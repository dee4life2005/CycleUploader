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

namespace CycleUploader
{
	/// <summary>
	/// Description of UserMonthlyStats.
	/// </summary>
	public partial class UserMonthlyStats : Form
	{
		private SQLiteConnection _db;
		
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
		
		public UserMonthlyStats(SQLiteConnection db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db = db;
		}
		
		private void initialiseMonthlyStats()
		{
			lstMonthlyStats.Items.Clear();
			SQLiteCommand command = new SQLiteCommand(_db);
			string sql = @"select * from view_user_monthlystats order by ym desc";
			
			try{
				command.CommandText = sql;
				SQLiteDataReader rdr = command.ExecuteReader();
				if(rdr.HasRows){
					while(rdr.Read()){
						TimeSpan tsMoving = TimeSpan.FromSeconds(Convert.ToInt32(rdr["totalDurationMoving"]));
						string[] row = {
							System.DateTime.Parse((string)rdr["ym"]).ToString("yyyy MMMM"),
							rdr.GetInt32(3).ToString(),
							string.Format("{0:0.00} miles", Convert.ToDouble(rdr["totalDistance"])),
							string.Format("{0:D2} h {1:D2} m {2:D2} s", Convert.ToInt32(Math.Floor(tsMoving.TotalHours)), tsMoving.Minutes, tsMoving.Seconds),
							string.Format("{0:0.00} mph", (Convert.ToDouble(rdr["totalDistance"]) / Convert.ToDouble(rdr["totalDurationMoving"]))*3600),
							string.Format("{0:0} rpm", Convert.ToInt32(rdr["avgCadence"])),
							string.Format("{0:0} bpm", Convert.ToInt32(rdr["avgHeart"])),
							string.Format("{0:0.00} ft", Convert.ToDouble(rdr["totalAscent"])),
							string.Format("{0:0.00} mph", Convert.ToDouble(rdr["maxSpeed"])),
							string.Format("{0:0} bpm", Convert.ToInt32(rdr["maxHeartRate"])),
							string.Format("{0:0} rpm", Convert.ToInt32(rdr["maxCadence"])),
							string.Format("{0:0.00} ft", Convert.ToDouble(rdr["maxAscent"]))
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
		
		void UserMonthlyStatsLoad(object sender, EventArgs e)
		{
			initialiseMonthlyStats();
		}
	}
}
