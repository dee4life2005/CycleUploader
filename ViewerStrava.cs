/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/03/2013
 * Time: 13:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Json;
using System.Threading;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace CycleUploader
{
	/// <summary>
	/// Description of ViewerStrava.
	/// </summary>
	public partial class ViewerStrava : Form
	{
		private string _token;
		private Thread _threadProfile;
		private Thread _threadActivity;
		
		private delegate void AddListViewItemDelegate(Control ctrl, ListViewItem newItem);			
		private static void AddListViewItem(Control ctrl, ListViewItem newItem)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new AddListViewItemDelegate(AddListViewItem), new object[] {ctrl, newItem});
			}
			else{
				((ListView)ctrl).Items.Add(newItem);
			}
		}
		
		private delegate void NavigateWebControlDelegate(Control ctrl, string url);
		private void NavigateWebControl(Control ctrl, string url)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new NavigateWebControlDelegate(NavigateWebControl), new object[] { ctrl, url});
			}
			else{
				((WebBrowser)ctrl).Navigate(url);
			}
		}
		
		private delegate void ResizeListViewDelegate(Control ctrl);
		private void ResizeListView(Control ctrl)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new ResizeListViewDelegate(ResizeListView), new object[] { ctrl});
			}
			else{
				((ListView)ctrl).AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}
		}
		private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
		public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
		  	}
			else{
				control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
			}
		}
		private delegate string GetListViewItemValueDelegate(Control ctrl, int itemIdx, int subItemIdx);			
		private static string GetListViewItemValue(Control ctrl, int itemIdx, int subItemIdx)
		{
			if(ctrl.InvokeRequired){
				return (string)ctrl.Invoke(new GetListViewItemValueDelegate(GetListViewItemValue), new object[] {ctrl, itemIdx, subItemIdx});
			}
			else{
				return ((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].Text;
			}
		}
		private delegate void ClearListViewDelegate(Control ctrl);
		private void ClearListView(Control ctrl)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new ClearListViewDelegate(ClearListView), new object[] { ctrl});
			}
			else{
				((ListView)ctrl).Items.Clear();
			}
		}
		
		private delegate void SortListViewDelegate(Control ctrl, int column, SortOrder dir);
		private void SortListView(Control ctrl, int column, SortOrder dir)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SortListViewDelegate(SortListView), new object[] { ctrl, column, dir});
			}
			else{
				ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
				lvwColumnSorter.Order = dir;
				lvwColumnSorter.SortColumn = column;
				((ListView)ctrl).ListViewItemSorter = lvwColumnSorter;
				((ListView)ctrl).Sort();
			}
		}
		
		private delegate string GetListViewSelectedItemValueDelegate(Control ctrl, int itemIdx, int subItemIdx);			
		private static string GetListViewSelectedItemValue(Control ctrl, int itemIdx, int subItemIdx)
		{
			if(ctrl.InvokeRequired){
				return (string)ctrl.Invoke(new GetListViewSelectedItemValueDelegate(GetListViewSelectedItemValue), new object[] {ctrl, itemIdx, subItemIdx});
			}
			else{
				return ((ListView)ctrl).SelectedItems[itemIdx].SubItems[subItemIdx].Text;
			}
		}
		
		public ViewerStrava(string token)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_token = token;
		}
		
		void loadProfile()
		{
			string url = "https://www.strava.com/api/v3/athlete?";
			url += "access_token=" + _token;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.Timeout = 5000;
		
			// build the url encoded form post data
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					dynamic json = JsonValue.Parse(text);
					
					SetControlPropertyThreadSafe(lblProfileName,"Text", String.Format("{0} {1}",(string)json.firstname, (string)json.lastname));
					pbProfile.Load((string)json.profile);
					SetControlPropertyThreadSafe(frmGender,"Text",(string)json.sex);
					SetControlPropertyThreadSafe(frmLocation,"Text",(string)json.city + ", " + (string)json.state);
					SetControlPropertyThreadSafe(frmCreated,"Text", (string)json.created_at);
					SetControlPropertyThreadSafe(frmUpdated,"Text", (string)json.updated_at);
					SetControlPropertyThreadSafe(frmPremium,"Text", (bool)json.premium ? "Yes" : "No");
					
					for(int bike = 0; bike < json.bikes.Count; bike++){
						string [] bike_info = {
							json.bikes[bike].name,
							String.Format("{0:0.00}",((double)json.bikes[bike].distance * 0.00062137)) + "ml", // convert metres to miles
							json.bikes[bike].primary
						};
						
						AddListViewItem(frmBikes, new ListViewItem(bike_info));
					}
					
				}
			}
			
			//grpProfile.Refresh();
			getActivities();
			
		}
		
		public static DateTime ConvertFromUnixTimestamp(double timestamp)
		{
		    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		    return origin.AddSeconds(timestamp);
		}
		
		public static double ConvertToUnixTimestamp(DateTime date)
		{
		    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		    TimeSpan diff = date.ToUniversalTime() - origin;
		    return Math.Floor(diff.TotalSeconds);
		}
		
		void getActivities()
		{
			int act_count = 0;
			int page_no = 1;
			DateTime act_search_date_from = System.DateTime.Now.AddDays(-60);
			
			double unix_ticks = ConvertToUnixTimestamp(act_search_date_from);
			
			
			try{
			
			do{
				string url = "https://www.strava.com/api/v3/athlete/activities?";
				url += "access_token=" + _token;
				//url += "&after=" + Convert.ToInt32(unix_ticks);
				url += "&per_page=50";
				url += "&page=" + page_no.ToString();
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Method = "GET";
				httpWebRequest.Timeout = 5000;
			
				// build the url encoded form post data
				
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
					if (responseStream != null)
					{
						System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
						string text = streamReader.ReadToEnd();
						dynamic json = JsonValue.Parse(text);
						act_count = json.Count;
						for(int act = 0; act < json.Count; act++){
							TimeSpan duration_e = TimeSpan.FromSeconds((double)json[act].elapsed_time);
							TimeSpan duration_m = TimeSpan.FromSeconds((double)json[act].moving_time);
							string duration_elapsed =  string.Format("{0:D2} h {1:D2} m {2:D2} s", 
								    			duration_e.Hours, 
								    			duration_e.Minutes, 
								    			duration_e.Seconds
								    		);
							string duration_moving=  string.Format("{0:D2} h {1:D2} m {2:D2} s", 
								    			duration_m.Hours, 
								    			duration_m.Minutes, 
								    			duration_m.Seconds
								    		);
							
							int hr = 0;
							int cad= 0;
							JsonValue hr_tmp = json[act].average_heartrate;
							JsonValue cad_tmp= json[act].average_cadence;
							if(hr_tmp.JsonType != JsonType.Default){
								hr = (int)json[act].average_heartrate;
							}
							if(cad_tmp.JsonType != JsonType.Default){
								cad = (int)json[act].average_cadence;
							}
							
							string [] activity = {
								json[act].id,
								json[act].start_date,
								json[act].name,
								string.Format("{0:0.00}",(double)json[act].distance * 0.00062137) + " ml",
								duration_elapsed,
								duration_moving,
								string.Format("{0:0.00} mph",(double)json[act].average_speed * 2.23693629), // m/sec to mph
								string.Format("{0:0} rpm", cad),
								string.Format("{0:0} bpm", hr),
								string.Format("{0:0.00} watts", json[act].average_watts ?? 0),
								string.Format("{0:0.00} ft",(float)json[act].total_elevation_gain * 3.2808399), // metres to feet
								(bool)json[act].commute ? "Y": "",
								(bool)json[act].trainer ? "Y": "",
								(bool)json[act].manual ? "Y": "",
								(bool)json[act]["private"] ? "Y" : "",
								(bool)json[act].flagged ? "Y" : "",
								((int)json[act].achievement_count).ToString()
							};
							AddListViewItem(frmActivities, new ListViewItem(activity));
						}
					}
				}
				page_no++;
			}while(act_count > 0 && page_no <= 1);
			SortListView(frmActivities, 1, SortOrder.Descending);
			ResizeListView(frmActivities);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				this.Close();
			}
			
		}
		
		void ViewerStravaLoad(object sender, EventArgs e)
		{
			splitContainer1.Panel1Collapsed = false;
			splitContainer1.Panel2Collapsed = true;
			pnlActivityDetails.Visible = false;
			pnlLoadingActivity.Visible = true;
			_threadProfile = new Thread(new ThreadStart(this.loadProfile));
			_threadProfile.Start();
		}
		
		void FrmActivitiesClick(object sender, EventArgs e)
		{
			// check if there is an activity load thread already running,
			// if there is abort it and load based on the new click event
			try{
				if(_threadActivity.IsAlive){
					_threadActivity.Abort();
				}
			}catch{}
			
			SetControlPropertyThreadSafe(splitContainer1, "Panel1Collapsed", true);
			SetControlPropertyThreadSafe(splitContainer1, "Panel2Collapsed", false);
			SetControlPropertyThreadSafe(pnlLoadingActivity, "Visible", true);
			SetControlPropertyThreadSafe(label2, "Visible", true);
			
			_threadActivity = new Thread(new ThreadStart(this.loadActivity));
			_threadActivity.Start();
		}
		void loadActivity()
		{
			try{
			// get the activity information from Strava
			
			int activityId = Convert.ToInt32(GetListViewSelectedItemValue(frmActivities,0,0));
			
			string url = "https://www.strava.com/api/v3/activities/";
			url+= activityId.ToString();
			url += "?access_token=" + _token;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.Timeout = 5000;
		
			// build the url encoded form post data
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					dynamic json = JsonValue.Parse(text);
					
					TimeSpan duration_e_act = TimeSpan.FromSeconds((double)json.elapsed_time);
					TimeSpan duration_m_act = TimeSpan.FromSeconds((double)json.moving_time);
					string duration_elapsed_act =  string.Format("{0:D2}:{1:D2}:{2:D2}", 
						    			duration_e_act.Hours, 
						    			duration_e_act.Minutes, 
						    			duration_e_act.Seconds
						    		);
					string duration_moving_act =  string.Format("{0:D2}:{1:D2}:{2:D2}", 
						    			duration_m_act.Hours, 
						    			duration_m_act.Minutes, 
						    			duration_m_act.Seconds
						    		);
					int hr_avg = 0;
					int cad_avg = 0;
					int hr_max = 0;
					int cad_max = 0;
					JsonValue hr_tmp = json.average_heartrate;
					JsonValue cad_tmp= json.average_cadence;
					if(hr_tmp.JsonType != JsonType.Default){
						hr_avg = (int)json.average_heartrate;
					}
					if(cad_tmp.JsonType != JsonType.Default){
						cad_avg = (int)json.average_cadence;
					}
					hr_tmp = json.maximum_heartrate;
					
					if(hr_tmp.JsonType != JsonType.Default){
						hr_max = (int)json.max_heartrate;
					}
					DateTime dtStartDate= DateTime.Parse((string)json.start_date,  null, DateTimeStyles.RoundtripKind);
					
					SetControlPropertyThreadSafe(lblActivityName, "Text", (string)json.name);
					
					SetControlPropertyThreadSafe(lblStartDate, "Text", dtStartDate.ToString("dd/MM/yyyy HH:mm"));
					SetControlPropertyThreadSafe(lblLocation, "Text", (string)json.location_city + "," + (string)json.location_state);
					SetControlPropertyThreadSafe(lblAchievements, "Text", (string)json.achievement_count);
					SetControlPropertyThreadSafe(lblSegmentCount, "Text", json.segment_efforts.Count.ToString());
					SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} ft", (float)json.total_elevation_gain * 3.2808399));
					SetControlPropertyThreadSafe(lblMovingTime, "Text", duration_moving_act);
					SetControlPropertyThreadSafe(lblDistance, "Text", string.Format("{0:0.00}",(double)json.distance * 0.00062137) + " ml");
					SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph",(double)json.average_speed * 2.23693629)); // m/sec to mph
					SetControlPropertyThreadSafe(lblAvgCadence, "Text", string.Format("{0:0} rpm", cad_avg));
					SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", string.Format("{0:0} bpm", hr_avg));
					SetControlPropertyThreadSafe(lblAvgPower, "Text", string.Format("{0:0} watts", json.average_watts ?? 0));		
					
					SetControlPropertyThreadSafe(lblMaxSpeed, "Text", string.Format("{0:0.00} mph",(double)json.max_speed * 2.23693629)); // m/sec to mph
					//SetControlPropertyThreadSafe(lblMaxCadence, "Text", string.Format("{0:0} rpm", cad_max));
					SetControlPropertyThreadSafe(lblMaxHeartRate, "Text", string.Format("{0:0} bpm", hr_max));
					//SetControlPropertyThreadSafe(lblAvgPower, "Text", string.Format("{0:0.00} watts", json.average_watts ?? 0));		

					// flags
					SetControlPropertyThreadSafe(cbkCommute, "Checked", (bool)json.commute);
					SetControlPropertyThreadSafe(cbkTrainer, "Checked", (bool)json.trainer);
					SetControlPropertyThreadSafe(cbkManual, "Checked", (bool)json.manual);
					SetControlPropertyThreadSafe(cbkPrivate, "Checked", (bool)json["private"]);
					SetControlPropertyThreadSafe(cbkFlagged, "Checked", (bool)json.flagged);
					
					// add the segment effors
					ClearListView(lstSplits);
					
					for(int a = 0; a < json.segment_efforts.Count; a++){
						TimeSpan duration_e = TimeSpan.FromSeconds((double)json.segment_efforts[a].elapsed_time);
						string duration_elapsed =  string.Format("{0:D2} h {1:D2} m {2:D2} s", 
							    			duration_e.Hours, 
							    			duration_e.Minutes, 
							    			duration_e.Seconds
							    		);
						
						double avg_speed = 
							((double)json.segment_efforts[a].segment.distance * 0.00062137) / ((double)json.segment_efforts[a].elapsed_time / 60 / 60);
						
						string climb_cat = "";
						if((5-(int)json.segment_efforts[a].segment.climb_category) != 5){
							climb_cat = (5-(int)json.segment_efforts[a].segment.climb_category).ToString();
						}
						
						string [] seg = {
							(string)json.segment_efforts[a].name,
							string.Format("{0:0.00} ml",(double)json.segment_efforts[a].segment.distance * 0.00062137),
							string.Format("{0:0.00} mph",avg_speed),
							string.Format("{0:0.0} %", (float)json.segment_efforts[a].segment.average_grade),
							string.Format("{0:0.0} %", (float)json.segment_efforts[a].segment.maximum_grade),
							string.Format("{0:0.00} ft", (float)json.segment_efforts[a].segment.elevation_low * 3.2808399),
							string.Format("{0:0.00} ft", (float)json.segment_efforts[a].segment.elevation_high * 3.2808399),
							climb_cat,
							(string)json.segment_efforts[a].segment.city + ", " + (string)json.segment_efforts[a].segment.state,
							duration_elapsed,
							(string)json.segment_efforts[a].kom_rank,
							(string)json.segment_efforts[a].pr_rank,
							(string)json.segment_efforts[a].segment.id
						};
						AddListViewItem(lstSplits, new ListViewItem(seg));
					}
					ResizeListView(lstSplits);
					
					
					
					SetControlPropertyThreadSafe(lnkStrava, "Visible", true);
					
					string encPolyline = (string)json.map.polyline;
					encPolyline = encPolyline.Replace("\\", "\\\\");
					
					
					
					// load the map
					double start_lat = (double)json.start_latlng[0];
					double start_lng = (double)json.start_latlng[1];
					double finish_lat= (double)json.end_latlng[0];
					double finish_lng= (double)json.end_latlng[1];
					double lat_min=-1;
					double lat_max=-1;
					double lng_min=-1;
					double lng_max=-1;
					double lat = 0;
					double lng = 0;
					string js_coords = "";
					string js_mile_markers = "";
					string js_bounds = "";
					string js_centre = "";
					int zoom = 11;
					
					// add markers to signify the START / END of route
					js_mile_markers = 	"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map_c,title: 'Start'});" +
										"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map_c,title: 'Finish'});" + 
										js_mile_markers;
							
					// build the route html
					string routeHTML = @"
						<html>
						  <head>
						    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"">
						    <meta charset=""utf-8"">
						    <title>Cycle Route</title>
						    <style>
						      #map_canvas{
						        width:100%;height:100%;
						      }
						    </style>
						    <script type=""text/javascript"" src=""http://maps.google.com/maps/api/js?libraries=geometry&sensor=false""></script>

						    <script language=""javascript"">
						    var map_c;
						    var map_bounds; 
						    var map_centre;
						    var segmentRegion = null;
						    
						    // === first support methods that don't (yet) exist in v3
