﻿/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/03/2013
 * Time: 11:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;

namespace CycleUploader
{
	/// <summary>
	/// Description of DatabaseSchemaUpdate.
	/// </summary>
	public partial class DatabaseSchemaUpdate : Form
	{
		private long _db_version_from;
		private long _db_version_to;
		private SQLiteConnection _db_conn;
		
		private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
		public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
		{
			if (control.InvokeRequired){
		  		control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
		  	}
			else{
				control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
			}
		}
		
		public DatabaseSchemaUpdate(long db_version_from, long db_version_to, SQLiteConnection db_conn)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_db_conn = db_conn;
			_db_version_from = db_version_from;
			_db_version_to = db_version_to;
		}
		
		void DatabaseSchemaUpdateShown(object sender, EventArgs e)
		{
			try{
			
				this.Show();
				SetControlPropertyThreadSafe(lblMigrationNote, "Text", string.Format("Upgrading database from v{0} to v{1}", _db_version_from, _db_version_to));
				SetControlPropertyThreadSafe(prgStatus, "Maximum", (int)(_db_version_to-_db_version_from));
				SetControlPropertyThreadSafe(prgStatus, "Value", 0);
				SetControlPropertyThreadSafe(lblProgressStatus, "Text", "Upgrading database to latest version, please wait");
				
				SQLiteCommand cmd = new SQLiteCommand(_db_conn);
				string sql;
				// perform actions to upgrade from each version in sequence.
				switch(_db_version_from){
					case 0:
						// create file summary view
						sql = @"
							CREATE VIEW ""view_file_summary"" AS select  fs.*, 
							        case f.fileActivityName ISNULL when 1 then f.fileName else f.fileActivityName end as `fileName`, f.fileActivityNotes,
							        fileUploadRunkeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS, 
							        fileIsCommute, fileIsStationaryTrainer, fileIsIncludedInStats 
							from File f 
							left join FileSummary fs on f.idFile = fs.idFile where f.idFile
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// create file history view
						sql = @"
							CREATE VIEW ""view_filehistory"" AS
							select  f.idFile, 
							        CASE fileActivityDateTime IS NULL when 1 then fileOpenDateTime else fileActivityDateTime end as `fileActivityName`, 
							        case fileActivityName ISNULL when 1 then fileName else fileActivityName end as `fileActivityDescription`, 
							        fileOpenDateTime, 
							        case fileActivityNotes ISNULL when 1 then """" else fileActivityNotes end as `fileActivityNotes`, 
							        fileUploadRunKeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS, 
							        fs.fsDistance, fs.fsMovingTime, fs.fsAvgSpeed, f.fileIsCommute, f.fileIsStationaryTrainer 
							from File f 
							left join FileSummary fs on fs.idFile = f.idFile 
							order by fileActivityDateTime desc						
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// create user file history view
						sql = @"
							CREATE VIEW ""view_user_monthlystats"" AS select  strftime(""%Y-%m"",f.fileActivityDateTime) as `ym`, 
							        SUM(fs.fsDistance) as `totalDistance`, 
							        SUM(fs.fsMovingTime) as `totalDurationMoving`,
							        COUNT(f.idFile)  as `fileCount`,
							        SUM(fs.fsTotalAscent) as `totalAscent`,
							        MAX(case fs.fsMaxSpeed = 255 when 1 then 0 else fs.fsMaxSpeed end) as `maxSpeed`,
							        MAX(case fs.fsMaxHeartRate = 255 when 1 then 0 else fs.fsMaxHeartRate end) as `maxHeartRate`,
							        MAX(case fs.fsMaxCadence = 255 when 1 then 0 else fs.fsMaxCadence end) as `maxCadence`,
							        MAX(CAST(fs.fsTotalAscent as double)) as `maxAscent`,
							        SUM(case fs.fsAvgCadence = 255 when 1 then 0 else fs.fsAvgCadence end * fs.fsMovingTime) / SUM(case fs.fsAvgCadence = 255 when 1 then 0 else fs.fsMovingTime end) as `avgCadence`,
							        SUM(case fs.fsAvgHeart = 255 when 1 then 0 else fs.fsAvgHeart end * fs.fsMovingTime) / SUM(case fs.fsAvgHeart = 255 when 1 then 0 else fs.fsMovingTime end) as `avgHeart`
							from File f
							join FileSummary fs on fs.idFile = f.idFile
							where f.fileIsIncludedInStats = 1
							group by ym
							order by ym asc	
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// create user records view
						sql = @"
							CREATE VIEW ""view_user_records"" AS select * from (
							  select
							      ""OVERALL_MAX_AVG_SPEED"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsAvgSpeed as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsAvgSpeed as double) desc limit 1
							) as max_speed
							UNION ALL 
							select * from (
							  select  
							      ""OVERALL_MAX_ASCENT"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsTotalAscent as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsTotalAscent as double) desc limit 1
							) as max_ascent
							UNION ALL 
							select * from (
							  select  
							      ""OVERALL_MAX_DISTANCE"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDistance as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_distance
							UNION ALL				
							select * from (
							  select  
							      ""OVERALL_MAX_DURATION"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDuration as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_duration
							UNION ALL				
							select * from (
							  select  
							      ""OVERALL_NO_RIDES"" as `recordType`, """" as `recordDate`,
							      """" as `recordActivityName`,
							      """","""", COUNT(*) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							) as no_rides
							UNION ALL				
							select * from (
							  select  
							      ""OVERALL_TOTAL_DISTANCE"" as `recordType`, """" as `recordDate`,
							      """" as `recordActivityName`,
							      """" as `recordDistance`, """" as `recordDuration`, CAST(IFNULL(SUM(CAST(fs.fsDistance as double)),0) as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							) as total_distance
							UNION ALL				
							select * from (
							  select  
							      ""OVERALL_TOTAL_DURATION"" as `recordType`, """" as `recordDate`,
							      """" as `recordActivityName`,
							      """" as `recordDistance`, """" as `recordDuration`, CAST(IFNULL(SUM(CAST(fs.fsDuration as double)),0) as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsIncludedInStats = 1
							) as total_distance
							
							UNION ALL	
							select * from (
							  select
							      ""COMMUTE_MAX_AVG_SPEED"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsAvgSpeed as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsAvgSpeed as double) desc limit 1
							) as max_speed_commute
							UNION ALL 
							select * from (
							  select  
							      ""COMMUTE_MAX_ASCENT"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsTotalAscent as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsTotalAscent as double) desc limit 1
							) as max_ascent_commute
							UNION ALL 
							select * from (
							  select  
							      ""COMMUTE_MAX_DISTANCE"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDistance as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_distance_commute
							UNION ALL				
							select * from (
							  select  
							      ""COMMUTE_MAX_DURATION"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDuration as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_duration_commute
							UNION ALL
							select * from (
							  select  
							      ""COMMUTE_TOTAL_DAYS"" as `recordType`,"""" as `recordDate`,
							      """" as `recordActivityName`,
							      """","""" as `recordDuration`, COUNT(distinct DATE(f.fileActivityDateTime)) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							) as total_days_commute
							UNION ALL
							select * from (
							  select  
							      ""COMMUTE_LAST_DATE"" as `recordType`,"""" as `recordDate`,
							      """" as `recordActivityName`,
							      """","""" as `recordDuration`, f.fileActivityDateTime as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsCommute = 1 and f.fileIsIncludedInStats = 1
							  order by f.fileActivityDateTime desc limit 1
							) as last_date_commute
							
							UNION ALL
							select * from (
							  select
							      ""TRAINER_MAX_AVG_SPEED"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsAvgSpeed as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsStationaryTrainer = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsAvgSpeed as double) desc limit 1
							) as max_speed_trainer
							UNION ALL 
							select * from (
							  select  
							      ""TRAINER_MAX_DISTANCE"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDistance as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsStationaryTrainer = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_distance_trainer
							UNION ALL				
							select * from (
							  select  
							      ""TRAINER_MAX_DURATION"" as `recordType`, DATE(f.fileActivityDateTime) as `recordDate`,
							      case IFNULL(f.fileActivityName,"""") == """" when 1 then fileName else fileActivityName end as `recordActivityName`,
							      fs.fsDistance as `recordDistance`, fs.fsDuration as `recordDuration`, CAST(fs.fsDuration as double) as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsStationaryTrainer = 1 and f.fileIsIncludedInStats = 1
							  order by CAST(fs.fsDistance as double) desc limit 1
							) as max_duration_trainer	
							UNION ALL
							select * from (
							  select  
							      ""TRAINER_LAST_DATE"" as `recordType`,"""" as `recordDate`,
							      """" as `recordActivityName`,
							      """","""" as `recordDuration`, f.fileActivityDateTime as `recordValue`
							  from File f
							  join FileSummary fs on fs.idFile = f.idFile
							  where f.fileIsStationaryTrainer = 1 and f.fileIsIncludedInStats = 1
							  order by f.fileActivityDateTime desc limit 1
							) as last_date_trainer						
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// create some indices
						sql = @"CREATE INDEX ""file_idx_filename"" ON ""File"" (""fileName"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						//
						sql = @"CREATE INDEX ""file_idx_is_commute"" ON ""File"" (""fileIsCommute"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						//
						sql = @"CREATE INDEX ""file_idx_is_trainer"" ON ""File"" (""fileIsStationaryTrainer"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// 
						sql = @"CREATE INDEX ""filesummary_idx_idFile"" ON ""FileSummary"" (""idFile"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						//
						sql = @"CREATE INDEX ""filetrackpoints_idx_idFile"" ON ""FileTrackpoints"" (""idFile"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// add avg power column to FileSummary
						sql = @"ALTER TABLE ""main"".""FileSummary"" ADD COLUMN ""fsAvgPower"" varchar";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// add max power column to FileSummary
						sql = @"ALTER TABLE ""main"".""FileSummary"" ADD COLUMN ""fsMaxPower"" varchar";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// add power column to FileTrackpoints
						sql = @"ALTER TABLE ""main"".""FileTrackpoints"" ADD COLUMN ""tpPower"" float NOT NULL  DEFAULT 0";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from += 1;
						goto case 1; // now upgrade to the next version ... etc.
					case 1:
						// drop the monthlystats view, as we need to make a change to it
						sql = @"DROP VIEW ""main"".""view_user_monthlystats""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// recreate the monthly stats view, with the correct adjustment for 0 cadence / heart rate averages when working out 
						// the monthly average figure ... this takes in to account any ride where cadence / heart rate information isn't available
						// i.e. it excludes them
						sql = @"						
							CREATE  VIEW ""main"".""view_user_monthlystats"" AS  select  strftime(""%Y-%m"",f.fileActivityDateTime) as `ym`, 
							        SUM(fs.fsDistance) as `totalDistance`, 
							        SUM(fs.fsMovingTime) as `totalDurationMoving`,
							        COUNT(f.idFile)  as `fileCount`,
							        SUM(ifnull(fs.fsTotalAscent,0)) as `totalAscent`,
							        MAX(case fs.fsMaxSpeed = 255 when 1 then 0 else fs.fsMaxSpeed end) as `maxSpeed`,
							        MAX(case fs.fsMaxHeartRate = 255 when 1 then 0 else fs.fsMaxHeartRate end) as `maxHeartRate`,
							        MAX(case fs.fsMaxCadence = 255 when 1 then 0 else fs.fsMaxCadence end) as `maxCadence`,
							        MAX(CAST(fs.fsTotalAscent as double)) as `maxAscent`,
							        SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsAvgCadence end * fs.fsMovingTime) / SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsMovingTime end) as `avgCadence`,
							        SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsAvgHeart end * fs.fsMovingTime) / SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsMovingTime end) as `avgHeart`
							from File f
							join FileSummary fs on fs.idFile = f.idFile
							where f.fileIsIncludedInStats = 1
							group by ym
							order by ym asc
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// create the heart rate zones table
						sql = @"
							CREATE TABLE ""HeartRateZones"" (
							  ""idZone"" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL ,
							  ""zoneLabel"" varchar NOT NULL ,
							  ""zoneMin"" INTEGER NOT NULL ,
							  ""zoneMax"" INTEGER NOT NULL
							)
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// initialise the heart rate zones with "my" default values, based on a max heart rate of 192.
						sql = @"
							INSERT into ""main"".""HeartRateZones"" (""idZone"", ""zoneLabel"", ""zoneMin"", ""zoneMax"") 
							select 1, ""Endurance"", 0, 113
							UNION ALL select 2, ""Moderate"", 113, 149
							UNION ALL select 3, ""Tempo"", 149, 168
							UNION ALL select 4, ""Threshold"", 168,186
							UNION ALL select 5, ""Anerobic"", 186, 255
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from += 1;
						goto case 2;
					case 2: 
						// do nothing as current versio, proceed to next version
						goto default;
					default:
						// issue command to set the db version in the database
						cmd.CommandText = string.Format("PRAGMA user_version = {0}", _db_version_to);
						cmd.ExecuteNonQuery();
						break;
				}
				this.DialogResult = DialogResult.OK;
				
			}
			catch(Exception ex){
				MessageBox.Show("Database Upgrade: Exception\r\n" + ex.Message);
				this.DialogResult = DialogResult.Abort;
			}
			finally{
				this.Close();
			}
		}
	}
}