<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightDetailStationManageEdit.aspx.cs" Inherits="TicketManage.Admin.FlightDetailStationManageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    航班站点管理修改：
     <div>
         <asp:DropDownList ID="DDLRoute" runat="server"></asp:DropDownList>
         <asp:DropDownList ID="DDLFlight" runat="server"></asp:DropDownList>
         <br />
         <asp:Label ID="Label1" runat="server" Text="起点站："></asp:Label><asp:TextBox ID="txtNowStation" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="Label2" runat="server" Text="起点时间："></asp:Label><asp:TextBox ID="txtVoyageTime" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="Label3" runat="server" Text="终点站："></asp:Label><asp:TextBox ID="txtAchieveName" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="Label4" runat="server" Text="到站时间："></asp:Label><asp:TextBox ID="txtAchieveTime" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="Label5" runat="server" Text="票价："></asp:Label><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="Label6" runat="server" Text="航程时间："></asp:Label><asp:TextBox ID="txtTripTime" runat="server"></asp:TextBox>
         <br />
         <asp:Button ID="btnEditFlightDetailStation" runat="server" Text="修改" OnClick="btnEditFlightDetailStation_Click"  />

         <asp:Panel ID="Panel1" runat="server" Visible="false">
             <asp:Button ID="btnToFlightDetailStationManage" runat="server" Text="返回航班管理页面" OnClick="btnToFlightDetailStationManage_Click"  />
         </asp:Panel>
     </div>
</asp:Content>
