using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonModels.Model
{
    public class AdminUser
    {
        public int Id { get; set; }

        
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Name entered contains invalid characters.")] //ensures that user enter alphabet characters 
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress] //ensure an actual email is entered
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|co.za)$", ErrorMessage = "Invalid pattern at email.")]
        public string Email { get; set; }

       [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,32}$", ErrorMessage = "Password doesn't meet security rules.")] //validate that password meets standard requirements
        public string Password { get; set; }

        [Required(ErrorMessage = "Authorisation is required")]
        public Boolean Authorize { get; set; }
    }
}
