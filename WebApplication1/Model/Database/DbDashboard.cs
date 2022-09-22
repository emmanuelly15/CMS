using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Database
{
    [Table("Dashboard", Schema = "dbo")]
    public class DbDashboard
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ActiveDevices { get; set; }
        [Required]
        public int ActiveEmails { get; set; }
        [Required]
        public int DocsSentDaily { get; set; }
    }
}
