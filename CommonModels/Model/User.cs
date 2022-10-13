using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonModels.Model
{
    
    public class User
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Employee name contains invalid characters.")] //enusres that user enter alphabet characters 
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress] //ensure an actual email is entered
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")] //ensure that only numbers are entered and validates length of phone number
        public string Telephone { get; set; }

        [RegularExpression(@"^.{8,}$")] //validate minimum amount of characters entered 
        [Required(ErrorMessage = "EmpId is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Employee Id must contain 8 characters.")] //validate maximum amount of characters entered and error message
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        
    }
}
