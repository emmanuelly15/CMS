using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Model.Database
{
    [Keyless]
    [Table("Dashboard", Schema = "dbo")]
    public class DbDashboard
    {
        [Required]
        public int ActiveDevices { get; set; }
        [Required]
        public int ActiveEmails { get; set; }
        [Required]
        public int DocsSentDaily { get; set; }
    }
}
