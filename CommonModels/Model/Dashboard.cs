using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CommonModels.Model
{
    public class Dashboard
    {
       // Task<ICollection<ActiveEmails>> LoadActiveEmails(); //define the method to load the emails
        //Task<ICollection<ActiveDevices>> LoadActiveDevices();
       // Task<ICollection<DocsSentDaily>> LoadDocsSentDaily();
        //public int Id { get; set; }
        public int ActiveEmails { get; set; }
        public int ActiveDevices { get; set; }
        public int DocsSentDaily { get; set; }
    }
}
