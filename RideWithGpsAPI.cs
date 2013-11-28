/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 07/03/2013
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Json;
using Microsoft.CSharp;
using ZedGraph;
using System.Data.SQLite;

namespace CycleUploader
{
	
	// APIKEY : jnas82ns 
	// http://ridewithgps.com/apitest/generic.html
	
	public class RideWithGpsActivityListItem
	{
		public int id;
		public string name;
		public string location_string;
		public string created_at;
		public string departed_at;
		public double moving_time;
		public double avg_power;
		public double avg_speed;
		public double distance;
		public double elevation_gain;
	}
	
	public class RideWithGpsProfile
	{
		public string display_name;
		public string profile_area;
		public string member_since;
		public string dob;
		public double total_trip_distance;
		public double total_trip_duration;
		public double total_trip_elevation;
		public int total_trip_count;
		public string profile_photo_url;
	}
	
	public class RideWithGpsActivitySummary
	{
		public string avgCadence;
		public string avgSpeed;
		public string avgHeartRate;
		public string calories;
		public string name;
		public string elevationGain;
		public string distance;
		public string durationTotal;
		public string durationMoving;
		public string notes;
		public List<RideWithGpsMileSplit> mileSplits;
	}
	
	public class RideWithGpsMileSplit
	{
		public string label;
		public string speed;
		public string pace;
	}
	
	
	/// <summary>
	/// Description of RideWithGpsAPI.
	/// </summary>
	public class RideWithGpsAPI
	{
		private bool _isLoggedIn;
		private string _authentication_token; // authentication token;
		private CookieContainer _cookies;
		private int _userId;
		
		private string _user;
		private string _password;
		
		public RideWithGpsProfile _profile;
		
		public RideWithGpsAPI()
		{
			_isLoggedIn = false;
			_cookies = new CookieContainer();
			_authentication_token = "";
			_userId = 0;
			_profile = new RideWithGpsProfile();
		}
		
		public bool isLoggedIn()
		{
			return _isLoggedIn;
		}
		
		public string getAuthToken()
		{
			return _authentication_token;
		}
		
		public bool login(string username, string password)
		{
			_user = username;
			_password = password;
			
			System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ridewithgps.com:" + 80 + "/login");
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			httpWebRequest.CookieContainer = this._cookies;
			httpWebRequest.Method = "POST";
			httpWebRequest.Timeout = 5000;
			
			// build the url encoded form post data
			string postData = string.Format("login[email]={0}&login[password]={1}", username, password);
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
					if(text.IndexOf("Incorrect username/password, please try again") != -1){
						this._isLoggedIn = false;
					}
					else{
						// check to see if there is a "csrf_token" in the response
						Match KeywordMatch = Regex.Match(text, "<meta content=\"([^<]*)\" name=\"csrf-token\" />", RegexOptions.IgnoreCase | RegexOptions.Multiline);
						if(KeywordMatch.Success){
	                		_authentication_token = KeywordMatch.Groups[1].Value;
	                		this._isLoggedIn = true;
						}
						else{
							this._isLoggedIn = false;
						}
						
						// extract the userId
						//Match KeywordMatchUser = Regex.Match(text, "<a class='profile' href='/users/([^<]*)/activities'>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
						Match KeywordMatchUser = Regex.Match(text, "<a class='brand' href='/users/([^<]*)' ", RegexOptions.IgnoreCase | RegexOptions.Multiline);
						if(KeywordMatchUser.Success){
							_userId = Convert.ToInt32(KeywordMatchUser.Groups[1].Value);
						}
						
						// extract the profile photo path
						Match KeywordMatchPhoto = Regex.Match(text, "class=\"profile_photo\" src=\"([^<]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
						if(KeywordMatchPhoto.Success){
							_profile.profile_photo_url = KeywordMatchPhoto.Groups[1].Value;
						}
						
						Match KeywordMatchProfile = Regex.Match(text, "rwgps.ns" + Regex.Escape("(") + "'config', ([^<]*)" + Regex.Escape("});"), RegexOptions.IgnoreCase | RegexOptions.Multiline);
						if(KeywordMatchProfile.Success){
							try{
								dynamic jsonProfile = JsonValue.Parse(KeywordMatchProfile.Groups[1].Value);
								_profile.display_name = jsonProfile.currentUser.display_name;
								_profile.display_name = jsonProfile.currentUser.name;
								_profile.profile_area = jsonProfile.currentUser.administrative_area;
								_profile.member_since = DateTime.Parse((string)jsonProfile.currentUser.created_at).ToString("dd/MM/yyyy HH:mm");
								_profile.dob = DateTime.Parse((string)jsonProfile.currentUser.dob).ToString("dd/MM/yyyy");
								_profile.total_trip_distance = (double)jsonProfile.currentUser.total_trip_distance;
								_profile.total_trip_duration = (double)jsonProfile.currentUser.total_trip_duration;
								_profile.total_trip_elevation = (double)jsonProfile.currentUser.total_trip_elevation_gain;
								_profile.total_trip_count = (int)jsonProfile.currentUser.trips_included_in_totals_count;
							}
							catch(Exception ex){
								MessageBox.Show("RideWithGPS: Exception retrieving profile information.\r\n\r\n" + ex.Message);
							}
						}
					}
				}
			}
			return this._isLoggedIn;
		}	
				
