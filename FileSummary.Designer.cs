/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 29/03/2013
 * Time: 11:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class FileSummary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSummary));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Please Wait ...");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Calculating");
			this.tabControlHistory = new System.Windows.Forms.TabControl();
			this.tabHistorySummary = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstMileSplits = new ListViewNF.ListViewNF();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pnlHistoryUploadRideWithGPS = new System.Windows.Forms.Panel();
			this.linkHistoryUploadRideWithGPS = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadRideWithGPS = new System.Windows.Forms.CheckBox();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadGarmin = new System.Windows.Forms.Panel();
			this.linkHistoryUploadGarmin = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadGarmin = new System.Windows.Forms.CheckBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadStrava = new System.Windows.Forms.Panel();
			this.linkHistoryUploadStrava = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadStrava = new System.Windows.Forms.CheckBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pnlHistoryUploadRunkeeper = new System.Windows.Forms.Panel();
			this.linkHistoryUploadRunkeeper = new System.Windows.Forms.LinkLabel();
			this.cbkHistoryUploadRunkeeper = new System.Windows.Forms.CheckBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.cbkSummaryIncludeInStats = new System.Windows.Forms.CheckBox();
			this.cbkSummaryIsStationaryTrainer = new System.Windows.Forms.CheckBox();
			this.cbkSummaryIsCommute = new System.Windows.Forms.CheckBox();
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
			this.webBrowserHistoryMap = new System.Windows.Forms.WebBrowser();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.zedHistoryAltitude = new ZedGraph.ZedGraphControl();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.zedHistorySpeed = new ZedGraph.ZedGraphControl();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.zedHistoryCadence = new ZedGraph.ZedGraphControl();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.lstHeartRateZones = new System.Windows.Forms.ListView();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.zedHistoryHeart = new ZedGraph.ZedGraphControl();
			this.lblHistoryName = new System.Windows.Forms.Label();
			this.lblHistoryDate = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnSaveFit = new System.Windows.Forms.Button();
			this.btnSaveTcx = new System.Windows.Forms.Button();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.tabControlHistory.SuspendLayout();
			this.tabHistorySummary.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.pnlHistoryUploadRideWithGPS.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
			this.pnlHistoryUploadGarmin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
			this.pnlHistoryUploadStrava.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
			this.pnlHistoryUploadRunkeeper.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
			this.tabHistoryMap.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlHistory
			// 
			this.tabControlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlHistory.Controls.Add(this.tabHistorySummary);
			this.tabControlHistory.Controls.Add(this.tabHistoryMap);
			this.tabControlHistory.Controls.Add(this.tabPage8);
			this.tabControlHistory.Controls.Add(this.tabPage9);
			this.tabControlHistory.Controls.Add(this.tabPage10);
			this.tabControlHistory.Controls.Add(this.tabPage11);
			this.tabControlHistory.Location = new System.Drawing.Point(0, 70);
			this.tabControlHistory.Name = "tabControlHistory";
			this.tabControlHistory.SelectedIndex = 0;
			this.tabControlHistory.Size = new System.Drawing.Size(1022, 340);
			this.tabControlHistory.TabIndex = 2;
			// 
			// tabHistorySummary
			// 
			this.tabHistorySummary.Controls.Add(this.groupBox2);
			this.tabHistorySummary.Controls.Add(this.groupBox1);
			this.tabHistorySummary.Controls.Add(this.groupBox4);
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIncludeInStats);
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIsStationaryTrainer);
			this.tabHistorySummary.Controls.Add(this.cbkSummaryIsCommute);
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
			this.tabHistorySummary.Size = new System.Drawing.Size(1014, 314);
			this.tabHistorySummary.TabIndex = 4;
			this.tabHistorySummary.Text = "Summary";
			this.tabHistorySummary.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.lstMileSplits);
			this.groupBox1.Location = new System.Drawing.Point(701, 111);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(305, 193);
			this.groupBox1.TabIndex = 69;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mile Splits";
			// 
			// lstMileSplits
			// 
			this.lstMileSplits.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstMileSplits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader11,
									this.columnHeader12,
									this.columnHeader13});
			this.lstMileSplits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstMileSplits.Location = new System.Drawing.Point(3, 16);
			this.lstMileSplits.Name = "lstMileSplits";
			this.lstMileSplits.Size = new System.Drawing.Size(299, 174);
			this.lstMileSplits.TabIndex = 0;
			this.lstMileSplits.UseCompatibleStateImageBehavior = false;
			this.lstMileSplits.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Mile No.";
			this.columnHeader11.Width = 99;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Speed";
			this.columnHeader12.Width = 113;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Pace";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pnlHistoryUploadRideWithGPS);
			this.groupBox4.Controls.Add(this.pnlHistoryUploadGarmin);
			this.groupBox4.Controls.Add(this.pnlHistoryUploadStrava);
			this.groupBox4.Controls.Add(this.pnlHistoryUploadRunkeeper);
			this.groupBox4.Location = new System.Drawing.Point(524, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(482, 99);
			this.groupBox4.TabIndex = 68;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Upload Status";
			// 
			// pnlHistoryUploadRideWithGPS
			// 
			this.pnlHistoryUploadRideWithGPS.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadRideWithGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.linkHistoryUploadRideWithGPS);
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.cbkHistoryUploadRideWithGPS);
			this.pnlHistoryUploadRideWithGPS.Controls.Add(this.pictureBox13);
			this.pnlHistoryUploadRideWithGPS.Enabled = false;
			this.pnlHistoryUploadRideWithGPS.Location = new System.Drawing.Point(329, 21);
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
			// pnlHistoryUploadGarmin
			// 
			this.pnlHistoryUploadGarmin.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadGarmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadGarmin.Controls.Add(this.linkHistoryUploadGarmin);
			this.pnlHistoryUploadGarmin.Controls.Add(this.cbkHistoryUploadGarmin);
			this.pnlHistoryUploadGarmin.Controls.Add(this.pictureBox10);
			this.pnlHistoryUploadGarmin.Enabled = false;
			this.pnlHistoryUploadGarmin.Location = new System.Drawing.Point(223, 21);
			this.pnlHistoryUploadGarmin.Name = "pnlHistoryUploadGarmin";
			this.pnlHistoryUploadGarmin.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadGarmin.Size = new System.Drawing.Size(105, 60);
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
			// pnlHistoryUploadStrava
			// 
			this.pnlHistoryUploadStrava.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadStrava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadStrava.Controls.Add(this.linkHistoryUploadStrava);
			this.pnlHistoryUploadStrava.Controls.Add(this.cbkHistoryUploadStrava);
			this.pnlHistoryUploadStrava.Controls.Add(this.pictureBox11);
			this.pnlHistoryUploadStrava.Enabled = false;
			this.pnlHistoryUploadStrava.Location = new System.Drawing.Point(117, 21);
			this.pnlHistoryUploadStrava.Name = "pnlHistoryUploadStrava";
			this.pnlHistoryUploadStrava.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadStrava.Size = new System.Drawing.Size(105, 60);
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
			// pnlHistoryUploadRunkeeper
			// 
			this.pnlHistoryUploadRunkeeper.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlHistoryUploadRunkeeper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.linkHistoryUploadRunkeeper);
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.cbkHistoryUploadRunkeeper);
			this.pnlHistoryUploadRunkeeper.Controls.Add(this.pictureBox12);
			this.pnlHistoryUploadRunkeeper.Enabled = false;
			this.pnlHistoryUploadRunkeeper.Location = new System.Drawing.Point(11, 21);
			this.pnlHistoryUploadRunkeeper.Name = "pnlHistoryUploadRunkeeper";
			this.pnlHistoryUploadRunkeeper.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHistoryUploadRunkeeper.Size = new System.Drawing.Size(105, 60);
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
			// cbkSummaryIncludeInStats
			// 
			this.cbkSummaryIncludeInStats.Enabled = false;
			this.cbkSummaryIncludeInStats.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbkSummaryIncludeInStats.ForeColor = System.Drawing.Color.SteelBlue;
			this.cbkSummaryIncludeInStats.Location = new System.Drawing.Point(535, 170);
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
			this.cbkSummaryIsStationaryTrainer.Location = new System.Drawing.Point(535, 147);
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
			this.cbkSummaryIsCommute.Location = new System.Drawing.Point(535, 124);
			this.cbkSummaryIsCommute.Name = "cbkSummaryIsCommute";
			this.cbkSummaryIsCommute.Size = new System.Drawing.Size(104, 24);
			this.cbkSummaryIsCommute.TabIndex = 65;
			this.cbkSummaryIsCommute.Text = "Commute";
			this.cbkSummaryIsCommute.UseVisualStyleBackColor = true;
			// 
			// txtHistoryNotes
			// 
			this.txtHistoryNotes.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHistoryNotes.Location = new System.Drawing.Point(110, 155);
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
			this.label6.Location = new System.Drawing.Point(15, 154);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 19);
			this.label6.TabIndex = 56;
			this.label6.Text = "Notes";
			// 
			// lblHistoryMaxSpeed
			// 
			this.lblHistoryMaxSpeed.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxSpeed.Location = new System.Drawing.Point(333, 129);
			this.lblHistoryMaxSpeed.Name = "lblHistoryMaxSpeed";
			this.lblHistoryMaxSpeed.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxSpeed.TabIndex = 55;
			this.lblHistoryMaxSpeed.Text = "-";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.SteelBlue;
			this.label9.Location = new System.Drawing.Point(238, 129);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(89, 19);
			this.label9.TabIndex = 54;
			this.label9.Text = "Max Speed";
			// 
			// lblHistoryMaxCadence
			// 
			this.lblHistoryMaxCadence.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxCadence.Location = new System.Drawing.Point(333, 105);
			this.lblHistoryMaxCadence.Name = "lblHistoryMaxCadence";
			this.lblHistoryMaxCadence.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxCadence.TabIndex = 53;
			this.lblHistoryMaxCadence.Text = "-";
			// 
			// lblHistoryMaxHeartRate
			// 
			this.lblHistoryMaxHeartRate.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMaxHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMaxHeartRate.Location = new System.Drawing.Point(333, 82);
			this.lblHistoryMaxHeartRate.Name = "lblHistoryMaxHeartRate";
			this.lblHistoryMaxHeartRate.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMaxHeartRate.TabIndex = 52;
			this.lblHistoryMaxHeartRate.Text = "-";
			// 
			// lblHistoryTotalDescent
			// 
			this.lblHistoryTotalDescent.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryTotalDescent.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryTotalDescent.Location = new System.Drawing.Point(333, 59);
			this.lblHistoryTotalDescent.Name = "lblHistoryTotalDescent";
			this.lblHistoryTotalDescent.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryTotalDescent.TabIndex = 51;
			this.lblHistoryTotalDescent.Text = "-";
			// 
			// lblHistoryTotalAscent
			// 
			this.lblHistoryTotalAscent.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryTotalAscent.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryTotalAscent.Location = new System.Drawing.Point(333, 37);
			this.lblHistoryTotalAscent.Name = "lblHistoryTotalAscent";
			this.lblHistoryTotalAscent.Size = new System.Drawing.Size(117, 15);
			this.lblHistoryTotalAscent.TabIndex = 50;
			this.lblHistoryTotalAscent.Text = "-";
			// 
			// lblHistoryMovingTime
			// 
			this.lblHistoryMovingTime.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryMovingTime.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryMovingTime.Location = new System.Drawing.Point(333, 13);
			this.lblHistoryMovingTime.Name = "lblHistoryMovingTime";
			this.lblHistoryMovingTime.Size = new System.Drawing.Size(117, 23);
			this.lblHistoryMovingTime.TabIndex = 49;
			this.lblHistoryMovingTime.Text = "-";
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.ForeColor = System.Drawing.Color.SteelBlue;
			this.label30.Location = new System.Drawing.Point(238, 105);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(82, 19);
			this.label30.TabIndex = 48;
			this.label30.Text = "Max Cadence";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.ForeColor = System.Drawing.Color.SteelBlue;
			this.label31.Location = new System.Drawing.Point(238, 82);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(89, 23);
			this.label31.TabIndex = 47;
			this.label31.Text = "Max Heart Rate";
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.ForeColor = System.Drawing.Color.SteelBlue;
			this.label32.Location = new System.Drawing.Point(238, 59);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(89, 23);
			this.label32.TabIndex = 46;
			this.label32.Text = "Total Descent";
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.SteelBlue;
			this.label33.Location = new System.Drawing.Point(238, 37);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(89, 15);
			this.label33.TabIndex = 45;
			this.label33.Text = "Total Ascent";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label34.ForeColor = System.Drawing.Color.SteelBlue;
			this.label34.Location = new System.Drawing.Point(238, 14);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(89, 22);
			this.label34.TabIndex = 44;
			this.label34.Text = "Moving Time";
			// 
			// lblHistoryAvgSpeed
			// 
			this.lblHistoryAvgSpeed.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgSpeed.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgSpeed.Location = new System.Drawing.Point(110, 130);
			this.lblHistoryAvgSpeed.Name = "lblHistoryAvgSpeed";
			this.lblHistoryAvgSpeed.Size = new System.Drawing.Size(122, 19);
			this.lblHistoryAvgSpeed.TabIndex = 43;
			this.lblHistoryAvgSpeed.Text = "-";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label36.ForeColor = System.Drawing.Color.SteelBlue;
			this.label36.Location = new System.Drawing.Point(15, 130);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(89, 19);
			this.label36.TabIndex = 42;
			this.label36.Text = "Avg. Speed";
			// 
			// lblHistoryAvgCadence
			// 
			this.lblHistoryAvgCadence.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgCadence.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgCadence.Location = new System.Drawing.Point(110, 106);
			this.lblHistoryAvgCadence.Name = "lblHistoryAvgCadence";
			this.lblHistoryAvgCadence.Size = new System.Drawing.Size(122, 19);
			this.lblHistoryAvgCadence.TabIndex = 39;
			this.lblHistoryAvgCadence.Text = "-";
			// 
			// lblHistoryAvgHeartRate
			// 
			this.lblHistoryAvgHeartRate.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryAvgHeartRate.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryAvgHeartRate.Location = new System.Drawing.Point(110, 83);
			this.lblHistoryAvgHeartRate.Name = "lblHistoryAvgHeartRate";
			this.lblHistoryAvgHeartRate.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryAvgHeartRate.TabIndex = 38;
			this.lblHistoryAvgHeartRate.Text = "-";
			// 
			// lblHistoryCalories
			// 
			this.lblHistoryCalories.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryCalories.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryCalories.Location = new System.Drawing.Point(110, 60);
			this.lblHistoryCalories.Name = "lblHistoryCalories";
			this.lblHistoryCalories.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryCalories.TabIndex = 37;
			this.lblHistoryCalories.Text = "-";
			// 
			// lblHistoryDistance
			// 
			this.lblHistoryDistance.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryDistance.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryDistance.Location = new System.Drawing.Point(110, 37);
			this.lblHistoryDistance.Name = "lblHistoryDistance";
			this.lblHistoryDistance.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryDistance.TabIndex = 36;
			this.lblHistoryDistance.Text = "-";
			// 
			// lblHistoryDuration
			// 
			this.lblHistoryDuration.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryDuration.ForeColor = System.Drawing.Color.Gray;
			this.lblHistoryDuration.Location = new System.Drawing.Point(110, 14);
			this.lblHistoryDuration.Name = "lblHistoryDuration";
			this.lblHistoryDuration.Size = new System.Drawing.Size(122, 23);
			this.lblHistoryDuration.TabIndex = 35;
			this.lblHistoryDuration.Text = "-";
			// 
			// label44
			// 
			this.label44.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label44.ForeColor = System.Drawing.Color.SteelBlue;
			this.label44.Location = new System.Drawing.Point(15, 106);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(99, 19);
			this.label44.TabIndex = 34;
			this.label44.Text = "Avg. Cadence";
			// 
			// label45
			// 
			this.label45.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label45.ForeColor = System.Drawing.Color.SteelBlue;
			this.label45.Location = new System.Drawing.Point(15, 83);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(89, 23);
			this.label45.TabIndex = 33;
			this.label45.Text = "Avg. Heart Rate";
			// 
			// label46
			// 
			this.label46.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label46.ForeColor = System.Drawing.Color.SteelBlue;
			this.label46.Location = new System.Drawing.Point(15, 60);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(89, 23);
			this.label46.TabIndex = 32;
			this.label46.Text = "Calories";
			// 
			// label47
			// 
			this.label47.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label47.ForeColor = System.Drawing.Color.SteelBlue;
			this.label47.Location = new System.Drawing.Point(15, 37);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(89, 23);
			this.label47.TabIndex = 31;
			this.label47.Text = "Distance";
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label48.ForeColor = System.Drawing.Color.SteelBlue;
			this.label48.Location = new System.Drawing.Point(15, 14);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(89, 23);
			this.label48.TabIndex = 30;
			this.label48.Text = "Duration";
			// 
			// tabHistoryMap
			// 
			this.tabHistoryMap.Controls.Add(this.webBrowserHistoryMap);
			this.tabHistoryMap.Location = new System.Drawing.Point(4, 22);
			this.tabHistoryMap.Name = "tabHistoryMap";
			this.tabHistoryMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabHistoryMap.Size = new System.Drawing.Size(1014, 314);
			this.tabHistoryMap.TabIndex = 5;
			this.tabHistoryMap.Text = "Map";
			this.tabHistoryMap.UseVisualStyleBackColor = true;
			// 
			// webBrowserHistoryMap
			// 
			this.webBrowserHistoryMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowserHistoryMap.Location = new System.Drawing.Point(3, 3);
			this.webBrowserHistoryMap.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowserHistoryMap.Name = "webBrowserHistoryMap";
			this.webBrowserHistoryMap.ScrollBarsEnabled = false;
			this.webBrowserHistoryMap.Size = new System.Drawing.Size(1008, 308);
			this.webBrowserHistoryMap.TabIndex = 1;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.zedHistoryAltitude);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new System.Drawing.Size(1014, 314);
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
			this.zedHistoryAltitude.Size = new System.Drawing.Size(1008, 308);
			this.zedHistoryAltitude.TabIndex = 0;
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.zedHistorySpeed);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(1014, 314);
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
			this.zedHistorySpeed.Size = new System.Drawing.Size(1008, 308);
			this.zedHistorySpeed.TabIndex = 1;
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.zedHistoryCadence);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(1014, 314);
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
			this.zedHistoryCadence.Size = new System.Drawing.Size(1008, 308);
			this.zedHistoryCadence.TabIndex = 1;
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.lstHeartRateZones);
			this.tabPage11.Controls.Add(this.zedHistoryHeart);
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new System.Drawing.Size(1014, 314);
			this.tabPage11.TabIndex = 3;
			this.tabPage11.Text = "Heart Rate";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// lstHeartRateZones
			// 
			this.lstHeartRateZones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lstHeartRateZones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader14,
									this.columnHeader15,
									this.columnHeader16});
			this.lstHeartRateZones.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstHeartRateZones.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
									listViewItem1,
									listViewItem2});
			this.lstHeartRateZones.Location = new System.Drawing.Point(781, 3);
			this.lstHeartRateZones.Name = "lstHeartRateZones";
			this.lstHeartRateZones.Size = new System.Drawing.Size(230, 162);
			this.lstHeartRateZones.TabIndex = 2;
			this.lstHeartRateZones.UseCompatibleStateImageBehavior = false;
			this.lstHeartRateZones.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Zone";
			this.columnHeader14.Width = 78;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Duration";
			this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "%";
			this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// zedHistoryHeart
			// 
			this.zedHistoryHeart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
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
			this.zedHistoryHeart.Size = new System.Drawing.Size(772, 308);
			this.zedHistoryHeart.TabIndex = 1;
			// 
			// lblHistoryName
			// 
			this.lblHistoryName.BackColor = System.Drawing.Color.Gainsboro;
			this.lblHistoryName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblHistoryName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryName.ForeColor = System.Drawing.Color.DimGray;
			this.lblHistoryName.Location = new System.Drawing.Point(0, 0);
			this.lblHistoryName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.lblHistoryName.Name = "lblHistoryName";
			this.lblHistoryName.Padding = new System.Windows.Forms.Padding(5);
			this.lblHistoryName.Size = new System.Drawing.Size(1022, 35);
			this.lblHistoryName.TabIndex = 0;
			// 
			// lblHistoryDate
			// 
			this.lblHistoryDate.BackColor = System.Drawing.Color.Gainsboro;
			this.lblHistoryDate.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblHistoryDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistoryDate.ForeColor = System.Drawing.Color.DimGray;
			this.lblHistoryDate.Location = new System.Drawing.Point(0, 35);
			this.lblHistoryDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.lblHistoryDate.Name = "lblHistoryDate";
			this.lblHistoryDate.Padding = new System.Windows.Forms.Padding(5);
			this.lblHistoryDate.Size = new System.Drawing.Size(1022, 22);
			this.lblHistoryDate.TabIndex = 1;
			this.lblHistoryDate.Text = " ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnSaveTcx);
			this.groupBox2.Controls.Add(this.btnSaveFit);
			this.groupBox2.Location = new System.Drawing.Point(524, 220);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(146, 57);
			this.groupBox2.TabIndex = 70;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Downloads";
			// 
			// btnSaveFit
			// 
			this.btnSaveFit.Location = new System.Drawing.Point(6, 28);
			this.btnSaveFit.Name = "btnSaveFit";
			this.btnSaveFit.Size = new System.Drawing.Size(62, 23);
			this.btnSaveFit.TabIndex = 0;
			this.btnSaveFit.Text = ".FIT";
			this.btnSaveFit.UseVisualStyleBackColor = true;
			this.btnSaveFit.Click += new System.EventHandler(this.BtnSaveFitClick);
			// 
			// btnSaveTcx
			// 
			this.btnSaveTcx.Location = new System.Drawing.Point(78, 28);
			this.btnSaveTcx.Name = "btnSaveTcx";
			this.btnSaveTcx.Size = new System.Drawing.Size(62, 23);
			this.btnSaveTcx.TabIndex = 1;
			this.btnSaveTcx.Text = ".TCX";
			this.btnSaveTcx.UseVisualStyleBackColor = true;
			// 
			// FileSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1022, 412);
			this.Controls.Add(this.lblHistoryDate);
			this.Controls.Add(this.tabControlHistory);
			this.Controls.Add(this.lblHistoryName);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1038, 450);
			this.Name = "FileSummary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File History : Activity Summary";
			this.Shown += new System.EventHandler(this.FileSummaryShown);
			this.tabControlHistory.ResumeLayout(false);
			this.tabHistorySummary.ResumeLayout(false);
			this.tabHistorySummary.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.pnlHistoryUploadRideWithGPS.ResumeLayout(false);
			this.pnlHistoryUploadRideWithGPS.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
			this.pnlHistoryUploadGarmin.ResumeLayout(false);
			this.pnlHistoryUploadGarmin.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
			this.pnlHistoryUploadStrava.ResumeLayout(false);
			this.pnlHistoryUploadStrava.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
			this.pnlHistoryUploadRunkeeper.ResumeLayout(false);
			this.pnlHistoryUploadRunkeeper.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
			this.tabHistoryMap.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.Button btnSaveFit;
		private System.Windows.Forms.Button btnSaveTcx;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblHistoryDate;
		private ZedGraph.ZedGraphControl zedHistoryHeart;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ListView lstHeartRateZones;
		private System.Windows.Forms.TabPage tabPage11;
		private ZedGraph.ZedGraphControl zedHistoryCadence;
		private System.Windows.Forms.TabPage tabPage10;
		private ZedGraph.ZedGraphControl zedHistorySpeed;
		private System.Windows.Forms.TabPage tabPage9;
		private ZedGraph.ZedGraphControl zedHistoryAltitude;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.WebBrowser webBrowserHistoryMap;
		private System.Windows.Forms.TabPage tabHistoryMap;
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
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtHistoryNotes;
		private System.Windows.Forms.CheckBox cbkSummaryIsCommute;
		private System.Windows.Forms.CheckBox cbkSummaryIsStationaryTrainer;
		private System.Windows.Forms.CheckBox cbkSummaryIncludeInStats;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.CheckBox cbkHistoryUploadRunkeeper;
		private System.Windows.Forms.LinkLabel linkHistoryUploadRunkeeper;
		private System.Windows.Forms.Panel pnlHistoryUploadRunkeeper;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.CheckBox cbkHistoryUploadStrava;
		private System.Windows.Forms.LinkLabel linkHistoryUploadStrava;
		private System.Windows.Forms.Panel pnlHistoryUploadStrava;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.CheckBox cbkHistoryUploadGarmin;
		private System.Windows.Forms.LinkLabel linkHistoryUploadGarmin;
		private System.Windows.Forms.Panel pnlHistoryUploadGarmin;
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.CheckBox cbkHistoryUploadRideWithGPS;
		private System.Windows.Forms.LinkLabel linkHistoryUploadRideWithGPS;
		private System.Windows.Forms.Panel pnlHistoryUploadRideWithGPS;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private ListViewNF.ListViewNF lstMileSplits;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabHistorySummary;
		private System.Windows.Forms.TabControl tabControlHistory;
	}
}
