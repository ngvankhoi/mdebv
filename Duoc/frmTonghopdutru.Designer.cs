namespace Duoc
{
    partial class frmTonghopdutru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonghopdutru));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbophieuduyet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.butxem = new System.Windows.Forms.Button();
            this.denngay = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tungay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbosophieu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbochinhanh = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.butluu = new System.Windows.Forms.Button();
            this.butketthuc = new System.Windows.Forms.Button();
            this.dgvdutru = new System.Windows.Forms.DataGridView();
            this.duyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hamluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenhc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sldutru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdutru)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbophieuduyet);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txttimkiem);
            this.panel1.Controls.Add(this.butxem);
            this.panel1.Controls.Add(this.denngay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tungay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbosophieu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbochinhanh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 54);
            this.panel1.TabIndex = 0;
            // 
            // cbophieuduyet
            // 
            this.cbophieuduyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbophieuduyet.FormattingEnabled = true;
            this.cbophieuduyet.Location = new System.Drawing.Point(98, 5);
            this.cbophieuduyet.Name = "cbophieuduyet";
            this.cbophieuduyet.Size = new System.Drawing.Size(99, 21);
            this.cbophieuduyet.TabIndex = 0;
            this.cbophieuduyet.SelectedValueChanged += new System.EventHandler(this.cbophieuduyet_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phiếu đã duyệt :";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttimkiem.ForeColor = System.Drawing.Color.Red;
            this.txttimkiem.Location = new System.Drawing.Point(288, 28);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(539, 20);
            this.txttimkiem.TabIndex = 8;
            this.txttimkiem.Text = "tìm kiếm";
            this.txttimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttimkiem.Click += new System.EventHandler(this.txttimkiem_Click);
            // 
            // butxem
            // 
            this.butxem.Image = ((System.Drawing.Image)(resources.GetObject("butxem.Image")));
            this.butxem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butxem.Location = new System.Drawing.Point(201, 28);
            this.butxem.Name = "butxem";
            this.butxem.Size = new System.Drawing.Size(81, 25);
            this.butxem.TabIndex = 5;
            this.butxem.Text = "    &Xem";
            this.butxem.UseVisualStyleBackColor = true;
            this.butxem.Click += new System.EventHandler(this.butxem_Click);
            // 
            // denngay
            // 
            this.denngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.denngay.Location = new System.Drawing.Point(762, 5);
            this.denngay.Mask = "00/00/0000";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(65, 20);
            this.denngay.TabIndex = 3;
            this.denngay.ValidatingType = typeof(System.DateTime);
            this.denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chọn phiếu dự trù :";
            // 
            // tungay
            // 
            this.tungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tungay.Location = new System.Drawing.Point(638, 5);
            this.tungay.Mask = "00/00/0000";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(65, 20);
            this.tungay.TabIndex = 2;
            this.tungay.ValidatingType = typeof(System.DateTime);
            this.tungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(704, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày :";
            // 
            // cbosophieu
            // 
            this.cbosophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosophieu.FormattingEnabled = true;
            this.cbosophieu.Location = new System.Drawing.Point(96, 30);
            this.cbosophieu.Name = "cbosophieu";
            this.cbosophieu.Size = new System.Drawing.Size(99, 21);
            this.cbosophieu.TabIndex = 4;
            this.cbosophieu.SelectedValueChanged += new System.EventHandler(this.cbosophieu_SelectedValueChanged);
            this.cbosophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn chi nhánh :";
            // 
            // cbochinhanh
            // 
            this.cbochinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbochinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbochinhanh.FormattingEnabled = true;
            this.cbochinhanh.Location = new System.Drawing.Point(288, 5);
            this.cbochinhanh.Name = "cbochinhanh";
            this.cbochinhanh.Size = new System.Drawing.Size(296, 21);
            this.cbochinhanh.TabIndex = 1;
            this.cbochinhanh.SelectedValueChanged += new System.EventHandler(this.cbochinhanh_SelectedValueChanged);
            this.cbochinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tungay_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkxml);
            this.panel2.Controls.Add(this.butluu);
            this.panel2.Controls.Add(this.butketthuc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 37);
            this.panel2.TabIndex = 1;
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.Location = new System.Drawing.Point(15, 10);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(85, 17);
            this.chkxml.TabIndex = 12;
            this.chkxml.Text = "Xuất ra XML";
            this.chkxml.UseVisualStyleBackColor = true;
            this.chkxml.Visible = false;
            // 
            // butluu
            // 
            this.butluu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butluu.Image = ((System.Drawing.Image)(resources.GetObject("butluu.Image")));
            this.butluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butluu.Location = new System.Drawing.Point(684, 5);
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
            this.butketthuc.Location = new System.Drawing.Point(754, 5);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 1;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdutru.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdutru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdutru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.duyet,
            this.ten,
            this.hamluong,
            this.tenhc,
            this.dang,
            this.soluong,
            this.sldutru,
            this.mabd});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdutru.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdutru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdutru.Location = new System.Drawing.Point(0, 54);
            this.dgvdutru.Name = "dgvdutru";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdutru.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdutru.RowHeadersVisible = false;
            this.dgvdutru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdutru.Size = new System.Drawing.Size(830, 414);
            this.dgvdutru.TabIndex = 2;
            this.dgvdutru.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdutru_CellClick);
            // 
            // duyet
            // 
            this.duyet.DataPropertyName = "chon";
            this.duyet.FalseValue = "0";
            this.duyet.FillWeight = 40.60914F;
            this.duyet.HeaderText = "Duyệt";
            this.duyet.Name = "duyet";
            this.duyet.TrueValue = "1";
            // 
            // ten
            // 
            this.ten.DataPropertyName = "ten";
            this.ten.FillWeight = 186.5225F;
            this.ten.HeaderText = "Tên thuốc, vật tư";
            this.ten.Name = "ten";
            this.ten.ReadOnly = true;
            // 
            // hamluong
            // 
            this.hamluong.DataPropertyName = "hamluong";
            this.hamluong.HeaderText = "Hàm lượng";
            this.hamluong.Name = "hamluong";
            // 
            // tenhc
            // 
            this.tenhc.DataPropertyName = "tenhc";
            this.tenhc.HeaderText = "Hoạt chất";
            this.tenhc.Name = "tenhc";
            // 
            // dang
            // 
            this.dang.DataPropertyName = "dang";
            this.dang.HeaderText = "Đơn vị tính";
            this.dang.Name = "dang";
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.FillWeight = 87.0574F;
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            // 
            // sldutru
            // 
            this.sldutru.DataPropertyName = "sldutru";
            this.sldutru.FillWeight = 85.81094F;
            this.sldutru.HeaderText = "Số lượng dự trù";
            this.sldutru.Name = "sldutru";
            this.sldutru.ReadOnly = true;
            // 
            // mabd
            // 
            this.mabd.DataPropertyName = "mabd";
            this.mabd.HeaderText = "id";
            this.mabd.Name = "mabd";
            this.mabd.Visible = false;
            // 
            // frmTonghopdutru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 505);
            this.Controls.Add(this.dgvdutru);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTonghopdutru";
            this.Text = "Tổng hợp các phiếu dự trù của các chi nhánh";
            this.Load += new System.EventHandler(this.frmTonghopdutru_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdutru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox tungay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox denngay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbochinhanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbosophieu;
        private System.Windows.Forms.Button butxem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butluu;
        private System.Windows.Forms.Button butketthuc;
        private System.Windows.Forms.DataGridView dgvdutru;
        private System.Windows.Forms.CheckBox chkxml;
        private System.Windows.Forms.ComboBox cbophieuduyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn duyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn hamluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenhc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dang;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn sldutru;
        private System.Windows.Forms.DataGridViewTextBoxColumn mabd;

    }
}