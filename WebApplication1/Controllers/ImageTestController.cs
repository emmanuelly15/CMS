using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using Api.Model.Database;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageTestController : Controller
    {
        public IHostingEnvironment hostingEnvironment;
        public DatabaseContext dbaseContext;

        public ImageTestController(IHostingEnvironment hostingEnv, DatabaseContext db)
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
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine(" ", hostingEnvironment.ContentRootPath + "\\Images\\" + newfilename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream); //copying url to stream
                        }

                        Imageupload imageupload = new Imageupload();
                        imageupload.imagepath = path;
                        imageupload.InsertedOn = DateTime.Now;
                        dbaseContext.Imageuploads.Add(imageupload); //reference each column in table properly
                        dbaseContext.SaveChanges();

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
        public ActionResult<List<Imageupload>> GetImageUpload() 
        {
            var result = dbaseContext.Imageuploads.ToList();
            return result;
        }
    }
}
