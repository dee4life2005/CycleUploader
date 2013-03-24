/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 07/03/2013
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Win32;

namespace CycleUploader
{
	/// <summary>
	/// Description of RideWithGpsConnect.
	/// </summary>
	public partial class RideWithGpsConnect : Form
	{
		public string _email;
		public string _password;
		public string _token;
		private RideWithGpsAPI rwgps;
		
		public RideWithGpsConnect(ref RideWithGpsAPI rw)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_email = "";
			_password = "";
			_token = "";
			rwgps = rw;
		}
		
		void BtnLoginTestClick(object sender, EventArgs e)
		{
			_email = txtUsername.Text;
			_password = txtPassword.Text;
						
			if(rwgps.login(txtUsername.Text, txtPassword.Text)){
				// try to open registry key for application
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
				if(key == null){
					Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
					key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
				}
				key.SetValue("ridewithgps_email", _email);
				key.SetValue("ridewithgps_password", _password);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else{
				MessageBox.Show("Login FAILED. FRM. Incorrect username / password perhaps ?");
			}
		}
	}
}
