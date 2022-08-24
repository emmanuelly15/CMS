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
    public class DeviceManagementController : ControllerBase
    {
    

            [HttpGet]
        public IEnumerable<DeviceManagement> Get()
        {
           using (var context = new PaycoDBContext())
            {

                //get all devices information

                //return context.DeviceManagements.ToList();

                //Add Device information to database

                DeviceManagement deviceManagement = new DeviceManagement();
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

                return context.DeviceManagements.Where(deviceManagement => deviceManagement.UserId == 01010).ToList();
            }
        }
    }
}
