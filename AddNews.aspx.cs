using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNews : System.Web.UI.Page
{
    String myStr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        TSE_base ck = new TSE_base();
        ck.checkpower();
        if ("in" == Request.QueryString["action"])
        { 
            putClass();
        } 
    }


    private void putClass()
    {
        SqlConnection Conn = new SqlConnection(myStr);
        if (Request.Form["cname"] != "")
        {
            SqlCommand Cmd = new SqlCommand("insert into human (name,mail,phone,units,duty,allcontent,type) values (@name,@mail,@phone,@units,@duty,@allcontent,@type)", Conn);
            {
                Cmd.Parameters.AddWithValue("@name", Request.Form["cname"]);
                Cmd.Parameters.AddWithValue("@mail", Request.Form["cmail"]);
                Cmd.Parameters.AddWithValue("@phone", Request.Form["cphone"]);
                Cmd.Parameters.AddWithValue("@units", Request.Form["cunits"]);
                Cmd.Parameters.AddWithValue("@duty", Request.Form["cduty"]);
                Cmd.Parameters.AddWithValue("@allcontent", Request.Form["callcontent"]);
                Cmd.Parameters.AddWithValue("@type", Request.Form["ctype"]);
            }
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

    }

}