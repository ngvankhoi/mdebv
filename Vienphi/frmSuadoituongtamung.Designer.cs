namespace Vienphi
{
    partial class frmSuadoituongtamung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuadoituongtamung));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ngayra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.madtcu = new System.Windows.Forms.ComboBox();
            this.madtmoi = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.cboLoaibnMoi = new System.Windows.Forms.ComboBox();
            this.cboLoaiBN = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            // 
            // mabn
            // 
            this.mabn.Location = new System.Drawing.Point(56, 6);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(72, 20);
            this.mabn.TabIndex = 0;
            this.mabn.Text = "12345678";
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên:";
            // 
            // hoten
            // 
            this.hoten.Enabled = false;
            this.hoten.Location = new System.Drawing.Point(178, 6);
            this.hoten.MaxLength = 8;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(201, 20);
            this.hoten.TabIndex = 1;
            this.hoten.Text = "12345678";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày vào :";
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.FormattingEnabled = true;
            this.ngayvao.Location = new System.Drawing.Point(56, 27);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(123, 21);
            this.ngayvao.TabIndex = 4;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Theo :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.FormattingEnabled = true;
            this.theo.Items.AddRange(new object[] {
            "Toàn bộ",
            "Chi tiết"});
            this.theo.Location = new System.Drawing.Point(56, 49);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(123, 21);
            this.theo.TabIndex = 9;
            this.theo.SelectedIndexChanged += new System.EventHandler(this.theo_SelectedIndexChanged);
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Năm sinh:";
            // 
            // namsinh
            // 
            this.namsinh.Enabled = false;
            this.namsinh.Location = new System.Drawing.Point(431, 6);
            this.namsinh.MaxLength = 8;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(44, 20);
            this.namsinh.TabIndex = 2;
            this.namsinh.Text = "1982";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Địa chỉ:";
            // 
            // diachi
            // 
            this.diachi.Enabled = false;
            this.diachi.Location = new System.Drawing.Point(550, 6);
            this.diachi.MaxLength = 8;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(239, 20);
            this.diachi.TabIndex = 3;
            this.diachi.Text = "1982";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Từ ngày:";
            // 
            // ngayvv
            // 
            this.ngayvv.Location = new System.Drawing.Point(236, 27);
            this.ngayvv.MaxLength = 8;
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(87, 20);
            this.ngayvv.TabIndex = 5;
            this.ngayvv.Text = "12345678";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            this.ngayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvv_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Đến ngày:";
            // 
            // ngayra
            // 
            this.ngayra.Location = new System.Drawing.Point(378, 27);
            this.ngayra.MaxLength = 8;
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(97, 20);
            this.ngayra.TabIndex = 6;
            this.ngayra.Text = "12345678";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            this.ngayra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayra_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Khoa xuất viện:";
            // 
            // tenkp
            // 
            this.tenkp.Location = new System.Drawing.Point(591, 27);
            this.tenkp.MaxLength = 8;
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(198, 20);
            this.tenkp.TabIndex = 8;
            this.tenkp.Text = "1982";
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // makp
            // 
            this.makp.Location = new System.Drawing.Point(550, 27);
            this.makp.MaxLength = 8;
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(40, 20);
            this.makp.TabIndex = 7;
            this.makp.Text = "1982";
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // madtcu
            // 
            this.madtcu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madtcu.FormattingEnabled = true;
            this.madtcu.Location = new System.Drawing.Point(236, 49);
            this.madtcu.Name = "madtcu";
            this.madtcu.Size = new System.Drawing.Size(239, 21);
            this.madtcu.TabIndex = 10;
            this.madtcu.SelectedIndexChanged += new System.EventHandler(this.madtcu_SelectedIndexChanged);
            this.madtcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtcu_KeyDown);
            // 
            // madtmoi
            // 
            this.madtmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madtmoi.FormattingEnabled = true;
            this.madtmoi.Location = new System.Drawing.Point(550, 49);
            this.madtmoi.Name = "madtmoi";
            this.madtmoi.Size = new System.Drawing.Size(239, 21);
            this.madtmoi.TabIndex = 11;
            this.madtmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtmoi_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Đối tượng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Đối tượng mới :";
            // 
            // butTiep
            // 
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(202, 529);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(73, 25);
            this.butTiep.TabIndex = 15;
            this.butTiep.Text = "   &Tiếp";
            this.butTiep.UseVisualStyleBackColor = true;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(275, 529);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(73, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "   &Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(421, 529);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(73, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "   &Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(348, 529);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(73, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "   &Sửa";
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(494, 529);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(3, 54);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(788, 462);
            this.dataGrid1.TabIndex = 35;
            // 
            // cboLoaibnMoi
            // 
            this.cboLoaibnMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaibnMoi.FormattingEnabled = true;
            this.cboLoaibnMoi.Location = new System.Drawing.Point(431, 71);
            this.cboLoaibnMoi.Name = "cboLoaibnMoi";
            this.cboLoaibnMoi.Size = new System.Drawing.Size(358, 21);
            this.cboLoaibnMoi.TabIndex = 39;
            this.cboLoaibnMoi.Visible = false;
            // 
            // cboLoaiBN
            // 
            this.cboLoaiBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBN.Enabled = false;
            this.cboLoaiBN.FormattingEnabled = true;
            this.cboLoaiBN.Location = new System.Drawing.Point(56, 71);
            this.cboLoaiBN.Name = "cboLoaiBN";
            this.cboLoaiBN.Size = new System.Drawing.Size(294, 21);
            this.cboLoaiBN.TabIndex = 38;
            this.cboLoaiBN.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Loại BN mới :";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Loại BN :";
            this.label13.Visible = false;
            // 
            // frmSuadoituongtamung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.madtmoi);
            this.Controls.Add(this.madtcu);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.cboLoaibnMoi);
            this.Controls.Add(this.cboLoaiBN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSuadoituongtamung";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa đối tượng tạm ứng";
            this.Load += new System.EventHandler(this.frmSuadoituongtamung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mabn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ngayvao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox theo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox namsinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ngayvv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ngayra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tenkp;
        private System.Windows.Forms.TextBox makp;
        private System.Windows.Forms.ComboBox madtcu;
        private System.Windows.Forms.ComboBox madtmoi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butTiep;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.ComboBox cboLoaibnMoi;
        private System.Windows.Forms.ComboBox cboLoaiBN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}