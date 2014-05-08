namespace UI
{
    partial class ClientUI
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMay = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttenmay = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Chọn thứ tự máy";
            // 
            // cmbMay
            // 
            this.cmbMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMay.FormattingEnabled = true;
            this.cmbMay.Location = new System.Drawing.Point(121, 152);
            this.cmbMay.Name = "cmbMay";
            this.cmbMay.Size = new System.Drawing.Size(115, 21);
            this.cmbMay.TabIndex = 6;
            this.cmbMay.SelectedIndexChanged += new System.EventHandler(this.cmbMay_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Database Name";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(121, 101);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(115, 20);
            this.txtDatabase.TabIndex = 4;
            this.txtDatabase.Text = "medisoft";
            this.txtDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDatabase_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dblink";
            // 
            // txttenmay
            // 
            this.txttenmay.Location = new System.Drawing.Point(121, 128);
            this.txttenmay.Name = "txttenmay";
            this.txttenmay.Size = new System.Drawing.Size(115, 20);
            this.txttenmay.TabIndex = 5;
            this.txttenmay.Text = "may114";
            this.txttenmay.Validated += new System.EventHandler(this.txttenmay_Validated);
            this.txttenmay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTable_KeyDown);
            this.txttenmay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttenmay_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(115, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "links1920";
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(121, 51);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(115, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "medisoft";
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(121, 27);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(115, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5432";
            this.txtPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPort_KeyDown);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(121, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(115, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.1.114";
            this.txtIP.Validated += new System.EventHandler(this.txtIP_Validated);
            this.txtIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIP_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hostname";
            // 
            // ClientUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbMay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttenmay);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ClientUI";
            this.Size = new System.Drawing.Size(240, 178);
            this.Load += new System.EventHandler(this.ClientUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttenmay;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
