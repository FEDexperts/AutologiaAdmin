using AutologiaDataAccess;
using System.Collections.Generic;

namespace AutologiaShare
{
    //public class CarBL
    //{

    //    //private Car car;
    //    public string Error;

    //    private readonly List<string> filter = new List<string>();
    //    //private DataRow[] filteredResult;
    //    private List<DataRow> resultsList = new List<DataRow>();
    //    //private DataTable results;

    //    public CarBL()
    //    {
    //        //car = new Car();
    //    }

    //    public void Add(
    //        int manufactor,
    //        int model,
    //        int year,
    //        int counry,
    //        int mainType,
    //        int subType,
    //        int seats,
    //        int dors,
    //        int fuelType,
    //        int geer,
    //        int size,
    //        int trunk,
    //        int accessory,
    //        int response,
    //        int perception,
    //        int driver,
    //        int maintanance,
    //        int fuelConsume,
    //        int secure,
    //        string description,
    //        int multiDriver,
    //        int subModel,
    //        string forOppinon,
    //        string againstOppinon,
    //        string uniqueIdentifier,
    //        int price)
    //    {
    //        //car.Add(manufactor, model, subModel, year, counry, mainType, subType,
    //        //        seats, dors, fuelType, geer, size, trunk, accessory, response,
    //        //        perception, driver, maintanance,
    //        //        fuelConsume, secure,
    //        //        description, multiDriver,
    //        //        forOppinon, againstOppinon, uniqueIdentifier, price);


    //        //using (Model ctx = new Model())
    //        //{
    //        //    ctx.Database.SqlQuery<Car>("spAddCar " + 
    //        //        "@MANUFACTOR, @MODEL, @SUB_MODEL, @YEAR, @COUNTRY, @MAIN_TYPE, @SUB_TYPE, " +
    //        //        "@SEATS, @DORS, @FUEL_TYPE, @GEER, @SIZE, @TRUNK, @ACCESSORY, @RESPONSE, " +
    //        //        "@MAINTANANCE, @SECURE, " +
    //        //        "@DESCRIPTION, @MULTI_DRIVER, " +
    //        //        "@PRICE, @OPPINION_FOR, @OPPINION_AGAINST, @UNIQUE_IDENTIFIER, " + 
    //        //        "@FUEL_CONSUME", manufactor, model, subModel, year, counry, mainType, subType,
    //        //        seats, dors, maintanance, secure, description, multiDriver, price, forOppinon, 
    //        //        againstOppinon, uniqueIdentifier, fuelConsume);
    //        //}

    //    }

    //    //public List<string> GetManufacturs()
    //    //{
    //    //    List<string> list = new List<string>();
    //    //    DataTable results = car.GetManufacturs();
    //    //    foreach (DataRow row in results.Rows)
    //    //    {
    //    //        list.Add(row["NAME"].ToString());
    //    //    }
    //    //    return list;
    //    //}

    //    //public CarManufactor GetManufactor(int manufactorId)
    //    //{
    //    //    using (AutologiaModel ctx = new AutologiaModel())
    //    //    {
    //    //        return ctx.CarManufactors.SingleOrDefault(x => x.ID == manufactorId);
    //    //    }
    //    //}

    //    //public void DeleteManufactors()
    //    //{
    //    //    car.DeleteManufactors();
    //    //}

    //    //public void AddManufactor(string value)
    //    //{
    //    //    car.AddManufactor(value);
    //    //}

    //    //public void DeleteModels(int manufactorId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        IEnumerable<CarModel> carModels = GetModels(manufactorId);
    //    //        ctx.CarModel.RemoveRange(carModels);
    //    //    }
    //    //}

    //    //public void AddModel(string value, int manufactorKey)
    //    //{
    //    //    car.AddModel(value, manufactorKey);
    //    //}

    //    //public void UpdateModel(int key, string value, int manufactorKey)
    //    //{
    //    //    car.UpdateModel(key, value, manufactorKey);
    //    //}

    //    //public IEnumerable<CarModel> GetModels(int manufactorId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        return ctx.CarModel.Where(x => x.MANUFACTOR_ID == manufactorId);
    //    //    }
    //    //}