google.maps.LatLng.prototype.distanceFrom = function(newLatLng) {
  var EarthRadiusMeters = 6378137.0; // meters
  var lat1 = this.lat();
  var lon1 = this.lng();
  var lat2 = newLatLng.lat();
  var lon2 = newLatLng.lng();
  var dLat = (lat2-lat1) * Math.PI / 180;
  var dLon = (lon2-lon1) * Math.PI / 180;
  var a = Math.sin(dLat/2) * Math.sin(dLat/2) +
    Math.cos(lat1 * Math.PI / 180 ) * Math.cos(lat2 * Math.PI / 180 ) *
    Math.sin(dLon/2) * Math.sin(dLon/2);
  var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
  var d = EarthRadiusMeters * c;
  return d;
}

google.maps.LatLng.prototype.latRadians = function() {
  return this.lat() * Math.PI/180;
}

google.maps.LatLng.prototype.lngRadians = function() {
  return this.lng() * Math.PI/180;
}

// === A method for testing if a point is inside a polygon
// === Returns true if poly contains point
// === Algorithm shamelessly stolen from http://alienryderflex.com/polygon/ 
google.maps.Polygon.prototype.Contains = function(point) {
  var j=0;
  var oddNodes = false;
  var x = point.lng();
  var y = point.lat();
  for (var i=0; i < this.getPath().getLength(); i++) {
    j++;
    if (j == this.getPath().getLength()) {j = 0;}
    if (((this.getPath().getAt(i).lat() < y) && (this.getPath().getAt(j).lat() >= y))
    || ((this.getPath().getAt(j).lat() < y) && (this.getPath().getAt(i).lat() >= y))) {
      if ( this.getPath().getAt(i).lng() + (y - this.getPath().getAt(i).lat())
      /  (this.getPath().getAt(j).lat()-this.getPath().getAt(i).lat())
      *  (this.getPath().getAt(j).lng() - this.getPath().getAt(i).lng())<x ) {
        oddNodes = !oddNodes
      }
    }
  }
  return oddNodes;
}

