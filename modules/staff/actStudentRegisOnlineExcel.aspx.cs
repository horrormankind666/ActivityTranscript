using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_staff_actStudentRegisOnlineExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _projectId = Request["projectId"];
        string _sectionId = Request["sectionId"];
        Login _login = new Login("staff");
        string _username = _login.Username;
        string _authen = _login.Authen;
        string _html = "";
        if (_authen == "true")
        {
            _html = ActUI.getListStudentRegistPublicEventBySection(_projectId, _sectionId, "1");
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=Report_StduentRigistrationOnline.xls");
            Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            Response.Write("<head>");
            Response.Write("<style> td { mso-number-format:'0'; } </style>");
            Response.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            Response.Write("<!--[if gte mso 9]><xml>");
            Response.Write("<x:ExcelWorkbook>");
            Response.Write("<x:ExcelWorksheets>");
            Response.Write("<x:ExcelWorksheet>");
            Response.Write("<x:Name>Data</x:Name>");
            Response.Write("<x:WorksheetOptions>");
            Response.Write("<x:Print>");
            Response.Write("<x:ValidPrinterInfo/>");
            Response.Write("</x:Print>");
            Response.Write("</x:WorksheetOptions>");
            Response.Write("</x:ExcelWorksheet>");
            Response.Write("</x:ExcelWorksheets>");
            Response.Write("</x:ExcelWorkbook>");
            Response.Write("</xml>");
            Response.Write("<![endif]--> ");
            Response.Write(_html);
            Response.Write("</head>");
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("ไม่มีสิทธิ์ในการ Export Excel");
        }
    }
}