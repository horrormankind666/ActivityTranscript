<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPublishForm.aspx.cs" Inherits="modules_staff_frmPublishForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Evaluation - เผยแผ่แบบประเมิน</title>
</head>
<body>
    <div id="divBanner" runat="server"></div>
    <div class="container-fulid site-content">
        <div class="side-menu-panel" id="divSideMenu" runat="server"></div>
        <div class="side-content-panel">
            <div id="divBreadcrumb" runat="server"></div>
            <div id="divNavbar" runat="server"></div>
            <div class="tab-content">
                <div style="margin-top: 1em;">
                    <div>
                        <a href='<%="frmEvaluation.aspx?year=" + Request.Params["year"] + "&semester=" + Request.Params["semester"] %>' class="btn btn-danger" style="border-radius: 0 20px 20px 0;">
                            <i class="glyphicon glyphicon-chevron-left"></i>
                            ย้อนกลับ
                        </a>
                    </div>
                    <div style="margin-left: 5em;">
                        <h3>เผยแผ่แบบประเมิน - <%=Request["formid"] %></h3>
                    </div>
                </div>
                <div class="container-fluid">
                    <div class="row">
                        <select style="display: none;" class="ddlSubjectPicker form-control" multiple="multiple" title="กรุณาเลือกรายวิชา" data-selected-text-format="count > 3"></select>
                    </div>
                    <div class="container-fluid divConditionGroup" style="border: solid rgb(224, 224, 224); border-radius: 10px; margin-top: 1em;"></div>
                </div>
            </div>
        </div>
    </div>
    <div id="divFooter" runat="server"></div>
