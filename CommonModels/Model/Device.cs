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
       
        [RegularExpression(@"[^a-zA-Z''-'\s]+$", ErrorMessage = "Only numbers or digits are allowed for IMEI.")] //validate only digits enters for IMEI
        [Required(ErrorMessage = "IMEI is required")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "IMEI must contain 15 digits.")] //validate max and minimum amount of characters entered and error message
        public string IMEI { get; set; }

        [Required(ErrorMessage = "User is required")]
        public string User { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public string Groups { get; set; }

        [Required(ErrorMessage = "Authorisation is required")]
        public Boolean Authorisation { get; set; }

    }
}
