using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_staff_frmPublishForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Login _userInfo = new Login("staff");
        Page.StylesRegister("Bootstrap", "DataTable", "Evaluation");
        Page.ScriptsRegister("Bootstrap", "DataTable", "Evaluation");
        divBanner.InnerHtml = Page.Banner();
        divBreadcrumb.InnerHtml = EvaluationUI.Breadcrumb(_userInfo.DocumentYear, _userInfo.DocumentSemester);
        divSideMenu.InnerHtml = EvaluationUI.SideMenu();
        //divNavbar.InnerHtml = EvaluationUI.Staff.StaffContentNavBar("frmEvaluation.aspx", Request.Params["year"], Request.Params["semester"]);
        divFooter.InnerHtml = Page.Footer();

        //DataTable _formInfoDt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelForm] WHERE id = @frmid",
        //        new SqlParameter("frmid", Request["formid"])
        //    ).Tables[0];

        //Dictionary<string, object> jsonObject = new Dictionary<string,object>();

        //foreach(DataColumn _col in _formInfoDt.Columns)
        //    jsonObject.Add(_col.ColumnName, _formInfoDt.Rows[0][_col.ColumnName]);

        //StringBuilder _script = new StringBuilder();
        //_script.Append("<script>");
        //_script.AppendFormat("var formObj = JSON.parse('{0}');", JsonConvert.SerializeObject(jsonObject));
        //_script.Append("</script>");

        //Response.Write(_script.ToString());
    }
}