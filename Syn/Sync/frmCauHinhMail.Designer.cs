namespace Server
{
    partial class frmCauHinhMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinhMail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.LogList = new System.Windows.Forms.ListBox();
            this.butTest = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbMail = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.butKetthuc3 = new System.Windows.Forms.Button();
            this.butLuucauhinh = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.butThumau = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtChude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.LogList);
            this.panel1.Controls.Add(this.butTest);
            this.panel1.Controls.Add(this.txtTo);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.txtFrom);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtSmtp);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 307);
            this.panel1.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 148);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(60, 13);
            this.label29.TabIndex = 25;
            this.label29.Text = "Log Report";
            // 
            // LogList
            // 
            this.LogList.Location = new System.Drawing.Point(15, 164);
            this.LogList.Name = "LogList";
            this.LogList.ScrollAlwaysVisible = true;
            this.LogList.Size = new System.Drawing.Size(273, 134);
            this.LogList.TabIndex = 24;
            // 
            // butTest
            // 
            this.butTest.Location = new System.Drawing.Point(195, 132);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(93, 23);
            this.butTest.TabIndex = 23;
            this.butTest.Text = "Gửi mail thử";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(94, 95);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(194, 20);
            this.txtTo.TabIndex = 22;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(63, 98);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(27, 13);
            this.label28.TabIndex = 21;
            this.label28.Text = "Đến";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(94, 72);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(194, 20);
            this.txtPass.TabIndex = 20;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(94, 26);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(194, 20);
            this.txtPort.TabIndex = 19;
            this.txtPort.Text = "587";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(94, 49);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(194, 20);
            this.txtFrom.TabIndex = 18;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 13);
            this.label24.TabIndex = 13;
            this.label24.Text = "Máy chủ SMTP";
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(94, 3);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(194, 20);
            this.txtSmtp.TabIndex = 17;
            this.txtSmtp.Text = "SMTP.Gmail.com";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(58, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "Cổng";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(38, 75);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 16;
            this.label27.Text = "Mật khẩu";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(70, 52);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 13);
            this.label26.TabIndex = 15;
            this.label26.Text = "Từ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtLogo);
            this.panel2.Controls.Add(this.cmbMail);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.butKetthuc3);
            this.panel2.Controls.Add(this.butLuucauhinh);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.txtNoidung);
            this.panel2.Controls.Add(this.butThumau);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.txtChude);
            this.panel2.Location = new System.Drawing.Point(303, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 307);
            this.panel2.TabIndex = 1;
            // 
            // cmbMail
            // 
            this.cmbMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMail.FormattingEnabled = true;
            this.cmbMail.Location = new System.Drawing.Point(53, 5);
            this.cmbMail.Name = "cmbMail";
            this.cmbMail.Size = new System.Drawing.Size(321, 21);
            this.cmbMail.TabIndex = 30;
            this.cmbMail.SelectedIndexChanged += new System.EventHandler(this.cmbMail_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(23, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 13);
            this.label32.TabIndex = 29;
            this.label32.Text = "Tên";
            // 
            // butKetthuc3
            // 
            this.butKetthuc3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc3.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc3.Image")));
            this.butKetthuc3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc3.Location = new System.Drawing.Point(254, 271);
            this.butKetthuc3.Name = "butKetthuc3";
            this.butKetthuc3.Size = new System.Drawing.Size(87, 25);
            this.butKetthuc3.TabIndex = 28;
            this.butKetthuc3.Text = "Kết thúc";
            this.butKetthuc3.UseVisualStyleBackColor = true;
            this.butKetthuc3.Click += new System.EventHandler(this.butKetthuc3_Click);
            // 
            // butLuucauhinh
            // 
            this.butLuucauhinh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuucauhinh.Image = ((System.Drawing.Image)(resources.GetObject("butLuucauhinh.Image")));
            this.butLuucauhinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuucauhinh.Location = new System.Drawing.Point(177, 271);
            this.butLuucauhinh.Name = "butLuucauhinh";
            this.butLuucauhinh.Size = new System.Drawing.Size(75, 25);
            this.butLuucauhinh.TabIndex = 27;
            this.butLuucauhinh.Text = "Lưu";
            this.butLuucauhinh.UseVisualStyleBackColor = true;
            this.butLuucauhinh.Click += new System.EventHandler(this.butLuucauhinh_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(0, 76);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 13);
            this.label31.TabIndex = 26;
            this.label31.Text = "Nội dung";
            // 
            // txtNoidung
            // 
            this.txtNoidung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoidung.Location = new System.Drawing.Point(53, 72);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(398, 195);
            this.txtNoidung.TabIndex = 25;
            // 
            // butThumau
            // 
            this.butThumau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butThumau.Location = new System.Drawing.Point(376, 4);
            this.butThumau.Name = "butThumau";
            this.butThumau.Size = new System.Drawing.Size(75, 23);
            this.butThumau.TabIndex = 24;
            this.butThumau.Text = "Thư mẫu";
            this.butThumau.UseVisualStyleBackColor = true;
            this.butThumau.Click += new System.EventHandler(this.butThumau_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(5, 52);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(44, 13);
            this.label30.TabIndex = 22;
            this.label30.Text = "Tiêu đề";
            // 
            // txtChude
            // 
            this.txtChude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChude.Location = new System.Drawing.Point(53, 49);
            this.txtChude.Name = "txtChude";
            this.txtChude.Size = new System.Drawing.Size(398, 20);
            this.txtChude.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Lô gô";
            // 
            // txtLogo
            // 
            this.txtLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogo.Location = new System.Drawing.Point(53, 28);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(398, 20);
            this.txtLogo.TabIndex = 32;
            this.txtLogo.Text = "<img src=\\\"http://trungtamphuocan.vn/themes/hepacenter/images/logo.jpg\\\"/>";
            // 
            // frmCauHinhMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 312);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCauHinhMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình email";
            this.Load += new System.EventHandler(this.frmCauHinhMail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtSmtp;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbMail;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button butKetthuc3;
        private System.Windows.Forms.Button butLuucauhinh;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Button butThumau;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtChude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogo;
    }
}