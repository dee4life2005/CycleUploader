/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 11/04/2013
 * Time: 09:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Dynastream.Fit;
using Dynastream.Utility;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;
using System.Data.SQLite;

namespace CycleUploader
{
	/// <summary>
	/// Description of GarminSettings.
	/// </summary>
	public partial class GarminSettings : Form
	{
		const int WM_DEVICECHANGE = 0x0219; //see msdn site
	    const int DBT_DEVICEARRIVAL = 0x8000;
	    const int DBT_DEVICEREMOVALCOMPLETE = 0x8004;
	    const int DBT_DEVTYPVOLUME = 0x00000002;   
    
	    private Thread th_loadingActivities;
	    private string curDeviceFile = "";
	    private SQLiteConnection _db;
	    private int unprocessedCount = 0;
	    
	    public List<string> unprocessedFiles;
	   	    
		public GarminSettings(SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db = db;
			tNoDevice.BringToFront();
		}
		
		protected override void WndProc(ref Message m)
	    {
	
	        if (m.Msg == WM_DEVICECHANGE)
	        {
	            DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
	            if ((m.WParam.ToInt32() == DBT_DEVICEARRIVAL) &&  (vol.dbcv_devicetype == DBT_DEVTYPVOLUME) )
	            {
	                checkForGarminDevice(DriveMaskToLetter(vol.dbcv_unitmask).ToString() + ":\\");
	            }
	            if ((m.WParam.ToInt32() == DBT_DEVICEREMOVALCOMPLETE) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
	            {
	            	showGarminDeviceRemoved();
	            }
	        }
	        base.WndProc(ref m);
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
		
		
		
		
		#region Fit File Processing Handlers
		
		void OnMesg(object sender, MesgEventArgs e)
		{
			
			if(e.mesg.Name == "Totals"){
				Debug.WriteLine("============== TOTALS ================");
				for (byte i=0; i<e.mesg.GetNumFields(); i++)
				{
					for (int j = 0; j < e.mesg.fields[i].GetNumValues(); j++)
					{
						
						Debug.WriteLine(string.Format("\tField{0} Index{1} (\"{2}\" Field#{4}) Value: {3}", i, j, e.mesg.fields[i].GetName(), getVal(e.mesg.fields[i].GetValue(j)), e.mesg.fields[i].Num));
					}
				}
			}
		}
		
		string getVal(object val)
		{
			if(val is byte[]){
				return System.Text.Encoding.ASCII.GetString((byte[])val);
			}
			else{
				return val.ToString();
			}
		}
		
		void OnSessionMesg(object sender, MesgEventArgs e)
      	{
			bool bAlreadyProcessed = false;
			SessionMesg mySession = (SessionMesg)e.mesg;
	         try
	         {
	         	TimeSpan tsTotal = TimeSpan.FromSeconds(Convert.ToDouble(mySession.GetTotalTimerTime()));
	         	TimeSpan tsMoving= TimeSpan.FromSeconds(Convert.ToDouble(mySession.GetTotalElapsedTime()));
	         	
	         	try{
		         	string sql = string.Format(@"select count(*) from File f where f.fileName = ""{0}""", Path.GetFileName(curDeviceFile));
		         	SQLiteCommand cmd = new SQLiteCommand(sql,_db);
		         	if(Convert.ToInt32(cmd.ExecuteScalar()) > 0){
						bAlreadyProcessed = true;	         		
		         	}
		         	else{
		         		unprocessedCount++;
		         		unprocessedFiles.Add(curDeviceFile);
		         		SetControlPropertyThreadSafe(tNumToBeProcessed, "Text", string.Format("There are {0} activities that are not yet processed / uploaded",unprocessedCount));
		         	}
	         	}
	         	catch(Exception ex){
	         		MessageBox.Show(ex.ToString());
	         	}
	         	
	         	string[] row = {
	         		"",
	         		bAlreadyProcessed ? "Y" : "",
	         		mySession.GetStartTime().GetDateTime().ToString("dd/MM/yyyy HH:mm",System.Globalization.CultureInfo.CurrentCulture),
	         		string.Format("{0:0.00} miles", (mySession.GetTotalDistance()/1000)*0.621371192),
	         		string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tsTotal.Hours, 
					    			tsTotal.Minutes, 
					    			tsTotal.Seconds
					    		),
	         		string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			tsMoving.Hours, 
					    			tsMoving.Minutes, 
					    			tsMoving.Seconds
					    		),
	         		string.Format("{0:0.00} ft",mySession.GetTotalAscent() * 3.2808399),
	         		mySession.GetTotalCalories().ToString(),
	         		string.Format("{0:0.00} mph", mySession.GetAvgSpeed()* 2.23693629),
	         		string.Format("{0:0} bpm", mySession.GetAvgHeartRate()),
	         		string.Format("{0:0} rpm", mySession.GetAvgCadence()),
	         		string.Format("{0:0.00} mph", mySession.GetMaxSpeed()* 2.23693629),
	         		string.Format("{0:0} bpm", mySession.GetMaxHeartRate()),
	         		string.Format("{0:0} rpm", mySession.GetMaxCadence()),
	         		""
	         	};
	         	AddListViewItem(lstDeviceActivities, new ListViewItem(row));
	         }
	         catch{}
		}
		
