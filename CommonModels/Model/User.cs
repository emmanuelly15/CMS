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
        [StringLength(10)]
        [Phone] //ensure that only numbers are entered --NEED TO VALIDATE LENGTH OF PHONE NUMBER      
        public string Telephone { get; set; }

        [Required(ErrorMessage = "EmpId is required")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        
    }
}
