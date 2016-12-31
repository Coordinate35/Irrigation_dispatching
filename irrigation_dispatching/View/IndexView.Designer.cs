namespace irrigation_dispatching.View
{
    partial class IndexView
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
            this.label1 = new System.Windows.Forms.Label();
            this.accountName = new System.Windows.Forms.TextBox();
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.passwdLabel = new System.Windows.Forms.Label();
            this.passwd = new System.Windows.Forms.TextBox();
            this.loginBotton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(337, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "灌水调度信息管理系统";
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(527, 242);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(210, 28);
            this.accountName.TabIndex = 1;
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountNameLabel.Location = new System.Drawing.Point(429, 242);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(92, 27);
            this.accountNameLabel.TabIndex = 2;
            this.accountNameLabel.Text = "用户名：";
            // 
            // passwdLabel
            // 
            this.passwdLabel.AutoSize = true;
            this.passwdLabel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdLabel.Location = new System.Drawing.Point(449, 304);
            this.passwdLabel.Name = "passwdLabel";
            this.passwdLabel.Size = new System.Drawing.Size(72, 27);
            this.passwdLabel.TabIndex = 3;
            this.passwdLabel.Text = "密码：";
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(527, 307);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(210, 28);
            this.passwd.TabIndex = 4;
            this.passwd.UseSystemPasswordChar = true;
            // 
            // loginBotton
            // 
            this.loginBotton.Location = new System.Drawing.Point(527, 385);
            this.loginBotton.Name = "loginBotton";
            this.loginBotton.Size = new System.Drawing.Size(147, 33);
            this.loginBotton.TabIndex = 5;
            this.loginBotton.Text = "登入";
            this.loginBotton.UseVisualStyleBackColor = true;
            this.loginBotton.Click += new System.EventHandler(this.loginBotton_Click);
            // 
            // IndexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.loginBotton);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.passwdLabel);
            this.Controls.Add(this.accountNameLabel);
            this.Controls.Add(this.accountName);
            this.Controls.Add(this.label1);
            this.Name = "IndexView";
            this.Text = "灌水调度信息管理系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.Label passwdLabel;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Button loginBotton;
    }
}