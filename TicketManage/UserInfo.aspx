<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="TicketManage.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 24px;
            width: 445px;
        }

        .auto-style2 {
            width: 445px;
        }

        .auto-style3 {
            width: 445px;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url('photos/a07.jpg'); height: 747px;">
            <div style="margin-top: 0px; margin-left: 430px;">
                <table style="border: thin solid #009933; width: 46%; height: 49px;">
                    <tr>
                        <td colspan="3" style="text-align: center" class="auto-style3">个人信息</td>

                    </tr>
                    <tr>
                        <td colspan="3" style="color: #FF0000; text-align: center;" class="auto-style1">gridview控件来显示个人信息&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="3" class="auto-style2">
                            <asp:Button ID="Button1" runat="server" Text="修改" />
                            &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="取消" />
                        </td>

                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
