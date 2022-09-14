using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
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
        //private readonly DocumentService svc;
        private readonly DatabaseContext db; //refer to DatabaseContext.cs 
        public DocumentController(IHostingEnvironment hostingEnv, DatabaseContext db)
        {
            hostingEnvironment = hostingEnv;
            this.db = db;
        }
        
        
        
        [HttpGet]
        public IEnumerable<Imageupload> Get()
        {

            var docList = new List<Imageupload>();

            var allImageuploads = db.Documents.ToList().Select(v => new Imageupload
            {
                Id =v.Id,
                Email = v.Email,
                Title = v.Title,
                InsertedOn = (DateTime)v.InsertedOn,
                ImagePath = v.ImagePath,
                FileFormat = v.FileFormat,
                Comment = v.Comment,
                Location = v.Location,
                Status = v.Status == "A"? "Accepted" :(v.Status == "R" ? "Rejected" : "Pending" ),
                Amount = v.Amount

            });

            return allImageuploads; //} End of block 1. getting device data
                                 //get all devices information

        }
        [HttpGet("{id}")]
        public Imageupload Get(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            var imageuploadview = new Imageupload
            {
                Id = imageupload.Id,
                Email = imageupload.Email,
                Title = imageupload.Title,
                InsertedOn = (DateTime)imageupload.InsertedOn,
                ImagePath = imageupload.ImagePath,
                FileFormat = imageupload.FileFormat,
                Comment = imageupload.Comment,
                Location = imageupload.Location,
                Status = imageupload.Status == "A" ? "Accepted" : (imageupload.Status == "R" ? "Rejected" : "Pending"),
                Amount = imageupload.Amount,
            };

            return imageuploadview;
        }
        [HttpGet("/ApproveDoc/{id}")]
        public void ApproveDoc(int id)
        {
          var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Status = "A";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("/RejectDoc/{id}")]
        public void RejectDoc(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Status = "R";
            db.Update(imageupload);
            db.SaveChanges();
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
