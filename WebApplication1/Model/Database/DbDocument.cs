using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Api.Model.Database
{
    [Table("Document", Schema = "dbo")]
    public class DbDocument
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime? SentDateTime { get; set; }
        [Required]               // ---Can move FromForm img_jpg here later
        public string FileFormat { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Comment { get; set; }

       // [FromForm(Name = "img_jpg")]  //got link from Gilbert  getting img.jpg from database
        //public List<DbDocument> Img { get; set; }
        //[FromForm(Name = "file_pdf")] //getting file.pdf from database
        //public List<DbDocument> FileFormat { get; set; }
    }
}
