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
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;

namespace CycleUploader
{
	/// <summary>
	/// Description of Courses.
	/// </summary>
	public partial class Courses : Form
	{
		private SQLiteConnection _db;
		private MainForm _mainfrm;
		
		public Courses(SQLiteConnection db, MainForm mainfrm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db = db;
			_mainfrm = mainfrm;
			
			// load the courses list
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select courseId, courseName from Course order by courseName asc";
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				while(rdr.Read())
				{
					lstCourses.Items.Add(new ComboboxItem(Convert.ToInt32(rdr["courseId"]), (string)rdr["courseName"]));
				}
			}
		}
		
		void BtnMapFullscreenClick(object sender, EventArgs e)
		{
			FullscreenMap fsmap = new FullscreenMap(Application.StartupPath + "\\course_route.html");
			fsmap.ShowDialog();
		}
		
		void loadCourseInfo(int courseId)
		{
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = string.Format(@"select * from view_course_list where courseId = {0}",courseId);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				rdr.Read();
				tCourseName.Text = (string)rdr["courseName"];
				if(rdr.IsDBNull(rdr.GetOrdinal("courseRiddenFirst"))){
					tRideCount.Text = "";
					tFirstRidden.Text = "No Rides Recorded Against Course";
				}
				else{
					tFirstRidden.Text = "First Ridden on " + System.DateTime.Parse((string)rdr["courseRiddenFirst"]).ToString("dd MMMM yyyy 'at' HH:mm");
					tLastRidden.Text = "Last Ridden on " + System.DateTime.Parse((string)rdr["courseRiddenLatest"]).ToString("dd MMMM yyyy 'at' HH:mm");
					tRideCount.Text = "Ridden " + Convert.ToInt32(rdr["courseActivityCount"]).ToString() + " times";
					
					TimeSpan ts;
					
					ts = TimeSpan.FromSeconds(Convert.ToInt32(rdr["durationLow"]));
					tFastestSpeed.Text = string.Format("{0:0.00} mph", rdr["avgspeedHight"]);
					tFastestDuration.Text = string.Format("{0:D2} h {1:D2} m {2:D2} s",
					                                      Convert.ToInt32(Math.Floor(ts.TotalHours)),
					                                      ts.Minutes,
					                                      ts.Seconds
					                                     );
					
					tSlowestSpeed.Text = string.Format("{0:0.00} mph", rdr["avgspeedLow"]);
					
					ts = TimeSpan.FromSeconds(Convert.ToInt32(rdr["durationHigh"]));
					tSlowestDuration.Text = string.Format("{0:D2} h {1:D2} m {2:D2} s",
					                                      Convert.ToInt32(Math.Floor(ts.TotalHours)),
					                                      ts.Minutes,
					                                      ts.Seconds
					                                     );
					
					ts = TimeSpan.FromSeconds(Convert.ToInt32(rdr["durationLTA"]));
					tAverageSpeed.Text = string.Format("{0:0.00} mph", rdr["avgspeedLTA"]);
					tAverageDuration.Text = string.Format("{0:D2} h {1:D2} m {2:D2} s",
					                                      Convert.ToInt32(Math.Floor(ts.TotalHours)),
					                                      ts.Minutes,
					                                      ts.Seconds
					                                     );
				}
			}
		}
		
		double loadCourseMap(int courseId)
		{
			double course_length = 0;
			
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select lat as `tpLatitude`, lng as `tpLongitude` from CourseRoute where courseId = {0} order by idx asc";
			sql = string.Format(sql, courseId);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			
			int rowCount = 0;
			double lat, lng, start_lat, start_lng, finish_lat, finish_lng, lat_min, lat_max, lng_min, lng_max, prev_lat, prev_lng;
			string js_coords = "", js_bounds = "", js_mile_markers = "";
			
			lat_min = lat_max = lng_min = lng_max = -1;
			start_lat = start_lng = finish_lat = finish_lng = 0;
			prev_lat = 0;
			prev_lng = 0;
			
			if(rdr.HasRows){
				while(rdr.Read()){
					rowCount++;
					
					if(rowCount==1){
						start_lat = Convert.ToDouble(rdr["tpLatitude"]);
						start_lng = Convert.ToDouble(rdr["tpLongitude"]);
						prev_lat = start_lat;
						prev_lng = start_lng;
					}
					
					
					// update the last point coordinates
					finish_lat = Convert.ToDouble(rdr["tpLatitude"]);
					finish_lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					lat = Convert.ToDouble(rdr["tpLatitude"]);
					lng = Convert.ToDouble(rdr["tpLongitude"]);
					
					
					// calculate the distance of this trackpoint from the previous one
					// incrementing route distance, and then update the previous trackpoint for 
					// the next loop iterations
					if(lat != 0 && lng != 0){
						course_length += GeoMath.Distance(prev_lat, prev_lng, lat, lng, GeoMath.MeasureUnits.Miles);
						prev_lat = lat;
						prev_lng = lng;
					}
					
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
			return course_length;
		}
		
		
		void LstCoursesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstCourses.SelectedIndex != -1){
				initialiseForm();
				loadCourseInfo(((ComboboxItem)lstCourses.SelectedItem).Value);
				double distance = loadCourseMap(((ComboboxItem)lstCourses.SelectedItem).Value);
				tCourseDistance.Text = string.Format("{0:0.00} miles", distance);
				loadCourseActivities(((ComboboxItem)lstCourses.SelectedItem).Value);
			}
		}
		
		void loadCourseActivities(int courseId)
		{
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = string.Format(@"select s.* from view_file_summary s join File f on f.idFile = s.idFile where f.idCourse = {0}", courseId);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				List<ListViewItem> lvi = new List<ListViewItem>();
				while(rdr.Read())
				{
					TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(rdr["fsDuration"]));
					string[] row = {
						Convert.ToInt32(rdr["idFile"]).ToString(),
						((System.DateTime)rdr["fileActivityDateTime"]).ToString("dd/MM/yyyy HH:mm"),
						(string)rdr["fileName"],
						string.Format("{0:0.00} miles", rdr["fsDistance"]),
						string.Format("{0:D2} h {1:D2} m {2:D2} s", 
						              Convert.ToInt32(Math.Floor(ts.TotalHours)), 
						              ts.Minutes, 
						              ts.Seconds
						             ),
						string.Format("{0:0.00} mph", rdr["fsAvgSpeed"]),
						Convert.ToInt32(rdr["fileIsCommute"]) == 1 ? "Y" : "",
						Convert.ToInt32(rdr["fileIsStationaryTrainer"]) == 1 ? "Y" : "",
						(string)rdr["fileActivityNotes"]						
					};
					lvi.Add(new ListViewItem(row));
				}
				
				foreach(ListViewItem li in lvi){
					lstCourseActivities.Items.Add(li);
				}
				lstCourseActivities.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}
		}
		
		void BtnDeleteCourseClick(object sender, EventArgs e)
		{
			if(lstCourses.SelectedIndex == -1){
				MessageBox.Show("No Course Selected");
			}
			else{
				if(MessageBox.Show("Are you sure you want to delete course `" + ((ComboboxItem)lstCourses.SelectedItem).Text + "` ?", "Confirm Course Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					SQLiteCommand cmd = new SQLiteCommand(_db);
					string sql = string.Format(@"delete from CourseRoute where courseId = {0}", ((ComboboxItem)lstCourses.SelectedItem).Value);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					sql = string.Format(@"delete from Course where courseId = {0}", ((ComboboxItem)lstCourses.SelectedItem).Value);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					sql = string.Format(@"update File set idCourse = NULL where idCourse = {0}", ((ComboboxItem)lstCourses.SelectedItem).Value);
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
					lstCourses.Items.Remove(lstCourses.SelectedItem);
					initialiseForm();
					_mainfrm.loadFileHistory();
					MessageBox.Show("Course successfully deleted");
				}
			};
		}
		
		void initialiseForm()
		{
			tRideCount.Text = "< Select Course From List On Left >";
			tCourseName.Text = "";
			tCourseDistance.Text = "";
			tFirstRidden.Text = "";
			tLastRidden.Text = "";
			tFastestDuration.Text = "";
			tFastestSpeed.Text = "";
			tSlowestDuration.Text = "";
			tSlowestSpeed.Text = "";
			tAverageDuration.Text = "";
			tAverageSpeed.Text = "";
			lstCourseActivities.Items.Clear();
			map.Navigate("about:blank");
		}
		
		void LstCourseActivitiesDoubleClick(object sender, EventArgs e)
		{
			if(lstCourseActivities.SelectedItems.Count > 0){
				
				CycleUploader.FileSummary summary = new CycleUploader.FileSummary(
					Convert.ToInt32(lstCourseActivities.SelectedItems[0].Text),
					_db
				);
				summary.ShowDialog();
			}
		}
	}
}
