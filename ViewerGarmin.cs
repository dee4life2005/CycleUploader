/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 03/03/2013
 * Time: 22:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace CycleUploader
{
	/// <summary>
	/// Description of ViewerGarmin.
	/// </summary>
	public partial class ViewerGarmin : Form
	{
		private string _gc_user;
		private string _gc_password;
		private GarminConnectAPI _gc;
		private Thread threadLoading;
		
		public ViewerGarmin()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		
		void ViewerGarminLoad(object sender, EventArgs e)
		{
			// try to open registry key for application
			RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
			_gc_user = (string)key.GetValue("gc_user");
			_gc_password= (string)key.GetValue("gc_password");
		}
		
		public void initialisePbLoadingStatus(string label, int value, int max)
		{
			SetStatusProgressThreadSafe(statusBar, "Maximum", max);
			SetStatusProgressThreadSafe(statusBar, "Value",value);
			SetStatusTextThreadSafe(statusBar, label);
		}
		
		public void setPbLoadingStatus(int value, int max, string label)
		{
			SetStatusProgressThreadSafe(statusBar, "Maximum", max);
			SetStatusProgressThreadSafe(statusBar, "Value",value);
			SetStatusTextThreadSafe(statusBar, label);
		}
		
		void loadProfile()
		{
			SetStatusProgressThreadSafe(statusBar, "Maximum", 3);
			SetStatusProgressThreadSafe(statusBar, "Value",0);
			SetStatusTextThreadSafe(statusBar, "Logging in to GarminConnect...");
			
			// Log in to GarminConnect, display error if failed
			_gc = new GarminConnectAPI();
			if(!_gc.Login(_gc_user,_gc_password)){
				MessageBox.Show("GarminConnect login failed");
				this.Close();
			}
			
			SetStatusProgressThreadSafe(statusBar, "Value", 1);
			SetStatusTextThreadSafe(statusBar, "Loading User Metrics...");
			
			garminMetric[] metrics = _gc.GetMetrics();
			if(metrics != null){
				// load the metrics into the metrics list view
				for(int m=0;m<metrics.Length;m++){
					TimeSpan ts = TimeSpan.FromSeconds(Convert.ToDouble(metrics[m].totalDuration));
					string[] stat = {
						metrics[m].month,
						metrics[m].totalActivities,
						string.Format("{0:0.00} miles",(Convert.ToDouble(metrics[m].totalDistance)/1000) * 0.621371),
						string.Format("{0:D2} days {1:D2} h {2:D2} m {3:D2} s",Convert.ToInt32(Math.Floor(ts.TotalDays)), ts.Hours, ts.Minutes, ts.Seconds),
						string.Format("{0:0.00} mph",(((Convert.ToDouble(metrics[m].totalDistance)/1000)/(Convert.ToDouble(metrics[m].totalDuration)/3600)) * 0.621371)),
						string.Format("{0:0.00} ft",Convert.ToDouble(metrics[m].totalElevationGain)*3.2808399),
						string.Format("{0:0}",Convert.ToDouble(metrics[m].totalCalories))
					};
					
					AddListViewItem(lstUserMetrics, new ListViewItem(stat));
				}
			}
			ResizeListView(lstUserMetrics);
			
			SetStatusProgressThreadSafe(statusBar, "Value",2);
			SetStatusTextThreadSafe(statusBar, "Retrieving Activity Information...");
			
			List<GarminActivityListItem> activities = _gc.GetLastActivities(this);
			
			for(int a = 0; a < activities.Count; a++){
				string[] row = {
					activities[a].activityId.ToString(),
					activities[a].startTime,
					activities[a].activityName,
					activities[a].duration.ToString(),
					activities[a].distance, 
					activities[a].elevationGain,
					activities[a].speedAvg,
					activities[a].cadenceAvg,
					activities[a].heartRateAvg,
					activities[a].cadenceMax,
					activities[a].heartRateMax,
					activities[a].speedMax,
					activities[a].tempMin,
					activities[a].tempAvg,
					activities[a].durationElapsed,
					activities[a].uploadDate,
					activities[a].deviceName
				};
				AddListViewItem(lstActivities, new ListViewItem(row));
			}
			ResizeListView(lstActivities);
			
			SetStatusProgressThreadSafe(statusBar, "Maximum", 3);
			SetStatusProgressThreadSafe(statusBar, "Value", 3);
			SetStatusTextThreadSafe(statusBar, "Done.");
		}
				
		void ViewerGarminShown(object sender, EventArgs e)
		{
			threadLoading = new Thread(new ThreadStart(this.loadProfile));
			threadLoading.Start();
		}
		
		void LstActivitiesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstActivities.SelectedItems.Count > 0){
				string wId = lstActivities.SelectedItems[0].SubItems[0].Text;
				string wUrl = string.Format("http://connect.garmin.com/activity/{0}", wId);
				ProcessStartInfo sInfo = new ProcessStartInfo(wUrl);  
        		Process.Start(sInfo);				
			}
		}
		
		void ViewerGarminFormClosing(object sender, FormClosingEventArgs e)
		{
			try{
				// close the loading thread if it's alive
				if(threadLoading.IsAlive){
					threadLoading.Abort();
				}
			}
			catch{}
		}
	}
}
