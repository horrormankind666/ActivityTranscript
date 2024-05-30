<%@ Page Language="C#" AutoEventWireup="true" CodeFile="actShoppingMain.aspx.cs" Inherits="modules_student_actShoppingMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    getListProjectActive();


    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 ก.ค. 2560
    // Perpose: List รายการข้อมูลโครงการทั้งหมดที่สถานะเป็นเปิดให้นักศึกษามา Shopping
    // Method : getListProjectActive
    function getListProjectActive() {

        var _post = $.param({ action: "getListProjectActive"
        });

        $.ajax({
            type: "POST",
            url: "actShoppingHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divStdMain").html(data);
                $(".divStdMain").find(".btnProjectDetail").click(function () {
                    _projectid = $(this).data('projectid');
                    getListProjectDetail(_projectid);
                });
                $(".divSideBarMenu").find(".btnLoadContractUs").click(function () {
                    getListLoadContactUs();
                });
                $(".divSideBarMenu").find(".btnLoadProjectList").click(function () {
                    getListProjectActive();
                });
                $(document).ready(function() {
                    $('#tblProjectList').DataTable();
                });

            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 ก.ค. 2560
    // Perpose: List รายการข้อมูลโครงการทั้งหมดที่สถานะเป็นเปิดให้นักศึกษามา Shopping
    // Method : getListProjectActive
    function getListProjectDetail(_projectid) {

        var _post = $.param({ action: "getListProjectDetail", projectId: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actShoppingHandler.ashx",
            data: _post,
            success: function (data) {
                //alert(data);
                $(".divStdMain").html(data);
                $('.divStdMain').find('.btnBack').click(function () {
                    getListProjectActive();
                });
                $('.divStdMain').find('.btnSetJoinSection').click(function () {
                    alert("กำลังดำเนินการพัฒนาระบบ");
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 ก.ค. 2560
    // Perpose: แสดงเมนู Menu bar ของนักศึกษา
    // Method : loadBarMenu
    function loadBarMenuStd() {

        var _post = $.param({ action: "loadBarMenuStd"
        });

        $.ajax({
            type: "POST",
            url: "actShoppingHandler.ashx",
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
    // Date   : 5 ก.ค. 2560
    // Perpose: แสดงเมนู Side bar
    // Method : loadSidebarMenuStd
    function loadSidebarMenuStd() {
        var _post = $.param({ action: "loadSidebarMenuStd"
        });
        $.ajax({
            type: "POST",
            url: "actShoppingHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divSideBarMenu").html(data);



            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 5 ก.ค. 2560
    // Perpose: แสดงเมนูหน้าจอ ติดต่อเรา
    // Method : getListLoadContactUs
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
