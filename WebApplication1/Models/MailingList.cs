using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class MailingList
    {
        public int MailId { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
    }
}
