using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace TicketManage.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private AdminLoginBLL adminLoginBll = new AdminLoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelTip.Visible = false;
            if (!IsPostBack)
            {
                this.LabelTip.Visible = false;
            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string LoginName = this.txtLoginName.Text;
            string Password = this.txtPassword.Text;
            if (LoginName == "sa")
            {
                string result = adminLoginBll.Adminlogin(LoginName,Password);
                if(string.IsNullOrEmpty(result))
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "账号或者密码出错，请重新输入" + "');</script>");
                    return;
                }
                else
                {
                    Session["adminRoot"] = "sa";
                    Response.Redirect("AdminIndex.aspx");
                }
            }
            if (LoginName == "admin")
            {
                string result = adminLoginBll.Adminlogin(LoginName, Password);
                if (string.IsNullOrEmpty(result))
                {
                    Response.Write("<Script Language='JavaScript'>window.alert('" + "账号或者密码出错，请重新输入" + "');</script>");
                    return;
                }
                else
                {
                    Session["adminRoot"] = "admin";
                    Response.Redirect("AdminIndex.aspx");
                }
            }
            else
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "您无权访问该系统后台，请与管理员联系" + "');</script>");
                return;
            }

        }

    }
}