using System;
using System.Web.UI.WebControls;

public partial class Admin_Prices : System.Web.UI.Page
{
    AutologiaDataAccess.Admin admin = new AutologiaDataAccess.Admin();

    protected void Page_Load(object sender, EventArgs e)
    {

        DropDownListManufactorer.SelectedIndexChanged += DropDownListManufactorer_SelectedIndexChanged;
        DropDownListModel.SelectedIndexChanged += DropDownListModel_SelectedIndexChanged;

        if (!IsPostBack)
        {
            DropDownListManufactorer.DataSource = admin.GetCarManufactors();
            DropDownListManufactorer.DataBind();
            int manufactor = int.Parse(DropDownListManufactorer.SelectedValue);

            DropDownListModel.DataSource = admin.GetCarModels(manufactor);
            DropDownListModel.DataBind();
            int model = int.Parse(DropDownListModel.SelectedValue);

            DropDownListYear.DataSource = admin.GetLookupDetails(1);
            DropDownListYear.DataBind();

            RepeaterPrices.DataSource = admin.GetCarSubModels(manufactor, model);
            RepeaterPrices.DataBind();
        }
        
    }

    private void DropDownListModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        int manufactor = int.Parse(DropDownListManufactorer.SelectedValue);
        int model = int.Parse(DropDownListModel.SelectedValue);
        RepeaterPrices.DataSource = admin.GetCarSubModels(manufactor, model);
        RepeaterPrices.DataBind();
    }

    private void DropDownListManufactorer_SelectedIndexChanged(object sender, EventArgs e)
    {
        int manufactor = int.Parse(DropDownListManufactorer.SelectedValue);
        DropDownListModel.DataSource = admin.GetCarModels(manufactor);
        DropDownListModel.DataBind();
        int model = int.Parse(DropDownListModel.SelectedValue);
        RepeaterPrices.DataSource = admin.GetCarSubModels(manufactor, model);
        RepeaterPrices.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int manufactor = int.Parse(DropDownListManufactorer.SelectedValue);
        int model = int.Parse(DropDownListModel.SelectedValue);
        foreach (RepeaterItem item in RepeaterPrices.Items)
        {
            var priceTextBox = (TextBox)item.FindControl("TextBox1");
            var subModelId = ((HiddenField)item.FindControl("HiddenField1"));
            if (string.IsNullOrEmpty(priceTextBox.Text)) continue;
            else
            {
                int id;
                int.TryParse(subModelId.Value, out id);
                int price;
                int.TryParse(priceTextBox.Text, out price);
                admin.UpdateCarSubModelPrice(id, price);
            }
        }
    }
}