/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/02/2013
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using Moq;
using HealthGraphNet;
using HealthGraphNet.Models;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;

namespace CycleUploader
{
	/// <summary>
	/// Description of RunkeeperConnect.
	/// </summary>
	public partial class RunkeeperConnect : Form
	{
		public string _runkeeper_code;
		public string rk_auth_token;
		public RunkeeperConnect()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			rk_auth_token = "";
		}
		
		void BtnRunkeeperLoginTestClick(object sender, EventArgs e)
		{
						
 			
		}
		
		void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			string client_id = "e54e428e76574fb1b5ae856f37befed2";
			string client_secret = "d1d13b891ffa44c891ff41f74d0a6951";
			string CodeIdentifier = "code=";
			string Code = "";
			
			txtUrl.Text = webBrowser1.Url.PathAndQuery;
			if (webBrowser1.Url.Query.Contains(CodeIdentifier)){
				Code = webBrowser1.Url.Query.Substring(webBrowser1.Url.Query.IndexOf(CodeIdentifier) + CodeIdentifier.Length);
				AccessTokenManager tm = new AccessTokenManager(client_id, client_secret, "https://www.facebook.com/connect/login_success.html");
				tm.InitAccessToken(Code);
				rk_auth_token = tm.Token.AccessToken;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		
		void RunkeeperConnectLoad(object sender, EventArgs e)
		{
			string client_id = "e54e428e76574fb1b5ae856f37befed2";
			//string client_secret = "d1d13b891ffa44c891ff41f74d0a6951";
			
			string url = "https://runkeeper.com/apps/authorize?client_id=" + client_id + "&response_type=code&redirect_uri=https://www.facebook.com/connect/login_success.html";
			
			webBrowser1.Navigate(url);
			txtUrl.Text = url;
		}
	}
}
