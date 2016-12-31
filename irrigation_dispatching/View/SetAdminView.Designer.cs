namespace irrigation_dispatching.View
{
    partial class SetAdminView
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
            this.accountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(317, 120);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(180, 28);
            this.accountName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理员用户名：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(317, 169);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(180, 28);
            this.passwd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "管理员密码：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SetAdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountName);
            this.Name = "SetAdminView";
            this.Text = "SetAdminView";
            this.Load += new System.EventHandler(this.SetAdminView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}