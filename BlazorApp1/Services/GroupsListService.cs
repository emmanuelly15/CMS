using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace BlazorApp1.Services
{
    public class GroupsListService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public GroupsListService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<GroupsListClass> groupsobj()
        {
            return _dbcontext.Groups.ToList();
        }

        public List<UserListClass> usersobj()
        {
            return _dbcontext.User.ToList();
        }

        public List<DeviceListClass> devobj()
        {
            return _dbcontext.Device.ToList();
        }

        public List<DocumentListClass> docobj()
        {
            return _dbcontext.Imageuploads.ToList();
        }
    }
}
