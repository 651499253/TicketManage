using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class AdminLoginBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string Adminlogin(string LoginName, string Password)
        {
            string strsql = string.Format(@" select * from [dbo].[UserInfo] where [LoginName]='{0}' and [Password]='{1}'", LoginName, Password);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();

        }
    }
}