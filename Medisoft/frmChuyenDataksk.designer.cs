namespace Medisoft
{
    partial class frmChuyenDataksk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenDataksk));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbChiNhanhNguon = new System.Windows.Forms.ComboBox();
            this.txtDatabaseNguon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortNguon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPNguon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbChiNhanhDich = new System.Windows.Forms.ComboBox();
            this.txtDatabaseDich = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortDich = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIPDich = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butTranfer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkKetQuaXN = new System.Windows.Forms.CheckBox();
            this.chkAddFieldChuyendi = new System.Windows.Forms.CheckBox();
            this.chkKetquaCDHA = new System.Windows.Forms.CheckBox();
            this.chkChuyenChidinh = new System.Windows.Forms.CheckBox();
            this.chkKSK = new System.Windows.Forms.CheckBox();
            this.chkChuyendmksk = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkChuyenDMGiavp = new System.Windows.Forms.CheckBox();
            this.chkdmbd = new System.Windows.Forms.CheckBox();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtphai = new System.Windows.Forms.TextBox();
            this.txtnamsinh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkToathuoc = new System.Windows.Forms.CheckBox();
            this.chkChuyenvienphi = new System.Windows.Forms.CheckBox();
            this.txtSoNgayLayData = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkdblink = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayLayData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbChiNhanhNguon);
            this.groupBox1.Controls.Add(this.txtDatabaseNguon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPortNguon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIPNguon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server nguồn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Chi nhánh :";
            // 
            // cmbChiNhanhNguon
            // 
            this.cmbChiNhanhNguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhNguon.Enabled = false;
            this.cmbChiNhanhNguon.FormattingEnabled = true;
            this.cmbChiNhanhNguon.Location = new System.Drawing.Point(90, 39);
            this.cmbChiNhanhNguon.Name = "cmbChiNhanhNguon";
            this.cmbChiNhanhNguon.Size = new System.Drawing.Size(260, 21);
            this.cmbChiNhanhNguon.TabIndex = 7;
            this.cmbChiNhanhNguon.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhNguon_SelectedIndexChanged);
            // 
            // txtDatabaseNguon
            // 
            this.txtDatabaseNguon.Location = new System.Drawing.Point(87, 116);
            this.txtDatabaseNguon.Name = "txtDatabaseNguon";
            this.txtDatabaseNguon.ReadOnly = true;
            this.txtDatabaseNguon.Size = new System.Drawing.Size(263, 20);
            this.txtDatabaseNguon.TabIndex = 5;
            this.txtDatabaseNguon.Text = "hepa_ksk1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Database :";
            // 
            // txtPortNguon
            // 
            this.txtPortNguon.Location = new System.Drawing.Point(87, 95);
            this.txtPortNguon.Name = "txtPortNguon";
            this.txtPortNguon.ReadOnly = true;
            this.txtPortNguon.Size = new System.Drawing.Size(263, 20);
            this.txtPortNguon.TabIndex = 3;
            this.txtPortNguon.Text = "5432";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port :";
            // 
            // txtIPNguon
            // 
            this.txtIPNguon.Location = new System.Drawing.Point(87, 74);
            this.txtIPNguon.Name = "txtIPNguon";
            this.txtIPNguon.ReadOnly = true;
            this.txtIPNguon.Size = new System.Drawing.Size(263, 20);
            this.txtIPNguon.TabIndex = 1;
            this.txtIPNguon.Text = "172.16.1.114";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbChiNhanhDich);
            this.groupBox2.Controls.Add(this.txtDatabaseDich);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPortDich);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIPDich);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(368, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Đích";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Chi nhánh :";
            // 
            // cmbChiNhanhDich
            // 
            this.cmbChiNhanhDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhDich.FormattingEnabled = true;
            this.cmbChiNhanhDich.Location = new System.Drawing.Point(101, 39);
            this.cmbChiNhanhDich.Name = "cmbChiNhanhDich";
            this.cmbChiNhanhDich.Size = new System.Drawing.Size(260, 21);
            this.cmbChiNhanhDich.TabIndex = 13;
            this.cmbChiNhanhDich.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhDich_SelectedIndexChanged);
            // 
            // txtDatabaseDich
            // 
            this.txtDatabaseDich.Location = new System.Drawing.Point(101, 116);
            this.txtDatabaseDich.Name = "txtDatabaseDich";
            this.txtDatabaseDich.ReadOnly = true;
            this.txtDatabaseDich.Size = new System.Drawing.Size(263, 20);
            this.txtDatabaseDich.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database :";
            // 
            // txtPortDich
            // 
            this.txtPortDich.Location = new System.Drawing.Point(101, 95);
            this.txtPortDich.Name = "txtPortDich";
            this.txtPortDich.ReadOnly = true;
            this.txtPortDich.Size = new System.Drawing.Size(263, 20);
            this.txtPortDich.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port :";
            // 
            // txtIPDich
            // 
            this.txtIPDich.Location = new System.Drawing.Point(101, 74);
            this.txtIPDich.Name = "txtIPDich";
            this.txtIPDich.ReadOnly = true;
            this.txtIPDich.Size = new System.Drawing.Size(263, 20);
            this.txtIPDich.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "IP :";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(12, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 23);
            this.label22.TabIndex = 317;
            this.label22.Text = "Mã số BN: ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label22.Visible = false;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(591, 210);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(122, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = " &Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butTranfer
            // 
            this.butTranfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butTranfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTranfer.Location = new System.Drawing.Point(469, 210);
            this.butTranfer.Name = "butTranfer";
            this.butTranfer.Size = new System.Drawing.Size(122, 25);
            this.butTranfer.TabIndex = 4;
            this.butTranfer.Text = "Chuyển dữ liệu";
            this.butTranfer.UseVisualStyleBackColor = true;
            this.butTranfer.Click += new System.EventHandler(this.butTranfer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 327;
            this.label7.Text = "Tables Chuyển: ";
            this.label7.Visible = false;
            // 
            // chkKetQuaXN
            // 
            this.chkKetQuaXN.AutoSize = true;
            this.chkKetQuaXN.Location = new System.Drawing.Point(93, 204);
            this.chkKetQuaXN.Name = "chkKetQuaXN";
            this.chkKetQuaXN.Size = new System.Drawing.Size(156, 17);
            this.chkKetQuaXN.TabIndex = 328;
            this.chkKetQuaXN.Text = "Chuyển Kết quả xét nghiệm";
            this.chkKetQuaXN.UseVisualStyleBackColor = true;
            // 
            // chkAddFieldChuyendi
            // 
            this.chkAddFieldChuyendi.AutoSize = true;
            this.chkAddFieldChuyendi.Checked = true;
            this.chkAddFieldChuyendi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddFieldChuyendi.Location = new System.Drawing.Point(471, 187);
            this.chkAddFieldChuyendi.Name = "chkAddFieldChuyendi";
            this.chkAddFieldChuyendi.Size = new System.Drawing.Size(126, 17);
            this.chkAddFieldChuyendi.TabIndex = 329;
            this.chkAddFieldChuyendi.Text = "Thêm field Chuyển đi";
            this.chkAddFieldChuyendi.UseVisualStyleBackColor = true;
            // 
            // chkKetquaCDHA
            // 
            this.chkKetquaCDHA.AutoSize = true;
            this.chkKetquaCDHA.Location = new System.Drawing.Point(93, 227);
            this.chkKetquaCDHA.Name = "chkKetquaCDHA";
            this.chkKetquaCDHA.Size = new System.Drawing.Size(201, 17);
            this.chkKetquaCDHA.TabIndex = 330;
            this.chkKetquaCDHA.Text = "Chuyển Kết quả chẩn đoán hình ảnh";
            this.chkKetquaCDHA.UseVisualStyleBackColor = true;
            // 
            // chkChuyenChidinh
            // 
            this.chkChuyenChidinh.AutoSize = true;
            this.chkChuyenChidinh.Location = new System.Drawing.Point(222, 184);
            this.chkChuyenChidinh.Name = "chkChuyenChidinh";
            this.chkChuyenChidinh.Size = new System.Drawing.Size(126, 17);
            this.chkChuyenChidinh.TabIndex = 331;
            this.chkChuyenChidinh.Text = "Chuyển chỉ định CLS";
            this.chkChuyenChidinh.UseVisualStyleBackColor = true;
            // 
            // chkKSK
            // 
            this.chkKSK.AutoSize = true;
            this.chkKSK.Location = new System.Drawing.Point(93, 184);
            this.chkKSK.Name = "chkKSK";
            this.chkKSK.Size = new System.Drawing.Size(91, 17);
            this.chkKSK.TabIndex = 332;
            this.chkKSK.Text = "Chuyển khám";
            this.chkKSK.UseVisualStyleBackColor = true;
            // 
            // chkChuyendmksk
            // 
            this.chkChuyendmksk.AutoSize = true;
            this.chkChuyendmksk.Checked = true;
            this.chkChuyendmksk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChuyendmksk.Location = new System.Drawing.Point(603, 184);
            this.chkChuyendmksk.Name = "chkChuyendmksk";
            this.chkChuyendmksk.Size = new System.Drawing.Size(138, 17);
            this.chkChuyendmksk.TabIndex = 336;
            this.chkChuyendmksk.Text = "Chuyển Danh mục KSK";
            this.chkChuyendmksk.UseVisualStyleBackColor = true;
            this.chkChuyendmksk.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 282);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(745, 19);
            this.lblStatus.TabIndex = 337;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkChuyenDMGiavp
            // 
            this.chkChuyenDMGiavp.AutoSize = true;
            this.chkChuyenDMGiavp.Location = new System.Drawing.Point(92, 273);
            this.chkChuyenDMGiavp.Name = "chkChuyenDMGiavp";
            this.chkChuyenDMGiavp.Size = new System.Drawing.Size(173, 17);
            this.chkChuyenDMGiavp.TabIndex = 338;
            this.chkChuyenDMGiavp.Text = "Chuyển Danh mục giá viện phí";
            this.chkChuyenDMGiavp.UseVisualStyleBackColor = true;
            this.chkChuyenDMGiavp.Visible = false;
            // 
            // chkdmbd
            // 
            this.chkdmbd.AutoSize = true;
            this.chkdmbd.Location = new System.Drawing.Point(271, 273);
            this.chkdmbd.Name = "chkdmbd";
            this.chkdmbd.Size = new System.Drawing.Size(97, 17);
            this.chkdmbd.TabIndex = 339;
            this.chkdmbd.Text = "Chuyển DMBD";
            this.chkdmbd.UseVisualStyleBackColor = true;
            this.chkdmbd.Visible = false;
            // 
            // txtmabn
            // 
            this.txtmabn.Location = new System.Drawing.Point(92, 11);
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(100, 20);
            this.txtmabn.TabIndex = 0;
            this.txtmabn.Validated += new System.EventHandler(this.txtmabn_Validated);
            this.txtmabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // txtHoten
            // 
            this.txtHoten.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.txtHoten.BackColor = System.Drawing.Color.White;
            this.txtHoten.Location = new System.Drawing.Point(255, 11);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.ReadOnly = true;
            this.txtHoten.Size = new System.Drawing.Size(276, 20);
            this.txtHoten.TabIndex = 341;
            // 
            // txtphai
            // 
            this.txtphai.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.txtphai.BackColor = System.Drawing.Color.White;
            this.txtphai.Location = new System.Drawing.Point(687, 11);
            this.txtphai.Name = "txtphai";
            this.txtphai.ReadOnly = true;
            this.txtphai.Size = new System.Drawing.Size(51, 20);
            this.txtphai.TabIndex = 342;
            // 
            // txtnamsinh
            // 
            this.txtnamsinh.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.txtnamsinh.BackColor = System.Drawing.Color.White;
            this.txtnamsinh.Location = new System.Drawing.Point(593, 11);
            this.txtnamsinh.Name = "txtnamsinh";
            this.txtnamsinh.ReadOnly = true;
            this.txtnamsinh.Size = new System.Drawing.Size(51, 20);
            this.txtnamsinh.TabIndex = 343;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(194, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 23);
            this.label10.TabIndex = 344;
            this.label10.Text = "Họ tên :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(533, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 23);
            this.label11.TabIndex = 345;
            this.label11.Text = "Năm sinh :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(646, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 23);
            this.label12.TabIndex = 346;
            this.label12.Text = "Phái :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Visible = false;
            // 
            // chkToathuoc
            // 
            this.chkToathuoc.AutoSize = true;
            this.chkToathuoc.Location = new System.Drawing.Point(93, 250);
            this.chkToathuoc.Name = "chkToathuoc";
            this.chkToathuoc.Size = new System.Drawing.Size(114, 17);
            this.chkToathuoc.TabIndex = 347;
            this.chkToathuoc.Text = "Chuyển Toa thuốc";
            this.chkToathuoc.UseVisualStyleBackColor = true;
            // 
            // chkChuyenvienphi
            // 
            this.chkChuyenvienphi.AutoSize = true;
            this.chkChuyenvienphi.Location = new System.Drawing.Point(222, 250);
            this.chkChuyenvienphi.Name = "chkChuyenvienphi";
            this.chkChuyenvienphi.Size = new System.Drawing.Size(122, 17);
            this.chkChuyenvienphi.TabIndex = 348;
            this.chkChuyenvienphi.Text = "Chuyển thu viện phí";
            this.chkChuyenvienphi.UseVisualStyleBackColor = true;
            // 
            // txtSoNgayLayData
            // 
            this.txtSoNgayLayData.Location = new System.Drawing.Point(648, 260);
            this.txtSoNgayLayData.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.txtSoNgayLayData.Name = "txtSoNgayLayData";
            this.txtSoNgayLayData.Size = new System.Drawing.Size(42, 20);
            this.txtSoNgayLayData.TabIndex = 349;
            this.txtSoNgayLayData.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(472, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 13);
            this.label13.TabIndex = 350;
            this.label13.Text = "Khoảng cách thời gian lấy dữ liệu :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(696, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 351;
            this.label14.Text = "ngày";
            // 
            // chkdblink
            // 
            this.chkdblink.AutoSize = true;
            this.chkdblink.Checked = true;
            this.chkdblink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkdblink.Location = new System.Drawing.Point(471, 241);
            this.chkdblink.Name = "chkdblink";
            this.chkdblink.Size = new System.Drawing.Size(124, 17);
            this.chkdblink.TabIndex = 352;
            this.chkdblink.Text = "Dùng Database Link";
            this.chkdblink.UseVisualStyleBackColor = true;
            // 
            // frmChuyenDataksk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 301);
            this.Controls.Add(this.chkdblink);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSoNgayLayData);
            this.Controls.Add(this.chkChuyenvienphi);
            this.Controls.Add(this.chkToathuoc);
            this.Controls.Add(this.txtphai);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtnamsinh);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.chkdmbd);
            this.Controls.Add(this.chkChuyenDMGiavp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkChuyendmksk);
            this.Controls.Add(this.chkKSK);
            this.Controls.Add(this.chkChuyenChidinh);
            this.Controls.Add(this.chkKetquaCDHA);
            this.Controls.Add(this.chkAddFieldChuyendi);
            this.Controls.Add(this.chkKetQuaXN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTranfer);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChuyenDataksk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển data của Bệnh nhân";
            this.Load += new System.EventHandler(this.frmChuyenDataksk_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayLayData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDatabaseNguon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortNguon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPNguon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtDatabaseDich;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPortDich;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIPDich;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butTranfer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkKetQuaXN;
        private System.Windows.Forms.CheckBox chkAddFieldChuyendi;
        private System.Windows.Forms.CheckBox chkKetquaCDHA;
        private System.Windows.Forms.CheckBox chkChuyenChidinh;
        private System.Windows.Forms.CheckBox chkKSK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbChiNhanhNguon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbChiNhanhDich;
        private System.Windows.Forms.CheckBox chkChuyendmksk;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkChuyenDMGiavp;
        private System.Windows.Forms.CheckBox chkdmbd;
        private System.Windows.Forms.TextBox txtmabn;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtphai;
        private System.Windows.Forms.TextBox txtnamsinh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkToathuoc;
        private System.Windows.Forms.CheckBox chkChuyenvienphi;
        private System.Windows.Forms.NumericUpDown txtSoNgayLayData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkdblink;
    }
}