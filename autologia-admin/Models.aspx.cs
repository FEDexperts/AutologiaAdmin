using AutologiaDataAccess;
using Resources;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

public partial class Admin_Models : System.Web.UI.Page
{
    private static int selectedSubModel;
    private AutologiaDataAccess.Admin admin = new AutologiaDataAccess.Admin();

    protected void Page_Load(object sender, EventArgs e)
    {
        Title = Resource.Admin_Models;

        if (!IsPostBack)
        {
            var data = admin.GetCarManufactors();
            DropDownListManufactor.DataSource = data.OrderBy(a=>a.NAME);
            DropDownListManufactor.DataBind();

            FillCarModels();
        }

        Master.SetSelectedMenu(1);
    }

    private void FillCarModels()
    {
        int carManufactorer = int.Parse(DropDownListManufactor.SelectedValue);
        var data = admin.GetCarModels();
        ListBoxModels.DataSource = data.Where(a => a.MANUFACTOR_ID == carManufactorer);
        ListBoxModels.DataBind();
    }

    protected void AddCarModel(object sender, EventArgs e)
    {
        int carManufactorer = Convert.ToInt32(DropDownListManufactor.SelectedValue);
        var data = admin.GetCarModels();
        int count = data.Where(a => a.NAME == TextBoxCarModel.Text).Count();

        string carModel = TextBoxCarModel.Text;

        if (count == 0 && !string.IsNullOrEmpty(carModel))
        {
            admin.AddCarModel(carManufactorer, carModel);
            FillCarModels();
        }
    }

    protected void UpdateCarModel(object sender, EventArgs e)
    {
        int carModelId;
        int.TryParse(ListBoxModels.SelectedValue, out carModelId);
        string carModelName = TextBoxCarModel.Text;
        if (!string.IsNullOrEmpty(carModelName))
            admin.UpdateCarModel(carModelId, carModelName);

        FillCarModels();
    }

    protected void DeleteCarModel(object sender, EventArgs e)
    {
        int carModelId;
        int.TryParse(ListBoxModels.SelectedValue, out carModelId);
        admin.DeleteCarModel(carModelId);

        FillCarModels();
        FillSubModels();
    }

    protected void AddSubModel(object sender, EventArgs e)
    {
        int carManufactorer = int.Parse(DropDownListManufactor.SelectedValue);
        int carModel;
        int.TryParse(ListBoxModels.SelectedValue, out carModel);
        string carSubModel = TextBoxCarSubModel.Text;
        if (!string.IsNullOrEmpty(carSubModel))
            admin.AddCarSubModel(carManufactorer, carModel, carSubModel);
        FillSubModels();
    }

    protected void UpdateSubModel(object sender, EventArgs e)
    {
        //AutologiaDL.CarSubModel carSubModelRow = GetSubModel(selectedSubModel);

        //string fileName1 = FileUpload1.FileName;
        //string fileName2 = FileUpload2.FileName;

        //if (carSubModelRow != null)
        //{
        //    if (string.IsNullOrEmpty(fileName1) && !string.IsNullOrEmpty(carSubModelRow.SMALL_IMAGE))
        //    {
        //        fileName1 = carSubModelRow.SMALL_IMAGE;
        //    }

        //    if (string.IsNullOrEmpty(fileName2) && !string.IsNullOrEmpty(carSubModelRow.BIG_IMAGE))
        //    {
        //        fileName2 = carSubModelRow.BIG_IMAGE;
        //    }
        //}

        //UploadFiles(fileName1, fileName2);

        int id;
        int.TryParse(ListBoxCarSubModels.SelectedValue, out id);
        string name = TextBoxCarSubModel.Text;
        if (!string.IsNullOrEmpty(name))
        {
            admin.UpdateCarSubModel(id, name);
            FillSubModels();
        }

    }

    protected void DeleteSubModel(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ListBoxCarSubModels.SelectedValue);

        admin.DeleteCarSubModel(id);

        selectedSubModel = 0;

