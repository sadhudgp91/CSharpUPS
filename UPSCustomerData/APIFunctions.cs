using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace UPSCustomerData
{
    public static class APIFunctions
    {
        private static readonly string baseAPIUrl = "https://gorest.co.in/";

        public static async Task<string> GetAllAsync(string id)

        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseAPIUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "public-api/users/";

            HttpResponseMessage response = client.GetAsync(baseAPIUrl + url + id).Result;

            HttpContent content = response.Content;

            if (response.IsSuccessStatusCode)
            {

                string json_daily_forecast = await content.ReadAsStringAsync();

                //var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(json_daily_forecast);


                //var employees = response.Content.ReadAsAsync<Datum>().Result;
                return json_daily_forecast;
                    
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

            return string.Empty;
        }



    }
}
