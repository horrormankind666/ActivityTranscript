<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestResponsive.aspx.cs" Inherits="modules_student_TestResponsive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
<style>
    .transparent-navbar{
    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";       /* IE 8 */
    filter: alpha(opacity=50);  /* IE 5-7 */
    -moz-opacity: 0.5;          /* Netscape */
    -khtml-opacity: 0.5;        /* Safari 1.x */
    opacity: 0.5;  
    box-shadow: 1px 5px black;

    -moz-box-shadow:    inset 0 0 10px #000000;
    -webkit-box-shadow: inset 0 0 10px #000000;
    box-shadow:         inset 0 0 10px #000000;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="padding-top:60px;"></div>
<nav class="fixed-top navbar navbar-dark bg-dark transparent-navbar" style="background-color: #e3f2fd;">
  <a class="navbar-brand" href="#">MU Activity Transcript</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarText">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Features</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Pricing</a>
      </li>
    </ul>
    <span class="navbar-text">
      Navbar text with an inline element
    </span>
  </div>
</nav>

<div class="container">
  <h2>ค้นหาข้อมูลเพื่อเข้าร่วม</h2>
  <p>Search by project name : <input type="text" class="form-control" id="usr" name="username">
       
  </p>
  <p><center><button type="button" class="btn btn-secondary">
       <span class="oi oi-magnifying-glass"></span>
      Search</button></p>
  <p>  
 
    <div class="card" style="width: 18rem;">
      <img class="card-img-top" src="../../images/fc295dee-0a85-403d-9088-6fe632da06d6.jpg" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title"><b>อบรมภาษาอังกฤษเข้มข้น</b></h5>
        <p class="card-text">จัดอบรมเพื่อปรับความรู้พื่นฐานภาษาอังกฤษ ตามคะแนน MUELT ที่สอบตอนรับเข้าศึกษา
            <span class="badge badge-warning">เปิดรับสมัคร : 18/01/2020-19/01/2020</span>
        </p>
          
      </div>

      <div class="card-body">
        <a href="#" class="card-link">Join</a>
        <a href="#" class="card-link">Detail</a>
      </div>
    </div>



    </p>

  <table class="table">
    <thead>
      <tr class="table-primary">
        <th>Section name</th>
        <th>Date time</th>
        <th>Amount</th>
        <th>Status</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>กลุ่มที่ 1 อบรมโครงการภาษาอังกฤษเข้มข้นครั้งที่ 1</td>
        <td>20/01/2020 10:00 น.- 20/01/2020 20:00 น.</td>
        <td>10 / 100</td>
        <td><button type="button" class="btn btn-info">join</button></td>
      </tr>      
     
    </tbody>
  </table>
</div>
    </form>
</body>
</html>
