using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model.Tests
{
    [TestClass()]
    public class AccountModelTests
    {
        [TestMethod()]
        public void AccountModelTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
           );
           AccountModel accountModel = new 
        }

        [TestMethod()]
        public void SetTableTest()
        {
        }
    }
}