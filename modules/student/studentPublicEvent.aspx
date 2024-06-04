<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentPublicEvent.aspx.cs" Inherits="modules_student_studentPublicEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
        @media screen and (min-width: 800px) {
	         #divPopup .modal-dialog  {width:1000px;}
        }

</style>

    <link href="../../scripts/simple-sidebar.css" rel="stylesheet" />
    <script type="text/javascript"  src="../../scripts/jssor.slider.min.js"></script>
  <%--  <link href="../../contents/CarouselCss.css" rel="stylesheet" />--%>
<%--    <script src="../../scripts/jquery.min.js"></script>--%>
    <title></title>
                        <style>
                        /* jssor slider loading skin spin css */
                        .jssorl-009-spin img {
                            animation-name: jssorl-009-spin;
                            animation-duration: 1.6s;
                            animation-iteration-count: infinite;
                            animation-timing-function: linear;
                        }

                        @keyframes jssorl-009-spin {
                            from {
                                transform: rotate(0deg);
                            }

                            to {
                                transform: rotate(360deg);
                            }
                        }
                        .style1 a {
                            color: ghostwhite;
                        }
                        .style1 a:hover,
                        .style1 a:focus {
                            color: darkgrey;
                        }
                        .navbar-custom a {
                            color:black;
                            font-size:16px;
                        }
                        .nav > li > a:hover,
                        .nav > li > a:focus {
                            color: chocolate;
                      
                        }

                        #divPosterATPoll .modal-dialog {
                            margin: 30px auto !important;
                        }
                        #divPosterATPoll .modal-dialog,
                        #divPosterATPoll .modal-body img {
                            width: 600px !important;
                        }

                        @media (max-width: 627px) {
                            #divPosterATPoll .modal-dialog {    
                                padding-left: 14px;
                                padding-right: 14px;
                            }
                            #divPosterATPoll .modal-dialog,
                            #divPosterATPoll .modal-body img {
                                width: 100% !important;
                            }
                        }
                    </style>
</head>
<body>

<div class="container-fluid">
  
   <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">

            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><span class='label label-primary' style='font-size: 20px;'>AT</span> MU ACTIVITY TRANSCRIPT</a>
            </div>

  
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><a href="#menu-toggle" id="menu-toggle"><span class="glyphicon glyphicon-align-justify"></span></a></li>
                    <li class="active"><a href="studentPublicEvent.aspx">Home <span class="sr-only">(current)</span></a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span class="th">ค้นหา</span><span class="en">Search</span> <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#" class="btnPanelSearch" data-panelsearchval="1"><span class="th">ค้นหาด้วยชื่อกิจกรรม</span><span class="en">Search by activity name</span></a></li>
                            <li><a href="#" class="btnPanelSearch" data-panelsearchval="2"><span class="th">ค้นหาตามช่วงเวลาการจัดกิจกรรม</span><span class="en">Search by activity duration</span></a></li>
                            <li><a href="#" class="btnPanelSearch" data-panelsearchval="3"><span class="th">ค้นหาตามสถานะของกิจกรรม</span><span class="en">Search by activity status</span></a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#" class="btnPanelSearch" data-panelsearchval="4"><span class="th">ค้นหาจำแนกตามหน่วยงาน</span><span class="en">Search by institute</span></a></li>
                            <li><a href="#" class="btnPanelSearch" data-panelsearchval="5"><span class="th">ค้นหาตามตัวชี้วัด</span><span class="en">Search by indicator</span></a></li>
                            
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span class="th">อื่นๆ</span><span class="en">Other</span> <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="https://apps.apple.com/th/app/we-mahidol/id1425003959?l=th" target="_blank">We Mahidol Application</a></li>
                            <li><a href="https://mahidol.ac.th/th/new-current-student/student-dormitory/" target="_blank"><span class="th">หอพักนักศึกษามหิดล</span><span class="en">Dormitory</span></a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#" class="btnLoadContractUs" target="_blank"><span class="th">ติดต่อเรา</span><span class="en">Contact us</span></a></li>
                        </ul>
                    </li>
    
                </ul>
           
                <ul class="nav navbar-nav">   
                    <div class="input-group">
                        <div class="row">
                            <div class="col-sm-10">
                                <span id="spnPanelSearchByActivity" class="hide">
                                    <input type="text" id="txtPublicEventName" runat="server" class="form-control" placeholder="Search for Activity Name" />
                                </span>  
                                <span id="spnPanelSearchByDuration" class="hide">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class='input-group date datetimepicker'>
                                                    <input type='text' class='form-control txtDateStart'  />
                                                    <span class='input-group-addon'>
                                                    <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                                    </span>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class='input-group date datetimepicker'>
                                                    <input type='text' class='form-control txtDateEnd'  />
                                                    <span class='input-group-addon'>
                                                    <span class='glyphicon glyphicon-calendar datepickerbutton'></span>
                                                    </span>
                                            </div>
                                        </div>
                                    </div>
                                </span> 
                                <span id="spnPanelSearchByProjectStatus" class="hide">
                                    <div class="divProjectStatus"></div>
                                </span>  
                                <span id="spnPanelSearchByFaculty" class="hide">
                                    <div class="divFacultyDDl" style="width:280px;" ></div>
                                </span>  
                                <span id="spnPanelSearchByGroupIndicator" class="hide">
                                    <table>
                                    <tr>
                                    <td>  <div class="divGroupIndicatorDDl" style="width:190px;" ></div> </td>
                                    <td>  <div class="divIndicatorDDl" style="width:170px;" ></div> </td>
                                    <td>  <div class="divSubIndicatorDDl" style="width:170px;" ></div> </td>
                                    </tr></table>
                                </span>
                            </div>
                            <div class="col-sm-2">
                                <span class="input-group-btn">
                                        <button class="btn btn-default glyphicon glyphicon-search" type="button" onclick="SearchPublicEvent();"></button>
                                </span>
                            </div>
                        </div>
