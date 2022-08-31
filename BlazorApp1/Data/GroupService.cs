using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{
    public class GroupService
    {
        public async Task<int> SaveAsync(Group group)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/groupmanagement", new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<Group[]> GetGroupsAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/groupmanagement");
            var data = await response.Content.ReadAsStringAsync();

            var listOfGroups = Newtonsoft.Json.JsonConvert.DeserializeObject<Group[]>(data);
            return listOfGroups;


        }
    }
}

