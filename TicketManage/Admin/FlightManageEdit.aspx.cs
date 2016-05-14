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
    public partial class FlightManageEdit : System.Web.UI.Page
    {
        private FlightManageBLL flightManageBll = new FlightManageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLRoute();
                BindDDLShipType();
                this.Panel1.Visible = false;
                int FlightId = Convert.ToInt32(Request.QueryString["FlightId"]);
                if (FlightId == 0)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                DataTable dtFlight = flightManageBll.GetAllFlightByFlightId(FlightId);
                this.txtFlightName.Text = dtFlight.Rows[0]["FlightName"].ToString();
                this.txtVoyageTime.Text = dtFlight.Rows[0]["VoyageTime"].ToString();
                this.txtAchieveTime.Text = dtFlight.Rows[0]["AchieveTime"].ToString();
                this.txtTripTime.Text = dtFlight.Rows[0]["TripTime"].ToString();

            }
        }

        //把航线绑定到下拉框
        private void BindDDLRoute()
        {
            DataTable AllRoutes = flightManageBll.GetAllRoutes();
            this.DDLRoute.DataSource = AllRoutes;
            this.DDLRoute.DataTextField = "RouteName"; //实际显示的值
            this.DDLRoute.DataValueField = "RouteId";//用来取值的
            this.DDLRoute.DataBind();
        }

        //把船舶类型绑定到下拉框
        private void BindDDLShipType()
        {
            DataTable AllShipType = flightManageBll.GetAllShipType();
            this.DDLShipType.DataSource = AllShipType;
            this.DDLShipType.DataTextField = "ShipTypeName"; //实际显示的值
            this.DDLShipType.DataValueField = "ShipTypeId";//用来取值的
            this.DDLShipType.DataBind();
        }

        protected void btnEditFlight_Click(object sender, EventArgs e)
        {
            int RouteId = Convert.ToInt32(DDLRoute.SelectedValue);
            int ShipTypeId = Convert.ToInt32(DDLShipType.SelectedValue);
            string FlightName = this.txtFlightName.Text;
            string VoyageTime = this.txtVoyageTime.Text;
            string AchieveTime = this.txtAchieveTime.Text;
            string TripTime = this.txtTripTime.Text;
            int FlightId = Convert.ToInt32(Request.QueryString["FlightId"]);

            int updateResult = flightManageBll.UpdateFlight(FlightName, RouteId, VoyageTime, AchieveTime, TripTime, ShipTypeId, FlightId);
            if (updateResult == 1)
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "修改成功" + "');</script>");
                this.Panel1.Visible = true;
            }
            else
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "修改失败" + "');</script>");
            }

        }

        protected void btnToFlight_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightManage.aspx");
        }
    }
}