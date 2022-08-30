using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data.Migrations
{
    public class LoginService
    {
        public async Task<string> FindAdminAsync(LoginModel loginm)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/admin", new StringContent(JsonConvert.SerializeObject(loginm), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return data;
        }

    }
    
}
