using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_student_studentPublicEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.StylesRegister("Bootstrap", "DataTable", "ActivityTranscript");
        Page.ScriptsRegister("Bootstrap", "DataTable", "ActivityTranscript");

        string _projectId = Request["projectId"];
        string _statusPublicEvent = Request["statusPublicEvent"];
        hddStatusPublicEvent.Value = _statusPublicEvent;
        
        //string _publicEventName = Request["publicEventName"];
        //string _ddlFaculty = Request["ddlFaculty"];
        //string _dateStart = Request["dateStart"];
        //string _dateEnd = Request["dateEnd"];
        //string _ddlProjectStatus = Request["ddlProjectStatus"];


        Login _login = new Login("student");
        string _studentId = _login.StudentId;

        // รุ่น แบบชี้วัดประเภท TQF(A1-A4)
        //_login.Authen = "true";
        //_studentId = "STD255200804";
        //_login.StudentCode = "5205093";

        // แบบชี้วัดประเภท MAHIDOL CORE VALUES
        //_studentId = "STD256103465";
        //_login.StudentCode = "6113299";

        // แบบชี้วัดประเภท Mahidol HIDEF
        //_studentId = "STD256203796";
        //_login.StudentCode = "6207053";

        //_studentId = "STD255988015";
        //_login.StudentCode = "5988015";

        //_studentId = "STD256000019";
        //_login.StudentCode = "6027039";


        // ผ่าน // ของปี 2565
        //_studentId = "STD256500108";
        //_login.StudentCode = "6502053";


        //_studentId = "STD256400322";
        //_login.StudentCode = "6401002";

        //_login.FullNameTh = "นาย ทดสอบ ระบบนะ";

        //_login.Authen = "true";

        hddStudentCode.Value = _login.StudentCode;
        string _htmlSieMenu = "";
        divProfile.InnerHtml += @"<table ><tr><td align='right' style = 'padding-right: 25px;'> <b class='h5'><a class='nav-link bg-hover-darkCobalt btnTh' href='javascript:void(0);' onclick=chkIsLangTh('1');>
                                   <img class='flag flag-th on-left' src='../../images/thai.png' /> Thai</a>
                                   </b>
                                   <b class='h5'><a class='nav-link bg-hover-darkCobalt btnEn' href='javascript:void(0);' onclick=chkIsLangTh('0');>
                                   <img class='flag flag-en on-left' src='../../images/eng.png' /> English</a></b>
                                   </td></tr>";

        if (_login.Authen == "true")
        {

            ////DateTime dateNow = DateTime.Now;
            ////// สำหรับหาปีการศึกษา academicYear
            ////string yearBE = string.Empty;
            ////if (dateNow.Month >= 8)
            ////{
            ////    yearBE = (dateNow.Year + 543).ToString();
            ////}
            ////else 
            ////{
            ////    yearBE = (dateNow.Year + 542).ToString();
            ////}

            //////////yearBE = "2565";
            ///////
            ////// ต้องมาเอาในส่วนของคอมเม้นต์ตรงนี้ออก เรื่อง WE SPACE

            ////// ไปตรวจสอบก่อนว่าในตาราง actTransStudentSurvey มีข้อมูลการประเมินหรือยัง ถ้ามีแล้วเข้าระบบได้เลย ถ้าไม่มีให้ไปประเมินก่อน
            ////DataSet _dsChk = ActDB.getCheckStudentSurveyWeSpace(_studentId, yearBE);
            ////if (_dsChk.Tables[0].Rows.Count == 0) // ถ้า = 0  คือยังไม่มีการประเมินให้ไปประเมินที่ระบบ Wespace ก่อนเลย
            ////{
            ////    // 4 ธ.ค. 65 ยิง API ของ Wespace เพื่อ Insert ข้อมูลลงตาราง actTransStudentSurvey กรณีมีการประเมินแล้ว
            ////    string url = "https://wespace-dashboard.mahidol.ac.th/api/student?studentCode=u" + _login.StudentCode + "&academicYear=" + yearBE;
            ////    HttpClient httpClient = new HttpClient();
            ////    httpClient.BaseAddress = new Uri(url);

            ////    HttpRequestMessage request = new HttpRequestMessage();
            ////    request.Method = HttpMethod.Get;

            ////    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            ////    request.Headers.Add("x-api-key", "MsoFlY6abRmhdnE8H6RAYwFslBEhKuAU");
            ////    //request.Headers.Add("Token", token);
            ////    var response = httpClient.SendAsync(request);

            ////    if (response.Result.IsSuccessStatusCode) // ตรวจสอบสถานะ Call API ผ่าน
            ////    {
            ////        var result = "[" + response.Result.Content.ReadAsStringAsync().Result + "]";
            ////        var dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(result);
            ////        ActDB.setStudentSurveyAPI(dataList, _studentId);
            ////    }
            ////    // จบ Call API

            ////    // หลังจากยิง- API แล้วก็จะตรวจสอบอีกทีให้เลยว่ามีประเมินหรือยัง? ถ้ายังก็จะ Redirect ไปหน้าระบบวีสเปลชเลย
            ////    _dsChk = ActDB.getCheckStudentSurveyWeSpace(_studentId, yearBE);
            ////    if (_dsChk.Tables[0].Rows.Count == 0)
            ////    {
            ////        //Response.Write("<script language=javascript>alert('นักศึกษาต้องเข้าประเมินแบบประเมินที่ระบบ https://wespace.mahidol.ac.th ก่อนเข้าระบบ Activity Transcript');</script>");
            ////        Response.Redirect("Notification.aspx");
            ////    }
            ////}



            string stdNameTh = string.Empty;
            string stdNameEn = string.Empty;
            DataSet _ds = ActDB.getListStudentByCode(_login.StudentCode);
            DataRow[] _drRow = _ds.Tables[0].Select();
            int _row = _drRow.Length;
            if (_row > 0)
            {
                for (int _i = 0; _i < _row; _i++)
                {
                    stdNameTh = _drRow[_i]["fullNameTh"].ToString();
                    stdNameEn = _drRow[_i]["fullNameEn"].ToString();
                }
            }

            divProfile.InnerHtml+= @"<tr><td> 
                                     <b class='h4'> <span class='glyphicon glyphicon-user' style='color:darkblue;'  ></span> " + _login.StudentCode+ @"</b>
                                     <b class='h5' style = 'padding-right: 25px;'><span class='th'>" + stdNameTh + "</span><span class='en'>"+ stdNameEn + "</span></b></td></tr>";

            _htmlSieMenu = @"       <li style = 'padding-top: 3px;'>
                                        <a href='#' class='h5 btnGetListActivitiesOnline' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-check '></i> <span class='th'>กิจกรรมที่สมัครออนไลน์</span><span class='en'>Online App activities</span></a>
                                    </li>
                                    <li style = 'padding-top: 3px;'>
                                        <a href='#' class='h5 btnGetListActivitiesByStudent' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-map-marker '></i> <span class='th'>กิจกรรมที่เข้าร่วม</span><span class='en'>Participating activities</span></a>
                                     </li>

                                     <li style = 'padding-top: 3px;'>
                                        <a href='#' class='h5 btnGetListActSchorlarShipByStudent' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-piggy-bank'></i> <span class='th'>กิจกรรมยื่นกู้ กยศ./กรอ.</span><span class='en'>Recovery activities</span></a>
                                    </li>  ";
            // ไว้เปิดปิด เมนู ยื่นคำร้องขอใบ AT ตามกองกิจ ร้องขอ
            _htmlSieMenu += @"<li style = 'padding-top: 3px;'>";
            _htmlSieMenu += @" <a href='#' class='h5 btnRequestAT' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-copy'></i> <span class='th'>ยื่นคำร้องขอใบ AT</span><span class='en'>Request AT</span></a>";
            _htmlSieMenu += @"</li>   ";

            //<li style = 'padding-top: 3px;'>
            //         <a href='#' class='h5 btnPrintActivityTranscript' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-print'></i> <span class='th'>พิมพ์ Activity Transcript</span><span class='en'>Print Activity Transcript</span></a>
            //  </li>   


            //sidebar-wrapper
        }
        else
        {
            divProfile.InnerHtml += @"<tr><td> <a style = 'padding-right: 25px;font-size:18px;'  href='https://smartedu.mahidol.ac.th/authen/login.aspx'><b >Sign up</b></a></td></tr>";
        }
        divProfile.InnerHtml += @"</table>";

        divSidebarWrapper.InnerHtml = @" <ul class='sidebar-nav navbar navbar-default' >
                                             <li style = 'padding-top: 8px;' >
                                                  <h4> &nbsp;<span class='th'>ประเภทกิจกรรม</span><span class='en'>Type of Activity</span> </h4>
                                                  <hr>
                                             <li style = 'padding-top: 3px;' >
                                                <a href = 'studentPublicEvent.aspx?statusPublicEvent=1' class='h5' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-bullhorn'></i> <span class='th'>กิจกรรมที่เปิดรับสมัคร</span><span class='en'>Recruitment activities</span></a>
                                             </li>
                                             <li style = 'padding-top: 3px;' >
                                                <a href = 'studentPublicEvent.aspx?statusPublicEvent=0' class='h5' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-bell'></i> <span class='th'>กิจกรรมใหม่</span><span class='en'>New activity</span> <span class='label label-success'>New</span></a>
                                             </li>
                                            " + _htmlSieMenu + @"
                                            <li style = 'padding-top: 3px;' >
                                                  <a href= '#' class='h5 btnLoadContractUs ' style='color:Black;font-size:16px;'><i class='glyphicon glyphicon-phone-alt'></i> <span class='th'>ติดต่อเรา</span><span class='en'>Contact us</span></a> 
                                            </li>
                                            <li style = 'padding-top: 3px;'>
                                                <hr>
                                            </li>
                                            <li style = 'padding-top: 15px;'>
                                                <a href = 'https://op.mahidol.ac.th/sa/' target='_blank'>
                                                    <img style = 'width: 210px; height: 60px;' class='img-thumbnail' alt='Responsive image' src='../../images/logo_Kongkid.png' /></a>
                                            </li>
                                            <li style = 'padding-top: 15px;'>
                                                <a href='https://iptv.mahidol.ac.th/mu-must-know' target='_blank'>
                                                    <img style = 'width: 210px; height: 60px;' class='img-thumbnail' alt='Responsive image' src='../../images/mu-must-know-logo.jpg' /></a>
                                            </li>
                                        </ul> ";


        if ((_projectId != null) && (_projectId != ""))
        {
            //    txtPublicEventName.Value = _publicEventName;

             divMainDisplay.InnerHtml = ActStdUI.getListProjectDetailPublic(_projectId, _studentId, "", "", "", "", "");
          }
            // Response.Write(_projectId);
        }
}