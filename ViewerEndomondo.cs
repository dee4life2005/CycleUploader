/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 12:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace TCX_Parser
{
	/// <summary>
	/// Description of ViewerEndomondo.
	/// </summary>
	public partial class ViewerEndomondo : Form
	{
		private string _authToken;
		private string _secureToken;
		private string _displayName;
		private string _userId;
		private Thread _threadProfile;
		
		public ViewerEndomondo(string authToken, string secureToken, string displayName, string userId)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_authToken = authToken;
			_secureToken = secureToken;
			_displayName = displayName;
			_userId = userId;
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
		
		void ViewerEndomondoShown(object sender, EventArgs e)
		{
			_threadProfile = new Thread(new ThreadStart(loadProfile));
			_threadProfile.Start();
		}
		
		void loadProfile()
		{
			string url = string.Format("http://www.endomondo.com/embed/user/summary?id={0}&sport=2&measure=1&zone=Gm0000_GMT&width=480&height=217",_userId);
			NavigateWebControl(wbSummaryWidget, url);
			
			loadActivities();
		}
		
		void loadActivities()
		{
			List<endomondoActivity> activities = new List<endomondoActivity>();
			//string url_page_suffix = "&before="; //"&before=2013-04-01 00:00:00";
			
			string url = string.Format("http://api.mobile.endomondo.com/mobile/api/workout/list?authToken={0}&maxResults=20",_authToken);
			
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			//httpWebRequest.CookieContainer = cookies;
			httpWebRequest.Method = "GET";
			string last_date = "";
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string json = streamReader.ReadToEnd();
					
					endomondoActivityItems eOut = new JavaScriptSerializer().Deserialize<endomondoActivityItems>(json);
					for(int a= 0 ; a<eOut.data.Length; a++){
						activities.Add(eOut.data[a]);
						last_date = eOut.data[a].start_time;
					}
					
					SetControlPropertyThreadSafe(lblTotalActivities, "Text", string.Format("{0} Activities", activities.Count));
					// try and load more activities
					List<endomondoActivity> moreActivities;
					do{
						moreActivities = loadMoreActivities(ref last_date);
						activities.AddRange(moreActivities);
						SetControlPropertyThreadSafe(lblTotalActivities, "Text", string.Format("{0} Activities", activities.Count));
					}while(moreActivities.Count > 0);
					
					SetControlPropertyThreadSafe(lblTotalActivities, "Text", string.Format("{0} Activities", activities.Count));
				}
			}
			
			if(activities.Count > 0){
				// add the activities to the activities list view
				for(int a = 0; a < activities.Count; a++){
					TimeSpan ts = TimeSpan.FromSeconds(activities[a].duration_sec);
					string[] row = {
						activities[a].id.ToString(),
						activities[a].start_time,
						activities[a].name,
						string.Format("{0:0.00} miles",activities[a].distance_km * 0.621371192), // distance in miles
						string.Format("{0:D2} h {1:D2} m {2:D2} s", ts.Hours, ts.Minutes, ts.Seconds),
						string.Format("{0:0.00} mph",activities[a].speed_kmh_avg * 0.621371192), // speed in mph
						activities[a].heart_rate_bpm_avg.ToString(),
						activities[a].cadence_avg_rpm.ToString(),
						activities[a].calories.ToString(),
						string.Format("{0:0.00} mph",activities[a].speed_kmh_max * 0.621371192), // speed in mph
						activities[a].heart_rate_bpm_max.ToString(),
						string.Format("{0:0.00} ft",activities[a].altitude_m_max * 3.2808399), // alt. in feet
						string.Format("{0:0.00} ft",activities[a].altitude_m_min * 3.2808399) // alt. in feet
					};
					AddListViewItem(lstActivities, new ListViewItem(row));
				}
				ResizeListView(lstActivities);
			}
		}
		
		List<endomondoActivity> loadMoreActivities(ref string last_search_date)
		{
			string url = string.Format("http://api.mobile.endomondo.com/mobile/api/workout/list?authToken={0}&maxResults=20&before={1}",_authToken, last_search_date);
			//string url_track = string.Format("http://api.mobile.endomondo.com/mobile/readTrack?authToken={0}&trackId={1}",_authToken, wId);
			
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			//httpWebRequest.CookieContainer = cookies;
			httpWebRequest.Method = "GET";
			List<endomondoActivity> activities = new List<endomondoActivity>();
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string json = streamReader.ReadToEnd();
					
					endomondoActivityItems eOut = new JavaScriptSerializer().Deserialize<endomondoActivityItems>(json);
					for(int a =0; a<eOut.data.Length; a++){
						activities.Add(eOut.data[a]);
						last_search_date = eOut.data[a].start_time;
					}
				}
			}
			return activities;
		}
		
		
		void LstActivitiesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstActivities.SelectedItems.Count > 0){
				string wId = lstActivities.SelectedItems[0].SubItems[0].Text;
				string wUrl = string.Format("http://www.endomondo.com/workouts/{0}/{1}", wId, _userId);
				ProcessStartInfo sInfo = new ProcessStartInfo(wUrl);  
        		Process.Start(sInfo);	
			}
			
		}
		
		void ViewerEndomondoFormClosing(object sender, FormClosingEventArgs e)
		{
			try{
				if(_threadProfile.IsAlive){
					_threadProfile.Abort();
				}
			}
			catch{}
		}
	}
}
