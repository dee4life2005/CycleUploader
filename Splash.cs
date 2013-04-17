/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 16/04/2013
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace CycleUploader
{
	/// <summary>
	/// Description of Splash.
	/// </summary>
	public partial class Splash : Form
	{
		private string _versionStr;
		private string _versionDate;
		private string _versionAuthor;
		private SQLiteConnection _m_dbConnection;
		
		public List<ListViewItem> _lstItems = new List<ListViewItem>();
		public List<ListViewGroup> _lstGroups = new List<ListViewGroup>();
		
		// -- garmin connect
		public string _gc_user;
		public string _gc_password;
		public bool _gc_login = false;
		public GarminConnectAPI _gc;
		// -- ride with gps
		public RideWithGpsAPI _rwgps;
		public string _ridewithgps_email;
		public string _ridewithgps_password;
		public string _ridewithgps_token;
		// -- threads
		private Thread _thInit;
		
		
		public Splash(string versionStr, string versionDate, string versionAuthor)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_versionStr = versionStr;
			_versionDate = versionDate;
			_versionAuthor = versionAuthor;
		}
		
		void SplashLoad(object sender, EventArgs e)
		{
			_thInit = new Thread(new ThreadStart(ProcessStartupRoutines));
			_thInit.Start();						
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
		
		void ProcessStartupRoutines()
		{
			int progressVal = 0;
			string versionInfo = string.Format("v {0}, Release Date: {1}", _versionStr, _versionDate);
			SetControlPropertyThreadSafe(lblVersionStr, "Text", versionInfo);
			SetControlPropertyThreadSafe(tStatus, "Maximum", 4);
			SetControlPropertyThreadSafe(tStatus, "Value", progressVal);
			
			// open a connection to the cycle uploader database
			SetControlPropertyThreadSafe(tStatusText, "Text", "Opening Database...");
			_m_dbConnection = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;");
			_m_dbConnection.Open();
			progressVal++;
			SetControlPropertyThreadSafe(tStatus, "Value", progressVal);
			
			SetControlPropertyThreadSafe(tStatusText, "Text", "Retrieving Imported Ride History...");
			loadFileHistory();
			progressVal++;
			SetControlPropertyThreadSafe(tStatus, "Value", progressVal);
			
			checkForGarminConnectDetails();
			progressVal++;
			SetControlPropertyThreadSafe(tStatus, "Value", progressVal);
			
			checkForRideWithGpsDetails();
			progressVal++;
			SetControlPropertyThreadSafe(tStatus, "Value", progressVal);
			
			
			if(this.InvokeRequired){
				this.Invoke((MethodInvoker)delegate{
				            	this.Close();
				            });
			}
			else{
				this.Close();
			}
		}
		
		void checkForGarminConnectDetails()
		{
			try{
				SetControlPropertyThreadSafe(tStatusText, "Text", "Checking GarminConnect authentication details...");
				_gc_user = loadDbSetting("gc_user","");
				_gc_password = loadDbSetting("gc_password","");
				if(_gc_user != "" && _gc_password != "" ){
					_gc = new GarminConnectAPI();
					_gc_login = _gc.Login(_gc_user, _gc_password);
				}
			}
			catch(Exception ex){
				this.Invoke((MethodInvoker) delegate {
					MessageBox.Show("GarminConnect: Login Exception.\r\n" + ex.Message);                              	
				            });
				
			}
		}
		
		void checkForRideWithGpsDetails()
		{
			SetControlPropertyThreadSafe(tStatusText, "Text", "Checking RideWithGps authentication details...");
			_ridewithgps_email = loadDbSetting("ridewithgps_email","");
			_ridewithgps_password = loadDbSetting("ridewithgps_password","");
			_ridewithgps_token = loadDbSetting("ridewithgps_token","");
			
			try{
				if(_ridewithgps_email != "" && _ridewithgps_password != ""){
					_rwgps = new RideWithGpsAPI();
					if(_rwgps.login(_ridewithgps_email, _ridewithgps_password)){
						//EnableMenuItem(menuConnectToRideWithGps, false);
						//EnableMenuItem(menuViewAccountRideWithGps, true);
						_ridewithgps_token = _rwgps.getAuthToken();
					}
				}
			}
			catch{}
		}
		
		string loadDbSetting(string settingName, string defaultValue)
		{
			SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
			string sql = string.Format(@"select SettingValue from ApplicationSettings where SettingName = '{0}'",
			                       settingName
			                      );
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				rdr.Read();
				return (string)rdr["SettingValue"];
			}
			else{
				rdr.Close();
				rdr.Dispose();
				cmd.CommandText = string.Format(@"insert into ApplicationSettings (SettingName, SettingValue) VALUES ('{0}','{1}')",
				                                settingName,
				                                defaultValue
				                               );
				cmd.ExecuteNonQuery();
				return defaultValue;
			}
		}
		
		public void loadFileHistory()
		{
			string sql = "";
			SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
			
			sql = @"select distinct strftime(""%Y-%m"",fileActivityName) as `grp_label` from view_filehistory order by grp_label desc";
			
			command.CommandText = sql;
			SQLiteDataReader rdr_grp = command.ExecuteReader();
			while(rdr_grp.HasRows && rdr_grp.Read()){
				_lstGroups.Add(new ListViewGroup(System.DateTime.Parse((string)rdr_grp["grp_label"]).ToString("yyyy MMMM")));
			}
			rdr_grp.Close();
			rdr_grp.Dispose();
			
			sql = @"select * from view_filehistory order by fileActivityName desc";
			
			command.CommandText = sql;
			SQLiteDataReader rdr = command.ExecuteReader();
			if(rdr.HasRows){
				while(rdr.Read()){
					TimeSpan tsDuration = TimeSpan.FromSeconds(0);
					if(!rdr.IsDBNull(rdr.GetOrdinal("fsMovingTime"))){
						tsDuration = TimeSpan.FromSeconds(Convert.ToInt32(rdr["fsMovingTime"]));
					}

					string[] row = {
						Convert.ToInt32(rdr["idFile"]).ToString(),
						(string)rdr["fileActivityName"],
						(string)rdr["fileActivityDescription"],
						Convert.ToString(rdr["fileOpenDateTime"]),
						string.Format("{0:0.00} miles", rdr.IsDBNull(rdr.GetOrdinal("fsDistance")) ? 0 : Convert.ToDouble(rdr["fsDistance"])),  // distance
						string.Format("{0:D2} h {1:D2} m {2:D2} s", tsDuration.Hours, tsDuration.Minutes, tsDuration.Seconds),
						string.Format("{0:0.00} mph",rdr.IsDBNull(rdr.GetOrdinal("fsAvgSpeed")) ? 0 : Convert.ToDouble(rdr["fsAvgSpeed"])), // avg speed
						Convert.ToInt32(rdr["fileIsCommute"]) == 1 ? "Y" : "", // activity is commute
						Convert.ToInt32(rdr["fileIsStationaryTrainer"]) == 1 ? "Y" : "", // activity is stationary trainer
						rdr.IsDBNull(rdr.GetOrdinal("idCourse")) ? "0" : Convert.ToInt32(rdr["idCourse"]).ToString(),
						rdr.IsDBNull(rdr.GetOrdinal("courseName")) ? "" : (string)rdr["courseName"],
						(string)rdr["fileActivityNotes"] // notes
					};
					ListViewItem lvi = new ListViewItem(row);
					lvi.UseItemStyleForSubItems = false;
					// loop through the groups add apply grouping to item
					foreach(ListViewGroup lvg in _lstGroups)
					{
						if(System.DateTime.Parse((string)rdr["fileActivityName"]).ToString("yyyy MMMM") == lvg.Header){
							lvi.Group = lvg;
						}
					}
					
					// add item to list
					_lstItems.Add(lvi);
				}
				
				// adjust the groups to reflect the number of items they contain.
				foreach(ListViewGroup lvg in _lstGroups)
				{
					lvg.Header = lvg.Header + " (" + lvg.Items.Count.ToString() + ")";
				}
			}
		}
		
		void SplashFormClosing(object sender, FormClosingEventArgs e)
		{
			if(_thInit.IsAlive){
				_thInit.Abort();
			}
		}
	}
}
