using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model
{
    public abstract class Model
    {
        protected DatabaseDriver databaseDriver;
        protected string tableName;
        public Model(ref DatabaseDriver databaseDriver)
        {
            this.databaseDriver = databaseDriver;
            SetTable();
        }

        public abstract void SetTable();

        public Boolean InsertEntry(Dictionary<string, object> entry)
        {
            return databaseDriver.Insert(tableName, entry);
        }

        public Boolean InsertMultiEntry(List<Dictionary<string, object>> entries)
        {
            return databaseDriver.Insert(tableName, entries);
        }
    }
}
