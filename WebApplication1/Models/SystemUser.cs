using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhone { get; set; }
    }
}