    //    //public CarModel GetModel(int modelId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        CarModel carModel = ctx.CarModel.SingleOrDefault(x => x.ID == modelId);
    //    //        return carModel;
    //    //    }
    //    //}

    //    //public CarSubModel GetSubModel(int subModelId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        return ctx.CarSubModel.SingleOrDefault(x => x.ID == subModelId);
    //    //    }
    //    //}

    //    //public IEnumerable<CarSubModel> GetSubModels(int manufactorId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        return ctx.CarSubModel.Where(x => x.MANUFACTOR_ID == manufactorId);
    //    //    }
    //    //}

    //    //public List<CarSubModel> GetSubModels(int manufactorId, int modelId)
    //    //{
    //    //    using (AutologiaModel ctx = new AutologiaModel())
    //    //    {
    //    //        return (ctx.CarSubModel.Where(x => x.MANUFACTOR_ID == manufactorId && x.MODEL_ID == modelId)).ToList();
    //    //    }
    //    //}

    //    //public List<MainType> GetMainTypes()
    //    //{
    //    //    List<MainType> list = new List<MainType>();
    //    //    DataTable results = car.GetMainTypes();
    //    //    foreach (DataRow row in results.Rows)
    //    //    {
    //    //        var mainType = new MainType
    //    //        {
    //    //            Id = int.Parse(row["ID"].ToString()),
    //    //            Description = row["DESCRIPTION"].ToString()
    //    //        };
    //    //        list.Add(mainType);
    //    //    }
    //    //    return list;
    //    //}

    //    //public void DeleteMainTypes()
    //    //{
    //    //    car.DeleteMainTypes();
    //    //}

    //    //public void AddMainType(string value)
    //    //{
    //    //    car.AddMainType(value);
    //    //}

    //    //public List<SubType> GetSubTypes(int mainKey)
    //    //{
    //    //    List<SubType> list = new List<SubType>();
    //    //    DataTable results = car.GetSubTypes(mainKey);

    //    //    list = (from DataRow row in results.Rows
    //    //            select
    //    //                new SubType
    //    //                {
    //    //                    Id = int.Parse(row["ID"].ToString()),
    //    //                    Description = row["DESCRIPTION"].ToString()
    //    //                }).
    //    //        ToList();
    //    //    return list;
    //    //}

    //    //public void DeleteSubTypes(int mainKey)
    //    //{
    //    //    car.DeleteSubTypes(mainKey);
    //    //}

    //    //public void AddSubType(int mainKey, int key, string value)
    //    //{
    //    //    car.AddSubType(mainKey, key, value);
    //    //}

    //    //public void DeleteSubModels(int manufactorId)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        IEnumerable<CarSubModel> subModels = GetSubModels(manufactorId);
    //    //        ctx.CarSubModel.RemoveRange(subModels);
    //    //    }
    //    //}

    //    //public void DeleteSubModels(int manufactorId, int modelId)
    //    //{
    //    //    using (AutologiaModel ctx = new AutologiaModel())
    //    //    {
    //    //        IEnumerable<CarSubModel> subModels = ctx.CarSubModel.Where(x => x.MANUFACTOR_ID == manufactorId && x.MODEL_ID == modelId);
    //    //        ctx.CarSubModel.RemoveRange(subModels);
    //    //    }
    //    //}

    //    //public void DeleteSubModels(IEnumerable<CarSubModel> subModels)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        ctx.CarSubModel.RemoveRange(subModels);
    //    //    }
    //    //}

    //    //public void AddSubModel(string value, int manufactorKey, int modelKey, string smallImage, string bigImage)
    //    //{
    //    //    car.AddSubModel(value, manufactorKey, modelKey, smallImage, bigImage);
    //    //}

    //    //public void UpdateSubModel(int key, string value, int manufactorKey, int modelKey, string smallImage, string bigImage)
    //    //{
    //    //    car.UpdateSubModel(key, value, manufactorKey, modelKey, smallImage, bigImage);
    //    //}

