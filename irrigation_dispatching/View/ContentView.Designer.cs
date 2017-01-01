namespace irrigation_dispatching.View
{
    partial class ContentView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableListTreeView = new System.Windows.Forms.TreeView();
            this.计算水文结果 = new System.Windows.Forms.Button();
            this.dataPresentGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPresentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableListTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.计算水文结果);
            this.splitContainer1.Panel2.Controls.Add(this.dataPresentGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 544);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableListTreeView
            // 
            this.tableListTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableListTreeView.Location = new System.Drawing.Point(0, 0);
            this.tableListTreeView.Name = "tableListTreeView";
            this.tableListTreeView.Size = new System.Drawing.Size(348, 544);
            this.tableListTreeView.TabIndex = 0;
            this.tableListTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tableListTreeView_AfterSelect);
            this.tableListTreeView.Click += new System.EventHandler(this.tableListTreeView_Click);
            // 
            // 计算水文结果
            // 
            this.计算水文结果.Location = new System.Drawing.Point(666, 491);
            this.计算水文结果.Name = "计算水文结果";
            this.计算水文结果.Size = new System.Drawing.Size(148, 41);
            this.计算水文结果.TabIndex = 1;
            this.计算水文结果.Text = "进行水文计算";
            this.计算水文结果.UseVisualStyleBackColor = true;
            // 
            // dataPresentGridView
            // 
            this.dataPresentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPresentGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataPresentGridView.Location = new System.Drawing.Point(0, 0);
            this.dataPresentGridView.Name = "dataPresentGridView";
            this.dataPresentGridView.RowTemplate.Height = 30;
            this.dataPresentGridView.Size = new System.Drawing.Size(826, 471);
            this.dataPresentGridView.TabIndex = 0;
            // 
            // ContentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ContentView";
            this.Text = "ContentView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPresentGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button 计算水文结果;
        private System.Windows.Forms.DataGridView dataPresentGridView;
        private System.Windows.Forms.TreeView tableListTreeView;
    }
}