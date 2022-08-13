namespace CommonModels.Model
{
    using System;
    public class Document
    {
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Creator { get; set; }
        public string Url { get; set; }
        public string CellphoneNumber { get; set; }

    }
}
