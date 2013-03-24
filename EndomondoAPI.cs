/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Win32;

namespace CycleUploader
{
	public class endomondoActivityItems
	{
		public endomondoActivity[] data;
	}
	
	public class endomondoActivity
	{
		public double duration_sec;
		public double heart_rate_bpm_avg;
		public double cadence_avg_rpm;
		public int sport;
		public double speed_kmh_avg;
		public int feed_id;
		public int id;
		public double altitude_m_max;
		public int heart_rate_bpm_max;
		public double altitude_m_min;
		public string name;
		public string start_time;
		public double calories;
		public double speed_kmh_max;
		public double distance_km;
		public bool has_points;
	}
	
	/// <summary>
	/// Description of EndomondoAPI.
	/// </summary>
	public class EndomondoAPI
	{
		public string _authToken;
		public string _secureToken;
		public string _displayName;
		public string _userId;

		public EndomondoAPI()
		{
			_authToken = "";
			_secureToken = "";
			_displayName = "";
			_userId = "";
		}
		
		public bool login(string GUID, string username, string password)
		{
			CookieContainer cookies = new CookieContainer();
			string url = string.Format("https://api.mobile.endomondo.com/mobile/auth?v=2.4&action=PAIR&deviceId={0}&email={1}&password={2}&country=GB",
			                          GUID,
			                          username,
			                          password
			                       );
			
			System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			httpWebRequest.CookieContainer = cookies;
			httpWebRequest.Method = "GET";
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					if(text.IndexOf("OK") >=0){
						string[] lines = text.Split('\n');
						for(int i = 0; i < lines.Length; i++){
							string[] line_values = lines[i].Split('=','1');
							switch(line_values[0]){
								case "authToken":
									_authToken = line_values[1];
									break;
								case "displayName":
									_displayName = line_values[1];
									break;
								case "userId":
									_userId = line_values[1];
									break;
								case "secureToken":
									_secureToken = line_values[1];
									break;
							}
						}
						
						// update the registry with these values
						// try to open registry key for application
						RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
						if(key == null){
							Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\CycleUploader\\");
							key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\CycleUploader",true);
						}
						key.SetValue("endomondo_authToken",_authToken);
						key.SetValue("endomondo_displayName", _displayName);
						key.SetValue("endomondo_userId", _userId);
						key.SetValue("endomondo_secureToken", _secureToken);
						
						return true;
					}
				}
			}
			return false;
		}
	}
}
