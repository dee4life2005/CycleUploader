/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 01/03/2013
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class StravaConnect
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StravaConnect));
			this.btnStravaLoginTest = new System.Windows.Forms.Button();
			this.txtStravaPassword = new System.Windows.Forms.TextBox();
			this.txtStravaUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lineSeparator1 = new CycleUploader.LineSeparator();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStravaLoginTest
			// 
			this.btnStravaLoginTest.Location = new System.Drawing.Point(203, 8);
			this.btnStravaLoginTest.Name = "btnStravaLoginTest";
			this.btnStravaLoginTest.Size = new System.Drawing.Size(86, 30);
			this.btnStravaLoginTest.TabIndex = 4;
			this.btnStravaLoginTest.Text = "Test Login...";
			this.btnStravaLoginTest.UseVisualStyleBackColor = true;
			this.btnStravaLoginTest.Click += new System.EventHandler(this.BtnStravaLoginTestClick);
			// 
			// txtStravaPassword
			// 
			this.txtStravaPassword.Location = new System.Drawing.Point(122, 82);
			this.txtStravaPassword.Name = "txtStravaPassword";
			this.txtStravaPassword.Size = new System.Drawing.Size(167, 20);
			this.txtStravaPassword.TabIndex = 3;
			this.txtStravaPassword.UseSystemPasswordChar = true;
			// 
			// txtStravaUsername
			// 
			this.txtStravaUsername.Location = new System.Drawing.Point(122, 56);
			this.txtStravaUsername.Name = "txtStravaUsername";
			this.txtStravaUsername.Size = new System.Drawing.Size(167, 20);
			this.txtStravaUsername.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.lineSeparator4);
			this.panel1.Controls.Add(this.btnStravaLoginTest);
			this.panel1.Controls.Add(this.btnMapFullscreen);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(331, 45);
			this.panel1.TabIndex = 18;
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 0);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(331, 2);
			this.lineSeparator4.TabIndex = 17;
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
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lineSeparator1);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(331, 38);
			this.panel2.TabIndex = 19;
			// 
			// lineSeparator1
			// 
			this.lineSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator1.Location = new System.Drawing.Point(0, 36);
			this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator1.Name = "lineSeparator1";
			this.lineSeparator1.Size = new System.Drawing.Size(331, 2);
			this.lineSeparator1.TabIndex = 19;
			// 
			// StravaConnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 172);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.txtStravaPassword);
			this.Controls.Add(this.txtStravaUsername);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StravaConnect";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connect to Strava";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CycleUploader.LineSeparator lineSeparator1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnMapFullscreen;
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtStravaUsername;
		private System.Windows.Forms.TextBox txtStravaPassword;
		private System.Windows.Forms.Button btnStravaLoginTest;
	}
}
