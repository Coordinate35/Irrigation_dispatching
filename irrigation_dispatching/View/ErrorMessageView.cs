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
    public partial class ErrorMessageView : Form
    {
        private int errorLevel;
        public ErrorMessageView(string errorMessage, int errorLevel)
        {
            InitializeComponent();
            this.errorLevel = errorLevel;
            this.errorMessageTextBox.Text = errorMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (errorLevel)
            {
                case ErrorLevel.ErrorLevelSevere:
                    System.Environment.Exit(0);
                    break;
                case ErrorLevel.ErrorLevelWarning:
                    this.Close();
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
