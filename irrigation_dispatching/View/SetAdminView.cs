using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.View
{
    public partial class SetAdminView : Form
    {
        public event EventHandler AdminSet;

        public SetAdminView()
        {
            InitializeComponent();
        }

        private void SetAdminView_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string privilege = Convert.ToString(Database.AccountPrivilegeAdmin);
            AdminEventArgs adminEventArgs = new AdminEventArgs(this.accountName.Text, this.passwd.Text, privilege);
            AdminSet?.Invoke(this, adminEventArgs);
        }
    }

    public class AdminEventArgs : EventArgs
    {
        public string AccountName
        {
            get;
            private set;
        }

        public string Passwd
        {
            get;
            private set;
        }

        public string Privilege
        {
            get;
            private set;
        }

        public AdminEventArgs(string accountName, string passwd, string privilege)
        {
            AccountName = accountName;
            Passwd = passwd;
            Privilege = privilege;
        }
    }
}
