using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace EveOnlineApp
{
    public class APIHelper
    {
        /// <summary>
        /// Author: Nicolai Thomsen
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        // TOTAL RUNTIME: 1:37 (Average)
        // This async Task method carres out the API call, and pulls the data, then deserializes all of it into EveObjModel objects. 
        public async static Task<List<List<EveObjModel>>> GetData(string region)
        {
            // The necessary list and list of lists. 
            List<EveObjModel> importedList = new List<EveObjModel>();
            List<List<EveObjModel>> ListOfAllImportedLists = new List<List<EveObjModel>>();

            // Forloop where max i is set a bit higher than the highest volume of pages of the largest region (291 pages of 1000 objects). 
            // The loop runs through every single page of JSON objects in the region and pulls all of the into lists, which are then
            // added to the listOfLists list. If a page contains null objects, we break the loop. 
            for (int i = 1; i < 300; i++)
            {
                // There needs to be a try-catch in here somewhere, too. 
                var http = new HttpClient();
                var url = String.Format($"https://esi.evetech.net/latest/markets/{region}/orders/?datasource=tranquility&order_type=all&page={i}");
                var response = await http.GetAsync(url);
                var jsonString = await response.Content.ReadAsStringAsync();

                importedList = (List<EveObjModel>)JsonConvert.DeserializeObject<List<EveObjModel>>(jsonString);

                if (importedList.Count > 0)
                    ListOfAllImportedLists.Add(importedList);
                else
                    break;
            }

            return ListOfAllImportedLists;
        }

        //This method takes in an itemID makes a call to the server
        //and then returns an object containing item values
        //removed static...
        public async  Task<EveItemModel> GetName(int itemId)
        {
            

            var http = new HttpClient();
            var url = String.Format($"https://esi.evetech.net/latest/universe/types/{itemId}/?datasource=tranquility&language=en-us");
            var response = await http.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            EveItemModel anItem = new EveItemModel();
            anItem = (EveItemModel)JsonConvert.DeserializeObject<EveItemModel>(jsonString);


            return anItem;
        }
    }
}
