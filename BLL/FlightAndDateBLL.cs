using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCommon;
using System.Data;

namespace BLL
{
    public class FlightAndDateBLL
    {
        private SqlHelper sqlhelper = new SqlHelper();

        /// <summary>
        /// 查出所有今天和以后的日程安排
        /// </summary>
        /// <param name="FlightDate"></param>
        /// <returns></returns>
        public DataTable GetAllFlightAndDates(string FlightDate)
        {
            string strsql = string.Format(@"select flight.FlightName, flightandDate.TableId,flightandDate.FlightDate,flightandDate.LevelOneSeatNum,flightandDate.LevelTwoSeatNum,flightandDate.LevelNoSeatNum from  [dbo].[FlightAndDate] flightandDate
                left join [dbo].[Flight] flight
                 on flight.FlightId=flightandDate.FlightId
                 where flightandDate.[FlightDate]>'{0}'", FlightDate);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //删除航班日程
        public int DeleteFlightAndDate(int TableId)
        {
            string strsql = string.Format(@"delete from [dbo].[FlightAndDate] where [TableId]='{0}'", TableId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        /// <summary>
        /// 查出所有的航班信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFlighs()
        {
            string strsql = string.Format(@"select * from [dbo].[Flight]");
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //添加航班日程安排
        public int AddFlightAndDate(int FlightId, string FlightDate, int LevelOneSeatNum, int LevelTwoSeatNum, int LevelNoSeatNum)
        {
            string strsql = string.Format(@"insert into [dbo].[FlightAndDate]([FlightId],[FlightDate],[LevelOneSeatNum],[LevelTwoSeatNum],[LevelNoSeatNum]) values('{0}','{1}','{2}','{3}','{4}')", FlightId, FlightDate, LevelOneSeatNum, LevelTwoSeatNum, LevelNoSeatNum);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }

        /// <summary>
        /// 修改，根据id，找出该条信息
        /// </summary>
        /// <param name="TableId"></param>
        /// <returns></returns>
        public DataTable GetFlightAndDateById(int TableId)
        {
            string strsql = string.Format(@"select * from [dbo].[FlightAndDate] where [TableId]='{0}'", TableId);
            DataTable dt = sqlhelper.GetTable(SqlHelper.connectionString, strsql);
            return dt;
        }

        //修改航班日程安排
        public int UpdateFlightAndDate(int FlightId, string FlightDate, int LevelOneSeatNum, int LevelTwoSeatNum, int LevelNoSeatNum, int TableId)
        {
            string strsql = string.Format(@"update [dbo].[FlightAndDate] set [FlightId]='{0}',[FlightDate]='{1}',[LevelOneSeatNum]='{2}',[LevelTwoSeatNum]='{3}',[LevelNoSeatNum]='{4}' where [TableId] ='{5}'", FlightId, FlightDate, LevelOneSeatNum, LevelTwoSeatNum, LevelNoSeatNum, TableId);
            int result = sqlhelper.GetRetRowCount(SqlHelper.connectionString, strsql);
            return result;
        }










    }
}