using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Model.Database
{
    [Table("User", Schema = "dbo")]
    public class DbMailingList
    {


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Telephone { get; set; }
        [Required]
        public string EmpId { get; set; }
        [Required]
        public string Password { get; set; }


    }

}