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
    public partial class FlightManage : System.Web.UI.Page
    {
        private FlightManageBLL flightManageBll = new FlightManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable AllFlights = flightManageBll.GetAllFlights();
                this.LVFlightList.DataSource = AllFlights;
                this.LVFlightList.DataBind();
            }

        }

        //编辑和删除事件
        protected void LVFlightList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //编辑操作
            if (String.Equals(e.CommandName, "EditFlight"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int FlightId = int.Parse(LVFlightList.DataKeys[dataItem.DisplayIndex].Value.ToString());

                Response.Redirect("FlightManageEdit.aspx?FlightId=" + FlightId);
            }

            //删除操作
            if (String.Equals(e.CommandName, "DeleteFlight"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int FlightId = int.Parse(LVFlightList.DataKeys[dataItem.DisplayIndex].Value.ToString());
                int deleteRoute = flightManageBll.DeleteFlight(FlightId);
                if (deleteRoute == 1)
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
                    DataTable AllFlights = flightManageBll.GetAllFlights();
                    this.LVFlightList.DataSource = AllFlights;
                    this.LVFlightList.DataBind();
                }
                else
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除失败" + "');</script>");
                    DataTable AllFlights = flightManageBll.GetAllFlights();
                    this.LVFlightList.DataSource = AllFlights;
                    this.LVFlightList.DataBind();
                }
            }
        }

        protected void btnAddNewFlight_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightManageAdd.aspx");
        }



    }
}