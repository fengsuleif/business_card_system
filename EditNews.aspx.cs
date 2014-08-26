using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditNews : System.Web.UI.Page
{
    String myStr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        TSE_base ck = new TSE_base();
        ck.checkpower();
        //string sql = "select * from SMT_two where zid in";
        if ("up" == Request.QueryString["action"])
        {
            upContent();
        }
       
        if ("edit" == Request.QueryString["action"])
        {
            getcontent();
        }
       
    }

    public cdata getcontent()
    {
        cdata Econtent = new cdata();
        if (!(string.IsNullOrEmpty(Request.QueryString["do"])))
        {
            SqlConnection Conn = new SqlConnection(myStr);
            SqlCommand Cmd = new SqlCommand("select id,name,mail,phone,type,units,duty,allcontent  from human where id=@id", Conn);
            {
                Cmd.Parameters.AddWithValue("@id", Request.QueryString["do"]);
            }
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            else
            {
                Conn.Close();
                Conn.Open();
            }

            SqlDataReader Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                Econtent.cid = Dr["id"].ToString();
                Econtent.cname = Dr["name"].ToString();
                Econtent.cmail = Dr["mail"].ToString();
                Econtent.cphone = Dr["phone"].ToString();
                Econtent.cunits = Dr["units"].ToString();
                Econtent.cduty = Dr["duty"].ToString();
                Econtent.callcontent = Dr["allcontent"].ToString();
                Econtent.ctype = int.Parse(Dr["type"].ToString()); 
            }
            Conn.Close();
        }
        return Econtent;
    }   

    private void upContent()
    {
        if (Request.Form["Etitle"] != "" && Request.Form["Edate"] != "")
        {
            SqlConnection Conn = new SqlConnection(myStr);
            SqlCommand Cmd = new SqlCommand("update human  set name=@name,mail=@mail,phone=@phone,type=@type,units=@units,duty=@duty,allcontent=@allcontent where id=@id", Conn);
            {
                Cmd.Parameters.AddWithValue("@name", Request.Form["cname"]);
                Cmd.Parameters.AddWithValue("@mail", Request.Form["cmail"]);
                Cmd.Parameters.AddWithValue("@phone", Request.Form["cphone"]);
                Cmd.Parameters.AddWithValue("@type", Request.Form["ctype"]);
                Cmd.Parameters.AddWithValue("@units", Request.Form["cunits"]);
                Cmd.Parameters.AddWithValue("@duty", Request.Form["cduty"]);
                Cmd.Parameters.AddWithValue("@allcontent", Request.Form["callcontent"].ToString());
                Cmd.Parameters.AddWithValue("@id", Request.QueryString["do"]);
            }
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            else
            {
                Conn.Close();
                Conn.Open();
            }
            Cmd.ExecuteNonQuery();
            Conn.Close();
            Response.Redirect("NewsList.aspx");
        }
    }
}
//定义一个类，用于存储数据
public  class cdata
{
    public string cid = null;
    public string cname=null; 
    public string cmail = null;
    public string cphone = null;
    public string cunits = null; 
    public string cduty= null;
    public string callcontent = null;
    public int ctype ;
}


