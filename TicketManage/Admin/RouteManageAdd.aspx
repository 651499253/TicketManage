<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RouteManageAdd.aspx.cs" Inherits="TicketManage.Admin.RouteManageAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    添加航线页面：
    <div>
        <asp:Label ID="Label1" runat="server" Text="航线名称："></asp:Label><asp:TextBox ID="txtRouteName" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="起 始 站："></asp:Label><asp:TextBox ID="txtStartStation" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="终 点 站："></asp:Label><asp:TextBox ID="txtAchieveStation" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="最早班次："></asp:Label><asp:TextBox ID="txtEarliestTrip" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label5" runat="server" Text="最晚班次："></asp:Label><asp:TextBox ID="txtLastedTrip" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="全程时间："></asp:Label><asp:TextBox ID="txtFullTime" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label7" runat="server" Text="站 点 数："></asp:Label><asp:TextBox ID="txtStationNum" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAddRoute" runat="server" Text="添加" OnClick="btnAddRoute_Click" />
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Button ID="btnToRouteManage" runat="server" Text="返回航线页面" OnClick="btnToRouteManage_Click" />
    </asp:Panel>
</asp:Content>
