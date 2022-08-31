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
               Email = v.Email,
               Groups = v.Groups,

            });

            return allMailingLists;


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
    }
}
