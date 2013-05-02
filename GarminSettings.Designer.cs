/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 11/04/2013
 * Time: 09:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class GarminSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GarminSettings));
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.tNoDevice = new System.Windows.Forms.Label();
			this.lineSeparator2 = new CycleUploader.LineSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlRequiresProcessing = new System.Windows.Forms.Panel();
			this.btnProcessNow = new System.Windows.Forms.Button();
			this.tNumToBeProcessed = new System.Windows.Forms.Label();
			this.pbRequiresProcessingIcon = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.lstDeviceActivities = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.colAlreadyProcessed = new System.Windows.Forms.ColumnHeader();
			this.colStartTime = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colTotalTime = new System.Windows.Forms.ColumnHeader();
			this.colMovingTime = new System.Windows.Forms.ColumnHeader();
			this.colTotalAscent = new System.Windows.Forms.ColumnHeader();
			this.colCalories = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colAvgHeart = new System.Windows.Forms.ColumnHeader();
			this.colAvgCadence = new System.Windows.Forms.ColumnHeader();
			this.colMaxSpeed = new System.Windows.Forms.ColumnHeader();
			this.colMaxHeart = new System.Windows.Forms.ColumnHeader();
			this.colMaxCadence = new System.Windows.Forms.ColumnHeader();
			this.colFilePath = new System.Windows.Forms.ColumnHeader();
			this.colDummy = new System.Windows.Forms.ColumnHeader();
			this.pnlLoadingActivities = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.prgReadingActivities = new System.Windows.Forms.ProgressBar();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pbDeviceImage = new System.Windows.Forms.PictureBox();
			this.tNumActivities = new System.Windows.Forms.Label();
			this.tDevice = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tSerialNumber = new System.Windows.Forms.Label();
			this.tSoftwareVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lstBikeProfile = new System.Windows.Forms.ListView();
			this.colBikeName = new System.Windows.Forms.ColumnHeader();
			this.colWeight = new System.Windows.Forms.ColumnHeader();
			this.colOdometer = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tHeight = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tHeartMax = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tHeartResting = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tWeightKg = new System.Windows.Forms.Label();
			this.tAge = new System.Windows.Forms.Label();
			this.tGender = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.deviceImageList = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.pnlRequiresProcessing.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRequiresProcessingIcon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.pnlLoadingActivities.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbDeviceImage)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tNoDevice
			// 
			this.tNoDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tNoDevice.Location = new System.Drawing.Point(18, 25);
			this.tNoDevice.Name = "tNoDevice";
			this.tNoDevice.Size = new System.Drawing.Size(907, 441);
			this.tNoDevice.TabIndex = 1;
			this.tNoDevice.Text = "[ No device Detected ]\r\n\r\nNote: If you have just plugged in the device it may tak" +
			"e a minute or two for it to be detected by Windows";
			this.tNoDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lineSeparator2
			// 
			this.lineSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator2.Location = new System.Drawing.Point(0, 481);
			this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator2.Name = "lineSeparator2";
			this.lineSeparator2.Size = new System.Drawing.Size(940, 2);
			this.lineSeparator2.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 481);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(940, 45);
			this.panel1.TabIndex = 10;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(853, 10);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 32);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// pnlRequiresProcessing
			// 
			this.pnlRequiresProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlRequiresProcessing.BackColor = System.Drawing.SystemColors.ControlLight;
			this.pnlRequiresProcessing.Controls.Add(this.btnProcessNow);
			this.pnlRequiresProcessing.Controls.Add(this.tNumToBeProcessed);
			this.pnlRequiresProcessing.Controls.Add(this.pbRequiresProcessingIcon);
			this.pnlRequiresProcessing.Location = new System.Drawing.Point(15, 102);
			this.pnlRequiresProcessing.Name = "pnlRequiresProcessing";
			this.pnlRequiresProcessing.Size = new System.Drawing.Size(278, 70);
			this.pnlRequiresProcessing.TabIndex = 9;
			this.pnlRequiresProcessing.Visible = false;
			// 
			// btnProcessNow
			// 
			this.btnProcessNow.Location = new System.Drawing.Point(151, 38);
			this.btnProcessNow.Name = "btnProcessNow";
			this.btnProcessNow.Size = new System.Drawing.Size(124, 29);
			this.btnProcessNow.TabIndex = 2;
			this.btnProcessNow.Text = "Process Selected...";
			this.btnProcessNow.UseVisualStyleBackColor = true;
			this.btnProcessNow.Click += new System.EventHandler(this.BtnProcessNowClick);
			// 
			// tNumToBeProcessed
			// 
			this.tNumToBeProcessed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tNumToBeProcessed.Location = new System.Drawing.Point(34, 4);
			this.tNumToBeProcessed.Name = "tNumToBeProcessed";
			this.tNumToBeProcessed.Size = new System.Drawing.Size(225, 34);
			this.tNumToBeProcessed.TabIndex = 1;
			this.tNumToBeProcessed.Text = "There are 0 activities that are not yet processed / uploaded";
			// 
			// pbRequiresProcessingIcon
			// 
			this.pbRequiresProcessingIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbRequiresProcessingIcon.Image")));
			this.pbRequiresProcessingIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbRequiresProcessingIcon.InitialImage")));
			this.pbRequiresProcessingIcon.Location = new System.Drawing.Point(12, 4);
			this.pbRequiresProcessingIcon.Name = "pbRequiresProcessingIcon";
			this.pbRequiresProcessingIcon.Size = new System.Drawing.Size(16, 16);
			this.pbRequiresProcessingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbRequiresProcessingIcon.TabIndex = 0;
			this.pbRequiresProcessingIcon.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(12, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(919, 460);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Device Information";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.lstDeviceActivities);
			this.groupBox5.Controls.Add(this.pnlLoadingActivities);
			this.groupBox5.Location = new System.Drawing.Point(15, 203);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(894, 251);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Activities Stored On Device";
			// 
			// lstDeviceActivities
			// 
			this.lstDeviceActivities.CheckBoxes = true;
			this.lstDeviceActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.colAlreadyProcessed,
									this.colStartTime,
									this.colDistance,
									this.colTotalTime,
									this.colMovingTime,
									this.colTotalAscent,
									this.colCalories,
									this.colAvgSpeed,
									this.colAvgHeart,
									this.colAvgCadence,
									this.colMaxSpeed,
									this.colMaxHeart,
									this.colMaxCadence,
									this.colFilePath,
									this.colDummy});
			this.lstDeviceActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDeviceActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstDeviceActivities.FullRowSelect = true;
			this.lstDeviceActivities.GridLines = true;
			this.lstDeviceActivities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstDeviceActivities.Location = new System.Drawing.Point(3, 16);
			this.lstDeviceActivities.MultiSelect = false;
			this.lstDeviceActivities.Name = "lstDeviceActivities";
			this.lstDeviceActivities.Size = new System.Drawing.Size(888, 232);
			this.lstDeviceActivities.TabIndex = 1;
			this.lstDeviceActivities.UseCompatibleStateImageBehavior = false;
			this.lstDeviceActivities.View = System.Windows.Forms.View.Details;
			this.lstDeviceActivities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstDeviceActivitiesItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 0;
			// 
			// colAlreadyProcessed
			// 
			this.colAlreadyProcessed.Text = "Processed";
			this.colAlreadyProcessed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colStartTime
			// 
			this.colStartTime.Text = "Start Time";
			this.colStartTime.Width = 112;
			// 
			// colDistance
			// 
			this.colDistance.Text = "Distance";
			this.colDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colDistance.Width = 55;
			// 
			// colTotalTime
			// 
			this.colTotalTime.Text = "Time";
			this.colTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colTotalTime.Width = 71;
			// 
			// colMovingTime
			// 
			this.colMovingTime.Text = "Moving Time";
			this.colMovingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colMovingTime.Width = 78;
			// 
			// colTotalAscent
			// 
			this.colTotalAscent.Text = "Tot.Ascent";
			this.colTotalAscent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colCalories
			// 
			this.colCalories.Text = "Calories";
			this.colCalories.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgSpeed
			// 
			this.colAvgSpeed.Text = "Avg. Speed";
			this.colAvgSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgHeart
			// 
			this.colAvgHeart.Text = "Avg.Heart";
			this.colAvgHeart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgCadence
			// 
			this.colAvgCadence.Text = "Avg.Cadence";
			this.colAvgCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxSpeed
			// 
			this.colMaxSpeed.Text = "Max.Speed";
			this.colMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxHeart
			// 
			this.colMaxHeart.Text = "Max.Heart";
			this.colMaxHeart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxCadence
			// 
			this.colMaxCadence.Text = "Max.Cadence";
			this.colMaxCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colFilePath
			// 
			this.colFilePath.Width = 0;
			// 
			// colDummy
			// 
			this.colDummy.Text = "";
			// 
			// pnlLoadingActivities
			// 
			this.pnlLoadingActivities.Controls.Add(this.label2);
			this.pnlLoadingActivities.Controls.Add(this.prgReadingActivities);
			this.pnlLoadingActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLoadingActivities.Location = new System.Drawing.Point(3, 16);
			this.pnlLoadingActivities.Name = "pnlLoadingActivities";
			this.pnlLoadingActivities.Size = new System.Drawing.Size(888, 232);
			this.pnlLoadingActivities.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(297, 14);
			this.label2.TabIndex = 5;
			this.label2.Text = "Reading activities on device ... this may take a while.\r\n";
			// 
			// prgReadingActivities
			// 
			this.prgReadingActivities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.prgReadingActivities.Location = new System.Drawing.Point(12, 60);
			this.prgReadingActivities.Maximum = 0;
			this.prgReadingActivities.Name = "prgReadingActivities";
			this.prgReadingActivities.Size = new System.Drawing.Size(861, 23);
			this.prgReadingActivities.Step = 1;
			this.prgReadingActivities.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.prgReadingActivities.TabIndex = 4;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pbDeviceImage);
			this.groupBox4.Controls.Add(this.pnlRequiresProcessing);
			this.groupBox4.Controls.Add(this.tNumActivities);
			this.groupBox4.Controls.Add(this.tDevice);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.tSerialNumber);
			this.groupBox4.Controls.Add(this.tSoftwareVersion);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Location = new System.Drawing.Point(15, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(299, 178);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Device";
			// 
			// pbDeviceImage
			// 
			this.pbDeviceImage.InitialImage = null;
			this.pbDeviceImage.Location = new System.Drawing.Point(213, 11);
			this.pbDeviceImage.Name = "pbDeviceImage";
			this.pbDeviceImage.Size = new System.Drawing.Size(80, 80);
			this.pbDeviceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbDeviceImage.TabIndex = 10;
			this.pbDeviceImage.TabStop = false;
			// 
			// tNumActivities
			// 
			this.tNumActivities.Location = new System.Drawing.Point(118, 80);
			this.tNumActivities.Name = "tNumActivities";
			this.tNumActivities.Size = new System.Drawing.Size(89, 15);
			this.tNumActivities.TabIndex = 6;
			this.tNumActivities.Text = "< calculating >";
			// 
			// tDevice
			// 
			this.tDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tDevice.Location = new System.Drawing.Point(15, 21);
			this.tDevice.Name = "tDevice";
			this.tDevice.Size = new System.Drawing.Size(233, 19);
			this.tDevice.TabIndex = 0;
			this.tDevice.Text = "Garmin 500";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Serial No.";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(15, 80);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(102, 15);
			this.label11.TabIndex = 5;
			this.label11.Text = "No. Activities";
			// 
			// tSerialNumber
			// 
			this.tSerialNumber.Location = new System.Drawing.Point(118, 44);
			this.tSerialNumber.Name = "tSerialNumber";
			this.tSerialNumber.Size = new System.Drawing.Size(89, 15);
			this.tSerialNumber.TabIndex = 2;
			// 
			// tSoftwareVersion
			// 
			this.tSoftwareVersion.Location = new System.Drawing.Point(118, 62);
			this.tSoftwareVersion.Name = "tSoftwareVersion";
			this.tSoftwareVersion.Size = new System.Drawing.Size(89, 15);
			this.tSoftwareVersion.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Software Version";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lstBikeProfile);
			this.groupBox3.Location = new System.Drawing.Point(575, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(267, 178);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Bike Profile";
			// 
			// lstBikeProfile
			// 
			this.lstBikeProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colBikeName,
									this.colWeight,
									this.colOdometer});
			this.lstBikeProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstBikeProfile.FullRowSelect = true;
			this.lstBikeProfile.GridLines = true;
			this.lstBikeProfile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstBikeProfile.Location = new System.Drawing.Point(3, 16);
			this.lstBikeProfile.MultiSelect = false;
			this.lstBikeProfile.Name = "lstBikeProfile";
			this.lstBikeProfile.Size = new System.Drawing.Size(261, 159);
			this.lstBikeProfile.TabIndex = 0;
			this.lstBikeProfile.UseCompatibleStateImageBehavior = false;
			this.lstBikeProfile.View = System.Windows.Forms.View.Details;
			// 
			// colBikeName
			// 
			this.colBikeName.Text = "Bike Name";
			this.colBikeName.Width = 112;
			// 
			// colWeight
			// 
			this.colWeight.Text = "Weight";
			this.colWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colWeight.Width = 55;
			// 
			// colOdometer
			// 
			this.colOdometer.Text = "Odometer";
			this.colOdometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colOdometer.Width = 89;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tHeight);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tHeartMax);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.tHeartResting);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tWeightKg);
			this.groupBox2.Controls.Add(this.tAge);
			this.groupBox2.Controls.Add(this.tGender);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(320, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(249, 178);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "User Profile";
			// 
			// tHeight
			// 
			this.tHeight.Location = new System.Drawing.Point(143, 94);
			this.tHeight.Name = "tHeight";
			this.tHeight.Size = new System.Drawing.Size(71, 23);
			this.tHeight.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 94);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 23);
			this.label9.TabIndex = 10;
			this.label9.Text = "Height";
			// 
			// tHeartMax
			// 
			this.tHeartMax.Location = new System.Drawing.Point(143, 140);
			this.tHeartMax.Name = "tHeartMax";
			this.tHeartMax.Size = new System.Drawing.Size(71, 23);
			this.tHeartMax.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 140);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Heart-Rate (Max)";
			// 
			// tHeartResting
			// 
			this.tHeartResting.Location = new System.Drawing.Point(143, 117);
			this.tHeartResting.Name = "tHeartResting";
			this.tHeartResting.Size = new System.Drawing.Size(71, 23);
			this.tHeartResting.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 117);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Heart-Rate (Rest)";
			// 
			// tWeightKg
			// 
			this.tWeightKg.Location = new System.Drawing.Point(143, 71);
			this.tWeightKg.Name = "tWeightKg";
			this.tWeightKg.Size = new System.Drawing.Size(71, 23);
			this.tWeightKg.TabIndex = 5;
			// 
			// tAge
			// 
			this.tAge.Location = new System.Drawing.Point(143, 48);
			this.tAge.Name = "tAge";
			this.tAge.Size = new System.Drawing.Size(100, 23);
			this.tAge.TabIndex = 4;
			// 
			// tGender
			// 
			this.tGender.Location = new System.Drawing.Point(143, 26);
			this.tGender.Name = "tGender";
			this.tGender.Size = new System.Drawing.Size(100, 23);
			this.tGender.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "Weight";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "Age";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Gender";
			// 
			// deviceImageList
			// 
			this.deviceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("deviceImageList.ImageStream")));
			this.deviceImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.deviceImageList.Images.SetKeyName(0, "edge200.png");
			this.deviceImageList.Images.SetKeyName(1, "edge500.png");
			this.deviceImageList.Images.SetKeyName(2, "edge800.png");
			this.deviceImageList.Images.SetKeyName(3, "forerunner50.png");
			this.deviceImageList.Images.SetKeyName(4, "forerunner60.png");
			this.deviceImageList.Images.SetKeyName(5, "forerunner310.png");
			this.deviceImageList.Images.SetKeyName(6, "forerunner405.png");
			// 
			// GarminSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(940, 526);
			this.Controls.Add(this.lineSeparator2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tNoDevice);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(956, 564);
			this.Name = "GarminSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Garmin Device Information";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GarminSettingsFormClosing);
			this.Shown += new System.EventHandler(this.GarminSettingsShown);
			this.panel1.ResumeLayout(false);
			this.pnlRequiresProcessing.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbRequiresProcessingIcon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.pnlLoadingActivities.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbDeviceImage)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader colFilePath;
		private System.Windows.Forms.ImageList deviceImageList;
		private System.Windows.Forms.PictureBox pbDeviceImage;
		private System.Windows.Forms.Button btnProcessNow;
		private System.Windows.Forms.Label tNumToBeProcessed;
		private System.Windows.Forms.PictureBox pbRequiresProcessingIcon;
		private System.Windows.Forms.Panel pnlRequiresProcessing;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader colAlreadyProcessed;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label tNumActivities;
		private System.Windows.Forms.ColumnHeader colMaxCadence;
		private System.Windows.Forms.ColumnHeader colMaxHeart;
		private System.Windows.Forms.ColumnHeader colMaxSpeed;
		private System.Windows.Forms.ColumnHeader colAvgCadence;
		private System.Windows.Forms.ColumnHeader colAvgHeart;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colCalories;
		private System.Windows.Forms.ColumnHeader colTotalAscent;
		private System.Windows.Forms.ColumnHeader colDummy;
		private System.Windows.Forms.ProgressBar prgReadingActivities;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlLoadingActivities;
		private System.Windows.Forms.ColumnHeader colMovingTime;
		private System.Windows.Forms.ColumnHeader colTotalTime;
		private System.Windows.Forms.ColumnHeader colDistance;
		private System.Windows.Forms.ColumnHeader colStartTime;
		private System.Windows.Forms.ListView lstDeviceActivities;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ColumnHeader colOdometer;
		private System.Windows.Forms.ColumnHeader colWeight;
		private System.Windows.Forms.ColumnHeader colBikeName;
		private System.Windows.Forms.ListView lstBikeProfile;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label tHeartMax;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label tHeight;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label tHeartResting;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label tSoftwareVersion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label tGender;
		private System.Windows.Forms.Label tAge;
		private System.Windows.Forms.Label tWeightKg;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label tSerialNumber;
		private System.Windows.Forms.Label tDevice;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private CycleUploader.LineSeparator lineSeparator2;
		private System.Windows.Forms.Label tNoDevice;
		private System.Windows.Forms.OpenFileDialog openFile;
	}
}
