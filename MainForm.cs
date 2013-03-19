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
using Stravan;
using Stravan.Json;
using System.Net;
using EmpyrealNight.Core.Json;
using System.Threading;
using System.Reflection;
using ListViewNF;
using System.Data.SQLite;

namespace TCX_Parser
{

	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		double avgHeart;
		double avgCadence;
		double avgSpeed;
		//double avgPower;
		
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
		
		string _previous_file_path = "";
		
		TCX_Parser.Activity activity;
		
		RideWithGpsAPI _rwgps;
		GarminConnectAPI _gc;
		
		Thread _threadInit;
		Thread _threadUpload;
		Thread _threadProcessFile;
		
		private string _versionStr;
		private string _versionDate;
		private string _versionAuthor;
		private string _opened_file;
		
		// SQLite Database Connection
		private SQLiteConnection _m_dbConnection;
		// SQLite last `file` record id - audits history of files opened
		// All trackpoints are saved against each file record. This allows us to easily reload the data from our archive without the need 
		// to have access to the original file (TODO: Check data usage for this feature).
		private int _dbFileId;
		
		public class StravaResponse
		{
			public string id;
			public string upload_id;
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
				menuOpenFile.Enabled = Convert.ToBoolean(value);
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
		
		public MainForm(string versionStr, string versionDate, string versionAuthor)
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
			
			openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			
			// Altitude Graph Setup
			zedAltitude.GraphPane.Legend.IsVisible = false;
			zedAltitude.GraphPane.Title.Text = "Altitude";
			zedAltitude.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedAltitude.GraphPane.YAxis.Title.Text = "Feet";
			// Speed Graph Setup
			zedSpeed.GraphPane.Legend.IsVisible = false;
			zedSpeed.GraphPane.Title.Text = "Speed";
			zedSpeed.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedSpeed.GraphPane.YAxis.Title.Text = "mph";
			// Heart Graph Setup
			zedHeart.GraphPane.Legend.IsVisible = false;
			zedHeart.GraphPane.Title.Text = "Heart-Rate";
			zedHeart.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedHeart.GraphPane.YAxis.Title.Text = "bpm";
			// Cadence Graph Setup
			zedCadence.GraphPane.Legend.IsVisible = false;
			zedCadence.GraphPane.Title.Text = "Cadence";
			zedCadence.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedCadence.GraphPane.YAxis.Title.Text = "rpm";
			// Temperature Graph Setup
			zedTemperature.GraphPane.Legend.IsVisible = false;
			zedTemperature.GraphPane.Title.Text = "Temperature";
			zedTemperature.GraphPane.XAxis.Title.Text = "Distance (miles)";
			zedTemperature.GraphPane.YAxis.Title.Text = "�C";
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
		}
		
