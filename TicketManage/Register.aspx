<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TicketManage.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 19px;
            width: 327px;
        }
        .style4
        {
            height: 19px;
            width: 107px;
        }
        .style5
        {
            width: 107px;
        }
        .style9
        {
            width: 107px;
            height: 23px;
        }
        .style10
        {
            height: 23px;
            width: 327px;
        }
        .style12
        {
            height: 12px;
            width: 107px;
        }
        .style13
        {
            height: 12px;
            width: 327px;
        }
        .style15
        {
            height: 17px;
            width: 107px;
        }
        .style16
        {
            height: 17px;
            width: 327px;
        }
        .style18
        {
            width: 107px;
            height: 22px;
        }
        .style19
        {
            height: 22px;
            width: 327px;
        }
        .style20
        {
            width: 327px;
        }
        .style21
        {
            height: 19px;
            width: 488px;
        }
        .style22
        {
            height: 12px;
            width: 488px;
        }
        .style23
        {
            width: 488px;
        }
        .style24
        {
            height: 17px;
            width: 488px;
        }
        .style25
        {
            height: 22px;
            width: 488px;
        }
        .style26
        {
            height: 23px;
            width: 488px;
        }
    </style>
    <script src="Scripts/js/My97DatePicker/WdatePicker.js"></script>
    <script>
        function sub() {
            var item = ["<%=txtBirthday.ClientID %>"];
            var mgf = ["请选择出生日期"];
            for (var i = 0; i < item.length; i++) {
                if (document.getElementById(item[i]).value.length == 0) {
                    alert(mgf[i]);
                    return false;
                }
            }
        }
    </script>
</head>
<body style="background-image: url('photos/d031.jpg')">
    <form id="form1" runat="server">
        <div style="width: 676px; position: relative;">
            <div style="position: absolute; top: 75px; left: 450px; font-size: xx-large; font-family: 宋体, Arial, Helvetica, sans-serif; font-weight: bold; width: 214px;">用户注册界面</div>
            <div style="position: absolute; left: 190px; top: 120px; font-family: 楷体; font-size: large; color: #0000FF; width: 968px;">
                <marquee behavior="alternate" direction="right" srollamount="15" width="600px" style="height: 33px">船票票务网欢迎您！</marquee>
            </div>
            <table style="border: thick double #0000FF; width: 81%; color: #000000; position: absolute; left: 320px; top: 175px; height: 471px; font-weight: bold;">
                <tr>
                    <td class="style21" align="right">姓名：</td>
                    <td class="style4" align="left">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtUserName" ErrorMessage="姓名不为空" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style22">&nbsp;
                    手机号码：</td>
                    <td class="style12" align="left">
                        <asp:TextBox ID="txtTelphone" runat="server" Height="16px"></asp:TextBox>
                    </td>
                    <td class="style13" align="left">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtTelphone" ErrorMessage="格式出错请重新输入"
                            ForeColor="Red" ValidationExpression="^([0-9]{11})?"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">身份证号码：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtIdentityNum" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="style20">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                            runat="server" ControlToValidate="txtIdentityNum" ErrorMessage="格式出错请重新输入"
                            ForeColor="Red" ValidationExpression="^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">登录名：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="登录名不为空" ControlToValidate="txtLoginName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">&nbsp;
                    密码：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="密码不为空" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">密码确认：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtPasswordConfirm" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="密码不为空" ControlToValidate="txtPasswordConfirm" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm"
                            ErrorMessage="密码不一致，重新输入" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">性别：</td>
                    <td class="style5" align="left">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="男" Checked="True" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" Text="女" />
                    </td>
                    <td align="left" class="style20"></td>
                </tr>
                <tr>
                    <td align="right" class="style23">出生日期：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtBirthday" runat="server" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="left" class="style20"></td>
                </tr>
                <tr>
                    <td align="right" class="style24">年龄：</td>
                    <td class="style15" align="left">
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </td>
                    <td class="style16" align="left"></td>
                </tr>

                <tr>
                    <td align="right" class="style25">邮箱：</td>
                    <td class="style18" align="left">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td class="style19" align="left">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="格式出错，请重新输入" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style23">用户类型：</td>
                    <td class="style5" align="left">
                        <asp:DropDownList ID="DDLUserType" runat="server"></asp:DropDownList></td>
                    <td align="left" class="style20"></td>
                </tr>
                <tr>
                    <td align="right" class="style23">问题：</td>
                    <td class="style5" align="left">
                        <asp:DropDownList ID="DDLQuestionType" runat="server"></asp:DropDownList>
                    </td>
                    <td align="left" class="style20"></td>
                </tr>
                <tr>
                    <td align="right" class="style23">问题答案：</td>
                    <td class="style5" align="left">
                        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="问题答案不能为空" ControlToValidate="txtAnswer" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" class="style26"></td>
                    <td class="style9" align="left">
                        <asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" /></td>
                    <td class="style10"></td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <div>
                    <asp:Button ID="btnToLogin" runat="server" Text="现在就去登录" OnClick="btnToLogin_Click" />
                </div>
            </asp:Panel>
        </div>


    </form>
</body>
</html>
