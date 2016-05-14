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
    public partial class TicketOrderManage : System.Web.UI.Page
    {
        private TicketOrderManageBLL ticketOrderManageBll = new TicketOrderManageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dtOrderTicketInfo = ticketOrderManageBll.GetAllTicketOrder();
                this.LVTicketList.DataSource = dtOrderTicketInfo;
                this.LVTicketList.DataBind();

            }

        }

        protected void lvOrderDataPager_PreRender(object sender, EventArgs e)
        {
            DataTable dtOrderTicketInfo = ticketOrderManageBll.GetAllTicketOrder();
            this.LVTicketList.DataSource = dtOrderTicketInfo;
            this.LVTicketList.DataBind();
        }
    }
}