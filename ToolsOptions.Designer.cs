/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 23/03/2013
 * Time: 10:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class ToolsOptions
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsOptions));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.settingAutoPause = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.numZ5high = new System.Windows.Forms.NumericUpDown();
			this.numZ4high = new System.Windows.Forms.NumericUpDown();
			this.numZ3high = new System.Windows.Forms.NumericUpDown();
			this.numZ2high = new System.Windows.Forms.NumericUpDown();
			this.numZ1high = new System.Windows.Forms.NumericUpDown();
			this.numZ5low = new System.Windows.Forms.NumericUpDown();
			this.numZ4low = new System.Windows.Forms.NumericUpDown();
			this.numZ3low = new System.Windows.Forms.NumericUpDown();
			this.numZ2low = new System.Windows.Forms.NumericUpDown();
			this.numZ1low = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.settingAutoPause)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numZ5high)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ4high)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ3high)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ2high)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ1high)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ5low)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ4low)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ3low)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ2low)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ1low)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 238);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(258, 238);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 6;
			this.btnApply.Text = "Apply...";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 18);
			this.label1.TabIndex = 8;
			this.label1.Text = "Auto-Pause Threshold (mph)";
			// 
			// settingAutoPause
			// 
			this.settingAutoPause.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingAutoPause.Location = new System.Drawing.Point(246, 19);
			this.settingAutoPause.Maximum = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.settingAutoPause.Name = "settingAutoPause";
			this.settingAutoPause.Size = new System.Drawing.Size(41, 22);
			this.settingAutoPause.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.numZ5high);
			this.groupBox1.Controls.Add(this.numZ4high);
			this.groupBox1.Controls.Add(this.numZ3high);
			this.groupBox1.Controls.Add(this.numZ2high);
			this.groupBox1.Controls.Add(this.numZ1high);
			this.groupBox1.Controls.Add(this.numZ5low);
			this.groupBox1.Controls.Add(this.numZ4low);
			this.groupBox1.Controls.Add(this.numZ3low);
			this.groupBox1.Controls.Add(this.numZ2low);
			this.groupBox1.Controls.Add(this.numZ1low);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 75);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(323, 157);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "      Heart Rate Zones";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(221, 121);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(19, 23);
			this.label11.TabIndex = 26;
			this.label11.Text = "-";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(221, 98);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(19, 23);
			this.label10.TabIndex = 25;
			this.label10.Text = "-";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(221, 75);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(19, 23);
			this.label9.TabIndex = 24;
			this.label9.Text = "-";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(221, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(19, 23);
			this.label8.TabIndex = 23;
			this.label8.Text = "-";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(221, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(19, 23);
			this.label7.TabIndex = 22;
			this.label7.Text = "-";
			// 
			// numZ5high
			// 
			this.numZ5high.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ5high.Location = new System.Drawing.Point(246, 119);
			this.numZ5high.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ5high.Name = "numZ5high";
			this.numZ5high.Size = new System.Drawing.Size(41, 22);
			this.numZ5high.TabIndex = 21;
			// 
			// numZ4high
			// 
			this.numZ4high.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ4high.Location = new System.Drawing.Point(246, 96);
			this.numZ4high.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ4high.Name = "numZ4high";
			this.numZ4high.Size = new System.Drawing.Size(41, 22);
			this.numZ4high.TabIndex = 20;
			// 
			// numZ3high
			// 
			this.numZ3high.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ3high.Location = new System.Drawing.Point(246, 73);
			this.numZ3high.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ3high.Name = "numZ3high";
			this.numZ3high.Size = new System.Drawing.Size(41, 22);
			this.numZ3high.TabIndex = 19;
			// 
			// numZ2high
			// 
			this.numZ2high.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ2high.Location = new System.Drawing.Point(246, 50);
			this.numZ2high.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ2high.Name = "numZ2high";
			this.numZ2high.Size = new System.Drawing.Size(41, 22);
			this.numZ2high.TabIndex = 18;
			// 
			// numZ1high
			// 
			this.numZ1high.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ1high.Location = new System.Drawing.Point(246, 27);
			this.numZ1high.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ1high.Name = "numZ1high";
			this.numZ1high.Size = new System.Drawing.Size(41, 22);
			this.numZ1high.TabIndex = 17;
			// 
			// numZ5low
			// 
			this.numZ5low.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ5low.Location = new System.Drawing.Point(169, 119);
			this.numZ5low.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ5low.Name = "numZ5low";
			this.numZ5low.Size = new System.Drawing.Size(41, 22);
			this.numZ5low.TabIndex = 16;
			// 
			// numZ4low
			// 
			this.numZ4low.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ4low.Location = new System.Drawing.Point(169, 96);
			this.numZ4low.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ4low.Name = "numZ4low";
			this.numZ4low.Size = new System.Drawing.Size(41, 22);
			this.numZ4low.TabIndex = 15;
			// 
			// numZ3low
			// 
			this.numZ3low.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ3low.Location = new System.Drawing.Point(169, 73);
			this.numZ3low.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ3low.Name = "numZ3low";
			this.numZ3low.Size = new System.Drawing.Size(41, 22);
			this.numZ3low.TabIndex = 14;
			// 
			// numZ2low
			// 
			this.numZ2low.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ2low.Location = new System.Drawing.Point(169, 50);
			this.numZ2low.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ2low.Name = "numZ2low";
			this.numZ2low.Size = new System.Drawing.Size(41, 22);
			this.numZ2low.TabIndex = 13;
			// 
			// numZ1low
			// 
			this.numZ1low.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numZ1low.Location = new System.Drawing.Point(169, 27);
			this.numZ1low.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numZ1low.Name = "numZ1low";
			this.numZ1low.Size = new System.Drawing.Size(41, 22);
			this.numZ1low.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(22, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(130, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Zone 5 - Anaerobic";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(22, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(130, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "Zone 4 - Threshold";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(22, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Zone 3 - Tempo";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(22, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Zone 2 - Moderate";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(22, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Zone 1 - Endurance";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.settingAutoPause);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(321, 52);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(6, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// ToolsOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(347, 273);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ToolsOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Settings";
			this.Load += new System.EventHandler(this.ToolsOptionsLoad);
			((System.ComponentModel.ISupportInitialize)(this.settingAutoPause)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numZ5high)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ4high)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ3high)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ2high)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ1high)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ5low)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ4low)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ3low)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ2low)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZ1low)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numZ1low;
		private System.Windows.Forms.NumericUpDown numZ2low;
		private System.Windows.Forms.NumericUpDown numZ3low;
		private System.Windows.Forms.NumericUpDown numZ4low;
		private System.Windows.Forms.NumericUpDown numZ5low;
		private System.Windows.Forms.NumericUpDown numZ1high;
		private System.Windows.Forms.NumericUpDown numZ2high;
		private System.Windows.Forms.NumericUpDown numZ3high;
		private System.Windows.Forms.NumericUpDown numZ4high;
		private System.Windows.Forms.NumericUpDown numZ5high;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown settingAutoPause;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
	}
}
