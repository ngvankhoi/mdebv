namespace tiemchung
{
    partial class frmBBHuyVaccin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBBHuyVaccin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSoluutru = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.denngay = new System.Windows.Forms.DateTimePicker();
            this.tungay = new System.Windows.Forms.DateTimePicker();
            this.txtMaDDTruong = new System.Windows.Forms.TextBox();
            this.txtMaTruongnhathuoc = new System.Windows.Forms.TextBox();
            this.txtMaDDPTiem = new System.Windows.Forms.TextBox();
            this.txtMaVaccin = new System.Windows.Forms.TextBox();
            this.txtTenVaccin = new System.Windows.Forms.TextBox();
            this.txtLosx = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtDDTruong = new System.Windows.Forms.TextBox();
            this.txtTruongnhathuoc = new System.Windows.Forms.TextBox();
            this.txtDDPTiem = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.listDDT = new LibList.List();
            this.listNTT = new LibList.List();
            this.listDDPT = new LibList.List();
            this.listVaccin = new LibList.List();
            this.txtMabd = new System.Windows.Forms.TextBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lưu trữ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày:";
            // 
            // cmbSoluutru
            // 
            this.cmbSoluutru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoluutru.FormattingEnabled = true;
            this.cmbSoluutru.Location = new System.Drawing.Point(64, 6);
            this.cmbSoluutru.Name = "cmbSoluutru";
            this.cmbSoluutru.Size = new System.Drawing.Size(135, 21);
            this.cmbSoluutru.TabIndex = 0;
            this.cmbSoluutru.SelectedIndexChanged += new System.EventHandler(this.cmbSoluutru_SelectedIndexChanged);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(375, 7);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(137, 20);
            this.txtTim.TabIndex = 2;
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNgay
            // 
            this.txtNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(242, 7);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(127, 20);
            this.txtNgay.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Điều dưỡng trưởng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trưởng bộ phận nhà thuốc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điều dưỡng phòng tiêm thuốc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Vaccin:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số lượng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Số lô:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Sử dụng từ ngày:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Đến ngày:";
            // 
            // denngay
            // 
            this.denngay.CustomFormat = "dd/MM/yyyy";
            this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denngay.Location = new System.Drawing.Point(416, 153);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(96, 20);
            this.denngay.TabIndex = 14;
            this.denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // tungay
            // 
            this.tungay.CustomFormat = "dd/MM/yyyy";
            this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tungay.Location = new System.Drawing.Point(261, 153);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(96, 20);
            this.tungay.TabIndex = 13;
            this.tungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtMaDDTruong
            // 
            this.txtMaDDTruong.Location = new System.Drawing.Point(159, 47);
            this.txtMaDDTruong.Name = "txtMaDDTruong";
            this.txtMaDDTruong.Size = new System.Drawing.Size(63, 20);
            this.txtMaDDTruong.TabIndex = 3;
            this.txtMaDDTruong.Validated += new System.EventHandler(this.txtMaDDTruong_Validated);
            this.txtMaDDTruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtMaTruongnhathuoc
            // 
            this.txtMaTruongnhathuoc.Location = new System.Drawing.Point(159, 69);
            this.txtMaTruongnhathuoc.Name = "txtMaTruongnhathuoc";
            this.txtMaTruongnhathuoc.Size = new System.Drawing.Size(63, 20);
            this.txtMaTruongnhathuoc.TabIndex = 5;
            this.txtMaTruongnhathuoc.Validated += new System.EventHandler(this.txtMaTruongnhathuoc_Validated);
            this.txtMaTruongnhathuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtMaDDPTiem
            // 
            this.txtMaDDPTiem.Location = new System.Drawing.Point(159, 91);
            this.txtMaDDPTiem.Name = "txtMaDDPTiem";
            this.txtMaDDPTiem.Size = new System.Drawing.Size(63, 20);
            this.txtMaDDPTiem.TabIndex = 7;
            this.txtMaDDPTiem.Validated += new System.EventHandler(this.txtMaDDPTiem_Validated);
            this.txtMaDDPTiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtMaVaccin
            // 
            this.txtMaVaccin.Location = new System.Drawing.Point(52, 131);
            this.txtMaVaccin.Name = "txtMaVaccin";
            this.txtMaVaccin.Size = new System.Drawing.Size(63, 20);
            this.txtMaVaccin.TabIndex = 9;
            this.txtMaVaccin.Validated += new System.EventHandler(this.txtMaVaccin_Validated);
            this.txtMaVaccin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtTenVaccin
            // 
            this.txtTenVaccin.Location = new System.Drawing.Point(116, 131);
            this.txtTenVaccin.Name = "txtTenVaccin";
            this.txtTenVaccin.Size = new System.Drawing.Size(245, 20);
            this.txtTenVaccin.TabIndex = 10;
            this.txtTenVaccin.TextChanged += new System.EventHandler(this.txtTenVaccin_TextChanged);
            this.txtTenVaccin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenVaccin_KeyDown);
            // 
            // txtLosx
            // 
            this.txtLosx.Location = new System.Drawing.Point(52, 153);
            this.txtLosx.Name = "txtLosx";
            this.txtLosx.Size = new System.Drawing.Size(110, 20);
            this.txtLosx.TabIndex = 12;
            this.txtLosx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(416, 131);
            this.txtSoluong.MaxLength = 3;
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(96, 20);
            this.txtSoluong.TabIndex = 11;
            this.txtSoluong.Text = "0";
            this.txtSoluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaDDTruong_KeyDown);
            this.txtSoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoluong_KeyPress);
            // 
            // txtDDTruong
            // 
            this.txtDDTruong.Location = new System.Drawing.Point(223, 47);
            this.txtDDTruong.Name = "txtDDTruong";
            this.txtDDTruong.Size = new System.Drawing.Size(289, 20);
            this.txtDDTruong.TabIndex = 4;
            this.txtDDTruong.TextChanged += new System.EventHandler(this.txtDDTruong_TextChanged);
            this.txtDDTruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDDTruong_KeyDown);
            // 
            // txtTruongnhathuoc
            // 
            this.txtTruongnhathuoc.Location = new System.Drawing.Point(223, 69);
            this.txtTruongnhathuoc.Name = "txtTruongnhathuoc";
            this.txtTruongnhathuoc.Size = new System.Drawing.Size(289, 20);
            this.txtTruongnhathuoc.TabIndex = 6;
            this.txtTruongnhathuoc.TextChanged += new System.EventHandler(this.txtTruongnhathuoc_TextChanged);
            this.txtTruongnhathuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTruongnhathuoc_KeyDown);
            // 
            // txtDDPTiem
            // 
            this.txtDDPTiem.Location = new System.Drawing.Point(223, 91);
            this.txtDDPTiem.Name = "txtDDPTiem";
            this.txtDDPTiem.Size = new System.Drawing.Size(289, 20);
            this.txtDDPTiem.TabIndex = 8;
            this.txtDDPTiem.TextChanged += new System.EventHandler(this.txtDDPTiem_TextChanged);
            this.txtDDPTiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDDPTiem_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(372, 198);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 30;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(442, 198);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 31;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(302, 198);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 29;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(232, 198);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 27;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(162, 198);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 15;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(92, 198);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 28;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // listDDT
            // 
            this.listDDT.BackColor = System.Drawing.SystemColors.Info;
            this.listDDT.ColumnCount = 0;
            this.listDDT.Location = new System.Drawing.Point(28, 112);
            this.listDDT.MatchBufferTimeOut = 1000;
            this.listDDT.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDDT.Name = "listDDT";
            this.listDDT.Size = new System.Drawing.Size(75, 17);
            this.listDDT.TabIndex = 69;
            this.listDDT.TextIndex = -1;
            this.listDDT.TextMember = null;
            this.listDDT.ValueIndex = -1;
            this.listDDT.Visible = false;
            // 
            // listNTT
            // 
            this.listNTT.BackColor = System.Drawing.SystemColors.Info;
            this.listNTT.ColumnCount = 0;
            this.listNTT.Location = new System.Drawing.Point(116, 112);
            this.listNTT.MatchBufferTimeOut = 1000;
            this.listNTT.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNTT.Name = "listNTT";
            this.listNTT.Size = new System.Drawing.Size(75, 17);
            this.listNTT.TabIndex = 70;
            this.listNTT.TextIndex = -1;
            this.listNTT.TextMember = null;
            this.listNTT.ValueIndex = -1;
            this.listNTT.Visible = false;
            // 
            // listDDPT
            // 
            this.listDDPT.BackColor = System.Drawing.SystemColors.Info;
            this.listDDPT.ColumnCount = 0;
            this.listDDPT.Location = new System.Drawing.Point(197, 112);
            this.listDDPT.MatchBufferTimeOut = 1000;
            this.listDDPT.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDDPT.Name = "listDDPT";
            this.listDDPT.Size = new System.Drawing.Size(75, 17);
            this.listDDPT.TabIndex = 71;
            this.listDDPT.TextIndex = -1;
            this.listDDPT.TextMember = null;
            this.listDDPT.ValueIndex = -1;
            this.listDDPT.Visible = false;
            // 
            // listVaccin
            // 
            this.listVaccin.BackColor = System.Drawing.SystemColors.Info;
            this.listVaccin.ColumnCount = 0;
            this.listVaccin.Location = new System.Drawing.Point(52, 179);
            this.listVaccin.MatchBufferTimeOut = 1000;
            this.listVaccin.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listVaccin.Name = "listVaccin";
            this.listVaccin.Size = new System.Drawing.Size(75, 17);
            this.listVaccin.TabIndex = 72;
            this.listVaccin.TextIndex = -1;
            this.listVaccin.TextMember = null;
            this.listVaccin.ValueIndex = -1;
            this.listVaccin.Visible = false;
            this.listVaccin.VisibleChanged += new System.EventHandler(this.listVaccin_VisibleChanged);
            // 
            // txtMabd
            // 
            this.txtMabd.Location = new System.Drawing.Point(135, 176);
            this.txtMabd.Name = "txtMabd";
            this.txtMabd.Size = new System.Drawing.Size(64, 20);
            this.txtMabd.TabIndex = 73;
            this.txtMabd.Visible = false;
            this.txtMabd.Validated += new System.EventHandler(this.txtMabd_Validated);
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(6, 203);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(73, 17);
            this.chkXml.TabIndex = 74;
            this.chkXml.Text = "Xuất XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmBBHuyVaccin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 235);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.txtMabd);
            this.Controls.Add(this.listVaccin);
            this.Controls.Add(this.listDDPT);
            this.Controls.Add(this.listNTT);
            this.Controls.Add(this.listDDT);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.txtDDPTiem);
            this.Controls.Add(this.txtTruongnhathuoc);
            this.Controls.Add(this.txtDDTruong);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.txtLosx);
            this.Controls.Add(this.txtTenVaccin);
            this.Controls.Add(this.txtMaVaccin);
            this.Controls.Add(this.txtMaDDPTiem);
            this.Controls.Add(this.txtMaTruongnhathuoc);
            this.Controls.Add(this.txtMaDDTruong);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNgay);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.cmbSoluutru);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 273);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 273);
            this.Name = "frmBBHuyVaccin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản hủy vỏ lọ vaccin";
            this.Load += new System.EventHandler(this.frmBBHuyVaccin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSoluutru;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker denngay;
        private System.Windows.Forms.DateTimePicker tungay;
        private System.Windows.Forms.TextBox txtMaDDTruong;
        private System.Windows.Forms.TextBox txtMaTruongnhathuoc;
        private System.Windows.Forms.TextBox txtMaDDPTiem;
        private System.Windows.Forms.TextBox txtMaVaccin;
        private System.Windows.Forms.TextBox txtTenVaccin;
        private System.Windows.Forms.TextBox txtLosx;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtDDTruong;
        private System.Windows.Forms.TextBox txtTruongnhathuoc;
        private System.Windows.Forms.TextBox txtDDPTiem;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butMoi;
        private LibList.List listDDT;
        private LibList.List listNTT;
        private LibList.List listDDPT;
        private LibList.List listVaccin;
        private System.Windows.Forms.TextBox txtMabd;
        private System.Windows.Forms.CheckBox chkXml;
    }
}