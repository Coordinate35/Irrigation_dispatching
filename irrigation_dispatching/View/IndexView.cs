using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace irrigation_dispatching.View
{
    public partial class IndexView : Form
    {
        public event EventHandler Login;

        public IndexView()
        {
            InitializeComponent();
        }

        private void loginBotton_Click(object sender, EventArgs e)
        {
            LoginEventArgs loginEventArgs = new LoginEventArgs(accountName.Text, passwd.Text);
            Login?.Invoke(this, loginEventArgs);
        }
    }

    public class LoginEventArgs : EventArgs
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

        public LoginEventArgs(string accountName, string passwd)
        {
            AccountName = accountName;
            Passwd = passwd;
        }
    }
}
