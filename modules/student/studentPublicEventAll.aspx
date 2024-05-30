<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentPublicEventAll.aspx.cs" Inherits="modules_student_studentPublicEventAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <link href="../../scripts/simple-sidebar.css" rel="stylesheet" />
    <script src="../../scripts/jquery.min.js"></script>--%>


</head>
<body>
    <form id="form1" runat="server">

       <button type="button" class="btn btn-lg btn-danger" data-toggle="popover" title="Popover title" data-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button>

        <div id="wrapper" class="text-left">

        <div id="sidebar-wrapper" style="background-color:rgb(1, 53, 173);">
            <ul class="sidebar-nav">
                <li class="sidebar-brand" >
                        <a href="#" style="color:whitesmoke;">Activity Menu</a>
                </li>
      
                    <div class="input-group" >
                      <input type="text" class="form-control txtProjectName" placeholder="ค้นหาจากชื่อกิจกรรม"/>
                      <div class="input-group-btn" >
                         <button type="button" class="btn btn-default btnFillterProjectByName" >Search</button>
                      </div>
                    </div>
             
                <li>
                    <a href="#" class="h4" style="color:whitesmoke;">ประเภทกิจกรรม</a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByType" type="checkbox" value="1" >
                              <label class="form-check-label" style="color:whitesmoke;">กำหนดให้เข้าร่วม</label> 
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByType" type="checkbox" value="2"  >
                              <label class="form-check-label" style="color:whitesmoke;">เลือกเลือกเข้าร่วม</label>
                            </div>
                    </a>
                </li>
                <li>
                    <a href="#" class="h4" style="color:whitesmoke;">กิจกรรมที่ได้ Indicator</a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-005">
                              <label class="form-check-label" style="color:whitesmoke;">M - Mastery</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-006">
                              <label class="form-check-label" style="color:whitesmoke;">A - Altruism</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-007">
                              <label class="form-check-label" style="color:whitesmoke;">H - Harmony</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-008">
                              <label class="form-check-label" style="color:whitesmoke;">I - Integrity</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-009">
                              <label class="form-check-label" style="color:whitesmoke;">D - Determination</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-010">
                              <label class="form-check-label" style="color:whitesmoke;">O - Originalty</label>
                            </div>
                    </a>
                    <a href="#">
                           <div class="form-check form-check-inline">
                              <input class="form-check-input btnFillterProjectByIndicator" type="checkbox" value="IDC-011">
                              <label class="form-check-label" style="color:whitesmoke;">L - Leadership</label>
                            </div>
                    </a>
                </li>

            </ul>
        </div>
 
        <div id="page-content-wrapper">  
            
            <div class="container-fluid">
                <a href="#menu-toggle" class="btn btn-default" id="menu-toggle">Toggle Menu</a>
                <h1>Activity Mahidol</h1>
                <ul class="list-group">
                  <li class="list-group-item list-group-item-warning">Fillter By : <span class="spnFillterDisplay"><b>-</b></span></li>
                </ul>

                        <p>
                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018 - 05 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-success'>M 3 Hr.</span> <span class='label label-warning'>A 1 Hr.</span>
                                               <span class='label label-info'>H 3 Hr.</span> <span class='label ' style="background-color:darkcyan">I 1 Hr.</span> 
                                               <span class='label label-success' style="background-color:darkviolet">D 3 Hr.</span> <span class='label ' style="background-color:chocolate">O 1 Hr.</span> <span class='label ' style="background-color:gold">L 1 Hr.</span> 
                                            </p>
                                            <p>Blah Blah Blah ...</p>
                                            
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                               <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                                
                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                                
                                <div class="col-sm-6 col-md-3">
                                    <div class="thumbnail">
                                        <img src="../../images/event4.jpg" />
                                        <div class="caption">
                                                <h4><b>กิจกรรมปลูกป่า</b>
                                                <span class='label label-default'>04 Nov 2018</span>
                                                </h4>
                                            <p><span class='label label-danger'>ยังไม่กำหนด Indicator</span></p>
                                            <p>Blah Blah Blah ...</p>
                                            <p><a href="#" class="btn btn-primary" role="button">Join us</a> <a href="#" class="btn btn-default" role="button">Detail</a></p>
                                            
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </p>
              
            </div>
        </div>
   

    </div>
    </form>
</body>
</html>

<script>

    $("#wrapper").toggleClass("toggled");
    $("#menu-toggle").click(function(e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });
    $(".btnFillterProjectByName").click(function (e) {
        var _projectName = $(".txtProjectName").val()
        if (_projectName == "") {
            _projectName = "-";
        }
        fillterProject(_projectName,_projectName,"ชื่อกิจกรรม");
    });
    $(".btnFillterProjectByType").click(function (e) {
        var _fillterValue = "";
        var _fillterDiaplay = "";
        $('.btnFillterProjectByType:checked').each(function () {
            if (this.value == "1") {
                _fillterValue += "PJT-001,PJT-003";
                _fillterDiaplay += "กำหนดให้เข้าร่วม";
            }
            else if(this.value == "2"){
                _fillterValue += "PJT-002,PJT-004,PJT-005";
                _fillterDiaplay += "เลือกเลือกเข้าร่วม";
            }
            else {
                _fillterValue = "";
                _fillterDiaplay = "";
            }
            _fillterValue += ",";
            _fillterDiaplay += ",";
        });
        _fillterDiaplay =_fillterDiaplay.substring(0, _fillterDiaplay.length - 1);
        fillterProject(_fillterValue,_fillterDiaplay,"ประเภทกิจกรรม");
        //alert($(this).val());
    });

    $(".btnFillterProjectByIndicator").click(function (e) {

        var _fillterValue = "";
        var _fillterDiaplay = "";
        $('.btnFillterProjectByIndicator:checked').each(function () {
            _fillterValue += _fillterValue;
            _fillterDiaplay += _fillterDiaplay;
            //_fillterValue += ",";
            //_fillterDiaplay += ",";

        });
        fillterProject(_fillterValue,_fillterDiaplay,"กิจกรรมที่ได้ Indicator");
        // alert($(this).val());
    });


    // Auther : เจตน์ เครือชะเอม
    // Date   : 29 พ.ย. 2561
    // Perpose:
    // Method : 
    function fillterProject(_fillterValue , _fillterDisplay , _fillterType) {

        $(".spnFillterDisplay").html("[ "+_fillterType+" : " + _fillterDisplay+" ]");

        //var _post = $.param({ action: "getListMainFeedContent", menuVal:_menuVal
        //});
        //$.ajax({
        //    type: "POST",
        //    url: "actStdHandler.ashx",
        //    data: _post,
        //    success: function (data) {
        //        $("#divMainFeedContent").html(data);
        //        loadSliderReady();
        //    },
        //    error: function (data) {
        //        alert(jQuery.error);
        //    }
        //});
    }

</script>

