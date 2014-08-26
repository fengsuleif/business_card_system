using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.Form["ys"] != null)
        {
            yanzheng();
        }


    }

    public void yanzheng()
    {
        if (Request.Form["ys"] != "" && Request.Form["ys"] != "tse")
        {
            Response.Write("验证码错误");
        }
        else 
        {
            Response.Cookies["TSE_user"].Value= "TRANSTION";
            Response.Cookies["TSE_user"].Expires = DateTime.Now.AddMinutes(60); 
            Response.Redirect("NewsList.aspx");
        }
    }
}