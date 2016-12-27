using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using irrigation_dispatching.Config;
using irrigation_dispatching.Service;
using irrigation_dispatching.Core;
using BCrypt.Net;

namespace irrigation_dispatching.Controller
{
    public class AccountController : Controller
    {
        private AccountService accountService;
        public AccountController(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
            accountService = new AccountService(ref databaseDriver);
        }
        public int AddAccount(Dictionary<string, string> UserInfo)
        {
            // To do: Add validation
            string userName = UserInfo["accountName"];
            string passwd = UserInfo["passwd"];
            string hashedPasswd = BCrypt.Net.BCrypt.HashPassword(passwd);

            bool isAccountExist = accountService.IsAccountExist(userName);
            if (isAccountExist)
            {
                return ControllerReturnCode.ACCOUNTADDACCOUNTDUPLICATE;
            }
            bool result = accountService.AddAccount(userName, hashedPasswd);
            if ( ! result)
            {
                return ControllerReturnCode.ACCOUNTADDACCOUNTERROR;
            }
            return ControllerReturnCode.ACCOUNTADDACCOUNTSUCCESS;
        }
    }
}
