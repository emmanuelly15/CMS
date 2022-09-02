using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;
using Api.Models;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DeviceManagementController : ControllerBase
    {
        private readonly DatabaseContext db; //refer to DatabaseContext.cs 
        public DeviceManagementController(DatabaseContext db)
        {
            this.db = db;
        }

        //get user input and selections
        [HttpGet]
        public IEnumerable<Device> Get()
        {
           
                var docList = new List<Device>();

                var allDevices = db.Devices.ToList().Select(v => new Device
                {
                    Id = v.Id,
                    IMEI = v.IMEI,
                    User = v.User,
                    Groups = v.Groups,
                    Authorisation = v.Authorisation
                });

                return allDevices; //} End of block 1. getting device data
                                   //get all devices information

               
        }
        [HttpGet("{id}")]

        public Device Get(int id)
        {
            var device = db.Devices.FirstOrDefault(u => u.Id == id);
            var deviceview = new Device
            {
                Id = device.Id,
                IMEI = device.IMEI,
                User = device.User,
                Groups = device.Groups,
                Authorisation = device.Authorisation,
            };

            return deviceview;
        }

        //post inputted data to table
        [HttpPost]
        public int Create(Device device)
        {
            var dbDevice = new DbDevice
            {
                
                IMEI = device.IMEI,
                User = device.User,
                Groups = device.Groups,
                Authorisation = device.Authorisation
            };

            db.Devices.Add(dbDevice);

            db.SaveChanges();
            return dbDevice.Id;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var device = db.Devices.FirstOrDefault(u => u.Id == id);
            if (device != null)
                db.Devices.Remove(device);

            db.SaveChanges();
            return true;
        }
    }
      
}
