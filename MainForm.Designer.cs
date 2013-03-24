/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/02/2013
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
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
			this.panel5 = new System.Windows.Forms.Panel();
			this.pnlNoFile = new System.Windows.Forms.Panel();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.label26 = new System.Windows.Forms.Label();
			this.cbkIsStationaryTrainer = new System.Windows.Forms.CheckBox();
			this.cbkIsCommute = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnUploadAllProviders = new System.Windows.Forms.Button();
			this.txtAutoPauseThreshold = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtActivityName = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
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
			this.tabFileHistory = new System.Windows.Forms.TabPage();
			this.tabControlHistory = new System.Windows.Forms.TabControl();
			this.tabFiles = new System.Windows.Forms.TabPage();
			this.lstFileHistory = new ListViewExtended.ListViewExtended();
			this.colFileId = new System.Windows.Forms.ColumnHeader();
			this.colActivityDateTime = new System.Windows.Forms.ColumnHeader();
			this.colActivityFilename = new System.Windows.Forms.ColumnHeader();
			this.colOpenedDateTime = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colDuration = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colIsCommute = new System.Windows.Forms.ColumnHeader();
			this.colIsStationaryTrainer = new System.Windows.Forms.ColumnHeader();
			this.colNotes = new System.Windows.Forms.ColumnHeader();
			this.tabHistorySummary = new System.Windows.Forms.TabPage();
			this.cbkSummaryIncludeInStats = new System.Windows.Forms.CheckBox();
			this.cbkSummaryIsStationaryTrainer = new System.Windows.Forms.CheckBox();
			this.cbkSummaryIsCommute = new System.Windows.Forms.CheckBox();
			this.label25 = new System.Windows.Forms.Label();
			this.pnlHistoryUploadRideWithGPS = new System.Windows.Forms.Panel();
			this.linkHistoryUploadRideWithGPS = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadRideWithGPS = new System.Windows.Forms.CheckBox();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadRunkeeper = new System.Windows.Forms.Panel();
			this.linkHistoryUploadRunkeeper = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadRunkeeper = new System.Windows.Forms.CheckBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadStrava = new System.Windows.Forms.Panel();
			this.linkHistoryUploadStrava = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadStrava = new System.Windows.Forms.CheckBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadGarmin = new System.Windows.Forms.Panel();
			this.linkHistoryUploadGarmin = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadGarmin = new System.Windows.Forms.CheckBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.txtHistoryNotes = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lblHistoryMaxSpeed = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblHistoryMaxCadence = new System.Windows.Forms.Label();
			this.lblHistoryMaxHeartRate = new System.Windows.Forms.Label();
			this.lblHistoryTotalDescent = new System.Windows.Forms.Label();
			this.lblHistoryTotalAscent = new System.Windows.Forms.Label();
			this.lblHistoryMovingTime = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.lblHistoryAvgSpeed = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.lblHistoryName = new System.Windows.Forms.Label();
			this.lblHistoryAvgCadence = new System.Windows.Forms.Label();
			this.lblHistoryAvgHeartRate = new System.Windows.Forms.Label();
			this.lblHistoryCalories = new System.Windows.Forms.Label();
			this.lblHistoryDistance = new System.Windows.Forms.Label();
			this.lblHistoryDuration = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.tabHistoryMap = new System.Windows.Forms.TabPage();
			this.btnFullscreenHistoryMap = new System.Windows.Forms.Button();
			this.webBrowserHistoryMap = new System.Windows.Forms.WebBrowser();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.zedHistoryAltitude = new ZedGraph.ZedGraphControl();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.zedHistorySpeed = new ZedGraph.ZedGraphControl();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.zedHistoryCadence = new ZedGraph.ZedGraphControl();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.zedHistoryHeart = new ZedGraph.ZedGraphControl();
			this.tabPageMonthlyStats = new System.Windows.Forms.TabPage();
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
			this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
			this.tabPageRecords = new System.Windows.Forms.TabPage();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.zedTemperature = new ZedGraph.ZedGraphControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.menubar = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenBatch = new System.Windows.Forms.ToolStripMenuItem();
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
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
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
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label27 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.recMostClimbing = new System.Windows.Forms.Label();
			this.recAverageSpeed = new System.Windows.Forms.Label();
			this.recLongestRide = new System.Windows.Forms.Label();
			this.grpSummary.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnlNoFile.SuspendLayout();
			this.tabControlOverview.SuspendLayout();
			this.tabFileHistory.SuspendLayout();
			this.tabControlHistory.SuspendLayout();
			this.tabFiles.SuspendLayout();
			this.tabHistorySummary.SuspendLayout();
			this.pnlHistoryUploadRideWithGPS.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
			this.pnlHistoryUploadRunkeeper.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
			this.pnlHistoryUploadStrava.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
			this.pnlHistoryUploadGarmin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
			this.tabHistoryMap.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.tabPageMonthlyStats.SuspendLayout();
			this.tabPageRecords.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage7.SuspendLayout();
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
			this.tabPage1.SuspendLayout();
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
			this.grpSummary.Controls.Add(this.panel5);
			this.grpSummary.Enabled = false;
			this.grpSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpSummary.ForeColor = System.Drawing.Color.RoyalBlue;
			this.grpSummary.Location = new System.Drawing.Point(5, 51);
			this.grpSummary.Name = "grpSummary";
			this.grpSummary.Size = new System.Drawing.Size(799, 205);
			this.grpSummary.TabIndex = 1;
			this.grpSummary.TabStop = false;
			this.grpSummary.Text = "File Contents Summary";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.pnlNoFile);
			this.panel5.Controls.Add(this.cbkIsStationaryTrainer);
			this.panel5.Controls.Add(this.cbkIsCommute);
			this.panel5.Controls.Add(this.label10);
			this.panel5.Controls.Add(this.btnUploadAllProviders);
			this.panel5.Controls.Add(this.txtAutoPauseThreshold);
			this.panel5.Controls.Add(this.label13);
			this.panel5.Controls.Add(this.txtActivityName);
			this.panel5.Controls.Add(this.label11);
			this.panel5.Controls.Add(this.txtActivityNotes);
			this.panel5.Controls.Add(this.lblMaxSpeed);
			this.panel5.Controls.Add(this.label12);
			this.panel5.Controls.Add(this.lblMaxCadence);
			this.panel5.Controls.Add(this.lblMaxHeartRate);
			this.panel5.Controls.Add(this.lblTotalDescent);
			this.panel5.Controls.Add(this.lblTotalAscent);
			this.panel5.Controls.Add(this.lblMovingTime);
			this.panel5.Controls.Add(this.label20);
			this.panel5.Controls.Add(this.label21);
			this.panel5.Controls.Add(this.label22);
			this.panel5.Controls.Add(this.label23);
			this.panel5.Controls.Add(this.label24);
			this.panel5.Controls.Add(this.lblAvgSpeed);
			this.panel5.Controls.Add(this.label8);
			this.panel5.Controls.Add(this.lblActivityDateTime);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Controls.Add(this.lblCadence);
			this.panel5.Controls.Add(this.lblAvgHeartRate);
			this.panel5.Controls.Add(this.lblCalories);
			this.panel5.Controls.Add(this.lblDistance);
			this.panel5.Controls.Add(this.lblDuration);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Location = new System.Drawing.Point(10, 16);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(784, 183);
			this.panel5.TabIndex = 40;
			// 
			// pnlNoFile
			// 
			this.pnlNoFile.Controls.Add(this.btnOpenFile);
			this.pnlNoFile.Controls.Add(this.label26);
			this.pnlNoFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlNoFile.Location = new System.Drawing.Point(0, 0);
			this.pnlNoFile.Name = "pnlNoFile";
			this.pnlNoFile.Size = new System.Drawing.Size(784, 183);
			this.pnlNoFile.TabIndex = 41;
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnOpenFile.Location = new System.Drawing.Point(345, 107);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(105, 23);
			this.btnOpenFile.TabIndex = 1;
			this.btnOpenFile.Text = "Open File...";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFileClick);
			// 
			// label26
			// 
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(6, 73);
			this.label26.Margin = new System.Windows.Forms.Padding(0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(773, 31);
			this.label26.TabIndex = 0;
			this.label26.Text = "[ No File Loaded ]";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbkIsStationaryTrainer
			// 
			this.cbkIsStationaryTrainer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkIsStationaryTrainer.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkIsStationaryTrainer.Location = new System.Drawing.Point(552, 139);
			this.cbkIsStationaryTrainer.Name = "cbkIsStationaryTrainer";
			this.cbkIsStationaryTrainer.Size = new System.Drawing.Size(132, 16);
			this.cbkIsStationaryTrainer.TabIndex = 3;
			this.cbkIsStationaryTrainer.Text = "Stationary Trainer";
			this.cbkIsStationaryTrainer.UseVisualStyleBackColor = true;
			// 
			// cbkIsCommute
			// 
			this.cbkIsCommute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkIsCommute.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkIsCommute.Location = new System.Drawing.Point(552, 123);
			this.cbkIsCommute.Name = "cbkIsCommute";
			this.cbkIsCommute.Size = new System.Drawing.Size(90, 15);
			this.cbkIsCommute.TabIndex = 2;
			this.cbkIsCommute.Text = "Commute";
			this.cbkIsCommute.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.SteelBlue;
			this.label10.Location = new System.Drawing.Point(552, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(227, 14);
			this.label10.TabIndex = 32;
			this.label10.Text = "Activity Notes (ex. Strava / GarminConnect)";
			// 
			// btnUploadAllProviders
			// 
			this.btnUploadAllProviders.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUploadAllProviders.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUploadAllProviders.Location = new System.Drawing.Point(552, 157);
			this.btnUploadAllProviders.Name = "btnUploadAllProviders";
			this.btnUploadAllProviders.Size = new System.Drawing.Size(216, 23);
			this.btnUploadAllProviders.TabIndex = 4;
			this.btnUploadAllProviders.Text = "Upload to All Active Providers ...";
			this.btnUploadAllProviders.UseVisualStyleBackColor = true;
			this.btnUploadAllProviders.Click += new System.EventHandler(this.BtnUploadAllProvidersClick);
			// 
			// txtAutoPauseThreshold
			// 
			this.txtAutoPauseThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAutoPauseThreshold.Location = new System.Drawing.Point(390, 5);
			this.txtAutoPauseThreshold.Name = "txtAutoPauseThreshold";
			this.txtAutoPauseThreshold.Size = new System.Drawing.Size(38, 20);
			this.txtAutoPauseThreshold.TabIndex = 38;
			this.txtAutoPauseThreshold.Text = "0";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.SteelBlue;
			this.label13.Location = new System.Drawing.Point(272, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(137, 12);
			this.label13.TabIndex = 37;
			this.label13.Text = "Auto-Pause Speed Threshold";
			// 
			// txtActivityName
			// 
			this.txtActivityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivityName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtActivityName.Location = new System.Drawing.Point(552, 19);
			this.txtActivityName.Name = "txtActivityName";
			this.txtActivityName.Size = new System.Drawing.Size(216, 20);
			this.txtActivityName.TabIndex = 0;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.SteelBlue;
			this.label11.Location = new System.Drawing.Point(552, 5);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(216, 15);
			this.label11.TabIndex = 35;
			this.label11.Text = "Activity Name (ex. Strava)";
			// 
			// txtActivityNotes
			// 
			this.txtActivityNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtActivityNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtActivityNotes.Location = new System.Drawing.Point(552, 54);
			this.txtActivityNotes.Multiline = true;
			this.txtActivityNotes.Name = "txtActivityNotes";
			this.txtActivityNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtActivityNotes.Size = new System.Drawing.Size(216, 67);
			this.txtActivityNotes.TabIndex = 1;
			// 
			// lblMaxSpeed
			// 
			this.lblMaxSpeed.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblMaxSpeed.Location = new System.Drawing.Point(390, 147);
			this.lblMaxSpeed.Name = "lblMaxSpeed";
			this.lblMaxSpeed.Size = new System.Drawing.Size(156, 23);
			this.lblMaxSpeed.TabIndex = 29;
			this.lblMaxSpeed.Text = "-";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.SteelBlue;
			this.label12.Location = new System.Drawing.Point(272, 147);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 19);
			this.label12.TabIndex = 28;
			this.label12.Text = "Max Speed";
			// 
			// lblMaxCadence
			// 
			this.lblMaxCadence.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblMaxCadence.Location = new System.Drawing.Point(390, 123);
			this.lblMaxCadence.Name = "lblMaxCadence";
			this.lblMaxCadence.Size = new System.Drawing.Size(156, 23);
			this.lblMaxCadence.TabIndex = 25;
			this.lblMaxCadence.Text = "-";
			// 
			// lblMaxHeartRate
			// 
			this.lblMaxHeartRate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblMaxHeartRate.Location = new System.Drawing.Point(390, 100);
			this.lblMaxHeartRate.Name = "lblMaxHeartRate";
			this.lblMaxHeartRate.Size = new System.Drawing.Size(156, 23);
			this.lblMaxHeartRate.TabIndex = 24;
			this.lblMaxHeartRate.Text = "-";
			// 
			// lblTotalDescent
			// 
			this.lblTotalDescent.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDescent.ForeColor = System.Drawing.Color.Gray;
			this.lblTotalDescent.Location = new System.Drawing.Point(390, 77);
			this.lblTotalDescent.Name = "lblTotalDescent";
			this.lblTotalDescent.Size = new System.Drawing.Size(156, 23);
			this.lblTotalDescent.TabIndex = 23;
			this.lblTotalDescent.Text = "-";
			// 
			// lblTotalAscent
			// 
			this.lblTotalAscent.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAscent.ForeColor = System.Drawing.Color.Gray;
			this.lblTotalAscent.Location = new System.Drawing.Point(390, 54);
			this.lblTotalAscent.Name = "lblTotalAscent";
			this.lblTotalAscent.Size = new System.Drawing.Size(156, 23);
			this.lblTotalAscent.TabIndex = 22;
			this.lblTotalAscent.Text = "-";
			// 
			// lblMovingTime
			// 
			this.lblMovingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMovingTime.ForeColor = System.Drawing.Color.Gray;
			this.lblMovingTime.Location = new System.Drawing.Point(390, 31);
			this.lblMovingTime.Name = "lblMovingTime";
			this.lblMovingTime.Size = new System.Drawing.Size(156, 23);
			this.lblMovingTime.TabIndex = 21;
			this.lblMovingTime.Text = "-";
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.ForeColor = System.Drawing.Color.SteelBlue;
			this.label20.Location = new System.Drawing.Point(272, 123);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(93, 19);
			this.label20.TabIndex = 20;
			this.label20.Text = "Max Cadence";
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.SteelBlue;
			this.label21.Location = new System.Drawing.Point(272, 100);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(118, 23);
			this.label21.TabIndex = 19;
			this.label21.Text = "Max Heart Rate";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.SteelBlue;
			this.label22.Location = new System.Drawing.Point(272, 77);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 18;
			this.label22.Text = "Total Descent";
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.Color.SteelBlue;
			this.label23.Location = new System.Drawing.Point(272, 54);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 17;
			this.label23.Text = "Total Ascent";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.Color.SteelBlue;
			this.label24.Location = new System.Drawing.Point(272, 31);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 16;
			this.label24.Text = "Moving Time";
			// 
			// lblAvgSpeed
			// 
			this.lblAvgSpeed.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblAvgSpeed.Location = new System.Drawing.Point(129, 147);
			this.lblAvgSpeed.Name = "lblAvgSpeed";
			this.lblAvgSpeed.Size = new System.Drawing.Size(137, 19);
			this.lblAvgSpeed.TabIndex = 13;
			this.lblAvgSpeed.Text = "-";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.SteelBlue;
			this.label8.Location = new System.Drawing.Point(11, 147);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "Avg. Speed";
			// 
			// lblActivityDateTime
			// 
			this.lblActivityDateTime.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityDateTime.ForeColor = System.Drawing.Color.Gray;
			this.lblActivityDateTime.Location = new System.Drawing.Point(129, 8);
			this.lblActivityDateTime.Name = "lblActivityDateTime";
			this.lblActivityDateTime.Size = new System.Drawing.Size(137, 23);
			this.lblActivityDateTime.TabIndex = 11;
			this.lblActivityDateTime.Text = "-";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.SteelBlue;
			this.label7.Location = new System.Drawing.Point(11, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "Activity";
			// 
			// lblCadence
			// 
			this.lblCadence.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblCadence.Location = new System.Drawing.Point(129, 123);
			this.lblCadence.Name = "lblCadence";
			this.lblCadence.Size = new System.Drawing.Size(137, 19);
			this.lblCadence.TabIndex = 9;
			this.lblCadence.Text = "-";
			// 
			// lblAvgHeartRate
			// 
			this.lblAvgHeartRate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblAvgHeartRate.Location = new System.Drawing.Point(129, 100);
			this.lblAvgHeartRate.Name = "lblAvgHeartRate";
			this.lblAvgHeartRate.Size = new System.Drawing.Size(137, 23);
			this.lblAvgHeartRate.TabIndex = 8;
			this.lblAvgHeartRate.Text = "-";
			// 
			// lblCalories
			// 
			this.lblCalories.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCalories.ForeColor = System.Drawing.Color.Gray;
			this.lblCalories.Location = new System.Drawing.Point(129, 77);
			this.lblCalories.Name = "lblCalories";
			this.lblCalories.Size = new System.Drawing.Size(137, 23);
			this.lblCalories.TabIndex = 7;
			this.lblCalories.Text = "-";
			// 
			// lblDistance
			// 
			this.lblDistance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDistance.ForeColor = System.Drawing.Color.Gray;
			this.lblDistance.Location = new System.Drawing.Point(129, 54);
			this.lblDistance.Name = "lblDistance";
			this.lblDistance.Size = new System.Drawing.Size(137, 23);
			this.lblDistance.TabIndex = 6;
			this.lblDistance.Text = "-";
			// 
			// lblDuration
			// 
			this.lblDuration.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDuration.ForeColor = System.Drawing.Color.Gray;
			this.lblDuration.Location = new System.Drawing.Point(129, 31);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(137, 23);
			this.lblDuration.TabIndex = 5;
			this.lblDuration.Text = "-";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.SteelBlue;
			this.label5.Location = new System.Drawing.Point(11, 123);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 19);
			this.label5.TabIndex = 4;
			this.label5.Text = "Avg. Cadence";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(11, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Avg. Heart Rate";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SteelBlue;
			this.label3.Location = new System.Drawing.Point(11, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Calories";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SteelBlue;
			this.label2.Location = new System.Drawing.Point(11, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Distance";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(11, 31);
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
			this.lstTrackpoints.Size = new System.Drawing.Size(1010, 383);
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
			this.webBrowser1.Size = new System.Drawing.Size(976, 383);
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
			this.zedSpeed.Size = new System.Drawing.Size(1016, 389);
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
			this.zedHeart.Size = new System.Drawing.Size(1016, 389);
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
			this.zedCadence.Size = new System.Drawing.Size(1016, 389);
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
			this.zedAltitude.Size = new System.Drawing.Size(1016, 389);
			this.zedAltitude.TabIndex = 21;
			// 
			// tabControlOverview
			// 
			this.tabControlOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlOverview.Controls.Add(this.tabFileHistory);
			this.tabControlOverview.Controls.Add(this.tabMap);
			this.tabControlOverview.Controls.Add(this.tabPage3);
			this.tabControlOverview.Controls.Add(this.tabPage4);
			this.tabControlOverview.Controls.Add(this.tabPage5);
			this.tabControlOverview.Controls.Add(this.tabPage6);
			this.tabControlOverview.Controls.Add(this.tabPage2);
			this.tabControlOverview.Controls.Add(this.tabPage7);
			this.tabControlOverview.Controls.Add(this.tabUploadStatus);
			this.tabControlOverview.Controls.Add(this.tabPage1);
			this.tabControlOverview.Enabled = false;
			this.tabControlOverview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControlOverview.HotTrack = true;
			this.tabControlOverview.Location = new System.Drawing.Point(5, 262);
			this.tabControlOverview.Name = "tabControlOverview";
			this.tabControlOverview.SelectedIndex = 0;
			this.tabControlOverview.Size = new System.Drawing.Size(1024, 415);
			this.tabControlOverview.TabIndex = 24;
			this.tabControlOverview.SelectedIndexChanged += new System.EventHandler(this.TabControlOverviewSelectedIndexChanged);
			// 
			// tabFileHistory
			// 
			this.tabFileHistory.Controls.Add(this.tabControlHistory);
			this.tabFileHistory.Location = new System.Drawing.Point(4, 22);
			this.tabFileHistory.Name = "tabFileHistory";
			this.tabFileHistory.Padding = new System.Windows.Forms.Padding(3);
			this.tabFileHistory.Size = new System.Drawing.Size(1016, 389);
			this.tabFileHistory.TabIndex = 9;
			this.tabFileHistory.Text = "File History";
			this.tabFileHistory.UseVisualStyleBackColor = true;
			// 
			// tabControlHistory
			// 
			this.tabControlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlHistory.Controls.Add(this.tabFiles);
			this.tabControlHistory.Controls.Add(this.tabHistorySummary);
			this.tabControlHistory.Controls.Add(this.tabHistoryMap);
			this.tabControlHistory.Controls.Add(this.tabPage8);
			this.tabControlHistory.Controls.Add(this.tabPage9);
			this.tabControlHistory.Controls.Add(this.tabPage10);
			this.tabControlHistory.Controls.Add(this.tabPage11);
			this.tabControlHistory.Controls.Add(this.tabPageMonthlyStats);
			this.tabControlHistory.Controls.Add(this.tabPageRecords);
			this.tabControlHistory.Location = new System.Drawing.Point(6, 27);
			this.tabControlHistory.Name = "tabControlHistory";
			this.tabControlHistory.SelectedIndex = 0;
			this.tabControlHistory.Size = new System.Drawing.Size(1004, 356);
			this.tabControlHistory.TabIndex = 1;
			this.tabControlHistory.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlHistorySelected);
			// 
			// tabFiles
			// 
			this.tabFiles.Controls.Add(this.lstFileHistory);
			this.tabFiles.Location = new System.Drawing.Point(4, 22);
			this.tabFiles.Name = "tabFiles";
			this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabFiles.Size = new System.Drawing.Size(996, 330);
			this.tabFiles.TabIndex = 6;
			this.tabFiles.Text = "Files";
			this.tabFiles.UseVisualStyleBackColor = true;
			// 
			// lstFileHistory
			// 
			this.lstFileHistory.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstFileHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colFileId,
									this.colActivityDateTime,
									this.colActivityFilename,
									this.colOpenedDateTime,
									this.colDistance,
									this.colDuration,
									this.colAvgSpeed,
									this.colIsCommute,
									this.colIsStationaryTrainer,
									this.colNotes});
			this.lstFileHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstFileHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstFileHistory.FullRowSelect = true;
			this.lstFileHistory.HideSelection = false;
			this.lstFileHistory.Location = new System.Drawing.Point(3, 3);
			this.lstFileHistory.MultiSelect = false;
			this.lstFileHistory.Name = "lstFileHistory";
			this.lstFileHistory.Size = new System.Drawing.Size(990, 324);
			this.lstFileHistory.TabIndex = 0;
			this.lstFileHistory.UseCompatibleStateImageBehavior = false;
			this.lstFileHistory.View = System.Windows.Forms.View.Details;
			this.lstFileHistory.DoubleClick += new System.EventHandler(this.LstFileHistoryDoubleClick);
			this.lstFileHistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LstFileHistoryMouseClick);
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
			// colOpenedDateTime
			// 
			this.colOpenedDateTime.Text = "Date/Time (Opened)";
			this.colOpenedDateTime.Width = 113;
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
			// 
			// colIsStationaryTrainer
			// 
			this.colIsStationaryTrainer.Text = "Trainer";
			// 
			// colNotes
			// 
			this.colNotes.Text = "Notes";
			this.colNotes.Width = 500;
			// 
			// tabHistorySummary
			// 
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIncludeInStats);
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIsStationaryTrainer);
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIsCommute);
			this.tabHistorySummary.Controls.Add(this.label25);
			this.tabHistorySummary.Controls.Add(this.pnlHistoryUploadRideWithGPS);
			this.tabHistorySummary.Controls.Add(this.pnlHistoryUploadRunkeeper);
			this.tabHistorySummary.Controls.Add(this.pnlHistoryUploadStrava);
			this.tabHistorySummary.Controls.Add(this.pnlHistoryUploadGarmin);
			this.tabHistorySummary.Controls.Add(this.txtHistoryNotes);
			this.tabHistorySummary.Controls.Add(this.label6);
			this.tabHistorySummary.Controls.Add(this.lblHistoryMaxSpeed);
			this.tabHistorySummary.Controls.Add(this.label9);
			this.tabHistorySummary.Controls.Add(this.lblHistoryMaxCadence);
			this.tabHistorySummary.Controls.Add(this.lblHistoryMaxHeartRate);
			this.tabHistorySummary.Controls.Add(this.lblHistoryTotalDescent);
			this.tabHistorySummary.Controls.Add(this.lblHistoryTotalAscent);
			this.tabHistorySummary.Controls.Add(this.lblHistoryMovingTime);
			this.tabHistorySummary.Controls.Add(this.label30);
			this.tabHistorySummary.Controls.Add(this.label31);
			this.tabHistorySummary.Controls.Add(this.label32);
			this.tabHistorySummary.Controls.Add(this.label33);
			this.tabHistorySummary.Controls.Add(this.label34);
			this.tabHistorySummary.Controls.Add(this.lblHistoryAvgSpeed);
			this.tabHistorySummary.Controls.Add(this.label36);
			this.tabHistorySummary.Controls.Add(this.lblHistoryName);
			this.tabHistorySummary.Controls.Add(this.lblHistoryAvgCadence);
			this.tabHistorySummary.Controls.Add(this.lblHistoryAvgHeartRate);
			this.tabHistorySummary.Controls.Add(this.lblHistoryCalories);
			this.tabHistorySummary.Controls.Add(this.lblHistoryDistance);
			this.tabHistorySummary.Controls.Add(this.lblHistoryDuration);
			this.tabHistorySummary.Controls.Add(this.label44);
			this.tabHistorySummary.Controls.Add(this.label45);
			this.tabHistorySummary.Controls.Add(this.label46);
			this.tabHistorySummary.Controls.Add(this.label47);
			this.tabHistorySummary.Controls.Add(this.label48);
			this.tabHistorySummary.Location = new System.Drawing.Point(4, 22);
			this.tabHistorySummary.Name = "tabHistorySummary";
			this.tabHistorySummary.Padding = new System.Windows.Forms.Padding(3);
			this.tabHistorySummary.Size = new System.Drawing.Size(996, 330);
			this.tabHistorySummary.TabIndex = 4;
			this.tabHistorySummary.Text = "Summary";
			this.tabHistorySummary.UseVisualStyleBackColor = true;
			// 
			// cbkSummaryIncludeInStats
			// 
			this.cbkSummaryIncludeInStats.Enabled = false;
			this.cbkSummaryIncludeInStats.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkSummaryIncludeInStats.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkSummaryIncludeInStats.Location = new System.Drawing.Point(471, 97);
			this.cbkSummaryIncludeInStats.Name = "cbkSummaryIncludeInStats";
			this.cbkSummaryIncludeInStats.Size = new System.Drawing.Size(129, 24);
			this.cbkSummaryIncludeInStats.TabIndex = 67;
			this.cbkSummaryIncludeInStats.Text = "Included in Statistics";
			this.cbkSummaryIncludeInStats.UseVisualStyleBackColor = true;
			// 
			// cbkSummaryIsStationaryTrainer
			// 
			this.cbkSummaryIsStationaryTrainer.Enabled = false;
			this.cbkSummaryIsStationaryTrainer.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkSummaryIsStationaryTrainer.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkSummaryIsStationaryTrainer.Location = new System.Drawing.Point(471, 74);
			this.cbkSummaryIsStationaryTrainer.Name = "cbkSummaryIsStationaryTrainer";
			this.cbkSummaryIsStationaryTrainer.Size = new System.Drawing.Size(104, 24);
			this.cbkSummaryIsStationaryTrainer.TabIndex = 66;
			this.cbkSummaryIsStationaryTrainer.Text = "Stationary Trainer";
			this.cbkSummaryIsStationaryTrainer.UseVisualStyleBackColor = true;
			// 
			// cbkSummaryIsCommute
			// 
			this.cbkSummaryIsCommute.Enabled = false;
			this.cbkSummaryIsCommute.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkSummaryIsCommute.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkSummaryIsCommute.Location = new System.Drawing.Point(471, 51);
			this.cbkSummaryIsCommute.Name = "cbkSummaryIsCommute";
			this.cbkSummaryIsCommute.Size = new System.Drawing.Size(104, 24);
			this.cbkSummaryIsCommute.TabIndex = 65;
			this.cbkSummaryIsCommute.Text = "Commute";
			this.cbkSummaryIsCommute.UseVisualStyleBackColor = true;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.ForeColor = System.Drawing.Color.SteelBlue;
			this.label25.Location = new System.Drawing.Point(642, 61);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(89, 14);
			this.label25.TabIndex = 64;
			this.label25.Text = "Uploads";
			// 
			// pnlHistoryUploadRideWithGPS
			// 
			this.pnlHistoryUploadRideWithGPS.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadRideWithGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.linkHistoryUploadRideWithGPS);
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.cbkHistoryUploadRideWithGPS);
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.pictureBox13);
			this.pnlHistoryUploadRideWithGPS.Enabled = false;
			this.pnlHistoryUploadRideWithGPS.Location = new System.Drawing.Point(642, 263);
			this.pnlHistoryUploadRideWithGPS.Name = "pnlHistoryUploadRideWithGPS";
			this.pnlHistoryUploadRideWithGPS.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadRideWithGPS.Size = new System.Drawing.Size(143, 60);
			this.pnlHistoryUploadRideWithGPS.TabIndex = 63;
			// 
			// linkHistoryUploadRideWithGPS
			// 
			this.linkHistoryUploadRideWithGPS.Enabled = false;
			this.linkHistoryUploadRideWithGPS.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkHistoryUploadRideWithGPS.ForeColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadRideWithGPS.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadRideWithGPS.Location = new System.Drawing.Point(24, 36);
			this.linkHistoryUploadRideWithGPS.Name = "linkHistoryUploadRideWithGPS";
			this.linkHistoryUploadRideWithGPS.Size = new System.Drawing.Size(100, 23);
			this.linkHistoryUploadRideWithGPS.TabIndex = 61;
			this.linkHistoryUploadRideWithGPS.TabStop = true;
			this.linkHistoryUploadRideWithGPS.Text = "Click to View";
			this.linkHistoryUploadRideWithGPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHistoryUploadClicked);
			// 
			// cbkHistoryUploadRideWithGPS
			// 
			this.cbkHistoryUploadRideWithGPS.AutoSize = true;
			this.cbkHistoryUploadRideWithGPS.Enabled = false;
			this.cbkHistoryUploadRideWithGPS.Location = new System.Drawing.Point(4, 3);
			this.cbkHistoryUploadRideWithGPS.Name = "cbkHistoryUploadRideWithGPS";
			this.cbkHistoryUploadRideWithGPS.Size = new System.Drawing.Size(15, 14);
			this.cbkHistoryUploadRideWithGPS.TabIndex = 59;
			this.cbkHistoryUploadRideWithGPS.UseVisualStyleBackColor = true;
			// 
			// pictureBox13
			// 
			this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
			this.pictureBox13.Location = new System.Drawing.Point(24, 3);
			this.pictureBox13.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox13.Name = "pictureBox13";
			this.pictureBox13.Size = new System.Drawing.Size(116, 32);
			this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox13.TabIndex = 58;
			this.pictureBox13.TabStop = false;
			// 
			// pnlHistoryUploadRunkeeper
			// 
			this.pnlHistoryUploadRunkeeper.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadRunkeeper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.linkHistoryUploadRunkeeper);
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.cbkHistoryUploadRunkeeper);
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.pictureBox12);
			this.pnlHistoryUploadRunkeeper.Enabled = false;
			this.pnlHistoryUploadRunkeeper.Location = new System.Drawing.Point(642, 80);
			this.pnlHistoryUploadRunkeeper.Name = "pnlHistoryUploadRunkeeper";
			this.pnlHistoryUploadRunkeeper.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadRunkeeper.Size = new System.Drawing.Size(143, 60);
			this.pnlHistoryUploadRunkeeper.TabIndex = 62;
			// 
			// linkHistoryUploadRunkeeper
			// 
			this.linkHistoryUploadRunkeeper.Enabled = false;
			this.linkHistoryUploadRunkeeper.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkHistoryUploadRunkeeper.ForeColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadRunkeeper.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadRunkeeper.Location = new System.Drawing.Point(24, 36);
			this.linkHistoryUploadRunkeeper.Name = "linkHistoryUploadRunkeeper";
			this.linkHistoryUploadRunkeeper.Size = new System.Drawing.Size(100, 23);
			this.linkHistoryUploadRunkeeper.TabIndex = 60;
			this.linkHistoryUploadRunkeeper.TabStop = true;
			this.linkHistoryUploadRunkeeper.Text = "Click to View";
			this.linkHistoryUploadRunkeeper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHistoryUploadClicked);
			// 
			// cbkHistoryUploadRunkeeper
			// 
			this.cbkHistoryUploadRunkeeper.AutoSize = true;
			this.cbkHistoryUploadRunkeeper.Enabled = false;
			this.cbkHistoryUploadRunkeeper.Location = new System.Drawing.Point(4, 3);
			this.cbkHistoryUploadRunkeeper.Name = "cbkHistoryUploadRunkeeper";
			this.cbkHistoryUploadRunkeeper.Size = new System.Drawing.Size(15, 14);
			this.cbkHistoryUploadRunkeeper.TabIndex = 59;
			this.cbkHistoryUploadRunkeeper.UseVisualStyleBackColor = true;
			// 
			// pictureBox12
			// 
			this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
			this.pictureBox12.Location = new System.Drawing.Point(24, 3);
			this.pictureBox12.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(32, 32);
			this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox12.TabIndex = 58;
			this.pictureBox12.TabStop = false;
			// 
			// pnlHistoryUploadStrava
			// 
			this.pnlHistoryUploadStrava.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadStrava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadStrava.Controls.Add(this.linkHistoryUploadStrava);
			this.pnlHistoryUploadStrava.Controls.Add(this.cbkHistoryUploadStrava);
			this.pnlHistoryUploadStrava.Controls.Add(this.pictureBox11);
			this.pnlHistoryUploadStrava.Enabled = false;
			this.pnlHistoryUploadStrava.Location = new System.Drawing.Point(642, 141);
			this.pnlHistoryUploadStrava.Name = "pnlHistoryUploadStrava";
			this.pnlHistoryUploadStrava.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadStrava.Size = new System.Drawing.Size(143, 60);
			this.pnlHistoryUploadStrava.TabIndex = 61;
			// 
			// linkHistoryUploadStrava
			// 
			this.linkHistoryUploadStrava.Enabled = false;
			this.linkHistoryUploadStrava.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkHistoryUploadStrava.ForeColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadStrava.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadStrava.Location = new System.Drawing.Point(24, 36);
			this.linkHistoryUploadStrava.Name = "linkHistoryUploadStrava";
			this.linkHistoryUploadStrava.Size = new System.Drawing.Size(100, 23);
			this.linkHistoryUploadStrava.TabIndex = 61;
			this.linkHistoryUploadStrava.TabStop = true;
			this.linkHistoryUploadStrava.Text = "Click to View";
			this.linkHistoryUploadStrava.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHistoryUploadClicked);
			// 
			// cbkHistoryUploadStrava
			// 
			this.cbkHistoryUploadStrava.AutoSize = true;
			this.cbkHistoryUploadStrava.Enabled = false;
			this.cbkHistoryUploadStrava.Location = new System.Drawing.Point(4, 3);
			this.cbkHistoryUploadStrava.Name = "cbkHistoryUploadStrava";
			this.cbkHistoryUploadStrava.Size = new System.Drawing.Size(15, 14);
			this.cbkHistoryUploadStrava.TabIndex = 59;
			this.cbkHistoryUploadStrava.UseVisualStyleBackColor = true;
			// 
			// pictureBox11
			// 
			this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
			this.pictureBox11.Location = new System.Drawing.Point(24, 3);
			this.pictureBox11.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(32, 32);
			this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox11.TabIndex = 58;
			this.pictureBox11.TabStop = false;
			// 
			// pnlHistoryUploadGarmin
			// 
			this.pnlHistoryUploadGarmin.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadGarmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadGarmin.Controls.Add(this.linkHistoryUploadGarmin);
			this.pnlHistoryUploadGarmin.Controls.Add(this.cbkHistoryUploadGarmin);
			this.pnlHistoryUploadGarmin.Controls.Add(this.pictureBox10);
			this.pnlHistoryUploadGarmin.Enabled = false;
			this.pnlHistoryUploadGarmin.Location = new System.Drawing.Point(642, 202);
			this.pnlHistoryUploadGarmin.Name = "pnlHistoryUploadGarmin";
			this.pnlHistoryUploadGarmin.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadGarmin.Size = new System.Drawing.Size(143, 60);
			this.pnlHistoryUploadGarmin.TabIndex = 60;
			// 
			// linkHistoryUploadGarmin
			// 
			this.linkHistoryUploadGarmin.Enabled = false;
			this.linkHistoryUploadGarmin.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkHistoryUploadGarmin.ForeColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadGarmin.LinkColor = System.Drawing.Color.DodgerBlue;
			this.linkHistoryUploadGarmin.Location = new System.Drawing.Point(24, 36);
			this.linkHistoryUploadGarmin.Name = "linkHistoryUploadGarmin";
			this.linkHistoryUploadGarmin.Size = new System.Drawing.Size(100, 23);
			this.linkHistoryUploadGarmin.TabIndex = 61;
			this.linkHistoryUploadGarmin.TabStop = true;
			this.linkHistoryUploadGarmin.Text = "Click to View";
			this.linkHistoryUploadGarmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHistoryUploadClicked);
			// 
			// cbkHistoryUploadGarmin
			// 
			this.cbkHistoryUploadGarmin.AutoSize = true;
			this.cbkHistoryUploadGarmin.Enabled = false;
			this.cbkHistoryUploadGarmin.Location = new System.Drawing.Point(4, 3);
			this.cbkHistoryUploadGarmin.Name = "cbkHistoryUploadGarmin";
			this.cbkHistoryUploadGarmin.Size = new System.Drawing.Size(15, 14);
			this.cbkHistoryUploadGarmin.TabIndex = 59;
			this.cbkHistoryUploadGarmin.UseVisualStyleBackColor = true;
			// 
			// pictureBox10
			// 
			this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
			this.pictureBox10.Location = new System.Drawing.Point(24, 3);
			this.pictureBox10.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(32, 32);
			this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox10.TabIndex = 58;
			this.pictureBox10.TabStop = false;
			// 
			// txtHistoryNotes
			// 
			this.txtHistoryNotes.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHistoryNotes.Location = new System.Drawing.Point(110, 198);
			this.txtHistoryNotes.Multiline = true;
			this.txtHistoryNotes.Name = "txtHistoryNotes";
			this.txtHistoryNotes.ReadOnly = true;
			this.txtHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHistoryNotes.Size = new System.Drawing.Size(349, 122);
			this.txtHistoryNotes.TabIndex = 57;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.SteelBlue;
			this.label6.Location = new System.Drawing.Point(15, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 19);
			this.label6.TabIndex = 56;
			this.label6.Text = "Notes";
			// 
			// lblHistoryMaxSpeed
			// 
			this.lblHistoryMaxSpeed.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxSpeed.Location = new System.Drawing.Point(333, 172);
			this.lblHistoryMaxSpeed.Name = "lblHistoryMaxSpeed";
			this.lblHistoryMaxSpeed.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxSpeed.TabIndex = 55;
			this.lblHistoryMaxSpeed.Text = "-";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.SteelBlue;
			this.label9.Location = new System.Drawing.Point(238, 172);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(89, 19);
			this.label9.TabIndex = 54;
			this.label9.Text = "Max Speed";
			// 
			// lblHistoryMaxCadence
			// 
			this.lblHistoryMaxCadence.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxCadence.Location = new System.Drawing.Point(333, 148);
			this.lblHistoryMaxCadence.Name = "lblHistoryMaxCadence";
			this.lblHistoryMaxCadence.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxCadence.TabIndex = 53;
			this.lblHistoryMaxCadence.Text = "-";
			// 
			// lblHistoryMaxHeartRate
			// 
			this.lblHistoryMaxHeartRate.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxHeartRate.Location = new System.Drawing.Point(333, 125);
			this.lblHistoryMaxHeartRate.Name = "lblHistoryMaxHeartRate";
			this.lblHistoryMaxHeartRate.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxHeartRate.TabIndex = 52;
			this.lblHistoryMaxHeartRate.Text = "-";
			// 
			// lblHistoryTotalDescent
			// 
			this.lblHistoryTotalDescent.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryTotalDescent.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryTotalDescent.Location = new System.Drawing.Point(333, 102);
			this.lblHistoryTotalDescent.Name = "lblHistoryTotalDescent";
			this.lblHistoryTotalDescent.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryTotalDescent.TabIndex = 51;
			this.lblHistoryTotalDescent.Text = "-";
			// 
			// lblHistoryTotalAscent
			// 
			this.lblHistoryTotalAscent.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryTotalAscent.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryTotalAscent.Location = new System.Drawing.Point(333, 80);
			this.lblHistoryTotalAscent.Name = "lblHistoryTotalAscent";
			this.lblHistoryTotalAscent.Size = new System.Drawing.Size(117, 15);
			this.lblHistoryTotalAscent.TabIndex = 50;
			this.lblHistoryTotalAscent.Text = "-";
			// 
			// lblHistoryMovingTime
			// 
			this.lblHistoryMovingTime.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMovingTime.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMovingTime.Location = new System.Drawing.Point(333, 56);
			this.lblHistoryMovingTime.Name = "lblHistoryMovingTime";
			this.lblHistoryMovingTime.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMovingTime.TabIndex = 49;
			this.lblHistoryMovingTime.Text = "-";
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.ForeColor = System.Drawing.Color.SteelBlue;
			this.label30.Location = new System.Drawing.Point(238, 148);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(82, 19);
			this.label30.TabIndex = 48;
			this.label30.Text = "Max Cadence";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.ForeColor = System.Drawing.Color.SteelBlue;
			this.label31.Location = new System.Drawing.Point(238, 125);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(89, 23);
			this.label31.TabIndex = 47;
			this.label31.Text = "Max Heart Rate";
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.ForeColor = System.Drawing.Color.SteelBlue;
			this.label32.Location = new System.Drawing.Point(238, 102);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(89, 23);
			this.label32.TabIndex = 46;
			this.label32.Text = "Total Descent";
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.SteelBlue;
			this.label33.Location = new System.Drawing.Point(238, 80);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(89, 15);
			this.label33.TabIndex = 45;
			this.label33.Text = "Total Ascent";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label34.ForeColor = System.Drawing.Color.SteelBlue;
			this.label34.Location = new System.Drawing.Point(238, 57);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(89, 22);
			this.label34.TabIndex = 44;
			this.label34.Text = "Moving Time";
			// 
			// lblHistoryAvgSpeed
			// 
			this.lblHistoryAvgSpeed.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgSpeed.Location = new System.Drawing.Point(110, 173);
			this.lblHistoryAvgSpeed.Name = "lblHistoryAvgSpeed";
			this.lblHistoryAvgSpeed.Size = new System.Drawing.Size(122, 19);
			this.lblHistoryAvgSpeed.TabIndex = 43;
			this.lblHistoryAvgSpeed.Text = "-";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label36.ForeColor = System.Drawing.Color.SteelBlue;
			this.label36.Location = new System.Drawing.Point(15, 173);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(89, 19);
			this.label36.TabIndex = 42;
			this.label36.Text = "Avg. Speed";
			// 
			// lblHistoryName
			// 
			this.lblHistoryName.BackColor = System.Drawing.Color.Gainsboro;
			this.lblHistoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHistoryName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblHistoryName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryName.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblHistoryName.Location = new System.Drawing.Point(3, 3);
			this.lblHistoryName.Name = "lblHistoryName";
			this.lblHistoryName.Padding = new System.Windows.Forms.Padding(5);
			this.lblHistoryName.Size = new System.Drawing.Size(990, 40);
			this.lblHistoryName.TabIndex = 41;
			this.lblHistoryName.Text = "<Activity History : Summary Information>";
			// 
			// lblHistoryAvgCadence
			// 
			this.lblHistoryAvgCadence.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgCadence.Location = new System.Drawing.Point(110, 149);
			this.lblHistoryAvgCadence.Name = "lblHistoryAvgCadence";
			this.lblHistoryAvgCadence.Size = new System.Drawing.Size(122, 19);
			this.lblHistoryAvgCadence.TabIndex = 39;
			this.lblHistoryAvgCadence.Text = "-";
			// 
			// lblHistoryAvgHeartRate
			// 
			this.lblHistoryAvgHeartRate.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgHeartRate.Location = new System.Drawing.Point(110, 126);
			this.lblHistoryAvgHeartRate.Name = "lblHistoryAvgHeartRate";
			this.lblHistoryAvgHeartRate.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryAvgHeartRate.TabIndex = 38;
			this.lblHistoryAvgHeartRate.Text = "-";
			// 
			// lblHistoryCalories
			// 
			this.lblHistoryCalories.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryCalories.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryCalories.Location = new System.Drawing.Point(110, 103);
			this.lblHistoryCalories.Name = "lblHistoryCalories";
			this.lblHistoryCalories.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryCalories.TabIndex = 37;
			this.lblHistoryCalories.Text = "-";
			// 
			// lblHistoryDistance
			// 
			this.lblHistoryDistance.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryDistance.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryDistance.Location = new System.Drawing.Point(110, 80);
			this.lblHistoryDistance.Name = "lblHistoryDistance";
			this.lblHistoryDistance.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryDistance.TabIndex = 36;
			this.lblHistoryDistance.Text = "-";
			// 
			// lblHistoryDuration
			// 
			this.lblHistoryDuration.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryDuration.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryDuration.Location = new System.Drawing.Point(110, 57);
			this.lblHistoryDuration.Name = "lblHistoryDuration";
			this.lblHistoryDuration.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryDuration.TabIndex = 35;
			this.lblHistoryDuration.Text = "-";
			// 
			// label44
			// 
			this.label44.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label44.ForeColor = System.Drawing.Color.SteelBlue;
			this.label44.Location = new System.Drawing.Point(15, 149);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(99, 19);
			this.label44.TabIndex = 34;
			this.label44.Text = "Avg. Cadence";
			// 
			// label45
			// 
			this.label45.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label45.ForeColor = System.Drawing.Color.SteelBlue;
			this.label45.Location = new System.Drawing.Point(15, 126);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(89, 23);
			this.label45.TabIndex = 33;
			this.label45.Text = "Avg. Heart Rate";
			// 
			// label46
			// 
			this.label46.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label46.ForeColor = System.Drawing.Color.SteelBlue;
			this.label46.Location = new System.Drawing.Point(15, 103);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(89, 23);
			this.label46.TabIndex = 32;
			this.label46.Text = "Calories";
			// 
			// label47
			// 
			this.label47.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label47.ForeColor = System.Drawing.Color.SteelBlue;
			this.label47.Location = new System.Drawing.Point(15, 80);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(89, 23);
			this.label47.TabIndex = 31;
			this.label47.Text = "Distance";
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label48.ForeColor = System.Drawing.Color.SteelBlue;
			this.label48.Location = new System.Drawing.Point(15, 57);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(89, 23);
			this.label48.TabIndex = 30;
			this.label48.Text = "Duration";
			// 
			// tabHistoryMap
			// 
			this.tabHistoryMap.Controls.Add(this.btnFullscreenHistoryMap);
			this.tabHistoryMap.Controls.Add(this.webBrowserHistoryMap);
			this.tabHistoryMap.Location = new System.Drawing.Point(4, 22);
			this.tabHistoryMap.Name = "tabHistoryMap";
			this.tabHistoryMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabHistoryMap.Size = new System.Drawing.Size(996, 330);
			this.tabHistoryMap.TabIndex = 5;
			this.tabHistoryMap.Text = "Map";
			this.tabHistoryMap.UseVisualStyleBackColor = true;
			// 
			// btnFullscreenHistoryMap
			// 
			this.btnFullscreenHistoryMap.AutoSize = true;
			this.btnFullscreenHistoryMap.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnFullscreenHistoryMap.Image = ((System.Drawing.Image)(resources.GetObject("btnFullscreenHistoryMap.Image")));
			this.btnFullscreenHistoryMap.Location = new System.Drawing.Point(959, 3);
			this.btnFullscreenHistoryMap.Name = "btnFullscreenHistoryMap";
			this.btnFullscreenHistoryMap.Size = new System.Drawing.Size(34, 324);
			this.btnFullscreenHistoryMap.TabIndex = 2;
			this.btnFullscreenHistoryMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFullscreenHistoryMap.UseVisualStyleBackColor = true;
			this.btnFullscreenHistoryMap.Click += new System.EventHandler(this.BtnFullscreenHistoryMapClick);
			// 
			// webBrowserHistoryMap
			// 
			this.webBrowserHistoryMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowserHistoryMap.Location = new System.Drawing.Point(3, 3);
			this.webBrowserHistoryMap.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowserHistoryMap.Name = "webBrowserHistoryMap";
			this.webBrowserHistoryMap.ScrollBarsEnabled = false;
			this.webBrowserHistoryMap.Size = new System.Drawing.Size(950, 324);
			this.webBrowserHistoryMap.TabIndex = 1;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.zedHistoryAltitude);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new System.Drawing.Size(996, 330);
			this.tabPage8.TabIndex = 0;
			this.tabPage8.Text = "Altitude";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// zedHistoryAltitude
			// 
			this.zedHistoryAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedHistoryAltitude.IsAntiAlias = true;
			this.zedHistoryAltitude.IsShowPointValues = true;
			this.zedHistoryAltitude.Location = new System.Drawing.Point(3, 3);
			this.zedHistoryAltitude.Name = "zedHistoryAltitude";
			this.zedHistoryAltitude.ScrollGrace = 0D;
			this.zedHistoryAltitude.ScrollMaxX = 0D;
			this.zedHistoryAltitude.ScrollMaxY = 0D;
			this.zedHistoryAltitude.ScrollMaxY2 = 0D;
			this.zedHistoryAltitude.ScrollMinX = 0D;
			this.zedHistoryAltitude.ScrollMinY = 0D;
			this.zedHistoryAltitude.ScrollMinY2 = 0D;
			this.zedHistoryAltitude.Size = new System.Drawing.Size(990, 324);
			this.zedHistoryAltitude.TabIndex = 0;
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.zedHistorySpeed);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(996, 330);
			this.tabPage9.TabIndex = 1;
			this.tabPage9.Text = "Speed";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// zedHistorySpeed
			// 
			this.zedHistorySpeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedHistorySpeed.IsAntiAlias = true;
			this.zedHistorySpeed.IsShowPointValues = true;
			this.zedHistorySpeed.Location = new System.Drawing.Point(3, 3);
			this.zedHistorySpeed.Name = "zedHistorySpeed";
			this.zedHistorySpeed.ScrollGrace = 0D;
			this.zedHistorySpeed.ScrollMaxX = 0D;
			this.zedHistorySpeed.ScrollMaxY = 0D;
			this.zedHistorySpeed.ScrollMaxY2 = 0D;
			this.zedHistorySpeed.ScrollMinX = 0D;
			this.zedHistorySpeed.ScrollMinY = 0D;
			this.zedHistorySpeed.ScrollMinY2 = 0D;
			this.zedHistorySpeed.Size = new System.Drawing.Size(990, 324);
			this.zedHistorySpeed.TabIndex = 1;
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.zedHistoryCadence);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(996, 330);
			this.tabPage10.TabIndex = 2;
			this.tabPage10.Text = "Cadence";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// zedHistoryCadence
			// 
			this.zedHistoryCadence.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedHistoryCadence.IsAntiAlias = true;
			this.zedHistoryCadence.IsShowPointValues = true;
			this.zedHistoryCadence.Location = new System.Drawing.Point(3, 3);
			this.zedHistoryCadence.Name = "zedHistoryCadence";
			this.zedHistoryCadence.ScrollGrace = 0D;
			this.zedHistoryCadence.ScrollMaxX = 0D;
			this.zedHistoryCadence.ScrollMaxY = 0D;
			this.zedHistoryCadence.ScrollMaxY2 = 0D;
			this.zedHistoryCadence.ScrollMinX = 0D;
			this.zedHistoryCadence.ScrollMinY = 0D;
			this.zedHistoryCadence.ScrollMinY2 = 0D;
			this.zedHistoryCadence.Size = new System.Drawing.Size(990, 324);
			this.zedHistoryCadence.TabIndex = 1;
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.zedHistoryHeart);
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new System.Drawing.Size(996, 330);
			this.tabPage11.TabIndex = 3;
			this.tabPage11.Text = "Heart Rate";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// zedHistoryHeart
			// 
			this.zedHistoryHeart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedHistoryHeart.IsAntiAlias = true;
			this.zedHistoryHeart.IsShowPointValues = true;
			this.zedHistoryHeart.Location = new System.Drawing.Point(3, 3);
			this.zedHistoryHeart.Name = "zedHistoryHeart";
			this.zedHistoryHeart.ScrollGrace = 0D;
			this.zedHistoryHeart.ScrollMaxX = 0D;
			this.zedHistoryHeart.ScrollMaxY = 0D;
			this.zedHistoryHeart.ScrollMaxY2 = 0D;
			this.zedHistoryHeart.ScrollMinX = 0D;
			this.zedHistoryHeart.ScrollMinY = 0D;
			this.zedHistoryHeart.ScrollMinY2 = 0D;
			this.zedHistoryHeart.Size = new System.Drawing.Size(990, 324);
			this.zedHistoryHeart.TabIndex = 1;
			// 
			// tabPageMonthlyStats
			// 
			this.tabPageMonthlyStats.Controls.Add(this.lstMonthlyStats);
			this.tabPageMonthlyStats.Location = new System.Drawing.Point(4, 22);
			this.tabPageMonthlyStats.Name = "tabPageMonthlyStats";
			this.tabPageMonthlyStats.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMonthlyStats.Size = new System.Drawing.Size(996, 330);
			this.tabPageMonthlyStats.TabIndex = 7;
			this.tabPageMonthlyStats.Text = "Monthly Stats";
			this.tabPageMonthlyStats.UseVisualStyleBackColor = true;
			// 
			// lstMonthlyStats
			// 
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
									this.columnHeader29});
			this.lstMonthlyStats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstMonthlyStats.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstMonthlyStats.GridLines = true;
			this.lstMonthlyStats.Location = new System.Drawing.Point(3, 3);
			this.lstMonthlyStats.Name = "lstMonthlyStats";
			this.lstMonthlyStats.Size = new System.Drawing.Size(990, 324);
			this.lstMonthlyStats.TabIndex = 0;
			this.lstMonthlyStats.UseCompatibleStateImageBehavior = false;
			this.lstMonthlyStats.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Month";
			this.columnHeader15.Width = 73;
			// 
			// columnHeader23
			// 
			this.columnHeader23.Text = "Count";
			this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Total Distance";
			this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader16.Width = 92;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Total Moving";
			this.columnHeader17.Width = 102;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "Avg. Speed";
			this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader18.Width = 75;
			// 
			// columnHeader30
			// 
			this.columnHeader30.Text = "Avg. Cadence";
			this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader30.Width = 74;
			// 
			// columnHeader31
			// 
			this.columnHeader31.Text = "Avg. Heart";
			this.columnHeader31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader31.Width = 68;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "Total Ascent";
			this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader24.Width = 73;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "Max Speed";
			this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader26
			// 
			this.columnHeader26.Text = "Max Heart";
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
			this.columnHeader28.Text = "Max Ascent";
			this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader28.Width = 67;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "";
			this.columnHeader29.Width = 5;
			// 
			// tabPageRecords
			// 
			this.tabPageRecords.Controls.Add(this.recMostClimbing);
			this.tabPageRecords.Controls.Add(this.recAverageSpeed);
			this.tabPageRecords.Controls.Add(this.recLongestRide);
			this.tabPageRecords.Controls.Add(this.label28);
			this.tabPageRecords.Controls.Add(this.label14);
			this.tabPageRecords.Controls.Add(this.label27);
			this.tabPageRecords.Location = new System.Drawing.Point(4, 22);
			this.tabPageRecords.Name = "tabPageRecords";
			this.tabPageRecords.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRecords.Size = new System.Drawing.Size(996, 330);
			this.tabPageRecords.TabIndex = 8;
			this.tabPageRecords.Text = "Records";
			this.tabPageRecords.UseVisualStyleBackColor = true;
			// 
			// tabMap
			// 
			this.tabMap.Controls.Add(this.webBrowser1);
			this.tabMap.Controls.Add(this.btnMapFullscreen);
			this.tabMap.Location = new System.Drawing.Point(4, 22);
			this.tabMap.Name = "tabMap";
			this.tabMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabMap.Size = new System.Drawing.Size(1016, 389);
			this.tabMap.TabIndex = 5;
			this.tabMap.Text = "Map";
			this.tabMap.UseVisualStyleBackColor = true;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.AutoSize = true;
			this.btnMapFullscreen.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(979, 3);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(34, 383);
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
			this.tabPage3.Size = new System.Drawing.Size(1016, 389);
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
			this.tabPage4.Size = new System.Drawing.Size(1016, 389);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Speed";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.zedCadence);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1016, 389);
			this.tabPage5.TabIndex = 2;
			this.tabPage5.Text = "Cadence";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.zedHeart);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(1016, 389);
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
			this.tabPage2.Size = new System.Drawing.Size(1016, 389);
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
			this.zedTemperature.Size = new System.Drawing.Size(1010, 383);
			this.zedTemperature.TabIndex = 20;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.lstTrackpoints);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(1016, 389);
			this.tabPage7.TabIndex = 4;
			this.tabPage7.Text = "Track Points";
			this.tabPage7.UseVisualStyleBackColor = true;
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
			this.tabUploadStatus.Size = new System.Drawing.Size(1016, 389);
			this.tabUploadStatus.TabIndex = 8;
			this.tabUploadStatus.Text = "Upload Status";
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel4.Controls.Add(this.pbUploadStatusRideWithGps);
			this.panel4.Controls.Add(this.sUploadRideWithGpsId);
			this.panel4.Controls.Add(this.sUploadRideWithGpsMsg);
			this.panel4.Controls.Add(this.label18);
			this.panel4.Controls.Add(this.pictureBox4);
			this.panel4.Location = new System.Drawing.Point(755, 15);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(240, 340);
			this.panel4.TabIndex = 8;
			// 
			// pbUploadStatusRideWithGps
			// 
			this.pbUploadStatusRideWithGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbUploadStatusRideWithGps.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusRideWithGps.Location = new System.Drawing.Point(205, 305);
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
			this.sUploadRideWithGpsMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.sUploadRideWithGpsMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadRideWithGpsMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadRideWithGpsMsg.Location = new System.Drawing.Point(4, 64);
			this.sUploadRideWithGpsMsg.Name = "sUploadRideWithGpsMsg";
			this.sUploadRideWithGpsMsg.Size = new System.Drawing.Size(213, 238);
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
			this.pictureBox4.Size = new System.Drawing.Size(240, 38);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox4.TabIndex = 1;
			this.pictureBox4.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel2.Controls.Add(this.pbUploadStatusGarmin);
			this.panel2.Controls.Add(this.sUploadGarminId);
			this.panel2.Controls.Add(this.sUploadGarminMsg);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.pictureBox3);
			this.panel2.Location = new System.Drawing.Point(510, 15);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(240, 340);
			this.panel2.TabIndex = 7;
			// 
			// pbUploadStatusGarmin
			// 
			this.pbUploadStatusGarmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbUploadStatusGarmin.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusGarmin.Location = new System.Drawing.Point(205, 305);
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
			this.sUploadGarminMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.sUploadGarminMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadGarminMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadGarminMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadGarminMsg.Name = "sUploadGarminMsg";
			this.sUploadGarminMsg.Size = new System.Drawing.Size(212, 238);
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
			this.pictureBox3.Size = new System.Drawing.Size(240, 38);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 1;
			this.pictureBox3.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel3.Controls.Add(this.pbUploadStatusStrava);
			this.panel3.Controls.Add(this.sUploadStravaId);
			this.panel3.Controls.Add(this.sUploadStravaMsg);
			this.panel3.Controls.Add(this.label16);
			this.panel3.Controls.Add(this.pictureBox2);
			this.panel3.Location = new System.Drawing.Point(266, 15);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(240, 340);
			this.panel3.TabIndex = 6;
			// 
			// pbUploadStatusStrava
			// 
			this.pbUploadStatusStrava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbUploadStatusStrava.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusStrava.Location = new System.Drawing.Point(205, 305);
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
			this.sUploadStravaMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.sUploadStravaMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadStravaMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadStravaMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadStravaMsg.Name = "sUploadStravaMsg";
			this.sUploadStravaMsg.Size = new System.Drawing.Size(212, 238);
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
			this.pictureBox2.Size = new System.Drawing.Size(240, 38);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pnlStatusRunkeeper
			// 
			this.pnlStatusRunkeeper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.pnlStatusRunkeeper.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pnlStatusRunkeeper.Controls.Add(this.pbUploadStatusRunkeeper);
			this.pnlStatusRunkeeper.Controls.Add(this.sUploadRunkeeperId);
			this.pnlStatusRunkeeper.Controls.Add(this.sUploadRunkeeperMsg);
			this.pnlStatusRunkeeper.Controls.Add(this.label15);
			this.pnlStatusRunkeeper.Controls.Add(this.pictureBox1);
			this.pnlStatusRunkeeper.Location = new System.Drawing.Point(22, 15);
			this.pnlStatusRunkeeper.Name = "pnlStatusRunkeeper";
			this.pnlStatusRunkeeper.Size = new System.Drawing.Size(240, 340);
			this.pnlStatusRunkeeper.TabIndex = 4;
			// 
			// pbUploadStatusRunkeeper
			// 
			this.pbUploadStatusRunkeeper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbUploadStatusRunkeeper.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pbUploadStatusRunkeeper.Location = new System.Drawing.Point(205, 305);
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
			this.sUploadRunkeeperMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.sUploadRunkeeperMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sUploadRunkeeperMsg.ForeColor = System.Drawing.Color.Black;
			this.sUploadRunkeeperMsg.Location = new System.Drawing.Point(5, 64);
			this.sUploadRunkeeperMsg.Name = "sUploadRunkeeperMsg";
			this.sUploadRunkeeperMsg.Size = new System.Drawing.Size(212, 238);
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
			this.pictureBox1.Size = new System.Drawing.Size(240, 38);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtDebug);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1016, 389);
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
			this.txtDebug.Size = new System.Drawing.Size(1010, 383);
			this.txtDebug.TabIndex = 0;
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
									this.toolsToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.menubar.Location = new System.Drawing.Point(0, 0);
			this.menubar.Name = "menubar";
			this.menubar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.menubar.Size = new System.Drawing.Size(1041, 40);
			this.menubar.TabIndex = 25;
			this.menubar.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuOpenFile,
									this.menuOpenBatch,
									this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 36);
			this.toolStripMenuItem1.Text = "File";
			// 
			// menuOpenFile
			// 
			this.menuOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenFile.Image")));
			this.menuOpenFile.Name = "menuOpenFile";
			this.menuOpenFile.Size = new System.Drawing.Size(145, 22);
			this.menuOpenFile.Text = "Open...";
			this.menuOpenFile.Click += new System.EventHandler(this.BtnOpenFileClick);
			// 
			// menuOpenBatch
			// 
			this.menuOpenBatch.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenBatch.Image")));
			this.menuOpenBatch.Name = "menuOpenBatch";
			this.menuOpenBatch.Size = new System.Drawing.Size(145, 22);
			this.menuOpenBatch.Text = "Open Batch...";
			this.menuOpenBatch.Click += new System.EventHandler(this.MenuOpenBatchClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
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
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuToolsOptions});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 36);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// menuToolsOptions
			// 
			this.menuToolsOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuToolsOptions.Image")));
			this.menuToolsOptions.Name = "menuToolsOptions";
			this.menuToolsOptions.Size = new System.Drawing.Size(125, 22);
			this.menuToolsOptions.Text = "Options...";
			this.menuToolsOptions.Click += new System.EventHandler(this.MenuToolsOptionsClick);
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
			this.menuAbout.Size = new System.Drawing.Size(107, 22);
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
			this.statusBar.Location = new System.Drawing.Point(0, 680);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(1041, 22);
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
			this.statusbarStatus.Size = new System.Drawing.Size(924, 17);
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
			this.grpProviders.Location = new System.Drawing.Point(810, 51);
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
			this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
			this.cbkProviderEndomondo.Enabled = false;
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
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "endomondo32.png");
			this.imageList1.Images.SetKeyName(1, "facebook32.png");
			this.imageList1.Images.SetKeyName(2, "garmin32.png");
			this.imageList1.Images.SetKeyName(3, "ridewithgps32.png");
			this.imageList1.Images.SetKeyName(4, "runkeeper32.png");
			this.imageList1.Images.SetKeyName(5, "strava32.png");
			this.imageList1.Images.SetKeyName(6, "cycle_bike.png");
			this.imageList1.Images.SetKeyName(7, "failure-icon.png");
			this.imageList1.Images.SetKeyName(8, "success-icon.png");
			// 
			// label27
			// 
			this.label27.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label27.ForeColor = System.Drawing.Color.SteelBlue;
			this.label27.Location = new System.Drawing.Point(22, 30);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(126, 23);
			this.label27.TabIndex = 32;
			this.label27.Text = "Longest Ride";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.SteelBlue;
			this.label14.Location = new System.Drawing.Point(22, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(126, 23);
			this.label14.TabIndex = 33;
			this.label14.Text = "Fastest Avg. Speed";
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.ForeColor = System.Drawing.Color.SteelBlue;
			this.label28.Location = new System.Drawing.Point(22, 98);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(162, 23);
			this.label28.TabIndex = 34;
			this.label28.Text = "Most Climbing";
			// 
			// recMostClimbing
			// 
			this.recMostClimbing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.recMostClimbing.ForeColor = System.Drawing.Color.DimGray;
			this.recMostClimbing.Location = new System.Drawing.Point(172, 98);
			this.recMostClimbing.Name = "recMostClimbing";
			this.recMostClimbing.Size = new System.Drawing.Size(613, 23);
			this.recMostClimbing.TabIndex = 38;
			// 
			// recAverageSpeed
			// 
			this.recAverageSpeed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.recAverageSpeed.ForeColor = System.Drawing.Color.DimGray;
			this.recAverageSpeed.Location = new System.Drawing.Point(172, 64);
			this.recAverageSpeed.Name = "recAverageSpeed";
			this.recAverageSpeed.Size = new System.Drawing.Size(613, 23);
			this.recAverageSpeed.TabIndex = 37;
			// 
			// recLongestRide
			// 
			this.recLongestRide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.recLongestRide.ForeColor = System.Drawing.Color.DimGray;
			this.recLongestRide.Location = new System.Drawing.Point(172, 30);
			this.recLongestRide.Name = "recLongestRide";
			this.recLongestRide.Size = new System.Drawing.Size(613, 23);
			this.recLongestRide.TabIndex = 36;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1041, 702);
			this.Controls.Add(this.grpSummary);
			this.Controls.Add(this.grpProviders);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.tabControlOverview);
			this.Controls.Add(this.menubar);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1057, 740);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cycling Activity File Uploader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.grpSummary.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.pnlNoFile.ResumeLayout(false);
			this.tabControlOverview.ResumeLayout(false);
			this.tabFileHistory.ResumeLayout(false);
			this.tabControlHistory.ResumeLayout(false);
			this.tabFiles.ResumeLayout(false);
			this.tabHistorySummary.ResumeLayout(false);
			this.tabHistorySummary.PerformLayout();
			this.pnlHistoryUploadRideWithGPS.ResumeLayout(false);
			this.pnlHistoryUploadRideWithGPS.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
			this.pnlHistoryUploadRunkeeper.ResumeLayout(false);
			this.pnlHistoryUploadRunkeeper.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
			this.pnlHistoryUploadStrava.ResumeLayout(false);
			this.pnlHistoryUploadStrava.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
			this.pnlHistoryUploadGarmin.ResumeLayout(false);
			this.pnlHistoryUploadGarmin.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
			this.tabHistoryMap.ResumeLayout(false);
			this.tabHistoryMap.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.tabPageMonthlyStats.ResumeLayout(false);
			this.tabPageRecords.ResumeLayout(false);
			this.tabMap.ResumeLayout(false);
			this.tabMap.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
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
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
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
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label recLongestRide;
		private System.Windows.Forms.Label recAverageSpeed;
		private System.Windows.Forms.Label recMostClimbing;
		private System.Windows.Forms.TabPage tabPageRecords;
		private System.Windows.Forms.ToolStripMenuItem menuToolsOptions;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.CheckBox cbkSummaryIsCommute;
		private System.Windows.Forms.CheckBox cbkSummaryIsStationaryTrainer;
		private System.Windows.Forms.CheckBox cbkSummaryIncludeInStats;
		private System.Windows.Forms.CheckBox cbkIsCommute;
		private System.Windows.Forms.CheckBox cbkIsStationaryTrainer;
		private System.Windows.Forms.ColumnHeader colIsStationaryTrainer;
		private System.Windows.Forms.ColumnHeader colIsCommute;
		private System.Windows.Forms.ToolStripMenuItem menuOpenBatch;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader31;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ListView lstMonthlyStats;
		private System.Windows.Forms.TabPage tabPageMonthlyStats;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colDuration;
		private System.Windows.Forms.ColumnHeader colDistance;
		private ListViewExtended.ListViewExtended listViewExtended1;
		private System.Windows.Forms.TabPage tabFiles;
		private System.Windows.Forms.ColumnHeader colActivityDateTime;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Panel pnlNoFile;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.LinkLabel linkHistoryUploadGarmin;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.CheckBox cbkHistoryUploadStrava;
		private System.Windows.Forms.LinkLabel linkHistoryUploadStrava;
		private System.Windows.Forms.Panel pnlHistoryUploadStrava;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.CheckBox cbkHistoryUploadRunkeeper;
		private System.Windows.Forms.LinkLabel linkHistoryUploadRunkeeper;
		private System.Windows.Forms.Panel pnlHistoryUploadRunkeeper;
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.CheckBox cbkHistoryUploadRideWithGPS;
		private System.Windows.Forms.LinkLabel linkHistoryUploadRideWithGPS;
		private System.Windows.Forms.Panel pnlHistoryUploadRideWithGPS;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.CheckBox cbkHistoryUploadGarmin;
		private System.Windows.Forms.Panel pnlHistoryUploadGarmin;
		private System.Windows.Forms.ColumnHeader colNotes;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtHistoryNotes;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label lblHistoryDuration;
		private System.Windows.Forms.Label lblHistoryDistance;
		private System.Windows.Forms.Label lblHistoryCalories;
		private System.Windows.Forms.Label lblHistoryAvgHeartRate;
		private System.Windows.Forms.Label lblHistoryAvgCadence;
		private System.Windows.Forms.Label lblHistoryName;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label lblHistoryAvgSpeed;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label lblHistoryMovingTime;
		private System.Windows.Forms.Label lblHistoryTotalAscent;
		private System.Windows.Forms.Label lblHistoryTotalDescent;
		private System.Windows.Forms.Label lblHistoryMaxHeartRate;
		private System.Windows.Forms.Label lblHistoryMaxCadence;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblHistoryMaxSpeed;
		private System.Windows.Forms.Button btnFullscreenHistoryMap;
		private System.Windows.Forms.WebBrowser webBrowserHistoryMap;
		private System.Windows.Forms.TabPage tabHistoryMap;
		private System.Windows.Forms.ColumnHeader colActivityFilename;
		private System.Windows.Forms.ColumnHeader colOpenedDateTime;
		private System.Windows.Forms.ColumnHeader colFileId;
		private System.Windows.Forms.TabPage tabHistorySummary;
		private ZedGraph.ZedGraphControl zedHistoryHeart;
		private System.Windows.Forms.TabPage tabPage11;
		private ZedGraph.ZedGraphControl zedHistoryCadence;
		private System.Windows.Forms.TabPage tabPage10;
		private ZedGraph.ZedGraphControl zedHistorySpeed;
		private ZedGraph.ZedGraphControl zedHistoryAltitude;
		private ListViewExtended.ListViewExtended lstFileHistory;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.TabControl tabControlHistory;
		private System.Windows.Forms.TabPage tabFileHistory;
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
		private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
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