// === A method which returns the approximate area of a non-intersecting polygon in square metres ===
// === It doesn't fully account for spherical geometry, so will be inaccurate for large polygons ===
// === The polygon must not intersect itself ===
google.maps.Polygon.prototype.Area = function() {
  var a = 0;
  var j = 0;
  var b = this.Bounds();
  var x0 = b.getSouthWest().lng();
  var y0 = b.getSouthWest().lat();
  for (var i=0; i < this.getPath().getLength(); i++) {
    j++;
    if (j == this.getPath().getLength()) {j = 0;}
    var x1 = this.getPath().getAt(i).distanceFrom(new google.maps.LatLng(this.getPath().getAt(i).lat(),x0));
    var x2 = this.getPath().getAt(j).distanceFrom(new google.maps.LatLng(this.getPath().getAt(j).lat(),x0));
    var y1 = this.getPath().getAt(i).distanceFrom(new google.maps.LatLng(y0,this.getPath().getAt(i).lng()));
    var y2 = this.getPath().getAt(j).distanceFrom(new google.maps.LatLng(y0,this.getPath().getAt(j).lng()));
    a += x1*y2 - x2*y1;
  }
  return Math.abs(a * 0.5);
}

// === A method which returns the length of a path in metres ===
google.maps.Polygon.prototype.Distance = function() {
  var dist = 0;
  for (var i=1; i < this.getPath().getLength(); i++) {
    dist += this.getPath().getAt(i).distanceFrom(this.getPath().getAt(i-1));
  }
  return dist;
}

