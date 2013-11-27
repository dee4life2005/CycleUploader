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
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Json;

namespace CycleUploader
{
	/// <summary>
	/// Description of StravaConnectV3.
	/// </summary>
	public partial class StravaConnectV3 : Form
	{
		public string _strava_code;
		public string strava_auth_token;
		public string _strava_access_token;
		public StravaConnectV3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			strava_auth_token = "";
		}
		
		void BtnRunkeeperLoginTestClick(object sender, EventArgs e)
		{
						
 			
		}
		
		void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			string _authentication_token;
			string client_id = "235";
			string client_secret = "10a780a7b221b6e1c962a4255de67799a21980f4";
			string CodeIdentifier = "code=";
			string Code = "";
			
			txtUrl.Text = webBrowser1.Url.PathAndQuery;
			
 			if (webBrowser1.Url.Query.Contains(CodeIdentifier)){
				Code = webBrowser1.Url.Query.Substring(webBrowser1.Url.Query.IndexOf(CodeIdentifier) + CodeIdentifier.Length);
				System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.strava.com/oauth/token");
				httpWebRequest.Method = "POST";
				httpWebRequest.Timeout = 5000;
			
				// build the url encoded form post data
				string postData = string.Format("client_id={0}&client_secret={1}&code={2}", client_id, client_secret, Code);
				byte[] bytes = aSCIIEncoding.GetBytes(postData);
			
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentLength = (long)bytes.Length;
				System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
					if (responseStream != null)
					{
						System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
						string text = streamReader.ReadToEnd();

						dynamic json = JsonValue.Parse(text);
						_strava_access_token = json.access_token;
					}
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			
		}
		
		void StravaConnectV3Load(object sender, EventArgs e)
		{
			string url = "https://www.strava.com/oauth/authorize?client_id=235&response_type=code&redirect_uri=http://www.google.co.uk/&approval_prompt=force&scope=write";
			
			webBrowser1.Navigate(url);
			txtUrl.Text = url;
		}
	}
}
