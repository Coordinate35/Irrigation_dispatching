using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using System.Configuration;

namespace irrigation_dispatching.Test.Core
{
    class DatabaseDriverException : Exception
    {

    }

    class DatabaseDriverTest
    {
        public DatabaseDriverTest()
        {
            DatabaseDriver driver = new DatabaseDriver();
        }
    }
}
