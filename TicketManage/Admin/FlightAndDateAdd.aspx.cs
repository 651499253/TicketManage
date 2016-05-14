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
    public partial class FlightAndDateAdd : System.Web.UI.Page
    {
        private FlightAndDateBLL flightAndDateBll = new FlightAndDateBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLFlightName();
            }

        }

        //把航线绑定到下拉框
        private void BindDDLFlightName()
        {
            DataTable AllFlightNames = flightAndDateBll.GetAllFlighs();
            this.DDLFlightName.DataSource = AllFlightNames;
            this.DDLFlightName.DataTextField = "FlightName"; //实际显示的值
            this.DDLFlightName.DataValueField = "FlightId";//用来取值的
            this.DDLFlightName.DataBind();
        }

        //添加
        protected void btnAddFlightAndDate_Click(object sender, EventArgs e)
        {
            int FlightId = Convert.ToInt32(this.DDLFlightName.SelectedValue);
            string FlightDate = this.txtFlightDate.Text;
            int LevelOneSeatNum = Convert.ToInt32(this.txtLevelOneSeatNum.Text);
            int LevelTwoSeatNum = Convert.ToInt32(this.txtLevelTwoSeatNum.Text);
            int LevelNoSeatNum = Convert.ToInt32(this.txtLevelNoSeatNum.Text);

            int addResult = flightAndDateBll.AddFlightAndDate(FlightId, FlightDate, LevelOneSeatNum, LevelTwoSeatNum, LevelNoSeatNum);
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

        protected void btnToFlightAndDate_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlightAndDate.aspx");
        }
    }
}