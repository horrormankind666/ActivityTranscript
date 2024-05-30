using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for HtmlHelper
/// </summary>
public class HtmlHelper
{
	public HtmlHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string Option(string text, string value, bool selected = false) {
        return new StringBuilder().AppendFormat(
            "<option value='{0}'{1}>{2}</option>", 
            value, 
            selected ? " selected='selected'" : "", 
            text
            ).ToString();
    }
}