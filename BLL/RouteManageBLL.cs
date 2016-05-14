using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class RouteManageBLL
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

        //用航线ID查改条信息
        public DataTable GetRouteByRouteId(int RouteId)
        {
            string strsql = string.Format(@"select * from [dbo].[Route] where RouteId='{0}'", RouteId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //删除航线
        public int DeleteRoute(int RouteId)
        {
            string strsql = string.Format(@"delete from [dbo].[Route] where [RouteId]='{0}'", RouteId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        //添加航线
        public int AddRoute(string RouteName, string StartStation, string AchieveStation, string EarliestTrip, string LastedTrip, string FullTime, int StationNum)
        {
            string strsql = string.Format(@"insert into [dbo].[Route]([RouteName],[StartStation],[AchieveStation],[EarliestTrip],[LastedTrip],[FullTime],[StationNum]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", RouteName, StartStation, AchieveStation, EarliestTrip, LastedTrip, FullTime, StationNum);
            int resule = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return resule;
        }

        //修改航线
        public int UpdateRoute(string RouteName, string StartStation, string AchieveStation, string EarliestTrip, string LastedTrip, string FullTime, int StationNum, int RouteId)
        {
            string strsql = string.Format(@"update [dbo].[Route] set [RouteName]='{0}',[StartStation]='{1}',[AchieveStation]='{2}',[EarliestTrip]='{3}',[LastedTrip]='{4}',[FullTime]='{5}',[StationNum]='{6}' where [RouteId]='{7}' ", RouteName, StartStation, AchieveStation, EarliestTrip, LastedTrip, FullTime, StationNum, RouteId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }
    }
}