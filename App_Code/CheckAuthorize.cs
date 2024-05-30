using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for CheckAuthorize
/// Author : Surasak.rit
/// Create date : 2016-11-14
/// Description : ใช้สำหรับตรวจสอบสิทธิผู้ร้องขอก่อนเข้าใช้งาน
/// </summary>
public class CheckAuthorize : IHttpModule, IRequiresSessionState 
{
	public CheckAuthorize()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public String ModuleName
    {
        get { return "CheckAuthorize"; }
    }

    public void Dispose()
    {
    }

    public void Init(HttpApplication context)
    {
        context.BeginRequest +=
            (new EventHandler(this.Application_BeginRequest));
        context.EndRequest +=
            (new EventHandler(this.Application_EndRequest));
    }
    /// <summary>
    /// Author      :   Surasak.rit
    /// Edit date   :   2016-11-14
    /// Description :   ใช้สำหรับตรวจสอบสิทธิผู้ร้องขอเข้าใช้งานหน้าเพจ
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void Application_BeginRequest(Object source,
         EventArgs e)
    {
        // Create HttpApplication and HttpContext objects to access
        // request and response properties.
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        context.SetSessionStateBehavior(SessionStateBehavior.Required);
        string filePath = context.Request.FilePath;
        string fileExtension = VirtualPathUtility.GetExtension(filePath);

        if (fileExtension.Equals(".aspx")) {
            if (filePath.Contains("/student/"))
            {
                Login _studentLogin = new Login("student");
                Login _staffLogin = new Login("staff");

                //if (!(_staffLogin.Authen.ToLower().Equals("true") || _studentLogin.Authen.ToLower().Equals("true")))
                if (!_studentLogin.Authen.ToLower().Equals("true"))
                    context.Response.Redirect(_studentLogin.UrlStudentLogin);
            }
            else if (filePath.Contains("/staff/")) 
            {
                Login _staffLogin = new Login("staff");
                if (!_staffLogin.Authen.ToLower().Equals("true"))
                {
                    context.Response.Redirect(_staffLogin.UrlStaffLogin);
                }
                else if ((_staffLogin.GetListFacultyAccess().Tables[0].Rows.Count.Equals(0) ||
                    !Check_Page_Authorize(_staffLogin.Username, _staffLogin.AccessFacultyId, filePath)) &&
                    !filePath.ToLower().Contains("/staff/default.aspx")
                    )
                {
                    string _url = Path.Combine(context.Request.ApplicationPath + "/modules/staff/Default.aspx").Replace("//", "/");
                    context.Response.Redirect(_url + "?msgid=1");
                }
                else
                {
                    HttpCookie _evaUserInfo = HttpContext.Current.Request.Cookies["evaUserInfo"];
                    if (_evaUserInfo == null)
                    {
                        _evaUserInfo = new HttpCookie("evaUserInfo");
                        _evaUserInfo.Values.Add("key", Utility.StringEncryption(_staffLogin.Username));
                        HttpContext.Current.Response.Cookies.Add(_evaUserInfo);
                    }
                    else
                    {
                        if (!_evaUserInfo.Values["key"].Equals(Utility.StringEncryption(_staffLogin.Username)))
                        {
                            _evaUserInfo.Expires = DateTime.Now.AddHours(-3);
                            context.Response.Cookies.Set(_evaUserInfo);
                            string _url = Path.Combine(context.Request.ApplicationPath + "/modules/staff/Default.aspx").Replace("//", "/");
                            context.Response.Redirect(_url);
                        }
                    }
                }
            }
        }
    }

    private bool Check_Page_Authorize(string username, string facid, string menuPath) {
        return DbConfiguration.ExecuteScalar("sp_evaCheckPageAuthorize", CommandType.StoredProcedure,
                new SqlParameter("username", username),
                new SqlParameter("facid", facid),
                new SqlParameter("path", menuPath)
            ).Equals(1);
    }
    private void Application_EndRequest(Object source, EventArgs e)
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        string filePath = context.Request.FilePath;
        string fileExtension = VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals(".aspx"))
        {

        }
    }
}