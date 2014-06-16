using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibVienphi;
using LibDuoc;
//using doiso;
using dichso;
using Medisoft_Image;
//using Medisoft.CyberRef;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmDkkb_chung : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan =null; Bogotiengviet tv = null; private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private frmGoibenh fgoi = null;
        private bool bDacocongkham = false;
        private bool bQuanLyChiNhanh = false,bBHYT_QRCode_Dangky = false;//B24
        private bool bKhongChoDKNeuChuaHetNgayCapThuocBHYT = false; private string s_QRcode_sothe = "", s_QRcode_Hoten = "", s_QRcode_ngaysinh = "", s_QRcode_gioitinh = "", s_QRcode_diachi = "", s_QRcode_mabv = "", s_QRcode_tungay = "", s_QRcode_denngay = "", s_QRcode_ngaycap = "", s_QRcode_MaQLBHXH = "", s_QRcode_KiemTraBHXH = "";
      //  Bogotiengviet tv = new Bogotiengviet();
     //   private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();		
        private LibMedi.AccessData m;
		private LibDuoc.AccessData d;
		private LibVienphi.AccessData v;
		//private Doisototext doiso;
        private int sizestt = 120, i_maxlength_mabn=8, i_maxlength_makp=2;
        private numbertotext doiso;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dslien=new DataSet();
		private DataSet dsdt=new DataSet();
		private DataSet dshn=new DataSet();
        public DataTable dtv = new DataTable();
        public DataTable dthinh = new DataTable();
		private DataTable dtnkp=new DataTable();
		private DataTable dttkham=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private DataSet dsbdien=new DataSet();
        private string user, nam = "", s_userid, s_makp, s_mabn, s_msg, s_ngayvv, sql, s_kyhieu, s_maqu, ma_vantay, s_madoituong, s_path, ngaysrv, pathImage, FileType,pathSave,file="",makp_kem_chidinh,thumuc="";
        public string s_mabn_moi = "", s_manvsale="", s_mavung="";
        public decimal l_maql_moi = 0,l_mavaovien_moi=0;
        private string s_matinh_bhyt = "", s_vitri_matinh_bhyt = "";
        private int i_userid, i_maba, iChidinh, hh1, hh2, hh3, mm1, mm2, mm3, i_madoituong_ng, imavp_the, i_useridvp, iCapso = 0;
        private decimal l_maql = 0, l_id = 0, mavp_kem_chidinh, l_matd = 0;
		private decimal d_dongia,d_mien,d_vattu;
        private bool bBNTrungcao_ghepthe = false, bChenhlech_laygiaphuthu = false, bDacohinh = false, bChupHinhBN=false;
        private DataSet dsthe = new DataSet();
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtgia=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtkh=new DataTable();
		private DataTable dtuser=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataTable dtsothe=new DataTable();
        private DataTable dtbs1 = new DataTable();
        private DataTable dtbv = new DataTable();
        private DataSet dsbarcode = new DataSet();
        private DataTable dtloaitg = new DataTable();
        DataTable dtngayle = new DataTable();
        DataTable dtngaynghi = new DataTable();
        private decimal v_tienkhambntra = 0;// gam 26072011
        private bool bKhacbv_traituyen_pk2 = false;
        private DataTable dtbsgioithieu = new DataTable();

        public ComboBox tenba;
        public Label label2;
        public Label label3;
        public Label label4;
        public Label label5;
        public MaskedTextBox.MaskedTextBox mabn1;
        public MaskedTextBox.MaskedTextBox mabn2;
        public MaskedTextBox.MaskedTextBox mabn3;
        public Label label6;
        public MaskedTextBox.MaskedTextBox namsinh;
        public Label label7;
        public ComboBox loaituoi;
        public TextBox maba;
        public TextBox tuoi;
        public TextBox hoten;
        public Label label52;
		private int songay=30,iTreem6,iTreem15,iKhamnhi,iLoai,i_loai,i_sohieu,i_sokham,iChuyendoituong1,iChuyenmavp,iChuyendoituong2;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bAdmin_hethong = false, bInkhambenh, bDanhsach, bSobienlai, bSuagiakham, bInphieudieutri, bKhamthai, bChuyenkhoasan, bHonnhan, bLydokham, bKhongintienkham, bLuachontienkham, bVantay, bVantay_batbuot, bVantay_dalan = false, bBacsy, bKyhieu_chung, bNew, b_trongngoai, bDenngay_sothe, bQuan01, bLoad_tiepdon, bTungay, bBangdien, bNoigioithieu, bVantay_mabntudong, bDssothe, bTudong = false, b701306, bDocmavach, bSothe_mabn, bMabn_tudong, bMabn_tudong_theomay=false , bHinh, bThuphi_kham, bGoi, bChonhinh, bThutien_the, bChuyendoituong, bKyhieu_may, bDangky_bsbv, bBienlai_mien, bIn1lan, bBhyt1kham, bSothe_dmbhyt, bSothe_ngay_huong, bSothe_dkkcb, bMien_congkham_cholam, bGrid = false, bTraituyen, bDadongtienkham = false,bChuphinhct=false;
        private bool bBH_chitra_1congkham = false, bChuyenkham_pkthu2_giataikham = false, bChuathanhtoan_khongcho_dangkykham = false, bLoadQuanhe_lantruoc = false, bChenhlechPK_chitinh_vaongaynghi = false, bXoaTrong_NoiDK_KCB_bandau = false, bBH_chitra_1congkham_conlaikhongtinh_G79_1 = false, bBH_chitra_1congkham_conlai_dttunguyen_G79_2 = false, bMabn_tudong_tu_ServerInterNet_D24 = false, bBHYT_Phanbiet_NVBenhvien = false, bBHYTNhapCMND = false, bThongtinNguoithan = false, bChuphinhtraituyen = false;
        public bool bNhapdaydu = true, bQuanlinvsale = false, bnKhamBHYTmotlantrongngay=false;
        private System.ComponentModel.IContainer components = null;
        public Panel phanhchinh;
        public ComboBox tennuoc;
        public ComboBox tendantoc;
        public ComboBox tentqx;
        public TextBox cholam;
        public TextBox thon;
        public TextBox mapxa2;
        public TextBox maqu2;
        public TextBox matt;
        public TextBox tqx;
        public TextBox manuoc;
        public TextBox madantoc;
        public TextBox mann;
        public ComboBox tennn;
        public ComboBox tenquan;
        public ComboBox tentinh;
        public ComboBox tenpxa;
        public MaskedTextBox.MaskedTextBox mapxa1;
        public MaskedTextBox.MaskedTextBox maqu1;
        public Label lcholam;
        public MaskedTextBox.MaskedTextBox sonha;
        public Label lphai;
        public Label lmann;
        public Label lsonha;
        public Label lmanuoc;
        public Label lmadantoc;
        public Label lthon;
        public Label lmatt;
        public Label ltqx;
        public Label lmaphuongxa;
        public Label lmaqu;
        public MaskedBox.MaskedBox ngaysinh;
        public TreeView treeView1;
        public Button butInbarcode;
        public PictureBox ptb;
        public Label label20;
        public TextBox dt_nha;
        public Panel pdienthoai;
        public Label label21;
        public TextBox dt_coquan;
        public TextBox dt_didong;
        public TextBox dt_email;
        public Label label22;
        public Label label31;
        private FingerApp.FrmNhanDang fnhandang;
        public ToolStrip toolStrip1;
        public ToolStripButton toolStripButton1;
        public ToolStripButton toolStripButton2;
        public ToolStripButton toolStripButton3;
        public ToolStripButton toolStripButton4;
        public ToolStripButton tbutvantay;
        public ToolStripLabel tlbl;
        private dllReportM.Print print;
        public ToolStripSeparator toolStripSeparator1;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripSeparator toolStripSeparator3;
        public ToolStripSeparator toolStripSeparator4;
        public Label label42;
        public Button button1;
        public PictureBox pic;
        public ComboBox phai;
        public Label label44;
        public Label label43;
        public PictureBox pictureBox2;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private System.Drawing.Bitmap map;
        public PictureBox pBarcode;
        public Panel pgoi;
        public Button butGoilai;
        public Button butGoi;
        public NumericUpDown sonhay;
        public NumericUpDown den;
        public NumericUpDown tu;
        public Label label50;
        public Label linthe;
        public Label lbienlaithe;
        public ToolTip toolTip1;
        private DataTable dtletet = new DataTable();
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bTiepdon_ngoaitru, bTiepdon_nkp_inchungchiphi;
        public ToolStripSeparator toolStripSeparator5;
        public ToolStripButton toolStripButton5;
        public ToolStripSeparator toolStripSeparator6;
        public ToolStripButton toolStripButton6;
        public ToolStripButton toolStripButton7;
        public ToolStripSeparator toolStripSeparator7;
        public CheckBox chkBhyt;
        public TextBox mathe;
        private int checkCol = 0,_dai=18,_vitri=14;
        private string _sothe = "08001";
        private string cl_cholam ="";
        private decimal cl_tyle = 0;
        private int cl_doituong = 3;
        private int i_khudt = 0;
        private int i_chinhanh = 0;
        private bool bTiepdon_n_makp_chung_chiphi, bBhyt_mien_trasau_ck_chidinh, bNgoaitru_k_khambenh;
        public LibList.List listBS;
        public LibList.List listSothe;
        public LibList.List listdstt;
        public Label label36;
        public Label l_bnmoi;
        public LibList.List list;
        public Label label1;
        public TextBox makp;
        public Label label19;
        public Label lbldoituong;
        public Label lblsothe;
        public Label lblden;
        public Panel pmien;
        public ComboBox duyet;
        public ComboBox lydomien;
        public Label label33;
        public Label label32;
        public Label lblnguoithan;
        public Label lblhoten;
        public Label lbldiachi;
        public Label lbldienthoai;
        public Label label30;
        public MaskedTextBox.MaskedTextBox sovaovien;
        public TextBox quanhe;
        public TextBox qh_diachi;
        public ComboBox tendoituong;
        public TextBox madoituong;
        public Label lbldkkcb;
        public ComboBox bnmoi;
        public Button butIn;
        public Label lbacsy;
        public TextBox tenbs;
        public Label label34;
        public Button butTiep;
        public ComboBox loai;
        public Button butLuu;
        public Button butBoqua;
        public TextBox tenbv;
        public Button butKetthuc;
        public Label lbltu;
        public MaskedBox.MaskedBox tungay;
        public TextBox sothe;
        public Label label37;
        public MaskedBox.MaskedBox giovv;
        public MaskedBox.MaskedBox ngayvv;
        public TextBox tendstt;
        public MaskedTextBox.MaskedTextBox madstt;
        public Label lhonnhan;
        public ComboBox honnhan;
        public Panel dausinhton;
        public MaskedTextBox.MaskedTextBox huyetap;
        public MaskedTextBox.MaskedTextBox mach;
        public MaskedBox.MaskedBox nhietdo;
        public MaskedTextBox.MaskedTextBox chieucao;
        public MaskedTextBox.MaskedTextBox bmi;
        public MaskedTextBox.MaskedTextBox cannang;
        public Label label45;
        public Label label40;
        public Label label39;
        public Label label14;
        public Label label13;
        public Label label16;
        public Label label18;
        public Label label53;
        public MaskedTextBox.MaskedTextBox mabv;
        public Label label38;
        public Label ltienkham;
        public Label lsobienlai;
        public ComboBox tienkham;
        public TextBox matienkham;
        public Button butKyhieu;
        public Label lkyhieu;
        public ComboBox kyhieu;
        public CheckBox checkBox1;
        public Label llydo;
        public MaskedTextBox.MaskedTextBox lydo;
        public MaskedTextBox.MaskedTextBox sobienlai;
        public DomainUpDown dongia;
        public CheckBox chkxml;
        public MaskedBox.MaskedBox denngay;
        public Label lbs;
        public TextBox qh_hoten;
        public MaskedTextBox.MaskedTextBox qh_dienthoai;
        public TextBox mabs;
        public Panel khamthai;
        public Label label10;
        public MaskedBox.MaskedBox ngaysanh;
        public MaskedBox.MaskedBox kinhcc;
        public TextBox dacdiem;
        public Label label12;
        public Label label11;
        public MaskedTextBox.MaskedTextBox para4;
        public MaskedTextBox.MaskedTextBox para3;
        public MaskedTextBox.MaskedTextBox para2;
        public MaskedTextBox.MaskedTextBox para1;
        public Label label9;
        public LibList.List listbs1;
        public LibList.List listbsgioithieu;
        public Label lbv;
        public TextBox bacsy;
        public LibList.List listbv;
        public TextBox benhvien;
        public CheckedListBox n_makp;
        public Panel pnmakp;
        public DataGrid dataGrid1;
        public CheckBox chkNgoaitru;
        public MaskedBox.MaskedBox ngay1;
        public MaskedBox.MaskedBox ngay2;
        public MaskedBox.MaskedBox ngay3;
        public DataGrid dataGrid2;
        public CheckBox chkView;
        public ComboBox traituyen;
        public TextBox tenkp;
        public LibList.List listKP;
        public CheckBox chkChenhlechcongkham;
        public ToolStripDropDownButton toolStripDropDownButton1;
        public ToolStripMenuItem chkLCD;
        public ToolStripMenuItem lblLCD;
        public ToolStripMenuItem chkDieutri;
        public ToolStripMenuItem chkXem;
        public ToolStripMenuItem tmn_bienlaikhongdong;
        public Button butget_msbn_from_internet;
        public CheckBox chkNhanvienbv;
        public Label label15;
        public TextBox txtMsThue;
        public TextBox txtCmnd;
        public Label label17;
        public Button button2;
        private ToolStripButton tbutYeucauhoadon;
        private ToolStripButton tbutChuphinh;
        public CheckBox chkTrungcao;
        public TextBox thetrungcao;
        public Panel pvaovien;
        public bool bKiemtra = true;
        public Label barcode;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ComboBox cmbLoaitg;
        public Label lblchieudaithe;//TU:17/06/2011
        private string s_soluutru = "";//Tu:28/06/2011
        private bool bCongthucchenhlech;
        private bool CongthucTraiTuyen160212 = false;
        private string MaDangKyKhamBenh = "", ViTriMaDangKyKhamBenh = "";
        #endregion
        public Label lbbsgioithieu;
        public TextBox txtMaBSGioiThieu;
        public TextBox txtTenBSGioiThieu;
        private ToolStripMenuItem chkBangDienGoiDocLapTheoTungQuay;
        private CheckedListBox chklistDTuutien;
        private Label lblDTUuTien;
        public Label label23;
        public Label label8;
        public Label label25;
        public Label label24;
        public MaskedTextBox.MaskedTextBox txtNhipTho;
        public Label label27;
        public Label label26;
        private ToolStripMenuItem mnuthongtinbodoi;
        private ToolStripButton toolStripButton8;
        private ToolStripMenuItem mnquanlihinhanhbn;
       
		public frmDkkb_chung()
		{
			//
			// Required for Windows Form Designer support
			//
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.Size = new System.Drawing.Size(1024, 768);
			InitializeComponent();
            
                                                 

            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        //khuong 19/05/2011 : tao ham init() public de ca form khac ke thua
        public void init()
        {
            print = new dllReportM.Print();
            d = new LibDuoc.AccessData();
            v = new LibVienphi.AccessData();
            lan = new Language();
            tv = new Bogotiengviet();

            if (m.bBogo) tv.GanBogo(this, textBox111);

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            //m = acc; s_makp = makp; s_madoituong = _madoituong;
            //s_userid = hoten; i_userid = userid; i_loai = loai;
            //i_sohieu = sohieu;
            //i_khudt = _khudieutri;

            m.writeXml("thongso", "khudt_hientai", i_khudt.ToString());
            //doiso=new Doisototext();
            doiso = new numbertotext();
            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        ///
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
                    if (disabledBackBrush != null)
                    {
                        disabledBackBrush.Dispose();
                        disabledTextBrush.Dispose();
                        alertBackBrush.Dispose();
                        alertFont.Dispose();
                        alertTextBrush.Dispose();
                        currentRowFont.Dispose();
                        currentRowBackBrush.Dispose();
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDkkb_chung));
            this.tenba = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn1 = new MaskedTextBox.MaskedTextBox();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loaituoi = new System.Windows.Forms.ComboBox();
            this.maba = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.phanhchinh = new System.Windows.Forms.Panel();
            this.thetrungcao = new System.Windows.Forms.TextBox();
            this.chkTrungcao = new System.Windows.Forms.CheckBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.tqx = new System.Windows.Forms.TextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.lmaqu = new System.Windows.Forms.Label();
            this.lmatt = new System.Windows.Forms.Label();
            this.ltqx = new System.Windows.Forms.Label();
            this.lcholam = new System.Windows.Forms.Label();
            this.lthon = new System.Windows.Forms.Label();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.pnmakp = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.butInbarcode = new System.Windows.Forms.Button();
            this.pdienthoai = new System.Windows.Forms.Panel();
            this.txtMsThue = new System.Windows.Forms.TextBox();
            this.txtCmnd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dt_email = new System.Windows.Forms.TextBox();
            this.dt_didong = new System.Windows.Forms.TextBox();
            this.dt_coquan = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dt_nha = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutvantay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutYeucauhoadon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutChuphinh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDieutri = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_bienlaikhongdong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnquanlihinhanhbn = new System.Windows.Forms.ToolStripMenuItem();
            this.chkBangDienGoiDocLapTheoTungQuay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuthongtinbodoi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.label42 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.phai = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pBarcode = new System.Windows.Forms.PictureBox();
            this.pgoi = new System.Windows.Forms.Panel();
            this.butGoilai = new System.Windows.Forms.Button();
            this.butGoi = new System.Windows.Forms.Button();
            this.sonhay = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.linthe = new System.Windows.Forms.Label();
            this.lbienlaithe = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ngay1 = new MaskedBox.MaskedBox();
            this.ngay2 = new MaskedBox.MaskedBox();
            this.ngay3 = new MaskedBox.MaskedBox();
            this.chkChenhlechcongkham = new System.Windows.Forms.CheckBox();
            this.chkNhanvienbv = new System.Windows.Forms.CheckBox();
            this.lblDTUuTien = new System.Windows.Forms.Label();
            this.chkBhyt = new System.Windows.Forms.CheckBox();
            this.mathe = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.listSothe = new LibList.List();
            this.listdstt = new LibList.List();
            this.label36 = new System.Windows.Forms.Label();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.list = new LibList.List();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbldoituong = new System.Windows.Forms.Label();
            this.lblsothe = new System.Windows.Forms.Label();
            this.lblden = new System.Windows.Forms.Label();
            this.pmien = new System.Windows.Forms.Panel();
            this.duyet = new System.Windows.Forms.ComboBox();
            this.lydomien = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblnguoithan = new System.Windows.Forms.Label();
            this.lblhoten = new System.Windows.Forms.Label();
            this.lbldiachi = new System.Windows.Forms.Label();
            this.lbldienthoai = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.quanhe = new System.Windows.Forms.TextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.lbldkkcb = new System.Windows.Forms.Label();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.lbacsy = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.butTiep = new System.Windows.Forms.Button();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbltu = new System.Windows.Forms.Label();
            this.tungay = new MaskedBox.MaskedBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.lhonnhan = new System.Windows.Forms.Label();
            this.honnhan = new System.Windows.Forms.ComboBox();
            this.dausinhton = new System.Windows.Forms.Panel();
            this.txtNhipTho = new MaskedTextBox.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.bmi = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ltienkham = new System.Windows.Forms.Label();
            this.lsobienlai = new System.Windows.Forms.Label();
            this.tienkham = new System.Windows.Forms.ComboBox();
            this.matienkham = new System.Windows.Forms.TextBox();
            this.butKyhieu = new System.Windows.Forms.Button();
            this.lkyhieu = new System.Windows.Forms.Label();
            this.kyhieu = new System.Windows.Forms.ComboBox();
            this.llydo = new System.Windows.Forms.Label();
            this.lydo = new MaskedTextBox.MaskedTextBox();
            this.sobienlai = new MaskedTextBox.MaskedTextBox();
            this.dongia = new System.Windows.Forms.DomainUpDown();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.lbs = new System.Windows.Forms.Label();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.khamthai = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysanh = new MaskedBox.MaskedBox();
            this.kinhcc = new MaskedBox.MaskedBox();
            this.dacdiem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listbs1 = new LibList.List();
            this.listbsgioithieu = new LibList.List();
            this.lbv = new System.Windows.Forms.Label();
            this.bacsy = new System.Windows.Forms.TextBox();
            this.listbv = new LibList.List();
            this.benhvien = new System.Windows.Forms.TextBox();
            this.n_makp = new System.Windows.Forms.CheckedListBox();
            this.chkNgoaitru = new System.Windows.Forms.CheckBox();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.chklistDTuutien = new System.Windows.Forms.CheckedListBox();
            this.lbbsgioithieu = new System.Windows.Forms.Label();
            this.txtMaBSGioiThieu = new System.Windows.Forms.TextBox();
            this.txtTenBSGioiThieu = new System.Windows.Forms.TextBox();
            this.lblchieudaithe = new System.Windows.Forms.Label();
            this.cmbLoaitg = new System.Windows.Forms.ComboBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.listKP = new LibList.List();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.butget_msbn_from_internet = new System.Windows.Forms.Button();
            this.barcode = new System.Windows.Forms.Label();
            this.phanhchinh.SuspendLayout();
            this.pnmakp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.pdienthoai.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.pmien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pvaovien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Enabled = false;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(141, 27);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(77, 21);
            this.tenba.TabIndex = 2;
            this.tenba.Visible = false;
            this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(324, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(212, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(32, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(32, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn1.Enabled = false;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(306, 50);
            this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn1.MaxLength = 8;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(25, 21);
            this.mabn1.TabIndex = 5;
            this.mabn1.Visible = false;
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(280, 50);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(25, 21);
            this.mabn2.TabIndex = 4;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(332, 50);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(45, 21);
            this.mabn3.TabIndex = 6;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(156, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(217, 94);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 9;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(242, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Location = new System.Drawing.Point(313, 94);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(64, 21);
            this.loaituoi.TabIndex = 11;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(192, 30);
            this.maba.MaxLength = 3;
            this.maba.Name = "maba";
            this.maba.Size = new System.Drawing.Size(30, 21);
            this.maba.TabIndex = 1;
            this.maba.Visible = false;
            this.maba.Validated += new System.EventHandler(this.maba_Validated);
            this.maba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maba_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(286, 94);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(25, 21);
            this.tuoi.TabIndex = 10;
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(93, 72);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(284, 21);
            this.hoten.TabIndex = 7;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label52.Location = new System.Drawing.Point(5, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(378, 20);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phanhchinh
            // 
            this.phanhchinh.BackColor = System.Drawing.SystemColors.Control;
            this.phanhchinh.Controls.Add(this.thetrungcao);
            this.phanhchinh.Controls.Add(this.chkTrungcao);
            this.phanhchinh.Controls.Add(this.cholam);
            this.phanhchinh.Controls.Add(this.tendantoc);
            this.phanhchinh.Controls.Add(this.tennuoc);
            this.phanhchinh.Controls.Add(this.manuoc);
            this.phanhchinh.Controls.Add(this.lmanuoc);
            this.phanhchinh.Controls.Add(this.sonha);
            this.phanhchinh.Controls.Add(this.tentqx);
            this.phanhchinh.Controls.Add(this.thon);
            this.phanhchinh.Controls.Add(this.mapxa2);
            this.phanhchinh.Controls.Add(this.maqu2);
            this.phanhchinh.Controls.Add(this.matt);
            this.phanhchinh.Controls.Add(this.tqx);
            this.phanhchinh.Controls.Add(this.madantoc);
            this.phanhchinh.Controls.Add(this.mann);
            this.phanhchinh.Controls.Add(this.tennn);
            this.phanhchinh.Controls.Add(this.tenquan);
            this.phanhchinh.Controls.Add(this.tentinh);
            this.phanhchinh.Controls.Add(this.lphai);
            this.phanhchinh.Controls.Add(this.tenpxa);
            this.phanhchinh.Controls.Add(this.mapxa1);
            this.phanhchinh.Controls.Add(this.lmaphuongxa);
            this.phanhchinh.Controls.Add(this.maqu1);
            this.phanhchinh.Controls.Add(this.lmaqu);
            this.phanhchinh.Controls.Add(this.lmatt);
            this.phanhchinh.Controls.Add(this.ltqx);
            this.phanhchinh.Controls.Add(this.lcholam);
            this.phanhchinh.Controls.Add(this.lthon);
            this.phanhchinh.Controls.Add(this.lsonha);
            this.phanhchinh.Controls.Add(this.lmadantoc);
            this.phanhchinh.Controls.Add(this.lmann);
            this.phanhchinh.Location = new System.Drawing.Point(17, 115);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(360, 176);
            this.phanhchinh.TabIndex = 13;
            // 
            // thetrungcao
            // 
            this.thetrungcao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thetrungcao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thetrungcao.Location = new System.Drawing.Point(303, 155);
            this.thetrungcao.Name = "thetrungcao";
            this.thetrungcao.Size = new System.Drawing.Size(54, 21);
            this.thetrungcao.TabIndex = 20;
            this.thetrungcao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTrungcao_KeyDown);
            // 
            // chkTrungcao
            // 
            this.chkTrungcao.BackColor = System.Drawing.SystemColors.Control;
            this.chkTrungcao.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrungcao.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkTrungcao.Location = new System.Drawing.Point(206, 155);
            this.chkTrungcao.Name = "chkTrungcao";
            this.chkTrungcao.Size = new System.Drawing.Size(97, 21);
            this.chkTrungcao.TabIndex = 19;
            this.chkTrungcao.Text = "BN Trung cao";
            this.chkTrungcao.UseVisualStyleBackColor = false;
            this.chkTrungcao.CheckedChanged += new System.EventHandler(this.chkTrungcao_CheckedChanged);
            this.chkTrungcao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTrungcao_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(76, 155);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(129, 21);
            this.cholam.TabIndex = 18;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(101, 23);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(65, 21);
            this.tendantoc.TabIndex = 3;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(250, 23);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(109, 21);
            this.tennuoc.TabIndex = 5;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(226, 23);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(23, 21);
            this.manuoc.TabIndex = 4;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmanuoc.Location = new System.Drawing.Point(164, 22);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(76, 45);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(90, 21);
            this.sonha.TabIndex = 6;
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(141, 67);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(218, 21);
            this.tentqx.TabIndex = 9;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(226, 45);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(133, 21);
            this.thon.TabIndex = 7;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(116, 133);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 21);
            this.mapxa2.TabIndex = 16;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(116, 111);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(23, 21);
            this.maqu2.TabIndex = 13;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(76, 89);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(63, 21);
            this.matt.TabIndex = 10;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(76, 67);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(63, 21);
            this.tqx.TabIndex = 8;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(76, 23);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 2;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(226, 1);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(23, 21);
            this.mann.TabIndex = 0;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(250, 1);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(109, 21);
            this.tennn.TabIndex = 1;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(141, 111);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(217, 21);
            this.tenquan.TabIndex = 14;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(141, 89);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(218, 21);
            this.tentinh.TabIndex = 11;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // lphai
            // 
            this.lphai.BackColor = System.Drawing.SystemColors.Control;
            this.lphai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lphai.Location = new System.Drawing.Point(22, 2);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(141, 133);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(218, 21);
            this.tenpxa.TabIndex = 17;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(76, 133);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(39, 21);
            this.mapxa1.TabIndex = 15;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.BackColor = System.Drawing.SystemColors.Control;
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaphuongxa.Location = new System.Drawing.Point(6, 133);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
            this.lmaphuongxa.TabIndex = 77;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(76, 111);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(39, 21);
            this.maqu1.TabIndex = 12;
            // 
            // lmaqu
            // 
            this.lmaqu.BackColor = System.Drawing.SystemColors.Control;
            this.lmaqu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaqu.Location = new System.Drawing.Point(5, 111);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(73, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.BackColor = System.Drawing.SystemColors.Control;
            this.lmatt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmatt.Location = new System.Drawing.Point(11, 87);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(67, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.BackColor = System.Drawing.SystemColors.Control;
            this.ltqx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ltqx.Location = new System.Drawing.Point(6, 67);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.BackColor = System.Drawing.SystemColors.Control;
            this.lcholam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcholam.Location = new System.Drawing.Point(6, 154);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.BackColor = System.Drawing.SystemColors.Control;
            this.lthon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lthon.Location = new System.Drawing.Point(156, 44);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.BackColor = System.Drawing.SystemColors.Control;
            this.lsonha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsonha.Location = new System.Drawing.Point(5, 44);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(73, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmadantoc.Location = new System.Drawing.Point(22, 23);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.BackColor = System.Drawing.SystemColors.Control;
            this.lmann.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmann.Location = new System.Drawing.Point(148, 1);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 58;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnmakp
            // 
            this.pnmakp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnmakp.BackColor = System.Drawing.SystemColors.Control;
            this.pnmakp.Controls.Add(this.dataGrid1);
            this.pnmakp.Location = new System.Drawing.Point(180, 243);
            this.pnmakp.Name = "pnmakp";
            this.pnmakp.Size = new System.Drawing.Size(224, 246);
            this.pnmakp.TabIndex = 267;
            this.pnmakp.Visible = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(2, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(215, 195);
            this.dataGrid1.TabIndex = 32;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(93, 385);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(219, 110);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(93, 94);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(69, 21);
            this.ngaysinh.TabIndex = 8;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // butInbarcode
            // 
            this.butInbarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInbarcode.BackColor = System.Drawing.Color.Transparent;
            this.butInbarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInbarcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butInbarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInbarcode.Location = new System.Drawing.Point(155, 545);
            this.butInbarcode.Name = "butInbarcode";
            this.butInbarcode.Size = new System.Drawing.Size(80, 25);
            this.butInbarcode.TabIndex = 235;
            this.butInbarcode.Text = "In mã &vạch";
            this.butInbarcode.UseVisualStyleBackColor = false;
            this.butInbarcode.Click += new System.EventHandler(this.butInbarcode_Click);
            // 
            // pdienthoai
            // 
            this.pdienthoai.BackColor = System.Drawing.SystemColors.Control;
            this.pdienthoai.Controls.Add(this.txtMsThue);
            this.pdienthoai.Controls.Add(this.txtCmnd);
            this.pdienthoai.Controls.Add(this.label17);
            this.pdienthoai.Controls.Add(this.label15);
            this.pdienthoai.Controls.Add(this.dt_email);
            this.pdienthoai.Controls.Add(this.dt_didong);
            this.pdienthoai.Controls.Add(this.dt_coquan);
            this.pdienthoai.Controls.Add(this.label31);
            this.pdienthoai.Controls.Add(this.label22);
            this.pdienthoai.Controls.Add(this.dt_nha);
            this.pdienthoai.Controls.Add(this.label21);
            this.pdienthoai.Controls.Add(this.label20);
            this.pdienthoai.Location = new System.Drawing.Point(17, 291);
            this.pdienthoai.Name = "pdienthoai";
            this.pdienthoai.Size = new System.Drawing.Size(362, 68);
            this.pdienthoai.TabIndex = 14;
            // 
            // txtMsThue
            // 
            this.txtMsThue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMsThue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMsThue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsThue.Location = new System.Drawing.Point(249, 45);
            this.txtMsThue.Name = "txtMsThue";
            this.txtMsThue.Size = new System.Drawing.Size(110, 21);
            this.txtMsThue.TabIndex = 251;
            this.txtMsThue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // txtCmnd
            // 
            this.txtCmnd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCmnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCmnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmnd.Location = new System.Drawing.Point(76, 45);
            this.txtCmnd.MaxLength = 9;
            this.txtCmnd.Name = "txtCmnd";
            this.txtCmnd.Size = new System.Drawing.Size(109, 21);
            this.txtCmnd.TabIndex = 250;
            this.txtCmnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(178, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 249;
            this.label17.Text = "MS Thuế :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(3, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 16);
            this.label15.TabIndex = 248;
            this.label15.Text = "CMND :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_email
            // 
            this.dt_email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_email.Location = new System.Drawing.Point(249, 23);
            this.dt_email.Name = "dt_email";
            this.dt_email.Size = new System.Drawing.Size(110, 21);
            this.dt_email.TabIndex = 3;
            this.dt_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_nha_KeyDown);
            // 
            // dt_didong
            // 
            this.dt_didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_didong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_didong.Location = new System.Drawing.Point(76, 23);
            this.dt_didong.Name = "dt_didong";
            this.dt_didong.Size = new System.Drawing.Size(109, 21);
            this.dt_didong.TabIndex = 2;
            this.dt_didong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_nha_KeyDown);
            // 
            // dt_coquan
            // 
            this.dt_coquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_coquan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_coquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_coquan.Location = new System.Drawing.Point(249, 1);
            this.dt_coquan.Name = "dt_coquan";
            this.dt_coquan.Size = new System.Drawing.Size(110, 21);
            this.dt_coquan.TabIndex = 1;
            this.dt_coquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_nha_KeyDown);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label31.Location = new System.Drawing.Point(212, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(40, 16);
            this.label31.TabIndex = 247;
            this.label31.Text = "Email :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(4, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 16);
            this.label22.TabIndex = 246;
            this.label22.Text = "Di động :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_nha
            // 
            this.dt_nha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_nha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_nha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_nha.Location = new System.Drawing.Point(76, 1);
            this.dt_nha.Name = "dt_nha";
            this.dt_nha.Size = new System.Drawing.Size(109, 21);
            this.dt_nha.TabIndex = 0;
            this.dt_nha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_nha_KeyDown);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(183, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 16);
            this.label21.TabIndex = 242;
            this.label21.Text = "Cơ quan :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(4, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 241;
            this.label20.Text = "ĐT nhà :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.tlbl,
            this.toolStripButton5,
            this.toolStripSeparator5,
            this.toolStripButton6,
            this.toolStripSeparator6,
            this.toolStripButton7,
            this.toolStripSeparator7,
            this.tbutvantay,
            this.toolStripSeparator8,
            this.tbutYeucauhoadon,
            this.toolStripSeparator9,
            this.tbutChuphinh,
            this.toolStripSeparator10,
            this.toolStripDropDownButton1,
            this.toolStripButton8});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(951, 23);
            this.toolStrip1.TabIndex = 244;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton1.Text = "F7";
            this.toolStripButton1.ToolTipText = "Yêu cầu cận lâm sàng";
            this.toolStripButton1.Click += new System.EventHandler(this.l_chidinh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton2.Text = "F9";
            this.toolStripButton2.ToolTipText = "Nhiều phòng khám";
            this.toolStripButton2.Click += new System.EventHandler(this.l_makp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(43, 20);
            this.toolStripButton3.Text = "^D";
            this.toolStripButton3.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton3.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(41, 20);
            this.toolStripButton4.Text = "^L";
            this.toolStripButton4.ToolTipText = "Lịch hẹn";
            this.toolStripButton4.Click += new System.EventHandler(this.l_lichhen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton5.ToolTipText = "Tự sát";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton6.ToolTipText = "Bệnh mãn tính";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton7.ToolTipText = "Tiền sử bệnh";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutvantay
            // 
            this.tbutvantay.Image = ((System.Drawing.Image)(resources.GetObject("tbutvantay.Image")));
            this.tbutvantay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbutvantay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutvantay.Name = "tbutvantay";
            this.tbutvantay.Size = new System.Drawing.Size(39, 20);
            this.tbutvantay.Text = "F5";
            this.tbutvantay.ToolTipText = "Vân tay";
            this.tbutvantay.Click += new System.EventHandler(this.tbutvantay_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutYeucauhoadon
            // 
            this.tbutYeucauhoadon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbutYeucauhoadon.Image = ((System.Drawing.Image)(resources.GetObject("tbutYeucauhoadon.Image")));
            this.tbutYeucauhoadon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutYeucauhoadon.Name = "tbutYeucauhoadon";
            this.tbutYeucauhoadon.Size = new System.Drawing.Size(23, 20);
            this.tbutYeucauhoadon.Text = "toolStripButton8";
            this.tbutYeucauhoadon.ToolTipText = "Yêu cầu hóa đơn giá trị gia tăng";
            this.tbutYeucauhoadon.Click += new System.EventHandler(this.tbutYeucauhoadon_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutChuphinh
            // 
            this.tbutChuphinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbutChuphinh.Image = ((System.Drawing.Image)(resources.GetObject("tbutChuphinh.Image")));
            this.tbutChuphinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutChuphinh.Name = "tbutChuphinh";
            this.tbutChuphinh.Size = new System.Drawing.Size(23, 20);
            this.tbutChuphinh.Text = "Chụp hình chứng từ";
            this.tbutChuphinh.Click += new System.EventHandler(this.tbutChuphinh_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkLCD,
            this.chkDieutri,
            this.chkXem,
            this.lblLCD,
            this.tmn_bienlaikhongdong,
            this.mnquanlihinhanhbn,
            this.chkBangDienGoiDocLapTheoTungQuay,
            this.mnuthongtinbodoi});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "Tùy chọn";
            // 
            // chkLCD
            // 
            this.chkLCD.CheckOnClick = true;
            this.chkLCD.Name = "chkLCD";
            this.chkLCD.Size = new System.Drawing.Size(273, 22);
            this.chkLCD.Text = "Xuất số từ .. đến ra LCD";
            this.chkLCD.Click += new System.EventHandler(this.chkLCD_Click);
            // 
            // chkDieutri
            // 
            this.chkDieutri.CheckOnClick = true;
            this.chkDieutri.Name = "chkDieutri";
            this.chkDieutri.Size = new System.Drawing.Size(273, 22);
            this.chkDieutri.Text = "In phiếu điều trị";
            // 
            // chkXem
            // 
            this.chkXem.CheckOnClick = true;
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(273, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // lblLCD
            // 
            this.lblLCD.Name = "lblLCD";
            this.lblLCD.Size = new System.Drawing.Size(273, 22);
            this.lblLCD.Text = "Thông số LCD";
            this.lblLCD.Click += new System.EventHandler(this.lblLCD_Click);
            // 
            // tmn_bienlaikhongdong
            // 
            this.tmn_bienlaikhongdong.CheckOnClick = true;
            this.tmn_bienlaikhongdong.Name = "tmn_bienlaikhongdong";
            this.tmn_bienlaikhongdong.Size = new System.Drawing.Size(273, 22);
            this.tmn_bienlaikhongdong.Text = "In biên lai 0 đồng (Miễn+BHYT)";
            this.tmn_bienlaikhongdong.Click += new System.EventHandler(this.tmn_bienlaikhongdong_Click);
            // 
            // mnquanlihinhanhbn
            // 
            this.mnquanlihinhanhbn.CheckOnClick = true;
            this.mnquanlihinhanhbn.Name = "mnquanlihinhanhbn";
            this.mnquanlihinhanhbn.Size = new System.Drawing.Size(273, 22);
            this.mnquanlihinhanhbn.Text = "Quản lí hình ảnh bệnh nhân";
            this.mnquanlihinhanhbn.CheckedChanged += new System.EventHandler(this.mnquanlihinhanhbn_CheckedChanged);
            this.mnquanlihinhanhbn.Click += new System.EventHandler(this.mnquanlihinhanhbn_Click);
            // 
            // chkBangDienGoiDocLapTheoTungQuay
            // 
            this.chkBangDienGoiDocLapTheoTungQuay.CheckOnClick = true;
            this.chkBangDienGoiDocLapTheoTungQuay.Name = "chkBangDienGoiDocLapTheoTungQuay";
            this.chkBangDienGoiDocLapTheoTungQuay.Size = new System.Drawing.Size(273, 22);
            this.chkBangDienGoiDocLapTheoTungQuay.Text = "Bảng điện gọi độc lập theo từng quầy";
            this.chkBangDienGoiDocLapTheoTungQuay.Click += new System.EventHandler(this.chkBangDienGoiDocLapTheoTungQuay_Click);
            // 
            // mnuthongtinbodoi
            // 
            this.mnuthongtinbodoi.Enabled = false;
            this.mnuthongtinbodoi.Name = "mnuthongtinbodoi";
            this.mnuthongtinbodoi.Size = new System.Drawing.Size(273, 22);
            this.mnuthongtinbodoi.Text = "Thông tin đối tượng bộ đội";
            this.mnuthongtinbodoi.Click += new System.EventHandler(this.mnuthongtinbodoi_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(91, 367);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(104, 13);
            this.label42.TabIndex = 251;
            this.label42.Text = "Các lần đăng ký ";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(3, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(383, 546);
            this.button1.TabIndex = 252;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(93, 116);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(69, 21);
            this.phai.TabIndex = 12;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(317, 508);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(67, 13);
            this.label44.TabIndex = 255;
            this.label44.Text = "Fingerprint";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Image = ((System.Drawing.Image)(resources.GetObject("label43.Image")));
            this.label43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label43.Location = new System.Drawing.Point(7, 508);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 18);
            this.label43.TabIndex = 256;
            this.label43.Text = "      Photo ";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(17, 422);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 253;
            this.pic.TabStop = false;
            // 
            // ptb
            // 
            this.ptb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptb.InitialImage")));
            this.ptb.Location = new System.Drawing.Point(318, 432);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(48, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 242;
            this.ptb.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(318, 430);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 257;
            this.pictureBox2.TabStop = false;
            // 
            // pBarcode
            // 
            this.pBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBarcode.Image = ((System.Drawing.Image)(resources.GetObject("pBarcode.Image")));
            this.pBarcode.Location = new System.Drawing.Point(247, 401);
            this.pBarcode.Name = "pBarcode";
            this.pBarcode.Size = new System.Drawing.Size(33, 13);
            this.pBarcode.TabIndex = 258;
            this.pBarcode.TabStop = false;
            // 
            // pgoi
            // 
            this.pgoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgoi.BackColor = System.Drawing.SystemColors.Control;
            this.pgoi.Controls.Add(this.butGoilai);
            this.pgoi.Controls.Add(this.butGoi);
            this.pgoi.Controls.Add(this.sonhay);
            this.pgoi.Controls.Add(this.den);
            this.pgoi.Controls.Add(this.tu);
            this.pgoi.Controls.Add(this.label50);
            this.pgoi.Location = new System.Drawing.Point(580, 0);
            this.pgoi.Name = "pgoi";
            this.pgoi.Size = new System.Drawing.Size(304, 26);
            this.pgoi.TabIndex = 262;
            // 
            // butGoilai
            // 
            this.butGoilai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGoilai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoilai.Location = new System.Drawing.Point(235, 2);
            this.butGoilai.Name = "butGoilai";
            this.butGoilai.Size = new System.Drawing.Size(67, 23);
            this.butGoilai.TabIndex = 6;
            this.butGoilai.Text = "Gọi lại";
            this.butGoilai.UseVisualStyleBackColor = true;
            this.butGoilai.Click += new System.EventHandler(this.butGoilai_Click);
            // 
            // butGoi
            // 
            this.butGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(178, 2);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(55, 23);
            this.butGoi.TabIndex = 5;
            this.butGoi.Text = "      &Gọi";
            this.butGoi.UseVisualStyleBackColor = true;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // sonhay
            // 
            this.sonhay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sonhay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonhay.Location = new System.Drawing.Point(138, 3);
            this.sonhay.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.sonhay.Name = "sonhay";
            this.sonhay.Size = new System.Drawing.Size(37, 21);
            this.sonhay.TabIndex = 4;
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(95, 3);
            this.den.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(41, 21);
            this.den.TabIndex = 2;
            // 
            // tu
            // 
            this.tu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(51, 3);
            this.tu.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(42, 21);
            this.tu.TabIndex = 1;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.Location = new System.Drawing.Point(-5, 7);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(57, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Số :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linthe
            // 
            this.linthe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linthe.BackColor = System.Drawing.SystemColors.Control;
            this.linthe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linthe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linthe.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.linthe.Image = ((System.Drawing.Image)(resources.GetObject("linthe.Image")));
            this.linthe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linthe.Location = new System.Drawing.Point(7, 526);
            this.linthe.Name = "linthe";
            this.linthe.Size = new System.Drawing.Size(100, 17);
            this.linthe.TabIndex = 263;
            this.linthe.Text = "      In thẻ";
            this.linthe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linthe.Click += new System.EventHandler(this.linthe_Click);
            // 
            // lbienlaithe
            // 
            this.lbienlaithe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbienlaithe.BackColor = System.Drawing.SystemColors.Control;
            this.lbienlaithe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbienlaithe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbienlaithe.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbienlaithe.Image = ((System.Drawing.Image)(resources.GetObject("lbienlaithe.Image")));
            this.lbienlaithe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbienlaithe.Location = new System.Drawing.Point(7, 545);
            this.lbienlaithe.Name = "lbienlaithe";
            this.lbienlaithe.Size = new System.Drawing.Size(134, 18);
            this.lbienlaithe.TabIndex = 264;
            this.lbienlaithe.Text = "      In biên lai in thẻ";
            this.lbienlaithe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbienlaithe.Click += new System.EventHandler(this.lbienlaithe_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.checkBox1.Location = new System.Drawing.Point(381, 344);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(16, 21);
            this.checkBox1.TabIndex = 222;
            this.toolTip1.SetToolTip(this.checkBox1, "Liệt kê tất cả ký hiệu biên lai");
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // ngay1
            // 
            this.ngay1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay1.Location = new System.Drawing.Point(211, 88);
            this.ngay1.Mask = "##/##/####";
            this.ngay1.Name = "ngay1";
            this.ngay1.Size = new System.Drawing.Size(62, 21);
            this.ngay1.TabIndex = 12;
            this.ngay1.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay1, "Ngày hưởng dịch vụ kỹ thuật cao, chi phí lớn");
            this.ngay1.Validated += new System.EventHandler(this.ngay1_Validated);
            // 
            // ngay2
            // 
            this.ngay2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay2.Location = new System.Drawing.Point(274, 88);
            this.ngay2.Mask = "##/##/####";
            this.ngay2.Name = "ngay2";
            this.ngay2.Size = new System.Drawing.Size(62, 21);
            this.ngay2.TabIndex = 13;
            this.ngay2.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay2, "Ngày hưởng thêm quyền lợi chăm sóc thai sản, sinh đẻ");
            this.ngay2.Validated += new System.EventHandler(this.ngay2_Validated);
            // 
            // ngay3
            // 
            this.ngay3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay3.Location = new System.Drawing.Point(337, 88);
            this.ngay3.Mask = "##/##/####";
            this.ngay3.Name = "ngay3";
            this.ngay3.Size = new System.Drawing.Size(62, 21);
            this.ngay3.TabIndex = 14;
            this.ngay3.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay3, "Ngày hưởng thêm các thuốc điều trị ung thư, thuốc chống thải ghép ngoài danh mục");
            this.ngay3.Validated += new System.EventHandler(this.ngay3_Validated);
            // 
            // chkChenhlechcongkham
            // 
            this.chkChenhlechcongkham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkChenhlechcongkham.AutoSize = true;
            this.chkChenhlechcongkham.BackColor = System.Drawing.SystemColors.Control;
            this.chkChenhlechcongkham.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkChenhlechcongkham.Location = new System.Drawing.Point(7, 518);
            this.chkChenhlechcongkham.Name = "chkChenhlechcongkham";
            this.chkChenhlechcongkham.Size = new System.Drawing.Size(181, 17);
            this.chkChenhlechcongkham.TabIndex = 269;
            this.chkChenhlechcongkham.Text = "Tính chênh lệch tiền công khám";
            this.toolTip1.SetToolTip(this.chkChenhlechcongkham, "Khi chọn: Phần chênh lệch giá khám BN phải trả + Thông số G27");
            this.chkChenhlechcongkham.UseVisualStyleBackColor = false;
            this.chkChenhlechcongkham.Visible = false;
            this.chkChenhlechcongkham.Click += new System.EventHandler(this.chkChenhlechcongkham_Click);
            // 
            // chkNhanvienbv
            // 
            this.chkNhanvienbv.AutoSize = true;
            this.chkNhanvienbv.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkNhanvienbv.Location = new System.Drawing.Point(145, 68);
            this.chkNhanvienbv.Name = "chkNhanvienbv";
            this.chkNhanvienbv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNhanvienbv.Size = new System.Drawing.Size(72, 17);
            this.chkNhanvienbv.TabIndex = 270;
            this.chkNhanvienbv.Text = "NViên BV";
            this.toolTip1.SetToolTip(this.chkNhanvienbv, "Bệnh nhân là nhân viên bệnh viện");
            this.chkNhanvienbv.UseVisualStyleBackColor = true;
            // 
            // lblDTUuTien
            // 
            this.lblDTUuTien.Image = ((System.Drawing.Image)(resources.GetObject("lblDTUuTien.Image")));
            this.lblDTUuTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDTUuTien.Location = new System.Drawing.Point(84, 42);
            this.lblDTUuTien.Name = "lblDTUuTien";
            this.lblDTUuTien.Size = new System.Drawing.Size(22, 23);
            this.lblDTUuTien.TabIndex = 271;
            this.lblDTUuTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lblDTUuTien, "Đối tượng ưu tiên");
            this.lblDTUuTien.Click += new System.EventHandler(this.lblDTUuTien_Click);
            // 
            // chkBhyt
            // 
            this.chkBhyt.BackColor = System.Drawing.SystemColors.Control;
            this.chkBhyt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkBhyt.Location = new System.Drawing.Point(34, 54);
            this.chkBhyt.Name = "chkBhyt";
            this.chkBhyt.Size = new System.Drawing.Size(73, 17);
            this.chkBhyt.TabIndex = 265;
            this.chkBhyt.Text = "Số thẻ :";
            this.chkBhyt.UseVisualStyleBackColor = false;
            this.chkBhyt.CheckedChanged += new System.EventHandler(this.chkBHYT_CheckedChanged);
            // 
            // mathe
            // 
            this.mathe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mathe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mathe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mathe.Location = new System.Drawing.Point(93, 50);
            this.mathe.MaxLength = 20;
            this.mathe.Name = "mathe";
            this.mathe.Size = new System.Drawing.Size(129, 21);
            this.mathe.TabIndex = 1;
            this.mathe.Validated += new System.EventHandler(this.mathe_Validated);
            this.mathe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mathe_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(352, -3);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 247;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // listSothe
            // 
            this.listSothe.BackColor = System.Drawing.SystemColors.Info;
            this.listSothe.ColumnCount = 0;
            this.listSothe.Location = new System.Drawing.Point(264, -3);
            this.listSothe.MatchBufferTimeOut = 1000;
            this.listSothe.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listSothe.Name = "listSothe";
            this.listSothe.Size = new System.Drawing.Size(75, 17);
            this.listSothe.TabIndex = 250;
            this.listSothe.TextIndex = -1;
            this.listSothe.TextMember = null;
            this.listSothe.ValueIndex = -1;
            this.listSothe.Visible = false;
            this.listSothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listSothe_KeyDown);
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(672, 0);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 244;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label36.Location = new System.Drawing.Point(118, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(60, 23);
            this.label36.TabIndex = 244;
            this.label36.Text = "Giới thiệu :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.BackColor = System.Drawing.SystemColors.Control;
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_bnmoi.Location = new System.Drawing.Point(111, 130);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(72, 23);
            this.l_bnmoi.TabIndex = 223;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(472, 0);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 212;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(151, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "P.khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(229, 22);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 2;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(2, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldoituong
            // 
            this.lbldoituong.BackColor = System.Drawing.SystemColors.Control;
            this.lbldoituong.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbldoituong.Location = new System.Drawing.Point(4, 66);
            this.lbldoituong.Name = "lbldoituong";
            this.lbldoituong.Size = new System.Drawing.Size(54, 23);
            this.lbldoituong.TabIndex = 12;
            this.lbldoituong.Text = "Đ. tượng :";
            this.lbldoituong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblsothe
            // 
            this.lblsothe.BackColor = System.Drawing.SystemColors.Control;
            this.lblsothe.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblsothe.Location = new System.Drawing.Point(195, 66);
            this.lblsothe.Name = "lblsothe";
            this.lblsothe.Size = new System.Drawing.Size(64, 20);
            this.lblsothe.TabIndex = 195;
            this.lblsothe.Text = "Số thẻ :";
            this.lblsothe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblden
            // 
            this.lblden.BackColor = System.Drawing.SystemColors.Control;
            this.lblden.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblden.Location = new System.Drawing.Point(111, 89);
            this.lblden.Name = "lblden";
            this.lblden.Size = new System.Drawing.Size(37, 23);
            this.lblden.TabIndex = 196;
            this.lblden.Text = "Đến :";
            this.lblden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pmien
            // 
            this.pmien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pmien.BackColor = System.Drawing.SystemColors.Control;
            this.pmien.Controls.Add(this.duyet);
            this.pmien.Controls.Add(this.lydomien);
            this.pmien.Controls.Add(this.label33);
            this.pmien.Controls.Add(this.label32);
            this.pmien.Location = new System.Drawing.Point(-1, 389);
            this.pmien.Name = "pmien";
            this.pmien.Size = new System.Drawing.Size(401, 28);
            this.pmien.TabIndex = 28;
            // 
            // duyet
            // 
            this.duyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.duyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.duyet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duyet.Location = new System.Drawing.Point(260, 4);
            this.duyet.Name = "duyet";
            this.duyet.Size = new System.Drawing.Size(134, 21);
            this.duyet.TabIndex = 245;
            this.duyet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.duyet_KeyDown);
            // 
            // lydomien
            // 
            this.lydomien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lydomien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydomien.Location = new System.Drawing.Point(56, 4);
            this.lydomien.Name = "lydomien";
            this.lydomien.Size = new System.Drawing.Size(159, 21);
            this.lydomien.TabIndex = 244;
            this.lydomien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydomien_KeyDown);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label33.Location = new System.Drawing.Point(187, 6);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(71, 16);
            this.label33.TabIndex = 243;
            this.label33.Text = "Duyệt :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label32.Location = new System.Drawing.Point(-3, 7);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(62, 16);
            this.label32.TabIndex = 242;
            this.label32.Text = "Lý do miễn :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblnguoithan
            // 
            this.lblnguoithan.BackColor = System.Drawing.SystemColors.Control;
            this.lblnguoithan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblnguoithan.Location = new System.Drawing.Point(245, 130);
            this.lblnguoithan.Name = "lblnguoithan";
            this.lblnguoithan.Size = new System.Drawing.Size(69, 23);
            this.lblnguoithan.TabIndex = 197;
            this.lblnguoithan.Text = "Người  thân :";
            this.lblnguoithan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblhoten
            // 
            this.lblhoten.BackColor = System.Drawing.SystemColors.Control;
            this.lblhoten.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblhoten.Location = new System.Drawing.Point(2, 154);
            this.lblhoten.Name = "lblhoten";
            this.lblhoten.Size = new System.Drawing.Size(57, 23);
            this.lblhoten.TabIndex = 198;
            this.lblhoten.Text = "Họ tên :";
            this.lblhoten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldiachi
            // 
            this.lbldiachi.BackColor = System.Drawing.SystemColors.Control;
            this.lbldiachi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbldiachi.Location = new System.Drawing.Point(8, 175);
            this.lbldiachi.Name = "lbldiachi";
            this.lbldiachi.Size = new System.Drawing.Size(48, 23);
            this.lbldiachi.TabIndex = 199;
            this.lbldiachi.Text = "Địa chỉ :";
            this.lbldiachi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldienthoai
            // 
            this.lbldienthoai.BackColor = System.Drawing.SystemColors.Control;
            this.lbldienthoai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbldienthoai.Location = new System.Drawing.Point(195, 152);
            this.lbldienthoai.Name = "lbldienthoai";
            this.lbldienthoai.Size = new System.Drawing.Size(57, 23);
            this.lbldienthoai.TabIndex = 200;
            this.lbldienthoai.Text = "Đ. thoại :";
            this.lbldienthoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(2, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(55, 44);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(28, 21);
            this.sovaovien.TabIndex = 4;
            // 
            // quanhe
            // 
            this.quanhe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(312, 132);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(88, 21);
            this.quanhe.TabIndex = 19;
            this.quanhe.TextChanged += new System.EventHandler(this.quanhe_TextChanged);
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // qh_diachi
            // 
            this.qh_diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(55, 176);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(343, 21);
            this.qh_diachi.TabIndex = 21;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.DropDownWidth = 140;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(74, 66);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(70, 21);
            this.tendoituong.TabIndex = 8;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(55, 66);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            this.madoituong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.madoituong_KeyPress);
            // 
            // lbldkkcb
            // 
            this.lbldkkcb.BackColor = System.Drawing.SystemColors.Control;
            this.lbldkkcb.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbldkkcb.Location = new System.Drawing.Point(2, 110);
            this.lbldkkcb.Name = "lbldkkcb";
            this.lbldkkcb.Size = new System.Drawing.Size(57, 23);
            this.lbldkkcb.TabIndex = 215;
            this.lbldkkcb.Text = "ĐKKCB :";
            this.lbldkkcb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbldkkcb.Click += new System.EventHandler(this.label8_Click);
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "New encounter",
            "Followed-up"});
            this.bnmoi.Location = new System.Drawing.Point(182, 132);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(64, 21);
            this.bnmoi.TabIndex = 18;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(246, 491);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 32;
            this.butIn.Text = "      &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // lbacsy
            // 
            this.lbacsy.BackColor = System.Drawing.SystemColors.Control;
            this.lbacsy.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbacsy.Location = new System.Drawing.Point(2, 198);
            this.lbacsy.Name = "lbacsy";
            this.lbacsy.Size = new System.Drawing.Size(57, 19);
            this.lbacsy.TabIndex = 246;
            this.lbacsy.Text = "Bác sĩ :";
            this.lbacsy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(89, 199);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(310, 21);
            this.tenbs.TabIndex = 26;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label34.Location = new System.Drawing.Point(10, 133);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 23);
            this.label34.TabIndex = 248;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(36, 491);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 31;
            this.butTiep.Text = "       &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(55, 132);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(62, 21);
            this.loai.TabIndex = 14;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(106, 491);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 29;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(176, 491);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 30;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(117, 110);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(183, 21);
            this.tenbv.TabIndex = 16;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(316, 491);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 33;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbltu
            // 
            this.lbltu.BackColor = System.Drawing.SystemColors.Control;
            this.lbltu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbltu.Location = new System.Drawing.Point(2, 89);
            this.lbltu.Name = "lbltu";
            this.lbltu.Size = new System.Drawing.Size(56, 23);
            this.lbltu.TabIndex = 249;
            this.lbltu.Text = "Từ :";
            this.lbltu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(55, 88);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(62, 21);
            this.tungay.TabIndex = 10;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(256, 66);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(132, 21);
            this.sothe.TabIndex = 9;
            this.sothe.TextChanged += new System.EventHandler(this.sothe_TextChanged);
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            this.sothe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sothe_KeyPress);
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label37.Location = new System.Drawing.Point(111, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 23);
            this.label37.TabIndex = 1;
            this.label37.Text = "giờ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(141, 22);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(55, 22);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(62, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // tendstt
            // 
            this.tendstt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(226, 44);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(173, 21);
            this.tendstt.TabIndex = 6;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(176, 44);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(48, 21);
            this.madstt.TabIndex = 5;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // lhonnhan
            // 
            this.lhonnhan.BackColor = System.Drawing.SystemColors.Control;
            this.lhonnhan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lhonnhan.Location = new System.Drawing.Point(245, 175);
            this.lhonnhan.Name = "lhonnhan";
            this.lhonnhan.Size = new System.Drawing.Size(69, 23);
            this.lhonnhan.TabIndex = 239;
            this.lhonnhan.Text = "Hôn phối :";
            this.lhonnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // honnhan
            // 
            this.honnhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.honnhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.honnhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.honnhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.honnhan.Location = new System.Drawing.Point(312, 176);
            this.honnhan.Name = "honnhan";
            this.honnhan.Size = new System.Drawing.Size(88, 21);
            this.honnhan.TabIndex = 23;
            this.honnhan.VisibleChanged += new System.EventHandler(this.honnhan_VisibleChanged);
            this.honnhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.honnhan_KeyDown);
            // 
            // dausinhton
            // 
            this.dausinhton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
            this.dausinhton.Controls.Add(this.txtNhipTho);
            this.dausinhton.Controls.Add(this.label27);
            this.dausinhton.Controls.Add(this.label26);
            this.dausinhton.Controls.Add(this.label25);
            this.dausinhton.Controls.Add(this.label24);
            this.dausinhton.Controls.Add(this.label23);
            this.dausinhton.Controls.Add(this.label8);
            this.dausinhton.Controls.Add(this.huyetap);
            this.dausinhton.Controls.Add(this.mach);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.chieucao);
            this.dausinhton.Controls.Add(this.bmi);
            this.dausinhton.Controls.Add(this.cannang);
            this.dausinhton.Controls.Add(this.label45);
            this.dausinhton.Controls.Add(this.label40);
            this.dausinhton.Controls.Add(this.label39);
            this.dausinhton.Controls.Add(this.label14);
            this.dausinhton.Controls.Add(this.label13);
            this.dausinhton.Controls.Add(this.label16);
            this.dausinhton.Controls.Add(this.label18);
            this.dausinhton.Location = new System.Drawing.Point(5, 240);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(393, 48);
            this.dausinhton.TabIndex = 27;
            // 
            // txtNhipTho
            // 
            this.txtNhipTho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNhipTho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhipTho.Location = new System.Drawing.Point(263, 25);
            this.txtNhipTho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.txtNhipTho.MaxLength = 5;
            this.txtNhipTho.Name = "txtNhipTho";
            this.txtNhipTho.Size = new System.Drawing.Size(32, 21);
            this.txtNhipTho.TabIndex = 27;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(298, 22);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 23);
            this.label27.TabIndex = 38;
            this.label27.Text = "l/p";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(213, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 18);
            this.label26.TabIndex = 36;
            this.label26.Text = "Nhịp thở:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(321, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 15);
            this.label25.TabIndex = 35;
            this.label25.Text = "BMI:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(89, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 20);
            this.label24.TabIndex = 34;
            this.label24.Text = "Chiều cao:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label23.Location = new System.Drawing.Point(204, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 18);
            this.label23.TabIndex = 33;
            this.label23.Text = "Huyết áp:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(96, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "Nhiệt độ:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // huyetap
            // 
            this.huyetap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(262, 3);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(61, 21);
            this.huyetap.TabIndex = 20;
            this.huyetap.Validated += new System.EventHandler(this.huyetap_Validated);
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(39, 3);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 16;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(150, 3);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(36, 21);
            this.nhietdo.TabIndex = 18;
            this.nhietdo.Text = "  .  ";
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(150, 25);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(36, 21);
            this.chieucao.TabIndex = 22;
            this.chieucao.Validated += new System.EventHandler(this.chieucao_Validated);
            // 
            // bmi
            // 
            this.bmi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bmi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bmi.Enabled = false;
            this.bmi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmi.Location = new System.Drawing.Point(351, 25);
            this.bmi.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.bmi.MaxLength = 5;
            this.bmi.Name = "bmi";
            this.bmi.Size = new System.Drawing.Size(39, 21);
            this.bmi.TabIndex = 28;
            this.bmi.Text = "12345";
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(39, 25);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(32, 21);
            this.cannang.TabIndex = 21;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(189, 22);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(26, 22);
            this.label45.TabIndex = 31;
            this.label45.Text = "cm";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(73, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(20, 22);
            this.label40.TabIndex = 29;
            this.label40.Text = "kg";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(-6, 25);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(46, 23);
            this.label39.TabIndex = 25;
            this.label39.Text = "Nặng :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(74, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 23);
            this.label14.TabIndex = 17;
            this.label14.Text = "l/p";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(0, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 23);
            this.label13.TabIndex = 1;
            this.label13.Text = "Mạch :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(188, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 23);
            this.label16.TabIndex = 19;
            this.label16.Text = "°C";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(330, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 23);
            this.label18.TabIndex = 21;
            this.label18.Text = "mmHg";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label53.Location = new System.Drawing.Point(1, 1);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(399, 20);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN ĐĂNG KÝ  KHÁM BỆNH :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(55, 110);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(60, 21);
            this.mabv.TabIndex = 15;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.Location = new System.Drawing.Point(3, 338);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(396, 50);
            this.label38.TabIndex = 254;
            // 
            // ltienkham
            // 
            this.ltienkham.BackColor = System.Drawing.SystemColors.Control;
            this.ltienkham.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ltienkham.Location = new System.Drawing.Point(1, 363);
            this.ltienkham.Name = "ltienkham";
            this.ltienkham.Size = new System.Drawing.Size(52, 23);
            this.ltienkham.TabIndex = 240;
            this.ltienkham.Text = "Thu tiền :";
            this.ltienkham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsobienlai
            // 
            this.lsobienlai.BackColor = System.Drawing.SystemColors.Control;
            this.lsobienlai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsobienlai.Location = new System.Drawing.Point(192, 346);
            this.lsobienlai.Name = "lsobienlai";
            this.lsobienlai.Size = new System.Drawing.Size(54, 15);
            this.lsobienlai.TabIndex = 27;
            this.lsobienlai.Text = "Biên lai :";
            this.lsobienlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tienkham
            // 
            this.tienkham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tienkham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tienkham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienkham.Location = new System.Drawing.Point(104, 365);
            this.tienkham.Name = "tienkham";
            this.tienkham.Size = new System.Drawing.Size(293, 21);
            this.tienkham.TabIndex = 31;
            this.tienkham.SelectedIndexChanged += new System.EventHandler(this.tienkham_SelectedIndexChanged);
            this.tienkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tienkham_KeyDown);
            // 
            // matienkham
            // 
            this.matienkham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matienkham.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.matienkham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matienkham.Location = new System.Drawing.Point(55, 365);
            this.matienkham.Name = "matienkham";
            this.matienkham.Size = new System.Drawing.Size(48, 21);
            this.matienkham.TabIndex = 27;
            this.matienkham.Validated += new System.EventHandler(this.matienkham_Validated);
            this.matienkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matienkham_KeyDown);
            // 
            // butKyhieu
            // 
            this.butKyhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKyhieu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKyhieu.Image = ((System.Drawing.Image)(resources.GetObject("butKyhieu.Image")));
            this.butKyhieu.Location = new System.Drawing.Point(359, 342);
            this.butKyhieu.Name = "butKyhieu";
            this.butKyhieu.Size = new System.Drawing.Size(21, 21);
            this.butKyhieu.TabIndex = 244;
            this.butKyhieu.Text = "...";
            this.butKyhieu.Click += new System.EventHandler(this.butKyhieu_Click);
            // 
            // lkyhieu
            // 
            this.lkyhieu.BackColor = System.Drawing.SystemColors.Control;
            this.lkyhieu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lkyhieu.Location = new System.Drawing.Point(5, 347);
            this.lkyhieu.Name = "lkyhieu";
            this.lkyhieu.Size = new System.Drawing.Size(48, 16);
            this.lkyhieu.TabIndex = 25;
            this.lkyhieu.Text = "&Ký hiệu :";
            this.lkyhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kyhieu
            // 
            this.kyhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kyhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kyhieu.Location = new System.Drawing.Point(55, 342);
            this.kyhieu.Name = "kyhieu";
            this.kyhieu.Size = new System.Drawing.Size(119, 21);
            this.kyhieu.TabIndex = 30;
            this.kyhieu.SelectedIndexChanged += new System.EventHandler(this.kyhieu_SelectedIndexChanged);
            this.kyhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kyhieu_KeyDown);
            // 
            // llydo
            // 
            this.llydo.BackColor = System.Drawing.SystemColors.Control;
            this.llydo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.llydo.Location = new System.Drawing.Point(10, 218);
            this.llydo.Name = "llydo";
            this.llydo.Size = new System.Drawing.Size(48, 24);
            this.llydo.TabIndex = 21;
            this.llydo.Text = "Lý do :";
            this.llydo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(55, 221);
            this.lydo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(344, 21);
            this.lydo.TabIndex = 24;
            this.lydo.Validated += new System.EventHandler(this.lydo_Validated);
            // 
            // sobienlai
            // 
            this.sobienlai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sobienlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobienlai.Location = new System.Drawing.Point(243, 342);
            this.sobienlai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sobienlai.MaxLength = 7;
            this.sobienlai.Name = "sobienlai";
            this.sobienlai.Size = new System.Drawing.Size(28, 20);
            this.sobienlai.TabIndex = 31;
            this.sobienlai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sobienlai.Validated += new System.EventHandler(this.sobienlai_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(274, 342);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(84, 20);
            this.dongia.TabIndex = 32;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dongia_KeyDown);
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.BackColor = System.Drawing.SystemColors.Control;
            this.chkxml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkxml.Location = new System.Drawing.Point(305, 3);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(85, 17);
            this.chkxml.TabIndex = 264;
            this.chkxml.Text = "Xuất ra XML";
            this.chkxml.UseVisualStyleBackColor = false;
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(147, 88);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(62, 21);
            this.denngay.TabIndex = 11;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // lbs
            // 
            this.lbs.BackColor = System.Drawing.SystemColors.Control;
            this.lbs.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbs.Location = new System.Drawing.Point(3, 289);
            this.lbs.Name = "lbs";
            this.lbs.Size = new System.Drawing.Size(53, 23);
            this.lbs.TabIndex = 247;
            this.lbs.Text = "Bác sĩ :";
            this.lbs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(55, 154);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(124, 21);
            this.qh_hoten.TabIndex = 20;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(248, 154);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(151, 21);
            this.qh_dienthoai.TabIndex = 22;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(55, 199);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 25;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // khamthai
            // 
            this.khamthai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.khamthai.BackColor = System.Drawing.SystemColors.Control;
            this.khamthai.Controls.Add(this.label10);
            this.khamthai.Controls.Add(this.ngaysanh);
            this.khamthai.Controls.Add(this.kinhcc);
            this.khamthai.Controls.Add(this.dacdiem);
            this.khamthai.Controls.Add(this.label12);
            this.khamthai.Controls.Add(this.label11);
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label9);
            this.khamthai.Location = new System.Drawing.Point(5, 287);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(396, 45);
            this.khamthai.TabIndex = 28;
            this.khamthai.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(184, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Kinh cuối cùng :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysanh
            // 
            this.ngaysanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysanh.Location = new System.Drawing.Point(98, 23);
            this.ngaysanh.Mask = "##/##/####";
            this.ngaysanh.Name = "ngaysanh";
            this.ngaysanh.Size = new System.Drawing.Size(56, 21);
            this.ngaysanh.TabIndex = 5;
            this.ngaysanh.Text = "  /  /    ";
            this.ngaysanh.Validated += new System.EventHandler(this.ngaysanh_Validated);
            // 
            // kinhcc
            // 
            this.kinhcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhcc.Location = new System.Drawing.Point(272, 1);
            this.kinhcc.Mask = "##/##/####";
            this.kinhcc.Name = "kinhcc";
            this.kinhcc.Size = new System.Drawing.Size(72, 21);
            this.kinhcc.TabIndex = 4;
            this.kinhcc.Text = "  /  /    ";
            this.kinhcc.Validated += new System.EventHandler(this.kinhcc_Validated);
            // 
            // dacdiem
            // 
            this.dacdiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dacdiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dacdiem.Location = new System.Drawing.Point(272, 23);
            this.dacdiem.Name = "dacdiem";
            this.dacdiem.Size = new System.Drawing.Size(102, 21);
            this.dacdiem.TabIndex = 6;
            this.dacdiem.Validated += new System.EventHandler(this.dacdiem_Validated);
            this.dacdiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dacdiem_KeyDown);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(152, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Đặc điểm thai phụ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(-9, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "Ngày sinh dự kiến :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(122, 1);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(22, 21);
            this.para4.TabIndex = 3;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            this.para4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(98, 1);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(22, 21);
            this.para3.TabIndex = 2;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            this.para3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(73, 1);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(22, 21);
            this.para2.TabIndex = 1;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            this.para2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(49, 1);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(22, 21);
            this.para1.TabIndex = 0;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            this.para1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.para1_KeyDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(-12, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Para :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listbs1
            // 
            this.listbs1.BackColor = System.Drawing.SystemColors.Info;
            this.listbs1.ColumnCount = 0;
            this.listbs1.Location = new System.Drawing.Point(332, 13);
            this.listbs1.MatchBufferTimeOut = 1000;
            this.listbs1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbs1.Name = "listbs1";
            this.listbs1.Size = new System.Drawing.Size(75, 17);
            this.listbs1.TabIndex = 265;
            this.listbs1.TextIndex = -1;
            this.listbs1.TextMember = null;
            this.listbs1.ValueIndex = -1;
            this.listbs1.Visible = false;
            this.listbs1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listbs_KeyDown);
            // 
            // listbsgioithieu
            // 
            this.listbsgioithieu.BackColor = System.Drawing.SystemColors.Info;
            this.listbsgioithieu.ColumnCount = 0;
            this.listbsgioithieu.Location = new System.Drawing.Point(332, 13);
            this.listbsgioithieu.MatchBufferTimeOut = 1000;
            this.listbsgioithieu.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbsgioithieu.Name = "listbsgioithieu";
            this.listbsgioithieu.Size = new System.Drawing.Size(75, 17);
            this.listbsgioithieu.TabIndex = 265;
            this.listbsgioithieu.TextIndex = -1;
            this.listbsgioithieu.TextMember = null;
            this.listbsgioithieu.ValueIndex = -1;
            this.listbsgioithieu.Visible = false;
            this.listbsgioithieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listbsgioithieu_KeyDown);
            // 
            // lbv
            // 
            this.lbv.BackColor = System.Drawing.SystemColors.Control;
            this.lbv.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbv.Location = new System.Drawing.Point(13, 307);
            this.lbv.Name = "lbv";
            this.lbv.Size = new System.Drawing.Size(43, 23);
            this.lbv.TabIndex = 253;
            this.lbv.Text = "B viện :";
            this.lbv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bacsy
            // 
            this.bacsy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bacsy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bacsy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bacsy.Location = new System.Drawing.Point(54, 288);
            this.bacsy.Name = "bacsy";
            this.bacsy.Size = new System.Drawing.Size(345, 21);
            this.bacsy.TabIndex = 26;
            this.bacsy.TextChanged += new System.EventHandler(this.bacsy_TextChanged);
            this.bacsy.Validated += new System.EventHandler(this.bacsy_Validated);
            this.bacsy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bacsy_KeyDown);
            // 
            // listbv
            // 
            this.listbv.BackColor = System.Drawing.SystemColors.Info;
            this.listbv.ColumnCount = 0;
            this.listbv.Location = new System.Drawing.Point(295, 16);
            this.listbv.MatchBufferTimeOut = 1000;
            this.listbv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbv.Name = "listbv";
            this.listbv.Size = new System.Drawing.Size(75, 17);
            this.listbv.TabIndex = 266;
            this.listbv.TextIndex = -1;
            this.listbv.TextMember = null;
            this.listbv.ValueIndex = -1;
            this.listbv.Visible = false;
            // 
            // benhvien
            // 
            this.benhvien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(54, 310);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(345, 21);
            this.benhvien.TabIndex = 27;
            this.benhvien.TextChanged += new System.EventHandler(this.benhvien_TextChanged);
            this.benhvien.Validated += new System.EventHandler(this.benhvien_Validated);
            this.benhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhvien_KeyDown);
            // 
            // n_makp
            // 
            this.n_makp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.n_makp.BackColor = System.Drawing.SystemColors.Info;
            this.n_makp.CheckOnClick = true;
            this.n_makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_makp.Location = new System.Drawing.Point(585, 245);
            this.n_makp.Name = "n_makp";
            this.n_makp.Size = new System.Drawing.Size(202, 244);
            this.n_makp.TabIndex = 229;
            this.n_makp.Visible = false;
            this.n_makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.n_makp_KeyDown);
            // 
            // chkNgoaitru
            // 
            this.chkNgoaitru.BackColor = System.Drawing.SystemColors.Control;
            this.chkNgoaitru.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNgoaitru.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkNgoaitru.Location = new System.Drawing.Point(13, 131);
            this.chkNgoaitru.Name = "chkNgoaitru";
            this.chkNgoaitru.Size = new System.Drawing.Size(103, 21);
            this.chkNgoaitru.TabIndex = 17;
            this.chkNgoaitru.Text = "Điều trị ngoại trú";
            this.chkNgoaitru.UseVisualStyleBackColor = false;
            this.chkNgoaitru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkNgoaitru_KeyDown);
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pvaovien.Controls.Add(this.pnmakp);
            this.pvaovien.Controls.Add(this.lblDTUuTien);
            this.pvaovien.Controls.Add(this.chklistDTuutien);
            this.pvaovien.Controls.Add(this.listbsgioithieu);
            this.pvaovien.Controls.Add(this.lbbsgioithieu);
            this.pvaovien.Controls.Add(this.txtMaBSGioiThieu);
            this.pvaovien.Controls.Add(this.txtTenBSGioiThieu);
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.lblchieudaithe);
            this.pvaovien.Controls.Add(this.cmbLoaitg);
            this.pvaovien.Controls.Add(this.chkNhanvienbv);
            this.pvaovien.Controls.Add(this.chkChenhlechcongkham);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.listKP);
            this.pvaovien.Controls.Add(this.traituyen);
            this.pvaovien.Controls.Add(this.ngay3);
            this.pvaovien.Controls.Add(this.ngay2);
            this.pvaovien.Controls.Add(this.ngay1);
            this.pvaovien.Controls.Add(this.chkNgoaitru);
            this.pvaovien.Controls.Add(this.benhvien);
            this.pvaovien.Controls.Add(this.listbv);
            this.pvaovien.Controls.Add(this.bacsy);
            this.pvaovien.Controls.Add(this.lbv);
            this.pvaovien.Controls.Add(this.listbs1);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Controls.Add(this.mabs);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.lbs);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.chkxml);
            this.pvaovien.Controls.Add(this.dongia);
            this.pvaovien.Controls.Add(this.sobienlai);
            this.pvaovien.Controls.Add(this.lydo);
            this.pvaovien.Controls.Add(this.llydo);
            this.pvaovien.Controls.Add(this.checkBox1);
            this.pvaovien.Controls.Add(this.kyhieu);
            this.pvaovien.Controls.Add(this.lkyhieu);
            this.pvaovien.Controls.Add(this.butKyhieu);
            this.pvaovien.Controls.Add(this.matienkham);
            this.pvaovien.Controls.Add(this.tienkham);
            this.pvaovien.Controls.Add(this.lsobienlai);
            this.pvaovien.Controls.Add(this.ltienkham);
            this.pvaovien.Controls.Add(this.label38);
            this.pvaovien.Controls.Add(this.mabv);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.dausinhton);
            this.pvaovien.Controls.Add(this.honnhan);
            this.pvaovien.Controls.Add(this.lhonnhan);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label37);
            this.pvaovien.Controls.Add(this.tungay);
            this.pvaovien.Controls.Add(this.lbltu);
            this.pvaovien.Controls.Add(this.butKetthuc);
            this.pvaovien.Controls.Add(this.tenbv);
            this.pvaovien.Controls.Add(this.butBoqua);
            this.pvaovien.Controls.Add(this.butLuu);
            this.pvaovien.Controls.Add(this.loai);
            this.pvaovien.Controls.Add(this.butTiep);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.tenbs);
            this.pvaovien.Controls.Add(this.lbacsy);
            this.pvaovien.Controls.Add(this.butIn);
            this.pvaovien.Controls.Add(this.bnmoi);
            this.pvaovien.Controls.Add(this.lbldkkcb);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.lbldienthoai);
            this.pvaovien.Controls.Add(this.lbldiachi);
            this.pvaovien.Controls.Add(this.lblhoten);
            this.pvaovien.Controls.Add(this.lblnguoithan);
            this.pvaovien.Controls.Add(this.pmien);
            this.pvaovien.Controls.Add(this.lblden);
            this.pvaovien.Controls.Add(this.lblsothe);
            this.pvaovien.Controls.Add(this.lbldoituong);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.list);
            this.pvaovien.Controls.Add(this.l_bnmoi);
            this.pvaovien.Controls.Add(this.label36);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Controls.Add(this.listSothe);
            this.pvaovien.Controls.Add(this.listBS);
            this.pvaovien.Controls.Add(this.button2);
            this.pvaovien.Location = new System.Drawing.Point(388, 27);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(419, 550);
            this.pvaovien.TabIndex = 15;
            // 
            // chklistDTuutien
            // 
            this.chklistDTuutien.FormattingEnabled = true;
            this.chklistDTuutien.Items.AddRange(new object[] {
            "Người già > 80 Tuổi",
            "Trẻ em < 1 Tuổi",
            "Thương binh",
            "Người tàn tật"});
            this.chklistDTuutien.Location = new System.Drawing.Point(106, 24);
            this.chklistDTuutien.Name = "chklistDTuutien";
            this.chklistDTuutien.Size = new System.Drawing.Size(120, 64);
            this.chklistDTuutien.TabIndex = 271;
            this.chklistDTuutien.VisibleChanged += new System.EventHandler(this.chklistDTuutien_VisibleChanged);
            this.chklistDTuutien.SelectedIndexChanged += new System.EventHandler(this.chklistDTuutien_SelectedIndexChanged);
            // 
            // lbbsgioithieu
            // 
            this.lbbsgioithieu.BackColor = System.Drawing.SystemColors.Control;
            this.lbbsgioithieu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbbsgioithieu.Location = new System.Drawing.Point(5, 202);
            this.lbbsgioithieu.Name = "lbbsgioithieu";
            this.lbbsgioithieu.Size = new System.Drawing.Size(93, 19);
            this.lbbsgioithieu.TabIndex = 277;
            this.lbbsgioithieu.Text = "Bác sĩ giới thiệu :";
            this.lbbsgioithieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaBSGioiThieu
            // 
            this.txtMaBSGioiThieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMaBSGioiThieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaBSGioiThieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBSGioiThieu.Location = new System.Drawing.Point(98, 201);
            this.txtMaBSGioiThieu.Name = "txtMaBSGioiThieu";
            this.txtMaBSGioiThieu.Size = new System.Drawing.Size(32, 21);
            this.txtMaBSGioiThieu.TabIndex = 275;
            this.txtMaBSGioiThieu.Validated += new System.EventHandler(this.txtMaBSGioiThieu_Validated);
            this.txtMaBSGioiThieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaBSGioiThieu_KeyDown);
            // 
            // txtTenBSGioiThieu
            // 
            this.txtTenBSGioiThieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBSGioiThieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenBSGioiThieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBSGioiThieu.Location = new System.Drawing.Point(131, 201);
            this.txtTenBSGioiThieu.Name = "txtTenBSGioiThieu";
            this.txtTenBSGioiThieu.Size = new System.Drawing.Size(269, 21);
            this.txtTenBSGioiThieu.TabIndex = 276;
            this.txtTenBSGioiThieu.TextChanged += new System.EventHandler(this.txtTenBSGioiThieu_TextChanged);
            this.txtTenBSGioiThieu.Validated += new System.EventHandler(this.txtTenBSGioiThieu_Validated);
            this.txtTenBSGioiThieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenBSGioiThieu_KeyDown);
            // 
            // lblchieudaithe
            // 
            this.lblchieudaithe.BackColor = System.Drawing.SystemColors.Control;
            this.lblchieudaithe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchieudaithe.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblchieudaithe.Location = new System.Drawing.Point(384, 66);
            this.lblchieudaithe.Name = "lblchieudaithe";
            this.lblchieudaithe.Size = new System.Drawing.Size(22, 23);
            this.lblchieudaithe.TabIndex = 274;
            this.lblchieudaithe.Text = "20";
            this.lblchieudaithe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLoaitg
            // 
            this.cmbLoaitg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaitg.Enabled = false;
            this.cmbLoaitg.FormattingEnabled = true;
            this.cmbLoaitg.Location = new System.Drawing.Point(240, -1);
            this.cmbLoaitg.Name = "cmbLoaitg";
            this.cmbLoaitg.Size = new System.Drawing.Size(159, 21);
            this.cmbLoaitg.TabIndex = 273;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(254, 22);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(145, 21);
            this.tenkp.TabIndex = 3;
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // listKP
            // 
            this.listKP.BackColor = System.Drawing.SystemColors.Info;
            this.listKP.ColumnCount = 0;
            this.listKP.Location = new System.Drawing.Point(335, 19);
            this.listKP.MatchBufferTimeOut = 1000;
            this.listKP.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listKP.Name = "listKP";
            this.listKP.Size = new System.Drawing.Size(75, 17);
            this.listKP.TabIndex = 268;
            this.listKP.TextIndex = -1;
            this.listKP.TextMember = null;
            this.listKP.ValueIndex = -1;
            this.listKP.Visible = false;
            // 
            // traituyen
            // 
            this.traituyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.traituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen.Location = new System.Drawing.Point(301, 110);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(97, 21);
            this.traituyen.TabIndex = 17;
            this.traituyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.traituyen_KeyDown);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(-1, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(408, 545);
            this.button2.TabIndex = 271;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(792, 30);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(160, 241);
            this.dataGrid2.TabIndex = 267;
            this.dataGrid2.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid2_Navigate);
            // 
            // chkView
            // 
            this.chkView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkView.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkView.Location = new System.Drawing.Point(804, 25);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(147, 23);
            this.chkView.TabIndex = 268;
            this.chkView.Text = "Thông tin người bệnh đăng ký khám bệnh";
            this.chkView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkView.UseVisualStyleBackColor = true;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // butget_msbn_from_internet
            // 
            this.butget_msbn_from_internet.Location = new System.Drawing.Point(286, 27);
            this.butget_msbn_from_internet.Name = "butget_msbn_from_internet";
            this.butget_msbn_from_internet.Size = new System.Drawing.Size(92, 23);
            this.butget_msbn_from_internet.TabIndex = 269;
            this.butget_msbn_from_internet.Text = "Lấy Mã BN";
            this.butget_msbn_from_internet.UseVisualStyleBackColor = true;
            this.butget_msbn_from_internet.Visible = false;
            this.butget_msbn_from_internet.Click += new System.EventHandler(this.butget_msbn_from_internet_Click);
            // 
            // barcode
            // 
            this.barcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcode.Location = new System.Drawing.Point(87, 497);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(233, 45);
            this.barcode.TabIndex = 270;
            this.barcode.Text = "label41";
            this.barcode.Visible = false;
            // 
            // frmDkkb_chung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(951, 573);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.butget_msbn_from_internet);
            this.Controls.Add(this.chkView);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.mathe);
            this.Controls.Add(this.chkBhyt);
            this.Controls.Add(this.butInbarcode);
            this.Controls.Add(this.lbienlaithe);
            this.Controls.Add(this.linthe);
            this.Controls.Add(this.pgoi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.n_makp);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pdienthoai);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBarcode);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, -2);
            this.Name = "frmDkkb_chung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft THIS - Đăng ký ";
            this.Load += new System.EventHandler(this.frmDkkb_chung_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDkkb_chung_KeyDown);
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.pnmakp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.pdienthoai.ResumeLayout(false);
            this.pdienthoai.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).EndInit();
            this.pgoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.pmien.ResumeLayout(false);
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        void QLNVSale_SapXepControl(int iKhoangDichChuyen)
        {
            try
            {
                lbldoituong.Location = new Point(lbldoituong.Location.X, lbldoituong.Location.Y + iKhoangDichChuyen);
                madoituong.Location = new Point(madoituong.Location.X, madoituong.Location.Y + iKhoangDichChuyen);
                tendoituong.Location = new Point(tendoituong.Location.X, tendoituong.Location.Y + iKhoangDichChuyen);
                chkNhanvienbv.Location = new Point(chkNhanvienbv.Location.X, chkNhanvienbv.Location.Y + iKhoangDichChuyen);
                lblsothe.Location = new Point(lblsothe.Location.X, lblsothe.Location.Y + iKhoangDichChuyen);
                sothe.Location = new Point(sothe.Location.X, sothe.Location.Y + iKhoangDichChuyen);
                lblchieudaithe.Location = new Point(lblchieudaithe.Location.X, lblchieudaithe.Location.Y + iKhoangDichChuyen);
                lbltu.Location = new Point(lbltu.Location.X, lbltu.Location.Y + iKhoangDichChuyen);
                tungay.Location = new Point(tungay.Location.X, tungay.Location.Y + iKhoangDichChuyen);
                lblden.Location = new Point(lblden.Location.X, lblden.Location.Y + iKhoangDichChuyen);
                denngay.Location = new Point(denngay.Location.X, denngay.Location.Y + iKhoangDichChuyen);
                ngay1.Location = new Point(ngay1.Location.X, ngay1.Location.Y + iKhoangDichChuyen);
                ngay2.Location = new Point(ngay2.Location.X, ngay2.Location.Y + iKhoangDichChuyen);
                ngay3.Location = new Point(ngay3.Location.X, ngay3.Location.Y + iKhoangDichChuyen);
                mabv.Location = new Point(mabv.Location.X, mabv.Location.Y + iKhoangDichChuyen);
                tenbv.Location = new Point(tenbv.Location.X, tenbv.Location.Y + iKhoangDichChuyen);
                traituyen.Location = new Point(traituyen.Location.X, traituyen.Location.Y + iKhoangDichChuyen);
                chkNgoaitru.Location = new Point(chkNgoaitru.Location.X, chkNgoaitru.Location.Y + iKhoangDichChuyen);
                l_bnmoi.Location = new Point(l_bnmoi.Location.X, l_bnmoi.Location.Y + iKhoangDichChuyen);
                bnmoi.Location = new Point(bnmoi.Location.X, bnmoi.Location.Y + iKhoangDichChuyen);
                lblnguoithan.Location = new Point(lblnguoithan.Location.X, lblnguoithan.Location.Y + iKhoangDichChuyen);
                quanhe.Location = new Point(quanhe.Location.X, quanhe.Location.Y + iKhoangDichChuyen);
                lblhoten.Location = new Point(lblhoten.Location.X, lblhoten.Location.Y + iKhoangDichChuyen);
                qh_hoten.Location = new Point(qh_hoten.Location.X, qh_hoten.Location.Y + iKhoangDichChuyen);
                lbldienthoai.Location = new Point(lbldienthoai.Location.X, lbldienthoai.Location.Y + iKhoangDichChuyen);
                qh_dienthoai.Location = new Point(qh_dienthoai.Location.X, qh_dienthoai.Location.Y + iKhoangDichChuyen);
                lbldiachi.Location = new Point(lbldiachi.Location.X, lbldiachi.Location.Y + iKhoangDichChuyen);
                qh_diachi.Location = new Point(qh_diachi.Location.X, qh_diachi.Location.Y + iKhoangDichChuyen);
            }
            catch { }
        }
        public void load_form()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //
            user = m.user; b701306 = m.Mabv_so == 701306;
            //
            capnhat_db_tiepdon();
            f_load_option();
            //
            bChuphinhtraituyen = m.bChuphinhTraiTuyen;
            
            traituyen.Enabled = bTraituyen;
            traituyen.SelectedIndex = 0;
            CongthucTraiTuyen160212 = m.CongthucTraiTuyen160212;
            MaDangKyKhamBenh = m.MaDangKyKhamBenh();
            ViTriMaDangKyKhamBenh = m.ViTriMaDangKyKhamBenh();

            if (bSothe_dmbhyt) chkBhyt.Checked = m.Thongso("c345") == "1";
            else if (bBHYT_QRCode_Dangky) chkBhyt.Checked = true;
            else chkBhyt.Checked = false;
            bChuphinhct = m.bChupHinhCT;
            tbutChuphinh.Visible = bChuphinhct;
            //mathe.Enabled = bSothe_dmbhyt && chkBhyt.Checked;
            mathe.Enabled = (bSothe_dmbhyt && chkBhyt.Checked) || bBHYT_QRCode_Dangky;
            bTiepdon_ngoaitru = m.bTiepdon_ngoaitru;
            bBHYTNhapCMND = m.bBHYT_NhapCMND;
            bThongtinNguoithan = m.bThongtinNguoithan;
            chkNgoaitru.Visible = bTiepdon_ngoaitru;
            bBhyt1kham = m.bBhyt1kham;
            i_useridvp = m.iUservp;
            lbs.Visible = bDangky_bsbv;
            lbv.Visible = bDangky_bsbv;
            bacsy.Visible = bDangky_bsbv;
            benhvien.Visible = bDangky_bsbv;
            lbbsgioithieu.Visible = bQuanlinvsale;//Thuy 13.03.2013
            txtMaBSGioiThieu.Visible = bQuanlinvsale;
            txtTenBSGioiThieu.Visible = bQuanlinvsale;
            #region cao vu 28/03/2013
            if (bQuanlinvsale)
            {
                int itam = lbldoituong.Location.Y;
                //int itam2 = lbbsgioithieu.Location.Y;
                
                QLNVSale_SapXepControl(23);
                lbbsgioithieu.Location = new Point(lbbsgioithieu.Location.X, itam);
                txtMaBSGioiThieu.Location = new Point(txtMaBSGioiThieu.Location.X, itam);
                txtTenBSGioiThieu.Location = new Point(txtTenBSGioiThieu.Location.X, itam);
                txtMaBSGioiThieu.TabIndex = 6; txtTenBSGioiThieu.TabIndex = 6; 
                listbsgioithieu.TabIndex = 6;

            }
            #endregion
            FileType = m.FileType;
            bGoi = m.bGoi_dangky;
            bIn1lan = m.bIn1lan;
            bThutien_the = m.bThutien_the;
            imavp_the = m.iMavp_the;
            lbienlaithe.Visible = bThutien_the && imavp_the != 0;
            ngaysrv=m.ngayhienhanh_server.Substring(0,10);
            tmn_bienlaikhongdong.Enabled = m.bIn_khambenh || m.bKhongin_tienkham;
            tmn_bienlaikhongdong.Checked = m.Thongso("dangky_inbienlai0dong") == "1" ;            
            pathImage = m.pathImage;
            if (pgoi.Visible = bGoi)
            {
                sonhay.Value = decimal.Parse(m.sonhay.ToString());
                decimal so=m.goidangky(ngaysrv, i_userid);
                if (so != 0)
                {
                    tu.Value = Math.Max(0, so - sonhay.Value+1);
                    den.Value = so;
                }
                else
                {
                    tu.Value = 0; den.Value = 0;
                }
            }
            bMabn_tudong = m.bMabn_tudong_tiepdon;
            bDssothe = m.bDsSothe; i_madoituong_ng = m.iDoituong_ngoaigio;
            bNoigioithieu = m.bNoigioithieu_tiepdon; 
			madstt.Enabled=bNoigioithieu;
			tendstt.Enabled=bNoigioithieu;
            bSothe_mabn = m.bsothe_mabn;
            bHinh = m.bHinh; bChonhinh = m.bChonhinh;
            //
            ////chkChenhlechcongkham.Visible = m.bChenhlech;
            //chkChenhlechcongkham.Visible = false;
            //chkChenhlechcongkham.Checked = m.Thongso("chenhlechcongkham") == "1";
            //
            if (bHinh || bChonhinh)
            {
                dsthe.ReadXml("..//..//..//xml//m_phieudieutri.xml");
                dsthe.Tables[0].Columns.Add("image", typeof(byte[]));
                dsthe.Tables[0].Columns.Add("barcode", typeof(byte[]));
                pathSave = "..//image";
                if (!System.IO.Directory.Exists(pathSave)) System.IO.Directory.CreateDirectory(pathSave);
                else
                {
                    try
                    {
                        string[] files = Directory.GetFiles(pathSave);
                        for (int i = 0; i < files.GetLength(0); i++) File.Delete(files[i].ToString());
                    }
                    catch { }
                }
                setFile();
            }
            sql = "select ten from " + m.user + ".thongso where id=265";
            dthinh = m.get_data(sql).Tables[0];
            if (dthinh.Rows.Count == 0)
            {
                thumuc = "";
            }
            else thumuc = dthinh.Rows[0][0].ToString();
            linthe.Visible = bHinh || bChonhinh;
            chkxml.Visible = bHinh || bChonhinh;
            bThuphi_kham = m.bThuphi_kham;
            if (bDocmavach)
            {
                mabn1.MaxLength = i_maxlength_mabn;
                mabn2.MaxLength = i_maxlength_mabn;
                mabn3.MaxLength = i_maxlength_mabn;
            }
            else
            {
                mabn1.MaxLength = 2;
                mabn2.MaxLength = 2;
                mabn3.MaxLength = 6;
            }
            //Khuong 21/05/2011
			if (bNoigioithieu||m.bTiepdonMoi) //them dieu kien neu la form tiepdon moi cua hepa, neu chon vao check ly do dung tuyen la "chuyen vien" thi hien len
			{
				listdstt.DisplayMember="MABV";
				listdstt.ValueMember="TENBV";
				listdstt.DataSource=m.get_data("select mabv,tenbv,diachi from "+user+".dstt where mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];
			}
			bBangdien=m.bKetxuat_bangdien;
			s_path=m.Path_bangdien;
			if (bBangdien) dsbdien.ReadXml("..//..//..//xml//m_bangdien.xml");
			bLoad_tiepdon=m.bLoad_tiepdon;
			bTungay=m.bBHYT_tungay;
			tungay.Enabled=bTungay;
			bQuan01=m.Mabv_so==701540;
			bDenngay_sothe=m.bDenngay_sothe;
            b_trongngoai=m.bKham_trong_ngoai_gio;
            if (b_trongngoai && m.gio_ngoai != "00:00")
            {
                dtletet = m.get_data("select * from "+user+".letet").Tables[0];
                hh3 = int.Parse(m.sGiobaocao.Substring(0, 2));
                mm3 = int.Parse(m.sGiobaocao.Substring(3, 2));
                hh2 = int.Parse(m.gio_ngoai.Substring(0, 2));
                mm2 = int.Parse(m.gio_ngoai.Substring(3, 2));
                bTudong = true;
                loai.Enabled = false;
            }
            else loai.Enabled = b_trongngoai;
			dsloai.ReadXml("..//..//..//xml//m_loai.xml");
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dsloai.Tables[0];
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];
			bKyhieu_chung=m.bKyhieu_chung;
			bBacsy=m.bBacsy_tiepdon;
			mabs.Visible=bBacsy;
			tenbs.Visible=bBacsy;
			lbacsy.Visible=bBacsy;
			if (bBacsy)
			{
				dtbs=m.get_data("select * from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];
				listBS.DisplayMember="MA";
				listBS.ValueMember="HOTEN";
				listBS.DataSource=dtbs;
			}
            //binh 110711
            if (bChenhlech_laygiaphuthu)
            {
                sql = "select * from " + m.user + ".dmloaitg";
                dtloaitg = m.get_data(sql).Tables[0];
                cmbLoaitg.DataSource = dtloaitg;
                cmbLoaitg.DisplayMember = "ten";
                cmbLoaitg.ValueMember = "id";

                sql = "select * from " + m.user + ".ngaynghi";
                dtngaynghi = m.get_data(sql).Tables[0];

                sql = "select * from " + m.user + ".letet";
                dtngayle = m.get_data(sql).Tables[0];
            }
            //
			pdienthoai.Visible=m.bDienthoai;
			pmien.Visible=m.bLydomien;
			if (m.bLydomien)
			{
				lydomien.DisplayMember="TEN";
				lydomien.ValueMember="ID";
				lydomien.DataSource=m.get_data("select * from "+user+".v_lydomien order by ten").Tables[0];
				duyet.DisplayMember="TEN";
				duyet.ValueMember="MA";
				duyet.DataSource=m.get_data("select * from "+user+".v_dsduyet order by ten").Tables[0];
			}
			bVantay=m.bVantay;
			if (bVantay) bVantay_mabntudong=m.bVantay_mabntudong;
			else bVantay_mabntudong=false;
			ptb.Visible=bVantay;
			tbutvantay.Visible=bVantay;
			dtuser=m.get_data("select * from "+user+".v_dlogin").Tables[0];
			bLuachontienkham=m.bLuachon_tienkham;
			ltienkham.Visible=bLuachontienkham;
			tienkham.Visible=bLuachontienkham;
			matienkham.Visible=bLuachontienkham;
			if (bLuachontienkham)
			{
				tienkham.DisplayMember="TEN";
				tienkham.ValueMember="ID";
			}
			bLydokham=m.bLydokham;
			lydo.Visible=bLydokham;
			llydo.Visible=bLydokham;
			bKhongintienkham=m.bKhongin_tienkham;
			bChuyenkhoasan=m.bChuyenkhoasan;
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			dausinhton.Visible=m.bMach_nhietdo;
			bHonnhan=m.bHonnhan;
			vis_honnhan(bHonnhan);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			tlbl.Text="";
			iChidinh=m.iChidinh;
            //linh
            //barcode.Visible = m.bMavach || bDocmavach;
            if (m.bMavach || bDocmavach)
            {
                //barcode.Visible = true;
                barcode.Text = "07123456";
                dsbarcode.ReadXml("..//..//..//xml//m_bnmoi.xml");
                dsbarcode.Tables[0].Columns.Add("mabn");
                dsbarcode.Tables[0].Columns.Add("hoten");
                dsbarcode.Tables[0].Columns.Add("namsinh");
                dsbarcode.Tables[0].Columns.Add("phai");
                dsbarcode.Tables[0].Columns.Add("diachi");
                dsbarcode.Tables[0].Columns.Add("barcode");
                dsbarcode.Tables[0].Columns.Add("image", typeof(byte[]));
            }
            else barcode.Visible = false;
            //end linh
			butInbarcode.Visible=bDocmavach;
			bAdmin=m.bAdmin(i_userid);
			bSobienlai=m.bSobienlai;
			chkXem.Checked=m.bPreview;
			bSuagiakham=m.bSuagiakham;
			bInkhambenh=m.bIn_khambenh;
			bDanhsach=m.bDanhsach_cho;
			bnmoi.Enabled=m.bMoi_cu;
			i_sokham=m.iSokham;
			bInphieudieutri=m.bPhieudieutri;
            chkDieutri.Visible = bInphieudieutri;
            bKhongChoDKNeuChuaHetNgayCapThuocBHYT = m.bKhongChoDKNeuChuaHetNgayCapThuocBHYT;
            if (bInphieudieutri) chkDieutri.Checked = true;
            if (i_sokham != 3)
            {
                sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
                sovaovien.Enabled = false;
            }
			load_dm();
			phai.SelectedIndex=0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            giovv.Enabled = m.bGiokham;
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			iKhamnhi=m.iTuoi_khamnhi;
			b_Hoten=m.bHoten_gioitinh;
			vis_vienphi(bInkhambenh || bKhongintienkham);
            butIn.Enabled = (bInkhambenh || bInphieudieutri || bHinh || bChonhinh);
            chkXem.Visible = butIn.Enabled;
            dtgia = m.get_data("select * from " + user + ".v_giavp").Tables[0];
            if (bInphieudieutri)
            {
                dsdt.ReadXml("..//..//..//xml//m_phieudieutri.xml");
                DataColumn dc = new DataColumn("cholam", typeof(string));
                dsdt.Tables[0].Columns.Add(dc);
                dc = new DataColumn("kyhieu", typeof(string));
                dsdt.Tables[0].Columns.Add(dc);
                dc = new DataColumn("sobienlai", typeof(string));
                dsdt.Tables[0].Columns.Add(dc);
                dc = new DataColumn("sotien", typeof(decimal));
                dsdt.Tables[0].Columns.Add(dc);
                dc = new DataColumn("mabv", typeof(string));
                dsdt.Tables[0].Columns.Add(dc);
                dc = new DataColumn("tenbv", typeof(string));
                try { dsdt.Tables[0].Columns.Add(dc); }
                catch { }
                dc = new DataColumn("traituyen", typeof(decimal));                
                dsdt.Tables[0].Columns.Add(dc);
            }
			if (bInkhambenh || bKhongintienkham)
			{
				dsxml.ReadXml("..//..//..//xml//v_bienlai.xml");
				dslien.ReadXml("..//..//..//xml//v_lien.xml");
				kyhieu.DisplayMember="SOHIEU";
				kyhieu.ValueMember="ID";
				load_kyhieu();
				kyhieu.SelectedValue=i_sohieu.ToString();
				if (bSuagiakham || bLuachontienkham)
				{
					s_maqu=m.Maqu;				
					load_dongia();
				}
			}			
            try
            {
                if (bInkhambenh || bKhongintienkham)
                {
                    kyhieu.SelectedValue = s_kyhieu.ToString();
                    sobienlai.Text = (bKyhieu_chung) ? m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()), 1).ToString() : dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
                }
            }
            catch { }
            if (bDangky_bsbv)
            {
                dtbv = m.get_data("select ten,ten as stt from " + user + ".dmbvchidinh order by ten").Tables[0];
                listbv.DataSource = dtbv;
                listbv.DisplayMember = "TEN";
                listbv.ValueMember = "TEN";

                dtbs1 = m.get_data("select * from " + user + ".dmbschidinh order by ten,noilamviec ").Tables[0];
                listbs1.DataSource = dtbs1;
                listbs1.DisplayMember = "TEN";
                listbs1.ValueMember = "TEN";
            }
            if (bQuanlinvsale)
            {
                Load_dmbstheodoituong(0);
                
                //listbsgioithieu.ColumnWidths[
            }
            sql = "select * from " + user + ".btdkp_bv where loai=1 and viettat<>'" + makp.Text + "'";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;
            sql += " order by makp";
            dtnkp = m.get_data(sql).Tables[0];
            dtnkp.Columns.Add("chon", typeof(bool));
            dtnkp.Columns.Add("taikham", typeof(bool));
            foreach (DataRow r in dtnkp.Rows)
            {
                r["chon"] = false; r["taikham"] = false;
            }
            dataGrid1.DataSource = dtnkp;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());

            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255, 255, 192));
            this.disabledTextBrush = new SolidBrush(Color.Red);

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            tungay.Text = denngay.Text = ngay1.Text = ngay2.Text = ngay3.Text = "";
            chkView.Checked = m.Thongso("tttiepdon") == "1";
            this.chkLCD.Checked = this.m.Thongso("tdlcd") == "1";
            if (chkView.Checked) load_grid();
            //alterTable();
            ena_quanhe(false);
            butTiep_Click(null,null);
		}

        void Load_dmbstheodoituong(int madt)
        
        {
            try
            {
                dtbsgioithieu = m.get_data("select a.mabs,a.ten,a.manv,b.hoten as nvsale"
                        + ",c.ten as tenvung,a.id,b.id_vung idvung,c.doituong "
                    + " from " + user + ".dmbschidinh a inner join " + user + ".dmbs b on a.manv=b.ma "
                    + " inner join " + user + ".dmvungsale c on b.id_vung=c.id "
                    + " where 1=1 "
                    + ((madt == 0) ? "" : " and c.doituong=" + madt)
                    + " order by ten,a.noilamviec").Tables[0];
                listbsgioithieu.DataSource = dtbsgioithieu;
                listbsgioithieu.DisplayMember = "TEN";
                listbsgioithieu.ValueMember = "id";
                txtMaBSGioiThieu.Text = txtTenBSGioiThieu.Text = "";
                s_mavung = s_manvsale = "";
            }
            catch { }
        }

        //private void alterTable()
        //{
        //    try
        //    {
        //        DataTable temp = m.get_data("select nvienbv from " + m.user + m.mmyy(DateTime.Now.ToString("dd/MM/yyyy")) + ".lienhe where 1=0").Tables[0];
        //    }
        //    catch
        //    {
        //        m.execute_data("alter table "+m.user+m.mmyy(DateTime.Now.ToString("dd/MM/yyyy"))+".lienhe add nvienbv number(1) default 0");
        //    }
        //}

        private void setFile()
        {
            file = pathSave + "//1" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + "."+FileType;
        }

		private void vis_honnhan(bool ena)
		{
             honnhan.Visible=ena;
            //linh
            //lhonnhan.Visible=honnhan.Visible;
		}

		private void vis_vienphi(bool vis)
		{
            label38.Visible = vis;
			lsobienlai.Visible=vis;
			sobienlai.Visible=vis;
			lkyhieu.Visible=vis;
			kyhieu.Visible=vis;
			checkBox1.Visible=vis;
			butKyhieu.Visible=vis;
			dongia.Visible=bSuagiakham || bLuachontienkham;
			dongia.Enabled=bSuagiakham;
		}

		private void load_chidinh()
		{
            /*
			if (iChidinh==4) return;
            sql = "select * from xxx.v_chidinh ";
            if (iChidinh == 1) sql += " where mabn='" + s_mabn + "'";
            else sql += "where maql=" + l_maql;
            chidinh.Checked = m.get_count(nam, sql);
			l_chidinh.ForeColor=(chidinh.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
            */
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
			//foreach(DataRow r in m.get_data("select distinct b.ten from "+user+".diungthuoc a,"+user+".d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) tlbl.Text+=r["ten"].ToString().Trim()+";";
            foreach (DataRow r in m.get_data("select distinct b.ten from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b where a.mahc=b.ma and a.mabn='" + f_get_mabn() + "'").Tables[0].Rows) tlbl.Text += r["ten"].ToString().Trim() + ";";
			//diungthuoc.Checked=tlbl.Text!="";
			//if (diungthuoc.Checked) 
            if (tlbl.Text!="") tlbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
			//l_diungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
			list.DataSource=m.get_data("select mabv,tenbv,diachi from "+user+".dmnoicapbhyt where hide=0 order by mabv").Tables[0];

			listSothe.DisplayMember="SOTHE";
			listSothe.ValueMember="SOTHE";
			if (bDssothe) 
			{
				dtsothe=m.get_data("select a.sothe as st,a.sothe,a.mabv,nullif(b.tenbv,'') as tenbv,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay from "+user+".dmbhyt a left join "+user+".dmnoicapbhyt b using(mabv) order by a.sothe").Tables[0];
				listSothe.DataSource=dtsothe;
			}

			sql="select a.viettat as ma, a.tenkp as hoten, a.* from "+user+".btdkp_bv a where makp<>'01' and loai=1";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_khudt != 0) sql += " and (a.khu=0 or a.khu=" + i_khudt + ")";
            if (i_chinhanh > 0) sql += " and a.chinhanh=" + i_chinhanh;
			sql+=" order by makp";
			dtkp=m.get_data(sql).Tables[0];

			listKP.DisplayMember="MA";
			listKP.ValueMember="HOTEN";
			listKP.DataSource=dtkp;
			//if (tenkp1.Items.Count>0) tenkp1.SelectedIndex=0;
			dtba=m.get_data("select * from "+user+".dmbenhan_bv where loaiba=3 order by maba").Tables[0];
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			tenba.SelectedIndex=0;
			//if (m.Mabv.Length>3) mabn1.Text=m.Mabv_so.ToString();
           

            if (m.Mabv.Length > 3 && i_maxlength_mabn == 8) mabn1.Text = m.Mabv_so.ToString();
            else if (i_maxlength_mabn > 8) mabn1.Text = i_chinhanh.ToString().PadLeft(2, '0');
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);			

			n_makp.DisplayMember="TENKP";
			n_makp.ValueMember="MAKP";

			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
			tendantoc.DataSource=m.get_data("select * from "+user+".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
			tentinh.DataSource=m.get_data("select * from "+user+".btdtt order by matt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
			tennuoc.DataSource=m.get_data("select * from "+user+".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

			sql="select * from "+user+".doituong";
            sql += " where madoituong<>5 ";
			if (s_madoituong!="") sql+=" and madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";            
            sql += " order by madoituong";
			dtdt=m.get_data(sql).Tables[0];
			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			tendoituong.DataSource=dtdt;
			if (tendoituong.SelectedIndex!=-1)
			{
				madoituong.Text=tendoituong.SelectedValue.ToString();
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
                chkNhanvienbv.Enabled = int.Parse(so.Substring(0, 2)) > 0;
				denngay.Enabled=so.Substring(2,1)=="1";
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
                ngay1.Enabled = ngay2.Enabled = ngay3.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                if (ngay2.Enabled && phai.SelectedIndex == 0) ngay2.Enabled = false;
                if (bTraituyen) traituyen.Enabled = mabv.Enabled;
			}
			
			if (bHonnhan)
			{
				dshn.ReadXml("..//..//..//xml//honnhan.xml");
				honnhan.DisplayMember="ten";
				honnhan.ValueMember="ma";
				honnhan.DataSource=dshn.Tables[0];
				if (honnhan.Items.Count>0) honnhan.SelectedIndex=0;
			}
		}

		private void load_tqx()
		{
			tentqx.DataSource=m.Tqx(tqx.Text).Tables[0];
		}

		private void ena_tuoi(bool ena)
		{
			tuoi.Enabled=ena;
			loaituoi.Enabled=ena;
		}

		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void load_quan()
		{
			tenquan.DataSource=m.get_data("select * from "+user+".btdquan where matt='"+tentinh.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") mabn2.Focus();
			else
			{
				if (m.bvodanh(hoten.Text))
				{
					hoten.Text=m.vodanh;
					tuoi.Text=m.vodanh_tuoi.ToString();
					loaituoi.SelectedIndex=0;
					namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
					phai.SelectedIndex=m.vodanh_gioitinh;
					tendantoc.SelectedValue=m.vodanh_dantoc;
					madantoc.Text=tendantoc.SelectedValue.ToString();
					try
					{
						tennn.SelectedValue=m.vodanh_nghenghiep;
					}
					catch{tennn.SelectedIndex=0;}
					mann.Text=tennn.SelectedValue.ToString();
					tentinh.SelectedValue=m.vodanh_tinh;
					load_quan();
					tenquan.SelectedValue=tentinh.SelectedValue.ToString()+"00";
					maqu1.Text=tentinh.SelectedValue.ToString();
					maqu2.Text="00";
					load_pxa();
					tenpxa.SelectedValue=tenquan.SelectedValue.ToString()+"00";
					ngayvv.Focus();
				}
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listKP.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listKP.Visible) listKP.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
		}

		private void tenba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenba.SelectedIndex==-1) tenba.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenba_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				maba.Text=tenba.SelectedValue.ToString();
                this.Text = lan.Change_language_MessageText("Đăng ký khám bệnh") + "< " + lan.Change_language_MessageText("Người cập nhật : ") + s_userid.Trim() + " >";
				DataRow r=m.getrowbyid(dtba,"mavt='"+tenba.SelectedValue.ToString()+"'");
				if (r!=null) i_maba=int.Parse(r[0].ToString());
				else i_maba=0;
			}
			catch{}
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{F4}");
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private bool load_tim_mabn()
		{
			string s_mann=mann.Text;
			load_btdnn(1);
			tennn.SelectedValue=s_mann;
			if (!b_Edit)
			{
				s_ngayvv="";
                s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
				DataTable dt=m.get_Timmabn(hoten.Text.Trim().ToUpper(),ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
                        if (f.m_mabn.Length > 8)
                        {
                            mabn1.Text = f.m_mabn.Substring(2, 2);//chi nhanh
                            mabn2.Text = f.m_mabn.Substring(0, 2);//nam
                            mabn3.Text = f.m_mabn.Substring(4);
                        }
                        else
                        {
                            mabn2.Text = f.m_mabn.Substring(0, 2);
                            mabn3.Text = f.m_mabn.Substring(2);
                        }
                        s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
                        if (barcode.Visible) barcode.Text = s_mabn;
						load_mabn();
						ngayvv.Focus();
						SendKeys.Send("{Home}");
						return true;
					}
				}
			}
			return false;
		}

		private void tennn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennn.SelectedIndex==-1) tennn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ena_nuoc(bool ena)
		{
			manuoc.Enabled=ena;
			tennuoc.Enabled=ena;
		}

		private void tennn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mann.Text=tennn.SelectedValue.ToString();
			}
			catch{mann.Text="";}
		}

		private void tendantoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				madantoc.Text=tendantoc.SelectedValue.ToString();
				if (madantoc.Text=="55") ena_nuoc(true);			
				else
				{
					ena_nuoc(false);
					tennuoc.SelectedValue="VN";
				}
			}
			catch{madantoc.Text="";}
		}

		private void tendantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tendantoc.SelectedIndex==-1) tendantoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennuoc.SelectedIndex==-1) tennuoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				manuoc.Text=tennuoc.SelectedValue.ToString();
			}
			catch{manuoc.Text="";}
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
					cholam.Focus();
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

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//tenkp1.SelectedValue=makp.Text;
                if (makp.Text != "")
                {
                    DataRow r1 = m.getrowbyid(dtkp, "ma='" + makp.Text + "'");
                    if (r1 != null)
                    {
                        tenkp.Text = r1["tenkp"].ToString();
                        //if (i_sokham == 2) sovaovien.Text = m.get_sokham(ngayvv.Text.Substring(0, 10), r1["makp"].ToString(), i_sokham).ToString();
                        if (bSuagiakham || bLuachontienkham) load_dongia();
                        if (bHonnhan) vis_honnhan(!m.kiemtra_khamnhi(r1["makp"].ToString()));
                    }
                    else tenkp.Text = "";
                }                
			}
			catch{}
		}

		private void maba_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenba.SelectedValue=maba.Text;
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void maba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void manuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
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

		private void mann_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennn.SelectedValue=mann.Text;
			}
			catch{}
		}

		private void madantoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendantoc.SelectedValue=madantoc.Text;
			}
			catch{}
		}

		private void manuoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennuoc.SelectedValue=manuoc.Text;
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
			if (e.KeyCode==Keys.Enter)
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
							cholam.Focus();
						}
						catch{}
					}
					else SendKeys.Send("{Tab}{F4}");
				}
			}
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
            string s = mabn2.Text;
            if (bDocmavach)
            {
                if (s.Length == i_maxlength_mabn && i_maxlength_mabn==8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2);

                    mabn3_Validated(sender, e);
                }
                else if (s.Length == i_maxlength_mabn && i_maxlength_mabn > 8)
                {
                    mabn1.Text = s.Substring(2, 2);//chi nhanh
                    mabn2.Text = s.Substring(0, 2);//yy
                    mabn3.Text = s.Substring(4);

                    mabn3_Validated(sender, e);
                }
            }
			mabn2.Text=mabn2.Text.PadLeft(2,'0');
            //mabn3.MaxLength = 6;
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
            if (bVantay) 
            { 
                bVantay_dalan = false;
                loadHinhVanTay(f_get_mabn());// (mabn2.Text + mabn3.Text); 
            }
			bNew=true;
			load_btdnn(0);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
            nam = "";
            v_tienkhambntra = 0; bDacocongkham = false;// gam 26072011
            decimal stt = 0;

            if ((bMabn_tudong || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "" && mabn2.Text != "")
            {
                for (; ; )
                {
                    stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                    //if (i_chinhanh > 0)
                    //{
                    //    mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                    //}
                    //else { mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 2, '0'); }
                    mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                    s_mabn = f_get_mabn();//mabn2.Text + mabn3.Text;
                    if (m.get_data("select mabn from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                }
            }
            else if ((bMabn_tudong_theomay|| bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "")
            {
                if (mabn2.Text == "")
                {
                    mabn2.Focus();
                    return;
                }
                
                for (; ; )
                {
                    //stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                    //mabn3.Text = stt.ToString().PadLeft(6, '0');
                    //s_mabn = mabn2.Text + mabn3.Text;
                    //if (m.get_data("select * from "+user+".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                    iCapso = 0;

                    stt = m.get_mabns(int.Parse(mabn2.Text), 0, 0);
                    if (stt != 0)
                    {
                        //if (i_chinhanh > 0)
                        //{
                        //    mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');//binh 160611
                        //}
                        //else mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');//6,'0');                        
                        mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                        iCapso = 2;
                    }
                    else
                    {
                        
                        //if (i_chinhanh > 0)
                        //{
                        //    mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 4, '0');//(6, '0');//binh 160611
                        //}
                        //else mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 2, '0');//(6, '0'); 
                        mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                        m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                        iCapso = 1;
                    }
                    s_mabn = mabn2.Text + mabn3.Text;
                    if (m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                    else if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                }
                if (barcode.Visible) barcode.Text = s_mabn;
                emp_text(true);
                return;
            }
			else if (mabn3.Text=="") return;
            if (bDocmavach)
            {
                string s = mabn3.Text;
                if (s.Length == 8)//i_maxlength_mabn)
                {
                    mabn2.Text = s.Substring(0,2);
                    mabn3.Text = s.Substring(2);
                }
                else if (s.Length > 8)
                {
                    mabn1.Text = s.Substring(2, 2);//chi nhanh
                    mabn2.Text = s.Substring(0, 2);//yy
                    mabn3.Text = s.Substring(4);
                }
            }
            mabn3.Text = mabn3.Text.PadLeft(6, '0');// mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');//();
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
            if (barcode.Visible) barcode.Text = s_mabn;
            if (mathe.Text == "" && !chkBhyt.Checked) emp_text(true);
            if (load_mabn())
            {
                //
                if (f_kiemtra_bnhantaikham(s_mabn, ngayvv.Text))
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã có hẹn, Bạn có muốn tiếp tục nhập đăng ký không?"), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.No)
                    {
                        butBoqua_Click(null, null);
                        butTiep_Click(null, null);
                        mabn2.Focus();
                        return;
                    }
                }
                if (ngayvv.Text == "")
                {
                    if (load_vv_mabn() && !bAdmin) ena_but(false);
                }
                //
                string s_chuathanhtoan = m.f_ngaychuathanhtoan(s_mabn);
                if (s_chuathanhtoan != "")
                {
                    if (bChuathanhtoan_khongcho_dangkykham)
                    {
                        MessageBox.Show(s_chuathanhtoan);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(s_chuathanhtoan);
                    }
                }

                if (bAdmin && !bDocmavach)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn có sửa thông tin hành chính không ?"), s_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        b_Edit = true;
                        hoten.Focus();
                    }
                    else
                    {
                        ngayvv.Focus();
                        SendKeys.Send("{Home}");
                    }
                }
                else
                {
                    ngayvv.Focus();
                    SendKeys.Send("{Home}");
                }
            }
            else
            {
                if (bVantay && bVantay_batbuot && bVantay_dalan == false)
                {
                    if (bAdmin_hethong)
                    {
                        DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa lăn vân tay."), "Vân tay", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa lăn vân tay, Đề nghị cho Bệnh nhân lăn lại vân tay."), "Vân tay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mabn3.Focus();
                    }
                }
            }
		}

        private bool load_mabn()
		{
            bool btimlai = true;//linh
            bool ret = false;
			foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
                txtCmnd.Text = r["cmnd"].ToString().Trim();
                txtMsThue.Text = r["msthue"].ToString().Trim();
				if (r["ngaysinh"].ToString()!="")
				{
					ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysinh"].ToString()));
					string tuoivao=m.Tuoivao("",ngaysinh.Text);
					tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
					loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				}
				else
				{
					if (namsinh.Text!="") tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
					loaituoi.SelectedIndex=0;
				}
                nam = r["nam"].ToString();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				tennn.SelectedValue=r["mann"].ToString();
				tendantoc.SelectedValue=r["madantoc"].ToString();
				sonha.Text=r["sonha"].ToString();
				thon.Text=r["thon"].ToString();
				cholam.Text=r["cholam"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				ret=true;
                btimlai = false;//linh
                if (pdienthoai.Visible)
				{
					foreach(DataRow r1 in m.get_data("select * from "+user+".dienthoai where mabn='"+s_mabn+"'").Tables[0].Rows)
					{
						dt_nha.Text=r1["nha"].ToString();
						dt_coquan.Text=r1["coquan"].ToString();
						dt_didong.Text=r1["didong"].ToString();
						dt_email.Text=r1["email"].ToString();
					}
				}
                if (bHinh || bChonhinh)
                {
                    bool error = false;
                    try
                    {
                        if (pathImage != "")
                        {
                            error = true;
                            pic.Tag = (System.IO.File.Exists(pathImage + "\\" + s_mabn + "." + FileType)) ? pathImage + "//" + s_mabn + "." + FileType : "0000.bmp";
                            File.Copy(pic.Tag.ToString(), file, true);
                        }
                        else
                        {
                            image = new byte[0];
                            image = (byte[])(r["image"]);
                            memo = new MemoryStream(image);
                            map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(memo));
                            pic.Image = (System.Drawing.Bitmap)map;
                            pic.Tag = image;
                        }
                    }
                    catch
                    {
                        error = true;
                        pic.Tag = "0000.bmp";
                        File.Copy(pic.Tag.ToString(), file, true);
                    }
                    if (error)
                    {
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                        pic.Image = (System.Drawing.Bitmap)map;
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();                        
                        if (pathImage == "") pic.Tag = image;
                    }
                }
				break;
			}
            //linh
            try
            {
                if (!ret && btimlai)
                {
                    string s_sql = "select mabn from " + user + ".btdbn where maphu='" + mabn2.Text + mabn1.Text + mabn3.Text + "'";
                    DataSet dstmp = new DataSet();
                    dstmp = m.get_data(s_sql);
                    //mabn1.MaxLength = 2;
                    //mabn2.MaxLength = 2;
                    //mabn3.MaxLength = 6;
                    if (dstmp != null)
                    {
                        foreach (DataRow rtmp in dstmp.Tables[0].Rows)
                        {
                            string tmp_mabn = rtmp["mabn"].ToString().Trim();
                            if (tmp_mabn != "")
                            {
                                mabn2.Text = tmp_mabn.Substring(0, 2);
                                mabn1.Text = tmp_mabn.Substring(2, 2);
                                mabn3.Text = tmp_mabn.Substring(4);
                                mabn3_Validated(null, null);
                            }
                        }
                    }
                    btimlai = false;
                }
            }
            catch { btimlai = false; }
            //end
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue=r1["id_nuoc"].ToString();
			load_diungthuoc();
            if (bLoadQuanhe_lantruoc || (namsinh.Text.Trim() != "" && m.StringToDateTime(m.Ngaygio_hienhanh).Year - int.Parse(namsinh.Text) < 15)) load_quanhe();
			if (bLoad_tiepdon) load_treeView();
			return ret;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            if (ngayvv.Text == "") return;
			DataRow r1;
            string susermmyy=user+m.mmyy(ngayvv.Text);
			foreach(DataRow r in m.get_data("select a.*, b.paid, b.id from "+susermmyy +".tiepdon a left join "+susermmyy+".v_chidinh b on a.maql=b.maql and a.idchidinh=b.id where a.maql="+l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
				madoituong.Text=r["madoituong"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				r1=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
                makp.Text = r1["viettat"].ToString();
                makp_Validated(null, null);
				//if (r1!=null) tenkp1.SelectedValue=r1["viettat"].ToString();
				if (bHonnhan) vis_honnhan(!m.kiemtra_khamnhi(r["makp"].ToString()));
				sovaovien.Text=r["sovaovien"].ToString();
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
                if (r["done"].ToString()!="c" ||r["idchidinh"].ToString() == r["id"].ToString() || r["idchidinh"].ToString() == "-" + r["id"].ToString())
                {
                    bDadongtienkham = r["paid"].ToString() == "1" || r["done"].ToString() != "c";
                }
                else
                {
                    bDadongtienkham = false;
                }
                l_id=decimal.Parse(r["idchidinh"].ToString());
                if (l_id < 0) l_id = -1 * l_id;
                if (b_Edit==false)//sua thong tin hanh chinh thi  khong load lai tuoi
                {
                    string stuoi = r["tuoivao"].ToString();
                    if (stuoi.Length == 4)
                    {
                        tuoi.Text = stuoi.Substring(0, 3);
                        loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
                    }
                }
                if (bTiepdon_ngoaitru) chkNgoaitru.Checked = int.Parse(r["noitiepdon"].ToString()) == -2;
                if (bDadongtienkham) break;
			}
			load_vv();
			if (skip) load_n_makp(ngayvv.Text+" "+giovv.Text);
		}

		private bool load_vv_mabn()
		{
			l_maql=0;
			emp_vv();
			DataRow r1;
            if (nam == "") return false;
			foreach(DataRow r in m.get_data("select * from "+user+nam.Substring(nam.Length-5,4)+".tiepdon where noitiepdon=0 and mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
                s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				r1=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
                makp.Text = r1["viettat"].ToString();
                makp_Validated(null, null);
				//if (r1!=null) tenkp1.SelectedValue=r1["viettat"].ToString();
				if (bHonnhan) vis_honnhan(!m.kiemtra_khamnhi(r["makp"].ToString()));
				madoituong.Text=r["madoituong"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
                if (bTiepdon_ngoaitru) chkNgoaitru.Checked = int.Parse(r["noitiepdon"].ToString()) == -2;
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
            string xxx = user + m.mmyy(ngayvv.Text);
            foreach (DataRow r in m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0].Rows) 
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
			}
            if (quanhe.Text.Trim() == "")
            {
                DataSet lds_quanhe = m.f_get_quanhe(s_mabn);
                if (lds_quanhe != null && lds_quanhe.Tables.Count > 0)
                {
                    foreach (DataRow r in lds_quanhe.Tables[0].Select("", "maql desc ")) 
                    {
                        quanhe.Text = r["quanhe"].ToString();
                        qh_hoten.Text = r["hoten"].ToString();
                        qh_diachi.Text = r["diachi"].ToString();
                        qh_dienthoai.Text = r["dienthoai"].ToString();
                        break;
                    }
                }
            }
			if (tendoituong.SelectedIndex!=-1)
			{
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".bhyt where maql="+l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						if (bTungay && r["tungay"].ToString()!="")
							tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
						if (so.Substring(3,1)=="1")
						{
							mabv.Text=r["mabv"].ToString();
							try
							{
								tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
							}
							catch{}
						}
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					}
				}
			}
			if (lydo.Visible) lydo.Text=m.get_lydokham(ngayvv.Text+" "+giovv.Text,l_maql);
			if (honnhan.Visible) honnhan.SelectedIndex=m.get_honnhan(ngayvv.Text+" "+giovv.Text,l_maql);
			if (dausinhton.Visible)
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".dausinhton where maql="+l_maql).Tables[0].Rows)
				{
                    mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                    nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                    huyetap.Text = r["huyetap"].ToString();
                    cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    txtNhipTho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                    tinh_bmi();
					break;
				}
			}
			if (bBacsy)
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
                    cholam.Text = r["cholam"].ToString();
					mabs.Text=r["mabs"].ToString();
					DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					break;
				}
			}
            if (bDangky_bsbv)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".tttiepdon where maql=" + l_maql).Tables[0].Rows)
                {
                    benhvien.Text = r["benhvien"].ToString();
                    bacsy.Text = r["bacsy"].ToString();
                    break;
                }
            }
            if (bQuanlinvsale)
            {
                foreach (DataRow r in m.get_data("select a.mabsgioithieu,b.ten,b.manv,c.id_vung idvung,c1.doituong "
                    +" from " + xxx + ".tttiepdon a inner join " + user + ".dmbschidinh b on a.mabsgioithieu=b.mabs "
                    +" left join "+user+".dmbs c on c.ma=b.manv"
                    + " left join " + user + ".dmvungsale c1 on c1.id=c.id_vung"
                    +"where a.maql=" + l_maql).Tables[0].Rows)
                {
                    txtTenBSGioiThieu.Text = r["ten"].ToString();
                    txtMaBSGioiThieu.Text = r["mabsgioithieu"].ToString();
                    s_manvsale = r["manv"].ToString();
                    s_mavung = r["idvung"].ToString();
                    break;
                }
            }
			if (khamthai.Visible)
			{
				bool bFound=false;
				foreach(DataRow r in m.get_data("select * from "+xxx+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
				{
					para1.Text=r["para"].ToString().Substring(0,2);
					para2.Text=r["para"].ToString().Substring(2,2);
					para3.Text=r["para"].ToString().Substring(4,2);
					para4.Text=r["para"].ToString().Substring(6,2);
					if (r["kinhcc"].ToString()!="") kinhcc.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["kinhcc"].ToString()));
					if (r["ngaysanh"].ToString()!="") ngaysanh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysanh"].ToString()));
					dacdiem.Text=r["dacdiem"].ToString();
					bFound=true;
				}
				if (!bFound)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".ttkhamthai where mabn='"+s_mabn+"' order by maql desc").Tables[0].Rows)
					{
						para1.Text=r["para"].ToString().Substring(0,2);
						para2.Text=r["para"].ToString().Substring(2,2);
						para3.Text=r["para"].ToString().Substring(4,2);
						para4.Text=r["para"].ToString().Substring(6,2);
						if (r["kinhcc"].ToString()!="") kinhcc.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["kinhcc"].ToString()));
						if (r["ngaysanh"].ToString()!="") ngaysanh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysanh"].ToString()));
					}
				}
			}
			if (bLuachontienkham || bSuagiakham || pmien.Visible || kyhieu.Visible)
			{
				try
				{
                    string fie = "mavp";
                    if (bnmoi.Enabled) fie = (bnmoi.SelectedIndex == 0) ? "mavp" : "mavptk";
					DataRow r=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
					if (r!=null)
					{
						l_id=0;
						if (bLuachontienkham)
						{
							string s_mucvp=r["mucvp"].ToString().Trim(),s_loaivp=r["loaivp"].ToString().Trim();
							sql="select a.id,a.quyenso,a.sobienlai,b.stt,b.mavp,b.dongia from "+xxx+".v_vienphill a,"+xxx+".v_vienphict b,"+user+".v_giavp c where a.id=b.id and b.mavp=c.id and a.maql="+l_maql;
                            if (imavp_the != 0) sql += " and b.mavp<>" + imavp_the;
							DataTable dttmp=m.get_data(sql).Tables[0];
							if (dttmp.Rows.Count>1)
							{
								string s="";
								decimal st=0;
								foreach(DataRow r1 in dttmp.Select("true","stt"))
								{
									s+=r1[fie].ToString().Trim().PadLeft(7,'0')+",";
									st+=decimal.Parse(r1["dongia"].ToString());
								}
								sql="select distinct id from "+user+".v_trongoi where id_gia in ("+s.Substring(0,s.Length-1)+")";
								int rec=dttmp.Rows.Count,i_mavp=0;
								foreach(DataRow r2 in m.get_data(sql).Tables[0].Rows) 
								{
									sql="select id from "+user+".v_trongoi where id="+int.Parse(r2["id"].ToString());
									if (m.get_data(sql).Tables[0].Rows.Count==rec)
									{
										i_mavp=int.Parse(r2["id"].ToString());
										break;
									}
								}
								if (i_mavp!=0)
								{
									l_id=decimal.Parse(dttmp.Rows[0]["id"].ToString());
									kyhieu.SelectedValue=dttmp.Rows[0]["quyenso"].ToString();
									sobienlai.Text=dttmp.Rows[0]["sobienlai"].ToString();
									load_dongia();
									DataRow r3=m.getrowbyid(dttkham,"id="+i_mavp);
									tienkham.SelectedValue=i_mavp.ToString();
									dongia.Text=st.ToString();
									if (r3!=null) matienkham.Text=r3["ma"].ToString();
								}
							}
							else
							{
								foreach(DataRow r1 in dttmp.Rows)
								{
									l_id=decimal.Parse(r1["id"].ToString());
									kyhieu.SelectedValue=r1["quyenso"].ToString();
									sobienlai.Text=r1["sobienlai"].ToString();
									load_dongia();
									tienkham.SelectedValue=r1[fie].ToString();
									dongia.Text=r1["dongia"].ToString();
									matienkham.Text=r1["ma"].ToString();
								}
							}
						}
						else if (bSuagiakham || kyhieu.Visible)
						{
							l_id=(imavp_the!=0)?m.get_id_vienphi(ngayvv.Text+" "+giovv.Text,l_maql,int.Parse(r[fie].ToString()),v.iNgoaitru):m.get_id_vienphi(l_maql,ngayvv.Text+" "+giovv.Text,v.iNgoaitru);
							if (l_id!=0)
							{
                                sql = "select a.quyenso,a.sobienlai,b.mavp,b.dongia from " + xxx + ".v_vienphill a," + xxx + ".v_vienphict b where a.id=b.id and a.id=" + l_id;
                                //if (imavp_the != 0) sql += " and b.mavp<>" + imavp_the;
								foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
								{
									kyhieu.SelectedValue=r1["quyenso"].ToString();
									sobienlai.Text=r1["sobienlai"].ToString();
									if (bSuagiakham)
									{
										dongia.Text=r1["dongia"].ToString();
										if (madantoc.Text=="55")
										{
											decimal l_dongia=decimal.Parse(dongia.Text)/m.dTygia;
											dongia.Text=l_dongia.ToString();
										}
									}
								}
							}
						}
                        else l_id = (imavp_the != 0) ? m.get_id_vienphi(ngayvv.Text + " " + giovv.Text, l_maql, int.Parse(r[fie].ToString()), v.iNgoaitru) : m.get_id_vienphi(l_maql, ngayvv.Text + " " + giovv.Text, v.iNgoaitru); 
						if (pmien.Visible && l_id!=0)
						{
							foreach(DataRow r1 in v.get_data("select * from "+xxx+".v_mienngtru where id="+l_id).Tables[0].Rows)
							{
								lydomien.SelectedValue=r1["lydo"].ToString();
								duyet.SelectedValue=r1["maduyet"].ToString();
							}
						}
					}
				}
				catch{}
			}
			if (bNoigioithieu)
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".noigioithieu where maql="+l_maql).Tables[0].Rows)
				{
					madstt.Text=r["mabv"].ToString();
					tendstt.Text=m.get_data("select tenbv from "+user+".dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
				}
			}
			//load_tainantt();
            foreach (DataRow r in m.get_data("select * from " + xxx + ".lienhe where maql=" + l_maql).Tables[0].Rows)
            {
                cholam.Text = r["cholam"].ToString();
                try
                {
                    chkNhanvienbv.Checked = (r["nvienbv"].ToString() == "1");
                }
                catch
                {
                    chkNhanvienbv.Checked = false;
                }
                break;
            }
			load_chidinh();
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
			if (!m.bNgay("",ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			try
			{
				string tuoivao=m.Tuoivao("",ngaysinh.Text);
				tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
				loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				namsinh.Text=m.Namsinh(ngaysinh.Text).ToString();
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh && loaituoi.SelectedIndex==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ngaysinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled)
					{
						phai.Focus();
						SendKeys.Send("{F4}");
					}
					else mann.Focus();
				}
                if ((namsinh.Text.Trim() != "" && m.StringToDateTime(m.Ngaygio_hienhanh).Year - int.Parse(namsinh.Text) < 15) || bLoadQuanhe_lantruoc) load_quanhe();
			}
			catch{}
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
                //if (ngaysinh.Text.Trim().Trim('/') != "") return;
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
                tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                loaituoi.SelectedIndex = 0;
                //int ituoi = DateTime.Now.Year - int.Parse(namsinh.Text);
                //if (ituoi > 6)
                //{
                //    tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                //    loaituoi.SelectedIndex = 0;
                //}
                //else
                //{
                //    ituoi = ituoi * 12;
                //    tuoi.Text = ituoi.ToString().PadLeft(3, '0');
                //    loaituoi.SelectedIndex = 1;
                //}
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
					else mann.Focus();
				}
			}
		}

		private void tuoi_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (int.Parse(tuoi.Text)==0) ngaysinh.Focus();
			}
			catch{ngaysinh.Focus();}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				hoten.Text=m.Viettat(hoten.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void thon_Validated(object sender, System.EventArgs e)
		{
            thon.Text = thon.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+');
			thon.Text=m.Caps(thon.Text);
		}

		private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				thon.Text=m.Viettat(thon.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cholam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				cholam.Text=m.Viettat(cholam.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
            cholam.Text = cholam.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+');
			cholam.Text=m.Caps(cholam.Text);		
		}
		//khanh son
		private void lay_mabn_vantay()
		{
            //string tmp_mabn = (mabn3.Text.Trim() != "") ? (mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0')) : "";//(3, '0')) : "";            
            string tmp_mabn = (mabn3.Text.Trim() != "") ? f_get_mabn() : "";//(3, '0')) : "";            
			ma_vantay="";
			//if(fnhandang==null) 
            fnhandang=new FingerApp.FrmNhanDang(ptb);
			fnhandang.ShowDialog();
			ma_vantay=fnhandang.mabn;
            bVantay_dalan = true;
			if(ma_vantay.Length==8  && i_maxlength_mabn==i_maxlength_mabn)
			{
				mabn2.Text=ma_vantay.Substring(0,2);
                mabn3.Text = ma_vantay.Substring(2);//, i_maxlength_mabn-2);
                s_mabn = f_get_mabn();//mabn2.Text+mabn3.Text;
				load_mabn();
				ngayvv.Focus();
				SendKeys.Send("{Home}");
			}
            else if (ma_vantay.Length == i_maxlength_mabn && i_maxlength_mabn == 10)
            {
                mabn2.Text = ma_vantay.Substring(0, 2);//yy
                mabn1.Text = ma_vantay.Substring(2, 2);//Chi nhanh            
                mabn3.Text = ma_vantay.Substring(4);//, i_maxlength_mabn - 2);
                s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
                load_mabn();
                ngayvv.Focus();
                SendKeys.Send("{Home}");
            }
			else
			{
                if (bVantay_mabntudong && tmp_mabn.Trim() == "")
                {
                    decimal maso = m.get_mabn(int.Parse(DateTime.Now.Year.ToString().Substring(2)), 1, 1, true);
                    if (maso != 0)
                    {
                        string ma = DateTime.Now.Year.ToString().Substring(2) + maso.ToString().PadLeft(6, '0'); // maso.ToString().PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
                        if (i_maxlength_mabn > 8) mabn1.Text = i_chinhanh.ToString().PadLeft(2, '0');
                        mabn2.Text = ma.Substring(0, 2);
                        mabn3.Text = ma.Substring(2);//, i_maxlength_mabn - 2);//6);
                        hoten.Text = "";
                        hoten.Focus();
                    }
                }
                else if (tmp_mabn.Trim() != "")
                    return;
                else if (tmp_mabn.Trim() == "")
                {
                    if (i_maxlength_mabn > 8) mabn1.Text = i_chinhanh.ToString().PadLeft(2, '0');
                    mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
                    mabn3.Text = "";
                    mabn2.Focus();
                }
			}
		}
		//khanh son
		private void frmDkkb_chung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F1: if (bGoi) butGoi_Click(sender, e); break;
                case Keys.F3: butTiep_Click(sender, e); break;
                case Keys.F6: if (butLuu.Enabled) { butLuu_Click(sender, e); } break;
                case Keys.F8: butIn_Click(sender, e); break;
				case Keys.F5:
					if (bVantay) lay_mabn_vantay();
					break;
				case Keys.F7:
					l_chidinh_Click(sender,e);
					break;
				case Keys.F9:
					l_makp_Click(sender,e);
					break;
				case Keys.F10:
                    if (lbienlaithe.Visible) lbienlaithe_Click(sender, e);
                    else butKetthuc_Click(sender, e);
					break;
                case Keys.F11:
                    label43_Click(sender, e);
                    break;
                case Keys.F12:
                    linthe_Click(sender, e);
                    break;
			}
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.D:
						l_diungthuoc_Click(sender,e);
						break;
					case Keys.L:
						l_lichhen_Click(sender,e);
						break;
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void madoituong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendoituong.SelectedValue=madoituong.Text;
				if (bSuagiakham || bLuachontienkham) load_dongia();
				if (pmien.Visible) 
				{
					lydomien.Enabled=madoituong.Text!="1" && m.mien_doituong(int.Parse(madoituong.Text),dtdt);
					duyet.Enabled=lydomien.Enabled;
				}
			}
			catch{}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tendoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tendoituong.SelectedIndex==-1) tendoituong.SelectedIndex=0;
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
                chkNhanvienbv.Enabled = int.Parse(so.Substring(0, 2)) > 0;
				denngay.Enabled=so.Substring(2,1)=="1";
				if (bTungay && denngay.Enabled) tungay.Enabled=denngay.Enabled;
				else tungay.Enabled=false;
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
                ngay1.Enabled = ngay2.Enabled = ngay3.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                if (ngay2.Enabled && phai.SelectedIndex == 0) ngay2.Enabled = false;
                if (bTraituyen) traituyen.Enabled = mabv.Enabled;
				SendKeys.Send("{Tab}");
			}
		}

		private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendoituong || sender==null)
			{
                selectedindexchange_tendoituong();
			}
		}
        private void selectedindexchange_tendoituong()
        {
            try
            {
                madoituong.Text = tendoituong.SelectedValue.ToString();
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
                chkNhanvienbv.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                denngay.Enabled = so.Substring(2, 1) == "1";
                if (denngay.Enabled && bTungay) tungay.Enabled = denngay.Enabled;
                else tungay.Enabled = false;
                mabv.Enabled = so.Substring(3, 1) == "1";
                tenbv.Enabled = mabv.Enabled;
                ngay1.Enabled = ngay2.Enabled = ngay3.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                if (ngay2.Enabled && phai.SelectedIndex == 0) ngay2.Enabled = false;
                if (bSuagiakham || bLuachontienkham) load_dongia();
                if (pmien.Visible)
                {
                    lydomien.Enabled = madoituong.Text != "1" && m.mien_doituong(int.Parse(madoituong.Text), dtdt);
                    duyet.Enabled = lydomien.Enabled;
                }
                if (bTraituyen) traituyen.Enabled = mabv.Enabled;
                DataRow drdoituong = m.getrowbyid(dtdt, "madoituong=" + madoituong.Text);
                if (drdoituong != null)
                {
                    try
                    {
                        mnuthongtinbodoi.Enabled = drdoituong["bodoi"].ToString() == "1";
                    }
                    catch { mnuthongtinbodoi.Enabled = false; }
                }
            }
            catch { }
        }
		private void load_bhyt()
		{
            
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (nam == "")
            {
                try
                {                        
                    if (so.Substring(3, 1) == "1" )
                    {
                        if (bXoaTrong_NoiDK_KCB_bandau)
                        {
                            mabv.Text = tenbv.Text = "";
                        }
                        else
                        {
                            if (mabv.Text == "") mabv.Text = m.Mabvbhyt;
                            if (mabv.Text == "") mabv.Text = m.Mabv;
                            tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
                catch { }
                return;
            }
			if (int.Parse(so.Substring(0,2))>0 && ngayvv.Text!="")
			{
                s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
                    sql="select * from xxx.bhyt where mabn='"+s_mabn+"' and denngay>=to_timestamp('"+ngayvv.Text.Substring(0,10)+"','"+m.f_ngay+"') order by maql desc";
				else
					sql="select * from xxx.bhyt where mabn='"+s_mabn+"' order by maql desc";
                DataSet lds = m.get_data_nam_dec(nam, sql);
                if (lds != null && lds.Tables.Count > 0)
                {
                    foreach (DataRow r in lds.Tables[0].Rows)
                    {
                        sothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        if (so.Substring(3, 1) == "1") mabv.Text = r["mabv"].ToString();
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                        break;
                    }
                }
                if (sothe.Text == "")
                {
                    if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                        sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                    else
                        sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' order by maql desc";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        sothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        if (so.Substring(3, 1) == "1") mabv.Text = r["mabv"].ToString();
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                        break;
                    }
                }
				try
				{
					if (so.Substring(3,1)=="1")
					{
						if (mabv.Text=="") mabv.Text=m.Mabvbhyt;
                        if (mabv.Text == "") mabv.Text = m.Mabv;
						tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
					}

				}
				catch{}
			}
			else
			{
				ngay1.Text=ngay2.Text=ngay3.Text=sothe.Text=denngay.Text=tungay.Text="";
				mabv.Text=tenbv.Text="";
			}
		}

		private void quanhe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				quanhe.Text=m.Viettat(quanhe.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter)
			{
				if (quanhe.Text=="")
				{
					if (honnhan.Visible) honnhan.Focus();
					else if (lydo.Visible) lydo.Focus();
					else if (mabs.Visible) mabs.Focus();
					else if (dausinhton.Visible) mach.Focus();
					else if (khamthai.Visible) para1.Focus();
					else if (bLuachontienkham) matienkham.Focus();
					else if (bSuagiakham) dongia.Focus();
					else if (pmien.Visible) lydomien.Focus();
                    else SendKeys.Send("{Tab}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void quanhe_Validated(object sender, System.EventArgs e)
		{
			quanhe.Text=m.Caps(quanhe.Text);
		}

		private void qh_hoten_Validated(object sender, System.EventArgs e)
		{
			qh_hoten.Text=m.Caps(qh_hoten.Text);
		}

		private void qh_hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				qh_hoten.Text=m.Viettat(qh_hoten.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter)
			{
                if (qh_diachi.Text == "") qh_diachi.Text = lan.Change_language_MessageText("Cùng địa chỉ");
				SendKeys.Send("{Tab}");
			}
		}

		private void qh_diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				qh_diachi.Text=m.Viettat(qh_diachi.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}   

		private void qh_diachi_Validated(object sender, System.EventArgs e)
		{
			//qh_diachi.Text=m.Caps(qh_diachi.Text);
		}

		private void denngay_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (sothe.Text != "")
                {
                    denngay.Text = denngay.Text.Trim();
                    if (denngay.Text.Length == 6) denngay.Text = denngay.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(denngay.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        denngay.Focus();
                        return;
                    }
                    denngay.Text = m.Ktngaygio(denngay.Text, 10);
                    if (!m.bNgay(denngay.Text, ngayvv.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày khám bệnh!"), s_msg);
                        denngay.Focus();
                        return;
                    }
                    if (tungay.Text != "")
                    {
                        if (!m.bNgay(denngay.Text, tungay.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!"), s_msg);
                            denngay.Focus();
                            return;
                        }
                    }
                    SendKeys.Send("{Home}");
                }
			}
			catch{}
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
//			if (sothe.Text=="" && !listSothe.Visible) madoituong.Focus();
//			else if (bDssothe)
//			{
//				DataRow r=m.getrowbyid(dtsothe,"sothe='"+sothe.Text+"'");
//				if (r!=null)
//				{
//					tungay.Text=r["tungay"].ToString();
//					denngay.Text=r["denngay"].ToString();
//					mabv.Text=r["mabv"].ToString();
//					tenbv.Text=r["tenbv"].ToString();
//				}
//			}
//			if (listSothe.Visible) listSothe.Hide();
            //
            //Tu:22/08/2011 kiểm tra số thẻ hợp lệ theo qui định của BHYT dựa vào option E28(true)
            traituyen.SelectedIndex = 0;
            if (!m.bKiemtrasothehople(sothe.Text))
            {
                MessageBox.Show("Số thẻ không hợp lệ. Đề nghị kiểm tra kĩ lại !");
                sothe.Focus();
                return;
            }
            //
           
            //
            if (sothe.Text.Trim() != "" && m.bKhactinh_macdinh_la_traituyen)
            {
                try
                {
                    int i_1 = int.Parse(s_vitri_matinh_bhyt.Split(',')[0].ToString());
                    int i_2 = int.Parse(s_vitri_matinh_bhyt.Split(',')[1].ToString());
                    if (sothe.Text.Substring(i_1, i_2) != s_matinh_bhyt)
                    {
                        traituyen.SelectedIndex = 1;
                    }
                }
                catch { traituyen.SelectedIndex = 0; }
            }
            try
            {
                if (sothe.Text.Trim() != "")//gam 20/03/2012
                {
                    int i_1 = int.Parse(ViTriMaDangKyKhamBenh.Split(',')[0].ToString());
                    int i_2 = int.Parse(ViTriMaDangKyKhamBenh.Split(',')[1].ToString());
                    string s_MaNoiDangKy = sothe.Text.Trim().Substring(i_1, i_2);
                    if (s_MaNoiDangKy != MaDangKyKhamBenh)
                    {
                        traituyen.SelectedIndex = 1;
                    }


                }
            }
            catch { }
		}

		private void emp_text(bool skip)
		{
            if (bDocmavach)
            {
                mabn1.MaxLength = i_maxlength_mabn;
                mabn2.MaxLength = i_maxlength_mabn;
                mabn3.MaxLength = i_maxlength_mabn;
            }
            else
            {
                mabn1.MaxLength = 2;
                mabn2.MaxLength = 2;
                mabn3.MaxLength = 6;
            }

			ena_but(true);
			if (!skip)
			{
                if (bQuanLyChiNhanh) mabn1.Text = i_chinhanh.ToString().PadLeft(2, '0');
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
            ptb.Image = null;            
            loaituoi.SelectedIndex = 0;
            mathe.Text = nam = mabs.Text = tenbs.Text = hoten.Text = ngaysinh.Text = "";
            namsinh.Text = tuoi.Text = sonha.Text = thon.Text = "";
            cholam.Text = ma_vantay = dt_nha.Text = dt_coquan.Text = dt_didong.Text = dt_email.Text=txtMsThue.Text=txtCmnd.Text = "";
			tentqx.SelectedIndex=-1;bnmoi.SelectedIndex=0;
            tqx.Text = ""; l_maql = 0; l_id = 0; bDadongtienkham = false; l_matd = 0;
			bNew=true;
			b_Edit=false;
            bVantay_dalan = false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			ref_check();
			load_quan();
			load_pxa();
			emp_vv();
            if (bChenhlech_laygiaphuthu) f_load_doituong_dangky(0);//binh 200711
			emp_bhyt();
			if (bHonnhan) vis_honnhan(bHonnhan);
            if (bHinh || bChonhinh)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                pic.Image = (System.Drawing.Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                if (pathImage == "") pic.Tag = image;
            }
            //
            s_QRcode_sothe = s_QRcode_Hoten = s_QRcode_ngaysinh = s_QRcode_gioitinh = s_QRcode_diachi = s_QRcode_mabv = s_QRcode_tungay = s_QRcode_denngay = s_QRcode_ngaycap = s_QRcode_MaQLBHXH = s_QRcode_KiemTraBHXH = "";
            //
            if (bTiepdon_ngoaitru) chkNgoaitru.Checked = false;
            for (int i = 0; i < n_makp.Items.Count; i++) n_makp.SetItemCheckState(i, CheckState.Unchecked);
            chkNhanvienbv.Checked = false; 
            for (int i = 0; i < chklistDTuutien.Items.Count; i++)
            {
                chklistDTuutien.SetItemChecked(i, false);
            }
		}

        private void emp_bhyt()
		{
			ngay1.Text=ngay2.Text=ngay3.Text=sothe.Text="";
			denngay.Text=tungay.Text=mabv.Text=tenbv.Text="";
		}

		private void emp_vv()
		{
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            traituyen.SelectedIndex = 0;
            s_ngayvv =  bacsy.Text =  benhvien.Text = madoituong.Text="";
			tendoituong.SelectedIndex=-1;
            quanhe.Text = qh_hoten.Text = qh_diachi.Text = qh_dienthoai.Text = sovaovien.Text = para1.Text = "";
            para2.Text = para3.Text = para4.Text = kinhcc.Text = ngaysanh.Text = dacdiem.Text = lydo.Text = madstt.Text = tendstt.Text = "";
			if (honnhan.Items.Count>0) honnhan.SelectedIndex=0;
            mach.Text = nhietdo.Text = huyetap.Text = cannang.Text = chieucao.Text = bmi.Text = txtNhipTho.Text = "";
            txtMaBSGioiThieu.Text = "";
            txtTenBSGioiThieu.Text = "";
            //cbbvungsale.SelectedIndex = 0;
            s_manvsale = "";
            s_mavung = "";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
        {
            mathe.Enabled = bBHYT_QRCode_Dangky || (bSothe_dmbhyt && chkBhyt.Checked);
            if (bDocmavach)
            {
                mabn1.MaxLength = i_maxlength_mabn;
                mabn2.MaxLength = i_maxlength_mabn;
                mabn3.MaxLength = i_maxlength_mabn;
            }
            else
            {
                mabn1.MaxLength = 2;
                mabn2.MaxLength = 2;
                mabn3.MaxLength = 6;
            }
            v_tienkhambntra = 0;// gam 26072011
			try
			{
				if (bInkhambenh || bKhongintienkham)
				{
					kyhieu.SelectedValue=s_kyhieu.ToString();
					sobienlai.Text=(bKyhieu_chung)?m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),1).ToString():dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
				}
			}
			catch{}
            if (bHinh || bChonhinh)
            {
                pathSave = "..//image";
                if (!System.IO.Directory.Exists(pathSave)) System.IO.Directory.CreateDirectory(pathSave);
                if (!System.IO.File.Exists(file)) setFile();
            }

            //fnhandang = null;
			emp_text(false);
            madoituong.Enabled = tendoituong.Enabled = true;
            if (chkView.Checked) load_grid();
            if (bSothe_dmbhyt && chkBhyt.Checked) mathe.Focus();
            else mabn2.Focus(); 
            if ((bSothe_dmbhyt && chkBhyt.Checked) || bBHYT_QRCode_Dangky) mathe.Focus();
            else mabn2.Focus();

		}

		public bool kiemtra()
		{

			DataRow r1;
            if (!bNhapdaydu)//Dung trong form tiepdon moi cua hepa
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập nơi giới thiệu !"), s_msg);
                tendstt.Focus();
                return false;
            }
            
            if (mabn2.Text == "" || mabn3.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"), s_msg);
                mabn2.Focus();
                return false;
            }
            else
            {
                if (i_maxlength_mabn > 8) mabn1.Text = mabn1.Text.PadLeft(2, '0');
                mabn2.Text = mabn2.Text.PadLeft(2, '0');
                mabn3.Text = mabn3.Text.PadLeft(6, '0');//(i_maxlength_mabn-2, '0');//(2, '0');
            }
            if (makp.Text == "" || tenkp.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"), s_msg);
                tenkp.Focus();
                return false;
            }
            //Thuy 20.08.2012
            DataRow r0 = m.getrowbyid(dtkp, "viettat='" + makp.Text+"'");
            if (bChenhlechPK_chitinh_vaongaynghi)
            {
                chkChenhlechcongkham.Checked = m.bNgaynghi(ngayvv.Text.Substring(0, 10));
            }
            else if (r0["phongdv"].ToString()=="1")
            {
                chkChenhlechcongkham.Checked = true;
            }
            
            if (bVantay && bVantay_batbuot && bVantay_dalan == false)
            {
                if (bAdmin_hethong)
                {
                    DialogResult dlg= MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa lăn vân tay, bạn có muốn cho Bệnh nhân lấy lại vân tay không?")+"\n"+"Kích YES, Bệnh nhân lăn lại vân tay.\nKích NO, tiếp tục nhập", "Vân tay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlg == DialogResult.Yes) return false;
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa lăn vân tay, Đề nghị cho Bệnh nhân lăn lại vân tay."),"Vân tay",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    butBoqua_Click(null, null);

                    return false;
                }
            }

			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
				return false;
			}

			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngaysinh.Focus();
				return false;
			}

            //Benh nhan duoi 6 tuoi bat buoc nhap thong tin nguoi than
            try
            {
                if (bThongtinNguoithan && (quanhe.Text.Trim() == "" || qh_hoten.Text.Trim() == "") && int.Parse(ngaysrv.Substring(6, 4)) - int.Parse(namsinh.Text.Trim()) <= 6)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập thông tin người thân !"), s_msg);
                    if (quanhe.Text.Trim() == "")
                        quanhe.Focus();
                    else
                        qh_hoten.Focus();
                    return false;
                }
            }
            catch { MessageBox.Show(lan.Change_language_MessageText("Nhập năm sinh !"), s_msg); return false; }
			if (tennuoc.Enabled)
			{
				if (tennuoc.SelectedValue.ToString()=="VN" && tendantoc.SelectedValue.ToString()=="55")
				{
					MessageBox.Show(lan.Change_language_MessageText("Quốc tịch không hợp lệ !"),LibMedi.AccessData.Msg);
					tennuoc.Focus();
					return false;
				}
			}

			if (b_Hoten)
			{
				if ((hoten.Text.Trim().IndexOf(" VĂN ")!=-1 && phai.SelectedIndex==1) || (hoten.Text.Trim().IndexOf(" THỊ ")!=-1 && phai.SelectedIndex==0))
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên và giới tính không hợp lệ !"),LibMedi.AccessData.Msg);
					if (phai.Enabled) phai.Focus();
					else hoten.Focus();
					return false;
				}
			}

			if (tuoi.Text=="" || loaituoi.SelectedIndex==-1)
			{
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
			}

            if (loaituoi.SelectedIndex == 0 && tuoi.Text!="")
            {
                if (int.Parse(tuoi.Text) > m.iTuoi_nguoibenh)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"), LibMedi.AccessData.Msg);
                    if (ngaysinh.Text != "") ngaysinh.Focus();
                    else namsinh.Focus();
                    return false;
                }
            }
			if (ngayvv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào khám bệnh !"),s_msg);
				ngayvv.Focus();
				return false;
            }
            
            if (mnquanlihinhanhbn.Checked && bDacohinh == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa chụp hình Bệnh nhân. Đề nghị chụp hình trước khi lưu!"), s_msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label43_Click(null, null);
                if (bDacohinh == false)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không chụp hình thì không cho lưu thông tin đăng ký khám."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

			if (madoituong.Text=="" || tendoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập đối tượng !"),s_msg);
				tendoituong.Focus();
				return false;
			}
			else
			{
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
					if (sothe.Text=="")
					{
						sothe.Focus();
						return false;
					}
                    else if (m.kiemtra_sothe(sothe.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ không hợp lệ !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                    if (bTungay && so.Substring(2, 1) == "1")
                    {
                        if (tungay.Text.Trim().Length != 10)
                        {
                            tungay.Focus();
                            return false;
                        }
                        if (!m.bNgay(ngayvv.Text, tungay.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu phải nhỏ hơn ngày khám bệnh!"), s_msg);
                            tungay.Focus();
                            return false;
                        }
                    }
                    if (so.Substring(2, 1) == "1")
                    {
                        if (denngay.Text == "")
                        {
                            denngay.Focus();
                            return false;
                        }
                        if (!m.bNgay(denngay.Text, ngayvv.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày khám bệnh!"), s_msg);
                            denngay.Focus();
                            return false;
                        }
                    }
					if (so.Substring(3,1)=="1" && (mabv.Text=="" || tenbv.Text==""))
					{
						tenbv.Focus();
						return false;
					}
					if (so.Substring(3,1)=="1")
					{
						if (m.get_data("select * from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows.Count==0)
						{
							mabv.Text="";
							tenbv.Focus();
							return false;
						}
					}
                    if (!m.sothe(int.Parse(tendoituong.SelectedValue.ToString()), sothe.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
				}
			}

			if (mann.Text=="" || tennn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
				mann.Focus();
				return false;
			}

			if (tentinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"),s_msg);
				tentinh.Focus();
				return false;
			}

			if (tenquan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),s_msg);
				tenquan.Focus();
				return false;
			}

			if (tenpxa.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"),s_msg);
				tenpxa.Focus();
				return false;
			}

			if (madantoc.Text=="" || tendantoc.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn dân tộc !"),s_msg);
				tendantoc.Focus();
				return false;
			}

			if (tennuoc.SelectedIndex==-1 && tennuoc.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quốc tịch !"),s_msg);
				tennuoc.Focus();
				return false;
			}

			if (namsinh.Text!="" && mann.Text!="")
			{
				if (!m.Kiemtra_mann(mann.Text,DateTime.Now.Year-int.Parse(namsinh.Text),iTreem6,iTreem15))
				{
					MessageBox.Show(lan.Change_language_MessageText("Nghề nghiệp và độ tuổi không hợp lệ !"),LibMedi.AccessData.Msg);
					mann.Focus();
					return false;
				}
			}
			if (namsinh.Text!="" && makp.Text!="")
			{
				if (DateTime.Now.Year-int.Parse(namsinh.Text)>iKhamnhi)
				{
					r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
					if (r1!=null)
					{
						if (m.kiemtra_khamnhi(r1["makp"].ToString()))
						{
							MessageBox.Show(lan.Change_language_MessageText("Độ tuổi và phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
							makp.Focus();
							return false;
						}
					}
				}
			}

            if (cholam.Text == "")
            {
                r1 = m.getrowbyid(dtdt, "cholam=1 and madoituong=" + int.Parse(madoituong.Text));
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng")+" "+ tendoituong.Text.Trim() + lan.Change_language_MessageText(" yêu cầu nhập nơi làm việc !"), s_msg);
                    cholam.Focus();
                    return false;
                }
            }
            if (chkTrungcao.Checked && thetrungcao.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập thẻ trung cao!"), s_msg);
                thetrungcao.Enabled=true;
                thetrungcao.Focus();
                return false;
            }
            if (ngaysinh.Text.Trim().Length!=10)
            {
                r1 = m.getrowbyid(dtdt, "ngaysinh=1 and madoituong=" + int.Parse(madoituong.Text));
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng") + " " + tendoituong.Text.Trim() + lan.Change_language_MessageText(" yêu cầu nhập ngày sinh !"), s_msg);
                    ngaysinh.Focus();
                    return false;
                }
            }
            //
            //
            if (bNew)
            {
                string s_chuathanhtoan = m.f_ngaychuathanhtoan(s_mabn);
                if (s_chuathanhtoan != "")
                {
                    if (bChuathanhtoan_khongcho_dangkykham)
                    {
                        MessageBox.Show(s_chuathanhtoan+"\nĐề nghị Bệnh nhân đi thanh toán, trước khi đăng ký khám");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(s_chuathanhtoan);
                    }
                }
            }
            //
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
			r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
				makp.Focus();
				return false;
			}
            //
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
            //if (i_sokham == 2 && bNew)
            //{
                //sovaovien.Text = m.get_sokham(ngayvv.Text.Substring(0, 10), r1["makp"].ToString(), i_sokham).ToString();
            //    sovaovien.Text = m.get_sokham(r1["makp"].ToString()).ToString(); //m.get_sokham(ngayvv.Text.Substring(0, 10), r1["makp"].ToString(), i_sokham).ToString(); 
            //}
            //
            if (m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text) == 0)
            {
                if (m.bTuvong(f_get_mabn()))//(mabn2.Text + mabn3.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                    return false;
                }
            }
            //
			l_maql=m.get_maql_tiepdon(s_mabn,ngayvv.Text+" "+giovv.Text);
            //l_matd = m.get_maql_tiepdon_ngay(s_mabn, ngayvv.Text);
            //
            if (bTiepdon_nkp_inchungchiphi) l_matd = m.get_maql_tiepdon_ngay(s_mabn, ngayvv.Text);
            else l_matd = l_maql;
            if (l_matd == 0) l_matd = l_maql;
            //if (l_maql == 0)
            //{
                string s1 = "";
                sql = "select b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".hiendien a," + user + ".btdkp_bv b," + user + ".benhandt c where a.maql=c.maql and a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and c.loaiba=1";
                sql += " and a.mabn='" + s_mabn + "'";
                if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    s1 = "ĐANG ĐIỀU TRỊ TẠI " + r["tenkp"].ToString().Trim().ToUpper() + " NGÀY " + r["ngay"].ToString();
                    break;
                }
                if (s1 != "")
                {
                    MessageBox.Show(s1 + "\nKhông cho phép đăng ký !", LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                    return false;
                }
                if (bBhyt1kham && madoituong.Text == "1")
                {
                    s1 = m.get_khambhyt(s_mabn, ngayvv.Text+" "+giovv.Text, l_maql);
                    if (s1 != "")
                    {
                        MessageBox.Show(s1, LibMedi.AccessData.Msg);
                        madoituong.Focus();
                        return false;
                    }
                }
            //}
            //else 
            if (bIn1lan)
            {
                if (m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where maql=" + l_maql).Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã in biên lai, không cho phép thay đổi !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            else if (!bThuphi_kham)
            {
                if (m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where maql=" + l_maql + " and done <> 'c'").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh !"), LibMedi.AccessData.Msg);
                    butTiep.Focus();
                    return false;
                }
            }
			if (pmien.Visible && madoituong.Text!="1")
			{
				if (m.mien_doituong(int.Parse(madoituong.Text),dtdt))
				{
					if (lydomien.SelectedIndex==-1 || duyet.SelectedIndex==-1)
					{
						if (lydomien.SelectedIndex==-1) lydomien.Focus();
						else duyet.Focus();
						return false;
					}
				}
			}
            if (kyhieu.SelectedIndex == -1 && kyhieu.Visible==true)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn kí hiệu!"), LibMedi.AccessData.Msg);
                kyhieu.Focus();
                return false;
            }
			if (bInkhambenh || bKhongintienkham || bLuachontienkham)
			{
				DataRow r=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
				if (r!=null)
				{
                    string fie = "mavp";
                    if (bnmoi.Enabled) fie = (bnmoi.SelectedIndex == 0) ? "mavp" : "mavptk";
					int i_mavp=(bLuachontienkham)?int.Parse(tienkham.SelectedValue.ToString()):int.Parse(r[fie].ToString());
                    l_id = (imavp_the != 0) ? m.get_id_vienphi(ngayvv.Text + " " + giovv.Text, l_maql, i_mavp, v.iNgoaitru) : m.get_id_vienphi(l_maql, ngayvv.Text + " " + giovv.Text, v.iNgoaitru); 
					if (l_id==0)
					{
						sobienlai.Text=m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),1).ToString();
						if (bSobienlai)
						{
							int so=int.Parse(sobienlai.Text);
							//if (n_makp.Visible) for(int i=0;i<n_makp.Items.Count;i++) if (n_makp.GetItemChecked(i)) so+=1;
                            if (pnmakp.Visible)
                                foreach (DataRow rk in dtnkp.Select("chon=true", "makp")) so += 1;
							if (!m.kiemtra_bienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),so))
							{
								MessageBox.Show(lan.Change_language_MessageText("Số biên lai vượt quá trong khoản từ : ")+dtkh.Rows[kyhieu.SelectedIndex]["tu"].ToString()+" đến : "+dtkh.Rows[kyhieu.SelectedIndex]["den"].ToString(),LibMedi.AccessData.Msg);
								kyhieu.Focus();
								return false;
							}
						}
					}
				}
			}
			if (khamthai.Visible)
			{
				if (phai.SelectedIndex==0 && (para1.Text+para2.Text+para3.Text+para4.Text!="" || kinhcc.Text!="" || ngaysanh.Text!="" || dacdiem.Text!=""))
				{
					MessageBox.Show(lan.Change_language_MessageText("Giới tính không hợp lệ !"),s_msg);
					phai.Focus();
					return false;
				}
				if (kinhcc.Text!="" && ngaysanh.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),s_msg);
					if (kinhcc.Text=="") kinhcc.Focus();
					else ngaysanh.Focus();
					return false;
				}
			}
			if (loai.Enabled)
			{
				if (loai.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Khám !"),LibMedi.AccessData.Msg);
					return false;
				}
			}
			else loai.SelectedIndex=0;
            if (bNoigioithieu)
            {
                if ((madstt.Text == "" && tendstt.Text != "") || (madstt.Text != "" && tendstt.Text == ""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập nơi giới thiệu !"), s_msg);
                    madstt.Focus();
                    return false;
                }
            }
            if (bSothe_dkkcb)
            {
                if (sothe.Text.Trim().Length == _dai && _vitri != 0 && _sothe != "")
                {
                    if (sothe.Text.Substring(_vitri - 1, _sothe.Length) != mabv.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ không hợp lệ so với Mã ĐKKCB !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = m.mabn_bhyt_ngayhethan(nam, mabn2.Text + mabn3.Text, sothe.Text,denngay.Text); // m.mabn_bhyt(nam, mabn2.Text + mabn3.Text, sothe.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ ")+" " + sothe.Text + "\n "+lan.Change_language_MessageText("Đã có mã người bệnh :") + s + "\n"+lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }

            if (bBHYTNhapCMND && txtCmnd.Text.Trim() == "" && int.Parse(tendoituong.SelectedValue.ToString()) == 1 && m.bDienthoai && !(sothe.Text.IndexOf("TE") > -1 && sothe.Text.IndexOf("HS") > -1))
            {
                MessageBox.Show(lan.Change_language_MessageText("Bắt buộc nhập CMND đối với bệnh nhân BHYT !"), s_msg);
                txtCmnd.Focus();
                return false;
            }

            if (bNgoaitru_k_khambenh)
            {
                string s_tenkp = m.bHiendien(s_mabn, 2);
                if (s_tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                    butBoqua.Focus();
                    return false;
                }
            }
            else if (bTiepdon_ngoaitru)
            {
                if (chkNgoaitru.Checked)
                {
                    string s_tenkp = m.bHiendien(s_mabn, 2);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        butBoqua.Focus();
                        return false;
                    }
                    else
                    {
                        s_tenkp = m.bNhapvien(s_mabn, 2);
                        if (s_tenkp != "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                            butBoqua.Focus();
                            return false;
                        }
                    }
                }
            }

            bool bExit = false;
            decimal d_songay = 0;
            string ngay_cap = "", s_ngay = ngayvv.Text.Substring(0, 10);
            sql = "select songay,to_char(ngay,'dd/mm/yyyy') as ngay,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.d_thuocbhytll where mabn='" + s_mabn + "'";// and madoituong=" + madoituong.Text ;
            sql += " and ngay<to_timestamp('" + s_ngay.Substring(0, 10) + "','" + d.f_ngay + "')";
            sql += " order by ngay desc";
            foreach (DataRow r in d.get_thuoc(s_ngay, s_ngay, sql).Tables[0].Select("true", "yyyymmdd desc"))
            {
                ngay_cap = r["ngay"].ToString();
                d_songay = decimal.Parse(r["songay"].ToString());
                if (d_songay > 0) bExit = Math.Abs(m.songay(m.StringToDate(s_ngay.Substring(0, 10)), m.StringToDate(r["ngay"].ToString()), 0)) < d_songay;
                break;
            }
            if (bExit)
            {
                if (bKhongChoDKNeuChuaHetNgayCapThuocBHYT == true && bAdmin)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Ngày") + " " + ngay_cap + " " + lan.Change_language_MessageText("cấp đơn thuốc") + " " + d_songay.ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + "\n" + lan.Change_language_MessageText("Bạn có muốn cho Bệnh nhân đăng ký khám tiếp không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return false;
                }
                else if (bKhongChoDKNeuChuaHetNgayCapThuocBHYT == true && !bAdmin)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày") + " " + ngay_cap + " " + lan.Change_language_MessageText("cấp đơn thuốc") + " " + d_songay.ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + "\n" + lan.Change_language_MessageText("Vui lòng liên hệ Admin vì bạn không có quyền đăng ký người bệnh này!"), s_msg);
                    return false;
                }
                else
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Ngày") + " " + ngay_cap + " " + lan.Change_language_MessageText("cấp đơn thuốc") + " " + d_songay.ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + "\n" + lan.Change_language_MessageText("Bạn có muốn cho Bệnh nhân đăng ký khám tiếp không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return false;
                }
            }
            //kiem tra bn xuat khoa trong ngay ko cho dki kham benh trong ngay vi bhyt ko chi tra 2 lần dk khám trong ngày
            if (madoituong.Text == "1")
            {
                sql = "select mabn from " + user + ".xuatvien where mabn='" + s_mabn + "' and to_timestamp(to_char(ngay,'" + d.f_ngay + "'),'" + d.f_ngay + "') = to_timestamp('" + s_ngay.Substring(0, 10) + "','" + d.f_ngay + "')";
                DataTable dttemp = m.get_data(sql).Tables[0];
                if (dttemp.Rows.Count > 0)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này mới ra viện trong ngày, bạn có muốn cho Bệnh nhân tiếp tục đăng kí khám không?") + "\n", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlg == DialogResult.No) return false;
                }
            }

            if  ( bnKhamBHYTmotlantrongngay&& madoituong.Text == "1")
            {
                int i_dakham = f_kiemtrabndakhamtrongngay(s_mabn, ngayvv.Text);
                if (i_dakham == 1)
                {
                    MessageBox.Show("Bệnh nhân vừa mới khám xong không cho đăng ký  BHYT thêm. Muốn khám thêm thì phải chuyển sang thu phí  ");
                    return false;
                }
                else if (i_dakham == 2)
                {
                    MessageBox.Show("Bệnh nhân vừa mới ra viện trong ngày( hay chưa ra) không cho đăng ký BHYT thêm. Muốn khám thêm thì phải chuyển sang thu phí  ");
                    return false;
                }




            }
			return true;
		}
		//moi them 14/1/2006 khanh son
		private void loadHinhVanTay(string mabn)
		{
            ptb.Image = null;
			if(fnhandang==null) fnhandang=new FingerApp.FrmNhanDang(ptb);
			ptb.Image=fnhandang.getImageFromMabn(mabn);
            //if (ptb.Image == null && bVantay_batbuot)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa lấy dấu vân tay");
            //}
            //else
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã lấy dấu vân tay");
            //}
		}

		private void luu_vantay()
		{
			try
			{
                string ma = f_get_mabn();// mabn2.Text + mabn3.Text;
				fnhandang.save_orac(ma);
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            bDacocongkham = f_b_dacocongkham(s_mabn, l_maql.ToString(), ngayvv.Text + giovv.Text, makp.Text);//gam 12/01/2012
			if (bVantay && ma_vantay=="") luu_vantay();
            //if (bVantay && ptb.Image != null) luu_vantay();
            if (!kiemtra()) { bKiemtra = false; return; }
            //
            if(bChenhlech_laygiaphuthu) f_get_tronggio_ngoaigio();
            //
            string zzz=user+m.mmyy(ngayvv.Text);
			if (i_sokham!=3 && makp.Text!="" && bNew)
			{
				DataRow r2=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
                if (r2 != null) //sovaovien.Text=m.get_sokham(ngayvv.Text.Substring(0,10),r2["makp"].ToString(),i_sokham).ToString();
                {
                    sovaovien.Text = m.get_sokham((i_sokham == 1) ? "01" : r2["makp"].ToString()).ToString();
                }
			}
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text.Trim('-').Trim('+'), thon.Text.Trim('-').Trim('+'), cholam.Text.Trim('-').Trim('+'), matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            m.upd_btdbn(s_mabn,txtCmnd.Text.Trim(),txtMsThue.Text.Trim());            
            if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
            if(mnquanlihinhanhbn.Checked && bChupHinhBN) //(bHinh || bChonhinh)
            {
                try
                {
                    Bitmap b = (Bitmap)pic.Image;
                    b.Save(thumuc + s_mabn + "." + m.FileType);
                    //File.Copy("temp\\" + s_mabn + "." + m.FileType, thumuc+ s_mabn + "." + m.FileType, true);
                }
                catch// (Exception exx)
                {
                    //MessageBox.Show(lan.Change_language_MessageText("Lỗi đường dẫn thư mục hình ảnh!"), s_msg);
                }
            }
            if (mnquanlihinhanhbn.Checked && bChupHinhBN)//if (bHinh || bChonhinh)
            {
                if (pathImage != "")
                {
                    try
                    {
                        if (System.IO.Directory.Exists(pathImage))
                        {
                            if (!System.IO.File.Exists(pathImage + "//" + s_mabn + "." + FileType))
                                System.IO.File.Copy(file, pathImage + "//" + s_mabn + "." + FileType, true);
                        }
                    }
                    catch { }
                }
                else m.upd_btdbn_image(s_mabn, (byte[])(pic.Tag));
            }
            /*
            if (bDocmavach)
            {
                if (!System.IO.Directory.Exists("..//barcode")) System.IO.Directory.CreateDirectory("..//barcode");
                barcode.Picture.Save("..//barcode//barcode.bmp");
                pBarcode.Tag = "..//barcode//barcode.bmp";
                fstr = new System.IO.FileStream(pBarcode.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new Bitmap(Image.FromStream(fstr));
                pBarcode.Image = (Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                pBarcode.Tag = image;
                //m.upd_btdbn_barcode(s_mabn, (byte[])(pBarcode.Tag));
            }
            */
			if (!m.upd_lienhe(ngayvv.Text,l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            //Tu:28/06/2011 soluutru tang tu dong neu check option D28
            if (m.bSoluutruPK_PL_NGT_tudong)
            {
                string s_mmyy = "";
                s_mmyy = DateTime.Now.Year.ToString().Substring(2,2) + DateTime.Now.Month.ToString().PadLeft(2,'0');
                decimal l_idluutru = m.get_capid(200, s_mmyy);
                s_soluutru = i_chinhanh.ToString().PadLeft(2,'0') + s_mmyy + l_idluutru.ToString().PadLeft(6,'0');
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            }
            //end Tu
            if (!bNew)
            {
                string s_xxx=user+m.mmyy(ngayvv.Text.Substring(0,10));
                decimal l_mavv = m.get_mavaovien(l_maql);
                if (l_mavv != 0)
                {
                    sql = "select maql from " + user + ".sukien where matiepdon=" + l_mavv;
                    DataSet lds = m.get_data(sql);
                    if (lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
                        m.f_upd_tuoivao(lds.Tables[0].Rows[0]["maql"].ToString(), tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedValue.ToString());
                    //
                    sql = "update " + s_xxx + ".lienhe set tuoivao='" + tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString() + "' where maql in(select maql from " + s_xxx + ".benhanpk where mavaovien=" + l_mavv + ")";
                    m.execute_data(sql);
                }
            }
            //
            if (honnhan.Visible && honnhan.SelectedIndex != -1) m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".lienhe set honnhan=" + honnhan.SelectedIndex + " where maql=" + l_maql);
			if (bBacsy && mabs.Text!="") m.execute_data("update "+user+m.mmyy(ngayvv.Text)+".lienhe set mabs='"+mabs.Text+"' where maql="+l_maql);
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
            int itable = m.tableid(m.mmyy(ngayvv.Text), "tiepdon");
            bool bnew = true;
            if (m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd",m.fields(zzz+".tiepdon","maql="+l_maql));
                bnew = false;
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            if (!m.upd_tiepdon(s_mabn,l_matd, l_maql, r1["makp"].ToString(), ngayvv.Text+" "+giovv.Text, int.Parse(tendoituong.SelectedValue.ToString()), (sovaovien.Text=="")?"0":sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex,(bTiepdon_ngoaitru)?(chkNgoaitru.Checked)?-2:0:0, loai.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"),s_msg);
				return;
			}

            //Tu:20/08/2011
            DataRow dr_kk = m.getrowbyid(m.get_data("select makp,tenkp from " + user + ".btdkp_bv a," + user + ".v_giavp b where a.mavp=b.id and b.gia_th=0 and b.gia_dv=0").Tables[0], "makp='" + makp.Text.Trim() + "'");
            //end Tu
            if (CongthucTraiTuyen160212 && traituyen.SelectedIndex != 0 && m.StringToDate(ngayvv.Text.Substring(0,10)) >= m.StringToDate("15/02/2012"))//gam 16/02/2012
            {
                sql = "update " + m.user + m.mmyy(ngayvv.Text) + ".tiepdon set done='c' ";
                sql += " where mavaovien=" + l_matd + " and maql=" + l_maql;
            }
            else
            {
                sql = "update " + m.user + m.mmyy(ngayvv.Text) + ".tiepdon set ";
                if (dr_kk != null || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")//Tu: 20/08/2011
                    sql += " done=null ";
                else sql += " done='c' ";
                sql += " where mavaovien=" + l_matd + " and maql=" + l_maql;
            }
            if (!m.execute_data(sql))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                return;
            }
            
            //Khuong 21/05/2011 : danh cho form tiepdonmoi cua Hepa
            if (chkTrungcao.Checked && thetrungcao.Text.Trim() != "") m.upd_btdbn_trungcao(s_mabn, l_matd, thetrungcao.Text, i_userid);
            s_mabn_moi = s_mabn;
            l_mavaovien_moi = l_matd;
            l_maql_moi = l_maql;
            //
            if (bnew && makp_kem_chidinh != "" && mavp_kem_chidinh!=0)
            {
                if (makp_kem_chidinh.IndexOf(r1["makp"].ToString()) != -1)
                {
                    decimal _id = v.get_id_chidinh;
                    decimal _dongia = 0;
                    DataRow r3 = v.getrowbyid(dtgia, "id=" + mavp_kem_chidinh);
                    if (r3 != null)
                    {
                        int tmp_dt = int.Parse(tendoituong.SelectedValue.ToString());
                        if(tendoituong.SelectedValue.ToString()=="1" && decimal.Parse(r3["bhyt"].ToString())>0)
                            _dongia = decimal.Parse(r3[m.field_gia(tendoituong.SelectedValue.ToString())].ToString());
                        else if (tendoituong.SelectedValue.ToString() == "1")
                        {
                            _dongia = decimal.Parse(r3["gia_th"].ToString());
                            tmp_dt = 2;
                        }
                        else
                        {
                            _dongia = decimal.Parse(r3[m.field_gia(tendoituong.SelectedValue.ToString())].ToString());
                        }
                        v.upd_chidinh(_id, s_mabn, l_maql, l_maql, 0, ngayvv.Text, v.iNgoaitru, r1["makp"].ToString(), tmp_dt , int.Parse(mavp_kem_chidinh.ToString()), 1, _dongia, 0, i_userid, 0, 0, _id, "", "", "", 3,"");
                        //
                        v.execute_data("update " + user + v.mmyy(ngayvv.Text.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + _id);
                        v.execute_data("update " + user + v.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon set idchidinh=" + l_id + " where maql=" + l_maql);
                    }                    
                }
            }
			if (lydo.Visible && lydo.Text=="") m.upd_lydokham(ngayvv.Text+" "+giovv.Text,l_maql,lydo.Text);
			else m.execute_data("delete from "+user+m.mmyy(ngayvv.Text)+".lydokham where maql="+l_maql);
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0, (txtNhipTho.Text != "") ? decimal.Parse(txtNhipTho.Text) : 0);
			m.upd_sukien(s_mabn,l_maql,LibMedi.AccessData.Tiepdon,l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),kinhcc.Text,ngaysanh.Text,dacdiem.Text);
            //if (n_makp.Visible) upd_tiepdon();
            if (pnmakp.Visible) upd_tiepdon();
            else if (r1["kem"].ToString().Trim() != "") upd_tiepdon(r1["kem"].ToString().Trim());
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0)
			{
                if (bDacocongkham && bKhacbv_traituyen_pk2 && mabv.Text != m.Mabv)//gam 12/01/2012
                {
                    m.upd_bhyt(ngayvv.Text, s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text, ngay1.Text, ngay2.Text, ngay3.Text, 1);
                    traituyen.SelectedIndex = 1;
                }
                else
                {
                    m.upd_bhyt(ngayvv.Text, s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text, ngay1.Text, ngay2.Text, ngay3.Text, traituyen.SelectedIndex);
                }
                if (bSothe_dmbhyt && chkBhyt.Checked) m.upd_dmthe(s_mabn, sothe.Text, hoten.Text, namsinh.Text, phai.SelectedIndex, sonha.Text.Trim() + " " + thon.Text.Trim(), matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, cholam.Text, tungay.Text, denngay.Text, mabv.Text);
				if (bDssothe) 
				{
					m.upd_dmbhyt(s_mabn,"",sothe.Text,tungay.Text,denngay.Text,mabv.Text,0);
					#region updrec
					DataRow r3,r4;
					r3=m.getrowbyid(dtsothe,"sothe='"+sothe.Text+"'");
					if (r3==null)
					{
						r4=dtsothe.NewRow();
						r4["st"]=sothe.Text;
						r4["sothe"]=sothe.Text;
						r4["mabv"]=mabv.Text;
						r4["tungay"]=tungay.Text;
						r4["denngay"]=denngay.Text;
						r4["tenbv"]=tenbv.Text;
						dtsothe.Rows.Add(r4);
					}
					#endregion
				}
            }
            if (bBHYT_QRCode_Dangky && s_QRcode_sothe.Trim() != "")
            {
                m.upd_bhyt_qrcode(s_QRcode_sothe, s_QRcode_Hoten, s_QRcode_ngaysinh, int.Parse(s_QRcode_gioitinh), s_QRcode_diachi, s_QRcode_mabv, s_QRcode_tungay, s_QRcode_denngay, s_QRcode_ngaycap, s_QRcode_MaQLBHXH, s_QRcode_KiemTraBHXH, i_userid, s_mabn);
            }
			if (pdienthoai.Visible)
			{
				if (dt_nha.Text!="" || dt_coquan.Text!="" || dt_didong.Text!="" || dt_email.Text!="")
					m.upd_dienthoai(s_mabn,dt_nha.Text,dt_coquan.Text,dt_didong.Text,dt_email.Text);
			}
			if (bNoigioithieu)
			{
				if (madstt.Text!="") m.upd_noigioithieu(ngayvv.Text,l_maql,madstt.Text,"","");
				else m.execute_data("delete from "+user+m.mmyy(ngayvv.Text)+".noigioithieu where maql="+l_maql);
			}
            lblDTUuTien_Click(null, null);
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (quanhe.Text!="") m.upd_quanhe(ngayvv.Text,l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
            //
            if (bChenhlech_laygiaphuthu && cmbLoaitg.SelectedIndex >= 0) 
            {
                if (m.get_data("select mavaovien from " + m.user + ".bndk_tg where mavaovien=" + l_matd).Tables[0].Rows.Count == 0)
                {
                    if (!m.upd_bndk_tg(f_get_mabn(), l_matd, int.Parse(cmbLoaitg.SelectedValue.ToString())))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin giờ hành chính !"), s_msg);
                        return;
                    }
                }
            }
            //quan ly doi tuong bo doi
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue.ToString());
            try
            {
                if (r["bodoi"].ToString() == "1")
                {
                    frmDoiTuongBoDoi f = new frmDoiTuongBoDoi(m, s_mabn, hoten.Text, tuoi.Text, ((sonha.Text == "") ? "" : sonha.Text + ", ") + ((thon.Text == "") ? "" : thon.Text + ", ") + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, l_matd, false);
                    f.ShowDialog();
                }
            }
            catch 
            {
                string aasql = "alter table medibv.doituong add bodoi numeric(1) default 0";
                m.execute_data(aasql, false);
                int tmp_dt = int.Parse(tendoituong.SelectedValue.ToString());
                f_load_doituong_dangky(0);
                tendoituong.SelectedValue = tmp_dt;
            }
			if (bInkhambenh || bDanhsach || bInphieudieutri ||bKhongintienkham)
                butIn_Click(null,null);
            if (bDangky_bsbv)
            {
                DataRow r3, r4;
                m.upd_tttiepdon(ngayvv.Text, l_maql, "", bacsy.Text, benhvien.Text, "", "",txtMaBSGioiThieu.Text,s_manvsale,s_mavung);
                if (bacsy.Text!="")
                {
                    r3 = m.getrowbyid(dtbs1, "ten='" + bacsy.Text + "' and benhvien='" + benhvien.Text + "'");
                    if (r3 == null)
                    {
                        r4 = dtbs1.NewRow();
                        r4["ten"] = bacsy.Text;
                        r4["benhvien"] = benhvien.Text;
                        dtbs1.Rows.Add(r4);
                    }
                    r3 = m.getrowbyid(dtbv, "ten='" + benhvien.Text + "'");
                    if (r3 == null)
                    {
                        r4 = dtbv.NewRow();
                        r4["ten"] = benhvien.Text;
                        dtbv.Rows.Add(r4);
                    }
                    m.upd_dmbschidinh(bacsy.Text, benhvien.Text);
                    m.upd_dmbvchidinh(benhvien.Text);
                }
            }
            if (bQuanlinvsale)
            {
                DataRow r3, r4;
                m.upd_tttiepdon(ngayvv.Text, l_maql, "", bacsy.Text, benhvien.Text, "", "", txtMaBSGioiThieu.Text, s_manvsale, s_mavung);
            }
			ena_but(false);
            chklistDTuutien.Visible = false;
			if (bBangdien)
			{
				dsbdien.Clear();
				r1=dsbdien.Tables[0].NewRow();
                r1["mabn"] = f_get_mabn();// mabn2.Text + mabn3.Text;
				r1["stt"]=sovaovien.Text.Trim().PadLeft(4,'0');
				r1["hoten"]=hoten.Text;
				r1["tuoi"]=tuoi.Text+" "+loaituoi.Text;
				r1["phongkham"]=tenkp.Text;
				r1["ngaykham"]=ngayvv.Text.Substring(0,10);
				dsbdien.Tables[0].Rows.Add(r1);
				string path=s_path+"//"+ngayvv.Text.Substring(0,2)+ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(6,4);
				string tenfile=sovaovien.Text.Trim().PadLeft(4,'0')+".xml";//mabn2.Text+mabn3.Text+"_"+makp.Text.Trim()+"_"+sovaovien.Text.Trim().PadLeft(4,'0')+".xml";
				if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
				dsbdien.WriteXml(path+"//"+tenfile,XmlWriteMode.WriteSchema);
			}
            // hien them 10-05-2011 bệnh nhân là nhân viên của bệnh viện
            m.execute_data("update "+m.user+m.mmyy(ngayvv.Text)+".lienhe set nvienbv="+(chkNhanvienbv.Checked ? 1:0)+" where maql="+l_maql+"");
            if (int.Parse(tendoituong.SelectedValue.ToString()) == 1 && bChuphinhct && traituyen.SelectedIndex == 1 && bChuphinhtraituyen)
            {
                sql = "select mavaovien from "+m.user+".hachungtu where mavaovien="+l_matd;
                if (m.get_data(sql).Tables[0].Rows.Count==0)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân trái tuyến phải có hình chứng từ !\nBạn có muốn chụp hình chứng từ?"), s_msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmChuphinhchungtu f = new frmChuphinhchungtu(s_mabn, decimal.Parse(l_matd.ToString()), i_userid);
                        f.ShowDialog();
                    }
                }
            }
			butTiep.Focus();
		}

        private void upd_tiepdon(string kem)
        {
            string kp, sokham = sovaovien.Text, ngay, ng = ngayvv.Text + " " + giovv.Text;
            int j = 1;
            decimal maql = 0,mavaovien=l_maql;
            string s = kem.Replace(",", "','");
            sql = "select * from "+user+".btdkp_bv where loai=1";
            sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                kp = r["makp"].ToString();
                DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                maql = m.get_maql(s_mabn, kp, ngay);
                mavaovien = (bTiepdon_n_makp_chung_chiphi && madoituong.Text=="1") ? l_maql : maql;
                if (i_sokham != 3 && bNew) sokham = m.get_sokham(ngay.Substring(0, 10), kp, i_sokham).ToString();
                if (!m.upd_tiepdon(s_mabn,mavaovien, maql, kp, ngay, int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex,(bTiepdon_ngoaitru)?(chkNgoaitru.Checked)?-2:0:0, loai.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                    return;
                }
                //090611
                sql = "update " + m.user + m.mmyy(ngay) + ".tiepdon set ";
                if (m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")
                    sql += " done=null ";
                else sql += " done='c' ";
                sql+=" where mavaovien=" + mavaovien + " and maql=" + maql;
                if (!m.execute_data(sql))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                    return;
                }
                //
                if (sothe.Text != "") m.upd_bhyt(ngay, s_mabn, maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,traituyen.SelectedIndex);
                m.upd_sukien(ngay, s_mabn, mavaovien, LibMedi.AccessData.Tiepdon, maql);
                m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "tiepdon"), i_userid, "ins");
                j++;
            }
        }

        private void upd_tiepdon()
        {
            string kp, sokham = sovaovien.Text, ngay, ng = ngayvv.Text + " " + giovv.Text;
            int j = 1;
            decimal maql = 0;
            decimal mavaovien = (l_matd > 0) ? l_matd : l_maql;
            //for (int i = 0; i < n_makp.Items.Count; i++)
            foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
            {
                kp = rk["makp"].ToString();
                DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                maql = m.get_maql(s_mabn, kp, ngay);
                //mavaovien = (bTiepdon_n_makp_chung_chiphi && madoituong.Text=="1") ? l_maql : maql;
                if (i_sokham != 3) sokham = m.get_sokham(ngay.Substring(0, 10), kp, i_sokham).ToString();
                if (!m.upd_tiepdon(s_mabn, mavaovien, maql, kp, ngay, int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, (rk["taikham"].ToString().ToLower() == "true") ? 1 : 0, 0, loai.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                    return;
                }
                //090611

                sql = "update " + m.user + m.mmyy(ngay) + ".tiepdon set ";
                if (m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")
                    sql += " done=null ";
                else sql += " done='c' ";
                sql+=" where mavaovien=" + mavaovien + " and maql=" + maql;
                if (!m.execute_data(sql))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                    return;
                }
                //
                if (sothe.Text != "")  m.upd_bhyt(ngay, s_mabn, maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text, ngay1.Text, ngay2.Text, ngay3.Text,traituyen.SelectedIndex);
                m.upd_sukien(ngay, s_mabn, mavaovien, LibMedi.AccessData.Tiepdon, maql);
                m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "tiepdon"), i_userid, "ins");
                j++;
            }
        }


		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            if (bInkhambenh || bInphieudieutri) butIn.Enabled = !ena;
            chklistDTuutien.Visible = !ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            if (bVantay) fnhandang.boqua_dauvantay();
			butTiep_Click(null,null);
		}

		private void ref_check()
		{
			//n_makp.Visible=false;
            pnmakp.Visible = false;
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "") return;
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
            TreeNode node;
            try
            {
                sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.tenkp,to_char(a.ngay,'yyyymmddhh24mi') as yymmdd from xxx.tiepdon a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + s_mabn + "'" + " and a.noitiepdon=0";
                if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";
                if (i_chinhanh != 0) sql += " and b.chinhanh="+i_chinhanh;
                foreach (DataRow r in m.get_data_nam(nam, sql).Tables[0].Select("true", "yymmdd desc"))
                {
                    node = treeView1.Nodes.Add(r["ngay"].ToString());
                    node.Nodes.Add(r["tenkp"].ToString());
                }
            }
            catch { }
			//treeView1.ExpandAll();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse || e.Action==TreeViewAction.ByKeyboard)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					string ngay=s.Substring(iPos-2,16);
                    s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
					l_maql=m.get_maql(s_mabn,"??",ngay);
					bNew=l_maql==0;
                    l_maql_moi = l_maql;
					if (l_maql!=0)
					{
                        ngayvv.Text = ngay.Substring(0, 10);
                        giovv.Text = ngay.Substring(11);
						load_vv_maql(true);
						load_n_makp(ngayvv.Text+" "+giovv.Text);
						if (!m.bAdminHethong(i_userid)) ena_but(false);
					}
				}
				catch{}
			}
		}

		

		private void load_btdnn(int i)
		{
			if (i==0) tennn.DataSource=m.get_data("select * from "+user+".btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void Filt_noicap(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
			DataView dv=(DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			try
			{
                tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where hide=0 and mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
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
			Filt_noicap(tenbv.Text);
            if (traituyen.Enabled) list.BrowseToText(tenbv, mabv, traituyen, mabv.Location.X, mabv.Location.Y + mabv.Height - 2, mabv.Width + tenbv.Width + 1, mabv.Height);
            if (bTiepdon_ngoaitru) list.BrowseToText(tenbv, mabv, chkNgoaitru, mabv.Location.X, mabv.Location.Y + mabv.Height - 2, mabv.Width + tenbv.Width + 1, mabv.Height);
			else if (loai.Enabled)  list.BrowseToText(tenbv,mabv,loai,mabv.Location.X,mabv.Location.Y+mabv.Height-2,mabv.Width+tenbv.Width+1,mabv.Height);
			else if (bnmoi.Enabled) list.BrowseToText(tenbv,mabv,bnmoi,mabv.Location.X,mabv.Location.Y+mabv.Height-2,mabv.Width+tenbv.Width+1,mabv.Height);
			else list.BrowseToText(tenbv,mabv,quanhe,mabv.Location.X,mabv.Location.Y+mabv.Height-2,mabv.Width+tenbv.Width+1,mabv.Height);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            if (sender != null)
            {
                if (!kiemtra()) return;
            }
			butIn.Enabled=false;
            bDacocongkham = false;
            DataRow r1;
			#region phieudieutri
			if (chkDieutri.Checked)
			{
				r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
				string so=r1["makp"].ToString(),ten=tenkp.Text.Trim().ToUpper();
				int p1=ten.IndexOf("(");
				if (p1!=-1)
				{
					if (ten.IndexOf(")")!=-1)
					{
						so=ten.Substring(p1+1);
						if (so.IndexOf(" ")!=-1)
						{
							so=so.Substring(so.IndexOf(" ")+1);
							so=so.Substring(0,so.Length-1);
						}
					}
					ten=ten.Substring(0,p1-1);
				}
                d_dongia = 0;
                int i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(r1["mavp"].ToString());
                if (bLuachontienkham)
                {
                    d_dongia = decimal.Parse(dongia.Text);
                    if (madantoc.Text == "55") d_dongia *= m.dTygia;
                }
                else
                {
                    if (bSuagiakham)
                    {
                        if (dongia.Text == "") dongia.Text = "0";
                        d_dongia = decimal.Parse(dongia.Text);
                        if (madantoc.Text == "55") d_dongia *= m.dTygia;
                    }
                    else d_dongia = m.tienkham(madantoc.Text == "55", int.Parse(r1["mavp"].ToString()), int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                }
				dsdt.Tables[0].Rows[0]["syt"]=m.Syte;
				dsdt.Tables[0].Rows[0]["bv"]=m.Tenbv;
				dsdt.Tables[0].Rows[0]["diachibv"]=m.Diachi;
				dsdt.Tables[0].Rows[0]["ngayin"]=d_dongia.ToString();
				dsdt.Tables[0].Rows[0]["nguoiin"]=s_userid;
				dsdt.Tables[0].Rows[0]["ghichu"]="PHÒNG SỐ : "+so;
				dsdt.Tables[0].Rows[0]["lien"]="SỐ : "+sovaovien.Text;
                dsdt.Tables[0].Rows[0]["mabn"] = f_get_mabn();//mabn2.Text+mabn3.Text;
				dsdt.Tables[0].Rows[0]["hoten"]=hoten.Text;
				dsdt.Tables[0].Rows[0]["namsinh"]=namsinh.Text;
				dsdt.Tables[0].Rows[0]["tuoi"]=tuoi.Text+" "+loaituoi.Text;
				dsdt.Tables[0].Rows[0]["gioitinh"]=phai.SelectedIndex.ToString();
				dsdt.Tables[0].Rows[0]["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+", "+tenquan.Text.Trim()+", "+tentinh.Text.Trim();
				dsdt.Tables[0].Rows[0]["ngaykham"]=ngayvv.Text;
				dsdt.Tables[0].Rows[0]["lydokham"]=ten;
				dsdt.Tables[0].Rows[0]["nghenghiep"]=tennn.Text;
				dsdt.Tables[0].Rows[0]["doituong"]=tendoituong.Text;
				dsdt.Tables[0].Rows[0]["sothe"]=sothe.Text;
				dsdt.Tables[0].Rows[0]["tungay"]=tungay.Text;
				dsdt.Tables[0].Rows[0]["denngay"]=denngay.Text;
                dsdt.Tables[0].Rows[0]["mabv"] = mabv.Text;
                dsdt.Tables[0].Rows[0]["tenbv"] = tenbv.Text;
                dsdt.Tables[0].Rows[0]["traituyen"] = traituyen.SelectedIndex;
				dsdt.Tables[0].Rows[0]["dantoc"]=tendantoc.Text;
                dsdt.Tables[0].Rows[0]["cholam"] = cholam.Text;
                try
                {
                    dsdt.Tables[0].Columns.Add("thangtuoi");
                }
                catch { }
                if(int.Parse(tuoi.Text)<=6 && ngaysinh.Text != "")
                {
                    long songay = m.songay(m.StringToDate(ngayvv.Text), m.StringToDate(ngaysinh.Text), 0);
                    long sothang = songay / 30;
                    foreach (DataRow r0 in dsdt.Tables[0].Rows) r0["thangtuoi"] = sothang.ToString();
                }
                if (kyhieu.Visible)
                {
                    dsdt.Tables[0].Rows[0]["kyhieu"] = kyhieu.Text;
                    dsdt.Tables[0].Rows[0]["sobienlai"] = sobienlai.Text;
                    dsdt.Tables[0].Rows[0]["sotien"] = d_dongia;
                }
                if (chkxml.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dsdt.WriteXml("..//xml//phieudieutri.xml", XmlWriteMode.WriteSchema);
                }
				if (chkXem.Checked)
				{
					dllReportM.frmReport f=new dllReportM.frmReport(dsdt,"","","m_phieudieutri.rpt");
					f.ShowDialog(this);
				}
				else print.Printer(dsdt,"m_phieudieutri.rpt","","",0);
			}
			#endregion
			#region vienphi
            string ngay, ng = ngayvv.Text+" "+giovv.Text;
            string mmyy = m.mmyy(ng);
            int tmp_madt = (madoituong.Text.Trim() == "") ? 2 : int.Parse(madoituong.Text);
            int j = 1;
            bool bChenhlech = true;
            r1 = m.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.Text));
            DataRow r = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            if (r != null && r1!=null)
            {
                d_dongia = 0;
                string fie = "mavp";
                if (bnmoi.Enabled) fie = (bnmoi.SelectedIndex == 0) ? "mavp" : "mavptk";
                int i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(r[fie].ToString());
                if (bLuachontienkham)
                {
                    d_dongia = decimal.Parse(dongia.Text);
                    if (madantoc.Text == "55") d_dongia *= m.dTygia;
                }
                else
                {
                    if (bSuagiakham)
                    {
                        if (dongia.Text == "") dongia.Text = "0";
                        d_dongia = decimal.Parse(dongia.Text);
                        if (madantoc.Text == "55") d_dongia *= m.dTygia;
                    }
                    else
                    {
                        //decimal l_mavv=m.get_mavaovien_tiepdon(l_maql,m.mmyy(ngayvv.Text));
                        //Xem BN da co cong kham BHYT trong ngay chua?
                        bDacocongkham = f_b_dacocongkham(s_mabn, l_maql.ToString(), ngayvv.Text + giovv.Text, makp.Text);
                        //BHYT+Ooption G79, G79.1... true + co cong kham --> thoat ra : do chi tinh 1 cong kham; Nguoc lai tinh tiep cong kham
                        if (bDacocongkham && madoituong.Text == "1" && bBH_chitra_1congkham_conlaikhongtinh_G79_1) return;//bhyt chi tinh 1 cong kham, con lai khong tinh
                        //binh 200711
                        
                        if (pnmakp.Visible == false && (bBH_chitra_1congkham || bBH_chitra_1congkham_conlai_dttunguyen_G79_2) && madoituong.Text == "1" && bDacocongkham)
                        {
                            //Neu dang ky nhieu phong kham, nhung bhyt chi tinh 1 cong kham, con lai phai tinh sang thu phi
                            if (bBH_chitra_1congkham_conlai_dttunguyen_G79_2 == false) tmp_madt = 2;//thu phi
                            else tmp_madt = m.iTunguyen;
                        }
                        
                        //end binh 200711

                        if (bChuyenkham_pkthu2_giataikham && bDacocongkham && pnmakp.Visible == false)
                        {
                            //PK gia kham thuong, PK 2: tinh theo gia tai kham (gia khac)
                            bnmoi.SelectedIndex = 1;
                            fie = (bnmoi.SelectedIndex == 0) ? "mavp" : "mavptk";
                            i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(r[fie].ToString());
                        }
                        d_dongia = m.tienkham(madantoc.Text == "55", int.Parse(r[fie].ToString()), tmp_madt, m.field_gia(tmp_madt.ToString()));
                    }
                }
                if (bInkhambenh==false && ( bDanhsach || (bBhyt_mien_trasau_ck_chidinh && (r1["mien"].ToString() == "1" || r1["trasau"].ToString() == "1" || tmp_madt==1 || r1["madoituong"].ToString() == "1"))))
                {
                    //doituong BHYT+mien: tu dong cap nhat vao v_chidinh
                    upd_chidinh(ng, i_mavp, r["makp"].ToString(),tmp_madt);
                    
                }
                else if (kyhieu.SelectedIndex != -1)
                {
                    j = 0;
                    DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                    ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                    l_id = (imavp_the != 0) ? m.get_id_vienphi(ngay, l_maql, i_mavp, v.iNgoaitru) : m.get_id_vienphi(l_maql, ngay, v.iNgoaitru);
                    bNew = l_id == 0;
                    if (bNew || !b701306)
                    {
                        if (bNew) l_id = v.get_id_vienphi;
                        in_bienlai(l_id, l_maql, ngay, r["makp"].ToString(), tenkp.Text, i_mavp, d_dongia);
                        if (bNew) m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "v_vienphill"), i_userid, "ins");
                    }
                    else if (!bIn1lan) in_bienlai(l_id, l_maql, ngay, r["makp"].ToString(), tenkp.Text, i_mavp, d_dongia);
                    sql = "update " + user + m.mmyy(ngay) + ".tiepdon set done=null where maql=" + l_maql;
                    m.execute_data(sql);
                    #region nhieuphongkham
                    j++;
                    int i_madt = int.Parse(madoituong.Text);
                    bool b_dacocongkham = false;
                    if (pnmakp.Visible)
                    {
                        foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
                        {
                            b_dacocongkham=f_b_dacocongkham(s_mabn, l_maql.ToString(), ngayvv.Text);
                            if (bBH_chitra_1congkham && i_madt.ToString() == "1" && b_dacocongkham)
                            {
                                //phong kham sau BHYT khong chi tra
                                tmp_madt = 2;
                            }
                            if (bChuyenkham_pkthu2_giataikham && b_dacocongkham)
                            {
                                bnmoi.SelectedIndex = 1;                                
                            }
                            i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(rk[(rk["taikham"].ToString().ToLower() == "true") ? "mavptk" : "mavp"].ToString());
                            if (bLuachontienkham) d_dongia = decimal.Parse(dongia.Text);
                            else
                            {
                                if (bSuagiakham)
                                {
                                    if (dongia.Text == "") dongia.Text = "0";
                                    d_dongia = decimal.Parse(dongia.Text);
                                    if (madantoc.Text == "55") d_dongia *= m.dTygia;
                                }
                                else d_dongia = m.tienkham(madantoc.Text == "55", i_mavp, i_madt, m.field_gia(i_madt.ToString())); //d_dongia = m.tienkham(madantoc.Text == "55", i_mavp, int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                            }
                            dtime = m.StringToDateTime(ng).AddMinutes(j);
                            ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                            l_maql = m.get_maql_tiepdon(s_mabn, rk["makp"].ToString(), ngay);
                            //
                            sql = "update " + user + m.mmyy(ngay) + ".tiepdon set done=null where maql=" + l_maql;
                            m.execute_data(sql);
                            //
                            l_id = m.get_id_vienphi(ngay, l_maql, i_mavp, v.iNgoaitru);
                            if (l_id == 0 || !b701306)
                            {
                                if (l_id == 0)
                                {
                                    m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "v_vienphill"), i_userid, "ins");
                                    l_id = v.get_id_vienphi;
                                    in_bienlai(l_id, l_maql, ngay, rk["makp"].ToString(), rk["tenkp"].ToString(), i_mavp, d_dongia);
                                }
                                else if (!bIn1lan) in_bienlai(l_id, l_maql, ngay, rk["makp"].ToString(), rk["tenkp"].ToString(), i_mavp, d_dongia);
                            }
                            j++;
                        }
                    }
                    #endregion
                }
            }
			#endregion
			butTiep.Focus();
		}

        private void upd_chidinh(string ng,int i_mavp,string s_makp, int i_madt)
        {
            v_tienkhambntra = 0;// gam 26072011
            int j = 0;
            DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
            string ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
            
            string fie = "mavp";
            j++;
            DataRow [] dr = dtgia.Select("trongoi=1 and id=" + i_mavp);
            if (dr.Length > 0)
            {
                string sql = "select * from " + user + ".v_trongoi where id=" + i_mavp + " order by stt ";
                foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                {
                    upd_data(ngay, int.Parse(r1["id_gia"].ToString()), s_makp, (r1["madoituong"].ToString() != "0") ? int.Parse(r1["madoituong"].ToString()) : i_madt);
                }
            }
            else 
                upd_data(ngay, i_mavp,s_makp, i_madt);
            //
            if (pnmakp.Visible && (madoituong.Text.Trim()!="" && madoituong.Text.Trim()!="1" || (m.bChuyenkham_tinhcongkham && madoituong.Text.Trim()=="1")))
            {
                foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
                {
                    dtime = m.StringToDateTime(ng).AddMinutes(j);
                    ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                    if (bChuyenkham_pkthu2_giataikham)
                    {
                        bnmoi.SelectedIndex = 1; fie = "mavptk";
                        i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(rk[fie].ToString());
                        if(bBH_chitra_1congkham) i_madt = 2;
                    }
                    else
                    {
                        i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(rk[(rk["taikham"].ToString().ToLower() == "true") ? "mavptk" : "mavp"].ToString());
                    }
                    d_dongia = (bLuachontienkham) ? decimal.Parse(dongia.Text) : m.tienkham(madantoc.Text == "55", i_mavp, i_madt, m.field_gia(i_madt.ToString()));//int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                    l_maql = m.get_maql(s_mabn, rk["makp"].ToString(), ngay);
                    dr = dtgia.Select("trongoi=1 and id=" + i_mavp);
                    bDacocongkham = true;
                    if (dr.Length > 0)
                    {
                        foreach (DataRow r1 in v.get_data("select * from " + user + ".v_trongoi where id=" + i_mavp + " order by stt").Tables[0].Rows)
                            upd_data(ngay, int.Parse(r1["id_gia"].ToString()), rk["makp"].ToString(), i_madt);
                    }
                    else upd_data(ngay, i_mavp, rk["makp"].ToString(), i_madt);
                    j++;
                }
            }
            if (i_madt == 1 && v_tienkhambntra > 0)// gam 26072011 bệnh viện thuận an -->bn BHYT thu gói công khám mới vào pk
                m.execute_data("update " + m.user + m.mmyy(ngayvv.Text) + ".tiepdon set done='c' where mavaovien=" + l_matd + " and maql=" + l_maql);
        }
        private void upd_data(string ngay, int _mavp, string _makp, int i_madt)
        {
            d_dongia = 0; d_vattu = 0;
            string mmyy = m.mmyy(ngay), gia="",gia1="",gia2=""; decimal tygia = 1;
            DataRow r = m.getrowbyid(dtgia, "id=" + _mavp);
            int _madoituong = i_madt;// int.Parse(tendoituong.SelectedValue.ToString());
            if (bChuyendoituong && iChuyendoituong1!=0 && iChuyendoituong2!=0)
            {
                if (_madoituong == iChuyendoituong1) _madoituong = iChuyendoituong2;
            }
            if (r != null)
            {
                //if ((_madoituong == 1 && r["chenhlech"].ToString() == "1" &&
                //    decimal.Parse(r[m.field_gia(m.iTunguyen.ToString())].ToString()) > decimal.Parse(r["gia_bh"].ToString())) 
                //   && (!bChenhlechPK_chitinh_vaongaynghi || (bChenhlechPK_chitinh_vaongaynghi && chkChenhlechcongkham.Checked)))
                    //|| (bChenhlechPK_chitinh_vaongaynghi && chkChenhlechcongkham.Checked))) //!= bo wa kiem tra checkbox chenhlechcongkham
                if (_madoituong == 1 && (r["chenhlech"].ToString() == "1" || (r["chenhlech"].ToString() != "1" && bChenhlechPK_chitinh_vaongaynghi)) && chkChenhlechcongkham.Checked && (decimal.Parse(r[m.field_gia(m.iTunguyen.ToString())].ToString()) > decimal.Parse(r["gia_bh"].ToString()))) //ThanhCuong 19/03/2012 thêm đk bChenhlechPK_chitinh_vaongaynghi
                {
                    l_id = m.get_id_chidinh(ngay, l_maql, 0, v.iNgoaitru);
                    if (l_id == 0)
                    {
                        l_id = v.get_id_chidinh;
                    }
                    gia = m.field_gia(_madoituong.ToString());
                    if (bCongthucchenhlech)
                    {
                        gia1 = m.field_gia1(_mavp, traituyen.SelectedIndex);
                        gia2 = m.field_gia2(_mavp, traituyen.SelectedIndex);
                        if (gia1 == "" || gia2 == "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Khai báo thông số G91 không hợp lệ.\n Liên hệ với quản trị hệ thống."));
                            return;
                        }
                    }
                    else
                    {
                        gia2 = "gia_bh";
                        gia1 = gia;
                    }
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    if (bDacocongkham == false || (bBH_chitra_1congkham_conlaikhongtinh_G79_1 || bBH_chitra_1congkham_conlai_dttunguyen_G79_2 || bBH_chitra_1congkham) == false) //binh 9999 
                    {
                        //bhyt chi tra 1 cong kham, con lai chi tinh chenh lech
                        if (d_dongia != 0) upd_detail(ngay, _makp, _mavp, _madoituong, d_dongia);
                    }
                    //if (d_dongia != 0) upd_detail(ngay, _makp, _mavp, _madoituong, d_dongia);
                    //tinh chenh lech-bbbb
                    //l_id = v.get_id_chidinh;//bbbb
                    //
                    int tmp_madt = m.iTunguyen;
                    if (bChenhlech_laygiaphuthu) tmp_madt = m.iTunguyen_Tronggio_ngoaigio(f_get_mabn(), l_matd.ToString());
                    gia = m.field_gia(tmp_madt.ToString()); //gia = m.field_gia(m.iTunguyen.ToString());
                    if (!bCongthucchenhlech)
                        gia1 = gia;
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    if (bChenhlech_laygiaphuthu == false)
                        //d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                        d_dongia = decimal.Parse(r[gia1].ToString()) * tygia - decimal.Parse(r[gia2].ToString());//gam 11/01/2012
                    else
                    {
                        d_dongia = decimal.Parse(r[gia.Replace("gia", "phuthu")].ToString());
                        //binh 130711 cap nhat gia phu thu thanh 1 cot trong v_chidinh chu khong them 1 dong
                        //m.execute_data("update " + user + m.mmyy(ngay) + ".v_chidinh set phuthu=" + d_dongia + " where id=" + l_id);//chua them filed phu thu nen chua dung
                        //return;//
                    }
                    if (d_dongia > 0)
                    {
                        if (i_madt != 1) v_tienkhambntra += d_dongia;// gam 26072011
                        l_id = -1 * l_id;
                        if (bMien_congkham_cholam && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                        {
                            decimal dg_giam = d_dongia;// *(cl_tyle / 100);
                            d_dongia -= dg_giam;
                            upd_detail(ngay, _makp, _mavp, cl_doituong, dg_giam);
                            //l_id = v.get_id_chidinh;
                        }
                        else if (cl_tyle != 0 && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                        {
                            decimal dg_giam = d_dongia * (cl_tyle / 100);
                            d_dongia -= dg_giam;
                            upd_detail(ngay, _makp, _mavp, cl_doituong, dg_giam);
                            //l_id = v.get_id_chidinh;
                        }
                        if (d_dongia != 0)//chenh lech
                        {
                            upd_detail(ngay, _makp, _mavp, tmp_madt, d_dongia);
                            sql = "update " + user + m.mmyy(ngay) + ".v_chidinh set hide=1, done=1 where id=" + l_id;
                            m.execute_data(sql);
                        }
                    }
                    //}
                }
                else
                {
                    //27.12.2011 bỏ điều kiện _madoituong.ToString() == "1" && trong if
                    if (((bDacocongkham == false || (bBH_chitra_1congkham_conlaikhongtinh_G79_1 || bBH_chitra_1congkham) == false))) //Khuong 12/12/2011 || bBH_chitra_1congkham_conlai_dttunguyen_G79_2 
                    { 
                        l_id = m.get_id_chidinh(ngay, l_maql, _mavp, v.iNgoaitru);
                        if (l_id == 0) l_id = v.get_id_chidinh;
                        gia = m.field_gia(_madoituong.ToString());
                        //gam 18/01/2012 nếu chọn option G79.2 thì tiền công khám từ phòng khám 2 tr
                        if (bCongthucchenhlech && bBH_chitra_1congkham_conlai_dttunguyen_G79_2 && i_madt == 1)//gam 19/01/2012 them dk i_madt == 1 => các đối tượng khác tính bình thường chỉ tính giá chênh lệch với đối tượng BHYT
                        {
                            gia1 = m.field_gia1(_mavp, traituyen.SelectedIndex);
                            gia2 = m.field_gia2(_mavp, traituyen.SelectedIndex);
                            if (gia1 == "" || gia2 == "")
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Khai báo thông số G91 không hợp lệ.\n Liên hệ với quản trị hệ thống."));
                                return;
                            }
                            d_dongia = decimal.Parse(r[gia1].ToString()) - decimal.Parse(r[gia2].ToString());
                        }
                        else
                        {
                            //end gam 18/01/2012
                            tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                            d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                        }
                        if (d_dongia != 0)
                        {
                            upd_detail(ngay, _makp, _mavp, _madoituong, d_dongia);
                            if (i_madt != 1) v_tienkhambntra += d_dongia;// gam 26072011
                            m.execute_data("delete from " + user + mmyy + ".v_chidinh where id=-" + l_id);//xoa bo phan chenh lech
                        }
                    }
                }
            }
        }
        
        private void upd_detail(string ngay,string _makp,int _mavp,int _madoituong,decimal d_dongia)
        {
            decimal mavaovien = l_matd == 0 ? l_maql : l_matd;//l_maql
            string s_makp_ = _makp;
            /*
            DataRow dr1 = m.getrowbyid(dtkp, "viettat'" + _makp + "'");
            if (dr1 != null)
            {
                s_makp_ = dr1["makp"].ToString();
            }
            else s_makp_ = "";
             * */
            if (bTiepdon_n_makp_chung_chiphi && madoituong.Text == "1")
                mavaovien = m.get_maql(f_get_mabn(), s_makp_, ngayvv.Text + " " + giovv.Text);// m.get_maql(mabn2.Text + mabn3.Text, s_makp_, ngayvv.Text + " " + giovv.Text); ;//
            if (l_id == 0) l_id = v.get_id_chidinh;//bbbb
            //if (!m.bTiepdonMoi)
            //{
            //    v.upd_chidinh(l_id, mabn2.Text + mabn3.Text, mavaovien, l_maql, 0, ngay, v.iNgoaitru, s_makp_, _madoituong, _mavp, 1, d_dongia, 0, i_userid, 0, 0, l_id, "", "", "", 3, "");
            //    v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + l_id);
            //    v.execute_data("update " + user + v.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon set idchidinh=" + l_id + " where maql=" + l_maql);
            //}
            //else
            //{
            //    if (tendoituong.SelectedValue.ToString() == "1")
            //    {
            //        v.upd_chidinh(l_id, mabn2.Text + mabn3.Text, mavaovien, l_maql, 0, ngay, v.iNgoaitru, s_makp_, _madoituong, _mavp, 1, d_dongia, 0, i_userid, 0, 0, l_id, "", "", "", 3, "");
            //        v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + l_id);
            //        v.execute_data("update " + user + v.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon set idchidinh=" + l_id + " where maql=" + l_maql);
            //    }
            //    else
            //    { 
                    
            //    }
            //}
            v.upd_chidinh(l_id, f_get_mabn(), mavaovien, l_maql, 0, ngay, v.iNgoaitru, s_makp_, _madoituong, _mavp, 1, d_dongia, 0, i_userid, 0, 0, l_id, "", "", "", 3, "");
            v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + l_id);
            v.execute_data("update " + user + v.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon set idchidinh=" + l_id + " where maql=" + l_maql);
            if (bThuphi_kham && bInkhambenh==false && bNew)// && l_id>0)//l_id<=0: phan chenh lech//Thuy 13.09.2012
            {
                DataRow r = m.getrowbyid(dtdt, "mien=0 and trasau=0 and madoituong=" + _madoituong);
                if (m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")
                    sql += " done=null ";
                else
                    if (r != null)
                    {
                        sql = "update " + user + m.mmyy(ngay) + ".tiepdon set ";
                        if (m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")
                            sql += " done=null ";
                        else if(bNew) sql += " done='c' ";
                        sql += " where maql=" + l_maql;
                        m.execute_data(sql);
                    }
                    else
                    {
                        sql = "update " + user + m.mmyy(ngay) + ".tiepdon set ";
                        if (m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["mien"].ToString() == "1" || m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue)["trasau"].ToString() == "1" || tendoituong.SelectedValue.ToString() == "1")
                            sql += " done=null ";
                        else sql += " done='c' ";
                        sql += " where maql=" + l_maql + " and done='x' and idchidinh in(select id from " + user + m.mmyy(ngay) + ".v_chidinh where paid=0 and id=" + l_id + ")";
                        m.execute_data(sql);
                    }
            }
            
        }

		private decimal upd_data_vp(decimal id,int _mavp,int stt,string kp)
		{
			decimal dongia=0,mien=0;
			DataRow r=m.getrowbyid(dtgia,"id="+_mavp);
			if (r!=null)
			{
				if (m.bNuocngoai(f_get_mabn()))//mabn2.Text+mabn3.Text))
					dongia=decimal.Parse(r["gia_nn"].ToString())*m.dTygia;
				else
				{
					string gia=m.field_gia(tendoituong.SelectedValue.ToString());
					string giavt="vattu_"+gia.Substring(4).Trim();
					dongia=decimal.Parse(r[gia].ToString());
				}
				if (madoituong.Text=="1") mien=(r["bhyt"].ToString()=="0")?0:dongia;
				else if (pmien.Visible)
				{
					if (m.mien_doituong(int.Parse(madoituong.Text),dtdt)) mien=dongia;
				}
				else if (m.mien_doituong(int.Parse(madoituong.Text),dtdt)) mien=dongia;
				v.upd_vienphict(ngayvv.Text+" "+giovv.Text,id,stt,int.Parse(madoituong.Text),_mavp,"Khám bệnh",1,dongia,mien,0,0,"",kp);
				d_dongia+=dongia;
				d_mien+=mien;
			}
			return dongia;
		}

		private void in_bienlai(decimal id,decimal maql,string ngay,string kp,string tkp,int mavp,decimal dongia)
		{
			decimal gia=0,dg_giam=0;
            int tmp_madt_tn = m.iTunguyen;
            string nguoithu = s_userid, s_doituong_tn = m.f_get_tendoituong(tmp_madt_tn.ToString());
            string lydo = "", ten = tkp;// tenkp.Text;
			DataRow r=m.getrowbyid(dtuser,"id="+i_useridvp);
			if (r!=null) nguoithu=r["hoten"].ToString();
			DataRow [] dr=dtgia.Select("trongoi=1 and id="+mavp);
			d_dongia=0;d_mien=0;
            bool bChenhlech = false;
            bool tmp_bBH_chitra_1congkham = bBH_chitra_1congkham && madoituong.Text == "1" && f_b_dacocongkham(s_mabn, l_maql.ToString(), ngay, makp.Text);
                        
            bool inbienlai = (dongia - d_mien != 0 || (bBienlai_mien && madoituong.Text != "1"));
            v.upd_vienphill(id, (!inbienlai) ? -1 : decimal.Parse(kyhieu.SelectedValue.ToString()), (!inbienlai) ? -1 : decimal.Parse(sobienlai.Text), ngay, f_get_mabn(), maql, maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, (!inbienlai) ? -1 : i_useridvp, "");
			if (dr.Length>0) 
			{
				int i=1;
				if (madoituong.Text=="1")
				{
                    lydo = "Bệnh nhân hưởng BHYT=";
					sql="select a.* from "+user+".v_giavp a,"+user+".v_trongoi b where a.id=b.id_gia and b.id="+mavp+" and a.bhyt<>0 order by b.stt";
					foreach(DataRow r1 in v.get_data(sql).Tables[0].Rows)
					{
						gia=upd_data_vp(id,int.Parse(r1["id"].ToString()),i++,kp);
						lydo=lydo+r1["ten"].ToString().Trim()+"["+gia.ToString("###,###,###").Trim()+"];";
                        ten=r1["ten"].ToString();
					}
                    v.upd_vienphict(ngay, id, 1, 1, mavp, ten, 1, gia, 0, 0, 0, "", kp);
                    sql = "select a.* from " + user + ".v_giavp a," + user + ".v_trongoi b where a.id=b.id_gia and b.id=" + mavp + " and a.bhyt=0 order by b.stt";
                    lydo += "Bệnh nhân thanh toán thêm=";
					foreach(DataRow r1 in v.get_data(sql).Tables[0].Rows)
					{
						gia=upd_data_vp(id,int.Parse(r1["id"].ToString()),i++,kp);
						lydo=lydo+r1["ten"].ToString().Trim()+"["+gia.ToString("###,###,###").Trim()+"];";
                        ten = r1["ten"].ToString();
					}
                    if (bMien_congkham_cholam && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                    {
                        dg_giam = gia;// *(cl_tyle / 100);
                        v.upd_vienphict(ngay, id, 3, cl_doituong, mavp, ten, 1, dg_giam, 0, 0, 0, "", kp);
                        v.upd_mienngtru(ngay, id, dg_giam, "", -1, -1);
                        gia -= dg_giam;
                    }
                    else if (cl_tyle != 0 && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                    {
                        dg_giam = gia * (cl_tyle / 100);
                        v.upd_vienphict(ngay, id, 3, cl_doituong, mavp, ten, 1, dg_giam, 0, 0, 0, "", kp);
                        v.upd_mienngtru(ngay, id, dg_giam, "", -1, -1);
                        gia -= dg_giam;
                    }
                    if (gia!=0) v.upd_vienphict(ngay, id,2,m.iTunguyen, mavp, ten, 1, gia, 0, 0, 0, "", kp);
                    dongia = gia;
                    bChenhlech = true;
				}
				else
				{
					sql="select a.* from "+user+".v_giavp a,"+user+".v_trongoi b where a.id=b.id_gia and b.id="+mavp+" order by b.stt";
					foreach(DataRow r1 in v.get_data(sql).Tables[0].Rows)
					{
						gia=upd_data_vp(id,int.Parse(r1["id"].ToString()),i++,kp);
						lydo=lydo+r1["ten"].ToString().Trim()+"["+gia.ToString("###,###,###").Trim()+"];";
					}
				}
				dongia=d_dongia-d_mien;
				d_mien=0;
			}
			else 
			{
                DataRow r2 = m.getrowbyid(dtgia, "id=" + mavp);
                if (tmp_bBH_chitra_1congkham)//BN dang ky kham kham nhieu lan, lan 2 tro di, BHYT khong thanh toan
                {
                    ten = r2["ten"].ToString();
                    v.upd_vienphict(ngay, id, 3, tmp_madt_tn, mavp, ten, 1, dongia, 0, 0, 0, "", kp);
                    inbienlai = true;
                }
                else
                {
                    if (madoituong.Text == "1" && r2["chenhlech"].ToString() == "1" && (decimal.Parse(r2[m.field_gia(m.iTunguyen.ToString())].ToString()) > decimal.Parse(r2["gia_bh"].ToString())))//!=
                    {
                        ten = r2["ten"].ToString();
                        lydo = "Bệnh nhân hưởng BHYT=";
                        string sgia = m.field_gia(madoituong.Text.ToString());
                        decimal tygia = (sgia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_mien = decimal.Parse(r2[sgia].ToString()) * tygia;
                        lydo = lydo + r2["ten"].ToString().Trim() + "[" + d_mien.ToString("###,###,###").Trim() + "];";
                        if (bBienlai_mien && bBhyt_mien_trasau_ck_chidinh==false) v.upd_vienphict(ngay, id, 1, 1, mavp, ten, 1, d_mien, 0, 0, 0, "", kp);//phan BHYT se khong chuyen vao vien phi
                        else upd_detail(ngay, kp, mavp, int.Parse(madoituong.Text), d_mien);

                        sgia = m.field_gia(m.iTunguyen.ToString());
                        tygia = (sgia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        dongia = decimal.Parse(r2[sgia].ToString()) * tygia;
                        d_dongia = dongia - decimal.Parse(r2["gia_bh"].ToString());
                        if (bMien_congkham_cholam && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                        {
                            dg_giam = d_dongia;// *(cl_tyle / 100);
                            v.upd_vienphict(ngay, id, 3, cl_doituong, mavp, ten, 1, dg_giam, 0, 0, 0, "", kp);
                            d_dongia -= dg_giam;
                            v.upd_mienngtru(ngay, id, dg_giam, "", -1, -1);
                        }
                        else if (cl_tyle != 0 && cl_cholam.IndexOf(cholam.Text.ToString().Trim().ToLower()) != -1 && cholam.Text != "")
                        {
                            dg_giam = d_dongia * (cl_tyle / 100);
                            v.upd_vienphict(ngay, id, 3, cl_doituong, mavp, ten, 1, dg_giam, 0, 0, 0, "", kp);
                            d_dongia -= dg_giam;
                            v.upd_mienngtru(ngay, id, dg_giam, "", -1, -1);
                        }
                        if (d_dongia != 0) lydo = lydo + "Bệnh nhân thanh toán thêm=" + r2["ten"].ToString().Trim() + "[" + d_dongia.ToString("###,###,###").Trim() + "];";
                        if (d_dongia != 0)
                        {
                            v.upd_vienphict(ngay, id, 2, m.iTunguyen, mavp, ten, 1, d_dongia, 0, 0, 0, "", kp);
                            v.upd_bhyt(ngayvv.Text, id, sothe.Text, 0, mabv.Text, "", traituyen.SelectedIndex);
                        }
                        dongia = d_dongia;
                        bChenhlech = true;
                    }
                    else
                    {
                        if (madoituong.Text == "1") v.upd_bhyt(ngayvv.Text, id, sothe.Text, 0, mabv.Text, "", traituyen.SelectedIndex);
                        else if (pmien.Visible)
                        {
                            if (m.mien_doituong(int.Parse(madoituong.Text), dtdt))
                            {
                                if (bBhyt_mien_trasau_ck_chidinh == false)
                                {
                                    v.upd_mienngtru(ngayvv.Text, id, dongia, "", int.Parse(duyet.SelectedValue.ToString()), int.Parse(lydomien.SelectedValue.ToString()));
                                }
                                else
                                {
                                    upd_detail(ngayvv.Text , kp, mavp, int.Parse(madoituong.Text), dongia);
                                }
                            }
                        }
                        gia = upd_data_vp(id, mavp, 1, kp);
                        lydo = m.get_tenvp(mavp);
                    }
                }
			}
            if (tmp_bBH_chitra_1congkham) inbienlai = true;//BN dang ky kham kham nhieu lan, lan 2 tro di, BHYT khong thanh toan
            else if (bChenhlech) inbienlai = true;
            else if (madoituong.Text == "1") inbienlai = false;
            else if (bBienlai_mien && m.mien_doituong(int.Parse(madoituong.Text), dtdt)) inbienlai = true;
            else inbienlai = (dongia - d_mien != 0);
			if (inbienlai)
			{
				if (bKyhieu_chung && bNew) sobienlai.Text=m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),true).ToString();
				else if (bNew) m.upd_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text));
			}
            v.upd_vienphill(id, (!inbienlai) ? -1 : decimal.Parse(kyhieu.SelectedValue.ToString()), (!inbienlai) ? -1 : decimal.Parse(sobienlai.Text), ngay, f_get_mabn(), maql, maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, (!inbienlai) ? -1 : i_useridvp, "");
            if (inbienlai)
			{
                //dongia -= d_mien;
				dsxml.Clear();
				DataRow r1;	
				for(int i=0;i<dslien.Tables[0].Rows.Count;i++)
				{
					r1=dsxml.Tables[0].NewRow();
					r1["syt"]=m.Syte;
					r1["bv"]=m.Tenbv;
					r1["diachibv"]=m.Diachi;
                    r1["tongcucthue"] = (tmp_bBH_chitra_1congkham)?s_doituong_tn : tendoituong.Text;
                    r1["cucthue"] = (tmp_bBH_chitra_1congkham) ? tmp_madt_tn.ToString() : madoituong.Text;
					r1["masothue"]=v.Masothue;
					r1["mauso"]=v.Mausobienlai;
					r1["nguoiin"]=s_userid;
					r1["ngaysinh"]=ngaysinh.Text;
                    r1["namsinh"] = namsinh.Text;
					r1["gioitinh"]=phai.Text;
					r1["quyenso"]=kyhieu.Text;
					r1["sobienlai"]=sobienlai.Text;
					r1["hoten"]=hoten.Text;
                    r1["mabn"] = f_get_mabn();// mabn2.Text + mabn3.Text;
					r1["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+", "+tenquan.Text.Trim()+", "+tentinh.Text.Trim();
					r1["khoa"]=tkp;
					r1["lydo"]=lydo;
					r1["sotien"]=dongia.ToString();
					r1["chutien"]=doiso.doiraso(dongia.ToString());
					r1["diengiai"]=lydo;
                    r1["ghichu"] = d_mien.ToString();
					r1["ngayin"]=ngayvv.Text.Substring(0,10);
					r1["lien"]=dslien.Tables[0].Rows[i]["ten"].ToString();
					r1["nguoithu"]=nguoithu;
                    try
                    {
                        r1["dienthoai"] = dt_didong.Text + " - " + dt_nha.Text;//binh 240108
                        r1["doituong"] = (tmp_bBH_chitra_1congkham) ? s_doituong_tn : tendoituong.Text; //tendoituong.Text;//binh 240108
                    }
                    catch 
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thêm 2 field: dienthoai, doituong trong file v_bienlai.xml, trong thu muc xml"));
                        m.upd_error("Them 2 field: dienthoai, doituong trong file v_bienlai.xml, trong thu muc xml", "", "v_bienlai.xml"); 
                    }
					dsxml.Tables[0].Rows.Add(r1);
				}
				sobienlai.Text=m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),1).ToString();
				m.updrec(dtkh,decimal.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
				if (bInkhambenh)
				{
                    if (bDocmavach)
                    {
                        //if (!System.IO.Directory.Exists("c://reportpic")) System.IO.Directory.CreateDirectory("c://reportpic");
                        //barcode.Picture.Save("c://reportpic//barcode.bmp");
                    }
					if (chkXem.Checked)
					{
						dllReportM.frmReport f=new dllReportM.frmReport(dsxml,s_userid,sovaovien.Text,"v_bienlaithuvienphi_tiepdon.rpt");
						f.ShowDialog(this);
					}
					else 
					{
						print.Printer(dsxml,"v_bienlaithuvienphi_tiepdon.rpt",s_userid,sovaovien.Text,0);
						m.execute_data("update "+user+m.mmyy(ngayvv.Text)+".v_vienphill set lanin=lanin+1 where id="+l_id);
					}
				}
			}
		}
		private void kyhieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (kyhieu.SelectedIndex==-1 && kyhieu.Items.Count>0) kyhieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void kyhieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.ActiveControl==kyhieu)
				{
					sobienlai.Text=dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
					iLoai=int.Parse(dtkh.Rows[0]["loai"].ToString());
					s_kyhieu=kyhieu.SelectedValue.ToString();
				}
			}
			catch{}
		}

		private void sobienlai_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (sobienlai.Text=="") sobienlai.Text="0";
				if (bSobienlai && kyhieu.SelectedIndex!=-1)
				{
					if (!m.kiemtra_bienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text)))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số biên lai vượt quá trong khoản từ : ")+dtkh.Rows[kyhieu.SelectedIndex]["tu"].ToString()+" đến : "+dtkh.Rows[kyhieu.SelectedIndex]["den"].ToString(),LibMedi.AccessData.Msg);
						sobienlai.Text=dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
						sobienlai.Focus();
						return;
					}
					m.upd_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text));
					m.updrec(dtkh,decimal.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
				}
			}
			catch{}
			butLuu.Focus();
		}

		private void load_kyhieu()
		{
			sql="select * from "+user+".v_quyenso where khambenh=1";
			if (i_sohieu!=0) sql+=" and id="+i_sohieu;
			if (i_loai!=0) sql+=" and loai like '%"+i_loai.ToString()+"%'";
			if (!checkBox1.Checked) sql+=" and soghi<den";
            if (bKyhieu_may) sql += " and computerid=" + m.iRownum;
            else if (!checkBox1.Checked) sql += " and userid=" + i_useridvp;
			sql+=" order by sohieu";
			dtkh=m.get_data(sql).Tables[0];
			kyhieu.DataSource=dtkh;
			if (dtkh.Rows.Count>0)
			{
				int iso=int.Parse(dtkh.Rows[0]["soghi"].ToString())+1;
				sobienlai.Text=iso.ToString();
				iLoai=i_loai;
				s_kyhieu=kyhieu.SelectedValue.ToString();
				m.updrec(dtkh,decimal.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
			}
		}

		private void checkBox1_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==checkBox1) load_kyhieu();
		}

		private void load_dongia()
		{
			dongia.Items.Clear();
			DataRow r=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r!=null)
			{
				if (bLuachontienkham)
				{
					string s_mucvp=r["mucvp"].ToString().Trim(),s_loaivp=r["loaivp"].ToString().Trim();
					sql="select a.* from "+user+".v_giavp a,"+user+".v_loaivp b ";
					sql+=" where a.id_loai=b.id";
					if (s_loaivp!="") sql+=" and b.id in ("+s_loaivp.Substring(0,s_loaivp.Length-1)+")";
					if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp.Substring(0,s_mucvp.Length-1)+")";
					sql+=" order by b.stt,a.stt";
					dttkham=m.get_data(sql).Tables[0];
					tienkham.DataSource=dttkham;
					if (tienkham.Items.Count>0)
					{
						dongia.Text=dttkham.Rows[tienkham.SelectedIndex][m.field_gia(madoituong.Text)].ToString();
						matienkham.Text=dttkham.Rows[tienkham.SelectedIndex]["ma"].ToString();
					}
				}
				else
				{
                    string fie = "mavp";
                    if (bnmoi.Enabled) fie = (bnmoi.SelectedIndex == 0) ? "mavp" : "mavptk";
					DataRow r1=m.getrowbyid(dtgia,"id="+int.Parse(r[fie].ToString()));
					if (r1!=null)
					{
						if (madantoc.Text=="55") 
						{
							dongia.Items.Add(r1["gia_nn"].ToString());
							dongia.Text=r1["gia_nn"].ToString();
						}
						else
						{
							string gia=m.field_gia(madoituong.Text);
							dongia.Items.Add(r1[gia].ToString());
							if (r1[gia].ToString()!=r1["gia_dv"].ToString()) dongia.Items.Add(r1["gia_dv"].ToString());
							if (bQuan01)//(s_maqu.Substring(0,3)=="701")
							{
								if (madoituong.Text=="1" || tenquan.SelectedValue.ToString()==s_maqu) dongia.Text=r1[gia].ToString();
								else dongia.Text=r1["gia_dv"].ToString();
							}
							else dongia.Text=r1[gia].ToString();
						}
					}
				}
			}
		}

		private void dongia_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (pmien.Visible) lydomien.Focus();
				else butLuu.Focus();		
			}
		}

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null) return;
			l_maql=m.get_maql_tiepdon(s_mabn,r1["makp"].ToString(),ngayvv.Text+" "+giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text + " " + giovv.Text, r1["makp"].ToString(), tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_maql, l_maql, 0, i_userid, "xxx.tiepdon", sothe.Text, nam, 3, "", "", "", (traituyen.SelectedIndex < 0) ? 0 : traituyen.SelectedIndex);
            //linh
            f.NgayVaoVien = ngayvv.Text;
            f.ShowInTaskbar = false;
            f.ParentForm = this;
            f.DiaChi = sonha.Text + ", " + thon.Text;
            f.MaPhuongXa = mapxa1.Text + mapxa2.Text;
            f.TenPhuongXa = tenpxa.Text;
            f.TenQuanHuyen = tenquan.Text;
            f.TenTinhThanh = tentinh.Text;
            f.ChoLam = cholam.Text;
            f.NamSinh = namsinh.Text;
            f.Ngaysinh = ngaysinh.Text.Trim('/');
            f.MaNgheNghiep = mann.Text;
            f.NgheNghiep = tennn.Text;
            f.MaDanToc = madantoc.Text;
            f.DanToc = tendantoc.Text;
            f.NgoaiKieu = tennuoc.Text;
            f.TheBHYT_DenNgay = denngay.Text;
            f.TheBHYT_TuNgay = tungay.Text;
            f.TheBHYT_NoiDKKCB = mabv.Text;
			f.ShowDialog(this);
            if (f.ChuyenNgoaiTru)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có sử dụng 1 số dịch vụ phải điều trị ngoại trú") + ".\n" +
                    lan.Change_language_MessageText("Đề nghị cho bệnh nhân vào phòng khám để xử trí") + ".", "Medisoft");
            }
            else if (f.ChuyenVien)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có sử dụng 1 số dịch vụ phải chuyển sang bệnh viện khác") + ".\n" +
                    lan.Change_language_MessageText("Vui lòng không chỉ định tại màn hình này") + ".", "Medisoft");
            }
            else if (f.XuatVienHenTraKetQua)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có sử dụng 1 số dịch vụ phải hẹn để trả kết quả") + ".\n" +
                    lan.Change_language_MessageText("Vui lòng không chỉ định tại màn hình này") + ".", "Medisoft");
            }
            //end linh
            load_chidinh();
		}

		public void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null) return;
            l_maql = m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
		}

		private void madoituong_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void bnmoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (bnmoi.SelectedIndex==-1) bnmoi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void l_makp_Click(object sender, System.EventArgs e)
		{
            /*
			if (n_makp.Visible) return;
			if (makp.Text=="" || tenkp.SelectedIndex==-1)
			{
				makp.Focus();
				return;
			}
			dtnkp=m.get_data("select * from "+user+".btdkp_bv where loai=1 and viettat<>'"+makp.Text+"'"+" order by makp").Tables[0];
			n_makp.Visible=true;
			n_makp.DataSource=dtnkp;
            n_makp.DisplayMember = "TENKP";
            n_makp.ValueMember = "MAKP";
			n_makp.Focus();
			if (n_makp.Visible && ngayvv.Text!="")
			{
				DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
				if (r1==null) return;
				string kp="";
				sql="select makp from "+user+m.mmyy(ngayvv.Text)+".tiepdon where noitiepdon=0 and mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"' and userid="+i_userid+" and makp<>'"+r1["makp"].ToString()+"'";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows) kp+=r["makp"].ToString().Trim()+",";
				for(int i=0;i<n_makp.Items.Count;i++)
					if (kp.IndexOf(dtnkp.Rows[i]["makp"].ToString()+",")!=-1) n_makp.SetItemCheckState(i,CheckState.Checked);
			}
             * */
            if (pnmakp.Visible)
            {
                pnmakp.Visible = false;
                return;
            }
            if (makp.Text == "" || tenkp.Text =="")
            {
                makp.Focus();
                return;
            }
            dtnkp.Clear();
            DataRow r1;
            sql = "select * from " + user + ".btdkp_bv where loai=1 and viettat<>'" + makp.Text + "'";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;//
            sql+=" order by makp";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                r1 = dtnkp.NewRow();
                r1["makp"] = r["makp"].ToString();
                r1["tenkp"] = r["tenkp"].ToString();
                r1["mavp"] = r["mavp"].ToString();
                r1["mavptk"] = r["mavptk"].ToString();
                r1["chon"] = false;
                r1["taikham"] = (bnmoi.SelectedIndex == 0) ? false : true;
                dtnkp.Rows.Add(r1);
            }
            pnmakp.Visible = true;
            if (pnmakp.Visible && ngayvv.Text != "")
            {
                r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
                if (r1 == null) return;
                sql = "select * from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where noitiepdon=0 and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and userid=" + i_userid + " and makp<>'" + r1["makp"].ToString() + "'";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    r1 = m.getrowbyid(dtnkp, "makp='" + r["makp"].ToString() + "'");
                    if (r1 != null)
                    {
                        r1["chon"] = true;
                        r1["taikham"] = (r["bnmoi"].ToString() == "0") ? false : true;
                    }
                }
            }
            dataGrid1.DataSource = dtnkp;
            dataGrid1.Focus();
		}

		private void load_n_makp(string ngay)
		{
            /*
			if (ngay!="")
			{
				sql="select * from "+user+m.mmyy(ngay)+".tiepdon where noitiepdon=0 and mabn='"+s_mabn+"'"+" and to_char(ngay,'dd/mm/yyyy')='"+ngay.Substring(0,10)+"'"+" and userid="+i_userid;
				c_makp.Checked=m.get_data(sql).Tables[0].Rows.Count>1;
				l_makp.ForeColor=(c_makp.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
			}
            */
		}

		private void n_makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}

		private void butInbarcode_Click(object sender, System.EventArgs e)
		{
			if (mabn2.Text+mabn3.Text=="" || hoten.Text=="") return;
            if (!System.IO.Directory.Exists("c://reportpic")) System.IO.Directory.CreateDirectory("c://reportpic");
            //barcode.Picture.Save("c://reportpic//barcode.bmp");
            dsbarcode.Clear();
            DataRow r = dsbarcode.Tables[0].NewRow();
            if (!System.IO.Directory.Exists("..//barcode")) System.IO.Directory.CreateDirectory("..//barcode");
            //barcode.Picture.Save("..//barcode//barcode.bmp");
            fstr = new System.IO.FileStream("..//barcode//barcode.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            image = new byte[fstr.Length];
            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
            fstr.Close();
            r["mabn"] = f_get_mabn();// mabn2.Text + mabn3.Text;
            r["hoten"] = hoten.Text;
            r["namsinh"] = namsinh.Text;
            r["phai"] = phai.Text;
            r["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            r["image"] = null;
            dsbarcode.Tables[0].Rows.Add(r);
            dllReportM.frmReport f = new dllReportM.frmReport(m, dsbarcode, "rptbarcode.rpt", f_get_mabn(), hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), "");
			f.ShowDialog(this);
		}

		private void dacdiem_Validated(object sender, System.EventArgs e)
		{
			dacdiem.Text=m.Caps(dacdiem.Text);
		}

		private void dacdiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				dacdiem.Text=m.Viettat(dacdiem.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter  || e.KeyCode==Keys.Tab)
			{
				if (bSuagiakham) dongia.Focus();
				else if (pmien.Visible) lydomien.Focus();
				else butLuu.Focus();
			}
		}

		private void para1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void para1_Validated(object sender, System.EventArgs e)
		{
			para1.Text=para1.Text.PadLeft(2,'0');
			if (para1.Text=="99")
			{
				para2.Text=para1.Text;
				para3.Text=para1.Text;
				para4.Text=para1.Text;
				dacdiem.Focus();
			}
		}

		private void para2_Validated(object sender, System.EventArgs e)
		{
			para2.Text=para2.Text.PadLeft(2,'0');
		}

		private void para3_Validated(object sender, System.EventArgs e)
		{
			para3.Text=para3.Text.PadLeft(2,'0');
		}

		private void para4_Validated(object sender, System.EventArgs e)
		{
			para4.Text=para4.Text.PadLeft(2,'0');
		}

		private void kinhcc_Validated(object sender, System.EventArgs e)
		{
			if (kinhcc.Text=="")
			{
				dacdiem.Focus();
				return;
			}
			kinhcc.Text=kinhcc.Text.Trim();
			if (!m.bNgay(kinhcc.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày kinh cuối cùng không hợp lệ !"));
				kinhcc.Focus();
				return;
			}
			kinhcc.Text=m.Ktngaygio(kinhcc.Text,10);
			if (!m.bNgay("",kinhcc.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày kinh cuối cùng không hợp lệ !"));
				kinhcc.Focus();
				return;
			}
			ngaysanh.Text=m.Ngaysanhdudoan(kinhcc.Text);
		}

		private void ngaysanh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysanh.Text=="") return;
			ngaysanh.Text=ngaysanh.Text.Trim();
			if (!m.bNgay(ngaysanh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sanh dự đoán không hợp lệ !"));
				ngaysanh.Focus();
				return;
			}
			ngaysanh.Text=m.Ktngaygio(ngaysanh.Text,10);
		}

		private void phai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (bKhamthai) khamthai.Visible=phai.SelectedIndex==1;		
		}

		private void l_lichhen_Click(object sender, System.EventArgs e)
		{
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null) return;
            l_maql = m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
		}

		private void lydo_Validated(object sender, System.EventArgs e)
		{
			if (dausinhton.Visible) mach.Focus();
			else if (khamthai.Visible) para1.Focus();
			else if (bSuagiakham) dongia.Focus();
			else if (pmien.Visible) lydomien.Focus();
			else butLuu.Focus();
		}

		private void huyetap_Validated(object sender, System.EventArgs e)
		{
            //if (khamthai.Visible) para1.Focus();
            //else if (bSuagiakham) dongia.Focus();
            //else if (pmien.Visible) lydomien.Focus();
            //else butLuu.Focus();
		}

		private void honnhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (honnhan.Items.Count>0 && honnhan.SelectedIndex==-1) honnhan.SelectedIndex=0;
				if (lydo.Visible) lydo.Focus();
				else if (mabs.Visible) mabs.Focus();
				else if (dausinhton.Visible) mach.Focus();
				else if (khamthai.Visible) para1.Focus();
				else if (bSuagiakham) dongia.Focus();
				else if (pmien.Visible) lydomien.Focus();
				else butLuu.Focus();
			}
		}

		private void tienkham_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tienkham && tienkham.SelectedIndex!=-1)
			{
				dongia.Text=dttkham.Rows[tienkham.SelectedIndex][m.field_gia(madoituong.Text)].ToString();
				matienkham.Text=dttkham.Rows[tienkham.SelectedIndex]["ma"].ToString();
			}
		}

		private void tienkham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tienkham.SelectedIndex==-1 && tienkham.Items.Count>0)
				{
					tienkham.SelectedIndex=0;
					dongia.Text=dttkham.Rows[tienkham.SelectedIndex][m.field_gia(madoituong.Text)].ToString();
					matienkham.Text=dttkham.Rows[tienkham.SelectedIndex]["ma"].ToString();
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void butKyhieu_Click(object sender, System.EventArgs e)
		{
			frmSohieu f1=new frmSohieu(m);
			f1.ShowDialog(this);
			if (f1.iKyhieu!=0 && f1.iLoai!=0)
			{
                i_loai = f1.iLoai; i_sohieu = f1.iKyhieu; i_useridvp = m.iUservp;
                checkBox1.Checked = f1.iAll == 1;
				load_kyhieu();
				kyhieu.SelectedValue=i_sohieu.ToString();
			}
			butTiep.Focus();
		}

		private void dt_nha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void lydomien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (lydomien.SelectedIndex==-1 && lydomien.Items.Count>0) lydomien.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void duyet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (duyet.SelectedIndex==-1 && duyet.Items.Count>0) duyet.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
			}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else 
				{
					if (dausinhton.Visible) mach.Focus();
					else if (khamthai.Visible) para1.Focus();
					else if (bSuagiakham) dongia.Focus();
					else if (pmien.Visible) lydomien.Focus();
					else butLuu.Focus();
				}
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

        private void Filt_tenbsgioithieu(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listbsgioithieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1 && loai.Items.Count>0) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tungay_Validated(object sender, System.EventArgs e)
		{
			tungay.Text=tungay.Text.Trim();
			if (tungay.Text.Length==6) tungay.Text=tungay.Text+DateTime.Now.Year.ToString();
			if (tungay.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				tungay.Focus();
				return;
			}
			if (!m.bNgay(tungay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tungay.Focus();
				return;
			}
            if (!m.bNgay(ngayvv.Text, tungay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu phải nhỏ hơn ngày khám bệnh!"), s_msg);
                tungay.Focus();
                return;
            }
            //if (ngay1.Enabled)
            //{
            //    DateTime tungay1 = m.StringToDate(tungay.Text);
            //    tungay1 = tungay1.AddDays(180);
            //    //if (tungay1 < m.StringToDate(m.Ngayhienhanh))
            //    //{
            //    ngay1.Text = tungay1.Day.ToString().PadLeft(2, '0') + "/" + tungay1.Month.ToString().PadLeft(2, '0') + "/" + tungay1.Year.ToString();
            //    //}
            //}
		}

		private void matienkham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matienkham_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r=m.getrowbyid(dttkham,"ma='"+matienkham.Text+"'");
				if (r!=null) tienkham.SelectedValue=r["id"].ToString();
				else tienkham.SelectedIndex=-1;
			}
			catch{}
		}

		private void madstt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (madstt.Text==m.Mabv)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"),s_msg);
					madstt.Text="";
					return;
				}
				tendstt.Text=m.get_data("select tenbv from "+user+".dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
			}
			catch{}
		}

		private void tendstt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listdstt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listdstt.Visible)
				{
					listdstt.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendstt_TextChanged(object sender, System.EventArgs e)
		{
			//treeView1.Visible=false;
			Filt_dstt(tendstt.Text);
			listdstt.BrowseToText(tendstt,madstt,madoituong,madstt.Location.X,madstt.Location.Y+madstt.Height,madstt.Width+tendstt.Width+2,madstt.Height);
		}

		private void listdstt_Validated(object sender, System.EventArgs e)
		{
			//treeView1.Visible=true;
		}

		private void tendstt_Validated(object sender, System.EventArgs e)
		{
			if(!listdstt.Focused)
			{
				listdstt.Hide();
				//treeView1.Visible=true;
			}
		}

		private void Filt_dstt(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[listdstt.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim().Replace("'","''")+"%'";
		}

		private void sothe_TextChanged(object sender, System.EventArgs e)
		{
            try
            {
                lblchieudaithe.Text = sothe.Text.Length.ToString();
            }
            catch
            {
            }
			if (this.ActiveControl==sothe && bDssothe)
			{
                
				Filt_sothe(sothe.Text);
				if (tungay.Enabled) listSothe.BrowseToDanhmuc(sothe,sothe,tungay);
				else if (denngay.Enabled) listSothe.BrowseToDanhmuc(sothe,sothe,denngay);
				else if (mabv.Enabled) listSothe.BrowseToDanhmuc(sothe,sothe,mabv);
                else if (bTiepdon_ngoaitru) listSothe.BrowseToDanhmuc(sothe, sothe, chkNgoaitru);
				else if (loai.Enabled) listSothe.BrowseToDanhmuc(sothe,sothe,loai);
				else if (bnmoi.Enabled) listSothe.BrowseToDanhmuc(sothe,sothe,bnmoi);
				else listSothe.BrowseToDanhmuc(sothe,sothe,quanhe);
			}
		}

		private void Filt_sothe(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listSothe.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="sothe like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void sothe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listSothe.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (sothe.Text=="")
				{
					madoituong.Focus();
					if (listSothe.Visible) listSothe.Hide();
					return;
				}
				if (tendoituong.SelectedIndex==-1)
				{
					focus_sothe();
					return;
				}
				if (bDssothe)
				{
					sql="sothe like '%"+sothe.Text.Trim()+"%'";
					DataRow [] dr=dtsothe.Select(sql);
					if (dr.Length==1)
					{
						sothe.Text=dr[0]["sothe"].ToString();
						tungay.Text=dr[0]["tungay"].ToString();
						denngay.Text=dr[0]["denngay"].ToString();
						mabv.Text=dr[0]["mabv"].ToString();
						tenbv.Text=dr[0]["tenbv"].ToString();
					}
				}
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (sothe.Text != "")
                {
                    if (bSothe_dkkcb)
                    {
                        if ((sothe.Text.Trim().Length == _dai || sothe.Text.Trim().Length == 18  || sothe.Text.Trim().Length == 20 ) && _vitri != 0 && _sothe != "")
                        {
                            mabv.Text = sothe.Text.Substring(sothe.Text.Trim().Length - 5, 5);
                            //mabv.Text = sothe.Text.Substring(_vitri - 1, _sothe.Length);
                            mabv_Validated(sender, e);
                        }
                    }
                }
				if (sothe.Text=="" || so.Substring(0,2)=="00") tendoituong.Focus();
				else if (m.sothe(int.Parse(tendoituong.SelectedValue.ToString()),sothe.Text))//(sothe.Text.Length>=int.Parse(so.Substring(0,2)))
				{
					focus_sothe();
					return;
				}
				else
				{
                    MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
					if (listSothe.Visible) listSothe.Hide();
					sothe.Focus();
					return;
				}
				if (listSothe.Visible) listSothe.Focus();
				else focus_sothe(); 
			}				
		}

		private void focus_sothe()
		{
			if (listSothe.Visible) listSothe.Hide();
			if (tungay.Enabled) tungay.Focus();
			else if (denngay.Enabled) denngay.Focus();
            else if (bTiepdon_ngoaitru) chkNgoaitru.Focus();
			else if (loai.Enabled) loai.Focus();
			else if (bnmoi.Enabled) bnmoi.Focus();
			else quanhe.Focus();
		}

		private void listSothe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				DataRow r=m.getrowbyid(dtsothe,"sothe='"+sothe.Text+"'");
				if (r!=null)
				{
					tungay.Text=r["tungay"].ToString();
					denngay.Text=r["denngay"].ToString();
					mabv.Text=r["mabv"].ToString();
					tenbv.Text=r["tenbv"].ToString();
				}
			}
		}

        private void ngayvv_Validated(object sender, System.EventArgs e)
        {
            if (ngayvv.Text == "")
            {
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (ngayvv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày khám bệnh !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            //
            try
            {
                //binh 140711
                if (bChenhlech_laygiaphuthu)
                {
                    if (bChenhlech_laygiaphuthu) f_get_tronggio_ngoaigio();//binh 200711
                    madoituong.Text = f_get_madoituong(int.Parse(cmbLoaitg.SelectedValue.ToString())).ToString();//binh 140711
                    f_load_doituong_dangky(int.Parse(madoituong.Text));//binh 201107
                    tendoituong.SelectedValue = madoituong.Text;
                }
            }
            catch { }
            //
            l_maql = m.get_maql_tiepdon_ngay(s_mabn, ngayvv.Text);
            if (l_maql != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã được đăng ký,") + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bNew = false;
                    load_vv_maql(false);
                    if (bDadongtienkham ==false && !m.bAdminHethong(i_userid)) ena_but(false); //if (!bAdmin) ena_but(false);
                    else if (bDadongtienkham)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã đóng tiền khám (đã khám), Bạn chỉ xem lại được thôi.") + "\n" + lan.Change_language_MessageText("Muốn sửa chữa thì đề nghị hoàn lại hóa đơn tiền khám."), LibMedi.AccessData.Msg, MessageBoxButtons.OK);
                        ena_but(false);
                    }
                    s_ngayvv = ngayvv.Text;
                    return;
                }
                else
                {
                    makp.Text = tenkp.Text = "";
                }
            }
            if (s_ngayvv != "")
            {
                if (ngayvv.Text != s_ngayvv.Substring(0, 10))
                {
                    try
                    {
                        if (tuoi.Text != "")
                        {
                            if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                            {
                                tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                                loaituoi.SelectedIndex = 0;
                            }
                        }
                    }
                    catch { }
                    s_ngayvv = ngayvv.Text;
                    if (bLoadQuanhe_lantruoc ||( namsinh.Text.Trim() != "" && m.StringToDateTime(m.Ngaygio_hienhanh).Year - int.Parse(namsinh.Text) < 15)) load_quanhe();
                }                
            }
            //if (bChenhlech_laygiaphuthu) f_get_tronggio_ngoaigio();//binh 200711
        }

        private void giovv_Validated(object sender, EventArgs e)
        {
            string sgio = (giovv.Text.Trim() == "") ? "00:00" : giovv.Text.Trim();
            giovv.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giovv.Focus();
                return;
            }
            ref_check();
            string s = ngayvv.Text + " " + giovv.Text;
            int i_madt = 0;
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
            if (s != s_ngayvv)
            {
                if (bTudong)
                {
                    DataRow r = m.getrowbyid(dtletet, "ngay='" + ngayvv.Text.Substring(0, 5) + "'");
                    bool bLetet = r != null;
                    hh1 = int.Parse(s.Substring(11, 2));
                    mm1 = int.Parse(s.Substring(14, 2));
                    DateTime dtime = m.StringToDate(s.Substring(0, 10));
                    string ddd = dtime.DayOfWeek.ToString().Substring(0, 3);
                    if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3))
                    {
                        loai.SelectedValue = "1";
                        i_madt = i_madoituong_ng;
                    }
                    else loai.SelectedValue = "0";
                }
                if (tuoi.Text != "")
                {
                    if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                    {
                        tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                        loaituoi.SelectedIndex = 0;
                    }
                }
                l_maql = m.get_maql(s_mabn, "??", s);
                bNew = l_maql == 0;
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (!bAdmin) ena_but(false);
                }
                else
                {
                    ena_but(true);
                    emp_vv();
                    if (bLoadQuanhe_lantruoc || (namsinh.Text.Trim() != "" && m.StringToDateTime(m.Ngaygio_hienhanh).Year - int.Parse(namsinh.Text) < 15)) load_quanhe();
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (bSuagiakham || bLuachontienkham) load_dongia(); 
                    if (mathe.Text == "" && !chkBhyt.Checked)
                    {
                        emp_bhyt();
                        if (i_madt != 0)
                        {
                            try
                            {
                                madoituong.Text = i_madoituong_ng.ToString();
                                tendoituong.SelectedValue = madoituong.Text;
                            }
                            catch { madoituong.Text = ""; tendoituong.SelectedIndex = -1; }
                        }
                        else
                        {
                            try
                            {
                                tendoituong.SelectedIndex = 0;
                                madoituong.Text = tendoituong.SelectedValue.ToString();
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        madoituong.Text = "1";
                        tendoituong.SelectedValue = "1";
                    }
                }
                s_ngayvv = s;
            }
            //if (i_sokham != 3 && makp.Text != "" && sovaovien.Text == "")
            //{
            //    DataRow r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            //    if (r1 != null) sovaovien.Text = m.get_sokham(ngayvv.Text.Substring(0, 10), r1["makp"].ToString(), i_sokham).ToString();
            //}

            if (bChenhlech_laygiaphuthu) f_get_tronggio_ngoaigio();//binh 110711
        }
        private void load_quanhe()
        {
            if (nam != "")
            {
                try
                {
                    foreach (DataRow r in m.get_data_nam_dec(nam, "select b.* from xxx.tiepdon a,xxx.quanhe b where a.maql=b.maql and a.mabn='" + f_get_mabn() + "'").Tables[0].Rows)
                    {
                        quanhe.Text = r["quanhe"].ToString();
                        qh_hoten.Text = r["hoten"].ToString();
                        qh_diachi.Text = r["diachi"].ToString();
                        qh_dienthoai.Text = r["dienthoai"].ToString();
                    }
                    if (quanhe.Text == "")
                    {
                        DataSet lds_quanhe = m.f_get_quanhe(s_mabn);
                        if (lds_quanhe != null && lds_quanhe.Tables.Count > 0)
                        {
                            foreach (DataRow r in lds_quanhe.Tables[0].Select("", "maql desc "))
                            {
                                quanhe.Text = r["quanhe"].ToString();
                                qh_hoten.Text = r["hoten"].ToString();
                                qh_diachi.Text = r["diachi"].ToString();
                                qh_dienthoai.Text = r["dienthoai"].ToString();
                                break;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void honnhan_VisibleChanged(object sender, EventArgs e)
        {
            lhonnhan.Visible = honnhan.Visible;
        }

        private void label43_Click(object sender, EventArgs e)
        {
            try
            {
                if (mabn2.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Mã số bệnh nhân vào trước khi chụp hình."));
                    mabn2.Focus();
                    return;
                }
                if (mnquanlihinhanhbn.Checked)
                {
                    pic.Image = null;
                    lock (pic)
                    {
                        frmChuphinh f = new frmChuphinh(s_mabn);
                        f.ShowDialog();
                        if (thumuc != "")
                        {
                            string sDir = System.Environment.CurrentDirectory.ToString();
                            //pic.Tag = thumuc + s_mabn + "." + m.FileType;
                            pic.Tag = "temp\\" + s_mabn + "." + m.FileType;
                            fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            if (pathImage == "") pic.Tag = image;
                            map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                            pic.Image = (System.Drawing.Bitmap)map;
                            fstr.Close();
                            System.Environment.CurrentDirectory = sDir;
                            bChupHinhBN = f.bCochuphinh;
                            bDacohinh = bChupHinhBN;
                            butLuu.Focus();
                        }
                    }
                }
                else if (bChonhinh)
                {
                    string sDir = System.Environment.CurrentDirectory.ToString();
                    OpenFileDialog of = new OpenFileDialog();
                    of.Title = "Chọn hình";
                    of.Filter = "Files (*." + FileType + ")|*.*|All Files (*.*)|*.*";
                    of.RestoreDirectory = true;
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        pic.Tag = of.FileName;
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        if (pathImage == "") pic.Tag = image;
                        map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                        pic.Image = (System.Drawing.Bitmap)map;
                        fstr.Close();
                        File.Copy(pic.Tag.ToString(), file, true);
                    }
                    System.Environment.CurrentDirectory = sDir;
                    butLuu.Focus();
                }
            }
            catch (Exception exx){}
        }

        private void butGoi_Click(object sender, EventArgs e)
        {
            if (chkBangDienGoiDocLapTheoTungQuay.Checked)
            {
                tu.Value = den.Value + 1;
                den.Value = den.Value + sonhay.Value;
            }
            else
            {
                string s_Quay = "TD";
                den.Value = (decimal)m.get_capstt(ngaysrv, s_Quay, (int)sonhay.Value);
                this.tu.Value = den.Value - this.sonhay.Value + 1;
                if (tu.Value == 0) tu.Value = 1;
            }
            tu.Update(); den.Update();
            
            if (this.chkLCD.Checked)
            {
                this.ds.ReadXml(@"..\..\..\xml\mauLCD.xml");
                this.sizestt = int.Parse(this.ds.Tables[0].Rows[0]["s2"].ToString());
                string str ="";
                if (tu.Value==den.Value)
                    str= this.tu.Value.ToString();// + "-" + this.den.Value.ToString();
                else
                    str = this.tu.Value.ToString() + "-" + this.den.Value.ToString();
                if (this.fgoi == null)
                {
                    this.fgoi = new frmGoibenh();
                    this.fgoi.sets = this.sizestt;
                    this.fgoi.s_sohienthi = str;
                    this.fgoi.Show();
                }
                else
                {
                    this.fgoi.sets = this.sizestt;
                    this.fgoi.s_sohienthi = str;
                    this.fgoi.Show();
                }
            }
            //System.Threading.Thread.Sleep(1000);
            m.goi_dangky(ngaysrv, i_userid, tu.Value.ToString(), den.Value.ToString(), true);
        }

        private void butGoilai_Click(object sender, EventArgs e)
        {
            m.goi_dangky(ngaysrv, i_userid, tu.Value.ToString(), den.Value.ToString(), false);
        }
        private void cannang_Validated(object sender, System.EventArgs e)
        {
            tinh_bmi();
        }

        private void chieucao_Validated(object sender, System.EventArgs e)
        {
            tinh_bmi();
            if (bDangky_bsbv) bacsy.Focus();
            else if (khamthai.Visible) para1.Focus();
            else if (bSuagiakham) dongia.Focus();
            else if (pmien.Visible) lydomien.Focus();
            else butLuu.Focus();
        }

        private void tinh_bmi()
        {
            decimal cn = (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0;
            decimal cc = (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0;
            decimal _bmi = 0;
            if (cn != 0 && cc != 0) _bmi = cn/ (cc/100 * cc/100);
            else _bmi = 0;
            bmi.Text = _bmi.ToString("####0.00");
        }

        private void linthe_Click(object sender, EventArgs e)
        {
            DataRow r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            string so = r1["makp"].ToString(), ten = tenkp.Text.Trim().ToUpper();
            int p1 = ten.IndexOf("(");
            if (p1 != -1)
            {
                if (ten.IndexOf(")") != -1)
                {
                    so = ten.Substring(p1 + 1);
                    if (so.IndexOf(" ") != -1)
                    {
                        so = so.Substring(so.IndexOf(" ") + 1);
                        so = so.Substring(0, so.Length - 1);
                    }
                }
                ten = ten.Substring(0, p1 - 1);
            }
            dsthe.Tables[0].Rows[0]["syt"] = m.Syte;
            dsthe.Tables[0].Rows[0]["bv"] = m.Tenbv;
            dsthe.Tables[0].Rows[0]["diachibv"] = m.Diachi;
            dsthe.Tables[0].Rows[0]["ngayin"] = m.Ngayhienhanh;
            dsthe.Tables[0].Rows[0]["nguoiin"] = s_userid;
            dsthe.Tables[0].Rows[0]["ghichu"] = "PHÒNG SỐ : " + so;
            dsthe.Tables[0].Rows[0]["lien"] = "SỐ : " + sovaovien.Text;
            dsthe.Tables[0].Rows[0]["mabn"] = f_get_mabn();// mabn2.Text + mabn3.Text;
            dsthe.Tables[0].Rows[0]["hoten"] = hoten.Text;
            dsthe.Tables[0].Rows[0]["namsinh"] = namsinh.Text;
            dsthe.Tables[0].Rows[0]["tuoi"] = tuoi.Text + " " + loaituoi.Text;
            dsthe.Tables[0].Rows[0]["gioitinh"] = phai.SelectedIndex.ToString();
            dsthe.Tables[0].Rows[0]["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            dsthe.Tables[0].Rows[0]["ngaykham"] = ngayvv.Text;
            dsthe.Tables[0].Rows[0]["lydokham"] = ten;
            dsthe.Tables[0].Rows[0]["nghenghiep"] = tennn.Text;
            dsthe.Tables[0].Rows[0]["doituong"] = tendoituong.Text;
            dsthe.Tables[0].Rows[0]["sothe"] = sothe.Text;
            dsthe.Tables[0].Rows[0]["tungay"] = tungay.Text;
            dsthe.Tables[0].Rows[0]["denngay"] = denngay.Text;
            dsthe.Tables[0].Rows[0]["dantoc"] = tendantoc.Text;
            if (pathImage == "") dsthe.Tables[0].Rows[0]["image"] = (byte[])(pic.Tag);
            else
            {
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                //map = new Bitmap(Image.FromStream(fstr));
                //pic.Image = (Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                dsthe.Tables[0].Rows[0]["image"] = image;
            }
            if (barcode.Visible)
            {
                if (!System.IO.Directory.Exists("..//barcode")) System.IO.Directory.CreateDirectory("..//barcode");
                //barcode.Picture.Save("..//barcode//barcode.bmp");
                fstr = new System.IO.FileStream("..//barcode//barcode.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                dsthe.Tables[0].Rows[0]["barcode"] = image;
            }
            if (chkxml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                dsthe.WriteXml("..//xml//phieuthe.xml", XmlWriteMode.WriteSchema);
            }
            if (chkXem.Checked)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(dsthe, "", "", "m_phieuthe.rpt");
                f.ShowDialog(this);
            }
            else print.Printer(dsthe, "m_phieuthe.rpt", "", "", 0);
        }

        private void lbienlaithe_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            if (kyhieu.SelectedIndex == -1)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Chọn ký hiệu biên lai !"), LibMedi.AccessData.Msg);
                kyhieu.Focus();
                return;
            }
            DataRow r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            if (r1 != null)
            {
                string ngay = ngayvv.Text + " " + giovv.Text;
                l_maql = m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(),ngay);
                if (l_maql == 0)
                {
                    MessageBox.Show(
lan.Change_language_MessageText("Thông tin đăng ký chưa cập nhật !"), LibMedi.AccessData.Msg);
                    if (butLuu.Enabled) butLuu.Focus();
                    else mabn2.Focus();
                    return;
                }
                l_id = m.get_id_vienphi(ngay,l_maql,imavp_the,v.iNgoaitru);
                bNew = l_id == 0;
                if (l_id == 0)
                {
                    if (l_id == 0) m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "v_vienphill"), i_userid, "ins");
                    l_id = v.get_id_vienphi;
                }
                else
                {
                    foreach (DataRow r in m.get_data("select sobienlai from " + user + m.mmyy(ngay) + ".v_vienphill where id=" + l_id).Tables[0].Rows)
                        sobienlai.Text = r["sobienlai"].ToString();
                }
                in_bienlaithe(l_id, l_maql, ngay, r1["makp"].ToString(), r1["tenkp"].ToString(), imavp_the);
            }
        }

        private decimal upd_data_the(decimal id, int _mavp, int stt, string kp)
        {
            decimal dongia = 0,mien=0;
            int _madoituong = (madoituong.Text=="1")?m.iTunguyen:int.Parse(madoituong.Text);
            DataRow r = m.getrowbyid(dtgia, "id=" + _mavp);
            if (r != null)
            {
                if (m.bNuocngoai(f_get_mabn()))//(mabn2.Text + mabn3.Text))
                    dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                else
                {
                    string gia = m.field_gia(_madoituong.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    dongia = decimal.Parse(r[gia].ToString());
                }
                if (_madoituong==1) mien = (r["bhyt"].ToString() == "0") ? 0 : dongia;
                else if (m.mien_doituong(_madoituong, dtdt)) mien = dongia;
                if (mien == dongia) _madoituong = m.iTunguyen;
                v.upd_vienphict(ngayvv.Text + " " + giovv.Text, id, stt, _madoituong, _mavp, r["ten"].ToString(), 1, dongia,0, 0, 0, "", kp);
            }
            return dongia;
        }

        private void in_bienlaithe(decimal id, decimal maql, string ngay, string kp, string tkp, int mavp)
        {
            //decimal gia = 0;
            string nguoithu = s_userid;
            string lydo = "";
            DataRow r = m.getrowbyid(dtuser, "id=" + i_useridvp);
            if (r != null) nguoithu = r["hoten"].ToString();
            r = m.getrowbyid(dtgia, "id=" + imavp_the);
            if (r != null) lydo = r["ten"].ToString();
            v.upd_vienphill(id, decimal.Parse(kyhieu.SelectedValue.ToString()), decimal.Parse(sobienlai.Text), ngay, f_get_mabn(), l_maql, l_maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, i_useridvp, "");
            d_dongia = upd_data_the(id, mavp, 1, kp);
            if (d_dongia != 0)
            {
                if (bKyhieu_chung && bNew) sobienlai.Text = m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()), true).ToString();
                else if (bNew) m.upd_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()), int.Parse(sobienlai.Text));
            }
            v.upd_vienphill(id, decimal.Parse(kyhieu.SelectedValue.ToString()), decimal.Parse(sobienlai.Text), ngay, f_get_mabn(), l_maql, l_maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, i_useridvp, "");
            if (d_dongia != 0)
            {
                dsxml.Clear();
                DataRow r1;
                for (int i = 0; i < dslien.Tables[0].Rows.Count; i++)
                {
                    r1 = dsxml.Tables[0].NewRow();
                    r1["syt"] = m.Syte;
                    r1["bv"] = m.Tenbv;
                    r1["diachibv"] = m.Diachi;
                    r1["tongcucthue"] = "";
                    r1["cucthue"] = "";
                    r1["masothue"] = v.Masothue;
                    r1["mauso"] = v.Mausobienlai;
                    r1["nguoiin"] = s_userid;
                    r1["ngaysinh"] = ngaysinh.Text;
                    r1["gioitinh"] = phai.Text;
                    r1["quyenso"] = kyhieu.Text;
                    r1["sobienlai"] = sobienlai.Text;
                    r1["hoten"] = hoten.Text;
                    r1["mabn"] = f_get_mabn();// mabn2.Text + mabn3.Text;
                    r1["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
                    r1["khoa"] = tkp;
                    r1["lydo"] = lydo;
                    r1["sotien"] = d_dongia.ToString();
                    r1["chutien"] = doiso.doiraso(d_dongia.ToString());
                    r1["diengiai"] = lydo;
                    r1["ghichu"] = lydo;
                    r1["ngayin"] = ngayvv.Text.Substring(0, 10);
                    r1["lien"] = dslien.Tables[0].Rows[i]["ten"].ToString();
                    r1["nguoithu"] = nguoithu;
                    dsxml.Tables[0].Rows.Add(r1);
                }
                sobienlai.Text = m.get_sobienlai(decimal.Parse(kyhieu.SelectedValue.ToString()), 1).ToString();
                m.updrec(dtkh, decimal.Parse(kyhieu.SelectedValue.ToString()), sobienlai.Text);
                if (bDocmavach)
                {
                    if (!System.IO.Directory.Exists("c://reportpic")) System.IO.Directory.CreateDirectory("c://reportpic");
                    //barcode.Picture.Save("c://reportpic//barcode.bmp");
                }
                if (chkXem.Checked)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(dsxml, s_userid, sovaovien.Text, "v_bienlaithuvienphi.rpt");
                    f.ShowDialog(this);
                }
                else
                {
                    print.Printer(dsxml, "v_bienlaithuvienphi.rpt", s_userid, sovaovien.Text, 0);
                    m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".v_vienphill set lanin=lanin+1 where id=" + l_id);
                }
            }
            
        }

        private void bacsy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbs1.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (bacsy.Text != "")
                {
                    sql = "ten like '%" + bacsy.Text.Trim() + "%'";
                    DataRow[] dr = dtbs1.Select(sql);
                    if (dr.Length == 1)
                    {
                        bacsy.Text = dr[0]["ten"].ToString();
                        benhvien.Text = dr[0]["benhvien"].ToString();
                        SendKeys.Send("{Tab}");
                    }
                    else if (listbs1.Visible) listbs1.Focus();
                    else SendKeys.Send("{Tab}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void bacsy_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == bacsy)
            {
                Filt_bacsy(bacsy.Text);
                listbs1.BrowseToDmnx(bacsy, bacsy, benhvien, 200);
            }
        }

        private void bacsy_Validated(object sender, EventArgs e)
        {
            if (!listbs1.Focused) listbs1.Hide();
        }

        private void Filt_bacsy(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listbs1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%'";
        }

        private void benhvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbv.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (benhvien.Text != "")
                {
                    sql = "ten like '%" + benhvien.Text.Trim() + "%'";
                    DataRow[] dr = dtbv.Select(sql);
                    if (dr.Length == 1)
                    {
                        benhvien.Text = dr[0]["ten"].ToString();
                        if (bSuagiakham) dongia.Focus();
                        else if (pmien.Visible) lydomien.Focus();
                        else butLuu.Focus();
                    }
                    else if (listbv.Visible) listbv.Focus();
                    else if (bSuagiakham) dongia.Focus();
                    else if (pmien.Visible) lydomien.Focus();
                    else butLuu.Focus();
                }
                else
                {
                  if (bSuagiakham) dongia.Focus();
                  else if (pmien.Visible) lydomien.Focus();
                  else butLuu.Focus();
                }
            }
        }

        private void benhvien_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == benhvien)
            {
                Filt_ten(benhvien.Text, listbv);
                if (bSuagiakham) listbv.BrowseToThon(benhvien, benhvien, dongia);
                else if (pmien.Visible) listbv.BrowseToThon(benhvien, benhvien, lydomien);
                else listbv.BrowseToThon(benhvien, benhvien, butLuu);
            }
        }

        private void Filt_ten(string ten, LibList.List list)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%'";
        }

        private void benhvien_Validated(object sender, EventArgs e)
        {
            if (!listbv.Focused) listbv.Hide();
        }

        private void listbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || benhvien.Text == "")
            {
                DataRow r = m.getrowbyid(dtbs1, "ten='" + bacsy.Text + "'");
                if (r != null) benhvien.Text = r["benhvien"].ToString();
            }
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtnkp.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "Chọn";
            discontinuedCol.Width = 30;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Phòng khám";
            TextCol.Width = (bnmoi.Enabled)?135:185;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "taikham";
            discontinuedCol.HeaderText = (bnmoi.Enabled)?"Tái khám":"";
            discontinuedCol.Width = (bnmoi.Enabled)?50:0;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);
        }
        
        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
            this.dataGrid1.Invalidate(rect);
        }

        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
                this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            afterCurrentCellChanged = true;
        }

        private void dataGrid1_Click(object sender, System.EventArgs e)
        {
            Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
            BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            if (afterCurrentCellChanged && hti.Row < bmb.Count
                && hti.Type == DataGrid.HitTestType.Cell
                && hti.Column == checkCol)
            {
                this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                RefreshRow(hti.Row);
            }
            afterCurrentCellChanged = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null) return;
			l_maql=m.get_maql_tiepdon(s_mabn,r1["makp"].ToString(),ngayvv.Text+" "+giovv.Text);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            frmTusat f = new frmTusat(l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid);
            f.ShowDialog();
        }

        private void tbutvantay_Click(object sender, EventArgs e)
        {
            if (bVantay) lay_mabn_vantay();
        }

        private void chkNgoaitru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, f_get_mabn(), hoten.Text, namsinh.Text, phai.Text);
            f.ShowDialog();
        }

        private void chkBHYT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkBhyt)
            {
                m.writeXml("thongso", "c345", (chkBhyt.Checked) ? "1" : "0");
                //mathe.Enabled = bSothe_dmbhyt && chkBhyt.Checked;
                mathe.Enabled = bBHYT_QRCode_Dangky || (bSothe_dmbhyt && chkBhyt.Checked);
            }
        }
        private void mathe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}");
        }

        private void mathe_Validated(object sender, System.EventArgs e)
        {
            if (mathe.Text != "" && bBHYT_QRCode_Dangky == false)
            {
                string _mabn = "";
                DataTable tmp = m.getdmthe("", mathe.Text, (ngayvv.Text != "") ? ngayvv.Text : m.Ngayhienhanh).Tables[0];
                foreach (DataRow r in tmp.Rows)
                {
                    _mabn = r["mabn"].ToString();
                    mathe.Text = r["sothe"].ToString();
                    if (_mabn == "")
                    {
                        hoten.Text = r["hoten"].ToString();
                        hoten.Tag = r["hoten"].ToString();
                        namsinh.Text = r["namsinh"].ToString();
                        namsinh.Tag = namsinh.Text;
                        tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                        loaituoi.SelectedIndex = 0;
                        phai.SelectedIndex = int.Parse(r["gioitinh"].ToString());
                        thon.Text = r["diachi"].ToString();
                        cholam.Text = r["cholam"].ToString();
                        tentinh.SelectedValue = r["matt"].ToString();
                        load_quan();
                        tenquan.SelectedValue = r["maqu"].ToString();
                        load_pxa();
                        tenpxa.SelectedValue = r["maphuongxa"].ToString();
                        madoituong.Text = "1"; tendoituong.SelectedValue = "1";
                        sothe.Text = mathe.Text;                        
                        mabv.Text = r["mabv"].ToString();
                        tenbv.Text = r["tenbv"].ToString();
                        tungay.Text = r["tungay"].ToString();
                        denngay.Text = r["denngay"].ToString();
                    }
                    break;
                }
                if (_mabn != "")
                {
                    s_mabn = _mabn;
                    if (s_mabn.Length > 8)
                    {
                        mabn1.Text = _mabn.Substring(0, 2);
                        mabn2.Text = _mabn.Substring(2, 2);
                        mabn3.Text = _mabn.Substring(4);
                    }
                    else
                    {

                        mabn2.Text = _mabn.Substring(0, 2);
                        mabn3.Text = _mabn.Substring(2);
                    }
                    load_mabn();
                    giovv.Focus();// ngayvv.Focus();
                }
                else
                {
                    sothe.Text = mathe.Text;                    
                    tendoituong.SelectedValue = "1"; madoituong.Text = "1";
                }
            }
            else if (bBHYT_QRCode_Dangky)
            {
                //xu ly the QR code cua BHYT
                if (mathe.Text.Trim() == "") return;
                f_split_QRCode_BHYT(mathe.Text);
                tendoituong.Enabled = madoituong.Enabled = s_QRcode_sothe == "";
                mathe.Enabled = false;
                try
                {
                    if (sothe.Text.Length >2 && sothe.Text.Substring(0,2) == "HS")
                    {
                        mann.Text = "02";
                    }
                    else
                    {
                        mann.Text = "99";
                    }
                    tennn.SelectedValue = mann.Text;
                    mann.Focus();
                }
                catch { }
            }
        }
        private void f_split_QRCode_BHYT(string a_QRCode)
        {
            if (a_QRCode == "") return;
            if (a_QRCode.IndexOf('$') <= 0) return;

            string[] arr_QRCode = a_QRCode.Split('|');
            int a_length = arr_QRCode.Length;
            //
            if (a_length > 0) s_QRcode_sothe = arr_QRCode[0].ToString().Length == 15 ? arr_QRCode[0] + arr_QRCode[5].Trim().Replace("-", "").Replace(" ", "") : arr_QRCode[0];
            if (a_length > 1) s_QRcode_Hoten = ConvertHexToString(arr_QRCode[1]);
            if (a_length > 2) s_QRcode_ngaysinh = arr_QRCode[2];
            if (a_length > 3) s_QRcode_gioitinh = arr_QRCode[3];
            if (a_length > 4) s_QRcode_diachi = ConvertHexToString(arr_QRCode[4]);
            if (a_length > 5) s_QRcode_mabv = arr_QRCode[5].Trim().Replace("-", "").Replace(" ", "");
            if (a_length > 6) s_QRcode_tungay = arr_QRCode[6];
            if (a_length > 7) s_QRcode_denngay = arr_QRCode[7];
            if (a_length > 8) s_QRcode_ngaycap = arr_QRCode[8];
            if (a_length > 9) s_QRcode_MaQLBHXH = arr_QRCode[9];
            if (a_length > 10) s_QRcode_KiemTraBHXH = arr_QRCode[10];

            //
            //            
            string a_qrcode_mabn = f_TimMSBN_From_QRCode_BHYT(s_QRcode_sothe, s_QRcode_mabv, s_QRcode_tungay, s_QRcode_denngay);
            if (a_qrcode_mabn.Trim().Length >= 8)
            {
                mabn2.Text = a_qrcode_mabn.Substring(0, 2);
                if (a_qrcode_mabn.Trim().Length > 8)
                {
                    mabn1.Text = a_qrcode_mabn.Substring(2, 2);//chi nhanh
                    mabn3.Text = a_qrcode_mabn.Substring(4, 6);
                }
                else
                {
                    mabn3.Text = a_qrcode_mabn.Substring(2).PadLeft(6, '0');
                }
                mabn3_Validated(null, null);
            }

            hoten.Text = s_QRcode_Hoten;
            if (s_QRcode_gioitinh == "1") phai.SelectedIndex = 0;
            else if (s_QRcode_gioitinh == "2") phai.SelectedIndex = 1;
            cholam.Text = s_QRcode_diachi;
            //
            if (s_QRcode_ngaysinh.Length == 10)
            {
                ngaysinh.Text = s_QRcode_ngaysinh;
                if (a_qrcode_mabn == "") ngaysinh_Validated(null, null);
            }
            else
            {
                namsinh.Text = s_QRcode_ngaysinh.Substring(s_QRcode_ngaysinh.Length - 4);
                if (a_qrcode_mabn == "") namsinh_Validated(null, null);
            }
            //
            if (s_QRcode_sothe.Length >= 15)
            {
                madoituong.Text = "1";
                madoituong_Validated(null, null);
                sothe.Text = s_QRcode_sothe;                
            }
            tungay.Text = s_QRcode_tungay;
            denngay.Text = s_QRcode_denngay;
            mabv.Text = s_QRcode_mabv;
            mabv_Validated(null, null);
            sothe_Validated(null, null);
            //
            if (mabn3.Text == "")  // khong tim thay thi cap masb moi
            {
                mabn3_Validated(null, null);
            }
            //
            //
        }

        private string f_TimMSBN_From_QRCode_BHYT(string a_sothe, string a_mabv, string a_tungay, string a_denngay)
        {
            string amabn = "";
            string asql = "";
            DataSet ads;
            asql = " select mabn from medibv.bhyt_qrcode where sothe='" + a_sothe + "' and mabv='" + a_mabv + "' and to_char(tungay,'dd/mm/yyyy')='" + a_tungay + "' and to_char(denngay,'dd/mm/yyyy')='" + a_denngay + "'";
            ads = m.get_data(asql);
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                amabn = ads.Tables[0].Rows[0]["mabn"].ToString();
            }
            else
            {
                string tmp_sothe = a_sothe;
                if (tmp_sothe.Length == 15) tmp_sothe = tmp_sothe + a_mabv;
                asql = " select a.mabn from xxx.bhyt a inner join medibv.btdbn b on a.mabn=b.mabn and b.hide=0 where sothe='" + tmp_sothe + "' and mabv='" + a_mabv + "'";
                ads = m.get_data_mmyy(asql, a_tungay, a_denngay, false);
                if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                {
                    amabn = ads.Tables[0].Rows[0]["mabn"].ToString();
                }
            }
            return amabn;
        }

        string ConvertHexToString(String hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            string result = System.Text.Encoding.UTF8.GetString(bytes);
            return result;
        }

        private void ngay1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (sothe.Text != "" && ngay1.Text!="")
                {
                    ngay1.Text = ngay1.Text.Trim();
                    if (ngay1.Text.Length == 6) ngay1.Text = ngay1.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay1.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay1.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay2_Validated(object sender, EventArgs e)
        {
            try
            {
                if (sothe.Text != "" && ngay2.Text!="")
                {
                    ngay2.Text = ngay2.Text.Trim();
                    if (ngay2.Text.Length == 6) ngay2.Text = ngay2.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay2.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay2.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay3_Validated(object sender, EventArgs e)
        {
            try
            {
                if (sothe.Text != "" && ngay3.Text!="")
                {
                    ngay3.Text = ngay3.Text.Trim();
                    if (ngay3.Text.Length == 6) ngay3.Text = ngay3.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay3.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay3.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkView)
            {
                if (chkView.Checked) load_grid();
                m.writeXml("thongso", "tttiepdon", (chkView.Checked) ? "1" : "0");
            }
        }

        public void chkViewClick()
        {
            chkBHYT_CheckedChanged(null, null);
        }

        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtv.TableName;
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
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Phòng khám";


            TextCol.Width = 120;

                        
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongso";
            TextCol.HeaderText = "T.Số";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chua";
            TextCol.HeaderText = "Chưa";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dichvu";
            TextCol.HeaderText = "CLS";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "xong";
            TextCol.HeaderText = "Đã";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        private void load_grid()
        {
            string _ngay=m.Ngaygio_hienhanh,mmyy = m.mmyy(_ngay);
            if (m.bMmyy(mmyy))
            {
                string xxx = user + mmyy;
                sql = "select b.tenkp,sum(1) as tongso,sum(case when a.done is null or a.done='c' then 1 else 0 end) as chua,";
                sql += "sum(case when a.done='?' then 1 else 0 end) as dichvu,sum(case when a.done is not null and a.done<>'c' then 1 else 0 end) as xong ";
                sql += " from " + xxx + ".tiepdon a," + user + ".btdkp_bv b where a.makp=b.makp and a.noitiepdon in (0,1,5) and b.loai=1";//dang ky, PK chuyen kham (hoac PK nhap truc tiep), khoa chi dinh di kham
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + _ngay.Substring(0,10) + "'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                //if (makp.SelectedIndex != -1) sql += " and a.makp='" + makp.SelectedValue.ToString() + "'";
                //if (madoituong.SelectedIndex != -1) sql += " and a.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";
                sql += " group by b.tenkp order by b.tenkp";
                dtv = m.get_data(sql).Tables[0];
                dataGrid2.DataSource = dtv;
            }
            if (!bGrid) AddGridTableStyle1();
            lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
            bGrid = true;
        }

        private void traituyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tenkp_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenkp )
            {
                Filt_tenkp(tenkp.Text);
                listKP.BrowseToICD10(tenkp, makp, (sovaovien.Enabled) ? sovaovien : (madstt.Enabled) ? madstt : madoituong, giovv.Location.X, giovv.Location.Y + giovv.Height,giovv.Width+ makp.Width + tenkp.Width + 50, makp.Height);
            }
        }

        private void Filt_tenkp(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listKP.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void chkChenhlechcongkham_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "chenhlechcongkham", (chkChenhlechcongkham.Checked) ? "1" : "0");
            
        }

        private void thôngTinTiếpĐónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblLCD_Click(object sender, EventArgs e)
        {
            new frmThongsoLCD(this.m).ShowDialog();
        }

        private void chkLCD_Click(object sender, EventArgs e)
        {
            this.m.writeXml("thongso", "tdlcd", this.chkLCD.Checked ? "1" : "0");
        }

        private void capnhat_db_tiepdon()
        {
            string xxx = user + m.mmyy(m.ngayhienhanh_server);
            sql = "Select idchidinh from " + xxx + ".tiepdon where 1=2";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + m.mmyy(m.ngayhienhanh_server) + ".tiepdon add idchidinh numeric default 0";
                m.execute_data(sql);
            }
        }

        private void tmn_bienlaikhongdong_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "dangky_inbienlai0dong", tmn_bienlaikhongdong.Checked ? "1" : "0");
            bBienlai_mien = tmn_bienlaikhongdong.Checked;            
        }

      
        private void f_load_option()
        {
            bDocmavach = m.bDocmavach;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            i_maxlength_makp = LibMedi.AccessData.i_maxlength_makp ;
            mabn3.MaxLength = i_maxlength_mabn - 2;
            bQuanLyChiNhanh = m.bQuanly_Theo_Chinhanh;//Thuy 02.06.2012
            if (!bQuanLyChiNhanh)
            {
                mabn3.Left = mabn1.Left;
                mabn3.Width = mabn3.Width + 2 + mabn1.Width;
                mabn1.Visible = false;
            }
            else 
            {
                mabn1.Visible = true;
                mabn1.Enabled = true;
            }
            if (bDocmavach)
            {
                mabn1.MaxLength = i_maxlength_mabn;
                mabn2.MaxLength = i_maxlength_mabn;
                mabn3.MaxLength = i_maxlength_mabn;
            }
            else
            {
                mabn2.MaxLength = 2;
                if (i_maxlength_mabn == 8)
                {
                    mabn3.MaxLength = i_maxlength_mabn - 2;
                    mabn3.Left = mabn1.Left;
                    mabn3.Width = mabn3.Width + 2 + mabn1.Width;
                    
                }
                else
                {
                    if (bQuanLyChiNhanh)
                    {
                        mabn1.Visible = i_maxlength_mabn > 8;//nhap id chi nhanh
                        mabn1.Enabled = i_maxlength_mabn > 8;
                        if (bDocmavach)
                        {
                            mabn1.MaxLength = i_maxlength_mabn;
                            mabn2.MaxLength = i_maxlength_mabn;
                            mabn3.MaxLength = i_maxlength_mabn;
                        }
                        else
                        {
                            mabn1.MaxLength = 2;
                            mabn2.MaxLength = 2;
                            mabn3.MaxLength = i_maxlength_mabn - 4;
                        }
                    }
                }
            }
            //
            bTraituyen = m.bTraituyen;
            cl_cholam = m.mien_chenhlech_cholam.Trim().ToLower();
            cl_tyle = m.mien_chenhlech; bNgoaitru_k_khambenh = m.bNgoaitru_k_khambenh;
            cl_doituong = m.mien_chenhlech_doituong;
            bTiepdon_n_makp_chung_chiphi = m.bTiepdon_n_makp_chung_chiphi;
            bBhyt_mien_trasau_ck_chidinh = m.bBhyt_mien_trasau_ck_chidinh;
            iChuyendoituong1 = m.iChuyendoituong1; iChuyenmavp = m.iChuyenmavp; iChuyendoituong2 = m.iChuyendoituong2;
            bChuyendoituong = m.bChuyendoituong; bKyhieu_may = m.bKyhieu_may; bDangky_bsbv = m.bDangky_bsbv;
            bBienlai_mien = m.bBienlai_mien; bSothe_dmbhyt = m.bSothe_dmbhyt;
            bQuanlinvsale = m.bQuanlyNVsale;

            chkBhyt.Enabled = bSothe_dmbhyt; bSothe_ngay_huong = m.bSothe_ngay_huong;
            mavp_kem_chidinh = m.mavp_kem_chidinh;
            makp_kem_chidinh = m.makp_kem_chidinh;
            bMien_congkham_cholam = m.bMien_congkham_cholam;
            bSothe_dkkcb = m.bSothe_dkkcb;
            bTiepdon_nkp_inchungchiphi = m.bTiepdon_nkp_inchungchiphi;//c47


            bBH_chitra_1congkham = m.bBH_chitra_1congkham;
            bBH_chitra_1congkham_conlaikhongtinh_G79_1 = m.bBH_chitra_1congkham_conlaikhongtinh_G79_1;
            bBH_chitra_1congkham_conlai_dttunguyen_G79_2 = m.bBH_chitra_1congkham_conlai_dttunguyen_G79_2;//binh 200711
            s_matinh_bhyt = m.s_matinh_bhyt;
            s_vitri_matinh_bhyt = m.s_vitri_matinh_bhyt;
            bChuyenkham_pkthu2_giataikham = m.bChuyenkham_pkthu2_giataikham;
            bChuathanhtoan_khongcho_dangkykham = m.bChuathanhtoan_khongcho_dangkykham;
            bVantay_batbuot = m.bVantay_batbuot;
            bAdmin_hethong = m.bAdminHethong(i_userid);
            bLoadQuanhe_lantruoc = m.bLoadQuanhe_lantruoc;
            bChenhlechPK_chitinh_vaongaynghi = m.bChenhlechPK_chitinh_vaongaynghi;
            bXoaTrong_NoiDK_KCB_bandau = m.bXoaTrong_NoiDK_KCB_bandau;
            bMabn_tudong_tu_ServerInterNet_D24 = m.bMabn_tudong_tu_ServerInterNet_D24;
            butget_msbn_from_internet.Visible = bMabn_tudong_tu_ServerInterNet_D24;
            bMabn_tudong_theomay = m.bMSBN_Tudong_Theomay;
            bBHYT_Phanbiet_NVBenhvien = m.bBHYT_Phanbiet_NVBenhvien;
            chkNhanvienbv.Visible = bBHYT_Phanbiet_NVBenhvien;

            
            chkTrungcao.Enabled = m.bE27_Quanly_bnTrungcao;
            thetrungcao.Enabled = chkTrungcao.Checked;
            bChenhlech_laygiaphuthu = m.bChenhlech_laygiaphuthu;
            cmbLoaitg.Visible = bChenhlech_laygiaphuthu;//binh 110711
                        
            chkChenhlechcongkham.Visible = m.bChenhlech  && m.bCongkham_Chenhlech_nguoidungchon_khidangky;
            chkChenhlechcongkham.Checked = m.bChenhlech;// m.Thongso("chenhlechcongkham") == "1";
            bCongthucchenhlech = m.bCongthucchenhlech;//gam 11/01/2011
            bKhacbv_traituyen_pk2 = m.bKhacbv_traituyen_pk2;//gam 12/01/2012
            bBHYT_QRCode_Dangky = m.bBHYT_QRCode_Dangky;
            mathe.MaxLength = (bBHYT_QRCode_Dangky) ? 20000 : 20;
            bnKhamBHYTmotlantrongngay = m.bnKhamBHYTmotlantrongngay;// E34

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_mabn"></param>
        /// <param name="m_ngay"></param>
        /// <returns>1 Vua kham xong trong ngay, 2 vua ra cung ngay dieu tri noi tru, ngoai tru ,</returns>
        private int f_kiemtrabndakhamtrongngay( string m_mabn, string m_ngay  )
        {
            string s_sql = "";
            s_sql = " select  mabn from xxx.bhytkb where mabn='"+m_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
           DataSet ds1 = new DataSet();
            ds1 = m.get_data_mmyy(s_sql, m_ngay, m_ngay, true);
            int i_trangthaikham = 0;
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                i_trangthaikham = 1;
            }
            else
            {
                s_sql = " select  to_number('2') as trangthai ,mabn from medibv.benhandt a left join  medibv.xuatvien b on a.maql=b.maql  where a.mabn='" + m_mabn + "' and (to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay + "' or b.ngay is null) ";
                s_sql += " union all ";
                s_sql += " select  to_number('2') as trangthai ,mabn from medibv.benhanngtr a left join  medibv.xuatvien b on a.maql=b.maql  where a.mabn='" + m_mabn + "' and (to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay + "' or b.ngay is null) ";
                ds1 = m.get_data(s_sql);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    i_trangthaikham = 2;
                }
                else
                    i_trangthaikham = 0;
            }
            return i_trangthaikham;
    
        }
        private bool f_b_dacocongkham(string mavaovien, string maql)
        {
            string xxx = m.user + m.mmyy(ngayvv.Text);
            string asql = "select maql from " + xxx + ".tiepdon where maql<>" + maql + " and mavaovien=" + mavaovien;
            DataSet lds = new DataSet();
            lds = m.get_data(asql);
            return lds.Tables[0].Rows.Count > 0;
        }

        private bool f_b_dacocongkham(string mabn, string maql, string ngay)
        {
            string xxx = m.user + m.mmyy(ngayvv.Text);
            string asql = "select maql from " + xxx + ".tiepdon where maql<>" + maql + " and mabn='" + mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and makp not in('00')";
            DataSet lds = new DataSet();
            lds = m.get_data(asql);
            return lds.Tables[0].Rows.Count > 0;
        }
        /// <summary>
        /// Xac dinh trong ngay BN da co cong kham chua?
        /// </summary>
        /// <param name="mabn"></param>
        /// <param name="maql"></param>
        /// <param name="ngay"></param>
        /// <param name="s_mapk"></param>
        /// <returns></returns>
        private bool f_b_dacocongkham(string mabn, string maql, string ngay, string s_mapk)
        {
            string s_user = m.user;
            string xxx = m.user + m.mmyy(ngayvv.Text);
            string asql = "select maql from " + xxx + ".tiepdon a, " + s_user + ".btdkp_bv b where a.makp=b.makp and a.maql<>" + maql + " and a.mabn='" + mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and a.makp not in('00')";
            //if (s_mapk.Trim().Trim(',') != "") asql += " and a.makp not in('" + s_mapk.Trim().Trim(',').Replace(",", "','") + "')";
            if (s_mapk.Trim().Trim(',') != "") asql += " and b.viettat not in('" + s_mapk.Trim().Trim(',').Replace(",", "','") + "')";
            if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";
            
            DataSet lds = new DataSet();
            lds = m.get_data(asql);
            if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
            {
                string tmp_maql = "";
                string s_mavp_pk = m.f_get_mavp_congkham();
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    tmp_maql += r["maql"].ToString() + ",";
                }
                asql = "select mavp from " + xxx + ".v_chidinh where maql in(" + tmp_maql.Trim().Trim(',') + ") and mabn='" + mabn + "'";
                lds = m.get_data(asql);                
            }
            return lds.Tables[0].Rows.Count > 0;
        }

      

        private void butget_msbn_from_internet_Click(object sender, EventArgs e)
        {
            if (mabn3.Text.Trim() != "") return;
            Cursor = Cursors.WaitCursor;
            //CyberMedisoftServices cms = new CyberMedisoftServices();
            string s_nam = mabn2.Text.PadLeft(2, '0');
            if (s_nam == "") s_nam = DateTime.Now.Year.ToString().Substring(2, 2);
            string ma = "", s_mabn = "";// cms.get_cap_mabn(s_nam);            
            for (; ; )
            {
                try
                {
                    //ma = cms.get_cap_mabn(s_nam);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
                mabn3.Text = ma.Substring(2);
                s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;
                if (m.get_data("select mabn from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
            }
            try
            {
                if (mabn3.Text != "")
                {
                    m.upd_capmabn(int.Parse(s_nam), 0, 0, int.Parse(mabn3.Text));
                }
                mabn3.Focus();
            }
            catch { Cursor = Cursors.Default; }
            Cursor = Cursors.Default;
        }
        public LibMedi.AccessData acc
        {
            get { return m; }
            set { m = value; }
        }
        public string MaKhoaPhong
        {
            get { return s_makp; }
            set { s_makp = value; }
        }
        public string MaDoiTuong
        {
            get { return s_madoituong; }
            set { s_madoituong = value; }
        }
        public string HoTenUser
        {
            get { return s_userid; }
            set { s_userid = value; }
        }
        public int UserID
        {
            get { return i_userid; }
            set { i_userid = value; }
        }
        public int Loai
        {
            get { return i_loai; }
            set { i_loai = value; }
        }
        public int SoHieu
        {
            get { return i_sohieu; }
            set { i_sohieu = value; }
        }
        public int KhuDieuTri
        {
            get { return i_khudt; }
            set { i_khudt = value; }
        }
        public void VisibleControl()
        {
            toolStrip1.Visible = false;
        }

        public int chinhanhid
        {
            get { return i_chinhanh; }
            set { i_chinhanh = value; }
        }

        private void tbutYeucauhoadon_Click(object sender, EventArgs e)
        {
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;

            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
                frmYeucauhoadon f = new frmYeucauhoadon(m, s_mabn, hoten.Text.Trim(), sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text + " " + tenquan.Text + " " + tentinh.Text, txtMsThue.Text.Trim(), decimal.Parse(l_mavaovien_moi.ToString()), i_userid);
                f.ShowDialog();
            }
            else
            {
                if (treeView1.SelectedNode == null)
                {
                    frmYeucauhoadon f1 = new frmYeucauhoadon(m, s_mabn, hoten.Text.Trim(), sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text + " " + tenquan.Text + " " + tentinh.Text, txtMsThue.Text.Trim(), decimal.Parse(l_mavaovien_moi.ToString()), i_userid);
                    f1.ShowDialog();
                    //MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đợt vào đăng ký !"), s_msg);
                    //return;
                }
                else
                {
                    string ngaydcchon = treeView1.SelectedNode.FullPath;
                    if (ngaydcchon == null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đợt vào đăng ký !"), s_msg);
                        return;
                    }
                    sql = "select hoten from " + m.user + ".btdbn where mabn='" + s_mabn + "'";
                    int iPos = ngaydcchon.IndexOf("/");
                    string ngay = ngaydcchon.Substring(iPos - 2, 16);
                    l_maql = m.get_maql(s_mabn, "??", ngay);
                    frmYeucauhoadon f = new frmYeucauhoadon(m, s_mabn, m.get_data(sql).Tables[0].Rows[0][0].ToString().Trim(),sonha.Text.Trim()+" "+thon.Text.Trim()+ " "+tenpxa.Text+" "+tenquan.Text+" "+tentinh.Text,txtMsThue.Text.Trim(), decimal.Parse(m.get_mavaovien_tiepdon(l_maql, m.mmyy(ngay)).ToString()), i_userid);
                    f.ShowDialog();
                }
            }
            //dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text + " " + giovv.Text, r1["makp"].ToString(), tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_maql, l_maql, 0, i_userid, "xxx.tiepdon", sothe.Text, nam, 3, "", "", "", (traituyen.SelectedIndex < 0) ? 0 : traituyen.SelectedIndex);
            //f.ShowDialog(this);
        }

        private void tbutChuphinh_Click(object sender, EventArgs e)
        {
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;

            if (l_maql == 0) 
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
                frmChuphinhchungtu f = new frmChuphinhchungtu( s_mabn,  decimal.Parse(l_mavaovien_moi.ToString()), i_userid);
                f.ShowDialog();
            }
            else
            {
                if (treeView1.SelectedNode == null)
                {
                    frmChuphinhchungtu f = new frmChuphinhchungtu(s_mabn, decimal.Parse(l_mavaovien_moi.ToString()), i_userid);
                    f.ShowDialog();
                    //MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đợt vào đăng ký !"), s_msg);
                    //return;
                }
                else
                {
                    string ngaydcchon = treeView1.SelectedNode.FullPath;
                    if (ngaydcchon == null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đợt vào đăng ký !"), s_msg);
                        return;
                    }
                    //sql = "select hoten from " + m.user + ".btdbn where mabn='" + s_mabn + "'";
                    int iPos = ngaydcchon.IndexOf("/");
                    string ngay = ngaydcchon.Substring(iPos - 2, 16);
                    l_maql = m.get_maql(s_mabn, "??", ngay);
                    frmChuphinhchungtu f = new frmChuphinhchungtu(s_mabn, decimal.Parse(m.get_mavaovien_tiepdon(l_maql, m.mmyy(ngay)).ToString()), i_userid);
                    f.ShowDialog();
                }
            }
        }

        private void chkTrungcao_CheckedChanged(object sender, EventArgs e)
        {
            //sothe.MaxLength = (chkTrungcao.Checked) ? 26 : 20;
            thetrungcao.Enabled = chkTrungcao.Checked;
        }

        private void chkTrungcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        public string f_get_mabn()
        {
            string _mabn = "";
            if (mabn3.Text.Trim() == "") return "";
            _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(6);
            //if (i_maxlength_mabn > 8)
            //{
                if (bQuanLyChiNhanh)
                {
                    _mabn = mabn2.Text.PadLeft(2, '0') + mabn1.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(6,'0');
                }
                else
                {
                    _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(6,'0');
                }
            //}
            return _mabn;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (mabv.Text.Length == 5) m.writeXml("maincode", "Mabvbhyt", mabv.Text);
        }

        private void mabn1_Validated(object sender, EventArgs e)
        {
            if (bDocmavach)
            {
                string s = mabn1.Text;
                if (s.Length == i_maxlength_mabn && i_maxlength_mabn == 8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2);

                    mabn3_Validated(sender, e);
                }
                else if (s.Length == i_maxlength_mabn && i_maxlength_mabn > 8)
                {
                    mabn1.Text = s.Substring(2, 2);//chi nhanh
                    mabn2.Text = s.Substring(0, 2);//yy
                    mabn3.Text = s.Substring(4);

                    mabn3_Validated(sender, e);
                }
            }
            mabn1.Text = mabn1.Text.PadLeft(2, '0');
        }
        private void ena_quanhe(bool ena)
        {
            qh_hoten.Enabled = ena;
            qh_diachi.Enabled = ena;
            qh_dienthoai.Enabled = ena;            
        }

        private void quanhe_TextChanged(object sender, EventArgs e)
        {
            ena_quanhe(quanhe.Text.Trim() != "");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mabn1.Text = "";
            mabn2.Text = "";
            mabn3.Text = "";
            mabn1.MaxLength = 20;
            mabn2.MaxLength = 20;
            mabn3.MaxLength = 20;
            mabn3.Focus();
        }

        private void f_get_tronggio_ngoaigio()
        {
            int giohanhchanh = phanloaiThoigian();
            cmbLoaitg.SelectedValue = giohanhchanh;            
        }

        private int phanloaiThoigian()
        {

            DateTime ngay_1, ngay_2, ngay_3, ngay_4, ngay_5;
            string ngayhethong = m.get_data("select to_char(to_date('" + ngayvv.Text.Trim() + " " + giovv.Text + "','dd/mm/yyyy hh24:mi'),'DY dd/mm/yyyy hh24:mi') from dual").Tables[0].Rows[0][0].ToString();
            //ngayvv.Text.Trim() + " " + giovv.Text;
            // m.get_data("select to_char(sysdate,'DY dd/mm/yyyy hh24:mi') from dual").Tables[0].Rows[0][0].ToString();

            //kiem tra ngay le
            for (int i = 0; i < dtngayle.Rows.Count; i++)
            {
                if (dtngayle.Rows[i]["ngay"].ToString() == ngayhethong.Substring(4, 5))
                {
                    return 3;
                }
            }

            //kiem tra ngay nghi
            for (int i = 0; i < dtngaynghi.Rows.Count; i++)
            {
                if (int.Parse(dtngaynghi.Rows[i]["nghi"].ToString()) == 1 && dtngaynghi.Rows[i]["day"].ToString().ToUpper() == ngayhethong.Substring(0, 3).ToUpper())
                {
                    if (dtngaynghi.Rows[i]["tugio"].ToString().Trim() == "") //neu ko set thoi gian co nghia la ngay nghi do nghi nguyen ngay
                        return 2;
                    else
                    {     //trong gio: nghi nua ngay thu 7
                        ngay_1 = m.StringToDateTime(ngayhethong.Substring(4));
                        ngay_2 = m.StringToDateTime(ngayhethong.Substring(4, 11) + dtngaynghi.Rows[i]["tugio"].ToString());
                        ngay_3 = m.StringToDateTime(ngayhethong.Substring(4, 11) + dtngaynghi.Rows[i]["dengio"].ToString());
                        if (ngay_1 > ngay_2 && ngay_1 < ngay_3) //neu roi vao truong hop nghi nua ngay t7 thi nua ngay la trong gio, nua ngay la ngay nghi
                            return 0;
                        else return 2;
                    }
                }
            }
            DataRow r = m.getrowbyid(dtloaitg, "id=0");
            ngay_1 = m.StringToDateTime(ngayhethong.Substring(4));
            ngay_2 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["tugio_s"].ToString());
            ngay_3 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["dengio_s"].ToString());
            ngay_4 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["tugio_c"].ToString());
            ngay_5 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["dengio_c"].ToString());
            //kiem tra trong gio
            if ((ngay_1 > ngay_2 && ngay_1 < ngay_3) || (ngay_1 > ngay_4 && ngay_1 < ngay_5))
                return 0;
            else return 1;//nguoc la la ngoai gio
        }

        private int f_get_madoituong(int iloaitg)
        {
            sql = "select madoituong from " + user + ".dmloaitg where id=" + iloaitg;
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0) return 0;
            else return int.Parse(lds.Tables[0].Rows[0]["madoituong"].ToString());
        }

        private void sothe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    lblchieudaithe.Text = sothe.Text.Length.ToString();
            //}
            //catch
            //{
            //}
        }

        private void f_load_doituong_dangky(int i_doituong)
        {
            dtdt = new DataTable();
            sql = "select * from " + user + ".doituong ";
            if (i_doituong == 0) sql += " where madoituong<> 5 ";
            else sql += " where madoituong in(1," + i_doituong + ")";
            dtdt = m.get_data(sql).Tables[0];
            tendoituong.DataSource = dtdt;
        }

        private void frmDkkb_chung_Load(object sender, EventArgs e)
        {
            chkBangDienGoiDocLapTheoTungQuay.Checked = m.Thongso(chkBangDienGoiDocLapTheoTungQuay.Name) == "1";
            chklistDTuutien.Visible = false;
        }

        private void mnquanlihinhanhbn_Click(object sender, EventArgs e)
        {
            this.m.writeXml("thongso", "chuphinhbhyt", this.mnquanlihinhanhbn.Checked ? "1" : "0");
        }

        private void mnquanlihinhanhbn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTenBSGioiThieu_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTenBSGioiThieu)
            {
                Filt_tenbsgioithieu(txtTenBSGioiThieu.Text);
                listbsgioithieu.BrowseToDanhmuc_bschidinh(txtMaBSGioiThieu, txtTenBSGioiThieu
                    , madoituong, txtMaBSGioiThieu.Location.X, txtMaBSGioiThieu.Location.Y + txtMaBSGioiThieu.Height
                    , txtMaBSGioiThieu.Width + txtTenBSGioiThieu.Width +2);
                
                listbsgioithieu.Visible = true;
            }
        }

        private void txtTenBSGioiThieu_KeyDown(object sender, KeyEventArgs e)
        {
            madoituong.ReadOnly = false;
            tendoituong.Enabled = true;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbsgioithieu.Focus();
            if (e.KeyCode == Keys.Enter)
            {
                DataRow r = d.getrowbyid(dtbsgioithieu, "mabs='" + txtMaBSGioiThieu.Text+"'");
                if (r != null)
                {
                    txtMaBSGioiThieu.Text = r["mabs"].ToString();
                    txtTenBSGioiThieu.Text = r["ten"].ToString();
                    s_manvsale = r["manv"].ToString();
                    s_mavung = r["idvung"].ToString();
                    madoituong.Text = r["doituong"].ToString();
                    madoituong_Validated(null, null);
                    madoituong.ReadOnly = true;
                    tendoituong.Enabled = false;
                    
                }
                if (listbsgioithieu.Visible) listbsgioithieu.Focus();
                else
                {
                    SendKeys.Send("{Tab}");
                }
                listbsgioithieu.Visible = false;
            }
        }

        private void tenbs_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text);
                if (dausinhton.Visible) listBS.BrowseToICD10(tenbs, mabs, mach, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
                else if (khamthai.Visible) listBS.BrowseToICD10(tenbs, mabs, para1, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
                else if (bSuagiakham) listBS.BrowseToICD10(tenbs, mabs, dongia, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
                else if (pmien.Visible) listBS.BrowseToICD10(tenbs, mabs, lydomien, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
                else listBS.BrowseToICD10(tenbs, mabs, butLuu, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
            }
        }

        private void txtTenBSGioiThieu_Validated(object sender, EventArgs e)
        {
            if (!listbsgioithieu.Focused) listbsgioithieu.Hide();
        }

        private void listbsgioithieu_KeyDown(object sender, KeyEventArgs e)
        {
            madoituong.ReadOnly = false;
            tendoituong.Enabled = true;
            if (e.KeyCode == Keys.Enter)
            {
                DataRow r = m.getrowbyid(dtbsgioithieu, "mabs='" + txtTenBSGioiThieu.Text + "'");
                if (r != null)
                {
                    txtTenBSGioiThieu.Text = r["ten"].ToString();
                    txtMaBSGioiThieu.Text = r["mabs"].ToString();
                    s_mavung = r["idvung"].ToString();
                    s_manvsale = r["manv"].ToString();
                    madoituong.Text = r["doituong"].ToString();
                    madoituong_Validated(null, null);
                    selectedindexchange_tendoituong();
                    madoituong.ReadOnly = true;
                    //madoituong.Enabled = false;
                    tendoituong.Enabled = false;
                    //cbbvungsale.SelectedValue = r["doituong"].ToString();
                }
                listbsgioithieu.Visible = false;
                SendKeys.Send("{Tab}");

            }
        }

        private void txtMaBSGioiThieu_Validated(object sender, EventArgs e)
        {
            if (txtMaBSGioiThieu.Text != "")
            {
                txtTenBSGioiThieu.Text = txtTenBSGioiThieu.Text.PadLeft(4, '0').ToString();
                DataRow r = m.getrowbyid(dtbsgioithieu, "mabs='" + txtMaBSGioiThieu.Text + "'");
                if (r != null) { txtTenBSGioiThieu.Text = r["ten"].ToString();  }
                else { txtTenBSGioiThieu.Text = "";  }
            }
        }

        private void txtMaBSGioiThieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbbvungsale_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ActiveControl != cbbvungsale) return;
            //Load_dmbstheodoituong(int.Parse(cbbvungsale.SelectedValue.ToString()));
        }

        private void chkBangDienGoiDocLapTheoTungQuay_Click(object sender, EventArgs e)
        {
            this.m.writeXml("thongso.xml", this.chkBangDienGoiDocLapTheoTungQuay.Name, this.chkBangDienGoiDocLapTheoTungQuay.Checked ? "1" : "0");
        }

        private void lblDTUuTien_Click(object sender, EventArgs e)
        {
            chklistDTuutien.Visible = !chklistDTuutien.Visible;
            string ten = "";
            for (int i = 0; i < chklistDTuutien.Items.Count; i++)
            {
                if (chklistDTuutien.GetItemChecked(i)) ten += (i + 1).ToString();
            }
            if (ten != "")
            {
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon set doituonguutien=" + ten + " where maql=" + l_maql);
            }
        }

        private void chklistDTuutien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ten = "";
            for (int i = 0; i < chklistDTuutien.Items.Count; i++)
            {
                if (chklistDTuutien.GetItemChecked(i)) ten += (i + 1).ToString() + ",";
            }
            ten = ten.Trim(',');
            string[] sten = ten.Split(',');
            if (sten.Length > 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chỉ được phép chọn 1 loại đối tượng ưu tiên !"), s_msg);
                return;
            }
        }

        private void chklistDTuutien_VisibleChanged(object sender, EventArgs e)
        {
            if (chklistDTuutien.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m.get_data("select doituonguutien from " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".tiepdon where maql="+l_maql);
                if (dstmp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < chklistDTuutien.Items.Count; i++)
                    {
                        chklistDTuutien.SetItemChecked(i, false);
                        if (dstmp.Tables[0].Rows[0]["doituonguutien"].ToString() == (i + 1).ToString()) chklistDTuutien.SetItemChecked(i, true);
                    }
                }
            }
        }
        private bool f_kiemtra_bnhantaikham(string m_mabn, string m_ngaydangky)
        {
            bool bCoHanTaikham = false;
            string s_kphen = "";
            if (m_ngaydangky.Trim() == "") m_ngaydangky = m.ngayhienhanh_server.Substring(0, 10);
            string asql = " select a.makp, b.tenkp ";
            asql += " from xxx.tiepdon a inner join medibv.btdkp_bv b on a.makp=b.makp ";
            asql += " where a.mabn='" + m_mabn + "' and a.noitiepdon=16 and to_char(ngay,'dd/mm/yyyy')='" + m_ngaydangky + "'";
            DataSet ads = m.get_data_mmyy(asql, m_ngaydangky, m_ngaydangky, false);
            //
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ads.Tables[0].Rows)
                {
                    s_kphen = dr["tenkp"].ToString() + " [" + dr["makp"].ToString() + "]";
                }
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã có hẹn tái khám ở phòng") + ": " + s_kphen, "medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bCoHanTaikham = true;
            }
            else
            {
                asql = " select a.makp, b.tenkp ";
                asql += " from medibv.tiepdon a inner join medibv.btdkp_bv b on a.makp=b.makp ";
                asql += " where a.mabn='" + m_mabn + "' and a.noitiepdon=16 and to_char(ngay,'dd/mm/yyyy')='" + m_ngaydangky + "'";
                ads = m.get_data(asql);
                if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                {
                    s_kphen = "";
                    foreach (DataRow dr in ads.Tables[0].Rows)
                    {
                        s_kphen = dr["tenkp"].ToString() + " [" + dr["makp"].ToString() + "]";
                    }
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã có hẹn tái khám ở phòng") + ": " + s_kphen, "medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bCoHanTaikham = true;
                }
                else
                {
                    bCoHanTaikham = false;
                }
            }

            return bCoHanTaikham;
        }

        private void mnuthongtinbodoi_Click(object sender, EventArgs e)
        {
            string a_mabn = f_get_mabn();
            if (s_mabn.Length < 8)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập mã số bệnh nhân."));
                mabn3.Focus();
                return;
            }
            if (l_matd <= 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa đăng ký."));
                mabn3.Focus();
                return;
            }

            //quan ly doi tuong bo doi
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue.ToString());
            if (r["bodoi"].ToString() == "1")
            {
                frmDoiTuongBoDoi f = new frmDoiTuongBoDoi(m, a_mabn, hoten.Text, tuoi.Text, ((sonha.Text == "") ? "" : sonha.Text + ", ") + ((thon.Text == "") ? "" : thon.Text + ", ") + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, l_matd, true);
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid2_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
