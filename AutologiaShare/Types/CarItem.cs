using System;
using System.Collections.Generic;
using System.Linq;

namespace AutologiaShare.Types
{
    public class CarItem
    {
        public int Id;
        public int Manufactor;
        public int Model;
        public int SubModel;
        public int Year;
        public int Country;
        public int MainType;
        public int SubType;
        public int License;
        public int Seats;
        public int Dors;
        public int FuelType;
        public int Geer;
        public int Size;
        public int Trunk;
        public int Accessories;
        public string Additions;
        public int Response;
        public List<int> Perception;
        public List<int> Driver;
        public int Seat5;
        public int VisualSpace;
        public int Weal;
        public int Road;
        public int Maintanance;
        public int Reliability;
        public int FuelConsume;
        public int Trade;
        public int Value;
        public int Secure;
        public int Handiccape;
        public int GasCompatible;
        public int Ignition;
        public int HeatStand;
        public int Smokers;
        public string Description;
        public int SurfaceCompatible;
        public int MultiDriver;
        public int DriverLimits;
        public int Price;
        public string For;
        public string Against;
        public string Links;
        public int Body;

        public string ManufactorDesc;
        public string ModelDesc;
        public string SubModelDesc;
        public string YearDesc;
        public string CountryDesc;
        public string MainTypeDesc;
        public string SubTypeDesc;
        public string LicenseDesc;
        public string SeatsDesc;
        public string DorsDesc;
        public string FuelConsumeDesc;
        public List<string> GeerDesc;
        public string SizeDesc;
        public string TrunkDesc;
        public string AccessoriesDesc;
        public string AdditionsDesc;
        public string ResponseDesc;
        public List<string> PerceptionDesc;
        public List<string> DriverDesc;
        public string Seat5Desc;
        public string VisualSpaceDesc;
        public string WealDesc;
        public string RoadDesc;
        public string MaintananceDesc;
        public string ReliabilityDesc;
        public string FuelTypeDesc;
        public string TradeDesc;
        public string ValueDesc;
        public string SecureDesc;
        public string HandiccapeDesc;
        public string GasCompatibleDesc;
        public string IgnitionDesc;
        public string HeatStandDesc;
        public string SmokersDesc;
        public string DescriptionDesc;
        public string SurfaceCompatibleDesc;
        public string MultiDriverDesc;
        public string DriverLimitsDesc;
        public string PriceDesc;
        public string Points;
        public string ManufactorLogo;
        public string SmallImage;
        public string BigImage;
        public string BodyDesc;

        public CarItem()
        {
            //Geer = new List<int>();
            //Driver = new List<int>();
            //Perception = new List<int>();
        }

        public static List<int> ToIntList(string value)
        {
            string[] tmp = value.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            return (from p in tmp select int.Parse(p)).ToList();
        }

        public static string ToCommaString(List<int> value)
        {
            string res = string.Empty;
            foreach (var i in value)
            {
                if (!string.IsNullOrEmpty(res))
                {
                    res += ",";
                }
                res += i.ToString();
            }
            return res;
        }

        public static string ToCommaString(List<string> value)
        {
            string res = string.Empty;
            foreach (var i in value)
            {
                if (!string.IsNullOrEmpty(res))
                {
                    res += ",";
                }
                res += i;
            }
            return res;
        }
    }
}