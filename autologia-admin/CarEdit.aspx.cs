using System;

namespace Admin
{
    public partial class AdminCarEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string error;
            bool update = CarEditControl1.Update(out error);
            if (update)
                Response.Redirect("Cars.aspx");
            else
                Label1.Text = error;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cars.aspx");
        }
    }
}