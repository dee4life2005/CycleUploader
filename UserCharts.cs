/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 01/04/2013
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using ZedGraph;
using System.Globalization;
using System.Diagnostics;

namespace CycleUploader
{
	/// <summary>
	/// Description of UserCharts.
	/// </summary>
	public partial class UserCharts : Form
	{
		private SQLiteConnection _db;
		private static RadioButton _chartType;
		private static RadioButton _chartGrouping;
		
		public UserCharts(SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db = db;
			zedGraph.GraphPane.IsFontsScaled = false;
			zedGraph.GraphPane.YAxis.ScaleFormatEvent += new ZedGraph.Axis.ScaleFormatHandler(YAxis_ScaleFormatEvent);
			zedGraph.GraphPane.XAxis.ScaleFormatEvent += new ZedGraph.Axis.ScaleFormatHandler(XAxis_ScaleFormatEvent);
			zedGraph.GraphPane.Legend.IsVisible = false;
			zedGraph.GraphPane.Title.Text = " ";
			zedGraph.GraphPane.YAxis.Scale.MagAuto = false;
			zedGraph.GraphPane.XAxis.Scale.FontSpec.Size = 10;
			zedGraph.GraphPane.YAxis.Scale.FontSpec.Size = 10;
			_chartType = radioButton1;
			_chartGrouping = rdoGroupMonthly;
			dpFrom.MaxDate = DateTime.Now;
			dpTo.MaxDate = DateTime.Now;
			dpFrom.Value = dpFrom.MinDate;
			loadMonthlyChart("No. Activities");
		}
		
