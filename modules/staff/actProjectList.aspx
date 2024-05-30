<%@ Page Language="C#" AutoEventWireup="true" CodeFile="actProjectList.aspx.cs" Inherits="modules_staff_actProjectList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
        .tab-content {
     
          background-color: #F6FAFD;
          padding : 5px 15px;
        }
        
        @media screen and (min-width: 800px) {
	         #divPopup .modal-dialog  {width:900px;}
        }
        
        @media screen and (min-width: 900px) {
	         #divSpiderGraph .modal-dialog  {width:1000px;}
        }
        
        @media screen and (min-width: 900px) {
	         #divSpiderGraphFacultyLevel .modal-dialog  {width:1000px;}
        }
        
        @media screen and (min-width: 900px) {
	         #divSpiderGraphUniversityLevel .modal-dialog  {width:1100px;}
        }
        
</style>
    <title></title>
     
</head>
<body>
    <form id="form1" runat="server">
    <div class='container-fluid ' >

            <div class='divBarMenu' >
            </div>

            <div class="col-md-2 page-header divSlideBarMenu" >
            </div>

            
            <div style="padding-top:25px;" class="col-md-10 divGetListProject"  >
            </div>

    </div>

    <div id="divPopup"   class='modal fade ' role='dialog'>
    </div>

<%--        <table id="tblTest">
            <tr>
                <td><input type="checkbox" class="chkStudent" data-studentcode="5901001"  checked/></td>
                <td class="stdCode">5901001_html</td>
            </tr>
            <tr>
                <td><input type="checkbox" class="chkStudent" data-studentcode="5901002"  /></td>
                <td class="stdCode">5901002_html</td>
            </tr>
        </table>

        <input onclick="checkTest()" type="button" value="OK"/>--%>

<div id="divPopupContent" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog modal-dialog-centered modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 class="modal-title">MU Activity Transcript</h3>
      </div>

      <div class="modal-body">       
           <img src="../../images/atsurvey.png" class="img-responsive" />
           <p class="h2 text-center"><a href="https://forms.office.com/r/nU8vAJ8FHg">https://forms.office.com/r/nU8vAJ8FHg</a></p>
      </div>

      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

    </form>


