using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Controller
{
    public abstract class Controller
    {
        protected DatabaseDriver databaseDriver;
        
        public Controller(ref DatabaseDriver databaseDriver)
        {
            this.databaseDriver = databaseDriver;
        }
    }
}
