using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmTainantt : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox diadiem;
		private System.Windows.Forms.ComboBox bophan;
		private System.Windows.Forms.ComboBox nguyennhan;
		private System.Windows.Forms.ComboBox ngodoc;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private AccessData m;
		private long l_maql;
		private int songay,i_userid;
		private string ngay_lv,s_ngaytt;
		private bool bAdmin,b701424;
		private System.Windows.Forms.Label label19;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.ComboBox dienbien;
		private System.Windows.Forms.ComboBox xutri;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.ComboBox tentqx;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.ComboBox tenquan;
		private System.Windows.Forms.Label lmaphuongxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.ComboBox tenpxa;
		private LibList.List list;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox mota;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTainantt(AccessData acc,long maql,string s_mabn,string s_ngay,string s_hoten,string s_namsinh,string s_mann,string s_diachi,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			namsinh.Text=s_namsinh;
			mann.Text=s_mann;
			diachi.Text=s_diachi;
			l_maql=maql;
			ngay_lv=s_ngay;
			ngay.Text=s_ngay;
			i_userid=userid;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTainantt));
			this.label1 = new System.Windows.Forms.Label();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.hoten = new System.Windows.Forms.TextBox();
			this.mabn = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.mann = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.diachi = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.diadiem = new System.Windows.Forms.ComboBox();
			this.bophan = new System.Windows.Forms.ComboBox();
			this.nguyennhan = new System.Windows.Forms.ComboBox();
			this.ngodoc = new System.Windows.Forms.ComboBox();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.ngay = new MaskedBox.MaskedBox();
			this.dienbien = new System.Windows.Forms.ComboBox();
			this.xutri = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.maqu1 = new MaskedTextBox.MaskedTextBox();
			this.lthon = new System.Windows.Forms.Label();
			this.thon = new System.Windows.Forms.TextBox();
			this.ltqx = new System.Windows.Forms.Label();
			this.tqx = new System.Windows.Forms.TextBox();
			this.tentqx = new System.Windows.Forms.ComboBox();
			this.lmatt = new System.Windows.Forms.Label();
			this.matt = new System.Windows.Forms.TextBox();
			this.tentinh = new System.Windows.Forms.ComboBox();
			this.lmaqu = new System.Windows.Forms.Label();
			this.maqu2 = new System.Windows.Forms.TextBox();
			this.tenquan = new System.Windows.Forms.ComboBox();
			this.lmaphuongxa = new System.Windows.Forms.Label();
			this.mapxa1 = new MaskedTextBox.MaskedTextBox();
			this.mapxa2 = new System.Windows.Forms.TextBox();
			this.tenpxa = new System.Windows.Forms.ComboBox();
			this.list = new LibList.List();
			this.label12 = new System.Windows.Forms.Label();
			this.mota = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(79, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(525, 8);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(43, 21);
			this.namsinh.TabIndex = 5;
			this.namsinh.Text = "";
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(245, 8);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(227, 21);
			this.hoten.TabIndex = 3;
			this.hoten.Text = "";
			// 
			// mabn
			// 
			this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn.Enabled = false;
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(125, 8);
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(73, 21);
			this.mabn.TabIndex = 1;
			this.mabn.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(464, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(197, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(47, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Nghề nghiệp :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mann
			// 
			this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mann.Enabled = false;
			this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mann.Location = new System.Drawing.Point(125, 31);
			this.mann.Name = "mann";
			this.mann.Size = new System.Drawing.Size(136, 21);
			this.mann.TabIndex = 7;
			this.mann.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(31, 166);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Địa điểm xảy ra :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(294, 166);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 15;
			this.label6.Text = "Bộ phận bị thương :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(23, 191);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 23);
			this.label7.TabIndex = 17;
			this.label7.Text = "Nguyên nhân :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(308, 191);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 23);
			this.label8.TabIndex = 19;
			this.label8.Text = "Ngộ độc các loại :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(317, 31);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(251, 21);
			this.diachi.TabIndex = 9;
			this.diachi.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(269, 31);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Địa chỉ :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// diadiem
			// 
			this.diadiem.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diadiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.diadiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diadiem.Location = new System.Drawing.Point(125, 168);
			this.diadiem.Name = "diadiem";
			this.diadiem.Size = new System.Drawing.Size(179, 21);
			this.diadiem.TabIndex = 23;
			this.diadiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diadiem_KeyDown);
			// 
			// bophan
			// 
			this.bophan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.bophan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bophan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bophan.Location = new System.Drawing.Point(402, 168);
			this.bophan.Name = "bophan";
			this.bophan.Size = new System.Drawing.Size(166, 21);
			this.bophan.TabIndex = 24;
			this.bophan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bophan_KeyDown);
			// 
			// nguyennhan
			// 
			this.nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nguyennhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nguyennhan.Location = new System.Drawing.Point(125, 191);
			this.nguyennhan.Name = "nguyennhan";
			this.nguyennhan.Size = new System.Drawing.Size(179, 21);
			this.nguyennhan.TabIndex = 25;
			this.nguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguyennhan_KeyDown);
			this.nguyennhan.SelectedIndexChanged += new System.EventHandler(this.nguyennhan_SelectedIndexChanged);
			// 
			// ngodoc
			// 
			this.ngodoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ngodoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngodoc.Location = new System.Drawing.Point(402, 191);
			this.ngodoc.Name = "ngodoc";
			this.ngodoc.Size = new System.Drawing.Size(166, 21);
			this.ngodoc.TabIndex = 26;
			this.ngodoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngodoc_KeyDown);
			// 
			// butBoqua
			// 
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(291, 304);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(70, 28);
			this.butBoqua.TabIndex = 31;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(217, 304);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(70, 28);
			this.butLuu.TabIndex = 30;
			this.butLuu.Text = "       &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label19.Location = new System.Drawing.Point(-10, 54);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(137, 23);
			this.label19.TabIndex = 10;
			this.label19.Text = "Thời điểm xảy ra tai nạn :";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngay
			// 
			this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngay.Location = new System.Drawing.Point(125, 54);
			this.ngay.Mask = "##/##/#### ##:##";
			this.ngay.Name = "ngay";
			this.ngay.Size = new System.Drawing.Size(94, 21);
			this.ngay.TabIndex = 11;
			this.ngay.Text = "";
			this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
			// 
			// dienbien
			// 
			this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dienbien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dienbien.Location = new System.Drawing.Point(125, 214);
			this.dienbien.Name = "dienbien";
			this.dienbien.Size = new System.Drawing.Size(179, 21);
			this.dienbien.TabIndex = 27;
			this.dienbien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dienbien_KeyDown);
			// 
			// xutri
			// 
			this.xutri.BackColor = System.Drawing.SystemColors.HighlightText;
			this.xutri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xutri.Location = new System.Drawing.Point(402, 214);
			this.xutri.Name = "xutri";
			this.xutri.Size = new System.Drawing.Size(166, 21);
			this.xutri.TabIndex = 28;
			this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(308, 214);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 23);
			this.label10.TabIndex = 23;
			this.label10.Text = "Xử trí sau tai nạn :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(7, 214);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 23);
			this.label11.TabIndex = 21;
			this.label11.Text = "Diễn biến sau tai nạn :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// maqu1
			// 
			this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maqu1.Enabled = false;
			this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu1.Location = new System.Drawing.Point(314, 122);
			this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.maqu1.MaxLength = 3;
			this.maqu1.Name = "maqu1";
			this.maqu1.Size = new System.Drawing.Size(27, 21);
			this.maqu1.TabIndex = 17;
			this.maqu1.Text = "";
			// 
			// lthon
			// 
			this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lthon.Location = new System.Drawing.Point(-25, 77);
			this.lthon.Name = "lthon";
			this.lthon.Size = new System.Drawing.Size(152, 23);
			this.lthon.TabIndex = 29;
			this.lthon.Text = "Nơi xảy ra tai nạn,Thôn :";
			this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// thon
			// 
			this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
			this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.thon.Location = new System.Drawing.Point(125, 77);
			this.thon.Name = "thon";
			this.thon.Size = new System.Drawing.Size(443, 21);
			this.thon.TabIndex = 12;
			this.thon.Text = "";
			this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
			this.thon.Validated += new System.EventHandler(this.thon_Validated);
			this.thon.TextChanged += new System.EventHandler(this.thon_TextChanged);
			// 
			// ltqx
			// 
			this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ltqx.Location = new System.Drawing.Point(63, 97);
			this.ltqx.Name = "ltqx";
			this.ltqx.Size = new System.Drawing.Size(64, 23);
			this.ltqx.TabIndex = 31;
			this.ltqx.Text = "T/Q/PXã :";
			this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tqx
			// 
			this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tqx.Location = new System.Drawing.Point(125, 99);
			this.tqx.Name = "tqx";
			this.tqx.Size = new System.Drawing.Size(64, 21);
			this.tqx.TabIndex = 13;
			this.tqx.Text = "";
			this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
			// 
			// tentqx
			// 
			this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentqx.ItemHeight = 13;
			this.tentqx.Location = new System.Drawing.Point(191, 99);
			this.tentqx.Name = "tentqx";
			this.tentqx.Size = new System.Drawing.Size(377, 21);
			this.tentqx.TabIndex = 14;
			this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
			this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
			// 
			// lmatt
			// 
			this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lmatt.Location = new System.Drawing.Point(71, 121);
			this.lmatt.Name = "lmatt";
			this.lmatt.Size = new System.Drawing.Size(56, 23);
			this.lmatt.TabIndex = 34;
			this.lmatt.Text = "Tỉnh/TP :";
			this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// matt
			// 
			this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.matt.Location = new System.Drawing.Point(125, 122);
			this.matt.MaxLength = 3;
			this.matt.Name = "matt";
			this.matt.Size = new System.Drawing.Size(27, 21);
			this.matt.TabIndex = 15;
			this.matt.Text = "";
			this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
			// 
			// tentinh
			// 
			this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentinh.ItemHeight = 13;
			this.tentinh.Location = new System.Drawing.Point(154, 122);
			this.tentinh.Name = "tentinh";
			this.tentinh.Size = new System.Drawing.Size(112, 21);
			this.tentinh.TabIndex = 16;
			this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
			this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
			// 
			// lmaqu
			// 
			this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lmaqu.Location = new System.Drawing.Point(259, 121);
			this.lmaqu.Name = "lmaqu";
			this.lmaqu.Size = new System.Drawing.Size(56, 23);
			this.lmaqu.TabIndex = 37;
			this.lmaqu.Text = "Quận/H :";
			this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// maqu2
			// 
			this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu2.Location = new System.Drawing.Point(342, 122);
			this.maqu2.Name = "maqu2";
			this.maqu2.Size = new System.Drawing.Size(21, 21);
			this.maqu2.TabIndex = 18;
			this.maqu2.Text = "";
			this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
			this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
			// 
			// tenquan
			// 
			this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenquan.ItemHeight = 13;
			this.tenquan.Location = new System.Drawing.Point(365, 122);
			this.tenquan.Name = "tenquan";
			this.tenquan.Size = new System.Drawing.Size(203, 21);
			this.tenquan.TabIndex = 19;
			this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
			this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
			// 
			// lmaphuongxa
			// 
			this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lmaphuongxa.Location = new System.Drawing.Point(55, 141);
			this.lmaphuongxa.Name = "lmaphuongxa";
			this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
			this.lmaphuongxa.TabIndex = 41;
			this.lmaphuongxa.Text = "Phường/Xã :";
			this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mapxa1
			// 
			this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa1.Enabled = false;
			this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa1.Location = new System.Drawing.Point(125, 145);
			this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mapxa1.MaxLength = 5;
			this.mapxa1.Name = "mapxa1";
			this.mapxa1.Size = new System.Drawing.Size(40, 21);
			this.mapxa1.TabIndex = 20;
			this.mapxa1.Text = "";
			// 
			// mapxa2
			// 
			this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa2.Location = new System.Drawing.Point(166, 145);
			this.mapxa2.Name = "mapxa2";
			this.mapxa2.Size = new System.Drawing.Size(23, 21);
			this.mapxa2.TabIndex = 21;
			this.mapxa2.Text = "";
			this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
			this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
			// 
			// tenpxa
			// 
			this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenpxa.ItemHeight = 13;
			this.tenpxa.Location = new System.Drawing.Point(192, 145);
			this.tenpxa.Name = "tenpxa";
			this.tenpxa.Size = new System.Drawing.Size(376, 21);
			this.tenpxa.TabIndex = 22;
			this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
			this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
			// 
			// list
			// 
			this.list.BackColor = System.Drawing.SystemColors.Info;
			this.list.ColumnCount = 0;
			this.list.Location = new System.Drawing.Point(392, 320);
			this.list.MatchBufferTimeOut = 1000;
			this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(75, 17);
			this.list.TabIndex = 42;
			this.list.TextIndex = -1;
			this.list.TextMember = null;
			this.list.ValueIndex = -1;
			this.list.Visible = false;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 237);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(120, 23);
			this.label12.TabIndex = 43;
			this.label12.Text = "Mô tả :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mota
			// 
			this.mota.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mota.Location = new System.Drawing.Point(125, 238);
			this.mota.Multiline = true;
			this.mota.Name = "mota";
			this.mota.Size = new System.Drawing.Size(443, 58);
			this.mota.TabIndex = 29;
			this.mota.Text = "";
			// 
			// frmTainantt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(578, 351);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.mota,
																		  this.label12,
																		  this.list,
																		  this.dienbien,
																		  this.nguyennhan,
																		  this.diadiem,
																		  this.mapxa1,
																		  this.tqx,
																		  this.matt,
																		  this.thon,
																		  this.maqu1,
																		  this.lthon,
																		  this.ltqx,
																		  this.tentqx,
																		  this.lmatt,
																		  this.tentinh,
																		  this.lmaqu,
																		  this.maqu2,
																		  this.tenquan,
																		  this.lmaphuongxa,
																		  this.mapxa2,
																		  this.tenpxa,
																		  this.bophan,
																		  this.xutri,
																		  this.label10,
																		  this.label11,
																		  this.ngay,
																		  this.label19,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.ngodoc,
																		  this.diachi,
																		  this.label9,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.mann,
																		  this.label4,
																		  this.namsinh,
																		  this.hoten,
																		  this.mabn,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTainantt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin tai nạn, thương tích";
			this.Load += new System.EventHandler(this.frmTainantt_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmTainantt_Load(object sender, System.EventArgs e)
		{
			b701424=m.Mabv_so==701424;
			bAdmin=m.bAdmin(i_userid);
			songay=m.Ngaylv_Ngayht;
			load_dm();
			DataTable tmp=m.get_data("select * from tainantt where maql="+l_maql).Tables[0];
			if (tmp.Rows.Count==0) tmp=m.get_data("select * from tainantt where mabn='"+mabn.Text+"' and to_char(ngay,'dd/mm/yyyy')='"+ngay_lv.Substring(0,10)+"'").Tables[0];
			foreach(DataRow r in tmp.Rows)
			{
				ngay.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				diadiem.SelectedIndex=int.Parse(r["diadiem"].ToString());
				bophan.SelectedIndex=int.Parse(r["bophan"].ToString());
				nguyennhan.SelectedIndex=int.Parse(r["nguyennhan"].ToString());
				ngodoc.SelectedIndex=int.Parse(r["ngodoc"].ToString());
				dienbien.SelectedIndex=int.Parse(r["dienbien"].ToString());
				xutri.SelectedIndex=int.Parse(r["xutri"].ToString());
				thon.Text=r["thon"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				mota.Text=r["mota"].ToString();
				break;
			}
			s_ngaytt=ngay.Text;
			SendKeys.Send("{HOME}");
		}

		private void load_dm()
		{
			list.DisplayMember="THON";
			list.ValueMember="THON";
			list.DataSource=m.get_data("select thon as ma,thon from dmthon order by thon").Tables[0];

			dienbien.ValueMember="MA";
			dienbien.DisplayMember="TEN";
			dienbien.DataSource=m.get_data("select * from dmdienbien order by ma").Tables[0];

			xutri.ValueMember="MA";
			xutri.DisplayMember="TEN";
			xutri.DataSource=m.get_data("select * from dmxutri order by ma").Tables[0];

			diadiem.ValueMember="MA";
			diadiem.DisplayMember="TEN";
			diadiem.DataSource=m.get_data("select * from dmdiadiem order by ma").Tables[0];

			bophan.ValueMember="MA";
			bophan.DisplayMember="TEN";
			bophan.DataSource=m.get_data("select * from dmbophan order by ma").Tables[0];

			nguyennhan.ValueMember="MA";
			nguyennhan.DisplayMember="TEN";
			nguyennhan.DataSource=m.get_data("select * from dmnguyennhan order by ma").Tables[0];

			ngodoc.ValueMember="MA";
			ngodoc.DisplayMember="TEN";
			ngodoc.DataSource=m.get_data("select * from dmngodoc order by ma").Tables[0];

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
			tentinh.DataSource=m.get_data("select * from btdtt order by "+((b701424)?"tentt":"matt")).Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";
		}

		private void load_quan()
		{
			tenquan.DataSource=m.get_data("select * from btdquan where matt='"+tentinh.SelectedValue.ToString()+"' order by "+((b701424)?"tenquan":"maqu")).Tables[0];
		}

		private void load_pxa()
		{
			tenpxa.DataSource=m.get_data("select * from btdpxa where maqu='"+tenquan.SelectedValue.ToString()+"' order by "+((b701424)?"tenpxa":"maphuongxa")).Tables[0];
		}

		private void tentqx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
				tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
				tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
			}
			catch{tqx.Text="";}
		}

		private void tentqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					if (tentqx.SelectedIndex==-1) tentqx.SelectedIndex=0;
					tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
					tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
					tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
					diadiem.Focus();
					return;
				}
				catch{}
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (tentinh.SelectedIndex==-1) tentinh.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				matt.Text=tentinh.SelectedValue.ToString();
				load_quan();
			}
			catch{matt.Text="";}
		}

		private void tenquan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				maqu1.Text=tenquan.SelectedValue.ToString().Substring(0,3);
				maqu2.Text=tenquan.SelectedValue.ToString().Substring(3,2);
				load_pxa();
			}
			catch
			{
				maqu1.Text="";
				maqu2.Text="";
			}
		}

		private void tenquan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenquan.SelectedIndex==-1) tenquan.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenpxa.SelectedIndex==-1) tenpxa.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mapxa1.Text=tenpxa.SelectedValue.ToString().Substring(0,5);
				mapxa2.Text=tenpxa.SelectedValue.ToString().Substring(5,2);
			}
			catch
			{
				mapxa1.Text="";
				mapxa2.Text="";
			}
		}

		private void load_tqx()
		{
			tentqx.DataSource=m.Tqx(tqx.Text).Tables[0];
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=matt.Text;
			}
			catch{}
		}

		private void maqu2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenquan.SelectedValue=maqu1.Text+maqu2.Text;
			}
			catch{}
		}

		private void maqu2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenpxa.SelectedValue=mapxa1.Text+mapxa2.Text;
			}
			catch{}
		}

		private void tqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tqx.Text=="") matt.Focus();
				else
				{
					load_tqx();
					if (tentqx.Items.Count==1)
					{
						try
						{
							string s=tentqx.SelectedValue.ToString();
							tentinh.SelectedValue=s.Substring(0,3);
							tenquan.SelectedValue=s.Substring(0,5);
							tenpxa.SelectedValue=s;
							diadiem.Focus();
						}
						catch{}
					}
					else SendKeys.Send("{Tab}{F4}");
				}
			}
		}

		private void thon_Validated(object sender, System.EventArgs e)
		{
			thon.Text=m.Caps(thon.Text);
		}

		private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				thon.Text=m.Viettat(thon.Text)+" ";
				SendKeys.Send("{END}");
			}
			else
			{
				if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
				else if (e.KeyCode==Keys.Enter)
				{
					if (list.Visible) list.Focus();
					else SendKeys.Send("{Tab}{Home}");
				}		
			}
		}

		private void diadiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (diadiem.SelectedIndex==-1) diadiem.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void bophan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (bophan.SelectedIndex==-1) bophan.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nguyennhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (nguyennhan.SelectedIndex==-1) nguyennhan.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ngodoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (ngodoc.SelectedIndex==-1) ngodoc.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private bool kiemtra()
		{
			if (tentinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"),LibMedi.AccessData.Msg);
				tentinh.Focus();
				return false;
			}

			if (tenquan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),LibMedi.AccessData.Msg);
				tenquan.Focus();
				return false;
			}

			if (tenpxa.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"),LibMedi.AccessData.Msg);
				tenpxa.Focus();
				return false;
			}
			if (nguyennhan.SelectedIndex==6 && ngodoc.SelectedIndex==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu loại ngộ độc !"),LibMedi.AccessData.Msg);
				ngodoc.Focus();
				return false;
			}
			else 
			{
				if (bophan.SelectedIndex==0 && nguyennhan.SelectedIndex!=7 && bophan.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu bộ phận xảy ra !"),LibMedi.AccessData.Msg);
					bophan.Focus();
					return false;
				}
			}
			string sql="select * from tainantt where mabn='"+mabn.Text+"' and to_char(ngay,'dd/mm/yyyy')='"+ngay.Text.Substring(0,10)+"' and maql<>"+l_maql;
			if (m.get_data(sql).Tables[0].Rows.Count>0)
				if (MessageBox.Show("Thông tin tai nạn thương tích ngày "+ngay.Text.Substring(0,10)+" đã nhập !\nBạn có muốn nhập tiếp ?",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return false;
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!bAdmin)
			{
				if (m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			m.upd_tainantt(mabn.Text,l_maql,ngay.Text,diadiem.SelectedIndex,bophan.SelectedIndex,nguyennhan.SelectedIndex,ngodoc.SelectedIndex,dienbien.SelectedIndex,xutri.SelectedIndex,thon.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,mota.Text);
			if (thon.Text!="") m.upd_dmthon(thon.Text);
			this.Close();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void nguyennhan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ngodoc.Enabled=nguyennhan.SelectedIndex==6;
				bophan.Enabled=!ngodoc.Enabled;
				if (!ngodoc.Enabled) ngodoc.SelectedIndex=0;
				if (!bophan.Enabled) bophan.SelectedIndex=0;
			}
			catch{}
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text=="")
			{
				ngay.Focus();
				return;
			}
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text!=s_ngaytt)
			{
				if (ngay.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ tai nạn, thương tích !"),LibMedi.AccessData.Msg);
					ngay.Focus();
					return;
				}
				if (!m.bNgay(ngay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngay.Focus();
					return;
				}
				ngay.Text=m.Ktngaygio(ngay.Text,16);
				if (!m.bNgaygio(ngay_lv,ngay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày tai nạn, thương tích không được lớn hơn ngày vào (")+ngay_lv+")",LibMedi.AccessData.Msg);
					ngay.Focus();
					return;
				}
				if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày tai nạn, thương tích không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",LibMedi.AccessData.Msg);
					ngay.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void dienbien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) 
			{
				if (dienbien.SelectedIndex==-1) dienbien.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}		
		}

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) 
			{
				if (xutri.SelectedIndex==-1) xutri.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}	

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="thon like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void thon_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thon)
			{
				Filter(thon.Text);
				list.BrowseToThon(thon,thon,tqx);
			}		
		}
	}
}
