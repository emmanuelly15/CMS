using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CommonModels.Model
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
      

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
