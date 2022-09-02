using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupManagementController : ControllerBase
    {
        private readonly DatabaseContext db;
        public GroupManagementController(DatabaseContext db)
        {
            this.db = db;
        }


        [HttpGet]

        public IEnumerable<Group> Get()
        {
            var docList = new List<Group>();

            var allGroups = db.Groups.ToList().Select(v => new Group
            {
                Id = v.Id,
                Groups = v.Groups,
            });

            return allGroups;


        }
        [HttpGet("{id}")]

        public Group Get(int id)
        {
            var group = db.Groups.FirstOrDefault(u => u.Id == id);
            var groupview = new Group
            {
                Id = group.Id,
                Groups = group.Groups,
                
            };

            return groupview;
        }
        [HttpPost]
        public int Create(Group group)
        {
            var dbGroup = new DbGroup
            {
                Groups = group.Groups,
                
            };

            db.Groups.Add(dbGroup);

            db.SaveChanges();
            return dbGroup.Id;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var group = db.Groups.FirstOrDefault(u => u.Id == id);
            if (group != null)
                db.Groups.Remove(group);

            db.SaveChanges();
            return true;
        }
    }
}