</body>
</html>
<script>
    $(function () {
        var _frmId = '<%=Request["formid"] %>';

        Page.Preload.Show();

        $.post("../datas/SubjectHandler.ashx",
            {
                action: "GetSubjectAsDropDownListItem",
                formid: _frmId
            },
            function (response) {
                $(".ddlSubjectPicker").append(response);
                $(".ddlSubjectPicker").selectpicker({
                    liveSearch: true,
                    showSubtext: true
                });
                <%//$(".ddlSubjectPicker").change();%>
                $(".divConditionGroup").append("<h3 class='text-center'>กรุณาเลือกรายวิชา</h3>");
                $(".ddlSubjectPicker").trigger("hidden.bs.select");
                Page.Preload.Hide();
            });
        $(".ddlSubjectPicker").on('hidden.bs.select', function () {
            Page.Preload.Show();
            var subjects = $(this).val();

            $.post("../datas/EvaluateHandler.ashx",
                {
                    action: "GetListSubject",
                    subjectid: subjects,
                    formid: _frmId
                },
                function (response) {
                    var divSubjectSelector = new Array();

                    if ($(response).is("h3"))
                        $(".divConditionGroup").html(response);
                    else {
                        $(response).each(function (key, obj) {
                            var subjectId = $(obj).data("subjectid");

                            // นำ element h3 ออกก่อนนำ divSubject มาต่อท้าย
                            $(".divConditionGroup").find("h3:not(.panel-title)").remove();

                            divSubjectSelector.push(".divSubject[data-subjectid='" + subjectId + "']");

                            if (!$(".divConditionGroup").find(".divSubject[data-subjectid='" + subjectId + "']").is("div")) {
                                $(".divConditionGroup").append($(obj));
                                $(obj).SetCreatePanelEvent();
                            }
                        });
                    }

                    $(".divSubject").not(divSubjectSelector.join(",")).remove();

                    Page.Preload.Hide();
                });
        });
        $.fn.SetCreatePanelEvent = function () {
            <%// เพิ่มเงื่อนไขระบุกลุ่มผู้ใช้งานแบบสอบถาม%>
            $(this).find(".btnAddCondition").click(function () {
                var divSubject = $(this).parents(".divSubject");
                var subjectId = divSubject.data("subjectid");

                Page.Preload.Show();

                $.post(
                    "../datas/EvaluateHandler.ashx",
                    {
                        action: "RenderCreateConditionPanel",
                        subjectid: subjectId,
                        formid: _frmId
                    },
                    function (response) {
                        var divCreateCodition = $(response);

                        <%//สร้างกล่อง select box ในรูปแบบ selectpicker%>
                        <%//อ้างอิง : https://silviomoreto.github.io/bootstrap-select/%>
                        divCreateCodition.find(".ddlSelectPicker").selectpicker({ showSubtext: true });

                        <%// กำหนดพฤติกรรมปุ่มลบเงือนไข%>
                        divCreateCodition.find(".btnRemove").click(function () {
                            $(this).parents(".divCondition").remove();
                        });

                        <%// กำหนดพฤติกรรมปุ่มบันทึกเงื่อนไข%>
                        divCreateCodition.find(".btnSave").click(function () {
                            var casesObject = renderConditionObject();

                            if (!checkFormValid()) {
                                return;
                            }
                            Page.Preload.Show();
                            $.post("../datas/SubjectHandler.ashx",
                                {
                                    action: "SetSubjectCondition",
                                    formid: _frmId,
                                    subjectid: subjectId,
                                    name: divCreateCodition.find(".txtConditionName").val(),
                                    cases: JSON.stringify(casesObject),
                                    instructor: divCreateCodition.find(".ddlInstructors").is("select") ? divCreateCodition.find(".ddlInstructors:not(div)").val().join(",") : null
                                },
                                function (response) {
                                    Page.Preload.Hide();
                                    window.location.reload();
                                })
                            .fail(function (message) {
                                Page.Preload.Hide();
                            });

                            function renderConditionObject() {
                                var casesObject = new Array();

                                if ($(".checkAll").is(":checked"))
                                    return casesObject;

                                divCreateCodition.find(".chkActiveCase:checked").each(function (key, obj) {
                                    var divCase = $(obj).parents(".divCase");
                                    casesObject.push({
                                        "parameter": $(obj).data("parameter"),
                                        "value": typeof (divCase.find(".caseValue:not(div)").val()) === "object" ?
                                            divCase.find(".caseValue:not(div)").val().join(",") :
                                            divCase.find(".caseValue:not(div)").val()
                                    });
                                });

                                return casesObject;
                            }

                            function checkFormValid() {
                                if (!divCreateCodition.find("[type='checkbox']:checked").is("input")) {
                                    Page.Toast("กรุณาระบุเงื่อนไขก่อนทำการบันทึก");
                                    return false;
                                } else if (divCreateCodition.find(".txtConditionName").val() == "") {
                                    Page.Toast("กรุณาระบุชื่อเงื่อนไขก่อนทำการบันทึก");
                                    divCreateCodition.find(".txtConditionName").focus();
                                    return false;
                                } else if ($(".ddlInstructors").selectpicker("val") == null) {
                                    Page.Toast("กรุณาระบุอาจารย์ที่จะทำการประเมิน");
                                    divCreateCodition.find(".txtConditionName").focus();
                                    return false;
                                } else
                                    return true;

                            }
                        });

                        divSubject.find(".divSubjectConditions").prepend(divCreateCodition);

                        Page.Preload.Hide();
                    }
                    );
            });

            <%// %>
            
            <%// เอารายวิชาออก%>
            $(this).find(".btnRemoveSubject").click(function () {
                var divSubject = $(this).parents(".divSubject");
                var subjectId = divSubject.data("subjectid");
                var selectedItem = new Array();

                divSubject.remove();

                if ($(".divConditionGroup").find(".divSubject").length === 0)
                    $(".divConditionGroup").append("<h3 class='text-center'>กรุณาเลือกรายวิชา</h3>");


                $(".ddlSubjectPicker option[value='" + subjectId + "']").prop("selected", false);

                $(".ddlSubjectPicker option:selected").each(function (key, obj) {
                    selectedItem.push(obj.value);
                });

                $(".ddlSubjectPicker").selectpicker("val", selectedItem);
                $(".ddlSubjectPicker").selectpicker("refresh");
            });
        };
    });
</script>
