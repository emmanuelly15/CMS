using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DocumentController> _logger;

        public DocumentController(ILogger<DocumentController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost]
        public object PostImage()
        {
            return null;
        }

            [HttpGet]
        public IEnumerable<Document> Get()
        {
            var docList = new List<Document>();

            docList.Add(new Document
            {
                Name = "Invoice",
                CreationDate = DateTime.Now,
                Creator = "Shanon",
                CellphoneNumber = "0729981533"

            });

            docList.Add(new Document
            {
                Name = "Purchase Order",
                CreationDate = DateTime.Now,
                Creator = "Shanon",
                CellphoneNumber = "0729981533"

            });

            return docList;
           

        }
    }
}
