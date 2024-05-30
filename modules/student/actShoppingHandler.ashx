<%@ WebHandler Language="C#" Class="actShoppingHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class actShoppingHandler : IHttpHandler {
    
    public HttpContext _c;
    string _username;
    string _facultyIdPermission;
    string _facultyNamePermission;
    string _facultyCodePermission;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        _c = context;
        string _act = _c.Request["action"];
        //_username = "STD256000001";
        switch (_act)
        {
            case "loadBarMenuStd":
                loadBarMenuStd();
                break;
            case "loadSidebarMenuStd":
                loadSidebarMenuStd();
                break;
            //case "getListProjectActive":
            //    getListProjectActive();
            //    break;
            //case "getListProjectDetail":
            //    getListProjectDetail();
            //    break;  
                
        }
        
    }
    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 5 ก.ค. 2560
    ///// Perpose: แสดงหน้าจอรายละเอียดโครงการมาแสดง
    ///// Method : getListProjectDetail
    ///// Sample : N/A
    //public void getListProjectDetail()
    //{
    //    string _projectId = _c.Request["projectId"];
    //    string _html = ActStdUI.getListProjectDetail(_projectId, _username);
    //    _c.Response.Write(_html);
    //}

    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 5 ก.ค. 2560
    ///// Perpose: แสดงหน้าจอสำหรับดึงโครงการที่ Active มาแสดง
    ///// Method : getListProjectActive
    ///// Sample : N/A
    //public void getListProjectActive()
    //{
    //    //string _html = ActStdUI.getListSearchForProjectActive();
    //    string _html = ActStdUI.getListProjectActive();
    //    _c.Response.Write(_html);
    //}

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 ก.ค. 2560
    /// Perpose: แสดงเมนู Menu bar
    /// Method : loadBarMenuStd
    /// Sample : N/A
    public void loadBarMenuStd()
    {
        string _html = ActStdUI.loadBarMenuStd(_username, _facultyCodePermission, _facultyNamePermission,"บดินทร์ สินหทัย");
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 ก.ค. 2560
    /// Perpose: แสดงเมนู Side bar
    /// Method : loadSidebarMenuStd
    /// Sample : N/A
    public void loadSidebarMenuStd()
    {
        string _html = ActStdUI.loadSidebarMenuStd();
        _c.Response.Write(_html);
    }
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}