using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class FlightDetailStationManageBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 得到所有的航班的详细站点信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFlightDetailStations()
        {
            string strsql = string.Format(@"select fligth.FlightName, rou.RouteName, flightdetail.AchieveName,flightdetail.AchieveTime,flightdetail.FlightDetailStationId,flightdetail.NowStation,flightdetail.Price,flightdetail.TripTime,flightdetail.VoyageTime from [dbo].[FlightDetailStation] flightdetail
            left join [dbo].[Route] rou
               on rou.RouteId=flightdetail.RouteId
            left join [dbo].[Flight] fligth
            on fligth.FlightId=flightdetail.FlightId");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //删除航班的详细站点信息
        public int DeleteFlightDetailStation(int FlightDetailStationId)
        {
            string strsql = string.Format(@"delete from [dbo].[FlightDetailStation] where [FlightDetailStationId]='{0}'", FlightDetailStationId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        /// <summary>
        /// 得到所有航线
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRoutes()
        {
            string strsql = string.Format(@"select * from [dbo].[Route]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        /// <summary>
        /// 得到所有的航班
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFlights()
        {
            string strsql = string.Format(@"select * from [dbo].[Flight]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //添加航班详细站点管理
        public int AddFlightDetailStation(int RouteId, int FlightId, string NowStation, string VoyageTime, string AchieveName, string AchieveTime, string Price, string TripTime)
        {
            string strsql = string.Format(@"insert into [dbo].[FlightDetailStation]([RouteId],[FlightId],[NowStation],[VoyageTime],[AchieveName],[AchieveTime],[Price],[TripTime]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", RouteId, FlightId, NowStation, VoyageTime, AchieveName, AchieveTime, Price, TripTime);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        /// <summary>
        /// 根据ID查找该条记录
        /// </summary>
        /// <param name="FlightDetailStationId"></param>
        /// <returns></returns>
        public DataTable GetFlightDetailStation(int FlightDetailStationId)
        {
            string strsql = string.Format(@"select * from [dbo].[FlightDetailStation] where [FlightDetailStationId]='{0}'", FlightDetailStationId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //修改航班详细站点
        public int UpdateFlightDetailStation(int RouteId, int FlightId, string NowStation, string VoyageTime, string AchieveName, string AchieveTime, string Price, string TripTime, int FlightDetailStationId)
        {
            string strsql = string.Format(@"update [dbo].[FlightDetailStation] set [RouteId]='{0}',[FlightId]='{1}',[NowStation]='{2}',[VoyageTime]='{3}',[AchieveName]='{4}',[AchieveTime]='{5}',[Price]='{6}',[TripTime]='{7}' where [FlightDetailStationId] ='{8}'", RouteId, FlightId, NowStation, VoyageTime, AchieveName, AchieveTime, Price, TripTime, FlightDetailStationId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }










    }
}