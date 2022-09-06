namespace CommonModels.Model
{
    using System;
    public class Document
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime? Time { get; set; }
        public string Img { get; set; }
        public string FileFormat { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }

    }
}
