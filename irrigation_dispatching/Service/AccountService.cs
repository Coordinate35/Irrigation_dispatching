using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Model;
using irrigation_dispatching.Helper;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Service
{
    class AccountService : Service
    {
        private AccountModel accountModel;
        public AccountService(ref DatabaseDriver databaseDriver) : base (ref databaseDriver)
        {
            accountModel = new AccountModel(ref databaseDriver);
        }
        public Boolean AddAccount(string userName, string passwd)
        {
            Dictionary<string, object> account = new Dictionary<string, object>()
            {
                { "account_name", userName },
                { "passwd", passwd },
                { "register_time", Helper.Helper.time() }
            };
            bool result = accountModel.InsertEntry(account);
            return result;
        }
    }
}
