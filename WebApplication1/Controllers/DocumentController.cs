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
using Microsoft.VisualBasic;

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
                Amount = v.Amount,
                Reason = v.Reason == "B" ? "Blurry" : (v.Reason == "N" ? "Amount Not Shown" : v.Reason == "I" ? "Incorrect Information" : v.Reason == "C" ? "Commment Not Shown" : "No Reason")
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
                Reason = imageupload.Reason == "B" ? "Blurry" : (imageupload.Reason == "N" ? "Amount Not Shown" : imageupload.Reason == "I" ? "Incorrect Information" : imageupload.Reason == "C" ? "Commment Not Shown"  : "No Reason")

            };

            return imageuploadview;
        }
        [HttpGet("ApproveDoc/{id}")]
        public void ApproveDoc(int id)
        {
          var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Status = "A";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("RejectDoc/{id}")]
        public void RejectDoc(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Status = "R";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("BlurryR/{id}")]
        public void Blurry(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Reason = "B";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("AmountR/{id}")]
        public void NAmountS(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Reason = "N";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("InfoR/{id}")]
        public void IInfo(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Reason = "I";
            db.Update(imageupload);
            db.SaveChanges();
        }
        [HttpGet("CommentR/{id}")]
        public void CommentNS(int id)
        {
            var imageupload = db.Documents.FirstOrDefault(u => u.Id == id);
            imageupload.Reason = "C";
            db.Update(imageupload);
            db.SaveChanges();
        }
    }
}
