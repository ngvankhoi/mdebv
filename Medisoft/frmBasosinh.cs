using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmBasosinh.
	/// </summary>
	public class frmBasosinh : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.ComponentModel.Container components = null;
		private string sql,s_msg,xxx,s_tenkp,user,s_makp,s_mabs,s_userid,mmyy,s_ngayrv;
		private decimal l_maql,l_id,l_idkhoa,l_idthuchien;
		private int i_userid,songay;
		private bool bAdmin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox cannang;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.ComboBox ditat;
		private System.Windows.Forms.Label label7;
		private DataSet ds=new DataSet();
		private DataTable dtnv=new DataTable();
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.Label label39;
		private MaskedTextBox.MaskedTextBox vongdau;
		private MaskedTextBox.MaskedTextBox cao;
		private MaskedTextBox.MaskedTextBox apgar10;
		private MaskedTextBox.MaskedTextBox apgar5;
		private MaskedTextBox.MaskedTextBox apgar1;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox madt;
		private System.Windows.Forms.ComboBox tendt;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox duthang;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown conthu;
		private System.Windows.Forms.NumericUpDown thang;
		private System.Windows.Forms.NumericUpDown tuan;
		private System.Windows.Forms.ComboBox ngoithai;
		private System.Windows.Forms.ComboBox cachthucde;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox xuly;
		private System.Windows.Forms.Label label168;
		private MaskedBox.MaskedBox ngaychuyenda;
		private MaskedBox.MaskedBox giochuyenda;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label100;
		private MaskedTextBox.MaskedTextBox timthai;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.TextBox tucung;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.Label label10;
		private MaskedTextBox.MaskedTextBox mo;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private MaskedTextBox.MaskedTextBox xoa;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox dolot;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tienluong;
		private System.Windows.Forms.TextBox xutri;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox kieuthe;
		private System.Windows.Forms.TextBox tentheodoi;
		private MaskedTextBox.MaskedTextBox theodoi;
		private System.Windows.Forms.Label label133;
		private LibList.List listNv1;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox tinhtrangoi;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.TextBox theodoi_pass;
		private System.Windows.Forms.CheckBox chkXml;
		private MaskedTextBox.MaskedTextBox nhiptho1;
		private MaskedTextBox.MaskedTextBox mach1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private MaskedBox.MaskedBox nhietdo1;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private MaskedBox.MaskedBox huyetap1;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox ngayvv;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox gioitinh;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private System.Windows.Forms.Button butBieudo;
		private int checkCol=0;

		public frmBasosinh(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //Language lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;gioitinh.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasosinh));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.ditat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.label39 = new System.Windows.Forms.Label();
            this.vongdau = new MaskedTextBox.MaskedTextBox();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.apgar10 = new MaskedTextBox.MaskedTextBox();
            this.apgar5 = new MaskedTextBox.MaskedTextBox();
            this.apgar1 = new MaskedTextBox.MaskedTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.ngoithai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.madt = new System.Windows.Forms.TextBox();
            this.tendt = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.duthang = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.conthu = new System.Windows.Forms.NumericUpDown();
            this.thang = new System.Windows.Forms.NumericUpDown();
            this.tuan = new System.Windows.Forms.NumericUpDown();
            this.cachthucde = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.xuly = new System.Windows.Forms.TextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.ngaychuyenda = new MaskedBox.MaskedBox();
            this.giochuyenda = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.timthai = new MaskedTextBox.MaskedTextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.tucung = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mo = new MaskedTextBox.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.xoa = new MaskedTextBox.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tinhtrangoi = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.dolot = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.xutri = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.kieuthe = new System.Windows.Forms.TextBox();
            this.tentheodoi = new System.Windows.Forms.TextBox();
            this.theodoi = new MaskedTextBox.MaskedTextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.listNv1 = new LibList.List();
            this.label31 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.theodoi_pass = new System.Windows.Forms.TextBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.nhiptho1 = new MaskedTextBox.MaskedTextBox();
            this.mach1 = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nhietdo1 = new MaskedBox.MaskedBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.huyetap1 = new MaskedBox.MaskedBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.phong = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.gioitinh = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butBieudo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(218, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 210;
            this.label1.Text = "Ngày sinh :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(368, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ngôi thai :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(226, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Giới tính :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(644, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tình trạng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(242, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Dị tật :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(218, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cân nặng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(288, 417);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cannang.MaxLength = 4;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 32;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(288, 345);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(64, 21);
            this.phai.TabIndex = 22;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Items.AddRange(new object[] {
            "Sống",
            "Chết"});
            this.tinhtrang.Location = new System.Drawing.Point(720, 417);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(64, 21);
            this.tinhtrang.TabIndex = 35;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // ditat
            // 
            this.ditat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ditat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ditat.Enabled = false;
            this.ditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ditat.Items.AddRange(new object[] {
            "Không",
            "Có"});
            this.ditat.Location = new System.Drawing.Point(288, 369);
            this.ditat.Name = "ditat";
            this.ditat.Size = new System.Drawing.Size(64, 21);
            this.ditat.TabIndex = 26;
            this.ditat.SelectedIndexChanged += new System.EventHandler(this.ditat_SelectedIndexChanged);
            this.ditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ditat_KeyDown);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(336, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "gr";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(288, 297);
            this.ngay.Mask = "##/##/#### ##:##";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(94, 21);
            this.ngay.TabIndex = 18;
            this.ngay.Text = "  /  /       :  ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(398, 420);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(40, 13);
            this.label39.TabIndex = 210;
            this.label39.Text = "Cao :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vongdau
            // 
            this.vongdau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vongdau.Enabled = false;
            this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongdau.Location = new System.Drawing.Point(585, 417);
            this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vongdau.MaxLength = 5;
            this.vongdau.Name = "vongdau";
            this.vongdau.Size = new System.Drawing.Size(39, 21);
            this.vongdau.TabIndex = 34;
            // 
            // cao
            // 
            this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cao.Enabled = false;
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(441, 417);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(39, 21);
            this.cao.TabIndex = 33;
            // 
            // apgar10
            // 
            this.apgar10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar10.Enabled = false;
            this.apgar10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar10.Location = new System.Drawing.Point(585, 393);
            this.apgar10.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar10.MaxLength = 3;
            this.apgar10.Name = "apgar10";
            this.apgar10.Size = new System.Drawing.Size(40, 21);
            this.apgar10.TabIndex = 31;
            // 
            // apgar5
            // 
            this.apgar5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar5.Enabled = false;
            this.apgar5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar5.Location = new System.Drawing.Point(441, 393);
            this.apgar5.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar5.MaxLength = 3;
            this.apgar5.Name = "apgar5";
            this.apgar5.Size = new System.Drawing.Size(40, 21);
            this.apgar5.TabIndex = 30;
            // 
            // apgar1
            // 
            this.apgar1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar1.Enabled = false;
            this.apgar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar1.Location = new System.Drawing.Point(288, 393);
            this.apgar1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar1.MaxLength = 3;
            this.apgar1.Name = "apgar1";
            this.apgar1.Size = new System.Drawing.Size(40, 21);
            this.apgar1.TabIndex = 29;
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label47.Location = new System.Drawing.Point(629, 416);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(24, 17);
            this.label47.TabIndex = 214;
            this.label47.Text = "cm";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(483, 420);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 13);
            this.label44.TabIndex = 213;
            this.label44.Text = "cm";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(511, 420);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(66, 13);
            this.label40.TabIndex = 211;
            this.label40.Text = "Vòng đầu :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(629, 398);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 13);
            this.label37.TabIndex = 208;
            this.label37.Text = "điểm";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(537, 397);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 13);
            this.label48.TabIndex = 206;
            this.label48.Text = "10 phút :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label50.Location = new System.Drawing.Point(483, 395);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(32, 16);
            this.label50.TabIndex = 205;
            this.label50.Text = "điểm";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label51.Location = new System.Drawing.Point(396, 397);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(42, 10);
            this.label51.TabIndex = 203;
            this.label51.Text = "5 phút :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label54.Location = new System.Drawing.Point(336, 393);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 18);
            this.label54.TabIndex = 202;
            this.label54.Text = "điểm";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(190, 397);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(92, 13);
            this.label66.TabIndex = 199;
            this.label66.Text = "Apgar 1 phút :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngoithai
            // 
            this.ngoithai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoithai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngoithai.Enabled = false;
            this.ngoithai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoithai.Location = new System.Drawing.Point(424, 142);
            this.ngoithai.Name = "ngoithai";
            this.ngoithai.Size = new System.Drawing.Size(152, 21);
            this.ngoithai.TabIndex = 11;
            this.ngoithai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngoithai_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(296, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 47;
            this.label11.Text = "Tên :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madt
            // 
            this.madt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madt.Enabled = false;
            this.madt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madt.Location = new System.Drawing.Point(384, 369);
            this.madt.Name = "madt";
            this.madt.Size = new System.Drawing.Size(56, 21);
            this.madt.TabIndex = 27;
            this.madt.Validated += new System.EventHandler(this.madt_Validated);
            this.madt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madt_KeyDown);
            // 
            // tendt
            // 
            this.tendt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendt.Enabled = false;
            this.tendt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendt.Location = new System.Drawing.Point(441, 369);
            this.tendt.Name = "tendt";
            this.tendt.Size = new System.Drawing.Size(343, 21);
            this.tendt.TabIndex = 28;
            this.tendt.SelectedIndexChanged += new System.EventHandler(this.tendt_SelectedIndexChanged);
            this.tendt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendt_KeyDown);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(660, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 50;
            this.label12.Text = "Con thứ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // duthang
            // 
            this.duthang.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.duthang.Enabled = false;
            this.duthang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.duthang.Location = new System.Drawing.Point(382, 347);
            this.duthang.Name = "duthang";
            this.duthang.Size = new System.Drawing.Size(72, 16);
            this.duthang.TabIndex = 23;
            this.duthang.Text = "Đủ tháng";
            this.duthang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.duthang.CheckedChanged += new System.EventHandler(this.duthang_CheckedChanged);
            this.duthang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(456, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 222;
            this.label14.Text = "Tháng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(568, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 19);
            this.label15.TabIndex = 223;
            this.label15.Text = "Tuần";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // conthu
            // 
            this.conthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.conthu.Enabled = false;
            this.conthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conthu.Location = new System.Drawing.Point(728, 321);
            this.conthu.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.conthu.Name = "conthu";
            this.conthu.Size = new System.Drawing.Size(56, 21);
            this.conthu.TabIndex = 21;
            this.conthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // thang
            // 
            this.thang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thang.Enabled = false;
            this.thang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thang.Location = new System.Drawing.Point(520, 345);
            this.thang.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(40, 21);
            this.thang.TabIndex = 24;
            this.thang.ValueChanged += new System.EventHandler(this.thang_ValueChanged);
            this.thang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // tuan
            // 
            this.tuan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuan.Enabled = false;
            this.tuan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuan.Location = new System.Drawing.Point(624, 345);
            this.tuan.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.tuan.Name = "tuan";
            this.tuan.Size = new System.Drawing.Size(40, 21);
            this.tuan.TabIndex = 25;
            this.tuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // cachthucde
            // 
            this.cachthucde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachthucde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cachthucde.Enabled = false;
            this.cachthucde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachthucde.Location = new System.Drawing.Point(464, 297);
            this.cachthucde.Name = "cachthucde";
            this.cachthucde.Size = new System.Drawing.Size(320, 21);
            this.cachthucde.TabIndex = 19;
            this.cachthucde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachthucde_KeyDown);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(384, 297);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 23);
            this.label19.TabIndex = 231;
            this.label19.Text = "Cách thức đẻ :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(178, 441);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 23);
            this.label20.TabIndex = 232;
            this.label20.Text = "Xử lý và kết quả :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xuly
            // 
            this.xuly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xuly.Enabled = false;
            this.xuly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuly.Location = new System.Drawing.Point(288, 441);
            this.xuly.Name = "xuly";
            this.xuly.Size = new System.Drawing.Size(496, 21);
            this.xuly.TabIndex = 36;
            this.xuly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label168
            // 
            this.label168.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.Location = new System.Drawing.Point(244, 97);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(38, 16);
            this.label168.TabIndex = 456;
            this.label168.Text = "Ngày :";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaychuyenda
            // 
            this.ngaychuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaychuyenda.Enabled = false;
            this.ngaychuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaychuyenda.Location = new System.Drawing.Point(288, 95);
            this.ngaychuyenda.Mask = "##/##/####";
            this.ngaychuyenda.Name = "ngaychuyenda";
            this.ngaychuyenda.Size = new System.Drawing.Size(64, 21);
            this.ngaychuyenda.TabIndex = 0;
            this.ngaychuyenda.Text = "  /  /    ";
            this.ngaychuyenda.Validated += new System.EventHandler(this.ngaychuyenda_Validated);
            // 
            // giochuyenda
            // 
            this.giochuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giochuyenda.Enabled = false;
            this.giochuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giochuyenda.Location = new System.Drawing.Point(376, 95);
            this.giochuyenda.Mask = "##:##";
            this.giochuyenda.Name = "giochuyenda";
            this.giochuyenda.Size = new System.Drawing.Size(40, 21);
            this.giochuyenda.TabIndex = 1;
            this.giochuyenda.Text = "  :  ";
            this.giochuyenda.Validated += new System.EventHandler(this.giochuyenda_Validated);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(352, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 457;
            this.label9.Text = "giờ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label100
            // 
            this.label100.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label100.Location = new System.Drawing.Point(320, 121);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(24, 16);
            this.label100.TabIndex = 460;
            this.label100.Text = "l/p";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timthai
            // 
            this.timthai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timthai.Enabled = false;
            this.timthai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timthai.Location = new System.Drawing.Point(288, 119);
            this.timthai.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.timthai.MaxLength = 5;
            this.timthai.Name = "timthai";
            this.timthai.Size = new System.Drawing.Size(32, 21);
            this.timthai.TabIndex = 6;
            this.timthai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label99
            // 
            this.label99.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.Location = new System.Drawing.Point(218, 121);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(64, 16);
            this.label99.TabIndex = 459;
            this.label99.Text = "Tim thai :";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tucung
            // 
            this.tucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tucung.Enabled = false;
            this.tucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tucung.Location = new System.Drawing.Point(424, 119);
            this.tucung.Name = "tucung";
            this.tucung.Size = new System.Drawing.Size(88, 21);
            this.tucung.TabIndex = 7;
            this.tucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label116
            // 
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(344, 121);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(80, 16);
            this.label116.TabIndex = 462;
            this.label116.Text = "Độ gò tử cung :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(520, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 463;
            this.label10.Text = "Cổ tử cung : - mở :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mo
            // 
            this.mo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mo.Enabled = false;
            this.mo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mo.Location = new System.Drawing.Point(616, 119);
            this.mo.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mo.MaxLength = 5;
            this.mo.Name = "mo";
            this.mo.Size = new System.Drawing.Size(40, 21);
            this.mo.TabIndex = 8;
            this.mo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.Location = new System.Drawing.Point(664, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 16);
            this.label21.TabIndex = 465;
            this.label21.Text = "cm";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(760, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 16);
            this.label22.TabIndex = 467;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xoa
            // 
            this.xoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xoa.Enabled = false;
            this.xoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.Location = new System.Drawing.Point(720, 119);
            this.xoa.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.xoa.MaxLength = 5;
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(32, 21);
            this.xoa.TabIndex = 9;
            this.xoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(688, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 16);
            this.label23.TabIndex = 468;
            this.label23.Text = "Xóa :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tinhtrangoi
            // 
            this.tinhtrangoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrangoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrangoi.Enabled = false;
            this.tinhtrangoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrangoi.Items.AddRange(new object[] {
            "Còn",
            "Rỉ",
            "Vỡ",
            "Sổ thai"});
            this.tinhtrangoi.Location = new System.Drawing.Point(288, 142);
            this.tinhtrangoi.Name = "tinhtrangoi";
            this.tinhtrangoi.Size = new System.Drawing.Size(80, 21);
            this.tinhtrangoi.TabIndex = 10;
            this.tinhtrangoi.SelectedIndexChanged += new System.EventHandler(this.tinhtrangoi_SelectedIndexChanged);
            this.tinhtrangoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label121
            // 
            this.label121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(178, 145);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(104, 16);
            this.label121.TabIndex = 470;
            this.label121.Text = "Tình trạng ối :";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(544, 145);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 16);
            this.label24.TabIndex = 471;
            this.label24.Text = "Độ lọt :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dolot
            // 
            this.dolot.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dolot.Enabled = false;
            this.dolot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dolot.Location = new System.Drawing.Point(616, 142);
            this.dolot.Name = "dolot";
            this.dolot.Size = new System.Drawing.Size(168, 21);
            this.dolot.TabIndex = 12;
            this.dolot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(210, 167);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 16);
            this.label25.TabIndex = 473;
            this.label25.Text = "Tiên lượng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(202, 201);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 16);
            this.label26.TabIndex = 474;
            this.label26.Text = "Hướng xử trí :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(288, 165);
            this.tienluong.Multiline = true;
            this.tienluong.Name = "tienluong";
            this.tienluong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tienluong.Size = new System.Drawing.Size(496, 40);
            this.tienluong.TabIndex = 13;
            // 
            // xutri
            // 
            this.xutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xutri.Enabled = false;
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(288, 207);
            this.xutri.Multiline = true;
            this.xutri.Name = "xutri";
            this.xutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xutri.Size = new System.Drawing.Size(496, 40);
            this.xutri.TabIndex = 14;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(226, 321);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 23);
            this.label27.TabIndex = 477;
            this.label27.Text = "Kiểu thế :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kieuthe
            // 
            this.kieuthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kieuthe.Enabled = false;
            this.kieuthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kieuthe.Location = new System.Drawing.Point(288, 321);
            this.kieuthe.Name = "kieuthe";
            this.kieuthe.Size = new System.Drawing.Size(376, 21);
            this.kieuthe.TabIndex = 20;
            this.kieuthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // tentheodoi
            // 
            this.tentheodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentheodoi.Enabled = false;
            this.tentheodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentheodoi.Location = new System.Drawing.Point(326, 249);
            this.tentheodoi.Name = "tentheodoi";
            this.tentheodoi.Size = new System.Drawing.Size(368, 21);
            this.tentheodoi.TabIndex = 16;
            this.tentheodoi.TextChanged += new System.EventHandler(this.tentheodoi_TextChanged);
            this.tentheodoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentheodoi_KeyDown);
            // 
            // theodoi
            // 
            this.theodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.theodoi.Enabled = false;
            this.theodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi.Location = new System.Drawing.Point(288, 249);
            this.theodoi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.theodoi.MaxLength = 9;
            this.theodoi.Name = "theodoi";
            this.theodoi.Size = new System.Drawing.Size(36, 21);
            this.theodoi.TabIndex = 15;
            this.theodoi.Validated += new System.EventHandler(this.theodoi_Validated);
            // 
            // label133
            // 
            this.label133.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(170, 252);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(112, 16);
            this.label133.TabIndex = 481;
            this.label133.Text = "Người theo dõi :";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(680, 544);
            this.listNv1.MatchBufferTimeOut = 1000;
            this.listNv1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv1.Name = "listNv1";
            this.listNv1.Size = new System.Drawing.Size(75, 17);
            this.listNv1.TabIndex = 482;
            this.listNv1.TextIndex = -1;
            this.listNv1.TextMember = null;
            this.listNv1.ValueIndex = -1;
            this.listNv1.Visible = false;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(192, 77);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(152, 17);
            this.label31.TabIndex = 483;
            this.label31.Text = "DIỄN BIẾN CHUYỂN DẠ :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(192, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 17);
            this.label8.TabIndex = 484;
            this.label8.Text = "DIỄN BIẾN SỔ THAI :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(192, 465);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 17);
            this.label13.TabIndex = 485;
            this.label13.Text = "TÌNH TRẠNG MẸ SAU SỔ THAI :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(439, 486);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 38;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(559, 486);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 39;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(703, 486);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 40;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(287, 486);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 37;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label149
            // 
            this.label149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label149.Location = new System.Drawing.Point(320, 486);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(48, 19);
            this.label149.TabIndex = 11;
            this.label149.Text = "lần/phút";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label150.Location = new System.Drawing.Point(472, 489);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 13;
            this.label150.Text = "°C";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label151.Location = new System.Drawing.Point(608, 489);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(38, 16);
            this.label151.TabIndex = 16;
            this.label151.Text = "mmHg";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label152.Location = new System.Drawing.Point(736, 489);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(48, 16);
            this.label152.TabIndex = 18;
            this.label152.Text = "lần/phút";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label155
            // 
            this.label155.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(648, 489);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(56, 16);
            this.label155.TabIndex = 6;
            this.label155.Text = "Nhịp thở :";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label156
            // 
            this.label156.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(496, 489);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(64, 16);
            this.label156.TabIndex = 5;
            this.label156.Text = "Huyết áp :";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label157
            // 
            this.label157.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(376, 489);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(56, 16);
            this.label157.TabIndex = 4;
            this.label157.Text = "Nhiệt độ :";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(242, 489);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(40, 16);
            this.label158.TabIndex = 3;
            this.label158.Text = "Mạch :";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theodoi_pass
            // 
            this.theodoi_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi_pass.Enabled = false;
            this.theodoi_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi_pass.Location = new System.Drawing.Point(696, 249);
            this.theodoi_pass.Name = "theodoi_pass";
            this.theodoi_pass.PasswordChar = '*';
            this.theodoi_pass.Size = new System.Drawing.Size(88, 21);
            this.theodoi_pass.TabIndex = 17;
            this.theodoi_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // chkXml
            // 
            this.chkXml.Location = new System.Drawing.Point(8, 528);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(96, 16);
            this.chkXml.TabIndex = 486;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // nhiptho1
            // 
            this.nhiptho1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho1.Enabled = false;
            this.nhiptho1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho1.Location = new System.Drawing.Point(744, 95);
            this.nhiptho1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho1.MaxLength = 5;
            this.nhiptho1.Name = "nhiptho1";
            this.nhiptho1.Size = new System.Drawing.Size(32, 21);
            this.nhiptho1.TabIndex = 5;
            this.nhiptho1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach1
            // 
            this.mach1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach1.Enabled = false;
            this.mach1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach1.Location = new System.Drawing.Point(456, 95);
            this.mach1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach1.MaxLength = 5;
            this.mach1.Name = "mach1";
            this.mach1.Size = new System.Drawing.Size(32, 21);
            this.mach1.TabIndex = 2;
            this.mach1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(416, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 487;
            this.label16.Text = "Mạch :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(489, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 19);
            this.label17.TabIndex = 491;
            this.label17.Text = "l/p";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(504, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 488;
            this.label18.Text = "T° :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo1
            // 
            this.nhietdo1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo1.Enabled = false;
            this.nhietdo1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo1.Location = new System.Drawing.Point(528, 95);
            this.nhietdo1.Mask = "##.##";
            this.nhietdo1.Name = "nhietdo1";
            this.nhietdo1.Size = new System.Drawing.Size(32, 21);
            this.nhietdo1.TabIndex = 3;
            this.nhietdo1.Text = "  .  ";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label28.Location = new System.Drawing.Point(560, 97);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 16);
            this.label28.TabIndex = 492;
            this.label28.Text = "°C";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(584, 97);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(32, 16);
            this.label29.TabIndex = 489;
            this.label29.Text = "HA :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // huyetap1
            // 
            this.huyetap1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap1.Enabled = false;
            this.huyetap1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap1.Location = new System.Drawing.Point(616, 95);
            this.huyetap1.Mask = "###/###";
            this.huyetap1.Name = "huyetap1";
            this.huyetap1.Size = new System.Drawing.Size(40, 21);
            this.huyetap1.TabIndex = 4;
            this.huyetap1.Text = "   /   ";
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(656, 97);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 16);
            this.label30.TabIndex = 493;
            this.label30.Text = "mmHg";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(688, 97);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 16);
            this.label32.TabIndex = 490;
            this.label32.Text = "Nhịp thở :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(776, 104);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 494;
            this.label33.Text = "l/p";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 64);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(186, 440);
            this.dataGrid1.TabIndex = 499;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(72, 27);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 513;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(253, 27);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(70, 21);
            this.sovaovien.TabIndex = 521;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(181, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(72, 16);
            this.label34.TabIndex = 520;
            this.label34.Text = "Số vào viện :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(72, 50);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(709, 21);
            this.chandoan.TabIndex = 519;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(369, 27);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 511;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(709, 27);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(72, 21);
            this.giuong.TabIndex = 518;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(581, 27);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 517;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(-6, 51);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(73, 16);
            this.label35.TabIndex = 516;
            this.label35.Text = "Chẩn đoán :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(661, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 515;
            this.label36.Text = "Giường :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(533, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 16);
            this.label38.TabIndex = 514;
            this.label38.Text = "Phòng :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(28, 28);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(39, 16);
            this.label41.TabIndex = 512;
            this.label41.Text = "Ngày :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(320, 28);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 16);
            this.label42.TabIndex = 510;
            this.label42.Text = "Số thẻ :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(536, 4);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(245, 21);
            this.diachi.TabIndex = 509;
            // 
            // gioitinh
            // 
            this.gioitinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gioitinh.Enabled = false;
            this.gioitinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gioitinh.Location = new System.Drawing.Point(456, 4);
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Size = new System.Drawing.Size(32, 21);
            this.gioitinh.TabIndex = 508;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(369, 4);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 507;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 4);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 506;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(72, 4);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 500;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(488, 6);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(48, 16);
            this.label43.TabIndex = 505;
            this.label43.Text = "Địa chỉ :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(400, 6);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 504;
            this.label45.Text = "Giới tính :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(336, 6);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(32, 16);
            this.label46.TabIndex = 503;
            this.label46.Text = "NS :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(128, 6);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(48, 16);
            this.label49.TabIndex = 502;
            this.label49.Text = "Họ tên :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(19, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(48, 16);
            this.label52.TabIndex = 501;
            this.label52.Text = "Mã BN :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(638, 514);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 47;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(498, 514);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 46;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(428, 514);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 45;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(358, 514);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 42;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(288, 514);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 41;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(218, 514);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 44;
            this.butSua.Text = "&Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(148, 514);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 43;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butBieudo
            // 
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(568, 514);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(70, 25);
            this.butBieudo.TabIndex = 522;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBieudo.Click += new System.EventHandler(this.butBieudo_Click);
            // 
            // frmBasosinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.gioitinh);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.nhietdo1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.nhiptho1);
            this.Controls.Add(this.mach1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.huyetap1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.ngoithai);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.theodoi_pass);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.cachthucde);
            this.Controls.Add(this.listNv1);
            this.Controls.Add(this.tentheodoi);
            this.Controls.Add(this.theodoi);
            this.Controls.Add(this.label133);
            this.Controls.Add(this.kieuthe);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tienluong);
            this.Controls.Add(this.ngaychuyenda);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.dolot);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tinhtrangoi);
            this.Controls.Add(this.label121);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.mo);
            this.Controls.Add(this.tucung);
            this.Controls.Add(this.timthai);
            this.Controls.Add(this.giochuyenda);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.label99);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label168);
            this.Controls.Add(this.tendt);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.xuly);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.conthu);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.duthang);
            this.Controls.Add(this.ditat);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.apgar10);
            this.Controls.Add(this.apgar5);
            this.Controls.Add(this.apgar1);
            this.Controls.Add(this.tuan);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.madt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.cao);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.vongdau);
            this.Controls.Add(this.label158);
            this.Controls.Add(this.label149);
            this.Controls.Add(this.label157);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.label150);
            this.Controls.Add(this.label156);
            this.Controls.Add(this.label151);
            this.Controls.Add(this.label155);
            this.Controls.Add(this.label152);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBasosinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diễn biến chuyển dạ";
            this.Load += new System.EventHandler(this.frmBasosinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBasosinh_Load(object sender, System.EventArgs e)
		{
			user=m.user;
            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv1.DisplayMember="MA";
			listNv1.ValueMember="HOTEN";
            listNv1.DataSource = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			ngoithai.DisplayMember="TEN";
			ngoithai.ValueMember="MA";
            ngoithai.DataSource = m.get_data("select * from " + user + ".dmngoithai order by stt").Tables[0];

			tendt.DisplayMember="TEN";
			tendt.ValueMember="MA";
            tendt.DataSource = m.get_data("select * from " + user + ".dmditat order by stt").Tables[0];

			cachthucde.DisplayMember="TEN";
			cachthucde.ValueMember="ID";
            cachthucde.DataSource = m.get_data("select * from " + user + ".dmkieusanh order by stt").Tables[0];

			s_msg=LibMedi.AccessData.Msg;
			songay=m.Ngaylv_Ngayht;
			ngay.Text=m.ngayhienhanh_server;
			ngaychuyenda.Text=ngay.Text.Substring(0,10);
			giochuyenda.Text=ngay.Text.Substring(11);
			tinhtrangoi.SelectedIndex=0;
			//ena_object(tinhtrangoi.SelectedIndex==3);

			load_grid();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

			ref_text();
		}

		private void load_grid()
		{
			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.theodoi,c.hoten as tenbs,c.password_ from xxx.ba_dbchuyenda a,xxx.ba_thuchien b," + user + ".dmbs c where a.idthuchien=b.id and a.theodoi=c.ma and b.idkhoa=" + l_idkhoa;
			sql+=" order by a.id";
			ds=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "In";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenbs";
			TextCol1.HeaderText = "Bác sĩ";
			TextCol1.Width = 150;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}				
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			ref_text();
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
		}

		private void ref_text()
		{
			try
			{
				int i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
				string _ngay=dataGrid1[i_row,2].ToString();
				ngaychuyenda.Text=_ngay.Substring(0,10);
				giochuyenda.Text=_ngay.Substring(11);
				load_data();
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
			if (ngay.Text.Length<16)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ sinh !"),s_msg);
				ngay.Focus();
				return;
			}
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngay.Focus();
				return;
			}
			ngay.Text=m.Ktngaygio(ngay.Text,16);
			if (ngay.Text!=ngayvv.Text)
			{
				if (!m.bNgaygio(ngay.Text,ngayvv.Text))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày sinh không được nhỏ hơn ngày đẻ (mổ đẻ) !"),s_msg);
					ngay.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày sinh không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngay.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tinhtrang.SelectedIndex==-1) tinhtrang.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ditat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (ditat.SelectedIndex==-1) ditat.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}	
		}

		private bool kiemtra()
		{
			if (tinhtrangoi.SelectedIndex==3)
			{
				if (ngay.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
					ngay.Focus();
					return false;
				}
				if (ngoithai.SelectedIndex==-1)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập ngôi thai !"),s_msg);
					ngoithai.Focus();
					return false;
				}

				if (cachthucde.SelectedIndex==-1)
				{
					cachthucde.Focus();
					return false;
				}
				if (phai.SelectedIndex==-1)
				{
					phai.Focus();
					return false;
				}

				if (tinhtrang.SelectedIndex==-1)
				{
					tinhtrang.Focus();
					return false;
				}

				if (ditat.SelectedIndex==-1)
				{
					ditat.Focus();
					return false;
				}
				else if (ditat.SelectedIndex==1 && madt.Text=="")
				{
					madt.Focus();
					return false;
				}

				if (cannang.Text=="" || cannang.Text=="0")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập cân nặng !"),s_msg);
					cannang.Focus();
					return false;
				}
				if (conthu.Value==0)
				{
					conthu.Focus();
					return false;
				}
			}
			if (theodoi.Text=="" || tentheodoi.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Tên người theo dõi không hợp lệ !"),LibMedi.AccessData.Msg);
				if (theodoi.Text=="") theodoi.Focus();
				else tentheodoi.Focus();
				return false;
			}
			if (theodoi.Text!="" && tentheodoi.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Tên người theo dõi không hợp lệ !"),LibMedi.AccessData.Msg);
					theodoi.Focus();
					return false;
				}
				if (!bAdmin)
				{
					if (theodoi_pass.Text!=r["password_"].ToString())
					{
						MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu tên người theo dõi chưa hợp lệ !"),LibMedi.AccessData.Msg);
						theodoi_pass.Focus();
						return false;
					}
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngaychuyenda.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngaychuyenda.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngaychuyenda.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-308);
			m.upd_ba_dbchuyenda(l_id,l_idthuchien,ngaychuyenda.Text+" "+giochuyenda.Text,(mach1.Text!="")?decimal.Parse(mach1.Text):0,huyetap1.Text,(nhietdo1.Text!="")?decimal.Parse(nhietdo1.Text):0,(nhiptho1.Text!="")?decimal.Parse(nhiptho1.Text):0,(timthai.Text!="")?decimal.Parse(timthai.Text):0,tucung.Text,(mo.Text!="")?decimal.Parse(mo.Text):0,(xoa.Text!="")?decimal.Parse(xoa.Text):0,tinhtrangoi.SelectedIndex,ngoithai.SelectedValue.ToString(),dolot.Text,tienluong.Text,xutri.Text,theodoi.Text,i_userid);
			if (tinhtrangoi.SelectedIndex==3)
			{
				m.upd_ddsosinh(mabn.Text,l_id,(apgar1.Text!="")?int.Parse(apgar1.Text):0,(apgar5.Text!="")?int.Parse(apgar5.Text):0,(apgar10.Text!="")?int.Parse(apgar10.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,(cao.Text!="")?int.Parse(cao.Text):0,(vongdau.Text!="")?int.Parse(vongdau.Text):0,"","",Convert.ToInt16(conthu.Value),"",(duthang.Checked)?1:0,Convert.ToInt16(thang.Value),Convert.ToInt16(tuan.Value),(ditat.SelectedIndex==1)?madt.Text:"","",int.Parse(cachthucde.SelectedValue.ToString()));//,xuly.Text,kieuthe.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,huyetap.Text,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0);
				m.upd_tresosinh(l_id,l_maql,ngay.Text,ngoithai.SelectedValue.ToString(),phai.SelectedIndex,tinhtrang.SelectedIndex,ditat.SelectedIndex,int.Parse(cannang.Text),i_userid);
			}
			upd_items();
			ena_object1(false);
			ena_object(false);
			butMoi.Focus();
		}

		private void upd_items()
		{
			DataRow r1,r2;
			r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r1==null)
			{
				r2=ds.Tables[0].NewRow();
				r2["id"]=l_id;
				r2["idthuchien"]=l_idthuchien;
				r2["ngay"]=ngaychuyenda.Text+" "+giochuyenda.Text;
				r2["theodoi"]=theodoi.Text;
				r2["tenbs"]=tentheodoi.Text;
				r2["password_"]=theodoi_pass.Text;
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngaychuyenda.Text+" "+giochuyenda.Text;
				dr[0]["theodoi"]=theodoi.Text;
				dr[0]["tenbs"]=tentheodoi.Text;
				dr[0]["password_"]=theodoi_pass.Text;
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object1(false);
			ena_object(false);
			if (l_id!=0) load_data();
			butMoi.Focus();
		}

		private void ngoithai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ngoithai.SelectedIndex==-1 && ngoithai.Items.Count>0) ngoithai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void load_data()
		{
			xxx=user+m.mmyy(ngaychuyenda.Text);
			sql="select to_char(f.ngay,'dd/mm/yyyy hh24:mi') as ngaychuyenda,f.timthai,f.tucung,f.mo,f.xoa,f.tinhtrangoi,";
			sql+="f.ngoithai,f.dolot,f.tienluong,f.xutri,f.theodoi,f.mach as mach1,f.huyetap as huyetap1,f.nhietdo as nhietdo1,f.nhiptho as nhiptho1,";
			sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,nvl(a.cannang,0) as cannang,nvl(a.phai,0) as phai,nvl(a.tinhtrang,0) as tinhtrang,nvl(a.ditat,0) as ditat,";
			sql+="nvl(c.apgar1,0) as apgar1,nvl(c.apgar5,0) as apgar5,nvl(c.apgar10,0) as apgar10,nvl(c.conthu,0) as conthu,nvl(c.duthang,0) as duthang,nvl(c.thang,0) as thang,nvl(c.tuan,0) as tuan,nvl(c.cachthucde,0) as cachthucde,c.xuly,";
			sql+="nvl(c.cao,0) as cao,nvl(c.vongdau,0) as vongdau,nvl(c.ditatbs,0) as ditatbs,c.kieuthe,nvl(c.mach,0) as mach,c.huyetap,nvl(c.nhietdo,0) as nhietdo,nvl(c.nhiptho,0) as nhiptho ";
            sql += " from " + user + ".tresosinh a," + user + ".ddsosinh c," + xxx + ".ba_dbchuyenda f";
			sql+=" where f.id=a.id_ss(+) and f.id=c.maql(+) and f.id="+l_id;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				ngaychuyenda.Text=r["ngaychuyenda"].ToString().Substring(0,10);
				giochuyenda.Text=r["ngaychuyenda"].ToString().Substring(11);
				mach1.Text=(r["mach1"].ToString()=="0")?"":r["mach1"].ToString();
				nhietdo1.Text=(r["nhietdo1"].ToString()=="0")?"":r["nhietdo1"].ToString();
				huyetap1.Text=r["huyetap1"].ToString();
				nhiptho1.Text=(r["nhiptho1"].ToString()=="0")?"":r["nhiptho1"].ToString();
				timthai.Text=(r["timthai"].ToString()=="0")?"":r["timthai"].ToString();
				ngoithai.SelectedValue=r["ngoithai"].ToString();
				tucung.Text=r["tucung"].ToString();
				mo.Text=(r["mo"].ToString()=="0")?"":r["mo"].ToString();
				xoa.Text=(r["xoa"].ToString()=="0")?"":r["xoa"].ToString();
				tinhtrangoi.SelectedIndex=int.Parse(r["tinhtrangoi"].ToString());
				dolot.Text=r["dolot"].ToString();
				tienluong.Text=r["tienluong"].ToString();
				xutri.Text=r["xutri"].ToString();
				theodoi.Text=r["theodoi"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+r["theodoi"].ToString()+"'");
				if (r1!=null)
				{
					tentheodoi.Text=r1["hoten"].ToString();
					theodoi_pass.Text=r1["password_"].ToString();
				}
				if (tinhtrangoi.SelectedIndex==3)
				{
					ngay.Text=r["ngay"].ToString();					
					phai.SelectedIndex=int.Parse(r["phai"].ToString());
					tinhtrang.SelectedIndex=int.Parse(r["tinhtrang"].ToString());
					ditat.SelectedIndex=int.Parse(r["ditat"].ToString());
					apgar1.Text=(r["apgar1"].ToString()=="0")?"":r["apgar1"].ToString();
					apgar5.Text=(r["apgar5"].ToString()=="0")?"":r["apgar5"].ToString();
					apgar10.Text=(r["apgar10"].ToString()=="0")?"":r["apgar10"].ToString();
					cannang.Text=(r["cannang"].ToString()=="0")?"":r["cannang"].ToString();
					cao.Text=(r["cao"].ToString()=="0")?"":r["cao"].ToString();
					vongdau.Text=(r["vongdau"].ToString()=="0")?"":r["vongdau"].ToString();
					conthu.Value=int.Parse(r["conthu"].ToString());
					duthang.Checked=r["duthang"].ToString()=="1";
					thang.Value=int.Parse(r["thang"].ToString());
					tuan.Value=int.Parse(r["tuan"].ToString());
					madt.Text=r["ditatbs"].ToString();
					tendt.SelectedValue=madt.Text;
					cachthucde.SelectedValue=r["cachthucde"].ToString();
					xuly.Text=r["xuly"].ToString();
					kieuthe.Text=r["kieuthe"].ToString();
					mach.Text=(r["mach"].ToString()=="0")?"":r["mach"].ToString();
					nhietdo.Text=(r["nhietdo"].ToString()=="0")?"":r["nhietdo"].ToString();
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()=="0")?"":r["nhiptho"].ToString();
				}
				else
				{
					kieuthe.Text="";duthang.Checked=true;
					apgar1.Text="";apgar5.Text="";apgar10.Text="";cannang.Text="";cao.Text="";
					vongdau.Text="";xuly.Text="";thang.Value=0;tuan.Value=0;
					mach.Text="";huyetap.Text="";nhietdo.Text="";nhiptho.Text="";
				}
				if (butLuu.Enabled) ena_object(tinhtrangoi.SelectedIndex==3);
				break;
			}
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			phai.Enabled=ena;
			tinhtrang.Enabled=ena;
			ditat.Enabled=ena;
			apgar1.Enabled=ena;
			apgar5.Enabled=ena;
			apgar10.Enabled=ena;
			cannang.Enabled=ena;
			cao.Enabled=ena;
			vongdau.Enabled=ena;
			conthu.Enabled=ena;
			duthang.Enabled=ena;
			madt.Enabled=ena;
			tendt.Enabled=ena;
			cachthucde.Enabled=ena;
			xuly.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			nhiptho.Enabled=ena;
			kieuthe.Enabled=ena;
			ngoithai.Enabled=ena;
			dolot.Enabled=ena;
		}

		private void ena_object1(bool ena)
		{
			ngaychuyenda.Enabled=ena;
			giochuyenda.Enabled=ena;
			mach1.Enabled=ena;
			huyetap1.Enabled=ena;
			nhietdo1.Enabled=ena;
			nhiptho1.Enabled=ena;
			timthai.Enabled=ena;
			tucung.Enabled=ena;
			mo.Enabled=ena;
			xoa.Enabled=ena;
			tinhtrangoi.Enabled=ena;
			dolot.Enabled=ena;
			tienluong.Enabled=ena;
			xutri.Enabled=ena;
			theodoi.Enabled=ena;
			tentheodoi.Enabled=ena;
			theodoi_pass.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butBieudo.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void cannang_Validated(object sender, System.EventArgs e)
		{
			if (cannang.Text=="" || cannang.Text=="0") cannang.Focus();
		}

		private void conthu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendt.SelectedValue=madt.Text;
			}
			catch{}
		}

		private void tendt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendt) madt.Text=tendt.SelectedValue.ToString();
		}

		private void tendt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tendt.SelectedIndex==-1 && tendt.Items.Count>0) tendt.SelectedIndex=0;
				madt.Text=tendt.SelectedValue.ToString();
				SendKeys.Send("{Tab}");
			}
		}

		private void ditat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ditat)
			{
				madt.Enabled=ditat.SelectedIndex==1;
				tendt.Enabled=madt.Enabled;
			}
		}

		private void duthang_CheckedChanged(object sender, System.EventArgs e)
		{
			thang.Enabled=!duthang.Checked;
			tuan.Enabled=thang.Enabled;
		}

		private void thang_ValueChanged(object sender, System.EventArgs e)
		{
			tuan.Enabled=thang.Value==0;
		}

		private void madt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");		
		}

		private void cachthucde_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cachthucde.SelectedIndex==-1 && cachthucde.Items.Count>0) cachthucde.SelectedIndex=0;
				SendKeys.Send("{Tab}");
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
				listNv1.BrowseToDanhmuc(tentheodoi,theodoi,theodoi_pass,35);
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

		private void giochuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giochuyenda.Text!="")
				{
					string sgio=(giochuyenda.Text.Trim()=="")?"00:00":giochuyenda.Text.Trim();
					giochuyenda.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giochuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giochuyenda.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void ngaychuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngaychuyenda.Text!="")
				{
					ngaychuyenda.Text=ngaychuyenda.Text.Trim();
					if (ngaychuyenda.Text.Length==6) ngaychuyenda.Text=ngaychuyenda.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngaychuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngaychuyenda.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void tinhtrangoi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tinhtrangoi) ena_object(tinhtrangoi.SelectedIndex==3);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_id="";
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_id+=r1["id"].ToString()+",";
			sql="select to_char(f.ngay,'dd/mm/yyyy hh24:mi') as ngaychuyenda,f.timthai,f.tucung,f.mo,f.xoa,f.tinhtrangoi,";
			sql+="f.ngoithai,f.dolot,f.tienluong,f.xutri,f.theodoi,";
			sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,nvl(a.cannang,0) as cannang,nvl(a.phai,0) as phai,nvl(a.tinhtrang,0) as tinhtrang,nvl(a.ditat,0) as ditat,";
			sql+="nvl(c.apgar1,0) as apgar1,nvl(c.apgar5,0) as apgar5,nvl(c.apgar10,0) as apgar10,nvl(c.conthu,0) as conthu,nvl(c.duthang,0) as duthang,nvl(c.thang,0) as thang,nvl(c.tuan,0) as tuan,nvl(c.cachthucde,0) as cachthucde,c.xuly,";
			sql+="nvl(c.cao,0) as cao,nvl(c.vongdau,0) as vongdau,nvl(c.ditatbs,0) as ditatbs,c.kieuthe,nvl(c.mach,0) as mach,c.huyetap,nvl(c.nhietdo,0) as nhietdo,nvl(c.nhiptho,0) as nhiptho,";
			sql+="b.hoten as tentheodoi,b.image,'' as tenditat,'' as tenngoithai,'' as tencachthucde,";
			sql+="'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as gioitinh,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,";
			sql+="nvl(f.mach,0) as mach1,f.huyetap as huyetap1,nvl(f.nhietdo,0) as nhietdo1,nvl(f.nhiptho,0) as nhiptho1 ";
            sql += " from " + user + ".tresosinh a," + user + ".ddsosinh c,xxx.ba_dbchuyenda f," + user + ".dmbs b,xxx.ba_thuchien e";
			sql+=" where f.idthuchien=e.id and f.id=a.id_ss(+) and f.id=c.maql(+) and f.theodoi=b.ma and e.idkhoa="+l_idkhoa;
			if (s_id!="") sql+=" and f.id in ("+s_id.Substring(0,s_id.Length-1)+")";
			sql+=" order by f.ngay ";
			DataSet dsxml=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);

			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["tuoi"]=m.get_tuoivao(l_maql);
				r["gioitinh"]=gioitinh.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
				r["tenditat"]=tendt.Text;
				r["tenngoithai"]=ngoithai.Text;
				r["tencachthucde"]=cachthucde.Text;
			}
			if (chkXml.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\dbchuyenda.xml",XmlWriteMode.WriteSchema);
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","r39bv_Chuyenda.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngaychuyenda.Text=_ngay.Substring(0,10);
			giochuyenda.Text=_ngay.Substring(11);
			mach1.Text="";nhietdo1.Text="";huyetap1.Text="";nhiptho1.Text="";
			timthai.Text="";tucung.Text="";mo.Text="";xoa.Text="";
			dolot.Text="";tienluong.Text="";xutri.Text="";tinhtrangoi.SelectedIndex=0;
			kieuthe.Text="";duthang.Checked=true;madt.Text="";tendt.SelectedIndex=-1;
			apgar1.Text="";apgar5.Text="";apgar10.Text="";cannang.Text="";cao.Text="";
			vongdau.Text="";xuly.Text="";thang.Value=0;tuan.Value=0;
			mach.Text="";huyetap.Text="";nhietdo.Text="";nhiptho.Text="";
			theodoi.Text="";tentheodoi.Text="";theodoi_pass.Text="";
			if (s_mabs!="")
			{
				theodoi.Text=s_mabs;
				DataRow r1=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r1!=null) 
				{
					tentheodoi.Text=r1["hoten"].ToString();
					theodoi_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tentheodoi.Text="";theodoi_pass.Text="";
				}
				if (theodoi.Text!="" && tentheodoi.Text!="" && !bAdmin)
				{
					theodoi.Enabled=false;tentheodoi.Enabled=false;
				}
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object1(true);
			emp_text();
			ngaychuyenda.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object1(true);
			ena_object(tinhtrangoi.SelectedIndex==3);
			ngaychuyenda.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(ngaychuyenda.Text);
				m.execute_data("delete from "+xxx+".ba_hausangan where id="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				ref_text();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butBieudo_Click(object sender, System.EventArgs e)
		{
			sql="select '' as soyte,'' as benhvien,'' as khoaphong,'' as sovaovien,'' as hoten,'' as mabn,";
			sql+="'' as namsinh,'' as lanthai,'' as lande,'' as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql+="'' as oivo,'' as maicd,'' as chandoan,a.mach,a.nhietdo,a.huyetap,a.timthai as nhiptim,a.mo as domotc,";
			sql+="'1' as soconco,a.tienluong as dienbien,a.xutri,a.xutri as ketqua,";
			sql+="c.hoten as theodoi,c.hoten as ghibdcd ";
            sql += " from xxx.ba_dbchuyenda a,xxx.ba_thuchien b," + user + ".dmbs c ";
			sql+=" where a.idthuchien=b.id and a.theodoi=c.ma and b.idkhoa="+l_idkhoa;
			sql+=" and a.mo>2 order by a.id";
			DataSet dsxml=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["soyte"]=m.Syte;
				r["benhvien"]=m.Tenbv;
				r["khoaphong"]=s_tenkp;
				r["sovaovien"]=sovaovien.Text;
				r["hoten"]=hoten.Text;
				r["mabn"]=mabn.Text;
				r["namsinh"]=namsinh.Text;
				r["lanthai"]=conthu.Value.ToString();
				r["lande"]=conthu.Value.ToString();
				r["ngayvv"]=ngayvv.Text;
				r["oivo"]=ngay.Text;
				r["chandoan"]=chandoan.Text;
			}
			dsxml.WriteXml("..\\..\\..\\xml\\dausinhton.xml",XmlWriteMode.WriteSchema);
			Chuyenda.frmBieudosinhton f=new Chuyenda.frmBieudosinhton();
			f.ShowDialog();
		}

	}
}
