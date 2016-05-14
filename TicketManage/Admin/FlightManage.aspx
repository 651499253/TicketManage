<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightManage.aspx.cs" Inherits="TicketManage.Admin.FlightManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    这是航班管理页面：
    <div style="height: 500px;">
        <div>
            <asp:Label ID="Label5" runat="server" Text="航班列表如下："></asp:Label>
            <asp:ListView ID="LVFlightList" runat="server" DataKeyNames="FlightId" OnItemCommand="LVFlightList_ItemCommand" >
                <LayoutTemplate>
                    <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                        <tr id="Tr1" runat="server">
                            <th id="Th1" runat="server">航班名称</th>
                            <th>航线名称</th>
                            <th>船舶类型</th>
                            <th>出航时间</th>
                            <th>抵航时间</th>
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
                        <td><%# Eval("FlightName")%></td>
                        <td><%# Eval("RouteName")%></td>
                        <td><%# Eval("ShipTypeName")%></td>
                        <td><%# Eval("VoyageTime")%></td>
                        <td><%# Eval("AchieveTime")%></td>
                        <td><%# Eval("TripTime")%></td>
                        <td>
                            <asp:LinkButton runat="server" CssClass="butnAdd"
                                ID="btnEditFlight"
                                Text="编辑"
                                CommandName="EditFlight"
                                CommandArgument="aaa" />
                            <asp:LinkButton ID="LbtnDeleteFlight" runat="server" CommandName="DeleteFlight"
                                Text="删除" OnClientClick="return confirm('你确定要删除？');" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:Button ID="btnAddNewFlight" runat="server" Text="添加新航班" OnClick="btnAddNewFlight_Click"  />

        
    </div>
</asp:Content>
