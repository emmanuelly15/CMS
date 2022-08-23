using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class DeviceManagement
    {
        public int Id { get; set; }
        public int? DeviceId { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public string DeviceImei { get; set; }
        public string LastLocation { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? Authorised { get; set; }
    }
}
