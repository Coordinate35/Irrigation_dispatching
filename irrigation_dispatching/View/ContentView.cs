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
    public partial class ContentView : Form
    {
        public event EventHandler SelectTable;

        private Dictionary<int, Dictionary<string, object>> tableData;
        private string tableName;

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

        public void RefreshTable(string tableName, Dictionary<int, Dictionary<string, object>> tableData, bool isAdmin)
        {
            this.tableName = tableName;
            this.tableData = tableData;
            int count = 0;
            DataGridView dataPresentGridView = new DataGridView();
            this.splitContainer1.Panel2.Controls.RemoveByKey("dataPresentGridView");
            this.splitContainer1.Panel2.Controls.Add(dataPresentGridView);
            dataPresentGridView.Name = "dataPresentGridView";
            dataPresentGridView.Dock = DockStyle.Top;
            dataPresentGridView.ColumnCount = tableData[0].Keys.Count;
            dataPresentGridView.Size = new Size(
                ViewConst.ContentViewDataPresentGridViewWidth,
                ViewConst.ContentViewDataPresentGridViewHeight
            );
            dataPresentGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataPresentGridView.ReadOnly = true;
            foreach (string key in tableData[0].Keys)
            {
                dataPresentGridView.Columns[count].Name = key;
                count += 1;
            }
            
            if (isAdmin)
            {
                DataGridViewButtonColumn updateBottonColumn = new DataGridViewButtonColumn();
                updateBottonColumn.HeaderText = ViewConst.ContentViewDataPresentGridViewUpdateBotton;
                updateBottonColumn.Text = ViewConst.ContentViewDataPresentGridViewUpdateBotton;
                updateBottonColumn.UseColumnTextForButtonValue = true;
                dataPresentGridView.Columns.Add(updateBottonColumn);

            }
            for (int i = 0; i < tableData.Count; i++)
            {
                int rowIndex = 0;
                rowIndex = dataPresentGridView.Rows.Add();
                count = 0;
                foreach (KeyValuePair<string, object> value in tableData[i])
                {
                    dataPresentGridView.Rows[rowIndex].Cells[count].Value = value.Value;
                    count += 1;
                }
                if (isAdmin)
                {
                    DataGridViewButtonCell editButton = new DataGridViewButtonCell();
                    editButton.Tag = i;
                    editButton.Value = ViewConst.ContentViewDataPresentGridViewUpdateBotton;
                    dataPresentGridView.Rows[rowIndex].Cells[count].Value = editButton;
                }
            }
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

    public class ItemValueChangeEventArgs : EventArgs
    {
        public Dictionary<string, object> Row
        {
            get;
            private set;
        }

        public string ItemName
        {
            get;
            private set;
        }

        public object ItemValue
        {
            get;
            private set;
        }

        public string TableName
        {
            get;
            private set;
        }

        public ItemValueChangeEventArgs(string tableName, Dictionary<string, object> row, string itemName, object itemValue)
        {
            TableName = tableName;
            Row = row;
            ItemName = itemName;
            ItemValue = itemValue;
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
