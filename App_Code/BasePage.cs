using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// 所有需要进行身份验证的页的基类
/// 作者：fengsulei
/// 日期：2010-9.12
/// </summary>
public class BasePage:System.Web.UI.Page
{
	public BasePage()
	{
        this.Load += new EventHandler(BasePage_Load);
	}

    void BasePage_Load(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch
        {
           // Response.Redirect("http://zhuanxing.cn/@Management_ti/");
        }
    }
}
