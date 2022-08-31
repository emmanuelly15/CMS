using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Site
    {
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
    }
}
