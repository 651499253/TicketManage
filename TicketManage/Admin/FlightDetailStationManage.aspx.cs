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
    public partial class FlightDetailStationManage : System.Web.UI.Page
    {
        private FlightDetailStationManageBLL flightDetailStationManageBll = new FlightDetailStationManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable AllFlightDetailStations = flightDetailStationManageBll.GetAllFlightDetailStations();
                this.LVFlightDetailStationList.DataSource = AllFlightDetailStations;
                this.LVFlightDetailStationList.DataBind();
            }
        }

        //编辑和删除
        protected void LVFlightDetailStationList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //编辑操作
            if (String.Equals(e.CommandName, "EditFlightDetailStation"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int FlightDetailStationId = int.Parse(LVFlightDetailStationList.DataKeys[dataItem.DisplayIndex].Value.ToString());

                Response.Redirect("FlightDetailStationManageEdit.aspx?FlightDetailStationId=" + FlightDetailStationId);
            }

            //删除操作
            if (String.Equals(e.CommandName, "DeleteFlightDetailStation"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int FlightDetailStationId = int.Parse(LVFlightDetailStationList.DataKeys[dataItem.DisplayIndex].Value.ToString());
                int deleteFlightDetailStation = flightDetailStationManageBll.DeleteFlightDetailStation(FlightDetailStationId);
                if (deleteFlightDetailStation == 1)
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
                    DataTable AllFlightDetailStations = flightDetailStationManageBll.GetAllFlightDetailStations();
                    this.LVFlightDetailStationList.DataSource = AllFlightDetailStations;
                    this.LVFlightDetailStationList.DataBind();
                }
                else
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除失败" + "');</script>");
                    DataTable AllFlightDetailStations = flightDetailStationManageBll.GetAllFlightDetailStations();
                    this.LVFlightDetailStationList.DataSource = AllFlightDetailStations;
                    this.LVFlightDetailStationList.DataBind();
                }
            }
        }

        protected void btnAddNewFlightDetailStation_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightDetailStationManageAdd.aspx");
        }
    }
}