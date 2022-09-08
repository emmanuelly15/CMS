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
                UserId = v.UserId,
                SentDateTime = v.SentDateTime,
                FileFormat = v.FileFormat,
                Img = v.Img,
                Description = v.Description,
                Location = v.Location,
                Status = v.Status,
                Amount = v.Amount,
                Comment = v.Comment
            });

            return allDocuments; //} End of block 1. getting device data
                                 //get all devices information


            /* [HttpPost]
             public object PostImage()
             {
                 return null;
             }*/

        }
        /*[HttpPost]
        public int Create(Document document)
        {
            var dbDocument = new DbDocument
            {
                UserId = document.UserId,
                SentDateTime = document.SentDateTime,
                FileFormat = document.FileFormat,
                Img = document.Img,
                Description = document.Description,
                Location = document.Location,
                Status = document.Status,
                Amount = document.Amount,
                Comment = document.Comment
            };

            db.Documents.Add(dbDocument);

            db.SaveChanges();
            return dbDocument.Id;
        }*/
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
