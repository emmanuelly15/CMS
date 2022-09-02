using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonModels.Model
{
    public class MailingListC
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public string Groups { get; set; }
    }
}

