using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Controller.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void AccountControllerTest()
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
            AccountController accountController = new AccountController(ref databaseDriver);
            Dictionary<string, string> account = new Dictionary<string, string>()
            {
                { "accountName", "matrix67" },
                { "passwd", "123456" }
            };
            int result = accountController.AddAccount(account);
            Console.WriteLine(databaseDriver.LastError);
            Assert.AreEqual(result, ControllerReturnCode.ACCOUNTADDACCOUNTDUPLICATE);
        }

        [TestMethod()]
        public void LoginTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            AccountController accountController = new AccountController(ref databaseDriver);
            Dictionary<string, string> account = new Dictionary<string, string>()
            {
                { "accountName", "matrix67" },
                { "passwd", "123456" }
            };
            Dictionary<string, object> accountInfo = accountController.Login(account);
            Assert.IsNotNull(accountInfo);
        }

        [TestMethod()]
        public void LoginTest1()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            AccountController accountController = new AccountController(ref databaseDriver);
            Dictionary<string, string> account = new Dictionary<string, string>()
            {
                { "accountName", "matrix67" },
                { "passwd", "12345" }
            };
            Dictionary<string, object> accountInfo = accountController.Login(account);
            Assert.IsNull(accountInfo);
        }
    }
}