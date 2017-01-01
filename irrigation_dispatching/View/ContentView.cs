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
    public partial class ContentView : Form
    {
        public event EventHandler SelectTable;

        public ContentView()
        {
            InitializeComponent();
        }

        public void AddTable(string attribute)
        {
            TreeNode tableitem = new TreeNode();
            tableitem.Text = attribute;
            tableListTreeView.Nodes.Add(tableitem);
        }

        public void RefreshTable(Dictionary<int, Dictionary<string, object>> tableData)
        {
            this.dataPresentGridView = new DataGridView();
            foreach (string key in tableData[0].Keys)
            {
                dataPresentGridView.Columns.Add(key, key);
            }
            
            for (int i = 0; i < tableData.Count; i++)
            {
                int count = 0;
                dataPresentGridView.Rows.Add(tableData.Count);
                foreach (KeyValuePair<string, object> value in tableData[i])
                {
                    dataPresentGridView.Rows[i].Cells[count].Value = value.Value;
                    count += 1;
                }
            }
            dataPresentGridView.Dock = DockStyle.Fill;
        }

        private void tableListTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        { 

        }

        private void tableListTreeView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tableListTreeView.Nodes.Count; i++)
            {
                if (tableListTreeView.Nodes[i].IsSelected)
                {
                    SelectTableEventArgs selectTableEventArgs = new SelectTableEventArgs(this.tableListTreeView.Nodes[i].Text);
                    SelectTable?.Invoke(this, selectTableEventArgs);
                }
            }
        }
    }

    public class SelectTableEventArgs : EventArgs
    {
        public string TableAttribute
        {
            get;
            private set;
        }

        public SelectTableEventArgs(string tableAttribute)
        {
            TableAttribute = tableAttribute;
        }
    }
}