// === A method which returns the bounds as a GLatLngBounds ===
google.maps.Polygon.prototype.Bounds = function() {
  var bounds = new google.maps.LatLngBounds();
  for (var i=0; i < this.getPath().getLength(); i++) {
    bounds.extend(this.getPath().getAt(i));
  }
  return bounds;
}

// === A method which returns a GLatLng of a point a given distance along the path ===
// === Returns null if the path is shorter than the specified distance ===
google.maps.Polygon.prototype.GetPointAtDistance = function(metres) {
  // some awkward special cases
  if (metres == 0) return this.getPath().getAt(0);
  if (metres < 0) return null;
  if (this.getPath().getLength() < 2) return null;
  var dist=0;
  var olddist=0;
  for (var i=1; (i < this.getPath().getLength() && dist < metres); i++) {
    olddist = dist;
    dist += this.getPath().getAt(i).distanceFrom(this.getPath().getAt(i-1));
  }
  if (dist < metres) {
    return null;
  }
  var p1= this.getPath().getAt(i-2);
  var p2= this.getPath().getAt(i-1);
  var m = (metres-olddist)/(dist-olddist);
  return new google.maps.LatLng( p1.lat() + (p2.lat()-p1.lat())*m, p1.lng() + (p2.lng()-p1.lng())*m);
}

