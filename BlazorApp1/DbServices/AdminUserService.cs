﻿using BlazorApp1.Services;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{
    public class AdminUserService: BaseServices
    {
        string apiurl2 = BaseApiUrl + "adminuser/";
        public async Task<int> SaveAsync(AdminUser adminuser)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiurl2, new StringContent(JsonConvert.SerializeObject(adminuser), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<AdminUser[]> GetAdminUsersAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurl2);
            var data = await response.Content.ReadAsStringAsync();

            var listOfAdminUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminUser[]>(data);
            return listOfAdminUsers;


        }
       /* public async Task<int> Login(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl2 + id);
            var data = await response.Content.ReadAsStringAsync();

            return int.Parse(data);
        }*/
        public async Task<AdminUser> GetAdminUserById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl2 + id);
            var data = await response.Content.ReadAsStringAsync();

            var adminuser = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminUser>(data);
            return adminuser;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurl2 + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<int> EditAdminUser(AdminUser adminuser)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurl2, new StringContent(JsonConvert.SerializeObject(adminuser), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            return int.Parse(data);
        }
    }
}
