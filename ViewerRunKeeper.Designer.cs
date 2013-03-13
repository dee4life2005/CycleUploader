/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/02/2013
 * Time: 14:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class ViewerRunKeeper
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerRunKeeper));
			this.pnlProfile = new System.Windows.Forms.GroupBox();
			this.lblTotalActivities = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblLocation = new System.Windows.Forms.Label();
			this.lblProfile = new System.Windows.Forms.LinkLabel();
			this.pbElite = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lblDob = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblGender = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblAthleteType = new System.Windows.Forms.Label();
			this.lblProfileName = new System.Windows.Forms.Label();
			this.pbProfileMedium = new System.Windows.Forms.PictureBox();
			this.lstStreetTeam = new System.Windows.Forms.ListView();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.pnlRecords = new System.Windows.Forms.GroupBox();
			this.lstRecords = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.pnlActivities = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lstActivities = new System.Windows.Forms.ListView();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabSummary = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.lstSplits = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.label14 = new System.Windows.Forms.Label();
			this.richActivityComments = new System.Windows.Forms.RichTextBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lnkRunkeper = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.lblLastModified = new System.Windows.Forms.Label();
			this.lblTotalAscent = new System.Windows.Forms.Label();
			this.lblActivityEquipment = new System.Windows.Forms.Label();
			this.lblActivityType = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.lblAvgSpeed = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblActivityDateTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblAvgHeartRate = new System.Windows.Forms.Label();
			this.lblCalories = new System.Windows.Forms.Label();
			this.lblDistance = new System.Windows.Forms.Label();
			this.lblDuration = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.tabChart = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbkChartHeart = new System.Windows.Forms.CheckBox();
			this.cbkChartSpeed = new System.Windows.Forms.CheckBox();
			this.zedActivityChart = new ZedGraph.ZedGraphControl();
			this.pnlStreetTeam = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label15 = new System.Windows.Forms.Label();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusBarStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlProfile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbElite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbProfileMedium)).BeginInit();
			this.pnlRecords.SuspendLayout();
			this.pnlActivities.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabSummary.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabChart.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlStreetTeam.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlProfile
			// 
			this.pnlProfile.Controls.Add(this.lblTotalActivities);
			this.pnlProfile.Controls.Add(this.label3);
			this.pnlProfile.Controls.Add(this.lblLocation);
			this.pnlProfile.Controls.Add(this.lblProfile);
			this.pnlProfile.Controls.Add(this.pbElite);
			this.pnlProfile.Controls.Add(this.label4);
			this.pnlProfile.Controls.Add(this.lblDob);
			this.pnlProfile.Controls.Add(this.label2);
			this.pnlProfile.Controls.Add(this.lblGender);
			this.pnlProfile.Controls.Add(this.label1);
			this.pnlProfile.Controls.Add(this.lblAthleteType);
			this.pnlProfile.Controls.Add(this.lblProfileName);
			this.pnlProfile.Controls.Add(this.pbProfileMedium);
			this.pnlProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlProfile.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlProfile.Location = new System.Drawing.Point(4, 38);
			this.pnlProfile.Name = "pnlProfile";
			this.pnlProfile.Size = new System.Drawing.Size(345, 127);
			this.pnlProfile.TabIndex = 0;
			this.pnlProfile.TabStop = false;
			this.pnlProfile.Text = "Profile";
			// 
			// lblTotalActivities
			// 
			this.lblTotalActivities.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTotalActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalActivities.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalActivities.Location = new System.Drawing.Point(252, 34);
			this.lblTotalActivities.Name = "lblTotalActivities";
			this.lblTotalActivities.Size = new System.Drawing.Size(79, 63);
			this.lblTotalActivities.TabIndex = 13;
			this.lblTotalActivities.Text = "0 Activities";
			this.lblTotalActivities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(67, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Location:";
			// 
			// lblLocation
			// 
			this.lblLocation.BackColor = System.Drawing.SystemColors.Control;
			this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLocation.Location = new System.Drawing.Point(149, 84);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(99, 13);
			this.lblLocation.TabIndex = 11;
			// 
			// lblProfile
			// 
			this.lblProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProfile.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblProfile.Location = new System.Drawing.Point(67, 101);
			this.lblProfile.Name = "lblProfile";
			this.lblProfile.Size = new System.Drawing.Size(264, 20);
			this.lblProfile.TabIndex = 10;
			this.lblProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblProfileLinkClicked);
			// 
			// pbElite
			// 
			this.pbElite.Image = ((System.Drawing.Image)(resources.GetObject("pbElite.Image")));
			this.pbElite.Location = new System.Drawing.Point(7, 68);
			this.pbElite.Name = "pbElite";
			this.pbElite.Size = new System.Drawing.Size(58, 29);
			this.pbElite.TabIndex = 9;
			this.pbElite.TabStop = false;
			this.pbElite.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(67, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "DOB:";
			// 
			// lblDob
			// 
			this.lblDob.BackColor = System.Drawing.SystemColors.Control;
			this.lblDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDob.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDob.Location = new System.Drawing.Point(149, 68);
			this.lblDob.Name = "lblDob";
			this.lblDob.Size = new System.Drawing.Size(99, 13);
			this.lblDob.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(67, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Gender:";
			// 
			// lblGender
			// 
			this.lblGender.BackColor = System.Drawing.SystemColors.Control;
			this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGender.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGender.Location = new System.Drawing.Point(149, 52);
			this.lblGender.Name = "lblGender";
			this.lblGender.Size = new System.Drawing.Size(99, 13);
			this.lblGender.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(67, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Ahtlete Type:";
			// 
			// lblAthleteType
			// 
			this.lblAthleteType.BackColor = System.Drawing.SystemColors.Control;
			this.lblAthleteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAthleteType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAthleteType.Location = new System.Drawing.Point(149, 36);
			this.lblAthleteType.Name = "lblAthleteType";
			this.lblAthleteType.Size = new System.Drawing.Size(99, 13);
			this.lblAthleteType.TabIndex = 2;
			// 
			// lblProfileName
			// 
			this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProfileName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblProfileName.Location = new System.Drawing.Point(67, 15);
			this.lblProfileName.Name = "lblProfileName";
			this.lblProfileName.Size = new System.Drawing.Size(264, 23);
			this.lblProfileName.TabIndex = 1;
			// 
			// pbProfileMedium
			// 
			this.pbProfileMedium.Location = new System.Drawing.Point(11, 15);
			this.pbProfileMedium.Name = "pbProfileMedium";
			this.pbProfileMedium.Size = new System.Drawing.Size(50, 50);
			this.pbProfileMedium.TabIndex = 0;
			this.pbProfileMedium.TabStop = false;
			// 
			// lstStreetTeam
			// 
			this.lstStreetTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader10,
									this.columnHeader12,
									this.columnHeader13});
			this.lstStreetTeam.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstStreetTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstStreetTeam.FullRowSelect = true;
			this.lstStreetTeam.GridLines = true;
			this.lstStreetTeam.Location = new System.Drawing.Point(3, 16);
			this.lstStreetTeam.Name = "lstStreetTeam";
			this.lstStreetTeam.Size = new System.Drawing.Size(498, 108);
			this.lstStreetTeam.TabIndex = 14;
			this.lstStreetTeam.UseCompatibleStateImageBehavior = false;
			this.lstStreetTeam.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Name";
			this.columnHeader10.Width = 120;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Profile";
			this.columnHeader12.Width = 297;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Uri";
			this.columnHeader13.Width = 0;
			// 
			// pnlRecords
			// 
			this.pnlRecords.Controls.Add(this.lstRecords);
			this.pnlRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlRecords.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlRecords.Location = new System.Drawing.Point(4, 171);
			this.pnlRecords.Name = "pnlRecords";
			this.pnlRecords.Size = new System.Drawing.Size(256, 182);
			this.pnlRecords.TabIndex = 2;
			this.pnlRecords.TabStop = false;
			this.pnlRecords.Text = "Records";
			// 
			// lstRecords
			// 
			this.lstRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.lstRecords.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstRecords.FullRowSelect = true;
			this.lstRecords.GridLines = true;
			this.lstRecords.Location = new System.Drawing.Point(3, 16);
			this.lstRecords.Name = "lstRecords";
			this.lstRecords.Size = new System.Drawing.Size(250, 163);
			this.lstRecords.TabIndex = 0;
			this.lstRecords.UseCompatibleStateImageBehavior = false;
			this.lstRecords.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Record";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Date";
			this.columnHeader2.Width = 70;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Value";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 50;
			// 
			// pnlActivities
			// 
			this.pnlActivities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlActivities.Controls.Add(this.label5);
			this.pnlActivities.Controls.Add(this.lstActivities);
			this.pnlActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlActivities.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlActivities.Location = new System.Drawing.Point(263, 171);
			this.pnlActivities.Name = "pnlActivities";
			this.pnlActivities.Size = new System.Drawing.Size(596, 182);
			this.pnlActivities.TabIndex = 3;
			this.pnlActivities.TabStop = false;
			this.pnlActivities.Text = "Activities";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(101, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Click to View Activity";
			// 
			// lstActivities
			// 
			this.lstActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader9,
									this.columnHeader4,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader5,
									this.columnHeader8});
			this.lstActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstActivities.FullRowSelect = true;
			this.lstActivities.GridLines = true;
			this.lstActivities.HideSelection = false;
			this.lstActivities.Location = new System.Drawing.Point(3, 16);
			this.lstActivities.Name = "lstActivities";
			this.lstActivities.Size = new System.Drawing.Size(590, 163);
			this.lstActivities.TabIndex = 1;
			this.lstActivities.UseCompatibleStateImageBehavior = false;
			this.lstActivities.View = System.Windows.Forms.View.Details;
			this.lstActivities.Click += new System.EventHandler(this.LstActivitiesClick);
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Type";
			this.columnHeader9.Width = 70;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Date/Time";
			this.columnHeader4.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Duration";
			this.columnHeader6.Width = 80;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Distance";
			this.columnHeader7.Width = 70;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Avg. Speed";
			this.columnHeader5.Width = 70;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Uri";
			this.columnHeader8.Width = 150;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.tabControl1);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.groupBox4.Location = new System.Drawing.Point(4, 359);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(855, 319);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Activity Details";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabSummary);
			this.tabControl1.Controls.Add(this.tabMap);
			this.tabControl1.Controls.Add(this.tabChart);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(3, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(849, 300);
			this.tabControl1.TabIndex = 1;
			// 
			// tabSummary
			// 
			this.tabSummary.BackColor = System.Drawing.SystemColors.Control;
			this.tabSummary.Controls.Add(this.label12);
			this.tabSummary.Controls.Add(this.lstSplits);
			this.tabSummary.Controls.Add(this.label14);
			this.tabSummary.Controls.Add(this.richActivityComments);
			this.tabSummary.Controls.Add(this.txtNotes);
			this.tabSummary.Controls.Add(this.lnkRunkeper);
			this.tabSummary.Controls.Add(this.label6);
			this.tabSummary.Controls.Add(this.lblLastModified);
			this.tabSummary.Controls.Add(this.lblTotalAscent);
			this.tabSummary.Controls.Add(this.lblActivityEquipment);
			this.tabSummary.Controls.Add(this.lblActivityType);
			this.tabSummary.Controls.Add(this.label21);
			this.tabSummary.Controls.Add(this.label22);
			this.tabSummary.Controls.Add(this.label23);
			this.tabSummary.Controls.Add(this.label24);
			this.tabSummary.Controls.Add(this.lblAvgSpeed);
			this.tabSummary.Controls.Add(this.label8);
			this.tabSummary.Controls.Add(this.lblActivityDateTime);
			this.tabSummary.Controls.Add(this.label7);
			this.tabSummary.Controls.Add(this.lblAvgHeartRate);
			this.tabSummary.Controls.Add(this.lblCalories);
			this.tabSummary.Controls.Add(this.lblDistance);
			this.tabSummary.Controls.Add(this.lblDuration);
			this.tabSummary.Controls.Add(this.label9);
			this.tabSummary.Controls.Add(this.label10);
			this.tabSummary.Controls.Add(this.label11);
			this.tabSummary.Controls.Add(this.label13);
			this.tabSummary.Location = new System.Drawing.Point(4, 22);
			this.tabSummary.Name = "tabSummary";
			this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tabSummary.Size = new System.Drawing.Size(841, 274);
			this.tabSummary.TabIndex = 0;
			this.tabSummary.Text = "Activity Summary";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.SteelBlue;
			this.label12.Location = new System.Drawing.Point(546, 3);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 11);
			this.label12.TabIndex = 89;
			this.label12.Text = "Split Times";
			// 
			// lstSplits
			// 
			this.lstSplits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstSplits.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lstSplits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader11,
									this.columnHeader14,
									this.columnHeader15});
			this.lstSplits.FullRowSelect = true;
			this.lstSplits.GridLines = true;
			this.lstSplits.Location = new System.Drawing.Point(546, 17);
			this.lstSplits.MultiSelect = false;
			this.lstSplits.Name = "lstSplits";
			this.lstSplits.Size = new System.Drawing.Size(289, 254);
			this.lstSplits.TabIndex = 88;
			this.lstSplits.UseCompatibleStateImageBehavior = false;
			this.lstSplits.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Mile";
			this.columnHeader11.Width = 82;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Speed";
			this.columnHeader14.Width = 88;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Pace";
			this.columnHeader15.Width = 94;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.SteelBlue;
			this.label14.Location = new System.Drawing.Point(297, 155);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 10);
			this.label14.TabIndex = 87;
			this.label14.Text = "Comments";
			// 
			// richActivityComments
			// 
			this.richActivityComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.richActivityComments.BackColor = System.Drawing.Color.WhiteSmoke;
			this.richActivityComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richActivityComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richActivityComments.Location = new System.Drawing.Point(297, 168);
			this.richActivityComments.Name = "richActivityComments";
			this.richActivityComments.ReadOnly = true;
			this.richActivityComments.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.richActivityComments.Size = new System.Drawing.Size(231, 103);
			this.richActivityComments.TabIndex = 86;
			this.richActivityComments.Text = "";
			// 
			// txtNotes
			// 
			this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.txtNotes.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNotes.Location = new System.Drawing.Point(17, 168);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ReadOnly = true;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(250, 100);
			this.txtNotes.TabIndex = 84;
			// 
			// lnkRunkeper
			// 
			this.lnkRunkeper.ForeColor = System.Drawing.Color.SteelBlue;
			this.lnkRunkeper.Location = new System.Drawing.Point(297, 16);
			this.lnkRunkeper.Name = "lnkRunkeper";
			this.lnkRunkeper.Size = new System.Drawing.Size(94, 23);
			this.lnkRunkeper.TabIndex = 0;
			this.lnkRunkeper.TabStop = true;
			this.lnkRunkeper.Text = "Open in Browser";
			this.lnkRunkeper.Visible = false;
			this.lnkRunkeper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRunkeperLinkClicked);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.SteelBlue;
			this.label6.Location = new System.Drawing.Point(17, 155);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 10);
			this.label6.TabIndex = 83;
			this.label6.Text = "Notes";
			// 
			// lblLastModified
			// 
			this.lblLastModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastModified.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblLastModified.Location = new System.Drawing.Point(415, 109);
			this.lblLastModified.Name = "lblLastModified";
			this.lblLastModified.Size = new System.Drawing.Size(132, 23);
			this.lblLastModified.TabIndex = 78;
			this.lblLastModified.Text = "-";
			// 
			// lblTotalAscent
			// 
			this.lblTotalAscent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAscent.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblTotalAscent.Location = new System.Drawing.Point(415, 86);
			this.lblTotalAscent.Name = "lblTotalAscent";
			this.lblTotalAscent.Size = new System.Drawing.Size(132, 23);
			this.lblTotalAscent.TabIndex = 77;
			this.lblTotalAscent.Text = "-";
			// 
			// lblActivityEquipment
			// 
			this.lblActivityEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityEquipment.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblActivityEquipment.Location = new System.Drawing.Point(415, 63);
			this.lblActivityEquipment.Name = "lblActivityEquipment";
			this.lblActivityEquipment.Size = new System.Drawing.Size(132, 23);
			this.lblActivityEquipment.TabIndex = 76;
			this.lblActivityEquipment.Text = "-";
			// 
			// lblActivityType
			// 
			this.lblActivityType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityType.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblActivityType.Location = new System.Drawing.Point(415, 40);
			this.lblActivityType.Name = "lblActivityType";
			this.lblActivityType.Size = new System.Drawing.Size(132, 23);
			this.lblActivityType.TabIndex = 75;
			this.lblActivityType.Text = "-";
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.SteelBlue;
			this.label21.Location = new System.Drawing.Point(297, 109);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(118, 23);
			this.label21.TabIndex = 73;
			this.label21.Text = "Last Modified By";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.SteelBlue;
			this.label22.Location = new System.Drawing.Point(297, 86);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 72;
			this.label22.Text = "Total Ascent";
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.Color.SteelBlue;
			this.label23.Location = new System.Drawing.Point(297, 63);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 71;
			this.label23.Text = "Equipment";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.Color.SteelBlue;
			this.label24.Location = new System.Drawing.Point(297, 40);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 70;
			this.label24.Text = "Type";
			// 
			// lblAvgSpeed
			// 
			this.lblAvgSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgSpeed.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblAvgSpeed.Location = new System.Drawing.Point(135, 132);
			this.lblAvgSpeed.Name = "lblAvgSpeed";
			this.lblAvgSpeed.Size = new System.Drawing.Size(156, 19);
			this.lblAvgSpeed.TabIndex = 69;
			this.lblAvgSpeed.Text = "-";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.SteelBlue;
			this.label8.Location = new System.Drawing.Point(17, 132);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 19);
			this.label8.TabIndex = 68;
			this.label8.Text = "Average Speed";
			// 
			// lblActivityDateTime
			// 
			this.lblActivityDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityDateTime.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblActivityDateTime.Location = new System.Drawing.Point(135, 17);
			this.lblActivityDateTime.Name = "lblActivityDateTime";
			this.lblActivityDateTime.Size = new System.Drawing.Size(156, 23);
			this.lblActivityDateTime.TabIndex = 67;
			this.lblActivityDateTime.Text = "-";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.SteelBlue;
			this.label7.Location = new System.Drawing.Point(17, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(118, 23);
			this.label7.TabIndex = 66;
			this.label7.Text = "Activity";
			// 
			// lblAvgHeartRate
			// 
			this.lblAvgHeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgHeartRate.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblAvgHeartRate.Location = new System.Drawing.Point(135, 109);
			this.lblAvgHeartRate.Name = "lblAvgHeartRate";
			this.lblAvgHeartRate.Size = new System.Drawing.Size(156, 23);
			this.lblAvgHeartRate.TabIndex = 64;
			this.lblAvgHeartRate.Text = "-";
			// 
			// lblCalories
			// 
			this.lblCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCalories.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblCalories.Location = new System.Drawing.Point(135, 86);
			this.lblCalories.Name = "lblCalories";
			this.lblCalories.Size = new System.Drawing.Size(156, 23);
			this.lblCalories.TabIndex = 63;
			this.lblCalories.Text = "-";
			// 
			// lblDistance
			// 
			this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDistance.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblDistance.Location = new System.Drawing.Point(135, 63);
			this.lblDistance.Name = "lblDistance";
			this.lblDistance.Size = new System.Drawing.Size(156, 23);
			this.lblDistance.TabIndex = 62;
			this.lblDistance.Text = "-";
			// 
			// lblDuration
			// 
			this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDuration.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblDuration.Location = new System.Drawing.Point(135, 40);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(156, 23);
			this.lblDuration.TabIndex = 61;
			this.lblDuration.Text = "-";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.SteelBlue;
			this.label9.Location = new System.Drawing.Point(17, 109);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(118, 23);
			this.label9.TabIndex = 59;
			this.label9.Text = "Average Heart Rate";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.SteelBlue;
			this.label10.Location = new System.Drawing.Point(17, 86);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 58;
			this.label10.Text = "Calories";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.SteelBlue;
			this.label11.Location = new System.Drawing.Point(17, 63);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 57;
			this.label11.Text = "Distance";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.SteelBlue;
			this.label13.Location = new System.Drawing.Point(17, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 56;
			this.label13.Text = "Duration";
			// 
			// tabMap
			// 
			this.tabMap.Controls.Add(this.btnMapFullscreen);
			this.tabMap.Controls.Add(this.webBrowser1);
			this.tabMap.Location = new System.Drawing.Point(4, 22);
			this.tabMap.Name = "tabMap";
			this.tabMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabMap.Size = new System.Drawing.Size(841, 274);
			this.tabMap.TabIndex = 2;
			this.tabMap.Text = "Map";
			this.tabMap.UseVisualStyleBackColor = true;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.AutoSize = true;
			this.btnMapFullscreen.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(804, 3);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(34, 268);
			this.btnMapFullscreen.TabIndex = 2;
			this.btnMapFullscreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnMapFullscreen.UseVisualStyleBackColor = true;
			this.btnMapFullscreen.Click += new System.EventHandler(this.BtnMapFullscreenClick);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.Location = new System.Drawing.Point(3, 3);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new System.Drawing.Size(795, 268);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
			// 
			// tabChart
			// 
			this.tabChart.Controls.Add(this.panel1);
			this.tabChart.Controls.Add(this.zedActivityChart);
			this.tabChart.Location = new System.Drawing.Point(4, 22);
			this.tabChart.Name = "tabChart";
			this.tabChart.Padding = new System.Windows.Forms.Padding(3);
			this.tabChart.Size = new System.Drawing.Size(841, 274);
			this.tabChart.TabIndex = 1;
			this.tabChart.Text = "Charts";
			this.tabChart.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.cbkChartHeart);
			this.panel1.Controls.Add(this.cbkChartSpeed);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(835, 33);
			this.panel1.TabIndex = 3;
			// 
			// cbkChartHeart
			// 
			this.cbkChartHeart.Checked = true;
			this.cbkChartHeart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkChartHeart.Location = new System.Drawing.Point(173, 4);
			this.cbkChartHeart.Name = "cbkChartHeart";
			this.cbkChartHeart.Size = new System.Drawing.Size(104, 24);
			this.cbkChartHeart.TabIndex = 2;
			this.cbkChartHeart.Text = "Heart-Rate";
			this.cbkChartHeart.UseVisualStyleBackColor = true;
			this.cbkChartHeart.CheckedChanged += new System.EventHandler(this.CbkChartHeartCheckedChanged);
			// 
			// cbkChartSpeed
			// 
			this.cbkChartSpeed.Checked = true;
			this.cbkChartSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkChartSpeed.Location = new System.Drawing.Point(63, 4);
			this.cbkChartSpeed.Name = "cbkChartSpeed";
			this.cbkChartSpeed.Size = new System.Drawing.Size(104, 24);
			this.cbkChartSpeed.TabIndex = 0;
			this.cbkChartSpeed.Text = "Speed";
			this.cbkChartSpeed.UseVisualStyleBackColor = true;
			this.cbkChartSpeed.CheckedChanged += new System.EventHandler(this.CbkChartSpeedCheckedChanged);
			// 
			// zedActivityChart
			// 
			this.zedActivityChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.zedActivityChart.IsShowPointValues = true;
			this.zedActivityChart.Location = new System.Drawing.Point(3, 37);
			this.zedActivityChart.Name = "zedActivityChart";
			this.zedActivityChart.ScrollGrace = 0D;
			this.zedActivityChart.ScrollMaxX = 0D;
			this.zedActivityChart.ScrollMaxY = 0D;
			this.zedActivityChart.ScrollMaxY2 = 0D;
			this.zedActivityChart.ScrollMinX = 0D;
			this.zedActivityChart.ScrollMinY = 0D;
			this.zedActivityChart.ScrollMinY2 = 0D;
			this.zedActivityChart.Size = new System.Drawing.Size(835, 234);
			this.zedActivityChart.TabIndex = 0;
			// 
			// pnlStreetTeam
			// 
			this.pnlStreetTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlStreetTeam.Controls.Add(this.lstStreetTeam);
			this.pnlStreetTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlStreetTeam.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlStreetTeam.Location = new System.Drawing.Point(355, 38);
			this.pnlStreetTeam.Name = "pnlStreetTeam";
			this.pnlStreetTeam.Size = new System.Drawing.Size(504, 127);
			this.pnlStreetTeam.TabIndex = 15;
			this.pnlStreetTeam.TabStop = false;
			this.pnlStreetTeam.Text = "Street Team";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(46, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(264, 23);
			this.label15.TabIndex = 18;
			this.label15.Text = "Runkeeper Profile";
			// 
			// statusBar
			// 
			this.statusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusBar.BackgroundImage")));
			this.statusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.statusBarProgress,
									this.statusBarStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 681);
			this.statusBar.Name = "statusBar";
			this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusBar.Size = new System.Drawing.Size(863, 22);
			this.statusBar.TabIndex = 30;
			this.statusBar.Text = "statusStrip1";
			// 
			// statusBarProgress
			// 
			this.statusBarProgress.Name = "statusBarProgress";
			this.statusBarProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// statusBarStatus
			// 
			this.statusBarStatus.Name = "statusBarStatus";
			this.statusBarStatus.Size = new System.Drawing.Size(715, 17);
			this.statusBarStatus.Spring = true;
			this.statusBarStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ViewerRunKeeper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(863, 703);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pnlStreetTeam);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.pnlActivities);
			this.Controls.Add(this.pnlRecords);
			this.Controls.Add(this.pnlProfile);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(863, 730);
			this.Name = "ViewerRunKeeper";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RunKeeper Profile Viewer";
			this.Shown += new System.EventHandler(this.ViewerRunKeeperLoad);
			this.pnlProfile.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbElite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbProfileMedium)).EndInit();
			this.pnlRecords.ResumeLayout(false);
			this.pnlActivities.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabSummary.ResumeLayout(false);
			this.tabSummary.PerformLayout();
			this.tabMap.ResumeLayout(false);
			this.tabMap.PerformLayout();
			this.tabChart.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlStreetTeam.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripStatusLabel statusBarStatus;
		private System.Windows.Forms.ToolStripProgressBar statusBarProgress;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.Button btnMapFullscreen;
		private System.Windows.Forms.CheckBox cbkChartSpeed;
		private System.Windows.Forms.CheckBox cbkChartHeart;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ListView lstSplits;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox pnlStreetTeam;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ListView lstStreetTeam;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RichTextBox richActivityComments;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.TabPage tabMap;
		private ZedGraph.ZedGraphControl zedActivityChart;
		private System.Windows.Forms.TabPage tabChart;
		private System.Windows.Forms.TabPage tabSummary;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblDistance;
		private System.Windows.Forms.Label lblCalories;
		private System.Windows.Forms.Label lblAvgHeartRate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblActivityDateTime;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblAvgSpeed;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label lblActivityType;
		private System.Windows.Forms.Label lblActivityEquipment;
		private System.Windows.Forms.Label lblTotalAscent;
		private System.Windows.Forms.Label lblLastModified;
		private System.Windows.Forms.LinkLabel lnkRunkeper;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView lstActivities;
		private System.Windows.Forms.GroupBox pnlActivities;
		private System.Windows.Forms.Label lblTotalActivities;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lstRecords;
		private System.Windows.Forms.GroupBox pnlRecords;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pbElite;
		private System.Windows.Forms.LinkLabel lblProfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblGender;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblDob;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblAthleteType;
		private System.Windows.Forms.Label lblProfileName;
		private System.Windows.Forms.PictureBox pbProfileMedium;
		private System.Windows.Forms.GroupBox pnlProfile;
	}
}
