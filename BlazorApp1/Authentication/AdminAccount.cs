using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Authentication
{
    public class AdminAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Authorize { get; set; } 
    }
}
