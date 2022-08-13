using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CommonModels.Model;
using Newtonsoft;
namespace BlazorApp1.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<Notification[]> GetForecastAsync(DateTime startDate)
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/notification");
            var data = await response.Content.ReadAsStringAsync();

            var listOfNotifications = Newtonsoft.Json.JsonConvert.DeserializeObject<Notification[]>(data);
            return listOfNotifications;


        }
    }
}
