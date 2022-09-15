using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CommonModels.Model
{
    public class AuthenticatedAdminModel
    {
        public string Access_Token { get; set; }
        public string email { get; set; }     
    }
}
