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
    public partial class FlightDetailStationManageAdd : System.Web.UI.Page
    {
        private FlightDetailStationManageBLL flightDetailStationManageBll = new FlightDetailStationManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLRoute();
                BindDDLFlight();
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

        protected void btnToFlightDetailStationManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightDetailStationManage.aspx");
        }

        //添加
        protected void btnAddFlightDetailStation_Click(object sender, EventArgs e)
        {
            int RouteId = Convert.ToInt32(this.DDLRoute.SelectedValue);
            int FlightId = Convert.ToInt32(this.DDLFlight.SelectedValue);
            string NowStation = this.txtNowStation.Text;
            string VoyageTime = this.txtVoyageTime.Text;
            string AchieveName = this.txtAchieveName.Text;
            string AchieveTime = this.txtAchieveTime.Text;
            string Price = this.txtPrice.Text;
            string TripTime = this.txtTripTime.Text;

            int AddFlightDetailStation = flightDetailStationManageBll.AddFlightDetailStation(RouteId, FlightId, NowStation, VoyageTime, AchieveName, AchieveTime, Price, TripTime);
            if (AddFlightDetailStation == 1)
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "添加成功" + "');</script>");
                this.Panel1.Visible = true;
            }
            else
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "添加失败" + "');</script>");
                this.Panel1.Visible = false;
            }

        }

    }
}