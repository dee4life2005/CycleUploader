/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 01/03/2013
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Stravan;
using Stravan.Json;

using Microsoft.Win32;

namespace TCX_Parser
{
	/// <summary>
	/// Description of StravaConnect.
	/// </summary>
	public partial class StravaConnect : Form
	{
		public string _email;
		public string _password;
		public string _token;
		public string _name;
		public int _user_id;
		
		public StravaConnect()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnStravaLoginTestClick(object sender, EventArgs e)
		{
			_email = txtStravaUsername.Text;
			_password = txtStravaPassword.Text;
			
			try{
				StravaWebClient swc = new StravaWebClient();
				AuthenticationService auth = new AuthenticationService(swc);
				
				AuthenticationV2 authV2 = auth.LoginV2(_email,_password);
				if(authV2.Token != "")
				{
					// try to open registry key for application
					RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
					if(key == null){
						Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
						key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
					}
					key.SetValue("strava_token",authV2.Token);
					key.SetValue("strava_user_id", authV2.Athlete.Id);
					key.SetValue("strava_name", authV2.Athlete.Name);
					key.SetValue("strava_username", _email);
					key.SetValue("strava_password",_password);
					
					_token = authV2.Token;
					_name = authV2.Athlete.Name;					
					_user_id = authV2.Athlete.Id;
					
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch{
				MessageBox.Show("Strava: login failed");
			}
							
		}
	}
}
