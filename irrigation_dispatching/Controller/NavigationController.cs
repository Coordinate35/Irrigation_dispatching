﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using irrigation_dispatching.View;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Controller
{
    class NavigationController
    {
        private Dictionary<string, Form> views;
        private Dictionary<string, Controller> controllers;
        private DatabaseDriver databaseDriver;
        private string lastError;
        private Dictionary<string, object> userInfo;
        private bool isAdmin;

        public NavigationController(string databaseDriverName = "DatabaseDriver")
        {
            views = new Dictionary<string, Form>();
            controllers = new Dictionary<string, Controller>();
            if ( ! InitDatabaseDriver(databaseDriverName))
            {
                ErrorMessageView errorMessageView = new ErrorMessageView(lastError, ErrorLevel.ErrorLevelSevere);
                errorMessageView.ShowDialog();
            }
            AccountController accountController = (AccountController)GetControllerByName("accountController");
            if ( ! accountController.IsAdminExists())
            {
                SetAdminView setAdminView = (SetAdminView)GetViewByName("setAdminView");
                setAdminView.AdminSet += SetAdminView_AdminSet;
                setAdminView.ShowDialog();
            }
            else
            {
                IndexView indexView = (IndexView)GetViewByName("indexView");
                indexView.Login += IndexView_Login;
                indexView.ShowDialog();
            }
        }

        private void SetAdminView_AdminSet(object sender, EventArgs e)
        {
            if (e is AdminEventArgs)
            {
                AdminEventArgs adminEventArgs = e as AdminEventArgs;
                AccountController accountController = (AccountController)GetControllerByName("accountController");
                Dictionary<string, string> accountInfo = new Dictionary<string, string>()
                {
                    { "accountName", adminEventArgs.AccountName },
                    { "passwd", adminEventArgs.Passwd },
                    { "privilege", adminEventArgs.Privilege }
                };
                int returnCode = accountController.AddAccount(accountInfo);
                if (ControllerReturnCode.ACCOUNTADDACCOUNTSUCCESS != returnCode)
                {
                    int errorLevel;
                    switch (returnCode)
                    {
                        case ControllerReturnCode.ACCOUNTADDACCOUNTDUPLICATE:
                            lastError = ErrorMessage.AcountNameExists;
                            errorLevel = ErrorLevel.ErrorLevelWarning;
                            break;
                        case ControllerReturnCode.ACCOUNTADDACCOUNTERROR:
                            lastError = ErrorMessage.SetAdminFailed;
                            errorLevel = ErrorLevel.ErrorLevelSevere;
                            break;
                        default:
                            lastError = ErrorMessage.SetAdminFailed;
                            errorLevel = ErrorLevel.ErrorLevelSevere;
                            break;
                    }
                    ErrorMessageView errorMessageView = new ErrorMessageView(lastError, errorLevel);
                    errorMessageView.ShowDialog();
                }
                FreeViewByName("setAdminView");
                IndexView indexView = (IndexView)GetViewByName("indexView");
                indexView.Login += IndexView_Login;
                indexView.ShowDialog();
            }
        }

        private void IndexView_Login(object sender, EventArgs e)
        {
            if (e is LoginEventArgs)
            {
                LoginEventArgs loginEventArgs = e as LoginEventArgs;
                Dictionary<string, string> loginAccountInfo = new Dictionary<string, string>()
                {
                    { "accountName", loginEventArgs.AccountName },
                    { "passwd", loginEventArgs.Passwd }
                };
                AccountController accountController = (AccountController)GetControllerByName("accountController");
                Dictionary<string, object> accountInfo = accountController.Login(loginAccountInfo);
                if (null == accountInfo)
                {
                    lastError = ErrorMessage.AccountNamePasswdNotMatch;
                    int errorLevel = ErrorLevel.ErrorLevelWarning;
                    ErrorMessageView errorMessageView = new ErrorMessageView(lastError, errorLevel);
                    errorMessageView.ShowDialog();
                }
                else
                {
                    userInfo = accountInfo;
                    if (Database.AccountPrivilegeAdmin == (int)userInfo[Database.ItemAccountPrivilege])
                    {
                        isAdmin = true;
                    }
                    else
                    {
                        isAdmin = false;
                    }
                    FreeViewByName("indexView");
                    LoadContentView();
                }
            }
        }

        private void LoadContentView()
        {
            ContentView contentView = (ContentView)GetViewByName("contentView");
            for (int i = 0; i < Database.TableList.Count; i++)
            {
                if (isAdmin || (bool)Database.TableList[i]["needNotAdmin"])
                {
                    contentView.AddTable((string)Database.TableList[i]["attribute"]);
                }
            }
            contentView.SelectTable += ContentView_SelectTable;
            contentView.ShowDialog();
        }

        private void ContentView_SelectTable(object sender, EventArgs e)
        {
            if (e is SelectTableEventArgs)
            {
                SelectTableEventArgs selectTableEventArgs = e as SelectTableEventArgs;
                ContentView contentView = (ContentView)GetViewByName("contentView");
                Dictionary<int, Dictionary<string, object>> tableData = null;
                string tableName = null;
                for (int i = 0; i < Database.TableList.Count; i++)
                {
                    if (selectTableEventArgs.TableAttribute == (string)Database.TableList[i]["attribute"])
                    {
                        tableName = (string)Database.TableList[i]["tableName"];
                        break;
                    }
                }
                HydroController hydroController = (HydroController)GetControllerByName("hydroController");
                tableData = hydroController.GetTableDataByTableName(tableName);
                if (null == tableData)
                {
                    Console.WriteLine(databaseDriver.LastError);
                    Console.WriteLine(databaseDriver.LastQuery);
                    lastError = ErrorMessage.GetDataFailed;
                    int errorLevel = ErrorLevel.ErrorLevelWarning;
                    ErrorMessageView errorMessageView = new ErrorMessageView(lastError, errorLevel);
                    errorMessageView.ShowDialog();
                }
                else
                {
                    contentView.RefreshTable(tableName, tableData, isAdmin);
                }
            }
        }

        private void FreeViewByName(string viewName)
        {
            if (views.ContainsKey(viewName))
            {
                views[viewName].Close();
                views[viewName].Dispose();
                views.Remove(viewName);
            }
        }

        private Controller GetControllerByName(string controllerName)
        {
            if (controllers.ContainsKey(controllerName))
            {
                return controllers[controllerName];
            }

            switch (controllerName)
            {
                case "accountController":
                    AccountController accountController = new AccountController(ref databaseDriver);
                    controllers.Add(controllerName, accountController);
                    return controllers[controllerName];
                case "hydroController":
                    HydroController hydroController = new HydroController(ref databaseDriver);
                    controllers.Add(controllerName, hydroController);
                    return controllers[controllerName];
                default:
                    return null;
            }
        }

        private Form GetViewByName(string viewName)
        {
            if (views.ContainsKey(viewName))
            {
                return views[viewName];
            }

            switch (viewName)
            {
                case "indexView":
                    IndexView indexView = new IndexView();
                    views.Add(viewName, indexView);
                    return views[viewName];
                case "setAdminView":
                    SetAdminView setAdminView = new SetAdminView();
                    views.Add(viewName, setAdminView);
                    return views[viewName];
                case "contentView":
                    ContentView contentView = new ContentView();
                    views.Add(viewName, contentView);
                    return views[viewName];
                default:
                    return null;
            }
        }

        private bool InitDatabaseDriver(string databaseDriverName)
        {
            bool isSuccess = true;
            switch (databaseDriverName)
            {
                case "DatabaseDriver":
                    databaseDriver = new DatabaseDriver(
                        Database.DataSource,
                        Database.InitialCatalog,
                        Database.UserId,
                        Database.Pwd,
                        Database.PersistSecurityInfo
                    );
                    break;
                default:
                    lastError = ErrorMessage.NoSuchDatabaseDriver;
                    isSuccess = false;
                    break;
            }
            if ( ! isSuccess)
            {
                return false;
            }
            if ( ! databaseDriver.Connect())
            {
                lastError = ErrorMessage.ConnectDatabaseError;
                isSuccess = false;
            }
            if ( ! databaseDriver.Use(Database.DatabaseName))
            {
                lastError = ErrorMessage.UseDatabaseError;
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
