using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Common;

using System.Net.Mail;
using System.Net;
//using System.Web.Mail;



/// <summary>
/// Summary description for MyConfig
/// Author : Thanakrit.tae
/// Create date : 2014-02-12
/// Description : สร้าง Function ในการทำงานที่มีการเรียกใช้บ่อยๆ และเหมือนกัน
/// </summary>
public class MyConfig
{
    
	public MyConfig()
	{
		//
		// TODO: Add constructor logic here
		//
       
	}

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : ExecuteDb()
    /// Param : string _query=คำสั่ง SQL Command
    /// Description : เชื่อมต่อฐานข้อมูลเพื่อ Run Query 
    /// </summary>
    public static DataSet ExecuteDb(string _query)
    {
   
        SqlDataAdapter _adp = new SqlDataAdapter(_query, MyConfig.GetConnect());
        DataSet _ds = new DataSet();
        
        
        _adp.Fill(_ds);
        return _ds;

    }
    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : ExecuteCmd()
    /// Param : string _query=คำสั่ง SQL Command
    /// Description : เชื่อมต่อฐานข้อมูลเพื่อ Run Command Query
    /// </summary>
    public static int ExecuteCmd(string _query)
    {
        SqlConnection _conn = MyConfig.GetConnect();
        SqlCommand _cmd = new SqlCommand(_query, _conn);
        _conn.Open();
        int _result = _cmd.ExecuteNonQuery();
        _conn.Close();
        _cmd.Dispose();
        _conn.Dispose();
        return _result;

    }
    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetConnect()
    /// Param : n/a
    /// Description : ใช้สำหรับเชื่อมต่อกับฐานข้อมูล
    /// </summary>
    /// <returns></returns>
    public static SqlConnection GetConnect()
    {
        SqlConnection _con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnect"].ToString());
        return _con;
    }
    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetJQuery()
    /// Param : n/a
    /// Description : เรียกใช้เมื่อต้องการ การเขียนโปรแกรมแบบ jQuery เป็นการเพิ่ม ref ของ css/javascript
    /// </summary>
    /// <returns></returns>
    public static void GetJQuery(Page _page)
    {
        //string _path = _page.Server.MapPath("/EducationService");
        string _path = GetVirtualPath();
        string _webLogo = "<link rel='shortcut icon' href='" + _path + "/image/bootstrap/logo.png' />";
        string _css = "<link href='" + _path + "/css/jquery-ui-1.10.3.custom/blitzer/jquery-ui-1.10.3.custom.css' rel='stylesheet' type='text/css' />";
        string _jsMin = "<script src='" + _path + "/js/jquery-ui-1.10.3.custom/jquery-1.9.1.js' type='text/javascript'></script>";
        string _jsUi = "<script src='" + _path + "/js/jquery-ui-1.10.3.custom/jquery-ui-1.10.3.custom.min.js' type='text/javascript'></script>";
        _page.Header.Controls.Add(new LiteralControl(_webLogo));
        _page.Header.Controls.Add(new LiteralControl(_css));
        _page.Header.Controls.Add(new LiteralControl(_jsMin));
        _page.Header.Controls.Add(new LiteralControl(_jsUi));

    }
    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetBoostrap()
    /// Param : n/a
    /// Description : เรียกใช้เมื่อต้องการ การเขียนโปรแกรม user interface แบบ bootstrap และ jQuery เป็นการเพิ่ม ref ของ css/javascript
    /// </summary>
    /// <returns></returns>
    public static void GetBoostrap(Page _page)
    {
        string _path = GetVirtualPath();
        string _webLogo="<link rel='shortcut icon' href='" + _path + "/image/bootstrap/logo.png' />";
        string _bootstap = "<link href='" + _path + "/css/bootstrap/bootstrap.css' rel='stylesheet' />";
        string _bootstapCustomize = "<link href='" + _path + "/css/bootstrap/bootstrap-customize.css' rel='stylesheet' />";
        string _jquery = "<script src='" + _path + "/js/jquery-ui-1.10.3.custom/jquery-1.9.1.js' type='text/javascript'></script>";
        string _jqueryMigrate = "<script type='text/javascript' src='" + _path + "/js/bootstrap/jquery-migrate-1.2.1.min.js'></script>";
        string _jqueryBootstrap = "<script type='text/javascript' src='" + _path + "/js/bootstrap/bootstrap.min.js'></script>";
        string _jqueryCss = "<link href='" + _path + "/css/jquery-ui-1.10.3.custom/flick/jquery-ui-1.10.3.custom.css' rel='stylesheet' type='text/css' />";
        string _jqueryUi = "<script src='" + _path + "/js/jquery-ui-1.10.3.custom/jquery-ui-1.10.3.custom.min.js' type='text/javascript'></script>";
        string _myJs = "<script src='" + _path + "/js/MyScript.js' type='text/javascript'></script>";

        _page.Header.Controls.Add(new LiteralControl(_webLogo));
        _page.Header.Controls.Add(new LiteralControl(_jqueryCss));
        _page.Header.Controls.Add(new LiteralControl(_bootstap));
        _page.Header.Controls.Add(new LiteralControl(_bootstapCustomize));
        _page.Header.Controls.Add(new LiteralControl(_jquery));
        _page.Header.Controls.Add(new LiteralControl(_jqueryMigrate));
        _page.Header.Controls.Add(new LiteralControl(_jqueryBootstrap));
        _page.Header.Controls.Add(new LiteralControl(_jqueryUi));
        _page.Header.Controls.Add(new LiteralControl(_myJs));
    }
    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetTimePicker()
    /// Param : n/a
    /// Description : Ref File Css and JavaScript For TimePicker
    /// </summary>
    /// <returns></returns>
    public static void GetTimePicker(Page _page)
    {
        string _path = GetVirtualPath();
        string _jqueryTimepickerCss = "<link href='" + _path + "/js/jquery-ui-timepicker-0.3.3/jquery.ui.timepicker.css' rel='stylesheet' type='text/css' />";
        string _jqueryTimepicker = "<script src='" + _path + "/js/jquery-ui-timepicker-0.3.3/jquery.ui.timepicker.js' type='text/javascript'></script>";


        _page.Header.Controls.Add(new LiteralControl(_jqueryTimepickerCss));
        _page.Header.Controls.Add(new LiteralControl(_jqueryTimepicker));
    }



    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetVirtualPath()
    /// Param : n/a
    /// Description : สำหรับต้องการ path เริ่มต้นของ application ที่พัฒนาอยู่
    /// </summary>
    /// <returns></returns>
    public static string GetVirtualPath()
    {
        string _path = HttpContext.Current.Request.ApplicationPath.ToString();
        if (_path == "/")
        {
            _path = "";

        }
        return _path;
    }

    



    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : UIBanner()
    /// Param : n/a
    /// Description : สร้าง HTML ฟอร์ม Banner ในส่วนหัวบนสุด
    /// </summary>
    /// <returns></returns>
    public static string UIBanner()
    {
        string _path = GetVirtualPath();
        StringBuilder _xml = new StringBuilder();
        _xml.Append("<div class='jumbotronstd' style='background-image: url(" + _path + "/image/bootstrap/jumbotron3.png);'>");
        _xml.Append("   <div class='container'>");
        _xml.Append("<img src='" + _path + "/image/bootstrap/logo-mu.png' alt='logo' class='img-rounded' />");
        _xml.Append("   </div>");
        _xml.Append("</div>");

        return _xml.ToString();
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : UIFooter()
    /// Param : n/a
    /// Description : สร้าง HTML ฟอร์ม Footer ส่วนล่างสุดของ webpage
    /// </summary>
    /// <returns></returns>
    public static string UIFooter()
    {
        string _path = GetVirtualPath();
        StringBuilder _xml = new StringBuilder();
        _xml.Append("<hr /><footer>");
        _xml.Append("            <span class='footer'>");
        _xml.Append("                <span>&copy; หน่วยพัฒนาระบบนักศึกษา กองเทคโนโลยีสารเทศ มหาวิทยาลัยมหิดล 2014</span>");
        _xml.Append("                <span class='pull-right'>");
        _xml.Append("                    <a href='#'>");
        _xml.Append("                        <img src='" + _path + "/image/bootstrap/glyphicons_social_30_facebook.png' /></a>");
        _xml.Append("                    <a href='#'>");
        _xml.Append("                        <img src='" + _path + "/image/bootstrap/glyphicons_social_31_twitter.png' /></a>");
        _xml.Append("                    <a href='#'>");
        _xml.Append("                        <img src='" + _path + "/image/bootstrap/glyphicons_social_02_google_plus.png' /></a>");
        _xml.Append("                </span>");
        _xml.Append("            </span>");
        _xml.Append("        </footer>");
        return _xml.ToString();
    }

 

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : ConvertText()
    /// Param : _source=ต้นฉบับ, _default=ค่าเริ่มต้น
    /// Description : ฟังก์ชั่น ตรวจสอบค่าว่างในตัวแปร _source แล้วให้แสดงผลเป็นค่าที่ต้องการ _default
    /// </summary>
    /// <returns></returns>
    public static string ConvertText(string _source, string _default)
    {
        string _str = _source;
        if (_source == null || _source == "" || _source == "0")
        {

            _str = _default;
        }


        return _str;
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : SwapText()
    /// Param : _index=ลำดับ,_text1=ข้อความแรก,_text2=ข้อความที่สอง
    /// Description : ฟังก์ชั่น ในการเลือกใช้ข้อความแรก เมือลำดับเป็นเลขคู่ หรือข้อความที่สอง เมื่อลำดับเป็นเลขคี่
    /// </summary>
    /// <returns></returns>
    public static string  SwapText(int _index,string _text1,string _text2){
        string _text = _text2;
        if (_index % 2 == 0)
        {
            _text = _text1;
        }

        return _text;
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : AbbrevText()
    /// Param : string _str=ข้อความ, int _maxLength=ความยาว
    /// Description : ตัดคำตามที่กำหนด
    /// </summary>
    /// <returns></returns>
    public static string AbbrevText(string _str, int _maxLength)
    {
        string _result;
        int _strLen = _str.Length;
        int _prevLen = _maxLength / 5;
        if (_strLen <= _maxLength)
        {
            _result = _str;
        }
        else
        {

            _result = _str.Substring(0, _maxLength - _prevLen +3) + "..." + _str.Substring(_strLen - _prevLen);
        }

        return _result;
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : EscapeText()
    /// Param : string _str=ข้อความ
    /// Description : แปรงข้อความให้อยู่ในรูปแบบเข้ากันได้กับคำสั่ง SQL
    /// </summary>
    /// <returns></returns>
    public static string EscapeText(string _str)
    {
        _str = _str.Replace("'", "''");


        return _str;
    }

    public static string HtmlEncode(string _str)
    {
        if (_str != null)
        {
           // _str = _str.Replace("&", " &#38; ");

            _str = _str.Replace("#", " &#35; ");
            _str = _str.Replace("'", " &#39; ");
            _str = _str.Replace("+", " &#43; ");
            _str = _str.Replace("%", " &#37; ");

        }
        return _str;

    }


    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : ToNumber()
    /// Param : string _str=ข้อความ
    /// Description : รูปแบบจำนวนตัวเลข
    /// </summary>
    /// <returns></returns>
    public static string ToNumber(string _str)
    {
        string _ans;
        if (_str == "" || _str == null)
            _str = "0";

        try{
            _ans = String.Format("{0:0}", Convert.ToDouble(_str));
        }catch{
            _ans = _str;
        }

        return _ans;

    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : ToCurrency()
    /// Param : string _str=ข้อความ
    /// Description : รูปแบบจำนวนเงิน ไม่มีทศนิยม
    /// </summary>
    /// <returns></returns>
    public static string ToCurrency(string _str)
    {
        string _ans;
        if (_str == "" || _str == null)
            _str = "0";

        try
        {
            _ans = String.Format("{0:0,0}", Convert.ToDouble(_str));
            if (_ans == "00")
                _ans = "0";


        }
        catch
        {
            _ans = _str;
        }



        return _ans;
       

    }


    /// <summary>
    /// Auther : Nopparat.j (Original-Thanakrit)
    /// Date   : 2014-03-20.
    /// Perpose: แปลงภาษาไทยให้เป็นแอสกี้
    /// Method : convertAscii
    /// Sample : "Nopparat.jap","XXX"
    /// </summary>
    public static string ConvertAscii(string _string)
    {
        string _x = string.Empty;
        if (_string != null && _string != "")
        {
            Encoding enc = Encoding.GetEncoding("tis-620");
            byte[] _arrByte = enc.GetBytes(_string.ToCharArray());
            foreach (byte _b in _arrByte)
            {
                _x += _b.ToString() + "@#@";
            }
        }
        return _x;
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : SendMail()
    /// Param : string _mail=เมล์ที่ส่ง, string _subject=เรื่อง, string _body=เนื้อหา
    /// Description : ส่งจดหมาย
    /// </summary>
    /// <returns></returns>
    public static void SendMail(string _mail, string _subject, string _body)
    {
        
        MailMessage mail = new MailMessage("thanakrit.tae@mahidol.ac.th", "opttj2521@gmail.com");
        SmtpClient client = new SmtpClient();
        client.Host = "mumail.mahidol.ac.th";
        client.Port = 25;
        //client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        
        client.UseDefaultCredentials = false;
        client.EnableSsl = false;

        client.Credentials = new NetworkCredential("thanakrit.tae@mahidol.ac.th", "meaw2520");

       
        mail.Subject = _subject;
        mail.Body = _body;
        client.Send(mail);
        
        

        /*
        System.Web.Mail.MailMessage eMail = new System.Web.Mail.MailMessage();


        eMail.BodyFormat = System.Web.Mail.MailFormat.Html;
        eMail.From = "thanakrit.tae@mahidol.ac.th"; //email ผู้ส่ง
        //config mail server
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtsperver"] = "mumail.mahidol.ac.th";  // "mail.yourdomain.com";
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = 25;
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = "thanakrit.tae@mahidol.ac.th";  //"user@yourdomain.com"; //email ผู้ส่ง
        eMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = "alex2521"; //password ของ email ผู้ส่ง
        eMail.To = _mail;//"opttj2521@gmail.com;lek_hot2521@hotmail.com"; //email ผู้รับ
        eMail.Subject = _subject;



        eMail.Body = (_body); //เนื้อหาของอีเมล์

        System.Web.Mail.SmtpMail.SmtpServer = "mumail.mahidol.ac.th";
        System.Web.Mail.SmtpMail.Send(eMail);

        */
        
        
        
        /*
        
        MailMessage mail = new MailMessage();

        mail.From = new System.Net.Mail.MailAddress("thanakrit.tae@mahidol.ac.th");

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        // The important part -- configuring the SMTP client

        SmtpClient smtp = new SmtpClient();

        smtp.Port = 587;

       

        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        smtp.UseDefaultCredentials = false;

        smtp.Credentials = new NetworkCredential("thanakrit.tae@mahidol.ac.th", "");
        smtp.EnableSsl = false;
        smtp.Host = "mumail.mahidol.ac.th";



        //recipient address



        mail.To.Add(new MailAddress("opttj2521@gmail.com"));

        //Formatted mail body

        mail.IsBodyHtml = true;

        string st = "Message Text";

        mail.Subject = "Subject";

        mail.Body = st;

        mail.Sender = new MailAddress("thanakrit.tae@mahidol.ac.th");

        smtp.Send(mail);

        
        */

    }


    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetUserIP()
    /// Param : n/a
    /// Description : หมายเลขเครื่องผู้ใช้งาน
    /// </summary>
    /// <returns></returns>
    public static string GetUserIP()
    {

        return HttpContext.Current.Request.UserHostAddress;
    }

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : GetHost()
    /// Param : n/a
    /// Description : หมายเลขเครื่องบริการ
    /// </summary>
    /// <returns></returns>
    public static string GetHost()
    {

        return HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

    }






}



public class DataReaderAdapter : DbDataAdapter
{

    /// <summary>
    /// Author : Thanakrit.tae
    /// Create Date : 2014-02-12
    /// Method : FillFromReader()
    /// Param : DataTable dataTable, IDataReader dataReader
    /// Description : แปลงข้อมูลจาก DataReader To DataSet
    /// </summary>
    /// <returns></returns>
    public int FillFromReader(DataTable dataTable, IDataReader dataReader)
    {
        return this.Fill(dataTable, dataReader);
    }
}