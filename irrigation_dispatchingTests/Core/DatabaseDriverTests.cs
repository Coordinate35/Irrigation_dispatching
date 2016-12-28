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
            databaseDriver.SetFrom("account");
            databaseDriver.SetAndWhere("account_id", 1);
            Dictionary<int, Dictionary<string, Object>> result = databaseDriver.Get();
            Console.WriteLine(databaseDriver.LastQuery);
            Dictionary<int, Dictionary<string, Object>> testCase = new Dictionary<int, Dictionary<string, object>>()
            {
                {
                    0,
                    /*
                    new Dictionary<string, object>() {
                        { "account_id", Convert.ChangeType("1", typeof(Object)) },
                        { "account_name", Convert.ChangeType("Coordinate35", typeof(Object)) },
                        { "passwd", Convert.ChangeType("123456", typeof(Object)) },
                        { "register_time", Convert.ChangeType("123456", typeof(Object)) },
                        { "available", Convert.ChangeType("True", typeof(Object)) }
                    }
                    */
                    new Dictionary<string, object>() {
                        { "account_id", (Int16)1 },
                        { "account_name", "Coordinate35" },
                        { "passwd", "1234dsfadfas5asdfa" },
                        { "register_time", 1482891426 },
                        { "privilege", 1 },
                        { "available", true }
                    }
                }
            };
            Assert.AreEqual(result.Count, testCase.Count);
            for (int i = 0; i < testCase.Count; i++)
            {
                Assert.AreEqual(result[i].Count, testCase[i].Count);
                foreach (string key in testCase[i].Keys)
                {
                    Assert.AreEqual(result[i][key], testCase[i][key]);
                }
            }
        }

        [TestMethod()]
        public void InsertTest()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳  
            long now = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;
            Console.WriteLine(now);
            Dictionary<string, object> account = new Dictionary<string, object>()
            {
                { "account_name", "Coordinate35" },
                { "passwd", "123456" },
                { "register_time", now }
            };
            bool result = databaseDriver.Insert("account", account);
            Console.WriteLine(databaseDriver.LastError);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InsertTest1()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver(
                Database.DataSource,
                Database.InitialCatalog,
                Database.UserId,
                Database.Pwd,
                Database.PersistSecurityInfo
            );
            databaseDriver.Connect();
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳  
            long now = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;
            Console.WriteLine(now);
            List<Dictionary<string, object>> account = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>
                {
                    { "account_name", "Coordinate35" },
                    { "passwd", "123456" },
                    { "register_time", now }
                },
                new Dictionary<string, object>
                {
                    { "account_name", "Coordinate" },
                    { "passwd", "123456" },
                    { "register_time", now }
                }
            };
            bool result = databaseDriver.Insert("account", account);
            Console.WriteLine(databaseDriver.LastError);
            Assert.IsTrue(result);
        }
    }
}