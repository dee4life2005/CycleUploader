/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/02/2013
 * Time: 11:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace CycleUploader
{
	/// <summary>
	/// Description of FullscreenChart.
	/// </summary>
	public partial class FullscreenChart : Form
	{
		public FullscreenChart()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void setGraphPane(GraphPane gp)
		{
			this.zedChart.GraphPane = gp;
		}
	}
}
