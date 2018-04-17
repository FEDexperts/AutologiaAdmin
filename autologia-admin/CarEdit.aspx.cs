using System;

namespace Admin
{
    public partial class AdminCarEdit : System.Web.UI.Page
    {
        //private SearchInfo searchInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["SearchInfo"] != null)
            //{
            //    searchInfo = (SearchInfo)Session["SearchInfo"];
            //}

            
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //string error;
            //bool update = CarEditControl1.Update(out error);
            //if (update)
            //    Response.Redirect(string.Format("Cars.aspx?pg={0}&selId={1}", searchInfo.PageId, searchInfo.SelectedId));
            //else
            //    Label1.Text = error;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Cars.aspx");
        }
    }
}