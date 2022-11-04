using System.Collections.Generic;
using System.Linq;

namespace Api.Authentication
{
    public class AdminAccountService
    {
        private List<AdminAccount> _adminAccountList;

        public AdminAccountService()
        {
            _adminAccountList = new List<AdminAccount>
            {
                new AdminAccount{UserName = "gngengineering@gmail.com", AdminPassword = "Gilbert1!", Role = "HigherAdmin"},
                new AdminAccount{UserName = "karabokobola@gmail.com", AdminPassword = "Karabo1!", Role = "LowerAdmin"}
            };
        }

        public AdminAccount? GetAdminAccountByUserName(string userName)
        {
            return _adminAccountList.FirstOrDefault(x => x.UserName == userName);

        }
    }
}
