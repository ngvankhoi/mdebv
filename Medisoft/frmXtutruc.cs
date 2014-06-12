using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;
using System.Collections.Generic;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXtutruc.
	/// </summary>
	public class frmXtutruc : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private bool bTheBHYTHethandung = false;
        public decimal d_idcu = 0;
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
		private MaskedTextBox.MaskedTextBox huyetap;
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
        private int i_nhom, i_makp, i_makhoa, i_phieu, i_userid, i_old, i_mabd, i_loai, i_madoituong, i_sudungthuoc, i_duyet, i_diung = -1, i_vienphi, i_buoi, i_somay, itable, i_done, i_mabdcu, i_makhocu, i_manguoncu,i_traituyen=0;
        private string user, xxx, nam = "", s_ngayvv, s_makho, s_makp, s_ngay, sql, s_mmyy, s_msg, s_manguon, s_nguon_doituong, s_title, s_nhom_doituong, s_mabn, s_tenkp, s_tenphieu, s_mabs, s_denngay = "", f_soluong, s_madoituong = "", s_makho_doituong, s_makp_bo = "";
		private decimal l_duyet=0,l_maql,l_idkhoa,l_idvpkhoa,l_mavaovien;
        private decimal d_soluongcu, d_soluong, d_soluongton, Tamung_min=0, chiphi=0,tamung=0;
        private bool bNew, bEdit, bDausinhton, bDiungthuoc, bNhapten, bMadoituong, bTrucoso, bRead, bTTngay, bLockytu, bSolan, bTru_tonao, bPhonggiuong, bMabd_madoituong, bHansd_thuoc, bThongbaoChiphi = false, bMessage_doituong = false, bThuphi_khongloadthuoc_BHYT, bPhongkham=false;
        private long l_idvpk = 0; private bool bTrongoi_khongchosua = true, bTrongoi = false;
        private string s_ngay_pttt = "", s_makppttt = "";
		private LibList.List listDmbd;
		private LibList.List listHoten;
		private LibList.List listNv;
		private LibList.List listCachdung;
		private DataRow r;
        private DataTable dtdt = new DataTable();
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
        private Button butGoi;
        private Button butTuongtac;
        private Button butIn;
        private ComboBox cbLoaipttt;
        private Label lblLoaipttt;
        private bool bQuanly_thuocmo = false;
        private Label label30;//gam 09/09/2011
        public decimal l_id = 0; 
        private bool bGoiPTTT = false;
        private string s_MaPTTT = "", s_MaMauPTTT = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXtutruc(string ngay,string makho,string makp,int nhom,int loai,int phieu,int imakp,int imakhoa,int userid,string mmyy,decimal duyet,string title,string msg,bool Dausinhton,int sudungthuoc,string manguon,string _mabn,int buoi,string _tenkp,string _tenphieu,int somay,string _mabs,string _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
			s_ngay=ngay;s_makho=makho;s_makp=(makp=="xx")?"":makp;
			i_userid=userid;i_nhom=nhom;i_loai=loai;i_somay=somay;
			i_phieu=phieu;i_buoi=buoi;i_makp=imakp;i_makhoa=imakhoa;
			i_sudungthuoc=sudungthuoc;s_mmyy=mmyy;s_mabn=_mabn;
			s_msg=msg;l_duyet=duyet;bDausinhton=Dausinhton;
			s_manguon=manguon;s_tenkp=_tenkp;s_tenphieu=_tenphieu;
            this.Text = title; s_title = title; s_mabs = _mabs; s_madoituong = _madoituong;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //ThanhCuong - 06/08/2012 - Kỹ thuật cao
        public frmXtutruc(string ngay, string makho, string makp, int nhom, int loai, int phieu, int imakp, int imakhoa, int userid, string mmyy,
            decimal duyet, string title, string msg, bool Dausinhton, int sudungthuoc, string manguon, string _mabn, int buoi, string _tenkp,
            string _tenphieu, int somay, string _mabs, string _madoituong, long _idvpkhoa, string _makppttt, string _ngay_pttt)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_ngay = ngay; s_makho = makho; s_makp = (makp == "xx") ? "" : makp;
            i_userid = userid; i_nhom = nhom; i_loai = loai; i_somay = somay;
            i_phieu = phieu; i_buoi = buoi; i_makp = imakp; i_makhoa = imakhoa;
            i_sudungthuoc = sudungthuoc; s_mmyy = mmyy; s_mabn = _mabn;
            s_msg = msg; l_duyet = duyet; bDausinhton = Dausinhton;
            s_manguon = manguon; s_tenkp = _tenkp; s_tenphieu = _tenphieu;
            this.Text = title; s_title = title; s_mabs = _mabs; s_madoituong = _madoituong;
            l_idvpk = _idvpkhoa; s_makppttt = _makppttt; s_ngay_pttt = _ngay_pttt;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }//End
        //--linh
        public frmXtutruc(string ngay, string makho, string makp, int nhom, int loai, int phieu, int imakp, int imakhoa, int userid, string mmyy, decimal duyet, string title, string msg, bool Dausinhton, int sudungthuoc, string manguon, string _mabn, int buoi, string _tenkp, string _tenphieu, int somay, string _mabs)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            s_ngay = ngay; s_makho = makho; s_makp = (makp == "xx") ? "" : makp;
            i_userid = userid; i_nhom = nhom; i_loai = loai; i_somay = somay;
            i_phieu = phieu; i_buoi = buoi; i_makp = imakp; i_makhoa = imakhoa;
            i_sudungthuoc = sudungthuoc; s_mmyy = mmyy; s_mabn = _mabn;
            s_msg = msg; l_duyet = duyet; bDausinhton = Dausinhton;
            s_manguon = manguon; s_tenkp = _tenkp; s_tenphieu = _tenphieu;
            this.Text = title; s_title = title; s_mabs = _mabs;
        }//end
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
            this.huyetap = new MaskedTextBox.MaskedTextBox();
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
            this.butGoi = new System.Windows.Forms.Button();
            this.butTuongtac = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.cbLoaipttt = new System.Windows.Forms.ComboBox();
            this.lblLoaipttt = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
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
            this.mabn.MaxLength = 10;
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
            this.hoten.TabIndex = 1;
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
            this.mabs.TabIndex = 2;
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
            this.tenbs.TabIndex = 3;
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
            this.manv.TabIndex = 4;
            this.manv.Validated += new System.EventHandler(this.manv_Validated);
            // 
            // tennv
            // 
            this.tennv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv.Enabled = false;
            this.tennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv.Location = new System.Drawing.Point(649, 6);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(141, 21);
            this.tennv.TabIndex = 5;
            this.tennv.TextChanged += new System.EventHandler(this.tennv_TextChanged);
            this.tennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(65, 87);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 3;
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
            this.dausinhton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dausinhton.TabIndex = 1112;
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
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(630, 229);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(160, 226);
            this.treeView1.TabIndex = 226;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 54);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 374);
            this.dataGrid1.TabIndex = 228;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(304, 436);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(320, 21);
            this.tenbd.TabIndex = 13;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(56, 459);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(211, 21);
            this.tenhc.TabIndex = 14;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(-13, 459);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(72, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(213, 436);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(54, 21);
            this.mabd.TabIndex = 12;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(260, 436);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(44, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(169, 436);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(45, 23);
            this.lMabd.TabIndex = 68;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(304, 459);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(72, 21);
            this.dang.TabIndex = 15;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(412, 500);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(73, 21);
            this.soluong.TabIndex = 20;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(348, 498);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(256, 458);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(50, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(544, 500);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(246, 21);
            this.cachdung.TabIndex = 21;
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(442, 500);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 23);
            this.label25.TabIndex = 76;
            this.label25.Text = "Cách dùng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(56, 436);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(122, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(-13, 436);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Đối tượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(656, 526);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 26;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(471, 526);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(55, 25);
            this.butHuy.TabIndex = 28;
            this.butHuy.Text = "&Hủy ";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(412, 526);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(58, 25);
            this.butBoqua.TabIndex = 24;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(358, 526);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(53, 25);
            this.butXoa.TabIndex = 25;
            this.butXoa.Text = "    &Xóa ";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(297, 526);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 23;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(243, 526);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(53, 25);
            this.butLuu.TabIndex = 24;
            this.butLuu.Text = "    &Lưu ";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(189, 526);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(53, 25);
            this.butSua.TabIndex = 27;
            this.butSua.Text = "    &Sửa ";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(135, 526);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(53, 25);
            this.butMoi.TabIndex = 13;
            this.butMoi.Text = "    &Mới ";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butCholai
            // 
            this.butCholai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCholai.Enabled = false;
            this.butCholai.Image = ((System.Drawing.Image)(resources.GetObject("butCholai.Image")));
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(1, 526);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(62, 25);
            this.butCholai.TabIndex = 26;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.listDmbd.Location = new System.Drawing.Point(412, 553);
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
            this.listHoten.Location = new System.Drawing.Point(116, 553);
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
            this.listNv.Location = new System.Drawing.Point(204, 553);
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
            this.listCachdung.Location = new System.Drawing.Point(300, 553);
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
            this.phong.TabIndex = 6;
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
            this.giuong.TabIndex = 7;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(453, 29);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(235, 21);
            this.ghichu.TabIndex = 9;
            this.ghichu.TextChanged += new System.EventHandler(this.ghichu_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(373, 459);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 23);
            this.label20.TabIndex = 96;
            this.label20.Text = "Kho :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(412, 459);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(92, 21);
            this.makho.TabIndex = 16;
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
            this.butChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butChuyen.Appearance = System.Windows.Forms.Appearance.Button;
            this.butChuyen.Image = ((System.Drawing.Image)(resources.GetObject("butChuyen.Image")));
            this.butChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyen.Location = new System.Drawing.Point(725, 526);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(66, 25);
            this.butChuyen.TabIndex = 99;
            this.butChuyen.Text = "Chuyển";
            this.butChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChuyen.CheckedChanged += new System.EventHandler(this.butChuyen_CheckedChanged);
            // 
            // diung
            // 
            this.diung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.diung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diung.Location = new System.Drawing.Point(744, 477);
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
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(544, 459);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(80, 21);
            this.manguon.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(502, 459);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 23);
            this.label22.TabIndex = 105;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmadt_def
            // 
            this.chkmadt_def.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkmadt_def.Location = new System.Drawing.Point(631, 479);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(122, 24);
            this.chkmadt_def.TabIndex = 108;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // vpkhoa
            // 
            this.vpkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vpkhoa.Checked = true;
            this.vpkhoa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vpkhoa.Enabled = false;
            this.vpkhoa.Location = new System.Drawing.Point(6, 506);
            this.vpkhoa.Name = "vpkhoa";
            this.vpkhoa.Size = new System.Drawing.Size(77, 18);
            this.vpkhoa.TabIndex = 16;
            this.vpkhoa.Text = "Trừ cơ số";
            this.vpkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vpkhoa_KeyDown);
            // 
            // chkThuoc
            // 
            this.chkThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(631, 461);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(142, 17);
            this.chkThuoc.TabIndex = 156;
            this.chkThuoc.Text = "Các ngày sử dụng thuốc";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // solan
            // 
            this.solan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solan.Enabled = false;
            this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solan.Location = new System.Drawing.Point(126, 500);
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
            this.solan.TabIndex = 18;
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
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(85, 499);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 158;
            this.label23.Text = "Ngày :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moilan
            // 
            this.moilan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moilan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.moilan.Enabled = false;
            this.moilan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moilan.Location = new System.Drawing.Point(213, 500);
            this.moilan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.moilan.Name = "moilan";
            this.moilan.Size = new System.Drawing.Size(54, 21);
            this.moilan.TabIndex = 19;
            this.moilan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moilan.Validated += new System.EventHandler(this.moilan_Validated);
            // 
            // lbldvt
            // 
            this.lbldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldvt.Location = new System.Drawing.Point(269, 499);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(76, 23);
            this.lbldvt.TabIndex = 161;
            this.lbldvt.Text = "viên";
            this.lbldvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.Location = new System.Drawing.Point(166, 498);
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
            this.songay.TabIndex = 8;
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
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(690, 29);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(100, 21);
            this.tim.TabIndex = 165;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butGoi
            // 
            this.butGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butGoi.Enabled = false;
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(64, 526);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(70, 25);
            this.butGoi.TabIndex = 166;
            this.butGoi.Text = "Chọn &gói";
            this.butGoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // butTuongtac
            // 
            this.butTuongtac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTuongtac.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtac.Image")));
            this.butTuongtac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtac.Location = new System.Drawing.Point(578, 526);
            this.butTuongtac.Name = "butTuongtac";
            this.butTuongtac.Size = new System.Drawing.Size(77, 25);
            this.butTuongtac.TabIndex = 271;
            this.butTuongtac.Text = "Tương tác";
            this.butTuongtac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtac.Click += new System.EventHandler(this.butTuongtac_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(527, 526);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(50, 25);
            this.butIn.TabIndex = 272;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // cbLoaipttt
            // 
            this.cbLoaipttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLoaipttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbLoaipttt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaipttt.Enabled = false;
            this.cbLoaipttt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaipttt.Location = new System.Drawing.Point(453, 51);
            this.cbLoaipttt.Name = "cbLoaipttt";
            this.cbLoaipttt.Size = new System.Drawing.Size(124, 21);
            this.cbLoaipttt.TabIndex = 10;
            this.cbLoaipttt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLoaipttt_KeyDown_1);
            // 
            // lblLoaipttt
            // 
            this.lblLoaipttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoaipttt.AutoSize = true;
            this.lblLoaipttt.Location = new System.Drawing.Point(422, 57);
            this.lblLoaipttt.Name = "lblLoaipttt";
            this.lblLoaipttt.Size = new System.Drawing.Size(33, 13);
            this.lblLoaipttt.TabIndex = 281;
            this.lblLoaipttt.Text = "Loại :";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(12, 482);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 23);
            this.label30.TabIndex = 1113;
            this.label30.Text = "0";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmXtutruc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cbLoaipttt);
            this.Controls.Add(this.lblLoaipttt);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTuongtac);
            this.Controls.Add(this.butGoi);
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
            this.Text = "Phiếu xuất cơ số tủ trực";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            //this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            d.kiemtra_cstt_nhap(s_mmyy, i_nhom);
            bPhonggiuong = m.bPhonggiuong;
            user = d.user; xxx = user + s_mmyy; bSolan = m.bSolan_donthuoc;
            chkThuoc.Checked = i_sudungthuoc != 3;
			bLockytu=d.bLockytu_traiphai(i_nhom);
            bMabd_madoituong = d.bMabd_doituong(i_nhom);
            bHansd_thuoc = m.bHansd_thuoc;
			//if (s_mabn!="") this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dausinhton.Enabled = bDausinhton;
            bThongbaoChiphi = m.Thongso("thongbaochiphi_cd") == "1";
            bThuphi_khongloadthuoc_BHYT = m.bThuphi_khongloadthuoc_BHYT;
            bTrongoi_khongchosua = m.bKhongChoSuaThuocXuatTuTruc_Goi;
            /*
			if (!bDausinhton)
			{
				this.treeView1.Location = new System.Drawing.Point(631, 55);
				treeView1.Height=357;
			}
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
             * */
			bTTngay=(m.bChieu_sang && i_buoi==0)?d.get_ttngay(s_ngay,s_makp):false;
			bTrucoso=d.bTrucoso(i_nhom);
			i_vienphi=m.iVienphi;
            diung.Tag = ""; f_soluong = d.format_soluong(i_nhom);
			bMadoituong=m.bSuadt_thuoc_vp;
			chkmadt_def.Checked=!bMadoituong;
			bNhapten=m.bNhapthuoc_ten;
			bDiungthuoc=m.bDiungthuoc;
			diung.Visible=bDiungthuoc;
            //gam 09/09/2011
            bQuanly_thuocmo = m.bQuanly_thuocmo;
            cbLoaipttt.Visible = bQuanly_thuocmo;
            lblLoaipttt.Visible = bQuanly_thuocmo;
            cbLoaipttt.DisplayMember = "ten";
            cbLoaipttt.ValueMember = "id";
            cbLoaipttt.DataSource = m.get_data("select 1 as id,'Trước mổ' as ten from dual union select 2 as id,'Trong mổ' as ten from dual union select 3 as id,'Sau mổ' as ten from dual").Tables[0];
            //end gam
            dtdmbd = d.get_data("select a.*,nullif(b.nhomvp,0) as nhomvp,nullif(c.id,0) as loaivp from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".v_loaivp c on b.nhomvp=c.id_nhom where a.nhom=" + i_nhom).Tables[0];
            s_makp_bo = "";
            if (s_makp != "")
            {
                dthoten = m.get_hiendien(s_makp, s_ngay).Tables[0];
                listHoten.DisplayMember = "MABN";
                listHoten.ValueMember = "HOTEN";
                listHoten.DataSource = dthoten;
                //
                s_makp_bo = m.f_get_makp_bo(s_makp);
                bPhongkham = m.f_makp_is_phongkham(s_makp);
            }

			dtnv=d.get_data("select ma,hoten,nhom,makp from "+user+".dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";

			listCachdung.DisplayMember="STT";
			listCachdung.ValueMember="TEN";

            dtdt = d.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where sothe>0 and ngay>0 order by madoituong").Tables[0];
            sql = "select * from " + user + ".d_doituong ";
            if (s_madoituong.Trim(',') != "") sql += " where madoituong in (" + s_madoituong.Trim(',') + ")";
            sql += " order by madoituong";
            dtdoituong = d.get_data(sql).Tables[0];
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

            sql = "select distinct a.id,a.mabn,d.hoten,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.mabs,c.manv,c.mach, ";
			sql+="c.nhietdo,c.huyetap,c.nhiptho,c.cannang,c.phong,c.giuong,c.ghichu,a.read,a.songay,a.traituyen,a.trongoi ";
            sql += " from " + xxx + ".d_xtutrucll a inner join " + xxx + ".d_duyet b on a.idduyet=b.id ";
            sql += " left join " + xxx + ".d_dausinhton c on a.id=c.iddutru inner join " + user + ".btdbn d on a.mabn=d.mabn ";
            sql += " inner join (select distinct id,id_ktcao from " + xxx + ".d_xuatsdct ";
            if(m.bMmyy(m.Mmyy_truoc(s_mmyy)))
            {
                sql += " union all select distinct id,id_ktcao from " + user + m.Mmyy_truoc(s_mmyy) + ".d_xuatsdct";
            }
            sql += " ) e on a.id=e.id";
            sql += " where b.id=" + l_duyet;
            if (s_mabn != "") { sql += " and a.mabn='" + s_mabn + "'"; }
            
            sql += " order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
            //ThanhCuong - 06/08/2012 - Kỹ thuật cao
            if (s_mabn != "" && l_idvpk != 0)
            {
                mabn.Text = s_mabn;
                mabn_Validated(sender, e);
            }
            //
			AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dsxoa.ReadXml("..//..//..//xml//d_dutruct.xml");
            try
            {
                dsxoa.Tables[0].Columns.Add("manhom", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
            try
            {
                dsxoa.Tables[0].Columns.Add("maloai", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
            try
            {
                dsxoa.Tables[0].Columns.Add("tennhom");
            }
            catch { }
            try
            {
                dsxoa.Tables[0].Columns.Add("tenloai");
            }
            catch { }
            
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
            sql = "select a.id,a.stt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang," +
                         "f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc," +
                         "' ' as diung,a.manguon,1 as tutruc,a.idvpkhoa,a.solan,a.lan,0 as done ,b.manhom,b.maloai,g.ten as tennhom, h.ten as tenloai,i.hoten ";//ThanhCuong 01/03/2012
            sql += " , to_number('0') as slxuat";
            sql += " from " + xxx + ".d_xtutrucct a left join medibv.dlogin i on a.userid=i.id ";
            sql += " inner join medibv.d_dmbd b on a.mabd=b.id inner join medibv.d_doituong e on a.madoituong= e.madoituong ";
            sql += " inner join medibv.d_dmkho f  on a.makho=f.id inner join medibv.d_dmnhom g on b.manhom=g.id ";
            sql += " inner join medibv.d_dmloai h on b.maloai=h.id ";
            sql += " where a.id_ktcao=0 and a.id=" + l_id + " order by a.stt";
            dtct = d.get_data(sql).Tables[0];
            if (bDiungthuoc) upd_diung();
            if (l_id != 0)
            {
                sql = "select * from " + user + s_mmyy + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                sql += " and idkhoa=" + l_idkhoa + " and id=" + l_id;
                sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and done=1 and makp=" + i_makhoa;
                sql += " and id_ktcao=" + l_idvpk;
                DataRow r1;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    r1 = d.getrowbyid(dtct, "mabd=" + int.Parse(r["mabd"].ToString()) + " and madoituong=" + int.Parse(r["madoituong"].ToString()));
                    if (r1 != null) r1["done"] = 1;
                }
            }
            //
            string asql = "select id, mabd, madoituong, makho, sum(soluong) as soluong";
            asql += " from " + xxx + ".d_xuatsdct ";
            asql += " where id="+l_id;
            asql += " group by id, mabd, madoituong, makho ";
            DataSet ads1 = m.get_data(asql);
            if (ads1 != null && ads1.Tables.Count > 0 && ads1.Tables[0].Rows.Count > 0)
            {
                string sexp = "";
                DataRow dr1;
                foreach (DataRow dr0 in ads1.Tables[0].Rows)
                {
                    sexp = "id='" + dr0["id"].ToString() + "' and mabd='" + dr0["mabd"].ToString() + "' and madoituong='" + dr0["madoituong"].ToString() + "' and makho='" + dr0["makho"].ToString() + "'";
                    dr1 = m.getrowbyid(dtct, sexp);
                    if (dr1 != null)
                    {
                        dr1["slxuat"] = dr0["soluong"].ToString();
                    }
                }
                dtct.AcceptChanges();
            }
            //
            dataGrid1.DataSource = dtct;
            label30.Text = cmbMabn.Items.Count.ToString();//Thuy 04.02.2012

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
			TextCol.HeaderText = "STT";
			TextCol.Width = 25;
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
			TextCol.Format=f_soluong;
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

            TextCol = new DataGridColoredTextBoxColumn(de, 16);
            TextCol.MappingName = "done";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 17);
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Người xuất";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 18);
            TextCol.MappingName = "SLXUAT";
            TextCol.HeaderText = "Trừ Tủ trực";
            TextCol.Width = 70;
            TextCol.Format = f_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
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
            if (this.dataGrid1[row, 16].ToString().Trim() != "0") c = Color.OrangeRed;
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
				soluong.Text=d_soluong.ToString(f_soluong);
				madoituong.SelectedValue=dataGrid1[i,7].ToString();
				makho.SelectedValue=dataGrid1[i,8].ToString();
				cachdung.Text=dataGrid1[i,9].ToString();
				mahc.Text=dataGrid1[i,10].ToString();
				manguon.SelectedValue=dataGrid1[i,12].ToString();
				l_idvpkhoa=(dataGrid1[i,13].ToString()!="")?decimal.Parse(dataGrid1[i,13].ToString()):0;
                solan.Value = decimal.Parse(dataGrid1[i, 14].ToString());
                moilan.Text = dataGrid1[i, 15].ToString();
				vpkhoa.Checked=l_idvpkhoa==0;
				d_soluongcu=d_soluong;
                DataRow r1 = m.getrowbyid(dtct, "stt=" + decimal.Parse(stt.Text));
                i_mabdcu = i_makhocu = i_manguoncu = 0;
                if (r1 != null)
                {
                    i_manguoncu = int.Parse(r1["manguon"].ToString());
                    i_makhocu = int.Parse(r1["makho"].ToString());
                    i_mabdcu = int.Parse(r1["mabd"].ToString());
                }
                i_done = (dataGrid1[i, 16].ToString() == "") ? 0 : int.Parse(dataGrid1[i, 16].ToString());
                if (butLuu.Enabled && !bNew)
                {
                    vpkhoa.Enabled = false;
                    butXoa.Enabled = solan.Enabled = moilan.Enabled = mabd.Enabled = tenbd.Enabled = soluong.Enabled = i_done==0;
                }
			}
            catch(Exception ex) { emp_detail(); }
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
            cbLoaipttt.Enabled = ena;//gam 09/09/2011
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
            if (d.bNhapmaso)
            {
                mabd.Enabled = ena;
            }
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
            butGoi.Enabled = ena;
			butCholai.Enabled=ena;
			butIn.Enabled=butHuy.Enabled=!ena;
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
            mabn.Text = ""; hoten.Text = ""; bRead = false; l_mavaovien = 0; s_ngayvv = ""; nam = ""; s_denngay = "";
            phong.Text = ""; giuong.Text = ""; ghichu.Text = ""; mach.Text = ""; nhiptho.Text = ""; songay.Value = 0;
			huyetap.Text="";nhietdo.Text="";cannang.Text="";l_id=0;l_maql=0;ngay.Text=m.Ngaygio;
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
			dsxoa.Clear();
		}

		private void emp_detail()
		{
            vpkhoa.Checked = true; l_idvpkhoa = 0; solan.Value = 1; i_done = 0;
			moilan.Text=mabd.Text=tenbd.Text=tenhc.Text=dang.Text=cachdung.Text=mahc.Text="";
			soluong.Text="";makho.SelectedIndex=-1;
            try
            {
                if (dtct.Rows.Count <= 0)
                {
                    stt.Text = d.get_data("select max(stt) as stt from " + xxx + ".d_xtutrucct where id=" + l_id).Tables[0].Rows[0][0].ToString();
                    if (stt.Text == "" || stt.Text == "0") { stt.Text = "1"; }
                    else 
                    {
                        int s = int.Parse(stt.Text.ToString()) + 1;
                        stt.Text = s.ToString();
                    }
                }
                else
                {
                    try
                    {
                        int a = int.Parse(d.get_stt(dtct).ToString());
                        int b = int.Parse(d.get_data("select max(stt) as stt from " + xxx + ".d_xtutrucct where id=" + l_id).Tables[0].Rows[0][0].ToString()) + 1;
                        stt.Text = a.ToString();
                        if (b > a) { stt.Text = b.ToString(); }
                    }
                    catch
                    {
                        stt.Text = d.get_stt(dtct).ToString();
                    }
                }
            }
            catch { stt.Text = d.get_stt(dtct).ToString(); }
            i_manguoncu = i_makhocu = i_mabdcu = 0; d_soluongcu = 0;
            if (i_madoituong != 0)
            {
                if (bHansd_thuoc && s_denngay != "" && bTheBHYTHethandung == false)
                {
                    r = d.getrowbyid(dtdt, "madoituong=" + i_madoituong);
                    if (r != null)
                    {
                        if (m.songay(m.StringToDate(s_denngay), m.StringToDate(s_ngay.Substring(0, 10)), 0) >= 0)
                            madoituong.SelectedValue = i_madoituong.ToString();
                    }
                }
            }
            else madoituong.SelectedValue = i_madoituong.ToString();            
		}

		private void load_dm()
		{            
			dtton=d.get_tutructh_dutru(s_mmyy,i_makp,s_makho,s_manguon,0,i_nhom);
			listDmbd.DataSource=dtton;
            listCachdung.DataSource = d.get_data("select ten as stt,ten from " + user + ".d_dmcachdung order by ten").Tables[0];
		}

		private void load_tonct()
		{
			dttonct=d.get_tutrucct_dutru(s_mmyy,i_makp,s_makho,s_manguon,0,i_nhom);
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
			DataRow r1;
			string gi;
            if (s_makp != "" && bPhongkham == false && (s_makp == "99" || s_makp_bo != "01" ))
			{
                r = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
				if (r!=null)
				{
                    s_denngay = r["denngay"].ToString();
					hoten.Text=r["hoten"].ToString();
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["id"].ToString());
                    i_traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
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
                sql =" select a.nam,a.hoten,b.mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mabs,b.madoituong from ";
                sql += "" + user + ".btdbn a," + user + ".benhanngtr b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "'";
                sql += " and b.ngayrv is null ";
                sql += " union all ";
                sql += "select a.nam,a.hoten,b.mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mabs,b.madoituong from ";
                sql += user + ".btdbn a," + zzz + ".benhanpk b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "'";// order by b.maql desc";
                foreach (DataRow r2 in d.get_data(sql).Tables[0].Select("","maql desc ")) //foreach (DataRow r2 in d.get_data(sql).Tables[0].Rows)
                {
                    nam = r2["nam"].ToString().Trim();
                    s_ngayvv = r2["ngay"].ToString();
                    hoten.Text = r2["hoten"].ToString();
                    l_maql = decimal.Parse(r2["maql"].ToString());
                    l_mavaovien = decimal.Parse(r2["mavaovien"].ToString());
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
						l_maql=decimal.Parse(r2["maql"].ToString());
                        l_mavaovien = decimal.Parse(r2["mavaovien"].ToString());
                        i_madoituong = int.Parse(r2["madoituong"].ToString());
                        if (dtct.Rows.Count == 0 && i_madoituong != 0) madoituong.SelectedValue = i_madoituong.ToString();
                        if (bDiungthuoc) load_diungthuoc(mabn.Text);
						l_id=0;
						break;
					}
				}
                if (hoten.Text == "")
                {
                    foreach (DataRow r2 in m.get_hiendien_all(s_ngay, mabn.Text).Tables[0].Rows)
                    {
                        s_denngay = r2["denngay"].ToString();
                        hoten.Text = r2["hoten"].ToString();
                        l_mavaovien = decimal.Parse(r2["mavaovien"].ToString());
                        l_maql = decimal.Parse(r2["maql"].ToString());
                        l_idkhoa = decimal.Parse(r2["id"].ToString());
                        gi = r2["giuong"].ToString().Trim();
                        s_ngayvv = r2["ngay"].ToString();
                        nam = r2["nam"].ToString().Trim();
                        if (mabs.Enabled)
                        {
                            mabs.Text = r2["mabs"].ToString();
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
                        i_madoituong = int.Parse(r2["madoituong"].ToString());
                        if (dtct.Rows.Count == 0 && i_madoituong != 0) madoituong.SelectedValue = i_madoituong.ToString();
                        if (bDiungthuoc) load_diungthuoc(mabn.Text);
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
                    r = d.getrowbyid(dtll, "mabn='" + mabn.Text + "'");
                    if (r != null)
                    {
                        if (l_idvpk == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"), s_msg);
                            mabn.Focus();
                            return;
                        }
                    }
			}
			catch{}
			sql="select b.mabs,b.manv,b.phong,b.giuong,b.ghichu from "+xxx+".d_xtutrucll a,"+xxx+".d_dausinhton b where a.id=b.iddutru and a.mabn='"+mabn.Text+"'";
			sql+=" order by a.id desc";
			foreach(DataRow r2 in d.get_data(sql).Tables[0].Rows)
			{
				if (r2["mabs"].ToString()!="" && mabs.Enabled) mabs.Text=r2["mabs"].ToString();
				if (r2["manv"].ToString()!="") manv.Text=r2["manv"].ToString();
				r1=d.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				r1=d.getrowbyid(dtnv,"ma='"+manv.Text+"'");
				if (r1!=null) tennv.Text=r1["hoten"].ToString();
				else tennv.Text="";
                if (!bPhonggiuong)
                {
                    if (phong.Text == "") phong.Text = r2["phong"].ToString();
                    if (giuong.Text == "") giuong.Text = r2["giuong"].ToString();
                }
				ghichu.Text=r2["ghichu"].ToString();
				break;
			}
			load_congno();
			if (chkThuoc.Checked) load_treeview();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
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
				MessageBox.Show(lan.Change_language_MessageText("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !"),LibMedi.AccessData.Msg);
				return;
            } 
            
            bTheBHYTHethandung = false;
            bMessage_doituong = false;
            bTrongoi = false;
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
			if (bRead)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã cập nhật !"),LibMedi.AccessData.Msg);
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
            if (d.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), LibMedi.AccessData.Msg);
                return;
            }
			l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
            if (s_makp != "" && !bPhongkham && s_makp_bo != "01") //if (s_makp != "")
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
                else if (decimal.Parse(r["id"].ToString()) != l_idkhoa)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã chuyển khoa !"), LibMedi.AccessData.Msg);
                    cmbMabn.Focus();
                    return;
                }
                i_madoituong = int.Parse(r["madoituong"].ToString());
            } 
            if (bTrongoi_khongchosua && bTrongoi)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ca này nhập theo gói, không cho phép sửa !"), LibMedi.AccessData.Msg);
                cmbMabn.Focus();
                return;
            }
            //i_madoituong = d.get_madoituong(l_maql);
			ena_object(true);
			mabn.Enabled=false;
			hoten.Enabled=false;
			bNew=false;
			bEdit=true;
            if (bHansd_thuoc)
            {
                r = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r == null) s_denngay = "";
                else s_denngay = r["denngay"].ToString();

            }
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}
        static Predicate<BietDuocSuDung> FindBDByMa(string mabd)
        {
            return delegate(BietDuocSuDung bd)
            {
                return bd.MaBD == mabd;
            };
        }
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            List<BietDuocSuDung> listdonthuoc = new List<BietDuocSuDung>();
            //  listdonthuoc.Find( );
            foreach (DataRow drrr in dtct.Rows)
            {
                if (listdonthuoc.Exists(FindBDByMa(drrr["ma"].ToString())))
                {
                    listdonthuoc.Find(FindBDByMa(drrr["ma"].ToString())).SoLuong += decimal.Parse(drrr["soluong"].ToString());
                }
                else
                {
                    string t = drrr["soluong"].ToString();
                    listdonthuoc.Add(new BietDuocSuDung(drrr["ma"].ToString(), drrr["ten"].ToString(), decimal.Parse(drrr["soluong"].ToString()), drrr["makho"].ToString(), drrr["manguon"].ToString(),0));
                }
            }
            foreach (BietDuocSuDung bd in listdonthuoc)
            {
                if (!KiemtraVuotkho(bd.MaBD, bd.MaKho, bd.MaNguon, bd.SoLuong,bd.TuTruc))
                {
                    MessageBox.Show("Số lượng thuốc " + bd.TenBD + " trong kho sau khi kiểm tra lại không còn đủ số lượng " + bd.SoLuong + "\nXin điều chỉnh lại đơn thuốc", "Lỗi thiếu thuốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,"-");
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatsd:l_id;
            itable = m.tableid(d.mmyy(s_ngay),"d_xtutrucll");
            DataTable tmp = new DataTable();
            bool bFound = false;
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngayvv+"^"+songay.Value.ToString());
            }
			if (!bNew) 
			{
                sql = "select * from " + user + s_mmyy + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                sql += " and idkhoa=" + l_idkhoa + " and id="+l_id;
                sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and done=1 and makp=" + i_makhoa;
                sql += " and id_ktcao=" + l_idvpk;
                tmp = m.get_data(sql).Tables[0];
                bFound = true;
                foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat, c.gia_bh from " + xxx + ".d_thucxuat a," + xxx + ".d_theodoi b," + user + ".d_dmbd c where a.sttt=b.id and a.mabd=c.id and a.id=" + l_id + " and a.id_ktcao=" + l_idvpk).Tables[0].Rows)
				{
					d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,1,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
					d.upd_theodoicongno(d.delete,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
                    if (!m.bktCao_tinhtungDV) { d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()), mabs.Text); }
                    else { d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()), mabs.Text,l_idvpk); }
				}
                d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + l_id + " and id_ktcao=" + l_idvpk);
                d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id + " and id_ktcao=" + l_idvpk);
			}
			if (l_duyet==0)
			{
                //linh 16102012
                //if (i_somay==1)
                //{
                    //if (d.get_data("select id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0].Rows.Count>0)
                    //{
                    //    MessageBox.Show(lan.Change_language_MessageText("Ngày ")+s_ngay+"\nKhoa "+s_tenkp+"\nPhiếu "+s_tenphieu+"\nĐã nhập !",LibMedi.AccessData.Msg);
                    //    return;
                    //}
                //}
                //else 
                //{
					DataTable dtd=d.get_data("select min(id) as id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'"+" and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0];
					if (dtd.Rows.Count!=0) l_duyet=decimal.Parse(dtd.Rows[0][0].ToString());
					else l_duyet=d.get_id_duyet;
				//}
				if (l_duyet==0) l_duyet=d.get_id_duyet;
                d.upd_duyet(s_mmyy, l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makhoa, (bQuanly_thuocmo ? int.Parse(cbLoaipttt.SelectedValue.ToString() == "" ? "0" : cbLoaipttt.SelectedValue.ToString()) : 0));//gam 09/09/2011
                foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), 0);
			}
            else d.upd_duyet(s_mmyy, l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makhoa, (bQuanly_thuocmo ? int.Parse(cbLoaipttt.SelectedValue.ToString() == "" ? "0" : cbLoaipttt.SelectedValue.ToString()) : 0));//gam 09/09/2011
			d.upd_dausinhton(s_mmyy,l_id,l_idkhoa,l_id,(bDausinhton)?ngay.Text:s_ngay,mabs.Text,manv.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,phong.Text,giuong.Text,ghichu.Text,mabn.Text);
			if (!d.upd_xtutrucll(s_mmyy,l_id,l_duyet,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngayvv,songay.Value))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            d.execute_data("update " + user + s_mmyy + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
            d.execute_data("update " + user + s_mmyy + ".d_xtutrucll set userid=" + i_userid + " where id=" + l_id);// gam060811
            itable = m.tableid(d.mmyy(s_ngay),"d_xtutrucct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_xtutrucct where id=" + l_id + " and id_ktcao=" + l_idvpk + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                    if (decimal.Parse(r1["idvpkhoa"].ToString()) != 0)
                    {
                        v.execute_data("delete from " + xxx + ".v_vpkhoa where id=" + decimal.Parse(r1["idvpkhoa"].ToString()));
                    }
                    if (m.bktCao_tinhtungDV) m.execute_data("update " + xxx + ".d_tienthuoc set id_ktcao=0 where mabn='" + s_mabn + "' and maql=" + l_maql + " and idkhoa=" + l_idkhoa + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "' and makp='" + i_makp.ToString() + "' and madoituong=" + r1["madoituong"].ToString() + " and id_ktcao=" + l_idvpk + " and mabd=" + r1["mabd"].ToString());
				}
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (m.get_data("select * from " + xxx + ".d_xtutrucct where id=" + l_id + " and id_ktcao=" + l_idvpk + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["madoituong"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + "0" + "^" + r1["cachdung"].ToString()+"^"+r1["manguon"].ToString()+"^"+r1["idvpkhoa"].ToString()+"^"+r1["solan"].ToString()+"^"+r1["lan"].ToString());
                }
                else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                d.upd_xtutrucct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), 0, r1["cachdung"].ToString(), int.Parse(r1["manguon"].ToString()), decimal.Parse(r1["idvpkhoa"].ToString()), decimal.Parse(r1["solan"].ToString()), decimal.Parse(r1["lan"].ToString()), decimal.Parse(i_userid.ToString()), l_idvpk);//ThanhCuong - 17/08/2012 - kỹ thuật cao
                d.execute_data("update " + user + s_mmyy + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
                d.execute_data("update " + user + s_mmyy + ".d_xtutrucll set userid=" + i_userid + " where id=" + l_id);
            }
			d.updrec_dutrull(dtll,l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,hoten.Text,mabs.Text,manv.Text,(bDausinhton)?ngay.Text:s_ngay,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,phong.Text,giuong.Text,ghichu.Text,0,1,s_ngayvv);
            d.execute_data("update " + user + s_mmyy + ".d_dutrull set userid=" + i_userid + " where id=" + l_id);
			#region xuatsd
            itable = m.tableid(d.mmyy(s_ngay), "d_xuatsdll");
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + i_phieu.ToString() + "^" + i_makp.ToString() + "^" + i_userid.ToString() + "^" + l_id.ToString() + "^" + "1" + "^" + i_makhoa.ToString() + "^" + "0" + "^" + "0" + "^" +"");
            }
			if (!d.upd_xuatsdll(s_mmyy,l_id,i_nhom,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_loai,i_phieu,i_makp,i_userid,l_id,1,i_makhoa,0,0,"",s_ngay,(bQuanly_thuocmo ? int.Parse(cbLoaipttt.SelectedValue.ToString() == "" ? "0" : cbLoaipttt.SelectedValue.ToString()) : 0),mabs.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh !"),d.Msg);
				return;
			}
            //ThanhCuong - 06/08/2012 - Kỹ thuật cao
            if (s_ngay_pttt != "") m.execute_data("update " + user + s_mmyy + ".pttt set idduoc=" + l_id + " where mabn='" + s_mabn + "'" + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + s_ngay_pttt + "'");
            //End
            d.execute_data("update " + user + s_mmyy + ".d_xuatsdll set traituyen=" + i_traituyen + " where id=" + l_id);

            if (m.bktCao_tinhtungDV) { d.get_xuatsdct_cstt(s_mmyy, dtct.Select("soluong>0 and idvpkhoa=0", "stt"), i_makp, i_makhoa, 0, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, i_loai, 1, s_ngay, i_nhom, s_ngay, i_traituyen, mabs.Text,l_idvpk); }
            else { d.get_xuatsdct_cstt(s_mmyy, dtct.Select("soluong>0 and idvpkhoa=0", "stt"), i_makp, i_makhoa, 0, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, i_loai, 1, s_ngay, i_nhom, s_ngay, i_traituyen, mabs.Text); }
            if (bFound)
            {
                sql = "delete from " + user + s_mmyy + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                sql += " and idkhoa=" + l_idkhoa + " and id="+l_id;
                sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and done=1 and makp=" + i_makhoa+" and soluong=0";
                sql += " and id_ktcao=" + l_idvpk;
                d.execute_data(sql);
                foreach (DataRow r1 in tmp.Rows)
                {
                    sql = "update " + user + s_mmyy + ".d_tienthuoc set done=" + int.Parse(r1["done"].ToString()) + ",idttrv=" + decimal.Parse(r1["idttrv"].ToString());
                    sql += " where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                    sql += " and idkhoa=" + l_idkhoa;
                    sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and makp=" + int.Parse(r1["makp"].ToString());
                    sql += " and id=" + l_id;
                    sql += " and madoituong=" + int.Parse(r1["madoituong"].ToString());
                    sql += " and mabd=" + decimal.Parse(r1["mabd"].ToString());
                    sql += " and done=0";
                    sql += " and id_ktcao=" + l_idvpk;
                    d.execute_data(sql);
                }
            }
            if (d.get_data("select * from " + user + s_mmyy + ".d_xuatsdct where id=" + l_id).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh chi tiết !"), d.Msg);
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
					v.upd_giavp(int.Parse(r1["mabd"].ToString()),decimal.Parse(r["loaivp"].ToString()),int.Parse(r["stt"].ToString()),r["ma"].ToString(),r["ten"].ToString().Trim()+" "+r["hamluong"].ToString(),r["dang"].ToString(),gia,gia,gia,gia,gia,int.Parse(r["bhyt"].ToString()),i_userid,0,0,0,0,0,0,0,0,"");
				}
                itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
				l_idvpkhoa=decimal.Parse(r1["idvpkhoa"].ToString());
				l_idvpkhoa=(l_idvpkhoa==0 || l_idvpkhoa==-1)?v.get_id_vpkhoa:l_idvpkhoa;
				v.upd_vpkhoa(l_idvpkhoa,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,int.Parse(r1["madoituong"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),gia,0,i_userid,i_buoi);
				d.upd_theodoicongno(d.insert,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),Math.Round(decimal.Parse(r1["soluong"].ToString())*gia,3),"vienphi");
                d.execute_data("update " + xxx + ".d_xtutrucct set idvpkhoa=" + l_idvpkhoa + " where id=" + l_id + " and id_ktcao=" + l_idvpk + " and stt=" + int.Parse(r1["stt"].ToString()));
			}	
			#endregion
            if (!kiemtrasoluong(d.get_data("select mabd,sum(soluong) as soluong from " + xxx + ".d_xuatsdct where id=" + l_id + " and id_ktcao=" + l_idvpk + " group by mabd").Tables[0], load_thuoc()))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số lượng không đủ trong tủ trực !"), LibMedi.AccessData.Msg);
                del();
                butBoqua_Click(sender, e);
                return;
            }
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbMabn.SelectedIndex=dtll.Rows.Count-1;
			}
            catch { } 
            if (bTrongoi)
            {
                d.execute_data("update " + user + s_mmyy + ".d_xtutrucll set trongoi=" + ((bTrongoi) ? "1" : "0") + " where id=" + l_id);
                DataRow dr0 = d.getrowbyid(dtll, "id='" + l_id + "'");
                if (dr0 != null)
                {
                    dr0["trongoi"] = (bTrongoi) ? "1" : "0";
                }
                dtll.AcceptChanges();
            }
			if (bDiungthuoc) upd_diung();
			load_grid();
			ref_text();
			ena_object(false);
            if (Tamung_min != 0 && bThongbaoChiphi) thongbao(false);
            listDmbd.Visible = false;
            string s_thuocerr = f_dsthuoc_biloi_xuattutruc();
            if (s_thuocerr != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Một số thuốc sau bị lỗi, không trừ được tủ trực.") + "/" + s_thuocerr + lan.Change_language_MessageText("Đề nghị kích nút sửa và kích nút lưu để chương trình tính lại."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                butSua.Focus();
            }
            else
            {
                butMoi.Focus();
            }
		}

        private string f_dsthuoc_biloi_xuattutruc()
        {
            string s_thuoc_error = "";
            decimal d_slyeucau = 0, d_slxuat = 0;
            foreach (DataRow dr in dtct.Rows)
            {
                d_slyeucau = (dr["soluong"].ToString() == "") ? 0 : decimal.Parse(dr["soluong"].ToString());
                d_slxuat = (dr["slxuat"].ToString() == "") ? 0 : decimal.Parse(dr["slxuat"].ToString());
                if (d_slxuat != d_slyeucau)
                {
                    s_thuoc_error += dr["ten"].ToString() + " [" + dr["ma"].ToString() + "]" + " " + dr["dang"].ToString() + "/n";
                }
            }
            return s_thuoc_error;
        }
        private DataTable load_thuoc()
        {
            sql = "select mabd,sum(slyeucau) as soluong from " + xxx + ".d_xtutrucct where id=" + l_id + " and id_ktcao=" + l_idvpk + " group by mabd";
            return d.get_data(sql).Tables[0];
        }

        private bool kiemtrasoluong(DataTable dt1, DataTable dt2)
        {
            string ma1 = "", ma2 = "";
            int so = dt1.Select("soluong>0").Length;
            foreach (DataRow r in dt1.Select("soluong>0", "mabd,soluong")) ma1 += r["mabd"].ToString().PadLeft(7, '0') + r["soluong"].ToString().Trim() + ",";
            foreach (DataRow r in dt2.Select("soluong>0", "mabd,soluong")) ma2 += r["mabd"].ToString().PadLeft(7, '0') + r["soluong"].ToString().Trim() + ",";
            return ma1 == ma2;
        }

        private void del()
        {
            foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat, b.gia_bh from " + xxx + ".d_thucxuat a," + xxx + ".d_theodoi b where a.sttt=b.id and a.mabd=c.id and a.id=" + l_id).Tables[0].Rows)
            {
                d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, i_makp, i_loai, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                d.upd_theodoicongno(d.delete, mabn.Text, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),mabs.Text);
            }
            foreach (DataRow r1 in d.get_data("select * from " + xxx + ".d_xtutrucct where idvpkhoa<>0 and id=" + l_id).Tables[0].Rows)
                v.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id=" + decimal.Parse(r1["idvpkhoa"].ToString()));
            d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + l_id);
            d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id);
            d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + l_id);
            d.execute_data("delete from " + xxx + ".d_xtutrucct where id=" + l_id);
            d.execute_data("delete from " + xxx + ".d_xtutrucll where id=" + l_id);
            d.execute_data("delete from " + xxx + ".d_dausinhton where iddutru=" + l_id);
            d.delrec(dtll, "id=" + l_id);
            dtll.AcceptChanges();
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
            cmbMabn.Refresh();
            //if (cmbMabn.Items.Count == 0)
            //{
            //    d.execute_data("delete from " + xxx + ".d_duyet where id=" + l_duyet);
            //    d.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
            //    l_duyet = 0;
            //}
            if (cmbMabn.Items.Count > 0) l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
            else l_id = 0;
            load_head();
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbMabn.SelectedIndex=i_old;
			}
			catch{}
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
            if (!bTru_tonao) load_dm();
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
                    s_makho_doituong = dtdoituong.Rows[madoituong.SelectedIndex]["makho"].ToString().Trim();
                    s_makho_doituong = (s_makho_doituong != "") ? s_makho_doituong.Substring(0, s_makho_doituong.Length - 1) : "";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
					if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
                    if (s_makho_doituong != "") sql += " and makho in (" + s_makho_doituong + ")";
				}
                if (bThuphi_khongloadthuoc_BHYT && madoituong.SelectedValue.ToString() != "1") sql += " and bhyt=0 ";
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
                    s_makho_doituong = dtdoituong.Rows[madoituong.SelectedIndex]["makho"].ToString().Trim();
                    s_makho_doituong = (s_makho_doituong != "") ? s_makho_doituong.Substring(0, s_makho_doituong.Length - 1) : "";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
					if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
                    if (s_makho_doituong != "") sql += " and makho in (" + s_makho_doituong + ")";
				}
                if (bThuphi_khongloadthuoc_BHYT && madoituong.SelectedValue.ToString() != "1") sql += " and bhyt=0 ";
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
                    if (bHansd_thuoc && s_denngay != "")
                    {
                        r = d.getrowbyid(dtdt, "madoituong=" + i_madoituong);
                        if (r != null)
                        {
                            if (m.songay(m.StringToDate(s_denngay), m.StringToDate(s_ngay.Substring(0, 10)), 0) >= 0)
                            {
                                if (int.Parse(madoituong.SelectedValue.ToString()) != i_madoituong && bMessage_doituong==false)
                                {                                    
                                    if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"), s_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        madoituong.SelectedValue = i_madoituong.ToString();
                                    else
                                        bMessage_doituong = true;
                                    //                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        if (int.Parse(madoituong.SelectedValue.ToString()) != i_madoituong && bMessage_doituong==false)
                        {
                            if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"), s_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                madoituong.SelectedValue = i_madoituong.ToString();
                            else bMessage_doituong = true;
                            //
                        }
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
				if (vpkhoa.Enabled) listDmbd.Tonkhoct(mabd,tenbd,vpkhoa,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width-8,mabd.Height+5);
                else if (solan.Enabled) listDmbd.Tonkhoct(mabd, tenbd, solan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + madoituong.Width + lMabd.Width + treeView1.Width - 8, mabd.Height + 5);
                else listDmbd.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width-8,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				if (vpkhoa.Enabled) listDmbd.Tonkhoct(tenbd,mabd,vpkhoa,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width-8,mabd.Height+5);
				else if (solan.Enabled) listDmbd.Tonkhoct(tenbd,mabd,solan,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width-8,mabd.Height+5);
                else listDmbd.Tonkhoct(tenbd, mabd, soluong, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + madoituong.Width + lMabd.Width + treeView1.Width - 8, mabd.Height + 5);
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
								if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh dị ứng thuốc")+" \n"+tenhc.Text.Trim()+"\nBạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
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
					l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id='"+l_id+"'");
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
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
                    bTrongoi = r["trongoi"].ToString() == "1";
					bRead=r["read"].ToString()=="1";
                    songay.Value = decimal.Parse(r["songay"].ToString());
					if (chkThuoc.Checked) load_treeview();
					if (bDiungthuoc) load_diungthuoc(mabn.Text);
					load_congno();
				}
			}
			catch
            {
                l_id=0;
            }
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
            if (s_makp != "" && !bPhongkham && s_makp_bo != "01")
			{
                l_maql = 0; l_mavaovien = 0; l_idkhoa = 0;
				r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
                //Thuy 18.01.12
                if (d.get_data("select id from " + user + ".xuatkhoa where id=" + r["id"] + "").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã xuất khoa !"), s_msg);
                    mabn.Focus();
                    return false;
                }
                //end Thuy 18.01.12
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
					mabn.Focus();
					return false;
				}
                nam = r["nam"].ToString().Trim();
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mặt hàng !"), LibMedi.AccessData.Msg);
                butThem.Focus();
                return false;
            }
			return true;
		}

		private bool KiemtraDetail(string tt)
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
            if (soluong.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                soluong.Focus();
                return false;
            }
            else
            {
                decimal sl = decimal.Parse(soluong.Text);
                if (sl == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                    soluong.Focus();
                    return false;
                }
            }
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn đối tượng !"),s_msg);
				if (!madoituong.Enabled) madoituong.Enabled=true;
				madoituong.Focus();
				return false;
            } 
            if (bTheBHYTHethandung && madoituong.SelectedValue.ToString() == "1")
            {
                madoituong.SelectedValue = 2;//thu phi
            }
			if (madoituong.SelectedIndex!=-1)
			{
                if (bHansd_thuoc && s_denngay != "")
                {
                    r = d.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.SelectedValue.ToString()));
                    if (r != null)
                    {
                        if (m.songay(m.StringToDate(s_denngay), m.StringToDate(s_ngay.Substring(0, 10)), 0) < 0)
                        {
                            bTheBHYTHethandung = true;
                            MessageBox.Show(lan.Change_language_MessageText("Đối tượng")+" " + madoituong.Text + " hết hạn sử dụng {" + s_denngay + "}", d.Msg);
                            if (madoituong.Enabled) madoituong.Focus();
                            else
                            {
                                madoituong.SelectedValue = 2;//thu phi
                                mabd.Focus();
                            }
                            return false;
                        }
                    }
                }
				sql="id="+i_mabd+" and makho="+int.Parse(makho.SelectedValue.ToString());
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
				s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
				s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
				s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
                s_makho_doituong = dtdoituong.Rows[madoituong.SelectedIndex]["makho"].ToString().Trim();
                s_makho_doituong = (s_makho_doituong != "") ? s_makho_doituong.Substring(0, s_makho_doituong.Length - 1) : "";
				if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
				if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
                if (s_makho_doituong != "") sql += " and makho in (" + s_makho_doituong + ")";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tên thuốc và đối tượng/nhóm không hợp lệ !"),s_msg);
					madoituong.Focus();
					return false;
                }
                else if (madoituong.SelectedValue.ToString() == "1" && decimal.Parse(dr[0]["bhyt"].ToString()) == 0)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Thuốc, Vật tư này BHYT không chi trả, chương trình sẽ chuyển sang đối tượng thu phí.\nBạn có muốn tiếp tục không?!"), s_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                        madoituong.SelectedValue = 2;
                    else if (madoituong.Enabled) { madoituong.Focus(); return false; }
                    else { mabd.Focus(); return false; }
                }
                else if (i_madoituong == 1 && madoituong.SelectedValue.ToString() != "1" && madoituong.SelectedValue.ToString() != "5" && decimal.Parse(dr[0]["bhyt"].ToString()) != 0 && bTheBHYTHethandung == false)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Thuốc, vật tư này BHYT có chi trả, Bạn có muốn chuyển lại đối tượng BHYT không?!"), s_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                        madoituong.SelectedValue = i_madoituong;

                }
			}
            //if (d_soluongcu != 0) return true;
            //else 
                if (dtct.Select("mabd=" + i_mabd+" and stt<>"+int.Parse(stt.Text)+" and madoituong="+madoituong.SelectedValue.ToString()).Length > 0 && tt == "-")
            {
                MessageBox.Show(tenbd.Text.Trim() + " " + dang.Text.Trim() + " đã nhập !", LibMedi.AccessData.Msg);
                mabd.Focus();
                return false;
            }
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (l_maql==0 && s_makp!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
				mabn.Focus();
				return;
			}
			if (d.bNhapmaso) mabd.Enabled=true;
            if (bSolan)
            {
                moilan.Enabled = solan.Enabled = true;
            }
            butXoa.Enabled = tenbd.Enabled = soluong.Enabled = true;
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
			if (!upd_table(dsxoa.Tables[0],"+")) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,string tt)
		{
            DataSet ads = new DataSet();
            string asql = "";
			if (!KiemtraDetail(tt)) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d.updrec_dutruct(tt,dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,mahc.Text,int.Parse(manguon.SelectedValue.ToString()),1,(vpkhoa.Checked)?0:(l_idvpkhoa==0)?-1:l_idvpkhoa,solan.Value,(moilan.Text!="")?decimal.Parse(moilan.Text):1,dtton,i_mabdcu);
            if (tt == "-")
            {
                DataRow r = d.getrowbyid(dt, "stt=" + int.Parse(stt.Text));
                if (r != null) r["done"] = i_done;
            }
            asql = "select a.manhom,a.maloai,b.ten as tennhom,c.ten as tenloai from " + user + ".d_dmbd a inner join " + user
                + ".d_dmnhom b on a.manhom=b.id inner join " + user + ".d_dmloai c on a.maloai=c.id where a.id=" + i_mabd;
            ads = d.get_data(asql);
            foreach (DataRow r in dt.Select("mabd=" + i_mabd))
            {
                r["manhom"] = ads.Tables[0].Rows[0]["manhom"].ToString();
                r["maloai"] = ads.Tables[0].Rows[0]["maloai"].ToString();
                r["tennhom"] = ads.Tables[0].Rows[0]["tennhom"].ToString();
                r["tenloai"] = ads.Tables[0].Rows[0]["tenloai"].ToString();
            }
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}
        private bool KiemtraVuotkho(string MaBD, string makho, string manguon, decimal soluongkiemtra, int tutruc)
        {
            DataTable dtton = d.get_tutructh_dutru(s_mmyy,i_makp, makho, manguon,0, i_nhom);
            //d.get_tutructh_dutru(s_mmyy, i_makp, s_makho, s_manguon, 0, i_nhom);
            if (vpkhoa.Checked)
            {
                DataRow r = d.getrowbyid(dtton, "ma='" + MaBD + "'");
                if (r != null && r["manguon"].ToString() != "-1")
                {
                    int i_mabd = int.Parse(r["id"].ToString());
                    if (i_mabdcu != 0 && i_mabdcu != i_mabd)
                    {
                        d_soluongcu = 0;
                    }
                    decimal d_soluongton = d.get_slton_nguon(dtton, int.Parse(makho), i_mabd, int.Parse(manguon), d_soluongcu);
                    //d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu)
                    if (soluongkiemtra > d_soluongton)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
                if (soluong.Text.IndexOf("/") != -1)
                {
                    string s1 = soluong.Text.Substring(0, soluong.Text.IndexOf("/")), s2 = soluong.Text.Substring(soluong.Text.IndexOf("/") + 1);
                    if (s1 != "" && s2 != "")
                    {
                        decimal sl = (s2 == "0") ? decimal.Parse(s1) : decimal.Parse(s1) / decimal.Parse(s2);
                        soluong.Text = sl.ToString();
                    }
                }
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(f_soluong);
				if (vpkhoa.Checked)
				{
					if (mabd.Text!="" && tenbd.Text!="")
					{
						r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
						if (r!=null)
						{
							i_mabd=int.Parse(r["id"].ToString());
                            if (i_mabdcu != 0 && i_mabdcu != i_mabd)
                            {
                                d.updrec_tonkho_tutruc_nguon(dtton, i_makhocu, i_manguoncu, i_mabdcu, 0, d_soluongcu, "+");
                                d_soluongcu = 0;
                            }
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
                if (soluong.Text == "") return;
                else
                {
                    decimal sl = decimal.Parse(soluong.Text);
                    if (sl == 0) return;
                }
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
							else d.updrec_dutruct("-",dtct,d.get_stt(dtct),madoituong.Text,i_mabd,r1["ma"].ToString(),r1["tenbd"].ToString(),r1["tenhc"].ToString(),r1["dang"].ToString(),makho.Text,decimal.Parse(r1["soluong"].ToString()),int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,r1["mahc"].ToString(),int.Parse(manguon.SelectedValue.ToString()),1,(vpkhoa.Checked)?0:(l_idvpkhoa==0)?-1:l_idvpkhoa,1,1,dtton,0);
						}						 			
						if (s!="") MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ tồn")+"\n"+s,d.Msg);
					}
				}

			}
			catch{}
		}

        private bool kiemtra_vienphi()
        {
            /*
            bool bFound = false;
            sql = "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien ";
            sql += " from " + xxx + ".d_thucxuat a," + xxx + ".d_theodoi b ," + user + ".d_dmbd c ";
            sql += " where a.sttt=b.id and b.mabd=c.id and a.id=" + l_id;
            foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
            {
                sql = "select * from " + user + s_mmyy + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                sql += " and idkhoa=" + l_idkhoa + " and madoituong=" + int.Parse(r1["madoituong"].ToString());
                sql += " and mabd=" + int.Parse(r1["mabd"].ToString()) + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and giamua=" + decimal.Parse(r1["giamua"].ToString()) + " and done=1 and makp="+i_makhoa;
                bFound = d.get_data(sql).Tables[0].Rows.Count > 0;
                if (bFound) break;
            }
            return bFound;
             * */
            return dtct.Select("done=1").Length > 0;
        }

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbMabn.Items.Count==0) return;
				if (bRead)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã cập nhật !"),LibMedi.AccessData.Msg);
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
                        string zzz = xxx;
                        if (m.bMmyy(d.mmyy(s_ngay))) zzz = user + d.mmyy(s_ngay);
                        sql = " select b.mabn,a.nam,a.hoten,b.mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mabs,b.madoituong from ";
                        sql += "" + user + ".btdbn a," + user + ".benhanngtr b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "'";
                        sql += " union all ";
                        sql += "select b.mabn,a.nam,a.hoten,b.mavaovien,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mabs,b.madoituong from ";
                        sql += user + ".btdbn a," + zzz + ".benhanpk b where a.mabn=b.mabn and a.mabn='" + mabn.Text + "'";
                        if (m.get_data(sql).Tables[0].Select("mabn='" + mabn.Text + "'").Length <= 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã xuất viện !"), LibMedi.AccessData.Msg);
                            cmbMabn.Focus();
                            return;
                        }
					}
				}
                if (kiemtra_vienphi())
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những thuốc này người bệnh")+" " + hoten.Text + " đã thanh toán !", LibMedi.AccessData.Msg);
                    return;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = m.tableid(d.mmyy(s_ngay), "d_thucxuat");
                    foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat from " + xxx + ".d_thucxuat a," + xxx + ".d_theodoi b where a.sttt=b.id and a.id=" + l_id + " and a.id_ktcao=" + l_idvpk).Tables[0].Rows)
					{
						d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,1,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
						d.upd_theodoicongno(d.delete,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
                        //d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),mabs.Text);d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),mabs.Text);
                        d.upd_tienthuoc(d.delete, s_mmyy, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()), mabs.Text, l_idvpk);
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_thucxuat", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
					}
                    itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                    foreach (DataRow r1 in d.get_data("select * from " + xxx + ".d_xtutrucct where idvpkhoa<>0 and id=" + l_id + " and id_ktcao=" + l_idvpk).Tables[0].Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + m.mmyy(s_ngay) + ".v_vpkhoa", "id=" + decimal.Parse(r1["idvpkhoa"].ToString())));
                        v.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id=" + decimal.Parse(r1["idvpkhoa"].ToString()));
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
                    d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + l_id + " and id_ktcao=" + l_idvpk);
                    d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id + " and id_ktcao=" + l_idvpk);
                    try
                    {
                        if (m.get_data("select * from " + xxx + ".d_xuatsdct where id=" + l_id).Tables[0].Rows.Count <= 0)
                        {
                            d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + l_id);
                        }
                    }
                    catch 
                    {
                        d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + l_id);
                    }
                    d.execute_data("delete from " + xxx + ".d_xtutrucct where id=" + l_id + " and id_ktcao=" + l_idvpk);
                    try
                    {
                        if (m.get_data("select * from " + xxx + ".d_xtutrucct where id=" + l_id).Tables[0].Rows.Count <= 0)
                        {
                            d.execute_data("delete from " + xxx + ".d_xtutrucll where id=" + l_id);
                            d.execute_data("delete from " + xxx + ".d_dausinhton where iddutru=" + l_id);
                            d.delrec(dtll, "id=" + l_id);
                        }
                    }
                    catch
                    {
                        d.execute_data("delete from " + xxx + ".d_xtutrucll where id=" + l_id);
                        d.execute_data("delete from " + xxx + ".d_dausinhton where iddutru=" + l_id);
                        d.delrec(dtll, "id=" + l_id);
                    }
					dtll.AcceptChanges();
                    if (d_idcu != 0 && d_idcu == l_id) d_idcu = 0;
                    CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.RowFilter = "";
					cmbMabn.Refresh();
                    //if (cmbMabn.Items.Count == 0)
                    //{
                    //    d.execute_data("delete from " + xxx + ".d_duyet where id=" + l_duyet);
                    //    d.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
                    //    l_duyet = 0;
                    //}
					if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
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
			if (mabn.Text.Trim().Length!=8)
			{
				mabn.Focus();
				return;
			}
            decimal idcholai = d.get_cholai(s_ngayvv, s_ngay, mabn.Text, i_phieu, "d_xtutrucll", "d_xtutrucct",s_makho);
			if (idcholai==0) return;
			sql="select b.madoituong,b.makho,b.mabd,b.slyeucau as soluong,b.cachdung, ";
			sql+=" d.doituong,e.ten as tenkho,f.ma,f.ten,f.tenhc,f.dang,f.mahc,b.manguon,b.solan ";
			sql+=" from xxx.d_xtutrucll a, xxx.d_xtutrucct b, xxx.d_duyet c,"+user+".d_doituong d,"+user+".d_dmkho e,"+user+".d_dmbd f ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.madoituong=d.madoituong ";
			sql+=" and b.makho=e.id and b.mabd=f.id and a.id="+idcholai+" and b.idvpkhoa=0"; 
			sql+=" order by b.stt";
			string s="";i_mabd=0;
            int stt = 0; DataRow r1;
			foreach(DataRow r in d.get_thuoc(s_ngayvv,s_ngay,sql).Tables[0].Rows)
			{
				i_mabd=int.Parse(r["mabd"].ToString());
				d_soluong=decimal.Parse(r["soluong"].ToString());
				d_soluongton=d.get_slton_nguon(dtton,int.Parse(r["makho"].ToString()),i_mabd,int.Parse(r["manguon"].ToString()),0);
				if (d_soluong>d_soluongton) s+=r["ten"].ToString()+" "+r["dang"].ToString()+" ("+d_soluongton.ToString("###,###,###0.000")+")\n";
				d_soluong=(d_soluong>d_soluongton)?d_soluongton:d_soluong;
                stt = d.get_stt(dtct);
				d.updrec_dutruct("-",dtct,stt,r["doituong"].ToString(),i_mabd,r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r["tenkho"].ToString(),d_soluong,int.Parse(r["madoituong"].ToString()),int.Parse(r["makho"].ToString()),r["cachdung"].ToString(),r["mahc"].ToString(),int.Parse(r["manguon"].ToString()),1,0,decimal.Parse(r["solan"].ToString()),1,dtton,0);
                r1 = d.getrowbyid(dtct, "stt=" + stt);
                if (r1 != null) r1["done"] = 0;
			}
			if (i_mabd!=0 && s!="")
				MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n")+s,s_msg);
			ref_text();
		}

		private void butChuyen_CheckedChanged(object sender, System.EventArgs e)
		{
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
                //
                //Truong hop: khi cung 1 phieu: nhung phat sinh ra nhieu d_duyet.id (do co nhieu may cung nhap lieu) --> gom lai 1 d_duyet.id duy nhat
                // va cung luon 1 makhoa trong d_duyet thi moi gom lai 
                string s_idduyet = m.f_get_idduyet(s_mmyy, s_ngay, i_nhom, i_loai, i_phieu, i_makp, l_duyet, s_makp);//Dong 140711
                m.f_chuyen_idduyet(s_mmyy, s_idduyet, l_duyet, i_loai);
                //
                //
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
					m.close();this.Close();
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
                        i_duyet = 1;
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
			m.close();this.Close();
		}

		private void frmXtutruc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F8) diung_Click(null,null);	
		}

		private void diung_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
			frmDiungthuoc f=new frmDiungthuoc(m,cmbMabn.Text,hoten.Text,"","");
			f.ShowDialog(this);
			load_diungthuoc(cmbMabn.Text);
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
							if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh dị ứng thuốc")+" "+" \n"+tenhc.Text.Trim()+"\n"+"Bạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
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
                    s_makho_doituong = dtdoituong.Rows[madoituong.SelectedIndex]["makho"].ToString().Trim();
                    s_makho_doituong = (s_makho_doituong != "") ? s_makho_doituong.Substring(0, s_makho_doituong.Length - 1) : "";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
                    if (s_makho_doituong != "") sql += " and makho in (" + s_makho_doituong + ")";
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
            if (d.bTinnhan_sound(i_nhom))
            {
                foreach (DataRow r in dtkho.Rows)
                    if (r["computer"].ToString() != "")
                        m.upd_tinnhan(r["computer"].ToString().Trim(), "duoc",1);
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
            gc_cachdung();
        }

        private void gc_cachdung()
        {
            if (moilan.Text != "")
            {
               // d_soluongcu = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0; truongthuy 12042014
                r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                if (r != null && dang.Text.Trim()==lbldvt.Text.Trim())
                {
                    DataRow r1 = d.getrowbyid(dtdmbd, "id=" + int.Parse(r["id"].ToString()));
                    if (r1 != null)
                        cachdung.Text = r1["duongdung"].ToString().Trim() + " ngày " + solan.Value.ToString() + " lần , lần " + moilan.Text.ToString().Trim() + " " + ((r1["donvidung"].ToString() != "") ? r1["donvidung"].ToString().Trim() : r1["dang"].ToString());
                }
                decimal sl = Math.Max(songay.Value, 1) * solan.Value * decimal.Parse(moilan.Text);
                // d_soluongcu = sl;  truongthuy 12042014
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
                    l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_id = 0; }
                load_head();
            }
        }

        private void butGoi_Click(object sender, EventArgs e)
        {
            if (mabn.Text.Trim().Length < 8)
            {
                mabn.Focus();
                return;
            }
            frmChongoi f = new frmChongoi(m,-1,i_nhom);
            f.GoiPTTT = bGoiPTTT;
            f.Ma_Mau_PTTT = s_MaMauPTTT;
            f.Ma_PTTT = s_MaPTTT;
            f.ShowDialog(); 
            if (f.dt.Rows.Count > 0)
            {
                string s = ""; i_mabd = 0;
                DataRow r1;
                string madoituong_tmp="0";
                string s_exp = "";
                //
                //
                foreach (DataRow r in f.dt.Rows)
                {
                    //
                    i_mabd = int.Parse(r["mabd"].ToString());
                    s_exp = "id=" + i_mabd + " and soluong>0 ";
                    madoituong_tmp = r["madoituong"].ToString();
                    if (madoituong_tmp == "0") madoituong_tmp = madoituong.SelectedValue.ToString();
                    if (madoituong_tmp == "1") s_exp += " and bhyt<>0";
                    if (madoituong_tmp != "0")
                    {
                        DataRow r_dt = m.getrowbyid(dtdoituong, "madoituong=" + madoituong_tmp);
                        s_nguon_doituong = r_dt["nguon"].ToString().Trim();
                        s_nguon_doituong = (s_nguon_doituong != "") ? s_nguon_doituong.Substring(0, s_nguon_doituong.Length - 1) : "";
                        s_nhom_doituong = r_dt["manhom"].ToString().Trim();
                        s_nhom_doituong = (s_nhom_doituong != "") ? s_nhom_doituong.Substring(0, s_nhom_doituong.Length - 1) : "";
                        s_makho_doituong = r_dt["makho"].ToString().Trim();
                        s_makho_doituong = (s_makho_doituong != "") ? s_makho_doituong.Substring(0, s_makho_doituong.Length - 1) : "";
                        if (s_nguon_doituong != "") s_exp += " and manguon in (" + s_nguon_doituong + ")";
                        if (s_nhom_doituong != "") s_exp += " and manhom in (" + s_nhom_doituong + ")";
                        if (s_makho_doituong != "") s_exp += " and makho in (" + s_makho_doituong + ")";
                    }
                    //
                    d_soluong = Math.Max(songay.Value,1)*decimal.Parse(r["soluong"].ToString());
                    r1 = m.getrowbyid(dtton, s_exp);
                    if (r1 != null)
                    {
                        d_soluongton = d.get_slton_nguon(dtton, int.Parse(r1["makho"].ToString()), i_mabd, int.Parse(r1["manguon"].ToString()), 0);
                        if (d_soluong > d_soluongton) s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.000") + ")\n";
                        d_soluong = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                        if (r["madoituong"].ToString() != "0")
                        {
                            madoituong.SelectedValue = r["madoituong"].ToString();
                        }
                        else if (bMabd_madoituong && r1["madoituong"].ToString() != "0") madoituong.SelectedValue = r1["madoituong"].ToString();
                        
                        //else madoituong.SelectedValue = i_madoituong.ToString(); //gam 08/09/2011 nếu lấy mã đối tượng theo người dùng chọn
                        d.updrec_dutruct("-", dtct, d.get_stt(dtct),madoituong.Text, i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r1["tenkho"].ToString(), d_soluong, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(r1["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r1["manguon"].ToString()), 1, 0, 1, 1, dtton,0);
                    }
                    else
                    {
                        s += r["ten"].ToString() + " [" + r["ma"].ToString() + "]" + "\n";
                    }
                }
                if (i_mabd != 0 && s != "")
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s, s_msg);
                ref_text();
                bTrongoi = f.dt.Rows.Count > 0;
                if (bTrongoi_khongchosua && bTrongoi) butLuu_Click(null, null);
            }
        }

        private void butTuongtac_Click(object sender, EventArgs e)
        {
            testc.clsTuongtac t = new testc.clsTuongtac();
            bool b_tuongtac = t.kiemtra_tuongtac(dtct, i_nhom);
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (cmbMabn.Items.Count == 0) return;
            DataTable tmp = dtct.Copy();
            
            //gam 26/08/2011 them dongia 
            DataTable dtTienthuoc;
            DataRow rDongia;
            try
            {
                tmp.Columns.Add("Dongia",typeof(decimal));
            }
            catch { }
            if (tmp.Rows.Count > 0)
                dtTienthuoc = m.get_data("select maql,mabd,soluong,giaban as dongia from "+m.user+s_mmyy+".d_tienthuoc where id="+tmp.Rows[0]["id"].ToString()).Tables[0];
            else
                dtTienthuoc = m.get_data("select maql,mabd,soluong,giaban as dongia from " + m.user + s_mmyy + ".d_tienthuoc where 1=2").Tables[0];
            foreach (DataRow rct in tmp.Rows)
            {
                rDongia = m.getrowbyid(dtTienthuoc,"mabd="+rct["mabd"].ToString());
                rct["dongia"] = rDongia["dongia"].ToString();
            }
            //end gam
            string s_phai = "Nam", s_tuoi = "",asovaovien="";
            try
            {
                foreach (DataRow r in m.get_data("select to_number(to_char(now(),'yyyy'),'9999')-to_number(namsinh,'9999') as tuoi,phai from " + user + ".btdbn where mabn='" + cmbMabn.Text + "'").Tables[0].Rows)
                {
                    s_phai = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                    s_tuoi = r["tuoi"].ToString();
                }
            }
            catch { }
            int irec = tmp.Rows.Count, n = 21;
            if (irec < n)
            {
                DataRow r1;
                for (int i = irec; i < n - irec; i++)
                {
                    r1 = tmp.NewRow();
                    r1["ten"] = "";
                    r1["soluong"] = 0;
                    r1["dang"] = "";
                    r1["cachdung"] = "";
                    tmp.Rows.Add(r1);
                }
            }
            // gam thêm field sovaovien
            try
            {
                string sql = " select sovaovien from medibv.benhandt where to_char(maql)='" + l_maql + "' and mabn='" + cmbMabn.Text +"'";
                sql += " union all ";
                sql += " select sovaovien from medibv.benhanngtr where to_char(maql)='" + l_maql + "' and mabn='" + cmbMabn.Text + "' ";
                sql += " union all ";
                sql += " select sovaovien from " + xxx + ".benhancc where to_char(maql)='" + l_maql + "' and mabn='" + cmbMabn.Text + "'";
                sql += " union all ";
                sql += " select sovaovien from " + xxx + ".benhanpk where to_char(maql)='" + l_maql + "' and mabn='" + cmbMabn.Text + "'";
                DataSet ds = d.get_data(sql);
                asovaovien = ds.Tables[0].Rows[0]["sovaovien"].ToString();
            }
            catch { }
            tmp.Columns.Add("sovaovien");
            tmp.Rows[0]["sovaovien"] = asovaovien;
            tmp.WriteXml("ylenh_cstt.xml",XmlWriteMode.WriteSchema);

            dllReportM.frmReport f = new dllReportM.frmReport(m, tmp, "ylenh_cstt.rpt", mabn.Text, hoten.Text, tenbs.Text, tennv.Text, s_ngay.Substring(0, 10), s_tenkp, s_tuoi, s_phai, s_tenphieu,phong.Text+"/"+giuong.Text);
            f.ShowDialog();
        }

        private void moilan_Validated(object sender, EventArgs e)
        {
            moilan.Tag = moilan.Text;
            if (moilan.Text.IndexOf("/") != -1)
            {
                string s1 = moilan.Text.Substring(0, moilan.Text.IndexOf("/")), s2 = moilan.Text.Substring(moilan.Text.IndexOf("/") + 1);
                if (s1 != "" && s2 != "")
                {
                    decimal sl = (s2 == "0") ? decimal.Parse(s1) : decimal.Parse(s1) / decimal.Parse(s2);
                    moilan.Text = sl.ToString();
                }
            }
            try
            {
                decimal d_moilan = (moilan.Text != "") ? decimal.Parse(moilan.Text) : 0;
                if (d_moilan != 0) moilan.Text = d_moilan.ToString(f_soluong);
            }
            catch { moilan.Text = "1"; }
            gc_cachdung();
        }

        private void thongbao(bool skip)
        {
            if (Tamung_min != 0)
            {
                string s = m.get_chiphi_mabn(mabn.Text, l_maql, 1, false);
                string[] a_chiphi = s.Split('~');
                chiphi = decimal.Parse(a_chiphi[0]);// (s.Substring(0, s.IndexOf("~")));
                tamung = decimal.Parse(a_chiphi[1]);//s.Substring(s.IndexOf("~") + 1));
                decimal bhyttra = decimal.Parse(a_chiphi[2]);//s.Substring(s.IndexOf("~") + 1));
                decimal bntra = decimal.Parse(a_chiphi[3]);
                decimal conlai = tamung + bhyttra - chiphi;//chi phi -tamung - bhyttra;
                if (conlai < Tamung_min && !skip)
                {
                    s = "Tổng chi phí :" + chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "Tạm ứng      :" + tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "BHYT Trả      :" + bhyttra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "BN phải Trả      :" + bntra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    if (conlai > 0)
                    {
                        s += "BN Thừa tiền    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                        s += "Yêu cầu người bệnh đóng tạm ứng !";
                    }
                    else
                    {
                        conlai = conlai * -1;
                        s += "Còn thiếu    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                    }

                    MessageBox.Show(s, LibMedi.AccessData.Msg);
                }
            }
        }

        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }		
        }

        private void cbLoaipttt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void ghichu_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaipttt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        public bool GoiPTTT
        {
            set
            {
                bGoiPTTT = value;
            }
        }
        public string Ma_PTTT
        {
            set
            {
                s_MaPTTT = value;
            }
        }

        public string Ma_Mau_PTTT
        {
            set
            {
                s_MaMauPTTT = value;
            }
        }
        public decimal IDXTutruc_Cu
        {
            set
            {
                d_idcu = value;
            }
        }
        class BietDuocSuDung
        {
            string mabd = "", ten = "", makho = "", manguon = "";
            int tutruc = -1;
            decimal soluong = 0;
            public string MaBD { set { mabd = value; } get { return mabd; } }
            public string TenBD { set { ten = value; } get { return ten; } }
            public string MaKho { set { makho = value; } get { return makho; } }
            public string MaNguon { set { manguon = value; } get { return manguon; } }
            public decimal SoLuong { set { soluong = value; } get { return soluong; } }
            public int TuTruc { set { tutruc = value; } get { return tutruc; } }
            public BietDuocSuDung(string maBd, string Tenbd, decimal sl, string makho, string manguon, int tuTruc)
            {
                this.mabd = maBd;
                this.ten = Tenbd;
                this.soluong = sl;
                this.makho = makho;
                this.manguon = manguon;
                this.tutruc = tuTruc;
            }
        }
	}
}
