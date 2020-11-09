// Data Models

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static UPSCustomerData.MainWindow;
using System.Web.Script.Serialization;

namespace UPSCustomerData.DataModels
{

    class EmployeeRecords {

        public class Obj
        {
            public Obj(string key, string value)
            {
                Key = key;
                Value = value;
            }

            public string Key { get; set; }

            public string Value { get; set; }
        }



        public IList<UPSCustomerDetails> GetData()
        {
            List<UPSCustomerDetails> genericList = new List<UPSCustomerDetails>();
            UPSCustomerDetails studentObj;
            Random randomObj = new Random();
            for (int i = 0; i < 12345; i++) //You can make this number anything you can think of (and your processor can handle).
            {
                studentObj = new UPSCustomerDetails
                {
                    
                };

                genericList.Add(studentObj);

            }
            return genericList;
        }



        public virtual async Task<IList<Datum>> GetDataAll()
        {
                       
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gorest.co.in/");
            var url = "https://gorest.co.in/users";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
            IList<Datum> userdetails = new List<Datum>();

            foreach (Datum employee in userdetails)
            {
                
                employee.name = null;
                employee.email = null;
            }
            
            var uri = new Uri(string.Format(url, string.Empty));
            var json = JsonConvert.SerializeObject(userdetails);
            var contentEnvio = new StringContent(json, Encoding.UTF8, "application/json");

           
            var response = await client.PostAsync(uri, contentEnvio);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Datum>>(content);
            }
            return null;
        }

        public class Pagination
        {
            public int total { get; set; }
            public int pages { get; set; }
            public int page { get; set; }
            public int limit { get; set; }
        }

        public class Meta
        {
            public Pagination pagination { get; set; }
        }

        //public class Datum
        //{
        //    public int id { get; set; }
        //    public string name { get; set; }
        //    public string email { get; set; }
        //    public Gender gender { get; set; }
        //    public string status { get; set; }
        //    public DateTime created_at { get; set; }
        //    public DateTime updated_at { get; set; }

        //}


        public IList<Student> GetRecord(int id)
        {
            List<Student> genericList = new List<Student>();

            Student studentObj;


            var BaseAddress = new Uri("https://gorest.co.in/");
            var url = "public-api/users?page=";
            string uriToSearch = BaseAddress + url;

            //ApiResult<Student> result = ApiResult<Student>.Get(apiUrl, "/" + Url, token);


            using (var Client = new System.Net.Http.HttpClient())
            {
                //This line
                Client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");

                HttpResponseMessage response = Client.GetAsync(uriToSearch+id).Result;

                if (response.IsSuccessStatusCode)
                {

                    var jsonresponse = response.Content.ReadAsStringAsync().Result;

                    var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Jsonobjects>(jsonresponse);
                    for (int i = 0; i <= 19; i++)
                    {
                        studentObj = new Student
                        {
                            id = myObject.data[i].id.ToString(),
                            name = myObject.data[i].name.ToString(),
                            email = myObject.data[i].email.ToString(),
                            status = myObject.data[i].status.ToString(),
                            //gender = (Gender)Enum.Parse(typeof(Gender), myObject.data[i].gender.ToString()),
                            gender = myObject.data[i].gender.ToString(),
                            created_at = Convert.ToDateTime(myObject.data[i].created_at.ToString()),
                            updated_at = Convert.ToDateTime(myObject.data[i].updated_at.ToString())
                         };
                         genericList.Add(studentObj);
                    }
               
                    //Student deserializedName = JsonConvert.DeserializeObject<Student>(jsonresponse);
                    //genericList.Add(deserializedName);
                }

                return genericList;


            }

                        
            
        }



        public IList<Student> SearUserRecord(string id)
        {
            List<Student> genericList = new List<Student>();

            Student studentObj;

            var BaseAddress = new Uri("https://gorest.co.in/");
            var url = "public-api/users/";
            string uriToSearch = BaseAddress + url;

            //ApiResult<Student> result = ApiResult<Student>.Get(apiUrl, "/" + Url, token);


            using (var Client = new System.Net.Http.HttpClient())
            {
                //This line
                Client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");

                HttpResponseMessage response = Client.GetAsync(uriToSearch + id).Result;

                if (response.IsSuccessStatusCode)
                {

                    var jsonresponse = response.Content.ReadAsStringAsync().Result;

                    var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Jsonobjects>(jsonresponse);

                    for (int i = 0; i <= 19; i++)
                    {
                        studentObj = new Student
                        {
                            id = myObject.data[i].id.ToString(),
                            name = myObject.data[i].name.ToString(),
                            email = myObject.data[i].email.ToString(),
                            status = myObject.data[i].status.ToString(),
                            //gender = (Gender)Enum.Parse(typeof(Gender), myObject.data[i].gender.ToString()),
                            gender = myObject.data[i].gender.ToString(),
                            created_at = Convert.ToDateTime(myObject.data[i].created_at.ToString()),
                            updated_at = Convert.ToDateTime(myObject.data[i].updated_at.ToString())
                        };
                        genericList.Add(studentObj);
                    }

                    //Student deserializedName = JsonConvert.DeserializeObject<Student>(jsonresponse);
                    //genericList.Add(deserializedName);
                }

                return genericList;

            }
        }


        public class Rootobject
        {
            public List<Student> Student { get; set; }
        }

        public class Student
        {
            public string id { get; set; }
            public string name { get; set; }
            public string email { get; set; }

            public string gender { get; set; }
            public string status { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }

           
        }



        public enum Gender
        {
            Male,
            Female
        };

        public enum Status
        {
            Active,
            InActve
        };



        public class Jsonobjects
        {
            public int id { get; set; }
            public Meta meta { get; set; }

            public Student[] data { get; set; }

            //public List<UPSCustomerDetails> data { get; set; }
        }



        public class UPSCustomerDetails
        {

            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("email")]
            public string email { get; set; }

            [JsonProperty("gender")]
            public Gender gender { get; set; }

            [JsonProperty("status")]
            public Status status { get; set; }

            [JsonProperty("created_at")]
            public string created_at { get; set; }

            [JsonProperty("updated_at")]
            public string updated_at { get; set; }

            public List<UPSCustomerDetails> userdetails { get; set; }

            //public static IList<UPSCustomerDetails> products = new List<UPSCustomerDetails>();
        }


        public class ApiResult<T>
        {
            public IEnumerable<T> List { get; set; }
            public T Object { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
            public HttpStatusCode StatusCode { get; set; }
            public string Url { get; set; }
            public static ApiResult<T> Post(string uri, string url, string token = null)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMilliseconds(1800000);
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    HttpResponseMessage response = client.PostAsync(url, null).Result;

                    return Result(response);
                }
            }

            public static ApiResult<T> Get(string uri, string url, string token = null)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMilliseconds(1800000);
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    return Result(response);
                }
            }
            private static ApiResult<T> Result(HttpResponseMessage response)
            {
                ApiResult<T> result = response.Content.ReadAsAsync<ApiResult<T>>().Result;
                if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    result.StatusCode = response.StatusCode;
                }

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;

                }
                return result;
            }
        }

    }
    
}