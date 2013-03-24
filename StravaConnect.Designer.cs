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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStravaLoginTest = new System.Windows.Forms.Button();
			this.txtStravaPassword = new System.Windows.Forms.TextBox();
			this.txtStravaUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnStravaLoginTest);
			this.groupBox1.Controls.Add(this.txtStravaPassword);
			this.groupBox1.Controls.Add(this.txtStravaUsername);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 146);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Strava Login Details";
			// 
			// btnStravaLoginTest
			// 
			this.btnStravaLoginTest.Location = new System.Drawing.Point(107, 99);
			this.btnStravaLoginTest.Name = "btnStravaLoginTest";
			this.btnStravaLoginTest.Size = new System.Drawing.Size(75, 23);
			this.btnStravaLoginTest.TabIndex = 4;
			this.btnStravaLoginTest.Text = "Test Login";
			this.btnStravaLoginTest.UseVisualStyleBackColor = true;
			this.btnStravaLoginTest.Click += new System.EventHandler(this.BtnStravaLoginTestClick);
			// 
			// txtStravaPassword
			// 
			this.txtStravaPassword.Location = new System.Drawing.Point(107, 66);
			this.txtStravaPassword.Name = "txtStravaPassword";
			this.txtStravaPassword.Size = new System.Drawing.Size(167, 20);
			this.txtStravaPassword.TabIndex = 3;
			this.txtStravaPassword.UseSystemPasswordChar = true;
			// 
			// txtStravaUsername
			// 
			this.txtStravaUsername.Location = new System.Drawing.Point(107, 40);
			this.txtStravaUsername.Name = "txtStravaUsername";
			this.txtStravaUsername.Size = new System.Drawing.Size(167, 20);
			this.txtStravaUsername.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(268, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// StravaConnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 195);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StravaConnect";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connect to Strava";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtStravaUsername;
		private System.Windows.Forms.TextBox txtStravaPassword;
		private System.Windows.Forms.Button btnStravaLoginTest;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
