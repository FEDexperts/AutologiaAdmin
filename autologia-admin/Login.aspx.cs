using System;

namespace Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //bool isUserExist = new Users().IsAdminUserExist(TextBox1.Text, TextBox2.Text);
            //if (isUserExist)
            //{
            //    Session["AdminUser"] = true;
                Response.Redirect("Manufactors.aspx");
            //}
            //else
            //    Label1.Text = "משתמש לא קיים";
        }
    }
}