    //    ////public DataTable GetCars()
    //    ////{
    //    ////    return car.GetCars();
    //    ////}

    //    //public List<object> GetCars()
    //    //{
    //    //    return car.GetCars();
    //    //}

    //    //public DataTable GetCars(int manufactor, int model, int subModel, int mainType, int subType, int year)
    //    //{
    //    //    DataTable cars = car.GetCars(manufactor, model, subModel, mainType, subType, year);
    //    //    return cars;
    //    //}

    //    //public DataTable GetCarsEx(int carId, int mainLookup)
    //    //{
    //    //    return car.GetCarsEx(carId, mainLookup);
    //    //}

    //    //private int hasIntValue(int? value)
    //    //{
    //    //    return value.HasValue ? value.Value : 0;
    //    //}

    //    //public CarItem GetCar(int carId)
    //    //{
    //    //    CarItem carItem = new CarItem();
    //    //    Car c = car.GetCar(carId);

    //    //    carItem.Id = c.ID;
    //    //    carItem.Manufactor = c.MANUFACTOR;
    //    //    carItem.Model = c.MODEL;
    //    //    carItem.SubModel = c.SUB_MODEL;
    //    //    carItem.Year = c.YEAR;
    //    //    carItem.Country = hasIntValue(c.COUNTRY);
    //    //    carItem.MainType = hasIntValue(c.MAIN_TYPE);
    //    //    carItem.SubType = hasIntValue(c.SUB_TYPE);
    //    //    carItem.License = hasIntValue(c.LICENSE);
    //    //    carItem.Seats = hasIntValue(c.SEATS);
    //    //    carItem.Dors = hasIntValue(c.DORS);
    //    //    carItem.FuelType = hasIntValue(c.FUEL_TYPE);
    //    //    carItem.Geer = hasIntValue(c.GEER);
    //    //    carItem.Size = hasIntValue(c.SIZE);
    //    //    carItem.Trunk = hasIntValue(c.TRUNK);
    //    //    carItem.Accessories = hasIntValue(c.ACCESSORY);
    //    //    carItem.Response = hasIntValue(c.RESPONSE);
    //    //    carItem.Perception = car.GetCarAnsweIdsr(10, carId);
    //    //    carItem.Driver = car.GetCarAnsweIdsr(11, carId);
    //    //    carItem.Seat5 = hasIntValue(c.SEAT_5);
    //    //    carItem.VisualSpace = hasIntValue(c.VISUAL_SPACE);
    //    //    carItem.Road = hasIntValue(c.ROAD);
    //    //    carItem.Maintanance = hasIntValue(c.MAINTANANCE);
    //    //    carItem.Reliability = hasIntValue(c.RELIABILITY);
    //    //    carItem.FuelConsume = hasIntValue(c.FUEL_CONSUME);
    //    //    //carItem.Trade = hasIntValue(c.TRADE);
    //    //    carItem.Value = hasIntValue(c.VALUE);
    //    //    carItem.Secure = hasIntValue(c.SECURE);
    //    //    //carItem.GasCompatible = hasIntValue(c.GAS_COMPATIBLE);
    //    //    carItem.Ignition = hasIntValue(c.IGNITION);
    //    //    //carItem.HeatStand = hasIntValue(c.HEAT_STAND);
    //    //    //carItem.Smokers = hasIntValue(c.SMOKERS);
    //    //    carItem.Description = c.DESCRIPTION;
    //    //    carItem.SurfaceCompatible = hasIntValue(c.AVIRUT_SHETAH);
    //    //    carItem.MultiDriver = hasIntValue(c.MULTI_DRIVER);
    //    //    carItem.Price = hasIntValue(c.PRICE);
    //    //    carItem.For = c.OPPINION_FOR;
    //    //    carItem.Against = c.OPPINION_AGAINST;
    //    //    carItem.Links = c.LINKS;
    //    //    carItem.Body = hasIntValue(c.BODY);

