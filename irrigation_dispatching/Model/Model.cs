using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model
{
    abstract class Model
    {
        private DatabaseDriver databaseDriver;
        private string tableName;
        public Model(ref DatabaseDriver databaseDriver)
        {
            this.databaseDriver = databaseDriver;
            SetTable();
        }

        protected abstract void SetTable();

        public Boolean InsertEntry(Dictionary<string, string> entry)
        {

        }
    }
}
