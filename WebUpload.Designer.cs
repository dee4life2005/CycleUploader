/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/02/2013
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TCX_Parser
{
	partial class WebUpload
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
			this.btnRunkeeperLoginTest = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.lblCode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblToken = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnRunkeeperLoginTest
			// 
			this.btnRunkeeperLoginTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunkeeperLoginTest.Location = new System.Drawing.Point(503, 12);
			this.btnRunkeeperLoginTest.Name = "btnRunkeeperLoginTest";
			this.btnRunkeeperLoginTest.Size = new System.Drawing.Size(135, 23);
			this.btnRunkeeperLoginTest.TabIndex = 0;
			this.btnRunkeeperLoginTest.Text = "Runkeeper Login Test";
			this.btnRunkeeperLoginTest.UseVisualStyleBackColor = true;
			this.btnRunkeeperLoginTest.Click += new System.EventHandler(this.BtnRunkeeperLoginTestClick);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new System.Drawing.Point(1, 2);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.Size = new System.Drawing.Size(392, 361);
			this.webBrowser1.TabIndex = 1;
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
			// 
			// lblCode
			// 
			this.lblCode.Location = new System.Drawing.Point(399, 61);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(255, 23);
			this.lblCode.TabIndex = 2;
			this.lblCode.Text = "-";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(399, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(255, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Code";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(399, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(255, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Token";
			// 
			// lblToken
			// 
			this.lblToken.Location = new System.Drawing.Point(399, 107);
			this.lblToken.Name = "lblToken";
			this.lblToken.Size = new System.Drawing.Size(255, 23);
			this.lblToken.TabIndex = 5;
			this.lblToken.Text = "-";
			// 
			// WebUpload
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 362);
			this.Controls.Add(this.lblToken);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblCode);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.btnRunkeeperLoginTest);
			this.Name = "WebUpload";
			this.Text = "WebUpload";
			this.Load += new System.EventHandler(this.WebUploadLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblToken;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button btnRunkeeperLoginTest;
	}
}
