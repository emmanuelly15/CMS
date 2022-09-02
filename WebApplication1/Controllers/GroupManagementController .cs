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

        /*[HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Group group) //<- 2 values, the id we are calling and the new value that we're going to add it with
        {
            var groupExists = await DbGroup(id);
            if (!groupExists) 
            {
                return NotFoud();
            }

            context.Update(group);
            await ActionContext.SaveChangesAsync();
            return NoContent();
        }*/

    }
}
