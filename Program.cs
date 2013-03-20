/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 22/02/2013
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

namespace TCX_Parser
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		private static string versionStr = "1.0.6.0";
		private static string versionDate = "20/03/2013";
		private static string versionAuthor = "Steven Saunders";
		
		public static MainForm mf = null;
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mf = new MainForm(versionStr, versionDate, versionAuthor);
			Application.Run(mf);
		}
		
	}
}
