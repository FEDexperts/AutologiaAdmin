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
    Cars car = null;
    Admin admin = new Admin();
    int carId = 0;

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
        if (Request.QueryString != null && Request.QueryString["id"] != null)
        {
            carId = Convert.ToInt32(Request.QueryString["id"]);
            car = admin.GetCar(carId);
        }

        if (!IsPostBack)
        {
            if (carId != 0)
            {
                EditType = EditTypeCode.EtModify;
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

        DropDownListYear.DataSource = admin.GetYears(1970, 100);
        DropDownListYear.DataBind();

        InitLists();
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

            DropDownListYear.DataSource = admin.GetYears(1980, 100);
            DropDownListYear.DataBind();
            DropDownListYear.SelectedValue = car.YEAR.ToString();

            TextBoxFor.Text = car.OPPINION_FOR;
            TextBoxAgainst.Text = car.OPPINION_AGAINST;
            TextBoxPrice.Text = car.PRICE.ToString();

            InitLists();
        }
        catch
        {

        }
    }

    private void InitLists()
    {
        FillDropDownList(DropDownListCountry, Constants.COUNTRY, car == null ? null : car.COUNTRY);
        FillCheckBoxList(ddSeats, Constants.SEATS, car == null ? null : car.SEATS);
        FillCheckBoxList(DropDownListDors, Constants.DORS, car == null ? null : car.DORS);
        FillCheckBoxList(ddFeulType, Constants.FEUL_TYPE, car == null ? null : car.FUEL_TYPE);
        FillCheckBoxList(CheckBoxListGeer, Constants.GEAR, car == null ? -1 : car.GEER);
        FillCheckBoxList(DropDownListCarSize, Constants.CAR_SIZE, car == null ? null : car.SIZE);
        FillCheckBoxList(DropDownListTrunkSize, Constants.TRUNK_SIZE, car == null ? null : car.TRUNK);
        FillCheckBoxList(DropDownListAccessoriesLevel, Constants.FEATURES, car == null ? null : car.ACCESSORY);
        FillCheckBoxList(DropDownListResponse, Constants.RESPONSE, car == null ? null : car.RESPONSE);

        var result = admin.GetCarMultiAnswer(carId, Constants.PERCEPTION_MATCH);
        FillMultiCheckBoxList(CheckBoxListPerception, Constants.PERCEPTION_MATCH, result);
        result = admin.GetCarMultiAnswer(carId, Constants.DRIVER_SIZE);
        FillMultiCheckBoxList(CheckBoxListDriverSize, Constants.DRIVER_SIZE, result);

        FillCheckBoxList(DropDownListMaintanance, Constants.MAINTANANCE, car == null ? null : car.MAINTANANCE);
        FillCheckBoxList(DropDownListFuelConsume, Constants.FEUL_CONSUMING, car == null ? null : car.FUEL_CONSUME);
        FillCheckBoxList(DropDownListSafety, Constants.SAFETY, car == null ? null : car.SECURE);
        FillCheckBoxList(DropDownListMultiDriver, Constants.MULTI_DRIVER, car == null ? null : car.MULTI_DRIVER);
        FillCheckBoxList(ddSurface, Constants.ROAD, car == null ? null : car.ROAD);
        FillCheckBoxList(ddVisualPerspective, Constants.VISUAL_SPACE, car == null ? null : car.VISUAL_SPACE);
        FillCheckBoxList(ddIgnition, Constants.IGNITION, car == null ? null : car.IGNITION);
    }

    private void FillCheckBoxList(ListControl list, int id, int? value)
    {
        int carMainType;
        int.TryParse(ddMainType.SelectedValue, out carMainType);

        list.DataSource = admin.GetAnswer(car == null ? carMainType : car.MAIN_TYPE.Value, id);
        list.DataTextField = "NAME";
        list.DataValueField = "ID";
        list.DataBind();

        if (value.HasValue && value.Value != -1)
        {
            list.SelectedValue = value.Value.ToString();
        }
    }

    private void FillMultiCheckBoxList(ListControl list, int id, List<int> values)
    {
        int carMainType;
        int.TryParse(ddMainType.SelectedValue, out carMainType);

        list.DataSource = admin.GetAnswer(car == null ? carMainType : car.MAIN_TYPE.Value, id);
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

    private void FillDropDownList(DropDownList dropDownList, int id, int? defaultValue)
    {
        int carMainType;
        int.TryParse(ddMainType.SelectedValue, out carMainType);

        dropDownList.DataSource = admin.GetAnswer(car == null ? carMainType : car.MAIN_TYPE.Value, id);
        dropDownList.DataTextField = "NAME";
        dropDownList.DataValueField = "ID";
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

        InitLists();
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

    public bool Update(out string error)
    {
        error = string.Empty;
        try
        {
            car.MAIN_TYPE = Convert.ToInt32(ddMainType.SelectedValue);
            car.SUB_TYPE = Convert.ToInt32(ddSubType.SelectedValue);
            car.MANUFACTOR = Convert.ToInt32(DropDownListManufactor.SelectedValue);
            car.MODEL = Convert.ToInt32(DropDownListModel.SelectedValue);
            car.SUB_MODEL = Convert.ToInt32(DropDownListSubModel.SelectedValue);

            car.COUNTRY = Convert.ToInt32(DropDownListCountry.SelectedValue);
            car.YEAR = Convert.ToInt32(DropDownListYear.SelectedValue);
            car.SEATS = Convert.ToInt32(ddSeats.SelectedValue);
            car.DORS = Convert.ToInt32(DropDownListDors.SelectedValue);
            car.GEER = Convert.ToInt32(CheckBoxListGeer.SelectedValue);
            car.TRUNK = Convert.ToInt32(DropDownListTrunkSize.SelectedValue);
            car.RESPONSE = Convert.ToInt32(DropDownListResponse.SelectedValue);
            car.FUEL_TYPE = Convert.ToInt32(ddFeulType.SelectedValue);
            car.SECURE = Convert.ToInt32(DropDownListSafety.SelectedValue);
            car.FUEL_CONSUME = Convert.ToInt32(DropDownListFuelConsume.SelectedValue);
            car.MULTI_DRIVER = Convert.ToInt32(DropDownListMultiDriver.SelectedValue);
            car.SIZE = Convert.ToInt32(DropDownListCarSize.SelectedValue);
            car.MAINTANANCE = Convert.ToInt32(DropDownListMaintanance.SelectedValue);
            car.DESCRIPTION = TextBoxDescription.Text;
            car.OPPINION_FOR = TextBoxFor.Text;
            car.OPPINION_AGAINST = TextBoxAgainst.Text;
            car.LINKS = TextBoxLink.Text;
            car.ACCESSORY = Convert.ToInt32(DropDownListAccessoriesLevel.SelectedValue);

            car.PRICE = Convert.ToInt32(TextBoxPrice.Text);

            //car.Driver = GetListItemsIds(CheckBoxListDriverSize);
            //car.Perception = GetListItemsIds(CheckBoxListPerception);

            admin.UpdateCar(car);

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