namespace Server
{
    partial class frmKhaibaomaychu
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
            DAL.Client client1 = new DAL.Client();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhaibaomaychu));
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnKetthuc = new System.Windows.Forms.Button();
            this.clientUI1 = new UI.ClientUI();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(104, 202);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnKetthuc
            // 
            this.btnKetthuc.Location = new System.Drawing.Point(185, 202);
            this.btnKetthuc.Name = "btnKetthuc";
            this.btnKetthuc.Size = new System.Drawing.Size(75, 23);
            this.btnKetthuc.TabIndex = 2;
            this.btnKetthuc.Text = "Kết thúc";
            this.btnKetthuc.UseVisualStyleBackColor = true;
            this.btnKetthuc.Click += new System.EventHandler(this.btnKetthuc_Click);
            // 
            // clientUI1
            // 
            client1.DatabaseName = "medisoft_phuocan";
            client1.DbLink = "may114";
            client1.Host = "192.168.1.114";
            client1.ID = ((long)(-1));
            client1.Passworddb = "links1920";
            client1.Port = "5432";
            client1.ServerName = "may114";
            client1.Thoigian = 5;
            client1.Userdb = "medisoft";
            this.clientUI1.Client = client1;
            this.clientUI1.Location = new System.Drawing.Point(47, 3);
            this.clientUI1.Name = "clientUI1";
            this.clientUI1.Size = new System.Drawing.Size(240, 178);
            this.clientUI1.TabIndex = 0;
            // 
            // frmKhaibaomaychu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 237);
            this.Controls.Add(this.btnKetthuc);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.clientUI1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKhaibaomaychu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai bao may chu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKhaibaomaychu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ClientUI clientUI1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKetthuc;
    }
}