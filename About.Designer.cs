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
			System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode(".FIT");
			System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode(".GPX");
			System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode33,
									treeNode34,
									treeNode35});
			System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode37,
									treeNode38,
									treeNode39,
									treeNode40});
			System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Garmin Edge 500", new System.Windows.Forms.TreeNode[] {
									treeNode36,
									treeNode41});
			System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode(".GPX");
			System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode43});
			System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode45,
									treeNode46,
									treeNode47});
			System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Mio Cyclo 100", new System.Windows.Forms.TreeNode[] {
									treeNode44,
									treeNode48});
			System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode50});
			System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("RideWithGPS");
			System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode52,
									treeNode53,
									treeNode54,
									treeNode55});
			System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Bryton", new System.Windows.Forms.TreeNode[] {
									treeNode51,
									treeNode56});
			System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode(".TCX");
			System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("File Support", new System.Windows.Forms.TreeNode[] {
									treeNode58});
			System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("RunKeeper");
			System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("Strava");
			System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("GarminConnect");
			System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("Provider Support", new System.Windows.Forms.TreeNode[] {
									treeNode60,
									treeNode61,
									treeNode62});
			System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("TrainerRoad", new System.Windows.Forms.TreeNode[] {
									treeNode59,
									treeNode63});
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblVersionStr = new System.Windows.Forms.Label();
			this.tvSupportedDevices = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lineSeparator1 = new CycleUploader.LineSeparator();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(85, 76);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(160, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 35);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cycle Uploader";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(166, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(205, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Copyright © 2013, Steven Saunders";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(370, 10);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 32);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "OK";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// lblVersionStr
			// 
			this.lblVersionStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.lblVersionStr.Location = new System.Drawing.Point(225, 73);
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
			treeNode33.Name = "Node4";
			treeNode33.Text = ".FIT";
			treeNode34.Name = "Node5";
			treeNode34.Text = ".TCX";
			treeNode35.Name = "Node6";
			treeNode35.Text = ".GPX";
			treeNode36.Name = "Node3";
			treeNode36.Text = "File Support";
			treeNode37.Name = "Node8";
			treeNode37.Text = "RunKeeper";
			treeNode38.Name = "Node9";
			treeNode38.Text = "Strava";
			treeNode39.Name = "Node10";
			treeNode39.Text = "GarminConnect";
			treeNode40.Name = "Node11";
			treeNode40.Text = "RideWithGPS";
			treeNode41.Name = "Node7";
			treeNode41.Text = "Provider Support";
			treeNode42.Name = "nodeGarmin500";
			treeNode42.Text = "Garmin Edge 500";
			treeNode43.Name = "Node15";
			treeNode43.Text = ".GPX";
			treeNode44.Name = "Node13";
			treeNode44.Text = "File Support";
			treeNode45.Name = "Node16";
			treeNode45.Text = "RunKeeper";
			treeNode46.Name = "Node17";
			treeNode46.Text = "Strava";
			treeNode47.Name = "Node18";
			treeNode47.Text = "RideWithGPS";
			treeNode48.Name = "Node14";
			treeNode48.Text = "Provider Support";
			treeNode49.Name = "nodeMioCyclo100";
			treeNode49.Text = "Mio Cyclo 100";
			treeNode50.Name = "Node7";
			treeNode50.Text = ".TCX";
			treeNode51.Name = "Node1";
			treeNode51.Text = "File Support";
			treeNode52.Name = "Node3";
			treeNode52.Text = "RunKeeper";
			treeNode53.Name = "Node4";
			treeNode53.Text = "Strava";
			treeNode54.Name = "Node5";
			treeNode54.Text = "GarminConnect";
			treeNode55.Name = "Node6";
			treeNode55.Text = "RideWithGPS";
			treeNode56.Name = "Node2";
			treeNode56.Text = "Provider Support";
			treeNode57.Name = "nodeBryton";
			treeNode57.Text = "Bryton";
			treeNode58.Name = "Node3";
			treeNode58.Text = ".TCX";
			treeNode59.Name = "Node1";
			treeNode59.Text = "File Support";
			treeNode60.Name = "Node4";
			treeNode60.Text = "RunKeeper";
			treeNode61.Name = "Node5";
			treeNode61.Text = "Strava";
			treeNode62.Name = "Node6";
			treeNode62.Text = "GarminConnect";
			treeNode63.Name = "Node2";
			treeNode63.Text = "Provider Support";
			treeNode64.Name = "Node0";
			treeNode64.Text = "TrainerRoad";
			this.tvSupportedDevices.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode42,
									treeNode49,
									treeNode57,
									treeNode64});
			this.tvSupportedDevices.Size = new System.Drawing.Size(419, 153);
			this.tvSupportedDevices.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(12, 94);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(433, 185);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tvSupportedDevices);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(425, 159);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Supported Devices";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 285);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(457, 45);
			this.panel1.TabIndex = 8;
			// 
			// lineSeparator1
			// 
			this.lineSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator1.Location = new System.Drawing.Point(0, 285);
			this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator1.Name = "lineSeparator1";
			this.lineSeparator1.Size = new System.Drawing.Size(457, 2);
			this.lineSeparator1.TabIndex = 9;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 330);
			this.Controls.Add(this.lineSeparator1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lblVersionStr);
			this.Controls.Add(this.label2);
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
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private CycleUploader.LineSeparator lineSeparator1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TreeView tvSupportedDevices;
		private System.Windows.Forms.Label lblVersionStr;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
