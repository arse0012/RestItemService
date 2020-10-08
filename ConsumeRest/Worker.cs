using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;

namespace ConsumeRest
{
    public class Worker
    {
        private const string URI = "https://pro-arsen.azurewebsites.net/api/localItems";

        public Worker()
        {
            
        }
        public async void Start()
        {
            IList<Item> allItems = await GetAllItemsAsync();
            foreach (Item item in allItems)
            {
                Console.WriteLine(item);
            }


            try
            {
                Item item1 = await GetOneItemAsync(2);
            }
            catch
            {

            }
        }

        private async Task<IList<Item>> GetAllItemsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<Item> cList = JsonConvert.DeserializeObject<IList<Item>>(content);
                return cList;
            }
        }

        private async Task<Item> GetOneItemAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(URI + id);

                string content = await resp.Content.ReadAsStringAsync();
                if (resp.IsSuccessStatusCode)
                {
                    Item cItem = JsonConvert.DeserializeObject<Item>(content);
                    return cItem;
                }

                throw new KeyNotFoundException($"Status code={resp.StatusCode} Message={content}");
            }
        }
    }
}