// === A method which returns an array of GLatLngs of points a given interval along the path ===
google.maps.Polygon.prototype.GetPointsAtDistance = function(metres) {
  var next = metres;
  var points = [];
  // some awkward special cases
  if (metres <= 0) return points;
  var dist=0;
  var olddist=0;
  for (var i=1; (i < this.getPath().getLength()); i++) {
    olddist = dist;
    dist += this.getPath().getAt(i).distanceFrom(this.getPath().getAt(i-1));
    while (dist > next) {
      var p1= this.getPath().getAt(i-1);
      var p2= this.getPath().getAt(i);
      var m = (next-olddist)/(dist-olddist);
      points.push(new google.maps.LatLng( p1.lat() + (p2.lat()-p1.lat())*m, p1.lng() + (p2.lng()-p1.lng())*m));
      next += metres;    
    }
  }
  return points;
}

// === A method which returns the Vertex number at a given distance along the path ===
// === Returns null if the path is shorter than the specified distance ===
google.maps.Polygon.prototype.GetIndexAtDistance = function(metres) {
  // some awkward special cases
  if (metres == 0) return this.getPath().getAt(0);
  if (metres < 0) return null;
  var dist=0;
  var olddist=0;
  for (var i=1; (i < this.getPath().getLength() && dist < metres); i++) {
    olddist = dist;
    dist += this.getPath().getAt(i).distanceFrom(this.getPath().getAt(i-1));
  }
  if (dist < metres) {return null;}
  return i;
}

