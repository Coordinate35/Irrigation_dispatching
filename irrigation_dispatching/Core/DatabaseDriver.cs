using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace irrigation_dispatching.Core
{
    class DatabaseDriver
    {
        private string dataSource;
        private string initialCatalog;
        private string persistSecurityInfo;
        private string userId;
        private string pwd;
        private string connectString;
        private SqlConnection connection;
        private string lastError;

        public DatabaseDriver(string dataSource, string initialCatalog, string userId, string pwd, string persistSecurityInfo = "True")
        {
            this.dataSource = dataSource;
            this.initialCatalog = initialCatalog;
            this.userId = userId;
            this.pwd = pwd;
            this.persistSecurityInfo = persistSecurityInfo;
            generateConnectString();
        }

        private void generateConnectString()
        {
            connectString = String.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info={2};User ID={3};Pwd={4}",
                dataSource,
                initialCatalog,
                persistSecurityInfo,
                userId,
                pwd
            );
        }

        public bool connect()
        {
            try
            {
                connection = new SqlConnection(this.connectString);
                connection.Open();
            }
            catch (SqlException e)
            {
                lastError = e.ToString();
                return false;
            }
            return true;
        }
    }
}
