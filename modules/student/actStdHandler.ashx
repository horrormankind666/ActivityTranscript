<%@ WebHandler Language="C#" Class="actStdHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class actStdHandler : IHttpHandler {
    public HttpContext _c;
    string _username;
    string _isAuthen;
    string _fullname;
    string _facultyIdPermission;
    string _facultyNamePermission;
    string _facultyCodePermission;
    string _studentId;
    string _studentCode;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        _c = context;
        Login _login = new Login("student");
        _username = _login.StudentId;
        _isAuthen = _login.Authen;
        _studentId = _login.StudentId;
        _studentCode = _login.StudentCode;
        // _username = "STD255402585";
        //_username = "STD255902572";

        //_username = "STD256104583";
        //_studentId= "STD256104583";
        //_studentCode = "6113340";
        //_isAuthen = "true";

        _fullname = _login.FullNameTh;
        string _act = _c.Request["action"];
        switch (_act)
        {
            case "loadBarMenuStd":
                loadBarMenuStd();
                break;
            case "loadSidebarMenuStd":
                loadSidebarMenuStd();
                break;
            case "getListStudentProfile":
                getListStudentProfile();
                break;
            case "searchActivity":
                searchActivity();
                break;
            case "getListActivitiesByStudent":
                getListActivitiesByStudent();
                break;
            case "resultActivity":
                resultActivity();
                break;
            case "getListActivitySchorlarship":
                getListActivitySchorlarship();
                break;
            case "getListActDetailForScholarship":
                getListActDetailForScholarship();
                break;
            case "setListSendActForScholarship":
                setListSendActForScholarship();
                break;
            case "getListSchStudentSendAct":
                getListSchStudentSendAct();
                break;
            case "getListActivityShoppingDetail":
                getListActivityShoppingDetail();
                break;
            case "getListProjectDetailForShopping":
                getListProjectDetailForShopping();
                break;
            case "getlistSectionForShopping":
                getlistSectionForShopping();
                break;
            case "setListSectionForShopping":
                setListSectionForShopping();
                break;
            case "getlistRptMahidolCoreValue":
                getlistRptMahidolCoreValue();
                break;
            case "getListHeaderShortProfile":
                getListHeaderShortProfile();
                break;
            case "getListDefinitionCoreValue":
                getListDefinitionCoreValue();
                break;
            case "getListDefinitionTQF":
                getListDefinitionTQF();
                break;
            case "getCharacterSummary":
                getCharacterSummary();
                break;
            case "getListDefinitionCenturySkill":
                getListDefinitionCenturySkill();
                break;
            case "getListMainFeedContent":
                getListMainFeedContent();
                break;
            case "getListSubFeedContent":
                getListSubFeedContent();
                break;
            case "loadRegisterPage":
                loadRegisterPage(_isAuthen);
                break;
            case "setLikeProject":
                setLikeProject(_isAuthen);
                break;
            case "loadCopyLinkProjectPage":
                loadCopyLinkProjectPage();
                break;
            case "setJoinProjectSection":
                setJoinProjectSection();
                break;
            case "setCancelJoinProjectSection":
                setCancelJoinProjectSection();
                break;
            case "loadFacultyDDl":
                loadFacultyDDl();
                break;
            case "loadProjectStatusDll":
                loadProjectStatusDll();
                break;
            case "loadDetailProjectPublic":
                loadDetailProjectPublic();
                break;
            case "getListActDetailForScholarshipNew":
                getListActDetailForScholarshipNew();
                break;
            case "loadGroupIndicatorDDl":
                loadGroupIndicatorDDl();
                break;
            case "getListActivitiesOnline":
                getListActivitiesOnline();
                break;
            case "getListDdlIndicator":
                getListDdlIndicator();
                break;
            case "getListDdlSubIndicator":
                getListDdlSubIndicator();
                break;
            case "qrPaymentDynamic":
                qrPaymentDynamic();
                break;
            case "getMahidolCoreValueUniversity":
                getMahidolCoreValueUniversity();
                break;
            case "getCharacterSummaryUniversity":
                getCharacterSummaryUniversity();
                break;
            case "getRequestAT":
                getRequestAT();
                break;
            case "setRequestAT":
                setRequestAT();
                break;
            case "setCancelRequestDoc":
                setCancelRequestDoc();
                break;
            case "getListRequestReasonToSelectPicker":
                getListRequestReasonToSelectPicker();
                break;

                //case "getListActNewRelease":
                //    getListActNewRelease();
                //    break;

        }
    }

    public void getListRequestReasonToSelectPicker()
    {
        string _requestStr = ActStdUI.getListRequestReasonToSelectPicker(_studentId);
        _c.Response.Write(_requestStr);
    }

    public void setCancelRequestDoc()
    {
        int _requestDocId = Convert.ToInt32(_c.Request["_requestDocId"]);
        ActDB.setCancelRequestDoc(_requestDocId,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void setRequestAT()
    {
        string _ddlRequestReason = _c.Request["_ddlRequestReason"];
        string _txtOtherReason = _c.Request["_txtOtherReason"];
        _ddlRequestReason = (_ddlRequestReason == "null") ? "" : _ddlRequestReason;
        _ddlRequestReason = _ddlRequestReason.Replace("%2C", ",");
        ActDB.setRequestDoc(_studentId,_ddlRequestReason,_txtOtherReason,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void getRequestAT()
    {

        string _studentCondition = _studentCode.Substring(0, 2);
        string _html = ActStdUI.getRequestAT(_studentCondition, _studentId);
        _c.Response.Write(_html);

    }

    public void getCharacterSummaryUniversity()
    {

        string _studentId = _c.Request["studentId"];
        string _groupCharacterId = _c.Request["groupCharacterId"];
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _html = ActStdUI.getCharacterSummaryUniversity(_studentId, _groupCharacterId, _facultyId, _programId, _acaYear, _semester);
        _c.Response.Write(_html);

    }


    public void getMahidolCoreValueUniversity()
    {

        string _studentId = _c.Request["studentId"];
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _indicatorId = _c.Request["indicatorId"];
        string _html = ActStdUI.getMahidolCoreValueUniversity(_studentId, _facultyId, _programId, _acaYear, _semester,_groupIndicatorId,_indicatorId);
        _c.Response.Write(_html);

    }


    public void qrPaymentDynamic()
    {
        string _invoiceId = _c.Request["invoiceId"];
        string _sectionId = _c.Request["sectionId"];
        string _html = ActStdUI.getQRCode(_invoiceId,_sectionId);
        _c.Response.Write(_html);

    }

    public void getListDdlSubIndicator()
    {
        string _indicatorId = _c.Request["indicatorId"];
        string _html = ActStdUI.getListDdlSubIndicator(_indicatorId);
        _c.Response.Write(_html);
    }

    public void getListDdlIndicator()
    {
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _html = ActStdUI.getListDdlIndicator(_groupIndicatorId);
        _c.Response.Write(_html);
    }

    public void getListActivitiesOnline()
    {

        string _html = ActStdUI.getListActivitiesOnline(_studentId);
        _c.Response.Write(_html);
    }

    public void loadGroupIndicatorDDl()
    {
        string _html = ActStdUI.loadGroupIndicator();
        _c.Response.Write(_html);
    }

    //public void getListActNewRelease()
    //{
    //    string _html = ActStdUI.getListActNewRelease();
    //    _c.Response.Write(_html);
    //}


    public void getListActDetailForScholarshipNew()
    {
        string _acaYear = _c.Request["acaYear"];
        string _html = ActStdUI.getListActDetailForScholarshipNew(_acaYear,_username);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 24 เม.ย. 2562
    /// Perpose: 
    /// Method : searchPublicEvent
    /// Sample : N/A
    //public void searchPublicEvent()
    //{
    //    string _publicEventName = _c.Request["_txtPublicEventName"];
    //    // string _html = ActStdUI.loadRegisterPage(_isAuthen,_projectId,_username);
    //    //_c.Response.Write(_html);
    //}

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 10 พ.ค. 2562
    /// Perpose: loadDetailProjectPublic
    /// Sample : N/A
    public void loadDetailProjectPublic()
    {
        string _projectId = _c.Request["projectId"];
        string _publicEventName = _c.Request["publicEventName"];
        string _ddlFaculty = _c.Request["ddlFaculty"];
        string _dateStart = _c.Request["dateStart"];
        string _dateEnd = _c.Request["dateEnd"];
        string _ddlProjectStatus = _c.Request["ddlProjectStatus"];
        string _html = ActStdUI.getListProjectDetailPublic(_projectId, _studentId, _publicEventName, _ddlFaculty, _dateStart, _dateEnd, _ddlProjectStatus);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2562
    /// Perpose: loadProjectStatusDll
    /// Sample : N/A
    public void loadProjectStatusDll()
    {
        string _html = ActStdUI.getListProjectStatusNoLabel("");
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 30 เม.ย. 2562
    /// Perpose: 
    /// Method : loadFacultyDDl
    /// Sample : N/A
    public void loadFacultyDDl()
    {
        string _html = ActStdUI.getListFacultyNoLabel("MU-01");
        _c.Response.Write(_html);
    }

    public void setCancelJoinProjectSection()
    {
        string _sectionId = _c.Request["sectionId"];
        string _invoiceId = _c.Request["invoiceId"];

        ActDB.setCancelJoinProjectSection(_sectionId,_username,_invoiceId);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }


    public void setJoinProjectSection()
    {
        string _sectionId = _c.Request["sectionId"];

        ActDB.setJoinProjectSection(_sectionId,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void loadCopyLinkProjectPage()
    {
        string _projectId = _c.Request["projectId"];
        // string _path =  HttpContext.Current.Server.MapPath("~/modules/student/studentPublicEvent.aspx");
        //        _path = _path + "?projectId=" + _projectId;
        string _path = "https://smartedu.mahidol.ac.th/ActivityTranscript/modules/student/studentPublicEvent.aspx?projectId="+ _projectId;

        string _html = ActStdUI.loadCopyLinkProjectPage(_projectId,_path);
        _c.Response.Write(_html);
    }

    public void setLikeProject(string _isAuthen)
    {
        string _studentId = _c.Request["studentId"];
        string _projectId = _c.Request["projectId"];
        string _studentLike = _c.Request["studentLike"];
        if (_isAuthen == "true")
        {
            if (_studentLike == "0")
            {
                // ถ้าเป็น 0 คือบันทึก Like
                ActDB.setLikeProject(_studentId, _projectId, _username);
            }
            else
            {
                // ถ้าเป็น 1 คือยกเลิกการ Like
                ActDB.setCancelLikeProject(_studentId, _projectId);
            }
            _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
        }
        else
        {
            _c.Response.Write("ยังไม่ได้ Log in เข้าสู่ระบบ");
        }


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 9 ม.ค. 2562
    /// Perpose: 
    /// Method : loadRegisterPage
    /// Sample : N/A
    public void loadRegisterPage(string _isAuthen)
    {
        string _projectId = _c.Request["projectId"];
        string _html = ActStdUI.loadRegisterPage(_isAuthen,_projectId,_username);
        _c.Response.Write(_html);
    }

    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 20 ธ.ค. 2561
    ///// Perpose: 
    ///// Method : getListProjectDetailPublic
    ///// Sample : N/A
    //public void getListProjectDetailPublic()
    //{
    //    string _projectId = _c.Request["projectId"];
    //    string _html = ActStdUI.getListProjectDetailPublic(_projectId);
    //    _c.Response.Write(_html);
    //}

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 พ.ย. 2561
    /// Perpose: 
    /// Method : getListSubFeedContent
    /// Sample : N/A
    public void getListSubFeedContent()
    {

        string _menuVal = _c.Request["menuVal"];
        string _publicEventName = _c.Request["publicEventName"];
        string _ddlFaculty = _c.Request["ddlFaculty"];
        string _dateStart = _c.Request["dateStart"];
        string _dateEnd =_c.Request["dateEnd"];
        string _ddlProjectStatus =_c.Request["ddlProjectStatus"];
        string _statusPublicEvent = _c.Request["statusPublicEvent"];
        string _ddlFacultyText =_c.Request["ddlFacultyText"];
        string _ddlProjectStatusText =_c.Request["ddlProjectStatusText"];
        string _panelSearchVal =_c.Request["panelSearchVal"];
        string _ddlGroupIndicatorText =_c.Request["ddlGroupIndicatorText"];
        string _ddlGroupIndicator =_c.Request["ddlGroupIndicator"];
        string _ddlIndicator =_c.Request["ddlIndicator"];
        string _ddlSubIndicator =_c.Request["ddlSubIndicator"];
        //string _html = "สวัสดี<br>5555";
        string _html = ActStdUI.getListSubFeedContent(_menuVal,_publicEventName,_ddlFaculty,_dateStart,_dateEnd,_ddlProjectStatus,_statusPublicEvent,_ddlFacultyText , _ddlProjectStatusText,_panelSearchVal,_ddlGroupIndicatorText,_ddlGroupIndicator,_ddlIndicator,_ddlSubIndicator);
        _c.Response.Write(_html);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 14 พ.ย. 2561
    /// Perpose: 
    /// Method : getListMainFeedContent
    /// Sample : N/A
    public void getListMainFeedContent()
    {
        string _menuVal = _c.Request["menuVal"];
        string _html = ActStdUI.getListMainFeedContent(_menuVal);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2561
    /// Perpose: 
    /// Method : getListDefinitionCenturySkill
    /// Sample : N/A
    public void getListDefinitionCenturySkill()
    {
        string _html = ActStdUI.getListDefinitionCenturySkill();
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2561
    /// Perpose: 
    /// Method : getlistRptTQF
    /// Sample : N/A
    public void getCharacterSummary()
    {

        string _studentId = _c.Request["studentId"];
        string _groupCharacterId = _c.Request["groupCharacterId"];
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _html = ActStdUI.getCharacterSummary(_studentId, _groupCharacterId, _facultyId, _programId, _acaYear, _semester);
        _c.Response.Write(_html);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 7 พ.ค. 2561
    /// Perpose: 
    /// Method : getListDefinitionTQF
    /// Sample : N/A
    public void getListDefinitionTQF()
    {
        string _html = ActStdUI.getListDefinitionTQF();
        _c.Response.Write(_html);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 7 พ.ค. 2561
    /// Perpose: 
    /// Method : getListDefinitionCoreValue
    /// Sample : N/A
    public void getListDefinitionCoreValue()
    {
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _html = ActStdUI.getListDefinitionCoreValue(_groupIndicatorId);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2 พ.ค. 2561
    /// Perpose: 
    /// Method : getListHeaderShortProfile
    /// Sample : N/A
    public void getListHeaderShortProfile()
    {

        string _studentCode = _c.Request["studentCode"];
        string _stsShowSummaryAct = _c.Request["stsShowSummaryAct"];
        string _txtDisplayHeader = _c.Request["txtDisplayHeader"];
        string _countProject = _c.Request["countProject"];
        string _sumHour = _c.Request["sumHour"];
        string _groupIndicatorId = _c.Request["groupIndicatorId"];
        string _groupCharacterId = _c.Request["groupCharacterId"];
        string _html = ActStdUI.getListShortProfileStudent(_studentCode, _stsShowSummaryAct, _txtDisplayHeader, _countProject, _sumHour , _groupIndicatorId,_groupCharacterId);
        _c.Response.Write(_html);

    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2 พ.ค. 2561
    /// Perpose: แสดงรายการกราฟมหิดลคอร์วารู
    /// Method : getlistRptMahidolCoreValue
    /// Sample : N/A
    public void getlistRptMahidolCoreValue()
    {

        string _studentId = _c.Request["studentId"];
        string _facultyId = _c.Request["facultyId"];
        string _programId = _c.Request["programId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _groupIndicatorId = _c.Request["groupIndicatorId"];

        string _html = ActStdUI.getlistRptMahidolCoreValue(_studentId, _facultyId, _programId, _acaYear, _semester,_groupIndicatorId);
        _c.Response.Write(_html);

    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 ต.ค. 2560
    /// Perpose: บันทึกข้อมูลการเข้าร่วม Section
    /// Method : setListSectionForShopping
    /// Sample : N/A
    public void setListSectionForShopping()
    {
        var _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(_c.Request["itemList"]);
        ActDB.setListSectionForShopping(_dataList, _username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 ต.ค. 2560
    /// Perpose: แสดงรายการสำหรับให้นักศึกษาเลือก Section
    /// Method : getlistSectionForShopping
    /// Sample : N/A
    public void getlistSectionForShopping()
    {
        string _projectId = _c.Request["projectId"];
        string _html = ActStdUI.getListSectionForShopping(_projectId, _username);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2 ต.ค. 2560
    /// Perpose: แสดงเมนูหน้าแสดงรายละเอียดข้อมูลเพื่อนจะให้นักศึกษา Shopping ดู
    /// Method : getListProjectDetailForShopping
    /// Sample : N/A
    public void getListProjectDetailForShopping()
    {
        string _projectId = _c.Request["projectId"];
        string _html = ActStdUI.getListProjectDetailForShopping(_projectId, _username);
        _c.Response.Write(_html);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 15 ก.ย. 2560
    /// Perpose: แสดงข้อมูลรายละเอียดกิจกรรมที่นศ.จะ Shopping
    /// Method : getListActivityShoppingDetail
    /// Sample : N/A
    public void getListActivityShoppingDetail()
    {
        string _projectId = _c.Request["projectId"];
        string _html = ActStdUI.getListActivityShoppingDetail(_projectId);
        _c.Response.Write(_html);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 15 ก.ย. 2560
    /// Perpose: แสดงข้อมูลรายการนักศึกษาที่ส่งข้อมูลกิจกรรมเพื่อยื่นกู้เงิน กยศ./กรอ.
    /// Method : getListSchStudentSendAct
    /// Sample : N/A
    public void getListSchStudentSendAct()
    {

        string _html = ActStdUI.getListSchStudentSendAct();
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 15 ก.ย. 2560
    /// Perpose: หน้าสำหรับบันทึกการส่งยืนยันทุนในการตรวจสอบกิจกรรม
    /// Method : getListActDetailForScholarship
    /// Sample : N/A
    public void setListSendActForScholarship()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _acaYear = _c.Request["acaYear"];
        string _studentId = _c.Request["studentId"];
        ActDB.setListSendActForScholarship(_acaYear, _studentId, _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 14 ก.ย. 2560
    /// Perpose: แสดงหน้ารายการข้อมูลกิจกรรมที่เข้าร่วมที่ได้ค่า A1 ด้านบำเพ็ญประโยชน์
    /// Method : getListActDetailForScholarship
    /// Sample : N/A
    public void getListActDetailForScholarship()
    {
        string _acaYear = _c.Request["acaYear"];
        string _html = ActStdUI.getListActDetailForScholarship(_acaYear,_username);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 14 ก.ย. 2560
    /// Perpose: แสดงหน้าจอกิจกรรมเพื่อยื่นกู้เงินกยศ.
    /// Method : getListActivitySchorlarship
    /// Sample : N/A
    public void getListActivitySchorlarship()
    {
        string _html = ActStdUI.getListActivitySchorlarship(_username);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 13 ก.ย. 2560
    /// Perpose: แสดงหน้าผลลัพธ์การค้นหากิจกรรม
    /// Method : resultActivity
    /// Sample : N/A
    public void resultActivity()
    {
        string _activityName = _c.Request["activityName"];
        string _acaYear = _c.Request["acaYear"];
        string _projectType = _c.Request["projectType"];
        string _projectStatus = _c.Request["projectStatus"];
        string _html = ActStdUI.getListProjectByCondition(_activityName, _acaYear, _projectType, _projectStatus, _username);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 28 ส.ค. 2560
    /// Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    /// Method : getListActivitiesByStudent
    /// Sample : N/A
    public void getListActivitiesByStudent()
    {

        string _html = ActStdUI.getListActivitiesByStudent(_username, _studentCode);
        // พี่ปเนตตรวจเสร็จค่อยมาเปิด
        //string _html = "</br><center><h3>อยู่ระหว่างดำเนินการประมวลผลข้อมูล</h3>";
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 28 ส.ค. 2560
    /// Perpose: แสดงหน้าเงื่อนไขการค้นหาข้อมูลกิจกรรม
    /// Method : searchActivity
    /// Sample : N/A
    public void searchActivity()
    {
        string _html = ActStdUI.searchActivity(_username);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 28 ส.ค. 2560
    /// Perpose: แสดงเมนู Menu bar
    /// Method : getListStudentProfile
    /// Sample : N/A
    public void getListStudentProfile()
    {
        string _html = ActStdUI.getListStudentProfile(_username);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 ก.ค. 2560
    /// Perpose: แสดงเมนู Menu bar
    /// Method : loadBarMenuStd
    /// Sample : N/A
    public void loadBarMenuStd()
    {
        string _html = ActStdUI.loadBarMenuStd(_username, _facultyCodePermission, _facultyNamePermission, _fullname);
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