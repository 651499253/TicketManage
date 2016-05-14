<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="TicketMenu.aspx.cs" Inherits="TicketManage.TicketMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Admin/CSS/TableStyle.css" rel="stylesheet" />
    <script src="Scripts/js/My97DatePicker/WdatePicker.js"></script>
    <script>
        function sub() {
            var item = ["<%=startData.ClientID %>"];
            var mgf = ["请选择出发日期"];
            for (var i = 0; i < item.length; i++) {
                if (document.getElementById(item[i]).value.length == 0) {
                    alert(mgf[i]);
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:80%; left:10%;">
        <div style="width: 0 auto;height:60px;">
            <asp:Label ID="Label1" runat="server" Text="出发地："></asp:Label><asp:DropDownList ID="DDLStartPlace" runat="server"></asp:DropDownList>   <asp:Label ID="Label2" runat="server" Text="目的地"></asp:Label><asp:DropDownList ID="DDLDestination" runat="server"></asp:DropDownList> <asp:Label ID="Label3" runat="server" Text="出发日期："></asp:Label><asp:TextBox ID="startData" runat="server" onfocus="WdatePicker()"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
        </div>
        <hr />
        <div>
            <asp:Label ID="Label4" runat="server" Text="船舶类型"></asp:Label><asp:DropDownList ID="DDLShipType" runat="server" OnSelectedIndexChanged="DDLShipType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>     
        </div>




        <asp:ListView ID="LVTicketList" runat="server" DataKeyNames="FlightDetailStationId" OnItemCommand="LVTicketList_ItemCommand">
        <LayoutTemplate>
            <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                <tr id="Tr1" runat="server">
                    <th id="Th1" runat="server">航班号</th>
                    <th>出发站</th>
                    <th>出发时间</th>
                    <th>到达站</th>
                    <th>到达时间</th>
                    <th>航程时间</th>
                    <th>船舶类型</th>
                    <th>一等座余票</th>
                    <th>二等座余票</th>
                    <th>无座余票</th>
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
                <td><%# Eval("NowStation")%></td>
                <td><%# Eval("VoyageTime")%></td>
                <td><%# Eval("AchieveName")%></td>
                <td><%# Eval("AchieveTime")%></td>
                <td><%# Eval("TripTime")%></td>
                <td><%# Eval("ShipTypeName")%></td>
                <td><%# Eval("LevelOneSeatNum")%> (¥<%=CurrentOnePrice %>)</td>
                <td><%# Eval("LevelTwoSeatNum") %></td>               
                <td><%# Eval("LevelNoSeatNum")%></td>
                <td>
<%--                    <a href="Index.aspx?FlightDetailStationId=<%# Eval("FlightDetailStationId") %>" target="main">购买</a>--%>
                 <asp:LinkButton runat="server" CssClass="butnAdd"
                            ID="btnBuyTicket"
                            Text="购买"
                            CommandName="BuyTicket"
                            CommandArgument="aaa" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

<%--    <div class="dataPager">
        <asp:DataPager ID="ticketsListDataPager" runat="server" PagedControlID="LVTicketList" PageSize="10" OnPreRender="ticketsListDataPager_PreRender">
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
    </div>--%>


    </div>
</asp:Content>
