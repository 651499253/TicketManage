using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage
{
    public partial class MyTicketOrder : System.Web.UI.Page
    {
        private MyTicketOrderBLL myTicketOrderBll = new MyTicketOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    string UserId = Session["UserId"].ToString();
                    string NowDate = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");


                    DataTable dtOrderTicketInfo = myTicketOrderBll.GetUserAllOrderTicketInfo(NowDate, Convert.ToInt32(UserId));
                    this.LVTicketList.DataSource = dtOrderTicketInfo;
                    this.LVTicketList.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                }
            }
        }

        protected void LVTicketList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
            }
            else
            {
                if (String.Equals(e.CommandName, "CancleTicket"))
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    int TicketOrderId = int.Parse(LVTicketList.DataKeys[dataItem.DisplayIndex].Value.ToString());
                  

                    string UserId = Session["UserId"].ToString();
                    string NowDate = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    DataTable dtOrderTicketInfo = myTicketOrderBll.GetUserAllOrderTicketInfo(NowDate, Convert.ToInt32(UserId));
                    this.LVTicketList.DataSource = dtOrderTicketInfo;
                    this.LVTicketList.DataBind();

                    string CancTicketNum = getTreeNumRandom();
                    string TicketOrderNum = dtOrderTicketInfo.Rows[0]["TicketOrderNum"].ToString();
                    string TicketPrice = dtOrderTicketInfo.Rows[0]["TicketPrice"].ToString();
                    string CancleFee = ((float.Parse (TicketPrice) )* 0.3).ToString();
                    string RemainFee = ((float.Parse(TicketPrice) )* 0.7).ToString();
                    string CancleDate = System.DateTime.Now.ToString("yyyy-MM-dd");

                    //把退票的信息存到退票表
                    int AddCancleTicketResult = myTicketOrderBll.AddCancleTicket(Convert.ToInt32(UserId), CancTicketNum, TicketOrderNum, CancleFee, RemainFee, CancleDate);

                    //退票后，更新票的状态
                    int CancleTicketResult = myTicketOrderBll.UpdateTicketState(TicketOrderId);
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "退票成功，我们收取您30%的手续费。" + "');</script>");




                    DataTable dtOrderTicketInfo2 = myTicketOrderBll.GetUserAllOrderTicketInfo(NowDate, Convert.ToInt32(UserId));
                    this.LVTicketList.DataSource = dtOrderTicketInfo2;
                    this.LVTicketList.DataBind();

                }
            }
        }

        //生成退票单号
        public string getTreeNumRandom()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 999;
            int iDown = 100;
            iResult = ro.Next(iDown, iUp);//生成100到999的三位随机数
            //获取月份，小于10，前面加0
            string Months = int.Parse(DateTime.Now.Month.ToString()) < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            //获取具体的天，小于10 ，前面加0
            string Days = int.Parse(DateTime.Now.Day.ToString()) < 10 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            //获取时，小于10，前面加0
            string Hours = int.Parse(DateTime.Now.TimeOfDay.Hours.ToString()) < 10 ? "0" + DateTime.Now.TimeOfDay.Hours.ToString() : DateTime.Now.TimeOfDay.Hours.ToString();
            //获取分，小于10，前面加0
            string Minutes = int.Parse(DateTime.Now.TimeOfDay.Minutes.ToString()) < 10 ? "0" + DateTime.Now.TimeOfDay.Minutes.ToString() : DateTime.Now.TimeOfDay.Minutes.ToString();
            //获取秒，小于10，前面加0
            string Seconds = int.Parse(DateTime.Now.TimeOfDay.Seconds.ToString()) < 10 ? "0" + DateTime.Now.TimeOfDay.Seconds.ToString() : DateTime.Now.TimeOfDay.Seconds.ToString();
            //生成订单号
            string rum = DateTime.Now.Year.ToString() + Months + Days + Hours + Minutes + Seconds + iResult.ToString().Trim();
            return rum;
        }
    }
}