using CommonModels.Model;
using Newtonsoft.Json;
using System.Linq;
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
        //include get by id and it's referenced on the updateGroup
        /*public async Task<int> UpdateAsync(Group updategroup)
        {
            var client = new HttpClient();
            var response = await client.PutAsync("https://localhost:44304/groupmanagement", new StringContent(JsonConvert.SerializeObject(updategroup), Encoding.UTF8, "application/json"));
            var editGroup = await response.Content.ReadAsStringAsync();

           // var editGroup = Newtonsoft.Json.JsonConvert.DeserializeObject<Group[]>(id);
            if (editGroup != null)
            {
                editGroup.Group = updategroup.Groups;
                //Group.SaveAsync();
                return int.Parse(editGroup);
            }
            else 
            {
                //return false;  created as a bool, timestamp -49:01
            }
            //return true;
            
        }//delete function timestamp 52:42*/
    }
}

