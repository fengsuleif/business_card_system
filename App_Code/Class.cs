using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///数据库类
/// </summary>
public class Db
{
    //public string strConn = ConfigurationSettings.AppSettings["sqlconn"];
    public string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
}
public static class sqldb
{
    public static string sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
    public static SqlConnection Conn = new SqlConnection(sqldb.sqlConn);

}

