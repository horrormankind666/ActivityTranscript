using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;
using System.Data;
using System.Text;

public partial class modules_student_actAtTranscript : System.Web.UI.Page
{

    int _yStartPosBody = 532; // 562 600
    int _feedLineBig = 19;
    int _ylinePos = 542; // 610 542
    int _yStartPos = 660; // 690 728
    int _xCenterPos = 290; // 302
    int _feedLineBiggest = 26;
    int _feedLineMeduim = 15;
    int _feedLineSmall = 13;
    int _sizeFontBig = 16;
    int _sizeFontMedium = 14;
    int _sizeFontSmalless = 10;
    int _sizeFontTheSmalless = 8;
    int _sizeFontSmall = 12;
    string _fullNameTh = "";
    string _fullNameEn = "";
    string _facultyNameTh = "";
    string _facultyNameEn = "";
    string _programNameTh = "";
    string _programNameEn = "";
    string _countAct = "";
    string _countHour = "";
    string _dateTh = "";
    string _dateEn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login _login = new Login("student");
        //string _studentCode = _login.StudentCode;
        //_studentCode = "5915001";
        //if (_login.Authen == "true")
        //{



        DataTable _dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(Request["itemList"]);
        string _language = Request["language"];
        // ไว้ทดสอบ
        //DataTable _dataList = new DataTable();
        //DataColumn column = new DataColumn();
        //column.DataType = System.Type.GetType("System.String");
        //column.ColumnName = "studentCode";
        //_dataList.Columns.Add(column);
        //DataRow _dtRow = _dataList.NewRow();
        //_dtRow["studentCode"] = "6201002";
        //_dataList.Rows.Add(_dtRow);




        int _row = _dataList.Rows.Count;
        int _cutStrNum = 68; // 68
        string _studentCode = "";

       


