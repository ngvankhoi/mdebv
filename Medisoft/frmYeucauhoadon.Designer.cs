namespace Medisoft
{
    partial class frmYeucauhoadon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYeucauhoadon));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMabn = new System.Windows.Forms.TextBox();
            this.txtTenbn = new System.Windows.Forms.TextBox();
            this.txtTencty = new System.Windows.Forms.TextBox();
            this.txtDiachicty = new System.Windows.Forms.TextBox();
            this.txtMsthue = new System.Windows.Forms.TextBox();
            this.txtDiachinhan = new System.Windows.Forms.TextBox();
            this.dateNgayhen = new System.Windows.Forms.DateTimePicker();
            this.txtNguoinhan = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên BN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên cá nhân/ Công ty:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ cá nhân/ Công ty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "MS thuế cá nhân/ Công ty:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ nhận hóa đơn:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Người nhận:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày hẹn gửi hóa đơn:";
            // 
            // txtMabn
            // 
            this.txtMabn.Enabled = false;
            this.txtMabn.Location = new System.Drawing.Point(144, 6);
            this.txtMabn.Name = "txtMabn";
            this.txtMabn.Size = new System.Drawing.Size(113, 20);
            this.txtMabn.TabIndex = 8;
            this.txtMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtTenbn
            // 
            this.txtTenbn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenbn.Enabled = false;
            this.txtTenbn.Location = new System.Drawing.Point(337, 6);
            this.txtTenbn.Name = "txtTenbn";
            this.txtTenbn.Size = new System.Drawing.Size(217, 20);
            this.txtTenbn.TabIndex = 9;
            this.txtTenbn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtTencty
            // 
            this.txtTencty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTencty.Location = new System.Drawing.Point(144, 32);
            this.txtTencty.Name = "txtTencty";
            this.txtTencty.Size = new System.Drawing.Size(410, 20);
            this.txtTencty.TabIndex = 10;
            this.txtTencty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtTencty.Enter += new System.EventHandler(this.txtTencty_Enter);
            // 
            // txtDiachicty
            // 
            this.txtDiachicty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiachicty.Location = new System.Drawing.Point(144, 58);
            this.txtDiachicty.Name = "txtDiachicty";
            this.txtDiachicty.Size = new System.Drawing.Size(410, 20);
            this.txtDiachicty.TabIndex = 11;
            this.txtDiachicty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtDiachicty.Enter += new System.EventHandler(this.txtDiachicty_Enter);
            // 
            // txtMsthue
            // 
            this.txtMsthue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsthue.Location = new System.Drawing.Point(144, 84);
            this.txtMsthue.Name = "txtMsthue";
            this.txtMsthue.Size = new System.Drawing.Size(410, 20);
            this.txtMsthue.TabIndex = 12;
            this.txtMsthue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtMsthue.Enter += new System.EventHandler(this.txtMsthue_Enter);
            // 
            // txtDiachinhan
            // 
            this.txtDiachinhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiachinhan.Location = new System.Drawing.Point(144, 110);
            this.txtDiachinhan.Name = "txtDiachinhan";
            this.txtDiachinhan.Size = new System.Drawing.Size(410, 20);
            this.txtDiachinhan.TabIndex = 13;
            this.txtDiachinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtDiachinhan.Enter += new System.EventHandler(this.txtDiachinhan_Enter);
            // 
            // dateNgayhen
            // 
            this.dateNgayhen.CustomFormat = "dd/MM/yyyy";
            this.dateNgayhen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayhen.Location = new System.Drawing.Point(144, 137);
            this.dateNgayhen.Name = "dateNgayhen";
            this.dateNgayhen.Size = new System.Drawing.Size(113, 20);
            this.dateNgayhen.TabIndex = 14;
            this.dateNgayhen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtNguoinhan
            // 
            this.txtNguoinhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoinhan.Location = new System.Drawing.Point(337, 137);
            this.txtNguoinhan.Name = "txtNguoinhan";
            this.txtNguoinhan.Size = new System.Drawing.Size(217, 20);
            this.txtNguoinhan.TabIndex = 15;
            this.txtNguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtNguoinhan.Enter += new System.EventHandler(this.txtNguoinhan_Enter);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(414, 173);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 21;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(484, 173);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(344, 173);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 20;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(274, 173);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // frmYeucauhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 210);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.txtNguoinhan);
            this.Controls.Add(this.dateNgayhen);
            this.Controls.Add(this.txtDiachinhan);
            this.Controls.Add(this.txtMsthue);
            this.Controls.Add(this.txtDiachicty);
            this.Controls.Add(this.txtTencty);
            this.Controls.Add(this.txtTenbn);
            this.Controls.Add(this.txtMabn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYeucauhoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yêu cầu hóa đơn giá trị gia tăng";
            this.Load += new System.EventHandler(this.frmYeucauhoadon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMabn;
        private System.Windows.Forms.TextBox txtTenbn;
        private System.Windows.Forms.TextBox txtTencty;
        private System.Windows.Forms.TextBox txtDiachicty;
        private System.Windows.Forms.TextBox txtMsthue;
        private System.Windows.Forms.TextBox txtDiachinhan;
        private System.Windows.Forms.DateTimePicker dateNgayhen;
        private System.Windows.Forms.TextBox txtNguoinhan;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
    }
}