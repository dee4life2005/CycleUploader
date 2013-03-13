/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 03/03/2013
 * Time: 22:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using FileHelpers;
using Microsoft.Win32;	
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.IO;
using System.Text;


namespace TCX_Parser
{
	/// <summary>
	/// Description of GarminConnect.
	/// </summary>
	public partial class GarminConnect : Form
	{
		public string _gc_user;
		public string _gc_password;
		
		public GarminConnect()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_gc_user = "";
			_gc_password = "";
		}
		
		private string ToQueryString(NameValueCollection nvc)
		{
		  return string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
		}
		
		void BtnSaveLoginDetailsClick(object sender, EventArgs e)
		{
			GarminConnectAPI gc = new GarminConnectAPI();
			if(gc.Login(txtUserName.Text, txtPassword.Text)){
				// try to open registry key for application
				RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
				if(key == null){
					Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
					key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
				}
				key.SetValue("gc_user",txtUserName.Text);
				key.SetValue("gc_password",txtPassword.Text);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else{
				MessageBox.Show("GarminConnect: Login failed. Incorrect username / password ?");
			}
		}
	}
}
