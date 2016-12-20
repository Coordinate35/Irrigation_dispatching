using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Core.Tests
{
    [TestClass()]
    public class DatabaseDriverTests
    {
        [TestMethod()]
        public void DatabaseDriverTest()
        {

            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            Assert.AreEqual(databaseDriver.ConnectString, "Data Source=DESKTOP-23E4P5O;Initial Catalog=irrigation_dispatching;Persist Security Info=True;User ID=irrigation_dispatching;Pwd=Irrigationdispatching");
        }

        [TestMethod()]
        public void ConnectTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            Assert.IsTrue(databaseDriver.Connect());
        }

        [TestMethod()]
        public void SetSelectTest()
        {
        }

        [TestMethod()]
        public void SetFromTest()
        {
        }

        [TestMethod()]
        public void SetAndWhereTest()
        {
        }

        [TestMethod()]
        public void SetAndWhereTest1()
        {
        }

        [TestMethod()]
        public void SetAndWhereTest2()
        {
        }

        [TestMethod()]
        public void SetOrderByTest()
        {
        }

        [TestMethod()]
        public void SetLimitTest()
        {
        }

        [TestMethod()]
        public void GetTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            databaseDriver.SetSelect("*");
            databaseDriver.SetFrom("Account");
            Assert.IsTrue(databaseDriver.Get());
            Console.WriteLine(databaseDriver.LastQuery);
        }
    }
}