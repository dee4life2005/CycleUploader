/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/03/2013
 * Time: 09:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CycleUploader
{
	partial class Batch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batch));
			this.fdBatch = new System.Windows.Forms.OpenFileDialog();
			this.lstBatchFiles = new System.Windows.Forms.ListView();
			this.colFileName = new System.Windows.Forms.ColumnHeader();
			this.colFileDate = new System.Windows.Forms.ColumnHeader();
			this.colActivityName = new System.Windows.Forms.ColumnHeader();
			this.colActivityNotes = new System.Windows.Forms.ColumnHeader();
			this.colIsCommute = new System.Windows.Forms.ColumnHeader();
			this.colIsTrainer = new System.Windows.Forms.ColumnHeader();
			this.colRunkeeper = new System.Windows.Forms.ColumnHeader("runkeeper16.png");
			this.colStrava = new System.Windows.Forms.ColumnHeader("strava16.png");
			this.colGarmin = new System.Windows.Forms.ColumnHeader("garmin16.png");
			this.colRWGPS = new System.Windows.Forms.ColumnHeader("ridewithgps16.png");
			this.colFilePath = new System.Windows.Forms.ColumnHeader();
			this.colAlreadyProcessed = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.btnUploadRides = new System.Windows.Forms.Button();
			this.imgListUploadStatus = new System.Windows.Forms.ImageList(this.components);
			this.prgProgress = new System.Windows.Forms.ProgressBar();
			this.prgStatus = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lstBatchFiles
			// 
			this.lstBatchFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstBatchFiles.BackColor = System.Drawing.SystemColors.Window;
			this.lstBatchFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBatchFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colFileName,
									this.colFileDate,
									this.colActivityName,
									this.colActivityNotes,
									this.colIsCommute,
									this.colIsTrainer,
									this.colRunkeeper,
									this.colStrava,
									this.colGarmin,
									this.colRWGPS,
									this.colFilePath,
									this.colAlreadyProcessed,
									this.columnHeader3});
			this.lstBatchFiles.FullRowSelect = true;
			this.lstBatchFiles.GridLines = true;
			this.lstBatchFiles.Location = new System.Drawing.Point(12, 43);
			this.lstBatchFiles.Name = "lstBatchFiles";
			this.lstBatchFiles.ShowItemToolTips = true;
			this.lstBatchFiles.Size = new System.Drawing.Size(831, 242);
			this.lstBatchFiles.SmallImageList = this.imageList1;
			this.lstBatchFiles.TabIndex = 0;
			this.lstBatchFiles.UseCompatibleStateImageBehavior = false;
			this.lstBatchFiles.View = System.Windows.Forms.View.Details;
			this.lstBatchFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LstBatchFilesMouseClick);
			// 
			// colFileName
			// 
			this.colFileName.Text = "File Name";
			this.colFileName.Width = 137;
			// 
			// colFileDate
			// 
			this.colFileDate.Text = "File Date";
			this.colFileDate.Width = 102;
			// 
			// colActivityName
			// 
			this.colActivityName.Text = "Activity Name";
			this.colActivityName.Width = 126;
			// 
			// colActivityNotes
			// 
			this.colActivityNotes.Text = "Notes";
			this.colActivityNotes.Width = 203;
			// 
			// colIsCommute
			// 
			this.colIsCommute.Text = "Commute";
			this.colIsCommute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colIsCommute.Width = 58;
			// 
			// colIsTrainer
			// 
			this.colIsTrainer.Text = "Trainer";
			this.colIsTrainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colIsTrainer.Width = 58;
			// 
			// colRunkeeper
			// 
			this.colRunkeeper.Text = "";
			this.colRunkeeper.Width = 32;
			// 
			// colStrava
			// 
			this.colStrava.Text = "";
			this.colStrava.Width = 32;
			// 
			// colGarmin
			// 
			this.colGarmin.Text = "";
			this.colGarmin.Width = 32;
			// 
			// colRWGPS
			// 
			this.colRWGPS.Text = "";
			this.colRWGPS.Width = 32;
			// 
			// colFilePath
			// 
			this.colFilePath.Text = "";
			this.colFilePath.Width = 0;
			// 
			// colAlreadyProcessed
			// 
			this.colAlreadyProcessed.Text = "";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "runkeeper16.png");
			this.imageList1.Images.SetKeyName(1, "strava16.png");
			this.imageList1.Images.SetKeyName(2, "garmin16.png");
			this.imageList1.Images.SetKeyName(3, "ridewithgps16.png");
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(380, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Right-Click to change activity name and/or notes";
			// 
			// btnUploadRides
			// 
			this.btnUploadRides.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUploadRides.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadRides.Image")));
			this.btnUploadRides.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUploadRides.Location = new System.Drawing.Point(720, 291);
			this.btnUploadRides.Name = "btnUploadRides";
			this.btnUploadRides.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnUploadRides.Size = new System.Drawing.Size(123, 65);
			this.btnUploadRides.TabIndex = 2;
			this.btnUploadRides.Text = "Upload Rides ...";
			this.btnUploadRides.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnUploadRides.UseVisualStyleBackColor = true;
			this.btnUploadRides.Click += new System.EventHandler(this.BtnUploadRidesClick);
			// 
			// imgListUploadStatus
			// 
			this.imgListUploadStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListUploadStatus.ImageStream")));
			this.imgListUploadStatus.TransparentColor = System.Drawing.Color.Transparent;
			this.imgListUploadStatus.Images.SetKeyName(0, "failure-icon.png");
			this.imgListUploadStatus.Images.SetKeyName(1, "success-icon.png");
			this.imgListUploadStatus.Images.SetKeyName(2, "tcmIconUploadRide.png");
			// 
			// prgProgress
			// 
			this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.prgProgress.Location = new System.Drawing.Point(12, 291);
			this.prgProgress.Name = "prgProgress";
			this.prgProgress.Size = new System.Drawing.Size(697, 15);
			this.prgProgress.TabIndex = 3;
			// 
			// prgStatus
			// 
			this.prgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.prgStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prgStatus.Location = new System.Drawing.Point(12, 314);
			this.prgStatus.Multiline = true;
			this.prgStatus.Name = "prgStatus";
			this.prgStatus.ReadOnly = true;
			this.prgStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.prgStatus.Size = new System.Drawing.Size(697, 42);
			this.prgStatus.TabIndex = 4;
			// 
			// Batch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 363);
			this.Controls.Add(this.prgStatus);
			this.Controls.Add(this.prgProgress);
			this.Controls.Add(this.btnUploadRides);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstBatchFiles);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(871, 401);
			this.Name = "Batch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Process Batch of Rides";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchFormClosing);
			this.Shown += new System.EventHandler(this.BatchShown);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader colIsTrainer;
		private System.Windows.Forms.ColumnHeader colAlreadyProcessed;
		private System.Windows.Forms.TextBox prgStatus;
		private System.Windows.Forms.ProgressBar prgProgress;
		private System.Windows.Forms.ImageList imgListUploadStatus;
		private System.Windows.Forms.ColumnHeader colIsCommute;
		private System.Windows.Forms.Button btnUploadRides;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader colFilePath;
		private System.Windows.Forms.ColumnHeader colRWGPS;
		private System.Windows.Forms.ColumnHeader colGarmin;
		private System.Windows.Forms.ColumnHeader colStrava;
		private System.Windows.Forms.ColumnHeader colRunkeeper;
		private System.Windows.Forms.ColumnHeader colActivityNotes;
		private System.Windows.Forms.ColumnHeader colActivityName;
		private System.Windows.Forms.ColumnHeader colFileDate;
		private System.Windows.Forms.ColumnHeader colFileName;
		private System.Windows.Forms.ListView lstBatchFiles;
		private System.Windows.Forms.OpenFileDialog fdBatch;
	}
}
