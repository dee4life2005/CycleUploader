﻿/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/04/2013
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CycleUploader
{
	/// <summary>
	/// Description of LineSeparator.
	/// </summary>
	public partial class LineSeparator : UserControl
	{
		public LineSeparator()
		{
			InitializeComponent();
			this.Paint += new PaintEventHandler(LineSeparator_Paint);
			this.MaximumSize = new Size(2000, 2);
			this.MinimumSize = new Size(0, 2);
			this.Width = 350;
		}
		
		private void LineSeparator_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point(this.Width, 0));
			g.DrawLine(Pens.White, new Point(0, 1), new Point(this.Width, 1));
		}
	}
}
