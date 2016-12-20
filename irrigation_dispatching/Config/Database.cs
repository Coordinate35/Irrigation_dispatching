using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Config
{
    public static class Database
    {
        private static string dataSource = "DESKTOP-23E4P5O";
        private static string initialCatalog = "irrigation_dispatching";
        private static string persistSecurityInfo = "True";
        private static string userId = "irrigation_dispatching";
        private static string pwd = "Irrigationdispatching";

        public static string DataSource
        {
            get
            {
                return dataSource;
            }
        }

        public static string InitialCatalog
        {
            get
            {
                return initialCatalog;
            }
        }

        public static string PersistSecurityInfo
        {
            get
            {
                return persistSecurityInfo;
            }
        }

        public static string UserId
        {
            get
            {
                return userId;
            }
        }

        public static string Pwd
        {
            get
            {
                return pwd;
            }
        }
    }
}
