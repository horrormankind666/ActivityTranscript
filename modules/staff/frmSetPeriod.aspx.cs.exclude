using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_staff_frmSetPeriod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Login _userInfo = new Login("staff");
        Page.StylesRegister("Bootstrap", "DataTable", "Evaluation", "jstree");
        Page.ScriptsRegister("Bootstrap", "DataTable", "Evaluation", "jstree");
        divBanner.InnerHtml = Page.Banner();
        divBreadcrumb.InnerHtml = EvaluationUI.Breadcrumb(_userInfo.DocumentYear, _userInfo.DocumentSemester);
        sideMenu.InnerHtml = EvaluationUI.SideMenu();
        //divNavbar.InnerHtml = EvaluationUI.Staff.StaffContentNavBar("frmSetPeriod.aspx", Request.Params["year"], Request.Params["semester"]);
        divFooter.InnerHtml = Page.Footer();
    }
}