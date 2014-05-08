namespace Medisoft
{
    partial class frmDmgiatribt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmgiatribt));
            this.dtgvGiatribt = new System.Windows.Forms.DataGridView();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_mach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_nhietdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_huyetap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_nhiptho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_cannang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_chieucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMach = new System.Windows.Forms.TextBox();
            this.txtCannang = new System.Windows.Forms.TextBox();
            this.txtHuyetap = new System.Windows.Forms.TextBox();
            this.txtChieucao = new System.Windows.Forms.TextBox();
            this.txtNhiptho = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtNhietdo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGiatribt)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvGiatribt
            // 
            this.dtgvGiatribt.AllowUserToAddRows = false;
            this.dtgvGiatribt.AllowUserToDeleteRows = false;
            this.dtgvGiatribt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvGiatribt.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dtgvGiatribt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGiatribt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_id,
            this.cl_mach,
            this.cl_nhietdo,
            this.cl_huyetap,
            this.cl_nhiptho,
            this.cl_cannang,
            this.cl_chieucao});
            this.dtgvGiatribt.Location = new System.Drawing.Point(3, 3);
            this.dtgvGiatribt.Name = "dtgvGiatribt";
            this.dtgvGiatribt.RowHeadersVisible = false;
            this.dtgvGiatribt.Size = new System.Drawing.Size(487, 264);
            this.dtgvGiatribt.TabIndex = 12;
            this.dtgvGiatribt.CurrentCellChanged += new System.EventHandler(this.dtgvGiatribt_CurrentCellChanged);
            // 
            // cl_id
            // 
            this.cl_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cl_id.DataPropertyName = "id";
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.Visible = false;
            this.cl_id.Width = 50;
            // 
            // cl_mach
            // 
            this.cl_mach.DataPropertyName = "mach";
            this.cl_mach.HeaderText = "Mạch";
            this.cl_mach.Name = "cl_mach";
            this.cl_mach.ToolTipText = "Mạch";
            this.cl_mach.Width = 80;
            // 
            // cl_nhietdo
            // 
            this.cl_nhietdo.DataPropertyName = "nhietdo";
            this.cl_nhietdo.HeaderText = "Nhiệt độ";
            this.cl_nhietdo.Name = "cl_nhietdo";
            this.cl_nhietdo.ToolTipText = "Nhiệt độ";
            this.cl_nhietdo.Width = 80;
            // 
            // cl_huyetap
            // 
            this.cl_huyetap.DataPropertyName = "huyetap";
            this.cl_huyetap.HeaderText = "Huyết áp";
            this.cl_huyetap.Name = "cl_huyetap";
            this.cl_huyetap.ToolTipText = "Huyết áp";
            this.cl_huyetap.Width = 80;
            // 
            // cl_nhiptho
            // 
            this.cl_nhiptho.DataPropertyName = "nhiptho";
            this.cl_nhiptho.HeaderText = "Nhịp thở";
            this.cl_nhiptho.Name = "cl_nhiptho";
            this.cl_nhiptho.ToolTipText = "Nhịp thở";
            this.cl_nhiptho.Width = 80;
            // 
            // cl_cannang
            // 
            this.cl_cannang.DataPropertyName = "cannang";
            this.cl_cannang.HeaderText = "Cân nặng";
            this.cl_cannang.Name = "cl_cannang";
            this.cl_cannang.ToolTipText = "Cân nặng";
            this.cl_cannang.Width = 80;
            // 
            // cl_chieucao
            // 
            this.cl_chieucao.DataPropertyName = "chieucao";
            this.cl_chieucao.HeaderText = "Chiều cao";
            this.cl_chieucao.Name = "cl_chieucao";
            this.cl_chieucao.ToolTipText = "Chiều cao";
            this.cl_chieucao.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvGiatribt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 270);
            this.panel2.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMach);
            this.groupBox1.Controls.Add(this.txtCannang);
            this.groupBox1.Controls.Add(this.txtHuyetap);
            this.groupBox1.Controls.Add(this.txtChieucao);
            this.groupBox1.Controls.Add(this.txtNhiptho);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Controls.Add(this.txtNhietdo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 96);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Dấu Sinh Tồn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(413, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "C";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(402, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "o";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(406, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 15);
            this.label13.TabIndex = 17;
            this.label13.Text = "cm";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(159, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Kg";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(404, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "lần/phút ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(159, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "mmHg";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(159, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "lần/phút ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(275, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Chiều cao :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(286, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nhịp thở :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(287, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nhiệt độ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(11, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cân nặng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Huyết áp :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mạch :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMach
            // 
            this.txtMach.AcceptsTab = true;
            this.txtMach.Location = new System.Drawing.Point(91, 23);
            this.txtMach.Name = "txtMach";
            this.txtMach.Size = new System.Drawing.Size(65, 21);
            this.txtMach.TabIndex = 0;
            this.txtMach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMach_KeyDown);
            // 
            // txtCannang
            // 
            this.txtCannang.Location = new System.Drawing.Point(91, 68);
            this.txtCannang.Name = "txtCannang";
            this.txtCannang.Size = new System.Drawing.Size(65, 21);
            this.txtCannang.TabIndex = 4;
            this.txtCannang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCannang_KeyDown);
            // 
            // txtHuyetap
            // 
            this.txtHuyetap.Location = new System.Drawing.Point(91, 46);
            this.txtHuyetap.Name = "txtHuyetap";
            this.txtHuyetap.Size = new System.Drawing.Size(65, 21);
            this.txtHuyetap.TabIndex = 2;
            this.txtHuyetap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHuyetap_KeyDown);
            // 
            // txtChieucao
            // 
            this.txtChieucao.Location = new System.Drawing.Point(359, 69);
            this.txtChieucao.Name = "txtChieucao";
            this.txtChieucao.Size = new System.Drawing.Size(41, 21);
            this.txtChieucao.TabIndex = 5;
            this.txtChieucao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChieucao_KeyDown);
            // 
            // txtNhiptho
            // 
            this.txtNhiptho.Location = new System.Drawing.Point(359, 46);
            this.txtNhiptho.Name = "txtNhiptho";
            this.txtNhiptho.Size = new System.Drawing.Size(41, 21);
            this.txtNhiptho.TabIndex = 3;
            this.txtNhiptho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNhiptho_KeyDown);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(440, 11);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(41, 21);
            this.txtid.TabIndex = 16;
            this.txtid.Visible = false;
            // 
            // txtNhietdo
            // 
            this.txtNhietdo.Location = new System.Drawing.Point(359, 23);
            this.txtNhietdo.Name = "txtNhietdo";
            this.txtNhietdo.Size = new System.Drawing.Size(41, 21);
            this.txtNhietdo.TabIndex = 1;
            this.txtNhietdo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNhietdo_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butLuu);
            this.panel1.Controls.Add(this.butBoqua);
            this.panel1.Controls.Add(this.butMoi);
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.butSua);
            this.panel1.Controls.Add(this.butXoa);
            this.panel1.Location = new System.Drawing.Point(2, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 30);
            this.panel1.TabIndex = 15;
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(103, 3);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(313, 3);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(33, 3);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "     &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(383, 3);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(70, 25);
            this.butClose.TabIndex = 11;
            this.butClose.Text = "&Kết thúc";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(173, 3);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "      &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(243, 2);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 9;
            this.butXoa.Text = "      &Xóa";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // frmDmgiatribt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(493, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDmgiatribt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo giá trị mặc định dấu sinh tồn";
            this.Load += new System.EventHandler(this.frmDmgiatribt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGiatribt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMach;
        private System.Windows.Forms.TextBox txtNhietdo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHuyetap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNhiptho;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCannang;
        private System.Windows.Forms.TextBox txtChieucao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_mach;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_nhietdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_huyetap;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_nhiptho;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_cannang;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_chieucao;
        private System.Windows.Forms.DataGridView dtgvGiatribt;
    }
}