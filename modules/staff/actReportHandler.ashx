
<%@ WebHandler Language="C#" Class="actReportHandler" %>

using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Data;
public class actReportHandler : IHttpHandler {
    public HttpContext _c;
    string _username;
    string _facultyIdPermission;
    string _facultyNamePermission;
    string _facultyCodePermission;
    string _levelPermission;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        _c = context;
        string _act = _c.Request["action"];
        Login _login = new Login("staff");
        _username = _login.Username;
        //_username = "jate.khr"; // เอาขึ้น 10.90.101.101
        DataSet _ds = ActDB.getPermission(_username);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _facultyIdPermission = _dr["facultyId"].ToString();
                _facultyNamePermission = _dr["facultyNameTh"].ToString();
                _facultyCodePermission = _dr["facultyCode"].ToString();
                _levelPermission = _dr["level"].ToString();
            }
        }
        switch (_act)
        {
            case "rptProjectSummary":
                rptProjectSummary();
                break;
            case "genGraphProjectSummary":
                genGraphProjectSummary();
                break;
            case "rptProjectSummaryDetail":
                rptProjectSummaryDetail();
                break;
            case "pageSearhStudentCondition":
                pageSearhStudentCondition();
                break;
            case "resultStudentCondition":
                resultStudentCondition();
                break;
            case "pageStudentCompleteActivity":
                pageStudentCompleteActivity();
                break;
            case "getlistRptStdCompleteActGroupFaculty":
                getlistRptStdCompleteActGroupFaculty();
                break;
            case "getlistRptStdCompleteActGroupProgram":
                getlistRptStdCompleteActGroupProgram();
                break;
            case "getListRptStdCompleteActGroupStudent":
                getListRptStdCompleteActGroupStudent();
                break;
            case "getListStudentCompleteActivity":
                getListStudentCompleteActivity();
                break;
            case "getListRptStatisticFac":
                getListRptStatisticFac();
                break;
            case "rptProjectBudgetByAcaYear":
                rptProjectBudgetByAcaYear();
                break;
            case "getListDivRptStatisticFac":
                getListDivRptStatisticFac();
                break;
            case "pagePrintActivityTranscript":
                pagePrintActivityTranscript();
                break;
            case "getListProgram":
                getListProgram();
                break;
            case "getListATForPrint":
                getListATForPrint();
                break;
            case "pagePrintSpiderGraph":
                pagePrintSpiderGraph();
                break;
            case "getListStudentForSpiderGraph":
                getListStudentForSpiderGraph();
                break;
            case "pagePrintSpiderGraphFacultyLevel":
                pagePrintSpiderGraphFacultyLevel();
                break;
            case "pageTabSpiderGraph":
                pageTabSpiderGraph();
                break;
            case "getListStudentForSpiderGraphFacultyLevel":
                getListStudentForSpiderGraphFacultyLevel();
                break;
            case "getListHeaderGraphFacultyLevel":
                getListHeaderGraphFacultyLevel();
                break;
            case "pagePrintSpiderGraphUniversityLevel":
                pagePrintSpiderGraphUniversityLevel();
                break;
            case "getListHeaderGraphUniversityLevel":
                getListHeaderGraphUniversityLevel();
                break;
            case "panelReportStudent":
                panelReportStudent();
                break;
            case "resultRptStudentKPITransection":
                resultRptStudentKPITransection();
                break;
            case "popUpActivityByStudentId":
                popUpActivityByStudentId();
                break;
            case "getListForPageSearchStudentCondition":
                getListForPageSearchStudentCondition();
                break;
            case "resultRptHidefSummary":
                resultRptHidefSummary();
                break;
            case "getHidefGraphSummary":
                getHidefGraphSummary();
                break;
            case "resultRpt21StSummary":
                resultRpt21StSummary();
                break;
            case "get21stGraphSummary":
                get21stGraphSummary();
                break;
        }
    }

    public void get21stGraphSummary()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId= _c.Request["programId"];
        string _studyYear = _c.Request["studyYear"];
        string _html = ActReportUI.get21stGraphSummary(_facultyId,_programId,_studyYear);
        _c.Response.Write(_html);
    }

    public void resultRpt21StSummary()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId= _c.Request["programId"];
        string _studyYear = _c.Request["studyYear"];
        string _html = ActReportUI.resultRpt21StSummary(_facultyId,_programId,_studyYear,"0");
        _c.Response.Write(_html);
    }


    public void getHidefGraphSummary()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId= _c.Request["programId"];
        string _studyYear = _c.Request["studyYear"];
        string _html = ActReportUI.getHidefGraphSummary(_facultyId,_programId,_studyYear);
        _c.Response.Write(_html);
    }

    public void resultRptHidefSummary()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId= _c.Request["programId"];
        string _studyYear = _c.Request["studyYear"];
        string _html = ActReportUI.resultRptHidefSummary(_facultyId,_programId,_studyYear,"0");
        _c.Response.Write(_html);
    }

    public void getListForPageSearchStudentCondition()
    {
        string _studentCode = _c.Request["studentCode"];
        string _stdFName = _c.Request["stdFName"];
        string _stdLName = _c.Request["stdLName"];
        string _html = "";
        _html = ActReportUI.getListForPageSearchStudentCondition(_studentCode, _stdFName,_stdLName);
        _c.Response.Write(_html);
    }


    public void popUpActivityByStudentId()
    {
        string _studentId = _c.Request["studentId"];
        string _studentCode= _c.Request["studentCode"];
        string _html = "";
        _html = ActStdUI.getListActivitiesByStudent(_studentId, _studentCode);

        _c.Response.Write(_html);
    }


    public void resultRptStudentKPITransection()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId= _c.Request["programId"];
        string _studyYear = _c.Request["studyYear"];
        string _html = ActReportUI.resultRptStudentKPITransection(_facultyId,_programId,_studyYear,"0");
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 13 พ.ค. 2562
    /// Perpose: 
    /// Method : panelReportStudent
    /// Sample : N/A
    public void panelReportStudent()
    {
        string _html = ActReportUI.panelReportStudent(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 11 พ.ค. 2561
    /// Perpose: 
    /// Method : getListHeaderGraphUniversityLevel
    /// Sample : N/A
    public void getListHeaderGraphUniversityLevel()
    {
        string _facultyId = _c.Request["facultyId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _txtDisplayHeader = _c.Request["txtDisplayHeader"];
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _groupCharacterId= _c.Request["groupCharacterId"];
        string _html = ActReportUI.getListHeaderGraphUniversityLevel(_acaYear, _semester, _facultyId, _txtDisplayHeader,_groupIndicatorId,_groupCharacterId);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 15 พ.ค. 2561
    /// Perpose: 
    /// Method : pagePrintSpiderGraphUniversityLevel
    /// Sample : N/A
    public void pagePrintSpiderGraphUniversityLevel()
    {
        string _html = ActReportUI.pagePrintSpiderGraphUniversityLevel(_facultyIdPermission);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 11 พ.ค. 2561
    /// Perpose: 
    /// Method : getListHeaderGraphFacultyLevel
    /// Sample : N/A
    public void getListHeaderGraphFacultyLevel()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _txtDisplayHeader = _c.Request["txtDisplayHeader"];
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _groupCharacterId = _c.Request["groupCharacterId"];

        string _html = ActReportUI.getListHeaderGraphFacultyLevel(_acaYear, _semester, _facultyId, _programId, _txtDisplayHeader,_groupIndicatorId,_groupCharacterId);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 11 พ.ค. 2561
    /// Perpose: 
    /// Method : getListStudentForSpiderGraphFacultyLevel
    /// Sample : N/A
    public void getListStudentForSpiderGraphFacultyLevel()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _html = ActReportUI.getListStudentForSpiderGraphFacultyLevel(_acaYear, _semester,_facultyId, _programId);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 11 พ.ค. 2561
    /// Perpose: 
    /// Method : pageTabSpiderGraph
    /// Sample : N/A
    public void pageTabSpiderGraph()
    {
        string _html = ActReportUI.pageTabSpiderGraph(_facultyIdPermission);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 10 พ.ค. 2561
    /// Perpose: 
    /// Method : pagePrintSpiderGraphFacultyLevel
    /// Sample : N/A
    public void pagePrintSpiderGraphFacultyLevel()
    {
        string _html = ActReportUI.pagePrintSpiderGraphFacultyLevel(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 9 พ.ค. 2561
    /// Perpose: 
    /// Method : getListStudentForSpiderGraph
    /// Sample : N/A
    public void getListStudentForSpiderGraph()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _studentCode = _c.Request["studentCode"];
        string _firstName = _c.Request["firstName"];
        string _lastName = _c.Request["lastName"];
        string _html = ActReportUI.getListStudentForSpiderGraph(_facultyId, _programId, _studentCode, _firstName, _lastName);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 9 พ.ค. 2561
    /// Perpose: 
    /// Method : pagePrintSpiderGraph
    /// Sample : N/A
    public void pagePrintSpiderGraph()
    {
        string _html = ActReportUI.pagePrintSpiderGraph(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 เม.ย. 2561
    /// Perpose: 
    /// Method : getListATForPrint
    /// Sample : N/A
    public void getListATForPrint()
    {
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _studentCode = _c.Request["studentCode"];
        string _studentYear = _c.Request["studentYear"];
        string _statusRequest = _c.Request["statusRequest"];
        string _html = ActReportUI.getListATForPrint(_studentYear,_facultyId, _programId, _studentCode,_statusRequest);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 เม.ย. 2561
    /// Perpose: 
    /// Method : getListProgram
    /// Sample : N/A
    public void getListProgram()
    {
        string _facultyId = _c.Request["facultyId"];
        string _html = ActUI.getListProgram(_facultyId);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 เม.ย. 2561
    /// Perpose: 
    /// Method : pagePrintActivityTranscript
    /// Sample : N/A
    public void pagePrintActivityTranscript()
    {

        string _ddlFacultyId = _c.Request["ddlFacultyId"];
        string _programId = _c.Request["programId"];
        string _studentYear = _c.Request["studentYear"];
        string _studentCode = _c.Request["studentCode"];
        string _statusRequest = _c.Request["statusRequest"];
        string _html = ActReportUI.pagePrintActivityTranscript(_facultyIdPermission,_ddlFacultyId,_programId,_studentYear,_studentCode,_statusRequest);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 ก.ย. 2560
    /// Perpose: 
    /// Method : rptProjectBudgetByAcaYear
    /// Sample : N/A
    public void rptProjectBudgetByAcaYear()
    {
        string _acaYear = _c.Request["acaYear"];
        string _facultyId = _c.Request["facultyId"];
        string _html = ActReportUI.rptProjectBudgetByAcaYear(_acaYear, _facultyId);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 22 ส.ค. 2560
    /// Perpose: 
    /// Method : getListRptStatisticFac
    /// Sample : N/A
    public void getListRptStatisticFac()
    {

        string _html = ActReportUI.getListRptStatisticFac(_facultyIdPermission);
        _c.Response.Write(_html);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 22 ส.ค. 2560
    /// Perpose: 
    /// Method : getListDivRptStatisticFac
    /// Sample : N/A
    public void getListDivRptStatisticFac()
    {
        string _facultyId = _c.Request["facultyId"];
        string _ddlYearReport = _c.Request["ddlYearReport"];
        string _ddlMonthReport = _c.Request["ddlMonthReport"];
        //string _html = ActReportUI.getListDivRptStatisticFacMAHIDOL(_facultyId);
        //_html += ActReportUI.getListDivRptStatisticFac(_facultyId);
        string _html = "";
        if (_ddlYearReport == "" && _ddlMonthReport == "")
        {
            _html = ActReportUI.getListRptStatisticDepartment(_facultyId, "GIR-003","","");
            _html += ActReportUI.getListRptStatisticDepartment(_facultyId, "GIR-002","","");
            _html += ActReportUI.getListRptStatisticDepartment(_facultyId, "GIR-001","","");
        }
        else
        { 
            _html = ActReportUI.getListRptStatisticDepartment(_facultyId, "GIR-003",_ddlYearReport,_ddlMonthReport);
        }
        _c.Response.Write(_html);

    }


    public void getListStudentCompleteActivity()
    {
        // string _typeComlpeteAct = _c.Request["typeComlpeteAct"];
        string _html = ActReportUI.rptStudentCompleteActivityGroupAcaYear(_facultyIdPermission, _facultyCodePermission, _facultyNamePermission);
        _c.Response.Write(_html);
    }



    public void getListRptStdCompleteActGroupStudent()
    {
        string _acaYear = _c.Request["acaYear"];
        string _facultyId = _c.Request["facultyId"];

        string _html = ActReportUI.rptStudentCompleteActivityGroupStudent(_facultyId, _acaYear);
        _c.Response.Write(_html);
    }


    public void getlistRptStdCompleteActGroupProgram()
    {
        string _acaYear = _c.Request["acaYear"];
        string _facultyId = _c.Request["facultyId"];
        string _facultyCode = _c.Request["facultyCode"];
        string _facultyNameTh = _c.Request["facultyNameTh"];

        string _html = ActReportUI.rptStudentCompleteActivityGroupProgram(_facultyId, _acaYear, _facultyCode, _facultyNameTh);
        _c.Response.Write(_html);
    }

    public void getlistRptStdCompleteActGroupFaculty()
    {
        string _acaYear = _c.Request["acaYear"];
        string _html = ActReportUI.rptStudentCompleteActivityGroupFaculty(_facultyIdPermission, _acaYear);
        _c.Response.Write(_html);
    }

    public void pageStudentCompleteActivity()
    {
        string _typeComlpeteAct = _c.Request["typeComlpeteAct"];
        string _html = ActReportUI.pageConditionStudentCompleteActivityGroupAcaYear();
        //string _html = ActReportUI.rptStudentCompleteActivityGroupAcaYear(_facultyIdPermission, _facultyCodePermission, _facultyNamePermission, _typeComlpeteAct);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 31 ก.ค. 2560
    /// Perpose: 
    /// Method : resultStudentCondition
    /// Sample : N/A
    public void resultStudentCondition()
    {
        string _studentId = _c.Request["studentId"];
        string _studentCode = _c.Request["studentCode"];

        //string _stdFName = _c.Request["stdFName"];
        //string _stdLName = _c.Request["stdLName"];
        //string _programId = _c.Request["programId"];
        //string _acaYear = _c.Request["acaYear"];
        //string _semester = _c.Request["semester"];
        //string _studentId = ActStdUI.getStudentId(_studentCode,"","");
        //if (_studentCode == "")
        //{
        //    _studentCode = ActStdUI.getStudentCode(_studentCode, "", "");
        //}
        //string _html = ActReportUI.resultStudentCondition(_studentCode, _stdFName, _stdLName, _programId);

        string _html = ActStdUI.getListActivitiesByStudent(_studentId, _studentCode);

        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 31 ก.ค. 2560
    /// Perpose: 
    /// Method : pageSearhStudentCondition
    /// Sample : N/A
    public void pageSearhStudentCondition()
    {
        string _html = ActReportUI.rptSearhStudentCondition(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 25 มิ.ย. 2560
    /// Perpose: 
    /// Method : rptProjectSummaryDetail
    /// Sample : N/A
    public void rptProjectSummaryDetail()
    {


        string _acaYear = _c.Request["acaYear"];
        string _html = ActReportUI.rptProjectSummaryDetail(_facultyIdPermission, _acaYear);
        _c.Response.Write(_html);


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 25 มิ.ย. 2560
    /// Perpose: 
    /// Method : genGraphProjectSummary
    /// Sample : N/A
    public void genGraphProjectSummary()
    {



        DataSet _ds = ActDB.rptProjectSummary(_facultyIdPermission);
        int _count = _ds.Tables[0].Rows.Count;
        List<int> _data = new List<int>();

        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _data.Add((int)_dr["countProject"]);
                //_acaYear = _dr["acaYear"].ToString();
            }
        }


        _c.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_data));
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 25 มิ.ย. 2560
    /// Perpose: 
    /// Method : rptProjectSummary
    /// Sample : N/A
    public void rptProjectSummary()
    {

        string _html = ActReportUI.rptProjectSummary(_facultyIdPermission,_facultyCodePermission,_facultyNamePermission);
        _c.Response.Write(_html);


    }


    public bool IsReusable {
        get {
            return false;
        }
    }

}