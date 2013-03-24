/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 03/03/2013
 * Time: 22:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class GarminConnect
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnSaveLoginDetails = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(28, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(134, 22);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(168, 20);
			this.txtUserName.TabIndex = 2;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(134, 51);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(168, 20);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// btnSaveLoginDetails
			// 
			this.btnSaveLoginDetails.Location = new System.Drawing.Point(202, 91);
			this.btnSaveLoginDetails.Name = "btnSaveLoginDetails";
			this.btnSaveLoginDetails.Size = new System.Drawing.Size(100, 23);
			this.btnSaveLoginDetails.TabIndex = 4;
			this.btnSaveLoginDetails.Text = "Save...";
			this.btnSaveLoginDetails.UseVisualStyleBackColor = true;
			this.btnSaveLoginDetails.Click += new System.EventHandler(this.BtnSaveLoginDetailsClick);
			// 
			// GarminConnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 133);
			this.Controls.Add(this.btnSaveLoginDetails);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GarminConnect";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Garmin Connect Login Details";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnSaveLoginDetails;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
