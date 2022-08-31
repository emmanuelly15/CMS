using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;

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
               Groups = v.Groups,
                
            });

            return allGroups;


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
    }
}
