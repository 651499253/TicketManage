using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TicketManage
{
    public partial class Register : System.Web.UI.Page
    {
        private UserInfoBLL userInfoBll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            if (!this.IsPostBack)
            {
                BindDDLUserType();
                BindDDLQuestionType();
                this.Panel1.Visible = false;
            }
        }


        //绑定用户类型下拉框
        private void BindDDLUserType()
        {
            object AllUserType = userInfoBll.GetAllUserType();
            this.DDLUserType.DataSource = AllUserType;
            this.DDLUserType.DataTextField = "UserTypeContent";//实际显示的值
            this.DDLUserType.DataValueField = "UserTypeId";//用来取值的
            this.DDLUserType.DataBind();
        }

        //绑定问题类型下拉框
        private void BindDDLQuestionType()
        {
            object AllQuestionType = userInfoBll.GetAllQuestionType();
            this.DDLQuestionType.DataSource = AllQuestionType;
            this.DDLQuestionType.DataTextField = "QuestionContent";//实际显示的值
            this.DDLQuestionType.DataValueField = "QuestionTypeId";//用来取值的
            this.DDLQuestionType.DataBind();
        }


        //注册按钮
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int UserTypeId = Convert.ToInt32(this.DDLUserType.SelectedValue);//用户类型ID
            string UserName = this.txtUserName.Text;
            string LoginName = this.txtLoginName.Text;
            if (userInfoBll.IsLoginNameExsit(LoginName) == LoginName)
            {
                Response.Write("<Script Language='JavaScript'>window.alert('" + "该登录名已被注册过" + "');</script>");
                return;
            }
            string Password = this.txtPassword.Text;
            string IdentityNum = this.txtIdentityNum.Text;
            string Sex = "";

            if (this.RadioButton1.Checked)
            {
                Sex = "男";
            }
            else
            {
                Sex = "女";
            }

            string Birthday = this.txtBirthday.Text;
            int Age = Convert.ToInt32(this.txtAge.Text);
            string Telphone = this.txtTelphone.Text;
            string Email = this.txtEmail.Text;
            int QuestionTypeId = Convert.ToInt32(this.DDLQuestionType.SelectedValue);
            string Answer = this.txtAnswer.Text;
            //注册
            int RegisterResult = userInfoBll.AddUserInfo(UserTypeId, UserName, LoginName, Password, IdentityNum, Sex, Birthday, Age, Telphone, Email, QuestionTypeId, Answer);
            Response.Write("<Script Language='JavaScript'>window.alert('" + "注册成功" + "');</script>");
            this.Panel1.Visible = true;
        }

        protected void btnToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}