<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="modules_staff_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<%--<script src="../../scripts/heightchart/highcharts.js" type="text/javascript"></script>
<script src="../../scripts/heightchart/highcharts-more.js" type="text/javascript"></script>
<script src="../../scripts/heightchart/modules/exporting.js" type="text/javascript"></script>
<script src="../../scripts/heightchart/modules/export-data.js" type="text/javascript"></script>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



</head>
<body>
    <form id="form1" runat="server">
        </br></br>
        ประเภทของเครื่องมือ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <select id="Select1">
            <option>แบบสอบถาม (Questionnaire)</option>
            <option>แบบสัมภาษณ์</option>
            <option>แนวทางการสัมภาษณ์หรือสังเกต</option>
            <option>แบบบันทึกข้อมูลสำหรับการวิจัย (Case record form/ Case report form)</option>
            <option>อื่นๆ </option>
        </select>
        </br>
        </br>
        <table>
            <tr>
                <td width="700px;">       อัพโหลดไฟล์ประเภทของเครื่องมือ</td>    
            <td><input id="File1" type="file" /></td>
                </tr>
        </table>



<div id="divMain">
</div>

    </form>
</body>
</html>

<script type="text/javascript">
    // testApi();

    function testApi() {
        alert();
        var _item = new Array();
        _item.push({ studentCode: "5901002", hours: "1", acaYear:"2563", semester:"2", serviceName:"TrashBottleApi" },
                   { studentCode: "5901003", hours: "2", acaYear:"2563", semester:"2", serviceName:"TrashBottleApi" });
        //var things = [
        //    { studentCode: "2", hours: 2, acaYear: "2563", semester: 2, serviceName: "TrashBottleApi" }
        //];
        //Page.Preload.Show();
        var _post = $.param({
            action: "getApiCollectATHours",
            itemList: JSON.stringify(_item)
        });
        $.ajax({
            type: "POST",
            url: "actProjectHandler.ashx" ,
            data: _post ,
            success: function (data) {
               // Page.Preload.Hide();
                alert(JSON.stringify(data));
                $("#divMain").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }


    
</script>