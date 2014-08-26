using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

public class TSE_base
{
	public TSE_base()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   

    public void checkpower()
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies["TSE_user"];

        if (cookie == null)
        {
            HttpContext.Current.Response.Redirect("Login.aspx");
        }
        else if (cookie == null && cookie.ToString() != "TRANSTION")
        {
            HttpContext.Current.Response.Redirect("Login.aspx");
        }

    }
}