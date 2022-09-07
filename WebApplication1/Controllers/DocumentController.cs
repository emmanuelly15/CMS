using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
using Api.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly DatabaseContext db; //refer to DatabaseContext.cs 
        public DocumentController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Document> Get()
        {

            var docList = new List<Document>();

            var allDocuments = db.Documents.ToList().Select(v => new Document
            {
                UserId = v.UserId,
                GroupId = v.GroupId,
                DeviceId = v.DeviceId,
                SentDateTime = v.SentDateTime,
                FileFormat = v.FileFormat,
                Img = v.Img,
                Description = v.Description,
                Location = v.Location,
                Status = v.Status,
                DocType = v.DocType,
                Amount = v.Amount,
                Comment = v.Comment
            });

            return allDocuments; //} End of block 1. getting device data
                                   //get all devices information



        //private readonly ILogger<DocumentController>_logger;

       // public DocumentController(ILogger<DocumentController> logger)
        //{
          //  _logger = logger;
        //}

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

       /* [HttpPost]
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

            return docList;*/
           
        }

        [HttpPost]
        public int Create(Document document)
        {
            var dbDocument = new DbDocument 
            {
                UserId = document.UserId,
                GroupId = document.GroupId,
                DeviceId = document.DeviceId,
                SentDateTime = document.SentDateTime,
                FileFormat = document.FileFormat,
                Img = document.Img,
                Description = document.Description,
                Location = document.Location,
                Status = document.Status,
                DocType = document.DocType,
                Amount = document.Amount,
                Comment = document.Comment
            };

            db.Documents.Add(dbDocument);

            db.SaveChanges();
            return dbDocument.Id;
        }
      /*  public class DocumentImg  --got from link that Gilbert sent
        {
           [FromForm(Img = "img_jpg")]
            public List<Document> img_jpg { get; set; }
            [FromForm(FileFormat = "file_pdf")]
            public List<Document> ifile_pdf { get; set; }
        }*/
    }
}
