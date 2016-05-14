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
    public partial class RouteManage : System.Web.UI.Page
    {
        private RouteManageBLL routeManageBll = new RouteManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable AllRoutes = routeManageBll.GetAllRoutes();
                this.LVRouteList.DataSource = AllRoutes;
                this.LVRouteList.DataBind();
            }
        }

        //编辑和删除操作
        protected void LVRouteList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //编辑操作
            if (String.Equals(e.CommandName, "EditRoute"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int RouteId = int.Parse(LVRouteList.DataKeys[dataItem.DisplayIndex].Value.ToString());

                Response.Redirect("RouteManageEdit.aspx?RouteId=" + RouteId);
            }

            //删除操作
            if (String.Equals(e.CommandName, "DeleteRoute"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int RouteId = int.Parse(LVRouteList.DataKeys[dataItem.DisplayIndex].Value.ToString());
                int deleteRoute = routeManageBll.DeleteRoute(RouteId);
                if (deleteRoute == 1)
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
                    DataTable AllRoutes = routeManageBll.GetAllRoutes();
                    this.LVRouteList.DataSource = AllRoutes;
                    this.LVRouteList.DataBind();
                }
                else
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除失败" + "');</script>");
                    DataTable AllRoutes = routeManageBll.GetAllRoutes();
                    this.LVRouteList.DataSource = AllRoutes;
                    this.LVRouteList.DataBind();
                }
            }

        }

        //添加新航线
        protected void btnAddNewRoute_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouteManageAdd.aspx");
        }
    }
}