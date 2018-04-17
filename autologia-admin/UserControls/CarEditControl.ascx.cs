using AutologiaDataAccess;
using AutologiaShare;
using AutologiaShare.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

public partial class UserControls_CarEditControl : System.Web.UI.UserControl
{
    Cars car;
    Admin admin = new Admin();
    int carId;

    public enum EditTypeCode
    {
        EtNew = 0,
        EtModify = 1
    }
    public EditTypeCode EditType
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            EditType = EditTypeCode.EtNew;
            if (Request.QueryString != null && Request.QueryString["id"] != null)
            {
                EditType = EditTypeCode.EtModify;
                carId = Convert.ToInt32(Request.QueryString["id"]);
                car = admin.GetCar(carId);
                InitEdit();
            }
            else
            {
                EditType = EditTypeCode.EtNew;
                InitNew();
            }
        }
    }

    private void InitNew()
    {
        var carManufactors = admin.GetCarManufactors().OrderBy(a => a.NAME).ToList();
        DropDownListManufactor.DataSource = carManufactors;
        DropDownListManufactor.DataBind();

        int carManufactorer = string.IsNullOrEmpty(DropDownListManufactor.SelectedValue) ? 0 : int.Parse(DropDownListManufactor.SelectedValue);

        DropDownListModel.DataSource = admin.GetCarModels().Where(a=>a.MANUFACTOR_ID == carManufactorer);
        DropDownListModel.DataBind();

        int carModel = string.IsNullOrEmpty(DropDownListModel.SelectedValue) ? 0 : int.Parse(DropDownListModel.SelectedValue);

        DropDownListSubModel.DataSource = admin.GetCarSubModels().Where(a=>a.MANUFACTOR_ID == carManufactorer && a.MODEL_ID == carModel);
        DropDownListSubModel.DataBind();

        
        ddMainType.DataSource = admin.GetMainTypes();
        ddMainType.DataBind();

        int carMainType;
        int.TryParse(ddMainType.SelectedValue, out carMainType);

        ddSubType.DataSource = admin.GetSubTypes(carMainType);
        ddSubType.DataBind();

        InitLists(car.MAIN_TYPE.Value);
    }
    private void InitLists(int typeId)
    {
        FillDropDownList2(DropDownListYear, Constants.YEAR, null);
        FillDropDownList2(DropDownListCountry, Constants.COUNTRY, null);
        FillCheckBoxList(ddSeats, Constants.SEATS, null, typeId);
        FillCheckBoxList(DropDownListDors, Constants.DORS, null, typeId);
        FillCheckBoxList(ddFeulType, Constants.FEUL_TYPE, null, typeId);
        FillCheckBoxList(CheckBoxListGeer, Constants.GEAR, null, typeId);
        FillCheckBoxList(DropDownListCarSize, Constants.CAR_SIZE, null, typeId);
        FillCheckBoxList(DropDownListTrunkSize, Constants.TRUNK_SIZE, null, typeId);
        FillCheckBoxList(DropDownListAccessoriesLevel, Constants.FEATURES, null, typeId);
        FillCheckBoxList(DropDownListResponse, Constants.RESPONSE, null, typeId);
        FillCheckBoxList(CheckBoxListPerception, Constants.PERCEPTION_MATCH, null, typeId);
        FillCheckBoxList(CheckBoxListDriverSize, Constants.DRIVER_SIZE, null, typeId);
        FillCheckBoxList(DropDownListMaintanance, Constants.MAINTANANCE, null, typeId);
        FillCheckBoxList(DropDownListFuelConsume, Constants.FEUL_CONSUMING, null, typeId);
        FillCheckBoxList(DropDownListSafety, Constants.SAFETY, null, typeId);
        FillCheckBoxList(DropDownListMultiDriver, Constants.MULTI_DRIVER, null, typeId);
        FillCheckBoxList(ddSurface, Constants.ROAD, null, typeId);
        FillCheckBoxList(ddVisualPerspective, Constants.VISUAL_SPACE, null, typeId);
        FillCheckBoxList(ddIgnition, Constants.IGNITION, null, typeId);
    }
    private void InitLists(Cars car, int typeId)
    {
        FillDropDownList2(DropDownListYear, Constants.YEAR, car.YEAR);
        FillDropDownList2(DropDownListCountry, Constants.COUNTRY, car.COUNTRY);
        FillCheckBoxList(ddSeats, Constants.SEATS, car.SEATS, typeId);
        FillCheckBoxList(DropDownListDors, Constants.DORS, car.DORS, typeId);
        FillCheckBoxList(ddFeulType, Constants.FEUL_TYPE, car.FUEL_TYPE, typeId);
        FillCheckBoxList(CheckBoxListGeer, Constants.GEAR, car.GEER, typeId);
        FillCheckBoxList(DropDownListCarSize, Constants.CAR_SIZE, car.SIZE, typeId);
        FillCheckBoxList(DropDownListTrunkSize, Constants.TRUNK_SIZE, car.TRUNK, typeId);
        FillCheckBoxList(DropDownListAccessoriesLevel, Constants.FEATURES, car.ACCESSORY, typeId);
        FillCheckBoxList(DropDownListResponse, Constants.RESPONSE, car.RESPONSE, typeId);

        var result = admin.GetCarMultiAnswer(carId, Constants.PERCEPTION_MATCH);
        FillMultiCheckBoxList(CheckBoxListPerception, Constants.PERCEPTION_MATCH, result, typeId);
        result = admin.GetCarMultiAnswer(carId, Constants.DRIVER_SIZE);
        FillMultiCheckBoxList(CheckBoxListDriverSize, Constants.DRIVER_SIZE, result, typeId);
        FillCheckBoxList(DropDownListMaintanance, Constants.MAINTANANCE, car.MAINTANANCE, typeId);
        FillCheckBoxList(DropDownListFuelConsume, Constants.FEUL_CONSUMING, car.FUEL_CONSUME, typeId);
        FillCheckBoxList(DropDownListSafety, Constants.SAFETY, car.SECURE, typeId);
        FillCheckBoxList(DropDownListMultiDriver, Constants.MULTI_DRIVER, car.MULTI_DRIVER, typeId);
        FillCheckBoxList(ddSurface, Constants.ROAD, car.ROAD, typeId);
        FillCheckBoxList(ddVisualPerspective, Constants.VISUAL_SPACE, car.VISUAL_SPACE, typeId);
        FillCheckBoxList(ddIgnition, Constants.IGNITION, car.IGNITION, typeId);
    }
    private void FillCheckBoxList(ListControl list, int id, int? value, int typeId)
    {
        list.DataSource = admin.GetAnswer(typeId, id);
        list.DataTextField = "NAME";
        list.DataValueField = "ID";
        list.DataBind();

        if (value.HasValue)
        {
            list.SelectedValue = value.Value.ToString();
        }
    }
    private void FillMultiCheckBoxList(ListControl list, int id, List<int> values, int typeId)
    {
        list.DataSource = admin.GetAnswer(typeId, id);
        list.DataTextField = "NAME";
        list.DataValueField = "ID";
        list.DataBind();

        foreach(int value in values)
        {
            ListItem item = list.Items.FindByValue(value.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }
    }
    private void FillDropDownList(DropDownList dropDownList, int id, int? defaultValue, int typeId)
    {
        dropDownList.DataSource = admin.GetAnswer(typeId, id);
        dropDownList.DataTextField = "NAME";
        dropDownList.DataValueField = "ID";
        dropDownList.DataBind();

        if (defaultValue.HasValue)
            dropDownList.SelectedValue = defaultValue.Value.ToString();
    }
    private void FillDropDownList2(DropDownList dropDownList, int id, int? defaultValue)
    {
        dropDownList.DataTextField = "VALUE";
        dropDownList.DataValueField = "ID";
        dropDownList.DataSource = admin.GetLookupDetails(id);
        dropDownList.DataBind();

        if (defaultValue.HasValue)
            dropDownList.SelectedValue = defaultValue.Value.ToString();
    }
    protected void DropDownListManufactor_SelectedIndexChanged(object sender, EventArgs e)
    {
        int carMannufactorerId = string.IsNullOrEmpty(DropDownListManufactor.SelectedValue) ? 0 : int.Parse(DropDownListManufactor.SelectedValue);

        DropDownListModel.DataSource = admin.GetCarModels(carMannufactorerId);
        DropDownListModel.DataBind();

        int carModelId = string.IsNullOrEmpty(DropDownListModel.SelectedValue) ? 0 : int.Parse(DropDownListModel.SelectedValue);

        DropDownListSubModel.DataSource = admin.GetCarSubModels(carMannufactorerId, carModelId);
        DropDownListSubModel.DataBind();
    }
    protected void ddMainTypeChanged(object sender, EventArgs e)
    {
        int carMainType;
        int.TryParse(ddMainType.SelectedValue, out carMainType);

        ddSubType.DataSource = admin.GetSubTypes(carMainType);
        ddSubType.DataBind();

        InitLists(carMainType);
    }
    protected void DropDownListModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListSubModel.DataSource = admin.GetCarSubModels(int.Parse(DropDownListManufactor.SelectedValue), int.Parse(DropDownListModel.SelectedValue));
        DropDownListSubModel.DataBind();
    }
    public void Add()
    {
        int price;
        int.TryParse(TextBoxPrice.Text, out price);

        switch (Convert.ToInt32(ddMainType.SelectedValue)) 
        {
            case Constants.PRIVATE:
                Private privateCar = new Private
                {
                    Manufactor = Convert.ToInt32(DropDownListManufactor.SelectedValue),
                    Model = Convert.ToInt32(DropDownListModel.SelectedValue),
                    SubModel = Convert.ToInt32(DropDownListSubModel.SelectedValue),
                    Year = Convert.ToInt32(DropDownListYear.SelectedValue),
                    Counry = Convert.ToInt32(DropDownListCountry.SelectedValue),
                    MainType = Convert.ToInt32(ddMainType.SelectedValue),
                    SubType = Convert.ToInt32(ddSubType.SelectedValue),
                    FuelType = Convert.ToInt32(ddFeulType.SelectedValue),
                    Geer = Convert.ToInt32(CheckBoxListGeer.SelectedValue),
                    Price = price,
                    Accessory = Convert.ToInt32(DropDownListAccessoriesLevel.SelectedValue),
                    Maintanance = Convert.ToInt32(DropDownListMaintanance.SelectedValue),
                    Secure = Convert.ToInt32(DropDownListSafety.SelectedValue),
                    FuelConsume = Convert.ToInt32(DropDownListFuelConsume.SelectedValue),

                    MultiDriver = Convert.ToInt32(DropDownListMultiDriver.SelectedValue),
                    Size = Convert.ToInt32(DropDownListCarSize.SelectedValue),
                    Perception = GetListItemsIds(CheckBoxListPerception),
                    Driver = GetListItemsIds(CheckBoxListDriverSize),
                    Dors = Convert.ToInt32(DropDownListDors.SelectedValue),
                    Response = Convert.ToInt32(DropDownListResponse.SelectedValue)
                };

                if (!string.IsNullOrEmpty(DropDownListTrunkSize.SelectedValue))
                {
                    privateCar.Trunk = Convert.ToInt32(DropDownListTrunkSize.SelectedValue);
                }

                if (!string.IsNullOrEmpty(ddSeats.SelectedValue))
                {
                    privateCar.Seats = Convert.ToInt32(ddSeats.SelectedValue);
                }

                privateCar.Add();
                break;
            case Constants.SUV:
                Suv suvCar = new Suv()
                {
                    Manufactor = Convert.ToInt32(DropDownListManufactor.SelectedValue),
                    Model = Convert.ToInt32(DropDownListModel.SelectedValue),
                    SubModel = Convert.ToInt32(DropDownListSubModel.SelectedValue),
                    Year = Convert.ToInt32(DropDownListYear.SelectedValue),
                    Counry = Convert.ToInt32(DropDownListCountry.SelectedValue),
                    MainType = Convert.ToInt32(ddMainType.SelectedValue),
                    SubType = Convert.ToInt32(ddSubType.SelectedValue),
                    FuelType = Convert.ToInt32(ddFeulType.SelectedValue),
                    Geer = Convert.ToInt32(CheckBoxListGeer.SelectedValue),
                    Price = price,
                    Accessory = Convert.ToInt32(DropDownListAccessoriesLevel.SelectedValue),
                    Maintanance = Convert.ToInt32(DropDownListMaintanance.SelectedValue),
                    Secure = Convert.ToInt32(DropDownListSafety.SelectedValue),
                    FuelConsume = Convert.ToInt32(DropDownListFuelConsume.SelectedValue),

                    Driver = GetListItemsIds(CheckBoxListDriverSize),
                    Response = Convert.ToInt32(DropDownListResponse.SelectedValue),
                    Surface = Convert.ToInt32(ddSurface.SelectedValue),
                };

                if (!string.IsNullOrEmpty(DropDownListTrunkSize.SelectedValue))
                {
                    suvCar.Trunk = Convert.ToInt32(DropDownListTrunkSize.SelectedValue);
                }

                if (!string.IsNullOrEmpty(ddSeats.SelectedValue))
                {
                    suvCar.Seats = Convert.ToInt32(ddSeats.SelectedValue);
                }

                suvCar.Add();
                break;
            case Constants.PUBLIC:
                Commercial commersialCar = new Commercial()
                {
                    Manufactor = Convert.ToInt32(DropDownListManufactor.SelectedValue),
                    Model = Convert.ToInt32(DropDownListModel.SelectedValue),
                    SubModel = Convert.ToInt32(DropDownListSubModel.SelectedValue),
                    Year = Convert.ToInt32(DropDownListYear.SelectedValue),
                    Counry = Convert.ToInt32(DropDownListCountry.SelectedValue),
                    MainType = Convert.ToInt32(ddMainType.SelectedValue),
                    SubType = Convert.ToInt32(ddSubType.SelectedValue),
                    FuelType = Convert.ToInt32(ddFeulType.SelectedValue),
                    Geer = Convert.ToInt32(CheckBoxListGeer.SelectedValue),
                    Price = price,
                    Accessory = Convert.ToInt32(DropDownListAccessoriesLevel.SelectedValue),
                    Maintanance = Convert.ToInt32(DropDownListMaintanance.SelectedValue),
                    Secure = Convert.ToInt32(DropDownListSafety.SelectedValue),
                    FuelConsume = Convert.ToInt32(DropDownListFuelConsume.SelectedValue),

                    VisualSpace = Convert.ToInt32(ddVisualPerspective.SelectedValue)
                };

                if (!string.IsNullOrEmpty(ddIgnition.SelectedValue))
                {
                    commersialCar.Ignition = Convert.ToInt32(ddIgnition.SelectedValue);
                }

                if (!string.IsNullOrEmpty(DropDownListTrunkSize.SelectedValue))
                {
                    commersialCar.Trunk = Convert.ToInt32(DropDownListTrunkSize.SelectedValue);
                }

                if (!string.IsNullOrEmpty(ddSeats.SelectedValue))
                {
                    commersialCar.Seats = Convert.ToInt32(ddSeats.SelectedValue);
                }

                commersialCar.Add();
                break;
        }
    }
    private List<int> GetListItemsIds(ListControl list)
    {
        return (from ListItem p in list.Items where p.Selected select int.Parse(p.Value)).ToList();
    }

    private List<string> GetCheckedItemsText(CheckBoxList checkBoxList)
    {
        return (from ListItem p in checkBoxList.Items where p.Selected select p.Text).ToList();
    }

    private void InitEdit()
    {
        try
        {
            DropDownListManufactor.DataSource = admin.GetCarManufactors().OrderBy(a => a.NAME);
            DropDownListManufactor.DataBind();
            DropDownListManufactor.SelectedValue = car.MANUFACTOR.ToString();
            int carManufactorer = string.IsNullOrEmpty(DropDownListManufactor.SelectedValue) ? 0 : int.Parse(DropDownListManufactor.SelectedValue);

            DropDownListModel.DataSource = admin.GetCarModels(carManufactorer);
            DropDownListModel.DataBind();
            DropDownListModel.SelectedValue = car.MODEL.ToString();
            int carModelId = string.IsNullOrEmpty(DropDownListModel.SelectedValue) ? 0 : int.Parse(DropDownListModel.SelectedValue);

            DropDownListSubModel.DataSource = admin.GetCarSubModels(carManufactorer, carModelId);
            DropDownListSubModel.DataBind();
            DropDownListSubModel.SelectedValue = car.SUB_MODEL.ToString();

            ddMainType.DataSource = admin.GetMainTypes();
            ddMainType.DataBind();
            ddMainType.SelectedValue = car.MAIN_TYPE.ToString();

            ddSubType.DataSource = admin.GetSubTypes(car.MAIN_TYPE.Value);
            ddSubType.DataBind();
            ddSubType.SelectedValue = car.SUB_TYPE.ToString();

            TextBoxFor.Text = car.OPPINION_FOR;
            TextBoxAgainst.Text = car.OPPINION_AGAINST;
            TextBoxPrice.Text = car.PRICE.ToString();

            InitLists(car, car.MAIN_TYPE.Value);
        }
        catch
        {

        }
    }

    public bool Update(out string error)
    {
        error = string.Empty;
        try
        {
            //int.TryParse(ddMainType.SelectedValue, out car.MainType);
            //int.TryParse(ddSubType.SelectedValue, out car.SubType);
            //int.TryParse(DropDownListManufactor.SelectedValue, out car.Manufactor);
            //int.TryParse(DropDownListModel.SelectedValue, out car.Model);
            //int.TryParse(DropDownListSubModel.SelectedValue, out car.SubModel);

            //car.Country = Convert.ToInt32(DropDownListCountry.SelectedValue);
            //car.Year = Convert.ToInt32(DropDownListYear.SelectedValue);
            //car.Seats = Convert.ToInt32(ddSeats.SelectedValue);
            //car.Dors = Convert.ToInt32(DropDownListDors.SelectedValue);
            //car.Geer = Convert.ToInt32(CheckBoxListGeer.SelectedValue);
            //car.Trunk = Convert.ToInt32(DropDownListTrunkSize.SelectedValue);
            //car.Driver = GetListItemsIds(CheckBoxListDriverSize);
            //car.Response = Convert.ToInt32(DropDownListResponse.SelectedValue);
            //car.FuelType = Convert.ToInt32(ddFeulType.SelectedValue);
            //car.Secure = Convert.ToInt32(DropDownListSafety.SelectedValue);
            //car.FuelConsume = Convert.ToInt32(DropDownListFuelConsume.SelectedValue);
            //car.MultiDriver = Convert.ToInt32(DropDownListMultiDriver.SelectedValue);
            //car.Perception = GetListItemsIds(CheckBoxListPerception);
            //car.Size = Convert.ToInt32(DropDownListCarSize.SelectedValue);
            //car.Maintanance = Convert.ToInt32(DropDownListMaintanance.SelectedValue);
            //car.Description = TextBoxDescription.Text;
            //car.For = TextBoxFor.Text;
            //car.Against = TextBoxAgainst.Text;
            //car.Links = TextBoxLink.Text;
            //car.Accessories = Convert.ToInt32(DropDownListAccessoriesLevel.SelectedValue);

            //int.TryParse(TextBoxPrice.Text, out car.Price);

            admin.UpdateCar();

            return true;
        }
        catch (SqlException exception)
        {
            error = string.Format("Database error: {0}", exception.Message);
            return false;
        }
        catch (Exception exception)
        {
            error = string.Format("General error: {0}", exception.Message);
            return false;
        }
    }
}