using CommonModels.Model;
using Newtonsoft.Json;
using System.Net.Http;
using Api.Model;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Console;
using System;
namespace BlazorApp1.DbServices
{
    public class ImageUploadService
    {
        string apiurl4 = "https://localhost:44304/imageupload/";
        public async Task<Imageupload[]> GetImagesAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiurl4);
            var data = await response.Content.ReadAsStringAsync();

            var listOfImages = Newtonsoft.Json.JsonConvert.DeserializeObject<Imageupload[]>(data);
            return listOfImages;


        }
        public async Task<Imageupload> GetImagesById(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(apiurl4 + id);
            var data = await response.Content.ReadAsStringAsync();

            var imageupload = Newtonsoft.Json.JsonConvert.DeserializeObject<Imageupload>(data);
            return imageupload;
        }
    }
}
