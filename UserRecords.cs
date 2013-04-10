/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/03/2013
 * Time: 12:49
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
	/// Description of UserRecords.
	/// </summary>
	public partial class UserRecords : Form
	{
		private SQLiteConnection _db;
		
		public UserRecords(SQLiteConnection db)
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
		
		private void initialiseRecords()
		{
			string sql = @"select * from view_user_records";
			SQLiteCommand command = new SQLiteCommand(_db);
			command.CommandText = sql;
			SQLiteDataReader rdr = command.ExecuteReader();
			if(rdr.HasRows){
				while(rdr.Read()){
					string recText = "";
					TimeSpan ts;
					switch((string)rdr["recordType"]){
						case "OVERALL_NO_RIDES":
							recText = string.Format("{0:0}", Convert.ToInt32(rdr["recordValue"]));
							break;
						case "OVERALL_TOTAL_DISTANCE":
							recText = string.Format("{0:0.00} miles", Convert.ToDouble(rdr["recordValue"]));
							break;
						case "OVERALL_TOTAL_DURATION":
							ts = TimeSpan.FromSeconds(Convert.ToDouble(rdr["recordValue"]));
							recText = string.Format("{0:D} h {1:D2} m {2:D2} s", Convert.ToInt32(Math.Floor(ts.TotalHours)), ts.Minutes, ts.Seconds);
							break;
							
						case "OVERALL_MAX_AVG_SPEED":
						case "COMMUTE_MAX_AVG_SPEED":
						case "TRAINER_MAX_AVG_SPEED":
							recText = string.Format("{0:0.00} mph, achieved on {1} [ {2} ]",
							                        Convert.ToDouble(rdr["recordValue"]),
							                        System.DateTime.Parse((string)rdr["recordDate"]).ToString("dd MMMM yyyy"),
							                        (string)rdr["recordActivityName"]
							                       );
							break;
						case "OVERALL_MAX_ASCENT":
						case "COMMUTE_MAX_ASCENT":
						//case "TRAILER_MAX_ASCENT": not applicable
							recText = string.Format("{0:0.00} ft, achieved on {1} [ {2} ]", 
						                        Convert.ToDouble(rdr["recordValue"]),
							                    System.DateTime.Parse((string)rdr["recordDate"]).ToString("dd MMMM yyyy"),
							                    (string)rdr["recordActivityName"]
							                   );
							break;
						case "OVERALL_MAX_DISTANCE":
						case "COMMUTE_MAX_DISTANCE":
						case "TRAINER_MAX_DISTANCE":
							recText = string.Format("{0:0.00} miles, achieved on {1} [ {2} ]", 
							                        Convert.ToDouble(rdr["recordValue"]),
							                        System.DateTime.Parse((string)rdr["recordDate"]).ToString("dd MMMM yyyy"),
							                        (string)rdr["recordActivityName"]
							                       );
							break;
						case "OVERALL_MAX_DURATION":
						case "COMMUTE_MAX_DURATION":
						case "TRAINER_MAX_DURATION":
							ts = TimeSpan.FromSeconds(Convert.ToDouble(rdr["recordValue"]));

							recText = string.Format("{0:D2} h {1:D2} m {2:D2} s, achieved on {3} [ {4} ]", ts.Hours, ts.Minutes, ts.Seconds,
							                        System.DateTime.Parse((string)rdr["recordDate"]).ToString("dd MMMM yyyy"),
							                        (string)rdr["recordActivityName"]
							                        );
							break;
						case "COMMUTE_TOTAL_DAYS":
							recText = string.Format("{0} total days commuting", 
							                       Convert.ToInt32(rdr["recordValue"])
							                       );
							break;
						case "COMMUTE_LAST_DATE":
						case "TRAINER_LAST_DATE":
							recText = System.DateTime.Parse((string)rdr["recordValue"]).ToString("dd MMMM yyyy");
							break;
					}
					switch((string)rdr["recordType"]){
						// overall stats
						case "OVERALL_MAX_AVG_SPEED":
							recAverageSpeed.Text = recText;
							break;
						case "OVERALL_MAX_ASCENT":
							recMostClimbing.Text = recText;
							break;
						case "OVERALL_MAX_DISTANCE":
							recLongestRide.Text = recText;
							break;
						case "OVERALL_MAX_DURATION":
							recLongestDuration.Text = recText;
							break;
						case "OVERALL_NO_RIDES":
							recNoRides.Text = recText;
							break;
						case "OVERALL_TOTAL_DURATION":
							recTotalDuration.Text = recText;
							break;
						case "OVERALL_TOTAL_DISTANCE":
							recTotalDistance.Text = recText;
							break;
						// commute stats
						case "COMMUTE_MAX_AVG_SPEED":
							recCommuteFastestSpeed.Text = recText;
							break;
						case "COMMUTE_MAX_ASCENT":
							recCommuteMostClimbing.Text = recText;
							break;
						case "COMMUTE_MAX_DISTANCE":
							recCommuteLongestRide.Text = recText;
							break;
						case "COMMUTE_MAX_DURATION":
							recCommuteLongestDuration.Text = recText;
							break;
						case "COMMUTE_TOTAL_DAYS":
							recCommuteTotalDays.Text = recText;
							break;
						case "COMMUTE_LAST_DATE":
							recCommuteLast.Text = recText;
							break;
						// trainer stats
						case "TRAINER_MAX_AVG_SPEED":
							recTrainerFastestSpeed.Text = recText;
							break;
						case "TRAINER_MAX_DISTANCE":
							recTrainerLongestRide.Text = recText;
							break;
						case "TRAINER_MAX_DURATION":
							recTrainerLongestDuration.Text = recText;
							break;
						case "TRAINER_LAST_DATE":
							recTrainerLast.Text = recText;
							break;
					}
				}
			}
		}
		
		void UserRecordsLoad(object sender, EventArgs e)
		{
			initialiseRecords();
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
		
		void GroupBox1Enter(object sender, EventArgs e)
		{
			
		}
	}
}
