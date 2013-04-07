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

namespace CycleUploader
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		private static string versionStr = "1.0.25.0";
		private static string versionDate = "05/04/2013";
		private static string versionAuthor = "Steven Saunders";
		private static long db_version = 7;
		
		public static MainForm mf = null;
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mf = new MainForm(versionStr, versionDate, versionAuthor, db_version);
			Application.Run(mf);
		}
		
	}
}
