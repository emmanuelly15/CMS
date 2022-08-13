namespace Api.Model.Database
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("notification")]
    public class DbNotification
    {
        
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