		public void upload_activity_json(ref StringBuilder jsonData, SQLiteConnection dbConnection, int fileId, string activityName, string activityNotes, Batch activityBatch)
		{
			System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
			
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ridewithgps.com/trips.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			httpWebRequest.ServicePoint.Expect100Continue = false;
			
			byte[] jsonBytes = aSCIIEncoding.GetBytes(jsonData.ToString());
			httpWebRequest.ContentLength = jsonBytes.Length;
			
			System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
			requestStream.Write(jsonBytes, 0, jsonBytes.Length);
			requestStream.Close();
			
			try{
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					
					Match KeywordMatch = Regex.Match(text, "\"id\":([^,]*),", RegexOptions.IgnoreCase | RegexOptions.Multiline);
					if(KeywordMatch.Success){
						((MainForm)Application.OpenForms[0]).setUpdateRideMsg("ridewithgps","Ride Uploaded Successfully");
						((MainForm)Application.OpenForms[0]).setUpdateRideId("ridewithgps",KeywordMatch.Groups[1].Value);
						((MainForm)Application.OpenForms[0]).setNewActivityLink("ridewithgps",KeywordMatch.Groups[1].Value,string.Format("http://ridewithgps.com/trips/{0}",KeywordMatch.Groups[1].Value));
						((MainForm)Application.OpenForms[0]).setUpdateRideImg("ridewithgps",Image.FromFile("success-icon.png"));
						
						if(activityBatch != null){
							activityBatch.setUploadStatus("rwgps","success",string.Format("http://ridewithgps.com/trips/{0}",KeywordMatch.Groups[1].Value));
							activityBatch.setUploadProgressStatus("RideWithGps: Uploaded Succesfully");
						}
				
						SQLiteCommand cmd = new SQLiteCommand(dbConnection);
						string sql = "update File set fileActivityName = ?, fileActivityNotes = ?, fileUploadRWGPS = ? where idFile = ?";
						cmd.CommandText = sql;
						cmd.Parameters.Add(new SQLiteParameter());
						cmd.Parameters.Add(new SQLiteParameter());
						cmd.Parameters.Add(new SQLiteParameter());
						cmd.Parameters.Add(new SQLiteParameter());
						// add values to parameters
						cmd.Parameters[0].Value = activityName;
						cmd.Parameters[1].Value = activityNotes;
						cmd.Parameters[2].Value = string.Format("http://ridewithgps.com/trips/{0}",KeywordMatch.Groups[1].Value);
						cmd.Parameters[3].Value = fileId;
						
						/*string sql = string.Format("update File set fileActivityName = \"{2}\", fileActivityNotes = \"{3}\", fileUploadRWGPS = \"{0}\" where idFile = {1}", 
					                           string.Format("http://ridewithgps.com/trips/{0}",KeywordMatch.Groups[1].Value), 
					                           fileId,
					                           activityName, 
					                           activityNotes
					                          );
						cmd.CommandText = sql;
						*/
						cmd.ExecuteNonQuery();
					}
					else{
						((MainForm)Application.OpenForms[0]).setUpdateRideMsg("ridewithgps","Ride ID not found, activity may not have been accepted.");
						((MainForm)Application.OpenForms[0]).setUpdateRideImg("ridewithgps",Image.FromFile("failure-icon.png"));
						if(activityBatch != null){
							activityBatch.setUploadStatus("rwgps","error");
							activityBatch.setUploadProgressStatus("RideWithGps: Error uploading ride");
						}
					}
				}
			}
			catch(Exception ex){
				((MainForm)Application.OpenForms[0]).setUpdateRideMsg("ridewithgps","Exception raised while processing upload request. " + ex.ToString());
				((MainForm)Application.OpenForms[0]).setUpdateRideImg("ridewithgps",Image.FromFile("failure-icon.png"));
				if(activityBatch != null){
					activityBatch.setUploadStatus("rwgps","exception");
					activityBatch.setUploadProgressStatus("RideWithGps: Exception" + ex.Message);
				}
			}
		}
		
		public List<RideWithGpsActivityListItem> GetActivities(ViewerRideWithGps rw)
		{
			List<RideWithGpsActivityListItem> activities = new List<RideWithGpsActivityListItem>();
			
			// try to login to the user account if not already authenticated
			if(!isLoggedIn()){
				login(_user, _password);
			}
			
			// if logged-in then issue the requests to retrieve the activities
			if(isLoggedIn()){
				int totalActivities = 0;
				int startIndex = 0;
				int perPageCount = 30;
				int currentPage = -1;
				int currentPageCount = 0;
				int a = 0;
				int totalLoaded = 0;
				rw.initialisePbLoadingStatus("Retrieving Activity Information...",0,0);
				do{
					currentPage++;
					startIndex = currentPage * perPageCount;
					string url = string.Format("http://ridewithgps.com:" + 80 + "/users/{0}/activities.json?sort=departed_at&dir=desc&startIndex={1}&results={2}",
					                           _userId, 
					                           startIndex,
					                           perPageCount
					                          );
					
					System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
					httpWebRequest.Proxy = null;
					httpWebRequest.Credentials = CredentialCache.DefaultCredentials;	
					httpWebRequest.CookieContainer = this._cookies;
					
					// get response
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
					if(responseStream != null){
						System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
						dynamic jsonResult = JsonValue.Parse(streamReader.ReadToEnd());
						totalActivities = (int)jsonResult.totalRecords;
						currentPageCount = (int)jsonResult.recordsReturned;
						
						for(a = 0; a < jsonResult.records.Count; a++){
							totalLoaded++;
							RideWithGpsActivityListItem rwli = new RideWithGpsActivityListItem();
							rwli.id = (int)jsonResult.records[a].id;
							rwli.name = (string)jsonResult.records[a].name;
							rwli.location_string = (string)jsonResult.records[a].location_string;
							//if(jsonResult.records[a].ContainsKey("avg_power")){
							//rwli.avg_power = (double)jsonResult.records[a].avg_power;
							//}
							try{
								rwli.avg_speed = (double)jsonResult.records[a].avg_speed;
							}catch{ rwli.avg_speed = 0;}
							rwli.created_at = (string)jsonResult.records[a].created_at;
							rwli.departed_at = (string)jsonResult.records[a].departed_at;
							rwli.distance = (double)jsonResult.records[a].distance;
							rwli.elevation_gain = (double)jsonResult.records[a].elevation_gain;
							rwli.moving_time = (double)jsonResult.records[a].moving_time;
							activities.Add(rwli);
						}
						rw.setPbLoadingStatus((currentPage*perPageCount) + a, totalActivities, string.Format("Retrieving Activity Information...Activity {0} of {1}",(currentPage*perPageCount) + a,totalActivities));
						
					}
				}while((currentPage*perPageCount)+a < totalActivities);
			}
			return activities;
		}
		
		public RideWithGpsActivitySummary retrieveWorkoutData(int wId, ref ZedGraph.ZedGraphControl zedActivityChart)
		{
			RideWithGpsActivitySummary summary = new RideWithGpsActivitySummary();
			
			string wUrl = string.Format("http://ridewithgps.com/trips/{0}.json", wId);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(wUrl);
			httpWebRequest.Proxy = null;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;	
			httpWebRequest.CookieContainer = this._cookies;
			
			// get response
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
			if(responseStream != null){
				System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				dynamic jsonResult = JsonValue.Parse(text);
				
				PointPairList graphListHeart = new PointPairList();
				PointPairList graphListAltitude = new PointPairList();
				PointPairList graphListSpeed = new PointPairList();
				PointPairList graphListCadence= new PointPairList();
				zedActivityChart.GraphPane.CurveList.Clear();
				zedActivityChart.GraphPane.GraphObjList.Clear();
				zedActivityChart.GraphPane.YAxisList.Clear();
				
				zedActivityChart.GraphPane.AddYAxis("Heart (bpm)");
				zedActivityChart.GraphPane.AddYAxis("Cadence");
				zedActivityChart.GraphPane.AddYAxis("Speed");
				zedActivityChart.GraphPane.AddYAxis("Altitude (ft)");
				zedActivityChart.GraphPane.Y2Axis.Scale.FontSpec.Size = 8;
				// set custom formatting for X-Axis in charts
				zedActivityChart.GraphPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(Axis_ScaleFormatEvent);
								
				// set the ride summary details
				summary.avgSpeed = "- mph";
				summary.avgCadence = " - rpm";
				summary.avgHeartRate = "- bpm";
				summary.distance = "- miles";
				summary.elevationGain = "- ft";
				summary.durationTotal = "-";
				summary.durationMoving = "-";
				
				if(jsonResult.metrics.ContainsKey("speed")){
					summary.avgSpeed = string.Format("{0:0.00} mph", (double)jsonResult.metrics.speed.avg * 0.621371);
				}
				if(jsonResult.metrics.ContainsKey("cad")){
					summary.avgCadence = string.Format("{0:0} rpm", (double)jsonResult.metrics.cad.avg);
				}
				if(jsonResult.metrics.ContainsKey("hr")){
					summary.avgHeartRate = string.Format("{0:0} bpm", (double)jsonResult.metrics.hr.avg);
				}
				if(jsonResult.metrics.ContainsKey("distance")){
					summary.distance = string.Format("{0:0.00} miles", ((double)jsonResult.distance/ 1000) *  0.621371);
				}
				if(jsonResult.metrics.ContainsKey("elevation_gain")){
					summary.elevationGain = string.Format("{0:0.00} ft", (double)jsonResult.elevation_gain * 3.2808399);
				}
				summary.name = (string)jsonResult.name;
				
				if(jsonResult.metrics.ContainsKey("duration")){
					TimeSpan tDuration = TimeSpan.FromSeconds((double)jsonResult.metrics.duration);
					summary.durationTotal = string.Format("{0:D2} h {1:D2} m {2:D2} s", tDuration.Hours, tDuration.Minutes, tDuration.Seconds);
				}
				if(jsonResult.metrics.ContainsKey("movingTime")){
					TimeSpan tMoving = TimeSpan.FromSeconds((double)jsonResult.metrics.movingTime);
					summary.durationMoving = string.Format("{0:D2} h {1:D2} m {2:D2} s", tMoving.Hours, tMoving.Minutes, tMoving.Seconds);
				}
				summary.notes = (string)jsonResult.description;
				summary.mileSplits = new List<RideWithGpsMileSplit>();
				
				double firstTimestamp = (double)jsonResult.track_points[0].t;
				double distance = 0;
				double duration = 0;
				double speed = 0;
				
				int currentMileSearch = 1;
				double runningMileDistance = 0;
				double runningDuration = 0;
				// google map strings
				double lat_min=-1;
				double lat_max=-1;
				double lng_min=-1;
				double lng_max=-1;
				double lat = 0;
				double lng = 0;
				double start_lat = 0; 
				double start_lng = 0;
				double finish_lat = 0;
				double finish_lng = 0;
				string js_coords = "";
				string js_mile_markers = "";
				string js_bounds = "";
				//string js_centre = "";
				
				for(int tp = 0; tp < jsonResult.track_points.Count; tp++){
					if(tp==0){
						start_lat = (double)jsonResult.track_points[tp].y;
						start_lng = (double)jsonResult.track_points[tp].x;
					}
					// update the last point coordinates
					finish_lat = (double)jsonResult.track_points[tp].y;
					finish_lng = (double)jsonResult.track_points[tp].x;
					if(tp > 0){
						js_coords += ",";
						duration = (double)jsonResult.track_points[tp].t - (double)jsonResult.track_points[tp-1].t;
						distance = GeoMath.Distance(
							(double)jsonResult.track_points[tp].y,
							(double)jsonResult.track_points[tp].x,
							(double)jsonResult.track_points[tp-1].y,
							(double)jsonResult.track_points[tp-1].x,
							GeoMath.MeasureUnits.Miles
						);
						speed = distance / (duration / 3600);
						
						// increment the running totals
						runningDuration += duration;
						runningMileDistance += distance;

						// check if we've reached threshold for current search miles
						if(runningMileDistance > currentMileSearch){
							TimeSpan tsPace = TimeSpan.FromSeconds(runningDuration);
							RideWithGpsMileSplit mileSplit = new RideWithGpsMileSplit();
							mileSplit.label = string.Format("Mile {0}",currentMileSearch);
							mileSplit.speed = string.Format("{0:0.00} mph", (1 / (runningDuration / 3600)));
							mileSplit.pace = string.Format("{0:D2} h {1:D2} m {2:D2} s", tsPace.Hours, tsPace.Minutes, tsPace.Seconds);
							
							summary.mileSplits.Add(mileSplit);
							
				
				
							TimeSpan tmp_ts = TimeSpan.FromSeconds((double)jsonResult.track_points[tp].t);
							string mile_marker_tag = "Time since start of ride: " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
								tmp_ts.Hours, 
								tmp_ts.Minutes, 
								tmp_ts.Seconds
							);
							js_mile_markers += "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=" + (currentMileSearch) + "|95E978|004400',position: new google.maps.LatLng(" + (string)jsonResult.track_points[tp].y + "," + (string)jsonResult.track_points[tp].x + "),map: map,title: 'Mile " + (currentMileSearch) + "\\r\\n" + mile_marker_tag + "'});";
							
							// reset the running duration
							// and increment the mile search counter for the next mile
							runningDuration = 0;
							currentMileSearch++;
						}
					}
					
					// update the max / min longitude / latitude
					lat = (double)jsonResult.track_points[tp].y;
					lng = (double)jsonResult.track_points[tp].x;
					if(lat_min == -1){ lat_min = lat;}
					if(lat_max == -1){ lat_max = lat;}
					if(lng_min == -1){ lng_min = lng;}
					if(lng_max == -1){ lng_max = lng;}
					
					if(lat < lat_min){ lat_min = lat;}
					if(lat > lat_max){ lat_max = lat;}
					if(lng < lng_min){ lng_min = lng;}
					if(lng > lng_max){ lng_max = lng;}
					js_coords += "\r\nnew google.maps.LatLng(" + (string)jsonResult.track_points[tp].y + "," + (string)jsonResult.track_points[tp].x + ")";
					
					TimeSpan ts = TimeSpan.FromSeconds((double)jsonResult.track_points[tp].t - firstTimestamp);
					string tagCadence = "";
					
					string tagHR = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\nHR: " + (string)jsonResult.track_points[tp].h + " bpm";
					string tagAltitude = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\n" + string.Format("Altitude: {0:0.00} ft",(double)jsonResult.track_points[tp].e * 3.2808399);
					if(jsonResult.track_points[tp].ContainsKey("c")){
						tagCadence = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
						    			ts.Hours, 
						    			ts.Minutes, 
						    			ts.Seconds
						    		) + "\r\n" + string.Format("Cadence: {0:0.00} rpm",(double)jsonResult.track_points[tp].c);
					}
					string tagSpeed = "Duration : " + string.Format("{0:D2} h {1:D2} m {2:D2} s", 
					    			ts.Hours, 
					    			ts.Minutes, 
					    			ts.Seconds
					    		) + "\r\n" + string.Format("Speed: {0:0.00} mph",speed);
					
					if(jsonResult.track_points[tp].ContainsKey("h") && jsonResult.track_points[tp].ContainsKey("t")){
						graphListHeart.Add(
							(double)jsonResult.track_points[tp].t - firstTimestamp,
							(double)jsonResult.track_points[tp].h,
							tagHR
						);	
					}
					if(jsonResult.track_points[tp].ContainsKey("e")&& jsonResult.track_points[tp].ContainsKey("t")){
						graphListAltitude.Add(
							(double)jsonResult.track_points[tp].t - firstTimestamp,
							(double)jsonResult.track_points[tp].e * 3.2808399,
							tagAltitude
						);		
					}
					if(jsonResult.track_points[tp].ContainsKey("c")&& jsonResult.track_points[tp].ContainsKey("t")){
						graphListCadence.Add(
							(double)jsonResult.track_points[tp].t - firstTimestamp,
							(double)jsonResult.track_points[tp].c,
							tagCadence
						);		
					}
					graphListSpeed.Add(
						(double)jsonResult.track_points[tp].t - firstTimestamp,
						speed,
						tagSpeed
					);						
				}
				LineItem ln_heart_heart = zedActivityChart.GraphPane.AddCurve("Heart Rate",graphListHeart,Color.Red, SymbolType.None);
				ln_heart_heart.Line.Width = 1;
				ln_heart_heart.YAxisIndex = 0;
				
				LineItem ln_cadence = zedActivityChart.GraphPane.AddCurve("Cadence",graphListCadence, Color.Magenta,SymbolType.None);
				ln_cadence.Line.Width = 1;
				ln_cadence.YAxisIndex  = 1;
				LineItem ln_speed = zedActivityChart.GraphPane.AddCurve("Speed",graphListSpeed, Color.Blue,SymbolType.None);
				ln_speed.Line.Width = 1;
				ln_speed.YAxisIndex  = 2;
				
				LineItem ln_altitude  = zedActivityChart.GraphPane.AddCurve("Altitude",graphListAltitude, Color.Green,SymbolType.None);
				ln_altitude.Line.Fill = new Fill(Color.LightGreen);
				ln_altitude.YAxisIndex  = 3;
	
				zedActivityChart.AxisChange();
				
				if(jsonResult.track_points.Count != 0){
					zedActivityChart.GraphPane.XAxis.Scale.Max = (double)jsonResult.track_points[(int)jsonResult.track_points.Count-1].t - firstTimestamp;
				}
					
				zedActivityChart.GraphPane.XAxis.MajorGrid.IsVisible = true;
				zedActivityChart.GraphPane.YAxis.MajorGrid.IsVisible = true;
				zedActivityChart.AxisChange();
				
				js_mile_markers = 	"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});" + 
								js_mile_markers;
				
				// create a bounding box for the map - so it can auto-zoom to the best level of detail
				js_bounds = @" 
					var latlngbounds = new google.maps.LatLngBounds();
					latlngbounds.extend(new google.maps.LatLng(" + lat_min + @"," + lng_min + @"));
					latlngbounds.extend(new google.maps.LatLng(" + lat_max + @"," + lng_max + @"));
					map.fitBounds(latlngbounds);
				";
				
				
				// build the route html
				string routeHTML = @"
					<html>
					  <head>
					    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"">
					    <meta charset=""utf-8"">
					    <title>Cycle Route</title>
					    <style>
					      #map_canvas{
					        width:100%;
					        height:100%;
					      }
					    </style>
					    <script src=""https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false""></script>
					    <script type=""text/javascript"" language=""javascript"">
							var map;
					      function initialize() {
					        var mapOptions = {
					          mapTypeId: google.maps.MapTypeId.TERRAIN
					        };
					
					        map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
					
					        var cycleRouteCoords = [
					          " + js_coords + @"
					        ];
					        var cycleRoute = new google.maps.Polyline({
					          path: cycleRouteCoords,
					          strokeColor: '#FF0000',
					          strokeOpacity: 1.0,
					          strokeWeight: 2
					        });
					
					        cycleRoute.setMap(map);
					        
					        " + js_mile_markers + @"
					        " + js_bounds + @"
					      }
					      
					      window.onresize = pageresize;
					      
					      function pageresize()
					      {
					       google.maps.event.trigger(map, 'resize');
					       " + js_bounds + @"					       
					      }
					    </script>
					  </head>
					  <body onload=""initialize()"" >
					    <div id=""map_canvas""></div>
					  </body>
					</html>				
				";
			
				try{
					if(System.IO.File.Exists(Application.StartupPath + "\\rwgps_route.html"))
					{
					   	System.IO.File.Delete(Application.StartupPath + "\\rwgps_route.html");
					}
					FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\rwgps_route.html");
		            StreamWriter writer = new StreamWriter(fs);  
		            writer.Write(routeHTML);  
		            writer.Close();
		            writer.Dispose();
		            fs.Dispose();
		            //tabMap.Enabled = true;
				}
				catch{
					MessageBox.Show("Map Update Failed. Try re-selecting the activity.","Error loading map", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				finally{
					//tabMap.Enabled = true;
				}
					
			}
			return summary;
		}
		
		static string Axis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index)
		{
		    TimeSpan timeVal = TimeSpan.FromSeconds(val); 
		    return string.Format("{0:D2} h {1:D2} m {2:D2} s", timeVal.Hours, timeVal.Minutes, timeVal.Seconds);
		}
	}
}
