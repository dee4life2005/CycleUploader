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
			lvwColumnSorter = new ListViewColumnSorter();
			lstMonthlyStats.ListViewItemSorter = lvwColumnSorter;
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
							System.DateTime.Parse((string)rdr["ym"]).ToString("yyyy-MM"),
							rdr.GetInt32(3).ToString(),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["totalDistance"])),
							string.Format("{0:D2} h {1:D2} m {2:D2} s", Convert.ToInt32(Math.Floor(tsMoving.TotalHours)), tsMoving.Minutes, tsMoving.Seconds),
							string.Format("{0:0.00}", (Convert.ToDouble(rdr["totalDistance"]) / Convert.ToDouble(rdr["totalDurationMoving"]))*3600),
							string.Format("{0:0}", Convert.ToInt32(rdr["avgCadence"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["avgHeart"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["totalAscent"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["maxSpeed"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["maxHeartRate"])),
							string.Format("{0:0}", Convert.ToInt32(rdr["maxCadence"])),
							string.Format("{0:0.00}", Convert.ToDouble(rdr["maxAscent"]))
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
	}
}
