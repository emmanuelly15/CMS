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
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Employee name contains invalid characters.")] //ensures that user enters alphabet characters 
        //[RegularExpression(@"(^[A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})", 
        //  ErrorMessage = "Group must start with Capital.")] //validate that group starts with caps --does not currently work properly
        public string Groups { get; set; }

    }
}
