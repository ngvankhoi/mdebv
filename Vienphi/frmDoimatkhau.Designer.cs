namespace Vienphi
{
    partial class frmDoimatkhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoimatkhau));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPassword_old = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNhom = new System.Windows.Forms.ComboBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butLuu = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtPassword_old);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbNhom);
            this.panel2.Controls.Add(this.txtHoten);
            this.panel2.Controls.Add(this.txtPassword1);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 153);
            this.panel2.TabIndex = 9;
            // 
            // txtPassword_old
            // 
            this.txtPassword_old.BackColor = System.Drawing.Color.White;
            this.txtPassword_old.ForeColor = System.Drawing.Color.Black;
            this.txtPassword_old.Location = new System.Drawing.Point(127, 39);
            this.txtPassword_old.MaxLength = 20;
            this.txtPassword_old.Name = "txtPassword_old";
            this.txtPassword_old.PasswordChar = '*';
            this.txtPassword_old.Size = new System.Drawing.Size(223, 20);
            this.txtPassword_old.TabIndex = 1;
            this.txtPassword_old.Validated += new System.EventHandler(this.txtPassword_old_Validated);
            this.txtPassword_old.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_old_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mật khẩu củ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbNhom
            // 
            this.cbNhom.BackColor = System.Drawing.Color.White;
            this.cbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhom.ForeColor = System.Drawing.Color.Black;
            this.cbNhom.FormattingEnabled = true;
            this.cbNhom.Location = new System.Drawing.Point(127, 123);
            this.cbNhom.Name = "cbNhom";
            this.cbNhom.Size = new System.Drawing.Size(224, 21);
            this.cbNhom.TabIndex = 5;
            this.cbNhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNhom_KeyDown);
            // 
            // txtHoten
            // 
            this.txtHoten.BackColor = System.Drawing.Color.White;
            this.txtHoten.ForeColor = System.Drawing.Color.Black;
            this.txtHoten.Location = new System.Drawing.Point(127, 102);
            this.txtHoten.MaxLength = 50;
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(223, 20);
            this.txtHoten.TabIndex = 4;
            this.txtHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoten_KeyDown);
            // 
            // txtPassword1
            // 
            this.txtPassword1.BackColor = System.Drawing.Color.White;
            this.txtPassword1.ForeColor = System.Drawing.Color.Black;
            this.txtPassword1.Location = new System.Drawing.Point(127, 81);
            this.txtPassword1.MaxLength = 20;
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(223, 20);
            this.txtPassword1.TabIndex = 3;
            this.txtPassword1.Validated += new System.EventHandler(this.txtPassword1_Validated);
            this.txtPassword1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(127, 60);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(223, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(127, 18);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(223, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Họ và tên:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Xác nhận mật khẩu mới:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên đăng nhập:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-3, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nhóm:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(243, 57);
            this.toolStripLabel1.Text = "ĐỔI MẬT KHẨU TRUY CẬP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butLuu);
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.butBoqua);
            this.panel1.Location = new System.Drawing.Point(1, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 33);
            this.panel1.TabIndex = 13;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(82, 3);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(68, 25);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "      &Đồng ý";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(222, 3);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(68, 25);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "&Kết thúc";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(152, 3);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(68, 25);
            this.butBoqua.TabIndex = 1;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // frmDoimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 202);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoimatkhau";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoimatkhau_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cbNhom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.TextBox txtPassword_old;
        private System.Windows.Forms.Label label1;
    }
}