using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommonModels.Model
{
    public class Device
    {

        public int Id { get; set; }
       
        [RegularExpression(@"[^a-zA-Z''-'\s]+$", ErrorMessage = "Characters are not allowed.")] //validate only digits enters for emp id
        [Required(ErrorMessage = "IMEI is required")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Employee Id must contain 15 digits.")] //validate max and minimum amount of characters entered and error message
        public string IMEI { get; set; }

        [Required(ErrorMessage = "User is required")]
        public string User { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public string Groups { get; set; }

        [Required(ErrorMessage = "Authorisation is required")]
        public Boolean Authorisation { get; set; }

    }
}
