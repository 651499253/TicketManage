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
    public partial class FlightAndDate : System.Web.UI.Page
    {
        private FlightAndDateBLL flightAndDateBll = new FlightAndDateBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)   
            {
                string YesterdayDate = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                DataTable AllFlightAndDates = flightAndDateBll.GetAllFlightAndDates(YesterdayDate);
                this.LVFlightAndDateList.DataSource = AllFlightAndDates;
                this.LVFlightAndDateList.DataBind();
            }

        }


        //编辑和删除
        protected void LVFlightAndDateList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //编辑操作
            if (String.Equals(e.CommandName, "EditFlightAndDate"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int TableId = int.Parse(LVFlightAndDateList.DataKeys[dataItem.DisplayIndex].Value.ToString());

                Response.Redirect("FlightAndDateEdit.aspx?TableId=" + TableId);
            }

            //删除操作
            if (String.Equals(e.CommandName, "DeleteFlightAndDate"))
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int TableId = int.Parse(LVFlightAndDateList.DataKeys[dataItem.DisplayIndex].Value.ToString());
                int DeleteFlightAndDate = flightAndDateBll.DeleteFlightAndDate(TableId);
                if (DeleteFlightAndDate == 1)
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
                    string YesterdayDate = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    DataTable AllFlightAndDates = flightAndDateBll.GetAllFlightAndDates(YesterdayDate);
                    this.LVFlightAndDateList.DataSource = AllFlightAndDates;
                    this.LVFlightAndDateList.DataBind();
                }
                else
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "删除失败" + "');</script>");
                    string YesterdayDate = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    DataTable AllFlightAndDates = flightAndDateBll.GetAllFlightAndDates(YesterdayDate);
                    this.LVFlightAndDateList.DataSource = AllFlightAndDates;
                    this.LVFlightAndDateList.DataBind();
                }
            }
        }

        //添加新的日程安排
        protected void btnAddNewFlightAndDate_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightAndDateAdd.aspx");
        }
    }
}