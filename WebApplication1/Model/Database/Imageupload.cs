using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Api.Model.Database
{
    public class Imageupload
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string imagepath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertedOn { get; set; }
    }
}
