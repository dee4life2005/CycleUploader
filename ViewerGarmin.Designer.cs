/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 03/03/2013
 * Time: 22:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class ViewerGarmin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerGarmin));
			this.pnlActivities = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstActivities = new ListViewNF.ListViewNF();
			this.colActivityId = new System.Windows.Forms.ColumnHeader();
			this.colStartTime = new System.Windows.Forms.ColumnHeader();
			this.colActivityName = new System.Windows.Forms.ColumnHeader();
			this.colDurationMoving = new System.Windows.Forms.ColumnHeader();
			this.colDistanceMetres = new System.Windows.Forms.ColumnHeader();
			this.colAltitude = new System.Windows.Forms.ColumnHeader();
			this.colAvgMovingSpeed = new System.Windows.Forms.ColumnHeader();
			this.colAvgCadence = new System.Windows.Forms.ColumnHeader();
			this.colAvgHeartRate = new System.Windows.Forms.ColumnHeader();
			this.colMaxCadence = new System.Windows.Forms.ColumnHeader();
			this.colMaxHeartRate = new System.Windows.Forms.ColumnHeader();
			this.colMaxSpeed = new System.Windows.Forms.ColumnHeader();
			this.colMinTemp = new System.Windows.Forms.ColumnHeader();
			this.colAvgTemp = new System.Windows.Forms.ColumnHeader();
			this.colDurationTotal = new System.Windows.Forms.ColumnHeader();
			this.colUploadDate = new System.Windows.Forms.ColumnHeader();
			this.colDeviceName = new System.Windows.Forms.ColumnHeader();
			this.label15 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstUserMetrics = new ListViewNF.ListViewNF();
			this.colMonth = new System.Windows.Forms.ColumnHeader();
			this.colActivities = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colDuration = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colElevation = new System.Windows.Forms.ColumnHeader();
			this.colCalories = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusBarStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlActivities.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlActivities
			// 
			this.pnlActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlActivities.Controls.Add(this.label1);
			this.pnlActivities.Controls.Add(this.lstActivities);
			this.pnlActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlActivities.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlActivities.Location = new System.Drawing.Point(7, 268);
			this.pnlActivities.Name = "pnlActivities";
			this.pnlActivities.Size = new System.Drawing.Size(908, 362);
			this.pnlActivities.TabIndex = 4;
			this.pnlActivities.TabStop = false;
			this.pnlActivities.Text = "Activities";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(902, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Click Activity To View In Browser. note: you will have to log in to GarminConnect" +
			" to view the activity unless it was made public.";
			// 
			// lstActivities
			// 
			this.lstActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colActivityId,
									this.colStartTime,
									this.colActivityName,
									this.colDurationMoving,
									this.colDistanceMetres,
									this.colAltitude,
									this.colAvgMovingSpeed,
									this.colAvgCadence,
									this.colAvgHeartRate,
									this.colMaxCadence,
									this.colMaxHeartRate,
									this.colMaxSpeed,
									this.colMinTemp,
									this.colAvgTemp,
									this.colDurationTotal,
									this.colUploadDate,
									this.colDeviceName});
			this.lstActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstActivities.FullRowSelect = true;
			this.lstActivities.GridLines = true;
			this.lstActivities.HideSelection = false;
			this.lstActivities.Location = new System.Drawing.Point(3, 31);
			this.lstActivities.Name = "lstActivities";
			this.lstActivities.Size = new System.Drawing.Size(902, 324);
			this.lstActivities.TabIndex = 1;
			this.lstActivities.UseCompatibleStateImageBehavior = false;
			this.lstActivities.View = System.Windows.Forms.View.Details;
			this.lstActivities.SelectedIndexChanged += new System.EventHandler(this.LstActivitiesSelectedIndexChanged);
			// 
			// colActivityId
			// 
			this.colActivityId.Text = "Id";
			// 
			// colStartTime
			// 
			this.colStartTime.Text = "Date/Time";
			// 
			// colActivityName
			// 
			this.colActivityName.Text = "Activity Name";
			this.colActivityName.Width = 96;
			// 
			// colDurationMoving
			// 
			this.colDurationMoving.Text = "Moving Time";
			// 
			// colDistanceMetres
			// 
			this.colDistanceMetres.Text = "Distance";
			// 
			// colAltitude
			// 
			this.colAltitude.Text = "Altitude";
			this.colAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgMovingSpeed
			// 
			this.colAvgMovingSpeed.Text = "Avg. Speed";
			this.colAvgMovingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgCadence
			// 
			this.colAvgCadence.Text = "Avg. Cadence";
			this.colAvgCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgHeartRate
			// 
			this.colAvgHeartRate.Text = "Avg. Heart Rate";
			this.colAvgHeartRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxCadence
			// 
			this.colMaxCadence.Text = "Max. Cadence";
			this.colMaxCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxHeartRate
			// 
			this.colMaxHeartRate.Text = "Max. Heart Rate";
			this.colMaxHeartRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxSpeed
			// 
			this.colMaxSpeed.Text = "Max. Speed";
			this.colMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMinTemp
			// 
			this.colMinTemp.Text = "Min. Temp";
			// 
			// colAvgTemp
			// 
			this.colAvgTemp.Text = "Avg. Temp";
			this.colAvgTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colDurationTotal
			// 
			this.colDurationTotal.Text = "Total Time";
			// 
			// colUploadDate
			// 
			this.colUploadDate.Text = "Upload Date";
			this.colUploadDate.Width = 81;
			// 
			// colDeviceName
			// 
			this.colDeviceName.Text = "Device";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(53, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(264, 23);
			this.label15.TabIndex = 20;
			this.label15.Text = "GarminConnect Profile";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(15, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lstUserMetrics);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.groupBox1.Location = new System.Drawing.Point(10, 49);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(908, 213);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User Metrics";
			// 
			// lstUserMetrics
			// 
			this.lstUserMetrics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colMonth,
									this.colActivities,
									this.colDistance,
									this.colDuration,
									this.colAvgSpeed,
									this.colElevation,
									this.colCalories,
									this.columnHeader4});
			this.lstUserMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstUserMetrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstUserMetrics.FullRowSelect = true;
			this.lstUserMetrics.GridLines = true;
			this.lstUserMetrics.HideSelection = false;
			this.lstUserMetrics.Location = new System.Drawing.Point(3, 16);
			this.lstUserMetrics.Name = "lstUserMetrics";
			this.lstUserMetrics.Size = new System.Drawing.Size(902, 194);
			this.lstUserMetrics.TabIndex = 1;
			this.lstUserMetrics.UseCompatibleStateImageBehavior = false;
			this.lstUserMetrics.View = System.Windows.Forms.View.Details;
			// 
			// colMonth
			// 
			this.colMonth.Text = "Month/Year";
			// 
			// colActivities
			// 
			this.colActivities.Text = "No. Activities";
			this.colActivities.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colActivities.Width = 93;
			// 
			// colDistance
			// 
			this.colDistance.Text = "Distance";
			this.colDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colDuration
			// 
			this.colDuration.Text = "Duration";
			this.colDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colDuration.Width = 79;
			// 
			// colAvgSpeed
			// 
			this.colAvgSpeed.Text = "Avg. Speed";
			this.colAvgSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colAvgSpeed.Width = 80;
			// 
			// colElevation
			// 
			this.colElevation.Text = "Elevation Gain";
			this.colElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colElevation.Width = 85;
			// 
			// colCalories
			// 
			this.colCalories.Text = "Calories";
			this.colCalories.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "";
			// 
			// statusBar
			// 
			this.statusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusBar.BackgroundImage")));
			this.statusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.statusBarProgress,
									this.statusBarStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 633);
			this.statusBar.Name = "statusBar";
			this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusBar.Size = new System.Drawing.Size(922, 22);
			this.statusBar.TabIndex = 24;
			this.statusBar.Text = "statusBar";
			// 
			// statusBarProgress
			// 
			this.statusBarProgress.Name = "statusBarProgress";
			this.statusBarProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// statusBarStatus
			// 
			this.statusBarStatus.Name = "statusBarStatus";
			this.statusBarStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// ViewerGarmin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(922, 655);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pnlActivities);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(938, 693);
			this.Name = "ViewerGarmin";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Garmin Connect Profile";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerGarminFormClosing);
			this.Load += new System.EventHandler(this.ViewerGarminLoad);
			this.Shown += new System.EventHandler(this.ViewerGarminShown);
			this.pnlActivities.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripStatusLabel statusBarStatus;
		private System.Windows.Forms.ToolStripProgressBar statusBarProgress;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader colMinTemp;
		private System.Windows.Forms.ColumnHeader colStartTime;
		private System.Windows.Forms.ColumnHeader colAvgTemp;
		private System.Windows.Forms.ColumnHeader colAvgMovingSpeed;
		private System.Windows.Forms.ColumnHeader colAvgHeartRate;
		private System.Windows.Forms.ColumnHeader colAvgCadence;
		private System.Windows.Forms.ColumnHeader colDurationTotal;
		private System.Windows.Forms.ColumnHeader colDurationMoving;
		private System.Windows.Forms.ColumnHeader colDistanceMetres;
		private System.Windows.Forms.ColumnHeader colMaxSpeed;
		private System.Windows.Forms.ColumnHeader colMaxHeartRate;
		private System.Windows.Forms.ColumnHeader colMaxCadence;
		private System.Windows.Forms.ColumnHeader colAltitude;
		private System.Windows.Forms.ColumnHeader colUploadDate;
		private System.Windows.Forms.ColumnHeader colDeviceName;
		private System.Windows.Forms.ColumnHeader colActivityName;
		private System.Windows.Forms.ColumnHeader colActivityId;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colDistance;
		private System.Windows.Forms.ColumnHeader colElevation;
		private System.Windows.Forms.ColumnHeader colCalories;
		private System.Windows.Forms.ColumnHeader colDuration;
		private System.Windows.Forms.ColumnHeader colActivities;
		private System.Windows.Forms.ColumnHeader colMonth;
		private System.Windows.Forms.ListView lstUserMetrics;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ListView lstActivities;
		private System.Windows.Forms.GroupBox pnlActivities;
	}
}
