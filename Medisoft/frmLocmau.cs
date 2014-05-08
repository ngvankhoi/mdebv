using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	public class frmLocmau : System.Windows.Forms.Form
    {
        #region Khai bao
        private Language lan = new Language();
        private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox ngayvv;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox ngay;
		private System.ComponentModel.IContainer components;
		private DataSet ds=new DataSet();
		private DataSet dsh=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private DataTable dtlinh=new DataTable();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_userid,i_stt=0;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true,bAdmin;
		private int checkCol=0;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lgio;
		private System.Windows.Forms.TextBox tenyta;
		private MaskedTextBox.MaskedTextBox yta;
		private System.Windows.Forms.Label label21;
		private MaskedBox.MaskedBox gio_kt;
		private MaskedBox.MaskedBox ngay_kt;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox cmbngay;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private MaskedBox.MaskedBox gio_ct;
		private MaskedBox.MaskedBox ngay_ct;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label17;
		private MaskedTextBox.MaskedTextBox cantloc;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private MaskedTextBox.MaskedTextBox rutnuoc;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private MaskedTextBox.MaskedTextBox cansloc;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.CheckBox fav;
		private System.Windows.Forms.CheckBox ttmd;
		private System.Windows.Forms.CheckBox mtct;
		private System.Windows.Forms.CheckBox tmdd;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox heparin;
		private System.Windows.Forms.CheckBox tlpt;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.CheckBox cachquang;
		private System.Windows.Forms.CheckBox lientuc;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private MaskedTextBox.MaskedTextBox mabsll;
		private System.Windows.Forms.TextBox tenbsll;
		private MaskedTextBox.MaskedTextBox ytall;
		private System.Windows.Forms.TextBox tenytall;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedBox.MaskedBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.TextBox dm;
		private MaskedTextBox.MaskedTextBox tocdo;
		private System.Windows.Forms.TextBox lieudau;
		private System.Windows.Forms.TextBox duytri;
		private System.Windows.Forms.TextBox tonglieu;
		private System.Windows.Forms.TextBox khac;
		private System.Windows.Forms.TextBox mangloc;
		private System.Windows.Forms.TextBox nhanhieu;
		private System.Windows.Forms.TextBox dientich;
		private System.Windows.Forms.TextBox heso;
		private System.Windows.Forms.TextBox baoquan;
		private System.Windows.Forms.NumericUpDown landung;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox tm;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label37;
		private MaskedTextBox.MaskedTextBox sieuloc;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox taibien;
		private System.Windows.Forms.TextBox thuoc;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Panel panel15;
		private MaskedTextBox.MaskedTextBox dichvamau;
		private System.Windows.Forms.CheckBox chkXML;
        private bool bbadt = false;
        #endregion

        public frmLocmau(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
		}
        public frmLocmau(LibMedi.AccessData acc, string _mabn, decimal _maql, decimal _idkhoa, string _sovaovien, string _makp, string _hoten, string _namsinh, string _phai, string _diachi, string _ngayvv, string _sothe, string _phong, string _giuong, string _ngayrv, string _mabs, int _userid, string _nhomkho, string suserid, string _chandoan, string _tenkp, bool _admin,bool _badt)
        {
            InitializeComponent();
            m = acc; mabn.Text = _mabn; l_maql = _maql; l_idkhoa = _idkhoa; sovaovien.Text = _sovaovien; i_userid = _userid; s_tenkp = _tenkp;
            hoten.Text = _hoten; chandoan.Text = _chandoan; s_makp = _makp; namsinh.Text = _namsinh; phai.Text = _phai; diachi.Text = _diachi; s_mabs = _mabs; s_nhomkho = _nhomkho;
            ngayvv.Text = _ngayvv; sothe.Text = _sothe; phong.Text = _phong; giuong.Text = _giuong; s_ngayrv = _ngayrv; s_userid = suserid; bAdmin = _admin;
            bbadt = _badt;
        }

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocmau));
            this.chandoan = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.phong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.gio = new MaskedBox.MaskedBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.lgio = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listNv = new LibList.List();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.tenyta = new System.Windows.Forms.TextBox();
            this.yta = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gio_ct = new MaskedBox.MaskedBox();
            this.ngay_ct = new MaskedBox.MaskedBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gio_kt = new MaskedBox.MaskedBox();
            this.ngay_kt = new MaskedBox.MaskedBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbngay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.mabsll = new MaskedTextBox.MaskedTextBox();
            this.tenbsll = new System.Windows.Forms.TextBox();
            this.ytall = new MaskedTextBox.MaskedTextBox();
            this.tenytall = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedBox.MaskedBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.dm = new System.Windows.Forms.TextBox();
            this.tocdo = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cantloc = new MaskedTextBox.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.rutnuoc = new MaskedTextBox.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.dichvamau = new MaskedTextBox.MaskedTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cansloc = new MaskedTextBox.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.fav = new System.Windows.Forms.CheckBox();
            this.ttmd = new System.Windows.Forms.CheckBox();
            this.mtct = new System.Windows.Forms.CheckBox();
            this.tmdd = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.heparin = new System.Windows.Forms.CheckBox();
            this.tlpt = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cachquang = new System.Windows.Forms.CheckBox();
            this.lientuc = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.lieudau = new System.Windows.Forms.TextBox();
            this.duytri = new System.Windows.Forms.TextBox();
            this.tonglieu = new System.Windows.Forms.TextBox();
            this.khac = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.mangloc = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.nhanhieu = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.dientich = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.heso = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.baoquan = new System.Windows.Forms.TextBox();
            this.landung = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tm = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.sieuloc = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.taibien = new System.Windows.Forms.TextBox();
            this.thuoc = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.landung)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(75, 49);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(517, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(372, 26);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(220, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(778, 26);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(109, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(640, 26);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(728, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(592, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(75, 26);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(539, 3);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(349, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(459, 3);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(372, 3);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(184, 3);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(75, 3);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(69, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(491, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(403, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Số vào viện :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(256, 26);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(778, 49);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 2;
            this.gio.Text = "  :  ";
            this.gio.Visible = false;
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(640, 49);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 1;
            this.ngay.Text = "  /  /    ";
            this.ngay.Visible = false;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // lgio
            // 
            this.lgio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgio.Location = new System.Drawing.Point(744, 52);
            this.lgio.Name = "lgio";
            this.lgio.Size = new System.Drawing.Size(32, 16);
            this.lgio.TabIndex = 302;
            this.lgio.Text = "Giờ :";
            this.lgio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgio.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(307, 388);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(221, 21);
            this.tenbs.TabIndex = 26;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(264, 388);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 25;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(160, 390);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(104, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ chỉ định :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 248);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(879, 136);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(163, 543);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 41;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(233, 543);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 42;
            this.butSua.Text = "     &Sữa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(303, 543);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 61;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(513, 543);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 43;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(583, 543);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 44;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(653, 543);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 45;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(723, 543);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 46;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(760, 584);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 311;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            this.listNv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listNv_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(8, 548);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 313;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // tenyta
            // 
            this.tenyta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenyta.Enabled = false;
            this.tenyta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenyta.Location = new System.Drawing.Point(690, 388);
            this.tenyta.Name = "tenyta";
            this.tenyta.Size = new System.Drawing.Size(192, 21);
            this.tenyta.TabIndex = 28;
            this.tenyta.TextChanged += new System.EventHandler(this.tenyta_TextChanged);
            this.tenyta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // yta
            // 
            this.yta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.yta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.yta.Enabled = false;
            this.yta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yta.Location = new System.Drawing.Point(648, 388);
            this.yta.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.yta.MaxLength = 9;
            this.yta.Name = "yta";
            this.yta.Size = new System.Drawing.Size(41, 21);
            this.yta.TabIndex = 27;
            this.yta.Validated += new System.EventHandler(this.yta_Validated);
            this.yta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(458, 390);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 16);
            this.label14.TabIndex = 319;
            this.label14.Text = "Điều dưỡng thực hiện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio_ct
            // 
            this.gio_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_ct.Enabled = false;
            this.gio_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_ct.Location = new System.Drawing.Point(137, 388);
            this.gio_ct.Mask = "##:##";
            this.gio_ct.Name = "gio_ct";
            this.gio_ct.Size = new System.Drawing.Size(40, 21);
            this.gio_ct.TabIndex = 24;
            this.gio_ct.Text = "  :  ";
            this.gio_ct.Validated += new System.EventHandler(this.gio_ct_Validated);
            // 
            // ngay_ct
            // 
            this.ngay_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_ct.Enabled = false;
            this.ngay_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_ct.Location = new System.Drawing.Point(65, 388);
            this.ngay_ct.Mask = "##/##/####";
            this.ngay_ct.Name = "ngay_ct";
            this.ngay_ct.Size = new System.Drawing.Size(70, 21);
            this.ngay_ct.TabIndex = 23;
            this.ngay_ct.Text = "  /  /    ";
            this.ngay_ct.Validated += new System.EventHandler(this.ngay_ct_Validated);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(17, 390);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 16);
            this.label21.TabIndex = 332;
            this.label21.Text = "Ngày :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio_kt
            // 
            this.gio_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_kt.Enabled = false;
            this.gio_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_kt.Location = new System.Drawing.Point(681, 78);
            this.gio_kt.Mask = "##:##";
            this.gio_kt.Name = "gio_kt";
            this.gio_kt.Size = new System.Drawing.Size(40, 21);
            this.gio_kt.TabIndex = 47;
            this.gio_kt.Text = "  :  ";
            this.gio_kt.Validated += new System.EventHandler(this.gio_kt_Validated);
            // 
            // ngay_kt
            // 
            this.ngay_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_kt.Enabled = false;
            this.ngay_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_kt.Location = new System.Drawing.Point(723, 78);
            this.ngay_kt.Mask = "##/##/####";
            this.ngay_kt.Name = "ngay_kt";
            this.ngay_kt.Size = new System.Drawing.Size(72, 21);
            this.ngay_kt.TabIndex = 48;
            this.ngay_kt.Text = "  /  /    ";
            this.ngay_kt.Validated += new System.EventHandler(this.ngay_kt_Validated);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(607, 79);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 336;
            this.label23.Text = "Giờ kết thúc :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbngay
            // 
            this.cmbngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbngay.Location = new System.Drawing.Point(640, 49);
            this.cmbngay.Name = "cmbngay";
            this.cmbngay.Size = new System.Drawing.Size(248, 21);
            this.cmbngay.TabIndex = 0;
            this.cmbngay.SelectedIndexChanged += new System.EventHandler(this.cmbngay_SelectedIndexChanged);
            this.cmbngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(600, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 339;
            this.label9.Text = "Ngày :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(443, 543);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 40;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(373, 543);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 39;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(8, 244);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 16);
            this.label35.TabIndex = 376;
            this.label35.Text = "BS chỉ định :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mabsll
            // 
            this.mabsll.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsll.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabsll.Enabled = false;
            this.mabsll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsll.Location = new System.Drawing.Point(75, 242);
            this.mabsll.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabsll.MaxLength = 9;
            this.mabsll.Name = "mabsll";
            this.mabsll.Size = new System.Drawing.Size(38, 21);
            this.mabsll.TabIndex = 19;
            this.mabsll.Validated += new System.EventHandler(this.mabsll_Validated);
            this.mabsll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenbsll
            // 
            this.tenbsll.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsll.Enabled = false;
            this.tenbsll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsll.Location = new System.Drawing.Point(115, 242);
            this.tenbsll.Name = "tenbsll";
            this.tenbsll.Size = new System.Drawing.Size(309, 21);
            this.tenbsll.TabIndex = 20;
            this.tenbsll.TextChanged += new System.EventHandler(this.tenbsll_TextChanged);
            this.tenbsll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ytall
            // 
            this.ytall.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ytall.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ytall.Enabled = false;
            this.ytall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytall.Location = new System.Drawing.Point(539, 242);
            this.ytall.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ytall.MaxLength = 9;
            this.ytall.Name = "ytall";
            this.ytall.Size = new System.Drawing.Size(38, 21);
            this.ytall.TabIndex = 21;
            this.ytall.Validated += new System.EventHandler(this.ytall_Validated);
            this.ytall.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenytall
            // 
            this.tenytall.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenytall.Enabled = false;
            this.tenytall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenytall.Location = new System.Drawing.Point(579, 242);
            this.tenytall.Name = "tenytall";
            this.tenytall.Size = new System.Drawing.Size(300, 21);
            this.tenytall.TabIndex = 22;
            this.tenytall.TextChanged += new System.EventHandler(this.tenytall_TextChanged);
            this.tenytall.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(366, 244);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(173, 16);
            this.label36.TabIndex = 383;
            this.label36.Text = "Điều dưỡng thực hiện :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(65, 488);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 31;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(65, 464);
            this.huyetap.Mask = "###/###";
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 30;
            this.huyetap.Text = "   /   ";
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(65, 512);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 32;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(65, 440);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 29;
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label50.Location = new System.Drawing.Point(13, 443);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(52, 16);
            this.label50.TabIndex = 418;
            this.label50.Text = "Mạch :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(105, 444);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(24, 16);
            this.label51.TabIndex = 414;
            this.label51.Text = "l/p";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(105, 493);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(24, 16);
            this.label53.TabIndex = 415;
            this.label53.Text = "°C";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label54.Location = new System.Drawing.Point(13, 468);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(52, 16);
            this.label54.TabIndex = 420;
            this.label54.Text = "HA :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(113, 467);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 16);
            this.label55.TabIndex = 416;
            this.label55.Text = "mmHg";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(105, 516);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(21, 16);
            this.label56.TabIndex = 417;
            this.label56.Text = "l/p";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label57.Location = new System.Drawing.Point(13, 514);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(52, 16);
            this.label57.TabIndex = 421;
            this.label57.Text = "Nhịp thở :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(13, 492);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(52, 16);
            this.label58.TabIndex = 422;
            this.label58.Text = "T° :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dm
            // 
            this.dm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dm.Enabled = false;
            this.dm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dm.Location = new System.Drawing.Point(264, 464);
            this.dm.Name = "dm";
            this.dm.Size = new System.Drawing.Size(136, 21);
            this.dm.TabIndex = 34;
            this.dm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tocdo
            // 
            this.tocdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tocdo.Enabled = false;
            this.tocdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tocdo.Location = new System.Drawing.Point(264, 440);
            this.tocdo.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.tocdo.MaxLength = 5;
            this.tocdo.Name = "tocdo";
            this.tocdo.Size = new System.Drawing.Size(104, 21);
            this.tocdo.TabIndex = 33;
            // 
            // label59
            // 
            this.label59.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label59.Location = new System.Drawing.Point(176, 440);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(88, 16);
            this.label59.TabIndex = 436;
            this.label59.Text = "Tốc độ máu :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(368, 445);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(32, 16);
            this.label60.TabIndex = 432;
            this.label60.Text = "ml/p";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(176, 464);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(88, 16);
            this.label66.TabIndex = 426;
            this.label66.Text = "Áp lực ĐM :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(15, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 441;
            this.label8.Text = "Trọng lượng khô :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 442;
            this.label17.Text = "Cân trước lọc :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cantloc
            // 
            this.cantloc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cantloc.Enabled = false;
            this.cantloc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantloc.Location = new System.Drawing.Point(95, 101);
            this.cantloc.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cantloc.Name = "cantloc";
            this.cantloc.Size = new System.Drawing.Size(64, 21);
            this.cantloc.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(161, 103);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 16);
            this.label24.TabIndex = 444;
            this.label24.Text = "kg";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 125);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 16);
            this.label25.TabIndex = 445;
            this.label25.Text = "Rút nước :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rutnuoc
            // 
            this.rutnuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rutnuoc.Enabled = false;
            this.rutnuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutnuoc.Location = new System.Drawing.Point(95, 123);
            this.rutnuoc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.rutnuoc.Name = "rutnuoc";
            this.rutnuoc.Size = new System.Drawing.Size(64, 21);
            this.rutnuoc.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(161, 127);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 16);
            this.label26.TabIndex = 447;
            this.label26.Text = "ml";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(15, 147);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 16);
            this.label27.TabIndex = 448;
            this.label27.Text = "Dịch và máu :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dichvamau
            // 
            this.dichvamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dichvamau.Enabled = false;
            this.dichvamau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dichvamau.Location = new System.Drawing.Point(95, 145);
            this.dichvamau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.dichvamau.Name = "dichvamau";
            this.dichvamau.Size = new System.Drawing.Size(64, 21);
            this.dichvamau.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(161, 150);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 16);
            this.label28.TabIndex = 450;
            this.label28.Text = "ml";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(15, 170);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 16);
            this.label29.TabIndex = 451;
            this.label29.Text = "Cân sau lọc :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(161, 170);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 16);
            this.label30.TabIndex = 453;
            this.label30.Text = "kg";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cansloc
            // 
            this.cansloc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cansloc.Enabled = false;
            this.cansloc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cansloc.Location = new System.Drawing.Point(95, 167);
            this.cansloc.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cansloc.Name = "cansloc";
            this.cansloc.Size = new System.Drawing.Size(64, 21);
            this.cansloc.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(192, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 16);
            this.label18.TabIndex = 454;
            this.label18.Text = "Đường vào mạch máu";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fav
            // 
            this.fav.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fav.Enabled = false;
            this.fav.Location = new System.Drawing.Point(192, 104);
            this.fav.Name = "fav";
            this.fav.Size = new System.Drawing.Size(59, 16);
            this.fav.TabIndex = 7;
            this.fav.Text = "FAV";
            this.fav.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // ttmd
            // 
            this.ttmd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttmd.Enabled = false;
            this.ttmd.Location = new System.Drawing.Point(192, 125);
            this.ttmd.Name = "ttmd";
            this.ttmd.Size = new System.Drawing.Size(59, 16);
            this.ttmd.TabIndex = 8;
            this.ttmd.Text = "TTMĐ";
            this.ttmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // mtct
            // 
            this.mtct.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mtct.Enabled = false;
            this.mtct.Location = new System.Drawing.Point(192, 149);
            this.mtct.Name = "mtct";
            this.mtct.Size = new System.Drawing.Size(59, 16);
            this.mtct.TabIndex = 9;
            this.mtct.Text = "MTCT";
            this.mtct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tmdd
            // 
            this.tmdd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tmdd.Enabled = false;
            this.tmdd.Location = new System.Drawing.Point(192, 173);
            this.tmdd.Name = "tmdd";
            this.tmdd.Size = new System.Drawing.Size(59, 16);
            this.tmdd.TabIndex = 10;
            this.tmdd.Text = "TMDD";
            this.tmdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(327, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 16);
            this.label19.TabIndex = 459;
            this.label19.Text = "Chống đông :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // heparin
            // 
            this.heparin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.heparin.Enabled = false;
            this.heparin.Location = new System.Drawing.Point(319, 101);
            this.heparin.Name = "heparin";
            this.heparin.Size = new System.Drawing.Size(70, 16);
            this.heparin.TabIndex = 11;
            this.heparin.Text = "Heparin";
            this.heparin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tlpt
            // 
            this.tlpt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlpt.Enabled = false;
            this.tlpt.Location = new System.Drawing.Point(480, 101);
            this.tlpt.Name = "tlpt";
            this.tlpt.Size = new System.Drawing.Size(84, 16);
            this.tlpt.TabIndex = 12;
            this.tlpt.Text = "TLPT Thấp";
            this.tlpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(319, 121);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 16);
            this.label31.TabIndex = 462;
            this.label31.Text = "Liều đầu :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(319, 146);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 16);
            this.label32.TabIndex = 463;
            this.label32.Text = "Duy trì :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(319, 168);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 16);
            this.label33.TabIndex = 464;
            this.label33.Text = "Tổng liều :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cachquang
            // 
            this.cachquang.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cachquang.Enabled = false;
            this.cachquang.Location = new System.Drawing.Point(480, 191);
            this.cachquang.Name = "cachquang";
            this.cachquang.Size = new System.Drawing.Size(84, 16);
            this.cachquang.TabIndex = 17;
            this.cachquang.Text = "Cách quãng";
            this.cachquang.CheckedChanged += new System.EventHandler(this.cachquang_CheckedChanged);
            this.cachquang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // lientuc
            // 
            this.lientuc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lientuc.Enabled = false;
            this.lientuc.Location = new System.Drawing.Point(319, 191);
            this.lientuc.Name = "lientuc";
            this.lientuc.Size = new System.Drawing.Size(70, 16);
            this.lientuc.TabIndex = 16;
            this.lientuc.Text = "Liên tục";
            this.lientuc.CheckedChanged += new System.EventHandler(this.lientuc_CheckedChanged);
            this.lientuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(319, 212);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(96, 16);
            this.label34.TabIndex = 467;
            this.label34.Text = "Khác :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lieudau
            // 
            this.lieudau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lieudau.Enabled = false;
            this.lieudau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lieudau.Location = new System.Drawing.Point(375, 117);
            this.lieudau.Name = "lieudau";
            this.lieudau.Size = new System.Drawing.Size(169, 21);
            this.lieudau.TabIndex = 13;
            this.lieudau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // duytri
            // 
            this.duytri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.duytri.Enabled = false;
            this.duytri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duytri.Location = new System.Drawing.Point(375, 141);
            this.duytri.Name = "duytri";
            this.duytri.Size = new System.Drawing.Size(169, 21);
            this.duytri.TabIndex = 14;
            this.duytri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tonglieu
            // 
            this.tonglieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tonglieu.Enabled = false;
            this.tonglieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tonglieu.Location = new System.Drawing.Point(375, 165);
            this.tonglieu.Name = "tonglieu";
            this.tonglieu.Size = new System.Drawing.Size(193, 21);
            this.tonglieu.TabIndex = 15;
            this.tonglieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // khac
            // 
            this.khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(375, 210);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(193, 21);
            this.khac.TabIndex = 18;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(544, 121);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(40, 16);
            this.label38.TabIndex = 472;
            this.label38.Text = "00 UI";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(544, 146);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 16);
            this.label67.TabIndex = 473;
            this.label67.Text = "UI/h";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mangloc
            // 
            this.mangloc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mangloc.Enabled = false;
            this.mangloc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mangloc.Location = new System.Drawing.Point(681, 101);
            this.mangloc.Name = "mangloc";
            this.mangloc.Size = new System.Drawing.Size(198, 21);
            this.mangloc.TabIndex = 49;
            this.mangloc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(607, 104);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(96, 16);
            this.label68.TabIndex = 474;
            this.label68.Text = "Màng lọc :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhanhieu
            // 
            this.nhanhieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanhieu.Enabled = false;
            this.nhanhieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanhieu.Location = new System.Drawing.Point(681, 123);
            this.nhanhieu.Name = "nhanhieu";
            this.nhanhieu.Size = new System.Drawing.Size(198, 21);
            this.nhanhieu.TabIndex = 50;
            this.nhanhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(607, 126);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(96, 16);
            this.label69.TabIndex = 476;
            this.label69.Text = "Nhãn hiệu :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dientich
            // 
            this.dientich.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dientich.Enabled = false;
            this.dientich.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dientich.Location = new System.Drawing.Point(681, 145);
            this.dientich.Name = "dientich";
            this.dientich.Size = new System.Drawing.Size(198, 21);
            this.dientich.TabIndex = 51;
            this.dientich.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(607, 148);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(96, 16);
            this.label70.TabIndex = 478;
            this.label70.Text = "Diện tích :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // heso
            // 
            this.heso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.heso.Enabled = false;
            this.heso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heso.Location = new System.Drawing.Point(681, 168);
            this.heso.Name = "heso";
            this.heso.Size = new System.Drawing.Size(198, 21);
            this.heso.TabIndex = 52;
            this.heso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(607, 171);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(96, 16);
            this.label71.TabIndex = 480;
            this.label71.Text = "Hệ số siêu lọc :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(607, 192);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(96, 16);
            this.label72.TabIndex = 482;
            this.label72.Text = "DD bảo quản :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(607, 216);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(96, 16);
            this.label73.TabIndex = 483;
            this.label73.Text = "Lần dùng :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baoquan
            // 
            this.baoquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.baoquan.Enabled = false;
            this.baoquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baoquan.Location = new System.Drawing.Point(681, 191);
            this.baoquan.Name = "baoquan";
            this.baoquan.Size = new System.Drawing.Size(198, 21);
            this.baoquan.TabIndex = 53;
            this.baoquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // landung
            // 
            this.landung.Enabled = false;
            this.landung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.landung.Location = new System.Drawing.Point(681, 214);
            this.landung.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.landung.Name = "landung";
            this.landung.Size = new System.Drawing.Size(198, 21);
            this.landung.TabIndex = 54;
            this.landung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(8, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 168);
            this.panel1.TabIndex = 486;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(176, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 168);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 168);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(312, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 168);
            this.panel4.TabIndex = 487;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(0, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 168);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(589, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 168);
            this.panel6.TabIndex = 488;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(0, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 168);
            this.panel7.TabIndex = 1;
            // 
            // tm
            // 
            this.tm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tm.Enabled = false;
            this.tm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm.Location = new System.Drawing.Point(264, 488);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(136, 21);
            this.tm.TabIndex = 35;
            this.tm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(176, 488);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 16);
            this.label16.TabIndex = 490;
            this.label16.Text = "Áp lực TM :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label37.Location = new System.Drawing.Point(176, 512);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(88, 16);
            this.label37.TabIndex = 491;
            this.label37.Text = "Siêu lọc :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sieuloc
            // 
            this.sieuloc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sieuloc.Enabled = false;
            this.sieuloc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sieuloc.Location = new System.Drawing.Point(264, 512);
            this.sieuloc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sieuloc.MaxLength = 5;
            this.sieuloc.Name = "sieuloc";
            this.sieuloc.Size = new System.Drawing.Size(104, 21);
            this.sieuloc.TabIndex = 36;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(368, 516);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 16);
            this.label39.TabIndex = 493;
            this.label39.Text = "ml/giờ";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(429, 416);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 16);
            this.label20.TabIndex = 494;
            this.label20.Text = "Tai biến";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(24, 416);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 16);
            this.label22.TabIndex = 495;
            this.label22.Text = "Dấu hiệu sinh tồn";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(200, 416);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(88, 16);
            this.label40.TabIndex = 496;
            this.label40.Text = "Thông số máy";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label41.Location = new System.Drawing.Point(648, 416);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(88, 16);
            this.label41.TabIndex = 497;
            this.label41.Text = "Thuốc sử dụng";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taibien.Enabled = false;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(427, 436);
            this.taibien.Multiline = true;
            this.taibien.Name = "taibien";
            this.taibien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.taibien.Size = new System.Drawing.Size(208, 96);
            this.taibien.TabIndex = 37;
            this.taibien.TextChanged += new System.EventHandler(this.taibien_TextChanged);
            // 
            // thuoc
            // 
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(648, 436);
            this.thuoc.Multiline = true;
            this.thuoc.Name = "thuoc";
            this.thuoc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.thuoc.Size = new System.Drawing.Size(232, 96);
            this.thuoc.TabIndex = 38;
            this.thuoc.TextChanged += new System.EventHandler(this.thuoc_TextChanged);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(6, 413);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(880, 124);
            this.panel8.TabIndex = 500;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(168, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1, 168);
            this.panel9.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(0, -1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1, 168);
            this.panel10.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(416, 414);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1, 122);
            this.panel11.TabIndex = 501;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Location = new System.Drawing.Point(0, -1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1, 168);
            this.panel12.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Location = new System.Drawing.Point(640, 414);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1, 122);
            this.panel13.TabIndex = 502;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Location = new System.Drawing.Point(0, -1);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1, 168);
            this.panel14.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Location = new System.Drawing.Point(7, 433);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(880, 1);
            this.panel15.TabIndex = 503;
            // 
            // frmLocmau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 613);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.sieuloc);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tm);
            this.Controls.Add(this.tenbsll);
            this.Controls.Add(this.tenytall);
            this.Controls.Add(this.ytall);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.landung);
            this.Controls.Add(this.baoquan);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.heso);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.dientich);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.nhanhieu);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.mangloc);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.khac);
            this.Controls.Add(this.tonglieu);
            this.Controls.Add(this.duytri);
            this.Controls.Add(this.lieudau);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.cachquang);
            this.Controls.Add(this.lientuc);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.tlpt);
            this.Controls.Add(this.heparin);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tmdd);
            this.Controls.Add(this.mtct);
            this.Controls.Add(this.ttmd);
            this.Controls.Add(this.fav);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cansloc);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dichvamau);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.rutnuoc);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cantloc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.dm);
            this.Controls.Add(this.tocdo);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.gio_ct);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.mabsll);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.tenyta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.gio_kt);
            this.Controls.Add(this.ngay_kt);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ngay_ct);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.yta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.lgio);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.cmbngay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocmau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu theo dõi lọc máu";
            this.Load += new System.EventHandler(this.frmLocmau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.landung)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLocmau_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
			user=m.user;
			xxx=user+m.mmyy(ngayvv.Text);
			dtnv=m.get_data("select * from "+user+".dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			sql="select a.id,a.idthuchien,to_char(a.ngaybd,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.cantloc,a.rutnuoc,a.dichvamau,a.cansloc,a.fav,a.ttmd,a.mtct,a.tmdd,a.heparin,a.tlpt,a.lieudau,";
			sql+="a.duytri,a.tonglieu,a.lientuc,a.cachquang,a.khac,to_char(a.ngaykt,'dd/mm/yyyy hh24:mi') as ngaykt,";
			sql+="a.mangloc,a.nhanhieu,a.dientich,a.heso,a.baoquan,a.landung,a.mabs,a.yta,a.userid";
			sql+=" from "+xxx+".ba_locmaull a,"+xxx+".ba_thuchien b ";
			sql+=" where a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";				

			dsh=m.get_data(sql);
			cmbngay.DisplayMember="NGAY";
			cmbngay.ValueMember="ID";
			cmbngay.DataSource=dsh.Tables[0];
			l_id=(dsh.Tables[0].Rows.Count>0)?decimal.Parse(dsh.Tables[0].Rows[0]["id"].ToString()):0;
			load_head();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,yta,35);
			}		
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}	
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void load_grid()
		{
			sql="select stt,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="mach,huyetap,nhietdo,nhiptho,tocdo,dm,tm,sieuloc,taibien,thuoc,mabs,yta from "+xxx+".ba_locmauct ";
			sql+=" where id="+l_id;
			sql+=" order by stt";
			ds=m.get_data(sql);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
			ref_text();
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
			discontinuedCol.HeaderText = "";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "stt";
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
			TextCol1.MappingName = "mach";
			TextCol1.HeaderText = "Mạch";
			TextCol1.Width =40;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "huyetap";
			TextCol1.HeaderText = "Huyết áp";
			TextCol1.Width =60;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "nhietdo";
			TextCol1.HeaderText = "Nhiệt độ";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "nhiptho";
			TextCol1.HeaderText = "Nhịp thở";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		
			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tocdo";
			TextCol1.HeaderText = "Tốc độ máu";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "dm";
			TextCol1.HeaderText = "Áp lực ĐM";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tm";
			TextCol1.HeaderText = "Áp lực TM";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "sieuloc";
			TextCol1.HeaderText = "Siêu lọc";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "taibien";
			TextCol1.HeaderText = "Tai biến";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "thuoc";
			TextCol1.HeaderText = "Thuốc sử dụng";
			TextCol1.Width = 130;
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
				i_stt=int.Parse(dataGrid1[i_row,1].ToString());
			}
			catch{i_stt=0;}
			load_items(i_stt);
		}

		private void load_items(int stt)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"stt="+stt);
			if (r!=null)
			{
				ngay_ct.Text=r["ngay"].ToString().Substring(0,10);
				gio_ct.Text=r["ngay"].ToString().Substring(11);
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				tocdo.Text=(r["tocdo"].ToString()!="0")?r["tocdo"].ToString():"";
				dm.Text=r["dm"].ToString();
				tm.Text=r["tm"].ToString();
				sieuloc.Text=(r["sieuloc"].ToString()!="0")?r["sieuloc"].ToString():"";
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) 	tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				yta.Text=r["yta"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
				if (r1!=null) 	tenyta.Text=r1["hoten"].ToString();
				else tenyta.Text="";
				taibien.Text=r["taibien"].ToString();
				thuoc.Text=r["thuoc"].ToString();
			}
		}

		private void emp_detail()
		{
			string _ngay=m.ngayhienhanh_server;
			ngay_ct.Text=_ngay.Substring(0,10);
			gio_ct.Text=_ngay.Substring(11);
			i_stt=1;
			if (ds.Tables[0].Rows.Count>0) i_stt=int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["stt"].ToString())+1;
			nhiptho.Text="";nhietdo.Text="";huyetap.Text="";mach.Text="";tocdo.Text="";dm.Text="";tm.Text="";taibien.Text="";thuoc.Text="";
			sieuloc.Text="";mabs.Text=mabsll.Text;tenbs.Text=tenbsll.Text;yta.Text=ytall.Text;tenyta.Text=tenytall.Text;
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			ngay_ct.Text=ngay.Text;
			gio_ct.Text=gio.Text;
			ngay_kt.Text="";gio_kt.Text="";
			cantloc.Text="";rutnuoc.Text="";dichvamau.Text="";cansloc.Text="";
			fav.Checked=false;ttmd.Checked=false;mtct.Checked=false;tmdd.Checked=false;
			heparin.Checked=false;tlpt.Checked=false;
			lieudau.Text="";duytri.Text="";tonglieu.Text="";lientuc.Checked=false;
			cachquang.Checked=false;khac.Text="";mangloc.Text="";nhanhieu.Text="";
			dientich.Text="";heso.Text="";baoquan.Text="";landung.Value=1;
			mabsll.Text="";tenbsll.Text="";ytall.Text="";tenytall.Text="";
			ngay_kt.Text="";gio_kt.Text="";nhiptho.Text="";nhietdo.Text="";
			huyetap.Text="";mach.Text="";mabs.Text="";tenbs.Text="";yta.Text="";tenyta.Text="";
			tocdo.Text="";dm.Text="";tm.Text="";sieuloc.Text="";
			ds.Clear();
			emp_detail();
		}

		private void ena_object(bool ena)
		{
			cmbngay.Visible=!ena;
			ngay.Visible=ena;
			lgio.Visible=ena;
			gio.Visible=ena;
			ngay.Enabled=ena;
			gio.Enabled=ena;
			ngay_kt.Enabled=ena;
			gio_kt.Enabled=ena;
			cantloc.Enabled=ena;
			rutnuoc.Enabled=ena;
			dichvamau.Enabled=ena;
			cansloc.Enabled=ena;
			fav.Enabled=ena;
			ttmd.Enabled=ena;
			mtct.Enabled=ena;
			tmdd.Enabled=ena;
			heparin.Enabled=ena;
			tlpt.Enabled=ena;
			lieudau.Enabled=ena;
			duytri.Enabled=ena;
			tonglieu.Enabled=ena;
			lientuc.Enabled=ena;
			cachquang.Enabled=ena;
			khac.Enabled=ena;
			mangloc.Enabled=ena;
			nhanhieu.Enabled=ena;
			dientich.Enabled=ena;
			heso.Enabled=ena;
			baoquan.Enabled=ena;
			landung.Enabled=ena;
			mabsll.Enabled=ena;
			tenbsll.Enabled=ena;
			ytall.Enabled=ena;
			tenytall.Enabled=ena;
			ngay_ct.Enabled=ena;
			gio_ct.Enabled=ena;
			nhiptho.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			mach.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			yta.Enabled=ena;
			tenyta.Enabled=ena;
			tocdo.Enabled=ena;
			dm.Enabled=ena;
			tm.Enabled=ena;
			sieuloc.Enabled=ena;
			taibien.Enabled=ena;
			thuoc.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			ngay.Text=cmbngay.Text.ToString().Substring(0,10);
			gio.Text=cmbngay.Text.ToString().Substring(11);			
			ena_object(true);
			ref_text();
			ngay_ct.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();d.close();
			System.GC.Collect();
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(ngayvv.Text.ToString());
				m.execute_data("delete from "+xxx+".ba_locmauct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_locmaull where id="+l_id);				
				m.delrec(dsh.Tables[0],"id="+l_id);
				cmbngay.Refresh();
				l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
				load_head();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			load_head();
			butMoi.Focus();
		}

		private bool kiemtra()
		{
			if (ngay.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return false;
			}
			if (gio.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio.Focus();
				return false;
			}
			if (ngay_kt.Text!="" && gio_kt.Text!="")
			{
				if (ngay_kt.Text.Trim().Length!=10)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
					ngay_kt.Focus();
					return false;
				}
				if (gio_kt.Text.Trim().Length!=5)
				{
					MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
					gio_kt.Focus();
					return false;
				}
				
				if (!m.bNgaygio(ngay_kt.Text+" "+gio_kt.Text,ngay.Text+" "+gio.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày giờ kết thúc không được nhỏ hơn ngày giờ bắt đầu !"),LibMedi.AccessData.Msg);
					ngay_kt.Focus();
					return false;
				}
			}
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ thực hiện !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ thực hiện !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
			}
			if (yta.Text!="" && tenyta.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập YT (ĐD) thực hiện !"),LibMedi.AccessData.Msg);
					yta.Focus();
					return false;
				}
			}
			return true;
		}

		private bool kiemtrad()
		{
			if (ngay_ct.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay_ct.Focus();
				return false;
			}
			if (gio_ct.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio_ct.Focus();
				return false;
			}			
			if (!m.bNgaygio(ngay_ct.Text+" "+gio_ct.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ thực hiện không được nhỏ hơn ngày giờ bắt đầu !"),LibMedi.AccessData.Msg);
				ngay_ct.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) m.tao_user_mmyy(mmyy,i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.getidyymmddhhmiss_stt_computer;
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.getidyymmddhhmiss_stt_computer;
			if (!upd_itemsd()) return;
            m.upd_ba_locmaull(ngayvv.Text, mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, (cantloc.Text != "") ? decimal.Parse(cantloc.Text) : 0, (rutnuoc.Text != "") ? decimal.Parse(rutnuoc.Text) : 0,
				(dichvamau.Text!="")?decimal.Parse(dichvamau.Text):0,(cansloc.Text!="")?decimal.Parse(cansloc.Text):0,(fav.Checked)?1:0,(ttmd.Checked)?1:0,(mtct.Checked)?1:0,(tmdd.Checked)?1:0,
				(heparin.Checked)?1:0,(tlpt.Checked)?1:0,lieudau.Text,duytri.Text,tonglieu.Text,(lientuc.Checked)?1:0,(cachquang.Checked)?1:0,khac.Text,ngay_kt.Text+" "+gio_kt.Text,
				mangloc.Text,nhanhieu.Text,dientich.Text,heso.Text,baoquan.Text,landung.Value,mabs.Text,yta.Text,i_userid);
			upd_items();
			m.execute_data("delete from "+xxx+".ba_locmauct where id="+l_id);
			ds.AcceptChanges();
			foreach(DataRow r in ds.Tables[0].Rows)
				m.upd_ba_locmauct(ngayvv.Text,l_id,int.Parse(r["stt"].ToString()),r["ngay"].ToString(),
					decimal.Parse(r["mach"].ToString()),r["huyetap"].ToString(),decimal.Parse(r["nhietdo"].ToString()),
					decimal.Parse(r["nhiptho"].ToString()),decimal.Parse(r["tocdo"].ToString()),r["dm"].ToString(),
					r["tm"].ToString(),decimal.Parse(r["sieuloc"].ToString()),r["taibien"].ToString(),
					r["thuoc"].ToString(),r["mabs"].ToString(),r["yta"].ToString());
			ena_object(false);
			butMoi.Focus();
		}

		private void upd_items()
		{
			DataRow r1,r2;
			r1=m.getrowbyid(dsh.Tables[0],"id="+l_id);
			if (r1==null)
			{
				r2=dsh.Tables[0].NewRow();
				r2["id"]=l_id;
				r2["idthuchien"]=l_idthuchien;
				r2["ngay"]=ngay.Text+" "+gio.Text;
				r2["ngaykt"]=ngay_kt.Text+" "+gio_kt.Text;
				r2["cantloc"]=(cantloc.Text!="")?decimal.Parse(cantloc.Text):0;
				r2["rutnuoc"]=(rutnuoc.Text!="")?decimal.Parse(rutnuoc.Text):0;
				r2["dichvamau"]=(dichvamau.Text!="")?decimal.Parse(dichvamau.Text):0;
				r2["cansloc"]=(cansloc.Text!="")?decimal.Parse(cansloc.Text):0;
				r2["fav"]=(fav.Checked)?1:0;
				r2["ttmd"]=(ttmd.Checked)?1:0;
				r2["mtct"]=(mtct.Checked)?1:0;
				r2["tmdd"]=(tmdd.Checked)?1:0;
				r2["heparin"]=(heparin.Checked)?1:0;
				r2["tlpt"]=(tlpt.Checked)?1:0;
				r2["lieudau"]=lieudau.Text;
				r2["duytri"]=duytri.Text;
				r2["tonglieu"]=tonglieu.Text;
				r2["lientuc"]=(lientuc.Checked)?1:0;
				r2["cachquang"]=(cachquang.Checked)?1:0;
				r2["khac"]=khac.Text;
				r2["mangloc"]=mangloc.Text;
				r2["nhanhieu"]=nhanhieu.Text;
				r2["dientich"]=dientich.Text;
				r2["heso"]=heso.Text;
				r2["baoquan"]=baoquan.Text;
				r2["landung"]=landung.Value;
				r2["mabs"]=mabsll.Text;
				r2["yta"]=ytall.Text;
				dsh.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=dsh.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["ngaykt"]=ngay_kt.Text+" "+gio_kt.Text;
				dr[0]["cantloc"]=(cantloc.Text!="")?decimal.Parse(cantloc.Text):0;
				dr[0]["rutnuoc"]=(rutnuoc.Text!="")?decimal.Parse(rutnuoc.Text):0;
				dr[0]["dichvamau"]=(dichvamau.Text!="")?decimal.Parse(dichvamau.Text):0;
				dr[0]["cansloc"]=(cansloc.Text!="")?decimal.Parse(cansloc.Text):0;
				dr[0]["fav"]=(fav.Checked)?1:0;
				dr[0]["ttmd"]=(ttmd.Checked)?1:0;
				dr[0]["mtct"]=(mtct.Checked)?1:0;
				dr[0]["tmdd"]=(tmdd.Checked)?1:0;
				dr[0]["heparin"]=(heparin.Checked)?1:0;
				dr[0]["tlpt"]=(tlpt.Checked)?1:0;
				dr[0]["lieudau"]=lieudau.Text;
				dr[0]["duytri"]=duytri.Text;
				dr[0]["tonglieu"]=tonglieu.Text;
				dr[0]["lientuc"]=(lientuc.Checked)?1:0;
				dr[0]["cachquang"]=(cachquang.Checked)?1:0;
				dr[0]["khac"]=khac.Text;
				dr[0]["mangloc"]=mangloc.Text;
				dr[0]["nhanhieu"]=nhanhieu.Text;
				dr[0]["dientich"]=dientich.Text;
				dr[0]["heso"]=heso.Text;
				dr[0]["baoquan"]=baoquan.Text;
				dr[0]["landung"]=landung.Value;
				dr[0]["mabs"]=mabsll.Text;
				dr[0]["yta"]=ytall.Text;
			}
		}

		private bool upd_itemsd()
		{
			if (mach.Text!="")
			{
				if (!kiemtrad()) return false;
				DataRow r1,r2;
				r1=m.getrowbyid(ds.Tables[0],"stt="+i_stt);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=i_stt;
					r2["ngay"]=ngay_ct.Text+" "+gio_ct.Text;
					r2["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
					r2["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
					r2["huyetap"]=huyetap.Text;
					r2["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
					r2["tocdo"]=(tocdo.Text!="")?decimal.Parse(tocdo.Text):0;
					r2["dm"]=dm.Text;
					r2["tm"]=tm.Text;
					r2["sieuloc"]=(sieuloc.Text!="")?decimal.Parse(sieuloc.Text):0;
					r2["taibien"]=taibien.Text;
					r2["thuoc"]=thuoc.Text;
					r2["mabs"]=mabs.Text;
					r2["yta"]=yta.Text;
					r2["chon"]=false;
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					DataRow [] dr=ds.Tables[0].Select("stt="+i_stt);
					dr[0]["ngay"]=ngay_ct.Text+" "+gio_ct.Text;
					dr[0]["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
					dr[0]["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
					dr[0]["huyetap"]=huyetap.Text;
					dr[0]["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
					dr[0]["tocdo"]=(tocdo.Text!="")?decimal.Parse(tocdo.Text):0;
					dr[0]["dm"]=dm.Text;
					dr[0]["tm"]=tm.Text;
					dr[0]["sieuloc"]=(sieuloc.Text!="")?decimal.Parse(sieuloc.Text):0;
					dr[0]["taibien"]=taibien.Text;
					dr[0]["thuoc"]=thuoc.Text;
					dr[0]["mabs"]=mabs.Text;
					dr[0]["yta"]=yta.Text;
				}
				emp_detail();
			}
			return true;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_stt="",stuoi=m.get_tuoivao(l_maql).Trim();
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_stt+=r1["stt"].ToString()+",";
			sql="select b.stt,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,to_char(a.ngaybd,'dd/mm/yyyy hh24:mi') as ngaybd,";
			sql+="a.cantloc,a.rutnuoc,a.dichvamau,a.cansloc,a.fav,a.ttmd,a.mtct,a.tmdd,a.heparin,a.tlpt,";
			sql+="a.lieudau,a.duytri,a.tonglieu,a.lientuc,a.cachquang,a.khac,";
			sql+="to_char(a.ngaykt,'dd/mm/yyyy hh24:mi') as ngaykt,";
			sql+="a.mangloc,a.nhanhieu,a.dientich,a.heso,a.baoquan,a.mabs as mabsll,a.yta as ytall,";
			sql+="c.hoten as tenbsll,d.hoten as tenytall,";
			sql+="to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mach,b.huyetap,b.nhietdo,b.nhiptho,b.tocdo,";
			sql+="b.dm,b.tm,b.sieuloc,b.taibien,b.thuoc,b.mabs,b.yta,";
			sql+="e.hoten as tenbs,f.hoten as tenyt,";
            sql += "'' as i_bsll,'' as i_ytall,'' as i_mabs,'' as i_yta";//d.image,e.image,f.image,c.image
			sql+=" from "+xxx+".ba_locmaull a,"+xxx+".ba_locmauct b,"+user+".dmbs c,"+user+".dmbs d,";
			sql+=user+".dmbs e,"+user+".dmbs f";
			sql+=" where a.id=b.id and a.mabs=c.ma(+) and a.yta=d.ma(+) and b.mabs=e.ma(+) ";
			sql+=" and b.yta=f.ma(+) and a.id="+l_id;
			if (s_stt!="") sql+=" and b.stt in ("+s_stt.Substring(0,s_stt.Length-1)+")";
			DataSet dsxml=m.get_data(sql);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\locmau.xml",XmlWriteMode.WriteSchema);
			}								

			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["tuoi"]=stuoi;
				r["phai"]=phai.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rLocmau.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}


		private void yta_Validated(object sender, System.EventArgs e)
		{
			if (yta.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
			if (r!=null) tenyta.Text=r["hoten"].ToString();
			else tenyta.Text="";	
		}

		private void tenyta_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenyta)
			{
				Filt_dmbs(tenyta.Text);
				listNv.BrowseToDanhmuc(tenyta,yta,mach,35);
			}		
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!upd_itemsd()) return;
			ngay_ct.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			m.delrec(ds.Tables[0],"stt="+i_stt);
			ref_text();			
		}

		private void cmbngay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbngay)
			{
				l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
				load_head();
			}
		}

		private void load_head()
		{
			DataRow r=m.getrowbyid(dsh.Tables[0],"id="+l_id);
			if (r!=null)
			{
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				ngay_kt.Text=(r["ngaykt"].ToString().Length==16)?r["ngaykt"].ToString().Substring(0,10):"";
				gio_kt.Text=(r["ngaykt"].ToString().Length==16)?r["ngaykt"].ToString().Substring(11):"";

				cantloc.Text=(r["cantloc"].ToString()!="0")?r["cantloc"].ToString():"";
				rutnuoc.Text=(r["rutnuoc"].ToString()!="0")?r["rutnuoc"].ToString():"";
				dichvamau.Text=(r["dichvamau"].ToString()!="0")?r["dichvamau"].ToString():"";
				cansloc.Text=(r["cansloc"].ToString()!="0")?r["cansloc"].ToString():"";
				fav.Checked=r["fav"].ToString()=="1";
				ttmd.Checked=r["ttmd"].ToString()=="1";
				mtct.Checked=r["mtct"].ToString()=="1";
				tmdd.Checked=r["tmdd"].ToString()=="1";
				heparin.Checked=r["heparin"].ToString()=="1";
				tlpt.Checked=r["tlpt"].ToString()=="1";
				lieudau.Text=r["lieudau"].ToString();
				duytri.Text=r["duytri"].ToString();
				tonglieu.Text=r["tonglieu"].ToString();
				lientuc.Checked=r["lientuc"].ToString()=="1";
				cachquang.Checked=r["cachquang"].ToString()=="1";
				khac.Text=r["khac"].ToString();
				mangloc.Text=r["mangloc"].ToString();
				nhanhieu.Text=r["nhanhieu"].ToString();
				dientich.Text=r["dientich"].ToString();
				heso.Text=r["heso"].ToString();
				baoquan.Text=r["baoquan"].ToString();
				landung.Value=decimal.Parse(r["landung"].ToString());

				mabsll.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabsll.Text+"'");
				if (r1!=null) tenbsll.Text=r1["hoten"].ToString();
				else tenbsll.Text="";	
				
				ytall.Text=r["yta"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ytall.Text+"'");
				if (r1!=null) tenytall.Text=r1["hoten"].ToString();
				else tenytall.Text="";	
			}
			load_grid();
		}

		private void ngay_ct_Validated(object sender, System.EventArgs e)
		{
			ngay_ct.Text=ngay_ct.Text.Trim();
			if (ngay_ct.Text.Length==6) ngay_ct.Text=ngay_ct.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay_ct.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay_ct.Focus();
				return;
			}
		}

		private void gio_ct_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio_ct.Text.Trim()=="")?"00:00":gio_ct.Text.Trim();
			gio_ct.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio_ct.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio_ct.Focus();
				return;
			}
		}

		private void ngay_kt_Validated(object sender, System.EventArgs e)
		{
			if (ngay_kt.Text!="")
			{
				ngay_kt.Text=ngay_kt.Text.Trim();
				if (ngay_kt.Text.Length==6) ngay_kt.Text=ngay_kt.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(ngay_kt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					ngay_kt.Focus();
					return;
				}
			}
		}

		private void gio_kt_Validated(object sender, System.EventArgs e)
		{
			if (gio_kt.Text!="")
			{
				string sgio=(gio_kt.Text.Trim()=="")?"00:00":gio_kt.Text.Trim();
				gio_kt.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
				if (!m.bGio(gio_kt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
					gio_kt.Focus();
					return;
				}
			}
			else butThem.Focus();
		}

		private void setFcous(TextBox txt)
		{
			if (txt.Text == "\r\n") SendKeys.Send("{Tab}");
		}

		private void taibien_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==taibien) setFcous(taibien);
		}

		private void thuoc_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thuoc) setFcous(thuoc);
		}

		private void mabsll_Validated(object sender, System.EventArgs e)
		{
			if (mabsll.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabsll.Text+"'");
			if (r!=null) tenbsll.Text=r["hoten"].ToString();
			else tenbsll.Text="";
			if (mabs.Text=="")
			{
				mabs.Text=mabsll.Text;
				tenbs.Text=tenbsll.Text;
			}
		}

		private void ytall_Validated(object sender, System.EventArgs e)
		{
			if (ytall.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ytall.Text+"'");
			if (r!=null) tenytall.Text=r["hoten"].ToString();
			else tenytall.Text="";
			if (yta.Text=="")
			{
				yta.Text=ytall.Text;
				tenyta.Text=tenytall.Text;
			}
		}

		private void tenbsll_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsll)
			{
				Filt_dmbs(tenbsll.Text);
				listNv.BrowseToDanhmuc(tenbsll,mabsll,ytall,35);
			}		
		}

		private void tenytall_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenytall)
			{
				Filt_dmbs(tenytall.Text);
				listNv.BrowseToDanhmuc(tenytall,ytall,ngay_ct,35);
			}		
		}

		private void listNv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (mabs.Text=="" && mabsll.Text!="")
				{
					mabs.Text=mabsll.Text;tenbs.Text=tenbsll.Text;
				}
				if (yta.Text=="" && ytall.Text!="")
				{
					yta.Text=ytall.Text;tenyta.Text=tenytall.Text;
				}
			}
		}

		private void lientuc_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lientuc && lientuc.Checked) cachquang.Checked=false;
		}

		private void cachquang_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachquang && cachquang.Checked) lientuc.Checked=false;
		}
	}
}
