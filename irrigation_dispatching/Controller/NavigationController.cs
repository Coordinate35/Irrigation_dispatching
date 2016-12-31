using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using irrigation_dispatching.View;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;
using irrigation_dispatching.Controller;

namespace irrigation_dispatching.Controller
{
    class NavigationController
    {
        private Dictionary<string, Form> views;
        private Dictionary<string, Controller> controllers;
        private DatabaseDriver databaseDriver;
        private string lastError;

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
                indexView.ShowDialog();
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
                    AccountController accountService = new AccountController(ref databaseDriver);
                    controllers.Add(controllerName, accountService);
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
            if (! databaseDriver.Connect())
            {
                lastError = ErrorMessage.ConnectDatabaseError;
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
