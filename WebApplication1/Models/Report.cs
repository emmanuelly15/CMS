using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Report
    {
        public int? ActiveEmails { get; set; }
        public int? ActiveDevices { get; set; }
        public int? EmailsSendDaily { get; set; }
    }
}
