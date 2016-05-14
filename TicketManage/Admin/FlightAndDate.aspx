<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlightAndDate.aspx.cs" Inherits="TicketManage.Admin.FlightAndDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    航班日程管理：
    <div style="height: 500px;">
        <div>
            <asp:Label ID="Label5" runat="server" Text="航班列表如下："></asp:Label>
            <asp:ListView ID="LVFlightAndDateList" runat="server" DataKeyNames="TableId" OnItemCommand="LVFlightAndDateList_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                        <tr id="Tr1" runat="server">
                            <th id="Th1" runat="server">航班名称</th>
                            <th>航行日期</th>
                            <th>一等座数量</th>
                            <th>二等座数量</th>
                            <th>无座数量</th>
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
                        <td><%# Eval("FlightDate")%></td>
                        <td><%# Eval("LevelOneSeatNum")%></td>
                        <td><%# Eval("LevelTwoSeatNum")%></td>
                        <td><%# Eval("LevelNoSeatNum")%></td>
                        <td>
                            <asp:LinkButton runat="server" CssClass="butnAdd"
                                ID="btnEditFlightAndDate"
                                Text="编辑"
                                CommandName="EditFlightAndDate"
                                CommandArgument="aaa" />
                            <asp:LinkButton ID="LbtnDeleteFlightAndDate" runat="server" CommandName="DeleteFlightAndDate"
                                Text="删除" OnClientClick="return confirm('你确定要删除？');" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:Button ID="btnAddNewFlightAndDate" runat="server" Text="添加新航班日程" OnClick="btnAddNewFlightAndDate_Click" />
    </div>
</asp:Content>
