/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 23/03/2013
 * Time: 10:57
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
	/// Description of ToolsOptions.
	/// </summary>
	public partial class ToolsOptions : Form
	{
		public int _autopause;
		private SQLiteConnection _db;
		
		public ToolsOptions(int autoPause, SQLiteConnection con)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_autopause = autoPause;
			settingAutoPause.Text = _autopause.ToString();
			_db = con;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			_autopause = Convert.ToInt32(settingAutoPause.Text);
			// save the heart rate zone changes
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"update HeartRateZones set zoneMin = {1}, zoneMax = {2} where idZone = {0}";
			
			cmd.CommandText = string.Format(sql, 1, numZ1low.Value, numZ1high.Value);
			cmd.ExecuteNonQuery();
			//
			cmd.CommandText = string.Format(sql, 2, numZ2low.Value, numZ2high.Value);
			cmd.ExecuteNonQuery();
			//
			cmd.CommandText = string.Format(sql, 3, numZ3low.Value, numZ3high.Value);
			cmd.ExecuteNonQuery();
			//
			cmd.CommandText = string.Format(sql, 4, numZ4low.Value, numZ4high.Value);
			cmd.ExecuteNonQuery();
			//
			cmd.CommandText = string.Format(sql, 5, numZ5low.Value, numZ5high.Value);
			cmd.ExecuteNonQuery();
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		void ToolsOptionsLoad(object sender, EventArgs e)
		{
			SQLiteCommand cmd = new SQLiteCommand(_db);
			string sql = @"select * from HeartRateZones order by idZone asc";
			cmd.CommandText = sql;
			SQLiteDataReader rdr = cmd.ExecuteReader();
			if(rdr.HasRows){
				while(rdr.Read()){
					int z = Convert.ToInt32(rdr["idZone"]);
					switch(Convert.ToInt32(rdr["idZone"])){
						case 1:
							numZ1low.Value = Convert.ToInt32(rdr["zoneMin"]);
							numZ1high.Value = Convert.ToInt32(rdr["zoneMax"]);
							break;
						case 2:
							numZ2low.Value = Convert.ToInt32(rdr["zoneMin"]);
							numZ2high.Value = Convert.ToInt32(rdr["zoneMax"]);
							break;
						case 3:
							numZ3low.Value = Convert.ToInt32(rdr["zoneMin"]);
							numZ3high.Value = Convert.ToInt32(rdr["zoneMax"]);
							break;
						case 4:
							numZ4low.Value = Convert.ToInt32(rdr["zoneMin"]);
							numZ4high.Value = Convert.ToInt32(rdr["zoneMax"]);
							break;
						case 5:
							numZ5low.Value = Convert.ToInt32(rdr["zoneMin"]);
							numZ5high.Value = Convert.ToInt32(rdr["zoneMax"]);
							break;
					}
				}
				
			}
			else{
				numZ1low.Value = 0;
				numZ1high.Value = 113;
				//
				numZ2low.Value = 113;
				numZ2high.Value = 149;
				//
				numZ3low.Value = 149;
				numZ3high.Value = 168;
				//
				numZ4low.Value = 168;
				numZ4high.Value = 186;
				//
				numZ5low.Value = 186;
				numZ5high.Value = 255;
			}
		}
	}
}
