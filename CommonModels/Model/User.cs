using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Web.Mvc;

namespace CommonModels.Model
{
    
    public class User
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Employee name contains invalid characters.")] //ensures that user enters alphabet characters 
        public string Name { get; set; }

        [Required(ErrorMessage  = "Email is required")]
        [EmailAddress] //ensure an actual email is enteredhttps://startblazoring.com/Blog/SignInManager
       // [Remote("EmailExists", "Account", "POST", ErrorMessage = "Email address already registered.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|co.za)$", ErrorMessage = "Invalid pattern at email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")] //ensure that only numbers are entered and validates length of phone number
        public string Telephone { get; set; }

        [RegularExpression(@"[^a-zA-Z''-'\s]+$", ErrorMessage = "Characters are not allowed for employee id.")] //validate only digits enters for emp id
        [Required(ErrorMessage = "Empployee Id is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Employee Id must contain 8 characters.")] //validate max and minimum amount of characters entered and error message
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,32}$", ErrorMessage = "Password doesn't meet security rules." +
            "Password must contain numbers between 0-9." +
            "Password must contain uppercase and lowercase letters " +
            "Password must contain non-alphanumeric characters. Eg. !@#$%&" +
            "Password must have a length of minimum 8 characters and a maximum of 32 characters.")] //validate that password meets standard requirements
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must have a length of minimum 8 characters and a maximum of 32 characters.")] //validate max and minimum amount of characters entered and error message
        public string Password { get; set; }

        
    }
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class UserProfile
    {
        public string ErrorMessage { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        public string Telephone { get; set; }

        public string EmpId { get; set; }


    }
}
