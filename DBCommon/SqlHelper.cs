using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DBCommon
{
    public class SqlHelper
    {
        public static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;


        /// <summary>
        /// 返回首行首列的值
        /// </summary>
        /// <param name="strconnstring">连接数据库的字符串</param>
        /// <param name="strSql">要执行的SQL</param>
        /// <returns>返回首行首列的值</returns>
        public object GetFistValue(string connectionString, string strSql)
        {
            //使用using 当连接断开的时候，会自己关闭连接，减少服务器的压力。
            using (SqlConnection sqlConn = new SqlConnection())
            {
                sqlConn.ConnectionString = connectionString;

                sqlConn.Open();

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandText = strSql;
                    object objValue = sqlComm.ExecuteScalar();
                    //sqlConn.Close();
                    return objValue;
                }
            }
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="pstrConnString">使用的连接字符串</param>
        /// <param name="strSql">要执行的SQL</param>
        /// <returns>受影响的行数</returns>
        public int GetRetRowCount(string strConnString, string strSql)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                sqlConn.ConnectionString = strConnString;
                sqlConn.Open();
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandText = strSql;
                    int iRowCount = sqlComm.ExecuteNonQuery();
                    //sqlConn.Close();

                    return iRowCount;
                }
            }
        }


        /// <summary>
        /// 返回一张表，DataTable
        /// </summary>
        /// <param name="pstrConnString"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetTable(string pstrConnString, string sql)
        {
            //打开数据库连接
            using (SqlConnection sqlConn = new SqlConnection(pstrConnString))
            {
                sqlConn.Open();
                //定义一个抽水机--把sql语句，和连接对象相关联
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
                //定义一个游泳馆
                DataSet ds = new DataSet();
                //把水抽到游泳馆
                da.Fill(ds);
                sqlConn.Close();
                //返回一张数据表
                return ds.Tables[0];
            }
        }


        /// <summary>
        /// 返回一张数据集，包括几张表,DataSet
        /// </summary>
        /// <param name="strconnstring">连接数据库字符串</param>
        /// <param name="strSql">查询字符串</param>
        /// <param name="strTableName">要查询数据库的表</param>
        /// <returns></returns>
        public DataSet GetDataSet(string strconnstring, string strSql, string strTableName)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                sqlConn.ConnectionString = strconnstring;
                sqlConn.Open();

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandText = strSql;

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.SelectCommand = sqlComm;
                    DataSet dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet, strTableName);
                    //sqlConn.Close();
                    return dataSet;
                }
            }
        }




    }
}