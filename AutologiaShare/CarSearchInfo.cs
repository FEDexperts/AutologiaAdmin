using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AutologiaShare
{
    //public class CarSearchInfo
    //{
    //    // Style
    //    public int MainType;
    //    public int SubType;
    //    public int Perception;
    //    public int Geer;
    //    public int FuelType;
    //    public int Ignition;
    //    public int CarSize;
    //    // Finance
    //    public int Price;
    //    public int Trade;
    //    public int Value;
    //    // Seats
    //    public int Seats;
    //    public int DriverSize;
    //    public int Seat5;
    //    // Dors
    //    public int Dors;
    //    public int Trunk;
    //    // Safety
    //    public int VisualSpace;
    //    public int Road;
    //    public int SecurityLevel;
    //    // Saveing
    //    public int Maintanance;
    //    public int Fuel;
    //    public int GasCompatible;
    //    // Other
    //    public int Handiccape;
    //    public int DriverLimits;
    //    public int MultiDriver;
    //    public int HeatStand;
    //    public int Response;
    //    public int SurfaceCompatible;
    //    public int License;
    //    public int Smokers;
    //    public int Reliability;

    //    public string ToString()
    //    {
    //        StringBuilder s = new StringBuilder();
    //        s.Append(MainType);
    //        s.Append(",");
    //        s.Append(SubType);
    //        s.Append(",");
    //        s.Append(FuelType);
    //        s.Append(",");
    //        s.Append(Geer);
    //        s.Append(",");
    //        s.Append(CarSize);
    //        s.Append(",");
    //        s.Append(Perception);
    //        s.Append(",");
    //        s.Append(Ignition);
    //        s.Append(",");
    //        s.Append(Trade);
    //        s.Append(",");
    //        s.Append(Value);
    //        s.Append(",");
    //        //s.Append(MinPrice);
    //        //s.Append(",");
    //        //s.Append(MaxPrice);
    //        //s.Append(",");
    //        s.Append(Seats);
    //        s.Append(",");
    //        s.Append(DriverSize);
    //        s.Append(",");
    //        s.Append(Seat5);
    //        s.Append(",");
    //        s.Append(Dors);
    //        s.Append(",");
    //        s.Append(Trunk);
    //        s.Append(",");
    //        s.Append(VisualSpace);
    //        s.Append(",");
    //        s.Append(Road);
    //        s.Append(",");
    //        s.Append(SecurityLevel);
    //        s.Append(",");
    //        s.Append(Maintanance);
    //        s.Append(",");
    //        s.Append(Fuel);
    //        s.Append(",");
    //        s.Append(GasCompatible);
    //        //s.Append(",");
    //        //s.Append(Handiccape);
    //        //s.Append(",");
    //        //s.Append(DriverLimits);
    //        //s.Append(",");
    //        //s.Append(MultiDriver);
    //        //s.Append(",");
    //        //s.Append(HeatStand);
    //        //s.Append(",");
    //        //s.Append(Response);
    //        //s.Append(",");
    //        //s.Append(SurfaceCompatible);
    //        //s.Append(",");
    //        //s.Append(License);
    //        //s.Append(",");
    //        //s.Append(Smokers);
    //        //s.Append(",");
    //        //s.Append(Reliability);

    //        return s.ToString();
    //    }

    //    public Hashtable Params;
    //    public string[] Keys = { "1,3", "1,4", "1,8", "1,9", "1,10", "1,15", "1,29", "2,24", "2,25", "2,36", "3,6", "3,16", "3,17", "4,7", "4,11", "5,18", "5,20", "5,26", "6,21", "6,23", "6,28" };
    //    public List<SearchInfoItem> SearchItems;

    //    public CarSearchInfo()
    //    {
    //        Params = new Hashtable();
    //        SearchItems = new List<SearchInfoItem>();
    //        foreach (string key in Keys)
    //        {
    //            string[] KeysItems = key.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    //            SearchInfoItem searchInfoItem = new SearchInfoItem(KeysItems[0], KeysItems[1]);
    //            SearchItems.Add(searchInfoItem);

    //            Params.Add(key, "-1");
    //        }
    //    }

    //    public void Add(int mid1, int mid2, int mid3)
    //    {
    //        string key = string.Format("{0},{1}", mid1, mid2);
    //        if (Params.ContainsKey(key))
    //            Params.Remove(key);
    //        Params.Add(key, mid3);
    //    }
    //}
}
