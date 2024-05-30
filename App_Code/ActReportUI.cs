using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Newtonsoft.Json;
/// <summary>
/// Summary description for ActReportUI
/// </summary>
public class ActReportUI
{
	public ActReportUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-25
    /// Perpose: 
    /// Method : rptProjectSummary
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptProjectSummary(string _facultyId, string _facultyCode, string _facultyNameTh)
    {
        DataSet _ds = ActDB.rptProjectSummary(_facultyId);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        string _inputHdd = "", _acaYear = "";
        StringBuilder _string = new StringBuilder();


        _string.Append(@"
        <h1 class='page-header'>รายงานสรุปจำนวนกิจกรรมทั้งหมดทุกภาคการศึกษา</h1>
        <h3 >" + _facultyCode + " - " + _facultyNameTh + @"</h3>
        <div id='divGraphProjectSummary'></div>
        <div id='divRptProjectSummary'>
        <table class='table'>

        
            <tr bgcolor='#efefef'>
                <td>
                    ปีการศึกษา
                </td>
                <td align='center'>
                    <font>จำนวนกิจกรรม</font>
                </td>
                <td align='center'>
                    จำนวนชั่วโมงกิจกรรม
                </td>
                <td>
                    จำนวนนักศึกษาเข้าร่วมกิจกรรม (ครั้ง)
                </td>
                <td>
                    งบประมาณ
                </td>
            </tr>");



        string _countProject = "", _sumHours = "", _countStd = "", _sumBudget = "", _acaYearFirst = "";

        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _countProject = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countProject"]));

                _sumHours = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHours"]));

                _countStd = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStd"]));

                _sumBudget = String.Format("{0:#,##0.##}", Convert.ToDouble(_dr["sumBudget"]));

                _acaYear = _dr["acaYear"].ToString();

                if (_i == 1)
                {
                    _acaYearFirst = _dr["acaYear"].ToString();
                }
                _string.Append(@"
                 <tr bgcolor='#f7f8f9'>
                        <td>
                            <font color='#025ebc'><a href='#' data-acayear='" + _acaYear + "' class='btnRptProjectSummaryDetail'>" + _acaYear + @"</a></font>
                        </td>
                        <td align='right'>
                            " + _countProject + @" กิจกรรม
                        </td>
                        <td align='right'>
                            <font color='#025ebc'><a href='#' data-acayear='" + _acaYear + "' class='btnRptProjectSummaryDetail'>" + _sumHours + @" ชั่วโมง </a></font>
                        </td>
                        <td align='right'>
                            " + _countStd + @" ครั้ง
                        </td>
                        <td align='right'>
                            " + _sumBudget + @" บาท 
                        </td>
                </tr>
                                        ");

                _i += 1;


            }

        }
        else
        {
            _string.Append(@"
                            <tr bgcolor='#f7f8f9' align='center'>
                            <td  colspan='5'>ไม่พบข้อมูล</td></tr> ");
        }
        _inputHdd = "<input id='hddAcaYearStart' type='hidden' value='" + _acaYearFirst + "' /> ";

        _string.Append(@"  </table>" + _inputHdd + "</div>");




        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-06-25
    /// Perpose: 
    /// Method : rptProjectSummaryDetail
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptProjectSummaryDetail(string _facultyId, string _acaYear)
    {
        DataSet _ds = ActDB.rptProjectSummaryDetail(_facultyId, _acaYear);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;

        StringBuilder _string = new StringBuilder();
        string _sumHours = "";
        string _sumHoursAll = "";
        _string.Append(@"
                
                           <div class='row'>
                           <div class='form-group col-xs-12 text-center'>
                           <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                           </div></div>

                        <table class='table'>
                            <caption> <h3>ปีการศึกษา " + _acaYear + @"</h3></caption>
                            <thead>
                            <tr bgcolor='#efefef'>
                                <th  class='col-sm-1'>
                                    ลำดับ
                                </th>
                                <th   class='col-sm-2'>
                                    ชื่อย่อ Indicator ไทย
                                </th>
                                <th   class='col-sm-2'>
                                    ชื่อย่อ Indicator อังกฤษ
                                </th>
                                <th  class='col-sm-3'>
                                    ชื่อเต็ม Indicator ไทย
                                </th>  
                                <th  class='col-sm-2'>
                                    ชื่อเต็ม Indicator อังกฤษ
                                </th>      
                                <th class='col-sm-2'>
                                    จำนวนชั่วโมงกิจกรรม
                                </th>

                            </tr>
                            <thead>");

        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {



                _sumHours = String.Format("{0:#,##0.##}", Convert.ToDouble(_dr["sumHours"]));

                _sumHoursAll = String.Format("{0:#,##0.##}", Convert.ToDouble(_dr["sumHoursAll"]));

                _string.Append(@"
                 <tr bgcolor='#f7f8f9'>
                        <td align='center'>
                            " + _i.ToString() + @"
                        </td>
                        <td align='left'>
                            " + _dr["abbrevTh"] + @" 
                        </td>
                        <td align='left'>
                            " + _dr["abbrevEn"] + @" 
                           
                        </td>
                        <td align='left'>
                            " + _dr["indicatorNameTh"] + @" 
                        </td>

                        <td align='left'>
                            " + _dr["indicatorNameEn"] + @" 
                        </td>
                        <td align='right'>
                             <font color='#025ebc'>" + _sumHours + @" ชั่วโมง</font> 
                        </td>
                </tr>
                                        ");

                _i += 1;


            }
            _string.Append(@"
                        <tr bgcolor='#efefef'>
                        <td colspan='6' align='right'>
                            จำนวนชั่วโมงทั้งหมด " + _sumHoursAll + @" ชั่วโมง
                        </td></tr>");

        }
        else
        {
            _string.Append(@"
                            <tr bgcolor='#f7f8f9' align='center'>
                            <td  colspan='6'>ไม่พบข้อมูล</td></tr> ");
        }

        _string.Append("   </table>   ");
        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-30
    /// Perpose: 
    /// Method : pageDialogConditionTargetGroup
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptSearhStudentCondition(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();

        _string.Append(@"    

                    <div id='divStudentCondition' class='tab-pane fade in active' >
                        <h2 class='page-header'>ค้นหาข้อมูลนักศึกษารายบุคคล</h2> <p>  ");
//        _string.Append(@"  
//                            <div class='row '>
//                                <div class='form-group col-xs-6 '>
//                                " + ActUI.getListAcaYear("") + @"
//                                </div>
//                                <div class='form-group col-xs-6 '>
//                                " + ActUI.getListSemester("") + @"
//                                </div>
//                            </div> ");
        _string.Append(@"  
                            <div class='row '>
                                      <div class='form-group col-xs-4 '>
                                             <label for=''>
                                                 รหัสนักศึกษา</label> 
                                          <input type='number' class='form-control txtStudentCode' placeholder='รหัสนักศึกษา' /> " + @"
                                     
         
                                     </div>

                                     
                                       <div class='form-group col-xs-4'>
                                             <label for=''>
                                                 ชื่อ</label> 
                                               <input type='text' class='form-control txtStdFName' placeholder='ชื่อนักศึกษา' /> " + @"
                                       </div>
                                         <div class='form-group col-xs-4'>
                                             <label for=''>
                                                 นามสกุล</label> 
                                               <input type='text' class='form-control txtStdLName' placeholder='นามสกุลนักศึกษา' /> " + @"
                                         </div>
                                     </div>
       
    

                                      <div class='row'>
                                        <div class='form-group col-xs-12 text-center'>
                                        <button type='button' class='btn btn-info btn-md btnSearchStudentCondition glyphicon glyphicon-search'> ค้นหา</button>
                                        </div>
                                      </div>
                                   </p>
                                    <div id='divResultStudentCondition'></div>
                                    <div id='divStdDetailActivity'></div>
                                </div> ");
                                     // < div class='row'>
                                     //    <div class='form-group col-xs-12'>
                                     //        " + ActUI.getListProgram(_facultyId) + @"
                                     //    </div>
                                     //</div>

        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-07-31
    /// Perpose: 
    /// Method : resultStudentCondition
    /// Sample : N/A
    /// </summary>
    /// 
    public static string resultStudentCondition(string _studentCode, string _stdFName, string _stdLName, string _programId)
    {
        StringBuilder _string = new StringBuilder();
        string _firstname = "";
        string _lastname = "";
        string _facultyNameTh = "";
        string _programNameTh = "";
        string _countAct = "";
        string _countHour = "";
        string _headerHtml = "";
        string _bodyHtml = "";
        string _bodyColumnHtml = "";
        string _projectNameTh = "", _positionNameTh = "", _hoursA3 = "", _hoursA4 = "";
        //string _typeIndicator = "";
        //string _hoursA1 = "";
        //string _hoursA2 = "";
        //string _hoursM = "";
        //string _hoursA = "";
        //string _hoursH = "";
        //string _hoursI = "";
        //string _hoursD = "";
        //string _hoursO = "";
        //string _hoursL = "";
        string _chkPassDetail = "";
        //string _acaYear = "";
        string _studentId = "";
        int _stdCondition=0;
        DataSet _ds = ActDB.getListSummaryProjectByStudent(_studentCode, _stdFName, _stdLName, _programId,"","");
    
        // ต้องมาแก้ตรงจุดนี้ในส่วนของการดึงจากหน้า Admin มาใช้
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentId = _dr["studentId"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _stdCondition = Convert.ToInt32(_studentCode.Substring(0, 2));
                _firstname = _dr["firstname"].ToString();
                _lastname = _dr["lastname"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _countAct = _dr["countAct"].ToString();
                _countHour = "";//= _dr["countHour"].ToString();
                //_typeIndicator = _dr["typeIndicator"].ToString();
                _projectNameTh = _dr["projectNameTh"].ToString();
                _positionNameTh = "";//= _dr["positionNameTh"].ToString();
                _chkPassDetail = _dr["chkPassRemark"].ToString();
                //_acaYear = _dr["acaYear"].ToString();
            }
            _bodyHtml += ActStdUI.getListActivitiesType1(_studentId);
            _bodyHtml += ActStdUI.getListActivitiesType2(_studentId);

//                if (_stdCondition < 60)
//                {
//                    _hoursA1 = _dr["A.1"].ToString();
//                    _hoursA2 = _dr["A.2"].ToString();
//                    _hoursA3 = _dr["A.3"].ToString();
//                    _hoursA4 = _dr["A.4"].ToString();
//                    _bodyHtml += @" 
//                             <tr bgcolor='#f7f8f9'>
//
//                                <td class='text-center'>
//                                    " + _acaYear + @"
//                                </td>
//                                <td >
//                                    " + _projectNameTh + @"
//                                </td>
//                                <td  >
//                                     " + _positionNameTh + @"
//                                </td>
//                                <td  >
//                                     " + _hoursA1 + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursA2 + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursA3 + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursA4 + @"
//                                </td>   
//                                <td >
//                                    
//                                </td>
//                            </tr> ";
//                }
//                else
//                {
//                    _hoursM = _dr["M"].ToString();
//                    _hoursA = _dr["A"].ToString();
//                    _hoursH = _dr["H"].ToString();
//                    _hoursI = _dr["I"].ToString();
//                    _hoursD = _dr["D"].ToString();
//                    _hoursO = _dr["O"].ToString();
//                    _hoursL = _dr["L"].ToString();
//                    _bodyHtml += @" 
//                             <tr bgcolor='#f7f8f9'>
//                                <td class='text-center'>
//                                    " + _acaYear + @"
//                                </td>
//                                <td >
//                                    " + _projectNameTh + @"
//                                </td>
//                                <td  >
//                                     " + _positionNameTh + @"
//                                </td>
//                                <td  >
//                                     " + _hoursM + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursA + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursH + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursI + @"
//                                </td>  
//                                <td  >
//                                     " + _hoursD + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursO + @"
//                                </td>   
//                                <td  >
//                                     " + _hoursL + @"
//                                </td>    
//                                <td >
//                                    
//                                </td>
//                            </tr> ";
//                }

        //   }

        //    _bodyColumnHtml = columnIndicatorForSummary(_typeIndicator);
        //    _bodyHtml += "</table> ";

            _headerHtml = @" <div style='font-size: 15px;'>
                                    <div class='row '>
                                          
                                          <div class='form-group col-xs-2 '>
                                                 <b>ชื่อ-นามสกุล :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _firstname + " " + _lastname + @"
                                          </div>

                                          <div class='form-group col-xs-2 '>
                                                 <b>รหัสนักศึกษา :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _studentCode + @"
                                          </div>

                                    </div>
                                    <div class='row '>
                                          <div class='form-group col-xs-2 '>
                                                 <b>คณะ :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _facultyNameTh + @"
                                          </div>

                                          <div class='form-group col-xs-2 '>
                                                 <b>หลักสูตร :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left' >
                                                 " + _programNameTh + @"
                                          </div>
                                    </div>
                                    <div class='row '>
                                          <div class='form-group col-xs-2 '>
                                                 <b>จำนวนกิจกรรม :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _countAct + @" กิจกรรม
                                          </div>

                                          <div class='form-group col-xs-2 '>
                                                 <b>จำนวนชั่วโมง :</b>
                                          </div>
                                          <div class='form-group col-xs-4 text-sm-left'>
                                                 " + _countHour + @" ชั่วโมง
                                          </div>
                                    </div>


                                    <div class='row '>
                                          <div class='form-group col-xs-2 '>
                                                 <b>สถานะ :</b> " + _chkPassDetail + @"
                                                                            
                                          </div>
                                          <div class='form-group col-xs-10 '>
                                                 <a href='#' class='btnGetListConditionToComplete' data-toggle='modal' data-target='#divPopup'>  หลักเกณฑ์ผ่านการเข้าร่วมกิจกรรมตามปีการศึกษา</a>
                                          </div>
                                         
                                    </div>
                           </div>";



        }
        else
        {
            _headerHtml = "";
            _bodyHtml = @"<div style='font-size: 16px;'> 
                                <div class='row '>
                                    <div class='form-group col-xs-12 text-center'>
                                         <b>ผลการค้นหา :</b> ไม่พบข้อมูลที่ค้นหาในภาคการศึกษานี้
                                    </div>
                                </div>  
                            </div>";
        }


        _string.Append(_headerHtml + _bodyColumnHtml + _bodyHtml );
        _string.Append("<input id='hddStudentCondition' type='hidden' value='"+_stdCondition+"' />");
        return _string.ToString();



    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-03
    /// Perpose: 
    /// Method : columnIndicatorForSummary
    /// Sample : N/A
    /// </summary>
    /// 
    public static string columnIndicatorForSummary(string _typeIndicator)
    {
        StringBuilder _string = new StringBuilder();

        if (_typeIndicator == "0")
        {
            _string.Append(@" 
                            <table class='table'>
                            
                            <thead>
                            <tr bgcolor='#efefef'>
                                <th  class='col-sm-1 text-center'>
                                    ปีการศึกษา
                                </th>
                                <th  class='col-sm-3'>
                                    ชื่อโครงการ
                                </th>
                                <th   class='col-sm-2'>
                                    ตำแหน่ง
                                </th>
                                <th   class='col-sm-1'>
                                    A1
                                </th>
                                <th  class='col-sm-1'>
                                    A2
                                </th>  
                                <th  class='col-sm-1'>
                                    A3
                                </th>     
                                <th  class='col-sm-1'>
                                    A4
                                </th>       
                                <th class='col-sm-2'>
                                    หน่วยชั่วโมง
                                </th>
                            </tr>
                            <thead>
                            ");
        }
        else
        {
            _string.Append(@"<table class='table'>
                            
                            <thead>
                            <tr bgcolor='#efefef'>
                                <th  class='col-sm-1 text-center'>
                                    ปีการศึกษา
                                </th>
                                <th  class='col-sm-2'>
                                    ชื่อโครงการ
                                </th>
                                <th   class='col-sm-1'>
                                    ตำแหน่ง
                                </th>
                                <th   class='col-sm-1'>
                                    M
                                </th>
                                <th  class='col-sm-1'>
                                    A
                                </th>  
                                <th  class='col-sm-1'>
                                    H
                                </th>     
                                <th  class='col-sm-1'>
                                    I
                                </th>    
                                <th  class='col-sm-1'>
                                    D
                                </th>
                                <th  class='col-sm-1'>
                                    O
                                </th>  
                                <th  class='col-sm-1'>
                                    L
                                </th>  
                                <th class='col-sm-1'>
                                    หน่วยชั่วโมง
                                </th>
                            </tr>
                            <thead> ");
        }

        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-01
    /// Perpose: 
    /// Method : getListConditionToComplete
    /// Sample : N/A
    /// </summary>
    public static string getListConditionToComplete(string _studentCondition,string _studentId)
    {
        
        StringBuilder _string = new StringBuilder();
        string _acaYear = "25"+_studentCondition;
        DataSet _ds = ActDB.getListStudentCompleteCondition(_acaYear);
        _string.Append(@"<div class='row '> 
                              <div class='form-group page-header col-xs-12' > 
                              <h3 ><span class='th'><b>เกณฑ์การร่วมกิจกรรมสำหรับนักศึกษาปี 25" + _studentCondition + @"</span><span class='en'>Activity Criteria</span></h3>
                              </div>
                         </div>");
        if (Convert.ToInt32(_studentCondition) >= 62)
        {

            _string.Append(@" <table class='table table-striped table-bordered'>
                             <tr >
                                <td nowrap='nowrap'>
                                     <span class='th'>กิจกรรมกำหนดให้เข้าร่วม : พิธีปฐมนิเทศนักศึกษาใหม่ระดับมหาวิทยาลัย หรือระดับส่วนงาน</span>
                                     <span class='en'>Activity scheduled to participate : New student orientation at the university level Or department level</span>
                                </td>
                                <td >
                                    <span class='th'>1 กิจกรรม 3 ชั่วโมง </span>
                                    <span class='en'>1 act. 3 hour</span>
                                </td>  
                            </tr>");
            // เอาออกเมื่อวันที่ 14/06/2565
            //<tr >
            //    <td >
            //         <span class='th'>กิจกรรมกำหนดให้เข้าร่วม : พิธีไหว้ครูระดับมหาวิทยาลัย หรือระดับส่วนงาน</span>
            //         <span class='en'>Activity scheduled to participate : University Paying Ceremony Or department level</span>
            //    </td>
            //    <td >
            //        <span class='th'>1 กิจกรรม 3 ชั่วโมง </span>
            //        <span class='en'>1 act. 3 hour</span>
            //    </td>  
            //</tr>

            _string.Append(@"<tr >
                                <td >
                                     <span class='th'>กิจกรรมเลือกเข้าร่วม : กิจกรรมจิตอาสา (Volunteer)	</span>
                                     <span class='en'>Activity Choose to participate : Volunteer</span>
                                </td>
                                <td >
                                    <span class='th'>10 ชั่วโมง</span>
                                    <span class='en'>10 hour</span>
                                </td>  
                            </tr>                        
                            <tr >
                                <td >
                                     <span class='th'>กิจกรรมเลือกเข้าร่วม : กิจกรรม Mahidol HIDEF</span>
                                     <span class='en'>Activity Choose to participate : Mahidol HIDEF</span>
                                </td>
                                <td >
                                    <span class='th'>3 ด้าน (ด้านละไม่น้อยกว่า 10 ชั่วโมง)</span>
                                    <span class='en'>3 sides (not less than 10 hours on each side)</span>
                                </td>  
                            </tr>
                            <tr >
                                <td >
                                     <span class='th'>กิจกรรมเลือกเข้าร่วม : กิจกรรมส่งเสริม 21st Century Skills อื่นๆ</span>
                                     <span class='en'>Activity Choose to participate : 21st Century Skills and other</span>
                                </td>
                                <td >
                                    <span class='th'>ไม่บังคับ</span>
                                    <span class='en'>not forcing</span>
                                </td>  
                            </tr>   
                             <tr >
                                <td  colspan='2' style='color:red;'>
                                    <span class='th'>* หมายเหตุ : กิจกรรมเลือกเข้าร่วม ต้องไม่น้อยกว่า 97 หน่วยชั่วโมง</span>
                                    <span class='en'>* Remark : Activity Choose to participate Not less than 97 units of hours</span>
                                </td>


                            </tr>");

        }
        //else 
        //{
        //    _string.Append(@" <table class='table table-bordered'>

        //                        <thead>
        //                        <tr class='bg-primary'>
        //                            <th class='col-sm-8'>
        //                                <span class='th'>เงื่อนไข</span><span class='en'>Condition</span>
        //                            </th>
        //                            <th class='col-sm-4'>
        //                                <span class='th'>หน่วยนับ</span><span class='en'>Unit</span>
        //                            </th>  
        //                        </tr>
        //                        </thead>");
        //    _string.Append(@" 
        //                     <tr >
        //                        <td nowrap='nowrap'>
        //                             <span class='th'>กิจกรรมทุกประเภทไม่ต่ำกว่า</span>
        //                             <span class='en'>All types of activities at least</span>
        //                        </td>
        //                        <td >
        //                            <span class='th'>15 กิจกรรม</span>
        //                            <span class='en'>15 activities</span>
        //                        </td>  
        //                    </tr>
        //                    <tr >
        //                        <td nowrap='nowrap'>
        //                             <span class='th'>จำนวนชั่วโมงกิจกรรมทุกประเภทไม่ต่ำกว่า</span>
        //                             <span class='en'>The number of hours for all types of activities is not less than</span>
        //                        </td>
        //                        <td >
        //                            <span class='th'>100 ชั่วโมง</span>
        //                            <span class='en'>100 hours</span>
        //                        </td>  
        //                    </tr>
        //                    </table>");
        //}
        else if (_ds.Tables[0].Rows.Count > 0)
        {

            _string.Append(@" <table class='table table-bordered'>

                            <thead>
                            <tr class='bg-primary'>
                                <th class='col-sm-12'>
                                    <span class='th'>เงื่อนไข</span><span class='en'>Condition</span>
                                </th>
           
                            </tr>
                            </thead>");

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"
                             <tr >
                                <td  >
                                     <span class='th'>" + _dr["conditionNameTh"]  + @"</span>
                                     <span class='en'>" + _dr["conditionNameEn"]  + @"</span>
                                </td>

                            </tr> ");

            }

        }


        _ds = ActDB.getTransStudentPass(_studentId);
        string _stsPass = "", _iconStatusPass = "", _stsPassTh = "", _stsPassEn = "";
        string _createdDate = "", _createdTime="";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _stsPass = _dr["stsPass"].ToString();
                _createdDate = _dr["createdDate"].ToString();
                _createdTime = _dr["createdTime"].ToString();

                if (_stsPass == "1")
                {
                    _iconStatusPass = "<i style='color:green;' class='glyphicon glyphicon-ok'></i>";
                    _stsPassTh = "ผ่าน";
                    _stsPassEn = "Pass";
                }
                else
                {
                    _iconStatusPass = "<i style='color:red;' class='glyphicon glyphicon-remove'></i>";
                    _stsPassTh = "ไม่ผ่าน";
                    _stsPassEn = "Not Pass";
                }
                _string.Append(@"<tr ><td colspan='2' style='background-color:#e4e2f6;'>
                                    <span class='th'><b>สถานะการเข้าร่วมกิจกรรม :  " + _iconStatusPass + " " + _stsPassTh + "&nbsp;&nbsp;&nbsp;<small > ประมวลผลข้อมูล ณ วันที่ " + _createdDate +@"</small ></b></span>
                                    <span class='en'><b>Status :  " + _iconStatusPass + " " + _stsPassEn + "&nbsp;&nbsp;&nbsp;<small > Detail at Day " + _createdDate +  @"</small ></b></span>
                                    
                                </td>
                                </tr>");
            }
        }
        _string.Append("</table>");

        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-09
    /// Perpose: 
    /// Method : pageConditionStudentCompleteActivityGroupAcaYear
    /// Sample : N/A
    /// </summary>
    /// 
    public static string pageConditionStudentCompleteActivityGroupAcaYear()
    {

        StringBuilder _string = new StringBuilder();
        //_string.Append("</br><h2 class='page-header'>อยู่ระหว่างการปรับปรุงข้อมูล</h2>");
        _string.Append("<h2 class='page-header'>รายงานสรุปจำนวนนักศึกษาที่เข้าร่วมกิจกรรมทั้งหมดแยกตามปีการศึกษา</h2>");
        ////_string.Append("<div class='row '>");
        ////_string.Append("<div class='col-xs-4 text-right'><label ><h4>เลือกเงื่อนไข</h4></label></div>");
        ////_string.Append("<div class='col-xs-5 ' >" + getListTypeCompleteAct() + "</div>");
        ////_string.Append("<div class='col-xs-3 '><button type='button' class='btn btn-info btn-md btnSearchRptReportCompleteAct glyphicon glyphicon-search'> ค้นหา</button></div>");
        ////_string.Append("</div>");
        _string.Append("<div id='divDetailReport'></div>");

        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-09
    /// Perpose: 
    /// Method : rptStudentCompleteActivity
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptStudentCompleteActivityGroupAcaYear(string _facultyId, string _facultyCode, string _facultyNameTh)
    {
        DataSet _ds = ActDB.rptStudentCompleteActivityGroupAcaYear(_facultyId);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        string _acaYear = "", _countStdPass = "", _countStdNotPass = "", _countStdAll="";
        string _percentPass = "", _percentNotPass = "";
        string _createdDate = "";
        string _htmlHeader = "";
        string _htmlBody = "";
        string _createdTime = "";
        StringBuilder _string = new StringBuilder();


        //_string.Append("<div id='divDetailReport'>");






         if (_count > 0)
         {


             foreach (DataRow _dr in _ds.Tables[0].Rows)
             {


                _acaYear = _dr["acaYear"].ToString();
                _countStdPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdPass"]));
                _countStdNotPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdNotPass"]));
                _countStdAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdAll"]));
                _percentPass = _dr["percentPass"].ToString();
                _percentNotPass = _dr["percentNotPass"].ToString();
                _createdDate = _dr["createdDate"].ToString();
                _createdTime = _dr["createdTime"].ToString();
                
                // data-typecomlpeteact='"+ _stsPass + "'
                // class='btnRptStdCompleteActGroupFaculty'
                // class='btnGetListRptStudent'
                _htmlBody +=@"
                            <tr style='cursor:pointer;' data-acayear='" + _acaYear + @"' class='btnRptStdCompleteActGroupFaculty'> 
                                    <td class='text-center'>
                                        <font color='#025ebc'><a href='#'  >" + _acaYear + @"</a></font>
                                    </td>
                                   <td class='text-right'>
                                        <font color='#025ebc' ><span style='font:blue;'   >"+ _countStdAll + @"</span></font>
                                    </td>
                                   <td class='text-right'>
                                        <font color='#025ebc' ><span style='font:blue;'   >" + _countStdPass + @"</span></font>
                                   </td>
                                   <th class='text-right' >
                                        <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentPass + @"</span></font>
                                   </th>                                   
                                   <td class='text-right'>
                                        <font color='#025ebc' ><span style='font:blue;'   >" + _countStdNotPass + @"</span></font>
                                    </td>
                                   <th class='text-right' >
                                        <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentNotPass + @"</span></font>
                                   </th>       
                            </tr>";

                 _i += 1;


             }

         }
         else
         {
            _htmlBody+=@"<tr bgcolor='#f7f8f9' align='center'>
                              <td  colspan='2'>ไม่พบข้อมูล</td></tr> ";
         }


        _htmlBody += "</table>";

        _htmlBody += "<div id='divRptStdCompleteActDetail'></div>";
        _htmlBody += "<div id='divRptStdCompleteGroupProgram'></div>"; // กลับเอามาเปิดใช้ใหม่วันที่ 14 ก.ค. 2564
        _htmlBody += "<div id='divRptStdCompleteGroupStudent'></div>";

        _htmlHeader = @"<h3 >" + _facultyCode + " - " + _facultyNameTh + @" <small>ข้อมูล ณ วันที่ " + _createdDate + " เวลา "+ _createdTime + @" น.</small></h3>

           <table class='table table-bordered table-hover'>
            <thead>
            <tr class='bg-info'>
                <th rowspan='2'  class='text-center col-sm-3'>
                    รหัสนักศึกษา(ตามปีการศึกษาที่เข้าศึกษา)
                </th>
                <th rowspan='2'  class='col-sm-3 text-center'>
                    จำนวนนักศึกษาทั้งหมด(คน)
                </th>
                <th colspan='2' class='col-sm-3 text-center'>
                    นักศึกษาที่ผ่านเกณฑ์
                </th>
                <th colspan='2' class='col-sm-3 text-center'>
                    นักศึกษาที่ไม่ผ่านเกณฑ์
                </th>
            </tr>
            <tr class='bg-info'>
                <th class='text-center'>
                    คน
                </th>
                <th class='text-center' >
                    <font color='#2c2e6a' >%</font>
                </th>
                <th class='text-center'>
                    คน
                </th>
                <th class='text-center' >
                    <font color='#2c2e6a' >%</font>
                </th>
            </tr>
        </thead>";
        _string.Append(_htmlHeader+ _htmlBody);

        return _string.ToString();

    }





    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-10
    /// Perpose: 
    /// Method : getlistRptStdCompleteActGroupFaculty
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptStudentCompleteActivityGroupFaculty(string _facultyId, string _acaYear)
    {
        DataSet _ds = ActDB.rptStudentCompleteActivityGroupFaculty(_facultyId, _acaYear);
        //int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        string _facultyIdDb = "", _facultyCode = "", _facultyNameTh = "", _countStdPass = "", _countStdNotPass="";
        string _countStdAll = "", _percentPass="", _percentNotPass="";
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                         <h4 >ปีการศึกษาที่เข้าศึกษา " + _acaYear+ @"</h4>
                         <table class='table tblStudentCriteria  table-bordered table-hover'>
                            <thead>
                            <tr class='bg-info' >
                                <th rowspan='2' class='col-sm-1 text-center'>
                                    รหัสคณะ
                                </th>
                                <th rowspan='2' class='col-sm-4 text-center'>
                                    ชื่อคณะ
                                </th>
                                <th rowspan='2' class='col-sm-3 text-center'>
                                    จำนวนนักศึกษาทั้งหมด(คน)
                                </th>
                                <th colspan='2' class='col-sm-2 text-center'>
                                    นักศึกษาที่ผ่านเกณฑ์
                                </th>
                                <th colspan='2' class='col-sm-2 text-center'>
                                    นักศึกษาที่ไม่ผ่านเกณฑ์
                                </th>
                                </tr>
                                <tr class='bg-info'>
                                    <th class='text-center'>
                                        คน
                                    </th>
                                    <th class='text-center' >
                                        <font color='#2c2e6a' >%</font>
                                    </th>
                                    <th class='text-center'>
                                        คน
                                    </th>
                                    <th class='text-center' >
                                        <font color='#2c2e6a' >%</font>
                                    </th>
                                </tr>
                    </thead>");
        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {


                _facultyIdDb = _dr["facultyId"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _percentPass = _dr["percentPass"].ToString();
                _percentNotPass = _dr["percentNotPass"].ToString();
                _countStdAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdAll"]));
                _countStdPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdPass"]));
                _countStdNotPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdNotPass"]));
                // class='btnRptStdCompleteActGroupProgram' // data-facultyid='" + _facultyIdDb + "' data-facultycode='" + _facultyCode + "' data-facultynameth='" + _facultyNameTh + @"'
                // class='btnGetListRptStdCompleteActGroupStudent'>
                // <tr style='cursor:pointer;' class='btnGetListRptStdCompleteActGroupStudent'  data-acayear='" + _acaYear + "' data-facultyid='" + _facultyIdDb + @"' data-programid='' 
                _string.Append(@"<tr style='cursor:pointer;'  onclick=getListRptStdCompleteActGroupStudent('"+ _acaYear + "','"+ _facultyIdDb + @"');  >
                                       <td class='text-center'>
                                            <font color='#025ebc'><span >" + _facultyCode + @"</span></font>
                                       </td>
                                       <td class='text-left'>
                                            " + _facultyNameTh + @"
                                       </td>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdAll + @"</span></font> 
                                       </td>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdPass + @"</span></font>
                                       </td>
                                       <th class='text-right'>
                                            <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentPass + @"</span></font>
                                       </th>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdNotPass + @"</span></font>
                                       </td>
                                       <th class='text-right'>
                                            <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentNotPass + @"</span></font>
                                       </th>
                                 </tr>");



            }

        }
        else
        {
            _string.Append(@"<tr bgcolor='#f7f8f9' align='center'>
                              <td  colspan='2'>ไม่พบข้อมูล</td></tr> ");
        }

        _string.Append("</table>");

        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-10
    /// Perpose: 
    /// Method : rptStudentCompleteActivityGroupProgram
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptStudentCompleteActivityGroupProgram(string _facultyId, string _acaYear, string _facultyCode, string _facultyNameTh)
    {
        DataSet _ds = ActDB.rptStudentCompleteActivityGroupProgram(_facultyId, _acaYear);

        int _count = _ds.Tables[0].Rows.Count;
        string _facultyIdDb = "";
        string _programId = "", _programCode = "", _majorCode = "", _groupnum="", _programNameTh = "";
        string _countStdPass = "", _countStdNotPass = "";
        string _countStdAll = "", _percentPass = "", _percentNotPass = "";
        StringBuilder _string = new StringBuilder();
        _string.Append(@"
                         <h4 >คณะ " + _facultyNameTh + @"</h4>
                         <table class='table tblRptGroupProgramKPI table-bordered table-hover'>
                            <thead>
                            <tr class='bg-info' >
                                <th rowspan='2' class='col-sm-1 text-center'>
                                    รหัสหลักสูตร
                                </th>
                                <th rowspan='2' class='col-sm-4 text-center'>
                                    ชื่อหลักสูตร
                                </th>
                                <th rowspan='2' class='col-sm-3 text-center'>
                                    จำนวนนักศึกษาทั้งหมด(คน)
                                </th>
                                <th colspan='2' class='col-sm-2 text-center'>
                                    นักศึกษาที่ผ่านเกณฑ์
                                </th>
                                <th colspan='2' class='col-sm-2 text-center'>
                                    นักศึกษาที่ไม่ผ่านเกณฑ์
                                </th>
                                </tr>
                                <tr class='bg-info'>
                                    <th class='text-center'>
                                        คน
                                    </th>
                                    <th class='text-center' >
                                        <font color='#2c2e6a' >%</font>
                                    </th>
                                    <th class='text-center'>
                                        คน
                                    </th>
                                    <th class='text-center' >
                                        <font color='#2c2e6a' >%</font>
                                    </th>
                                </tr>
                    </thead>");
        if (_count > 0)
        {


            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _facultyIdDb = _dr["facultyId"].ToString();
                _programId = _dr["programId"].ToString();
                _programCode = _dr["programCode"].ToString();
                _majorCode = _dr["majorCode"].ToString();
                _groupnum = _dr["groupnum"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _percentPass = _dr["percentPass"].ToString();
                _percentNotPass = _dr["percentNotPass"].ToString();
                _countStdAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdAll"]));
                _countStdPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdPass"]));
                _countStdNotPass = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countStdNotPass"]));

                _string.Append(@"<tr style='cursor:pointer;'  onclick=getListRptStdCompleteActGroupStudent('" + _acaYear + "','" + _facultyIdDb + @"');  >
                                       <td class='text-center'>
                                            <font color='#025ebc'><span >" + _programCode+ _programCode+ _groupnum + @"</span></font>
                                       </td>
                                       <td class='text-left'>
                                            " + _programNameTh + @"
                                       </td>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdAll + @"</span></font> 
                                       </td>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdPass + @"</span></font>
                                       </td>
                                       <th class='text-right'>
                                            <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentPass + @"</span></font>
                                       </th>
                                       <td class='text-right'>
                                            <font color='#025ebc'  ><span    > " + _countStdNotPass + @"</span></font>
                                       </td>
                                       <th class='text-right'>
                                            <font color='#2c2e6a' ><span style='font:blue;'   >" + _percentNotPass + @"</span></font>
                                       </th>
                                 </tr>");

                //_string.Append(@"<tr bgcolor='#f7f8f9'>
                //                       <td class='text-center'>
                //                            <font color='#025ebc'><a href='#' data-acayear='" + _acaYear + "' data-facultyid='" + _facultyId + "' data-programid='" + _programId + @"'   class='btnGetListRptStdCompleteActGroupStudent'>" + _programCode + _majorCode + _groupnum + @"</a></font>
                //                       </td>
                //                       <td class='text-left'>
                //                            " + _programNameTh + @"
                //                       </td>
                //                       <td class='text-right'>
                //                           <font color='#025ebc'><a  href='#' data-acayear='" + _acaYear + "' data-facultyid='" + _facultyId + "' data-programid='" + _programId + @"'   class='btnGetListRptStdCompleteActGroupStudent'>" + _stdNum + @"</a></font> คน
                //                       </td>
                //                 </tr>");



            }

        }
        else
        {
            _string.Append(@"<tr bgcolor='#f7f8f9' align='center'>
                              <td  colspan='3'>ไม่พบข้อมูล</td></tr> ");
        }

        _string.Append(" </table>");
        _string.Append(@" <div class='row'>
                          <div class='form-group col-xs-12 text-center'>
                           <button type='button' class='btn btn-warning glyphicon glyphicon-step-backward btnBack'> ย้อนกลับ</button>
                           </div></div> ");

        return _string.ToString();

    }



     /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-10
    /// Perpose: 
    /// Method : rptStudentCompleteActivityGroupStudent
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptStudentCompleteActivityGroupStudent(string _facultyId,string _acaYear)
    {
        DataSet _ds = ActDB.rptStudentCompleteActivityGroupStudent(_facultyId, _acaYear);
        StringBuilder _string = new StringBuilder();
        string _headColumn = "";
        string _bodyHtml = "";
        string _studentCode = "";
        string _fullNameTh = "";
        string _facultyNameTh = "";
        string _facultyCode= "";
        string _progNameTh = "";
        string _stsPass = "", _iconStatusPass = "", _stsPassTh = "", _stsPassEn = "";
        string _countAct = "";
        string _countHour = "";
        string _studentId = "";
        //string _typeIndicator = "";
        //string _hoursA1 = "";
        //string _hoursA2 = "";
        //string _hoursA3 = "";
        //string _hoursA4 = "";
        //string _hoursM = "";
        //string _hoursA = "";
        //string _hoursH = "";
        //string _hoursI = "";
        //string _hoursD = "";
        //string _hoursO = "";
        //string _hoursL = "";
        //string _studentCode = "";
        //string _firstName = "";
        //string _lastName = "";
        //string _facultyNameTh = "";
        //string _type1 = "";
        //string _type1sum = "";
        //string _type2 = "";
        //string _type2sum = "";
        //string _typeOther = "";
        //string _typeOthersum = "";
        // int _i = 1;
        _headColumn = "<h4 class='page-header' >รายการนักศึกษา</h4>";
        _headColumn += @"<table class='table tblTransStudentCreterion table-bordered table-hover'>
                            <thead>
                            <tr class='bg-info' >
                                <th class='text-center' style='width:80px;'>
                                    รหัสนักศึกษา
                                </th>
                                <th class='text-center' style='width:160px;'>
                                    ชื่อ-สกุล
                                </th>
                                <th class='text-center' style='width:190px;'>
                                    ชื่อคณะ
                                </th>
                                <th class='text-center' style='width:190px;'>
                                    ชื่อหลักสูตร
                                </th>
                                <th class='text-center'>
                                    จำนวนกิจกรรม
                                </th>
                                <th class='text-center'>
                                    จำนวนชั่วโมง
                                </th>
                                <th class='text-center'>
                                    สถานะผ่านเกณฑ์
                                </th>
                                </tr></thead>";
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _studentId = _dr["studentId"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _fullNameTh = _dr["fullNameTh"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _progNameTh = _dr["progNameTh"].ToString();
                _stsPassTh = _dr["stsPassTh"].ToString();
                _stsPass = _dr["stsPass"].ToString();
                _stsPassEn = _dr["stsPassEn"].ToString();
                if (_stsPass == "1")
                {
                    _iconStatusPass = "<i style='color:green;' class='glyphicon glyphicon-ok'></i>";
                }
                else
                {
                    _iconStatusPass = "<i style='color:red;' class='glyphicon glyphicon-remove'></i>";
                }

                _countAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countAct"]));
                _countHour = String.Format("{0:#,##0.##}", Convert.ToDouble(_dr["countHour"]));
                _bodyHtml += @"<tr style='cursor:pointer;' onclick=popUpActivityByStudentId('" + _studentId + "','"+ _studentCode + @"');>
                                       <td class='text-center'>
                                            <font color='#025ebc'><span >" + _studentCode + @"</span></font>
                                       </td>
                                       <td class='text-left'>
                                            " + _fullNameTh + @"
                                       </td>
                                       <td class='text-left'>
                                            "+_facultyCode+" - " + _facultyNameTh + @"
                                       </td>
                                       <td class='text-left'>
                                            " + _progNameTh + @"
                                       </td>
                                       <th class='text-right'>
                                             <font color='#2c2e6a' >" + _countAct + @"</font>
                                       </th>
                                       <th class='text-right'>
                                             <font color='#2c2e6a' >" + _countHour + @"</font>
                                       </th>
                                       <td class='text-center'>
                                            " + _iconStatusPass +" "+ _stsPassTh + @"
                                       </td>
                                 </tr>";

                //_typeIndicator = _dr["typeIndicator"].ToString();
                //_studentCode = _dr["studentCode"].ToString();
                //_firstName = _dr["firstName"].ToString();
                //_lastName = _dr["lastName"].ToString();
                //_facultyNameTh = _dr["facultyNameTh"].ToString();
                //_type1 = _dr["type1"].ToString();
                //_type1sum = _dr["type1sum"].ToString();
                //_type2 = _dr["type2"].ToString();
                //_type2sum = _dr["type2sum"].ToString();
                //_typeOther = _dr["typeOther"].ToString();
                //_typeOthersum = _dr["typeOthersum"].ToString();


                //if (Convert.ToInt32(_acaYear) < 2560)
                //{ 
                //    _hoursA1 = _dr["A.1"].ToString();
                //    _hoursA2 = _dr["A.2"].ToString();
                //    _hoursA3 = _dr["A.3"].ToString();
                //    _hoursA4 = _dr["A.4"].ToString();

                //    _bodyHtml += @" 
                //             <tr bgcolor='#f7f8f9'>
                //                <td >
                //                   " + _i.ToString() + @"
                //                </td>
                //                <td >
                //                   "+_studentCode+@" 
                //                </td>
                //                <td   >
                //                    " + _firstName + @"
                //                </td>
                //                <td  >
                //                   " + _lastName + @"
                //                </td>
                //                <td  >
                //                    " + _facultyNameTh + @"
                //                </td>
                //                <td  >"+_type1+@"</td>
                //                <td  >"+_type1sum+@"</td>
                //                <td  >" + _type2 + @"</td>
                //                <td  >
                //                     " + _hoursA1 + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursA2 + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursA3 + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursA4 + @"
                //                </td>   
                //                <td  >"+ _type2sum +@"</td>
                //                <td  >" + _typeOther + @"</td>
                //                <td  >" + _typeOthersum + @"</td>
                //            </tr> ";
                //}
                //else if((Convert.ToInt32(_acaYear)>=2560) && (Convert.ToInt32(_acaYear) <= 2561))
                //{
                //    _hoursM = _dr["M"].ToString();
                //    _hoursA = _dr["A"].ToString();
                //    _hoursH = _dr["H"].ToString();
                //    _hoursI = _dr["I"].ToString();
                //    _hoursD = _dr["D"].ToString();
                //    _hoursO = _dr["O"].ToString();
                //    _hoursL = _dr["L"].ToString();
                //    _bodyHtml += @" 
                //             <tr bgcolor='#f7f8f9'>
                //                <td >
                //                   " + _i.ToString() + @"
                //                </td>
                //                <td >
                //                   " + _studentCode + @" 
                //                </td>
                //                <td   >
                //                    " + _firstName + @"
                //                </td>
                //                <td  >
                //                   " + _lastName + @"
                //                </td>
                //                <td  >
                //                    " + _facultyNameTh + @"
                //                </td>
                //                <td  >" + _type1 + @"</td>
                //                <td  >" + _type1sum + @"</td>
                //                <td  >" + _type2 + @"</td>
                //                <td  >
                //                     " + _hoursM + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursA + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursH + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursI + @"
                //                </td>  
                //                <td  >
                //                     " + _hoursD + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursO + @"
                //                </td>   
                //                <td  >
                //                     " + _hoursL + @"
                //                </td>    
                //                <td  >" + _type2sum + @"</td>
                //                <td  >" + _typeOther + @"</td>
                //                <td  >" + _typeOthersum + @"</td>
                //            </tr> ";
            }

            //_i++;


        }
        _bodyHtml += "</table>";
        _bodyHtml += @" <div class='row '>
                                <div class=' col-xs-12 text-center'>
                                     <button type='button' data-acayear='"+ _acaYear + "' data-facultyid='"+_facultyId +@"' class='btn btn-success btn-md btnTransStudentCreterionExcel glyphicon glyphicon-file'>Excel</button>
                                </div>
                        </div></br>";

        //_headColumn += columnIndicatorForSummaryGroupStudent(_typeIndicator);

        _bodyHtml += "<div id='divTransActStd' class='modal fade' role='dialog'>";
        _bodyHtml += "<div class='modal-dialog modal-lg'>";
        _bodyHtml += "<div class='modal-content'>";
        _bodyHtml += @"<div class='modal-header'>
                          <button type='button' class='close' data-dismiss='modal'>&times;</button>
                          <h4 class='modal-title'>ข้อมูลการเข้าร่วมกิจกรรมของนักศึกษา</h4>
                        </div>";

        _bodyHtml += @"<div class='modal-body'>
                         <p><span id='spnDataDetailTransAct'></span></p></div>  
                  </div></div></div> ";
        _string.Append(  _headColumn + _bodyHtml);

        return _string.ToString();

    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-11
    /// Perpose: 
    /// Method : columnIndicatorForSummaryGroupStudent
    /// Sample : N/A
    /// </summary>
    /// 
    public static string columnIndicatorForSummaryGroupStudent(string _typeIndicator)
    {
        StringBuilder _string = new StringBuilder();

        if (_typeIndicator == "0")
        {
            _string.Append(@" 
                           
                            <table id='tblRptStdList' class='table'>
                            
                            <thead>
                            <tr bgcolor='#efefef'>
                                <th  class='col-sm-1'>
                                    ลำดับ
                                </th>
                                <th   class='col-sm-1'>
                                    รหัสนักศึกษา
                                </th>
                                <th   class='col-sm-2'>
                                    ชื่อ
                                </th>
                                <th   class='col-sm-2'>
                                    นามสกุล
                                </th>
                                <th  class='col-sm-3'>
                                    คณะ/วิทยาลัย
                                </th>
                                <th  title='จำนวนกิจกรรมบังคับของมหาวิทยาลัย' >
                                    type1
                                </th>
                                <th  title='จำนวนชั่วโมงของกิจกรรมบังคับ' >
                                    type1sum
                                </th>
                                <th title='จำนวนกิจกรรมเลือกเสรี'  >
                                    type2
                                </th>
                                <th   >
                                    A1
                                </th>
                                <th  >
                                    A2
                                </th>  
                                <th  >
                                    A3
                                </th>     
                                <th  >
                                    A4
                                </th> 
                                <th title='จำนวนชั่วโมงของกิจกรรมเลือกเสรี'>
                                    type2sum
                                </th>  
                                <th  >
                                    typeOther
                                </th>  
                                <th  >
                                    typeOthersum
                                </th>  
                            </tr>
                            </thead>
                            ");
        }
        else
        {
            _string.Append(@"<table class='table'>
                            
                            <thead>
                            <tr bgcolor='#efefef'>
                                <th  class='col-sm-1'>
                                    ลำดับ
                                </th>
                                <th   class='col-sm-1'>
                                    รหัสนักศึกษา
                                </th>
                                <th   class='col-sm-2'>
                                    ชื่อ
                                </th>
                                <th   class='col-sm-2'>
                                    นามสกุล
                                </th>
                                <th  class='col-sm-3'>
                                    คณะ/วิทยาลัย
                                </th>
                                <th   >
                                    type1
                                </th>
                                <th   >
                                    type1sum
                                </th>
                                <th   >
                                    type2
                                </th>
                                <th   >
                                    M
                                </th>
                                <th  >
                                    A
                                </th>  
                                <th  >
                                    H
                                </th>     
                                <th  >
                                    I
                                </th>    
                                <th  >
                                    D
                                </th>
                                <th  >
                                    O
                                </th>  
                                <th  >
                                    L
                                </th>  
                                <th  >
                                    type2sum
                                </th>  
                               <th  >
                                    typeOther
                                </th>  
                                <th  >
                                    typeOthersum
                                </th>  

                            </tr>
                            </thead> ");
        }

        return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-15
    /// Perpose: แสดงรายการข้อมูล
    /// Method : getListTypeCompleteAct
    /// Sample : N/A
    /// </summary>
    public static string getListTypeCompleteAct()
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListTypeCompleteAct();
        string _selectIndex = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            _string.Append(@" 
                                 <select class='form-control ddlTypeComlpeteAct'       >
                                   <option value=''>ทั้งหมด</option>");
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _string.Append(@"<option value='" + _dr["id"] + "' " + _selectIndex + "  >" + _dr["typeCompleteActTh"] + "</option>");

            }

            _string.Append(@"</select>");
        }
        return _string.ToString();
    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-02-07
    /// Perpose: 
    /// Method : getListDivRptStatisticFac
    /// Sample : N/A
    /// </summary>
    /// 
    public static string getListDivRptStatisticFac(string _facultyId)
    {
        DataSet _ds = ActDB.rptStatisticGroupAcaYear(_facultyId);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<table class='table table-bordered'>
                    <tr bgcolor='#efefef'>
                        <th rowspan='3' class='text-center'>
                            ปีการศึกษา
                        </th>
                        <th colspan='2'  class='text-center'>
                            กำหนดให้เข้าร่วม</br>และเลือกเข้าร่วม
                        </th>
                        <th colspan='10'  class='text-center'>
                            เลือกเสรี
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนกิจกรรม</br>(รวม)
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนชั่วโมง</br>กิจกรรมรวม
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนนักศึกษา</br>เข้าร่วมกิจกรรม</br>(ครั้ง)
                        </th>
                        <th rowspan='3'  class='text-center'>
                            งบประมาณ
                        </th>
                    </tr>

                    <tr bgcolor='#efefef'>
                    <th rowspan='2' class='text-center'>
                    โครงการ
                    </th>
                    <th rowspan='2' class='text-center'>
                    ชั่วโมง
                    </th>
                    <th rowspan='2' class='text-center'>
                    โครงการ
                    </th>
                    <th colspan='5' class='text-center'>
                    จำนวนชั่วโมง
                    </th>
                    <th colspan='4' class='text-center'>
                    จำนวนโครงการที่สอดคล้องในแต่ละด้าน
                    </th>
                    </tr>

                    <tr bgcolor='#efefef'>
                    <th class='text-center'>
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
                    </th>
                    <th class='text-center'>
                    รวม
                    </th>

                    <th class='text-center'>
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
                    </th>
                    </tr>
        ");

        string _acaYearTran = "";
        string _countActType1 = "";
        string _sumHoursType1 = "";
        string _countActType2 = "";
        string _A1 = "";
        string _A2 = "";
        string _A3 = "";
        string _A4 = "";
        string _sumHoursType2 = "";
        string _countActMatchA1 = "";
        string _countActMatchA2 = "";
        string _countActMatchA3 = "";
        string _countActMatchA4 = "";
        string _countActTypeAll = "";
        string _sumHoursTypeAll = "";
        string _countNumStdAct = "";
        string _sumBudget = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _acaYearTran = _dr["acaYear"].ToString();
                _countActType1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActType1"]));
                _sumHoursType1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursType1"]));
                _countActType2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActType2"]));
                _A1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A.1"]));
                _A2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A.2"]));
                _A3 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A.3"]));
                _A4 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A.4"]));
                _sumHoursType2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursType2"]));
                _countActMatchA1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchA.1"]));
                _countActMatchA2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchA.2"]));
                _countActMatchA3 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchA.3"]));
                _countActMatchA4 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchA.4"]));
                _countActTypeAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActTypeAll"]));
                _sumHoursTypeAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursTypeAll"]));
                _countNumStdAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countNumStdAct"]));
                _sumBudget = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumBudget"]));



                _string.Append(@"
                 <tr bgcolor='#f7f8f9'>
                        <td class='text-center'>
                            <font color='#025ebc'><a href='#' data-acayear='" + _acaYearTran + "' class='btnRptProjectBudget'>" + _acaYearTran + @"</a></font>
                        </td>
                        <td class='text-right'>
                            " + _countActType1 + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursType1 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActType2 + @"
                        </td>
                        <td class='text-right'>
                            " + _A1 + @"
                        </td>
                        <td class='text-right'>
                            " + _A2 + @"
                        </td>
                        <td class='text-right'>
                            " + _A3 + @"
                        </td>
                        <td class='text-right'>
                            " + _A4 + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursType2 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchA1 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchA2 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchA3 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchA4 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActTypeAll + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursTypeAll + @"
                        </td>
                        <td class='text-right'>
                            " + _countNumStdAct + @"
                        </td>
                        <td class='text-right'>
                            " + _sumBudget + @"
                        </td>
           
                </tr>
                                        ");




            }

        }
        else
        {

        }

        _string.Append("  </table>");
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-08-22
    /// Perpose: 
    /// Method : getListRptStatisticFac
    /// Sample : N/A
    /// </summary>
    /// 
    public static string getListRptStatisticFac(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append("  <h2 class='page-header'>รายงานสถิติส่วนงาน</h2>");

        // <h3 >" + _facultyCode + " - " + _facultyNameTh + @"</h3>
        _string.Append(ActUI.getListYearFillterReport());
        _string.Append(ActUI.getListFaculty(_facultyId, _facultyId));
        _string.Append("</br>");
        _string.Append("<div id='divRptStatistic'>");
        //+ getListDivRptStatisticFacMAHIDOL(_facultyId)
        //+ getListDivRptStatisticFac(_facultyId) +
        if (_facultyId == "MU-01")
        {

        }
        else
        {
            _string.Append(getListRptStatisticDepartment(_facultyId, "GIR-003","",""));
            _string.Append(getListRptStatisticDepartment(_facultyId, "GIR-002","",""));
            _string.Append(getListRptStatisticDepartment(_facultyId, "GIR-001","",""));
        }
        _string.Append("</div>");
        _string.Append("<div id='divRptProjectBudget'></div>");
        return _string.ToString();

    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-09-20
    /// Perpose: 
    /// Method : rptProjectBudget
    /// Sample : N/A
    /// </summary>
    /// 
    public static string rptProjectBudgetByAcaYear(string _acaYear,string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.rptProjectBudgetByAcaYear(_acaYear, _facultyId);
        string _htmlHeader = "";
        string _htmlBody = "";
        int _i = 0;
        string _projectNameTh = "", _instituteNameTh = "", _budget = "", _paid = "", _sumBudgetAll="";
        if (_ds.Tables[0].Rows.Count > 0)
        {
   
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _projectNameTh = _dr["projectNameTh"].ToString();
                _instituteNameTh = _dr["instituteNameTh"].ToString();
                _budget = _dr["budget"].ToString();
                _paid = _dr["paid"].ToString();
                _sumBudgetAll = _dr["sumBudgetAll"].ToString();
                _budget = String.Format("{0:#,##0}", Convert.ToDouble(_budget));
                _paid = String.Format("{0:#,##0}", Convert.ToDouble(_paid));
                _sumBudgetAll = String.Format("{0:#,##0}", Convert.ToDouble(_sumBudgetAll));
                _htmlBody +=@"
                           <tr >
                                <td class='text-center col-sm-1'>
                                    " + (_i+1).ToString() + @"
                                </td>
                                <td class='text-left col-sm-4'>
                                    " + _projectNameTh + @"
                                </td>
                                <td class='text-left col-sm-3'>
                                    "+_instituteNameTh+@"
                                </td>
                                <td class='text-center col-sm-2'>
                                    "+_budget+@"
                                </td>
                                <td class='text-center col-sm-2'>
                                    " + _paid + @"
                                </td>
                            </tr>                                ";

                _i++;
            }

           _htmlBody+=" </table>  ";

        }
        else
        {
           _htmlHeader +=@"   <tr bgcolor='#f7f8f9' align='center'>
                               <td  colspan='5'>ไม่พบข้อมูล</td></tr> ";
        }

        _htmlHeader = @"
               <h3 >กิจกรรมของปีการศึกษา " + _acaYear + " งบประมาณ " + _sumBudgetAll + @" บาท</h3>
               <table id='tblProjectBudgetSummary' class='table table-bordered'>
                    <thead>
                    <tr bgcolor='#efefef'>
                        <th class='text-center col-sm-1'>
                            ลำดับ
                        </th>
                        <th class='text-center col-sm-5'>
                            ชื่อโครงการ
                        </th>
                        <th class='text-center col-sm-3'>
                            หน่วยงานที่จัด
                        </th>
                        <th class='text-center col-sm-2'>
                            งบประมาณขออนุมัติ
                        </th>
                        <th class='text-center col-sm-2'>
                            งบประมาณใช้จริง
                        </th>
                    </tr></thead>";

        _string.Append(_htmlHeader + _htmlBody);

        return _string.ToString();

    }

    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-04-19
    /// Perpose: แสดงรายการข้อมูลโครงการทั้งหมด
    /// Method : pagePrintActivityTranscript
    /// Sample : N/A
    /// </summary>
    public static string pagePrintActivityTranscript(string _facultyId,string _ddlFacultyId, string _programId
        , string _studentYear, string _studentCode, string _statusRequest)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div >");
        _string.Append(@"  <h2 class='page-header'>
                               พิมพ์ Activity Transcript</h2>");


        _string.Append(@"  </br>  

                                <div class='row '>
                                     <div class='form-group col-xs-2 '>
                                           " + ActUI.getListStudentYear() + @"
                                     </div>
                                     <div class='form-group col-xs-3 '>
                                           " + ActUI.getListFaculty(_facultyId, "") + @"
                                     </div>
                                     <div class='form-group col-xs-3'>
                                            <div class='divProgram'>
                                            " + ActUI.getListProgram(_facultyId) + @"
                                            </div>
                                     </div>
                                       <div class='form-group col-xs-2'>
                                            <div class='divRequestDoc'>
                                            " + ActUI.getListStatusRequestDoc() + @"
                                            </div>
                                     </div>
                                     <div class='form-group col-xs-2 '>
                                           <b>รหัสนักศึกษา</b>
                                           <input type='number' maxlength='7' class='form-control txtStudentCode' />
                                     </div>
                                
                              </div>");
        _string.Append(@"<div class='row'>
                        <div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-info btn-md btnSearchPrintAT glyphicon glyphicon-search'> ค้นหา</button>
                            <button type='button' class='btn btn-success btn-md btnExportPrintAT glyphicon glyphicon-file' > Excel</button>
                        </div></div>");
        // data-statusrequest='" + _statusRequest + "'  data-studentcode='" + _studentCode + "'  data-programid='" + _programId + "' data-studentyear='" + _studentYear + "' data-facultyid='"+ _ddlFacultyId + @"'
        _string.Append("</div><div class='divSearchDetail'></div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-04-19
    /// Perpose: 
    /// Method : getListATForPrint
    /// Sample : N/A
    /// </summary>
    public static string getListATForPrint(string _studentYear, string _facultyId, string _programId, string _studentCode,string _statusRequest)
    {
        DataSet _ds = ActDB.getListATForPrint(_studentYear,_facultyId, _programId, _studentCode, _statusRequest);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();

        _string.Append("<button type='button' class='btn btn-default glyphicon glyphicon-print btnPrintAT'> ภาษาไทย</button>&nbsp;");
        _string.Append("<button type='button' class='btn btn-default glyphicon glyphicon-print btnPrintATEng'> ภาษาอังกฤษ</button></br>");
        _string.Append(@" <div class='table-responsive' > 
                    <table class='table' id='tblStudentAT'>
                    <thead>
                    <tr>
                    <th class='col-sm-1'>
                    <div class='checkbox' style='cursor:pointer;'>
                             <label><input type='checkbox' class='btnChkAll' ></label>
                    </div>
                    </th>
                    <th class='col-sm-1'>
                    ลำดับ
                    </th>
                    <th class='col-sm-2'>
                    รหัสนักศึกษา
                    </th>
                    <th class='col-sm-2'>
                    ชื่อ-นามสกุล
                    </th>
                    <th class='col-sm-3'>
                    คณะ
                    </th>
                    <th class='col-sm-3'>
                    หลักสูตร
                    </th>
                    </tr>
                    </thead> ");

        _string.Append("<tbody> ");
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"    <tr style='height:25px;'>
                                        <td scope='row'>
                                            <div class='checkbox' style='cursor:pointer;'>
                                                <label><input type='checkbox' class='chkStudentPrintAT' data-studentcode='"+_dr["studentCode"]+"' ></label>"+@"
                                            </div>
                                        </td>
                                        <td >
                                         " + _i.ToString() + @"
                                        </td>
                                        <td >
                                         " + _dr["studentCode"] + @"
                                        </td>
                                        <td >
                                         " + _dr["firstName"] + " " + _dr["lastName"] + @"
                                        </td>
                                        <td >
                                         " + _dr["facultyCode"] + " - " + _dr["facultyNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["programNameTh"] + @"
                                        </td>
                                        </tr>
                                        ");
                _i++;
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
        _string.Append("</tbody></table></div>");
        return _string.ToString();
    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-09
    /// Perpose: 
    /// Method : pagePrintSpiderGraph
    /// Sample : N/A
    /// </summary>
    public static string pagePrintSpiderGraph(string _facultyId)
    {

        StringBuilder _string = new StringBuilder();
        _string.Append(@"<div >
                                <div class='row '>

                                     <div class='form-group col-xs-4 '>
                                           <b>รหัสนักศึกษา</b>
                                           <input type='number' maxlength='7' class='form-control txtStudentCode' />
                                     </div>
                                     <div class='form-group col-xs-4 '>
                                           <b>ชื่อ</b>
                                           <input type='text'  class='form-control txtFirstName' />
                                     </div>
                                     <div class='form-group col-xs-4 '>
                                           <b>นามสกุล</b>
                                           <input type='text' class='form-control txtLastName' />
                                     </div>
                                </div>

                                <div class='row '>
                                     <div class='form-group col-xs-6 '>
                                           " + ActUI.getListFaculty(_facultyId, "") + @"
                                     </div>
                                     <div class='form-group col-xs-6'>
                                            <div class='divProgram'>
                                            " + ActUI.getListProgram(_facultyId) + @"
                                            </div>
                                     </div>
                               </div>


                              </div>");
        _string.Append(@"<div class='row'>
                        <div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-info btn-md btnSearchPrintSpiderGraph glyphicon glyphicon-search'> ค้นหา</button>
                        </div></div>");

        _string.Append("</div><div class='divSearchDetail'></div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-09
    /// Perpose: 
    /// Method : pagePrintSpiderGraphFacultyLevel
    /// Sample : N/A
    /// </summary>
    public static string pagePrintSpiderGraphFacultyLevel(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append(@"  </br>  
       
                                <div class='row '>

                                     <div class='form-group col-xs-2 '>
                                           " + ActUI.getListAcaYear("00","") + @"
                                     </div>

                                     <div class='form-group col-xs-2 '>
                                           " + ActUI.getListSemester("00") + @"
                                     </div>

                                     <div class='form-group col-xs-4 '>
                                           " + ActUI.getListFaculty(_facultyId, "") + @"
                                     </div>
                                     <div class='form-group col-xs-4'>
                                            <div class='divProgram'>
                                            " + ActUI.getListProgram(_facultyId) + @"
                                            </div>
                                     </div>
                               </div>


                              </div>");
        _string.Append(@"<div class='row'>
                        <div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-info btn-md btnSearchStdListFacultyLevel glyphicon glyphicon-search'> ค้นหา</button>
                        </div></div>");

        _string.Append("</div><div class='divDetailFacultyLevel'></div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-09
    /// Perpose: 
    /// Method : getListStudentForSpiderGraph
    /// Sample : N/A
    /// </summary>
    public static string getListStudentForSpiderGraph(string _facultyId,string _programId,string _studentCode,string _firstName,string _lastName)
    {
        DataSet _ds = ActDB.getListStudentForSpiderGraph(_facultyId, _programId, _studentCode, _firstName, _lastName);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();
        string _dataSend = "";
        _string.Append(@" <div class='table-responsive ' > 
                    <table class='table table-hover' id='tblStudentListGraph'>
                    <thead>
                    <tr>
                    <th class='col-sm-1'>
                    ลำดับ
                    </th>
                    <th class='col-sm-1'>
                    รหัสนักศึกษา
                    </th>
                    <th class='col-sm-2'>
                    ชื่อ-นามสกุล
                    </th>
                    <th class='col-sm-3'>
                    คณะ
                    </th>
                    <th class='col-sm-3'>
                    หลักสูตร
                    </th>   
                    <th class='col-sm-1'>
                    จำนวนกิจกรรม
                    </th> 
                    <th class='col-sm-1'>
                    จำนวนชั่วโมง
                    </th>
      
                    </tr>
                    </thead> ");

        _string.Append("<tbody> ");
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                // data-toggle='modal'
                _dataSend = " data-target='#divSpiderGraph' onclick=checkCoditionForSpiderGraph('" + _dr["studentId"] + "','" + _dr["studentCode"] + "','" + _dr["facultyId"] + "','" + _dr["programId"] + "','" + _dr["countProject"] + "','" + _dr["sumHour"] + "'); ";
                //_dataSend = "    data-facultyid='" + _dr["facultyId"] + "' data-programid='" + _dr["programid"] + "'   data-studentid='" + _dr["studentId"] + "' data-studentcode='" + _dr["studentCode"] + "' ";
                _string.Append(@"    <tr style='height:25px;cursor:pointer;' class='btnReportStudentSpider' " + _dataSend + @"' >
                                        <td scope='row'>
                                         " + _i.ToString() + @"
                                        </td>
                                        <td >
                                         " + _dr["studentCode"] + @"
                                        </td>
                                        <td >
                                         " + _dr["thTitleFullName"] + _dr["firstName"] + " " + _dr["lastName"] + @"
                                        </td>
                                        <td >
                                         " + _dr["facultyCode"] + " - " + _dr["facultyNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["programNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["countProject"] + @"
                                        </td>
                                        <td >
                                         " + _dr["sumHour"] + @"
                                        </td>

                                        </tr>
                                        ");
                _i++;
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
        _string.Append("</tbody></table></div>");
        _string.Append("<div id='divSpiderGraph' class='modal fade' role='dialog'>");
        _string.Append("<div class='modal-dialog'>");
        _string.Append("<div class='modal-content'>");
        _string.Append(@"<div class='modal-header'>
                          <button type='button' class='close' data-dismiss='modal'>&times;</button>
                          <h4 class='modal-title'>รายงานรายบุคคล</h4>
                        </div>");
        _string.Append(@"<div class='modal-body'>
                         <p>");


        _string.Append(@"<ul class='nav nav-tabs'>
                          
                          <li class='active'><a data-toggle='tab' href='#divTab0'>Mahidol HIDEF</a></li>
                          <li><a data-toggle='tab' href='#divTab1'>Mahidol Core values</a></li>
                          <li><a data-toggle='tab' href='#divTab4'>A1 - A4</a></li>
                          <li><a data-toggle='tab' href='#divTab2'>21st Century Skill Outcomes</a></li>
                          <li><a data-toggle='tab' href='#divTab3'>TQF มาตรฐานการเรียนรู้ 5 ด้าน</a></li>
                        </ul>");

        _string.Append("<div class='tab-content'>");

        _string.Append("<div id='divTab0' class='tab-pane fade in active'>");
        _string.Append("<p>");
        _string.Append("<div id='divProfileStudent'></div>");
        _string.Append("<div id='container00' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue00'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTab1' class='tab-pane fade '>");
        _string.Append("<p>");
        _string.Append("<div id='divProfileStudent'></div>");
        _string.Append("<div id='container01' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue01'></div>");
        _string.Append("</p>");
        _string.Append("</div>");




        _string.Append("<div id='divTab4' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divProfileStudent'></div>");
        _string.Append("<div id='container04' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue04'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTab2' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divProfileStudent02'></div>");
        _string.Append("<div id='container02' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue02'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTab3' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divProfileStudent03'></div>");
        _string.Append("<div id='container03' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue03'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("</div>");


        _string.Append(@"</p>
                         </div>");

        _string.Append("</div>");
        _string.Append("</div>");
        _string.Append("</div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-09
    /// Perpose: 
    /// Method : getListTypeGraph
    /// Sample : N/A
    /// </summary>
    public static string getListTypeGraph()
    {
         StringBuilder _string = new StringBuilder();
         _string.Append(@" <label for='ddlTypeGraph'>
                                 ประเภทกราฟข้อมูล</label>
                                 <select class='form-control ddlTypeGraph' >");
         _string.Append("<option value=''>กรุณาเลือก</option>");
         _string.Append("<option value='01'>Mahidol Core values</option>");
         _string.Append("<option value='04'>A1 - A4</option>");
        _string.Append("<option value='02'>21st Century Skill Outcomes</option>");
         _string.Append("<option value='03'>TQF มาตรฐานการเรียนรู้ 5 ด้าน</option>");
         _string.Append("</select>");

         return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2017-05-11
    /// Perpose: 
    /// Method : pageTabSpiderGraph
    /// Sample : N/A
    /// </summary>
    public static string pageTabSpiderGraph(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();

        // อันนี้สำหรับใช้กรณีปิดระบบ
        //_string.Append("<div>");
        //_string.Append("<h2 class='page-header'>รายงาน Spider graph</h2><br><center><h4 style='color:red;'>อยู่ในระหว่างการปรับปรุงระบบ</h4>");
        //_string.Append("</div>");
        // ปิดอันนี้

        // อันนี้สำหรับเวลาแก้เสร็จ
        _string.Append(@"<div >");
        _string.Append(@"  <h2 class='page-header'>
                               รายงาน Spider graph</h2>");
        _string.Append(@"<ul class='nav nav-tabs'>
                          <li class='active'><a data-toggle='tab' href='#divTabGraph1'><h4>ระดับมหาวิทยาลัย</h4></a></li>
                        </ul>");
        //_string.Append(@"<ul class='nav nav-tabs'>
        //                  <li class='active'><a data-toggle='tab' href='#divTabGraph1'><h4>ระดับมหาวิทยาลัย</h4></a></li>
        //                  <li><a data-toggle='tab' href='#divTabGraph2'><h4>ระดับคณะ</h4></a></li>
        //                  <li><a data-toggle='tab' href='#divTabGraph3'><h4>รายบุคคล</h4></a></li>
        //                </ul>");


        _string.Append("<div class='tab-content'>");

        _string.Append("<div id='divTabGraph1' class='tab-pane fade in active'>");
        _string.Append("</div>");

        //_string.Append("<div id='divTabGraph2' class='tab-pane fade'>");
        //_string.Append("</div>");

        //_string.Append("<div id='divTabGraph3' class='tab-pane fade'>");
        //_string.Append("</div>");

        _string.Append("</div>");

        _string.Append("</div>");
        // ปิดอันนี้

        return _string.ToString();
    }








    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-11
    /// Perpose: 
    /// Method : getListStudentForSpiderGraphFacultyLevel
    /// Sample : N/A
    /// </summary>
    public static string getListStudentForSpiderGraphFacultyLevel(string _acaYear, string _semester, string _facultyId, string _programId)
    {
        DataSet _ds = ActDB.getListStudentForSpiderGraphFacultyLevel(_acaYear, _semester, _facultyId, _programId,"","");
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();
        string _dataSend = "";
        _string.Append(@" <div class='table-responsive ' > 
                    <table class='table table-hover' id='tblStudentListGraph'>
                    <thead>
                    <tr>
                    <th class='col-sm-1'>
                    ลำดับ
                    </th>
                    <th class='col-sm-1'>
                    ปีการศึกษา
                    </th>
                    <th class='col-sm-1'>
                    ภาคการศึกษา
                    </th>  
                    <th class='col-sm-3'>
                    คณะที่จัดกิจกรรม
                    </th> 
                    <th class='col-sm-3'>
                    หลักสูตรที่จัดกิจกรรม
                    </th> 
                    <th class='col-sm-1'>
                    จำนวนนศ.ที่เข้าร่วม
                    </th> 
                    <th class='col-sm-1'>
                    จำนวชั่วโมง
                    </th> 
                    <th class='col-sm-1'>
                    จำนวกิจกรรม
                    </th> 
                    </tr>
                    </thead> ");

        _string.Append("<tbody> ");
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _dataSend = " data-target='#divSpiderGraphFacultyLevel' onclick=drillDownGraphFacultyLevel('" + _dr["acaYear"] + "','" + _dr["semester"] + "','" + _dr["facultyId"] + "','" + _dr["programId"] + "'); ";
                _string.Append(@"    <tr style='height:25px;cursor:pointer;' class='btnReportStudentSpider' " + _dataSend + @"' >
                                        <td scope='row'>
                                         " + _i.ToString() + @"
                                        </td>
                                        <td >
                                         " + _dr["acaYear"] + @"
                                        </td>
                                        <td >
                                         " + _dr["semester"]  + @"
                                        </td>
                                        <td >
                                         " + _dr["facultyCode"] + " - " + _dr["facultyNameTh"] + @"
                                        </td>
                                        <td >
                                         " + _dr["programNameTh"] + @"
                                        </td>
                                        <td align='right'>
                                         " + _dr["countStd"] + @"
                                        </td>
                                        <td align='right'>
                                         " + _dr["sumHour"] + @"
                                        </td>                                        
                                         <td align='right'>
                                         " + _dr["countProject"] + @"
                                        </td>
                                        </tr>
                                        ");
                _i++;
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
        _string.Append("</tbody></table></div>");

        _string.Append("<div id='divSpiderGraphFacultyLevel' class='modal fade' role='dialog'>");
        _string.Append("<div class='modal-dialog'>");
        _string.Append("<div class='modal-content'>");
        _string.Append(@"<div class='modal-header'>
                          <button type='button' class='close' data-dismiss='modal'>&times;</button>
                          <h4 class='modal-title'>รายงานระดับคณะ</h4>
                        </div>");
        _string.Append(@"<div class='modal-body'>
                         <p>");


        _string.Append(@"<ul class='nav nav-tabs'>
                          <li class='active'><a data-toggle='tab' href='#divTabFac0'>Mahidol HIDEF</a></li>
                          <li><a data-toggle='tab' href='#divTabFac1'>Mahidol Core values</a></li>
                          <li><a data-toggle='tab' href='#divTabFac4'>A1 - A4</a></li>
                          <li><a data-toggle='tab' href='#divTabFac2'>21st Century Skill Outcomes</a></li>
                          <li><a data-toggle='tab' href='#divTabFac3'>TQF มาตรฐานการเรียนรู้ 5 ด้าน</a></li>
                        </ul>");

        _string.Append("<div class='tab-content'>");
        _string.Append("<div id='divTabFac0' class='tab-pane fade in active'>");
        _string.Append("<p>");
        _string.Append("<div id='divFaculty00'></div>");
        _string.Append("<div id='divGraphFaculty00' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue00'></div>");
        _string.Append("</p>");
        _string.Append("</div>");


        _string.Append("<div id='divTabFac1' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divFaculty01'></div>");
        _string.Append("<div id='divGraphFaculty01' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue01'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTabFac4' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divFaculty04'></div>");
        _string.Append("<div id='divGraphFaculty04' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue04'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTabFac2' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divFaculty02'></div>");
        _string.Append("<div id='divGraphFaculty02' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue02'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTabFac3' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divFaculty03'></div>");
        _string.Append("<div id='divGraphFaculty03' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue03'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("</div>");


        _string.Append(@"</p>
                         </div>");

        _string.Append("</div>");
        _string.Append("</div>");
        _string.Append("</div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-11
    /// Perpose: 
    /// Method : getListHeaderGraphFacultyLevel
    /// Sample : N/A
    /// </summary>
    public static string getListHeaderGraphFacultyLevel(string _acaYear, string _semester, string _facultyId, string _programId, string _txtDisplayHeader,string _groupIndicatorId,string _groupCharacterId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudentForSpiderGraphFacultyLevel(_acaYear, _semester, _facultyId, _programId, _groupIndicatorId, _groupCharacterId);
        string _countStd = "";
        string _countProject = "";
        string _sumHour = "";
        string _facNameTh = "";
        string _programNameTh = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _countStd = _dr["countStd"].ToString();
                _countProject = _dr["countProject"].ToString();
                _sumHour = _dr["sumHour"].ToString();
                _facNameTh = _dr["facultyNameTh"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
            }

            _string.Append(@" <table class='table table-bordered' >
                    <caption class='text-center'><h3>" + _txtDisplayHeader + @"</h3></caption>
                     <tr >
                     <th bgcolor='#efefef' class='col-xs-2'>
                         ปีการศึกษา:
                     </th>
                     <td class='col-xs-4'>
                         " + _acaYear + @"
                     </td>
                     <th bgcolor='#efefef' class='col-xs-2'>
                         ภาคการศึกษา:
                     </th>
                     <td class='col-xs-4' colspan='3'>
                         " + _semester + @"
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
                     <td colspan='3'>
                         " + _programNameTh + @"
                     </td>
                     </tr>

                     <tr >
                     <th bgcolor='#efefef'>
                         จำนวนนักศึกษาที่เข้าร่วมกิจกรรม:
                     </th>
            
                     <td >
                         " + _countStd + @" คน
                     </td>

                     <th bgcolor='#efefef'>
                         จำนวนชั่วโมง:
                     </th>
            
                     <td >
                         " + _sumHour + @" ชั่วโมง
                     </td>

                     <th bgcolor='#efefef'>
                         จำนวนกิจกรรม:
                     </th>
            
                     <td >
                         " + _countProject + @" กิจกรรม
                     </td>

                     </tr>
  
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
    /// Date   : 2018-05-16
    /// Perpose: 
    /// Method : pagePrintSpiderGraphUniversityLevel
    /// Sample : N/A
    /// </summary>
    public static string pagePrintSpiderGraphUniversityLevel(string _facultyId)
    {
       StringBuilder _string = new StringBuilder();
       _string.Append(@"  </br>  
       
                                <div class='row '>

                                     <div class='form-group col-xs-3 '>
                                           " + ActUI.getListAcaYear("00","") + @"
                                     </div>

                                     <div class='form-group col-xs-3 '>
                                           " + ActUI.getListSemester("00") + @"
                                     </div>

                                     <div class='form-group col-xs-6 '>
                                           " + ActUI.getListFaculty(_facultyId, "") + @"
                                     </div>
                               </div>


                              </div>");

       _string.Append(@"<div class='row'>
                        <div class='form-group col-xs-12 text-center'>
                            <button type='button' class='btn btn-info btn-md btnSearchListUniversityLevel glyphicon glyphicon-stats'> รายงาน</button>
                        </div></div>");

        _string.Append("</div>");

        _string.Append("<div id='divSpiderGraphUniversityLevel' class='modal fade' role='dialog'>");
        _string.Append("<div class='modal-dialog'>");
        _string.Append("<div class='modal-content'>");
        _string.Append(@"<div class='modal-header'>
                          <button type='button' class='close' data-dismiss='modal'>&times;</button>
                          <h4 class='modal-title'>รายงานระดับมหาวิทยาลัย</h4>
                        </div>");

        _string.Append(@"<div class='modal-body'>
                         <p>");

        _string.Append(@"<ul class='nav nav-tabs'>
                          <li class='active'><a data-toggle='tab' href='#divTabUniversity0'>Mahidol HIDEF</a></li>
                          <li><a data-toggle='tab' href='#divTabUniversity1'>Mahidol Core values</a></li>
                          <li><a data-toggle='tab' href='#divTabUniversity4'>A1 - A4</a></li>
                        </ul>");

                                  //< li >< a data - toggle = 'tab' href = '#divTabUniversity2' > 21st Century Skill Outcomes</ a ></ li >
           
                                  //   < li >< a data - toggle = 'tab' href = '#divTabUniversity3' > TQF มาตรฐานการเรียนรู้ 5 ด้าน </ a ></ li >

                              _string.Append("<div class='tab-content'>");

        _string.Append("<div id='divTabUniversity0' class='tab-pane fade in active'>");
        _string.Append("<p>");
        _string.Append("<div id='divUniversity00'></div>");
        _string.Append("<div id='divGraphUniversity00' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<h4 class='page-header' style='color:darkblue;' class='text-center'>กลุ่ม Literacy HIDEF</h4>");
        _string.Append("<div id='divGraphUniversity00_sub01' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<h4 class='page-header' style='color:darkblue;' class='text-center'>กลุ่ม 21st Century Skills</h4>");
        _string.Append("<div id='divGraphUniversity00_sub02' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue00'></div>");
        _string.Append("</p>");
        _string.Append("</div>");


        _string.Append("<div id='divTabUniversity1' class='tab-pane fade in'>");
        _string.Append("<p>");
        _string.Append("<div id='divUniversity01'></div>");
        _string.Append("<div id='divGraphUniversity01' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue01'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        _string.Append("<div id='divTabUniversity4' class='tab-pane fade'>");
        _string.Append("<p>");
        _string.Append("<div id='divUniversity04'></div>");
        _string.Append("<div id='divGraphUniversity04' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        _string.Append("<div id='divDefinitionCoreValue04'></div>");
        _string.Append("</p>");
        _string.Append("</div>");

        //_string.Append("<div id='divTabUniversity2' class='tab-pane fade'>");
        //_string.Append("<p>");
        //_string.Append("<div id='divUniversity02'></div>");
        //_string.Append("<div id='divGraphUniversity02' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        //_string.Append("<div id='divDefinitionCoreValue02'></div>");
        //_string.Append("</p>");
        //_string.Append("</div>");

        //_string.Append("<div id='divTabUniversity3' class='tab-pane fade'>");
        //_string.Append("<p>");
        //_string.Append("<div id='divUniversity03'></div>");
        //_string.Append("<div id='divGraphUniversity03' style='min-width: 600px; max-width: 700px; height: 400px; margin: 0 auto'></div>");
        //_string.Append("<div id='divDefinitionCoreValue03'></div>");
        //_string.Append("</p>");
        //_string.Append("</div>");

        _string.Append("</div>");


        _string.Append(@"</p>
                         </div>");

        _string.Append("</div>");
        _string.Append("</div>");
        _string.Append("</div>");

       return _string.ToString();

    }



    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2018-05-11
    /// Perpose: 
    /// Method : getListHeaderGraphUniversityLevel
    /// Sample : N/A
    /// </summary>
    public static string getListHeaderGraphUniversityLevel(string _acaYear, string _semester, string _facultyId, string _txtDisplayHeader,string _groupIndicatorId,string _groupCharacterId)
    {

        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getSpiderUniversityLevel(_acaYear, _semester, _facultyId, _groupIndicatorId,_groupCharacterId);
        string _countStd = "";
        string _countProject = "";
        string _sumHour = "";
        string _facNameTh = "";
        // string _countProjectAll = "";
        string _semesterDisplay = "";
        double _sumAllStd=0;
        double _sumAllProject=0;
        double _sumAllHour=0;

        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _acaYear = _dr["acaYear"].ToString();
                _semesterDisplay = _dr["semester"].ToString();

                // _countStd = _dr["countStd"].ToString();
                _countProject = _dr["countProject"].ToString();
                //_countProjectAll = _dr["countProjectAll"].ToString();
                _sumHour = _dr["sumHour"].ToString();
                _facNameTh = _dr["facTName"].ToString();

      
                _sumAllProject += Convert.ToDouble(_countProject);
                _sumAllHour += Convert.ToDouble(_sumHour);
            }
        }
        // สำหรับ CountProject
        //DataSet _ds2 = ActDB.getProjectForCount(_acaYear, _semester, _facultyId, _groupIndicatorId, _groupCharacterId);
        //if (_ds2.Tables[0].Rows.Count > 0)
        //{
        //    foreach (DataRow _dr in _ds2.Tables[0].Rows)
        //    {
        //        _countProjectAll = _dr["countProjectAll"].ToString();
        //    }
        //}
                //if (_acaYear == "")
                //{
                //    _acaYear = "ทุกปีการศึกษา";
                //}
                //if (_semester == "")
                //{
                //    _semester = "ทุกภาคการศึกษา";
                //}
                //if (_facultyId == "")
                //{
                //    _facNameTh = "ทุกคณะ";
                //}

                _string.Append(@" <table class='table table-bordered' >
                    <caption class='text-center'><h3>" + _txtDisplayHeader + @"</h3></caption>
                     <tr >
                     <th bgcolor='#efefef' class='text-right' style='width:12%;'>
                         ปีการศึกษา:
                     </th>
                     <td class='col-xs-1' style='width:10%;'>
                         " + _acaYear + @"
                     </td>
                     <th bgcolor='#efefef' class=' text-right' style='width:21%;'>
                         ภาคการศึกษา:
                     </th>
                     <td  style='width:13%;' >
                         " + _semesterDisplay + @"
                     </td>

                     <th class=' text-right' bgcolor='#efefef' style='width:18%;'>
                         คณะ:
                     </th>
                     <td >
                         " + _facNameTh + @"
                     </td>

                    
                    </tr>

                     <tr >
                    

                     <th bgcolor='#efefef' class='text-right'>
                         จำนวนชั่วโมง:
                     </th>
            
                     <td >
                         " + String.Format("{0:#,##0}", _sumAllHour) + @" ชั่วโมง
                     </td>

                     <th bgcolor='#efefef' class='text-right'>
                         
                     </th>
            
                     <td >
                       
                     </td>

                     <th bgcolor='#efefef' class='text-right'>
                         จำนวนกิจกรรมทั้งหมด:
                     </th>
            
                     <td >
                         " + String.Format("{0:#,##0}", _countProject) + @" กิจกรรม
                     </td>

                     </tr>
  
                    </table>");



         //< th bgcolor = '#efefef' >
         //                 จำนวนนักศึกษาที่เข้าร่วมกิจกรรม2:
         //            </ th >


         //            < td >
         //                " + String.Format("{ 0:#,##0}", _sumAllStd) + @" คน
         //            </ td >
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-04-16
    /// Perpose: 
    /// Method : getListDivRptStatisticFacMAHIDOL
    /// Sample : N/A
    /// </summary>
    /// 
    public static string getListDivRptStatisticFacMAHIDOL(string _facultyId)
    {

        DataSet _ds = ActDB.rptStatisticGroupAcaYearNew(_facultyId);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();
        _string.Append(@"<table class='table table-bordered'>
                    <tr bgcolor='#efefef'>
                        <th rowspan='3' class='text-center'>
                            ปีการศึกษา
                        </th>
                        <th colspan='2'  class='text-center'>
                            กำหนดให้เข้าร่วม</br>และเลือกเข้าร่วม
                        </th>
                        <th colspan='16'  class='text-center'>
                            เลือกเสรี
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนกิจกรรม</br>(รวม)
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนชั่วโมง</br>กิจกรรมรวม
                        </th>
                        <th rowspan='3'  class='text-center'>
                            จำนวนนักศึกษา</br>เข้าร่วมกิจกรรม</br>(ครั้ง)
                        </th>
                        <th rowspan='3'  class='text-center'>
                            งบประมาณ
                        </th>
                    </tr>

                    <tr bgcolor='#efefef'>
                    <th rowspan='2' class='text-center'>
                    โครงการ
                    </th>
                    <th rowspan='2' class='text-center'>
                    ชั่วโมง
                    </th>
                    <th rowspan='2' class='text-center'>
                    โครงการ
                    </th>
                    <th colspan='8' class='text-center'>
                    จำนวนชั่วโมง
                    </th>
                    <th colspan='7' class='text-center'>
                    จำนวนโครงการที่สอดคล้องในแต่ละด้าน
                    </th>
                    </tr>

                    <tr bgcolor='#efefef'>
                    <th class='text-center'>
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
                    </th>
                    <th class='text-center'>
                    รวม
                    </th>

                    <th class='text-center'>
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
                    </th>
                    </tr>
        ");

        string _acaYearTran = "";
        string _countActType1 = "";
        string _sumHoursType1 = "";
        string _countActType2 = "";
        string _M = "";
        string _A = "";
        string _H = "";
        string _I = "";
        string _D = "";
        string _O = "";
        string _L = "";

        string _sumHoursType2 = "";
        string _countActMatchM = "", _countActMatchA = "", _countActMatchH = "", _countActMatchI = "";
        string _countActMatchD = "", _countActMatchO = "", _countActMatchL = "";
        string _countActTypeAll = "";
        string _sumHoursTypeAll = "";
        string _countNumStdAct = "";
        string _sumBudget = "";

        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _acaYearTran = _dr["acaYear"].ToString();
                _countActType1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActType1"]));
                _sumHoursType1 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursType1"]));
                _countActType2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActType2"]));
                _M = String.Format("{0:#,##0}", Convert.ToDouble(_dr["M"]));
                _A = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A"]));
                _H = String.Format("{0:#,##0}", Convert.ToDouble(_dr["H"]));
                _I = String.Format("{0:#,##0}", Convert.ToDouble(_dr["I"]));
                _D = String.Format("{0:#,##0}", Convert.ToDouble(_dr["D"]));
                _O = String.Format("{0:#,##0}", Convert.ToDouble(_dr["O"]));
                _L = String.Format("{0:#,##0}", Convert.ToDouble(_dr["L"]));



                _sumHoursType2 = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursType2"]));
                _countActMatchM = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchM"]));
                _countActMatchA = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchA"]));
                _countActMatchH = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchH"]));
                _countActMatchI = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchI"]));
                _countActMatchD = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchD"]));
                _countActMatchO = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchO"]));
                _countActMatchL = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActMatchL"]));
                _countActTypeAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActTypeAll"]));
                _sumHoursTypeAll = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHoursTypeAll"]));
                _countNumStdAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countNumStdAct"]));
                _sumBudget = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumBudget"]));



                _string.Append(@"
                 <tr bgcolor='#f7f8f9'>
                        <td class='text-center'>
                            <font color='#025ebc'><a href='#' data-acayear='" + _acaYearTran + "' class='btnRptProjectBudget'>" + _acaYearTran + @"</a></font>
                        </td>
                        <td class='text-right'>
                            " + _countActType1 + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursType1 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActType2 + @"
                        </td>
                        <td class='text-right'>
                            " + _M + @"
                        </td>
                        <td class='text-right'>
                            " + _A + @"
                        </td>
                        <td class='text-right'>
                            " + _H + @"
                        </td>
                        <td class='text-right'>
                            " + _I + @"
                        </td>
                        <td class='text-right'>
                            " + _D + @"
                        </td>
                        <td class='text-right'>
                            " + _O + @"
                        </td>
                        <td class='text-right'>
                            " + _L + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursType2 + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchM + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchA + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchH + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchI + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchD + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchO + @"
                        </td>
                        <td class='text-right'>
                            " + _countActMatchL + @"
                        </td>
                        <td class='text-right'>
                            " + _countActTypeAll + @"
                        </td>
                        <td class='text-right'>
                            " + _sumHoursTypeAll + @"
                        </td>
                        <td class='text-right'>
                            " + _countNumStdAct + @"
                        </td>
                        <td class='text-right'>
                            " + _sumBudget + @"
                        </td>
           
                </tr>
                                        ");


            }

        }
        else
        {

        }

        _string.Append("  </table>");
        return _string.ToString();
    }




    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-05-13
    /// Perpose: 
    /// Method : panelReportStudent
    /// Sample : N/A
    /// </summary>
    public static string panelReportStudent(string _facultyId)
    {
        StringBuilder _string = new StringBuilder();
        _string.Append("<div>");
        _string.Append("<h1 class='page-header'>รายงานนักศึกษาเข้าร่วมกิจกรรม </h1>");
        _string.Append(@"<ul class='nav nav-tabs' style='font-size:16px;' >
                          <li role = 'presentation' class='active'><a data-toggle='tab' href='#divRptStd1'> ข้อมูลชั่วโมงกิจกรรม/จำนวนกิจกรรมของนศ.</a></li>
                          <li role = 'presentation' ><a data-toggle='tab' href='#divRptStd2'>รายงาน HIDEF Summary</a></li> 
                          <li role = 'presentation' ><a data-toggle='tab' href='#divRptStd3'>รายงาน 21st Century skill </a></li>
                         </ul>");

                          //<li role = 'presentation' ><a data-toggle='tab' href='#divRptStd2'>รายงานกิจกรรม ตามด้านกิจกรรม</a></li>
                          //


        _string.Append("  <div class='tab-content'>");


        _string.Append("        <div id='divRptStd1' class='tab-pane fade in active'>");
        _string.Append("           <div  class='row form-group'>");
        _string.Append("                <div  class='col-xs-2'>");
        _string.Append(                 ActUI.getListStudentYear());
        _string.Append("                </div>");

        _string.Append("                <div  class='col-xs-5'>");
        _string.Append(                 ActUI.getListFaculty(_facultyId, ""));
        _string.Append("                </div>");

        _string.Append("                <div  class='col-xs-5'>");
        _string.Append("                <div class='divProgram'>");
        _string.Append(                 ActUI.getListProgram(_facultyId));
        _string.Append("                </div>");
        _string.Append("                </div>");
        //_string.Append("                <div  class='col-xs-2'>");
        //_string.Append(                 ActUI.getListStudyYear());
        //_string.Append("                </div>");

        _string.Append("           </div>");
        _string.Append(@"         <div class='row '>
                                        <div class=' col-xs-12 text-center'>
                                             <button type='button' class='btn btn-info btn-md btnSearchRptStd1 glyphicon glyphicon-search'> ค้นหา</button>
                                             &nbsp;<button type='button' class='btn btn-success btn-md btnSearchRptStd1Excel glyphicon glyphicon-file'> Excel</button>
                                        </div>
                                  </div>");
        _string.Append("          <div  class='divMainRptStd1 table-responsive'></div>");
        _string.Append("        </div>");


        _string.Append("        <div id='divRptStd2' class='tab-pane fade'>");
        _string.Append("           <div  class='row form-group'>");
        _string.Append("                <div  class='col-xs-2'>");
        _string.Append(ActUI.getListStudentYear());
        _string.Append("                </div>");
        _string.Append("                <div  class='col-xs-5'>");
        _string.Append(ActUI.getListFaculty(_facultyId, ""));
        _string.Append("                </div>");
        _string.Append("                <div  class='col-xs-5'>");
        _string.Append("                <div class='divProgram'>");
        _string.Append(ActUI.getListProgram(_facultyId));
        _string.Append("                </div>");
        _string.Append("                </div>");
        _string.Append("           </div>");
        _string.Append(@"         <div class='row '>
                                        <div class=' col-xs-12 text-center'>
                                             <button type='button' class='btn btn-info btn-md btnSearchRptStd2 glyphicon glyphicon-search'> ค้นหา</button>
                                             

                                        </div>
                                  </div>");
        //&nbsp;<button type='button' class='btn btn-success btn-md btnSearchRptStd2Excel glyphicon glyphicon-file'> Excel</button>
        _string.Append("          <div  class='divMainRptStd2 table-responsive'></div>");
        _string.Append("        </div>");



        _string.Append("        <div id='divRptStd3' class='tab-pane fade'>");
        _string.Append("           <div  class='row form-group'>");
        _string.Append("                <div  class='col-xs-2'>");
        _string.Append(ActUI.getListStudentYear());
        _string.Append("                </div>");
        _string.Append("                <div  class='col-xs-5'>");
        _string.Append(ActUI.getListFaculty(_facultyId, ""));
        _string.Append("                </div>");
        _string.Append("                <div  class='col-xs-5'>");
        _string.Append("                <div class='divProgram'>");
        _string.Append(ActUI.getListProgram(_facultyId));
        _string.Append("                </div>");
        _string.Append("                </div>");
        _string.Append("           </div>");
        _string.Append(@"         <div class='row '>
                                        <div class=' col-xs-12 text-center'>
                                             <button type='button' class='btn btn-info btn-md btnSearchRptStd3 glyphicon glyphicon-search'> ค้นหา</button>
                                             

                                        </div>
                                  </div>");
         _string.Append("          <div  class='divMainRptStd3 table-responsive'></div>");
        _string.Append("        </div>");



        _string.Append("        </div>");

        _string.Append("        <div id='divRptStd3' class='tab-pane fade'>3");
        _string.Append("        </div>");

        _string.Append("  </div>");

        _string.Append("</div>");
        return _string.ToString();
    }


    /// <summary>
    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2019-05-16
    /// Perpose: 
    /// Method : resultRptSumHrAndCountActStudent
    /// Sample : N/A
    /// </summary>
    public static string resultRptSumHrAndCountActStudent(string _facultyId, string _programId, string _studyYear,string _acaYear)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRptSumHrAndCountActStudent(_facultyId, _programId, _studyYear, _acaYear);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        // class='table-responsive' style='height:320px;'
        // table-hover table-fixed
        _string.Append(@"
                          <table id='tblRptStd1' class='table table-bordered'>
                          <thead>
                            <tr class='bg-primary' >
                                <th scope = 'col' >#</th>
                                <th scope = 'col' nowrap='nowrap'> รหัสนักศึกษา </th>
                                <th scope = 'col' nowrap='nowrap' > คำนำหน้า </th>
                                <th scope = 'col' > ชื่อ </th>
                                <th scope = 'col' nowrap='nowrap' > นามสกุล </th>
                                <th scope = 'col' nowrap='nowrap' > รหัสคณะ </th>
                                <th scope = 'col' > ชื่อคณะ </th>
                                <th scope = 'col' nowrap='nowrap' > รหัสหลักสูตร </th>
                                <th scope = 'col' nowrap='nowrap' > ชื่อหลักสูตร </th>
                                <th scope = 'col' nowrap='nowrap' > สถานะนักศึกษา </th>
                                <th scope = 'col' nowrap='nowrap' > ชั้นปี </th>
                                <th scope = 'col' nowrap='nowrap' > สถานะ </th>
                                <th scope = 'col' nowrap='nowrap' > จำนวนกิจกรรม </th>
                                <th scope = 'col' > A.1 </th>
                                <th scope = 'col' > A.2 </th>
                                <th scope = 'col' > A.3 </th>
                                <th scope = 'col' > A.4 </th>
                                <th scope = 'col' nowrap='nowrap' > รวม A.1 - A.4 </th>
                                <th scope = 'col' > M </th>
                                <th scope = 'col' > A </th>
                                <th scope = 'col' > H </th>
                                <th scope = 'col' > I </th>
                                <th scope = 'col' > D </th>
                                <th scope = 'col' > O </th>
                                <th scope = 'col' > L </th>
                                <th scope = 'col' nowrap='nowrap' > รวม M-L </th>
                                <th scope = 'col' > H </th>
                                <th scope = 'col' > I </th>
                                <th scope = 'col' > D </th>
                                <th scope = 'col' > E </th>
                                <th scope = 'col' > F </th>
                                <th scope = 'col' nowrap='nowrap' > รวม HIDEF </th>
                                <th scope = 'col' > ปฐมนิเทศ </th>
                                <th scope = 'col' > ไหว้ครู </th>
                                <th scope = 'col' > จิตอาสา </th>
                                <th scope = 'col' > 21St </th>
                            </tr>
                          </thead>
                          <tbody >");
        string _row = "";
        string _studentCode = "";
        string _titleName = "";
        string _firstName = "";
        string _lastName = "";
        string _facultyCode = "";
        string _facultyNameTh = "";
        string _programCode = "";
        string _majorCode = "";
        string _groupNum = "";
        string _programNameTh = "";
        string _stsNameTh = "";
        string _class = "";
        string _countAct = "";
        string _a1Val = "";
        string _a2Val = "";
        string _a3Val = "";
        string _a4Val = "";
        string _sumAlla = "";
        string _mVal = "";
        string _aVal = "";
        string _hVal = "";
        string _iVal = "";
        string _dVal = "";
        string _oVal = "";
        string _lVal = "";
        string _H = "";
        string _I = "";
        string _D = "";
        string _E = "";
        string _F = "";
        string _sumAllHIDEF = "";
        string _stsPassTh = "";
        string _sumAllCoreValue = "";
        string _PatomNited = "";
        string _WaiKru = "";
        string _Volunteer = "";
        string _21St = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _row = _dr["Row"].ToString();
                _studentCode = _dr["studentCode"].ToString();
                _titleName = _dr["titleName"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _programCode = _dr["programCode"].ToString();
                _majorCode = _dr["majorCode"].ToString();
                _groupNum = _dr["groupNum"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _stsNameTh = _dr["stsNameTh"].ToString();
                _class = _dr["class"].ToString();
                _stsPassTh = _dr["stsPassTh"].ToString();
                _countAct = _dr["countAct"].ToString();
                _a1Val = _dr["A.1"].ToString();
                _a2Val = _dr["A.2"].ToString();
                _a3Val = _dr["A.3"].ToString();
                _a4Val = _dr["A.4"].ToString();
                _sumAlla = _dr["sumAlla"].ToString();
                _mVal = _dr["M"].ToString();
                _aVal = _dr["A"].ToString();
                _hVal = _dr["H"].ToString();
                _iVal = _dr["I"].ToString();
                _dVal = _dr["D"].ToString();
                _oVal = _dr["O"].ToString();
                _lVal = _dr["L"].ToString();
                _sumAllCoreValue = _dr["sumAllCoreValue"].ToString();
                _H = _dr["H_HIDEF"].ToString();
                _I = _dr["I_HIDEF"].ToString();
                _D = _dr["D_HIDEF"].ToString();
                _E = _dr["E_HIDEF"].ToString();
                _F = _dr["F_HIDEF"].ToString();
                _sumAllHIDEF = _dr["sumAllHIDEF"].ToString();
                _PatomNited = _dr["PatomNited"].ToString();
                _WaiKru = _dr["WaiKru"].ToString();
                _Volunteer = _dr["Volunteer"].ToString();
                _21St = _dr["21St"].ToString();

                _string.Append(@"<tr >
                                      <th scope = 'row' > "+ _row + @" </th>
                                      <td class='text-center'> "+ _studentCode + @" </td>
                                      <td > "+ _titleName + @" </td>
                                      <td nowrap='nowrap' > "+ _firstName + @" </td>
                                      <td nowrap='nowrap' > "+ _lastName + @" </td>
                                      <td > "+ _facultyCode + @" </td>
                                      <td nowrap='nowrap' > "+ _facultyNameTh + @" </td>
                                      <td > "+ _programCode + _majorCode + _groupNum + @" </td>
                                      <td nowrap='nowrap' > "+ _programNameTh + @" </td>
                                      <td nowrap='nowrap' > "+ _stsNameTh + @" </td>
                                      <td class='text-center'> " + _class + @" </td>
                                      <td class='text-center'> " + _stsPassTh + @" </td>
                                      <td class='text-right'> " + _countAct + @" </td>
                                      <td > "+ _a1Val + @" </td>
                                      <td > "+ _a2Val + @" </td>
                                      <td > "+ _a3Val + @" </td>
                                      <td > "+ _a4Val + @" </td>
                                      <td class='text-right'> " + _sumAlla + @" </td>
                                      <td > "+ _mVal + @" </td>
                                      <td > "+ _aVal + @" </td>
                                      <td > "+ _hVal + @" </td>
                                      <td > "+ _iVal + @" </td>
                                      <td > "+ _dVal + @" </td>
                                      <td > "+ _oVal + @" </td>
                                      <td > "+ _lVal + @" </td>
                                      <td class='text-right'> " + _sumAllCoreValue + @" </td>
                                      <td > " + _H + @" </td>
                                      <td > " + _I + @" </td>
                                      <td > " + _D + @" </td>
                                      <td > " + _E + @" </td>
                                      <td > " + _F + @" </td>
                                      <td class='text-right'> " + _sumAllHIDEF + @" </td>
                                      <td > " + _PatomNited + @" </td>
                                      <td > " + _WaiKru + @" </td>
                                      <td > " + _Volunteer + @" </td>
                                      <td > " + _21St + @" </td>
                                    </tr >");
            }
        }
        _string.Append(@"       </tbody>
                               </table>
                             ");

        return _string.ToString();
    }


    public static string getListForPageSearchStudentCondition(string _studentCode, string _stdFName, string _stdLName)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListStudent();
        DataRow[] _drRow = _ds.Tables[0].Select("studentCode like '%" + _studentCode + "%' and firstName like '%" + _stdFName + "%'  and lastName like '%" + _stdLName + "%' ");
        int _row = _drRow.Length;

        _string.Append(@"<table id='tblStdPageSearch' class='table table-bordered table-hover'>
                         <thead>
                         <tr class='bg-info' >
                         <th class='text-center' style='width:5%;'>
                         ลำดับ
                         </th>
                         <th class='text-center' style='width:12%;'>
                         รหัสนักศึกษา
                         </th> 
                         <th class='text-center' style='width:18%;'>
                         ชื่อ-นามสกุล
                         </th>
                         <th class='text-center'>
                         ชื่อคณะ
                         </th>
                         <th class='text-center' style='width:30%;'>
                         ชื่อหลักสูตร
                         </th>
                         </tr>
                         </thead>");
        if (_row > 0)
        {
            for (int _i = 0; _i < _row; _i++)
            {
                // if (_indicatorId == _drRow[_i]["id"].ToString())





                _string.Append(@"<tr style='cursor:pointer;' onclick=searchStudentCondition('" + _drRow[_i]["studentId"] + "','" + _drRow[_i]["studentCode"] + @"');>
                         <td class='text-center' >
                         " + (_i+1).ToString() + @"
                         </td>
                         <td class='text-center'>
                          " + _drRow[_i]["studentCode"] + @"
                         </td> 
                         <td>
                         " + _drRow[_i]["fullNameTh"] + @"
                         </td>
                         <td>
                         " +  _drRow[_i]["facultyCode"] +" - "+ _drRow[_i]["facNameTh"] + @"
                         </td>
                         <td>
                         " + _drRow[_i]["progNameTh"] + @"
                         </td>
                         </tr>");
            }
        }


        _string.Append("</table>");

        return _string.ToString();
    }




    public static string getListRptStatisticDepartment(string _facultyId,string _groupIndicatorId,string _ddlYearReport,string _ddlMonthReport)
    {
        StringBuilder _string = new StringBuilder();

        if (_groupIndicatorId == "GIR-003")
        {
            DataSet _ds = ActDB.getListRptStatisticDepartment(_facultyId, _groupIndicatorId, _ddlYearReport, _ddlMonthReport);
            int _count = _ds.Tables[0].Rows.Count;
            _string.Append(@"<table class='table table-bordered table-hover'>
                    <thead>
                    <tr >
                        <th colspan='31' class='text-left' style='color:darkblue;font-size:16px;'>
                            Mahidol HIDEF (ปีการศึกษา 2562 – ปัจจุบัน)
                        </th>
                    </tr>
                    <tr bgcolor='#DFF6FC'>
                        <th rowspan='3' class='text-center' style='width:90px;vertical-align:middle;'>
                            ปีการศึกษา
                        </th>
                        <th colspan='13'  class='text-center'>
                            จำนวนโครงการสอดคล้อง
                        </th>
                        <th colspan='13'  class='text-center'>
                            จำนวนชั่วโมงสอดคล้อง
                        </th>
                       
                        <th rowspan='3'  class='text-center' style='width:140px;vertical-align:middle;'>
                            จำนวนกิจกรรมรวม</br>(กิจกรรม)
                        </th>
                        <th rowspan='3'  class='text-center' style='width:130px;vertical-align:middle;'>
                            จำนวนชั่วโมงรวม</br>(ชั่วโมง)
                        </th>
                        <th rowspan='3'  class='text-center' style='width:130px;vertical-align:middle;'>
                            จำนวนนักศึกษา</br>เข้าร่วมกิจกรรม</br>(ครั้ง)
                        </th>
                        <th rowspan='3'  class='text-center' style='width:120px;vertical-align:middle;'>
                            งบประมาณ</br>(บาท)
                        </th>
                    </tr>

                  
                    <tr bgcolor='#DFF6FC'>
                    <th class='text-center' rowspan='2' style='vertical-align:middle; '>
                    Orientation
                    </th>
                    <th class='text-center' rowspan='2' style='vertical-align:middle;'>
                    Waikru
                    </th>
                    <th class='text-center' rowspan='2' style='vertical-align:middle;'>
                    Volunteer
                    </th>
                    <th class='text-center' colspan='5' style='vertical-align:middle;'>
                    HIDEF
                    </th>
                    <th class='text-center' colspan='5' style='vertical-align:middle;' >
                    21st Century Skills
                    </th>
                    <th class='text-center' rowspan='2' style='vertical-align:middle;'>
                    Orientation
                    </th>
                    <th class='text-center' rowspan='2' style='vertical-align:middle;'>
                    Waikru
                    </th>
                    <th class='text-center' rowspan='2' style='vertical-align:middle;'>
                    Volunteer
                    </th>
                    <th class='text-center' colspan='5' style='vertical-align:middle;'>
                    HIDEF
                    </th>
                    <th class='text-center' colspan='5' style='vertical-align:middle;'>
                    21st Century Skills
                    </th>

                    </tr>
                    <tr bgcolor = '#DFF6FC' >
                    <th style='vertical-align:middle; '>H</th> <th style='vertical-align:middle; '>I</th> 
                    <th style='vertical-align:middle; '>D</th> <th style='vertical-align:middle; '>E</th> 
                    <th style='vertical-align:middle; '>F</th>
                    <th style='vertical-align:middle; '>Critical Thinking & Problem Solving</th> 
                    <th style='vertical-align:middle; '>Creativity & Innovation</th> 
                    <th style='vertical-align:middle; '>Communication & Collaboration</th> 
                    <th style='vertical-align:middle; '>Leadership & Management Skills</th> 
                    <th style='vertical-align:middle; '>Social Skill</th>
                    <th style='vertical-align:middle; '>H</th> <th style='vertical-align:middle; '>I</th> 
                    <th style='vertical-align:middle; '>D</th> <th style='vertical-align:middle; '>E</th> 
                    <th style='vertical-align:middle; '>F</th>
                    <th style='vertical-align:middle; '>Critical Thinking & Problem Solving</th> 
                    <th style='vertical-align:middle; '>Creativity & Innovation</th> 
                    <th style='vertical-align:middle; '>Communication & Collaboration</th> 
                    <th style='vertical-align:middle; '>Leadership & Management Skills</th> 
                    <th style='vertical-align:middle; '>Social Skill</th>
                    </tr >
                    </thead >       ");
            string _acaYearTran = "";
            string _orientation_act = "";
            string _waiKru_act = "";
            string _volunteer_act = "";
            string _health_act = "";
            string _inter_act = "";
            string _digital_act = "";
            string _enviroment_act = "";
            string _finance_act = "";
            string _critical_act = "";
            string _creativity_act = "";
            string _communication_act = "";
            string _leadership_act = "";
            string _socialSkill_act = "";
            string _orientation_hour = "";
            string _waiKru_hour = "";
            string _volunteer_hour = "";

            string _health_hour = "";
            string _inter_hour = "";
            string _digital_hour = "";
            string _enviroment_hour = "";
            string _finance_hour = "";

            string _critical_hour = "";
            string _creativity_hour = "";
            string _communication_hour = "";
            string _leadership_hour = "";
            string _socialSkill_hour = "";

            string _countActReal = "";
            string _hoursAct = "";
            string _countNumStdAct = "";
            string _sumBudget = "";
            if (_count > 0)
            {
                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {

                    _acaYearTran = _dr["acaYear"].ToString();
                    _orientation_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["orientation_act"]));
                    _waiKru_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["waiKru_act"]));
                    _volunteer_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["volunteer_act"]));
                    _health_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["health_act"]));
                    _inter_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["inter_act"]));
                    _digital_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["digital_act"]));
                    _enviroment_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["enviroment_act"]));
                    _finance_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["finance_act"]));

                    _critical_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["critical_act"]));
                    _creativity_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["creativity_act"]));
                    _communication_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["communication_act"]));
                    _leadership_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["leadership_act"]));
                    _socialSkill_act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["socialSkill_act"]));


                    _orientation_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["orientation_hour"]));
                    _waiKru_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["waiKru_hour"]));
                    _volunteer_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["volunteer_hour"]));


                    _health_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["health_hour"]));
                    _inter_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["inter_hour"]));
                    _digital_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["digital_hour"]));
                    _enviroment_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["enviroment_hour"]));
                    _finance_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["finance_hour"]));


                    _critical_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["critical_hour"]));
                    _creativity_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["creativity_hour"]));
                    _communication_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["communication_hour"]));
                    _leadership_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["leadership_hour"]));
                    _socialSkill_hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["socialSkill_hour"]));

                    _countActReal = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActReal"]));
                    _hoursAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["hoursAct"]));
                    _countNumStdAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countNumStdAct"]));
                    _sumBudget = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumBudget"]));

                    _string.Append(" <tr > <td class='text-center'><b style='color:darkblue;'>" + _acaYearTran + "</b></td>");
                    _string.Append(" <td class='text-center'>" + _orientation_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _waiKru_act + "</td>");

                    _string.Append(" <td class='text-center'>" + _volunteer_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _health_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _inter_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _digital_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _enviroment_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _finance_act + "</td>");

                    _string.Append(" <td class='text-center'>" + _critical_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _creativity_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _communication_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _leadership_act + "</td>");
                    _string.Append(" <td class='text-center'>" + _socialSkill_act + "</td>");

                    _string.Append(" <td class='text-center'>" + _orientation_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _waiKru_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _volunteer_hour + "</td>");

                    _string.Append(" <td class='text-center'>" + _health_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _inter_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _digital_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _enviroment_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _finance_hour + "</td>");

                    _string.Append(" <td class='text-center'>" + _critical_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _creativity_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _communication_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _leadership_hour + "</td>");
                    _string.Append(" <td class='text-center'>" + _socialSkill_hour + "</td>");

                    _string.Append(" <td class='text-center'>" + _countActReal + "</td>");
                    _string.Append(" <td class='text-center'>" + _hoursAct + "</td>");
                    _string.Append(" <td class='text-center'>" + _countNumStdAct + "</td>");
                    _string.Append(" <td class='text-center'>" + _sumBudget + "</td>");

                    _string.Append(" </tr>");
                }
            }
            else {
                _string.Append("<tr><td class='text-center' colspan='31'>ไม่มีข้อมูลสถิติกลุ่มตัวชี้วัดประเภทนี้</td></tr>");
            }

        }
        else if (_groupIndicatorId == "GIR-002")
        {

            DataSet _ds = ActDB.getListRptStatisticDepartment(_facultyId, _groupIndicatorId,"","");
            int _count = _ds.Tables[0].Rows.Count;

            _string.Append(@"<table class='table table-bordered table-hover'>
                    <thead>
                    <tr >
                        <th colspan='19' class='text-left' style='color:darkblue;font-size:16px;'>
                            MAHIDOL CORE VALUES (ปีการศึกษา 2560 – 2561)
                        </th>
                    </tr>
                    <tr bgcolor='#DFF6FC'>
                        <th rowspan='2' class='text-center' style='width:90px;'>
                            ปีการศึกษา
                        </th>
                        <th colspan='7'  class='text-center'>
                            จำนวนโครงการสอดคล้อง
                        </th>
                        <th colspan='7'  class='text-center'>
                            จำนวนชั่วโมงสอดคล้อง
                        </th>
                        <th rowspan='2'  class='text-center' style='width:140px;'>
                            จำนวนกิจกรรมรวม</br>(กิจกรรม)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:130px;'>
                            จำนวนชั่วโมงรวม</br>(ชั่วโมง)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:130px;'>
                            จำนวนนักศึกษา</br>เข้าร่วมกิจกรรม</br>(ครั้ง)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:120px;'>
                            งบประมาณ</br>(บาท)
                        </th>
                    </tr>

                  
                    <tr bgcolor='#DFF6FC'>
                    <th class='text-center'>
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
                    </th>

                    <th class='text-center'>
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
                    </th>
                    </tr>
                    </thead>
        ");

            string _acaYearTran = "";
            string M_Act = "";
            string A_Act = "";
            string H_Act = "";
            string I_Act = "";
            string D_Act = "";
            string O_Act = "";
            string L_Act = "";
            string M_Hour = "";
            string A_Hour = "";
            string H_Hour = "";
            string I_Hour = "";
            string D_Hour = "";
            string O_Hour = "";
            string L_Hour = "";
            string _countActReal = "";
            string _hoursAct = "";
            string _countNumStdAct = "";
            string _sumBudget = "";


            if (_count > 0)
            {
                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {

                    _acaYearTran = _dr["acaYear"].ToString();
                    M_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["M_Act"]));
                    A_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A_Act"]));
                    H_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["H_Act"]));
                    I_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["I_Act"]));
                    D_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["D_Act"]));
                    O_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["O_Act"]));
                    L_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["L_Act"]));

                    M_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["M_Hour"]));
                    A_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A_Hour"]));
                    H_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["H_Hour"]));
                    I_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["I_Hour"]));
                    D_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["D_Hour"]));
                    O_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["O_Hour"]));
                    L_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["L_Hour"]));

                    _countActReal = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActReal"]));
                    _hoursAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["hoursAct"]));
                    _countNumStdAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countNumStdAct"]));
                    _sumBudget = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumBudget"]));
                    //                             <font color='#025ebc'><a href='#' data-acayear='" + _acaYearTran + "' class='btnRptProjectBudget'>" + _acaYearTran + @"</a></font>
                    _string.Append(@"
                 <tr >
                        <td class='text-center'>
                            <b style='color:darkblue;'>" + _acaYearTran + @"</b>
                        </td>
                        <td class='text-right'>
                            " + M_Act + @"
                        </td>
                        <td class='text-right'>
                            " + A_Act + @"
                        </td>
                        <td class='text-right'>
                            " + H_Act + @"
                        </td>
                        <td class='text-right'>
                            " + I_Act + @"
                        </td>
                        <td class='text-right'>
                            " + D_Act + @"
                        </td>
                        <td class='text-right'>
                            " + O_Act + @"
                        </td>
                        <td class='text-right'>
                            " + L_Act + @"
                        </td>

                        <td class='text-right'>
                            " + M_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + A_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + H_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + I_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + D_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + O_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + L_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + _countActReal + @"
                        </td>
                        <td class='text-right'>
                            " + _hoursAct + @"
                        </td>
                        <td class='text-right'>
                            " + _countNumStdAct + @"
                        </td>

                        <td class='text-right'>
                            " + _sumBudget + @"
                        </td>
                 </tr> ");


                }

            }
            else
            {
                _string.Append("<tr><td class='text-center' colspan='19'>ไม่มีข้อมูลสถิติกลุ่มตัวชี้วัดประเภทนี้</td></tr>");
            }

        }
        else if (_groupIndicatorId == "GIR-001")
        {

            DataSet _ds = ActDB.getListRptStatisticDepartment(_facultyId, _groupIndicatorId,"","");
            int _count = _ds.Tables[0].Rows.Count;

            _string.Append(@"<table class='table table-bordered table-hover'>
                    <thead>
                    <tr >
                        <th colspan='19' class='text-left' style='color:darkblue;font-size:16px;'>
                            TQF (ปีการศึกษา 2552 – 2559)
                        </th>
                    </tr>
                    <tr bgcolor='#DFF6FC'>
                        <th rowspan='2' class='text-center' style='width:90px;'>
                            ปีการศึกษา
                        </th>
                        <th colspan='4'  class='text-center'>
                            จำนวนโครงการสอดคล้อง
                        </th>
                        <th colspan='4'  class='text-center'>
                            จำนวนชั่วโมงสอดคล้อง
                        </th>
                        <th rowspan='2'  class='text-center' style='width:140px;'>
                            จำนวนกิจกรรมรวม</br>(กิจกรรม)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:130px;'>
                            จำนวนชั่วโมงรวม</br>(ชั่วโมง)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:130px;'>
                            จำนวนนักศึกษา</br>เข้าร่วมกิจกรรม</br>(ครั้ง)
                        </th>
                        <th rowspan='2'  class='text-center' style='width:120px;'>
                            งบประมาณ</br>(บาท)
                        </th>
                    </tr>

                  
                    <tr bgcolor='#DFF6FC'>
                    <th class='text-center'>
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
                    </th>
                   

                    <th class='text-center'>
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
                    </th>
                   
                    </tr>
                    </thead>
        ");

            string _acaYearTran = "";
            string A1_Act = "";
            string A2_Act = "";
            string A3_Act = "";
            string A4_Act = "";
 
            string A1_Hour = "";
            string A2_Hour = "";
            string A3_Hour = "";
            string A4_Hour = "";


            string _countActReal = "";
            string _hoursAct = "";
            string _countNumStdAct = "";
            string _sumBudget = "";


            if (_count > 0)
            {
                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {

                    _acaYearTran = _dr["acaYear"].ToString();
                    A1_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A1_Act"]));
                    A2_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A2_Act"]));
                    A3_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A3_Act"]));
                    A4_Act = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A4_Act"]));

                    A1_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A1_Hour"]));
                    A2_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A2_Hour"]));
                    A3_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A3_Hour"]));
                    A4_Hour = String.Format("{0:#,##0}", Convert.ToDouble(_dr["A4_Hour"]));


                    _countActReal = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countActReal"]));
                    _hoursAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["hoursAct"]));
                    _countNumStdAct = String.Format("{0:#,##0}", Convert.ToDouble(_dr["countNumStdAct"]));
                    _sumBudget = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumBudget"]));

                    //  <font color='#025ebc'><a href='#' data-acayear='" + _acaYearTran + "' class='btnRptProjectBudget'>" + _acaYearTran + @"</a></font>
                    _string.Append(@"
                 <tr >
                        <td class='text-center'>
                            <b style='color:darkblue;'>" + _acaYearTran + @"</b>
                        </td>
                        <td class='text-right'>
                            " + A1_Act + @"
                        </td>
                        <td class='text-right'>
                            " + A2_Act + @"
                        </td>
                        <td class='text-right'>
                            " + A3_Act + @"
                        </td>
                        <td class='text-right'>
                            " + A4_Act + @"
                        </td>
                        <td class='text-right'>
                            " + A1_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + A2_Hour + @"
                        </td>
                        <td class='text-right'>
                            " + A3_Hour + @"
                        </td>

                        <td class='text-right'>
                            " + A4_Hour + @"
                        </td>

                        <td class='text-right'>
                            " + _countActReal + @"
                        </td>
                        <td class='text-right'>
                            " + _hoursAct + @"
                        </td>
                        <td class='text-right'>
                            " + _countNumStdAct + @"
                        </td>

                        <td class='text-right'>
                            " + _sumBudget + @"
                        </td>
                 </tr> ");


                }

            }
            else
            {
                _string.Append("<tr><td class='text-center' colspan='31'>ไม่มีข้อมูลสถิติกลุ่มตัวชี้วัดประเภทนี้</td></tr>");
            }

        }


        _string.Append("  </table>");
        return _string.ToString();
    }



    public static string resultRptStudentKPITransection(string _facultyId, string _programId, string _studyYear , string _isExcel)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRptStudentKPITransection(_facultyId, _programId, _studyYear);

        int _count = _ds.Tables[0].Rows.Count;
        // class='table-responsive' style='height:320px;'
        // table-hover table-fixed
        _string.Append(@"
                          <table id='tblRptStd1' class='table table-bordered table-hover'>
                          <thead>
                            <tr class='bg-info' >
                                <th style='background-color:#D4FAFD;font-weight:bold;' >#</th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap'> รหัสนักศึกษา </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > คำนำหน้า </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' > ชื่อ </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > นามสกุล </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > รหัสคณะ </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' > ชื่อคณะ </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > รหัสหลักสูตร </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > ชื่อหลักสูตร </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > สถานะนักศึกษา </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > ชั้นปี </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > สถานะ </th>
                                <th style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' > จำนวนกิจกรรม </th>
<th style='background-color:#C3D341;font-weight:bold;' nowrap='nowrap' > ปฐมนิเทศ </th>
<th style='background-color:#C3D341;font-weight:bold;' nowrap='nowrap' > ไหว้ครู </th>
<th style='background-color:#C3D341;font-weight:bold;' nowrap='nowrap' > จิตอาสา </th>
        ");
        if (_isExcel == "1") 
        {
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:160px;vertical-align:middle;' nowrap='nowrap' > Health_Literacy </th>");
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:185px;vertical-align:middle;' nowrap='nowrap' > Internationalization </th>");
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:160px;vertical-align:middle;' nowrap='nowrap' > Digital_Literacy </th>");
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:235px;vertical-align:middle;' nowrap='nowrap' > Environmental_Literacy </th>");
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:180px;vertical-align:middle;' nowrap='nowrap' > Financial_Literacy </th>");
            _string.Append(" <th style='background-color:#fafab0;font-weight:bold;width:120px;vertical-align:middle;' nowrap='nowrap' > sumHIDEF </th>");

            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > M </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > A </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > H </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > I </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > D </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > O </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > L </th>");
            _string.Append(" <th style='background-color:#abe6e4;font-weight:bold;width:140px;vertical-align:middle;' nowrap='nowrap' > sumCorevalue </th>");

            _string.Append(" <th style='background-color:bisque;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > A1 </th>");
            _string.Append(" <th style='background-color:bisque;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > A2 </th>");
            _string.Append(" <th style='background-color:bisque;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > A3 </th>");
            _string.Append(" <th style='background-color:bisque;font-weight:bold;width:80px;vertical-align:middle;' nowrap='nowrap' > A4 </th>");
            _string.Append(" <th style='background-color:bisque;font-weight:bold;width:140px;vertical-align:middle;' nowrap='nowrap' > sumALLA1_A4 </th>");

            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:330px;' nowrap='nowrap' > 21st_CriticalThinkingProblemSolving </th>");
            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:300px;' nowrap='nowrap' > 21st_CreativityInnovation </th>");
            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:330px;' nowrap='nowrap' > 21st_CommunicationCollabration </th>");
            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:330px;' nowrap='nowrap' > 21st_LeadershipManagementSkills </th>");
            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:280px;' nowrap='nowrap' > 21st_Socialskill </th>");
            _string.Append(" <th style='background-color:#FFE1FE;font-weight:bold;vertical-align:middle;width:130px;' nowrap='nowrap' > sumALL21st </th>");
        }
        _string.Append(@" </tr>
                          </thead>
                          <tbody >");

                                //        <th scope = 'col' > A.1 </th>
                                //<th scope = 'col' > A.2 </th>
                                //<th scope = 'col' > A.3 </th>
                                //<th scope = 'col' > A.4 </th>
                                //<th scope = 'col' nowrap='nowrap' > รวม A.1 - A.4 </th>
                                //<th scope = 'col' > M </th>
                                //<th scope = 'col' > A </th>
                                //<th scope = 'col' > H </th>
                                //<th scope = 'col' > I </th>
                                //<th scope = 'col' > D </th>
                                //<th scope = 'col' > O </th>
                                //<th scope = 'col' > L </th>
                                //<th scope = 'col' nowrap='nowrap' > รวม M-L </th>

        int _i = 0;
        string _studentCode = "";
        string _titleName = "";
        string _firstName = "";
        string _lastName = "";
        string _facultyCode = "";
        string _facultyNameTh = "";
        string _programCode = "";
        string _programNameTh = "";
        string _stsNameTh = "";
        string _class = "";
        string _countAct = "";
        string _stsPassTh = "";

        string Health_Literacy = "";
        string Internationalization = "";
        string Digital_Literacy = "";
        string Environmental_Literacy = "";
        string Financial_Literacy = "";
        string sumHIDEF = "";

        string M = "";
        string A = "";
        string H = "";
        string I = "";
        string D = "";
        string O = "";
        string L = "";
        string sumCorevalue = "";

        string A1 = "";
        string A2 = "";
        string A3 = "";
        string A4 = "";
        string sumALLA1_A4 = "";

        string _21st_CriticalThinkingProblemSolving = "";
        string _21st_CreativityInnovation = "";
        string _21st_CommunicationCollabration = "";
        string _21st_LeadershipManagementSkills = "";
        string _21st_Socialskill = "";
        string sumALL21st = "";
        string Orientation = "";
        string WaiKru = "";
        string Volunteer = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                
                _studentCode = _dr["studentCode"].ToString();
                _titleName = _dr["titleName"].ToString();
                _firstName = _dr["firstName"].ToString();
                _lastName = _dr["lastName"].ToString();
                _facultyCode = _dr["facultyCode"].ToString();
                _facultyNameTh = _dr["facNameTh"].ToString();
                _programCode = _dr["programCode"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _stsNameTh = _dr["stsNameTh"].ToString();
                _class = _dr["class"].ToString();
                _stsPassTh = _dr["stsPassTh"].ToString();
                _countAct = _dr["countAct"].ToString();

                Orientation = _dr["Orientation"].ToString();
                WaiKru = _dr["WaiKru"].ToString();
                Volunteer = _dr["Volunteer"].ToString();

                Health_Literacy = _dr["Health_Literacy"].ToString();
                Internationalization = _dr["Internationalization"].ToString();
                Digital_Literacy = _dr["Digital_Literacy"].ToString();
                Environmental_Literacy = _dr["Environmental_Literacy"].ToString();
                Financial_Literacy = _dr["Financial_Literacy"].ToString();
                sumHIDEF = _dr["sumHIDEF"].ToString();

                M = _dr["M"].ToString();
                A = _dr["A"].ToString();
                H = _dr["H"].ToString();
                I = _dr["I"].ToString();
                D = _dr["D"].ToString();
                O = _dr["O"].ToString();
                L = _dr["L"].ToString();
                sumCorevalue = _dr["sumCorevalue"].ToString();

                A1 = _dr["A1"].ToString();
                A2 = _dr["A2"].ToString();
                A3 = _dr["A3"].ToString();
                A4 = _dr["A4"].ToString();
                sumALLA1_A4 = _dr["sumALLA1_A4"].ToString();

                _21st_CriticalThinkingProblemSolving = _dr["21st_CriticalThinkingProblemSolving"].ToString();
                _21st_CreativityInnovation = _dr["21st_CreativityInnovation"].ToString();
                _21st_CommunicationCollabration = _dr["21st_CommunicationCollabration"].ToString();
                _21st_LeadershipManagementSkills = _dr["21st_LeadershipManagementSkills"].ToString();
                _21st_Socialskill = _dr["21st_Socialskill"].ToString();
                sumALL21st = _dr["sumALL21st"].ToString();

                _string.Append(@"<tr >
                                      <th scope = 'row' > " + (_i + 1).ToString() + @" </th>
                                      <td class='text-center'> " + _studentCode + @" </td>
                                      <td > " + _titleName + @" </td>
                                      <td nowrap='nowrap' > " + _firstName + @" </td>
                                      <td nowrap='nowrap' > " + _lastName + @" </td>
                                      <td > " + _facultyCode + @" </td>
                                      <td nowrap='nowrap' > " + _facultyNameTh + @" </td>
                                      <td > " + _programCode + @" </td>
                                      <td nowrap='nowrap' > " + _programNameTh + @" </td>
                                      <td nowrap='nowrap' > " + _stsNameTh + @" </td>
                                      <td class='text-center'> " + _class + @" </td>
                                      <td class='text-center'> " + _stsPassTh + @" </td>
                                      <td class='text-right'> " + _countAct + @" </td>
<td class='text-right'> " + Orientation + @" </td>
<td class='text-right'> " + WaiKru + @" </td>
<td class='text-right'> " + Volunteer + @" </td>
");
                if (_isExcel == "1")
                {
                    _string.Append(" <td class='text-center'> "+ Health_Literacy + " </td>");
                    _string.Append(" <td class='text-center'> " + Internationalization + " </td>");
                    _string.Append(" <td class='text-center'> " + Digital_Literacy + " </td>");
                    _string.Append(" <td class='text-center'> " + Environmental_Literacy + " </td>");
                    _string.Append(" <td class='text-center'> " + Financial_Literacy + " </td>");
                    _string.Append(" <td class='text-center'> " + sumHIDEF + " </td>");

                    _string.Append(" <td class='text-center'> " + M + " </td>");
                    _string.Append(" <td class='text-center'> " + A + " </td>");
                    _string.Append(" <td class='text-center'> " + H + " </td>");
                    _string.Append(" <td class='text-center'> " + I + " </td>");
                    _string.Append(" <td class='text-center'> " + D + " </td>");
                    _string.Append(" <td class='text-center'> " + O + " </td>");
                    _string.Append(" <td class='text-center'> " + L + " </td>");
                    _string.Append(" <td class='text-center'> " + sumCorevalue + " </td>");

                    _string.Append(" <td class='text-center'> " + A1 + " </td>");
                    _string.Append(" <td class='text-center'> " + A2 + " </td>");
                    _string.Append(" <td class='text-center'> " + A3 + " </td>");
                    _string.Append(" <td class='text-center'> " + A4 + " </td>");
                    _string.Append(" <td class='text-center'> " + sumALLA1_A4 + " </td>");

                    _string.Append(" <td class='text-center'> " + _21st_CriticalThinkingProblemSolving + " </td>");
                    _string.Append(" <td class='text-center'> " + _21st_CreativityInnovation + " </td>");
                    _string.Append(" <td class='text-center'> " + _21st_CommunicationCollabration + " </td>");
                    _string.Append(" <td class='text-center'> " + _21st_LeadershipManagementSkills + " </td>");
                    _string.Append(" <td class='text-center'> " + _21st_Socialskill + " </td>");
                    _string.Append(" <td class='text-center'> " + sumALL21st + " </td>");
                }
                _string.Append(" </tr>");
                _i += 1;
                                      //                <td > " + _a1Val + @" </td>
                                      //<td > " + _a2Val + @" </td>
                                      //<td > " + _a3Val + @" </td>
                                      //<td > " + _a4Val + @" </td>
                                      //<td class='text-right'> " + _sumAlla + @" </td>
                                      //<td > " + _mVal + @" </td>
                                      //<td > " + _aVal + @" </td>
                                      //<td > " + _hVal + @" </td>
                                      //<td > " + _iVal + @" </td>
                                      //<td > " + _dVal + @" </td>
                                      //<td > " + _oVal + @" </td>
                                      //<td > " + _lVal + @" </td>
                                      //<td class='text-right'> " + _sumAllCoreValue + @" </td>
            }
        }
        _string.Append(@"       </tbody>
                               </table>
                             ");

        return _string.ToString();
    }


    public static string resultRptHidefSummary(string _facultyId, string _programId, string _studyYear, string _isExcel)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRptHidefSummary(_facultyId, _programId, _studyYear);

        int _count = _ds.Tables[0].Rows.Count;

        _string.Append("<h4 class='page-header' style='color:darkblue;' class='text-center'>Literacy HIDEF</h4>");
        _string.Append("<div id='divGraphHidefSummary' style='min-width: 500px; max-width: 600px; height: 350px; margin: 0 auto'></div>");
        _string.Append(@"
                          <table id='tblRptStd2' class='table table-bordered'>
                          <thead>
                            <tr class='bg-info' >
                                <th class='col-sm-1 text-center' style='background-color:#D4FAFD;font-weight:bold;' align='center'>ลำดับ</th>
                                <th class='text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > รายละเอียดตัวชี้วัดไทย </th>
                                <th class='text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > รายละเอียดตัวชี้วัดอังกฤษ </th>
                                <th class='col-sm-1 text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > จำนวนชั่วโมง </th>
                           </tr>
                          </thead>
                          <tbody >");
        int _i = 0;
        string _subIndicatorNameTh = "";
        string _subIndicatorNameEn = "";
        string _sumHours = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _subIndicatorNameTh = _dr["subIndicatorNameTh"].ToString();
                _subIndicatorNameEn = _dr["subIndicatorNameEn"].ToString();
                _sumHours = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHours"]));


                _string.Append(@"<tr >
                                      <th scope = 'row' class='text-center'> " + (_i + 1).ToString() + @" </th>
                                      <td class='text-left'> " + _subIndicatorNameTh + @" </td>
                                      <td class='text-left'> " + _subIndicatorNameEn + @" </td>
                                      <td class='text-right'> " + _sumHours + @" </td>
                                 </tr>");
                _i += 1;
            }
        }
        _string.Append(@"       </tbody>
                               </table>
                             ");

        return _string.ToString();
    }

    public static string get21stGraphSummary(string _facultyId, string _programId, string _studyYear)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRpt21StSummary(_facultyId, _programId, _studyYear); 
        string _abbrevEn = "", _hours = "";
        DataTable _dt = new DataTable();
        int _i = 0;

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _abbrevEn = _dr["subIndicatorNameEn"].ToString();
                _hours = _dr["sumHours"].ToString();
                _result.name[_i] = _abbrevEn ;
                _result.data[_i] = Convert.ToDouble(_hours);
                _i++;

            }
        }

        return JsonConvert.SerializeObject(_result);
    }

    public static string getHidefGraphSummary(string _facultyId, string _programId, string _studyYear)
    {
        Result _result = new Result();
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRptHidefSummary(_facultyId, _programId, _studyYear);
        string _abbrevEn = "", _hours = "";
        DataTable _dt = new DataTable();
        int _i = 0;

        if (_ds.Tables[0].Rows.Count > 0)
        {

            _result.name = new string[_ds.Tables[0].Rows.Count];
            _result.data = new double[_ds.Tables[0].Rows.Count];
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {

                _abbrevEn = _dr["subIndicatorNameEn"].ToString();
                _hours = _dr["sumHours"].ToString();
                _result.name[_i] = _abbrevEn;
                _result.data[_i] = Convert.ToDouble(_hours);
                _i++;

            }
        }

        return JsonConvert.SerializeObject(_result);
    }


    public static string RptTransectionRequestDoc(string _studentYear, string _facultyId, string _programId, string _studentCode, string _statusRequest)
    {
        DataSet _ds = ActDB.getListATForPrint(_studentYear, _facultyId, _programId, _studentCode, _statusRequest);
        int _i = 1;
        int _count = _ds.Tables[0].Rows.Count;
        StringBuilder _string = new StringBuilder();


        _string.Append(@" 
                    <table  >
        
                    <tr>
                    <td align='center' style='width:80px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    ลำดับ
                    </td>
                    <td align='center' style='width:110px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    รหัสนศ.
                    </td>
                    <td align='center' style='width:270px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    ชื่อ-นามสกุล
                    </td>
                    <td align='center' style='width:410px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    คณะ
                    </td>
                    <td align='center' style='width:540px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    หลักสูตร
                    </td>
                    <td align='center' style='width:220px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    สถานะผ่านเกณฑ์ AT
                    </td>
                    <td align='center' style='width:180px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    สถานะ Request
                    </td>
                    <td align='center' style='width:310px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    เหตุผลการ Request
                    </td>
                    <td align='center' style='width:220px;border:1px solid gray;background-color:#F7FDC2;font-weight:bold;'>
                    วันที่ Request
                    </td>
                    </tr>
          ");

        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _string.Append(@"    <tr 
                                        <td align='center' style='border:1px solid gray;'>
                                         " + _i.ToString() + @"
                                        </td>
                                        <td align='center' style='border:1px solid gray;'>
                                         " + _dr["studentCode"] + @"
                                        </td>
                                        <td style='border:1px solid gray;'>
                                         " + _dr["firstName"] + " " + _dr["lastName"] + @"
                                        </td>
                                        <td style='border:1px solid gray;'>
                                         " + _dr["facultyCode"] + " - " + _dr["facultyNameTh"] + @"
                                        </td>
                                        <td style='border:1px solid gray;'>
                                         " + _dr["programNameTh"] + @"
                                        </td>
                                        <td align='center' style='border:1px solid gray;'>
                                         " + _dr["stsPassTh"] + @"
                                        </td>
                                        <td align='center' style='border:1px solid gray;'>
                                         " + _dr["statusRequestName"] + @"
                                        </td>
                                        <td align='left' style='border:1px solid gray;'>
                                         " + _dr["requestReason"] + @"
                                        </td>
                                        <td align='center' style='border:1px solid gray;'>
                                         " + _dr["requestDate"] + @"
                                        </td>
                                        </tr>
                                        ");
                _i++;
            }

        }
        else
        {
            _string.Append(@"
                <tr >
                <td colspan='7' align='center'>
                    ไม่พบรายการ
                </td>
                </tr>
                ");
        }
        _string.Append("</table>");
        return _string.ToString();
    }


    public static string resultRpt21StSummary(string _facultyId, string _programId, string _studyYear, string _isExcel)
    {
        StringBuilder _string = new StringBuilder();
        DataSet _ds = ActDB.getListRpt21StSummary(_facultyId, _programId, _studyYear);

        int _count = _ds.Tables[0].Rows.Count;

        _string.Append("<h4 class='page-header' style='color:darkblue;' class='text-center'>Literacy 21st Century skill</h4>");
        _string.Append("<div id='divGraph21stSummary' style='min-width: 500px; max-width: 600px; height: 350px; margin: 0 auto'></div>");
        _string.Append(@"
                          <table id='tblRptStd3' class='table table-bordered'>
                          <thead>
                            <tr class='bg-info' >
                                <th class='col-sm-1 text-center' style='background-color:#D4FAFD;font-weight:bold;' align='center'>ลำดับ</th>
                                <th class='text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > รายละเอียดตัวชี้วัดไทย </th>
                                <th class='text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > รายละเอียดตัวชี้วัดอังกฤษ </th>
                                <th class='col-sm-1 text-center' style='background-color:#D4FAFD;font-weight:bold;' nowrap='nowrap' align='center' > จำนวนชั่วโมง </th>
                           </tr>
                          </thead>
                          <tbody >");
        int _i = 0;
        string _subIndicatorNameTh = "";
        string _subIndicatorNameEn = "";
        string _sumHours = "";
        if (_count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _subIndicatorNameTh = _dr["subIndicatorNameTh"].ToString();
                _subIndicatorNameEn = _dr["subIndicatorNameEn"].ToString();
                _sumHours = String.Format("{0:#,##0}", Convert.ToDouble(_dr["sumHours"]));


                _string.Append(@"<tr >
                                      <th scope = 'row' class='text-center'> " + (_i + 1).ToString() + @" </th>
                                      <td class='text-left'> " + _subIndicatorNameTh + @" </td>
                                      <td class='text-left'> " + _subIndicatorNameEn + @" </td>
                                      <td class='text-right'> " + _sumHours + @" </td>
                                 </tr>");
                _i += 1;
            }
        }
        _string.Append(@"       </tbody>
                               </table>
                             ");

        return _string.ToString();
    }


}