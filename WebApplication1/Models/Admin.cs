using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int? AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SecurePassword { get; set; }
    }
}
