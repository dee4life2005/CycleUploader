/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 18/03/2013
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Json;


namespace CycleUploader
{
	
	/// <summary>
	/// Description of ActivityName.
	/// </summary>
	public partial class ActivityName : Form
	{
		public string _activityName;
		public string _activityNotes;
		public bool _activityIsCommute;
		public bool _activityIsStationaryTrainer;
		public bool _activityIsIncludedInStatistics;
		private SQLiteConnection _db;
		private Thread _loadMap;
		public int courseId = 0;
		public string courseName = "";
		private MainForm mainFrm;
		public string stravaGearId = "";
		public string stravaGearName = "";
		
		public ActivityName(string activityName, string activityNotes, bool isCommute, bool isStationaryTrainer, SQLiteConnection db, bool allowSelectMap = false, int idCourse = 0, bool isIncludedInStats = true, bool isStravaEnabled = true, MainForm fm = null, string stravaGearIdCurrent = "")
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_activityName = activityName;
			_activityNotes = activityNotes;
			_activityIsCommute = isCommute;
			_activityIsStationaryTrainer = isStationaryTrainer;
			_activityIsIncludedInStatistics = isIncludedInStats;
			stravaGearId = stravaGearIdCurrent;
			
			txtActivityName.Text = activityName;
			txtActivityNotes.Text = activityNotes;
			cbkIsCommute.Checked = isCommute;
			cbkIsStationaryTrainer.Checked = isStationaryTrainer;
			cbkIsIncludedInStatistics.Checked = isIncludedInStats;
			mainFrm = fm;
			
			_db = db;
			// resize the form if course selection is allowed
			if(allowSelectMap){
				this.Width = 775;
				this.Height = 387;
				lblStravaBike.Visible = false;
				lstStravaBike.Visible = false;
				txtActivityNotes.Height = 153;
			}
			else{
				this.Width = 459;
				this.Height = 330;
				txtActivityNotes.Height = 122;
				if(isStravaEnabled){
					initialiseStravaBikes();
					lblStravaBike.Visible = true;
					lstStravaBike.Visible = true;
				}
				else{
					txtActivityNotes.Height = 153;
				}
			}
			courseId = idCourse;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			try{
				map.Stop();
				if(_loadMap != null && _loadMap.IsAlive){
					_loadMap.Abort();
				}
			}catch{}
			this.DialogResult = DialogResult.Cancel;
		}
		
		void initialiseStravaBikes()
		{
			string url = "https://www.strava.com/api/v3/athlete?";
			url += "access_token=" + mainFrm._strava_access_token;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.Timeout = 5000;
		
			// build the url encoded form post data
			
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				if (responseStream != null)
				{
					System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					dynamic json = JsonValue.Parse(text);
					
					for(int bike = 0; bike < json.bikes.Count; bike++){
						
						lstStravaBike.Items.Add(new ComboboxItem(
							Convert.ToInt32(((string)json.bikes[bike].id).Replace("b","")),
							(string)json.bikes[bike].name
						));
						if(stravaGearId != "" && stravaGearId == ((string)json.bikes[bike].id).Replace("b","")){
							lstStravaBike.SelectedIndex = bike;
						}
					}
				}
			}
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			_activityName = txtActivityName.Text;
			_activityNotes = txtActivityNotes.Text;
			_activityIsCommute = cbkIsCommute.Checked;
			_activityIsStationaryTrainer = cbkIsStationaryTrainer.Checked;
			_activityIsIncludedInStatistics = cbkIsIncludedInStatistics.Checked;
			if(lstCourse.SelectedIndex != -1){
				courseId = ((ComboboxItem)lstCourse.SelectedItem).Value;
				courseName = ((ComboboxItem)lstCourse.SelectedItem).Text;
			}
			else{
				courseId = 0;
				courseName = "";
			}
			if(lstStravaBike.SelectedIndex != -1){
				stravaGearId = "b" + ((ComboboxItem)lstStravaBike.SelectedItem).Value.ToString();
				stravaGearName = ((ComboboxItem)lstStravaBike.SelectedItem).Text;
			}
			
