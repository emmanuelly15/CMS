using BlazorApp1.Pages;
using BlazorApp1.Services;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class DeviceService: BaseServices
    {
        string apiurl1 = BaseApiUrl + "devicemanagement/";
        public async Task<int> SaveAsync(Device device) //saving a device to the database
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiurl1, new StringContent(JsonConvert.SerializeObject(device), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }

        public async Task<Device[]> GetDevicesAsync() //getting data from the database
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurl1);
            var data = await response.Content.ReadAsStringAsync();

            var listOfDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<Device[]>(data);
            return listOfDevices;

        }
        public async Task<Device> GetDevicesById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl1 + id);
            var data = await response.Content.ReadAsStringAsync();

            var device = Newtonsoft.Json.JsonConvert.DeserializeObject<Device>(data);
            return device;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurl1 + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<int> EditDevice(Device device)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurl1, new StringContent(JsonConvert.SerializeObject(device), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            return int.Parse(data);
        }
    }
}
