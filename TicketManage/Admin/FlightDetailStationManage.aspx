<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightDetailStationManage.aspx.cs" Inherits="TicketManage.Admin.FlightDetailStationManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    航班站点管理：

    <div style="height: 500px;">
        <div>
                <asp:Label ID="Label1" runat="server" Text="航班站点列表如下："></asp:Label>
                <asp:ListView ID="LVFlightDetailStationList" runat="server" DataKeyNames="FlightDetailStationId" OnItemCommand="LVFlightDetailStationList_ItemCommand" >
                    <LayoutTemplate>
                        <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                            <tr id="Tr1" runat="server">
                                <th id="Th1" runat="server">航线名称</th>
                                <th>航班名称</th>
                                <th>起点站</th>
                                <th>起点时间</th>
                                <th>终点站</th>
                                <th>到站时间</th>
                                <th>价格</th>
                                <th>航程时间</th>
                                <th>操作</th>
                            </tr>
                            <tr runat="server" id="groupPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr runat="server" id="ProductsRow">
                            <td runat="server" id="itemPlaceholder"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("RouteName")%></td>
                            <td><%# Eval("FlightName")%></td>
                            <td><%# Eval("NowStation")%></td>
                            <td><%# Eval("VoyageTime")%></td>
                            <td><%# Eval("AchieveName")%></td>
                            <td><%# Eval("AchieveTime")%></td>
                            <td><%# Eval("Price")%></td>
                             <td><%# Eval("TripTime")%></td>
                            <td>
                                <asp:LinkButton runat="server" CssClass="butnAdd"
                                    ID="btnEditRoute"
                                    Text="编辑"
                                    CommandName="EditFlightDetailStation"
                                    CommandArgument="aaa" />
                                <asp:LinkButton ID="LbtnDeleteFlightDetailStation" runat="server" CommandName="DeleteFlightDetailStation"
                                    Text="删除" OnClientClick="return confirm('你确定要删除？');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <asp:Button ID="btnAddNewFlightDetailStation" runat="server" Text="添加新航班站点管理" OnClick="btnAddNewFlightDetailStation_Click" />
    </div>
</asp:Content>
