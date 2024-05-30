<%@ Page Language="C#" AutoEventWireup="true" CodeFile="actApproveProject.aspx.cs" Inherits="modules_staff_actApproveProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        @media screen and (min-width: 1000px) {
            #divPopupApprove .modal-dialog {
                width: 1000px
            }
             #divInputSentMail .modal-dialog  {
                 width:800px;

             }
             
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h2 class='page-header'>อนุมัติโครงการใหม่</h2>

     <div class='divFillterProjectApprove'>

     </div>

     <div class='divProjectApproveList'>
                
                

     
     </div>

   



    </div>

    <div id="divPopupApprove"  class='modal fade ' role='dialog'>
    </div>

    <div id="divInputSentMail"  class='modal fade ' role='dialog'>
    </div>

    </form>
</body>
</html>

<script type="text/javascript">

    LoadFillterProjectForApprove();
  
    // Auther : เจตน์ เครือชะเอม
    // Date   : 22 มิ.ย. 2560
    // Perpose: แสดงหน้าจอ Fillter สำหรับ List โครงการ
    // Method : LoadFillterProjectForApprove
    function LoadFillterProjectForApprove() {

        var _post = $.param({ action: "LoadFillterProjectForApprove"
        });
        $.ajax({
            type: "POST",
            data: _post,
            url: "actApproveHandler.ashx",
            success: function (data) {
                $(".divFillterProjectApprove").html(data);
                getListProjectForApprove();
                $('.btnSearchProjectApprove').click(function () {
                    getListProjectForApprove();

                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 22 มิ.ย. 2560
    // Perpose: แสดงหน้าข้อมูลรายการโครงการตามเงื่อนไข
    // Method : getListProjectForApprove
    function getListProjectForApprove() {
        var _acaYear = $(".divFillterProjectApprove").find(".ddlAcaYear").val();
        var _semester = $(".divFillterProjectApprove").find(".ddlSemester").val();
        var _ddlFaculty = $(".divFillterProjectApprove").find(".ddlFaculty").val();
        var _ddlProjectStatus = $(".divFillterProjectApprove").find(".ddlProjectStatus").val();
        var _post = $.param({ action: "getListProjectForApprove", acaYear: _acaYear
                            , semester: _semester, facultyId: _ddlFaculty
                            , projectStatusId: _ddlProjectStatus
        });
        Page.Preload.Show();
        $.ajax({
            type: "POST",
            url: "actApproveHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divProjectApproveList").html(data);
                $(document).ready(function () {
                    $('#tblListActForApproveByAdmin').DataTable();
                });

                //$('.btnLoadDetailProject').click(function () {
                //    _projectId = $(this).data('projectid');
                //    getListProjectDetailForView(_projectId, "0");
                //});
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }



    function getListProjectDetailForView(_projectid, _index) {
        //alert(_projectid);
        //alert(_index);
        
        Page.Preload.Show();
        var _post = $.param({ action: "getListProjectDetail", projectId: _projectid , statusEdit:"N"
        });

        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx",
            data: _post,
            //beforeSend: function () { loading(); },
            success: function (data) {
                //$(".divGetListProject").html(_html);
                Page.Preload.Hide();
                $('#divPopupApprove').html(data);
                $('#divPopupApprove').modal('show'); 
                

                $(".selectpicker").selectpicker();
                getDataClassTodisplaySelectPicker(_projectid);
                getDataFacultyTodisplaySelectPicker(_projectid);


                $('.nav-tabs li:eq(' + _index + ') a').tab('show');
                $('.datetimepicker').datetimepicker();
                $('.datetimepicker').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm:ss'
                });



            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }




    // Auther : เจตน์ เครือชะเอม
    // Date   : 22 มิ.ย. 2560
    // Perpose: แสดงหน้าข้อมูลรายการโครงการตามเงื่อนไข
    // Method : setApproveProject
     function setApproveProject(_projectid) {
         if (confirm("ยืนยันการอนุมัติโครงการ")) {
             var _post = $.param({ action: "setApproveProject", projectid: _projectid
             });
             $.ajax({
                 type: "POST",
                 url: "actApproveHandler.ashx",
                 data: _post,
                 success: function (data) {
                     alert(data);
                     LoadFillterProjectForApprove();
                 },
                 error: function (data) {
                     alert(jQuery.error);
                 }
             });
         }
    }

    function modalSendMailForApproveProject(_projectid) {
        //alert(_projectid);
        Page.Preload.Show();
        var _post = $.param({
            action: "getListDetailForSendmail", projectId: _projectid
        });

        $.ajax({
            type: "POST",
            url: "actApproveHandler.ashx",
            data: _post,
            //beforeSend: function () { loading(); },
            success: function (data) {
                //$(".divGetListProject").html(_html);
                Page.Preload.Hide();
                $('#divPopupApprove').html(data);
                // $('#divPopupApprove').modal('show');
                $('#divPopupApprove').modal('toggle');
                $('.btnSetSendMail').click(function () {
                    SendMailProjectCreator(_projectid);
                });
                $('.btnCloseDiv').click(function () {
                    $('#divPopupApprove').modal('toggle');
                });
                
                //$(".selectpicker").selectpicker();
                //getDataClassTodisplaySelectPicker(_projectid);
                //getDataFacultyTodisplaySelectPicker(_projectid);


                //$('.nav-tabs li:eq(' + _index + ') a').tab('show');
                //$('.datetimepicker').datetimepicker();
                //$('.datetimepicker').datetimepicker({
                //    format: 'DD/MM/YYYY HH:mm:ss'
                //});



            },
            error: function (data) {
                alert(jQuery.error);
            }
        });



    }

    function SendMailProjectCreator(projectid) {
        var txtAcaYear = $("#divPopupApprove").find("#txtAcaYear").val();
        var txtProjectNameTh = $("#divPopupApprove").find("#txtProjectNameTh").val();
        var txtInstituteNameTh = $("#divPopupApprove").find("#txtInstituteNameTh").val();
        var txtCreateDateTh = $("#divPopupApprove").find("#txtCreateDateTh").val();
        var txtCreatedBy = $("#divPopupApprove").find("#txtCreatedBy").val();
        var txtRemark = $("#divPopupApprove").find("#txtRemark").val();
        if (txtRemark == "") {
            alert("กรุณากรอกข้อมูลหมายเหตุ");
            $("#divPopupApprove").find("#txtRemark").focus();
            return;
        }
        //alert(txtAcaYear);
        //alert(txtProjectNameTh);
        //alert(txtInstituteNameTh);
        //alert(txtCreateDateTh);
        //alert(txtCreatedBy);
        //alert(txtRemark);
        if (confirm("ยืนยันการส่งเมล์?")) {
            Page.Preload.Show();
            var _post = $.param({
                action: "SendMailProjectCreator"
                , txtAcaYear: txtAcaYear
                , txtProjectNameTh: txtProjectNameTh
                , txtInstituteNameTh: txtInstituteNameTh
                , txtCreateDateTh: txtCreateDateTh
                , txtCreatedBy: txtCreatedBy
                , txtRemark: txtRemark
                , projectid: projectid
            });

            $.ajax({
                type: "POST",
                url: "actApproveHandler.ashx",
                data: _post,
                //beforeSend: function () { loading(); },
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    $('#divPopupApprove').modal('toggle');
                    LoadFillterProjectForApprove();
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }

</script>
