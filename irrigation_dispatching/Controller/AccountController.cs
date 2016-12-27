using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using irrigation_dispatching.Config;
using irrigation_dispatching.Service;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.controller
{
    public class Account
    {
        public Boolean AddAccount(Dictionary<string, string> UserInfo)
        {
            // To do: Add validation
            string userName = UserInfo["userName"];
            string passwd = UserInfo["passwd"];

            Rfc2898DeriveBytes PBKDF2Encrypter = new Rfc2898DeriveBytes(
                passwd, 
                Security.PasswdSaltLenght,
                Security.PasswdEncryptIterationCount
            );

            //AccountService accountService = new AccountService(ref);

            //if (false == accountService.AddAccount(userName, passwd))
            //{
            //    return false;
            //}
            return true;
        }
    }
}
