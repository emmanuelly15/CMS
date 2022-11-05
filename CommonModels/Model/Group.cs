using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommonModels.Model
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Group is required")]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Group contains invalid characters.")] //ensures that user enters alphabet characters 
        public string Groups { get; set; }

    }
}
