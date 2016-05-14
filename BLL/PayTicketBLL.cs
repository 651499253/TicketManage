using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class PayTicketBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 根据订单信息查出订单信息
        /// </summary>
        /// <param name="TicketOrderNum"></param>
        /// <returns></returns>
        public DataTable GetOrderTicketInfo(string TicketOrderNum)
        {
            string strsql = string.Format(@"select * from 
(select tick.AchieveName,tick.AchieveTime,tick.BaggageId,tick.FlightDate,tick.FlightName,tick.NowStation,tick.PayState,tick.SeatTypeName,tick.ShipTypName,tick.TicketOrderId,tick.TicketPrice,tick.TripTime,tick.VoyageTime,pass.PassengerId,pass.PassengerName,pass.UserTypeId   from [dbo].[TicketOrder] tick ,[dbo].[Passenger] pass
 where [TicketOrderNum]='{0}' and tick.PassengerId=pass.PassengerId )T1
 left join [dbo].[UserType] userty
 on T1.UserTypeId=userty.UserTypeId", TicketOrderNum);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //支付后更新支付状态
        public int UpdateTicketOrder(string TicketOrderNum)
        {
            string strsql = string.Format(@"update [dbo].[TicketOrder] set [PayState]='1' where [TicketOrderNum]='{0}'", TicketOrderNum);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }

        /// <summary>
        /// 根据订单号获取该单号的全部信息
        /// </summary>
        /// <param name="TicketOrderNum"></param>
        /// <returns></returns>
        public DataTable GetOrderTicketByOrderNum(string TicketOrderNum)
        {
            string strsql = string.Format(@" select * from [dbo].[TicketOrder] where [TicketOrderNum]='{0}'", TicketOrderNum);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //根据航班名称找出航班ID
        public string GetFlightId(string FlightName)
        {
            string strsql = string.Format(@"select [FlightId] from [dbo].[Flight] where [FlightName]='{0}'", FlightName);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        //减少相应的日期的一等座座位类型的票数
        public int UpdateFlightAndDateLevelOneSeat(int FlightId, string FlightDate)
        {
            string strsql = string.Format(@" update [dbo].[FlightAndDate]  set [LevelOneSeatNum]-=1 where [FlightId]='{0}' and [FlightDate]='{1}'",FlightId,FlightDate);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //减少相应的日期的二等座座位类型的票数
        public int UpdateFlightAndDateLevelTwoSeat(int FlightId, string FlightDate)
        {
            string strsql = string.Format(@"update [dbo].[FlightAndDate]  set [LevelTwoSeatNum]-=1 where [FlightId]='{0}' and [FlightDate]='{1}'", FlightId, FlightDate);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //减少相应的日期的无座座位类型的票数
        public int UpdateFlightAndDateLevelNoSeat(int FlightId, string FlightDate)
        {
            string strsql = string.Format(@"update [dbo].[FlightAndDate]  set [LevelNoSeatNum]-=1 where [FlightId]='{0}' and [FlightDate]='{1}'", FlightId, FlightDate);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

       





    }
}