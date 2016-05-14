<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TicketManage.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 254px;
            height: 51px;
        }
        .style5
        {
            height: 51px;
        }
        .style6
        {
            width: 117px;
            height: 51px;
        }
        .style10
        {
            width: 254px;
            height: 57px;
        }
        .style11
        {
            width: 117px;
            height: 57px;
        }
        .style12
        {
            height: 57px;
        }
        .style13
        {
            width: 254px;
            height: 42px;
        }
        .style14
        {
            width: 117px;
            height: 42px;
        }
        .style15
        {
            height: 42px;
        }
        .style16
        {
            width: 124px;
            height: 19px;
        }
    </style>
</head>
<body style="background-image: url('photos/d02.jpg')">
    <form id="form1" runat="server">
<div style="position: relative;">
        <div style="position: absolute; top: 150px; left: 600px; color: #0000FF; font-family: 楷体; font-size: xx-large;"><b>指定新密码</b></div>
         <div style="position: absolute;left:532px; top: 225px; font-family: 楷体; font-size: large; color: #0000FF; width: 968px;">
         <marquee behavior="alternate" direction="right" srollamount="15"  width="600px" style="height: 33px">船票票务网欢迎您！</marquee>
         </div>
        <table style="border: medium double #0000FF; width: 42%; position: absolute; top: 300px; right:30px; height: 219px;">
            <tr>
                <td align="right" class="style3" style="font-size: large; color: #0000FF">
                    &nbsp;
                    用户名：</td>
                <td align="left" class="style6">
                    <asp:TextBox ID="TextBox1" runat="server" Width="116px" 
                        style="margin-left: 0px; margin-top: 0px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="用户名不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style10" style="font-size: large; color: #0000FF">
                    &nbsp;
                    请输入密码：</td>
                <td align="left" class="style11">
                    <asp:TextBox ID="TextBox2" runat="server" Width="115px"></asp:TextBox>
                </td>
                <td class="style12">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="密码不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
              <td align="right" class="style13" style="font-size: large; color: #0000FF">
                    &nbsp;
                    密码确认：</td>
              <td class="style14">
                  <asp:TextBox ID="TextBox3" runat="server" Width="115px"></asp:TextBox>
                </td>
              <td class="style15">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                      ControlToValidate="TextBox2" ErrorMessage="密码不为空" ForeColor="Red"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
                      ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="前后密码不一致" 
                      ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td  class="style16" align="center">
                    <asp:Button ID="Button1" runat="server" Text="确认" BackColor="White" 
         Font-Size="Large" ForeColor="Blue" /></td>
                   <td colspan="2" align="center"><asp:Button ID="Button2" runat="server" Text="取消"  Font-Size="Large" ForeColor="Blue" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
