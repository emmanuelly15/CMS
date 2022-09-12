
namespace CommonModels.Model
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;
    using System.Xml.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Document
    {
       /* [FromForm(Name = "Docfile")]
        public IFormFile Docfile { get; set; }*/
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

        /*[FromForm(Name = "img_jpg")]  //got link from Gilbert  getting img.jpg from database
        public IFormFile img_jpg { get; set; }
        //public List<DbDocument> Img { get; set; }
        [FromForm(Name = "file_pdf")] //getting file.pdf from database
        public IFormFile file_pdf { get; set; }
        //public List<DbDocument> FileFormat { get; set; }
    }

   public class UploadDocument //creating model class for uploading a document
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string imagepath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertedOn { get; set; }
    }*/
    }
}