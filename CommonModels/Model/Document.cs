
namespace CommonModels.Model
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    public class Document
    {
       /* [FromForm(Name = "Docfile")]
        public IFormFile Docfile { get; set; }  */
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime? Time { get; set; }
        public string Img { get; set; }
        public string FileFormat { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }

    }
}
