using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class UserInfoBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 获取登录用户的所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserInfo(int Id)
        {
            string strsql = string.Format(@"select * from [dbo].[UserInfo] where Id ='{0}'", Id);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public string UserLogin(string LoginName, string Password)
        {
            string strsql = string.Format(@"select [LoginName],[Password] from [dbo].[UserInfo] where [LoginName]='{0}' and [Password]='{1}'", LoginName, Password);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 用用户登录名获取用户ID
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public string GetUserIdByLoginName(string LoginName)
        {
            string strsql = string.Format(@"select [Id] from [dbo].[UserInfo] where [LoginName]='{0}'", LoginName);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 取到所有的用户类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserType()
        {
            string strsql = string.Format(@"select * from [dbo].[UserType]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 取到所有的问题类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllQuestionType()
        {
            string strsql = string.Format(@"select * from [dbo].[QuestionType]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //注册用户
        public int AddUserInfo(int UserTypeId, string UserName, string LoginName, string Password, string IdentityNum, string Sex, string Birthday, int Age, string Telphone, string Email, int QuestionTypeId, string Answer)
        {
            string strsql = string.Format(@"insert into [dbo].[UserInfo]([UserTypeId],[UserName],[LoginName],[Password],[IdentityNum],[Sex],[Birthday],[Age],[Telphone],[Email],[QuestionTypeId],[Answer]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", UserTypeId, UserName, LoginName, Password, IdentityNum, Sex, Birthday, Age, Telphone, Email, QuestionTypeId, Answer);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //检查登录名是否被注册过
        public string IsLoginNameExsit(string LoginName)
        {
            string strsql = string.Format(@" select [LoginName] from [dbo].[UserInfo] where [LoginName]='{0}'", LoginName);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }




    }
}