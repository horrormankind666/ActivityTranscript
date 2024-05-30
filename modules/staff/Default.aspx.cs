using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_staff_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.StylesRegister("Bootstrap", "DataTable", "ActivityTranscript");
        Page.ScriptsRegister("Bootstrap", "DataTable", "ActivityTranscript");

        //Login _login = new Login("staff");
        //if (_login.Authen == "true")
        //{
        //    Page.StylesRegister("Bootstrap", "DataTable", "ActivityTranscript");
        //    Page.ScriptsRegister("Bootstrap", "DataTable", "ActivityTranscript");
        //}
        //else
        //{
        //    Response.Redirect("https://smartedu.mahidol.ac.th/Authen/staff/login.aspx");
        //}
    }
}