using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_staff_actRptStudentExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _acaYear = Request["acaYear"];
        string _facultyId = Request["facultyId"];
        string _programId = Request["programId"];
        string _studyYear = Request["studyYear"];
        string _reportName = Request["reportName"];
        //_acaYear = "2561";
        //_facultyId = "AM-01";
        //_programId = "";
        //_studyYear = "";
        //_reportName = "RptSumHrAndCountActStudent";

        Login _login = new Login("staff");
        string _username = _login.Username;
        string _authen = _login.Authen;
        string _html = "";
        if (_authen == "true")
        {
            if (_reportName == "resultRptStudentKPITransection")
            {
                _html = ActReportUI.resultRptStudentKPITransection(_facultyId, _programId, _studyYear,"1");
            }
            else if (_reportName == "RptSumHrAndCountActStudent")
            {
                _html = ActReportUI.resultRptSumHrAndCountActStudent(_facultyId, _programId, _studyYear, _acaYear);
            }
            else if (_reportName == "RptTransectionRequestDoc")
            {
                string _studentYear = Request["studentYear"];
                string _studentCode = Request["studentCode"];
                string _statusRequest = Request["statusRequest"];
                _html = ActReportUI.RptTransectionRequestDoc(_studentYear, _facultyId, _programId, _studentCode, _statusRequest);
            }
            
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=Report_"+ _reportName + ".xls");
            Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            Response.Write("<head>");
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
            Response.Write("ไม่มีสิทธิ์เข้าใช้เมนูนี้");
        }



    }
}