using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext db;
        public UserController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]

        public IEnumerable<User> Get()
        {
            var docList = new List<User>();

            var allUsers = db.Users.ToList().Select(v => new User
            {
                Id= v.Id,
                Name = v.Name,
                Email = v.Email,
                Telephone = v.Telephone,
                EmpId = v.EmpId
            });

            return allUsers;


        }
        [HttpGet("{id}")]

        public User Get(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            var userview = new User
            {
               Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                EmpId = user.EmpId,
                Password = user.Password
            };

            return userview;
         }
        [HttpPost]
        public int Create(User user)
        {
            var dbUser = new DbUser
            {
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                EmpId = user.EmpId,
                Password = user.Password
            };

            db.Users.Add(dbUser);

            db.SaveChanges();
            return dbUser.Id;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                db.Users.Remove(user);

            db.SaveChanges();
            return true;
        }
        [HttpPut]
        public int UpdateUser(User user)
        {
            var dbUser = db.Users.FirstOrDefault(u => u.Id == user.Id);

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.Telephone = user.Telephone;
            dbUser.EmpId = user.EmpId;
            dbUser.Password = user.Password;
            
            db.SaveChanges();
            return dbUser.Id;

        }
        
    }
}
