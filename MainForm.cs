/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/02/2013
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*
	REGISTRY SETTINGS, for webBrowser control to use IE9
 
	HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION
		and add a new DWORD value named your program name (with .exe) and a decimal value set to 9999.

	HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_GPU_RENDERING 
		and add a new DWORD value named your program name (with .exe) and a hexadecimal value set to 1.
*/ 

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Xml;
using System.Web.Util;
using System.Web.Script.Serialization;
using System.Drawing;
using System.IO;
using System.Text;
using ZedGraph;
using Dynastream.Fit;
using Dynastream.Utility;
using System.Diagnostics;
using HealthGraphNet;
using HealthGraphNet.Models;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Stravan;
using Stravan.Json;
using System.Net;
using EmpyrealNight.Core.Json;
using System.Threading;
using System.Reflection;
using ListViewNF;
using System.Data.SQLite;
using ListViewExtended;

namespace CycleUploader
{

	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const int WM_DEVICECHANGE = 0x0219; //see msdn site
	    const int DBT_DEVICEARRIVAL = 0x8000;
	    const int DBT_DEVICEREMOVALCOMPLETE = 0x8004;
	    const int DBT_DEVTYPVOLUME = 0x00000002;
	    
		private readonly CheckForUpdate checkForUpdate = null;
		private bool bIsAutomaticUpdate = false;
		private DownloadedVersionInfo downloadedVersionInfo;
		private long _db_version;
		private GarminSettings _gs;
		
		private bool bSplashShown = false;
		private bool bGarminDetected = false;
		
		double avgHeart;
		double avgCadence;
		double avgSpeed;
		//double avgPower;
		Splash sp;
		
		string _client_id = "e54e428e76574fb1b5ae856f37befed2";
		string _client_secret = "d1d13b891ffa44c891ff41f74d0a6951";
		string _client_uri = "http://127.0.0.1/runkeeper.html";
		string _rk_auth_token = "";
		string _strava_token = "";
		int _strava_user_id = 0;
		string _strava_name = "";
		string _strava_username ="";
		string _strava_password = "";
		string _gc_user;
		string _gc_password;	
		string _endomondo_authToken;
		string _endomondo_displayName;
		string _endomondo_userId;
		string _endomondo_secureToken;
		
		string _GUID = "";
		
		string _ridewithgps_token = "";
		string _ridewithgps_email = "";
		string _ridewithgps_password = "";

		string _activity_file_name = "";
		//string _activity_file_type;
		
		int _autopause;
		
		string _previous_file_path = "";
		
		CycleUploader.Activity activity;
		
		RideWithGpsAPI _rwgps;
		GarminConnectAPI _gc;
		
		Thread _threadInit;
		Thread _threadUpload;
		Thread _threadProcessFile;
		
		private string _versionStr;
		private string _versionDate;
		private string _versionAuthor;
		private string _opened_file;
		
		// indicates whether it's a batch being processed, as we will perform some callbacks to 
		// the batch processing form to indicate status
		public bool _bIsBatchProcessing = false; 
		
		private Batch _activityBatch;
		private int _activityBatchRowIdx; // idx of the row being processed in the _activityBatch form
		
		// SQLite Database Connection
		public SQLiteConnection _m_dbConnection = null;
		// SQLite last `file` record id - audits history of files opened
		// All trackpoints are saved against each file record. This allows us to easily reload the data from our archive without the need 
		// to have access to the original file (TODO: Check data usage for this feature).
		private int _dbFileId;
		
		public class StravaResponse
		{
			public string id;
			public string upload_id;
		}
		
		public class FileSummary
		{
			public int dbId;
			public string fileName;
			public string filePath;
			// stats
			public int durationSeconds;
			public double distanceMiles;
			public int calories;
			public double avgHeartRate;
			public double avgCadence;
			public double avgSpeedMph;
			public int movingTimeSeconds;
			public double totalAscentFeet;
			public double totalDescentFeet;
			public int maxHeartRate;
			public int maxCadence;
			public double maxSpeedMph;
			public System.DateTime startTime;
		}
		
		private FileSummary _fileSummary;
		
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
		
