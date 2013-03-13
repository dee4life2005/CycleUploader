/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 11/03/2013
 * Time: 20:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class ViewerRideWithGps
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerRideWithGps));
			this.label15 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlActivities = new System.Windows.Forms.GroupBox();
			this.lstActivities = new System.Windows.Forms.ListView();
			this.colActivityId = new System.Windows.Forms.ColumnHeader();
			this.colStartTime = new System.Windows.Forms.ColumnHeader();
			this.colActivityName = new System.Windows.Forms.ColumnHeader();
			this.colLocationString = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colMovingTime = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colElevationGain = new System.Windows.Forms.ColumnHeader();
			this.colCreatedAt = new System.Windows.Forms.ColumnHeader();
			this.pnlProfile = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblMemberSince = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblTotalElevation = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblTotalDuration = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotalDistance = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDOB = new System.Windows.Forms.Label();
			this.lblProfileCity = new System.Windows.Forms.Label();
			this.lblProfileName = new System.Windows.Forms.Label();
			this.lblTotalActivities = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tabChart = new System.Windows.Forms.TabControl();
			this.tabSummary = new System.Windows.Forms.TabPage();
			this.lblMovingTime = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lblAvgCadence = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lstSplits = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lblTotalAscent = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lblAvgSpeed = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblActivityDateTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblAvgHeartRate = new System.Windows.Forms.Label();
			this.lblDistance = new System.Windows.Forms.Label();
			this.lblDuration = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.tabCharts = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbkChartHeart = new System.Windows.Forms.CheckBox();
			this.cbkChartCadence = new System.Windows.Forms.CheckBox();
			this.cbkChartSpeed = new System.Windows.Forms.CheckBox();
			this.zedActivityChart = new ZedGraph.ZedGraphControl();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusBarStatus = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pnlActivities.SuspendLayout();
			this.pnlProfile.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabChart.SuspendLayout();
			this.tabSummary.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabCharts.SuspendLayout();
			this.panel1.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(153, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 23);
			this.label15.TabIndex = 25;
			this.label15.Text = "Profile";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(139, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 24;
			this.pictureBox1.TabStop = false;
			// 
			// pnlActivities
			// 
			this.pnlActivities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlActivities.Controls.Add(this.lstActivities);
			this.pnlActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlActivities.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlActivities.Location = new System.Drawing.Point(12, 177);
			this.pnlActivities.Name = "pnlActivities";
			this.pnlActivities.Padding = new System.Windows.Forms.Padding(5);
			this.pnlActivities.Size = new System.Drawing.Size(864, 190);
			this.pnlActivities.TabIndex = 26;
			this.pnlActivities.TabStop = false;
			this.pnlActivities.Text = "Activities";
			// 
			// lstActivities
			// 
			this.lstActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colActivityId,
									this.colStartTime,
									this.colActivityName,
									this.colLocationString,
									this.colDistance,
									this.colMovingTime,
									this.colAvgSpeed,
									this.colElevationGain,
									this.colCreatedAt});
			this.lstActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstActivities.FullRowSelect = true;
			this.lstActivities.GridLines = true;
			this.lstActivities.HideSelection = false;
			this.lstActivities.Location = new System.Drawing.Point(5, 18);
			this.lstActivities.Name = "lstActivities";
			this.lstActivities.Size = new System.Drawing.Size(854, 167);
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
			this.colStartTime.Width = 75;
			// 
			// colActivityName
			// 
			this.colActivityName.Text = "Activity Name";
			this.colActivityName.Width = 101;
			// 
			// colLocationString
			// 
			this.colLocationString.Text = "Location";
			// 
			// colDistance
			// 
			this.colDistance.Text = "Distance";
			// 
			// colMovingTime
			// 
			this.colMovingTime.Text = "Duration";
			// 
			// colAvgSpeed
			// 
			this.colAvgSpeed.Text = "Avg. Speed";
			// 
			// colElevationGain
			// 
			this.colElevationGain.Text = "Altitude";
			// 
			// colCreatedAt
			// 
			this.colCreatedAt.Text = "Date Created";
			// 
			// pnlProfile
			// 
			this.pnlProfile.Controls.Add(this.label3);
			this.pnlProfile.Controls.Add(this.lblMemberSince);
			this.pnlProfile.Controls.Add(this.label6);
			this.pnlProfile.Controls.Add(this.lblTotalElevation);
			this.pnlProfile.Controls.Add(this.label4);
			this.pnlProfile.Controls.Add(this.lblTotalDuration);
			this.pnlProfile.Controls.Add(this.label2);
			this.pnlProfile.Controls.Add(this.lblTotalDistance);
			this.pnlProfile.Controls.Add(this.label1);
			this.pnlProfile.Controls.Add(this.lblDOB);
			this.pnlProfile.Controls.Add(this.lblProfileCity);
			this.pnlProfile.Controls.Add(this.lblProfileName);
			this.pnlProfile.Controls.Add(this.lblTotalActivities);
			this.pnlProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlProfile.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlProfile.Location = new System.Drawing.Point(15, 40);
			this.pnlProfile.Name = "pnlProfile";
			this.pnlProfile.Size = new System.Drawing.Size(861, 131);
			this.pnlProfile.TabIndex = 27;
			this.pnlProfile.TabStop = false;
			this.pnlProfile.Text = "Profile";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SteelBlue;
			this.label3.Location = new System.Drawing.Point(6, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 26;
			this.label3.Text = "Member Since";
			// 
			// lblMemberSince
			// 
			this.lblMemberSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMemberSince.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMemberSince.Location = new System.Drawing.Point(6, 108);
			this.lblMemberSince.Name = "lblMemberSince";
			this.lblMemberSince.Size = new System.Drawing.Size(113, 13);
			this.lblMemberSince.TabIndex = 25;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.SteelBlue;
			this.label6.Location = new System.Drawing.Point(289, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 24;
			this.label6.Text = "Total Elevation";
			// 
			// lblTotalElevation
			// 
			this.lblTotalElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalElevation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalElevation.Location = new System.Drawing.Point(395, 86);
			this.lblTotalElevation.Name = "lblTotalElevation";
			this.lblTotalElevation.Size = new System.Drawing.Size(113, 13);
			this.lblTotalElevation.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(289, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Total Duration";
			// 
			// lblTotalDuration
			// 
			this.lblTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDuration.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalDuration.Location = new System.Drawing.Point(395, 60);
			this.lblTotalDuration.Name = "lblTotalDuration";
			this.lblTotalDuration.Size = new System.Drawing.Size(113, 13);
			this.lblTotalDuration.TabIndex = 21;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SteelBlue;
			this.label2.Location = new System.Drawing.Point(289, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Total Distance";
			// 
			// lblTotalDistance
			// 
			this.lblTotalDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDistance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalDistance.Location = new System.Drawing.Point(395, 34);
			this.lblTotalDistance.Name = "lblTotalDistance";
			this.lblTotalDistance.Size = new System.Drawing.Size(113, 13);
			this.lblTotalDistance.TabIndex = 19;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(6, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "DOB";
			// 
			// lblDOB
			// 
			this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDOB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDOB.Location = new System.Drawing.Point(6, 71);
			this.lblDOB.Name = "lblDOB";
			this.lblDOB.Size = new System.Drawing.Size(113, 13);
			this.lblDOB.TabIndex = 17;
			// 
			// lblProfileCity
			// 
			this.lblProfileCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProfileCity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblProfileCity.Location = new System.Drawing.Point(6, 32);
			this.lblProfileCity.Name = "lblProfileCity";
			this.lblProfileCity.Size = new System.Drawing.Size(237, 15);
			this.lblProfileCity.TabIndex = 16;
			// 
			// lblProfileName
			// 
			this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProfileName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblProfileName.Location = new System.Drawing.Point(6, 16);
			this.lblProfileName.Name = "lblProfileName";
			this.lblProfileName.Size = new System.Drawing.Size(264, 23);
			this.lblProfileName.TabIndex = 14;
			// 
			// lblTotalActivities
			// 
			this.lblTotalActivities.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTotalActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalActivities.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalActivities.Location = new System.Drawing.Point(656, 34);
			this.lblTotalActivities.Name = "lblTotalActivities";
			this.lblTotalActivities.Size = new System.Drawing.Size(79, 63);
			this.lblTotalActivities.TabIndex = 15;
			this.lblTotalActivities.Text = "0 Activities";
			this.lblTotalActivities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.tabChart);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.groupBox4.Location = new System.Drawing.Point(15, 373);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(861, 365);
			this.groupBox4.TabIndex = 28;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Activity Details";
			// 
			// tabChart
			// 
			this.tabChart.Controls.Add(this.tabSummary);
			this.tabChart.Controls.Add(this.tabMap);
			this.tabChart.Controls.Add(this.tabCharts);
			this.tabChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabChart.Location = new System.Drawing.Point(3, 16);
			this.tabChart.Margin = new System.Windows.Forms.Padding(0);
			this.tabChart.Name = "tabChart";
			this.tabChart.Padding = new System.Drawing.Point(0, 0);
			this.tabChart.SelectedIndex = 0;
			this.tabChart.Size = new System.Drawing.Size(855, 346);
			this.tabChart.TabIndex = 1;
			// 
			// tabSummary
			// 
			this.tabSummary.BackColor = System.Drawing.SystemColors.Control;
			this.tabSummary.Controls.Add(this.lblMovingTime);
			this.tabSummary.Controls.Add(this.label17);
			this.tabSummary.Controls.Add(this.lblAvgCadence);
			this.tabSummary.Controls.Add(this.label16);
			this.tabSummary.Controls.Add(this.label12);
			this.tabSummary.Controls.Add(this.lstSplits);
			this.tabSummary.Controls.Add(this.txtNotes);
			this.tabSummary.Controls.Add(this.label5);
			this.tabSummary.Controls.Add(this.lblTotalAscent);
			this.tabSummary.Controls.Add(this.label22);
			this.tabSummary.Controls.Add(this.lblAvgSpeed);
			this.tabSummary.Controls.Add(this.label8);
			this.tabSummary.Controls.Add(this.lblActivityDateTime);
			this.tabSummary.Controls.Add(this.label7);
			this.tabSummary.Controls.Add(this.lblAvgHeartRate);
			this.tabSummary.Controls.Add(this.lblDistance);
			this.tabSummary.Controls.Add(this.lblDuration);
			this.tabSummary.Controls.Add(this.label9);
			this.tabSummary.Controls.Add(this.label11);
			this.tabSummary.Controls.Add(this.label13);
			this.tabSummary.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tabSummary.Location = new System.Drawing.Point(4, 22);
			this.tabSummary.Name = "tabSummary";
			this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tabSummary.Size = new System.Drawing.Size(847, 320);
			this.tabSummary.TabIndex = 0;
			this.tabSummary.Text = "Activity Summary";
			// 
			// lblMovingTime
			// 
			this.lblMovingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMovingTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMovingTime.Location = new System.Drawing.Point(415, 107);
			this.lblMovingTime.Name = "lblMovingTime";
			this.lblMovingTime.Size = new System.Drawing.Size(119, 23);
			this.lblMovingTime.TabIndex = 93;
			this.lblMovingTime.Text = "-";
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.Color.SteelBlue;
			this.label17.Location = new System.Drawing.Point(297, 107);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 92;
			this.label17.Text = "Moving Time";
			// 
			// lblAvgCadence
			// 
			this.lblAvgCadence.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgCadence.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAvgCadence.Location = new System.Drawing.Point(415, 77);
			this.lblAvgCadence.Name = "lblAvgCadence";
			this.lblAvgCadence.Size = new System.Drawing.Size(119, 19);
			this.lblAvgCadence.TabIndex = 91;
			this.lblAvgCadence.Text = "-";
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.Color.SteelBlue;
			this.label16.Location = new System.Drawing.Point(297, 77);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 19);
			this.label16.TabIndex = 90;
			this.label16.Text = "Average Cadence";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
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
			this.lstSplits.Size = new System.Drawing.Size(289, 300);
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
			// txtNotes
			// 
			this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.txtNotes.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtNotes.Location = new System.Drawing.Point(17, 168);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ReadOnly = true;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(511, 146);
			this.txtNotes.TabIndex = 84;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.SteelBlue;
			this.label5.Location = new System.Drawing.Point(17, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 10);
			this.label5.TabIndex = 83;
			this.label5.Text = "Notes";
			// 
			// lblTotalAscent
			// 
			this.lblTotalAscent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAscent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalAscent.Location = new System.Drawing.Point(135, 107);
			this.lblTotalAscent.Name = "lblTotalAscent";
			this.lblTotalAscent.Size = new System.Drawing.Size(132, 23);
			this.lblTotalAscent.TabIndex = 77;
			this.lblTotalAscent.Text = "-";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.SteelBlue;
			this.label22.Location = new System.Drawing.Point(17, 107);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 72;
			this.label22.Text = "Total Ascent";
			// 
			// lblAvgSpeed
			// 
			this.lblAvgSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAvgSpeed.Location = new System.Drawing.Point(415, 17);
			this.lblAvgSpeed.Name = "lblAvgSpeed";
			this.lblAvgSpeed.Size = new System.Drawing.Size(119, 19);
			this.lblAvgSpeed.TabIndex = 69;
			this.lblAvgSpeed.Text = "-";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.SteelBlue;
			this.label8.Location = new System.Drawing.Point(297, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 19);
			this.label8.TabIndex = 68;
			this.label8.Text = "Average Speed";
			// 
			// lblActivityDateTime
			// 
			this.lblActivityDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivityDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
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
			this.lblAvgHeartRate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAvgHeartRate.Location = new System.Drawing.Point(415, 47);
			this.lblAvgHeartRate.Name = "lblAvgHeartRate";
			this.lblAvgHeartRate.Size = new System.Drawing.Size(119, 23);
			this.lblAvgHeartRate.TabIndex = 64;
			this.lblAvgHeartRate.Text = "-";
			// 
			// lblDistance
			// 
			this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDistance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDistance.Location = new System.Drawing.Point(135, 77);
			this.lblDistance.Name = "lblDistance";
			this.lblDistance.Size = new System.Drawing.Size(156, 23);
			this.lblDistance.TabIndex = 62;
			this.lblDistance.Text = "-";
			// 
			// lblDuration
			// 
			this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDuration.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDuration.Location = new System.Drawing.Point(135, 47);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(156, 23);
			this.lblDuration.TabIndex = 61;
			this.lblDuration.Text = "-";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.SteelBlue;
			this.label9.Location = new System.Drawing.Point(297, 47);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(118, 23);
			this.label9.TabIndex = 59;
			this.label9.Text = "Average Heart Rate";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.SteelBlue;
			this.label11.Location = new System.Drawing.Point(17, 77);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 57;
			this.label11.Text = "Distance";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.SteelBlue;
			this.label13.Location = new System.Drawing.Point(17, 47);
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
			this.tabMap.Size = new System.Drawing.Size(847, 320);
			this.tabMap.TabIndex = 2;
			this.tabMap.Text = "Map";
			this.tabMap.UseVisualStyleBackColor = true;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.AutoSize = true;
			this.btnMapFullscreen.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(810, 3);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(34, 314);
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
			this.webBrowser1.Size = new System.Drawing.Size(801, 314);
			this.webBrowser1.TabIndex = 0;
			// 
			// tabCharts
			// 
			this.tabCharts.Controls.Add(this.panel1);
			this.tabCharts.Controls.Add(this.zedActivityChart);
			this.tabCharts.Location = new System.Drawing.Point(4, 22);
			this.tabCharts.Name = "tabCharts";
			this.tabCharts.Size = new System.Drawing.Size(847, 320);
			this.tabCharts.TabIndex = 4;
			this.tabCharts.Text = "Chart";
			this.tabCharts.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.cbkChartHeart);
			this.panel1.Controls.Add(this.cbkChartCadence);
			this.panel1.Controls.Add(this.cbkChartSpeed);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(847, 33);
			this.panel1.TabIndex = 2;
			// 
			// cbkChartHeart
			// 
			this.cbkChartHeart.Checked = true;
			this.cbkChartHeart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkChartHeart.Location = new System.Drawing.Point(275, 4);
			this.cbkChartHeart.Name = "cbkChartHeart";
			this.cbkChartHeart.Size = new System.Drawing.Size(104, 24);
			this.cbkChartHeart.TabIndex = 2;
			this.cbkChartHeart.Text = "Heart-Rate";
			this.cbkChartHeart.UseVisualStyleBackColor = true;
			this.cbkChartHeart.CheckedChanged += new System.EventHandler(this.CbkChartHeartCheckedChanged);
			// 
			// cbkChartCadence
			// 
			this.cbkChartCadence.Checked = true;
			this.cbkChartCadence.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkChartCadence.Location = new System.Drawing.Point(169, 4);
			this.cbkChartCadence.Name = "cbkChartCadence";
			this.cbkChartCadence.Size = new System.Drawing.Size(104, 24);
			this.cbkChartCadence.TabIndex = 1;
			this.cbkChartCadence.Text = "Cadence";
			this.cbkChartCadence.UseVisualStyleBackColor = true;
			this.cbkChartCadence.CheckedChanged += new System.EventHandler(this.CbkChartCadenceCheckedChanged);
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
			this.zedActivityChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.zedActivityChart.IsAntiAlias = true;
			this.zedActivityChart.IsShowPointValues = true;
			this.zedActivityChart.Location = new System.Drawing.Point(0, 32);
			this.zedActivityChart.Name = "zedActivityChart";
			this.zedActivityChart.ScrollGrace = 0D;
			this.zedActivityChart.ScrollMaxX = 0D;
			this.zedActivityChart.ScrollMaxY = 0D;
			this.zedActivityChart.ScrollMaxY2 = 0D;
			this.zedActivityChart.ScrollMinX = 0D;
			this.zedActivityChart.ScrollMinY = 0D;
			this.zedActivityChart.ScrollMinY2 = 0D;
			this.zedActivityChart.Size = new System.Drawing.Size(847, 288);
			this.zedActivityChart.TabIndex = 1;
			// 
			// statusBar
			// 
			this.statusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusBar.BackgroundImage")));
			this.statusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.statusBarProgress,
									this.statusBarStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 741);
			this.statusBar.Name = "statusBar";
			this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusBar.Size = new System.Drawing.Size(888, 22);
			this.statusBar.TabIndex = 29;
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
			this.statusBarStatus.Size = new System.Drawing.Size(740, 17);
			this.statusBarStatus.Spring = true;
			this.statusBarStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ViewerRideWithGps
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 763);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.pnlProfile);
			this.Controls.Add(this.pnlActivities);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(904, 801);
			this.Name = "ViewerRideWithGps";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RideWithGPS Profile";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerRideWithGpsFormClosing);
			this.Shown += new System.EventHandler(this.ViewerRideWithGpsShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pnlActivities.ResumeLayout(false);
			this.pnlProfile.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabChart.ResumeLayout(false);
			this.tabSummary.ResumeLayout(false);
			this.tabSummary.PerformLayout();
			this.tabMap.ResumeLayout(false);
			this.tabMap.PerformLayout();
			this.tabCharts.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
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
		private System.Windows.Forms.CheckBox cbkChartCadence;
		private System.Windows.Forms.CheckBox cbkChartHeart;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label lblMovingTime;
		private System.Windows.Forms.Label label16;
		private ZedGraph.ZedGraphControl zedActivityChart;
		private System.Windows.Forms.TabPage tabCharts;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.TabPage tabMap;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblDistance;
		private System.Windows.Forms.Label lblAvgHeartRate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblActivityDateTime;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblAvgSpeed;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lblTotalAscent;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Label lblAvgCadence;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ListView lstSplits;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabPage tabSummary;
		private System.Windows.Forms.TabControl tabChart;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lblMemberSince;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblDOB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTotalDistance;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotalDuration;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTotalElevation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblProfileCity;
		private System.Windows.Forms.Label lblProfileName;
		private System.Windows.Forms.Label lblTotalActivities;
		private System.Windows.Forms.GroupBox pnlProfile;
		private System.Windows.Forms.ColumnHeader colCreatedAt;
		private System.Windows.Forms.ColumnHeader colElevationGain;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colMovingTime;
		private System.Windows.Forms.ColumnHeader colDistance;
		private System.Windows.Forms.ColumnHeader colLocationString;
		private System.Windows.Forms.ColumnHeader colActivityName;
		private System.Windows.Forms.ColumnHeader colStartTime;
		private System.Windows.Forms.ColumnHeader colActivityId;
		private System.Windows.Forms.ListView lstActivities;
		private System.Windows.Forms.GroupBox pnlActivities;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
	}
}
