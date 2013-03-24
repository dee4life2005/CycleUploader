/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 23/03/2013
 * Time: 10:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CycleUploader
{
	/// <summary>
	/// Description of ToolsOptions.
	/// </summary>
	public partial class ToolsOptions : Form
	{
		public int _autopause;
		
		public ToolsOptions(int autoPause)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_autopause = autoPause;
			settingAutoPause.Text = _autopause.ToString();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			_autopause = Convert.ToInt32(settingAutoPause.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
