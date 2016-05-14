<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="TicketManage.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 164px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                <a href="News.aspx">新闻资讯</a></td>
            <td colspan="2">
              
            </td>
           
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                最新公告</td>
            <td colspan="2">
                &nbsp;
            </td>
          
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                公司新闻</td>
            <td colspan="2">
                &nbsp;
            </td>
           
        </tr>
        
    </table>
</div>
</asp:Content>
