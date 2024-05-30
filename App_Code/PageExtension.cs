using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageExtension
/// </summary>
public static class PageExtension
{
    public static void ScriptsRegister(this Page _page, params string[] scripts)
    {
        PageConfiguration PageConfig = new PageConfiguration();
        var ScriptsObjcet = PageConfig.GetScripts();
        var ScriptIndex = _page.Header.Controls.FindControlsByTagName("script").Count() > 0 ? _page.Header.Controls.IndexOf(_page.Header.Controls.FindControlsByTagName("script").ToList()[0]) : 0;
        var AbsolutePath = _page.Server.MapPath(_page.Request.ApplicationPath);
        foreach (var scriptSet in scripts) 
        {
            if (ScriptsObjcet.Keys.Contains(scriptSet))
            foreach (var script in ScriptsObjcet[scriptSet])
            {
                foreach (var _file in Directory.GetFiles(AbsolutePath, FixFileUrl(script), SearchOption.AllDirectories))
                {
                    var tagScript = new HtmlGenericControl("script");
                    tagScript.Attributes.Add("type", "text/javascript");
                    tagScript.Attributes.Add("src", _page.ResolveUrl(_file.Replace(AbsolutePath, _page.Request.ApplicationPath)));
                    if (ScriptIndex == 0)
                        _page.Header.Controls.Add(tagScript);
                    else
                    {
                        _page.Header.Controls.AddAt(ScriptIndex, tagScript);
                        ScriptIndex++;
                    }
                }
            }
        }
    }
    public static void StylesRegister(this Page _page, params string[] styles)
    {
        PageConfiguration PageConfig = new PageConfiguration();
        var StylesObject = PageConfig.GetStyles();
        var StyleIndex = _page.Header.Controls.IndexOf(_page.Header.Controls.FindControlsByTagName("title").ToList()[0]) + 1;
        var AbsolutePath = _page.Server.MapPath(_page.Request.ApplicationPath);
        foreach (var scriptSet in styles)
        {
            if (StylesObject.Keys.Contains(scriptSet))
            foreach (var style in StylesObject[scriptSet])
            {
                foreach (var _file in Directory.GetFiles(AbsolutePath, FixFileUrl(style), SearchOption.AllDirectories))
                {
                    var tagStyle = new HtmlGenericControl("link");
                    tagStyle.Attributes.Add("type", "text/css");
                    tagStyle.Attributes.Add("href", _page.ResolveUrl(_file.Replace(AbsolutePath, _page.Request.ApplicationPath)));
                    tagStyle.Attributes.Add("rel", new FileInfo(_file).Extension.Equals(".less") ? "stylesheet/less" : "stylesheet");
                    _page.Header.Controls.AddAt(StyleIndex, tagStyle);
                    StyleIndex++;
                }
            }
        }
    }
    public static string ReslovePath(this Page _page, string filePath) 
    {
        return _page.ResolveUrl(
                (
                    _page.Request.ApplicationPath.EndsWith("/") ?
                    _page.Request.ApplicationPath :
                    _page.Request.ApplicationPath + "/"
                )
                + filePath);
    }
    public static string Banner(this Page _page)
    {
        StringBuilder _sb = new StringBuilder();
        Login _login;// = new Login("");
        string _logoutPath = string.Empty;
        StringBuilder _userPrivilage = new StringBuilder();
        string lblPrivilage = string.Empty;
        if (_page.Request.FilePath.Contains("/staff/"))
        {
            _login = new Login("staff");
            _logoutPath = _login.UrlStaffLogin;
            //DataSet _privilageDs = MasterDataDB.Sp_evaGetListUserPrivilage(_login.Username);
            DataSet _privilageDs = _login.GetListFacultyAccess();
            if (_login.AccessFacultyId.Equals("") && _privilageDs.Tables[0].Rows.Count > 0)
                _login.AccessFacultyId = _privilageDs.Tables[0].Rows[0]["id"].ToString();

            string _accessFac = string.Empty;
            if (!_login.AccessFacultyId.Equals(""))
            {
                DataRow _facInfo = _login.GetListFacultyAccess().Tables[0].Select("id='" + _login.AccessFacultyId + "'").First();
                _accessFac = _facInfo["facultyCode"].ToString() + " - " + _facInfo["nameTh"].ToString();
            }


            if(_privilageDs.Tables[0].Rows.Count.Equals(0))
                lblPrivilage = @"<div style='font-size: small;'>ไม่พบสิทธิ์การเข้าใช้งาน</div>";
            else
                lblPrivilage = string.Format(@"<div style='font-size: small;'>สิทธิ์ <span class='selected-fac'>{0}</span></div>", _accessFac);

            
                

            _userPrivilage.Append("<li class='dropdown-header'>สิทธิ์การเข้าใช้งาน</li>");
            //foreach (DataRow _privilage in _privilageDs.Tables[0].Rows)
            //{
            foreach(DataRow _privilage in _login.GetListFacultyAccess().Tables[0].Rows) {
                string lblFacName =  _privilage["facultyCode"] + " - " + _privilage["nameTh"];
                if (_privilage["id"].ToString().Equals(_login.AccessFacultyId))
                    _userPrivilage.AppendFormat("<li class='privilage-fac' data-facid='{1}'><a style='font-weight: bold;'>{0}<i class='glyphicon glyphicon-ok' style='margin-left:10px;'></i></a></li>", 
                        lblFacName, _privilage["id"]);
                else
                    _userPrivilage.AppendFormat("<li class='privilage-fac' data-facid='{1}'><a>{0}</a></li>", lblFacName, _privilage["id"]);
            }
            _userPrivilage.Append("<li role='separator' class='divider'></li>");
        }
        else
        {
            _login = new Login("student");
            _logoutPath = _login.UrlStudentLogin;
            lblPrivilage = @"<div style='font-size: small;'>&nbsp;</div>";
        }

        _sb.AppendFormat(@"<div class='container-fulid'>
            <nav class='navbar navbar-default navbar-fixed-top'>
                <div class='container-fluid'>
                    <div class='navbar-header'>
                        <a class='navbar-brand' href='#'>
                            <div class='brand-title'>
                                <div style='font-size: xx-large; text-align: center;'>Evaluation</div>
                                <div style='font-size: small;'>ระบบประเมินการเรียนการสอน</div>
                            </div>
                        </a>
                    </div>
                    <div class='navbar-header navbar-right'>
                        <div class='brand-title'>
                            <ul class='nav navbar-nav'>
                                <li class='dropdown'>
                                    <a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>
                                        <div style='vertical-align:middle;display:inline-block;height:auto;'>
                                            <i class='glyphicon glyphicon-user'></i>
                                            <span class='caret pull-right' style='margin-left: 15px;margin-top: 15px;'></span>
                                            <div class='pull-right' style='text-align:right;margin-left: 1em;'>
                                                <div style='font-size: large;'>{0}</div>
                                                {1}
                                            </div>
                                        </div>
                                    </a>
                                    <ul class='dropdown-menu'>
                                        {3}
                                        <li><a href='{2}'><i class='glyphicon glyphicon-log-out' style='margin-right: 1em;'></i><span>Logout</span></a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- /.container-fluid -->
            </nav>
        </div>",
               _login.FullNameTh,
               lblPrivilage,
               _logoutPath,
               _userPrivilage);

        return _sb.ToString();
    }
    public static string Footer(this Page _page) 
    {
        StringBuilder _sb = new StringBuilder();

        _sb.Append(@"<nav class='navbar navbar-default'>
                        <div class='container text-center'>
                        <div class='container' style='margin-top: 1em;'>Copyright © 2010 Mahidol University. All rights reserved.</div>
                        <div class='container'>ติดต่อกองบริหารการศึกษา สำนักงานอธิการบดี มหาวิทยาลัยมหิดล โทร. 0-2849-6115-24, 0-2849-6251-59 </div>
                        <div class='container' style='margin-bottom: 2em;'>ระบบประเมินการเรียนการสอน แสดงผลได้ดีบน Internet Explorer Version 7 ขึ้นไป</div>
                        </div>
                    </nav>");

        return _sb.ToString();
    }
    public static IEnumerable<Control> FindControlsByTagName(this ControlCollection _self, string selector)
    {
        foreach (var item in (_self.OfType<Control>()))
        {
            if (item.TagName() == selector)
                yield return item;
        }
    }
    public static string TagName(this Control _self) {
        StringBuilder _sb = new StringBuilder();
        StringWriter _sw = new StringWriter(_sb);

        using (HtmlTextWriter _htw = new HtmlTextWriter(_sw)) {
            _self.RenderControl(_htw);
        }

        string _tagStr = _sb.ToString();
        _tagStr = Regex.Replace(_tagStr, "<\\/.+?>", "");
        string _tagName = Regex.Match(_tagStr, "<\\w*").Value.Replace("<", "");

        return _tagName;
    }
    public static string FixFileUrl(string path){
        return path.StartsWith("/") ? path.Substring(1) : path;
    }

    public static void BadRequest(HttpContext context) {
        context.Response.ContentType = "text/html";
    }
}