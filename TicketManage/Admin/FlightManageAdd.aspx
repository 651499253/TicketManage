<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightManageAdd.aspx.cs" Inherits="TicketManage.Admin.FlightManageAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    这是航班添加页面：
    <div style="height: 500px;">
        <asp:DropDownList ID="DDLRoute" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="DDLShipType" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="航班名称："></asp:Label><asp:TextBox ID="txtFlightName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="出航时间："></asp:Label><asp:TextBox ID="txtVoyageTime" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="抵航时间："></asp:Label><asp:TextBox ID="txtAchieveTime" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="航程时间："></asp:Label><asp:TextBox ID="txtTripTime" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddFlight" runat="server" Text="添加航班" OnClick="btnAddFlight_Click" />

        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Button ID="btnToFlight" runat="server" Text="返回航班管理页面" OnClick="btnToFlight_Click" />
        </asp:Panel>
    </div>
</asp:Content>
