using System.Collections.Generic;

namespace AutologiaShare
{
    public class CarSearchRequest
    {
        public readonly List<CarSearchRequestItem> Items = new List<CarSearchRequestItem>();

        public int GetValue(int key1, int key2)
        {
            CarSearchRequestItem carSearchRequestItem = Items.Find(
                searchRequestItem => searchRequestItem.Key1 == key1 &&
                                     searchRequestItem.Key2 == key2);
            if (carSearchRequestItem != null) return carSearchRequestItem.Value;
            return -1;
        }

        public CarSearchRequestItem GetItem(int key1, int key2)
        {
            CarSearchRequestItem carSearchRequestItem = Items.Find(
                searchRequestItem => searchRequestItem.Key1 == key1 &&
                                     searchRequestItem.Key2 == key2);
            return carSearchRequestItem;
        }

        public new string ToString()
        {
            string retVal = "";

            foreach (var carSearchRequestItem in Items)
            {
                if (!string.IsNullOrEmpty(retVal))
                    retVal += ",";
                retVal += carSearchRequestItem.Value;
            }

            return retVal;
        }

        public bool Completed()
        {
            return Items.Count == 29;
        }
    }
}