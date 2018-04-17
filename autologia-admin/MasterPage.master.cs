using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    List<LinkButton> _menus;

    public Admin_MasterPage()
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["AdminUser"] == null)
        //    Response.Redirect("Login.aspx");
    }

    public void SetSelectedMenu(int id)
    {
        _menus = new List<LinkButton> { LinkButton3, LinkButton4, LinkButton7, LinkButton2, LinkButton6, LinkButton8, LinkButton10 };
        _menus[id].Style.Add("Color", "Blue");
    }
}
