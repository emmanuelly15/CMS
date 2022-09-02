using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Model.Database
{
    [Table("Groups", Schema = "dbo")]
    public class DbGroup
    {


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Groups { get; set; }
        

    }

}