// === A function which returns the bearing between two vertices in decgrees from 0 to 360===
// === If v1 is null, it returns the bearing between the first and last vertex ===
// === If v1 is present but v2 is null, returns the bearing from v1 to the next vertex ===
// === If either vertex is out of range, returns void ===
google.maps.Polygon.prototype.Bearing = function(v1,v2) {
  if (v1 == null) {
    v1 = 0;
    v2 = this.getPath().getLength()-1;
  } else if (v2 ==  null) {
    v2 = v1+1;
  }
  if ((v1 < 0) || (v1 >= this.getPath().getLength()) || (v2 < 0) || (v2 >= this.getPath().getLength())) {
    return;
  }
  var from = this.getPath().getAt(v1);
  var to = this.getPath().getAt(v2);
  if (from.equals(to)) {
    return 0;
  }
  var lat1 = from.latRadians();
  var lon1 = from.lngRadians();
  var lat2 = to.latRadians();
  var lon2 = to.lngRadians();
  var angle = - Math.atan2( Math.sin( lon1 - lon2 ) * Math.cos( lat2 ), Math.cos( lat1 ) * Math.sin( lat2 ) - Math.sin( lat1 ) * Math.cos( lat2 ) * Math.cos( lon1 - lon2 ) );
  if ( angle < 0.0 ) angle  += Math.PI * 2.0;
  angle = angle * 180.0 / Math.PI;
  return parseFloat(angle.toFixed(1));
}




