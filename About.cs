/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 10/03/2013
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TCX_Parser
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public partial class About : Form
	{
		private string _versionStr;
		private string _versionDate;
		private string _versionAuthor;
		
		public About(string versionStr, string versionDate, string versionAuthor)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_versionStr = versionStr;
			_versionDate = versionDate;
			_versionAuthor = versionAuthor;
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		void AboutLoad(object sender, EventArgs e)
		{
			lblVersionStr.Text = "v " + _versionStr;
		}
	}
}
