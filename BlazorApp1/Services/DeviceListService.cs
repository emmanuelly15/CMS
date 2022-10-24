using BlazorApp1.Data;
using BlazorApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Services
{
    public class DeviceListService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public DeviceListService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<DeviceListClass> devobj()
        {
            return _dbcontext.Device.ToList();
        }

    }
}
