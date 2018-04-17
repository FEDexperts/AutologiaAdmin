using System;
using System.Data.SqlClient;

public partial class Admin_AddCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.SetSelectedMenu(3);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            CarEditControl1.Add();
            Label1.Text = "רכב נוסף בהצלחה";
        }
        catch (SqlException sqlException)
        {
            Label1.Text = string.Format("Database error: {0}", sqlException.Message);
        }
        catch (Exception exception)
        {
            Label1.Text = string.Format("Database error: {0}", exception.Message);
        }
    }
}