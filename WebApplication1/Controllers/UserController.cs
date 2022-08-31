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
        public UserController( DatabaseContext db)
        {
            this.db = db;
        }
        

        [HttpGet]

        public IEnumerable<User> Get()
        {
            var docList = new List<User>();

            var allUsers = db.Users.ToList().Select(v => new User
            {
                Name = v.Name,
                Email = v.Email,
                Telephone = v.Telephone,
                EmpId =v.EmpId
            });

            return allUsers;


        }
        [HttpPost]
        public int Create(User user)
        {
            var dbUser = new DbUser{ Name = user.Name,
            Email = user.Email,
            Telephone = user.Telephone,
            EmpId = user.EmpId,
            Password = user.Password
            };

            db.Users.Add(dbUser);

            db.SaveChanges();
          return dbUser.Id;
        }
        
        

    }
}
