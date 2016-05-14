using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class FlightManageBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

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
        /// 取到所有的船舶类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllShipType()
        {
            string strsql = string.Format(@"select * from [dbo].[ShipType]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //找出所有的航班信息
        public DataTable GetAllFlights()
        {
            string strsql = string.Format(@"select  rou.RouteName,shiptype.ShipTypeName,flight.FlightId, flight.AchieveTime,flight.FlightName,flight.TripTime,flight.VoyageTime from [dbo].[Flight] flight
                left join [dbo].[ShipType] shiptype
                on flight.ShipTypeId=shiptype.ShipTypeId
                left join [dbo].[Route] rou
                 on rou.RouteId=flight.RouteId");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //找出的航班信息
        public DataTable GetAllFlightByFlightId(int FlightId)
        {
            string strsql = string.Format(@" select  rou.RouteName,shiptype.ShipTypeName,flight.FlightId, flight.AchieveTime,flight.FlightName,flight.TripTime,flight.VoyageTime from [dbo].[Flight] flight
                left join [dbo].[ShipType] shiptype
                on flight.ShipTypeId=shiptype.ShipTypeId
                left join [dbo].[Route] rou
                on rou.RouteId=flight.RouteId
                where flight.FlightId='{0}'", FlightId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //删除航班
        public int DeleteFlight(int FlightId)
        {
            string strsql = string.Format(@"delete from [dbo].[Flight] where [FlightId]='{0}'", FlightId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //添加航班
        public int AddFlight(string FlightName, int RouteId, string VoyageTime, string AchieveTime, string TripTime, int ShipTypeId)
        {
            string strsql = string.Format(@"insert into [dbo].[Flight]([FlightName],[RouteId],[VoyageTime],[AchieveTime],[TripTime],[ShipTypeId]) values('{0}','{1}','{2}','{3}','{4}','{5}')", FlightName, RouteId, VoyageTime, AchieveTime, TripTime, ShipTypeId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //修改航班
        public int UpdateFlight(string FlightName, int RouteId, string VoyageTime, string AchieveTime, string TripTime, int ShipTypeId, int FlightId)
        {
            string strsql = string.Format(@"update [dbo].[Flight] set [FlightName]='{0}',[RouteId]='{1}',[VoyageTime]='{2}',[AchieveTime]='{3}',[TripTime]='{4}',[ShipTypeId]='{5}' where [FlightId]='{6}'", FlightName, RouteId, VoyageTime, AchieveTime, TripTime, ShipTypeId, FlightId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }








    }
}