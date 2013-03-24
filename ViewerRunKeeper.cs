/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/02/2013
 * Time: 14:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HealthGraphNet;
using HealthGraphNet.Models;
using ZedGraph;
using System.Threading;
using System.Reflection;

namespace CycleUploader
{
	/// <summary>
	/// Description of ViewerRunKeeper.
	/// </summary>
	public partial class ViewerRunKeeper : Form
	{
		AccessTokenManager _tm;
		public string _client_id;
		public string _client_secret;
		public string _uri;
		public string _token;
		public UsersEndpoint _userRequest;
		public UsersModel _user;
		
		private Thread _threadProfile;
		private Thread _threadActivity;
		
		public ViewerRunKeeper(string client_id, string client_secret, string uri, string token)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_token = token;
			_client_id = client_id;
			_client_secret = client_secret;
			_uri = uri;
		}
		
		private delegate void SetStatusTextThreadSafeDelegate(ToolStrip control,string text );
		public void SetStatusTextThreadSafe(ToolStrip control, string text)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetStatusTextThreadSafeDelegate(SetStatusTextThreadSafe), new object[] { control, text});
		  	}
			else{
				
				statusBarStatus.Text = text;
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
						statusBarProgress.Value = value;
						break;
					case "Maximum":
						statusBarProgress.Maximum = value;
						break;
					case "Visible":
						statusBarProgress.Visible = Convert.ToBoolean(value);
						break;
				}
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
		
		private delegate void AppendControlTextThreadSafeDelegate(Control ctrl, string appendText, FontStyle style);
		public static void AppendControlTextThreadSafe(Control ctrl, string appendText, FontStyle style)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new AppendControlTextThreadSafeDelegate(AppendControlTextThreadSafe), new object[] { ctrl, appendText, style});
			}
			else{
				int startIdx = ctrl.Text.Length;
				((RichTextBox)ctrl).AppendText(appendText);
				((RichTextBox)ctrl).SelectionStart = startIdx;
				((RichTextBox)ctrl).SelectionLength = appendText.Length;
				((RichTextBox)ctrl).SelectionFont = new Font(ctrl.Font.FontFamily, ctrl.Font.Size, style);
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
		
		private static int listViewCountItems(ListView varControl)
		{
	        if (varControl.InvokeRequired) {
	            return (int) varControl.Invoke(new Func<int>(() => listViewCountItems(varControl)));
	        } else {
	            return varControl.Items.Count;
	        }
    	}
		
		private static int listViewSelectedCountItems(ListView varControl)
		{
	        if (varControl.InvokeRequired) {
	            return (int) varControl.Invoke(new Func<int>(() => listViewSelectedCountItems(varControl)));
	        } else {
	            return varControl.SelectedItems.Count;
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
		
		
		
		void ViewerRunKeeperLoad(object sender, EventArgs e)
		{
			_threadProfile = new Thread(new ThreadStart(this.loadProfile));
			_threadProfile.Start();
		}
		
		void loadProfile()
		{
			int progressValue = 0;
			try{
				
				// initialise the loading progress bar
				SetStatusProgressThreadSafe(statusBar, "Step", 1);
				SetStatusProgressThreadSafe(statusBar, "Maximum", 4);
				SetStatusProgressThreadSafe(statusBar, "Value", progressValue);
				
				_tm = new AccessTokenManager(_client_id, _client_secret, "https://www.facebook.com/connect/login_success.html", _token);
				
				
				//Retrieve URIs for HealthGraph endpoints.
				SetStatusTextThreadSafe(statusBar, "Loading available HealthPoint endpoints...");
				
				_userRequest = new UsersEndpoint(_tm);
				_user = _userRequest.GetUser();
				
				SetStatusProgressThreadSafe(statusBar, "Value", ++progressValue);
				
				// Load the Profile information
				
				SetStatusTextThreadSafe(statusBar, "Loading user profile information...");
				ProfileEndpoint profile = new ProfileEndpoint(_tm,_user);
				ProfileModel userProfile = profile.GetProfile();
				
				SetControlPropertyThreadSafe(pbProfileMedium, "ImageLocation", userProfile.SmallPicture);
				
				SetControlPropertyThreadSafe(lblProfileName, "Text", userProfile.Name);
				SetControlPropertyThreadSafe(lblGender, "Text", userProfile.Gender);
				SetControlPropertyThreadSafe(lblAthleteType, "Text", userProfile.AthleteType);
				SetControlPropertyThreadSafe(lblDob, "Text", ((DateTime)userProfile.Birthday).ToString("dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture));
				SetControlPropertyThreadSafe(lblProfile, "Text", userProfile.Profile);
				
				//lblProfile.Links.Add(0,0,userProfile.Profile);	
				SetControlPropertyThreadSafe(lblLocation, "Text", userProfile.Location);
							
				if(userProfile.Elite){
					SetControlPropertyThreadSafe(pbElite, "Visible", true);
				}
				else{
					SetControlPropertyThreadSafe(pbElite, "Visible", false);
				}
				SetStatusProgressThreadSafe(statusBar, "Value", ++progressValue);
				
				// Load the Street Team information
				SetStatusTextThreadSafe(statusBar, "Loading StreetTeam information...");
				
				StreetTeamEndpoint team = new StreetTeamEndpoint(_tm, _user);
				FeedModel<StreetTeamFeedItemModel> streetteam=  team.GetFeedPage(0,25);
				
				for(int st = 0; st < streetteam.Items.Count; st++){
					string [] sti = {
						streetteam.Items[st].Name,
						streetteam.Items[st].Profile,
						streetteam.Items[st].Uri
					};
					AddListViewItem(lstStreetTeam, new ListViewItem(sti));
				}
				
				SetStatusProgressThreadSafe(statusBar, "Value", ++progressValue);
				
				// Load the Records information
				SetStatusTextThreadSafe(statusBar, "Loading user Records information...");
				
				RecordsEndpoint records = new RecordsEndpoint(_tm, _user);
				
				List<RecordsFeedItemModel> userRecords = records.GetRecordsFeed();
					
				for(int r = 0; r < userRecords.Count; r++){
					if(userRecords[r].ActivityType == "Cycling"){
						for(int s = 0; s < userRecords[r].Stats.Count; s++){
							string recdistance = userRecords[r].Stats[s].Value.ToString();
						
							if(userRecords[r].Stats[s].StatType == "OVERALL"){
								recdistance = ((Convert.ToDouble(recdistance)/1000) * 0.621371192).ToString(); // convert to miles
							}
							
							string [] rec ={
								userRecords[r].Stats[s].StatType,
								((DateTime)userRecords[r].Stats[s].Date).ToString("dd/MM/yyyy"),
								string.Format("{0:0.00}",Convert.ToDouble(recdistance))
							};
							AddListViewItem(lstRecords, new ListViewItem(rec));
						}
					}
				}
				SetStatusProgressThreadSafe(statusBar, "Value", ++progressValue);
				
				// Load the activities information
				SetStatusTextThreadSafe(statusBar, "Loading activities...");
				
				FitnessActivitiesEndpoint activities = new FitnessActivitiesEndpoint(_tm, _user);
				int userActivitiesPage = 0;
				int userActivitiesPerPage = 25;
				FeedModel<FitnessActivitiesFeedItemModel> userActivities = activities.GetFeedPage(userActivitiesPage,userActivitiesPerPage);
				SetControlPropertyThreadSafe(lblTotalActivities, "Text", userActivities.Size.ToString() + " Activities");
				
				int userActivitiesCount = userActivities.Size;
				int loadingCount = 0;
				SetStatusProgressThreadSafe(statusBar, "Maximum",	userActivities.Size);
				SetStatusProgressThreadSafe(statusBar, "Value", loadingCount);
				
				for(userActivitiesPage = 0; userActivitiesPage <= Convert.ToInt32(Math.Ceiling(Convert.ToDouble(userActivitiesCount/userActivitiesPerPage))); userActivitiesPage++){

					// if not first page, load the next page
					if(userActivitiesPage > 0){
						userActivities = activities.GetFeedPage(userActivitiesPage,userActivitiesPerPage);
					}
					for(int a = 0; a < userActivities.Items.Count; a++){
						SetStatusProgressThreadSafe(statusBar, "Value", ++loadingCount);
						TimeSpan duration = TimeSpan.FromSeconds(userActivities.Items[a].Duration);
						string duration_f =  string.Format("{0:D2} h {1:D2} m {2:D2} s", 
							    			duration.Hours, 
							    			duration.Minutes, 
							    			duration.Seconds
							    		);
						string [] arec = {
							userActivities.Items[a].Type,
							userActivities.Items[a].StartTime.ToString("dd/MM/yyyy HH:mm:ss"),
							duration_f,
							string.Format("{0:0.00 miles}",(userActivities.Items[a].TotalDistance/1000)*0.621371192),
							string.Format("{0:0.00} mph",((userActivities.Items[a].TotalDistance/1000)*0.621371192) / (userActivities.Items[a].Duration / 3600)),
							userActivities.Items[a].Uri
						};
						AddListViewItem(lstActivities, new ListViewItem(arec));
					}
				}
				ResizeListView(lstActivities);
				SetStatusTextThreadSafe(statusBar, "Done.");
			}
			catch(HealthGraphException he)
			{
				MessageBox.Show(he.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally{
				SetControlPropertyThreadSafe(lstActivities, "Enabled", true);
			}
		}
		
		void LblProfileLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());			
		}
		
		void LstActivitiesClick(object sender, EventArgs e)
		{
			// check if there is an activity load thread already running,
			// if there is abort it and load based on the new click event
			try{
				if(_threadActivity.IsAlive){
					_threadActivity.Abort();
				}
			}catch{}
			
			_threadActivity = new Thread(new ThreadStart(this.loadActivity));
			_threadActivity.Start();
		}
		void loadActivity()
		{
			int progress = 0;

			zedActivityChart.GraphPane.Legend.IsVisible = true;
			zedActivityChart.GraphPane.Title.Text = "Activity Chart";
			zedActivityChart.GraphPane.XAxis.Title.Text = "Duration from Activity Start";
			zedActivityChart.GraphPane.YAxis.Title.Text = "";			
			
			SetStatusProgressThreadSafe(statusBar, "Maximum",6);
			SetStatusProgressThreadSafe(statusBar, "Value", progress);
			SetStatusTextThreadSafe(statusBar, "Loading selected activity...");
			
			// load activity
			SetStatusTextThreadSafe(statusBar, "Downloading Activity Information from Runkeeper...");

			FitnessActivitiesEndpoint activities = new FitnessActivitiesEndpoint(_tm,_user);
			FitnessActivitiesPastModel activity = activities.GetActivity(GetListViewSelectedItemValue(lstActivities,0,5));
			
			SetControlPropertyThreadSafe(lblActivityDateTime, "Text", activity.StartTime.ToString("dd/MM/yyyy HH:mm:ss"));
			SetControlPropertyThreadSafe(lblCalories, "Text", activity.TotalCalories.ToString());
			SetControlPropertyThreadSafe(lblDistance, "Text", string.Format("{0:0.00} miles", (activity.TotalDistance / 1000) * 0.621371192));
			SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", activity.AverageHeartRate.ToString());
			SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph",((activity.TotalDistance / 1000) * 0.621371192) / (activity.Duration / 3600)));
			SetControlPropertyThreadSafe(lblActivityEquipment, "Text", string.Format("{0:0.00} ft",activity.Climb * 3.2808399));
			TimeSpan duration = TimeSpan.FromSeconds(activity.Duration);
			SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			duration.Hours, 
					    			duration.Minutes, 
					    			duration.Seconds
					    		));
			SetControlPropertyThreadSafe(lblActivityType, "Text", activity.Type);
			SetControlPropertyThreadSafe(lblActivityEquipment, "Text", activity.Equipment);
			SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} ft", activity.Climb * 3.2808399));
			SetControlPropertyThreadSafe(lblLastModified, "Text", activity.Source);
			SetControlPropertyThreadSafe(txtNotes, "Text", activity.Notes);
			
			setTab(tabControl1, "tabSummary");
			SetControlPropertyThreadSafe(tabMap, "Enabled", true);
			
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			SetStatusTextThreadSafe(statusBar, "Loading activity comments...");
			
			// retrieve the comments
			SetControlPropertyThreadSafe(richActivityComments, "Text", "");
			CommentThreadsEndpoint comments = new CommentThreadsEndpoint(_tm);
			CommentThreadsModel comment_thread = comments.GetCommentThread(activity.Comments);
			
			AppendControlTextThreadSafe(richActivityComments, "", FontStyle.Regular);
			for(int c = 0; c < comment_thread.Comments.Count; c++){
				AppendControlTextThreadSafe(richActivityComments, comment_thread.Comments[c].Timestamp.ToString("dd/MM/yyyy HH:mm") + " by " + comment_thread.Comments[c].Name, FontStyle.Bold);
				AppendControlTextThreadSafe(richActivityComments, "\r\n", FontStyle.Regular);
				AppendControlTextThreadSafe(richActivityComments, comment_thread.Comments[c].Comment + "\r\n", FontStyle.Regular);
			}
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			
						
			// generate the heart rate graph
			SetStatusTextThreadSafe(statusBar, "Generating Heart Rate Graph Data...");
			
			PointPairList graphListHeart = new PointPairList();
			PointPairList graphListAltitude = new PointPairList();
			PointPairList graphListSpeed = new PointPairList();
			zedActivityChart.GraphPane.CurveList.Clear();
			zedActivityChart.GraphPane.GraphObjList.Clear();
			zedActivityChart.GraphPane.YAxisList.Clear();
			
			zedActivityChart.GraphPane.AddYAxis("Heart (bpm)");
			zedActivityChart.GraphPane.AddYAxis("Speed (mph)");
			zedActivityChart.GraphPane.AddYAxis("Altitude (ft)");
			
			// set custom formatting for X-Axis in charts
			zedActivityChart.GraphPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(Axis_ScaleFormatEvent);
			
			for(int h = 0; h < activity.HeartRate.Count; h++){
				TimeSpan ts = TimeSpan.FromSeconds(activity.HeartRate[h].Timestamp);
				string tag = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\nHR: " + activity.HeartRate[h].HeartRate.ToString() + " bpm";
				
				graphListHeart.Add(
					activity.HeartRate[h].Timestamp,
					activity.HeartRate[h].HeartRate,
					tag
				);				
			}
			LineItem ln_heart_heart = zedActivityChart.GraphPane.AddCurve("Heart Rate",graphListHeart,Color.Red, SymbolType.None);
			ln_heart_heart.Line.Width = 1;
			ln_heart_heart.YAxisIndex = 0;
			
			if(activity.HeartRate.Count != 0){
				zedActivityChart.GraphPane.XAxis.Scale.Max = activity.HeartRate[activity.HeartRate.Count-1].Timestamp;
			}
			

			zedActivityChart.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedActivityChart.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedActivityChart.AxisChange();
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			
			
			// build the list of mile splits
			SetStatusTextThreadSafe(statusBar, "Calculating Mile Split information...");
			
			ClearListView(lstSplits);
			
			int mile_split_count = 1;
			double mile_previous_timestamp = 0;
			double mile_current_timestamp = 0;
			
			List<double> mile_marker_timestamps = new List<double>();
			
			for(int d = 0; d < activity.Distance.Count; d++){
				
				if(activity.Distance[d].Distance >= (1609.344 * mile_split_count)){
					if(mile_split_count == 1){
						mile_previous_timestamp = activity.Distance[0].Timestamp;
					}
					mile_current_timestamp = activity.Distance[d].Timestamp;
					TimeSpan ts_current_mile = TimeSpan.FromSeconds(mile_current_timestamp-mile_previous_timestamp);
					string[] mile_split_info = {
						"Mile " + mile_split_count.ToString(),
						string.Format("{0:0.00} mph",3600 / (mile_current_timestamp - mile_previous_timestamp)),
						string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts_current_mile.Hours, 
					    			ts_current_mile.Minutes, 
					    			ts_current_mile.Seconds
					    		)
					};
					AddListViewItem(lstSplits, new ListViewItem(mile_split_info));
					mile_marker_timestamps.Add(activity.Distance[d].Timestamp);
					mile_previous_timestamp = activity.Distance[d].Timestamp;
					mile_split_count++;	
				}
			}
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			
			// generate the speed graph
			SetStatusTextThreadSafe(statusBar, "Generating Speed Graph Data...");
			double dist;
			double time;
			double speed_mph;
			int mile_count = 1;
			List<Double> mile_markers= new List<Double>();
			for(int s = 0; s < activity.Distance.Count; s++){
				if(s == 0){ 
					dist = activity.Distance[0].Distance;
					time = activity.Distance[0].Timestamp;
				}
				else{
					dist = activity.Distance[s].Distance - activity.Distance[s-1].Distance;
					time = activity.Distance[s].Timestamp - activity.Distance[s-1].Timestamp;
				}
				speed_mph = (dist / time) * 2.23693629;
				if(activity.Distance[s].Distance > (1609.344 * mile_count)){
					mile_markers.Add(activity.Distance[s].Timestamp);
					mile_count++;
				}
				
				TimeSpan ts = TimeSpan.FromSeconds(activity.Distance[s].Timestamp);
				string tag = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\n" + string.Format("Speed: {0:0.00} mph",speed_mph);
				
				graphListSpeed.Add(activity.Distance[s].Timestamp, speed_mph, tag);
				
			}
			LineItem ln_speed = zedActivityChart.GraphPane.AddCurve("Speed",graphListSpeed,Color.Blue, SymbolType.None);
			ln_speed.Line.Width = 1;
			ln_speed.YAxisIndex = 1;
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			
			// generate the altitude graph
			SetStatusTextThreadSafe(statusBar, "Generating Altitude Graph Data...");
			for(int a = 0; a < activity.Path.Count; a++){
				TimeSpan ts = TimeSpan.FromSeconds(activity.Path[a].Timestamp);
				string tag = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\n" + string.Format("Altitude: {0:0.00} ft",activity.Path[a].Altitude * 3.2808399);
				
				graphListAltitude.Add(
					activity.Path[a].Timestamp,
					activity.Path[a].Altitude * 3.2808399,
					tag
				);
			}
			
			LineItem ln_altitude  = zedActivityChart.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
			ln_altitude.Line.Fill = new Fill(Color.LightGreen);
			ln_altitude.YAxisIndex  =2;

			zedActivityChart.AxisChange();
			
			setTab(tabControl1, "tabSummary");
			
			double start_lat = 0;
			double start_lng = 0;
			double finish_lat=0;
			double finish_lng=0;
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
			
			mile_count = 0;
			int current_mile_marker_search = 0;
			for(int t = 0; t < activity.Path.Count; t++){
				if(t==0){
					start_lat = activity.Path[t].Latitude;
					start_lng = activity.Path[t].Longitude;
				}
				// update the last point coordinates
				finish_lat = lat = activity.Path[t].Latitude;
				finish_lng = lng = activity.Path[t].Longitude;
				
				
				// update the max / min longitude / latitude
				if(lat_min == -1){ lat_min = lat;}
				if(lat_max == -1){ lat_max = lat;}
				if(lng_min == -1){ lng_min = lng;}
				if(lng_max == -1){ lng_max = lng;}
				
				if(lat < lat_min){ lat_min = lat;}
				if(lat > lat_max){ lat_max = lat;}
				if(lng < lng_min){ lng_min = lng;}
				if(lng > lng_max){ lng_max = lng;}
				
				// add GoogleMap polyline point.
				if(t > 0){
					js_coords += ",";
				}
				js_coords += "\r\nnew google.maps.LatLng(" + activity.Path[t].Latitude.ToString() + "," + activity.Path[t].Longitude.ToString() + ")";
				if(current_mile_marker_search < mile_marker_timestamps.Count && activity.Path[t].Timestamp == mile_marker_timestamps[current_mile_marker_search]){
					TimeSpan tmp_ts = TimeSpan.FromSeconds(mile_marker_timestamps[current_mile_marker_search]);
					string mile_marker_tag = "Time since start of ride: " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tmp_ts.Hours, 
					    			tmp_ts.Minutes, 
					    			tmp_ts.Seconds
					    		);
					js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + (current_mile_marker_search+1) + "|95E978|004400',position: new google.maps.LatLng(" + activity.Path[t].Latitude.ToString() + "," + activity.Path[t].Longitude.ToString() + "),map: map,title: 'Mile " + (current_mile_marker_search+1) + "\\r\\n" + mile_marker_tag + "'});";
					current_mile_marker_search++;
				}
				
				
			}
			
			// add markers to signify the START / END of route
			js_mile_markers = 	"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});" + 
								js_mile_markers;
			
			js_centre = "new google.maps.LatLng(" + ((lat_min+lat_max)/2) + "," + ((lng_min+lng_max)/2) + ")";
			
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
				        var myLatLng = " + js_centre + @"
				        var mapOptions = {
				          zoom: " + zoom + @",
				          center: myLatLng,
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
				       map.panTo(" + js_centre + @");
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
				if(System.IO.File.Exists(Application.StartupPath + "\\rk_route.html"))
				{
				   	System.IO.File.Delete(Application.StartupPath + "\\rk_route.html");
				}
				FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\rk_route.html");
	            StreamWriter writer = new StreamWriter(fs);  
	            writer.Write(routeHTML);  
	            writer.Close();
	            writer.Dispose();
	            fs.Dispose();
				
	            NavigateWebControl(webBrowser1, Application.StartupPath + "\\rk_route.html");
	            SetControlPropertyThreadSafe(tabMap, "Enabled", true);
			}
			catch{
				MessageBox.Show("Map Update Failed. Try re-selecting the activity.","Error loading map", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			finally{
				SetControlPropertyThreadSafe(tabMap, "Enabled", true);
			}
			SetStatusProgressThreadSafe(statusBar, "Value", ++progress);
			
			SetStatusTextThreadSafe(statusBar, "Done.");
			
		}
		
		
		void LnkRunkeperLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = lblProfile.Text + lstActivities.SelectedItems[0].SubItems[5].Text.Replace("fitnessActivities","activity");
			System.Diagnostics.Process.Start(url);
		}
		
		static string Axis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index)
		{
		    TimeSpan timeVal = TimeSpan.FromSeconds(val); 
		    return string.Format("{0:D2} h {1:D2} m {2:D2} s", timeVal.Hours, timeVal.Minutes, timeVal.Seconds);
		}
		
		void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			lstActivities.Enabled = true;
		}
		
		void CbkChartSpeedCheckedChanged(object sender, EventArgs e)
		{
			zedActivityChart.GraphPane.CurveList[1].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.GraphPane.YAxisList[1].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.AxisChange();
			zedActivityChart.Refresh();
		}
		
		void CbkChartHeartCheckedChanged(object sender, EventArgs e)
		{
			zedActivityChart.GraphPane.CurveList[0].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.GraphPane.YAxisList[0].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.AxisChange();
			zedActivityChart.Refresh();
		}
		
		void BtnMapFullscreenClick(object sender, EventArgs e)
		{
			FullscreenMap fsMap;
			
			fsMap = new FullscreenMap(Application.StartupPath + "\\rk_route.html");
			fsMap.ShowDialog();
		}
	}
}
