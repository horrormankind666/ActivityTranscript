<%@ WebHandler Language="C#" Class="actApproveHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Net.Http;

public class actApproveHandler : IHttpHandler {
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
            case "LoadFillterProjectForApprove":
                LoadFillterProjectForApprove();
                break;
            case "getListProjectForApprove":
                getListProjectForApprove();
                break;
            case "setApproveProject":
                setApproveProject();
                break;
            case "getListDetailForSendmail":
                getListDetailForSendmail();
                break;
            case "SendMailProjectCreator":
                SendMailProjectCreator();
                break;

        }

    }

    public void SendMailProjectCreator()
    {
        string txtAcaYear = _c.Request["txtAcaYear"];
        string txtProjectNameTh = _c.Request["txtProjectNameTh"];
        string txtInstituteNameTh = _c.Request["txtInstituteNameTh"];
        // string txtCreateDateTh = _c.Request["txtCreateDateTh"];
        string txtCreatedBy = _c.Request["txtCreatedBy"];
        string txtRemark = _c.Request["txtRemark"];
        string projectid = _c.Request["projectid"];
            
        using (SmtpClient client = new SmtpClient())
        {
            string _email = txtCreatedBy + "@mahidol.ac.th";
            //string _email = "jate.khr@mahidol.ac.th";
            DateTime dateNow = DateTime.Now;
            DateTime expiryDate = dateNow.AddDays(30);
            client.Host = "mumail.mahidol.ac.th";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("noreply_idev@mahidol.ac.th", "uyo4ppao");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply_idev@mahidol.ac.th", "Activity Transcript");
            mail.To.Add(_email);
            //mail.CC.Add(_email); 
            mail.Subject = "[MAHIDOL UNIVERSITY][Activity Transcript] โปรดพิจารณาแก้ไขรายละเอียดโครงการของท่านในระบบ Activity Transcript";
            mail.IsBodyHtml = true;
            mail.Body =  "<h3>Dear "+ txtCreatedBy + "</h3>";

            mail.Body += @"<p style='text-indent: 50px;'>ตามที่ท่านได้สร้างข้อมูลโครงการ " +
                " '"+ txtProjectNameTh +"' ของภาคการศึกษาที่ "+ txtAcaYear + " ในระบบบันทึกกิจกรรมเสริมหลักสูตร (Activity Transcript) นั้น เนื่องจากโครงการดังกล่าว ยังมีข้อมูลไม่ถูกต้องครบถ้วนนั้น";
            mail.Body += "<p style='text-indent: 50px;'>ในการนี้เพื่อให้ข้อมูลโครงการดังกล่าวมีความสมบูรณ์ครบถ้วน และสอดคล้องตามประกาศที่มหาวิทยาลัยกำหนด จึงใคร่ขอให้ท่านดำเนินการแก้ไข ดังนี้</p>";
            mail.Body += "<p style='text-indent: 50px;'> "+txtRemark+" </p>";
            mail.Body += "<p >โดยขอให้ท่านดำเนินการแก้ไขรายละเอียดโครงการให้แล้วเสร็จภายในวันที่ " + dateNow.AddDays(30).ToString("dd/MM/yyyy") + "</p>";
            mail.Body += "<p >* หากท่านไม่ได้ดำเนินการภายในวันดังกล่าว โครงการของท่านจะถูกยกเลิก โดยท่านจะไม่สามารถดำเนินการแก้ไขโครงการดังกล่าวได้ หากท่านมีข้อสงสัยเพิ่มติมกรุณาติดต่อเจ้าหน้าที่ดูแลระบบ 02-849-4527</p>";
            mail.Body += "<p style='text-indent: 50px;'>จึงเรียนมาเพื่อโปรดดำเนินการดังกล่าวด้วย จะเป็นพระคุณยิ่ง</p>";
            mail.Body += "<br>";
            mail.Body += "<p style='text-indent: 500px;'>เจ้าหน้าที่ดูแลระบบ</p>";
            //Encode เนื้อหา Email ให้อักขระเป็นไทย
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("Windows-874");
            client.Send(mail);

            // บันทึกการส่งอีเมล์ในฐานข้อมูลเป็น Log แล้วจะปรับสถานะโครงการจากที่ 
            ActDB.setProjectSendMail(projectid,txtRemark,expiryDate,_username,txtCreatedBy);

        }

        _c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
    }


    public void getListDetailForSendmail()
    {
        string projectId = _c.Request["projectId"];
        string _html = ActUI.getListDetailForSendmail(projectId);

        string _data = @" <div >
                    <div class='modal-dialog'>
                                
                    <div class='modal-content'>
                        <div class='modal-header'>
                        <button type='button' class='close' data-dismiss='modal'>&times;</button>
                        <h4 class='modal-title'>บริหารจัดการแจ้งอีเมลถึงผู้สร้างโครงการของส่วนงาน</h4>
                        </div>
                        <div class='modal-body'>
                        <p>" + _html + @"
                            <div class='row'>
                                <div class='form-group col-xs-12  text-center '>
                                    <button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk btnSetSendMail'> บันทึก</button>
                                    <button type='button' class='btn btn-danger glyphicon glyphicon-remove btnCloseDiv' > ยกเลิก</button>
                                </div>
                            </div>
                        </p>
                        </div>
                       
                    </div>

                    </div>
                </div>";
        _c.Response.Write(_data);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 22 มิ.ย. 2560
    /// Perpose: 
    /// Method : setApproveProject
    /// Sample : N/A
    public void setApproveProject()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _projectid = _c.Request["projectid"];
        //string _username = "jate.khr";
        ActDB.setApproveProject(_projectid,_username);
        _c.Response.Write(_returnText);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 22 มิ.ย. 2560
    /// Perpose: 
    /// Method : getListProjectForApprove
    /// Sample : N/A
    public void getListProjectForApprove()
    {
        string _acaYear = _c.Request["acaYear"];
        string _semester = _c.Request["semester"];
        string _facultyId = _c.Request["facultyId"];
        string _projectStatusId = _c.Request["projectStatusId"];
        string _html = ActUI.getListProjectForApprove(_acaYear, _semester, _facultyId, _projectStatusId);
        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 22 มิ.ย. 2560
    /// Perpose: 
    /// Method : LoadFillterProjectForApprove
    /// Sample : N/A
    public void LoadFillterProjectForApprove()
    {
        string _html = ActUI.LoadFillterProjectForApprove(_facultyIdPermission);
        _c.Response.Write(_html);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}