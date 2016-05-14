<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TicketOrderManage.aspx.cs" Inherits="TicketManage.Admin.TicketOrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    这是船票订单管理页面：
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="所有订单如下："></asp:Label>
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
                            <th>船票状态</th>
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
                        <td><%# int.Parse(Eval("TicketState").ToString())==0?"正常":"已退票" %></td>

                    </tr>
                </ItemTemplate>
            </asp:ListView>
                <div class="dataPager">
        <asp:DataPager ID="lvOrderDataPager" runat="server" PagedControlID="LVTicketList" PageSize="6" OnPreRender="lvOrderDataPager_PreRender">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowFirstPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="true"
                    FirstPageImageUrl="../Images/Page/首页.jpg" />
                <asp:NumericPagerField ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowLastPageButton="true"
                    ShowNextPageButton="true"
                    ShowPreviousPageButton="false"
                    LastPageImageUrl="../Images/Page/末页.jpg" />
            </Fields>

        </asp:DataPager>
    </div>
        </div>
    </div>
</asp:Content>
