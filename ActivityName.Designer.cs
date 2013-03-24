/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 18/03/2013
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class ActivityName
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityName));
			this.label1 = new System.Windows.Forms.Label();
			this.txtActivityName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtActivityNotes = new System.Windows.Forms.TextBox();
			this.cbkIsCommute = new System.Windows.Forms.CheckBox();
			this.cbkIsStationaryTrainer = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Activity Name";
			// 
			// txtActivityName
			// 
			this.txtActivityName.Location = new System.Drawing.Point(113, 30);
			this.txtActivityName.Name = "txtActivityName";
			this.txtActivityName.Size = new System.Drawing.Size(329, 20);
			this.txtActivityName.TabIndex = 0;
			this.txtActivityName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtActivityNameKeyDown);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(430, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Set the Name of the selected Activity";
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(367, 234);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Apply...";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 234);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Notes";
			// 
			// txtActivityNotes
			// 
			this.txtActivityNotes.Location = new System.Drawing.Point(113, 56);
			this.txtActivityNotes.Multiline = true;
			this.txtActivityNotes.Name = "txtActivityNotes";
			this.txtActivityNotes.Size = new System.Drawing.Size(329, 122);
			this.txtActivityNotes.TabIndex = 1;
			// 
			// cbkIsCommute
			// 
			this.cbkIsCommute.Location = new System.Drawing.Point(114, 184);
			this.cbkIsCommute.Name = "cbkIsCommute";
			this.cbkIsCommute.Size = new System.Drawing.Size(328, 24);
			this.cbkIsCommute.TabIndex = 2;
			this.cbkIsCommute.Text = "Commute";
			this.cbkIsCommute.UseVisualStyleBackColor = true;
			// 
			// cbkIsStationaryTrainer
			// 
			this.cbkIsStationaryTrainer.Location = new System.Drawing.Point(114, 205);
			this.cbkIsStationaryTrainer.Name = "cbkIsStationaryTrainer";
			this.cbkIsStationaryTrainer.Size = new System.Drawing.Size(328, 24);
			this.cbkIsStationaryTrainer.TabIndex = 3;
			this.cbkIsStationaryTrainer.Text = "Stationary Trainer";
			this.cbkIsStationaryTrainer.UseVisualStyleBackColor = true;
			// 
			// ActivityName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 269);
			this.Controls.Add(this.cbkIsStationaryTrainer);
			this.Controls.Add(this.cbkIsCommute);
			this.Controls.Add(this.txtActivityNotes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtActivityName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActivityName";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Activity Details";
			this.Load += new System.EventHandler(this.ActivityNameLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox cbkIsStationaryTrainer;
		private System.Windows.Forms.CheckBox cbkIsCommute;
		private System.Windows.Forms.TextBox txtActivityNotes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtActivityName;
		private System.Windows.Forms.Label label1;
	}
}
