using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;

public partial class modules_GenCertificated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string phrase = "1,2,3,4,5";
        //string[] words = phrase.Split(',');
        //int i = 0;
        //string valueBeforeLast = string.Empty;
        //foreach (var word in words)
        //{
        //    i++;
        //    if (i == words.Count() - 1)
        //    {
        //        valueBeforeLast = word;
        //    }
        //}


        //string docId = "FrgdIUe-o033Ghf";
        //bool isThai = true;
        //ServiceGeneratePDF(docId, isThai);
    }

    public void ServiceGeneratePDF(string docId,bool isThai)
    {
        string path = Server.MapPath("~");
        Response.Charset = String.Empty;
        Response.ClearContent();
        Response.ContentType = "application/PDF";
        Document document = new Document();
        PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
        document.SetPageSize(iTextSharp.text.PageSize.A4);
        document.Open();
        PdfContentByte cb = writer.DirectContent;
        BaseFont bf = BaseFont.CreateFont(path + "\\fonts\\THSarabun.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        BaseFont bfBold = BaseFont.CreateFont(path + "\\fonts\\THSarabun Bold.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        cb.BeginText();
        generatePosition(path, document, cb, bf, bfBold, isThai);
        //cb.SetFontAndSize(bf, 12);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ทดสอบ", 198, 500, 0);
        cb.EndText();
        document.Close();
        Response.Write(document);
        Response.End();

    }


    public void generatePosition(string path, Document document, PdfContentByte cb, BaseFont bf, BaseFont bfBold, bool isThai)
    {
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(path + "\\images/logo.png");
        img.SetAbsolutePosition(265, 680);
        img.ScaleAbsolute(1500f, 0f);
        img.ScalePercent(0.8f * 72);
        document.Add(img);

        string docNumber = "MU-01-2022/00001";
        string headName1 = "MAHIDOL UNIVERSITY ACCREDITATION CENTER (MAC)";
        string headName2 = "เอกสารแสดงผลการทดสอบจากห้องปฏิบัติการ";
        //string headName3 = "ห้องปฏิบัติการ";///"ประเภท การให้บริการตรวจวิเคราะห์โดยห้องปฏิบัติการ";

        int xRight = 570;
        cb.SetFontAndSize(bfBold, 14);
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ใบทะเบียนเลขที่ " + docNumber, xRight, 800, 0);

        cb.SetFontAndSize(bfBold, 18);
        int x = 313;
        int y = 655;
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, headName1, x, y, 0);
        y = y - 30;
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, headName2, x, y, 0);
        //y = y - 30;
        //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, headName3, x, y, 0);

        y = y - 45;

        string productName = "เบซูโตะ เมาท์ สเปรย์";
        string productionDate = "20 ก.ค. 2564";
        string testDate = "12 ก.พ. 2565";
        string resultDate = "7 มี.ค. 2565";
        string topicTestName = "ความเป็นกรดเป็นด่างของน้ำ";
        string testMethod = "ทดสอบความเป็นกรดเป็นด่างของน้ำ";
        string benchmark = "การตรวจและวิเคราะห์คุณภาพน้ำทิ้งตามวิธีมาตรฐาน AWWA";
        // string benchmark2 = "the Activity of Microbicides against Viruses in Suspension";

        string testResults = "ตรวจวิเคราะห์ประสิทธิภาพของผลิตภัณฑ์มีผลต่อการฆ่าเชื้อไวรัส";
        string certifierName = "ดร.เจตน์ เครือชะเอม";
        string locationName = "ห้องปฏิบัติการ ABC";
        string certificationStartDate = "27 มิ.ย. 2565";
        string certificationEndDate = "26 มิ.ย. 2566";
        string detailLab = "26 มิ.ย. 2566";

        int xBody1 = 50;
        int xBody2 = 70;
        int xIndentData = 215;
        int xIndentData2 = 130;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อห้องปฏิบัติการ", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, locationName, xIndentData, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "2.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ที่ตั้งห้องปฏิบัติการ" , xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "999 ถนนพุทธมณฑลสาย 4 ต.ศาลายา อ.พุทธมณฑล จ.นครปฐม 73170", xIndentData, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หัวข้อการทดสอบ", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, topicTestName, xIndentData, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "4.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "วันที่ทำการทดสอบ", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, testDate, xIndentData, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "5.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "วิธีการทดสอบ", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, testMethod, xIndentData, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "6.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ผลการทดสอบ", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "มีความเป็นกรดสูงเกินค่ามาตรฐาน", xIndentData, y, 0);


        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "7.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "เกณฑ์มาตรฐาน", xBody2, y, 0);
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, benchmark, xIndentData, y, 0);

        //y = y - 24;
        ////cb.SetFontAndSize(bfBold, 16);
        ////cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "7.", xBody1, y, 0);
        ////cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "เกณฑ์มาตรฐาน", xBody2, y, 0);
        //cb.SetFontAndSize(bf, 16);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, benchmark2, xIndentData, y, 0);

        

        y = y - 30;
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "8.", xBody1, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อและลายมือชื่อผู้รับรองการทดสอบ", xBody2, y, 0);

        y = y - 30;
        cb.SetFontAndSize(bf, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, certifierName, xIndentData2, y, 0);

        iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(path + "\\images/SignExample.jpg");
        imgSign.SetAbsolutePosition(xIndentData2 + 150, y - 24);
        imgSign.ScaleAbsolute(1500f, 0f);
        imgSign.ScalePercent(0.2f * 72);
        document.Add(imgSign);

        //y = y - 24;
        //cb.SetFontAndSize(bfBold, 16);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "10.", xBody1, y, 0);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ชื่อและสถานที่ตั้งของห้องปฏิบัติการทดสอบ", xBody2, y, 0);

        //y = y - 24;
        //cb.SetFontAndSize(bf, 16);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, locationName, xIndentData2, y, 0);

        //y = y - 24;
        //cb.SetFontAndSize(bfBold, 16);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "9.", xBody1, y, 0);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "วันที่ออกใบรับรอง", xBody2, y, 0);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ระยะเวลาการรับรอง", xBody2 + 240 , y, 0);
        //cb.SetFontAndSize(bf, 16);
        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, certificationStartDate, xIndentData, y, 0);
      //  cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, certificationEndDate, xIndentData + 220, y, 0);

        y = y - 70;

   
        // int xFooter = 450;
        string issuedBy = "กองแผนงาน สำนักงานอธิการบดี";
        string issuedDate = "20 มิ.ย. 2565";
        cb.SetFontAndSize(bfBold, 16);
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ออกให้โดย  " + issuedBy, xRight, y + 15, 0);

        y = y - 24;
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ณ วันที่  " + issuedDate, xRight, y + 15, 0);

        //y = y - 24;
        //cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "วันสิ้นสุดการรับรอง  " + certificationEndDate, xRight, y, 0);

        // เส้น QR Code
        cb.SetLineWidth(0.6f);
        cb.SetGrayStroke(0.1f); // 1 = white, 0 = black

        y = y - 24;
        y = y - 24;
        y = y - 24;
        y = y - 33;


        cb.SetFontAndSize(bfBold, 14);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "QR Code" , 80, y + 8, 0);
        // เส้นแนวตั้งซ้าย
        cb.MoveTo(40, 160);
        cb.LineTo(40, 90);

        // เส้นแนวตั้งขวา
        cb.MoveTo(120, 160);
        cb.LineTo(120, 90);

        // เส้นบน
        cb.MoveTo(40, 160);
        cb.LineTo(120, 160);

        // เส้นล่าง
        cb.MoveTo(40, 90);
        cb.LineTo(120, 90);

        cb.Stroke();

        iTextSharp.text.Image imgQR = iTextSharp.text.Image.GetInstance(path + "\\images/QRcodeCertificate.png");
        imgQR.SetAbsolutePosition(55, y - 45);
        imgQR.ScaleAbsolute(1500f, 0f);
        imgQR.ScalePercent(0.047f * 72);
        document.Add(imgQR);



        y = y - 82;
        cb.SetFontAndSize(bfBold, 14);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "หมายเหตุ", 95, y, 0);
        string remark = "ผลวิเคราะห์นี้ใช้รับรองเฉพาะตัวอย่างที่ส่งมาให้เท่านั้น ห้ามนำรายงานนี้ไปประกาศโฆษณา";
        string remark2 = "ห้ามคัดลอกรายงานผลวิเคราะห์เพียงบางส่วน ยกเว้นทั้งหมด";
        //cb.SetFontAndSize(bf, 14);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1.", 138, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 149, y, 0);
        y = y - 22;
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "2.", 138, y, 0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark2, 149, y, 0);

        cb.SetLineWidth(0.6f);
        cb.SetColorStroke(new BaseColor(Color.Red));

        cb.MoveTo(40, 75);
        cb.LineTo(40, 28);

        cb.MoveTo(570, 75);
        cb.LineTo(570, 28);

        cb.MoveTo(40, 75);
        cb.LineTo(570, 75);

        cb.MoveTo(40, 28);
        cb.LineTo(570, 28);
        
        cb.Stroke();


    }





}