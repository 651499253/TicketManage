<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightAndDateEdit.aspx.cs" Inherits="TicketManage.Admin.FlightAndDateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/js/My97DatePicker/WdatePicker.js"></script>
    <script>
        function sub() {
            var item = ["<%=txtFlightDate.ClientID %>"];
            var mgf = ["请选择出发日期"];
            for (var i = 0; i < item.length; i++) {
                if (document.getElementById(item[i]).value.length == 0) {
                    alert(mgf[i]);
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    航班日程管理修改：
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="航班名称："></asp:Label><asp:DropDownList ID="DDLFlightName" runat="server"></asp:DropDownList><br />
            <asp:Label ID="Label2" runat="server" Text="航行日期："></asp:Label><asp:TextBox ID="txtFlightDate" runat="server" onfocus="WdatePicker()"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="一等座数量："></asp:Label><asp:TextBox ID="txtLevelOneSeatNum" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="二等座数量："></asp:Label><asp:TextBox ID="txtLevelTwoSeatNum" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" Text="无座数量："></asp:Label><asp:TextBox ID="txtLevelNoSeatNum" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnEditFlightAndDate" runat="server" Text="修改" OnClick="btnEditFlightAndDate_Click" />

        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Button ID="btnToFlightAndDate" runat="server" Text="返回航班日程管理页面" OnClick="btnToFlightAndDate_Click1" />
        </asp:Panel>
    </div>
</asp:Content>