        int _conditionReport = 0;
        string _path = Server.MapPath("~");
        Response.Charset = String.Empty;
        Response.ClearContent();
        Response.ContentType = "application/PDF";
        Document _document = new Document();
        PdfWriter _writer = PdfWriter.GetInstance(_document, Response.OutputStream);
        _document.SetPageSize(iTextSharp.text.PageSize.A4);
        _document.Open();
        PdfContentByte _cb = _writer.DirectContent;
        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        BaseFont _bfBold = BaseFont.CreateFont(_path + "\\fonts\\THSarabun Bold.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
       
        string _checkPassAT = "";      
        if (_dataList.Rows.Count > 0)
        {
            foreach (DataRow _drList in _dataList.Rows)
            {
                    _studentCode = _drList["studentCode"].ToString();
                    DataSet _ds2 = ActDB.getTransStudentPassByStudentCode(_studentCode);
                    if (_ds2.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds2.Tables[0].Rows)
                        {
                            _checkPassAT = _dr["stsPass"].ToString();
                            // 0 ไม่ผ่าน
                            // 1 ผ่าน
                        }
                    }
                    //_studentCode = "6001034";
                    _conditionReport = Convert.ToInt32(_studentCode.Substring(0, 2)); //  _studentCode.Substring(0, 2)

                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.BeginText();

                    string _projectNameTh = "";
                    string _projectNameEn = "";
                    string _projectNameThLine1 = "";
                    string _projectNameThLine2 = "";
                    string _positionNameTh = "";
                    string _positionNameEn = "";
                    string _projectCode = "";

                MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf,"1","1", _language, _document); // ต้องมาเอาเม้นต์ออก
                
                _cb.SetFontAndSize(_bf, _sizeFontSmall);
                DataSet _ds = ActDB.getActivityTranscript(_studentCode, "", "", "");
                int _i = 1;
                if (_conditionReport >= 62)
                {
                    _yStartPos = 660;
                    _yStartPosBody = 592; 
                    _ylinePos = 542;
                    _cb.EndText();
                    _document.NewPage(); // ต้องมาเอาเม้นต์ออก
                    _cb.BeginText();
                    _cb.SetFontAndSize(_bfBold, _sizeFontSmall);

                    MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf, "0", "1",_language, _document);
                    _yStartPosBody = _yStartPosBody + 17;
                    string _sumHours = string.Empty;
                    double _totalHours = 0.0;
                    ColumnText ct = new ColumnText(_cb);
                    int status = 0;
                    double _countR = 0;
                    iTextSharp.text.Font fontTh = new iTextSharp.text.Font(_bf, 11);
                    Paragraph _projectNameLong;
                    string _projectName = "";

                    DataSet _ds1 = ActDB.getListActATHIDEF(_studentCode);
                    DataRow[] _drRow1 = _ds1.Tables[0].Select("projectTypeId in ('PJT-007')"); //กิจกรรมกำหนดให้เข้าร่วม  
                    int _row1 = _drRow1.Length;
                    if (_row1 > 0)
                    {
                        for (int _j = 0; _j < _row1; _j++)
                        {
                            _sumHours = _drRow1[_j]["sumHours"].ToString();
                            _totalHours = _totalHours + Convert.ToDouble(_sumHours);
                        }
                    }
                    _cb.SetFontAndSize(_bf, 13);
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "กิจกรรมเลือกเข้าร่วม : จำนวน " + _row1 + " กิจกรรม", 50, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _totalHours + " หน่วยชั่วโมง", 206, _yStartPosBody, 0); // 198
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Elective Activities : " + _row1 + " Activities", 50, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _totalHours + " Hours", 187, _yStartPosBody, 0); // 181
                    }
                    
                    // header ส่วนของ กิจกรรมกำหนดให้เข้าร่วม
                    LineBorderTable(_conditionReport, _cb, "1", "0", _bfBold,_language);
                    

                    string _projectCodeHIDEF = string.Empty;
                    string _projectNameHIDEF = string.Empty;
                    string _positionNameHIDEF = string.Empty;
                    string _Volunteer = string.Empty;
                    string _HealthLiteracy = string.Empty;
                    string _Internationalization = string.Empty;
                    string _DigitalLiteracy = string.Empty;
                    string _EnvironmentalLiteracy = string.Empty;
                    string _FinancialLiteracy = string.Empty;
                    string _CriticalThinking = string.Empty;
                    string _Creativity = string.Empty;
                    string _Communication = string.Empty;
                    string _Leadership = string.Empty;
                    string _Socialskill = string.Empty;
                    double _totalVolunteer = 0.0;
                    double _totalHealthLiteracy = 0.0;
                    double _totalInternationalization = 0.0;
                    double _totalDigitalLiteracy = 0.0;
                    double _totalEnvironmentalLiteracy = 0.0;
                    double _totalFinancialLiteracy = 0.0;
                    double _totalCriticalThinking = 0.0;
                    double _totalCreativity = 0.0;
                    double _totalCommunication = 0.0;
                    double _totalLeadership = 0.0;
                    double _totalSocialskill = 0.0;

                    //string _ = string.Empty;
                    //string _ = string.Empty;
                    if (_row1 > 0)
                    {
                        for (int _j = 0; _j < _row1; _j++)
                        {
                            // _projectCodeHIDEF = _drRow1[_j]["projectCode"].ToString();
                            if (_language == "th")
                            {
                                //_projectNameHIDEF = _drRow1[_j]["projectNameTh"].ToString();
                                _positionNameHIDEF = _drRow1[_j]["positionNameTh"].ToString();
                                _projectNameHIDEF = _drRow1[_j]["projectNameDisplayTh"].ToString();
                                
                            }
                            else
                            {
                               // _projectNameHIDEF = _drRow1[_j]["projectNameEn"].ToString();
                                _positionNameHIDEF = _drRow1[_j]["positionNameEn"].ToString();
                                _projectNameHIDEF = _drRow1[_j]["projectNameDisplayEn"].ToString();
                            }
                            
                            _Volunteer = _drRow1[_j]["Volunteer"].ToString();
                            _HealthLiteracy = _drRow1[_j]["HealthLiteracy"].ToString();
                            _Internationalization = _drRow1[_j]["Internationalization"].ToString();
                            _DigitalLiteracy = _drRow1[_j]["DigitalLiteracy"].ToString();
                            _EnvironmentalLiteracy = _drRow1[_j]["EnvironmentalLiteracy"].ToString();
                            _FinancialLiteracy = _drRow1[_j]["FinancialLiteracy"].ToString();
                            _CriticalThinking = _drRow1[_j]["CriticalThinking"].ToString();
                            _Creativity = _drRow1[_j]["Creativity"].ToString();
                            _Communication = _drRow1[_j]["Communication"].ToString();
                            _Leadership = _drRow1[_j]["Leadership"].ToString();
                            _Socialskill = _drRow1[_j]["Socialskill"].ToString();
                            _sumHours = _drRow1[_j]["sumHours"].ToString();

                            _Volunteer = (_Volunteer == "") ? "0" : _Volunteer;
                            _HealthLiteracy = (_HealthLiteracy == "") ? "0" : _HealthLiteracy;
                            _Internationalization = (_Internationalization == "") ? "0" : _Internationalization;
                            _DigitalLiteracy = (_DigitalLiteracy == "") ? "0" : _DigitalLiteracy;
                            _EnvironmentalLiteracy = (_EnvironmentalLiteracy == "") ? "0" : _EnvironmentalLiteracy;
                            _FinancialLiteracy = (_FinancialLiteracy == "") ? "0" : _FinancialLiteracy;
                            _CriticalThinking = (_CriticalThinking == "") ? "0" : _CriticalThinking;
                            _Creativity = (_Creativity == "") ? "0" : _Creativity;
                            _Communication = (_Communication == "") ? "0" : _Communication;
                            _Leadership = (_Leadership == "") ? "0" : _Leadership;
                            _Socialskill = (_Socialskill == "") ? "0" : _Socialskill;



                            _totalVolunteer += Convert.ToDouble(_Volunteer);
                            _totalHealthLiteracy += Convert.ToDouble(_HealthLiteracy);
                            _totalInternationalization += Convert.ToDouble(_Internationalization);
                            _totalDigitalLiteracy += Convert.ToDouble(_DigitalLiteracy);
                            _totalEnvironmentalLiteracy += Convert.ToDouble(_EnvironmentalLiteracy);
                            _totalFinancialLiteracy += Convert.ToDouble(_FinancialLiteracy);
                            _totalCriticalThinking += Convert.ToDouble(_CriticalThinking);
                            _totalCreativity += Convert.ToDouble(_Creativity);
                            _totalCommunication += Convert.ToDouble(_Communication);
                            _totalLeadership += Convert.ToDouble(_Leadership);
                            _totalSocialskill += Convert.ToDouble(_Socialskill);


                            //_cb.SetFontAndSize(_bf, 11);
                            _cb.SetFontAndSize(_bf, _sizeFontSmalless);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_j + 1).ToString(), 36, _yStartPosBody, 0); // _projectCodeHIDEF
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameHIDEF, 54, _yStartPosBody, 0);




                            // เรื่องตัดบรรทัดเอาออกก่อน จะทำเป็น ฯ ใส่แทน
                            //_projectNameLong = new Paragraph(_projectNameHIDEF, fontTh);


                            //ct.SetSimpleColumn(new iTextSharp.text.Rectangle(56, 56, 260, _yStartPosBody + 16)); // 91  262
                            //_projectNameLong.SetLeading(Convert.ToSingle(1.35), Convert.ToSingle(1.35));// ระหว่างบรรทัด
                            //ct.AddElement(_projectNameLong);
                            //status = ct.Go();
                            //if (_projectNameHIDEF.Length < 66) // 54
                            //{
                            //    _countR = 1;
                            //}
                            //else
                            //{


                            //    _countR = _projectNameHIDEF.Length / 64 + 1; // 52 + 1
                            //    if (_countR >= 3)
                            //    {
                            //        if (_projectNameHIDEF.Length <= 147) // 125
                            //        {
                            //            // _countR = _countR;
                            //        }
                            //        else
                            //        {
                            //            _countR = _countR + 1;
                            //        }
                            //    }
                            //}



                            _Volunteer = (_Volunteer == "0") ? "-" : _Volunteer;
                            _HealthLiteracy = (_HealthLiteracy == "0") ? "-" : _HealthLiteracy;
                            _Internationalization = (_Internationalization == "0") ? "-" : _Internationalization;
                            _DigitalLiteracy = (_DigitalLiteracy == "0") ? "-" : _DigitalLiteracy;
                            _EnvironmentalLiteracy = (_EnvironmentalLiteracy == "0") ? "-" : _EnvironmentalLiteracy;
                            _FinancialLiteracy = (_FinancialLiteracy == "0") ? "-" : _FinancialLiteracy;
                            _CriticalThinking = (_CriticalThinking == "0") ? "-" : _CriticalThinking;
                            _Creativity = (_Creativity == "0") ? "-" : _Creativity;
                            _Communication = (_Communication == "0") ? "-" : _Communication;
                            _Leadership = (_Leadership == "0") ? "-" : _Leadership;
                            _Socialskill = (_Socialskill == "0") ? "-" : _Socialskill;

                            _cb.SetFontAndSize(_bf, _sizeFontTheSmalless);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _positionNameHIDEF, 295, _yStartPosBody, 0); // 295
                            _cb.SetFontAndSize(_bf, _sizeFontSmall);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Volunteer, 335, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _HealthLiteracy, 355, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Internationalization, 375, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _DigitalLiteracy, 395, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _EnvironmentalLiteracy, 415, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _FinancialLiteracy, 435, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _CriticalThinking, 455, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Creativity, 475, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Communication, 495, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Leadership, 515, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _Socialskill, 535, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _sumHours, 555, _yStartPosBody, 0);

                            _countR = 1;

                            _yStartPosBody = _yStartPosBody - Convert.ToInt32(Math.Ceiling(17 * _countR));
                            _ylinePos = _ylinePos - Convert.ToInt32(Math.Ceiling(17 * _countR));

                            if ((_yStartPosBody <= 197))
                            {
                                _cb.MoveTo(23, 580);
                                _cb.LineTo(23, _ylinePos - 150);

                                _cb.MoveTo(50, 580); // 87
                                _cb.LineTo(50, _ylinePos - 150);

                                _cb.MoveTo(264, 580);
                                _cb.LineTo(264, _ylinePos - 150);

                                _cb.MoveTo(324, 580);
                                _cb.LineTo(324, _ylinePos - 150);

                                _cb.MoveTo(345, 580);
                                _cb.LineTo(345, _ylinePos - 150);

                                _cb.MoveTo(365, 564);
                                _cb.LineTo(365, _ylinePos - 150);

                                _cb.MoveTo(385, 564);
                                _cb.LineTo(385, _ylinePos - 150);

                                _cb.MoveTo(405, 564);
                                _cb.LineTo(405, _ylinePos - 150);

                                _cb.MoveTo(425, 564);
                                _cb.LineTo(425, _ylinePos - 150);

                                _cb.MoveTo(445, 580);
                                _cb.LineTo(445, _ylinePos - 150);

                                _cb.MoveTo(465, 564);
                                _cb.LineTo(465, _ylinePos - 150);

                                _cb.MoveTo(485, 564);
                                _cb.LineTo(485, _ylinePos - 150);

                                _cb.MoveTo(505, 564);
                                _cb.LineTo(505, _ylinePos - 150);

                                _cb.MoveTo(525, 564);
                                _cb.LineTo(525, _ylinePos - 150);

                                _cb.MoveTo(545, 580);
                                _cb.LineTo(545, _ylinePos - 150);

                                _cb.MoveTo(565, 580);
                                _cb.LineTo(565, _ylinePos - 150);


                                _cb.MoveTo(23, 580);
                                _cb.LineTo(565, 580);

                                _cb.MoveTo(345, 564);
                                _cb.LineTo(545, 564);

                                _cb.MoveTo(23, 451);
                                _cb.LineTo(565, 451);

                                _cb.MoveTo(23, _ylinePos - 150);
                                _cb.LineTo(565, _ylinePos - 150);
                                _cb.Stroke();

                                _yStartPos = 660;
                                _yStartPosBody = 592;
                                _ylinePos = 542;

                                
                                _cb.EndText();
                                _document.NewPage();
                                _cb.BeginText();
                                LineBorderTable(_conditionReport, _cb, "1", "0", _bfBold,_language);
                                _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
                                MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf, "0", "1",_language, _document);
                                _cb.SetFontAndSize(_bf, _sizeFontSmall);
                                _yStartPosBody = _yStartPosBody + 17;

                            }

                        }
                    }







                    _cb.MoveTo(23, 580);
                    _cb.LineTo(23, _ylinePos - 170);

                    _cb.MoveTo(50, 580); // 87
                    _cb.LineTo(50, _ylinePos - 150);

                    _cb.MoveTo(264, 580);
                    _cb.LineTo(264, _ylinePos - 150);

                    _cb.MoveTo(324, 580);
                    _cb.LineTo(324, _ylinePos - 170);

                    _cb.MoveTo(345, 580);
                    _cb.LineTo(345, _ylinePos - 170);

                    _cb.MoveTo(365, 564);
                    _cb.LineTo(365, _ylinePos - 170);

                    _cb.MoveTo(385, 564);
                    _cb.LineTo(385, _ylinePos - 170);

                    _cb.MoveTo(405, 564);
                    _cb.LineTo(405, _ylinePos - 170);

                    _cb.MoveTo(425, 564);
                    _cb.LineTo(425, _ylinePos - 170);

                    _cb.MoveTo(445, 580);
                    _cb.LineTo(445, _ylinePos - 170);

                    _cb.MoveTo(465, 564);
                    _cb.LineTo(465, _ylinePos - 170);

                    _cb.MoveTo(485, 564);
                    _cb.LineTo(485, _ylinePos - 170);

                    _cb.MoveTo(505, 564);
                    _cb.LineTo(505, _ylinePos - 170);

                    _cb.MoveTo(525, 564);
                    _cb.LineTo(525, _ylinePos - 170);

                    _cb.MoveTo(545, 580);
                    _cb.LineTo(545, _ylinePos - 170);

                    _cb.MoveTo(565, 580);
                    _cb.LineTo(565, _ylinePos - 170);


                    _cb.MoveTo(23, 580);
                    _cb.LineTo(565, 580);

                    _cb.MoveTo(345, 564);
                    _cb.LineTo(545, 564);

                    _cb.MoveTo(23, 451);
                    _cb.LineTo(565, 451);

                    _cb.MoveTo(23, _ylinePos - 150);
                    _cb.LineTo(565, _ylinePos - 150);
                    _cb.Stroke();


                    //_yStartPosBody = _yStartPosBody - 19;


                    if(_language=="th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "รวมทั้งสิ้น", 178, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Total", 178, _yStartPosBody, 0);
                    }
                    
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalVolunteer == 0) ? "-" : _totalVolunteer.ToString() , 335, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalHealthLiteracy == 0) ? "-" : _totalHealthLiteracy.ToString(), 355, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalInternationalization == 0) ? "-" : _totalInternationalization.ToString(), 375, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalDigitalLiteracy == 0) ? "-" : _totalDigitalLiteracy.ToString(), 395, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalEnvironmentalLiteracy == 0) ? "-" : _totalEnvironmentalLiteracy.ToString() , 415, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalFinancialLiteracy == 0) ? "-" : _totalFinancialLiteracy.ToString() , 435, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalCriticalThinking == 0) ? "-" : _totalCriticalThinking.ToString(), 455, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalCreativity == 0) ? "-" : _totalCreativity.ToString(), 475, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalCommunication == 0) ? "-" : _totalCommunication.ToString() , 495, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalLeadership == 0) ? "-" : _totalLeadership.ToString() , 515, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalSocialskill == 0) ? "-" : _totalSocialskill.ToString(), 535, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (_totalHours == 0) ? "-" : _totalHours.ToString() , 555, _yStartPosBody, 0);

                    _cb.MoveTo(23, _ylinePos - 170);
                    _cb.LineTo(565, _ylinePos - 170);
                    _cb.Stroke();

                    _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                }   
                else 
                if (_conditionReport >= 60)
                { 
                        string _M = "", _A = "", _H = "", _I = "", _D = "", _O = "", _L = "";
                        string _ASum = "";
                        int _stsFirstPage = 1;
                        int _stsNoBorder = 0;
                        int kk = 0;
                        string _stsNewPageBlank = "";
                        if (_ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow _dr in _ds.Tables[0].Rows)
                            {
                            //while (_i <= 26)
                            //{


                                _fullNameTh = _dr["prefixNameTh"].ToString() + _dr["firstname"].ToString() + " " + _dr["lastname"].ToString();
                                _projectNameTh = _dr["projectNameTh"].ToString();
                                _projectNameEn = _dr["projectNameEn"].ToString();
                                _positionNameTh = _dr["positionNameTh"].ToString();
                                _positionNameEn = _dr["positionNameEn"].ToString();
                                _projectCode = _dr["code"].ToString();
                                _M = _dr["M"].ToString();
                                _A = _dr["A"].ToString();
                                _H = _dr["H"].ToString();
                                _I = _dr["I"].ToString();
                                _D = _dr["D"].ToString();
                                _O = _dr["O"].ToString();
                                _L = _dr["L"].ToString();


                                _M = _M == "" ? "0" : _M;
                                _A = _A == "" ? "0" : _A;
                                _H = _H == "" ? "0" : _H;
                                _I = _I == "" ? "0" : _I;
                                _D = _D == "" ? "0" : _D;
                                _O = _O == "" ? "0" : _O;
                                _L = _L == "" ? "0" : _L;

                                _ASum = (Convert.ToDouble(_M) + Convert.ToDouble(_A) + Convert.ToDouble(_H) + Convert.ToDouble(_I) + Convert.ToDouble(_D) + Convert.ToDouble(_O) + Convert.ToDouble(_L)).ToString();
                                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectCode, 35, _yStartPosBody, 0);

                            if (_language == "th") {
                                

                            }
                            else
                            {
                                _projectNameTh = _projectNameEn;
                                _positionNameTh = _positionNameEn;
                            }

                                if (_projectNameTh.Length > _cutStrNum) // 60
                                {
                                     string _strNameLastBefore  = _projectNameTh.Substring(_cutStrNum-1, 1);
                                     string _projectNameLast = _projectNameTh.Substring(_cutStrNum, 1);
                                     string _strName2Last = "";
                                     string _strName2LastBefore = "";
                                     string _strName2LastBeforable = "";
                                     string _strName4LastBefore = "";
                                     string _strName3LastBefore = "";
                                     string _strName3Before = "";

                                     if (_projectNameTh.Length >= (_cutStrNum+2))
                                     {
                                            _strName2Last = _projectNameTh.Substring(_cutStrNum, 2);
                                            _strName2LastBefore = _projectNameTh.Substring(_cutStrNum - 1, 2);
                                            _strName2LastBeforable = _projectNameTh.Substring(_cutStrNum - 2, 2);
                                            _strName3LastBefore = _projectNameTh.Substring(_cutStrNum - 2, 3);
                                            _strName4LastBefore = _projectNameTh.Substring(_cutStrNum - 3, 4);
                                     }
                                     int _numDigitRotate = 0;

                                     _numDigitRotate = numDigitForCheckStringThai(_projectNameLast, _strName2Last, _strName2LastBefore, _strNameLastBefore, _strName4LastBefore, _strName3LastBefore, _strName2LastBeforable);


                                    _projectNameThLine1 = _projectNameTh.Substring(0, _cutStrNum + _numDigitRotate);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine1, 107, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionNameTh, 354, _yStartPosBody, 0); //340
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _M, 422, _yStartPosBody, 0); // 412
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A, 437, _yStartPosBody, 0); // 427
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _H, 452, _yStartPosBody, 0); // 442
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _I, 467, _yStartPosBody, 0); // 457
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _D, 482, _yStartPosBody, 0); // 472
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _O, 497, _yStartPosBody, 0); // 487
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _L, 512, _yStartPosBody, 0); // 502
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _ASum, 546, _yStartPosBody, 0); // 543
                                    _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                                    _ylinePos = _ylinePos - 15;
                                    _projectNameThLine2 = _projectNameTh.Substring(_cutStrNum + _numDigitRotate, _projectNameTh.Length - (_cutStrNum + _numDigitRotate)); // 60
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine2, 107, _yStartPosBody, 0);

                                }
                                else
                                {
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameTh, 107, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionNameTh, 354, _yStartPosBody, 0); // 340
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _M, 422, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A, 437, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _H, 452, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _I, 467, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _D, 482, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _O, 497, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _L, 512, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _ASum, 546, _yStartPosBody, 0);
                                }

                                _ylinePos = _ylinePos - 15;
                                _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                                kk++;
                                if (kk == _ds.Tables[0].Rows.Count)
                                {
                                    _stsNewPageBlank = "0";
                                }
                                else
                                {
                                    _stsNewPageBlank = "1";
                                }
                            if ((_yStartPosBody <= 197) )//&& (_ds.Tables[0].Rows.Count >= 26))
                            {
                                    LineBorderTable(_conditionReport, _cb, _stsFirstPage.ToString(), _stsNoBorder.ToString(), _bfBold,_language); // 1
                                    _yStartPos = 660; // 728
                                    _yStartPosBody = 592; // 532

                                    _ylinePos = 542; // 542

                                    _cb.EndText();
                                    _document.NewPage();
                                    _cb.BeginText();
                                    _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
                                    MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf,"0", _stsNewPageBlank,_language, _document);
                                    _cb.SetFontAndSize(_bf, _sizeFontSmall);
                                    _stsFirstPage++;
                            }

                                //    _i++;
                                //}
                            }
                            // ไว้ตรวจสอบว่าหน้าถัดไปถ้ามีการขึ้นเพจ แต่มีแค่ ลายเซนอย่างเดียวจะต้องไม่มีเส้นขอบ
                            if (_ylinePos == 602)
                            {
                                _stsNoBorder = 1;
                            }
                            LineBorderTable(_conditionReport, _cb, _stsFirstPage.ToString(), _stsNoBorder.ToString(), _bfBold,_language);
                        }


                    }
                    else
                    {

                        string _A1 = "", _A2 = "", _A3 = "", _A4 = "";
                        string _ASum = "";
                        string _stsNewPageBlank = "";
                        int _stsFirstPage = 1;
                        int _stsNoBorder = 0;
                        int kk = 0;

                        
                        if (_ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow _dr in _ds.Tables[0].Rows)
                            {

                    
                                _fullNameTh = _dr["prefixNameTh"].ToString() + _dr["firstname"].ToString() + " " + _dr["lastname"].ToString();
                                _projectNameTh = _dr["projectNameTh"].ToString();
                                _projectNameEn = _dr["projectNameEn"].ToString();
                                _positionNameTh = _dr["positionNameTh"].ToString();
                                _positionNameEn = _dr["positionNameEn"].ToString();
                                _projectCode = _dr["code"].ToString();
                                _A1 = _dr["A.1"].ToString();
                                _A2 = _dr["A.2"].ToString();
                                _A3 = _dr["A.3"].ToString();
                                _A4 = _dr["A.4"].ToString();
                                _A1 = _A1 == "" ? "0" : _A1;
                                _A2 = _A2 == "" ? "0" : _A2;
                                _A3 = _A3 == "" ? "0" : _A3;
                                _A4 = _A4 == "" ? "0" : _A4;
                                _ASum = (Convert.ToDouble(_A1) + Convert.ToDouble(_A2) + Convert.ToDouble(_A3) + Convert.ToDouble(_A4)).ToString();
                                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectCode, 33, _yStartPosBody, 0);

                            if (_language == "th")
                            {
        
                            }
                            else
                            {
                                _projectNameTh = _projectNameEn;
                                _positionNameTh = _positionNameEn;
                            }

                            if (_projectNameTh.Length > _cutStrNum) // 60
                                {
                                     string _strNameLastBefore = _projectNameTh.Substring(_cutStrNum - 1, 1);
                                     string _projectNameLast = _projectNameTh.Substring(_cutStrNum, 1);
                                     string _strName2Last = "";
                                     string _strName2LastBefore = "";
                                     string _strName2LastBeforable = "";
                                     string _strName3LastBefore = "";
                                     string _strName4LastBefore = "";
                                     string _strName3Before = "";
                            
                                     if (_projectNameTh.Length >= (_cutStrNum + 2 )) // เคยบวก 2
                                     {
                                        _strName2Last = _projectNameTh.Substring(_cutStrNum, 2);
                                        _strName2LastBefore = _projectNameTh.Substring(_cutStrNum - 1, 2);
                                        _strName2LastBeforable = _projectNameTh.Substring(_cutStrNum - 2, 2);
                                        _strName3LastBefore = _projectNameTh.Substring(_cutStrNum - 2, 3);
                                        _strName4LastBefore = _projectNameTh.Substring(_cutStrNum - 3, 4);
                                        
                                      }
                                     int _numDigitRotate = 0;

                                    _numDigitRotate = numDigitForCheckStringThai(_projectNameLast, _strName2Last, _strName2LastBefore, _strNameLastBefore, _strName4LastBefore, _strName3LastBefore, _strName2LastBeforable);

                                    _projectNameThLine1 = _projectNameTh.Substring(0, _cutStrNum + _numDigitRotate);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine1, 101, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionNameTh, 375, _yStartPosBody, 0); // 368
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A1, 445, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A2, 465, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A3, 485, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A4, 505, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _ASum, 543, _yStartPosBody, 0);
                                    _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                                    _ylinePos = _ylinePos - 15;
                                    _projectNameThLine2 = _projectNameTh.Substring(_cutStrNum + _numDigitRotate, _projectNameTh.Length - (_cutStrNum + _numDigitRotate)); // 60
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine2, 101, _yStartPosBody, 0);

                                //_projectNameThLine1 = _projectNameTh.Substring(0, 55); // 60
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine1, 110, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionNameTh, 345, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A1, 445, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A2, 465, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A3, 485, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A4, 505, _yStartPosBody, 0);
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _ASum, 543, _yStartPosBody, 0);
                                //_yStartPosBody = _yStartPosBody - _feedLineMeduim;
                                //_ylinePos = _ylinePos - 15;
                                //_projectNameThLine2 = _projectNameTh.Substring(55, _projectNameTh.Length - 55); // 60
                                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameThLine2, 110, _yStartPosBody, 0);
                                }
                                else
                                {
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectNameTh, 101, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionNameTh, 375, _yStartPosBody, 0); // 368
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A1, 445, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A2, 465, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A3, 485, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _A4, 505, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _ASum, 543, _yStartPosBody, 0);
                                }

                                _ylinePos = _ylinePos - 15;
                                _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                                kk++;
                                if (kk == _ds.Tables[0].Rows.Count)
                                {
                                    _stsNewPageBlank = "0";
                                }
                                else
                                {
                                    _stsNewPageBlank = "1";
                                }


                               if ((_yStartPosBody <= 197) )//&& (_ds.Tables[0].Rows.Count >= 26))
                                {
                                    LineBorderTable(_conditionReport, _cb, _stsFirstPage.ToString(), _stsNoBorder.ToString(), _bfBold,_language);
                                    _yStartPos = 660; // 728
                                    _yStartPosBody = 592; // 532
                                    _ylinePos = 542; // 610  542
                                    _cb.EndText();
                                    _document.NewPage();
                                    _cb.BeginText();
                                    _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
                                    MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf,"0", _stsNewPageBlank,_language, _document);
                                    _cb.SetFontAndSize(_bf, _sizeFontSmall);
                                    _stsFirstPage++;

                                }
                            }
                        // ไว้ตรวจสอบว่าหน้าถัดไปถ้ามีการขึ้นเพจ แต่มีแค่ ลายเซนอย่างเดียวจะต้องไม่มีเส้นขอบ
                        if (_ylinePos==602)
                        {
                            _stsNoBorder = 1;
                        }
                        LineBorderTable(_conditionReport, _cb, _stsFirstPage.ToString(), _stsNoBorder.ToString(), _bfBold,_language); // _stsHasNewPage.ToString()
                    }
                    }

                // }

                if (_checkPassAT == "1") // ถ้าผ่านค่อยมีลายเซนต์
                {
                    string _logoMU = _path + "\\images\\SignPerson.jpg";
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(_logoMU);


                    _yStartPosBody = _yStartPosBody - _feedLineSmall;
                    _yStartPosBody = _yStartPosBody - _feedLineSmall;
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ลงชื่อ...................................................", 420, _yStartPosBody, 0);
                    }
                    else 
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "sign...................................................", 420, _yStartPosBody, 0);
                    }
                    _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "( " + _fullNameTh + " )", 420, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "( " + _fullNameEn + " )", 420, _yStartPosBody, 0);
                    }
                    _yStartPosBody = _yStartPosBody - _feedLineSmall;
                    _yStartPosBody = _yStartPosBody - _feedLineSmall;
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ให้ไว้ ณ วันที่ " + _dateTh, 420, _yStartPosBody, 0);
                    }
                    else 
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Issued on " + _dateEn, 420, _yStartPosBody, 0);
                    }
                    _yStartPosBody = _yStartPosBody - _feedLineBiggest;


                    _yStartPosBody = _yStartPosBody - _feedLineSmall;
                    image.ScaleAbsolute(100, 32);
                    image.SetAbsolutePosition(368, _yStartPosBody);
                    _cb.AddImage(image);
                    // _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "( รองศาสตราจารย์ นายแพทย์ปรีชา  สุนทรานันท์ )", 420, _yStartPosBody, 0);
                    _yStartPosBody = _yStartPosBody - 5;
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "( ผู้ช่วยศาสตราจารย์ ร.ท. ทพ.ชัชชัย คุณาวิศรุต )", 420, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "( Asst. Prof. Flg.Off. Chatchai Kunavisarut  )", 420, _yStartPosBody, 0);
                    }

                    _yStartPosBody = _yStartPosBody - _feedLineMeduim;
                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "รักษาการแทนรองอธิการบดีฝ่ายกิจการนักศึกษาและศิษย์เก่าสัมพันธ์", 420, _yStartPosBody, 0);
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "รองอธิการบดีฝ่ายกิจการนักศึกษาและศิษย์เก่าสัมพันธ์", 420, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Vice President for Student Affairs and Alumni", 420, _yStartPosBody, 0);
                    }
                    //_cb.Stroke();

                }


                    _cb.EndText();


                    _document.NewPage();
                    _yStartPosBody = 532; // 600
                    _feedLineBig = 19;

                    _ylinePos = 542; // 610 542

                    _yStartPos = 660; // 728
                    _xCenterPos = 290; // 302
                    _feedLineBiggest = 26;
                    _feedLineMeduim = 15;
                    _feedLineSmall = 13;
                    _sizeFontBig = 16;
                    _sizeFontMedium = 14;
                    _sizeFontSmalless = 10;
                    _sizeFontTheSmalless = 8;
                    _sizeFontSmall = 12;
            }
        }

        _document.Close();
        Response.Write(_document);
        Response.End();
        //}
        //else
        //{
        //    Response.Write("ไม่มีสิทธิ์เข้าใช้งานระบบ");
        //}
       // string _studentCode = Request["studentCode"];
        //string _studentCode = "5613277";
        //string _studentCode = "6005249";
      

    }

    //public void FeddNewPage(int _yStartPosBody, int _row, int _conditionReport, PdfContentByte _cb, BaseFont _bfBold, BaseFont _bf, Document _document, PdfWriter _writer, string _path, string _studentCode)
    //{

    //        // start เริ่มกำหนดค่าให้ใหม่
    //        LineBorderTable(_conditionReport, _cb);
    //        _yStartPos = 728;
    //        _yStartPosBody = 600;
    //        _ylinePos = 610;
    //        _cb.EndText();
    //        _document.NewPage();
    //        _cb.BeginText();
    //        _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
    //        MasterDataInEachPage(_conditionReport, _cb, _writer, _path, _studentCode, _bfBold, _bf);
    //        _cb.SetFontAndSize(_bf, _sizeFontSmall);

    //}

   

    public void MasterDataInEachPage(int _conditionReport, PdfContentByte _cb, PdfWriter _writer, string _path, string _studentCode, BaseFont _bfBold, BaseFont _bf, string _statusFirstPage,string _statusNewBlankPage,string _language,Document _document) // _statusFirstPage = 1 คือเป็นหน้าแรก
    {
        //string _logoMU = _path + "\\images\\logo.png";
        //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(_logoMU);
        //image.SetAbsolutePosition(260, 0);
        //image.ScaleAbsolute(85, 82);
        //image.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
        //tp.AddImage(image);






        PdfContentByte cbhead = _writer.DirectContent;
        PdfTemplate tp = cbhead.CreateTemplate(500, 95);
        
        cbhead.AddTemplate(tp, 0, 842 - 95);

        string _studentId = string.Empty;
        DataSet _ds = ActDB.getListSummaryProjectByStudent(_studentCode, "", "", "", "", "");
        if (_ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _fullNameTh = _dr["prefixNameTh"].ToString() + _dr["firstname"].ToString() + " " + _dr["lastname"].ToString();
                _fullNameEn = _dr["prefixNameEn"].ToString() + _dr["enFirstname"].ToString() + " " + _dr["enLastname"].ToString();
                _facultyNameTh = _dr["facultyNameTh"].ToString();
                _facultyNameEn = _dr["facultyNameEn"].ToString();
                _programNameTh = _dr["programNameTh"].ToString();
                _programNameEn = _dr["programNameEn"].ToString();
                _countAct = _dr["countAct"].ToString();
                _countHour = _dr["countHour"].ToString();
                _dateTh = _dr["dateTh"].ToString();
                _dateEn = _dr["dateEn"].ToString();
                _studentId = _dr["studentId"].ToString();
            }
        }



        if (_language == "th")
        {
            _cb.SetFontAndSize(_bfBold, _sizeFontBig);
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "มหาวิทยาลัยมหิดล", _xCenterPos, _yStartPos, 0);
            _yStartPos = _yStartPos - _feedLineBig;
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หนังสือรับรองการผ่านกิจกรรมเสริมหลักสูตร", _xCenterPos, _yStartPos, 0);
            _yStartPos = _yStartPos - _feedLineBig;
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หนังสือสำคัญฉบับนี้ให้ไว้แสดงถึงการผ่านการเข้าร่วมกิจกรรมเสริมหลักสูตร", _xCenterPos, _yStartPos, 0);
            _cb.SetFontAndSize(_bf, _sizeFontMedium);
        }
        else
        {
            _yStartPos = _yStartPos + 10;
            _cb.SetFontAndSize(_bfBold, _sizeFontBig);
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Mahidol University", _xCenterPos, _yStartPos, 0);
            _yStartPos = _yStartPos - 17;
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Official Activity Transcript of Record", _xCenterPos, _yStartPos, 0);
            _yStartPos = _yStartPos - 17;
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This Certificate is issued to certify that the individual named has been", _xCenterPos, _yStartPos, 0);
            _yStartPos = _yStartPos - 17;
            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "attended the extracurricular activity of Mahidol University", _xCenterPos, _yStartPos, 0);
            _cb.SetFontAndSize(_bf, 17);
        }

        iTextSharp.text.Font fontTh = new iTextSharp.text.Font(_bf, 13);
        iTextSharp.text.Font fontEn = new iTextSharp.text.Font(_bf, 12);

        if (_statusFirstPage == "1")
        {
            _cb.SetFontAndSize(_bf, _sizeFontSmall);
            _yStartPos = _yStartPos - _feedLineBiggest;
            if (_language == "th")
            {
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อ-นามสกุล : " + _fullNameTh , 50, _yStartPos, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "เลขประจำตัวนักศึกษา : " + _studentCode, 350, _yStartPos, 0);

                _yStartPos = _yStartPos - _feedLineBig;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _facultyNameTh, 50, _yStartPos, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _programNameTh, 350, _yStartPos, 0);
                _yStartPos = _yStartPos - _feedLineBig;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนกิจกรรม : " + _countAct + " กิจกรรม", 50, _yStartPos, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนชั่วโมง : " + _countHour + " ชั่วโมง", 350, _yStartPos, 0); // 365
            }
            else
            {
                ColumnText ct = new ColumnText(_cb);
                int status = 0;
                int _countR = 0;
                Paragraph _programNameEnLong;

                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Name : " + _fullNameEn, 50, _yStartPos, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Student ID : " + _studentCode, 350, _yStartPos, 0);

                _yStartPos = _yStartPos - _feedLineBig;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Degree : " + _facultyNameEn, 50, _yStartPos, 0);
                _programNameEnLong = new Paragraph(_programNameEn, fontEn);

                // แสดงตรงชื่อ Club ที่ยาว
                ct.SetSimpleColumn(new iTextSharp.text.Rectangle(350, 350, _yStartPos, _yStartPos + 18));
                _programNameEnLong.SetLeading(Convert.ToSingle(1.32), Convert.ToSingle(1.32));// ระหว่างบรรทัด
                ct.AddElement(_programNameEnLong);
                status = ct.Go();
                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "โคฟเวอร์แดนซ์ เต้นไปให้ถึงฝั่งฝัน ครั้งที่ 5 GRUJ 5", 436, _yStartPosBody, 0);
                if (_programNameEn.Length < 37) // 52
                {
                    _countR = 1;
                }
                else
                {
                    _countR = (_programNameEn.Length / 37) + 1;
                }

                _cb.EndText();
                _cb.BeginText();

                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Major : "+_programNameEn, 350, _yStartPos, 0);
                _yStartPos = _yStartPos - _feedLineBig;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total :  " + _countAct + " Activities , "+ _countHour + " Hours", 50, _yStartPos, 0);
                //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนชั่วโมง : " + _countHour + " ชั่วโมง", 350, _yStartPos, 0); // 365
            }
        }
        else
        {
            _ylinePos = _ylinePos + 60;
        }

      if (_statusNewBlankPage == "1")
        {

            _cb.SetLineWidth(0.6f);
            _cb.SetGrayStroke(0.3f);

            if (_conditionReport >= 62) // New HIDEF
            {
                if (_statusFirstPage == "1") // เฉพาะหน้าแรก
                {
                    _cb.MoveTo(30, _ylinePos);
                    _cb.LineTo(570, _ylinePos);
                    _ylinePos = _ylinePos - 15;
                    _cb.MoveTo(30, _ylinePos);
                    _cb.LineTo(570, _ylinePos);
                    _cb.Stroke();

                    _cb.SetFontAndSize(_bfBold, _sizeFontMedium);
                    _yStartPos = _yStartPos - _feedLineBiggest;

                    ColumnText ct = new ColumnText(_cb);
                    int status = 0;
                    int _countR = 0;
                    Paragraph _clubNameLong;
                    string _clubName = string.Empty;
                    string _positionName = string.Empty;
                    string _clubFacultyName = string.Empty;
                    string _acaYearDisplay = string.Empty;

                    DataSet _dsClub = ActDB.getListTransStudentClub(_studentCode);

                    _yStartPosBody = _yStartPosBody - 1;
                    if (_language == "th") 
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ปี", 55, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "องค์กรนักศึกษา/ชมรม", 149, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ตำแหน่งที่ดำรง", 312, _yStartPosBody, 0); // 301
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ส่วนงาน", 475, _yStartPosBody, 0); // 495

                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ปี", 55, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ตำแหน่งที่ดำรง", 140, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ส่วนงาน", 313, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "องค์กรนักศึกษา/ชมรม", 495, _yStartPosBody, 0);

                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Year", 55, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Club/Organization", 149, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Position", 312, _yStartPosBody, 0); // 313
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Faculty/Institute/Colledge", 475, _yStartPosBody, 0); // 495

                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Year", 55, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Position", 140, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Faculty/Institute/Colledge", 313, _yStartPosBody, 0);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Club/Organization", 495, _yStartPosBody, 0);

                    }




                    _yStartPosBody = _yStartPosBody - 17;
                    _ylinePos = _ylinePos - 18;

                    if (_dsClub.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _dsClub.Tables[0].Rows)
                        {
                            if (_language == "th") 
                            {
                                _clubName = _dr["clubNameTh"].ToString();
                                _clubNameLong = new Paragraph(_clubName, fontTh);
                                _positionName = _dr["positionNameTh"].ToString();
                                _clubFacultyName = _dr["positionNameDisplayTh"].ToString();
                            }
                            else
                            {
                                _clubName = _dr["clubNameEn"].ToString();
                                _clubNameLong = new Paragraph(_clubName, fontEn);
                                _positionName = _dr["positionNameDisplayEn"].ToString();
                                _clubFacultyName = _dr["clubFacultyNameEn"].ToString();
                            }
                            
                            
                            
                            _acaYearDisplay = _dr["acaYearDisplay"].ToString();
                            


                            _cb.SetFontAndSize(_bf, 11); // 13
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _acaYearDisplay, 55, _yStartPosBody, 0);

                            // แสดงตรงชื่อ Club ที่ยาว
                            //ct.SetSimpleColumn(new iTextSharp.text.Rectangle(85, 85, 200, _yStartPosBody + 17));
                            //_clubNameLong.SetLeading(Convert.ToSingle(1.2), Convert.ToSingle(1.2));// ระหว่างบรรทัด
                            //ct.AddElement(_clubNameLong);
                            //status = ct.Go();
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _clubName, 85, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionName, 262, _yStartPosBody, 0); // 228
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _clubFacultyName, 390, _yStartPosBody, 0); // 436


                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _positionName, 90, _yStartPosBody, 0);
                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _clubFacultyName, 211, _yStartPosBody, 0);
                            //// แสดงตรงชื่อ Club ที่ยาว
                            //ct.SetSimpleColumn(new iTextSharp.text.Rectangle(436, 436, 565, _yStartPosBody + 17));
                            //_clubNameLong.SetLeading(Convert.ToSingle(1.2), Convert.ToSingle(1.2));// ระหว่างบรรทัด
                            //ct.AddElement(_clubNameLong);
                            //status = ct.Go();
                            _countR = 1;
                            _yStartPosBody = _yStartPosBody - (13 * _countR);
                            _ylinePos = _ylinePos - (13 * _countR);

                            // _yStartPosBody = _yStartPosBody + 14;

                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "โคฟเวอร์แดนซ์ เต้นไปให้ถึงฝั่งฝัน ครั้งที่ 5 GRUJ 5", 436, _yStartPosBody, 0);
                            //if (_clubName.Length < 37) // 52
                            //{
                            //    _countR = 1;
                            //}
                            //else
                            //{
                            //    _countR = (_clubName.Length / 37) + 1;
                            //}
                            //_yStartPosBody = _yStartPosBody - (17 * _countR);
                            //_ylinePos = _ylinePos - (17 * _countR);
                            // จบ

                            // เพิ่ม 29 ต.ค. 2566 ตัดขึ้นหน้าใหม่
                            if ((_yStartPosBody <= 197))
                            {

                                _cb.MoveTo(30, 542);
                                _cb.LineTo(30, _ylinePos);

                                _cb.MoveTo(80, 542);
                                _cb.LineTo(80, _ylinePos);

                                _cb.MoveTo(255, 542); // 218
                                _cb.LineTo(255, _ylinePos); // 218

                                _cb.MoveTo(380, 542); // 425
                                _cb.LineTo(380, _ylinePos); // 425

                                _cb.MoveTo(570, 542);
                                _cb.LineTo(570, _ylinePos);

                                _cb.MoveTo(30, _ylinePos);
                                _cb.LineTo(570, _ylinePos);

                                _cb.Stroke();


                                _yStartPosBody = 532; // 600
                                _yStartPos = 660; // 728
                                _ylinePos = 542; // 610 542


                                






          

                                _cb.EndText();
                                _document.NewPage();
                                _cb.BeginText();

                                if (_language == "th")
                                {
                                    _cb.SetFontAndSize(_bfBold, _sizeFontBig);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "มหาวิทยาลัยมหิดล", _xCenterPos, _yStartPos, 0);
                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หนังสือรับรองการผ่านกิจกรรมเสริมหลักสูตร", _xCenterPos, _yStartPos, 0);
                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หนังสือสำคัญฉบับนี้ให้ไว้แสดงถึงการผ่านการเข้าร่วมกิจกรรมเสริมหลักสูตร", _xCenterPos, _yStartPos, 0);
                                    _cb.SetFontAndSize(_bf, _sizeFontMedium);
                                }
                                else
                                {
                                    _yStartPos = _yStartPos + 10;
                                    _cb.SetFontAndSize(_bfBold, _sizeFontBig);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Mahidol University", _xCenterPos, _yStartPos, 0);
                                    _yStartPos = _yStartPos - 17;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Official Activity Transcript of Record", _xCenterPos, _yStartPos, 0);
                                    _yStartPos = _yStartPos - 17;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This Certificate is issued to certify that the individual named has been", _xCenterPos, _yStartPos, 0);
                                    _yStartPos = _yStartPos - 17;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "attended the extracurricular activity of Mahidol University", _xCenterPos, _yStartPos, 0);
                                    _cb.SetFontAndSize(_bf, 17);
                                }

                                _cb.SetFontAndSize(_bf, _sizeFontSmall);
                                _yStartPos = _yStartPos - _feedLineBiggest;
                                if (_language == "th")
                                {
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อ-นามสกุล : " + _fullNameTh, 50, _yStartPos, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "เลขประจำตัวนักศึกษา : " + _studentCode, 350, _yStartPos, 0);

                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _facultyNameTh, 50, _yStartPos, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _programNameTh, 350, _yStartPos, 0);
                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนกิจกรรม : " + _countAct + " กิจกรรม", 50, _yStartPos, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนชั่วโมง : " + _countHour + " ชั่วโมง", 350, _yStartPos, 0); // 365
                                }
                                else
                                {
                                     Paragraph _programNameEnLong;

                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Name : " + _fullNameEn, 50, _yStartPos, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Student ID : " + _studentCode, 350, _yStartPos, 0);

                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Degree : " + _facultyNameEn, 50, _yStartPos, 0);
                                    _programNameEnLong = new Paragraph(_programNameEn, fontEn);

                                    // แสดงตรงชื่อ Club ที่ยาว
                                    ct.SetSimpleColumn(new iTextSharp.text.Rectangle(350, 350, _yStartPos, _yStartPos + 18));
                                    _programNameEnLong.SetLeading(Convert.ToSingle(1.32), Convert.ToSingle(1.32));// ระหว่างบรรทัด
                                    ct.AddElement(_programNameEnLong);
                                    status = ct.Go();
                                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "โคฟเวอร์แดนซ์ เต้นไปให้ถึงฝั่งฝัน ครั้งที่ 5 GRUJ 5", 436, _yStartPosBody, 0);
                                    if (_programNameEn.Length < 37) // 52
                                    {
                                        _countR = 1;
                                    }
                                    else
                                    {
                                        _countR = (_programNameEn.Length / 37) + 1;
                                    }
                                    _cb.EndText();
                                    _cb.BeginText();

                                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Major : "+_programNameEn, 350, _yStartPos, 0);
                                    _yStartPos = _yStartPos - _feedLineBig;
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total :  " + _countAct + " Activities , " + _countHour + " Hours", 50, _yStartPos, 0);
                                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "จำนวนชั่วโมง : " + _countHour + " ชั่วโมง", 350, _yStartPos, 0); // 365
                                }


                                



                                _cb.MoveTo(30, _ylinePos);
                                _cb.LineTo(570, _ylinePos);
                                _ylinePos = _ylinePos - 15;
                                _cb.MoveTo(30, _ylinePos);
                                _cb.LineTo(570, _ylinePos);
                                _cb.Stroke();
                                _cb.SetFontAndSize(_bfBold, _sizeFontMedium);
                                _yStartPos = _yStartPos - _feedLineBiggest;
                                _yStartPosBody = _yStartPosBody - 1;
                                if (_language == "th")
                                {
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ปี", 55, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "องค์กรนักศึกษา/ชมรม", 149, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ตำแหน่งที่ดำรง", 312, _yStartPosBody, 0); // 301
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ส่วนงาน", 475, _yStartPosBody, 0); // 495
                                }
                                else
                                {
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Year", 55, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Club/Organization", 149, _yStartPosBody, 0);
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Position", 312, _yStartPosBody, 0); // 313
                                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Faculty/Institute/Colledge", 475, _yStartPosBody, 0); // 495
                                }

                                _yStartPosBody = _yStartPosBody - 17;
                                _ylinePos = _ylinePos - 18;

                            }

                        }
                    }
                    else {
                        _cb.SetFontAndSize(_bf, 13);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 55, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 149, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 301, _yStartPosBody, 0); // 313
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 475, _yStartPosBody, 0); // 495
                    }




                    // ต้องเอามาเชคกรณีบางคนมีหน้าเดียว
                    _cb.MoveTo(30, 542);
                    _cb.LineTo(30, _ylinePos);

                    _cb.MoveTo(80, 542);
                    _cb.LineTo(80, _ylinePos);

                    _cb.MoveTo(255, 542); // 218
                    _cb.LineTo(255, _ylinePos); // 218

                    _cb.MoveTo(380, 542); // 425
                    _cb.LineTo(380, _ylinePos); // 425

                    _cb.MoveTo(570, 542);
                    _cb.LineTo(570, _ylinePos);

                    _cb.MoveTo(30, _ylinePos);
                    _cb.LineTo(570, _ylinePos);

                    _cb.Stroke();

                    _yStartPosBody = _yStartPosBody - 40;

                    string _countFixAct = "0";
                    string _projectCode = string.Empty;
                    string _projectName = string.Empty;
                    string _positionNameInProject = string.Empty;
                    string _sumHours = string.Empty;
                    double _totalHours = 0;
                    int _yStartPosStart2 = 0;
                    DataSet _ds1 = ActDB.getListActATHIDEF(_studentCode);
                    DataRow[] _drRow1 = _ds1.Tables[0].Select("projectTypeId in ('PJT-006')"); //กิจกรรมกำหนดให้เข้าร่วม  
                    int _row = _drRow1.Length;
                    if (_row > 0)
                    {
                        for (int _i = 0; _i < _row; _i++)
                        {
                            _sumHours = _drRow1[_i]["sumHours"].ToString();
                            _totalHours = _totalHours + Convert.ToDouble(_sumHours);
                        }
                    }
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "กิจกรรมกำหนดให้เข้าร่วม : จำนวน " + _row + " กิจกรรม", 50, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _totalHours.ToString() + " หน่วยชั่วโมง", 210, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Compulsory Activities : " + _row + " Activities", 50, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _totalHours.ToString() + " Hours", 184, _yStartPosBody, 0);
                    }
                    
                    
                    _yStartPosBody = _yStartPosBody - 22;
                    // header ส่วนของ กิจกรรมกำหนดให้เข้าร่วม
                    _cb.SetFontAndSize(_bfBold, _sizeFontMedium);
                    if (_language == "th")
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ลำดับ", 48, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ชื่อโครงการ", 254, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ตำแหน่ง", 454, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หน่วยชั่วโมง", 542, _yStartPosBody, 0);
                    }
                    else
                    {
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "No", 48, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Extracurricular Activity", 254, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Participated as", 454, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Credit Hrs.", 542, _yStartPosBody, 0);
                    }
                    _ylinePos = _ylinePos - 44;
                    _yStartPosStart2 = _ylinePos - 1;
                    _cb.MoveTo(30, _ylinePos - 1);
                    _cb.LineTo(570, _ylinePos - 1);
                    _ylinePos = _ylinePos - 16;
                    _cb.MoveTo(30, _ylinePos);
                    _cb.LineTo(570, _ylinePos);
                    _cb.Stroke();
                    _yStartPosBody = _yStartPosBody - 17;


                    if (_row > 0)
                    {
                        for (int _i = 0; _i < _row; _i++)
                        {

                            //_projectCode = _drRow1[_i]["projectCode"].ToString();
                            
                            if (_language == "th")
                            {
                                _projectName = _drRow1[_i]["projectNameTh"].ToString();
                                _positionNameInProject = _drRow1[_i]["positionNameTh"].ToString();
                            }
                            else
                            {
                                _projectName = _drRow1[_i]["projectNameDisplayEn"].ToString();
                                _positionNameInProject = _drRow1[_i]["positionNameEn"].ToString();

                            }
                            

                            _sumHours = _drRow1[_i]["sumHours"].ToString();

                            //Paragraph _projaectNameLong;
                            ////string _projectName = "พิธีปฐมนิเทศนักศึกษาใหม่ มหาวิทยาลัยมหิดล ประจำปีการศึกษา 2564";
                            //_projaectNameLong = new Paragraph(_projectName, fontTh);


                            _cb.SetFontAndSize(_bf, 11); // 13
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (_i + 1).ToString(), 43, _yStartPosBody, 0);

                            // แสดงตรงชื่อ ProjectName ที่ยาว
                            //ct.SetSimpleColumn(new iTextSharp.text.Rectangle(80, 80, 380, _yStartPosBody + 17)); // 392
                            //_projaectNameLong.SetLeading(Convert.ToSingle(1.2), Convert.ToSingle(1.2));// ระหว่างบรรทัด
                            //ct.AddElement(_projaectNameLong);
                            //status = ct.Go();

                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "พิธีปฐมนิเทศนักศึกษาใหม่ มหาวิทยาลัยมหิดล ทดสอบชื่อโครงการยาว ครั้งที่ 1 การขึ้นบรรทัดใหม่", 128, _yStartPosBody, 0); // ประจำปีการศึกษา 2564
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _projectName, 77, _yStartPosBody, 0);
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _positionNameInProject, 448, _yStartPosBody, 0); // 454
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _sumHours, 540, _yStartPosBody, 0);


                            //if (_projectName.Length < 63)
                            //{
                            //    _countR = 1;
                            //}
                            //else
                            //{
                            //    _countR = (_projectName.Length / 63) + 1;
                            //}

                            _countR = 1;
                            _yStartPosBody = _yStartPosBody - (15 * _countR);


                        }
                    }
                    else 
                    {
                        _cb.SetFontAndSize(_bf, 13);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 76, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 254, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 454, _yStartPosBody, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "-", 542, _yStartPosBody, 0);
                        _yStartPosBody = _yStartPosBody - 6;
                    }



                    _cb.MoveTo(30, _yStartPosStart2);
                    _cb.LineTo(30, _yStartPosBody);

                    _cb.MoveTo(64, _yStartPosStart2); // 120
                    _cb.LineTo(64, _yStartPosBody); // 120

                    _cb.MoveTo(392, _yStartPosStart2);
                    _cb.LineTo(392, _yStartPosBody);

                    _cb.MoveTo(512, _yStartPosStart2);
                    _cb.LineTo(512, _yStartPosBody);

                    _cb.MoveTo(570, _yStartPosStart2);
                    _cb.LineTo(570, _yStartPosBody);

                    _cb.MoveTo(30, _yStartPosBody);
                    _cb.LineTo(570, _yStartPosBody);
                    _cb.Stroke();
                }


            }
            else if (_conditionReport >= 60) // รหัสนักศึกษาที่เป็น 60
            {
                _cb.MoveTo(30, _ylinePos);
                _cb.LineTo(570, _ylinePos);
                _ylinePos = _ylinePos - 15;
                _cb.MoveTo(30, _ylinePos);
                _cb.LineTo(570, _ylinePos);
                _cb.Stroke();

                
                _yStartPos = _yStartPos - _feedLineBiggest;

                if (_language == "th")
                {
                    _cb.SetFontAndSize(_bfBold, _sizeFontMedium);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "รหัสโครงการ", 50, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อโครงการ", 175, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ตำแหน่ง", 363, _yStartPosBody, 0); // 348

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หน่วยชั่วโมง", 521, _yStartPosBody, 0); // 520
                }
                else 
                {
                    _cb.SetFontAndSize(_bfBold, 12);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Activity Code", 43, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Extracurricular Activity", 170, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Participated as", 355, _yStartPosBody, 0); // 348

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Credit Hrs.", 525, _yStartPosBody, 0); // 520

                }

                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "M", 420, _yStartPosBody, 0); // 410
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A", 435, _yStartPosBody, 0); // 425
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "H", 450, _yStartPosBody, 0); // 440
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "I", 466, _yStartPosBody, 0); // 456 
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "D", 480, _yStartPosBody, 0); // 470
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "O", 495, _yStartPosBody, 0); // 485
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "L", 510, _yStartPosBody, 0); // 500
                

            }
            else
            {
                _cb.MoveTo(30, _ylinePos);
                _cb.LineTo(570, _ylinePos);
                _ylinePos = _ylinePos - 15;
                _cb.MoveTo(30, _ylinePos);
                _cb.LineTo(570, _ylinePos);
                _cb.Stroke();

                
                _yStartPos = _yStartPos - _feedLineBiggest;
                if (_language == "th")
                {
                    _cb.SetFontAndSize(_bfBold, _sizeFontMedium);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "รหัสโครงการ", 46, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อโครงการ", 182, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ตำแหน่ง", 384, _yStartPosBody, 0);  // 375
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หน่วยชั่วโมง", 518, _yStartPosBody, 0);
                }
                else
                {
                    _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Activity Code", 43, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Extracurricular Activity", 180, _yStartPosBody, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Participated as", 376, _yStartPosBody, 0);  // 375
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Credit Hrs.", 522, _yStartPosBody, 0);
                }

                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A1", 440, _yStartPosBody, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A2", 460, _yStartPosBody, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A3", 480, _yStartPosBody, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A4", 500, _yStartPosBody, 0);
                
            }
        }
        _yStartPosBody = _yStartPosBody - _feedLineBig;


        if (_conditionReport >= 62)
        {

        }
        else 
        if (_conditionReport >= 60)
        {
            _cb.MoveTo(30, 57);
            _cb.LineTo(570, 57);
            _cb.SetFontAndSize(_bf, _sizeFontSmalless);
            int _yFooter = 50;
            if (_language == "th")
            {
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หมายเหตุ", 50, _yFooter, 0); // 50 60
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "M", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mastery", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  รู้แจ้ง รู้จริง สมเหตุ สมผล", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Altruism", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  มุ่งผลเพื่อผู้อื่น", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "H", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Harmony", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  กลมกลืนกับสรรพสิ่ง", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "I", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Integrity", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  มั่นคงยิ่งในคุณธรรม", 95, _yFooter, 0);

                _yFooter = 40;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "D", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Determination", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  แน่วแน่ทำกล้าติดสินใจ", 390, _yFooter, 0);

                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "O", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Originality", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  สร้างสรรค์สิ่งใหม่", 390, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "L", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Leadership", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":  ใฝ่ใจเป็นผู้นำ", 390, _yFooter, 0);
            }
            else
            {

                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mahidol University Competencies:", 50, _yFooter, 0); // 50 60
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "M", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mastery", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Altruism", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "H", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Harmony", 95, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "I", 50, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 62, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Integrity", 95, _yFooter, 0);

                _yFooter = 40;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "D", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Determination", 390, _yFooter, 0);

                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "O", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Originality", 390, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "L", 330, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 342, _yFooter, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Leadership", 390, _yFooter, 0);

            }
            _cb.Stroke();
        }
        else
        {
            _cb.MoveTo(30, 57);
            _cb.LineTo(570, 57);
            _cb.SetFontAndSize(_bf, _sizeFontSmalless);
            int _yFooter = 50;
            if (_language == "th")
            {
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หมายเหตุ", 50, _yFooter, 0); // 50  60
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A1 : ด้านคุณธรรม จริยธรรมและบำเพ็ญประโยชน์", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A2 : ด้านวินัยและทักษะสังคม วิชาชีพ วิชาการ และจิตตปัญญาศึกษา", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A3 : ด้านศิลปวัฒนธรรม ภูมิปัญญาท้องถิ่น และค่านิยมที่ถูกต้อง", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A4 : ด้านเสริมสร้างสุขภาพ", 50, _yFooter, 0);
                _cb.Stroke();
            }
            else
            {
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mahidol University Competencies:", 50, _yFooter, 0); // 50  60
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A1 : Moral, ethics and volunteer", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A2 : Discipline, social skill, profession, academic and transformative learning", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A3 : Art and cultural, local wisdom and social value", 50, _yFooter, 0);
                _yFooter = _yFooter - 10;
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "A4 : Health promotion", 50, _yFooter, 0);
                _cb.Stroke();

            }
        }

        




    }

    public void LineBorderTable(int _conditionReport, PdfContentByte _cb,string _statusFirstPage,string _stsNoBorder,BaseFont _bfBold,string _language)
    {
        int _yForLine = 0;
        if (_statusFirstPage == "1")
        { 
            _yForLine = 542; // 542
        }
        else // ถ้าไม่ใช่หน้าแรก จะ 602 เพราะตัดเรื่องพวก Profile
        {
            _yForLine = 602; // 602
        }

        if (_stsNoBorder == "0")
        {
            if (_conditionReport >= 62)
            {
                _yStartPosBody = _yStartPosBody - 30;
                _cb.SetFontAndSize(_bfBold, _sizeFontSmall);
                if(_language=="th")
                {
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ลำดับ", 37, _yStartPosBody - 44, 0); // 55
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ชื่อโครงการ", 178, _yStartPosBody - 44, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ตำแหน่ง", 294, _yStartPosBody - 44, 0);
                }
                else
                {
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "No", 37, _yStartPosBody - 44, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Extracurricular Activity", 178, _yStartPosBody - 44, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Participated as", 294, _yStartPosBody - 44, 0);
                }
                
                
                _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Volunteer", 338, _yStartPosBody - 44, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "HIDEF", 397, _yStartPosBody + 10, 0);

                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Health Literacy", 358, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Internationalization", 378, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Digital Literacy", 398, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Environmental Literacy", 418, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Financial Literacy", 438, _yStartPosBody - 102, 90);

                _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "21st Century Skills", 496, _yStartPosBody + 10, 0);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Critical Thinking & Problem", 458, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Creativity & Innovation", 478, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Communication", 498, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Leadership & Management", 518, _yStartPosBody - 102, 90);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Social skill", 538, _yStartPosBody - 102, 90);
                if (_language == "th")
                {
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "หน่วยชั่วโมง", 558, _yStartPosBody - 44, 90);
                }
                else
                {
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Credit Hrs.", 558, _yStartPosBody - 44, 90);
                }
                    



                _yStartPosBody = _yStartPosBody - 122;

            }
            else if (_conditionReport >= 60)
            {

                _cb.MoveTo(30, _yForLine); // 610
                _cb.LineTo(30, _ylinePos - 5);
                _cb.MoveTo(415, _yForLine); // 415
                _cb.LineTo(415, _ylinePos - 5);
                _cb.MoveTo(430, _yForLine); // 420 
                _cb.LineTo(430, _ylinePos - 5);
                _cb.MoveTo(445, _yForLine); // 435 
                _cb.LineTo(445, _ylinePos - 5);
                _cb.MoveTo(460, _yForLine); // 450
                _cb.LineTo(460, _ylinePos - 5);
                _cb.MoveTo(475, _yForLine); // 465
                _cb.LineTo(475, _ylinePos - 5);
                _cb.MoveTo(490, _yForLine); // 480
                _cb.LineTo(490, _ylinePos - 5);
                _cb.MoveTo(505, _yForLine); // 495
                _cb.LineTo(505, _ylinePos - 5); // 495
                _cb.MoveTo(520, _yForLine); // 510
                _cb.LineTo(520, _ylinePos - 5); // 510
                _cb.MoveTo(570, _yForLine);
                _cb.LineTo(570, _ylinePos - 5);
                _cb.MoveTo(30, _ylinePos - 5);
                _cb.LineTo(570, _ylinePos - 5);
                _cb.Stroke();
            }
            else
            {

                _cb.MoveTo(30, _yForLine);// 610
                _cb.LineTo(30, _ylinePos - 5);
                _cb.MoveTo(435, _yForLine);
                _cb.LineTo(435, _ylinePos - 5);
                _cb.MoveTo(455, _yForLine);
                _cb.LineTo(455, _ylinePos - 5);
                _cb.MoveTo(475, _yForLine);
                _cb.LineTo(475, _ylinePos - 5);
                _cb.MoveTo(495, _yForLine);
                _cb.LineTo(495, _ylinePos - 5);
                _cb.MoveTo(515, _yForLine);
                _cb.LineTo(515, _ylinePos - 5);
                _cb.MoveTo(570, _yForLine);
                _cb.LineTo(570, _ylinePos - 5);
                _cb.MoveTo(30, _ylinePos - 5);
                _cb.LineTo(570, _ylinePos - 5);
                _cb.Stroke();
            }
        }

    }


    public int numDigitForCheckStringThai(string _strNameLast,string _strName2Last,string _strName2LastBefore,string _strNameLastBefore,string _strName4LastBefore,string _strName3LastBefore, string _strName2LastBeforable)
    {
        //_strName4LastBefore = หาภู
        int _numDigitRotate = 0;
        // สำหรับฟังก์ช่นการตัดคำภาษาไทยของโครงการที่ยาวให้สละสลวย 
        //  _strName4LastBefore ครีย

        if (
             (new string[] { "าชกุ" }).Any(x => x == _strName4LastBefore)

            )
        {
            _numDigitRotate = 5;
        }
        else if (
             (new string[] { "ิ่", "่ว" }).Any(x => x == _strName2Last)
             || (new string[] { "เรี", "สร้", "เสด" }).Any(x => x == _strName3LastBefore)
             || (new string[] { "ึก" }).Any(x => x == _strName2LastBefore)
             || (new string[] { "ุคลา", "าชกุ" , "หาภู" }).Any(x => x == _strName4LastBefore)


            )
        {
            _numDigitRotate = 3;
        }
        else if (

               (new string[] { "ุ", "่ว", "ู" }).Any(x => x == _strNameLast)
            || (new string[] { "าม", "ระ", "ึก", "ิจ", "รี", "าพ", "ัย" }).Any(x => x == _strName2Last) // , "าร"

            || (new string[] { "ช่ว", "พื่", "ใหญ", "อุด", "เจ้", "ร่ว" }).Any(x => x == _strName3LastBefore)
            || (new string[] { "ครีย" , "เฉลิ" }).Any(x => x == _strName4LastBefore)
            || (new string[] { "ุ" }).Any(x => x == _strNameLastBefore)
            //(_strName2Last == "าม") || (_strName2LastBefore == "ึก") || (_strName2Last == "ระ") || (_strName3LastBefore == "ช่ว") || (_strName2Last == "าร") || (_strName2Last == "ึก") || (_strName2Last == "ิจ")
            //|| (_strNameLast == "ุ") || (_strName3LastBefore == "255")




            )
        {
            _numDigitRotate = 2;
        }
        else if ((new string[] { "ญจนบ", "ิทยา" }).Any(x => x == _strName4LastBefore)
          )
        {
            _numDigitRotate = 4;
        }

        else if ( (new string[] { "าร" }).Any(x => x == _strName2Last)
            || (new string[] { "กันย" }).Any(x => x == _strName4LastBefore)
            || (new string[] { "ุง" }).Any(x => x == _strName2LastBefore)

            ) 
        {
            _numDigitRotate = -3;
        }
        else if ((new string[] { "เ", "โ", "ไ", "ใ", "แ" }).Any(x => x == _strNameLastBefore)
             || (new string[] { "25","ma", "วิ","อา", "น้" }).Any(x => x == _strName2LastBefore)
             || (new string[] { "หิ", "้ำ", "ปร" }).Any(x => x == _strName2Last)
             || (new string[] { "ทพรั" }).Any(x => x == _strName4LastBefore)

             )

        {
            _numDigitRotate = -1;
        }
        else if ((new string[] { "25" ,"โน"}).Any(x => x == _strName2LastBeforable) 
             || (new string[] { "ร็" }).Any(x => x == _strName2Last)
             || (new string[] { "ิจ" }).Any(x => x == _strName2LastBefore)

    

            )
        {
            _numDigitRotate = -2;
        }
        else if ((new string[] { "มัคร"}).Any(x => x == _strName4LastBefore)
            || (new string[] {  "มิ" }).Any(x => x == _strName2LastBeforable)
            )
        {
            _numDigitRotate = -4;
        }
        else if ((new string[] {  "ษา 2" }).Any(x => x == _strName4LastBefore)
           )
        {
            _numDigitRotate = -6;
        }
        //else if ((_strNameLast == "ำ") || (_strNameLast == "่") || (_strNameLast == "ี") || (_strNameLast == "ุ") || (_strNameLast == "ึ") || (_strNameLast == "็")
        // || (_strNameLast == "๊") || (_strNameLast == "ั") || (_strNameLast == "ิ") || (_strNameLast == "์") || (_strNameLast == " ") || (_strNameLast == "ไ") 
        // || (_strNameLast == "ใ") || (_strNameLast == "า") || (_strNameLast == "๋") || (_strName2LastBefore == "ิด") || (_strName4LastBefore=="แปลง") || (_strName3LastBefore == "การ") || (_strName2LastBefore =="25") || (_strName3LastBefore == "ญจน") )
        //{
        else if (((new string[] { "ำ", "่", "ี", "ุ", "ึ", "็", "๊", "ั", "ิ", "์", " ", "า", "๋", "ะ" }).Any(x => x == _strNameLast)) 
              || (new string[] { "ิด","25" }).Any(x => x == _strName2LastBefore) //  เคส 25
              || (new string[] { "การ", "ญจน", "มรม" }).Any(x => x == _strName3LastBefore)
              || (new string[] { "แปลง", "2561","2560", "2559", "2558", "2557", "หิดล" , "ะชนม" }).Any(x => x == _strName4LastBefore)
              || (new string[] { "ิ", "า","ั","็","๊" }).Any(x => x == _strNameLastBefore) 
              || (new string[] { "ดล" }).Any(x => x == _strNameLastBefore + _strNameLast) )
            


        {
            _numDigitRotate = 1; 
        }
        else //            || (new string[] {"ไ", "ใ" }).Any(x => x == _strNameLast)
        {
            _numDigitRotate = 0;
        }

        return _numDigitRotate;


    }





    




}