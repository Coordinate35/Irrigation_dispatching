using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model
{
    public class AccountModel : Model
    {
        public AccountModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
        }
        public override void SetTable()
        {
            tableName = Database.TableAccount;
        }

        public Dictionary<int, Dictionary<string, object>> GetAccountByName(string accountName)
        {
            string selectedContent = Database.ItemAccountAccountId.ToString() +
                ", " + Database.ItemAccountAccountName.ToString() +
                ", " + Database.ItemAccountPasswd.ToString() +
                ", " + Database.ItemAccountRegisterTime.ToString();
            databaseDriver.SetSelect(selectedContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemAccountAccountName, accountName);
            databaseDriver.SetAndWhere(Database.ItemAccountAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> account = databaseDriver.Get();
            return account;
        }
    }
}
