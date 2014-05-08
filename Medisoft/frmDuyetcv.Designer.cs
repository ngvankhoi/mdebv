namespace Medisoft
{
    partial class frmDuyetcv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetcv));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mabn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noichuyenden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daduyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chuaduyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cungtuyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ngoaituyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butluu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tungay = new System.Windows.Forms.MaskedTextBox();
            this.denngay = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbogioitinh = new System.Windows.Forms.ComboBox();
            this.txtlydocv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbotenkp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttim = new System.Windows.Forms.Button();
            this.butketthuc = new System.Windows.Forms.Button();
            this.butin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkchuaduyet = new System.Windows.Forms.CheckBox();
            this.chkdaduyet = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkngoaituyen = new System.Windows.Forms.CheckBox();
            this.chkcungtuyen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.mabn,
            this.hoten,
            this.ngaysinh,
            this.gioitinh,
            this.lydo,
            this.noichuyenden,
            this.daduyet,
            this.chuaduyet,
            this.cungtuyen,
            this.ngoaituyen,
            this.maql});
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(919, 433);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.FillWeight = 49.46908F;
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.In.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // mabn
            // 
            this.mabn.DataPropertyName = "mabn";
            this.mabn.FillWeight = 100.5196F;
            this.mabn.HeaderText = "Mã BN";
            this.mabn.Name = "mabn";
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.FillWeight = 240.7119F;
            this.hoten.HeaderText = "Họ Tên";
            this.hoten.Name = "hoten";
            // 
            // ngaysinh
            // 
            this.ngaysinh.DataPropertyName = "ngaysinh";
            this.ngaysinh.FillWeight = 110.2659F;
            this.ngaysinh.HeaderText = "Ngày sinh";
            this.ngaysinh.Name = "ngaysinh";
            // 
            // gioitinh
            // 
            this.gioitinh.DataPropertyName = "gioitinh";
            this.gioitinh.FillWeight = 110.2659F;
            this.gioitinh.HeaderText = "Giới tính";
            this.gioitinh.Name = "gioitinh";
            // 
            // lydo
            // 
            this.lydo.DataPropertyName = "lydo";
            this.lydo.FillWeight = 110.2659F;
            this.lydo.HeaderText = "Lý do";
            this.lydo.Name = "lydo";
            // 
            // noichuyenden
            // 
            this.noichuyenden.DataPropertyName = "noichuyenden";
            this.noichuyenden.FillWeight = 110.2659F;
            this.noichuyenden.HeaderText = "Nơi chuyển đến";
            this.noichuyenden.Name = "noichuyenden";
            // 
            // daduyet
            // 
            this.daduyet.DataPropertyName = "daduyet";
            this.daduyet.FillWeight = 72.33987F;
            this.daduyet.HeaderText = "Đã duyệt";
            this.daduyet.Name = "daduyet";
            // 
            // chuaduyet
            // 
            this.chuaduyet.DataPropertyName = "chuaduyet";
            this.chuaduyet.FillWeight = 70.43693F;
            this.chuaduyet.HeaderText = "Chưa duyệt";
            this.chuaduyet.Name = "chuaduyet";
            // 
            // cungtuyen
            // 
            this.cungtuyen.DataPropertyName = "cungtuyen";
            this.cungtuyen.FillWeight = 64.03792F;
            this.cungtuyen.HeaderText = "Cùng tuyến";
            this.cungtuyen.Name = "cungtuyen";
            // 
            // ngoaituyen
            // 
            this.ngoaituyen.DataPropertyName = "ngoaituyen";
            this.ngoaituyen.FillWeight = 61.42132F;
            this.ngoaituyen.HeaderText = "Ngoài tuyến";
            this.ngoaituyen.Name = "ngoaituyen";
            // 
            // maql
            // 
            this.maql.DataPropertyName = "maql";
            this.maql.HeaderText = "maql";
            this.maql.Name = "maql";
            this.maql.Visible = false;
            // 
            // butluu
            // 
            this.butluu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butluu.Image = ((System.Drawing.Image)(resources.GetObject("butluu.Image")));
            this.butluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butluu.Location = new System.Drawing.Point(709, 547);
            this.butluu.Name = "butluu";
            this.butluu.Size = new System.Drawing.Size(70, 25);
            this.butluu.TabIndex = 2;
            this.butluu.Text = "    &Lưu";
            this.butluu.UseVisualStyleBackColor = true;
            this.butluu.Click += new System.EventHandler(this.butluu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ ngày :";
            // 
            // tungay
            // 
            this.tungay.Location = new System.Drawing.Point(69, 9);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(66, 20);
            this.tungay.TabIndex = 4;
            // 
            // denngay
            // 
            this.denngay.Location = new System.Drawing.Point(198, 9);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(66, 20);
            this.denngay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đến ngày :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã BN :";
            // 
            // txtmabn
            // 
            this.txtmabn.Location = new System.Drawing.Point(313, 9);
            this.txtmabn.MaxLength = 10;
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(72, 20);
            this.txtmabn.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(431, 9);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(500, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Họ tên :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Giới tính :";
            // 
            // cbogioitinh
            // 
            this.cbogioitinh.FormattingEnabled = true;
            this.cbogioitinh.Items.AddRange(new object[] {
            "Nữ",
            "Nam"});
            this.cbogioitinh.Location = new System.Drawing.Point(69, 31);
            this.cbogioitinh.Name = "cbogioitinh";
            this.cbogioitinh.Size = new System.Drawing.Size(66, 21);
            this.cbogioitinh.TabIndex = 12;
            // 
            // txtlydocv
            // 
            this.txtlydocv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlydocv.Location = new System.Drawing.Point(97, 500);
            this.txtlydocv.MaxLength = 3000;
            this.txtlydocv.Multiline = true;
            this.txtlydocv.Name = "txtlydocv";
            this.txtlydocv.Size = new System.Drawing.Size(834, 40);
            this.txtlydocv.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Lý do chuyển viện :";
            // 
            // cbotenkp
            // 
            this.cbotenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbotenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotenkp.FormattingEnabled = true;
            this.cbotenkp.Location = new System.Drawing.Point(198, 31);
            this.cbotenkp.Name = "cbotenkp";
            this.cbotenkp.Size = new System.Drawing.Size(314, 21);
            this.cbotenkp.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tên khoa :";
            // 
            // buttim
            // 
            this.buttim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttim.Image = ((System.Drawing.Image)(resources.GetObject("buttim.Image")));
            this.buttim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttim.Location = new System.Drawing.Point(861, 30);
            this.buttim.Name = "buttim";
            this.buttim.Size = new System.Drawing.Size(70, 25);
            this.buttim.TabIndex = 17;
            this.buttim.Text = "    &Tìm";
            this.buttim.UseVisualStyleBackColor = true;
            this.buttim.Click += new System.EventHandler(this.buttim_Click);
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(861, 547);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 18;
            this.butketthuc.Text = "    &Kết thúc";
            this.butketthuc.UseVisualStyleBackColor = true;
            this.butketthuc.Click += new System.EventHandler(this.butketthuc_Click);
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(785, 547);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 19;
            this.butin.Text = "    &In";
            this.butin.UseVisualStyleBackColor = true;
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkchuaduyet);
            this.panel1.Controls.Add(this.chkdaduyet);
            this.panel1.Location = new System.Drawing.Point(517, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 22);
            this.panel1.TabIndex = 20;
            // 
            // chkchuaduyet
            // 
            this.chkchuaduyet.AutoSize = true;
            this.chkchuaduyet.Location = new System.Drawing.Point(72, 4);
            this.chkchuaduyet.Name = "chkchuaduyet";
            this.chkchuaduyet.Size = new System.Drawing.Size(80, 17);
            this.chkchuaduyet.TabIndex = 1;
            this.chkchuaduyet.Text = "Chưa duyệt";
            this.chkchuaduyet.UseVisualStyleBackColor = true;
            this.chkchuaduyet.CheckedChanged += new System.EventHandler(this.chkchuaduyet_CheckedChanged);
            // 
            // chkdaduyet
            // 
            this.chkdaduyet.AutoSize = true;
            this.chkdaduyet.Location = new System.Drawing.Point(3, 4);
            this.chkdaduyet.Name = "chkdaduyet";
            this.chkdaduyet.Size = new System.Drawing.Size(69, 17);
            this.chkdaduyet.TabIndex = 0;
            this.chkdaduyet.Text = "Đã duyệt";
            this.chkdaduyet.UseVisualStyleBackColor = true;
            this.chkdaduyet.CheckedChanged += new System.EventHandler(this.chkdaduyet_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkngoaituyen);
            this.panel2.Controls.Add(this.chkcungtuyen);
            this.panel2.Location = new System.Drawing.Point(679, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 22);
            this.panel2.TabIndex = 21;
            // 
            // chkngoaituyen
            // 
            this.chkngoaituyen.AutoSize = true;
            this.chkngoaituyen.Location = new System.Drawing.Point(90, 3);
            this.chkngoaituyen.Name = "chkngoaituyen";
            this.chkngoaituyen.Size = new System.Drawing.Size(83, 17);
            this.chkngoaituyen.TabIndex = 3;
            this.chkngoaituyen.Text = "Ngoài tuyến";
            this.chkngoaituyen.UseVisualStyleBackColor = true;
            this.chkngoaituyen.CheckedChanged += new System.EventHandler(this.chkngoaituyen_CheckedChanged);
            // 
            // chkcungtuyen
            // 
            this.chkcungtuyen.AutoSize = true;
            this.chkcungtuyen.Location = new System.Drawing.Point(5, 3);
            this.chkcungtuyen.Name = "chkcungtuyen";
            this.chkcungtuyen.Size = new System.Drawing.Size(80, 17);
            this.chkcungtuyen.TabIndex = 2;
            this.chkcungtuyen.Text = "Cùng tuyến";
            this.chkcungtuyen.UseVisualStyleBackColor = true;
            this.chkcungtuyen.CheckedChanged += new System.EventHandler(this.chkcungtuyen_CheckedChanged);
            // 
            // frmDuyetcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 579);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.buttim);
            this.Controls.Add(this.cbotenkp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtlydocv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbogioitinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butluu);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuyetcv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt chuyển viện";
            this.Load += new System.EventHandler(this.frmDuyetcv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butluu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tungay;
        private System.Windows.Forms.MaskedTextBox denngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmabn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbogioitinh;
        private System.Windows.Forms.TextBox txtlydocv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbotenkp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttim;
        private System.Windows.Forms.Button butketthuc;
        private System.Windows.Forms.Button butin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewTextBoxColumn mabn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lydo;
        private System.Windows.Forms.DataGridViewTextBoxColumn noichuyenden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn daduyet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chuaduyet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cungtuyen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ngoaituyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn maql;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkchuaduyet;
        private System.Windows.Forms.CheckBox chkdaduyet;
        private System.Windows.Forms.CheckBox chkngoaituyen;
        private System.Windows.Forms.CheckBox chkcungtuyen;
    }
}