using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Service.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {
        [TestMethod()]
        public void AccountServiceTest()
        {
        }

        [TestMethod()]
        public void AddAccountTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            AccountService accountService = new AccountService(ref databaseDriver);
            bool result = accountService.AddAccount("Coordinate35", "1234dsfadfas5asdfa");
            Assert.IsTrue(result);
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
            AccountService accountService = new AccountService(ref databaseDriver);
            Dictionary<string, object> account = accountService.GetAccountByName("matrix67");
            Assert.IsNotNull(account);
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
            AccountService accountService = new AccountService(ref databaseDriver);
            Dictionary<string, object> account = accountService.GetAccountByName("matri");
            Assert.IsNull(account);
        }
    }
}