		private delegate void SetStatusTextThreadSafeDelegate(ToolStrip control,string text );
		public void SetStatusTextThreadSafe(ToolStrip control, string text)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetStatusTextThreadSafeDelegate(SetStatusTextThreadSafe), new object[] { control, text});
		  	}
			else{
				
				statusbarStatus.Text = text;
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
		
		private delegate void SetMenuStatusThreadSafeDelegate(ToolStrip control, string field, object value);
		public void SetMenuStatusThreadSafe(ToolStrip control, string field, object value)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetMenuStatusThreadSafeDelegate(SetMenuStatusThreadSafe), new object[] { control, field, value});
		  	}
			else{
				//menuOpenFile.Enabled = Convert.ToBoolean(value);
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
		
		private delegate void SetListViewColumnWidthDelegate(Control ctrl, int colIdx, int width);
		private static void SetListViewColumnWidth(Control ctrl, int colIdx, int width)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SetListViewColumnWidthDelegate(SetListViewColumnWidth), new object[] {ctrl, colIdx, width});
			}
			else{
				((ListView)ctrl).Columns[colIdx].Width = width;
			}
		}
		
		private delegate void AppendControlTextThreadSafeDelegate(Control control, string appendString);
		public static void AppendControlTextThreadSafe(Control control, string appendString)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new AppendControlTextThreadSafeDelegate(AppendControlTextThreadSafe), new object[] { control, appendString});
		  	}
			else{
				control.Text += appendString;
				//control.GetType().InvokeMember("Text", BindingFlags.SetProperty, null, control, new object[] { appendString});
			}
		}
		
		public void setUpdateRideId(string provider, string id)
		{
			switch(provider){
				case "runkeeper":
					SetControlPropertyThreadSafe(sUploadRunkeeperId, "Text", id);
					break;
				case "strava":
					SetControlPropertyThreadSafe(sUploadStravaId, "Text", id);
					break;
				case "ridewithgps":
					SetControlPropertyThreadSafe(sUploadRideWithGpsId, "Text", id);
					break;
				case "garmin":
					SetControlPropertyThreadSafe(sUploadGarminId, "Text", id);
					break;
				default:
					break;
			}
		}
		
		public void setUpdateRideMsg(string provider, string error)
		{
			switch(provider){
				case "runkeeper":
					SetControlPropertyThreadSafe(sUploadRunkeeperMsg, "Text", error);
					break;
				case "strava":
					SetControlPropertyThreadSafe(sUploadStravaMsg, "Text", error);
					break;
				case "ridewithgps":
					SetControlPropertyThreadSafe(sUploadRideWithGpsMsg, "Text", error);
					break;
				case "garmin":
					SetControlPropertyThreadSafe(sUploadGarminMsg, "Text", error);
					break;
				default:
					break;
			}
		}
		public void setUpdateRideImg(string provider, Image pbImage)
		{
			switch(provider){
				case "runkeeper":
					SetControlPropertyThreadSafe(pbUploadStatusRunkeeper, "Image", pbImage);
					break;
				case "strava":
					SetControlPropertyThreadSafe(pbUploadStatusStrava, "Image", pbImage);
					break;
				case "ridewithgps":
					SetControlPropertyThreadSafe(pbUploadStatusRideWithGps, "Image", pbImage);
					break;
				case "garmin":
					SetControlPropertyThreadSafe(pbUploadStatusGarmin, "Image", pbImage);
					break;
				default:
					break;
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
		
		private void EnableMenuItem(ToolStripMenuItem item, bool enabled)
	    {
	        this.BeginInvoke(new MethodInvoker(delegate()
	        {
	            item.Enabled = enabled;
	        }
	        ));
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
		
		private delegate void SetListViewGroupDelegate(ListView ctrl, int idx, ListViewGroup grp);
		private static void SetListViewGroup(ListView ctrl, int idx, ListViewGroup grp)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SetListViewGroupDelegate(SetListViewGroup), new object[] { ctrl, idx, grp});
			}
			else{
				
				if(grp.Header.IndexOf("(") > 0){
					grp.Header = grp.Header.Substring(0,grp.Header.IndexOf("(")) + "(" + (grp.Items.Count+1).ToString() + ")";
				}
				else{
					grp.Header += " (" + (grp.Items.Count+1).ToString() + ")";
				}
				ctrl.Items[idx].Group = grp;
			}
		}
		
		private delegate void SetListViewGroupHeaderDelegate(ListView ctrl, int gidx, string header);
		private static void SetListViewGroupHeader(ListView ctrl, int gidx, string header)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SetListViewGroupHeaderDelegate(SetListViewGroupHeader), new object[] { ctrl, gidx, header });
			}else{
				ctrl.Groups[gidx].Header = header;
			}
		}
				
		private delegate string GetListViewGroupHeaderDelegate(ListView ctrl, int gidx);
		private static string GetListViewGroupHeader(ListView ctrl, int gidx)
		{
			if(ctrl.InvokeRequired){
				return (string)ctrl.Invoke(new GetListViewGroupHeaderDelegate(GetListViewGroupHeader), new object[] { ctrl, gidx });
			}else{
				return ctrl.Groups[gidx].Header;
			}
		}
		
		private delegate void AddListViewGroupDelegate(ListView ctrl, ListViewGroup grp);
		private static void AddListViewGroup(ListView ctrl, ListViewGroup grp)
		{
			if(ctrl.InvokeRequired)
			{
				ctrl.Invoke(new AddListViewGroupDelegate(AddListViewGroup), new object[] { ctrl, grp });
			}
			else{
				ctrl.Groups.Add(grp);
			}
		}
		
		
		public void setNewActivityLink(string provider, string text, string link)
		{
			switch(provider){
				case "runkeeper":
					break;
				case "strava":
					sUploadStravaId.Text = text;
					sUploadStravaId.Links[0].LinkData = link;
					break;
				case "ridewithgps":
					sUploadRideWithGpsId.Text = text;
					sUploadRideWithGpsId.Links[0].LinkData = link;
					break;
				case "garmin":
					sUploadGarminId.Text = text;
					sUploadRideWithGpsId.Links[0].LinkData = link;
					break;
			}
		}
		
		public MainForm(string versionStr, string versionDate, string versionAuthor, long db_version)
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
			_db_version = db_version;
			
			openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			
			// Altitude Graph Setup
			zedAltitude.GraphPane.Legend.IsVisible = false;
			zedAltitude.GraphPane.Title.Text = "Altitude";
			zedAltitude.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedAltitude.GraphPane.YAxis.Title.Text = "Feet";
			zedAltitude.GraphPane.IsFontsScaled = false;	
			
			// Speed Graph Setup
			zedSpeed.GraphPane.Legend.IsVisible = false;
			zedSpeed.GraphPane.Title.Text = "Speed";
			zedSpeed.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedSpeed.GraphPane.YAxis.Title.Text = "mph";
			zedSpeed.GraphPane.IsFontsScaled = false;
			// Heart Graph Setup
			zedHeart.GraphPane.Legend.IsVisible = false;
			zedHeart.GraphPane.Title.Text = "Heart-Rate";
			zedHeart.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedHeart.GraphPane.YAxis.Title.Text = "bpm";
			zedHeart.GraphPane.IsFontsScaled = false;
			// Cadence Graph Setup
			zedCadence.GraphPane.Legend.IsVisible = false;
			zedCadence.GraphPane.Title.Text = "Cadence";
			zedCadence.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedCadence.GraphPane.YAxis.Title.Text = "rpm";
			zedCadence.GraphPane.IsFontsScaled = false;
			// Temperature Graph Setup
			zedTemperature.GraphPane.Legend.IsVisible = false;
			zedTemperature.GraphPane.Title.Text = "Temperature";
			zedTemperature.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedTemperature.GraphPane.YAxis.Title.Text = "°C";
			zedTemperature.GraphPane.IsFontsScaled = false;
			//
			zedAltitude.GraphPane.XAxis.Scale.MagAuto = false;
			zedSpeed.GraphPane.XAxis.Scale.MagAuto = false;
			zedCadence.GraphPane.XAxis.Scale.MagAuto = false;
			zedHeart.GraphPane.XAxis.Scale.MagAuto = false;
			zedTemperature.GraphPane.XAxis.Scale.MagAuto = false;
			
			avgSpeed = 0;
			avgCadence =0;
			//avgPower = 0;
			avgHeart = 0;
			//_activity_file_type = "";
			
			_rwgps = new RideWithGpsAPI();
			_gc = new GarminConnectAPI();
			
			this.checkForUpdate = new CheckForUpdate(this);
		}
		
		protected override void WndProc(ref Message m) {
			try{
		        if(m.Msg == NativeMethods.WM_SHOWME) {
		            ShowMe();
		        }
				if (m.Msg == WM_DEVICECHANGE)
		        {
		            DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
		            if ((m.WParam.ToInt32() == DBT_DEVICEARRIVAL) &&  (vol.dbcv_devicetype == DBT_DEVTYPVOLUME) )
		            {
		            	if(checkForGarminDevice(DriveMaskToLetter(vol.dbcv_unitmask).ToString() + ":\\")){
		            		if(_gs == null || (_gs != null && !_gs.Visible)){
		            			bGarminDetected = true;
		            			if(bSplashShown){
		            				showGarminSettings();
		            			}
		            		}
		            	}
		            }
		            if ((m.WParam.ToInt32() == DBT_DEVICEREMOVALCOMPLETE) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
		            {
		            	//showGarminDeviceRemoved();
		            }
		        }
		        base.WndProc(ref m);
			}catch{}
	    }
		
		[StructLayout(LayoutKind.Sequential)] //Same layout in mem
	    public struct DEV_BROADCAST_VOLUME
	    {
	        public int dbcv_size;
	        public int dbcv_devicetype;
	        public int dbcv_reserved;
	        public int dbcv_unitmask;
	    }
	
	    private static char DriveMaskToLetter(int mask)
	    {
	        char letter;
	        string drives = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //1 = A, 2 = B, 3 = C
	        int cnt = 0;
	        int pom = mask / 2;
	        while (pom != 0)    // while there is any bit set in the mask shift it right        
	        {        
	            pom = pom / 2;
	            cnt++;
	        }
	        if (cnt < drives.Length)
	            letter = drives[cnt];
	        else
	            letter = '?';
	        return letter;
	    }
	    
	    bool checkForGarminDevice(string driveRoot)
		{
			if(System.IO.File.Exists(driveRoot + "Garmin\\Device.fit")){
	    		return true;
	    	}
	    	else{
				return false;
	    	}	
		}
	    
	    void searchRemovableDevicesForGarmin()
		{
			DriveInfo[] ListDrives = DriveInfo.GetDrives();

			foreach (DriveInfo Drive in ListDrives)
			{
			    if (Drive.DriveType == DriveType.Removable)
			    {
			    	if(checkForGarminDevice(Drive.RootDirectory.ToString())){
			    		if(_gs == null || (_gs != null && !_gs.Visible)){
			    			showGarminSettings();
			    		}
			    		return;
			    	}
			    }    
			}
		}
		
	    private void ShowMe() {
	        if(WindowState == FormWindowState.Minimized) {
	            WindowState = FormWindowState.Normal;
	        }
	        // get our current "TopMost" value (ours will always be false though)
	        bool top = TopMost;
	        // make our form jump to the top of everything
	        TopMost = true;
	        // set it back to whatever it was
	        TopMost = top;
	    }
		
		void BtnOpenFileClick(object sender, EventArgs e)
		{
			if(_previous_file_path == ""){
				_previous_file_path = Environment.SpecialFolder.Personal.ToString();
			}
			openFile.Filter = "All Files (*.fit,*.tcx,*.gpx)|*.fit;*.tcx;*.gpx|FIT File (*.fit)|*.fit|Garmin Training Center Database Files (*.tcx)|*.tcx|GPX Files (*.gpx)|*.gpx";
			openFile.Title = "Please select activity data file to view.";
			openFile.InitialDirectory = _previous_file_path;
			
			lstTrackpoints.Items.Clear();
			
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				
				// run a check against the database to determine if we've already opened this file
				using(var conn = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;"))
				{
					conn.Open();
					using(var command = new SQLiteCommand(conn)){
						string sql = string.Format("select * from File where fileName = \"{0}\"", Path.GetFileName(openFile.FileName));
						command.CommandText = sql;
						SQLiteDataReader rdr = command.ExecuteReader();
						if(rdr.HasRows){
							MessageBox.Show("Error: this file has already been processed by this application.\r\n\r\nAdditional processing is not supported, please perform this manually on the provider websites", "Error: File Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else{
							_opened_file = openFile.FileName;
							_fileSummary = new FileSummary();
							_threadProcessFile = new Thread(new ThreadStart(this.processSelectedFile));
							_threadProcessFile.Start();			
						}
					}
				}
			}
		}
		
		void processSelectedFile()
		{
			string filename = _opened_file;
			
			// de-activate the file-open menu item
			SetMenuStatusThreadSafe(menubar, "Enabled", false);
			
			// add the file record to our File log in cycleuploader sqllite database
			string sql = string.Format("insert into File(fileType, fileName, filePath, fileOpenDateTime, fileActivityName, fileActivityNotes, fileIsCommute, fileIsStationaryTrainer) values (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\",{6},{7})",
			                           Path.GetExtension(filename).ToLower(),
			                           Path.GetFileName(filename),
			                           Path.GetDirectoryName(filename),
			                           System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
			                           txtActivityName.Text, 
			                           txtActivityNotes.Text, 
			                           cbkIsCommute.Checked ? 1 :0,
			                           cbkIsStationaryTrainer.Checked ? 1 : 0
			                          );
			
			SQLiteCommand command = new SQLiteCommand(sql, _m_dbConnection);
			command.ExecuteNonQuery();				                           
			
			// retrieve the ID of the `file` from the database as we will need this later to 
			// store the trackpoints once we've processed the file contents
			sql = @"select last_insert_rowid()";
			command.CommandText = sql;
			_dbFileId = Convert.ToInt32(command.ExecuteScalar());
			_fileSummary.dbId = _dbFileId;
			_fileSummary.fileName = Path.GetFileName(filename);
			_fileSummary.filePath = Path.GetDirectoryName(filename);
			
			_previous_file_path = Path.GetDirectoryName(filename);
			
			SetControlPropertyThreadSafe(pnlNoFile, "Visible", false);
			switch(Path.GetExtension(filename).ToLower()){
				case ".fit":
					_activity_file_name = filename;
					processFile_FIT(filename);
					break;
				case ".tcx":
					_activity_file_name = filename;
					processFile_TCX(filename);
					break;
				case ".gpx":
					_activity_file_name = filename;
					processFile_GPX(filename);
					break;
				default:
					MessageBox.Show("unsupported file type selected");
					break;
			}
		
			ResizeListView(lstTrackpoints);
			
			// save the activity time from the trackpoints
			sql = string.Format("update File set fileActivityDateTime = \"{0}\" where idFile = {1}", 
			                    GetListViewItemValue(lstTrackpoints,0,0),
			                    _dbFileId
			                   );
			command.CommandText = sql;
			command.ExecuteNonQuery();
			
			// save trackpoints to database
			dbSaveTrackpoints();
			
			// save file summary information
			dbSaveSummary(_dbFileId);
			
			// refresh the FileHistory list
			if(!_bIsBatchProcessing){
				loadFileHistory();
			}
			
			SetMenuStatusThreadSafe(menubar, "Enabled", true);
			
			if(_bIsBatchProcessing){
				_activityBatch.responseFileOpened();
			}
		}
		
		void dbSaveSummary(int fileId)
		{
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("Archiving File information");
			}
			SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
			string sql = string.Format("insert into FileSummary(idFile, fsDuration, fsDistance, fsCalories, fsAvgHeart, fsAvgCadence, fsAvgSpeed, fsMovingTime, fsTotalAscent, fsTotalDescent, fsMaxHeartRate, fsMaxCadence, fsMaxSpeed) "+
			                           "VALUES ("+
			                           "  {0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\", \"{12}\" "+
			                           ")",
			                           _fileSummary.dbId,
			                           _fileSummary.durationSeconds, 
			                           _fileSummary.distanceMiles,
			                           _fileSummary.calories,
			                           _fileSummary.avgHeartRate,
			                           _fileSummary.avgCadence,
			                           _fileSummary.avgSpeedMph,
			                           _fileSummary.movingTimeSeconds,
			                           _fileSummary.totalAscentFeet,
			                           _fileSummary.totalDescentFeet,
			                           _fileSummary.maxHeartRate,
			                           _fileSummary.maxCadence,
			                           _fileSummary.maxSpeedMph
			                          );
			command.CommandText = sql;
			command.ExecuteNonQuery();
		}
		
		void dbSaveTrackpoints()
		{
			SetStatusProgressThreadSafe(statusBar, "Visible", 1);
			SetStatusProgressThreadSafe(statusBar, "Maximum", lstTrackpoints.Items.Count-1);
			SetStatusProgressThreadSafe(statusBar, "Value", 0);
			SetStatusTextThreadSafe(statusBar, "Archiving file information ... ");
			
			using(var conn = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;"))
			{
				conn.Open();
				using( var trans = conn.BeginTransaction())
				{
					using(var command = new SQLiteCommand(conn)){
						// set command text, and add parameters
						string sql = @"
							insert into FileTrackpoints (idFile, tpTime, tpDuration, tpAltitude, tpDistance, tpHeart, tpCadence, tpSpeed, tpLongitude, tpLatitude, tpTemperature, tpIsAutoPaused)
							values(?,?,?,?,?,?,?,?,?,?,?,?)";
						command.CommandText = sql;
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());
						command.Parameters.Add(new SQLiteParameter());							                           
							                          						
						for(int tp = 0; tp < lstTrackpoints.Items.Count; tp++){
							/*
							string sql = string.Format("insert into FileTrackpoints (idFile, tpTime, tpDuration, tpAltitude, tpDistance, tpHeart, tpCadence, tpSpeed, tpLongitude, tpLatitude, tpTemperature, tpIsAutoPaused) " +
							                           "values(" +
							                           "	{0},\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\""+
							                           ")",
							                           _dbFileId, 
							                           GetListViewItemValue(lstTrackpoints,tp,0),
							                           GetListViewItemValue(lstTrackpoints,tp,1),
							                           GetListViewItemValue(lstTrackpoints,tp,2),
							                           GetListViewItemValue(lstTrackpoints,tp,3),
							                           GetListViewItemValue(lstTrackpoints,tp,4),
							                           GetListViewItemValue(lstTrackpoints,tp,5),
							                           GetListViewItemValue(lstTrackpoints,tp,6),
							                           GetListViewItemValue(lstTrackpoints,tp,7),
							                           GetListViewItemValue(lstTrackpoints,tp,8),
							                           GetListViewItemValue(lstTrackpoints,tp,9),
							                           GetListViewItemValue(lstTrackpoints,tp,10)
							                          );
							command.CommandText = sql;
							*/
							
							command.Parameters[0].Value = _dbFileId;
							command.Parameters[1].Value = GetListViewItemValue(lstTrackpoints,tp,0);
							command.Parameters[2].Value = GetListViewItemValue(lstTrackpoints,tp,1);
							command.Parameters[3].Value = GetListViewItemValue(lstTrackpoints,tp,2);
							command.Parameters[4].Value = GetListViewItemValue(lstTrackpoints,tp,3);
							command.Parameters[5].Value = GetListViewItemValue(lstTrackpoints,tp,4);
							command.Parameters[6].Value = GetListViewItemValue(lstTrackpoints,tp,5);
							command.Parameters[7].Value = GetListViewItemValue(lstTrackpoints,tp,6);
							command.Parameters[8].Value = GetListViewItemValue(lstTrackpoints,tp,7);
							command.Parameters[9].Value = GetListViewItemValue(lstTrackpoints,tp,8);
							command.Parameters[10].Value = GetListViewItemValue(lstTrackpoints,tp,9);
							command.Parameters[11].Value = GetListViewItemValue(lstTrackpoints,tp,10);
							
							command.ExecuteNonQuery();
							// to reduce GUI updates, only update status every 50 trackpoints
							if((tp+1) % 50 == 0){
								SetStatusProgressThreadSafe(statusBar, "Value", tp);
								
								SetStatusTextThreadSafe(statusBar, string.Format("Archiving file information ... Data Point {0} of {1}", tp+1, lstTrackpoints.Items.Count));
								if(_bIsBatchProcessing){
									_activityBatch.setUploadProgressStatus(string.Format("Archiving file information ... Data Point {0} of {1}", tp+1, lstTrackpoints.Items.Count));
								}
							}
						}
					}
					trans.Commit();
				}
				SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			}
			SetStatusTextThreadSafe(statusBar, "");
		}
		
		void processFile_FIT(string filename)
		{
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("FIT: Opening Activity Fit File (" + filename + ")");
			}
			activity = new Activity();
			clear_summary();
			FileStream fitSource = new FileStream(filename, FileMode.Open);
			Decode fitSourceDec = new Decode();
			
			ClearListView(lstTrackpoints);

			
			MesgBroadcaster mesgBroadcaster = new MesgBroadcaster();
			
			// connect the broadcaster to our event (message) source (this this case the decoder)
			fitSourceDec.MesgEvent += mesgBroadcaster.OnMesg;
			fitSourceDec.MesgDefinitionEvent += mesgBroadcaster.OnMesgDefinition;
			
			// subscribe to message events of interest by connecting to the broadcaster
			mesgBroadcaster.MesgEvent += new MesgEventHandler(OnMesg);
			mesgBroadcaster.MesgDefinitionEvent += new MesgDefinitionEventHandler(OnMesgDefn);
			
			mesgBroadcaster.FileIdMesgEvent += new MesgEventHandler( OnFileIDMesg);
			mesgBroadcaster.UserProfileMesgEvent += new MesgEventHandler( OnUserProfileMesg);
			
			bool status = fitSourceDec.IsFIT(fitSource);
			status &= fitSourceDec.CheckIntegrity(fitSource);
			if(status == true){
				fitSourceDec.Read(fitSource);
			}
			else{
				MessageBox.Show("fit file integrity failed, attempting to read anyway");
				fitSourceDec.Read(fitSource);
			}
			fitSource.Close();	
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("FIT: Processing activity trackpoints");
			}
			Process_TrackPoints();
			
		}
		
		void uploadRideToStrava()
		{
			setUpdateRideMsg("strava","");
			setUpdateRideId("strava","-");
			setUpdateRideImg("ridewithgps",null);
			if(!_bIsBatchProcessing){
				setActiveTabPage("tabUploadStatus");
			}
			if(_bIsBatchProcessing){
				_activityBatch.setUploadStatus("strava","inprogress");
			}
			
			StravaWebClient swc = new StravaWebClient();
			AuthenticationService auth = new AuthenticationService(swc);

			setUpdateRideMsg("strava", "Authenticating User Credentials");
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("Strava: Authenticating user credentials");
			}
			AuthenticationV2 authV2 = auth.LoginV2(_strava_username, _strava_password);
			
			NameValueCollection nameValuePairs = new NameValueCollection();
			
			nameValuePairs.Add("token", authV2.Token);
			nameValuePairs.Add("type", "tcx"); //_activity_file_type);
			nameValuePairs.Add(System.Web.HttpUtility.UrlEncode("activity_type"), "ride");
			nameValuePairs.Add(System.Web.HttpUtility.UrlEncode("activity_name"), System.Web.HttpUtility.UrlEncode(txtActivityName.Text));
			
			setUpdateRideMsg("strava", "Preparing Activity Information For Upload");
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("Strava: Preparing activity for upload");
			}
			
			string tcx = TrackPointsToTcx();
			
			nameValuePairs.Add("data", tcx);
			
			setUpdateRideMsg("strava", "Uploading, waiting for a response");
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("Strava: Uploading activity, waiting for a response");
			}
			var request = WebRequest.Create("http://www.strava.com/api/v2/upload");
			request.Method = "POST";
			var boundary = "---------------------------" + System.DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
			request.ContentType = "multipart/form-data; boundary=" + boundary;
    		boundary = "--" + boundary;
			
    		using(var requestStream = request.GetRequestStream())
    		{
    			foreach(string name in nameValuePairs.Keys)
    			{
    				var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
    				requestStream.Write(buffer, 0, buffer.Length);
    				if(name == "data"){
    					buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}Content-Type: application/octet-stream{1}{1}", name, Environment.NewLine));
    				}
    				else{
		            buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
    				}
		            requestStream.Write(buffer, 0, buffer.Length);
		            buffer = Encoding.UTF8.GetBytes(nameValuePairs[name] + Environment.NewLine);
		            requestStream.Write(buffer, 0, buffer.Length);
    			}
    			    			
    			var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
        		requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
        		
    		}
			WebResponse response = request.GetResponse();
    		
    		Stream responseStream = response.GetResponseStream();
    		StreamReader responseStreamReader = new StreamReader(responseStream);
    		
    		string json = responseStreamReader.ReadToEnd();
    		
    		// try and parse the response
    		try{
    			StravaResponse stravaOut = new JavaScriptSerializer().Deserialize<StravaResponse>(json);
    			int strava_id = Convert.ToInt32(stravaOut.upload_id);
    			setUpdateRideMsg("strava", "Ride Uploaded Successfully");
    			setUpdateRideId("strava", strava_id.ToString());
    			
    			SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
				string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadStrava = \"{0}\", fileIsCommute = {4}, fileIsStationaryTrainer = {5} where idFile = {1}", 
				                           string.Format("http://app.strava.com/activities/{0}",strava_id), 
				                           _dbFileId,
				                           txtActivityName.Text, 
				                           txtActivityNotes.Text,
				                           cbkIsCommute.Checked ? 1 : 0,
				                           cbkIsStationaryTrainer.Checked ? 1 : 0
				                          );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
    			setUpdateRideImg("strava",Image.FromFile("success-icon.png"));
    			if(_bIsBatchProcessing){
    				_activityBatch.setUploadStatus("strava","success", string.Format("http://app.strava.com/activities/{0}",strava_id));
    				_activityBatch.setUploadProgressStatus("Strava: Uploaded Successfully. *note: if duplicate, it will be ignored automatically by Strava");
    			}
    		}
    		catch(Exception ex){
    			setUpdateRideMsg("strava", "Error processing response. " + ex.ToString());
    			setUpdateRideImg("strava",Image.FromFile("failure-icon.png"));
    			if(_bIsBatchProcessing){
    				_activityBatch.setUploadStatus("strava","error", "Strava: Error processing response. \r\n" + ex.ToString());
    				_activityBatch.setUploadProgressStatus("Strava: Error." + ex.Message);
    			}
    		}
		}
		
		
		#region Fit File Processing Handlers
		
		void OnMesgDefn(object sender, MesgDefinitionEventArgs e)
		{
			//Debug.WriteLine(string.Format("\r\nOnMesgDef: Received Defn for local message #{0}, it has {1} fields", e.mesgDef.LocalMesgNum, e.mesgDef.NumFields));
		}
		
		void OnMesg(object sender, MesgEventArgs e)
		{
			int epoch_seconds = 0;
			System.DateTime dt = new System.DateTime(1989,12,31,0,0,0);
			string timestamp;
			string duration;
			string altitude;
			string distance;
			string heart;
			string cadence;
			string speed;
			string lng;
			string lat;
			string temperature;
			//string paused = "";
			
			timestamp = duration = altitude = distance = heart = cadence = speed = lat = lng = temperature = "0";
			
			
			if(e.mesg.Name == "Record"){
				//Debug.WriteLine(string.Format("OnMesg: Received Mesg with global ID#{0}, its name is {1}", e.mesg.Num, e.mesg.Name));
	
				for (byte i=0; i<e.mesg.GetNumFields(); i++)
				{
					for (int j = 0; j < e.mesg.fields[i].GetNumValues(); j++)
					{
						//Debug.WriteLine(string.Format("\tField{0} Index{1} (\"{2}\" Field#{4}) Value: {3}", i, j, e.mesg.fields[i].GetName(), e.mesg.fields[i].GetValue(j), e.mesg.fields[i].Num));
						switch(e.mesg.fields[i].GetName()){
							case "Timestamp":
								epoch_seconds = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								dt = dt.AddSeconds(epoch_seconds);
								timestamp = dt.ToString("yyyy-MM-ddTHH:mm:ssZ",System.Globalization.CultureInfo.InvariantCulture);
								break;
							case "Speed":
								speed = e.mesg.fields[i].GetValue(j).ToString();
								if(speed == "" || speed == null){ speed = "0";}
								break;
							case "Altitude":
								altitude = string.Format("{0:0.00}",Convert.ToDouble(e.mesg.fields[i].GetValue(j)) * 3.2808399); // converted to feet from metres
								break;
							case "Cadence":
								cadence = e.mesg.fields[i].GetValue(j).ToString();
								if(cadence == "" || cadence == null){ cadence = "0";}
								break;
							case "Heart":
							case "HeartRate":
								heart = e.mesg.fields[i].GetValue(j).ToString();
								if(heart == "" || heart == null){ heart = "0";}
								break;
							case "Distance":
								distance = e.mesg.fields[i].GetValue(j).ToString();
								break;
							case "PositionLong":
								lng = e.mesg.fields[i].GetValue(j).ToString();
								break;
							case "PositionLat":
								lat = e.mesg.fields[i].GetValue(j).ToString();
								break;
							case "Temperature":
								temperature = e.mesg.fields[i].GetValue(j).ToString();
								if(temperature == "" || temperature == null){ temperature = "0";}
								break;
							
						}
					}
				} 
				//2147483647
				// only add the point if it has coordinates.
				//if(lng != "" && lat != "" && lng != "0" && lat != "0" && lat != "2147483647" && lng != "2147483647"){
				if(lng != "" && lat != "" && lat != "2147483647" && lng != "2147483647"){
					string[] row = {
						timestamp,
						duration.ToString(),
						altitude,
						distance,
						heart,
						cadence,
						speed,
						GeoMath.semicircle_to_degrees(Convert.ToDouble(lng)).ToString(),
						GeoMath.semicircle_to_degrees(Convert.ToDouble(lat)).ToString(),
						temperature,
						(Convert.ToDouble(speed) < Convert.ToDouble("0" + txtAutoPauseThreshold.Text) * 0.44704) ? "paused" : ""
					};
					
					AddListViewItem(lstTrackpoints, new ListViewItem(row));
					
					
					// attempt to set the duration
					if(lstTrackpoints.Items.Count > 1){
						System.DateTime cur = System.DateTime.ParseExact(GetListViewItemValue(lstTrackpoints, lstTrackpoints.Items.Count-1, 0),"yyyy-MM-ddTHH:mm:ssZ",System.Globalization.CultureInfo.InvariantCulture);
						System.DateTime pre = System.DateTime.ParseExact(GetListViewItemValue(lstTrackpoints, lstTrackpoints.Items.Count-2, 0),"yyyy-MM-ddTHH:mm:ssZ",System.Globalization.CultureInfo.InvariantCulture);
					
						TimeSpan ts = cur - pre;

						SetListViewItemValue(lstTrackpoints, lstTrackpoints.Items.Count-1, 1, (Convert.ToInt32(GetListViewItemValue(lstTrackpoints, lstTrackpoints.Items.Count-2, 1)) + ts.TotalSeconds).ToString());
					
					}
					else{
						SetListViewItemValue(lstTrackpoints, 0, 1, "0");
						
					}
				}
				
			}
			else if(e.mesg.Name == "Session"){
				for (byte i=0; i<e.mesg.GetNumFields(); i++)
				{
					for (int j = 0; j < e.mesg.fields[i].GetNumValues(); j++)
					{
						
						//Debug.WriteLine(string.Format("\tField{0} Index{1} (\"{2}\" Field#{4}) Value: {3}", i, j, e.mesg.fields[i].GetName(), e.mesg.fields[i].GetValue(j), e.mesg.fields[i].Num));
						switch(e.mesg.fields[i].GetName()){
							case "AvgSpeed":
								SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph ( {1:0.00} km/h )",Convert.ToDouble(e.mesg.fields[i].GetValue(j)) * 2.23693629,Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.6));
								avgSpeed = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								activity._avgSpeed = avgSpeed;
								_fileSummary.avgSpeedMph = avgSpeed * 2.23693629;
								break;
							case "AvgCadence":
								SetControlPropertyThreadSafe(lblCadence, "Text", string.Format("{0:0} rpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								avgCadence = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								activity._avgCadence = avgCadence;
								_fileSummary.avgCadence = avgCadence;
								break;
							case "AvgHeartRate":
								SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", string.Format("{0:0} bpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								avgHeart = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								activity._avgHeartRate = avgHeart;
								_fileSummary.avgHeartRate = avgHeart;
								break;
							case "TotalCalories":
								SetControlPropertyThreadSafe(lblCalories, "Text", string.Format("{0:0}",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._calories = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.calories = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalDistance":
								SetControlPropertyThreadSafe(lblDistance, "Text", string.Format("{0:0.0}", (Convert.ToDouble(e.mesg.fields[i].GetValue(j))/1000)*0.621371192) + " miles");
								activity._distance = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.distanceMiles = (Convert.ToDouble(e.mesg.fields[i].GetValue(j))/1000)*0.621371192;
								break;
							case "TotalElapsedTime":
								TimeSpan tme = TimeSpan.FromSeconds(Convert.ToInt32(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tme.Hours, 
					    			tme.Minutes, 
					    			tme.Seconds
					    		));
								_fileSummary.durationSeconds = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalTimerTime":
								TimeSpan tmm = TimeSpan.FromSeconds(Convert.ToInt32(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblMovingTime, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tmm.Hours, 
					    			tmm.Minutes, 
					    			tmm.Seconds
					    		));
								activity._duration = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								_fileSummary.movingTimeSeconds = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalAscent":
								SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} feet",Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399));
								activity._totalAscent = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.totalAscentFeet = (Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399);
								break;
							case "TotalDescent":
								SetControlPropertyThreadSafe(lblTotalDescent, "Text", string.Format("{0:0.00} feet",Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399));
								activity._totalDescent = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.totalDescentFeet = (Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399);
								break;
							case "MaxSpeed":
								SetControlPropertyThreadSafe(lblMaxSpeed, "Text", string.Format("{0:0.00} mph ( {1:0.00} km/h )",Convert.ToDouble(e.mesg.fields[i].GetValue(j)) * 2.23693629,Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.6));
								activity._maxSpeed = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.maxSpeedMph = Convert.ToDouble(e.mesg.fields[i].GetValue(j)) * 2.23693629;
								break;
							case "MaxCadence":
								SetControlPropertyThreadSafe(lblMaxCadence, "Text", string.Format("{0:0} rpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._maxCadence = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.maxCadence = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								break;
							case "MaxHeartRate":
								SetControlPropertyThreadSafe(lblMaxHeartRate,"Text", string.Format("{0:0} bpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._maxHeartRate = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								_fileSummary.maxHeartRate = Convert.ToInt32(e.mesg.fields[i].GetValue(j));
								break;
							case "StartTime":
								System.DateTime st = new System.DateTime(1989,12,31,0,0,0);
								st = st.AddSeconds(Convert.ToDouble(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblActivityDateTime, "Text", st.ToString("dd/MM/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture));
								activity._startTime = st;
								_fileSummary.startTime = st;
								break;
						}
					}
				}
			}
		}
		
		void OnFileIDMesg(object sender, MesgEventArgs e)
      	{
			//Debug.WriteLine(string.Format("FileIdHandler: Received {1} Mesg with global ID#{0}", e.mesg.Num, e.mesg.Name));
			FileIdMesg myFileId = (FileIdMesg)e.mesg;         
	         try
	         {
	         	//Debug.WriteLine(string.Format("\tType: {0}", myFileId.GetType()));
	         	//Debug.WriteLine(string.Format("\tManufacturer: {0}", myFileId.GetManufacturer()));
	         	//Debug.WriteLine(string.Format("\tProduct: {0}", myFileId.GetProduct()));
	         	//Debug.WriteLine(string.Format("\tSerialNumber {0}", myFileId.GetSerialNumber()));
	         	//Debug.WriteLine(string.Format("\tNumber {0}", myFileId.GetNumber()));
	         	Dynastream.Fit.DateTime dtTime = new Dynastream.Fit.DateTime(myFileId.GetTimeCreated().GetTimeStamp());
	         }
	         catch (FitException exception)
	         {
	         	Debug.WriteLine(string.Format("\tOnFileIDMesg Error {0}", exception.Message));
	         	Debug.WriteLine(string.Format("\t{0}", exception.InnerException));
	         }        
		}
		
		void OnUserProfileMesg(object sender, MesgEventArgs e)
		{
			
			UserProfileMesg myUserProfile = (UserProfileMesg)e.mesg;
			try
			{
				//Debug.WriteLine(string.Format("\tType {0}", myUserProfile.GetFriendlyName()));
				//Debug.WriteLine(string.Format("\tGender {0}", myUserProfile.GetGender().ToString()));
				//Debug.WriteLine(string.Format("\tAge {0}", myUserProfile.GetAge()));
				//Debug.WriteLine(string.Format("\tWeight  {0}", myUserProfile.GetWeight()));
			}        
			catch (FitException exception)
			{
				Debug.WriteLine(string.Format("\tOnUserProfileMesg Error {0}", exception.Message));
				Debug.WriteLine(string.Format("\t{0}", exception.InnerException));
			}  	
		}
		
		
		#endregion
		
		
		void processFile_GPX(string filename)
		{
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("GPX: Opening Activity GPX File (" + filename + ")");
			}
			activity = new Activity();
			clear_summary();
			XmlNodeList nodeList;
			string ext_prefix = "";
			double seconds_start = 0;
			double seconds_pt = 0;
			double lat_min = -1;
			double lat_max = -1;
			double lng_min = -1;
			double lng_max = -1;
			string js_coords = "";
			string js_centre = "";
			string js_bounds = "";
			int zoom = 11;
			bool bIsMioGPX = false;
			bool bIsStravaGPX = false;
			
			
			PointPairList graphListAltitude = new PointPairList();
			PointPairList graphListHeart = new PointPairList();
			PointPairList graphListSpeed = new PointPairList();
			PointPairList graphListCadence = new PointPairList();
			
			// clear the currently loaded trackpoints
			
			ClearListView(lstTrackpoints);
			
			// load the xml document
			XmlDocument doc = new XmlDocument();
			doc.Load(filename);
			
			XmlAttributeCollection xcol = doc.DocumentElement.Attributes;
			for(int i = 0; i < xcol.Count; i++){
				if(xcol[i].Value == "http://www.garmin.com/xmlschemas/TrackPointExtension/v1"){
					ext_prefix = xcol[i].LocalName;
				}
				if(xcol[i].Value == "MIO Cyclo - http://www.mio.com/cyclo/"){
					bIsMioGPX = true;
				}
				if(xcol[i].Value == "StravaGPX"){
					bIsStravaGPX = true;
				}
			}		
			
			nodeList = doc.GetElementsByTagName("name");
			SetControlPropertyThreadSafe(lblActivityDateTime, "Text", nodeList[0].InnerText);
			
					
			// get the track points
			XmlNodeList trackpoints = doc.GetElementsByTagName("trkpt");
			double lng=0;
			double lat=0;
			double lat_prev = 0;
			double lng_prev = 0;
			double distance = 0;
			double cadence = 0;
			double heart = 0;
			int mile_count = 1;
			string js_mile_markers = "";
			double start_lat = 0;
			double start_lng = 0;	
			double finish_lat = 0;
			double finish_lng = 0;
			double dur = 0;
			double dur_prev = 0;
			double dur_pt = 0;
			double distance_prev = 0;
			double speed = 0;
			double altitude = 0;
			double tot_heart = 0;
			double tot_cadence = 0;
			double gradient = 0;
			double elev_prev = 0;
			string time = "";
			
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("GPX: Processing trackpoints");
			}
			
			for(int t = 0; t < trackpoints.Count; t++){
				// extract the longitude / latitude coords
				lng = Convert.ToDouble(trackpoints[t].Attributes["lon"].Value);
				lat = Convert.ToDouble(trackpoints[t].Attributes["lat"].Value);
				
				if(t == 0){
					start_lat = lat;
					start_lng = lng;
				}
				finish_lat = lat;
				finish_lng = lng;
			
				altitude = Convert.ToDouble(trackpoints[t]["ele"].InnerText)*3.2808399;
				
				if(t > 0){
					distance += (GeoMath.Distance(lat, lng, lat_prev, lng_prev, GeoMath.MeasureUnits.Kilometers) * 1000);
				}
				
				// copy the lng/lat to act as the "prev" for next coord
				lng_prev = lng;
				lat_prev = lat;
				
				// extract the longitude / latitude coords
				lng = Convert.ToDouble(trackpoints[t].Attributes["lon"].Value);
				lat = Convert.ToDouble(trackpoints[t].Attributes["lat"].Value);
				if(lat_min == -1){ lat_min = lat;}
				if(lat_max == -1){ lat_max = lat;}
				if(lng_min == -1){ lng_min = lng;}
				if(lng_max == -1){ lng_max = lng;}
				
				if(lat < lat_min){ lat_min = lat;}
				if(lat > lat_max){ lat_max = lat;}
				if(lng < lng_min){ lng_min = lng;}
				if(lng > lng_max){ lng_max = lng;}
				
				if(!bIsStravaGPX){
					time = trackpoints[t]["time"].InnerText;
				}
				
				if(!bIsStravaGPX && t == 0){
					seconds_start = ((TimeSpan)(System.DateTime.Parse(trackpoints[0]["time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds;
				}	
				
				if(!bIsStravaGPX){
					seconds_pt = ((TimeSpan)(System.DateTime.Parse(trackpoints[t]["time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds - seconds_start;
					dur = seconds_pt;
					dur_pt = dur-dur_prev;
					dur_prev = seconds_pt;
					speed = (distance-distance_prev) / dur_pt;
					distance_prev = distance;
				}
				
				if(!bIsMioGPX && !bIsStravaGPX && trackpoints[t]["extensions"][ext_prefix+":TrackPointExtension"][ext_prefix+":cad"] != null){
					cadence = Convert.ToDouble(trackpoints[t]["extensions"][ext_prefix+":TrackPointExtension"][ext_prefix+":cad"].InnerText);
					tot_cadence += (dur_pt * cadence);
				}
				else if(bIsMioGPX){
					cadence = Convert.ToDouble(trackpoints[t]["extensions"]["cadence"].InnerText);
				}
			
				if(!bIsMioGPX && !bIsStravaGPX && trackpoints[t]["extensions"][ext_prefix+":TrackPointExtension"][ext_prefix+":hr"] != null){
					heart = Convert.ToDouble(trackpoints[t]["extensions"][ext_prefix+":TrackPointExtension"][ext_prefix+":hr"].InnerText);
					tot_heart += (dur_pt * heart);
				}
				else if(bIsMioGPX){
					heart = Convert.ToDouble(trackpoints[t]["extensions"]["heartrate"].InnerText);
				}
				
				if(!bIsMioGPX && !bIsStravaGPX){
					speed = (distance-distance_prev) / dur_pt;
				}
				else if(bIsMioGPX){
					speed = Convert.ToDouble(trackpoints[t]["extensions"]["speed"].InnerText);
				}
				
				
				
				if(distance > (1609.344 * mile_count)){
					js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + mile_count + "|95E978|004400',position: new google.maps.LatLng(" + lat + "," + lng + "),map: map,title: 'Mile " + mile_count + "'});";
					mile_count++;
				}
				
				
				
				elev_prev = altitude;
				
				// build string array and add it to the Trackpoints (lstTrackpoints) list view tab
				string[] row = {
					time,
					seconds_pt.ToString(),
					string.Format("{0:0.00}",altitude), // altitude (converted from metres to feet)
					distance.ToString(),
					heart.ToString(),
					cadence.ToString(),
					speed.ToString(),
					lng.ToString(),
					lat.ToString(),
					"0",
					""
				};
				AddListViewItem(lstTrackpoints, new ListViewItem(row));
				
				

				double dist = (distance * 0.621371192); // convert km to miles
				string tag = "";
				if(!bIsStravaGPX){
					tag = trackpoints[t]["time"].InnerText + "\r\nDistance = " + string.Format("{0:0.00}",(dist / 1000)) + " miles";
				}
				
				graphListCadence.Add(dist/1000,cadence,tag + "\r\nCadence = " + cadence + " rpm");
				graphListSpeed.Add(dist/1000,speed*2.23693629,tag + "\r\nSpeed = " + string.Format("{0:0.00}",speed*2.23693629) + " mph");
				graphListHeart.Add(dist/1000,Convert.ToDouble(heart),tag + "\r\nHear Rate = " + heart + " bpm");
				graphListAltitude.Add(dist/1000,Convert.ToDouble(trackpoints[t]["ele"].InnerText)*3.2808399,tag + "\r\nAltitude = " + Math.Round(Convert.ToDouble(trackpoints[t]["ele"].InnerText)*3.2808399) + " feet\r\nGradient = " + string.Format("{0:0.00}",gradient));
				
				if(t > 0 && lat != 0){
					js_coords += ",";
				}
				if(lat != 0){
					js_coords += "\r\nnew google.maps.LatLng(" + lat + "," + lng + ")";
				}
			}
			
			// calculations for summary section, as they aren't summarised for us in the GPX, but they are in the .TCX
			double avg_speed = 0;
			double avg_heart = 0;
			double avg_cadence = 0;
			
			if(!bIsMioGPX && !bIsStravaGPX){
				
				double dist_miles = (distance/1000) * 0.621371192;
				double dist_km = distance / 1000;
				double sec_start = ((TimeSpan)(System.DateTime.Parse(trackpoints[0]["time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds;
				double sec_end = ((TimeSpan)(System.DateTime.Parse(trackpoints[trackpoints.Count-1]["time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds;
				TimeSpan tot_duration = TimeSpan.FromSeconds(sec_end-sec_start);
				
				
				double mph = dist_miles / (tot_duration.TotalSeconds / 3600);
				double kph = dist_km / (tot_duration.TotalSeconds/3600);
				avg_speed = mph;
				double avg_speed_metres_per_sec = avg_speed / 2.23693629; // convert MPH to m/sec
				avg_heart = tot_heart / tot_duration.TotalSeconds;
				avg_cadence = tot_cadence / tot_duration.TotalSeconds;
				
				activity._distance = distance;
				activity._duration = tot_duration.TotalSeconds;
				activity._avgCadence = avg_cadence;
				activity._avgHeartRate = avg_heart;		
				activity._avgSpeed = avg_speed_metres_per_sec;		
			
				
				// set the summary information
				this.lblAvgHeartRate.Text = string.Format("{0:0.00} bpm", avg_heart);
				this.lblCadence.Text = string.Format("{0:0.00} rpm", avg_cadence);
				this.lblCalories.Text = "-";
				this.lblDistance.Text = string.Format("{0:0.00} miles ( {1:0.00} km )",dist_miles, dist_km);
				this.lblDuration.Text = string.Format("{0:D2} h {1:D2} m {2:D2} s", 
	    			tot_duration.Hours, 
	    			tot_duration.Minutes, 
	    			tot_duration.Seconds
	    		);
				this.lblAvgSpeed.Text = string.Format("{0:0.00} mph  ( {1:0.00} km/h )", mph, kph);
				
			}
			else if(bIsMioGPX){
				
				double dist_miles = (distance/1000) * 0.621371192;
				double dist_km = (distance/1000);
				TimeSpan tot_duration = TimeSpan.FromSeconds(Convert.ToDouble(doc.GetElementsByTagName("timelength").Item(0).InnerText));;
				
				double avg_speed_metres_per_sec = Convert.ToDouble(doc.GetElementsByTagName("avgspeed").Item(0).InnerText);
				double max_speed_metres_per_sec = Convert.ToDouble(doc.GetElementsByTagName("maxspeed").Item(0).InnerText);
				// convert avg_speed from metres/sec to miles/hour
				avg_speed = avg_speed_metres_per_sec * 2.23693629;
				double max_speed = max_speed_metres_per_sec * 2.23693629;
				double total_ascent = Convert.ToDouble(doc.GetElementsByTagName("totalascent").Item(0).InnerText);
				double total_descent = Convert.ToDouble(doc.GetElementsByTagName("totaldescent").Item(0).InnerText);
				avg_cadence = Convert.ToDouble(doc.GetElementsByTagName("avgcadence").Item(0).InnerText);
				avg_heart = Convert.ToDouble(doc.GetElementsByTagName("avgheartrate").Item(0).InnerText);
				double max_cadence = Convert.ToDouble(doc.GetElementsByTagName("maxcadence").Item(0).InnerText);
				double max_heartrate = Convert.ToDouble(doc.GetElementsByTagName("maxheartrate").Item(0).InnerText);
				
				activity._distance = distance;
				activity._duration = tot_duration.TotalSeconds;
				activity._avgCadence = avg_cadence;
				activity._maxCadence = max_cadence;
				activity._avgHeartRate = avg_heart;
				activity._maxHeartRate = max_heartrate;
				activity._avgSpeed = avg_speed_metres_per_sec;
				activity._calories = Convert.ToDouble(doc.GetElementsByTagName("calories").Item(0).InnerText);
				
				_fileSummary.distanceMiles = dist_miles;
				_fileSummary.durationSeconds = (int)tot_duration.TotalSeconds;
				_fileSummary.movingTimeSeconds = (int)tot_duration.TotalSeconds;
				_fileSummary.avgSpeedMph = avg_speed;
				_fileSummary.calories = (int)activity._calories;
				_fileSummary.avgCadence = activity._avgCadence;
				_fileSummary.avgHeartRate = activity._avgHeartRate;
				_fileSummary.maxCadence = (int)activity._maxCadence;
				_fileSummary.maxSpeedMph = max_speed_metres_per_sec * 2.23693629;
				_fileSummary.totalAscentFeet = total_ascent * 3.2808399;
				_fileSummary.totalDescentFeet = total_descent* 3.2808399;
				
				// set the summary information
				SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", string.Format("{0:0.00} bpm", avg_heart));
				SetControlPropertyThreadSafe(lblCadence, "Text", string.Format("{0:0.00} rpm", avg_cadence));
				SetControlPropertyThreadSafe(lblCalories, "Text", string.Format("{0:0}",activity._calories));
				SetControlPropertyThreadSafe(lblDistance, "Text", string.Format("{0:0.00} miles ( {1:0.00} km )",dist_miles, dist_km));
				SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
	    			tot_duration.Hours, 
	    			tot_duration.Minutes, 
	    			tot_duration.Seconds
	    		));
				SetControlPropertyThreadSafe(lblMovingTime, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
	    			tot_duration.Hours, 
	    			tot_duration.Minutes, 
	    			tot_duration.Seconds
	    		));
				SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph  ( {1:0.00} km/h )", avg_speed, avg_speed/0.621371192));
				SetControlPropertyThreadSafe(lblMaxSpeed, "Text", string.Format("{0:0.00} mph  ( {1:0.00} km/h )", max_speed, max_speed/0.621371192));
				SetControlPropertyThreadSafe(lblMaxCadence, "Text", string.Format("{0:0.00} rpm",max_cadence));
				SetControlPropertyThreadSafe(lblMaxHeartRate, "Text", string.Format("{0:0.00} bpm", max_heartrate));
				SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} ft", total_ascent * 3.2808399));
				SetControlPropertyThreadSafe(lblTotalDescent, "Text", string.Format("{0:0.00} ft", total_descent * 3.2808399));
			}
			else{
				SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", "-");
				SetControlPropertyThreadSafe(lblCadence, "Text", "-");
				SetControlPropertyThreadSafe(lblCalories, "Text", "-");
				SetControlPropertyThreadSafe(lblDuration, "Text", "-");
				SetControlPropertyThreadSafe(lblDistance, "Text", "-");
				SetControlPropertyThreadSafe(lblAvgSpeed, "Text", "-");
			}
			
			
			
			// add markers to signify the START / END of route
			js_mile_markers = 	"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});" + 
								js_mile_markers;
			
			// clear the current series on the charts
			zedCadence.GraphPane.CurveList.Clear();
			zedHeart.GraphPane.CurveList.Clear();
			zedSpeed.GraphPane.CurveList.Clear();
			zedAltitude.GraphPane.CurveList.Clear();
			zedTemperature.GraphPane.CurveList.Clear();
			// clear the current "lines" on the charts - used for showing the averages
			zedCadence.GraphPane.GraphObjList.Clear();
			zedHeart.GraphPane.GraphObjList.Clear();
			zedSpeed.GraphPane.GraphObjList.Clear();
			zedAltitude.GraphPane.GraphObjList.Clear();
			zedTemperature.GraphPane.GraphObjList.Clear();
			
			// add the data series to the relevant charts
			zedCadence.GraphPane.AddCurve("Cadence",graphListCadence,Color.Black, SymbolType.None).Line.Width = 1;
			zedAltitude.GraphPane.AddCurve("Altitude",graphListAltitude,Color.Green, SymbolType.None).Line.Width = 1;
			zedHeart.GraphPane.AddCurve("Heart Rate",graphListHeart,Color.Red, SymbolType.None).Line.Width = 1;
			zedSpeed.GraphPane.AddCurve("Speed",graphListSpeed,Color.Blue, SymbolType.None).Line.Width = 1;
			
			// set the x-axis scaling for all charts to the max distance travelled
			zedAltitude.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedAltitude.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedAltitude.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedAltitude.AxisChange();
			
			//
			zedSpeed.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedSpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.Scale.MaxAuto = true;
			zedSpeed.AxisChange();
			
			//
			zedCadence.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedCadence.AxisChange();
			
			//
			zedHeart.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000; 
			zedHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedHeart.AxisChange();
			
			
			// add trend line for average heart rate
			if(avg_heart != 0){
				LineObj heartAvg = new LineObj(
				    Color.Magenta,
				    zedHeart.GraphPane.XAxis.Scale.Min,
				    avg_heart,
				    zedHeart.GraphPane.XAxis.Scale.Max,
				    avg_heart
				);
				zedHeart.GraphPane.GraphObjList.Add(heartAvg);
			}
			// add trend line for average cadence
			if(avg_cadence != 0){
				LineObj cadenceAvg = new LineObj(
				    Color.Magenta,
				    zedCadence.GraphPane.XAxis.Scale.Min,
				    avg_cadence,
				    zedCadence.GraphPane.XAxis.Scale.Max,
				    avg_cadence
				);
				zedCadence.GraphPane.GraphObjList.Add(cadenceAvg);
			}
			// add trend line for average speed
			if(avg_speed != 0){
				LineObj speedAvg = new LineObj(
				    Color.Magenta,
				    zedSpeed.GraphPane.XAxis.Scale.Min,
				    avg_speed,
				    zedSpeed.GraphPane.XAxis.Scale.Max,
				    avg_speed
				);
				zedSpeed.GraphPane.GraphObjList.Add(speedAvg);
			}
			
			// calculate the centre point of the map
			js_centre = "new google.maps.LatLng(" + ((lat_min+lat_max)/2) + "," + ((lng_min+lng_max)/2) + ")";
			// create a bounding box for the map - so it can auto-zoom to the best level of detail
			js_bounds = @" 
				var latlngbounds = new google.maps.LatLngBounds();
				latlngbounds.extend(new google.maps.LatLng(" + lat_min + @"," + lng_min + @"));
				latlngbounds.extend(new google.maps.LatLng(" + lat_max + @"," + lng_max + @"));
				map.fitBounds(latlngbounds);
			";
			
			// build the route html
			if(!_bIsBatchProcessing){
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
				
				if(System.IO.File.Exists(Application.StartupPath + "\\route.html"))
				{
				   	System.IO.File.Delete(Application.StartupPath + "\\route.html");
				}
				FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\route.html");
	            StreamWriter writer = new StreamWriter(fs);  
	            writer.Write(routeHTML);  
	            writer.Close();  
	            
	            
	            // Build the [activity] object. Can't buld this as we go, as Mio (and possibly others) set the Time in the <extensions> tag
	            // based on when the file was created rather than when the activity took place. So we need to build the activity here so we 
	            // can get the correct information from the trackpoints and using [lstTrackpoints] makes this easier.
	            activity._startTime = System.DateTime.Parse(GetListViewItemValue(lstTrackpoints, 0, 0));
	            			
	            setTab(tabControlOverview, "tabMap");
	            
	            NavigateWebControl(webBrowser1, Application.StartupPath + "\\route.html");
			}
            
            EnableMenuItem(menuUploadToRunKeeper, true);
            EnableMenuItem(menuUploadToStrava, true);
            EnableMenuItem(menuUploadToGarminConnect, true);
            EnableMenuItem(menuUploadToRideWithGps, true);
			
            ResizeListView(lstTrackpoints);
		}
	
		void processFile_TCX(string filename)
		{
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("TCX: Opening Activity TCX File (" + filename + ")");
			}
			activity = new Activity();
			clear_summary();
			int t;
			string js_coords = "";
			string js_centre = "";
			string js_bounds = "";
			
			int mile_count = 1;
			string js_mile_markers = "";
			
			double lat_min = -1;
			double lat_max = -1;
			double lng_min = -1;
			double lng_max = -1;
			int cadence_total = 0;
			int cadence_total_time_nonzero = 0;
			XmlNodeList nodeList;
			double seconds_start = 0;
			double seconds_pt = 0;
			double total_time_seconds = 0;	
			int zoom = 11;
			double avgHeart = 0;
			double avgSpeed = 0;
			double avgCadence = 0;
			double maxCadence = 0;
			double totalAscent = 0;
			double totalDescent = 0;
			openFile.InitialDirectory = Path.GetDirectoryName(filename);
			// clear the currently loaded trackpoints
			ClearListView(lstTrackpoints);
			
			XmlDocument doc = new XmlDocument();
			doc.Load(filename);
			
			PointPairList graphListAltitude = new PointPairList();
			PointPairList graphListHeart = new PointPairList();
			PointPairList graphListSpeed = new PointPairList();
			PointPairList graphListCadence = new PointPairList();
			
			nodeList = doc.GetElementsByTagName("Id");
		
			System.DateTime d2= System.DateTime.Parse(nodeList[0].InnerText,  null, DateTimeStyles.RoundtripKind);
			SetControlPropertyThreadSafe(lblActivityDateTime, "Text", d2.ToString("U"));
			
			nodeList = doc.GetElementsByTagName("TotalTimeSeconds");
			total_time_seconds = Convert.ToDouble(nodeList[0].InnerText);
			
			activity._duration = total_time_seconds;
			activity._startTime = d2;
			_fileSummary.durationSeconds = Convert.ToInt32(total_time_seconds);
			_fileSummary.movingTimeSeconds = Convert.ToInt32(total_time_seconds); // Total Time = Moving Time for TCX (does from the Garmin anyway)
			_fileSummary.startTime = d2;
					
			TimeSpan tDuration = TimeSpan.FromSeconds(Convert.ToDouble(nodeList[0].InnerText));
			SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", tDuration.Hours, tDuration.Minutes, tDuration.Seconds));
			
			nodeList = doc.GetElementsByTagName("DistanceMeters");
			activity._distance = Convert.ToDouble(nodeList[0].InnerText);
			
			double miles;
			double kms;
			miles =  Convert.ToDouble(nodeList[0].InnerText) * 0.000621371192;
			kms = Convert.ToDouble(nodeList[0].InnerText)/1000;
			SetControlPropertyThreadSafe(lblDistance, "Text", miles.ToString("0.00") + " miles ( " + kms.ToString("0.00") + " km )");
			_fileSummary.distanceMiles = miles;
			
			nodeList = doc.GetElementsByTagName("Calories");
			SetControlPropertyThreadSafe(lblCalories, "Text", nodeList[0].InnerText);
			activity._calories = Convert.ToDouble(nodeList[0].InnerText);
			_fileSummary.calories = Convert.ToInt32(activity._calories);
			
			
			nodeList = doc.GetElementsByTagName("AverageHeartRateBpm");
			if(nodeList.Count > 0){
				SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", nodeList[0].InnerText);
				avgHeart = Convert.ToDouble(nodeList[0].InnerText);
				activity._avgHeartRate = avgHeart;	
				_fileSummary.avgHeartRate = avgHeart;
			}
			
			nodeList = doc.GetElementsByTagName("MaximumHeartRateBpm");
			if(nodeList.Count > 0){
				SetControlPropertyThreadSafe(lblMaxHeartRate, "Text", nodeList[0].InnerText);
				activity._maxHeartRate = Convert.ToDouble(nodeList[0].InnerText);
				_fileSummary.maxHeartRate = Convert.ToInt32(nodeList[0].InnerText);
			}
			
			nodeList = doc.GetElementsByTagName("Cadence");
			if(nodeList.Count > 0){
				SetControlPropertyThreadSafe(lblCadence, "Text", nodeList[0].InnerText);
				avgCadence = Convert.ToDouble(nodeList[0].InnerText);
				_fileSummary.avgCadence = avgCadence;
			}				
			
			nodeList = doc.GetElementsByTagName("MaximumSpeed");
			if(nodeList.Count > 0){
				double max_speed_mph;
				max_speed_mph = Convert.ToDouble(nodeList[0].InnerText) * 2.23693629; // convert metres per second to mph
				SetControlPropertyThreadSafe(lblMaxSpeed, "Text", string.Format("{0:0.00} mph", max_speed_mph));
				_fileSummary.maxSpeedMph = max_speed_mph;
			}
			
			
			double mph = miles / (tDuration.TotalSeconds / 3600);
			double kph = kms / (tDuration.TotalSeconds/3600);
			
			SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph  ( {1:0.00} km/h )", mph, kph));
			avgSpeed = mph;
			_fileSummary.avgSpeedMph = avgSpeed;
			
			XmlNodeList trackpoints = doc.GetElementsByTagName("Trackpoint");
			
			string distance, cadence, speed, heart;
			double lng, lat, altitude;
			
			
			int point = 0;
			distance = "0";
			double start_lat = 0;
			double start_lng = 0;	
			double finish_lat = 0;
			double finish_lng = 0;	
			double previousAltitude = 0;			

			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("TCX: Processing Trackpoints");
			}			
			
			for(t = 0; t < trackpoints.Count; t++){
				distance = cadence = speed = heart = "";
				lng = lat = altitude = 0;
				distance = "0";
				// if cadence tag exists then extract the cadence information - revolutions per minute
				if(trackpoints[t]["Cadence"] != null){
					cadence = trackpoints[t]["Cadence"].InnerText;
				}
				else{
					cadence = "0";
				}	
				
				if(Convert.ToDouble(cadence) > maxCadence){
					maxCadence = Convert.ToDouble(cadence);
				}
				
				// if position tag exists, then extract the lng/lat position information (GPS coordinates)
				if(trackpoints[t]["Position"] != null){
					point++;
					
					if(t == 0){
						start_lat = Convert.ToDouble(trackpoints[0]["Position"]["LatitudeDegrees"].InnerText);
						start_lng = Convert.ToDouble(trackpoints[0]["Position"]["LongitudeDegrees"].InnerText);
					}
					
					finish_lat = Convert.ToDouble(trackpoints[t]["Position"]["LatitudeDegrees"].InnerText);
					finish_lng = Convert.ToDouble(trackpoints[t]["Position"]["LongitudeDegrees"].InnerText);
				
					lng = Convert.ToDouble(trackpoints[t]["Position"]["LongitudeDegrees"].InnerText);
					lat = Convert.ToDouble(trackpoints[t]["Position"]["LatitudeDegrees"].InnerText);
					
					if(lat_min == -1){ lat_min = lat;}
					if(lat_max == -1){ lat_max = lat;}
					if(lng_min == -1){ lng_min = lng;}
					if(lng_max == -1){ lng_max = lng;}
					
					if(lat < lat_min){ lat_min = lat;}
					if(lat > lat_max){ lat_max = lat;}
					if(lng < lng_min){ lng_min = lng;}
					if(lng > lng_max){ lng_max = lng;}
				}
				// if altitude tag exists then extract the altitude, in metres
				if(trackpoints[t]["AltitudeMeters"] != null){
					altitude = Convert.ToDouble(trackpoints[t]["AltitudeMeters"].InnerText)*3.2808399;
				}
				
				// calculate the total ascent / descent
				// nb. need to skip the first trackpoint as this isn't climb / descent but is used to initialise the starting altitude
				if(t > 0){
					if(altitude > previousAltitude){
						totalAscent += Math.Abs(altitude - previousAltitude);
					}
					else{
						totalDescent += Math.Abs(altitude - previousAltitude);
					}
				}
				previousAltitude = altitude;
							
				
				// if heartratebpm tag exists then extract the heart rate - beats per minute
				if(trackpoints[t]["HeartRateBpm"] != null){
					heart = trackpoints[t]["HeartRateBpm"]["Value"].InnerText;
				}
				else{
					heart = "0";
				}
				// if distancemetres tag exists then extract the distance information (in metres).
				// check for distance crossing a `mile` and create a mile marker if it does
				if(trackpoints[t]["DistanceMeters"] != null){
					distance = trackpoints[t]["DistanceMeters"].InnerText;
					
					if(Convert.ToDouble(distance) > (1609.344 * mile_count)){
						//if(js_mile_markers != ""){ js_mile_markers += ",";
						js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + mile_count + "|95E978|004400',position: new google.maps.LatLng(" + lat + "," + lng + "),map: map,title: 'Mile " + mile_count + "'});";
						mile_count++;
					}
				}
				
				// retrieve speed, two different ways to support normal TCX and TrainerRoad versions
				// currently there are two different methods for defining the speed within the .TCX file that I have seen.
				// One as created by Garmin / Strava, and the other from TrainerRoad
				if(trackpoints[t]["Extensions"] != null){
					// Extract the Garmin / Strava speed if available
					if(trackpoints[t]["Extensions"]["TPX"] != null){
						if(trackpoints[t]["Extensions"]["TPX"]["Speed"] != null){
							speed = trackpoints[t]["Extensions"]["TPX"]["Speed"].InnerText;
						}
						else{
							speed = "0";
						}
					}
					// Extract TrainerRoad version of the speed if available
					else if(trackpoints[t]["Extensions"]["ns3:TPX"] != null){
						speed = trackpoints[t]["Extensions"]["ns3:TPX"]["ns3:Speed"].InnerText;
					}
					else{
						speed = "0";
					}
					
				}
				else{
					speed = "0";
				}
				
				if(t == 0){
					seconds_start = ((TimeSpan)(System.DateTime.Parse(trackpoints[0]["Time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds;
				}	
				seconds_pt = ((TimeSpan)(System.DateTime.Parse(trackpoints[t]["Time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))).TotalSeconds - seconds_start;
				
				if(t > 0 && Convert.ToInt32(cadence) != 0){
					
					int ttime = Convert.ToInt32(seconds_pt - (
							(
								(TimeSpan)(
									System.DateTime.Parse(trackpoints[t-1]["Time"].InnerText, null, DateTimeStyles.RoundtripKind)-new System.DateTime(1970, 1, 1))
							).TotalSeconds - seconds_start));
					
					cadence_total_time_nonzero += ttime;
					cadence_total += ttime * Convert.ToInt32(cadence);
					//cadence_total += Convert.ToInt32(cadence) * Convert.ToInt32(seconds_pt);
				}
				else{
					cadence_total += Convert.ToInt32(cadence);
				}
				
				// if distance is not zero then add the relevant data points to relevant PointPairs list
				// which is used to define all points to be added to each chart. 
				if(distance != "0"){
					double dist = (Convert.ToDouble(distance) * 0.621371192); // convert km to miles
					string tag = trackpoints[t]["Time"].InnerText + "\r\nDistance = " + string.Format("{0:0.00}",(dist / 1000)) + " miles";
					
					graphListCadence.Add(dist/1000,Convert.ToDouble(cadence),tag + "\r\nCadence = " + cadence + " rpm");
					graphListSpeed.Add(dist/1000,Convert.ToDouble(speed)*2.23693629,tag + "\r\nSpeed = " + string.Format("{0:0.00}",Convert.ToDouble(speed)*2.23693629) + " mph");
					graphListHeart.Add(dist/1000,Convert.ToDouble(heart),tag + "\r\nHear Rate = " + heart + " bpm");
					graphListAltitude.Add(dist/1000,Convert.ToDouble(altitude),tag + "\r\nAltitude = " + Math.Round(Convert.ToDouble(altitude)) + " feet");
				}
				
				// build string array and add it to the Trackpoints (lstTrackpoints) list view tab
				string[] row = {
					trackpoints[t]["Time"].InnerText, 
					seconds_pt.ToString(),
					string.Format("{0:0.00}",altitude),
					distance,
					heart,
					cadence,
					speed,
					lng.ToString(),
					lat.ToString(),
					"", // temp
					(Convert.ToDouble(speed) < Convert.ToDouble("0" + txtAutoPauseThreshold.Text) * 0.44704) ? "paused" : ""
				};
				AddListViewItem(lstTrackpoints, new ListViewItem(row));
				
				
				if(point > 1 && lat != 0){
					js_coords += ",";
				}
				if(lat != 0){
					js_coords += "\r\nnew google.maps.LatLng(" + lat + "," + lng + ")";
				}
			}
			
			// add markers to signify the START / END of route
			js_mile_markers = 	"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});" + 
								js_mile_markers;
			
			if(cadence_total_time_nonzero != 0){
				AppendControlTextThreadSafe(lblCadence, " ( avg " + (cadence_total / cadence_total_time_nonzero).ToString() + " )");
			}
			
			double max_width = (lat_max - ((lat_min+lat_max)/2));
			double max_height = (lng_max - ((lng_min+lng_max)/2));
			
			// clear the current series on the charts
			zedCadence.GraphPane.CurveList.Clear();
			zedHeart.GraphPane.CurveList.Clear();
			zedSpeed.GraphPane.CurveList.Clear();
			zedAltitude.GraphPane.CurveList.Clear();
			zedTemperature.GraphPane.CurveList.Clear();
			// clear the current "lines" on the charts - used for showing the averages
			zedCadence.GraphPane.GraphObjList.Clear();
			zedHeart.GraphPane.GraphObjList.Clear();
			zedSpeed.GraphPane.GraphObjList.Clear();
			zedAltitude.GraphPane.GraphObjList.Clear();
			zedTemperature.GraphPane.GraphObjList.Clear();
			
			// add the data series to the relevant charts
			zedCadence.GraphPane.AddCurve("Cadence",graphListCadence,Color.Black, SymbolType.None).Line.Width = 1;
			zedAltitude.GraphPane.AddCurve("Altitude",graphListAltitude,Color.Green, SymbolType.None).Line.Width = 1;
			zedHeart.GraphPane.AddCurve("Heart Rate",graphListHeart,Color.Red, SymbolType.None).Line.Width = 1;
			zedSpeed.GraphPane.AddCurve("Speed",graphListSpeed,Color.Blue, SymbolType.None).Line.Width = 1;
			
			// set the x-axis scaling for all charts to the max distance travelled
			zedAltitude.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedAltitude.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedAltitude.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedAltitude.AxisChange();
			//
			zedSpeed.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedSpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedSpeed.AxisChange();
			//
			zedCadence.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedCadence.AxisChange();
			//
			zedHeart.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000; 
			zedHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedHeart.AxisChange();
			
			// add trend line for average heart rate
			if(avgHeart != 0){
				LineObj heartAvg = new LineObj(
				    Color.Magenta,
				    zedHeart.GraphPane.XAxis.Scale.Min,
				    avgHeart,
				    zedHeart.GraphPane.XAxis.Scale.Max,
				    avgHeart
				);
				zedHeart.GraphPane.GraphObjList.Add(heartAvg);
			}
			// add trend line for average cadence
			if(avgCadence != 0){
				LineObj cadenceAvg = new LineObj(
				    Color.Magenta,
				    zedCadence.GraphPane.XAxis.Scale.Min,
				    avgCadence,
				    zedCadence.GraphPane.XAxis.Scale.Max,
				    avgCadence
				);
				zedCadence.GraphPane.GraphObjList.Add(cadenceAvg);
			}
			// add trend line for average speed
			if(avgSpeed != 0){
				LineObj speedAvg = new LineObj(
				    Color.Magenta,
				    zedSpeed.GraphPane.XAxis.Scale.Min,
				    avgSpeed,
				    zedSpeed.GraphPane.XAxis.Scale.Max,
				    avgSpeed
				);
				zedSpeed.GraphPane.GraphObjList.Add(speedAvg);
			}
			
			// calculate the centre point of the map
			js_centre = "new google.maps.LatLng(" + ((lat_min+lat_max)/2) + "," + ((lng_min+lng_max)/2) + ")";
			// create a bounding box for the map - so it can auto-zoom to the best level of detail
			js_bounds = @" 
				var latlngbounds = new google.maps.LatLngBounds();
				latlngbounds.extend(new google.maps.LatLng(" + lat_min + @"," + lng_min + @"));
				latlngbounds.extend(new google.maps.LatLng(" + lat_max + @"," + lng_max + @"));
				map.fitBounds(latlngbounds);
			";
			
			// build the route html
			if(!_bIsBatchProcessing){
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
				
				if(System.IO.File.Exists(Application.StartupPath + "\\route.html"))
				{
				   	System.IO.File.Delete(Application.StartupPath + "\\route.html");
				}
				FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\route.html");
	            StreamWriter writer = new StreamWriter(fs);  
	            writer.Write(routeHTML);  
	            writer.Close();  
				
	            NavigateWebControl(webBrowser1, Application.StartupPath + "\\route.html");
				
	            setTab(tabControlOverview, "tabMap");
			}
			
			SetControlPropertyThreadSafe(lblMaxCadence, "Text", string.Format("{0:0}", Convert.ToInt32(maxCadence)));
			activity._maxCadence = Convert.ToDouble(maxCadence);
			_fileSummary.maxCadence = Convert.ToInt32(maxCadence);
			
			if(totalAscent != 0){
				SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} ft", totalAscent));
				activity._totalAscent = totalAscent;
				_fileSummary.totalAscentFeet = totalAscent;
			}
			if(totalDescent != 0){
				SetControlPropertyThreadSafe(lblTotalDescent, "Text", string.Format("{0:0.00} ft", Math.Abs(totalDescent)));
				activity._totalDescent = Math.Abs(totalDescent);
				_fileSummary.totalDescentFeet = Math.Abs(totalDescent);
			}
            
            EnableMenuItem(menuUploadToRunKeeper, true);
            EnableMenuItem(menuUploadToStrava, true);
            EnableMenuItem(menuUploadToGarminConnect, true);
            EnableMenuItem(menuUploadToRideWithGps, true);
            
            ResizeListView(lstTrackpoints);
		}
	
		
		void BtnMapFullscreenClick(object sender, EventArgs e)
		{
			FullscreenMap fsMap;
			
			switch(tabControlOverview.SelectedIndex){
				case 0:
					fsMap = new FullscreenMap(Application.StartupPath + "\\route.html");
					fsMap.ShowDialog();
					break;
			}
			
		}
		
		void TabControlOverviewSelectedIndexChanged(object sender, EventArgs e)
		{
			switch(tabControlOverview.SelectedIndex){
				case 0:
					btnMapFullscreen.Visible = true;
					break;
				default:
					btnMapFullscreen.Visible = false;
					break;
			}
		}
		
		void clear_summary()
		{
			SetControlPropertyThreadSafe(lblActivityDateTime, "Text", "-");
			SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", "-");
			SetControlPropertyThreadSafe(lblAvgSpeed, "Text", "-");
			SetControlPropertyThreadSafe(lblCadence, "Text", "-");
			SetControlPropertyThreadSafe(lblCalories, "Text", "-");
			SetControlPropertyThreadSafe(lblDistance, "Text", "-");
			SetControlPropertyThreadSafe(lblDuration, "Text", "-");
			SetControlPropertyThreadSafe(lblMaxCadence, "Text", "-");
			SetControlPropertyThreadSafe(lblMaxHeartRate, "Text", "-");
			SetControlPropertyThreadSafe(lblMaxSpeed, "Text", "-");
			SetControlPropertyThreadSafe(lblMovingTime, "Text", "-");
			SetControlPropertyThreadSafe(lblTotalAscent, "Text", "-");
			SetControlPropertyThreadSafe(lblTotalDescent, "Text", "-");
			
		}
		
		void Process_TrackPoints()
		{
			int mile_count = 1;
			string zoom = "11";
			string js_mile_markers = "";
			string js_coords = "";
			string js_centre = "";
			string js_bounds = "";
			
			double lat_min = -1;
			double lat_max = -1;
			double lng_min = -1;
			double lng_max = -1;
			string distance; //, cadence, speed, heart;
			double lng, lat; //, altitude;
			
			
			//int point = 0;
			distance = "0";
			double start_lat = 0;
			double start_lng = 0;	
			double finish_lat = 0;
			double finish_lng = 0;	
			
			PointPairList graphListAltitude = new PointPairList();
			PointPairList graphListHeart = new PointPairList();
			PointPairList graphListSpeed = new PointPairList();
			PointPairList graphListCadence = new PointPairList();
			PointPairList graphListTemperature = new PointPairList();
			
			// clear the current series on the charts
			zedCadence.GraphPane.CurveList.Clear();
			zedHeart.GraphPane.CurveList.Clear();
			zedSpeed.GraphPane.CurveList.Clear();
			zedAltitude.GraphPane.CurveList.Clear();
			zedTemperature.GraphPane.CurveList.Clear();
			// clear the current "lines" on the charts - used for showing the averages
			zedCadence.GraphPane.GraphObjList.Clear();
			zedHeart.GraphPane.GraphObjList.Clear();
			zedSpeed.GraphPane.GraphObjList.Clear();
			zedAltitude.GraphPane.GraphObjList.Clear();
			zedTemperature.GraphPane.GraphObjList.Clear();
			
			for(int t = 0; t < lstTrackpoints.Items.Count; t++){
				if(t==0){
					start_lat = Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 8));
					start_lng = Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 7));
				}
				// update the last point coordinates
				finish_lat = lat = Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 8));
				finish_lng = lng = Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 7));
				
				
				if(lat != 0 || lng != 0){
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
					js_coords += "\r\nnew google.maps.LatLng(" + lat + "," + lng + ")";
				}
				
				// Check the distance reaching next mile threshold
				// in which case add a google maps mile marker
				if(Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 3)) > (1609.344 * mile_count)){
					//if(js_mile_markers != ""){ js_mile_markers += ",";
					js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + mile_count + "|95E978|004400',position: new google.maps.LatLng(" + lat + "," + lng + "),map: map,title: 'Mile " + mile_count + "'});";
					mile_count++;
				}
				
				
				double dist = Convert.ToDouble(GetListViewItemValue(lstTrackpoints, t, 3)) * 0.621371192; // convert km to miles
				string tag = GetListViewItemValue(lstTrackpoints,t,0) + "\r\nDistance = " + string.Format("{0:0.00}",(dist / 1000)) + " miles";
				
				graphListCadence.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,5)),tag + "\r\nCadence = " + GetListViewItemValue(lstTrackpoints,t,5) + " rpm");
				graphListSpeed.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,6))*2.23693629,tag + "\r\nSpeed = " + string.Format("{0:0.00}",Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,6))*2.23693629) + " mph");
				graphListHeart.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,4)),tag + "\r\nHeart Rate = " + string.Format("{0:0}",Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,4))) + " bpm");
				graphListAltitude.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2)),tag + "\r\nAltitude = " + string.Format("{0:0.00}",Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2))) + " feet");
				graphListTemperature.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,9)),tag + "\r\nTemperature = " + string.Format("{0:0}",Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,9))) + " °C");
				
				distance = dist.ToString();
			}
			
			
			
			// add the data series to the relevant charts
			zedCadence.GraphPane.AddCurve("Cadence",graphListCadence,Color.Black, SymbolType.None).Line.Width = 1;
			zedAltitude.GraphPane.AddCurve("Altitude",graphListAltitude,Color.Green, SymbolType.None).Line.Width = 1;
			zedHeart.GraphPane.AddCurve("Heart Rate",graphListHeart,Color.Red, SymbolType.None).Line.Width = 1;
			zedSpeed.GraphPane.AddCurve("Speed",graphListSpeed,Color.Blue, SymbolType.None).Line.Width = 1;
			zedTemperature.GraphPane.AddCurve("Temperature",graphListTemperature,Color.Orange, SymbolType.None).Line.Width = 1;
			
			// set the x-axis scaling for all charts to the max distance travelled
			zedAltitude.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance))/1000;
			zedAltitude.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedAltitude.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedAltitude.AxisChange();
			//
			zedSpeed.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance))/1000;
			zedSpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedSpeed.AxisChange();
			//
			zedCadence.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance))/1000;
			zedCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedCadence.AxisChange();
			//
			zedHeart.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance))/1000; 
			zedHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedHeart.AxisChange();
			//
			zedTemperature.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance))/1000; 
			zedTemperature.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedTemperature.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedTemperature.AxisChange();
			
			// add trend line for average heart rate
			if(avgHeart != 0){
				LineObj heartAvg = new LineObj(
				    Color.Magenta,
				    zedHeart.GraphPane.XAxis.Scale.Min,
				    avgHeart,
				    zedHeart.GraphPane.XAxis.Scale.Max,
				    avgHeart
				);
				zedHeart.GraphPane.GraphObjList.Add(heartAvg);
			}
			// add trend line for average cadence
			if(avgCadence != 0){
				LineObj cadenceAvg = new LineObj(
				    Color.Magenta,
				    zedCadence.GraphPane.XAxis.Scale.Min,
				    avgCadence,
				    zedCadence.GraphPane.XAxis.Scale.Max,
				    avgCadence
				);
				zedCadence.GraphPane.GraphObjList.Add(cadenceAvg);
			}
			// add trend line for average speed
			if(avgSpeed != 0){
				LineObj speedAvg = new LineObj(
				    Color.Magenta,
				    zedSpeed.GraphPane.XAxis.Scale.Min,
				    avgSpeed * 2.23693629,
				    zedSpeed.GraphPane.XAxis.Scale.Max,
				    avgSpeed * 2.23693629
				);
				zedSpeed.GraphPane.GraphObjList.Add(speedAvg);
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
			// only if we aren't batch processing - as this can cause locking issues with access
			// to the route.html file
			if(!_bIsBatchProcessing){
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
				
				
				if(System.IO.File.Exists(Application.StartupPath + "\\route.html"))
				{
				   	System.IO.File.Delete(Application.StartupPath + "\\route.html");
				}
				FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\route.html");
	            StreamWriter writer = new StreamWriter(fs);  
	            writer.Write(routeHTML);  
	            writer.Close();  
				
	            NavigateWebControl(webBrowser1, Application.StartupPath + "\\route.html");
			
            	setTab(tabControlOverview, "tabMap");          
			}
            EnableMenuItem(menuUploadToRunKeeper, true);
            EnableMenuItem(menuUploadToGarminConnect, true);
            EnableMenuItem(menuUploadToStrava, true);
            EnableMenuItem(menuUploadToRideWithGps, true);
		}
		
		void menuUploadToRunKeeperClick(object sender, EventArgs e)
		{
			try{
				if(_threadUpload.IsAlive){
					_threadUpload.Abort();
				}
			}
			catch{}
			
			_threadUpload = new Thread(new ThreadStart(this.uploadRideToRunKeeper));
			_threadUpload.Start();
		}
		
		
		void uploadRideToRunKeeper()
		{
			setUpdateRideMsg("runkeeper","");
			setUpdateRideId("runkeeper","-");
			setUpdateRideImg("runkeeper",null);
			if(!_bIsBatchProcessing){
				setActiveTabPage("tabUploadStatus");
			}

			EnableMenuItem(menuUploadToRunKeeper, false);
			
			try{
				if(_rk_auth_token != ""){
					if(_bIsBatchProcessing){
						_activityBatch.setUploadStatus("runkeeper","inprogress");
					}
					
					
					setUpdateRideMsg("runkeeper", "Authenticating User Credentials");
					if(_bIsBatchProcessing){
						_activityBatch.setUploadProgressStatus("Runkeeper: Authenticating User Credentials");
					}
					AccessTokenManager tm = new AccessTokenManager(_client_id, _client_secret, _client_uri, _rk_auth_token);
					//tm.InitAccessToken(rk_auth_code);
					
					//Retrieve URIs for HealthGraph endpoints.
					setUpdateRideMsg("runkeeper", "Retrieving API Endpoints");
					if(_bIsBatchProcessing){
						_activityBatch.setUploadProgressStatus("Runkeeper: Retrieving API configuration information");
					}
					UsersEndpoint userRequest = new UsersEndpoint(tm);
					UsersModel user = userRequest.GetUser();
					
					// Retrieve the user profile, so we know what the username is for building 
					// the full activity link
					if(_bIsBatchProcessing){
						_activityBatch.setUploadProgressStatus("Runkeeper: Retrieving User Profile Details");
					}
					ProfileEndpoint userProfile = new ProfileEndpoint(tm, user);
					ProfileModel profile = userProfile.GetProfile();
					
					// upload the activity to the Runkeeper website.
					setUpdateRideMsg("runkeeper", "Uploading Activity Information");
					if(_bIsBatchProcessing){
						_activityBatch.setUploadProgressStatus("Runkeeper: Uploading Activity, Waiting for response");
					}
					FitnessActivitiesNewModel newActivity = new FitnessActivitiesNewModel();
					newActivity.Type = "Cycling";
					newActivity.Notes = txtActivityNotes.Text;
					newActivity.AverageHeartRate = Convert.ToInt32(activity._avgHeartRate);
					newActivity.TotalCalories = activity._calories;
					newActivity.StartTime = activity._startTime;
					newActivity.TotalDistance = activity._distance;
					newActivity.Duration = activity._duration;
	
					// try to detect auto pause.
					newActivity.DetectPauses = true;
					
					newActivity.Path = new List<PathModel>();
					newActivity.HeartRate = new List<HeartRateModel>();
					
					// loop through the trackpoints and add the Path items
					Double _timestamp;
					for(int t = 0; t < lstTrackpoints.Items.Count; t++){
						_timestamp = Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,1));
						if(GetListViewItemValue(lstTrackpoints,t,8) != "0" && GetListViewItemValue(lstTrackpoints,t,7) != "0"){
							PathModel pm = new PathModel();
							pm.Timestamp = _timestamp;
							pm.Latitude = Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,8));
							pm.Longitude = Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,7));
							pm.Altitude = Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2));
							
							pm.Type = (GetListViewItemValue(lstTrackpoints, t, 10)) == "" ? "gps" : "pause";
							newActivity.Path.Add(pm);
						}
						newActivity.HeartRate.Add(new HeartRateModel{Timestamp=_timestamp, HeartRate=Convert.ToInt32(GetListViewItemValue(lstTrackpoints,t,4))});
					}
					
					FitnessActivitiesEndpoint activityRequest = new FitnessActivitiesEndpoint(tm, user);
					string link = activityRequest.CreateActivity(newActivity);
					setUpdateRideMsg("runkeeper", "Ride Uploaded Successfully");
					setUpdateRideId("runkeeper",link);
					setNewActivityLink("runkeeper", link, link);
					setUpdateRideImg("runkeeper",Image.FromFile("success-icon.png"));
					link = link.Replace("fitnessActivities/","activity/");
					if(_bIsBatchProcessing){
						_activityBatch.setUploadStatus("runkeeper","success", profile.Profile + link);
						_activityBatch.setUploadProgressStatus("Runkeeper: Uploaded Successfully");
					}
					
					SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
					string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadRunkeeper = \"{0}\" where idFile = {1}", 
					                           profile.Profile + link , 
					                           _dbFileId,
					                           txtActivityName.Text, 
					                           txtActivityNotes.Text,
					                           cbkIsCommute.Checked ? 1 :0,
					                           cbkIsStationaryTrainer.Checked ? 1 : 0
					                          );
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					
				}
				else{
					setUpdateRideMsg("runkeeper","Runkeeper account hasn`t been linked to application yet. \r\nCannot upload at this time.");
					setUpdateRideImg("runkeeper",Image.FromFile("failure-icon.png"));
					if(_bIsBatchProcessing){
						_activityBatch.setUploadStatus("runkeeper","not linked", "Runkeeper: account hasn`t been linked to application yet. \r\nCannot upload at this time.");
					}
				}
			}
			catch(Exception ex){
				setUpdateRideMsg("runkeeper","Exception uploading activity. " + ex.ToString());
				setUpdateRideImg("runkeeper",Image.FromFile("failure-icon.png"));
				if(_bIsBatchProcessing){
					_activityBatch.setUploadStatus("runkeeper","exception", "Runkeeper: Exception uploading activity. " + ex.ToString());
				}
			}
			ResizeListView(lstTrackpoints);
		}
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			try{
			// open a connection to the cycle uploader database
			_m_dbConnection = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;");
			_m_dbConnection.Open();
			
			// run a test to see if the database schema requires updating
			SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
			cmd.CommandText = "PRAGMA user_version";
			long result = (long)cmd.ExecuteScalar();
			if(result != _db_version){
				DatabaseSchemaUpdate frmDbUpdate = new DatabaseSchemaUpdate(result, _db_version, _m_dbConnection);
				if(frmDbUpdate.ShowDialog() != DialogResult.OK){
					MessageBox.Show("Error: problem migrating the database to the latest version. Exiting program");
					this.Close();
					return;
				}
			}
			
			// the user settings were stored in the registry prior to version6 of the database schema
			// so issue a one-time alert about having to re-connect to chosen providers before uploading of rides.
			if( result < 6){
				string settings_migration_alert = loadDbSetting("settings_migration_alert","");
				if(settings_migration_alert == ""){
					if(MessageBox.Show("This version of the application requires that you reconnect to your chosen providers before attempting to upload any more rides, or errors may occur.\r\n\r\nThis message will not show again.","Reconnect with providers...",MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK){
						saveDbSetting("settings_migration_alert","ok");
					}
				}
			}
						
			
			statusBarVersion.Text = _versionStr + ", " + _versionDate;
			
			this.bIsAutomaticUpdate = true;
			this.checkForUpdate.OnCheckForUpdate();
			
			this.Visible = false;
			sp = new Splash(this._versionStr, this._versionDate, this._versionAuthor);
			sp.ShowDialog();
			bSplashShown = true;
			
			_gc_user = sp._gc_user;
			_gc_password = sp._gc_password;
			if(sp._gc_login){
				EnableMenuItem(menuConnectToGarmin,false);
				EnableMenuItem(menuViewAccountGarmin, true);
			}
			
			_rwgps = sp._rwgps;
			_ridewithgps_email = sp._ridewithgps_email;
			_ridewithgps_password = sp._ridewithgps_password;
			_ridewithgps_token = sp._ridewithgps_token;
			if(_ridewithgps_token != ""){
				EnableMenuItem(menuConnectToRideWithGps, false);
				EnableMenuItem(menuViewAccountRideWithGps, true);
			}
			
			// add the groups to the list view
			foreach(ListViewGroup lvg in sp._lstGroups){
				AddListViewGroup(lstFileHistory, lvg);
			}
			lstFileHistory.SetGroupState(ListViewGroupState.Collapsible);

			// add the items to the list view
			foreach(ListViewItem lvi in sp._lstItems){
				AddListViewItem(lstFileHistory,lvi);
			}
			
			ResizeListView(lstFileHistory);
			SetListViewColumnWidth(lstFileHistory,9,0);
			
			_threadInit = new Thread(new ThreadStart(this.initialiseProviders));
			_threadInit.Start();
			}
			catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
			
		}
		
		// this method is called when the checkForUpdate finishes checking
        // for the new version. If this method returns true, our checkForUpdate
        // object will download the installer
        public bool OnCheckForUpdateFinished(DownloadedVersionInfo versionInfo)
        {
            if ((versionInfo.error) || (versionInfo.installerUrl.Length == 0) || (versionInfo.latestVersion == null))
            {
                MessageBox.Show(this, "Error while looking for the newest version", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.downloadedVersionInfo = versionInfo;
            // compare the current version with the downloaded version number
            Version curVer = new Version(_versionStr);
            
            if (curVer.CompareTo(versionInfo.latestVersion) >= 0)
            {
            	
                // no new version
                if(!bIsAutomaticUpdate){
               	 MessageBox.Show(this, "No new version detected", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return false;
            }

            // new version found, ask the user if he wants to download the installer
            if(!bIsAutomaticUpdate){
            	UpdateNotification un = new UpdateNotification("download", curVer.ToString(), versionInfo.latestVersion.ToString(),versionInfo.changes);
            	return (un.ShowDialog() == DialogResult.Yes);
            }
            else{
            	// return Yes for automatic updates
            	return true;
            }
        }

        // called after the checkForUpdate object downloaded the installer
        public void OnDownloadInstallerinished(DownloadInstallerInfo info)
        {
            if (info.error)
            {
                MessageBox.Show(this, "Error while downloading the installer", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ask the user if he want to start the installer
            string msg = "";
            DialogResult result;
            
            if(this.bIsAutomaticUpdate){
            	Version curVer = new Version(_versionStr);
            	UpdateNotification un = new UpdateNotification("install", curVer.ToString(), this.downloadedVersionInfo.latestVersion.ToString(),this.downloadedVersionInfo.changes);
            	result = un.ShowDialog();
            }
            else{
            	msg = "Do you want to install the newest version ?";
            	result = MessageBox.Show(this, msg, "Check for updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            
            
            if (result != DialogResult.Yes)
            {
                // it not - remove the downloaded file
                try
                {
                    System.IO.File.Delete(info.path);
                }
                catch { }
                return;
            }
            else{
	            // run the installer and exit the app
	            try
	            {
	                Process.Start(info.path);
	                this.Close();
	            }
	            catch (Exception)
	            {
	                MessageBox.Show(this, "Error while running the installer.", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
	                try
	                {
	                    System.IO.File.Delete(info.path);
	                }
	                catch { }
	            }
	            return;
            }
        }
		
		void initialiseProviders()
		{
			int step =0; 
			try{
			SetStatusProgressThreadSafe(statusBar, "Value",step);
			SetStatusProgressThreadSafe(statusBar, "Maximum", 4);
			SetStatusTextThreadSafe(statusBar, "Initialising...");
			checkForGUID();
			
			loadProviderStates();
			loadUserSettings();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Endomondo Configuration...");
			checkForEndomondoDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Runkeeper Configuration...");
			checkForRunkeeperConnectToken();
			
			//SetStatusProgressThreadSafe(statusBar, "Value",++step);
			//SetStatusTextThreadSafe(statusBar, "Loading GarminConnect Configuration...");
			//checkForGarminConnectDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Strava Configuration...");
			checkForStravaConnectToken();
			
			//SetStatusProgressThreadSafe(statusBar, "Value",++step);
			//SetStatusTextThreadSafe(statusBar, "Loading RideWithGPS Configuration...");
			//checkForRideWithGpsDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Performing Clean-Up...");
			
			//SetStatusProgressThreadSafe(statusBar, "Value",++step);			
			//SetStatusTextThreadSafe(statusBar, "");
			//SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			
			// load the file open history information
			//SetStatusProgressThreadSafe(statusBar, "Value" ,++step);
			//SetStatusTextThreadSafe(statusBar, "Loading File History Information...");
			//SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			if(!_bIsBatchProcessing){
				//loadFileHistory();
			}
			SetStatusTextThreadSafe(statusBar, "Done.");
			
			// enable various panels on the form
			SetControlPropertyThreadSafe(grpSummary, "Enabled", true);
			SetControlPropertyThreadSafe(grpProviders, "Enabled", true);
			SetControlPropertyThreadSafe(tabControlOverview, "Enabled", true);
			SetControlPropertyThreadSafe(btnMapFullscreen, "Enabled", true);
			SetControlPropertyThreadSafe(menubar, "Enabled", true);	
			
			setTab(tabControlOverview, "tabFileHistory");
			
			this.Invoke(new MethodInvoker(searchRemovableDevicesForGarmin));
			}
			catch(Exception ex){
				
				try{
					_threadInit.Abort();
				    MessageBox.Show(ex.ToString()); 
				}
				catch{}
				
			}
			finally{
				if(sp.InvokeRequired){
					this.Invoke((MethodInvoker) delegate {
					            	sp.Close();
					            });
				}
				else{
					sp.Close();
				}
				
			}
		}
		
		public void loadFileHistory()
		{
			string sql = "";
			SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
			// clear the current file history information, do this so we can use
			// the same function to reload
			ClearListView(lstFileHistory);
			List<ListViewItem> lstItems = new List<ListViewItem>();
			List<ListViewGroup> lstGroups = new List<ListViewGroup>();
			
			sql = @"select distinct strftime(""%Y-%m"",fileActivityName) as `grp_label` from view_filehistory order by grp_label desc";
			
			command.CommandText = sql;
			SQLiteDataReader rdr_grp = command.ExecuteReader();
			while(rdr_grp.HasRows && rdr_grp.Read()){
				lstGroups.Add(new ListViewGroup(System.DateTime.Parse((string)rdr_grp["grp_label"]).ToString("yyyy MMMM")));
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
					foreach(ListViewGroup lvg in lstGroups)
					{
						if(System.DateTime.Parse((string)rdr["fileActivityName"]).ToString("yyyy MMMM") == lvg.Header){
							lvi.Group = lvg;
						}
					}
					
					// add item to list
					lstItems.Add(lvi);
				}
				
				// adjust the groups to reflect the number of items they contain.
				foreach(ListViewGroup lvg in lstGroups)
				{
					lvg.Header = lvg.Header + " (" + lvg.Items.Count.ToString() + ")";
				}
				
				// add the groups to the list view
				foreach(ListViewGroup lvg in lstGroups){
					AddListViewGroup(lstFileHistory, lvg);
				}
				//lstFileHistory.SetGroupState(ListViewGroupState.Collapsed | ListViewGroupState.Collapsible);
				lstFileHistory.SetGroupState(ListViewGroupState.Collapsible);

				// add the items to the list view
				foreach(ListViewItem lvi in lstItems){
					AddListViewItem(lstFileHistory,lvi);
				}
				
				ResizeListView(lstFileHistory);
				SetListViewColumnWidth(lstFileHistory,9,0);
				
			}
			
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
		
		void saveDbSetting(string settingName, string settingValue)
		{
			SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
			cmd.CommandTimeout = 2;
			string sql = string.Format(@"REPLACE INTO ApplicationSettings (SettingName, SettingValue) VALUES ('{0}', '{1}')",
			                           settingName,
			                           settingValue
			                          );
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
		}
		
		void loadProviderStates()
		{
			string rk = loadDbSetting("checkRunkeeper","False");
			SetControlPropertyThreadSafe(cbkProviderRunkeeper, "Checked", Convert.ToBoolean(loadDbSetting("checkRunkeeper","False")));
			SetControlPropertyThreadSafe(cbkProviderStrava, "Checked", Convert.ToBoolean(loadDbSetting("checkStrava","False")));
			SetControlPropertyThreadSafe(cbkProviderEndomondo, "Checked", Convert.ToBoolean(loadDbSetting("checkEndomondo","False")));
			SetControlPropertyThreadSafe(cbkProviderGarmin, "Checked", Convert.ToBoolean(loadDbSetting("checkGarmin","False")));
			SetControlPropertyThreadSafe(cbkProviderRideWithGps, "Checked", Convert.ToBoolean(loadDbSetting("checkRideWithGps","False")));
		}
		
		
		
		void loadUserSettings()
		{
			_autopause = Convert.ToInt32(loadDbSetting("autopause","0"));
			SetControlPropertyThreadSafe(txtAutoPauseThreshold, "Text", _autopause.ToString());
		}
		
		void checkForGUID()
		{
			_GUID = loadDbSetting("GUID","");
			
			if(_GUID == ""){
				_GUID = Guid.NewGuid().ToString();
				saveDbSetting("GUID",_GUID);
			}
		}
		
		void checkForEndomondoDetails()
		{
			_endomondo_authToken = loadDbSetting("endomondo_authToken","");
			_endomondo_displayName = loadDbSetting("endomondo_displayName","");
			_endomondo_userId = loadDbSetting("endomondo_userId","");
			_endomondo_secureToken = loadDbSetting("endomondo_secureToken","");
			
			if(_endomondo_authToken != ""){
				EnableMenuItem(menuConnectToEndomondo, false);
				EnableMenuItem(menuViewAccountEndomondo, true);
			}
		}
		
		void checkForGarminConnectDetails()
		{
			try{
				_gc_user = loadDbSetting("gc_user","");
				_gc_password = loadDbSetting("gc_password","");
				if(_gc_user != "" && _gc_password != "" ){
					if((new GarminConnectAPI()).Login(_gc_user, _gc_password)){
						// enable the view account button
						EnableMenuItem(menuConnectToGarmin, false);
						EnableMenuItem(menuViewAccountGarmin, true);
					}
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
			_ridewithgps_email = loadDbSetting("ridewithgps_email","");
			_ridewithgps_password = loadDbSetting("ridewithgps_password","");
			
			                                   
			try{
				if(_ridewithgps_email != "" && _ridewithgps_password != ""){
					_rwgps = new RideWithGpsAPI();
					if(_rwgps.login(_ridewithgps_email, _ridewithgps_password)){
						EnableMenuItem(menuConnectToRideWithGps, false);
						EnableMenuItem(menuViewAccountRideWithGps, true);
						_ridewithgps_token = _rwgps.getAuthToken();
					}
				}
				else{
					EnableMenuItem(menuConnectToRideWithGps, true);
					EnableMenuItem(menuViewAccountRideWithGps, false);
				}
			}
			catch{}
		}
		
		void checkForStravaConnectToken()
		{
			
			_strava_token = loadDbSetting("strava_token","");
			_strava_name = loadDbSetting("strava_name","");
			_strava_user_id = Convert.ToInt32(loadDbSetting("strava_user_id","0"));
			_strava_username = loadDbSetting("strava_username","");
			_strava_password = loadDbSetting("strava_password","");
			
			if(_strava_token != ""){
				// enable the view account button
				EnableMenuItem(menuConnectToStrava, false);
				EnableMenuItem(menuViewAccountStrava, true);
			}
		}
		
		void checkForRunkeeperConnectToken()
		{
			_rk_auth_token = loadDbSetting("rk_auth_token","");

			if(_rk_auth_token == ""){
				EnableMenuItem(menuConnectToRunkeeper, true);
				EnableMenuItem(menuViewAccountRunKeeper, false);
			}
			else{
				EnableMenuItem(menuConnectToRunkeeper, false);
				EnableMenuItem(menuViewAccountRunKeeper, true);
			}
		}
		
		void saveRunkeeperToken(string token)
		{
			saveDbSetting("rk_auth_token",token);
		}
		
		void menuViewAccountRunKeeperClick(object sender, EventArgs e)
		{
			ViewerRunKeeper vrk = new ViewerRunKeeper(_client_id, _client_secret, _client_uri, _rk_auth_token);
			vrk.ShowDialog();
		}
		
		void MenuConnectToRunkeeperClick(object sender, EventArgs e)
		{
			RunkeeperConnect rk_connect = new RunkeeperConnect();
			rk_connect.ShowDialog();
			saveRunkeeperToken(rk_connect.rk_auth_token);
			checkForRunkeeperConnectToken();
		}
		
		void MenuConnectToStravaClick(object sender, EventArgs e)
		{
			StravaConnect sc = new StravaConnect();
			if(sc.ShowDialog() == DialogResult.OK){
				EnableMenuItem(menuConnectToStrava, false);
				EnableMenuItem(menuViewAccountStrava, true);
				_strava_token = sc._token;
				_strava_name = sc._name;
				_strava_username = sc._email;
				_strava_password = sc._password;
				_strava_user_id = sc._user_id;
				saveDbSetting("strava_token", _strava_token);
				saveDbSetting("strava_name", _strava_name);
				saveDbSetting("strava_username", _strava_username);
				saveDbSetting("strava_password", _strava_password);
				saveDbSetting("strava_user_id", _strava_user_id.ToString());
			}
		}
		
		void MenuConnectToGarminClick(object sender, EventArgs e)
		{
			GarminConnect gc = new GarminConnect();
			if(gc.ShowDialog() == DialogResult.OK){
				EnableMenuItem(menuConnectToGarmin, false);
				EnableMenuItem(menuViewAccountGarmin, true);
				EnableMenuItem(menuUploadToGarminConnect, true);
				_gc_user = gc._gc_user;
				_gc_password = gc._gc_password;
				saveDbSetting("gc_user", _gc_user);
				saveDbSetting("gc_password", _gc_password);
			}
		}
		
		void menuViewAccountGarminClick(object sender, EventArgs e)
		{
			ViewerGarmin vg = new ViewerGarmin(_gc_user, _gc_password);
			vg.ShowDialog();
		}
		
		void menuViewAccountStravaClick(object sender, EventArgs e)
		{
			ViewerStrava vs = new ViewerStrava(_strava_token, _strava_name, _strava_user_id);
			vs.ShowDialog();
		}
		
		void menuUploadToStravaClick(object sender, EventArgs e)
		{
			try{
				if(_threadUpload.IsAlive){
					_threadUpload.Abort();
				}
			}catch{}
			
			_threadUpload = new Thread(new ThreadStart(this.uploadRideToStrava));
			_threadUpload.Start();
		}
		
		void BtnGenerateTcxFromTrackpointsClick(object sender, EventArgs e)
		{
			string tcx = TrackPointsToTcx();
		}
		
		string TrackPointsToTcx()
		{
			// simulate a Garmin Training Centre formatted TCX V2 file
			string tcx_body = "";
			string tcx_header = ""+
				"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>"+
				"<TrainingCenterDatabase xmlns=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2 http://www.garmin.com/xmlschemas/ActivityExtensionv2.xsd http://www.garmin.com/xmlschemas/FatCalories/v1 http://www.garmin.com/xmlschemas/fatcalorieextensionv1.xsd http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2 http://www.garmin.com/xmlschemas/TrainingCenterDatabasev2.xsd\">"+
				"<Activities>"+
				"<Activity Sport=\"Biking\">"+
				"<Id>" + GetListViewItemValue(lstTrackpoints,0,0) + "</Id>"+
				"<Name>" + System.DateTime.Now.ToString("dd/MM/yyyy") + " - " + txtActivityName.Text + "</Name>"+
				"<Lap StartTime=\"" + GetListViewItemValue(lstTrackpoints,0,0) + "\">";
			
			string tcx_footer = ""+
				"</Lap>"+
				"<Creator xsi:type=\"Device_t\">"+
				"<Name>CycleUploader TCX Generator</Name>"+
        		//"<UnitId>3839235642</UnitId>"+
        		//"<ProductID>1036</ProductID>"+
        		//"<Version>"+
				//"<VersionMajor>2</VersionMajor>"+
				//"<VersionMinor>80</VersionMinor>"+
				//"<BuildMajor>0</BuildMajor>"+
				//"<BuildMinor>0</BuildMinor>"+
				//"</Version>"+
				"</Creator>"+
				"</Activity></Activities>";
				
			string previous_pause_val = "pause";
			for(int t = 0; t < lstTrackpoints.Items.Count; t++){
				// if "IsPaused" column is "" then start a new Track section
				if(GetListViewItemValue(lstTrackpoints,t,10) != previous_pause_val){
					if(GetListViewItemValue(lstTrackpoints,t,10) == ""){
						tcx_body += "<Track>";
					}
					else{
						tcx_body += "</Track>";
					}
					previous_pause_val = GetListViewItemValue(lstTrackpoints,t,10);
				}
				
				// Add <TrackPoint> for current list item if we're not paused
				//if(GetListViewItemValue(lstTrackpoints,t,10) == "" && GetListViewItemValue(lstTrackpoints,t,8) != "0" && GetListViewItemValue(lstTrackpoints,t,7) != "0"){
				if(GetListViewItemValue(lstTrackpoints,t,10) == ""){
					// Add standard stuff to the trackpoint tag
					bool bIncludeHeartStream = true;
					bool bIncludeCadenceStream = true;
					
					string trkpt = ""+
						"<Trackpoint>"+
						"<Time>" + GetListViewItemValue(lstTrackpoints,t,0) + "</Time>";
					// only add the position if the GPS coordinates are available
					if(GetListViewItemValue(lstTrackpoints,t,8) != "0" && GetListViewItemValue(lstTrackpoints,t,7) != "0"){
						trkpt += "<Position><LatitudeDegrees>" + GetListViewItemValue(lstTrackpoints,t,8) + "</LatitudeDegrees><LongitudeDegrees>" + GetListViewItemValue(lstTrackpoints,t,7) + "</LongitudeDegrees></Position>";
					}
					trkpt += "<AltitudeMeters>" + (Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2))/3.2808399).ToString() + "</AltitudeMeters>"+
						"<DistanceMeters>" + GetListViewItemValue(lstTrackpoints,t,3) + "</DistanceMeters>";
					if(bIncludeHeartStream){
						trkpt += "<HeartRateBpm xsi:type=\"HeartRateInBeatsPerMinute_t\"><Value>" + GetListViewItemValue(lstTrackpoints,t,4) + "</Value></HeartRateBpm>";
					}
					if(bIncludeCadenceStream){
						trkpt += "<Cadence>" + GetListViewItemValue(lstTrackpoints,t,5) + "</Cadence>";
					}
					trkpt += "<Extensions><TPX xmlns=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\" CadenceSensor=\"Bike\"><Speed>" + GetListViewItemValue(lstTrackpoints,t,6) + "</Speed></TPX></Extensions>";
					trkpt += "</Trackpoint>";
		            tcx_body += "\r\n" + trkpt;
				}
				
				
				
			}
			// make sure to close the "Track" if we last opened one
			if(previous_pause_val == ""){
				tcx_body += "</Track>";
			}
			
			return (tcx_header + tcx_body + tcx_footer);

		}
		
		void menuUploadToGarminConnectClick(object sender, EventArgs e)
		{
			try{
				if(_threadUpload.IsAlive){
					_threadUpload.Abort();
				}
			}
			catch{}
			
			_threadUpload = new Thread(new ThreadStart(this.uploadRideToGarminConnect));
			_threadUpload.Start();
		}
		
		void uploadRideToGarminConnect()
		{
			setUpdateRideMsg("garmin","");
			setUpdateRideId("garmin","-");
			setUpdateRideImg("garmin",null);
			if(!_bIsBatchProcessing){
				setActiveTabPage("tabUploadStatus");
			}
			if(_bIsBatchProcessing){
				_activityBatch.setUploadStatus("garmin","inprogress");
			}
			setUpdateRideMsg("garmin","Authenticating User");
			if(_bIsBatchProcessing){
				_activityBatch.setUploadProgressStatus("Garmin: Authenticating User");
			}
			if(!_gc.Login(_gc_user, _gc_password)){
				setUpdateRideMsg("garmin","Login Failed");
				if(_bIsBatchProcessing){
					_activityBatch.setUploadStatus("garmin","login failed");
					_activityBatch.setUploadProgressStatus("Garmin: Login Failed");
				}
			}
			else{
				setUpdateRideMsg("garmin","Preparing Activity For Upload");
				if(_bIsBatchProcessing){
					_activityBatch.setUploadProgressStatus("Garmin: Preparing Activity for Upload");
				}
				_gc.UploadFile(_activity_file_name, txtActivityName.Text, _m_dbConnection, _dbFileId, txtActivityName.Text, txtActivityNotes.Text, _activityBatch);
			}
		}
		
		void setActiveTabPage(string tabpage)
		{
			setTab(tabControlOverview, tabpage);
		}
		
		void setFileHistoryActiveTabPage(string tabpage)
		{
			//setTab(tabControlHistory, tabpage);
		}
		
		void MenuConnectToRideWithGpsClick(object sender, EventArgs e)
		{
			
			if(_rwgps == null){ _rwgps = new RideWithGpsAPI();}
			RideWithGpsConnect rwg = new RideWithGpsConnect(ref _rwgps);
			if(rwg.ShowDialog() == DialogResult.OK){
				
				EnableMenuItem(menuConnectToRideWithGps, false);
				EnableMenuItem(menuViewAccountRideWithGps, true);
				EnableMenuItem(menuUploadToRideWithGps, true);
				
				_ridewithgps_token = _rwgps.getAuthToken();
				_ridewithgps_email = rwg._email;
				_ridewithgps_password = rwg._password;
				saveDbSetting("ridewithgps_email", _ridewithgps_email);
				saveDbSetting("ridewithgps_password", _ridewithgps_password);
			}
		}
		
		void MenuUploadToRideWithGpsClick(object sender, EventArgs e)
		{
			try{
				if(_threadUpload.IsAlive){
					_threadUpload.Abort();
				}
			}
			catch{}
			
			_threadUpload = new Thread(new ThreadStart(this.uploadRideToRideWithGPS));
			_threadUpload.Start();
		}
		
		void uploadRideToRideWithGPS()
		{
			setUpdateRideMsg("ridewithgps","");
			setUpdateRideId("ridewithgps","-");
			setUpdateRideImg("ridewithgps", null);
			if(!_bIsBatchProcessing){
				setActiveTabPage("tabUploadStatus");
			}
			if(_bIsBatchProcessing){
				_activityBatch.setUploadStatus("rwgps","inprogress");
			}
			// if not logged in, attempt to login now.
			if(!_rwgps.isLoggedIn()){
				setUpdateRideMsg("ridewithgps","Authenticating User");
				if(_bIsBatchProcessing){
					_activityBatch.setUploadProgressStatus("RideWithGps: Authenticating User");
				}
				if(!_rwgps.login(_ridewithgps_email, _ridewithgps_password)){
					setUpdateRideMsg("ridewithgps", "Login Failed");
					if(_bIsBatchProcessing){
						_activityBatch.setUploadStatus("rwgps","login failed");
						_activityBatch.setUploadProgressStatus("RideWithGps: Login Failed");
					}
				}
			}
			
			if(_rwgps.isLoggedIn()){
				setUpdateRideMsg("ridewithgps","Preparing Activity For Upload");
				if(_bIsBatchProcessing){
					_activityBatch.setUploadProgressStatus("RideWithGps: Preparing activity for upload");
				}
				
				StringBuilder jsonData = new StringBuilder();
				
				string jsonHeader = string.Format(@"{{""apikey"": ""jnas82ns"", ""email"": ""{0}"", ""password"": ""{1}"", ""trip"": {{""name"":""{2}"", ""description"":""{3}""}}, ""track_points"": ""[",
				                                  _ridewithgps_email, 
				                                  _ridewithgps_password,
				                                  txtActivityName.Text, 
				                                  txtActivityNotes.Text
				                                 );
				jsonData.Append(jsonHeader);
			
				int pt = 0;
				for(int t = 0; t < lstTrackpoints.Items.Count; t++){
					
					// do one action if we're a stationary trainer workout, which don't have lat/lng coordinates so 
					// we need to include any with a "0" value for these
					// if it's a normal workout, we want to strip those out so we don't end up jumping into the middle
					// of the atlantic ;-) lol
					if(cbkIsStationaryTrainer.Checked){
						if(pt > 0){
							jsonData.Append(",");
						}
						string json_point = string.Format(@"{{""x"": {0}, ""y"": {1}, ""t"": {2}, ""e"": {3}, ""p"": {4}, ""c"": {5}, ""h"": {6}}}",
						                                  GetListViewItemValue(lstTrackpoints, t, 7),
						                                  GetListViewItemValue(lstTrackpoints, t, 8),
						                                  GeoMath.DateTimeToUnixTimestamp(System.DateTime.Parse(GetListViewItemValue(lstTrackpoints,t,0),  null, DateTimeStyles.RoundtripKind)),
						                                  Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2))/3.2808399, // Altitude, converted from FT to METRES
						                                  0,
						                                  GetListViewItemValue(lstTrackpoints,t,5),
						                                  GetListViewItemValue(lstTrackpoints,t,4)
						                                  );
						jsonData.Append(json_point.Replace(@"""", @"\"""));
						pt++;
					}
					else{
						if(GetListViewItemValue(lstTrackpoints, t, 8) != "0" && GetListViewItemValue(lstTrackpoints, t, 7) != "0"){
							if(pt > 0){
								jsonData.Append(",");
							}
							string json_point = string.Format(@"{{""x"": {0}, ""y"": {1}, ""t"": {2}, ""e"": {3}, ""p"": {4}, ""c"": {5}, ""h"": {6}}}",
							                                  GetListViewItemValue(lstTrackpoints, t, 7),
							                                  GetListViewItemValue(lstTrackpoints, t, 8),
							                                  GeoMath.DateTimeToUnixTimestamp(System.DateTime.Parse(GetListViewItemValue(lstTrackpoints,t,0),  null, DateTimeStyles.RoundtripKind)),
							                                  Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2))/3.2808399, // Altitude, converted from FT to METRES
							                                  0,
							                                  GetListViewItemValue(lstTrackpoints,t,5),
							                                  GetListViewItemValue(lstTrackpoints,t,4)
							                                  );
							jsonData.Append(json_point.Replace(@"""", @"\"""));
							pt++;
						}
					}
				}
				
				string jsonFooter = @"]""}";
				
				jsonData.Append(jsonFooter);
				
				setUpdateRideMsg("ridewithgps","Uploading, waiting for response");
				
				if(_bIsBatchProcessing){
					_activityBatch.setUploadProgressStatus("RideWithGps: Uploading activity, waiting for response");
				}
				
				Debug.WriteLine(jsonData);
				_rwgps.upload_activity_json(ref jsonData, _m_dbConnection, _dbFileId, txtActivityName.Text, txtActivityNotes.Text, _activityBatch);
				
			}
		}
		
		
		void BtnUploadAllProvidersClick(object sender, EventArgs e)
		{
			try{
				if(_threadUpload.IsAlive){
					_threadUpload.Abort();
				}
			}catch{}
			_threadUpload = new Thread(new ThreadStart(this.uploadToAllProviders));
			_threadUpload.Start();
		}
		
		void uploadToAllProviders()
		{
			SetControlPropertyThreadSafe(btnUploadAllProviders, "Enabled", false);
			
			setUpdateRideMsg("garmin","");
			setUpdateRideId("garmin","-");
			setUpdateRideImg("garmin",null);		
			//
			setUpdateRideMsg("strava","");
			setUpdateRideId("strava","-");
			setUpdateRideImg("strava",null);
			//
			setUpdateRideMsg("runkeeper","");
			setUpdateRideId("runkeeper","-");
			setUpdateRideImg("runkeeper",null);
			//
			setUpdateRideMsg("ridewithgps","");
			setUpdateRideId("ridewithgps","-");
			setUpdateRideImg("ridewithgps",null);
			//
			if(!_bIsBatchProcessing){
				setTab(tabControlOverview, "tabUploadStatus");
			}
			
			if(cbkProviderRunkeeper.Checked){
				uploadRideToRunKeeper();
			}
			else{
				setUpdateRideMsg("runkeeper","Skipped, provider not active");
			}
			if(cbkProviderStrava.Checked){
				uploadRideToStrava();
			}
			else{
				setUpdateRideMsg("strava","Skipped, provider not active");
			}
			if(cbkProviderGarmin.Checked){
				uploadRideToGarminConnect();
			}
			else{
				setUpdateRideMsg("garmin","Skipped, provider not active");
			}
			if(cbkProviderRideWithGps.Checked){
				uploadRideToRideWithGPS();
			}
			else{
				setUpdateRideMsg("ridewithgps","Skipped, provider not active");
			}
			
			if(!_bIsBatchProcessing){
				loadFileHistory();
			}
			SetControlPropertyThreadSafe(btnUploadAllProviders, "Enabled", true);
		}
			
		void linkRideIdClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//string wUrl = string.Format("http://app.strava.com/activities/{0}", e.Link.LinkData.ToString());
			//Process.Start(wUrl);
		}
		
		void MenuConnectToEndomondoClick(object sender, EventArgs e)
		{
			
 			EndomondoConnect endo = new EndomondoConnect(_GUID);
			if(endo.ShowDialog() == DialogResult.OK){
				menuConnectToEndomondo.Enabled = false;
				menuViewAccountEndomondo.Enabled = true;
				_endomondo_authToken = endo.endo._authToken;
				_endomondo_secureToken = endo.endo._secureToken;
				_endomondo_displayName = endo.endo._displayName;
				_endomondo_userId = endo.endo._userId;
			}
			
		}
		
		void MenuViewAccountEndomondoClick(object sender, EventArgs e)
		{
			ViewerEndomondo endo = new ViewerEndomondo(_endomondo_authToken, _endomondo_secureToken, _endomondo_displayName, _endomondo_userId);
			endo.ShowDialog();			
		}
		
		
		void CbkProviderRunkeeperCheckedChanged(object sender, EventArgs e)
		{
			menuProviderRunkeeper.Enabled = ((CheckBox)sender).Checked;
		}
		
		void CbkProviderStravaCheckedChanged(object sender, EventArgs e)
		{
			menuProviderStrava.Enabled = ((CheckBox)sender).Checked;
		}
		
		void CbkProviderEndomondoCheckedChanged(object sender, EventArgs e)
		{
			menuProviderEndomondo.Enabled = ((CheckBox)sender).Checked;
		}
		
		void CbkProviderGarminCheckedChanged(object sender, EventArgs e)
		{	
			menuProviderGarmin.Enabled = ((CheckBox)sender).Checked;
		}
		
		void CbkProviderRideWithGpsCheckedChanged(object sender, EventArgs e)
		{
			menuProviderRideWithGps.Enabled = ((CheckBox)sender).Checked;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			// try and stop the check for update process in a threadsafe manor
			try{
				if(this.InvokeRequired){
					this.Invoke((MethodInvoker)delegate{
					            	this.checkForUpdate.StopThread();
					            });
				}
				else{
					this.checkForUpdate.StopThread();
				}
				
			}
			catch{}
			
			// cancel closing of the application if a file is being processed 
			// as we need that to complete for the database to be in a consistent state
			// i.e. all track points archived etc.
			if(_threadProcessFile != null && _threadProcessFile.IsAlive){
				MessageBox.Show("Close is disabled as a file is currently being processed.");
				e.Cancel = true;
			}
			else{
				// try and save the provider enabled settings to the registry so they are preserved
				// on next run of the application
				try{
					saveDbSetting("checkRunkeeper", cbkProviderRunkeeper.Checked.ToString());
					saveDbSetting("checkStrava", cbkProviderStrava.Checked.ToString());
					saveDbSetting("checkGarmin", cbkProviderGarmin.Checked.ToString());
					saveDbSetting("checkRideWithGps", cbkProviderRideWithGps.Checked.ToString());
					
				}
				catch(Exception ex){
					//MessageBox.Show(ex.ToString());
				}
				
				// check to see if the init thread is active, if it is abort it gracefully (ish)
				try{
					if(_threadInit != null && _threadInit.IsAlive){
						_threadInit.Abort();
					}
				}
				catch(Exception ex){
					MessageBox.Show(ex.ToString());
				}
			}
		}
		
		void MenuAboutClick(object sender, EventArgs e)
		{
			About abt = new About(_versionStr, _versionDate, _versionAuthor);
			abt.ShowDialog();
		}
		
		void MenuViewAccountRideWithGpsClick(object sender, EventArgs e)
		{
			ViewerRideWithGps rwgps = new ViewerRideWithGps(_ridewithgps_email, _ridewithgps_password);
			rwgps.ShowDialog();
			
		}
		
		void LstFileHistoryDoubleClick(object sender, EventArgs e)
		{
			
			if(lstFileHistory.SelectedItems.Count > 0){
				
				CycleUploader.FileSummary summary = new CycleUploader.FileSummary(
					Convert.ToInt32(lstFileHistory.SelectedItems[0].Text),
					_m_dbConnection
				);
				summary.ShowDialog();
			}
		}
		
	
		void BtnFullscreenHistoryMapClick(object sender, EventArgs e)
		{
			FullscreenMap map = new FullscreenMap(Application.StartupPath + "\\history_route.html");
			map.ShowDialog();
		}
				
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool bCanClose = true;
			if(_threadInit.IsAlive){ _threadInit.Abort();}
			if(_threadProcessFile != null && _threadProcessFile.IsAlive){ 
				bCanClose = false;
				MessageBox.Show("Cannot close application at this time as a file is currently being processed.");
			}
			if(_threadUpload != null && _threadUpload.IsAlive){
				bCanClose = false;
				MessageBox.Show("Cannot close application at this time as a file is currently being uploaded.");
			}
			
			if(bCanClose){
				this.Close();
			}
		}
		
		void LinkHistoryUploadClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				Process.Start(e.Link.LinkData.ToString());
			}
			catch(Exception ex){
				MessageBox.Show("There was a problem opening the link for the selected activity.\r\n" + e.Link.LinkData.ToString());
			}
		}
		
		
		private void GroupFileHistoryItem(int idx)
		{
		    // This flag will tell us if proper group already exists
		    bool group_exists = false;
		    // Check each group if it fits to the item
		    foreach (ListViewGroup group in lstFileHistory.Groups)
		    {
		        // Compare group's header to selected subitem's text
		        if (group.Header.Contains(System.DateTime.Parse(GetListViewItemValue(lstFileHistory,idx,1)).ToString("yyyy MMMM")))
		        {
		            // Add item to the group.
		            // Alternative is: group.Items.Add(item);
		            SetListViewGroup(lstFileHistory, idx, group);
		            group_exists = true;
		            break;
		        }
		    }
		    // Create new group if no proper group was found
		    if (!group_exists)
		    {
		        // Create group and specify its header by
		        // getting selected subitem's text
		        ListViewGroup group = new ListViewGroup(System.DateTime.Parse(GetListViewItemValue(lstFileHistory,idx,1)).ToString("yyyy MMMM"));
		        // We need to add the group to the ListView first
		        
		        AddListViewGroup(lstFileHistory, group);
		        SetListViewGroup(lstFileHistory, idx, group);
		    }
		}
		
		void MenuOpenBatchClick(object sender, EventArgs e)
		{
			_activityBatch = new Batch(_previous_file_path, 
			                           this,
			                           cbkProviderRunkeeper.Checked,
			                           cbkProviderStrava.Checked,
			                           cbkProviderGarmin.Checked,
			                           cbkProviderRideWithGps.Checked,
			                           new List<string>()
			                          );
			_activityBatch.ShowDialog();
		}
		
		// called from batch process
		public void openSelectedFile(int batchItemRowIdx, string filename, string activityName, string activityNotes, bool isCommute, bool isStationaryTrainer, int courseId = 0)
		{
			_opened_file = filename;
			SetControlPropertyThreadSafe(txtActivityName, "Text", activityName);
			SetControlPropertyThreadSafe(txtActivityNotes, "Text", activityNotes);
			SetControlPropertyThreadSafe(cbkIsCommute, "Checked", isCommute);
			SetControlPropertyThreadSafe(cbkIsStationaryTrainer ,"Checked", isStationaryTrainer);
			_activityBatchRowIdx = batchItemRowIdx;
			_bIsBatchProcessing = true;
			_fileSummary = new FileSummary();
			_threadProcessFile = new Thread(new ThreadStart(this.processSelectedFile));
			_threadProcessFile.Start();
		}
		
		public void processOpenedFile()
		{
			if(_bIsBatchProcessing){
				setActiveTabPage("tabFileHistory");
				setFileHistoryActiveTabPage("tabFiles");
			}
			uploadToAllProviders();
			if(_bIsBatchProcessing){
				_activityBatch.responseFileProcessed();
			}
		}
		public void setEndOfBatch()
		{
			_bIsBatchProcessing = false;
			loadFileHistory();
		}
		
		void MenuToolsOptionsClick(object sender, EventArgs e)
		{
			ToolsOptions usersettings = new ToolsOptions(_autopause, _m_dbConnection);
			
			// show the user settings and apply and changes if the user has selected anything different
			if(usersettings.ShowDialog() == DialogResult.OK)
			{
				_autopause = usersettings._autopause;
				SetControlPropertyThreadSafe(txtAutoPauseThreshold, "Text", _autopause.ToString());
				saveDbSetting("autopause",_autopause.ToString());
			}
		}
		
		void MenuAnalysisRecordsClick(object sender, EventArgs e)
		{
			UserRecords records = new UserRecords(_m_dbConnection);
			records.ShowDialog();
		}
		
		void MenuAnalysisMonthlyStatsClick(object sender, EventArgs e)
		{
			UserMonthlyStats monthlystats = new UserMonthlyStats(_m_dbConnection);
			monthlystats.ShowDialog();
		}
		
		public void SetProviderState(string name, bool checked_state)
		{
			switch(name){
				case "Runkeeper":
					cbkProviderRunkeeper.Checked = checked_state;
					break;
				case "Strava":
					cbkProviderStrava.Checked = checked_state;
					break;
				case "Garmin":
					cbkProviderGarmin.Checked = checked_state;
					break;
				case "RWGPS":
					cbkProviderRideWithGps.Checked = checked_state;
					break;
			}
		}
		
		void MenuAnalysisChartsClick(object sender, EventArgs e)
		{
			UserCharts uc = new UserCharts(_m_dbConnection);
			uc.ShowDialog();
		}
		
		
		
		//
		//
		//
		//
		//
		// NEW 
		//
		//
		
		void MenuFileHistoryEditActivityClick(object sender, EventArgs e)
		{
			if(lstFileHistory.SelectedItems.Count > 0){
				ActivityName actName = new ActivityName(
					lstFileHistory.SelectedItems[0].SubItems[2].Text,			// activity name
					lstFileHistory.SelectedItems[0].SubItems[11].Text,			// activity notes
					lstFileHistory.SelectedItems[0].SubItems[7].Text == "Y",	// activity is commute
					lstFileHistory.SelectedItems[0].SubItems[8].Text == "Y",	// activity is stationary trainer
					_m_dbConnection,
					true,
					lstFileHistory.SelectedItems[0].SubItems[9].Text == "" ? 0 : Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[9].Text) // activity course
				);
				// if OK, set the activity name in the database
				if(actName.ShowDialog() == DialogResult.OK){
					// get the id of the file selected
					int fileId = Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text);
					string sql = string.Format("update File set fileActivityName = \"{0}\", fileActivityNotes = \"{2}\", fileIsCommute = {3}, fileIsStationaryTrainer = {4}, fileIsIncludedInStats = {5}, idCourse = {6} where idFile = {1}",
					                           actName._activityName,
					                           fileId,
					                           actName._activityNotes,
					                           actName._activityIsCommute ? 1 : 0,
					                           actName._activityIsStationaryTrainer ? 1 : 0,
					                           actName._activityIsIncludedInStatistics ? 1 : 0,
					                           actName.courseId
					                          );
					SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
					command.CommandText = sql;
					int index = lstFileHistory.SelectedItems[0].Index;
					command.ExecuteNonQuery();
					//loadFileHistory();
					lstFileHistory.Items[index].SubItems[2].Text = actName._activityName;
					lstFileHistory.Items[index].SubItems[9].Text = actName._activityNotes;
					lstFileHistory.Items[index].SubItems[7].Text = actName._activityIsCommute ? "Y" : "";
					lstFileHistory.Items[index].SubItems[8].Text = actName._activityIsStationaryTrainer ? "Y" : "";				
					lstFileHistory.Items[index].SubItems[9].Text = actName.courseId.ToString();
					lstFileHistory.Items[index].SubItems[10].Text = actName.courseName;
					ResizeListView(lstFileHistory);
					SetListViewColumnWidth(lstFileHistory,9,0);
				}
			}
			else{
				MessageBox.Show("No Activity Selected");
			}
		}
		
		void MenuFileHistoryDeleteActivityClick(object sender, EventArgs e)
		{
			if(lstFileHistory.SelectedItems.Count > 0){
				string activityName = lstFileHistory.SelectedItems[0].SubItems[2].Text;
				string activityDate = System.DateTime.Parse(lstFileHistory.SelectedItems[0].SubItems[1].Text).ToString("dd MMMM yyyy 'at' HH:mm");
				int fileId = Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text);
				
				if(MessageBox.Show("Are you sure you want to delete activity `"+activityName+"` ridden on "+activityDate+" ?", "Confirm Deletion of Activity...",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
					string sql = string.Format(@"delete from FileTrackpoints where idFile = {0}", fileId);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					sql = string.Format(@"delete from FileSummary where idFile = {0}", fileId);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					sql = string.Format(@"delete from File where idFile = {0}", fileId);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					lstFileHistory.Items.Remove(lstFileHistory.SelectedItems[0]);
				}
			}
			else{
				MessageBox.Show("No Activity Selected");
			}
		}
		
		void MenuFileHistoryCreateCourseClick(object sender, EventArgs e)
		{
			if(lstFileHistory.SelectedItems.Count > 0){
				CourseCreate cc = new CourseCreate(
					Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text),
					lstFileHistory.SelectedItems[0].SubItems[2].Text,
					lstFileHistory.SelectedItems[0].SubItems[1].Text,
					lstFileHistory.SelectedItems[0].SubItems[4].Text,
					_m_dbConnection
				);
				if(cc.ShowDialog() == DialogResult.OK){
					// apply the course id and name to the FileHistory list to save us having to reload it
					SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
					cmd.CommandText = string.Format("update File set idCourse = {0} where idFile = {1}", cc._courseId, Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text));
					cmd.ExecuteNonQuery();
					lstFileHistory.SelectedItems[0].SubItems[9].Text = cc._courseId.ToString();
					lstFileHistory.SelectedItems[0].SubItems[10].Text = cc._courseName;
					ResizeListView(lstFileHistory);
					lstFileHistory.Columns[9].Width = 0;
				}
			}
			else{
				MessageBox.Show("No Activity Selected");
			}
		}
		
		void MenuCoursesCourseListClick(object sender, EventArgs e)
		{
			Courses c = new Courses(_m_dbConnection, this);
			c.ShowDialog();
		}
		
		void MenuHelpCheckForUpdatesClick(object sender, EventArgs e)
		{
			this.bIsAutomaticUpdate = false;
			this.checkForUpdate.OnCheckForUpdate();
		}
		
		void MenuToolsGarminSettingsViewerClick(object sender, EventArgs e)
		{
			showGarminSettings();
		}
		
		void showGarminSettings()
		{
			_gs = new GarminSettings(_m_dbConnection);
			// show dialog and check if the result is YES, as this indicates that the user selected
			// to batch process the unprocessed files on the device
			if(_gs.ShowDialog(this) == DialogResult.Yes){
				if(_gs.unprocessedFiles.Count > 0){
					_activityBatch = new Batch(_previous_file_path, 
				                           this,
				                           cbkProviderRunkeeper.Checked,
				                           cbkProviderStrava.Checked,
				                           cbkProviderGarmin.Checked,
				                           cbkProviderRideWithGps.Checked,
				                           _gs.unprocessedFiles
				                          );
					_activityBatch.ShowDialog();
				}
			}
			_gs.Visible = false;
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			if(bSplashShown && bGarminDetected){
				showGarminSettings();
			}
		}
		
		void MenuAnalysisWeeklyStatsClick(object sender, EventArgs e)
		{
			UserWeeklyStats weeklystats = new UserWeeklyStats(_m_dbConnection);
			weeklystats.ShowDialog();
		}
	}
}
