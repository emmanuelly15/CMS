using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Api.Model.Database
{
    [Table("Document", Schema = "dbo")]
    public class DbDocument
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /*[FromForm(Name = "Docfile")]
        public IFormFile Docfile { get; set; }*/
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime? Time { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string FileFormat { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
