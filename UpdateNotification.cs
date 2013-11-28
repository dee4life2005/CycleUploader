/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 10/04/2013
 * Time: 13:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CycleUploader
{
	/// <summary>
	/// Description of UpdateNotification.
	/// </summary>
	public partial class UpdateNotification : Form
	{
		public UpdateNotification(string type, string currentVersion, string latestVersion, string changeLog)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			pbIcon.Image = System.Drawing.SystemIcons.Question.ToBitmap();
			tCurrentVersion.Text = currentVersion;
			tLatestVersion.Text = latestVersion;
			tChangeLog.Text = changeLog.Replace("\n", System.Environment.NewLine).Substring(3);
			// inform user that update is available to be downloaded
			if(type == "download"){
				this.Text = "Software Update Available";	
				this.tLabel.Text = "A software update is available for download";
				this.tQuestion.Text = "Do you want to download this update now ?";
			}
			// inform user that update is available to be installed
			else if(type == "install"){
				this.Text = "Software Update Downloaded, Confirm Install";
				this.tLabel.Text = "A software update has been downloaded and awaiting installation";
				this.tQuestion.Text = "Do you want to install this update now ?";
			}
		}
		
		void UpdateNotificationLoad(object sender, EventArgs e)
		{
			
		}
		
		void BtnNoClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
		}
		
		void BtnYesClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
		}
	}
}
