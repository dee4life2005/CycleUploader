/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/03/2013
 * Time: 11:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class DatabaseSchemaUpdate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSchemaUpdate));
			this.lblProgressStatus = new System.Windows.Forms.Label();
			this.prgStatus = new System.Windows.Forms.ProgressBar();
			this.lblMigrationNote = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblProgressStatus
			// 
			this.lblProgressStatus.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProgressStatus.Location = new System.Drawing.Point(12, 62);
			this.lblProgressStatus.Name = "lblProgressStatus";
			this.lblProgressStatus.Size = new System.Drawing.Size(492, 40);
			this.lblProgressStatus.TabIndex = 0;
			this.lblProgressStatus.Text = "Updating database in progress ... this should only take a moment.";
			// 
			// prgStatus
			// 
			this.prgStatus.Location = new System.Drawing.Point(12, 38);
			this.prgStatus.Name = "prgStatus";
			this.prgStatus.Size = new System.Drawing.Size(492, 21);
			this.prgStatus.TabIndex = 1;
			// 
			// lblMigrationNote
			// 
			this.lblMigrationNote.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMigrationNote.Location = new System.Drawing.Point(12, 22);
			this.lblMigrationNote.Name = "lblMigrationNote";
			this.lblMigrationNote.Size = new System.Drawing.Size(492, 13);
			this.lblMigrationNote.TabIndex = 2;
			// 
			// DatabaseSchemaUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 122);
			this.Controls.Add(this.lblMigrationNote);
			this.Controls.Add(this.prgStatus);
			this.Controls.Add(this.lblProgressStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DatabaseSchemaUpdate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Updating Database...";
			this.Shown += new System.EventHandler(this.DatabaseSchemaUpdateShown);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblMigrationNote;
		private System.Windows.Forms.ProgressBar prgStatus;
		private System.Windows.Forms.Label lblProgressStatus;
	}
}
