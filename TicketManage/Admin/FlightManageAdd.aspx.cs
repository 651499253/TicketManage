using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage.Admin
{
    public partial class FlightManageAdd : System.Web.UI.Page
    {
        private FlightManageBLL flightManageBll = new FlightManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLRoute();
                BindDDLShipType();
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

        //添加航班
        protected void btnAddFlight_Click(object sender, EventArgs e)
        {
            int RouteId =Convert.ToInt32(DDLRoute.SelectedValue);
            int ShipTypeId = Convert.ToInt32(DDLShipType.SelectedValue);
            string FlightName = this.txtFlightName.Text;
            string VoyageTime = this.txtVoyageTime.Text;
            string AchieveTime = this.txtAchieveTime.Text;
            string TripTime = this.txtTripTime.Text;

            int addResult = flightManageBll.AddFlight(FlightName, RouteId, VoyageTime, AchieveTime, TripTime, ShipTypeId);
            if (addResult == 1)
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

        protected void btnToFlight_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightManage.aspx");
        }
    }
}