using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int? SiteId { get; set; }
        public int? AdminId { get; set; }
        public string Ipaddress { get; set; }
        public string UserAgent { get; set; }
        public string UserData { get; set; }
        public string LastActivity { get; set; }
    }
}
