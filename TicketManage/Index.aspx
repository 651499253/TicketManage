<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TicketManage.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 136px;
        }
        .auto-style2 {
            width: 136px;
            height: 19px;
        }
        .auto-style3 {
            height: 19px;
            width: 591px;
        }
        .auto-style4 {
            width: 591px;
        }
        .auto-style5 {
            width: 136px;
            height: 36px;
        }
        .auto-style6 {
            width: 541px;
        }
        .auto-style7 {
            width: 541px;
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div style="height: 300px;">
        <asp:Button ID="btnToTicketMenu" runat="server" Text="订票" OnClick="btnToTicketMenu_Click" />
        <asp:Button ID="btnTicketOrder" runat="server" Text="我的订单" OnClick="btnTicketOrder_Click" />
    </div>--%>


    <div>
        <table style="width: 100%; height: 67%; background-color: #FF9966; margin-top:0px;">
          <tr > 
              <td >
               <a href="Index.aspx" style="text-decoration: none"><img src="photos/首页.png" style="width: 52px; height: 63px"/></a>
              </td>
              <td>
                <a href="TicketMenu.aspx" style="text-decoration: none"><img src="photos/购票.png"/></a>
              </td>
              <td >
                 <a href="TicketMenu.aspx" style="text-decoration: none"><img src="photos/航班查询.png"/></a>
                 </td>
                  <td >
                 <a href="MyTicketOrder.aspx" style="text-decoration: none"><img src="photos/我的订单.png"/></a>
              </td>
               <td class="style1">
                 <a href="News.aspx" style="text-decoration: none"><img src="photos/新闻中心.png"/></a>
              </td>
          </tr>
          </table>
       </div>
  
       <div style="position: relative; top: 1px; left: 0px; ">
         <div style="width: 600px; background-color: #FF66FF; height: 230px; float: left;">
          <table style="width: 100%; text-align:center; height: 223px;">
              <tr><td class="auto-style2"><b>个人信息</b><br />
                  <br />
                  </td>
                  <td class="auto-style3">&nbsp;</td>
                 
              </tr>
              <tr><td class="auto-style1"><a href="UserInfo.aspx" style="text-decoration: none;color: #000000;">个人信息查询</a><br />
                  <br />
                  </td>
                  <td rowspan="4" class="auto-style4"></td>
                  
              </tr>
              <tr><td class="auto-style1"><a href="修改密码.aspx"style="text-decoration: none;color: #000000;">帐号安全</a><br />
                  <br />
                  </td>
              
              </tr>
               <tr><td class="auto-style1"><a href="联系人管理.aspx" style="text-decoration: none;color: #000000;">常用联系人管理</a><br />
                   <br />
                   </td>
       
              </tr>
               <tr><td class="auto-style5"><a href="行李管理.aspx" style="text-decoration: none;color: #000000;">行李管理</a><br />
                   <br />
                   </td>
                 
              </tr>
          </table>
      </div>
         <div style="text-align :center; background-color: #00FFFF; float: left; height: 230px;width:732px;">
           <table style="height: 221px; width: 595px;" >
             <tr><td class="auto-style7">最新公告</td></tr>
             <tr><td class="auto-style6"></td></tr>
           </table>
          </div>
      </div>
     
     <div>
         <div style="background-image: url('photos/查询01.png'); height:240px; width: 450px; background-color: #FF99CC;float:left;text-align:center;">余票查询</div>
         <div style="background-color: #C0C0C0;height:240px;width:480px;float:left;text-align:center;">投诉建议</div>
         <div style="background-color: #CC6699; height:240px;width:402px;float:left;text-align:center;">友情提示</div>
    </div>
    
    <div style="font-family: 华文隶书; font-size: large; color: #FF0000; background-color: #9933FF; height:18px; width:1332px; text-align:center;margin-top: 0px; margin-left: 0px; "></div>
</asp:Content>
