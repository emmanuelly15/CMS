using Api.Model.Database;
using BlazorApp1.Pages;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DbServices
{
    public class DocumentService
    {

        public async Task<int> SaveAsync(Imageupload imageupload) //saving a device to the database
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/document", new StringContent(JsonConvert.SerializeObject(imageupload), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<int> Upload(Document doc) //saving a device to the database
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44304/document", new StringContent(JsonConvert.SerializeObject(doc), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }

        public async Task<Imageupload[]> GetDocumentsAsync() //getting data from the database
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/document");
            var data = await response.Content.ReadAsStringAsync();

            var listOfImageuploads = Newtonsoft.Json.JsonConvert.DeserializeObject<Imageupload[]>(data);
            return listOfImageuploads;

        }
        public async Task<Imageupload> GetDocumentById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/document" + id);
            var data = await response.Content.ReadAsStringAsync();

            var imageupload = Newtonsoft.Json.JsonConvert.DeserializeObject<Imageupload>(data);
            return imageupload;
        }
        public async Task ApproveDocumentById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/ApproveDoc/" + id);

        }
        public async Task RejectDocumentById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44304/RejectDoc/" + id);

        }
    }
}