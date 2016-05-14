<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReportManage.aspx.cs" Inherits="TicketManage.Admin.ReportManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    这是报表管理页面
    <asp:Button ID="Button1" runat="server" Text="今日报表" /><asp:Button ID="Button2" runat="server" Text="月报表" /><asp:Button ID="Button3" runat="server" Text="退票报表" />
</asp:Content>
