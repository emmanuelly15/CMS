using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Console;
using System;

namespace BlazorApp1.Data

{
    public class UserService
    {
        string apiurl = "https://localhost:44304/user/";
        public async Task<int> SaveAsync(User user)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiurl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            
            return int.Parse(data);
        }
        public async Task<User[]> GetUsersAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurl);
            var data = await response.Content.ReadAsStringAsync();

            var listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(data);
            return listOfUsers;


        }
        public async Task<User> GetUserById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl + id);
            var data = await response.Content.ReadAsStringAsync();

            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
            return user;
        }
        //adding user password hash
       /* string HashPassword(string password) //hashpassword method
        {
            using SHA256 hash = SHA256.Create(); //call create method to return instance of SHA
            var passwordBytes = Encoding.Default.GetBytes(password);
            //must change string to bytes to pass to ComputeHash method
            hash.ComputeHash(passwordBytes); //call another method

            //return an array of bytes and then convert to string
            var hashedpassword = hash.ComputeHash(passwordBytes);

            //convert method to convert bytes to string
            return Convert.ToBase64String(hashedpassword);

        }*/
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurl + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<int> EditUser(User user)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            return int.Parse(data);
        }
    }
}
