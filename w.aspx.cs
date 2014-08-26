using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class w : System.Web.UI.Page
{
    String myStr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
    public int  Mpage=20;  //每页多少行
    public int Cpage=1;    //当前页
    //public int Cid;
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (Request.Form["Classid"] != null)
        {
            if (Request.Form["gpage"] != null)
            {
                gettable();
                Fwrite(10);
            }else
            {
                gettable();
                Fwrite(10);
            }
         
        }
        if (Request.Form["s"] != null) {
            getsearch();
            //Swrite(1);
        }

        if (Request.QueryString["i"] != null)
        {
            View();
        }
    }
    public int totalpage(int pnum)
    {
        SqlConnection Conn = new SqlConnection(myStr);
        SqlCommand mycomm = new SqlCommand("select count(id) from human where type=@type ", Conn);
        {
            mycomm.Parameters.AddWithValue("@type", Request.Form["Classid"]);            
        }
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
       Response.Write("<ul class=\"ch-pagination\" id=\"xxx\"><li><a type=\"prev\" href=\"#\">共" + ipage + "页</a></li>");
      // Response.Write("<li><a type=\"prev\" href=\"/2.html\">Previous</a></li>");
            for (int i=1;i<=ipage;i++)
       {
           if (Request.Form["gpage"] != null && int.Parse(Request.Form["gpage"]) == i)
           {
               Response.Write("<li class=\"ch-pagination-current\"><a  href=\"#\" >" + i + "</a></li>");
           }
           else 
           {
               Response.Write("<li><a  href=\"#\" >" + i + "</a></li>");
           }				
       }
     Response.Write("<li><a type=\"next\" href=\"#\"></a></li></ul>");
   }
  
    public string sql1;
    public void gettable()
    {
        if (Request.Form["gpage"] != null && int.Parse(Request.Form["gpage"]) > 1)
        {

            this.Cpage = int.Parse(Request.Form["gpage"]);
            this.sql1 = "select top 20 id,name,mail,phone from human where (type=@type) and id<(select min(id) from (select top " + this.Mpage * (this.Cpage - 1) + " id from human where type=" + int.Parse(Request.Form["Classid"].ToString())  + " order by id desc ) as t1 ) order by id desc";
        }
        else
        {
            //this.Cpage = 1;
            this.sql1 = "select top 20 id,name,mail,phone from human where (type=@type) order by id desc";
        }
       
        SqlConnection Conn = new SqlConnection(myStr);
        DataTable tb = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand(this.sql1, Conn);
        {
            adp.SelectCommand.Parameters.AddWithValue("@type", Request.Form["Classid"]);            
        }
        adp.Fill(tb);
        ////
        Response.Write("<table class=\"ch-datagrid\" ><caption>文章管理</caption>");
        Response.Write("<thead><tr> <th scope=\"col\"><input type=\"checkbox\" name=\"checkall\" id=\"ckid\"/>全选</th><th scope=\"col\">id</th><th>姓名</th><th>邮箱</th><th>电话</th><th scope=\"col\" style=\"width:170px\">管理</th></tr></thead><tbody>");
        ////  
        foreach (DataRow row in tb.Rows)
        {
            Response.Write("<tr><td>");
            Response.Write("<input type=\"checkbox\" name=\"mycheckall\" value=" + row["id"] + " />");
            Response.Write("</td><td>");
            Response.Write(row["id"]);
            Response.Write("</td><td><a href=\"w.aspx?i=" + row["id"] + "\" class=\"YOUR_SELECTOR_Modal\">");
            Response.Write(row["name"]);

            Response.Write("</a></td><td><a href='mailto:"+row["mail"]+"'>");
            Response.Write(row["mail"]);			
            Response.Write("</a></td><td><a href='tel://"+row["phone"]+"'>");
            Response.Write(row["phone"]); 
			Response.Write("</a> | <a href='sms:"+row["phone"]+"'>短信");			
            Response.Write("</a></td><td>");
            int sid = (int)row["id"];
            Response.Write("<a href=EditNews.aspx?action=edit&do=" + sid + " class=\" ch-btn ch-btn-small ch-icon-pencil\"   target=\"blank\">Edit</a>     <a href=NewsList.aspx?action=de&do=" + sid + "  class=\"ch-btn ch-btn-small ch-icon-remove\" > delete</a>");
            Response.Write("</td></tr>");

        }
        Response.Write("</tbody></table>  <input type=\"submit\" class=\"ch-btn ch-btn-small ch-icon-remove\" value=\"删除所选\" id=\"send_ckid11\" />");
     
    }



    public void getsearch()
    {       
        string dname = Request.Form["s"].ToString();
        dname = "%" + dname + "%";
        if (Request.Form["gpage"] != null && int.Parse(Request.Form["gpage"]) > 1)
        {
            this.Cpage = int.Parse(Request.Form["gpage"]);
            this.sql1 = "select top 20 id,name,mail,phone from human where (type!=1000000) and id<(select min(id) from (select top " + this.Mpage * (this.Cpage - 1) + " id from human where type!=1000000 order by id desc ) as t1 ) order by id desc";
        }
        else
        {
            this.sql1 = "select  id,name,mail,phone from human where name like @name and  type!=1000000 order by id desc";
        }

        SqlConnection Conn = new SqlConnection(myStr);
        DataTable tb = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand(this.sql1, Conn);
        {
            adp.SelectCommand.Parameters.AddWithValue("@name",dname);
        }
        adp.Fill(tb);
        ////
        Response.Write("<table class=\"ch-datagrid\" ><caption>文章管理</caption>");
        Response.Write("<thead><tr> <th scope=\"col\"><input type=\"checkbox\" name=\"checkall\" id=\"ckid\"/>全选</th><th scope=\"col\">id</th><th>姓名</th><th>邮箱</th><th>电话</th><th scope=\"col\" style=\"width:170px\">管理</th></tr></thead><tbody>");
        ////  
        foreach (DataRow row in tb.Rows)
        {
            Response.Write("<tr><td>");
            Response.Write("<input type=\"checkbox\" name=\"mycheckall\" value=" + row["id"] + " />");
            Response.Write("</td><td>");
            Response.Write(row["id"]);
            Response.Write("</td><td><a href=\"w.aspx?i=" + row["id"] + "\" class=\"YOUR_SELECTOR_Modal\">");
            Response.Write(row["name"]);

            Response.Write("</a></td><td><a href='mailto:"+row["mail"]+"'>");
            Response.Write(row["mail"]);			
            Response.Write("</a></td><td><a href='tel://"+row["phone"]+"'>");
            Response.Write(row["phone"]); 
			Response.Write("</a> | <a href='sms:"+row["phone"]+"'>短信");			
            Response.Write("</a></td><td>");
            int sid = (int)row["id"];
            Response.Write("<a href=EditNews.aspx?action=edit&do=" + sid + " class=\" ch-btn ch-btn-small ch-icon-pencil\"  data=\"" + 1 + "," + row["id"] + "," + row["name"] + "," + row["mail"] + "\" target=\"blank\">Edit</a>     <a href=NewsList.aspx?action=de&do=" + sid + "  class=\"ch-btn ch-btn-small ch-icon-remove\" > delete</a>");
            Response.Write("</td></tr>");

        }
        Response.Write("</tbody></table>  <input type=\"submit\" class=\"ch-btn ch-btn-small ch-icon-remove\" value=\"删除所选\" id=\"send_ckid11\" />");

    }

    public int serpage(int pnum)
    {
        string sname = Request.Form["s"].ToString();
        SqlConnection Conn = new SqlConnection(myStr);
        SqlCommand mycomm = new SqlCommand("select count(id) from human where name like @name ", Conn);
        {
            mycomm.Parameters.AddWithValue("@name", sname);
        }
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
    public void Swrite(int ipage)
    {
        ipage = serpage(20);
        Response.Write("<ul class=\"ch-pagination\" id=\"xxx\"><li><a type=\"prev\" href=\"#\">共" + ipage + "页</a></li>");
        // Response.Write("<li><a type=\"prev\" href=\"/2.html\">Previous</a></li>");
        for (int i = 1; i <= ipage; i++)
        {
            if (Request.Form["gpage"] != null && int.Parse(Request.Form["gpage"]) == i)
            {
                Response.Write("<li class=\"ch-pagination-current\"><a  href=\"#\" >" + i + "</a></li>");
            }
            else
            {
                Response.Write("<li><a  href=\"#\" >" + i + "</a></li>");
            }
        }
        Response.Write("<li><a type=\"next\" href=\"#\"></a></li></ul>");
    }

    public void View()
    {
        this.sql1 = "select * from human where id=@id ";
        SqlConnection Conn = new SqlConnection(myStr);
        DataTable tb = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand(this.sql1, Conn);
        {
            adp.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["i"]);
        }
        adp.Fill(tb);
        ////
        Response.Write("<div class=\"ch-box-lite\">");
       
        ////  
        foreach (DataRow row in tb.Rows)
        {
            Response.Write(" <h2>姓名："+row["name"]+"</h2>");           
            Response.Write(" <h2>电话："+row["phone"]+"</h2>");
            Response.Write(" <h2>邮箱：" + row["mail"] + "</h2>");
            Response.Write(" <h2>职业：" + row["duty"] + "</h2>");
            Response.Write(" <h2>职位：" + row["units"] + "</h2>");
            Response.Write(" <h2>备注：</h2><div style='font-size: 1.3em;'>" + row["allcontent"] + "</div>");
        }
        Response.Write("</div>");
    }
}