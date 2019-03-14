using System;
using System.Collections.Generic;
using System.Text;

namespace Flora.Model
{
    public class PlantObject
    {
        public class Data
        {
        }

        public class IndexTerms
        {
            public string genus { get; set; }
            public bool hasImage { get; set; }
            public string scientificname { get; set; }
            public string family { get; set; }
        }

        public class Item
        {
            public string uuid { get; set; }
            public string type { get; set; }
            public Data data { get; set; }
            public IndexTerms indexTerms { get; set; }
        }

        public class Contact
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string role { get; set; }
            public string email { get; set; }
        }

        public class Attribution
        {
            public string uuid { get; set; }
            public int itemCount { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string logo { get; set; }
            public string url { get; set; }
            public string emllink { get; set; }
            public string archivelink { get; set; }
            public List<Contact> contacts { get; set; }
            public string data_rights { get; set; }
            public string publisher { get; set; }
            public int totalCount { get; set; }
            public double hitRatio { get; set; }
        }

        public class RootObject
        {
            public int itemCount { get; set; }
            public DateTime lastModified { get; set; }
            public List<Item> items { get; set; }
            public List<Attribution> attribution { get; set; }
        }
    }//PlantObject end
}//namespace end
