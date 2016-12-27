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
    }
}
