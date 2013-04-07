/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/04/2013
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CycleUploader
{
	/// <summary>
	/// Description of ComboBoxItem.
	/// </summary>
	public class ComboboxItem
	{
	    public string Text { get; set; }
	    public int Value { get; set; }
	    
	    public ComboboxItem(int val, string label)
	    {
	    	Text = label;
	    	Value = val;
	    }
	
	    public override string ToString()
	    {
	        return Text;
	    }
	}
}
