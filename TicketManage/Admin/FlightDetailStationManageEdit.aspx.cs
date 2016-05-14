using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace TicketManage.Admin
{
    public partial class FlightDetailStationManageEdit : System.Web.UI.Page
    {
        private FlightDetailStationManageBLL flightDetailStationManageBll = new FlightDetailStationManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLRoute();
                BindDDLFlight();
                int FlightDetailStationId = Convert.ToInt32(Request.QueryString["FlightDetailStationId"]);
                if (FlightDetailStationId == 0)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                DataTable dtFlightDetailStation = flightDetailStationManageBll.GetFlightDetailStation(FlightDetailStationId);
                this.DDLRoute.SelectedValue = dtFlightDetailStation.Rows[0]["RouteId"].ToString();
                this.DDLFlight.SelectedValue = dtFlightDetailStation.Rows[0]["FlightId"].ToString();
                this.txtNowStation.Text = dtFlightDetailStation.Rows[0]["NowStation"].ToString();
                this.txtVoyageTime.Text = dtFlightDetailStation.Rows[0]["VoyageTime"].ToString();
                this.txtAchieveName.Text = dtFlightDetailStation.Rows[0]["AchieveName"].ToString();
                this.txtAchieveTime.Text = dtFlightDetailStation.Rows[0]["AchieveTime"].ToString();
                this.txtPrice.Text = dtFlightDetailStation.Rows[0]["Price"].ToString();
                this.txtTripTime.Text = dtFlightDetailStation.Rows[0]["TripTime"].ToString();
            }
        }

        //把航线绑定到下拉框
        private void BindDDLRoute()
        {
            DataTable AllRoutes = flightDetailStationManageBll.GetAllRoutes();
            this.DDLRoute.DataSource = AllRoutes;
            this.DDLRoute.DataTextField = "RouteName"; //实际显示的值
            this.DDLRoute.DataValueField = "RouteId";//用来取值的
            this.DDLRoute.DataBind();
        }

        //把航班绑定到下拉框
        private void BindDDLFlight()
        {
            DataTable AllFlights = flightDetailStationManageBll.GetAllFlights();
            this.DDLFlight.DataSource = AllFlights;
            this.DDLFlight.DataTextField = "FlightName"; //实际显示的值
            this.DDLFlight.DataValueField = "FlightId";//用来取值的
            this.DDLFlight.DataBind();
        }

        protected void btnEditFlightDetailStation_Click(object sender, EventArgs e)
        {
            int RouteId = Convert.ToInt32(this.DDLRoute.SelectedValue);
            int FlightId = Convert.ToInt32(this.DDLFlight.SelectedValue);
            string NowStation = this.txtNowStation.Text;
            string VoyageTime = this.txtVoyageTime.Text;
            string AchieveName = this.txtAchieveName.Text;
            string AchieveTime = this.txtAchieveTime.Text;
            string Price = this.txtPrice.Text;
            string TripTime = this.txtTripTime.Text;
            int FlightDetailStationId = Convert.ToInt32(Request.QueryString["FlightDetailStationId"]);

            int UpdateFlightDetailStation = flightDetailStationManageBll.UpdateFlightDetailStation(RouteId, FlightId, NowStation, VoyageTime, AchieveName, AchieveTime, Price, TripTime, FlightDetailStationId);
            if (UpdateFlightDetailStation == 1)
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "修改成功" + "');</script>");
                this.Panel1.Visible = true;
            }
            else
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "修改失败" + "');</script>");
            }

        }

        protected void btnToFlightDetailStationManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightDetailStationManage.aspx");
        }
    }
}