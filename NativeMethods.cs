/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/07/2011
 * Time: 12:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Runtime.InteropServices;

namespace CycleUploader
{
	// this class just wraps some Win32 stuffthat we're going to use
	internal class NativeMethods {
	    public const int HWND_BROADCAST = 0xffff;
	    public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
	    [DllImport("user32")]
	    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
	    [DllImport("user32")]
	    public static extern int RegisterWindowMessage(string message);
	}
}
