/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 01/04/2013
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class UserCharts
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCharts));
			this.zedGraph = new ZedGraph.ZedGraphControl();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.rdoGroupWeekly = new System.Windows.Forms.RadioButton();
			this.rdoGroupMonthly = new System.Windows.Forms.RadioButton();
			this.dpFrom = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dpTo = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// zedGraph
			// 
			this.zedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.zedGraph.IsAntiAlias = true;
			this.zedGraph.IsShowPointValues = true;
			this.zedGraph.IsSynchronizeXAxes = true;
			this.zedGraph.Location = new System.Drawing.Point(12, 111);
			this.zedGraph.Name = "zedGraph";
			this.zedGraph.ScrollGrace = 0D;
			this.zedGraph.ScrollMaxX = 0D;
			this.zedGraph.ScrollMaxY = 0D;
			this.zedGraph.ScrollMaxY2 = 0D;
			this.zedGraph.ScrollMinX = 0D;
			this.zedGraph.ScrollMinY = 0D;
			this.zedGraph.ScrollMinY2 = 0D;
			this.zedGraph.Size = new System.Drawing.Size(883, 383);
			this.zedGraph.TabIndex = 1;
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(136, 22);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 21);
			this.radioButton3.TabIndex = 6;
			this.radioButton3.Text = "Total Distance";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.rdoChartTypeCheckedChanged);
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(246, 20);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(96, 24);
			this.radioButton5.TabIndex = 5;
			this.radioButton5.Text = "Total Ascent";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.CheckedChanged += new System.EventHandler(this.rdoChartTypeCheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(246, 47);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(104, 24);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "Total Calories";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.rdoChartTypeCheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(136, 47);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Total Duration";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.rdoChartTypeCheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(26, 20);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "No. Activities";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.rdoChartTypeCheckedChanged);
			// 
			// rdoGroupWeekly
			// 
			this.rdoGroupWeekly.Location = new System.Drawing.Point(106, 20);
			this.rdoGroupWeekly.Name = "rdoGroupWeekly";
			this.rdoGroupWeekly.Size = new System.Drawing.Size(72, 24);
			this.rdoGroupWeekly.TabIndex = 1;
			this.rdoGroupWeekly.Text = "Weekly";
			this.rdoGroupWeekly.UseVisualStyleBackColor = true;
			this.rdoGroupWeekly.CheckedChanged += new System.EventHandler(this.RdoGroupCheckedChanged);
			// 
			// rdoGroupMonthly
			// 
			this.rdoGroupMonthly.Checked = true;
			this.rdoGroupMonthly.Location = new System.Drawing.Point(25, 20);
			this.rdoGroupMonthly.Name = "rdoGroupMonthly";
			this.rdoGroupMonthly.Size = new System.Drawing.Size(75, 24);
			this.rdoGroupMonthly.TabIndex = 0;
			this.rdoGroupMonthly.TabStop = true;
			this.rdoGroupMonthly.Text = "Monthly";
			this.rdoGroupMonthly.UseVisualStyleBackColor = true;
			this.rdoGroupMonthly.CheckedChanged += new System.EventHandler(this.RdoGroupCheckedChanged);
			// 
			// dpFrom
			// 
			this.dpFrom.CustomFormat = "dd/MM/yyyy";
			this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpFrom.Location = new System.Drawing.Point(25, 20);
			this.dpFrom.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
			this.dpFrom.Name = "dpFrom";
			this.dpFrom.Size = new System.Drawing.Size(95, 20);
			this.dpFrom.TabIndex = 7;
			this.dpFrom.ValueChanged += new System.EventHandler(this.DpValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(122, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 10);
			this.label4.TabIndex = 10;
			this.label4.Text = "-";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dpTo
			// 
			this.dpTo.CustomFormat = "dd/MM/yyyy";
			this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpTo.Location = new System.Drawing.Point(151, 20);
			this.dpTo.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
			this.dpTo.Name = "dpTo";
			this.dpTo.Size = new System.Drawing.Size(95, 20);
			this.dpTo.TabIndex = 9;
			this.dpTo.ValueChanged += new System.EventHandler(this.DpValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoGroupMonthly);
			this.groupBox1.Controls.Add(this.rdoGroupWeekly);
			this.groupBox1.Location = new System.Drawing.Point(11, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(187, 83);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Grouping";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton5);
			this.groupBox2.Location = new System.Drawing.Point(204, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(420, 83);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chart Source Type";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.dpTo);
			this.groupBox3.Controls.Add(this.dpFrom);
			this.groupBox3.Location = new System.Drawing.Point(630, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(265, 83);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Period";
			// 
			// UserCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(907, 506);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.zedGraph);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(923, 544);
			this.Name = "UserCharts";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Performance Charts";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dpTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dpFrom;
		private System.Windows.Forms.RadioButton rdoGroupMonthly;
		private System.Windows.Forms.RadioButton rdoGroupWeekly;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private ZedGraph.ZedGraphControl zedGraph;
	}
}