		void OnFileIDMesg(object sender, MesgEventArgs e)
      	{
			FileIdMesg myFileId = (FileIdMesg)e.mesg;         
	         try
	         {
	         	Dynastream.Fit.DateTime dtTime = new Dynastream.Fit.DateTime(myFileId.GetTimeCreated().GetTimeStamp());
	         	
	         	tDevice.Text = getGarminProduct(myFileId.GetProduct());
	         	tSerialNumber.Text = myFileId.GetSerialNumber().ToString();
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
				tGender.Text = myUserProfile.GetGender().ToString();
				tAge.Text = myUserProfile.GetAge().ToString();
				tHeight.Text = myUserProfile.GetHeight().ToString() + " m";
				tWeightKg.Text = myUserProfile.GetWeight().ToString() + " kg";
				tHeartResting.Text = myUserProfile.GetRestingHeartRate().ToString() + " bpm";
				tHeartMax.Text = myUserProfile.GetDefaultMaxBikingHeartRate().ToString() + " bpm";
			}        
			catch (FitException exception)
			{
				Debug.WriteLine(string.Format("\tOnUserProfileMesg Error {0}", exception.Message));
				Debug.WriteLine(string.Format("\t{0}", exception.InnerException));
			}  	
		}
		
		void OnBikeProfileMesg(object sender, MesgEventArgs e)
		{
			BikeProfileMesg myBikeProfile = (BikeProfileMesg)e.mesg;
			
			try
			{
				string[] row = {
					getVal(myBikeProfile.GetName()),
					myBikeProfile.GetBikeWeight().ToString() + " kg",
					string.Format("{0:0.00} miles",Convert.ToDouble(myBikeProfile.GetOdometer()) * 0.000621371192)
				};
				lstBikeProfile.Items.Add(new ListViewItem(row));
			}        
			catch (FitException exception)
			{
				Debug.WriteLine(string.Format("\tOnBikeProfileMesg Error {0}", exception.Message));
				Debug.WriteLine(string.Format("\t{0}", exception.InnerException));
			}  	
		}
		
		void OnFileCreatorMesg(object sender, MesgEventArgs e)
		{
			FileCreatorMesg myFileCreator = (FileCreatorMesg)e.mesg;
			
			try
			{
				tSoftwareVersion.Text = myFileCreator.GetSoftwareVersion().ToString();
			}        
			catch{}
		}
		
		#endregion
		
		
		
		string getGarminProduct(ushort? productId)
		{
			string productName = "";
			switch(productId)
			{
				case GarminProduct.Fr405:
					productName = "Forerunner 405";
					pbDeviceImage.Image = deviceImageList.Images["forerunner405.png"];
					break;
				case GarminProduct.Fr50:
					productName = "Forerunner 50";
					pbDeviceImage.Image = deviceImageList.Images["forerunner50.png"];
					break;
				case GarminProduct.Fr60:
					productName = "Forerunner 60";
					pbDeviceImage.Image = deviceImageList.Images["forerunner60.png"];
					break;
				case GarminProduct.Fr310xt:
				case GarminProduct.Fr310xt4t:
					productName = "Forerunner 310";
					pbDeviceImage.Image = deviceImageList.Images["forerunner310.png"];
					break;
				case GarminProduct.Edge200:
					productName = "Edge 200";
					pbDeviceImage.Image = deviceImageList.Images["edge200.png"];
					break;
				case GarminProduct.Edge500:
					productName = "Edge 500";
					pbDeviceImage.Image = deviceImageList.Images["edge500.png"];
					break;
				case GarminProduct.Edge800:
					productName = "Edge 800";
					pbDeviceImage.Image = deviceImageList.Images["edge800.png"];
					break;
				default:
					productName = productId.ToString();
					break;
			}
			return productName;
		}
		
		void GarminSettingsShown(object sender, EventArgs e)
		{
			DriveInfo[] ListDrives = DriveInfo.GetDrives();

			foreach (DriveInfo Drive in ListDrives)
			{
			    if (Drive.DriveType == DriveType.Removable)
			    {
			    	if(checkForGarminDevice(Drive.RootDirectory.ToString())){
			    		return;
			    	}
			    }    
			}
		}
		
		bool checkForGarminDevice(string driveRoot)
		{
			if(System.IO.File.Exists(driveRoot + "Garmin\\Device.fit")){
				Debug.WriteLine("checkForGarminDevice()");
	    		loadGarminDeviceSettings(driveRoot);
	    		return true;
	    	}
	    	else{
				return false;
	    	}	
		}
		
		
		
