﻿/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/03/2013
 * Time: 09:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Data.SQLite;
using System.Collections.Generic;

namespace CycleUploader
{
	/// <summary>
	/// Description of Batch.
	/// </summary>
	public partial class Batch : Form
	{
		private string _previous_file_path;
		private MainForm _mainFrm;
		private bool _bIsProcessingBatch;
		private int _batchCurrentIdx; // index of item currently being processed
		private bool _bIsProcessingComplete;
		private List<string> _unprocessedFiles;
		private bool _skipFileOpen = false;
		
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
		
		private delegate void SetListViewItemValueDelegate(Control ctrl, int itemIdx, int subItemIdx, string value, string text);			
		private static void SetListViewItemValue(Control ctrl, int itemIdx, int subItemIdx, string value, string text)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new SetListViewItemValueDelegate(SetListViewItemValue), new object[] {ctrl, itemIdx, subItemIdx, value, text});
			}
			else{
				if(value == "success"){
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].BackColor = Color.LightGreen;
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].ForeColor = Color.LightGreen;
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].Text = text;
				}
				else if(value == "inprogress"){
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].BackColor = Color.DodgerBlue;
				}
				else if(value == "indicator")
				{
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].BackColor = Color.LightBlue;
				}
				else if(value == "completed")
				{
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].BackColor = Color.DarkGray;
				}
				else{
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].BackColor = Color.LightCoral;
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].ForeColor = Color.LightCoral;
					((ListView)ctrl).Items[itemIdx].SubItems[subItemIdx].Text = text;
				}
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
		
		
		public Batch(string path, MainForm mainFrm, bool bRunkeeper, bool bStrava, bool bGarmin, bool bRWGPS, List<string> files)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_previous_file_path = path;
			_mainFrm = mainFrm;
			_bIsProcessingBatch = false;
			_bIsProcessingComplete = false;
			cbkProviderRunkeeper.Checked = bRunkeeper;
			cbkProviderStrava.Checked = bStrava;
			cbkProviderGarmin.Checked = bGarmin;
			cbkProviderRideWithGps.Checked = bRWGPS;
			if(files.Count > 0){
				_skipFileOpen = true;
				_unprocessedFiles = files;
			}
		}
		
		void BatchShown(object sender, EventArgs e)
		{
			
			if(!_skipFileOpen){
				if(_previous_file_path == ""){
					_previous_file_path = Environment.SpecialFolder.Personal.ToString();
				}
				
				fdBatch.Filter = "All Files (*.fit,*.tcx,*.gpx)|*.fit;*.tcx;*.gpx|FIT File (*.fit)|*.fit|Garmin Training Center Database Files (*.tcx)|*.tcx|GPX Files (*.gpx)|*.gpx";
				fdBatch.Title = "Please select activities for upload.";
				fdBatch.InitialDirectory = _previous_file_path;
				fdBatch.Multiselect = true;
				if(fdBatch.ShowDialog() == DialogResult.OK)
				{
					_unprocessedFiles = new List<string>();
					for(int f = 0; f < fdBatch.FileNames.Length; f++){
						_unprocessedFiles.Add(fdBatch.FileNames[f]);
					}
				}
			}
			if(_unprocessedFiles != null && _unprocessedFiles.Count > 0){
				// run a check against the database to determine if we've already opened this file
				using(var conn = new SQLiteConnection("Data Source=cycleuploader.sqlite;Version=3;"))
				{
					conn.Open();
					for(int f =0; f < _unprocessedFiles.Count; f++){
						SQLiteCommand command = new SQLiteCommand(conn);
						string sql = string.Format("select * from File where fileName = \"{0}\"", Path.GetFileName(_unprocessedFiles[f]));
						command.CommandText = sql;
						SQLiteDataReader rdr = command.ExecuteReader();
						if(rdr.HasRows){
							MessageBox.Show("Error: File `" + Path.GetFileName(_unprocessedFiles[f]) + "` has already been processed by this application and will be excluded from your processing batch.\r\n\r\nAdditional processing is not supported, please perform this manually on the provider websites", "Error: File Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else{
							string[] row = {
								"",
								Path.GetFileName(_unprocessedFiles[f]),
								File.GetCreationTime(_unprocessedFiles[f]).ToString("dd/MM/yyyy HH:mm"),
								"", // act name
								"", // act notes
								"", // act is commute
								"", // act is stationary trainer
								"", // runkeeper status
								"", // strava status
								"", // garmin status
								"", // rwgps status
								_unprocessedFiles[f],  // file path column
								"",
								""
							};
							lstBatchFiles.Items.Add(new ListViewItem(row));
							lstBatchFiles.Items[lstBatchFiles.Items.Count-1].UseItemStyleForSubItems = false;
						}
					}
				}
			}
			lstBatchFiles.SuspendLayout();
			ResizeListView(lstBatchFiles);
			lstBatchFiles.Columns[0].Width=30;
			lstBatchFiles.Columns[0].TextAlign = HorizontalAlignment.Left;
			
			lstBatchFiles.Columns[4].Width=50;
			
			lstBatchFiles.Columns[7].Width=32;
			lstBatchFiles.Columns[8].Width=32;
			lstBatchFiles.Columns[9].Width=32;
			lstBatchFiles.Columns[10].Width=32;
			lstBatchFiles.Columns[11].Width=0; // hide the full file path column
			lstBatchFiles.Columns[12].Width = 0; // hide the "already processed" column
			lstBatchFiles.Columns[13].Width = 0;
			lstBatchFiles.Columns[14].Width = 0;
			lstBatchFiles.ResumeLayout();
			if(lstBatchFiles.Items.Count == 0){
				MessageBox.Show("There are no unprocessed files available for processing", "No Files For Processing",MessageBoxButtons.OK, MessageBoxIcon.Information);
				btnUploadRides.Enabled = false;
			}
		}
		
		void LstBatchFilesMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				ActivityName actName = new ActivityName(
					lstBatchFiles.SelectedItems[0].SubItems[3].Text, // activity name
					lstBatchFiles.SelectedItems[0].SubItems[4].Text, // activity notes
					lstBatchFiles.SelectedItems[0].SubItems[5].Text == "Y" ? true : false, // activity is commute
					lstBatchFiles.SelectedItems[0].SubItems[6].Text == "Y" ? true : false, // activity is stationary trainer (turbo)
					_mainFrm._m_dbConnection,
					false,0,true,
					cbkProviderStrava.Checked,
					_mainFrm,
					lstBatchFiles.SelectedItems[0].SubItems[13].Text.Replace("b","")
				);
				// if OK, set the activity name in the database
				if(actName.ShowDialog() == DialogResult.OK){
					lstBatchFiles.SuspendLayout();
					lstBatchFiles.SelectedItems[0].SubItems[3].Text = actName._activityName;
					lstBatchFiles.SelectedItems[0].SubItems[4].Text = actName._activityNotes;
					lstBatchFiles.SelectedItems[0].SubItems[5].Text = actName._activityIsCommute ? "Y" : "";
					lstBatchFiles.SelectedItems[0].SubItems[6].Text = actName._activityIsStationaryTrainer ? "Y" : "";
					
					lstBatchFiles.SelectedItems[0].SubItems[13].Text = actName.stravaGearId;
					//lstBatchFiles.SelectedItems[0].SubItems[14].Text = actName.stravaGearName;
					ResizeListView(lstBatchFiles);
					
					lstBatchFiles.Columns[0].Width=30;
					lstBatchFiles.Columns[0].TextAlign = HorizontalAlignment.Left;
					lstBatchFiles.Columns[4].Width=50;
					//
					lstBatchFiles.Columns[7].Width=32;
					lstBatchFiles.Columns[8].Width=32;
					lstBatchFiles.Columns[9].Width=32;
					lstBatchFiles.Columns[10].Width=32;
					lstBatchFiles.Columns[11].Width=0; // hide the full file path column
					lstBatchFiles.Columns[12].Width = 0; // hide the "already processed" column
					lstBatchFiles.Columns[13].Width = 0;
					lstBatchFiles.Columns[14].Width = 0;
					lstBatchFiles.ResumeLayout();
				}
			}
			else{
				//if(_bIsProcessingComplete){
				ListViewHitTestInfo lvhit = lstBatchFiles.HitTest(e.Location);
				prgStatus.Text = lvhit.SubItem.Text;
				
				if(lvhit.SubItem.Text.Length >= 7 && lvhit.SubItem.Text.Substring(0,7) == "http://"){
					Process.Start(lvhit.SubItem.Text);
				}
			}
		}
		
		void BtnUploadRidesClick(object sender, EventArgs e)
		{
			
			if(MessageBox.Show("Are you sure you wish to proceed and upload these activities, and that you have set any `activity name` and `activity notes` that you require ?", "Batch Processing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
				((Button)sender).Enabled = false;
				_bIsProcessingBatch = true;
				_batchCurrentIdx = 0;
				
				SetControlPropertyThreadSafe(pnlProviders, "Enabled", false);
				SetControlPropertyThreadSafe(prgProgress, "Maximum", lstBatchFiles.Items.Count);
				SetControlPropertyThreadSafe(prgProgress, "Value", 0);
				
				SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,0, "indicator", "");
				_mainFrm._bIsBatchProcessing = true;
				
				string activityName = lstBatchFiles.Items[_batchCurrentIdx].SubItems[3].Text;
				string activityNotes= lstBatchFiles.Items[_batchCurrentIdx].SubItems[4].Text;
				// convert quotes to backticks in the activity notes / name to avoid it breaking the json uploaded, 
				// and possibility of sql injection - although this is probably negated by using Parameterised Queries
				// so may not strictly be necessary. App seems to hang though when quotes are present, and not sure where
				// the issue lies. This should hopefully provide a short-term(ish) fix.
				activityNotes = activityNotes.Replace("\"","`").Replace("'","`");
				activityName  = activityName.Replace("\"","`").Replace("'","`");
				
				_mainFrm.openSelectedFile(
					_batchCurrentIdx, 
					lstBatchFiles.Items[_batchCurrentIdx].SubItems[11].Text,	// file name
					activityName,
					activityNotes,
					//lstBatchFiles.Items[_batchCurrentIdx].SubItems[3].Text,		// activity name
					//lstBatchFiles.Items[_batchCurrentIdx].SubItems[4].Text,		// activity notes
					lstBatchFiles.Items[_batchCurrentIdx].SubItems[5].Text == "Y" ? true : false, // activity is commute
					lstBatchFiles.Items[_batchCurrentIdx].SubItems[6].Text == "Y" ? true : false, // activity is stationary trainer
					0,
					lstBatchFiles.Items[_batchCurrentIdx].SubItems[13].Text // strava bike id
				);
			}
		}
		
		void BatchFormClosing(object sender, FormClosingEventArgs e)
		{
			if(_bIsProcessingBatch){
				MessageBox.Show("Close is disabled as a batch is currently being processed");
				e.Cancel = true;
			}
			else{
				_mainFrm.setEndOfBatch();
			}
		}
		
		public void responseFileOpened()
		{
			_mainFrm.processOpenedFile();
		}
		
		public void setUploadStatus(string provider, string status, string value="")
		{
			switch(provider){
				case "runkeeper":
					SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,7,status, value);
					break;
				case "strava":
					SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,8,status, value);
					break;
				case "garmin":
					SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,9,status, value);
					break;
				case "rwgps":
					SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,10,status, value);
					break;
			}
			SetControlPropertyThreadSafe(prgStatus, "Text", status);
		}
		
		public void responseFileProcessed()
		{
			// check to see if there is another item in the queue to be processed
			SetControlPropertyThreadSafe(prgProgress, "Value", _batchCurrentIdx+1);
			if(_batchCurrentIdx < lstBatchFiles.Items.Count-1){
				// mark current item as done - change colour
				SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,0, "completed", "");
				_batchCurrentIdx ++;			
				SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,0, "indicator", "");
				_mainFrm.openSelectedFile(_batchCurrentIdx, 
				                          GetListViewItemValue(lstBatchFiles,_batchCurrentIdx, 11),	// filename
				                          GetListViewItemValue(lstBatchFiles, _batchCurrentIdx, 3),	// activity name 
				                          GetListViewItemValue(lstBatchFiles, _batchCurrentIdx, 4),	// activity notes
				                          ((string)GetListViewItemValue(lstBatchFiles, _batchCurrentIdx,5)) == "Y" ? true : false, // activity is commute
				                          ((string)GetListViewItemValue(lstBatchFiles, _batchCurrentIdx,6)) == "Y" ? true : false  // activity is stationary trainer
				                         );
			}
			else{
				SetListViewItemValue(lstBatchFiles,_batchCurrentIdx,0, "completed", "");
				_mainFrm._bIsBatchProcessing = false;
				_bIsProcessingBatch = false;
				_mainFrm.setEndOfBatch();
				MessageBox.Show("Batch Processing Complete");
				_bIsProcessingComplete = true;
				SetControlPropertyThreadSafe(prgStatus,"Text", "Batch Processing Completed.");
			}
		}
		
		public void setUploadProgressStatus(string status)
		{
			SetControlPropertyThreadSafe(prgStatus, "Text", status);
		}
		
		
		void CbkProviderCheckStateChanged(object sender, EventArgs e)
		{
			_mainFrm.SetProviderState("Runkeeper", cbkProviderRunkeeper.Checked);
			_mainFrm.SetProviderState("Strava", cbkProviderStrava.Checked);
			_mainFrm.SetProviderState("Garmin", cbkProviderGarmin.Checked);
			_mainFrm.SetProviderState("RWGPS", cbkProviderRideWithGps.Checked);
		}
		
		void CbkProviderStravaCheckedChanged(object sender, EventArgs e)
		{
			
		}
	}
}
