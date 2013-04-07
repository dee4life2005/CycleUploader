/*
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
using System.Threading;

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
				try{
					control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
				}catch{}
		  	}
			else{
				try{
					control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
				}catch{}
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
			Thread th = new Thread(new ThreadStart(upgradeSchema));
			th.Start();
		}
		
		void upgradeSchema()
		{
			try{
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
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
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
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);						
						goto case 2;
					case 2: 
						sql = @"DROP VIEW ""main"".""view_file_summary""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"CREATE  VIEW ""main"".""view_file_summary"" AS  
							select  fs.*,
							        case f.fileActivityName ISNULL when 1 then f.fileName else f.fileActivityName end as `fileName`, f.fileActivityNotes,
							        fileUploadRunkeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS, 
							        fileIsCommute, fileIsStationaryTrainer, fileIsIncludedInStats, f.fileActivityDateTime
							from File f 
							left join FileSummary fs on f.idFile = fs.idFile
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from+=1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);						
						goto case 3;
					case 3:
						// add compound index on file and timestamp
						sql= @"CREATE  INDEX ""main"".""trackpoints_idx_filetime"" ON ""FileTrackpoints"" (""idFile"" ASC, ""tpTime"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from+=1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
						goto case 4;
					case 4:
						sql = @"DROP VIEW if exists ""main"".""view_user_monthlystats""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// recreate the monthly stats view, with the correct adjustment for 0 cadence / heart rate averages when working out 
						// the monthly average figure ... this takes in to account any ride where cadence / heart rate information isn't available
						// i.e. it excludes them
						sql = @"						
							CREATE  VIEW ""main"".""view_user_monthlystats"" AS
							select  strftime(""%Y-%m"",f.fileActivityDateTime) as `ym`,
							        SUM(fs.fsDistance) as `totalDistance`, 
							        SUM(fs.fsMovingTime) as `totalDurationMoving`,
							        COUNT(f.idFile)  as `fileCount`,
							        SUM(ifnull(fs.fsTotalAscent,0)) as `totalAscent`,
							        MAX(case fs.fsMaxSpeed = 255 when 1 then 0 else fs.fsMaxSpeed end) as `maxSpeed`,
							        MAX(case fs.fsMaxHeartRate = 255 when 1 then 0 else fs.fsMaxHeartRate end) as `maxHeartRate`,
							        MAX(case fs.fsMaxCadence = 255 when 1 then 0 else fs.fsMaxCadence end) as `maxCadence`,
							        MAX(CAST(fs.fsTotalAscent as double)) as `maxAscent`,
							        ifnull(SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsAvgCadence end * fs.fsMovingTime) / SUM(case fs.fsAvgCadence = 255 or fs.fsAvgCadence = 0 when 1 then 0 else fs.fsMovingTime end),0) as `avgCadence`,
							        ifnull(SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsAvgHeart end * fs.fsMovingTime) / SUM(case fs.fsAvgHeart = 255 or fs.fsAvgHeart = 0 when 1 then 0 else fs.fsMovingTime end),0) as `avgHeart`
							from File f
							join FileSummary fs on fs.idFile = f.idFile
							where f.fileIsIncludedInStats = 1
							group by ym
							order by ym asc					
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from+=1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
						goto case 5;
					case 5:
						sql = @"CREATE TABLE ""ApplicationSettings"" (""SettingName"" VARCHAR NOT NULL  UNIQUE , ""SettingValue"" VARCHAR NOT NULL  DEFAULT """")";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// adjust the FileSummary table schema to use non-varchar data types 
						// which should result in smaller database size
						sql = @"CREATE TABLE ""FileSummaryTEMP"" (""idFile"" INTEGER,""fsDuration"" INTEGER,""fsDistance"" FLOAT,""fsCalories"" INTEGER,""fsAvgHeart"" INTEGER,""fsAvgCadence"" INTEGER,""fsAvgSpeed"" FLOAT,""fsMovingTime"" INTEGER,""fsTotalAscent"" FLOAT,""fsTotalDescent"" FLOAT,""fsMaxHeartRate"" INTEGER,""fsMaxCadence"" INTEGER,""fsMaxSpeed"" FLOAT, ""fsAvgPower"" FLOAT, ""fsMaxPower"" FLOAT)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"INSERT INTO ""FileSummaryTEMP"" SELECT * from FileSummary";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"DROP TABLE ""FileSummary""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"ALTER TABLE ""FileSummaryTEMP"" RENAME TO ""FileSummary""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// adjust the FileTrackpoints table scheme to use non-varchar data types
						// which should result in smaller database size
						sql = @"CREATE TABLE ""FileTrackpointsTEMP"" (""idFile"" INTEGER,""tpTime"" VARCHAR,""tpDuration"" INTEGER,""tpAltitude"" FLOAT,""tpDistance"" FLOAT,""tpHeart"" INTEGER,""tpCadence"" INTEGER,""tpSpeed"" FLOAT,""tpLongitude"" FLOAT,""tpLatitude"" FLOAT,""tpTemperature"" INTEGER,""tpIsAutoPaused"" VARCHAR, ""tpPower"" FLOAT NOT NULL  DEFAULT 0)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"INSERT INTO FileTrackpointsTEMP SELECT * from FileTrackpoints";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"DROP TABLE ""FileTrackpoints""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"ALTER TABLE ""FileTrackpointsTEMP"" RENAME TO ""FileTrackpoints""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// need to recreate the FileTrackpoints file/time index
						sql= @"CREATE  INDEX ""main"".""trackpoints_idx_filetime"" ON ""FileTrackpoints"" (""idFile"" ASC, ""tpTime"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// need to recreate the FileSummary file index
						sql = @"CREATE INDEX ""filesummary_idx_idFile"" ON ""FileSummary"" (""idFile"" ASC)";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						
						_db_version_from+=1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
						goto case 6;
					case 6:
						// add the course table
						sql = @"CREATE TABLE ""Course"" (""courseId"" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , ""courseName"" VARCHAR NOT NULL  UNIQUE )";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// add the course route table
						sql = @"CREATE TABLE ""CourseRoute"" (""courseId"" INTEGER NOT NULL , ""lat"" DOUBLE NOT NULL , ""lng"" DOUBLE NOT NULL , ""idx"" INTEGER NOT NULL )";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// add the course id to the "File" table
						sql = @"ALTER TABLE ""main"".""File"" ADD COLUMN ""idCourse"" INTEGER";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						// alter the file_summary view to include course id
						sql = @"DROP VIEW IF EXISTS ""main"".""view_filehistory""";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						sql = @"CREATE  VIEW ""main"".""view_filehistory"" AS    
							select  f.idFile, 
							        CASE fileActivityDateTime IS NULL when 1 then fileOpenDateTime else fileActivityDateTime end as `fileActivityName`, 
							        case fileActivityName ISNULL when 1 then fileName else fileActivityName end as `fileActivityDescription`, 
							        fileOpenDateTime, 
							        case fileActivityNotes ISNULL when 1 then """" else fileActivityNotes end as `fileActivityNotes`, 
							        fileUploadRunKeeper, fileUploadStrava, fileUploadGarmin, fileUploadRWGPS, 
							        fs.fsDistance, fs.fsMovingTime, fs.fsAvgSpeed, f.fileIsCommute, f.fileIsStationaryTrainer,
							        f.idCourse,
							        c.courseName
							from File f 
							left join FileSummary fs on fs.idFile = f.idFile 
							left join Course c on c.courseId = f.idCourse
							order by fileActivityDateTime desc
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from+=1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
						goto case 7;
					case 7:
						// create view to retrieve the course summary information for Course Listing
						sql = @"
							CREATE  VIEW  IF NOT EXISTS ""main"".""view_course_list"" AS 
							select
							  c.courseId,
							  c.courseName,
							  COUNT(f.idFile) as `courseActivityCount`,
							  MIN(f.fileActivityDateTime) as `courseRiddenFirst`,
							  MAX(f.fileActivityDateTime) as `courseRiddenLatest`,
							  MIN(fs.fsDuration) as `durationLow`,
							  MAX(fs.fsDuration) as `durationHigh`,
							  AVG(fs.fsDuration) as `durationLTA`,
							  MIN(fs.fsAvgSpeed) as `avgspeedLow`,
							  MAX(fs.fsAvgSpeed) as `avgspeedHight`,
							  AVG(fs.fsAvgSpeed) as `avgspeedLTA`,
							  SUM(fs.fsDistance) as `cumulativeDistance`,
							  SUM(fs.fsDuration) as `cumulativeDuration` 
							from
							  Course c 
							  left join File f 
							    on f.idCourse = c.courseId 
							  left join FileSummary fs 
							    on fs.idFile = f.idFile 
							group by c.courseId 						
						";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();
						_db_version_from += 1;
						SetControlPropertyThreadSafe(prgStatus, "Value", _db_version_from);
						Thread.Sleep(500);
						goto case 8;
					case 8:
						// do nothing, current version
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
		}
	}
}
