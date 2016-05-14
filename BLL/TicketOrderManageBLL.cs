using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;


namespace BLL
{
    public class TicketOrderManageBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();


        /// <summary>
        /// 获得所有的船票订单
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTicketOrder()
        {
            string strsql = string.Format(@"  select * from 
(select tick.AchieveName,tick.TicketOrderNum,tick.TicketState,tick.AchieveTime,tick.BaggageId,tick.FlightDate,tick.FlightName,tick.NowStation,tick.PayState,tick.SeatTypeName,tick.ShipTypName,tick.TicketOrderId,tick.TicketPrice,tick.TripTime,tick.VoyageTime,pass.PassengerId,pass.PassengerName,pass.UserTypeId   from [dbo].[TicketOrder] tick ,[dbo].[Passenger] pass
 where  tick.PassengerId=pass.PassengerId )T1
 left join [dbo].[UserType] userty
 on T1.UserTypeId=userty.UserTypeId");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }
    }
}