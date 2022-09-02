using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailingListController : ControllerBase
    {
        private readonly DatabaseContext db;
        public MailingListController(DatabaseContext db)
        {
            this.db = db;
        }

         [HttpGet]

        public IEnumerable<MailingListC> Get()
        {
            var docList = new List<MailingListC>();

            var allMailingLists = db.ML.ToList().Select(v => new MailingListC
            {
                Id = v.Id,
                Email = v.Email,
               Groups = v.Groups,

            });
                return allMailingLists;
         }
        [HttpGet("{id}")]

        public MailingListC Get(int id)
        {
            var ml = db.ML.FirstOrDefault(u => u.Id == id);
            var mlview = new MailingListC
            {
                Id = ml.Id,
                Email = ml.Email,
                Groups = ml.Groups,
            };

            return mlview;
        }
        
        [HttpPost]
        public int Create(MailingListC ml)
        {
            var dbMailingList = new DbMailingList
            {
                Email = ml.Email,
                Groups = ml.Groups,
            };

            db.ML.Add(dbMailingList);

            db.SaveChanges();
            return dbMailingList.Id;
        }
        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var ml = db.ML.FirstOrDefault(u => u.Id == id);
            if (ml != null)
                db.ML.Remove(ml);

            db.SaveChanges();
            return true;
        }
        [HttpPut("{id}")]
        public int UpdateMailingList(MailingListC ml)
        {
            var dbMailingList = db.ML.FirstOrDefault(u => u.Id == ml.Id);
            dbMailingList.Email = ml.Email;
            dbMailingList.Groups = ml.Groups;

            db.SaveChanges();
            return dbMailingList.Id;

        }
    }
}
