<%@ WebHandler Language="C#" Class="actProjectHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
public class actProjectHandler : IHttpHandler
{

    public HttpContext _c;
    string _username;
    string _facultyIdPermission;
    string _facultyNamePermission;
    string _facultyCodePermission;
    string _levelPermission;
    public void ProcessRequest(HttpContext context)
    {

        context.Response.ContentType = "text/plain";
        context.Response.ContentType = "application/java";
        _c = context;
        string _act = _c.Request["action"];
        Login _login = new Login("staff");
        _username = _login.Username;
       // _username = "jate.khr"; // เอาขึ้น 10.90.101.101
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
            case "setProject":
                setProject();
                break;
            case "getListProject":
                getListProject();
                break;
            case "getListProjectDetail":
                getListProjectDetail();
                break;
            case "LoadPageAddNewProject":
                LoadPageAddNewProject();
                break;
            case "setProjectSection":
                setProjectSection();
                break;
            case "setProjectBudget":
                setProjectBudget();
                break;
            case "setProjectIndicator":
                setProjectIndicator();
                break;
            case "setProjectCharacter":
                setProjectCharacter();
                break;
            case "setProjectDevice":
                setProjectDevice();
                break;
            case "setUpdateProject":
                setUpdateProject();
                break;
            case "setProjectPicture":
                setProjectPicture();
                break;
            case "uploadPicture":
                uploadPicture();
                break;
            case "addSectionRegisterStudentOnly":
                addSectionRegisterStudentOnly();
                break;
            case "setStudentRegistSection":
                setStudentRegistSection();
                break;
            case "setCancelStudentRegist":
                setCancelStudentRegist();
                break;
            case "editSectionPage":
                editSectionPage();
                break;
            case "setUpdateProjectSection":
                setUpdateProjectSection();
                break;
            case "editProjectBudgetPage":
                editProjectBudgetPage();
                break;
            case "setUpdateTransProjectBudget":
                setUpdateTransProjectBudget();
                break;
            case "editProjectIndicatorPage":
                editProjectIndicatorPage();
                break;
            case "setUpdateTransProjectIndicator":
                setUpdateTransProjectIndicator();
                break;
            case "editProjectDevicePage":
                editProjectDevicePage();
                break;
            case "setUpdateTransProjectDevice":
                setUpdateTransProjectDevice();
                break;
            case "setCancelProjectPicture":
                setCancelProjectPicture();
                break;
            case "setCancelProjectDevice":
                setCancelProjectDevice();
                break;
            case "setCancelProjectIndicator":
                setCancelProjectIndicator();
                break;
            case "setCancelProjectBudget":
                setCancelProjectBudget();
                break;
            case "setCancelSection":
                setCancelSection();
                break;

            case "setCancelProjectCharacter":
                setCancelProjectCharacter();
                break;
            case "ListStudentRegister":
                ListStudentRegister();
                break;

            case "getlistStudentRegistSection":
                getlistStudentRegistSection();
                break;
            case "addSectionRegisterStudentExcel":
                addSectionRegisterStudentExcel();
                break;
            case "addStudentEachOnly":
                addStudentEachOnly();
                break;
            case "setStudentRegistOnly":
                setStudentRegistOnly();
                break;
            case "uploadStdRegist":
                uploadStdRegist();
                break;
            case "connectstdlistexcel":
                connectstdlistexcel();
                break;
            case "getlistProjectMainList":
                getlistProjectMainList();
                break;
            case "setCancelProject":
                setCancelProject();
                break;
            case "pageDialogUpdatePostition":
                pageDialogUpdatePostition();
                break;
            case "SetUpdateStudentPosition":
                SetUpdateStudentPosition();
                break;
            case "setCloseProject":
                setCloseProject();
                break;
            //case "pageDialogConditionTargetGroup":
            //    pageDialogConditionTargetGroup();
            //    break;

            case "getListConditionToComplete":
                getListConditionToComplete();
                break;
            case "getClassYearCondition":
                getClassYearCondition();
                break;
            case "getFacultyCondition":
                getFacultyCondition();
                break;
            case "setCancelStdRegistByCheckBox":
                setCancelStdRegistByCheckBox();
                break;
            case "getListDdlSubIndicator":
                getListDdlSubIndicator();
                break;

            case "getListStudentRegistPublicEvent":
                getListStudentRegistPublicEvent();
                break;

            case "getListStudentRegistPublicEventBySection":
                getListStudentRegistPublicEventBySection();
                break;

            case "getlistProjectAll":
                //context.Response.ContentType = "application/javascript";
                getlistProjectAll();
                break;

            case "getProjectId":
                getProjectId();
                break;

            case "getListStdInSection":
                getListStdInSection();
                break;

            case "getDataStatusPassMuxTodisplaySelectPicker":
                getDataStatusPassMuxTodisplaySelectPicker();
                break;
            case "getDataStatusEnrollmentMuxTodisplaySelectPicker":
                getDataStatusEnrollmentMuxTodisplaySelectPicker();
                break;
            case "setCollectATHours":
                setCollectATHours();
                break;
            case "panelManageClub":
                panelManageClub();
                break;
            case "setNewClub":
                setNewClub();
                break;
            case "getListClub":
                getListClub();
                break;
            case "setCancelClub":
                setCancelClub();
                break;
            case "dialogEditClub":
                dialogEditClub();
                break;
            case "setEditClub":
                setEditClub();
                break;
            case "getListStudentInClubByClubId":
                getListStudentInClubByClubId();
                break;
            case "setCancelStudentInClub":
                setCancelStudentInClub();
                break;
            case "setNewStudentInClubByStudentCode":
                setNewStudentInClubByStudentCode();
                break;
            case "setNewStudentInClubByFile":
                setNewStudentInClubByFile();
                break;
            case "validateSubmitProject":
                validateSubmitProject();
                break;
            case "setSubmitProject":
                setSubmitProject();
                break;

        }
    }

    public void setSubmitProject()
    {

        string _projectid = _c.Request["_projectid"];
        ActDB.setSubmitProject(_projectid,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void validateSubmitProject()
    {

        string _projectid = _c.Request["_projectid"];
        DataSet _ds= ActDB.getValidateForSubmitProject(_projectid);
        //string countCheck = string.Empty;
        //string statusPassCheckSumIndicator = string.Empty;

        string statusPass = string.Empty;
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                statusPass = _dr["statusPass"].ToString();
                //countCheck = _dr["countCheck"].ToString();
                //statusPassCheckSumIndicator = _dr["statusPassCheckSumIndicator"].ToString();
            }
        }
        // แก้กระบวนการให้คำนวณใน Proc ไปแล้ว
        //if (Convert.ToInt32(countCheck) >= 3 && statusPassCheckSumIndicator == "1")
        //{
        //    data = "true";
        //}
        //else if (Convert.ToInt32(countCheck) >= 3 && statusPassCheckSumIndicator == "0")
        //{
        //    data = "false_notsumindicator_same";
        //}
        //else 
        //{ 
        //     data = "false";
        //}
        _c.Response.Write(statusPass);
    }

    public void setNewStudentInClubByFile()
    {
        string _ddlClub = _c.Request["ddlClub"];
        string _fileName = _c.Request["fileName"];
        string _extName = _c.Request["extName"];
        string _ddlAcaYear = _c.Request["ddlAcaYear"];
        string _ddlSemester = _c.Request["ddlSemester"];
        //string _sectionId = _c.Request["sectionId"];

        string _stsMsg = "";
        string _no = string.Empty, _studentCode = string.Empty;
        string _fullName = string.Empty, _year = string.Empty, _facultyId = string.Empty;
        string _programme = string.Empty, _grade = string.Empty, _comment = string.Empty;
        string _position = string.Empty;
        int _i = 1;
        string _currentPath = _c.Server.MapPath("~/file/");
        string _urlFile = _currentPath + _fileName;


        try
        {
            DataTable _dt = ReadExcelFile("datastudent", _urlFile);
            ActDB.setNewStudentInClubByFile(_ddlAcaYear,_ddlSemester,_ddlClub , _dt , _username);
            int _row = _dt.Rows.Count;
            //for (int i = 0; i < _row; i++)
            //{
            //    _studentCode = _dt.Rows[i]["StudentCode"].ToString();
            //    _position = _dt.Rows[i]["Position"].ToString();
            //    // _stsMsg += "<div class='row'>"+_studentCode +" "+_position+"</div>";
            //}
            if (_row > 0)
            {
                _stsMsg = "1"; // ถ้าเท่ากับ 1 แปลว่าบันทึกข้อมูลเรียบร้อยแล้ว
            }
            else
            {
                _stsMsg = "0"; // ไม่มีข้อมูลนักศึกษาในการอัพโหลดไฟล์
            }
        }
        catch (Exception ex)
        {
            _stsMsg = ex.Message;
        }

        _c.Response.Write(_stsMsg);
    }

    public void setNewStudentInClubByStudentCode()
    {

        string _ddlClub = _c.Request["_ddlClub"];
        string _ddlPosition = _c.Request["_ddlPosition"];
        string _txtStudentCode = _c.Request["_txtStudentCode"];
        string _ddlAcaYear = _c.Request["_ddlAcaYear"];
        string _ddlSemester = _c.Request["_ddlSemester"];
        string _statusSame = string.Empty;
        DataSet _ds= ActDB.setNewStudentInClubByStudentCode(_ddlAcaYear,_ddlSemester,_ddlClub,_ddlPosition,_txtStudentCode,_username);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _statusSame = _dr["statusSame"].ToString();
            }
        }
        _c.Response.Write(_statusSame);

    }

    public void setCancelStudentInClub()
    {

        string _id = _c.Request["_id"];
        ActDB.setCancelStudentInClub(_id,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");

    }

    public void getListStudentInClubByClubId()
    {
        string _clubId = _c.Request["clubId"];
        string _html = ActUI.getListStudentInClubByClubId(_clubId);
        _c.Response.Write(_html);
    }

    public void setEditClub()
    {
        string _clubId = _c.Request["_clubId"];
        string _txtClubNameTh = _c.Request["_txtClubNameTh"];
        string _txtClubNameEn = _c.Request["_txtClubNameEn"];
        string _txtClubDetailTh = _c.Request["_txtClubDetailTh"];
        string _txtClubDetailEn = _c.Request["_txtClubDetailEn"];
        string _txtMail = _c.Request["_txtMail"];
        string _txtPlace = _c.Request["_txtPlace"];
        string _txtPhone = _c.Request["_txtPhone"];
        ActDB.setEditClub(_txtClubNameTh,_txtClubNameEn,_txtClubDetailTh,_txtClubDetailEn,_txtMail,_txtPlace,_txtPhone,_clubId,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void dialogEditClub()
    {
        string _clubId = _c.Request["_clubId"];
        string _html = ActUI.dialogEditClub(_facultyIdPermission,_clubId);
        _c.Response.Write(_html);
    }


    public void setCancelClub()
    {

        string _clubId = _c.Request["_clubId"];
        ActDB.setCancelClub(_clubId,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");

    }

    public void getListClub()
    {
        string _html = ActUI.getListClub(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    public void setNewClub()
    {

        string _txtClubNameTh = _c.Request["_txtClubNameTh"];
        string _txtClubNameEn = _c.Request["_txtClubNameEn"];
        string _txtClubDetailTh = _c.Request["_txtClubDetailTh"];
        string _txtClubDetailEn = _c.Request["_txtClubDetailEn"];
        string _txtMail = _c.Request["_txtMail"];
        string _txtPlace = _c.Request["_txtPlace"];
        string _txtPhone = _c.Request["_txtPhone"];
        ActDB.setNewClub(_txtClubNameTh,_txtClubNameEn,_txtClubDetailTh,_txtClubDetailEn,_txtMail,_txtPlace,_txtPhone,_facultyIdPermission,_username);
        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }

    public void panelManageClub()
    {

        // string _facultyId = _c.Request["facultyId"];
        string _html = ActUI.panelManageClub(_facultyIdPermission,_username);
        _c.Response.Write(_html);
    }

    public void setCollectATHours()
    {
        string apiKey = _c.Request["apiKey"];
        DataSet _dsPermiss = ActDB.getApiPermission(apiKey,"setCollectATHours");

        if (_dsPermiss.Tables[0].Rows.Count > 0)
        {

            try
            {
                _c.Response.ContentType = "application/json";
                string documentContents;
                using (Stream receiveStream = _c.Request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                var obj = (Newtonsoft.Json.JsonConvert.DeserializeObject(documentContents) as Newtonsoft.Json.Linq.JObject)["itemList"].ToString();
                //var _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(_c.Request["itemList"]);
                var _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(obj);
                //ActDB.setApiCollectATHours(_dataList, _username);


                DataSet _ds = ActDB.setApiCollectATHours(_dataList);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(_ds.Tables[0]);
                string result = @"{ ""success"": true, ""message"": ""request is success"" }";
                _c.Response.Write(result);


            }
            catch (Exception ex)
            {
                string result = @"{ ""success"": false, ""message"": ""bad request with, " + ex.Message + @""" }";
                _c.Response.Write(result);
            }
        }
        else
        {
            // string result = @"{ ""success"": false, ""message"": ""no permission to access"" , ""ip"": ""bad request with, " + ip + @""" }";
            string result = @"{ ""success"": false, ""message"": ""no permission to access"" }";
            _c.Response.Write(result);
        }


    }

    //public static string ToJson(this DataTable dt)
    //{
    //    List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
    //    Dictionary<string, object> item;
    //    foreach (DataRow row in dt.Rows)
    //    {
    //            item = new Dictionary<string, object>();
    //                foreach (DataColumn col in dt.Columns)
    //                {
    //                    item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));       
    //                }
    //        lst.Add(item);
    //    }
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(lst);
    //}


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


    public class studentCollectAT
    {
        public string studentCode { get; set; }
        public int hours { get; set; }
        public string acaYear { get; set; }
        public int semester { get; set; }
        public string serviceName { get; set; }
    }


    // Converts the specified JSON string to an object of type T
    public T Deserialize<T>(string context)
    {
        string jsonData = context;

        //cast to specified objectType
        var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
        return obj;
    }

    public void getDataStatusEnrollmentMuxTodisplaySelectPicker()
    {

        string _sectionid = _c.Request["sectionid"];
        string _statusEnrollmentMux = ActUI.getDataStatusEnrollmentMuxTodisplaySelectPicker(_sectionid);
        _c.Response.Write(_statusEnrollmentMux);
    }

    public void getDataStatusPassMuxTodisplaySelectPicker()
    {

        string _sectionid = _c.Request["sectionid"];
        string _statusPassMux = ActUI.getDataStatusPassMuxTodisplaySelectPicker(_sectionid);
        _c.Response.Write(_statusPassMux);
    }


    public void getListStdInSection()
    {

        string _projectId = _c.Request["projectId"];
        string _sectionId = _c.Request["sectionId"];
        string _html = ActUI.getlistStudentRegistSection(_projectId, _sectionId);
        _c.Response.Write(_html);
    }


    public void getProjectId()
    {

        string _html = ActUI.getProjectId(_username);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 ก.ค. 2562
    /// Perpose: 
    /// Method : getlistProjectAll
    /// Sample : N/A
    public void getlistProjectAll()
    {

        string _ddlAcaYear = _c.Request["ddlAcaYear"];
        string _ddlSemester = _c.Request["ddlSemester"];
        string _ddlFaculty = _c.Request["ddlFaculty"];
        string _projectName = _c.Request["projectName"];
        //var db = ActDB.getListProject(_ddlFaculty, _ddlAcaYear, _ddlSemester, _projectName);
        string _html = ActUI.getlistProjectAll(_ddlFaculty, _ddlAcaYear, _ddlSemester, _projectName);


        //_c.Response.ContentType = "text/json";
        //_c.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(db));
        _c.Response.Write(_html);
    }


    public void getListStudentRegistPublicEventBySection()
    {

        string _projectId = _c.Request["projectId"];
        string _sectionId = _c.Request["sectionId"];
        string _html = ActUI.getListStudentRegistPublicEventBySection(_projectId, _sectionId, "0");
        _c.Response.Write(_html);
    }

    public void getListStudentRegistPublicEvent()
    {

        string _projectId = _c.Request["projectId"];
        string _projectNameTh = _c.Request["projectNameTh"];
        string _html = ActUI.getListStudentRegistPublicEvent(_projectId, _projectNameTh);
        _c.Response.Write(_html);
    }



    public void getListDdlSubIndicator()
    {

        string _indicatorId = _c.Request["indicatorId"];
        string _html = ActUI.getListDdlSubIndicator(_indicatorId, "", _facultyIdPermission);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 9 ส.ค. 2560
    /// Perpose: ยกเลิกรายการข้อมูล
    /// Method : setCancelStdRegistByCheckBox
    public void setCancelStdRegistByCheckBox()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        var _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(_c.Request["itemList"]);
        ActDB.setCancelStdRegistByCheckBox(_dataList, _username);
        _c.Response.Write(_returnText);

    }


    public void getFacultyCondition()
    {

        string _projectId = _c.Request["projectId"];
        string _facultyCondition = ActUI.getFacultyCondition(_projectId);
        _c.Response.Write(_facultyCondition);
    }


    public void getClassYearCondition()
    {

        string _projectId = _c.Request["projectId"];
        string _classYear = ActUI.getClassYearCondition(_projectId);
        _c.Response.Write(_classYear);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 31 ก.ค. 2560
    /// Perpose: 
    /// Method : getListConditionToComplete
    /// Sample : N/A
    public void getListConditionToComplete()
    {

        string _studentCondition = _c.Request["studentCondition"];
        string _html = ActReportUI.getListConditionToComplete(_studentCondition, "");
        _c.Response.Write(_html);

    }





    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 30 ก.ค. 2560
    ///// Perpose: 
    ///// Method : pageConditionTargetGroup
    ///// Sample : N/A
    //public void pageDialogConditionTargetGroup()
    //{


    //    string _html = ActUI.pageDialogConditionTargetGroup();

    //    _c.Response.Write(_html);
    //}

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 30 ก.ค. 2560
    /// Perpose: Flag ว่าปิดโครงการ
    /// Method : setCloseProject
    public void setCloseProject()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _projectid = _c.Request["projectid"];
        // ตรวจสอบก่อนว่ามีการกรอกข้อมูล Section ข้อมูล Indicator และข้อมูลนศ.เข้าร่วมกิจกรรม หรือว่ามีการปิดโครงการนี้ไปแล้ว
        string _returnSts = ActUI.getChkForCloseProject(_projectid);
        if (_returnSts == "1")
        {
            _returnText = "โครงการนี้ได้เคยดำเนินการปิดโครงการแล้ว";
        }
        else if (_returnSts == "2")
        {
            _returnText = "กรอกข้อมูลไม่ครบ! การปิดโครงการต้องมีการกรอกข้อมูล Section ,ข้อมูล Indicator และมีข้อมูลนักศึกษาที่ร่วมในกิจกรรม";
        }
        else
        {
            ActDB.setCloseProject(_projectid, _username);
        }
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 28 ก.ค. 2560
    /// Perpose: เปลี่ยนแปลงสถานะเข้าร่วมของนศ.
    /// Method : SetUpdateStudentPosition
    public void SetUpdateStudentPosition()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transSectionRegistId = _c.Request["transsectionregistid"];
        string _positionId = _c.Request["positionid"];
        ActDB.SetUpdateStudentPosition(_transSectionRegistId, _positionId, _username);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 17 ก.ค. 2560
    /// Perpose: 
    /// Method : pageDialogUpdatePostition
    /// Sample : N/A
    public void pageDialogUpdatePostition()
    {

        string _transsectionregistid = _c.Request["transsectionregistid"];
        string _studentcode = _c.Request["studentcode"];
        string _firstname = _c.Request["firstname"];
        string _lastname = _c.Request["lastname"];
        string _positionid = _c.Request["positionid"];
        string _html = ActUI.pageDialogUpdatePostition(_transsectionregistid, _studentcode, _firstname, _lastname);

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 15 ก.ค. 2560
    /// Perpose: ยกเลิกรายการโครงการ
    /// Method : setCancelProject
    public void setCancelProject()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _projectId = _c.Request["projectId"];
        ActDB.setCancelProject(_projectId, _username);
        _c.Response.Write(_returnText);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 28 มิ.ย. 2560
    /// Perpose: 
    /// Method : getlistProjectMainList
    /// Sample : N/A
    public void getlistProjectMainList()
    {
        // string _guid = Guid.NewGuid().ToString();
        string _ddlAcaYear = _c.Request["ddlAcaYear"];
        string _ddlSemester = _c.Request["ddlSemester"];
        string _ddlFaculty = _c.Request["ddlFaculty"];
        string _projectName = _c.Request["projectName"];
        string _projectStatus = _c.Request["projectStatus"];
        string _createdBy = _c.Request["createdBy"];
        string _html = ActUI.getlistProjectMainList(_ddlAcaYear, _ddlSemester, _ddlFaculty, _projectName, _projectStatus, _createdBy);
        _c.Response.Write(_html);
    }



    public void connectstdlistexcel()
    {
        string _fileName = _c.Request["fileName"];
        string _sectionId = _c.Request["sectionId"];
        string _extName = _c.Request["extName"];
        //string _positionId = _c.Request["positionId"];
        string _html = "";
        string _no = string.Empty, _studentCode = string.Empty;
        string _fullName = string.Empty, _year = string.Empty, _facultyId = string.Empty;
        string _programme = string.Empty, _grade = string.Empty, _comment = string.Empty;
        string _position = string.Empty;
        int _i = 1;
        string _currentPath = _c.Server.MapPath("~/file/");
        string _urlFile = _currentPath + _fileName;
        // string xConnStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;  ImportMixedTypes=Text\";", _urlFile);
        //string xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _urlFile + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes\"";


        try
        {   // อ่านไฟล์เอกเซล
            //string xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _urlFile + ";Extended Properties=\"Excel 12.0 Xml;MAXSCANROWS=0\"";

            //OleDbConnection objXConn = new OleDbConnection(xConnStr);
            //objXConn.Open();
            //OleDbCommand objCommand2 = new OleDbCommand("SELECT distinct * FROM [datastudent$]", objXConn);
            //OleDbCommand objCommand = new OleDbCommand();
            //objCommand = objCommand2;
            //OleDbDataReader reader;
            //reader = objCommand.ExecuteReader();

            //while (reader.Read()) // อ่านข้อมูลตามหัวคอลัมน์
            //{

            //    _studentCode = GetValueFromReader(reader, "StudentCode");
            //    _position = GetValueFromReader(reader, "Position");
            //    _html += ActUI.addStudentRegistTemp(_studentCode, _sectionId, _position);
            //    _i++;

            //}

            //reader.Close();
            //objXConn.Close();
            DataTable _dt = ReadExcelFile("datastudent", _urlFile);
            int _row = _dt.Rows.Count;
            for (int i = 0; i < _row; i++)
            {
                _studentCode = _dt.Rows[i]["StudentCode"].ToString();
                _position = _dt.Rows[i]["Position"].ToString();
                _html += ActUI.addStudentRegistTemp(_studentCode, _sectionId, _position);
            }


        }
        catch (Exception ex)
        {
            _html = ex.Message;
        }

        _c.Response.Write(_html);
    }


    private DataTable ReadExcelFile(string sheetName, string path)
    {

        using (OleDbConnection conn = new OleDbConnection())
        {
            DataTable dt = new DataTable();
            string Import_FileName = path;
            string fileExtension = Path.GetExtension(Import_FileName);
            if (fileExtension == ".xls")
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
            if (fileExtension == ".xlsx")
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            //   conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;IMEX=1;MAXSCANROWS=0'";
            using (OleDbCommand comm = new OleDbCommand())
            {
                comm.CommandText = "Select * from [" + sheetName + "$]";

                comm.Connection = conn;

                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    da.SelectCommand = comm;
                    da.Fill(dt);
                    return dt;
                }

            }
        }
    }





    public void uploadStdRegist()
    {

        string _newFileName = Guid.NewGuid().ToString();
        string _extName = _c.Request["extname"];
        bool _chkSuccess = false;
        string _errMsg = string.Empty;

        try
        {
            _c.Request.Files["excelStdRegistUpload"].SaveAs(string.Join("\\", _c.Server.MapPath("../../file"), _newFileName + "." + _extName));
            _chkSuccess = true;
        }
        catch (Exception ex)
        {
            _errMsg = ex.Message;
        }

        //string _retJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
        //{
        //    isSuccess = _chkSuccess,
        //    fileName = _newFileName,
        //    errorMessage = _errMsg
        //});

        StringBuilder _sbRet = new StringBuilder();
        _sbRet.Append("{");
        _sbRet.AppendFormat("'isSuccess': {0},", _chkSuccess ? "true" : "false");
        _sbRet.AppendFormat("'fileName': '{0}',", _newFileName);
        _sbRet.AppendFormat("'errorMessage': '{0}',", _errMsg);
        _sbRet.AppendFormat("'extName': '{0}'", _extName);

        _sbRet.Append("}");

        _c.Response.ContentType = "text/html";
        _c.Response.Write("<script>parent.callback_uploadfile(" + _sbRet.ToString() + ");</script>");
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 24 มิ.ย. 2560
    /// Perpose: 
    /// Method : setStudentRegistOnly
    /// Sample : N/A
    public void setStudentRegistOnly()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        var _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(_c.Request["itemList"]);
        string _uId = _c.Request["uId"];
        ActDB.setListStudentRegist(_dataList, _uId, _username);

        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 23 มิ.ย. 2560
    /// Perpose: 
    /// Method : addStudentEachOnly
    /// Sample : N/A
    public void addStudentEachOnly()
    {

        string _sectionId = _c.Request["sectionId"];
        string _studentCode = _c.Request["studentCode"];
        string _positionId = _c.Request["positionId"];
        string _html = ActUI.addStudentRegistTemp(_studentCode, _sectionId, _positionId);

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 21 มิ.ย. 2560
    /// Perpose: 
    /// Method : addSectionRegisterStudentExcel
    /// Sample : N/A
    public void addSectionRegisterStudentExcel()
    {

        string _projectId = _c.Request["projectId"];
        string _projectNameTh = _c.Request["projectNameTh"];
        string _html = ActUI.addSectionRegisterStudentExcel(_projectId, _projectNameTh);

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 21 มิ.ย. 2560
    /// Perpose: 
    /// Method : getlistStudentRegistSection
    /// Sample : N/A
    public void getlistStudentRegistSection()
    {

        string _projectId = _c.Request["projectId"];
        string _html = ActUI.getListSectionList(_projectId);
        // string _html = ActUI.getlistStudentRegistSection(_projectId);

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 21 มิ.ย. 2560
    /// Perpose: 
    /// Method : ListStudentRegister
    /// Sample : N/A
    public void ListStudentRegister()
    {

        string _projectId = _c.Request["projectId"];
        string _html = ActUI.ListStudentRegister(_projectId, "","0");

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ Project Character
    /// Method : setCancelProjectCharacter
    public void setCancelProjectCharacter()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transSectionCharacterId = _c.Request["transSectionCharacterId"];
        ActDB.setCancelProjectCharacter(_transSectionCharacterId, _username);
        _c.Response.Write(_returnText);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ Section
    /// Method : setCancelSection
    public void setCancelSection()
    {

        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _sectionId = _c.Request["sectionId"];
        ActDB.setCancelSection(_sectionId, _username);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ Budget
    /// Method : setCancelProjectBudget
    public void setCancelProjectBudget()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transProjectBubgetId = _c.Request["transProjectBubgetId"];
        ActDB.setCancelProjectBudget(_transProjectBubgetId, _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ Indicator
    /// Method : setCancelProjectIndicator
    public void setCancelProjectIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transSectionIndicatorId = _c.Request["transSectionIndicatorId"];
        ActDB.setCancelProjectIndicator(_transSectionIndicatorId, _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ Device
    /// Method : setCancelProjectDevice
    public void setCancelProjectDevice()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transSectionDeviceId = _c.Request["transSectionDeviceId"];
        ActDB.setCancelProjectDevice(_transSectionDeviceId, _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการรูปภาพ
    /// Method : setCancelProjectPicture
    public void setCancelProjectPicture()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _transProjectPictureId = _c.Request["transProjectPictureId"];
        ActDB.setCancelProjectPicture(_transProjectPictureId, _username);
        _c.Response.Write(_returnText);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Project Device ใหม่
    /// Method : setUpdateTransProjectDevice
    public void setUpdateTransProjectDevice()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _deviceId = _c.Request["deviceId"];
        string _startDateDevice = _c.Request["startDateDevice"];
        string _endDateDevice = _c.Request["endDateDevice"];
        string _transSectionDeviceId = _c.Request["transSectionDeviceId"];
        ActDB.setUpdateTransProjectDevice(_uId,
                            _sectionId,
                            _deviceId,
                            _startDateDevice,
                            _endDateDevice,
                            _username,
                            _transSectionDeviceId);
        _c.Response.Write(_returnText);
    }




    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูล edit Project Device
    /// Method : editProjectDevicePage
    /// Sample : N/A
    public void editProjectDevicePage()
    {
        string _transSectionDeviceId = _c.Request["transSectionDeviceId"];
        string _projectId = _c.Request["projectId"];

        string _html = ActUI.editProjectDevicePage(_transSectionDeviceId, _projectId);
        _c.Response.Write(_html);
    }

    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 19 มิ.ย. 2560
    ///// Perpose: แสดงรายการข้อมูล edit Project CharacterPage 
    ///// Method : editProjectCharacterPage
    ///// Sample : N/A
    //public void editProjectCharacterPage()
    //{
    //    string _transSectionIndicatorId = _c.Request["transsectionindicatorid"];
    //    string _projectId = _c.Request["projectId"];
    //    string _html = ActUI.editProjectCharacterPage(_transSectionIndicatorId, _projectId);
    //    _c.Response.Write(_html);
    //}


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Project Indicator
    /// Method : setUpdateTransProjectIndicator
    public void setUpdateTransProjectIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _indicatorId = _c.Request["indicatorId"];
        string _subIndicatorId = _c.Request["subIndicatorId"];
        string _projectIndicatoeHour = _c.Request["projectIndicatoeHour"];
        string _transSectionIndicatorId = _c.Request["transsectionindicatorid"];
        string _description = _c.Request["description"];
        ActDB.setUpdateTransProjectIndicator(_uId,
                            _sectionId,
                            _indicatorId,
                            _projectIndicatoeHour,
                            _username,
                            _transSectionIndicatorId,
                            _subIndicatorId,
                            _description);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 19 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูล edit Project Indicator 
    /// Method : editProjectIndicatorPage
    /// Sample : N/A
    public void editProjectIndicatorPage()
    {
        string _transSectionIndicatorId = _c.Request["transsectionindicatorid"];
        string _projectId = _c.Request["projectId"];
        string _html = ActUI.editProjectIndicatorPage(_transSectionIndicatorId, _projectId, _facultyIdPermission);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 18 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Project Budget 
    /// Method : setUpdateTransProjectBudget
    public void setUpdateTransProjectBudget()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _transProjectBubgetId = _c.Request["transProjectBubgetId"];
        string _budgetTypeId = _c.Request["budgetTypeId"];
        string _budget = _c.Request["budget"];
        string _paid = _c.Request["paid"];
        ActDB.setUpdateTransProjectBudget(_uId,
                            _transProjectBubgetId,
                            _budgetTypeId,
                            _budget,
                            _paid,
                            _username);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 18 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูล editProjectBudget 
    /// Method : editProjectBudgetPage
    /// Sample : N/A
    public void editProjectBudgetPage()
    {

        string _transProjectBubgetId = _c.Request["transProjectBubgetId"];
        string _html = ActUI.editProjectBudgetPage(_transProjectBubgetId, _facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 18 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Project Section 
    /// Method : setUpdateProjectSection
    public void setUpdateProjectSection()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _projectSectionId = _c.Request["projectSectionId"];
        //string _acaYear = _c.Request["acaYear"];
        //string _semester = _c.Request["semester"];
        string _sectionNameTh = _c.Request["sectionNameTh"];
        string _sectionNameEn = _c.Request["sectionNameEn"];
        string _startDateProjectSection = _c.Request["startDateProjectSection"];
        string _endDateProjectSection = _c.Request["endDateProjectSection"];
        string _amountSection = _c.Request["amountSection"];
        string _placeSection = _c.Request["placeSection"];
        string _txtMuxRefId = _c.Request["txtMuxRefId"];
        string _ddlStatusPassMux = _c.Request["ddlStatusPassMux"];
        string _ddlStatusEnrollmentMux = _c.Request["ddlStatusEnrollmentMux"];
        _ddlStatusPassMux = (_ddlStatusPassMux == "null") ? "" : _ddlStatusPassMux;
        _ddlStatusEnrollmentMux = (_ddlStatusEnrollmentMux == "null") ? "" : _ddlStatusEnrollmentMux;

        _ddlStatusPassMux = _ddlStatusPassMux.Replace("%2C", ",");
        _ddlStatusEnrollmentMux = _ddlStatusEnrollmentMux.Replace("%2C", ",");


        ActDB.setUpdateProjectSection(_uId,
                            _projectSectionId,
                            _sectionNameTh,
                            _sectionNameEn,
                            _startDateProjectSection,
                            _endDateProjectSection,
                            _amountSection,
                            _placeSection,
                            _username,
                            _txtMuxRefId,
                            _ddlStatusPassMux,
                            _ddlStatusEnrollmentMux);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 18 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูล Section Page
    /// Method : editSectionPage
    /// Sample : N/A
    public void editSectionPage()
    {

        string _sectionid = _c.Request["sectionid"];
        string _html = ActUI.editSectionPage(_sectionid);

        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 6 มิ.ย. 2560
    /// Perpose: Update ข้อมูลนักศึกษาเพื่อยกเลิกการเข้าร่วม Section
    /// Method : setCancelStudentRegist
    public void setCancelStudentRegist()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _studentid = _c.Request["studentid"];
        string _transsectionregistid = _c.Request["transsectionregistid"];
        ActDB.setCancelStudentRegist(_transsectionregistid,
                            _username);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 มิ.ย. 2560
    /// Perpose: Insert ข้อมูลนักศึกษาใหม่ลงใน Section
    /// Method : setStudentRegistSection
    public void setStudentRegistSection()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _projectId = _c.Request["projectId"];
        string _sectionId = _c.Request["sectionId"];
        string _studentCode = _c.Request["studentCode"];
        string _positionId = _c.Request["positionId"];
        ActDB.setStudentRegistSection(_uId,
                            _projectId,
                            _sectionId,
                            _studentCode,
                            _username,
                            _positionId);
        _c.Response.Write(_returnText);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลรายละเอียดการสร้างเงือนไขคอนดิชั่น
    /// Method : addSectionRegisterStudentOnly
    /// Sample : N/A
    public void addSectionRegisterStudentOnly()
    {

        string _projectId = _c.Request["projectId"];
        string _projectNameTh = _c.Request["projectNameTh"];
        string _html = ActUI.addSectionRegisterStudentOnly(_projectId, _projectNameTh);

        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Picture ใหม่
    /// Method : setProjectPicture
    public void setProjectPicture()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _projectId = _c.Request["projectId"];
        string _pictureName = _c.Request["pictureName"];
        string _pictureDetail = _c.Request["pictureDetail"];
        string _filename = _c.Request["filename"];
        string _typeFileUploadId = _c.Request["typeFileUploadId"];
        ActDB.setProjectPicture(_uId,
                            _projectId,
                            _pictureName,
                            _pictureDetail,
                            _filename,
                            _username,
                            _typeFileUploadId);
        _c.Response.Write(_returnText);
    }

    public void uploadPicture()
    {
        string _extention = _c.Request["extention"];
        string _newFileName = Guid.NewGuid().ToString() + "." + _extention;
        bool _chkSuccess = false;
        string _errMsg = string.Empty;

        try
        {
            _c.Request.Files["pictureUpload"].SaveAs(string.Join("\\", _c.Server.MapPath("../../images"), _newFileName));
            _chkSuccess = true;
        }
        catch (Exception ex)
        {
            _errMsg = ex.Message;
        }

        //string _retJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
        //{
        //    isSuccess = _chkSuccess,
        //    fileName = _newFileName,
        //    errorMessage = _errMsg
        //});

        StringBuilder _sbRet = new StringBuilder();
        _sbRet.Append("{");
        _sbRet.AppendFormat("'isSuccess': {0},", _chkSuccess ? "true" : "false");
        _sbRet.AppendFormat("'fileName': '{0}',", _newFileName);
        _sbRet.AppendFormat("'errorMessage': '{0}'", _errMsg);
        _sbRet.Append("}");

        _c.Response.ContentType = "text/html";
        _c.Response.Write("<script>parent.callback_uploadfile(" + _sbRet.ToString() + ");</script>");
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Project ใหม่
    /// Method : setUpdateProject
    public void setUpdateProject()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _instituteId = _c.Request["instituteId"];
        string _projectNameTh = _c.Request["projectNameTh"];
        string _projectNameEn = _c.Request["projectNameEn"];
        string _projectDetail = _c.Request["projectDetail"];
        string _projectDetailEn = _c.Request["projectDetailEn"];
        string _projectTypeId = _c.Request["projectTypeId"];
        //string _projectStatusId = _c.Request["projectStatusId"];
        //string _targetGroup = _c.Request["targetGroup"];
        string _projectId = _c.Request["projectId"];
        //string _facultyId = _c.Request["facultyId"];
        string _startDateRecruit = _c.Request["startDateRecruit"];
        string _endDateRecruit = _c.Request["endDateRecruit"];
        string _facultyStr = _c.Request["facultyStr"];
        string _classYearStr = _c.Request["classYearStr"];
        string _studentCodeStr = _c.Request["conditionStudentCodeStr"];
        _facultyStr = (_facultyStr == "null") ? "" : _facultyStr;
        _classYearStr = (_classYearStr == "null") ? "" : _classYearStr;
        _facultyStr = _facultyStr.Replace("%2C", ",");
        _classYearStr = _classYearStr.Replace("%2C", ",");


        ActDB.setUpdateProject(_uId,
                            _acaYear,
                            _semester,
                            _instituteId,
                            _projectNameTh,
                            _projectNameEn,
                            _projectDetail,
                            _projectTypeId,
                            _username,
                            _projectId,
                            _facultyIdPermission,
                            _startDateRecruit,
                            _endDateRecruit,
                            _facultyStr,
                            _classYearStr,
                            _studentCodeStr,
                            _projectDetailEn);
        _c.Response.Write(_returnText);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Device ใหม่
    /// Method : setProjectDevice
    public void setProjectDevice()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _deviceId = _c.Request["deviceId"];
        string _startDateDevice = _c.Request["startDateDevice"];
        string _endDateDevice = _c.Request["endDateDevice"];
        ActDB.setProjectDevice(_uId,
                            _sectionId,
                            _deviceId,
                            _startDateDevice,
                            _endDateDevice,
                            _username);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Character ใหม่
    /// Method : setProjectCharacter
    public void setProjectCharacter()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _characterStr = _c.Request["characterStr"];

        _characterStr = _characterStr.Replace("%2C", ",");
        ActDB.setProjectCharacter(_uId,
                            _sectionId,
                            _characterStr,
                            _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Indicator ใหม่
    /// Method : setProjectIndicator
    public void setProjectIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _sectionId = _c.Request["sectionId"];
        string _indicatorId = _c.Request["indicatorId"];
        string _subIndicatorId = _c.Request["subIndicator"];

        string _projectIndicatoeHour = _c.Request["projectIndicatoeHour"];
        string _description = _c.Request["description"];

        ActDB.setProjectIndicator(_uId,
                            _sectionId,
                            _indicatorId,
                            _projectIndicatoeHour,
                            _username,
                            _subIndicatorId,
                            _description);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 4 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Budget ใหม่
    /// Method : setProjectBudget
    public void setProjectBudget()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _projectId = _c.Request["projectId"];
        string _budgetTypeId = _c.Request["budgetTypeId"];
        string _budget = _c.Request["budget"];
        string _paid = _c.Request["paid"];
        ActDB.setProjectBudget(_uId,
                            _projectId,
                            _budgetTypeId,
                            _budget,
                            _paid,
                            _username);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 3 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Project Section ใหม่
    /// Method : setProjectSection
    public void setProjectSection()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _projectId = _c.Request["projectId"];
        string _sectionNameTh = _c.Request["sectionNameTh"];
        string _sectionNameEn = _c.Request["sectionNameEn"];
        string _startDateProjectSection = _c.Request["startDateProjectSection"];
        string _endDateProjectSection = _c.Request["endDateProjectSection"];
        string _amountSection = _c.Request["amountSection"];
        string _placeSection = _c.Request["placeSection"];
        string _txtMuxRefId = _c.Request["txtMuxRefId"];
        string _ddlStatusPassMux = _c.Request["ddlStatusPassMux"];
        string _ddlStatusEnrollmentMux = _c.Request["ddlStatusEnrollmentMux"];
        _ddlStatusPassMux = (_ddlStatusPassMux == "null") ? "" : _ddlStatusPassMux;
        _ddlStatusEnrollmentMux = (_ddlStatusEnrollmentMux == "null") ? "" : _ddlStatusEnrollmentMux;

        _ddlStatusPassMux = _ddlStatusPassMux.Replace("%2C", ",");
        _ddlStatusEnrollmentMux = _ddlStatusEnrollmentMux.Replace("%2C", ",");

        ActDB.setProjectSection(_uId,
                            _projectId,
                            _sectionNameTh,
                            _sectionNameEn,
                            _startDateProjectSection,
                            _endDateProjectSection,
                            _amountSection,
                            _placeSection,
                            _username,
                            _txtMuxRefId,
                            _ddlStatusPassMux,
                            _ddlStatusEnrollmentMux
                            );
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 26 พ.ค. 2560
    /// Perpose: แสดงหน้าสำหรับเพิ่มข้อมูลโครงการใหม่
    /// Method : LoadPageAddNewProject
    /// Sample : N/A
    public void LoadPageAddNewProject()
    {
        string _html = ActUI.LoadPageAddNewProject(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 พ.ค. 2560
    /// Perpose: Insert ข้อมูล Project ใหม่
    /// Method : setProject
    public void setProject()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _instituteId = _c.Request["instituteId"];
        string _projectNameTh = _c.Request["projectNameTh"];
        string _projectNameEn = _c.Request["projectNameEn"];
        string _projectDetail = _c.Request["projectDetail"];
        string _projectDetailEn = _c.Request["projectDetailEn"];
        string _projectTypeId = _c.Request["projectTypeId"];
        //string _projectStatusId = _c.Request["projectStatusId"];
        //string _targetGroup = _c.Request["targetGroup"];
        //string _facultyId = _c.Request["facultyId"];
        string _startDateRecruit = _c.Request["startDateRecruit"];
        string _endDateRecruit = _c.Request["endDateRecruit"];
        string _facultyStr = _c.Request["facultyStr"];
        string _classYearStr = _c.Request["classYearStr"];
        string _studentCodeStr = _c.Request["conditionStudentCodeStr"];
        _facultyStr = (_facultyStr == "null") ? "" : _facultyStr;
        _classYearStr = (_classYearStr == "null") ? "" : _classYearStr;
        _facultyStr = _facultyStr.Replace("%2C", ",");
        _classYearStr = _classYearStr.Replace("%2C", ",");

        string _targetGroup = "";
        string _projectStatusId = "PSS-007"; // เดิมเป็น  PSS-005
        ActDB.setProject(_uId,
                            _acaYear,
                            _semester,
                            _instituteId,
                            _projectNameTh,
                            _projectNameEn,
                            _projectDetail,
                            _projectTypeId,
                            _targetGroup,
                            _username,
                            _facultyIdPermission,
                            _startDateRecruit,
                            _endDateRecruit,
                            _facultyStr,
                            _classYearStr,
                            _studentCodeStr,
                            _projectDetailEn,
                            _projectStatusId);
        _c.Response.Write(_returnText);


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 5 พ.ค. 2560
    /// Perpose: แสดงรายการข้อมูลโครงการทั้งหมด
    /// Method : getListProject
    /// Sample : N/A
    public void getListProject()
    {

        string _ddlAcaYear = _c.Request["ddlAcaYear"];
        string _ddlSemester = _c.Request["ddlSemester"];
        string _ddlFaculty = _c.Request["ddlFaculty"];
        string _projectName = _c.Request["projectName"];

        string _html = ActUI.getListProject(_username, _facultyIdPermission, _facultyNamePermission, _facultyCodePermission, _ddlAcaYear, _ddlSemester, _ddlFaculty, _projectName);
        _c.Response.Write(_html);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2560
    /// Perpose: แสดงรายการข้อมูลรายละเอียดโครงการโครงการ
    /// Method : getListProjectDetail
    /// Sample : N/A
    public void getListProjectDetail()
    {

        string _projectId = _c.Request["projectId"];
        string _statusEdit = _c.Request["statusEdit"];
        _statusEdit = (_statusEdit == null) ? "" : _statusEdit;

        string _html = ActUI.getListProjectDetail(_projectId, _facultyIdPermission, _statusEdit,_levelPermission);
        string _data = "";
        if (_statusEdit == "N")
        {
            _data += @" <div >
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>รายละเอียดของโครงการ</h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + _html + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>

                                            </div>
                                        </div>
                                    </p>
                                  </div>
                       
                                </div>

                              </div>
                            </div>";
        }
        else
        {
            _data = _html;
        }
        //        string _data = "";
        //        _data = @"  <div id='divTT'>
        //                              <div class='modal-dialog'>
        //
        //                                
        //                                <div class='modal-content'>
        //                                  <div class='modal-header'>
        //                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
        //                                    <h4 class='modal-title'>แก้ไขข้อมูลตัวชี้วัดของ Section </h4>
        //                                  </div>
        //                                  <div class='modal-body'>
        //                                    <p>688
        //                                        <div class='row'>
        //                                            <div class='form-group col-xs-12  text-center '>
        //                                             <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk '> บันทึก</button>                       
        //                                
        //</div>
        //                                        </div>
        //                                    </p>
        //                                  </div>
        //                               
        //                                </div>
        //
        //                              </div>
        //                            </div";
        _c.Response.Write(_data);


    }
    protected string GetValueFromReader(OleDbDataReader myreader, string stringValue)
    {
        object val = myreader[stringValue];
        if (val != DBNull.Value)
            return val.ToString();
        else
            return "";
    }





}