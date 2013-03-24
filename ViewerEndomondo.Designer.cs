/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 12:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class ViewerEndomondo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerEndomondo));
			this.label15 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlProfile = new System.Windows.Forms.GroupBox();
			this.wbSummaryWidget = new System.Windows.Forms.WebBrowser();
			this.lblTotalActivities = new System.Windows.Forms.Label();
			this.pnlActivities = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstActivities = new ListViewNF.ListViewNF();
			this.colId = new System.Windows.Forms.ColumnHeader();
			this.colDateTime = new System.Windows.Forms.ColumnHeader();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colDistance = new System.Windows.Forms.ColumnHeader();
			this.colDuration = new System.Windows.Forms.ColumnHeader();
			this.colAvgSpeed = new System.Windows.Forms.ColumnHeader();
			this.colAvgHeart = new System.Windows.Forms.ColumnHeader();
			this.colAvgCadence = new System.Windows.Forms.ColumnHeader();
			this.colCalories = new System.Windows.Forms.ColumnHeader();
			this.colMaxSpeed = new System.Windows.Forms.ColumnHeader();
			this.colMaxHeart = new System.Windows.Forms.ColumnHeader();
			this.colMaxAltitude = new System.Windows.Forms.ColumnHeader();
			this.colMinAltitude = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pnlProfile.SuspendLayout();
			this.pnlActivities.SuspendLayout();
			this.SuspendLayout();
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(43, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(264, 23);
			this.label15.TabIndex = 24;
			this.label15.Text = "Endomondo Profile";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(5, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 23;
			this.pictureBox1.TabStop = false;
			// 
			// pnlProfile
			// 
			this.pnlProfile.Controls.Add(this.wbSummaryWidget);
			this.pnlProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlProfile.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlProfile.Location = new System.Drawing.Point(12, 41);
			this.pnlProfile.Name = "pnlProfile";
			this.pnlProfile.Size = new System.Drawing.Size(500, 263);
			this.pnlProfile.TabIndex = 26;
			this.pnlProfile.TabStop = false;
			this.pnlProfile.Text = "Profile";
			// 
			// wbSummaryWidget
			// 
			this.wbSummaryWidget.AllowWebBrowserDrop = false;
			this.wbSummaryWidget.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbSummaryWidget.IsWebBrowserContextMenuEnabled = false;
			this.wbSummaryWidget.Location = new System.Drawing.Point(3, 16);
			this.wbSummaryWidget.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbSummaryWidget.Name = "wbSummaryWidget";
			this.wbSummaryWidget.ScriptErrorsSuppressed = true;
			this.wbSummaryWidget.ScrollBarsEnabled = false;
			this.wbSummaryWidget.Size = new System.Drawing.Size(494, 244);
			this.wbSummaryWidget.TabIndex = 0;
			this.wbSummaryWidget.WebBrowserShortcutsEnabled = false;
			// 
			// lblTotalActivities
			// 
			this.lblTotalActivities.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTotalActivities.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalActivities.Location = new System.Drawing.Point(611, 99);
			this.lblTotalActivities.Name = "lblTotalActivities";
			this.lblTotalActivities.Size = new System.Drawing.Size(79, 63);
			this.lblTotalActivities.TabIndex = 13;
			this.lblTotalActivities.Text = "0 Activities";
			this.lblTotalActivities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlActivities
			// 
			this.pnlActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlActivities.Controls.Add(this.label1);
			this.pnlActivities.Controls.Add(this.lstActivities);
			this.pnlActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlActivities.ForeColor = System.Drawing.Color.RoyalBlue;
			this.pnlActivities.Location = new System.Drawing.Point(12, 310);
			this.pnlActivities.Name = "pnlActivities";
			this.pnlActivities.Size = new System.Drawing.Size(823, 313);
			this.pnlActivities.TabIndex = 27;
			this.pnlActivities.TabStop = false;
			this.pnlActivities.Text = "Activities";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(817, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "Click Activity To View In Browser. note: you will have to log in to the Endomondo" +
			" website to view the activity unless it was made public.";
			// 
			// lstActivities
			// 
			this.lstActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colId,
									this.colDateTime,
									this.colName,
									this.colDistance,
									this.colDuration,
									this.colAvgSpeed,
									this.colAvgHeart,
									this.colAvgCadence,
									this.colCalories,
									this.colMaxSpeed,
									this.colMaxHeart,
									this.colMaxAltitude,
									this.colMinAltitude});
			this.lstActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstActivities.FullRowSelect = true;
			this.lstActivities.GridLines = true;
			this.lstActivities.HideSelection = false;
			this.lstActivities.Location = new System.Drawing.Point(3, 31);
			this.lstActivities.Name = "lstActivities";
			this.lstActivities.Size = new System.Drawing.Size(817, 279);
			this.lstActivities.TabIndex = 1;
			this.lstActivities.UseCompatibleStateImageBehavior = false;
			this.lstActivities.View = System.Windows.Forms.View.Details;
			this.lstActivities.SelectedIndexChanged += new System.EventHandler(this.LstActivitiesSelectedIndexChanged);
			// 
			// colId
			// 
			this.colId.Text = "Id";
			// 
			// colDateTime
			// 
			this.colDateTime.Text = "Date/Time";
			// 
			// colName
			// 
			this.colName.Text = "Name";
			// 
			// colDistance
			// 
			this.colDistance.DisplayIndex = 4;
			this.colDistance.Text = "Distance";
			// 
			// colDuration
			// 
			this.colDuration.DisplayIndex = 3;
			this.colDuration.Text = "Duration";
			// 
			// colAvgSpeed
			// 
			this.colAvgSpeed.Text = "Avg. Speed";
			this.colAvgSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgHeart
			// 
			this.colAvgHeart.Text = "Avg. Heart";
			this.colAvgHeart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colAvgCadence
			// 
			this.colAvgCadence.Text = "Avg. Cadence";
			this.colAvgCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colCalories
			// 
			this.colCalories.DisplayIndex = 9;
			this.colCalories.Text = "Calories";
			this.colCalories.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxSpeed
			// 
			this.colMaxSpeed.DisplayIndex = 10;
			this.colMaxSpeed.Text = "Max Speed";
			this.colMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxHeart
			// 
			this.colMaxHeart.DisplayIndex = 11;
			this.colMaxHeart.Text = "Max Heart";
			this.colMaxHeart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMaxAltitude
			// 
			this.colMaxAltitude.DisplayIndex = 8;
			this.colMaxAltitude.Text = "Alt. Max";
			this.colMaxAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// colMinAltitude
			// 
			this.colMinAltitude.Text = "Alt. Min";
			this.colMinAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ViewerEndomondo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(847, 635);
			this.Controls.Add(this.lblTotalActivities);
			this.Controls.Add(this.pnlActivities);
			this.Controls.Add(this.pnlProfile);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(863, 673);
			this.Name = "ViewerEndomondo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Endomondo Profile";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerEndomondoFormClosing);
			this.Shown += new System.EventHandler(this.ViewerEndomondoShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pnlProfile.ResumeLayout(false);
			this.pnlActivities.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.WebBrowser wbSummaryWidget;
		private System.Windows.Forms.ColumnHeader colMinAltitude;
		private System.Windows.Forms.ColumnHeader colMaxAltitude;
		private System.Windows.Forms.ColumnHeader colMaxHeart;
		private System.Windows.Forms.ColumnHeader colMaxSpeed;
		private System.Windows.Forms.ColumnHeader colCalories;
		private System.Windows.Forms.ColumnHeader colAvgCadence;
		private System.Windows.Forms.ColumnHeader colAvgHeart;
		private System.Windows.Forms.ColumnHeader colAvgSpeed;
		private System.Windows.Forms.ColumnHeader colDuration;
		private System.Windows.Forms.ColumnHeader colDistance;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colDateTime;
		private System.Windows.Forms.ColumnHeader colId;
		private System.Windows.Forms.ListView lstActivities;
		private System.Windows.Forms.GroupBox pnlActivities;
		private System.Windows.Forms.Label lblTotalActivities;
		private System.Windows.Forms.GroupBox pnlProfile;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
	}
}
