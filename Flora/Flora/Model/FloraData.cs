using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using HtmlAgilityPack;

namespace Flora.Model
{
    public class FloraData
    {

        public class StringData
        {
            public string familyName { get; set; }
            public string genusName { get; set; }
        }
        HttpClient client = new HttpClient();
        string[] data;
        public async Task<string[]> GetData()
        {
            string uri = "https://search.idigbio.org/v2/search/records?fields=[%22scientificname%22,%22genus%22,%22family%22,%22taxonid%22]" +
                "&rq={\"county\":\"floyd\",\"stateprovince\":\"Indiana\",\"kingdom\":\"plantae\"}&no_attribution=true&limit=15";
            Debug.WriteLine("uri string is: " + uri);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("status 200***IsASuccess!");
                    string content = await response.Content.ReadAsStringAsync();
                    PlantObject.RootObject dynObj = JsonConvert.DeserializeObject<PlantObject.RootObject>(content);
                    Debug.WriteLine("deserialization completed...");
                    data = new string[(dynObj.items.Count * 4)];
                    Debug.WriteLine("itemCount is " + dynObj.items.Count);
                    int i = 0;
                    foreach (var data1 in dynObj.items)
                    {
                        Debug.WriteLine(i + "foreach loop iteration");
                        Debug.WriteLine("family is: " + data1.indexTerms.family);
                        data[i] = data1.indexTerms.family;
                        Debug.WriteLine("data[i] newest addition is " + data[i]);
                        Debug.WriteLine("genus is: " + data1.indexTerms.genus);
                        data[i + 1] = data1.indexTerms.family + " " + data1.indexTerms.genus;
                        Debug.WriteLine("data[i+1] newest addition is " + data[i + 1]);
                        Debug.WriteLine("scientific name is: " + data1.indexTerms.scientificname);
                        data[i + 2] = data1.indexTerms.scientificname;
                        Debug.WriteLine("data[i+2] newest addition is " + data[i + 2]);
                        Debug.WriteLine("taxonid is " + data1.indexTerms.taxonid);
                        data[i + 3] = data1.indexTerms.taxonid.ToString() + " " + data1.indexTerms.scientificname;
                        Debug.WriteLine("data[i+3] newest addition is " + data[i + 3]);
                        i = i + 4;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving Json data: " + e);
            }
            return data;
        }//GetData end"

        List<string> imageURIs = new List<string>();

        public async Task<List<string>> WebScraper(string taxonid)
        {
            //string uri = "http://midwestherbaria.org/portal/taxa/index.php?taxauthid=1&taxon="+taxonid+"&clid=";
            int i = 0;
            var html = await client.GetStringAsync(@"http://midwestherbaria.org/portal/taxa/index.php?taxauthid=1&taxon=" + taxonid + "&clid=");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var uriNodes = htmlDoc.DocumentNode.Descendants("div").
                Where(x => x.GetAttributeValue("class", "").Equals("tptnimg"));
            var descriptionNodes = htmlDoc.DocumentNode.Descendants("div").
                Where(x => x.GetAttributeValue("style", "").Equals("clear:both;"));
            foreach (var node in descriptionNodes)
            {
                if (i < 1)
                {
                    var descr = HtmlEntity.DeEntitize(node.InnerText);
                    imageURIs.Add(descr);
                    Debug.WriteLine("newest description is " + imageURIs.Last());
                    break;
                }
            }
            foreach (var node in uriNodes)
            {
                var uri = HtmlEntity.DeEntitize(node.Descendants("img").FirstOrDefault()?.ChildAttributes("src")
                    .FirstOrDefault()?.Value);
                imageURIs.Add(uri);
                Debug.WriteLine("imageURIs list newest item is " + imageURIs.Last());
            }

            return imageURIs;
        }
        /*
        public async Task<List<string>> GetImage(string scientificName)
        {
            string uri = "https://search.idigbio.org/v2/search/media?fields=[%22accessuri%22]&rq={\"scientificname\":\"" + scientificName + "\"}&no_attribution=true&limit=1";
            Debug.WriteLine("IMAGE: uri string is: " + uri);
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("IMAGE: status 200***IsASuccess!");
                    string content = await response.Content.ReadAsStringAsync();
                    PlantQuery.RootObject dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PlantQuery.RootObject>(content);
                    Debug.WriteLine("IMAGE: deserialization completed...");
                    //imageURIs = new string[dynObj.itemCount];
                    Debug.WriteLine("IMAGE: itemCount is " + dynObj.itemCount);
                    //int i = 0;
                    foreach (var data1 in dynObj.items)
                    {
                        Debug.WriteLine("IMAGE: foreach loop iteration");
                        Debug.WriteLine("accessURI is: " + data1.indexTerms.accessuri);
                        imageURIs.Add(data1.indexTerms.accessuri);
                        Debug.WriteLine("data[i] newest addition is " + imageURIs.Last());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving Json data: " + e);
            }
            return imageURIs;
        }//GetImage end"
        */

    }//FloraData end
}//namespace end