			try{
				map.Stop();
				if(_loadMap != null && _loadMap.IsAlive){
					_loadMap.Abort();
				}
			}catch{}
			this.DialogResult = DialogResult.OK;	
		}
		
		void TxtActivityNameKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return){
				BtnApplyClick(sender, e);
			}
		}
		
		void ActivityNameLoad(object sender, EventArgs e)
		{
			this.ActiveControl = txtActivityName;
			
			// load the available courses
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select courseId, courseName from Course order by courseName asc";
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				try{
				while(rdr.Read()){
					lstCourse.Items.Add(new ComboboxItem(
							Convert.ToInt32(rdr["courseId"]),
							(string)rdr["courseName"])
						);
						if(Convert.ToInt32(rdr["courseId"]) == courseId){
							lstCourse.SelectedIndex = lstCourse.Items.Count-1;
						}
				}
				}catch(Exception ex){
					MessageBox.Show(ex.ToString());
				}
				
			}
		}
		
		void LstCourseSelectedIndexChanged(object sender, EventArgs e)
		{
			try{
				if(_loadMap != null && _loadMap.IsAlive){
					map.Stop();
					_loadMap.Abort();
				}
			}catch{}
			
			courseId = ((ComboboxItem)lstCourse.SelectedItem).Value;
			courseName = ((ComboboxItem)lstCourse.SelectedItem).Text;
			_loadMap = new Thread(new ThreadStart(loadCourseMap));
			_loadMap.Start();
		}
		
		void loadCourseMap()
		{
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select lat as tpLatitude, lng as tpLongitude from CourseRoute where courseId = {0} and ifnull(lat,0) != 0 and ifnull(lng,0) != 0 order by idx asc";
			sql = string.Format(sql,courseId);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			
			int rowCount = 0;
			double lat, lng, start_lat, start_lng, finish_lat, finish_lng, lat_min, lat_max, lng_min, lng_max;
			string js_coords = "", js_bounds = "", js_mile_markers = "";
			
			lat_min = lat_max = lng_min = lng_max = -1;
			start_lat = start_lng = finish_lat = finish_lng = 0;
			
			if(rdr.HasRows){
				while(rdr.Read()){
					rowCount++;
					
					if(rowCount==1){
						start_lat = Convert.ToDouble(rdr["tpLatitude"]);
						start_lng = Convert.ToDouble(rdr["tpLongitude"]);
					}
					// update the last point coordinates
					finish_lat = Convert.ToDouble(rdr["tpLatitude"]);
					finish_lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					lat = Convert.ToDouble(rdr["tpLatitude"]);
					lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					if(lat != 0 && lng != 0 && Math.Ceiling(lat) != 180 && Math.Ceiling(lng) != 180){
						if(lat_min == -1){ lat_min = lat;}
						if(lat_max == -1){ lat_max = lat;}
						if(lng_min == -1){ lng_min = lng;}
						if(lng_max == -1){ lng_max = lng;}
						
						if(lat < lat_min){ lat_min = lat;}
						if(lat > lat_max){ lat_max = lat;}
						if(lng < lng_min){ lng_min = lng;}
						if(lng > lng_max){ lng_max = lng;}
						if(rowCount > 1){
							js_coords += ",";
						}
						js_coords += "\r\nnew google.maps.LatLng(" + Convert.ToDouble(rdr["tpLatitude"]).ToString() + "," + Convert.ToDouble(rdr["tpLongitude"]).ToString() + ")";
					}
				}
				
				js_mile_markers = "\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=S|000088|FFFFFF',position: new google.maps.LatLng(" + start_lat + "," + start_lng + "),map: map,title: 'Start'});" +
								"\r\nnew google.maps.Marker({icon:'https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=F|000088|FFFFFF',position: new google.maps.LatLng(" + finish_lat + "," + finish_lng + "),map: map,title: 'Finish'});";
								
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
					if(System.IO.File.Exists(Application.StartupPath + "\\course_route.html"))
					{
					   	System.IO.File.Delete(Application.StartupPath + "\\course_route.html");
					}
					FileStream fs = System.IO.File.OpenWrite(Application.StartupPath + "\\course_route.html");
		            StreamWriter writer = new StreamWriter(fs);  
		            writer.Write(routeHTML);  
		            writer.Close();
		            writer.Dispose();
		            fs.Dispose();
		            map.Navigate(Application.StartupPath + "\\course_route.html");
				}
				catch(Exception ex){
					MessageBox.Show("Map: Loading Failed. " + ex.Message ,"Error loading map of route", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}
		
		void BtnMapFullscreenClick(object sender, EventArgs e)
		{
			FullscreenMap fsmap = new FullscreenMap(Application.StartupPath + "\\course_route.html");
			fsmap.ShowDialog();
		}
	}
}
