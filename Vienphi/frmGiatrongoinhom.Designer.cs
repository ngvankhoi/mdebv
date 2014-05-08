namespace Vienphi
{
    partial class frmGiatrongoinhom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiatrongoinhom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tennhom = new System.Windows.Forms.ComboBox();
            this.matat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bhyt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Panel();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.dgGia = new System.Windows.Forms.DataGridView();
            this.Column_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvt = new System.Windows.Forms.TextBox();
            this.txtidloai = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtPhanbo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGia)).BeginInit();
            this.SuspendLayout();
            // 
            // tennhom
            // 
            this.tennhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhom.FormattingEnabled = true;
            this.tennhom.Location = new System.Drawing.Point(97, 4);
            this.tennhom.Name = "tennhom";
            this.tennhom.Size = new System.Drawing.Size(370, 21);
            this.tennhom.TabIndex = 6;
            this.tennhom.SelectedIndexChanged += new System.EventHandler(this.tennhom_SelectedIndexChanged);
            this.tennhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhom_KeyDown);
            // 
            // matat
            // 
            this.matat.Location = new System.Drawing.Point(40, 4);
            this.matat.Name = "matat";
            this.matat.Size = new System.Drawing.Size(56, 20);
            this.matat.TabIndex = 5;
            this.matat.Validated += new System.EventHandler(this.matat_Validated);
            this.matat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matat_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Stt:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(505, 4);
            this.stt.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.stt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(43, 20);
            this.stt.TabIndex = 10;
            this.stt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(561, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.Location = new System.Drawing.Point(602, 4);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(119, 20);
            this.ma.TabIndex = 11;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(505, 25);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(216, 82);
            this.ten.TabIndex = 11;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(469, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tên:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(467, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "BHYT:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bhyt
            // 
            this.bhyt.FormattingEnabled = true;
            this.bhyt.Location = new System.Drawing.Point(505, 108);
            this.bhyt.Name = "bhyt";
            this.bhyt.Size = new System.Drawing.Size(52, 21);
            this.bhyt.TabIndex = 13;
            this.bhyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bhyt_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(555, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Giá:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gia
            // 
            this.gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia.Location = new System.Drawing.Point(602, 108);
            this.gia.Name = "gia";
            this.gia.Size = new System.Drawing.Size(119, 20);
            this.gia.TabIndex = 11;
            this.gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(505, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "SỐ TIỀN PHÂN BỔ  THEO NHÓM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p
            // 
            this.p.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p.Location = new System.Drawing.Point(505, 171);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(215, 264);
            this.p.TabIndex = 14;
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(522, 442);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(77, 27);
            this.butKetthuc.TabIndex = 21;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(445, 442);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(77, 27);
            this.butBoqua.TabIndex = 20;
            this.butBoqua.Text = "    &Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(368, 442);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(77, 27);
            this.butXoa.TabIndex = 19;
            this.butXoa.Text = "      &Xoá";
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(291, 442);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(77, 27);
            this.butSua.TabIndex = 18;
            this.butSua.Text = "      &Sửa";
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(214, 442);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(77, 27);
            this.butLuu.TabIndex = 17;
            this.butLuu.Text = "       &Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(137, 442);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(77, 27);
            this.butMoi.TabIndex = 16;
            this.butMoi.Text = "      &Mới";
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // dgGia
            // 
            this.dgGia.AllowDrop = true;
            this.dgGia.AllowUserToAddRows = false;
            this.dgGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgGia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgGia.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_3,
            this.Column_4,
            this.Column_5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGia.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgGia.GridColor = System.Drawing.Color.Silver;
            this.dgGia.Location = new System.Drawing.Point(40, 26);
            this.dgGia.MultiSelect = false;
            this.dgGia.Name = "dgGia";
            this.dgGia.RowHeadersVisible = false;
            this.dgGia.RowHeadersWidth = 20;
            this.dgGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGia.Size = new System.Drawing.Size(427, 405);
            this.dgGia.StandardTab = true;
            this.dgGia.TabIndex = 22;
            this.dgGia.Click += new System.EventHandler(this.dgGia_Click);
            // 
            // Column_3
            // 
            this.Column_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_3.DataPropertyName = "stt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "0";
            this.Column_3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_3.HeaderText = "Stt";
            this.Column_3.Name = "Column_3";
            this.Column_3.Width = 45;
            // 
            // Column_4
            // 
            this.Column_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_4.DataPropertyName = "ma";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column_4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_4.HeaderText = "Mã VP";
            this.Column_4.Name = "Column_4";
            this.Column_4.ReadOnly = true;
            this.Column_4.Width = 64;
            // 
            // Column_5
            // 
            this.Column_5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_5.DataPropertyName = "ten";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column_5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_5.HeaderText = "Tên viện phí";
            this.Column_5.Name = "Column_5";
            this.Column_5.ReadOnly = true;
            this.Column_5.Width = 230;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "gia_th";
            this.Column1.HeaderText = "Giá";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 85;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "id";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 73;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "bhyt";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            this.Column3.Width = 73;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "dvt";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            this.Column4.Width = 73;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "id_loai";
            this.Column5.HeaderText = "id_loai";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 62;
            // 
            // dvt
            // 
            this.dvt.Location = new System.Drawing.Point(472, 43);
            this.dvt.Name = "dvt";
            this.dvt.Size = new System.Drawing.Size(27, 20);
            this.dvt.TabIndex = 11;
            this.dvt.Visible = false;
            // 
            // txtidloai
            // 
            this.txtidloai.Location = new System.Drawing.Point(472, 69);
            this.txtidloai.Name = "txtidloai";
            this.txtidloai.Size = new System.Drawing.Size(27, 20);
            this.txtidloai.TabIndex = 11;
            this.txtidloai.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(40, 445);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Tìm";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPhanbo
            // 
            this.txtPhanbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhanbo.Location = new System.Drawing.Point(601, 148);
            this.txtPhanbo.Name = "txtPhanbo";
            this.txtPhanbo.Size = new System.Drawing.Size(119, 20);
            this.txtPhanbo.TabIndex = 11;
            this.txtPhanbo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(512, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Số tiền phân bổ:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGiatrongoinhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 479);
            this.Controls.Add(this.dgGia);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.p);
            this.Controls.Add(this.bhyt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.txtidloai);
            this.Controls.Add(this.dvt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPhanbo);
            this.Controls.Add(this.gia);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tennhom);
            this.Controls.Add(this.matat);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGiatrongoinhom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo giá trọn gói theo nhóm";
            this.Load += new System.EventHandler(this.frmGiatrongoinhom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tennhom;
        private System.Windows.Forms.TextBox matat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown stt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ma;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox bhyt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox gia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel p;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.DataGridView dgGia;
        private System.Windows.Forms.TextBox dvt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox txtidloai;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtPhanbo;
        private System.Windows.Forms.Label label8;
    }
}