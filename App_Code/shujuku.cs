using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using System.Web;


using System.Data.SqlClient;
using System.Configuration;

using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace FTchina
{
    public class shujuku
    {

        protected static SqlConnection conn = new SqlConnection();
        protected static SqlCommand comm = new SqlCommand();
        protected static string connstr = ConfigurationSettings.AppSettings["connStr"];
         /// <summary> 
        /// 打开数据库连接 
        /// </summary> 
        public static void OpenConnection()
        {
            CheckConnection();
        }
        public static bool CheckConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.ConnectionString = connstr;
                    comm.Connection = conn;
                    conn.Open();
                }
                catch  
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary> 
        /// 关闭当前数据库连接 
        /// </summary> 
        public static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }
        /// <summary> 
        /// 执行Sql查询语句 
        /// </summary> 
        /// <param name="sqlstr">传入的Sql语句</param> 
        public static bool ExecuteSql(string sqlstr)
        {
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                comm.ExecuteNonQuery();
  

                return true;
            }
            catch
            {

                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary> 
        /// 返回指定Sql语句的DataTable 
        /// </summary> 
        /// <param name="sqlstr">传入的Sql语句</param> 
        /// <returns>DataTable</returns> 
        public static DataTable GetDataTable(string sqlstr)
        {
            return GetDataSet(sqlstr).Tables[0];

        }


        /// <summary> 
        /// 返回指定Sql语句的DataSet
        /// </summary> 
        /// <param name="sqlstr">传入的Sql语句</param> 
        /// <returns>DataTable</returns> 
        public static DataSet GetDataSet(string sqlstr)
        {
           
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet dataset = new DataSet();
                try
                {
                    OpenConnection();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sqlstr;
                    da.SelectCommand = comm;
                    da.Fill(dataset);
  
                }

                finally
                {
                    CloseConnection();
                }
                return dataset;
            
        }

        //检测数据是否存在，返回真假
        public static bool testread(string sqlstr)
        {
            return(GetDataSet(sqlstr).Tables[0].Rows.Count > 0);
         }

        /// <summary>
        /// 返回特定值的查询结果
        /// </summary>
        /// <param name="wKey">列名称 如 "select com from table where id=3 "中的com</param>
        /// <param name="fTable">表名称 如 "select com from table"中的table</param>
        /// <param name="wStr">限制条件 如 "select com from table where id=3 "中的id=3</param>
        /// <returns></returns>
        public static string GetValueByKey(string wKey, string fTable, string wStr)
        {
            try
            {
                return GetDataTable("select " + wKey + " from " + fTable + " where " + wStr).Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }




    }
}
