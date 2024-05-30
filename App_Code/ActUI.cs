using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for ActUI
/// </summary>
public class ActUI
{
    public ActUI()
    {

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-03
    /// Perpose: แสดงเมนูด้านซ้ายมือของเจ้าหน้าที่ Slide bar Menu
    /// Method : loadSlidebarMenu
    /// Sample : N/A
    /// </summary>
    public static string loadSlidebarMenu(string _levelPermission,string _facultyCodePermission)
    {

        StringBuilder _string = new StringBuilder();
        string _menu1 = @" <a href='#' class='list-group-item btnLoadTabProject'>
                                    <i class='glyphicon glyphicon-home'></i> โครงการทั้งหมด
                           </a>";
        string _menu2 = @" <a href='#' class='list-group-item btnLoadTabConfig'>
                                    <i class='glyphicon glyphicon-wrench'></i> จัดการข้อมูลตั้งต้น
                                </a>";
        string _menu3 = @" ";
        string _menu4 = @" <a href='#' class='list-group-item btnLoadReport'>
                                    <i class='glyphicon glyphicon-stats'></i> รายงานสรุปกิจกรรมทั้งหมด
                                </a>";
        string _menu5 = @" <a href='#' class='list-group-item btnLoadStudent'>
                                    <i class='glyphicon glyphicon-user'></i> ค้นหานักศึกษา
                                </a>";
        string _menu6 = @" <a href='#' class='list-group-item btnLoadStudentCompleteActivity'>
                                    <i class='glyphicon glyphicon-flag'></i> นักศึกษาที่ผ่านเกณฑ์
                                </a>";
        string _menu7 = @" <a href='#' class='list-group-item btnLoadRptStatisticFac'>
                                    <i class='glyphicon glyphicon-stats'></i> รายงานสถิติส่วนงาน
                                </a>";
        //string _menu11 = @" <a href='#' class='list-group-item btnLoadRptStudentActivity'>
        //                            <i class='glyphicon glyphicon-stats'></i> รายงานนศ.เข้าร่วมกิจกรรม
        //                        </a>";
        string _menu8 = @" <a href='#' class='list-group-item btnPrintActivityTranscript'>
                                    <i class='glyphicon glyphicon-file'></i> พิมพ์ Activity Transcript
                                </a>";
        string _menu12 = @" <a href='#' class='list-group-item btnManageClub'>
                                    <i class='glyphicon glyphicon-fire'></i> ข้อมูลองค์กร/ชมรม
                                </a>";
        string _menu9 = @" <a href='#' class='list-group-item btnPrintSpiderGraph'>
                                    <i class='glyphicon glyphicon-object-align-bottom'></i> รายงาน Spider graph
                                </a>";
        string _menu10 = @" <a href='#' class='list-group-item btnPanelReportStudent'>
                                    <i class='glyphicon glyphicon-stats'></i> รายงานนศ.เข้าร่วมกิจกรรม
                                </a>";
        string _menu11 = @" <a href='#' class='list-group-item btnSurveySystem'>
                                    <i class='glyphicon glyphicon-bullhorn'></i> แบบประเมินความพึงพอใจในการใช้งานระบบ
                                </a>";
        string _menuContact = @" <a href='#' class='list-group-item btnLoadContractUs'>
                                    <i class='glyphicon glyphicon-phone-alt'></i> ติดต่อเรา
                                </a>";


        if (_levelPermission.ToLower() == "user" && _facultyCodePermission.ToLower() == "mu") // User คณะไม่ให้เห็นเมนูอะไรบ้าง
        {
            //_menu3 = "";
            _menu8 = "";
            _menu6 = "";
            _menu7 = "";
            _menu10 = "";
            _menu9 = "";
        }
        else if (_levelPermission.ToLower() == "user")
        {
            //_menu3 = "";
            _menu8 = "";
        }

        // แก้ไขวันที่ 12/9/2566 เฉพาะสิทธิ์ MU Admin จะเห็นเมนู "อนุมัติโครงการใหม่"
        if (_levelPermission.ToLower() == "admin" && _facultyCodePermission.ToLower() == "mu")
        {
            _menu3 = @" <a href='#' class='list-group-item btnLoadApprovePage'>
                                    <i class='glyphicon glyphicon-save-file'></i> อนุมัติโครงการใหม่
                                </a>";
        }

        //_string.Append(@"  </br></br></br>
        //                     <div class='list-group'>
        //                        <span class='list-group-item active'>
        //                            <b class=''>MAIN MENU</b>
        //                            <span class='pull-right' id='slide-submenu'>
        //                            </span>
        //                        </span>
        //                        " + _menu1 + @"
        //                        " + _menu2 + @"
        //                        " + _menu3 + @"
        //                        " + _menu5 + @"
        //                        " + _menu6 + @"
        //                        " + _menu7 + @"
        //                        " + _menu8 + @"
        //                        " + _menu9 + @"

        //                        " + _menuContact + @"
        //                        <a class='list-group-item' style='height:100px;'>
        //                        </a>
        //                    </div>  ");

        _string.Append(@" <div class='list-group' style='padding-top:50px; '>
                              <a class='list-group-item list-group-item-action list-group-item-info'><b>MAIN MENU</b></span></a>
                               " + _menu1 + @"
                               " + _menu2 + @"
                               " + _menu3 + @"
                               " + _menu5 + @"
                               " + _menu6 + @"
                               " + _menu7 + @"
                               " + _menu10 + @"
                               " + _menu8 + @"
                               " + _menu12 + @"
                               " + _menu9 + @"
                               " + _menu11 + @"
                           </div>");
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-04
    /// Perpose: แสดงเมนูด้านซ้ายมือของเจ้าหน้าที่ Bar Menu
    /// Method : loadBarMenu
    /// Sample : N/A
    /// </summary>
    public static string loadBarMenu(string _username, string _facultyCodePermission, string _facultyNamePermission)
    {

        StringBuilder _string = new StringBuilder();
        Login _login = new Login("staff");
        _username = _login.Username;

        //_username = "jate.khr"; // เอาขึ้น 10.90.101.101

        //_string.Append(@" < nav class='navbar navbar-inverse navbar-fixed-top'>
        //                   <div class='container-fluid'>

        //                     <div class='navbar-header'>
        //                        <a class='navbar-brand' href='#'>Mahidol Activity Transcript</a>
        //                     </div>
        //                     <ul class='nav navbar-nav'>
        //                       <li class='active'><a href='#'>Home</a></li>

        //                     </ul>
        //                     <ul class='nav navbar-nav navbar-right'>
        //                       <li><a href='#'><span class='glyphicon glyphicon-user'></span> "+_username+" "+_facultyNamePermission+ @"</a></li>
        //                       <li><a href='#' class='btnLogout'><span class='glyphicon glyphicon-log-in '></span> Logout</a></li>
        //                     </ul>
        //                  </div>

        //                </nav> </br></br>  ");

        _string.Append(@"

            <nav class='navbar navbar-default navbar-fixed-top'>
            <div class='container-fluid'>

            <div class='navbar-header'>
                <button type = 'button' class='navbar-toggle collapsed' data-toggle='collapse' data-target='#bs-example-navbar-collapse-1' aria-expanded='false'>
                   
                    <span class='sr-only'>Toggle navigation</span>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>

                </button>
                <a class='navbar-brand' href='#'><span class='label label-primary' style='font-size: 20px;'>AT</span> MU ACTIVITY TRANSCRIPT</a>
            </div>

            <div class='collapse navbar-collapse' id='bs-example-navbar-collapse-1'>

                        <ul class='nav navbar-nav navbar-right'>
                            <li><a href = '#' >
                                <div class='row' id='divProfile' style = 'padding-right:10px;' onclick = getListProject('','','','','" + _username + @"');>
                                     <b class='h4' > <span class='glyphicon glyphicon-user' style='color:darkblue;'  ></span> " + _username + @"</b>
                                     <b class='h5' >สิทธิ์ : " + _facultyNamePermission + @"</b>
                                </div>
                                </a></li>
                        </ul>
                    </div>
            </div>

      
            </nav>

        ");

        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-04
    /// Perpose: แสดงรายการข้อมูลหน่วยงาน
    /// Method : getListBudgetType
    /// Sample : N/A
    /// </summary>
    public static string getListBudgetType(string _budgetTypeId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListBudget(_facultyId);
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@" <label for='ddlBudgetType'>
                                 ประเภทแหล่งทุน</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlBudgetType'       >
                                   <option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_budgetTypeId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["budgetTypeNameTh"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลหน่วยงาน
    /// Method : getListInstitute
    /// Sample : N/A
    /// </summary>
    public static string getListInstitute(string _instituteId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListInstitute(_facultyId);
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@" <label for='ddlInstitute'>
                                 ส่วนงานผู้จัดโครงการ</label> ");
            _string.Append(@"    <select class='form-control ddlInstitute' >");
            //<option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                if (_instituteId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + " >" + _dr["instituteNameTh"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลกลุ่มนักศึกษา
    /// Method : getListTargetGroup
    /// Sample : N/A
    /// </summary>
    public static string getListTargetGroup(string _targetGroupId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListTargetGroup();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlTargetGroup'>
                                 กลุ่มของนักศึกษา</label>
                                 <select class='form-control ddlTargetGroup' >
                                <option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_targetGroupId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["targetGroupNameTh"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }



    //    /// <summary>
    //    /// Auther : เจตน์ เครือชะเอม
    //    /// Date   : 2017-05-08
    //    /// Perpose: แสดงรายการข้อมูลกลุ่มนักศึกษา
    //    /// Method : getListTargetGroup
    //    /// Sample : N/A
    //    /// </summary>
    //    public static string getLabelTargetGroup(string _targetGroup)
    //    {
    //        StringBuilder _string = new StringBuilder();

    //        _string.Append(@"
    //                            <label >
    //                            กลุ่มของนักศึกษา</label>
    //                            <button type='button' class='form-control btn btn-primary btn-sm glyphicon glyphicon-plus btnConditionTargetGroup'  data-toggle='modal' data-target='#divPopup'   > เพิ่มเงื่อนไข</button>
    //                       
    //                       ");

    //        return _string.ToString();
    //    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลประเภทโครงการ
    /// Method : getListProjectType
    /// Sample : N/A
    /// </summary>
    public static string getListProjectType(string _projectTypeId,string _isDisable)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectType(_projectTypeId);


        string _htmlBody = "";
        string _selectIndex = "";
        string _disableFlag = "";
        if (_isDisable == "1")
        {
            _disableFlag = "disabled";
        }
        else
        {
            _disableFlag = "";
        }
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_projectTypeId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                    //_disableFlag = "disabled";
                }
                else
                {
                    _selectIndex = "";
                    //_disableFlag = "";
                }
                _htmlBody += "<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["startYear"] + "-" + _dr["nameTh"] + "</option>";

            }

            _string.Append(@" <label for='ddlProjectType'>
                                 ประเภทโครงการ <span style='color:Red;font-weight:bold;'>*</span></label>
                                 <select class='form-control ddlProjectType' " + _disableFlag + @">
                                     <option value=''>กรุณาเลือก</option>");
            _string.Append(_htmlBody);
            _string.Append("</select>");
        }
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลสถานะโครงการ
    /// Method : getListProjectStatus
    /// Sample : N/A
    /// </summary>
    public static string getListProjectStatus(string _projectStatusId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectStatus();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlProjectStatus'>
                                 สถานะโครงการ</label>
                                 <select class='form-control ddlProjectStatus' >
                                <option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_projectStatusId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "   >" + _dr["nameTh"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลปีการศึกษา
    /// Method : getListAcaYear
    /// Sample : N/A
    /// </summary>
    public static string getListAcaYear(string _acaYear, string _isDisable)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListAcaYear();
        string _selectIndex = "";
        string _disabled = "";
        // กรณีหยกมาให้เปิด ให้ชั่วคราวจะ Comment หมดเพื่อให้คีย์ปี ย้อนหลัง
        if (_isDisable == "1")
        {
            _disabled = "disabled";
        }
        else
        {
            _disabled = "";
        }

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlAcaYear'>
                                 ปีการศึกษา</label>
                                 <select class='form-control ddlAcaYear' " + _disabled + ">"); // 
            if (_acaYear == "00")
            {
                _string.Append(@"<option value=''    >ทุกปีการศึกษา</option>");
            }

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                /*
                ของเจต
                if ((_acaYear == "00") && ((_dr["currentAcaYear"].ToString() == _dr["acaYear"].ToString())))
                */
                /*
                ของเอ
                */
                if ((_acaYear == "00" || _acaYear == "current") && 
                    (_dr["currentAcaYear"].ToString() == _dr["acaYear"].ToString()))
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else if (_acaYear == _dr["acaYear"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["acaYear"] + "'  " + _selectIndex + "  >" + _dr["acaYear"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลภาคการศึกษา
    /// Method : getListSemester
    /// Sample : N/A
    /// </summary>
    public static string getListSemester(string _semester)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSemester();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlSemester'>
                                 ภาคการศึกษา</label>
                                 <select class='form-control ddlSemester' >");
            if (_semester == "00")
            {
                _string.Append(@"<option value=''    >ทุกภาคการศึกษา</option>");
            }
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_semester == _dr["semester"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["semester"] + "' " + _selectIndex + "  >" + _dr["semester"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-15
    /// Perpose: แสดงรายการข้อมูล Indicator ใน Dropdownlist
    /// Method : getListDdlIndicator
    /// Sample : N/A
    /// </summary>
    public static string getListDdlIndicator(string _indicatorId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        string _selectIndex = "";
        string _groupIndicatorId = "";
        DataSet _dsMain = ActDB.getListGroupIndicator();
        if (_dsMain.Tables[0].Rows.Count > 0)
        {
            _string.Append(@" <label for='ddlIndicator'>
                                 ตัวชี้วัด</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlIndicator' ><option value=''>กรุณาเลือก</option>");
            foreach (DataRow _drMain in _dsMain.Tables[0].Rows)
            {
                _groupIndicatorId = _drMain["id"].ToString();
                _string.Append(@" <optgroup label = '" + _drMain["nameTh"] + "' ></optgroup>");

                DataSet _ds = ActDB.getListIndicator(_facultyId);
                DataRow[] _drRow = _ds.Tables[0].Select("groupIndicatorId='" + _groupIndicatorId + "'");
                int _row = _drRow.Length;


                if (_row > 0)
                {
                    for (int _i = 0; _i < _row; _i++)
                    {
                        if (_indicatorId == _drRow[_i]["id"].ToString())
                        {
                            _selectIndex = " selected = 'selected' ";
                        }
                        else
                        {
                            _selectIndex = "";
                        }
                        _string.Append(@"<option value='" + _drRow[_i]["id"] + "' " + _selectIndex + "  >&nbsp;" + _drRow[_i]["indicatorAbbrevEn"] + " - " + _drRow[_i]["indicatorNameTh"] + "</option>");
                    }
                }
            }
            _string.Append(@"</select>");
        }

        //DataSet _ds = ActDB.getListIndicator(_facultyId);
        //string _selectIndex = "";
        //if (_ds.Tables[0].Rows.Count > 0)
        //{


        //    _string.Append(@" <label for='ddlIndicator'>
        //                         ตัวชี้วัด</label> <span style='color:Red;font-weight:bold;'>*</span>
        //                         <select class='form-control ddlIndicator' >
        //                      <option value=''>กรุณาเลือก</option>
        //    ");
        //    foreach (DataRow _dr in _ds.Tables[0].Rows)
        //    {
        //        if (_indicatorId == _dr["id"].ToString())
        //        {
        //            _selectIndex = " selected = 'selected' ";
        //        }
        //        else
        //        {
        //            _selectIndex = "";
        //        }
        //        _string.Append(@"<optgroup label = 'Swedish Cars'>");
        //        _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["indicatorAbbrevEn"] + " - " + _dr["indicatorNameTh"] + "</option>");
        //        _string.Append(@"</optgroup>");
        //    }


        //}
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-15
    /// Perpose: แสดงรายการข้อมูล Section ใน Dropdownlist
    /// Method : getListSection
    /// Sample : N/A
    /// </summary>
    public static string getListSection(string _projectId, string _projectSectionId)
    {
        StringBuilder _string = new StringBuilder();
        string _selectIndex = "";
        DataSet _ds = ActDB.getListSection(_projectId, "");
        _string.Append(@" <label for='ddlSection'>
                                 ชื่อ Section</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlSection' >
                              <option value=''>กรุณาเลือก</option>");
        if (_ds.Tables[0].Rows.Count > 0)
        {



            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_projectSectionId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "'  " + _selectIndex + " >" + _dr["sectionNameTh"] + "</option>");
            }


        }
        _string.Append(@"</select>");
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-16
    /// Perpose: แสดงรายการข้อมูล Character ใน Dropdownlist
    /// Method : getListCharacter
    /// Sample : N/A
    /// </summary>
    public static string getListCharacter(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListCharacter(_facultyId);
        if (_ds.Tables[0].Rows.Count > 0)
        {


            _string.Append(@"<label for='ddlCharacter'>
                                 ชื่อ Character</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlCharacter selectpicker'  multiple>
                                <optgroup label='กรุณาเลือก' >");

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "'  >" + _dr["characterAbbrevEn"] + " " + _dr["characterNameTh"] + "</option>");
            }
            _string.Append(@"</optgroup>");

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-03
    /// Perpose: แสดงรายการข้อมูล Group Character ใน Dropdownlist
    /// Method : getListGroupCharacter
    /// Sample : N/A
    /// </summary>
    public static string getListGroupCharacter(string _groupCharacterId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListGroupCharacter(_facultyId);
        string _selectIndex = "";
        _string.Append(@" <label for='ddlGroupCharacter'>
                                 ชื่อ Group Character</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlGroupCharacter' >
                              <option value=''>กรุณาเลือก</option>");
        if (_ds.Tables[0].Rows.Count > 0)
        {



            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_groupCharacterId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + " >" + _dr["groupCharacterNameTh"] + "</option>");
            }


        }
        _string.Append(@"</select>");
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-16
    /// Perpose: แสดงรายการข้อมูล Device ใน Dropdownlist
    /// Method : getListDevice
    /// Sample : N/A
    /// </summary>
    public static string getListDevice(string _deviceInfoId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListDevice();
        string _selectIndex = "";
        _string.Append(@" <label for='ddlDevice'>
                                 ชื่อ Device</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlDevice' >
                              <option value=''>กรุณาเลือก</option>");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_deviceInfoId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "'  " + _selectIndex + " >" + _dr["deviceNumber"] + " - " + _dr["deviceNameTh"] + "</option>");
            }
        }
        _string.Append(@"</select>");
        return _string.ToString();
    }


    public static string getlistProjectMainList(string _ddlAcaYear, string _ddlSemester, string _ddlFaculty, string _projectName, string _projectStatus, string _createdBy)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProject(_ddlFaculty, _ddlAcaYear, _ddlSemester, _projectName, _createdBy);

        // _projectStatus
        //int _i = 1;
        //int _count = _ds.Tables[0].Rows.Count;
        string _projectStatusId = "";
        //string _statusManageStd = "";
        string _cancelProjectFlag = "";
        string _cssCancelProject = "";
        string _disableCancel = "";
        string _btnCancel = "";
        string _createdByDb = "";
        string _hours = "";
        DataRow[] _drRow;
        _drRow = _ds.Tables[0].Select("projectStatusId='" + _projectStatus + "'  ");
        if (_projectStatus == "")
        {
            _drRow = _ds.Tables[0].Select("projectStatusId not in ('PSS-006')  ");
        }
        else
        {
            _drRow = _ds.Tables[0].Select("projectStatusId='" + _projectStatus + "'  ");
        }
        int _row = _drRow.Length;
        _string.Append(@"   <div>
                                <table id='tblListActivityAll'  class='table table-striped'>
                                <caption><h4>รายการโครงการทั้งหมด " + _row + @" รายการ</h4></caption>
                                <thead>
                                 <tr>
                                    <th style='width:25px;'>
                                    ลำดับ
                                    </th >
                                    <th style='width:30px;'>
                                    Quarter
                                    </th>
                                    <th style='width:50px;'>
                                    รหัสกิจกรรม
                                    </th>
                                    <th >
                                    ชื่อโครงการ
                                    </th>
                                    <th  >
                                    ส่วนงานผู้จัด
                                    </th>
                                    <th >
                                    #นศ.
                                    </th>
                                    <th >
                                    #ชม.
                                    </th>
                                    <th >
                                    สถานะโครงการ
                                    </th>
                                    <th>
                                    ผู้สร้างโครงการ
                                    </th>
                                    <th >
                                    ยกเลิก
                                    </th>
                                    <th >
                                    </th>
                                    <th >
                                    </th>
                                    <th>
                                    </th>
                                    </tr>
                                    </thead>");




        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {

                _projectStatusId = _drRow[_i]["projectStatusId"].ToString();
                _cancelProjectFlag = _drRow[_i]["cancelStatus"].ToString();
                _hours = _drRow[_i]["hours"].ToString();
                _createdByDb = _drRow[_i]["createdBy"].ToString();
                if (_cancelProjectFlag == "Y")
                {
                    _cssCancelProject = "  style='text-decoration:line-through;color:red;'  ";
                    _disableCancel = " disabled='disabled' ";
                    _btnCancel = "-";
                }
                else
                {
                    _cssCancelProject = "";
                    _disableCancel = "";
                    _btnCancel = "    <a href='#' ><i  class='glyphicon glyphicon-trash ' onclick=setCancelProject('" + _drRow[_i]["id"] + "');  ></i></a>              ";
                }

                //if (_projectStatusId == "PSS-005")
                //{
                //    //_statusManageStd = "  <input style='color:red;' class='btn btn-default btn-sm ' data-projectid='" + _dr["id"] + "' onclick=alert('ต้องรออนุมัติโครงการจากส่วนกลาง'); type='button' value='ยังไม่สามารถเพิ่มนักศึกษาได้' " + _disableCancel + "/> ";
                //    _statusManageStd = @" <button type='button' class='btn btn-primary btn-sm glyphicon glyphicon-plus '  onclick=alert('555');  > เพิ่มนศ.</button> ";
                //}
                //else
                //{
                //    //_statusManageStd = " <input class='btn btn-sm btn-success btnAddSectionRegister' data-projectnameth='" + _dr["nameTh"] + "'  data-projectid='" + _dr["id"] + "' type='button' value='เพิ่มนศ.' " + _disableCancel + "/>";
                //    _statusManageStd = @" <button type='button' class='btn btn-primary btn-sm glyphicon glyphicon-plus'  onclick=alert();  > เพิ่มนศ.</button> ";
                //}

                // onclick=getlistStudentRegistSection('" + _dr["id"].ToString() + "','" + _dr["nameTh"].ToString() + "') 
                _string.Append(@" <tr " + _cssCancelProject + @">
                                    <th scope='row' >
                                    " + (_i + 1).ToString() + @"
                                    </th>
                                    <td >
                                        " + _drRow[_i]["semester"] + "/" + _drRow[_i]["acaYear"] + @"
                                    </td>

                                    <td >
                                        " + _drRow[_i]["code"] + @"
                                    </td>

                                    <td >
                                        " + _drRow[_i]["nameTh"] + @"
                                    </td>

                                    <td >
                                        " + _drRow[_i]["instituteNameTh"] + @"
                                    </td>

                    

                                    <td >
                                        " + _drRow[_i]["numStdRegist"] + @"
                                    </td>

                                    <td >
                                        " + _hours + @"
                                    </td>
                                    <td >
                                        " + _drRow[_i]["projectStatusNameTh"] + @"
                                    </td>

                                    <td >
                                        " + _createdByDb + @"
                                    </td>

                                    <td class='text-center'>
                                       " + _btnCancel + @"
                                    </td>
                                    <td >
                                        
                                        <button type='button' class='btn btn-sm btn-default glyphicon glyphicon-list-alt' data-projectid='" + _drRow[_i]["id"] + "' onclick=getListProjectDetail('" + _drRow[_i]["id"] + "','0');  " + _disableCancel + @"> รายละเอียด</button> 
                                    </td>
                                    <td >");

                if (_projectStatusId == "PSS-005" || _projectStatusId  == "PSS-007")
                {

                    _string.Append("<button type='button' class='btn btn-default btn-sm glyphicon glyphicon-plus' onclick='alertNotPermission();'  > เพิ่มนศ.</button> ");

                }
                else
                {
                    _string.Append("<button type='button' class='btn btn-default btn-sm glyphicon glyphicon-plus'  onclick=getlistStudentRegistSection('" + _drRow[_i]["id"] + "');  > เพิ่มนศ.</button>");
                }

                _string.Append(@" </td>
                                    <td >
                                        <button type='button' class='btn btn-sm btn-default glyphicon glyphicon-user btnStdOnlineRegis'  data-projectid='" + _drRow[_i]["id"] + "' data-projectnameth='" + _drRow[_i]["nameTh"] + "' > นศ.ออนไลน์</button> " + @"
                                    </td>
                                    </tr>");

                // btnProjectDetail
            }


        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='11' align='center'>
                    ไม่พบรายการ
                </td>
            
                </tr>
                ");
        }
        _string.Append(@"    </table>   </div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลโครงการทั้งหมด
    /// Method : getListProject
    /// Sample : N/A
    /// </summary>
    public static string getListProject(string _username, string _facultyId, string _facultyName, string _facultyCode, string _ddlAcaYear, string _ddlSemester, string _ddlFaculty, string _projectName)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div class='divProjectMain' >");
        _string.Append(@"<h2 class='page-header'>โครงการของ ");
        _string.Append(_facultyCode + " - " + _facultyName);


        if (_ddlAcaYear == "")
        {
            _ddlAcaYear = Convert.ToString(DateTime.Now.Year+543); // เดิม "00";
        }
        if (_ddlSemester == "")
        {
            _ddlSemester = "00";
        }

        _string.Append(@" </h2> </br>  <div class='row '>
                                      <div class='form-group col-xs-2 '>
                                           " + getListAcaYear(_ddlAcaYear, "") + @"
                                      </div>

                                      <div class='form-group col-xs-2 '>
                                           " + getListSemester(_ddlSemester) + @"
                                      </div>

                                      <div class='form-group col-xs-4 '>
                                           " + getListFaculty(_facultyId, _ddlFaculty) + @"
                                      </div>

                                      <div class='form-group col-xs-2 '>
                                           " + getListProjectStatus("") + @"
                                      </div>

                                      <div class='form-group col-xs-2 '>
                                           <label >ชื่อโครงการ</label>
                                           <input  type='text' class='txtProjectName form-control ' value='" + _projectName + @"' />  
                                      </div>
                              </div>");
        _string.Append(@"<div class='row'>
                        <div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-info btn-md btnSearchProjectMain glyphicon glyphicon-search'> ค้นหา</button>
                          <button type='button' class='btn btn-primary btn-md btnAddNewProject glyphicon glyphicon-plus'> เพิ่มโครงการใหม่</button>  
                        </div></div>");

        _string.Append("<div class='divListProjectAll' style='width:100%;'></div>");


        //   _string.Append(@"<button type='button' class='btn btn-primary btn-block btn-md btnAddNewProject glyphicon glyphicon-plus'> เพิ่มโครงการใหม่</button>");
        _string.Append("</div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายละเอียดโครงการ
    /// Method : getListProjectDetail
    /// Sample : N/A
    /// </summary>
    public static string getListProjectDetail(string _projectId, string _facultyId, string _statusEdit, string _levelPermission)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        int _i = 1;
        string _menuStr = "divProjectMenu1";
        string _acaYear = "";
        string _semester = "";
        string _projectNameTh = "";
        string _projectNameEn = "";
        string _targetGroup = "";
        string _projectTypeId = "";
        string _projectStatusId = "";
        string _projectDetail = "";
        string _projectDetailEn = "";
        string _projectStatusNameTh = "";
        string _facultyIdDb = "";
        
        string _instituteId = "";
        string _startDateRecruit = "";
        string _endDateRecruit = "";
        string _expressionStudentCode = "";
        string _expressionClassYear = "";
        string _expressionFaculty = "";
        string _startDateRecruitDisplay = "";
        string _endDateRecruitDisplay = "";
        string _bodyHtml = "";
        string _statusEdit3Tab = _statusEdit;
        string _disabledProjectType = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _bodyHtml= "<div id='" + _menuStr + "' class='tab-pane fade in active' >";

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _projectNameTh = _dr["nameTh"].ToString();
                _projectNameEn = _dr["nameEn"].ToString();
                _acaYear = _dr["acaYear"].ToString();
                _semester = _dr["semester"].ToString();
                _instituteId = _dr["instituteId"].ToString();
                _targetGroup = _dr["targetGroupNameTh"].ToString();
                _projectTypeId = _dr["projectTypeId"].ToString();
                _projectStatusId = _dr["projectStatusId"].ToString();
                _projectDetail = _dr["projectDetail"].ToString();
                _projectDetailEn = _dr["projectDetailEn"].ToString();
                _projectStatusNameTh = _dr["projectStatusNameTh"].ToString();
                _facultyIdDb = _dr["facultyId"].ToString();
                _startDateRecruit = _dr["startDateRecruit"].ToString();
                _endDateRecruit = _dr["endDateRecruit"].ToString();
                _expressionStudentCode = _dr["expressionStudentCode"].ToString();
                _expressionClassYear = _dr["expressionClassYear"].ToString();
                _expressionFaculty = _dr["expressionFaculty"].ToString();
                _startDateRecruitDisplay = _dr["startDateRecruitDisplay"].ToString();
                _endDateRecruitDisplay = _dr["endDateRecruitDisplay"].ToString();

                if (_projectStatusNameTh == "ร่างโครงการ")
                {
                    _disabledProjectType = "";
                }
                else 
                {
                    _disabledProjectType = "1";
                }
                _bodyHtml += @"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2>";
                _bodyHtml += " <p> ";

                _bodyHtml += editProjectPage(_acaYear, _semester, _projectNameTh, _projectNameEn, _projectDetail, _instituteId, _targetGroup
                                               , _projectTypeId, _projectStatusNameTh, _facultyId, _facultyIdDb, _startDateRecruitDisplay, _endDateRecruitDisplay, _expressionStudentCode, _expressionClassYear, _expressionFaculty
                                               , _projectDetailEn, _disabledProjectType);

                //                _string.Append(@"  <div class='row divAlertClosePJ hide'>
                //                                   <div class='form-group col-xs-12 ' style='color:red;'>
                //                                    * หมายเหตุ : การปิดโครงการต้องมีการกรอกข้อมูล Section ,ข้อมูล Indicator และมีข้อมูลนักศึกษาที่ร่วมในกิจกรรม
                //                                   </div></div>");
                _bodyHtml+=@"       <div class='row'>
                                        <div class='form-group col-xs-12 text-center'>
                                         <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/> ";

                // ให้ Edit ได้แค่สถานะ "รอการยืนยัน"  23 ธ.ค. 2564
                //if (_projectStatusId != "PSS-005")
                //{
                //    _bodyHtml += "";
                //}
                //else if (_statusEdit != "N")
                //{
                    _bodyHtml += @"       <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                                          <button type='button' class='btn btn-danger glyphicon glyphicon-remove btnSetCloseProject' data-projectid='" + _projectId + @"' > ปิดโครงการ</button>";
                // 24 ก.ย. 2565
                // ต้อง IF ให้เห็นเฉพาะโครงการสถานะ "PSS-007 : ร่างโครงการ" ถึงจะคลิกปุ่มส่ง "ส่งโครงการ" ได้
                // ถ้าสถานะของโครงการเป็น "ร่างโครงการ" จะแก้ไข Project กับ ProjectSection กับ ProjectIndicator
                if (_projectStatusId == "PSS-007" )
                {
                    _statusEdit3Tab = "Y"; // ถ้าเป็น N คือจะไม่เห็น Input ปุ่มให้บันทึกแก้ไข
                    _bodyHtml += " <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetUpdateProject'> บันทึก</button>";
                    _bodyHtml += " <button type='button' class='btn btn-success glyphicon glyphicon-retweet btnSetSubmitProject' data-projectid='" + _projectId + "'> <b >ส่งโครงการ</b></button>";
                }
                else // กรณีสถานะอื่นๆเราจะไม่ให้เขาแก้ไข 3 tab
                {
                    _statusEdit3Tab = "N"; // ถ้าเป็น N คือจะไม่เห็น Input ปุ่มให้บันทึกแก้ไข
                }
                //}

                // แก้ไขวันที่ 26 ส.ค. 66 กรณีเป็น admin จะให้สามารถบันทึกแก้ไขข้อมูลเกี่ยวกับโครงการทั้งหมด 6 tab ได้
                if(_levelPermission.ToLower() == "admin")
                {
                    _statusEdit3Tab = "Y";
                    _bodyHtml += " <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetUpdateProject'> บันทึก</button>";
                }


                _bodyHtml += " </div></div> </p>";
                _i += 1;

            }

            _bodyHtml += " </div>";
        }

        
        
        _bodyHtml += getListProjectSection(_projectId, _projectNameTh, _statusEdit3Tab, _projectStatusId);
        _bodyHtml += getListProjectBudget(_projectId, _projectNameTh, _facultyId, _statusEdit);
        _bodyHtml += getListProjectIndicator(_projectId, _projectNameTh, _facultyId, _statusEdit3Tab, _projectStatusId);
        _bodyHtml += getListProjectCharacter(_projectId, _projectNameTh, _facultyId, _statusEdit);
        _bodyHtml += getListProjectDeviceInfo(_projectId, _projectNameTh, _statusEdit);
        _bodyHtml += getListProjectPicture(_projectId, _projectNameTh, _statusEdit);
        _bodyHtml += "</div>";

        _string.Append(LoadMenuTabProject());
        _string.Append("<div class='tab-content'>");
        _string.Append(_bodyHtml);
        return _string.ToString();
    }

    public static string getClassYearCondition(string _projectId)
    {
        StringBuilder _string = new StringBuilder();
        string _expressionClassYear = "";
        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append("[");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _expressionClassYear = _dr["expressionClassYear"].ToString();
                _string.Append(_expressionClassYear);
            }
            _string.Append("]");
        }
        return _string.ToString();
    }


    public static string getFacultyCondition(string _projectId)
    {
        StringBuilder _string = new StringBuilder();
        string _expressionFaculty = "";
        string _facultyStr = "";
        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _expressionFaculty = _dr["expressionFaculty"].ToString();

            }



        }

        string[] words = _expressionFaculty.Split(',');
        _string.Append("[");
        foreach (string word in words)
        {
            _facultyStr += "\"" + word + "\",";
        }
        _facultyStr = _facultyStr.Substring(0, _facultyStr.Length - 1);
        _string.Append(_facultyStr);
        _string.Append("]");

        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-11
    /// Perpose: แสดงรายละเอียดข้อมูลแหล่งทุน
    /// Method : getListProjectBudget
    /// Sample : N/A
    /// </summary>
    public static string getListProjectBudget(string _projectId, string _projectNameTh, string _facultyId, string _statusEdit)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectBudget(_projectId);
        int _i = 1;
        string _menuStr = "divProjectMenu3";
        int _count = _ds.Tables[0].Rows.Count;
        string _budget = "", _paid = "";
        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");
        _string.Append(@" <table class='table'>
                <caption><h4>รายการรายรับ/รายจ่ายทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-3'>
                ชื่อแหล่งทุนภาษาไทย
                </th>
                <th class='col-sm-2'>
                ชื่อแหล่งทุนภาษาอังกฤษ
                </th>
                <th class='col-sm-2'>
                รายรับ(บาท)
                </th>
                <th class='col-sm-2'>
                รายจ่าย(บาท)
                </th>");
        if (_statusEdit != "N")
        {
            _string.Append(@"
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>");
        }
        _string.Append(@"</tr>
                          </thead> ");

        _string.Append(divProjectBudgetPage("", _facultyId));

        _string.Append(@"    <div class='row'>
                                    <div class='form-group col-xs-12 text-center'>
                                         <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");
        if (_statusEdit != "N")
        {
            _string.Append(@" <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProjectBudget'> บันทึก</button>");
        }
        _string.Append(@"</div>
                           </div></p>");
        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _paid = _dr["paid"].ToString();
                _budget = _dr["budget"].ToString();

                if (_paid == "0.0000")
                {
                    _paid = String.Format("{0:F2}", Convert.ToDouble(_paid));
                }
                else
                {
                    _paid = Convert.ToDouble(_paid).ToString("#,###.00");
                }
                if (_budget == "0.0000")
                {
                    _budget = String.Format("{0:F2}", Convert.ToDouble(_budget));
                }
                else
                {
                    _budget = Convert.ToDouble(_budget).ToString("#,###.00");
                }
                _string.Append(@"
               
                <tr >
                <th scope='row'>
                " + _i.ToString() + @"
                </th>
                <td >
                 " + _dr["budgetTypeNameTh"] + @"
                </td>
                <td >
                 " + _dr["budgetTypeNameEn"] + @"
                </td>
                <td >
                 " + _budget + @"
                </td>
                <td >
                 " + _paid + @"    
                </td>");

                if (_statusEdit != "N")
                {
                    _string.Append(@"  <td >
                 <a style='cursor:pointer;'><i  data-toggle='modal' data-target='#divPopup' data-transprojectbubgetid='" + _dr["id"].ToString() + @"' class='glyphicon glyphicon-edit btnEditProjectBudget'></i></a>
                </td>
                <td >
                <a href='#'><i class='glyphicon glyphicon-trash btnCancelProjectBudget' data-transprojectbubgetid='" + _dr["id"] + @"'></i></a>
                </td>");
                }
                _string.Append(@"
                </tr>
                ");

                _i += 1;


            }




        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='7' align='center'>
                    ไม่พบรายการ
                </td>
            
                </tr>
                ");
        }

        _string.Append("</table>");

        _string.Append(@" </p>");
        _string.Append(@"   </div>");


        //            foreach (DataRow _dr in _ds.Tables[0].Rows)
        //            {

        //                _string.Append(@" <div class='row '>
        //                                      <div class='form-group col-xs-12 '>
        //                                             <label for=''>
        //                                                 " +_dr["budgetTypeNameTh"] + @" (บาท)</label>
        //                                          <input type='text' class='form-control txtProjectBudget" + _dr["id"] + "' value='" + _dr["budget"] + "' required/> " + @"
        //                                         </div>
        //                                     </div>");
        //                _i += 1;


        //            }






        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-15
    /// Perpose: แสดงรายละเอียดข้อมูล Indicators
    /// Method : getListProjectIndicator
    /// Sample : N/A
    /// </summary>
    public static string getListProjectIndicator(string _projectId, string _projectNameTh, string _facultyId, string _statusEdit , string _projectStatusId)
    {
        // ให้ Edit ได้แค่สถานะ "รอการยืนยัน"  23 ธ.ค. 2564
        //if (_projectStatusId != "PSS-005")
        //{
        //    _statusEdit = "N";
        //}

        StringBuilder _string = new StringBuilder();

        string _menuStr = "divProjectMenu4";

        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");
        _string.Append(divProjectIndicatorPage("", _projectId, _facultyId));
        _string.Append(@" <div class='row'>
                          <div class='form-group col-xs-12 text-center'>
                                 <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");
        if (_statusEdit != "N")
        {
            _string.Append(@" <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnAddIndicator  btnSetProjectIndicator'> บันทึก</button>    ");
        }


        _string.Append(@" </div></div>
                                ");


        //  <caption><h4>รายการ Indicator ทั้งหมด " + _count + @" รายการ</h4></caption>




        // แบ่งตามกลุ่ม Section
        DataSet _dsSection = ActDB.getListSection(_projectId, "");
        DataRow[] _drRowSection = _dsSection.Tables[0].Select("");
        int _rowSection = _drRowSection.Length;
        string _sectionId = "", _sectionNameTh = "";
        double _sumHourGrpIndicator = 0;
        if (_rowSection > 0)
        {
            for (int _iSection = 0; _iSection < _rowSection; _iSection++)
            {
                _sectionId = _drRowSection[_iSection]["id"].ToString();
                _sectionNameTh = _drRowSection[_iSection]["sectionNameTh"].ToString();
                _string.Append("<caption><b><h4 class='page-header text-primary' >" + _sectionNameTh + "</h4></b></caption>");
                _string.Append("<div class='card' >");
                _string.Append("<center><div class='card-body' style='width:95%;'>");



                DataSet _dsMain = ActDB.getListGroupIndicator();
                DataRow[] _drRowMain = _dsMain.Tables[0].Select("");
                int _rowMain = _drRowMain.Length;
                DataSet _ds;
                string _groupIndicatorId = "", _groupIndicatorNameTh = "";
                if (_rowMain > 0)
                {


                    for (int _iMain = 0; _iMain < _rowMain; _iMain++)
                    {
                        _groupIndicatorId = _drRowMain[_iMain]["id"].ToString();
                        _groupIndicatorNameTh = _drRowMain[_iMain]["nameTh"].ToString();
                        _ds = ActDB.getListProjectIndicator(_projectId);
                        // DataRow[] _drRow = _ds.Tables[0].Select("groupIndicatorId = 'GIR-001'");
                        DataRow[] _drRow = _ds.Tables[0].Select("groupIndicatorId='" + _groupIndicatorId + "' and projectSectionId = '" + _sectionId + "'");
                        int _row = _drRow.Length;

                        _string.Append(@"
                            <table id='tblIndicator" + _groupIndicatorId + @"' class='table table-bordered'>
                           
                            <tr class='bg-info'>
                            <th style='width:5%;'>
                            ลำดับ
                            </th>
                            <th >
                            ตัวชี้วัด
                            </th>
                            <th style='width:25%;'>
                            ตัวชี้วัดย่อย
                            </th>
                            <th style='width:8%;'>
                            ชั่วโมง
                            </th>
                            <th style='width:22%;'>
                            ลักษณะกิจกรรมที่สอดคล้อง
                            </th>
                            ");
                        if (_statusEdit != "N")
                        {
                            _string.Append(@"
                                    <th style='width:5%;'>
                                    แก้ไข
                                    </th>
                                    <th style='width:5%;'>
                                    ลบ
                                    </th>");
                        }
                        _string.Append(@"
                                    </tr>
                                     ");


                        if (_row > 0)
                        {


                            for (int _i = 0; _i < _row; _i++)
                            {

                                _string.Append(@"
               
                                    <tr >
                                    <td scope='row' class='text-center'>
                                    " + (_i + 1).ToString() + @"
                                    </td>
                                    <td >
                                     " + _drRow[_i]["indicatorAbbrevEn"] + "-" + _drRow[_i]["indicatorNameTh"] + @"
                                    </td>
                                    <td >
                                     " + _drRow[_i]["subIndicatorName"] + @"
                                    </td>
                                    <td >
                                     " + _drRow[_i]["hours"] + @"
                                    </td>
                                    <td >
                                     " + _drRow[_i]["description"] + @"
                                    </td>  ");
                                _sumHourGrpIndicator += Convert.ToDouble(_drRow[_i]["hours"]);
                                if (_statusEdit != "N")
                                {
                                    _string.Append(@"<td >
                                     <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup' data-transsectionindicatorid='" + _drRow[_i]["id"] + @"' class='glyphicon glyphicon-edit btnEditProjectIndicator'></i></a>
                                    </td>
                                    <td >
                                    <a href='#'><i class='glyphicon glyphicon-trash btnCancelProjectIndicator' data-transsectionindicatorid='" + _drRow[_i]["id"] + @"'></i></a>
                                    </td>");
                                }
                                _string.Append(@"</tr> ");


                            }



                        }
                        else
                        {
                            _string.Append(" <tr ><td colspan='6' class='text-center'>ไม่พบข้อมูล Indicator</td></tr>");
                        }
                        _string.Append("<div class='row'><div class='form-group text-left'><caption><b>" + _groupIndicatorNameTh + " (รวม " + _sumHourGrpIndicator + " ชม.)</b></caption></div></div>");

                        _sumHourGrpIndicator = 0;

                        _string.Append(" </table>");
                    }
                }
                _string.Append("</div></div>");
            }
        }

        _string.Append(@" </p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-16
    /// Perpose: แสดงรายละเอียดข้อมูล Character
    /// Method : getListProjectCharacter
    /// Sample : N/A
    /// </summary>
    public static string getListProjectCharacter(string _projectId, string _projectNameTh, string _facultyId, string _statusEdit)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectCharacter(_projectId);
        int _i = 1;
        string _menuStr = "divProjectMenu5";
        int _count = _ds.Tables[0].Rows.Count;
        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");
        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            
                                          " + getListSection(_projectId, "") + @"
                                         </div>
                                     </div>");

        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            
                                          " + getListCharacter(_facultyId) + @"
                                         </div>
                            </div>");
        _string.Append(@"   <div class='row'>
                          <div class='form-group col-xs-12 text-center'> 
                               <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");

        if (_statusEdit != "N")
        {
            _string.Append(@"  <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                                <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProjectCharacter'> บันทึก</button>");
        }


        _string.Append(@" </div></div> ");



        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Character ทั้งหมด " + _count + @" รายการ</h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-5'>
                ชื่อ Section
                </th>
                <th class='col-sm-5'>
                ชื่อ Character 
                </th>");
        if (_statusEdit != "N")
        {
            _string.Append(@"   <th class='col-sm-1'>
                ลบ
                </th>");
        }
        _string.Append(@"        </tr>
                </thead> ");
        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"
               
                <tr >
                <th scope='row'>
                " + _i.ToString() + @"
                </th>
                <td >
                 " + _dr["projectSectionNameTh"] + @"
                </td>
                <td >
                 " + _dr["characterAbbrevEn"] + " " + _dr["characterNameTh"] + @"
                </td>");
                if (_statusEdit != "N")
                {
                    _string.Append(@" <td >
                 <a style='cursor:pointer;'><i  data-transsectioncharacterid='" + _dr["id"] + @"' class='glyphicon glyphicon-trash btnCancelProjectCharacter'></i></a>
                </td>");
                }

                _string.Append(@"   </tr>    ");



                _i += 1;


            }



        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='4' align='center'>
                    ไม่พบรายการ
                </td>
            
                </tr>
                ");
        }

        _string.Append("</table>");

        _string.Append(@"</p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-16
    /// Perpose: แสดงรายละเอียดข้อมูล Device Info
    /// Method : getListProjectDeviceInfo
    /// Sample : N/A
    /// </summary>
    public static string getListProjectDeviceInfo(string _projectId, string _projectNameTh, string _statusEdit)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectDeviceInfo(_projectId);
        int _i = 1;
        string _menuStr = "divProjectMenu6";
        int _count = _ds.Tables[0].Rows.Count;
        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");

        _string.Append(divProjectDevicePage("", _projectId));
        _string.Append(@"     <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");
        if (_statusEdit != "N")
        {
            _string.Append(@" <input class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProjectDevice' type='button' value='บันทึก'/>
                               <input class='btn btn-warning btn-block btnBack' type='button' value='ย้อนกลับ' />
                            
                              ");

        }



        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Device ทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-2'>
                ชื่อ Section
                </th>
                <th class='col-sm-1'>
                เลขเครื่อง
                </th>
                <th class='col-sm-2'>
                ชื่อ Device
                </th>
                <th class='col-sm-2'>
                วันที่เปิด
                </th>
                <th class='col-sm-2'>
                วันที่ปิด
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>
                </tr>
                </thead> ");


        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"
               
                <tr >
                <th scope='row'>
                " + _i.ToString() + @"
                </th>
                <td >
                 " + _dr["projectSectionNameTh"] + @"
                </td>
                <td >
                 " + _dr["deviceNumber"] + @"
                </td>
                <td >
                 " + _dr["deviceInfoNameTh"] + @"
                </td>
                <td >
                 " + _dr["startDateTh"] + @"
                </td>   
                <td >
                 " + _dr["endDateTh"] + @"
                </td>         
                <td >
                 <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup'    data-transsectiondeviceid='" + _dr["id"] + @"' class='glyphicon glyphicon-edit btnEditSectionDevice'></i></a>
                </td>
                <td >
                <a href='#'><i class='glyphicon glyphicon-trash btnCancelProjectDevice' data-transsectiondeviceid='" + _dr["id"] + @"'></i></a>
                </td>
                </tr>
                ");

                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='8' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }

        _string.Append("</table>");
        _string.Append(@"</p>");
        _string.Append(@"   </div>");


        return _string.ToString();
    }






    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-25
    /// Perpose: แสดงรายละเอียดข้อมูลรูปภาพของโครงการนั้นๆ
    /// Method : getListProjectPicture
    /// Sample : N/A
    /// </summary>
    public static string getListProjectPicture(string _projectId, string _projectNameTh, string _statusEdit)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectPicture(_projectId);
        int _i = 1;

        string _menuStr = "divProjectMenu7";
        int _count = _ds.Tables[0].Rows.Count;
        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");

        _string.Append(@"  <div class='row '>
                                      
                                     <div class='form-group col-xs-6 '>
                                            <form action='' method='post' target='uploadframe' id='frmUploadPic'>
                                                <lable for='' style='font-weight:bold;'>กรุณาเลือกไฟล์</lable>&nbsp;<span style='color:Red;font-weight:bold;'>*</span>
                                                <input name='pictureUpload' id='txtProjectPictureUpload'  type='file' class='file' data-preview-file-type='text' > 
                                            </form>
                                            <iframe id='uploadframe' name='uploadframe' style='display: none;'></iframe>
                                      </div>

                                         <div class='form-group col-xs-3 '>
                                            
                                           <lable for='txtPictureProjectName' style='font-weight:bold;'>ชื่อรูปภาพ</lable>
                                           
                                           <input type='text' class='form-control txtPictureProjectName' />
                                           
                                        </div>  
                                        <div class='form-group col-xs-3 '>
                                                " + getListFileUploadType() + @"
                                        </div> 

                           </div>");



        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            <lable for='txtPictureDetail' style='font-weight:bold;'>รายละเอียดรูปภาพ</lable>
                                            <input type='text' class='form-control txtPictureDetail' />
                                            
                                      </div>
                            </div>");



        _string.Append(@" <div class='row'>
                            <div class='form-group col-xs-12 text-center'>
                                <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");
        if (_statusEdit != "N")
        {
            _string.Append(@" <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                               <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProjectPicture'> บันทึก</button>");

        }
        _string.Append(@" </div></div>      ");


        _string.Append(@" <table class='table'>
                <caption><h4>รายการรูปภาพทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-2'>
                รูปภาพ
                </th>
                <th class='col-sm-4'>
                ชื่อรูปภาพ
                </th>
                <th class='col-sm-2'>
                ประเภทรูปภาพ
                </th>
                <th class='col-sm-2'>
                รายละเอียดรูปภาพ
                </th>");
        if (_statusEdit != "N")
        {
            _string.Append(@"<th class='col-sm-1'>
                ลบ
                </th>");
        }
        _string.Append(@"</tr>
                </thead> ");


        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"
               
                <tr >
                <th scope='row'>
                " + _i.ToString() + @"
                </th>
                <td >
                 <img style='width:80px;height:60px;' class='img-thumbnail' src='" + string.Join("\\", ("../../images"), _dr["fileName"]) + @"' />
                </td>

                <td >
                 " + _dr["fileTopic"] + @"
                </td>
                <td >
                 " + _dr["fileTypeNameTh"] + @"
                </td>
                <td >
                 " + _dr["fileDetail"] + @"
                </td>");
                if (_statusEdit != "N")
                {
                    _string.Append(@"<td >
                                 <a href='#'><i class='glyphicon glyphicon-trash btnCancelProjectPicture' data-transprojectpictureid='" + _dr["id"] + @"'></i></a>
                                </td>");
                }
                _string.Append(@"</tr> ");
                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='5' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }

        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");


        return _string.ToString();
    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-25
    /// Perpose: แสดงรายการข้อมูล Section ทั้งหมดของโครงการนั้นๆ
    /// Method : getListProjectSection
    /// Sample : N/A
    /// </summary>
    public static string getListProjectSection(string _projectId, string _projectNameTh, string _statusEdit,string _projectStatusId)
    {
        // ให้ Edit ได้แค่สถานะ "รอการยืนยัน"  23 ธ.ค. 2564
        //if (_projectStatusId != "PSS-005")
        //{
        //    _statusEdit = "N";
        //}

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSection(_projectId, "");
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        string _menuStr = "divProjectMenu2";

        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");
        _string.Append(@"<h2 class='page-header'>
                                   ชื่อโครงการ : " + _projectNameTh + "</h2><p> ");




        _string.Append(divSectionPage(""));

        _string.Append(@" <div class='row'>
                          <div class='form-group col-xs-12 text-center'>
                             <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>");

        if (_statusEdit != "N")
        {
            _string.Append(@" <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                             <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProjectSection'> บันทึก</button> ");
        }
        _string.Append(@" </div></div>
                             ");


        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Section ทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-1'>
                ภาค/ปี
                </th>
                <th class='col-sm-2'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-2'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-1'>
                วันที่เริ่มต้น
                </th>
                <th class='col-sm-1'>
                วันที่สิ้นสุด
                </th>

                <th class='col-sm-1'>
                จำนวนรับสมัคร
                </th>
                <th class='col-sm-1'>
                สถานที่
                </th>");
        if (_statusEdit != "N")
        {
            _string.Append(@"     <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>");
        }
        _string.Append(@"</tr>
                </thead> ");


        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"
               
                <tr >
                <th scope='row'>
                " + _i.ToString() + @"
                </th>
                <td >
                 " + _dr["semester"] + "/" + _dr["acaYear"] + @"
                </td>
                <td >
                 " + _dr["sectionNameTh"] + @"
                </td>
                <td >
                 " + _dr["sectionNameEn"] + @"
                </td>
                <td >
                 " + _dr["startDateDisplay"] + @"
                </td>
                <td >
                 " + _dr["endDateDisplay"] + @"
                </td>

                <td >
                 " + _dr["amountMax"] + @"
                </td>
                <td >
                 " + _dr["place"] + @"
                </td>");
                if (_statusEdit != "N")
                {
                    _string.Append(@"
                 <td >
                 <a style='cursor:pointer;'><i data-sectionid='" + _dr["id"] + @"' data-toggle='modal' data-target='#divPopup' class='glyphicon glyphicon-edit btnEditSection'></i></a>
                </td>
                <td >
                <a href='#'><i class='glyphicon glyphicon-trash btnCancelSection' data-sectionid='" + _dr["id"] + @"'></i></a>
                </td>");
                }

                _string.Append(@"</tr> ");

                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='9' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }

        _string.Append("</table>");
        _string.Append(@"  </p>");
        _string.Append(@"   </div>");



        return _string.ToString();
    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-09
    /// Perpose: แสดงเมนู Tab จัดการข้อมูลเกี่ยวกับโครงการ
    /// Method : LoadMenuTabProject
    /// Sample : N/A
    /// </summary>
    public static string LoadMenuTabProject()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"</br></br>  <ul class='nav nav-tabs nav-justified'>
                                <li class='active'><a data-toggle='tab' href='#divProjectMenu1'>Project</a></li>
                                <li><a data-toggle='tab' href='#divProjectMenu3'>Budget</a></li>
                                <li><a data-toggle='tab' href='#divProjectMenu2'>Section</a></li>                                
                                <li><a data-toggle='tab' href='#divProjectMenu4'>Indicator</a></li>
                                <li><a data-toggle='tab' href='#divProjectMenu5'>Character</a></li>
                                <li><a data-toggle='tab' href='#divProjectMenu7'>Picture</a></li>
                              </ul> "); //  <li><a data-toggle='tab' href='#divProjectMenu6'>Device</a></li>
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-26
    /// Perpose: แสดงหน้าจอสำหรับเพิ่มข้อมูลโปรเจคใหม่
    /// Method : LoadPageAddNewProject
    /// Sample : N/A
    /// </summary>
    public static string LoadPageAddNewProject(string _facultyId)
    {



        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                <div class='col-md-12 divNewProject'>
                     <h1 class='page-header'>
                         เพิ่มข้อมูลโครงการใหม่</h1>
                     ");

        /*
        ของเจต
        _string.Append(editProjectPage("", "", "", "", "", "", "", "", "ร่างโครงการ", _facultyId, "", "", "", "", "", "", "",""));
        */
        _string.Append(editProjectPage("current", "", "", "", "", "", "", "", "ร่างโครงการ", _facultyId, "", "", "", "", "", "", "", ""));


        _string.Append(@"       
                     <div class='row'>
                     <div class='form-group col-xs-12 text-center'>
                         <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                         <button class='btn btn-success glyphicon glyphicon-floppy-disk btnSetProject ' type='button'>
                             บันทึก</button>
                     </div></div>
                     </p>
                 </div>
             </div>");
        return _string.ToString();
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-02
    /// Perpose: แสดงเมนู Tab จัดการข้อมูลตั้งต้น
    /// Method : LoadMenuTabConfig
    /// Sample : N/A
    /// </summary>
    public static string LoadMenuTabConfig()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"</br></br>  <ul class='nav nav-tabs nav-justified'>
                                <li class='active'><a data-toggle='tab' href='#divConfigMenu1'>Indicator</a></li>
                                <li><a data-toggle='tab' href='#divConfigMenu5'>Group Character</a></li>
                                <li><a data-toggle='tab' href='#divConfigMenu2'>Character</a></li>                                
                                <li><a data-toggle='tab' href='#divConfigMenu3'>Budget Type</a></li>
                                
                                
                              </ul> "); //  <li><a data-toggle='tab' href='#divConfigMenu5'>Institute</a></li>
                                        //  <li><a data-toggle='tab' href='#divConfigMenu4'>Device Info</a></li>
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-02
    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล Character
    /// Method : getListConfigIndicator
    /// Sample : N/A
    /// </summary>
    public static string getListConfigIndicator(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListIndicator(_facultyId);
        _string.Append(LoadMenuTabConfig());
        int _i = 1;
        string _statusEdit = "";
        string _iconEdit = "";
        string _iconDelete = "";
        string _menuStr = "divConfigMenu1";
        int _count = _ds.Tables[0].Rows.Count;
        _string.Append("<div class='tab-content'>");
        _string.Append(@"<div id='" + _menuStr + "' class='tab-pane fade in active' >");
        _string.Append(@"<h2 class='page-header'>จัดการข้อมูล Indicator</h2>");
        _string.Append(@" <p> ");

        _string.Append(divConfigIndicatorPage("", _facultyId));
        //        _string.Append(@"                        <div class='row '>
        //                                      <div class='form-group col-xs-12 '>
        //                                             <label for=''>
        //                                                 ชื่อ Indicator ภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
        //                                          <input type='text' class='form-control txtIndicatorNameTh' placeholder='ชื่อ Indicator ภาษาไทย' /> " + @"
        //                                         </div>
        //         
        //                                     </div>");
        //        _string.Append(@"          <div class='row '>
        //                                      <div class='form-group col-xs-12 '>
        //                                             <label for=''>
        //                                                 ชื่อ Indicator ภาษาอังกฤษ</label> <span style='color:Red;font-weight:bold;'>*</span>
        //                                          <input type='text' class='form-control txtIndicatorNameEn' placeholder='Indicator Name' /> " + @"
        //                                       </div>
        //         
        //                                   </div>");

        //        _string.Append(@"          <div class='row '>
        //                                      <div class='form-group col-xs-3 '>
        //                                             <label for=''>
        //                                                 ชื่อตัวย่อ Indicator ภาษาไทย</label> 
        //                                          <input type='text' class='form-control txtIndicatorAbbrevTh' placeholder='ชื่อตัวย่อ Indicator ภาษาไทย' /> " + @"
        //                                      </div>
        //                                      <div class='form-group col-xs-3 '>
        //                                             <label for=''>
        //                                                 ชื่อตัวย่อ Indicator ภาษาอังกฤษ</label> 
        //                                          <input type='text' class='form-control txtIndicatorAbbrevEn' placeholder='Indicator Abbrev Name' /> " + @"
        //                                      </div>
        //
        //                                      <div class='form-group col-xs-3 '>
        //                                             <label for=''>
        //                                                 ปีที่เริ่ม</label> 
        //                                          <input type='number' class='form-control txtStartYearIndicator' placeholder='ปีที่เริ่ม' /> " + @"
        //                                      </div>
        //
        //                                      <div class='form-group col-xs-3 '>
        //                                             <label for=''>
        //                                                 ปีที่สิ้นสุด</label> 
        //                                          <input type='number' class='form-control txtEndYearIndicator' placeholder='ปีที่สิ้นสุด' /> " + @"
        //                                      </div>
        //         
        //                                   </div>");


        _string.Append(@"          <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetTypeIndicator'> บันทึก</button>
                                             </div>
                                    </div>");



        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Indicator ทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-3'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-2'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-1'>
                ตัวย่อไทย
                </th>
                <th class='col-sm-1'>
                ตัวย่ออังกฤษ
                </th>
                <th class='col-sm-1'>
                ปีที่เริ่ม
                </th>
                <th class='col-sm-1'>
                ปีที่สิ้นสุด
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>   
                </tr>
                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _statusEdit = _dr["statusEdit"].ToString();

                if (_statusEdit == "1")
                {
                    _iconEdit = " <a style='cursor:pointer;' ><i data-toggle='modal' data-target='#divPopup' class='glyphicon glyphicon-edit btnEditConfigIndicator' data-indicatorid='" + _dr["id"] + @"' ></i></a>";
                    _iconDelete = " <a href='#'><i class='glyphicon glyphicon-trash btnCancelConfigIndicator' data-indicatorid='" + _dr["id"] + @"'></i></a> ";
                }
                else
                {
                    _iconEdit = "-";
                    _iconDelete = "-";

                }

                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _i.ToString() + @"
                                        </th>
                                        <td >
                                         " + _dr["IndicatorNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["IndicatorNameEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["IndicatorAbbrevTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["IndicatorAbbrevEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["startYear"] + @"
                                        </td>
                                        <td >
                                         " + _dr["endYear"] + @"
                                        </td>
                                        <td >
                                        " + _iconEdit + @"
                                        </td>
                                         <td >
                                         " + _iconDelete + @"
                                        </td>
                                        </tr>
                                        ");

                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='9' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }



        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append("</div>");

        _string.Append(getListConfigCharacter(_facultyId));
        _string.Append(getListConfigBudgetType(_facultyId));
        _string.Append(getListConfigDeviceInfo());
        _string.Append(getListConfigGroupCharacter(_facultyId));
        _string.Append("</div>");

        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-02
    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล Character
    /// Method : getListConfigCharacter
    /// Sample : N/A
    /// </summary>
    public static string getListConfigCharacter(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListCharacter(_facultyId);
        int _i = 1;
        string _statusEdit = "";
        string _iconEdit = "";
        string _iconDelete = "";
        string _menuStr = "divConfigMenu2";
        int _count = _ds.Tables[0].Rows.Count;


        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");

        _string.Append(@"<h2 class='page-header'>จัดการข้อมูล Character</h2>");
        _string.Append(@" <p> ");

        _string.Append(divConfigCharacterPage("", _facultyId));

        _string.Append(@"          <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetTypeCharacter'> บันทึก</button>
                                             </div>
                                    </div>");



        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Character ทั้งหมด " + _count + @" รายการ </h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-3'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-2'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-2'>
                ชื่อ Group Character
                </th>
                <th class='col-sm-1'>
                ปีที่เริ่ม
                </th>
                <th class='col-sm-1'>
                ปีที่สิ้นสุด
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>
                </tr>
                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _statusEdit = _dr["statusEdit"].ToString();

                if (_statusEdit == "1")
                {
                    _iconEdit = "  <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup' class='glyphicon glyphicon-edit btnEditConfigCharacter' data-characterid='" + _dr["id"] + @"'></i></a>";
                    _iconDelete = "  <a href='#'><i class='glyphicon glyphicon-trash btnCancelConfigCharacter' data-characterid='" + _dr["id"] + @"'></i></a>  ";
                }
                else
                {
                    _iconEdit = "-";
                    _iconDelete = "-";
                }
                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _i.ToString() + @"
                                        </th>
                                        <td >
                                         " + _dr["characterNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["characterNameEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["groupCharacterNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["startYear"] + @"
                                        </td>
                                        <td >
                                         " + _dr["endYear"] + @"
                                        </td>
                                        <td >
                                        " + _iconEdit + @"
                                        </td>
                                        <td >
                                        " + _iconDelete + @"
                                        </td>
                                        </tr>
                                        ");


                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='9' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }





        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-03
    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล gBudget
    /// Method : getListConfigBudgetType
    /// Sample : N/A
    /// </summary>
    public static string getListConfigBudgetType(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListBudget(_facultyId);
        int _i = 1;
        string _statusEdit = "";
        string _iconEdit = "";
        string _iconDelete = "";
        string _menuStr = "divConfigMenu3";
        int _count = _ds.Tables[0].Rows.Count;


        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");

        _string.Append(@"<h2 class='page-header'>จัดการข้อมูลประเภทแหล่งทุน</h2>");
        _string.Append(@" <p>");

        _string.Append(divConfigBudgetPage(""));

        _string.Append(@"          <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetTypeBudget'> บันทึก</button>
                                             </div>
                                    </div>");



        _string.Append(@" <table class='table'>
                <caption><h4>รายการประเภทแหล่งทุนทั้งหมด " + _count + @" รายการ</h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-4'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-3'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-1'>
                ปีที่เริ่ม
                </th>
                <th class='col-sm-1'>
                ปีที่สิ้นสุด
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>
                </tr>
                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _statusEdit = _dr["statusEdit"].ToString();

                if (_statusEdit == "1")
                {
                    _iconEdit = " <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup' class='glyphicon glyphicon-edit btnEditConfigBudget' data-budgetid='" + _dr["id"] + @"'></i></a>";
                    _iconDelete = " <a href='#'><i class='glyphicon glyphicon-trash btnCancelConfigBudget' data-budgetid='" + _dr["id"] + @"'></i></a>   ";
                }
                else
                {
                    _iconEdit = "-";
                    _iconDelete = "-";

                }

                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _i.ToString() + @"
                                        </th>
                                        <td >
                                         " + _dr["budgetTypeNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["budgetTypeNameEn"] + @"
                                        </td>
                                        <td>
                                            " + _dr["startYear"] + @"
                                        </td>
                                        <td >
                                         " + _dr["endYear"] + @"
                                        </td>
                                        <td >
                                        " + _iconEdit + @"
                                        </td>
                                        <td >
                                        " + _iconDelete + @"
                                         </td>
                                        </tr>
                                        ");


                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='7' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }





        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-03
    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล DeviceInfo
    /// Method : getListConfigDeviceInfo
    /// Sample : N/A
    /// </summary>
    public static string getListConfigDeviceInfo()
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListDevice();
        int _i = 1;
        string _menuStr = "divConfigMenu4";
        int _count = _ds.Tables[0].Rows.Count;


        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");

        _string.Append(@"<h2 class='page-header'>จัดการข้อมูล Device</h2>");
        _string.Append(@" <p> ");
        _string.Append(divConfigDevicePage(""));

        _string.Append(@"          <div class='row'>
                                            <div class='form-group col-xs-12 '>
                                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetTypeDevice'> บันทึก</button>
                                             </div>
                                    </div>");



        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Device ทั้งหมด " + _count + @" รายการ</h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-4'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-3'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-2'>
                หมายเลขเครื่อง
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>
                </tr>
                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _i.ToString() + @"
                                        </th>
                                        <td >
                                         " + _dr["deviceNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["deviceNameEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["deviceNumber"] + @"
                                        </td>
                                        <td >
                                         <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup' class='glyphicon glyphicon-edit btnEditConfigDevice' data-deviceid='" + _dr["id"] + @"'></i></a>
                                        </td>
                                        <td >
                                        <a href='#'><i class='glyphicon glyphicon-trash btnCancelConfigDevice' data-deviceid='" + _dr["id"] + @"'></i></a>
                                        </td>
                                        </tr>
                                        ");


                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='6' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }





        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }




    //    /// <summary>
    //    /// Auther : เจตน์ เครือชะเอม
    //    /// Date   : 2017-06-03
    //    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล Institute
    //    /// Method : getListConfigInstitute
    //    /// Sample : N/A
    //    /// </summary>
    //    public static string getListConfigInstitute()
    //    {

    //        StringBuilder _string = new StringBuilder();
    //        DataSet _ds = ActDB.getListInstitute();
    //        int _i = 1;
    //        string _menuStr = "divConfigMenu5";
    //        int _count = _ds.Tables[0].Rows.Count;


    //        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");

    //        _string.Append(@"<h2 class='page-header'>จัดการข้อมูลหน่วยงาน</h2>");
    //        _string.Append(@" <p> ");


    //        _string.Append(@" <table class='table'>
    //                <caption><h4>รายการหน่วยงานทั้งหมด " + _count + @" รายการ</h4></caption>
    //                <thead>
    //                <tr>
    //                <th class='col-sm-1'>
    //                ลำดับ
    //                </th>
    //                <th class='col-sm-3'>
    //                ชื่อภาษาไทย
    //                </th>
    //                <th class='col-sm-3'>
    //                ชื่อภาษาอังกฤษ
    //                </th>
    //                <th class='col-sm-1'>
    //                ตัวย่อไทย
    //                </th>
    //                <th class='col-sm-1'>
    //                ตัวย่ออังกฤษ
    //                </th>
    //                <th class='col-sm-1'>
    //                แก้ไข
    //                </th>
    //                </tr>
    //                </thead> ");



    //        if (_count > 0)
    //        {


    //            foreach (DataRow _dr in _ds.Tables[0].Rows)
    //            {


    //                _string.Append(@"
    //               
    //                                        <tr >
    //                                        <th scope='row'>
    //                                        " + _i.ToString() + @"
    //                                        </th>
    //                                        <td >
    //                                         " + _dr["instituteNameTh"] + @"
    //                                        </td>
    //                                        <td >
    //                                         " + _dr["instituteNameEn"] + @"
    //                                        </td>
    //                                        <td >
    //                                         " + _dr["instituteAbbrevTh"] + @"
    //                                        </td>
    //                                        <td >
    //                                         " + _dr["instituteAbbrevEn"] + @"
    //                                        </td>
    //                                        <td >
    //                                         <a href='#'><i class='glyphicon glyphicon-edit'></i></a>
    //                                        </td>
    //                                        </tr>
    //                                        ");

    //                _i += 1;


    //            }

    //        }
    //        else
    //        {
    //            _string.Append(@"
    //               
    //                <tr >
    //                <td scope='row' colspan='8' align='center'>
    //                    ไม่พบรายการ
    //                </td>
    //                </tr>
    //                ");
    //        }





    //        _string.Append("</table>");
    //        _string.Append(@" </p>");
    //        _string.Append(@"   </div>");

    //        return _string.ToString();
    //    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-03
    /// Perpose: 
    /// Method : addCondition
    /// Sample : N/A
    /// </summary>
    public static string addCondition()
    {

        StringBuilder _string = new StringBuilder();



        _string.Append(@"<div   class='tab-pane fade divCondition' >");
        _string.Append(@"<table class='table'>");
        _string.Append(@"<tr><td>เงื่อนไขการสร้างกลุ่ม Section</td></tr>");
        _string.Append(@"<tr><td></td></tr>");
        _string.Append(@"</table>");
        _string.Append(@"</div>");

        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-04
    /// Perpose: แสดงเมนูด้านซ้ายมือของเจ้าหน้าที่ Bar Menu
    /// Method : AddSectionRegister
    /// Sample : N/A
    /// </summary>
    /// 
    public static string ListStudentRegister(string _projectId, string _sectionId,string stsHideInput)
    {
        DataSet _ds = ActDB.getListStudentRegist(_projectId);
        //int _count = _ds.Tables[0].Rows.Count;
        DataRow[] _drRow;
        if (_sectionId == "")
        {
            _drRow = _ds.Tables[0].Select("");
        }
        else
        {
            _drRow = _ds.Tables[0].Select("projectSectionId = '" + _sectionId + "'");
        }

        int _row = _drRow.Length;

        StringBuilder _string = new StringBuilder();
        string _inputTransId = "";
        _string.Append(@" <table class='table' id='tblStudentRegist'>
                
                <thead>
                <tr>");
        if (stsHideInput == "0")
        {
            _string.Append(@"<th class='col-sm-1'>
                <div class='checkbox' style='cursor:pointer;'>
                         <label><input type='checkbox' class='btnChkAll' ></label>
                </div>                
                </th>");
        }
        _string.Append(@"<th class='col-sm-1'>
                ลำดับ
                </th>

                <th class='col-sm-1'>
                รหัสนักศึกษา
                </th>
                
                <th class='col-sm-1'>
                ชื่อ-นามสกุล
                </th>

                <th class='col'>
                ชื่อ Section
                </th>

                <th class='col-sm-2'>
                คณะ
                </th>


                <th class='col-sm-1'>
                สถานะ
                </th>
                <th class='col-sm-1'>
                วันที่นำเข้า
                </th>
                <th class='col-sm-1'>
                ผู้ที่นำเข้า
                </th>");

        if (stsHideInput == "0")
        {
            _string.Append(@"<th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>");
        }

        _string.Append(@"
                </tr>
                </thead> ");



        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {

                _inputTransId = "<input class='transId' type='hidden' value='" + _drRow[_i]["id"] + "' >";
                _string.Append(@"     <tr >");

                if (stsHideInput == "0")
                {
                    _string.Append(@"      <td scope='row'>
                                            <div class='checkbox' style='cursor:pointer;'>
                                                <label><input type='checkbox' class='chkStudentRegist' ></label>
                                            </div>
                                        </td>");
                }

                _string.Append(@"       <td >
                                         " + (_i + 1).ToString() + @"
                                        </td>
                                        <td >
                                         " + _drRow[_i]["studentCode"] + @"
                                        </td>
                                        
                                        <td >
                                         " + _drRow[_i]["firstName"] + " " + _drRow[_i]["lastName"] + @"
                                        </td>

                                        <td >
                                         " + _drRow[_i]["projectSectionNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _drRow[_i]["facultyCode"] + " - " + _drRow[_i]["facultyNameTh"] + @"
                                        </td>
     
                                        <td >
                                         " + _drRow[_i]["positionNameTh"] + @"
                                        </td>

                                         <td >
                                         &nbsp;" + _drRow[_i]["createdDateFormat"] + @"
                                        </td>
                                        <td >
                                         " + _drRow[_i]["createdBy"] + _inputTransId + @"
                                        </td>");
                if (stsHideInput == "0")
                {
                    _string.Append(@"
                                        <td >
                                          <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup'    class='glyphicon glyphicon-edit btnDialogUpdatePostition'  data-transsectionregistid='" + _drRow[_i]["id"] + "' data-studentcode='" + _drRow[_i]["studentCode"] + @"' data-firstname='" + _drRow[_i]["firstName"] + @"' data-lastname='" + _drRow[_i]["lastName"] + "' data-projectnameth='" + _drRow[_i]["projectnameth"] + "' data-positionid='" + _drRow[_i]["positionId"] + @"' ></i></a>
                                         
                                        </td>
                                        <td >
                                         <a href='#'><i class='glyphicon glyphicon-trash btnSetCancelStudentRegist' data-transsectionregistid='" + _drRow[_i]["id"] + "' data-studentid='" + _drRow[_i]["studentId"] + "' data-sectionid='" + _drRow[_i]["projectSectionid"] + "' data-projectid='" + _projectId + "' data-projectnameth='" + _drRow[_i]["projectnameth"] + @"'  ></i></a>
                                        </td>");
                }
                _string.Append(@" </tr> ");



            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='9' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }
        _string.Append("</tbody></table>");


        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-23
    /// Perpose: แสดงเมนูรายชื่อนักศึกษา
    /// Method : getlistStudentRegistSection
    /// Sample : N/A
    /// </summary>
    /// 
    public static string getlistStudentRegistSection(string _projectId, string _sectionId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(ListStudentRegister(_projectId, _sectionId,"0"));
        //        string _projectNameTh = "";

        //        StringBuilder _string = new StringBuilder();
        //        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        //        int _i = 1;
        //        int _count = _ds.Tables[0].Rows.Count;
        //        if (_count > 0)
        //        {
        //            foreach (DataRow _dr in _ds.Tables[0].Rows)
        //            {
        //                _projectNameTh = _dr["nameTh"].ToString();
        //            }
        //        }


        //        _string.Append(@"   <div id='divStudentRegistList'> <h2 class='page-header'>รายชื่อนักศึกษาทั้งหมดของโครงการ:"+_projectNameTh+"</h2>");
        ////        _string.Append(@"  <table class='table' cellpadding='0' cellspacing='0'>
        ////                            <tr>
        ////                            <th class='col-sm-2 left'>
        ////                                <input class='btn btn-warning btnBack' type='button' value='ย้อนกลับ' />
        ////                            </th>
        ////                            <th class='col-sm-10 right'>
        ////                                      <button type='button' class='btn btn-primary btn-md btnAddStudentOnly glyphicon glyphicon-plus' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษารายบุคคล</button>
        ////                                &nbsp;<button type='button' class='btn btn-info  btn-md btnAddStudentExcel glyphicon glyphicon-file' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษาแบบไฟล์ Excel</button>
        ////                            </th>
        ////                            </tr>
        ////                            </table>");

        //        _string.Append(@"<div class='row'>
        //                         <div class='form-group col-xs-12 text-center'>
        //                     <button type='button' class='btn btn-warning btn-md glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 

        //                     <button type='button' class='btn btn-primary btn-md btnAddStudentOnly glyphicon glyphicon-plus' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษารายบุคคล</button>
        //                     <button type='button' class='btn btn-primary btn-md btnAddStudentExcel glyphicon glyphicon-file' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษาแบบไฟล์ Excel</button>
        //                     <button type='button' class='btn btn-danger btn-md  btnSetCancelStdRegistByCheckBox glyphicon glyphicon-trash' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> ลบรายการนักศึกษา</button>


        //                    </div></div></br>");


        // _string.Append(@"   </div>");


        return _string.ToString();

    }






    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-04
    /// Perpose: 
    /// Method : addSectionRegisterStudentOnly
    /// Sample : N/A
    /// </summary>
    /// 
    public static string addSectionRegisterStudentOnly(string _projectId, string _projectNameTh)
    {


        StringBuilder _string = new StringBuilder();

        _string.Append(@"   <div id='divSectionStudentOnly'>   <h2 class='page-header'>
                                    เพิ่มรายชื่อนักศึกษาแบบรายบุคคลของโครงการ : " + _projectNameTh + @"</h2>
                                <p>
                                    <div class='row '>

                                        <div class='form-group col-xs-12 '>
                                            " + getListSection(_projectId, "") + @"
                                        </div>
                                      </div>
                                      <div class='row '>
                                         <div class='form-group col-xs-5 '>
                                            <label for=''>
                                                รหัสนักศึกษา</label>
                                            <span style='color: Red; font-weight: bold;'>*</span>
                                            <input type='number' class='form-control txtStudentCode' maxlength='7' placeholder='รหัสนักศึกษา' />
                                           </div>
                                            <div class='form-group col-xs-7 '>
                                            " + getListPosition("1") + @"
                                            </div>
                                       </div>

                                    </div>
                                    <div class='row '>
                                         <div class='form-group col-xs-12  text-center '>
                                          <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>
                                          <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                                          <button type='button' class='btn btn-primary glyphicon glyphicon-plus btnAddStudentEachOnly' > เพิ่ม</button>
                                          <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetStudentEachOnly' > บันทึก</button>
                               
                                    
                                         </div>                           

                                    </div>  ");
        _string.Append(@" <div class='divStudentRegistTemp'>");

        _string.Append(@" <table class='table tblStudentRegistTemp'>
                
                <thead>
                <tr>
                <th class='col-sm-1'>
                
                </th>
                <th class='col-sm-1'>
                รหัสนักศึกษา
                </th>
                <th class='col-sm-3'>
                ชื่อ Section
                </th>
       
                <th class='col-sm-2'>
                คณะ
                </th>
                <th class='col-sm-2'>
                ชื่อ-นามสกุล
                </th>
                <th class='col-sm-1'>
                สถานะ
                </th>
                <th class='col-sm-2'>
                หมายเหตุ
                </th>
                </tr>
                </thead></table> ");

        _string.Append(@"   </div>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");


        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-04
    /// Perpose: 
    /// Method : addSectionRegisterStudentExcel
    /// Sample : N/A
    /// </summary>
    /// 
    public static string addSectionRegisterStudentExcel(string _projectId, string _projectNameTh)
    {


        StringBuilder _string = new StringBuilder();

        _string.Append(@"   <div id='divSectionStudentRegistExcel'>   <h2 class='page-header'>
                                    เพิ่มรายชื่อนักศึกษาแบบไฟล์ Excel ของโครงการ : " + _projectNameTh + @"</h2>
                                <p>
                                    <div class='row '>

                                        <div class='form-group col-xs-12 '>
                                            <form action='' method='post' target='uploadframeStdRegistExcel' id='frmUploadStdRegistExcel'>
                                                <lable for='' style='font-weight:bold;'>กรุณาเลือกไฟล์ Excel</lable>&nbsp;<span style='color:Red;font-weight:bold;'>*</span>
                                                &nbsp; <a href='../../file/templateStudentList.xlsx'>Download Template Excel File คลิก</a>
                                                <input name='excelStdRegistUpload' id='txtProjectStdRegistUpload'  type='file' class='file' data-preview-file-type='text' > 
                                            </form>
                                            <iframe id='uploadframeStdRegistExcel' name='uploadframeStdRegistExcel' style='display: none;'></iframe>   
                                      
                                        </div>
                                      </div>
                                      <div class='row '>
                                         <div class='form-group col-xs-12 '>
                                                " + getListSection(_projectId, "") + @"
                                                </div>
            

                                    </div>
                                    <div class='row '>
                                         <div class='form-group col-xs-12  text-center '>
                                          <input class='hddProjectId' type='hidden' value='" + _projectId + @"'/>
                                          
                                            <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 
                                            <button type='button' class='btn btn-primary glyphicon glyphicon-file btnAddStudentRegistExcel' > อัพโหลดไฟล์</button>
                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetStudentRegistExcel' > บันทึก</button>
                                         
                                         </div>                           

                                    </div>  ");
        _string.Append(@" <div class='divListStudentRegistExcel'>");
        _string.Append(@" <table class='table tblStudentRegistTempExcel'>
                
                <thead>
                <tr>
                <th class='col-sm-1'>
                
                </th>
                <th class='col-sm-1'>
                รหัสนักศึกษา
                </th>
                <th class='col-sm-3'>
                ชื่อ Section
                </th>
       
                <th class='col-sm-2'>
                คณะ
                </th>
                <th class='col-sm-2'>
                ชื่อ-นามสกุล
                </th>
                <th class='col-sm-1'>
                สถานะ
                </th>
                <th class='col-sm-2'>
                หมายเหตุ
                </th>
                </tr>
                </thead></table> ");
        _string.Append(@"   </div>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");


        return _string.ToString();

    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-06
    /// Perpose: แสดงเมนู Tab Config เพื่อจัดการข้อมูล Group Character
    /// Method : getListConfigGroupCharacter
    /// Sample : N/A
    /// </summary>
    public static string getListConfigGroupCharacter(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListGroupCharacter(_facultyId);
        int _i = 1;
        string _statusEdit = "";
        string _iconEdit = "";
        string _iconDelete = "";
        string _menuStr = "divConfigMenu5";
        int _count = _ds.Tables[0].Rows.Count;


        _string.Append(@"<div id='" + _menuStr + "'  class='tab-pane fade' >");

        _string.Append(@"<h2 class='page-header'>จัดการข้อมูล Group Character</h2>");
        _string.Append(@" <p> ");

        _string.Append(divConfigGroupCharacterPage(""));

        _string.Append(@"          <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                                                 <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetTypeGroupCharacter'> บันทึก</button>
                                             </div>
                                    </div>");


        _string.Append(@" <table class='table'>
                <caption><h4>รายการ Group Character ทั้งหมด " + _count + @" รายการ</h4></caption>
                <thead>
                <tr>
                <th class='col-sm-1'>
                ลำดับ
                </th>
                <th class='col-sm-3'>
                ชื่อภาษาไทย
                </th>
                <th class='col-sm-2'>
                ชื่อภาษาอังกฤษ
                </th>
                <th class='col-sm-1'>
                ตัวย่อไทย
                </th>
                <th class='col-sm-1'>
                ตัวย่ออังกฤษ
                </th>
                <th class='col-sm-1'>
                ปีที่เริ่ม
                </th>
                <th class='col-sm-1'>
                ปีที่สิ้นสุด
                </th>
                <th class='col-sm-1'>
                แก้ไข
                </th>
                <th class='col-sm-1'>
                ลบ
                </th>
                </tr>
                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _statusEdit = _dr["statusEdit"].ToString();

                if (_statusEdit == "1")
                {
                    _iconEdit = "  <a style='cursor:pointer;'><i data-toggle='modal' data-target='#divPopup' data-groupcharacterid='" + _dr["id"] + @"' class='glyphicon glyphicon-edit btnEditConfigGroupCharacter'></i></a>";
                    _iconDelete = " <a href='#'><i class='glyphicon glyphicon-trash btnCancelConfigGroupCharacter' data-groupcharacterid='" + _dr["id"] + @"'></i></a>        ";
                }
                else
                {
                    _iconEdit = "-";
                    _iconDelete = "-";
                }

                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _i.ToString() + @"
                                        </th>
                                        <td >
                                         " + _dr["groupCharacterNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["groupCharacterNameEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["groupCharacterAbbrevTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["groupCharacterAbbrevEn"] + @"
                                        </td>
                                        <td >
                                         " + _dr["startYear"] + @"
                                        </td>
                                        <td >
                                         " + _dr["endYear"] + @"
                                        </td>   
                                        <td >
                                        " + _iconEdit + @"
                                        </td>
                                        <td >
                                         " + _iconDelete + @"
                                         </td>
                                        </tr>
                                        ");


                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
               
                <tr >
                <td scope='row' colspan='11' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }





        _string.Append("</table>");
        _string.Append(@" </p>");
        _string.Append(@"   </div>");

        return _string.ToString();
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-18
    /// Perpose: แสดงเมนูหน้าจอของข้อมูล Section
    /// Method : divSectionPage
    /// Sample : N/A
    /// </summary>
    public static string divSectionPage(string _projectSectionId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSectionBySectionId(_projectSectionId);
        string _sectionNameTh = "";
        string _sectionNameEn = "";
        string _acaYear = "";
        string _semester = "";
        string _startDate = "";
        string _endDate = "";
        string _amountMax = "";
        string _place = "";
        string _muxRefId = "";
        string _statusPassMux = "";
        string _statusEnrollmentMux = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _acaYear = _dr["acaYear"].ToString();
                _semester = _dr["semester"].ToString();
                _sectionNameTh = _dr["sectionNameTh"].ToString();
                _sectionNameEn = _dr["sectionNameEn"].ToString();
                _startDate = _dr["startDateDisplay"].ToString();
                _endDate = _dr["endDateDisplay"].ToString();
                _amountMax = _dr["amountMax"].ToString();
                _place = _dr["place"].ToString();
                _muxRefId = _dr["muxRefId"].ToString();
                _statusPassMux = _dr["statusPassMux"].ToString();
                _statusEnrollmentMux = _dr["statusEnrollmentMux"].ToString();
            }


        }

        //       _string.Append(@"  <div class='row '>
        //                                      <div class='form-group col-xs-6 '>
        //                                       " + getListAcaYear(_acaYear) + @"
        //                                       </div>  
        //                                        <div class='form-group col-xs-6 '>
        //                                       " + getListSemester(_semester) + @"
        //                                       </div>  
        //                           </div>");

        _string.Append(@"<div class='row'>
                             <div class='form-group col-xs-12'>
                                 <label for='txtSectionNameTh'>
                                     ชื่อ Section ภาษาไทย</label>&nbsp;<span style='color:Red;font-weight:bold;'>*</span>
                                 <input type='text' class='form-control' id='txtSectionNameTh' placeholder='ชื่อ Section' value='" + _sectionNameTh + @"'/>
                             </div>
                         </div>");

        _string.Append(@"<div class='row'>
                             <div class='form-group col-xs-12'>
                                 <label for='txtSectionNameEn'>
                                     ชื่อ Section ภาษาอังกฤษ</label>
                                 <input type='text' class='form-control' id='txtSectionNameEn' placeholder='Section Name' value='" + _sectionNameEn + @"' />
                             </div>
                         </div>");

        _string.Append(@"   <div class='row'>

                             <div class='form-group col-xs-5'>
                                <lable for='txtStartDateProjectSection' style='font-weight:bold;'>วันที่เริ่มต้น</lable>&nbsp;<span style='color:Red;font-weight:bold;'>*</span>
                                <div class='input-group date datetimepicker'>
                                    <input type='text' class='form-control txtStartDateProjectSection' value='" + _startDate + @"'  />
                                    <span class='input-group-addon'>
                                        <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                    </span>
                                </div>
                            </div>


                            <div class='form-group col-xs-5'>
                                 <lable for='txtEndDateProjectSection' style='font-weight:bold;'>วันที่สิ้นสุด</lable>&nbsp;<span style='color:Red;font-weight:bold;'>*</span>
                                 <div class='input-group date datetimepicker'>
                                    <input type='text' class='form-control txtEndDateProjectSection' value='" + _endDate + @"' />
                                    <span class='input-group-addon'>
                                        <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                    </span>
                                </div>
                            </div>



                            <div class='form-group col-xs-2'>
                                 <label for='txtAmountSection'>
                                     จำนวนรับสมัคร</label>
             
                                    <input type='number' class='form-control' id='txtAmountSection' placeholder='จำนวนรับสมัคร'  value='" + _amountMax + @"'  />
          
                            </div>


                            </div> ");

        //<div class='form-group col-xs-2'>
        //      <label for='txtAmountSection'>
        //          กลุ่มของนักศึกษา</label>
        //         <input id='btnAddTargetGroup' type='button' value='เพิ่ม' />


        // </div>
        //       <div class='form-group col-xs-3'>   
        //     <label for='txtHourSection'>จำนวนชั่วโมงของโครงการ</label>

        //            <input type='text' class='form-control' id='txtHourSection' placeholder='จำนวนชั่วโมง' disabled />

        //</div>


        _string.Append(@"    <div class='row'>
                                 <div class='form-group col-xs-12'>
                                     <label for='txtPlaceSection'>
                                         สถานที่จัด</label>
                                     <input type='text' class='form-control' id='txtPlaceSection' placeholder='สถานที่จัด'  value='" + _place + @"'  />
                                 </div>
                             </div>");
        _string.Append(@" <div class='row'>

                             <div class='form-group col-xs-6'>
                                 <label for='txtMuxRefId'>รหัส MUX</label>
                                 <input type='text' class='form-control' id='txtMuxRefId'
                                  placeholder='รหัสอ้างอิงจากระบบ MUX'  value='" + _muxRefId + @"'  />
                             </div>

                             <div class='form-group col-xs-3'>
                                 <label for='ddlStatusPassMux'>สถานะการสอบ(จากระบบ MUX)</label>

                                    <select name='selStatusPassMux' class='form-control ddlStatusPassMux selectpicker' multiple> 
                                        <optgroup label='กรุณาเลือก' >
                                            <option value='0' >pass</option>
                                            <option value='1' >not pass</option>
                                        </optgroup>
                                    </select>

                             </div>

                             <div class='form-group col-xs-3'>
                                 <label for='ddlStatusEnrollmentMux'>สถานะการลงทะเบียน(จากระบบ MUX)</label>
                                    <select name='selStatusEnrollmentMux' class='form-control ddlStatusEnrollmentMux selectpicker' multiple> 
                                        <optgroup label='กรุณาเลือก' >
                                            <option value='0'>enrollment</option>
                                            <option value='1'>unenrollment</option>
                                        </optgroup>
                                    </select>
                             </div>

                          </div> ");

        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-18
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ Edit Section
    /// Method : editSectionPage
    /// Sample : N/A
    /// </summary>
    public static string editSectionPage(string _projectSectionId)
    {
        StringBuilder _string = new StringBuilder();



        _string.Append(@" <div id='divEditSection'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Section </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divSectionPage(_projectSectionId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>

                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateProjectSection'> บันทึก</button>
                                            
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                       
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-18
    /// Perpose: แสดงเมนูหน้าจอของข้อมูล Budget
    /// Method : divProjectBudgetPage
    /// Sample : N/A
    /// </summary>
    public static string divProjectBudgetPage(string _transProjectBubgetId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        string _budgetTypeId = "";
        DataSet _ds = ActDB.getListTransProjectBudget(_transProjectBubgetId);
        string _budget = "";
        string _paid = "";


        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _budgetTypeId = _dr["budgetTypeId"].ToString();
                _budget = String.Format("{0:F2}", Convert.ToDouble(_dr["budget"]));
                _paid = String.Format("{0:F2}", Convert.ToDouble(_dr["paid"]));
            }


        }

        _string.Append(@"     <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            
                                          " + getListBudgetType(_budgetTypeId, _facultyId) + @"
                                      </div>
                              </div>");
        _string.Append(@"    <div class='row '>
                            <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ยอดรายรับ(บาท)</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input  type='number' class='form-control txtProjectBudget' placeholder='ยอดรายรับ' value='" + _budget + "'  required/> " + @"
                             </div>
                             <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ยอดรายจ่าย(บาท)</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input  type='number' class='form-control txtProjectPaid' placeholder='ยอดรายจ่าย'  value='" + _paid + "'  required/> " + @"
                             </div>

                              </div>");

        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-18
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ EditProject Budget 
    /// Method : editProjectBudgetPage
    /// Sample : N/A
    /// </summary>
    public static string editProjectBudgetPage(string _transProjectBubgetId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();



        _string.Append(@"   <div id='divEditProjectBudget'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูลแหล่งทุนของโครงการ </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divProjectBudgetPage(_transProjectBubgetId, _facultyId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12 text-center'>
                                            
                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateProjectBudget'> บันทึก</button>
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();
    }






    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-19
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ Edit Project Indicator 
    /// Method : editProjectIndicatorPage
    /// Sample : N/A
    /// </summary>
    public static string editProjectIndicatorPage(string _transSectionIndicatorId, string _projectId, string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"   <div id='divEditProjectIndicator'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูลตัวชี้วัดของ Section </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divProjectIndicatorPage(_transSectionIndicatorId, _projectId, _facultyId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                                             <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateProjectIndicator'> บันทึก</button>                       
                                
</div>
                                        </div>
                                    </p>
                                  </div>
                               
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-19
    /// Perpose: แสดงเมนูหน้าจอของข้อมูล Indicator
    /// Method : divProjectIndicatorPage
    /// Sample : N/A
    /// </summary>
    public static string divProjectIndicatorPage(string _transSectionIndicatorId, string _projectId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        string _indicatorId = "";
        DataSet _ds = ActDB.getListTransProjectIndicator(_transSectionIndicatorId);
        string _hours = "";
        string _projectSectionId = "";
        string _subIndicatorId = "";
        string _description = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectSectionId = _dr["projectSectionId"].ToString();
                _indicatorId = _dr["indicatorId"].ToString();
                _subIndicatorId = _dr["subIndicatorId"].ToString();
                _hours = _dr["hours"].ToString();
                _description = _dr["description"].ToString();
            }


        }

        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            
                                          " + getListSection(_projectId, _projectSectionId) + @"
                                         </div>
                                     </div>");


        _string.Append(@"     <div class='row '>
                                      <div class='form-group col-xs-4 '>
                                          " + getListDdlIndicator(_indicatorId, _facultyId) + @"
                                      </div>

                                     <div class='form-group col-xs-4 '>
                                          <span class='spnSubIndicator'>" + getListDdlSubIndicator(_indicatorId, _subIndicatorId, _facultyId) + @"</span>
                                      </div>

                                      <div class='form-group col-xs-4 '>
                                             <label for=''>
                                                 จำนวนชั่วโมงกิจกรรม</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input  type='number' onkeypress='return isNumberKey(event)' class='form-control txtProjectIndicatoeHour' placeholder='จำนวนชั่วโมงกิจกรรม' value='" + _hours + "'  required/> " + @"
                                       </div>

                                </div> ");

        _string.Append(@"<div class='row '>
                           <div class='form-group col-xs-12 '>
                                            
                            <label for='' >ลักษณะกิจกรรมที่สอดคล้อง  </label> 
                            <input class='form-control txtDescription' value='" + _description + @"' />
                           </div>           
                        </div>");

        return _string.ToString();
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-19
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ Edit Project Device
    /// Method : editProjectDevicePage
    /// Sample : N/A
    /// </summary>
    public static string editProjectDevicePage(string _transSectionDeviceId, string _projectId)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"   <div id='divEditProjectDevice'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Device ใน Section </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divProjectDevicePage(_transSectionDeviceId, _projectId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12 '>
                                            <input class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateProjectDevice' type='button' value='บันทึก'/>
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                  
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-19
    /// Perpose: แสดงเมนูหน้าจอของข้อมูล Device
    /// Method : divProjectDevicePage
    /// Sample : N/A
    /// </summary>
    public static string divProjectDevicePage(string _transSectionDeviceId, string _projectId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListTransProjectDevice(_transSectionDeviceId);
        string _projectSectionId = "";
        string _deviceInfoId = "";
        string _startDate = "";
        string _endDate = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectSectionId = _dr["projectSectionId"].ToString();
                _deviceInfoId = _dr["deviceInfoId"].ToString();
                _startDate = _dr["startDate"].ToString();
                _endDate = _dr["endDate"].ToString();
            }

        }

        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                            
                                          " + getListSection(_projectId, _projectSectionId) + @"
                                         </div>
                           </div>");
        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                                  " + getListDevice(_deviceInfoId) + @"
                                      </div>
                            </div>");


        _string.Append(@"   <div class='row'>

                             <div class='form-group col-xs-6'>
                                

                             <lable for='txtStartDateDevice' style='font-weight:bold;'>วันที่เปิด</lable>
                                <div class='input-group date datetimepicker'>
                                    <input type='text' class='form-control txtStartDateDevice' value='" + _startDate + @"' />
                                    <span class='input-group-addon'>
                                        <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                    </span>
                                </div>
                            </div>
                             <div class='form-group col-xs-6'>
                                 <lable for='txtEndDateDevice' style='font-weight:bold;'>วันที่ปิด</lable>
                                 <div class='input-group date datetimepicker'>
                                    <input type='text' class='form-control txtEndDateDevice' value='" + _endDate + @"' />
                                    <span class='input-group-addon'>
                                        <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                    </span>
                                </div>
                            </div>

                           

                            </div> ");

        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-19
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Indicator
    /// Method : divConfigIndicatorPage
    /// Sample : N/A
    /// </summary>
    public static string divConfigIndicatorPage(string _indicatorId, string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListConfigIndicator(_indicatorId, _facultyId);
        string _indicatorNameTh = "";
        string _indicatorNameEn = "";
        string _startYear = "";
        string _endYear = "";
        string _indicatorAbbrevTh = "";
        string _indicatorAbbrevEn = "";

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _indicatorNameTh = _dr["indicatorNameTh"].ToString();
                _indicatorNameEn = _dr["indicatorNameEn"].ToString();
                _indicatorAbbrevTh = _dr["indicatorAbbrevTh"].ToString();
                _indicatorAbbrevEn = _dr["indicatorAbbrevEn"].ToString();


                _startYear = _dr["startYear"].ToString();
                _endYear = _dr["endYear"].ToString();



            }

        }
        if (_indicatorId == "") // แสดงถึงว่ามาจาก Page การเพิ่มข้อมูลใหม่ พี่ปเนศให้ Default ปีปัจจุบัน
        {
            _startYear = (DateTime.Now.Year + 543).ToString();
            _endYear = (DateTime.Now.Year + 543).ToString();
        }

        _string.Append(@"        <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Indicator ภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtIndicatorNameTh' placeholder='ชื่อ Indicator ภาษาไทย' value='" + _indicatorNameTh + @"' /> " + @"
                                         </div>
         
                                     </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Indicator ภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtIndicatorNameEn' placeholder='Indicator Name' value='" + _indicatorNameEn + @"' /> " + @"
                                       </div>
         
                                   </div>");

        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาไทย</label> 
                                          <input type='text' class='form-control txtIndicatorAbbrevTh' placeholder='ชื่อตัวย่อ Indicator ภาษาไทย' value='" + _indicatorAbbrevTh + "' /> " + @"
                                      </div>
                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtIndicatorAbbrevEn' placeholder='Indicator Abbrev Name' value='" + _indicatorAbbrevEn + "' /> " + @"
                                      </div>

                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่เริ่ม</label> 
                                          <input type='number' class='form-control txtStartYearIndicator' placeholder='ปีที่เริ่ม' value='" + _startYear + "' /> " + @"
                                      </div>

                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่สิ้นสุด</label> 
                                          <input type='number' class='form-control txtEndYearIndicator' placeholder='ปีที่สิ้นสุด' value='" + _endYear + "' /> " + @"
                                      </div>
         
                                   </div>");

        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Indicator
    /// Method : editConfigIndicator
    /// Sample : N/A
    /// </summary>
    public static string editConfigIndicator(string _indicatorId, string _facultyId)
    {

        StringBuilder _string = new StringBuilder();


        _string.Append(@"   <div id='divEditConfigIndicator'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Config Indicator </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divConfigIndicatorPage(_indicatorId, _facultyId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
   
                                             <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateConfigIndicator'> บันทึก</button>          
                              
                                             </div>
                                        </div>
                                    </p>
                                  </div>
                                  
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Character
    /// Method : divConfigCharacterPage
    /// Sample : N/A
    /// </summary>
    public static string divConfigCharacterPage(string _characterId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListConfigCharacter(_characterId);
        string _characterNameTh = "";
        string _characterNameEn = "";
        string _startYear = "";
        string _endYear = "";
        string _characterAbbrevTh = "";
        string _characterAbbrevEn = "";
        string _groupCharacterId = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _characterNameTh = _dr["characterNameTh"].ToString();
                _characterNameEn = _dr["characterNameEn"].ToString();
                _characterAbbrevTh = _dr["characterAbbrevTh"].ToString();
                _characterAbbrevEn = _dr["characterAbbrevEn"].ToString();
                _groupCharacterId = _dr["groupCharacterId"].ToString();
                _startYear = _dr["startYear"].ToString();
                _endYear = _dr["endYear"].ToString();
            }

        }

        if (_characterId == "") // แสดงถึงว่ามาจาก Page การเพิ่มข้อมูลใหม่ พี่ปเนศให้ Default ปีปัจจุบัน
        {
            _startYear = (DateTime.Now.Year + 543).ToString();
            _endYear = (DateTime.Now.Year + 543).ToString();
        }

        _string.Append(@"  <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Character ภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtCharacterNameTh' placeholder='ชื่อ Character ภาษาไทย' value='" + _characterNameTh + @"' /> " + @"
                                         </div>
         
                                     </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Character ภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtCharacterNameEn' placeholder='Character Name' value='" + _characterNameEn + @"' /> " + @"
                                         </div>
         
                                   </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาไทย</label> 
                                          <input type='text' class='form-control txtCharacterAbbrevTh' placeholder='ชื่อตัวย่อ Character ภาษาไทย' value='" + _characterAbbrevTh + @"' /> " + @"
                                      </div>
                                      <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtCharacterAbbrevEn' placeholder='Character Abbrev Name' value='" + _characterAbbrevEn + @"' /> " + @"
                                      </div> </div>");
        _string.Append(@"          <div class='row '>
                                    <div class='form-group col-xs-6 '>
                                         " + getListGroupCharacter(_groupCharacterId, _facultyId) + @"   
                                    </div>


                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่เริ่ม</label> 
                                          <input type='number' class='form-control txtStartYearCharacter' placeholder='ปีที่เริ่ม' value='" + _startYear + @"' /> " + @"
                                      </div>

                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่สิ้นสุด</label> 
                                          <input type='number' class='form-control txtEndYearCharacter' placeholder='ปีที่สิ้นสุด' value='" + _endYear + @"' /> " + @"
                                      </div>
         
                                   </div>");



        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Indicator
    /// Method : editConfigCharacter
    /// Sample : N/A
    /// </summary>
    public static string editConfigCharacter(string _characterId, string _facultyId)
    {

        StringBuilder _string = new StringBuilder();


        _string.Append(@"   <div id='divEditConfigCharacter'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Config Character </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divConfigCharacterPage(_characterId, _facultyId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
   
                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateConfigCharacter'> บันทึก</button>          
                              
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                  
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Budget
    /// Method : editConfigBudget
    /// Sample : N/A
    /// </summary>
    public static string editConfigBudget(string _budgetId)
    {

        StringBuilder _string = new StringBuilder();


        _string.Append(@"   <div id='divEditConfigBudget'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Config Budget </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divConfigBudgetPage(_budgetId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>
                
                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateConfigBudget'> บันทึก</button>          
                              
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                 
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Config Budget
    /// Method : divConfigBudgetPage
    /// Sample : N/A
    /// </summary>
    public static string divConfigBudgetPage(string _budgetId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListConfigBudget(_budgetId);
        string _budgetTypeNameTh = "";
        string _budgetTypeNameEn = "";
        string _startYear = "";
        string _endYear = "";

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _budgetTypeNameTh = _dr["budgetTypeNameTh"].ToString();
                _budgetTypeNameEn = _dr["budgetTypeNameEn"].ToString();

                _startYear = _dr["startYear"].ToString();
                _endYear = _dr["endYear"].ToString();
            }

        }
        if (_budgetId == "") // แสดงถึงว่ามาจาก Page การเพิ่มข้อมูลใหม่ พี่ปเนศให้ Default ปีปัจจุบัน
        {
            _startYear = (DateTime.Now.Year + 543).ToString();
            _endYear = (DateTime.Now.Year + 543).ToString();
        }
        _string.Append(@"    <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อแหล่งทุนภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtBugetTypeNameTh' placeholder='ชื่อแหล่งทุนภาษาไทย' value='" + _budgetTypeNameTh + @"' /> " + @"
                                         </div>
         
                                     </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อแหล่งทุนภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtBugetTypeNameEn' placeholder='Budget Name' value='" + _budgetTypeNameEn + @"' /> " + @"
                                         </div>
         
                                   </div>");
        _string.Append(@"          <div class='row '>
            
                                      <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ปีที่เริ่ม</label> 
                                          <input type='number' class='form-control txtStartYearBugetType' placeholder='ปีที่เริ่ม' value='" + _startYear + @"' /> " + @"
                                      </div>

                                      <div class='form-group col-xs-6 '>
                                             <label for=''>
                                                 ปีที่สิ้นสุด</label> 
                                          <input type='number' class='form-control txtEndYearBugetType' placeholder='ปีที่สิ้นสุด' value='" + _endYear + @"' /> " + @"
                                      </div>
         
                                   </div>");
        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ divConfigDevicePage
    /// Method : divConfigDevicePage
    /// Sample : N/A
    /// </summary>
    public static string divConfigDevicePage(string _deviceId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListConfigDevice(_deviceId);
        string _deviceNameTh = "";
        string _deviceNameEn = "";
        string _deviceNumber = "";

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _deviceNameTh = _dr["deviceNameTh"].ToString();
                _deviceNameEn = _dr["deviceNameEn"].ToString();
                _deviceNumber = _dr["deviceNumber"].ToString();

            }

        }
        _string.Append(@"              <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Device ภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtDeviceNameTh' placeholder='ชื่อ Device ภาษาไทย' value='" + _deviceNameTh + @"'/> " + @"
                                         </div>
         
                                     </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Device ภาษาอังกฤษ</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtDeviceNameEn' placeholder='Device Name' value='" + _deviceNameEn + @"' /> " + @"
                                         </div>
         
                                   </div>");
        _string.Append(@"          <div class='row '>
            
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 หมายเลขเครื่อง</label> 
                                          <input type='text' class='form-control txtDeviceNumber' placeholder='หมายเลขเครื่อง' value='" + _deviceNumber + @"'/> " + @"
                                      </div>

                                    
         
                                   </div>");

        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ editConfigDevices
    /// Method : editConfigDevices
    /// Sample : N/A
    /// </summary>
    public static string editConfigDevices(string _deviceId)
    {

        StringBuilder _string = new StringBuilder();


        _string.Append(@"   <div id='divEditConfigDevice'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูล Config Device </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divConfigDevicePage(_deviceId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12 '>
                                            <input class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateConfigDevice' type='button' value='บันทึก'/>
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                  
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ editConfigGroupCharacter
    /// Method : editConfigGroupCharacter
    /// Sample : N/A
    /// </summary>
    public static string editConfigGroupCharacter(string _groupCharacterId)
    {

        StringBuilder _string = new StringBuilder();


        _string.Append(@"   <div id='divEditConfigGroupCharacter'>
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'>แก้ไขข้อมูลกลุ่ม Character </h4>
                                  </div>
                                  <div class='modal-body'>
                                    <p>" + divConfigGroupCharacterPage(_groupCharacterId) + @"
                                        <div class='row'>
                                            <div class='form-group col-xs-12  text-center '>

                                            <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnUpdateConfigGroupCharacter'> บันทึก</button>          
                              
                                            </div>
                                        </div>
                                    </p>
                                  </div>
                                  
                                </div>

                              </div>
                            </div> ");
        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-20
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ divConfigGroupCharacterPage
    /// Method : divConfigGroupCharacterPage
    /// Sample : N/A
    /// </summary>
    public static string divConfigGroupCharacterPage(string _groupCharacterId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListConfigGroupCharacter(_groupCharacterId);
        string _groupCharacterNameTh = "";
        string _groupCharacterNameEn = "";
        string _groupCharacterAbbrevTh = "";
        string _groupCharacterAbbrevEn = "";
        string _startYear = "";
        string _endYear = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _groupCharacterNameTh = _dr["groupCharacterNameTh"].ToString();
                _groupCharacterNameEn = _dr["groupCharacterNameEn"].ToString();
                _groupCharacterAbbrevTh = _dr["groupCharacterAbbrevTh"].ToString();
                _groupCharacterAbbrevEn = _dr["groupCharacterAbbrevEn"].ToString();
                _startYear = _dr["startYear"].ToString();
                _endYear = _dr["endYear"].ToString();
            }

        }
        if (_groupCharacterId == "") // แสดงถึงว่ามาจาก Page การเพิ่มข้อมูลใหม่ พี่ปเนศให้ Default ปีปัจจุบัน
        {
            _startYear = (DateTime.Now.Year + 543).ToString();
            _endYear = (DateTime.Now.Year + 543).ToString();
        }
        _string.Append(@"     <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Group Character ภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtGroupCharacterNameTh' placeholder='ชื่อ Group Character ภาษาไทย' value='" + _groupCharacterNameTh + @"'/> " + @"
                                         </div>
         
                                     </div>");
        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อ Group Character ภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtGroupCharacterNameEn' placeholder='Group Character Name' value='" + _groupCharacterNameEn + @"'/> " + @"
                                         </div>
         
                                   </div>");

        _string.Append(@"          <div class='row '>
                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาไทย</label> 
                                          <input type='text' class='form-control txtGroupCharacterAbbrevTh' placeholder='ชื่อตัวย่อภาษาไทย' value='" + _groupCharacterAbbrevTh + @"'/> " + @"
                                      </div>
                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ชื่อตัวย่อภาษาอังกฤษ</label> 
                                          <input type='text' class='form-control txtGroupCharacterAbbrevEn' placeholder='Group Character Abbrev Name' value='" + _groupCharacterAbbrevEn + @"'/> " + @"
                                      </div>            

                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่เริ่ม</label> 
                                          <input type='number' class='form-control txtStartYearGroupCharacter' placeholder='ปีที่เริ่ม' value='" + _startYear + @"'/> " + @"
                                      </div>

                                      <div class='form-group col-xs-3 '>
                                             <label for=''>
                                                 ปีที่สิ้นสุด</label> 
                                          <input type='number' class='form-control txtEndYearGroupCharacter' placeholder='ปีที่สิ้นสุด' value='" + _endYear + @"'/> " + @"
                                      </div>
         
                                   </div>");
        return _string.ToString();

    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-21
    /// Perpose: แสดงรายการข้อมูล Position
    /// Method : getListPosition
    /// Sample : N/A
    /// </summary>
    public static string getListPosition(string _statusPerson)
    {
        // _statusPerson = 1 เป็นนักศึกษา เห็นได้แค่ 
        //  ผู้เข้าร่วม
        //  หัวหน้าโครงการ
        //  ผู้จัด
        if (_statusPerson == "1")
        {
            _statusPerson = "PNT-001";
        }
        else
        {
            _statusPerson = "PNT-002";
        }
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListPosition(_statusPerson);
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlPosition'>
                                 สถานะเข้าร่วม</label><span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlPosition' >
                                <option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_statusPerson == "1")
                {
                    // if ((_dr["id"].ToString() == "PST-001") || (_dr["id"].ToString() == "PST-002") || (_dr["id"].ToString() == "PST-003"))
                    // {
                    _string.Append(@"<option value='" + _dr["id"] + "'   >" + _dr["positionNameTh"] + "</option>");
                    // }
                }
                else
                {
                    _string.Append(@"<option value='" + _dr["id"] + "'   >" + _dr["positionNameTh"] + "</option>");
                }
            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-22
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับ edit Prject Page
    /// Method : editProjectPage
    /// Sample : N/A
    /// </summary>
    public static string editProjectPage(string _acaYear, string _semester, string _projectNameTh, string _projectNameEn, string _projectDetail
                                         , string _instituteId, string _targetGroup, string _projectTypeId, string _projectStatusNameTh
                                         , string _facultyId, string _facultyIdDb, string _startDateRecruit, string _endDateRecruit
                                         , string _expressionStudentCode, string _expressionClassYear, string _expressionFaculty
                                         , string _projectDetailEn
                                         , string _disabledFlagProjectType)
    {
        StringBuilder _string = new StringBuilder();
        string _chkConditionStudent = "";
        string _chkConditionFaculty = "";
        string _chkConditionClassYear = "";
        string _disbeleConditionStudent = "";
        string _disbeleConditionClassYear = "";
        string _disbeleConditionFaculty = "";
        if (_expressionClassYear != "")
        {
            _chkConditionClassYear = "checked='checked'";
            _disbeleConditionClassYear = "";
        }
        else
        {
            _chkConditionClassYear = "";
            _disbeleConditionClassYear = " disabled ";

        }
        if (_expressionFaculty != "")
        {
            _chkConditionFaculty = "checked='checked'";
            _disbeleConditionFaculty = "";
        }
        else
        {
            _chkConditionFaculty = "";
            _disbeleConditionFaculty = " disabled ";
        }

        if (_expressionStudentCode != "")
        {
            _chkConditionStudent = "checked='checked'";
            _disbeleConditionStudent = "";
        }
        else {
            _chkConditionStudent = "";
            _disbeleConditionStudent = " disabled ";
        }

        _string.Append(@"    <div class='row ' >
                                        <div class='form-group col-xs-6 '>");
        //if (_acaYear == "") // คือ การสร้างโครงการใหม่ จะให้มีตั้งแต่ปีการศึกษา 2564 ขึ้นไปเท่านั้น
        //{
        //    _string.Append(getListAcaYear(_acaYear, "1"));
        //}
        //else
        //{
        //    _string.Append(getListAcaYear(_acaYear, ""));
        //}

        _string.Append(getListAcaYear(_acaYear, "1")); // _string.Append(getListAcaYear(_acaYear, "1"));

        _string.Append(@"               </div>
                                      <div class='form-group col-xs-6 '>
                                           " + getListSemester(_semester) + @"
                                      </div>

                                     </div>

                                    <div class='row '>
                                      <div class='form-group col-xs-12 '>
                                             <label for=''>
                                                 ชื่อโครงการภาษาไทย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                          <input type='text' class='form-control txtProjectNameTh' placeholder='ชื่อโครงการภาษาไทย' value='" + _projectNameTh + "' required/> " + @"
                                         </div>
         
                                     </div>




                                     <div class='row'>
                                         <div class='form-group col-xs-12'>
                                             <label for=''>
                                                 ชื่อโครงการภาษาอังกฤษ</label> 
                                               <input type='text' class='form-control txtProjectNameEn' placeholder='Project Name' value='" + _projectNameEn + "' required/> " + @"
        
                                         </div>
                                     </div>
                                     <div class='row'>
                                         <div class='form-group col-xs-12'>
                                             <label for=''>
                                                 รายละเอียดของโครงการภาษาไทย</label>
                                              <input type='text' class='form-control txtProjectDetail' placeholder='รายละเอียดโครงการภาษาไทย' value='" + _projectDetail + "' required/> " + @"
        
                                         </div>
                                     </div>

                                     <div class='row'>
                                         <div class='form-group col-xs-12'>
                                             <label for=''>
                                                 รายละเอียดของโครงการภาษาอังกฤษ</label>
                                              <input type='text' class='form-control txtProjectDetailEn' placeholder='Project detail in English' value='" + _projectDetailEn + "' required/> " + @"
        
                                         </div>
                                     </div>

                                     <div class='row'>
                                        <div class='form-group col-xs-12' >
                                         " + getListInstitute(_instituteId, _facultyId) + @"
                                         </div>
                                    

                          



                                    </div>


                                    <div class='row'>
                                         
                                         <div class='col-xs-6' >
                                         " + getListProjectType(_projectTypeId, _disabledFlagProjectType) + @"
                                         </div>
                                         <div class='col-xs-6' >
                                         <label for=''>
                                                 สถานะโครงการ</label>
                                         <input type='text' class='form-control ' value='" + _projectStatusNameTh + "' disabled/> " + @"
                                               
                                         </div>
                                     </div> 
                                     </br>


                                        <div class='panel-group'>
                                            <div class='panel panel-default'>
                                            <div class='panel-heading'>
                                              <label  style='cursor:pointer;'>  ");
        if (_acaYear == "")
        {
            _string.Append("<input type='checkbox' style='cursor:pointer;'  class='chkPanelOnline' >");
        }
        _string.Append(@" เปิดรับสมัครออนไลน์ </label>
                                            </div>
                                            <div class='panel-body' disabled>
                                                                 <div class='row'>

                                                                          <div class='col-xs-12' > 
                                                                              <div class='row'>
                                                                              <div class='form-group text-sm-left'>

                                                                                <div class='form-group col-xs-6'>
                                                                                    <lable for='txtStartDateRecruit' style='font-weight:bold;'>วันที่เปิดการรับสมัคร</lable>
                                                                                    <div class='input-group date datetimepicker'>
                                                                                        <input type='text' class='form-control txtStartDateRecruit chkPanelOnlineDisable' value='" + _startDateRecruit + @"'  />
                                                                                        <span class='input-group-addon'>
                                                                                            <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>

                                                                                <div class='form-group col-xs-6'>
                                                                                     <lable for='txtEndDateRecruit' style='font-weight:bold;'>วันที่สิ้นสุดการรับสมัคร</lable>
                                                                                     <div class='input-group date datetimepicker'>
                                                                                        <input type='text' class='form-control txtEndDateRecruit chkPanelOnlineDisable' value='" + _endDateRecruit + @"' />
                                                                                        <span class='input-group-addon'>
                                                                                            <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                              </div>
                                                                              </div>

                                                                          </div>

                                                                 </div>

                                                                 <div class='row'>
                                                                        <div class='form-group text-sm-left'>
                                                                            <div class='form-group col-xs-12'>
                                                                                <b>เงื่อนไขเฉพาะนักศึกษา</b>
                                                                            </div>
                                                                        </div>
                                                                 </div>

                                                                 <div class='row'>
                                                                          <div class='col-xs-2' > 
                                                                             <div class='checkbox'  style='cursor:pointer;'>
                                                                                      <label><input type='checkbox' style='cursor:pointer;' class='chkStudentCode chkPanelOnlineDisable' " + _chkConditionStudent + @">รหัสนักศึกษา</label>
                                                                             </div>
                                                                          </div>

                                                                          <div class='col-xs-10' > 
                                                                      
                                                                                <div class='form-group text-sm-left'>
                                                                                     <input type='text' class='form-control txtConditionStudentCode ' placeholder='ตัวอย่างการกรอกข้อมูล 5415001-5415005,5415009 เป็นต้น' value='" + _expressionStudentCode + "'  " + _disbeleConditionStudent + @"/>
                                                                               
                                                                                </div>

                                                                          </div>

                                                                 </div>

                                                                 <div class='row'>
                                                                         <div class='col-xs-2' > 
                                                                             <div class='checkbox' style='cursor:pointer;'>
                                                                                      <label><input type='checkbox' style='cursor:pointer;' class='chkFaculty chkPanelOnlineDisable' " + _chkConditionFaculty + @">คณะ</label>
                                                                             </div>
                                                                          </div>
                                                                          <div class='col-xs-10' > 
                                                                              <div class='form-group text-sm-left'>
                                                                                     " + getListFacultyPicker(_disbeleConditionFaculty) + @"
                                                                              </div>
                                                                          </div>
                                                                 </div>

                                                                 <div class='row'>
                                                                          <div class='col-xs-2' > 
                                                                             <div class='checkbox' style='cursor:pointer;'>
                                                                                      <label><input type='checkbox' style='cursor:pointer;' class='chkClassYear chkPanelOnlineDisable' " + _chkConditionClassYear + @" >ชั้นปี</label>
                                                                             </div>
                                                                          </div>
                                                                          <div class='col-xs-10' > 
                                                                              <div class='form-group text-sm-left'>
                                                                                     " + getListClassYearPicker(_disbeleConditionClassYear) + @"
                                                                              </div>
                                                                          </div>
                                                                 </div>

                                                                 <div class='row'>
                                                                          <div class='form-group text-sm-left'>
                                                                               <div class='form-group col-xs-2'>
                                                                                     <span style='color:red;'><b>หมายเหตุ :</b></span>
                                                                               </div>
                                                                               <div class='form-group col-xs-10'>
                                                                                     <span style='color:red;'>*** วันที่เปิด/สิ้นสุดการรับสมัคร เป็นวันที่ที่นักศึกษาจะเห็นโครงการสมัครออนไลน์บนเว็บไซต์ <u>ไม่ใช่วันที่เปิด/ปิดของการจัดกิจกรรม</u></span>
                                                                               </div>
                                                                          </div>
                                                                  </div>
                                                                 <div class='row'>
                                                                          <div class='form-group text-sm-left'>
                                                                               <div class='form-group col-xs-2'>
                                                                                     
                                                                               </div>
                                                                               <div class='form-group col-xs-10'>
                                                                        
                                                                                     <span style='color:red;'>*** ตัวอย่างการกรอกข้อมูล รหัสนักศึกษา 5415001-5415005,5415009 เป็นต้น</span>
                                                                     
                                                                               </div>
                                                                          </div>
                                                                  </div>

                                            </div>
                                            </div>
                                            </div>

                                      ");
        // _expressionStudentCode


        //<div class='row '>
        //                                    <div class='form-group col-xs-3 '>
        //                                           <div class='checkbox'>
        //                                            <label><input type='checkbox' value='1'>รหัสนักศึกษา</label>
        //                                          </div>
        //                                    </div>
        //                                    <div class='form-group col-xs-9 text-sm-left'>
        //                                           <input type='text' class='form-control txtConditionStudent' />
        //                                    </div>

        //                                   </div>

        //                                  <div class='row '>
        //                                    <div class='form-group col-xs-3 '>
        //                                           <div class='checkbox'>
        //                                            <label><input type='checkbox' value='1'>ชั้นปี</label>
        //                                          </div>
        //                                    </div>
        //                                    <div class='form-group col-xs-9 text-sm-left'>
        //                                           <input type='text' class='form-control txtConditionClass' />
        //                                    </div>

        //                                   </div>

        //<div class='col-xs-4' >
        //" + getListProjectStatus(_projectStatusId) + @"
        //</div>

        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-22
    /// Perpose: แสดงเมนูหน้าจอของข้อมูลสำหรับเตรียมฟิวเตอร์โครงการที่จะอนุุมัติ
    /// Method : LoadFillterProjectForApprove
    /// Sample : N/A
    /// </summary>
    public static string LoadFillterProjectForApprove(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"     <div class='row '>
                                      <div class='form-group col-xs-2 '>
                                           " + getListAcaYearWithBlankChoose("") + @"
                                      </div>

                                      <div class='form-group col-xs-2 '>
                                           " + getListSemesterWithBlankChoose("") + @"
                                      </div>

                                      <div class='form-group col-xs-6 '>
                                           " + getListFaculty(_facultyId, "") + @"
                                      </div>

                                      <div class='form-group col-xs-2 '>
                                           " + getListProjectStatus("PSS-005") + @"
                                      </div>

                              </div>");
        _string.Append(@" <div class='row '>
                             <div class='form-group col-xs-12 text-center'>
                                <button type='button' class='btn btn-info btn-md btnSearchProjectApprove glyphicon glyphicon-search'> ค้นหา</button>
                           </div></div>");
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลคณะ
    /// Method : getListFaculty
    /// Sample : N/A
    /// </summary>
    public static string getListFaculty(string _facultyId, string _facultyIdDb)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListFaculty(_facultyId);
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlFaculty'>
                                 คณะ</label>
                                 <select class='form-control ddlFaculty btnChangeFac' >");
            if (_facultyId == "MU-01")
            {
                _string.Append("<option value=''>กรุณาเลือก</option>");
            }
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_facultyIdDb == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["facultyCode"] + " - " + _dr["nameTh"] + "</option>");

            }




            _string.Append(@"</select>");
        }
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลโครงการที่จะต้องการ Approve
    /// Method : getListProjectForApprove
    /// Sample : N/A
    /// </summary>
    public static string getListProjectForApprove(string _acaYear, string _semester, string _facultyId, string _projectStatusId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectForApprove(_acaYear, _semester, _facultyId, _projectStatusId);
        int _countRecord = _ds.Tables[0].Rows.Count;
        int _i = 1;
        string _btnDisplayApprove = "";
        string _iconKeySection = "<span class='glyphicon glyphicon-retweet'></span>&nbsp;";
        string _iconKeyBudget = "<span class='glyphicon glyphicon-usd'></span>&nbsp;";
        string _iconKeyIndicator = "<span class='glyphicon glyphicon-tint'></span>&nbsp;";
        string _iconKeyCharacter = "<span class='glyphicon glyphicon-leaf'></span>&nbsp;";
        string _iconKeyPicture = "<span class='glyphicon glyphicon-picture'></span>";
        string _countBudget = "", _countSection = "", _countIndicator = "", _countCharacter = "", _countPicture = "";
        _string.Append(@"  <div class='table-responsive'>
                    
                                <table id='tblListActForApproveByAdmin' class='table table-hover' >
                                <caption><h4>จำนวนรายการที่พบ " + _countRecord.ToString() + @" โครงการ</h4></caption>
                                <caption>นิยามสถานะกรอกข้อมูล : " + _iconKeySection + @" กรอกข้อมูล Section แล้ว " +
                                _iconKeyBudget + @" กรอกข้อมูล Budget แล้ว " +
                                _iconKeyIndicator + @" กรอกข้อมูล Indicator แล้ว " +
                                _iconKeyCharacter + @" กรอกข้อมูล Character แล้ว " +
                                _iconKeyPicture + @" กรอกข้อมูล Picture แล้ว ");

        _string.Append(@"       </caption>
                                <thead>
                                <tr>
                                <th class='col-sm-1'>
                                ลำดับ
                                </th>
                                <th class='col-sm-1'>
                                ภาค/ปีการศึกษา
                                </th>
                                <th class='col-sm-3'>
                                ชื่อโครงการภาษาไทย
                                </th>
                                <th class='col-sm-2'>
                                ส่วนงานผู้จัด
                                </th>
                                <th class='col-sm-1'>
                                วันที่สร้างโครงการ
                                </th>
                                <th class='col-sm-1'>
                                สถานะโครงการ
                                </th>
                                <th class='col-sm-1'>
                                สถานะกรอกข้อมูล
                                </th>
                                <th class='col-sm-1'>
                                ผู้สร้างโครงการ
                                </th>
                                <th class='col-sm-1'>
                                </th>
                                </tr>
                                </thead>");
        string _acaYearProject = "", _semesterProject = "", _createBy = "";
        if (_countRecord > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _acaYearProject = _dr["acaYear"].ToString();
                _semesterProject = _dr["semester"].ToString();
                _countBudget = _dr["countBudget"].ToString();
                _countSection = _dr["countSection"].ToString();
                _countIndicator = _dr["countIndicator"].ToString();
                _countCharacter = _dr["countCharacter"].ToString();
                _countPicture = _dr["countPicture"].ToString();
                _createBy = _dr["createdBy"].ToString();

                if (_countSection == "0")
                {
                    _iconKeySection = "";
                }
                else
                {
                    _iconKeySection = "<span class='glyphicon glyphicon-retweet'></span>&nbsp;";
                }

                if (_countBudget == "0")
                {
                    _iconKeyBudget = "";
                }
                else
                {
                    _iconKeyBudget = "<span class='glyphicon glyphicon-usd'></span>&nbsp;";
                }


                if (_countIndicator == "0")
                {
                    _iconKeyIndicator = "";
                }
                else
                {
                    _iconKeyIndicator = "<span class='glyphicon glyphicon-tint'></span>&nbsp;";
                }

                if (_countCharacter == "0")
                {
                    _iconKeyCharacter = "";
                }
                else
                {
                    _iconKeyCharacter = "<span class='glyphicon glyphicon-leaf'></span>&nbsp;";
                }

                if (_countPicture == "0")
                {
                    _iconKeyPicture = "";
                }
                else
                {
                    _iconKeyPicture = "<span class='glyphicon glyphicon-picture'></span>";
                }


                if (_dr["projectStatusId"].ToString() == "PSS-005")
                {
                    _btnDisplayApprove = @" <button type='button' class='btn btn-primary btn-md glyphicon glyphicon-thumbs-up' onclick=setApproveProject('" + _dr["id"].ToString() + "'); > อนุมัติ</button>&nbsp;&nbsp;<button type='button' class='btn btn-danger btn-md glyphicon glyphicon-alert' onclick=modalSendMailForApproveProject('" + _dr["id"].ToString() + "'); > ส่งเมล์</button>  ";
                }
                else
                {
                    _btnDisplayApprove = " อนุมัติแล้ว";
                }



                _string.Append(@" <tr >
                                        <th scope='row' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _i.ToString() + @"</a>
                                        </th>
                                        <td style='cursor:pointer;' data-toggle='modal' data-target='#myModal' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _semesterProject + "/" + _acaYearProject + @"</a>
                                        </td>
                                        <td style='cursor:pointer;' data-toggle='modal' data-target='#myModal' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _dr["nameTh"] + @"</a>
                                        </td>
                                        <td style='cursor:pointer;' data-toggle='modal' data-target='#myModal' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _dr["instituteNameTh"] + @"</a>
                                        </td>
                                        <td style='cursor:pointer;' data-toggle='modal' data-target='#myModal' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _dr["createDateTh"] + @"</a>
                                        </td>
                                        <td style='cursor:pointer;' data-toggle='modal' data-target='#myModal' onclick=getListProjectDetailForView('" + _dr["id"].ToString() + @"','0');  '>
                                            <a style='cursor:pointer;'>" + _dr["projectStatusNameTh"] + @"</a>
                                        </td> 
                                        <td>                                           
                                         " + _iconKeySection + _iconKeyBudget + _iconKeyIndicator + _iconKeyCharacter + _iconKeyPicture + @"
                                        </td> 
                                        <td>
                                          " + _createBy + @"
                                        </td>
                                        <td>
                                          " + _btnDisplayApprove + @"
                                        </td>
                                </tr>");



                _i++;

            }
        }
        else
        {
            _string.Append(@"
                            <tr >
                            <td scope='row' colspan='8' align='center'>
                                ไม่พบรายการ
                            </td>
                            </tr>
                ");
        }
        _string.Append(@"</table></div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-24
    /// Perpose: 
    /// Method : addStudentRegistTemp
    /// Sample : N/A
    /// </summary>
    /// 
    public static string addStudentRegistTemp(string _studentCode, string _sectionId, string _positionId)
    {
        DataSet _ds = ActDB.getListChkStudentInSection(_studentCode, _sectionId, _positionId);
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();
        string _inputStudentCode = "", _inputSectionId = "", _inputPositionId = "";
        string _countRecord = "";
        string _sectionNameTh = "";
        string _positionNameTh = "";
        string _facultyCode = "";
        string _facultyNameTh = "";
        string _firstName = "";
        string _lastName = "";
        string _remark = "";
        string _checkBoxInput = "";
        string _countStd = "";
        string _stsCheckbox = "";
        //        _string.Append(@" <table class='table'>
        //                
        //                <thead>
        //                <tr>
        //                <th class='col-sm-1'>
        //                
        //                </th>
        //                <th class='col-sm-1'>
        //                ลำดับ
        //                </th>
        //                <th class='col-sm-3'>
        //                ชื่อ Section
        //                </th>
        //                <th class='col-sm-1'>
        //                รหัสนักศึกษา
        //                </th>
        //                <th class='col-sm-2'>
        //                คณะ
        //                </th>
        //                <th class='col-sm-2'>
        //                ชื่อ-นามสกุล
        //                </th>
        //                <th class='col-sm-1'>
        //                สถานะ
        //                </th>
        //                <th class='col-sm-1'>
        //                หมายเหตุ
        //                </th>
        //                </tr>
        //                </thead> ");



        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _countRecord = _dr["countRecord"].ToString();
                _countStd = _dr["countStd"].ToString();
                _stsCheckbox = _dr["stsCheckbox"].ToString();
                _sectionNameTh = _dr["sectionNameTh"].ToString();
                _positionNameTh = _dr["positionNameTh"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _remark = _dr["remark"].ToString();
                _inputStudentCode = "<input class='studentCodeVal' type='hidden' value='" + _studentCode + "' >";
                _inputSectionId = "<input class='sectionIdVal' type='hidden' value='" + _sectionId + "' >";
                _inputPositionId = "<input class='positionIdVal' type='hidden' value='" + _positionId + "' >";

                if (_stsCheckbox == "0")
                {
                    _checkBoxInput = "<input class='chkStudentRegistSection' type='checkbox' checked='checked' />";

                }
                else
                {
                    _checkBoxInput = "<input class='chkStudentRegistSection' type='checkbox'  disabled='disabled' />";

                }

                _string.Append(@"
               
                                        <tr >
                                        <th scope='row'>
                                        " + _checkBoxInput + @"
                                        </th>
                                          <td >
                                         " + _studentCode + @"
                                        </td>
                                        <td >
                                         " + _sectionNameTh + @"
                                        </td>
                
                                        <td >
                                         " + _facultyCode + " - " + _facultyNameTh + @"
                                        </td>
                                        <td >
                                         " + _firstName + " " + _lastName + @"
                                        </td>
                                        <td >
                                         " + _positionNameTh + @"
                                        </td>
                                        <td >
                                         " + _remark + _inputStudentCode + _inputSectionId + _inputPositionId + @"
                                        </td>
                                        </tr>
                                        ");



            }

        }




        return _string.ToString();

    }















    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-17
    /// Perpose: 
    /// Method : pageDialogUpdatePostition
    /// Sample : N/A
    /// </summary>
    /// 
    public static string pageDialogUpdatePostition(string _transsectionregistid, string _studentcode, string _firstname, string _lastname)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div id='divEditStudentPosition'>
                              <div class='modal-dialog'>

                                <div class='modal-content'>
                                      <div class='modal-header'>
                                        <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                        <h4 class='modal-title'>แก้ไขข้อมูลสถานะเข้าร่วม </h4>
                                      </div>
                                      <div class='modal-body'>
                                        <p>
                                        <div class='row '>
                                          <div class='form-group col-xs-3 '>
                                                 <b>รหัสนักศึกษา :</b>
                                          </div>
                                          <div class='form-group col-xs-2 text-sm-left'>
                                                 " + _studentcode + @"
                                          </div>
                                          <div class='form-group col-xs-3 '>
                                                 <b>ชื่อ-นามสกุล :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _firstname + " " + _lastname + @"
                                          </div>
                                         </div>

                                         <div class='form-group'>
                                             " + getListPosition("1") + @"
                                         </div>
                                        <div class='row'>
                                        <div class='form-group col-xs-12 text-center'>
                       
                                             <button type='button' data-transsectionregistid='" + _transsectionregistid + @"'   class='btn btn-success glyphicon glyphicon-floppy-disk btnSetUpdateStudentPosition'> บันทึก</button>
                      
                                         </div></div>
                                      </div>
                                 </div>
                       </div> </div> ");
        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-30
    /// Perpose: 
    /// Method : getChkForCloseProject
    /// Sample : N/A
    /// </summary>
    /// 
    public static string getChkForCloseProject(string _projectId)
    {
        DataSet _ds = ActDB.getChkForCloseProject(_projectId);
        int _count = _ds.Tables[0].Rows.Count;

        StringBuilder _string = new StringBuilder();
        string _stsCloseProject = "";
        string _stsKeyData = "";
        string _returnKey = "";

        if (_count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _stsCloseProject = _dr["stsCloseProject"].ToString();
                _stsKeyData = _dr["stsKeyData"].ToString();
                if (_stsCloseProject == "1")
                {
                    _returnKey = "1"; // โครงการปิดไปแล้ว
                }
                else if (_stsKeyData == "0")
                {
                    _returnKey = "2"; // กรอกข้อมูลไม่ครบ 3 ด้าน
                }
                else
                {
                    _returnKey = "0"; // สามารถบันทึกข้อมูลได้ คือ กรอกครบ   // ข้อมูล Section ข้อมูล Indicator และข้อมูลนศ.เข้าร่วมกิจกรรม 
                }
                _string.Append(_returnKey);

            }


        }

        return _string.ToString();

    }





    //    /// <summary>
    //    /// Auther : เจตน์ เครือชะเอม
    //    /// Date   : 2017-07-30
    //    /// Perpose: 
    //    /// Method : pageDialogConditionTargetGroup
    //    /// Sample : N/A
    //    /// </summary>
    //    /// 
    //    public static string pageDialogConditionTargetGroup()
    //    {
    //        StringBuilder _string = new StringBuilder();


    //        _string.Append(@"<div id='divConditionTargetGroup'>
    //                              <div class='modal-dialog'>
    //
    //                                <div class='modal-content'>
    //                                      <div class='modal-header'>
    //                                        <button type='button' class='close' data-dismiss='modal'>&times;</button>
    //                                        <h4 class='modal-title'>เงื่อนไข กลุ่มข้อมูลของนักศึกษา  </h4>
    //                                      </div>
    //                                      <div class='modal-body'>
    //                                        <p>
    //                                         <div class='row '>
    //                                          <div class='form-group col-xs-3 '>
    //                                                 <div class='checkbox'>
    //                                                  <label><input type='checkbox' value='1'>คณะ</label>
    //                                                </div>
    //                                          </div>
    //                                          <div class='form-group col-xs-9 text-sm-left'>
    //                                                 <input type='text' class='form-control txtConditionStudent' />
    //                                          </div>
    //                                         
    //                                         </div>
    //
    //                                        <div class='row '>
    //                                          <div class='form-group col-xs-3 '>
    //                                                 <div class='checkbox'>
    //                                                  <label><input type='checkbox' value='1'>รหัสนักศึกษา</label>
    //                                                </div>
    //                                          </div>
    //                                          <div class='form-group col-xs-9 text-sm-left'>
    //                                                 <input type='text' class='form-control txtConditionStudent' />
    //                                          </div>
    //                                         
    //                                         </div>
    //                                        <div class='row '>
    //                                          <div class='form-group col-xs-3 '>
    //                                                 <div class='checkbox'>
    //                                                  <label><input type='checkbox' value='1'>ชั้นปี</label>
    //                                                </div>
    //                                          </div>
    //                                          <div class='form-group col-xs-9 text-sm-left'>
    //                                                 <input type='text' class='form-control txtConditionClass' />
    //                                          </div>
    //                                         
    //                                         </div>
    //
    //                 
    //                                        <div class='row'>
    //                                        <div class='form-group col-xs-12 text-center'>
    //                       
    //                                             <button type='button'   class='btn btn-success glyphicon glyphicon-floppy-disk btnSetConditionTargetGroup'> บันทึก</button>
    //                      
    //                                         </div></div>
    //                                      </div>
    //                                 </div>
    //                       </div> </div> ");
    //        return _string.ToString();

    //    }







    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-31
    /// Perpose: แสดงรายการข้อมูลหลักสูตร
    /// Method : getListProgram
    /// Sample : N/A
    /// </summary>
    public static string getListProgram(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProgram(_facultyId);
        _string.Append(@" <label for='ddlProjectType'>
                                 หลักสูตร</label>
                                 <select class='form-control ddlProgram' >");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@"<option value=''  >กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "'  >" + _dr["programCode"] + _dr["majorCode"] + _dr["groupnum"] + " - " + _dr["nameTh"] + "</option>");
            }
        }
        else
        {
            _string.Append(@"<option value='0'  >ไม่มีหลักสูตร</option>");
        }
        _string.Append(@"</select>");
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-04-19
    /// Perpose: 
    /// Method : getListStudentYear
    /// Sample : N/A
    /// </summary>
    public static string getListStudentYear()
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudentYear();
        _string.Append(@" <label for='ddlStudentYear'>
                                 ปีนักศึกษา</label>
                                 <select class='form-control ddlStudentYear' >");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@"<option value=''  >ทั้งหมด</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append("<option value='" + _dr["studentYear"] + "'  >" + _dr["studentYear"] + "</option>");
            }
        }

        _string.Append(@"</select>");
        return _string.ToString();

    }



















    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-04
    /// Perpose: แสดงรายการข้อมูลชั้นปีใน Dropdownlist
    /// Method : getListClassYearPicker
    /// Sample : N/A
    /// </summary>
    public static string getListClassYearPicker(string _disbeleConditionClassYear)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListClassYear();
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@"   <select name='selClassYear' class='form-control ddlClassYear selectpicker' title='ทุกชั้นปี'  " + _disbeleConditionClassYear + @" multiple>
                                <optgroup label='เลือกชั้นปี' >");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["class"] + "'  >" + _dr["class"] + "</option>");
            }
            _string.Append(@"</optgroup>");
            _string.Append(@"</select>");


            //            _string.Append(@"   <select name='selClassYear' class='form-control ddlClassYear selectpicker' title='ทุกชั้นปี'  " + _disbeleConditionClassYear + @" multiple>
            //                                            <optgroup label='เลือกชั้นปี' >");

            //                _string.Append(@"<option value='a'  >a-ทัน</option>");
            //                _string.Append(@"<option value='b'  >b-ไม่ทัน</option>");
            //            _string.Append(@"</optgroup>");
            //            _string.Append(@"</select>");

        }
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-04
    /// Perpose: แสดงรายการข้อมูลคณะ
    /// Method : getListFacultyPicker
    /// Sample : N/A
    /// </summary>
    public static string getListFacultyPicker(string _disbeleConditionFaculty)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListFaculty("MU-01");
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append("<select name='selFaculty' class='form-control ddlFaculty  selectpicker' title='ทุกคณะ' " + _disbeleConditionFaculty + @"  multiple>");
            _string.Append("<optgroup label='เลือกคณะ' >");

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "' >" + _dr["facultyCode"] + " - " + _dr["nameTh"] + "</option>");

            }
            _string.Append(@"</optgroup>");
            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-01-17
    /// Perpose: แสดงรายการข้อมูลปีการศึกษา
    /// Method : getListAcaYearWithBlankChoose
    /// Sample : N/A
    /// </summary>
    public static string getListAcaYearWithBlankChoose(string _acaYear)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListAcaYear();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlAcaYear'>
                                 ปีการศึกษา</label>
                                 <select class='form-control ddlAcaYear' >");
            _string.Append(@"<option value=''   >ทุกปีการศึกษา</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_acaYear == _dr["acaYear"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["acaYear"] + "'  " + _selectIndex + "  >" + _dr["acaYear"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-01-17
    /// Perpose: แสดงรายการข้อมูลภาคการศึกษา
    /// Method : getListSemesterWithBlankChoose
    /// Sample : N/A
    /// </summary>
    public static string getListSemesterWithBlankChoose(string _semester)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSemester();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlSemester'>
                                 ภาคการศึกษา</label>
                                 <select class='form-control ddlSemester' >");
            _string.Append(@"<option value=''  >ทุกภาคการศึกษา</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_semester == _dr["semester"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["semester"] + "' " + _selectIndex + "  >" + _dr["semester"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-05-14
    /// Perpose: แสดงรายการข้อมูลปีศึกษา
    /// Method : getListStudyYear
    /// Sample : N/A
    /// </summary>
    public static string getListStudyYear()
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListClassYear();
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@" <label for='ddlFaculty'>
                                 ชั้นปี</label>
                                 <select class='form-control ddlStudyYear' >");
            _string.Append("<option value=''>ทุกชั้นปี</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["class"] + "'   >" + _dr["class"] + "</option>");
            }
            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-06-11
    /// Perpose: แสดงรายการข้อมูล SubIndicator ใน Dropdownlist
    /// Method : getListDdlSubIndicator
    /// Sample : N/A
    /// </summary>
    public static string getListDdlSubIndicator(string _indicatorId, string _subIndicatorId, string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSubIndicator(_indicatorId, _facultyId);
        string _selectIndex = "";
        _string.Append(@" <label for='ddlSubIndicator'>
                                 ตัวชี้วัดย่อย</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlSubIndicator' > ");
        if (_ds.Tables[0].Rows.Count > 0)
        {


            _string.Append(" <option value=''>กรุณาเลือก</option> ");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                if (_subIndicatorId == _dr["id"].ToString())
                {
                    _selectIndex = " selected = 'selected' ";
                }
                else
                {
                    _selectIndex = "";
                }
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["nameEn"] + " - " + _dr["nameTh"] + "</option>");

            }


        }
        else
        {
            _string.Append(" <option value='0'>ไม่มีตัวชี้วัดย่อย</option> ");
        }
        _string.Append(@"</select>");
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-07-15
    /// Perpose: 
    /// Method : getListStudentRegistPublicEvent
    /// Sample : N/A
    /// </summary>
    public static string getListStudentRegistPublicEvent(string _projectId, string _projectNameTh)
    {
        StringBuilder _string = new StringBuilder();
        string _htmlHeader = "";
        _htmlHeader += @" <h2 style='padding-top:25px;'>ข้อมูลสมัครออนไลน์ของนักศึกษา <small style='padding-top:25px;color:gray;'>" + _projectNameTh + @"</small></h2>
                           <hr> <div class='row'>
                             <div class='form-group col-xs-12'>
                                 " + getListSection(_projectId, "") + @"
                             </div>
                          </div>" + getListStudentRegistPublicEventBySection(_projectId, "", "0");
        _string.Append(_htmlHeader);
        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-07-15
    /// Perpose: 
    /// Method : getListStudentRegistPublicEventBySection
    /// Sample : N/A
    /// </summary>
    public static string getListStudentRegistPublicEventBySection(string _projectId, string _sectionId, string _btnHide)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudentRegisOnline(_projectId, _sectionId);
        int _count = _ds.Tables[0].Rows.Count;
        string _htmlHeader = "";
        string _htmlBody = "";
        string _studentCode = "";
        string _titleName = "";
        string _firstName = "";
        string _lastName = "";
        string _facultyNameTh = "";
        string _programNameTh = "";
        string _regisDate = "";
        string _regisTime = "";
        string _projectSectionNameTh = "";
        string _class = "";
        string _phone = "";
        string _paidStatus = "";
        string _paidDate = "";
        string _paidAmount = "";
        string _eMail = "";
        string _stsProjectIsQRPayment = "";
        int _i = 1;

        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _projectSectionNameTh = _dr["projectSectionNameTh"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _titleName = _dr["thTitleFullName"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _regisDate = _dr["regisDate"].ToString();
                _regisTime = _dr["regisTime"].ToString();
                _class = _dr["class"].ToString();
                _phone = _dr["phone"].ToString();
                _paidStatus = _dr["paidStatus"].ToString();
                _paidDate = _dr["paidDate"].ToString();
                _paidAmount = _dr["paidAmount"].ToString();
                _paidAmount = String.Format("{0:F2}", Convert.ToDouble(_paidAmount));
                _eMail = _dr["emailEProfile"].ToString();
                _stsProjectIsQRPayment = _dr["stsProjectIsQRPayment"].ToString();
                _htmlBody += @"<tr >
                                     <td  > " + _i.ToString() + @" </td>
                                     <td class='text-center'>&nbsp;" + _regisDate + @" </td>
                                     <td class='text-center'>&nbsp;" + _regisTime + @" </td>
                                     <td > " + _projectSectionNameTh + @" </td>
                                     <td > " + _studentCode + @" </td>
                                     <td > " + _titleName + @" </td>
                                     <td > " + _firstName + @" </td>
                                     <td > " + _lastName + @" </td>
                                     <td > " + _facultyNameTh + @" </td>
                                     <td > " + _programNameTh + @" </td>
                                     <td class='text-center'> " + _class + @" </td>
                                     <td >&nbsp;" + _phone + @"</td>
                                     <td >" + _eMail + @"</td>";
                if (_stsProjectIsQRPayment == "Y")
                {
                    _htmlBody += @"<td align='right'>" + _paidAmount + @"</td>
                                     <td align='center'>" + _paidStatus + @"</td>
                                     <td align='center'>&nbsp;" + _paidDate + @"</td>";
                }
                _htmlBody += @" </tr>";

                _i++;
            }
        }

        _htmlHeader += @"<div class='divStdRegisOnline'> <table id='tblStdRegistPublicEvent' class='table table-bordered' >
                          <thead>
                            <tr  >
                                <th style = 'background-color:#eefe90;'>ลำดับ</th>
                                <th style = 'background-color:#eefe90;'>วันที่สมัคร</th>
                                <th style = 'background-color:#eefe90;'>เวลาที่สมัคร</th>
                                <th style = 'background-color:#eefe90;'>ชื่อ Section</th>
                                <th style = 'background-color:#eefe90;'>รหัสนักศึกษา</th>
                                <th style = 'background-color:#eefe90;'>คำนำหน้า</th>
                                <th style = 'background-color:#eefe90;'>ชื่อ</th>
                                <th style = 'background-color:#eefe90;'>นามสกุล</th>
                                <th style = 'background-color:#eefe90;'>ชื่อคณะ/วิทยาลัย</th>
                                <th style = 'background-color:#eefe90;'>ชื่อหลักสูตร</th>
                                <th style = 'background-color:#eefe90;'>ชั้นปี</th>
                                <th style = 'background-color:#eefe90;'>เบอร์โทรศัพท์</th>
                                <th style = 'background-color:#eefe90;'>อีเมล์</th>";
        if (_stsProjectIsQRPayment == "Y")
        {
            _htmlHeader += @"   <th style = 'background-color:#eefe90;'>ยอดเงินที่ชำระเงิน</th>
                                <th style = 'background-color:#eefe90;'>สถานะการชำระเงิน</th>
                                <th style = 'background-color:#eefe90;'>วันที่ชำระเงิน</th>";
        }
        _htmlHeader += @"      </tr>
                          </thead>
                          <tbody >";
        _htmlBody += @"      </tbody>
                             </table>
                             <center>";

        if (_btnHide == "0")
        {
            _htmlBody += @"      <div class='row'>
                                 <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                                 <button type='button' class='btn btn-success btn-md btnExportExcel glyphicon glyphicon-file' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' > ใบเซนต์ชื่อ</button> </th>
                                 </div>";
        }
        _htmlBody += @"    </div> ";
        _string.Append(_htmlHeader + _htmlBody);
        return _string.ToString();



    }


    public static string getListFileUploadType()
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListFileUploadType();
        string _selectIndex = "";
        _string.Append(@" <label for='ddlTypeFileUpload'>
                                 ประเภทของรูป</label> <span style='color:Red;font-weight:bold;'>*</span>
                                 <select class='form-control ddlTypeFileUpload' > ");
        if (_ds.Tables[0].Rows.Count > 0)
        {


            _string.Append(" <option value=''>กรุณาเลือก</option> ");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["nameTh"] + "</option>");

            }


        }
        else
        {
            _string.Append(" <option value='0'>ไม่มีตัวชี้วัดย่อย</option> ");
        }
        _string.Append(@"</select>");
        return _string.ToString();
    }



    public static string getProjectId(string _username)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getProjectId(_username);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(_dr["id"]);

            }
        }

        return _string.ToString();
    }




    public static string getlistProjectAll(string _ddlAcaYear, string _ddlSemester, string _ddlFaculty, string _projectName)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProject(_ddlFaculty, _ddlAcaYear, _ddlSemester, _projectName, "");
        DataTable dt = new DataTable();
        _ds.Merge(dt);
        StringBuilder JsonString = new StringBuilder();
        if (_ds != null && _ds.Tables[0].Rows.Count > 0)
        {
            JsonString.Append("[");
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                JsonString.Append("{");
                for (int j = 0; j < _ds.Tables[0].Columns.Count; j++)
                {
                    if (j < _ds.Tables[0].Columns.Count - 1)
                    {
                        JsonString.Append("\"" + _ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + _ds.Tables[0].Rows[i][j].ToString() + "\",");
                    }
                    else if (j == _ds.Tables[0].Columns.Count - 1)
                    {
                        JsonString.Append("\"" + _ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + _ds.Tables[0].Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == _ds.Tables[0].Rows.Count - 1)
                {
                    JsonString.Append("}");
                }
                else
                {
                    JsonString.Append("},");
                }
            }
            JsonString.Append("]");
            return JsonString.ToString();
        }
        else
        {
            return null;
        }
    }

    public static string getListSectionList(string _projectId)
    {
        StringBuilder _string = new StringBuilder();
        string _projectNameTh = "";
        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectNameTh = _dr["nameTh"].ToString();
            }
        }


        _string.Append(@"   <div > <h2 class='page-header'>รายชื่อนักศึกษาทั้งหมดของโครงการ:" + _projectNameTh + "</h2>");

        _string.Append(@"<div class='row'>
                         <div class='form-group col-xs-12 text-center'>
                     <button type='button' class='btn btn-warning btn-md glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button> 

                     <button type='button' class='btn btn-primary btn-md btnAddStudentOnly glyphicon glyphicon-plus' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษารายบุคคล</button>
                     <button type='button' class='btn btn-primary btn-md btnAddStudentExcel glyphicon glyphicon-file' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> เพิ่มนักศึกษาแบบไฟล์ Excel</button>
                     <button type='button' class='btn btn-danger btn-md  btnSetCancelStdRegistByCheckBox glyphicon glyphicon-trash' data-projectid='" + _projectId + "' data-projectnameth='" + _projectNameTh + @"'> ลบรายการนักศึกษา</button>
             
                     
                    </div></div></br>");


        _string.Append(@"   </div>");
        _ds = ActDB.getListSection(_projectId, "");
        _count = _ds.Tables[0].Rows.Count;
        string _sectionNameTh = "";
        string _startDateTh = "";
        string _endDateTh = "";
        string _countStdRegist = "";
        string _sectionId = "";

        _string.Append(@"<table class='table table-bordered table-hover '>
                          <thead>
                            <tr class='bg-info'>
                              <th scope='col' class='text-center'>ลำดับ</th>
                              <th scope='col' class='text-center'>ชื่อ Section</th>
                              <th scope='col' class='text-center'>วันที่เริ่มการจัดกิจกรรม</th>
                              <th scope='col' class='text-center'>วันที่สิ้นสุดการจัดกิจกรรม</th>
                              <th scope='col' class='text-center'>จำนวนนศ.เข้าร่วม(คน)</th>
                              <th scope='col' class='text-center'>Export Excel</th>
                            </tr>
                          </thead>");
        _i = 1;
        if (_count > 0)
        {
            _string.Append("<tbody>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _sectionId = _dr["id"].ToString();
                _sectionNameTh = _dr["sectionNameTh"].ToString();
                _startDateTh = _dr["startDateTh"].ToString();
                _endDateTh = _dr["endDateTh"].ToString();
                _countStdRegist = _dr["countStdRegist"].ToString();
                _string.Append(@"<tbody>
                          <tr style='cursor:pointer;' >
                              <th scope='row'  class='text-center'>" + _i.ToString() + @"</th>
                              <td class='btnGetListStdInSection' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' >" + _sectionNameTh + @"</td>
                              <td class='btnGetListStdInSection' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' >" + _startDateTh + @"</td>
                              <td class='btnGetListStdInSection' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' >" + _endDateTh + @"</td>
                              <td class='btnGetListStdInSection' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' align='right'><font color='#025ebc'>" + _countStdRegist + @"</font></td>
                              <td align='center'><button type='button' class='btn btn-sm btn-success btn-md btnExportExcelStudentInSection glyphicon glyphicon-file' data-projectid='" + _projectId + "' data-sectionid='" + _sectionId + @"' > ดาวน์โหลด</button></td>
                              
                          </tr>");
                _i++;
            }
            _string.Append("</tbody>");
        }


        _string.Append(" </table>");
        _string.Append("<div id='divStdInSection'></div>");
        return _string.ToString();
    }


    public static string getDataStatusPassMuxTodisplaySelectPicker(string _sectionid)
    {
        StringBuilder _string = new StringBuilder();
        string _statusPassMux = "";
        DataSet _ds = ActDB.getListSectionBySectionId(_sectionid);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append("[");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _statusPassMux = _dr["statusPassMux"].ToString();
                _string.Append(_statusPassMux);
            }
            _string.Append("]");
        }
        return _string.ToString();
    }


    public static string getDataStatusEnrollmentMuxTodisplaySelectPicker(string _sectionid)
    {
        StringBuilder _string = new StringBuilder();
        string _statusEnrollmentMux = "";
        DataSet _ds = ActDB.getListSectionBySectionId(_sectionid);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append("[");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _statusEnrollmentMux = _dr["statusEnrollmentMux"].ToString();
                _string.Append(_statusEnrollmentMux);
            }
            _string.Append("]");
        }
        return _string.ToString();
    }

    public static string getListStatusRequestDoc()
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@" <label for='ddlStatusRequest'>
                                 สถานะ Request</label>
                                 <select class='form-control ddlStatusRequest' >");
        _string.Append("<option value=''  >ทั้งหมด</option>");
        _string.Append("<option value='Y'  >ร้องขอ</option>");
        _string.Append("<option value='N'  >ไม่ร้องขอ</option>");
        _string.Append("</select>");
        return _string.ToString();

    }


    public static string getListDdlRequestReasonPicker(string _disableSelectPicker)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRequestReason();
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append("<select name='selRequestReason' class='form-control ddlRequestReason  selectpicker' title='กรุณาเลือก' multiple " + _disableSelectPicker + ">");
            _string.Append("<optgroup label='กรุณาเลือก' >");

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "' >" + _dr["nameTh"] + "</option>");

            }
            _string.Append(@"</optgroup>");
            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    public static string panelManageClub(string _facultyId,string _username)
    {
        StringBuilder _string = new StringBuilder();

        _string.Append("<h1 class='page-header'>บริหารจัดการข้อมูลองค์กร/ชมรม </h1>");

        _string.Append(@"<ul class='nav nav-tabs' style='font-size:16px;' >
                          <li role = 'presentation' class='active'><a data-toggle='tab' href='#divClub1'> ข้อมูลองค์กรนักศึกษา/ชมรม</a></li>
                          
                         ");
        //if ((_username == "tareenichar.lee" || _username == "jate.khr") )
        //{
            _string.Append(@" 
                          <li role = 'presentation' ><a data-toggle='tab' href='#divClub2'> จัดการข้อมูลผู้เข้าองค์กรนักศึกษา/ชมรม</a>
                          </li>");
        //}
        _string.Append("</ul>");

        _string.Append(" <div class='tab-content'>");


        _string.Append("        <div id='divClub1' class='tab-pane fade in active'>");
        _string.Append("           <div  class='row form-group'>");
        _string.Append("               <div  class='divMainClub1 '>" + getListClubAndManage(_facultyId, "") + "</div>");
        _string.Append("           </div>");
        _string.Append("        </div>");

        _string.Append("        <div id='divClub2' class='tab-pane fade'>");
        _string.Append("           <div  class='row form-group'>");
        _string.Append("                <div  class='divMainClub2 '>" + loadPanelManageStudentInClub(_facultyId) + "</div>");
        _string.Append("           </div>");
        _string.Append("        </div>");




        _string.Append("</div>");



        _string.Append("  </div>");

        _string.Append("</div>");



        //_string.Append(@"         <div class='row '>
        //                                <div class=' col-xs-12 text-center'>
        //                                     <button type='button' class='btn btn-info btn-md btnSearchRptStd1 glyphicon glyphicon-search'> ค้นหา</button>
        //                                </div>
        //                          </div>");



        //_string.Append("        <div id='divClub2' class='tab-pane fade'>");
        //_string.Append("           <div  class='row form-group'>");
        //_string.Append("                <div  class='col-xs-2'>");
        ////_string.Append(ActUI.getListStudentYear());
        //_string.Append("                </div>");
        //_string.Append("                <div  class='col-xs-5'>");
        ////_string.Append(ActUI.getListFaculty(_facultyId, ""));
        //_string.Append("                </div>");
        //_string.Append("                <div  class='col-xs-5'>");
        //_string.Append("                <div class='divProgram'>");
        ////_string.Append(ActUI.getListProgram(_facultyId));
        //_string.Append("                </div>");
        //_string.Append("                </div>");
        //_string.Append("           </div>");
        //_string.Append(@"         <div class='row '>
        //                                <div class=' col-xs-12 text-center'>
        //                                     <button type='button' class='btn btn-info btn-md btnSearchRptStd2 glyphicon glyphicon-search'> ค้นหา</button>
        //                                </div>
        //                          </div>");


        return _string.ToString();
    }

    public static string loadPanelManageStudentInClub(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div class='row'>

                              <div class='form-group col-xs-6 '>
                                <label for='' style='font-size:16px;'>
                                          ชมรม</label>
                                  <span style = 'color: Red; font-weight: bold;' > *</span>
                                   " + getListDDlClub(_facultyId) + @"
                              </div>
                              <div class='form-group col-xs-3 '>
                                   " + getListAcaYear("","") + @"
                              </div>
                              <div class='form-group col-xs-3 '>
                                   " + getListSemester("00") + @"
                              </div>

                        </div>
                        <div class='row'>
                              <div class='form-group col-xs-3 '>
                                   " + getListPosition("1") + @"
                              </div>

                              <div class='form-group col-xs-2 '>
                                  <label for=''>
                                          รหัสนักศึกษา</label>
                                  <span style = 'color: Red; font-weight: bold;' > *</span>
                                  <input type='number' class='form-control txtStudentCode' maxlength='7' placeholder='รหัสนักศึกษา' />
                              </div>
                              
                              <div class='form-group col-xs-1 '>
                                   <label for=''>
                                          &nbsp;</label>
                                   <button type='button' class='btn btn-primary glyphicon glyphicon-plus btnAddNewMember' > เพิ่ม</button>
                              </div>

                              <div class='form-group col-xs-4 '>



                                    <form action='' method='post' target='uploadframeStudentClubExcel' id='frmUploadStdRegistExcel'>
                                      <lable for='' style='font-weight:bold;'>กรุณาเลือกไฟล์ Excel &nbsp;<span style='color:Red;font-weight:bold;'>*</span> 
                            &nbsp; <a href='../../file/templateStudentList.xlsx'>Download Template Excel File คลิก</a>
                                      </lable>
                                           <input name='excelStdRegistUpload' id='uploadStudentClub'  type='file' class='file' data-preview-file-type='text'  style='padding-top:10px;'> 
                                   </form>


                                   <iframe id='uploadframeStudentClubExcel' name='uploadframeStudentClubExcel'  style='display: none;'></iframe>
                               </div>

                               <div class='form-group col-xs-2 text-left' style='padding-top:20px;'>
                                <label for=''>
                                          &nbsp;</label>
                                <button type='button' class='btn btn-success glyphicon glyphicon-file btnUploadNewMember' > อัพโหลด</button>
                                </div>
                        </div>

                        <div class='row text-center'>
                            <div id='divPanelStdInClubList'></div>                         
                        </div>");
        return _string.ToString();
    }


    public static string getListClubAndManage(string _facultyId,string _clubId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListClubById(_clubId);
        string _clubNameTh = "";
        string _clubNameEn = "";
        string _descriptionNameTh = "";
        string _descriptionNameEn = "";
        string _place = "";
        string _phone = "";
        string _email = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _clubNameTh  = _dr["nameTh"].ToString();
                _clubNameEn  = _dr["nameEn"].ToString();
                _descriptionNameTh = _dr["descriptionNameTh"].ToString();
                _descriptionNameEn = _dr["descriptionNameEn"].ToString();
                _place = _dr["place"].ToString();
                _phone = _dr["phone"].ToString();
                _email = _dr["email"].ToString();
                
            }
        }


        _string.Append(@"<div class='form-group col-xs-6 '>
                               <label for=''>ชื่อองค์กรนักศึกษา/ชมรมภาษาไทย <span style='color:red;font-weight:bold;'>*</span></label> 
                               <input type='text' class='form-control txtClubNameTh' placeholder='ชื่อองค์กรนักศึกษา/ชมรมภาษาไทย' value='" + _clubNameTh + @"'/> 
                         </div>");
        _string.Append(@"<div class='form-group col-xs-6 '>
                               <label for=''>ชื่อองค์กรนักศึกษา/ชมรมภาษาอังกฤษ <span style='color:red;font-weight:bold;'>*</span></label> 
                               <input type='text' class='form-control txtClubNameEn' placeholder='ชื่อองค์กรนักศึกษา/ชมรมภาษาอังกฤษ' value='" + _clubNameEn + @"' /> 
                         </div>");
        _string.Append(@"<div class='form-group col-xs-6 '>
                               <label for=''>รายละเอียดองค์กรนักศึกษา/ชมรมภาษาไทย</label> 
                               <textarea class='form-control txtClubDetailTh' rows='2' >" + _descriptionNameTh + @"</textarea>
                         </div>");
        _string.Append(@"<div class='form-group col-xs-6 '>
                               <label for=''>รายละเอียดองค์กรนักศึกษา/ชมรมภาษาอังกฤษ</label> 
                               <textarea class='form-control txtClubDetailEn' rows='2' >" + _descriptionNameEn + @"</textarea>
                        </div>");
        _string.Append(@"<div class='form-group col-xs-4 '>
                               <label for=''>สถานที่</label> 
                               <input type='text' class='form-control txtPlace' placeholder='สถานที่ตั้งชมรม' value='" + _place + @"'/> 
                         </div>");
        _string.Append(@"<div class='form-group col-xs-4 '>
                               <label for=''>เบอร์โทรศัพท์</label> 
                               <input type='text' class='form-control txtPhone' placeholder='เบอร์โทรศัพท์ของชมรม' value='" + _phone + @"'/> 
                         </div>");
        _string.Append(@"<div class='form-group col-xs-4 '>
                               <label for=''>อีเมล์</label> 
                               <input type='text' class='form-control txtMail' placeholder='อีเมล์สำหรับไว้ติดต่อกับชมรม' value='" + _email + @"'/> 
                         </div>");

        if (_clubId == "")
        {
            _string.Append(@"<div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-success btn-sm btnAddNewClub glyphicon glyphicon-plus'> เพิ่มชมรมใหม่</button>
                         </div>");
        
            _string.Append("<div id='divListClub'>" + getListClub(_facultyId) + "</div>");
        }

        return _string.ToString();
    }

    public static string getListDDlClub(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListClub(_facultyId);
        _string.Append(@"  <select class='form-control ddlClub'  >
                                   <option value=''>กรุณาเลือก</option>");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "'   >" + _dr["clubName"] + "</option>");

            }

            
        }
        _string.Append("  </select>");
        return _string.ToString();
    }

    public static string getListClub(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListClub(_facultyId);
        int _i = 0;
        _string.Append(@"   <div>
                                <table id='tblListClub'  class='table table-striped'>
                                <caption><h4>รายการชมรมทั้งหมด</h4></caption>
                                <thead>
                                 <tr >
                                    <th style='width:25px; ' class='text-center '>
                                    ลำดับ
                                    </th >
                                    <th style='width:320px;' class='text-center'>
                                    ชื่อองค์กรนักศึกษา/ชมรม
                                    </th>
                                    <th style='width:200px;' class='text-center'>
                                    สถานที่
                                    </th>
                                    <th style='width:100px;' class='text-center'>
                                   เบอร์โทรศัพท์
                                    </th>
                                    <th style='width:100px;'  class='text-center'>
                                    อีเมล์
                                    </th>
                                    <th  class='text-center' >
                                    action
                                    </th>
                                    </tr>
                                    </thead>");

        if (_ds.Tables[0].Rows.Count > 0)
        {
        
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"   <tr>
                                    <td>
                                    "+(_i+1).ToString()+ @"
                                    </td>
                                    <td>
                                    " + _dr["nameTh"] + @"
                                    </td>
                                    <td>
                                    " + _dr["place"] + @"
                                    </td>
                                    <td>
                                    " + _dr["phone"] + @"
                                    </td>
                                    <td>
                                    " + _dr["email"] + @"
                                    </td>
                                    <td  class='text-center'>
<button type='button' class='btn btn-warning btn-sm glyphicon glyphicon-pencil' onclick=dialogEditClub('"+ _dr["id"] + @"');> แก้ไข</button>&nbsp;
<button type='button' data-clubid = '" + _dr["id"] + @"' class='btn btn-danger btn-sm btnDelClub glyphicon glyphicon-trash'> ยกเลิก</button>
                                    </td>
                                    </tr>
                                    ");
                _i++;
            }

        }
        _string.Append("  </table> </div>");



  

        return _string.ToString();
    }


    public static string dialogEditClub(string _facultyId,string _clubId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div id='divEditDialog'>
                              <div class='modal-dialog'>

                                <div class='modal-content'>
                                      <div class='modal-header'>
                                        <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                        <h4 class='modal-title'>แก้ไขข้อมูลชมรม </h4>
                                      </div>
                                      <div class='modal-body'>
                                        <p>
                                            "+getListClubAndManage(_facultyId, _clubId) +@"
                                        </p>
                                        <div class='row'>
                                            <div class='form-group col-xs-12 text-center'>
                                                 <button type='button' data-clubid='" + _clubId + @"'   class='btn btn-success glyphicon glyphicon-floppy-disk btnSetEditClub'> บันทึก</button>
                                            </div>
                                        </div>
                                      </div>
                                 </div>
                       </div> </div> ");
        return _string.ToString();
    }


    public static string getListStudentInClubByClubId(string _clubId)
    {


        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudentInClub(_clubId);
        int _i = 0;
        _string.Append(@" <table class='table table-border table-striped tblStudentListInClub'>
                
                <thead>
                <tr>
                <th class='col-sm-1 text-center'>
                    ลำดับ
                </th>
                <th class='col-sm-1 text-center'>
                    ปีการศึกษา
                </th>
                <th class='col-sm-1 text-center'>
                    รหัสนักศึกษา
                </th>
                <th class='col-sm-2 text-center'>
                    ชื่อ-นามสกุล
                </th>
                <th class='col-sm-2 text-center'>
                    สถานะ
                </th>
                <th class='col-sm-4 text-center'>
                    ชื่อคณะ
                </th>

                <th class='col-sm-1 text-center'>
                    action
                </th>
                </tr>
                </thead> ");

        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

             
                _string.Append(@"
               
                          <tr >
                          <td >
                                         " + (_i + 1).ToString() + @"
                           </td>
                           <td class='text-center'>
                                         " + _dr["acaYearDisplay"] + @"
                           </td>
                           <td >
                                         " + _dr["studentCode"] + @"
                           </td>
                           <td class='text-left'>
                                         " + _dr["studentNameTh"] + " " + @"
                           </td>
                           <td class='text-left'>
                                         " + _dr["positionNameTh"] + " " + @"
                           </td>
                            <td class='text-left'>
                                         " + _dr["facNameTh"] + @"
                            </td>

    
                             <td >
                                  <a style='cursor:pointer;'><i class='glyphicon glyphicon-trash btnCancelStdInClub'  data-id='"+ _dr["id"].ToString() + @"'></i></a>
      
                             </td>

                         </tr> ");

                _i++;

            }
        }
        else
        {
            _string.Append(" <tr ><td class='text-center' colspan='6'>ไม่พบข้อมูลรายชื่อนักศึกษาในชมรมนี้</td></tr>");
        }

        _string.Append(" </table>");



        return _string.ToString();

    }


    public static string getListDetailForSendmail(string projectId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListDetailForSendmail(projectId);
        int _countRecord = _ds.Tables[0].Rows.Count;
        if (_countRecord > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _string.Append(@"  

                          <div class='form-group row'>
                            <label   class='col-sm-2 col-form-label'>ภาค/ปีการศึกษา</label>
                            <div class='col-sm-10'>
                              <input type='text' id='txtAcaYear'  class='form-control' value='" + _dr["semester"] + "/"+_dr["acaYear"] + @"' disabled>
                            </div>
                          </div>

                          <div class='form-group row'>
                            <label   class='col-sm-2 col-form-label'>ชื่อโครงการภาษาไทย</label>
                            <div class='col-sm-10'>
                              <input type='text' id='txtProjectNameTh'  class='form-control' value='" + _dr["nameTh"] + @"' disabled>
                            </div>
                          </div>

                          <div class='form-group row'>
                            <label   class='col-sm-2 col-form-label'>ส่วนงานผู้จัด</label>
                            <div class='col-sm-10'>
                              <input type='text' id='txtInstituteNameTh'   class='form-control' value='" + _dr["instituteNameTh"] + @"' disabled>
                            </div>
                          </div>

                          <div class='form-group row'>
                            <label   class='col-sm-2 col-form-label'>วันที่สร้างโครงการ</label>
                            <div class='col-sm-10'>
                              <input type='text' id='txtCreateDateTh'   class='form-control' value='" + _dr["createDateTh"] + @"' disabled>
                            </div>
                          </div>

                          <div class='form-group row'>
                            <label   class='col-sm-2 col-form-label'>อีเมลผู้สร้างโครงการ</label>
                            <div class='col-sm-10'>
                              <input type='text' id='txtCreatedBy'    class='form-control' value='" + _dr["createdBy"] + @"' disabled>
                            </div>
                          </div>

                          <div class='form-group row'>
                            <label for='txtRemark' class='col-sm-2 col-form-label'>Remark <span class='text-danger' >*</span></label>
                            <div class='col-sm-10'>
                              <input type='text'  class='form-control' id='txtRemark' placeholder='เนื้อหาเพิ่มเติมที่แจ้งในอีเมล'>
                            </div>
                          </div>");
              
            }
        }

        _string.Append(@"</table></div>");
        return _string.ToString();
    }

    public static string getListYearFillterReport()
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListYearFillterReport();
        _string.Append("<div class='row'>");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@"<div class='form-group col-xs-6'>");
            _string.Append(@" <label for='ddlYearReport'>
                                 ปีปฏิทิน</label>
                                 <select id='ddlYearReport' class='form-control ddlYearReport btnChangeFac' >");
            _string.Append("<option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["year"] + "'   >" + _dr["year"] + "</option>");

            }
            _string.Append("</select>");
            _string.Append("</div>");
        }

        DataSet _ds2 = ActDB.getListMonthFillterReport();
        if (_ds2.Tables[0].Rows.Count > 0)
        {
            _string.Append(@"<div class='form-group col-xs-6'>");
            _string.Append(@" <label for='ddlMonthReport'>
                                 เดือน</label>
                                 <select id='ddlMonthReport' class='form-control ddlMonthReport btnChangeFac' >");
            _string.Append("<option value=''>กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds2.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["monthValue"] + "'   >" + _dr["monthNameTh"] + "</option>");

            }
            _string.Append("</select>");
            _string.Append("</div>");
        }
        _string.Append("</div>");
        return _string.ToString();
    }




}