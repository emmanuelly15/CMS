using BlazorApp1.Pages;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class DeviceService
    {
        public async Task<int> SaveAsync(Device device) //saving a device to the database
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/device", new StringContent(JsonConvert.SerializeObject(device), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }

        public async Task<Device[]> GetDevicesAsync() //getting data from the database
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/device");
            var data = await response.Content.ReadAsStringAsync();

            var listOfDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<Device[]>(data);
            return listOfDevices;

        }
    }
}
