using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.Model
{
    public class LoginModel
    {

        public string email { get; set; }
        [Required(ErrorMessage = "Email is required")]

        public string password { get; set; }
        [Required(ErrorMessage = "password is required")]

    }
}
