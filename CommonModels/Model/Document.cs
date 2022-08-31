namespace CommonModels.Model
{
    using System;
    public class Document
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int DeviceId { get; set; }
        public DateTime? SentDateTime { get; set; }
        public string FileFormat { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string DocType { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }

    }
}
