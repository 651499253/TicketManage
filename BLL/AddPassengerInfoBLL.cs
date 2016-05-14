using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class AddPassengerInfoBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        public DataTable GetPassengerIdById(int PassengerId)
        {
            string strsql = string.Format(@"select * from [dbo].[Passenger] where [PassengerId]='{0}'", PassengerId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }


        public DataTable GetAllUserType()
        {
            string strsql = string.Format(@"select * from [dbo].[UserType]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //添加乘客
        public int AddPassenger(string PassengerName, int UserTypeId, string IdentityNum, string Telphone, int UserId)
        {
            string strsql = string.Format(@"insert into [dbo].[Passenger]([PassengerName],[UserTypeId],[IdentityNum],[Telphone],[UserId]) values('{0}','{1}','{2}','{3}','{4}')", PassengerName, UserTypeId, IdentityNum, Telphone, UserId);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }

        //修改乘客
        public int UpdatePassenger(string PassengerName, int UserTypeId, string IdentityNum, string Telphone, int UserId, int PassengerId)
        {
            string strsql = string.Format(@"update [dbo].[Passenger]  set [PassengerName]='{0}',[UserTypeId]='{1}',[IdentityNum]='{2}',[Telphone]='{3}' where [UserId]='{4}' and [PassengerId]='{5}'", PassengerName, UserTypeId, IdentityNum, Telphone, UserId, PassengerId);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }



    }
}