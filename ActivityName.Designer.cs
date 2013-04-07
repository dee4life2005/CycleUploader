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
			this.cbkIsIncludedInStatistics = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lstCourse = new System.Windows.Forms.ComboBox();
			this.lineSeparator1 = new CycleUploader.LineSeparator();
			this.map = new System.Windows.Forms.WebBrowser();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
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
			this.label2.Text = "Provide details for the selected activity";
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnApply.Location = new System.Drawing.Point(367, 10);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 32);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Apply...";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(12, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
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
			this.cbkIsCommute.Location = new System.Drawing.Point(113, 184);
			this.cbkIsCommute.Name = "cbkIsCommute";
			this.cbkIsCommute.Size = new System.Drawing.Size(328, 24);
			this.cbkIsCommute.TabIndex = 2;
			this.cbkIsCommute.Text = "Commute";
			this.cbkIsCommute.UseVisualStyleBackColor = true;
			// 
			// cbkIsStationaryTrainer
			// 
			this.cbkIsStationaryTrainer.Location = new System.Drawing.Point(113, 204);
			this.cbkIsStationaryTrainer.Name = "cbkIsStationaryTrainer";
			this.cbkIsStationaryTrainer.Size = new System.Drawing.Size(328, 24);
			this.cbkIsStationaryTrainer.TabIndex = 3;
			this.cbkIsStationaryTrainer.Text = "Stationary Trainer";
			this.cbkIsStationaryTrainer.UseVisualStyleBackColor = true;
			// 
			// cbkIsIncludedInStatistics
			// 
			this.cbkIsIncludedInStatistics.Checked = true;
			this.cbkIsIncludedInStatistics.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkIsIncludedInStatistics.Enabled = false;
			this.cbkIsIncludedInStatistics.Location = new System.Drawing.Point(113, 224);
			this.cbkIsIncludedInStatistics.Name = "cbkIsIncludedInStatistics";
			this.cbkIsIncludedInStatistics.Size = new System.Drawing.Size(328, 24);
			this.cbkIsIncludedInStatistics.TabIndex = 6;
			this.cbkIsIncludedInStatistics.Text = "Include in Stats";
			this.cbkIsIncludedInStatistics.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnMapFullscreen);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnApply);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 301);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(769, 45);
			this.panel1.TabIndex = 7;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(701, 10);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(61, 32);
			this.btnMapFullscreen.TabIndex = 6;
			this.btnMapFullscreen.UseVisualStyleBackColor = true;
			this.btnMapFullscreen.Click += new System.EventHandler(this.BtnMapFullscreenClick);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 257);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Course";
			// 
			// lstCourse
			// 
			this.lstCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstCourse.FormattingEnabled = true;
			this.lstCourse.Location = new System.Drawing.Point(113, 253);
			this.lstCourse.Name = "lstCourse";
			this.lstCourse.Size = new System.Drawing.Size(328, 21);
			this.lstCourse.TabIndex = 9;
			this.lstCourse.SelectedIndexChanged += new System.EventHandler(this.LstCourseSelectedIndexChanged);
			// 
			// lineSeparator1
			// 
			this.lineSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator1.Location = new System.Drawing.Point(0, 300);
			this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator1.Name = "lineSeparator1";
			this.lineSeparator1.Size = new System.Drawing.Size(769, 2);
			this.lineSeparator1.TabIndex = 6;
			// 
			// map
			// 
			this.map.AllowWebBrowserDrop = false;
			this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.map.IsWebBrowserContextMenuEnabled = false;
			this.map.Location = new System.Drawing.Point(466, 9);
			this.map.Margin = new System.Windows.Forms.Padding(0);
			this.map.MinimumSize = new System.Drawing.Size(20, 20);
			this.map.Name = "map";
			this.map.ScriptErrorsSuppressed = true;
			this.map.ScrollBarsEnabled = false;
			this.map.Size = new System.Drawing.Size(294, 286);
			this.map.TabIndex = 16;
			this.map.TabStop = false;
			this.map.Url = new System.Uri("about:blank", System.UriKind.Absolute);
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(454, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(2, 280);
			this.label5.TabIndex = 17;
			// 
			// ActivityName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 346);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.map);
			this.Controls.Add(this.lineSeparator1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cbkIsIncludedInStatistics);
			this.Controls.Add(this.cbkIsStationaryTrainer);
			this.Controls.Add(this.cbkIsCommute);
			this.Controls.Add(this.txtActivityNotes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtActivityName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstCourse);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActivityName";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Activity Details";
			this.Load += new System.EventHandler(this.ActivityNameLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnMapFullscreen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.WebBrowser map;
		private CycleUploader.LineSeparator lineSeparator1;
		private System.Windows.Forms.ComboBox lstCourse;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox cbkIsIncludedInStatistics;
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
