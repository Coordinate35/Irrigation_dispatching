using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;
using irrigation_dispatching.Helper;

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
            databaseDriver.Connect();
            AccountModel accountModel = new AccountModel(ref databaseDriver);
            Dictionary<string, object> account = new Dictionary<string, object>()
            {
                { "account_name", "Coordinate35" },
                { "passwd", "123456" },
                { "register_time", Helper.Helper.time() }
            };
            bool result = accountModel.InsertEntry(account);
            Console.WriteLine(databaseDriver.LastError);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SetTableTest()
        {
        }

        [TestMethod()]
        public void GetAccountByNameTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            AccountModel accountModel = new AccountModel(ref databaseDriver);

            Dictionary<int, Dictionary<string, object>> account = accountModel.GetAccountByName("Coordinate35");
            Console.WriteLine(databaseDriver.LastQuery);
            bool hasContent = account.Count > 0;
            Assert.IsTrue(hasContent);
        }

        public void GetAccountByNameTest1()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            AccountModel accountModel = new AccountModel(ref databaseDriver);

            Dictionary<int, Dictionary<string, object>> account = accountModel.GetAccountByName("ABC");
            bool hasContent = account.Count > 0;
            Assert.IsFalse(hasContent);
        }
    }
}