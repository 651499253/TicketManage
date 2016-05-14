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
    public partial class TicketMenu : System.Web.UI.Page
    {
        private TicketMenuBLL tickMenuBll = new TicketMenuBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //if (Session["UserId"] != null)
                //{
                //string UserId = Session["UserId"].ToString();
                BindDDLStartPlace();
                BindDDLDestination();
                BindDDLShipType();
                //BindDDLSeatType();
                //}
                //else
                //{
                //    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                //}
            }
        }

        public double CurrentOnePrice
        {
            get;
            set;
        }

        public double CurrentTwoPrice
        {
            get;
            set;
        }
        public double CurrentNoPrice
        {
            get;
            set;
        }

        //绑定出发地下拉框
        private void BindDDLStartPlace()
        {
            object AllStations = tickMenuBll.GetAllStations();
            this.DDLStartPlace.DataSource = AllStations;
            this.DDLStartPlace.DataTextField = "StationName"; //实际显示的值
            this.DDLStartPlace.DataBind();
        }

        //绑定目的地下拉框
        private void BindDDLDestination()
        {
            object AllStations = tickMenuBll.GetAllStations();
            this.DDLDestination.DataSource = AllStations;
            this.DDLDestination.DataTextField = "StationName"; //实际显示的值
            this.DDLDestination.DataBind();
        }

        //绑定船舶类型下拉框
        private void BindDDLShipType()
        {
            object AllShipType = tickMenuBll.GetAllShipTypes();
            this.DDLShipType.DataSource = AllShipType;
            this.DDLShipType.DataTextField = "ShipTypeName"; //实际显示的值
            this.DDLShipType.DataValueField = "ShipTypeId";//用来取值的
            this.DDLShipType.DataBind();
        }


        //选择船舶类型后触发事件
        protected void DDLShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string StartPlace = DDLStartPlace.SelectedValue;
            string Destination = DDLDestination.SelectedValue;
            string startData = this.startData.Text;
            string ShipTypeName = DDLShipType.SelectedItem.ToString();

            DataTable dt = tickMenuBll.GetTicketByparmsAndShipName(StartPlace, Destination, startData, ShipTypeName);
            this.LVTicketList.DataSource = dt;
            this.LVTicketList.DataBind();
            if (ShipTypeName == "大型游轮")
            {

                DataTable dtone = tickMenuBll.GetTicketByparmsAndShipName(StartPlace, Destination, startData, ShipTypeName);
                if (dtone.Rows.Count > 0)
                {
                    CurrentOnePrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 1.2;
                    CurrentTwoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 1;
                    CurrentNoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 0.8;
                }
            }
            if (ShipTypeName == "快艇")
            {

                DataTable dtone = tickMenuBll.GetTicketByparmsAndShipName(StartPlace, Destination, startData, ShipTypeName);
                if (dtone.Rows.Count > 0)
                {
                    CurrentOnePrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.2 * 1.2;
                    CurrentTwoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.2 * 1;
                    CurrentNoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.2 * 0.8;
                }
            }
            if (ShipTypeName == "普通游轮")
            {

                DataTable dtone = tickMenuBll.GetTicketByparmsAndShipName(StartPlace, Destination, startData, ShipTypeName);
                if (dtone.Rows.Count > 0)
                {
                    CurrentOnePrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.0 * 1.2;
                    CurrentTwoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.0 * 1;
                    CurrentNoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.0 * 0.8;
                }
            }



        }

        ////选择座位后触发事件
        //protected void DDLSeatType_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //查找按钮
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string StartPlace = DDLStartPlace.SelectedValue;
            string Destination = DDLDestination.SelectedValue;
            string startData = this.startData.Text;
            //先判断出发地和目的地不能一样
            if (StartPlace == Destination)
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "目的地不能和出发地一样" + "');</script>");
                DataTable dt0 = tickMenuBll.GetTicketByparm(StartPlace, Destination, startData);
                this.LVTicketList.DataSource = dt0;
                this.LVTicketList.DataBind();
                return;
            }

            //判断系统里有没有某天的船票
            if (string.IsNullOrEmpty(tickMenuBll.IsTicketSomeDay(startData)))
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "对不起，没有当天的船票" + "');</script>");
                DataTable dt1 = tickMenuBll.GetTicketByparm(StartPlace, Destination, startData);
                this.LVTicketList.DataSource = dt1;
                this.LVTicketList.DataBind();
                return;
            }
            //默认是大型游轮
            string ShipTypeName = DDLShipType.SelectedItem.ToString();

            DataTable dt = tickMenuBll.GetTicketByparmsAndShipName(StartPlace, Destination, startData, ShipTypeName);


            //DataTable dt = tickMenuBll.GetTicketByparm(StartPlace, Destination, startData);
            this.LVTicketList.DataSource = dt;
            this.LVTicketList.DataBind();
            CurrentOnePrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 1.2;
            CurrentTwoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 1;
            CurrentNoPrice = double.Parse(dt.Rows[0]["Price"].ToString()) * 1.5 * 0.8;


            //Response.Write(startData + StartPlace + Destination);
        }

        protected void LVTicketList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
            }
            else
            {
                if (String.Equals(e.CommandName, "BuyTicket"))
                {
                    string StartPlace = DDLStartPlace.SelectedValue;
                    string Destination = DDLDestination.SelectedValue;
                    string startData = this.startData.Text;
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    int FlightDetailStationId = int.Parse(LVTicketList.DataKeys[dataItem.DisplayIndex].Value.ToString());

                    DataTable dt = tickMenuBll.GetTicketByparmsAndDetailId(StartPlace, Destination, startData, FlightDetailStationId);
                    //Response.Write(StartPlace + Destination + startData);
                    string LevelOneSeatNum = dt.Rows[0]["LevelOneSeatNum"].ToString();
                    string LevelTwoSeatNum = dt.Rows[0]["LevelTwoSeatNum"].ToString();
                    string LevelNoSeatNum = dt.Rows[0]["LevelNoSeatNum"].ToString();
                    if (string.IsNullOrEmpty(LevelNoSeatNum) && string.IsNullOrEmpty(LevelTwoSeatNum) && string.IsNullOrEmpty(LevelNoSeatNum))
                    {
                        Response.Write("<Script Language='JavaScript'>window.alert('" + "无票，无法购买" + "');</script>");
                    }
                    else
                    {
                        string ShipTypeName = DDLShipType.SelectedItem.ToString();
                        Response.Redirect("TicketCreateOrder.aspx?FlightDetailStationId=" + FlightDetailStationId + "&NowStation=" + StartPlace + "&AchieveName=" + Destination + "&FlightDate=" + startData + "&ShipTypeName=" + ShipTypeName);
                    }

                }
            }
        }


        //protected void ticketsListDataPager_PreRender(object sender, EventArgs e)
        //{

        //}
    }
}