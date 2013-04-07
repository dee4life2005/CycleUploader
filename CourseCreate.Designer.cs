/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/04/2013
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class CourseCreate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseCreate));
			this.lineSeparator1 = new CycleUploader.LineSeparator();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tActivityDistance = new System.Windows.Forms.Label();
			this.tActivityDate = new System.Windows.Forms.Label();
			this.tActivityName = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lineSeparator2 = new CycleUploader.LineSeparator();
			this.label9 = new System.Windows.Forms.Label();
			this.map = new System.Windows.Forms.WebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnMapFullscreen = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.tCourseName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lineSeparator1
			// 
			this.lineSeparator1.Location = new System.Drawing.Point(12, 23);
			this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator1.Name = "lineSeparator1";
			this.lineSeparator1.Size = new System.Drawing.Size(320, 2);
			this.lineSeparator1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Activity";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Date";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(35, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Distance";
			// 
			// tActivityDistance
			// 
			this.tActivityDistance.Location = new System.Drawing.Point(97, 80);
			this.tActivityDistance.Name = "tActivityDistance";
			this.tActivityDistance.Size = new System.Drawing.Size(208, 13);
			this.tActivityDistance.TabIndex = 7;
			// 
			// tActivityDate
			// 
			this.tActivityDate.Location = new System.Drawing.Point(97, 58);
			this.tActivityDate.Name = "tActivityDate";
			this.tActivityDate.Size = new System.Drawing.Size(208, 13);
			this.tActivityDate.TabIndex = 6;
			// 
			// tActivityName
			// 
			this.tActivityName.Location = new System.Drawing.Point(97, 37);
			this.tActivityName.Name = "tActivityName";
			this.tActivityName.Size = new System.Drawing.Size(208, 13);
			this.tActivityName.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(12, 116);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 9;
			this.label8.Text = "Course";
			// 
			// lineSeparator2
			// 
			this.lineSeparator2.Location = new System.Drawing.Point(12, 132);
			this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator2.Name = "lineSeparator2";
			this.lineSeparator2.Size = new System.Drawing.Size(320, 2);
			this.lineSeparator2.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(35, 148);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "Name";
			// 
			// map
			// 
			this.map.AllowWebBrowserDrop = false;
			this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.map.IsWebBrowserContextMenuEnabled = false;
			this.map.Location = new System.Drawing.Point(356, 9);
			this.map.Margin = new System.Windows.Forms.Padding(0);
			this.map.MinimumSize = new System.Drawing.Size(20, 20);
			this.map.Name = "map";
			this.map.ScriptErrorsSuppressed = true;
			this.map.ScrollBarsEnabled = false;
			this.map.Size = new System.Drawing.Size(311, 253);
			this.map.TabIndex = 13;
			this.map.TabStop = false;
			this.map.Url = new System.Uri("about:blank", System.UriKind.Absolute);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.btnMapFullscreen);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnApply);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 270);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(679, 45);
			this.panel1.TabIndex = 14;
			// 
			// btnMapFullscreen
			// 
			this.btnMapFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMapFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnMapFullscreen.Image")));
			this.btnMapFullscreen.Location = new System.Drawing.Point(606, 8);
			this.btnMapFullscreen.Name = "btnMapFullscreen";
			this.btnMapFullscreen.Size = new System.Drawing.Size(61, 32);
			this.btnMapFullscreen.TabIndex = 7;
			this.btnMapFullscreen.UseVisualStyleBackColor = true;
			this.btnMapFullscreen.Click += new System.EventHandler(this.BtnMapFullscreenClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(12, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(257, 8);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 32);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Apply...";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 270);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(679, 2);
			this.lineSeparator4.TabIndex = 15;
			// 
			// tCourseName
			// 
			this.tCourseName.Location = new System.Drawing.Point(97, 145);
			this.tCourseName.Name = "tCourseName";
			this.tCourseName.Size = new System.Drawing.Size(235, 20);
			this.tCourseName.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(344, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(2, 240);
			this.label5.TabIndex = 18;
			// 
			// CourseCreate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 315);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tCourseName);
			this.Controls.Add(this.lineSeparator4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.map);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lineSeparator2);
			this.Controls.Add(this.tActivityDistance);
			this.Controls.Add(this.tActivityDate);
			this.Controls.Add(this.tActivityName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lineSeparator1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(647, 343);
			this.Name = "CourseCreate";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create Course";
			this.Load += new System.EventHandler(this.CourseCreateLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnMapFullscreen;
		private System.Windows.Forms.TextBox tCourseName;
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.WebBrowser map;
		private System.Windows.Forms.Label label9;
		private CycleUploader.LineSeparator lineSeparator2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label tActivityName;
		private System.Windows.Forms.Label tActivityDate;
		private System.Windows.Forms.Label tActivityDistance;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private CycleUploader.LineSeparator lineSeparator1;
	}
}
