namespace Duoc
{
    partial class frmLapkehoachmua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapkehoachmua));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.cbosophieu = new System.Windows.Forms.ComboBox();
            this.cbophieuduyet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDenngay = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTungay = new System.Windows.Forms.MaskedTextBox();
            this.cbochinhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butxem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBienban = new System.Windows.Forms.CheckBox();
            this.chkKehoach = new System.Windows.Forms.CheckBox();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.butin = new System.Windows.Forms.Button();
            this.butluu = new System.Windows.Forms.Button();
            this.butketthuc = new System.Windows.Forms.Button();
            this.dgvdutru = new System.Windows.Forms.DataGridView();
            this.duyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hamluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenhc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slthucte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giamua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdutru)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txttimkiem);
            this.panel1.Controls.Add(this.cbosophieu);
            this.panel1.Controls.Add(this.cbophieuduyet);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDenngay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTungay);
            this.panel1.Controls.Add(this.cbochinhanh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.butxem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 53);
            this.panel1.TabIndex = 0;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttimkiem.ForeColor = System.Drawing.Color.Red;
            this.txttimkiem.Location = new System.Drawing.Point(291, 28);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(472, 20);
            this.txttimkiem.TabIndex = 8;
            this.txttimkiem.Text = "tìm kiếm";
            this.txttimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            this.txttimkiem.Click += new System.EventHandler(this.txttimkiem_Click);
            // 
            // cbosophieu
            // 
            this.cbosophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosophieu.FormattingEnabled = true;
            this.cbosophieu.Location = new System.Drawing.Point(97, 28);
            this.cbosophieu.Name = "cbosophieu";
            this.cbosophieu.Size = new System.Drawing.Size(107, 21);
            this.cbosophieu.TabIndex = 4;
            this.cbosophieu.SelectedValueChanged += new System.EventHandler(this.cbosophieu_SelectedValueChanged);
            this.cbosophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // cbophieuduyet
            // 
            this.cbophieuduyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbophieuduyet.FormattingEnabled = true;
            this.cbophieuduyet.Location = new System.Drawing.Point(98, 5);
            this.cbophieuduyet.Name = "cbophieuduyet";
            this.cbophieuduyet.Size = new System.Drawing.Size(105, 21);
            this.cbophieuduyet.TabIndex = 0;
            this.cbophieuduyet.SelectedValueChanged += new System.EventHandler(this.cbophieuduyet_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Phiếu đã duyệt :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Chọn phiếu dự trù :";
            // 
            // txtDenngay
            // 
            this.txtDenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenngay.Location = new System.Drawing.Point(700, 5);
            this.txtDenngay.Mask = "00/00/0000";
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(65, 20);
            this.txtDenngay.TabIndex = 3;
            this.txtDenngay.ValidatingType = typeof(System.DateTime);
            this.txtDenngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            this.txtDenngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chọn chi nhánh :";
            // 
            // txtTungay
            // 
            this.txtTungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTungay.Location = new System.Drawing.Point(576, 5);
            this.txtTungay.Mask = "00/00/0000";
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(65, 20);
            this.txtTungay.TabIndex = 2;
            this.txtTungay.ValidatingType = typeof(System.DateTime);
            this.txtTungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // cbochinhanh
            // 
            this.cbochinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbochinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbochinhanh.FormattingEnabled = true;
            this.cbochinhanh.Location = new System.Drawing.Point(291, 5);
            this.cbochinhanh.Name = "cbochinhanh";
            this.cbochinhanh.Size = new System.Drawing.Size(227, 21);
            this.cbochinhanh.TabIndex = 1;
            this.cbochinhanh.SelectedValueChanged += new System.EventHandler(this.cbochinhanh_SelectedValueChanged);
            this.cbochinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(642, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày :";
            // 
            // butxem
            // 
            this.butxem.Image = ((System.Drawing.Image)(resources.GetObject("butxem.Image")));
            this.butxem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butxem.Location = new System.Drawing.Point(210, 26);
            this.butxem.Name = "butxem";
            this.butxem.Size = new System.Drawing.Size(70, 25);
            this.butxem.TabIndex = 5;
            this.butxem.Text = "    &Xem";
            this.butxem.UseVisualStyleBackColor = true;
            this.butxem.Click += new System.EventHandler(this.butxem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkBienban);
            this.panel2.Controls.Add(this.chkKehoach);
            this.panel2.Controls.Add(this.chkxml);
            this.panel2.Controls.Add(this.butin);
            this.panel2.Controls.Add(this.butluu);
            this.panel2.Controls.Add(this.butketthuc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 37);
            this.panel2.TabIndex = 1;
            // 
            // chkBienban
            // 
            this.chkBienban.AutoSize = true;
            this.chkBienban.Location = new System.Drawing.Point(149, 11);
            this.chkBienban.Name = "chkBienban";
            this.chkBienban.Size = new System.Drawing.Size(122, 17);
            this.chkBienban.TabIndex = 15;
            this.chkBienban.Text = "BIên bản điều chỉnh";
            this.chkBienban.UseVisualStyleBackColor = true;
            // 
            // chkKehoach
            // 
            this.chkKehoach.AutoSize = true;
            this.chkKehoach.Checked = true;
            this.chkKehoach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKehoach.Enabled = false;
            this.chkKehoach.Location = new System.Drawing.Point(330, 10);
            this.chkKehoach.Name = "chkKehoach";
            this.chkKehoach.Size = new System.Drawing.Size(118, 17);
            this.chkKehoach.TabIndex = 14;
            this.chkKehoach.Text = "Kế hoạch đặt hàng";
            this.chkKehoach.UseVisualStyleBackColor = true;
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.Location = new System.Drawing.Point(7, 10);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(85, 17);
            this.chkxml.TabIndex = 13;
            this.chkxml.Text = "Xuất ra XML";
            this.chkxml.UseVisualStyleBackColor = true;
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(625, 7);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 1;
            this.butin.Text = "    &In";
            this.butin.UseVisualStyleBackColor = true;
            this.butin.Visible = false;
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // butluu
            // 
            this.butluu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butluu.Image = ((System.Drawing.Image)(resources.GetObject("butluu.Image")));
            this.butluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butluu.Location = new System.Drawing.Point(555, 6);
            this.butluu.Name = "butluu";
            this.butluu.Size = new System.Drawing.Size(70, 25);
            this.butluu.TabIndex = 0;
            this.butluu.Text = "    &Lưu";
            this.butluu.UseVisualStyleBackColor = true;
            this.butluu.Click += new System.EventHandler(this.butluu_Click);
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(695, 6);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 2;
            this.butketthuc.Text = "    &Kết thúc";
            this.butketthuc.UseVisualStyleBackColor = true;
            this.butketthuc.Click += new System.EventHandler(this.butketthuc_Click);
            // 
            // dgvdutru
            // 
            this.dgvdutru.AllowUserToAddRows = false;
            this.dgvdutru.AllowUserToDeleteRows = false;
            this.dgvdutru.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdutru.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdutru.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdutru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdutru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.duyet,
            this.ten,
            this.hamluong,
            this.tenhc,
            this.dang,
            this.soluong,
            this.slthucte,
            this.giamua,
            this.vat,
            this.id});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdutru.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvdutru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdutru.Location = new System.Drawing.Point(0, 53);
            this.dgvdutru.Name = "dgvdutru";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdutru.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvdutru.RowHeadersVisible = false;
            this.dgvdutru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdutru.Size = new System.Drawing.Size(772, 415);
            this.dgvdutru.TabIndex = 2;
            // 
            // duyet
            // 
            this.duyet.FillWeight = 45.68528F;
            this.duyet.HeaderText = "Duyệt";
            this.duyet.Name = "duyet";
            // 
            // ten
            // 
            this.ten.DataPropertyName = "ten";
            this.ten.FillWeight = 160.5331F;
            this.ten.HeaderText = "Tên thuốc, vật tư";
            this.ten.Name = "ten";
            this.ten.ReadOnly = true;
            // 
            // hamluong
            // 
            this.hamluong.FillWeight = 164.4071F;
            this.hamluong.HeaderText = "Hàm lượng";
            this.hamluong.Name = "hamluong";
            // 
            // tenhc
            // 
            this.tenhc.FillWeight = 127.7136F;
            this.tenhc.HeaderText = "Hoạt chất";
            this.tenhc.Name = "tenhc";
            // 
            // dang
            // 
            this.dang.FillWeight = 70.95247F;
            this.dang.HeaderText = "Đơn vị tính";
            this.dang.Name = "dang";
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.FillWeight = 76.87503F;
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            // 
            // slthucte
            // 
            this.slthucte.DataPropertyName = "slthucte";
            this.slthucte.FillWeight = 109.5129F;
            this.slthucte.HeaderText = "SL thực tế";
            this.slthucte.Name = "slthucte";
            this.slthucte.ReadOnly = true;
            // 
            // giamua
            // 
            this.giamua.DataPropertyName = "giamua";
            this.giamua.FillWeight = 94.97313F;
            this.giamua.HeaderText = "Giá mua";
            this.giamua.Name = "giamua";
            // 
            // vat
            // 
            this.vat.DataPropertyName = "vat";
            this.vat.FillWeight = 49.34737F;
            this.vat.HeaderText = "VAT";
            this.vat.Name = "vat";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // frmLapkehoachmua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 505);
            this.Controls.Add(this.dgvdutru);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLapkehoachmua";
            this.Text = "Lập kế hoạch đặt hàng";
            this.Load += new System.EventHandler(this.frmLapkehoachmua_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdutru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtTungay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDenngay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butxem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butluu;
        private System.Windows.Forms.Button butketthuc;
        private System.Windows.Forms.DataGridView dgvdutru;
        private System.Windows.Forms.Button butin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbosophieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbochinhanh;
        private System.Windows.Forms.CheckBox chkxml;
        private System.Windows.Forms.ComboBox cbophieuduyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn duyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn hamluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenhc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dang;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn slthucte;
        private System.Windows.Forms.DataGridViewTextBoxColumn giamua;
        private System.Windows.Forms.DataGridViewTextBoxColumn vat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.CheckBox chkBienban;
        private System.Windows.Forms.CheckBox chkKehoach;

    }
}