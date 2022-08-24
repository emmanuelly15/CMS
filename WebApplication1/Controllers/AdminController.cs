using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
    

            [HttpGet]
        public IEnumerable<Admin> Get()
        {
           using (var context = new PaycoDBContext())
            {

                //get all admin information

                //return context.Admins.ToList();

                //Add Admin information to database

                Admin admin = new Admin();
                admin.AdminId = 00000;
                admin.FirstName = "emma";
                admin.LastName = "kabamba";
                admin.Email = "emmakabamba@gmail.com";
                admin.SecurePassword = "123";

                context.Admins.Add(admin);

                //Update admin information

                Admin admin1 = context.Admins.Where(admin => admin.FirstName == "emma").FirstOrDefault();
                admin.SecurePassword = "12345";

                //Remove Admin

                Admin admin2 = context.Admins.Where(admin => admin.FirstName == "emma").FirstOrDefault();
                context.Admins.Remove(admin);


                context.SaveChanges();

                return context.Admins.Where(admin => admin.FirstName == "emma").ToList();
            }
        }
    }
}
