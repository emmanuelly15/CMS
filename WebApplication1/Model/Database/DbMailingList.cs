using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Model.Database
{
    [Table("MailingList", Schema = "dbo")]
    public class DbMailingList
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Groups { get; set; }


    }

}