/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/04/2013
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class Courses
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Courses));
			this.lstCourses = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tCourseDistance = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tAverageSpeed = new System.Windows.Forms.Label();
			this.tAverageDuration = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tSlowestSpeed = new System.Windows.Forms.Label();
			this.tSlowestDuration = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tFastestSpeed = new System.Windows.Forms.Label();
			this.tFastestDuration = new System.Windows.Forms.Label();
			this.tLastRidden = new System.Windows.Forms.Label();
			this.tFirstRidden = new System.Windows.Forms.Label();
			this.tRideCount = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.map = new System.Windows.Forms.WebBrowser();
			this.tCourseName = new System.Windows.Forms.Label();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDeleteCourse = new System.Windows.Forms.Button();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.lstCourseActivities = new ListViewExtended.ListViewExtended();
			this.colFileId = new System.Windows.Forms.ColumnHeader();
			this.colActivityDateTime = new System.Windows.Forms.ColumnHeader();
			this.colActivityFilename = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colDuration = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colIsCommute = new System.Windows.Forms.ColumnHeader();
			this.colIsStationaryTrainer = new System.Windows.Forms.ColumnHeader();
			this.colNotes = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstCourses
			// 
			this.lstCourses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCourses.FormattingEnabled = true;
			this.lstCourses.Location = new System.Drawing.Point(3, 16);
			this.lstCourses.Name = "lstCourses";
			this.lstCourses.Size = new System.Drawing.Size(305, 269);
			this.lstCourses.TabIndex = 0;
			this.lstCourses.SelectedIndexChanged += new System.EventHandler(this.LstCoursesSelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tCourseDistance);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.tLastRidden);
			this.groupBox1.Controls.Add(this.tFirstRidden);
			this.groupBox1.Controls.Add(this.tRideCount);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.map);
			this.groupBox1.Controls.Add(this.tCourseName);
			this.groupBox1.Location = new System.Drawing.Point(329, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(562, 288);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Course Details";
			// 
			// tCourseDistance
			// 
			this.tCourseDistance.AutoEllipsis = true;
			this.tCourseDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tCourseDistance.ForeColor = System.Drawing.Color.CadetBlue;
			this.tCourseDistance.Location = new System.Drawing.Point(6, 40);
			this.tCourseDistance.Name = "tCourseDistance";
			this.tCourseDistance.Size = new System.Drawing.Size(248, 27);
			this.tCourseDistance.TabIndex = 27;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.tAverageSpeed);
			this.groupBox4.Controls.Add(this.tAverageDuration);
			this.groupBox4.Location = new System.Drawing.Point(6, 233);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(254, 49);
			this.groupBox4.TabIndex = 26;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Long-term Average";
			// 
			// tAverageSpeed
			// 
			this.tAverageSpeed.Location = new System.Drawing.Point(148, 20);
			this.tAverageSpeed.Name = "tAverageSpeed";
			this.tAverageSpeed.Size = new System.Drawing.Size(100, 17);
			this.tAverageSpeed.TabIndex = 25;
			this.tAverageSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tAverageDuration
			// 
			this.tAverageDuration.Location = new System.Drawing.Point(6, 20);
			this.tAverageDuration.Name = "tAverageDuration";
			this.tAverageDuration.Size = new System.Drawing.Size(100, 17);
			this.tAverageDuration.TabIndex = 24;
			this.tAverageDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tSlowestSpeed);
			this.groupBox3.Controls.Add(this.tSlowestDuration);
			this.groupBox3.Location = new System.Drawing.Point(6, 178);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(254, 49);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Slowest";
			// 
			// tSlowestSpeed
			// 
			this.tSlowestSpeed.Location = new System.Drawing.Point(148, 20);
			this.tSlowestSpeed.Name = "tSlowestSpeed";
			this.tSlowestSpeed.Size = new System.Drawing.Size(100, 17);
			this.tSlowestSpeed.TabIndex = 25;
			this.tSlowestSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tSlowestDuration
			// 
			this.tSlowestDuration.Location = new System.Drawing.Point(6, 20);
			this.tSlowestDuration.Name = "tSlowestDuration";
			this.tSlowestDuration.Size = new System.Drawing.Size(100, 17);
			this.tSlowestDuration.TabIndex = 24;
			this.tSlowestDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tFastestSpeed);
			this.groupBox2.Controls.Add(this.tFastestDuration);
			this.groupBox2.Location = new System.Drawing.Point(6, 123);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(254, 49);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Fastest";
			// 
			// tFastestSpeed
			// 
			this.tFastestSpeed.Location = new System.Drawing.Point(148, 20);
			this.tFastestSpeed.Name = "tFastestSpeed";
			this.tFastestSpeed.Size = new System.Drawing.Size(100, 17);
			this.tFastestSpeed.TabIndex = 25;
			this.tFastestSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tFastestDuration
			// 
			this.tFastestDuration.Location = new System.Drawing.Point(6, 20);
			this.tFastestDuration.Name = "tFastestDuration";
			this.tFastestDuration.Size = new System.Drawing.Size(100, 17);
			this.tFastestDuration.TabIndex = 24;
			this.tFastestDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tLastRidden
			// 
			this.tLastRidden.Location = new System.Drawing.Point(6, 102);
			this.tLastRidden.Name = "tLastRidden";
			this.tLastRidden.Size = new System.Drawing.Size(254, 18);
			this.tLastRidden.TabIndex = 23;
			// 
			// tFirstRidden
			// 
			this.tFirstRidden.Location = new System.Drawing.Point(6, 85);
			this.tFirstRidden.Name = "tFirstRidden";
			this.tFirstRidden.Size = new System.Drawing.Size(254, 17);
			this.tFirstRidden.TabIndex = 22;
			// 
			// tRideCount
			// 
			this.tRideCount.Location = new System.Drawing.Point(6, 67);
			this.tRideCount.Name = "tRideCount";
			this.tRideCount.Size = new System.Drawing.Size(254, 18);
			this.tRideCount.TabIndex = 21;
			this.tRideCount.Text = "< Select Course From List On Left >";
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(266, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(2, 239);
			this.label5.TabIndex = 20;
			// 
			// map
			// 
			this.map.AllowWebBrowserDrop = false;
			this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.map.IsWebBrowserContextMenuEnabled = false;
			this.map.Location = new System.Drawing.Point(271, 43);
			this.map.Margin = new System.Windows.Forms.Padding(0);
			this.map.MinimumSize = new System.Drawing.Size(20, 20);
			this.map.Name = "map";
			this.map.ScriptErrorsSuppressed = true;
			this.map.ScrollBarsEnabled = false;
			this.map.Size = new System.Drawing.Size(285, 239);
			this.map.TabIndex = 19;
			this.map.TabStop = false;
			this.map.Url = new System.Uri("about:blank", System.UriKind.Absolute);
			// 
			// tCourseName
			// 
			this.tCourseName.AutoEllipsis = true;
			this.tCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tCourseName.Location = new System.Drawing.Point(6, 15);
			this.tCourseName.Name = "tCourseName";
			this.tCourseName.Size = new System.Drawing.Size(550, 24);
			this.tCourseName.TabIndex = 0;
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 0);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(903, 2);
			this.lineSeparator4.TabIndex = 17;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnDeleteCourse);
			this.panel1.Controls.Add(this.lineSeparator4);
			this.panel1.Controls.Add(this.btnMapFullscreen);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 524);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(903, 45);
			this.panel1.TabIndex = 16;
			// 
			// btnDeleteCourse
			// 
			this.btnDeleteCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeleteCourse.Location = new System.Drawing.Point(12, 10);
			this.btnDeleteCourse.Name = "btnDeleteCourse";
			this.btnDeleteCourse.Size = new System.Drawing.Size(107, 32);
			this.btnDeleteCourse.TabIndex = 18;
			this.btnDeleteCourse.Text = "Delete Course...";
			this.btnDeleteCourse.UseVisualStyleBackColor = true;
			this.btnDeleteCourse.Click += new System.EventHandler(this.BtnDeleteCourseClick);
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(830, 10);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(61, 32);
			this.btnMapFullscreen.TabIndex = 7;
			this.btnMapFullscreen.UseVisualStyleBackColor = true;
			this.btnMapFullscreen.Click += new System.EventHandler(this.BtnMapFullscreenClick);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.lstCourses);
			this.groupBox5.Location = new System.Drawing.Point(12, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(311, 288);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Course List";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.lstCourseActivities);
			this.groupBox6.Location = new System.Drawing.Point(12, 302);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(879, 216);
			this.groupBox6.TabIndex = 18;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Course Ride History";
			// 
			// lstCourseActivities
			// 
			this.lstCourseActivities.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstCourseActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colFileId,
									this.colActivityDateTime,
									this.colActivityFilename,
									this.colDistance,
									this.colDuration,
									this.colAvgSpeed,
									this.colIsCommute,
									this.colIsStationaryTrainer,
									this.colNotes});
			this.lstCourseActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCourseActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstCourseActivities.FullRowSelect = true;
			this.lstCourseActivities.HideSelection = false;
			this.lstCourseActivities.Location = new System.Drawing.Point(3, 16);
			this.lstCourseActivities.MultiSelect = false;
			this.lstCourseActivities.Name = "lstCourseActivities";
			this.lstCourseActivities.Size = new System.Drawing.Size(873, 197);
			this.lstCourseActivities.TabIndex = 1;
			this.lstCourseActivities.UseCompatibleStateImageBehavior = false;
			this.lstCourseActivities.View = System.Windows.Forms.View.Details;
			this.lstCourseActivities.DoubleClick += new System.EventHandler(this.LstCourseActivitiesDoubleClick);
			// 
			// colFileId
			// 
			this.colFileId.Text = "File ID";
			this.colFileId.Width = 45;
			// 
			// colActivityDateTime
			// 
			this.colActivityDateTime.Text = "Activity Date/Time";
			this.colActivityDateTime.Width = 105;
			// 
			// colActivityFilename
			// 
			this.colActivityFilename.Text = "Activity / FileName";
			this.colActivityFilename.Width = 122;
			// 
			// colDistance
			// 
			this.colDistance.Text = "Distance";
			this.colDistance.Width = 120;
			// 
			// colDuration
			// 
			this.colDuration.Text = "Duration";
			this.colDuration.Width = 73;
			// 
			// colAvgSpeed
			// 
			this.colAvgSpeed.Text = "Avg. Speed";
			this.colAvgSpeed.Width = 120;
			// 
			// colIsCommute
			// 
			this.colIsCommute.Text = "Commute";
			this.colIsCommute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colIsStationaryTrainer
			// 
			this.colIsStationaryTrainer.Text = "Trainer";
			this.colIsStationaryTrainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colNotes
			// 
			this.colNotes.Text = "Notes";
			this.colNotes.Width = 500;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(356, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Double-Click Ride to View Ride Details";
			// 
			// Courses
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(903, 569);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Courses";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Courses";
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader colNotes;
		private System.Windows.Forms.ColumnHeader colIsStationaryTrainer;
		private System.Windows.Forms.ColumnHeader colIsCommute;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colDuration;
		private System.Windows.Forms.ColumnHeader colDistance;
		private System.Windows.Forms.ColumnHeader colActivityFilename;
		private System.Windows.Forms.ColumnHeader colActivityDateTime;
		private System.Windows.Forms.ColumnHeader colFileId;
		private ListViewExtended.ListViewExtended lstCourseActivities;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label tCourseDistance;
		private System.Windows.Forms.Button btnDeleteCourse;
		private System.Windows.Forms.Button btnMapFullscreen;
		private System.Windows.Forms.Panel panel1;
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.WebBrowser map;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label tRideCount;
		private System.Windows.Forms.Label tFirstRidden;
		private System.Windows.Forms.Label tLastRidden;
		private System.Windows.Forms.Label tFastestDuration;
		private System.Windows.Forms.Label tFastestSpeed;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label tSlowestDuration;
		private System.Windows.Forms.Label tSlowestSpeed;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label tAverageDuration;
		private System.Windows.Forms.Label tAverageSpeed;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label tCourseName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lstCourses;
	}
}
