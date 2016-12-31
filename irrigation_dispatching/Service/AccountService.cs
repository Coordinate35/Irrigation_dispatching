using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Model;
using irrigation_dispatching.Helper;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Service
{
    public class AccountService : Service
    {
        private AccountModel accountModel;
        public AccountService(ref DatabaseDriver databaseDriver) : base (ref databaseDriver)
        {
            accountModel = new AccountModel(ref databaseDriver);
        }
        public Boolean AddAccount(string userName, string passwd, int privilege)
        {
            Dictionary<string, object> account = new Dictionary<string, object>()
            {
                { "account_name", userName },
                { "passwd", passwd },
                { "privilege", privilege },
                { "register_time", Helper.Helper.time() }
            };
            bool result = accountModel.InsertEntry(account);
            return result;
        }

        public Boolean IsAccountExist(string accountName)
        {
            Dictionary<int, Dictionary<string, object>> account = accountModel.GetAccountByName(accountName);
            return 0 < account.Count() ? true : false;
        }

        public Dictionary<string, object> GetAccountByName(string accountName)
        {
            Dictionary<int, Dictionary<string, object>> account = accountModel.GetAccountByName(accountName);
            if (0 < account.Count)
            {
                return account[0];
            }
            return null;
        }

        public bool IsAdminExists()
        {
            Dictionary<int, Dictionary<string, object>> account = accountModel.GetAllAmin();
            if (0 >= account.Count)
            {
                return false;
            }
            return true;
        }
    }
}
