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
    public class AdminController : ControllerBase
    {
        private readonly DatabaseContext dbs;
        public DbAdmin(DatabaseContext dbs)
        {
            this.dbs = dbs;
        }


        [HttpGet]

        public IEnumerable<Admin> Get()
        {
            var docList = new List<Admin>();

            var allAdmins = db.Admin.ToList().Select(v => new Admin
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,

            });

            return allAdmins;


        }
        [HttpGet("{id}")]

        public AdminUser Get(int id)
        {
            var admin = db.Admin.FirstOrDefault(u => u.Id == id);
            var adminview = new Admin
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,

            };

            return adminview;
        }
        [HttpPost]
        public int Create(Admin admin)
        {
            var dbAdmin = new DbAdmin
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Password = admin.SecurePassword
            };

            db.Admin.Add(dbAdmin);

            db.SaveChanges();
            return dbAdmin.Id;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var admin = db.Admin.FirstOrDefault(u => u.Id == id);
            if (admin != null)
                db.AdminUsers.Remove(admin);

            db.SaveChanges();
            return true;
        }
        [HttpPut("{id}")]
        public int UpdateAdmin(Admin admin)
        {
            var dbAdmin = db.Admin.FirstOrDefault(u => u.Id == admin.Id);

            dbAdmin.Name = admin.FirstName;
            dbAdmin.Email = admin.LastName;
            dbAdmin.Password = admin.SecurePassword;

            db.SaveChanges();
            return dbAdmin.Id;

        }

    }
}
