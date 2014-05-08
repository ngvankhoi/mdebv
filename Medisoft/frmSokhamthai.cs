using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSokhamthai.
	/// </summary>
	public class frmSokhamthai : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tinhchat;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private AccessData m;
		private decimal l_maql,l_mavaovien,_maql;
		private int i_userid,_songay;
		private string user,ngay_lv,nam,sql,xxx;
		private bool bAdmin;
        public bool bOk = false;
        private DataSet ds = new DataSet();
		private System.Windows.Forms.Label label19;
        private MaskedBox.MaskedBox ngay;
        private System.Windows.Forms.ComboBox ngoi;
        private System.Windows.Forms.Label label10;
        private MaskedBox.MaskedBox gio;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox dacdiem;
        private TextBox vat1;
        private TextBox tiensu;
        private MaskedTextBox.MaskedTextBox huyetap;
        private Label label39;
        private MaskedTextBox.MaskedTextBox mach;
        private Label label41;
        private Label label43;
        private Label label45;
        private MaskedTextBox.MaskedTextBox cao;
        private Label label18;
        private Label label20;
        private MaskedBox.MaskedBox ngaydd;
        private MaskedTextBox.MaskedTextBox para1;
        private Label label21;
        private MaskedTextBox.MaskedTextBox para4;
        private MaskedBox.MaskedBox ngaykc;
        private Label label22;
        private Label label23;
        private MaskedTextBox.MaskedTextBox para3;
        private MaskedTextBox.MaskedTextBox para2;
        private Label label24;
        private MaskedTextBox.MaskedTextBox chuky;
        private Label label25;
        private Label label26;
        private ComboBox luongkinh;
        private Label label27;
        private MaskedTextBox.MaskedTextBox songay;
        private Label label28;
        private Label label29;
        private Label label30;
        private TextBox vat2;
        private CheckBox chktiensu;
        private Label label5;
        private MaskedTextBox.MaskedTextBox cannang;
        private Label label6;
        private CheckBox phu;
        private Label label7;
        private TextBox bctc;
        private Label label8;
        private TextBox timthai;
        private Label label11;
        private TextBox ketluan;
        private TreeView treeView1;
        private CheckBox chkTiepdon;
        private TextBox hen_ghichu;
        private ComboBox hen_loai;
        private Label label32;
        private NumericUpDown hen_ngay;
        private Label label17;
        private Button butMoi;
        private DataGrid dataGrid1;
        public string _ghichu = "";
        public int _loai = 0, _tiepdon = 0,_songayhen=0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSokhamthai(AccessData acc,decimal mavaovien,decimal maql,string s_mabn,string s_ngay,string s_hoten,string s_namsinh,string s_mann,string s_diachi,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; mabn.Text = s_mabn; hoten.Text = s_hoten; namsinh.Text = s_namsinh; mann.Text = s_mann;
            diachi.Text = s_diachi; l_maql = maql; l_mavaovien = mavaovien; ngay_lv = s_ngay; ngay.Text = s_ngay.Substring(0, 10);
            gio.Text = s_ngay.Substring(11); i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSokhamthai));
            this.label1 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tinhchat = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.ngoi = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gio = new MaskedBox.MaskedBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dacdiem = new System.Windows.Forms.TextBox();
            this.vat1 = new System.Windows.Forms.TextBox();
            this.tiensu = new System.Windows.Forms.TextBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ngaydd = new MaskedBox.MaskedBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.ngaykc = new MaskedBox.MaskedBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chuky = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.luongkinh = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.songay = new MaskedTextBox.MaskedTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.vat2 = new System.Windows.Forms.TextBox();
            this.chktiensu = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.phu = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bctc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timthai = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ketluan = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chkTiepdon = new System.Windows.Forms.CheckBox();
            this.hen_ghichu = new System.Windows.Forms.TextBox();
            this.hen_loai = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.hen_ngay = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.butMoi = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(461, 5);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(41, 21);
            this.namsinh.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(217, 5);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(177, 21);
            this.hoten.TabIndex = 1;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(103, 5);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(73, 21);
            this.mabn.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(396, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(172, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 32;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(495, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nghề nghiệp :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(577, 5);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(136, 21);
            this.mann.TabIndex = 3;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(103, 28);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(291, 21);
            this.diachi.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(56, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Địa chỉ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tinhchat
            // 
            this.tinhchat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhchat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhchat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhchat.Items.AddRange(new object[] {
            "Đều",
            "Không đều"});
            this.tinhchat.Location = new System.Drawing.Point(328, 94);
            this.tinhchat.Name = "tinhchat";
            this.tinhchat.Size = new System.Drawing.Size(90, 21);
            this.tinhchat.TabIndex = 12;
            this.tinhchat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhchat_KeyDown);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(12, 323);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 23);
            this.label19.TabIndex = 10;
            this.label19.Text = "Ngày khám :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(94, 327);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(70, 21);
            this.ngay.TabIndex = 21;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // ngoi
            // 
            this.ngoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoi.Location = new System.Drawing.Point(555, 350);
            this.ngoi.Name = "ngoi";
            this.ngoi.Size = new System.Drawing.Size(158, 21);
            this.ngoi.TabIndex = 29;
            this.ngoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngoi_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(509, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 23);
            this.label10.TabIndex = 47;
            this.label10.Text = "Ngôi :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(190, 327);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 22;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(165, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 23);
            this.label12.TabIndex = 36;
            this.label12.Text = "giờ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(29, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(191, 23);
            this.label13.TabIndex = 48;
            this.label13.Text = "Mũi 2 :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(117, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 23);
            this.label14.TabIndex = 49;
            this.label14.Text = "Chu kỳ kinh :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dacdiem
            // 
            this.dacdiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dacdiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dacdiem.Location = new System.Drawing.Point(217, 50);
            this.dacdiem.Multiline = true;
            this.dacdiem.Name = "dacdiem";
            this.dacdiem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dacdiem.Size = new System.Drawing.Size(496, 42);
            this.dacdiem.TabIndex = 10;
            this.dacdiem.TextChanged += new System.EventHandler(this.dacdiem_TextChanged);
            // 
            // vat1
            // 
            this.vat1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vat1.Location = new System.Drawing.Point(217, 117);
            this.vat1.Name = "vat1";
            this.vat1.Size = new System.Drawing.Size(496, 21);
            this.vat1.TabIndex = 15;
            this.vat1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // tiensu
            // 
            this.tiensu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tiensu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiensu.Location = new System.Drawing.Point(217, 161);
            this.tiensu.Multiline = true;
            this.tiensu.Name = "tiensu";
            this.tiensu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tiensu.Size = new System.Drawing.Size(496, 42);
            this.tiensu.TabIndex = 18;
            this.tiensu.TextChanged += new System.EventHandler(this.tiensu_TextChanged);
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(417, 327);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(48, 21);
            this.huyetap.TabIndex = 24;
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label39.Location = new System.Drawing.Point(362, 323);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 24;
            this.label39.Text = "Huyết áp :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(555, 327);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(42, 21);
            this.mach.TabIndex = 25;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label41.Location = new System.Drawing.Point(511, 325);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 23);
            this.label41.TabIndex = 1;
            this.label41.Text = "Mạch :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label43.Location = new System.Drawing.Point(598, 325);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(28, 23);
            this.label43.TabIndex = 17;
            this.label43.Text = "l/p";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label45.Location = new System.Drawing.Point(467, 325);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(38, 23);
            this.label45.TabIndex = 21;
            this.label45.Text = "mmHg";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cao
            // 
            this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(461, 28);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(41, 21);
            this.cao.TabIndex = 5;
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(398, 456);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 37;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(326, 456);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 35;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(414, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Cao :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(503, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 23);
            this.label20.TabIndex = 56;
            this.label20.Text = "cm";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngaydd
            // 
            this.ngaydd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaydd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaydd.Location = new System.Drawing.Point(407, 205);
            this.ngaydd.Mask = "##/##/####";
            this.ngaydd.Name = "ngaydd";
            this.ngaydd.Size = new System.Drawing.Size(67, 21);
            this.ngaydd.TabIndex = 20;
            this.ngaydd.Text = "  /  /    ";
            this.ngaydd.Validated += new System.EventHandler(this.ngaydd_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(577, 28);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(20, 21);
            this.para1.TabIndex = 6;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(541, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Para :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(643, 28);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(20, 21);
            this.para4.TabIndex = 9;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // ngaykc
            // 
            this.ngaykc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykc.Location = new System.Drawing.Point(217, 205);
            this.ngaykc.Mask = "##/##/####";
            this.ngaykc.Name = "ngaykc";
            this.ngaykc.Size = new System.Drawing.Size(62, 21);
            this.ngaykc.TabIndex = 19;
            this.ngaykc.Text = "  /  /    ";
            this.ngaykc.Validated += new System.EventHandler(this.ngaykc_Validated);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(285, 208);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 15);
            this.label22.TabIndex = 29;
            this.label22.Text = "Ngày sanh dự đoán :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(131, 209);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 15);
            this.label23.TabIndex = 28;
            this.label23.Text = "Ngày kinh cuối :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(621, 28);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(20, 21);
            this.para3.TabIndex = 8;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(599, 28);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(20, 21);
            this.para2.TabIndex = 7;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(56, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(171, 23);
            this.label24.TabIndex = 57;
            this.label24.Text = "Đặc điểm những lần sinh trước :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chuky
            // 
            this.chuky.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chuky.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuky.Location = new System.Drawing.Point(217, 94);
            this.chuky.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chuky.MaxLength = 5;
            this.chuky.Name = "chuky";
            this.chuky.Size = new System.Drawing.Size(24, 21);
            this.chuky.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(241, 92);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(98, 23);
            this.label25.TabIndex = 59;
            this.label25.Text = "ngày, Tính chất :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(416, 94);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 21);
            this.label26.TabIndex = 60;
            this.label26.Text = "Lượng kinh :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luongkinh
            // 
            this.luongkinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.luongkinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.luongkinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luongkinh.Items.AddRange(new object[] {
            "Nhiều",
            "Trung bình",
            "Ít"});
            this.luongkinh.Location = new System.Drawing.Point(479, 94);
            this.luongkinh.Name = "luongkinh";
            this.luongkinh.Size = new System.Drawing.Size(70, 21);
            this.luongkinh.TabIndex = 13;
            this.luongkinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.luongkinh_KeyDown);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(549, 92);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(111, 23);
            this.label27.TabIndex = 62;
            this.label27.Text = "Số ngày ra máu kinh :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songay
            // 
            this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(657, 94);
            this.songay.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.songay.MaxLength = 5;
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(24, 21);
            this.songay.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(681, 93);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 23);
            this.label28.TabIndex = 64;
            this.label28.Text = "ngày";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(120, 118);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(88, 23);
            this.label29.TabIndex = 65;
            this.label29.Text = "Chích VAT :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(175, 118);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(45, 23);
            this.label30.TabIndex = 66;
            this.label30.Text = "Mũi 1 :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vat2
            // 
            this.vat2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vat2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vat2.Location = new System.Drawing.Point(217, 139);
            this.vat2.Name = "vat2";
            this.vat2.Size = new System.Drawing.Size(496, 21);
            this.vat2.TabIndex = 16;
            this.vat2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // chktiensu
            // 
            this.chktiensu.AutoSize = true;
            this.chktiensu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktiensu.Location = new System.Drawing.Point(120, 164);
            this.chktiensu.Name = "chktiensu";
            this.chktiensu.Size = new System.Drawing.Size(96, 17);
            this.chktiensu.TabIndex = 17;
            this.chktiensu.Text = "Tiền sử dị ứng ";
            this.chktiensu.UseVisualStyleBackColor = true;
            this.chktiensu.CheckedChanged += new System.EventHandler(this.chktiensu_CheckedChanged);
            this.chktiensu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(224, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 70;
            this.label5.Text = "Cân nặng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(292, 327);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(41, 21);
            this.cannang.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(337, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 23);
            this.label6.TabIndex = 72;
            this.label6.Text = "kg";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phu
            // 
            this.phu.AutoSize = true;
            this.phu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phu.Location = new System.Drawing.Point(660, 329);
            this.phu.Name = "phu";
            this.phu.Size = new System.Drawing.Size(48, 17);
            this.phu.TabIndex = 26;
            this.phu.Text = "Phù ";
            this.phu.UseVisualStyleBackColor = true;
            this.phu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(12, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 23);
            this.label7.TabIndex = 74;
            this.label7.Text = "BCTC :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bctc
            // 
            this.bctc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bctc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bctc.Location = new System.Drawing.Point(94, 350);
            this.bctc.Name = "bctc";
            this.bctc.Size = new System.Drawing.Size(239, 21);
            this.bctc.TabIndex = 27;
            this.bctc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(340, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 23);
            this.label8.TabIndex = 76;
            this.label8.Text = "Tim thai :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timthai
            // 
            this.timthai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timthai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timthai.Location = new System.Drawing.Point(417, 350);
            this.timthai.Name = "timthai";
            this.timthai.Size = new System.Drawing.Size(104, 21);
            this.timthai.TabIndex = 28;
            this.timthai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(12, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 23);
            this.label11.TabIndex = 78;
            this.label11.Text = "Kết luận - xử trí :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ketluan
            // 
            this.ketluan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketluan.Location = new System.Drawing.Point(94, 373);
            this.ketluan.Multiline = true;
            this.ketluan.Name = "ketluan";
            this.ketluan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ketluan.Size = new System.Drawing.Size(619, 48);
            this.ketluan.TabIndex = 30;
            this.ketluan.TextChanged += new System.EventHandler(this.ketluan_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(3, 74);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(114, 152);
            this.treeView1.TabIndex = 208;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // chkTiepdon
            // 
            this.chkTiepdon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTiepdon.AutoSize = true;
            this.chkTiepdon.BackColor = System.Drawing.SystemColors.Control;
            this.chkTiepdon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkTiepdon.Location = new System.Drawing.Point(250, 426);
            this.chkTiepdon.Name = "chkTiepdon";
            this.chkTiepdon.Size = new System.Drawing.Size(144, 17);
            this.chkTiepdon.TabIndex = 33;
            this.chkTiepdon.Text = "Qua đăng ký khám bệnh";
            this.chkTiepdon.UseVisualStyleBackColor = false;
            this.chkTiepdon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // hen_ghichu
            // 
            this.hen_ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ghichu.Location = new System.Drawing.Point(479, 422);
            this.hen_ghichu.Name = "hen_ghichu";
            this.hen_ghichu.Size = new System.Drawing.Size(234, 21);
            this.hen_ghichu.TabIndex = 34;
            this.hen_ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // hen_loai
            // 
            this.hen_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hen_loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_loai.FormattingEnabled = true;
            this.hen_loai.Items.AddRange(new object[] {
            "Ngày liên tục",
            "Ngày",
            "Tuần",
            "Tháng"});
            this.hen_loai.Location = new System.Drawing.Point(135, 423);
            this.hen_loai.Name = "hen_loai";
            this.hen_loai.Size = new System.Drawing.Size(110, 21);
            this.hen_loai.TabIndex = 32;
            this.hen_loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label32.Location = new System.Drawing.Point(411, 422);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 20);
            this.label32.TabIndex = 230;
            this.label32.Text = "Ghi chú :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen_ngay
            // 
            this.hen_ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ngay.Location = new System.Drawing.Point(94, 423);
            this.hen_ngay.Name = "hen_ngay";
            this.hen_ngay.Size = new System.Drawing.Size(40, 21);
            this.hen_ngay.TabIndex = 31;
            this.hen_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vat1_KeyDown);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(14, 422);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 23);
            this.label17.TabIndex = 227;
            this.label17.Text = "Hẹn tái khám :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(254, 456);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 36;
            this.butMoi.Text = "      &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(3, 209);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(710, 113);
            this.dataGrid1.TabIndex = 231;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // frmSokhamthai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(720, 491);
            this.ControlBox = false;
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.hen_ghichu);
            this.Controls.Add(this.chkTiepdon);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.hen_loai);
            this.Controls.Add(this.ketluan);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.hen_ngay);
            this.Controls.Add(this.timthai);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bctc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.phu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chktiensu);
            this.Controls.Add(this.vat2);
            this.Controls.Add(this.vat1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tinhchat);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.dacdiem);
            this.Controls.Add(this.luongkinh);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.chuky);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.ngaydd);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.ngaykc);
            this.Controls.Add(this.para4);
            this.Controls.Add(this.para1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cao);
            this.Controls.Add(this.para3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.para2);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.tiensu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ngoi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSokhamthai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ khám thai";
            this.Load += new System.EventHandler(this.frmSokhamthai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSokhamthai_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            nam = m.get_mabn_nam(mabn.Text);
            if (nam == "") nam = m.mmyy(ngay_lv) + "+";
            xxx = user + m.mmyy(ngay_lv);
			bAdmin=m.bAdmin(i_userid);
            _songay = m.Ngaylv_Ngayht; _maql = l_maql;
			load_dm();
            tinhchat.SelectedIndex = 0; luongkinh.SelectedIndex = 0; hen_loai.SelectedIndex = 0;
            string s = "";
            load_head();
            foreach (DataRow r in m.get_data("select * from " + xxx + ".sokhamthaict where maql=" + l_maql).Tables[0].Rows)
            {
                s = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                ngay.Text = s.Substring(0, 10);
                gio.Text = s.Substring(11);
                cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                huyetap.Text = r["huyetap"].ToString();
                mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                phu.Checked = r["phu"].ToString() == "1";
                bctc.Text = r["bctc"].ToString();
                timthai.Text = r["timthai"].ToString();
                ngoi.SelectedValue = r["ngoi"].ToString();
                ketluan.Text = r["ketluan"].ToString();
                load_hen();
                break;
            }
            ena_head(ds.Tables[0].Rows.Count == 0);
		}

        private void load_head()
        {
            string s = "";
            foreach (DataRow r in m.get_data("select * from " + xxx + ".sokhamthai where mavaovien=" + l_mavaovien).Tables[0].Rows)
            {
                cao.Text = r["cao"].ToString();
                s = r["para"].ToString().Trim();
                if (s.Length == 8)
                {
                    para1.Text = s.Substring(0, 2);
                    para2.Text = s.Substring(2, 2);
                    para3.Text = s.Substring(4, 2);
                    para4.Text = s.Substring(6, 2);
                }
                dacdiem.Text = r["dacdiem"].ToString();
                chuky.Text = (r["chuky"].ToString() != "0") ? r["chuky"].ToString() : "";
                tinhchat.SelectedIndex = int.Parse(r["tinhchat"].ToString());
                luongkinh.SelectedIndex = int.Parse(r["luongkinh"].ToString());
                songay.Text = (r["songay"].ToString() != "0") ? r["songay"].ToString() : "";
                vat1.Text = r["vat1"].ToString();
                vat2.Text = r["vat2"].ToString();
                chktiensu.Checked = r["tiensu"].ToString() != "";
                tiensu.Text = r["tiensu"].ToString();
                if (r["ngaykc"].ToString() != "") ngaykc.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaykc"].ToString()));
                if (r["ngaydd"].ToString() != "") ngaydd.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaydd"].ToString()));
                break;
            }
        }
        private void load_grid()
        {
            sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.cannang,a.huyetap,a.mach,a.phu,a.bctc,a.timthai,a.ngoi,a.ketluan,";
            sql += " b.ten as tenngoi from xxx.sokhamthaict a," + user + ".dmngoithai b where a.ngoi=b.id and a.mavaovien=" + l_mavaovien;
            sql += " order by a.maql ";
            ds = m.get_data_nam_all_dec(nam, sql);
            dataGrid1.DataSource = ds.Tables[0];
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cannang";
            TextCol.HeaderText = "Cân nặng";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "huyetap";
            TextCol.HeaderText = "Huyết áp";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mach";
            TextCol.HeaderText = "Mạch";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "bctc";
            TextCol.HeaderText = "BCTC";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "timthai";
            TextCol.HeaderText = "Tim thai";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenngoi";
            TextCol.HeaderText = "Ngôi";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ketluan";
            TextCol.HeaderText = "Kết luận - xử trí";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

		private void load_dm()
		{
			ngoi.ValueMember="ID";
			ngoi.DisplayMember="TEN";
			ngoi.DataSource=m.get_data("select * from "+user+".dmngoithai order by stt").Tables[0];
            load_treeView();
            load_grid();
            AddGridTableStyle();
		}

		private bool kiemtra()
		{
			if (tinhchat.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Tính chất !"),LibMedi.AccessData.Msg);
				tinhchat.Focus();
				return false;
			}

			if (luongkinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Lượng kinh !"),LibMedi.AccessData.Msg);
				luongkinh.Focus();
				return false;
			}

			if (ngoi.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn ngôi !"),LibMedi.AccessData.Msg);
				ngoi.Focus();
				return false;
			}
            
            string sql = "select b.* from " + xxx + ".sokhamthaict b,"+xxx+".sokhamthai a where a.mavaovien=b.mavaovien and a.mabn='" + mabn.Text + "' and to_char(b.ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "' and b.maql<>" + l_maql;
            if (m.get_data(sql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh ") + hoten.Text + lan.Change_language_MessageText(" khám thai ngày ") + ngay.Text + " " + gio.Text + "\n"+lan.Change_language_MessageText("Đã nhập !"), LibMedi.AccessData.Msg);
                return false;
            }
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!bAdmin)
			{
				if (m.get_data("select * from "+xxx+".sokhamthaict where maql="+l_maql).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            int itable = 0;
            if (cao.Enabled)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".benhanpk where maql=" + l_maql).Tables[0].Rows)
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                itable = m.tableid(m.mmyy(ngay_lv), "sokhamthai");
                if (m.get_data("select * from " + xxx + ".sokhamthai where mavaovien=" + l_mavaovien).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(ngay_lv, itable, i_userid, "upd");
                    m.upd_eve_upd_del(ngay_lv, itable, i_userid, "upd", m.fields(xxx + ".sokhamthai", "mavaovien=" + l_mavaovien));
                }
                else m.upd_eve_tables(ngay_lv, itable, i_userid, "ins");
                m.upd_sokhamthai(ngay_lv,mabn.Text,l_mavaovien,(cao.Text!="")?decimal.Parse(cao.Text):0,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),dacdiem.Text,(chuky.Text!="")?decimal.Parse(chuky.Text):0,tinhchat.SelectedIndex,luongkinh.SelectedIndex,(songay.Text!="")?decimal.Parse(songay.Text):0,vat1.Text,vat2.Text,tiensu.Text,ngaykc.Text,ngaydd.Text,i_userid);
            }
            itable = m.tableid(m.mmyy(ngay_lv), "sokhamthaict");
            if (m.get_data("select * from " + xxx + ".sokhamthaict where maql=" + l_maql).Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(ngay_lv, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngay_lv, itable, i_userid, "upd", m.fields(xxx+".sokhamthaict","maql="+l_maql));
            }
            else m.upd_eve_tables(ngay_lv, itable, i_userid, "ins");
			m.upd_sokhamthaict(ngay_lv,l_mavaovien,l_maql,ngay.Text+" "+gio.Text,(cannang.Text!="")?decimal.Parse(cannang.Text):0,huyetap.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,(phu.Checked)?1:0,bctc.Text,timthai.Text,int.Parse(ngoi.SelectedValue.ToString()),ketluan.Text);
            load_grid();
            bOk = true;
            if (_maql == l_maql)
            {
                _ghichu = hen_ghichu.Text;
                _songayhen = Convert.ToInt16(hen_ngay.Value);
                _tiepdon = (chkTiepdon.Checked) ? 1 : 0;
                _loai = hen_loai.SelectedIndex;
            }
            ena_head(false);
			butBoqua.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void ngay_Validated(object sender, System.EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"));
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngay.Focus();
                return;
            }
            if (!m.ngay(m.StringToDate(ngay.Text.Substring(0, 10)), DateTime.Now, _songay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày tai nạn, thương tích không hợp lệ so với khai báo hệ thống (") + _songay.ToString() + ")!", LibMedi.AccessData.Msg);
                ngay.Focus();
                return;
            }
        }

        private void gio_Validated(object sender, EventArgs e)
        {
            string sgio = (gio.Text.Trim() == "") ? "00:00" : gio.Text.Trim();
            gio.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(gio.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                gio.Focus();
                return;
            }
            if (!m.bNgaygio(ngay.Text + " " + gio.Text, ngay_lv))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày khám thai không được nhỏ hơn ngày vào (") + ngay_lv + ")", LibMedi.AccessData.Msg);
                ngay.Focus();
                return;
            }
        }

        private void dacdiem_TextChanged(object sender, EventArgs e)
        {
            if (dacdiem.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void tiensu_TextChanged(object sender, EventArgs e)
        {
            if (tiensu.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void ketluan_TextChanged(object sender, EventArgs e)
        {
            if (ketluan.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void vat1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tinhchat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (tinhchat.SelectedIndex == -1 && tinhchat.Items.Count > 0) tinhchat.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void luongkinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (luongkinh.SelectedIndex == -1 && luongkinh.Items.Count > 0) luongkinh.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void ngoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (ngoi.SelectedIndex == -1 && ngoi.Items.Count > 0) ngoi.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }
        private void ngaykc_Validated(object sender, System.EventArgs e)
        {
            if (ngaykc.Text != "")
            {
                ngaykc.Text = ngaykc.Text.Trim();
                if (ngaykc.Text.Length == 6) ngaykc.Text = ngaykc.Text + DateTime.Now.Year.ToString();
                if (!m.bNgay(ngaykc.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày kinh cuối cùng không hợp lệ !"));
                    ngaykc.Focus();
                    return;
                }
                ngaykc.Text = m.Ktngaygio(ngaykc.Text, 10);
                if (!m.bNgay("", ngaykc.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày kinh cuối cùng không hợp lệ !"));
                    ngaykc.Focus();
                    return;
                }
                ngaydd.Text = m.Ngaysanhdudoan(ngaykc.Text);
            }
        }

        private void ngaydd_Validated(object sender, System.EventArgs e)
        {
            if (ngaydd.Text == "") return;
            ngaydd.Text = ngaydd.Text.Trim();
            if (ngaydd.Text.Length == 6) ngaydd.Text = ngaydd.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(ngaydd.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày sang dự đoán không hợp lệ !"));
                ngaydd.Focus();
                return;
            }
            ngaydd.Text = m.Ktngaygio(ngaydd.Text, 10);
        }
        private void load_treeView()
        {
            treeView1.Nodes.Clear();
            TreeNode node;
            l_mavaovien = 0;
            foreach (DataRow r in m.get_data_nam(nam, "select a.mavaovien,a.ngay,a.makp,b.tenkp,a.chandoan,to_char(a.ngay,'yyyymmdd') as yyyymmdd,a.mavaovien from xxx.benhanpk a," + user + ".btdkp_bv b,xxx.sokhamthai c where a.makp=b.makp and a.mabn='" + mabn.Text + "' and a.mavaovien=c.mavaovien and a.mangtr=0").Tables[0].Select("true", "yyyymmdd desc"))
            {
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + " " + r["tenkp"].ToString().Trim() + "(" + r["makp"].ToString() + ")");
                node.Nodes.Add(r["chandoan"].ToString());
                l_mavaovien = (l_mavaovien == 0) ? decimal.Parse(r["mavaovien"].ToString()) : l_mavaovien;
            }
        }

        private void chktiensu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chktiensu) tiensu.Enabled = chktiensu.Checked;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                try
                {
                    string s = e.Node.FullPath.Trim();
                    int iPos = s.IndexOf("/");
                    l_mavaovien = 0;
                    string ngay = s.Substring(iPos - 2, 16), kp = s.Substring(s.IndexOf("(") + 1, 2);
                    foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngay) + ".benhanpk where mabn='" + mabn.Text + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay + "' and makp='" + kp + "'").Tables[0].Rows)
                        l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    if (l_mavaovien != 0)
                    {
                        load_head();
                        load_grid();
                    }
                }
                catch { }
            }
        }

        private void para1_Validated(object sender, System.EventArgs e)
        {
            para1.Text = para1.Text.PadLeft(2, '0');
            if (para1.Text == "99")
            {
                para2.Text = para1.Text;
                para3.Text = para1.Text;
                para4.Text = para1.Text;
                dacdiem.Focus();
            }
        }

        private void para2_Validated(object sender, System.EventArgs e)
        {
            para2.Text = para2.Text.PadLeft(2, '0');
        }

        private void para3_Validated(object sender, System.EventArgs e)
        {
            para3.Text = para3.Text.PadLeft(2, '0');
        }

        private void para4_Validated(object sender, System.EventArgs e)
        {
            para4.Text = para4.Text.PadLeft(2, '0');
        }

        private void emp_head()
        {
            cao.Text = ""; para1.Text = ""; para2.Text = ""; para3.Text = ""; para4.Text = "";
            dacdiem.Text = ""; chuky.Text = ""; songay.Text = ""; vat1.Text = ""; vat2.Text = "";
            chktiensu.Checked = false; tiensu.Text = ""; ngaykc.Text = ""; ngaydd.Text = "";
        }
        private void emp_detail()
        {
            string s = m.ngayhienhanh_server;
            ngay.Text = s.Substring(0, 10);gio.Text = s.Substring(11);
            cannang.Text = ""; huyetap.Text = ""; mach.Text = ""; phu.Checked = false;
            bctc.Text = ""; timthai.Text = ""; ketluan.Text = ""; hen_ngay.Value = 0; hen_ghichu.Text = "";
        }
        private void ena_head(bool ena)
        {
            cao.Enabled = ena; para1.Enabled = ena; para2.Enabled = ena; para3.Enabled = ena; para4.Enabled = ena;
            dacdiem.Enabled = ena; chuky.Enabled = ena; songay.Enabled = ena; vat1.Enabled = ena; vat2.Enabled = ena;
            chktiensu.Enabled = ena; tiensu.Enabled = ena; ngaykc.Enabled = ena; ngaydd.Enabled = ena; tinhchat.Enabled = ena; luongkinh.Enabled = ena;
            if (ena) tiensu.Enabled = chktiensu.Checked;
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            emp_head();
            emp_detail();
            ena_head(true);
            ds.Clear();
            cao.Focus();
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }
        private void ref_text()
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                l_maql = decimal.Parse(dataGrid1[i, 0].ToString());
                DataRow r = m.getrowbyid(ds.Tables[0], "maql=" + l_maql);
                if (r != null)
                {
                    ngay.Text = r["ngay"].ToString().Substring(0, 10);
                    gio.Text = r["ngay"].ToString().Substring(11);
                    cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    huyetap.Text = r["huyetap"].ToString();
                    mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                    phu.Checked = r["phu"].ToString() == "1";
                    bctc.Text = r["bctc"].ToString();
                    timthai.Text = r["timthai"].ToString();
                    ngoi.SelectedValue = r["ngoi"].ToString();
                    ketluan.Text = r["ketluan"].ToString();
                    load_hen();
                }
            }
            catch { }
        }

        private void load_hen()
        {
            foreach (DataRow r1 in m.get_data("select * from " + xxx + ".hen where maql=" + l_maql).Tables[0].Rows)
            {
                hen_ngay.Value = decimal.Parse(r1["songay"].ToString());
                hen_ghichu.Text = r1["ghichu"].ToString();
                hen_loai.SelectedIndex = int.Parse(r1["loai"].ToString());
                chkTiepdon.Checked = r1["tiepdon"].ToString() == "1";
                break;
            }
        }
	}
}
