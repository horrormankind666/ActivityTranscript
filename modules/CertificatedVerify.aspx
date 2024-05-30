<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertificatedVerify.aspx.cs" Inherits="modules_CertificatedVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<link rel="stylesheet" href="https://site-assets.fontawesome.com/releases/v6.1.1/css/all.css"   >
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
<head runat="server">

    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container-fluid align-items-center text-center">
            <center>
            <div class="card " style="width: 58rem; ">
                <div class="card-header text-center ">
                    <img src="../images/logo.png" style="width:60px;" class="" /><b style="font-size:20px;"> MAHIDOL UNIVERSITY CERTIFICATE VERIFY SYSTEM</b>
                </div>
                <br>
                <div class="embed-responsive embed-responsive-21by9" >
                  <iframe class="embed-responsive-item " style="width:85%;height:400px;" src="https://smartedu.mahidol.ac.th/ActivityTranscript/modules/GenCertificated.aspx" allowfullscreen></iframe>
                </div>
                <%--<img src="../images/logo.png" style="width:150px;" class="card-img-top align-items-center" />--%>
                <div class="card-body">
                  <%--  <h5 class="card-title">Topic Cer</h5>--%>
                  
                        <table class="table table-bordered ">
                
                            <tr class="">
                              <td class="table-active " style="width:38%;"><b>Status verify :</b> </td>
                              <td><b><i class="fa-solid fa-check text-success " style="font-size:20px;" ></i></b></td>
                            </tr>
                            <tr class="">
                              <td class="table-active" ><b>Date of verify :</b> </td>
                              <td>20/06/2022</td>
                            </tr>
                            <tr class="">
                              <td class="table-active" ><b>Certification date :</b> </td>
                              <td>27/06/2022 - 26/06/2023</td>
                            </tr> 
                            <tr class="">
                              <td class="table-active" ><b>Issued by :</b> </td>
                              <td>กองแผนงาน สำนักงานอธิการบดี มหาวิทยาลัยมหิดล</td>
                            </tr>
                            
                         
                        </table>

                  
                    <p class="card-text text-left " style="font-size:16px;">เว็บไซต์นี้ใช้สำหรับยืนยันเอกสารที่ได้รับการตรวจสอบการใบ Certificate ว่าเป็นเอกสารที่ได้ผ่านการรับรองจริงโดยมหาวิทยาลัยเท่านั้น</p>
               <%--     <a href="#" class="btn btn-primary">Go somewhere</a>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
