using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommonModels.Model
{
    public class Device
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "IMEI is required")]
        public string IMEI { get; set; }

        [Required(ErrorMessage = "User is required")]
        public string User { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public string Groups { get; set; }

        [Required(ErrorMessage = "Authorisation is required")]
        public Boolean Authorisation { get; set; }

    }
}
