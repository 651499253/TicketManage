<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="PayTicket.aspx.cs" Inherits="TicketManage.PayTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Admin/CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="出票成功，您的订单如下，请支付："></asp:Label>
        <asp:ListView ID="LVTicketList" runat="server" DataKeyNames="TicketOrderId">
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
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
    </div>
    <div>
        <div>
            <img src="Images/weixinpay.jpg" title="欢迎使用微信支付" height="200" width="500" />
        </div>
        <asp:Button ID="btnPay" runat="server" Text="确定支付" OnClick="btnPay_Click" />
        <asp:Button ID="btnToIndex" runat="server" Text="返回首页" Visible="false" OnClick="btnToIndex_Click" />
    </div>
</asp:Content>
