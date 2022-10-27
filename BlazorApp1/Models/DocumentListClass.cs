using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class DocumentListClass
    {
        [Key]
        public int Id { get; set; }

        public DateTime? InsertedOn { get; set; }
    }
}
