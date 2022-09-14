using System;

namespace CommonModels.Model
{
    public class Imageupload
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime InsertedOn { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FileFormat { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Decimal Amount { get; set; }
        /*public string CoverImageUrl { get; set; }*/
    }
}
