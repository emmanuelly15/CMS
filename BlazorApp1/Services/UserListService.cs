using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorApp1.Services
{
    public class UserListService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public UserListService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<UserListClass> userobj()
        {
            return _dbcontext.User.ToList();
        }


    }
}
