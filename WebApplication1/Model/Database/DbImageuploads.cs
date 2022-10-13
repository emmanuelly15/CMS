using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Api.Model.Database
{
    [Table("Imageuploads", Schema = "dbo")]
    public class DbImageuploads
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime InsertedOn { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string FileFormat { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public Decimal Amount { get; set; }
    }
}
