using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace BelzonaMobile
{
    
    public class CloudDataStore : IDataStore<BelProduct>
    {
        HttpClient client;
        IEnumerable<BelProduct> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            //client.BaseAddress = new Uri($"{App.BackendUrl}/");
            //client.BaseAddress = new Uri($"{App.BackendUrl}");


            //items = new List<Item>();
        }

        public async Task<IEnumerable<BelProduct>> GetItemsAsync(bool forceRefresh = false)
        {
            //if (forceRefresh && CrossConnectivity.Current.IsConnected)
            items = new List<BelProduct>();
            var uri = new Uri(string.Format(Constants.BackendUrl, string.Empty));

            if (forceRefresh)
            {
                //var json = await client.GetStringAsync($"api/item");
                //items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));

                try
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<BelProduct>>(content);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(@"              ERROR {0}", ex.Message);
                }
            }

            return items;
        }

        public async Task<BelProduct> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<BelProduct>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(BelProduct item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(BelProduct item)
        {
            //if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
            if (item == null || item.short_description == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.short_description}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
