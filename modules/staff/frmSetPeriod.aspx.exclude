<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSetPeriod.aspx.cs" Inherits="modules_staff_frmSetPeriod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Evaluation - กำหนดเวลาเปิดปิด</title>
</head>
<body>
    <div runat="server" id="divBanner" class="container-fulid"></div>
    <div class="container-fulid site-content">
        <div class="side-menu-panel" id="sideMenu" runat="server"></div>
        <div class="side-content-panel">
            <div id="divBreadcrumb" runat="server"></div>
            <div id="divNavbar" runat="server"></div>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="divContent">
                    <div class="container-fulid">
                        <div class="row">
                            <select style="display: none;" class="ddlSubjectPicker form-control" multiple="multiple" title="กรุณาเลือกรายวิชา" data-selected-text-format="count > 3"></select>
                        </div>
                        <div class="row" style="margin-top: 1em;">
                            <div class="col-sm-4" style="padding-left: 0px;">
                                <lable>วันที่เปิด</lable>
                                <div class='input-group date datetimepicker'>
                                    <input type='text' class="form-control startdatepicker" />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar datepickerbutton"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <lable>วันที่ปิด</lable>
                                <div class='input-group date datetimepicker'>
                                    <input type='text' class="form-control enddatepicker" />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar datepickerbutton"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding-right: 0px;">
                                <div>&nbsp;</div>
                                <div style="position: absolute; right: 0;">
                                    <button class="btn btn-success btnSave">บันทึก</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="container-fulid divContent"></div>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" id="divFooter" class="container-fulid"></div>
</body>
</html>
<script type="text/javascript">
    $(function () {
        var _frmId = '<%=Request["formid"] %>';

        Page.Preload.Show();

        $('.datetimepicker').datetimepicker();

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

                Page.Preload.Hide();
            });

        $(".ddlSubjectPicker").on("hidden.bs.select", function (e) {
            var subjects = $(".ddlSubjectPicker").selectpicker("val");

            Page.Preload.Show();

            $.post("../datas/EvaluateHandler.ashx",
                {
                    action: "GetListSubjectEvaluateWithCondition",
                    subjectid: subjects
                },
                function (response) {
                    $(".divContent").html(response);

                    $(".divContent").find(".divSubject").each(function (key, obj) {
                        $(obj).find(".divEvaluates").load(
                            "../datas/SubjectHandler.ashx",
                            {
                                action: "GetSubjectEvaluation",
                                subjectid: $(obj).data("subjectid")
                            },
                            function () {
                                // สร้าง tree view
                                // อ้างอิงเอกสาร https://www.jstree.com/
                                $(obj).find(".divEvaluates").jstree({
                                    "plugins": ["checkbox", "types"]
                                });
                            });
                    });

                    Page.Preload.Hide();
                });
        });

        $(".btnSave").on("click", function () {
            var conditionArr = new Array();

            Page.Preload.Show();

            $(".divSubject").each(function (key, subject) {
                $($(subject).find(".divEvaluates").jstree().get_bottom_selected(true)).each(function (k, condition) {
                    conditionArr.push(condition.data);
                });
            });

            $.post("../datas/EvaluateHandler.ashx",
                {
                    action: "SaveConditionPeriod",
                    startdate: $(".startdatepicker").val(),
                    enddate: $(".enddatepicker").val(),
                    conditionsid: JSON.stringify(conditionArr)
                },
                function (response) {
                    Page.Preload.Hide();
                    Page.Toast({ message: response.Message, onclose: function () { window.location.reload(); } });
                });
        });
    });
</script>
