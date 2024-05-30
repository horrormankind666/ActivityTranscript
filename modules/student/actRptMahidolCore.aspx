<%@ Page Language="C#" AutoEventWireup="true" CodeFile="actRptMahidolCore.aspx.cs" Inherits="modules_student_actRptMahidolCore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div style='width:80%;' class='container-fluid divMain' >
   
        <div id="divProfileStudent" ></div>

        <div id="container" style="min-width: 400px; max-width: 600px; height: 400px; margin: 0 auto"></div>

        <div id='divDefinitionCoreValue'></div>

     </div>
    </form>
</body>
</html>


<script type="text/javascript">


    //getListReportCoreValue();
    //getListReportTQF();
    getListReportCenturySkill();


    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListReportCenturySkill
    function getListReportCenturySkill() {
        getListHeaderCenturySkill();
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderCenturySkill
    function getListHeaderCenturySkill() {
        var _post = $.param({ action: "getListHeaderShortProfile", studentCode: "5915001", stsShowSummaryAct: "0", txtDisplayHeader: "21st Century Skill Outcomes"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divProfileStudent").html(data);
                getCharacterSummary("GCR-002");
                getListDefinitionCenturySkill();
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2561
    // Perpose: 
    // Method : getListDefinitionCenturySkill
    function getListDefinitionCenturySkill() {
        var _post = $.param({ action: "getListDefinitionCenturySkill"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divDefinitionCoreValue").html(data);
            }
        });
    }



    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListReportTQF
    function getListReportTQF() {
        getListHeaderTQF();
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderTQF
    function getListHeaderTQF() {
        var _post = $.param({ action: "getListHeaderShortProfile", studentCode: "5915001", stsShowSummaryAct: "0", txtDisplayHeader: "TQF มาตรฐานการเรียนรู้ 5 ด้าน"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divProfileStudent").html(data);
                getCharacterSummary("GCR-001");
                getListDefinitionTQF();
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: แสดงรายงานมหิดลคอร์วารู
    // Method : getCharacterSummary
    function getCharacterSummary(_groupCharacterId) {

        var _post = $.param({ action: "getCharacterSummary", studentId: "STD255901150", groupCharacterId: _groupCharacterId, facultyId: "", programId: "", acaYear: ""
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: 'container',
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
    function getListDefinitionTQF() {
        var _post = $.param({ action: "getListDefinitionTQF"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divDefinitionCoreValue").html(data);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListReportCoreValue
    function getListReportCoreValue() {
        getListHeaderCoreValue();
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 7 พ.ค. 2561
    // Perpose: 
    // Method : getListDefinitionCoreValue
    function getListDefinitionCoreValue() {
        var _post = $.param({ action: "getListDefinitionCoreValue", studentCode: "5915001"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divDefinitionCoreValue").html(data);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: 
    // Method : getListHeaderCoreValue
    function getListHeaderCoreValue() {
        var _post = $.param({ action: "getListHeaderShortProfile", studentCode: "5915001", stsShowSummaryAct: "1", txtDisplayHeader: "Mahidol Core values"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divProfileStudent").html(data);
                getlistRptMahidolCoreValue();
                getListDefinitionCoreValue();
            }
        });
    }
    

    // Auther : เจตน์ เครือชะเอม
    // Date   : 2 พ.ค. 2561
    // Perpose: แสดงรายงานมหิดลคอร์วารู
    // Method : getlistRptMahidolCoreValue
    function getlistRptMahidolCoreValue() {

        var _post = $.param({ action: "getlistRptMahidolCoreValue", studentId: "STD255901413", facultyId: "", programId: "",acaYear:""
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (jSonData) {
                // var obj = JSON.parse(jSonData);
                var obj = jQuery.parseJSON(jSonData);
                $(document).ready(function () {
                    var options = {
                        chart: {
                            renderTo: 'container',
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
               


</script>

