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
    public partial class RouteManageEdit : System.Web.UI.Page
    {
        private RouteManageBLL routeManageBll = new RouteManageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Panel1.Visible = false;
                int RouteId = Convert.ToInt32(Request.QueryString["RouteId"]);
                if (RouteId == 0)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                DataTable dtRoute = routeManageBll.GetRouteByRouteId(RouteId);
                this.txtRouteName.Text = dtRoute.Rows[0]["RouteName"].ToString();
                this.txtStartStation.Text = dtRoute.Rows[0]["StartStation"].ToString();
                this.txtAchieveStation.Text = dtRoute.Rows[0]["AchieveStation"].ToString();
                this.txtEarliestTrip.Text = dtRoute.Rows[0]["EarliestTrip"].ToString();
                this.txtLastedTrip.Text = dtRoute.Rows[0]["LastedTrip"].ToString();
                this.txtFullTime.Text = dtRoute.Rows[0]["FullTime"].ToString();
                this.txtStationNum.Text = dtRoute.Rows[0]["StationNum"].ToString();
            }
        }

        protected void btnEditRoute_Click(object sender, EventArgs e)
        {
            int RouteId = Convert.ToInt32(Request.QueryString["RouteId"]);
            string RouteName = this.txtRouteName.Text;
            string StartStation = this.txtStartStation.Text;
            string AchieveStation = this.txtAchieveStation.Text;
            string EarliestTrip = this.txtEarliestTrip.Text;
            string LastedTrip = this.txtLastedTrip.Text;
            string FullTime = this.txtFullTime.Text;
            int StationNum = Convert.ToInt32(this.txtStationNum.Text);

            int updateResult = routeManageBll.UpdateRoute(RouteName, StartStation, AchieveStation, EarliestTrip, LastedTrip, FullTime, StationNum, RouteId);
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

        protected void btnToRouteManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouteManage.aspx");
        }
    }
}