<%--                            <div class="row">
                            <div class="col-sm-4">
                            <input type="text" id="txtPublicEventName" runat="server" class="form-control" placeholder="Search for Activity Name" />
                          
                            </div>
                            <div class="col-sm-3">
                                <div class="divProjectStatus"></div>
                             </div>

                              <div class="col-sm-3">
                                <div class="divFacultyDDl"></div>
                             </div>

                            <div class="col-sm-2">
                            <span class="input-group-btn">
                                <button class="btn btn-default glyphicon glyphicon-search" type="button" onclick="SearchPublicEvent();"></button>
                            </span>
                            </div>
                            </div>--%>

                    </div>
                </ul>

                

                <ul class="nav navbar-nav navbar-right">

                    <li>
                       
                        <div class="row" id='divProfile' runat="server">
                        </div>

                    </li>

                </ul>
            </div>
          
        </div>
      
    </nav>

   


    <div id="wrapper" class="text-left " style="padding-top:55px;"  >
    
        <div id="sidebar-wrapper"  style="background-color: #F9F9F9;color:Black;" >
            <div id="divSidebarWrapper" runat="server" ></div>
        </div>
     

    <div id="page-content-wrapper" >  
            <div id="divMainDisplay" runat="server">
                <div id="divMain" class="container" >
                    <%--<h1>กิจกรรมล่าสุด</h1>--%>
                          <%--  <div id='divActNewRelease'></div>--%>
                           <%-- <div class="carousel fade-carousel slide carousel-fade" data-ride="carousel" data-interval="3000" id="bs-carousel">
                                        <!-- Overlay -->
                                        <!-- Indicators -->
                                        <ol class="carousel-indicators">
                                            <li data-target="#bs-carousel" data-slide-to="0" class="active"></li>
                                            <li data-target="#bs-carousel" data-slide-to="1"></li>
                                            <li data-target="#bs-carousel" data-slide-to="2"></li>
                                        </ol>
                                        <!-- Wrapper for slides -->
                                        <div class="carousel-inner">
                                            <div class="item slides active carousel-item">
                                                <div class="slide-1" style="background-image: url(https://ununsplash.imgix.net/photo-1416339134316-0e91dc9ded92?q=75&fm=jpg&s=883a422e10fc4149893984019f63c818);" >
                                                    <div class="overlay" ></div>
                                                </div>
                                            </div>
                                            <div class="item slides carousel-item">
                                                <div class="slide-2">
                                                    <div class="overlay"></div>
                                                </div>
                                            </div>
                                            <div class="item slides carousel-item">
                                                <div class="slide-3">
                                                    <div class="overlay"></div>
                                                </div>
                                            </div>
                                            <div class="hero">
                                                <hgroup>
                                                     <h1>We Mahidol Apps Training</h1> 
                                                     <h3>เรียนรู้ Life Style ใหม่ของการใช้ Apps</h3>
                                                </hgroup>
                                                <button class="btn btn-hero btn-lg" role="button">See all detail</button>
                                            </div>
                                        </div>
                                    </div>--%>

                    <%--<h2 style="text-shadow: 1px 1px grey;">กิจกรรมที่เปิดรับสมัคร</h2>--%>

                    <div class="row" id="divBody"  >
                        <div  id="divSubFeedContent"  >
                         </div>
                    </div>
                </div>

                <div id="divDetailAll" >

                </div>
            </div>
     </div>
     </div>
</div>


<div tabindex="-1" class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" type="button" data-dismiss="modal">×</button>
                    <h3 class="modal-title"><span class="th">ภาพกิจกรรม</span><span class="en">gallery</span></h3>
                </div>

                <div class="modal-body" align="center">
                </div>

                <div class="modal-footer">
                    <button class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
</div>


<div id="divReLogin" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog modal-dialog-centered modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title"><span class="th">ลงทะเบียนเพื่อเข้าร่วมกิจกรรม</span><span class="en">Registration</span></h4>
      </div>
      <div class="modal-body divReLoginBody">
       
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<div id="divPosterATPoll" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color: transparent; border: 0;border-radius: 0;">
            <div class="modal-body divPosterATPollBody" style="padding: 0;">
                <a href='https://forms.gle/DZNVLYf3EZk4B8yj8/' target='_blank'>
                    <img alt='Responsive image' src='../../images/PosterATPoll.png' />
                </a>
            </div>
        </div>
    </div>
</div>




<input id="hddStudentCode" runat="server" type="hidden" />  
<input id="hddPanelSearchVal" type="hidden" />
<input id="hddIsTH" type="hidden" />
<input id="hddStatusPublicEvent" type="hidden" runat="server" />
    <div id="divPopup"  class='modal fade ' role='dialog'>
    </div>




   
</body>
</html>

