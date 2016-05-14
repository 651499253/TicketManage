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
    public partial class TicketCreateOrder : System.Web.UI.Page
    {
        TicketMenuBLL tickMenuBll = new TicketMenuBLL();
        TicketCreateOrderBLL tickCreateBll = new TicketCreateOrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    int FlightDetailStationId = int.Parse(Request.QueryString["FlightDetailStationId"]);
                    string NowStation = Request.QueryString["NowStation"];
                    string AchieveName = Request.QueryString["AchieveName"];
                    string FlightDate = Request.QueryString["FlightDate"];
                    string ShipTypeName = Request.QueryString["ShipTypeName"];
                    DataTable dt = tickCreateBll.GetCheckedTicket(NowStation, AchieveName, FlightDate, FlightDetailStationId);
                    this.LVTicketList.DataSource = dt;
                    this.LVTicketList.DataBind();
                    BindDDLSeatType();
                    //把原有的乘客加载出来。
                    int UserId = int.Parse(Session["UserId"].ToString());
                    DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
                    this.Repeater1.DataSource = dtPassenger;
                    this.Repeater1.DataBind();

                    //绑定行李重量
                    BindDDLBaggageWeight();
                }
                else
                {
                    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                }
            }
        }

        public double TotalPrice
        {
            get;
            set;
        }

        //绑定座位类型下拉框
        private void BindDDLSeatType()
        {
            object AllSeatType = tickMenuBll.GetAllSeatTypes();
            this.DDLSeatType.DataSource = AllSeatType;
            this.DDLSeatType.DataTextField = "SeatTypeName"; //实际显示的值
            this.DDLSeatType.DataValueField = "SeatTypeId";//用来取值的
            this.DDLSeatType.DataBind();
        }

        //绑定行李重量下拉框
        private void BindDDLBaggageWeight()
        {
            object dtBaggageWeight = tickCreateBll.GetAllBaggageWeight();
            this.DDLBaggageWeight.DataSource = dtBaggageWeight;
            this.DDLBaggageWeight.DataTextField = "BaggageWeightContent"; //实际显示的值
            this.DDLBaggageWeight.DataValueField = "BaggageWeightTypeId";//用来取值的
            this.DDLBaggageWeight.DataBind();
        }

        protected void btnToIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnToAddPassage_Click(object sender, EventArgs e)
        {
            int FlightDetailStationId = int.Parse(Request.QueryString["FlightDetailStationId"]);
            string NowStation = Request.QueryString["NowStation"];
            string AchieveName = Request.QueryString["AchieveName"];
            string FlightDate = Request.QueryString["FlightDate"];
            string ShipTypeName = Request.QueryString["ShipTypeName"];

            Session["FlightDetailStationId"] = FlightDetailStationId;
            Session["NowStation"] = NowStation;
            Session["AchieveName"] = AchieveName;
            Session["FlightDate"] = FlightDate;
            Session["ShipTypeName"] = ShipTypeName;
            Response.Redirect("AddPassengerInfo.aspx?FlightDetailStationId=" + FlightDetailStationId);
        }

        //让radiobutton只选一个值 ,加页面脚本
        protected void rptTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RadioButton rdo = (RadioButton)e.Item.FindControl("RadioButton1");
            string script = "SetSingleRadioButton(this)";
            rdo.Attributes.Add("onclick", script);
            //删除按钮提示框的出现
            Button btn = (Button)e.Item.FindControl("btnDelete");
            btn.Attributes.Add("onclick", "return confirm('是否要删除');");
        }

        //repeater控件里的删除按钮
        protected void OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int PassengerId = Convert.ToInt32(btn.CommandArgument);
            tickCreateBll.DeletePassenger(PassengerId);
            Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
            int UserId = int.Parse(Session["UserId"].ToString());
            DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
            this.Repeater1.DataSource = dtPassenger;
            this.Repeater1.DataBind();
        }


        // 返回PassengerId的值
        private string Addr()
        {
            //取PassengerId
            string r = "";
            foreach (Control item in Repeater1.Controls)
            {
                try
                {
                    RadioButton rb = ((RadioButton)item.FindControl("RadioButton1"));
                    if (rb.Checked)
                    {
                        r = rb.GroupName;
                    }
                }
                catch { }
            } return r;
        }


        protected void DDLBaggage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IsBaggage = DDLBaggage.SelectedItem.ToString();
            if (IsBaggage == "是")
            {
                this.Panel1.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
            }
        }

        //创建订单
        protected void btnCreateTicket_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int UserId = Convert.ToInt32(Session["UserId"].ToString());
                string SeatTypeName = DDLSeatType.SelectedItem.ToString();
                int PassengerId = int.Parse(Addr());
                int BaggageWeightTypeId = Convert.ToInt32(DDLBaggageWeight.SelectedValue);
                string OrderTime = DateTime.Now.ToString();
                string TicketOrderNum = getTreeNumRandom();
                string ShipTypeName = Request.QueryString["ShipTypeName"];
                int BaggageId = 0;


                double BaggageMultiple = 1.0;
                double SeatTypeMultiple = 1.0;
                double ShipTypeMultiple = 1.0;
                double UserTypeDiscount = 1.0;


                //如果有行李，把行李存进行李表
                string IsBaggage = DDLBaggage.SelectedItem.ToString();
                if (IsBaggage == "是")
                {
                    DataTable dtBaggageWeightById = tickCreateBll.GetAllBaggageWeightById(BaggageWeightTypeId);
                    BaggageMultiple = double.Parse(dtBaggageWeightById.Rows[0]["PriceMultiple"].ToString());

                    string BaggageNum = getBagaRandom();
                    int AddBaggageResult = tickCreateBll.AddBaggage(BaggageNum, PassengerId, BaggageWeightTypeId, OrderTime);
                    BaggageId = Convert.ToInt32(tickCreateBll.GetBaggageId(BaggageNum));
                }

                SeatTypeMultiple = double.Parse(tickCreateBll.GetSeatTypePriceMultiple(SeatTypeName));
                ShipTypeMultiple = double.Parse(tickCreateBll.GetShipTypeNamePriceMultiple(ShipTypeName));
                UserTypeDiscount = double.Parse(tickCreateBll.GetUserTypeDiscount(PassengerId));

                int FlightDetailStationId = int.Parse(Request.QueryString["FlightDetailStationId"]);
                string NowStation = Request.QueryString["NowStation"];
                string AchieveName = Request.QueryString["AchieveName"];
                string FlightDate = Request.QueryString["FlightDate"];
                DataTable dt = tickCreateBll.GetCheckedTicket(NowStation, AchieveName, FlightDate, FlightDetailStationId);
                string FlightName = dt.Rows[0]["FlightName"].ToString();
                string VoyageTime = dt.Rows[0]["VoyageTime"].ToString();
                string AchieveTime = dt.Rows[0]["AchieveTime"].ToString();
                string TripTime = dt.Rows[0]["TripTime"].ToString();

                double OriPrice = double.Parse(dt.Rows[0]["Price"].ToString());
                double TicketPrice = OriPrice * BaggageMultiple * SeatTypeMultiple * ShipTypeMultiple * UserTypeDiscount;
                //this.lbtotalPrice.Text = TicketPrice.ToString();

                int CreateTicketResult = tickCreateBll.CreateTicket(TicketOrderNum, SeatTypeName, ShipTypeName, OrderTime, UserId, PassengerId, TicketPrice.ToString(), FlightName, BaggageId, FlightDate, NowStation, VoyageTime, AchieveName, AchieveTime, TripTime);
                if (CreateTicketResult == 1)
                {
                    Response.Redirect("PayTicket.aspx?TicketOrderNum=" + TicketOrderNum);
                }
            }
            else
            {
                Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
            }
        }

        //生成行李单号
        public string getBagaRandom()
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
            string rum = DateTime.Now.Year.ToString() + iResult.ToString().Trim() + Months + Days + iResult.ToString().Trim();
            return rum;
        }
        //生成订单号
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