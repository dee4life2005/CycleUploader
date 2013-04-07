/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 06/03/2013
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using FileHelpers;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Globalization;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Json;
using Microsoft.CSharp;
using System.Data.SQLite;

namespace CycleUploader
{
	public class garminImportResult
	{
		public garminImportResultDetailed detailedImportResult;
	}
	
	public class garminImportResultMsg
	{
		public string content;
		public string code;
	}
	
	public class garminImportResultRecord
	{
		public string internalId;
		public string externalId;
		public garminImportResultMsg[] messages;
	}
	
	public class garminImportResultDetailed
	{
		public string uploadId;
		public string owner;
		public string processingTime;
		public string ipAddress;
		public string fileName;
		
		public garminImportResultRecord[] successes;
		public garminImportResultRecord[] failures;
	}
	
	public class garminMetricsResult
	{
		public garminMetric[] userMetrics;
	}
	public class garminMetric
	{
		
		public string totalActivities;
		public string totalDistance;
		public string totalDuration;
		public string totalCalories;
		public string totalElevationGain;
		public string month;
	}
	
	public class GarminActivityListItem
	{
		public int activityId;
		public string activityName;
		public string deviceName;
		public string uploadDate;
		public string elevationGain;
		public string cadenceMax;
		public string heartRateMax;
		public string speedMax;
		public string distance;
		public string duration; // moving time
		public string durationElapsed; // total time
		public string cadenceAvg;
		public string heartRateAvg;
		public string speedAvg;
		public string tempAvg;
		public string tempMin;
		public string startTime;
	}
	
