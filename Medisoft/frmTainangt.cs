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
	/// Summary description for frmTainangt.
	/// </summary>
	public class frmTainangt : System.Windows.Forms.Form
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
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox diadiem;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private AccessData m;
		private decimal l_maql;
		private int songay,i_diadiem,i_userid;
		private string ngay_lv,s_ngaytt,user,xxx;
		private bool bAdmin,b701424;
		private System.Windows.Forms.Label label19;
		private MaskedBox.MaskedBox ngay;
		private LibList.List list;
		private System.Windows.Forms.Button butIn;
		private DataSet ds=new DataSet();
		private DataTable dtbv=new DataTable();
		private DataTable dtbs=new DataTable();
		private System.Windows.Forms.CheckBox chkXml;
		private MaskedBox.MaskedBox ngaycc;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox socap;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox ptvv;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox pttn;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox ptgaytn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox ptgaykhac;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox mubaohiem;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox gaiquai;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox bivo;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox loaimu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox ruoubia;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox camquan;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox mau;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox hoitho;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox sonao;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox glassgow;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.ComboBox cotsongco;
		private System.Windows.Forms.ComboBox thuongkhac;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox nhapvien;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.ComboBox mocapcuu;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox tuvong;
		private System.Windows.Forms.CheckBox xinve;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox tenbs;
		private LibList.List listBS;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox sophieu;
		private MaskedTextBox.MaskedTextBox mabv;
		private System.Windows.Forms.TextBox tenbv;
        private Label label40;
        private ComboBox nguyennhantv;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTainangt(AccessData acc,decimal maql,string s_mabn,string s_ngay,string s_hoten,string s_namsinh,string s_mann,string s_diachi,int userid,int idiadiem,string ngaytt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			namsinh.Text=s_namsinh;
			mann.Text=s_mann;
			diachi.Text=s_diachi;
			l_maql=maql;
			ngay_lv=s_ngay;
			ngay.Text=s_ngay;
			i_userid=userid;
			i_diadiem=idiadiem;
			s_ngaytt=ngaytt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTainangt));
            this.label1 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.diadiem = new System.Windows.Forms.ComboBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.list = new LibList.List();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.ngaycc = new MaskedBox.MaskedBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.socap = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ptvv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pttn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ptgaytn = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ptgaykhac = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.mubaohiem = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gaiquai = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bivo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.loaimu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.ruoubia = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.camquan = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.mau = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.hoitho = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.sonao = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.glassgow = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cotsongco = new System.Windows.Forms.ComboBox();
            this.thuongkhac = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.nhapvien = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.mocapcuu = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tuvong = new System.Windows.Forms.ComboBox();
            this.xinve = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.sophieu = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.nguyennhantv = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(448, 23);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(43, 21);
            this.namsinh.TabIndex = 5;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(256, 23);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(168, 21);
            this.hoten.TabIndex = 3;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(152, 23);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(64, 21);
            this.mabn.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(388, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(211, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nghề nghiệp :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(152, 46);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(272, 21);
            this.mann.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(440, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa điểm xảy ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(536, 23);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(278, 21);
            this.diachi.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(488, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "Địa chỉ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diadiem
            // 
            this.diadiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diadiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diadiem.Enabled = false;
            this.diadiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diadiem.Location = new System.Drawing.Point(536, 46);
            this.diadiem.Name = "diadiem";
            this.diadiem.Size = new System.Drawing.Size(120, 21);
            this.diadiem.TabIndex = 11;
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(429, 452);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 71;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(289, 452);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 69;
            this.butLuu.Text = "       &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(4, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 23);
            this.label19.TabIndex = 14;
            this.label19.Text = "Thời gian xảy ra tai nạn :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(152, 69);
            this.ngay.Mask = "##/##/#### ##:##";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(96, 21);
            this.ngay.TabIndex = 15;
            this.ngay.Text = "  /  /       :  ";
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(680, 488);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 0;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(359, 452);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 70;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXml
            // 
            this.chkXml.Location = new System.Drawing.Point(7, 453);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(88, 24);
            this.chkXml.TabIndex = 77;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // ngaycc
            // 
            this.ngaycc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaycc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaycc.Location = new System.Drawing.Point(328, 69);
            this.ngaycc.Mask = "##/##/#### ##:##";
            this.ngaycc.Name = "ngaycc";
            this.ngaycc.Size = new System.Drawing.Size(96, 21);
            this.ngaycc.TabIndex = 17;
            this.ngaycc.Text = "  /  /       :  ";
            this.ngaycc.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(192, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 23);
            this.label13.TabIndex = 16;
            this.label13.Text = "Đến cấp cứu :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(399, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 23);
            this.label14.TabIndex = 18;
            this.label14.Text = "Sơ cấp cứu ban đầu :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // socap
            // 
            this.socap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.socap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.socap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socap.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.socap.Location = new System.Drawing.Point(536, 69);
            this.socap.Name = "socap";
            this.socap.Size = new System.Drawing.Size(278, 21);
            this.socap.TabIndex = 19;
            this.socap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(4, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Phương tiện đưa nạn nhân đến viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ptvv
            // 
            this.ptvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptvv.Location = new System.Drawing.Point(256, 92);
            this.ptvv.Name = "ptvv";
            this.ptvv.Size = new System.Drawing.Size(558, 21);
            this.ptvv.TabIndex = 21;
            this.ptvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(4, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Phương tiện giao thông sử dụng khi bị tai nạn :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pttn
            // 
            this.pttn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pttn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pttn.Location = new System.Drawing.Point(256, 115);
            this.pttn.Name = "pttn";
            this.pttn.Size = new System.Drawing.Size(558, 21);
            this.pttn.TabIndex = 23;
            this.pttn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(4, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Phương tiện gây tai nạn :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ptgaytn
            // 
            this.ptgaytn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptgaytn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptgaytn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptgaytn.Items.AddRange(new object[] {
            "Ô tô",
            "Tàu hỏa",
            "Mô tô, xe gắn máy",
            "Xe tự chế",
            "Tự gây tai nạn",
            "Khác"});
            this.ptgaytn.Location = new System.Drawing.Point(152, 138);
            this.ptgaytn.Name = "ptgaytn";
            this.ptgaytn.Size = new System.Drawing.Size(240, 21);
            this.ptgaytn.TabIndex = 25;
            this.ptgaytn.SelectedIndexChanged += new System.EventHandler(this.ptgaytn_SelectedIndexChanged);
            this.ptgaytn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(400, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 26;
            this.label10.Text = "Khác :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptgaykhac
            // 
            this.ptgaykhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptgaykhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptgaykhac.Location = new System.Drawing.Point(448, 138);
            this.ptgaykhac.Name = "ptgaykhac";
            this.ptgaykhac.Size = new System.Drawing.Size(366, 21);
            this.ptgaykhac.TabIndex = 27;
            this.ptgaykhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 23);
            this.label11.TabIndex = 72;
            this.label11.Text = "I. THÔNG TIN CHUNG :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(4, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(280, 23);
            this.label12.TabIndex = 73;
            this.label12.Text = "II. THÔNG TIN VỀ SỬ DỤNG MŨ BẢO HIỂM :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(4, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(272, 19);
            this.label15.TabIndex = 28;
            this.label15.Text = "Đội mũ bảo hiểm :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mubaohiem
            // 
            this.mubaohiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mubaohiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mubaohiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mubaohiem.Items.AddRange(new object[] {
            "Có",
            "Không",
            "Không rõ"});
            this.mubaohiem.Location = new System.Drawing.Point(152, 190);
            this.mubaohiem.Name = "mubaohiem";
            this.mubaohiem.Size = new System.Drawing.Size(96, 21);
            this.mubaohiem.TabIndex = 29;
            this.mubaohiem.SelectedIndexChanged += new System.EventHandler(this.mubaohiem_SelectedIndexChanged);
            this.mubaohiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(178, 191);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(272, 19);
            this.label16.TabIndex = 30;
            this.label16.Text = "Nếu có, khi đội có gài quai không ? :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gaiquai
            // 
            this.gaiquai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gaiquai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gaiquai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaiquai.Items.AddRange(new object[] {
            "Có",
            "Không",
            "Không rõ"});
            this.gaiquai.Location = new System.Drawing.Point(448, 190);
            this.gaiquai.Name = "gaiquai";
            this.gaiquai.Size = new System.Drawing.Size(366, 21);
            this.gaiquai.TabIndex = 31;
            this.gaiquai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(4, 216);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(272, 19);
            this.label17.TabIndex = 32;
            this.label17.Text = "Mũ bảo hiểm có bị vỡ không ?";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bivo
            // 
            this.bivo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bivo.Items.AddRange(new object[] {
            "Có",
            "Không",
            "Không rõ"});
            this.bivo.Location = new System.Drawing.Point(152, 213);
            this.bivo.Name = "bivo";
            this.bivo.Size = new System.Drawing.Size(96, 21);
            this.bivo.TabIndex = 33;
            this.bivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label18.Location = new System.Drawing.Point(287, 215);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(163, 19);
            this.label18.TabIndex = 34;
            this.label18.Text = "Loại mũ bảo hiểm : Tên hãng :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaimu
            // 
            this.loaimu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaimu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaimu.Location = new System.Drawing.Point(448, 213);
            this.loaimu.Name = "loaimu";
            this.loaimu.Size = new System.Drawing.Size(366, 21);
            this.loaimu.TabIndex = 35;
            this.loaimu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(4, 241);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(280, 23);
            this.label20.TabIndex = 74;
            this.label20.Text = "III. THÔNG TIN VỀ SỬ DỤNG RƯỢU BIA :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label21.Location = new System.Drawing.Point(4, 267);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(272, 19);
            this.label21.TabIndex = 36;
            this.label21.Text = "Sử dụng rượu bia :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ruoubia
            // 
            this.ruoubia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ruoubia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruoubia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruoubia.Items.AddRange(new object[] {
            "Có",
            "Không",
            "Không rõ"});
            this.ruoubia.Location = new System.Drawing.Point(152, 266);
            this.ruoubia.Name = "ruoubia";
            this.ruoubia.Size = new System.Drawing.Size(96, 21);
            this.ruoubia.TabIndex = 38;
            this.ruoubia.SelectedIndexChanged += new System.EventHandler(this.ruoubia_SelectedIndexChanged);
            this.ruoubia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.Location = new System.Drawing.Point(180, 266);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(272, 19);
            this.label22.TabIndex = 39;
            this.label22.Text = "Nếu có, hoặc không rõ : Theo cảm quan :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // camquan
            // 
            this.camquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.camquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camquan.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.camquan.Location = new System.Drawing.Point(448, 266);
            this.camquan.Name = "camquan";
            this.camquan.Size = new System.Drawing.Size(156, 21);
            this.camquan.TabIndex = 40;
            this.camquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label23.Location = new System.Drawing.Point(4, 290);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(144, 19);
            this.label23.TabIndex = 41;
            this.label23.Text = "Đo nồng độ cồn trong máu :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mau
            // 
            this.mau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mau.Location = new System.Drawing.Point(152, 289);
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(43, 21);
            this.mau.TabIndex = 42;
            this.mau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mau_KeyPress);
            this.mau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label24.Location = new System.Drawing.Point(200, 290);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 19);
            this.label24.TabIndex = 43;
            this.label24.Text = "mg/ml máu";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label25.Location = new System.Drawing.Point(306, 292);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(144, 19);
            this.label25.TabIndex = 44;
            this.label25.Text = "Nồng độ cồn trong hơi thở :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoitho
            // 
            this.hoitho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoitho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoitho.Location = new System.Drawing.Point(448, 290);
            this.hoitho.Name = "hoitho";
            this.hoitho.Size = new System.Drawing.Size(43, 21);
            this.hoitho.TabIndex = 45;
            this.hoitho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hoitho_KeyPress);
            this.hoitho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label26.Location = new System.Drawing.Point(496, 290);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 19);
            this.label26.TabIndex = 46;
            this.label26.Text = "mg/1 khí thở";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(4, 319);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(280, 23);
            this.label27.TabIndex = 75;
            this.label27.Text = "IV. TÌNH TRẠNG THƯƠNG TÍCH :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label28.Location = new System.Drawing.Point(4, 344);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(144, 19);
            this.label28.TabIndex = 47;
            this.label28.Text = "Chấn thương sọ não :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sonao
            // 
            this.sonao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sonao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonao.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.sonao.Location = new System.Drawing.Point(152, 343);
            this.sonao.Name = "sonao";
            this.sonao.Size = new System.Drawing.Size(80, 21);
            this.sonao.TabIndex = 48;
            this.sonao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label29.Location = new System.Drawing.Point(227, 344);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 19);
            this.label29.TabIndex = 49;
            this.label29.Text = "Glassgow :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // glassgow
            // 
            this.glassgow.BackColor = System.Drawing.SystemColors.HighlightText;
            this.glassgow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassgow.Location = new System.Drawing.Point(288, 343);
            this.glassgow.Name = "glassgow";
            this.glassgow.Size = new System.Drawing.Size(43, 21);
            this.glassgow.TabIndex = 50;
            this.glassgow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glassgow_KeyPress);
            this.glassgow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label30.Location = new System.Drawing.Point(328, 344);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 19);
            this.label30.TabIndex = 51;
            this.label30.Text = "điểm";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label31.Location = new System.Drawing.Point(378, 342);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(144, 19);
            this.label31.TabIndex = 52;
            this.label31.Text = "Chấn thương cột sống cổ :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cotsongco
            // 
            this.cotsongco.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cotsongco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cotsongco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotsongco.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.cotsongco.Location = new System.Drawing.Point(510, 342);
            this.cotsongco.Name = "cotsongco";
            this.cotsongco.Size = new System.Drawing.Size(94, 21);
            this.cotsongco.TabIndex = 53;
            this.cotsongco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thuongkhac
            // 
            this.thuongkhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuongkhac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thuongkhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuongkhac.Items.AddRange(new object[] {
            "Không",
            "Chấn thương hàm mặt",
            "Chi",
            "Ngực, bụng",
            "Đa chấn thương"});
            this.thuongkhac.Location = new System.Drawing.Point(703, 343);
            this.thuongkhac.Name = "thuongkhac";
            this.thuongkhac.Size = new System.Drawing.Size(111, 21);
            this.thuongkhac.TabIndex = 55;
            this.thuongkhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label32.Location = new System.Drawing.Point(611, 344);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 19);
            this.label32.TabIndex = 54;
            this.label32.Text = "Tổn thương khác :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(4, 369);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(280, 23);
            this.label33.TabIndex = 76;
            this.label33.Text = "V. XỬ TRÍ :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label34.Location = new System.Drawing.Point(4, 396);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(144, 19);
            this.label34.TabIndex = 56;
            this.label34.Text = "Nhập viện :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhapvien
            // 
            this.nhapvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhapvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhapvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapvien.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.nhapvien.Location = new System.Drawing.Point(152, 394);
            this.nhapvien.Name = "nhapvien";
            this.nhapvien.Size = new System.Drawing.Size(80, 21);
            this.nhapvien.TabIndex = 57;
            this.nhapvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label35.Location = new System.Drawing.Point(240, 396);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 19);
            this.label35.TabIndex = 58;
            this.label35.Text = "Mổ cấp cứu :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mocapcuu
            // 
            this.mocapcuu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mocapcuu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mocapcuu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mocapcuu.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.mocapcuu.Location = new System.Drawing.Point(311, 394);
            this.mocapcuu.Name = "mocapcuu";
            this.mocapcuu.Size = new System.Drawing.Size(96, 21);
            this.mocapcuu.TabIndex = 59;
            this.mocapcuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label36.Location = new System.Drawing.Point(399, 396);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 19);
            this.label36.TabIndex = 60;
            this.label36.Text = "Tử vong :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuvong
            // 
            this.tuvong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuvong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tuvong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuvong.Items.AddRange(new object[] {
            "Không",
            "Trước bệnh viện",
            "Trong bệnh viện"});
            this.tuvong.Location = new System.Drawing.Point(470, 394);
            this.tuvong.Name = "tuvong";
            this.tuvong.Size = new System.Drawing.Size(134, 21);
            this.tuvong.TabIndex = 61;
            this.tuvong.SelectedIndexChanged += new System.EventHandler(this.tuvong_SelectedIndexChanged);
            this.tuvong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // xinve
            // 
            this.xinve.Location = new System.Drawing.Point(152, 457);
            this.xinve.Name = "xinve";
            this.xinve.Size = new System.Drawing.Size(104, 17);
            this.xinve.TabIndex = 62;
            this.xinve.Text = "Nặng, xin về";
            this.xinve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label37.Location = new System.Drawing.Point(4, 416);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(144, 19);
            this.label37.TabIndex = 63;
            this.label37.Text = "Nơi chuyển tuyến :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(510, 417);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(304, 21);
            this.tenbs.TabIndex = 68;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(680, 452);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 78;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(470, 417);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 67;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(152, 417);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(55, 21);
            this.mabv.TabIndex = 64;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(208, 417);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(199, 21);
            this.tenbv.TabIndex = 65;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label38.Location = new System.Drawing.Point(399, 420);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 19);
            this.label38.TabIndex = 66;
            this.label38.Text = "Lập phiếu :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(641, 45);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(72, 23);
            this.label39.TabIndex = 12;
            this.label39.Text = "Số phiếu :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(712, 46);
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(102, 21);
            this.sophieu.TabIndex = 13;
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(606, 399);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 13);
            this.label40.TabIndex = 79;
            this.label40.Text = "Nguyên nhân :";
            // 
            // nguyennhantv
            // 
            this.nguyennhantv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguyennhantv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nguyennhantv.Enabled = false;
            this.nguyennhantv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguyennhantv.Items.AddRange(new object[] {
            "",
            "Đến muộn",
            "Mức độ chấn thương nặng",
            "Khả năng cấp cứu"});
            this.nguyennhantv.Location = new System.Drawing.Point(680, 394);
            this.nguyennhantv.Name = "nguyennhantv";
            this.nguyennhantv.Size = new System.Drawing.Size(134, 21);
            this.nguyennhantv.TabIndex = 80;
            // 
            // frmTainangt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(821, 519);
            this.ControlBox = false;
            this.Controls.Add(this.nguyennhantv);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.glassgow);
            this.Controls.Add(this.diadiem);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.mocapcuu);
            this.Controls.Add(this.xinve);
            this.Controls.Add(this.tuvong);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.nhapvien);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.cotsongco);
            this.Controls.Add(this.thuongkhac);
            this.Controls.Add(this.sonao);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.hoitho);
            this.Controls.Add(this.camquan);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.mubaohiem);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.mau);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ruoubia);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.loaimu);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.ngaycc);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.bivo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.gaiquai);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ptgaykhac);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ptgaytn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.pttn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ptvv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.socap);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.list);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label38);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTainangt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tai nạn giao thông";
            this.Load += new System.EventHandler(this.frmTainangt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTainangt_Load(object sender, System.EventArgs e)
		{
            user = m.user; xxx = user + m.mmyy(s_ngaytt);
			b701424=m.Mabv_so==701424;
			bAdmin=m.bAdmin(i_userid);
			songay=m.Ngaylv_Ngayht;
			load_dm();
			DataTable tmp=m.get_data("select * from "+xxx+".tainangt where maql="+l_maql).Tables[0];
			if (tmp.Rows.Count==0) tmp=m.get_data("select a.* from "+xxx+".tainantt a,"+xxx+".tainangt b where a.maql=b.maql and a.mabn='"+mabn.Text+"' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngaytt.Substring(0,10)+"'").Tables[0];
			DataRow r1;
			foreach(DataRow r in tmp.Rows)
			{
				sophieu.Text=r["sophieu"].ToString();
				ngay.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				diadiem.SelectedIndex=i_diadiem;
				socap.SelectedIndex=int.Parse(r["socap"].ToString());
				ptvv.Text=r["ptvv"].ToString();
				pttn.Text=r["pttn"].ToString();
				ptgaytn.SelectedIndex=int.Parse(r["ptgaytn"].ToString());
				ptgaykhac.Text=r["ptgaykhac"].ToString();
				mubaohiem.SelectedIndex=int.Parse(r["mubaohiem"].ToString());
				gaiquai.SelectedIndex=int.Parse(r["gaiquai"].ToString());
				bivo.SelectedIndex=int.Parse(r["bivo"].ToString());
				loaimu.Text=r["loaimu"].ToString();
				ruoubia.SelectedIndex=int.Parse(r["ruoubia"].ToString());
				camquan.SelectedIndex=int.Parse(r["camquan"].ToString());
				mau.Text=(r["mau"].ToString()!="0")?r["mau"].ToString():"";
				hoitho.Text=(r["hoitho"].ToString()!="0")?r["hoitho"].ToString():"";
				sonao.SelectedIndex=int.Parse(r["sonao"].ToString());
				glassgow.Text=(r["glassgow"].ToString()!="0")?r["glassgow"].ToString():"";
				cotsongco.SelectedIndex=int.Parse(r["cotsongco"].ToString());
				thuongkhac.SelectedIndex=int.Parse(r["thuongkhac"].ToString());
				nhapvien.SelectedIndex=int.Parse(r["nhapvien"].ToString());
				mocapcuu.SelectedIndex=int.Parse(r["mocapcuu"].ToString());
				tuvong.SelectedIndex=int.Parse(r["tuvong"].ToString());
				xinve.Checked=r["xinve"].ToString()=="1";
				mabv.Text=r["mabv"].ToString();
                try //Khuong 25/11/2011 Them nguyen nhan tu vong
                {
                    nguyennhantv.Enabled = tuvong.SelectedIndex != 0;
                    nguyennhantv.SelectedIndex = int.Parse(r["nguyennhantuvong"].ToString());
                }
                catch {
                    nguyennhantv.SelectedIndex = 0;
                }
				if (mabv.Text!="")
				{
					r1=m.getrowbyid(dtbv,"mabv='"+mabv.Text+"'");
					tenbv.Text=(r1!=null)?r1["tenbv"].ToString():"";
				}
				mabs.Text=r["manv"].ToString();
				if (mabs.Text!="")
				{
					r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					tenbs.Text=(r1!=null)?r1["hoten"].ToString():"";
				}
				break;
			}

			ptgaykhac.Enabled=ptgaytn.SelectedIndex==5;
			gaiquai.Enabled=mubaohiem.SelectedIndex==0;
			bivo.Enabled=mubaohiem.SelectedIndex==0;
			loaimu.Enabled=mubaohiem.SelectedIndex==0;
			camquan.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
			mau.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
			hoitho.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
		}

		private void load_dm()
		{
			dtbv=m.get_data("select MABV,TENBV,DIACHI from "+user+".tenvien order by mabv").Tables[0];
			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
			list.DataSource=dtbv;

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="HOTEN";
			listBS.ValueMember="MA";
			listBS.DataSource=dtbs;

			diadiem.ValueMember="MA";
			diadiem.DisplayMember="TEN";
            diadiem.DataSource = m.get_data("select * from " + user + ".dmdiadiem order by ma").Tables[0];
			socap.SelectedIndex=ptgaytn.SelectedIndex=0;
			mubaohiem.SelectedIndex=gaiquai.SelectedIndex=bivo.SelectedIndex=1;
			ruoubia.SelectedIndex=camquan.SelectedIndex=1;
			sonao.SelectedIndex=cotsongco.SelectedIndex=1;
			thuongkhac.SelectedIndex=0;
			nhapvien.SelectedIndex=mocapcuu.SelectedIndex=1;
			tuvong.SelectedIndex=0;ngaycc.Text=s_ngaytt;
		}

		private bool kiemtra()
		{
            string sql = "select a.* from " + xxx + ".tainantt a," + xxx + ".tainangt b where a.maql=b.maql and a.mabn='" + mabn.Text + "' and to_char(b.ngay,'dd/mm/yyyy')='" + ngay.Text.Substring(0, 10) + "' and a.maql<>" + l_maql;
			if (m.get_data(sql).Tables[0].Rows.Count>0)
				if (MessageBox.Show(lan.Change_language_MessageText("Thông tin tai nạn giao thông ngày ")+ngay.Text.Substring(0,10)+lan.Change_language_MessageText(" đã nhập !")+"\n"+lan.Change_language_MessageText("Bạn có muốn nhập tiếp ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return false;
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            Cursor = Cursors.WaitCursor;
			if (!bAdmin)
			{
                if (m.get_data("select * from " + xxx + ".tainangt where maql=" + l_maql).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			if (!m.upd_tainangt(ngay.Text,l_maql,sophieu.Text,ngaycc.Text,socap.SelectedIndex,ptvv.Text,pttn.Text,ptgaytn.SelectedIndex,ptgaykhac.Text,
				mubaohiem.SelectedIndex,gaiquai.SelectedIndex,bivo.SelectedIndex,loaimu.Text,ruoubia.SelectedIndex,camquan.SelectedIndex,
				(mau.Text!="")?int.Parse(mau.Text):0,(hoitho.Text!="")?int.Parse(hoitho.Text):0,sonao.SelectedIndex,
				(glassgow.Text!="")?int.Parse(glassgow.Text):0,cotsongco.SelectedIndex,thuongkhac.SelectedIndex,
				nhapvien.SelectedIndex,mocapcuu.SelectedIndex,tuvong.SelectedIndex,(xinve.Checked)?1:0,mabv.Text,mabs.Text,nguyennhantv.SelectedIndex))
			{
                Cursor = Cursors.Default;
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhập được thông tin tai nạn giao thông !"),LibMedi.AccessData.Msg);
				return;
			}
            Cursor = Cursors.Default;

			butBoqua.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngaycc.Text=="")
			{
				ngaycc.Focus();
				return;
			}
			ngaycc.Text=ngaycc.Text.Trim();
			if (ngaycc.Text!=s_ngaytt)
			{
				if (ngaycc.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ đến cấp cứu !"),LibMedi.AccessData.Msg);
					ngaycc.Focus();
					return;
				}
				if (!m.bNgay(ngaycc.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngaycc.Focus();
					return;
				}
				ngaycc.Text=m.Ktngaygio(ngaycc.Text,16);
				if (!m.bNgaygio(ngaycc.Text,s_ngaytt))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày giờ đến cấp cứu không được nhỏ hơn ngày giờ xảy ra tai nạn (")+s_ngaytt+")",LibMedi.AccessData.Msg);
					ngaycc.Focus();
					return;
				}
				if (!m.ngay(m.StringToDate(ngaycc.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày giờ đến cấp cứu không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",LibMedi.AccessData.Msg);
					ngaycc.Focus();
					return;
				}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql="select a.mabn,a.hoten,a.namsinh,a.phai,'' as gioitinh,a.mann,a.mann as nghenghiep,a.sonha as diachi,";
			sql+="c.sophieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngaycc,d.ten as bophan, e.ten as diadiem, ";
            sql += "c.* from " + user + ".btdbn a," + xxx + ".tainantt b," + xxx + ".tainangt c, " + user + ".dmbophan d, " + user + ".dmdiadiem e ";
            sql += " where a.mabn=b.mabn and b.maql=c.maql and b.bophan=d.ma and b.diadiem=e.ma and b.maql=" + l_maql;
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Rows[0]["mabv"]=tenbv.Text;
				ds.Tables[0].Rows[0]["manv"]=tenbs.Text;
				ds.Tables[0].Rows[0]["gioitinh"]=(ds.Tables[0].Rows[0]["phai"].ToString()=="0")?"Nam":"Nữ";
				ds.Tables[0].Rows[0]["diachi"]=diachi.Text;
				ds.Tables[0].Rows[0]["nghenghiep"]=mann.Text;
				if (chkXml.Checked)
				{
					if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
					ds.WriteXml("..//xml//tainangt.xml",XmlWriteMode.WriteSchema);
				}
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,"","rptTainangt.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Chưa cập nhật !"),LibMedi.AccessData.Msg);
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mau_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void hoitho_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void glassgow_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void ptgaytn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ptgaytn) ptgaykhac.Enabled=ptgaytn.SelectedIndex==5;
		}

		private void mubaohiem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mubaohiem)
			{
				gaiquai.Enabled=mubaohiem.SelectedIndex==0;
				bivo.Enabled=mubaohiem.SelectedIndex==0;
				loaimu.Enabled=mubaohiem.SelectedIndex==0;
			}
		}

		private void ruoubia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ruoubia)
			{
				camquan.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
				mau.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
				hoitho.Enabled=ruoubia.SelectedIndex==0 || ruoubia.SelectedIndex==2;
			}
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			if (mabv.Text!="")
			{
				DataRow r=m.getrowbyid(dtbv,"mabv='"+mabv.Text+"'");
				tenbv.Text=(r!=null)?r["tenbv"].ToString():"";
			}
			else tenbv.Text="";		
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				tenbs.Text=(r!=null)?r["hoten"].ToString():"";
			}
			else tenbs.Text="";
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,butLuu,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible)
				{
					list.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbv)
			{
				Filt_tenbv(tenbv.Text);
				list.BrowseToText(tenbv,mabv,mabs,mabv.Location.X,mabv.Location.Y+mabv.Height,mabv.Width+tenbv.Width+2,mabv.Height);
			}
		}

		private void Filt_tenbv(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbv like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

        private void tuvong_SelectedIndexChanged(object sender, EventArgs e)
        {
            nguyennhantv.Enabled = tuvong.SelectedIndex != 0;
            nguyennhantv.SelectedIndex = tuvong.SelectedIndex == 0 ? 0 : nguyennhantv.SelectedIndex;
        }
	}
}
