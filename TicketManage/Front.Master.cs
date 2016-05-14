using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
namespace TicketManage
{
    public partial class Front : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoBLL userInfoBll = new UserInfoBLL();

            if (!this.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    int UserId = int.Parse(Session["UserId"].ToString());
                    DataTable dt = userInfoBll.GetUserInfo(UserId);
                    UserName = dt.Rows[0]["UserName"].ToString();
                }
                //else
                //{
                //    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                //}
            }
            else
            {
                if (Session["UserId"] != null)
                {
                    int UserId2 = int.Parse(Session["UserId"].ToString());
                    DataTable dt2 = userInfoBll.GetUserInfo(UserId2);
                    UserName = dt2.Rows[0]["UserName"].ToString();
                }
                //else
                //{
                //    Response.Redirect("Login.aspx?url=" + Request.Url.ToString());
                //}
            }


        }

        public string UserName
        {
            get;
            set;
        }
    }
}