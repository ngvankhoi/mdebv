using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace libxTutruc
{
	/// <summary>
	/// Summary description for frmXtutruc.
	/// </summary>
	public class frmXtutruc : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox manv;
		private System.Windows.Forms.TextBox tennv;
		private MaskedBox.MaskedBox huyetap;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox cannang;
		private System.Windows.Forms.GroupBox dausinhton;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label lMabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label ldvt;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butCholai;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private int i_nhom,i_makp,i_makhoa,i_phieu,i_userid,i_old,i_mabd,i_loai,i_madoituong,i_sudungthuoc,i_duyet,i_diung=-1,i_vienphi,i_buoi,i_somay,itable;
		private string user,xxx,nam,s_ngayvv,s_makho,s_makp,s_ngay,sql,s_mmyy,s_msg,s_manguon,s_nguon_doituong,s_title,s_nhom_doituong,s_mabn,s_tenkp,s_tenphieu,s_mabs;
		private long l_id=0,l_duyet=0,l_maql,l_idkhoa,l_idvpkhoa,l_mavaovien;
		private decimal d_soluongcu,d_soluong,d_soluongton;
        private bool bNew, bEdit, bDausinhton, bDiungthuoc, bNhapten, bMadoituong, bTrucoso, bRead, bTTngay, bLockytu, bSolan, bTru_tonao, bPhonggiuong, bMabd_madoituong;
		private LibList.List listDmbd;
		private LibList.List listHoten;
		private LibList.List listNv;
		private LibList.List listCachdung;
		private DataRow r;
		private DataTable dtkho=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dttonct=new DataTable();
		private DataTable dtnv=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtdoituong=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private MaskedTextBox.MaskedTextBox phong;
		private MaskedTextBox.MaskedTextBox giuong;
		private MaskedTextBox.MaskedTextBox ghichu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.TextBox stt;
		private MaskedBox.MaskedBox nhietdo;
		private System.Windows.Forms.CheckBox butChuyen;
		private System.Windows.Forms.Label diung;
		private System.Windows.Forms.TextBox mahc;
		private System.Windows.Forms.Label label21;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox chkmadt_def;
		private System.Windows.Forms.CheckBox vpkhoa;
        private CheckBox chkThuoc;
        private NumericUpDown solan;
        private Label label23;
        private MaskedTextBox.MaskedTextBox moilan;
        private Label lbldvt;
        private Label label27;
        private NumericUpDown songay;
        private Label label24;
        private Label label26;
        private TextBox tim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXtutruc(string ngay,string makho,string makp,int nhom,int loai,int phieu,int imakp,int imakhoa,int userid,string mmyy,long duyet,string title,string msg,bool Dausinhton,int sudungthuoc,string manguon,string _mabn,int buoi,string _tenkp,string _tenphieu,int somay,string _mabs)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_ngay=ngay;s_makho=makho;s_makp=(makp=="xx")?"":makp;
			i_userid=userid;i_nhom=nhom;i_loai=loai;i_somay=somay;
			i_phieu=phieu;i_buoi=buoi;i_makp=imakp;i_makhoa=imakhoa;
			i_sudungthuoc=sudungthuoc;s_mmyy=mmyy;s_mabn=_mabn;
			s_msg=msg;l_duyet=duyet;bDausinhton=Dausinhton;
			s_manguon=manguon;s_tenkp=_tenkp;s_tenphieu=_tenphieu;
            this.Text = title; s_title = title; s_mabs = _mabs;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXtutruc));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.manv = new MaskedTextBox.MaskedTextBox();
            this.tennv = new System.Windows.Forms.TextBox();
            this.huyetap = new MaskedBox.MaskedBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.dausinhton = new System.Windows.Forms.GroupBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.label21 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.mabd = new System.Windows.Forms.TextBox();
            this.lTen = new System.Windows.Forms.Label();
            this.lMabd = new System.Windows.Forms.Label();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butCholai = new System.Windows.Forms.Button();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.listDmbd = new LibList.List();
            this.listHoten = new LibList.List();
            this.listNv = new LibList.List();
            this.listCachdung = new LibList.List();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.phong = new MaskedTextBox.MaskedTextBox();
            this.giuong = new MaskedTextBox.MaskedTextBox();
            this.ghichu = new MaskedTextBox.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.butChuyen = new System.Windows.Forms.CheckBox();
            this.diung = new System.Windows.Forms.Label();
            this.mahc = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkmadt_def = new System.Windows.Forms.CheckBox();
            this.vpkhoa = new System.Windows.Forms.CheckBox();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.solan = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.moilan = new MaskedTextBox.MaskedTextBox();
            this.lbldvt = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.dausinhton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(47, 6);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(175, 21);
            this.hoten.TabIndex = 2;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(348, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bác sĩ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(573, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "ĐDV :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mabs.Location = new System.Drawing.Point(397, 6);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(35, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(433, 6);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(143, 21);
            this.tenbs.TabIndex = 4;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv.Enabled = false;
            this.manv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.manv.Location = new System.Drawing.Point(612, 6);
            this.manv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(36, 21);
            this.manv.TabIndex = 5;
            this.manv.Validated += new System.EventHandler(this.manv_Validated);
            // 
            // tennv
            // 
            this.tennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv.Enabled = false;
            this.tennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv.Location = new System.Drawing.Point(649, 6);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(141, 21);
            this.tennv.TabIndex = 6;
            this.tennv.TextChanged += new System.EventHandler(this.tennv_TextChanged);
            this.tennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(65, 87);
            this.huyetap.Mask = "###/###";
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 3;
            this.huyetap.Text = "   /   ";
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(65, 41);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 1;
            this.mach.Validated += new System.EventHandler(this.mach_Validated);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mạch :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(98, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "lần/phút";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nhiệt độ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Huyết áp :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Nhịp thở :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cân nặng :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(113, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "mmHg";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(100, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 23);
            this.label12.TabIndex = 7;
            this.label12.Text = "lần/phút";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(108, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 9;
            this.label13.Text = "gram";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(99, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 23);
            this.label14.TabIndex = 3;
            this.label14.Text = "C°";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(65, 110);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 4;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(65, 133);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 5;
            // 
            // dausinhton
            // 
            this.dausinhton.Controls.Add(this.ngay);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.huyetap);
            this.dausinhton.Controls.Add(this.nhiptho);
            this.dausinhton.Controls.Add(this.cannang);
            this.dausinhton.Controls.Add(this.mach);
            this.dausinhton.Controls.Add(this.label21);
            this.dausinhton.Controls.Add(this.label5);
            this.dausinhton.Controls.Add(this.label6);
            this.dausinhton.Controls.Add(this.label7);
            this.dausinhton.Controls.Add(this.label14);
            this.dausinhton.Controls.Add(this.label8);
            this.dausinhton.Controls.Add(this.label11);
            this.dausinhton.Controls.Add(this.label12);
            this.dausinhton.Controls.Add(this.label13);
            this.dausinhton.Controls.Add(this.label9);
            this.dausinhton.Controls.Add(this.label10);
            this.dausinhton.Location = new System.Drawing.Point(630, 59);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(160, 164);
            this.dausinhton.TabIndex = 11;
            this.dausinhton.TabStop = false;
            this.dausinhton.Text = "Dấu sinh tồn";
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(65, 18);
            this.ngay.Mask = "##/##/#### ##:##";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(94, 21);
            this.ngay.TabIndex = 0;
            this.ngay.Text = "  /  /       :  ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(65, 64);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 2;
            this.nhietdo.Text = "  .  ";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(18, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 23);
            this.label21.TabIndex = 18;
            this.label21.Text = "Ngày :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(630, 229);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(160, 184);
            this.treeView1.TabIndex = 26;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 37);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 364);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // tenbd
            // 
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(304, 412);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(320, 21);
            this.tenbd.TabIndex = 14;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(56, 435);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(240, 21);
            this.tenhc.TabIndex = 15;
            // 
            // lTenhc
            // 
            this.lTenhc.Location = new System.Drawing.Point(-13, 435);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(72, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(192, 412);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(60, 21);
            this.mabd.TabIndex = 13;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Location = new System.Drawing.Point(256, 412);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(44, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Location = new System.Drawing.Point(147, 412);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(45, 23);
            this.lMabd.TabIndex = 68;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(328, 435);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(48, 21);
            this.dang.TabIndex = 155;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(412, 458);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(73, 21);
            this.soluong.TabIndex = 19;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(348, 456);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Location = new System.Drawing.Point(280, 435);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(50, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cachdung
            // 
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(544, 458);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(246, 21);
            this.cachdung.TabIndex = 20;
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(442, 458);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 23);
            this.label25.TabIndex = 76;
            this.label25.Text = "Cách dùng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(56, 412);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(96, 21);
            this.madoituong.TabIndex = 12;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(-13, 412);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Đối tượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(538, 484);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(60, 25);
            this.butKetthuc.TabIndex = 29;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(476, 484);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 28;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(414, 484);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 24;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(352, 484);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(60, 25);
            this.butXoa.TabIndex = 22;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(290, 484);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 21;
            this.butThem.Text = "&Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(228, 484);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 23;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(166, 484);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 27;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(104, 484);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 25;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butCholai
            // 
            this.butCholai.Enabled = false;
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(42, 484);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(60, 25);
            this.butCholai.TabIndex = 26;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(47, 6);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(80, 21);
            this.cmbMabn.TabIndex = 0;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // listDmbd
            // 
            this.listDmbd.BackColor = System.Drawing.SystemColors.Info;
            this.listDmbd.ColumnCount = 0;
            this.listDmbd.Location = new System.Drawing.Point(416, 542);
            this.listDmbd.MatchBufferTimeOut = 1000;
            this.listDmbd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDmbd.Name = "listDmbd";
            this.listDmbd.Size = new System.Drawing.Size(75, 17);
            this.listDmbd.TabIndex = 89;
            this.listDmbd.TextIndex = -1;
            this.listDmbd.TextMember = null;
            this.listDmbd.ValueIndex = -1;
            this.listDmbd.Visible = false;
            this.listDmbd.DoubleClick += new System.EventHandler(this.listDmbd_DoubleClick);
            this.listDmbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDmbd_KeyDown);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(120, 542);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 90;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(208, 542);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 91;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // listCachdung
            // 
            this.listCachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listCachdung.ColumnCount = 0;
            this.listCachdung.Location = new System.Drawing.Point(304, 542);
            this.listCachdung.MatchBufferTimeOut = 1000;
            this.listCachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listCachdung.Name = "listCachdung";
            this.listCachdung.Size = new System.Drawing.Size(75, 17);
            this.listCachdung.TabIndex = 92;
            this.listCachdung.TextIndex = -1;
            this.listCachdung.TextMember = null;
            this.listCachdung.ValueIndex = -1;
            this.listCachdung.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(2, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 23);
            this.label17.TabIndex = 93;
            this.label17.Text = "Phòng :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(130, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 23);
            this.label18.TabIndex = 94;
            this.label18.Text = "Giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(390, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Tình trạng :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(47, 29);
            this.phong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.phong.MaxLength = 10;
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 7;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(176, 29);
            this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giuong.MaxLength = 10;
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(59, 21);
            this.giuong.TabIndex = 8;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(453, 29);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(235, 21);
            this.ghichu.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(373, 435);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 23);
            this.label20.TabIndex = 96;
            this.label20.Text = "Kho :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(412, 435);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(92, 21);
            this.makho.TabIndex = 97;
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(306, 145);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 98;
            // 
            // butChuyen
            // 
            this.butChuyen.Appearance = System.Windows.Forms.Appearance.Button;
            this.butChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyen.Location = new System.Drawing.Point(631, 484);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(159, 25);
            this.butChuyen.TabIndex = 99;
            this.butChuyen.Text = "Chuyển số liệu về kho";
            this.butChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.butChuyen.CheckedChanged += new System.EventHandler(this.butChuyen_CheckedChanged);
            // 
            // diung
            // 
            this.diung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.diung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diung.Location = new System.Drawing.Point(744, 435);
            this.diung.Name = "diung";
            this.diung.Size = new System.Drawing.Size(50, 23);
            this.diung.TabIndex = 101;
            this.diung.Text = "DỊ ỨNG";
            this.diung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diung.Click += new System.EventHandler(this.diung_Click);
            // 
            // mahc
            // 
            this.mahc.Location = new System.Drawing.Point(208, 360);
            this.mahc.Name = "mahc";
            this.mahc.Size = new System.Drawing.Size(48, 20);
            this.mahc.TabIndex = 102;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(544, 435);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(80, 21);
            this.manguon.TabIndex = 106;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(502, 435);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 23);
            this.label22.TabIndex = 105;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmadt_def
            // 
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkmadt_def.Location = new System.Drawing.Point(631, 437);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(122, 24);
            this.chkmadt_def.TabIndex = 108;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // vpkhoa
            // 
            this.vpkhoa.Checked = true;
            this.vpkhoa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vpkhoa.Enabled = false;
            this.vpkhoa.Location = new System.Drawing.Point(5, 461);
            this.vpkhoa.Name = "vpkhoa";
            this.vpkhoa.Size = new System.Drawing.Size(77, 18);
            this.vpkhoa.TabIndex = 16;
            this.vpkhoa.Text = "Trừ cơ số";
            this.vpkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vpkhoa_KeyDown);
            // 
            // chkThuoc
            // 
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(631, 419);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(142, 17);
            this.chkThuoc.TabIndex = 156;
            this.chkThuoc.Text = "Các ngày sử dụng thuốc";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // solan
            // 
            this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solan.Enabled = false;
            this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solan.Location = new System.Drawing.Point(126, 458);
            this.solan.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.solan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Name = "solan";
            this.solan.Size = new System.Drawing.Size(37, 21);
            this.solan.TabIndex = 17;
            this.solan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Validated += new System.EventHandler(this.solan_Validated);
            this.solan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solan_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(88, 457);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 158;
            this.label23.Text = "Ngày :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moilan
            // 
            this.moilan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.moilan.Enabled = false;
            this.moilan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moilan.Location = new System.Drawing.Point(213, 458);
            this.moilan.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.moilan.Name = "moilan";
            this.moilan.Size = new System.Drawing.Size(54, 21);
            this.moilan.TabIndex = 18;
            this.moilan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moilan.Validated += new System.EventHandler(this.solan_Validated);
            // 
            // lbldvt
            // 
            this.lbldvt.Location = new System.Drawing.Point(269, 457);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(76, 23);
            this.lbldvt.TabIndex = 161;
            this.lbldvt.Text = "viên";
            this.lbldvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(166, 456);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 23);
            this.label27.TabIndex = 160;
            this.label27.Text = "lần , lần :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // songay
            // 
            this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songay.Enabled = false;
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(315, 29);
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(36, 21);
            this.songay.TabIndex = 9;
            this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(235, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 23);
            this.label24.TabIndex = 164;
            this.label24.Text = "Đơn thuốc cấp ";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(354, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 16);
            this.label26.TabIndex = 163;
            this.label26.Text = "ngày";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(690, 29);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(100, 21);
            this.tim.TabIndex = 165;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // frmXtutruc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cachdung);
            this.Controls.Add(this.solan);
            this.Controls.Add(this.moilan);
            this.Controls.Add(this.lbldvt);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.diung);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.vpkhoa);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.chkmadt_def);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dausinhton);
            this.Controls.Add(this.butChuyen);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.listCachdung);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.listDmbd);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.butCholai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.tennv);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.mahc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXtutruc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Phiếu xuất cơ số tủ trực";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXtutruc_KeyDown);
            this.Load += new System.EventHandler(this.frmXtutruc_Load);
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXtutruc_Load(object sender, System.EventArgs e)
		{
            bPhonggiuong = m.bPhonggiuong;
            user = d.user; xxx = user + s_mmyy; bSolan = m.bSolan_donthuoc;
            chkThuoc.Checked = i_sudungthuoc != 3;
			bLockytu=d.bLockytu_traiphai(i_nhom);
            bMabd_madoituong = d.bMabd_doituong(i_nhom);
			//if (s_mabn!="") this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			if (!bDausinhton)
			{
				this.treeView1.Location = new System.Drawing.Point(631, 55);
				treeView1.Height=357;
			}
			bTTngay=(m.bChieu_sang && i_buoi==0)?d.get_ttngay(s_ngay,s_makp):false;
			bTrucoso=d.bTrucoso(i_nhom);
			i_vienphi=m.iVienphi;
			diung.Tag="";
			bMadoituong=m.bSuadt_thuoc_vp;
			chkmadt_def.Checked=!bMadoituong;
			bNhapten=m.bNhapthuoc_ten;
			bDiungthuoc=m.bDiungthuoc;
			diung.Visible=bDiungthuoc;
            dtdmbd = d.get_data("select a.*,nullif(b.nhomvp,0) as nhomvp,nullif(c.id,0) as loaivp from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".v_loaivp c on b.nhomvp=c.id_nhom where a.nhom=" + i_nhom).Tables[0];
            if (s_makp != "")
            {
                dthoten = m.get_hiendien(s_makp, s_ngay).Tables[0];
                listHoten.DisplayMember = "MABN";
                listHoten.ValueMember = "HOTEN";
                listHoten.DataSource = dthoten;
            }

			dtnv=d.get_data("select ma,hoten,nhom from "+user+".dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";

			listCachdung.DisplayMember="STT";
			listCachdung.ValueMember="TEN";

            dtdoituong = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdoituong;

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
            if (d.bQuanlynguon(i_nhom)) sql = "select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt";
            else sql = "select * from " + user + ".d_dmnguon where nhom=0 or nhom=" + i_nhom + " order by stt";
			manguon.DataSource=d.get_data(sql).Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

            sql = "select a.id,a.mabn,d.hoten,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.mabs,c.manv,c.mach, ";
			sql+="c.nhietdo,c.huyetap,c.nhiptho,c.cannang,c.phong,c.giuong,c.ghichu,a.read,a.songay";
            sql += " from " + xxx + ".d_xtutrucll a inner join " + xxx + ".d_duyet b on a.idduyet=b.id ";
            sql += " left join " + xxx + ".d_dausinhton c on a.id=c.iddutru inner join " + user + ".btdbn d on a.mabn=d.mabn ";
			sql+=" where b.id="+l_duyet+" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dsxoa.ReadXml("..\\..\\..\\xml\\d_dutruct.xml");
			if (l_duyet!=0)
			{
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				butChuyen.Checked=i_duyet!=0;
				butChuyen.Enabled=i_duyet!=2;
				if (butChuyen.Enabled) col_butChuyen(i_duyet);
			}
            bTru_tonao = d.bTru_tonao(i_nhom);
            if (!bTru_tonao) load_dm();
		}

		private void load_grid()
		{
			sql="select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,1 as tutruc,a.idvpkhoa,a.solan,a.lan ";
            sql += " from " + xxx + ".d_xtutrucct a," + user + ".d_dmbd b," + user + ".d_doituong e," + user + ".d_dmkho f where a.mabd=b.id and a.madoituong=e.madoituong and a.makho=f.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			if (bDiungthuoc) upd_diung();
			dataGrid1.DataSource=dtct;
		}

		private void upd_diung()
		{
			if (diung.Tag.ToString()!="")
			{
				int i=0;
				foreach(DataRow r in dtct.Rows)
				{
					i=0;
					while (i<diung.Tag.ToString().Length)
					{
						if (r["mahc"].ToString().IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
						{
							r["diung"]="1";
							break;
						}
						i+=7;
					}
				}
				dtct.AcceptChanges();
			}
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 55;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 45;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 34;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "diung";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "idvpkhoa";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "solan";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = "lan";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			if (this.dataGrid1[row,13].ToString().Trim()!="0") c=Color.Blue;
			else if (this.dataGrid1[row,11].ToString().Trim()=="1")
			{
				c=Color.Red;
				i_diung=row;
			}
			if (row==i_diung) c=Color.Red;
			return c;
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,2].ToString();
				tenbd.Text=dataGrid1[i,3].ToString();
				tenhc.Text=dataGrid1[i,4].ToString();
				dang.Text=dataGrid1[i,5].ToString();
                lbldvt.Text = dang.Text;
				d_soluong=(dataGrid1[i,6].ToString()!="")?decimal.Parse(dataGrid1[i,6].ToString()):0;
				soluong.Text=d_soluong.ToString("###,###,##0.00");
				madoituong.SelectedValue=dataGrid1[i,7].ToString();
				makho.SelectedValue=dataGrid1[i,8].ToString();
				cachdung.Text=dataGrid1[i,9].ToString();
				mahc.Text=dataGrid1[i,10].ToString();
				manguon.SelectedValue=dataGrid1[i,12].ToString();
				l_idvpkhoa=(dataGrid1[i,13].ToString()!="")?long.Parse(dataGrid1[i,13].ToString()):0;
                solan.Value = decimal.Parse(dataGrid1[i, 14].ToString());
                moilan.Text = dataGrid1[i, 15].ToString();
				vpkhoa.Checked=l_idvpkhoa==0;
				d_soluongcu=d_soluong;
				if (butLuu.Enabled && !bNew) vpkhoa.Enabled=false;
			}
            catch { emp_detail(); }
		}

		private void ena_object(bool ena)
		{
            tim.Enabled = !ena;
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			if (s_makp!="" && bNhapten) hoten.Enabled=ena;
            songay.Enabled = ena;
			mabs.Enabled=ena;
			manv.Enabled=ena;
			tenbs.Enabled=ena;
			tennv.Enabled=ena;
            if (!bPhonggiuong)
            {
                phong.Enabled = ena;
                giuong.Enabled = ena;
            }
			ghichu.Enabled=ena;
			if (bTrucoso) vpkhoa.Enabled=ena;
            if (bSolan) solan.Enabled = ena;
            moilan.Enabled = ena;
			if (bDausinhton)
			{
				ngay.Enabled=ena;
				mach.Enabled=ena;
				nhietdo.Enabled=ena;
				huyetap.Enabled=ena;
				nhiptho.Enabled=ena;
				cannang.Enabled=ena;
			}
			if (bMadoituong) madoituong.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butCholai.Enabled=ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butChuyen.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
            if (ena)
            {
                if (bTru_tonao) load_dm();
                else listCachdung.DataSource = d.get_data("select ten as stt,ten from " + user + ".d_dmcachdung order by ten").Tables[0];
            }
            if (s_mabs != "")
            {
                DataRow r = m.getrowbyid(dtnv, "ma='" + s_mabs + "'");
                if (r != null)
                {
                    if (int.Parse(r["nhom"].ToString()) == LibMedi.AccessData.nhanvien)
                    {
                        manv.Text = s_mabs; tennv.Text = r["hoten"].ToString();
                        manv.Enabled = false; tennv.Enabled = false;
                    }
                    else
                    {
                        mabs.Text = s_mabs; tenbs.Text = r["hoten"].ToString();
                        mabs.Enabled = false; tenbs.Enabled = false;
                    }
                }
            }
		}

		private void emp_head()
		{
			if (bDiungthuoc)
			{
				diung.ForeColor=Color.FromArgb(0,0,128);
				diung.Tag="";
			}
            mabn.Text = ""; hoten.Text = ""; bRead = false; l_mavaovien = 0; s_ngayvv = ""; nam = "";
            phong.Text = ""; giuong.Text = ""; ghichu.Text = ""; mach.Text = ""; nhiptho.Text = ""; songay.Value = 0;
			huyetap.Text="";nhietdo.Text="";cannang.Text="";l_id=0;l_maql=0;ngay.Text=m.Ngaygio;
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
			dsxoa.Clear();
		}

		private void emp_detail()
		{
            vpkhoa.Checked = true; l_idvpkhoa = 0; solan.Value = 1;
			mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";cachdung.Text="";mahc.Text="";
			soluong.Text="";makho.SelectedIndex=-1;stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;if (i_madoituong!=0) madoituong.SelectedValue=i_madoituong.ToString();
		}

		private void load_dm()
		{
			dtton=d.get_tutructh_dutru(s_mmyy,i_makp,s_makho,s_manguon,0,i_nhom);
			listDmbd.DataSource=dtton;
            listCachdung.DataSource = d.get_data("select ten as stt,ten from " + user + ".d_dmcachdung order by ten").Tables[0];
		}

		private void load_tonct()
		{
			dttonct=d.get_tutrucct_dutru(s_mmyy,i_makp,s_makho,s_manguon,0);
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			DataRow r1;
			string gi;
			if (s_makp!="")
			{
				r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					hoten.Text=r["hoten"].ToString();
                    l_mavaovien = long.Parse(r["mavaovien"].ToString());
					l_maql=long.Parse(r["maql"].ToString());
					l_idkhoa=long.Parse(r["id"].ToString());
					gi=r["giuong"].ToString().Trim();
                    s_ngayvv = r["ngay"].ToString();
                    nam = r["nam"].ToString().Trim();
                    if (mabs.Enabled)
                    {
                        mabs.Text = r["mabs"].ToString();
                        r1 = d.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                        if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                        else tenbs.Text = "";
                    }
                    if (bPhonggiuong) giuong.Text = gi;
                    else
                    {
                        if (gi.IndexOf("/") != -1 || gi.IndexOf("-") != -1)
                        {
                            int pos = (gi.IndexOf("/") != -1) ? gi.IndexOf("/") : gi.IndexOf("-");
                            phong.Text = gi.Substring(0, pos);
                            if (pos + 1 <= gi.Length) giuong.Text = gi.Substring(pos + 1);
                        }
                        else giuong.Text = gi;
                    }
					i_madoituong=int.Parse(r["madoituong"].ToString());
					if (dtct.Rows.Count==0 && i_madoituong!=0) madoituong.SelectedValue=i_madoituong.ToString();
					if (bDiungthuoc) load_diungthuoc(mabn.Text);
				}
                else { hoten.Text = ""; l_maql = 0; l_idkhoa = 0; l_mavaovien = 0; }
			}
			else
			{
				hoten.Text="";
                string zzz = xxx;
                if (m.bMmyy(d.mmyy(s_ngay))) zzz = user + d.mmyy(s_ngay);
                sql = "select a.nam,a.hoten,b.mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mabs,b.madoituong from ";
                sql += user + ".btdbn a," + zzz + ".benhanpk b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "' order by b.maql desc";
                foreach (DataRow r2 in d.get_data(sql).Tables[0].Rows)
                {
                    nam = r2["nam"].ToString().Trim();
                    s_ngayvv = r2["ngay"].ToString();
                    hoten.Text = r2["hoten"].ToString();
                    l_maql = long.Parse(r2["maql"].ToString());
                    l_mavaovien = long.Parse(r2["mavaovien"].ToString());
                    mabs.Text = r2["mabs"].ToString();
                    r1 = d.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                    i_madoituong = int.Parse(r2["madoituong"].ToString());
                    if (dtct.Rows.Count == 0 && i_madoituong != 0) madoituong.SelectedValue = i_madoituong.ToString();
                    if (bDiungthuoc) load_diungthuoc(mabn.Text);
                    l_id = 0;
                    break;
                }
				if (hoten.Text=="")
				{
                    sql="select a.nam,a.hoten,b.maql as mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.madoituong ";
                    sql += " from " + user + ".btdbn a," + zzz + ".tiepdon b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "' order by b.maql desc";
					foreach(DataRow r2 in d.get_data(sql).Tables[0].Rows)
					{
                        s_ngayvv = r2["ngay"].ToString();
                        nam = r2["nam"].ToString().Trim();
						hoten.Text=r2["hoten"].ToString();
						l_maql=long.Parse(r2["maql"].ToString());
                        l_mavaovien = long.Parse(r2["mavaovien"].ToString());
                        i_madoituong = int.Parse(r2["madoituong"].ToString());
                        if (dtct.Rows.Count == 0 && i_madoituong != 0) madoituong.SelectedValue = i_madoituong.ToString();
                        if (bDiungthuoc) load_diungthuoc(mabn.Text);
						l_id=0;
						break;
					}
				}
				if (hoten.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return;
				}
			}
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"),s_msg);
					mabn.Focus();
					return;
				}
			}
			catch{}
			sql="select b.mabs,b.manv,b.phong,b.giuong,b.ghichu from "+xxx+".d_xtutrucll a,"+xxx+".d_dausinhton b where a.id=b.iddutru and a.mabn='"+mabn.Text+"'";
			sql+=" order by a.id desc";
			foreach(DataRow r2 in d.get_data(sql).Tables[0].Rows)
			{
				if (r2["mabs"].ToString()!="") mabs.Text=r2["mabs"].ToString();
				if (r2["manv"].ToString()!="") manv.Text=r2["manv"].ToString();
				r1=d.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				r1=d.getrowbyid(dtnv,"ma='"+manv.Text+"'");
				if (r1!=null) tennv.Text=r1["hoten"].ToString();
				else tennv.Text="";
                if (!bPhonggiuong)
                {
                    phong.Text = r2["phong"].ToString();
                    giuong.Text = r2["giuong"].ToString();
                }
				ghichu.Text=r2["ghichu"].ToString();
				break;
			}
			load_congno();
			if (chkThuoc.Checked) load_treeview();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            return;
			i_duyet=d.get_duyet(s_mmyy,l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?lan.Change_language_MessageText("Số liệu đã chuyển xuống kho bạn không quyền thay đổi !"):"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
            if (d.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), LibMedi.AccessData.Msg);
                return;
            }
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			treeView1.Nodes.Clear();
			bNew=true;
			bEdit=true;
			if (s_mabn!="")
			{
				r=m.getrowbyid(dtll,"mabn='"+s_mabn+"'");
				if (r==null) mabn.Text=s_mabn;
			}
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
            //if (bRead)
            //{
            //    MessageBox.Show("Người bệnh đã cập nhật !",LibMedi.AccessData.Msg);
            //    cmbMabn.Focus();
            //    return;
            //}
            //i_duyet=d.get_duyet(s_mmyy,l_duyet);
            //if (i_duyet!=0)
            //{
            //    sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
            //    MessageBox.Show(sql,s_msg);
            //    return;
            //}
            //if (d.bKhoaso(i_nhom, s_mmyy))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), LibMedi.AccessData.Msg);
            //    return;
            //}
			l_id=long.Parse(cmbMabn.SelectedValue.ToString());
            //if (s_makp != "")
            //{
            //    if (d.get_paid(mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã thanh toán !"), LibMedi.AccessData.Msg);
            //        cmbMabn.Focus();
            //        return;
            //    }

            //    DataRow r = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
            //    if (r == null)
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã xuất viện !"), LibMedi.AccessData.Msg);
            //        cmbMabn.Focus();
            //        return;
            //    }
            //    else if (long.Parse(r["id"].ToString()) != l_idkhoa)
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã chuyển khoa !"), LibMedi.AccessData.Msg);
            //        cmbMabn.Focus();
            //        return;
            //    }
            //    i_madoituong = int.Parse(r["madoituong"].ToString());
            //}
            //i_madoituong = d.get_madoituong(l_maql);
			ena_object(true);
			mabn.Enabled=false;
			hoten.Enabled=false;
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            //if (!KiemtraHead()) return;
			bEdit=false;
			//upd_table(dtct,"-");
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatsd:l_id;
            itable = m.tableid(d.mmyy(s_ngay),"d_xtutrucll");
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngayvv+"^"+songay.Value.ToString());
            }
			if (!bNew) 
			{
                foreach (DataRow r1 in d.get_data( "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien from " + xxx + ".d_thucxuat a,"+xxx+".d_theodoi b where a.sttt=b.id and a.id=" + l_id).Tables[0].Rows)
				{
					d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,1,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
					d.upd_theodoicongno(d.delete,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
					d.upd_tienthuoc(d.delete,s_mmyy,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_makhoa,i_loai,int.Parse(r1["madoituong"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}
                d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + l_id);
                d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id);
			}
			if (l_duyet==0)
			{
				if (i_somay==1)
				{
					if (d.get_data("select id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0].Rows.Count>0)
					{
						MessageBox.Show("Ngày "+s_ngay+"\nKhoa "+s_tenkp+"\nPhiếu "+s_tenphieu+"\nĐã nhập !",LibMedi.AccessData.Msg);
						return;
					}
				}
				else 
				{
					DataTable dtd=d.get_data("select id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'"+" and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0];
					if (dtd.Rows.Count!=0) l_duyet=long.Parse(dtd.Rows[0][0].ToString());
					else l_duyet=d.get_id_duyet;
				}
				if (l_duyet==0) l_duyet=d.get_id_duyet;
				d.upd_duyet(s_mmyy,l_duyet,i_nhom,s_ngay,i_loai,i_phieu,i_makp,0,i_userid,i_makhoa);
                foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), 0);
			}
			d.upd_dausinhton(s_mmyy,l_id,l_idkhoa,l_id,(bDausinhton)?ngay.Text:s_ngay,mabs.Text,manv.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,phong.Text,giuong.Text,ghichu.Text);
			if (!d.upd_xtutrucll(s_mmyy,l_id,l_duyet,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngayvv,songay.Value))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            itable = m.tableid(d.mmyy(s_ngay),"d_xtutrucct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucct", "id=" + l_id + " and stt=" + long.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_xtutrucct where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
					if (long.Parse(r1["idvpkhoa"].ToString())!=0) 
						v.execute_data("delete from "+xxx+".v_vpkhoa where id="+long.Parse(r1["idvpkhoa"].ToString()));
				}
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (m.get_data("select * from " + xxx + ".d_xtutrucct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["madoituong"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + "0" + "^" + r1["cachdung"].ToString()+"^"+r1["manguon"].ToString()+"^"+r1["idvpkhoa"].ToString()+"^"+r1["solan"].ToString()+"^"+r1["lan"].ToString());
                }
                else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                d.upd_xtutrucct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), 0, r1["cachdung"].ToString(), int.Parse(r1["manguon"].ToString()), long.Parse(r1["idvpkhoa"].ToString()), decimal.Parse(r1["solan"].ToString()), decimal.Parse(r1["lan"].ToString()));
            }
			d.updrec_dutrull(dtll,l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,hoten.Text,mabs.Text,manv.Text,(bDausinhton)?ngay.Text:s_ngay,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,phong.Text,giuong.Text,ghichu.Text,0,1,s_ngayvv);
			#region xuatsd
            itable = m.tableid(d.mmyy(s_ngay), "d_xuatsdll");
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + i_phieu.ToString() + "^" + i_makp.ToString() + "^" + i_userid.ToString() + "^" + l_id.ToString() + "^" + "1" + "^" + i_makhoa.ToString() + "^" + "0" + "^" + "0" + "^" +"");
            }
			if (!d.upd_xuatsdll(s_mmyy,l_id,i_nhom,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_loai,i_phieu,i_makp,i_userid,l_id,1,i_makhoa,0,0,"",s_ngay))
			{
				MessageBox.Show("Không cập nhật được thông tin phiếu lĩnh !",d.Msg);
				return;
			}
			d.get_xuatsdct_cstt(s_mmyy,dtct.Select("soluong>0 and idvpkhoa=0","stt"),i_makp,i_makhoa,0,l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,i_loai,1,s_ngay,i_nhom,s_ngay);
            if (d.get_data("select * from " + user + s_mmyy + ".d_xuatsdct where id=" + l_id).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không cập nhật được thông tin phiếu lĩnh chi tiết !", d.Msg);
                return;
            }
			decimal gia=0;
			foreach(DataRow r1 in dtct.Select("soluong>0 and idvpkhoa<>0","stt"))
			{
				gia=d.get_dongia(s_mmyy,i_makp,int.Parse(r1["mabd"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["madoituong"].ToString()));
				r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
				if (r!=null) 
				{
                    itable = m.tableid(d.mmyy(s_ngay), "v_giavp");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
					gia=(gia==0)?decimal.Parse(r["dongia"].ToString()):gia;
					v.upd_giavp(int.Parse(r1["mabd"].ToString()),long.Parse(r["loaivp"].ToString()),int.Parse(r["stt"].ToString()),r["ma"].ToString(),r["ten"].ToString().Trim()+" "+r["hamluong"].ToString(),r["dang"].ToString(),gia,gia,gia,gia,gia,int.Parse(r["bhyt"].ToString()),i_userid,0,0,0,0,0,0,0,0,"");
				}
                itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
				l_idvpkhoa=long.Parse(r1["idvpkhoa"].ToString());
				l_idvpkhoa=(l_idvpkhoa==0 || l_idvpkhoa==-1)?v.get_id_vpkhoa:l_idvpkhoa;
				v.upd_vpkhoa(l_idvpkhoa,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,int.Parse(r1["madoituong"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),gia,0,i_userid,i_buoi);
				d.upd_theodoicongno(d.insert,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),Math.Round(decimal.Parse(r1["soluong"].ToString())*gia,3),"vienphi");
				d.execute_data("update "+xxx+".d_xtutrucct set idvpkhoa="+l_idvpkhoa+" where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
			}	
			#endregion
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbMabn.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			if (bDiungthuoc) upd_diung();
			load_grid();
			ref_text();
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbMabn.SelectedIndex=i_old;
			}
			catch{}
			if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void Filt_hoten(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listHoten.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void Filt_dmbs(string ten,string exp)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%' and "+exp;
			}
			catch{}
		}

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listCachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text,"nhom<>"+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tenbs,mabs,manv,35);
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

		private void tennv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv)
			{
				Filt_dmbs(tennv.Text,"nhom="+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tennv,manv,phong,35);
			}
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,mabs,55);
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung)
			{
				Filter_cachdung(cachdung.Text);
				listCachdung.BrowseToBtdkp(cachdung,cachdung,butThem);
			}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listCachdung.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listCachdung.Visible) listCachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="(soluong>0) and (ma like '"+ma.Trim()+"%' or mahc like '"+ma.Trim()+"%')";
				else sql="(soluong>0) and (ma like '%"+ma.Trim()+"%' or mahc like '%"+ma.Trim()+"%')";
				if (madoituong.SelectedIndex!=-1) if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
					s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
					if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="(soluong>0) and (ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				if (madoituong.SelectedIndex!=-1) if (madoituong.SelectedValue.ToString()=="1") sql+=" and (bhyt<>0)";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
					s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
					if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				if (i_madoituong!=0 && s_makp!="")
				{
					if (int.Parse(madoituong.SelectedValue.ToString())!=i_madoituong)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							madoituong.SelectedValue=i_madoituong.ToString();
					}
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				if (vpkhoa.Enabled) listDmbd.Tonkhoct(mabd,tenbd,vpkhoa,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
                else if (solan.Enabled) listDmbd.Tonkhoct(mabd, tenbd, solan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + madoituong.Width + lMabd.Width + treeView1.Width + 3, mabd.Height + 5);
                else listDmbd.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				if (vpkhoa.Enabled) listDmbd.Tonkhoct(tenbd,mabd,vpkhoa,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
				else if (solan.Enabled) listDmbd.Tonkhoct(tenbd,mabd,solan,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
                else listDmbd.Tonkhoct(tenbd, mabd, soluong, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + madoituong.Width + lMabd.Width + treeView1.Width + 3, mabd.Height + 5);
			}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDmbd.Visible) listDmbd.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDmbd.Focused) listDmbd.Hide();
		}

		private void listDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
                        lbldvt.Text = dang.Text;
						makho.SelectedValue=r["makho"].ToString();
						mahc.Text=r["mahc"].ToString().Trim();
						manguon.SelectedValue=r["manguon"].ToString();
                        if (bMabd_madoituong && r["madoituong"].ToString() != "0") madoituong.SelectedValue = r["madoituong"].ToString();
					#region diung
						if (bDiungthuoc)
						{
							bool bFound=false;
							if (diung.Tag.ToString()!="" && mahc.Text!="")
							{
								int i=0;
								while (i<diung.Tag.ToString().Length)
								{
									if (mahc.Text.IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
									{
										bFound=true;
										break;
									}
									i+=7;
								}
							}
							if (bFound)
							{
								if (MessageBox.Show("Người bệnh dị ứng thuốc \n"+tenhc.Text.Trim()+"\nBạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
								else
								{
									mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
									mabd.Focus();
								}
							}
						}
					#endregion
					}
				}
				catch{}
			}
		}

		private void cachdung_Validated(object sender, System.EventArgs e)
		{
			if(!listCachdung.Focused) listCachdung.Hide();
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom<>"+LibMedi.AccessData.nhanvien+" and ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";
		}

		private void manv_Validated(object sender, System.EventArgs e)
		{
			if (manv.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom="+LibMedi.AccessData.nhanvien+" and ma='"+manv.Text+"'");
			if (r!=null) tennv.Text=r["hoten"].ToString();
			else tennv.Text="";
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_id=long.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
                    s_ngayvv = r["ngayvv"].ToString();
					mabn.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					mabs.Text=r["mabs"].ToString();
					manv.Text=r["manv"].ToString();
					DataRow r1=d.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					r1=d.getrowbyid(dtnv,"ma='"+manv.Text+"'");
					if (r1!=null) tennv.Text=r1["hoten"].ToString();
					else tennv.Text="";
					phong.Text=r["phong"].ToString();
					giuong.Text=r["giuong"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					if (bDausinhton) ngay.Text=r["ngay"].ToString();
					mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
                    l_mavaovien = long.Parse(r["mavaovien"].ToString());
					l_maql=long.Parse(r["maql"].ToString());
                    l_idkhoa=long.Parse(r["idkhoa"].ToString());
					bRead=r["read"].ToString()=="1";
                    songay.Value = decimal.Parse(r["songay"].ToString());
					if (chkThuoc.Checked) load_treeview();
					if (bDiungthuoc) load_diungthuoc(mabn.Text);
					load_congno();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private void load_congno()
		{
			if (i_vienphi!=4)
			{
				decimal congno=d.congno(i_vienphi,mabn.Text,l_maql,l_idkhoa);
				if (congno==0) this.Text=s_title;
				else
				{
					if (congno>0) this.Text=s_title+",Thiếu :"+congno.ToString("###,###,###,##0.00");
					else
					{
						congno=Math.Abs(congno);
						this.Text=s_title+",Thừa :"+congno.ToString("###,###,###,##0.00");
					}
				}	
			}
		}

		private bool KiemtraHead()
		{
			if (bNew)
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"),s_msg);
					mabn.Focus();
					return false;
				}
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),s_msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			if (s_makp!="")
			{
                l_maql = 0; l_mavaovien = 0; l_idkhoa = 0;
				r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
					mabn.Focus();
					return false;
				}
                nam = r["nam"].ToString().Trim();
				l_maql=long.Parse(r["maql"].ToString());
				l_idkhoa=long.Parse(r["id"].ToString());
                l_mavaovien = long.Parse(r["mavaovien"].ToString());
                s_ngayvv = r["ngay"].ToString();
			}
			if ((mabs.Text!="" && tenbs.Text=="") || (mabs.Text=="" && tenbs.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),s_msg);
				if (mabs.Text=="") mabs.Focus();
				else if (tenbs.Text=="") tenbs.Focus();
				return false;
			}
			if ((manv.Text!="" && tennv.Text=="") || (manv.Text=="" && tennv.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),s_msg);
				if (manv.Text=="") manv.Focus();
				else if (tennv.Text=="") tennv.Focus();
				return false;
			}
			if (s_makp!="")
			{
				if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return false;
				}
			}
            dtct.AcceptChanges();
            if (dtct.Rows.Count == 0)
            {
                MessageBox.Show("Yêu cầu nhập mặt hàng !", LibMedi.AccessData.Msg);
                butThem.Focus();
                return false;
            }
			return true;
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),s_msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),s_msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),s_msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),s_msg);
				soluong.Focus();
				return false;
			}
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn đối tượng !"),s_msg);
				if (!madoituong.Enabled) madoituong.Enabled=true;
				madoituong.Focus();
				return false;
			}
			if (madoituong.SelectedIndex!=-1)
			{
				sql="id="+i_mabd+" and makho="+int.Parse(makho.SelectedValue.ToString());
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
				s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
				s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
				s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
				if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
				if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tên thuốc và đối tượng/nhóm không hợp lệ !"),s_msg);
					madoituong.Focus();
					return false;
				}
			}
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            return;
			if (l_maql==0 && s_makp!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
				mabn.Focus();
				return;
			}
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct,"-")) return;
			emp_detail();
			if (bTrucoso) vpkhoa.Enabled=true;
			if (madoituong.Enabled)
			{
				madoituong.Focus();
				SendKeys.Send("{F4}");
			}
			else if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
            return;
			if (!upd_table(dsxoa.Tables[0],"+")) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,string tt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d.updrec_dutruct(tt,dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,mahc.Text,int.Parse(manguon.SelectedValue.ToString()),1,(vpkhoa.Checked)?0:(l_idvpkhoa==0)?-1:l_idvpkhoa,solan.Value,(moilan.Text!="")?decimal.Parse(moilan.Text):1,dtton);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString("#,###,##0.00");
				if (vpkhoa.Checked)
				{
					if (mabd.Text!="" && tenbd.Text!="")
					{
						r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
						if (r!=null)
						{
							i_mabd=int.Parse(r["id"].ToString());
							d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
							if (d_soluong>d_soluongton)
							{
								MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",s_msg);
								soluong.Focus();
								return;
							}
						}
					}
				}
				if (d_soluongcu!=0) upd_table(dtct,"-");
				if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")return;
				upd_table(dtct,"-");
				r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null)
				{
                    DataTable tmp = d.get_data("select a.*,trim(b.ten)||' '||trim(b.hamluong)||' '||trim(b.dang) as ten,trim(b.ten)||' '||b.hamluong as tenbd,b.dang,b.tenhc,b.ma,b.giaban,b.dongia,b.mahc from " + user + ".d_dmbdkemtheo a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + int.Parse(r["id"].ToString())).Tables[0];
					if (tmp.Rows.Count>0)
					{
						string s="";
						foreach(DataRow r1 in tmp.Rows)
						{
							i_mabd=int.Parse(r1["mabd"].ToString());
							d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),0);
							if (d_soluong>d_soluongton) s+=r1["ten"].ToString().Trim()+"\n";
							else d.updrec_dutruct("-",dtct,d.get_stt(dtct),madoituong.Text,i_mabd,r1["ma"].ToString(),r1["tenbd"].ToString(),r1["tenhc"].ToString(),r1["dang"].ToString(),makho.Text,decimal.Parse(r1["soluong"].ToString()),int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,r1["mahc"].ToString(),int.Parse(manguon.SelectedValue.ToString()),1,(vpkhoa.Checked)?0:(l_idvpkhoa==0)?-1:l_idvpkhoa,1,1,dtton);
						}						 			
						if (s!="") MessageBox.Show("Những mặt hàng sau không đủ tồn\n"+s,d.Msg);
					}
				}
			}
			catch{}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            return;
			try
			{
				if (cmbMabn.Items.Count==0) return;
				if (bRead)
				{
					MessageBox.Show("Người bệnh đã cập nhật !",LibMedi.AccessData.Msg);
					cmbMabn.Focus();
					return;
				}
				i_duyet=d.get_duyet(s_mmyy,l_duyet);
				if (i_duyet!=0)
				{
					sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
					MessageBox.Show(sql,s_msg);
					return;
				}
				if (s_makp!="")
				{
					if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
						cmbMabn.Focus();
						return;
					}
				
					DataRow r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã xuất viện !"),LibMedi.AccessData.Msg);
						cmbMabn.Focus();
						return;
					}
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = m.tableid(d.mmyy(s_ngay), "d_thucxuat");
                    foreach (DataRow r1 in d.get_data( "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien from " + xxx + ".d_thucxuat a,"+xxx+".d_theodoi b where a.sttt=b.id and a.id=" + l_id).Tables[0].Rows)
					{
						d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,1,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
						d.upd_theodoicongno(d.delete,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
						d.upd_tienthuoc(d.delete,s_mmyy,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_makhoa,i_loai,int.Parse(r1["madoituong"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_thucxuat", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
					}
                    itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                    foreach (DataRow r1 in d.get_data("select * from " + xxx + ".d_xtutrucct where idvpkhoa<>0 and id=" + l_id).Tables[0].Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + m.mmyy(s_ngay) + ".v_vpkhoa", "id=" + long.Parse(r1["idvpkhoa"].ToString())));
                        v.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id=" + long.Parse(r1["idvpkhoa"].ToString()));
                    }
                    itable = m.tableid(d.mmyy(s_ngay), "d_xtutrucct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    itable = m.tableid(d.mmyy(s_ngay), "d_xtutrucll");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucll", "id=" + l_id));
                    itable = m.tableid(d.mmyy(s_ngay), "d_xuatsdll");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xuatsdll", "id=" + l_id));
                    d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + l_id);
					d.execute_data("delete from " + xxx + ".d_xtutrucct where id="+l_id);
                    d.execute_data("delete from " + xxx + ".d_xtutrucll where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_dausinhton where iddutru=" + l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
                    CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.RowFilter = "";
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count==0) 
					{
                        d.execute_data("delete from " + xxx + ".d_duyet where id=" + l_duyet);
                        d.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
						l_duyet=0;
					}
					if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}
		
		private void load_treeview()
		{
            if (s_ngayvv == "" || mabn.Text == "" || l_maql == 0) return;
            sql = "select to_char(c.ngay,'yyyymmdd') as ngay,b.mabd,sum(b.slyeucau) as soluong ";
            sql += " from xxx.d_xtutrucll a,xxx.d_xtutrucct b,xxx.d_duyet c," + user + ".d_dmbd d ";
            sql += " where a.id=b.id and a.idduyet=c.id and b.mabd=d.id ";
            sql += " and a.mabn='" + mabn.Text + "'" + " and c.nhom=" + i_nhom;
            if (i_sudungthuoc == 2) sql += " and a.maql=" + l_maql;
            sql += " group by to_char(c.ngay,'yyyymmdd'),b.mabd";
            treeView1.Nodes.Clear();
            TreeNode node;
            DataTable dtngay = (i_sudungthuoc == 1 && nam != "") ? m.get_data_nam(nam, sql).Tables[0] : m.get_data_mmyy(sql, s_ngayvv.Substring(0, 10), s_ngay.Substring(0, 10), true).Tables[0];
			string ngay="";
			DataRow [] dr;
			foreach(DataRow r1 in dtngay.Rows)
			{
				if (ngay!=r1["ngay"].ToString())
				{
					ngay=r1["ngay"].ToString();
					node=treeView1.Nodes.Add(ngay.Substring(6,2)+"/"+ngay.Substring(4,2)+"/"+ngay.Substring(0,4));
					dr=dtngay.Select("ngay='"+ngay+"'");
					for(int i=0;i<dr.Length;i++)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
						if (r!=null) node.Nodes.Add(r["ten"].ToString().Trim()+"/"+r["tenhc"].ToString().Trim()+" "+r["dang"].ToString().Trim()+" ("+dr[i]["soluong"].ToString().Trim()+")");
					}
				}
			}
		}

		private void butCholai_Click(object sender, System.EventArgs e)
		{
            return;
			if (mabn.Text.Trim().Length!=8)
			{
				mabn.Focus();
				return;
			}
			long idcholai=d.get_cholai(s_ngayvv,s_ngay,mabn.Text,i_phieu,"d_xtutrucll");
			if (idcholai==0) return;
			sql="select b.madoituong,b.makho,b.mabd,b.slyeucau as soluong,b.cachdung, ";
			sql+=" d.doituong,e.ten as tenkho,f.ma,f.ten,f.tenhc,f.dang,f.mahc,b.manguon,b.solan ";
			sql+=" from xxx.d_xtutrucll a,xxx.d_xtutrucct b,xxx,d_duyet c,"+user+".d_doituong d,"+user+".d_dmkho e,"+user+".d_dmbd f ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.madoituong=d.madoituong ";
			sql+=" and b.makho=e.id and b.mabd=f.id and a.id="+idcholai+" and b.idvpkhoa=0"; 
			sql+=" order by b.stt";
			string s="";i_mabd=0;
			foreach(DataRow r in d.get_thuoc(s_ngayvv,s_ngay,sql).Tables[0].Rows)
			{
				i_mabd=int.Parse(r["mabd"].ToString());
				d_soluong=decimal.Parse(r["soluong"].ToString());
				d_soluongton=d.get_slton_nguon(dtton,int.Parse(r["makho"].ToString()),i_mabd,int.Parse(r["manguon"].ToString()),0);
				if (d_soluong>d_soluongton) s+=r["ten"].ToString()+" "+r["dang"].ToString()+" ("+d_soluongton.ToString("###,###,###0.00")+")\n";
				d_soluong=(d_soluong>d_soluongton)?d_soluongton:d_soluong;
				d.updrec_dutruct("-",dtct,d.get_stt(dtct),r["doituong"].ToString(),i_mabd,r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r["tenkho"].ToString(),d_soluong,int.Parse(r["madoituong"].ToString()),int.Parse(r["makho"].ToString()),r["cachdung"].ToString(),r["mahc"].ToString(),int.Parse(r["manguon"].ToString()),1,0,decimal.Parse(r["solan"].ToString()),1,dtton);
			}
			if (i_mabd!=0 && s!="")
				MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n")+s,s_msg);
			ref_text();
		}

		private void butChuyen_CheckedChanged(object sender, System.EventArgs e)
		{
            return;

			if (this.ActiveControl==butChuyen)
			{
				if (l_duyet==0) return;
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				if (i_duyet==2)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cập nhật bạn không có quyền thay đổi !"),s_msg);
					col_butChuyen(2);
					butChuyen.Checked=true;
					return;
				}
				Cursor=Cursors.WaitCursor;
				i_duyet=(butChuyen.Checked)?1:0;
				d.execute_data("update "+xxx+".d_duyet set done="+i_duyet+" where id="+l_duyet);
				sql = "select distinct c.makho from " + xxx + ".d_duyet a," + xxx + ".d_xtutrucll b," + xxx + ".d_xtutrucct c ";
				sql += " where a.id=b.idduyet and b.id=c.id and a.id=" + l_duyet;
				DataTable tmp = m.get_data(sql).Tables[0];
				m.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
				DataRow r1;
				foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
				{
					r1 = m.getrowbyid(tmp, "makho=" + int.Parse(r["id"].ToString()));
					if (r1 != null)
					{
						d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()),i_duyet);
						//d.execute_data("update " + xxx + ".d_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
					}
				}
				/*
                foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), i_duyet);
                    //d.execute_data("update " + xxx + ".d_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
				*/
				col_butChuyen(i_duyet);
				d.upd_theodoiduyet(s_mmyy,s_ngay,i_nhom,i_loai,i_makp,i_duyet);
				Cursor=Cursors.Default;
				if (i_duyet==1)
				{
					netsend();
					this.Close();
				}
				else cmbMabn.Focus();
			}
		}

		private void col_butChuyen(int i)
		{
			butChuyen.ForeColor=(i==2)?Color.Red:(i==1)?Color.Blue:Color.Black;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			if (l_duyet!=0)
			{
				i_duyet=d.get_duyet(s_mmyy,l_duyet);
				if (i_duyet==0 && dtll.Rows.Count>0)
				{
					DialogResult=MessageBox.Show(lan.Change_language_MessageText("Chuyển số liệu xuống kho ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					if (DialogResult==DialogResult.Yes)
					{
                        d.execute_data("update " + xxx + ".d_duyet set done=1 where id=" + l_duyet);
                        sql = "select distinct c.makho from " + xxx + ".d_duyet a," + xxx + ".d_xtutrucll b," + xxx + ".d_xtutrucct c ";
                        sql += " where a.id=b.idduyet and b.id=c.id and a.id=" + l_duyet;
                        DataTable tmp = m.get_data(sql).Tables[0];
                        m.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
                        DataRow r1;
                        foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                        {
                            r1 = m.getrowbyid(tmp, "makho=" + int.Parse(r["id"].ToString()));
                            if (r1 != null)
                            {
                                d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), i_duyet);
                                //d.execute_data("update " + xxx + ".d_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
                            }
                        }
                        /*
                        foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                            d.execute_data("update " + xxx + ".d_duyetkho set done=1 where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
                        */
						netsend();
					}
					else if (DialogResult==DialogResult.Cancel) return;
				}
			}
			this.Close();
		}

		private void frmXtutruc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F8) diung_Click(null,null);	
		}

		private void diung_Click(object sender, System.EventArgs e)
		{
            //if (cmbMabn.Items.Count==0) return;
            //frmDiungthuoc f=new frmDiungthuoc(m,cmbMabn.Text,hoten.Text,"","");
            //f.ShowDialog(this);
            //load_diungthuoc(cmbMabn.Text);
		}

		private void load_diungthuoc(string mabn)
		{
			DataTable dt=m.get_data("select * from "+user+".diungthuoc where mabn='"+mabn+"'").Tables[0];
			string s="";
			foreach(DataRow r in dt.Rows) s+=r["mahc"].ToString().Trim()+"+";
			diung.ForeColor=(dt.Rows.Count!=0)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
			diung.Tag=s;
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
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ lấy dấu sinh tồn !"),LibMedi.AccessData.Msg);
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
			if (!m.bNgay(s_ngay,ngay.Text.Substring(0,10)))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày lấy dấu sinh tồn không được lớn hơn ngày dự trù !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return;
			}
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dtton,"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
                    lbldvt.Text = dang.Text;
					makho.SelectedValue=r["makho"].ToString();
					mahc.Text=r["mahc"].ToString().Trim();
					manguon.SelectedValue=r["manguon"].ToString();
                    if (bMabd_madoituong && r["madoituong"].ToString() != "0") madoituong.SelectedValue = r["madoituong"].ToString();
					#region diung
					if (bDiungthuoc)
					{
						bool bFound=false;
						if (diung.Tag.ToString()!="" && mahc.Text!="")
						{
							int i=0;
							while (i<diung.Tag.ToString().Length)
							{
								if (mahc.Text.IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
								{
									bFound=true;
									break;
								}
								i+=7;
							}
						}
						if (bFound)
						{
							if (MessageBox.Show("Người bệnh dị ứng thuốc \n"+tenhc.Text.Trim()+"\nBạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
							else
							{
								mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
								mabd.Focus();
							}
						}
					}
					#endregion
					listDmbd.Hide();
                    if (vpkhoa.Enabled) vpkhoa.Focus();
                    else if (solan.Enabled) solan.Focus();
                    else soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDmbd_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				get_items(int.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
				}
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDmbd.Focused) listDmbd.Hide();
                    if (vpkhoa.Enabled) vpkhoa.Focus();
                    else if (solan.Enabled) solan.Focus();
                    else soluong.Focus();
				}
				else
				{
					if (listDmbd.Visible)
					{
						listDmbd.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void mach_Validated(object sender, System.EventArgs e)
		{
			if (mach.Text=="" || mach.Text=="0") butThem.Focus();
		}

		private void chkmadt_def_CheckedChanged(object sender, System.EventArgs e)
		{
			bMadoituong=!chkmadt_def.Checked;
			madoituong.Enabled=bMadoituong;
		}

		private void vpkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		private void netsend()
		{
			if (d.bTinnhan(i_nhom))
			{
				foreach(DataRow r in dtkho.Rows)
					if (r["computer"].ToString()!="")
						d.netsend(d.sDomain(i_nhom),r["computer"].ToString().Trim(),"DUYET PHIEU XUAT TU TRUC KHOA "+m.khongdau(s_tenkp)+" PHIEU "+m.khongdau(s_tenphieu));
			}
		}

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkThuoc)
            {
                if (chkThuoc.Checked) load_treeview();
                else treeView1.Nodes.Clear();
            }
        }

        private void solan_Validated(object sender, EventArgs e)
        {
            //if (soluong.Text != "")
            //{
            //    r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
            //    if (r != null)
            //    {
            //        DataRow r1 = d.getrowbyid(dtdmbd, "id=" + int.Parse(r["id"].ToString()));
            //        if (r1 != null)
            //        {
            //            decimal lan = decimal.Parse(soluong.Text) / solan.Value;
            //            //if (songay.Value != 0) lan /= songay.Value;
            //            lan = Math.Round(lan, 2);
            //            cachdung.Text = r1["duongdung"].ToString().Trim() + " ngày " + solan.Value.ToString() + " lần , lần " + lan.ToString().Trim() + " " + r1["dang"].ToString().Trim();
            //        }
            //    }
            //}
            gc_cachdung();
        }

        private void gc_cachdung()
        {
            if (moilan.Text != "")
            {
                r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                if (r != null)
                {
                    DataRow r1 = d.getrowbyid(dtdmbd, "id=" + int.Parse(r["id"].ToString()));
                    if (r1 != null)
                        cachdung.Text = r1["duongdung"].ToString().Trim() + " ngày " + solan.Value.ToString() + " lần , lần " + moilan.Text.ToString().Trim() + " " + r1["dang"].ToString().Trim();
                }
                decimal sl = Math.Max(songay.Value, 1) * solan.Value * decimal.Parse(moilan.Text);
                soluong.Text = sl.ToString();
                soluong.Refresh();
                soluong_Validated(null, null);
            }
        }

        private void solan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void songay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
                try
                {
                    l_id = long.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_id = 0; }
                load_head();
            }
        }
	}
}
