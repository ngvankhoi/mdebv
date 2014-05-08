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
	/// Summary description for frmTTSankhoa.
	/// </summary>
	public class frmTTSankhoa : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox have;
		private System.Windows.Forms.ComboBox tinhtrangoi;
		private System.Windows.Forms.ComboBox oivo;
		private System.Windows.Forms.ComboBox dolot;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.TextBox kieu;
		private System.Windows.Forms.TextBox the;
		private System.Windows.Forms.TextBox ngoi;
		private System.Windows.Forms.TextBox nuocoi;
		private System.Windows.Forms.TextBox mausac;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label124;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.Label label121;
		private MaskedBox.MaskedBox giovo;
		private MaskedBox.MaskedBox ngayvo;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
		private System.Windows.Forms.TextBox phanphu;
		private System.Windows.Forms.TextBox tucung;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label117;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.TextBox sinhmon;
		private System.Windows.Forms.TextBox amdao;
		private System.Windows.Forms.TextBox amho;
		private System.Windows.Forms.Label label115;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.Label label104;
		private MaskedTextBox.MaskedTextBox bishop;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Button butTresosinh;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.TextBox chucdanh;
		private MaskedBox.MaskedBox ngayde;
		private System.Windows.Forms.TextBox tentheodoi;
		private MaskedTextBox.MaskedTextBox theodoi;
		private LibList.List listNv1;
		private System.Windows.Forms.Label label134;
		private System.Windows.Forms.Label label133;
		private MaskedBox.MaskedBox giode;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.ComboBox cotucung;
		private System.Windows.Forms.Label label161;
		private System.Windows.Forms.TextBox loaichi;
		private MaskedTextBox.MaskedTextBox somui;
		private System.Windows.Forms.ComboBox tangsinhmon;
		private System.Windows.Forms.Label label160;
		private System.Windows.Forms.Label label159;
		private System.Windows.Forms.Label label154;
		private System.Windows.Forms.ComboBox ppde;
		private System.Windows.Forms.TextBox canthiep;
		private System.Windows.Forms.Label label153;
		private System.Windows.Forms.Panel panel3;
		private MaskedBox.MaskedBox sd_nhietdo;
		private MaskedBox.MaskedBox sd_huyetap;
		private MaskedTextBox.MaskedTextBox sd_nhiptho;
		private MaskedTextBox.MaskedTextBox sd_mach;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.Label label148;
		private System.Windows.Forms.TextBox da;
		private System.Windows.Forms.Label label147;
		private System.Windows.Forms.Label label146;
		private System.Windows.Forms.TextBox xuly;
		private System.Windows.Forms.Label label145;
		private System.Windows.Forms.CheckBox kiemsoattc;
		private System.Windows.Forms.Label label144;
		private MaskedTextBox.MaskedTextBox maumat;
		private System.Windows.Forms.Label label143;
		private System.Windows.Forms.CheckBox chaymau;
		private System.Windows.Forms.Label label142;
		private MaskedTextBox.MaskedTextBox raudai;
		private System.Windows.Forms.Label label141;
		private System.Windows.Forms.TextBox banhrau;
		private System.Windows.Forms.TextBox mui;
		private System.Windows.Forms.TextBox mang;
		private System.Windows.Forms.TextBox cachso;
		private MaskedTextBox.MaskedTextBox raucannang;
		private System.Windows.Forms.CheckBox raucuon;
		private System.Windows.Forms.Label label140;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.Label label138;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label136;
		private MaskedBox.MaskedBox ngayrau;
		private MaskedBox.MaskedBox giorau;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label135;
		private System.Windows.Forms.ComboBox rau;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private DataSet ds=new DataSet();
		private DataSet dstress=new DataSet();
		private DataTable dtnv=new DataTable();
		private AccessData m;
		private decimal l_id,l_maql,l_iddieutri;
		private int i_userid;
		private string sql,ngay,xxx,s_sovaovien,s_hoten,s_phai,s_tenkp,s_phong,s_giuong,s_chandoan;
		public bool bUpdate=false;
		private bool bAdmin;
		private System.Windows.Forms.Label label168;
		private MaskedBox.MaskedBox ngaysaude;
		private MaskedBox.MaskedBox giosaude;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTTSankhoa(AccessData acc,DataSet _ds,decimal _id,decimal _maql,string _ngay,int _userid,decimal _iddieutri,bool _admin,string _sovaovien,string _hoten,string _phai,string _tenkp,string _phong,string _giuong,string _chandoan)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;ds=_ds;l_id=_id;l_maql=_maql;ngay=_ngay;i_userid=_userid;l_iddieutri=_iddieutri;bAdmin=_admin;
			s_sovaovien=_sovaovien;s_hoten=_hoten;s_phai=_phai;s_tenkp=_tenkp;s_phong=_phong;s_giuong=_giuong;s_chandoan=_chandoan;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTSankhoa));
            this.have = new System.Windows.Forms.TextBox();
            this.tinhtrangoi = new System.Windows.Forms.ComboBox();
            this.oivo = new System.Windows.Forms.ComboBox();
            this.dolot = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.kieu = new System.Windows.Forms.TextBox();
            this.the = new System.Windows.Forms.TextBox();
            this.ngoi = new System.Windows.Forms.TextBox();
            this.nuocoi = new System.Windows.Forms.TextBox();
            this.mausac = new System.Windows.Forms.TextBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.giovo = new MaskedBox.MaskedBox();
            this.ngayvo = new MaskedBox.MaskedBox();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.phanphu = new System.Windows.Forms.TextBox();
            this.tucung = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.sinhmon = new System.Windows.Forms.TextBox();
            this.amdao = new System.Windows.Forms.TextBox();
            this.amho = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.bishop = new MaskedTextBox.MaskedTextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.butTresosinh = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.chucdanh = new System.Windows.Forms.TextBox();
            this.ngayde = new MaskedBox.MaskedBox();
            this.tentheodoi = new System.Windows.Forms.TextBox();
            this.theodoi = new MaskedTextBox.MaskedTextBox();
            this.listNv1 = new LibList.List();
            this.label134 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.giode = new MaskedBox.MaskedBox();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.cotucung = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.loaichi = new System.Windows.Forms.TextBox();
            this.somui = new MaskedTextBox.MaskedTextBox();
            this.tangsinhmon = new System.Windows.Forms.ComboBox();
            this.label160 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.ppde = new System.Windows.Forms.ComboBox();
            this.canthiep = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sd_nhietdo = new MaskedBox.MaskedBox();
            this.sd_huyetap = new MaskedBox.MaskedBox();
            this.sd_nhiptho = new MaskedTextBox.MaskedTextBox();
            this.sd_mach = new MaskedTextBox.MaskedTextBox();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.da = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.xuly = new System.Windows.Forms.TextBox();
            this.label145 = new System.Windows.Forms.Label();
            this.kiemsoattc = new System.Windows.Forms.CheckBox();
            this.label144 = new System.Windows.Forms.Label();
            this.maumat = new MaskedTextBox.MaskedTextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.chaymau = new System.Windows.Forms.CheckBox();
            this.label142 = new System.Windows.Forms.Label();
            this.raudai = new MaskedTextBox.MaskedTextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.banhrau = new System.Windows.Forms.TextBox();
            this.mui = new System.Windows.Forms.TextBox();
            this.mang = new System.Windows.Forms.TextBox();
            this.cachso = new System.Windows.Forms.TextBox();
            this.raucannang = new MaskedTextBox.MaskedTextBox();
            this.raucuon = new System.Windows.Forms.CheckBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.ngayrau = new MaskedBox.MaskedBox();
            this.giorau = new MaskedBox.MaskedBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.rau = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.label168 = new System.Windows.Forms.Label();
            this.ngaysaude = new MaskedBox.MaskedBox();
            this.giosaude = new MaskedBox.MaskedBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // have
            // 
            this.have.BackColor = System.Drawing.SystemColors.HighlightText;
            this.have.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.have.Location = new System.Drawing.Point(624, 114);
            this.have.Name = "have";
            this.have.Size = new System.Drawing.Size(152, 21);
            this.have.TabIndex = 16;
            this.have.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // tinhtrangoi
            // 
            this.tinhtrangoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrangoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrangoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrangoi.Items.AddRange(new object[] {
            "1. Ối phồng",
            "2. Ối dẹt",
            "3. Ối quả lê"});
            this.tinhtrangoi.Location = new System.Drawing.Point(624, 42);
            this.tinhtrangoi.Name = "tinhtrangoi";
            this.tinhtrangoi.Size = new System.Drawing.Size(152, 21);
            this.tinhtrangoi.TabIndex = 6;
            this.tinhtrangoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // oivo
            // 
            this.oivo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.oivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oivo.Items.AddRange(new object[] {
            "1. Tự nhiên",
            "2. Bấm ối"});
            this.oivo.Location = new System.Drawing.Point(356, 66);
            this.oivo.Name = "oivo";
            this.oivo.Size = new System.Drawing.Size(148, 21);
            this.oivo.TabIndex = 9;
            this.oivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // dolot
            // 
            this.dolot.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dolot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dolot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dolot.Items.AddRange(new object[] {
            "1. Cao",
            "2. Chúc",
            "3. Chặt",
            "4. Lọt"});
            this.dolot.Location = new System.Drawing.Point(356, 113);
            this.dolot.Name = "dolot";
            this.dolot.Size = new System.Drawing.Size(148, 21);
            this.dolot.TabIndex = 15;
            this.dolot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label128
            // 
            this.label128.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(500, 116);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(124, 16);
            this.label128.TabIndex = 372;
            this.label128.Text = "Đường kính nhô hạ vệ :";
            this.label128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kieu
            // 
            this.kieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kieu.Location = new System.Drawing.Point(105, 113);
            this.kieu.Name = "kieu";
            this.kieu.Size = new System.Drawing.Size(198, 21);
            this.kieu.TabIndex = 14;
            this.kieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // the
            // 
            this.the.BackColor = System.Drawing.SystemColors.HighlightText;
            this.the.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.the.Location = new System.Drawing.Point(624, 90);
            this.the.Name = "the";
            this.the.Size = new System.Drawing.Size(152, 21);
            this.the.TabIndex = 13;
            this.the.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // ngoi
            // 
            this.ngoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoi.Location = new System.Drawing.Point(356, 90);
            this.ngoi.Name = "ngoi";
            this.ngoi.Size = new System.Drawing.Size(148, 21);
            this.ngoi.TabIndex = 12;
            this.ngoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // nuocoi
            // 
            this.nuocoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nuocoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuocoi.Location = new System.Drawing.Point(105, 90);
            this.nuocoi.Name = "nuocoi";
            this.nuocoi.Size = new System.Drawing.Size(199, 21);
            this.nuocoi.TabIndex = 11;
            this.nuocoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // mausac
            // 
            this.mausac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mausac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mausac.Location = new System.Drawing.Point(624, 66);
            this.mausac.Name = "mausac";
            this.mausac.Size = new System.Drawing.Size(152, 21);
            this.mausac.TabIndex = 10;
            this.mausac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label127
            // 
            this.label127.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(308, 116);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(48, 16);
            this.label127.TabIndex = 371;
            this.label127.Text = "Độ lọt :";
            this.label127.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label126
            // 
            this.label126.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.Location = new System.Drawing.Point(-14, 116);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(120, 16);
            this.label126.TabIndex = 370;
            this.label126.Text = "- Kiểu thế :";
            this.label126.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label125
            // 
            this.label125.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.Location = new System.Drawing.Point(584, 92);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(40, 16);
            this.label125.TabIndex = 369;
            this.label125.Text = "Thế :";
            this.label125.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label124
            // 
            this.label124.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.Location = new System.Drawing.Point(316, 92);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(40, 16);
            this.label124.TabIndex = 368;
            this.label124.Text = "Ngôi :";
            this.label124.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label123
            // 
            this.label123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.Location = new System.Drawing.Point(-14, 92);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(120, 16);
            this.label123.TabIndex = 367;
            this.label123.Text = "- Nước ối nhiều hay ít :";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label122
            // 
            this.label122.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.Location = new System.Drawing.Point(528, 69);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(96, 16);
            this.label122.TabIndex = 366;
            this.label122.Text = "Mầu sắc nước ối :";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label121
            // 
            this.label121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(316, 69);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(40, 16);
            this.label121.TabIndex = 365;
            this.label121.Text = "Ối vỡ :";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovo
            // 
            this.giovo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovo.Location = new System.Drawing.Point(105, 66);
            this.giovo.Mask = "##:##";
            this.giovo.Name = "giovo";
            this.giovo.Size = new System.Drawing.Size(40, 21);
            this.giovo.TabIndex = 7;
            this.giovo.Text = "  :  ";
            this.giovo.Validated += new System.EventHandler(this.giovo_Validated);
            // 
            // ngayvo
            // 
            this.ngayvo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvo.Location = new System.Drawing.Point(233, 66);
            this.ngayvo.Mask = "##/##/####";
            this.ngayvo.Name = "ngayvo";
            this.ngayvo.Size = new System.Drawing.Size(72, 21);
            this.ngayvo.TabIndex = 8;
            this.ngayvo.Text = "  /  /    ";
            this.ngayvo.Validated += new System.EventHandler(this.ngayvo_Validated);
            // 
            // label119
            // 
            this.label119.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(194, 69);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(38, 16);
            this.label119.TabIndex = 364;
            this.label119.Text = "ngày :";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label120
            // 
            this.label120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.Location = new System.Drawing.Point(-14, 69);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(120, 16);
            this.label120.TabIndex = 363;
            this.label120.Text = "- Ối vỡ lúc :";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phanphu
            // 
            this.phanphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanphu.Location = new System.Drawing.Point(233, 42);
            this.phanphu.Name = "phanphu";
            this.phanphu.Size = new System.Drawing.Size(271, 21);
            this.phanphu.TabIndex = 5;
            this.phanphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // tucung
            // 
            this.tucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tucung.Location = new System.Drawing.Point(105, 42);
            this.tucung.Name = "tucung";
            this.tucung.Size = new System.Drawing.Size(64, 21);
            this.tucung.TabIndex = 4;
            this.tucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label118
            // 
            this.label118.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(536, 45);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(88, 16);
            this.label118.TabIndex = 362;
            this.label118.Text = "Tình trạng ối :";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label117
            // 
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(170, 45);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(64, 16);
            this.label117.TabIndex = 361;
            this.label117.Text = "Phần phụ :";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label116
            // 
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(-14, 45);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(120, 16);
            this.label116.TabIndex = 360;
            this.label116.Text = "- Cổ tử cung :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sinhmon
            // 
            this.sinhmon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sinhmon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinhmon.Location = new System.Drawing.Point(624, 18);
            this.sinhmon.Name = "sinhmon";
            this.sinhmon.Size = new System.Drawing.Size(152, 21);
            this.sinhmon.TabIndex = 3;
            this.sinhmon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // amdao
            // 
            this.amdao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.amdao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amdao.Location = new System.Drawing.Point(393, 18);
            this.amdao.Name = "amdao";
            this.amdao.Size = new System.Drawing.Size(111, 21);
            this.amdao.TabIndex = 2;
            this.amdao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // amho
            // 
            this.amho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.amho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amho.Location = new System.Drawing.Point(233, 18);
            this.amho.Name = "amho";
            this.amho.Size = new System.Drawing.Size(111, 21);
            this.amho.TabIndex = 1;
            this.amho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label115
            // 
            this.label115.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(536, 22);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(88, 16);
            this.label115.TabIndex = 359;
            this.label115.Text = "Tầng sinh môn :";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label114
            // 
            this.label114.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(336, 22);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(56, 16);
            this.label114.TabIndex = 358;
            this.label114.Text = "Âm đạo :";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label113
            // 
            this.label113.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.Location = new System.Drawing.Point(178, 22);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(56, 16);
            this.label113.TabIndex = 357;
            this.label113.Text = "Âm hộ :";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label104
            // 
            this.label104.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.Location = new System.Drawing.Point(144, 22);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(48, 16);
            this.label104.TabIndex = 356;
            this.label104.Text = "điểm";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bishop
            // 
            this.bishop.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bishop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bishop.Location = new System.Drawing.Point(105, 18);
            this.bishop.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.bishop.MaxLength = 5;
            this.bishop.Name = "bishop";
            this.bishop.Size = new System.Drawing.Size(38, 21);
            this.bishop.TabIndex = 0;
            this.bishop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label103
            // 
            this.label103.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label103.Location = new System.Drawing.Point(-14, 22);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(120, 16);
            this.label103.TabIndex = 355;
            this.label103.Text = "- Chỉ số Bishop :";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label102
            // 
            this.label102.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.Location = new System.Drawing.Point(0, 2);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(104, 16);
            this.label102.TabIndex = 354;
            this.label102.Text = "3. Khám trong :";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(0, 137);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(232, 17);
            this.label64.TabIndex = 373;
            this.label64.Text = "IV. Theo dõi tại buồng đẻ :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butTresosinh
            // 
            this.butTresosinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butTresosinh.Location = new System.Drawing.Point(656, 181);
            this.butTresosinh.Name = "butTresosinh";
            this.butTresosinh.Size = new System.Drawing.Size(120, 19);
            this.butTresosinh.TabIndex = 22;
            this.butTresosinh.Text = "Diễn biến chuyển dạ";
            this.butTresosinh.Visible = false;
            this.butTresosinh.Click += new System.EventHandler(this.butTresosinh_Click);
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(-2, 185);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(144, 16);
            this.label73.TabIndex = 393;
            this.label73.Text = "1. Đặc điểm trẻ sơ sinh :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(14, 182);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.ReadOnly = true;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(762, 68);
            this.dataGrid4.TabIndex = 394;
            // 
            // chucdanh
            // 
            this.chucdanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chucdanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chucdanh.Location = new System.Drawing.Point(624, 152);
            this.chucdanh.Name = "chucdanh";
            this.chucdanh.Size = new System.Drawing.Size(152, 21);
            this.chucdanh.TabIndex = 21;
            this.chucdanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // ngayde
            // 
            this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayde.Location = new System.Drawing.Point(184, 154);
            this.ngayde.Mask = "##/##/####";
            this.ngayde.Name = "ngayde";
            this.ngayde.Size = new System.Drawing.Size(72, 21);
            this.ngayde.TabIndex = 18;
            this.ngayde.Text = "  /  /    ";
            this.ngayde.Validated += new System.EventHandler(this.ngayde_Validated);
            // 
            // tentheodoi
            // 
            this.tentheodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentheodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentheodoi.Location = new System.Drawing.Point(393, 154);
            this.tentheodoi.Name = "tentheodoi";
            this.tentheodoi.Size = new System.Drawing.Size(162, 21);
            this.tentheodoi.TabIndex = 20;
            this.tentheodoi.TextChanged += new System.EventHandler(this.tentheodoi_TextChanged);
            this.tentheodoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentheodoi_KeyDown);
            // 
            // theodoi
            // 
            this.theodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.theodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi.Location = new System.Drawing.Point(356, 154);
            this.theodoi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.theodoi.MaxLength = 9;
            this.theodoi.Name = "theodoi";
            this.theodoi.Size = new System.Drawing.Size(36, 21);
            this.theodoi.TabIndex = 19;
            this.theodoi.Validated += new System.EventHandler(this.theodoi_Validated);
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(568, 0);
            this.listNv1.MatchBufferTimeOut = 1000;
            this.listNv1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv1.Name = "listNv1";
            this.listNv1.Size = new System.Drawing.Size(75, 17);
            this.listNv1.TabIndex = 405;
            this.listNv1.TextIndex = -1;
            this.listNv1.TextMember = null;
            this.listNv1.ValueIndex = -1;
            this.listNv1.Visible = false;
            // 
            // label134
            // 
            this.label134.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.Location = new System.Drawing.Point(555, 156);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(69, 16);
            this.label134.TabIndex = 404;
            this.label134.Text = "Chức danh :";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label133
            // 
            this.label133.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(248, 156);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(112, 16);
            this.label133.TabIndex = 403;
            this.label133.Text = "Tên người theo dõi :";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giode
            // 
            this.giode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giode.Location = new System.Drawing.Point(105, 154);
            this.giode.Mask = "##:##";
            this.giode.Name = "giode";
            this.giode.Size = new System.Drawing.Size(40, 21);
            this.giode.TabIndex = 17;
            this.giode.Text = "  :  ";
            this.giode.Validated += new System.EventHandler(this.giode_Validated);
            // 
            // label131
            // 
            this.label131.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(144, 156);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(38, 16);
            this.label131.TabIndex = 402;
            this.label131.Text = "ngày :";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label132
            // 
            this.label132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.Location = new System.Drawing.Point(0, 156);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(104, 16);
            this.label132.TabIndex = 401;
            this.label132.Text = "- Vào buồng đẻ lúc :";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cotucung
            // 
            this.cotucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cotucung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cotucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotucung.Items.AddRange(new object[] {
            "1. Không rách",
            "2. Rách"});
            this.cotucung.Location = new System.Drawing.Point(288, 445);
            this.cotucung.Name = "cotucung";
            this.cotucung.Size = new System.Drawing.Size(328, 21);
            this.cotucung.TabIndex = 46;
            this.cotucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label161
            // 
            this.label161.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.Location = new System.Drawing.Point(194, 447);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(96, 16);
            this.label161.TabIndex = 450;
            this.label161.Text = "Cổ tử cung :";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaichi
            // 
            this.loaichi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaichi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaichi.Location = new System.Drawing.Point(400, 421);
            this.loaichi.Name = "loaichi";
            this.loaichi.Size = new System.Drawing.Size(216, 21);
            this.loaichi.TabIndex = 44;
            this.loaichi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // somui
            // 
            this.somui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.somui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.somui.Location = new System.Drawing.Point(112, 445);
            this.somui.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.somui.MaxLength = 5;
            this.somui.Name = "somui";
            this.somui.Size = new System.Drawing.Size(40, 21);
            this.somui.TabIndex = 45;
            this.somui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tangsinhmon
            // 
            this.tangsinhmon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tangsinhmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tangsinhmon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tangsinhmon.Items.AddRange(new object[] {
            "1. Không rách",
            "2. Rách",
            "3. Cắt"});
            this.tangsinhmon.Location = new System.Drawing.Point(112, 421);
            this.tangsinhmon.Name = "tangsinhmon";
            this.tangsinhmon.Size = new System.Drawing.Size(94, 21);
            this.tangsinhmon.TabIndex = 43;
            this.tangsinhmon.SelectedIndexChanged += new System.EventHandler(this.tangsinhmon_SelectedIndexChanged);
            this.tangsinhmon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label160
            // 
            this.label160.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.Location = new System.Drawing.Point(8, 447);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(88, 16);
            this.label160.TabIndex = 449;
            this.label160.Text = "- Số mũi khâu :";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label159
            // 
            this.label159.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label159.Location = new System.Drawing.Point(183, 426);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(216, 16);
            this.label159.TabIndex = 448;
            this.label159.Text = "Nếu có, phương pháp khâu và loại chỉ :";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label154
            // 
            this.label154.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.Location = new System.Drawing.Point(8, 426);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(96, 16);
            this.label154.TabIndex = 447;
            this.label154.Text = "- Tầng sinh môn :";
            this.label154.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ppde
            // 
            this.ppde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ppde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ppde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppde.Location = new System.Drawing.Point(112, 397);
            this.ppde.Name = "ppde";
            this.ppde.Size = new System.Drawing.Size(94, 21);
            this.ppde.TabIndex = 41;
            this.ppde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // canthiep
            // 
            this.canthiep.BackColor = System.Drawing.SystemColors.HighlightText;
            this.canthiep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canthiep.Location = new System.Drawing.Point(288, 397);
            this.canthiep.Name = "canthiep";
            this.canthiep.Size = new System.Drawing.Size(328, 21);
            this.canthiep.TabIndex = 42;
            this.canthiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label153
            // 
            this.label153.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label153.Location = new System.Drawing.Point(194, 401);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(96, 16);
            this.label153.TabIndex = 446;
            this.label153.Text = "Lý do can thiệp :";
            this.label153.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.sd_nhietdo);
            this.panel3.Controls.Add(this.sd_huyetap);
            this.panel3.Controls.Add(this.sd_nhiptho);
            this.panel3.Controls.Add(this.sd_mach);
            this.panel3.Controls.Add(this.label149);
            this.panel3.Controls.Add(this.label150);
            this.panel3.Controls.Add(this.label151);
            this.panel3.Controls.Add(this.label152);
            this.panel3.Controls.Add(this.label155);
            this.panel3.Controls.Add(this.label156);
            this.panel3.Controls.Add(this.label157);
            this.panel3.Controls.Add(this.label158);
            this.panel3.Location = new System.Drawing.Point(624, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(152, 95);
            this.panel3.TabIndex = 40;
            // 
            // sd_nhietdo
            // 
            this.sd_nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_nhietdo.Location = new System.Drawing.Point(64, 25);
            this.sd_nhietdo.Mask = "##.##";
            this.sd_nhietdo.Name = "sd_nhietdo";
            this.sd_nhietdo.Size = new System.Drawing.Size(32, 21);
            this.sd_nhietdo.TabIndex = 1;
            this.sd_nhietdo.Text = "  .  ";
            // 
            // sd_huyetap
            // 
            this.sd_huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_huyetap.Location = new System.Drawing.Point(64, 48);
            this.sd_huyetap.Mask = "###/###";
            this.sd_huyetap.Name = "sd_huyetap";
            this.sd_huyetap.Size = new System.Drawing.Size(45, 21);
            this.sd_huyetap.TabIndex = 2;
            this.sd_huyetap.Text = "   /   ";
            // 
            // sd_nhiptho
            // 
            this.sd_nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_nhiptho.Location = new System.Drawing.Point(64, 70);
            this.sd_nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sd_nhiptho.MaxLength = 5;
            this.sd_nhiptho.Name = "sd_nhiptho";
            this.sd_nhiptho.Size = new System.Drawing.Size(32, 21);
            this.sd_nhiptho.TabIndex = 3;
            this.sd_nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sd_mach
            // 
            this.sd_mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_mach.Location = new System.Drawing.Point(64, 2);
            this.sd_mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sd_mach.MaxLength = 5;
            this.sd_mach.Name = "sd_mach";
            this.sd_mach.Size = new System.Drawing.Size(32, 21);
            this.sd_mach.TabIndex = 0;
            this.sd_mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label149
            // 
            this.label149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(99, 4);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(48, 19);
            this.label149.TabIndex = 11;
            this.label149.Text = "lần/phút";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.Location = new System.Drawing.Point(96, 29);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 13;
            this.label150.Text = "°C";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(112, 48);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(38, 16);
            this.label151.TabIndex = 16;
            this.label151.Text = "mmHg";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.Location = new System.Drawing.Point(99, 73);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(48, 16);
            this.label152.TabIndex = 18;
            this.label152.Text = "lần/phút";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label155
            // 
            this.label155.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(8, 74);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(56, 16);
            this.label155.TabIndex = 6;
            this.label155.Text = "Nhịp thở :";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label156
            // 
            this.label156.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(0, 53);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(64, 16);
            this.label156.TabIndex = 5;
            this.label156.Text = "Huyết áp :";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label157
            // 
            this.label157.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(8, 29);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(56, 16);
            this.label157.TabIndex = 4;
            this.label157.Text = "Nhiệt độ :";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(24, 5);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(40, 16);
            this.label158.TabIndex = 3;
            this.label158.Text = "Mạch :";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label148
            // 
            this.label148.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(8, 401);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(112, 15);
            this.label148.TabIndex = 445;
            this.label148.Text = "- Phương pháp đẻ :";
            this.label148.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // da
            // 
            this.da.BackColor = System.Drawing.SystemColors.HighlightText;
            this.da.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.da.Location = new System.Drawing.Point(400, 374);
            this.da.Name = "da";
            this.da.Size = new System.Drawing.Size(216, 21);
            this.da.TabIndex = 39;
            this.da.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label147
            // 
            this.label147.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.Location = new System.Drawing.Point(304, 374);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(96, 16);
            this.label147.TabIndex = 444;
            this.label147.Text = "Da, niêm mạc :";
            this.label147.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label146
            // 
            this.label146.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.Location = new System.Drawing.Point(0, 377);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(176, 16);
            this.label146.TabIndex = 443;
            this.label146.Text = "3. Tình trạng sản phụ sau đẻ :";
            this.label146.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xuly
            // 
            this.xuly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xuly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuly.Location = new System.Drawing.Point(112, 350);
            this.xuly.Name = "xuly";
            this.xuly.Size = new System.Drawing.Size(664, 21);
            this.xuly.TabIndex = 36;
            this.xuly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label145
            // 
            this.label145.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.Location = new System.Drawing.Point(8, 352);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(112, 15);
            this.label145.TabIndex = 442;
            this.label145.Text = "- Xử lý và kết quả :";
            this.label145.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kiemsoattc
            // 
            this.kiemsoattc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kiemsoattc.Location = new System.Drawing.Point(436, 326);
            this.kiemsoattc.Name = "kiemsoattc";
            this.kiemsoattc.Size = new System.Drawing.Size(114, 16);
            this.kiemsoattc.TabIndex = 35;
            this.kiemsoattc.Text = "Kiểm soát tử cung ";
            this.kiemsoattc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label144
            // 
            this.label144.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.Location = new System.Drawing.Point(380, 326);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(38, 16);
            this.label144.TabIndex = 441;
            this.label144.Text = "ml";
            this.label144.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maumat
            // 
            this.maumat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maumat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maumat.Location = new System.Drawing.Point(336, 326);
            this.maumat.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.maumat.MaxLength = 5;
            this.maumat.Name = "maumat";
            this.maumat.Size = new System.Drawing.Size(40, 21);
            this.maumat.TabIndex = 34;
            this.maumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label143
            // 
            this.label143.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.Location = new System.Drawing.Point(208, 326);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(128, 16);
            this.label143.TabIndex = 440;
            this.label143.Text = "Nếu có lượng máu mất :";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chaymau
            // 
            this.chaymau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chaymau.Location = new System.Drawing.Point(8, 326);
            this.chaymau.Name = "chaymau";
            this.chaymau.Size = new System.Drawing.Size(133, 16);
            this.chaymau.TabIndex = 33;
            this.chaymau.Text = "- Có chảy máu sau sổ";
            this.chaymau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label142
            // 
            this.label142.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(720, 302);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(38, 16);
            this.label142.TabIndex = 439;
            this.label142.Text = "cm";
            this.label142.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // raudai
            // 
            this.raudai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.raudai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raudai.Location = new System.Drawing.Point(680, 302);
            this.raudai.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.raudai.MaxLength = 5;
            this.raudai.Name = "raudai";
            this.raudai.Size = new System.Drawing.Size(40, 21);
            this.raudai.TabIndex = 32;
            this.raudai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label141
            // 
            this.label141.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(592, 302);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(88, 16);
            this.label141.TabIndex = 438;
            this.label141.Text = "Cuống rau dài :";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // banhrau
            // 
            this.banhrau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.banhrau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banhrau.Location = new System.Drawing.Point(112, 302);
            this.banhrau.Name = "banhrau";
            this.banhrau.Size = new System.Drawing.Size(152, 21);
            this.banhrau.TabIndex = 29;
            this.banhrau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // mui
            // 
            this.mui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mui.Location = new System.Drawing.Point(680, 278);
            this.mui.Name = "mui";
            this.mui.Size = new System.Drawing.Size(96, 21);
            this.mui.TabIndex = 28;
            this.mui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // mang
            // 
            this.mang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mang.Location = new System.Drawing.Point(536, 278);
            this.mang.Name = "mang";
            this.mang.Size = new System.Drawing.Size(96, 21);
            this.mang.TabIndex = 27;
            this.mang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // cachso
            // 
            this.cachso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachso.Location = new System.Drawing.Point(336, 278);
            this.cachso.Name = "cachso";
            this.cachso.Size = new System.Drawing.Size(144, 21);
            this.cachso.TabIndex = 26;
            this.cachso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // raucannang
            // 
            this.raucannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.raucannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raucannang.Location = new System.Drawing.Point(336, 302);
            this.raucannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.raucannang.MaxLength = 5;
            this.raucannang.Name = "raucannang";
            this.raucannang.Size = new System.Drawing.Size(40, 21);
            this.raucannang.TabIndex = 30;
            this.raucannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // raucuon
            // 
            this.raucuon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.raucuon.Location = new System.Drawing.Point(460, 302);
            this.raucuon.Name = "raucuon";
            this.raucuon.Size = new System.Drawing.Size(90, 16);
            this.raucuon.TabIndex = 31;
            this.raucuon.Text = "Rau cuốn cổ";
            this.raucuon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label140
            // 
            this.label140.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(376, 302);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(38, 16);
            this.label140.TabIndex = 437;
            this.label140.Text = "gram";
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label139
            // 
            this.label139.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(264, 302);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(72, 16);
            this.label139.TabIndex = 436;
            this.label139.Text = "Cân nặng :";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label138
            // 
            this.label138.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(8, 302);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(72, 16);
            this.label138.TabIndex = 435;
            this.label138.Text = "- Bánh rau :";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label137
            // 
            this.label137.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.Location = new System.Drawing.Point(608, 278);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(72, 16);
            this.label137.TabIndex = 434;
            this.label137.Text = "Mặt mũi :";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(464, 278);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(72, 16);
            this.label74.TabIndex = 433;
            this.label74.Text = "Mặt màng :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label136
            // 
            this.label136.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.Location = new System.Drawing.Point(264, 278);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(72, 16);
            this.label136.TabIndex = 432;
            this.label136.Text = "Cách sổ rau :";
            this.label136.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayrau
            // 
            this.ngayrau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrau.Location = new System.Drawing.Point(192, 278);
            this.ngayrau.Mask = "##/##/####";
            this.ngayrau.Name = "ngayrau";
            this.ngayrau.Size = new System.Drawing.Size(72, 21);
            this.ngayrau.TabIndex = 25;
            this.ngayrau.Text = "  /  /    ";
            this.ngayrau.Validated += new System.EventHandler(this.ngayrau_Validated);
            // 
            // giorau
            // 
            this.giorau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorau.Location = new System.Drawing.Point(112, 278);
            this.giorau.Mask = "##:##";
            this.giorau.Name = "giorau";
            this.giorau.Size = new System.Drawing.Size(40, 21);
            this.giorau.TabIndex = 24;
            this.giorau.Text = "  :  ";
            this.giorau.Validated += new System.EventHandler(this.giorau_Validated);
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(152, 278);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(38, 16);
            this.label72.TabIndex = 431;
            this.label72.Text = "ngày :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label135
            // 
            this.label135.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label135.Location = new System.Drawing.Point(8, 278);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(112, 16);
            this.label135.TabIndex = 430;
            this.label135.Text = "- Rau sổ lúc :";
            this.label135.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rau
            // 
            this.rau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rau.Items.AddRange(new object[] {
            "1. Bóc",
            "2. Sổ"});
            this.rau.Location = new System.Drawing.Point(192, 254);
            this.rau.Name = "rau";
            this.rau.Size = new System.Drawing.Size(72, 21);
            this.rau.TabIndex = 23;
            this.rau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amho_KeyDown);
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(160, 254);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(40, 16);
            this.label69.TabIndex = 429;
            this.label69.Text = "Rau :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(0, 254);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(144, 16);
            this.label68.TabIndex = 428;
            this.label68.Text = "2. Đặc điểm sổ rau :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butLuu
            // 
            this.butLuu.Location = new System.Drawing.Point(332, 475);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 47;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Location = new System.Drawing.Point(404, 475);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 48;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // label168
            // 
            this.label168.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.Location = new System.Drawing.Point(170, 374);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(38, 16);
            this.label168.TabIndex = 453;
            this.label168.Text = "ngày :";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysaude
            // 
            this.ngaysaude.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysaude.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysaude.Location = new System.Drawing.Point(211, 374);
            this.ngaysaude.Mask = "##/##/####";
            this.ngaysaude.Name = "ngaysaude";
            this.ngaysaude.Size = new System.Drawing.Size(72, 21);
            this.ngaysaude.TabIndex = 37;
            this.ngaysaude.Text = "  /  /    ";
            this.ngaysaude.Validated += new System.EventHandler(this.ngaysaude_Validated);
            // 
            // giosaude
            // 
            this.giosaude.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giosaude.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giosaude.Location = new System.Drawing.Point(284, 374);
            this.giosaude.Mask = "##:##";
            this.giosaude.Name = "giosaude";
            this.giosaude.Size = new System.Drawing.Size(40, 21);
            this.giosaude.TabIndex = 38;
            this.giosaude.Text = "  :  ";
            this.giosaude.Validated += new System.EventHandler(this.giosaude_Validated);
            // 
            // frmTTSankhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(786, 519);
            this.Controls.Add(this.label168);
            this.Controls.Add(this.ngaysaude);
            this.Controls.Add(this.giosaude);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.cotucung);
            this.Controls.Add(this.label161);
            this.Controls.Add(this.loaichi);
            this.Controls.Add(this.somui);
            this.Controls.Add(this.tangsinhmon);
            this.Controls.Add(this.label160);
            this.Controls.Add(this.label159);
            this.Controls.Add(this.label154);
            this.Controls.Add(this.ppde);
            this.Controls.Add(this.canthiep);
            this.Controls.Add(this.label153);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.da);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.label146);
            this.Controls.Add(this.xuly);
            this.Controls.Add(this.label145);
            this.Controls.Add(this.kiemsoattc);
            this.Controls.Add(this.label144);
            this.Controls.Add(this.maumat);
            this.Controls.Add(this.label143);
            this.Controls.Add(this.chaymau);
            this.Controls.Add(this.label142);
            this.Controls.Add(this.raudai);
            this.Controls.Add(this.label141);
            this.Controls.Add(this.banhrau);
            this.Controls.Add(this.mui);
            this.Controls.Add(this.mang);
            this.Controls.Add(this.cachso);
            this.Controls.Add(this.raucannang);
            this.Controls.Add(this.raucuon);
            this.Controls.Add(this.label140);
            this.Controls.Add(this.label139);
            this.Controls.Add(this.label138);
            this.Controls.Add(this.label137);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label136);
            this.Controls.Add(this.ngayrau);
            this.Controls.Add(this.giorau);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label135);
            this.Controls.Add(this.rau);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.chucdanh);
            this.Controls.Add(this.ngayde);
            this.Controls.Add(this.tentheodoi);
            this.Controls.Add(this.theodoi);
            this.Controls.Add(this.listNv1);
            this.Controls.Add(this.label134);
            this.Controls.Add(this.label133);
            this.Controls.Add(this.giode);
            this.Controls.Add(this.label131);
            this.Controls.Add(this.label132);
            this.Controls.Add(this.butTresosinh);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.have);
            this.Controls.Add(this.tinhtrangoi);
            this.Controls.Add(this.oivo);
            this.Controls.Add(this.dolot);
            this.Controls.Add(this.label128);
            this.Controls.Add(this.kieu);
            this.Controls.Add(this.the);
            this.Controls.Add(this.ngoi);
            this.Controls.Add(this.nuocoi);
            this.Controls.Add(this.mausac);
            this.Controls.Add(this.label127);
            this.Controls.Add(this.label126);
            this.Controls.Add(this.label125);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.label122);
            this.Controls.Add(this.label121);
            this.Controls.Add(this.giovo);
            this.Controls.Add(this.ngayvo);
            this.Controls.Add(this.label119);
            this.Controls.Add(this.label120);
            this.Controls.Add(this.phanphu);
            this.Controls.Add(this.tucung);
            this.Controls.Add(this.label118);
            this.Controls.Add(this.label117);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.sinhmon);
            this.Controls.Add(this.amdao);
            this.Controls.Add(this.amho);
            this.Controls.Add(this.label115);
            this.Controls.Add(this.label114);
            this.Controls.Add(this.label113);
            this.Controls.Add(this.label104);
            this.Controls.Add(this.bishop);
            this.Controls.Add(this.label103);
            this.Controls.Add(this.label102);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTTSankhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin sản khoa";
            this.Load += new System.EventHandler(this.frmTTSankhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTTSankhoa_Load(object sender, System.EventArgs e)
		{
			xxx=m.user+m.mmyy(ngay);
			dtnv=m.get_data("select * from dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];

			listNv1.DisplayMember="MA";
			listNv1.ValueMember="HOTEN";
			listNv1.DataSource=m.get_data("select * from dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];

			tinhtrangoi.SelectedIndex=0;oivo.SelectedIndex=0;dolot.SelectedIndex=0;rau.SelectedIndex=0;tangsinhmon.SelectedIndex=0;cotucung.SelectedIndex=0;
			ppde.DisplayMember="TEN";
			ppde.ValueMember="ID";
			ppde.DataSource=m.get_data("select * from dmkieusanh order by stt").Tables[0];

			dstress.ReadXml("..\\..\\..\\xml\\m_tresosinh.xml");
			dataGrid4.DataSource=dstress.Tables[0];
			AddGridTableStyle4();

			load_data();
		}

		private void load_data()
		{
			string _ngay="";
			DataRow r1;
			foreach(DataRow r in m.get_data("select * from "+xxx+".ba_sankhoa where id="+l_id).Tables[0].Rows)
			{
				bishop.Text=(r["bishop"].ToString()!="0")?r["bishop"].ToString():"";
				amho.Text=r["amho"].ToString();
				amdao.Text=r["amdao"].ToString();
				sinhmon.Text=r["sinhmon"].ToString();
				tucung.Text=r["tucung"].ToString();
				phanphu.Text=r["phanphu"].ToString();
				tinhtrangoi.SelectedIndex=int.Parse(r["tinhtrangoi"].ToString());
				if (r["voluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["voluc"].ToString()));
					ngayvo.Text=_ngay.Substring(0,10);
					giovo.Text=_ngay.Substring(11);
				}
				oivo.SelectedIndex=int.Parse(r["oivo"].ToString());
				mausac.Text=r["mausac"].ToString();
				nuocoi.Text=r["nuocoi"].ToString();
				ngoi.Text=r["ngoi"].ToString();
				the.Text=r["the"].ToString();
				kieu.Text=r["kieu"].ToString();
				dolot.SelectedIndex=int.Parse(r["dolot"].ToString());
				have.Text=r["have"].ToString();
				if (r["deluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["deluc"].ToString()));
					ngayde.Text=_ngay.Substring(0,10);
					giode.Text=_ngay.Substring(11);
				}
				if (r["ngaysaude"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaysaude"].ToString()));
					ngaysaude.Text=_ngay.Substring(0,10);
					giosaude.Text=_ngay.Substring(11);
				}
				theodoi.Text=r["theodoi"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r1!=null) tentheodoi.Text=r1["hoten"].ToString();
				chucdanh.Text=r["chucdanh"].ToString();
				rau.SelectedIndex=int.Parse(r["rau"].ToString());
				if (r["rauluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["rauluc"].ToString()));
					ngayrau.Text=_ngay.Substring(0,10);
					giorau.Text=_ngay.Substring(11);
				}
				cachso.Text=r["cachso"].ToString();
				mang.Text=r["mang"].ToString();
				mui.Text=r["mui"].ToString();
				banhrau.Text=r["banhrau"].ToString();
				raucannang.Text=(r["raucannang"].ToString()!="0")?r["raucannang"].ToString():"";
				raucuon.Checked=r["raucuon"].ToString()=="1";
				raudai.Text=(r["raudai"].ToString()!="0")?r["raudai"].ToString():"";
				chaymau.Checked=r["chaymau"].ToString()=="1";
				maumat.Text=(r["maumat"].ToString()!="0")?r["maumat"].ToString():"";
				maumat.Enabled=chaymau.Checked;
				kiemsoattc.Checked=r["kiemsoattc"].ToString()=="1";
				xuly.Text=r["xuly"].ToString();
				da.Text=r["da"].ToString();
				ppde.SelectedValue=r["ppde"].ToString();
				sd_mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				sd_nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				sd_huyetap.Text=r["huyetap"].ToString();
				sd_nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				canthiep.Text=r["canthiep"].ToString();
				tangsinhmon.SelectedIndex=int.Parse(r["tangsinhmon"].ToString());
				loaichi.Text=r["loaichi"].ToString();
				somui.Text=(r["somui"].ToString()!="0")?r["somui"].ToString():"";
				loaichi.Enabled=tangsinhmon.SelectedIndex==2;
				somui.Enabled=loaichi.Enabled;
				cotucung.SelectedIndex=int.Parse(r["cotucung"].ToString());
				break;
			}
			load_tresosinh();
		}

		private void AddGridTableStyle4()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dstress.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id_ss";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày sinh";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenngoithai";
			TextCol.HeaderText = "Ngôi thai";
			TextCol.Width = 85;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_phai";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tencachthucde";
			TextCol.HeaderText = "Cách thức đẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cao";
			TextCol.HeaderText = "Cao";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vongdau";
			TextCol.HeaderText = "Vòng đầu";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_tinhtrang";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_ditat";
			TextCol.HeaderText = "Dị tật";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenditat";
			TextCol.HeaderText = "Tật bẩm sinh";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);
		}


		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			m.upd_ba_sankhoa(ngay,l_id,(bishop.Text!="")?decimal.Parse(bishop.Text):0,amho.Text,amdao.Text,sinhmon.Text,tucung.Text,
				phanphu.Text,tinhtrangoi.SelectedIndex,ngayvo.Text+" "+giovo.Text,oivo.SelectedIndex,mausac.Text,nuocoi.Text,ngoi.Text,the.Text,kieu.Text,dolot.SelectedIndex,have.Text,
				ngayde.Text+" "+giode.Text,theodoi.Text,chucdanh.Text,rau.SelectedIndex,ngayrau.Text+" "+giorau.Text,cachso.Text,mang.Text,mui.Text,banhrau.Text,(raucannang.Text!="")?decimal.Parse(raucannang.Text):0,
				(raucuon.Checked)?1:0,(raudai.Text!="")?decimal.Parse(raudai.Text):0,(chaymau.Checked)?1:0,(maumat.Text!="")?decimal.Parse(maumat.Text):0,(kiemsoattc.Checked)?1:0,xuly.Text,ngaysaude.Text+" "+giosaude.Text,da.Text,int.Parse(ppde.SelectedValue.ToString()),
				(sd_mach.Text!="")?decimal.Parse(sd_mach.Text):0,(sd_nhietdo.Text!="")?decimal.Parse(sd_nhietdo.Text):0,sd_huyetap.Text,(sd_nhiptho.Text!="")?decimal.Parse(sd_nhiptho.Text):0,canthiep.Text,tangsinhmon.SelectedIndex,loaichi.Text,(somui.Text!="")?decimal.Parse(somui.Text):0,cotucung.SelectedIndex);
			bUpdate=true;
			this.Close();
		}

		private void butTresosinh_Click(object sender, System.EventArgs e)
		{
//			DataRow r=m.getrowbyid(ds.Tables[0],"maql="+l_maql);
//			if (r!=null)
//			{
//				frmBasosinh f=new frmBasosinh(m,ngay,l_iddieutri,r["mabn"].ToString(),l_maql,r["ngayvk"].ToString(),i_userid,bAdmin,s_sovaovien,s_hoten,s_phai,s_tenkp,s_phong,s_giuong,s_chandoan);
//				f.ShowDialog();
//				load_tresosinh();
//				rau.Focus();
//			}
		}

		private void load_tresosinh()
		{
			sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten as tenngoithai,b.ma,";
			sql+="decode(a.phai,0,'Nam','Nu') as t_phai,decode(a.tinhtrang,0,'Song','Chet') as t_tinhtrang,";
			sql+="decode(a.ditat,0,'Không','Có') as t_ditat,a.cannang,a.phai,a.tinhtrang,a.ditat,a.id_ss,d.ten as tencachthucde,";
			sql+="c.apgar1,c.apgar5,c.apgar10,c.conthu,c.mass,c.hoten,c.duthang,c.thang,c.tuan,c.manv1,c.manv2,c.cachthucde,c.xuly,";
			sql+="c.cao,c.vongdau,c.ditatbs,e.ten as tenditat,a.ngoithai ";
			sql+=" from tresosinh a,dmngoithai b,ddsosinh c,dmkieusanh d,dmditat e ";
			sql+=" where a.ngoithai=b.ma and a.id_ss=c.maql and c.cachthucde=d.id and c.ditatbs=e.ma(+) and a.maql="+l_maql+" order by a.id_ss";
			dstress=m.get_data(sql);
			dataGrid4.DataSource=dstress.Tables[0];
		}

		private void amho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ngayvo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayvo.Text!="")
				{
					ngayvo.Text=ngayvo.Text.Trim();
					if (ngayvo.Text.Length==6) ngayvo.Text=ngayvo.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayvo.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayvo.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void giovo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giovo.Text!="")
				{
					string sgio=(giovo.Text.Trim()=="")?"00:00":giovo.Text.Trim();
					giovo.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giovo.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giovo.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giode_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giode.Text!="")
				{
					string sgio=(giode.Text.Trim()=="")?"00:00":giode.Text.Trim();
					giode.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giode.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giode.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giorau_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giorau.Text!="")
				{
					string sgio=(giorau.Text.Trim()=="")?"00:00":giorau.Text.Trim();
					giorau.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giorau.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giorau.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void ngayrau_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayrau.Text!="")
				{
					ngayrau.Text=ngayrau.Text.Trim();
					if (ngayrau.Text.Length==6) ngayrau.Text=ngayrau.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayrau.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayrau.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void ngayde_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayde.Text!="")
				{
					ngayde.Text=ngayde.Text.Trim();
					if (ngayde.Text.Length==6) ngayde.Text=ngayde.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayde.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayde.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void tangsinhmon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tangsinhmon)
			{
				loaichi.Enabled=tangsinhmon.SelectedIndex==2;
				somui.Enabled=loaichi.Enabled;
			}
		}

		private void theodoi_Validated(object sender, System.EventArgs e)
		{
			if (theodoi.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
			if (r!=null) tentheodoi.Text=r["hoten"].ToString();
			else tentheodoi.Text="";				
		}

		private void tentheodoi_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentheodoi)
			{
				Filt_dmbs(tentheodoi.Text);
				listNv1.BrowseToDanhmuc(tentheodoi,theodoi,chucdanh,35);
			}	
		}

		private void tentheodoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv1.Visible) listNv1.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void giosaude_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giosaude.Text!="")
				{
					string sgio=(giosaude.Text.Trim()=="")?"00:00":giosaude.Text.Trim();
					giosaude.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giosaude.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giosaude.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void ngaysaude_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngaysaude.Text!="")
				{
					ngaysaude.Text=ngaysaude.Text.Trim();
					if (ngaysaude.Text.Length==6) ngaysaude.Text=ngaysaude.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngaysaude.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngaysaude.Focus();
						return;
					}
				}
			}
			catch{}		
		}

	}
}
