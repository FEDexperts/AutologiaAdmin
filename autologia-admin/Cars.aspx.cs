using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class Cars : System.Web.UI.Page
    {
        //private SearchInfo searchInfo;
        AutologiaDataAccess.Admin admin = new AutologiaDataAccess.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    LoadMainType();
            //    int mainTypeId = Convert.ToInt32(DropDownListMainType.SelectedValue);
            //    LoadSubType(mainTypeId);
            //    LoadManufactorer();
            //    int manufactorer = Convert.ToInt32(DropDownListManufactorer.SelectedValue);
            //    LoadModels(manufactorer);
            //    int model = Convert.ToInt32(DropDownListModel.SelectedValue);
            //    LoadSubModels(manufactorer, model);

            //    if (Session["SearchInfo"] != null)
            //    {
            //        searchInfo = (SearchInfo)Session["SearchInfo"];
            //        DropDownListManufactorer.SelectedValue = searchInfo.Manufactorer.ToString();
            //        LoadModels(searchInfo.Manufactorer);
            //        DropDownListModel.SelectedValue = searchInfo.Model.ToString();
            //        LoadSubModels(searchInfo.Manufactorer, searchInfo.Model);
            //        DropDownListSubModel.SelectedValue = searchInfo.SubModel.ToString();
            //        DropDownListMainType.SelectedValue = searchInfo.MainType.ToString();
            //        LoadSubType(searchInfo.MainType);
            //        DropDownListSubType.SelectedValue = searchInfo.SubType.ToString();
            //        DropDownListYear.DataBind();
            //        DropDownListYear.SelectedValue = searchInfo.Year.ToString();
            GetCars();
            //        GridView1.SelectedIndex = searchInfo.SelectedId;
            //        GridView1.PageIndex = searchInfo.PageId;
            //    }
            //    else
            //    {
            //        GridView1.SelectedIndex = -1;
            //        ButtonEdit.Enabled = false;
            //        ButtonDelete.Enabled = false;
            //    }
            //}
            //Master.SetSelectedMenu(4);
        }

        private void LoadSubModels(int manufactorer, int model)
        {
            //var adapter = new AutologiaDL.CarSubModel();
            //DropDownListSubModel.DataSource = from p in adapter.GetData() where p.MANUFACTOR_ID == manufactorer && p.MODEL_ID == model select p;
            //DropDownListSubModel.DataBind();
            //AddAll(DropDownListSubModel);
        }

        private void LoadModels(int manufactorer)
        {
            //var adapter = new AutologiaDL.CarModel();
            //DropDownListModel.DataSource = from p in adapter.GetData() where p.MANUFACTOR_ID == manufactorer select p;
            //DropDownListModel.DataBind();
            //AddAll(DropDownListModel);
        }

        private void AddAll(DropDownList dropDownListModel)
        {
            dropDownListModel.Items.Insert(0,new ListItem("הכל","0"));
        }

        private void LoadSubType(int mainTypeId)
        {
            //var adapter = new AutologiaDL.Menu();
            //DropDownListSubType.DataSource = from p in adapter.GetData() where p.PARENT_ID == Constants.SUB_TYPE && p.LINKED_TO == mainTypeId  select p;
            //DropDownListSubType.DataBind();
        
        }

        private void LoadMainType()
        {
            //var adapter = new AutologiaDL.Menu();
            //DropDownListMainType.DataSource = from p in adapter.GetData() where p.PARENT_ID == Constants.MAIN_TYPE select p;
            //DropDownListMainType.DataBind();
        }

        private void LoadManufactorer()
        {
            //var adapter = new AutologiaDL.CarManufactors();
            //DropDownListManufactorer.DataSource = from p in adapter.GetData() select p;
            //DropDownListManufactorer.DataBind();
            //AddAll(DropDownListManufactorer);
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ButtonEdit.Enabled = true;
            //ButtonDelete.Enabled = true;
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //int id = 0;
            //if (GridView1.Rows.Count > GridView1.SelectedIndex && GridView1.SelectedIndex != -1)
            //    int.TryParse(GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text, out id);

            //var searchInfo = new SearchInfo
            //    {
            //        CarId = id,
            //        Manufactorer = int.Parse(DropDownListManufactorer.SelectedValue),
            //        Model = int.Parse(DropDownListModel.SelectedValue),
            //        SubModel = int.Parse(DropDownListSubModel.SelectedValue),
            //        PageId = GridView1.PageIndex,
            //        SelectedId = GridView1.SelectedIndex,
            //        Year = int.Parse(DropDownListYear.SelectedValue),
            //        MainType = int.Parse(DropDownListMainType.SelectedValue),
            //        SubType = int.Parse(DropDownListSubType.SelectedValue)
            //    };
            //Session["SearchInfo"] = searchInfo;
            //Response.Redirect("CarEdit.aspx");
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
        }
        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            //GridView1.SelectedIndex = -1;
        }
        protected void DropDownListManufactorer_DataBound(object sender, EventArgs e)
        {
            //DropDownListManufactorer.SelectedValue = searchInfo.Manufactorer.ToString();
        }

        protected void DropDownListModel_DataBound(object sender, EventArgs e)
        {
            //if (DropDownListModel.Items.FindByValue(searchInfo.Model.ToString()) != null)
            //    DropDownListModel.SelectedValue = searchInfo.Model.ToString();

        }

        protected void DropDownListYear_DataBound(object sender, EventArgs e)
        {
            //AddAll(DropDownListYear);
            //DropDownListYear.SelectedValue = searchInfo.Year.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //int carId = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text);
            //new CarBL().Delete(carId);
            GetCars();
            //GridView1.DataBind();
        }

        protected void DropDownListSubModel_DataBound(object sender, EventArgs e)
        {
            //if (DropDownListSubModel.Items.FindByValue(searchInfo.SubModel.ToString()) != null)
            //    DropDownListSubModel.SelectedValue = searchInfo.SubModel.ToString();
        }

        protected void DropDownListMainType_DataBound(object sender, EventArgs e)
        {
        }

        protected void DropDownListSubType_DataBound(object sender, EventArgs e)
        {
            //if (DropDownListSubType.Items.FindByValue(searchInfo.SubType.ToString()) != null)
            //    DropDownListSubType.SelectedValue = searchInfo.SubType.ToString();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "מס.";
                e.Row.Cells[3].Text = "יצרן";
                e.Row.Cells[4].Text = "דגם";
                e.Row.Cells[5].Text = "דגם משנה";
                e.Row.Cells[6].Text = "סגנון ראשי";
                e.Row.Cells[7].Text = "סגנון משני";
                e.Row.Cells[8].Text = "";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var carImage = (Image)(e.Row.Cells[1].FindControl("CarImage"));
                carImage.ImageUrl = string.Format("../Images/Upload/{0}", e.Row.Cells[8].Text);
                e.Row.Cells[8].Text = "";
            }
        }

        protected void ObjectDataSourceYearSelected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            var table = (DataTable)e.ReturnValue;
            foreach (DataRow row in table.Rows)
            {
                row["VALUE"] = string.Format("({0}) {1}", row["ID"], row["VALUE"]);
            }
        }

        protected void MainTypeChanged(object sender, EventArgs e)
        {
            //int mainTypeId = Convert.ToInt32(DropDownListMainType.SelectedValue);
            //LoadSubType(mainTypeId);
        }

        protected void ModelChanged(object sender, EventArgs e)
        {
            //int manufactorer = Convert.ToInt32(DropDownListManufactorer.SelectedValue);
            //int model = Convert.ToInt32(DropDownListModel.SelectedValue);
            //LoadSubModels(manufactorer, model);
        }

        protected void ManufactorerChanged(object sender, EventArgs e)
        {
            //int manufactorer = Convert.ToInt32(DropDownListManufactorer.SelectedValue);
            //LoadModels(manufactorer);

            //if (DropDownListModel.Items.FindByValue("0") != null)
            //    DropDownListModel.SelectedIndex = 0;

            //if (!string.IsNullOrEmpty(DropDownListModel.SelectedValue))
            //{
            //    int model = Convert.ToInt32(DropDownListModel.SelectedValue);
            //    LoadSubModels(manufactorer, model);
            //}
        }

        protected void Search(object sender, EventArgs e)
        {
            GetCars();
        }

        private void GetCars()
        {
            try
            {
                //int manufactorer = Convert.ToInt32(DropDownListManufactorer.SelectedValue);
                //int model = Convert.ToInt32(DropDownListModel.SelectedValue);
                //int subModel = Convert.ToInt32(DropDownListSubModel.SelectedValue);
                //int mainType = Convert.ToInt32(DropDownListMainType.SelectedValue);
                //int subType = Convert.ToInt32(DropDownListSubType.SelectedValue);
                //int year = Convert.ToInt32(DropDownListYear.SelectedValue);

                //DataTable dataTable = new CarBL().GetCars(manufactorer, model, subModel, mainType, subType, year);

                var data = new AutologiaDataAccess.Admin().GetCars();
                Repeater1.DataSource = data;
                Repeater1.DataBind();


                //Label1.Visible = false;
                //GridView1.DataSource = data;
                //GridView1.DataBind();

                //var searchInfo = new SearchInfo
                //    {
                //        Manufactorer = manufactorer,
                //        Model = model,
                //        SubModel = subModel,
                //        MainType = mainType,
                //        SubType = subType,
                //        Year = year
                //    };
                //Session["SearchInfo"] = searchInfo;

                //ButtonEdit.Visible = dataTable.Rows.Count != 0;
                //ButtonDelete.Visible = dataTable.Rows.Count != 0;
            }
            catch(FormatException)
            {
                //Label1.Text = Resource.Admin_Cars_DoSearch_EmptyFilter;
                //Label1.Visible = true;
                //GridView1.DataSource = null;
                //GridView1.DataBind();
            }
            //catch (Exception ex)
            //{
                //Label1.Text = ex.Message;
                //Label1.Visible = true;
                //GridView1.DataSource = null;
                //GridView1.DataBind();
            //}
        }

        protected void Btn_Command(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument;
            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("caredit.aspx?id=" + id);
                    break;
                case "Delete":
                    try
                    {
                        admin.DeleteCar(Convert.ToInt32(id));
                        GetCars();
                    }
                    catch(Exception err)
                    {
                        Label1.Text = err.Message;
                    }
                    finally
                    {
                        Label1.Visible = !String.IsNullOrEmpty(Label1.Text);
                    }
                    break;
            }
        }
    }
}