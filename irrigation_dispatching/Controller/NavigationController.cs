using System;
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
        private DatabaseDriver databaseDriver;
        private string lastError;

        public NavigationController(string databaseDriverName = "DatabaseDriver")
        {
            views = new Dictionary<string, Form>();
            LaunchIndex();
            if ( ! InitDatabaseDriver(databaseDriverName))
            {
                ErrorMessageView errorMessageView = new ErrorMessageView(lastError, ErrorLevel.ErrorLevelSevere);
                errorMessageView.Show();
            }
        }

        private void LaunchIndex()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IndexView indexView = new IndexView();
            views.Add("indexView", indexView);
            Application.Run(indexView);
        }

        private Form getViewByName(string viewName)
        {
            if (views.ContainsKey(viewName))
            {
                return views[viewName];
            }

            switch (viewName)
            {
                case "indexView":
                    return new IndexView();
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
                lastError = databaseDriver.LastError;
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
