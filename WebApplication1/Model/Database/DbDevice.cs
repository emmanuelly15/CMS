using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Model.Database
{
    [Table("Device", Schema = "dbo")]
    public class DbDevice
    {


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string IMEI { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Groups { get; set; }
        [Required]
        public bool Authorisation { get; set; }


    }

}

