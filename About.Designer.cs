/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class About
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode(".FIT");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode(".GPX");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode5,
									treeNode6,
									treeNode7,
									treeNode8});
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Garmin Edge 500", new System.Windows.Forms.TreeNode[] {
									treeNode4,
									treeNode9});
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode(".GPX");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode11});
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode13,
									treeNode14,
									treeNode15});
			System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Mio Cyclo 100", new System.Windows.Forms.TreeNode[] {
									treeNode12,
									treeNode16});
			System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode18});
			System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode20,
									treeNode21,
									treeNode22,
									treeNode23});
			System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Bryton", new System.Windows.Forms.TreeNode[] {
									treeNode19,
									treeNode24});
			System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode26});
			System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode28,
									treeNode29,
									treeNode30});
			System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("TrainerRoad", new System.Windows.Forms.TreeNode[] {
									treeNode27,
									treeNode31});
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblVersionStr = new System.Windows.Forms.Label();
			this.tvSupportedDevices = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tChangeLog = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.linkEmail = new System.Windows.Forms.LinkLabel();
			this.lineSeparator1 = new CycleUploader.LineSeparator();
			this.lineSeparator2 = new CycleUploader.LineSeparator();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(79, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(276, 47);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cycle Uploader";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(331, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Copyright © 2013, Steven Saunders";
			// 
			// lblVersionStr
			// 
			this.lblVersionStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.lblVersionStr.Location = new System.Drawing.Point(87, 52);
			this.lblVersionStr.Name = "lblVersionStr";
			this.lblVersionStr.Size = new System.Drawing.Size(99, 18);
			this.lblVersionStr.TabIndex = 4;
			this.lblVersionStr.Text = "v 1.0.0.12";
			// 
			// tvSupportedDevices
			// 
			this.tvSupportedDevices.BackColor = System.Drawing.SystemColors.Window;
			this.tvSupportedDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvSupportedDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvSupportedDevices.HotTracking = true;
			this.tvSupportedDevices.ItemHeight = 16;
			this.tvSupportedDevices.LineColor = System.Drawing.Color.SteelBlue;
			this.tvSupportedDevices.Location = new System.Drawing.Point(3, 3);
			this.tvSupportedDevices.Margin = new System.Windows.Forms.Padding(10);
			this.tvSupportedDevices.Name = "tvSupportedDevices";
			treeNode1.Name = "Node4";
			treeNode1.Text = ".FIT";
			treeNode2.Name = "Node5";
			treeNode2.Text = ".TCX";
			treeNode3.Name = "Node6";
			treeNode3.Text = ".GPX";
			treeNode4.Name = "Node3";
			treeNode4.Text = "File Support";
			treeNode5.Name = "Node8";
			treeNode5.Text = "RunKeeper";
			treeNode6.Name = "Node9";
			treeNode6.Text = "Strava";
			treeNode7.Name = "Node10";
			treeNode7.Text = "GarminConnect";
			treeNode8.Name = "Node11";
			treeNode8.Text = "RideWithGPS";
			treeNode9.Name = "Node7";
			treeNode9.Text = "Provider Support";
			treeNode10.Name = "nodeGarmin500";
			treeNode10.Text = "Garmin Edge 500";
			treeNode11.Name = "Node15";
			treeNode11.Text = ".GPX";
			treeNode12.Name = "Node13";
			treeNode12.Text = "File Support";
			treeNode13.Name = "Node16";
			treeNode13.Text = "RunKeeper";
			treeNode14.Name = "Node17";
			treeNode14.Text = "Strava";
			treeNode15.Name = "Node18";
			treeNode15.Text = "RideWithGPS";
			treeNode16.Name = "Node14";
			treeNode16.Text = "Provider Support";
			treeNode17.Name = "nodeMioCyclo100";
			treeNode17.Text = "Mio Cyclo 100";
			treeNode18.Name = "Node7";
			treeNode18.Text = ".TCX";
			treeNode19.Name = "Node1";
			treeNode19.Text = "File Support";
			treeNode20.Name = "Node3";
			treeNode20.Text = "RunKeeper";
			treeNode21.Name = "Node4";
			treeNode21.Text = "Strava";
			treeNode22.Name = "Node5";
			treeNode22.Text = "GarminConnect";
			treeNode23.Name = "Node6";
			treeNode23.Text = "RideWithGPS";
			treeNode24.Name = "Node2";
			treeNode24.Text = "Provider Support";
			treeNode25.Name = "nodeBryton";
			treeNode25.Text = "Bryton";
			treeNode26.Name = "Node3";
			treeNode26.Text = ".TCX";
			treeNode27.Name = "Node1";
			treeNode27.Text = "File Support";
			treeNode28.Name = "Node4";
			treeNode28.Text = "RunKeeper";
			treeNode29.Name = "Node5";
			treeNode29.Text = "Strava";
			treeNode30.Name = "Node6";
			treeNode30.Text = "GarminConnect";
			treeNode31.Name = "Node2";
			treeNode31.Text = "Provider Support";
			treeNode32.Name = "Node0";
			treeNode32.Text = "TrainerRoad";
			this.tvSupportedDevices.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode10,
									treeNode17,
									treeNode25,
									treeNode32});
			this.tvSupportedDevices.Size = new System.Drawing.Size(483, 180);
			this.tvSupportedDevices.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 82);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(497, 212);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.tvSupportedDevices);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(489, 186);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Supported Devices";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.tChangeLog);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(489, 186);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Change Log";
			// 
			// tChangeLog
			// 
			this.tChangeLog.BackColor = System.Drawing.SystemColors.Window;
			this.tChangeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tChangeLog.Location = new System.Drawing.Point(3, 3);
			this.tChangeLog.Name = "tChangeLog";
			this.tChangeLog.ReadOnly = true;
			this.tChangeLog.Size = new System.Drawing.Size(483, 180);
			this.tChangeLog.TabIndex = 1;
			this.tChangeLog.Text = "";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.linkEmail);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 349);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(518, 45);
			this.panel1.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(12, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 14);
			this.label3.TabIndex = 7;
			this.label3.Text = "Email :";
			// 
			// linkEmail
			// 
			this.linkEmail.ForeColor = System.Drawing.Color.White;
			this.linkEmail.LinkColor = System.Drawing.Color.Black;
			this.linkEmail.Location = new System.Drawing.Point(63, 20);
			this.linkEmail.Name = "linkEmail";
			this.linkEmail.Size = new System.Drawing.Size(177, 14);
			this.linkEmail.TabIndex = 6;
			this.linkEmail.TabStop = true;
			this.linkEmail.Text = "cycleuploader@gmail.com";
			this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkEmailLinkClicked);
			// 
			// lineSeparator1
			// 
			this.lineSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator1.Location = new System.Drawing.Point(0, 349);
			this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator1.Name = "lineSeparator1";
			this.lineSeparator1.Size = new System.Drawing.Size(518, 2);
			this.lineSeparator1.TabIndex = 9;
			// 
			// lineSeparator2
			// 
			this.lineSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator2.Location = new System.Drawing.Point(0, 349);
			this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator2.Name = "lineSeparator2";
			this.lineSeparator2.Size = new System.Drawing.Size(518, 2);
			this.lineSeparator2.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 297);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(497, 41);
			this.label4.TabIndex = 30;
			this.label4.Text = "Note: \r\nSTRAVA support removed as of 03/07/2013 due to them dropping support for " +
			"V1/V2 of their API. \r\nAccess to V3 of their API wasn\'t granted, unfortunately.";
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 394);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lineSeparator2);
			this.Controls.Add(this.lineSeparator1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lblVersionStr);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About CycleUploader";
			this.Load += new System.EventHandler(this.AboutLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox tChangeLog;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.LinkLabel linkEmail;
		private System.Windows.Forms.Label label3;
		private CycleUploader.LineSeparator lineSeparator2;
		private CycleUploader.LineSeparator lineSeparator1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TreeView tvSupportedDevices;
		private System.Windows.Forms.Label lblVersionStr;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