<script>

  /*  $('#divPopupContent').modal({ show: true });*/

    // $('.btnRegister').click(function () {
    //    loadRegisterPage();
    // });




    $(document).ready(function () {
         initialOnload();
    });

    function initialOnload() {
       
        $("#hddIsTH").val("1");
        var _statusPublicEvent = $("#hddStatusPublicEvent").val();

        $('.datetimepicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });

        //getListActNewRelease();
        $('.btnPanelSearch').click(function () {
            var _panelsearchval = $(this).data("panelsearchval");
            scriptPanelSearch(_panelsearchval);
        });

        $(".btnGetListActivitiesByStudent").click(function () {
            getListActivitiesByStudent();
        });

        $(".btnGetListActivitiesOnline").click(function () {
            getListActivitiesOnline();
        });

        $(".btnGetListActSchorlarShipByStudent").click(function () {
            getListActivitySchorlarship();
        });

        $(".btnPrintActivityTranscript").click(function () {
            printActivityTranscript();
        });

        $(".btnRequestAT").click(function () {
            getRequestAT();
        });

        $(".btnLoadContractUs").click(function () {
            getListLoadContactUs();
        });
        

        //$(window).bind('resize', function() {
        //    $("#wrapper").toggleClass("toggled");
        //});
  
        $("#wrapper").toggleClass("toggled");
        $("#menu-toggle").click(function(e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });


        // getListMainFeedContent("");
        var _txtPublicEventName = $('#txtPublicEventName').val();
        var _ddlFaculty = $('.ddlFaculty').val();
        var _txtDateStart = $(".txtDateStart").val();
        var _txtDateEnd = $(".txtDateEnd").val();
        var _ddlProjectStatus = $('.ddlProjectStatus').val();
        var _ddlFacultyText = $(".ddlFaculty option:selected").text();
        var _ddlProjectStatusText = $(".ddlProjectStatus option:selected").text();
        var _ddlGroupIndicatorText = $(".ddlGroupIndicator option:selected").text();
        var _ddlGroupIndicator = $('.ddlGroupIndicator').val();
        var _ddlIndicator =$('.ddlIndicator').val();
        var _ddlSubIndicator =$('.ddlSubIndicator').val();
        // alert(_txtPublicEventName);
         getListSubFeedContent("", "#divSubFeedContent", _txtPublicEventName,_ddlFaculty,_txtDateStart,_txtDateEnd,_ddlProjectStatus,_statusPublicEvent,_ddlFacultyText , _ddlProjectStatusText,"",_ddlGroupIndicatorText,_ddlGroupIndicator,_ddlIndicator, _ddlSubIndicator);
        loadFacultyDDl();
        loadProjectStatusDll();
        loadGroupIndicatorDDl();
        getListDdlIndicator();
        getListDdlSubIndicator();

        $("li").click(function() {
            $("li").removeClass("active");
            $(this).addClass("active");
            //var _menuVal = $(this).data("menuval");
            //menuBarVal(_menuVal);
        });

        $('#divPosterATPoll').modal({ show: true });
    }

    function getRequestAT() {

        Page.Preload.Show();
        var _post = $.param({
            action: "getRequestAT"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divSubFeedContent").html("<div style='width:82%;' >" + data + "</div>");
                $(".selectpicker").selectpicker();
                $(".ddlRequestReason").on("change", function () {
                    var _ddlRequestReason = $(".ddlRequestReason").selectpicker("val");
                    // txtOtherReason
                    //alert(_ddlRequestReason);
                    if (_ddlRequestReason.indexOf("7") != "-1") {
                        $('#txtOtherReason').removeAttr("disabled");
                    }
                    else {
                        //$('#txtOtherReason').attr('disabled');
                        $('#txtOtherReason').prop("disabled", true);
                    }
                });

                // ดึงค่าเข้า SelectPicker
                getListRequestReasonToSelectPicker();


                $(".btnSetRequestAT").click(function () {
                        setRequestAT();
                });
                $(".btnSetCancelRequestAT").click(function () {
                    if (confirm("ยืนยันการยกเลิกยื่นคำร้องขอใบ AT")) {
                        var _requestDocId = $(this).data("requestdocid");
                        setCancelRequestAT(_requestDocId);
                    }
                });
                $(".btnWanringNotPass").click(function () {
                    alert("นักศึกษาไม่ผ่านเกณฑ์ AT ไม่สามารถขอใบ Transcript กิจกรรมได้");
                });
                

                chkIsLangTh($("#hddIsTH").val());
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function setCancelRequestAT(_requestDocId) {

        Page.Preload.Show();
        var _post = $.param({
            action: "setCancelRequestDoc", _requestDocId: _requestDocId
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                alert(data);
                getRequestAT();
                chkIsLangTh($("#hddIsTH").val());
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    function setRequestAT() {

        
        var _ddlRequestReason = $(".ddlRequestReason").selectpicker("val");
        var _txtOtherReason = $("#txtOtherReason").val();
        // alert(_ddlRequestReason);
        if (_ddlRequestReason == null) {
            alert("กรุณาระบุเหตุผลการ Requert ใบ AT");
            return;
        }
        if ((_ddlRequestReason.indexOf("7") != "-1") && (_txtOtherReason=="")) {
            alert("กรุณาระบุเหตุผลอื่นๆ");
            $("#txtOtherReason").focus();
            return;
        }
        
        if (confirm("ยืนยันการยื่นคำร้องขอใบ AT")) {
            Page.Preload.Show();
            var _post = $.param({
                action: "setRequestAT"
                , _txtOtherReason: _txtOtherReason
                , _ddlRequestReason: escape(_ddlRequestReason)
                    
            });
            $.ajax({
                type: "POST",
                url: "actStdHandler.ashx",
                data: _post,
                success: function (data) {
                    Page.Preload.Hide();
                    alert(data);
                    getRequestAT();
                    chkIsLangTh($("#hddIsTH").val());
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }


    function printActivityTranscript() {
        var _item = new Array();
        var _studentCode = $("#hddStudentCode").val();
        var _isLanguageTh = $("#hddIsTH").val();
        _item.push({ studentCode: _studentCode });
        // alert(_isLanguageTh);
        if (_isLanguageTh == "1") {
            post_to_url("actAtTranscript.aspx", { itemList: JSON.stringify(_item), submit: "submit" });
        }
        else {
            post_to_url("actAtTranscriptEng.aspx", { itemList: JSON.stringify(_item), submit: "submit" });
        }
        
    }

    function post_to_url(path, params, method) {
        method = method || "post";

        var form = document.createElement("form");


        form._submit_function_ = form.submit;
        form.setAttribute("method", method);
        form.setAttribute("action", path);

        for (var key in params) {
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("type", "hidden");
            hiddenField.setAttribute("name", key);
            hiddenField.setAttribute("value", params[key]);
            form.appendChild(hiddenField);
        }

        document.body.appendChild(form);
        form._submit_function_(); //Call the renamed function.
    }

    function getListActivitiesOnline() {
        
        Page.Preload.Show();
        var _post = $.param({ action: "getListActivitiesOnline"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $("#divSubFeedContent").html(data);
                chkIsLangTh($("#hddIsTH").val());
                $('.btnLoadDetailProjectPublic').click(function () {
                    var _projectId = $(this).data("projectid");
                    loadDetailProjectPublic(_projectId, "","","","","")
                    //alert(_projectId);
                    //alert(_publicEventName);
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }
    

    //$(".btnActiveMenuBar").click(function () {
    //    alert($(this).data("menuval"));
    //    $(this).addClass("active");

    //    $(".btnActiveMenuBar").removeClass(function() {
    //      return $(this).prev().attr("active");
    //    });
    //});
    //$('#sidebar-wrapper').on('hidden.bs.collapse', function () {
    //    e.preventDefault();
    //    $("#wrapper").toggleClass("toggled");
    //});



    //function searchPublicEvent() {
    //    // Page.Preload.Show();
    //    var _txtPublicEventName =  $('#txtPublicEventName').val();
    //    var _post = $.param({ action: "searchPublicEvent",publicEventName:_txtPublicEventName
    //    });
    //    $.ajax({
    //        type: "POST",
    //        url: "actStdHandler.ashx",
    //        data: _post,
    //        success: function (data) {
    //            // Page.Preload.Hide();
    //        },
    //        error: function (data) {
    //            alert(jQuery.error);
    //        }
    //    });
    //}

    //function getListActNewRelease() {
    //    var _post = $.param({ action: "getListActNewRelease"
    //    });
    //    $.ajax({
    //        type: "POST",
    //        url: "actStdHandler.ashx",
    //        data: _post,
    //        success: function (data) {
    //            $("#divActNewRelease").html(data);
    //        },
    //        error: function (data) {
    //            alert(jQuery.error);
    //        }
    //    });
    //}

    // Auther : เจตน์ เครือชะเอม
    // Date   : 21 ก.ค. 2562
    // Perpose:
    // Method : 
    function loadGroupIndicatorDDl() {
        var _post = $.param({ action: "loadGroupIndicatorDDl"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divGroupIndicatorDDl").html(data);
                $('.ddlGroupIndicator').change(function () {
                    var _ddlGroupIndicator = $(this).val();
                    getListDdlIndicator(_ddlGroupIndicator);
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function getListDdlIndicator(_ddlGroupIndicator) {
        var _post = $.param({ action: "getListDdlIndicator",groupIndicatorId:_ddlGroupIndicator
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divIndicatorDDl").html(data);
                $('.ddlIndicator').change(function () {
                    var _ddlIndicator = $(this).val();
                    getListDdlSubIndicator(_ddlIndicator);
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function getListDdlSubIndicator(_ddlIndicator) {
        var _post = $.param({ action: "getListDdlSubIndicator",indicatorId:_ddlIndicator
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divSubIndicatorDDl").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    

    function getListLoadContactUs() {

        //$.ajax({
        //    type: "POST",
        //    url: "https://op.mahidol.ac.th/sa/employeecommunication-center",
        //    success: function (data) {
        //        $("#divMain").html(data);
        //    },
        //    error: function (data) {
        //        alert(jQuery.error);
        //    }
        //});
        window.open("https://op.mahidol.ac.th/sa/employeecommunication-center","_blank");
        
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 10 ก.ค. 2562
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
                $("#divSubFeedContent").html("<div style='width:82%;' >" + data + "</div>"); // divMain
                chkIsLangTh($("#hddIsTH").val());
                $("#divSubFeedContent").find(".btnGetListActDetailForScholarship").click(function () {
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
    // Date   : 10 ก.ค. 2562
    // Perpose: แสดงหน้ารายการข้อมูลกิจกรรมที่เข้าร่วมที่ได้ค่า A1 ด้านบำเพ็ญประโยชน์
    // Method : getListActDetailForScholarship
    function getListActDetailForScholarship(_acaYear) {
        Page.Preload.Show();
        var _post = $.param({ action: "getListActDetailForScholarshipNew", acaYear: _acaYear
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();

                $(".divDetailActForScholarship").html(data);
                chkIsLangTh($("#hddIsTH").val());
                $(".divDetailActForScholarship").find(".btnPrintActForScholarship").click(function () {
                    //var printContents = document.getElementById('divActScholarship').innerHTML;
                    //var originalContents = document.body.innerHTML;
                    //document.body.innerHTML = "<html><head><title></title></head><body>" + printContents + "</body>";
                    //window.print();
                    //document.body.innerHTML = originalContents;


                    var printContents = document.getElementById('divActScholarship').innerHTML;
                    var winPrint = window.open('', '', 'left=0,top=0,width=800,height=600,toolbar=0,scrollbars=0,status=0');
                    winPrint.document.write('<html><title>Print  Report</title><br /><body><br /> '+printContents+"</body></html>");
                    winPrint.document.close();
                    winPrint.focus();
                    winPrint.print();
                    winPrint.close(); 

                    //initialOnload();
                    //$(".divDetailActForScholarship").find(".btnGetListSchStudentSendAct").click(function () {
                    //    getListSchStudentSendAct();
                    //});


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
    // Date   : 15 ก.ย. 2562
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
    // Date   : 10 ก.ค. 2562
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
    // Date   : 10 ก.ค. 2562
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
                $("#divSubFeedContent").html("<div style='width:82%;' >" + data + "</div>");

                //$(".btnGetListConditionToComplete").click(function () {
                //    //$('#tblListStdSchAct').html();
                //    alert();
                //});
                chkIsLangTh($("#hddIsTH").val());
                $(document).ready(function () {
                    $("#divSubFeedContent").find("#tblStdActType1").DataTable();
                    $("#divSubFeedContent").find("#tblStdActType2").DataTable();
                });
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    function scriptPanelSearch(_panelsearchval) {
            $('#hddPanelSearchVal').val(_panelsearchval);
            if (_panelsearchval == "1") {
                $("#spnPanelSearchByActivity").removeClass("hide").addClass("show");
                $("#spnPanelSearchByFaculty" ).removeClass("show").addClass("hide");
                $("#spnPanelSearchByProjectStatus").removeClass("show").addClass("hide");
                $("#spnPanelSearchByDuration").removeClass("show").addClass("hide");
                $("#spnPanelSearchByGroupIndicator").removeClass("show").addClass("hide");
                
            }
            if (_panelsearchval == "2") {
                $("#spnPanelSearchByDuration").removeClass("hide").addClass("show");
                $("#spnPanelSearchByActivity").removeClass("show").addClass("hide");
                $("#spnPanelSearchByFaculty" ).removeClass("show").addClass("hide");
                $("#spnPanelSearchByProjectStatus").removeClass("show").addClass("hide");
                $("#spnPanelSearchByGroupIndicator").removeClass("show").addClass("hide");
            }
            if (_panelsearchval == "3") {
                $("#spnPanelSearchByProjectStatus").removeClass("hide").addClass("show");
                $("#spnPanelSearchByFaculty").removeClass("show").addClass("hide");
                $("#spnPanelSearchByActivity").removeClass("show").addClass("hide");
                $("#spnPanelSearchByDuration").removeClass("show").addClass("hide");
                $("#spnPanelSearchByGroupIndicator").removeClass("show").addClass("hide");
            }
            else if (_panelsearchval == "4") {
                $('#spnPanelSearchByFaculty').removeClass("hide").addClass("show");
                $("#spnPanelSearchByActivity").removeClass("show").addClass("hide");
                $("#spnPanelSearchByProjectStatus").removeClass("show").addClass("hide");
                $("#spnPanelSearchByDuration").removeClass("show").addClass("hide");
                $("#spnPanelSearchByGroupIndicator").removeClass("show").addClass("hide");
            }
            else if (_panelsearchval == "5") {
                $('#spnPanelSearchByFaculty').removeClass("show").addClass("hide");
                $("#spnPanelSearchByActivity").removeClass("show").addClass("hide");
                $("#spnPanelSearchByProjectStatus").removeClass("show").addClass("hide");
                $("#spnPanelSearchByDuration").removeClass("show").addClass("hide");
                $("#spnPanelSearchByGroupIndicator").removeClass("hide").addClass("show");

            }
    }

    function SearchPublicEvent() {
        var _txtPublicEventName = $('#txtPublicEventName').val();
        var _ddlFaculty = $('.ddlFaculty').val();
        var _ddlProjectStatus = $('.ddlProjectStatus').val();
        var _ddlGroupIndicator = $('.ddlGroupIndicator').val();
        var _ddlIndicator =$('.ddlIndicator').val();
        var _ddlSubIndicator =$('.ddlSubIndicator').val();
        var _txtDateStart = $(".txtDateStart").val();
        var _txtDateEnd = $(".txtDateEnd").val();
        var _panelSearchVal = $('#hddPanelSearchVal').val();
        var _ddlFacultyText = $(".ddlFaculty option:selected").text();
        var _ddlProjectStatusText = $(".ddlProjectStatus option:selected").text();
        var _ddlGroupIndicatorText = $(".ddlGroupIndicator option:selected").text();
        // alert(_panelSearchVal);
        if (_panelSearchVal == "1") {
            _txtDateStart = "";
            _txtDateEnd = "";
            _ddlProjectStatus = "";
            _ddlFaculty = "";
            _ddlGroupIndicator = "";
            _ddlIndicator = "";
            _ddlSubIndicator = "";
        }
        else if (_panelSearchVal == "2") {
            _ddlProjectStatus = "";
            _ddlFaculty = "";
            _txtPublicEventName = "";
            _ddlGroupIndicator = "";
            _ddlIndicator = "";
            _ddlSubIndicator = "";
        }
        else if (_panelSearchVal == "3") {
            _txtDateStart = "";
            _txtDateEnd = "";
            _ddlFaculty = "";
            _txtPublicEventName = "";
            _ddlGroupIndicator = "";
            _ddlIndicator = "";
            _ddlSubIndicator = "";
        }
        else if (_panelSearchVal == "4") {
            _txtDateStart = "";
            _txtDateEnd = "";
            _ddlProjectStatus = "";
            _txtPublicEventName = "";
            _ddlGroupIndicator = "";
            _ddlIndicator = "";
            _ddlSubIndicator = "";
        }
        else if (_panelSearchVal == "5") {
            _txtDateStart = "";
            _txtDateEnd = "";
            _ddlProjectStatus = "";
            _txtPublicEventName = "";
        }
        //alert(_txtPublicEventName);
        //alert(_ddlFaculty);
        //alert(_ddlProjectStatus);
        //alert(_txtDateStart);
        //alert(_txtDateEnd);
        //alert(_ddlGroupIndicator);
        //alert(_ddlGroupIndicatorText);
                    
        getListSubFeedContent("","#divSubFeedContent",_txtPublicEventName,_ddlFaculty,_txtDateStart,_txtDateEnd,_ddlProjectStatus,"2",_ddlFacultyText , _ddlProjectStatusText,_panelSearchVal,_ddlGroupIndicatorText,_ddlGroupIndicator,_ddlIndicator, _ddlSubIndicator);       

    }

    function loadCopyLinkProjectPage(_projectId) {
        // alert(_projectId);
        var _post = $.param({ action: "loadCopyLinkProjectPage",projectId:_projectId
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
     
                $(".divReLoginBody").html(data);
                $("#divReLogin").parent().find(".modal-title").html("<h4><span class='glyphicon glyphicon-link' style='color:#504d4d;'></span> COPY LINK PROJECT</h4>");
                chkIsLangTh($("#hddIsTH").val());
                $('#divReLogin').modal({ show: true });
                $(".btnCopyLinkProject").click(function(){
                    $("#txtCopyLink").select();
                    document.execCommand('copy');
                });
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
        

    }


    function loadRegisterPage(_projectId) {
        // alert(_projectId);

        Page.Preload.Show();
        var _post = $.param({ action: "loadRegisterPage",projectId:_projectId
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                $(".divReLoginBody").html(data);
                
                $("#divReLogin").parent().find(".modal-title").html("<h4><span class='th'>ลงทะเบียนเพื่อเข้าร่วมกิจกรรม</span><span class='en'>Registration</span></h4>");
                $('#divReLogin').modal({ show: true });
                
                chkIsLangTh($("#hddIsTH").val());
                // btnSetJoinProjectSection
                $('.btnQRPayment').click(function () {
                    var _invoiceId = $(this).data("invoiceid");
                    var _sectionId = $(this).data("sectionid");
                    //alert(_invoiceId);
                    //alert(_sectionId);
                    qrPaymentDynamic(_invoiceId,_sectionId,_projectId);
                    
                });
                $('.btnSetJoinProjectSection').click(function () {
                    var _sectionId = $(this).data("sectionid");
                    var _projectId = $(this).data("projectid");
                    var _projectStatusId = $(this).data("projectstatusid");
                    var _projectStartDateRecruit = $(this).data("projectstartdaterecruit");
                    var _stsdatenowjoinact = $(this).data("stsdatenowjoinact");
                    var _isexpressionfaculty = $(this).data("isexpressionfaculty");
                    var _isexpressionclass = $(this).data("isexpressionclass");
                    var _isexpressionstudentcode = $(this).data("isexpressionstudentcode");
                    //alert(_isexpressionfaculty);
                    //alert(_isexpressionclass);
                    //alert(_isexpressionstudentcode);
                    //alert(_isexpressionfaculty+_isexpressionclass+_isexpressionstudentcode);
                    //alert(_isexpressionclass);
                    //alert(_isexpressionstudentcode);

                    _isOverRegister = $(this).data("isoverregister");
                    // alert(_stsdatenowjoinact);
                    if (_isOverRegister == "True") {
                        alert("จำนวนที่รับสมัครเต็มแล้ว กรุณาเปลี่ยน Section");
                        return;
                    }
                    else if (_projectStatusId != "PSS-001") {
                        alert("เข้าร่วมได้เฉพาะกิจกรรมที่สถานะ เปิดรับสมัคร เท่านั้น");
                        return;
                    }
                    else if (_stsdatenowjoinact == "0") {
                        alert("ไม่สามารถเข้าร่วมโครงการได้เนื่องจากไม่อยู่ในช่วงวันที่รับสมัคร");
                        return;
                    }
                    else if (_projectStartDateRecruit == "") {
                        alert("ไม่มีวันที่รับสมัคร กรุณาติดต่อเจ้าหน้าที่ที่จัดตั้งโครงการเพื่อเปิดช่วงเวลาเข้าร่วมกิจกรรม");
                        return;
                    }
                    else if (_isexpressionfaculty == "0") {
                        alert("ไม่สามารถเข้าร่วมกิจกรรมได้ เนื่องจากเงื่อนไขคณะ ไม่ได้อยู่ในการรับสมัคร");
                        return;
                    }
                    else if (_isexpressionclass == "0") {
                        alert("ไม่สามารถเข้าร่วมกิจกรรมได้ เนื่องจากเงื่อนไขชั้นปี ไม่ได้อยู่ในการรับสมัคร");
                        return;
                    }
                    else if (_isexpressionstudentcode == "0") {
                        alert("ไม่สามารถเข้าร่วมกิจกรรมได้ เนื่องจากเงื่อนไขรหัสนักศึกษา ไม่ได้อยู่ในการรับสมัคร");
                        return;
                    }
                    else {
                        setJoinProjectSection(_projectId, _sectionId);
                    }
                });

                $('.btnSetCancelJoinProjectSection').click(function () {
                    var _sectionId = $(this).data("sectionid");
                    var _projectId = $(this).data("projectid");
                    var _invoiceId = $(this).data("invoiceid");
                    setCancelJoinProjectSection(_projectId,_sectionId,_invoiceId);
                });

                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });

    }

    function qrPaymentDynamic(_invoiceId, _sectionId,_projectId) {
          //Page.Preload.Show();
          var _post = $.param({
                action: "qrPaymentDynamic",invoiceId:_invoiceId, sectionId: _sectionId
            });
            $.ajax({
                type: "POST",
                url: "actStdHandler.ashx",
                data: _post,
                success: function (data) {
                    //Page.Preload.Hide();
                    $(".divReLoginBody").html(data);
                    //$('.btnBack').click(function () {
                    //    loadRegisterPage(_projectId);
                    //});
                    setTimeout(function(){ qrPaymentDynamic(_invoiceId, _sectionId,_projectId); }, 3500);
                },
                error: function (data) {
                    alert(jQuery.error);
                }
        });

    }

    function setCancelJoinProjectSection(_projectId, _sectionId,_invoiceId) {
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setCancelJoinProjectSection", sectionId: _sectionId , invoiceId:_invoiceId
            });
            $.ajax({
                type: "POST",
                url: "actStdHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    loadRegisterPage(_projectId);
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }
    }

    function setJoinProjectSection(_projectId,_sectionId) {
        if (confirm("ยืนยันการบันทึกข้อมูล")) {
            var _post = $.param({
                action: "setJoinProjectSection", sectionId: _sectionId
            });
            $.ajax({
                type: "POST",
                url: "actStdHandler.ashx",
                data: _post,
                success: function (data) {
                    alert(data);
                    $('#divReLogin').modal('hide');
                    loadRegisterPage(_projectId); // เดี๋ยวค่อยมาเอาออก
                },
                error: function (data) {
                    alert(jQuery.error);
                }
            });
        }

    }



    function loadSliderReady() {
        jQuery(document).ready(function ($) {
            var options = {
                $AutoPlay: 1,                                       //[Optional] Auto play or not, to enable slideshow, this option must be set to greater than 0. Default value is 0. 0: no auto play, 1: continuously, 2: stop at last slide, 4: stop on click, 8: stop on user navigation (by arrow/bullet/thumbnail/drag/arrow key navigation)
                $AutoPlaySteps: 1,                                  //[Optional] Steps to go for each navigation request (this options applys only when slideshow disabled), the default value is 1
                $Idle: 2000,                                        //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                $PauseOnHover: 1,                                   //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                $ArrowKeyNavigation: 1,   			                //[Optional] Steps to go for each navigation request by pressing arrow key, default value is 1.
                $SlideEasing: $Jease$.$OutQuint,                    //[Optional] Specifies easing for right to left animation, default value is $Jease$.$OutQuad
                $SlideDuration: 800,                                //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide, default value is 20
                //$SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                //$SlideHeight: 300,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $Cols is greater than 1, or parking position is not 0)

                $ArrowNavigatorOptions: {                           //[Optional] Options to specify and enable arrow navigator or not
                    $Class: $JssorArrowNavigator$,                  //[Requried] Class to create arrow navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $Steps: 1                                       //[Optional] Steps to go for each navigation request, default value is 1
                },

                $BulletNavigatorOptions: {                          //[Optional] Options to specify and enable navigator or not
                    $Class: $JssorBulletNavigator$,                 //[Required] Class to create navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $SpacingX: 12,                                  //[Optional] Horizontal space between each item in pixel, default value is 0
                    $Orientation: 1                                 //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                }
            };


            var jssor_slider1 = new $JssorSlider$("slider1_container", options);


            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizing
            function ScaleSlider() {
                var parentWidth = jssor_slider1.$Elmt.parentNode.clientWidth;
                if (parentWidth) {
                    jssor_slider1.$ScaleWidth(parentWidth - 30);
                }
                else
                    window.setTimeout(ScaleSlider, 30);
            }
            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    }
                    
    
    // Auther : เจตน์ เครือชะเอม
    // Date   : 8 พ.ค. 2562
    // Perpose:
    // Method : 
    function loadProjectStatusDll() {
        var _post = $.param({ action: "loadProjectStatusDll"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divProjectStatus").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    // Auther : เจตน์ เครือชะเอม
    // Date   : 30 เม.ย. 2562
    // Perpose:
    // Method : 
    function loadFacultyDDl() {
        var _post = $.param({ action: "loadFacultyDDl"
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $(".divFacultyDDl").html(data);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 21 พ.ย. 2561
    // Perpose:
    // Method : 
    //function menuBarVal(_menuVal) {
    //    //alert(_menuVal);

    //    if (_menuVal == "") {
    //        window.open("studentPublicEvent.aspx", "_self");
    //    }
    //    else if (_menuVal == "3") {
    //        $.ajax({
    //            type: "POST",
    //            url: "studentPublicEventAll.aspx",
    //            success: function (data) {
    //                //alert(data);
    //                $("#divBody").html(data);
    //            },
    //            error: function (data) {
    //                alert(jQuery.error);
    //            }
    //        });

    //    }
    //    else {
    //        getListSubFeedContent(_menuVal, "#divSubFeedContent","","","","",""); // #divBody
    //    }
    //}



    // loadSliderReady();
    // Auther : เจตน์ เครือชะเอม
    // Date   : 14 พ.ย. 2561
    // Perpose:
    // Method : 
    function getListMainFeedContent(_menuVal) {
        var _post = $.param({ action: "getListMainFeedContent", menuVal:_menuVal
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divMainFeedContent").html(data);
                loadSliderReady();
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }

    // Auther : เจตน์ เครือชะเอม
    // Date   : 20 พ.ย. 2561
    // Perpose:
    // Method : 
    function getListSubFeedContent(_menuVal, _divId, _publicEventName, _ddlFaculty, _txtDateStart, _txtDateEnd, _ddlProjectStatus,_statusPublicEvent,_ddlFacultyText , _ddlProjectStatusText,_panelSearchVal,_ddlGroupIndicatorText,_ddlGroupIndicator,_ddlIndicator, _ddlSubIndicator) {

        //alert(_divId);
        //alert(_publicEventName);
        //alert(_txtDateStart);
        //alert(_txtDateEnd);
        //alert(_ddlProjectStatus);
        //alert(_ddlFaculty);
        
        var _post = $.param({
            action: "getListSubFeedContent", menuVal: _menuVal, publicEventName: _publicEventName, ddlFaculty: _ddlFaculty
            , dateStart: _txtDateStart, dateEnd: _txtDateEnd, ddlProjectStatus: _ddlProjectStatus, statusPublicEvent: _statusPublicEvent
            , ddlFacultyText: _ddlFacultyText, ddlProjectStatusText: _ddlProjectStatusText, panelSearchVal: _panelSearchVal
            , ddlGroupIndicatorText: _ddlGroupIndicatorText, ddlGroupIndicator: _ddlGroupIndicator
            , ddlIndicator : _ddlIndicator  , ddlSubIndicator : _ddlSubIndicator
        });




        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            before:Page.Preload.Show(),
            success: function (data) {
                Page.Preload.Hide();
                $(_divId).html(data);
                chkIsLangTh($("#hddIsTH").val());
                $('.btnLoadDetailProjectPublic').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _publicEventName = $(this).data("publiceventname");
                    var _facultyId = $(this).data("facultyid");
                    var _dateStart = $(this).data("datestart");
                    var _dateEnd = $(this).data("dateend");
                    var _ddlProjectStatus = $(this).data("ddlprojectstatus");

                    loadDetailProjectPublic(_projectId, _publicEventName,_facultyId,_dateStart,_dateEnd,_ddlProjectStatus)
                    //alert(_projectId);
                    //alert(_publicEventName);
                });
                $('.btnRegister').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _studentid = $(this).data("studentid");
                    //alert(_studentid);
                    if (_studentid == "") {
                        //alert("กรุณาเข้าสู่ระบบก่อนทำการลงทะเบียนที่ \n\r https://smartedu.mahidol.ac.th/authen/login.aspx ");
                        if (confirm("กรุณาเข้าสู่ระบบก่อนทำการลงทะเบียนที่ \n\r https://smartedu.mahidol.ac.th/authen/login.aspx ")) {
                            window.location.href = "https://smartedu.mahidol.ac.th/authen/login.aspx";
                        }
                        return;
                    }
                    else {
                        loadRegisterPage(_projectId);
                    }
                });

                // alert(_publicEventName);
                $('#txtPublicEventName').val(_publicEventName);
                
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    function setLikeProject(_projectId, _studentId,_studentLike,_publicEventName,_ddlFaculty,_dateStart,_dateEnd,_ddlProjectStatus) {
        Page.Preload.Show();
        var _post = $.param({ action: "setLikeProject",projectId:_projectId,studentId:_studentId,studentLike:_studentLike
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                Page.Preload.Hide();
                alert(data);
                loadDetailProjectPublic(_projectId,_publicEventName,_ddlFaculty,_dateStart,_dateEnd,_ddlProjectStatus);
            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
    }


    function loadDetailProjectPublic(_projectId, _publicEventName, _ddlFaculty, _dateStart, _dateEnd, _ddlProjectStatus) {

        var _post = $.param({ action: "loadDetailProjectPublic",projectId:_projectId, publicEventName: _publicEventName, ddlFaculty: _ddlFaculty
                    , dateStart: _dateStart, dateEnd: _dateEnd , ddlProjectStatus:_ddlProjectStatus
        });
        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $("#divSubFeedContent").html("<div style='width:82%'>" + data + "</div>"); // เดิม divMainDisplay 
                chkIsLangTh($("#hddIsTH").val());
                $('.btnRegister').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _studentid = $(this).data("studentid");
                    //alert(_studentid);
                    if (_studentid == "") {
                        //alert("กรุณาเข้าสู่ระบบก่อนทำการลงทะเบียนที่ \n\r https://smartedu.mahidol.ac.th/authen/login.aspx ");
                        if (confirm("กรุณาเข้าสู่ระบบก่อนทำการลงทะเบียนที่ \n\r https://smartedu.mahidol.ac.th/authen/login.aspx ")) {
                            window.location.href = "https://smartedu.mahidol.ac.th/authen/login.aspx";
                        }
                        return;
                    }
                    else {
                        loadRegisterPage(_projectId);
                    }
                });
                $('.btnLikeProject').click(function () {
                    var _projectId = $(this).data("projectid");
                    var _studentId = $(this).data("studentid");
                    var _studentLike = $(this).data("studentlike");
                    // alert(_studentLike);
                    setLikeProject(_projectId,_studentId,_studentLike,_publicEventName,_ddlFaculty,_dateStart,_dateEnd,_ddlProjectStatus);
                });
                $('.btnCopyLinkProject').click(function () {
                    var _projectId = $(this).data("projectid");
                    // alert(_projectId);
                    loadCopyLinkProjectPage(_projectId);
                });
                $('.thumbDrillDown').click(function(){
                    $('.modal-body').empty();
  	                var title = $(this).parent('a').attr("title");
  	                $('.modal-title').html("ภาพกิจกรรม");
  	                $($(this).parents('div').html()).appendTo('.modal-body');
  	                $('#myModal').modal({show:true});
                });


            },
            error: function (data) {
                alert(jQuery.error);
            }
        });
        // window.open("studentPublicEvent.aspx?projectId="+_projectId+"&publicEventName="+_publicEventName+"&ddlFaculty="+_ddlFaculty+"&dateStart="+_dateStart+"&dateEnd="+_dateEnd+"&ddlProjectStatus="+_ddlProjectStatus, "_self");


    }

    //// Auther : เจตน์ เครือชะเอม
    //// Date   : 20 ธ.ค. 2561
    //// Perpose:
    //// Method : 
    //function getListProjectDetailPublic(_projectId) {
    //    var _post = $.param({ action: "getListProjectDetailPublic", projectId:_projectId
    //    });
    //    $.ajax({
    //        type: "POST",
    //        url: "actStdHandler.ashx",
    //        data: _post,
    //        success: function (data) {
    //            $("#divDetailAll").html(data);
    //        },
    //        error: function (data) {
    //            alert(jQuery.error);
    //        }
    //    });
    //}
    

    function chkIsLangTh(_isTh) {
        $("#hddIsTH").val(_isTh);
        if (_isTh == "1") {
            $(".en").hide();
            $(".th").show();
        }
        else {
            $(".th").hide();
            $(".en").show();
        }
    }

    function getListRequestReasonToSelectPicker() {

        var _post = $.param({
            action: "getListRequestReasonToSelectPicker"
        });

        $.ajax({
            type: "POST",
            url: "actStdHandler.ashx",
            data: _post,
            success: function (data) {
                $('select[name=selRequestReason]').selectpicker('val', JSON.parse(data));
            }
        });

    }




</script>