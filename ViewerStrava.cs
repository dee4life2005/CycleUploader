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
		
		void getActivities()
		{
			string url = "https://www.strava.com/api/v3/athlete/activities?";
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
					SuspendLayout();
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
							(bool)json[act].flagged ? "Y" : ""
						};
						AddListViewItem(frmActivities, new ListViewItem(activity));
					}
					ResumeLayout();
					ResizeListView(frmActivities);
						
					
				}
			}
		}
		
		void ViewerStravaLoad(object sender, EventArgs e)
		{
			_threadProfile = new Thread(new ThreadStart(this.loadProfile));
			_threadProfile.Start();
		}
	}
}
