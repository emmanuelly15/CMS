using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Authentication
{
    public class AdminAccountService
    {
        private List<AdminAccount> _admins;

        public AdminAccountService()
        {
            _admins = new List<AdminAccount>
            {
                new AdminAccount{Name = "Gilbert", Email = "gilbert@gngengineering.com", Password = "Gilbert1!", Authorize = "1" },
                new AdminAccount{Name= "Shannon", Email = "Shannon@gngengineering.com", Password = "Shannon1!", Authorize = "0"}
            };
        }

        public AdminAccount GetByEmail(string email)
        {
            return _admins.FirstOrDefault(x => x.Email == email);
        }
    }






/*
    public class AdminAccountService
    {
        DbAdminUser adminuser = new DbAdminUser();
        
    }

    public DbAdminUser? GetByEmail(string Email)
    {
        return DbAdminUser.FirstOrDefault(x => x.Email == Email);
    }
*/
}
