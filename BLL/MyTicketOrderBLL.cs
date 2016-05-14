using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class MyTicketOrderBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 根据用户id查出当天之后的所有船票
        /// </summary>
        /// <param name="FlightDate"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetUserAllOrderTicketInfo(string FlightDate, int UserId)
        {
            string strsql = string.Format(@" select * from 
(select tick.AchieveName,tick.TicketOrderNum,tick.TicketState,tick.AchieveTime,tick.BaggageId,tick.FlightDate,tick.FlightName,tick.NowStation,tick.PayState,tick.SeatTypeName,tick.ShipTypName,tick.TicketOrderId,tick.TicketPrice,tick.TripTime,tick.VoyageTime,pass.PassengerId,pass.PassengerName,pass.UserTypeId   from [dbo].[TicketOrder] tick ,[dbo].[Passenger] pass
 where [FlightDate] > '{0}' and tick.[UserId]='{1}' and [TicketState]=0 and tick.PassengerId=pass.PassengerId )T1
 left join [dbo].[UserType] userty
 on T1.UserTypeId=userty.UserTypeId", FlightDate, UserId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 退票，更新票的状态
        /// </summary>
        /// <param name="TicketOrderNum"></param>
        /// <returns></returns>
        public int UpdateTicketState(int TicketOrderId)
        {
            string strsql = string.Format(@"update [dbo].[TicketOrder] set [TicketState]='1' where [TicketOrderId]='{0}'", TicketOrderId);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }

        //添加退票信息到退票表
        public int AddCancleTicket(int UserId, string CancTicketNum, string TicketOrderNum, string CancleFee, string RemainFee, string CancleDate)
        {
            string strsql = string.Format(@"insert into [dbo].[CancleTicket]([UserId],[CancTicketNum],[TicketOrderNum],[CancleFee],[RemainFee],[CancleDate]) values('{0}','{1}','{2}','{3}','{4}','{5}')", UserId, CancTicketNum, TicketOrderNum, CancleFee, RemainFee, CancleDate);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }
    }
}