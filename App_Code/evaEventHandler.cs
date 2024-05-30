using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoHandler
/// </summary>
public class evaEventHandler : IHttpModule
{
    public evaEventHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        throw new NotImplementedException();
    }


    public static void NoDocumentSelected(HttpContext context)
    {
        context.Response.Redirect((context.Request.ApplicationPath + "/modules/staff/Default.aspx").Replace("//", "/"));
    }
}