namespace Vienphi
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.butDongy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groLogin = new System.Windows.Forms.GroupBox();
            this.groLicense = new System.Windows.Forms.GroupBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.RichTextBox();
            this.txtKey = new System.Windows.Forms.RichTextBox();
            this.butTiepTuc = new System.Windows.Forms.Button();
            this.butDangKi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groLogin.SuspendLayout();
            this.groLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDongy
            // 
            this.butDongy.Cursor = System.Windows.Forms.Cursors.Default;
            this.butDongy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDongy.Image = ((System.Drawing.Image)(resources.GetObject("butDongy.Image")));
            this.butDongy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDongy.Location = new System.Drawing.Point(86, 94);
            this.butDongy.Name = "butDongy";
            this.butDongy.Size = new System.Drawing.Size(68, 25);
            this.butDongy.TabIndex = 3;
            this.butDongy.Text = "  Đồn&g ý";
            this.butDongy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDongy.UseVisualStyleBackColor = true;
            this.butDongy.Click += new System.EventHandler(this.butDongy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(155, 94);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "    &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // txtNgay
            // 
            this.txtNgay.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.txtNgay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.txtNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(95, 25);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(184, 20);
            this.txtNgay.TabIndex = 0;
            this.txtNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày làm việc:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(95, 68);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(184, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.Location = new System.Drawing.Point(95, 46);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(184, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật khẩu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 2);
            this.label1.TabIndex = 4;
            // 
            // groLogin
            // 
            this.groLogin.Controls.Add(this.txtPassword);
            this.groLogin.Controls.Add(this.txtUsername);
            this.groLogin.Controls.Add(this.butDongy);
            this.groLogin.Controls.Add(this.txtNgay);
            this.groLogin.Controls.Add(this.label2);
            this.groLogin.Controls.Add(this.label4);
            this.groLogin.Controls.Add(this.butKetthuc);
            this.groLogin.Controls.Add(this.label3);
            this.groLogin.Location = new System.Drawing.Point(0, -6);
            this.groLogin.Name = "groLogin";
            this.groLogin.Size = new System.Drawing.Size(291, 145);
            this.groLogin.TabIndex = 8;
            this.groLogin.TabStop = false;
            // 
            // groLicense
            // 
            this.groLicense.Controls.Add(this.lblLicense);
            this.groLicense.Controls.Add(this.txtLicense);
            this.groLicense.Controls.Add(this.txtKey);
            this.groLicense.Controls.Add(this.butTiepTuc);
            this.groLicense.Controls.Add(this.butDangKi);
            this.groLicense.Controls.Add(this.label5);
            this.groLicense.Controls.Add(this.label6);
            this.groLicense.Location = new System.Drawing.Point(2, 2);
            this.groLicense.Name = "groLicense";
            this.groLicense.Size = new System.Drawing.Size(389, 235);
            this.groLicense.TabIndex = 9;
            this.groLicense.TabStop = false;
            this.groLicense.Text = "License";
            // 
            // lblLicense
            // 
            this.lblLicense.ForeColor = System.Drawing.Color.Red;
            this.lblLicense.Location = new System.Drawing.Point(2, 12);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(381, 44);
            this.lblLicense.TabIndex = 14;
            this.lblLicense.Text = "Bạn chưa có bản quyền sử dụng. Vui lòng copy key bên dưới và gởi cho quản trị hệ " +
                "thống.\r\nBạn còn 30 ngày sử dụng";
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(73, 105);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(299, 91);
            this.txtLicense.TabIndex = 13;
            this.txtLicense.Text = "";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(73, 62);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(299, 39);
            this.txtKey.TabIndex = 12;
            this.txtKey.Text = "";
            // 
            // butTiepTuc
            // 
            this.butTiepTuc.Image = ((System.Drawing.Image)(resources.GetObject("butTiepTuc.Image")));
            this.butTiepTuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiepTuc.Location = new System.Drawing.Point(202, 201);
            this.butTiepTuc.Name = "butTiepTuc";
            this.butTiepTuc.Size = new System.Drawing.Size(75, 23);
            this.butTiepTuc.TabIndex = 11;
            this.butTiepTuc.Text = "   Tiếp tục";
            this.butTiepTuc.UseVisualStyleBackColor = true;
            this.butTiepTuc.Click += new System.EventHandler(this.butTiepTuc_Click);
            // 
            // butDangKi
            // 
            this.butDangKi.Image = ((System.Drawing.Image)(resources.GetObject("butDangKi.Image")));
            this.butDangKi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDangKi.Location = new System.Drawing.Point(121, 201);
            this.butDangKi.Name = "butDangKi";
            this.butDangKi.Size = new System.Drawing.Size(75, 23);
            this.butDangKi.TabIndex = 10;
            this.butDangKi.Text = "    Đăng ký";
            this.butDangKi.UseVisualStyleBackColor = true;
            this.butDangKi.Click += new System.EventHandler(this.butDangKi_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(-17, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "License :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(21, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Key";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 237);
            this.ControlBox = false;
            this.Controls.Add(this.groLogin);
            this.Controls.Add(this.groLicense);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý viện phí";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groLogin.ResumeLayout(false);
            this.groLogin.PerformLayout();
            this.groLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butDongy;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groLogin;
        private System.Windows.Forms.GroupBox groLicense;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.RichTextBox txtLicense;
        private System.Windows.Forms.RichTextBox txtKey;
        private System.Windows.Forms.Button butTiepTuc;
        private System.Windows.Forms.Button butDangKi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}