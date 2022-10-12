using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class DocumentListClass
    {
        [Key]
        public int Id { get; set; }

        //public DateFormat InsertedOn { get; set; }
    }
}
