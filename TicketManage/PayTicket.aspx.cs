using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace TicketManage
{
    public partial class PayTicket : System.Web.UI.Page
    {
        PayTicketBLL payTicketBll = new PayTicketBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string TicketOrderNum = Request.QueryString["TicketOrderNum"];
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {

                    DataTable dtOrderTicketInfo = payTicketBll.GetOrderTicketInfo(TicketOrderNum);
                    this.LVTicketList.DataSource = dtOrderTicketInfo;
                    this.LVTicketList.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                }
            }


        }
        //模拟支付，改变支付状态
        protected void btnPay_Click(object sender, EventArgs e)
        {
            string TicketOrderNum = Request.QueryString["TicketOrderNum"];
            int PayResult = payTicketBll.UpdateTicketOrder(TicketOrderNum);

            //支付成功之后，把相应的座位的船票减去
            DataTable dtTicketOrder = payTicketBll.GetOrderTicketByOrderNum(TicketOrderNum);
            string FlightName = dtTicketOrder.Rows[0]["FlightName"].ToString();
            string FlightDate = dtTicketOrder.Rows[0]["FlightDate"].ToString();
            string SeatTypeName = dtTicketOrder.Rows[0]["SeatTypeName"].ToString();
            int FlightId = Convert.ToInt32(payTicketBll.GetFlightId(FlightName));
            if (SeatTypeName == "一等座")
            {
                int result = payTicketBll.UpdateFlightAndDateLevelOneSeat(FlightId, FlightDate);
            }
            if (SeatTypeName == "二等座")
            {
                int result = payTicketBll.UpdateFlightAndDateLevelTwoSeat(FlightId, FlightDate);
            }
            if (SeatTypeName == "无座")
            {
                int result = payTicketBll.UpdateFlightAndDateLevelNoSeat(FlightId, FlightDate);
            }

            //数据重新绑定
            DataTable dtOrderTicke = payTicketBll.GetOrderTicketInfo(TicketOrderNum);
            this.LVTicketList.DataSource = dtOrderTicke;
            this.LVTicketList.DataBind();
            Response.Write("<Script Language='JavaScript'>window.alert('" + "支付成功" + "');</script>");
            this.btnPay.Visible = false;
            this.btnToIndex.Visible = true;
        }

        protected void btnToIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}