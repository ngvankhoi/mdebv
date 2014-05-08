namespace Vienphi
{
    partial class frmNewbaocao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewbaocao));
            this.panel2 = new System.Windows.Forms.Panel();
            this.listDieukien = new System.Windows.Forms.ListBox();
            this.butGetdataall = new System.Windows.Forms.Button();
            this.butGetdata = new System.Windows.Forms.Button();
            this.butBrown = new System.Windows.Forms.Button();
            this.cbCha = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenreport = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStt = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkReadonly = new System.Windows.Forms.CheckBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listDieukien);
            this.panel2.Controls.Add(this.butGetdataall);
            this.panel2.Controls.Add(this.butGetdata);
            this.panel2.Controls.Add(this.butBrown);
            this.panel2.Controls.Add(this.cbCha);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTenreport);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtStt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkReadonly);
            this.panel2.Controls.Add(this.txtSQL);
            this.panel2.Controls.Add(this.txtTen);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 309);
            this.panel2.TabIndex = 0;
            // 
            // listDieukien
            // 
            this.listDieukien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listDieukien.FormattingEnabled = true;
            this.listDieukien.IntegralHeight = false;
            this.listDieukien.Items.AddRange(new object[] {
            ":v_tn",
            ":v_dn",
            ":v_tn16",
            ":v_dn16",
            ":v_makp",
            ":v_mabs",
            ":v_mabsdoc",
            ":v_maktv",
            ":v_doituong",
            ":v_loaibn",
            ":v_loaidv",
            ":v_tinhtrang",
            ":v_id_vitrung",
            ":v_id_benhpham",
            ":v_userid"});
            this.listDieukien.Location = new System.Drawing.Point(496, 115);
            this.listDieukien.Name = "listDieukien";
            this.listDieukien.Size = new System.Drawing.Size(132, 188);
            this.listDieukien.TabIndex = 43;
            // 
            // butGetdataall
            // 
            this.butGetdataall.BackColor = System.Drawing.SystemColors.Control;
            this.butGetdataall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGetdataall.Image = ((System.Drawing.Image)(resources.GetObject("butGetdataall.Image")));
            this.butGetdataall.Location = new System.Drawing.Point(103, 90);
            this.butGetdataall.Name = "butGetdataall";
            this.butGetdataall.Size = new System.Drawing.Size(26, 23);
            this.butGetdataall.TabIndex = 8;
            this.butGetdataall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGetdataall.UseVisualStyleBackColor = true;
            this.butGetdataall.Click += new System.EventHandler(this.butGetdataall_Click);
            // 
            // butGetdata
            // 
            this.butGetdata.BackColor = System.Drawing.SystemColors.Control;
            this.butGetdata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGetdata.Image = ((System.Drawing.Image)(resources.GetObject("butGetdata.Image")));
            this.butGetdata.Location = new System.Drawing.Point(75, 90);
            this.butGetdata.Name = "butGetdata";
            this.butGetdata.Size = new System.Drawing.Size(26, 23);
            this.butGetdata.TabIndex = 7;
            this.butGetdata.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGetdata.UseVisualStyleBackColor = true;
            this.butGetdata.Click += new System.EventHandler(this.butGetdata_Click);
            // 
            // butBrown
            // 
            this.butBrown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrown.BackColor = System.Drawing.SystemColors.Control;
            this.butBrown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBrown.Image = ((System.Drawing.Image)(resources.GetObject("butBrown.Image")));
            this.butBrown.Location = new System.Drawing.Point(606, 47);
            this.butBrown.Name = "butBrown";
            this.butBrown.Size = new System.Drawing.Size(22, 20);
            this.butBrown.TabIndex = 4;
            this.butBrown.TabStop = false;
            this.butBrown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBrown.UseVisualStyleBackColor = true;
            this.butBrown.Click += new System.EventHandler(this.butBrown_Click);
            // 
            // cbCha
            // 
            this.cbCha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCha.BackColor = System.Drawing.Color.White;
            this.cbCha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCha.ForeColor = System.Drawing.Color.Black;
            this.cbCha.FormattingEnabled = true;
            this.cbCha.Location = new System.Drawing.Point(75, 68);
            this.cbCha.Name = "cbCha";
            this.cbCha.Size = new System.Drawing.Size(553, 21);
            this.cbCha.TabIndex = 5;
            this.cbCha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSo_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-55, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Mục cha:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenreport
            // 
            this.txtTenreport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenreport.BackColor = System.Drawing.Color.White;
            this.txtTenreport.ForeColor = System.Drawing.Color.Black;
            this.txtTenreport.Location = new System.Drawing.Point(75, 47);
            this.txtTenreport.Name = "txtTenreport";
            this.txtTenreport.Size = new System.Drawing.Size(530, 20);
            this.txtTenreport.TabIndex = 3;
            this.txtTenreport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViettat_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-55, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "Tên report:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStt
            // 
            this.txtStt.BackColor = System.Drawing.Color.White;
            this.txtStt.Location = new System.Drawing.Point(75, 5);
            this.txtStt.Mask = "0000000";
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(52, 20);
            this.txtStt.TabIndex = 0;
            this.txtStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStt.ValidatingType = typeof(int);
            this.txtStt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSt_KeyDown);
            this.txtStt.Validated += new System.EventHandler(this.txtStt_Validated);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Stt:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkReadonly
            // 
            this.chkReadonly.AutoSize = true;
            this.chkReadonly.Location = new System.Drawing.Point(133, 8);
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Size = new System.Drawing.Size(71, 17);
            this.chkReadonly.TabIndex = 1;
            this.chkReadonly.Text = "Readonly";
            this.chkReadonly.UseVisualStyleBackColor = true;
            this.chkReadonly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkReadonly_KeyDown);
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.BackColor = System.Drawing.Color.White;
            this.txtSQL.ForeColor = System.Drawing.Color.Black;
            this.txtSQL.Location = new System.Drawing.Point(2, 115);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(492, 188);
            this.txtSQL.TabIndex = 6;
            this.txtSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(75, 26);
            this.txtTen.MaxLength = 4000;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(553, 20);
            this.txtTen.TabIndex = 2;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-57, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 21);
            this.label5.TabIndex = 39;
            this.label5.Text = "Câu truy vấn:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tên báo cáo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(496, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 44;
            this.label2.Text = "Điều kiện lọc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(282, 1);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(81, 28);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(212, 1);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 28);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "      &Xoá";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(142, 1);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 28);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "      &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(2, 1);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 28);
            this.butMoi.TabIndex = 0;
            this.butMoi.Text = "      &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(72, 1);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 28);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(363, 1);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(72, 28);
            this.butClose.TabIndex = 5;
            this.butClose.Text = "      Đó&ng";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(635, 60);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(188, 57);
            this.toolStripLabel1.Text = "CẬP NHẬT BÁO CÁO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttStatus});
            this.statusStrip1.Location = new System.Drawing.Point(1, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttStatus
            // 
            this.ttStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.ttStatus.Image = ((System.Drawing.Image)(resources.GetObject("ttStatus.Image")));
            this.ttStatus.Name = "ttStatus";
            this.ttStatus.Size = new System.Drawing.Size(63, 17);
            this.ttStatus.Text = "ttStatus";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butBoqua);
            this.panel1.Controls.Add(this.butXoa);
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.butSua);
            this.panel1.Controls.Add(this.butLuu);
            this.panel1.Controls.Add(this.butMoi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 30);
            this.panel1.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(-15, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 100);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // frmNewbaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 423);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewbaocao";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật báo cáo";
            this.Load += new System.EventHandler(this.frmNewbaocao_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox txtTenreport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtStt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkReadonly;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butBrown;
        private System.Windows.Forms.Button butGetdataall;
        private System.Windows.Forms.Button butGetdata;
        private System.Windows.Forms.ListBox listDieukien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}