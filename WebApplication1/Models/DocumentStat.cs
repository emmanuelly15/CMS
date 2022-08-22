using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class DocumentStat
    {
        public int DocId { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public int? DeviceId { get; set; }
        public DateTime? SentDate { get; set; }
        public string FileFormat { get; set; }
        public string Img { get; set; }
        public string Descriptions { get; set; }
        public string Locations { get; set; }
        public bool? Response { get; set; }
        public string DocumentType { get; set; }
        public decimal? Amount { get; set; }
        public string Comment { get; set; }
    }
}
