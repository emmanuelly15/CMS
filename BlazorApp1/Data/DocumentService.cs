using BlazorApp1.Pages;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class DocumentService
    {
        public async Task<int> SaveAsync(Document document) //saving a device to the database
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/document", new StringContent(JsonConvert.SerializeObject(document), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }

        public async Task<Document[]> GetDocumentsAsync() //getting data from the database
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/document");
            var data = await response.Content.ReadAsStringAsync();

            var listOfDocuments = Newtonsoft.Json.JsonConvert.DeserializeObject<Document[]>(data);
            return listOfDocuments;

        }
    }
}
