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
            int privilege = UserInfo.ContainsKey("privilege") ? Convert.ToInt32(UserInfo["privilege"]) : Database.AccountPrivilegeUser;
            string hashedPasswd = BCrypt.Net.BCrypt.HashPassword(passwd);

            bool isAccountExist = accountService.IsAccountExist(userName);
            if (isAccountExist)
            {
                return ControllerReturnCode.ACCOUNTADDACCOUNTDUPLICATE;
            }
            bool result = accountService.AddAccount(userName, hashedPasswd, privilege);
            if ( ! result)
            {
                return ControllerReturnCode.ACCOUNTADDACCOUNTERROR;
            }
            return ControllerReturnCode.ACCOUNTADDACCOUNTSUCCESS;
        }

        public Dictionary<string, object> Login(Dictionary<string, string> UserInfo)
        {
            string userName = UserInfo["accountName"];
            string passwd = UserInfo["passwd"];

            Dictionary<string, object> accountInfo = accountService.GetAccountByName(userName);
            if (null == accountInfo)
            {
                return null;
            }
            string hashedPassword = accountInfo["passwd"].ToString();
            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(passwd, hashedPassword);
            if ( ! isPasswordMatch)
            {
                return null;
            }
            return accountInfo;
        }

        public bool IsAdminExists()
        {
            return accountService.IsAdminExists();
        }
    }
}
