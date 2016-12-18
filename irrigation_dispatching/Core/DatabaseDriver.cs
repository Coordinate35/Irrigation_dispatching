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
        private Dictionary<string, string> partialCommand;
        private string[] commandList;
        private Dictionary<string, bool> commandsInCommandGet;
        private string error;
        private string lastQuery;
        private SqlCommand command;
        private SqlDataReader resultReader;

        public DatabaseDriver(string dataSource, string initialCatalog, string userId, string pwd, string persistSecurityInfo = "True")
        {
            this.dataSource = dataSource;
            this.initialCatalog = initialCatalog;
            this.userId = userId;
            this.pwd = pwd;
            this.persistSecurityInfo = persistSecurityInfo;
            GenerateConnectString();

            partialCommand = InitializePartialCommand();
            commandsInCommandGet = InitializeGetCommandList();
        }

        private Dictionary<string, string> InitializePartialCommand()
        {
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commandList = new string[] { "select", "from", "where", "orderBy", "limit" };
            foreach (string commandName in commandList)
            {
                commands.Add(commandName, null);
            }

            return commands;
        }

        private Dictionary<string, bool> InitializeGetCommandList()
        {
            Dictionary<string, bool> commandList = new Dictionary<string, bool>();
            commandList.Add("select", true);
            commandList.Add("from", true);
            commandList.Add("where", false);
            commandList.Add("orderBy", false);
            commandList.Add("limit", false);
            return commandList;
        }

        private void GenerateConnectString()
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

        public bool Connect()
        {
            try
            {
                connection = new SqlConnection(this.connectString);
                connection.Open();
            }
            catch (SqlException e)
            {
                error = e.ToString();
                return false;
            }
            return true;
        }

        public void SetSelect(string columns)
        {
            partialCommand["select"] = "SELECT " + columns;
        }

        public void SetFrom(string tables)
        {
            partialCommand["from"] = "FROM " + tables;
        }

        public void SetAndWhere(string condition)
        {
            partialCommand["where"] = "WHERE " + condition;
        }

        public void SetAndWhere(string key, string value)
        {
            if (null == partialCommand["where"])
            {
                SetFirstWhere(key, value);
            }
            partialCommand["where"] = partialCommand["where"] + " " + key + "=" + value; 
        }

        public void SetAndWhere(string key, int value)
        {
            string stringValue = value.ToString();
            SetAndWhere(key, stringValue);
        }

        private void SetFirstWhere(string key, string value)
        {
            partialCommand["where"] = "WHERE " + key + "=" + value;
        }

        public void SetOrderBy(string colume, string direction = "ASC")
        {
            partialCommand["orderBy"] = "ORDER BY " + colume + " " + direction;
        }

        public void SetLimit(int limitNumber, int offset)
        {
            partialCommand["limit"] = "LIMIT " + limitNumber.ToString() + ", " + offset.ToString();
        }

        private bool GenerateGetQuery()
        {
            foreach (KeyValuePair<string, bool> singleCommand in commandsInCommandGet)
            {
                if ((true == singleCommand.Value) && (null == partialCommand[singleCommand.Key]))
                {
                    return false;
                }
                if (null == lastQuery)
                {
                    lastQuery = partialCommand[singleCommand.Key];
                }
                else
                {
                    lastQuery += partialCommand[singleCommand.Key];
                }
            }
            return true;
        }

        public bool Get()
        {
            if (false == GenerateGetQuery())
            {
                return false;
            }
            try
            {
                command = new SqlCommand(lastQuery, connection);
                resultReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            return true;
        }
    }
}