		void loadWeeklyChart(string type)
		{
			// tweaked code to get iso year / week no. based on first 4 day week of year being week 1
			string sql = @"
				select 
					strftime('%Y',date(f.fileActivityDateTime, '-3 days', 'weekday 4')) as iso_year,
					(strftime('%j', date(f.fileActivityDateTime, '-3 days', 'weekday 4')) - 1) / 7 + 1 as iso_week,			
					count(f.idFile) as `NoActivities`,
					cast(sum(fs.fsDuration) as double)/3600 as `TotalDurationHours`,
					sum(fs.fsDistance) as `TotalDistanceMiles`,
					sum(fs.fsCalories) as `TotalCalories`,
					sum(ifnull(fs.fsTotalAscent,0)) as `TotalAscent`
				from File f
				join FileSummary fs on fs.idFile = f.idFile
				where date(f.fileActivityDateTime) between ""{0}"" and ""{1}""
				group by iso_year, iso_week			
			";
			Debug.WriteLine(sql);
			sql = string.Format(sql, 
			                    dpFrom.Value.ToString("yyyy-MM-dd"),
			                    dpTo.Value.ToString("yyyy-MM-dd")
			                   );
			SQLiteCommand cmd = new SQLiteCommand(_db);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			
			zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			
			PointPairList p = new PointPairList();
			while(rdr.Read()){
				DateTime dt = FirstDateOfWeek(
					Convert.ToInt32(rdr["iso_year"]),
					Convert.ToInt32(rdr["iso_week"]),
					CalendarWeekRule.FirstFourDayWeek
				);
				switch(type){
					case "No. Activities":
						p.Add(
							dt.ToOADate(),
							Convert.ToInt32(rdr["NoActivities"]),
							dt.ToString("dd/MM/yyyy") + "\r\nNo. Activities = " + Convert.ToInt32(rdr["NoActivities"]).ToString()
						);
						zedGraph.GraphPane.YAxis.Title.Text = "No. Activities";
						zedGraph.GraphPane.XAxis.Title.Text = "Week";
				
						break;
					case "Total Duration":
						TimeSpan ts = TimeSpan.FromHours(Convert.ToDouble(rdr["TotalDurationHours"]));
						string tag = dt.ToString("dd/MM/yyyy") + "\r\n";
						tag += string.Format("Total Duration = {0:D2} h {1:D2} m {2:D2} s", 
						                     Convert.ToInt32(Math.Floor(ts.TotalHours)),
						                     ts.Minutes,
						                     ts.Seconds
						                    );
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalDurationHours"]),
							tag
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Duration(h:m:s)";
						zedGraph.GraphPane.XAxis.Title.Text = "Week";
						break;
					case "Total Distance":
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalDistanceMiles"]),
							dt.ToString("dd/MM/yyyy") + "\r\nTotal Distance = " + string.Format("{0:0.00} miles", rdr["TotalDistanceMiles"])
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Distance (miles)";
						zedGraph.GraphPane.XAxis.Title.Text = "Week";
						break;
					case "Total Calories":
						p.Add(
							dt.ToOADate(),
							Convert.ToInt32(rdr["TotalCalories"]),
							dt.ToString("dd/MM/yyyy") + "\r\nTotal Calories = " + Convert.ToInt32(rdr["TotalCalories"]).ToString()
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Calories";
						zedGraph.GraphPane.XAxis.Title.Text = "Week";
						break;
					case "Total Ascent":
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalAscent"]),
							dt.ToString("dd/MM/yyyy") + "\r\nTotal Ascent = " + string.Format("{0:0.00} ft", rdr["TotalAscent"])
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Ascent (ft)";
						zedGraph.GraphPane.XAxis.Title.Text = "Week";
						break;
				}
			}
			zedGraph.GraphPane.GraphObjList.Clear();
			zedGraph.GraphPane.CurveList.Clear();
			
			zedGraph.GraphPane.AddCurve(type,p, Color.Blue, SymbolType.Diamond);
			zedGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;
			zedGraph.GraphPane.AxisChange();
			zedGraph.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Month;
			zedGraph.GraphPane.XAxis.Scale.MajorStep = 1;
			zedGraph.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Month;
			zedGraph.GraphPane.XAxis.Scale.MinorStep = 0.25;
			
			// for the x-axis to better values
			zedGraph.GraphPane.XAxis.Scale.MinAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MaxAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MajorStepAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MinorStepAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MagAuto = false;
			zedGraph.GraphPane.XAxis.Scale.FormatAuto = false;
			zedGraph.GraphPane.XAxis.Scale.Min = dpFrom.Value.ToOADate();
			zedGraph.GraphPane.XAxis.Scale.Max = dpTo.Value.ToOADate();
			
			zedGraph.Refresh();					
		}
		
		void loadMonthlyChart(string type)
		{
			string sql = @"
				select 
					strftime(""%Y-%m-01"", f.fileActivityDateTime) as `ym`,
					count(f.idFile) as `NoActivities`,
					cast(sum(fs.fsDuration) as double)/3600 as `TotalDurationHours`,
					sum(fs.fsDistance) as `TotalDistanceMiles`,
					sum(fs.fsCalories) as `TotalCalories`,
					sum(ifnull(fs.fsTotalAscent,0)) as `TotalAscent`
				from File f
				join FileSummary fs on fs.idFile = f.idFile
				where date(f.fileActivityDateTime) between ""{0}"" and ""{1}""
				group by ym
			";
			sql = string.Format(sql, 
		                    dpFrom.Value.ToString("yyyy-MM-dd"),
		                    dpTo.Value.ToString("yyyy-MM-dd")
		                   );
			SQLiteCommand cmd = new SQLiteCommand(_db);
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			
			
			zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;
				
			PointPairList p = new PointPairList();
			while(rdr.Read()){
				DateTime dt = Convert.ToDateTime(rdr["ym"]);
				switch(type){
					case "No. Activities":
						p.Add(
							dt.ToOADate(),
							Convert.ToInt32(rdr["NoActivities"]),
							dt.ToString("MMMM yyyy") + "\r\nNo. Activities = " + Convert.ToInt32(rdr["NoActivities"]).ToString()
						);
						zedGraph.GraphPane.YAxis.Title.Text = "No. Activities";
						zedGraph.GraphPane.XAxis.Title.Text = "Month";
				
						break;
					case "Total Duration":
						TimeSpan ts = TimeSpan.FromHours(Convert.ToDouble(rdr["TotalDurationHours"]));
						string tag = dt.ToString("MMMM yyyy") + "\r\n";
						tag += string.Format("Total Duration = {0:D2} h {1:D2} m {2:D2} s", 
						                     Convert.ToInt32(Math.Floor(ts.TotalHours)),
						                     ts.Minutes,
						                     ts.Seconds
						                    );
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalDurationHours"]),
							tag
						);
						
						
						zedGraph.GraphPane.YAxis.Title.Text = "Total Duration(h:m:s)";
						zedGraph.GraphPane.XAxis.Title.Text = "Month";
						break;
					case "Total Distance":
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalDistanceMiles"]),
							dt.ToString("MMMM yyyy") + "\r\nTotal Distance = " + string.Format("{0:0.00} miles", rdr["TotalDistanceMiles"])
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Distance (miles)";
						zedGraph.GraphPane.XAxis.Title.Text = "Month";
						break;
					case "Total Calories":
						p.Add(
							dt.ToOADate(),
							Convert.ToInt32(rdr["TotalCalories"]),
							dt.ToString("MMMM yyyy") + "\r\nTotal Calories = " + Convert.ToInt32(rdr["TotalCalories"]).ToString()
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Calories";
						zedGraph.GraphPane.XAxis.Title.Text = "Month";
						break;
					case "Total Ascent":
						p.Add(
							dt.ToOADate(),
							Convert.ToDouble(rdr["TotalAscent"]),
							dt.ToString("MMMM yyyy") + "\r\nTotal Ascent = " + string.Format("{0:0.00} ft", rdr["TotalAscent"])
						);
						zedGraph.GraphPane.YAxis.Title.Text = "Total Ascent (ft)";
						zedGraph.GraphPane.XAxis.Title.Text = "Month";
						break;
				}
			}
				
			zedGraph.GraphPane.GraphObjList.Clear();
			zedGraph.GraphPane.CurveList.Clear();
			
			zedGraph.GraphPane.AddCurve(type,p, Color.Blue, SymbolType.Diamond);
			zedGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;
			
			zedGraph.GraphPane.AxisChange();
			
			zedGraph.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Month;
			zedGraph.GraphPane.XAxis.Scale.MajorStep = 1;
			zedGraph.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Month;
			// for the x-axis to better values
			zedGraph.GraphPane.XAxis.Scale.MinAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MaxAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MajorStepAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MinorStepAuto = false;
			zedGraph.GraphPane.XAxis.Scale.MagAuto = false;
			zedGraph.GraphPane.XAxis.Scale.FormatAuto = false;
			zedGraph.GraphPane.XAxis.Scale.Min = dpFrom.Value.ToOADate();//.MinDate.ToOADate();
			zedGraph.GraphPane.XAxis.Scale.Max = dpTo.Value.ToOADate(); //.MaxDate.ToOADate();
			
			zedGraph.Refresh();					
		}
			
		
		void rdoChartTypeCheckedChanged(object sender, EventArgs e)
		{
			if(((RadioButton)sender).Checked){
				_chartType = (RadioButton)sender;
				if(_chartGrouping.Text == "Monthly"){
					loadMonthlyChart(((RadioButton)sender).Text);
				}else{
					loadWeeklyChart(((RadioButton)sender).Text);
				}
			}
		}
		
		static string YAxis_ScaleFormatEvent(GraphPane pane, ZedGraph.Axis axis, double val, int index)
		{
			if(_chartType.Text == "Total Duration"){
				TimeSpan timeVal = TimeSpan.FromHours(val); 
				
				return string.Format("{0:D2}:{1:D2}:{2:D2}",
				                     Convert.ToInt32(Math.Floor(timeVal.TotalHours)), 
				                     timeVal.Minutes, 
				                     timeVal.Seconds
				                    );
			}
			else{
				return val.ToString();
			}
		}
		
		static string XAxis_ScaleFormatEvent(GraphPane pane, ZedGraph.Axis axis, double val, int index)
		{
			if(_chartGrouping.Text == "Monthly"){
				return DateTime.FromOADate(val).ToString("MM/yyyy");
			}
			else{
				pane.XAxis.Scale.FontSpec.Angle = 45;
				return DateTime.FromOADate(val).ToString("dd/MM/yyyy");
			}
		}
		
		static DateTime FirstDateOfWeek(int year, int weekNum, CalendarWeekRule rule)
		{
		    DateTime jan1 = new DateTime(year, 1, 1);
		    int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
		
		    DateTime firstThursday = jan1.AddDays(daysOffset);
		    var cal = CultureInfo.CurrentCulture.Calendar;
		    int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		
		    if (firstWeek <= 1)
		    {
		        weekNum -= 1;
		    }
		    var result = firstThursday.AddDays(weekNum * 7);
		    return result.AddDays(-3);
		}
		
		void RdoGroupCheckedChanged(object sender, EventArgs e)
		{
			_chartGrouping = ((RadioButton)sender);
			if(_chartGrouping.Text == "Monthly"){
				loadMonthlyChart(_chartType.Text);
			}
			else{
				loadWeeklyChart(_chartType.Text);
			}
		}
		
		void DpValueChanged(object sender, EventArgs e)
		{
			if(_chartGrouping.Text == "Monthly"){
				loadMonthlyChart(_chartType.Text);
			}
			else{
				loadWeeklyChart(_chartType.Text);
			}
		}
	}
}
