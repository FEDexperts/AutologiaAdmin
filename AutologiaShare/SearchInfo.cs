using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AutologiaShare
{
    public class SearchInfoItem
    {
        public string Key1;
        public string Key2;
        public string Value;

        public SearchInfoItem(string key1, string key2)
        {
            Key1 = key1;
            Key2 = key2;
        }
    }

    public class SearchInfo
    {
        public Hashtable Params;
        public string[] Keys = { "1,3", "1,4", "1,8", "1,9", "1,10", "1,15", "1,29", "2,24", "2,25", "2,36", "3,6", "3,16", "3,17", "4,7", "4,11", "5,18", "5,20", "5,26", "6,21", "6,23", "6,28" };
        public List<SearchInfoItem> SearchItems;

        public SearchInfo()
        {
            Params = new Hashtable();
            SearchItems = new List<SearchInfoItem>();
            foreach (string key in Keys)
            {
                string[] KeysItems = key.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                SearchInfoItem searchInfoItem = new SearchInfoItem(KeysItems[0], KeysItems[1]);
                SearchItems.Add(searchInfoItem);

                Params.Add(key, "-1");
            }
        }

        public void Add(int mid1, int mid2, int mid3)
        {
            string key = string.Format("{0},{1}", mid1, mid2);
            if (Params.ContainsKey(key))
                Params.Remove(key);
            Params.Add(key, mid3);
        }
    }
}
