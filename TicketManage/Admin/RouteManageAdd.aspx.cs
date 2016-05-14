using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage.Admin
{
    public partial class RouteManageAdd : System.Web.UI.Page
    {
        private RouteManageBLL routeManageBll = new RouteManageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;

        }

        protected void btnAddRoute_Click(object sender, EventArgs e)
        {
            string RouteName = this.txtRouteName.Text;
            string StartStation = this.txtStartStation.Text;
            string AchieveStation = this.txtAchieveStation.Text;
            string EarliestTrip = this.txtEarliestTrip.Text;
            string LastedTrip = this.txtLastedTrip.Text;
            string FullTime = this.txtFullTime.Text;
            int StationNum = Convert.ToInt32(this.txtStationNum.Text);
            int addResult = routeManageBll.AddRoute(RouteName, StartStation, AchieveStation, EarliestTrip, LastedTrip, FullTime, StationNum);
            if(addResult==1)
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

        protected void btnToRouteManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouteManage.aspx");
        }
    }
}