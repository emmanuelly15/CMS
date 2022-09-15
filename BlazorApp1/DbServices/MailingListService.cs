using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data

{

    public class MailingListService
    {
        string apiurls = "https://localhost:44304/mailinglist/";
        public async Task<int> SaveAsync(MailingListC ml)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiurls, new StringContent(JsonConvert.SerializeObject(ml), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<MailingListC[]> GetMLAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurls);
            var data = await response.Content.ReadAsStringAsync();

            var listOfMailingList = Newtonsoft.Json.JsonConvert.DeserializeObject<MailingListC[]>(data);
            return listOfMailingList;
         }
        public async Task<MailingListC> GetMLById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurls + id);
            var data = await response.Content.ReadAsStringAsync();

            var ml = Newtonsoft.Json.JsonConvert.DeserializeObject<MailingListC>(data);
            return ml;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(apiurls + id);
            var data = await response.Content.ReadAsStringAsync();


            return bool.Parse(data);
        }
        public async Task<MailingListC> EditMailingList(MailingListC ml)
        {
            var client = new HttpClient();
            var response = await client.PutAsync(apiurls, new StringContent(JsonConvert.SerializeObject(ml), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();

            var mlresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<MailingListC>(data);
            return mlresponse;
        }
    }
}


