<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventHandle.aspx.cs" Inherits="modules_EventHandle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=Session["message"].ToString() %>
    </div>
    </form>
</body>
</html>