</body>
</html>
<script type="text/javascript">




     //if (confirm("ขอรบกวนผู้ใช้งาน ประเมินแบบสอบถามความพึงพอใจต่อการใช้งานระบบ ")) {
     //   window.open("https://docs.google.com/forms/d/e/1FAIpQLSdIfvO7b-9vW9yVWkuUIx7IiYUhlzEyTmEBdMq-_kkoAP_qNQ/viewform?usp=pp_url&entry.1320515055=%E0%B8%A3%E0%B8%B0%E0%B8%9A%E0%B8%9A+Activity+Transcript", "_blank");
     //}

    //function checkTest() {
    //    var _tb = $("#tblTest");
    //    var _count = 0;

    //    var _chkStudentRegistSection = _tb.find(".chkStudent");
    //    $(_chkStudentRegistSection).each(function (index) {
    //        if ($(this).is(':checked')) {
    //            alert($(this).parent().find(".stdCode").html());
    //        }
    //    });
    //}
      loadBarMenu();

     var pictureName;
     var extName;

    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2560
    // Perpose: แสดงเมนู Menu bar
    // Method : loadBarMenu
     function loadBarMenu() {
     
        var _post = $.param({ action: "loadBarMenu"
        });
        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divBarMenu").html(data);
                $('.btnLogout').click(function () {
                    //alert();
                    window.open('', '_self', '');
                    window.close();
                });

                loadSlidebarMenu();

            },
            error: function (data) {
          
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2560
    // Perpose: แสดงเมนู Side bar
    // Method : loadSlidebarMenu
    function loadSlidebarMenu() {
        var _post = $.param({ action: "loadSlidebarMenu"
        });
        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divSlideBarMenu").html(data);
                getListProject("","","","","");
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2560
    // Perpose: List รายการข้อมูลโครงการทั้งหมดของคณะนั้นๆ
    // Method : getListProject
    function getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName , _createdBy) {
        
       
        var _post = $.param({
            action: "getListProject", ddlAcaYear: _ddlAcaYear, ddlSemester: _ddlSemester
            , ddlFaculty:_ddlFaculty, projectName:_projectName , createdBy:_createdBy
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            //beforeSend: function () { loading(); },
            success: function (data) {
                $(".divGetListProject").html(data);
                getlistProjectMainList(_createdBy);
                
              
                $('.ddlAcaYear').change(function () {
                    getlistProjectMainList();
                });
                $('.ddlSemester').change(function () {
                    getlistProjectMainList();
                });
                $('.ddlFaculty').change(function () {
                    getlistProjectMainList();
                });
                $('.ddlProjectStatus').change(function () {
                    getlistProjectMainList();
                });
                $('.btnSearchProjectMain').click(function () {
                    getlistProjectMainList();
                });
                $('.txtProjectName').on('keypress', function (e) {
                    if (e.which === 13) {
                        getlistProjectMainList();
                        return false;
                    }
                });
        
                $('.btnAddNewProject').click(function () {
                    LoadPageAddNewProject();
                });

                $(".divSlideBarMenu").find(".btnLoadTabProject").click(function () {
                    getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName , "");
                });

                $(".divSlideBarMenu").find(".btnLoadTabConfig").click(function () {
                    getListConfigManage("0");
                });

                $(".divSlideBarMenu").find(".btnLoadApprovePage").click(function () {
                    LoadApprovePage();
                });


                $(".divSlideBarMenu").find(".btnLoadReport").click(function () {
                    getListReport();
                });

                $(".divSlideBarMenu").find(".btnLoadRptStatisticFac").click(function () {
                    getListRptStatisticFac();
                });

                $(".divSlideBarMenu").find(".btnLoadStudent").click(function () {
                    getListLoadStudent();
                });

                $(".divSlideBarMenu").find(".btnLoadStudentCompleteActivity").click(function () {
                    pageStudentCompleteActivity();
                });

                $(".divSlideBarMenu").find(".btnPrintActivityTranscript").click(function () {
                    pagePrintActivityTranscript();
                });

                $(".divSlideBarMenu").find(".btnManageClub").click(function () {
                    panelManageClub();
                });

                $(".divSlideBarMenu").find(".btnPrintSpiderGraph").click(function () {
                    pageTabSpiderGraph();
                });

                $(".divSlideBarMenu").find(".btnPanelReportStudent").click(function () {
                    panelReportStudent();
                });


                $(".divSlideBarMenu").find(".btnLoadContractUs").click(function () {
                    getListLoadContactUs();
                });

                $(".divSlideBarMenu").find('.btnSurveySystem').click(function () {
                    $('#divPopupContent').modal({ show: true });
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    function panelManageClub() {
        var _post = $.param({
            action: "panelManageClub"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divGetListProject").html(data);
                $(document).ready(function () {
                    $('#tblListClub').DataTable();
                });
                $(".divGetListProject").find('.btnAddNewClub').click(function () {
                    setNewClub();
                });  
                //$(".divGetListProject").find('.btnEditClub').click(function () {
                //    var _clubId = $(this).data("clubid");
                //    dialogEditClub(_clubId);
                //});
                $(".divGetListProject").find('.btnDelClub').click(function () {
                    var _clubId = $(this).data("clubid");
                    setCancelClub(_clubId);
                });

                $(".ddlClub").change(function () {
                    var _ddlClubVal = $(this).val();
                    getListStudentInClubByClubId(_ddlClubVal);
                });

                $("#divClub2").find('.btnAddNewMember').click(function () {
                    addNewMemberInClubByStudentCode();
                });
                $("#divClub2").find('.btnUploadNewMember').click(function () {
                    addNewMemberInClubByFile();
                });

                $('#uploadStudentClub').change(function () {
                    // Page.Preload.Show();
                    var fullPath = document.getElementById('uploadStudentClub').value;
                    var filename;
                    var extname;
                    if (fullPath) {
                        startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                        var filename = fullPath.substring(startIndex);
                        if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                            filename = filename.substring(1);
                            extname = getExtension(filename);
                        }


                    }
                    $("form").attr({
                        "target": "uploadframeStudentClubExcel",
                        "action": "actProjectHandler.ashx?action=uploadStdRegist&filename=" + filename + "&extname=" + extname,
                        "enctype": "multipart/form-data"
                    });
                    $("form").submit();
                });

                $("#uploadframeStudentClubExcel").ready(function () {
                    console.log($("#uploadframeStudentClubExcel").contents());
                });

                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }
    function addNewMemberInClubByFile() {
        var _ddlClub = $("#divClub2").find('.ddlClub').val();
        var _ddlAcaYear = $("#divClub2").find('.ddlAcaYear').val();
        var _ddlSemester = $("#divClub2").find('.ddlSemester').val();
        var _uploadStudentClub = $("#divClub2").find('#uploadStudentClub').val();

        if (_ddlClub == "") {
            alert("กรุณาเลือกชมรม");
            $("#divClub2").find('.ddlClub').focus();
            return;
        }
        else if (_uploadStudentClub == "") {
            alert("กรุณาเลือกไฟล์ Excel ที่ต้องการอัพโหลดข้อมูล");
            $("#divClub2").find('#uploadStudentClub').focus();
            return;
        }
        else {
            //alert(pictureName);
            //alert(extName);
            //return;
            if (confirm("ยืนยันการบันทึกข้อมูล")) {
                var _post = $.param({
                    action: "setNewStudentInClubByFile",
                    fileName: pictureName + "." + extName,
                    extName: extName,
                    ddlClub: _ddlClub,
                    ddlAcaYear: _ddlAcaYear,
                    ddlSemester: _ddlSemester
                });
                Page.Preload.Show();

                $.ajax({
                    type: "POST",
                    url: "actProjectHandler.ashx",
                    data: _post,
                    success: function (data) {
                        Page.Preload.Hide();
                        if (data == "1") {
                            alert("บันทึกข้อมูลเรียบร้อยแล้ว");
                            getListStudentInClubByClubId(_ddlClub);
                        }
                        else if (data == "0") {
                            alert("กรุณากรอกข้อมูลใน Excel file");
                        }
                        else {
                            alert(data);
                        }
                        // $("#divPanelStdInClubList").html(data);
                        // $(".tblStudentRegistTempExcel").append(data);
                        // $("#divSectionStudentRegistExcel").find("#txtProjectStdRegistUpload").val("");
                    }
                    , error: function (data) {
                        alert(jQuery.error);
                        alert(data);
                    }
                });
            }

        }

    }

    function addNewMemberInClubByStudentCode() {
        var _ddlClub = $("#divClub2").find('.ddlClub').val();
        var _ddlPosition = $("#divClub2").find('.ddlPosition').val();
        var _ddlAcaYear = $("#divClub2").find('.ddlAcaYear').val();
        var _ddlSemester = $("#divClub2").find('.ddlSemester').val();
        //alert(_ddlAcaYear);
        //alert(_ddlSemester);
        var _txtStudentCode = $(".txtStudentCode").val();
        if (_ddlClub == "") {
            alert("กรุณาเลือกชมรม");
            $("#divClub2").find('.ddlClub').focus();
            return;
        }
        else if (_ddlPosition == "") {
            alert("กรุณาระบุสถานะการเข้าร่วม");
            $("#divClub2").find('.ddlPosition').focus();
            return;
        }
        else if (_txtStudentCode == "") {
            alert("กรุณาระบุรหัสนักศึกษา");
            $(".txtStudentCode").focus();
            return;
        }
        else {
            if (confirm("ยืนยันการบันทึกข้อมูล")) {
                var _post = $.param({
                    action: "setNewStudentInClubByStudentCode", _ddlClub: _ddlClub, _ddlPosition: _ddlPosition, _txtStudentCode: _txtStudentCode, _ddlAcaYear: _ddlAcaYear, _ddlSemester: _ddlSemester
                });
                Page.Preload.Show();
                $.ajax({
                    type: "POST",
                    url: "actProjectHandler.ashx",
                    data: _post,
                    success: function (data) {
                        Page.Preload.Hide();
                        if (data == "0") {
                            alert("บันทึกข้อมูลเรียบร้อยแล้ว");
                            $(".txtStudentCode").val("");
                            getListStudentInClubByClubId(_ddlClub);
                        }
                        else {
                            alert("มีข้อมูลรหัสนักศึกษานี้แล้ว");
                        }
                        
                        
                        
                    },
                    error: function (data) {
                        alert(jQuery.error);
                    }
                });
            }
        }

    }


    function getListStudentInClubByClubId(_clubId) {

        var _post = $.param({
            action: "getListStudentInClubByClubId",
            clubId: _clubId,
            uId: "U0001"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divPanelStdInClubList").html(data);
                $("#divPanelStdInClubList").find('.btnCancelStdInClub').click(function () {
                    var _id = $(this).data("id");
                    setCancelStudentInClub(_id, _clubId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function setCancelStudentInClub(_id, _clubId) {
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setCancelStudentInClub", _id: _id
            });
            Page.Preload.Show();
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    getListStudentInClubByClubId(_clubId);

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }



    function setCancelClub(_clubId) {
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setCancelClub", _clubId: _clubId
            });
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    getListClub();


                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }


    function setNewClub() {
        var _txtClubNameTh = $(".txtClubNameTh").val();
        var _txtClubNameEn = $(".txtClubNameEn").val();
        var _txtClubDetailTh = $(".txtClubDetailTh").val();
        var _txtClubDetailEn = $(".txtClubDetailEn").val();
        var _txtPlace = $(".txtPlace").val();
        var _txtPhone = $(".txtPhone").val();
        var _txtMail= $(".txtMail").val();


        if (_txtClubNameTh == "") {
            alert("กรุณาระบุชื่อชมรมภาษาไทย");
            $(".txtClubNameTh").focus();
            return;
        }
        else if (_txtClubNameEn == "") {
            alert("กรุณาระบุชื่อชมรมภาษาอังกฤษ");
            $(".txtClubNameEn").focus();
            return;
        }
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setNewClub", _txtClubNameTh: _txtClubNameTh, _txtClubNameEn: _txtClubNameEn,
                _txtClubDetailTh: _txtClubDetailTh, _txtClubDetailEn: _txtClubDetailEn, _txtPlace: _txtPlace,
                _txtPhone: _txtPhone, _txtMail: _txtMail
            });
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    getListClub();
                    $(".txtClubNameTh").val("");
                    $(".txtClubNameEn").val("");
                    $(".txtClubDetailTh").val("");
                    $(".txtClubDetailEn").val("");
                    $(".txtPlace").val("");
                    $(".txtPhone").val("");
                    $(".txtMail").val("");
                    
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }

    function getListClub() {
        var _post = $.param({
            action: "getListClub"
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divListClub").html(data);
                $(document).ready(function () {
                    $('#tblListClub').DataTable();
                });
                //$("#divListClub").find('.btnEditClub').click(function () {
                //    var _clubId = $(this).data("clubid");
                //    dialogEditClub(_clubId);
                //});
                $("#divListClub").find('.btnDelClub').click(function () {
                    var _clubId = $(this).data("clubid");
                    setCancelClub(_clubId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
        
    }


    function dialogEditClub(_clubId) {

        var _post = $.param({
            action: "dialogEditClub",
            _clubId: _clubId
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                //alert(data);
                $("#divPopup").html(data);
                $('#divPopup').modal('toggle');
                $("#divPopup").find('.btnSetEditClub').click(function () {
                    var _clubId = $(this).data("clubid");
                    setEditClub(_clubId);
                });  

                // $("#divPopup").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    function setEditClub(_clubId) {
        var _txtClubNameTh = $("#divPopup").find(".txtClubNameTh").val();
        var _txtClubNameEn = $("#divPopup").find(".txtClubNameEn").val();
        var _txtClubDetailTh = $("#divPopup").find(".txtClubDetailTh").val();
        var _txtClubDetailEn = $("#divPopup").find(".txtClubDetailEn").val();
        var _txtPlace = $("#divPopup").find(".txtPlace").val();
        var _txtPhone = $("#divPopup").find(".txtPhone").val();
        var _txtMail = $("#divPopup").find(".txtMail").val();


        if (_txtClubNameTh == "") {
            alert("กรุณาระบุชื่อชมรมภาษาไทย");
            $(".txtClubNameTh").focus();
            return;
        }
        else if (_txtClubNameEn == "") {
            alert("กรุณาระบุชื่อชมรมภาษาอังกฤษ");
            $(".txtClubNameEn").focus();
            return;
        }
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setEditClub", _txtClubNameTh: _txtClubNameTh, _txtClubNameEn: _txtClubNameEn,
                _txtClubDetailTh: _txtClubDetailTh, _txtClubDetailEn: _txtClubDetailEn, _txtPlace: _txtPlace,
                _txtPhone: _txtPhone, _txtMail: _txtMail, _clubId: _clubId
            });
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    $('#divPopup').modal('toggle');
                    getListClub();
                    $("#divPopup").find(".txtClubNameTh").val("");
                    $("#divPopup").find(".txtClubNameEn").val("");
                    $("#divPopup").find(".txtClubDetailTh").val("");
                    $("#divPopup").find(".txtClubDetailEn").val("");
                    $("#divPopup").find(".txtPlace").val("");
                    $("#divPopup").find(".txtPhone").val("");
                    $("#divPopup").find(".txtMail").val("");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }


    function panelReportStudent(){
        var _post = $.param({ action: "panelReportStudent"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divGetListProject").html(data);
                $("#divRptStd1").find('.btnChangeFac').change(function () {
                    getListProgram("#divRptStd1");
                });  
                $("#divRptStd1").find('.btnSearchRptStd1').click(function () {
                    resultSearchRptStd1();
                });  
                $("#divRptStd1").find('.btnSearchRptStd1Excel').click(function () {
                    resultSearchRptStd1Excel("resultRptStudentKPITransection");
                });  

                $("#divRptStd2").find('.btnChangeFac').change(function () {
                    getListProgram("#divRptStd2");
                });
                
                $("#divRptStd2").find('.btnSearchRptStd2').click(function () {
                    resultSearchRptStd2();
                });

                $("#divRptStd3").find('.btnChangeFac').change(function () {
                    getListProgram("#divRptStd3");
                });

                $("#divRptStd3").find('.btnSearchRptStd3').click(function () {
                    resultSearchRptStd3();
                });


                //$("#divRptStd2").find('.btnSearchRptStd2Excel').click(function () {
                //    alert(2);
                //});  

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function resultSearchRptStd1Excel(_reportName) {
        var _facultyId = $("#divRptStd1").find('.ddlFaculty').val();
        var _programId = $("#divRptStd1").find('.ddlProgram').val();
        var _studyYear = $("#divRptStd1").find('.ddlStudentYear').val();
        window.open("actRptStudentExcel.aspx?facultyId="+_facultyId+"&programId="+_programId+"&studyYear="+_studyYear+"&reportName="+_reportName);

    }


    function resultSearchRptStd1() {
        var _facultyId = $("#divRptStd1").find('.ddlFaculty').val();
        var _programId = $("#divRptStd1").find('.ddlProgram').val();
        var _studyYear = $("#divRptStd1").find('.ddlStudentYear').val();
        var _post = $.param({
            action: "resultRptStudentKPITransection"
            , facultyId: _facultyId
            , programId: _programId
            , studyYear: _studyYear
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divMainRptStd1").html(data);
                $(document).ready(function () {
                    $(".divMainRptStd1").find("#tblRptStd1").DataTable();
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

     function resultSearchRptStd2() {
            var _facultyId = $("#divRptStd2").find('.ddlFaculty').val();
            var _programId = $("#divRptStd2").find('.ddlProgram').val();
            var _studyYear = $("#divRptStd2").find('.ddlStudentYear').val();
            var _post = $.param({
                action: "resultRptHidefSummary"
                , facultyId: _facultyId
                , programId: _programId
                , studyYear: _studyYear
            });
            Page.Preload.Show();
            $.ajax({
                type: "POST",
                url: "actReportHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    $(".divMainRptStd2").html(data);
                    $(document).ready(function () {
                        $(".divMainRptStd2").find("#tblRptStd2").DataTable();
                    });
                    getHidefGraphSummary();
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });

    }


    function resultSearchRptStd3() {
        var _facultyId = $("#divRptStd3").find('.ddlFaculty').val();
        var _programId = $("#divRptStd3").find('.ddlProgram').val();
        var _studyYear = $("#divRptStd3").find('.ddlStudentYear').val();
        var _post = $.param({
            action: "resultRpt21StSummary"
            , facultyId: _facultyId
            , programId: _programId
            , studyYear: _studyYear
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divMainRptStd3").html(data);
                $(document).ready(function () {
                    $(".divMainRptStd3").find("#tblRptStd3").DataTable();
                });
                get21stGraphSummary();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    function get21stGraphSummary() {
        var _facultyId = $("#divRptStd3").find('.ddlFaculty').val();
        var _programId = $("#divRptStd3").find('.ddlProgram').val();
        var _studyYear = $("#divRptStd3").find('.ddlStudentYear').val();
        Page.Preload.Show();
        var _post = $.param({
            action: "get21stGraphSummary", facultyId: _facultyId, programId: _programId, studyYear: _studyYear
        });

        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                // var obj = JSON.parse(jSonData);
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: "divGraph21stSummary",
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{
                            tickmarkPlacement: 'on',
                            lineWidth: 0
                        }],
                        series: [{
                        }]
                    };
                    options.xAxis[0].categories = obj.name;//obj.name;
                    options.series[0].name = "จำนวนชั่วโมง";
                    options.series[0].data = obj.data;
                    var chart = new Highcharts.Chart(options);
                });

            }
        });
    }

    function getHidefGraphSummary() {
        var _facultyId = $("#divRptStd2").find('.ddlFaculty').val();
        var _programId = $("#divRptStd2").find('.ddlProgram').val();
        var _studyYear = $("#divRptStd2").find('.ddlStudentYear').val();
        Page.Preload.Show();
        var _post = $.param({
            action: "getHidefGraphSummary", facultyId: _facultyId, programId: _programId, studyYear: _studyYear
        });

        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                // var obj = JSON.parse(jSonData);
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: "divGraphHidefSummary",
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{
                            tickmarkPlacement: 'on',
                            lineWidth: 0
                        }],
                        series: [{
                        }]
                    };
                    options.xAxis[0].categories = obj.name;//obj.name;
                    options.series[0].name = "จำนวนชั่วโมง";
                    options.series[0].data = obj.data;
                    var chart = new Highcharts.Chart(options);
                });

            }
        });
    }




    function pageTabSpiderGraph(){

        var _post = $.param({ action: "pageTabSpiderGraph"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divGetListProject").html(data);
                

                pagePrintSpiderGraphUniversityLevel();
                //pagePrintSpiderGraphFacultyLevel();
                //pagePrintSpiderGraph();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }


    function pagePrintSpiderGraphUniversityLevel() {

        var _post = $.param({ action: "pagePrintSpiderGraphUniversityLevel"
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divTabGraph1").html(data);
                $("#divTabGraph1").find('.btnChangeFac').change(function () {
                    getListProgram("#divTabGraph1");
                });  
                $('.btnSearchListUniversityLevel').click(function () {
                    reportGraphUniversityLevel();
                });  
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }



    function reportGraphUniversityLevel()    {
              

           var _acaYear = $("#divTabGraph1").find(".ddlAcaYear").val();
           var _semester = $("#divTabGraph1").find(".ddlSemester").val();
           var _facultyId = $("#divTabGraph1").find(".ddlFaculty").val();
           

           $('#divSpiderGraphUniversityLevel').modal('toggle');


           getListHeaderGraphUniversityLevel(_acaYear,_semester,_facultyId,"Mahidol HIDEF","#divUniversity00","GIR-003","");
           getlistRptMahidolCoreValueUniversity(_facultyId, "", _acaYear, _semester, "", "divGraphUniversity00", "GIR-003","");
           getlistRptMahidolCoreValueUniversity(_facultyId, "", _acaYear, _semester, "", "divGraphUniversity00_sub01", "GIR-003", "IDC-026");
           getlistRptMahidolCoreValueUniversity(_facultyId, "", _acaYear, _semester, "", "divGraphUniversity00_sub02", "GIR-003", "IDC-027");
           getListDefinitionCoreValue("GIR-003", "#divTabUniversity0", "#divDefinitionCoreValue00");

           getListHeaderGraphUniversityLevel(_acaYear,_semester,_facultyId,"Mahidol Core values","#divUniversity01","GIR-002","");
           getlistRptMahidolCoreValueUniversity(_facultyId, "", _acaYear, _semester, "", "divGraphUniversity01","GIR-002","");

           getListDefinitionCoreValue("GIR-002", "#divTabUniversity1", "#divDefinitionCoreValue01");


           getListHeaderGraphUniversityLevel(_acaYear, _semester, _facultyId, "A1 - A4", "#divUniversity04","GIR-001","");
           getlistRptMahidolCoreValueUniversity(_facultyId, "", _acaYear, _semester, "", "divGraphUniversity04","GIR-001","");
           getListDefinitionCoreValue("GIR-001", "#divTabUniversity4", "#divDefinitionCoreValue04");


           //getListHeaderGraphUniversityLevel(_acaYear,_semester,_facultyId,"21st Century Skill Outcomes","#divUniversity02","","GCR-002");
           //getCharacterSummaryUniversity(_acaYear,_semester,_facultyId,"","GCR-002","","divGraphUniversity02"); // ต้องปรับ
           //getListDefinitionCenturySkill("#divTabUniversity2");



           //getListHeaderGraphUniversityLevel(_acaYear,_semester,_facultyId,"TQF มาตรฐานการเรียนรู้ 5 ด้าน","#divUniversity03","","GCR-001");
           //getCharacterSummaryUniversity(_acaYear,_semester,_facultyId,"","GCR-001","","divGraphUniversity03"); // ต้องปรับ
           //getListDefinitionTQF("#divTabUniversity3");


       

     }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 17 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderGraphUniversityLevel
    function getListHeaderGraphUniversityLevel(_acaYear,_semester,_facultyId,_txtDisplayHeader,_divName,_groupIndicatorId,_groupCharacterId) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListHeaderGraphUniversityLevel", acaYear: _acaYear, semester:_semester,facultyId:_facultyId,txtDisplayHeader:_txtDisplayHeader,groupIndicatorId:_groupIndicatorId,groupCharacterId:_groupCharacterId
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_divName).html(data);
            }
        });
    }



    



    function pagePrintSpiderGraphFacultyLevel() {

        var _post = $.param({ action: "pagePrintSpiderGraphFacultyLevel"
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divTabGraph2").html(data);
                $("#divTabGraph2").find('.btnChangeFac').change(function () {
                    getListProgram("#divTabGraph2");
                });  
                $('.btnSearchStdListFacultyLevel').click(function () {
                    getListStudentForSpiderGraphFacultyLevel();
                });  
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 11 พ.ค. 2561
    // Perpose: 
    // Method : getListStudentForSpiderGraphFacultyLevel
    function getListStudentForSpiderGraphFacultyLevel() {
        var _acaYear = $("#divTabGraph2").find(".ddlAcaYear").val();
        var _semester = $("#divTabGraph2").find(".ddlSemester").val();
        var _facultyId = $("#divTabGraph2").find(".ddlFaculty").val();
        var _programId = $("#divTabGraph2").find(".ddlProgram").val();
        var _post = $.param({ action: "getListStudentForSpiderGraphFacultyLevel",facultyId:_facultyId
                        ,programId:_programId,acaYear:_acaYear,semester:_semester
        });

        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divTabGraph2").find(".divDetailFacultyLevel").html(data);
                $(document).ready(function () {
                    $(".divDetailFacultyLevel").find("#tblStudentListGraph").DataTable();
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 9 พ.ค. 2561
    // Perpose: 
    // Method : pagePrintSpiderGraph
    function pagePrintSpiderGraph() {

        var _post = $.param({ action: "pagePrintSpiderGraph"
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divTabGraph3").html(data);
                $("#divTabGraph3").find('.btnChangeFac').change(function () {
                    getListProgram("#divTabGraph3");
                });  
                $('.btnSearchPrintSpiderGraph').click(function () {
                    getListStudentForSpiderGraph();
                });  
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 9 พ.ค. 2561
    // Perpose: 
    // Method : getListStudentForSpiderGraph
    function getListStudentForSpiderGraph() {
        var _facultyId = $("#divTabGraph3").find(".ddlFaculty").val();
        var _programId = $("#divTabGraph3").find(".ddlProgram").val();
        var _studentCode = $("#divTabGraph3").find(".txtStudentCode").val();
        var _firstName = $("#divTabGraph3").find(".txtFirstName").val();
        var _lastName = $("#divTabGraph3").find(".txtLastName").val();
        var _post = $.param({ action: "getListStudentForSpiderGraph",facultyId:_facultyId
                        ,programId:_programId,studentCode:_studentCode,firstName:_firstName,lastName:_lastName
        });

        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divTabGraph3").find(".divSearchDetail").html(data);
                $(document).ready(function () {
                    $(".divSearchDetail").find("#tblStudentListGraph").DataTable();
                });

//                $('.btnReportStudentSpider').click(function () {
//                    var _studentId= $(this).data("studentid");
//                    var _studentCode= $(this).data("studentcode");
//                    var _facultyId= $(this).data("facultyid");
//                    var _programId= $(this).data("programid");
//                    var _ddlTypeGraph= $(".ddlTypeGraph").val();
//                    alert(_studentCode)
//                    //alert(_ddlTypeGraph);
//                    if(_ddlTypeGraph=="01"){
//                        getListReportCoreValue(_studentCode,_studentId);
//                    }else if(_ddlTypeGraph=="02"){
//                    }else if(_ddlTypeGraph=="03"){
//                    }else{}
//                    
//                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }

    function checkCoditionForSpiderGraph(_studentId,_studentCode,_facultyId,_programId,_countProject,_sumHour)    {
        $('#divSpiderGraph').modal('toggle');
            getListReportCoreValue(_studentCode, _studentId, _countProject, _sumHour, "GIR-003", "Mahidol HIDEF", "#divTab0", "container00","#divDefinitionCoreValue00","");
            getListReportCoreValue(_studentCode, _studentId, _countProject, _sumHour, "GIR-002", "Mahidol Core values", "#divTab1", "container01","#divDefinitionCoreValue01","");
            getListReportCoreValue(_studentCode, _studentId, _countProject, _sumHour, "GIR-001", "A1 - A4", "#divTab4", "container04", "#divDefinitionCoreValue04","")
            getListReportCenturySkill(_studentCode,_studentId,_countProject,_sumHour,"GCR-002");
            getListReportTQF(_studentCode,_studentId,_countProject,_sumHour,"GCR-001");
    }




     function drillDownGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId)    {

           $('#divSpiderGraphFacultyLevel').modal('toggle');
            getListHeaderGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId,"Mahidol HIDEF","#divFaculty00","GIR-003","");
            getlistRptMahidolCoreValue(_facultyId, _programId, _acaYear, _semester, "", "divGraphFaculty00","GIR-003");
            getListDefinitionCoreValue("GIR-003", "#divTabFac0", "#divDefinitionCoreValue00");


            getListHeaderGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId,"Mahidol Core values","#divFaculty01","GIR-002","");
            getlistRptMahidolCoreValue(_facultyId, _programId, _acaYear, _semester, "", "divGraphFaculty01","GIR-002");
            getListDefinitionCoreValue("GIR-002", "#divTabFac1", "#divDefinitionCoreValue01");
         
            getListHeaderGraphFacultyLevel(_acaYear, _semester, _facultyId, _programId, "A1 - A4", "#divFaculty04","GIR-001","");
            getlistRptMahidolCoreValue(_facultyId, _programId, _acaYear, _semester, "", "divGraphFaculty04", "GIR-001");
            getListDefinitionCoreValue("GIR-001", "#divTabFac4", "#divDefinitionCoreValue04");

            getListHeaderGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId,"21st Century Skill Outcomes","#divFaculty02","","GCR-002");
            getCharacterSummary(_acaYear,_semester,_facultyId,_programId,"GCR-002","","divGraphFaculty02");
            getListDefinitionCenturySkill("#divTabFac2");
            
            getListHeaderGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId,"TQF มาตรฐานการเรียนรู้ 5 ด้าน","#divFaculty03","","GCR-001");
            getCharacterSummary(_acaYear,_semester,_facultyId,_programId,"GCR-001","","divGraphFaculty03");
            getListDefinitionTQF("#divTabFac3");

     }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderGraphFacultyLevel
    function getListHeaderGraphFacultyLevel(_acaYear,_semester,_facultyId,_programId,_txtDisplayHeader,_divName,_groupIndicatorId,_groupCharacterId) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getListHeaderGraphFacultyLevel", acaYear: _acaYear, semester: _semester, facultyId: _facultyId, programId: _programId
            , txtDisplayHeader: _txtDisplayHeader, groupIndicatorId: _groupIndicatorId
            , groupCharacterId:_groupCharacterId
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_divName).html(data);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 เม.ย. 2561
    // Perpose: 
    // Method : pagePrintActivityTranscript
    function pagePrintActivityTranscript() {

        var _post = $.param({ action: "pagePrintActivityTranscript"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                $(".divGetListProject").find('.btnChangeFac').change(function () {
                    getListProgram(".divGetListProject");
                });  
                $('.btnSearchPrintAT').click(function () {
                    getListATForPrint();
                });  
                $('.btnExportPrintAT').click(function () {
                    //_studentYear = $(this).data('studentyear');
                    //_facultyId = $(this).data('facultyid');
                    //_programId = $(this).data('programid');
                    //_studentCode = $(this).data('studentcode');
                    //_statusRequest = $(this).data('statusrequest');
                    var _studentYear = $(".ddlStudentYear").val();
                    var _facultyId = $(".ddlFaculty").val();
                    var _programId = $(".ddlProgram").val();
                    var _studentCode = $(".txtStudentCode").val();
                    var _statusRequest = $(".ddlStatusRequest").val();
                    window.open("actRptStudentExcel.aspx?facultyId=" + _facultyId + "&studentCode=" + _studentCode + "&statusRequest=" + _statusRequest +
                        "&reportName=RptTransectionRequestDoc&programId=" + _programId +"&studentYear=" + _studentYear);

                });  
                
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 เม.ย. 2561
    // Perpose: 
    // Method : getListATForPrint
    function getListATForPrint() {
        var _studentYear = $(".ddlStudentYear").val();
        var _facultyId = $(".ddlFaculty").val();
        var _programId = $(".ddlProgram").val();
        var _studentCode = $(".txtStudentCode").val();
        var _statusRequest = $(".ddlStatusRequest").val();
        var _post = $.param({
            action: "getListATForPrint", facultyId: _facultyId, programId: _programId, studentCode: _studentCode
            , studentYear: _studentYear, statusRequest: _statusRequest
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divSearchDetail").html(data);
//                $(document).ready(function () {
//                    $('#tblStudentAT').DataTable();
//                });
                $('.btnChkAll').change(function () {
                    var _checkboxes = $(".chkStudentPrintAT").closest('form').find(':checkbox');
                    if ($(this).is(':checked')) {
                        _checkboxes.prop('checked', true);
                    } else {
                        _checkboxes.prop('checked', false);
                    }
                });
                $('.btnPrintAT').click(function () {
                    getListJsonDataPrintAt()
                });
                $('.btnPrintATEng').click(function () {
                    getListJsonDataPrintAtEng()
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
//        alert(_facultyId);
//        alert(_programId);
//        alert(_studentCode);

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 เม.ย. 2561
    // Perpose: 
    // Method : getListJsonDataPrintAt
    function getListJsonDataPrintAt() {
        var _tb = $("#tblStudentAT");
        var _item = new Array();
        var _count = 0;

        var _chkStudentRegistSection = _tb.find(".chkStudentPrintAT");
        $(_chkStudentRegistSection).each(function (index) { 
            if ($(this).is(':checked')) {
                //alert($(this).data("studentcode"));
                _item.push({ studentCode: $(this).data("studentcode") });
                _count++;
                }
        });
        if (_count == 0) {
            alert("กรุณาเลือกรายการนักศึกษาที่ต้องการพิมพ์");
            return;
        }

//        var _post = $.param({ itemList: JSON.stringify(_item)
//        });
//        $.ajax({
//            type: "POST",
//            url: "../student/actAtTranscript.aspx",
//            data: _post,
//            success: function (data) {
//                var file = new Blob([data], { type: 'application/pdf' });
//                var fileURL = URL.createObjectURL(file);
//                window.open(fileURL);
//            },
//            error: function (data) {
//                alert(jQuery.error);
//            }
//        });
//window.open("../student/actAtTranscript.aspx?itemList="+JSON.stringify(_item));

        post_to_url("../student/actAtTranscript.aspx?language=th", { itemList:JSON.stringify(_item),submit: "submit" } );

    }

     function post_to_url(path, params, method) {
        method = method || "post";

        var form = document.createElement("form");


        form._submit_function_ = form.submit;
        form.setAttribute("method", method);
        form.setAttribute("action", path);

        for(var key in params) {
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("type", "hidden");
            hiddenField.setAttribute("name", key);
            hiddenField.setAttribute("value", params[key]);
            form.appendChild(hiddenField);
        }

        document.body.appendChild(form);
        form._submit_function_(); //Call the renamed function.
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 เม.ย. 2561
    // Perpose: 
    // Method : getListProgram
    function getListProgram(_root) {
        var _facultyId = $(_root).find(".ddlFaculty").val();
        //alert(_facultyId);
        //Page.Preload.Show();
        var _post = $.param({ action: "getListProgram",facultyId:_facultyId
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(_root).find(".divProgram").html(data);
                //Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 22 ส.ค. 2560
    // Perpose: แสดงหน้ารายงานสถิติส่วนงาน
    // Method : getListRptStatisticFac
    function getListRptStatisticFac() {
        //var _facultyId = $(".ddlFaculty").val();
        //alert(_facultyId);
        Page.Preload.Show();
        var _post = $.param({ action: "getListRptStatisticFac"//, facultyId:_facultyId
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                $('.btnRptProjectBudget').click(function () {
                    _acayear = $(this).data('acayear');
                    rptProjectBudgetByAcaYear(_acayear);
    
                });
                $('.btnChangeFac').change(function () {
                    //alert("ต้องมาทำต่อ");
                    getListDivRptStatisticFac();
                 
                });       
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function getListDivRptStatisticFac() {
        var _facultyId = $(".ddlFaculty").val();
        var ddlYearReport = $("#ddlYearReport").val();
        var ddlMonthReport = $("#ddlMonthReport").val();
        //alert(ddlYearReport);
        //alert(ddlMonthReport);
        if (typeof ddlYearReport == 'undefined') {
            ddlYearReport = "";
        }
        if (typeof ddlMonthReport == 'undefined') {
            ddlMonthReport = "";
        }
        Page.Preload.Show();
        var _post = $.param({
            action: "getListDivRptStatisticFac", facultyId: _facultyId
            , ddlYearReport: ddlYearReport
            , ddlMonthReport: ddlMonthReport
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divRptStatistic").html(data);
                $('.btnRptProjectBudget').click(function () {
                    _acayear = $(this).data('acayear');
                    rptProjectBudgetByAcaYear(_acayear);
                });

                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }



    function rptProjectBudgetByAcaYear(_acayear) {

        var _facultyId = $(".ddlFaculty").val();
        Page.Preload.Show();
        var _post = $.param({ action: "rptProjectBudgetByAcaYear",
            acayear: _acayear , facultyId:_facultyId
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divRptProjectBudget").html(data);
                $(document).ready(function () {
                    $("#divRptProjectBudget").find("#tblProjectBudgetSummary").DataTable();
                });
           
              
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }





    function getListLoadContactUs() {
       $.ajax({
            type: "POST",
            url: "actContactUs.aspx",
        
            success: function (data) {
                $(".divGetListProject").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
     }


      function getlistProjectMainList(_createdBy) {
          var _ddlAcaYear = $(".divProjectMain").find(".ddlAcaYear").val();
          var _ddlSemester = $(".divProjectMain").find(".ddlSemester").val();
          var _ddlFaculty = $(".divProjectMain").find(".ddlFaculty").val();
          var _projectName = $(".divProjectMain").find(".txtProjectName").val();
          var _ddlProjectStatus = $(".divProjectMain").find(".ddlProjectStatus").val();

          // alert(_ddlProjectStatus);
          Page.Preload.Show();

        var _post = $.param({ action: "getlistProjectMainList",  //getlistProjectMainList
            ddlAcaYear: _ddlAcaYear,
            ddlSemester:_ddlSemester,
            ddlFaculty: _ddlFaculty,
            projectName: _projectName,
            projectStatus: _ddlProjectStatus,
            createdBy: _createdBy
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divListProjectAll").html(data);  //divListProjectAll
                Page.Preload.Hide();

                $(document).ready(function () {
                    try {
                        $('#tblListActivityAll').DataTable();
                    }
                    catch {
                    }
                });

//                $('.btnProjectDetail').click(function () {
//                    //alert(555);
//                    _projectid = $(this).data('projectid');
//                    getListProjectDetail(_projectid, "0");

//                });
                
                $('.btnCancelProject').click(function () {
                    _projectid = $(this).data('projectid');
                    setCancelProject(_projectid);

                });
                $('.btnStdOnlineRegis').click(function () {
                    _projectid = $(this).data('projectid');
                    _projectnameth = $(this).data('projectnameth');
                    //alert(_projectnameth);
                    
                    getListStudentRegistPublicEvent(_projectid,_projectnameth,_ddlAcaYear ,_ddlSemester , _ddlFaculty , _projectName);

                });
                

//                $('.btnAddSectionRegister').click(function () {
//                    _projectid = $(this).data('projectid');
//                    _projectNameTh = $(this).data('projectnameth');
//                    getlistStudentRegistSection(_projectid, _projectNameTh);

//                });
//                $('.btnDontAddSectionRegister').click(function () {
//                    alert("ยังไม่สามารถเพิ่มนักศึกษาได้ ต้องรออนุมัติโครงการจากส่วนกลางมหาวิทยาลัย");
//                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }



    function alertNotPermission() {
        alert("ยังไม่สามารถเพิ่มนักศึกษาได้ เนื่องจากโครงการเป็นสถานะรออนุมัติโครงการ/ร่างโครงการ");
    }



    function getlistStudentRegistSection(_projectId) {
        var _ddlAcaYear = $(".divProjectMain").find(".ddlAcaYear").val();
        var _ddlSemester = $(".divProjectMain").find(".ddlSemester").val();
        var _ddlFaculty = $(".divProjectMain").find(".ddlFaculty").val();
        var _projectName = $(".divProjectMain").find(".txtProjectName").val();
        Page.Preload.Show();
        var _post = $.param({ action: "getlistStudentRegistSection", // 
            projectId: _projectId,
            uId: "U0001"
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divGetListProject").html(data);
                $('.btnAddStudentOnly').click(function () {
                    _projectid = $(this).data('projectid');
                    _projectNameTh = $(this).data('projectnameth');
                    addSectionRegisterStudentOnly(_projectid, _projectNameTh);

                });
                $('.btnGetListStdInSection').click(function () {
                    _projectid = $(this).data('projectid');
                    _sectionid = $(this).data('sectionid');
                    getListStdInSection(_projectid , _sectionid);

                });
                $('.btnAddStudentExcel').click(function () {
                    _projectid = $(this).data('projectid');
                    _projectNameTh = $(this).data('projectnameth');
                    addSectionRegisterStudentExcel(_projectid, _projectNameTh);

                });
                $('.btnExportExcelStudentInSection').click(function () {
                    _projectid = $(this).data('projectid');
                    _sectionid = $(this).data('sectionid');
                    window.open("actStudentInSectionExcel.aspx?projectId=" + _projectid + "&sectionId=" + _sectionid, "_self");
                    //alert(_projectid);
                    //alert(_sectionid);

                });

                

                $('.divGetListProject').find('.btnBack').click(function () {
                     getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName , "");
                    //window.open("actProjectList.aspx", "_self");
                });






                $('.btnSetCancelStdRegistByCheckBox').click(function () {
                    _projectid = $(this).data('projectid');
                    _projectNameTh = $(this).data('projectnameth');
                    setCancelStdRegistByCheckBox(_projectid, _projectNameTh);
                });




                $('.btnChkAll').change(function () {
                    var _checkboxes = $(".chkStudentRegist").closest('form').find(':checkbox');
                    if ($(this).is(':checked')) {
                        _checkboxes.prop('checked', true);
                    } else {
                        _checkboxes.prop('checked', false);
                    }
                });


                $(document).ready(function () {
                    $('#tblStudentRegist').DataTable();
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }



      function getListStdInSection(_projectId,_sectionId) {

        var _post = $.param({ action: "getListStdInSection",
            projectId: _projectId,sectionId: _sectionId
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divStdInSection").html(data);
                $('.btnDialogUpdatePostition').click(function () {
                    _transsectionregistid = $(this).data('transsectionregistid');
                    _studentcode = $(this).data('studentcode');
                    _firstname = $(this).data('firstname');
                    _lastname = $(this).data('lastname');
                    _positionid = $(this).data('positionid');
                    _projectNameTh = $(this).data('projectnameth');
                    pageDialogUpdatePostition(_transsectionregistid, _studentcode, _firstname, _lastname, _positionid, _projectId, _projectNameTh);
                    // editProjectBudgetPage("555", "777");
                });
                $('.btnSetCancelStudentRegist').click(function () {
                    _studentid = $(this).data('studentid');
                    _sectionid = $(this).data('sectionid');
                    _projectid = $(this).data('projectid');
                    _projectNameTh = $(this).data('projectnameth');
                    _transsectionregistid = $(this).data('transsectionregistid');

                    setCancelStudentRegist(_projectid, _sectionid, _studentid, _projectNameTh, _transsectionregistid);
                });
                $('.btnChkAll').change(function () {
                    var _checkboxes = $(".chkStudentRegist").closest('form').find(':checkbox');
                    if ($(this).is(':checked')) {
                        _checkboxes.prop('checked', true);
                    } else {
                        _checkboxes.prop('checked', false);
                    }
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 9 ส.ค. 2560
    // Perpose: ยกเลิกรายการข้อมูลนักศึกษาตาม Checkbox 
    // Method : setCancelStdRegistByCheckBox
    function setCancelStdRegistByCheckBox(_projectid, _projectNameTh){
        
        var _tb = $("#tblStudentRegist");
        var _item = new Array();
        var _count = 0;
        var _transId = _tb.find(".transId");
        var _chkStudentRegistSection = _tb.find(".chkStudentRegist");
        $(_chkStudentRegistSection).each(function (index) { 

            if ($(this).is(':checked')) {
                    //alert(_transId[index].value);
                    _count++;
                _item.push({ transId: _transId[index].value });
                }

        });

        if (_count == 0) {
            alert("กรุณาเลือกรายการนักศึกษาที่ต้องการลบข้อมูล");
            return;
        }

        if(confirm("ยืนยันการลบข้อมูล")){
                var _post = $.param({ action: "setCancelStdRegistByCheckBox",
                    itemList: JSON.stringify(_item)
                });
                $.ajax({
                    type: "POST",
                    url: "actProjectHandler.ashx",
                    data: _post,
                    success: function (data) {
                            alert(data);
                            getlistStudentRegistSection(_projectid);
                    },
                    error: function (data) {
                        alert(jQuery.error);
                    }
                });
        }
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 17 ก.ค. 2560
    // Perpose: 
    // Method : pageDialogUpdatePostition
    function pageDialogUpdatePostition(_transsectionregistid,_studentcode,_firstname,_lastname,_positionid,_projectid,_projectNameTh) {

        var _post = $.param({ action: "pageDialogUpdatePostition",
            transsectionregistid: _transsectionregistid,
            studentcode: _studentcode,
            firstname:_firstname,
            lastname:_lastname,
            positionid :_positionid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
         
                $("#divPopup").html(data);
                $("#divEditStudentPosition").find(".ddlPosition").val(_positionid);
                $('.btnSetUpdateStudentPosition').click(function () {
                    _transsectionregistid = $(this).data('transsectionregistid');
                    SetUpdateStudentPosition(_transsectionregistid,_projectid,_projectNameTh);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ก.ค. 2560
    // Perpose: 
    // Method : SetUpdateStudentPosition
    function SetUpdateStudentPosition(_transsectionregistid,_projectid,_projectNameTh) {
      if(confirm("ยืนยันการบันทึกข้อมูล")){
           _positionid = $("#divEditStudentPosition").find(".ddlPosition").val();
           var _post = $.param({ action: "SetUpdateStudentPosition",
                transsectionregistid: _transsectionregistid,
                positionid: _positionid
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    $('#divPopup').modal('toggle');
                    getlistStudentRegistSection(_projectid);

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

     }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 มิ.ย. 2560
    // Perpose: 
    // Method : addSectionRegisterStudentExcel
    function addSectionRegisterStudentExcel(_projectId, _projectNameTh) {

        var _post = $.param({ action: "addSectionRegisterStudentExcel",
            projectId: _projectId,
            projectNameTh: _projectNameTh,
            uId: "U0001"
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);

                $('.btnBack').click(function () {
                    getlistStudentRegistSection(_projectid);
                });

                $('#txtProjectStdRegistUpload').change(function () {
                    Page.Preload.Show();
                    var fullPath = document.getElementById('txtProjectStdRegistUpload').value;
                    var filename;
                    var extname;
                    if (fullPath) {
                        startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                        var filename = fullPath.substring(startIndex);
                        if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                            filename = filename.substring(1);
                             extname = getExtension(filename);
                        }
                       

                    }
                    $("form").attr({
                        "target": "uploadframeStdRegistExcel",
                        "action": "actProjectHandler.ashx?action=uploadStdRegist&filename=" + filename + "&extname=" + extname,
                        "enctype": "multipart/form-data"
                    });
                    $("form").submit();
                });
                $("#uploadframeStdRegistExcel").ready(function () {
                    console.log($("#uploadframeStdRegistExcel").contents());
                });

                $('.btnAddStudentRegistExcel').click(function () {

                    addStudentRegistExcel();
                });
                $('.btnSetStudentRegistExcel').click(function () {
                    setStudentEachOnly(_projectid, _projectNameTh, "tblStudentRegistTempExcel");
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }


    function getExtension(path) {
    var basename = path.split(/[\\/]/).pop(),  
                                              
        pos = basename.lastIndexOf(".");       

    if (basename === "" || pos < 1)         
        return "";                          

    return basename.slice(pos + 1);            
    }


    function addStudentRegistExcel() {

        Page.Preload.Show();
        var _ddlSection = $("#divSectionStudentRegistExcel").find(".ddlSection").val();
        //var _ddlPosition = $("#divSectionStudentRegistExcel").find(".ddlPosition").val();
        var _txtFiletName = $("#divSectionStudentRegistExcel").find("#txtProjectStdRegistUpload").val();
        if (_txtFiletName == "") {
            alert("กรุณาเลือกไฟล์");
            $("#divSectionStudentRegistExcel").find("#txtProjectStdRegistUpload").focus();
            return;
        }
        else if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divSectionStudentRegistExcel").find(".ddlSection").focus();
            return;
        }
//        else if (_ddlPosition == "") {
//            alert("กรุณาเลือกข้อมูล");
//            $("#divSectionStudentRegistExcel").find(".ddlPosition").focus();
//            return;
//        }



        
        var _post = $.param({ action: "connectstdlistexcel",
            fileName: pictureName  + "."+extName,
            extName: extName,
            sectionId: _ddlSection
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".tblStudentRegistTempExcel").append(data);
                $("#divSectionStudentRegistExcel").find("#txtProjectStdRegistUpload").val("");


            }
            , error: function (data) {
                alert(jQuery.error);
                alert(data);
            }
        });

    }









    function LoadApprovePage() {

        Page.Preload.Show();

        $.ajax({
            type: "POST",
            url: "actApproveProject.aspx",
            //beforeSend: function () { loading(); },
            success: function (data) {
                $(".divGetListProject").html(data);
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }






    function loadPageSectionRegister(_projectid) {

        $.ajax({
            type: "POST",
            url: "Student.aspx",
            //beforeSend: function () { loading(); },
            success: function (data) {
                $(".divGetListProject").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }



    
    function pageStudentCompleteActivity() {

 
        var _post = $.param({ action: "pageStudentCompleteActivity", typeComlpeteAct : "0"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                
                Page.Preload.Hide();
                getListStudentCompleteActivity("");


                $('.btnSearchRptReportCompleteAct').click(function () {
                    var _ddlTypeComlpeteAct = $(".ddlTypeComlpeteAct").val();
                    getListStudentCompleteActivity(_ddlTypeComlpeteAct);

//                        var _ddlTypeComlpeteAct = $(".ddlTypeComlpeteAct").val();
//                        if( typeof _ddlTypeComlpeteAct == 'undefined' ){
//                            _ddlTypeComlpeteAct="";
//                        }

                });


            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


   function getListStudentCompleteActivity(_typeCompleteAct) {

        
        //alert(_typeCompleteAct);
        var _post = $.param({ action: "getListStudentCompleteActivity", typeComlpeteAct : _typeCompleteAct
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divDetailReport").html(data);
                Page.Preload.Hide();
                $('.btnRptStdCompleteActGroupFaculty').click(function () {
                    _acaYear = $(this).data('acayear');
                    getlistRptStdCompleteActGroupFaculty(_acaYear);
                });
                $('.btnGetListRptStudent').click(function () {
                    _acaYear = $(this).data('acayear');
                    _facultyId = $(this).data('facultyid');
                    //_programId = $(this).data('programid');
                    //_typeComlpeteAct = $(this).data('typecomlpeteact');
                    //alert(_acaYear);
                    //alert(_facultyId);
                    //alert(_programId);
                    getListRptStdCompleteActGroupStudent(_acaYear,_facultyId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

   }



    function getlistRptStdCompleteActGroupFaculty(_acaYear) {


        var _post = $.param({ action: "getlistRptStdCompleteActGroupFaculty" , acaYear : _acaYear
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divRptStdCompleteActDetail").html(data);
                Page.Preload.Hide();
                $(document).ready(function () {
                    $("#divRptStdCompleteActDetail").find(".tblStudentCriteria").DataTable();
                });

                $('.btnRptStdCompleteActGroupProgram').click(function () {
                    _facultyId = $(this).data('facultyid');
                    _facultyCode = $(this).data('facultycode');
                    _facultyNameTh = $(this).data('facultynameth');
                    //alert(_facultyCode);
                    //alert(_facultyNameTh);
                    getlistRptStdCompleteActGroupProgram(_acaYear,_facultyId,_facultyCode,_facultyNameTh);
                });
                //$('.btnGetListRptStdCompleteActGroupStudent').click(function () {
                //    _facultyId = $(this).data('facultyid');
                //    _programId = $(this).data('programid');
                //    //alert("Fac");
                //    getListRptStdCompleteActGroupStudent(_acaYear,_facultyId);
                //});
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

     function getlistRptStdCompleteActGroupProgram(_acaYear,_facultyId,_facultyCode,_facultyNameTh) {
        var _post = $.param({ action: "getlistRptStdCompleteActGroupProgram" , acaYear : _acaYear , facultyId :_facultyId
                                      , facultyCode:_facultyCode , facultyNameTh:_facultyNameTh
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divRptStdCompleteActDetail").html(data);
                Page.Preload.Hide();
                $('.btnBack').click(function () {
                    getlistRptStdCompleteActGroupFaculty(_acaYear);
                });
                $('.btnGetListRptStdCompleteActGroupStudent').click(function () {
                    _acaYear = $(this).data('acayear');
                    _facultyId = $(this).data('facultyid');
                    //alert("Pro");
                    getListRptStdCompleteActGroupStudent(_acaYear,_facultyId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
     }

     function getListRptStdCompleteActGroupStudent(_acaYear,_facultyId) {
        //alert(555);
        var _post = $.param({ action: "getListRptStdCompleteActGroupStudent" ,acaYear:_acaYear,facultyId:_facultyId
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {

                $("#divRptStdCompleteGroupStudent").html(data);
                $(document).ready(function () {
                    $('.tblTransStudentCreterion').DataTable();
                });
                $('.btnTransStudentCreterionExcel').click(function () {
                    _acaYear = $(this).data('acayear');
                    _facultyId = $(this).data('facultyid');
                     window.open("actRptStudentExcel.aspx?facultyId="+_facultyId+"&acaYear="+_acaYear+"&reportName=RptSumHrAndCountActStudent&programId=&studyYear=");

                });
                Page.Preload.Hide();

  
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function popUpActivityByStudentId(_studentId, _studentCode) {

        // $("#divDD").modal('toggle');

        var _post = $.param({ action: "popUpActivityByStudentId" , studentId:_studentId , studentCode:_studentCode
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                //$("#myModal").modal('toggle');
                $("#spnDataDetailTransAct").html(data);
                //setTimeout($("#divTransActStd").modal('toggle'), 5000);
                $("#divTransActStd").modal('toggle');
                
                $(".en").hide();
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    function getListLoadStudent() {

        var _post = $.param({ action: "pageSearhStudentCondition"
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                Page.Preload.Hide();
                $('.btnSearchStudentCondition').click(function () {
                    getListForPageSearchStudentCondition();
                    // searchStudentCondition();

                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
//        $.ajax({
//            type: "POST",
//            url: "Student.aspx",
//            //beforeSend: function () { loading(); },
//            success: function (data) {
//                $(".divGetListProject").html(data);
//            },
//            error: function (data) {
//                alert(jQuery.error);
//            }
//        });

    }
    function getListForPageSearchStudentCondition() {
        var _studentCode = $("#divStudentCondition").find(".txtStudentCode").val();
        var _stdFName = $("#divStudentCondition").find(".txtStdFName").val();
        var _stdLName = $("#divStudentCondition").find(".txtStdLName").val();
        if ((_studentCode == "") && (_stdFName == "") && (_stdLName== "")) {
            alert("กรุณาระบุรายละเอียดของนศ.เพื่อทำการค้นหาข้อมูล");
            return;
        }
        var _post = $.param({ action: "getListForPageSearchStudentCondition" ,
                              studentCode:_studentCode,
                              stdFName:_stdFName,
                              stdLName:_stdLName
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divStudentCondition").find("#divResultStudentCondition").html(data);
                $(document).ready(function () {
                    $("#tblStdPageSearch").DataTable(
                       {
                            "searching": false
                       });
                });
                $(".en").hide();
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function searchStudentCondition(_studentId,_studentCode) {
        
        //var _studentCode = $("#divStudentCondition").find(".txtStudentCode").val();
        //var _stdFName = $("#divStudentCondition").find(".txtStdFName").val();
        //var _stdLName = $("#divStudentCondition").find(".txtStdLName").val();
        //var _programId = $("#divStudentCondition").find(".ddlProgram").val();
//        var _ddlAcaYear = $("#divStudentCondition").find(".ddlAcaYear").val();
//        var _ddlSemester = $("#divStudentCondition").find(".ddlSemester").val();

        var _post = $.param({ action: "resultStudentCondition" ,
            studentCode: _studentCode,studentId:_studentId
                              //     ,
                              //stdFName:_stdFName,
                              //stdLName:_stdLName,
                              //programId: _programId
                             // ,  acaYear:_ddlAcaYear,  semester:_ddlSemester
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                //$("#divStudentCondition").find("#divResultStudentCondition").html(data);
                $("#divStudentCondition").find("#divStdDetailActivity").html(data);
                $(".en").hide();
                $(document).ready(function () {
                    $("#tblStdActType1").DataTable(
                        {
                            "order": [[ 0, "desc" ]]
                        }
                    );
                    $("#tblStdActType2").DataTable(
                        {
                            "order": [[ 0, "desc" ]]
                        }
                    );
                });


                $('.btnGetListConditionToComplete').click(function () {
                    getListConditionToComplete();
                });
                
                Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

     }

     function getListConditionToComplete() {
         var _studentCondition = $("#hddStudentCondition").val();

         var _post = $.param({ action: "getListConditionToComplete", studentCondition:"60"
        });
        //Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                
                $('#divResultStudentCondition').html(data);
                //Page.Preload.Hide();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function getListReport() {

 
//        $.ajax({
//            type: "POST",
//            url: "Report.aspx",
//            //beforeSend: function () { loading(); },
//            success: function (data) {
//                $(".divGetListProject").html(data);
//            },
//            error: function (data) {
//                alert(jQuery.error);
//            }
//        });



        Page.Preload.Show();
        var _post = $.param({ action: "rptProjectSummary"
        });

        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                Page.Preload.Hide();
                $('.btnRptProjectSummaryDetail').click(function () {
                    _acaYear = $(this).data('acayear');
                    rptProjectSummaryDetail(_acaYear);
                });
  
                
                //genGraphProjectSummary();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

     function rptProjectSummaryDetail(_acaYear) {
   
        var _post = $.param({ action: "rptProjectSummaryDetail",acaYear:_acaYear
        });
        $.ajax({
            type: "POST",
            url: "actReportHandler.ashx",
            data: _post,
            success: function (data) {
                    $("#divRptProjectSummary").html(data);
                    
                    $('.btnBack').click(function () {
                        getListReport();
                    });
             },
            error: function (data) {
                alert(jQuery.error);
            }
        });

       
    }


//    function genGraphProjectSummary() {
//        var _acaYear =  $("#hddAcaYearStart").val();
//        var _post = $.param({ action: "genGraphProjectSummary"
//        });
//        $.ajax({
//            type: "POST",
//            url: "actReportHandler.ashx",
//            data: _post,
//            success: function (chartData) {
//                //alert(chartData);
//                Highcharts.chart('divGraphProjectSummary', {

//                    title: {
//                        text: 'รายงานแสดงจำนวนกิจกรรม'
//                    },

//                    subtitle: {
//                        text: 'แบ่งตามปีการศึกษา'
//                    },

//                    yAxis: {
//                        title: {
//                            text: 'จำนวนกิจกรรม'
//                        }
//                    },
//                    legend: {
//                        layout: 'vertical',
//                        align: 'right',
//                        verticalAlign: 'middle'
//                    },

//                    plotOptions: {
//                        series: {
//                            pointStart: parseInt(_acaYear)
//                        }
//                    },

//                    series: [{
//                        name: '',
//                        data: JSON.parse(chartData),
//                    }]
//                    
//                });
//            },
//            error: function (data) {
//                alert(jQuery.error);
//            }
//        });

//       
//    }






    function LoadPageAddNewProject() {
        var _post = $.param({ action: "LoadPageAddNewProject"
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                $('.datetimepicker').datetimepicker();
                $(".selectpicker").selectpicker(); 



                // Script สำหรับ Checkbox คณะ 
                $(".chkFaculty").click(function(event){
                    if($(this).is(':checked')){
                        $('.ddlFaculty').prop('disabled', false);
                        $('.ddlFaculty').selectpicker('refresh');
                    }
                    else{
                        $('.ddlFaculty').prop('disabled', true);
                        $('.ddlFaculty').selectpicker('refresh');
                        $('.ddlFaculty').selectpicker('deselectAll');
                    }
                });

                // Script สำหรับ Checkbox ชั้นปี
                $(".chkClassYear").click(function(event){
                    if($(this).is(':checked')){
                        $('.ddlClassYear').prop('disabled', false);
                        $('.ddlClassYear').selectpicker('refresh');
                    }
                    else{
                        $('.ddlClassYear').prop('disabled', true);
                        $('.ddlClassYear').selectpicker('refresh');
                        $('.ddlClassYear').selectpicker('deselectAll');
                    }
                });
                // Script สำหรับ Checkbox รหัสนักศึกษา
                $(".chkStudentCode").click(function(event){
                    if($(this).is(':checked')){
                         $('.txtConditionStudentCode').prop('disabled', false);
                         $('.txtConditionStudentCode').focus();
                    }
                    else{
                        $('.txtConditionStudentCode').prop('disabled', true);
                        $('.txtConditionStudentCode').val('');

                    }
                });


                $('.btnBack').click(function () {
                    getListProject("","","","","");
                });
                $('.btnSetProject').click(function () { 
                    setProject();
                });


                // jate 26 เม.ย.64
                $('.chkPanelOnlineDisable').prop('disabled', true);
                $(".chkPanelOnline").click(function (event) {
                    var chkPanelOnline = $(this).is(':checked');
                    //alert(chkPanelOnline);
                    if (chkPanelOnline) {
                        $('.chkPanelOnlineDisable').prop('disabled', false);
                    }
                    else {
                        $('.chkPanelOnlineDisable').prop('disabled', true);
                        $('.chkPanelOnlineDisable').val("");

                        $(".chkStudentCode").prop('checked', false);
                        $('.txtConditionStudentCode').prop('disabled', true);
                        $('.txtConditionStudentCode').val('');


                        $(".chkClassYear").prop('checked', false);
                        $('.ddlClassYear').prop('disabled', true);
                        $('.ddlClassYear').selectpicker('refresh');
                        $('.ddlClassYear').selectpicker('deselectAll');


                        $(".chkFaculty").prop('checked', false);
                        $('.ddlFaculty').prop('disabled', true);
                        $('.ddlFaculty').selectpicker('refresh');
                        $('.ddlFaculty').selectpicker('deselectAll');
                    }
                });
//                $('.btnConditionTargetGroup').click(function () { 
//                    pageDialogConditionTargetGroup();
//                });

                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 30 ก.ค. 2560
    // Perpose: 
    // Method : pageConditionTargetGroup
//    function pageDialogConditionTargetGroup(){
//            var _post = $.param({ action: "pageDialogConditionTargetGroup"   });
//            $.ajax({
//                type: "POST",
//                url: "actProjectHandler.ashx",
//                data: _post,
//                success: function (data) {

//                    $('#divPopup').html(data);
//                },
//                error: function (data) {
//                    alert(jQuery.error);
//                }
//            });
//    }


    function validateStudentCodeCondition(_strData){
        
        var _data = _strData.split(',');
        var _chkStudent = 0;
        // Loop แรกสำหรับตัด คอมม่าออกจาก สตริง
        $.each(_data, function(index, value) { 
              if(!isNaN(value))
              {
                  if(value.length != 7){
                       alert("รหัสนักศึกษาไม่ครบจำนวน 7 หลัก");
                      _chkStudent =1;
                  }
                  
              }
              else
              {
                   var _splitMinus = value.split('-');
                   $.each(_splitMinus, function(indexSub, valueSub) { 
                        if(!isNaN(valueSub)){
                            if(valueSub.length != 7){
                                alert("รหัสนักศึกษาไม่ครบจำนวน 7 หลัก");
                                _chkStudent =1;
                            }
                        }
                        else{
                             alert("กรุณากรอกข้อมูลเฉพาะตัวเลขเท่านั้น");
                             _chkStudent =1;
                        }
                   });
              }

        });

        return _chkStudent;
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 29 พ.ค. 2560
    // Perpose: Insert ข้อมูลโครงการใหม่
    // Method : setProject
    function setProject() {
        //$("#form1").validator();
        var _projectNameTh = $(".divNewProject").find(".txtProjectNameTh").val();
        var _projectNameEn = $(".divNewProject").find(".txtProjectNameEn").val();
        var _ddlFaculty = $(".divNewProject").find(".ddlFaculty").selectpicker("val");
        var _ddlClassYear= $(".divNewProject").find(".ddlClassYear").selectpicker("val");
        var _conditionStudentCode = $(".divNewProject").find(".txtConditionStudentCode").val();
        var _ddlProjectType = $(".divNewProject").find(".ddlProjectType").val();
        var _acaYear = $(".divNewProject").find(".ddlAcaYear").val();
        var _semester = $(".divNewProject").find(".ddlSemester").val();
        var _chkStudent=0;
        if (_projectNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $(".divNewProject").find(".txtProjectNameTh").focus();
            return;
        }
     
        if($(".chkStudentCode").is(':checked')){
              if(_conditionStudentCode==""){
                        alert("กรุณากรอกข้อมูล");
                        $(".divNewProject").find(".txtConditionStudentCode").focus();
                        return;
              }
              _chkStudent = validateStudentCodeCondition(_conditionStudentCode);
         }
         if(_chkStudent==1){
            return;
         }

         if(_ddlProjectType==""){
            alert("กรุณาเลือกประเภทโครงการ");
            $(".divNewProject").find(".ddlProjectType").focus();
            return;
         }
  
          
       

//        else if (_projectNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $(".divNewProject").find(".txtProjectNameEn").focus();
//            return;
//        }
        // สำหรับตรวจสอบ การกรอกเงื่อนไข Conditon ที่เป็นรหัสนักศึกษา
        


        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProject"
                             , uId: "U0001"
                             , acaYear: _acaYear
                             , semester: _semester
                             , instituteId: $(".divNewProject").find(".ddlInstitute").val()
                             , projectNameTh: _projectNameTh
                             , projectNameEn: _projectNameEn
                             , projectDetail: $(".divNewProject").find(".txtProjectDetail").val()
                             , projectDetailEn: $(".divNewProject").find(".txtProjectDetailEn").val()
                             , projectTypeId: _ddlProjectType
                             //, projectStatusId: $(".divNewProject").find(".ddlProjectStatus").val()
//                             , targetGroup: $(".divNewProject").find(".txtTargetGroup").val()
                             //, facultyId: $(".divNewProject").find(".ddlFaculty").val()

                             , startDateRecruit: $(".divNewProject").find(".txtStartDateRecruit").val()
                             , endDateRecruit: $(".divNewProject").find(".txtEndDateRecruit").val()
                             , facultyStr: escape(_ddlFaculty)
                             , classYearStr: escape(_ddlClassYear)
                             , conditionStudentCodeStr:_conditionStudentCode
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    getProjectId();
                    // alert(55);
                    //getListProjectDetail(_projectId, "1");
                    // getListProject("","","","");
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    function getProjectId() {
         var _post = $.param({ action: "getProjectId"
         });
         $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (_projectId) {
                    //alert(_projectId);
                    getListProjectDetail(_projectId, "1");
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        
    }

    function callback_uploadfile(obj) { 

        console.log(obj);
        pictureName = obj.fileName;
        extName = obj.extName;
//        alert(pictureName);
//        alert(obj.extName);
        Page.Preload.Hide();

    }

    function getListProjectDetail(_projectid,_index) {
        var _ddlAcaYear = $(".divProjectMain").find(".ddlAcaYear").val();
        var _ddlSemester = $(".divProjectMain").find(".ddlSemester").val();
        var _ddlFaculty = $(".divProjectMain").find(".ddlFaculty").val();
        var _projectName = $(".divProjectMain").find(".txtProjectName").val();
        //alert(_projectName);

        Page.Preload.Show();
        var _post = $.param({ action: "getListProjectDetail", projectId: _projectid ,statusEdit:""
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            //beforeSend: function () { loading(); },
            success: function (data) {
                // alert();
                $(".divGetListProject").html(data);
                $(".selectpicker").selectpicker();
                getDataClassTodisplaySelectPicker(_projectid);
                getDataFacultyTodisplaySelectPicker(_projectid);
                Page.Preload.Hide();


                $('.nav-tabs li:eq(' + _index + ') a').tab('show');
                $('.datetimepicker').datetimepicker();
                $('.datetimepicker').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm:ss'
                });

                // อันนี้
                //$(document).ready(function () {
                //    $(".divGetListProject").find("#tblIndicatorGIR-001").DataTable({
                //        "paging":   false , "searching":   false ,"info":     false
                //    });
                //    $(".divGetListProject").find("#tblIndicatorGIR-002").DataTable({
                //        "paging":   false , "searching":   false,"info":     false
                //    });
                //    $(".divGetListProject").find("#tblIndicatorGIR-003").DataTable({
                //        "paging":   false , "searching":   false,"info":     false
                //    });
                //});

                // Script สำหรับ Checkbox คณะ 
                $(".chkFaculty").click(function (event) {
                    if ($(this).is(':checked')) {
                        $('.ddlFaculty').prop('disabled', false);
                        $('.ddlFaculty').selectpicker('refresh');
                    }
                    else {
                        $('.ddlFaculty').prop('disabled', true);
                        $('.ddlFaculty').selectpicker('refresh');
                        $('.ddlFaculty').selectpicker('deselectAll');
                    }
                });

                // Script สำหรับ Checkbox ชั้นปี
                $(".chkClassYear").click(function (event) {
                    if ($(this).is(':checked')) {
                        $('.ddlClassYear').prop('disabled', false);
                        $('.ddlClassYear').selectpicker('refresh');
                    }
                    else {
                        $('.ddlClassYear').prop('disabled', true);
                        $('.ddlClassYear').selectpicker('refresh');
                        $('.ddlClassYear').selectpicker('deselectAll');
                    }
                });
                // Script สำหรับ Checkbox รหัสนักศึกษา
                $(".chkStudentCode").click(function (event) {
                    if ($(this).is(':checked')) {
                        $('.txtConditionStudentCode').prop('disabled', false);
                        $('.txtConditionStudentCode').focus();
                    }
                    else {
                        $('.txtConditionStudentCode').prop('disabled', true);
                        $('.txtConditionStudentCode').val('');
                    }
                });
                $('#txtProjectPictureUpload').change(function () {
                    var fullPath = document.getElementById('txtProjectPictureUpload').value;
                    if (fullPath) {
                        var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                        filename = fullPath.substring(startIndex);
                        if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                            filename = filename.substring(1);
                        }


                        _extention = filename.replace(/^.*\./, '');
                    }

                    Page.Preload.Show();
                    $("form").attr({
                        "target": "uploadframe",
                        "action": "actProjectHandler.ashx?action=uploadPicture&extention=" + _extention,
                        "enctype": "multipart/form-data"
                    });
                    $("form").submit();
                });

                $("#uploadframe").ready(function () {
                    console.log($("#uploadframe").contents());
                });
                $('.btnSetProjectSection').click(function () {
                    setProjectSection();
                });
                $('.btnSetProjectBudget').click(function () {
                    setProjectBudget();
                });
                $('.btnSetProjectIndicator').click(function () {
                    setProjectIndicator();
                });
                $('.btnSetProjectCharacter').click(function () {
                    setProjectCharacter();
                });
                $('.btnSetProjectDevice').click(function () {
                    setProjectDevice();
                });
                $('.btnSetUpdateProject').click(function () {
                    //alert(55);
                    setUpdateProject();
                });
                $('.btnSetSubmitProject').click(function () {
                    // ต้องมีการบันทึกข้อมูล 3 Module o	Project , o	Section , o	Indicator
                    _projectid = $(this).data('projectid');
                    validateSubmitProject(_projectid);
                });
                $('.btnSetCloseProject').click(function () {
                    _projectid = $(this).data('projectid');
                    setCloseProject(_projectid);
                });

                $('.btnSetProjectPicture').click(function () {
                    setProjectPicture();
                });
                $('.btnEditSection').click(function () {
                    _sectionid = $(this).data('sectionid');
                    editSectionPage(_sectionid, _projectid);
                });
                $('.btnEditProjectBudget').click(function () {
                    _transProjectBubgetId = $(this).data('transprojectbubgetid');
                    editProjectBudgetPage(_transProjectBubgetId, _projectid);
                });

                $('.btnEditProjectIndicator').click(function () {
                    _transsectionindicatorid = $(this).data('transsectionindicatorid');
                    editProjectIndicatorPage(_transsectionindicatorid, _projectid);
                });

                //                $('.btnEditProjectCharacter').click(function () {
                //                    _transSectionCharacterId = $(this).data('transsectioncharacterid');
                //                    editProjectCharacterPage(_transSectionCharacterId, _projectid);
                //                });

                $('.btnEditSectionDevice').click(function () {
                    _transSectionDeviceId = $(this).data('transsectiondeviceid');
                    editProjectDevicePage(_transSectionDeviceId, _projectid);
                });
                $('.btnCancelProjectPicture').click(function () {
                    _transProjectPictureId = $(this).data('transprojectpictureid');
                    setCancelProjectPicture(_transProjectPictureId, _projectid);
                });
                $('.btnCancelProjectDevice').click(function () {
                    _transSectionDeviceId = $(this).data('transsectiondeviceid');
                    setCancelProjectDevice(_transSectionDeviceId, _projectid);
                });
                $('.btnCancelProjectIndicator').click(function () {
                    _transSectionIndicatorId = $(this).data('transsectionindicatorid');
                    setCancelProjectIndicator(_transSectionIndicatorId, _projectid);
                });
                $('.btnCancelProjectBudget').click(function () {
                    _transProjectBubgetId = $(this).data('transprojectbubgetid');
                    setCancelProjectBudget(_transProjectBubgetId, _projectid);
                });
                $('.btnCancelSection').click(function () {
                    _sectionId = $(this).data('sectionid');
                    setCancelSection(_sectionId, _projectid);
                });

                $('.btnCancelProjectCharacter').click(function () {
                    _transSectionCharacterId = $(this).data('transsectioncharacterid');
                    setCancelProjectCharacter(_transSectionCharacterId, _projectid);
                });


                $('.btnBack').click(function () {
                    //alert(_ddlAcaYear);
                    //alert(_ddlSemester);
                    //alert(_ddlFaculty);
                    //alert(_projectName);
                    getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName,"");
                    //getlistProjectMainList();
                });

                $('.ddlIndicator').change(function () {
                    var _ddlIndicator = $(this).val();
                    // alert(_ddlIndicator);
                    getListDdlSubIndicator(_ddlIndicator);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function validateSubmitProject(_projectid) {
        var _post = $.param({
            action: "validateSubmitProject", _projectid: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                
                if (data == "true") {
                    if (confirm("ยืนยันการบันทึกข้อมูล")) {
                        setSubmitProject(_projectid);
                    }
                }
                else if (data == "false_notsumindicator_same"){
                    alert("ข้อมูลจำนวนชั่วโมง Indicator ของ HIDEF กับ MAHIDOL Core Value ไม่เท่ากัน");
                }
                else {
                    alert("กรุณากรอกข้อมูลให้ครบทั้ง 3 Tab (Project,Section,Indicator)");                    
                }
            }
        });

    }


    function setSubmitProject(_projectid) {
        var _post = $.param({
            action: "setSubmitProject", _projectid: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                alert(data);
                window.open("actProjectList.aspx", "_self");
            }
        });

    }

    function getListDdlSubIndicator(_ddlIndicator){
           
        var _post = $.param({ action: "getListDdlSubIndicator", indicatorId: _ddlIndicator
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".spnSubIndicator").html(data);
            }
            });
           
     }


    function getDataClassTodisplaySelectPicker(_projectid){
           
        var _post = $.param({ action: "getClassYearCondition", projectId: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                //alert(data);
                    //$('select[name=selClassYear]').selectpicker('val',   JSON.parse("[\"a\",\"b\"]")); // กรณีเป็นสตริง
                    $('select[name=selClassYear]').selectpicker('val',   JSON.parse(data));
             }
            });
           
     }


     function getDataFacultyTodisplaySelectPicker(_projectid){
           
        var _post = $.param({ action: "getFacultyCondition", projectId: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
               $('select[name=selFaculty]').selectpicker('val',JSON.parse(data));
             }
            });
           
     }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 30 ก.ค. 2560
    // Perpose: Update ข้อมูลปิดโครงการ Flag สถานะ
    // Method : setCloseProject
    function setCloseProject(_projectid) {
   //   $(".divAlertClosePJ").show();
        if (confirm("ยืนยันการปิดโครงการ")) {
            var _post = $.param({ action: "setCloseProject"
                             , uId: "U0001"
                             , projectid: _projectid});
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    getListProject("","","","","");
                  },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 15 ก.ค. 2560
    // Perpose: setCancelProject
    // Method : setCancelProject
    function setCancelProject(_projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProject",
                projectId: _projectId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    getListProject("","","","","");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 21 มิ.ย. 2560
    // Perpose: setCancelProjectCharacter
    // Method : setCancelProjectCharacter
    function setCancelProjectCharacter(_transSectionCharacterId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProjectCharacter",
                transSectionCharacterId: _transSectionCharacterId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "4");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: setCancelSection
    // Method : setCancelSection
    function setCancelSection(_sectionId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelSection",
                sectionId: _sectionId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "2");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: setCancelProjectBudget
    // Method : setCancelProjectBudget
    function setCancelProjectBudget(_transProjectBubgetId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProjectBudget",
                transProjectBubgetId: _transProjectBubgetId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "1");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: setCancelProjectIndicator
    // Method : setCancelProjectIndicator
    function setCancelProjectIndicator(_transSectionIndicatorId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProjectIndicator",
                transSectionIndicatorId: _transSectionIndicatorId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "3");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: setCancelProjectDevice
    // Method : setCancelProjectDevice
    function setCancelProjectDevice(_transSectionDeviceId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProjectDevice",
                transSectionDeviceId: _transSectionDeviceId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "6");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: setCancelProjectPicture
    // Method : setCancelProjectPicture
    function setCancelProjectPicture(_transProjectPictureId, _projectId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelProjectPicture",
                transProjectPictureId: _transProjectPictureId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "5");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: editProjectDevicePage
    // Method : editProjectDevicePage
    function editProjectDevicePage(_transSectionDeviceId, _projectId) {
        var _post = $.param({ action: "editProjectDevicePage",
            transSectionDeviceId: _transSectionDeviceId,
            projectId: _projectId
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $('#divPopup').html(data);
                $('.datetimepicker').datetimepicker();
                $('.btnUpdateProjectDevice').click(function () {
                    setUpdateTransProjectDevice(_transSectionDeviceId, _projectId);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: Update ข้อมูล Project Device
    // Method : setProjectDevice
    function setUpdateTransProjectDevice(_transSectionDeviceId, _projectId) {

        var _ddlSection = $("#divEditProjectDevice").find(".ddlSection").val();
        var _ddlDevice = $("#divEditProjectDevice").find(".ddlDevice").val();
        var _txtStartDateDevice = $("#divEditProjectDevice").find(".txtStartDateDevice").val();
        var _txtEndDateDevice = $("#divEditProjectDevice").find(".txtEndDateDevice").val();

        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectDevice").find(".ddlSection").focus();
            return;
        }
        else if (_ddlDevice == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectDevice").find(".ddlDevice").focus();
            return;
        }



        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateTransProjectDevice",
                sectionId: _ddlSection,
                deviceId: _ddlDevice,
                startDateDevice: _txtStartDateDevice,
                endDateDevice: _txtEndDateDevice,
                uId: "U0001",
                transSectionDeviceId: _transSectionDeviceId
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListProjectDetail(_projectId, "5")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }











//    // Auther : เจตน์ เครือชะเอม
//    // Date   : 19 มิ.ย. 2560
//    // Perpose: editProjectCharacterPage
//    // Method : editProjectCharacterPage
//    function editProjectCharacterPage(_transSectionCharacterId, _projectId) {


//        var _post = $.param({ action: "editProjectCharacterPage",
//            transSectionCharacterId: _transSectionCharacterId,
//            projectId: _projectId
//        });

//        $.ajax({
//            type: "POST",
//            url: "actProjectHandler.ashx",
//            data: _post,
//            success: function (data) {
//                $('#divPopup').html(data);
////                $('.btnUpdateProjectIndicator').click(function () {
////                    setUpdateTransProjectIndicator(_transsectionindicatorid, _projectId);
////                });
//            },
//            error: function (data) {
//                alert(jQuery.error);
//            }
//        });


//    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: editProjectIndicatorPage
    // Method : editProjectIndicatorPage
    function editProjectIndicatorPage(_transsectionindicatorid, _projectId) {


        var _post = $.param({ action: "editProjectIndicatorPage",
            transsectionindicatorid: _transsectionindicatorid,
            projectId: _projectId
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $('#divPopup').html(data);
                $('.btnUpdateProjectIndicator').click(function () {
                    setUpdateTransProjectIndicator(_transsectionindicatorid, _projectId);
                });
                $('.ddlIndicator').change(function () {
                    var _ddlIndicator = $(this).val();
                    //alert(_ddlIndicator);
                    getListDdlSubIndicator(_ddlIndicator);
                });


            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 19 มิ.ย. 2560
    // Perpose: Update ข้อมูล Project Indicator
    // Method : setUpdateTransProjectIndicator
    function setUpdateTransProjectIndicator(_transsectionindicatorid, _projectId) {

        var _ddlSection = $("#divEditProjectIndicator").find(".ddlSection").val();
        var _ddlIndicator = $("#divEditProjectIndicator").find(".ddlIndicator").val();
        var _ddlSubIndicator = $("#divEditProjectIndicator").find(".ddlSubIndicator").val();
        var _txtProjectIndicatoeHour = $("#divEditProjectIndicator").find(".txtProjectIndicatoeHour").val();
        var _txtDescription = $("#divEditProjectIndicator").find(".txtDescription").val();
        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectIndicator").find(".ddlSection").focus();
            return;
        }
        else if (_ddlIndicator == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectIndicator").find(".ddlIndicator").focus();
            return;
        }
        else if (_ddlSubIndicator == "")
        {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectIndicator").find(".ddlSubIndicator").focus();
            return;
        }
        else if (_txtProjectIndicatoeHour.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditProjectIndicator").find(".txtProjectIndicatoeHour").focus();
            return;
        }



        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateTransProjectIndicator",
                sectionId: _ddlSection,
                indicatorId: _ddlIndicator,
                subIndicatorId:_ddlSubIndicator,
                projectIndicatoeHour: _txtProjectIndicatoeHour,
                uId: "U0001",
                transsectionindicatorid: _transsectionindicatorid,
                description: _txtDescription
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListProjectDetail(_projectId, "3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }





    // Auther : เจตน์ เครือชะเอม
    // Date   : 18 มิ.ย. 2560
    // Perpose: editProjectBudgetPage
    // Method : editProjectBudgetPage
    function editProjectBudgetPage(_transProjectBubgetId, _projectId) {

        

        var _post = $.param({ action: "editProjectBudgetPage",
            transProjectBubgetId: _transProjectBubgetId
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $('#divPopup').html(data);
                $('.btnUpdateProjectBudget').click(function () {
                    setUpdateTransProjectBudget(_transProjectBubgetId, _projectId);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 18 มิ.ย. 2560
    // Perpose: Edit ข้อมูล Project Budget
    // Method : setUpdateTransProjectBudget
    function setUpdateTransProjectBudget(_transProjectBubgetId, _projectId) {

       
        var _ddlBudgetTypeId = $("#divEditProjectBudget").find(".ddlBudgetType").val();
        var _txtProjectBudget = $("#divEditProjectBudget").find(".txtProjectBudget").val();
        var _txtProjectPaid = $("#divEditProjectBudget").find(".txtProjectPaid").val();

        if (_ddlBudgetTypeId == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditProjectBudget").find(".ddlBudgetType").focus();
            return;
        }
        else if (_txtProjectBudget.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditProjectBudget").find(".txtProjectBudget").focus();
            return;
        }
        else if (_txtProjectPaid.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditProjectBudget").find(".txtProjectPaid").focus();
            return;
        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateTransProjectBudget",
                transProjectBubgetId: _transProjectBubgetId,
                budgetTypeId: _ddlBudgetTypeId,
                budget: _txtProjectBudget,
                paid: _txtProjectPaid,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListProjectDetail(_projectId, "1")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }





    // Auther : เจตน์ เครือชะเอม
    // Date   : 18 มิ.ย. 2560
    // Perpose: editSectionPage
    // Method : editSectionPage
    function editSectionPage(_sectionid, _projectId) {



            var _post = $.param({ action: "editSectionPage",
                sectionid: _sectionid
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert();
                    $('#divPopup').html(data);
                    $('.datetimepicker').datetimepicker();
                    $(".selectpicker").selectpicker();
                    getDataStatusPassMuxTodisplaySelectPicker(_sectionid); 
                    getDataStatusEnrollmentMuxTodisplaySelectPicker(_sectionid); 
                    $('.btnUpdateProjectSection').click(function () {
                        setUpdateProjectSection(_sectionid, _projectId);
                    });

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });


        }

        function setUpdateProjectSection(_sectionid, _projectId) {
    
//            var _ddlAcaYear = $("#divEditSection").find(".ddlAcaYear").val();
//            var _ddlSemester = $("#divEditSection").find(".ddlSemester").val();
            var _txtSectionNameTh = $("#divEditSection").find("#txtSectionNameTh").val();
            var _txtSectionNameEn = $("#divEditSection").find("#txtSectionNameEn").val();
            var _txtStartDateProjectSection = $("#divEditSection").find(".txtStartDateProjectSection").val();
            var _txtEndDateProjectSection = $("#divEditSection").find(".txtEndDateProjectSection").val();
            var _txtAmountSection = $("#divEditSection").find("#txtAmountSection").val();
            var _txtPlaceSection = $("#divEditSection").find("#txtPlaceSection").val();
        var _txtMuxRefId = $("#divEditSection").find("#txtMuxRefId").val();
        var _ddlStatusPassMux = $("#divEditSection").find(".ddlStatusPassMux").selectpicker("val");
        var _ddlStatusEnrollmentMux = $("#divEditSection").find(".ddlStatusEnrollmentMux").selectpicker("val");


        //alert(_txtMuxRefId);
        //alert(_ddlStatusPassMux);
        //alert(_ddlStatusEnrollmentMux);


            if (_txtSectionNameTh.split(' ').join('_') == "") {
                alert("กรุณากรอกข้อมูล");
                $("#divEditSection").find("#txtSectionNameTh").focus();
                return;
            }
            else if (_txtStartDateProjectSection.split(' ').join('_') == "") {
                alert("กรุณากรอกข้อมูล");
                $("#divEditSection").find("#txtStartDateProjectSection").focus();
                return;
            }
            else if (_txtEndDateProjectSection.split(' ').join('_') == "") {
                alert("กรุณากรอกข้อมูล");
                $("#divEditSection").find("#txtEndDateProjectSection").focus();
                return;
            }
            else if (_txtMuxRefId != "") { 
                if (_ddlStatusPassMux == null) {
                    alert("กรุณาระบุสถานะการสอบ");
                    return;
                }
                else if (_ddlStatusEnrollmentMux == null) {
                    alert("กรุณาระบุสถานะการลงทะเบียน");
                    return;
                }
            }

            
            if (confirm("ต้องการบันทึกข้อมูล")) {
                var _post = $.param({ action: "setUpdateProjectSection",
                    projectSectionId: _sectionid,
//                    acaYear: _ddlAcaYear,
//                    semester: _ddlSemester,
                    sectionNameTh: _txtSectionNameTh,
                    sectionNameEn: _txtSectionNameEn,
                    startDateProjectSection: _txtStartDateProjectSection,
                    endDateProjectSection: _txtEndDateProjectSection,
                    amountSection: _txtAmountSection,
                    placeSection: _txtPlaceSection,
                    txtMuxRefId: _txtMuxRefId,
                    ddlStatusPassMux: escape(_ddlStatusPassMux),
                    ddlStatusEnrollmentMux:escape(_ddlStatusEnrollmentMux),
                    uId: "U0001"
                });

                $.ajax({
                    type: "POST",
                    url: "actProjectHandler.ashx",
                    data: _post,
                    success: function (data) {
                        //alert(data);
                        $('#divPopup').modal('toggle');
                        getListProjectDetail(_projectId, "2")

                    },
                    error: function (data) {
                        alert(jQuery.error);
                    }
                });
            }

        }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Project Picture
    // Method : setProjectPicture
    function setProjectPicture() {


        var _projectId = $("#divProjectMenu7").find(".hddProjectId").val();
        var _txtProjectPictureUpload = pictureName;// $("#divProjectMenu7").find("#txtProjectPictureUpload").val();
        var _txtPictureDetail = $("#divProjectMenu7").find(".txtPictureDetail").val();
        var _txtPictureProjectName = $("#divProjectMenu7").find(".txtPictureProjectName").val();
        var _ddlTypeFileUpload = $("#divProjectMenu7").find(".ddlTypeFileUpload").val();
        // alert(_ddlTypeFileUpload);
        // return;
//        if (_txtPictureProjectName == "") {
//            alert("กรุณาระบุข้อมูล");
//            $("#divProjectMenu7").find(".txtPictureProjectName").focus();
//            return;
//        }
        //alert(_txtProjectPictureUpload);
        if (typeof _txtProjectPictureUpload === "undefined") {
            alert("กรุณาเลือกไฟล์");
            $("#divProjectMenu7").find("#txtProjectPictureUpload").focus();
            return;
        }
        else if (_ddlTypeFileUpload == "") {
            alert("กรุณาเลือกประเภทของรูปภาพ");
            return;
        }
//        var fullPath = document.getElementById('txtProjectPictureUpload').value;
//        if (fullPath) {
//            var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
//            filename = fullPath.substring(startIndex);                                                                                            
//            if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
//                filename = filename.substring(1);
//            }  
//  

//          
//        }
      
        //alert(_extention);
        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProjectPicture",
                projectId: _projectId,
                pictureName: _txtPictureProjectName,
                filename: _txtProjectPictureUpload ,
                pictureDetail: _txtPictureDetail,
                typeFileUploadId: _ddlTypeFileUpload,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "5")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Update ข้อมูลโครงการใหม่
    // Method : setUpdateProject
    function setUpdateProject() {
        var _projectId = $("#divProjectMenu1").find(".hddProjectId").val();
        var _projectNameTh = $("#divProjectMenu1").find(".txtProjectNameTh").val();
        var _projectNameEn = $("#divProjectMenu1").find(".txtProjectNameEn").val();
        var _ddlFaculty = $("#divProjectMenu1").find(".ddlFaculty").selectpicker("val");
        var _ddlClassYear= $("#divProjectMenu1").find(".ddlClassYear").selectpicker("val");
        var _conditionStudentCode= $("#divProjectMenu1").find(".txtConditionStudentCode").val();
        var _ddlProjectType = $("#divProjectMenu1").find(".ddlProjectType").val()
        var _chkStudent = 0;



        if (_projectNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divProjectMenu1").find(".txtProjectNameTh").focus();
            return;
        }
//        else if (_projectNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divProjectMenu1").find(".txtProjectNameEn").focus();
//            return;
//        }
       
        // สำหรับตรวจสอบเรื่องการกรอกข้อมูล StudentCode ไม่ถูกตาม Format
        if($(".chkStudentCode").is(':checked')){
              if(_conditionStudentCode==""){
                        alert("กรุณากรอกข้อมูล");
                        $("#divProjectMenu1").find(".txtConditionStudentCode").focus();
                        return;
              }
              _chkStudent = validateStudentCodeCondition(_conditionStudentCode);
          }
         // alert(_chkStudent);
         if(_chkStudent==1){
            return;
         }
         if(_ddlProjectType==""){
            alert("กรุณาเลือกประเภทโครงการ");
            $("#divProjectMenu1").find(".ddlProjectType").focus();
            return;
         }
        
        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateProject"
                             , uId: "U0001"
                             , acaYear: $("#divProjectMenu1").find(".ddlAcaYear").val()
                             , semester: $("#divProjectMenu1").find(".ddlSemester").val()
                             , instituteId: $("#divProjectMenu1").find(".ddlInstitute").val()
                             , projectNameTh: _projectNameTh
                             , projectNameEn: _projectNameEn
                             , projectDetail: $("#divProjectMenu1").find(".txtProjectDetail").val()
                             , projectDetailEn: $("#divProjectMenu1").find(".txtProjectDetailEn").val()
                             , projectTypeId: _ddlProjectType
                             //, projectStatusId: $("#divProjectMenu1").find(".ddlProjectStatus").val()
//                             , targetGroup: $("#divProjectMenu1").find(".txtTargetGroup").val()
                             , projectId: _projectId
//                             , facultyId: $("#divProjectMenu1").find(".ddlFaculty").val()
                             , startDateRecruit: $("#divProjectMenu1").find(".txtStartDateRecruit").val()
                             , endDateRecruit: $("#divProjectMenu1").find(".txtEndDateRecruit").val()
                             , facultyStr: escape(_ddlFaculty)
                             , classYearStr: escape(_ddlClassYear)
                             , conditionStudentCodeStr:_conditionStudentCode
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProject("","","","","")
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }





    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Project Device
    // Method : setProjectDevice
    function setProjectDevice() {
        var _projectId = $("#divProjectMenu6").find(".hddProjectId").val();
        var _ddlSection = $("#divProjectMenu6").find(".ddlSection").val();
        var _ddlDevice = $("#divProjectMenu6").find(".ddlDevice").val();
        var _txtStartDateDevice = $("#divProjectMenu6").find(".txtStartDateDevice").val();
        var _txtEndDateDevice = $("#divProjectMenu6").find(".txtEndDateDevice").val();

        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu6").find(".ddlSection").focus();
            return;
        }
        else if (_ddlDevice == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu6").find(".ddlDevice").focus();
            return;
        }



        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProjectDevice",
                sectionId: _ddlSection,
                deviceId: _ddlDevice,
                startDateDevice: _txtStartDateDevice,
                endDateDevice: _txtEndDateDevice,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "6")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Project Character
    // Method : setProjectCharacter
    function setProjectCharacter() {

        var _projectId = $("#divProjectMenu5").find(".hddProjectId").val();
        var _ddlSection = $("#divProjectMenu5").find(".ddlSection").val();
        var _ddlCharacter = $("#divProjectMenu5").find(".ddlCharacter").selectpicker("val");
       

        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu5").find(".ddlSection").focus();
            return;
        }
        else if (_ddlCharacter == null) {
           alert("กรุณาเลือกข้อมูล");
           $("#divProjectMenu5").find(".ddlCharacter").focus();
           return;
        }



       if (confirm("ต้องการบันทึกข้อมูล")) {
            //alert(_ddlCharacter);
            var _post = $.param({ action: "setProjectCharacter",
                sectionId: _ddlSection ,
                characterStr: escape(_ddlCharacter),
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "4")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Project Indicator
    // Method : setProjectIndicator
    function setProjectIndicator() {
        var _projectId = $("#divProjectMenu4").find(".hddProjectId").val();
        var _ddlSection = $("#divProjectMenu4").find(".ddlSection").val();
        var _ddlIndicator = $("#divProjectMenu4").find(".ddlIndicator").val();
        var _ddlSubIndicator = $("#divProjectMenu4").find(".ddlSubIndicator").val();

        var _txtProjectIndicatoeHour = $("#divProjectMenu4").find(".txtProjectIndicatoeHour").val();
        var _txtDescription = $("#divProjectMenu4").find(".txtDescription").val();
        //$("#divProjectMenu4").find(".txtDescription").val("5555");
        //alert(_txtDescription);

        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu4").find(".ddlSection").focus();
            return;
        }
        else if (_ddlIndicator == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu4").find(".ddlIndicator").focus();
            return;
        }
        else if (_ddlSubIndicator == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu4").find(".ddlSubIndicator").focus();
            return;
        }
        else if (_txtProjectIndicatoeHour.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divProjectMenu4").find(".txtProjectIndicatoeHour").focus();
            return;
        }


        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProjectIndicator",
                sectionId: _ddlSection,
                indicatorId: _ddlIndicator,
                subIndicator:_ddlSubIndicator,
                projectIndicatoeHour: _txtProjectIndicatoeHour,
                uId: "U0001",
                description: _txtDescription
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Project Budget
    // Method : setProjectBudget
    function setProjectBudget() {

        var _projectId = $("#divProjectMenu3").find(".hddProjectId").val();
        var _ddlBudgetTypeId = $("#divProjectMenu3").find(".ddlBudgetType").val();
        var _txtProjectBudget = $("#divProjectMenu3").find(".txtProjectBudget").val();
        var _txtProjectPaid = $("#divProjectMenu3").find(".txtProjectPaid").val();

        if (_ddlBudgetTypeId == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divProjectMenu3").find(".ddlBudgetType").focus();
            return;
        }
        else if (_txtProjectBudget.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divProjectMenu3").find(".txtProjectBudget").focus();
            return;
        }
        else if (_txtProjectPaid.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divProjectMenu3").find(".txtProjectPaid").focus();
            return;
        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProjectBudget",
                projectId: _projectId,
                budgetTypeId: _ddlBudgetTypeId,
                budget: _txtProjectBudget,
                paid: _txtProjectPaid,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId, "1")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Insert ข้อมูล ProjectSection
    // Method : setProjectSection
    function setProjectSection() {

        var _projectId = $("#divProjectMenu2").find(".hddProjectId").val();
        var _txtSectionNameTh = $("#divProjectMenu2").find("#txtSectionNameTh").val();
        var _txtSectionNameEn = $("#divProjectMenu2").find("#txtSectionNameEn").val();
        var _txtStartDateProjectSection = $("#divProjectMenu2").find(".txtStartDateProjectSection").val();
        var _txtEndDateProjectSection = $("#divProjectMenu2").find(".txtEndDateProjectSection").val();
        var _txtAmountSection = $("#divProjectMenu2").find("#txtAmountSection").val();
        var _txtPlaceSection = $("#divProjectMenu2").find("#txtPlaceSection").val();

        var _txtMuxRefId = $("#divProjectMenu2").find("#txtMuxRefId").val();
        var _ddlStatusPassMux = $("#divProjectMenu2").find(".ddlStatusPassMux").selectpicker("val");
        var _ddlStatusEnrollmentMux = $("#divProjectMenu2").find(".ddlStatusEnrollmentMux").selectpicker("val");


        //alert(_txtMuxRefId);
        //alert(_ddlStatusPassMux);
        //alert(_ddlStatusEnrollmentMux);

        if (_txtSectionNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divProjectMenu2").find("#txtSectionNameTh").focus();
            return;
        }
        else if (_txtStartDateProjectSection.split(' ').join('_') == "") {
                alert("กรุณากรอกข้อมูลวันที่เริ่มต้น");
                $("#divProjectMenu2").find("#txtStartDateProjectSection").focus();
                return;
        }
        else if (_txtEndDateProjectSection.split(' ').join('_') == "") {
                alert("กรุณากรอกข้อมูลวันที่สิ้นสุด");
                $("#divProjectMenu2").find("#txtEndDateProjectSection").focus();
                return;
        }
        else if (_txtMuxRefId != "") { 
            if (_ddlStatusPassMux == null) {
                alert("กรุณาระบุสถานะการสอบ");
                return;
            }
            else if (_ddlStatusEnrollmentMux == null) {
                alert("กรุณาระบุสถานะการลงทะเบียน");
                return;
            }
        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setProjectSection",
                projectId :_projectId,
                sectionNameTh: _txtSectionNameTh,
                sectionNameEn: _txtSectionNameEn,
                startDateProjectSection: _txtStartDateProjectSection,
                endDateProjectSection: _txtEndDateProjectSection,
                amountSection: _txtAmountSection,
                placeSection: _txtPlaceSection,
                txtMuxRefId: _txtMuxRefId,
                ddlStatusPassMux: escape(_ddlStatusPassMux),
                ddlStatusEnrollmentMux:escape(_ddlStatusEnrollmentMux),
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListProjectDetail(_projectId,"2")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 มิ.ย. 2560
    // Perpose: List รายการข้อมูล Tabs สำหรับจัดการ Config
    // Method : getListConfigManage
    function getListConfigManage(_index) {
        Page.Preload.Show();

        var _post = $.param({ action: "getListConfigManage"
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            //beforeSend: function () { loading(); },
            success: function (data) {
                $(".divGetListProject").html(data);
                Page.Preload.Hide();
                $('.nav-tabs li:eq(' + _index + ') a').tab('show');
                $('.btnSetTypeIndicator').click(function () {
                    setIndicator();
                });
                $('.btnSetTypeCharacter').click(function () {
                    setCharater();
                });
                $('.btnSetTypeBudget').click(function () {
                    setBudgetType();
                });
                $('.btnSetTypeDevice').click(function () {
                    setDeviceInfo();
                });
                $('.btnSetTypeGroupCharacter').click(function () {
                    setGroupCharacter();
                });

                $('.btnEditConfigIndicator').click(function () {
                    _indicatorId = $(this).data('indicatorid');
                    editConfigIndicator(_indicatorId);
                });
                $('.btnEditConfigCharacter').click(function () {
                    _characterId = $(this).data('characterid');
                    editConfigCharacter(_characterId);
                });
                $('.btnEditConfigBudget').click(function () {
                    _budgetId = $(this).data('budgetid');
                    editConfigBudget(_budgetId);
                });
                $('.btnEditConfigDevice').click(function () {
                    _deviceId = $(this).data('deviceid');
                    editConfigDevice(_deviceId);
                });
                $('.btnEditConfigGroupCharacter').click(function () {
                    _groupCharacterId = $(this).data('groupcharacterid');
                    editConfigGroupCharacter(_groupCharacterId);
                });
                $('.btnCancelConfigIndicator').click(function () {
                    _indicatorId = $(this).data('indicatorid');
                    setCancelConfigIndicator(_indicatorId);
                });
                $('.btnCancelConfigCharacter').click(function () {
                    _characterId = $(this).data('characterid');
                    setCancelConfigCharacter(_characterId);
                });
                $('.btnCancelConfigBudget').click(function () {
                    _budgetId = $(this).data('budgetid');
                    setCancelConfigBudget(_budgetId);
                });
                $('.btnCancelConfigDevice').click(function () {
                    _deviceId = $(this).data('deviceid');
                    setCancelConfigDevice(_deviceId);
                });
                $('.btnCancelConfigGroupCharacter').click(function () {
                    _groupCharacterId = $(this).data('groupcharacterid');
                    setCancelConfigGroupCharacter(_groupCharacterId);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: setCancelConfigGroupCharacter
    // Method : setCancelConfigGroupCharacter
    function setCancelConfigGroupCharacter(_groupCharacterId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelConfigGroupCharacter",
                groupCharacterId: _groupCharacterId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("1");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: setCancelConfigDevice
    // Method : setCancelConfigDevice
    function setCancelConfigDevice(_deviceId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelConfigDevice",
                deviceId: _deviceId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("3");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: setCancelConfigBudget
    // Method : setCancelConfigBudget
    function setCancelConfigBudget(_budgetId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelConfigBudget",
                budgetId: _budgetId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("3");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: setCancelConfigCharacter
    // Method : setCancelConfigCharacter
    function setCancelConfigCharacter(_characterId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelConfigCharacter",
                characterId: _characterId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("2");

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: setCancelConfigIndicator
    // Method : setCancelConfigIndicator
    function setCancelConfigIndicator(_indicatorId) {
        if (confirm("ยืนยันการลบข้อมูล")) {
            var _post = $.param({ action: "setCancelConfigIndicator",
                indicatorId: _indicatorId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("0")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: editConfigGroupCharacter
    // Method : editConfigGroupCharacter
    function editConfigGroupCharacter(_groupCharacterId) {



        var _post = $.param({ action: "editConfigGroupCharacter",
            groupCharacterId: _groupCharacterId
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {

                $('#divPopup').html(data);
                $('.btnUpdateConfigGroupCharacter').click(function () {
                    setUpdateConfigGroupCharacter(_groupCharacterId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: update ข้อมูล Group Character
    // Method : setUpdateConfigGroupCharacter
    function setUpdateConfigGroupCharacter(_groupCharacterId) {

        var _txtGroupCharacterNameTh = $("#divEditConfigGroupCharacter").find(".txtGroupCharacterNameTh").val();
        var _txtGroupCharacterNameEn = $("#divEditConfigGroupCharacter").find(".txtGroupCharacterNameEn").val();
        var _txtGroupCharacterAbbrevTh = $("#divEditConfigGroupCharacter").find(".txtGroupCharacterAbbrevTh").val();
        var _txtGroupCharacterAbbrevEn = $("#divEditConfigGroupCharacter").find(".txtGroupCharacterAbbrevEn").val();
        var _txtStartYearGroupCharacter = $("#divEditConfigGroupCharacter").find(".txtStartYearGroupCharacter").val();
        var _txtEndYearGroupCharacter = $("#divEditConfigGroupCharacter").find(".txtEndYearGroupCharacter").val();

        if (_txtGroupCharacterNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigGroupCharacter").find(".txtGroupCharacterNameTh").focus();
            return;
        }
//        else if (_txtGroupCharacterNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divEditConfigGroupCharacter").find(".txtGroupCharacterNameEn").focus();
//            return;
//        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateConfigGroupCharacter",
                groupCharacterNameTh: _txtGroupCharacterNameTh,
                groupCharacterNameEn: _txtGroupCharacterNameEn,
                groupCharacterAbbrevTh: _txtGroupCharacterAbbrevTh,
                groupCharacterAbbrevEn: _txtGroupCharacterAbbrevEn,
                startYear: _txtStartYearGroupCharacter,
                endYear: _txtEndYearGroupCharacter,
                uId: "U0001",
                groupCharacterId: _groupCharacterId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListConfigManage("1")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }





    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: editConfigDevice
    // Method : editConfigDevice
    function editConfigDevice(_deviceId) {



        var _post = $.param({ action: "editConfigDevice",
            deviceId: _deviceId
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {

                $('#divPopup').html(data);
                $('.btnUpdateConfigDevice').click(function () {
                    setUpdateConfigDevice(_deviceId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: Update ข้อมูล DeviceInfo
    // Method : setUpdateConfigDevice
    function setUpdateConfigDevice(_deviceId) {

        var _txtDeviceNameTh = $("#divEditConfigDevice").find(".txtDeviceNameTh").val();
        var _txtDeviceNameEn = $("#divEditConfigDevice").find(".txtDeviceNameEn").val();
        var _txtDeviceNumber = $("#divEditConfigDevice").find(".txtDeviceNumber").val();
        if (_txtDeviceNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigDevice").find(".txtDeviceNameTh").focus();
            return;
        }
        else if (_txtDeviceNameEn.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigDevice").find(".txtDeviceNameEn").focus();
            return;
        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateConfigDevice",
                deviceInfoNameTh: _txtDeviceNameTh,
                deviceInfoNameEn: _txtDeviceNameEn,
                deviceNumber: _txtDeviceNumber,
                uId: "U0001",
                deviceId:_deviceId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListConfigManage("3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }







    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: editConfigBudget
    // Method : editConfigBudget
    function editConfigBudget(_budgetId) {



        var _post = $.param({ action: "editConfigBudget",
            budgetId: _budgetId
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {

                $('#divPopup').html(data);
                $('.btnUpdateConfigBudget').click(function () {
                    setUpdateConfigBudget(_budgetId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Update ข้อมูล BudgetType
    // Method : setUpdateConfigBudget
    function setUpdateConfigBudget(_budgetId) {

        var _txtBugetTypeNameTh = $("#divEditConfigBudget").find(".txtBugetTypeNameTh").val();
        var _txtBugetTypeNameEn = $("#divEditConfigBudget").find(".txtBugetTypeNameEn").val();
        var _txtStartYearBugetType = $("#divEditConfigBudget").find(".txtStartYearBugetType").val();
        var _txtEndYearBugetType = $("#divEditConfigBudget").find(".txtEndYearBugetType").val();
        if (_txtBugetTypeNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigBudget").find(".txtBugetTypeNameTh").focus();
            return;
        }
//        else if (_txtBugetTypeNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divEditConfigBudget").find(".txtBugetTypeNameEn").focus();
//            return;
//        }


        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateConfigBudget",
                budgetTypeNameTh: _txtBugetTypeNameTh,
                budgetTyperNameEn: _txtBugetTypeNameEn,
                startYear: _txtStartYearBugetType,
                endYear: _txtEndYearBugetType,
                uId: "U0001",
                budgetId: _budgetId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListConfigManage("3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }






    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: editConfigCharacter
    // Method : editConfigCharacter
    function editConfigCharacter(_characterId) {


       
        var _post = $.param({ action: "editConfigCharacter",
            characterId: _characterId
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {

                $('#divPopup').html(data);
                $('.datetimepicker').datetimepicker();
                $('.btnUpdateConfigCharacter').click(function () {
                      setUpdateConfigCharacter(_characterId);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }








    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: Update ข้อมูล Indicator
    // Method : setUpdateConfigIndicator
    function setUpdateConfigIndicator(_indicatorId) {

        var _txtIndicatorNameTh = $("#divEditConfigIndicator").find(".txtIndicatorNameTh").val();
        var _txtIndicatorrNameEn = $("#divEditConfigIndicator").find(".txtIndicatorNameEn").val();
        var _txtIndicatorAbbrevTh = $("#divEditConfigIndicator").find(".txtIndicatorAbbrevTh").val();
        var _txtIndicatorAbbrevEn = $("#divEditConfigIndicator").find(".txtIndicatorAbbrevEn").val();
        var _txtStartYearIndicator = $("#divEditConfigIndicator").find(".txtStartYearIndicator").val();
        var _txtEndYearIndicator = $("#divEditConfigIndicator").find(".txtEndYearIndicator").val();
        if (_txtIndicatorNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigIndicator").find(".txtIndicatorNameTh").focus();
            return;
        }
//        else if (_txtIndicatorrNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divEditConfigIndicator").find(".txtIndicatorNameEn").focus();
//            return;
//        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateConfigIndicator",
                indicatorNameTh: _txtIndicatorNameTh,
                indicatorNameEn: _txtIndicatorrNameEn,
                indicatorAbbrevTh: _txtIndicatorAbbrevTh,
                indicatorAbbrevEn: _txtIndicatorAbbrevEn,
                startYear: _txtStartYearIndicator,
                endYear: _txtEndYearIndicator,
                indicatorId:_indicatorId,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListConfigManage("0")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: editConfigIndicator
    // Method : editConfigIndicator
    function editConfigIndicator(_indicatorId) {


        //alert(_indicatorId);
        var _post = $.param({ action: "editConfigIndicator",
            indicatorId: _indicatorId
        });

        $.ajax({
            type: "POST",
            url: "actConfigHandler.ashx",
            data: _post,
            success: function (data) {
                
                $('#divPopup').html(data);
                $('.datetimepicker').datetimepicker();
                                $('.btnUpdateConfigIndicator').click(function () {
                                    setUpdateConfigIndicator(_indicatorId);
                                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 มิ.ย. 2560
    // Perpose: Update ข้อมูล Charater
    // Method : setUpdateConfigCharater
    function setUpdateConfigCharacter(_characterId) {

        var _txtCharacterNameTh = $("#divEditConfigCharacter").find(".txtCharacterNameTh").val();
        var _txtCharacterNameEn = $("#divEditConfigCharacter").find(".txtCharacterNameEn").val();
        var _txtCharacterAbbrevTh = $("#divEditConfigCharacter").find(".txtCharacterAbbrevTh").val();
        var _txtCharacterAbbrevEn = $("#divEditConfigCharacter").find(".txtCharacterAbbrevEn").val();
        var _txtStartYearCharacter = $("#divEditConfigCharacter").find(".txtStartYearCharacter").val();
        var _txtEndYearCharacter = $("#divEditConfigCharacter").find(".txtEndYearCharacter").val();
        var _ddlGroupCharacter = $("#divEditConfigCharacter").find(".ddlGroupCharacter").val();
        if (_txtCharacterNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divEditConfigCharacter").find(".txtCharacterNameTh").focus();
            return;
        }
//        else if (_txtCharacterNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divEditConfigCharacter").find(".txtCharacterNameEn").focus();
//            return;
//        }
        else if (_ddlGroupCharacter == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divEditConfigCharacter").find(".ddlGroupCharacter").focus();
            return;
        }



        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setUpdateConfigCharater",
                characterNameTh: _txtCharacterNameTh,
                characterNameEn: _txtCharacterNameEn,
                characterAbbrevTh: _txtCharacterAbbrevTh,
                characterAbbrevEn: _txtCharacterAbbrevEn,
                startYear: _txtStartYearCharacter,
                endYear: _txtEndYearCharacter,
                groupCharacterId: _ddlGroupCharacter,
                uId: "U0001",
                characterId: _characterId
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    $('#divPopup').modal('toggle');
                    getListConfigManage("2")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }






    // Auther : เจตน์ เครือชะเอม
    // Date   : 6 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Group Character
    // Method : setGroupCharacter
    function setGroupCharacter() {

        var _txtGroupCharacterNameTh = $("#divConfigMenu5").find(".txtGroupCharacterNameTh").val();
        var _txtGroupCharacterNameEn = $("#divConfigMenu5").find(".txtGroupCharacterNameEn").val();
        var _txtGroupCharacterAbbrevTh = $("#divConfigMenu5").find(".txtGroupCharacterAbbrevTh").val();
        var _txtGroupCharacterAbbrevEn = $("#divConfigMenu5").find(".txtGroupCharacterAbbrevEn").val();
        var _txtStartYearGroupCharacter = $("#divConfigMenu5").find(".txtStartYearGroupCharacter").val();
        var _txtEndYearGroupCharacter = $("#divConfigMenu5").find(".txtEndYearGroupCharacter").val();

        if (_txtGroupCharacterNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu5").find(".txtGroupCharacterNameTh").focus();
            return;
        }
//        else if (_txtGroupCharacterNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divConfigMenu5").find(".txtGroupCharacterNameEn").focus();
//            return;
//        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setGroupCharacter",
                groupCharacterNameTh: _txtGroupCharacterNameTh,
                groupCharacterNameEn: _txtGroupCharacterNameEn,
                groupCharacterAbbrevTh: _txtGroupCharacterAbbrevTh,
                groupCharacterAbbrevEn: _txtGroupCharacterAbbrevEn,
                startYear: _txtStartYearGroupCharacter,
                endYear: _txtEndYearGroupCharacter,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("1")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Indicator
    // Method : setIndicator
    function setIndicator() {

        var _txtIndicatorNameTh = $("#divConfigMenu1").find(".txtIndicatorNameTh").val();
        var _txtIndicatorrNameEn = $("#divConfigMenu1").find(".txtIndicatorNameEn").val();
        var _txtIndicatorAbbrevTh = $("#divConfigMenu1").find(".txtIndicatorAbbrevTh").val();
        var _txtIndicatorAbbrevEn = $("#divConfigMenu1").find(".txtIndicatorAbbrevEn").val();
        var _txtStartYearIndicator = $("#divConfigMenu1").find(".txtStartYearIndicator").val();
        var _txtEndYearIndicator = $("#divConfigMenu1").find(".txtEndYearIndicator").val();
        if (_txtIndicatorNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu1").find(".txtIndicatorNameTh").focus();
            return;
        }
//        else if (_txtIndicatorrNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divConfigMenu1").find(".txtIndicatorNameEn").focus();
//            return;
//        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setIndicator",
                            indicatorNameTh :_txtIndicatorNameTh ,
	                        indicatorNameEn :_txtIndicatorrNameEn,
	                        indicatorAbbrevTh :_txtIndicatorAbbrevTh,
	                        indicatorAbbrevEn :_txtIndicatorAbbrevEn,
	                        startYear :_txtStartYearIndicator,
	                        endYear :_txtEndYearIndicator,
	                        uId :"U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("0")
    
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Insert ข้อมูล Charater
    // Method : setCharater
    function setCharater() {

        var _txtCharacterNameTh = $("#divConfigMenu2").find(".txtCharacterNameTh").val();
        var _txtCharacterNameEn = $("#divConfigMenu2").find(".txtCharacterNameEn").val();
        var _txtCharacterAbbrevTh = $("#divConfigMenu2").find(".txtCharacterAbbrevTh").val();
        var _txtCharacterAbbrevEn = $("#divConfigMenu2").find(".txtCharacterAbbrevEn").val();
        var _txtStartYearCharacter = $("#divConfigMenu2").find(".txtStartYearCharacter").val();
        var _txtEndYearCharacter = $("#divConfigMenu2").find(".txtEndYearCharacter").val();
        var _ddlGroupCharacter = $("#divConfigMenu2").find(".ddlGroupCharacter").val();
        if (_txtCharacterNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu2").find(".txtCharacterNameTh").focus();
            return;
        }
//        else if (_txtCharacterNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divConfigMenu2").find(".txtCharacterNameEn").focus();
//            return;
//        }
        else if (_ddlGroupCharacter == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divConfigMenu2").find(".ddlGroupCharacter").focus();
            return;
        }



        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setCharater",
                characterNameTh: _txtCharacterNameTh,
                characterNameEn: _txtCharacterNameEn,
                characterAbbrevTh: _txtCharacterAbbrevTh,
                characterAbbrevEn: _txtCharacterAbbrevEn,
                startYear: _txtStartYearCharacter,
                endYear: _txtEndYearCharacter,
                groupCharacterId: _ddlGroupCharacter,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("2")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Insert ข้อมูล BudgetType
    // Method : setBudgetType
    function setBudgetType() {

        var _txtBugetTypeNameTh = $("#divConfigMenu3").find(".txtBugetTypeNameTh").val();
        var _txtBugetTypeNameEn = $("#divConfigMenu3").find(".txtBugetTypeNameEn").val();
        var _txtStartYearBugetType = $("#divConfigMenu3").find(".txtStartYearBugetType").val();
        var _txtEndYearBugetType = $("#divConfigMenu3").find(".txtEndYearBugetType").val();
        if (_txtBugetTypeNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu3").find(".txtBugetTypeNameTh").focus();
            return;
        }
//        else if (_txtBugetTypeNameEn.split(' ').join('_') == "") {
//            alert("กรุณากรอกข้อมูล");
//            $("#divConfigMenu3").find(".txtBugetTypeNameEn").focus();
//            return;
//        }
  

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setBudgetType",
                budgetTypeNameTh: _txtBugetTypeNameTh,
                budgetTyperNameEn: _txtBugetTypeNameEn,
                startYear: _txtStartYearBugetType,
                endYear: _txtEndYearBugetType,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 3 มิ.ย. 2560
    // Perpose: Insert ข้อมูล DeviceInfo
    // Method : setDeviceInfo
    function setDeviceInfo() {

        var _txtDeviceNameTh = $("#divConfigMenu4").find(".txtDeviceNameTh").val();
        var _txtDeviceNameEn = $("#divConfigMenu4").find(".txtDeviceNameEn").val();
        var _txtDeviceNumber = $("#divConfigMenu4").find(".txtDeviceNumber").val();
        if (_txtDeviceNameTh.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu4").find(".txtDeviceNameTh").focus();
            return;
        }
        else if (_txtDeviceNameEn.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divConfigMenu4").find(".txtDeviceNameEn").focus();
            return;
        }

        if (confirm("ต้องการบันทึกข้อมูล")) {
            var _post = $.param({ action: "setDeviceInfo",
                deviceInfoNameTh: _txtDeviceNameTh,
                deviceInfoNameEn: _txtDeviceNameEn,
                deviceNumber: _txtDeviceNumber,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actConfigHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    getListConfigManage("3")

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 มิ.ย. 2560
    // Perpose: Load ข้อมูลสำหรับเพิ่มนักศึกษาที่ลงทะเบียนตาม Section
    // Method : addSectionRegisterStudentOnly
    function addSectionRegisterStudentOnly(_projectId, _projectNameTh) {

        var _post = $.param({ action: "addSectionRegisterStudentOnly",
            projectId: _projectId,
            projectNameTh: _projectNameTh,
            uId: "U0001"
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGetListProject").html(data);
                $('.txtStudentCode').on('keypress', function (e) {
                    if (e.which === 13) {
                        addStudentEachOnly();
                        return false;

                    }
                });
                $('.btnBack').click(function () {
                    getlistStudentRegistSection(_projectid);
                });
                //                $('.btnSetStudentRegistSection').click(function () {
                //                    setStudentRegistSection();
                //                });
                $('.btnAddStudentEachOnly').click(function () {
                    addStudentEachOnly();
                });
                $('.btnSetStudentEachOnly').click(function () {
                    setStudentEachOnly(_projectid, _projectNameTh, "tblStudentRegistTemp");
                });



            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 24 มิ.ย. 2560
    // Perpose: Inset ข้อมูลนักศึกษารายคนลงฐานจริง
    // Method : setStudentEachOnly
    function setStudentEachOnly(_projectid, _projectNameTh,tblName) {

        var _tb = $("." + tblName);
            var _item = new Array();
            var _count = 0;
            var _studentCodeVal = _tb.find(".studentCodeVal");
            var _sectionIdVal = _tb.find(".sectionIdVal");
            var _positionIdVal = _tb.find(".positionIdVal");
            var _chkStudentRegistSection = _tb.find(".chkStudentRegistSection");
            $(_chkStudentRegistSection).each(function (index) { // เจตน์ เพิ่มวันที่ 12 พ.ย. 2557
                if ($(this).is(':checked')) {
                    _count++;
                    //                alert(_studentCodeVal[index].value);
                    //                alert(_sectionIdVal[index].value);
                    //                alert(_positionIdVal[index].value);
                    _item.push({ studentCode: _studentCodeVal[index].value,
                        sectionId: _sectionIdVal[index].value,
                        positionId: _positionIdVal[index].value
                    });
                }

            });
            //alert(_count);
        if (_count == 0) {
            alert("ไม่พบข้อมูลที่จะบันทึก");
            return;
            }
        if (confirm("ยืนยันบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setStudentRegistOnly", itemList: JSON.stringify(_item), uId: "U0001"
            });
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    getlistStudentRegistSection(_projectid);

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
      
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 23 มิ.ย. 2560
    // Perpose: Add ข้อมูลนักศึกษารายคนลง Temp
    // Method : addStudentEachOnly
    function addStudentEachOnly() {
        var _ddlSection = $("#divSectionStudentOnly").find(".ddlSection").val();
        var _txtStudentCode = $("#divSectionStudentOnly").find(".txtStudentCode").val();
        var _ddlPosition = $("#divSectionStudentOnly").find(".ddlPosition").val();



        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divSectionStudentOnly").find(".ddlSection").focus();
            return;
        }
        else if (_txtStudentCode.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divSectionStudentOnly").find(".txtStudentCode").focus();
            return;
        }
        else if (_ddlPosition == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divSectionStudentOnly").find(".ddlPosition").focus();
            return;
        }
        var _tb = $(".tblStudentRegistTemp");
        var _studentCodeVal = _tb.find(".studentCodeVal");
        var _sectionIdVal = _tb.find(".sectionIdVal");
        var _isDup = false;
        $(_studentCodeVal).each(function (index) { // เจตน์ เพิ่มวันที่ 12 พ.ย. 2557

            if ((_studentCodeVal[index].value == (_txtStudentCode)) && (_sectionIdVal[index].value == (_ddlSection))) {
                //alert("รหัสนักศึกษานี้มีใน Section นี้แล้ว");
                alert("กรอกข้อมูลซ้ำ กรุณาตรวจสอบ!");
                _isDup = true;
            }


        });

        if (_isDup) {
            return;
        }
        var _post = $.param({ action: "addStudentEachOnly",
            sectionId: _ddlSection,
            studentCode: _txtStudentCode,
            uId: "U0001",
            positionId: _ddlPosition
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                $(".tblStudentRegistTemp").append(data);
                $("#divSectionStudentOnly").find(".txtStudentCode").val("");
                $("#divSectionStudentOnly").find(".txtStudentCode").focus();

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });


    }








    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 มิ.ย. 2560
    // Perpose: Update ข้อมูลเพื่อยกเลิกรายการข้อมูลนักศึกษา
    // Method : setCancelStudentRegist
    function setCancelStudentRegist(_projectid, _sectionid, _studentid, _projectNameTh, _transsectionregistid) {
        if(confirm("ยืนยันการลบข้อมูล")){
            var _post = $.param({ action: "setCancelStudentRegist",
                sectionId: _sectionid,
                studentid: _studentid,
                transsectionregistid:_transsectionregistid,
                uId: "U0001"
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    //AddSectionRegister(_projectid);
                    getlistStudentRegistSection(_projectid);

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 มิ.ย. 2560
    // Perpose: Insert ข้อมูล StudentRegistSection
    // Method : setStudentRegistSection
    function setStudentRegistSection() {
        var _projectId = $("#divSectionStudentRegist").find(".hddProjectId").val();
        var _ddlSection = $("#divSectionStudentRegist").find(".ddlSection").val();
        var _txtStudentCode = $("#divSectionStudentRegist").find(".txtStudentCode").val();
        var _ddlPosition = $("#divSectionStudentRegist").find(".ddlPosition").val();

        if (_ddlSection == "") {
            alert("กรุณาเลือกข้อมูล");
            $("#divSectionStudentRegist").find(".ddlSection").focus();
            return;
        }
        else if (_txtStudentCode.split(' ').join('_') == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divSectionStudentRegist").find(".txtStudentCode").focus();
            return;
        }
        else if (_ddlPosition == "") {
            alert("กรุณากรอกข้อมูล");
            $("#divSectionStudentRegist").find(".ddlPosition").focus();
            return;
        }

   
            var _post = $.param({ action: "setStudentRegistSection",
                sectionId: _ddlSection,
                projectId: _projectId,
                studentCode: _txtStudentCode,
                uId: "U0001",
                positionId: _ddlPosition
            });

            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    //alert(data);
                    ListStudentRegister(_projectId);

                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });


        }




        // Auther : เจตน์ เครือชะเอม
        // Date   : 5 มิ.ย. 2560
        // Perpose: Load ข้อมูลสำหรับเพิ่มนักศึกษาที่ลงทะเบียนตาม Section
        // Method : ListStudentRegister
        function ListStudentRegister(_projectId) {
            var _post = $.param({ action: "ListStudentRegister",
                projectId: _projectId,
                uId: "U0001"
            });
            $.ajax({
                type: "POST",
                url: "actProjectHandler.ashx",
                data: _post,
                success: function (data) {
                    $(".divListStudentRegist").html(data);
                    $("#divSectionStudentRegist").find(".txtStudentCode").val("");
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });

        }





    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListReportCenturySkill
    function getListReportCenturySkill(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId) {
        getListHeaderCenturySkill(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId);
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderCenturySkill
    function getListHeaderCenturySkill(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListHeaderShortProfile", studentCode:_studentCode, stsShowSummaryAct: "0", txtDisplayHeader: "21st Century Skill Outcomes"
        ,countProject:_countProject,sumHour:_sumHour,groupIndicatorId:"",groupCharacterId:_groupCharacterId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divProfileStudent02").html(data);
                getCharacterSummary("","","","","GCR-002",_studentId,"container02");
                getListDefinitionCenturySkill("#divTab2");
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListDefinitionCenturySkill
    function getListDefinitionCenturySkill(_root) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListDefinitionCenturySkill"
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_root).find("#divDefinitionCoreValue02").html(data);
            }
        });
    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListReportTQF
    function getListReportTQF(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId) {
        getListHeaderTQF(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId);
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderTQF
    function getListHeaderTQF(_studentCode,_studentId,_countProject,_sumHour,_groupCharacterId) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListHeaderShortProfile", studentCode: _studentCode, stsShowSummaryAct: "0", txtDisplayHeader: "TQF มาตรฐานการเรียนรู้ 5 ด้าน"
        ,countProject:_countProject,sumHour:_sumHour,groupIndicatorId:"",groupCharacterId:_groupCharacterId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Show();
                $("#divProfileStudent03").html(data);
                getCharacterSummary("","","","","GCR-001",_studentId,"container03"); 
                getListDefinitionTQF("#divTab3");
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: แสดงรายงานมหิดลคอร์วารู
    // Method : getCharacterSummary
    function getCharacterSummary(_acaYear,_semester,_facultyId,_programId,_groupCharacterId,_studentId,_divId) {
        Page.Preload.Show();
        var _post = $.param({ action: "getCharacterSummary", studentId: _studentId, groupCharacterId: _groupCharacterId, facultyId: _facultyId, programId: _programId, acaYear: _acaYear,semester:_semester
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: _divId,
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{ tickmarkPlacement: 'on',
                            lineWidth: 0
                        }],
                        series: [{
                    }]
                };
                options.xAxis[0].categories = obj.name;
                options.series[0].name = "จำนวนกิจกรรม";
                options.series[0].data = obj.data;
                var chart = new Highcharts.Chart(options);
            });

        }
    });
}



    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListDefinitionTQF
    function getListDefinitionTQF(_root) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListDefinitionTQF"
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_root).find("#divDefinitionCoreValue03").html(data);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListReportCoreValue
    function getListReportCoreValue(_studentCode, _studentId, _countProject, _sumHour, groupIndicatorId, _txtDisplayHeader, _root,_idContainner,_idDef,_groupCharacterId) {
        getListHeaderCoreValue(_studentCode, _studentId, _countProject, _sumHour, groupIndicatorId, _txtDisplayHeader, _root,_groupCharacterId);
        getlistRptMahidolCoreValue("", "", "", "", _studentId, _idContainner, groupIndicatorId);
        getListDefinitionCoreValue(groupIndicatorId, _root, _idDef);
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListDefinitionCoreValue
    function getListDefinitionCoreValue(_groupIndicatorId,_root,_div) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getListDefinitionCoreValue", groupIndicatorId: _groupIndicatorId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_root).find(_div).html(data);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderCoreValue
    function getListHeaderCoreValue(_studentCode, _studentId, _countProject, _sumHour, groupIndicatorId, _txtDisplayHeader,_root,_groupCharacterId) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getListHeaderShortProfile", studentCode: _studentCode, stsShowSummaryAct: "1", txtDisplayHeader: _txtDisplayHeader
           ,countProject:_countProject,sumHour:_sumHour,groupIndicatorId:groupIndicatorId,groupCharacterId:_groupCharacterId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(_root).find("#divProfileStudent").html(data);

            }
        });
    }
    

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: แสดงรายงานมหิดลคอร์วารู
    // Method : getlistRptMahidolCoreValue
    function getlistRptMahidolCoreValue(_facultyId, _programId, _acaYear, _semester, _studentId, _divName, _groupIndicatorId) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getlistRptMahidolCoreValue", studentId: _studentId, facultyId: _facultyId, programId: _programId, acaYear: _acaYear, semester: _semester, groupIndicatorId: _groupIndicatorId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                // var obj = JSON.parse(jSonData);
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: _divName,
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{tickmarkPlacement: 'on',
                                 lineWidth: 0
                               }],
                        series: [{                  
                                }]
                    };
                    options.xAxis[0].categories = obj.name;
                    options.series[0].name = "จำนวนชั่วโมง";
                    options.series[0].data = obj.data;
                    var chart = new Highcharts.Chart(options);
                });

            }
        });
    }


    function getListStudentRegistPublicEvent(_projectId,_projectNameTh,_ddlAcaYear ,_ddlSemester , _ddlFaculty , _projectName) {
        //alert(_projectId);
        var _post = $.param({ action: "getListStudentRegistPublicEvent", projectId: _projectId ,projectNameTh:_projectNameTh
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divGetListProject").html(data);
                $(document).ready(function () {
                    $(".divStdRegisOnline").find("#tblStdRegistPublicEvent").DataTable();
                });
                //$('.btnBack').click(function () {
                //    window.open("actProjectList.aspx", "_self");
                //});
                $('.btnBack').click(function () {
                    //alert(_ddlAcaYear);
                    //alert(_ddlSemester);
                    //alert(_ddlFaculty);
                    //alert(_projectName);
                    getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName,"");
                });
                //alert(1);
                $('.btnExportExcel').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _sectionId = $(this).data("sectionid");
                    window.open("actStudentRegisOnlineExcel.aspx?projectId="+_projectId+"&sectionId="+_sectionId, "_self");
                });
                $('.ddlSection').change(function () {
                    var _sectionId = $(this).val();
                    getListStudentRegistPublicEventBySection(_projectId,_sectionId) 
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }




     function getListStudentRegistPublicEventBySection(_projectId,_sectionId) {
        var _post = $.param({ action: "getListStudentRegistPublicEventBySection", projectId: _projectId ,sectionId:_sectionId
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divStdRegisOnline").html(data);
                $(document).ready(function () {
                    $(".divStdRegisOnline").find("#tblStdRegistPublicEvent").DataTable();
                });
                $('.btnBack').click(function () {
                    
                    //getListProject(_ddlAcaYear , _ddlSemester , _ddlFaculty , _projectName);
                    window.open("actProjectList.aspx", "_self");
                });
                //alert(2);
                $('.btnExportExcel').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _sectionId = $(this).data("sectionid");
                    window.open("actStudentRegisOnlineExcel.aspx?projectId="+_projectId+"&sectionId="+_sectionId, "_self");
                });
                $('.ddlSection').change(function () {
                    var _sectionId = $(this).val();
                    getListStudentRegistPublicEventBySection(_projectId, _sectionId);
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    function getListJsonDataPrintAtEng() {
        var _tb = $("#tblStudentAT");
        var _item = new Array();
        var _count = 0;

        var _chkStudentRegistSection = _tb.find(".chkStudentPrintAT");
        $(_chkStudentRegistSection).each(function (index) { 
            if ($(this).is(':checked')) {
                //alert($(this).data("studentcode"));
                _item.push({ studentCode: $(this).data("studentcode") });
                _count++;
                }
        });
        if (_count == 0) {
            alert("กรุณาเลือกรายการนักศึกษาที่ต้องการพิมพ์");
            return;
        }
        post_to_url("../student/actAtTranscript.aspx?language=en", { itemList: JSON.stringify(_item), submit: "submit" });
          //post_to_url("../student/actAtTranscriptEng.aspx", { itemList:JSON.stringify(_item),submit: "submit" } );

    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 พ.ย. 2562
    // Perpose: แสดงรายงานมหิดลคอร์วารู
    // Method : getlistRptMahidolCoreValueUniversity
    function getlistRptMahidolCoreValueUniversity(_facultyId, _programId, _acaYear, _semester, _studentId, _divName, _groupIndicatorId,_indicatorId) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getMahidolCoreValueUniversity", studentId: _studentId, facultyId: _facultyId, programId: _programId, acaYear: _acaYear, semester: _semester, groupIndicatorId: _groupIndicatorId,indicatorId:_indicatorId
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                // var obj = JSON.parse(jSonData);
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: _divName,
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{tickmarkPlacement: 'on',
                                 lineWidth: 0
                               }],
                        series: [{                  
                                }]
                    };
                    options.xAxis[0].categories = obj.name;//obj.name;
                    options.series[0].name = "จำนวนชั่วโมง";
                    options.series[0].data = obj.data;
                    var chart = new Highcharts.Chart(options);
                });

            }
        });
    }




    function getCharacterSummaryUniversity(_acaYear, _semester, _facultyId, _programId, _groupCharacterId, _studentId, _divId) {
        Page.Preload.Show();
        var _post = $.param({
            action: "getCharacterSummaryUniversity", studentId: _studentId, groupCharacterId: _groupCharacterId, facultyId: _facultyId, programId: _programId, acaYear: _acaYear, semester: _semester
        });

        $.ajax({
            type: "POST",
            url: "../student/actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                Page.Preload.Hide();
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: _divId,
                            polar: true,
                            type: 'line'
                        },
                        title: {
                            text: '',
                            x: -80
                        },
                        yAxis: {
                            gridLineInterpolation: 'polygon',
                            lineWidth: 0,
                            min: 0
                        },
                        tooltip: {
                            shared: true,
                            pointFormat: '<span style="color:{series.color}">{series.name}: <b>${point.y:,.0f}</b><br/>'
                        },
                        legend: {
                            align: 'right',
                            verticalAlign: 'top',
                            y: 70,
                            layout: 'vertical'
                        },
                        xAxis: [{
                            tickmarkPlacement: 'on',
                            lineWidth: 0
                        }],
                        series: [{
                        }]
                    };
                    options.xAxis[0].categories = obj.name;
                    options.series[0].name = "จำนวนกิจกรรม";
                    options.series[0].data = obj.data;
                    var chart = new Highcharts.Chart(options);
                });

            }
        });
    }



    function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
    }

    function getDataStatusPassMuxTodisplaySelectPicker(_sectionid){
           
        var _post = $.param({ action: "getDataStatusPassMuxTodisplaySelectPicker", sectionid: _sectionid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                //alert("[pass,notpass]");
                   $('#divEditSection').find('select[name=selStatusPassMux]').selectpicker('val', JSON.parse(data));
                }
            });
           
    }


    function getDataStatusEnrollmentMuxTodisplaySelectPicker(_sectionid){
           
        var _post = $.param({ action: "getDataStatusEnrollmentMuxTodisplaySelectPicker", sectionid: _sectionid
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            success: function (data) {
                //alert("[pass,notpass]");
                   $('#divEditSection').find('select[name=selStatusEnrollmentMux]').selectpicker('val', JSON.parse(data));
                }
            });
           
     }





    //function cookiesPageAt() {
    //    alert();
    //}

</script>