    //    //    //carItem.ManufactorDesc = c.MANUFACTOR_DESC;
    //    //    //carItem.ModelDesc = row["MODEL_DESC"].ToString();
    //    //    //carItem.SubModelDesc = row["SUB_MODEL_DESC"].ToString();
    //    //    //carItem.YearDesc = row["YEAR_DESC"].ToString();
    //    //    //carItem.MainTypeDesc = row["MAIN_TYPE_DESC"].ToString();
    //    //    //carItem.SubTypeDesc = row["SUB_TYPE_DESC"].ToString();

    //    //    //carItem.SmallImage = row["SMALL_IMAGE"].ToString();
    //    //    //carItem.BigImage = row["BIG_IMAGE"].ToString();

    //    //    carItem.For = c.OPPINION_FOR;
    //    //    carItem.Against = c.OPPINION_AGAINST;
    //    //    return carItem;
    //    //}

    //    //public ClsCarDescriptionInfo GetCarDesc(int carId)
    //    //{
    //    //    var carDesc = new ClsCarDescriptionInfo();
    //    //    DataTable dt = car.Search(carId);
    //    //    if (dt.Rows.Count == 1)
    //    //    {
    //    //        DataRow row = dt.Rows[0];
    //    //        carDesc.Id = row["ID"].ToString();
    //    //        carDesc.Manufactor = row["MANUFACTOR_VALUE"].ToString();
    //    //        carDesc.Model = row["MODEL_VALUE"].ToString();
    //    //        carDesc.SubModel = row["SUB_MODEL_VALUE"].ToString();
    //    //        carDesc.Year = row["YEAR_VALUE"].ToString();
    //    //        carDesc.Country = row["COUNTRY_VALUE"].ToString();
    //    //        carDesc.MainType = row["MAIN_TYPE_VALUE"].ToString();
    //    //        carDesc.SubType = row["SUB_TYPE_VALUE"].ToString();
    //    //        carDesc.License = row["LICENSE_VALUE"].ToString();
    //    //        carDesc.Seats = row["SEATS_VALUE"].ToString();
    //    //        carDesc.Dors = row["DORS_VALUE"].ToString();
    //    //        carDesc.FuelType = row["FUEL_TYPE_VALUE"].ToString();
    //    //        carDesc.Geer = row["GEER_VALUE"].ToString();
    //    //        carDesc.Size = row["SIZE_VALUE"].ToString();
    //    //        carDesc.Trunk = row["TRUNK_VALUE"].ToString();
    //    //        carDesc.Accessories = row["ACCESSORY_VALUE"].ToString();
    //    //        carDesc.Additions = row["ADDITION_VALUE"].ToString();
    //    //        carDesc.Response = row["RESPONSE_VALUE"].ToString();
    //    //        carDesc.Perception = row["PERCEPTION_VALUE"].ToString();
    //    //        carDesc.Driver = row["DRIVER_VALUE"].ToString();
    //    //        carDesc.Seat5 = row["SEAT_5_VALUE"].ToString();
    //    //        carDesc.VisualSpace = row["VISUAL_SPACE_VALUE"].ToString();
    //    //        carDesc.Weal = row["WEAL_VALUE"].ToString();
    //    //        carDesc.Road = row["ROAD_VALUE"].ToString();
    //    //        carDesc.Maintanance = row["MAINTANANCE_VALUE"].ToString();
    //    //        carDesc.Reliability = row["RELIABILITY_VALUE"].ToString();
    //    //        carDesc.Fuel = row["FUEL_VALUE"].ToString();
    //    //        carDesc.Trade = row["TRADE_VALUE"].ToString();
    //    //        carDesc.Value = row["VALUE_VALUE"].ToString();
    //    //        carDesc.Secure = row["SECURE_VALUE"].ToString();
    //    //        carDesc.Handiccape = row["HANDICAPPE_VALUE"].ToString();
    //    //        carDesc.GasCompatible = row["GAS_COMPATIBLE_VALUE"].ToString();
    //    //        carDesc.Ignition = row["IGNITION_VALUE"].ToString();
    //    //        carDesc.HeatStand = row["HEAT_STAND_VALUE"].ToString();
    //    //        carDesc.Smokers = row["SMOKERS_VALUE"].ToString();
    //    //        carDesc.Description = row["DESCRIPTION_VALUE"].ToString();
    //    //        carDesc.SurfaceCompatible = row["SURFACE_COMPATIBLE_VALUE"].ToString();
    //    //        carDesc.MultiDriver = row["MULTI_DRIVER_VALUE"].ToString();
    //    //        carDesc.DriverLimits = row["DRIVER_LIMITS_VALUE"].ToString();
    //    //        carDesc.Price = row["PRICE"].ToString();
    //    //        carDesc.For = row["OPPINION_FOR"].ToString();
    //    //        carDesc.Against = row["OPPINION_AGAINST"].ToString();
    //    //        carDesc.Links = row["LINKS"].ToString();
    //    //        carDesc.ModelSmallImage = row["SMALL_IMAGE"].ToString();
    //    //        carDesc.ModelBigImage = row["BIG_IMAGE"].ToString();
    //    //    }
    //    //    return carDesc;
    //    //}

