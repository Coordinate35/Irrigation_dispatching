using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace irrigation_dispatching.Core
{
    public class DatabaseDriver
    {
        private string dataSource;
        private string initialCatalog;
        private string persistSecurityInfo;
        private string userId;
        private string pwd;
        private Boolean isQueryChange;
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

            partialCommand = InitializePartialCommand();
            commandsInCommandGet = InitializeGetCommandList();
        }

        public string ConnectString
        {
            get
            {
                return GenerateConnectString();
            }
        }

        public string LastQuery
        {
            get
            {
                return lastQuery;
            }
        }

        public string LastError
        {
            get
            {
                return error;
            }
        }

        private Dictionary<string, string> InitializePartialCommand()
        {
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commandList = new string[] { "select", "from", "where", "orderBy" };
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
            return commandList;
        }

        private string GenerateConnectString()
        {
            string connectString = String.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info={2};User ID={3};Pwd={4}",
                dataSource,
                initialCatalog,
                persistSecurityInfo,
                userId,
                pwd
            );
            return connectString;
        }

        public bool Connect()
        {
            string connectString = GenerateConnectString();
            try
            {
                connection = new SqlConnection(connectString);
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
            isQueryChange = true;
        }

        public void SetFrom(string tables)
        {
            partialCommand["from"] = "FROM " + tables;
            isQueryChange = true;
        }

        public void SetAndWhere(string condition)
        {
            partialCommand["where"] = "WHERE " + condition;
            isQueryChange = true;
        }

        public void SetAndWhere(string key, string value)
        {
            if (null == partialCommand["where"])
            {
                SetFirstWhere(key, value);
                return;
            }
            partialCommand["where"] = partialCommand["where"] + " " + key + "=" + value;
            isQueryChange = true; 
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
            isQueryChange = true;
        }

        private bool GenerateGetQuery()
        {
            if (false == isQueryChange)
            {
                return true;
            }
            lastQuery = null;
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
                    lastQuery += " " + partialCommand[singleCommand.Key];
                }
            }
            isQueryChange = false;
            return true;
        }

        public Dictionary<int, Dictionary<string, Object>> Get()
        {
            if (false == GenerateGetQuery())
            {
                return null;
            }
            try
            {
                command = new SqlCommand(lastQuery, connection);
                resultReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                error = e.ToString();
                return null;
            }
            Dictionary<int, Dictionary<string, Object>> result = ConverResultToDictionary(resultReader);
            return result;
        }

        private Dictionary<int, Dictionary<string, Object>> ConverResultToDictionary(SqlDataReader resultReader)
        {
            Dictionary<int, Dictionary<string, Object>> result = new Dictionary<int, Dictionary<string, Object>>();
            int i = 0;
            while (resultReader.Read())
            {
                result.Add(i, new Dictionary<string, Object>());
                for (int j = 0; j < resultReader.FieldCount; j++)
                {
                    result[i].Add(resultReader.GetName(j), resultReader[j]);
                }
            }
            return result;
        }

        public bool Insert(string tableName, Dictionary<string, object> entry)
        {
            string colPart = GenerateInsertColPart(entry);
            string valuesPart = GenerateInsertValuesItem(entry);
            lastQuery = GenerateInsertQuery(tableName, colPart, valuesPart);
            return ExecuteNonQuery();
        }

        public bool Insert(string tableName, List<Dictionary<string, object>> entries)
        {
            string valuePart = null;
            string colPart = null;
            if (0 < entries.Count)
            {
                colPart = GenerateInsertColPart(entries[0]);
            }
            foreach (Dictionary<string, object> row in entries)
            {
                if (null == valuePart)
                {
                    valuePart = GenerateInsertValuesItem(row);
                }
                else
                {
                    valuePart += ", " + GenerateInsertValuesItem(row);
                }
            }
            lastQuery = GenerateInsertQuery(tableName, colPart, valuePart);
            return ExecuteNonQuery();
        }

        private bool ExecuteNonQuery()
        {
            int affectedRowNumber;
            try
            {
                command = new SqlCommand(lastQuery, connection);
                affectedRowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            if (0 >= affectedRowNumber)
            {
                return false;
            }
            return true;
        }

        private string GenerateInsertColPart(Dictionary<string, object> entry)
        {
            string colPart = null;
            foreach (string key in entry.Keys)
            {
                if (null == colPart)
                {
                    colPart = "(" + key;
                }
                else
                {
                    colPart += ", " + key;
                }
            }
            if (null != colPart)
            {
                colPart += ")";
            }
            return colPart; 
        }

        private string GenerateInsertQuery(string tableName, string colPart, string valuePart)
        {
            return "INSERT INTO " + tableName + colPart + " VALUES " + valuePart;
        }

        private string GenerateInsertValuesItem(Dictionary<string, object> entry)
        {
            string valuesItem = null;
            foreach (string key in entry.Keys)
            {
                if (null == valuesItem)
                {
                    if (typeof(String) != entry[key].GetType())
                    {
                        valuesItem = "(" + entry[key].ToString();
                    }
                    else
                    {
                        valuesItem = "('" + entry[key].ToString() + "'";
                    }
                }
                else
                {
                    if (typeof(String) != entry[key].GetType())
                    {
                        valuesItem += " ," + entry[key].ToString();
                    }
                    else
                    {
                        valuesItem += " ,'" + entry[key].ToString() + "'";
                    }
                }
            }
            if (null != valuesItem)
            {
                valuesItem += ")";
            }
            return valuesItem;
        }
    }
}
