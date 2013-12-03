/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 10/04/2013
 * Time: 13:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class UpdateNotification
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateNotification));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.tLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tLatestVersion = new System.Windows.Forms.Label();
			this.tCurrentVersion = new System.Windows.Forms.Label();
			this.tQuestion = new System.Windows.Forms.Label();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.tChangeLog = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnYes);
			this.panel1.Controls.Add(this.btnNo);
			this.panel1.Controls.Add(this.lineSeparator4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 282);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(647, 45);
			this.panel1.TabIndex = 17;
			// 
			// btnYes
			// 
			this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnYes.Location = new System.Drawing.Point(12, 8);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(107, 32);
			this.btnYes.TabIndex = 19;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.BtnYesClick);
			// 
			// btnNo
			// 
			this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNo.Location = new System.Drawing.Point(394, 8);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(107, 32);
			this.btnNo.TabIndex = 18;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.BtnNoClick);
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 0);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(647, 2);
			this.lineSeparator4.TabIndex = 17;
			// 
			// tLabel
			// 
			this.tLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tLabel.Location = new System.Drawing.Point(63, 9);
			this.tLabel.Name = "tLabel";
			this.tLabel.Size = new System.Drawing.Size(424, 23);
			this.tLabel.TabIndex = 18;
			this.tLabel.Text = "A software update is available for download";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(95, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 23);
			this.label2.TabIndex = 19;
			this.label2.Text = "Your Version:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(95, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 23);
			this.label3.TabIndex = 20;
			this.label3.Text = "Latest Version:";
			// 
			// tLatestVersion
			// 
			this.tLatestVersion.Location = new System.Drawing.Point(177, 55);
			this.tLatestVersion.Name = "tLatestVersion";
			this.tLatestVersion.Size = new System.Drawing.Size(87, 23);
			this.tLatestVersion.TabIndex = 22;
			// 
			// tCurrentVersion
			// 
			this.tCurrentVersion.Location = new System.Drawing.Point(177, 32);
			this.tCurrentVersion.Name = "tCurrentVersion";
			this.tCurrentVersion.Size = new System.Drawing.Size(103, 23);
			this.tCurrentVersion.TabIndex = 21;
			// 
			// tQuestion
			// 
			this.tQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tQuestion.Location = new System.Drawing.Point(63, 246);
			this.tQuestion.Name = "tQuestion";
			this.tQuestion.Size = new System.Drawing.Size(256, 23);
			this.tQuestion.TabIndex = 23;
			this.tQuestion.Text = "Do you want to download this update now ?";
			// 
			// pbIcon
			// 
			this.pbIcon.Location = new System.Drawing.Point(12, 9);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(32, 32);
			this.pbIcon.TabIndex = 24;
			this.pbIcon.TabStop = false;
			// 
			// tChangeLog
			// 
			this.tChangeLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tChangeLog.Location = new System.Drawing.Point(63, 98);
			this.tChangeLog.Multiline = true;
			this.tChangeLog.Name = "tChangeLog";
			this.tChangeLog.ReadOnly = true;
			this.tChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tChangeLog.Size = new System.Drawing.Size(572, 136);
			this.tChangeLog.TabIndex = 25;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(63, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 17);
			this.label5.TabIndex = 26;
			this.label5.Text = "Change Log";
			// 
			// UpdateNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 327);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tChangeLog);
			this.Controls.Add(this.pbIcon);
			this.Controls.Add(this.tQuestion);
			this.Controls.Add(this.tLatestVersion);
			this.Controls.Add(this.tCurrentVersion);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tLabel);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateNotification";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Software Update Available";
			this.Load += new System.EventHandler(this.UpdateNotificationLoad);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tChangeLog;
		private System.Windows.Forms.PictureBox pbIcon;
		private System.Windows.Forms.Label tQuestion;
		private System.Windows.Forms.Label tCurrentVersion;
		private System.Windows.Forms.Label tLatestVersion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label tLabel;
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Panel panel1;
	}
}