		void BtnOpenFileClick(object sender, EventArgs e)
		{
			if(_previous_file_path == ""){
				_previous_file_path = Environment.SpecialFolder.Personal.ToString();
			}
			openFile.Filter = "FIT File (*.fit)|*.fit|Garmin Training Center Database Files (*.tcx)|*.tcx|GPX Files (*.gpx)|*.gpx";
			openFile.Title = "Please select activity data file to view.";
			openFile.InitialDirectory = _previous_file_path;
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				_opened_file = openFile.FileName;
				_threadProcessFile = new Thread(new ThreadStart(this.processSelectedFile));
				_threadProcessFile.Start();
			}
		}
		
		void processSelectedFile()
		{
			string filename = _opened_file;
			
			// de-activate the file-open menu item
			SetMenuStatusThreadSafe(menubar, "Enabled", false);
			
			// add the file record to our File log in cycleuploader sqllite database
			string sql = string.Format("insert into File(fileType, fileName, filePath, fileOpenDateTime) values (\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
			                           Path.GetExtension(filename).ToLower(),
			                           Path.GetFileName(filename),
			                           Path.GetDirectoryName(filename),
			                           System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
			                          );
			SQLiteCommand command = new SQLiteCommand(sql, _m_dbConnection);
			command.ExecuteNonQuery();				                           
			
			// retrieve the ID of the `file` from the database as we will need this later to 
			// store the trackpoints once we've processed the file contents
			sql = @"select last_insert_rowid()";
			command.CommandText = sql;
			_dbFileId = Convert.ToInt32(command.ExecuteScalar());
			
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
			
			// save trackpoints to database
			dbSaveTrackpoints();
			
			// save file summary information
			dbSaveSummary(_dbFileId);
			
			// refresh the FileHistory list
			loadFileHistory();
			
			SetMenuStatusThreadSafe(menubar, "Enabled", true);
		}
		
		void dbSaveSummary(int fileId)
		{
			SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
			string sql = string.Format("insert into FileSummary(idFile, fsDuration, fsDistance, fsCalories, fsAvgHeart, fsAvgCadence, fsAvgSpeed, fsMovingTime, fsTotalAscent, fsTotalDescent, fsMaxHeartRate, fsMaxCadence, fsMaxSpeed) "+
			                           "VALUES ("+
			                           "  {0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\", \"{12}\" "+
			                           ")",
			                           fileId,
			                           lblDuration.Text,
			                           lblDistance.Text, 
			                           lblCalories.Text,
			                           lblAvgHeartRate.Text, 
			                           lblCalories.Text,
			                           lblAvgSpeed.Text,
			                           lblMovingTime.Text,
			                           lblTotalAscent.Text,
			                           lblTotalDescent.Text,
			                           lblMaxHeartRate.Text,
			                           lblMaxCadence.Text,
			                           lblMaxSpeed.Text
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
			SQLiteCommand command = new SQLiteCommand("begin", _m_dbConnection);
			command.ExecuteNonQuery();
			for(int tp = 0; tp < lstTrackpoints.Items.Count; tp++){
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
				command.ExecuteNonQuery();
				SetStatusProgressThreadSafe(statusBar, "Value", tp);
				SetStatusTextThreadSafe(statusBar, string.Format("Archiving file information ... Data Point {0} of {1}", tp+1, lstTrackpoints.Items.Count));
			}
			command.CommandText = "end";
			command.ExecuteNonQuery();
			SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			SetStatusTextThreadSafe(statusBar, "Done.");
			
		}
		
		void processFile_FIT(string filename)
		{
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
			Process_TrackPoints();
			
		}
		
		void uploadRideToStrava()
		{
			setUpdateRideMsg("strava","");
			setUpdateRideId("strava","-");
			setUpdateRideImg("ridewithgps",null);
			setActiveTabPage("tabUploadStatus");
			
			StravaWebClient swc = new StravaWebClient();
			AuthenticationService auth = new AuthenticationService(swc);

			setUpdateRideMsg("strava", "Authenticating User Credentials");
			AuthenticationV2 authV2 = auth.LoginV2(_strava_username, _strava_password);
			
			NameValueCollection nameValuePairs = new NameValueCollection();
			
			nameValuePairs.Add("token", authV2.Token);
			nameValuePairs.Add("type", "tcx"); //_activity_file_type);
			nameValuePairs.Add(System.Web.HttpUtility.UrlEncode("activity_type"), "ride");
			nameValuePairs.Add(System.Web.HttpUtility.UrlEncode("activity_name"), System.Web.HttpUtility.UrlEncode(txtActivityName.Text));
			
			setUpdateRideMsg("strava", "Preparing Activity Information For Upload");
			
			string tcx = TrackPointsToTcx();
			
			nameValuePairs.Add("data", tcx);
			
			setUpdateRideMsg("strava", "Uploading, waiting for a response");
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
				string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadStrava = \"{0}\" where idFile = {1}", 
				                           string.Format("http://app.strava.com/activities/{0}",strava_id), 
				                           _dbFileId,
				                           txtActivityName.Text, 
				                           txtActivityNotes.Text
				                          );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
    			setUpdateRideImg("strava",Image.FromFile("success-icon.png"));
    		}
    		catch(Exception ex){
    			setUpdateRideMsg("strava", "Error processing response. " + ex.ToString());
    			setUpdateRideImg("strava",Image.FromFile("failure-icon.png"));
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
				
				// only add the point if it has coordinates.
				if(lng != "" && lat != "" && lng != "0" && lat != "0"){
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
								break;
							case "AvgCadence":
								SetControlPropertyThreadSafe(lblCadence, "Text", string.Format("{0:0} rpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								avgCadence = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								activity._avgCadence = avgCadence;
								break;
							case "AvgHeartRate":
								SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", string.Format("{0:0} bpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								avgHeart = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								activity._avgHeartRate = avgHeart;
								break;
							case "TotalCalories":
								SetControlPropertyThreadSafe(lblCalories, "Text", string.Format("{0:0}",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._calories = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalDistance":
								SetControlPropertyThreadSafe(lblDistance, "Text", string.Format("{0:0.0}", (Convert.ToDouble(e.mesg.fields[i].GetValue(j))/1000)*0.621371192) + " miles");
								activity._distance = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalElapsedTime":
								TimeSpan tme = TimeSpan.FromSeconds(Convert.ToInt32(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tme.Hours, 
					    			tme.Minutes, 
					    			tme.Seconds
					    		));
								break;
							case "TotalTimerTime":
								TimeSpan tmm = TimeSpan.FromSeconds(Convert.ToInt32(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblMovingTime, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tmm.Hours, 
					    			tmm.Minutes, 
					    			tmm.Seconds
					    		));
								break;
							case "TotalAscent":
								SetControlPropertyThreadSafe(lblTotalAscent, "Text", string.Format("{0:0.00} feet",Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399));
								activity._totalAscent = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "TotalDescent":
								SetControlPropertyThreadSafe(lblTotalDescent, "Text", string.Format("{0:0.00} feet",Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.2808399));
								activity._totalDescent = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "MaxSpeed":
								SetControlPropertyThreadSafe(lblMaxSpeed, "Text", string.Format("{0:0.00} mph ( {1:0.00} km/h )",Convert.ToDouble(e.mesg.fields[i].GetValue(j)) * 2.23693629,Convert.ToDouble(e.mesg.fields[i].GetValue(j))*3.6));
								activity._maxSpeed = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "MaxCadence":
								SetControlPropertyThreadSafe(lblMaxCadence, "Text", string.Format("{0:0} rpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._maxCadence = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "MaxHeartRate":
								SetControlPropertyThreadSafe(lblMaxHeartRate,"Text", string.Format("{0:0} bpm",Convert.ToDouble(e.mesg.fields[i].GetValue(j))));
								activity._maxHeartRate = Convert.ToDouble(e.mesg.fields[i].GetValue(j));
								break;
							case "StartTime":
								System.DateTime st = new System.DateTime(1989,12,31,0,0,0);
								st = st.AddSeconds(Convert.ToDouble(e.mesg.fields[i].GetValue(j)));
								SetControlPropertyThreadSafe(lblActivityDateTime, "Text", st.ToString("dd/MM/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture));
								activity._startTime = st;
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
			Debug.WriteLine(string.Format("UserProfileHandler: Received {1} Mesg, it has global ID#{0}", e.mesg.Num, e.mesg.Name));
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
			lblActivityDateTime.Text = nodeList[0].InnerText;
			
					
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
				// convert avg_speed from metres/sec to miles/hour
				avg_speed = avg_speed_metres_per_sec * 2.23693629;
				avg_cadence = Convert.ToDouble(doc.GetElementsByTagName("avgcadence").Item(0).InnerText);
				avg_heart = Convert.ToDouble(doc.GetElementsByTagName("avgheartrate").Item(0).InnerText);
				
				activity._distance = distance;
				activity._duration = tot_duration.TotalSeconds;
				activity._avgCadence = avg_cadence;
				activity._avgHeartRate = avg_heart;
				activity._avgSpeed = avg_speed_metres_per_sec;
				activity._calories = Convert.ToDouble(doc.GetElementsByTagName("calories").Item(0).InnerText);
				
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
				this.lblAvgSpeed.Text = string.Format("{0:0.00} mph  ( {1:0.00} km/h )", avg_speed, avg_speed/0.621371192);
			}
			else{
				this.lblAvgHeartRate.Text = "-";
				this.lblCadence.Text = "-";
				this.lblCalories.Text = "-";
				this.lblDuration.Text = "-";
				this.lblDistance.Text = "-";
				this.lblAvgSpeed.Text = "-";
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
			zedAltitude.Refresh();	
			//
			zedSpeed.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedSpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedSpeed.GraphPane.YAxis.Scale.MaxAuto = true;
			zedSpeed.AxisChange();
			zedSpeed.Refresh();
			//
			zedCadence.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000;
			zedCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedCadence.AxisChange();
			zedCadence.Refresh();
			//
			zedHeart.GraphPane.XAxis.Scale.Max = (Convert.ToDouble(distance) * 0.621371192)/1000; 
			zedHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
			zedHeart.AxisChange();
			zedHeart.Refresh();
			
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
			
			zedHeart.Refresh();
			zedCadence.Refresh();
			zedSpeed.Refresh();
			
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
            activity._startTime = System.DateTime.Parse(lstTrackpoints.Items[0].SubItems[0].Text);
            			
            setTab(tabControlOverview, "tabMap");
            
            NavigateWebControl(webBrowser1, Application.StartupPath + "\\route.html");
            
            EnableMenuItem(menuUploadToRunKeeper, true);
            EnableMenuItem(menuUploadToStrava, true);
            EnableMenuItem(menuUploadToGarminConnect, true);
            EnableMenuItem(menuUploadToRideWithGps, true);
			
            ResizeListView(lstTrackpoints);
            
            
            
            
		}
	
		void processFile_TCX(string filename)
		{
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
			openFile.InitialDirectory = Path.GetDirectoryName(openFile.FileName);
			// clear the currently loaded trackpoints
			ClearListView(lstTrackpoints);
			
			XmlDocument doc = new XmlDocument();
			doc.Load(openFile.FileName);
			
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
					
			TimeSpan tDuration = TimeSpan.FromSeconds(Convert.ToDouble(nodeList[0].InnerText));
			SetControlPropertyThreadSafe(lblDuration, "Text", string.Format("{0:D2} h {1:D2} m {2:D2} s", tDuration.Hours, tDuration.Minutes, tDuration.Seconds));
			
			nodeList = doc.GetElementsByTagName("DistanceMeters");
			activity._distance = Convert.ToDouble(nodeList[0].InnerText);
			
			double miles;
			double kms;
			miles =  Convert.ToDouble(nodeList[0].InnerText) * 0.000621371192;
			kms = Convert.ToDouble(nodeList[0].InnerText)/1000;
			SetControlPropertyThreadSafe(lblDistance, "Text", miles.ToString("0.00") + " miles ( " + kms.ToString("0.00") + " km )");
			
			nodeList = doc.GetElementsByTagName("Calories");
			SetControlPropertyThreadSafe(lblCalories, "Text", nodeList[0].InnerText);
			activity._calories = Convert.ToDouble(nodeList[0].InnerText);
			
			
			nodeList = doc.GetElementsByTagName("AverageHeartRateBpm");
			if(nodeList.Count > 0){
				SetControlPropertyThreadSafe(lblAvgHeartRate, "Text", nodeList[0].InnerText);
				avgHeart = Convert.ToDouble(nodeList[0].InnerText);
				activity._avgHeartRate = avgHeart;	
			}
			
			nodeList = doc.GetElementsByTagName("Cadence");
			if(nodeList.Count > 0){
				SetControlPropertyThreadSafe(lblCadence, "Text", nodeList[0].InnerText);
				avgCadence = Convert.ToDouble(nodeList[0].InnerText);
			}				
			
			double mph = miles / (tDuration.TotalSeconds / 3600);
			double kph = kms / (tDuration.TotalSeconds/3600);
			
			SetControlPropertyThreadSafe(lblAvgSpeed, "Text", string.Format("{0:0.00} mph  ( {1:0.00} km/h )", mph, kph));
			avgSpeed = mph;
			
			XmlNodeList trackpoints = doc.GetElementsByTagName("Trackpoint");
			
			string distance, cadence, speed, heart;
			double lng, lat, altitude;
			
			
			int point = 0;
			distance = "0";
			double start_lat = 0;
			double start_lng = 0;	
			double finish_lat = 0;
			double finish_lng = 0;				
			
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
				graphListTemperature.Add(dist/1000,Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,9)),tag + "\r\nTemperature = " + string.Format("{0:0}",Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,9))) + " �C");
				
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
				    avgSpeed,
				    zedSpeed.GraphPane.XAxis.Scale.Max,
				    avgSpeed
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
			setActiveTabPage("tabUploadStatus");

			EnableMenuItem(menuUploadToRunKeeper, false);
			
			try{
				if(_rk_auth_token != ""){
					
					setUpdateRideMsg("runkeeper", "Authenticating User Credentials");
					AccessTokenManager tm = new AccessTokenManager(_client_id, _client_secret, _client_uri, _rk_auth_token);
					//tm.InitAccessToken(rk_auth_code);
					
					//Retrieve URIs for HealthGraph endpoints.
					setUpdateRideMsg("runkeeper", "Retrieving API Endpoints");
					UsersEndpoint userRequest = new UsersEndpoint(tm);
					UsersModel user = userRequest.GetUser();
					
					// Retrieve the user profile, so we know what the username is for building 
					// the full activity link
					ProfileEndpoint userProfile = new ProfileEndpoint(tm, user);
					ProfileModel profile = userProfile.GetProfile();
					
					// upload the activity to the Runkeeper website.
					setUpdateRideMsg("runkeeper", "Uploading Activity Information");
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
					
					SQLiteCommand cmd = new SQLiteCommand(_m_dbConnection);
					string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadRunkeeper = \"{0}\" where idFile = {1}", 
					                           profile.Profile + link , 
					                           _dbFileId,
					                           txtActivityName.Text, 
					                           txtActivityNotes.Text
					                          );
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					
				}
				else{
					setUpdateRideMsg("runkeeper","Runkeeper account hasn`t been linked to application yet. \r\nCannot upload at this time.");
					setUpdateRideImg("runkeeper",Image.FromFile("failure-icon.png"));
				}
			}
			catch(Exception ex){
				setUpdateRideMsg("runkeeper","Exception uploading activity. " + ex.ToString());
				setUpdateRideImg("runkeeper",Image.FromFile("failure-icon.png"));
				Debug.Write(ex.ToString());
			}
			
			ResizeListView(lstTrackpoints);
		}
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			// open a connection to the cycle uploader database
			_m_dbConnection = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;");
			_m_dbConnection.Open();
			
			statusBarVersion.Text = _versionStr + ", " + _versionDate;
			_threadInit = new Thread(new ThreadStart(this.initialiseProviders));
			_threadInit.Start();
		}
		
		void initialiseProviders()
		{
			int step =0; 
			SetStatusProgressThreadSafe(statusBar, "Value",step);
			SetStatusProgressThreadSafe(statusBar, "Maximum", 8);
			SetStatusTextThreadSafe(statusBar, "Initialising...");
			checkForGUID();
			
			loadProviderStates();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Endomondo Configuration...");
			//checkForEndomondoDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Runkeeper Configuration...");
			checkForRunkeeperConnectToken();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading GarminConnect Configuration...");
			checkForGarminConnectDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading Strava Configuration...");
			checkForStravaConnectToken();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Loading RideWithGPS Configuration...");
			checkForRideWithGpsDetails();
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);
			SetStatusTextThreadSafe(statusBar, "Performing Clean-Up...");
			
			SetStatusProgressThreadSafe(statusBar, "Value",++step);			
			SetStatusTextThreadSafe(statusBar, "");
			SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			
			// load the file open history information
			SetStatusProgressThreadSafe(statusBar, "Value" ,++step);
			SetStatusTextThreadSafe(statusBar, "Loading File History Information...");
			SetStatusProgressThreadSafe(statusBar, "Visible", 0);
			loadFileHistory();
			SetStatusTextThreadSafe(statusBar, "Done.");
			
			// enable various panels on the form
			SetControlPropertyThreadSafe(grpSummary, "Enabled", true);
			SetControlPropertyThreadSafe(grpProviders, "Enabled", true);
			SetControlPropertyThreadSafe(tabControlOverview, "Enabled", true);
			SetControlPropertyThreadSafe(btnMapFullscreen, "Enabled", true);
			SetControlPropertyThreadSafe(menubar, "Enabled", true);	
			
			setTab(tabControlOverview, "tabFileHistory");
			
			
		}
		
		void loadFileHistory()
		{
			// clear the current file history information, do this so we can use
			// the same function to reload
			ClearListView(lstFileHistory);
			
			string sql = "select idFile, fileOpenDateTime, case fileActivityName ISNULL when 1 then fileName else fileActivityName end as `fileActivityDescription`, case fileActivityNotes isnull when 1 then \"\" else fileActivityNotes end as `fileActivityNotes`, "+
				"fileUploadRunKeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS "+
				"from File order by idFile desc";
			
			SQLiteCommand command = new SQLiteCommand(sql, _m_dbConnection);
			SQLiteDataReader rdr = command.ExecuteReader();
			if(rdr.HasRows){
				while(rdr.Read()){
					string[] row = {
						rdr.GetInt32(0).ToString(),
						rdr.GetString(1),
						rdr.GetString(2),
						rdr.GetString(3),
						rdr.IsDBNull(4) ? "" : rdr.GetString(4), // runkeeper
						rdr.IsDBNull(5) ? "" : rdr.GetString(5), // strava
						rdr.IsDBNull(6) ? "" : rdr.GetString(6), // garmin
						rdr.IsDBNull(7) ? "" : rdr.GetString(7)  // ride with gps
							
					};
					AddListViewItem(lstFileHistory,new ListViewItem(row));
				}
			}
			
		}
		
		void loadProviderStates()
		{
			RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);	
			if(key != null){
				SetControlPropertyThreadSafe(cbkProviderRunkeeper, "Checked", Convert.ToBoolean((string)key.GetValue("checkRunkeeper")));
				SetControlPropertyThreadSafe(cbkProviderStrava, "Checked", Convert.ToBoolean((string)key.GetValue("checkStrava")));
				//SetControlPropertyThreadSafe(cbkProviderEndomondo, "Checked", Convert.ToBoolean((string)key.GetValue("checkEndomondo")));
				SetControlPropertyThreadSafe(cbkProviderGarmin, "Checked", Convert.ToBoolean((string)key.GetValue("checkGarmin")));
				SetControlPropertyThreadSafe(cbkProviderRideWithGps, "Checked", Convert.ToBoolean((string)key.GetValue("checkRideWithGps")));
			}
		}
		
		void checkForGUID()
		{
			_GUID = Guid.NewGuid().ToString();
			
			try{
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);	
				if(key != null){
					if((string)key.GetValue("GUID") == null){
						key.SetValue("GUID",_GUID);
					}
				}
				else{
					Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
					key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
					key.SetValue("GUID",_GUID);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
		}
		
		void checkForEndomondoDetails()
		{
			/*
 			try{
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);	
				if(key != null){
					_endomondo_authToken = (string)key.GetValue("endomondo_authToken");
					_endomondo_displayName = (string)key.GetValue("endomondo_displayName");
					_endomondo_userId = (string)key.GetValue("endomondo_userId");
					_endomondo_secureToken = (string)key.GetValue("endomondo_secureToken");
					
					if(_endomondo_authToken != null){
						EnableMenuItem(menuConnectToEndomondo, false);
						EnableMenuItem(menuViewAccountEndomondo, true);
					}
				}
			}
			catch{}
			*/
		}
		
		void checkForGarminConnectDetails()
		{
			try{
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);	
				if(key != null){
					_gc_user = (string)key.GetValue("gc_user");
					_gc_password = (string)key.GetValue("gc_password");
					if(_gc_user != null && _gc_password != null){
						if((new GarminConnectAPI()).Login(_gc_user, _gc_password)){
							// enable the view account button
							EnableMenuItem(menuConnectToGarmin, false);
							EnableMenuItem(menuViewAccountGarmin, true);
						}
					}
				}
			}
			catch{}
		}
		
		void checkForRideWithGpsDetails()
		{
			try{
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);	
				if(key != null){
					_ridewithgps_email = (string)key.GetValue("ridewithgps_email");
					_ridewithgps_password = (string)key.GetValue("ridewithgps_password");
					if(_ridewithgps_email != null && _ridewithgps_password != null){
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
			}
			catch{}
		}
		
		void checkForStravaConnectToken()
		{
			try{
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);	
				if(key != null){
					_strava_token = (string)key.GetValue("strava_token");
					_strava_name = (string)key.GetValue("strava_name");
					_strava_user_id = (int)key.GetValue("strava_user_id");
					_strava_username = (string)key.GetValue("strava_username");
					_strava_password = (string)key.GetValue("strava_password");
					if(_strava_token != null){
						// enable the view account button
						EnableMenuItem(menuConnectToStrava, false);
						EnableMenuItem(menuViewAccountStrava, true);
					}
				}
			}
			catch{}
		}
		
		void checkForRunkeeperConnectToken()
		{
			// try to open registry key for application
			RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);
			if(key == null){
				// first run, attempt to set the feature-browser_emulation
				
				// create the CycleUploader application key
				
				Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
				key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",false);
			}
			_rk_auth_token = (string)key.GetValue("rk_auth_token");
			if(_rk_auth_token == null){
				_rk_auth_token = "";
			}
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
			// try to open registry key for application
			RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
			if(key == null){
				Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
				key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
			}
			key.SetValue("rk_auth_token",token);
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
			}
		}
		
		void menuViewAccountGarminClick(object sender, EventArgs e)
		{
			ViewerGarmin vg = new ViewerGarmin();
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
        		"<UnitId>3839235642</UnitId>"+
        		"<ProductID>1036</ProductID>"+
        		"<Version>"+
				"<VersionMajor>2</VersionMajor>"+
				"<VersionMinor>80</VersionMinor>"+
				"<BuildMajor>0</BuildMajor>"+
				"<BuildMinor>0</BuildMinor>"+
				"</Version>"+
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
				if(GetListViewItemValue(lstTrackpoints,t,10) == "" && GetListViewItemValue(lstTrackpoints,t,8) != "0" && GetListViewItemValue(lstTrackpoints,t,7) != "0"){
					// Add standard stuff to the trackpoint tag
					bool bIncludeHeartStream = true;
					bool bIncludeCadenceStream = true;
					
					string trkpt = ""+
						"<Trackpoint>"+
						"<Time>" + GetListViewItemValue(lstTrackpoints,t,0) + "</Time>"+
						"<Position><LatitudeDegrees>" + GetListViewItemValue(lstTrackpoints,t,8) + "</LatitudeDegrees><LongitudeDegrees>" + GetListViewItemValue(lstTrackpoints,t,7) + "</LongitudeDegrees></Position>"+
						"<AltitudeMeters>" + (Convert.ToDouble(GetListViewItemValue(lstTrackpoints,t,2))/3.2808399).ToString() + "</AltitudeMeters>"+
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
			setActiveTabPage("tabUploadStatus");
			setUpdateRideMsg("garmin","Authenticating User");
			if(!_gc.Login(_gc_user, _gc_password)){
				setUpdateRideMsg("garmin","Login Failed");
			}
			else{
				setUpdateRideMsg("garmin","Preparing Activity For Upload");
				_gc.UploadFile(_activity_file_name, txtActivityName.Text, _m_dbConnection, _dbFileId, txtActivityName.Text, txtActivityNotes.Text);
			}
		}
		
		void setActiveTabPage(string tabpage)
		{
			setTab(tabControlOverview, tabpage);
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
			setActiveTabPage("tabUploadStatus");
			// if not logged in, attempt to login now.
			if(!_rwgps.isLoggedIn()){
				setUpdateRideMsg("ridewithgps","Authenticating User");
				if(!_rwgps.login(_ridewithgps_email, _ridewithgps_password)){
					setUpdateRideMsg("ridewithgps", "Login Failed");
				}
			}
			
			if(_rwgps.isLoggedIn()){
				setUpdateRideMsg("ridewithgps","Preparing Activity For Upload");
				//string tcx = "";
				
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
					
					if(GetListViewItemValue(lstTrackpoints, t, 8) != "0" && GetListViewItemValue(lstTrackpoints, t, 7) != ""){
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
				
				string jsonFooter = @"]""}";
				
				jsonData.Append(jsonFooter);
				
				setUpdateRideMsg("ridewithgps","Uploading, waiting for response");
				_rwgps.upload_activity_json(ref jsonData, _m_dbConnection, _dbFileId, txtActivityName.Text, txtActivityNotes.Text);
				
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
			setTab(tabControlOverview, "tabUploadStatus");
			
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
			
			loadFileHistory();
			
			SetControlPropertyThreadSafe(btnUploadAllProviders, "Enabled", true);
		}
			
		void linkRideIdClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//string wUrl = string.Format("http://app.strava.com/activities/{0}", e.Link.LinkData.ToString());
			//Process.Start(wUrl);
		}
		
		void MenuConnectToEndomondoClick(object sender, EventArgs e)
		{
			/*
 			EndomondoConnect endo = new EndomondoConnect(_GUID);
			if(endo.ShowDialog() == DialogResult.OK){
				menuConnectToEndomondo.Enabled = false;
				menuViewAccountEndomondo.Enabled = true;
				_endomondo_authToken = endo.endo._authToken;
				_endomondo_secureToken = endo.endo._secureToken;
				_endomondo_displayName = endo.endo._displayName;
				_endomondo_userId = endo.endo._userId;
			}
			*/
		}
		
		void MenuViewAccountEndomondoClick(object sender, EventArgs e)
		{
			//ViewerEndomondo endo = new ViewerEndomondo(_endomondo_authToken, _endomondo_secureToken, _endomondo_displayName, _endomondo_userId);
			//endo.ShowDialog();			
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
			//menuProviderEndomondo.Enabled = ((CheckBox)sender).Checked;
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
			RegistryKey key;
			// try and save the provider enabled settings to the registry so they are preserved
			// on next run of the application
			try{
				key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);	
				if(key == null){
					Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
					key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
				}
				
				key.SetValue("checkRunkeeper",this.cbkProviderRunkeeper.Checked);
				key.SetValue("checkStrava", this.cbkProviderStrava.Checked);
				//key.SetValue("checkEndomondo", this.cbkProviderEndomondo.Checked);
				key.SetValue("checkGarmin", this.cbkProviderGarmin.Checked);
				key.SetValue("checkRideWithGps", this.cbkProviderRideWithGps.Checked);
				
			}
			catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
			
			// check to see if the init thread is active, if it is abort it gracefully (ish)
			try{
				if(_threadInit.IsAlive){
					_threadInit.Abort();
				}
			}
			catch{}
			
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
				loadFileHistoryInformation(Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text));
			}
		}
		
		void loadFileHistoryInformation(int fileId)
		{
			SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
			SQLiteDataReader rdrSummary;
			SQLiteDataReader rdr;
			string sql = "";
			
			// load the file summary
			sql = string.Format("select fs.*, case f.fileActivityName ISNULL when 1 then f.fileName else f.fileActivityName end as `fileName`, f.fileActivityNotes, "+
			                    " fileUploadRunkeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS "+
			                    "from File f "+
			                    "left join FileSummary fs on f.idFile = fs.idFile where f.idFile = {0}", 
			                    fileId
			                   );
			command.CommandText = sql;
			rdrSummary = command.ExecuteReader();
			if(rdrSummary.HasRows){
				rdrSummary.Read();
				lblHistoryName.Text = rdrSummary.GetString(13);
				lblHistoryDuration.Text = rdrSummary.IsDBNull(1) ? "-" : rdrSummary.GetString(1);
				lblHistoryDistance.Text = rdrSummary.IsDBNull(2) ? "-" : rdrSummary.GetString(2);
				lblHistoryCalories.Text = rdrSummary.IsDBNull(3) ? "-" : rdrSummary.GetString(3);
				lblHistoryAvgHeartRate.Text = rdrSummary.IsDBNull(4) ? "-" : rdrSummary.GetString(4);
				lblHistoryAvgCadence.Text = rdrSummary.IsDBNull(5) ? "-" : rdrSummary.GetString(5);
				lblHistoryAvgSpeed.Text = rdrSummary.IsDBNull(6) ? "-" : rdrSummary.GetString(6);
				lblHistoryMovingTime.Text = rdrSummary.IsDBNull(7) ? "-" : rdrSummary.GetString(7);
				lblHistoryTotalAscent.Text = rdrSummary.IsDBNull(8) ? "-" : rdrSummary.GetString(8);
				lblHistoryTotalDescent.Text = rdrSummary.IsDBNull(9) ? "-" : rdrSummary.GetString(9);
				lblHistoryMaxHeartRate.Text = rdrSummary.IsDBNull(10) ? "-" : rdrSummary.GetString(10);
				lblHistoryMaxCadence.Text = rdrSummary.IsDBNull(11) ? "-" : rdrSummary.GetString(11);
				lblHistoryMaxSpeed.Text = rdrSummary.IsDBNull(12) ? "-" : rdrSummary.GetString(12);
				txtHistoryNotes.Text = rdrSummary.IsDBNull(14) ? "" : rdrSummary.GetString(14);
				
				if(rdrSummary.IsDBNull(15)){
					cbkHistoryUploadRunkeeper.Checked = false;
					pnlHistoryUploadRunkeeper.Enabled = false;
					pnlHistoryUploadRunkeeper.BackColor = Color.Gainsboro;
				}else{
					cbkHistoryUploadRunkeeper.Checked = true;
					pnlHistoryUploadRunkeeper.Enabled = true;
					pnlHistoryUploadRunkeeper.BackColor = Color.AliceBlue;
					linkHistoryUploadRunkeeper.Links.Clear();
					linkHistoryUploadRunkeeper.Links.Add(0,0,rdrSummary.GetString(15));
				}
				//
				if(rdrSummary.IsDBNull(16)){
					cbkHistoryUploadStrava.Checked = false;
					pnlHistoryUploadStrava.Enabled = false;
					pnlHistoryUploadStrava.BackColor = Color.Gainsboro;
				}else{
					cbkHistoryUploadStrava.Checked = true;
					pnlHistoryUploadStrava.Enabled = true;				
					pnlHistoryUploadStrava.BackColor = Color.AliceBlue;					
					linkHistoryUploadStrava.Links.Clear();
					linkHistoryUploadStrava.Links.Add(0,0,rdrSummary.GetString(16));
				}
				// 
				if(rdrSummary.IsDBNull(17)){
					cbkHistoryUploadGarmin.Checked = false;
					pnlHistoryUploadGarmin.Enabled = false;
					pnlHistoryUploadGarmin.BackColor = Color.Gainsboro;
				}else{
					cbkHistoryUploadGarmin.Checked = true;
					pnlHistoryUploadGarmin.Enabled = true;
					pnlHistoryUploadGarmin.BackColor = Color.AliceBlue;
					linkHistoryUploadGarmin.Links.Clear();
					linkHistoryUploadGarmin.Links.Add(0,0,rdrSummary.GetString(17));
				}
				// 
				if(rdrSummary.IsDBNull(18)){
					cbkHistoryUploadRideWithGPS.Checked = false;
					pnlHistoryUploadRideWithGPS.Enabled = false;
					pnlHistoryUploadRideWithGPS.BackColor = Color.Gainsboro;
				}else{
					cbkHistoryUploadRideWithGPS.Checked = true;
					pnlHistoryUploadRideWithGPS.Enabled = true;
					pnlHistoryUploadRideWithGPS.BackColor = Color.AliceBlue;
					linkHistoryUploadRideWithGPS.Links.Clear();
					linkHistoryUploadRideWithGPS.Links.Add(0,0,rdrSummary.GetString(18));
				}
			}
			else{
				lblHistoryName.Text = "<Summary Not Found>";
				lblHistoryDuration.Text = "-";
				lblHistoryDistance.Text = "-";
				lblHistoryCalories.Text = "-";
				lblHistoryAvgHeartRate.Text = "-";
				lblHistoryAvgCadence.Text = "-";
				lblHistoryAvgSpeed.Text = "-";
				lblHistoryMovingTime.Text = "-";
				lblHistoryTotalAscent.Text = "-";
				lblHistoryTotalDescent.Text = "-";
				lblHistoryMaxHeartRate.Text = "-";
				lblHistoryMaxCadence.Text = "-";
				lblHistoryMaxSpeed.Text = "-";
				txtHistoryNotes.Text = "-";
				
				cbkHistoryUploadRunkeeper.Checked = false;
				pnlHistoryUploadRunkeeper.Enabled = false;
				pnlHistoryUploadRunkeeper.BackColor = Color.Gainsboro;
				//
				cbkHistoryUploadStrava.Checked = false;
				pnlHistoryUploadStrava.Enabled = false;
				pnlHistoryUploadStrava.BackColor = Color.Gainsboro;
				// 
				cbkHistoryUploadGarmin.Checked = false;
				pnlHistoryUploadGarmin.Enabled = false;
				pnlHistoryUploadGarmin.BackColor = Color.Gainsboro;
				// 
				cbkHistoryUploadRideWithGPS.Checked = false;
				pnlHistoryUploadRideWithGPS.Enabled= false;
				pnlHistoryUploadRideWithGPS.BackColor = Color.Gainsboro;
			}
			rdrSummary.Close();
			rdrSummary.Dispose();
			
			// load and process the archived trackpoints for file
			sql = string.Format("select * from FileTrackpoints where idFile = {0}", 
			                           fileId
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
				
				PointPairList graphListAltitude = new PointPairList();
				PointPairList graphListSpeed = new PointPairList();
				PointPairList graphListCadence = new PointPairList();
				PointPairList graphListHeart = new PointPairList();
				
				double distance = 0;
				while(rdr.Read()){
					rowCount++;
					
					if(rowCount==1){
						start_lat = Convert.ToDouble(rdr.GetString(9));
						start_lng = Convert.ToDouble(rdr.GetString(8));
					}
					// update the last point coordinates
					finish_lat = Convert.ToDouble(rdr.GetString(9));
					finish_lng = Convert.ToDouble(rdr.GetString(8));
					
					distance = (rdr.GetDouble(4)/1000) * 0.621371192; // convert metres to miles
					double duration = rdr.GetDouble(2);
					double altitude = rdr.GetDouble(3);
					double speed = rdr.GetDouble(7);
					double cadence = rdr.GetDouble(6);
					double heart = rdr.GetDouble(5);
					
					tag = rdr.GetString(1) + "\r\nDistance = " + distance.ToString("0.00") + " miles\r\n";
					if(distance != 0){
						graphListAltitude.Add(distance,altitude,tag + "Altitude = " + altitude.ToString("0.00") + " feet");
						graphListSpeed.Add(distance, speed, tag + "Speed = " + speed.ToString("0.00") + " mph");
						graphListCadence.Add(distance, cadence, tag + "Cadence = " + cadence.ToString("0") + " rpm");
						graphListHeart.Add(distance, heart, tag + "Heart-Rate = " + heart.ToString("0") + " bpm");
					}
					
					lat = Convert.ToDouble(rdr.GetString(9));
					lng = Convert.ToDouble(rdr.GetString(8));
					
					// increment the running totals
					runningDuration = duration;
					runningMileDistance = distance;

					// check if we've reached threshold for current search miles
					if(runningMileDistance > currentMileSearch){
						TimeSpan tsPace = TimeSpan.FromSeconds(runningDuration);
						RideWithGpsMileSplit mileSplit = new RideWithGpsMileSplit();
						mileSplit.label = string.Format("Mile {0}",currentMileSearch);
						mileSplit.speed = string.Format("{0:0.00} mph", (1 / (runningDuration / 3600)));
						mileSplit.pace = string.Format("{0:D2} h {1:D2} m {2:D2} s", tsPace.Hours, tsPace.Minutes, tsPace.Seconds);
						
						//summary.mileSplits.Add(mileSplit);
						
			
			
						TimeSpan tmp_ts = TimeSpan.FromSeconds(rdr.GetDouble(2));
						string mile_marker_tag = "Time since start of ride: " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
							tmp_ts.Hours, 
							tmp_ts.Minutes, 
							tmp_ts.Seconds
						);
						js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + (currentMileSearch) + "|95E978|004400',position: new google.maps.LatLng(" + lat + "," + lng + "),map: map,title: 'Mile " + (currentMileSearch) + "\\r\\n" + mile_marker_tag + "'});";
						
						// reset the running duration
						// and increment the mile search counter for the next mile
						runningDuration = 0;
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
						js_coords += "\r\nnew google.maps.LatLng(" + rdr.GetString(9) + "," + rdr.GetString(8) + ")";
					}
					
					
				}
				
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
		            setTab(tabControlHistory, "tabHistorySummary");
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
				zedHistoryAltitude.Refresh();
				// add the speed curve
				zedHistorySpeed.GraphPane.AddCurve("Speed",graphListSpeed, Color.Blue, SymbolType.None).Line.Width = 1;					
				zedHistorySpeed.GraphPane.XAxis.Scale.Max = distance;
				zedHistorySpeed.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistorySpeed.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				LineItem ln_altitude  = zedHistorySpeed.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistorySpeed.AxisChange();
				zedHistorySpeed.Refresh();
				// add the cadence curve
				zedHistoryCadence.GraphPane.AddCurve("Cadence",graphListCadence, Color.Magenta, SymbolType.None).Line.Width = 1;					
				zedHistoryCadence.GraphPane.XAxis.Scale.Max = distance;
				zedHistoryCadence.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistoryCadence.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				ln_altitude  = zedHistoryCadence.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistoryCadence.AxisChange();
				zedHistoryCadence.Refresh();
				// add the heart rate curve
				zedHistoryHeart.GraphPane.AddCurve("Heart-Rate",graphListHeart, Color.Red, SymbolType.None).Line.Width = 1;					
				zedHistoryHeart.GraphPane.XAxis.Scale.Max = distance;
				zedHistoryHeart.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedHistoryHeart.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
				ln_altitude  = zedHistoryHeart.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 1;
				
				zedHistoryHeart.AxisChange();
				zedHistoryHeart.Refresh();
			}
		}
		
		void BtnFullscreenHistoryMapClick(object sender, EventArgs e)
		{
			FullscreenMap map = new FullscreenMap(Application.StartupPath + "\\history_route.html");
			map.ShowDialog();
		}
			
		void LstFileHistoryMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				ActivityName actName = new ActivityName(lstFileHistory.SelectedItems[0].SubItems[2].Text, lstFileHistory.SelectedItems[0].SubItems[3].Text);
				// if OK, set the activity name in the database
				if(actName.ShowDialog() == DialogResult.OK){
					// get the id of the file selected
					int fileId = Convert.ToInt32(lstFileHistory.SelectedItems[0].SubItems[0].Text);
					string sql = string.Format("update File set fileActivityName = \"{0}\", fileActivityNotes = \"{2}\" where idFile = {1}",
					                           actName._activityName,
					                           fileId,
					                           actName._activityNotes
					                          );
					SQLiteCommand command = new SQLiteCommand(_m_dbConnection);
					command.CommandText = sql;
					int index = lstFileHistory.SelectedItems[0].Index;
					command.ExecuteNonQuery();
					loadFileHistory();
					lstFileHistory.Items[index].Selected = true;
					lstFileHistory.Select();
					lstFileHistory.HideSelection = false;
					
				}
			}
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
	}
}
