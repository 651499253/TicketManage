<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RouteManage.aspx.cs" Inherits="TicketManage.Admin.RouteManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    这是航线管理页面
        <div style="height: 500px;">
            <div>
                <asp:Label ID="Label1" runat="server" Text="航线列表如下："></asp:Label>
                <asp:ListView ID="LVRouteList" runat="server" DataKeyNames="RouteId" OnItemCommand="LVRouteList_ItemCommand">
                    <LayoutTemplate>
                        <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                            <tr id="Tr1" runat="server">
                                <th id="Th1" runat="server">航线名称</th>
                                <th>起始站</th>
                                <th>终点站</th>
                                <th>最早班次</th>
                                <th>最晚班次</th>
                                <th>全程时间</th>
                                <th>站点数</th>
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
                            <td><%# Eval("StartStation")%></td>
                            <td><%# Eval("AchieveStation")%></td>
                            <td><%# Eval("EarliestTrip")%></td>
                            <td><%# Eval("LastedTrip")%></td>
                            <td><%# Eval("FullTime")%></td>
                            <td><%# Eval("StationNum")%></td>
                            <td>
                                <asp:LinkButton runat="server" CssClass="butnAdd"
                                    ID="btnEditRoute"
                                    Text="编辑"
                                    CommandName="EditRoute"
                                    CommandArgument="aaa" />
                                <asp:LinkButton ID="LbtnDeleteRoute" runat="server" CommandName="DeleteRoute"
                                    Text="删除" OnClientClick="return confirm('你确定要删除？');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <asp:Button ID="btnAddNewRoute" runat="server" Text="添加新航线" OnClick="btnAddNewRoute_Click" />
        </div>
</asp:Content>
