using Api.Model.Database;
using CommonModels.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DatabaseContext db;
        public DashboardController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]

        public IEnumerable<Dashboard> Get()
        {
            var docList = new List<Dashboard>();

            var allInfo = db.Dashboards.ToList().Select(v => new Dashboard
            {
                Id = v.Id,
                ActiveDevices = v.ActiveDevices,
                ActiveEmails = v.ActiveEmails,
                DocsSentDaily = v.DocsSentDaily,
            });

            return allInfo;


        }
    }
}
