/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/03/2013
 * Time: 13:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class ViewerStrava
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerStrava));
			this.lblProfileName = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.grpProfile = new System.Windows.Forms.GroupBox();
			this.lblTotalActivities = new System.Windows.Forms.Label();
			this.lstStravaRides = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.pbLoading = new System.Windows.Forms.ProgressBar();
			this.lblLoadingStatus = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.grpProfile.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblProfileName
			// 
			this.lblProfileName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProfileName.Location = new System.Drawing.Point(6, 16);
			this.lblProfileName.Name = "lblProfileName";
			this.lblProfileName.Size = new System.Drawing.Size(271, 23);
			this.lblProfileName.TabIndex = 19;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(46, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(264, 23);
			this.label15.TabIndex = 21;
			this.label15.Text = "Strava Profile";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			// 
			// grpProfile
			// 
			this.grpProfile.Controls.Add(this.lblTotalActivities);
			this.grpProfile.Controls.Add(this.lblProfileName);
			this.grpProfile.Location = new System.Drawing.Point(8, 41);
			this.grpProfile.Name = "grpProfile";
			this.grpProfile.Size = new System.Drawing.Size(283, 118);
			this.grpProfile.TabIndex = 22;
			this.grpProfile.TabStop = false;
			this.grpProfile.Text = "Profile";
			// 
			// lblTotalActivities
			// 
			this.lblTotalActivities.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTotalActivities.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalActivities.Location = new System.Drawing.Point(198, 52);
			this.lblTotalActivities.Name = "lblTotalActivities";
			this.lblTotalActivities.Size = new System.Drawing.Size(79, 63);
			this.lblTotalActivities.TabIndex = 20;
			this.lblTotalActivities.Text = "0 Activities";
			this.lblTotalActivities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lstStravaRides
			// 
			this.lstStravaRides.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader3,
									this.columnHeader2,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8,
									this.columnHeader9,
									this.columnHeader10,
									this.columnHeader11});
			this.lstStravaRides.Location = new System.Drawing.Point(8, 165);
			this.lstStravaRides.Name = "lstStravaRides";
			this.lstStravaRides.Size = new System.Drawing.Size(708, 216);
			this.lstStravaRides.TabIndex = 23;
			this.lstStravaRides.UseCompatibleStateImageBehavior = false;
			this.lstStravaRides.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Id";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 108;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Distance";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Elapsed";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Moving";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Avg. Speed";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Elev.";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Bike";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Commute";
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Trainer";
			// 
			// pbLoading
			// 
			this.pbLoading.Location = new System.Drawing.Point(297, 149);
			this.pbLoading.Name = "pbLoading";
			this.pbLoading.Size = new System.Drawing.Size(419, 10);
			this.pbLoading.TabIndex = 24;
			// 
			// lblLoadingStatus
			// 
			this.lblLoadingStatus.Location = new System.Drawing.Point(425, 133);
			this.lblLoadingStatus.Name = "lblLoadingStatus";
			this.lblLoadingStatus.Size = new System.Drawing.Size(267, 13);
			this.lblLoadingStatus.TabIndex = 25;
			this.lblLoadingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ViewerStrava
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 393);
			this.Controls.Add(this.lblLoadingStatus);
			this.Controls.Add(this.pbLoading);
			this.Controls.Add(this.lstStravaRides);
			this.Controls.Add(this.grpProfile);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pictureBox1);
			this.Name = "ViewerStrava";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Strava Profile Viewer";
			this.Shown += new System.EventHandler(this.ViewerStravaShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.grpProfile.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label lblLoadingStatus;
		private System.Windows.Forms.ProgressBar pbLoading;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label lblTotalActivities;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lstStravaRides;
		private System.Windows.Forms.GroupBox grpProfile;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label lblProfileName;
	}
}
