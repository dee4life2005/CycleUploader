/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/03/2013
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class UserWeeklyStats
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserWeeklyStats));
			this.label1 = new System.Windows.Forms.Label();
			this.lstMonthlyStats = new System.Windows.Forms.ListView();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 23);
			this.label1.TabIndex = 48;
			this.label1.Text = "User Weekly Statistics";
			// 
			// lstMonthlyStats
			// 
			this.lstMonthlyStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstMonthlyStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader15,
									this.columnHeader23,
									this.columnHeader16,
									this.columnHeader17,
									this.columnHeader18,
									this.columnHeader30,
									this.columnHeader31,
									this.columnHeader24,
									this.columnHeader25,
									this.columnHeader26,
									this.columnHeader27,
									this.columnHeader28,
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader29});
			this.lstMonthlyStats.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstMonthlyStats.GridLines = true;
			this.lstMonthlyStats.Location = new System.Drawing.Point(12, 35);
			this.lstMonthlyStats.Name = "lstMonthlyStats";
			this.lstMonthlyStats.Size = new System.Drawing.Size(999, 317);
			this.lstMonthlyStats.TabIndex = 49;
			this.lstMonthlyStats.UseCompatibleStateImageBehavior = false;
			this.lstMonthlyStats.View = System.Windows.Forms.View.Details;
			this.lstMonthlyStats.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstMonthlyStatsColumnClick);
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Week";
			this.columnHeader15.Width = 73;
			// 
			// columnHeader23
			// 
			this.columnHeader23.Text = "Count";
			this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Total Distance (miles)";
			this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader16.Width = 100;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Total Moving";
			this.columnHeader17.Width = 102;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "Avg. Speed (mph)";
			this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader18.Width = 100;
			// 
			// columnHeader30
			// 
			this.columnHeader30.Text = "Avg. Cadence";
			this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader30.Width = 74;
			// 
			// columnHeader31
			// 
			this.columnHeader31.Text = "Avg. HeartRate";
			this.columnHeader31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader31.Width = 75;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "Total Ascent (ft)";
			this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader24.Width = 85;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "Max Speed (mph)";
			this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader25.Width = 85;
			// 
			// columnHeader26
			// 
			this.columnHeader26.Text = "Max HeartRate";
			this.columnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader27
			// 
			this.columnHeader27.Text = "Max Cadence";
			this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader27.Width = 68;
			// 
			// columnHeader28
			// 
			this.columnHeader28.Text = "Max Ascent (ft)";
			this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader28.Width = 67;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "No. Commute";
			this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Commute Distance (miles).";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "";
			this.columnHeader29.Width = 5;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Controls.Add(this.lineSeparator4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 358);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1023, 45);
			this.panel1.TabIndex = 50;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(936, 8);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 32);
			this.btnOk.TabIndex = 24;
			this.btnOk.Text = "Close";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 0);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(1023, 2);
			this.lineSeparator4.TabIndex = 17;
			// 
			// UserWeeklyStats
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 403);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lstMonthlyStats);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1039, 441);
			this.Name = "UserWeeklyStats";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Weekly Statistics";
			this.Load += new System.EventHandler(this.UserWeeklyStatsLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button btnOk;
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader31;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ListView lstMonthlyStats;
		private System.Windows.Forms.Label label1;
	}
}
