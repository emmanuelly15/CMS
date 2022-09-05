using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string GroupId { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public DateTime? SentDateTime { get; set; }
        [Required]
        public string FileFormat { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string DocType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
