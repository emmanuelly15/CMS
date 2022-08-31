using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{
    public class MailingListService
    {
        public async Task<int> SaveAsync(MailingListC ml)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/mlist", new StringContent(JsonConvert.SerializeObject(ml), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<MailingListC[]> GetMLAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/mlist");
            var data = await response.Content.ReadAsStringAsync();

            var listOfMailingList = Newtonsoft.Json.JsonConvert.DeserializeObject<MailingListC[]>(data);
            return listOfMailingList;


        }
    }
}


