using BlazorApp1.Services;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorApp1.DbServices
{
    /*public class DashboardService : BaseServices //deriving the class from the baseServices class
    {
        private readonly HttpClient _httpClient;
        private readonly int _currentDate = DateTime.Today.Year;

        public DashboardService(HttpClient http)
        {
            _httpClient = http; //inject the insatnce of the httpclient type in the constructor of the data service class
        }

        public async Task<ICollection<Dashboard>> LoadActiveEmails() //calling active emails for dashboard
        {
            //transform the data into the format required for the dashboard
            var client = _httpClient;
            var response = await _httpClient.GetAsync(BaseApiUrl + "user/");
            var data = await response.Content.ReadAsStringAsync();
            //var listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(data);

            var activeEmail = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(data);
            return data.Where(user => user.Email >= new StringToCharConverter()
            && user.Email <= new StringToCharConverter())
            .GroupBy(user => user.Id)
            .Select(user => new Dashboard
            {
                ActiveEmails = user.Count(user => user.Email) //count how many emails are active in the database
            })
            .ToList(); //activeEmail
        }

        public async Task<ICollection<Dashboard>> LoadActiveDevices() //calling active devices for dashboard
        {
            //transform the data into the format required for the dashboard
            var client = _httpClient;
            var response = await _httpClient.GetAsync(BaseApiUrl + "devices/");
            var data = await response.Content.ReadAsStringAsync();

            var activeDevice = Newtonsoft.Json.JsonConvert.DeserializeObject<Device>(data);
            return data.Where(device => device.Id >= new StringToCharConverter()
            && device.Id <= new StringToCharConverter())
            .GroupBy(device => device.Id)
            .Select(device => new Dashboard
            {
                ActiveDevices = device.Count(device => device.Id)
            })
            .ToList(); //activeDevices
        }

        }*/

         public class DashboardService : BaseServices
         {
             //string apiur = "https://localhost:44304/groupmanagement/";
             string apiuRl = BaseApiUrl + "dashboard/";
             public async Task<int> SaveAsync(Dashboard dashboard)
             {
                 var client = new HttpClient();
                 var response = await client.PostAsync(apiuRl, new StringContent(JsonConvert.SerializeObject(dashboard), Encoding.UTF8, "application/json"));
                 var data = await response.Content.ReadAsStringAsync();


                 return int.Parse(data);
             }
             public async Task<Dashboard[]> GetDashboardsAsync()
             {

                 var client = new HttpClient();
                 var response = await client.GetAsync(apiuRl);
                 var data = await response.Content.ReadAsStringAsync();

                 var listOfInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dashboard[]>(data);
                 return listOfInfo;
             }
         }
    
}
