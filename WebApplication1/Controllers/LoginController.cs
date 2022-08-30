using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext db;
        public LoginController( DatabaseContext db)
        {
            this.db = db;
        }

        public string alert { get; set; } = "You are in";

        [HttpGet]

       
        public string FindAdmin(LoginModel loginm)
        {
            
            var dbAdmin = new DbAdmin
            {
                
                Email = loginm.email,
                SecurePassword = loginm.password
            };

            var lmodel = new LoginModel();

           

            if (lmodel.email == dbAdmin.Email)
            {
                if (lmodel.password == dbAdmin.SecurePassword)
                {
                    db.Admins.Find(dbAdmin);

                    System.Console.WriteLine("Your are successfully in");
                }
            }

            return alert;


         
        }

    }
}
