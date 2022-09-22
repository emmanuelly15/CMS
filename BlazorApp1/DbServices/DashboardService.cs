using BlazorApp1.Services;
using CommonModels.Model;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DbServices
{
    public class DashboardService : BaseServices
    {
        //string apiur = "https://localhost:44304/groupmanagement/";
        string apiuRl = BaseApiUrl + "dashboard/";
        public async Task<int> SaveAsync(Dashboard dashboard)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(apiuRl, new StringContent(JsonConvert.SerializeObject(dashboard), Encoding.UTF8, "application/json"));
            var data = await response.Content.ReadAsStringAsync();


            return int.Parse(data);
        }
        public async Task<Dashboard[]> GetDashboardsAsync()
        {

            var client = new HttpClient();
            var response = await client.GetAsync(apiuRl);
            var data = await response.Content.ReadAsStringAsync();

            var listOfInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dashboard[]>(data);
            return listOfInfo;
        }
    }
}