// === Copy all the above functions to GPolyline ===
google.maps.Polyline.prototype.Contains             = google.maps.Polygon.prototype.Contains;
google.maps.Polyline.prototype.Area                 = google.maps.Polygon.prototype.Area;
google.maps.Polyline.prototype.Distance             = google.maps.Polygon.prototype.Distance;
google.maps.Polyline.prototype.Bounds               = google.maps.Polygon.prototype.Bounds;
google.maps.Polyline.prototype.GetPointAtDistance   = google.maps.Polygon.prototype.GetPointAtDistance;
google.maps.Polyline.prototype.GetPointsAtDistance  = google.maps.Polygon.prototype.GetPointsAtDistance;
google.maps.Polyline.prototype.GetIndexAtDistance   = google.maps.Polygon.prototype.GetIndexAtDistance;
google.maps.Polyline.prototype.Bearing              = google.maps.Polygon.prototype.Bearing;
						    
						    function initialize() {
							    var myOptions = {
							        zoom: 11,
							        mapTypeId: google.maps.MapTypeId.ROADMAP
							    }
							    map_c = new google.maps.Map(document.getElementById(""map_canvas""), myOptions);
        
							    var decodedPath = google.maps.geometry.encoding.decodePath('" + encPolyline + @"'); 
							    
							    var setRegion = new google.maps.Polyline({
							        path: decodedPath,
							        strokeColor: '#FF0000',
							        strokeOpacity: 1.0,
							        strokeWeight: 2,
							        map: map_c
							    });
							    map_bounds = new google.maps.LatLngBounds();
							    " + js_mile_markers + @"
							    var points = setRegion.GetPointsAtDistance(1609.344);


							    for (var i=0; i<points.length; i++) {
							    	new google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=' + (i+1) + '|aa0000|FFFFFF',position: points[i],map: map_c,title: (i+1).toString()});
							    }
							    setRegion.getPath().forEach(function(e){map_bounds.extend(e);});
							    map_c.fitBounds(map_bounds);
							    
							}
							
							window.onresize = pageresize;
				      
						      function pageresize()
						      {
						       google.maps.event.trigger(map_c, 'resize');
						       map_c.fitBounds(map_bounds);
						      }

							function decodeLevels(encodedLevelsString) {
							    var decodedLevels = [];
							
							    for (var i = 0; i < encodedLevelsString.length; ++i) {
							        var level = encodedLevelsString.charCodeAt(i) - 63;
							        decodedLevels.push(level);
							    }
							    return decodedLevels;
							}
						    </script>
						  </head>
						  <body onload=""initialize()"" >
						    <div id=""map_canvas""></div>
						  </body>
						</html>				
					";
					
					try{
						if(System.IO.File.Exists(Application.StartupPath + "\\strava_route.html"))
						{
						   	System.IO.File.Delete(Application.StartupPath + "\\strava_route.html");
						}
						FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\strava_route.html");
			            StreamWriter writer = new StreamWriter(fs);  
			            writer.Write(routeHTML);  
			            writer.Close();
			            writer.Dispose();
			            fs.Dispose();
						
			            NavigateWebControl(webBrowser1, Application.StartupPath + "\\strava_route.html");
					}
					catch{
						MessageBox.Show("Map Update Failed. Try re-selecting the activity.","Error loading map", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
					finally{
						
					}
					
					
					SetControlPropertyThreadSafe(splitContainer1, "Panel1Collapsed", true);
					SetControlPropertyThreadSafe(splitContainer1, "Panel2Collapsed", false);
					SetControlPropertyThreadSafe(pnlLoadingActivity, "Visible", false);
					SetControlPropertyThreadSafe(pnlActivityDetails, "Visible", true);
				}
			}
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.Close();
			}
			
		}
		
		void LnkStravaLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			int activityId = Convert.ToInt32(GetListViewSelectedItemValue(frmActivities,0,0));
			string url = "http://www.strava.com/activities/" + activityId.ToString();
			System.Diagnostics.Process.Start(url);
		}
		
		void BtnMapFullscreenClick(object sender, EventArgs e)
		{
			FullscreenMap fsMap;
			
			fsMap = new FullscreenMap(Application.StartupPath + "\\strava_route.html");
			fsMap.ShowDialog();	
		}
		
		void BtnActivityCloseClick(object sender, EventArgs e)
		{
			SetControlPropertyThreadSafe(splitContainer1, "Panel1Collapsed", false);
			SetControlPropertyThreadSafe(splitContainer1, "Panel2Collapsed", true);
			SetControlPropertyThreadSafe(pnlActivityDetails, "Visible", false);
			SetControlPropertyThreadSafe(pnlLoadingActivity, "Visible", true);
		}
		
		void CbkCommuteClick(object sender, EventArgs e)
		{
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
			HtmlElement s = webBrowser1.Document.CreateElement("script");
			
			string seg_path = @"
				if(segmentRegion != null){
					segmentRegion.setMap(null);
				}
				map_c.fitBounds(map_bounds);			
			";
			
			s.SetAttribute("text",seg_path);//"alert('hello');");
			head.AppendChild(s);
		}
		
		void LstSplitsClick(object sender, EventArgs e)
		{
			int segmentId = Convert.ToInt32(GetListViewSelectedItemValue(lstSplits,0,12));
			
			string url = "https://www.strava.com/api/v3/segments/";
			url+= segmentId.ToString();
			url += "?access_token=" + _token;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.Timeout = 5000;
		
			// build the url encoded form post data
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					dynamic json = JsonValue.Parse(text);
					string seg_polyline = (string)json.map.polyline;
					
					HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
					HtmlElement s = webBrowser1.Document.CreateElement("script");
					
					string seg_path = @"
						if(segmentRegion != null){
							segmentRegion.setMap(null);
						}
						var decodedPath = google.maps.geometry.encoding.decodePath('" + seg_polyline.Replace("\\","\\\\") + @"'); 
						
						segmentRegion = new google.maps.Polyline({
						    path: decodedPath,
						    strokeColor: '#0000FF',
						    strokeOpacity: 1.0,
						    strokeWeight: 3,
						    map: map_c
						});
						bounds = new google.maps.LatLngBounds();
						segmentRegion.getPath().forEach(function(e){bounds.extend(e);});
						map_c.fitBounds(bounds);			
					";
					
					s.SetAttribute("text",seg_path);//"alert('hello');");
					head.AppendChild(s);
					
				}
			}
		}
	}
}
