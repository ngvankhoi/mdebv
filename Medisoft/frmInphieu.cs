using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using System.IO;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmThuhoi.
	/// </summary>
	public class frmInphieu : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dtphieu=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataSet ds;
		private DataSet dsxml;
		private DataTable dt=new DataTable();
		private DataTable dtkho=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataTable dtnguon=new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable tmpyc = new DataTable();
        private DataTable dtnhomin = new DataTable();
        private string s_mmyy, s_makp, sql, s_makho, s_madt, s_tendt, s_tenkho, file1, file2, tenfile, s_idduyet, tieude, s_manguon, s_tennguon, s_doc, s_nhomkho, user, stime, s_ngay = "", s_ngayylenhduyet, s_nhomin, s_tennhomin;
        private int i_nhom, i_loai, i_makp, i_phieu, i_songay, i_loais, i_userid;
		private bool bBuhaophi=false,bNhomin_mabd,bInngang,bDoituong_phieulinh,bInphieu_ngay,bNgayylenh_phieulinh,bChuky,bLinh_dongia;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private dllReportM.Print prn = new dllReportM.Print();
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.CheckBox xuatcstt;
		private System.Windows.Forms.CheckedListBox manguon;
		private System.Windows.Forms.CheckBox haophicstt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox xem;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox nguoilinh;
		private DataColumn dc;
		private System.Windows.Forms.NumericUpDown banin;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckedListBox kho;
        private byte[] image_duoc = new byte[0];
        private byte[] image_dieutri = new byte[0];
        private System.IO.MemoryStream memo;
        private FileStream fstr;
        private Panel p;
        private CheckedListBox ckNhomIn;
        private Label label13;
        private CheckBox cbdongy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInphieu(string makp,string _nhomkho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_makp=makp;s_nhomkho=_nhomkho;
            i_userid = _userid;
            if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmInphieu(string makp, string _nhomkho, int _nhom, int _loai, int _phieu, int _makp, string _ngay, string _mmyy, int _userid)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_makp = makp; s_nhomkho = _nhomkho; i_nhom = _nhom; i_loais = _loai; i_phieu = _phieu; i_makp = _makp; s_ngay = _ngay; s_mmyy = _mmyy;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            i_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInphieu));
            this.phieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.xuatcstt = new System.Windows.Forms.CheckBox();
            this.manguon = new System.Windows.Forms.CheckedListBox();
            this.haophicstt = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.xem = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nguoilinh = new System.Windows.Forms.TextBox();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.p = new System.Windows.Forms.Panel();
            this.ckNhomIn = new System.Windows.Forms.CheckedListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbdongy = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            this.SuspendLayout();
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(54, 122);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(210, 21);
            this.phieu.TabIndex = 9;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Phiếu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(54, 76);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(210, 21);
            this.makp.TabIndex = 7;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(155, 293);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 15;
            this.butOk.Text = "    &In";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(226, 293);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 16;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-2, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(54, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(153, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "đến :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(184, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.CheckOnClick = true;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(54, 214);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(210, 68);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-10, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Đối tượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(54, 53);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(210, 21);
            this.nhom.TabIndex = 6;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nhóm :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Loại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(54, 99);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(210, 21);
            this.loai.TabIndex = 8;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // xuatcstt
            // 
            this.xuatcstt.Location = new System.Drawing.Point(272, 214);
            this.xuatcstt.Name = "xuatcstt";
            this.xuatcstt.Size = new System.Drawing.Size(114, 18);
            this.xuatcstt.TabIndex = 13;
            this.xuatcstt.Text = "Phiếu xuất tủ trực";
            this.xuatcstt.CheckedChanged += new System.EventHandler(this.xuatcstt_CheckedChanged);
            this.xuatcstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // manguon
            // 
            this.manguon.CheckOnClick = true;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(266, 8);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(176, 68);
            this.manguon.TabIndex = 20;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // haophicstt
            // 
            this.haophicstt.Location = new System.Drawing.Point(272, 230);
            this.haophicstt.Name = "haophicstt";
            this.haophicstt.Size = new System.Drawing.Size(208, 21);
            this.haophicstt.TabIndex = 14;
            this.haophicstt.Text = "Bù cơ số tủ trực";
            this.haophicstt.CheckedChanged += new System.EventHandler(this.haophicstt_CheckedChanged);
            this.haophicstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(150, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "năm :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(184, 30);
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(80, 21);
            this.yyyy.TabIndex = 5;
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(54, 30);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(80, 21);
            this.mm.TabIndex = 4;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 24);
            this.label10.TabIndex = 23;
            this.label10.Text = "Số liệu :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xem
            // 
            this.xem.Location = new System.Drawing.Point(272, 246);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(104, 24);
            this.xem.TabIndex = 25;
            this.xem.Text = "Xem trước khi in";
            this.xem.CheckedChanged += new System.EventHandler(this.xem_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(264, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Người lĩnh :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nguoilinh
            // 
            this.nguoilinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoilinh.Location = new System.Drawing.Point(328, 190);
            this.nguoilinh.Name = "nguoilinh";
            this.nguoilinh.Size = new System.Drawing.Size(114, 21);
            this.nguoilinh.TabIndex = 12;
            this.nguoilinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoilinh_KeyDown);
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(328, 270);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(40, 21);
            this.banin.TabIndex = 28;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(264, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "Số bản in :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(54, 144);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(210, 68);
            this.kho.TabIndex = 10;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // p
            // 
            this.p.AutoScroll = true;
            this.p.Location = new System.Drawing.Point(54, 322);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(388, 75);
            this.p.TabIndex = 29;
            // 
            // ckNhomIn
            // 
            this.ckNhomIn.CheckOnClick = true;
            this.ckNhomIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNhomIn.Location = new System.Drawing.Point(270, 117);
            this.ckNhomIn.Name = "ckNhomIn";
            this.ckNhomIn.Size = new System.Drawing.Size(172, 68);
            this.ckNhomIn.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(269, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 30;
            this.label13.Text = "Nhóm in :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbdongy
            // 
            this.cbdongy.AutoSize = true;
            this.cbdongy.Location = new System.Drawing.Point(302, 299);
            this.cbdongy.Name = "cbdongy";
            this.cbdongy.Size = new System.Drawing.Size(89, 17);
            this.cbdongy.TabIndex = 32;
            this.cbdongy.Text = "Phiếu đông y";
            this.cbdongy.UseVisualStyleBackColor = true;
            // 
            // frmInphieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(450, 403);
            this.Controls.Add(this.cbdongy);
            this.Controls.Add(this.ckNhomIn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.p);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.nguoilinh);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.haophicstt);
            this.Controls.Add(this.xuatcstt);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInphieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In phiếu";
            this.Load += new System.EventHandler(this.frmInphieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInphieu_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			xem.Checked=d.bPreview;
            bChuky = m.bChuky;
			banin.Enabled=!xem.Checked;         

            sql = "select mmyy from " + user + ".table ";
            sql += " order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
            dt = d.get_data(sql).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                s_mmyy = r["mmyy"].ToString();
                if (d.get_data("select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
            }
            decimal yy = decimal.Parse("20" + s_mmyy.Substring(2, 2));
            mm.Value = decimal.Parse(s_mmyy.Substring(0, 2));
            yyyy.Minimum = yy - 3; yyyy.Maximum = yy + 3;
            yyyy.Value = yy;

            dtbs = d.get_data("select * from " + user + ".dmbs where nhom=" + LibMedi.AccessData.truongkhoa).Tables[0];

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

            sql = "select * from " + user + ".d_dmnhomkho ";
			if (s_nhomkho!="") sql+=" where id in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")";
			sql+=" order by stt";
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			nhom.DataSource=d.get_data(sql).Tables[0];
			i_nhom=int.Parse(nhom.SelectedValue.ToString());
            i_songay = d.Ngay_in_phieu(i_nhom);
            bInphieu_ngay = d.bInphieu_ngay(i_nhom);
            if (!bInphieu_ngay)
            {
                this.ClientSize = new System.Drawing.Size(456, 350);
                p.Visible = false;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(456, 428);
                p.Visible = true;
            }
			load_makp();

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			load_loai();

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			load_phieu();

			i_makp=int.Parse(makp.SelectedValue.ToString());

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			load_nguon();

            dtdt = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DataSource=dtdt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";

            //khuyen 10/01/2014

            dtnhomin = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];
            ckNhomIn.DataSource = dtnhomin;
            ckNhomIn.DisplayMember = "TEN";
            ckNhomIn.ValueMember = "ID";
            //

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			load_makho();
            if (s_ngay != "")
            {
                nhom.SelectedValue = i_nhom.ToString();
                makp.SelectedValue = i_makp.ToString();
                loai.SelectedValue = i_loais.ToString();
                load_phieu();
                phieu.SelectedValue = i_phieu.ToString();
                mm.Value = decimal.Parse(s_mmyy.Substring(0, 2));
                yyyy.Value = decimal.Parse("20" + s_mmyy.Substring(2, 2));
                tu.Value = new DateTime(int.Parse(s_ngay.Substring(6, 4)), int.Parse(s_ngay.Substring(3, 2)), int.Parse(s_ngay.Substring(0, 2)));
                den.Value = tu.Value;
            }
		}

		private void load_phieu()
		{
			try
			{
				xuatcstt.Checked=false;
				haophicstt.Checked=false;
				i_loai=int.Parse(loai.SelectedValue.ToString());
				sql="select * from "+user+".d_loaiphieu where nhom="+int.Parse(nhom.SelectedValue.ToString())+" and loai="+i_loai+" order by stt";
				if (i_loai==3) sql="select * from "+user+".d_loaiphieu where (id=0) or (nhom="+int.Parse(nhom.SelectedValue.ToString())+" and loai="+i_loai+") order by stt";
				dtphieu=d.get_data(sql).Tables[0];
				phieu.DataSource=dtphieu;
				xuatcstt.Enabled=i_loai==2 || i_loai==4;
				haophicstt.Enabled=i_loai==4;
			}
			catch{}
		}

		private void load_loai()
		{
			try
			{
				i_nhom=int.Parse(nhom.SelectedValue.ToString());
				loai.DataSource=d.get_data("select * from "+user+".d_dmphieu where id not in (5,6) order by stt").Tables[0];
				i_loai=int.Parse(loai.SelectedValue.ToString());
			}
			catch{}
		}

		private void load_makho()
		{
			try
			{
				s_makho="";
                sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
				DataRow r=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null) s_makho=r["makho"].ToString();
				if (s_makho=="") s_makho=d.get_data("select kho from "+user+".d_dmphieu where id="+i_loai).Tables[0].Rows[0][0].ToString();
				if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				sql+=" order by stt";
				dtkho=d.get_data(sql).Tables[0];
				kho.DataSource=dtkho;
                kho.DisplayMember = "TEN";
                kho.ValueMember = "ID";
				nguoilinh.Text=r["nguoilinh"].ToString();
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phieu.SelectedIndex==-1) phieu.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (m.songay(m.StringToDate(den.Text),m.StringToDate(tu.Text),1)>i_songay)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số ngày in phiếu (")+i_songay.ToString()+")",LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
			if (makp.SelectedIndex==-1 || phieu.SelectedIndex==-1)
			{
				if (makp.SelectedIndex==-1) makp.Focus();
				else phieu.Focus();
				return;
			}
			s_makho="";s_tenkho="";
			if (kho.CheckedItems.Count==0)
				for(int i=0;i<kho.Items.Count;i++) s_makho+=dtkho.Rows[i]["id"].ToString()+",";
			else
			{
				for(int i=0;i<kho.Items.Count;i++)
				{
					if (kho.GetItemChecked(i))
					{
						s_makho+=dtkho.Rows[i]["id"].ToString()+",";
						s_tenkho+=dtkho.Rows[i]["ten"].ToString()+";";
					}
				}
			}
            string cont = "", tuden = "";
            if (tu.Text != den.Text && bInphieu_ngay)
            {
                foreach (Control c in this.p.Controls)
                {
                    if (c.Name.ToString() == "ng")
                    {
                        cont += "(to_char(a.ngay,'dd/mm/yyyy')='" + c.Text + "'";
                        tuden += c.Text;
                    }
                    if (c.Name.ToString() == "ph")
                    {
                        ComboBox cb = (ComboBox)c;
                        if (cb.SelectedIndex != -1)
                        {
                            cont += " and a.phieu=" + int.Parse(cb.SelectedValue.ToString());
                            tuden += " " + cb.Text.Trim();
                        }
                        cont += ") or ";
                        tuden += ";";
                    }
                }
            }
            bLinh_dongia = d.bPhieulinh_dongia(int.Parse(nhom.SelectedValue.ToString())) || d.bPhieulinh_dongia_losx_date(int.Parse(nhom.SelectedValue.ToString()));
            if (cont != "") cont = cont.Substring(0, cont.Length - 4);
			sql="select a.makp, a.phieu, a.loai, a.ngay, a.nhom, a.done, a.duyettreole, a.makho, a.userid from xxx.d_daduyet a where a.nhom="+int.Parse(nhom.SelectedValue.ToString());
            if (cont != "") sql += " and (" + cont + ")";
			else sql+=" and a.phieu="+int.Parse(phieu.SelectedValue.ToString())+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
			sql+=" and a.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			ds=new DataSet();
			dsxml=new DataSet();
			ds.ReadXml("..//..//..//xml//d_inphieu.xml");
			dsxml.ReadXml("..//..//..//xml//d_inphieu.xml");
            if (bChuky)
            {
                DataColumn dc = new DataColumn("image_duoc", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
                dc = new DataColumn("image_dieutri", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
            }
            dsxml.Tables[0].Columns.Add("chandoan");
            dsxml.Tables[0].Columns.Add("maicd");
            dsxml.Tables[0].Columns.Add("ngayduyet");
            try
            {
                dsxml.Tables[0].Columns.Add("NGUOIDUYET");
            }
            catch { }
            try//gam 12/12/2011
            {
                ds.Tables[0].Columns.Add("MANHOM1");
                dsxml.Tables[0].Columns.Add("MANHOM1");
                ds.Tables[0].Columns.Add("TENNHOM1");
                dsxml.Tables[0].Columns.Add("TENNHOM1");
                ds.Tables[0].Columns.Add("giaban");
                dsxml.Tables[0].Columns.Add("giaban");
            }
            catch { }

            ds.Tables[0].Columns.Add("mabn");
            dsxml.Tables[0].Columns.Add("mabn");
            //khuyen them 08/01/2014
            try
            {
                ds.Tables[0].Columns.Add("tennguon");
                dsxml.Tables[0].Columns.Add("tennguon");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("sothangdongy");
                dsxml.Tables[0].Columns.Add("sothangdongy");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("slmotthang");
                dsxml.Tables[0].Columns.Add("slmotthang");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("sothe");
                dsxml.Tables[0].Columns.Add("sothe");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("giuong");
                dsxml.Tables[0].Columns.Add("giuong");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("doituong");
                dsxml.Tables[0].Columns.Add("doituong");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("sonha");
                dsxml.Tables[0].Columns.Add("sonha");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("thon");
                dsxml.Tables[0].Columns.Add("thon");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tenpxa");
                dsxml.Tables[0].Columns.Add("tenpxa");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tenquan");
                dsxml.Tables[0].Columns.Add("tenquan");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tentt");
                dsxml.Tables[0].Columns.Add("tentt");
            }
            catch { }
            //11/03/14
            try
            {
                ds.Tables[0].Columns.Add("tungay");
                dsxml.Tables[0].Columns.Add("tungay");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("denngay");
                dsxml.Tables[0].Columns.Add("denngay");
            }
            catch { }
            //
			i_makp=int.Parse(makp.SelectedValue.ToString());
			i_phieu=int.Parse(phieu.SelectedValue.ToString());
			i_nhom=int.Parse(nhom.SelectedValue.ToString());
			i_loai=int.Parse(loai.SelectedValue.ToString());
			bBuhaophi=i_loai==4 && haophicstt.Checked;
			bNhomin_mabd=d.bNhomin_mabd(i_nhom);
			bInngang=d.bPhieulinh_ngang(i_nhom);
			bDoituong_phieulinh=d.bDoituong_Phieulinh(i_nhom);
            bNgayylenh_phieulinh = d.bNgayylenh_phieulinh(i_nhom);
			if (bDoituong_phieulinh)
			{
				foreach(DataRow r in dtdt.Rows)
				{
					dc=new DataColumn();
					dc.ColumnName="c_"+r["madoituong"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
					dc=new DataColumn();
					dc.ColumnName="c_"+r["madoituong"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					dsxml.Tables[0].Columns.Add(dc);
				}
			}
			s_doc="";
			if (d.bHoten_docGN(i_nhom)!=0) s_doc+=d.bHoten_docGN(i_nhom).ToString()+",";
			if (d.bHoten_docHTT(i_nhom)!=0) s_doc+=d.bHoten_docHTT(i_nhom).ToString()+",";
			if (d.bHoten_docAB(i_nhom)!=0) s_doc+=d.bHoten_docAB(i_nhom).ToString()+",";
			s_doc=(s_doc!="")?s_doc.Substring(0,s_doc.Length-1):"";
			if (bBuhaophi)
			{
                file1 = "d_haophill"; file2 = "d_haophict"; tieude = "PHIẾU LĨNH";
			}
			else
			{
				switch (i_loai)
				{
                    case 1: file1 = "d_dutrull"; file2 = "d_dutruct"; tieude = "PHIẾU LĨNH";
						break;
                    case 2: file1 = "d_xtutrucll"; file2 = "d_xtutrucct"; tieude = "PHIẾU BÙ";
						break;
                    case 3: file1 = "d_hoantrall"; file2 = "d_hoantract"; tieude = "PHIẾU HOÀN TRẢ";
						break;
                    default: file1 = "d_haophill"; file2 = "d_haophict"; tieude = "PHIẾU LĨNH";
						break;
				}
			}
            //sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,c.ten as tennhom,c.stt as manhom,"+
            //    "c.stt,d.ten as tenhang,e.ten as tennhom1,e.stt as manhom1 from " + user + ".d_dmbd a," + user + ".d_dmnhom b," + user + ".d_dmnhom e," + 
            //    user + ".d_nhomin c," + user + ".d_dmhang d";
            //sql+=" where a.manhom=b.id ";
            //if (bNhomin_mabd)
            //    sql+=" and a.nhomin=c.id ";
            //else
            //    sql+=" and b.nhomin=c.id ";
            //if (bNhomin_mabd) sql += " and b.nhomin=e.id ";//gam 12/12/2011
            //else sql += " and a.nhomin=e.id ";
            //sql+=" and a.mahang=d.id and a.nhom="+i_nhom;

            if (bNhomin_mabd)//Thuy 26.12.2011 
            {
                sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,c.ten as tennhom,c.stt as manhom,";
                sql += "c.stt,d.ten as tenhang,e.ten as tennhom1,e.stt as manhom1 ";
                sql += "from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".d_dmnhom e on b.nhomin=e.id left join ";
                sql += user + ".d_nhomin c on a.nhomin=c.id inner join " + user + ".d_dmhang d on a.mahang=d.id where a.nhom=" + i_nhom;
            }
            else
            {
                sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,c.ten as tennhom,c.stt as manhom,";
                sql += "c.stt,d.ten as tenhang,e.ten as tennhom1,e.stt as manhom1 from " + user + ".d_dmbd a left join " + user + ".d_dmnhom b on a.manhom=b.id ";
                sql += "left join " + user + ".d_nhomin e on a.nhomin=e.id inner join ";
                sql += "" + user + ".d_nhomin c on b.nhomin=c.id inner join " + user + ".d_dmhang d on a.mahang=d.id where a.nhom=" + i_nhom;
            }//end Thuy 26.12.2011
			dt=d.get_data(sql).Tables[0];
			s_madt="";s_tendt="";
            s_manguon = ""; s_tennguon = ""; s_nhomin = ""; s_tennhomin = "";


            //khuyen 10/01/14
            if (ckNhomIn.CheckedItems.Count == 0)
                for (int i = 0; i < ckNhomIn.Items.Count; i++) s_nhomin += dtnhomin.Rows[i]["id"].ToString() + ",";
            else
            {
                for (int i = 0; i < ckNhomIn.Items.Count; i++)
                {
                    if (ckNhomIn.GetItemChecked(i))
                    {
                        s_nhomin += dtnhomin.Rows[i]["id"].ToString() + ",";
                        s_tennhomin += dtnhomin.Rows[i]["ten"].ToString() + ";";
                    }
                }
            }
            //
			if (madoituong.CheckedItems.Count==0)
				for(int i=0;i<madoituong.Items.Count;i++) s_madt+=dtdt.Rows[i]["madoituong"].ToString()+",";
			else
			{
				for(int i=0;i<madoituong.Items.Count;i++)
				{
					if (madoituong.GetItemChecked(i))
					{
						s_madt+=dtdt.Rows[i]["madoituong"].ToString()+",";
						s_tendt+=dtdt.Rows[i]["doituong"].ToString()+";";
					}
				}
			}
			if (manguon.CheckedItems.Count==0)
				for(int i=0;i<manguon.Items.Count;i++) s_manguon+=dtnguon.Rows[i]["id"].ToString().Trim()+",";
			else
			{
				for(int i=0;i<manguon.Items.Count;i++)
				{
					if (manguon.GetItemChecked(i))
					{
						s_manguon+=dtnguon.Rows[i]["id"].ToString().Trim()+",";
						s_tennguon+=dtnguon.Rows[i]["ten"].ToString()+";";
					}
				}
			}
			s_idduyet="";
            s_ngayylenhduyet = "";
            string s_idstt = "", s_id = "a.id in (";//gam 05/2011 them biến s_id
            sql = "select a.idduyet,a.sttduyet from xxx.d_ngayduyet a where a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.makp=" + i_makp;
            if (cont != "") sql += " and (" + cont + ")";
            else sql+=" and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ") and a.phieu=" + i_phieu;
			foreach(DataRow r in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
                /*
				s_idduyet+="(a.id="+decimal.Parse(r["idduyet"].ToString());
				if (r["sttduyet"].ToString()!="")
					s_idduyet+=" and b.sttduyet in ("+r["sttduyet"].ToString().Trim().Substring(0,r["sttduyet"].ToString().Trim().Length-1)+")";
				s_idduyet+=") or ";

				s_idstt+="(a.id="+decimal.Parse(r["idduyet"].ToString());
				if (r["sttduyet"].ToString()!="")
					s_idstt+=" and b.stt in ("+r["sttduyet"].ToString().Trim().Substring(0,r["sttduyet"].ToString().Trim().Length-1)+")";
				s_idstt+=") or ";
                 * */
                s_idduyet += "(a.id=" + decimal.Parse(r["idduyet"].ToString());
                if (r["sttduyet"].ToString() != "")
                    s_idduyet += " and b.sttduyet in (" + r["sttduyet"].ToString().Trim().Substring(0, r["sttduyet"].ToString().Trim().Length - 1) + ")";
                s_idduyet += ") or ";

                if (r["sttduyet"].ToString() != "")
                {
                    s_id += (r["idduyet"].ToString() + ",");//gam 05/2011
                    s_idstt += "(a.id=" + decimal.Parse(r["idduyet"].ToString());
                    s_idstt += " and b.stt in (" + r["sttduyet"].ToString().Trim().Substring(0, r["sttduyet"].ToString().Trim().Length - 1) + ")";
                    s_idstt += ") or ";
                }
			}
			if (s_idduyet=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
            sql = "select to_char(min(ngayylenh),'dd/mm/yyyy') as ngayylenh from xxx.d_xuatsdll a where a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.makp=" + i_makp;
            if (cont != "") sql += " and (" + cont + ")";
            else sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ") and a.phieu=" + i_phieu;
            foreach (DataRow r in d.get_thuoc(tu.Text, den.Text, sql).Tables[0].Rows)
            {
                if(r["ngayylenh"].ToString()!="")s_ngayylenhduyet = r["ngayylenh"].ToString();
            }
			if (s_idstt!="") s_idstt=s_idstt.Substring(0,s_idstt.Length-4);
			if (s_idduyet!="") s_idduyet=s_idduyet.Substring(0,s_idduyet.Length-4);
            if (s_id != "") { s_id = s_id.Substring(0, s_id.Length - 1); s_id += ")"; }//gam 05/2011
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
            if (d.bSLYeucau(i_nhom))
            {
                if (s_ngayylenhduyet.Trim() == "") s_ngayylenhduyet = tu.Text;
                /* khuyen khoa 11/01/14 ds = d.get_slyeucau(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc,i_nhom,s_ngayylenhduyet,s_id);//gam 05/09/2011
                 if (s_doc != "") tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc).Tables[0];
                 */
                //khuyen 11/01/14 them tham so s_nhomin
                ds = d.get_slyeucau(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc, i_nhom, s_ngayylenhduyet, s_id, s_nhomin);//gam 05/09/2011
                 if (s_doc != "")
                    if (s_nhomin == "") tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc).Tables[0];
                    else tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_nhomin.Substring(0, s_nhomin.Length - 1)).Tables[0];
                //
            }
			if (xuatcstt.Checked)
			{
				tieude="PHIẾU XUẤT TỦ TRỰC";
				bBuhaophi=(i_loai==4 || i_loai==2);
				if (bLinh_dongia)
					ds=d.get_xuatcstt_dongia(s_mmyy,ds,dt,dtkho,s_idduyet,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,dtdt,bDoituong_phieulinh,i_nhom);
				else
					ds=d.get_xuatcstt(s_mmyy,ds,dt,dtkho,s_idduyet,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,dtdt,bDoituong_phieulinh);
			}
			else
			{
				if (bBuhaophi)
				{
					i_loai=2;
					tieude="PHIẾU BÙ";
				}
				if (bLinh_dongia)

					
                    //khuyen khoa 11/01/2014 ds = d.get_slxuat_dongia(ds, dt, dtkho, tu.Text, den.Text, s_mmyy, i_nhom, i_loai, i_phieu, i_makp, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, cont,s_nhomin);
                   // khuyen 11/01/2014 them tham so s_nhomin
                    ds = d.get_slxuat_dongia(ds, dt, dtkho, tu.Text, den.Text, s_mmyy, i_nhom, i_loai, i_phieu, i_makp, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, cont, s_nhomin);
                    //
				else
					ds=d.get_slxuat(ds,dt,dtkho,tu.Text,den.Text,s_mmyy,i_nhom,i_loai,i_phieu,i_makp,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,dtdt,bDoituong_phieulinh,cont);
			}
			if (ds.Tables[0].Rows.Count==0 && s_doc=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			if (bLinh_dongia)
				d.sort_inphieu_dongia(dsxml,ds,d.bSLYeucau(i_nhom),s_mmyy,tu.Text,i_nhom,i_makp,i_loai,i_phieu,s_makho,s_madt,s_manguon,nguoilinh.Text,dtdt,bDoituong_phieulinh,(xuatcstt.Checked)?false:(i_loai==2)?true:bBuhaophi);
			else
				d.sort_inphieu(dsxml,ds,d.bSLYeucau(i_nhom),s_mmyy,tu.Text,i_nhom,i_makp,i_loai,i_phieu,s_makho,s_madt,s_manguon,nguoilinh.Text,dtdt,bDoituong_phieulinh,(xuatcstt.Checked)?false:(i_loai==2)?true:bBuhaophi);
            string ngayylenh = "";
            if (bNgayylenh_phieulinh) ngayylenh = d.get_ngayylenh(tu.Text, den.Text, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc, false);
            if (ngayylenh != "") foreach (DataRow r in dsxml.Tables[0].Rows) r["ngayylenh"] = ngayylenh;
            bool bDuoc = false, bDieutri = false;
            if (bChuky)
            {
                DataRow r1 = m.getrowbyid(dtbs, "makp='" + dtkp.Rows[makp.SelectedIndex]["makp"].ToString() + "'");
                if (r1 != null)
                {
                    string truongkhoa = r1["ma"].ToString().Trim();
                    if (File.Exists("..//..//..//chuky//" + truongkhoa + ".bmp"))
                    {
                        fstr = new FileStream("..//..//..//chuky//" + truongkhoa + ".bmp", FileMode.Open, FileAccess.Read);
                        image_dieutri = new byte[fstr.Length];
                        fstr.Read(image_dieutri, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        bDieutri = true;
                    }
                }
                string truongkho = "kho" + nhom.SelectedValue.ToString();
                if (File.Exists("..//..//..//chuky//" + truongkho + ".bmp"))
                {
                    fstr = new FileStream("..//..//..//chuky//" + truongkho + ".bmp", FileMode.Open, FileAccess.Read);
                    image_duoc = new byte[fstr.Length];
                    fstr.Read(image_duoc, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    bDuoc = true;
                }
                foreach (DataRow r in dsxml.Tables[0].Rows)
                {
                    if (bDuoc) r["Image_duoc"] = image_duoc;
                    if (bDieutri) r["Image_dieutri"] = image_dieutri;
                }
            }
			if (bDoituong_phieulinh)
			{
				tenfile=(bLinh_dongia)?"d_phieulanh_yc_dt_dg":"d_phieulanh_yc_dt";
				tenfile=(m.Mabv_so==701424)?"d_phieulanh_dt_dg":tenfile;
			}
			else if (bInngang) tenfile="d_phieulanh_ng";
			else
			{
				tenfile=(d.bSLYeucau(i_nhom))?"d_phieulanh_yc":"d_phieulanh";
				tenfile+=(bLinh_dongia)?"_dg":"";
			}

            if (m.bAdminHethong(i_userid) == false && dsxml.Tables[0].Rows.Count > 0)
            {
                try
                {
                    int isolanintoida = d.solaninphieulinh(i_nhom);
                    if (int.Parse(dsxml.Tables[0].Rows[0]["lanin"].ToString()) > isolanintoida)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số lần in vượt quá số lần cho phép là :" + isolanintoida.ToString() + "."), lan.Change_language_MessageText("In phiếu"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch { }
            }
			if (xem.Checked)
			{
                //khuyen khoa 01/01/14
                //dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml.Tables[0], tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, den.Text, "");
                //f.ShowDialog(this);
                //khuyen 09/01/14
                if (dsxml.Tables[0].Rows.Count > 0 )
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml.Tables[0], tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, den.Text, "");
                    f.ShowDialog(this);
                }
                //
			}
            else prn.Printer(m, dsxml.Tables[0], tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, den.Text, "", (bInngang) ? 2 : 1, Convert.ToInt16(banin.Value));

			if (s_doc!="")
			{
				dsxml=d.get_slxuat_doc(dsxml,tu.Text,den.Text,s_mmyy,i_nhom,i_loai,i_phieu,i_makp,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,nguoilinh.Text,cont,tmpyc);
				if(dsxml.Tables[0].Rows.Count<=0)return;
                ngayylenh = "";
                if (bNgayylenh_phieulinh) ngayylenh = d.get_ngayylenh(tu.Text, den.Text, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc,true);
                if (ngayylenh != "") foreach (DataRow r in dsxml.Tables[0].Rows) r["ngayylenh"] = ngayylenh;
                if (bChuky)
                {
                    foreach (DataRow r in dsxml.Tables[0].Rows)
                    {
                        if (bDuoc) r["Image_duoc"] = image_duoc;
                        if (bDieutri) r["Image_dieutri"] = image_dieutri;
                    }
                }
  
                //khuyen 08/01/14
               dsxml.WriteXml("..//..//dataxml//d_inphieudongy.xml", XmlWriteMode.WriteSchema);
                //
               //khuyen khoa 13/01/14 tenfile = "d_pldoc.rpt";
               //khuyen 13/01/14
               if (s_doc == "3" && cbdongy.Checked)
               {
                   tenfile = "d_pldoc1.rpt";
               }
               else
               {
                   tenfile = "d_pldoc.rpt";
               }
               //
				if (xem.Checked)
				{
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml.Tables[0], tenfile, makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, den.Text, "");
					f.ShowDialog(this);
				}
                else prn.Printer(m, dsxml.Tables[0], tenfile, makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, den.Text, "", 1, Convert.ToInt16(banin.Value));
			}
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp) load_makho();
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nhom)
			{
				i_nhom=int.Parse(nhom.SelectedValue.ToString());
                i_songay = d.Ngay_in_phieu(i_nhom);
                bInphieu_ngay = d.bInphieu_ngay(i_nhom);
                if (!bInphieu_ngay)
                {
                    this.ClientSize = new System.Drawing.Size(456, 350);
                    p.Visible = false;
                }
                else
                {
                    this.ClientSize = new System.Drawing.Size(456, 428);
                    p.Visible = true;
                }
				load_makp();
				load_loai();
				load_phieu();
				load_makho();
				load_nguon();
			}
		}
		
		private void load_makp()
		{
			sql="select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];
			makp.DataSource=dtkp;
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhom.SelectedIndex==-1) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}	

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1 && loai.Items.Count>0) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai) 
			{
				load_phieu();		
				load_makho();
                p.Controls.Clear();
                if (tu.Text!=den.Text && bInphieu_ngay) load_control();
			}
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (kho.SelectedIndex==-1 && kho.Items.Count>0) kho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (i_songay==1) den.Value=tu.Value;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
            p.Controls.Clear();
            if (i_songay == 1) tu.Value = den.Value;
            else if (tu.Text != den.Text && bInphieu_ngay) load_control();
		}

		private void xuatcstt_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==xuatcstt && haophicstt.Enabled) haophicstt.Checked=!xuatcstt.Checked;
		}

		private void haophicstt_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==haophicstt) xuatcstt.Checked=!haophicstt.Checked;
		}

		private void load_nguon()
		{
			if (d.bQuanlynguon(i_nhom))
				dtnguon=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by id").Tables[0];
			else
				dtnguon=d.get_data("select * from "+user+".d_dmnguon where id=0 or nhom="+i_nhom+" order by id").Tables[0];
			manguon.DataSource=dtnguon;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
		}

		private void nguoilinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void xem_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==xem) banin.Enabled=!xem.Checked;
		}

        private void load_control()
        {
            p.Controls.Clear();
            DateTimePicker dt;
            ComboBox cb;
            int t = 0;
            for (int i = 0; i <= d.songay(d.StringToDate(den.Text), d.StringToDate(tu.Text), 0); i++)
            {
                dt = new DateTimePicker();
                dt.Name = "ng"; dt.Left = 0; dt.Top = t; dt.Size = new System.Drawing.Size(80, 21);
                dt.CustomFormat = "dd/MM/yyyy";
                dt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
                dt.Value = d.StringToDate(tu.Text).AddDays(i);
                cb = new ComboBox();
                cb.Name = "ph"; cb.Left = 82; cb.Top = t; cb.Size = new System.Drawing.Size(300, 21);
                cb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                cb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
                cb.DisplayMember = "TEN";
                cb.ValueMember = "ID";
                cb.DataSource = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString()) + " and loai=" + int.Parse(loai.SelectedValue.ToString()) + " order by stt").Tables[0];
                cb.SelectedIndex = -1;
                p.Controls.Add(dt);
                p.Controls.Add(cb);
                t += 23;
            }
        }

        private void f_capnhat_db()
        {
            sql = "select lanin_m from " + user + ".d_sophieu where 1=2 ";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".d_sophieu add lanin_m numeric(3) default 0";
                m.execute_data(sql);
            }
            sql = "select lanin_m from " + user + s_mmyy + ".d_sophieu where 1=2 ";
            lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + s_mmyy + ".d_sophieu add lanin_m numeric(3) default 0";
                m.execute_data(sql);
            }
        }
        private void f_capnhat_db(string d_tu, string d_den)
        {
            sql = "alter table xxx.d_sophieu add lanin_m numeric(3) default 0";
            m.execute_data_mmyy(sql,d_tu,d_den,true);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //f_capnhat_db(tu.Text, den.Text);
        }
	}
}