	public class GarminConnectAPI
	{
		private const string SSLProtocal = "https://";
		private const string SSLServerHost = "connect.garmin.com";
		private const int SSLServerPort = 443;
		private const string Protocal = "http://";
		private const string ServerHost = "connect.garmin.com";
		private const int ServerPort = 80;
		private const string SignInURL = "/signin";
		private const string ActivityURL = "/activities";
		private bool _init;
		private bool _loggedIn;
		private CookieCollection _cookieCollection;
		public string LastOutput = "";
		public string LastDataOutput = "";
		public string _username;
		public GarminConnectAPI()
		{
			this._cookieCollection = new CookieCollection();
		}
		public void Initialise()
		{
			//ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)System.Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
			//ServicePointManager.ServerCertificateValidationCallback = Nothing;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://connect.garmin.com:" + 443 + "/signin");
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			httpWebRequest.CookieContainer = new CookieContainer();
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				this._cookieCollection = httpWebResponse.Cookies;
			}
			this._init = true;
		}
		public bool Login(string username, string password)
		{
			if (!this._init)
			{
				this.Initialise();
			}
			_username = username;
			System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
			string s = string.Format("login=login&login:loginUsernameField={0}&login%3Apassword={1}&login:signInButton=Sign+In&javax.faces.ViewState=j_id1", username, password);
			byte[] bytes = aSCIIEncoding.GetBytes(s);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://connect.garmin.com:" + 443 + "/signin");
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = (long)bytes.Length;
			httpWebRequest.CookieContainer = this.GetCookieContainer();
			httpWebRequest.Timeout = 10000;
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
					this.LastOutput = text;
					bool flag = text.IndexOf("Invalid username/password combination.", System.StringComparison.Ordinal) >= 0;
					bool flag2 = text.IndexOf("Welcome, " + username, System.StringComparison.Ordinal) >= 0;
					this._loggedIn = (!flag && flag2);
					return this._loggedIn;
				}
			}
			return false;
		}
		
		public garminMetric[] GetMetrics()
		{
			string url = string.Format("http://connect.garmin.com/proxy/userstats-service/statistics/monthly/{0}",_username);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			httpWebRequest.Method = "GET";
			httpWebRequest.CookieContainer = this.GetCookieContainer();
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string json = streamReader.ReadToEnd();
					
					garminMetricsResult gOut = new JavaScriptSerializer().Deserialize<garminMetricsResult>(json);
					
					return gOut.userMetrics;
				}
			}
			return null;
		}
		
		
		
		
		public void UploadFile(string file, string activity_name, SQLiteConnection dbConnection, int fileId, string activityName, string activityNotes, Batch activityBatch)
		{
			
			int wId = 0;
			string url = "http://connect.garmin.com/proxy/upload-service-1.1/json/upload/";
			string file_content_type = "application/octet-stream";
			string file_param_name = "data";
			string file_extension = Path.GetExtension(file);
			url += file_extension;
			bool bSetName = false;
			
			NameValueCollection nvc = new NameValueCollection();
			
			nvc.Add("responseContentType", "text/html");
			
	        Debug.Write(string.Format("Uploading {0} to {1}", file, url));
	        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
	        byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
	
	        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
	        wr.ContentType = "multipart/form-data; boundary=" + boundary;
	        wr.Method = "POST";
	        wr.KeepAlive = true;
	        wr.ServicePoint.Expect100Continue = false;
	        wr.CookieContainer = this.GetCookieContainer();
	        
	        wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
	
	        Stream rs = wr.GetRequestStream();
	
	        string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
	        foreach (string key in nvc.Keys)
	        {
	            rs.Write(boundarybytes, 0, boundarybytes.Length);
	            string formitem = string.Format(formdataTemplate, key, nvc[key]);
	            byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
	            rs.Write(formitembytes, 0, formitembytes.Length);
	        }
	        rs.Write(boundarybytes, 0, boundarybytes.Length);
	
	        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
	        string header = string.Format(headerTemplate, file_param_name, file, file_content_type);
	        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
	        rs.Write(headerbytes, 0, headerbytes.Length);
	
	        //byte[] filedata = System.Text.Encoding.ASCII.GetBytes(file);
	        //rs.Write(filedata, 0, filedata.Length);
	        FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
	        byte[] buffer = new byte[4096];
	        int bytesRead = 0;
	        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) {
	            rs.Write(buffer, 0, bytesRead);
	        }
	        fileStream.Close();
	        
	        ((MainForm)Application.OpenForms[0]).setUpdateRideMsg("garmin","Uploading, waiting for response");
	        
	        if(activityBatch != null){
	        	activityBatch.setUploadProgressStatus("Garmin: Uploading activity, waiting for response");
	        }
	        	
	        byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
	        rs.Write(trailer, 0, trailer.Length);
	        rs.Close();
	
	        WebResponse wresp = null;
	        try {
	            wresp = wr.GetResponse();
	            Stream stream2 = wresp.GetResponseStream();
	            StreamReader reader2 = new StreamReader(stream2);
	            string json = reader2.ReadToEnd();
	            //Debug.Write(string.Format("File uploaded, server response is: {0}", json));
	            
	            garminImportResult gOut = new JavaScriptSerializer().Deserialize<garminImportResult>(json);
	            
	            if(gOut.detailedImportResult.successes.Length > 0){
	            	garminImportResultRecord sRec = gOut.detailedImportResult.successes[0];
	            	((MainForm)Application.OpenForms[0]).setUpdateRideMsg("garmin","Ride Uploaded Successfully");
	            	((MainForm)Application.OpenForms[0]).setUpdateRideId("garmin",sRec.internalId);
	            	((MainForm)Application.OpenForms[0]).setNewActivityLink("garmin",sRec.internalId, string.Format("http://connect.garmin.com/activity/{0}",sRec.internalId));
	            	((MainForm)Application.OpenForms[0]).setUpdateRideImg("garmin",Image.FromFile("success-icon.png"));
	            	if(activityBatch != null){
	            		activityBatch.setUploadProgressStatus("Garmin: Uploaded Successfully");
	            	}
	            	
	            	wId = Convert.ToInt32(sRec.internalId);
	            	
	            	SQLiteCommand cmd = new SQLiteCommand(dbConnection);
					string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadGarmin = \"{0}\" where idFile = {1}", 
					                           string.Format("http://connect.garmin.com/activity/{0}",sRec.internalId), 
					                           fileId,
					                           activityName, 
					                           activityNotes
					                          );
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
	            	
	            	bSetName = true;
	            	
	            	if(activityBatch != null){
	            		activityBatch.setUploadStatus("garmin","success",string.Format("http://connect.garmin.com/activity/{0}",sRec.internalId));
	            	}
	            }
	            else if(gOut.detailedImportResult.failures.Length > 0){
	            	garminImportResultRecord fRec = gOut.detailedImportResult.failures[0];
	            	
	            	((MainForm)Application.OpenForms[0]).setUpdateRideMsg("garmin","Activity data wasn`t accepted. Code="+fRec.messages[0].code+", Msg=" + fRec.messages[0].content);
	            	((MainForm)Application.OpenForms[0]).setUpdateRideImg("garmin",Image.FromFile("failure-icon.png"));
	            	if(activityBatch != null){
	            		activityBatch.setUploadStatus("garmin","not accepted", "Garmin: Activity data wasn`t accepted. Code="+fRec.messages[0].code+", Msg=" + fRec.messages[0].content);
	            	}
	            }
	        } catch(Exception ex) {
	        	Debug.Write("Error uploading file", ex.ToString());
	        	((MainForm)Application.OpenForms[0]).setUpdateRideMsg("garmin","Exception raised while processing upload request. " + ex.ToString());
	        	((MainForm)Application.OpenForms[0]).setUpdateRideImg("garmin",Image.FromFile("failure-icon.png"));
	        	if(activityBatch != null){
	        		activityBatch.setUploadStatus("garmin","exception", "Garmin: Exception raised while processing upload request. " + ex.ToString());
	        	}
	            if(wresp != null) {
	                wresp.Close();
	                wresp = null;
	            }
	        } finally {
	            wr = null;
	        }
	        	        
	        // Set the workout name if the activity was successfully created above
	        if(bSetName){
		        
	        	// Build the Http Request, with specified headers - including preserving the cookies (this.GetCookieContainer)
		        string wUrl = string.Format("http://connect.garmin.com/proxy/activity-service-1.2/json/name/{0}",wId);
		        string wParams = "value=" + HttpUtility.UrlEncode(activity_name);
		        
		        System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
		        byte[] wBytes = aSCIIEncoding.GetBytes(wParams);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(wUrl);
				httpWebRequest.Proxy = null;
				httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentLength = (long)wBytes.Length;
				httpWebRequest.CookieContainer = this.GetCookieContainer();
				System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(wBytes, 0, wBytes.Length);
				requestStream.Close();
				
				// Get the response to the web request, and read all of the data received
				// TODO: parse the response to check for errors - just ignore for now as it's not critical if this step fails as the activity 
				// will still have been saved at this point so activity name could be changed manually if necessary
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
					if (responseStream != null)
					{
						System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
						string text = streamReader.ReadToEnd();
						this.LastOutput = text;
					}
				}
	        }
	    }
				
		public List<GarminActivityListItem> GetLastActivities(ViewerGarmin vg)
		{
			List<GarminActivityListItem> activities = new List<GarminActivityListItem>();
			if (!this._loggedIn)
			{
				MessageBox.Show("GarminConnect: Login Failed. Try again later.");
			}
			else{
				
				int totalActivities = 0;
				int totalPages = 0;
				int perPage = 50;
				int currentPage = -1;
				int currentPageCount = 0;
				string url;
				
				vg.initialisePbLoadingStatus("Retrieving Activity Information...",0,0);
				
				do{
						currentPage++;
						url = string.Format("http://connect.garmin.com:" + 80 + "/proxy/activity-search-service-1.2/json/activities?start={0}&limit={1}",
						                    currentPage*perPage, 
						                    perPage
						                   );
						HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
						httpWebRequest.Proxy = null;
						httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
						httpWebRequest.Method = "GET";
						httpWebRequest.CookieContainer = this.GetCookieContainer();
						
						HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
						System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
						System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
						
						dynamic jsonResult = JsonValue.Parse(streamReader.ReadToEnd());
						
						totalActivities = (int)jsonResult.results.totalFound;
						totalPages = (int)jsonResult.results.totalPages;
						currentPageCount = jsonResult.results.activities.Count;
										
						int a;
						vg.setPbLoadingStatus(currentPage+1, totalPages, string.Format("Retrieving Activity Information...Page {0} of {1}",currentPage+1,totalPages));
						
						for(a = 0; a < jsonResult.results.activities.Count; a++){
							GarminActivityListItem gi = new GarminActivityListItem();
							//JsonValue activitySummary = (JsonValue)jsonResult.results.activities[a].activity.activitySummary;
							gi.activityId = (int)jsonResult.results.activities[a].activity.activityId;
							gi.activityName = (string)jsonResult.results.activities[a].activity.activityName;
							gi.deviceName = (string)jsonResult.results.activities[a].activity.device.display;
							gi.uploadDate = (string)jsonResult.results.activities[a].activity.uploadDate.display;
							gi.startTime = (string)jsonResult.results.activities[a].activity.activitySummary.BeginTimestamp.value;
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("GainElevation")){
								gi.elevationGain = (string)jsonResult.results.activities[a].activity.activitySummary.GainElevation.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("MaxBikeCadence")){
								gi.cadenceMax = (string)jsonResult.results.activities[a].activity.activitySummary.MaxBikeCadence.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("MaxHeartRate")){
								gi.heartRateMax = (string)jsonResult.results.activities[a].activity.activitySummary.MaxHeartRate.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("MaxSpeed")){
								gi.speedMax = (string)jsonResult.results.activities[a].activity.activitySummary.MaxSpeed.withUnitAbbr;
							}
							gi.distance = (string)jsonResult.results.activities[a].activity.activitySummary.SumDistance.withUnitAbbr;
							gi.duration = (string)jsonResult.results.activities[a].activity.activitySummary.SumDuration.withUnitAbbr;
							gi.durationElapsed= (string)jsonResult.results.activities[a].activity.activitySummary.SumElapsedDuration.withUnitAbbr;
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("WeightedMeanBikeCadence")){
								gi.cadenceAvg = (string)jsonResult.results.activities[a].activity.activitySummary.WeightedMeanBikeCadence.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("WeightedMeanHeartRate")){
								gi.heartRateAvg = (string)jsonResult.results.activities[a].activity.activitySummary.WeightedMeanHeartRate.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("WeightedMeanMovingSpeed")){
								gi.speedAvg = (string)jsonResult.results.activities[a].activity.activitySummary.WeightedMeanMovingSpeed.withUnitAbbr;
							}
							
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("WeightedMeanAirTemperature")){
								gi.tempAvg = (string)jsonResult.results.activities[a].activity.activitySummary.WeightedMeanAirTemperature.withUnitAbbr;
							}
							if(jsonResult.results.activities[a].activity.activitySummary.ContainsKey("MinAirTemperature")){
								gi.tempMin = (string)jsonResult.results.activities[a].activity.activitySummary.MinAirTemperature.withUnitAbbr;
							}
							activities.Add(gi);
							
						}
					}while((currentPage*perPage)+currentPageCount < totalActivities);
				//}
				//catch(Exception ex){
				//	MessageBox.Show(ex.ToString());
				//}
				
				return activities;
			}
			return null;
		}

		private CookieContainer GetCookieContainer()
		{
			CookieContainer cookieContainer = new CookieContainer();
			foreach (Cookie cookie in this._cookieCollection)
			{
				cookieContainer.Add(cookie);
			}
			return cookieContainer;
		}
		public static void ConnectSSL()
		{
		}
	}
}
