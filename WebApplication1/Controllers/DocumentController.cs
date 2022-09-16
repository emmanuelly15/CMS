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
        
    }
}
