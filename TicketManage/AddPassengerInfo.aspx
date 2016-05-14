<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="AddPassengerInfo.aspx.cs" Inherits="TicketManage.AddPassengerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="Label2" runat="server" Text="新建或者修改收货地址："></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="乘客姓名："></asp:Label><asp:TextBox ID="txtPassengerName" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="乘客类型"></asp:Label><asp:DropDownList ID="DDLUserType" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label5" runat="server" Text="身份证号码："></asp:Label><asp:TextBox ID="txtIdentityNum" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="手机号码"></asp:Label><asp:TextBox ID="txtTelphone" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSave" runat="server" Text="确定" OnClick="btnSave_Click" />
        <asp:Button ID="btnReturnUrl" runat="server" Text="返回" OnClick="btnReturnUrl_Click" />
    </div>

    <div>
        <asp:Label ID="Label1" runat="server" Text="现有乘客信息"></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>乘客姓名
                        </th>
                        <th>乘客类型
                        </th>
                        <th>身份证号码
                        </th>
                        <th>手机号码
                        </th>

                        <th>修改
                        </th>
                        <th>删除
                        </th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("PassengerName")%>
                    </td>
                    <td>
                        <%# Eval("UserTypeContent")%>
                    </td>
                    <td>
                        <%# Eval("IdentityNum")%>
                    </td>
                    <td>
                        <%# Eval("Telphone")%>
                    </td>
                    <td>
                        <a href='AddPassengerInfo.aspx?PassengerId=<%# Eval("PassengerId")%>'>修改</a>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("PassengerId")%>' OnClick="OnClick" Text="删除" />
                        </td>
                </tr>
            </ItemTemplate>
            <%--                <AlternatingItemTemplate>
                    <!--交错行-->
                </AlternatingItemTemplate>--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
