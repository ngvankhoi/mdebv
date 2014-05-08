namespace Duoc
{
    partial class frmChuyenDuocbenhvien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenDuocbenhvien));
            this.chkNhomBV = new System.Windows.Forms.CheckedListBox();
            this.txtTungay = new System.Windows.Forms.DateTimePicker();
            this.txtDenngay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butChuyen = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTao = new System.Windows.Forms.Button();
            this.cboSolieu = new System.Windows.Forms.ComboBox();
            this.cboNhomkho = new System.Windows.Forms.ComboBox();
            this.lstNhomMedisoft = new System.Windows.Forms.ListBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkNhomBV
            // 
            this.chkNhomBV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNhomBV.BackColor = System.Drawing.Color.White;
            this.chkNhomBV.CheckOnClick = true;
            this.chkNhomBV.FormattingEnabled = true;
            this.chkNhomBV.Location = new System.Drawing.Point(230, 33);
            this.chkNhomBV.Name = "chkNhomBV";
            this.chkNhomBV.Size = new System.Drawing.Size(217, 394);
            this.chkNhomBV.TabIndex = 1;
            // 
            // txtTungay
            // 
            this.txtTungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTungay.CustomFormat = "dd/MM/yyyy";
            this.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTungay.Location = new System.Drawing.Point(51, 451);
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(89, 20);
            this.txtTungay.TabIndex = 2;
            // 
            // txtDenngay
            // 
            this.txtDenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDenngay.CustomFormat = "dd/MM/yyyy";
            this.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenngay.Location = new System.Drawing.Point(162, 451);
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(88, 20);
            this.txtDenngay.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "đến";
            // 
            // butChuyen
            // 
            this.butChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butChuyen.Image = ((System.Drawing.Image)(resources.GetObject("butChuyen.Image")));
            this.butChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyen.Location = new System.Drawing.Point(6, 474);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(70, 25);
            this.butChuyen.TabIndex = 6;
            this.butChuyen.Text = "&Chuyển";
            this.butChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChuyen.UseVisualStyleBackColor = true;
            this.butChuyen.Click += new System.EventHandler(this.butChuyen_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(216, 474);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.button2_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(76, 474);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTao
            // 
            this.butTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTao.Enabled = false;
            this.butTao.Image = ((System.Drawing.Image)(resources.GetObject("butTao.Image")));
            this.butTao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTao.Location = new System.Drawing.Point(146, 474);
            this.butTao.Name = "butTao";
            this.butTao.Size = new System.Drawing.Size(70, 25);
            this.butTao.TabIndex = 10;
            this.butTao.Text = "&Tạo";
            this.butTao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTao.UseVisualStyleBackColor = true;
            this.butTao.Click += new System.EventHandler(this.butTao_Click);
            // 
            // cboSolieu
            // 
            this.cboSolieu.BackColor = System.Drawing.Color.White;
            this.cboSolieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSolieu.FormattingEnabled = true;
            this.cboSolieu.Items.AddRange(new object[] {
            "Dược bệnh viện                  - Biểu 07",
            "Cận lâm sàng                      - Biểu 06",
            "Trang thiết bị                       - Biểu 08",
            "Hoạt động tài chính             - Biểu 10.1",
            "Chi tiết thu viện phí - BHYT- Biểu 10.2.1",
            "Chi tiết các khoản chi          - Biểu 10.2.2",
            "Các khoản không thu được - Biểu 10.3"});
            this.cboSolieu.Location = new System.Drawing.Point(6, 6);
            this.cboSolieu.Name = "cboSolieu";
            this.cboSolieu.Size = new System.Drawing.Size(218, 21);
            this.cboSolieu.TabIndex = 11;
            this.cboSolieu.Tag = "bieu_07";
            this.cboSolieu.SelectedIndexChanged += new System.EventHandler(this.cboSolieu_SelectedIndexChanged);
            // 
            // cboNhomkho
            // 
            this.cboNhomkho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhomkho.BackColor = System.Drawing.Color.White;
            this.cboNhomkho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomkho.Enabled = false;
            this.cboNhomkho.FormattingEnabled = true;
            this.cboNhomkho.Items.AddRange(new object[] {
            "Dược bệnh viện",
            "Cận lâm sàng",
            "Trang thiết bị"});
            this.cboNhomkho.Location = new System.Drawing.Point(230, 6);
            this.cboNhomkho.Name = "cboNhomkho";
            this.cboNhomkho.Size = new System.Drawing.Size(218, 21);
            this.cboNhomkho.TabIndex = 12;
            this.cboNhomkho.SelectedIndexChanged += new System.EventHandler(this.cboNhomkho_SelectedIndexChanged);
            // 
            // lstNhomMedisoft
            // 
            this.lstNhomMedisoft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNhomMedisoft.FormattingEnabled = true;
            this.lstNhomMedisoft.Location = new System.Drawing.Point(7, 33);
            this.lstNhomMedisoft.Name = "lstNhomMedisoft";
            this.lstNhomMedisoft.Size = new System.Drawing.Size(217, 407);
            this.lstNhomMedisoft.TabIndex = 13;
            this.lstNhomMedisoft.SelectedIndexChanged += new System.EventHandler(this.lstNhomMedisoft_SelectedIndexChanged);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(230, 427);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(81, 17);
            this.chkAll.TabIndex = 14;
            this.chkAll.Text = "Chọn tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmChuyenDuocbenhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 501);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lstNhomMedisoft);
            this.Controls.Add(this.cboNhomkho);
            this.Controls.Add(this.cboSolieu);
            this.Controls.Add(this.butTao);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butChuyen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDenngay);
            this.Controls.Add(this.txtTungay);
            this.Controls.Add(this.chkNhomBV);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChuyenDuocbenhvien";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển số liệu sang Medisoft 2003";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChuyenDuocbenhvien_KeyDown);
            this.Load += new System.EventHandler(this.frmChuyenDuocbenhvien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkNhomBV;
        private System.Windows.Forms.DateTimePicker txtTungay;
        private System.Windows.Forms.DateTimePicker txtDenngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butChuyen;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butTao;
        private System.Windows.Forms.ComboBox cboSolieu;
        private System.Windows.Forms.ComboBox cboNhomkho;
        private System.Windows.Forms.ListBox lstNhomMedisoft;
        private System.Windows.Forms.CheckBox chkAll;
    }
}