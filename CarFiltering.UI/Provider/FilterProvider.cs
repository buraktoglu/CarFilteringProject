using CarFiltering.UI.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarFiltering.UI.Provider
{
    public class FilterProvider
    {
        HttpClient _client;

        public FilterProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Car>> GetCarsAsync(string filters)
        {
            HttpResponseMessage carsHRM = await _client.GetAsync(filters);
            

            if (carsHRM.IsSuccessStatusCode)
            {
                string carsJson = await carsHRM.Content.ReadAsStringAsync();
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);
                return cars;
            }
            else
            {
                //handle the situation
                return null;
            }        
        }
    }
}