    //    //public void Update(CarItem carItem)
    //    //{
    //    //    car.Update(carItem);

    //    //    //var adapter = new CarsTableAdapter();
    //    //    //try
    //    //    //{
    //    //    //    var row = (from p in adapter.GetData() where p.ID == carItem.Id select p).Single();

    //    //    //    row.MANUFACTOR = carItem.Manufactor;
    //    //    //    row.MODEL = carItem.Model;
    //    //    //    row.YEAR = carItem.Year;
    //    //    //    row.COUNTRY = carItem.Country;
    //    //    //    row.MAIN_TYPE = carItem.MainType;
    //    //    //    row.SUB_TYPE = carItem.SubType;
    //    //    //    row.LICENSE = carItem.License;
    //    //    //    row.SEATS = carItem.Seats;
    //    //    //    row.DORS = carItem.Dors;
    //    //    //    row.FUEL_TYPE = carItem.FuelType;
    //    //    //    row.GEER = CarItem.ToCommaString(carItem.Geer);
    //    //    //    row.SIZE = carItem.Size;
    //    //    //    row.TRUNK = carItem.Trunk;
    //    //    //    row.ACCESSORY = carItem.Accessories;
    //    //    //    row.RESPONSE = carItem.Response;
    //    //    //    row.PERCEPTION = CarItem.ToCommaString(carItem.Perception);
    //    //    //    row.DRIVER = CarItem.ToCommaString(carItem.Driver);
    //    //    //    row.SEAT_5 = carItem.Seat5;
    //    //    //    row.VISUAL_SPACE = carItem.VisualSpace;
    //    //    //    row.ROAD = carItem.Road;
    //    //    //    row.MAINTANANCE = carItem.Maintanance;
    //    //    //    row.RELIABILITY = carItem.Reliability;
    //    //    //    row.FUEL_CONSUME = carItem.FuelConsume;
    //    //    //    row.TRADE = carItem.Trade;
    //    //    //    row.VALUE = carItem.Value;
    //    //    //    row.SECURE = carItem.Secure;
    //    //    //    row.GAS_COMPATIBLE = carItem.GasCompatible;
    //    //    //    row.IGNITION = carItem.Ignition;
    //    //    //    row.HEAT_STAND = carItem.HeatStand;
    //    //    //    row.SMOKERS = carItem.Smokers;
    //    //    //    row.DESCRIPTION = carItem.Description;
    //    //    //    row.AVIRUT_SHETAH = carItem.SurfaceCompatible;
    //    //    //    row.MULTI_DRIVER = carItem.MultiDriver;
    //    //    //    //row.PRICE = car.Price;
    //    //    //    row.SUB_MODEL = carItem.SubModel;
    //    //    //    row.OPPINION_FOR = carItem.For;
    //    //    //    row.OPPINION_AGAINST = carItem.Against;
    //    //    //    row.LINKS = carItem.Links;
    //    //    //    row.BODY = carItem.Body;