		void loadGarminDeviceSettings(string driveRoot)
		{
			tNumActivities.Text = "< calculating >";
			unprocessedFiles = new List<string>();
			lstBikeProfile.Items.Clear();
			tNoDevice.SendToBack();
			pnlRequiresProcessing.Hide();
			FileStream fitSource = new FileStream(driveRoot + "Garmin\\Settings\\Settings.fit", FileMode.Open);
			Decode fitSourceDec = new Decode();
			
			MesgBroadcaster mesgBroadcaster = new MesgBroadcaster();
			
			// connect the broadcaster to our event (message) source (this this case the decoder)
			fitSourceDec.MesgEvent += mesgBroadcaster.OnMesg;
			fitSourceDec.MesgDefinitionEvent += mesgBroadcaster.OnMesgDefinition;
			
			// subscribe to message events of interest by connecting to the broadcaster
			//mesgBroadcaster.MesgEvent += new MesgEventHandler(OnMesg);
			//mesgBroadcaster.MesgDefinitionEvent += new MesgDefinitionEventHandler(OnMesgDefn);
			
			mesgBroadcaster.FileIdMesgEvent += new MesgEventHandler( OnFileIDMesg);
			mesgBroadcaster.UserProfileMesgEvent += new MesgEventHandler( OnUserProfileMesg);
			mesgBroadcaster.BikeProfileMesgEvent += new MesgEventHandler( OnBikeProfileMesg);
			mesgBroadcaster.FileCreatorMesgEvent += new MesgEventHandler( OnFileCreatorMesg);
		
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
			
			// determine if there are any activities on the device
			
			string[] files = Directory.GetFiles(driveRoot + "Garmin\\Activities\\", "*.fit");
			Array.Sort(files,StringComparer.InvariantCulture);
			if(files.Length > 0){
				tNumActivities.Text = files.Length.ToString();
				if(th_loadingActivities != null && th_loadingActivities.IsAlive){
					th_loadingActivities.Abort();
				}
				th_loadingActivities = new Thread(new ParameterizedThreadStart(this.ReadActivitiesOnDevice));
				th_loadingActivities.Start(driveRoot);
			}
			else{
				tNumActivities.Text = "0";
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
		
		void ReadActivitiesOnDevice(object driveRoot)
		{
			if(pnlLoadingActivities.InvokeRequired){
				pnlLoadingActivities.Invoke(new MethodInvoker(pnlLoadingActivities.BringToFront));
			}
			ClearListView(lstDeviceActivities);
						
			string[] files = Directory.GetFiles((string)driveRoot + "Garmin\\Activities\\", "*.fit");
			SetControlPropertyThreadSafe(prgReadingActivities, "Value", 0);
			SetControlPropertyThreadSafe(prgReadingActivities, "Maximum", files.Length);
			SetControlPropertyThreadSafe(prgReadingActivities, "Step", 1);
			if(files.Length > 0){
				unprocessedCount = 0;
				for(int f = 0; f < files.Length; f++){
					curDeviceFile = files[f];
					FileStream fitFile = new FileStream(files[f], FileMode.Open);
					Decode fitFileDec = new Decode();		
					MesgBroadcaster fileMesgBroadcaster = new MesgBroadcaster();
			
					// connect the broadcaster to our event (message) source (this this case the decoder)
					fitFileDec.MesgEvent += fileMesgBroadcaster.OnMesg;
					fitFileDec.MesgDefinitionEvent += fileMesgBroadcaster.OnMesgDefinition;
					fileMesgBroadcaster.SessionMesgEvent += new MesgEventHandler( OnSessionMesg);
					
					bool statusFile = fitFileDec.IsFIT(fitFile);
					statusFile &= fitFileDec.CheckIntegrity(fitFile);
					if(statusFile == true){
						fitFileDec.Read(fitFile);
					}
					else{
						MessageBox.Show("fit file integrity failed, attempting to read anyway");
						fitFileDec.Read(fitFile);
					}
					fitFile.Close();
					SetControlPropertyThreadSafe(prgReadingActivities, "Value", f+1);
				}
				if(unprocessedCount > 0){
					SetControlPropertyThreadSafe(pnlRequiresProcessing, "Visible", true);
				}
				else{
					SetControlPropertyThreadSafe(pnlRequiresProcessing, "Visible", false);
				}
			}
			ResizeListView(lstDeviceActivities);
			SetListViewColumnWidth(lstDeviceActivities,0,0);
			if(lstDeviceActivities.InvokeRequired){
				lstDeviceActivities.Invoke(new MethodInvoker(lstDeviceActivities.BringToFront));
			}
		}
		
		void showGarminDeviceRemoved()
		{
			if(th_loadingActivities != null && th_loadingActivities.IsAlive){
				th_loadingActivities.Abort();
			}
			tNoDevice.BringToFront();
			pnlRequiresProcessing.Hide();
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			if(th_loadingActivities != null && th_loadingActivities.IsAlive){
				th_loadingActivities.Abort();
			}
			this.DialogResult = DialogResult.OK;
		}
		
		void GarminSettingsFormClosing(object sender, FormClosingEventArgs e)
		{
			if(th_loadingActivities != null && th_loadingActivities.IsAlive){
				th_loadingActivities.Abort();
			}
		}
		
		void BtnProcessNowClick(object sender, EventArgs e)
		{
			// send YES to indicate we want to process the unprocessed files
			this.DialogResult = DialogResult.Yes;
		}
	}
}
