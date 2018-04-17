using AutologiaShare;
using Resources;
using System;
using System.Configuration;

public partial class Admin_Manufactors : System.Web.UI.Page
{
    private AutologiaDataAccess.Admin admin = new AutologiaDataAccess.Admin();

    protected void Page_Load(object sender, EventArgs e)
    {
        Title = Resource.Admin_Manufactors;

        if (!IsPostBack)
        {
            var data = admin.GetCarManufactors();
            ListBoxManufactorers.DataSource = data;
            ListBoxManufactorers.DataBind();
        }

        Master.SetSelectedMenu(0);
    }

    private void Refresh()
    {
        var data = admin.GetCarManufactors();
        ListBoxManufactorers.DataSource = data;
        ListBoxManufactorers.DataBind();
        TextBoxSelManufactorer.Text = "";
    }

    protected void UpdateManufactorer(object sender, EventArgs e)
    {
        if (ListBoxManufactorers.SelectedIndex == -1) return;

        try
        {
            int id = Convert.ToInt32(ListBoxManufactorers.SelectedValue);
            string manufctorName = TextBoxSelManufactorer.Text;

            admin.UpdateManufactor(id, manufctorName);

            //string uploadImage = UploadImage();

            Refresh();
        }
        catch (Exception ex)
        {
            string error = "SqlException: " + ex.Message;
        }
    }

    protected void UpdateLink(object sender, EventArgs e)
    {
        int carId = Convert.ToInt32(ListBoxManufactorers.SelectedValue);
        //var adapter = new CarManufactorsTableAdapter();
        //DataSet1.CarManufactorsRow row = (from p in adapter.GetData() where p.ID == carId select p).Single();

        //row.LINK = TextBoxManufactorLink.Text;

        //adapter.Update(row);

        //new CarBL().UpdateManufactorLink(carId, TextBoxManufactorLink.Text);

        TextBoxManufactorLink.Text = string.Empty;
    }

    protected void ManufactorerSelected(object sender, EventArgs e)
    {
        //TextBoxSelManufactorer.Text = ListBoxManufactorers.SelectedItem.Text;
        //ButtonUpdateManufatorer.Enabled = ListBoxManufactorers.SelectedIndex != -1;

        //int carId = Convert.ToInt32(ListBoxManufactorers.SelectedValue);
        //var adapter = new AutologiaDL.CarManufactors();
        //AutologiaDL.CarManufactors row = adapter.GetData().Find(a=>a.ID == carId);
        //TextBoxManufactorLink.Text = row.LINK;

        //string logoUrl = string.Empty;
        //if (!string.IsNullOrEmpty(row.LOGO))
        //{
        //    logoUrl = @"..\" + ConfigurationManager.AppSettings[Constants.MANUFACTOR_IMAGES_FOLDER] + row.LOGO;
        //}

        //ImageManufactor.ImageUrl = logoUrl;
        //ImageManufactor.Visible = !string.IsNullOrEmpty(row.LOGO);
        //Label1.Visible = string.IsNullOrEmpty(row.LOGO);
    }

    protected void NewManufactorer(object sender, EventArgs e)
    {
        //string uploadImage = UploadImage();
        string manufactorName = TextBoxSelManufactorer.Text;

        if (!string.IsNullOrEmpty(manufactorName))
        {
            admin.AddManufactor(TextBoxSelManufactorer.Text);
            Refresh();
        }
    }

    protected void SaveImage(object sender, EventArgs e)
    {
        UploadImage();
    }

    private string UploadImage()
    {
        string fileName = FileUpload1.FileName;

        if (string.IsNullOrEmpty(fileName))
            return string.Empty;

        if (FileUpload1.FileName != null && FileUpload1.FileBytes.Length != 0)
        {
            string path = Server.MapPath("~\\") + ConfigurationManager.AppSettings[Constants.MANUFACTOR_IMAGES_FOLDER] + FileUpload1.FileName;
            try
            {
                FileUpload1.SaveAs(path);
            }
            catch
            {

            }

            ImageManufactor.ImageUrl = path;
        }

        return fileName;
    }

    protected void DeleteManufactorer(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ListBoxManufactorers.SelectedValue);
        admin.DeleteManufactor(id);

        //Label1.Visible = true;
        //ImageManufactor.Visible = false;
        //TextBoxManufactorLink.Text = string.Empty;

        Refresh();
    }
}