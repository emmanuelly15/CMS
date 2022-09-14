using Api.Model.Database;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageUploadController : Controller
    {
        public IHostingEnvironment hostingEnvironment; //
        public DatabaseContext dbaseContext;

        public ImageUploadController(IHostingEnvironment hostingEnv, DatabaseContext db)
        {
            hostingEnvironment = hostingEnv;
            dbaseContext = db;
        }

        [HttpPost]
        public ActionResult<string> UploadImages()
        {

            try
            {
                var files = HttpContext.Request.Form.Files;
                var form = HttpContext.Request.Form;
                var hasEmail = form.TryGetValue("email", out var email);
                var hasTitle = form.TryGetValue("title", out var title);
                var hasFileFormat = form.TryGetValue("fileformat", out var fileformat);
                var hasComment = form.TryGetValue("comment", out var comment);
                var hasLocation = form.TryGetValue("location", out var location);
                var hasAmount = form.TryGetValue("amount", out var amount);
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("\\Users\\shank\\Source\\Repos\\emmanuelly15\\CMS\\BlazorApp1\\wwwroot\\Images\\" + newfilename);
                        var dbPath = Path.Combine("",  "Images/" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream); //copying url to stream
                        }

                        Imageupload imageupload = new Imageupload();
                       
                        imageupload.ImagePath = dbPath;
                        imageupload.InsertedOn = DateTime.Now;
                        if(hasEmail) imageupload.Email = email;
                        if(hasTitle) imageupload.Title = title;
                        if (hasFileFormat) imageupload.FileFormat = fileformat;
                        if (hasComment) imageupload.Comment = comment;
                        if (hasLocation) imageupload.Location = location;
                        imageupload.Status = "P";
                        if (hasAmount) 
                        {
                            var amt = Decimal.Parse(amount[0], CultureInfo.InvariantCulture);
                           //ecimal.TryParse(amount[0], out decimal amt);
                            //var amt = amount[0];
                            imageupload.Amount = amt;

                        }
                        dbaseContext.Imageuploads.Add(imageupload); //reference each column in table properly
                        dbaseContext.SaveChanges();

                    }
                    return "Saved Successful"; //message displayed after successful document uploaded
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
        /* [HttpGet]
         public ActionResult<List<Imageupload>> GetImageUpload()
         {
             var result = dbaseContext.Imageuploads.ToList();
             return result;
         }*/
        [HttpGet]
        public IEnumerable<Imageupload> Get()
        {
            var docList = new List<Imageupload>();

            var allImageuploads = dbaseContext.Imageuploads.ToList().Select(v => new Imageupload
            {
                Id = v.Id,
                Email = v.Email,
                Title = v.Title,
                InsertedOn = v.InsertedOn,
                ImagePath = v.ImagePath,
                FileFormat = v.FileFormat,
                Comment = v.Comment,
                Location = v.Location,
                Amount = v.Amount
                

            });

            return allImageuploads;
             }
        [HttpGet("{id}")]

        public Imageupload Get(int id)
        {
            var imageupload = dbaseContext.Imageuploads.FirstOrDefault(u => u.Id == id);
            var imageuploadview = new Imageupload
            {
                Id = imageupload.Id,
                Email = imageupload.Email,
                Title = imageupload.Title,
                InsertedOn = imageupload.InsertedOn,
                ImagePath = imageupload.ImagePath,
                FileFormat = imageupload.FileFormat,
                Comment = imageupload.Comment,
                Location = imageupload.Location,
                Amount = imageupload.Amount

            };

            return imageuploadview;
        }
    }
    /* [HttpPost]
     public async Task<IActionResult> UploadImage(CommonModels.Model.Imageupload imageupload)
     {
         if (ModelState.IsValid)
         {
             if (imageupload.Image != null)
             {
                 string folder = "api/images/";
                 folder + -Guid.NewGuid().ToString() + "_" + imageupload.CoverPhoto.FileName;

                 CommonModels.Model.Imageupload.CoverImageUrl = folder;

                 string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                 await imageupload.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
             }

             int id = await _imageRepository.AddNewImage(Imageupload);
             if (id > 0)
             {
                 return RedirectToAction(nameof(AddNewImage), new { isSuccess = true, imgId = id });
             }
         }

     }*/
   
}
    

