using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeiXiangLe.AdminPages
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminRoot"] != null)
            {
                if (Session["adminRoot"].ToString() == "sa")
                {
                    this.lbFlightManage.Visible = true;
                    this.lbNewsManage.Visible = true;
                    this.lbRouteManage.Visible = true;
                    this.lbFlightAndDate.Visible = true;
                    this.lbFlightDetailStationManage.Visible = true;
                    this.lbReportManage.Visible = true;
                }
                if (Session["adminRoot"].ToString() == "admin")
                {
                    this.lbFlightManage.Visible = true;
                    this.lbNewsManage.Visible = true;
                    this.lbRouteManage.Visible = true;
                    this.lbFlightAndDate.Visible = true;
                    this.lbFlightDetailStationManage.Visible = true;
                    this.lbReportManage.Visible = false;
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["AdminUserId"] = null;
            Response.Redirect("AdminLogin.aspx");
        }
    }
}