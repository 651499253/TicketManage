<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketManage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .style1
        {
            width: 105px;
        }
        .style4
        {
            height: 46px;
        }
        .style5
        {
            width: 246px;
        }
    </style>
</head>
<body  style="background-image: url('photos/d02.jpg')">
    <form id="form1" runat="server">
        <%--        <div>
            <asp:Label ID="Label1" runat="server" Text="账号："></asp:Label><asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox><asp:Label ID="LbLoginName" runat="server" Text="账户不能为空" Visible="False" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><asp:Label ID="LbPassword" runat="server" Text="密码不能为空" Visible="False" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lbTip" runat="server" Visible="False" ForeColor="Red"></asp:Label>
            <br />

            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
        </div>--%>
        开心



        <div style="position: relative;">
            <div style="position: absolute; top: 100px; left: 600px; color: #0000FF; font-family: 楷体; font-size: xx-large;"><b>用户登录</b></div>
            <div style="position: absolute; left: 532px; top: 150px; font-family: 楷体; font-size: large; color: #0000FF; width: 968px;">
                <marquee behavior="alternate" direction="right" srollamount="15" width="600px" style="height: 33px">船票票务网欢迎您！</marquee>
            </div>
            <table style="border: medium double #0000FF; width: 38%; position: absolute; top: 300px; right: 62px; height: 172px;">
                <tr>
                    <td align="right" class="style5" style="font-size: large; color: #0000FF">&nbsp;
                    用户名：</td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtLoginName" runat="server" Width="116px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtLoginName" ErrorMessage="用户名不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style5" style="font-size: large; color: #0000FF">&nbsp;
                    密 码：</td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtPassword" runat="server" Width="115px"></asp:TextBox>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="密码不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLogin" runat="server" Text="确认" BackColor="White"
                        Font-Size="Large" ForeColor="Blue" OnClick="btnLogin_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="取消" Font-Size="Large" ForeColor="Blue" />
                    </td>

                </tr>
            </table>
            <table style="position: absolute; top: 220px; right: 80px; width: 268px; height: 50px;">
                <tr>
                    <td align="center">忘记密码?
                    </td>
                    <td align="center">
                        <a href="FindPassword.aspx">
                            <img src="photos/点击.png"></a>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
