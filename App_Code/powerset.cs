using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// powerset 的摘要说明
/// </summary>
public class powerset
{
    public static bool pset(string Ti_user, string Ti_password)
	{
        Db pn163 = new Db();
        //密码使用MD5加密
        //string Pd;
        //string Us;
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlCommand Cmd = new SqlCommand("select * from Admin where UserAdmin=@UserAdmin and UserPwd = @UserPwd and Mpw = @Mpw", Conn);
        {
            Cmd.Parameters.AddWithValue("@UserAdmin",Ti_user.ToString());
            Cmd.Parameters.AddWithValue("@UserPwd", Ti_password.ToString());
            
        }
        Conn.Open();
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            return true;
        }
        else
        {
            return false;

        }
	}
}
