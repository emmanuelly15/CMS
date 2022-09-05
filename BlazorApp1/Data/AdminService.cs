using Api.Models;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{
    public class AdminService
    {
        string apiurl2 = "https://localhost:44304/adminuser/";
        public async Task<int> SaveAsync(Admin admin)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiurl2, new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<Admin[]> GetAdminAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurl2);
            var data = await response.Content.ReadAsStringAsync();

            var listOfAdmin = Newtonsoft.Json.JsonConvert.DeserializeObject<Admin[]>(data);
            return listOfAdmin;


        }
        public async Task<Admin> GetAdminById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl2 + id);
            var data = await response.Content.ReadAsStringAsync();

            var admin = Newtonsoft.Json.JsonConvert.DeserializeObject<Admin>(data);
            return admin;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurl2 + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<Admin> EditAdmin(int id)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurl2, new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            var admin = Newtonsoft.Json.JsonConvert.DeserializeObject<Admin>(data);
            return admin;
        }
    }
}