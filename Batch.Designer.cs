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
			this.colProcess = new System.Windows.Forms.ColumnHeader();
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
			this.cbkProviderRideWithGps = new System.Windows.Forms.CheckBox();
			this.cbkProviderGarmin = new System.Windows.Forms.CheckBox();
			this.cbkProviderStrava = new System.Windows.Forms.CheckBox();
			this.cbkProviderRunkeeper = new System.Windows.Forms.CheckBox();
			this.pnlProviders = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lineSeparator4 = new CycleUploader.LineSeparator();
			this.pnlProviders.SuspendLayout();
			this.panel1.SuspendLayout();
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
									this.colProcess,
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
			this.lstBatchFiles.MultiSelect = false;
			this.lstBatchFiles.Name = "lstBatchFiles";
			this.lstBatchFiles.ShowGroups = false;
			this.lstBatchFiles.ShowItemToolTips = true;
			this.lstBatchFiles.Size = new System.Drawing.Size(864, 243);
			this.lstBatchFiles.SmallImageList = this.imageList1;
			this.lstBatchFiles.TabIndex = 0;
			this.lstBatchFiles.UseCompatibleStateImageBehavior = false;
			this.lstBatchFiles.View = System.Windows.Forms.View.Details;
			this.lstBatchFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LstBatchFilesMouseClick);
			// 
			// colProcess
			// 
			this.colProcess.Text = "";
			this.colProcess.Width = 20;
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
			// columnHeader3
			// 
			this.columnHeader3.Text = "";
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
			this.btnUploadRides.Location = new System.Drawing.Point(753, 8);
			this.btnUploadRides.Name = "btnUploadRides";
			this.btnUploadRides.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnUploadRides.Size = new System.Drawing.Size(123, 33);
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
			this.prgProgress.Location = new System.Drawing.Point(12, 292);
			this.prgProgress.Name = "prgProgress";
			this.prgProgress.Size = new System.Drawing.Size(864, 19);
			this.prgProgress.TabIndex = 3;
			// 
			// prgStatus
			// 
			this.prgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.prgStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prgStatus.Location = new System.Drawing.Point(12, 317);
			this.prgStatus.Multiline = true;
			this.prgStatus.Name = "prgStatus";
			this.prgStatus.ReadOnly = true;
			this.prgStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.prgStatus.Size = new System.Drawing.Size(437, 90);
			this.prgStatus.TabIndex = 4;
			// 
			// cbkProviderRideWithGps
			// 
			this.cbkProviderRideWithGps.AutoSize = true;
			this.cbkProviderRideWithGps.Image = ((System.Drawing.Image)(resources.GetObject("cbkProviderRideWithGps.Image")));
			this.cbkProviderRideWithGps.Location = new System.Drawing.Point(243, 3);
			this.cbkProviderRideWithGps.Name = "cbkProviderRideWithGps";
			this.cbkProviderRideWithGps.Padding = new System.Windows.Forms.Padding(5);
			this.cbkProviderRideWithGps.Size = new System.Drawing.Size(178, 42);
			this.cbkProviderRideWithGps.TabIndex = 4;
			this.cbkProviderRideWithGps.Text = " ";
			this.cbkProviderRideWithGps.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.cbkProviderRideWithGps.UseVisualStyleBackColor = true;
			this.cbkProviderRideWithGps.CheckStateChanged += new System.EventHandler(this.CbkProviderCheckStateChanged);
			// 
			// cbkProviderGarmin
			// 
			this.cbkProviderGarmin.AutoSize = true;
			this.cbkProviderGarmin.Image = ((System.Drawing.Image)(resources.GetObject("cbkProviderGarmin.Image")));
			this.cbkProviderGarmin.Location = new System.Drawing.Point(166, 3);
			this.cbkProviderGarmin.Name = "cbkProviderGarmin";
			this.cbkProviderGarmin.Padding = new System.Windows.Forms.Padding(5);
			this.cbkProviderGarmin.Size = new System.Drawing.Size(71, 42);
			this.cbkProviderGarmin.TabIndex = 3;
			this.cbkProviderGarmin.Text = " ";
			this.cbkProviderGarmin.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.cbkProviderGarmin.UseVisualStyleBackColor = true;
			this.cbkProviderGarmin.CheckStateChanged += new System.EventHandler(this.CbkProviderCheckStateChanged);
			// 
			// cbkProviderStrava
			// 
			this.cbkProviderStrava.AutoSize = true;
			this.cbkProviderStrava.Image = ((System.Drawing.Image)(resources.GetObject("cbkProviderStrava.Image")));
			this.cbkProviderStrava.Location = new System.Drawing.Point(89, 3);
			this.cbkProviderStrava.Name = "cbkProviderStrava";
			this.cbkProviderStrava.Padding = new System.Windows.Forms.Padding(5);
			this.cbkProviderStrava.Size = new System.Drawing.Size(71, 42);
			this.cbkProviderStrava.TabIndex = 1;
			this.cbkProviderStrava.Text = " ";
			this.cbkProviderStrava.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.cbkProviderStrava.UseVisualStyleBackColor = true;
			this.cbkProviderStrava.CheckStateChanged += new System.EventHandler(this.CbkProviderCheckStateChanged);
			// 
			// cbkProviderRunkeeper
			// 
			this.cbkProviderRunkeeper.AutoSize = true;
			this.cbkProviderRunkeeper.Image = ((System.Drawing.Image)(resources.GetObject("cbkProviderRunkeeper.Image")));
			this.cbkProviderRunkeeper.Location = new System.Drawing.Point(12, 3);
			this.cbkProviderRunkeeper.Name = "cbkProviderRunkeeper";
			this.cbkProviderRunkeeper.Padding = new System.Windows.Forms.Padding(5);
			this.cbkProviderRunkeeper.Size = new System.Drawing.Size(71, 42);
			this.cbkProviderRunkeeper.TabIndex = 0;
			this.cbkProviderRunkeeper.Text = " ";
			this.cbkProviderRunkeeper.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.cbkProviderRunkeeper.UseVisualStyleBackColor = true;
			this.cbkProviderRunkeeper.CheckStateChanged += new System.EventHandler(this.CbkProviderCheckStateChanged);
			// 
			// pnlProviders
			// 
			this.pnlProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlProviders.BackColor = System.Drawing.SystemColors.Control;
			this.pnlProviders.Controls.Add(this.cbkProviderRunkeeper);
			this.pnlProviders.Controls.Add(this.cbkProviderRideWithGps);
			this.pnlProviders.Controls.Add(this.cbkProviderStrava);
			this.pnlProviders.Controls.Add(this.cbkProviderGarmin);
			this.pnlProviders.Location = new System.Drawing.Point(452, 317);
			this.pnlProviders.Margin = new System.Windows.Forms.Padding(0);
			this.pnlProviders.Name = "pnlProviders";
			this.pnlProviders.Size = new System.Drawing.Size(424, 90);
			this.pnlProviders.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.Controls.Add(this.lineSeparator4);
			this.panel1.Controls.Add(this.btnUploadRides);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 410);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(888, 45);
			this.panel1.TabIndex = 17;
			// 
			// lineSeparator4
			// 
			this.lineSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator4.Location = new System.Drawing.Point(0, 0);
			this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
			this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
			this.lineSeparator4.Name = "lineSeparator4";
			this.lineSeparator4.Size = new System.Drawing.Size(888, 2);
			this.lineSeparator4.TabIndex = 17;
			// 
			// Batch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 455);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlProviders);
			this.Controls.Add(this.prgStatus);
			this.Controls.Add(this.prgProgress);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstBatchFiles);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(904, 436);
			this.Name = "Batch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Process Batch of Rides";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchFormClosing);
			this.Shown += new System.EventHandler(this.BatchShown);
			this.pnlProviders.ResumeLayout(false);
			this.pnlProviders.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CycleUploader.LineSeparator lineSeparator4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader colProcess;
		private System.Windows.Forms.Panel pnlProviders;
		private System.Windows.Forms.CheckBox cbkProviderRunkeeper;
		private System.Windows.Forms.CheckBox cbkProviderStrava;
		private System.Windows.Forms.CheckBox cbkProviderGarmin;
		private System.Windows.Forms.CheckBox cbkProviderRideWithGps;
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
