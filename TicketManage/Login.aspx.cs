using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage
{
    public partial class Login : System.Web.UI.Page
    {
        UserInfoBLL userInfoBll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
            //this.LbLoginName.Visible = false;
            //this.LbPassword.Visible = false;
            //this.lbTip.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (this.txtLoginName.Text == "")
            //{
            //    this.LbLoginName.Visible = true;
            //    return;
            //}
            //if (this.txtPassword.Text == "")
            //{
            //    this.LbPassword.Visible = true;
            //    return;
            //}

            string LoginName = this.txtLoginName.Text;
            string Password = this.txtPassword.Text;
            string result = userInfoBll.UserLogin(LoginName, Password);
            if (!string.IsNullOrEmpty(result))
            {
                int UserId = Convert.ToInt32(userInfoBll.GetUserIdByLoginName(LoginName));
                Session["UserId"] = UserId;
                if (string.IsNullOrEmpty(Request.QueryString["url"]))
                {
                    Response.Redirect("Index.aspx");//跳转页面                    
                }
                else
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
            }
            else
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "账号或者密码出错，请重新输入" + "');</script>");
                //this.lbTip.Visible = true;
                //this.lbTip.Text = "";
            }

        }

        //protected void btnLogin_Click1(object sender, EventArgs e)
        //{

        //}
    }
}