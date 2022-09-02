﻿using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminUserController : ControllerBase
    {
        private readonly DatabaseContext db;
        public AdminUserController(DatabaseContext db)
        {
            this.db = db;
        }


        [HttpGet]

        public IEnumerable<AdminUser> Get()
        {
            var docList = new List<AdminUser>();

            var allAdminUsers = db.AdminUsers.ToList().Select(v => new AdminUser
            {
                Id = v.Id,
                Name = v.Name,
                Email = v.Email,
                
            });

            return allAdminUsers;


        }
        [HttpGet("{id}")]

        public AdminUser Get(int id)
        {
            var adminuser = db.AdminUsers.FirstOrDefault(u => u.Id == id);
            var adminuserview = new AdminUser
            {
                Id = adminuser.Id,
                Name = adminuser.Name,
                Email = adminuser.Email,
                
            };

            return adminuserview;
        }
        [HttpPost]
        public int Create(AdminUser adminuser)
        {
            var dbAdminUser = new DbAdminUser
            {
                Name = adminuser.Name,
                Email = adminuser.Email,
               Password = adminuser.Password
            };

            db.AdminUsers.Add(dbAdminUser);

            db.SaveChanges();
            return dbAdminUser.Id;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var adminuser = db.AdminUsers.FirstOrDefault(u => u.Id == id);
            if (adminuser != null)
                db.AdminUsers.Remove(adminuser);

            db.SaveChanges();
            return true;
        }


    }
}
