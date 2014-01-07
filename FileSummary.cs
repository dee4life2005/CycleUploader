/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 29/03/2013
 * Time: 11:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Reflection;
using Dynastream.Fit;
using System.Diagnostics;

namespace CycleUploader
{
	/// <summary>
	/// Description of FileSummary.
	/// </summary>
	public partial class FileSummary : Form
	{
		private int _file;
		private SQLiteConnection _db;
		private Thread _loading;
				
		public FileSummary(int idFile, SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_file = idFile;
			_db = db;
		}
		
		private delegate void RefreshZedgraphDelegate(ZedGraphControl ctrl);
		private void RefreshZedgraph(ZedGraphControl ctrl)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new RefreshZedgraphDelegate(RefreshZedgraph), new object[]{ctrl});
			}
			else{
				ctrl.Refresh();
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
				((ListView)ctrl).Groups.Clear();
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
		
		private delegate void SetListViewItemValueDelegate(Control ctrl, int itemIdx, int subItemIdx, string value);			
		private static void SetListViewItemValue(Control ctrl, int itemIdx, int subItemIdx, string value)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SetListViewItemValueDelegate(SetListViewItemValue), new object[] {ctrl, itemIdx, subItemIdx, value});
			}
			else{
				((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].Text = value;
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
		
		private delegate void SetStatusProgressThreadSafeDelegate(ToolStrip control, string field, int value);
		public void SetStatusProgressThreadSafe(ToolStrip control, string field, int value)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetStatusProgressThreadSafeDelegate(SetStatusProgressThreadSafe), new object[] { control, field, value});
		  	}
			else{
				switch(field){
					case "Value":
						//statusBarProgress.Value = value;
						break;
					case "Maximum":
						//statusBarProgress.Maximum = value;
						break;
					case "Visible":
						//statusBarProgress.Visible = Convert.ToBoolean(value);
						break;
				}
			}
		}
		
		private delegate void setTabDelegate(Control ctrl, string tabName);
		private static void setTab(Control ctrl, string tabName)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new setTabDelegate(setTab), new object[] {ctrl, tabName});
			}
			else{
				((TabControl)ctrl).SelectTab(tabName);
			}
		}

		private delegate void SetLinkLabelUrlDelegate(Control ctrl, string url);
		private static void SetLinkLabelUrl(Control ctrl, string url)
		{
			if (ctrl.InvokeRequired)
			{
				ctrl.Invoke(new SetLinkLabelUrlDelegate(SetLinkLabelUrl), new object[] { ctrl, url });
			}
			else
			{
				((LinkLabel)ctrl).Links.Clear();
				((LinkLabel)ctrl).Links.Add(0, ((LinkLabel)ctrl).Text.Length, url);
			}
		}
		
		
		void loadFileHistoryInformation()
		{
			string gradient_debug = "";
			SQLiteCommand command = new SQLiteCommand(_db);
			SQLiteDataReader rdrSummary;
			SQLiteDataReader rdr;
			string sql = "";
			// load the file summary
			sql = string.Format("select * from view_file_summary where idFile = {0}", _file);
			
			double total_ride_duration = 0;
			
			command.CommandText = sql;
			rdrSummary = command.ExecuteReader();
			if(rdrSummary.HasRows){
				rdrSummary.Read();
				
				TimeSpan tsDuration = TimeSpan.FromSeconds(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsDuration")) ? 0 : Convert.ToInt32(rdrSummary["fsDuration"]));
				TimeSpan tsMoving = TimeSpan.FromSeconds(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsMovingTime")) ? 0 : Convert.ToInt32(rdrSummary["fsMovingTime"]));
			
				SetControlPropertyThreadSafe(lblHistoryName, "Text", (string)rdrSummary["fileName"]);
				SetControlPropertyThreadSafe(lblHistoryDate, "Text", ((System.DateTime)rdrSummary["fileActivityDateTime"]).ToString("dd MMMM yyyy HH:mm"));
				SetControlPropertyThreadSafe(lblHistoryDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", tsDuration.Hours, tsDuration.Minutes, tsDuration.Seconds));
				SetControlPropertyThreadSafe(lblHistoryDistance, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsDistance")) ? "-" : string.Format("{0:0.00} miles", Convert.ToDouble(rdrSummary["fsDistance"])));
				SetControlPropertyThreadSafe(lblHistoryCalories, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsCalories")) ? "-" : Convert.ToInt32(rdrSummary["fsCalories"]).ToString());
				SetControlPropertyThreadSafe(lblHistoryAvgHeartRate, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsAvgHeart")) ? "-" : Convert.ToInt32(rdrSummary["fsAvgHeart"]).ToString());
				SetControlPropertyThreadSafe(lblHistoryAvgCadence, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsAvgCadence")) ? "-" : Convert.ToInt32(rdrSummary["fsAvgCadence"]).ToString());
				SetControlPropertyThreadSafe(lblHistoryAvgSpeed, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsAvgSpeed")) ? "-" : string.Format("{0:0.00} mph", Convert.ToDouble(rdrSummary["fsAvgSpeed"])));
				SetControlPropertyThreadSafe(lblHistoryMovingTime, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", tsMoving.Hours, tsMoving.Minutes, tsMoving.Seconds));
				SetControlPropertyThreadSafe(lblHistoryTotalAscent, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsTotalAscent")) ? "-" : string.Format("{0:0.00} ft",Convert.ToDouble(rdrSummary["fsTotalAscent"])));
				SetControlPropertyThreadSafe(lblHistoryTotalDescent, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsTotalDescent")) ? "-" : string.Format("{0:0.00} ft",Convert.ToDouble(rdrSummary["fsTotalDescent"])));
				SetControlPropertyThreadSafe(lblHistoryMaxHeartRate, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsMaxHeartRate")) ? "-" : Convert.ToDouble(rdrSummary["fsMaxHeartRate"]).ToString());
				SetControlPropertyThreadSafe(lblHistoryMaxCadence, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsMaxCadence")) ? "-" : Convert.ToDouble(rdrSummary["fsMaxCadence"]).ToString());
				SetControlPropertyThreadSafe(lblHistoryMaxSpeed, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fsMaxSpeed")) ? "-" : string.Format("{0:0.00} mph",Convert.ToDouble(rdrSummary["fsMaxSpeed"])));
				SetControlPropertyThreadSafe(txtHistoryNotes, "Text", rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileActivityNotes")) ? "" : (string)rdrSummary["fileActivityNotes"]);

				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileUploadRunkeeper"))){
					SetControlPropertyThreadSafe(cbkHistoryUploadRunkeeper, "Checked", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadRunkeeper, "Enabled", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadRunkeeper, "BackColor", Color.Gainsboro);
				}else{
					SetControlPropertyThreadSafe(cbkHistoryUploadRunkeeper, "Checked", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadRunkeeper, "Enabled", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadRunkeeper, "BackColor", Color.PaleGreen);

					SetLinkLabelUrl(linkHistoryUploadStrava, rdrSummary["fileUploadRunkeeper"].ToString());
					SetControlPropertyThreadSafe(linkHistoryUploadRunkeeper, "Enabled", true);
				}
				//
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileUploadStrava"))){
					SetControlPropertyThreadSafe(cbkHistoryUploadStrava, "Checked", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadStrava, "Enabled", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadStrava, "BackColor", Color.Gainsboro);
				}else{
					SetControlPropertyThreadSafe(cbkHistoryUploadStrava, "Checked", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadStrava, "Enabled", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadStrava, "BackColor", Color.PaleGreen);

					SetLinkLabelUrl(linkHistoryUploadStrava, rdrSummary["fileUploadStrava"].ToString());
					SetControlPropertyThreadSafe(linkHistoryUploadStrava, "Enabled", true);
				}
				// 
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileUploadGarmin"))){
					SetControlPropertyThreadSafe(cbkHistoryUploadGarmin, "Checked", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadGarmin, "Enabled",false);
					SetControlPropertyThreadSafe(pnlHistoryUploadGarmin, "BackColor", Color.Gainsboro);
				}else{
					SetControlPropertyThreadSafe(cbkHistoryUploadGarmin, "Checked",true);
					SetControlPropertyThreadSafe(pnlHistoryUploadGarmin, "Enabled", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadGarmin, "BackColor", Color.PaleGreen);

					SetLinkLabelUrl(linkHistoryUploadStrava, rdrSummary["fileUploadGarmin"].ToString());
					SetControlPropertyThreadSafe(linkHistoryUploadGarmin, "Enabled", true);
				}
				// 
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileUploadRWGPS"))){
					SetControlPropertyThreadSafe(cbkHistoryUploadRideWithGPS, "Checked", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadRideWithGPS, "Enabled", false);
					SetControlPropertyThreadSafe(pnlHistoryUploadRideWithGPS, "BackColor", Color.Gainsboro);
				}else{
					SetControlPropertyThreadSafe(cbkHistoryUploadRideWithGPS, "Checked", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadRideWithGPS, "Enabled", true);
					SetControlPropertyThreadSafe(pnlHistoryUploadRideWithGPS, "BackColor", Color.PaleGreen);

					SetLinkLabelUrl(linkHistoryUploadStrava, rdrSummary["fileUploadRWGPS"].ToString());
					SetControlPropertyThreadSafe(linkHistoryUploadRideWithGPS, "Enabled", true);
				}
				
				// display the activity "is commute" flag
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileIsCommute"))){
					SetControlPropertyThreadSafe(cbkSummaryIsCommute, "Checked", false);
				}
				else{
					SetControlPropertyThreadSafe(cbkSummaryIsCommute, "Checked", (Convert.ToInt32(rdrSummary["fileIsCommute"]) == 1 ? true : false));
				}
				
				// display the activity "is stationary trainer" flag
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileIsStationaryTrainer"))){
					SetControlPropertyThreadSafe(cbkSummaryIsStationaryTrainer, "Checked", false);
				}
				else{
					SetControlPropertyThreadSafe(cbkSummaryIsStationaryTrainer, "Checked", (Convert.ToInt32(rdrSummary["fileIsStationaryTrainer"]) == 1 ? true : false));
				}
				
				// display the activity "is included in stats" flag
				if(rdrSummary.IsDBNull(rdrSummary.GetOrdinal("fileIsIncludedInStats"))){
					SetControlPropertyThreadSafe(cbkSummaryIncludeInStats, "Checked", false);
				}
				else{
					SetControlPropertyThreadSafe(cbkSummaryIncludeInStats, "Checked", (Convert.ToInt32(rdrSummary["fileIsIncludedInStats"]) == 1 ? true : false));
				}
			}
			
			rdrSummary.Close();
			rdrSummary.Dispose();
			
			// load and process the archived trackpoints for file
			sql = string.Format("select * from FileTrackpoints where idFile = {0}", 
			                           _file
			                          );
			
			command.CommandText = sql;
			rdr = command.ExecuteReader();
			if(rdr.HasRows)
			{
				int rowCount = 0;
				//double altitude_max = 0;
				string tag = "";
				
				int currentMileSearch = 1;
				double runningMileDistance = 0;
				double runningDuration = 0;
				double runningDurationPrevious = 0;
				// google map strings
				double lat_min=-1;
				double lat_max=-1;
				double lng_min=-1;
				double lng_max=-1;
				double lat = 0;
				double lng = 0;
				double start_lat = 0; 
				double start_lng = 0;
				double finish_lat = 0;
				double finish_lng = 0;
				double prev_lat = 0;
				double prev_lng = 0;
				string js_coords = "";
				string js_mile_markers = "";
				string js_bounds = "";
				
				// initialise the altitude chart
				zedHistoryAltitude.GraphPane.Legend.IsVisible = false;
				zedHistoryAltitude.GraphPane.Title.Text = "Altitude";
				zedHistoryAltitude.GraphPane.XAxis.Title.Text = "Distance (miles)";
				zedHistoryAltitude.GraphPane.YAxis.Title.Text = "Feet";
				zedHistoryAltitude.GraphPane.XAxis.Scale.MagAuto = false;
				zedHistoryAltitude.GraphPane.CurveList.Clear();
				zedHistoryAltitude.GraphPane.GraphObjList.Clear();
				zedHistoryAltitude.GraphPane.IsFontsScaled = false;
				// initialise the speed chart
				zedHistorySpeed.GraphPane.YAxisList.Clear();
				zedHistorySpeed.GraphPane.AddYAxis("mph");
				zedHistorySpeed.GraphPane.AddYAxis("Altitude (ft)");
				zedHistorySpeed.GraphPane.Legend.IsVisible = false;
				zedHistorySpeed.GraphPane.Title.Text = "Speed";
				zedHistorySpeed.GraphPane.XAxis.Title.Text = "Distance (miles)";
				zedHistorySpeed.GraphPane.YAxis.Title.Text = "mph";
				zedHistorySpeed.GraphPane.XAxis.Scale.MagAuto = false;
				zedHistorySpeed.GraphPane.CurveList.Clear();
				zedHistorySpeed.GraphPane.GraphObjList.Clear();
				zedHistorySpeed.GraphPane.IsFontsScaled = false;
				
				// initialise the cadence chart
				zedHistoryCadence.GraphPane.YAxisList.Clear();
				zedHistoryCadence.GraphPane.AddYAxis("rpm");
				zedHistoryCadence.GraphPane.AddYAxis("Altitude (ft)");
				zedHistoryCadence.GraphPane.Legend.IsVisible = false;
				zedHistoryCadence.GraphPane.Title.Text = "Cadence";
				zedHistoryCadence.GraphPane.XAxis.Title.Text = "Distance (miles)";
				zedHistoryCadence.GraphPane.YAxis.Title.Text = "rpm";
				zedHistoryCadence.GraphPane.XAxis.Scale.MagAuto = false;
				zedHistoryCadence.GraphPane.CurveList.Clear();
				zedHistoryCadence.GraphPane.GraphObjList.Clear();
				zedHistoryCadence.GraphPane.IsFontsScaled = false;
				
				// initialise the heart chart
				zedHistoryHeart.GraphPane.YAxisList.Clear();
				zedHistoryHeart.GraphPane.AddYAxis("bpm");
				zedHistoryHeart.GraphPane.AddYAxis("Altitude (ft)");
				zedHistoryHeart.GraphPane.Legend.IsVisible = false;
				zedHistoryHeart.GraphPane.Title.Text = "Heart";
				zedHistoryHeart.GraphPane.XAxis.Title.Text = "Distance (miles)";
				zedHistoryHeart.GraphPane.YAxis.Title.Text = "bpm";
				zedHistoryHeart.GraphPane.XAxis.Scale.MagAuto = false;
				zedHistoryHeart.GraphPane.CurveList.Clear();
				zedHistorySpeed.GraphPane.GraphObjList.Clear();
				zedHistoryHeart.GraphPane.IsFontsScaled = false;
				
				PointPairList graphListAltitude = new PointPairList();
				PointPairList graphListSpeed = new PointPairList();
				PointPairList graphListCadence = new PointPairList();
				PointPairList graphListHeart = new PointPairList();
				
				double distance = 0;
				double p_duration = 0;
				
				double prev_altitude = 0;
				double prev_distance = 0;
				double distance_metres = 0;
				double gradient = 0;
				
				while(rdr.Read()){
					rowCount++;
					
					if(rowCount==1){
						start_lat = Convert.ToDouble(rdr["tpLatitude"]);
						start_lng = Convert.ToDouble(rdr["tpLongitude"]);
					}
					// update the last point coordinates
					finish_lat = Convert.ToDouble(rdr["tpLatitude"]);
					finish_lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					
					distance_metres = Convert.ToDouble(rdr["tpDistance"]);
					distance = (distance_metres/1000) * 0.621371192; // convert metres to miles
					double duration = Convert.ToDouble(rdr["tpDuration"]);
					double altitude = Convert.ToDouble(rdr["tpAltitude"]);
					double speed = Convert.ToDouble(rdr["tpSpeed"]) * 2.23693629; // metres per second to mph
					double cadence = Convert.ToDouble(rdr["tpCadence"]);
					double heart = Convert.ToDouble(rdr["tpHeart"]);
					
					tag = (string)rdr["tpTime"] + "\r\nDistance = " + distance.ToString("0.00") + " miles\r\n";
					
					if(rowCount > 1){
						double cur_distance_metres = GeoMath.Distance(
							finish_lat, finish_lng, prev_lat, prev_lng, GeoMath.MeasureUnits.Kilometers
						) * 1000; 
						double alt_diff = altitude - prev_altitude;
						//double gradient = GeoMath.Gradient(distance_metres - prev_distance,altitude*0.3048, prev_altitude*0.3048);
						gradient = (Math.Abs((altitude*0.3048)-(prev_altitude*0.3048)) / (cur_distance_metres)) * 100;
						gradient_debug += string.Format("altitude1 = {0}m, altitude2 = {1}m, distance = {2}m, gradient = {3}",
						                                altitude*0.3048, 
						                                prev_altitude*0.3048,
						                                cur_distance_metres,
						                                gradient
						                                );
						gradient_debug += Environment.NewLine;						
						
						// update the previous data for the next iteration
						prev_distance = cur_distance_metres;
						prev_altitude= Convert.ToDouble(rdr["tpAltitude"]);
					}
					
					if(distance != 0){
						//graphListAltitude.Add(distance,altitude,tag + "Altitude = " + altitude.ToString("0.00") + " feet" + Environment.NewLine + "Gradient = " + gradient.ToString("0.00") + "%");
						graphListAltitude.Add(distance,altitude,tag + "Altitude = " + altitude.ToString("0.00") + " feet");
						graphListSpeed.Add(distance, speed, tag + "Speed = " + speed.ToString("0.00") + " mph");
						graphListCadence.Add(distance, cadence, tag + "Cadence = " + cadence.ToString("0") + " rpm");
						graphListHeart.Add(distance, heart, tag + "Heart-Rate = " + heart.ToString("0") + " bpm");
						if(rowCount > 1){
							total_ride_duration += (duration - p_duration);
						}
					}
					
					lat = Convert.ToDouble(rdr["tpLatitude"]);
					lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					// if row is > 1 then we have the previous point data to be able to calculate the gradient
					
					prev_lat = finish_lat;
					prev_lng = finish_lng;
					p_duration = duration;
					
					// increment the running totals
					runningDuration = duration;
					runningMileDistance = distance;

					// check if we've reached threshold for current search miles
					if(runningMileDistance > currentMileSearch){
						TimeSpan tsPace = TimeSpan.FromSeconds(runningDuration-runningDurationPrevious);
						RideWithGpsMileSplit mileSplit = new RideWithGpsMileSplit();
						mileSplit.label = string.Format("Mile {0}",currentMileSearch);
						mileSplit.speed = string.Format("{0:0.00} mph", (1 / ((runningDuration - runningDurationPrevious)/ 3600)));
						mileSplit.pace = string.Format("{0:D2} h {1:D2} m {2:D2} s", tsPace.Hours, tsPace.Minutes, tsPace.Seconds);
						
						AddListViewItem(lstMileSplits, new ListViewItem( new string[] {mileSplit.label, mileSplit.speed, mileSplit.pace}));
			
						TimeSpan tmp_ts = TimeSpan.FromSeconds(Convert.ToDouble(rdr["tpDuration"]));
						string mile_marker_tag = "Time since start of ride: " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
							tmp_ts.Hours, 
							tmp_ts.Minutes, 
							tmp_ts.Seconds
						);
						js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + (currentMileSearch) + "|95E978|004400',position: new google.maps.LatLng(" + lat + "," + lng + "),map: map,title: 'Mile " + (currentMileSearch) + "\\r\\n" + mile_marker_tag + "'});";
						
						// reset the running duration
						// and increment the mile search counter for the next mile
						runningDurationPrevious = runningDuration;
						runningDuration = 0;
						runningMileDistance = 0;
						currentMileSearch++;
					}
					
					
					
					// update the max / min longitude / latitude
					
					if(lat != 0 && lng != 0 && Math.Ceiling(lat) != 180 && Math.Ceiling(lng) != 180){
						if(lat_min == -1){ lat_min = lat;}
						if(lat_max == -1){ lat_max = lat;}
						if(lng_min == -1){ lng_min = lng;}
						if(lng_max == -1){ lng_max = lng;}
						
						if(lat < lat_min){ lat_min = lat;}
						if(lat > lat_max){ lat_max = lat;}
						if(lng < lng_min){ lng_min = lng;}
						if(lng > lng_max){ lng_max = lng;}
						if(rowCount > 1){
							js_coords += ",";
						}
						js_coords += "\r\nnew google.maps.LatLng(" + Convert.ToDouble(rdr["tpLatitude"]).ToString() + "," + Convert.ToDouble(rdr["tpLongitude"]).ToString() + ")";
					}
					
					
				}
				rdr.Close();
				rdr.Dispose();
				
				js_mile_markers = "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});" + 
								js_mile_markers;
				
				// create a bounding box for the map - so it can auto-zoom to the best level of detail
				js_bounds = @" 
					var latlngbounds = new google.maps.LatLngBounds();
					latlngbounds.extend(new google.maps.LatLng(" + lat_min + @"," + lng_min + @"));
					latlngbounds.extend(new google.maps.LatLng(" + lat_max + @"," + lng_max + @"));
					map.fitBounds(latlngbounds);
				";
				
				// build the route html
				string routeHTML = @"
					<html>
					  <head>
					    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"">
					    <meta charset=""utf-8"">
					    <title>Cycle Route</title>
					    <style>
					      #map_canvas{
					        width:100%;
					        height:100%;
					      }
					    </style>
					    <script src=""https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false""></script>
					    <script type=""text/javascript"" language=""javascript"">
							var map;
					      function initialize() {
					        var mapOptions = {
					          mapTypeId: google.maps.MapTypeId.TERRAIN
					        };
					
					        map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
					
					        var cycleRouteCoords = [
					          " + js_coords + @"
					        ];
					        var cycleRoute = new google.maps.Polyline({
					          path: cycleRouteCoords,
					          strokeColor: '#FF0000',
					          strokeOpacity: 1.0,
					          strokeWeight: 2
					        });
					
					        cycleRoute.setMap(map);
					        
					        " + js_mile_markers + @"
					        " + js_bounds + @"
					      }
					      
					      window.onresize = pageresize;
					      
					      function pageresize()
					      {
					       google.maps.event.trigger(map, 'resize');
					       " + js_bounds + @"					       
					      }
					    </script>
					  </head>
					  <body onload=""initialize()"" >
					    <div id=""map_canvas""></div>
					  </body>
					</html>				
				";
			
				try{
					if(System.IO.File.Exists(Application.StartupPath + "\\history_route.html"))
					{
					   	System.IO.File.Delete(Application.StartupPath + "\\history_route.html");
					}
					FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\history_route.html");
		            StreamWriter writer = new StreamWriter(fs);  
		            writer.Write(routeHTML);  
		            writer.Close();
		            writer.Dispose();
		            fs.Dispose();
		            webBrowserHistoryMap.Navigate(Application.StartupPath + "\\history_route.html");
				}
				catch(Exception ex){
					MessageBox.Show("Map Update Failed. Try re-selecting the activity." + ex.Message ,"Error loading map", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				finally{
					//tabMap.Enabled = true;
				}
				
				
				// add the altitude curve
				zedHistoryAltitude.GraphPane.AddCurve("Altitude",graphListAltitude,Color.Green, SymbolType.None).Line.Width = 1;					
				zedHistoryAltitude.GraphPane.XAxis.Scale.Max = distance;
				zedHistoryAltitude.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistoryAltitude.GraphPane.YAxis.MajorGrid.IsVisible = true;
				zedHistoryAltitude.AxisChange();
				RefreshZedgraph(zedHistoryAltitude);
				
				// add the speed curve
				zedHistorySpeed.GraphPane.AddCurve("Speed",graphListSpeed, Color.Blue, SymbolType.None).Line.Width = 1;					
				zedHistorySpeed.GraphPane.XAxis.Scale.Max = distance;
				zedHistorySpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistorySpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				LineItem ln_altitude  = zedHistorySpeed.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistorySpeed.AxisChange();
				RefreshZedgraph(zedHistorySpeed);
				
				// add the cadence curve
				zedHistoryCadence.GraphPane.AddCurve("Cadence",graphListCadence, Color.Magenta, SymbolType.None).Line.Width = 1;					
				zedHistoryCadence.GraphPane.XAxis.Scale.Max = distance;
				zedHistoryCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistoryCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				ln_altitude  = zedHistoryCadence.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistoryCadence.AxisChange();
				RefreshZedgraph(zedHistoryCadence);
				
				// add the heart rate curve
				zedHistoryHeart.GraphPane.AddCurve("Heart-Rate",graphListHeart, Color.Red, SymbolType.None).Line.Width = 1;					
				zedHistoryHeart.GraphPane.XAxis.Scale.Max = distance;
				zedHistoryHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistoryHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				ln_altitude  = zedHistoryHeart.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistoryHeart.AxisChange();
				RefreshZedgraph(zedHistoryHeart);
				
				ResizeListView(lstMileSplits);
				
			}
			
			try{
				sql = string.Format(@"select  f.fileActivityDateTime,
					        f.fileActivityName,
					        hr.idZone,			
							ifnull(hr.zoneLabel, ""no data"") as zoneLabel,
					        SUM(hduration.duration) as `duration_seconds`,
					        (SUM(hduration.duration) / CAST(fs.fsDuration as double)) * 100 as `pct_total`,
					        cast(fs.fsDuration as double) as fsDuration
					from (
					/*select 1 as idFile, 100 as tpHeart, 1 as duration*/
					  select ft.idFile, ft.tpHeart, IFNULL(MIN(ft2.tpDuration),0) - ft.tpDuration as duration
					  from FileTrackpoints ft
					  join FileTrackpoints ft2 on ft.idFile = ft2.idFile and ft.tpTime < ft2.tpTime and ft.tpSpeed != 0
					  where ft.idFile = {0} and ft.tpSpeed != 0
					  group by ft.tpTime
					  
					) hduration
					left join HeartRateZones hr on hduration.tpHeart > hr.zoneMin and hduration.tpHeart <= hr.zoneMax
					left join FileSummary fs on fs.idFile = hduration.idFile
					left join File f on f.idFile = hduration.idFile
					group by hr.idZone			
				", _file);
				
				
				SQLiteCommand cmd = new SQLiteCommand(_db);
				cmd.CommandText = sql;
				cmd.CommandTimeout = 10;
				SQLiteDataReader hr_rdr = cmd.ExecuteReader();
				ClearListView(lstHeartRateZones);
				if(hr_rdr.HasRows){
					while(hr_rdr.Read()){
						TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(hr_rdr["duration_seconds"]));
						string[] row = {
							(string)hr_rdr["zoneLabel"],
							string.Format("{0:D2} h {1:D2} m {2:D2} s", ts.Hours, ts.Minutes, ts.Seconds),
							string.Format("{0:0.00} %", Convert.ToDouble(hr_rdr["pct_total"]))
						};
						AddListViewItem(lstHeartRateZones, new ListViewItem(row));
					}
					ResizeListView(lstHeartRateZones);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
			
			SetControlPropertyThreadSafe(txtGradientDebug, "Text", gradient_debug);
			
		}
		
		void FileSummaryShown(object sender, EventArgs e)
		{
			_loading = new Thread(new ThreadStart(loadFileHistoryInformation));
			_loading.Start();
		}
		
		
		void BtnSaveFitClick(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				
				
				FileIdMesg fileIdMesg = new FileIdMesg();
				fileIdMesg.SetManufacturer(Manufacturer.Dynastream);
				fileIdMesg.SetProduct(1000);
				fileIdMesg.SetSerialNumber(12345);
				
				FileStream fitDest = new FileStream(saveFileDlg.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
				
				// create file encode object
				Encode encode = new Encode();
				// write out header
				encode.Open(fitDest);
				// encode each message, a definition message is automatically generated and output if necessary
				encode.Write(fileIdMesg);
				
				SQLiteCommand cmd = new SQLiteCommand(_db);
				string sql;
				// TODO: write FIT File Summary Information here, suspect that's why GarminConnect
				// is rejecting it because the summary data isn't there.
				sql = string.Format("select fs.*, f.fileActivityDateTime from FileSummary fs join File f on f.idFile = fs.idFile where fs.idFile = {0}", _file);
				cmd.CommandText = sql;
				SQLiteDataReader rdr_summary = cmd.ExecuteReader();
				if(rdr_summary.HasRows){
					rdr_summary.Read();
					SessionMesg sess = new SessionMesg();
					//"fsMaxHeartRate" INTEGER,"fsMaxCadence" INTEGER,"fsMaxSpeed" FLOAT, "fsAvgPower" FLOAT, "fsMaxPower" FLOAT)
					sess.SetTotalElapsedTime((float)Convert.ToDouble(rdr_summary["fsDuration"]));
					sess.SetTotalMovingTime((float)Convert.ToDouble(rdr_summary["fsMovingTime"]));
					sess.SetTotalTimerTime((float)Convert.ToDouble(rdr_summary["fsMovingTime"]));
					sess.SetTotalDistance((float)(Convert.ToDouble(rdr_summary["fsDistance"]) * 1609.344)); // convert miles back to metres
					sess.SetTotalCalories(Convert.ToUInt16(rdr_summary["fsCalories"]));
					sess.SetAvgHeartRate(Convert.ToByte(Convert.ToInt32(rdr_summary["fsAvgHeart"])));
					sess.SetAvgCadence(Convert.ToByte(Convert.ToInt32(rdr_summary["fsAvgCadence"])));
					sess.SetAvgSpeed((float)(Convert.ToDouble(rdr_summary["fsAvgSpeed"])/2.23693629));
					sess.SetTotalAscent(Convert.ToUInt16(Convert.ToDouble(rdr_summary["fsTotalAscent"])/3.2808399));
					sess.SetTotalDescent(Convert.ToUInt16(Convert.ToDouble(rdr_summary["fsTotalDescent"])/3.2808399));
					sess.SetMaxHeartRate(Convert.ToByte(Convert.ToInt32(rdr_summary["fsMaxHeartRate"])));
					sess.SetMaxCadence(Convert.ToByte(Convert.ToInt32(rdr_summary["fsMaxCadence"])));
					sess.SetMaxSpeed(Convert.ToByte(Convert.ToInt32(rdr_summary["fsMaxSpeed"])/2.23693629));
					
					Dynastream.Fit.DateTime dt_start = new Dynastream.Fit.DateTime(Convert.ToDateTime(rdr_summary["fileActivityDateTime"]));
					sess.SetStartTime(dt_start);
					encode.Write(sess);
				}
				rdr_summary.Close();
				
				// load and process the archived trackpoints for file
				
				sql = string.Format("select * from FileTrackpoints where idFile = {0}", _file);
				cmd.CommandText = sql;
				SQLiteDataReader rdr = cmd.ExecuteReader();
				if(rdr.HasRows){
					while(rdr.Read()){
						// TODO: need to handle `0` lng/lat coordinates so that we're not mapped
						// as being in the middle of the atlantic ! :-)
						RecordMesg rec = new RecordMesg();
						Dynastream.Fit.DateTime dt = new Dynastream.Fit.DateTime(System.DateTime.Parse((string)rdr["tpTime"]));
						rec.SetTimestamp(dt);
						rec.SetDistance((float)Convert.ToDouble(rdr["tpDistance"]));
						rec.SetHeartRate(Convert.ToByte(Convert.ToInt32(rdr["tpHeart"])));
						rec.SetCadence(Convert.ToByte(Convert.ToInt32(rdr["tpCadence"])));
						rec.SetTemperature(Convert.ToSByte(Convert.ToInt32(rdr["tpTemperature"])));
						rec.SetAltitude((float)(Convert.ToDouble(rdr["tpAltitude"]) / 3.2808399)); // converted back to metres from ft in db
						rec.SetPositionLong((int)GeoMath.degrees_to_semicircle(Convert.ToDouble(rdr["tpLongitude"])));
						rec.SetPositionLat((int)GeoMath.degrees_to_semicircle(Convert.ToDouble(rdr["tpLatitude"])));
						rec.SetSpeed((float)Convert.ToDouble(rdr["tpSpeed"]));
						encode.Write(rec);
					}
				}
				
				encode.Close();
				fitDest.Close();
				
				MessageBox.Show("File Saved Successfully");
				
				System.Diagnostics.Process.Start(saveFileDlg.FileName);
				
			}
			else{
				
			}
		}

		private void linkHistoryUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (e.Link == null)
				return;
			Process.Start(e.Link.LinkData as string);
		}
	}
}
