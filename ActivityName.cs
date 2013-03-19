/*
 * Created by SharpDevelop.
 * User: steve
 * Date: 18/03/2013
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TCX_Parser
{
	/// <summary>
	/// Description of ActivityName.
	/// </summary>
	public partial class ActivityName : Form
	{
		public string _activityName;
		public string _activityNotes;
		
		public ActivityName(string activityName, string activityNotes)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_activityName = "";
			_activityNotes = "";
			txtActivityName.Text = activityName;
			txtActivityNotes.Text = activityNotes;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			_activityName = txtActivityName.Text;
			_activityNotes = txtActivityNotes.Text;
			this.DialogResult = DialogResult.OK;	
		}
		
		void TxtActivityNameKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return){
				BtnApplyClick(sender, e);
			}
		}
		
		void ActivityNameLoad(object sender, EventArgs e)
		{
			this.ActiveControl = txtActivityName;
		}
	}
}
