﻿/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/02/2013
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.grpSummary = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btnUploadAllProviders = new System.Windows.Forms.Button();
			this.txtAutoPauseThreshold = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtActivityName = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtActivityNotes = new System.Windows.Forms.TextBox();
			this.lblMaxSpeed = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lblMaxCadence = new System.Windows.Forms.Label();
			this.lblMaxHeartRate = new System.Windows.Forms.Label();
			this.lblTotalDescent = new System.Windows.Forms.Label();
			this.lblTotalAscent = new System.Windows.Forms.Label();
			this.lblMovingTime = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.lblAvgSpeed = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblActivityDateTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblCadence = new System.Windows.Forms.Label();
			this.lblAvgHeartRate = new System.Windows.Forms.Label();
			this.lblCalories = new System.Windows.Forms.Label();
			this.lblDistance = new System.Windows.Forms.Label();
			this.lblDuration = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lstTrackpoints = new ListViewNF.ListViewNF();
			this.colTime = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.zedSpeed = new ZedGraph.ZedGraphControl();
			this.zedHeart = new ZedGraph.ZedGraphControl();
			this.zedCadence = new ZedGraph.ZedGraphControl();
			this.zedAltitude = new ZedGraph.ZedGraphControl();
			this.tabControlOverview = new System.Windows.Forms.TabControl();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.zedTemperature = new ZedGraph.ZedGraphControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.tabUploadStatus = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pbUploadStatusRideWithGps = new System.Windows.Forms.PictureBox();
			this.sUploadRideWithGpsId = new System.Windows.Forms.LinkLabel();
			this.sUploadRideWithGpsMsg = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pbUploadStatusGarmin = new System.Windows.Forms.PictureBox();
			this.sUploadGarminId = new System.Windows.Forms.LinkLabel();
			this.sUploadGarminMsg = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pbUploadStatusStrava = new System.Windows.Forms.PictureBox();
			this.sUploadStravaId = new System.Windows.Forms.LinkLabel();
			this.sUploadStravaMsg = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pnlStatusRunkeeper = new System.Windows.Forms.Panel();
			this.pbUploadStatusRunkeeper = new System.Windows.Forms.PictureBox();
			this.sUploadRunkeeperId = new System.Windows.Forms.LinkLabel();
			this.sUploadRunkeeperMsg = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menubar = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProviderRunkeeper = new System.Windows.Forms.ToolStripMenuItem();
			this.menuConnectToRunkeeper = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAccountRunKeeper = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUploadToRunKeeper = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProviderStrava = new System.Windows.Forms.ToolStripMenuItem();
			this.menuConnectToStrava = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAccountStrava = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUploadToStrava = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProviderEndomondo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuConnectToEndomondo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAccountEndomondo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProviderGarmin = new System.Windows.Forms.ToolStripMenuItem();
			this.menuConnectToGarmin = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAccountGarmin = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUploadToGarminConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProviderRideWithGps = new System.Windows.Forms.ToolStripMenuItem();
			this.menuConnectToRideWithGps = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAccountRideWithGps = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUploadToRideWithGps = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusbarStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusBarVersion = new System.Windows.Forms.ToolStripStatusLabel();
			this.grpProviders = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label19 = new System.Windows.Forms.Label();
			this.cbkProviderRideWithGps = new System.Windows.Forms.CheckBox();
			this.cbkProviderGarmin = new System.Windows.Forms.CheckBox();
			this.cbkProviderEndomondo = new System.Windows.Forms.CheckBox();
			this.cbkProviderStrava = new System.Windows.Forms.CheckBox();
			this.cbkProviderRunkeeper = new System.Windows.Forms.CheckBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.grpSummary.SuspendLayout();
			this.tabControlOverview.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabUploadStatus.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusRideWithGps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusGarmin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusStrava)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.pnlStatusRunkeeper.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusRunkeeper)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menubar.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.grpProviders.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			this.SuspendLayout();
			// 
			// grpSummary
			// 
			this.grpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSummary.Controls.Add(this.label14);
			this.grpSummary.Controls.Add(this.btnUploadAllProviders);
			this.grpSummary.Controls.Add(this.txtAutoPauseThreshold);
			this.grpSummary.Controls.Add(this.label13);
			this.grpSummary.Controls.Add(this.txtActivityName);
			this.grpSummary.Controls.Add(this.label11);
			this.grpSummary.Controls.Add(this.label10);
			this.grpSummary.Controls.Add(this.txtActivityNotes);
			this.grpSummary.Controls.Add(this.lblMaxSpeed);
			this.grpSummary.Controls.Add(this.label12);
			this.grpSummary.Controls.Add(this.lblMaxCadence);
			this.grpSummary.Controls.Add(this.lblMaxHeartRate);
			this.grpSummary.Controls.Add(this.lblTotalDescent);
			this.grpSummary.Controls.Add(this.lblTotalAscent);
			this.grpSummary.Controls.Add(this.lblMovingTime);
			this.grpSummary.Controls.Add(this.label20);
			this.grpSummary.Controls.Add(this.label21);
			this.grpSummary.Controls.Add(this.label22);
			this.grpSummary.Controls.Add(this.label23);
			this.grpSummary.Controls.Add(this.label24);
			this.grpSummary.Controls.Add(this.lblAvgSpeed);
			this.grpSummary.Controls.Add(this.label8);
			this.grpSummary.Controls.Add(this.lblActivityDateTime);
			this.grpSummary.Controls.Add(this.label7);
			this.grpSummary.Controls.Add(this.lblCadence);
			this.grpSummary.Controls.Add(this.lblAvgHeartRate);
			this.grpSummary.Controls.Add(this.lblCalories);
			this.grpSummary.Controls.Add(this.lblDistance);
			this.grpSummary.Controls.Add(this.lblDuration);
			this.grpSummary.Controls.Add(this.label5);
			this.grpSummary.Controls.Add(this.label4);
			this.grpSummary.Controls.Add(this.label3);
			this.grpSummary.Controls.Add(this.label2);
			this.grpSummary.Controls.Add(this.label1);
			this.grpSummary.Enabled = false;
			this.grpSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpSummary.ForeColor = System.Drawing.Color.RoyalBlue;
			this.grpSummary.Location = new System.Drawing.Point(5, 51);
			this.grpSummary.Name = "grpSummary";
			this.grpSummary.Size = new System.Drawing.Size(790, 194);
			this.grpSummary.TabIndex = 1;
			this.grpSummary.TabStop = false;
			this.grpSummary.Text = "Summary";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.SteelBlue;
			this.label14.Location = new System.Drawing.Point(463, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(77, 27);
			this.label14.TabIndex = 39;
			this.label14.Text = "* as defined in device";
			// 
			// btnUploadAllProviders
			// 
			this.btnUploadAllProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUploadAllProviders.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUploadAllProviders.Location = new System.Drawing.Point(563, 165);
			this.btnUploadAllProviders.Name = "btnUploadAllProviders";
			this.btnUploadAllProviders.Size = new System.Drawing.Size(216, 23);
			this.btnUploadAllProviders.TabIndex = 2;
			this.btnUploadAllProviders.Text = "Upload to All Active Providers ...";
			this.btnUploadAllProviders.UseVisualStyleBackColor = true;
			this.btnUploadAllProviders.Click += new System.EventHandler(this.BtnUploadAllProvidersClick);
			// 
			// txtAutoPauseThreshold
			// 
			this.txtAutoPauseThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAutoPauseThreshold.Location = new System.Drawing.Point(423, 20);
			this.txtAutoPauseThreshold.Name = "txtAutoPauseThreshold";
			this.txtAutoPauseThreshold.Size = new System.Drawing.Size(38, 20);
			this.txtAutoPauseThreshold.TabIndex = 38;
			this.txtAutoPauseThreshold.Text = "0";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.SteelBlue;
			this.label13.Location = new System.Drawing.Point(280, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(137, 12);
			this.label13.TabIndex = 37;
			this.label13.Text = "Auto-Pause Speed Threshold";
			// 
			// txtActivityName
			// 
			this.txtActivityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivityName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtActivityName.Location = new System.Drawing.Point(563, 38);
			this.txtActivityName.Name = "txtActivityName";
			this.txtActivityName.Size = new System.Drawing.Size(214, 20);
			this.txtActivityName.TabIndex = 0;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.SteelBlue;
			this.label11.Location = new System.Drawing.Point(563, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(216, 11);
			this.label11.TabIndex = 35;
			this.label11.Text = "Activity Name (Strava/GarminConnect Only):";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.SteelBlue;
			this.label10.Location = new System.Drawing.Point(563, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(214, 11);
			this.label10.TabIndex = 32;
			this.label10.Text = "Activity Notes (RunKeeper Only)";
			// 
			// txtActivityNotes
			// 
			this.txtActivityNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivityNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtActivityNotes.Location = new System.Drawing.Point(563, 78);
			this.txtActivityNotes.Multiline = true;
			this.txtActivityNotes.Name = "txtActivityNotes";
			this.txtActivityNotes.Size = new System.Drawing.Size(216, 86);
			this.txtActivityNotes.TabIndex = 1;
			// 
			// lblMaxSpeed
			// 
			this.lblMaxSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMaxSpeed.Location = new System.Drawing.Point(398, 163);
			this.lblMaxSpeed.Name = "lblMaxSpeed";
			this.lblMaxSpeed.Size = new System.Drawing.Size(156, 23);
			this.lblMaxSpeed.TabIndex = 29;
			this.lblMaxSpeed.Text = "-";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.SteelBlue;
			this.label12.Location = new System.Drawing.Point(280, 163);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 19);
			this.label12.TabIndex = 28;
			this.label12.Text = "Max Speed";
			// 
			// lblMaxCadence
			// 
			this.lblMaxCadence.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxCadence.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMaxCadence.Location = new System.Drawing.Point(398, 139);
			this.lblMaxCadence.Name = "lblMaxCadence";
			this.lblMaxCadence.Size = new System.Drawing.Size(156, 23);
			this.lblMaxCadence.TabIndex = 25;
			this.lblMaxCadence.Text = "-";
			// 
			// lblMaxHeartRate
			// 
			this.lblMaxHeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxHeartRate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMaxHeartRate.Location = new System.Drawing.Point(398, 116);
			this.lblMaxHeartRate.Name = "lblMaxHeartRate";
			this.lblMaxHeartRate.Size = new System.Drawing.Size(156, 23);
			this.lblMaxHeartRate.TabIndex = 24;
			this.lblMaxHeartRate.Text = "-";
			// 
			// lblTotalDescent
			// 
			this.lblTotalDescent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDescent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalDescent.Location = new System.Drawing.Point(398, 93);
			this.lblTotalDescent.Name = "lblTotalDescent";
			this.lblTotalDescent.Size = new System.Drawing.Size(156, 23);
			this.lblTotalDescent.TabIndex = 23;
			this.lblTotalDescent.Text = "-";
			// 
			// lblTotalAscent
			// 
			this.lblTotalAscent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAscent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalAscent.Location = new System.Drawing.Point(398, 70);
			this.lblTotalAscent.Name = "lblTotalAscent";
			this.lblTotalAscent.Size = new System.Drawing.Size(156, 23);
			this.lblTotalAscent.TabIndex = 22;
			this.lblTotalAscent.Text = "-";
			// 
			// lblMovingTime
			// 
			this.lblMovingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMovingTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMovingTime.Location = new System.Drawing.Point(398, 47);
			this.lblMovingTime.Name = "lblMovingTime";
			this.lblMovingTime.Size = new System.Drawing.Size(156, 23);
			this.lblMovingTime.TabIndex = 21;
			this.lblMovingTime.Text = "-";
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.ForeColor = System.Drawing.Color.SteelBlue;
			this.label20.Location = new System.Drawing.Point(280, 139);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(93, 19);
			this.label20.TabIndex = 20;
			this.label20.Text = "Max Cadence";
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.SteelBlue;
			this.label21.Location = new System.Drawing.Point(280, 116);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(118, 23);
			this.label21.TabIndex = 19;
			this.label21.Text = "Max Heart Rate";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.SteelBlue;
			this.label22.Location = new System.Drawing.Point(280, 93);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 18;
			this.label22.Text = "Total Descent";
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.Color.SteelBlue;
			this.label23.Location = new System.Drawing.Point(280, 70);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 17;
			this.label23.Text = "Total Ascent";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.Color.SteelBlue;
			this.label24.Location = new System.Drawing.Point(280, 47);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 16;
			this.label24.Text = "Moving Time";
			// 
			// lblAvgSpeed
			// 
			this.lblAvgSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAvgSpeed.Location = new System.Drawing.Point(137, 163);
			this.lblAvgSpeed.Name = "lblAvgSpeed";
			this.lblAvgSpeed.Size = new System.Drawing.Size(137, 19);
			this.lblAvgSpeed.TabIndex = 13;
			this.lblAvgSpeed.Text = "-";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.SteelBlue;
			this.label8.Location = new System.Drawing.Point(19, 163);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "Average Speed";
			// 
			// lblActivityDateTime
			// 
			this.lblActivityDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblActivityDateTime.Location = new System.Drawing.Point(137, 24);
			this.lblActivityDateTime.Name = "lblActivityDateTime";
			this.lblActivityDateTime.Size = new System.Drawing.Size(137, 23);
			this.lblActivityDateTime.TabIndex = 11;
			this.lblActivityDateTime.Text = "-";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.SteelBlue;
			this.label7.Location = new System.Drawing.Point(19, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "Activity";
			// 
			// lblCadence
			// 
			this.lblCadence.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCadence.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCadence.Location = new System.Drawing.Point(137, 139);
			this.lblCadence.Name = "lblCadence";
			this.lblCadence.Size = new System.Drawing.Size(137, 19);
			this.lblCadence.TabIndex = 9;
			this.lblCadence.Text = "-";
			// 
			// lblAvgHeartRate
			// 
			this.lblAvgHeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgHeartRate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAvgHeartRate.Location = new System.Drawing.Point(137, 116);
			this.lblAvgHeartRate.Name = "lblAvgHeartRate";
			this.lblAvgHeartRate.Size = new System.Drawing.Size(137, 23);
			this.lblAvgHeartRate.TabIndex = 8;
			this.lblAvgHeartRate.Text = "-";
			// 
			// lblCalories
			// 
			this.lblCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCalories.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCalories.Location = new System.Drawing.Point(137, 93);
			this.lblCalories.Name = "lblCalories";
			this.lblCalories.Size = new System.Drawing.Size(137, 23);
			this.lblCalories.TabIndex = 7;
			this.lblCalories.Text = "-";
			// 
			// lblDistance
			// 
			this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDistance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDistance.Location = new System.Drawing.Point(137, 70);
			this.lblDistance.Name = "lblDistance";
			this.lblDistance.Size = new System.Drawing.Size(137, 23);
			this.lblDistance.TabIndex = 6;
			this.lblDistance.Text = "-";
			// 
			// lblDuration
			// 
			this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDuration.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDuration.Location = new System.Drawing.Point(137, 47);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(137, 23);
			this.lblDuration.TabIndex = 5;
			this.lblDuration.Text = "-";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.SteelBlue;
			this.label5.Location = new System.Drawing.Point(19, 139);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 19);
			this.label5.TabIndex = 4;
			this.label5.Text = "Average Cadence";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(19, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Average Heart Rate";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SteelBlue;
			this.label3.Location = new System.Drawing.Point(19, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Calories";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SteelBlue;
			this.label2.Location = new System.Drawing.Point(19, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Distance";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(19, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Duration";
			// 
			// lstTrackpoints
			// 
			this.lstTrackpoints.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstTrackpoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTrackpoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colTime,
									this.columnHeader8,
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader9,
									this.columnHeader10});
			this.lstTrackpoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstTrackpoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstTrackpoints.GridLines = true;
			this.lstTrackpoints.Location = new System.Drawing.Point(3, 3);
			this.lstTrackpoints.Name = "lstTrackpoints";
			this.lstTrackpoints.ShowGroups = false;
			this.lstTrackpoints.Size = new System.Drawing.Size(1001, 296);
			this.lstTrackpoints.TabIndex = 2;
			this.lstTrackpoints.UseCompatibleStateImageBehavior = false;
			this.lstTrackpoints.View = System.Windows.Forms.View.Details;
			// 
			// colTime
			// 
			this.colTime.Text = "Time";
			this.colTime.Width = 110;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Duration";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Altitude";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Distance";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Heart";
			this.columnHeader3.Width = 40;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Tag = "Cadence";
			this.columnHeader4.Text = "Cadence";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Speed";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Lng.";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Lat.";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Temp.";
			this.columnHeader9.Width = 40;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "IsAutoPaused";
			this.columnHeader10.Width = 79;
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(3, 3);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new System.Drawing.Size(967, 296);
			this.webBrowser1.TabIndex = 0;
			// 
			// zedSpeed
			// 
			this.zedSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedSpeed.Font = new System.Drawing.Font("Verdana", 11F);
			this.zedSpeed.IsAntiAlias = true;
			this.zedSpeed.IsShowPointValues = true;
			this.zedSpeed.Location = new System.Drawing.Point(0, 0);
			this.zedSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.zedSpeed.Name = "zedSpeed";
			this.zedSpeed.ScrollGrace = 0D;
			this.zedSpeed.ScrollMaxX = 0D;
			this.zedSpeed.ScrollMaxY = 0D;
			this.zedSpeed.ScrollMaxY2 = 0D;
			this.zedSpeed.ScrollMinX = 0D;
			this.zedSpeed.ScrollMinY = 0D;
			this.zedSpeed.ScrollMinY2 = 0D;
			this.zedSpeed.Size = new System.Drawing.Size(1007, 302);
			this.zedSpeed.TabIndex = 18;
			// 
			// zedHeart
			// 
			this.zedHeart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedHeart.Font = new System.Drawing.Font("Verdana", 11F);
			this.zedHeart.IsAntiAlias = true;
			this.zedHeart.IsShowPointValues = true;
			this.zedHeart.Location = new System.Drawing.Point(0, 0);
			this.zedHeart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.zedHeart.Name = "zedHeart";
			this.zedHeart.ScrollGrace = 0D;
			this.zedHeart.ScrollMaxX = 0D;
			this.zedHeart.ScrollMaxY = 0D;
			this.zedHeart.ScrollMaxY2 = 0D;
			this.zedHeart.ScrollMinX = 0D;
			this.zedHeart.ScrollMinY = 0D;
			this.zedHeart.ScrollMinY2 = 0D;
			this.zedHeart.Size = new System.Drawing.Size(1007, 302);
			this.zedHeart.TabIndex = 19;
			// 
			// zedCadence
			// 
			this.zedCadence.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedCadence.Font = new System.Drawing.Font("Verdana", 11F);
			this.zedCadence.IsAntiAlias = true;
			this.zedCadence.IsShowPointValues = true;
			this.zedCadence.Location = new System.Drawing.Point(0, 0);
			this.zedCadence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.zedCadence.Name = "zedCadence";
			this.zedCadence.ScrollGrace = 0D;
			this.zedCadence.ScrollMaxX = 0D;
			this.zedCadence.ScrollMaxY = 0D;
			this.zedCadence.ScrollMaxY2 = 0D;
			this.zedCadence.ScrollMinX = 0D;
			this.zedCadence.ScrollMinY = 0D;
			this.zedCadence.ScrollMinY2 = 0D;
			this.zedCadence.Size = new System.Drawing.Size(1007, 302);
			this.zedCadence.TabIndex = 20;
			// 
			// zedAltitude
			// 
			this.zedAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedAltitude.Font = new System.Drawing.Font("Verdana", 11F);
			this.zedAltitude.IsAntiAlias = true;
			this.zedAltitude.IsShowPointValues = true;
			this.zedAltitude.Location = new System.Drawing.Point(0, 0);
			this.zedAltitude.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.zedAltitude.Name = "zedAltitude";
			this.zedAltitude.ScrollGrace = 0D;
			this.zedAltitude.ScrollMaxX = 0D;
			this.zedAltitude.ScrollMaxY = 0D;
			this.zedAltitude.ScrollMaxY2 = 0D;
			this.zedAltitude.ScrollMinX = 0D;
			this.zedAltitude.ScrollMinY = 0D;
			this.zedAltitude.ScrollMinY2 = 0D;
			this.zedAltitude.Size = new System.Drawing.Size(1007, 302);
			this.zedAltitude.TabIndex = 21;
			// 
			// tabControlOverview
			// 
			this.tabControlOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlOverview.Controls.Add(this.tabMap);
			this.tabControlOverview.Controls.Add(this.tabPage3);
			this.tabControlOverview.Controls.Add(this.tabPage4);
			this.tabControlOverview.Controls.Add(this.tabPage5);
			this.tabControlOverview.Controls.Add(this.tabPage6);
			this.tabControlOverview.Controls.Add(this.tabPage2);
			this.tabControlOverview.Controls.Add(this.tabPage7);
			this.tabControlOverview.Controls.Add(this.tabPage1);
			this.tabControlOverview.Controls.Add(this.tabUploadStatus);
			this.tabControlOverview.Enabled = false;
			this.tabControlOverview.HotTrack = true;
			this.tabControlOverview.Location = new System.Drawing.Point(5, 262);
			this.tabControlOverview.Name = "tabControlOverview";
			this.tabControlOverview.SelectedIndex = 0;
			this.tabControlOverview.Size = new System.Drawing.Size(1015, 328);
			this.tabControlOverview.TabIndex = 24;
			this.tabControlOverview.SelectedIndexChanged += new System.EventHandler(this.TabControlOverviewSelectedIndexChanged);
			// 
			// tabMap
			// 
			this.tabMap.Controls.Add(this.webBrowser1);
			this.tabMap.Controls.Add(this.btnMapFullscreen);
			this.tabMap.Location = new System.Drawing.Point(4, 22);
			this.tabMap.Name = "tabMap";
			this.tabMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabMap.Size = new System.Drawing.Size(1007, 302);
			this.tabMap.TabIndex = 5;
			this.tabMap.Text = "Map";
			this.tabMap.UseVisualStyleBackColor = true;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.AutoSize = true;
			this.btnMapFullscreen.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(970, 3);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(34, 296);
			this.btnMapFullscreen.TabIndex = 1;
			this.btnMapFullscreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnMapFullscreen.UseVisualStyleBackColor = true;
			this.btnMapFullscreen.Click += new System.EventHandler(this.BtnMapFullscreenClick);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.zedAltitude);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1007, 302);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Altitude";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.zedSpeed);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(1007, 302);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Speed";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.zedCadence);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1007, 302);
			this.tabPage5.TabIndex = 2;
			this.tabPage5.Text = "Cadence";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.zedHeart);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(1007, 302);
			this.tabPage6.TabIndex = 3;
			this.tabPage6.Text = "Heart Rate";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.zedTemperature);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1007, 302);
			this.tabPage2.TabIndex = 7;
			this.tabPage2.Text = "Temperature";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// zedTemperature
			// 
			this.zedTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedTemperature.Font = new System.Drawing.Font("Verdana", 11F);
			this.zedTemperature.IsAntiAlias = true;
			this.zedTemperature.IsShowPointValues = true;
			this.zedTemperature.Location = new System.Drawing.Point(3, 3);
			this.zedTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.zedTemperature.Name = "zedTemperature";
			this.zedTemperature.ScrollGrace = 0D;
			this.zedTemperature.ScrollMaxX = 0D;
			this.zedTemperature.ScrollMaxY = 0D;
			this.zedTemperature.ScrollMaxY2 = 0D;
			this.zedTemperature.ScrollMinX = 0D;
			this.zedTemperature.ScrollMinY = 0D;
			this.zedTemperature.ScrollMinY2 = 0D;
			this.zedTemperature.Size = new System.Drawing.Size(1001, 296);
			this.zedTemperature.TabIndex = 20;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.lstTrackpoints);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(1007, 302);
			this.tabPage7.TabIndex = 4;
			this.tabPage7.Text = "Track Points";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtDebug);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1007, 302);
			this.tabPage1.TabIndex = 6;
			this.tabPage1.Text = "Debug";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtDebug
			// 
			this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDebug.Location = new System.Drawing.Point(3, 3);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.Size = new System.Drawing.Size(1001, 296);
			this.txtDebug.TabIndex = 0;
			// 
			// tabUploadStatus
			// 
			this.tabUploadStatus.BackColor = System.Drawing.Color.White;
			this.tabUploadStatus.Controls.Add(this.panel4);
			this.tabUploadStatus.Controls.Add(this.panel2);
			this.tabUploadStatus.Controls.Add(this.panel3);
			this.tabUploadStatus.Controls.Add(this.pnlStatusRunkeeper);
			this.tabUploadStatus.Location = new System.Drawing.Point(4, 22);
			this.tabUploadStatus.Name = "tabUploadStatus";
			this.tabUploadStatus.Padding = new System.Windows.Forms.Padding(3);
			this.tabUploadStatus.Size = new System.Drawing.Size(1007, 302);
			this.tabUploadStatus.TabIndex = 8;
			this.tabUploadStatus.Text = "Upload Status";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel4.Controls.Add(this.pbUploadStatusRideWithGps);
			this.panel4.Controls.Add(this.sUploadRideWithGpsId);
			this.panel4.Controls.Add(this.sUploadRideWithGpsMsg);
			this.panel4.Controls.Add(this.label18);
			this.panel4.Controls.Add(this.pictureBox4);
			this.panel4.Location = new System.Drawing.Point(575, 18);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(186, 278);
			this.panel4.TabIndex = 8;
			// 
			// pbUploadStatusRideWithGps
			// 
			this.pbUploadStatusRideWithGps.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusRideWithGps.Location = new System.Drawing.Point(151, 243);
			this.pbUploadStatusRideWithGps.Name = "pbUploadStatusRideWithGps";
			this.pbUploadStatusRideWithGps.Size = new System.Drawing.Size(32, 32);
			this.pbUploadStatusRideWithGps.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUploadStatusRideWithGps.TabIndex = 15;
			this.pbUploadStatusRideWithGps.TabStop = false;
			// 
			// sUploadRideWithGpsId
			// 
			this.sUploadRideWithGpsId.Location = new System.Drawing.Point(67, 40);
			this.sUploadRideWithGpsId.Name = "sUploadRideWithGpsId";
			this.sUploadRideWithGpsId.Size = new System.Drawing.Size(116, 23);
			this.sUploadRideWithGpsId.TabIndex = 14;
			this.sUploadRideWithGpsId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRideIdClicked);
			// 
			// sUploadRideWithGpsMsg
			// 
			this.sUploadRideWithGpsMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadRideWithGpsMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadRideWithGpsMsg.Location = new System.Drawing.Point(4, 64);
			this.sUploadRideWithGpsMsg.Name = "sUploadRideWithGpsMsg";
			this.sUploadRideWithGpsMsg.Size = new System.Drawing.Size(178, 212);
			this.sUploadRideWithGpsMsg.TabIndex = 12;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(3, 41);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(57, 23);
			this.label18.TabIndex = 10;
			this.label18.Text = "Ride ID:";
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Gainsboro;
			this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(0, 0);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox4.Size = new System.Drawing.Size(186, 38);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox4.TabIndex = 1;
			this.pictureBox4.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel2.Controls.Add(this.pbUploadStatusGarmin);
			this.panel2.Controls.Add(this.sUploadGarminId);
			this.panel2.Controls.Add(this.sUploadGarminMsg);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.pictureBox3);
			this.panel2.Location = new System.Drawing.Point(388, 18);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(186, 278);
			this.panel2.TabIndex = 7;
			// 
			// pbUploadStatusGarmin
			// 
			this.pbUploadStatusGarmin.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusGarmin.Location = new System.Drawing.Point(151, 243);
			this.pbUploadStatusGarmin.Name = "pbUploadStatusGarmin";
			this.pbUploadStatusGarmin.Size = new System.Drawing.Size(32, 32);
			this.pbUploadStatusGarmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUploadStatusGarmin.TabIndex = 15;
			this.pbUploadStatusGarmin.TabStop = false;
			// 
			// sUploadGarminId
			// 
			this.sUploadGarminId.Location = new System.Drawing.Point(66, 40);
			this.sUploadGarminId.Name = "sUploadGarminId";
			this.sUploadGarminId.Size = new System.Drawing.Size(116, 23);
			this.sUploadGarminId.TabIndex = 14;
			this.sUploadGarminId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRideIdClicked);
			// 
			// sUploadGarminMsg
			// 
			this.sUploadGarminMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadGarminMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadGarminMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadGarminMsg.Name = "sUploadGarminMsg";
			this.sUploadGarminMsg.Size = new System.Drawing.Size(178, 212);
			this.sUploadGarminMsg.TabIndex = 12;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(3, 41);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(57, 23);
			this.label17.TabIndex = 10;
			this.label17.Text = "Ride ID:";
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
			this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(0, 0);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox3.Size = new System.Drawing.Size(186, 38);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 1;
			this.pictureBox3.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel3.Controls.Add(this.pbUploadStatusStrava);
			this.panel3.Controls.Add(this.sUploadStravaId);
			this.panel3.Controls.Add(this.sUploadStravaMsg);
			this.panel3.Controls.Add(this.label16);
			this.panel3.Controls.Add(this.pictureBox2);
			this.panel3.Location = new System.Drawing.Point(201, 18);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(186, 278);
			this.panel3.TabIndex = 6;
			// 
			// pbUploadStatusStrava
			// 
			this.pbUploadStatusStrava.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusStrava.Location = new System.Drawing.Point(151, 243);
			this.pbUploadStatusStrava.Name = "pbUploadStatusStrava";
			this.pbUploadStatusStrava.Size = new System.Drawing.Size(32, 32);
			this.pbUploadStatusStrava.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUploadStatusStrava.TabIndex = 14;
			this.pbUploadStatusStrava.TabStop = false;
			// 
			// sUploadStravaId
			// 
			this.sUploadStravaId.Location = new System.Drawing.Point(69, 40);
			this.sUploadStravaId.Name = "sUploadStravaId";
			this.sUploadStravaId.Size = new System.Drawing.Size(116, 23);
			this.sUploadStravaId.TabIndex = 13;
			this.sUploadStravaId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRideIdClicked);
			// 
			// sUploadStravaMsg
			// 
			this.sUploadStravaMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadStravaMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadStravaMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadStravaMsg.Name = "sUploadStravaMsg";
			this.sUploadStravaMsg.Size = new System.Drawing.Size(178, 212);
			this.sUploadStravaMsg.TabIndex = 12;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(5, 41);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(57, 23);
			this.label16.TabIndex = 10;
			this.label16.Text = "Ride ID:";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox2.Size = new System.Drawing.Size(186, 38);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pnlStatusRunkeeper
			// 
			this.pnlStatusRunkeeper.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pnlStatusRunkeeper.Controls.Add(this.pbUploadStatusRunkeeper);
			this.pnlStatusRunkeeper.Controls.Add(this.sUploadRunkeeperId);
			this.pnlStatusRunkeeper.Controls.Add(this.sUploadRunkeeperMsg);
			this.pnlStatusRunkeeper.Controls.Add(this.label15);
			this.pnlStatusRunkeeper.Controls.Add(this.pictureBox1);
			this.pnlStatusRunkeeper.Location = new System.Drawing.Point(14, 18);
			this.pnlStatusRunkeeper.Name = "pnlStatusRunkeeper";
			this.pnlStatusRunkeeper.Size = new System.Drawing.Size(186, 278);
			this.pnlStatusRunkeeper.TabIndex = 4;
			// 
			// pbUploadStatusRunkeeper
			// 
			this.pbUploadStatusRunkeeper.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusRunkeeper.Location = new System.Drawing.Point(151, 243);
			this.pbUploadStatusRunkeeper.Name = "pbUploadStatusRunkeeper";
			this.pbUploadStatusRunkeeper.Size = new System.Drawing.Size(32, 32);
			this.pbUploadStatusRunkeeper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUploadStatusRunkeeper.TabIndex = 13;
			this.pbUploadStatusRunkeeper.TabStop = false;
			// 
			// sUploadRunkeeperId
			// 
			this.sUploadRunkeeperId.Location = new System.Drawing.Point(66, 40);
			this.sUploadRunkeeperId.Name = "sUploadRunkeeperId";
			this.sUploadRunkeeperId.Size = new System.Drawing.Size(116, 23);
			this.sUploadRunkeeperId.TabIndex = 12;
			this.sUploadRunkeeperId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRideIdClicked);
			// 
			// sUploadRunkeeperMsg
			// 
			this.sUploadRunkeeperMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadRunkeeperMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadRunkeeperMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadRunkeeperMsg.Name = "sUploadRunkeeperMsg";
			this.sUploadRunkeeperMsg.Size = new System.Drawing.Size(178, 212);
			this.sUploadRunkeeperMsg.TabIndex = 11;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(5, 41);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(57, 23);
			this.label15.TabIndex = 9;
			this.label15.Text = "Ride ID:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox1.Size = new System.Drawing.Size(186, 38);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// menubar
			// 
			this.menubar.BackColor = System.Drawing.SystemColors.Control;
			this.menubar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menubar.BackgroundImage")));
			this.menubar.Enabled = false;
			this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1,
									this.menuProviderRunkeeper,
									this.menuProviderStrava,
									this.menuProviderEndomondo,
									this.menuProviderGarmin,
									this.menuProviderRideWithGps,
									this.aboutToolStripMenuItem});
			this.menubar.Location = new System.Drawing.Point(0, 0);
			this.menubar.Name = "menubar";
			this.menubar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.menubar.Size = new System.Drawing.Size(1032, 40);
			this.menubar.TabIndex = 25;
			this.menubar.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 36);
			this.toolStripMenuItem1.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenFileClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// menuProviderRunkeeper
			// 
			this.menuProviderRunkeeper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuConnectToRunkeeper,
									this.menuViewAccountRunKeeper,
									this.menuUploadToRunKeeper});
			this.menuProviderRunkeeper.Enabled = false;
			this.menuProviderRunkeeper.Image = ((System.Drawing.Image)(resources.GetObject("menuProviderRunkeeper.Image")));
			this.menuProviderRunkeeper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.menuProviderRunkeeper.Name = "menuProviderRunkeeper";
			this.menuProviderRunkeeper.Size = new System.Drawing.Size(44, 36);
			// 
			// menuConnectToRunkeeper
			// 
			this.menuConnectToRunkeeper.Image = ((System.Drawing.Image)(resources.GetObject("menuConnectToRunkeeper.Image")));
			this.menuConnectToRunkeeper.Name = "menuConnectToRunkeeper";
			this.menuConnectToRunkeeper.Size = new System.Drawing.Size(201, 22);
			this.menuConnectToRunkeeper.Text = "Connect to Runkeeper...";
			this.menuConnectToRunkeeper.Click += new System.EventHandler(this.MenuConnectToRunkeeperClick);
			// 
			// menuViewAccountRunKeeper
			// 
			this.menuViewAccountRunKeeper.Enabled = false;
			this.menuViewAccountRunKeeper.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAccountRunKeeper.Image")));
			this.menuViewAccountRunKeeper.Name = "menuViewAccountRunKeeper";
			this.menuViewAccountRunKeeper.Size = new System.Drawing.Size(201, 22);
			this.menuViewAccountRunKeeper.Text = "View Account...";
			this.menuViewAccountRunKeeper.Click += new System.EventHandler(this.menuViewAccountRunKeeperClick);
			// 
			// menuUploadToRunKeeper
			// 
			this.menuUploadToRunKeeper.Enabled = false;
			this.menuUploadToRunKeeper.Image = ((System.Drawing.Image)(resources.GetObject("menuUploadToRunKeeper.Image")));
			this.menuUploadToRunKeeper.Name = "menuUploadToRunKeeper";
			this.menuUploadToRunKeeper.Size = new System.Drawing.Size(201, 22);
			this.menuUploadToRunKeeper.Text = "Upload Ride...";
			this.menuUploadToRunKeeper.Click += new System.EventHandler(this.menuUploadToRunKeeperClick);
			// 
			// menuProviderStrava
			// 
			this.menuProviderStrava.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuConnectToStrava,
									this.menuViewAccountStrava,
									this.menuUploadToStrava});
			this.menuProviderStrava.Enabled = false;
			this.menuProviderStrava.Image = ((System.Drawing.Image)(resources.GetObject("menuProviderStrava.Image")));
			this.menuProviderStrava.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.menuProviderStrava.Name = "menuProviderStrava";
			this.menuProviderStrava.Size = new System.Drawing.Size(44, 36);
			// 
			// menuConnectToStrava
			// 
			this.menuConnectToStrava.Image = ((System.Drawing.Image)(resources.GetObject("menuConnectToStrava.Image")));
			this.menuConnectToStrava.Name = "menuConnectToStrava";
			this.menuConnectToStrava.Size = new System.Drawing.Size(177, 22);
			this.menuConnectToStrava.Text = "Connect to Strava...";
			this.menuConnectToStrava.Click += new System.EventHandler(this.MenuConnectToStravaClick);
			// 
			// menuViewAccountStrava
			// 
			this.menuViewAccountStrava.Enabled = false;
			this.menuViewAccountStrava.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAccountStrava.Image")));
			this.menuViewAccountStrava.Name = "menuViewAccountStrava";
			this.menuViewAccountStrava.Size = new System.Drawing.Size(177, 22);
			this.menuViewAccountStrava.Text = "View Account...";
			this.menuViewAccountStrava.Visible = false;
			this.menuViewAccountStrava.Click += new System.EventHandler(this.menuViewAccountStravaClick);
			// 
			// menuUploadToStrava
			// 
			this.menuUploadToStrava.Enabled = false;
			this.menuUploadToStrava.Image = ((System.Drawing.Image)(resources.GetObject("menuUploadToStrava.Image")));
			this.menuUploadToStrava.Name = "menuUploadToStrava";
			this.menuUploadToStrava.Size = new System.Drawing.Size(177, 22);
			this.menuUploadToStrava.Text = "Upload Ride...";
			this.menuUploadToStrava.Click += new System.EventHandler(this.menuUploadToStravaClick);
			// 
			// menuProviderEndomondo
			// 
			this.menuProviderEndomondo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuConnectToEndomondo,
									this.menuViewAccountEndomondo});
			this.menuProviderEndomondo.Enabled = false;
			this.menuProviderEndomondo.Image = ((System.Drawing.Image)(resources.GetObject("menuProviderEndomondo.Image")));
			this.menuProviderEndomondo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.menuProviderEndomondo.Name = "menuProviderEndomondo";
			this.menuProviderEndomondo.Size = new System.Drawing.Size(44, 36);
			// 
			// menuConnectToEndomondo
			// 
			this.menuConnectToEndomondo.Image = ((System.Drawing.Image)(resources.GetObject("menuConnectToEndomondo.Image")));
			this.menuConnectToEndomondo.Name = "menuConnectToEndomondo";
			this.menuConnectToEndomondo.Size = new System.Drawing.Size(211, 22);
			this.menuConnectToEndomondo.Text = "Connect to Endomondo...";
			this.menuConnectToEndomondo.Click += new System.EventHandler(this.MenuConnectToEndomondoClick);
			// 
			// menuViewAccountEndomondo
			// 
			this.menuViewAccountEndomondo.Enabled = false;
			this.menuViewAccountEndomondo.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAccountEndomondo.Image")));
			this.menuViewAccountEndomondo.Name = "menuViewAccountEndomondo";
			this.menuViewAccountEndomondo.Size = new System.Drawing.Size(211, 22);
			this.menuViewAccountEndomondo.Text = "View Account...";
			this.menuViewAccountEndomondo.Click += new System.EventHandler(this.MenuViewAccountEndomondoClick);
			// 
			// menuProviderGarmin
			// 
			this.menuProviderGarmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuConnectToGarmin,
									this.menuViewAccountGarmin,
									this.menuUploadToGarminConnect});
			this.menuProviderGarmin.Enabled = false;
			this.menuProviderGarmin.Image = ((System.Drawing.Image)(resources.GetObject("menuProviderGarmin.Image")));
			this.menuProviderGarmin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.menuProviderGarmin.Name = "menuProviderGarmin";
			this.menuProviderGarmin.Size = new System.Drawing.Size(44, 36);
			// 
			// menuConnectToGarmin
			// 
			this.menuConnectToGarmin.Image = ((System.Drawing.Image)(resources.GetObject("menuConnectToGarmin.Image")));
			this.menuConnectToGarmin.Name = "menuConnectToGarmin";
			this.menuConnectToGarmin.Size = new System.Drawing.Size(229, 22);
			this.menuConnectToGarmin.Text = "Connect to GarminConnect...";
			this.menuConnectToGarmin.Click += new System.EventHandler(this.MenuConnectToGarminClick);
			// 
			// menuViewAccountGarmin
			// 
			this.menuViewAccountGarmin.Enabled = false;
			this.menuViewAccountGarmin.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAccountGarmin.Image")));
			this.menuViewAccountGarmin.Name = "menuViewAccountGarmin";
			this.menuViewAccountGarmin.Size = new System.Drawing.Size(229, 22);
			this.menuViewAccountGarmin.Text = "View Account...";
			this.menuViewAccountGarmin.Click += new System.EventHandler(this.menuViewAccountGarminClick);
			// 
			// menuUploadToGarminConnect
			// 
			this.menuUploadToGarminConnect.Enabled = false;
			this.menuUploadToGarminConnect.Image = ((System.Drawing.Image)(resources.GetObject("menuUploadToGarminConnect.Image")));
			this.menuUploadToGarminConnect.Name = "menuUploadToGarminConnect";
			this.menuUploadToGarminConnect.Size = new System.Drawing.Size(229, 22);
			this.menuUploadToGarminConnect.Text = "Upload Ride...";
			this.menuUploadToGarminConnect.Click += new System.EventHandler(this.menuUploadToGarminConnectClick);
			// 
			// menuProviderRideWithGps
			// 
			this.menuProviderRideWithGps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuConnectToRideWithGps,
									this.menuViewAccountRideWithGps,
									this.menuUploadToRideWithGps});
			this.menuProviderRideWithGps.Enabled = false;
			this.menuProviderRideWithGps.Image = ((System.Drawing.Image)(resources.GetObject("menuProviderRideWithGps.Image")));
			this.menuProviderRideWithGps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.menuProviderRideWithGps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.menuProviderRideWithGps.Name = "menuProviderRideWithGps";
			this.menuProviderRideWithGps.Size = new System.Drawing.Size(151, 36);
			// 
			// menuConnectToRideWithGps
			// 
			this.menuConnectToRideWithGps.Enabled = false;
			this.menuConnectToRideWithGps.Image = ((System.Drawing.Image)(resources.GetObject("menuConnectToRideWithGps.Image")));
			this.menuConnectToRideWithGps.Name = "menuConnectToRideWithGps";
			this.menuConnectToRideWithGps.Size = new System.Drawing.Size(213, 22);
			this.menuConnectToRideWithGps.Text = "Connect to RideWithGps...";
			this.menuConnectToRideWithGps.Click += new System.EventHandler(this.MenuConnectToRideWithGpsClick);
			// 
			// menuViewAccountRideWithGps
			// 
			this.menuViewAccountRideWithGps.Enabled = false;
			this.menuViewAccountRideWithGps.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAccountRideWithGps.Image")));
			this.menuViewAccountRideWithGps.Name = "menuViewAccountRideWithGps";
			this.menuViewAccountRideWithGps.Size = new System.Drawing.Size(213, 22);
			this.menuViewAccountRideWithGps.Text = "View Account...";
			this.menuViewAccountRideWithGps.Click += new System.EventHandler(this.MenuViewAccountRideWithGpsClick);
			// 
			// menuUploadToRideWithGps
			// 
			this.menuUploadToRideWithGps.Enabled = false;
			this.menuUploadToRideWithGps.Image = ((System.Drawing.Image)(resources.GetObject("menuUploadToRideWithGps.Image")));
			this.menuUploadToRideWithGps.Name = "menuUploadToRideWithGps";
			this.menuUploadToRideWithGps.Size = new System.Drawing.Size(213, 22);
			this.menuUploadToRideWithGps.Text = "Upload Ride...";
			this.menuUploadToRideWithGps.Click += new System.EventHandler(this.MenuUploadToRideWithGpsClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuAbout});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
			this.aboutToolStripMenuItem.Text = "Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuAbout.Image")));
			this.menuAbout.Name = "menuAbout";
			this.menuAbout.Size = new System.Drawing.Size(152, 22);
			this.menuAbout.Text = "About";
			this.menuAbout.Click += new System.EventHandler(this.MenuAboutClick);
			// 
			// statusBar
			// 
			this.statusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusBar.BackgroundImage")));
			this.statusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.statusBarProgress,
									this.statusbarStatus,
									this.statusBarVersion});
			this.statusBar.Location = new System.Drawing.Point(0, 593);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(1032, 22);
			this.statusBar.TabIndex = 26;
			// 
			// statusBarProgress
			// 
			this.statusBarProgress.Name = "statusBarProgress";
			this.statusBarProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// statusbarStatus
			// 
			this.statusbarStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.statusbarStatus.Name = "statusbarStatus";
			this.statusbarStatus.Size = new System.Drawing.Size(915, 17);
			this.statusbarStatus.Spring = true;
			this.statusbarStatus.Text = "Loading...";
			this.statusbarStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusBarVersion
			// 
			this.statusBarVersion.Name = "statusBarVersion";
			this.statusBarVersion.Size = new System.Drawing.Size(0, 17);
			this.statusBarVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpProviders
			// 
			this.grpProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpProviders.Controls.Add(this.panel1);
			this.grpProviders.Enabled = false;
			this.grpProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpProviders.ForeColor = System.Drawing.Color.RoyalBlue;
			this.grpProviders.Location = new System.Drawing.Point(801, 51);
			this.grpProviders.Name = "grpProviders";
			this.grpProviders.Size = new System.Drawing.Size(219, 194);
			this.grpProviders.TabIndex = 28;
			this.grpProviders.TabStop = false;
			this.grpProviders.Text = "Available Providers";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.label19);
			this.panel1.Controls.Add(this.cbkProviderRideWithGps);
			this.panel1.Controls.Add(this.cbkProviderGarmin);
			this.panel1.Controls.Add(this.cbkProviderEndomondo);
			this.panel1.Controls.Add(this.cbkProviderStrava);
			this.panel1.Controls.Add(this.cbkProviderRunkeeper);
			this.panel1.Controls.Add(this.pictureBox9);
			this.panel1.Controls.Add(this.pictureBox8);
			this.panel1.Controls.Add(this.pictureBox7);
			this.panel1.Controls.Add(this.pictureBox6);
			this.panel1.Controls.Add(this.pictureBox5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(213, 175);
			this.panel1.TabIndex = 0;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.Color.SteelBlue;
			this.label19.Location = new System.Drawing.Point(78, 82);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 18);
			this.label19.TabIndex = 17;
			this.label19.Text = "No Upload Support";
			// 
			// cbkProviderRideWithGps
			// 
			this.cbkProviderRideWithGps.AutoSize = true;
			this.cbkProviderRideWithGps.Location = new System.Drawing.Point(18, 149);
			this.cbkProviderRideWithGps.Name = "cbkProviderRideWithGps";
			this.cbkProviderRideWithGps.Size = new System.Drawing.Size(15, 14);
			this.cbkProviderRideWithGps.TabIndex = 4;
			this.cbkProviderRideWithGps.UseVisualStyleBackColor = true;
			this.cbkProviderRideWithGps.CheckedChanged += new System.EventHandler(this.CbkProviderRideWithGpsCheckedChanged);
			// 
			// cbkProviderGarmin
			// 
			this.cbkProviderGarmin.AutoSize = true;
			this.cbkProviderGarmin.Location = new System.Drawing.Point(18, 115);
			this.cbkProviderGarmin.Name = "cbkProviderGarmin";
			this.cbkProviderGarmin.Size = new System.Drawing.Size(15, 14);
			this.cbkProviderGarmin.TabIndex = 3;
			this.cbkProviderGarmin.UseVisualStyleBackColor = true;
			this.cbkProviderGarmin.CheckedChanged += new System.EventHandler(this.CbkProviderGarminCheckedChanged);
			// 
			// cbkProviderEndomondo
			// 
			this.cbkProviderEndomondo.AutoSize = true;
			this.cbkProviderEndomondo.Location = new System.Drawing.Point(18, 81);
			this.cbkProviderEndomondo.Name = "cbkProviderEndomondo";
			this.cbkProviderEndomondo.Size = new System.Drawing.Size(15, 14);
			this.cbkProviderEndomondo.TabIndex = 2;
			this.cbkProviderEndomondo.UseVisualStyleBackColor = true;
			this.cbkProviderEndomondo.CheckedChanged += new System.EventHandler(this.CbkProviderEndomondoCheckedChanged);
			// 
			// cbkProviderStrava
			// 
			this.cbkProviderStrava.AutoSize = true;
			this.cbkProviderStrava.Location = new System.Drawing.Point(19, 47);
			this.cbkProviderStrava.Name = "cbkProviderStrava";
			this.cbkProviderStrava.Size = new System.Drawing.Size(15, 14);
			this.cbkProviderStrava.TabIndex = 1;
			this.cbkProviderStrava.UseVisualStyleBackColor = true;
			this.cbkProviderStrava.CheckedChanged += new System.EventHandler(this.CbkProviderStravaCheckedChanged);
			// 
			// cbkProviderRunkeeper
			// 
			this.cbkProviderRunkeeper.AutoSize = true;
			this.cbkProviderRunkeeper.Location = new System.Drawing.Point(19, 13);
			this.cbkProviderRunkeeper.Name = "cbkProviderRunkeeper";
			this.cbkProviderRunkeeper.Size = new System.Drawing.Size(15, 14);
			this.cbkProviderRunkeeper.TabIndex = 0;
			this.cbkProviderRunkeeper.UseVisualStyleBackColor = true;
			this.cbkProviderRunkeeper.CheckedChanged += new System.EventHandler(this.CbkProviderRunkeeperCheckedChanged);
			// 
			// pictureBox9
			// 
			this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
			this.pictureBox9.Location = new System.Drawing.Point(39, 140);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(139, 32);
			this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox9.TabIndex = 4;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox8
			// 
			this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
			this.pictureBox8.Location = new System.Drawing.Point(39, 106);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(32, 32);
			this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox8.TabIndex = 3;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(39, 72);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(32, 32);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox7.TabIndex = 2;
			this.pictureBox7.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(39, 38);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(32, 32);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox6.TabIndex = 1;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
			this.pictureBox5.Location = new System.Drawing.Point(39, 4);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(32, 32);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox5.TabIndex = 0;
			this.pictureBox5.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 615);
			this.Controls.Add(this.grpProviders);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.tabControlOverview);
			this.Controls.Add(this.grpSummary);
			this.Controls.Add(this.menubar);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1048, 653);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cycling Activity File Uploader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.grpSummary.ResumeLayout(false);
			this.grpSummary.PerformLayout();
			this.tabControlOverview.ResumeLayout(false);
			this.tabMap.ResumeLayout(false);
			this.tabMap.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabUploadStatus.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusRideWithGps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusGarmin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusStrava)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.pnlStatusRunkeeper.ResumeLayout(false);
			this.pnlStatusRunkeeper.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbUploadStatusRunkeeper)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menubar.ResumeLayout(false);
			this.menubar.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.grpProviders.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripStatusLabel statusBarVersion;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripProgressBar statusBarProgress;
		private System.Windows.Forms.ToolStripStatusLabel statusbarStatus;
		private System.Windows.Forms.ToolStripMenuItem menuViewAccountRideWithGps;
		private System.Windows.Forms.ToolStripMenuItem menuAbout;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.PictureBox pbUploadStatusRunkeeper;
		private System.Windows.Forms.PictureBox pbUploadStatusStrava;
		private System.Windows.Forms.PictureBox pbUploadStatusGarmin;
		private System.Windows.Forms.PictureBox pbUploadStatusRideWithGps;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.CheckBox cbkProviderRunkeeper;
		private System.Windows.Forms.CheckBox cbkProviderStrava;
		private System.Windows.Forms.CheckBox cbkProviderEndomondo;
		private System.Windows.Forms.CheckBox cbkProviderGarmin;
		private System.Windows.Forms.CheckBox cbkProviderRideWithGps;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpProviders;
		private System.Windows.Forms.ToolStripMenuItem menuViewAccountEndomondo;
		private System.Windows.Forms.ToolStripMenuItem menuConnectToEndomondo;
		private System.Windows.Forms.ToolStripMenuItem menuProviderEndomondo;
		private System.Windows.Forms.Label sUploadStravaMsg;
		private System.Windows.Forms.Label sUploadGarminMsg;
		private System.Windows.Forms.Label sUploadRideWithGpsMsg;
		private System.Windows.Forms.Label sUploadRunkeeperMsg;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.LinkLabel sUploadRunkeeperId;
		private System.Windows.Forms.Panel pnlStatusRunkeeper;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.LinkLabel sUploadStravaId;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.LinkLabel sUploadGarminId;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.LinkLabel sUploadRideWithGpsId;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TabPage tabUploadStatus;
		private System.Windows.Forms.Button btnUploadAllProviders;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripMenuItem menuUploadToRideWithGps;
		private System.Windows.Forms.ToolStripMenuItem menuConnectToRideWithGps;
		private System.Windows.Forms.ToolStripMenuItem menuProviderRideWithGps;
		private System.Windows.Forms.ToolStripMenuItem menuUploadToGarminConnect;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtAutoPauseThreshold;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtActivityName;
		private System.Windows.Forms.ToolStripMenuItem menuUploadToStrava;
		private System.Windows.Forms.ToolStripMenuItem menuViewAccountStrava;
		private System.Windows.Forms.ToolStripMenuItem menuViewAccountGarmin;
		private System.Windows.Forms.ToolStripMenuItem menuConnectToGarmin;
		private System.Windows.Forms.ToolStripMenuItem menuProviderGarmin;
		private System.Windows.Forms.ToolStripMenuItem menuConnectToStrava;
		private System.Windows.Forms.ToolStripMenuItem menuProviderStrava;
		private System.Windows.Forms.ToolStripMenuItem menuConnectToRunkeeper;
		private System.Windows.Forms.ToolStripMenuItem menuUploadToRunKeeper;
		private System.Windows.Forms.ToolStripMenuItem menuViewAccountRunKeeper;
		private System.Windows.Forms.ToolStripMenuItem menuProviderRunkeeper;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menubar;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtActivityNotes;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lblMovingTime;
		private System.Windows.Forms.Label lblTotalAscent;
		private System.Windows.Forms.Label lblTotalDescent;
		private System.Windows.Forms.Label lblMaxHeartRate;
		private System.Windows.Forms.Label lblMaxCadence;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblMaxSpeed;
		private ZedGraph.ZedGraphControl zedTemperature;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.TextBox txtDebug;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControlOverview;
		private System.Windows.Forms.Button btnMapFullscreen;
		private System.Windows.Forms.TabPage tabMap;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private ZedGraph.ZedGraphControl zedAltitude;
		private ZedGraph.ZedGraphControl zedCadence;
		private ZedGraph.ZedGraphControl zedHeart;
		private ZedGraph.ZedGraphControl zedSpeed;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader colTime;
		private ListViewNF.ListViewNF lstTrackpoints;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblAvgSpeed;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblActivityDateTime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblDistance;
		private System.Windows.Forms.Label lblCalories;
		private System.Windows.Forms.Label lblAvgHeartRate;
		private System.Windows.Forms.Label lblCadence;
		private System.Windows.Forms.GroupBox grpSummary;
		private System.Windows.Forms.OpenFileDialog openFile;
	}
}
