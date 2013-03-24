/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/02/2013
 * Time: 11:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CycleUploader
{
	/// <summary>
	/// Description of FullscreenMap.
	/// </summary>
	public partial class FullscreenMap : Form
	{
		private string _url;
		
		public FullscreenMap(string path)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_url = path;
		}
		
		void FullscreenMapLoad(object sender, EventArgs e)
		{
			webBrowser1.Navigate(_url);
		}
	}
}
