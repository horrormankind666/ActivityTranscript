<%@ Page Language="C#" AutoEventWireup="true" CodeFile="actStdMain.aspx.cs" Inherits="modules_student_actStdMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
        @media screen and (min-width: 800px) {
	         #divPopup .modal-dialog  {width:1000px;}
        }
</style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class='container-fluid '>

            <div class='divBarMenu' >
            </div>

            <div class="col-md-3 page-header divSideBarMenu" >
            </div>


            <div  class="col-md-9 divStdMain"  >
            </div>

    </div>
 
    <div id="divPopup"  class='modal fade ' role='dialog'>
    </div>


  
    </form>
</body>
</html>

<script type="text/javascript">





    loadBarMenuStd();
    loadSidebarMenuStd();
    getListStudentProfile();


    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ส.ค. 2560
    // Perpose: แสดงเมนู Profile Student
    // Method : loadBarMenu
    function getListStudentProfile() {
        Page.Preload.Show();
        var _post = $.param({ action: "getListStudentProfile"  });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divStdMain").html(data);
                $(".divSideBarMenu").find(".btnHome").click(function () {
                    getListStudentProfile();
                });
                $(".divSideBarMenu").find(".btnLoadContractUs").click(function () {
                    getListLoadContactUs();
                });
                $(".divSideBarMenu").find(".btnSearchActivity").click(function () {
                    searchActivity();
                });
                $(".divSideBarMenu").find(".btnGetListActivitiesByStudent").click(function () {
                    getListActivitiesByStudent();
                });
                $(".divSideBarMenu").find(".btnLoadApprovePage").click(function () {
                    getListActivitySchorlarship();
                });

                

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }
    // Auther : เจตน์ เครือชะเอม
    // Date   : 14 ก.ย. 2560
    // Perpose: แสดงหน้าจอกิจกรรมเพื่อยื่นกู้เงินกยศ.
    // Method : getListActivitySchorlarship
    function getListActivitySchorlarship() {
        Page.Preload.Show();
        var _post = $.param({ action: "getListActivitySchorlarship"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divStdMain").html(data);
                $(".divStdMain").find(".btnGetListActDetailForScholarship").click(function () {
                    _acaYear = $(this).data('acayear');
                    getListActDetailForScholarship(_acaYear);
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 14 ก.ย. 2560
    // Perpose: แสดงหน้ารายการข้อมูลกิจกรรมที่เข้าร่วมที่ได้ค่า A1 ด้านบำเพ็ญประโยชน์
    // Method : getListActDetailForScholarship
    function getListActDetailForScholarship(_acaYear) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListActDetailForScholarship", acaYear: _acaYear
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();

                $(".divDetailActForScholarship").html(data);
                $(".divDetailActForScholarship").find(".btnPrintActForScholarship").click(function () {
                    var printContents = document.getElementById('divActScholarship').innerHTML;
                    var originalContents = document.body.innerHTML;
                    document.body.innerHTML = "<html><head><title></title></head><body>" + printContents + "</body>";
                    window.print();
                    document.body.innerHTML = originalContents;

                });
                $(".divDetailActForScholarship").find(".btnSendDataScholarship").click(function () {
                    _stsScholarship = $(this).data('stsscholarship');
                    _studentId = $(this).data('studentid');
                    _acaYear = $(this).data('acayear');
                    //                    alert(_stsScholarship);
                    //                    alert(_studentId);
                    //                    alert(_acaYear);
                    if (_stsScholarship == "0") {
                        if (confirm("ยืนยันการบันทึกข้อมูล")) {
                            setListSendActForScholarship(_acaYear, _studentId);
                        }
                    }
                    else {
                        alert("ได้ยืนยันการส่งข้อมูลเรียบร้อยแล้ว");
                        return;
                    }
                });
                $(".divDetailActForScholarship").find(".btnGetListSchStudentSendAct").click(function () {
                    getListSchStudentSendAct();
                });


            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 15 ก.ย. 2560
    // Perpose: แสดงข้อมูลรายการนักศึกษาที่ส่งข้อมูลกิจกรรมเพื่อยื่นกู้เงิน กยศ./กรอ.
    // Method : getListSchStudentSendAct
    function getListSchStudentSendAct() {
        Page.Preload.Show();
        var _post = $.param({ action: "getListSchStudentSendAct"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                //$(".divStdMain").html(data);
                //alert(data);
                $("#divPopup").html(data);
                $(document).ready(function () {
                    $('#tblListStdSchAct').DataTable();
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

  

    // Auther : เจตน์ เครือชะเอม
    // Date   : 15 ก.ย. 2560
    // Perpose: หน้าสำหรับบันทึกการส่งยืนยันทุนในการตรวจสอบกิจกรรม
    // Method : setListSendActForScholarship
    function setListSendActForScholarship(_acaYear, _studentId) {
        Page.Preload.Show();
        var _post = $.param({ action: "setListSendActForScholarship", acaYear: _acaYear, studentId: _studentId
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                alert(data);
                getListActDetailForScholarship(_acaYear)
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ส.ค. 2560
    // Perpose: แสดงหน้ารายงานกิจกรรมที่เข้าร่วมของนักศึกษา
    // Method : getListActivitiesByStudent
    function getListActivitiesByStudent() {
        Page.Preload.Show();
        var _post = $.param({ action: "getListActivitiesByStudent"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divStdMain").html(data);
                
                $(".divStdMain").find(".btnActivityTranscript").click(function(){
                  _studentCode = $(this).data('studentcode');
                  window.open("actAtTranscript.aspx");
                 });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ส.ค. 2560
    // Perpose: แสดงหน้าเงื่อนไขการค้นหาข้อมูลกิจกรรม
    // Method : searchActivity
    function searchActivity() {
        Page.Preload.Show();
        var _post = $.param({ action: "searchActivity"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divStdMain").html(data);
                $(".divStdMain").find(".btnSearchProject").click(function () {
                    resultActivity();
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 13 ก.ย.2560
    // Perpose: แสดงหน้าจอรายการโครงการที่ค้นหาเจอตามเงื่อนไข
    // Method : resultActivity
    function resultActivity() {
        Page.Preload.Show();
        var _activityName = $(".divStdMain").find(".txtActivityName").val();
        var _acaYear = $(".divStdMain").find(".ddlAcaYear").val();
        var _projectType = $(".divStdMain").find(".ddlProjectType").val();
        var _projectStatus = $(".divStdMain").find(".ddlProjectStatus").val();
//        alert(_activityName);
//        alert(_acaYear);
//        alert(_projectType);
//        alert(_projectStatus);
        var _post = $.param({ action: "resultActivity", activityName: _activityName, acaYear: _acaYear, 
                              projectType: _projectType, projectStatus: _projectStatus
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divResultActivity").html(data);
                $(document).ready(function () {
                    $('#tblActivityList').DataTable();
                });
                $(".divResultActivity").find(".btnGetListActivityShoppingDetail").click(function () {

                    _projectid = $(this).data('projectid');
                    getListProjectDetailForShopping(_projectid);

                });
                


            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 ต.ค. 2560
    // Perpose: แสดงเมนูหน้าแสดงรายละเอียดข้อมูลเพื่อนจะให้นักศึกษา Shopping ดู
    // Method : getListProjectDetailForShopping
    function getListProjectDetailForShopping(_projectid) {
        Page.Preload.Show();
        //alert(_projectid);
        var _post = $.param({ action: "getListProjectDetailForShopping", projectId: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $('.divStdMain').html(data);
                $('.divStdMain').find('.btnBack').click(function () {
                    searchActivity();
                });
                $('.divStdMain').find('.btnGetlistSectionForShopping').click(function () {
                    _projectid = $(this).data('projectid');
                    _countsection = $(this).data('countsection');
                    _stsjoinsectionall = $(this).data('stsjoinsectionall');
                    
                    if (_countsection == "0") {
                        alert("ไม่มีการกำหนด Section ของกิจกรรมดังกล่าว กรุณาติดต่อเจ้าหน้าที่คณะเพื่อตรวจสอบข้อมูล");
                        return false;
                    }
                    else if (_stsjoinsectionall!="0"){
                        alert("ได้สมัครเข้าร่วมกิจกรรมนี้แล้ว");
                        return false;
                    }
                    else {
                        getlistSectionForShopping(_projectid);
                    }
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 ต.ค. 2560
    // Perpose: แสดงรายการสำหรับให้นักศึกษาเลือก Section
    // Method : getlistSectionForShopping
    function getlistSectionForShopping(_projectid) {
            Page.Preload.Show();
            var _post = $.param({ action: "getlistSectionForShopping", projectId: _projectid
            });

            $.ajax({
                type: "POST",
                url: "actStdHandler.ashx",
                data: _post,
                success: function (data) {

                    Page.Preload.Hide();
                    $("#divPopup").html(data);
                    $('#divPopup').find('.btnSetListSectionForShopping').click(function () {
                            setListSectionForShopping();
                    });


                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });

        }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 4 ต.ค. 2560
    // Perpose: บันทึกข้อมูลการเข้าร่วม Section
    // Method : loadBarMenu
    function setListSectionForShopping() {
        var _tb = $("#tblListSection");
        var _item = new Array();
        var _count = 0;
        var _chkOver = 0;
        var _projectSectionId = _tb.find(".projectSectionId");
        var _amountMax = _tb.find(".amountMax");
        var _amountCountStudent = _tb.find(".amountCountStudent");
        var _chkSectionListShopping = _tb.find(".chkSectionListShopping");
        $(_chkSectionListShopping).each(function (index) {
            if ($(this).is(':checked')) {
                if (_amountCountStudent[index].value >= _amountMax[index].value) {
                    _chkOver = 1;
                }
                _count++;
                _item.push({ projectSectionId: _projectSectionId[index].value });
            }
        });
        if (_chkOver == 1) {
            alert("จำนวนที่รับเกินจำนวนผู้สมัครแล้ว ไม่สามารถเข้าร่วมกิจกรรมนี้ได้");
            return;
        }
        else if (_count == 0) {
            alert("กรุณาเลือกรายการ Section ที่ต้องการเข้าร่วม");
            return;
        }
        else {
            if (confirm("ยืนยันการบันทึกข้อมูล")) {
                var _post = $.param({ action: "setListSectionForShopping", itemList: JSON.stringify(_item),
                });
                $.ajax({
                    type: "POST",
                    url: "actStdHandler.ashx",
                    data: _post,
                    success: function (data) {
                        alert(data);

                    },
                    error: function (data) {
                        alert(jQuery.error);
                    }
                });
            }
        }
    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ส.ค. 2560
    // Perpose: แสดงเมนู Menu bar ของนักศึกษา
    // Method : loadBarMenu
    function loadBarMenuStd() {
       
        var _post = $.param({ action: "loadBarMenuStd"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divBarMenu").html(data);
                $('.btnLogout').click(function () {
                    window.open('', '_self', '');
                    window.close();
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 28 ส.ค. 2560
    // Perpose: แสดงเมนู Side bar
    // Method : loadSidebarMenuStd
    function loadSidebarMenuStd() {
        var _post = $.param({ action: "loadSidebarMenuStd"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divSideBarMenu").html(data);
             
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    function getListLoadContactUs() {

        $.ajax({
            type: "POST",
            url: "../staff/actContactUs.aspx",
            success: function (data) {
                $(".divStdMain").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

</script>