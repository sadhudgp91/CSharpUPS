using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net.Http.Formatting;
using static UPSCustomerData.MainWindow;

namespace UPSCustomerData.ControlEngine
{
    public static class RestAPIFunctions
    {
        public static readonly string baseURL = "https://gorest.co.in/public-api/";
        public static async Task<string> GetAll()

        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(baseURL + "users"))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        try
                        {
                            var json_daily_forecast = await response.Content.ReadAsStringAsync();
                            var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Jsonobjects>(json_daily_forecast);
                            string jsonData = JsonConvert.SerializeObject(json_daily_forecast, Formatting.None);
                           
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error while processing request!");
                        }
                        finally
                        {
                            
                            //CleanUp();
                        }
                      
                    }

                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;

                        }

                    }
                }

            }

            return string.Empty;
        }



        public static async Task<string> SearchUser(string id)
        {
            var BaseAddress = new Uri("https://gorest.co.in/");
            var url = "public-api/users/" + id;
            string uriToSearch = BaseAddress + url;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                
                using (HttpResponseMessage response = await client.GetAsync(uriToSearch))
                {

                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;

                        }
                    }

                }

            }

            return string.Empty;

        }



        public static async Task<string> GoToPage(string id)
        {
            var BaseAddress = new Uri("https://gorest.co.in/");
            var url = "public-api/users?page=" + id;
            string uriToSearch = BaseAddress + url;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");

                using (HttpResponseMessage response = await client.GetAsync(uriToSearch))
                {

                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;

                        }
                    }

                }

            }

            return string.Empty;

        }


        public static async Task<string> Post(string name, string email, string gender, string status)

        {
            
            var inputText = new Dictionary<string, string>
            {
                {"name", name },
                {"email", email },
                {"gender", gender },
                {"status", status }
            };

            var encodedItem = new FormUrlEncodedContent(inputText);
            using (HttpClient client = new HttpClient())
     
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                using (HttpResponseMessage response = await client.PostAsync(baseURL + "users", encodedItem))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        System.Windows.MessageBox.Show("Data entered successfully!");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                    }

                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;

                        }

                    }
                }

            }

            return string.Empty;
        }

        public static string BeautifyJson(string jsonStr)
        {
            JToken parseJson = JToken.Parse(jsonStr);
            return parseJson.ToString(Formatting.Indented);
        }




    }
}