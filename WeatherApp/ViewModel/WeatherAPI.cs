using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class WeatherAPI
    {
        public const string API_KEY = "e65CHkbxGFgnn0IWHVL5a6BVYC6nYVb4";

        public const string BASE_URL =
            "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";

        public async Task<AccuWeather> GetWeatherInformationAsync (string cityname)
        {
            AccuWeather result = new AccuWeather();

            string url = String.Format(BASE_URL, API_KEY, cityname);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<AccuWeather>(json);
            }

            return result;
        }
    }
}
