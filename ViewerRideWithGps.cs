/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 11/03/2013
 * Time: 20:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace CycleUploader
{
	/// <summary>
	/// Description of ViewerRideWithGps.
	/// </summary>
	public partial class ViewerRideWithGps : Form
	{
		private RideWithGpsAPI _rwgps;
		private string _username;
		private string _password;
		
		private Thread _threadProfile;
		private Thread _threadActivity;
		
				
		public ViewerRideWithGps(string username, string password)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_username = username;
			_password = password;
			_rwgps = new RideWithGpsAPI();
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
	            //string varText = varControl.Text;
	            //return varText;
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
		
		public void initialisePbLoadingStatus(string label, int value, int max)
		{
			SetStatusProgressThreadSafe(statusBar, "Maximum", max);
			SetStatusProgressThreadSafe(statusBar, "Value", value);
			SetStatusTextThreadSafe(statusBar, label);
		}
		
		public void setPbLoadingStatus(int value, int max, string label)
		{
			
			SetStatusProgressThreadSafe(statusBar, "Maximum", max);
			SetStatusProgressThreadSafe(statusBar, "Value", value);
			SetStatusTextThreadSafe(statusBar, label);
		}
		
		void ViewerRideWithGpsShown(object sender, EventArgs e)
		{
			_threadProfile = new Thread(new ThreadStart(this.loadProfile));
			_threadProfile.Start();
		}
		
		void loadProfile()
		{
			List<RideWithGpsActivityListItem> activities;
			
			SetStatusProgressThreadSafe(statusBar, "Value", 0);
			SetStatusProgressThreadSafe(statusBar, "Maximum", 3);
			SetStatusTextThreadSafe(statusBar, "Authenticating with RideWithGPS...");
			
			// Log in to RideWithGPS, display error if failed
			if(!_rwgps.login(_username, _password)){
				MessageBox.Show("RideWithGPS: Login Failed");
				this.Close();
			}
			
			SetControlPropertyThreadSafe(lblProfileName, "Text", _rwgps._profile.display_name);
			SetControlPropertyThreadSafe(lblProfileCity, "Text", _rwgps._profile.profile_area);
			SetControlPropertyThreadSafe(lblMemberSince, "Text", _rwgps._profile.member_since);
			SetControlPropertyThreadSafe(lblDOB, "Text", _rwgps._profile.dob);
			SetControlPropertyThreadSafe(lblTotalElevation, "Text", string.Format("{0:0.00} ft", (_rwgps._profile.total_trip_elevation*3.2808399)));

			TimeSpan totDur = TimeSpan.FromSeconds(_rwgps._profile.total_trip_duration);
			SetControlPropertyThreadSafe(lblTotalDuration, "Text", string.Format("{0:D2} d {1:D2} h {2:D2} m {3:D2} s", Convert.ToInt32(Math.Floor(totDur.TotalDays)), totDur.Hours, totDur.Minutes, totDur.Seconds));
			SetControlPropertyThreadSafe(lblTotalDistance, "Text", string.Format("{0:0.00} miles",(_rwgps._profile.total_trip_distance*0.000621371192)));
			SetControlPropertyThreadSafe(lblTotalActivities, "Text", string.Format("{0:0}", _rwgps._profile.total_trip_count));
			
			SetControlPropertyThreadSafe(pbProfilePhoto, "ImageLocation", _rwgps._profile.profile_photo_url);
			
			
			activities = _rwgps.GetActivities(this);		
			
			
			SetStatusTextThreadSafe(statusBar, "Processing activities, and adding to profile page...");
			for(int a = 0; a < activities.Count; a++){
				TimeSpan ts = TimeSpan.FromSeconds(activities[a].moving_time);
				
				string[] row = {
					activities[a].id.ToString(),
					activities[a].departed_at,
					activities[a].name,
					activities[a].location_string,
					string.Format("{0:0.00} miles",(activities[a].distance/1000) * 0.621371192),
					string.Format("{0:D2} h {1:D2} m {2:D2} s", ts.Hours, ts.Minutes, ts.Seconds),						
					string.Format("{0:0.00} mph",activities[a].avg_speed * 0.621371192),
					string.Format("{0:0.00} ft", activities[a].elevation_gain * 3.2808399),
					//activities[a].avg_power.ToString(),
					activities[a].created_at					
				};
				AddListViewItem(lstActivities, new ListViewItem(row));
				SetControlPropertyThreadSafe(lblTotalActivities, "Text", string.Format("{0}", lstActivities.Items.Count));
			}
			SetStatusTextThreadSafe(statusBar, "Done.");
			
			ResizeListView(lstActivities);
		}
		
		void LstActivitiesSelectedIndexChanged(object sender, EventArgs e)
		{
			// abort loading current activity if a new one has been selected
			try{
				if(_threadActivity.IsAlive){
					_threadActivity.Abort();
				}
			}
			catch{}
			
			
			if(lstActivities.SelectedItems.Count > 0){
				
				_threadActivity = new Thread(new ThreadStart(this.loadActivity));
				_threadActivity.Start();
				
				//lstActivities.Enabled = false;
				
			}
		}
		
		void loadActivity()
		{
			zedActivityChart.GraphPane.Legend.IsVisible = true;
			zedActivityChart.GraphPane.Title.Text = "Activity Chart";
			zedActivityChart.GraphPane.XAxis.Title.Text = "Duration from Activity Start";
			zedActivityChart.GraphPane.YAxis.Title.Text = "";			
			
			SetStatusProgressThreadSafe(statusBar, "Value", 0);
			SetStatusProgressThreadSafe(statusBar, "Maximum", 6);
			SetStatusTextThreadSafe(statusBar, "Loading selected activity...");
			
			if(listViewSelectedCountItems(lstActivities) > 0){
				int wId = Convert.ToInt32(GetListViewSelectedItemValue(lstActivities, 0, 0));
				RideWithGpsActivitySummary summary = _rwgps.retrieveWorkoutData(wId, ref zedActivityChart);
				
				// apply the ride summary information
				SetControlPropertyThreadSafe(lblAvgSpeed, "Text", summary.avgSpeed);
				SetControlPropertyThreadSafe(lblAvgCadence, "Text", summary.avgCadence);
				SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", summary.avgHeartRate);
				SetControlPropertyThreadSafe(lblActivityDateTime, "Text", summary.name);
				SetControlPropertyThreadSafe(lblTotalAscent, "Text", summary.elevationGain);
				SetControlPropertyThreadSafe(lblDuration, "Text", summary.durationTotal);
				SetControlPropertyThreadSafe(lblMovingTime, "Text", summary.durationMoving);
				SetControlPropertyThreadSafe(lblDistance, "Text", summary.distance);
				SetControlPropertyThreadSafe(txtNotes, "Text", summary.notes);

				ClearListView(lstSplits);
				for(int s = 0; s < summary.mileSplits.Count; s++){
					string[] row = {
						summary.mileSplits[s].label, 
						summary.mileSplits[s].speed,
						summary.mileSplits[s].pace
					};
					AddListViewItem(lstSplits, new ListViewItem(row));
				}
				
				// finalise
				SetControlPropertyThreadSafe(lstActivities, "Enabled", true);
				
				// set active tab, and tell the MAP browser component to reload the route map
				setTab(tabChart, "tabSummary");
				NavigateWebControl(webBrowser1, Application.StartupPath + "\\rwgps_route.html");
			}
			SetStatusTextThreadSafe(statusBar, "Done.");
		}
		
		void CbkChartSpeedCheckedChanged(object sender, EventArgs e)
		{
			zedActivityChart.GraphPane.CurveList[2].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.GraphPane.YAxisList[2].IsVisible = ((CheckBox)sender).Checked;
			zedActivityChart.AxisChange();
			zedActivityChart.Refresh();
		}
		
		void CbkChartCadenceCheckedChanged(object sender, EventArgs e)
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
			
			fsMap = new FullscreenMap(Application.StartupPath + "\\rwgps_route.html");
			fsMap.ShowDialog();
		}
		
		void ViewerRideWithGpsFormClosing(object sender, FormClosingEventArgs e)
		{
			try{
				if(_threadProfile.IsAlive){
					_threadProfile.Abort();
				}
				if(_threadActivity.IsAlive){
					_threadActivity.Abort();
				}
			}catch{}
		}
		
		void LstActivitiesDoubleClick(object sender, EventArgs e)
		{
			LstActivitiesSelectedIndexChanged(sender, e);
			
		}
	}
}
