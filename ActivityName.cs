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

namespace CycleUploader
{
	/// <summary>
	/// Description of ActivityName.
	/// </summary>
	public partial class ActivityName : Form
	{
		public string _activityName;
		public string _activityNotes;
		public bool _activityIsCommute;
		public bool _activityIsStationaryTrainer;
		
		public ActivityName(string activityName, string activityNotes, bool isCommute, bool isStationaryTrainer)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_activityName = activityName;
			_activityNotes = activityNotes;
			_activityIsCommute = isCommute;
			_activityIsStationaryTrainer = isStationaryTrainer;
			txtActivityName.Text = activityName;
			txtActivityNotes.Text = activityNotes;
			cbkIsCommute.Checked = isCommute;
			cbkIsStationaryTrainer.Checked = isStationaryTrainer;
			
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			_activityName = txtActivityName.Text;
			_activityNotes = txtActivityNotes.Text;
			_activityIsCommute = cbkIsCommute.Checked;
			_activityIsStationaryTrainer = cbkIsStationaryTrainer.Checked;
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
