using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonModels.Model
{
    public class Dashboard
    {
        public int Id { get; set; }
        public int ActiveDevices { get; set; }
        public int ActiveEmails { get; set; }
        public int DocsSentDaily { get; set; }
    }
}
