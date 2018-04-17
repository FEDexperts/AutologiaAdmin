using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutologiaShare
{
    public class CarSearchInfo
    {
        // Style
        public static int MainType;
        public static int SubType;
        public static int Perception;
        public static int Geer;
        public static int FuelType;
        public static int Ignition;
        public static int CarSize;
        // Finance
        public static int Price;
        public static int Trade;
        public static int Value;
        // Seats
        public static int Seats;
        public static int DriverSize;
        public static int Seat5;
        // Dors
        public static int Dors;
        public static int Trunk;
        // Safety
        public static int VisualSpace;
        public static int Road;
        public static int SecurityLevel;
        // Saveing
        public static int Maintanance;
        public static int Fuel;
        public static int GasCompatible;
        // Other
        public static int Handiccape;
        public static int DriverLimits;
        public static int MultiDriver;
        public static int HeatStand;
        public static int Response;
        public static int SurfaceCompatible;
        public static int License;
        public static int Smokers;
        public static int Reliability;

        public static string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(MainType);
            s.Append(",");
            s.Append(SubType);
            s.Append(",");
            s.Append(FuelType);
            s.Append(",");
            s.Append(Geer);
            s.Append(",");
            s.Append(CarSize);
            s.Append(",");
            s.Append(Perception);
            s.Append(",");
            s.Append(Ignition);
            s.Append(",");
            s.Append(Trade);
            s.Append(",");
            s.Append(Value);
            s.Append(",");
            s.Append(Price);
            s.Append(",");
            s.Append(Seats);
            s.Append(",");
            s.Append(DriverSize);
            s.Append(",");
            s.Append(Seat5);
            s.Append(",");
            s.Append(Dors);
            s.Append(",");
            s.Append(Trunk);
            s.Append(",");
            s.Append(VisualSpace);
            s.Append(",");
            s.Append(Road);
            s.Append(",");
            s.Append(SecurityLevel);
            s.Append(",");
            s.Append(Maintanance);
            s.Append(",");
            s.Append(Fuel);
            s.Append(",");
            s.Append(GasCompatible);
            //s.Append(",");
            //s.Append(Handiccape);
            //s.Append(",");
            //s.Append(DriverLimits);
            //s.Append(",");
            //s.Append(MultiDriver);
            //s.Append(",");
            //s.Append(HeatStand);
            //s.Append(",");
            //s.Append(Response);
            //s.Append(",");
            //s.Append(SurfaceCompatible);
            //s.Append(",");
            //s.Append(License);
            //s.Append(",");
            //s.Append(Smokers);
            //s.Append(",");
            //s.Append(Reliability);

            return s.ToString();
        }
    }
}
