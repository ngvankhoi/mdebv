namespace Vienphi
{
    partial class frmChitiethd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChitiethd));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Loi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_May = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmn_Timnhanh = new System.Windows.Forms.ToolStripTextBox();
            this.tmn_Tong = new System.Windows.Forms.ToolStripLabel();
            this.butClose = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNgay = new System.Windows.Forms.Label();
            this.lbKyhieu = new System.Windows.Forms.Label();
            this.lbSobienlai = new System.Windows.Forms.Label();
            this.lbNhanvien = new System.Windows.Forms.Label();
            this.lbMabn = new System.Windows.Forms.Label();
            this.lbDiachi = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 61);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.panel2.Size = new System.Drawing.Size(674, 340);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column_ngay,
            this.Column_Loi,
            this.Column_table,
            this.Column_May,
            this.Column1,
            this.Column4,
            this.Column2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(2, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(666, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "ma";
            this.Column5.HeaderText = "Mã VP";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 64;
            // 
            // Column_ngay
            // 
            this.Column_ngay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ngay.DataPropertyName = "ten";
            this.Column_ngay.HeaderText = "Nội dung";
            this.Column_ngay.Name = "Column_ngay";
            this.Column_ngay.ReadOnly = true;
            // 
            // Column_Loi
            // 
            this.Column_Loi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Loi.DataPropertyName = "dvt";
            this.Column_Loi.HeaderText = "Đvt";
            this.Column_Loi.Name = "Column_Loi";
            this.Column_Loi.ReadOnly = true;
            this.Column_Loi.Width = 49;
            // 
            // Column_table
            // 
            this.Column_table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_table.DataPropertyName = "soluong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "### ### ###.##";
            dataGridViewCellStyle3.NullValue = "0";
            this.Column_table.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_table.HeaderText = "Số lượng";
            this.Column_table.Name = "Column_table";
            this.Column_table.ReadOnly = true;
            this.Column_table.Width = 74;
            // 
            // Column_May
            // 
            this.Column_May.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_May.DataPropertyName = "dongia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "### ### ###.##";
            dataGridViewCellStyle4.NullValue = "0";
            this.Column_May.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_May.HeaderText = "Đơn giá";
            this.Column_May.Name = "Column_May";
            this.Column_May.ReadOnly = true;
            this.Column_May.Width = 69;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "sotien";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "### ### ###.##";
            dataGridViewCellStyle5.NullValue = "0";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Thành tiền";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 83;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 250;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "mien";
            this.Column2.HeaderText = "mien";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butRefresh,
            this.toolStripSeparator2,
            this.tmn_Timnhanh,
            this.tmn_Tong});
            this.toolStrip1.Location = new System.Drawing.Point(2, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(666, 25);
            this.toolStrip1.TabIndex = 64;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butRefresh
            // 
            this.butRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRefresh.Image = ((System.Drawing.Image)(resources.GetObject("butRefresh.Image")));
            this.butRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(23, 22);
            this.butRefresh.ToolTipText = "Refresh";
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tmn_Timnhanh
            // 
            this.tmn_Timnhanh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Timnhanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tmn_Timnhanh.ForeColor = System.Drawing.Color.Blue;
            this.tmn_Timnhanh.Name = "tmn_Timnhanh";
            this.tmn_Timnhanh.Size = new System.Drawing.Size(80, 25);
            this.tmn_Timnhanh.Text = "Tìm kiếm";
            this.tmn_Timnhanh.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tmn_Timnhanh.Leave += new System.EventHandler(this.tmn_Timnhanh_Leave);
            this.tmn_Timnhanh.Enter += new System.EventHandler(this.tmn_Timnhanh_Enter);
            this.tmn_Timnhanh.TextChanged += new System.EventHandler(this.tmn_Timnhanh_TextChanged);
            // 
            // tmn_Tong
            // 
            this.tmn_Tong.ForeColor = System.Drawing.Color.Red;
            this.tmn_Tong.Name = "tmn_Tong";
            this.tmn_Tong.Size = new System.Drawing.Size(78, 22);
            this.tmn_Tong.Text = "toolStripLabel1";
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(601, 406);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(70, 29);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "     &Kết thúc";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(674, 60);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(1, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 33);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbProgress
            // 
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 28);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(1, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(674, 4);
            this.label3.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(-17, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 154);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.BackColor = System.Drawing.Color.ForestGreen;
            this.lbNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.ForeColor = System.Drawing.Color.White;
            this.lbNgay.Location = new System.Drawing.Point(11, 7);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(91, 13);
            this.lbNgay.TabIndex = 24;
            this.lbNgay.Text = "Ngày hoá đơn:";
            // 
            // lbKyhieu
            // 
            this.lbKyhieu.AutoSize = true;
            this.lbKyhieu.BackColor = System.Drawing.Color.ForestGreen;
            this.lbKyhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKyhieu.ForeColor = System.Drawing.Color.White;
            this.lbKyhieu.Location = new System.Drawing.Point(11, 24);
            this.lbKyhieu.Name = "lbKyhieu";
            this.lbKyhieu.Size = new System.Drawing.Size(53, 13);
            this.lbKyhieu.TabIndex = 25;
            this.lbKyhieu.Text = "Ký hiệu:";
            // 
            // lbSobienlai
            // 
            this.lbSobienlai.AutoSize = true;
            this.lbSobienlai.BackColor = System.Drawing.Color.ForestGreen;
            this.lbSobienlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSobienlai.ForeColor = System.Drawing.Color.White;
            this.lbSobienlai.Location = new System.Drawing.Point(11, 41);
            this.lbSobienlai.Name = "lbSobienlai";
            this.lbSobienlai.Size = new System.Drawing.Size(71, 13);
            this.lbSobienlai.TabIndex = 26;
            this.lbSobienlai.Text = "Số biên lai:";
            // 
            // lbNhanvien
            // 
            this.lbNhanvien.AutoSize = true;
            this.lbNhanvien.BackColor = System.Drawing.Color.ForestGreen;
            this.lbNhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhanvien.ForeColor = System.Drawing.Color.White;
            this.lbNhanvien.Location = new System.Drawing.Point(255, 41);
            this.lbNhanvien.Name = "lbNhanvien";
            this.lbNhanvien.Size = new System.Drawing.Size(123, 13);
            this.lbNhanvien.TabIndex = 29;
            this.lbNhanvien.Text = "Nhân viên thu ngân:";
            // 
            // lbMabn
            // 
            this.lbMabn.AutoSize = true;
            this.lbMabn.BackColor = System.Drawing.Color.ForestGreen;
            this.lbMabn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMabn.ForeColor = System.Drawing.Color.White;
            this.lbMabn.Location = new System.Drawing.Point(255, 7);
            this.lbMabn.Name = "lbMabn";
            this.lbMabn.Size = new System.Drawing.Size(49, 13);
            this.lbMabn.TabIndex = 27;
            this.lbMabn.Text = "Mã BN:";
            // 
            // lbDiachi
            // 
            this.lbDiachi.AutoSize = true;
            this.lbDiachi.BackColor = System.Drawing.Color.ForestGreen;
            this.lbDiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiachi.ForeColor = System.Drawing.Color.White;
            this.lbDiachi.Location = new System.Drawing.Point(255, 24);
            this.lbDiachi.Name = "lbDiachi";
            this.lbDiachi.Size = new System.Drawing.Size(51, 13);
            this.lbDiachi.TabIndex = 30;
            this.lbDiachi.Text = "Địa chỉ:";
            // 
            // frmChitiethd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 438);
            this.Controls.Add(this.lbDiachi);
            this.Controls.Add(this.lbNhanvien);
            this.Controls.Add(this.lbMabn);
            this.Controls.Add(this.lbSobienlai);
            this.Controls.Add(this.lbKyhieu);
            this.Controls.Add(this.lbNgay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChitiethd";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoá đơn";
            this.Load += new System.EventHandler(this.frmChitiethd_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbProgress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tmn_Timnhanh;
        private System.Windows.Forms.ToolStripLabel tmn_Tong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Loi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_May;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.Label lbKyhieu;
        private System.Windows.Forms.Label lbSobienlai;
        private System.Windows.Forms.Label lbNhanvien;
        private System.Windows.Forms.Label lbMabn;
        private System.Windows.Forms.Label lbDiachi;
    }
}