<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="TicketCreateOrder.aspx.cs" Inherits="TicketManage.TicketCreateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Admin/CSS/TableStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">

        function SetSingleRadioButton(current) {
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i]
                if (elm.type == 'radio') {
                    elm.checked = false;
                }
            }
            current.checked = true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="btnToIndex" runat="server" Text="返回首页" OnClick="btnToIndex_Click" />
    </div>
    <div>
        <asp:ListView ID="LVTicketList" runat="server" DataKeyNames="FlightDetailStationId">
            <LayoutTemplate>
                <table runat="server" id="tbFoodListView" class="tblListView" border="0" cellpadding="1" cellspacing="1">
                    <tr id="Tr1" runat="server">
                        <th id="Th1" runat="server">航班号</th>
                        <th>日期</th>
                        <th>出发站</th>
                        <th>出发时间</th>
                        <th>到达站</th>
                        <th>到达时间</th>
                        <th>航程时间</th>
                        <th>船舶类型</th>
                        <th>一等座余票</th>
                        <th>二等座余票</th>
                        <th>无座余票</th>
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
                    <td><%# Eval("NowStation")%></td>
                    <td><%# Eval("VoyageTime")%></td>
                    <td><%# Eval("AchieveName")%></td>
                    <td><%# Eval("AchieveTime")%></td>
                    <td><%# Eval("TripTime")%></td>
                    <td><%# Eval("ShipTypeName")%></td>
                    <td><%# Eval("LevelOneSeatNum")%></td>
                    <td><%# Eval("LevelTwoSeatNum") %></td>
                    <td><%# Eval("LevelNoSeatNum")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>

    <div>
        <asp:Label ID="Label5" runat="server" Text="请选择座位类型:"></asp:Label>
        <asp:DropDownList ID="DDLSeatType" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="请选择乘坐人："></asp:Label>
        <asp:Button ID="btnToAddPassage" runat="server" Text="添加新乘客" OnClick="btnToAddPassage_Click" />
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="rptTest_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th></th>
                        <th>选择
                        </th>
                        <th>乘客姓名
                        </th>
                        <th>乘客类型
                        </th>
                        <th>身份证号码
                        </th>
                        <th>手机号码
                        </th>

                        <th>修改
                        </th>
                        <th>删除
                        </th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>选择
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName='<%# Eval("PassengerId")%>' name="addrId" Checked=' <%#Container.ItemIndex.ToString()=="0" ? true :false%>' />
                    </td>
                    <td>
                        <%# Eval("PassengerName")%>
                    </td>
                    <td>
                        <%# Eval("UserTypeContent")%>
                    </td>
                    <td>
                        <%# Eval("IdentityNum")%>
                    </td>
                    <td>
                        <%# Eval("Telphone")%>
                    </td>
                    <td>
                        <a href='AddPassengerInfo.aspx?PassengerId=<%# Eval("PassengerId")%>'>修改</a>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("PassengerId")%>' OnClick="OnClick" Text="删除" />
                        </td>
                </tr>
            </ItemTemplate>
            <%--                <AlternatingItemTemplate>
                    <!--交错行-->
                </AlternatingItemTemplate>--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="是否携带行李："></asp:Label>
        <asp:DropDownList ID="DDLBaggage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLBaggage_SelectedIndexChanged">
            <asp:ListItem Selected="True">是</asp:ListItem>
            <asp:ListItem>否</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="请选择行李重量："></asp:Label>
            <asp:DropDownList ID="DDLBaggageWeight" runat="server"></asp:DropDownList>
        </div>
    </asp:Panel>
    <br />
    <hr />
    <%--<div>
        <asp:Label ID="Label4" runat="server" Text="最终票价："></asp:Label><asp:Label ID="lbtotalPrice" runat="server" Text=""></asp:Label>
    </div>--%>
    <div>
        <asp:Button ID="btnCreateTicket" runat="server" Text="确定购买" OnClick="btnCreateTicket_Click" />
    </div>
</asp:Content>
