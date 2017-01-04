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
            DataGridView dataPresentGridView = new DataGridView();
            this.splitContainer1.Panel2.Controls.RemoveByKey("dataPresentGridView");
            this.splitContainer1.Panel2.Controls.Add(dataPresentGridView);
            dataPresentGridView.Name = "dataPresentGridView";
            dataPresentGridView.Dock = DockStyle.Top;
            dataPresentGridView.ColumnCount = tableData[0].Keys.Count;
            dataPresentGridView.Size = new Size(826, 471);
            dataPresentGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            foreach (string key in tableData[0].Keys)
            {
                int columnIndex = dataPresentGridView.Columns.Add(key, key);
            }
            
            for (int i = 0; i < tableData.Count; i++)
            {
                int rowIndex = 0;
                rowIndex = dataPresentGridView.Rows.Add();
                int count = 0;
                foreach (KeyValuePair<string, object> value in tableData[i])
                {
                    dataPresentGridView.Rows[rowIndex].Cells[count].Value = value.Value;
                    count += 1;
                    //Console.WriteLine(dataPresentGridView.Columns[0].Displayed);
                }
            }
            dataPresentGridView.Dock = DockStyle.Fill;
        }

        private void tableListTreeView_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void tableListTreeView_Click(object sender, EventArgs e)
        {
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
