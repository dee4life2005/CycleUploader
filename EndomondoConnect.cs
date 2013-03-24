/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 12:53
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
	/// Description of EndomondoConnect.
	/// </summary>
	public partial class EndomondoConnect : Form
	{
		public EndomondoAPI endo;
		string _GUID;

		public EndomondoConnect(string GUID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_GUID = GUID;
			endo = new EndomondoAPI();
		}
		
		void BtnLoginTestClick(object sender, EventArgs e)
		{
			if(endo.login(_GUID, txtUsername.Text, txtPassword.Text))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else{
				MessageBox.Show("Endomondo: Login Failed, Incorrect Username / Password.\nCannot connect this application to your account at this time.");
			}
			
		}
	}
}
