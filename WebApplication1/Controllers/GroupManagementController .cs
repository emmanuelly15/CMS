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
    public class GroupManagementController : ControllerBase
    {
    

            [HttpGet]
        public IEnumerable<GroupManagement> Get()
        {
           using (var context = new PaycoDBContext())
            {

                //get all devices information

                //return context.GroupManagements.ToList();

                //Add Device information to database

                GroupManagement groupmanagement = new GroupManagement();
                groupmanagement.GroupName = "Logistics";
                groupmanagement.GroupId = 1;
                

                context.GroupManagements.Add(groupmanagement);

                //Update device management information
                GroupManagement groupManagement = context.GroupManagements.Where(groupmanagement => groupmanagement.GroupName == "Logistics").FirstOrDefault();
                groupmanagement.GroupName = "Transport";

                //Remove device
                GroupManagement groupManagement1 = context.GroupManagements.Where(groupmanagement => groupmanagement.GroupName == "Logistics").FirstOrDefault();
                context.GroupManagements.Remove(groupmanagement);


                context.SaveChanges();

                return context.GroupManagements.Where(groupmanagement => groupmanagement.GroupName == "Logistics").ToList();
            }
        }
    }
}
