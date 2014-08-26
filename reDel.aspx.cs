using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reDel : System.Web.UI.Page
{
    String myStr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        TSE_base ck = new TSE_base();
        ck.checkpower();
        if ("recovery" == Request.QueryString["action"])
        {           
            recoveryUser();
        }else  if ("del" == Request.QueryString["action"])
        {           
            delUser();
        } else  if ("adel" == Request.QueryString["action"] && Request.Form["mycheckall"]!= null )
        {           
            alldelUser();
        }            
       
    }
    public int Mpage = 20;  //每页多少行
    public int Cpage = 1;    //当前页

    public int totalpage(int pnum)
    {
        SqlConnection Conn = new SqlConnection(myStr);
        SqlCommand mycomm = new SqlCommand("select count(id) from human where type=1000000", Conn);
        
        Conn.Open();
        int totalOrders = (int)mycomm.ExecuteScalar();
        Conn.Close();
        if (totalOrders <= pnum)
        {
            return 1;
        }
        else
        {
            return totalOrders / pnum + 1;
        }
    }
    public void Fwrite(int ipage)
    {
        ipage = totalpage(20);
        Response.Write("<ul class=\"ch-pagination\" id=\"yyy\"><li><a type=\"prev\" href=\"\">共" + ipage + "页</a></li>");
        // Response.Write("<li><a type=\"prev\" href=\"/2.html\">Previous</a></li>");
        if(ipage>100)          
         ipage = 100;
        for (int i=1 ; i <= ipage; i++)
        {
            if (Request.QueryString["gpage"]!=null&&int.Parse(Request.QueryString["gpage"]) == i)
            {
                Response.Write("<li class=\"ch-pagination-current\"><a  href=\"reDel.aspx?gpage=" + i + "\" >" + i + "</a></li>"); 
            }
            else
            {
                Response.Write("<li><a  href=\"reDel.aspx?gpage=" + i + "\" >" + i + "</a></li>");
            }
        }
     
    }
   
    private void delUser()
    {  
        string sql = "delete from  human  where type=1000000 and id=@id";
      
            SqlConnection Conn = new SqlConnection(myStr);
           
            SqlCommand Cmd = new SqlCommand(sql,Conn);
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
            Cmd.ExecuteNonQuery();
            Conn.Close();
    }
	
	private void alldelUser()
    {  
		string sql = string.Format("delete from  human  where type=1000000 and id in({0})", Request.Form["mycheckall"]);
            SqlConnection Conn = new SqlConnection(myStr);          
            SqlCommand Cmd = new SqlCommand(sql,Conn);
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
			Response.Redirect("reDel.aspx");
        //Response.Write("is all del"+Request.Form["mycheckall"]);
    }
	
    private void recoveryUser()
    {  
        string sql = "update human  set type=1 where id=@id";
      
            SqlConnection Conn = new SqlConnection(myStr);
           
            SqlCommand Cmd = new SqlCommand(sql,Conn);
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
            Cmd.ExecuteNonQuery();
            Conn.Close();
    }
    public string sql1 = "select top 20 id,name,mail ,phone from human where type=1000000 order by id desc";
    public void gettable()
    {
        SqlConnection Conn = new SqlConnection(myStr);
        DataTable tb = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(sql1, Conn);
        adp.Fill(tb);
        foreach (DataRow row in tb.Rows)
        {
            Response.Write("<tr><td>");
            Response.Write("<input type=\"checkbox\" name=\"mycheckall\" value=" + row["id"] + " />");
            Response.Write("</td><td>");
            Response.Write(row["id"]);
            Response.Write("</td><td><a href=\"w.aspx?i="+ row["id"]+"\" class=\"YOUR_SELECTOR_Modal\">");
            Response.Write(row["name"]);

            Response.Write("</a></td><td>");
            Response.Write(row["mail"]);
             Response.Write("</td><td>");
            Response.Write(row["phone"]);          
            Response.Write("</td><td>");
            int sid = (int)row["id"];
            Response.Write("<a href=reDel.aspx?action=del&do=" + sid + " class=\" ch-btn ch-btn-small ch-icon-pencil\"  data=\"" + 1 + "," + row["id"] + "," + row["name"] + "," +  row["mail"] + "\" target=\"blank\">Del</a>     <a href=reDel.aspx?action=recovery&do=" + sid + "  class=\"ch-btn ch-btn-small ch-icon-remove\" > recovery</a>");
            Response.Write("</td></tr>");
            //listchildtable((int)row["zid"], tb2, 0);

        }
    }
    public void gettable2()
    {
        this.Cpage = int.Parse(Request.QueryString["gpage"]);
        this.sql1 = "select top 20 id,name,mail,phone from human where (type=100000) and id<(select min(id) from (select top " + this.Mpage * (this.Cpage - 1) + " id from human where type!=1000000 order by id desc ) as t1 ) order by id desc";

        SqlConnection Conn = new SqlConnection(myStr);
        DataTable tb = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(sql1, Conn);
        adp.Fill(tb);
        foreach (DataRow row in tb.Rows)
        {
            Response.Write("<tr><td>");
            Response.Write("<input type=\"checkbox\" name=\"mycheckall\" value=" + row["id"] + " />");
            Response.Write("</td><td>");
            Response.Write(row["id"]);
            Response.Write("</td><td><a href=\"w.aspx?i="+ row["id"]+"\" class=\"YOUR_SELECTOR_Modal\">");
            Response.Write(row["name"]);

            Response.Write("</a></td><td>");
            Response.Write(row["mail"]);
             Response.Write("</td><td>");
            Response.Write(row["phone"]);          
            Response.Write("</td><td>");
            int sid = (int)row["id"];
            Response.Write("<a href=reDel.aspx?action=del&do=" + sid + " class=\" ch-btn ch-btn-small ch-icon-pencil\"  data=\"" + 1 + "," + row["id"] + "," + row["name"] + "," +  row["mail"] + "\" target=\"blank\">Del</a>     <a href=reDel.aspx?action=recovery&do=" + sid + "  class=\"ch-btn ch-btn-small ch-icon-remove\" > recovery</a>");
            Response.Write("</td></tr>");
        }
    }
    

 
}