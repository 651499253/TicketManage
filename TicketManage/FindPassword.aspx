<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="TicketManage.FindPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style4 {
            height: 50px;
        }
    </style>
</head>
<body style="background-image: url('photos/d02.jpg')">
    <form id="form1" runat="server">
    <div style="position: relative;">
        <div style="position: absolute; top: 100px; left: 600px; color: #0000FF; font-family: 楷体; font-size: xx-large;"><b>找回密码</b></div>
         <div style="position: absolute;left:532px; top: 165px; font-family: 楷体; font-size: large; color: #0000FF; width: 968px;">
         <marquee behavior="alternate" direction="right" srollamount="15"  width="600px" style="height: 33px">船票票务网欢迎您！</marquee>
         </div>
        <table style="border: medium double #0000FF; width: 38%; position: absolute; top: 250px; right: 62px; height: 172px;">
            <tr>
                <td align="right" class="style4" style="font-size: large; color: #0000FF">
                    &nbsp;
                    用户名：</td>
                <td align="left" class="style4">
                    <asp:TextBox ID="TextBox1" runat="server" Width="116px"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="用户名不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4" style="font-size: large; color: #0000FF">
                    &nbsp;
                    请选择问题：</td>
                <td align="left" class="style4">
                    </td>
                <td class="style4">

                    </td>
            </tr>
              <tr>
                <td align="right" class="style4" style="font-size: large; color: #0000FF">
                    &nbsp;
                    请输入问题答案：</td>
                <td align="left" class="style4">
                    </td>
                <td class="style4">

                </td>
            </tr>
            <tr>
                <td colspan="3" class="style4" >
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="确认" BackColor="White" 
                        Font-Size="Large" ForeColor="Blue" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="取消"  Font-Size="Large" ForeColor="Blue" />
                </td>
                
            </tr>
        </table>
      
    </div>
    </form>
</body>
</html>
