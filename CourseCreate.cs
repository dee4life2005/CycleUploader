/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/04/2013
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;
using System.IO;

namespace CycleUploader
{
	/// <summary>
	/// Description of CourseCreate.
	/// </summary>
	public partial class CourseCreate : Form
	{
		private int _fileId;
		private Thread _thLoadMap;
		private SQLiteConnection _db;
		
		public int _courseId = 0;
		public string _courseName = "";
		
		public CourseCreate(int fileid, string activityName, string activityDate, string distance, SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_fileId = fileid;
			_db = db;
			tActivityName.Text = activityName;
			tActivityDate.Text = System.DateTime.Parse(activityDate).ToString("dd MMMM yyyy 'at' HH:mm");
			tActivityDistance.Text = distance;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			try{
				if(_thLoadMap != null && _thLoadMap.IsAlive){
					_thLoadMap.Abort();
				}
			}catch{}
			this.DialogResult = DialogResult.Cancel;
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			int courseId = 0;
			SQLiteCommand cmd = new SQLiteCommand(_db);
			// insert the course
			string sql = @"insert into Course(courseName) VALUES (""{0}"")";
			sql = string.Format(sql, tCourseName.Text);
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			cmd.CommandText = "SELECT last_insert_rowid()";
			courseId = Convert.ToInt32(cmd.ExecuteScalar());
			
			// insert the route trackpoints
			sql = @"
				insert into CourseRoute(courseId, idx, lat, lng)
				select {0}, rowid, tpLatitude, tpLongitude
				from FileTrackpoints
				where idFile = {1}
				order by rowid asc
			";
			sql = string.Format(sql, courseId, _fileId);
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			
			_courseId = courseId;
			_courseName = tCourseName.Text;
			this.DialogResult = DialogResult.OK;
		}
		
		void CourseCreateLoad(object sender, EventArgs e)
		{
			_thLoadMap = new Thread(new ThreadStart(loadCourseMap));
			_thLoadMap.Start();
		}
		
		void loadCourseMap()
		{
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select * from FileTrackpoints where idFile = {0} and ifnull(tpLongitude,0) != 0 and ifnull(tpLatitude,0) != 0 order by tpTime asc";
			sql = string.Format(sql,_fileId);
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
