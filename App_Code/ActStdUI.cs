using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.Drawing;
using System.IO;
using RestSharp;

/// <summary>
/// Summary description for ActStdUI
/// </summary>
public class ActStdUI
{
    public ActStdUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-05
    /// Perpose: แสดงเมนูด้านซ้ายมือของเจ้าหน้าที่ Bar Menu
    /// Method : loadBarMenuStd
    /// Sample : N/A
    /// </summary>
    public static string loadBarMenuStd(string _username, string _facultyCodePermission, string _facultyNamePermission, string _fullname)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"  <nav class='navbar navbar-inverse navbar-fixed-top'>
                           <div class='container-fluid'>
     
                             <div class='navbar-header'>
                                <a class='navbar-brand' href='#'>Mahidol Activity Transcript</a>
                             </div>
                             <ul class='nav navbar-nav'>
                               <li class='active'><a href='#'>Home</a></li>

                             </ul>
                             <ul class='nav navbar-nav navbar-right'>
                               <li><a href='#'><span class='glyphicon glyphicon-user'></span> " + _fullname + @"</a></li>
                               <li><a href='#' class='btnLogout'><span class='glyphicon glyphicon-log-in '></span> Logout</a></li>
                             </ul>
                          </div>
                         
                        </nav> </br></br>  ");
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-05
    /// Perpose: แสดงเมนูด้านซ้ายมือของนักศึกษาที่ Side bar Menu
    /// Method : loadSidebarMenuStd
    /// Sample : N/A
    /// </summary>
    public static string loadSidebarMenuStd()
    {

        StringBuilder _string = new StringBuilder();
        string _menu1 = @" <a href='#' class='list-group-item btnHome'>
                                    <i class='glyphicon glyphicon-home '></i> หน้าแรก (ข้อมูลนักศึกษา)
                           </a>";
        string _menu2 = @" <a href='#' class='list-group-item btnSearchActivity'>
                                    <i class='glyphicon glyphicon-search'></i> ค้นหากิจกรรม
                                </a>";
        string _menu3 = @" <a href='#' class='list-group-item btnGetListActivitiesByStudent'>
                                    <i class='glyphicon glyphicon-stats'></i> รายการกิจกรรมที่เข้าร่วม
                                </a>";
        string _menu4 = @" <a href='#' class='list-group-item btnLoadApprovePage'>
                                    <i class='glyphicon glyphicon-bitcoin'></i> ข้อมูลกิจกรรมเพื่อยืนกู้ กยศ./กรอ.
                                </a>";
        string _menu5 = @" <a href='#' class='list-group-item btnLoadContractUs'>
                                    <i class='glyphicon glyphicon-phone-alt'></i> ติดต่อเรา
                                </a>";

        _string.Append(@"  </br></br></br>
                             <div class='list-group'>
                                <span class='list-group-item'>
                                    <b>MAIN MENU</b>
                                    <span class='pull-right' id='slide-submenu'>
                                    </span>
                                </span>
                                " + _menu1 + @"
                                " + _menu2 + @"
                                " + _menu3 + @"
                                " + _menu4 + @"
                                " + _menu5 + @"
                                <a class='list-group-item' style='height:100px;'>
                                </a>
                            </div>  ");
        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-28
    /// Perpose: แสดงเมนู Profile ของนักศึกษา
    /// Method : getListStudentProfile
    /// Sample : N/A
    /// </summary>
    public static string getListStudentProfile(string _username)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudentProfile(_username);
        string _studentCode = "";
        string _firstName = "";
        string _lastName = "";
        string _idCard = "";
        string _birthDateTh = "";
        string _perBloodTypeName = "";
        string _phoneNumberCurrent = "";
        string _mobileNumberCurrent = "";
        string _email = "";
        string _facNameTh = "";
        string _programNameTh = "";
        string _noCurrent = "";
        string _soiCurrent = "";
        string _roadCurrent = "";
        string _thSubdistrictNameCurrent = "";
        string _thDistrictNameCurrent = "";
        string _thPlaceNameCurrent = "";
        string _zipCodeDistrictCurrent = "";
        string _firstNameParent = "";
        string _lastNameParent = "";
        string _relationshipNameTH = "";
        string _phoneNumberCurrentParent = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _idCard = _dr["idCard"].ToString();
                _birthDateTh = _dr["birthDateTh"].ToString();
                _perBloodTypeName = _dr["perBloodTypeName"].ToString();
                _phoneNumberCurrent = _dr["phoneNumberCurrent"].ToString();
                _mobileNumberCurrent = _dr["mobileNumberCurrent"].ToString();
                _email = _dr["email"].ToString();
                _facNameTh = _dr["facNameTh"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _noCurrent = _dr["noCurrent"].ToString();
                _soiCurrent = _dr["soiCurrent"].ToString();
                _roadCurrent = _dr["roadCurrent"].ToString();
                _thSubdistrictNameCurrent = _dr["thSubdistrictNameCurrent"].ToString();
                _thDistrictNameCurrent = _dr["thDistrictNameCurrent"].ToString();
                _thPlaceNameCurrent = _dr["thPlaceNameCurrent"].ToString();
                _zipCodeDistrictCurrent = _dr["zipCodeDistrictCurrent"].ToString();
                _firstNameParent = _dr["firstNameParent"].ToString();
                _lastNameParent = _dr["lastNameParent"].ToString();
                _relationshipNameTH = _dr["relationshipNameTH"].ToString();
                _phoneNumberCurrentParent = _dr["phoneNumberCurrentParent"].ToString();

            }


        }
        _string.Append("<div  style='font-size:15px;'>");
        _string.Append("<h2 class='page-header'>ข้อมูลส่วนตัว</h2>");
        _string.Append(@"<div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>รหัสนักศึกษา</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _studentCode + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>ชื่อ</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _firstName + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>นามสกุล</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _lastName + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>เลขที่บัตรประชาชน</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _idCard + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>วัน เดื่อน ปี เกิด</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _birthDateTh + @"
                              </div>
                              </div>  
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>หมู่โลหิต</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _perBloodTypeName + @"
                              </div>
                              </div>  
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>เบอร์โทรบ้าน</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _phoneNumberCurrent + @"
                              </div>
                              </div>  
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>เบอร์โทรศัพท์มือถือ</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _mobileNumberCurrent + @"
                              </div>
                              </div>  
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>อีเมล์</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _email + @"
                              </div>
                              </div>");

        _string.Append(" <h2 class='page-header'>ข้อมูลการศึกษา</h2>");
        _string.Append(@"<div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>คณะ/วิทยาลัย</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _facNameTh + @"
                              </div>
                              </div>

                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>หลักสูตร</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _programNameTh + @"
                              </div>
                              </div>");

        _string.Append("<h2 class='page-header'>ที่อยู่อาศัย(ปัจจุบัน)</h2>");
        _string.Append(@"<div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>บ้านเลขที่</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _noCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>ซอย</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _soiCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>ถนน</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _roadCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>แขวง/ตำบล</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _thSubdistrictNameCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>เขต/อำเภอ</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _thDistrictNameCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>จังหวัด</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _thPlaceNameCurrent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>รหัสไปรษณีย์</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _zipCodeDistrictCurrent + @"
                              </div>
                              </div>
                              ");

        _string.Append("<h2 class='page-header'>ข้อมูลผู้ปกครอง</h2>");
        _string.Append(@"<div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>ชื่อ</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _firstNameParent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>นามสกุล</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _lastNameParent + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>ความสัมพันธ์</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _relationshipNameTH + @"
                              </div>
                              </div>
                              <div class='row '>
                              <div class='form-group col-xs-5 text-left'>
                              <b>เบอร์โทรศัพท์(มือถือ)</b> 
                              </div>
                              <div class='form-group col-xs-7 text-left'>
                              " + _phoneNumberCurrentParent + @"
                              </div>
                              </div>
                              ");

        _string.Append(@"</div>");
        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-29
    /// Perpose: แสดงหน้าจอเงื่อนไขการค้นหากิจกรรม
    /// Method : searchActivity
    /// Sample : N/A
    /// </summary>
    public static string searchActivity(string _studentId)
    {

        StringBuilder _string = new StringBuilder();

        _string.Append(@"<div class='divSearchActShop'>
                         <h2 class='page-header'>ค้นหาข้อมูลกิจกรรม</h2>
                         <div class='panel panel-default '  style='font-size:15px;'>
                                              
                                              <div class='panel-heading'>เงื่อนไขการค้นหา</div>
                                              <div class='panel-body'>
                                                                 <div class='row'>
                                                                         <div class='form-group col-xs-12' > 
                                                                             <label for='ddlProjectType'>
                                                                             ชื่อโครงการ</label>
                                                                             <input type='text' class='form-control txtActivityName' placeholder='ชื่อโครงการ' />
                                                                          </div>
                                                                 </div>
                                                                 <div class='row'>
                                                                          <div class='form-group col-xs-3' > 
                                                                              " + ActUI.getListAcaYear("","") + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-5' > 
                                                                              " + getListProjectTypeByStudentYear(_studentId) + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-4' > 
                                                                              " + ActUI.getListProjectStatus("") + @"
                                                                          </div>
                                                                 </div>
                                                                 <div class='row'>
                                                                         <div class='form-group col-xs-12 text-center'>
                                                                            <button type='button' class='btn btn-info btn-md btnSearchProject glyphicon glyphicon-search'> ค้นหา</button>
                                                                         </div>
                                                                 </div>
                                                
                                               </div>
                                               
                          </div>
                          <div class='divResultActivity'></div>
                          </div>");

        _string.Append("<div class='divProjectDetailForShopping'></div>");
        //_string.Append(getListProjectByCondition());
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-15
    /// Perpose: แสดงข้อมูลรายการนักศึกษาที่ส่งข้อมูลกิจกรรมเพื่อยื่นกู้เงิน กยศ./กรอ.
    /// Method : getListSchStudentSendAct
    /// Sample : N/A
    /// </summary>
    public static string getListSchStudentSendAct()
    {

        StringBuilder _string = new StringBuilder();
        string _htmlBody = "";





        _htmlBody = @"                 <div class='panel-body'>
                                                                
                                                    <div class='table-responsive'>
                                                    <table id='tblListStdSchAct' class='table'>
                                                    <thead>
                                                     <tr>
                                                        <th class='col-sm-2 text-center'>
                                                        รหัสนักศึกษา
                                                        </th >
                                                        <th class='col-sm-2 text-center'>
                                                        ชื่อ
                                                        </th>
                                                        <th class='col-sm-2 text-center'>
                                                        นามสกุล
                                                        </th>
                                                        <th class='col-sm-4 text-center'>
                                                        คณะ/วิทยาลัย
                                                        </th>
                                                        <th  class='col-sm-2 text-center'>
                                                        วันที่สมัคร
                                                        </th>
                                                        </tr>
                                                         </thead>";
        DataSet _ds = ActDB.getListSchStudentSendAct();
        int _i = 1;
        string _studentCode = "", _firstName = "", _lastName = "";
        string _facultyCode = "", _facNameTh = "", _dateTh = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _facNameTh = _dr["facNameTh"].ToString();
                _dateTh = _dr["dateTh"].ToString();
                _htmlBody += @"<tr>
                                      <td class='text-center'>" + _studentCode + @"</td>
                                      <td>" + _firstName + @"</td>
                                      <td>" + _lastName + @"</td>
                                      <td>" + _facultyCode + "-" + _facNameTh + @"</td>
                                      <td class='text-center'>" + _dateTh + @"</td>
                                 </tr>
                              ";
            }
        }



        _htmlBody += @"                             </table>
                                                    </div>
                                               </div>
                                               </div>
                            <div class='divResultActivity'></div>";

        _string.Append(@"   <div >
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'><strong>รายชื่อผู้ส่งข้อมูลกิจกรรมเพื่อยื่นกู้เงิน กยศ. (เรียงข้อมูลจากการสมัครล่าสุด)</strong></h4>
                                  </div>
                                  <div class='modal-body'>
                                   " + _htmlBody + @"
                                    </p>
                                  </div>
                                
                                </div>

                              </div>
                            </div> ");

        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-29
    /// Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    /// Method : searchActivity
    /// Sample : N/A
    /// </summary>
    public static string getListActivitiesByStudent(string _studentId, string _studentCode)
    {
        StringBuilder _string = new StringBuilder();
        if (_studentCode == "")
        {
            _string.Append("ไม่พบข้อมูลที่ค้นหา");
        }
        //else
        //{
        //    _string.Append("</br><center><h3>อยู่ระหว่างดำเนินการประมวลผลข้อมูล</h3>");
        //}
        else if (Convert.ToInt32(_studentCode.Substring(0, 2)) >= 62) // เกณฑ์ใหม่ HIDEF น.ศ.ปี 62 ขึ้นไป
        {
            _string.Append(getListActivitiesStdHIDEFType1(_studentId));
        }
        else // กลุ่มนักศึกษาเก่า
        {
            _string.Append(getListActivitiesType1(_studentId));
            _string.Append("<hr>");
            _string.Append(getListActivitiesType2(_studentId));
        }
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-29
    /// Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    /// Method : searchActivity
    /// Sample : N/A
    /// </summary>
    public static string getListActivitiesType1(string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.rptGetListActivityAllByStudentId(_studentId, "0");
        int _i = 1;
        string _studentCode = "", _hourRow = "";
        string _semester = "", _acaYear = "";
        string _firstName = "", _lastName = "";
        string _htmlHeader1 = "", _htmlBody1 = "";
        string _countAct = "0", _countHours = "0";
        string _projectNameTh = "", _positionNameTh = "", _projectNameEn = "";
        string _code = "";
        string _instituteNameTh = "", _instituteNameEn = "";
        
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _semester = _dr["semester"].ToString();
                _acaYear = _dr["acaYear"].ToString();
                
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _countAct = _dr["countAct"].ToString();
                _countHours = _dr["countHour"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _positionNameTh = _dr["positionNameTh"].ToString();
                _hourRow = _dr["hourRow"].ToString();
                _code = _dr["projectCode"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _htmlBody1 += @"<tr>

                                        <td class='text-center'>
                                            " + _acaYear + "/" + _semester  + "</br><small style='color:gray;'>" + _code + @"</small>
                                        </td>
                                        <td class='text-center'>
                                            <span class='th'>" + _instituteNameTh + "</span><span class='en'>" + _instituteNameEn + @"</span>
                                        </td>

                                        <td>
                                            <span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span>
                                        </td>

                                        <td>
                                            " + _positionNameTh + @"
                                        </td>

                                        <td class='text-center'>
                                            " + _hourRow + @"
                                        </td>
                                </tr>";
                _i++;
            }
        }

        _ds = ActDB.getListStudentProfile(_studentId);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
            }
        }


                if (_studentCode != "")
        {
            _htmlHeader1 += ActReportUI.getListConditionToComplete(_studentCode.Substring(0, 2), _studentId);
        }

        _htmlHeader1 += "<h4 class='page-header'><span class='th'><b>ข้อมูลการเข้าร่วมกิจกรรม</b></span><span class='en'><b>Activity Information</b></span></h4>";

        //else
        //{
        //    _htmlBody1 += "<tr>  <td colspan='5' class='text-center'> <span class='th'>ไม่พบข้อมูล</span><span class='en'>No data</span> </td></tr>";
        //}
        string _facNameTh = "";
        string _programNameTh = "";
        string _countActAll = "0";
        string _countHoursAll = "0";
        string _countAct2 = "0";
        string _countHours2 = "0";
        string _enfirstName = "", _enlastName = "";
        string _facNameEn = "", _programNameEn = "";
        string _stsPass = "", _iconStatusPass="", _stsPassTh = "", _stsPassEn = "";
        _ds = ActDB.getListStudentProfile(_studentId);

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _enfirstName = _dr["enfirstName"].ToString();
                _enlastName = _dr["enlastName"].ToString();
                _facNameTh = _dr["facNameTh"].ToString();
                _facNameEn = _dr["facNameEn"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _programNameEn = _dr["programNameEn"].ToString();
            }
        }






        _ds = ActDB.rptGetListActivityAllByStudentId(_studentId, "1");
        //_ds = ActDB.getActivityTranscript(_studentCode, "", "", "");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _countAct2 = _dr["countAct"].ToString();
                _countHours2 = _dr["countHour"].ToString();
                //_stsPass = _dr["stsPass"].ToString();
                //_stsPassTh = _dr["stsPassTh"].ToString();
                //_stsPassEn = _dr["stsPassEn"].ToString();
            }
        }
        //if (_stsPass == "1")
        //{
        //    _iconStatusPass = "<i style='color:green;' class='glyphicon glyphicon-ok'></i>";
        //}
        //else
        //{
        //    _iconStatusPass = "<i style='color:red;' class='glyphicon glyphicon-remove'></i>";
        //    _stsPassTh = "ไม่ผ่าน";
        //    _stsPassEn = "Not Pass";
        //}
  
   
        _countActAll = (Convert.ToDouble(_countAct) + Convert.ToDouble(_countAct2)).ToString();
        _countHoursAll = (Convert.ToDouble(_countHours) + Convert.ToDouble(_countHours2)).ToString();
        _htmlHeader1 += @"<div class='row page-header'>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>ชื่อ-นามสกุล :</b> " + _firstName + " " + _lastName + @"</span>
                            <span class='en'><b>Fullname :</b> " + _enfirstName + " " + _enlastName + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>เลขประจำตัวนักศึกษา :</b> " + _studentCode + @"</span>
                            <span class='en'><b>Student Id :</b> " + _studentCode + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>คณะ :</b> " + _facNameTh + @"</span>
                            <span class='en'><b>Faculty :</b> " + _facNameEn + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>หลักสูตร :</b> " + _programNameTh + @"</span>
                            <span class='en'><b>Program :</b> " + _programNameEn + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>จำนวนกิจกรรม</b> " + _countActAll + @" <b>กิจกรรม</b></span>
                            <span class='en'><b>Amount </b> " + _countActAll + @" <b>Act.</b></span>

                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>จำนวนชั่วโมง</b> " + Convert.ToString(_countHoursAll) + @" <b>ชั่วโมง</b></span>
                            <span class='en'><b>Hour</b> " + Convert.ToString(_countHoursAll) + @" <b>hour</b></span>
                            </div>


                         </div>";
                            // < div class='form-group col-xs-6' > 
                            //<span class='th'><b>สถานะการเข้าร่วมกิจกรรม :  "+_iconStatusPass + " " + _stsPassTh + @"</b></span>
                            //<span class='en'><b>Status :  " + _iconStatusPass + " " + _stsPassEn + @"</b></span>
                            //</div>

    

        //_htmlHeader1 += @"<div class='row '> 
        //                  <div class='form-group col-xs-12' > 
        //                  <h4 ><span class='th'><b>เกณฑ์การร่วมกิจกรรมสำหรับนักศึกษาปี 25"+ _studentCode.Substring(0,2) + @"</span><span class='en'>Activity Criteria</span></h4>
        //                  </div>
        //                  </div>";
        //_htmlHeader1 += @"<table class='table table-striped'>
        //                  <thread><tr><th>เงื่อนไข</th><th>หน่วยนับ</th></tr></thread>
        //                  </table> ";

        //_htmlHeader1 += @"<div class='row page-header'>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>ชื่อ-นามสกุล :</b> " + _firstName + " " + _lastName+ @"
        //                    </div>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>เลขประจำตัวนักศึกษา :</b> " + _studentCode + @"
        //                    </div>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>คณะ :</b> " + _facNameTh + @"
        //                    </div>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>หลักสูตร :</b> " + _programNameTh + @"
        //                    </div>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>จำนวนกิจกรรม</b> " + _countActAll + @" <b>กิจกรรม</b>
        //                    </div>
        //                    <div class='form-group col-xs-6' > 
        //                    <b>จำนวนชั่วโมง</b> " + _countHoursAll + @" <b>ชั่วโมง</b>
        //                    </div>
        //                  </div>";

        // _htmlHeader1 += @"<button type='button' class='btn btn-info btnActivityTranscript' data-studentcode='" + _studentCode + "'><span class='glyphicon glyphicon-file'></span> Activity Transcript</button> ";
        _htmlHeader1 += @"<div class='row '> 
                              <div class='form-group col-xs-12' > 
                              <h4 ><b><span class='th'>กิจกรรมที่ได้เข้าร่วมแล้ว</span><span class='en'>Activity joined</span></b></h4>
                              </div>
                          </div>";
        _htmlHeader1 += @"                                      
                                              <table id='tblStdActType1' class='table table-bordered'>
                                              <thead>
                                              <tr class='bg-primary'>
                                                  <th class='col-sm-12' colspan='5'>
                                                  <span class='th'>1. กิจกรรมกำหนดเข้าร่วมและเลือกเข้าร่วม (" + _countAct+" กิจกรรม,"+_countHours+ @" ชั่วโมง)</span>
                                                  <span class='en'>1. Activity, determine, join and choose to participate (" + _countAct + " act.," + _countHours + @" hour)</span>
                                                  </th>
                                              </tr>
                                              <tr class='bg-info'>
                                                 <th class='col-sm-2 text-center'>
                                                       <b><span class='th'>ปีการศึกษา/ภาค</span><span class='en'>Academic year/Semester</span></b>
                                                 </th>
                                                 <th class='col-sm-2 text-center'>
                                                       <b><span class='th'>ส่วนงานผู้จัดโครงการ</span><span class='en'>Institute</span></b>
                                                 </th>
                                                 <th class='col-sm-5 text-center'>
                                                       <b><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></b>
                                                 </th>
                                                 <th class='col-sm-2 text-center'>
                                                       <b><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></b>
                                                 </th>
                                                 <th class='col-sm-1 text-center'>
                                                       <b><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></b>
                                                 </th>
                                              </tr>
                                              </thead>";
        _htmlBody1 += "</table>";
        _string.Append(_htmlHeader1 +_htmlBody1);
        return _string.ToString();

    }


    ///// <summary>
    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 2017-08-29
    ///// Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    ///// Method : searchActivity
    ///// Sample : N/A
    ///// </summary>
    //public static string getListActivitiesType2(string _studentId)
    //{

    //    StringBuilder _string = new StringBuilder();
    //    DataSet _ds = ActDB.rptGetListActivityAllByStudentId(_studentId, "1");
    //    int _i = 1;
    //    string _studentCode = "", _stdLeft2="";
    //    string _semester = "", _acaYear = "";
    //    string _firstName = "", _lastName = "";
    //    string _htmlHeader2 = "", _htmlBody2 = "";
    //    string _countAct = "0", _countHours = "0";
    //    string _projectNameTh = "", _positionNameTh = "";
    //    string _hourRow = "";
    //    string _A1 = "", _A2 = "", _A3 = "", _A4 = "";
    //    string _M = "", _A = "", _H = "", _I = "", _D = "", _O = "", _L = "";
    //    string _code = "";
    //    _htmlHeader2 = " <div class='panel panel-default'  style='font-size:15px;'>";
    //    if (_ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow _dr in _ds.Tables[0].Rows)
    //        {
    //            _semester = _dr["semester"].ToString();
    //            _acaYear = _dr["acaYear"].ToString();
    //            _studentCode = _dr["studentCode"].ToString();
    //            _stdLeft2 = _dr["stdLeft2"].ToString();
    //            _firstName = _dr["firstName"].ToString();
    //            _lastName = _dr["lastName"].ToString();
    //            _countAct = _dr["countAct"].ToString();
    //            _countHours = _dr["countHour"].ToString();
    //            _projectNameTh = _dr["projectNameTh"].ToString();
    //            _positionNameTh = _dr["positionNameTh"].ToString();
    //            _hourRow = _dr["hourRow"].ToString();
    //            _code = _dr["code"].ToString();

    //            if (Convert.ToInt32(_stdLeft2) > 59)
    //            {
    //                _M = _dr["M"].ToString();
    //                _A = _dr["A"].ToString();
    //                _H = _dr["H"].ToString();
    //                _I = _dr["I"].ToString();
    //                _D = _dr["D"].ToString();
    //                _O = _dr["O"].ToString();
    //                _L = _dr["L"].ToString();
    //                _htmlBody2 += @"    <div class='row'>

    //                                        <div class='form-group col-xs-1' > 
    //                                            " + _semester + @"/" + _acaYear + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-2' > 
    //                                            " + _code + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-3' > 
    //                                            " + _projectNameTh + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-2' > 
    //                                            " + _positionNameTh + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-3' > 
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _M + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _A + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _H + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _I + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _D + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _O + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-1 text-right' > 
    //                                                " + _L + @"
    //                                            </div>
    //                                        </div>
    //                                        <div class='form-group col-xs-1 text-right' > 
    //                                        " + _hourRow+@"
    //                                        </div>
    //                                </div>";

    //            }
    //            else
    //            {
    //                _A1 = _dr["A.1"].ToString();
    //                _A2 = _dr["A.2"].ToString();
    //                _A3 = _dr["A.3"].ToString();
    //                _A4 = _dr["A.4"].ToString();
    //                _htmlBody2 += @"    <div class='row'>
    //                                        <div class='form-group col-xs-1' > 
    //                                            " + _semester + @"/" + _acaYear + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-2' > 
    //                                            " + _code + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-4' > 
    //                                            " + _projectNameTh + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-2' > 
    //                                            " + _positionNameTh + @"
    //                                        </div>
    //                                        <div class='form-group col-xs-2' > 
    //                                            <div class='form-group col-xs-3 text-right' > 
    //                                                " + _A1 + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-3 text-right' > 
    //                                                " + _A2 + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-3 text-right' > 
    //                                                " + _A3 + @"
    //                                            </div>
    //                                            <div class='form-group col-xs-3 text-right' > 
    //                                                " + _A4 + @"
    //                                            </div>
    //                                        </div>
    //                                        <div class='form-group col-xs-1 text-right' > 
    //                                        " + _hourRow + @"
    //                                        </div>
    //                                </div>";
    //            }
               
    //            _i++;
    //        }
    //    }
    //    else
    //    {
    //        _htmlBody2 += "<div class='row'>  <div class='form-group col-xs-12 text-center' > ไม่พบข้อมูล </div></div>";
    //    }

    //    string _column = "";
    //    _ds = ActDB.getListStudentProfile(_studentId);
    //    if (_ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow _dr in _ds.Tables[0].Rows)
    //        {
    //            _studentCode = _dr["studentCode"].ToString();
    //            _stdLeft2 = _dr["stdLeft2"].ToString();
    //        }
    //    }
    //    if (Convert.ToInt32(_stdLeft2) > 59)
    //    {
    //        _column = @"    <div class='form-group col-xs-1  text-right' > 
    //                        <b>M</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>A</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>H</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>I</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>D</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>O</b>
    //                        </div>
    //                        <div class='form-group col-xs-1 text-right' > 
    //                        <b>L</b>
    //                        </div>";
    //    }
    //    else
    //    {
    //        _column = @"   <div class='form-group col-xs-3 text-right' > 
    //                        <b>A1</b>
    //                        </div>
    //                        <div class='form-group col-xs-3 text-right' > 
    //                        <b>A2</b>
    //                        </div>
    //                        <div class='form-group col-xs-3 text-right' > 
    //                        <b>A3</b>
    //                        </div>
    //                        <div class='form-group col-xs-3 text-right' > 
    //                        <b>A4</b>
    //                        </div>";
    //    }
    //    _htmlHeader2 += @"<div class='panel panel-default'  style='font-size:15px;'>
                                                      
    //                                                  <div class='panel-heading'>2. กิจกรรมเลือกเสรี (" + _countAct + " กิจกรรม," + _countHours + @" ชั่วโมง)</div>
    //                                                  <div class='panel-body'>
    //                                                                     <div class='row'>

    //                                                                              <div class='form-group col-xs-1' > 
    //                                                                                <b>ภาค/ปีการศึกษา</b>
    //                                                                              </div>
    //                                                                              <div class='form-group col-xs-2' > 
    //                                                                                 <b>รหัสโครงการ</b>
    //                                                                              </div>
    //                                                                              <div class='form-group col-xs-3' > 
    //                                                                                <b>ชื่อโครงการ/กิจกรรม</b>
    //                                                                              </div>
    //                                                                              <div class='form-group col-xs-2' > 
    //                                                                                <b>ตำแหน่ง</b>
    //                                                                              </div>
    //                                                                              <div class='form-group col-xs-3' > 
    //                                                                                 " + _column + @"
    //                                                                              </div>
    //                                                                              <div class='form-group col-xs-1 text-right' > 
    //                                                                                <b>รวม</b>
    //                                                                              </div>
    //                                                                       </div>";
    //    _htmlBody2 += "</div></div></div>";

    //    _ds = ActDB.getListIndicatorByYearStd(_studentCode);
    //    _htmlBody2 += "<div class='panel-body'>";
    //    if (_ds.Tables[0].Rows.Count > 0)
    //    {
    //        _htmlBody2 += "<div class='row'><b>หมายเหตุ</b></div>";
    //        foreach (DataRow _dr in _ds.Tables[0].Rows)
    //        {
    //            _htmlBody2 += "  <div class='row'><b>" + _dr["indicatorAbbrevEn"] + ":</b> " + _dr["indicatorNameTh"] + "</div>";
    //        }
    //    }
    //    else
    //    {
    //        _htmlBody2 += "<div class='row'><b>ไม่พบข้อมูล</b></div>";
    //    }
    //    _htmlBody2 += "</div>";

    //    _string.Append(_htmlHeader2 + _htmlBody2);
    //    return _string.ToString();

    //}

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-05
    /// Perpose: แสดงข้อมูลประเภทโครงการในดรอปดาวน์ลิสต์
    /// Method : getListProjectTypeByStudentYear
    /// Sample : N/A
    /// </summary>
    public static string getListProjectTypeByStudentYear(string _studentId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectTypeByStudentYear(_studentId);
 
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <label for='ddlProjectType'>
                                 ประเภทโครงการ</label>
                                 <select class='form-control ddlProjectType' >");
            _string.Append("<option value=''  >กรุณาเลือก</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append("<option value='" + _dr["id"] + "'    >" + _dr["nameTh"] + "</option>");
            }

            _string.Append("</select>");
        }
        return _string.ToString();
    }


     /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-05
    /// Perpose: แสดงรายการข้อมูลโครงการตามเงื่อนไขที่ค้นหา
    /// Method : getListProjectByCondition
    /// Sample : N/A
    /// </summary>
    public static string getListProjectByCondition(string _activityName, string _acaYear, string _projectType, string _projectStatus, string _studentId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectForStudentShopping(_activityName, _acaYear, _projectType, _projectStatus, _studentId);
        string _code = "";
        string _nameTh = "";
        string _dateTh = "";
        string _place = "";
        string _projectStatusNameTh = "";
        string _projectId="";
        _string.Append("<h4 class='page-header'><b>รายการข้อมูลโครงการที่ค้นหา</b></h4>");
        _string.Append(@"<div class='table-responsive'>
                                                    <table id='tblActivityList' class='table'>
                                                    <thead>
                                                     <tr>
                                                        <th class='col-sm-2 text-center'>
                                                        รหัสกิจกรรม
                                                        </th >
                                                        <th class='col-sm-8 text-center'>
                                                        รายละเอียด
                                                        </th >
                                                        <th class='col-sm-2 text-center'>
                                                        สถานะ
                                                        </th >
                                                    </thead>");
        //_string.Append("<div style='overflow-y:auto;height:330px;overflow-x:hidden;'>");

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _code = _dr["code"].ToString();
                _nameTh = _dr["nameTh"].ToString();
                _dateTh = _dr["dateTh"].ToString();
                _place = _dr["place"].ToString();
                _projectId = _dr["id"].ToString();
                _projectStatusNameTh = _dr["projectStatusNameTh"].ToString();
                _string.Append(@"<tr >
                                  <td class='text-center'>"+_code+ @"</td>
                                  <td><a class='btnGetListActivityShoppingDetail' data-projectid='" + _projectId + @"' style='cursor:pointer;'><u style='font-size:15px;'>" + _nameTh + "</u></br><b>วัน เวลา :</b> " + _dateTh + "</br><b>สถานที่ :</b> " + _place + @"</a></td>
                                  <td class='text-center'>" + _projectStatusNameTh + @"</td>
                                 </tr>");
            }
        }
        else
        {
            _string.Append("<tr> <td colspan='3' class='col-xs-12 text-center' style='font-size:16px;' >ไม่พบข้อมูลที่ค้นหา</td></tr>");
        }
        _string.Append("</table></div>");
        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-14
    /// Perpose: แสดงหน้าจอกิจกรรมเพื่อยื่นกู้เงินกยศ.
    /// Method : getListActivitySchorlarship
    /// Sample : N/A
    /// </summary>
    public static string getListActivitySchorlarship(string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListActivitySchorlarship(_studentId);
        _string.Append(@"<h2 class='page-header'><span class='th'>ข้อมูลกิจกรรมเพื่อยื่นกู้เงิน กยศ./กรอ.</span><span class='en'>Recovery activities</span></h2>
                          <div class='panel panel-default'  style='font-size:15px;'>
                                              
                                                <div class='panel-heading'><strong>
                                                <span class='th'>ตารางสรุป ชั่วโมงกิจกรรมด้านบำเพ็ญประโยชน์</span><span class='en'>Table of service activity</span>
                                                </strong></div>
                                              <div class='panel-body'> ");
        _string.Append(@"                                       <div class='row'>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong><span class='th'>ปีการศึกษา</span><span class='en'>Academic year</span></strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong><span class='th'>จำนวนกิจกรรม</span><span class='en'>Number of activities</span></strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong><span class='th'>จำนวนชั่วโมง</span><span class='en'>Hour</span></strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong><span class='th'>สถานะ</span><span class='en'>Status</span></strong>
                                                                          </div>
                                                                 </div>");
        string _acaYear = "", _countActs = "", _sumHours = "", _stsPass = "", _stsPassEn = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _acaYear = _dr["acaYear"].ToString();
                _countActs = _dr["countActs"].ToString();
                _sumHours = _dr["sumHours"].ToString();
                _stsPass = _dr["stsPass"].ToString();
                _string.Append(@"     <div class='row'>
                                                <div class='form-group col-xs-3 text-center' > 
                                                    <a href='#' class='btnGetListActDetailForScholarship' data-acayear='" + _acaYear + "'><u>" + _acaYear + @"</u></a>
                                                </div>
                                                <div class='form-group col-xs-3 text-center' > 
                                                    " +_countActs+@"
                                                </div>
                                                <div class='form-group col-xs-3 text-center' > 
                                                    "+_sumHours+@"
                                                </div>
                                                <div class='form-group col-xs-3  text-center' > 
                                                    " + _stsPass + @"
                                                </div>
                                       </div> ");

            }
        }
        else
        {
            _string.Append("<div class='row'> <div class='col-xs-12 text-center' style='font-size:16px;' >-</div></div>");
        }

                                                                
       _string.Append(@"  <div class='row'>
                                       <div class='form-group col-xs-12' > 
                                                    <span class='th'><strong><u>หมายเหตุ</u> : </strong>ระบบจะสรุปหน่วยชั่วโมงเฉพาะกิจกรรมด้านคุณธรรม จริยธรรมและบำเพ็ญประโยชน์(A1) ในแต่ละปีการศึกษาเท่านั้น</span>
                                                    <span class='en'><strong><u>Remark</u> : </strong>The system will summarize the hour units for specific moral activities. Ethics and service (A1) in each academic year only</span>
                                       </div>
                              </div>
                                                
                          </div>
                          </div>
                         </div>");
        _string.Append("<div class='divDetailActForScholarship'></div>");
        _string.Append(@"<div class='panel-body'>
                                                        <div class='row'>
                                                            <div form-group col-xs-12 >
                                                            <strong><span class='th'>เงื่อนไข</span><span class='en'>Condition</span></strong>
                                                            </div>
                                                        </div>
                                                        <div class='row'>
                                                            <div form-group col-xs-12 >
                                                            <span class='th'>1.นักศึกษาต้องเข้าร่วมกิจกรรมด้านบำเพ็ญประโยชน์ฯไม่น้อยกว่า 1 กิจกรรม/ภาคการศึกษา</span>
                                                            <span class='en'>1.Students must attend at least 1 service activity / semester.</span>
                                                            </div>
                                                        </div>
                                                        <div class='row'>
                                                            <div form-group col-xs-12 >
                                                            <span class='th'>2.นักศึกษาต้องมีจำนวนหน่วยชั่วโมงกิจกรรมด้านบำเพ็ญประโยชน์ฯไม่น้อยกว่า 18 ชั่วโมง/ภาคการศึกษา</span>
                                                            <span class='en'>2. Students must have at least 18 hours of service activity activities per semester.</span>
                                                            </div>
                                                        </div>
                          </div>");

        return _string.ToString();

    }

      /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-14
    /// Perpose: แสดงหน้ารายการข้อมูลกิจกรรมที่เข้าร่วมที่ได้ค่า A1 ด้านบำเพ็ญประโยชน์
    /// Method : getListActDetailForScholarship
    /// Sample : N/A
    /// </summary>
    public static string getListActDetailForScholarship(string _acaYear,string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectForStudentScholarShip(_acaYear, _studentId);
        string _htmlHeader = "", _htmlBody = "";
        _htmlHeader = @" <div id='divActScholarship' class='panel panel-default'  style='font-size:15px;'>
                                              
                                              <div class='panel-heading'><strong>กิจกรรมบำเพ็ญประโยชน์ ปีการศึกษา " + _acaYear + @"</strong></div>
                                              <div class='panel-body'>    </br>
                                               <div class='row'>
                                               <div class='form-group col-xs-12 text-center' > 
                                               <img src='../../images/logo.png' /> </div></div>";

        string _projectNameTh = "", _instituteNameTh = "", _sumHours = "", _sumHoursAll = "", _stsSendDataSch = "", _stsScholarship="";
        string _code = "", _dateTh = "", _studentCode = "", _firstName = "", _lastName = "", _stsPass = "" ;
        int _i = 1;
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectNameTh = _dr["projectNameTh"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _firstName= _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _sumHours = _dr["sumHours"].ToString();
                _sumHoursAll = _dr["sumHoursAll"].ToString();
                _code = _dr["code"].ToString();
                _dateTh = _dr["dateTh"].ToString();
                _stsPass = _dr["stsPass"].ToString();
                _stsScholarship = _dr["stsScholarship"].ToString();
                _stsSendDataSch = _dr["stsSendDataSch"].ToString();
                _htmlBody += @"                                  <div class='row'>
                                                                         <div class='form-group col-xs-2 text-left' > 
                                                                             " + _code + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-left' > 
                                                                             " + _projectNameTh + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-left' > 
                                                                             " + _dateTh + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-left' > 
                                                                             " + _instituteNameTh + @"
                                                                          </div>
                                                                          <div class='form-group col-xs-1 text-center' > 
                                                                             " + _sumHours + @"
                                                                          </div>
                                                                 </div>"; 
                _i++;
            }
            _htmlBody += @" <div class='row'> <div class='col-xs-11 text-right'  ><strong>รวม</strong></div><div class='col-xs-1 text-center'  >" + _sumHoursAll + "</div></div>";
            _htmlBody += @" <div class='row'> <div class='col-xs-11 text-right'  ><strong>สถานะ</strong></div><div class='col-xs-1 text-center'  >" + _stsPass + "</div></div>";
            _htmlBody += @" <div class='row'> <div class='col-xs-12 text-left'  ><strong><u>หมายเหตุ</u> : </strong>เอกสารฉบับนี้ใช้เพื่อประกอบการพิจารณาอนุมัติการกู้ยืมเงินกยศ./กรอ.เท่านั้น</div></div>";
  
        }
        else
        {
            _htmlBody += "<div class='row'> <div class='col-xs-12 text-center' style='font-size:16px;' >ไม่พบข้อมูลที่ค้นหา</div></div>";
        }
        _htmlBody += "   </div> </div>";
        _htmlBody += "<div class='row'> <div class='col-xs-5 text-left'  ><strong>สถานะการส่งข้อมูล :</strong> ";
        _htmlBody += "   <a style='cursor:pointer;' class='btnSendDataScholarship' data-acayear='" + _acaYear + "' data-studentid='" + _studentId + "' data-stsscholarship='" + _stsScholarship + "'>" + _stsSendDataSch + "</a><a style='cursor:pointer;' data-toggle='modal' data-target='#divPopup' class='btnGetListSchStudentSendAct'> >> ตรวจสอบรายชื่อ << </a></div>";
        _htmlBody += "   <div class='col-xs-7 text-left'  ><button type='button' class='btn btn-default glyphicon glyphicon-print btnPrintActForScholarship'> พิมพ์เอกสาร</button></div>   ";
        _htmlBody += "</div></div>";
        _htmlHeader += @"                    
                                             <div class='row'>
                                                 
                                                    <div class='form-group col-xs-12 text-center' > 
                                                          <strong>กิจกรรมด้านบำเพ็ญประโยชน์ ปีการศึกษา " + _acaYear + @"</strong>
                                                    </div>
                                             </div></br>
                                             <div class='row'> 
                                                <div class='form-group col-xs-5 text-left' > 
                                                <strong>รหัสนักศึกษา :</strong> " + _studentCode + @"
                                                </div>
                                                <div class='form-group col-xs-7 text-left' > 
                                                <strong>ชื่อ-นามสกุล :</strong> " + _firstName + ' '+_lastName + @"
                                                </div>
                                             </div>
                                             <div class='row'  >
                                                                          <div class='form-group col-xs-2 text-center ' > 
                                                                             <strong>รหัส</strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong>ชื่อโครงการ</strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong>วันเวลาที่จัดกิจกรรม</strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-3 text-center' > 
                                                                             <strong>หน่วยงาน</strong>
                                                                          </div>
                                   
                                                                          <div class='form-group col-xs-1 text-center' > 
                                                                             <strong>ชั่วโมง</strong>
                                                                          </div>
                                           </div>";
        _string.Append(_htmlHeader+_htmlBody);

        return _string.ToString();

    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-15
    /// Perpose: แสดงหน้าจอ Shopping กิจกรรมของนักศึกษา
    /// Method : getListActivityShoppingDetail
    /// Sample : N/A
    /// </summary>
    public static string getListActivityShoppingDetail(string _projectId)
    {

        StringBuilder _string = new StringBuilder();
        //DataSet _ds = ActDB.getListActivitySchorlarship(_studentId);
        _string.Append(@"<h2 class='page-header'>รักน้อง 2560 (ทดสอบระบบ)</h2>
                          <div class='panel panel-default'  style='font-size:15px;'>
                                              
                                              <div class='panel-heading'><strong>---------</strong></div>
                                              <div class='panel-body'> ");
        _string.Append(@"                                       <div class='row'>
                                                                          <div class='form-group col-xs-6 text-center' > 
                                                                             <strong>ข้อมูลกิจกรรม</strong>
                                                                          </div>
                                                                          <div class='form-group col-xs-6 text-center' > 
                                                                             <strong>รายละเอียด</strong>
                                                                          </div>
                                                                 </div>");

        _string.Append("</div></div>");

        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-10-02
    /// Perpose: แสดงเมนูหน้าแสดงรายละเอียดข้อมูลเพื่อนจะให้นักศึกษา Shopping ดู
    /// Method : getListProjectDetailForShopping
    /// Sample : N/A
    /// </summary>
    public static string getListProjectDetailForShopping(string _projectId,string _username)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectDetail(_projectId);
        string _code = "", _nameTh = "", _projectTypeNameTh = "", _placeName="";
        string _projectDetail = "", _projectStatusNameTh="";
        string _targetExprFaculty = "", _targetExprClassYear="", _targetExprStudentCode="";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _code = _dr["code"].ToString();
                _nameTh = _dr["nameTh"].ToString();
                _projectTypeNameTh = _dr["projectTypeNameTh"].ToString();
                _placeName = _dr["placeName"].ToString();
                _projectDetail = _dr["projectDetail"].ToString();
                _projectStatusNameTh = _dr["projectStatusNameTh"].ToString();
                _targetExprFaculty = _dr["targetExprFaculty"].ToString();
                _targetExprClassYear = _dr["targetExprClassYear"].ToString();
                _targetExprStudentCode = _dr["targetExprStudentCode"].ToString();
            }
        }
        _ds = ActDB.getListSection(_projectId, _username);
        string _htmlSectionList = "", _startDateTh = "", _endDateTh = "", _amountMax = "", _amoutRegist = "";
        string _stsJoinSection = "", _stsJoinSectionAll = "";
        int _i =1;
        int _countSection = _ds.Tables[0].Rows.Count;
        _htmlSectionList = "<tr>";
        if (_countSection > 0)
        {
            _htmlSectionList += " <th class='left-center' rowspan='" + _ds.Tables[0].Rows.Count + "'>วัน เวลาจัดกิจกรรม :</th >";
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _startDateTh = _dr["startDateTh"].ToString();
                _endDateTh = _dr["endDateTh"].ToString();
                _amountMax = _dr["amountMax"].ToString();
                _amoutRegist = _dr["countStudentSection"].ToString();
                _stsJoinSection = _dr["stsJoinDetail"].ToString();
                _stsJoinSectionAll = _dr["stsJoinSectionAll"].ToString();
                _amountMax = String.Format("{0:#,##0}", Convert.ToDouble(_amountMax));
                _amoutRegist = String.Format("{0:#,##0}", Convert.ToDouble(_amoutRegist));
                _htmlSectionList += "<td class='left-center'><b>ช่วงที่ " + _i.ToString() + "</b> วันที่ " + _startDateTh + " - " + _endDateTh + "";
                _htmlSectionList += " <b>จำนวนผู้สมัครแล้ว/จำนวนที่รับ : </b>" + _amountMax + " คน / " + _amoutRegist + " คน";
                _htmlSectionList += " </br><b>สถานะการสมัคร : </b>" + _stsJoinSection ;
                _htmlSectionList += "</td >";

            }
        }
        else
        {
            _htmlSectionList += " <th class='left-center'>วัน เวลาจัดกิจกรรม :</th><td class='left-center'>-</td>";
        }
        _htmlSectionList += "</tr>";


        _ds = ActDB.getListIndicatorHoursForStudentShopping(_projectId);
        string _htmlIndicatorList = "";
        string _indicatorAbbrevEn = "";
        string _indicatorNameTh = "";
        string _sumHours = "", _sumHoursAll="";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _htmlIndicatorList += "<tr><th class='left-center' colspan='2' >รายการตัวชี้วัด(Indicator) :</th ></tr>";
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _indicatorAbbrevEn = _dr["indicatorAbbrevEn"].ToString();
                _indicatorNameTh = _dr["indicatorNameTh"].ToString();
                _sumHours = _dr["sumHours"].ToString();
                _sumHoursAll = _dr["sumHoursAll"].ToString();
                _sumHours = String.Format("{0:#,##0}", Convert.ToDouble(_sumHours));
                _sumHoursAll = String.Format("{0:#,##0}", Convert.ToDouble(_sumHoursAll));
                _htmlIndicatorList += "<tr><td class='text-left'>- " + _indicatorAbbrevEn + " " + _indicatorNameTh+"</td>";
                _htmlIndicatorList += "<td class='text-left'>" + _sumHours + " ชม.</td>";
                _htmlIndicatorList += "</tr>";
            }
            _htmlIndicatorList += "<tr>";
            _htmlIndicatorList += "<th class='text-left'>ชั่วโมงกิจกรรมที่ได้</th><td class='text-left'>" + _sumHoursAll + " ชม.</td>";
            _htmlIndicatorList += "</tr>";
        }
        else
        {
            _htmlIndicatorList += "<tr><th class='left-center'>รายการตัวชี้วัด(Indicator) :</th><td class='left-center'>-</td></tr>";
        }




        _ds = ActDB.getListProjectCharacter(_projectId);
        string _htmlCharacterList = "", _characterNameTh="";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _htmlCharacterList += "<tr><th class='left-center' colspan='2' >รายการคุณลักษณะที่พึงประสงค์(Character) :</th ></tr>";
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _characterNameTh = _dr["characterNameTh"].ToString();
                _htmlCharacterList += "<tr><td class='text-left' colspan='2'>- " + _characterNameTh + "</td>";
                _htmlCharacterList += "</tr>";
            }

        }
        else
        {
            _htmlIndicatorList += "<tr><th class='left-center'>รายการคุณลักษณะที่พึงประสงค์(Character) :</th><td class='left-center'>-</td></tr>";
        }



        _string.Append("<h2 class='page-header'>ค้นหาข้อมูลกิจกรรม</h2>");
        _string.Append(@"  <div class='row'>
                           <div class='form-group col-xs-12 text-center'>
                           <input class='hddProjectId' type='hidden'/>
                           <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                           <button type='button' class='btn btn-info glyphicon glyphicon-hand-right btnGetlistSectionForShopping' data-projectid='" + _projectId + "' data-countsection='" + _countSection + "' data-stsjoinsectionall='"+_stsJoinSectionAll+@"' data-toggle='modal' data-target='#divPopup' > สมัครเข้าร่วมโครงการ</button>
                           </div></div>");
        _string.Append(@"
                         <div class='panel panel-default'  style='font-size:15px;'>
                          <div class='panel-body'>  <table id='tblActivityList' class='table' cellpadding='0' cellspacing='0'>
                                                    <thead>
                                                     <tr class='bg-warning'>
                                                        <th class='col-sm-5 text-center'>
                                                        ข้อมูลกิจกรรม
                                                        </th >
                                                        <th class='col-sm-7 text-center'>
                                                        รายละเอียด
                                                        </th >
                                                      </tr>
                                                    </thead>");
        _string.Append(" <tr><th class='left-center'>รหัสกิจกรรม :</th ><td class='left-center'>" + _code + "</td ></tr>");
        _string.Append(" <tr><th class='left-center'>ชื่อกิจกรรม :</th ><td class='left-center'>" + _nameTh + "</td ></tr>");
        _string.Append(_htmlSectionList);
        _string.Append(" <tr><th class='left-center'>สถานที่จัด :</th ><td class='left-center'>" + _placeName + "</td ></tr>");
        _string.Append(" <tr><th class='left-center'>กลุ่มเป้าหมายของกิจกรรม :</th ><td class='left-center'>" + _targetExprFaculty +" "+ _targetExprClassYear +" "+ _targetExprStudentCode + "</td ></tr>");
        _string.Append(" <tr><th class='left-center'>ประเภทโครงการ :</th ><td class='left-center'>" + _projectTypeNameTh + "</td ></tr>");
        _string.Append(_htmlIndicatorList);
        _string.Append(_htmlCharacterList);
        _string.Append(" <tr><th class='left-center'>รายละเอียดโครงการ :</th ><td class='left-center'>" + _projectDetail + "</td ></tr>");
        _string.Append(" <tr><th class='left-center'>สถานะโครงการ :</th ><td class='left-center'>" + _projectStatusNameTh + "</td ></tr>");
        _string.Append("</table>");
        _string.Append("</div>");
        _string.Append("</div>");

        return _string.ToString();

    }



        /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-10-04
    /// Perpose: แสดงหน้า List Shopping ให้นศ.เลือกรายการ Section
    /// Method : getListSectionForShopping
    /// Sample : N/A
    /// </summary>
    public static string getListSectionForShopping(string _projectId, string _username)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSection(_projectId, _username);
        string _htmlSectionList = "", _startDateTh = "", _endDateTh = "", _amountMax = "", _amoutRegist = "";
        string _stsJoinSection = "", _projectNameTh="";
        int _i = 1;
        _htmlSectionList = @"
                              <table id='tblListSection' class='table' style='font-size:16px;'>
                              <thead>
                              <tr>
                              <th class='col-sm-2'>เลือก</th>
                              <th class='col-sm-10'>
                              รายละเอียด Section
                              </th>
                              </tr>
                              </thead>";
        if (_ds.Tables[0].Rows.Count > 0)
        {
           foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _startDateTh = _dr["startDateTh"].ToString();
                _endDateTh = _dr["endDateTh"].ToString();
                _amountMax = _dr["amountMax"].ToString();
                _amoutRegist = _dr["countStudentSection"].ToString();
                _stsJoinSection = _dr["stsJoinDetail"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _amountMax = String.Format("{0:#,##0}", Convert.ToDouble(_amountMax));
                _amoutRegist = String.Format("{0:#,##0}", Convert.ToDouble(_amoutRegist));
                _htmlSectionList += "<tr>";
                _htmlSectionList += @"<td><div class='checkbox' style='cursor:pointer;'>
                                                <label><input type='checkbox' class='chkSectionListShopping' ></label>
                                          </div></td>";
                _htmlSectionList += "<td class='left-center'><b>ช่วงที่ " + _i.ToString() + "</b> วันที่ " + _startDateTh + " - " + _endDateTh + "";
                _htmlSectionList += "</br><b>จำนวนผู้สมัครแล้ว/จำนวนที่รับ : </b>" + _amountMax + " คน / " + _amoutRegist + " คน";

            //    _htmlSectionList += "</br><b>สถานะการสมัคร : </b>" + _stsJoinSection;

                _htmlSectionList += "<input class='projectSectionId' type='hidden' value='" + _dr["id"] + "' />";
                _htmlSectionList += "<input class='amountMax' type='hidden' value='" + _dr["amountMax"] + "' />";
                _htmlSectionList += "<input class='amountCountStudent' type='hidden' value='" + _dr["countStudentSection"] + "' />";
                _htmlSectionList += "</td ></tr>";

            }

           _htmlSectionList += "<tr><td class='text-center' colspan='2' class='col-sm-12'> <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetListSectionForShopping' data-projectid='" + _projectId + @"'  > ยืนยันเข้าร่วมโครงการ</button></td></tr>";
        }
 
        _htmlSectionList += "</table>";

        _string.Append(@"   <div >
                              <div class='modal-dialog'>

                                
                                <div class='modal-content'>
                                  <div class='modal-header'>
                                    <button type='button' class='close' data-dismiss='modal'>&times;</button>
                                    <h4 class='modal-title'><strong>กิจกรรม : " + _projectNameTh + @"</strong></h4>
                                  </div>
                                  <div class='modal-body'>
                                   " + _htmlSectionList + @"
                                    </p>
                                  </div>
                                
                                </div>

                              </div>
                            </div> ");

        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-02
    /// Perpose: แสดงหน้ารายงานกราฟ Spiral Graph
    /// Method : getlistRptMahidolCoreValue
    /// Sample : N/A
    /// </summary>
    public static string getlistRptMahidolCoreValue(string _studentId,string _facultyId,string _programId,string _acaYear,string _semester,string _groupIndicatorId)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getMahidolCoreValue(_studentId, _facultyId, _programId, _acaYear, _semester, _groupIndicatorId);
        string _abbrevEn = "", _indicatorName = "", _hours="";
        DataTable _dt = new DataTable();
        int _i =0;
   
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _abbrevEn = _dr["abbrevEn"].ToString();
                _indicatorName = _dr["indicatorName"].ToString();
                _hours = _dr["hours"].ToString();
                _result.name[_i] = _abbrevEn + ":" + _indicatorName;
                _result.data[_i] = Convert.ToDouble(_hours);
               _i++;

            } 
        }

        //_result.name = new string[] {"M:Mastery", "A:Altruism", "H:Harmony", "I:Integrity","D:Determination","O:Originality","L:Leadership"};
        //_result.data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        //_result.data = "5,4,5,4,1,1,1";

        return JsonConvert.SerializeObject(_result);
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-03
    /// Perpose: 
    /// Method : getListShortProfileStudent
    /// Sample : N/A
    /// </summary>
    public static string getListShortProfileStudent(string _studentCode,string _stsShowSummaryAct,string _txtDisplayHeader,string  _countProject,string _sumHour,string _groupIndicatorId,string _groupCharacterId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSummaryProjectByStudent(_studentCode,"","","", _groupIndicatorId, _groupCharacterId);
        string _firstName = "";
        string _lastName = "";
        //string _countAct = "";
        //string _countHour = "";
        string _facNameTh = "";
        string _programNameTh = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _countProject = _dr["countAct"].ToString();
                _sumHour = _dr["countHour"].ToString();
                _facNameTh = _dr["facultyNameTh"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();


            }
            _string.Append(@" <table class='table table-bordered' >
                    <caption class='text-center'><h3>" + _txtDisplayHeader + @"</h3></caption>
                     <tr >
                     <th bgcolor='#efefef' class='col-xs-2'>
                         ชื่อ-นามสกุล:
                     </th>
                     <td class='col-xs-4'>
                         " + _firstName + " " + _lastName + @"
                     </td>
                     <th bgcolor='#efefef' class='col-xs-2'>
                         เลขประจำตัวนักศึกษา:
                     </th>
                     <td class='col-xs-4'>
                         " + _studentCode + @"
                     </td>
                     </tr>

                     <tr >

                     <th bgcolor='#efefef'>
                         คณะ:
                     </th>
                     <td>
                         " + _facNameTh + @"
                     </td>
                     <th bgcolor='#efefef'>
                         หลักสูตร:
                     </th>
                     <td>
                         " + _programNameTh + @"
                     </td>
                     </tr>

                     <tr >
                     <th bgcolor='#efefef'>
                         จำนวนกิจกรรม:
                     </th>
                    ");

            if (_stsShowSummaryAct == "1")
            {
                _string.Append(@"
                     <td>
                         " + _countProject + @" กิจกรรม
                     </td>
                     <th bgcolor='#efefef'>
                         จำนวนชั่วโมง:
                     </th>
                     <td>
                         " + _sumHour + @" ชั่วโมง
                     </td>");
            }
            else
            {
                _string.Append(@"
                     <td colspan='3'>
                        " + _countProject + @" กิจกรรม
                     </td>");
            }

            _string.Append(@" </tr>
  
                    </table>");
        }
        else
        {
            _string.Append(@"<table class='table table-bordered' >
                    <caption class='text-center'><h3>" + _txtDisplayHeader + @"</h3></caption>
                     <tr >
                     <th bgcolor='#efefef' >
                         ไม่พบข้อมูลรายงานของนักศึกษา
                     </th></tr></table>");
        }
        return _string.ToString();
    }


     /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-05
    /// Perpose: 
    /// Method : getListDefinitionCoreValue
    /// Sample : N/A
    /// </summary>
    public static string getListDefinitionCoreValue(string _groupIndicatorId)
    {
        StringBuilder _string = new StringBuilder();
        if (_groupIndicatorId == "GIR-001")
        {
            _string.Append(definitionA1A4());
        }
        else if(_groupIndicatorId == "GIR-002")
        {
            _string.Append(definitionMahidol());
        }
        else if (_groupIndicatorId == "GIR-003")
        {
            _string.Append(definitionMahidolHidef());
        }
        //if (_studentCode=="all")
        //{
        //    _string.Append(definitionMahidol());
        //    _string.Append(definitionA1A4());

        //}
        //else if (Convert.ToInt16(_studentCode.Substring(0,2)) >= 60)
        //{
        //    _string.Append(definitionMahidol());
        //}
        //else
        //{
        //    _string.Append(definitionA1A4());
        //}
        return _string.ToString();
    }
    public static string definitionMahidolHidef()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                         <table class='table table-striped table-bordered' style='margin-top: 20px;' >
                         <tr >
                         <th class='col-xs-4'>
                             พิธีปฐมนิเทศนักศึกษาใหม่ระดับมหาวิทยาลัย หรือระดับส่วนงาน :
                         </th>
                         <td class='col-xs-8'>
                             <li>-</li>
                             </td>
                         </tr>
                         <tr >
                         <th >
                            พิธีไหว้ครูระดับมหาวิทยาลัย หรือระดับส่วนงาน :
                         </th>
                         <td>
                            <li>-</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                            กิจกรรมจิตอาสา (Volunteer) :
                         </th>
                         <td>
                             <li>-</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             กิจกรรมหลัก Mahidol HIDEF :
                         </th>
                         <td>
                            <li>Health Literacy - ความเข้าใจและสามารถดำเนินชีวิตให้เป็นผู้มีสุขภาพดี</li>
                            <li>Internationalization - ความเป็นนานาชาติ</li>
                            <li>Digital Literacy - ทักษะความเข้าใจและใช้เทคโนโลยีดิจิทัล</li>
                            <li>Environmental Literacy - ความเข้าใจและปฏิบัติเป็นในด้านสิ่งแวดล้อม</li>
                            <li>Financial Literacy - ความเข้าใจและปฏิบัติเป็นในด้านการเงิน เศรษฐกิจ ธุรกิจ</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             กิจกรรมส่งเสริม 21st Century Skills :
                         </th>
                         <td>
                            <li>Communication & Collaboration - การติดต่อสื่อสารและการร่วมมือกัน</li>
                            <li>Creativity & Innovation - ความคิดสร้างสรรค์และนวัตกรรม</li>
                            <li>Critical Thinking & Problem Solving - ทักษะการคิดเชิงวิพากษ์และการแก้ปัญหา</li>
                            <li>Leadership & Management Skills - การเป็นผู้นำ มีคุณธรรมจริยธรรมและทักษะการจัดการแบบเป็นกระบวนการ</li>
                            <li>Social skill - ทักษะทางสังคมและวัฒนธรรมที่ต่างกัน</li>
                         </td>
                         </tr>
                         </table>
                       ");
        return _string.ToString();
    }

    public static string definitionMahidol()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                         <table class='table table-striped table-bordered' style='margin-top: 20px;' >
                         <tr >
                         <th class='col-xs-4'>
                             M Mastery รู้แจ้ง รู้จริง สมเหตุ สมผล:
                         </th>
                         <td class='col-xs-8'>
                             <li>Self Directed มีสติ ควบคุมดูแลตนเองได้ สร้างวินัยในการดำเนินชีวิต ควบคุมจิตใจ และอารมณ์ให้ทำในสิ่งที่ถูกที่ควร ไม่ต้องให้ใครบังคับ</li>
                             <li>Personal Learning  รักการเรียนรู้ขวนขวายศึกษาหาความรู้เพื่อพัฒนาตนเอง ให้รู้แจ้งรู้จริง อย่างสม่ำเสมอ และนำความรู้ใหม่ๆมาประยุกต์ปรับปรุงงาน</li>
                             <li>Agility กระตือรือร้น ว่องไว  กระฉับกระเฉง สนใจวิทยาการ และการเปลี่ยนแปลง    ที่เกิดขึ้นคิดไตร่ตรอง และนำเสนอแนวทางใหม่ที่เฉียบคมเหมาะสม</li>
                             <li>System Perspective คิด พูด ทำ อย่างเป็นระบบ มีขั้นตอนอธิบายที่มาที่ไปสมเหตุสมผล ตรวจสอบได้</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             A Altruism มุ่งผลเพื่อผู้อื่น:
                         </th>
                         <td>
                             <li>Organization First รัก หวงแหน และปกป้องชื่อเสียงของมหิดล เมื่อต้องตัดสินใจ จะยึดประโยชน์ของส่วนรวม และองค์การเหนือประโยชน์ของตนเอง พร้อมเสียสละเวลา และ ความสุขส่วนตัวเพื่อส่วนรวม</li>
                             <li>Customer Focus Driven สนใจ เข้าใจ ความต้องการของ “ผู้รับบริการ” และหาวิธีตอบสนองด้วยความรวดเร็วให้เกิดความพึงพอใจ และ สร้างความประทับใจด้วยบริการ และผลงานที่มีคุณภาพ ด้วยความเต็มใจ</li>
                             <li>Societal Responsibility ตระหนักและลงมือดูแล และรักษาผลประโยชน์ของส่วนรวม และสังคมเสมือนของตนเอง</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             H Harmony กลมกลืนกับสรรถสิ่ง:
                         </th>
                         <td>
                             <li>Valuing Workforce Member เคารพ ให้เกียรติผู้ร่วมงาน โดยเปิดรับฟังความคิดเห็น สื่อสารให้มีส่วนรวม และสร้างความผูกพัน ไม่อคติ และ รักษาศักดิ์ศรี หน้าตาของผู้ร่วมงาน</li>
                             <li>Empathy ใส่ใจความรู้สึก ทุกข์สุขของผู้อื่นรอบตัว ร่วมดีใจ หรือให้กำลังใจ ชมเชย ยกย่อง รวมถึงแนะนำอย่างสร้างสรรค์จริงใจ</li>
                             <li>Unity มีน้ำใจ ร่วมมือ ร่วมแรงร่วมใจ อาสาเข้าช่วยเหลือด้วยความเต็มใจ ยืดหยุ่น ผ่อนปรน ประนีประนอม ทำให้ภารกิจสำเร็จลุล่วงด้วยความสามัคคี ปรองดอง</li>
                             <li>Synergy ผนึกพลัง ประสาน  ความแตกต่าง (เพศ วัย ความรู้ ) ให้เกิดความกลมกลืน นำจุดเด่นของทุกคนสร้างผลงานให้เหนือความคาดหมาย</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             I Integrity มั่นคงยิ่งในคุณธรรม:
                         </th>
                         <td>
                             <li>Truthfulness ซื่อตรง ตรงไปตรงมา ไม่หลอกลวงทั้งต่อตนเองและผู้อื่น คิด ไตร่ตรอง ก่อนพูดยึดมั่นรักษาคำพูดอย่างมั่นคงเสมอต้นเสมอปลาย</li>
                             <li>Moral & Ethic ตั้งมั่นในความถูกต้อง โปร่งใส ไม่มีอคติ วาระซ่อนเร้น ถือมั่นในกรอบของจรรยาบรรณแห่งวิชาชีพ ไม่บิดเบือนเพื่อประโยชน์ผู้ใด</li>
                             <li>Management by Fact  รวบรวม วิเคราะห์ ตรวจสอบข้อเท็จจริงประกอบการคิดพิจารณาและลงมือดำเนินการตามข้อเท็จจริง โดยหลีกเลี่ยงการอนุมาน</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             D Determination แน่วแน่ทำกล้าตัดสินใจ:
                         </th>
                         <td>
                             <li>Commitment & Faith รักและมีศรัทธาในงาน  มุ่งมั่น ทุ่มเททำงานที่ได้รับมอบหมาย หรือรับปากด้วยความจริงจัง จนเรียบร้อยตามกำหนดทุกครั้ง โดยไม่ต้องติดตามทวงถาม</li>
                             <li>Perseverance ตั้งใจ มานะ อดทน พากเพียร ด้วยความมั่นคงทั้งทางจิตใจ และร่างกายโดยไม่ท้อถอย เบื่อหน่ายหรือล้มเลิกความตั้งใจต่ออุปสรรคและความยากลำบาก</li>
                             <li>Achievement Oriented & Creating Value มุ่งสู่เป้าหมายความสำเร็จของงานที่รับผิดชอบ โดยถือเอาคุณภาพและมาตรฐานเป็นพื้นฐาน ใช้ความหมั่นเพียร และละเอียดรอบคอบในทุกขั้นตอน เพื่อสร้างคุณค่าเพิ่มให้แก่งาน</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             O Originalty สร้างสรรค์สิ่งใหม่:
                         </th>
                         <td>
                             <li>Courageous to be the Best กล้าคิด ริเริ่ม เสนอแนะ โดยมุ่งให้ได้ผลงานอันเป็นเลิศ เกินมาตรฐานหรือเป้าหมาย แม้ต้องทำงานละเอียดขึ้น หนักขึ้นบ้างก็ตาม</li>
                             <li>Driving into the Future กำหนดเป้าหมายในอนาคตที่ท้าทาย และ ดีกว่าที่ทำได้ในปัจจุบัน แก้ไข ปรับปรุงพัฒนาอย่างสม่ำเสมอ ให้บรรลุเป้าหมายนั้น</li>
                             <li>Novelty & Innovation คิด ริเริ่ม สร้างสรรค์ ปรับปรุง วิธีการใหม่ๆ หรือสร้างผลงานวิจัยที่แตกต่างโดดเด่น ช่วยให้การทำงานดีขึ้น หรือชี้นำสังคม</li>
                         </td>
                         </tr>
                         <tr >
                         <th >
                             L Leadership ใฝ่ใจเป็นผู้นำ:
                         </th>
                         <td>
                             <li>Calm & Certain จิตใจสงบ หนักแน่น และมั่นคง ทั้งในภาวะปกติและวิกฤติยากลำบาก ไม่ประหม่า ตื่นเต้น หรือเกรี้ยวกราด รวมทั้ง ฟัง   รวบรวมข้อมูล ไตร่ตรองด้วยความรอบคอบก่อนดำเนินการ</li>
                             <li>Influencing People สามารถใช้เหตุใช้ผล ประกอบกับวาทศิลป์ ในการโน้มน้าว จูงใจ สื่อสาร ให้ผู้เกี่ยวข้องเข้าใจ รวมถึงเป็นแบบอย่างที่ดี เพื่อให้ผู้อื่นเห็นด้วยและปฏิบัติตาม</li>
                             <li>Visioning ประมวลสถานการณ์ และข้อมูลปัจจุบันและอดีต นำมากำหนดภาพอนาคต หรือเป้าหมายที่ต้องการได้อย่างสมเหตุสมผล และท้าทาย</li>
                         </td>
                         </tr>
                         </table>
                       ");
        return _string.ToString();
    }

    public static string definitionA1A4()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                            <table class='table table-striped table-bordered' style='margin-top: 20px;'  >
                             <tr >
                             <th class='col-xs-4'>
                                 A 1 : ด้านคุณธรรม จริยธรรมและบำเพ็ญประโยชน์
                             </th>
                             <td class='col-xs-8'>
                                 ได้แก่ กิจกรรมที่มุ่งเน้นการเสริมสร้างจิตสำนึกด้านคุณธรรม จริยธรรม เช่น การส่งเสริมค่านิยมมหาวิทยาลัยมหิดล กิจกรรมทางศาสนาต่างๆ สร้างความมีจิตสำนึกสาธารณะเพื่อสังคมส่วนรวม เช่น สร้างอาคาร เผยแพร่ความรู้สู่ชุมชน บริการเพื่อชุมชน เป็นต้น
                             </td>
                             </tr>
                             <tr >
                             <th >
                                 A 2 : ด้านวินัยและทักษะสังคม วิชาชีพ วิชาการ และจิตตปัญญาศึกษา
                             </th>
                             <td>
                                 ได้แก่ กิจกรรมที่มุ่งเน้นการให้ความรู้ ทักษะและสร้างเสริมความมีวินัยทางสังคม หรือวิชาชีพ หรือวิชาการ เช่น กิจกรรมทางภาษา คอมพิวเตอร์ การติดต่อสื่อสาร และการพัฒนาบุคลิกภาพ ภาวะผู้นำ พฤติกรรมการแสดงออก ส่งเสริมประสบการณ์และจรรยาบรรณทางวิชาชีพ และจิตตปัญญาศึกษา เป็นต้น
                             </td>
                             </tr>
                             <tr >
                             <th >
                                 A 3 : ด้านศิลปวัฒนธรรม ภูมิปัญญาท้องถิ่น และค่านิยมที่ถูกต้อง
                             </th>
                             <td>
                                 ได้แก่ กิจกรรมที่เสริมสร้างความเข้าใจในความแตกต่างทางวัฒนธรรม เชื้อชาติ ภาษา กิจกรรมที่เผยแพร่ สืบสานศิลปวัฒนธรรม ภูมิปัญญาท้องถิ่น และการสร้างค่านิยมที่ถูกต้องบนวิถีความเป็นไทย
                             </td>
                             </tr>
                             <tr >
                             <th >
                                 A 4 : ด้านเสริมสร้างสุขภาพ
                             </th>
                             <td>
                                 ได้แก่ กิจกรรมที่ส่งเสริมและพัฒนาสุขภาพทั้งทางด้านร่างกายและจิตใจ เช่น กิจกรรมการออกกำลังกาย นันทนาการ กีฬา ทั้งเพื่อสุขภาพ และเพื่อความเป็นเลิศ เป็นต้น
                             </td>
                             </tr>
     
                             </table>
                            ");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-07
    /// Perpose: 
    /// Method : getListDefinitionTQF
    /// Sample : N/A
    /// </summary>
    public static string getListDefinitionTQF()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                        <table class='table table-striped table-bordered' style='margin-top: 20px;'  >
                         <tr >
                         <td class='col-xs-4'>
                             1. คุณธรรม/จริยธรรม
                         </td>
                         </tr>
                         <tr >
                         <td >
                             2. ความรู้
                         </td>
                         </tr>
                         <tr >
                         <td >
                             3. ทักษะทางปัญญา
                         </td>
                         </tr>
                         <tr >
                         <td >
                             4. ทักษะความสัมพันธ์ระหว่างบุคคลและความรับผิดชอบ
                         </td>
                         </tr>
                         <tr >
                         <td >
                             5. ทักษะการวิเคราะห์เชิงตัวเลข การสื่อสาร และการใช้เทคโนโลยีสารสนเทศ
                         </td>
                         </tr>
                         </table>
                       ");

        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-08
    /// Perpose: แสดงหน้ารายงานกราฟ Spiral Graph
    /// Method : getlistRptTQF
    /// Sample : N/A
    /// </summary>
    public static string getCharacterSummary(string _studentId, string _groupCharacterId, string _facultyId, string _programId, string _acaYear, string _semester)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getCharacterSummary(_studentId, _groupCharacterId, _facultyId, _programId, _acaYear, _semester);
        string _abbrevEn = "", _characterNameTh = "", _countAct = "";
        DataTable _dt = new DataTable();
        int _i = 0;

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

               // _abbrevEn = _dr["characterId"].ToString();
                _characterNameTh = _dr["characterNameTh"].ToString();
                _countAct = _dr["countAct"].ToString();
                _result.name[_i] = _characterNameTh;
                _result.data[_i] = Convert.ToDouble(_countAct);
                _i++;

            }
        }


        return JsonConvert.SerializeObject(_result);
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-08
    /// Perpose: 
    /// Method : getListDefinitionCenturySkill
    /// Sample : N/A
    /// </summary>
    public static string getListDefinitionCenturySkill()
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                         <table class='table table-striped table-bordered' style='margin-top: 20px;'  >
                         <tr >
                         <th class='col-xs-4' rowspan='5'>
                             Learning & Innovation Skills ทักษะการเรียนรู้และนวัตกรรม
                         </th>
                         <td class='col-xs-6'>
                         <li>Critical Thinking & Problem Solving การคิดเชิงวิพากษ์ และการแก้ปัญหา</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Creativity & Innovation ความคิดสร้างสรรค์และนวัตกรรม</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Communication & Collaboration การสื่อสารและการร่วมมือทำงาน</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Information, Media & Technology Skill ทักษะด้านข้อมูลสารสนเทศ สื่อ และเทคโนโลยี</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Leadership & Responsibility ความเป็นผู้นำและความรับผิดชอบ</li>
                         </td>
                         </tr>

                          <tr >
                         <th class='col-xs-4' rowspan='4'>
                             Life & Career Skills ทักษะชีวิตและการทำงาน

                         </th>
                         <td class='col-xs-6'>
                         <li>Flexibility & Adaptability ความยืดหยุ่นและความสามารถในการปรับตัว </li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Initiative & Self-Direction ความคิดริเริ่มและการชี้นำตนเอง</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Social & Cross-Cultural Skills ทักษะทางสังคมและการเรียนรู้ข้ามวัฒนธรรม</li>
                         </td>
                         </tr>
                         <tr >
                         <td >
                         <li>Productivity & Accountability การเพิ่มผลผลิตและความรับรู้รับผิด</li>
                         </td>
                         </tr>
                         </table>
                       ");

        return _string.ToString();
    }



    public static string getListMainFeedContent(string _menuVal)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListPublicEventPicture(_menuVal,"","","","","","","","2","","",""); 
        string _projectId = "", _pictureName = "", _projectNameTh = "";
        string _projectNameEn = "", _projectDetail="";
        string _startDate = "", _endDate = "";
        string _instituteNameTh = "", _instituteNameEn = "";
        string _createdDate = "";
        DataTable _dt = new DataTable();
        int _i = 0;
        _string.Append("</br></br>");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectId = _dr["projectId"].ToString();
                _pictureName = _dr["pictureName"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _projectDetail = _dr["projectDetail"].ToString();
                _startDate = _dr["startDate"].ToString();
                _endDate= _dr["endDate"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _createdDate = _dr["createdDate"].ToString();
                if (_i < 5)
                {
                    _string.Append(" <div style = \"background-image:url('../../images/" + _pictureName + "');color:azure;text-shadow:2px 2px dimgray;\" >" + @"
                                    </br>
                                    <h1 class='display-3'>
                                        <span >" + _projectNameTh + @"</span>
                                        <span class='label label-default'>" + _startDate + @"</span>
                                    </h1>
                                    <p class='lead'>" + _projectDetail + @"</p>
                                    <p><a class='btn btn-lg btn-info' href='#' role='button'>Sign up to join Activity</a></p>
                                </div>");
                }
                else
                {


                }
                _i++;

            }
        }
       
        //_string.Append("  <div style = \"background-image:url('../../images/event2.jpg'); color:azure; text-shadow: 2px 2px dimgray; width:100%; height:100%; \" >" + @"
        //                                             </br>
        //                            <h1 class='display-3'>
        //                                <span >Sing with professtional</span>
        //                                <span class='label label-default'>12 May 2018</span>
        //                            </h1>
        //                            <p class='lead'>Sometimes contextual classes cannot be applied due to the specificity of another selector.In some cases, a sufficient workaround is to wrap your element’s content.</p>
        //                            <p><a class='btn btn-lg btn-info' href='#' role='button'>Sign up to join Activity</a></p>
        //                        </div>
        //        ");
        return _string.ToString();
    }

    public static string getListSubFeedContent(string _menuVal,string _publicEventName,string _ddlFaculty, string _dateStart, string _dateEnd, string _ddlProjectStatus,string _statusPublicEvent,string _ddlFacultyText , string _ddlProjectStatusText,string _panelSearchVal,string _ddlGroupIndicatorText,string _ddlGroupIndicator,string _ddlIndicator,string _ddlSubIndicator)
    {
        // _statusPublicEvent 
        // = 0 กิจกรรมใหม่
        // = 1 กิจกรรมที่เปิดรับสมัคร
        // = 2 กิจกรรมที่ค้นหา

        // _panelSearchVal
        // = 1 ค้นหาตามชื่อกิจกรรม
        // = 2 ค้นหาตามช่วงเวลาการจัดกิจกรรม
        // = 3 ค้นหาตามสถานะกิจกรรม
        // = 4 ค้นหาจำแนกตามหน่วยงาน
        // = 5 ค้นหาจำแนกตามตัวชี้วัด

        Login _login = new Login("student");
        string _studentId = _login.StudentId;
        //_studentId = "";
        string _statusPublicEventNameTh = "";
        string _textConditionSearch = "";
        string _textSubSearch = "";
        if (_statusPublicEvent == "0")
        {
            _statusPublicEventNameTh = "<span class='th'>กิจกรรมใหม่</span><span class='en'>New activity</span>";
        }
        else if (_statusPublicEvent == "1")
        {
            _statusPublicEventNameTh = "<span class='th'>กิจกรรมที่เปิดรับสมัคร</span><span class='en'>Recruitment activities</span>";
        }
        else if (_statusPublicEvent == "2")
        {
            _statusPublicEventNameTh = "<span class='th'>กิจกรรมที่ค้นหา</span><span class='en'>Search Activity</span>";
            if (_panelSearchVal == "1")
            {
                _textSubSearch = _publicEventName;
            }
            else if (_panelSearchVal == "2")
            {
                _textSubSearch = _dateStart + " - " + _dateEnd;
            }
            else if (_panelSearchVal == "3")
            {
                _textSubSearch = _ddlProjectStatusText;
            }
            else if (_panelSearchVal == "4")
            {
                _textSubSearch = _ddlFacultyText;
            }
            else if (_panelSearchVal == "5")
            {
                _textSubSearch = _ddlGroupIndicatorText;
            }
            _textConditionSearch = "<small>Search : <span class='label label-info'>" + _textSubSearch + "</span></small>";
        }
        else
        {
            _statusPublicEvent = "1";
            _statusPublicEventNameTh = "<span class='th'>กิจกรรมที่เปิดรับสมัคร</span><span class='en'>Recruitment activities</span>";
        }
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListPublicEventPicture(_menuVal,"","", _publicEventName, _ddlFaculty, _dateStart, _dateEnd, _ddlProjectStatus, _statusPublicEvent, _ddlGroupIndicator, _ddlIndicator, _ddlSubIndicator);
        string _projectId = "", _pictureName = "", _projectNameTh = "";
        string _projectNameEn = "", _projectDetail = "";
        string _startDate = "", _endDate = "";
        string _instituteNameTh = "", _instituteNameEn = "";
        string _createdDate = "", _dateStartAndEndActs="";
        string _dateStartAndEndRecruit = "";
        string _expressionFaculty = "";
        string _expressionClassYear = "";
        string _expressionStudentCode = "";
        string _displayExpress = "";
        string _projectShortNameEn = "";
        DataTable _dt = new DataTable();
        int _i = 0,_j=1;
        int _isFoundPic = 0;
    
        _string.Append("<h2 style='text-shadow: 1px 1px grey;'>"+ _statusPublicEventNameTh + " "+ _textConditionSearch + @"</h2>");
        _string.Append("</br>");

        

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectId = _dr["projectId"].ToString();
                _pictureName = _dr["pictureName"].ToString();
                _projectNameTh = _dr["projectShortNameTh"].ToString();
                _projectShortNameEn = _dr["projectShortNameEn"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _projectDetail = _dr["projectShortDetail"].ToString();
                _startDate = _dr["startDate"].ToString();
                _endDate = _dr["endDate"].ToString();
                _dateStartAndEndActs = _dr["dateStartAndEndActs"].ToString();
                
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _createdDate = _dr["createdDate"].ToString();
                _dateStartAndEndRecruit = _dr["dateStartAndEndRecruit"].ToString();

                _expressionFaculty = _dr["expressionFaculty"].ToString();
                _expressionClassYear = _dr["expressionClassYear"].ToString();
                _expressionStudentCode = _dr["expressionStudentCode"].ToString();

                _displayExpress = "<p align = 'left' >";

                if (_expressionFaculty != "")
                {
                    _displayExpress += "<span style = 'color:red;' ><small><strong> <span class='th'>เฉพาะคณะ</span><span class='en'>For faculty</span> : " + _expressionFaculty + " </strong></small></span>";
                }
                else{
                    _expressionFaculty = "";
                }

                if (_expressionClassYear != "")
                {
                    _displayExpress += "<span style = 'color:red;' ><small><strong> <span class='th'>เฉพาะชั้นปี</span><span class='en'>For Class</span> : " + _expressionClassYear + " </strong></small></span>";
                }
                else
                {
                    _expressionClassYear = "";
                }

                if (_expressionStudentCode != "")
                {
                    _displayExpress += "<span style = 'color:red;' ><small><strong> <span class='th'>เฉพาะรหัส</span><span class='en'>For StudentId</span> : " + _expressionStudentCode + " </strong></small></span>";
                }
                else
                {
                    _expressionStudentCode = "";
                }


                _displayExpress += "</p>";

                //if (_i >= 5)
                //{
                if (_j % 3 == 0)
                {
                        _string.Append("<div class='row'>");
                }

                //_string.Append(@" <div class='col-lg-3'>

                //                      <div >
                //                        <div class='thumbnail'>
                //                          <img style = 'height:100%;width:100%;' src='../../images/" + _pictureName + @"'  >
                //                          <div class='caption' style='height:200px;'>
                //                            <h4 style='height:70px;'><b>" + _projectNameTh + @"</b>
                //                            <span class='label label-default'>" + _startDate + @"</span>
                //                            </h4>
                //                            <p style='height:78px;'>" + _projectDetail + @"</p>
                //                                <p align='center'>
                //                                <ul class='nav nav-pills'>
                //                                  <li>
                //                                    <a href = '' >
                //                                      <span class='glyphicon glyphicon-hand-up'></span> Register
                //                                     </a>
                //                                  </li>
                //                                  <li>
                //                                    <a href = '' >
                //                                      <span class='glyphicon glyphicon-info-sign'></span> Detail
                //                                     </a>
                //                                  </li>
                //                                </ul>
                //                             </p>
                //                            </div>

                //                      </div>
                //                    </div>
                //                </div>");

                // ขึ้น Server แล้วพัง
                //string[] fileArray = Directory.GetFiles(@"D:\JATE Backup\Project\ActivityTranscript\images\", _pictureName, SearchOption.AllDirectories);
                //_isFoundPic = fileArray.Length;
                //if (_isFoundPic == 0)
                //{
                //    _pictureName = "imageNotFound.jpg";
                //}


                _string.Append(@" <div class='col-lg-3'>
                                       
                                          <div >
                                            <div class='thumbnail'>
                                              <img class='btnLoadDetailProjectPublic  img-fluid img-thumbnail'  data-datestart='" + _dateStart + "' data-dateend='" + _dateEnd + "' data-ddlprojectstatus='" + _ddlProjectStatus + "'   data-projectid='" + _projectId + "' data-publiceventname='" + _publicEventName + "' data-facultyid='" + _ddlFaculty + "' style = 'cursor:pointer;' src='../../images/" + _pictureName + @"'  >
                                              <div class='caption' >
                                                <h4 style='height:70px;'><b><span class='th'>" + _projectNameTh + "</span><span class='en'>"+ _projectShortNameEn + @"</span></b>
                                                </h4>
                                                
                                                 <p align='left'> <span class='label label-primary'><span class='th'>วันที่รับสมัคร</span><span class='en'>Application date</span> : " + _dateStartAndEndRecruit + @"</span></p>
                                                 <p align='left'> <span class='label label-default'><span class='th'>วันที่จัดกิจกรรม</span><span class='en'>Event date</span> : " + _dateStartAndEndActs + @"</span></p>

                                                 <p class='text-center'>
                                                    
                                                    <ul class='nav nav-pills'>
                                                      <li>
                                                           <button type = 'button' class='btn btn-sm btnRegister btn-default' data-studentid='"+ _studentId + "' data-projectid='" + _projectId + @"'>
                                                              <span class='glyphicon glyphicon-hand-up'></span> Register
                                                            </button>
                                                      </li>
                                                      <li>
                                                        <button type = 'button' class='btn btn-sm btnLoadDetailProjectPublic  btn-default' data-datestart='" + _dateStart + "' data-dateend='" + _dateEnd + "' data-ddlprojectstatus='" + _ddlProjectStatus + "'   data-projectid='" + _projectId + "' data-publiceventname='" + _publicEventName + "' data-facultyid='"+ _ddlFaculty + "' >");
                // onclick=loadDetailProjectPublic('" + _projectId + "','" + _publicEventName + "');

                _string.Append(@"<span class='glyphicon glyphicon-info-sign '></span> Detail
                                                            </button>
                                                      </li>
                                                    </ul>
     
                                                 </p>
                                                " + _displayExpress + @"
 

                                                </div>
                    
                                          </div>
                                        </div>
                                    </div>");
                    //<button type = 'button' class='btn btn-sm'>
                    //  <span class='glyphicon glyphicon-star'></span> Register
                    //</button>
                    // <p><a href = '#' class='btn btn-primary' role='button'>Join us</a> <a href = '#' class='btn btn-default' data-toggle='modal' data-target='#myModal' role='button'>Detail</a></p>

                    if (_j % 3 == 0)
                    {
                        _string.Append("</div>");
                    }
                    _j++;

                //}
                //else
                //{

                //}
                _i++;

            }
        }
        else
        {
            _string.Append("<div class='col-lg-3'>ไม่พบข้อมูลที่ค้นหา</div>");

        }

        //_string.Append(@"<footer class='footer'>
        //                    <p>Copyright &copy; 2018 Mahidol University.All rights reserved.</p>
        //                  </footer>");
        return _string.ToString();
    }


    public static string getListProjectDetailPublic(string _projectId,string _studentId,string _publicEventName,string _ddlFaculty, string _dateStart, string _dateEnd, string _ddlProjectStatus)
    {

        string _pictureName = "", _placeSection="";
        string _dataStrIndicator = "";
        int _isFoundPic = 0;
        string _startDateTh = "", _endDateTh="";
        string _sectionNameTh = "";
        string _sectionNameEn = "";
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListPublicEventPicture("", _projectId, _studentId,"", _ddlFaculty, _dateStart, _dateEnd, _ddlProjectStatus, "2","","","");
        string _projectNameTh = "";
        string _fileNameSection = "";
        string _place = "", _projectDetail = "";
        string _startDate = "", _endDate = "";
        string _instituteNameTh = "", _instituteNameEn = "";
        string _createdDate = "", _dateStartAndEndActs = "";
        string _projectStatusNameTh = "";
        string _countLikeProject = "";
        string _colorLike = "";
        string _studentLike = "";
        string _projectIdDB = "";
        string _fileName = "";
        string _filefileTopic = "";
        string _projectNameEn = "";
        string _projectStatusNameEn = "";
        string _projectDetailEn = "";
        _string.Append("</br>");

        // DataRow[] _drAll = _ds.Tables[0].Select("projectId='" + _projectId + "'");
        // int _row = _drAll.Length;

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectIdDB = _dr["projectId"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _pictureName = _dr["pictureName"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                _projectDetail = _dr["projectDetail"].ToString();
                _projectDetailEn = _dr["projectDetailEn"].ToString();
                _countLikeProject = _dr["countLikeProject"].ToString();
                _studentLike = _dr["studentLike"].ToString();
                _projectStatusNameTh = _dr["projectStatusNameTh"].ToString();
                _projectStatusNameEn= _dr["projectStatusNameEn"].ToString();

                //string[] fileArray = Directory.GetFiles(@"D:\JATE Backup\Project\ActivityTranscript\images\", _pictureName, SearchOption.AllDirectories);
                //_isFoundPic = fileArray.Length;
                //if (_isFoundPic == 0)
                //{
                //    _pictureName = "imageNotFound.jpg";
                //}
                // img - fluid img - thumbnail  width:95%;height:280px;
                _string.Append(@"<div class='row'>
                            <div id = 'divProjectImageCover'  class='col-lg-5 text-center'>
                                <p><img class='img-fluid img-thumbnail shadow' src='../../images/" + _pictureName + @"' />
                                </p>
                                    <p><button type = 'button' class='btn btn-sm btnRegister btn-default' data-studentid='"+ _studentId + "'  data-projectid='" + _projectIdDB + @"'>
                                   <span class='glyphicon glyphicon-hand-up'></span> Register
                                 </button></p>
                            </div>
                            <div id = 'divProjectPlace'  class='col-lg-7' style='color:#504d4d;'  >
                                  <p><h2><b><span class='th'>" + _projectNameTh + "</span><span class='en'>"+ _projectNameEn + @"</span></b>
                                  </h2></p>
                                <hr>
                                <p><h4><b><span class='th'>ส่วนงานผู้จัด</span><span class='en'>Institute</span> :</b> <span class='th'>" + _instituteNameTh + "</span><span class='en'>"+ _instituteNameEn + @"</h4></p>
                                <p><h4><b><span class='th'>สถานะของโครงการ</span><span class='en'>Status</span> :</b> <span class='label label-success'><span class='th'>" + _projectStatusNameTh + "</span><span class='en'>" + _projectStatusNameEn + @"</span></span></h4></p>
                                <p>
                                <h4><b><span class='th'>เอกสารประกอบโครงการ</span><span class='en'>Documentation</span> : ");
                  DataSet _dsFileUpload = ActDB.getListProjectPicture(_projectId);
                  DataRow[] _drRowFileUpload = _dsFileUpload.Tables[0].Select("fileTypeId = 'UPT-004'");
                  int _rowFile = _drRowFileUpload.Length;
                  if (_rowFile > 0)
                  {
                      for (int _i = 0; _i < _rowFile; _i++)
                      {

                        _fileName = _drRowFileUpload[_i]["fileName"].ToString();
                        _filefileTopic = _drRowFileUpload[_i]["fileTopic"].ToString();
                        _string.Append(@"<a href= '../../images/"+_fileName+"' class='small' style='color:blue;' >"+ _filefileTopic + "</a>");
                        //<a href='../../images/ใบรับรองการผ่านกิจกรรม_AT_ใหม่_4 ด้าน.docx' class='small' style='color:blue;' >Download</a></h4>
                    }
                  }
                else
                {
                    _string.Append(@"-");
                }

                 _string.Append(@"</b></h4></p>
                               
                  <p class='text-center'>");

                if (Convert.ToInt16(_studentLike) > 0)
                {
                    _colorLike = "color:blue;";
                }
                else
                {
                    _colorLike = "color:black;";
                }

                _string.Append("<span class='glyphicon glyphicon-thumbs-up btnLikeProject' style='cursor:pointer;"+ _colorLike + "'  data-studentid='" + _studentId + "' data-studentlike='"+ _studentLike + "' data-projectid='" + _projectId + "' ></span> <strong>" + _countLikeProject + "</strong>");

                //<button type = 'button' class='btn btn-sm btn-default'  >
                //  <span class='glyphicon glyphicon-thumbs-up' style='color:pink;'></span> ถูกใจ
                //</button>

                _string.Append("&nbsp;&nbsp;&nbsp;&nbsp;<span class='glyphicon glyphicon-link btnCopyLinkProject'  data-projectid='" + _projectId + "' style='color:black;cursor:pointer;' ></span> <strong><span class='th'>แชร์</span><span class='en'>Share</></strong>");
                //<button type = 'button' class='btn btn-sm btn-default' >
                //    <span class='glyphicon glyphicon-link'></span> แชร์
                //  </button>
                _string.Append(@"</p>
                          
                            </div>
                        </div>");

                _string.Append(@"<div id = 'divProjectDatePeriod'  class='row'>
                                            <h4><span class='glyphicon glyphicon-bullhorn' style='color:#504d4d;'></span> <span class='th'>ช่วงเวลาที่จัดกิจกรรม</span><span class='en'>Event period</span></h4>
                                             <table class='table table-striped'>
                                              <tr>
                                              <th style='width:32%;'><span class='th'>ชื่อ Section</span><span class='en'>Section Name</span></th>
                                              <th><span class='th'>วันเวลาที่เริ่มกิจกรรม</span><span class='en'>Date of activity start</span></th>
                                              <th><span class='th'>วันเวลาที่สิ้นสุดกิจกรรม</span><span class='en'>Date of activity end</span></th>
                                              <th><span class='th'>สถานที่</span><span class='en'>Place</span></th>
                                              <th><span class='th'>หน่วยชม.ที่ได้รับ</span><span class='en'>Hours received</span></th>
                                              </tr>");
                DataSet _ds2 = ActDB.getListSection(_projectId, _studentId);
                if (_ds2.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr2 in _ds2.Tables[0].Rows)
                    {

                        _startDateTh = _dr2["startDateTh"].ToString();
                        _endDateTh = _dr2["endDateTh"].ToString();
                        _placeSection = _dr2["place"].ToString();
                        _dataStrIndicator = _dr2["dataStrIndicator"].ToString();
                        _sectionNameTh = _dr2["sectionNameTh"].ToString();
                        _sectionNameEn = _dr2["sectionNameEn"].ToString();
                        _string.Append(@"<tr><td><span class='th'>" + _sectionNameTh + "</span><span class='en'>" + _sectionNameEn + "</span></td><td>" + _startDateTh + "</td><td>" + _endDateTh + "</td><td>" + _placeSection + "</td><td>" + _dataStrIndicator + "</td></tr>");
                    }
                }
                else
                {
                    _string.Append(@"<tr><td>-</td><td>-</td><td>-</td></tr>");
                }
                _string.Append(@"</table>
                            </div>
                            <div id = 'divProjectGallery'  class='row'>
                                    <h4><span class='glyphicon glyphicon-picture' style='color:#504d4d;'></span> <span class='th'>ภาพกิจกรรม</span><span class='en'>Gallery</span></h4>
                                     <div class='row'>");

                DataSet _ds3 = ActDB.getListProjectPicture(_projectId);
                // ไม่ดึงรูปแรกมาแสดงคือรูปที่เป็นประเภท Cover นะ
                DataRow[] _drRow = _ds3.Tables[0].Select("isnull(fileTypeId,'') <> 'UPT-001'");
                int _row = _drRow.Length;
                if (_row > 0)
                {
                    for (int _i = 0; _i < _row; _i++)
                    {

                        _fileNameSection = _drRow[_i]["fileName"].ToString();
                        _string.Append(@"<div style='height:180px;'  class='col-lg-3 col-md-4 col-xs-6 thumb'>
                                            <a class ='thumbDrillDown'  href='#' data-image-id='' data-toggle='myModal' data-title=''
                                               data-image='../../images/" + _fileNameSection + @"'
                                               data -target='#image-gallery'>
                                                <img style='height:100%;width:100%;' class='img-thumbnail'
                                                     src='../../images/" + _fileNameSection + @"'
                                                     alt='Another alt text' />
                                            </a>
                              </div>");
                    }
                }
                else
                {
                    _string.Append(@"<div style='height:180px;' class='col-lg-3 col-md-4 col-xs-6 thumb'>
                                            <a class ='thumbDrillDown'   href='#' data-image-id='' data-toggle='myModal' data-title=''
                                               data-image='../../images/imageNotFound.jpg'
                                               data-target='#image-gallery'>
                                                <img style='height:100%;width:100%;' class='img-thumbnail'
                                                     src='../../images/imageNotFound.jpg'
                                                     alt='Another alt text' />
                                            </a>
                              </div>");
                }




                // onclick=window.open('studentPublicEvent.aspx','_self');   SearchPublicEvent();
                _string.Append(@"      </div>
                                </div>

                                <div id = 'divProjectDetail' class='row'>
                                    <h4><span class='glyphicon glyphicon-th-list' style='color:#504d4d;'></span> <span class='th'>รายละเอียดกิจกรรม</span><span class='en'>Detail</span></h4>
                                     <hr>
                                    <p><BLOCKQUOTE><span class='th'>" + _projectDetail + "</span><span class='en'>" + _projectDetailEn + @"</span></BLOCKQUOTE></p>
                                    <p align = 'center' ><button type='button' class='btn btn-sm btn-default' onclick = window.open('studentPublicEvent.aspx','_self');>
                                                <span class='glyphicon glyphicon-home'></span> Home
                                              </button>
           
                                              <button type = 'button' class='btn btn-sm btn-default btnRegister btn-default' data-studentid='" + _studentId + "' data-projectid='" + _projectIdDB + @"' >
                                                <span class='glyphicon glyphicon-hand-up'></span> Register
                                              </button></p>
                                 </div>");
            }
        }
        return _string.ToString();

    }

    public static string loadRegisterPage(string _isAuthen, string _projectId,string _studentId)
    {
        // string _projectId = "PJR256000211";
        // _isAuthen = "false";

        string _startDateTh = "", _endDateTh = "", _placeSection = "", _projectNameTh = "";
        string _dataStrIndicator = "", _amountMax = "", _countStudentSection = "";
        string _html = "";
        string _htmlBody = "";
        string _sectionId = "";
        string _stsJoinSection = "";
        string _btnText = "";
        string _projectStatusId = "";
        string _projectStartDateRecruit = "";
        string _stsDateNowJoinActt = "";
        string _isExpressionFaculty = "", _isExpressionClass = "", _isExpressionStudentCode = "";
        string _registrationFee = "";
        string _txtRegistrationFee = "";
        string _columnHeadQRPaid = "";
        string _columnBodyQRPaid = "";
        string _isEntranceAct = "";
        string _paidStatus = "";
        string _invoiceId = "";
        string _projectNameEn = "";
        string _sectionNameTh = "";
        string _sectionNameEn = "";
        bool _isOverRegister;
        StringBuilder _string = new StringBuilder();
        if (_isAuthen == "true")
        {
            DataSet _ds2 = ActDB.getListSection(_projectId, _studentId);
            if (_ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _dr2 in _ds2.Tables[0].Rows)
                {
                    _sectionId = _dr2["id"].ToString();
                    _projectNameTh = _dr2["projectNameTh"].ToString();
                    _projectNameEn = _dr2["projectNameEn"].ToString();
                    _sectionNameTh = _dr2["sectionNameTh"].ToString();
                    _sectionNameEn = _dr2["sectionNameEn"].ToString();
                    _startDateTh = _dr2["startDateTh"].ToString();
                    _endDateTh = _dr2["endDateTh"].ToString();
                    _placeSection = _dr2["place"].ToString();
                    _dataStrIndicator = _dr2["dataStrIndicator"].ToString();
                    _amountMax = _dr2["amountMax"].ToString();
                    _countStudentSection = _dr2["countStudentSection"].ToString();
                    _stsJoinSection = _dr2["stsJoinSection"].ToString();
                    _projectStatusId = _dr2["projectStatusId"].ToString();
                    _projectStartDateRecruit = _dr2["projectStartDateRecruit"].ToString();
                    _stsDateNowJoinActt = _dr2["stsDateNowJoinAct"].ToString();
                    _isExpressionFaculty = _dr2["isExpressionFaculty"].ToString();
                    _isExpressionClass = _dr2["isExpressionClass"].ToString();
                    _isExpressionStudentCode = _dr2["isExpressionStudentCode"].ToString();
                    _registrationFee = _dr2["registrationFee"].ToString();
                    _isEntranceAct = _dr2["isEntranceAct"].ToString();
                    _paidStatus = _dr2["paidStatus"].ToString();
                    _invoiceId = _dr2["invoiceId"].ToString();
                   


                    if (_registrationFee != "") // กรณีโครงการที่มีการเรียกเก็บเงินจะมี Remark นี้ขึ้นมา
                    {
                        _registrationFee = String.Format("{0:#,##0}", Convert.ToDouble(_registrationFee));
                        _txtRegistrationFee = "</br><span style='color:red;font-size:13px;'>" +
                            "<span class='th'>* ค่าลงทะเบียน "+ _registrationFee +" บาท</span>" +
                            "<span class='en'>* Register fee " + _registrationFee + " baht</span>" +
                            "</span>";
                    }

                    if (_isEntranceAct == "1") // เดิม _isEntranceAct = 1 // กรณีเข้าร่วมโครงการแล้ว จะมีสถานะ QR Payment ขึ้นมา อีก 1 คอลัมน์
                    {
                        _columnHeadQRPaid = "<th><span class='th'>การชำระเงิน</span><span class='en'>Paid</span></th>";
                        if (_paidStatus == "Y")
                        {
                            _columnBodyQRPaid = "<td><a class='bold btnQRPayment' data-invoiceid='" + _invoiceId + "' data-sectionid='" + _sectionId + "'  style='color:green;' href='#'><span class='glyphicon glyphicon-saved' style='color:green;' ></span> ชำระเงินแล้ว</a></td>";
                        }
                        else
                        {
                            _columnBodyQRPaid = "<td><button type='button' class='btn btn-warning btnQRPayment' data-invoiceid='" + _invoiceId + "' data-sectionid='" + _sectionId + "' ><span class='glyphicon glyphicon-bitcoin' ></span> QR Payment</button></td>";
                        }
                    }
                    else {
                        _columnBodyQRPaid = "<td></td>";
                    }
                  

                    if (Convert.ToInt32(_countStudentSection) >= Convert.ToInt32(_amountMax))
                    {
                        _isOverRegister = true;
                    }
                    else
                    {
                        _isOverRegister = false;
                    }

                    // isexpressionfaculty  isexpressionclass  isexpressionstudentcode
                    if (_paidStatus == "Y")
                    {
                        _btnText = "<a class='bold' style='color:green;' ><span class='glyphicon glyphicon-saved' style='color:green;' ></span> <span class='th'>เข้าร่วมแล้ว</span><span class='en'>Joined</span></a>";
                    }
                    else if (_stsJoinSection == "1")
                    {
                        _btnText = "<button type='button' class='btn btn-danger btnSetCancelJoinProjectSection' data-sectionid='" + _sectionId + "' data-projectid='" + _projectId + "' data-invoiceid='" + _invoiceId + "' ><span class='th'><span class='th'>ยกเลิก</span><span class='en'>Cancel</span></button>";
                    }
                    else if (_isOverRegister)
                    {
                        _btnText = "<button type='button' class='btn btn-default' disabled><span class='th' style='color:red;'><b>เต็มแล้ว</b></span><span class='en' style='color:red;'><b>full</b></span></button>";
                    }
                    else if (_stsJoinSection == "0")
                    {
                        _btnText = "<button type='button' class='btn btn-primary btnSetJoinProjectSection' data-isexpressionstudentcode='" + _isExpressionStudentCode + "' data-isexpressionclass='" + _isExpressionClass + "' data-isexpressionfaculty='" + _isExpressionFaculty + "' data-stsdatenowjoinact='" + _stsDateNowJoinActt + "' data-sectionid='" + _sectionId + "' data-projectid='" + _projectId + "' data-isoverregister='" + _isOverRegister + "' data-projectstatusid='" + _projectStatusId + "' data-projectstartdaterecruit='" + _projectStartDateRecruit + "' ><span class='th'>เข้าร่วม</span><span class='en'>join us</span></button>";
                    }
                    else {
                        _btnText = "";
                    }
                   
                   
                    

                    _htmlBody += @" <tr><td><span class='th'>"+ _sectionNameTh + "</span><span class='en'>"+ _sectionNameEn + "</span></td><td>" + _startDateTh + "</td><td>" + _endDateTh + "</td><td>" + _placeSection + "</td><td>" + _dataStrIndicator + "</td><td align='center'>" + _countStudentSection + "/" + _amountMax + "</td><td>" +
                                    _btnText + _txtRegistrationFee + _columnBodyQRPaid  +
                                  " </td></tr>";

                }
            }
            else
            {
                _htmlBody += @"<tr><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
            }
            _htmlBody += @"</table>
                            </div></p>";
            _html = @"<p><div class='row container-fluid' >
                                <h4><span class='glyphicon glyphicon-bullhorn' style='color:#504d4d;'></span> <span class='th'>กิจกรรม</span><span class='en'>Activity</span> <span class='th'>" + _projectNameTh + "</span><span class='en'>"+ _projectNameEn + @"</span></h4>
                                 <table class='table table-striped'>
                                  <tr>
                                  <th style='width:32%;'><span class='th'>ชื่อ Section</span><span class='en'>Section Name</span></th>
                                  <th ><span class='th'>วันเวลาที่เริ่มกิจกรรม</span><span class='en'>Start Date</span></th>
                                  <th><span class='th'>วันเวลาที่สิ้นสุดกิจกรรม</span><span class='en'>End Date</span></th>
                                  <th><span class='th'>สถานที่</span><span class='en'>Place</span></th>
                                  <th><span class='th'>หน่วยชม.ที่ได้รับ</span><span class='en'>Hour.</span></th>
                                  <th><span class='th'>จำนวนที่สมัคร/จำนวนที่รับ</span><span class='en'>Amount registered/Amount Received</span></th>
                                  <th><span class='th'>สถานะ</br>การเข้าร่วมกิจกรรม</span><span class='en'>Action</span></th>" + _columnHeadQRPaid + "</tr>";

        }
        else
        {
            _htmlBody = messageNoAuthen();
        }

        _string.Append(_html + _htmlBody);
        return _string.ToString();

    }


    public static string loadCopyLinkProjectPage(string _projectId,string _path)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListPublicEventPicture("", _projectId, "","","","","","","2","","","");
        string _projectNameTh = "", _projectNameEn="";
        _string.Append("</br>");
        

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
            }
        }

        string _html = @"<p><div class='row container-fluid' >
                               <span class='th'><b>ชื่อโครงการ :</b> "+ _projectNameTh + @"</span>
                               <span class='en'><b>Project Name :</b> " + _projectNameEn + @"</span>
                               <textarea id='txtCopyLink' style='width:98%;' rows='3'>" + _path + "</textarea>" + @"
                               <div class='col-sm text-center'><button type='button' class='btn btn-default btnCopyLinkProject'>Copy</button></div></div></p>";
        _string.Append(_html);
        return _string.ToString();

    }

    public static string messageNoAuthen()
    {

        string _html = @"<p>กรุณา Login เข้าระบบ SmartEdu ของมหาวิทยาลัยเพื่อใช้งาน MU Activity Transcript</p>
                         <p><a href='https://smartedu.mahidol.ac.th/authen/login.aspx' target='_self' >https://smartedu.mahidol.ac.th/authen/login.aspx</a></p>"; //                          <p><button type='button' class='btn btn-default' onclick=cookiesPageAt();> Login</button> </p>

        return _html;

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-08
    /// Perpose: แสดงรายการข้อมูลคณะ
    /// Method : getListFaculty
    /// Sample : N/A
    /// </summary>
    public static string getListFacultyNoLabel(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListFaculty(_facultyId);
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@"<select class='form-control ddlFaculty' >");
            if (_facultyId == "MU-01")
            {
                _string.Append("<option value=''>ทุกคณะ</option>");
            }
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "'  >" + _dr["facultyCode"] + " - " + _dr["nameTh"] + "</option>");
            }




            _string.Append(@"</select>");
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
    public static string getListProjectStatusNoLabel(string _projectStatusId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectStatus();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@"   <select class='form-control ddlProjectStatus' >
                                <option value=''>ทุกสถานะของโครงการ</option>");
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
    //    /// <summary>
    //    /// Auther : เจตน์ เครือชะเอม
    //    /// Date   : 2017-07-05
    //    /// Perpose: แสดงหน้าจอเงื่อนไขสำหรับที่จะค้นหาโครงการ
    //    /// Method : getListSearchForProjectActive
    //    /// Sample : N/A
    //    /// </summary>
    //    public static string getListSearchForProjectActive()
    //    {

    //        StringBuilder _string = new StringBuilder();
    //        _string.Append(@" < div id='divProjectListActive'>  <h1 class='page-header'>
    //                                กิจกรรมทั้งหมดที่เปิดรับสมัคร</h1>");
    //        _string.Append(@"  </br><div class='row '>
    //                                      <div class='form-group col-xs-8 '>
    //                                      </div>
    //                                      <div class='form-group col-xs-4 '>
    //                                        
    //                                     
    //                                        <div class='input-group'>
    //                                          <input type='text' class='form-control txtProjectName' placeholder='ค้นหาด่วนด้วยชื่อโครงการ'>
    //                                          <span class='input-group-btn'>
    //                                            <button class='btn btn-secondary ' type='button'> ค้นหา</button>
    //                                          </span>
    //                                        </div>
    //
    //                                     </div>
    //
    //                                </div>");
    //        _string.Append(@"</div>");

    //        //_string.Append("<button type='button' class='btn btn-primary btn-block btn-md btnAddNewProject glyphicon glyphicon-plus'> เพิ่มโครงการใหม่</button>  ");
    //        //_string.Append("<button type='button' class='btn btn-info btn-block btn-md btnSearchProjectMain glyphicon glyphicon-search'> ค้นหา</button>");
    //        return _string.ToString();

    //    }


    //     //<summary>
    //     //Auther : เจตน์ เครือชะเอม
    //     //Date   : 2017-07-05
    //     //Perpose: แสดงหน้าจอสำหรับดึงโครงการที่ Active มาแสดง
    //     //Method : getListProjectActive
    //     //Sample : N/A
    //     //</summary>
    //    public static string getListProjectActive()
    //    {
    //        string _acaYear = (DateTime.Now.Year+543).ToString();
    //        DataSet _ds = ActDB.getListProjectActive(_acaYear);
    //        int _i = 1;
    //        int _count = _ds.Tables[0].Rows.Count;
    //        StringBuilder _string = new StringBuilder();
    //       _string.Append(@"<div id='divProjectListActive'>  <h1 class='page-header'>
    //                                กิจกรรมทั้งหมดที่เปิดรับสมัคร</h1>");
    //       _string.Append(@" <table id='tblProjectList' class='table display' cellSpacing='0' width='100%' >
    //                <caption><h4>รายการโครงการทั้งหมด 2 รายการ</h4></caption>
    //                <thead>
    //                <tr>
    //                <th >
    //                ลำดับ
    //                </th>
    //                <th >
    //                ชื่อโครงการ
    //                </th>
    //                <th >
    //                หน่วยงานที่จัด
    //                </th>
    //                <th >
    //                วันที่เปิดรับสมัคร
    //                </th>
    //                <th >
    //                วันที่ปิดรับสมัคร
    //                </th>
    //                <th  >
    //                </th>
    //                </tr>
    //                </thead> ");
    //       _string.Append(@" <tfoot>
    //
    //                <tr>
    //                <th >
    //                ลำดับ
    //                </th>
    //                <th >
    //                ชื่อโครงการ
    //                </th>
    //                <th >
    //                หน่วยงานที่จัด
    //                </th>
    //                <th >
    //                วันที่เปิดรับสมัคร
    //                </th>
    //                <th >
    //                วันที่ปิดรับสมัคร
    //                </th>
    //                <th  >
    //                </th>
    //                </tr>
    //                </tfoot>
    //                 <tbody>");
    //       if (_count > 0)
    //       {

    //           foreach (DataRow _dr in _ds.Tables[0].Rows)
    //           {

    //               _string.Append(@"
    //                <tr >
    //                <td >
    //                " + _i.ToString() + @"
    //                </td>
    //                <td >
    //                 " + _dr["nameTh"].ToString() + @"
    //                </td>
    //                <td >
    //                 " + _dr["instituteNameTh"].ToString() + @" 
    //                </td>
    //                <td >
    //                 " + _dr["startDateRecruitTh"].ToString() + @"
    //                </td>
    //                <td >
    //                 " + _dr["endDateRecruitTh"].ToString() + @"
    //                </td>        
    //                <td >
    //                     <input  class='btn btn-success btn-sm btnProjectDetail' data-projectid='" + _dr["id"] + "'  type='button' value='รายละเอียด'/>" + @" 
    //                </td>   
    //                </tr>
    //               
    //                ");

    //               _i++;

    //           }
    //       }

    //       _string.Append("</tbody> </table></div>");
    //        return _string.ToString();

    //    }

    //     // <summary>
    //     //Auther : เจตน์ เครือชะเอม
    //     //Date   : 2017-07-05
    //     //Perpose: แสดงหน้าจอรายละเอียดของโครงการ 1 โครงการ
    //     //Method : getListProjectDetail
    //     //Sample : N/A
    //     //</summary>
    //    public static string getListProjectDetail(string _projectId, string _username)
    //    {
    //        DataSet _ds = ActDB.getListSection(_projectId, _username);
    //        int _i = 1;
    //        int _count = _ds.Tables[0].Rows.Count;
    //        StringBuilder _string = new StringBuilder();
    //        string _htmlProjectDetail="";
    //        string _htmlSectionDetail="";
    //        string _projectNameTh = "";
    //        string _picName="";
    //        string _instituteNameTh = "";
    //        string _projectDetail = "";
    //        string _projectStartDateRecruit = "";
    //        string _projectEndDateRecruit=  "";
    //        string _projectTypeNameTh = "";
    //        string _targetGroupNameTh = "";
    //        string _stsJoinSection = "";
    //        string _btnJoinSection = "";
    //        if (_count > 0)
    //        {

    //            _htmlSectionDetail = "<h3 class='page-body'>รายการ Section ที่ให้เลือกเข้าร่วม</h3>";
    //            _htmlSectionDetail += @"<table  class='table' >
    //                                      <tr>
    //                                      <th>
    //                                       ลำดับ
    //                                      </th>
    //                                      <th>
    //                                       ชื่อ Section
    //                                      </th>
    //                                      <th>
    //                                       จำนวนรับสมัคร
    //                                      </th>
    //                                      <th>
    //                                       จำนวนลงทะเบียน
    //                                      </th> 
    //                                      <th>
    //                                       วันเวลาที่ทำกิจกรรม
    //                                      </th> 
    //                                      <th>
    //                                       Indicator ที่ได้รับ
    //                                      </th> 
    //                                      <th>
    //                                       Character ที่ได้รับ
    //                                      </th> 
    //                                      <th>
    //                                      </th> 
    //                                      </tr>";
    //            foreach (DataRow _dr in _ds.Tables[0].Rows)
    //            {
    //                _projectNameTh = _dr["projectNameTh"].ToString();
    //                _picName = _dr["picName"].ToString();
    //                _instituteNameTh = _dr["instituteNameTh"].ToString();
    //                _projectDetail = _dr["projectDetail"].ToString();
    //                _projectStartDateRecruit = _dr["projectStartDateRecruit"].ToString();
    //                _projectEndDateRecruit = _dr["projectEndDateRecruit"].ToString();
    //                _projectTypeNameTh = _dr["projectTypeNameTh"].ToString();
    //                _targetGroupNameTh = _dr["targetGroupNameTh"].ToString();
    //                _stsJoinSection = _dr["stsJoinSection"].ToString();

    //                if (_stsJoinSection == "0")
    //                {
    //                    _btnJoinSection = "<button type='button' class='btn btn-info btn-sm btnSetJoinSection'>เข้าร่วมโครงการ</button>";
    //                }
    //                else
    //                {
    //                    _btnJoinSection = " <button type='button' class='btn btn-success btn-sm glyphicon glyphicon-ok' onclick=alert('คุณได้ลงทะเบียนเข้าร่วมกิจกรรมนี้แล้ว');> เข้าร่วมโครงการนี้แล้ว</button>";
    //                }



    //                _htmlSectionDetail += @"
    //                                      <tr>
    //                                      <td>
    //                                       " + _i.ToString() + @"
    //                                      </td>
    //
    //                                      <td>
    //                                       " + _dr["sectionNameTh"] + @"
    //                                      </td>
    //                                      <td>
    //                                       " + _dr["amountMax"] + @"
    //                                      </td>
    //                                      <td>
    //                                       " + _dr["countStdRegist"] + @"
    //                                      </td> 
    //                                      <td>
    //                                       " + _dr["startDateTh"] + " - " + _dr["endDateTh"] + @"
    //                                      </td> 
    //                                      <td>
    //                                       " + _dr["dataStrIndicator"] + @"
    //                                      </td> 
    //                                      <td>
    //                                       " + _dr["dataStrCharacter"] + @"
    //                                      </td> 
    //                                      <td>
    //                                        "+_btnJoinSection +@"
    //                                      </td> 
    //                                      </tr>";
    //                _i++;


    //            }

    //            _htmlSectionDetail += " </table>";
    //            _htmlProjectDetail = @"<div id='divProjectDetail'>  <h1 class='page-header'>
    //                                        ชื่อโครงการ : " + _projectNameTh + "</h1>" + @"
    //                                        <input class='btn btn-warning btn-block btnBack' type='button' value='ย้อนกลับ' />
    //                                        </br><table  class='table' >
    //                                   
    //                                            <tr>
    //                                            <td rowspan='5' align='center'>
    //                                            <img src='../../images/" + _picName + @"'  class='img-rounded' style='width:260px;height:280px;' />
    //                                            </td>
    //                                            <td>
    //                                            <b>หน่วยงานที่จัด :</b> " + _instituteNameTh + @"
    //                                            </td>
    //                                            </tr>
    //                                            <tr>
    //                                            <td>
    //                                              <b>รายละเอียดโครงการ :</b> " + _projectDetail + @"
    //                                            </td>
    //                                            </tr>
    //                                            <tr>
    //                                            <td>
    //                                             <b>ระยะเวลาที่เปิดรับสมัคร :</b> " + _projectStartDateRecruit + " - " + _projectEndDateRecruit + @"
    //                                            </td>
    //                                            </tr>
    //                                            <tr>
    //                                            <td>
    //                                             <b>ประเภทกิจกรรม :</b> " + _projectTypeNameTh + @"
    //                                            </td>
    //                                            </tr>
    //                                            <tr>
    //                                            <td>
    //                                             <b>กลุ่มของนักศึกษา :</b> " + _targetGroupNameTh + @"
    //                                            </td>
    //                                            </tr>
    //                                            <tr>
    //                                           </tr>
    //                                 </table>";
    //        }
    //        else
    //        {
    //            _htmlSectionDetail = @"<div id='divProjectDetail'>  <h1 class='page-header'>ไม่มีข้อมูล Section</h1></div>
    //                                     <input class='btn btn-warning btn-block btnBack' type='button' value='ย้อนกลับ' />
    //                                  ";
    //        }

    //        _string.Append(_htmlProjectDetail);
    //        _string.Append(_htmlSectionDetail);
    //        _string.Append(@"</div>");
    //        return _string.ToString();

    //    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-06-06
    /// Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    /// Method : getListActivitiesType2
    /// Sample : N/A
    /// </summary>
    public static string getListActivitiesType2(string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.rptGetListActivityAllByStudentId(_studentId, "1");
        int _i = 1;
        string _studentCode = "", _stdLeft2 = "";
        string _semester = "", _acaYear = "";
        string _firstName = "", _lastName = "";
        string _htmlHeader2 = "", _htmlBody2 = "";
        string _countAct = "0", _countHours = "0";
        string _projectNameTh = "", _positionNameTh = "", _projectNameEn = "", _positionNameEn="";
        string _hourRow = "";
        string _A1 = "", _A2 = "", _A3 = "", _A4 = "";
        string _M = "", _A = "", _H = "", _I = "", _D = "", _O = "", _L = "";
        string _code = "";
        string _groupIndicatorId = "";
        string _colspan = "5";
        string _instituteNameTh = "", _instituteNameEn = "";
       // _htmlHeader2 = " <div style='font-size:15px;'>";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _htmlBody2 += "<tbody>";
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _semester = _dr["semester"].ToString();
                _acaYear = _dr["acaYear"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _stdLeft2 = _dr["stdLeft2"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _countAct = _dr["countAct"].ToString();
                _countHours = _dr["countHour"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _positionNameTh = _dr["positionNameTh"].ToString();
                _positionNameEn = _dr["positionNameEn"].ToString();
                _hourRow = _dr["hourRow"].ToString();
                _code = _dr["projectCode"].ToString();
                _groupIndicatorId = _dr["groupIndicatorId"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _instituteNameEn = _dr["instituteNameEn"].ToString();
                
                if (_groupIndicatorId == "GIR-002")
                {
                    _M = _dr["M"].ToString();
                    _A = _dr["A"].ToString();
                    _H = _dr["H"].ToString();
                    _I = _dr["I"].ToString();
                    _D = _dr["D"].ToString();
                    _O = _dr["O"].ToString();
                    _L = _dr["L"].ToString();
                    _htmlBody2 += @"     <tr>    
                                            <td class='text-center'> 
                                                " + _acaYear + "/" + _semester + "</br><small style='color:gray;'>" + _code + @"</small>
                                            </td>
                                            <td class='text-left'> 
                                                <span class='th'>" + _instituteNameTh + "</span><span class='en'>"+ _instituteNameEn + @"</span>
                                            </td>
                                            <td > 
                                                <span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span>
                                            </td>
                                            <td > 
                                                 <span class='th'>" + _positionNameTh + "</span><span class='en'>" + _positionNameEn + @"</span>
                                            </td>
                                            <td class='text-center'> 
                                                    " + _M + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _A + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _H + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _I + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _D + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _O + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _L + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _hourRow + @"
                                            </td>
                                    </tr>";
                    _colspan = "12";

                }
                else if(_groupIndicatorId == "GIR-001")
                {
                    _A1 = _dr["A.1"].ToString();
                    _A2 = _dr["A.2"].ToString();
                    _A3 = _dr["A.3"].ToString();
                    _A4 = _dr["A.4"].ToString();
                    _htmlBody2 += @"    <tr>    
                                            <td class='text-center'> 
                                                " + _acaYear + @"/" + _semester + "</br><small style='color:gray;'>"+ _code + @"</small>
                                            </td>
                                            <td class='text-left' > 
                                                <span class='th'>" + _instituteNameTh + "</span><span class='en'>" + _instituteNameEn + @"</span>
                                            </td>
                                            <td> 
                                                <span class='th'>" + _projectNameTh + @"</span>
                                                <span class='en'>" + _projectNameEn + @"</span>
                                            </td>
                                            <td> 
                                                <span class='th'>" + _positionNameTh + @"</span>
                                                <span class='En'>" + _positionNameEn + @"</span>
                                            </td>
                                            <td class='text-center'> 
                                                    " + _A1 + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _A2 + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _A3 + @"
                                            </td>
                                            <td class='text-center'> 
                                                    " + _A4 + @"
                                            </td> 
                                            <td class='text-center'> 
                                            " + _hourRow + @"
                                            </td>
                                        </tr>";
                    _colspan = "9";
                }
                else
                {
                    _colspan = "5";

                }
                

                _i++;
            }
            _htmlBody2 += "</tbody>";
        }
        //else
        //{
        //    _htmlBody2 += "<tr>  <th class='text-center' colspan='12' > <span class='th'>ไม่พบข้อมูล</span><span class='en'>No data</span> </th></tr>";
        //}



        string _column = "";
        _ds = ActDB.getListStudentProfile(_studentId);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _stdLeft2 = _dr["stdLeft2"].ToString();
            }
        }
        if (_groupIndicatorId == "GIR-002")
        {
            _column = @"    <th class='text-center'> 
                            M
                            </th>
                            <th class='text-center'> 
                            A
                            </th>
                            <th class='text-center'> 
                            H
                            </th>
                            <th class='text-center'> 
                            I
                            </th>
                            <th class='text-center'> 
                            D
                            </th>
                            <th class='text-center'> 
                            O
                            </th>
                            <th class='text-center'> 
                            L
                            </th>";
        }
        else if(_groupIndicatorId == "GIR-001")
        {
            _column = @"   <th class='text-center'> 
                            A1
                            </th>
                           <th class='text-center'> 
                            A2
                            </th>
                           <th class='text-center'> 
                            A3
                            </th>
                           <th class='text-center'> 
                            A4
                            </th>";
        }

        

        _htmlHeader2 += @"                <table id='tblStdActType2' class='table table-bordered '  >
                                                      
                                                      <thead>
                                                      <tr class='bg-primary'>
                                                      <th colspan='" + _colspan + @"'>
                                                          <span class='th'>2. กิจกรรมเลือกเสรี (" + _countAct + " กิจกรรม," + _countHours + @" ชั่วโมง)</span>
                                                          <span class='en'>2. Elective Activity (" + _countAct + " act.," + _countHours + @" hour)</span>
                                                      </th>
                                                      </tr>
                                                      <tr class='bg-info'>
                                                      <th class='text-center col-sm-2'> 
                                                           <b><span class='th'>ปีการศึกษา/ภาค</span><span class='en'>Academic year/Semester</span></b>
                                                      </th>
                                                      <th class='text-center col-sm-2'> 
                                                           <b><span class='th'>ส่วนงานผู้จัดโครงการ</span><span class='en'>Institute</span></b>
                                                      </th>
                                                      <th class='text-center col-sm-3'>  
                                                           <b><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></b>
                                                      </th>
                                                      <th class='text-center col-sm-2'> 
                                                           <b><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></b>
                                                      </th>
                                                            " + _column + @"
                                                      <th class='text-center col-sm-1'> 
                                                           <span class='th'>รวม</span><span class='en'>Total</span>
                                                      </th>
                                                      </tr>
                                                      </thead>";
        _htmlBody2 += "</table>";

        _ds = ActDB.getListIndicatorByYearStd(_studentCode);
        _htmlBody2 += "<hr><table class='table table-striped table-bordered'>";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _htmlBody2 += "<thead><tr class='bg-info'><th><b><span class='th'>หมายเหตุ</span><span class='en'>Remark</span></b></th></tr></thead>";
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _htmlBody2 += "  <tr><td><b>" + _dr["indicatorAbbrevEn"] + ":</b> <span class='th'>" + _dr["indicatorNameTh"] + "</span><span class='en'>" + _dr["indicatorNameEn"] + "</span></td></tr>";
            }
        }
        else
        {
            _htmlBody2 += "<td><b><span class='th'>ไม่พบข้อมูล</span><span class='en'>No data</span></b></td>";
        }
        _htmlBody2 += "</table>";

        _string.Append(_htmlHeader2 + _htmlBody2);
        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-06-13
    /// Perpose: แสดงหน้ากิจกรรมกำหนดให้เข้าร่วม
    /// Method : getListActivitiesStdHIDEFType1
    /// Sample : N/A
    /// </summary>
    public static string getListActivitiesStdHIDEFType1(string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        string _htmlBody = "";
        string _firstName = "";
        string _lastName = "";
        string _studentCode = "";
        string _facNameTh = "";
        string _programNameTh = "";
        string _countActAll = "";
        double _countHoursAll = 0.0;
        string _htmlHeader = "";


        DataSet _ds = ActDB.getListActivityStudentHIDEF(_studentId);
        DataRow[] _drRow = _ds.Tables[0].Select("indicatorId='IDC-023'");
        int _row = _drRow.Length;


        string _acaYear = "";
        string _semeter = "";
        string _projectNameTh = "";
        string _projectSectionNameTh = "";
        string _projectCode = "";
        string _positionNameTh = "";
        string _projectNameEn = "";
        string _projectSectionNameEn = "";
        string _sumHours = "";
        double _totalHour = 0.0;
        _htmlBody += @"<div class='row '> 
                              <div class='form-group col-xs-12' > 
                              <h4 class='page-header'><b><span class='th'>กิจกรรมที่ได้เข้าร่วมแล้ว</span><span class='en'>Activity joined</span></b></h4>
                              </div>
                              </div>";
        _htmlBody += "<small><span class='th'>กิจกรรมเสริมหลักสูตรตลอดเวลาการศึกษาในมหาวิทยาลัยมหิดล(ชั้นปีที่ 1 - ปีสุดท้าย) มีจำนวนหน่วยชั่วโมงในการเข้าร่วมกิจกรรมไม่น้อยกว่า 100 หน่วยชั่วโมง</span></small>";
        _htmlBody += "<small><span class='en'>Extra-curricular activities throughout the study period at Mahidol University (Year 1 - Year) with a total of not less than 100 hours of hours per activity</span></small>";

        _htmlBody += "<table class='table table-bordered'><tr><td class='bg-info h4'> <span class='th'>1.กิจกรรมกำหนดให้เข้าร่วม</span><span class='en'>1. Activity scheduled to participate</span> <span class='label label-info'>" +
            "<span class='th'>เกณฑ์ผ่าน : 1 กิจกรรม 3 หน่วยชั่วโมง</span><span class='en'>creterion : 1 act. 3 hour</span>     </span></td></tr>";
        _htmlBody += @"<tr >
                       <td>
                          <strong>
<span class='th'>พิธีปฐมนิเทศนักศึกษาใหม่ระดับมหาวิทยาลัย หรือระดับส่วนงาน <small style='color:gray;'>(เกณฑ์ผ่าน : 1 กิจกรรม 3 หน่วยชั่วโมง)</span></small>
<span class='en'>New student orientation at the university level Or department level <small style='color:gray;'>(creterion : 1 act. 3 hours)</span></small>
</strong></br>
                          <center>
                          <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                            </thead>";

        _htmlBody += "     <tbody>";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {

                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                             </tr>";
                _countHoursAll += Convert.ToDouble(_sumHours);
            }
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"     </tbody>
                            </table>
                      </td>
                      </tr>";





        // เอาออกเมื่อวันที่ 14/06/2565
        //_drRow = _ds.Tables[0].Select("indicatorId='IDC-024'");
        //_row = _drRow.Length;
        //        _htmlBody += @"<tr >
        //                       <td>
        //                          <strong>
        //<span class='th'>1.2 พิธีไหว้ครูระดับมหาวิทยาลัย หรือระดับส่วนงาน <small style='color:gray;'>(เกณฑ์ผ่าน : 1 กิจกรรม 3 หน่วยชั่วโมง)</small></span>
        //<span class='en'>1.2 University Paying Ceremony Or department level <small style='color:gray;'>(creterion : 1 act. 3 hours)</small></span>
        //</strong></br>
        //                          <center>
        //                          <table class='table table-striped table-bordered page-heading' style='width:98%;'>
        //                          <thead>
        //                            <tr class='text-info'>
        //                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
        //                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
        //                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
        //                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
        //<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
        //                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
        //                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
        //                            </tr>

        //                           </thead>";

        //        _htmlBody += " <tbody > ";
        //        if (_row > 0)
        //        {
        //            for (int _i = 0; _i < _row; _i++)
        //            {
        //                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
        //                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
        //                _acaYear = _drRow[_i]["acaYear"].ToString();
        //                _semeter = _drRow[_i]["semester"].ToString();
        //                _projectCode = _drRow[_i]["projectCode"].ToString();
        //                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
        //                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
        //                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
        //                _sumHours = _drRow[_i]["sumHours"].ToString();
        //                _countHoursAll += Convert.ToDouble(_sumHours);
        //                _htmlBody += @"  <tr>
        //                                  <td>" + (_i + 1).ToString() + @"</td>
        //                                  <td>" + _semeter + "/" + _acaYear + @"</td>
        //                                  <td>" + _projectCode + @"</td>
        //                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
        //<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
        //                                  <td>" + _positionNameTh + @"</td>
        //                                  <td>" + _sumHours + @"</td>
        //                             </tr>";
        //            }
        //        }
        //        else
        //        {
        //            _htmlBody += @"  <tr>
        //                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
        //                             </tr>";
        //        }


        //        _htmlBody += @"     </tbody>
        //                            </table>
        //                      </td>
        //                      </tr>";


        _htmlBody += "</table>";



        _drRow = _ds.Tables[0].Select("indicatorId='IDC-025'");
        _row = _drRow.Length;
        _htmlBody += "<table class='table table-bordered'><tr><td class='bg-info h4'> " +
            "<span class='th'>2.กิจกรรมเลือกเข้าร่วม <span class='label label-info'>เกณฑ์ผ่าน : 97 หน่วยชั่วโมง</span>" +
            "<span class='en'>2.Activity Choose to participate <span class='label label-info'>creterion : 97 hours</span>" +
            "</span></td></tr>";
        _htmlBody += @"<tr>
                       <td>
                          <strong>
<span class='th'>2.1 กิจกรรมจิตอาสา (Volunteer) <small style='color:gray;'>(เกณฑ์ผ่าน : ไม่น้อยกว่า 10 หน่วยชั่วโมง)</small></span>
<span class='en'>2.1 Volunteer activities (Volunteer) <small style='color:gray;'>(criteria: not less than 10 hours)</small></span>
</strong></br>
                          <center>
                          <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>

                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
   
                           </thead>";
   
        _htmlBody += " <tbody > ";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='5'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }


        _htmlBody += @"     </tbody>
                            </table>
                      </td>
                      </tr>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-001' "); 
        _row = _drRow.Length;
        _htmlBody += @"<tr>
                       <td>

                          <strong>
<span class='th'>2.2 กิจกรรมหลัก Mahidol HIDEF <small style='color:gray;'>(เกณฑ์ผ่าน : ไม่น้อยกว่า 3 ใน 5 ด้าน โดยแต่ละด้านไม่น้อยกว่า 10 ชั่วโมง)</small></span>
<span class='en'>2.2 Main Activities Mahidol HIDEF<small style='color:gray;'>(criteria : Not less than 3 in 5 sides, each side not less than 10 hours)</small></span>
</strong></br>
                          <center>

                          <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>

                                <span class='th'>2.2.1 Health Literacy ความเข้าใจและสามารถดำเนินชีวิตให้เป็นผู้มีสุขภาพดี</span>
                                <span class='en'>2.2.1 Health Literacy</span>                              
                              </th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody > ";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";


        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-002' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.2.2 Internationalization ความเป็นนานาชาติ</span>
<span class='en'>2.2.2 Internationalization</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";



        _htmlBody += " <tbody > ";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-003' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.2.3 Digital Literacy ทักษะความเข้าใจและใช้เทคโนโลยีดิจิทัล</span>
<span class='en'>2.2.3 Digital Literacy</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += "<tbody> ";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-004' "); 
        _row = _drRow.Length;
        _htmlBody += @"  <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.2.4 Environmental Literacy ความเข้าใจและปฏิบัติเป็นในด้านสิ่งแวดล้อม</span>
<span class='en'>2.2.4 Environmental Literacy</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   

        _htmlBody += " <tbody > ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-005' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.2.5 Financial Literacy ความเข้าใจและปฏิบัติเป็นในด้านการเงิน เศรษฐกิจ ธุรกิจ</span>
<span class='en'>2.2.5 Financial Literacy</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody > ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
       _htmlBody += @"    </tbody>
                          </table>

                      </td>
                      </tr>";

        _htmlBody += @"<tr>
                       <td>

                          <strong>
<span class='th'>2.3 กิจกรรมส่งเสริม 21st Century Skills อื่นๆ</span>
<span class='en'>2.3 Other 21st Century Skills promotion activities</span>
</strong></br>
                          <center>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-006' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.3.1 Critical Thinking & Problem Solving ทักษะการคิดเชิงวิพากษ์และการแก้ปัญหา</span>
<span class='en'>2.3.1 Critical Thinking & Problem Solving</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody> ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"    </tbody>
                          </table>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-007' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.3.2 Creativity & Innovation ความคิดสร้างสรรค์และนวัตกรรม</span>
<span class='en'>2.3.2 Creativity & Innovation</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody> ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";


        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-008' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.3.3 Communication & Collaboration การติดต่อสื่อสารและการร่วมมือกัน</span>
<span class='en'>2.3.3 Communication & Collaboration</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody > ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";

        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-009' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.3.4 Leadership & Management Skills การเป็นผู้นำ มีคุณธรรมจริยธรรม</span>
<span class='en'>2.3.4 Leadership & Management Skills</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody > ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>";
        _drRow = _ds.Tables[0].Select("subIndicatorId = 'SID-010' ");
        _row = _drRow.Length;
        _htmlBody += @"   <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                          <thead>
                          <tr>
                              <th colspan = '7'>
<span class='th'>2.3.5 Social skill ทักษะทางสังคมและวัฒนธรรมที่ต่างกัน</span>
<span class='en'>2.3.5 Social skill</span>
</th>
                          </tr>
                            <tr class='text-info'>
                              <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                              <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
<th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                              <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                              <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                            </tr>
                          </thead>";
   
        _htmlBody += " <tbody > ";

        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                  <td>" + (_i + 1).ToString() + @"</td>
                                  <td>" + _semeter + "/" + _acaYear + @"</td>
                                  <td>" + _projectCode + @"</td>
                                  <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
<td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                  <td>" + _positionNameTh + @"</td>
                                  <td>" + _sumHours + @"</td>
                                </tr>";
                _totalHour += Convert.ToDouble(_sumHours);
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                  <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                             </tr>";
        }
        _htmlBody += @"   </tbody>
                          </table>

                       </td>
                       </tr>";
        


        // เพิ่มเมื่อวันที่ 14/06/2565
        _drRow = _ds.Tables[0].Select("indicatorId='IDC-024'");
        _row = _drRow.Length;
        _htmlBody += @"<tr >
                               <td>
                                  <strong>
        <span class='th'>2.4 พิธีไหว้ครูระดับมหาวิทยาลัย หรือระดับส่วนงาน </span>
        <span class='en'>2.4 University Paying Ceremony Or department level </span>
        </strong></br>
                                  <center>
                                  <table class='table table-striped table-bordered page-heading' style='width:98%;'>
                                  <thead>
                                    <tr class='text-info'>
                                      <th scope = 'col' class='col-sm-1 '><span class='th'>ลำดับ</span><span class='en'>No</span></th>
                                      <th scope = 'col' class='col-sm-2'><span class='th'>ภาค/ปีการศึกษา</span><span class='en'>Semester/Academic Year</span></th>
                                      <th scope = 'col' class='col-sm-2'><span class='th'>รหัสโครงการ</span><span class='en'>Project Code</span></th>
                                      <th scope = 'col' ><span class='th'>ชื่อโครงการ/กิจกรรม</span><span class='en'>Project Name/Activity Name</span></th>
        <th scope = 'col' ><span class='th'>ชื่อเซกชั่น</span><span class='en'>Section Name</span></th>
                                      <th scope = 'col' class='col-sm-2'><span class='th'>ตำแหน่ง</span><span class='en'>Position</span></th>
                                      <th scope = 'col' class='col-sm-1'><span class='th'>ชั่วโมง</span><span class='en'>Hour</span></th>
                                    </tr>

                                   </thead>";

        _htmlBody += " <tbody > ";
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _projectSectionNameTh = _drRow[_i]["projectSectionNameTh"].ToString();
                _projectSectionNameEn = _drRow[_i]["projectSectionNameEn"].ToString();
                _acaYear = _drRow[_i]["acaYear"].ToString();
                _semeter = _drRow[_i]["semester"].ToString();
                _projectCode = _drRow[_i]["projectCode"].ToString();
                _projectNameTh = _drRow[_i]["projectNameTh"].ToString();
                _projectNameEn = _drRow[_i]["projectNameEn"].ToString();
                _positionNameTh = _drRow[_i]["positionNameTh"].ToString();
                _sumHours = _drRow[_i]["sumHours"].ToString();
                _countHoursAll += Convert.ToDouble(_sumHours);
                _totalHour += Convert.ToDouble(_sumHours);
                _htmlBody += @"  <tr>
                                          <td>" + (_i + 1).ToString() + @"</td>
                                          <td>" + _semeter + "/" + _acaYear + @"</td>
                                          <td>" + _projectCode + @"</td>
                                          <td><span class='th'>" + _projectNameTh + "</span><span class='en'>" + _projectNameEn + @"</span></td>
        <td><span class='th'>" + _projectSectionNameTh + "</span><span class='en'>" + _projectSectionNameEn + @"</span></td>
                                          <td>" + _positionNameTh + @"</td>
                                          <td>" + _sumHours + @"</td>
                                     </tr>";
            }
            _htmlBody += @"    <tr>
                                  <td class='text-right' colspan='6'><strong><span class='th'>รวม</span><span class='en'>Total</span></strong></td>
                                  <td><strong>" + _totalHour.ToString() + @"</strong></td>
                                </tr>";
            _totalHour = 0.0;
        }
        else
        {
            _htmlBody += @"  <tr>
                                          <td colspan='7' class='text-center'><span class='th'>ไม่มีกิจกรรมที่เข้าร่วม</span><span class='en'>No data</span></td>
                                     </tr>";
        }


        _htmlBody += @"     </tbody>
                                    </table>
                              </td>
                              </tr>";

        _htmlBody += " </table>";

        string _enfirstName = "", _enlastName = "";
        string _facNameEn = "", _programNameEn="";
        string _iconStatusPass="",_stsPass = "",_stsPassTh ="", _stsPassEn = "";
        DataSet _dsAT = ActDB.getListStudentProfile(_studentId);
        if (_dsAT.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _dsAT.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _enfirstName = _dr["enfirstName"].ToString();
                _enlastName = _dr["enlastName"].ToString();
                _facNameTh = _dr["facNameTh"].ToString();
                _facNameEn = _dr["facNameEn"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _programNameEn = _dr["programNameEn"].ToString();
            }
        }
         _ds = ActDB.getListActivityStudentHIDEF(_studentId);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _countActAll = _dr["sumActAll"].ToString();
                _stsPass = _dr["stsPass"].ToString();
                _stsPassTh = _dr["stsPassTh"].ToString();
                _stsPassEn = _dr["stsPassEn"].ToString();
                //_countHoursAll = _dr["sumHoursAll"].ToString();
            }
        }
        if (_stsPass == "1")
        {
            _iconStatusPass = "<i style='color:green;' class='glyphicon glyphicon-ok'></i>";
        }
        else
        {
            _iconStatusPass = "<i style='color:red;' class='glyphicon glyphicon-remove'></i>";
        }
        _htmlHeader += ActReportUI.getListConditionToComplete(_studentCode.Substring(0, 2), _studentId);
        _htmlHeader += "<h4 class='page-header'><span class='th'><b>ข้อมูลการเข้าร่วมกิจกรรม</b></span><span class='en'><b>Participating activities</b></span></h4>";
        _htmlHeader += @"<div class='row'>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>ชื่อ-นามสกุล :</b> " + _firstName + " " + _lastName + @"</span>
                            <span class='en'><b>Fullname :</b> " + _enfirstName + " " + _enlastName + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>เลขประจำตัวนักศึกษา :</b> " + _studentCode + @"</span>
                            <span class='en'><b>Student Id :</b> " + _studentCode + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>คณะ :</b> " + _facNameTh + @"</span>
                            <span class='en'><b>Faculty :</b> " + _facNameEn + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>หลักสูตร :</b> " + _programNameTh + @"</span>
                            <span class='en'><b>Program :</b> " + _programNameEn + @"</span>
                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>จำนวนกิจกรรม</b> " + _countActAll + @" <b>กิจกรรม</b></span>
                            <span class='en'><b>Amount </b> " + _countActAll + @" <b>Act.</b></span>

                            </div>
                            <div class='form-group col-xs-6' > 
                            <span class='th'><b>จำนวนชั่วโมง</b> " + Convert.ToString(_countHoursAll) + @" <b>ชั่วโมง</b></span>
                            <span class='en'><b>Hour</b> " + Convert.ToString(_countHoursAll) + @" <b>hour</b></span>
                            </div>


                          </div>";
                            //        < div class='form-group col-xs-6' > 
                            //<span class='th'><b>สถานะการเข้าร่วมกิจกรรม :  " + _iconStatusPass + " " + _stsPassTh + @"</b></span>
                            //<span class='en'><b>Status :  " + _iconStatusPass + " " + _stsPassEn + @"</b></span>
                            //</div>
        

        _string.Append(_htmlHeader+_htmlBody);
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-14
    /// Perpose: แสดงหน้ารายการข้อมูลกิจกรรมที่เข้าร่วมที่ได้ค่า A1 ด้านบำเพ็ญประโยชน์
    /// Method : getListActDetailForScholarshipNew
    /// Sample : N/A
    /// </summary>
    public static string getListActDetailForScholarshipNew(string _acaYear, string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListProjectForStudentScholarShip(_acaYear, _studentId);
        string _htmlHeader = "", _htmlBody = "";
        string _projectNameTh = "", _instituteNameTh = "", _sumHours = "", _sumHoursAll = "", _stsSendDataSch = "", _stsScholarship = "";
        string _code = "", _dateTh = "", _studentCode = "", _firstName = "", _lastName = "", _stsPass = "";
        string _enFirstName = "", _enLastName = "";
        string _stsPassEn = "", _projectNameEn="";

        int _i = 1;
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectNameTh = _dr["projectNameTh"].ToString();
                _projectNameEn = _dr["projectNameEn"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _sumHours = _dr["sumHours"].ToString();
                _sumHoursAll = _dr["sumHoursAll"].ToString();
                _code = _dr["code"].ToString();
                _dateTh = _dr["dateTh"].ToString();
                _stsPass = _dr["stsPass"].ToString();
                _stsScholarship = _dr["stsScholarship"].ToString();
                _stsSendDataSch = _dr["stsSendDataSch"].ToString();
                _enFirstName = _dr["enFirstName"].ToString();
                _enLastName = _dr["enLastName"].ToString();
                _stsPassEn = _dr["stsPassEn"].ToString();
                _htmlBody += @" <tr>
                                <td  style='border:1px solid gray;' align='left'>
                                " + _code + @"
                                </td>
                                <td  style='border:1px solid gray;' align='left'>
                                <span class='th'>" + _projectNameTh + "</span><span class='en'>"+ _projectNameEn + @"</span>
                                </td>
                                <td  style='border:1px solid gray;' align='left'>
                                " + _dateTh + @"
                                </td>
                                <td  style='border:1px solid gray;' align='left'>
                                " + _instituteNameTh + @"
                                </td>
                                <td  style='border:1px solid gray;' align='center'>
                                " + _sumHours + @"
                                </td>
                                </tr>";
            }
            _htmlBody += @" <tr> <td colspan='5' align='right'  >";
            _htmlBody += @" <span class='th'><strong>รวม</strong> " + _sumHoursAll + " ชั่วโมง <strong>สถานะ</strong> " + _stsPass + " </span>";
            _htmlBody += @" <span class='en'><strong>Total</strong> " + _sumHoursAll + " hour. <strong>Status</strong> " + _stsPassEn + " </span></td></tr>";
            _htmlBody += @" <tr> <td colspan='5' align='center'  >
<span class='th'><strong><u>หมายเหตุ</u> : </strong>เอกสารฉบับนี้ใช้เพื่อประกอบการพิจารณาอนุมัติการกู้ยืมเงินกยศ./กรอ.เท่านั้น</span>
<span class='en'><strong><u>Remark</u> : </strong>This document is used to support the loan approval process.</span>
</td></tr>";
        }
        else
        {
            _htmlBody += "<tr> <td colspan='5' align='center'  ><span class='th'>ไม่พบข้อมูลที่ค้นหา</span><span class='en'>No Data</span></td></tr>";
        }

        _htmlHeader = @"<div id='divActScholarship' class='panel panel-default'  style='font-size:15px;'>
                        <table class='table table-bordered' style='width:100%;border:1px solid gray;border-collapse: collapse;'>
                        <tr>
                             <th class='text-center' style='background-color:#d6d7d8;border:1px solid gray;' colspan='4'><span class='th'>กิจกรรมบำเพ็ญประโยชน์ ปีการศึกษา</span><span class='en'>Service activities, academic year</span> " + _acaYear + @"</th>
                        </tr> 
                        <tr>
                             <th class='text-center' colspan='4' style='border:1px solid gray;'><img src='../../images/logo.png' /></th>
                        </tr>
                        <tr>
                        <td style='width:25%;border:1px solid gray;' align='right'><strong><span class='th'>รหัสนักศึกษา</span><span class='en'>Student Id</span> :</strong></td>
                        <td style='width:25%;border:1px solid gray;' align='left'>" + _studentCode + @"</td>
                        <td style='width:25%;border:1px solid gray;' align='right'><strong><span class='th'>ชื่อ-นามสกุล</span><span class='en'>Full Name</span> :</strong></td>
                        <td style='width:25%;border:1px solid gray;' align='left'><span class='th'>" + _firstName + ' ' + _lastName + "</span><span class='en'>" + _enFirstName + ' ' + _enLastName + @"</span></td>
                        </td>
                        </tr>


                        <tr>
                        <td colspan='4' width='100%'>
                            </br>
                            <table  class='table table-bordered' style='width:100%;border:1px solid gray;border-collapse: collapse;'>
                            <tr style='background-color:#d6d7d8;'>
                                <th align='center' class='text-center' style='width:12%;border:1px solid gray;'><span class='th'>รหัส</span><span class='en'>Project Code</span></th>
                                <th align='center' class='text-center' style='border:1px solid gray;'><span class='th'>ชื่อโครงการ</span><span class='en'>Project Name/Activity Name</span></th>
                                <th align='center' class='text-center' style='width:18%;border:1px solid gray;'><span class='th'>วันเวลาที่จัดกิจกรรม</span><span class='en'>Date of activity</span></th>
                                <th align='center' class='text-center' style='width:25%;border:1px solid gray;'><span class='th'>หน่วยงาน</span><span class='en'>Institute</span></th>
                                <th align='center' class='text-center' style='width:6%;border:1px solid gray;'><span class='th'>ชั่วโมง</span><span class='en'>Hours received</span></th>
                            </tr>

                            " + _htmlBody + @"

                            </table>
                        </td>
                        </tr>

                        </table>
                        </div>

                        <table  class='table table-bordered' style='width:100%;border:1px solid gray;border-collapse: collapse;'>
                        <tr>
                             <td style='border:1px solid gray;'  >

                                <strong><span class='th'>สถานะการส่งข้อมูล</span>Status<span class='en'></span> :</strong>  <a style='cursor:pointer;' class='btnSendDataScholarship' data-acayear='" + _acaYear + "' " +
                                "data-studentid='" + _studentId + "' data-stsscholarship='" + _stsScholarship + "'>" + _stsSendDataSch 
                                + @"</a><a style='cursor:pointer;' data-toggle='modal' data-target='#divPopup' class='btnGetListSchStudentSendAct'> >> <span class='th'>ตรวจสอบรายชื่อ</span><span class='en'>Check list</span> << </a>
                                <button type='button' class='btn btn-default glyphicon glyphicon-print btnPrintActForScholarship'> <span class='th'>พิมพ์เอกสาร</span><span class='en'>Print</span></button>

                            </td>
                        </tr>
                        </table>";



        _string.Append(_htmlHeader);
        return _string.ToString();

    }


    public static string loadGroupIndicator()
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListGroupIndicator();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@"   <select class='form-control ddlGroupIndicator' >
                                <option value=''>ทุกกลุ่มตัวชี้วัด</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "   >" + _dr["nameTh"] + "</option>");
            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }


    public static string getListActivitiesOnline(string _studentId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListActivitiesOnline(_studentId);
        string _instituteNameTh = "", _projectSectionNameDisplayTh = "", _projectNameTh = "";
        string _createdDate = "";
        string _pictureName = "";
        string _projectId = "";
        DataTable _dt = new DataTable();
        


        _string.Append("<h2 style='text-shadow: 1px 1px grey;'><span class='th'>กิจกรรมที่ได้สมัครออนไลน์แล้ว</span><span class='en'>Online application activities</span></h2>");
        _string.Append("</br>");



        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@"<div class='container - fluid'>
                                    <div class='row'>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectId = _dr["projectId"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _projectSectionNameDisplayTh = _dr["projectSectionNameTh"].ToString();
                _pictureName = _dr["imageFile"].ToString();
                _createdDate = _dr["createdDate"].ToString();



                _string.Append(@"   <div class='col-xs-6 col-md-3'>
                                    <div class='thumbnail' >
                                    <img src='../../images/" + _pictureName + @"' alt='"+ _projectNameTh + @"'>
                                    <div class='caption'>
                                    <p ><h4> <strong>"+_projectNameTh+ @"</strong></h4></p>
                                    <p> <b>Section :</b> " + _projectSectionNameDisplayTh + @" </p>
                                    <p> <span class='label label-info'>วันเวลาที่สมัคร : " + _createdDate + @"</span> </p>
                                       

                                    <p align='center'><a href = '#' data-projectid='" + _projectId + @"' class='btn btn-default btnLoadDetailProjectPublic' role='button'><span class='glyphicon glyphicon-info-sign '></span> Detail</a></p>
                                    </div>
                                    </div>
                                    </div>");



            }
            _string.Append(@" </div></div>");
        }
        else
        {
            _string.Append("<div class='col-lg-3'><span class='th'>ไม่พบข้อมูลที่สมัคร</span><span class='en'>No data</span></div>");

        }

        return _string.ToString();
    }

    public static string getListDdlIndicator(string _groupIndicatorId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<select class='form-control ddlIndicator' ><option value=''>ทุกตัวชี้วัด</option>");
        DataSet _ds = ActDB.getListIndicator("");
        DataRow[] _drRow = _ds.Tables[0].Select("groupIndicatorId='" + _groupIndicatorId + "'");
        int _row = _drRow.Length;
        if (_row > 0)
        {
              for (int _i = 0; _i < _row; _i++)
              {
                   _string.Append(@"<option value='" + _drRow[_i]["id"] + "'  >&nbsp;" + _drRow[_i]["indicatorAbbrevEn"] + " - " + _drRow[_i]["indicatorNameTh"] + "</option>");
              }
         }
         _string.Append(@"</select>");
        return _string.ToString();
    }


    public static string getListDdlSubIndicator(string _indicatorId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListSubIndicator(_indicatorId, "");
        string _selectIndex = "";
        _string.Append(@"<select class='form-control ddlSubIndicator' > ");
        _string.Append(" <option value=''>ทุกตัวชี้วัดย่อย</option> ");
        DataRow[] _drRow = _ds.Tables[0].Select("indicatorId='" + _indicatorId + "'");
        int _row = _drRow.Length;
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                _string.Append(@"<option value='" + _drRow[_i]["id"] + "' " + _selectIndex + "  >" + _drRow[_i]["nameEn"] + " - " + _drRow[_i]["nameTh"] + "</option>");

            }


        }
        _string.Append(@"</select>");
        return _string.ToString();
    }


    public static string getQRCode(string _invoiceId, string _sectionId)
    {
        string _amount = "";
        string _amountDisplay = "";
        string _ref_1 = "";
        string _ref_2 = "";
        string _acaYear = "";
        string _invoiceNo = "";
        string _billerId = "";
        string _projectSectionNameTh = "";
        string _projectNameTh = "";
        string _studentCode = "";
        string _studentNameTh = "";
        string _paidStatusDetail = "";
        string _paidDateFormat = "";
        string _expiryDatePaymentFormat = "";
        string _paidStatus = "";
        string _studentId = "";
        DataSet _ds = ActDB.getInvoiceStudentForPayment(_invoiceId, _sectionId);

        //// Install RestSharp, JSON
        StringBuilder _string = new StringBuilder();
        //var _client = new RestClient("https://kapi.mahidol.ac.th/scbapi/muBarcode/muQRCodeGen");
        var _client = new RestClient("https://smartedu.mahidol.ac.th/scbapi/muBarcode/muQRCodeGen");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _amount = _dr["invoiceAmount"].ToString();
                _ref_1 = _dr["qrRef_1"].ToString();
                _ref_2 = _dr["qrRef_2"].ToString();
                _acaYear = _dr["acayear"].ToString();
                _invoiceNo = _dr["invoiceNo"].ToString();
                _billerId = _dr["billerId"].ToString();
                _projectSectionNameTh = _dr["projectSectionNameTh"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _studentNameTh = _dr["nameTh"].ToString();
                _paidStatusDetail = _dr["paidStatusDetail"].ToString();
                _paidDateFormat = _dr["paidDateFormat"].ToString();
                _paidStatus = _dr["paidStatus"].ToString();
                _studentId = _dr["studentId"].ToString();
                _expiryDatePaymentFormat = _dr["expiryDatePaymentFormat"].ToString();
                _paidDateFormat = (_paidDateFormat == "") ? "-" : _paidDateFormat;


                _amountDisplay = String.Format("{0:#,##0}", Convert.ToDouble(_amount));

            }
        }

        var _request = new RestRequest(Method.POST);
        var _scbReq = new
        {
            biller_id = _billerId,
            merchant_name = "MU_XCHANGE-ENG", // ตาราง [Infinity].[dbo].[finPayBankQRCode]
            amount = _amount,
            ref_1 = _ref_1,
            ref_2 = _ref_2,
            //biller_id = "099400015837887",
            //merchant_name = "MU_DORM",
            //amount = "4500.00",
            //ref_1 = "03038001621002950",
            //ref_2 = "6124058020819",
        };
        string _username = "activityTranscript";
        string _password = "At#2019#";

        string _tokenBasicEncoded = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(_username + ":" + _password));
        _request.AddHeader("Authorization", _tokenBasicEncoded);
        _request.AddHeader("cache-control", "no-cache");
        _request.AddHeader("content-type", "application/json");
        _request.AddParameter("application/json", JsonConvert.SerializeObject(_scbReq), ParameterType.RequestBody);
        IRestResponse _response = _client.Execute(_request);
        if (_response.ResponseStatus == ResponseStatus.Error)
        {
            // Do Something     
            _string.Append(_response.ErrorMessage);
        }
        else
        {
            try
            {
                dynamic _obj = JsonConvert.DeserializeObject(_response.Content);
                string _qrCode = _obj.qr_code;
                string _qrMsg = _obj.qr_message;
                string _qrFormat = _obj.qr_format;
                string _qrImg = _obj.qr_image64;
                string _qrRes = _obj.qr_response;
                string _qrNewRef1 = _obj.qr_new_ref_1; //ค่า ref 1 ใหม่ บันทึกเพื่อตรวจสอบ
                if (_qrCode == "00")
                {
                    //Your Code for QR Code Display and Save Data for Ref
                    if (_paidStatus != "Y")
                    {
                        _string.Append("<div class='row'>");
                        _string.Append("<div class='col-xs-12 text-center'>");

                        _string.Append("<img id=\"qrCode\" src=\"data:image/gif;base64," + _qrImg + "\"/>");     //Test Response

                        _string.Append("</div>");
                        _string.Append("</div>");

                        _string.Append("<div class='row'>");
                        _string.Append("<div class='col-xs-12 text-center' style='color:red;'>");
                        _string.Append("* Scan QR Code เพื่อชำระเงินเข้าร่วมกิจกรรม " + _projectNameTh);
                        _string.Append("</div>");
                        _string.Append("</div>");
                    }
                    else
                    {
                        _string.Append("<div class='row'>");
                        _string.Append("<div class='col-xs-12 text-center' style='color:green;'>");
                        _string.Append("* คุณได้ชำระเงินสำหรับการเข้าร่วมกิจกรรม " + _projectNameTh + "เรียบร้อยแล้ว");
                        _string.Append("</div>");
                        _string.Append("</div>");
                    }


                    _string.Append("<table class='table table-bordered'>" +
                        "<tr><td class='bg-info bold text-right'>รหัสนักศึกษา : </td>" +
                        "<td class='text-left'>" + _studentCode + "</td>" +
                        "<td class='bg-info bold text-right'>ชื่อ-สกุล : </td>" +
                        "<td class='text-left'>" + _studentNameTh + "</td></tr>" +

                        "<tr><td class='bg-info bold text-right'>Invoice No : </td>" +
                        "<td class='text-left'>" + _invoiceNo + "</td>" +
                        "<td class='bg-info bold text-right'>Invoice Amount : </td>" +
                        "<td class='text-left'>" + _amountDisplay + " บาท</td></tr>" +

                        "<tr><td class='bg-info bold text-right'>สถานะชำระเงิน : </td>" +
                        "<td class='text-left'>" + _paidStatusDetail + "</td>" +
                        "<td class='bg-info bold text-right'>วันที่ชำระเงิน : </td>" +
                        "<td class='text-left'>" + _paidDateFormat + "</td></tr>" +
                        "<tr><td class='bg-info bold text-right'>วันที่สิ้นสุดการชำระเงิน : </td>" +
                        "<td colspan='3' class='text-left'>" + _expiryDatePaymentFormat + "</td></tr>" +

                        "<tr><td class='bg-danger text-right'><strong>คำแนะนำ</strong></td>" +
                        "<td class='text-left' colspan='3'><strong>(1) การชำระเงินโดยวิธีการสแกน QR Code ผ่าน Mobile Banking Application ของธนาคาร เท่านั้น !</strong></td></tr>" +
                        "<tr><td class='bg-danger text-right'></td>" +
                        "<td class='text-left' colspan='3'><strong>(2) QR Code ที่แสดงบนหน้าจอนี้สามารถใช้ชำระเงินได้ถึงวันที่สิ้นสุดการชำระเงินเท่านั้น</strong></td></tr>" +
                        "<tr><td class='bg-danger text-right'></td>" +
                        "<td class='text-left' colspan='3'><strong>(3) นักศึกษากรุณา เก็บสลิป การชำระเงินไว้เป็นหลักฐาน</strong></td></tr>" +

                        //"<tr><td class='text-center' colspan='4'>" +
                        //"<button type = 'button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> Back</button></td></tr>" +

                        "</table>");

                    //update table drmInvoice field qrNewRef_1=_qrNewRef1
                    ActDB.actSetUpdateNewRef1(_studentId, _invoiceId, _qrNewRef1, _ref_2, _billerId);
                    // DormitStudentDB.Sp_drmSetUpdateNewRef1(_studentId, _acaYear, _semester, _invoiceNo, _qrNewRef1, _ref_2, _billerId);
                }
                else
                {
                    // Do Something
                    _string.Append("QRCODE MESSAGE: " + _qrMsg + "<BR>RESPONSE DATA: " + _qrRes);
                }
            }
            catch (Exception _ex)
            {
                // Do Something
                _string.Append("QRCODE ERROR: " + _ex.Message);
            }
        }
        //_string.Append(@"<div class='row'>  <div class='form-group col-xs-12 text-center' > 
        //                                    <img src = '../../images/QRCODEExample.png' /> </div></div> ");
        //_string.Append("<div class='row'><div class='form-group col-xs-12 text-center' > QRCODE MESSAGE: - RESPONSE DATA: - </div></div>");
        //_string.Append("<img id=\"qrCode\" src=\"data:image/gif;base64," + _billerId + "\"/>");
        return _string.ToString();
    }


    public static string getStudentId(string _studentCode,string _stdFName,string _stdLName)
    {
        DataSet _ds = ActDB.getStudentKey(_studentCode, _stdFName, _stdLName);
        int _count = _ds.Tables[0].Rows.Count;

        string _studentId = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentId = _dr["studentId"].ToString();
            }
        }
        return _studentId;

    }

    public static string getStudentCode(string _studentCode, string _stdFName, string _stdLName)
    {
        DataSet _ds = ActDB.getStudentKey(_studentCode, _stdFName, _stdLName);
        int _count = _ds.Tables[0].Rows.Count;


        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentCode = _dr["studentCode"].ToString();
            }
        }
        return _studentCode;

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-02
    /// Perpose: แสดงหน้ารายงานกราฟ Spiral Graph
    /// Method : getlistRptMahidolCoreValue
    /// Sample : N/A
    /// </summary>
    public static string getMahidolCoreValueUniversity(string _studentId, string _facultyId, string _programId, string _acaYear, string _semester, string _groupIndicatorId,string _indicatorId)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getMahidolCoreValueUniversity(_studentId, _facultyId, _programId, _acaYear, _semester, _groupIndicatorId, _indicatorId);
        string _abbrevEn = "", _indicatorName = "", _hours = "";
        DataTable _dt = new DataTable();
        int _i = 0;

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _abbrevEn = _dr["abbrevEn"].ToString();
                _indicatorName = _dr["indicatorName"].ToString();
                _hours = _dr["hours"].ToString();
                _result.name[_i] = _abbrevEn + ":" + _indicatorName;
                _result.data[_i] = Convert.ToDouble(_hours);
                _i++;

            }
        }

        //_result.name = new string[] {"M:Mastery", "A:Altruism", "H:Harmony", "I:Integrity","D:Determination","O:Originality","L:Leadership"};
        //_result.data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        //_result.data = "5,4,5,4,1,1,1";

        return JsonConvert.SerializeObject(_result);
    }



    public static string getCharacterSummaryUniversity(string _studentId, string _groupCharacterId, string _facultyId, string _programId, string _acaYear, string _semester)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getCharacterSummaryUniversity(_studentId, _groupCharacterId, _facultyId, _programId, _acaYear, _semester);
        string _abbrevEn = "", _characterNameTh = "", _countAct = "";
        DataTable _dt = new DataTable();
        int _i = 0;

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                // _abbrevEn = _dr["characterId"].ToString();
                _characterNameTh = _dr["characterNameTh"].ToString();
                _countAct = _dr["countAct"].ToString();
                _result.name[_i] = _characterNameTh;
                _result.data[_i] = Convert.ToDouble(_countAct);
                _i++;

            }
        }


        return JsonConvert.SerializeObject(_result);
    }

    public static string getRequestAT(string _studentCondition, string _studentId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getRequestDoc(_studentId);
        int _countRow = _ds.Tables[0].Rows.Count;
        int _countRequestDoc = 0;
        string _requestDocId = string.Empty;
        string _stsPass = string.Empty;
        string _requestDate = string.Empty;
        string _requestTime = string.Empty;
        string _requestReasonText = string.Empty;
        string _disableTxtReason = string.Empty;
        string _disableSelectPicker = string.Empty;
        string _requestReasonId = string.Empty;
        if (_countRow > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _requestDocId = _dr["requestDocId"].ToString();
                _countRequestDoc = Convert.ToInt32(_dr["countRequestDoc"]);
                _stsPass = _dr["stsPass"].ToString();
                _requestDate = _dr["requestDate"].ToString();
                _requestTime = _dr["requestTime"].ToString();
                _requestReasonText = _dr["requestReasonText"].ToString();
                _requestReasonId = _dr["requestReasonId"].ToString();
            }
        }

        if(_requestReasonId!="")
        {
            _disableSelectPicker = "disabled";
            _disableTxtReason = "disabled";
        }
        else
        {
            _disableSelectPicker = "";
            _disableTxtReason = "";
        }




        _string.Append(ActReportUI.getListConditionToComplete(_studentCondition, _studentId));
        _string.Append("<table id='tblRequestAT' class='table  table-bordered'");
        _string.Append(@" <tr >
                            <td colspan='2' class='bg-primary'>
                            Request Activity Transcript
                            </td>
                          </tr>

                          <tr>
                            <td class='text-right' width='20%' >
                              <span class='th' >เหตุผลการขอ :</span> <span class='en' >reason :</span> 
                            </td>
                            <td  >
                              <div class='form-group text-left'>
                                     " + ActUI.getListDdlRequestReasonPicker(_disableSelectPicker) + @"
                              </div>
                             </td>
                          </tr>

                          <tr>
                            <td class='text-right' >
                              <span class='th' >อื่นๆ :</span> <span class='en' >other :</span> 
                            </td>
                            <td  >
                              <div class='form-group text-left'>
                                     <input type='text' class='form-control' id='txtOtherReason' value='"+ _requestReasonText + "' placeholder='เหตุผลอื่นๆในการขอเอกสาร Activity Transript' "+ _disableTxtReason + @"/>
                              </div>
                             </td>
                          </tr>

                          <tr>
                                <td  class='text-right' >
                                    <span class='th'><b>วันที่ขอเอกสาร AT :  </span>
                                    <span class='en'><b>Request date :  </span>
                                    
                                </td>
                                <td  >
                                 " + _requestDate + " " + _requestTime +@"
                                </td >
                          </tr>");
        _string.Append(@"       <tr >
                                <td colspan='2' style='height:28px;background-color:#e4e2f6;' >
                                    <span class='th' style='color:red;'>* นักศึกษาสามารถยื่นความจำนงค์ขอรับใบ AT ได้ในกรณี 'ผ่าน' เกณฑ์การเข้าร่วมกิจกรรมเท่านั้น</span>
                                    <span class='en' style='color:red;'>* Students can apply for an AT certificate only if they 'pass' the entry requirements.</span>
                                </td>
                                </tr>

                        </table>");
        _string.Append(@"<table width='100%'>
                                        <tr >
                                <td class='text-center'>");
        if (_stsPass == "0") // ถ้าไม่ผ่าน AT ปุ่มเหลือง
        {
            _string.Append("<button type='button' class='btn btn-warning glyphicon glyphicon-wrench btnWanringNotPass' > <span class='th'>ไม่ผ่านเกณฑ์</span><span class='en'>NotPass</span></button>");
        }
        else if ((_stsPass == "1") && (_countRequestDoc == 0)) // ต้องผ่าน AT และต้องไม่เคยขอเอกสาร ถึงจะมี Request 
        {
            _string.Append("<button type='button' class='btn btn-success glyphicon glyphicon-file btnSetRequestAT'> RequestAT</button>");
        }
        else
        {
            _string.Append("<button type='button' class='btn btn-danger glyphicon glyphicon-remove btnSetCancelRequestAT' data-requestdocid='" + _requestDocId + "'> CancelRequestAT</button>");
        }

        _string.Append(@"     </td>
                                </tr>    
                        </table>");
        return _string.ToString();
    }


    public static string getListRequestReasonToSelectPicker(string _studentId)
    {
        StringBuilder _string = new StringBuilder();
        string _requestReasonId = "";
        string _requestStr = "";
        DataSet _ds = ActDB.getRequestDoc(_studentId);
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _requestReasonId = _dr["requestReasonId"].ToString();

            }



        }

        string[] words = _requestReasonId.Split(',');
        _string.Append("[");
        foreach (string word in words)
        {
            _requestStr += "\"" + word + "\",";
        }
        _requestStr = _requestStr.Substring(0, _requestStr.Length - 1);
        _string.Append(_requestStr);
        _string.Append("]");

        return _string.ToString();
    }

    ///// <summary>
    ///// Auther : เจตน์ เครือชะเอม
    ///// Date   : 2019-07-10
    ///// Perpose: แสดงหน้ากิจกรรมกำหนดให้เข้าร่วม
    ///// Method : getListActivitiesStdHIDEFType1
    ///// Sample : N/A
    ///// </summary>
    //public static string getListActNewRelease()
    //{
    //    StringBuilder _string = new StringBuilder();
    //    string _html = "555";
    //    _string.Append(_html);
    //    return _string.ToString();
    //}


}