    //    //    //    //row.MANUFACTOR_DESC = car.ManufactorDesc;
    //    //    //    //row.MODEL_DESC = car.ModelDesc;
    //    //    //    //row.YEAR_DESC = car.YearDesc;
    //    //    //    //row.COUNTRY_DESC = car.CountryDesc;
    //    //    //    //row.MAIN_TYPE_DESC = car.MainTypeDesc;
    //    //    //    //row.SUB_TYPE_DESC = car.SubTypeDesc;
    //    //    //    //row.LICENSE_DESC = car.LicenseDesc;
    //    //    //    //row.SEATS_DESC = car.SeatsDesc;
    //    //    //    //row.DORS_DESC = car.DorsDesc;
    //    //    //    //row.FUEL_TYPE_DESC = car.FuelTypeDesc;
    //    //    //    //row.GEER_DESC = CarItem.ToCommaString(car.GeerDesc);
    //    //    //    //row.SIZE_DESC = car.SizeDesc;
    //    //    //    //row.TRUNK_DESC = car.TrunkDesc;
    //    //    //    //row.ACCESSORY_DESC = car.AccessoriesDesc;
    //    //    //    //row.RESPONSE_DESC = car.ResponseDesc;
    //    //    //    //row.PERCEPTION_DESC = CarItem.ToCommaString(car.PerceptionDesc);
    //    //    //    //row.DRIVER_DESC = CarItem.ToCommaString(car.DriverDesc);
    //    //    //    //row.SEAT_5_DESC = car.Seat5Desc;
    //    //    //    //row.VISUAL_SPACE_DESC = car.VisualSpaceDesc;
    //    //    //    //row.ROAD_DESC = car.RoadDesc;
    //    //    //    //row.MAINTANANCE_DESC = car.MaintananceDesc;
    //    //    //    //row.RELIABILITY_DESC = car.ReliabilityDesc;
    //    //    //    //row.FEUL_CONSUME_DESC = car.FuelConsumeDesc;
    //    //    //    //row.TRADE_DESC = car.TradeDesc;
    //    //    //    //row.VALUE_DESC = car.ValueDesc;
    //    //    //    //row.SECURE_DESC = car.SecureDesc;
    //    //    //    //row.GAS_COMPATIBLE_DESC = car.GasCompatibleDesc;
    //    //    //    //row.IGNITION_DESC = car.IgnitionDesc;
    //    //    //    //row.HEAT_STAND_DESC = car.HeatStandDesc;
    //    //    //    //row.SMOKERS_DESC = car.SmokersDesc;
    //    //    //    //row.AVIRUT_SHETAH_DESC = car.SurfaceCompatibleDesc;
    //    //    //    //row.MULTI_DRIVER_DESC = car.MultiDriverDesc;
    //    //    //    //row.SUB_MODEL_DESC = car.SubModelDesc;

    //    //    //    adapter.Update(row);
    //    //    //}
    //    //    //catch (Exception)
    //    //    //{
    //    //    //}
    //    //}

    //    //public MainType GetMainType(int mainId)
    //    //{
    //    //    DataTable result = car.GetMainTypes();
    //    //    var mainType = new MainType();
    //    //    DataRow[] select = result.Select("ID=" + mainId);
    //    //    if (select.Length == 1)
    //    //    {
    //    //        mainType.Id = int.Parse(select[0]["ID"].ToString());
    //    //        mainType.Description = select[0]["DESCRIPTION"].ToString();
    //    //    }
    //    //    return mainType;
    //    //}


    //    //public SubType GetSubType(int mainKey, int key)
    //    //{
    //    //    var result = car.GetSubType(mainKey, key);
    //    //    var subType = new SubType();
    //    //    if (result != null && result.Rows.Count == 1)
    //    //    {
    //    //        subType.Id = int.Parse(result.Rows[0]["ID"].ToString());
    //    //        subType.MainId = int.Parse(result.Rows[0]["MAIN_ID"].ToString());
    //    //        subType.Description = result.Rows[0]["DESCRIPTION"].ToString();
    //    //    }
    //    //    return subType;
    //    //}

    //    //public DataTable GetMySearches(int userId)
    //    //{
    //    //    return car.GetMySearches(userId);
    //    //}

    //    //public void DeleteSearch(string p)
    //    //{
    //    //    car.DeleteSearch(p);
    //    //}