        SmallCarImage.Visible = false;
        BigCarImage.Visible = false;
        Label1.Visible = true;

        FillSubModels();
    }

    private void FillSubModels()
    {
        int carManufactorer;
        int.TryParse(DropDownListManufactor.SelectedValue, out carManufactorer);
        int carModel;
        int.TryParse(ListBoxModels.SelectedValue, out carModel);

        var data = admin.GetCarSubModels();
        ListBoxCarSubModels.DataSource = data.Where(a => a.MANUFACTOR_ID == carManufactorer && a.MODEL_ID == carModel);
        ListBoxCarSubModels.DataBind();

        if (selectedSubModel != 0)
        {
            ListBoxCarSubModels.SelectedValue = selectedSubModel.ToString();
            //LoadImages();
        }
    }

    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        FillCarModels();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedSubModel = 0;

        FillCarModels();

        TextBoxCarModel.Text = "";
        TextBoxCarSubModel.Text = "";

        ListBoxCarSubModels.Items.Clear();

        LoadImages();
    }

    private void UploadFiles(string fileName1, string fileName2)
    {
        if (FileUpload1.FileName != null && FileUpload1.FileBytes.Length != 0)
        {
            string path1 = Server.MapPath("~\\") + ConfigurationManager.AppSettings["UploadFilesFolder"];

            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);

            string fullPath1 = string.Format("{0}{1}", path1, fileName1);

            FileUpload1.SaveAs(fullPath1);
        }

        if (FileUpload2.FileName != null && FileUpload2.FileBytes.Length != 0)
        {
            string path2 = Server.MapPath("~\\") + ConfigurationManager.AppSettings["UploadFilesFolder"];

            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);

            string fullPath2 = string.Format("{0}{1}", path2, fileName2);

            FileUpload2.SaveAs(fullPath2);
        }
    }

    protected void CarModelSelected(object sender, EventArgs e)
    {
        selectedSubModel = 0;

        TextBoxCarModel.Text = ListBoxModels.SelectedItem.Text;
        FillSubModels();

        //LoadImages();
    }

    protected void CarSubModelSelected(object sender, EventArgs e)
    {
        TextBoxCarSubModel.Text = ListBoxCarSubModels.SelectedItem.Text;

        int.TryParse(ListBoxCarSubModels.SelectedValue, out selectedSubModel);

        if (selectedSubModel == 0) return;

        LoadImages();
    }

    private CarSubModel GetSubModel(int selectedSubModel)
    {
        var data = admin.GetCarSubModels();
        CarSubModel carSubModelRow = data.Find(a=>a.ID == selectedSubModel);
        return carSubModelRow;
    }

    private void LoadImages()
    {
        CarSubModel carSubModelRow = GetSubModel(selectedSubModel);

        if (carSubModelRow != null)
        {
            if (!string.IsNullOrEmpty(carSubModelRow.SMALL_IMAGE))
            {
                SmallCarImage.ImageUrl = @"..\" + ConfigurationManager.AppSettings["UploadFilesFolder"] + "/" +
                                         carSubModelRow.SMALL_IMAGE;
                SmallCarImage.Visible = true;
                Label1.Visible = false;
            }
            else
            {
                SmallCarImage.Visible = false;
                Label1.Visible = string.IsNullOrEmpty(carSubModelRow.SMALL_IMAGE);
            }
            if (!string.IsNullOrEmpty(carSubModelRow.BIG_IMAGE))
            {
                BigCarImage.ImageUrl = @"..\" + ConfigurationManager.AppSettings["UploadFilesFolder"] + "/" +
                                         carSubModelRow.BIG_IMAGE;
                BigCarImage.Visible = true;
                Label1.Visible = false;
            }
            else
            {
                BigCarImage.Visible = false;
                Label1.Visible = string.IsNullOrEmpty(carSubModelRow.BIG_IMAGE);
            }
        }
        else
        {
            SmallCarImage.Visible = false;
            BigCarImage.Visible = false;
            Label1.Visible = false;
        }
    }
}