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
    public partial class FlightAndDateEdit : System.Web.UI.Page
    {
        private FlightAndDateBLL flightAndDateBll = new FlightAndDateBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDDLFlightName();
                int TableId = Convert.ToInt32(Request.QueryString["TableId"]);
                DataTable dtFlightAndDate = flightAndDateBll.GetFlightAndDateById(TableId);
                this.DDLFlightName.SelectedValue = dtFlightAndDate.Rows[0]["FlightId"].ToString();
                this.txtFlightDate.Text = dtFlightAndDate.Rows[0]["FlightDate"].ToString();
                this.txtLevelOneSeatNum.Text = dtFlightAndDate.Rows[0]["LevelOneSeatNum"].ToString();
                this.txtLevelTwoSeatNum.Text = dtFlightAndDate.Rows[0]["LevelTwoSeatNum"].ToString();
                this.txtLevelNoSeatNum.Text = dtFlightAndDate.Rows[0]["LevelNoSeatNum"].ToString();
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



        protected void btnToFlightAndDate_Click1(object sender, EventArgs e)
        {
            Response.Redirect("FlightAndDate.aspx");
        }

        //修改
        protected void btnEditFlightAndDate_Click(object sender, EventArgs e)
        {
            int FlightId = Convert.ToInt32(this.DDLFlightName.SelectedValue);
            string FlightDate = this.txtFlightDate.Text;
            int LevelOneSeatNum = Convert.ToInt32(this.txtLevelOneSeatNum.Text);
            int LevelTwoSeatNum = Convert.ToInt32(this.txtLevelTwoSeatNum.Text);
            int LevelNoSeatNum = Convert.ToInt32(this.txtLevelNoSeatNum.Text);
            int TableId = Convert.ToInt32(Request.QueryString["TableId"]);
            int updateResult = flightAndDateBll.UpdateFlightAndDate(FlightId, FlightDate, LevelOneSeatNum, LevelTwoSeatNum, LevelNoSeatNum, TableId);
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
    }
}