/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/03/2013
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Diagnostics;

namespace CycleUploader
{
	/// <summary>
	/// Description of UserWeeklyStats.
	/// </summary>
	public partial class UserWeeklyStats : Form
	{
		private SQLiteConnection _db;
		private ListViewColumnSorter lvwColumnSorter;
		
		private delegate void ResizeListViewDelegate(Control ctrl);
		private void ResizeListView(Control ctrl)
		{
			if(ctrl.InvokeRequired){
				ctrl.Invoke(new ResizeListViewDelegate(ResizeListView), new object[] { ctrl});
			}
			else{
				((ListView)ctrl).AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}
		}
		
		public UserWeeklyStats(SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db = db;
			lvwColumnSorter = new ListViewColumnSorter();
			lstMonthlyStats.ListViewItemSorter = lvwColumnSorter;
		}
		
		private void initialiseMonthlyStats()
		{
			lstMonthlyStats.Items.Clear();
			SQLiteCommand command = new SQLiteCommand(_db);
			
			string sql = @"
				select  t.*, 
				        IFNULL(commutes.num_commutes,0) as `numCommuteDays`,
				        IFNULL(commutes.totDistance,0) as `totCommuteDistance`
				from
				(
				  select  strftime('%Y',DATE(f.fileActivityDateTime, '-3 days', 'weekday 4')) as iso_year,
				          (strftime('%j', DATE(f.fileActivityDateTime, '-3 days', 'weekday 4')) - 1) / 7 + 1 as iso_week,			
				          strftime('%W', f.fileActivityDateTime) as sqlweek, 
				          strftime('%Y', f.fileActivityDateTime) as sqlyear,
				          SUM(fs.fsDistance) as `totalDistance`, 
				          SUM(fs.fsMovingTime) as `totalDurationMoving`,
				          COUNT(f.idFile)  as `fileCount`,
				          SUM(IFNULL(fs.fsTotalAscent,0)) as `totalAscent`,
				          MAX(case fs.fsMaxSpeed = 255 when 1 then 0 else fs.fsMaxSpeed end) as `maxSpeed`,
				          MAX(case fs.fsMaxHeartRate = 255 when 1 then 0 else fs.fsMaxHeartRate end) as `maxHeartRate`,
				          MAX(case fs.fsMaxCadence = 255 when 1 then 0 else fs.fsMaxCadence end) as `maxCadence`,
				          MAX(CAST(fs.fsTotalAscent as double)) as `maxAscent`,
				          IFNULL(SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsAvgCadence end * fs.fsMovingTime) / SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsMovingTime end),0) as `avgCadence`,
				          IFNULL(SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsAvgHeart end * fs.fsMovingTime) / SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsMovingTime end),0) as `avgHeart`
				  from File f
				  join FileSummary fs on fs.idFile = f.idFile
				  where f.fileIsIncludedInStats = 1
				  group by iso_year, iso_week
				) t
				left join (
				  select	strftime('%Y',DATE(f.fileActivityDateTime, '-3 days', 'weekday 4')) as iso_year,
									(strftime('%j', DATE(f.fileActivityDateTime, '-3 days', 'weekday 4')) - 1) / 7 + 1 as iso_week,
				          COUNT(distinct DATE(f.fileActivityDateTime)) as num_commutes,
				          SUM(fs.fsDistance) as totDistance
				  from File f 
				  join FileSummary fs on fs.idFile = f.idFile
				  where f.fileIsIncludedInStats = 1 and f.fileIsCommute = 1
					group by iso_year, iso_week
				) commutes on commutes.iso_year = t.iso_year and commutes.iso_week = t.iso_week
				order by t.iso_year desc, t.iso_week desc				
			";
			//string sql = @"select * from view_user_monthlystats order by ym desc";
			
			try{
				command.CommandText = sql;
				SQLiteDataReader rdr = command.ExecuteReader();
				if(rdr.HasRows){
					while(rdr.Read()){
						TimeSpan tsMoving = TimeSpan.FromSeconds(Convert.ToInt32(rdr["totalDurationMoving"]));
						DateTime wk = FirstDateOfWeek(
							Convert.ToInt32(rdr["iso_year"]),
							Convert.ToInt32(rdr["iso_week"]),
							CalendarWeekRule.FirstFourDayWeek
						);
						string[] row = {
							wk.ToString("yyyy-MM-dd") + " to " + wk.AddDays(6).ToString("yyyy-MM-dd"),
							Convert.ToInt32(rdr["fileCount"]).ToString(),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["totalDistance"])),
							string.Format("{0:D2} h {1:D2} m {2:D2} s", Convert.ToInt32(Math.Floor(tsMoving.TotalHours)), tsMoving.Minutes, tsMoving.Seconds),
							string.Format("{0:0.00}", (Convert.ToDouble(rdr["totalDistance"]) / Convert.ToDouble(rdr["totalDurationMoving"]))*3600),
							string.Format("{0:0}", Convert.ToInt32(rdr["avgCadence"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["avgHeart"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["totalAscent"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["maxSpeed"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["maxHeartRate"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["maxCadence"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["maxAscent"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["numCommuteDays"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["totCommuteDistance"]))
						};
						lstMonthlyStats.Items.Add(new ListViewItem(row));
					}
					ResizeListView(lstMonthlyStats);
				}
			}
			catch(Exception ex){
				MessageBox.Show("MonthlyStats Exception: There was a problem building the monthly statistics.\r\n" + ex.Message);
			}
		}
		
		void UserWeeklyStatsLoad(object sender, EventArgs e)
		{
			initialiseMonthlyStats();
		}
		
		void LstMonthlyStatsColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvwColumnSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending){
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			
			// Perform the sort with these new sort options.
			myListView.Sort();
			myListView.SetSortIcon(lvwColumnSorter.SortColumn, lvwColumnSorter.Order);
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
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
	}
}
