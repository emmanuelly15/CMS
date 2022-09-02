using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurl + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<User> EditUser(int id)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurl, new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
            return user;
        }
    }
}
