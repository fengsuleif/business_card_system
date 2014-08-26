using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class human_view : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlDataAdapter Da1 = new SqlDataAdapter();
        Da1.SelectCommand = new SqlCommand("Select * from human where id=@id order by id desc", sqldb.Conn);
        {
            Da1.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }

        DataSet Ds1 = new DataSet();

        Da1.Fill(Ds1, "NewView");

        PagedDataSource Pds = new PagedDataSource();

        Pds.DataSource = Ds1.Tables["NewView"].DefaultView;

        Pds.AllowPaging = true;

        Pds.PageSize = 1;

        Repeater1.DataSource = Pds;

        Repeater1.DataBind();


        ///////////////////////////////////////////////////////////////////分页

        SqlCommand mycomm = new SqlCommand("select count(id) from human ", sqldb.Conn);
        sqldb.Conn.Open();
        int totalOrders = (int)mycomm.ExecuteScalar();
        sqldb.Conn.Close();
        AspNetPager1.RecordCount = totalOrders;
        //以上取得分页的数据总数是没问题的，是正确的 
        BindData();
    }



    public void BindData()
    {

        //略去声明myAdapter   和   DataSet   
        //以下是填充数据方法 

        SqlDataAdapter myAdapter = new SqlDataAdapter("Select * from human order by id desc", sqldb.Conn);
        DataSet ds = new DataSet();
        myAdapter.Fill(ds, AspNetPager1.StartRecordIndex - 1, AspNetPager1.PageSize, "dtable ");
        this.Repeater2.DataSource = ds.Tables[0].DefaultView;
        this.Repeater2.DataBind();

    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();

    }
    public void dh(object sender, EventArgs e)
    {

        F_type();
    }
    public void F_type()
    {

        SqlDataAdapter Da1 = new SqlDataAdapter();

        Da1.SelectCommand = new SqlCommand("Select * from human where id=@id order by id desc", sqldb.Conn);
        {
            Da1.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }

        DataSet Ds1 = new DataSet();

        Da1.Fill(Ds1, "NewView");

        PagedDataSource Pds = new PagedDataSource();

        Pds.DataSource = Ds1.Tables["NewView"].DefaultView;

        Pds.AllowPaging = true;

        Pds.PageSize = 1;

        Repeater1.DataSource = Pds;

        Repeater1.DataBind();
    }
}
