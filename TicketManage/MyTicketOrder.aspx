<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="MyTicketOrder.aspx.cs" Inherits="TicketManage.MyTicketOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Admin/CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 400px;">
        <div>
            <asp:Label ID="Label1" runat="server" Text="您的订单如下："></asp:Label>
            <asp:ListView ID="LVTicketList" runat="server" DataKeyNames="TicketOrderId" OnItemCommand="LVTicketList_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                        <tr id="Tr1" runat="server">
                            <th id="Th1" runat="server">航班号</th>
                            <th>日期</th>
                            <th>乘客姓名</th>
                            <th>出发站</th>
                            <th>出发时间</th>
                            <th>到达站</th>
                            <th>到达时间</th>
                            <th>航程时间</th>
                            <th>乘客类型</th>
                            <th>船舶类型</th>
                            <th>座位类型</th>
                            <th>是否携带行李</th>
                            <th>支付状态</th>
                            <th>总价</th>
                      <%--      <th>船票状态</th>--%>
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
                        <td><%# Eval("PassengerName")%></td>
                        <td><%# Eval("NowStation")%></td>
                        <td><%# Eval("VoyageTime")%></td>
                        <td><%# Eval("AchieveName")%></td>
                        <td><%# Eval("AchieveTime")%></td>
                        <td><%# Eval("TripTime")%></td>
                        <td><%# Eval("UserTypeContent")%></td>
                        <td><%# Eval("ShipTypName")%></td>
                        <td><%# Eval("SeatTypeName")%></td>
                        <td><%# int.Parse(Eval("BaggageId").ToString())==0?"未携带":"携带" %></td>
                        <td><%# int.Parse(Eval("PayState").ToString())==0?"未支付":"已支付" %></td>
                        <td><%# Eval("TicketPrice")%></td>
                     <%--   <td><%# int.Parse(Eval("TicketState").ToString())==0?"正常":"已退票" %></td>--%>
                        <td>
                            <asp:LinkButton runat="server" CssClass="butnAdd"
                                ID="btnCancleTicket"
                                Text="退票"
                                CommandName="CancleTicket"
                                CommandArgument="aaa" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
