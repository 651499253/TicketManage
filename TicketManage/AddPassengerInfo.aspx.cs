using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage
{
    public partial class AddPassengerInfo : System.Web.UI.Page
    {
        TicketCreateOrderBLL tickCreateBll = new TicketCreateOrderBLL();
        AddPassengerInfoBLL addPassengetInfoBll = new AddPassengerInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    //把原有的乘客加载出来。
                    int UserId = int.Parse(Session["UserId"].ToString());
                    DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
                    this.Repeater1.DataSource = dtPassenger;
                    this.Repeater1.DataBind();

                    DataTable dtUserType = addPassengetInfoBll.GetAllUserType();
                    this.DDLUserType.DataSource = dtUserType;
                    this.DDLUserType.DataTextField = "UserTypeContent"; //实际显示的值
                    this.DDLUserType.DataValueField = "UserTypeId";//用来取值的
                    this.DDLUserType.DataBind();

                    int PassengerId = Convert.ToInt32(Request.QueryString["PassengerId"]);
                    if (PassengerId != 0)
                    {
                        DataTable dtPassengerOne = addPassengetInfoBll.GetPassengerIdById(PassengerId);
                        this.txtPassengerName.Text = dtPassengerOne.Rows[0]["PassengerName"].ToString();
                        this.txtIdentityNum.Text = dtPassengerOne.Rows[0]["IdentityNum"].ToString();
                        this.txtTelphone.Text = dtPassengerOne.Rows[0]["Telphone"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                }
            }
        }

        //repeater控件里的删除按钮
        protected void OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int PassengerId = Convert.ToInt32(btn.CommandArgument);
            tickCreateBll.DeletePassenger(PassengerId);
            Response.Write("<Script Language='JavaScript'>window.alert('" + "删除成功" + "');</script>");
            int UserId = int.Parse(Session["UserId"].ToString());
            DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
            this.Repeater1.DataSource = dtPassenger;
            this.Repeater1.DataBind();
        }

        protected void btnReturnUrl_Click(object sender, EventArgs e)
        {
            int FlightDetailStationId = int.Parse(Session["FlightDetailStationId"].ToString());
            string NowStation = Session["NowStation"].ToString();
            string AchieveName = Session["AchieveName"].ToString();
            string FlightDate = Session["FlightDate"].ToString();
            string ShipTypeName = Session["ShipTypeName"].ToString();

            Response.Redirect("TicketCreateOrder.aspx?FlightDetailStationId=" + FlightDetailStationId + "&NowStation=" + NowStation + "&AchieveName=" + AchieveName + "&FlightDate=" + FlightDate + "&ShipTypeName=" + ShipTypeName);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
            }
            else
            {
                int UserId = Convert.ToInt32(Session["UserId"].ToString());
                string PassengerName = this.txtPassengerName.Text;
                string IdentityNum = this.txtIdentityNum.Text;
                string txtTelphone = this.txtTelphone.Text;
                int UserTypeId = Convert.ToInt32(DDLUserType.SelectedValue);

                int PassengerId = Convert.ToInt32(Request.QueryString["PassengerId"]);
                //如果地址栏取不到的话，那就是新增加
                if (PassengerId == 0)
                {
                    int addResult = addPassengetInfoBll.AddPassenger(PassengerName, UserTypeId, IdentityNum, txtTelphone, UserId);
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "添加成功" + "');</script>");
                    DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
                    this.Repeater1.DataSource = dtPassenger;
                    this.Repeater1.DataBind();

                }
                else  //否则做修改操作
                {
                    int UpdateResult = addPassengetInfoBll.UpdatePassenger(PassengerName, UserTypeId, IdentityNum, txtTelphone, UserId, PassengerId);
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "修改成功" + "');</script>");
                    DataTable dtPassenger = tickCreateBll.GetAllPassenger(UserId);
                    this.Repeater1.DataSource = dtPassenger;
                    this.Repeater1.DataBind();
                }
            }

        }
    }
}