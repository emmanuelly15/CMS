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
    public class MailingListController : ControllerBase
    {
    

            [HttpGet]
        public IEnumerable<MailingList> Get()
        {
           using (var context = new PaycoDBContext())
            {

                //get all devices information

                //return context.MailingLists.ToList();

                //Add Device information to database

                MailingList mailingList = new MailingList();
                mailingList.MailId = 101010;
                mailingList.UserId = 01010;
                mailingList.GroupId = 01010;
                
                context.MailingLists.Add(mailingList);

                //Update device management information
                MailingList mailinglist = context.MailingLists.Where(mailingList => mailingList.MailId == 01010).FirstOrDefault();
                //mailinglist.MailId = 11111;

                //Remove device
                MailingList mailinglist1 = context.MailingLists.Where(mailingList => mailingList.MailId == 01010).FirstOrDefault();
                //context.MailingLists.Remove(mailingList);


                context.SaveChanges();

                return context.MailingLists.Where(mailingList => mailingList.MailId == 01010).ToList();
            }
        }
    }
}
