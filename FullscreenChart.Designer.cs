/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/02/2013
 * Time: 11:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class FullscreenChart
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullscreenChart));
			this.zedChart = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedChart
			// 
			this.zedChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedChart.Location = new System.Drawing.Point(0, 0);
			this.zedChart.Name = "zedChart";
			this.zedChart.ScrollGrace = 0D;
			this.zedChart.ScrollMaxX = 0D;
			this.zedChart.ScrollMaxY = 0D;
			this.zedChart.ScrollMaxY2 = 0D;
			this.zedChart.ScrollMinX = 0D;
			this.zedChart.ScrollMinY = 0D;
			this.zedChart.ScrollMinY2 = 0D;
			this.zedChart.Size = new System.Drawing.Size(284, 262);
			this.zedChart.TabIndex = 0;
			// 
			// FullscreenChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.zedChart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FullscreenChart";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chart";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);
		}
		private ZedGraph.ZedGraphControl zedChart;
	}
}
