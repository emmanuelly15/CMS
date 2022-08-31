using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{
    public class UserService
    {
        public async Task<int> SaveAsync(User user)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/user", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            
            return int.Parse(data);
        }
        public async Task<User[]> GetUsersAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/user");
            var data = await response.Content.ReadAsStringAsync();

            var listOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(data);
            return listOfUsers;


        }
        public async Task<int> DeleteAsync()
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync("https://localhost:44304/user");
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
    }
}
