using Api.Model.Database;
using Api.Models;
using CommonModels.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommonModels.Model;
using System.Linq;

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

        [HttpGet]
        //get user input and selections
        public IEnumerable<DeviceManagement> Get()
        {
            using (var context = new PaycoDBContext())
            {
                var docList = new List<DeviceManagement>();

                var allDevices = db.registered_device.ToList().Select(v => new DeviceManagement
                {
                    IMEI = v.IMEI,
                    User = v.User,
                    Group = v.Group,
                    Authorisation = v.Authorisation
                });

                return allDevices; //} End of block 1. getting device data
                                   //get all devices information

                //return context.DeviceManagements.ToList();

                //Add Device information to database

                /* DeviceManagement deviceManagement = new DeviceManagement();
                 deviceManagement.DeviceImei = "SVF2TGVEHJD990";
                 deviceManagement.UserId = 01010;
                 deviceManagement.GroupId = 01010;
                 deviceManagement.RegisteredDate = null;
                 deviceManagement.LastUpdate = null;
                 deviceManagement.LastLocation = "EASTRAND";
                 deviceManagement.Authorised = null;

                 context.DeviceManagements.Add(deviceManagement);

                 //Update device management information
                 DeviceManagement devicemanagement = context.DeviceManagements.Where(deviceManagement => deviceManagement.UserId == 01010).FirstOrDefault();
                 deviceManagement.UserId = 10000;

                 //Remove device
                 DeviceManagement devicemanagement1 = context.DeviceManagements.Where(deviceManagement => deviceManagement.UserId == 01010).FirstOrDefault();
                 context.DeviceManagements.Remove(devicemanagement1);


                 context.SaveChanges();

                 return context.DeviceManagements.Where(deviceManagement => deviceManagement.UserId == 01010).ToList();*/
            }
        }

        //post inputted data to table
        [HttpPost]
        public int Create(DeviceManagement device)
        {
            var dbDevice = new DbDevice
            {
                IMEI = device.IMEI,
                User = device.User,
                Group = device.Group,
                Authorisation = device.Authorisation
            };

            db.Devices.Add(dbDevice);

            db.SaveChanges();
            return dbDevice.Id;
        }
    }
      
}
