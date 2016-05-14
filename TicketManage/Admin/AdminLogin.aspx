<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="TicketManage.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员登录</title>
    <style type="text/css">
        #left
        {
            width: 15%;
            height: 750px;
            position: relative;
            top: 0px;
            left: 0px;
            background-image: url("../Images/admin/left.jpg");
        }
        #left_1
        {
            position: absolute;
            top: 5px;
            left: 25px;
            width: 120px;
        }
        #right
        {
            position: absolute;
            top: 120px;
            right: 10px;
            width: 80%;
        }
        
        
        #LeftPic
        {
            margin-left: 420px;
            margin-top: -700px;
            height: 80px;
            width: 500px;
        }
        
        #Content
        {
            margin-left: 420px;
            margin-top: 20px;
            height: 220px;
            width: 442px;
        }
        
        #LoginInfo
        {
            margin-left: 180px;
            margin-top: -236px;
            border-color: Blue;
            border-style: groove;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="../Images/admin/head.jpg" Height="100px"
            Width="100%" />
    </div>
    <div id="left">
        <div id="left_1">
            管理员，您好，欢迎来到本系统。
            <br />
            <br />
            请登录后使用。
        </div>
    </div>
    <div id="LeftPic">
       
    </div>
    <div id="Content">
        <img src="../Images/admin/AdminLoginPic.png" style="white-space: 520px; height: 300px;" />
        <div id="LoginInfo">
            <asp:Label ID="Label1" runat="server" Text="账号：" Font-Bold="False" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtLoginName" runat="server" Font-Size="Large"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="密码：" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Font-Size="Large"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAdminLogin" runat="server" Text="登录" Font-Size="Large" OnClick="btnAdminLogin_Click" />
            <br />
            <asp:Label ID="LabelTip" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