    //    //public void Delete(int id)
    //    //{
    //    //    car.Delete(id);
    //    //}

    //    //public void UpdateManufactor(int id, string name, string link, string image)
    //    //{
    //    //    using (var ctx = new Model())
    //    //    {
    //    //        CarManufactors manufactor = ctx.CarManufactors.SingleOrDefault(x => x.ID == id);
    //    //        if (manufactor != null)
    //    //        {
    //    //            manufactor.NAME = name;
    //    //            manufactor.LINK = link;
    //    //            manufactor.LINK = image;
    //    //            ctx.SaveChanges();
    //    //        }
    //    //    }
    //    //}

    //    //public DataTable Search(CarSearchRequest carSearchRequest)
    //    //{
    //    //    int minPrice;
    //    //    int maxPrice;
    //    //    SearchCarMenuItem menuItem = new Menu().GetMenuItem(carSearchRequest.Items.Find(r => r.Key2 == Constants.PRICE).Value);
    //    //    string[] prices = menuItem.Description.Split(new[] { "-" }, StringSplitOptions.None);
    //    //    int.TryParse(prices[0], out minPrice);
    //    //    int.TryParse(prices[1], out maxPrice);

    //    //    DataTable dt = null;
    //    //    dt = new AutologiaDL.Car().Search(carSearchRequest, minPrice, maxPrice);
    //    //    if (dt == null || dt.Rows.Count == 0)
    //    //        return null;

    //    //    dt.Columns.Add(new DataColumn("POINTS"));
    //    //    dt.Columns[dt.Columns.Count-1].DefaultValue = 0;

    //    //    // ממון
    //    //    filter.Add(string.Format("TRADE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.SHIRUT).Value));
    //    //    filter.Add(string.Format("VALUE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.VALUE).Value));
    //    //    // מושבים
    //    //    filter.Add(string.Format("SEATS = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.SEATS).Value));
    //    //    filter.Add(string.Format("DRIVER LIKE '%{0}%'", carSearchRequest.Items.Find(r => r.Key2 == Constants.DRIVER_SIZE).Value));
    //    //    filter.Add(string.Format("SEAT_5 = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.SEAT5).Value));
    //    //    // דלתות
    //    //    filter.Add(string.Format("DORS = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.DORS).Value));
    //    //    filter.Add(string.Format("TRUNK = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.TRUNK_SIZE).Value));
    //    //    // בטחון
    //    //    filter.Add(string.Format("VISUAL_SPACE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.VISUAL_SPACE).Value));
    //    //    filter.Add(string.Format("ROAD = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.ROAD).Value));
    //    //    filter.Add(string.Format("SECURE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.SAFETY).Value));
    //    //    // עלות אחזקה
    //    //    filter.Add(string.Format("MAINTANANCE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.MAINTANANCE).Value));
    //    //    filter.Add(string.Format("FUEL_CONSUME = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.FEUL_CONSUMING).Value));
    //    //    filter.Add(string.Format("GAS_COMPATIBLE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.GAS_COMPATIBLE).Value));
    //    //    // אחר
    //    //    filter.Add(string.Format("RESPONSE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.RESPONSE).Value));
    //    //    filter.Add(string.Format("LICENSE = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.LICENSE).Value));
    //    //    filter.Add(string.Format("MULTI_DRIVER = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.MULTI_DRIVER).Value));
    //    //    filter.Add(string.Format("RELIABILITY = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.RELIABILITY).Value));
    //    //    filter.Add(string.Format("HEAT_STAND = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.HEAT_RESISTANCE).Value));
    //    //    filter.Add(string.Format("SMOKERS = {0}", carSearchRequest.Items.Find(r => r.Key2 == Constants.SMOKERS).Value));

    //    //    // Create a collection of rows that represent filtered resultset from max filters to min filters
    //    //    for (int i = filter.Count; i > 0; i--)
    //    //    {
    //    //        FilterResults(dt, i);
    //    //    }

