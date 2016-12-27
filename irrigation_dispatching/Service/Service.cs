using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Service
{
    public abstract class Service
    {
        protected DatabaseDriver databaseDriver;

        public Service(ref DatabaseDriver databaseDriver)
        {
            this.databaseDriver = databaseDriver;
        }
    }
}
