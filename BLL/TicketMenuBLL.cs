using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class TicketMenuBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 获取所有的站点
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStations()
        {
            string strsql = string.Format(@"select distinct [StationName] from [dbo].[Station] ");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 获取所有的座位类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSeatTypes()
        {
            string strsql = string.Format(@"select * from [dbo].[SeatType] ");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 获取所有的船舶类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllShipTypes()
        {
            string strsql = string.Format(@"select * from [dbo].[ShipType] ");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 判断选中的某天是否有船票
        /// </summary>
        /// <param name="startData"></param>
        /// <returns></returns>
        public string IsTicketSomeDay(string startData)
        {
            string strsql = string.Format(@"select * from 
                (select * from [dbo].[FlightAndDate] where [FlightDate]='{0}')t  
                where t.[LevelOneSeatNum]>0 or [LevelTwoSeatNum]>0 or [LevelNoSeatNum]>0", startData);
            object obj = sqlhelper.GetFistValue(SqlHelper.connectionString, strsql);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 根据出发地，目的地，时间查询票
        /// </summary>
        /// <param name="StartPlace"></param>
        /// <param name="Destination"></param>
        /// <param name="startData"></param>
        /// <returns></returns>
        public DataTable GetTicketByparm(string StartPlace, string Destination, string startData)
        {
            string strsql = string.Format(@"select detailflig.FlightDetailStationId,detailflig.RouteId,detailflig.FlightId,detailflig.NowStation,detailflig.VoyageTime,detailflig.AchieveName,detailflig.AchieveTime,detailflig.Price,detailflig.TripTime,detailflig.FlightDate,detailflig.LevelOneSeatNum,detailflig.LevelTwoSeatNum,detailflig.LevelNoSeatNum, detailship.FlightName,detailship.ShipTypeId,detailship.ShipTypeName from 
               (select T1.FlightDetailStationId,T1.RouteId,T1.FlightId,T1.NowStation,T1.VoyageTime,T1.AchieveName,T1.AchieveTime,T1.Price,T1.TripTime,T2.FlightDate,T2.LevelOneSeatNum,T2.LevelTwoSeatNum,T2.LevelNoSeatNum from 
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
                on detailflig.FlightId=detailship.FlightId", StartPlace, Destination, startData);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 根基详细的id查记录
        /// </summary>
        /// <param name="StartPlace"></param>
        /// <param name="Destination"></param>
        /// <param name="startData"></param>
        /// <param name="FlightDetailStationId"></param>
        /// <returns></returns>
        public DataTable GetTicketByparmsAndDetailId(string StartPlace, string Destination, string startData, int FlightDetailStationId)
        {
            string strsql = string.Format(@"select detailflig.FlightDetailStationId,detailflig.RouteId,detailflig.FlightId,detailflig.NowStation,detailflig.VoyageTime,detailflig.AchieveName,detailflig.AchieveTime,detailflig.Price,detailflig.TripTime,detailflig.FlightDate,detailflig.LevelOneSeatNum,detailflig.LevelTwoSeatNum,detailflig.LevelNoSeatNum, detailship.FlightName,detailship.ShipTypeId,detailship.ShipTypeName from 
            (select T1.FlightDetailStationId,T1.RouteId,T1.FlightId,T1.NowStation,T1.VoyageTime,T1.AchieveName,T1.AchieveTime,T1.Price,T1.TripTime, T2.FlightDate,T2.LevelOneSeatNum,T2.LevelTwoSeatNum,T2.LevelNoSeatNum from 
            (select * from [dbo].[FlightDetailStation] where [NowStation]='{0}' and [AchieveName]='{1}' and [FlightDetailStationId]='{2}')T1
            left join 
            (select * from 
            (select * from [dbo].[FlightAndDate] where [FlightDate]='{3}')t  
             where t.[LevelOneSeatNum]>0 or [LevelTwoSeatNum]>0 or [LevelNoSeatNum]>0)T2
             on T1.FlightId=T2.FlightId)detailflig 
             left join

            (select flig.FlightId, flig.FlightName,flig.RouteId,shiptype.ShipTypeId,shiptype.ShipTypeName from 
            (select * from [dbo].[Flight]) flig  
            left join 
            (select * from [dbo].[ShipType])shiptype
            on flig.ShipTypeId=shiptype.ShipTypeId)detailship
            on detailflig.FlightId=detailship.FlightId", StartPlace, Destination, FlightDetailStationId, startData);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 在查出的结果里按大型油轮找。
        /// </summary>
        /// <param name="StartPlace"></param>
        /// <param name="Destination"></param>
        /// <param name="startData"></param>
        /// <param name="ShipTypeName"></param>
        /// <returns></returns>
        public DataTable GetTicketByparmsAndShipName(string StartPlace, string Destination, string startData, string ShipTypeName)
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
on detailflig.FlightId=detailship.FlightId) list
where list.ShipTypeName='{3}'", StartPlace, Destination, startData, ShipTypeName);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }


    }
}