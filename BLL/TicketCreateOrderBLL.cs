using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class TicketCreateOrderBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        public DataTable GetCheckedTicket(string NowStation, string AchieveName, string FlightDate, int FlightDetailStationId)
        {
            string strsql = string.Format(@"select * from 
(select detailflig.FlightDetailStationId,detailflig.RouteId,detailflig.FlightId,detailflig.NowStation,
detailflig.VoyageTime,detailflig.AchieveName,detailflig.AchieveTime,detailflig.Price,detailflig.TripTime,
detailflig.FlightDate,detailflig.LevelOneSeatNum,detailflig.LevelTwoSeatNum,detailflig.LevelNoSeatNum, 
detailship.FlightName,detailship.ShipTypeId,detailship.ShipTypeName from 
(select T1.FlightDetailStationId,T1.RouteId,T1.FlightId,T1.NowStation,T1.VoyageTime,T1.AchieveName,
T1.AchieveTime,T1.Price,T1.TripTime, T2.FlightDate,T2.LevelOneSeatNum,T2.LevelTwoSeatNum,T2.LevelNoSeatNum from 
(select * from [dbo].[FlightDetailStation] where [NowStation]='{0}' and [AchieveName]='{1}')T1
left join 
(select * from 
(select * from [dbo].[FlightAndDate] where [FlightDate]='{2}')t  
 where t.[LevelOneSeatNum]>0 or [LevelTwoSeatNum]>0 or [LevelNoSeatNum]>0)T2
 on T1.FlightId=T2.FlightId)detailflig 
 left join

(select flig.FlightId, flig.FlightName,flig.RouteId,shiptype.ShipTypeId,shiptype.ShipTypeName from 
(select * from [dbo].[Flight]) flig  
left join 
(select * from [dbo].[ShipType])shiptype
on flig.ShipTypeId=shiptype.ShipTypeId)detailship
on detailflig.FlightId=detailship.FlightId) shipselect
where shipselect.FlightDetailStationId='{3}'
", NowStation, AchieveName, FlightDate, FlightDetailStationId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 取得所有的乘客
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetAllPassenger(int UserId)
        {
            string strsql = string.Format(@"select [PassengerId],[PassengerName],[IdentityNum],[Telphone],[UserId],pa.[UserTypeId],[UserTypeContent],[UserTypeDiscount] from [dbo].[Passenger] pa
                left join [dbo].[UserType] UT
                on pa.UserTypeId=UT.UserTypeId
                where [UserId]='{0}'", UserId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }
        /// <summary>
        /// 查找所有行李重量
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBaggageWeight()
        {
            string strsql = string.Format(@"select * from [dbo].[BaggageWeightType]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }


        //删除乘客
        public string DeletePassenger(int PassengerId)
        {
            string strsql = string.Format(@"delete from [dbo].[Passenger] where [PassengerId]='{0}'", PassengerId);
            string result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql).ToString();
            return result;
        }

        //根据行李重量ID，查询该条重量类型全部信息
        public DataTable GetAllBaggageWeightById(int BaggageWeightTypeId)
        {
            string strsql = string.Format(@"select * from [dbo].[BaggageWeightType] where [BaggageWeightTypeId]='{0}'", BaggageWeightTypeId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 添加行李到行李表
        /// </summary>
        /// <param name="PassengerId"></param>
        /// <param name="BaggageWeightTypeId"></param>
        /// <param name="CheckTime"></param>
        /// <returns></returns>
        public int AddBaggage(string BaggageNum, int PassengerId, int BaggageWeightTypeId, string CheckTime)
        {
            string strsql = string.Format(@"insert into [dbo].[Baggage]([BaggageNum],[PassengerId],[BaggageWeightTypeId],[CheckTime]) values('{0}','{1}','{2}','{3}')", BaggageNum, PassengerId, BaggageWeightTypeId, CheckTime);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }

        //得到行李ID
        public string GetBaggageId(string BaggageNum)
        {
            string strsql = string.Format(@"select [BaggageId] from [dbo].[Baggage] where [BaggageNum]='{0}'", BaggageNum);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }


        /// <summary>
        /// 根据座位名字查找座位倍数
        /// </summary>
        /// <param name="SeatTypeName"></param>
        /// <returns></returns>
        public string GetSeatTypePriceMultiple(string SeatTypeName)
        {
            string strsql = string.Format(@" select [PriceMultiple] from [dbo].[SeatType] where [SeatTypeName]='{0}'", SeatTypeName);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 根据船舶类型找倍数
        /// </summary>
        /// <param name="ShipTypeName"></param>
        /// <returns></returns>
        public string GetShipTypeNamePriceMultiple(string ShipTypeName)
        {
            string strsql = string.Format(@"select [PriceMultiple] from [dbo].[ShipType] where [ShipTypeName]='{0}'", ShipTypeName);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 找出用户类型折扣
        /// </summary>
        /// <param name="PassengerId"></param>
        /// <returns></returns>
        public string GetUserTypeDiscount(int PassengerId)
        {
            string strsql = string.Format(@"select [UserTypeDiscount] from [dbo].[UserType] where [UserTypeId] =
            (select [UserTypeId] from [dbo].[Passenger] where [PassengerId]='{0}')", PassengerId);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        //生成订单
        public int CreateTicket(string TicketOrderNum, string SeatTypeName, string ShipTypName, string OrderTime, int UserId, int PassengerId, string TicketPrice, string FlightName, int BaggageId, string FlightDate, string NowStation, string VoyageTime, string AchieveName, string AchieveTime, string TripTime)
        {
            string strsql = string.Format(@"insert into [dbo].[TicketOrder]([TicketOrderNum],[SeatTypeName],[ShipTypName],[OrderTime],[UserId],[PassengerId],[TicketPrice],[FlightName],BaggageId,FlightDate,NowStation,VoyageTime,AchieveName,AchieveTime,TripTime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", TicketOrderNum, SeatTypeName, ShipTypName, OrderTime, UserId, PassengerId, TicketPrice, FlightName, BaggageId, FlightDate, NowStation, VoyageTime, AchieveName, AchieveTime, TripTime);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }












    }
}