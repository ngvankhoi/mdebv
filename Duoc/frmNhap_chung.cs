using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	public class frmNhap_chung : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan;// = new Language();
        Bogotiengviet tv;// = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label lbcmbSophieu;
		private System.Windows.Forms.Label lbngaysp;
		private System.Windows.Forms.Label lbsohd;
		private System.Windows.Forms.Label lbngayhd;
		private System.Windows.Forms.Label lbmadv;
		private System.Windows.Forms.Label lbbbkiem;
		private System.Windows.Forms.Label lbngaykiem;
		private System.Windows.Forms.Label lbnguoigiao;
		private System.Windows.Forms.Label lbmanguon;
		private System.Windows.Forms.Label lbmakho;
		private System.Windows.Forms.Label lbno;
		private System.Windows.Forms.Label lbco;
		private MaskedBox.MaskedBox ngaysp;
        private MaskedBox.MaskedBox ngayhd;
        public MaskedBox.MaskedBox ngaykiem;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox makho;
		private LibList.List listNX;
        private LibList.List listDMBD;
        public DataGrid dataGrid1;
        public Button butMoi;
        private System.Windows.Forms.Button butSua;
        public Button butLuu;
		private System.Windows.Forms.Button butThem;
        private System.Windows.Forms.Button butXoa;
        public Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox chuathue;
		private System.Windows.Forms.TextBox cothue;
		private System.Windows.Forms.ComboBox cmbSophieu;
        private string s_mmyy, s_ngay, sql, s_loai, s_vat = "", s_ngaysp = "", s_ngayhd = "", s_ngaykiem = "", s_makho = "", format_sotien, format_dongia, format_soluong, format_giaban, s_manhom = "", s_sophieu = "", stkgiamgia, s_title = "";
        public int i_nhom, i_userid, i_madv, i_mabd, i_vat, i_nhomcc, i_old, i_songay, manguon_old, makho_old, i_sole_giaban, i_sole_dongia, i_thanhtien_le, itable, i_khudt = 0, ichinhanh = 0;
        public string user, xxx;
        public int i_suasoluong = 0;
		public decimal l_id;
        private bool bVattuyte = false;
		private decimal d_soluongcu,d_soluong,d_dongia,d_sotien,d_sotienvat,d_chuathue,d_cothue,d_giaban,d_sl1,d_sl2,d_tyle,d_giaban2,d_tyle2,d_tyle_ggia,d_st_ggia,d_tongtien,d_soluongdahaohut,d_giadahaohut;
        private bool bKhoaso, bGiaban, bNew, bAdmin, bQuidoi, bGiaban_nguon, bNhom_nx, bKinhphi, bBienban, bNguoigiao, bDinhkhoan, bSophieu, bLockytu, bSophieu_kho, bSophieu_ngay, bChietkhau, bGiaban_noi_ngtru, bGiaban_danhmuc, bGiamgia, bDmtyleban;
        public bool bLuu = true, bSophieu_user = false, bChiAdminMoiDuocPhepHuyPhieuNhapKho_E9 = false;
		private AccessData d;
        private LibMedi.AccessData m;
		private Doisototext doiso;//=new Doisototext();
		private DataTable dtdmbd;//=new DataTable();
		private DataTable dtdmnx;//=new DataTable();
		private DataTable dtll;//=new DataTable();
		public DataTable dtct;//=new DataTable();
		private DataTable dtold;//=new DataTable();
		private DataTable dtnguon;//=new DataTable();
		private DataSet dsxoa;//=new DataSet();
        private DataTable dtnguonthuoc;
        private DataRow r;
		private MaskedTextBox.MaskedTextBox sophieu;
        private MaskedTextBox.MaskedTextBox sohd;
        public MaskedTextBox.MaskedTextBox bbkiem;
		private MaskedTextBox.MaskedTextBox nguoigiao;
        private MaskedTextBox.MaskedTextBox no;
        public MaskedTextBox.MaskedTextBox co;
		private System.Drawing.Printing.PrintDocument docToPrint;// = new System.Drawing.Printing.PrintDocument();
        private PrintDialog p;//=new PrintDialog();
        private DialogResult result;
        private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.ComboBox cmbTimkiem;
        private ComboBox chonin;
        private MaskedTextBox.MaskedTextBox chietkhau;
        private Label lbchietkhau;
        private Label label34;
        private ToolTip toolTip1;
        private Button butFind;
        private Label label1;
        private ComboBox cmbnguonthuoc;
        private Label label2;
        private MaskedBox.MaskedBox mkbngaysx;
        private Label label3;
        private Label label4;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton mnuTuyChon;
        private ToolStripMenuItem chkxml;
        private ToolStripMenuItem chkIn;
        private ToolStripMenuItem chkQuanLyNguonThuoc;
        private TextBox mkbhandung;
        private TextBox mkbTCChatLuong;
        private MaskedTextBox.MaskedTextBox tylehaohut;
        private Label label5;
        private MaskedTextBox.MaskedTextBox sotienvat;
        private MaskedTextBox.MaskedTextBox sotien;
        private MaskedTextBox.MaskedTextBox sotienhang;
        private Label label40;
        private MaskedTextBox.MaskedTextBox st_ggia;
        private Label label26;
        private MaskedTextBox.MaskedTextBox tyle_ggia;
        private Label label38;
        private Label label39;
        private Label label35;
        private MaskedBox.MaskedBox tenhang;
        private TextBox losx;
        private ComboBox madoituong;
        private Label lmadoituong;
        private MaskedTextBox.MaskedTextBox giabancu;
        private MaskedTextBox.MaskedTextBox giaban2;
        private MaskedTextBox.MaskedTextBox tyle2;
        private Label label36;
        private Label label37;
        private MaskedTextBox.MaskedTextBox giamuacu;
        private MaskedTextBox.MaskedTextBox dongia;
        private MaskedBox.MaskedBox tennuoc;
        private Label label32;
        private MaskedTextBox.MaskedTextBox giaban;
        private Label label31;
        private Label label30;
        private MaskedTextBox.MaskedTextBox tyle;
        private Label label29;
        private Label label28;
        private Label label27;
        private MaskedTextBox.MaskedTextBox sl2;
        private MaskedTextBox.MaskedTextBox sl1;
        private Label ltennuoc;
        private Label label23;
        private Label label25;
        private TextBox tenbd;
        private TextBox tenhc;
        private Label lTenhc;
        private MaskedBox.MaskedBox handung;
        private Label label24;
        private Label label15;
        private MaskedBox.MaskedBox dang;
        private Label label14;
        private MaskedTextBox.MaskedTextBox soluong;
        private MaskedTextBox.MaskedTextBox vat;
        private TextBox mabd;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label ldvt;
        private Label lTen;
        private Label label13;
        private Label lsokhoan;
        private TextBox stt;
        private ToolStripMenuItem ToolStripMnuQLThuocMuaThau;
        private Label label6;
        private ComboBox cmbThuocMuaThau;
        private Label label7;
        private TextBox txtSoDangKy;
        private IContainer components;
        //private string s_sophieudathang;
        #endregion

        public frmNhap_chung()
        {
            InitializeComponent();
        }
        //public frmNhap_chung(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool ban,bool admin,string _manhom, int _khudt)
        //{
        //    InitializeComponent();
        //    init();
            //d=acc;
            //i_nhom=nhom;s_manhom=_manhom;
            //s_makho=kho;i_userid=userid;
            //s_mmyy=mmyy;s_ngay=ngay;
            //s_loai=loai;bGiaban=ban;
            //bAdmin=admin;s_title=title;
            //i_khudt = _khudt;            
        //}
        ///Dong 13/07/2011
        //public frmNhap_chung(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool ban, bool admin, string _manhom, int _khudt,int _ichinhanh)
        //{
            //InitializeComponent();
            //init();
            //d = acc;
            //i_nhom = nhom; s_manhom = _manhom;
            //s_makho = kho; i_userid = userid;
            //s_mmyy = mmyy; s_ngay = ngay;
            //s_loai = loai; bGiaban = ban;
            //bAdmin = admin; this.Text = title;
            //i_khudt = _khudt;
            //ichinhanh = _ichinhanh;
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);
        //}
        /// End Dong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhap_chung));
            this.lbcmbSophieu = new System.Windows.Forms.Label();
            this.lbngaysp = new System.Windows.Forms.Label();
            this.lbsohd = new System.Windows.Forms.Label();
            this.lbngayhd = new System.Windows.Forms.Label();
            this.lbmadv = new System.Windows.Forms.Label();
            this.lbbbkiem = new System.Windows.Forms.Label();
            this.lbngaykiem = new System.Windows.Forms.Label();
            this.lbnguoigiao = new System.Windows.Forms.Label();
            this.lbmanguon = new System.Windows.Forms.Label();
            this.lbmakho = new System.Windows.Forms.Label();
            this.lbno = new System.Windows.Forms.Label();
            this.lbco = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.ngayhd = new MaskedBox.MaskedBox();
            this.ngaykiem = new MaskedBox.MaskedBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.tendv = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.listNX = new LibList.List();
            this.listDMBD = new LibList.List();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chuathue = new System.Windows.Forms.TextBox();
            this.cothue = new System.Windows.Forms.TextBox();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.sohd = new MaskedTextBox.MaskedTextBox();
            this.bbkiem = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new MaskedTextBox.MaskedTextBox();
            this.no = new MaskedTextBox.MaskedTextBox();
            this.co = new MaskedTextBox.MaskedTextBox();
            this.find = new System.Windows.Forms.TextBox();
            this.cmbTimkiem = new System.Windows.Forms.ComboBox();
            this.chonin = new System.Windows.Forms.ComboBox();
            this.chietkhau = new MaskedTextBox.MaskedTextBox();
            this.lbchietkhau = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbnguonthuoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mkbngaysx = new MaskedBox.MaskedBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuTuyChon = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkxml = new System.Windows.Forms.ToolStripMenuItem();
            this.chkIn = new System.Windows.Forms.ToolStripMenuItem();
            this.chkQuanLyNguonThuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMnuQLThuocMuaThau = new System.Windows.Forms.ToolStripMenuItem();
            this.mkbhandung = new System.Windows.Forms.TextBox();
            this.mkbTCChatLuong = new System.Windows.Forms.TextBox();
            this.tylehaohut = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sotienvat = new MaskedTextBox.MaskedTextBox();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.sotienhang = new MaskedTextBox.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.st_ggia = new MaskedTextBox.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tyle_ggia = new MaskedTextBox.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tenhang = new MaskedBox.MaskedBox();
            this.losx = new System.Windows.Forms.TextBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.lmadoituong = new System.Windows.Forms.Label();
            this.giabancu = new MaskedTextBox.MaskedTextBox();
            this.giaban2 = new MaskedTextBox.MaskedTextBox();
            this.tyle2 = new MaskedTextBox.MaskedTextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.giamuacu = new MaskedTextBox.MaskedTextBox();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.tennuoc = new MaskedBox.MaskedBox();
            this.label32 = new System.Windows.Forms.Label();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tyle = new MaskedTextBox.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.sl2 = new MaskedTextBox.MaskedTextBox();
            this.sl1 = new MaskedTextBox.MaskedTextBox();
            this.ltennuoc = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dang = new MaskedBox.MaskedBox();
            this.label14 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.vat = new MaskedTextBox.MaskedTextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.lsokhoan = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbThuocMuaThau = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoDangKy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbcmbSophieu
            // 
            this.lbcmbSophieu.Location = new System.Drawing.Point(6, 28);
            this.lbcmbSophieu.Name = "lbcmbSophieu";
            this.lbcmbSophieu.Size = new System.Drawing.Size(71, 23);
            this.lbcmbSophieu.TabIndex = 37;
            this.lbcmbSophieu.Text = "Số phiếu :";
            this.lbcmbSophieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbngaysp
            // 
            this.lbngaysp.Location = new System.Drawing.Point(140, 28);
            this.lbngaysp.Name = "lbngaysp";
            this.lbngaysp.Size = new System.Drawing.Size(48, 23);
            this.lbngaysp.TabIndex = 38;
            this.lbngaysp.Text = "Ngày :";
            this.lbngaysp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsohd
            // 
            this.lbsohd.Location = new System.Drawing.Point(244, 28);
            this.lbsohd.Name = "lbsohd";
            this.lbsohd.Size = new System.Drawing.Size(56, 23);
            this.lbsohd.TabIndex = 39;
            this.lbsohd.Text = "Hóa đơn :";
            this.lbsohd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbngayhd
            // 
            this.lbngayhd.Location = new System.Drawing.Point(462, 28);
            this.lbngayhd.Name = "lbngayhd";
            this.lbngayhd.Size = new System.Drawing.Size(48, 23);
            this.lbngayhd.TabIndex = 40;
            this.lbngayhd.Text = "Ngày :";
            this.lbngayhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbmadv
            // 
            this.lbmadv.Location = new System.Drawing.Point(-14, 50);
            this.lbmadv.Name = "lbmadv";
            this.lbmadv.Size = new System.Drawing.Size(91, 23);
            this.lbmadv.TabIndex = 43;
            this.lbmadv.Text = "Nhà cung cấp :";
            this.lbmadv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbbbkiem
            // 
            this.lbbbkiem.Location = new System.Drawing.Point(562, 28);
            this.lbbbkiem.Name = "lbbbkiem";
            this.lbbbkiem.Size = new System.Drawing.Size(72, 23);
            this.lbbbkiem.TabIndex = 41;
            this.lbbbkiem.Text = "BB kiểm số :";
            this.lbbbkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbngaykiem
            // 
            this.lbngaykiem.Location = new System.Drawing.Point(711, 28);
            this.lbngaykiem.Name = "lbngaykiem";
            this.lbngaykiem.Size = new System.Drawing.Size(48, 23);
            this.lbngaykiem.TabIndex = 42;
            this.lbngaykiem.Text = "Ngày :";
            this.lbngaykiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbnguoigiao
            // 
            this.lbnguoigiao.Location = new System.Drawing.Point(569, 50);
            this.lbnguoigiao.Name = "lbnguoigiao";
            this.lbnguoigiao.Size = new System.Drawing.Size(64, 23);
            this.lbnguoigiao.TabIndex = 44;
            this.lbnguoigiao.Text = "Người giao :";
            this.lbnguoigiao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbmanguon
            // 
            this.lbmanguon.Location = new System.Drawing.Point(29, 74);
            this.lbmanguon.Name = "lbmanguon";
            this.lbmanguon.Size = new System.Drawing.Size(48, 23);
            this.lbmanguon.TabIndex = 45;
            this.lbmanguon.Text = "Nguồn :";
            this.lbmanguon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbmakho
            // 
            this.lbmakho.Location = new System.Drawing.Point(152, 74);
            this.lbmakho.Name = "lbmakho";
            this.lbmakho.Size = new System.Drawing.Size(49, 23);
            this.lbmakho.TabIndex = 46;
            this.lbmakho.Text = "Kho :";
            this.lbmakho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbno
            // 
            this.lbno.Location = new System.Drawing.Point(320, 74);
            this.lbno.Name = "lbno";
            this.lbno.Size = new System.Drawing.Size(32, 23);
            this.lbno.TabIndex = 47;
            this.lbno.Text = "Nợ :";
            this.lbno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbco
            // 
            this.lbco.Location = new System.Drawing.Point(551, 74);
            this.lbco.Name = "lbco";
            this.lbco.Size = new System.Drawing.Size(32, 23);
            this.lbco.TabIndex = 48;
            this.lbco.Text = "Có :";
            this.lbco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(184, 28);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // ngayhd
            // 
            this.ngayhd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayhd.Enabled = false;
            this.ngayhd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayhd.Location = new System.Drawing.Point(506, 28);
            this.ngayhd.Mask = "##/##/####";
            this.ngayhd.MaxLength = 10;
            this.ngayhd.Name = "ngayhd";
            this.ngayhd.Size = new System.Drawing.Size(64, 21);
            this.ngayhd.TabIndex = 4;
            this.ngayhd.Text = "  /  /    ";
            this.ngayhd.Validated += new System.EventHandler(this.ngayhd_Validated);
            // 
            // ngaykiem
            // 
            this.ngaykiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaykiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykiem.Enabled = false;
            this.ngaykiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykiem.Location = new System.Drawing.Point(756, 28);
            this.ngaykiem.Mask = "##/##/####";
            this.ngaykiem.Name = "ngaykiem";
            this.ngaykiem.Size = new System.Drawing.Size(11, 21);
            this.ngaykiem.TabIndex = 6;
            this.ngaykiem.Text = "  /  /    ";
            this.ngaykiem.Validated += new System.EventHandler(this.ngaykiem_Validated);
            // 
            // madv
            // 
            this.madv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Enabled = false;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(72, 51);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(64, 21);
            this.madv.TabIndex = 7;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // tendv
            // 
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(138, 51);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(323, 21);
            this.tendv.TabIndex = 8;
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(72, 74);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(96, 21);
            this.manguon.TabIndex = 11;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(200, 74);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(128, 21);
            this.makho.TabIndex = 12;
            this.makho.SelectedIndexChanged += new System.EventHandler(this.makho_SelectedIndexChanged);
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(504, 568);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 25;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            this.listNX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listNX_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(61, 471);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 1663;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(5, 81);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(807, 241);
            this.dataGrid1.TabIndex = 100;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.Location = new System.Drawing.Point(363, 330);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 23);
            this.label21.TabIndex = 55;
            this.label21.Text = "Tổng cộng chưa thuế :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(558, 328);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 23);
            this.label22.TabIndex = 56;
            this.label22.Text = "Tổng cộng  :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chuathue
            // 
            this.chuathue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chuathue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chuathue.Enabled = false;
            this.chuathue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuathue.Location = new System.Drawing.Point(481, 330);
            this.chuathue.Name = "chuathue";
            this.chuathue.Size = new System.Drawing.Size(128, 21);
            this.chuathue.TabIndex = 57;
            this.chuathue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cothue
            // 
            this.cothue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cothue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cothue.Enabled = false;
            this.cothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cothue.Location = new System.Drawing.Point(677, 330);
            this.cothue.Name = "cothue";
            this.cothue.Size = new System.Drawing.Size(138, 21);
            this.cothue.TabIndex = 58;
            this.cothue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(72, 28);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(80, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(72, 28);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(80, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // sohd
            // 
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(295, 28);
            this.sohd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(166, 21);
            this.sohd.TabIndex = 3;
            this.sohd.TextChanged += new System.EventHandler(this.sohd_TextChanged);
            this.sohd.Validated += new System.EventHandler(this.sohd_Validated);
            // 
            // bbkiem
            // 
            this.bbkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bbkiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bbkiem.Enabled = false;
            this.bbkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbkiem.Location = new System.Drawing.Point(630, 28);
            this.bbkiem.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bbkiem.MaxLength = 15;
            this.bbkiem.Name = "bbkiem";
            this.bbkiem.Size = new System.Drawing.Size(86, 21);
            this.bbkiem.TabIndex = 5;
            // 
            // nguoigiao
            // 
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(629, 51);
            this.nguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(157, 21);
            this.nguoigiao.TabIndex = 10;
            this.nguoigiao.Validated += new System.EventHandler(this.nguoigiao_Validated);
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.SystemColors.HighlightText;
            this.no.Enabled = false;
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(352, 74);
            this.no.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(197, 21);
            this.no.TabIndex = 13;
            // 
            // co
            // 
            this.co.BackColor = System.Drawing.SystemColors.HighlightText;
            this.co.Enabled = false;
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(584, 74);
            this.co.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.co.MaxLength = 10;
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(58, 21);
            this.co.TabIndex = 14;
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(644, 74);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(88, 21);
            this.find.TabIndex = 104;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            this.find.Enter += new System.EventHandler(this.find_Enter);
            // 
            // cmbTimkiem
            // 
            this.cmbTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTimkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimkiem.Items.AddRange(new object[] {
            "Số phiếu",
            "Số hóa đơn",
            "Số phiếu/hoá đơn"});
            this.cmbTimkiem.Location = new System.Drawing.Point(735, 74);
            this.cmbTimkiem.Name = "cmbTimkiem";
            this.cmbTimkiem.Size = new System.Drawing.Size(83, 21);
            this.cmbTimkiem.TabIndex = 103;
            this.cmbTimkiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimkiem_SelectedIndexChanged);
            // 
            // chonin
            // 
            this.chonin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chonin.BackColor = System.Drawing.SystemColors.Info;
            this.chonin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chonin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonin.FormattingEnabled = true;
            this.chonin.Items.AddRange(new object[] {
            "Phiếu nhập",
            "Biên bản giao nhận",
            "Biên bản bàn giao",
            "Kiểm nhập",
            "Phiếu đề nghị thanh toán",
            "Phiếu nhập (Liên 1)",
            "Phiếu nhập (Liên 2)",
            "Phiếu nhập (theo giá trước VAT)",
            "In mã vạch"});
            this.chonin.Location = new System.Drawing.Point(500, 472);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(168, 24);
            this.chonin.TabIndex = 51;
            // 
            // chietkhau
            // 
            this.chietkhau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chietkhau.Enabled = false;
            this.chietkhau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chietkhau.Location = new System.Drawing.Point(532, 51);
            this.chietkhau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chietkhau.MaxLength = 3;
            this.chietkhau.Name = "chietkhau";
            this.chietkhau.Size = new System.Drawing.Size(26, 21);
            this.chietkhau.TabIndex = 9;
            this.chietkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbchietkhau
            // 
            this.lbchietkhau.Location = new System.Drawing.Point(469, 52);
            this.lbchietkhau.Name = "lbchietkhau";
            this.lbchietkhau.Size = new System.Drawing.Size(66, 19);
            this.lbchietkhau.TabIndex = 114;
            this.lbchietkhau.Text = "Chiết khấu :";
            this.lbchietkhau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(559, 51);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(8, 23);
            this.label34.TabIndex = 115;
            this.label34.Text = "%";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butFind
            // 
            this.butFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFind.Location = new System.Drawing.Point(787, 50);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(32, 23);
            this.butFind.TabIndex = 129;
            this.butFind.Text = "...";
            this.toolTip1.SetToolTip(this.butFind, "Tìm kiếm theo tên thuốc");
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(181, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "Nguồn thuốc :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // cmbnguonthuoc
            // 
            this.cmbnguonthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbnguonthuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnguonthuoc.Enabled = false;
            this.cmbnguonthuoc.FormattingEnabled = true;
            this.cmbnguonthuoc.Location = new System.Drawing.Point(260, 445);
            this.cmbnguonthuoc.Name = "cmbnguonthuoc";
            this.cmbnguonthuoc.Size = new System.Drawing.Size(107, 21);
            this.cmbnguonthuoc.TabIndex = 40;
            this.cmbnguonthuoc.Visible = false;
            this.cmbnguonthuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbnguonthuoc_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(374, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 134;
            this.label2.Text = "Ngày sản xuất :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // mkbngaysx
            // 
            this.mkbngaysx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mkbngaysx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mkbngaysx.Enabled = false;
            this.mkbngaysx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkbngaysx.Location = new System.Drawing.Point(455, 445);
            this.mkbngaysx.Mask = "##/##/####";
            this.mkbngaysx.MaxLength = 10;
            this.mkbngaysx.Name = "mkbngaysx";
            this.mkbngaysx.Size = new System.Drawing.Size(64, 21);
            this.mkbngaysx.TabIndex = 41;
            this.mkbngaysx.Text = "  /  /    ";
            this.mkbngaysx.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(523, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 136;
            this.label3.Text = "Hạn dùng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(687, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 137;
            this.label4.Text = "TC chất lượng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTuyChon});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 25);
            this.toolStrip1.TabIndex = 140;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuTuyChon
            // 
            this.mnuTuyChon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkxml,
            this.chkIn,
            this.chkQuanLyNguonThuoc,
            this.ToolStripMnuQLThuocMuaThau});
            this.mnuTuyChon.Image = ((System.Drawing.Image)(resources.GetObject("mnuTuyChon.Image")));
            this.mnuTuyChon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTuyChon.Name = "mnuTuyChon";
            this.mnuTuyChon.Size = new System.Drawing.Size(80, 22);
            this.mnuTuyChon.Text = "Tùy chọn";
            // 
            // chkxml
            // 
            this.chkxml.CheckOnClick = true;
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(225, 22);
            this.chkxml.Text = "Xml";
            // 
            // chkIn
            // 
            this.chkIn.CheckOnClick = true;
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(225, 22);
            this.chkIn.Text = "Xem trước khi in";
            // 
            // chkQuanLyNguonThuoc
            // 
            this.chkQuanLyNguonThuoc.CheckOnClick = true;
            this.chkQuanLyNguonThuoc.Name = "chkQuanLyNguonThuoc";
            this.chkQuanLyNguonThuoc.Size = new System.Drawing.Size(225, 22);
            this.chkQuanLyNguonThuoc.Text = "Quản lý nguồn thuốc";
            this.chkQuanLyNguonThuoc.Click += new System.EventHandler(this.chkQuanLyNguonThuoc_CheckedChanged);
            // 
            // ToolStripMnuQLThuocMuaThau
            // 
            this.ToolStripMnuQLThuocMuaThau.CheckOnClick = true;
            this.ToolStripMnuQLThuocMuaThau.Name = "ToolStripMnuQLThuocMuaThau";
            this.ToolStripMnuQLThuocMuaThau.Size = new System.Drawing.Size(225, 22);
            this.ToolStripMnuQLThuocMuaThau.Text = "Quản lí thuốc mua trúng thầu";
            this.ToolStripMnuQLThuocMuaThau.Click += new System.EventHandler(this.ToolStripMnuQLThuocMuaThau_Click);
            // 
            // mkbhandung
            // 
            this.mkbhandung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mkbhandung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mkbhandung.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mkbhandung.Enabled = false;
            this.mkbhandung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkbhandung.Location = new System.Drawing.Point(585, 445);
            this.mkbhandung.Name = "mkbhandung";
            this.mkbhandung.Size = new System.Drawing.Size(100, 21);
            this.mkbhandung.TabIndex = 42;
            this.mkbhandung.Visible = false;
            this.mkbhandung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mkbhandung_KeyDown);
            // 
            // mkbTCChatLuong
            // 
            this.mkbTCChatLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mkbTCChatLuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mkbTCChatLuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mkbTCChatLuong.Enabled = false;
            this.mkbTCChatLuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mkbTCChatLuong.Location = new System.Drawing.Point(771, 446);
            this.mkbTCChatLuong.Name = "mkbTCChatLuong";
            this.mkbTCChatLuong.Size = new System.Drawing.Size(45, 21);
            this.mkbTCChatLuong.TabIndex = 43;
            this.mkbTCChatLuong.Visible = false;
            this.mkbTCChatLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mkbTCChatLuong_KeyDown);
            // 
            // tylehaohut
            // 
            this.tylehaohut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tylehaohut.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tylehaohut.Enabled = false;
            this.tylehaohut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tylehaohut.Location = new System.Drawing.Point(789, 352);
            this.tylehaohut.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tylehaohut.MaxLength = 3;
            this.tylehaohut.Name = "tylehaohut";
            this.tylehaohut.Size = new System.Drawing.Size(27, 21);
            this.tylehaohut.TabIndex = 20;
            this.tylehaohut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(699, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 199;
            this.label5.Text = "Tỷ lệ hao hụt (%)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotienvat
            // 
            this.sotienvat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotienvat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienvat.Enabled = false;
            this.sotienvat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienvat.Location = new System.Drawing.Point(156, 398);
            this.sotienvat.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotienvat.Name = "sotienvat";
            this.sotienvat.Size = new System.Drawing.Size(85, 21);
            this.sotienvat.TabIndex = 30;
            this.sotienvat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(481, 376);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(100, 21);
            this.sotien.TabIndex = 26;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotien.Validated += new System.EventHandler(this.sotien_Validated);
            // 
            // sotienhang
            // 
            this.sotienhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotienhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienhang.Enabled = false;
            this.sotienhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienhang.Location = new System.Drawing.Point(299, 398);
            this.sotienhang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotienhang.Name = "sotienhang";
            this.sotienhang.Size = new System.Drawing.Size(139, 21);
            this.sotienhang.TabIndex = 31;
            this.sotienhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotienhang.Validated += new System.EventHandler(this.sotienhang_Validated);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.Location = new System.Drawing.Point(228, 397);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(73, 23);
            this.label40.TabIndex = 197;
            this.label40.Text = "Tổng tiền :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // st_ggia
            // 
            this.st_ggia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.st_ggia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st_ggia.Enabled = false;
            this.st_ggia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_ggia.Location = new System.Drawing.Point(714, 376);
            this.st_ggia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.st_ggia.Name = "st_ggia";
            this.st_ggia.Size = new System.Drawing.Size(102, 21);
            this.st_ggia.TabIndex = 28;
            this.st_ggia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(664, 374);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(8, 23);
            this.label26.TabIndex = 196;
            this.label26.Text = "%";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tyle_ggia
            // 
            this.tyle_ggia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle_ggia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle_ggia.Enabled = false;
            this.tyle_ggia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle_ggia.Location = new System.Drawing.Point(628, 375);
            this.tyle_ggia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle_ggia.Name = "tyle_ggia";
            this.tyle_ggia.Size = new System.Drawing.Size(35, 21);
            this.tyle_ggia.TabIndex = 27;
            this.tyle_ggia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label38.Location = new System.Drawing.Point(537, 374);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 23);
            this.label38.TabIndex = 195;
            this.label38.Text = "Giảm giá :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label39.Location = new System.Drawing.Point(661, 375);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 194;
            this.label39.Text = "Số tiền :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label35.Location = new System.Drawing.Point(109, 422);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(8, 23);
            this.label35.TabIndex = 192;
            this.label35.Text = "%";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(481, 421);
            this.tenhang.Mask = "";
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(173, 21);
            this.tenhang.TabIndex = 39;
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(359, 421);
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(79, 21);
            this.losx.TabIndex = 38;
            this.losx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.losx_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(714, 422);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(102, 21);
            this.madoituong.TabIndex = 39;
            this.madoituong.Visible = false;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // lmadoituong
            // 
            this.lmadoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lmadoituong.Location = new System.Drawing.Point(648, 420);
            this.lmadoituong.Name = "lmadoituong";
            this.lmadoituong.Size = new System.Drawing.Size(65, 23);
            this.lmadoituong.TabIndex = 193;
            this.lmadoituong.Text = "Đối tượng :";
            this.lmadoituong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lmadoituong.Visible = false;
            // 
            // giabancu
            // 
            this.giabancu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giabancu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giabancu.Enabled = false;
            this.giabancu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giabancu.Location = new System.Drawing.Point(714, 398);
            this.giabancu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giabancu.Name = "giabancu";
            this.giabancu.Size = new System.Drawing.Size(102, 21);
            this.giabancu.TabIndex = 34;
            this.giabancu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // giaban2
            // 
            this.giaban2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban2.Enabled = false;
            this.giaban2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban2.Location = new System.Drawing.Point(156, 421);
            this.giaban2.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.giaban2.Name = "giaban2";
            this.giaban2.Size = new System.Drawing.Size(85, 21);
            this.giaban2.TabIndex = 36;
            this.giaban2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban2.Validated += new System.EventHandler(this.giaban2_Validated);
            // 
            // tyle2
            // 
            this.tyle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle2.Enabled = false;
            this.tyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle2.Location = new System.Drawing.Point(68, 421);
            this.tyle2.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle2.Name = "tyle2";
            this.tyle2.Size = new System.Drawing.Size(40, 21);
            this.tyle2.TabIndex = 35;
            this.tyle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle2.Validated += new System.EventHandler(this.tyle2_Validated);
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.Location = new System.Drawing.Point(-11, 420);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 23);
            this.label36.TabIndex = 191;
            this.label36.Text = "Tỷ lệ ng trú :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label37.Location = new System.Drawing.Point(125, 420);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(31, 23);
            this.label37.TabIndex = 190;
            this.label37.Text = "Giá :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giamuacu
            // 
            this.giamuacu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giamuacu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giamuacu.Enabled = false;
            this.giamuacu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamuacu.Location = new System.Drawing.Point(359, 376);
            this.giamuacu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giamuacu.Name = "giamuacu";
            this.giamuacu.Size = new System.Drawing.Size(79, 21);
            this.giamuacu.TabIndex = 25;
            this.giamuacu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(260, 376);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(76, 21);
            this.dongia.TabIndex = 24;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(714, 422);
            this.tennuoc.Mask = "";
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(102, 21);
            this.tennuoc.TabIndex = 39;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label32.Location = new System.Drawing.Point(328, 375);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 23);
            this.label32.TabIndex = 189;
            this.label32.Text = "Cũ :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(581, 398);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(82, 21);
            this.giaban.TabIndex = 33;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban.Validated += new System.EventHandler(this.giaban_Validated);
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label31.Location = new System.Drawing.Point(684, 399);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 23);
            this.label31.TabIndex = 187;
            this.label31.Text = "Cũ :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.Location = new System.Drawing.Point(520, 399);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(8, 23);
            this.label30.TabIndex = 186;
            this.label30.Text = "%";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tyle
            // 
            this.tyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle.Enabled = false;
            this.tyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle.Location = new System.Drawing.Point(481, 398);
            this.tyle.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle.Name = "tyle";
            this.tyle.Size = new System.Drawing.Size(36, 21);
            this.tyle.TabIndex = 32;
            this.tyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle.Validated += new System.EventHandler(this.tyle_Validated);
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.Location = new System.Drawing.Point(443, 399);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 23);
            this.label29.TabIndex = 185;
            this.label29.Text = "Tỷ lệ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.Location = new System.Drawing.Point(147, 375);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(8, 23);
            this.label28.TabIndex = 184;
            this.label28.Text = "=";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.Location = new System.Drawing.Point(108, 375);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(8, 23);
            this.label27.TabIndex = 183;
            this.label27.Text = "x";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sl2
            // 
            this.sl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl2.Enabled = false;
            this.sl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl2.Location = new System.Drawing.Point(116, 376);
            this.sl2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sl2.Name = "sl2";
            this.sl2.Size = new System.Drawing.Size(29, 21);
            this.sl2.TabIndex = 22;
            this.sl2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl2.Validated += new System.EventHandler(this.sl2_Validated);
            // 
            // sl1
            // 
            this.sl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl1.Enabled = false;
            this.sl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl1.Location = new System.Drawing.Point(68, 376);
            this.sl1.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sl1.Name = "sl1";
            this.sl1.Size = new System.Drawing.Size(40, 21);
            this.sl1.TabIndex = 21;
            this.sl1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl1.Validated += new System.EventHandler(this.sl1_Validated);
            // 
            // ltennuoc
            // 
            this.ltennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ltennuoc.Location = new System.Drawing.Point(652, 422);
            this.ltennuoc.Name = "ltennuoc";
            this.ltennuoc.Size = new System.Drawing.Size(48, 23);
            this.ltennuoc.TabIndex = 182;
            this.ltennuoc.Text = "Nước :";
            this.ltennuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(441, 420);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 181;
            this.label23.Text = "Hãng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(525, 399);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 179;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(156, 353);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(211, 21);
            this.tenbd.TabIndex = 16;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(431, 353);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(69, 21);
            this.tenhc.TabIndex = 17;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(369, 352);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(63, 23);
            this.lTenhc.TabIndex = 178;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(299, 421);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 37;
            this.handung.Text = "    ";
            this.handung.Validated += new System.EventHandler(this.handung_Validated);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(299, 423);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 19);
            this.label24.TabIndex = 36;
            this.label24.Text = "Lô :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(241, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 175;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(540, 353);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(42, 21);
            this.dang.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(109, 398);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(8, 23);
            this.label14.TabIndex = 174;
            this.label14.Text = "%";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(156, 376);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(57, 21);
            this.soluong.TabIndex = 23;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // vat
            // 
            this.vat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vat.Enabled = false;
            this.vat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vat.Location = new System.Drawing.Point(68, 398);
            this.vat.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vat.MaxLength = 3;
            this.vat.Name = "vat";
            this.vat.Size = new System.Drawing.Size(40, 21);
            this.vat.TabIndex = 29;
            this.vat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vat.Validated += new System.EventHandler(this.vat_Validated);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(68, 353);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(59, 21);
            this.mabd.TabIndex = 15;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(103, 397);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 23);
            this.label20.TabIndex = 173;
            this.label20.Text = "Tiền :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.Location = new System.Drawing.Point(29, 397);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 23);
            this.label19.TabIndex = 171;
            this.label19.Text = "Thuế :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(426, 375);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 168;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(207, 375);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 166;
            this.label17.Text = "Giá gốc :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(13, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 165;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ldvt.Location = new System.Drawing.Point(502, 352);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(41, 23);
            this.ldvt.TabIndex = 162;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(103, 353);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(53, 23);
            this.lTen.TabIndex = 160;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(23, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 23);
            this.label13.TabIndex = 159;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(737, 471);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 53;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(668, 471);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 52;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(429, 471);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 50;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(360, 471);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 49;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(291, 471);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 48;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(222, 471);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 44;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(153, 471);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 45;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butSua.Enabled = false;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(84, 471);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 46;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(15, 471);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 47;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // lsokhoan
            // 
            this.lsokhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsokhoan.Location = new System.Drawing.Point(7, 326);
            this.lsokhoan.Name = "lsokhoan";
            this.lsokhoan.Size = new System.Drawing.Size(184, 24);
            this.lsokhoan.TabIndex = 201;
            this.lsokhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(150, 249);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 20);
            this.stt.TabIndex = 202;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(-2, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 203;
            this.label6.Text = "Thuốc mua :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Visible = false;
            // 
            // cmbThuocMuaThau
            // 
            this.cmbThuocMuaThau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbThuocMuaThau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThuocMuaThau.Enabled = false;
            this.cmbThuocMuaThau.FormattingEnabled = true;
            this.cmbThuocMuaThau.Items.AddRange(new object[] {
            "Trúng thầu",
            "Không trúng thầu"});
            this.cmbThuocMuaThau.Location = new System.Drawing.Point(68, 445);
            this.cmbThuocMuaThau.Name = "cmbThuocMuaThau";
            this.cmbThuocMuaThau.Size = new System.Drawing.Size(108, 21);
            this.cmbThuocMuaThau.TabIndex = 40;
            this.cmbThuocMuaThau.Visible = false;
            this.cmbThuocMuaThau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbThuocMuaThau_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(579, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 204;
            this.label7.Text = "Số đăng ký :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoDangKy
            // 
            this.txtSoDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoDangKy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSoDangKy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSoDangKy.Enabled = false;
            this.txtSoDangKy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDangKy.Location = new System.Drawing.Point(645, 353);
            this.txtSoDangKy.Name = "txtSoDangKy";
            this.txtSoDangKy.Size = new System.Drawing.Size(62, 21);
            this.txtSoDangKy.TabIndex = 19;
            this.txtSoDangKy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoDangKy_KeyDown);
            // 
            // frmNhap_chung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(823, 504);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.txtSoDangKy);
            this.Controls.Add(this.cmbThuocMuaThau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.cmbTimkiem);
            this.Controls.Add(this.ngaykiem);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.lsokhoan);
            this.Controls.Add(this.tylehaohut);
            this.Controls.Add(this.sotienvat);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.sotienhang);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.st_ggia);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tyle_ggia);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.lmadoituong);
            this.Controls.Add(this.giabancu);
            this.Controls.Add(this.giaban2);
            this.Controls.Add(this.tyle2);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.giamuacu);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tyle);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.sl2);
            this.Controls.Add(this.sl1);
            this.Controls.Add(this.ltennuoc);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.vat);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mkbTCChatLuong);
            this.Controls.Add(this.mkbhandung);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mkbngaysx);
            this.Controls.Add(this.cmbnguonthuoc);
            this.Controls.Add(this.chuathue);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.chietkhau);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.lbchietkhau);
            this.Controls.Add(this.chonin);
            this.Controls.Add(this.find);
            this.Controls.Add(this.co);
            this.Controls.Add(this.no);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.bbkiem);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.cothue);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.lbco);
            this.Controls.Add(this.lbno);
            this.Controls.Add(this.lbmakho);
            this.Controls.Add(this.lbmanguon);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.ngayhd);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.lbnguoigiao);
            this.Controls.Add(this.lbngaykiem);
            this.Controls.Add(this.lbbbkiem);
            this.Controls.Add(this.lbmadv);
            this.Controls.Add(this.lbngayhd);
            this.Controls.Add(this.lbsohd);
            this.Controls.Add(this.lbngaysp);
            this.Controls.Add(this.lbcmbSophieu);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label22);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNhap_chung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhap_chung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        //Tu:17/07/2011
        public void init()
        {

            d = new AccessData();
            m = new LibMedi.AccessData();
            lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            tv = new Bogotiengviet();
            doiso = new Doisototext();
            dtdmbd = new DataTable();
            dtdmnx = new DataTable();
            dtll = new DataTable();
            dtct = new DataTable();
            dtold = new DataTable();
            dtnguon = new DataTable();
            dsxoa = new DataSet();
            docToPrint = new System.Drawing.Printing.PrintDocument();
            p = new PrintDialog();
        }
        public LibDuoc.AccessData libDuoc
        {
            get { return d; }
            set { d = value; }
        }
        public LibMedi.AccessData libMedi
        {
            get { return m; }
            set { m = value; }
        }
        public string sLoai
        {
            get { return s_loai; }
            set { s_loai = value; }
        }
        public string sMmyy
        {
            get { return s_mmyy; }
            set { s_mmyy = value; }
        }
        public string sNgay
        {
            get { return s_ngay; }
            set { s_ngay = value; }
        }
        public int iNhom
        {
            get { return i_nhom; }
            set { i_nhom = value; }
        }
        public int iUserid
        {
            get { return i_userid; }
            set { i_userid = value; }
        }
        public string sKho
        {
            get { return s_makho; }
            set { s_makho = value; }
        }
        public string sTitle
        {
            get { return s_title; }
            set { s_title = value; }
        }
        public bool bBan
        {
            get { return bGiaban; }
            set { bGiaban = value; }
        }
        public bool b_Admin
        {
            get { return bAdmin; }
            set { bAdmin = value; }
        }
        public string sManhom
        {
            get { return s_manhom; }
            set { s_manhom = value; }
        }
        public int iKhudt
        {
            get { return i_khudt; }
            set { i_khudt = value; }
        }
        public int iChinhanh
        {
            get { return ichinhanh; }
            set { ichinhanh = value; }
        }
        public int iSuasoluong
        {
            get { return i_suasoluong; }
            set { i_suasoluong = value; }
        }
        //end Tu

        public void Load_form()
        {
            this.Text = s_title;
            this.WindowState = FormWindowState.Normal;
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
            //
            f_capnhat_db();
            //
            if (s_loai == "K")
            {
                lbmadv.Text = "Khoa :";
                lmadoituong.Visible = true;
                madoituong.Visible = true;
                ltennuoc.Visible = false;
                tennuoc.Visible = false;
            }
            bGiamgia = d.bGiamgia(i_nhom);
            bDmtyleban = d.bDmtyleban(i_nhom);
            stkgiamgia = d.Stkgiamgia(i_nhom);
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];

            bChiAdminMoiDuocPhepHuyPhieuNhapKho_E9 = d.bChiAdminMoiDuocPhepHuyPhieuNhapKho_E9(i_nhom);
            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            bGiaban_noi_ngtru = d.bGiaban_noi_ngtru(i_nhom);
            i_thanhtien_le = d.d_thanhtien_le(i_nhom);
            bLockytu = d.bLockytu_traiphai(i_nhom);
            cmbTimkiem.SelectedIndex = 0;
            bChietkhau = d.bChietkhau(i_nhom);
            chkIn.Checked = d.bPreview;
            bSophieu = d.bSophieunhap_tudong(i_nhom);
            bSophieu_kho = d.bSophieu_theokho(i_nhom);
            bSophieu_ngay = d.bPhieunhap_ngay(i_nhom);
            bSophieu_user = d.bPhieunhap_user(i_nhom);
            bKinhphi = d.bKinhphi(i_nhom);
            format_sotien = d.format_sotien(i_nhom);
            format_dongia = d.format_dongia(i_nhom);
            format_giaban = d.format_giaban(i_nhom);
            format_soluong = d.format_soluong(i_nhom);
            bGiaban_nguon = d.bGiaban_nguon(i_nhom);
            bNhom_nx = d.bNhom_nhapxuat(i_nhom);
            i_sole_giaban = d.d_giaban_le(i_nhom);
            i_sole_dongia = d.d_dongia_le(i_nhom);
            if (i_sole_dongia < 3) i_sole_dongia = 3;
            format_dongia = d.format_dongia_sole(i_sole_dongia);
            bBienban = d.bBbankiemso;
            bNguoigiao = d.bNguoigiao;
            bDinhkhoan = d.bDinhkhoan;
            bQuidoi = d.bQuidoi(i_nhom);
            bKhoaso = d.bKhoaso(i_nhom, s_mmyy);
            i_songay = d.Ngaylv_Ngayht;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            //if (d.bQuanlynguon(i_nhom))
            //    dtnguon = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
            //else
            //    dtnguon = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
            if (d.bQuanlynguon(i_nhom))
            {
                sql = "select * from " + user + ".d_dmnguon where nhom=" + i_nhom;
                if(s_loai == "M")
                    sql += " and nguon_tt=1";
                sql += " order by stt";
                dtnguon = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom;
                if(s_loai == "M")
                    sql += " and nguon_tt=1";
                sql += " order by stt";
                dtnguon = d.get_data(sql).Tables[0];
            }
            manguon.DataSource = dtnguon;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
            if (s_makho != "") 
                sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            if (i_khudt != 0) 
                sql += " and (khu=0 or khu=" + i_khudt + ")";
            if (s_loai == "M") 
                sql += " and khott=1";
            sql += " order by stt";
            makho.DataSource = d.get_data(sql).Tables[0];
            if (makho.Items.Count > 0) makho.SelectedIndex = 0;

            listDMBD.DisplayMember = "TEN";
            listDMBD.ValueMember = "MA";

            listNX.DisplayMember = "MA";
            listNX.ValueMember = "TEN";

            load_dm();

            sql = "select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,bbkiem,to_char(ngaykiem,'dd/mm/yyyy') as ngaykiem,nguoigiao,madv,makho,manguon,nhomcc,no,co,lydo,chietkhau,userid from " + xxx + ".d_nhapll ";
            sql += "where loai='" + s_loai + "'";
            if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
            //if (!bAdmin) sql += " and userid=" + i_userid;
            sql += " and nhom=" + i_nhom;
            if (bSophieu && bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
            if (s_makho.Trim().Trim(',') != "") sql += " and makho in(" + s_makho.Trim().Trim(',') + ")";
            if (d.bPhieunhap_sophieu(i_nhom)) sql += " order by sophieu";
            else sql += " order by manguon,id";
            dtll = d.get_data(sql).Tables[0];
            cmbSophieu.DataSource = dtll;
            cmbSophieu.DisplayMember = "SOPHIEU";
            cmbSophieu.ValueMember = "ID";
            
            if (dtll.Rows.Count > 0) l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
            else l_id = 0;
            load_head();
            AddGridTableStyle();
            dsxoa.ReadXml("..\\..\\..\\xml\\d_nhapct.xml");
            dsxoa.Tables[0].Columns.Add("haohut");
            dsxoa.Tables[0].Columns.Add("giahaohut");
            dsxoa.Tables[0].Columns.Add("sodangky");
            chonin.SelectedIndex = 0;
            chkQuanLyNguonThuoc.Checked = this.m.Thongso("quanlinguongocthuoc") == "1";
            chkQuanLyNguonThuoc_CheckedChanged(null, null);
            this.WindowState = FormWindowState.Maximized;
        }

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
            sql+="a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua,"+i_thanhtien_le+") as tongtien,";
            sql+="a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql+="a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
            sql+="a.st_ggia,case when a.vat=0 then 0 else round(a.sotien*a.vat/100,"+i_thanhtien_le+") end as sotienvat,a.tieuchuanchatluong,a.hansudung,a.haohut,a.giahaohut,a.muathau,b.sodk,a.sodangky " ;//Thuy 19.01.2013 thêm hao hụt
            sql+= " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowDelete = false;
            dv.AllowNew = false;
			tongcong();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
                DataRow r1 = d.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                if (r1 != null)
                {
                    mabd.Text = r1["ma"].ToString();
                    tenbd.Text = r1["ten"].ToString();
                    tenhc.Text = r1["tenhc"].ToString();
                    dang.Text = r1["dang"].ToString();
                    handung.Text = r1["handung"].ToString();
                    losx.Text = r1["losx"].ToString();
                    tenhang.Text = r1["tenhang"].ToString();
                    tennuoc.Text = r1["tennuoc"].ToString();
                    d_soluong = (r1["soluong"].ToString() != "") ? decimal.Parse(r1["soluong"].ToString()) : 0;
                    d_dongia = (r1["dongia"].ToString() != "") ? decimal.Parse(r1["dongia"].ToString()) : 0;
                    d_sotien = (r1["sotien"].ToString() != "") ? decimal.Parse(r1["sotien"].ToString()) : 0;
                    i_vat = (r1["vat"].ToString() != "") ?(int) decimal.Parse(r1["vat"].ToString()) : 0;
                    d_sotienvat = (r1["sotienvat"].ToString() != "") ? decimal.Parse(r1["sotienvat"].ToString()) : 0;
                    d_giaban = (r1["giaban"].ToString() != "") ? decimal.Parse(r1["giaban"].ToString()) : 0;
                    d_tongtien = (r1["tongtien"].ToString() != "") ? decimal.Parse(r1["tongtien"].ToString()) : 0;
                    d_sl1 = (r1["sl1"].ToString() != "") ? decimal.Parse(r1["sl1"].ToString()) : 0;
                    d_sl2 = (r1["sl2"].ToString() != "") ? decimal.Parse(r1["sl2"].ToString()) : 0;
                    d_tyle = (r1["tyle"].ToString() != "") ? decimal.Parse(r1["tyle"].ToString()) : 0;
                    tylehaohut.Text = r1["haohut"].ToString();//Thuy 19.01.2013
                    txtSoDangKy.Text = r1["sodangky"].ToString();
                    decimal _sotien = d_sotien + d_sotienvat;
                    try
                    {
                        if (d_giaban != 0) d_tyle = (d_giaban / Math.Round((_sotien / d_soluong)) - 1) * 100;
                    }
                    catch { d_tyle = 0; }
                    sl1.Text = d_sl1.ToString(format_soluong);
                    sl2.Text = d_sl2.ToString("###,###,##0");
                    tyle.Text = d_tyle.ToString("##0.00");
                    soluong.Text = d_soluong.ToString(format_soluong);
                    dongia.Text = d_dongia.ToString(format_dongia);
                    sotien.Text = d_sotien.ToString(format_sotien);
                    sotienhang.Text = d_tongtien.ToString(format_sotien);
                    vat.Text = i_vat.ToString("##0");
                    sotienvat.Text = d_sotienvat.ToString(format_sotien);
                    giaban.Text = d_giaban.ToString(format_giaban);
                    d_giaban = (r1["giabancu"].ToString() != "") ? decimal.Parse(r1["giabancu"].ToString()) : 0;
                    giabancu.Text = d_giaban.ToString(format_giaban);
                    d_giaban = (r1["giamuacu"].ToString() != "") ? decimal.Parse(r1["giamuacu"].ToString()) : 0;
                    giamuacu.Text = d_giaban.ToString(format_dongia);
                    d_giaban2 = (r1["giaban2"].ToString() != "") ? decimal.Parse(r1["giaban2"].ToString()) : 0;
                    d_tyle2 = (r1["tyle2"].ToString() != "") ? decimal.Parse(r1["tyle2"].ToString()) : 0;
                    if (d_giaban2 != 0) d_tyle2 = (d_giaban2 / Math.Round((_sotien / d_soluong)) - 1) * 100;
                    tyle2.Text = d_tyle2.ToString("##0.00");
                    giaban2.Text = d_giaban2.ToString(format_giaban);
                    d_tyle_ggia = (r1["tyle_ggia"].ToString() != "") ? decimal.Parse(r1["tyle_ggia"].ToString()) : 0;
                    d_st_ggia = (r1["st_ggia"].ToString() != "") ? decimal.Parse(r1["st_ggia"].ToString()) : 0;
                    tyle_ggia.Text = d_tyle_ggia.ToString("##0.00");
                    st_ggia.Text = d_st_ggia.ToString(format_sotien);
                    d_soluongcu = d_soluong;
                    if (r1["nguongoc"].ToString() == "0")
                    {
                        cmbnguonthuoc.SelectedIndex=-1;
                    }
                    else
                    {
                        cmbnguonthuoc.SelectedValue = int.Parse(r1["nguongoc"].ToString());
                    }
                    mkbngaysx.Text = r1["namsx"].ToString();
                    mkbTCChatLuong.Text = r1["tieuchuanchatluong"].ToString();
                    mkbhandung.Text = r1["hansudung"].ToString();
                    //Thuy 04.03.2013 
                    if (r1["muathau"].ToString() == "0")
                    {
                        cmbThuocMuaThau.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbThuocMuaThau.SelectedIndex = 1;
                    }
                    if (s_loai == "K") madoituong.SelectedValue = r1["tinhtrang"].ToString();
                    if (butLuu.Enabled)
                    {
                        r = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                        if (r != null)
                        {
                            i_mabd = int.Parse(r["id"].ToString());
                            tenbd.Enabled = d.get_iXuat(s_mmyy, int.Parse(makho.SelectedValue.ToString()), l_id, int.Parse(stt.Text)) == 0;
                            if (d.bNhapmaso) mabd.Enabled = tenbd.Enabled;
                            if (bQuidoi)
                            {
                                sl1.Enabled = tenbd.Enabled;
                                sl2.Enabled = tenbd.Enabled;
                            }
                            else soluong.Enabled = tenbd.Enabled;
                            if (d.bDongia(i_nhom)) dongia.Enabled = tenbd.Enabled;
                            else sotien.Enabled = sotienhang.Enabled=tenbd.Enabled;
                            if (s_loai != "K") vat.Enabled = tenbd.Enabled;
                        }
                    }
                }
			}
            catch { emp_detail(); }//
		}

		private void AddGridTableStyle()
		{
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
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bGiaban)?200:230;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
            TextCol.ReadOnly = true;
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
            TextCol.ReadOnly = false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
            TextCol.ReadOnly = false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 60;
			TextCol.Format=format_soluong;
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            //Tu thêm cột số lượng thực tế để sửa dành cho hepa
            if (i_suasoluong != 0)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "slthucte";
                TextCol.HeaderText = "SL thực tế";
                TextCol.Width = i_suasoluong;
                TextCol.Format = format_soluong;
                TextCol.ReadOnly = false;
                TextCol.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);
            }//end Tu

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 100;
			TextCol.Format=format_dongia;
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            if (bGiamgia)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "tyle_ggia";
                TextCol.HeaderText = "Giảm giá";
                TextCol.Width = 50;
                TextCol.Format = "##0.00";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "st_ggia";
                TextCol.HeaderText = "Tiền giảm";
                TextCol.Width = 100;
                TextCol.Format = format_sotien;
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);
            }

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vat";
			TextCol.HeaderText = "Thuế";
			TextCol.Width = 30;
			TextCol.Format="##0";
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotienvat";
			TextCol.HeaderText = "Tiền thuế";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongtien";
            TextCol.HeaderText = "Tổng tiền";
            TextCol.Width = 100;
            TextCol.Format = format_sotien;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru)?"Giá bán nội trú":(bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?100:0;
            TextCol.Format = format_giaban;
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giaban2";
            TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "Giá bán ngoại trú" : "";
            TextCol.Width = (bGiaban && bGiaban_noi_ngtru) ? 100 : 0;
            TextCol.Format = "###,###,###,##0";
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhang";
            TextCol.HeaderText = "Hãng";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennuoc";
            TextCol.HeaderText = "Nước";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sodk";
            TextCol.HeaderText = "Số ĐK/GPNK";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void load_dm()
		{
            sql = "select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,trim(a.dang)||'/'||trim(a.donvi) as dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,nullif(d.ma,' ') as sotk,a.sldonggoi,a.vtyt from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join " + user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom+" and a.hide=0";
            if (s_manhom != "")
                sql += " and a.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
			sql+=" order by a.ten";
			dtdmbd=d.get_data(sql).Tables[0];
			listDMBD.DataSource=dtdmbd;
            if (s_loai == "K")
            {
                sql = "select ma,ten,id,0 as nhomcc,' ' as diachi,' ' as masothue,' ' as daidien from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
                sql += " order by stt";
            }
            else
            {
                sql = "select ma,ten,id,nhomcc,diachi,masothue,daidien from " + user + ".d_dmnx where nhom=" + i_nhom + " and hide=0 order by stt";
            }
            dtdmnx = d.get_data(sql).Tables[0];
			listNX.DataSource=dtdmnx;
            sql = "select id,ten from " + user + ".d_dmnguongocthuoc";
            dtnguonthuoc = d.get_data(sql).Tables[0];
            cmbnguonthuoc.DisplayMember = "TEN";
            cmbnguonthuoc.ValueMember = "ID";
            cmbnguonthuoc.DataSource = dtnguonthuoc;
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
            //if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sophieu='"+sophieu.Text+"' and id<>"+l_id);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
            if (s_loai == "K") sohd.Text = sophieu.Text;
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu)
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
                load_head();
                ena_object(false);
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id='"+l_id+"'");
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngaysp"].ToString();
					sohd.Text=r["sohd"].ToString();
					ngayhd.Text=r["ngayhd"].ToString();
					bbkiem.Text=r["bbkiem"].ToString();
					ngaykiem.Text=r["ngaykiem"].ToString();
					nguoigiao.Text=r["nguoigiao"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
                    chietkhau.Text = r["chietkhau"].ToString();
					DataRow r1=d.getrowbyid(dtdmnx,"id="+int.Parse(r["madv"].ToString()));
					if (r1!=null)
					{
						madv.Text=r1["ma"].ToString();
						tendv.Text=r1["ten"].ToString();
					}
					no.Text=r["no"].ToString();
					co.Text=r["co"].ToString();
					s_ngaysp=ngaysp.Text;
					s_ngayhd=ngayhd.Text;
					s_ngaykiem=ngaykiem.Text;
				}
			}
			catch{}
			load_grid();
			ref_text();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%'";
				else sql="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmnx(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNX.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
                    sl2.Text = (r["sldonggoi"].ToString()=="0")?"":r["sldonggoi"].ToString();
                    d_giaban = decimal.Parse(r["dongia"].ToString());
                    giamuacu.Text = d_giaban.ToString(format_dongia);
					d_giaban=decimal.Parse(r["giaban"].ToString());
					giabancu.Text=d_giaban.ToString(format_giaban);
					if (bDinhkhoan)
					{
						string sotk=no.Text.Trim();
						if (sotk.IndexOf(r["sotk"].ToString())==-1)
						{
							sotk+=(sotk!="")?",":"";
							sotk+=r["sotk"].ToString().Trim();
							no.Text=sotk;
						}
					}
					if (s_loai=="T" || s_loai=="K")
					{
						d_dongia=decimal.Parse(r["dongia"].ToString());
						dongia.Text=d_dongia.ToString(format_dongia);
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString(format_giaban);
					}
                    else if (!bGiaban_danhmuc) giaban.Text = d_giaban.ToString(format_giaban);
                    bVattuyte = r["vtyt"].ToString() == "1";
				}
			}
		}

		private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNX.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNX.Visible)	listNX.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendv)
			{
				Filter_dmnx(tendv.Text);
                if (chietkhau.Enabled) listNX.BrowseToDmnx(tendv, madv, chietkhau);
				else listNX.BrowseToDmnx(tendv,madv,nguoigiao);
			}
		}

		private void tendv_Validated(object sender, System.EventArgs e)
		{
			if(!listNX.Focused) listNX.Hide();
			if (tendv.Text!="" && madv.Text=="")
			{
				r=d.getrowbyid(dtdmnx,"ten='"+tendv.Text+"'");
				if (r!=null) madv.Text=r["ma"].ToString();
			}
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			cmbTimkiem.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			if (!bSophieu) sophieu.Enabled=ena;
            if (bSophieu && bSophieu_ngay) ngaysp.Enabled = false;
            else ngaysp.Enabled = ena;
            if (bChietkhau && s_loai=="M") chietkhau.Enabled = ena;
            if (bGiamgia && s_loai == "M") tyle_ggia.Enabled = ena;
            st_ggia.Enabled = tyle_ggia.Enabled;
			sohd.Enabled=ena;
			ngayhd.Enabled=ena;
            if (s_loai != "K") sohd.Enabled = ena;
            if (s_loai != "K") ngayhd.Enabled = ena;
            if (bBienban && s_loai != "K") bbkiem.Enabled = ena;

			ngaykiem.Enabled=bbkiem.Enabled;
			madv.Enabled=ena;
			tendv.Enabled=ena;
            if (bNguoigiao && s_loai != "K") nguoigiao.Enabled = ena;
			if (d.bQuanlynguon(i_nhom)) manguon.Enabled=ena;
			else manguon.SelectedValue="0";
			makho.Enabled=ena;
            if (bDinhkhoan && s_loai != "K") no.Enabled = ena;
			co.Enabled=no.Enabled;
			if (d.bNhapmaso) mabd.Enabled=ena;
            tenbd.Enabled = ena;
            txtSoDangKy.Enabled = ena;
            if (s_loai == "K") madoituong.Enabled = ena;
			if (bQuidoi)
			{
				sl1.Enabled=ena;
				sl2.Enabled=ena;
			}
			else soluong.Enabled=ena;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=ena;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=ena;
			if (d.bDongia(i_nhom)) dongia.Enabled=ena;
			else sotien.Enabled=sotienhang.Enabled=ena;

            if (!bGiaban_danhmuc && !bDmtyleban)
            {
                if (bGiaban_nguon) giaban.Enabled = ena;
                else if (bGiaban) giaban.Enabled = ena;
                if (bGiaban_nguon && ena && manguon.SelectedIndex != -1)
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
            }
			tyle.Enabled=giaban.Enabled;
            if (giaban.Enabled && bGiaban_noi_ngtru) giaban2.Enabled = giaban.Enabled;
            tyle2.Enabled = giaban2.Enabled;
            if (s_loai != "K") vat.Enabled = ena;
            else
            {
                sl1.Enabled = sl2.Enabled = vat.Enabled = sotienvat.Enabled = sotienhang.Enabled = false;
                soluong.Enabled = true;
            }
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
            butFind.Enabled = !ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            chonin.Enabled = !ena;
			i_old=cmbSophieu.SelectedIndex;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
				load_dm();
            }
            cmbnguonthuoc.Enabled = !ena;
            cmbThuocMuaThau.Enabled = ena;
            mkbngaysx.Enabled = ena;
            mkbhandung.Enabled = ena;
            mkbTCChatLuong.Enabled = ena;
            find.Text = "";            
            makho_SelectedIndexChanged(null, null);
        }

		private void emp_head()
		{
			l_id=0;
            if (bSophieu)
            {
                sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                if (bSophieu_ngay)
                {
                    sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                }
                if (bSophieu_user)
                {
                    sql += " and userid='"+i_userid+"'";
                }
                if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
            }
            else sophieu.Text = "";
			ngaysp.Text=s_ngay;
            if (s_loai == "K") sohd.Text = sophieu.Text;
            else sohd.Text = "";
			ngayhd.Text=s_ngay;
			bbkiem.Text="";
			ngaykiem.Text="";
			madv.Text="";
			tendv.Text="";
			find.Text=nguoigiao.Text="";
            /*
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
             * */
			if (makho.Items.Count>0) makho.SelectedIndex=0;
			no.Text="";
			co.Text="";
            chietkhau.Text = "0";
			s_ngaysp=ngaysp.Text;
			s_ngayhd=ngayhd.Text;
			s_ngaykiem=ngaykiem.Text;
			dsxoa.Clear();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}
		
		private void emp_detail()
		{
            mabd.Text = ""; tenbd.Text = ""; tenhc.Text = ""; dang.Text = "";
            txtSoDangKy.Text = "";
			soluong.Text="";sl1.Text="";sl2.Text="";dongia.Text="";
			sotien.Text=sotienhang.Text="";vat.Text="";sotienvat.Text="";chuathue.Text="";
			cothue.Text="";handung.Text="";losx.Text="";
			giaban.Text="0";tyle.Text="";
            giaban2.Text = "0"; tyle2.Text = "0";
            tyle_ggia.Text = "0"; st_ggia.Text = "0";
			tenhang.Text="";tennuoc.Text="";d_soluongcu=0;
            tyle.Text = ""; tylehaohut.Text = "";
            cmbnguonthuoc.Text = ""; giamuacu.Text = "";
            mkbngaysx.Text = ""; mkbhandung.Text = ""; mkbTCChatLuong.Text = "";
			stt.Text=d.get_stt(dtct).ToString();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
            if (find.Text != "" && find.Text.ToLower() != "tìm kiếm")
            {
                find.Text = "";
                RefreshChildren("");
            }
			ena_object(true);
			emp_head();
			emp_detail();
            load_dm();
			dtct.Clear();
			dtold.Clear();
			if (sophieu.Text!="")
			{
				emp_head();
				emp_detail();
				dtct.Clear();
			}
			bNew=true;
			manguon_old=0;makho_old=0;
            if (sophieu.Enabled) sophieu.Focus();
            else if (ngaysp.Enabled) ngaysp.Focus();
            else sohd.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
            DataRow r = d.getrowbyid(dtll, "id='" + l_id + "'");
            if (r["userid"].ToString() != i_userid.ToString() && !bAdmin)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được phân quyền sửa phiếu này!"), d.Msg);
                return;
            }
			if (d.get_paid("d_nhapll",s_mmyy,l_id))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
				return;
			}
            makho_SelectedIndexChanged(null, null);//Thuy 19.01.2013
			ena_object(true);
			bNew=false;
			s_sophieu=sophieu.Text;
			manguon_old=int.Parse(manguon.SelectedValue.ToString());
			makho_old=int.Parse(makho.SelectedValue.ToString());

            foreach (DataRow r1 in dtct.Rows)
            {
                i_mabd = d.get_iXuat(s_mmyy, makho_old, l_id, int.Parse(r1["stt"].ToString()));
                if (i_mabd != 0)
                {
                    r = d.getrowbyid(dtdmbd, "id=" + i_mabd);
                    if (r != null)
                    {
                        makho.Enabled = false;
                        break;
                    }
                }
            }
			dtold=dtct.Copy();
			dsxoa.Clear();
            if (sophieu.Enabled) sophieu.Focus();
            else if (ngaysp.Enabled) ngaysp.Focus();
            else sohd.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (sohd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số hóa đơn !"),d.Msg);
				sohd.Focus();
				return false;
			}
			if (ngayhd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày hóa đơn !"),d.Msg);
				ngayhd.Focus();
				return false;
			}
			if (bBienban && s_loai!="K")
			{
				if ((bbkiem.Text=="" && ngaykiem.Text!="") || (bbkiem.Text!="" && ngaykiem.Text==""))
				{
					if (bbkiem.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập biên bản kiểm số !"),d.Msg);
						bbkiem.Focus();
						return false;
					}
					else if (ngaykiem.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập ngày biên bản kiểm !"),d.Msg);
						ngaykiem.Focus();
						return false;
					}
				}
			}
			if (d.bQuanlynguon(i_nhom))
			{
				if (manguon.SelectedIndex==-1 || manguon.SelectedValue.ToString()=="0")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nguồn không hợp lệ !"),d.Msg);
					manguon.Focus();
					return false;
				}
			}
			else manguon.SelectedValue="0";

			if (makho.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				makho.Focus();
				return false;
			}
			if (madv.Text=="" && tendv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
				madv.Focus();
				return false;
			}
			if ((madv.Text!="" && tendv.Text=="") || (madv.Text=="" && tendv.Text!=""))
			{
				if (madv.Text=="")
				{
					madv.Focus();
					return false;
				}
				else if (tendv.Text=="")
				{
					tendv.Focus();
					return false;
				}
			}
			i_madv=0;
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			if (r==null)
			{
                string s = (s_loai == "K") ? "Khoa " : "Nhà cung cấp";
                MessageBox.Show(s + " không hợp lệ !", d.Msg);
				madv.Focus();
				return false;
			}
			i_madv=int.Parse(r["id"].ToString());
            if (d.bQuanlynhomcc(i_nhom)) i_nhomcc = i_madv;//i_nhomcc=int.Parse(r["nhomcc"].ToString());
            else i_nhomcc=0;
            if (dtct.Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập chi tiết !"),d.Msg);
				butThem.Focus();
				return false;
			}
			if (bDinhkhoan && s_loai!="K")
			{
				if ((no.Text=="" && co.Text!="") || (no.Text!="" && co.Text==""))
				{
					if (no.Text=="")
					{
						no.Focus();
						return false;
					}
					else if (co.Text=="")
					{
						co.Focus();
						return false;
					}
				}
			}
			if (!bNew)
			{
				if (sophieu.Text!=s_sophieu)
				{
					sql="select sophieu from "+xxx+".d_nhapll where loai='"+s_loai+"' and sophieu='"+sophieu.Text+"' and id<>"+l_id;
                    if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
					if (d.get_data(sql).Tables[0].Rows.Count>0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Số phiếu")+" "+sophieu.Text+" "+lan.Change_language_MessageText("đã nhập !"),d.Msg);
						sophieu.Focus();
						return false;
					}
				}
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtct.Rows)
					{
						i_mabd=d.get_iXuat(s_mmyy,makho_old,l_id,int.Parse(r1["stt"].ToString()));
						if (i_mabd!=0)
						{
							r=d.getrowbyid(dtdmbd,"id="+i_mabd);
							if (r!=null)
							{
								MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép chỉnh sửa !",d.Msg);
								return false;
							}
						}
					}
                    if (bSophieu)
                    {
                        sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                        if (bSophieu_kho) sql += " and makho=" + int.Parse(makho.SelectedValue.ToString());
                        if (bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                        if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                        sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
                    }
				}
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
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
            if (d.bGiaban(i_nhom) && giaban.Enabled && !bGiaban_danhmuc)
            {
                try
                {
                    d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                    d_giaban = (giaban.Text != "") ? decimal.Parse(giaban.Text) : 0;
                    if (d_giaban < d_dongia)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"), d.Msg);
                        giaban.Focus();
                        return false;
                    }
                }
                catch { return false; }
            }
            if (ToolStripMnuQLThuocMuaThau.Checked && cmbThuocMuaThau.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn thuốc mua trúng thầu hay không!"), d.Msg);
                cmbThuocMuaThau.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            bLuu = true;
            //m = new LibMedi.AccessData();
			upd_table(dtct);
			dtct.AcceptChanges();
            if (!KiemtraHead()) { bLuu = false; return; }
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_nhap:l_id;
            itable = d.tableid(s_mmyy, "d_nhapll");
            Cursor = Cursors.WaitCursor;
            if (bNew)
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                if (bSophieu)
                {
                    sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                    if (bSophieu_kho) sql += " and makho=" + int.Parse(makho.SelectedValue.ToString());
                    if (bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                    if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                    sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
                }
            }
            else
            {
                string s = "";
                DataRow r2;
                foreach (DataRow r1 in dtold.Rows)
                {
                    r2 = d.getrowbyid(dtct, "stt=" + decimal.Parse(r1["stt"].ToString()));
                    if (r2 != null)
                    {
                        if (int.Parse(r1["mabd"].ToString()) != int.Parse(r2["mabd"].ToString()))
                        {
                            i_mabd = d.get_iXuat(s_mmyy, int.Parse(makho.SelectedValue.ToString()), l_id, int.Parse(r1["stt"].ToString()));
                            if (i_mabd != 0)
                            {
                                r = d.getrowbyid(dtdmbd, "id=" + i_mabd);
                                if (r != null)
                                    s += r["ten"].ToString().Trim() + " " + r["dang"].ToString().Trim() + "\n";
                            }
                        }
                    }
                }
                if (s != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau đã xuất không cho phép thay đổi")+" \n"+s, d.Msg);
                    bLuu = false;
                    Cursor = Cursors.Default;
                    return;
                }
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                //d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + sohd.Text + "^" + ngayhd.Text + "^" + bbkiem.Text + "^" + ngaykiem.Text + "^" + s_loai + "^" + nguoigiao.Text + "^" + i_madv.ToString() + "^" + makho.SelectedValue.ToString() + "^" + manguon.SelectedValue.ToString() + "^" + i_nhomcc.ToString() + "^" + no.Text + "^" + co.Text + "^" + i_userid.ToString() + "^" + "0^"+chietkhau.Text);
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", d.fields(xxx + ".d_nhapll", "id=" + l_id + ""));
            }
            ///Dong them ichinhanh ngay 13-07-2011
            if (m.bQuanly_Theo_Chinhanh)
            {
                if (!d.upd_nhapll(s_mmyy, l_id, i_nhom, sophieu.Text, ngaysp.Text, sohd.Text, ngayhd.Text, bbkiem.Text, ngaykiem.Text, s_loai, nguoigiao.Text, i_madv, int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, no.Text, co.Text, i_userid, 0, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, ichinhanh))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"), d.Msg);
                    bLuu = false;
                    Cursor = Cursors.Default;
                    return;
                }
            }
            ///End dong
            else
            {
                if (!d.upd_nhapll(s_mmyy, l_id, i_nhom, sophieu.Text, ngaysp.Text, sohd.Text, ngayhd.Text, bbkiem.Text, ngaykiem.Text, s_loai, nguoigiao.Text, i_madv, int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, no.Text, co.Text, i_userid, 0, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"), d.Msg);
                    bLuu = false;
                    Cursor = Cursors.Default;
                    return;
                }
            }
            itable = d.tableid(s_mmyy, "d_nhapct");
			if (!bNew)
			{
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtold.Rows)
					{
						d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                            if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
						}
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), makho_old, manguon_old, i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
					}
					dtold.Clear();
				}
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del",d.fields(xxx+".d_nhapct","id="+l_id+" and stt="+int.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
				}
				foreach(DataRow r1 in dtold.Rows)
				{
					if (s_loai=="M" && bKinhphi)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                        if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
					}
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
				}
			}
			foreach(DataRow r1 in dtct.Rows)
			{
                if (d.get_data("select * from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["handung"].ToString() + "^" + r1["losx"].ToString() + "^" + r1["vat"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["dongia"].ToString() + "^" + r1["sotien"].ToString() + "^" + r1["giaban"].ToString() + "^" + r1["giamua"].ToString() + "^" + r1["sl1"].ToString() + "^" + r1["sl2"].ToString() + "^" + r1["tyle"].ToString() + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + r1["giabancu"].ToString() + "^" + r1["giamuacu"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                if (chkQuanLyNguonThuoc.Checked)
                {
                    d.upd_nhapct_qlnguonthuoc(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), (int)decimal.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, r1["namsx"].ToString(), "", 0, int.Parse(r1["nguongoc"].ToString()), int.Parse(r1["tinhtrang"].ToString()), "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), r1["tc_chatluong"].ToString(), r1["hansudung"].ToString(),r1["sodangky"].ToString());
                }
                else if (ToolStripMnuQLThuocMuaThau.Checked)
                {
                    d.upd_nhapct_QLThuocMuaThau(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), (int)decimal.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, "", "", 0, 0, int.Parse(r1["tinhtrang"].ToString()), "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["muathau"].ToString()), r1["sodangky"].ToString());
                }
                else
                {
                    d.upd_nhapct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), (int)decimal.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, "", "", 0, 0, int.Parse(r1["tinhtrang"].ToString()), "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), r1["sodangky"].ToString());
                }
				if (s_loai=="M" && bKinhphi)
				{
					r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                    if (r != null) d.upd_kinhphi_sd(i_nhom, s_mmyy.Substring(2, 2), int.Parse(r["manhom"].ToString()), d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le));
				}
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), (int)decimal.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc, r1["sodangky"].ToString());
                //Update vat vào d_dmbd để làm báo cáo thuế giá trị gia tăng.
                d.execute_data("update "+user+".d_dmbd set vat="+r1["vat"].ToString()+" where id="+r1["mabd"].ToString());
                d.execute_data("update " + user + s_mmyy+".d_nhapct set haohut=" + r1["haohut"].ToString() + " where id="+l_id+" and stt="+ r1["stt"].ToString());
			}
            //
            Capnhat_Tracking_Nhapkho(s_mmyy, l_id);//binh 26032013
            //
			d.updrec_nhapll(dtll,l_id,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),no.Text,co.Text,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
                if (!bNew)
                {
                    cmbSophieu.SelectedValue = l_id.ToString();
                    load_head();
                }
			}
			catch{}
            Cursor = Cursors.Default;
			tongcong();
			ena_object(false);
            giaban2.Enabled = false;
            tyle2.Enabled = false;
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			cmbSophieu.SelectedIndex=i_old;
			try
			{
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_head();
            ena_object(false);
            makho_SelectedIndexChanged(null, null);
            giaban2.Enabled = false;
            tyle2.Enabled = false;
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
            ngaysp.Text=ngaysp.Text.Trim();
            if (ngaysp.Text.Length == 6) ngaysp.Text = ngaysp.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
		}

		private void ngayhd_Validated(object sender, System.EventArgs e)
		{
			if (ngayhd.Text=="") return;
            ngayhd.Text=ngayhd.Text.Trim();
            if (ngayhd.Text.Length == 6) ngayhd.Text = ngayhd.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngayhd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngayhd.Focus();
				return;
			}
			ngayhd.Text=d.Ktngaygio(ngayhd.Text,10);
			if (ngayhd.Text!=s_ngayhd)
			{
				if (!d.ngay(d.StringToDate(ngayhd.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngayhd.Focus();
					return;
				}
			}
		}

		private void ngaykiem_Validated(object sender, System.EventArgs e)
		{
			if (ngaykiem.Text=="") return;
			ngaykiem.Text=ngaykiem.Text.Trim();
            if (ngaykiem.Text.Length == 6) ngaykiem.Text = ngaykiem.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaykiem.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaykiem.Focus();
				return;
			}
			ngaykiem.Text=d.Ktngaygio(ngaykiem.Text,10);
			if (ngaykiem.Text!=s_ngaykiem)
			{
				if (!d.ngay(d.StringToDate(ngaykiem.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaykiem.Focus();
					return;
				}
			}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			tenbd.Enabled=true;
			if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
			if (bQuidoi)
			{
				sl1.Enabled=tenbd.Enabled;
				sl2.Enabled=tenbd.Enabled;
			}
			else soluong.Enabled=tenbd.Enabled;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=tenbd.Enabled;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=tenbd.Enabled;
			if (d.bDongia(i_nhom)) dongia.Enabled=tenbd.Enabled;
			else sotien.Enabled=sotienhang.Enabled=tenbd.Enabled;
            if (!bGiaban_danhmuc && !bDmtyleban)
            {
                if (bGiaban_nguon) giaban.Enabled = tenbd.Enabled;
                else if (bGiaban) giaban.Enabled = tenbd.Enabled;
                if (bGiaban_nguon && manguon.SelectedIndex != -1)
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
            }

            if (giaban.Enabled && bGiaban_noi_ngtru) giaban2.Enabled = giaban.Enabled;
            tyle2.Enabled = giaban2.Enabled;
			if (s_loai!="K") vat.Enabled=tenbd.Enabled;
			tyle.Enabled=giaban.Enabled;
			if (!upd_table(dtct)) return;
            string s_tyle = (tyle.Text == "") ? "0" : tyle.Text;
            s_vat = vat.Text; bVattuyte = false;
			emp_detail();
			vat.Text=s_vat;
            decimal d_tyleban = Math.Round ((decimal.Parse(s_tyle) / 5),0) * 5;
            tyle.Text = d_tyleban.ToString();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			i_mabd=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(stt.Text));
			if (i_mabd!=0)
			{
				r=d.getrowbyid(dtdmbd,"id="+i_mabd);
				if (r!=null)
				{
					MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép hủy !",d.Msg);
					return;
				}
			}
			if (!upd_table(dsxoa.Tables[0])) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
            if (bDinhkhoan && bGiamgia)
            {
                string sotk = no.Text.Trim();
                if (sotk.IndexOf(stkgiamgia.Trim()) == -1)
                {
                    sotk += (sotk != "") ? "," : "";
                    sotk += stkgiamgia.Trim();
                    no.Text = sotk;
                }
            }
			if (bQuidoi)
			{
				d_sl1=(sl1.Text!="")?decimal.Parse(sl1.Text):0;
				d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
                d_soluong = d_sl1 * d_sl2;
                try
                {
                    if (decimal.Parse(tylehaohut.Text) != 0)
                    {
                        d_soluongdahaohut = d_soluong - (d_soluong * decimal.Parse(tylehaohut.Text) / 100);//Thuy 21.01.2013
                    }
                }
                catch { }
			}
			else 
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				d_sl1=d_soluong;d_sl2=1;
			}
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_sotienvat=(sotienvat.Text!="")?decimal.Parse(sotienvat.Text):0;
            //d_tongtien=d_sotien+d_sotienvat;
            d_tongtien = (sotienhang.Text != "") ? decimal.Parse(sotienhang.Text) : 0;
			i_vat=(vat.Text!="")?int.Parse(vat.Text):0;
            if (bDmtyleban)
            {
                decimal tl = d.get_tyleban(d_tongtien / d_soluong,i_nhom,bVattuyte);
                tyle.Text = tyle2.Text = tl.ToString();
                try
                {
                    if (decimal.Parse(tylehaohut.Text) != 0)
                    {
                        d_giaban = d.Round(d_tongtien / d_soluongdahaohut + d_tongtien / d_soluongdahaohut * tl / 100, i_sole_giaban);
                    }
                    else
                    {
                        d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban);
                    }
                }
                catch { d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban); }
                giaban2.Text = giaban.Text = d_giaban.ToString(format_giaban);
            }
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
            d_giaban2 = (giaban2.Text != "") ? decimal.Parse(giaban2.Text) : 0;
            decimal d_giamuacu = (giamuacu.Text != "") ? decimal.Parse(giamuacu.Text) : 0;
			decimal d_giabancu=(giabancu.Text!="")?decimal.Parse(giabancu.Text):0;
			d_tyle=(tyle.Text=="")?0:decimal.Parse(tyle.Text);
            d_tyle_ggia = (tyle_ggia.Text == "") ? 0 : decimal.Parse(tyle_ggia.Text);
            d_st_ggia = (st_ggia.Text == "") ? 0 : decimal.Parse(st_ggia.Text);
            if (d_giaban == 0)
            {
                try
                {
                    if (decimal.Parse(tylehaohut.Text) != 0)
                    {
                        d_giaban = d.Round(d_tongtien / d_soluongdahaohut + d_tongtien / d_soluongdahaohut * d_tyle / 100, i_sole_giaban);
                    }
                    else
                    {
                        d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban);
                    }
                }
                catch { d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban); }
            }
            d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
            if (d_giaban2 == 0) d_giaban2 = d_giaban;
            d_tongtien -= d_st_ggia;
            decimal d_giamua;
            
            if (decimal.Parse(tylehaohut.Text)>0)
            {
                d_giamua = d.Round(d_tongtien / d_soluongdahaohut, 10);
            }
            else
            {
                d_giamua = d.Round(d_tongtien / d_soluong, 10);
            }
			handung.Text=handung.Text.Trim().PadRight(4,'0');
			handung.Refresh();
			losx.Refresh();
            if (chkQuanLyNguonThuoc.Checked)
            {
                try
                {
                    dt.Columns.Add("tc_chatluong");
                    dt.Columns.Add("hansudung");
                }
                catch { }
                d.updrec_nhapct_qlnguonthuoc(dt, int.Parse(stt.Text), i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, handung.Text, losx.Text,
                    (decimal.Parse(tylehaohut.Text) != 0 ? d_soluongdahaohut : d_soluong), d_dongia, d_sotien, i_vat, d_sotienvat, d_giaban, d_giamua, d_sl1, d_sl2, d_tyle, 0, 0, mkbngaysx.Text, "", 0, 
                    cmbnguonthuoc.Text == "" ? 0 : int.Parse(cmbnguonthuoc.SelectedValue.ToString()), 
                    (s_loai == "K" && madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0, "", d_giabancu, 
                    d_giamuacu, d_giaban2, d_tyle2, d_tyle_ggia, d_st_ggia, d_tongtien, mkbTCChatLuong.Text, mkbhandung.Text, 
                    decimal.Parse(tylehaohut.Text),d_giadahaohut,txtSoDangKy.Text);
            }
            else if (ToolStripMnuQLThuocMuaThau.Checked)
            {
                d.updrec_nhapct_QLThuocMuaThau(dt, int.Parse(stt.Text), i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, handung.Text, losx.Text, (decimal.Parse(tylehaohut.Text) != 0 ? d_soluongdahaohut : d_soluong),
                   d_dongia, d_sotien, i_vat, d_sotienvat, d_giaban, d_giamua, d_sl1, d_sl2, d_tyle, 0, 0, 0, "", 0, 0,
                   (s_loai == "K" && madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0, "", d_giabancu,
                   d_giamuacu, d_giaban2, d_tyle2, d_tyle_ggia, d_st_ggia, d_tongtien, decimal.Parse(tylehaohut.Text), d_giadahaohut,cmbThuocMuaThau.SelectedIndex,txtSoDangKy.Text);
            }
            else
            {
                d.updrec_nhapct(dt, int.Parse(stt.Text), i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, handung.Text, losx.Text, (decimal.Parse(tylehaohut.Text) != 0 ? d_soluongdahaohut : d_soluong),
                    d_dongia, d_sotien, i_vat, d_sotienvat, d_giaban, d_giamua, d_sl1, d_sl2, d_tyle, 0, 0, 0, "", 0, 0,
                    (s_loai == "K" && madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0, "", d_giabancu,
                    d_giamuacu, d_giaban2, d_tyle2, d_tyle_ggia, d_st_ggia, d_tongtien, decimal.Parse(tylehaohut.Text), d_giadahaohut,txtSoDangKy.Text);
            }
			dt.AcceptChanges();
			return true;
		}

		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (manguon.SelectedIndex==-1) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
			}
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
                    sl2.Text = (r["sldonggoi"].ToString() == "0") ? "" : r["sldonggoi"].ToString();
					d_giaban=decimal.Parse(r["giaban"].ToString());
					giabancu.Text=d_giaban.ToString(format_giaban);
                    d_giaban = decimal.Parse(r["dongia"].ToString());
                    giamuacu.Text = d_giaban.ToString(format_dongia);
					if (bDinhkhoan)
					{
						string sotk=no.Text.Trim();
						if (sotk.IndexOf(r["sotk"].ToString().Trim())==-1)
						{
							sotk+=(sotk!="")?",":"";
							sotk+=r["sotk"].ToString().Trim();
							no.Text=sotk;
						}
					}
					if (s_loai=="T" || s_loai=="K")
					{
						d_dongia=decimal.Parse(r["dongia"].ToString());
						dongia.Text=d_dongia.ToString(format_dongia);
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString(format_giaban);
					}
                    else if (giaban.Enabled || bGiaban_danhmuc)
                    {
                        d_giaban = decimal.Parse(r["giaban"].ToString());
                        giaban.Text = d_giaban.ToString(format_giaban);
                    }
                    bVattuyte = r["vtyt"].ToString() == "1";
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) mabd_Validated(null,null);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void tinh_giatri()
		{
			try
			{
                decimal d_vat = (vat.Text != "") ? decimal.Parse(vat.Text) : 0, d_giamua = 0;
                tylehaohut.Text = (tylehaohut.Text == "") ? "0" : tylehaohut.Text;//Thuy 21.01.2013
                if (bQuidoi && s_loai!="K")
				{
					d_sl1=(sl1.Text!="")?decimal.Parse(sl1.Text):0;
					d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
                    d_soluong = d_sl1 * d_sl2;
                    try
                    {
                        if (decimal.Parse(tylehaohut.Text) != 0)
                        {
                            d_soluongdahaohut = d_soluong - (d_soluong * decimal.Parse(tylehaohut.Text) / 100);//Thuy 21.01.2013
                        }
                    }
                    catch { }
                    soluong.Text=d_soluong.ToString(format_soluong);
				}
				else
				{
					d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
					sl1.Text=d_soluong.ToString(format_soluong);
					sl2.Text="1";
				}
				if (d.bDongia(i_nhom))
				{
					d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
					d_sotien=d.Round(d_soluong*d_dongia,i_thanhtien_le);
                    d_giadahaohut = d.Round(d_soluongdahaohut * d_dongia, i_thanhtien_le);
                    sotien.Text = (d_sotien > 0) ? d_sotien.ToString(format_sotien) : "";
				}
				else
				{	
                    //d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
                    //d_dongia=d.Round(d_sotien/d_soluong,3);
                    //dongia.Text=d_dongia.ToString(format_dongia);
                    d_sotienvat = (sotienhang.Text != "") ? decimal.Parse(sotienhang.Text) : 0;
                    d_sotien = d_sotienvat / (1 + d_vat / 100);
                    sotienhang.Text = d_sotienvat.ToString(format_sotien);
                    sotien.Text = (d_sotien > 0) ? d_sotien.ToString(format_dongia) : "";
                    //d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
                    d_dongia = d.Round(d_sotien / d_soluong, i_sole_dongia);
                    dongia.Text = (d_dongia > 0) ? d_dongia.ToString(format_dongia) : "";
                    try
                    {
                        if (decimal.Parse(tylehaohut.Text) != 0)
                        {
                            d_giamua = d.Round(d_sotienvat / d_soluongdahaohut, 10);
                        }
                        else
                        {
                            d_giamua = d.Round(d_sotienvat / d_soluong, 10);
                        }
                    }
                    catch { d_giamua = d.Round(d_sotienvat / d_soluong, 10); }
                    //giamua.Text = d_giamua.ToString(format_dongia);
                    d_sotienvat = d_sotien * d_vat / 100;
                    sotienvat.Text = d_sotienvat.ToString(format_sotien);
				}
				i_vat=(vat.Text!="")?int.Parse(vat.Text):0;
                d_tyle_ggia = (tyle_ggia.Text != "") ? decimal.Parse(tyle_ggia.Text) : 0;
                d_st_ggia = (st_ggia.Text != "") ? decimal.Parse(st_ggia.Text) : 0;
                if (!sotienhang.Enabled) //if (!sotienvat.Enabled)
                {
                    d_sotienvat = d.Round(d_sotien * i_vat / 100, i_thanhtien_le);
                    sotienvat.Text = d_sotienvat.ToString(format_sotien);
                    d_tongtien = d_sotien + d_sotienvat;
                    if (bDmtyleban)
                    {
                        decimal tl = d.get_tyleban(d_tongtien / d_soluong,i_nhom,bVattuyte);
                        tyle.Text = tyle2.Text = tl.ToString();
                        try
                        {
                            if (decimal.Parse(tylehaohut.Text) != 0)
                            {
                                d_giaban = d.Round(d_tongtien / d_soluongdahaohut + d_tongtien / d_soluongdahaohut * tl / 100, i_sole_giaban);
                            }
                            else
                            {
                                d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban);
                            }
                        }
                        catch { d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban); }
                        giaban2.Text = giaban.Text = (d_giaban > 0) ? d_giaban.ToString(format_giaban) : "";
                    }
                    if (!bGiaban_danhmuc && !bDmtyleban)
                    {
                        d_tyle = (tyle.Text == "") ? 0 : decimal.Parse(tyle.Text);
                        try
                        {
                            if (decimal.Parse(tylehaohut.Text) != 0)
                            {
                                d_giaban = d.Round(d_tongtien / d_soluongdahaohut + d_tongtien / d_soluongdahaohut * d_tyle / 100, i_sole_giaban);
                            }
                            else
                            {
                                d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban);
                            }
                        }
                        catch { d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban); }
                        giaban.Text = (d_giaban > 0) ? d_giaban.ToString(format_giaban) : "";// d_giaban.ToString(format_giaban);
                    }
                    d_tongtien -= d_st_ggia;
                    sotienhang.Text = d_tongtien.ToString(format_sotien);
                }
                else
                {
                    d_tyle = (tyle.Text == "") ? 0 : decimal.Parse(tyle.Text);
                    try
                    {
                        if (decimal.Parse(tylehaohut.Text) != 0)
                        {
                            d_giaban = d.Round(d_tongtien / d_soluongdahaohut + d_tongtien / d_soluongdahaohut * d_tyle / 100, i_sole_giaban);
                        }
                        else
                        {
                            d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban);
                        }
                    }
                    catch { d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban); }
                    giaban2.Text = giaban.Text = (d_giaban > 0) ? d_giaban.ToString(format_giaban) : "";// d_giaban.ToString(format_giaban);
                }
            }
			catch{}
		}

		private void vat_Validated(object sender, System.EventArgs e)
		{
			try
			{
                //if (vat.Text=="") vat.Text="0";
                //decimal _vat = decimal.Parse(vat.Text);
                //decimal _st = decimal.Parse(sotien.Text);
                ////sotienvat.Enabled = (_st == 0 && _vat > 0);
                ////sotienvat.Update();
                //if (!sotienhang.Enabled) tinh_giatri(); //if (!sotienvat.Enabled) tinh_giatri();
                //else
                //{
                //    r = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                //    if (r != null) giaban.Text = r["giaban"].ToString();
                //    decimal _giacu = decimal.Parse(giamuacu.Text);
                //    decimal _sl = decimal.Parse(soluong.Text);
                //    _st = _sl * _giacu;
                //    _st = _st * _vat / 100;
                //    sotienvat.Text = _st.ToString(format_sotien);
                //    sotienvat.Focus();
                //}
                if (vat.Text == "") vat.Text = "0";
                decimal _vat = decimal.Parse(vat.Text);
                decimal _st = decimal.Parse(sotien.Text);
                if (bDmtyleban)
                {
                    decimal tl = d.get_tyleban(d_dongia * (1 + _vat / 100), i_nhom, bVattuyte);
                    tyle.Text = tyle2.Text = tl.ToString();
                }
                //if (!sotienhang.Enabled) tinh_giatri();
                //else
                if(sotienhang.Enabled)
                {
                    d_tongtien = _st + _st * _vat / 100;
                    sotienhang.Text = d_tongtien.ToString(format_sotien);
                    _st = _st * _vat / 100;
                    sotienvat.Text = _st.ToString(format_sotien);
                    //sotienvat.Focus();
                }
                tinh_giatri();
			}
			catch{}			
		}

		private void dongia_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				dongia.Text=d_dongia.ToString(format_dongia);
			}
			catch{dongia.Text="0";}
            if (bDmtyleban)
            {
                decimal _vat = (vat.Text != "") ? 0 : decimal.Parse(vat.Text);
                decimal tl = d.get_tyleban(d_dongia * (1 + _vat / 100), i_nhom, bVattuyte);
                tyle.Text = tyle2.Text = tl.ToString();
            }
			tinh_giatri();
		}

		private void sotien_Validated(object sender, System.EventArgs e)
		{
            try
            {
                d_sotien = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                sotien.Text = d_sotien.ToString(format_sotien);
                decimal d_vat = (vat.Text != "") ? decimal.Parse(vat.Text) : 0;
                d_tongtien = d_sotien + d_sotien * d_vat / 100;
                sotienhang.Text = d_tongtien.ToString(format_sotien);
                if (bDmtyleban)
                {
                    decimal d_sl = (soluong.Text == "") ? 0 : decimal.Parse(soluong.Text);
                    if (d_sl > 0)
                    {
                        decimal tl = d.get_tyleban(d_tongtien / d_sl, i_nhom, bVattuyte);
                        tyle.Text = tyle2.Text = tl.ToString();
                    }
                }
            }
            catch { }
            tinh_giatri();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
                if (s_loai == "K" && sotienhang.Enabled)//sotien.Enabled
                {
                    decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                    decimal dgc = (giamuacu.Text != "") ? decimal.Parse(giamuacu.Text) : 0;
                    decimal dg = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                    if (dg == 0)
                    {
                        dg = dgc;
                        dongia.Text = dg.ToString(format_dongia);
                    }
                    if (st == 0 && dg != 0)
                    {
                        st = d_soluong * dg;
                        sotien.Text = st.ToString(format_sotien);
                    }
                }
			}
			catch{}            
			tinh_giatri();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                if (d.get_paid("d_nhapll", s_mmyy, l_id))
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
					return;
				}
				foreach(DataRow r1 in dtct.Rows)
				{
					i_mabd=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(r1["stt"].ToString()));
					if (i_mabd!=0)
					{
						r=d.getrowbyid(dtdmbd,"id="+i_mabd);
						if (r!=null)
						{
							MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép hủy !",d.Msg);
							return;
						}
					}
                }
                if (bChiAdminMoiDuocPhepHuyPhieuNhapKho_E9 && !bAdmin)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không được phép hủy! \n Vui lòng liên hệ với quản trị hệ thống!"), d.Msg);
                    return ;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "d_nhapct");
					foreach(DataRow r1 in dtct.Rows)
					{
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                            if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
						}
					}
                    itable = d.tableid(s_mmyy, "d_nhapll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapll", "id=" + l_id));
					d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id);
                    d.execute_data("delete from "+xxx+".d_thanhtoan where id=" + l_id);
					d.execute_data("delete from "+xxx+".d_nhapll where id="+l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void nguoigiao_Validated(object sender, System.EventArgs e)
		{
			SendKeys.Send("{F4}");
		}

		private void tongcong()
		{
			try
			{
				d_chuathue=0;
				d_cothue=0;
				foreach(DataRow r1 in dtct.Rows)
				{
					d_sotien=decimal.Parse(r1["sotien"].ToString());
					d_chuathue+=d_sotien;
					d_cothue+=d.Round(decimal.Parse(r1["tongtien"].ToString()),i_thanhtien_le);
				}
				chuathue.Text=d_chuathue.ToString(format_sotien);
                cothue.Text = d_cothue.ToString(format_sotien);
                
			}
			catch{}
		}

		private void sohd_Validated(object sender, System.EventArgs e)
		{
            //if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sohd='"+sohd.Text+"' and id<>"+l_id);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số hóa đơn đã nhập !"),d.Msg);
					sohd.Focus();
				}
			}
			catch{}		
		}

		private void giaban_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				giaban.Text=d_giaban.ToString(format_giaban);
				if (d.bGiaban(i_nhom))
				{
					if (d_giaban<d_dongia)
					{
						MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"),d.Msg);
						giaban.Focus();
						return;
					}
				}
				d_sotienvat=decimal.Parse(sotienvat.Text)+((sotien.Text!="")?decimal.Parse(sotien.Text):0);
				d_soluong=decimal.Parse(soluong.Text);
				d_tyle=(d_giaban/(d_sotienvat/d_soluong)-1)*100;
				tyle.Text=d_tyle.ToString("##0.00");
			}
			catch{giaban.Text="0";}
            if (giaban2.Text == "" || giaban2.Text == "0")
            {
                tyle2.Text = tyle.Text;
                giaban2.Text = giaban.Text;
            }
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            switch (chonin.SelectedIndex)
            {
                case 1: giaonhan(); break;
                case 2: bangiao(); break;
                case 3: kiemnhap(); break;
                case 4: indenghi(); break;
                case 7: phieunhap(true); break;
                case 8: inmavach(); break;
                default: phieunhap(false); break;
            }
        }

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
                listDMBD.BrowseToDmbd(tenbd, mabd, txtSoDangKy, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width + ldvt.Width + dang.Width - 30, mabd.Height + 5);
                //if (tylehaohut.Enabled)
                //{
                //    listDMBD.BrowseToDmbd(tenbd, mabd, tylehaohut, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width + ldvt.Width + dang.Width - 30, mabd.Height + 5);
                //}
                //else if (soluong.Enabled)
                //{
                //    listDMBD.BrowseToDmbd(tenbd, mabd, soluong, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width + ldvt.Width + dang.Width - 30, mabd.Height + 5);//Thuy 19.01.2013
                //}
                //else
                //{
                //    listDMBD.BrowseToDmbd(tenbd, mabd, sl1, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width + ldvt.Width + dang.Width - 30, mabd.Height + 5);//Thuy 19.01.2013
                //}
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				if (soluong.Enabled)
					listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
				else
					listDMBD.BrowseToDmbd(mabd,tenbd,sl1,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="ma like '"+ma.Trim()+"%'";
				else sql="ma like '%"+ma.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void sl1_Validated(object sender, System.EventArgs e)
		{
			try
			{
                d_sl1 = (sl1.Text != "") ? decimal.Parse(sl1.Text) : 0;
                //Thuy 19.01.2013
                try
                {
                    if (decimal.Parse(tylehaohut.Text) != 0)
                    {
                        d_soluongdahaohut = d_sl1 - (d_sl1 * decimal.Parse(tylehaohut.Text) / 100);
                    }
                }
                catch { }
                //end
				sl1.Text=d_sl1.ToString(format_soluong);
			}
			catch{}
			tinh_giatri();
		}

		private void sl2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
				sl2.Text=d_sl2.ToString("#,###,##0");
			}
			catch{}
			tinh_giatri();
		}

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == manguon && !bGiaban_danhmuc && !bDmtyleban)
                if (bGiaban_nguon && butLuu.Enabled && manguon.SelectedIndex != -1)
                {
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
                    tyle.Enabled = giaban.Enabled;
                }
		}

		private void tyle_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_tyle=(tyle.Text=="")?0:decimal.Parse(tyle.Text);
				tyle.Text=d_tyle.ToString("##0.00");
			}
			catch{tyle.Text="0";}
			tinh_giatri();
            if (tyle2.Text == "" || tyle2.Text == "0" || tyle2.Text == "0.00")
            {
                tyle2.Text = tyle.Text;
                giaban2.Text = giaban.Text;
            }
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;
                if (text.Trim() == "") sql = "";
                else
                {
                    if (cmbTimkiem.SelectedIndex == 0) sql = "sophieu like '%" + text.Trim() + "%'";
                    else if (cmbTimkiem.SelectedIndex == 1) sql = "sohd like '%" + text + "%'";
                    else sql = "sophieu like '%" + text.Trim() + "%' or sohd like '%" + text + "%'";
                }
				dv.RowFilter=sql;
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void cmbTimkiem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbTimkiem && find.Text!="") RefreshChildren(find.Text);
		}

        private void kiemnhap()
        {
            if (dtct.Rows.Count == 0) return;
            if (chkxml.Checked)
            {
                dtct.WriteXml("../../dataxml/d_Bbknhap_hd.xml", XmlWriteMode.WriteSchema);
            }
            rptBbknhap_hd f = new rptBbknhap_hd(d, i_nhom, s_makho, "d_Bbknhap_hd.rpt", madv.Text, tendv.Text, ngayhd.Text, ngaysp.Text, int.Parse(makho.SelectedValue.ToString()),i_userid);
            f.ShowDialog();
        }

        private void bangiao()
        {
            if (dtct.Rows.Count == 0) return;
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            frmBangiao f1 = new frmBangiao(r["daidien"].ToString());
            f1.ShowDialog(this);
            if (!f1.ok) return;
            DataSet dsxml = new DataSet();
            dsxml.ReadXml("..\\..\\..\\xml\\d_bangiao.xml");
            sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
            sql += "a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
            sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
            sql += "a.st_ggia,a.soluong*a.giamua as sotienvat ";
            sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem,b.sodk ";
            sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d ";
            sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
            DataTable dttmp = d.get_data(sql).Tables[0];
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid, "d_bangiao.rpt", dsxml.Tables[0].Rows[0]["NGAY"].ToString(), dsxml.Tables[0].Rows[0]["BENA"].ToString(), dsxml.Tables[0].Rows[0]["CVA"].ToString(), dsxml.Tables[0].Rows[0]["NGUOIGIAO"].ToString(), dsxml.Tables[0].Rows[0]["BENB"].ToString().Trim(), dsxml.Tables[0].Rows[0]["CVB"].ToString().Trim(), dsxml.Tables[0].Rows[0]["NGUOINHAN"].ToString().Trim(), dsxml.Tables[0].Rows[0]["BANGIAO"].ToString().Trim(), tendv.Text.ToString().Trim().ToUpper(), ngayhd.Text, _dc, _maso);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\d_bangiao.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAY"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + dsxml.Tables[0].Rows[0]["BENA"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + dsxml.Tables[0].Rows[0]["CVA"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + dsxml.Tables[0].Rows[0]["NGUOIGIAO"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + dsxml.Tables[0].Rows[0]["BENB"].ToString().Trim() + " " + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + dsxml.Tables[0].Rows[0]["CVB"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + dsxml.Tables[0].Rows[0]["NGUOINHAN"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + dsxml.Tables[0].Rows[0]["BANGIAO"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }

        private void giaonhan()
        {
            if (dtct.Rows.Count == 0) return;
            frmGiaonhan f1 = new frmGiaonhan(d);
            f1.ShowDialog(this);
            if (!f1.ok) return;
            sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,a.soluong*a.giamua as sotienvat,a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,b.congsuat,a.tyle_ggia,a.st_ggia,b.sodk ";
            sql += " from "+xxx+".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
            DataTable dttmp = d.get_data(sql).Tables[0];
            DataSet dsxml = new DataSet();
            dsxml.ReadXml("..\\..\\..\\xml\\d_giaonhan.xml");
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid , "d_giaonhan.rpt", dsxml.Tables[0].Rows[0]["NGAY"].ToString(), dsxml.Tables[0].Rows[0]["SOQD"].ToString(), dsxml.Tables[0].Rows[0]["NGAYQD"].ToString(), dsxml.Tables[0].Rows[0]["CUAQD"].ToString(), dsxml.Tables[0].Rows[0]["HT1"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV1"].ToString().Trim(), dsxml.Tables[0].Rows[0]["HT2"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV2"].ToString().Trim(), dsxml.Tables[0].Rows[0]["HT3"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV3"].ToString().Trim(), dsxml.Tables[0].Rows[0]["DD"].ToString().Trim(), ngayhd.Text, sophieu.Text, no.Text, co.Text);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\d_giaonhan.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAY"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + dsxml.Tables[0].Rows[0]["SOQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAYQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + dsxml.Tables[0].Rows[0]["CUAQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + dsxml.Tables[0].Rows[0]["HT1"].ToString().Trim() + " " + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + dsxml.Tables[0].Rows[0]["CV1"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + dsxml.Tables[0].Rows[0]["HT2"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + dsxml.Tables[0].Rows[0]["CV2"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + dsxml.Tables[0].Rows[0]["HT3"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + dsxml.Tables[0].Rows[0]["CV3"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + dsxml.Tables[0].Rows[0]["DD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }

        private void phieunhap(bool m_ingiatruocvat)
        {
            if (dtct.Rows.Count == 0) return;
            DataTable dttmp;
            if (bNhom_nx && d.Mabv_so != 701424)
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,";
                if (m_ingiatruocvat == false) sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ")+a.cuocvc+a.chaythu as sotienvat,";
                else sql += " a.sotien+a.cuocvc+a.chaythu as sotienvat,";
                sql += " a.giaban,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,b.manhom,e.ten as tennhom,f.ten as noingoai,f.stt as sttnn ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ",a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem,h.phieu as spdathang,a.hansudung,a.tieuchuanchatluong,a.namsx,a.nguongoc,a.sodangky ";// Hien:ket them table d_kehoachdathang de lay so phieu
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnhom e," + user + ".d_nhomhang f," + user + ".d_dmnx g,"+user+".d_kehoachdathang h ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and b.manhom=e.id and c.loai=f.id(+) and aa.madv=g.id and aa.id_kehoachdathang=h.id(+) and a.id=" + l_id;
                if (d.bInHangNuoc_Nhapxuat(i_nhom)) sql += " order by f.stt,e.stt,a.stt";
                else sql += " order by e.stt,a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,";
                if (m_ingiatruocvat == false) sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                else sql += " a.sotien as tongtien,";
                sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,a.hansudung,a.tieuchuanchatluong,";
                if (m_ingiatruocvat == false) sql +=" a.soluong*a.giamua as sotienvat ";
                else sql += " a.sotien as sotienvat ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ",a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem,h.phieu as spdathang,a.sodangky ";
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnx g,"+user+".d_kehoachdathang h ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and aa.madv=g.id and aa.id_kehoachdathang=h.id(+) and a.id=" + l_id + " order by a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            string c11 = no.Text, c12 = co.Text, _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string tenfile = (d.Mabv_so == 701424) ? "d_phieunhap.rpt" : (d.bInHangNuoc_Nhapxuat(i_nhom)) ? "d_phieunhap_ct_nhom.rpt" : (bNhom_nx) ? "d_phieunhap_nhom.rpt" : "d_phieunhap.rpt";
            decimal st = 0;
            if (tenfile == "d_phieunhap.rpt")
            {
                if (c11.IndexOf(",") == -1) c11 += ",";                
                string s12 = "NỢ :     ";
                sql = "select c.ma,";
                if (m_ingiatruocvat == false) sql += " sum(a.soluong*a.giamua) as sotienvat ";
                else sql += " sum(a.sotien) as sotienvat ";
                //
                sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id;
                if (bGiamgia) sql+=" and a.st_ggia=0 ";
                sql+=" group by c.ma";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    if (r1["sotienvat"].ToString() != "")
                    {
                        st = decimal.Parse(r1["sotienvat"].ToString());
                        s12 = s12 + r1["ma"].ToString().Trim() + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                    }
                }
                if (bGiamgia)
                {
                    if (m_ingiatruocvat == false)  sql = "select sum(a.soluong*a.giamua) as sotienvat ";
                    else sql = "select sum(a.sotien) as sotienvat ";
                    sql += " from " + xxx + ".d_nhapct a,";
                    sql += user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                    sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id + " and a.st_ggia<>0";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        if (r1["sotienvat"].ToString() != "")
                        {
                            st = decimal.Parse(r1["sotienvat"].ToString());
                            s12 = s12 + stkgiamgia + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                        }
                    }
                }
                c12 = c12 + "," + s12;
            }
            string _ngay = ngaysp.Text + ((chonin.SelectedIndex == 5) ? "1" : (chonin.SelectedIndex == 6) ? "2" : "");
            decimal d_tontien = (m_ingiatruocvat) ? decimal.Parse(chuathue.Text.Trim() == "" ? "0" : chuathue.Text.Trim()) : decimal.Parse(cothue.Text.Trim() == "" ? "0" : cothue.Text.Trim());
            if (chkxml.Checked)
            {
                dttmp.WriteXml("../../dataxml/"+tenfile.Replace(".rpt",".xml"), XmlWriteMode.WriteSchema);
            }
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp, i_userid, tenfile, cmbSophieu.Text, _ngay, c11, c12, nguoigiao.Text, sohd.Text, ngayhd.Text, tendv.Text, makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + ";", doiso.Doiso_Unicode(Convert.ToInt64(d_tontien).ToString()), _dc, _maso);                
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\" + tenfile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + cmbSophieu.Text + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + _ngay + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c11 + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c12 + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + nguoigiao.Text + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + sohd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + tendv.Text + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()) + "'";
                if (_dc != "") oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                if (_maso != "") oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }
        private void inmavach()
        {
            if (dtct.Rows.Count == 0) return;
            DataTable dttmp;
            if (bNhom_nx && d.Mabv_so != 701424)
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,";
                sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ")+a.cuocvc+a.chaythu as sotienvat,";
                sql += " a.giaban,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,b.manhom,e.ten as tennhom,f.ten as noingoai,f.stt as sttnn ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ", a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem, to_char(aa.id) as idnhap, to_char(i.stt) as sttt,b.sodk ";
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnhom e," + user + ".d_nhomhang f," + user + ".d_dmnx g ";
                sql += " ," + xxx + ".d_tonkhoct i, " + xxx + ".d_theodoi j ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and b.manhom=e.id and c.loai=f.id(+) and aa.madv=g.id";
                sql += " and a.id=i.idn and a.stt=i.sttn and i.stt=j.id ";
                sql += "  and a.id=" + l_id;
                if (d.bInHangNuoc_Nhapxuat(i_nhom)) sql += " order by f.stt,e.stt,a.stt";
                else sql += " order by e.stt,a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,";
                sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,";
                sql += " a.soluong*a.giamua as sotienvat ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ",a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem , to_char(aa.id) as idnhap, to_char(i.stt) as sttt,b.sodk ";
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnx g ";
                sql += " ," + xxx + ".d_tonkhoct i, " + xxx + ".d_theodoi j ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and aa.madv=g.id ";
                sql += " and a.id=i.idn and a.stt=i.sttn and i.stt=j.id ";
                sql += " and a.id=" + l_id + " order by a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            string c11 = no.Text, c12 = co.Text, _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string tenfile = "d_phieunhap_mavach.rpt";
            decimal st = 0;
            if (tenfile == "d_phieunhap.rpt")
            {
                if (c11.IndexOf(",") == -1) c11 += ",";
                string s12 = "NỢ :     ";
                sql = "select c.ma,";
                sql += " sum(a.soluong*a.giamua) as sotienvat,b.sodk ";                
                //
                sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id;
                if (bGiamgia) sql += " and a.st_ggia=0 ";
                sql += " group by c.ma";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    if (r1["sotienvat"].ToString() != "")
                    {
                        st = decimal.Parse(r1["sotienvat"].ToString());
                        s12 = s12 + r1["ma"].ToString().Trim() + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                    }
                }
                if (bGiamgia)
                {
                    sql = "select sum(a.soluong*a.giamua) as sotienvat,b.sodk ";
                    sql += " from " + xxx + ".d_nhapct a,";
                    sql += user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                    sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id + " and a.st_ggia<>0";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        if (r1["sotienvat"].ToString() != "")
                        {
                            st = decimal.Parse(r1["sotienvat"].ToString());
                            s12 = s12 + stkgiamgia + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                        }
                    }
                }
                c12 = c12 + "," + s12;
            }
            string _ngay = ngaysp.Text + ((chonin.SelectedIndex == 5) ? "1" : (chonin.SelectedIndex == 6) ? "2" : "");
            decimal d_tontien = decimal.Parse(cothue.Text);
            if (chkxml.Checked)
            {
                dttmp.WriteXml("../../dataxml/" + tenfile.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
            }
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp, i_userid, tenfile, cmbSophieu.Text, _ngay, c11, c12, nguoigiao.Text, sohd.Text, ngayhd.Text, tendv.Text, makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + ";", doiso.Doiso_Unicode(Convert.ToInt64(d_tontien).ToString()), _dc, _maso);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\" + tenfile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + cmbSophieu.Text + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + _ngay + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c11 + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c12 + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + nguoigiao.Text + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + sohd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + tendv.Text + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()) + "'";
                if (_dc != "") oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                if (_maso != "") oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }
        private void indenghi()
        {
            if (dtct.Rows.Count == 0) return;
            frmDenghict f1 = new frmDenghict(d, i_nhom, madv.Text.Trim(), tendv.Text.Trim(), ngayhd.Text, i_userid);
            f1.ShowDialog();
        }

        private void tyle2_Validated(object sender, EventArgs e)
        {
            try
            {
                d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
                tyle2.Text = d_tyle2.ToString("##0.00");
            }
            catch { tyle2.Text = "0"; }
            d_tongtien = ((sotien.Text != "") ? decimal.Parse(sotien.Text) : 0) + ((sotienvat.Text != "") ? decimal.Parse(sotienvat.Text) : 0);
            d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
            d_giaban2 = (d_soluong!=0)?d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle2 / 100, i_sole_giaban):0;
            giaban2.Text = d_giaban2.ToString(format_giaban);
        }

        private void giaban2_Validated(object sender, EventArgs e)
        {
            try
            {
                d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                d_giaban2 = (giaban2.Text != "") ? decimal.Parse(giaban2.Text) : 0;
                giaban2.Text = d_giaban2.ToString(format_giaban);
                if (d.bGiaban(i_nhom))
                {
                    if (d_giaban2 < d_dongia)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"), d.Msg);
                        giaban2.Focus();
                        return;
                    }
                }
                d_sotienvat = decimal.Parse(sotienvat.Text) + ((sotien.Text != "") ? decimal.Parse(sotien.Text) : 0);
                d_soluong = decimal.Parse(soluong.Text);
                d_tyle2 = (d_giaban2 / (d_sotienvat / d_soluong) - 1) * 100;
                tyle2.Text = d_tyle2.ToString("##0.00");
            }
            catch { giaban2.Text = "0"; }
        }

        private void madoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void losx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                if (s_loai == "K") SendKeys.Send("{F4}");
            }
        }

        private void tyle_ggia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal tyle = (tyle_ggia.Text != "") ? decimal.Parse(tyle_ggia.Text) : 0;
                decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                decimal stggia = (tyle != 0) ? st * tyle/100 : 0;
                st_ggia.Text = stggia.ToString(format_sotien);
                tinh_giatri();
            }
            catch { tyle_ggia.Text = "0"; }
        }

        private void st_ggia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                decimal stggia = (st_ggia.Text != "") ? decimal.Parse(st_ggia.Text) : 0;
                decimal tyle = (st != 0) ? stggia / st * 100 : 0;
                tyle_ggia.Text=tyle.ToString("##0.00");
                tinh_giatri();
            }
            catch { st_ggia.Text = "0"; }
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            frmTimthuoc f = new frmTimthuoc(d, s_mmyy, s_loai, i_nhom, i_userid, bAdmin);
            f.ShowDialog();
        }

        private void listNX_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void sotienhang_Validated(object sender, EventArgs e)
        {
            try
            {
                d_sotienvat = (sotienhang.Text != "") ? decimal.Parse(sotienhang.Text) : 0;
                decimal d_vat = (vat.Text != "") ? decimal.Parse(vat.Text) : 0;
                d_sotien = d_sotienvat / (1 + d_vat / 100);
                sotienhang.Text = d_sotienvat.ToString(format_sotien);
                sotien.Text = d_sotien.ToString(format_dongia);
                if (bDmtyleban)
                {
                    decimal d_sl = (soluong.Text == "") ? 0 : decimal.Parse(soluong.Text);
                    if (d_sl > 0)
                    {
                        decimal tl = d.get_tyleban(d_sotienvat / d_sl, i_nhom, bVattuyte);
                        tyle.Text = tyle2.Text = tl.ToString();
                    }
                }
            }
            catch { }
            tinh_giatri();
        }

        private void f_capnhat_db()
        {
            string asql = "";
            asql = "alter table " + user + s_mmyy + ".d_thanhtoan add sotiennovat numeric(18,4) default 0;";
            asql += "alter table " + user + s_mmyy + ".d_nhapll add id_kehoachdathang numeric(22);";
            d.execute_data(asql, false);
        }

        private void chkQuanLyNguonThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuanLyNguonThuoc.Checked && butMoi.Enabled==false)
            {
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                cmbnguonthuoc.Enabled = true;
                mkbngaysx.Enabled = true;
                mkbhandung.Enabled = true;
                mkbTCChatLuong.Enabled = true;
                cmbnguonthuoc.Visible = true;
                mkbngaysx.Visible = true;
                mkbhandung.Visible = true;
                mkbTCChatLuong.Visible = true;
                //ena_object(true);
            }
            if (chkQuanLyNguonThuoc.Checked && butMoi.Enabled == true)
            {
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                cmbnguonthuoc.Enabled = false;
                mkbngaysx.Enabled = false;
                mkbhandung.Enabled = false;
                mkbTCChatLuong.Enabled = false;
                cmbnguonthuoc.Visible = true;
                mkbngaysx.Visible = true;
                mkbhandung.Visible = true;
                mkbTCChatLuong.Visible = true;
            }
            else
            {
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                cmbnguonthuoc.Enabled = false;
                mkbngaysx.Enabled = false;
                mkbhandung.Enabled = false;
                mkbTCChatLuong.Enabled = false;
                cmbnguonthuoc.Visible = false;
                mkbngaysx.Visible = false;
                mkbhandung.Visible = false;
                mkbTCChatLuong.Visible = false;
                //ena_object(true);
            }
            this.m.writeXml("thongso", "quanlinguongocthuoc", this.chkQuanLyNguonThuoc.Checked ? "1" : "0");
        }

        private void cmbnguonthuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cmbnguonthuoc.SelectedIndex == -1) cmbnguonthuoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void mkbhandung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void mkbTCChatLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void frmNhap_chung_Load(object sender, EventArgs e)
        {
        }
        //Thuy 19.01.2013
        private void tylehaohut_Validated(object sender, EventArgs e)
        {
            if (tylehaohut.Text == "")
            {
                tylehaohut.Text = "0";
            }
        }

        private void makho_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt_kho = m.get_data("select id,haohut from " + user + ".d_dmkho where hide=0 and id=" + makho.SelectedValue).Tables[0];
            if (dt_kho.Rows[0]["haohut"].ToString() == "1" && !butSua.Enabled)
            {
                tylehaohut.Enabled = true;
            }
            else
            {
                tylehaohut.Enabled = false;
            }
        }

        private void sohd_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripMnuQLThuocMuaThau_Click(object sender, EventArgs e)
        {
            if (ToolStripMnuQLThuocMuaThau.Checked && butMoi.Enabled==false)
            {
                label6.Enabled = true;
                label6.Visible = true;
                cmbThuocMuaThau.Enabled = true;
                cmbThuocMuaThau.Visible = true;
                //ena_object(true);
            }
            else if(ToolStripMnuQLThuocMuaThau.Checked && butMoi.Enabled==true)
            {
                label6.Enabled = true;
                label6.Visible = true;
                cmbThuocMuaThau.Enabled = false;
                cmbThuocMuaThau.Visible = true;
            }
            else
            {
                label6.Enabled = false;
                label6.Visible = false;
                cmbThuocMuaThau.Enabled = false;
                cmbThuocMuaThau.Visible = false;
                //ena_object(true);
            }
        }

        private void cmbThuocMuaThau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cmbThuocMuaThau.SelectedIndex == -1) cmbThuocMuaThau.SelectedIndex = 0;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void Capnhat_Tracking_Nhapkho(string ammyy, decimal aid)
        {
            decimal d_idtracking = 0;
            xxx = d.user + ammyy;
            string asql = "select idtracking from " + xxx + ".d_nhapll_tracking where 1=2";
            DataSet lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "create table " + xxx + ".d_nhapll_tracking as select * from " + xxx + ".d_nhapll where 1=2";
                d.execute_data(asql);
                asql = "create table " + xxx + ".d_nhapct_tracking as select * from " + xxx + ".d_nhapct where 1=2";
                d.execute_data(asql);

                asql = " alter table " + xxx + ".d_nhapll_tracking add idtracking numeric ";
                d.execute_data(asql);
                asql = " alter table " + xxx + ".d_nhapct_tracking add idtracking numeric ";
                d.execute_data(asql);
            }
            d_idtracking = d.get_id_nhap;
            string aFieldName = d.f_get_field_name(ammyy, "d_nhapll_tracking", "");
            aFieldName = aFieldName.Replace("idtracking", d_idtracking + " as idtracking ");
            asql = " insert into " + xxx + ".d_nhapll_tracking  ";
            asql += " select " + aFieldName +" from " + xxx + ".d_nhapll where id=" + aid;
            d.execute_data(asql);

            aFieldName = d.f_get_field_name(ammyy, "d_nhapct_tracking", "");
            aFieldName = aFieldName.Replace("idtracking", d_idtracking + " as idtracking ");
            asql = " insert into " + xxx + ".d_nhapct_tracking  ";
            asql += " select " + aFieldName + " from " + xxx + ".d_nhapct where id=" + aid;
            d.execute_data(asql);
        }

        private void handung_Validated(object sender, EventArgs e)
        {
            string mmyyhienhanh = m.mmyy(m.Ngayhienhanh);
            if (handung.Text.Trim() != "")
            {
                if (int.Parse(handung.Text.PadLeft(4).ToString().Substring(2,2)) < int.Parse(mmyyhienhanh.Substring(2,2)))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Hạn dùng không hợp lệ,thời điểm hết hạn phải lớn hơn thời điểm hiện tại!"), d.Msg);
                    handung.Focus();
                }
                if (int.Parse(handung.Text.PadLeft(4).ToString().Substring(2, 2)) == int.Parse(mmyyhienhanh.Substring(2, 2)))
                {
                    if (int.Parse(handung.Text.PadLeft(4).ToString().Substring(0, 2)) == int.Parse(mmyyhienhanh.Substring(0, 2)))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Sắp hết hạn dùng!"), d.Msg);
                    }
                    if (int.Parse(handung.Text.PadLeft(4).ToString().Substring(0, 2)) < int.Parse(mmyyhienhanh.Substring(0, 2)))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Hạn dùng không hợp lệ,thời điểm hết hạn phải lớn hơn thời điểm hiện tại!"), d.Msg);
                        handung.Focus();
                    }
                }
            }
        }

        private void txtSoDangKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }
	}
}

