/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblVersionStr = new System.Windows.Forms.Label();
			this.tvSupportedDevices = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
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
			this.btnClose.Location = new System.Drawing.Point(370, 295);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
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
			this.tvSupportedDevices.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode10,
									treeNode17});
			this.tvSupportedDevices.Size = new System.Drawing.Size(419, 162);
			this.tvSupportedDevices.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(12, 94);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(433, 194);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tvSupportedDevices);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(425, 168);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Supported Devices";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 330);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lblVersionStr);
			this.Controls.Add(this.btnClose);
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
			this.ResumeLayout(false);
		}
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
