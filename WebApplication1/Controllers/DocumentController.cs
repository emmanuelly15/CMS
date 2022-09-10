using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
using Api.Models;
using System.IO;
using System;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        public IHostingEnvironment hostingEnvironment;

        private readonly DatabaseContext db; //refer to DatabaseContext.cs 
        public DocumentController(IHostingEnvironment hostingEnv, DatabaseContext db)
        {
            hostingEnvironment = hostingEnv;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Document> Get()
        {

            var docList = new List<Document>();

            var allDocuments = db.Documents.ToList().Select(v => new Document
            {
                Email = v.Email,
                Title = v.Title,
                Time = v.Time,
                Img = v.Img,
                FileFormat = v.FileFormat,
                Comment = v.Comment,
                Location = v.Location,
                Status = v.Status,
                Amount = v.Amount
            });

            return allDocuments; //} End of block 1. getting device data
                                 //get all devices information

        }
        public Document Get(int id)
        {
            var document = db.Documents.FirstOrDefault(u => u.Id == id);
            var documentview = new Document
            {
                Id = document.Id,
                Email = document.Email,
                Title = document.Title,
                Time = document.Time,
                Img = document.Img,
                FileFormat = document.FileFormat,
                Comment = document.Comment,
                Location = document.Location,
                Status = document.Status,
                Amount = document.Amount,
            };

            return documentview;
        }

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


        [HttpPost]
        public int Create(Document document)
        {
            var dbDocument = new DbDocument
            {
                Email = document.Email,
                Title = document.Title,
                Time = document.Time,
                Img = document.Img,
                FileFormat = document.FileFormat,
                Comment = document.Comment,
                Location = document.Location,
                Status = document.Status,
                Amount = document.Amount
            };

            db.Documents.Add(dbDocument);

            db.SaveChanges();
            return dbDocument.Id;
        }
        /*[HttpPost]
        public ActionResult<string> UploadDocument(Document document, int v)
        {
            
            try
            {
                var documents = HttpContext.Request.Form.Files;
                if (documents != null && documents.Count > 0)
                {
                    foreach (var docmnt in documents)
                    {
                        FileInfo doc = new FileInfo(docmnt.FileName);
                        var newdocname = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + doc.Extension;
                        var path = Path.Combine(" ", hostingEnvironment.ContentRootPath + "\\Images\\" + newdocname);
                       
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            docmnt.CopyTo(stream); //copying url to stream
                        }

                        Document imageupload = new Document();
                        imageupload.Id = document.Id;
                        imageupload.UserId = document.UserId;
                        imageupload.SentDateTime = DateTime.Now;
                        imageupload.FileFormat = document.FileFormat;
                        imageupload.Img = path;
                        imageupload.Description = document.Description;
                        imageupload.Location = document.Location;
                        imageupload.Status = document.Status;
                        imageupload.Amount = document.Amount;
                        imageupload.Comment = document.Comment;

                        db.Documents.Add(imageupload); //reference each column in table properly
                        db.SaveChanges();

                    }
                    return "Saved Succesful"; //message displayed after successful document uploaded
                }
                else
                {
                    return "Select Files";
                }
            }
            catch (Exception el)
            {
                return el.Message; //exception message
            }
        }
        [HttpGet]
        public ActionResult<List<Document>> GetImageUpload()
        {
            var results = db.Documents.ToList();
            return results; //maybe connected to imageupload error
        }*/

         /*[HttpPost("{id}")]
         [Route("UploadDocument")]
         public async Task<IActionResult> Upload([FromForm] Document doc)
         {
             var dbDocuments = db.Documents.FirstOrDefault(u => u.Id == doc.Id);
             var imagePath = Path.Combine(@"C:\uploadfolder\", doc.img_jpg.FileName);
             using (Stream fileStream = new FileStream(imagePath, FileMode.Create))
             {
                 await doc.img_jpg.CopyToAsync(fileStream);
             }
             var filePath = Path.Combine(@"C:\uploadfolder\", doc.file_pdf.FileName);
             using (Stream fileStream = new FileStream(filePath, FileMode.Create))
             {
                 await doc.file_pdf.CopyToAsync(fileStream);
             }
             return Ok();
         }*/
    }
}
