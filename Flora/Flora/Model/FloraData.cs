using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Flora.Model
{
    public class FloraData
    {

        public class StringData
        {
            public string familyName { get; set; }
            public string genusName { get; set; }
        }

        List<StringData> familyList = new List<StringData>();
        public async Task<List<StringData>> GetData()
        {
            
            List<StringData> genusList = new List<StringData>();
            string uri = "https://search.idigbio.org/v2/search/records?fields=[%22scientificname%22,%22genus%22,%22family%22,%22hasImage%22]&rq={\"country\":\"United States\",\"county\":\"floyd\",\"municipality\":\"New Albany\",\"kingdom\":\"plantae\"}&no_attribution=true&limit=2";
            Debug.WriteLine("uri string is: " + uri);
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("status 200***IsASuccess!");
                    string content = await response.Content.ReadAsStringAsync();
                    PlantObject.RootObject dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PlantObject.RootObject>(content);
                    Debug.WriteLine("deserialization completed...");
                    foreach (var data1 in dynObj.items)
                    {
                        Debug.WriteLine("foreach loop iteration");
                        Debug.WriteLine("family is: " + data1.indexTerms.family);
                        familyList.Add(new StringData() { familyName = data1.indexTerms.family });
                        Debug.WriteLine("familyList newest addition is " + familyList.Last());
                        Debug.WriteLine("genus is: " + data1.indexTerms.genus);
                        genusList.Add(new StringData() { genusName = data1.indexTerms.genus });
                        Debug.WriteLine("scientific name is: " + data1.indexTerms.scientificname);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving Json data: " + e);
            }
            return familyList;
        }//GetData end"

    }//FloraData end
}//namespace end