    //    //    DataTable resultDT = new DataTable();
    //    //    resultDT = dt.Copy();
    //    //    resultDT.Clear();
    //    //    foreach (DataRow row in resultsList)
    //    //    {
    //    //        DataRow newRow = resultDT.NewRow();
    //    //        newRow.ItemArray = row.ItemArray;
    //    //        resultDT.Rows.Add(newRow);
    //    //    }

    //    //    return resultDT;
    //    //}

    //    private decimal CalculatePoints(int p)
    //    {
    //        decimal res = decimal.Divide(p, filter.Count) * 50;
    //        return Math.Round(res, 2);
    //    }

    //    private void FilterResults(DataTable dt, int p)
    //    {
    //        int validFiltersCount = 0;
    //        var f = new StringBuilder();
    //        for (int i = 0; i < p; i++)
    //        {
    //            if (dt.Select(filter[i]).Length == 0)
    //            {
    //                continue;
    //            }

    //            validFiltersCount += 1;
    //            if (f.Length != 0)
    //                f.Append(" AND ");
    //            f.Append(filter[i]);
    //        }
    //        DataRow[] dataRows = dt.Select(f.ToString());

    //        if (dataRows.Length != 0)
    //        {
    //            foreach (var row in dataRows)
    //            {
    //                decimal calculatePoints = CalculatePoints(validFiltersCount) + 50;
    //                DataRow newRow = dt.NewRow();
    //                newRow.ItemArray = row.ItemArray;
    //                newRow["POINTS"] = calculatePoints;
    //                resultsList.Add(newRow);
    //            }
    //        }
    //    }
    //}

    public class CarBase
    {
        public Admin admin = new Admin();

        public int Manufactor { get; set; }
        public int Model { get; set; }
        public int SubModel { get; set; }
        public int Year { get; set; }
        public int Counry { get; set; }
        public int MainType { get; set; }
        public int SubType { get; set; }
        public int FuelType { get; set; }
        public int Geer { get; set; }
        public int Seats { get; set; }
        public int Price { get; set; }
        public int Trunk { get; set; }
        public int Accessory { get; set; }
        public int Maintanance { get; set; }
        public int Secure { get; set; }
        public int FuelConsume { get; set; }

        public string Description { get; set; }
        public string ForOppinon { get; set; }
        public string AgainstOppinon { get; set; }
        public string UniqueIdentifier { get; set; }
    }

    public class Private : CarBase
    {
        public int MultiDriver { get; set; }
        public int Size { get; set; }
        //public List<Search.CarMultiAnswer> perception { get; set; }
        //public List<Search.CarMultiAnswer> driver { get; set; }
        public List<int> Perception { get; set; }
        public List<int> Driver { get; set; }
        public int Dors { get; set; }
        public int Response { get; set; }

        public void Add()
        {
            admin.AddCar(Manufactor, Model, Year, Counry, MainType, SubType, Seats, Dors,
                FuelType, Geer, Size, Trunk, null, Accessory, Response, Perception, Driver,
                Maintanance, FuelConsume, Secure, Description, MultiDriver, SubModel,
                ForOppinon, AgainstOppinon, UniqueIdentifier, Price);
        }
    }

    public class Suv : CarBase
    {
        //public List<Search.CarMultiAnswer> driver { get; set; }
        public List<int> Driver { get; set; }
        public int Response { get; set; }
        public int Surface { get; set; }

        public void Add()
        {
            admin.AddCar(Manufactor, Model, Year, Counry, MainType, SubType, Seats, null,
                FuelType, Geer, null, Trunk, Surface, Accessory, Response, null, Driver,
                Maintanance, FuelConsume, Secure, Description, null, SubModel,
                ForOppinon, AgainstOppinon, UniqueIdentifier, Price);
        }
    }

    public class Commercial : CarBase
    {
        public int Ignition { get; set; }
        public int VisualSpace { get; set; }

        public void Add()
        {
            admin.AddCar(Manufactor, Model, Year, Counry, MainType, SubType, Seats, null,
                FuelType, Geer, null, Trunk, null, Accessory, null, null, null,
                Maintanance, FuelConsume, Secure, Description, null, SubModel,
                ForOppinon, AgainstOppinon, UniqueIdentifier, Price);
        }
    }
}
