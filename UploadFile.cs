/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 05/03/2013
 * Time: 13:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace TCX_Parser
{
	/// <summary>
	/// Description of UploadFile.
	/// </summary>
	public class UploadFile
	{
	    public UploadFile()
	    {
	        ContentType = "application/octet-stream";
	    }
	    public string Name { get; set; }
	    public string Filename { get; set; }
	    public string ContentType { get; set; }
	    public Stream Stream { get; set; }
	}
}
