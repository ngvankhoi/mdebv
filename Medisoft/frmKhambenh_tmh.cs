using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.IO.Ports;
using LibMedi;
using LibVienphi;
using LibCaller;

namespace Medisoft
{
	public class frmKhambenh_tmh : System.Windows.Forms.Form
    {
        //linh
        DataTable dtdmbenhvien = null;
        DataTable dtdmchinhanh = null;
        //end linh
        #region Khai bao
        Language lan;// = new Language();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private LibDuoc.AccessData d;//=new LibDuoc.AccessData();
		private LibCaller.Caller call;
        private frmOutput2 flcd = null;
        private frmGoibenhKham fgoi = null;
        private int sizestt = 120;
        //private AxMSCommLib.AxMSComm MSComm1;// = null;
        private Project1.Form1 fled;
		private DataSet ds=new DataSet();
        private DataSet ds_lydo = new DataSet();
        private string user, mmyy, xxx, nam = "", s_userid, s_makp = "", s_mabn, s_msg, s_ngayvv, sql, s_madoituong = "", s_mabs, s_nhomkho, makp_khamnoi, makp_capid, ngaysrv="";
        private int i_userid, i_mabv, i_maba, i_bangoaitru, iChidinh, i_loai, i_traituyen=0,i_khudt=0,i_chinhanh=0;
        private bool bChenhlech_laygiaphuthu = false;//option G27.1
		private decimal l_maql=0,l_matd=0,l_mavaovien=0;
		private decimal sodu=0;
        private string pathImage = "",FileType = "";
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtlist=new DataTable();
		private DataTable dtxutri=new DataTable();
		private DataTable dtkp=new DataTable();
        private DataTable dtkpfull = new DataTable();
        private DataTable dtgia = new DataTable();
        private DataTable dtdt = new DataTable();
		private DataSet dsdt;
		private DataSet dsloai=new DataSet();
        private DataSet dsbnmoi = new DataSet();
        protected Label label3;
        protected Label label4;
        protected Label label5;
        protected MaskedTextBox.MaskedTextBox mabn2;
        protected MaskedTextBox.MaskedTextBox mabn3;
        protected Label label6;
        protected MaskedTextBox.MaskedTextBox namsinh;
        protected Label label7;
        protected ComboBox loaituoi;
        protected TextBox tuoi;
        protected TextBox hoten;
        protected MaskedTextBox.MaskedTextBox icd_chinh;
        private ComboBox tenloaibv;
        private TextBox loaibv;
        private Label label47;
        protected Label label48;
        protected MaskedTextBox.MaskedTextBox mabv;
        private ComboBox tenbv;
        protected TextBox mabs;
        protected CheckBox taibien;
        private CheckBox bienchung;
        protected Label label52;
        protected Button butTiep;
        protected Button butLuu;
        protected Button butBoqua;
        protected Button butIn;
        protected Button butKetthuc;
		private int songay=30,iTreem6,iTreem15,iKhamnhi,i_sokham,hh1,hh2,hh3,mm1,mm2,mm3,i_madoituong=0,traituyen=0;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bHiends, b_soluutru, bLuutru_Mabn, b_sovaovien, bXutri_noitru, bXutri_ngoaitru, bChuyenkhoasan, bKhamthai, bTiepdon, bDanhmuc_nhathuoc, bBacsy, bSoluutru, bSuadoituong, bSothe_mabn, bGhichu, bCapso, bTamung, bHinh, bTaikham_hen, bPhongluu_userid, bKhamsuckhoe,bGoi;
        private bool bPhongkham_bangdien_kontum, bPhongkham_bangdien_hanoi;
        protected CheckBox giaiphau;
		private System.ComponentModel.IContainer components;
        private bool b_khambenh, b_bacsi, b_trongngoai, bDenngay_sothe, bChandoan, b701424, b701306, bNew, bTudong = false, b711512, bPhongkham_chidinh, bTungay, bAdministrator, bNgay1kham, bCaller, bYta_khambenh, bBacsi_hanhchinh, bHienthi_tivi, bStt, bExit = false;
        protected ComboBox tennuoc;
        protected ComboBox tendantoc;
        protected ComboBox tentqx;
        protected TextBox cholam;
        protected TextBox thon;
        protected TextBox mapxa2;
        protected TextBox maqu2;
        protected TextBox matt;
        protected TextBox tqx;
        protected TextBox manuoc;
        protected TextBox madantoc;
        protected TextBox mann;
        protected ComboBox tennn;
        protected ComboBox tenquan;
        protected ComboBox tentinh;
        protected ComboBox tenpxa;
        protected MaskedTextBox.MaskedTextBox mapxa1;
        protected MaskedTextBox.MaskedTextBox maqu1;
        protected Label lcholam;
        protected MaskedTextBox.MaskedTextBox sonha;
        protected ComboBox phai;
        protected Label lphai;
        protected Label lmann;
        protected Label lsonha;
        protected Label lmanuoc;
        protected Label lmadantoc;
        protected Label lthon;
        protected Label lmatt;
        protected Label ltqx;
        protected Label lmaphuongxa;
        protected Label lmaqu;
        protected ComboBox tenkp;
        protected TextBox madoituong;
        protected ComboBox tendentu;
        protected ComboBox tendoituong;
        protected MaskedTextBox.MaskedTextBox icd_noichuyenden;
        protected Label label31;
        protected MaskedTextBox.MaskedTextBox qh_dienthoai;
        protected TextBox qh_diachi;
        protected TextBox qh_hoten;
        protected TextBox quanhe;
        protected MaskedTextBox.MaskedTextBox sothe;
        protected Label label30;
        protected Label label29;
        protected Label label28;
        protected Label label27;
        protected Label label26;
        protected Label label25;
        protected Label label24;
        protected Label label23;
        protected TextBox dentu;
        protected Label label21;
        protected Label label19;
        protected TextBox makp;
        protected Label label1;
        protected ComboBox tennhantu;
        protected TextBox nhantu;
        protected Label label20;
        protected ComboBox gphaubenh;
        protected MaskedBox.MaskedBox denngay;
        protected MaskedBox.MaskedBox ngayvv;
        protected MaskedBox.MaskedBox ngaysinh;
        protected ComboBox cmbTaibien;
        protected Label label9;
        protected MaskedTextBox.MaskedTextBox madstt;
        protected TextBox tendstt;
        protected LibList.List listdstt;
        protected TreeView treeView1;
        private string s_icd_noichuyenden, s_icd_chinh, s_mabv, s_noicap, s_chonxutri = "";
        protected TextBox cd_chinh;
        protected LibList.List listICD;
        protected TextBox cd_noichuyenden;
        protected GroupBox danhsach;
        protected Button butRef;
        protected Label label10;
        protected MaskedTextBox.MaskedTextBox soluutru;
        protected LibList.List listBS;
        protected TextBox tenbs;
        protected TextBox khoa;
        protected ComboBox tenkhoa;
        protected CheckedListBox xutri;
        protected MaskedTextBox.MaskedTextBox maxutri;
        protected Label lbl;
        protected Panel khamthai;
        protected MaskedTextBox.MaskedTextBox para4;
        protected MaskedTextBox.MaskedTextBox para3;
        protected MaskedTextBox.MaskedTextBox para2;
        protected MaskedTextBox.MaskedTextBox para1;
        protected Label label15;
        protected MaskedBox.MaskedBox ngaysanh;
        protected MaskedBox.MaskedBox kinhcc;
        protected Label label13;
        protected Label label14;
        private ComboBox loai;
        private Label label34;
        protected ComboBox bnmoi;
        protected Label l_bnmoi;
        protected TextBox sovaovien;
        protected Panel pmat;
        protected Label label18;
        protected Label label22;
        protected Label label33;
        protected MaskedTextBox.MaskedTextBox mp;
        protected MaskedTextBox.MaskedTextBox mt;
        protected MaskedTextBox.MaskedTextBox nhanapp;
        protected MaskedTextBox.MaskedTextBox nhanapt;
        protected Label label35;
        protected Label label36;
        protected Label label37;
        protected Button butIncv;
        protected Label lblhd;
        protected Panel hen;
        protected Label label16;
        protected NumericUpDown hen_ngay;
        protected Label label17;
        protected TextBox hen_ghichu;
        protected Button hen_butin;
		private DataTable dticd=new DataTable();
        private DataTable dtletet = new DataTable();
        protected ComboBox hen_loai;
        protected CheckBox chkTiepdon;
        protected AsYetUnnamed.MultiColumnListBox list;
        protected Label label55;
        protected MaskedBox.MaskedBox tungay;
        protected Label label8;
        protected Label label38;
        protected LibList.List list1;
        protected TextBox tennoidk;
        protected MaskedTextBox.MaskedTextBox noidk;
        protected ToolTip toolTip1;
        protected TextBox c_lydo;
        protected Label label2;
        protected Label label51;
        protected Label label53;
        protected Label label54;
        protected Label label56;
        protected Label label57;
        protected TextBox c_hb_benhly;
        protected TextBox c_hb_giadinh;
        protected TextBox c_hb_banthan;
        protected Label label58;
        protected Label label12;
        protected Label label59;
        protected Label label60;
        protected Label label61;
        protected Label label62;
        protected TextBox c_kb_tomtat;
        protected TextBox c_kb_bophan;
        protected TextBox c_kb_toanthan;
        protected Panel panel2;
        protected MaskedBox.MaskedBox nhietdo;
        protected MaskedBox.MaskedBox huyetap;
        protected MaskedTextBox.MaskedTextBox nhiptho;
        protected MaskedTextBox.MaskedTextBox cannang;
        protected MaskedTextBox.MaskedTextBox mach;
        protected Label label39;
        protected Label label41;
        protected Label label43;
        protected Label label44;
        protected Label label45;
        protected Label label50;
        protected Label label63;
        protected Label label64;
        protected Label label65;
        protected Label label66;
        protected TextBox c_kb_xuli;
        protected Label label67;
        protected Label lblKhoaphong;
        protected TextBox c_kb_chuy;
        protected Label label49;
        protected TextBox tenbs_pass;
        protected Panel panMenu;
        protected TextBox tim;
        private Print print = new Print();
        protected Label label11;
        protected TextBox sobo;
        protected TextBox phanbiet;
        protected Label label40;
        protected Label lchiphi;
        protected PictureBox pic;
		private byte[] image;
		private Bitmap map;
		private System.IO.MemoryStream memo;
		private System.IO.FileStream fstr;
        private int _d1, _d2, _d3, _d4;
		private bool bChuctramngan,bHen_dangkylai;
		private dichso.numbertotext doiso=new dichso.numbertotext();
		private DataSet dsxmlin=new DataSet();
		private DataTable dtbd=new DataTable();
		private DataTable dtvpin=new DataTable();
        private string madoituong_hen, xutri_hen;
        protected Panel p;
        protected ToolStripSeparator toolStripSeparator1;
        protected ToolStripButton barDonthuocduoc;
        protected ToolStripSeparator toolStripSeparator2;
        protected ToolStripButton barChidinh;
        protected ToolStripSeparator toolStripSeparator3;
        protected ToolStripButton barTainantt;
        protected ToolStripSeparator toolStripSeparator4;
        protected ToolStripButton barTutruc;
        protected ToolStripSeparator toolStripSeparator6;
        protected ToolStripButton barBenhkemtheo;
        protected ToolStripSeparator toolStripSeparator7;
        protected ToolStripButton barXemcls;
        protected ToolStripSeparator toolStripSeparator8;
        protected ToolStripButton barLichhen;
        protected ToolStripSeparator toolStripSeparator9;
        protected ToolStripButton barPhanUng;
        protected ToolStripSeparator toolStripSeparator10;
        protected ToolStripButton barPttt;
        protected ToolStripButton barKetthuc;
        protected ToolStripButton barDonthuocngoai;
        protected ToolStripButton barSudungthuoc;
        protected ToolStripSeparator toolStripSeparator13;
        protected ToolStripSeparator toolStripSeparator14;
        protected ToolStripButton barTiensubenh;
        protected ToolStripSeparator toolStripSeparator15;
        protected ToolStripButton barTmh;
        protected Button butphauthuat;
        protected Button but_thuocdan;
        protected Button but_thuocbhyt;
        protected Button butchidinh;
        protected Button butkemtheo;
        protected Button buttutruc;
        protected Button buttainantt;
        protected Button buttmh;
        protected Button buttiensu;
        protected Button butlichhen;
        protected Button butdiungthuoc;
        private MaskedTextBox.MaskedTextBox bmi;
        private Label label106;
        private Label label105;
        private MaskedTextBox.MaskedTextBox chieucao;
        private Label label32;
        protected MaskedTextBox.MaskedTextBox icd_kemtheo;
        protected Button butKhuyettat;
        protected Button butPhanungcohai;
        private Label lblnguoilogin;
        protected ComboBox cbotuyen;
        protected Panel panHanhchanh;
        private int i_maxlenght_mabn = 8;
        //Tu:09/06/2011
        private bool bChuyenkham_tinhcongkham = false, bChuyenkham_tinh_congkham_dtthuphi = false, bChuyenkham_thuphi, bDangky_homqua;
        private Label label46;
        private Label label42;
        private Label label69;
        private Label label70;
        protected Button butgoibenh;
        private NumericUpDown den;
        private NumericUpDown tu;
        private Label label71;
        private NumericUpDown sonhay;
        private Panel pgoi;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem chkLCD;
        private ToolStripMenuItem tsLCD;
        private ToolStripButton barDausinhton;
        protected ToolStripSeparator toolStripSeparator16;
        protected Button butgoilai;
        private Panel panel4;
        protected ToolStripSeparator toolStripSeparator17;
        private ToolStripButton barbenhmantinh;
        private Button butdausinhton;
        protected Button butbenhmantinh;
        private string s_ngaydk = "", s_soluutru = "";
        protected ToolStripSeparator toolStripSeparator19;
        private ToolStrip toolStrip1;
        protected Label label72;
        protected TextBox txtTenbv;
        protected LibList.List listBenhvien;
        private ToolStripMenuItem chkXem;
        private ToolStripDropDownButton mnuTienich;
        private ToolStripMenuItem butBienbantuvong;
        private ToolStripMenuItem butXemtonkho;
        private ToolStripMenuItem butXemhosobenhan;
        private ToolStripMenuItem butXemthuocdadung;
        protected Label label68;
        protected Button butTiemchung;
        private ToolStripMenuItem chkTudongchonthongso;
        private ToolStripMenuItem butChamdoc;
        private ToolStripMenuItem butTruyendich;
        private ToolStripMenuItem mnuBaolucgiadinh;
        private ToolStripMenuItem butPhieusangloc;
        private ToolStripMenuItem butPhieughichep;
        private ToolStripMenuItem butGiayxacnhan;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem chkXml;
        protected GroupBox groupBox1;
        protected AsYetUnnamed.MultiColumnListBox multiColumnListBox1;
        protected TextBox textBox1;
        protected Button button1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton tbutvantay;
        public PictureBox ptb;
        private ToolStripMenuItem butPhieuchuyenkhamchuyenkhoa;
        protected TextBox c_kb_hong;
        protected Label label73;
        protected TextBox c_kb_mui;
        protected Label label74;
        protected TextBox c_kb_tai;
        protected Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label80;
        private Label label81;
        private System.IO.Ports.SerialPort MSComm1;
        private ToolStripMenuItem toolStripMenuItem1;//end Tu
        #endregion

        public frmKhambenh_tmh()
        {
            InitializeComponent();
            lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        public frmKhambenh_tmh(LibMedi.AccessData acc, string makp, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _madoituong, string _mabs, string _nhomkho, bool _admin, int _loai, int _i_khudt, int _i_chinhanh)
        {
            InitializeComponent();
            lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc;
            d = new LibDuoc.AccessData();
            v = new LibVienphi.AccessData();
            bAdministrator = _admin;
            s_makp = makp; s_madoituong = _madoituong; s_mabs = _mabs;
            s_userid = hoten; i_userid = userid; i_mabv = mabv;
            b_soluutru = soluutru; s_nhomkho = _nhomkho; i_loai = _loai; i_khudt = _i_khudt;
            i_chinhanh = _i_chinhanh;
        }

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
		public void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhambenh_tmh));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loaituoi = new System.Windows.Forms.ComboBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.tenloaibv = new System.Windows.Forms.ComboBox();
            this.loaibv = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.tenbv = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.taibien = new System.Windows.Forms.CheckBox();
            this.bienchung = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.giaiphau = new System.Windows.Forms.CheckBox();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
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
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tennoidk = new System.Windows.Forms.TextBox();
            this.noidk = new MaskedTextBox.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.loai = new System.Windows.Forms.ComboBox();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.icd_noichuyenden = new MaskedTextBox.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.quanhe = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dentu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.khamthai = new System.Windows.Forms.Panel();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.ngaysanh = new MaskedBox.MaskedBox();
            this.kinhcc = new MaskedBox.MaskedBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gphaubenh = new System.Windows.Forms.ComboBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.cmbTaibien = new System.Windows.Forms.ComboBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.danhsach = new System.Windows.Forms.GroupBox();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.butRef = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.khoa = new System.Windows.Forms.TextBox();
            this.tenkhoa = new System.Windows.Forms.ComboBox();
            this.xutri = new System.Windows.Forms.CheckedListBox();
            this.maxutri = new MaskedTextBox.MaskedTextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.pmat = new System.Windows.Forms.Panel();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.hen = new System.Windows.Forms.Panel();
            this.hen_butin = new System.Windows.Forms.Button();
            this.chkTiepdon = new System.Windows.Forms.CheckBox();
            this.hen_loai = new System.Windows.Forms.ComboBox();
            this.hen_ghichu = new System.Windows.Forms.TextBox();
            this.hen_ngay = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblhd = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.multiColumnListBox1 = new AsYetUnnamed.MultiColumnListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.c_lydo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.c_hb_benhly = new System.Windows.Forms.TextBox();
            this.c_hb_giadinh = new System.Windows.Forms.TextBox();
            this.c_hb_banthan = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.c_kb_tomtat = new System.Windows.Forms.TextBox();
            this.c_kb_bophan = new System.Windows.Forms.TextBox();
            this.c_kb_toanthan = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bmi = new MaskedTextBox.MaskedTextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedBox.MaskedBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.c_kb_xuli = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.lblKhoaphong = new System.Windows.Forms.Label();
            this.c_kb_chuy = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.panMenu = new System.Windows.Forms.Panel();
            this.butTiemchung = new System.Windows.Forms.Button();
            this.butbenhmantinh = new System.Windows.Forms.Button();
            this.butdausinhton = new System.Windows.Forms.Button();
            this.butPhanungcohai = new System.Windows.Forms.Button();
            this.butKhuyettat = new System.Windows.Forms.Button();
            this.buttmh = new System.Windows.Forms.Button();
            this.buttiensu = new System.Windows.Forms.Button();
            this.butlichhen = new System.Windows.Forms.Button();
            this.butdiungthuoc = new System.Windows.Forms.Button();
            this.butkemtheo = new System.Windows.Forms.Button();
            this.buttutruc = new System.Windows.Forms.Button();
            this.buttainantt = new System.Windows.Forms.Button();
            this.butchidinh = new System.Windows.Forms.Button();
            this.butphauthuat = new System.Windows.Forms.Button();
            this.but_thuocdan = new System.Windows.Forms.Button();
            this.but_thuocbhyt = new System.Windows.Forms.Button();
            this.butIncv = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.sobo = new System.Windows.Forms.TextBox();
            this.phanbiet = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.lchiphi = new System.Windows.Forms.Label();
            this.panHanhchanh = new System.Windows.Forms.Panel();
            this.cbotuyen = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.lblnguoilogin = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Panel();
            this.pgoi = new System.Windows.Forms.Panel();
            this.butgoilai = new System.Windows.Forms.Button();
            this.butgoibenh = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.sonhay = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.barDonthuocngoai = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.barDonthuocduoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.barChidinh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.barTainantt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.barTutruc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.barBenhkemtheo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.barXemcls = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.barLichhen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.barPhanUng = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.barSudungthuoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.barPttt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.barTiensubenh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.barTmh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.barDausinhton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.barbenhmantinh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutvantay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.barKetthuc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.chkLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkTudongchonthongso = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXml = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTienich = new System.Windows.Forms.ToolStripDropDownButton();
            this.butBienbantuvong = new System.Windows.Forms.ToolStripMenuItem();
            this.butChamdoc = new System.Windows.Forms.ToolStripMenuItem();
            this.butTruyendich = new System.Windows.Forms.ToolStripMenuItem();
            this.butPhieuchuyenkhamchuyenkhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaolucgiadinh = new System.Windows.Forms.ToolStripMenuItem();
            this.butPhieusangloc = new System.Windows.Forms.ToolStripMenuItem();
            this.butPhieughichep = new System.Windows.Forms.ToolStripMenuItem();
            this.butGiayxacnhan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.butXemtonkho = new System.Windows.Forms.ToolStripMenuItem();
            this.butXemhosobenhan = new System.Windows.Forms.ToolStripMenuItem();
            this.butXemthuocdadung = new System.Windows.Forms.ToolStripMenuItem();
            this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label72 = new System.Windows.Forms.Label();
            this.txtTenbv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBenhvien = new LibList.List();
            this.listBS = new LibList.List();
            this.listICD = new LibList.List();
            this.list1 = new LibList.List();
            this.listdstt = new LibList.List();
            this.c_kb_hong = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.c_kb_mui = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.c_kb_tai = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.MSComm1 = new System.IO.Ports.SerialPort(this.components);
            this.khamthai.SuspendLayout();
            this.danhsach.SuspendLayout();
            this.pmat.SuspendLayout();
            this.hen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panMenu.SuspendLayout();
            this.panHanhchanh.SuspendLayout();
            this.p.SuspendLayout();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(28, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(161, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 90;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(353, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 23);
            this.label5.TabIndex = 91;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(73, 30);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 1;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(96, 30);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 8;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(65, 21);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(474, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 22);
            this.label6.TabIndex = 92;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(535, 30);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(563, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 23);
            this.label7.TabIndex = 94;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(624, 30);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(58, 21);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(595, 30);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
            this.tuoi.TabIndex = 6;
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(202, 30);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(151, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // icd_chinh
            // 
            this.icd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(303, 520);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(51, 21);
            this.icd_chinh.TabIndex = 63;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            this.icd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_chinh_KeyDown);
            // 
            // tenloaibv
            // 
            this.tenloaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenloaibv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenloaibv.Enabled = false;
            this.tenloaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloaibv.Location = new System.Drawing.Point(275, 633);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(87, 21);
            this.tenloaibv.TabIndex = 72;
            this.tenloaibv.Visible = false;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Enabled = false;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(255, 632);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(18, 21);
            this.loaibv.TabIndex = 71;
            this.loaibv.Visible = false;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.Enabled = false;
            this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label47.Location = new System.Drawing.Point(168, 632);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(88, 16);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label47.Visible = false;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(441, 588);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 16);
            this.label48.TabIndex = 112;
            this.label48.Text = "Chuyển đến :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(510, 586);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.MaxLength = 20;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(58, 21);
            this.mabv.TabIndex = 73;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            this.mabv.EnabledChanged += new System.EventHandler(this.txtTenbv_EnabledChanged);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(188, 632);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(149, 21);
            this.tenbv.TabIndex = 74;
            this.tenbv.Visible = false;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(274, 7);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(34, 21);
            this.mabs.TabIndex = 76;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // taibien
            // 
            this.taibien.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.taibien.Location = new System.Drawing.Point(570, 661);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(146, 24);
            this.taibien.TabIndex = 84;
            this.taibien.Text = "Tai biến điều trị nội khoa";
            this.taibien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.Visible = false;
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bienchung.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bienchung.Location = new System.Drawing.Point(199, 632);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(80, 24);
            this.bienchung.TabIndex = 86;
            this.bienchung.Text = "Biến chứng";
            this.bienchung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.Visible = false;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(26, 3);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(112, 23);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giaiphau
            // 
            this.giaiphau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.giaiphau.Location = new System.Drawing.Point(818, 661);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(104, 24);
            this.giaiphau.TabIndex = 86;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.Visible = false;
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(465, 13);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(111, 21);
            this.tennuoc.TabIndex = 14;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(439, 13);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 13;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmanuoc.Location = new System.Drawing.Point(384, 14);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(59, 19);
            this.lmanuoc.TabIndex = 96;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(622, 13);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(64, 21);
            this.sonha.TabIndex = 15;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(311, 13);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(73, 21);
            this.tendantoc.TabIndex = 12;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(222, 44);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(160, 21);
            this.tentqx.TabIndex = 18;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(73, 74);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(204, 21);
            this.cholam.TabIndex = 27;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(489, 45);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(0, 21);
            this.thon.TabIndex = 16;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(510, 52);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 21);
            this.mapxa2.TabIndex = 25;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(253, 52);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(23, 21);
            this.maqu2.TabIndex = 22;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(73, 52);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(27, 21);
            this.matt.TabIndex = 19;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(181, 44);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(40, 21);
            this.tqx.TabIndex = 17;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(288, 13);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(22, 21);
            this.madantoc.TabIndex = 11;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(104, 13);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 9;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(127, 13);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(107, 21);
            this.tennn.TabIndex = 10;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(278, 52);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(102, 21);
            this.tenquan.TabIndex = 23;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(101, 52);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(76, 21);
            this.tentinh.TabIndex = 20;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(535, 52);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(245, 21);
            this.tenpxa.TabIndex = 26;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(472, 52);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(36, 21);
            this.mapxa1.TabIndex = 24;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(405, 52);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(69, 23);
            this.lmaphuongxa.TabIndex = 102;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(225, 52);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 21;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(177, 52);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(56, 23);
            this.lmaqu.TabIndex = 101;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(21, 52);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 100;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(109, 44);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 99;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcholam.Location = new System.Drawing.Point(5, 74);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 103;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(419, 47);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 20);
            this.lthon.TabIndex = 98;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsonha.Location = new System.Drawing.Point(576, 13);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(48, 19);
            this.lsonha.TabIndex = 97;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmadantoc.Location = new System.Drawing.Point(235, 13);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(53, 20);
            this.lmadantoc.TabIndex = 95;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmann.Location = new System.Drawing.Point(26, 13);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(78, 23);
            this.lmann.TabIndex = 93;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(737, 29);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(43, 21);
            this.phai.TabIndex = 8;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lphai.Location = new System.Drawing.Point(681, 30);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 109;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(689, 96);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 18;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(173, 21);
            this.sothe.TabIndex = 39;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(169, 118);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(64, 21);
            this.denngay.TabIndex = 41;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(73, 118);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(66, 21);
            this.tungay.TabIndex = 40;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(44, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 112;
            this.label8.Text = "Từ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennoidk
            // 
            this.tennoidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennoidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennoidk.Location = new System.Drawing.Point(314, 118);
            this.tennoidk.Name = "tennoidk";
            this.tennoidk.Size = new System.Drawing.Size(140, 21);
            this.tennoidk.TabIndex = 43;
            this.tennoidk.TextChanged += new System.EventHandler(this.tennoidk_TextChanged);
            this.tennoidk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennoidk_KeyDown);
            // 
            // noidk
            // 
            this.noidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidk.Location = new System.Drawing.Point(281, 118);
            this.noidk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.noidk.MaxLength = 8;
            this.noidk.Name = "noidk";
            this.noidk.Size = new System.Drawing.Size(32, 21);
            this.noidk.TabIndex = 42;
            this.noidk.Validated += new System.EventHandler(this.noidk_Validated);
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(233, 122);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 16);
            this.label38.TabIndex = 114;
            this.label38.Text = "ĐKKCB :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(689, 117);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(30, 21);
            this.sovaovien.TabIndex = 44;
            this.sovaovien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sovaovien_KeyDown);
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.bnmoi.Location = new System.Drawing.Point(82, 114);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(57, 21);
            this.bnmoi.TabIndex = 46;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // loai
            // 
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(201, 656);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(152, 21);
            this.loai.TabIndex = 45;
            this.loai.Visible = false;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(141, 140);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(578, 21);
            this.cd_noichuyenden.TabIndex = 52;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(73, 96);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(39, 21);
            this.madstt.TabIndex = 33;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(113, 96);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(341, 21);
            this.tendstt.TabIndex = 34;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // tendentu
            // 
            this.tendentu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(732, 74);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(131, 21);
            this.tendentu.TabIndex = 32;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(354, 74);
            this.ngayvv.Mask = "##/##/#### ##:##";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(100, 21);
            this.ngayvv.TabIndex = 28;
            this.ngayvv.Text = "  /  /       :  ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // tennhantu
            // 
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(535, 74);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(102, 21);
            this.tennhantu.TabIndex = 30;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(511, 74);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(21, 21);
            this.nhantu.TabIndex = 29;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(461, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 23);
            this.label20.TabIndex = 105;
            this.label20.Text = "Nhận từ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(570, 7);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(209, 21);
            this.tenkp.TabIndex = 36;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(511, 96);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(21, 21);
            this.madoituong.TabIndex = 37;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(535, 96);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(102, 21);
            this.tendoituong.TabIndex = 38;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(73, 140);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(66, 21);
            this.icd_noichuyenden.TabIndex = 51;
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(-4, 139);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 20);
            this.label31.TabIndex = 2;
            this.label31.Text = "CĐ Nơi chuyển :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(569, 139);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(0, 21);
            this.qh_dienthoai.TabIndex = 50;
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(500, 114);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(156, 21);
            this.qh_diachi.TabIndex = 49;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(292, 114);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(156, 21);
            this.qh_hoten.TabIndex = 48;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(197, 114);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(48, 21);
            this.quanhe.TabIndex = 47;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(639, 118);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 20);
            this.label30.TabIndex = 115;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(505, 140);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 18);
            this.label29.TabIndex = 121;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(449, 114);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 19);
            this.label28.TabIndex = 120;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(246, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 23);
            this.label27.TabIndex = 119;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(139, 113);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 23);
            this.label26.TabIndex = 118;
            this.label26.Text = "Người nhà:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(138, 122);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 16);
            this.label25.TabIndex = 113;
            this.label25.Text = "Đến :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(647, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 16);
            this.label24.TabIndex = 111;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(454, 96);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 20);
            this.label23.TabIndex = 110;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(712, 74);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 31;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(635, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 23);
            this.label21.TabIndex = 106;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(273, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 23);
            this.label19.TabIndex = 104;
            this.label19.Text = "Khám bệnh lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(535, 7);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(34, 21);
            this.makp.TabIndex = 35;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(485, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 108;
            this.label1.Text = "Phòng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(3, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 23);
            this.label9.TabIndex = 107;
            this.label9.Text = "Nơi giới thiệu :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khamthai
            // 
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.ngaysanh);
            this.khamthai.Controls.Add(this.kinhcc);
            this.khamthai.Controls.Add(this.label13);
            this.khamthai.Controls.Add(this.label14);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label15);
            this.khamthai.Location = new System.Drawing.Point(234, 72);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(328, 21);
            this.khamthai.TabIndex = 53;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(168, 0);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(22, 21);
            this.para4.TabIndex = 4;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // ngaysanh
            // 
            this.ngaysanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaysanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysanh.Location = new System.Drawing.Point(448, 0);
            this.ngaysanh.Mask = "##/##/####";
            this.ngaysanh.Name = "ngaysanh";
            this.ngaysanh.Size = new System.Drawing.Size(0, 21);
            this.ngaysanh.TabIndex = 27;
            this.ngaysanh.Text = "  /  /    ";
            this.ngaysanh.Validated += new System.EventHandler(this.ngaysanh_Validated);
            // 
            // kinhcc
            // 
            this.kinhcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhcc.Location = new System.Drawing.Point(272, 0);
            this.kinhcc.Mask = "##/##/####";
            this.kinhcc.Name = "kinhcc";
            this.kinhcc.Size = new System.Drawing.Size(72, 21);
            this.kinhcc.TabIndex = 26;
            this.kinhcc.Text = "  /  /    ";
            this.kinhcc.Validated += new System.EventHandler(this.kinhcc_Validated);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(328, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ngày sanh dự đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(185, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Kinh cuối cùng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(144, 0);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(22, 21);
            this.para3.TabIndex = 3;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(120, 0);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(22, 21);
            this.para2.TabIndex = 2;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(96, 0);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(22, 21);
            this.para1.TabIndex = 1;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(64, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "&Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(161, 656);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(40, 21);
            this.label34.TabIndex = 116;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label34.Visible = false;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_bnmoi.Location = new System.Drawing.Point(13, 113);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(69, 23);
            this.l_bnmoi.TabIndex = 117;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label55.Location = new System.Drawing.Point(880, 146);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 14);
            this.label55.TabIndex = 206;
            this.label55.Text = "&CÁC LẦN KHÁM BỆNH :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(872, 161);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(144, 157);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // gphaubenh
            // 
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(922, 663);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(96, 21);
            this.gphaubenh.TabIndex = 87;
            this.gphaubenh.Visible = false;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(409, 30);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(722, 661);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(106, 21);
            this.cmbTaibien.TabIndex = 85;
            this.cmbTaibien.Visible = false;
            // 
            // cd_chinh
            // 
            this.cd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(356, 520);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(516, 21);
            this.cd_chinh.TabIndex = 64;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // danhsach
            // 
            this.danhsach.Controls.Add(this.list);
            this.danhsach.Controls.Add(this.tim);
            this.danhsach.Controls.Add(this.butRef);
            this.danhsach.Location = new System.Drawing.Point(0, 30);
            this.danhsach.Name = "danhsach";
            this.danhsach.Size = new System.Drawing.Size(148, 153);
            this.danhsach.TabIndex = 0;
            this.danhsach.TabStop = false;
            this.danhsach.Text = "DANH SÁCH ĐĂNG KÝ";
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 37);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(148, 108);
            this.list.TabIndex = 1;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F1 : Gọi người bệnh");
            this.list.ValueIndex = -1;
            this.list.MouseEnter += new System.EventHandler(this.list_MouseEnter);
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 16);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(127, 21);
            this.tim.TabIndex = 0;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(126, 16);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(22, 21);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách đăng ký");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(920, 593);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 217;
            this.label10.Text = "Số lưu trữ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(388, 712);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(68, 21);
            this.soluutru.TabIndex = 88;
            this.soluutru.Visible = false;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(309, 7);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(164, 21);
            this.tenbs.TabIndex = 77;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // khoa
            // 
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(303, 586);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(24, 21);
            this.khoa.TabIndex = 69;
            this.khoa.Validated += new System.EventHandler(this.khoa_Validated);
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(328, 586);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(106, 21);
            this.tenkhoa.TabIndex = 70;
            this.tenkhoa.SelectedIndexChanged += new System.EventHandler(this.tenkhoa_SelectedIndexChanged);
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xutri.CheckOnClick = true;
            this.xutri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(872, 528);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(144, 124);
            this.xutri.TabIndex = 300;
            this.xutri.SelectedIndexChanged += new System.EventHandler(this.xutri_SelectedIndexChanged);
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // maxutri
            // 
            this.maxutri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maxutri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maxutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxutri.Location = new System.Drawing.Point(872, 505);
            this.maxutri.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maxutri.Name = "maxutri";
            this.maxutri.Size = new System.Drawing.Size(144, 21);
            this.maxutri.TabIndex = 68;
            this.maxutri.Validated += new System.EventHandler(this.maxutri_Validated);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(93, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(60, 13);
            this.lbl.TabIndex = 236;
            this.lbl.Text = "diungthuoc";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.label33);
            this.pmat.Controls.Add(this.label22);
            this.pmat.Controls.Add(this.label18);
            this.pmat.Controls.Add(this.label35);
            this.pmat.Controls.Add(this.label36);
            this.pmat.Controls.Add(this.label37);
            this.pmat.Location = new System.Drawing.Point(56, 736);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(664, 22);
            this.pmat.TabIndex = 122;
            this.pmat.Visible = false;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(598, 0);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(64, 21);
            this.nhanapt.TabIndex = 26;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(471, 0);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(64, 21);
            this.nhanapp.TabIndex = 25;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(247, 0);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(64, 21);
            this.mt.TabIndex = 24;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(115, 0);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(60, 21);
            this.mp.TabIndex = 23;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(315, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 5;
            this.label33.Text = "/10";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(552, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "Trái :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(352, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Nhãn áp phải :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(206, 4);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(40, 16);
            this.label35.TabIndex = 1;
            this.label35.Text = "Trái :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(178, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 4;
            this.label36.Text = "/10";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(8, 4);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(112, 16);
            this.label37.TabIndex = 0;
            this.label37.Text = "Thị lực phải :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen
            // 
            this.hen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hen.Controls.Add(this.hen_butin);
            this.hen.Controls.Add(this.chkTiepdon);
            this.hen.Controls.Add(this.hen_loai);
            this.hen.Controls.Add(this.hen_ghichu);
            this.hen.Controls.Add(this.hen_ngay);
            this.hen.Controls.Add(this.label17);
            this.hen.Controls.Add(this.label16);
            this.hen.Location = new System.Drawing.Point(161, 632);
            this.hen.Name = "hen";
            this.hen.Size = new System.Drawing.Size(365, 46);
            this.hen.TabIndex = 79;
            this.hen.Visible = false;
            // 
            // hen_butin
            // 
            this.hen_butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hen_butin.Location = new System.Drawing.Point(334, 23);
            this.hen_butin.Name = "hen_butin";
            this.hen_butin.Size = new System.Drawing.Size(28, 21);
            this.hen_butin.TabIndex = 5;
            this.hen_butin.Text = "In";
            this.hen_butin.Click += new System.EventHandler(this.hen_butin_Click);
            // 
            // chkTiepdon
            // 
            this.chkTiepdon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTiepdon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTiepdon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTiepdon.Location = new System.Drawing.Point(273, 5);
            this.chkTiepdon.Name = "chkTiepdon";
            this.chkTiepdon.Size = new System.Drawing.Size(88, 16);
            this.chkTiepdon.TabIndex = 4;
            this.chkTiepdon.Text = "Qua tiếp đón";
            this.chkTiepdon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // hen_loai
            // 
            this.hen_loai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hen_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hen_loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_loai.Items.AddRange(new object[] {
            "Ngày liên tục",
            "Ngày",
            "Tuần",
            "Tháng"});
            this.hen_loai.Location = new System.Drawing.Point(184, 1);
            this.hen_loai.Name = "hen_loai";
            this.hen_loai.Size = new System.Drawing.Size(86, 21);
            this.hen_loai.TabIndex = 2;
            this.hen_loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_loai_KeyDown);
            // 
            // hen_ghichu
            // 
            this.hen_ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hen_ghichu.Location = new System.Drawing.Point(141, 24);
            this.hen_ghichu.Name = "hen_ghichu";
            this.hen_ghichu.Size = new System.Drawing.Size(191, 20);
            this.hen_ghichu.TabIndex = 3;
            this.hen_ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // hen_ngay
            // 
            this.hen_ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ngay.Location = new System.Drawing.Point(142, 2);
            this.hen_ngay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hen_ngay.Name = "hen_ngay";
            this.hen_ngay.Size = new System.Drawing.Size(40, 21);
            this.hen_ngay.TabIndex = 1;
            this.hen_ngay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hen_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(9, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "Ghi chú :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(4, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Thời gian :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblhd
            // 
            this.lblhd.AutoSize = true;
            this.lblhd.ForeColor = System.Drawing.Color.Red;
            this.lblhd.Location = new System.Drawing.Point(661, -1);
            this.lblhd.Name = "lblhd";
            this.lblhd.Size = new System.Drawing.Size(47, 13);
            this.lblhd.TabIndex = 240;
            this.lblhd.Text = "hiendien";
            this.lblhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(292, 712);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(56, 21);
            this.tenbs_pass.TabIndex = 78;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ khám bệnh");
            this.tenbs_pass.Visible = false;
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_pass_KeyDown);
            // 
            // multiColumnListBox1
            // 
            this.multiColumnListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.multiColumnListBox1.ColumnCount = 0;
            this.multiColumnListBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiColumnListBox1.Location = new System.Drawing.Point(0, 37);
            this.multiColumnListBox1.MatchBufferTimeOut = 1000;
            this.multiColumnListBox1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.multiColumnListBox1.Name = "multiColumnListBox1";
            this.multiColumnListBox1.Size = new System.Drawing.Size(148, 108);
            this.multiColumnListBox1.TabIndex = 1;
            this.multiColumnListBox1.TextIndex = -1;
            this.multiColumnListBox1.TextMember = null;
            this.toolTip1.SetToolTip(this.multiColumnListBox1, "F1 : Gọi người bệnh");
            this.multiColumnListBox1.ValueIndex = -1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(126, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.toolTip1.SetToolTip(this.button1, "Danh sách đăng ký");
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BackColor = System.Drawing.SystemColors.Desktop;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic.InitialImage")));
            this.pic.Location = new System.Drawing.Point(782, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(81, 65);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 307;
            this.pic.TabStop = false;
            this.toolTip1.SetToolTip(this.pic, "DoubleClick phóng to hình");
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // c_lydo
            // 
            this.c_lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_lydo.Location = new System.Drawing.Point(303, 193);
            this.c_lydo.Multiline = true;
            this.c_lydo.Name = "c_lydo";
            this.c_lydo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_lydo.Size = new System.Drawing.Size(569, 35);
            this.c_lydo.TabIndex = 54;
            this.c_lydo.TextChanged += new System.EventHandler(this.c_lydo_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(151, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 259;
            this.label2.Text = "II. LÝ DO VÀO VIỆN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label51.Location = new System.Drawing.Point(151, 215);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(97, 17);
            this.label51.TabIndex = 261;
            this.label51.Text = "III. HỎI BỆNH :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label53.Location = new System.Drawing.Point(198, 293);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 19);
            this.label53.TabIndex = 265;
            this.label53.Text = "+ Gia đình :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label54.Location = new System.Drawing.Point(196, 273);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(72, 16);
            this.label54.TabIndex = 264;
            this.label54.Text = "+ Bản thân :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label56.Location = new System.Drawing.Point(158, 255);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(112, 16);
            this.label56.TabIndex = 263;
            this.label56.Text = "2. Tiền sử bệnh :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(158, 231);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(112, 16);
            this.label57.TabIndex = 262;
            this.label57.Text = "1. Quá trình bệnh lý :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_hb_benhly
            // 
            this.c_hb_benhly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_hb_benhly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_hb_benhly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_hb_benhly.Location = new System.Drawing.Point(303, 230);
            this.c_hb_benhly.Multiline = true;
            this.c_hb_benhly.Name = "c_hb_benhly";
            this.c_hb_benhly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_hb_benhly.Size = new System.Drawing.Size(569, 28);
            this.c_hb_benhly.TabIndex = 55;
            this.c_hb_benhly.TextChanged += new System.EventHandler(this.c_hb_benhly_TextChanged);
            // 
            // c_hb_giadinh
            // 
            this.c_hb_giadinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_hb_giadinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_hb_giadinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_hb_giadinh.Location = new System.Drawing.Point(302, 290);
            this.c_hb_giadinh.Multiline = true;
            this.c_hb_giadinh.Name = "c_hb_giadinh";
            this.c_hb_giadinh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_hb_giadinh.Size = new System.Drawing.Size(569, 28);
            this.c_hb_giadinh.TabIndex = 57;
            this.c_hb_giadinh.TextChanged += new System.EventHandler(this.c_hb_giadinh_TextChanged);
            // 
            // c_hb_banthan
            // 
            this.c_hb_banthan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_hb_banthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_hb_banthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_hb_banthan.Location = new System.Drawing.Point(303, 260);
            this.c_hb_banthan.Multiline = true;
            this.c_hb_banthan.Name = "c_hb_banthan";
            this.c_hb_banthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_hb_banthan.Size = new System.Drawing.Size(569, 28);
            this.c_hb_banthan.TabIndex = 56;
            this.c_hb_banthan.TextChanged += new System.EventHandler(this.c_hb_banthan_TextChanged);
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label58.Location = new System.Drawing.Point(151, 308);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(104, 16);
            this.label58.TabIndex = 269;
            this.label58.Text = "IV. KHÁM BỆNH :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(159, 565);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 16);
            this.label12.TabIndex = 274;
            this.label12.Text = "5. Đã xử lí (thuốc,chăm sóc):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label59.Location = new System.Drawing.Point(212, 522);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(79, 14);
            this.label59.TabIndex = 273;
            this.label59.Text = "- Bệnh chính :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label60.Location = new System.Drawing.Point(159, 472);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(176, 16);
            this.label60.TabIndex = 272;
            this.label60.Text = "3. Tóm tắt kết quả lâm sàng :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label61.Location = new System.Drawing.Point(158, 350);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(116, 16);
            this.label61.TabIndex = 271;
            this.label61.Text = "2. Bệnh chuyên khoa:";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label62.Location = new System.Drawing.Point(158, 328);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(80, 16);
            this.label62.TabIndex = 270;
            this.label62.Text = "1. Toàn thân :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_kb_tomtat
            // 
            this.c_kb_tomtat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_tomtat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_tomtat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_tomtat.Location = new System.Drawing.Point(303, 469);
            this.c_kb_tomtat.Multiline = true;
            this.c_kb_tomtat.Name = "c_kb_tomtat";
            this.c_kb_tomtat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_tomtat.Size = new System.Drawing.Size(569, 26);
            this.c_kb_tomtat.TabIndex = 61;
            this.c_kb_tomtat.TextChanged += new System.EventHandler(this.c_kb_tomtat_TextChanged);
            // 
            // c_kb_bophan
            // 
            this.c_kb_bophan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_bophan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_bophan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_bophan.Location = new System.Drawing.Point(303, 349);
            this.c_kb_bophan.Multiline = true;
            this.c_kb_bophan.Name = "c_kb_bophan";
            this.c_kb_bophan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_bophan.Size = new System.Drawing.Size(569, 26);
            this.c_kb_bophan.TabIndex = 59;
            this.c_kb_bophan.TextChanged += new System.EventHandler(this.c_kb_bophan_TextChanged);
            // 
            // c_kb_toanthan
            // 
            this.c_kb_toanthan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_toanthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_toanthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_toanthan.Location = new System.Drawing.Point(303, 322);
            this.c_kb_toanthan.Multiline = true;
            this.c_kb_toanthan.Name = "c_kb_toanthan";
            this.c_kb_toanthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_toanthan.Size = new System.Drawing.Size(569, 25);
            this.c_kb_toanthan.TabIndex = 58;
            this.c_kb_toanthan.TextChanged += new System.EventHandler(this.c_kb_toanthan_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.bmi);
            this.panel2.Controls.Add(this.label106);
            this.panel2.Controls.Add(this.label105);
            this.panel2.Controls.Add(this.chieucao);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.nhietdo);
            this.panel2.Controls.Add(this.huyetap);
            this.panel2.Controls.Add(this.nhiptho);
            this.panel2.Controls.Add(this.cannang);
            this.panel2.Controls.Add(this.mach);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.label41);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.label50);
            this.panel2.Controls.Add(this.label63);
            this.panel2.Controls.Add(this.label64);
            this.panel2.Controls.Add(this.label65);
            this.panel2.Controls.Add(this.label66);
            this.panel2.Location = new System.Drawing.Point(872, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 163);
            this.panel2.TabIndex = 60;
            // 
            // bmi
            // 
            this.bmi.BackColor = System.Drawing.Color.White;
            this.bmi.Enabled = false;
            this.bmi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmi.Location = new System.Drawing.Point(62, 137);
            this.bmi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bmi.MaxLength = 5;
            this.bmi.Name = "bmi";
            this.bmi.Size = new System.Drawing.Size(48, 21);
            this.bmi.TabIndex = 25;
            this.bmi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label106
            // 
            this.label106.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(12, 142);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(48, 16);
            this.label106.TabIndex = 28;
            this.label106.Text = "BMI :";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label105
            // 
            this.label105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(110, 120);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(32, 16);
            this.label105.TabIndex = 27;
            this.label105.Text = "cm";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.Color.White;
            this.chieucao.Enabled = false;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(62, 115);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(40, 21);
            this.chieucao.TabIndex = 24;
            this.chieucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chieucao.Validated += new System.EventHandler(this.chieucao_Validated);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(-2, 120);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 16);
            this.label32.TabIndex = 26;
            this.label32.Text = "Chiều cao :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.Color.White;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(62, 25);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 1;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.Color.White;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(62, 48);
            this.huyetap.Mask = "###/###";
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 2;
            this.huyetap.Text = "   /   ";
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.Color.White;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(62, 71);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 3;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.Color.White;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(62, 93);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 4;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.Color.White;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(62, 2);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 0;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(96, 4);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 19);
            this.label39.TabIndex = 11;
            this.label39.Text = "lần/phút";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(96, 29);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(24, 16);
            this.label41.TabIndex = 13;
            this.label41.Text = "°C";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(109, 48);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(38, 16);
            this.label43.TabIndex = 16;
            this.label43.Text = "mmHg";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(99, 73);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 16);
            this.label44.TabIndex = 18;
            this.label44.Text = "lần/phút";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(107, 95);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(32, 16);
            this.label45.TabIndex = 19;
            this.label45.Text = "Kg";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label50.Location = new System.Drawing.Point(-3, 96);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(64, 16);
            this.label50.TabIndex = 7;
            this.label50.Text = "Cân nặng :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label63.Location = new System.Drawing.Point(5, 74);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(56, 16);
            this.label63.TabIndex = 6;
            this.label63.Text = "Nhịp thở :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label64.Location = new System.Drawing.Point(-3, 53);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(64, 16);
            this.label64.TabIndex = 5;
            this.label64.Text = "Huyết áp :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(5, 29);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(56, 16);
            this.label65.TabIndex = 4;
            this.label65.Text = "Nhiệt độ :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(21, 5);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(40, 16);
            this.label66.TabIndex = 3;
            this.label66.Text = "Mạch :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_kb_xuli
            // 
            this.c_kb_xuli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_xuli.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_xuli.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_xuli.Location = new System.Drawing.Point(303, 564);
            this.c_kb_xuli.Name = "c_kb_xuli";
            this.c_kb_xuli.Size = new System.Drawing.Size(569, 21);
            this.c_kb_xuli.TabIndex = 67;
            this.c_kb_xuli.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label67.Location = new System.Drawing.Point(160, 608);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(56, 16);
            this.label67.TabIndex = 281;
            this.label67.Text = "7. Chú ý :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKhoaphong
            // 
            this.lblKhoaphong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoaphong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKhoaphong.Location = new System.Drawing.Point(160, 587);
            this.lblKhoaphong.Name = "lblKhoaphong";
            this.lblKhoaphong.Size = new System.Drawing.Size(152, 16);
            this.lblKhoaphong.TabIndex = 280;
            this.lblKhoaphong.Text = "6. Cho vào điều trị tại khoa :";
            this.lblKhoaphong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_kb_chuy
            // 
            this.c_kb_chuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_chuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_chuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_chuy.Location = new System.Drawing.Point(303, 608);
            this.c_kb_chuy.Name = "c_kb_chuy";
            this.c_kb_chuy.Size = new System.Drawing.Size(569, 21);
            this.c_kb_chuy.TabIndex = 75;
            this.c_kb_chuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(157, 9);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(117, 16);
            this.label49.TabIndex = 283;
            this.label49.Text = "BÁC SĨ KHÁM BỆNH :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panMenu
            // 
            this.panMenu.Controls.Add(this.butTiemchung);
            this.panMenu.Controls.Add(this.butbenhmantinh);
            this.panMenu.Controls.Add(this.butdausinhton);
            this.panMenu.Controls.Add(this.butPhanungcohai);
            this.panMenu.Controls.Add(this.butKhuyettat);
            this.panMenu.Controls.Add(this.buttmh);
            this.panMenu.Controls.Add(this.buttiensu);
            this.panMenu.Controls.Add(this.butlichhen);
            this.panMenu.Controls.Add(this.butdiungthuoc);
            this.panMenu.Controls.Add(this.butkemtheo);
            this.panMenu.Controls.Add(this.buttutruc);
            this.panMenu.Controls.Add(this.buttainantt);
            this.panMenu.Controls.Add(this.butchidinh);
            this.panMenu.Controls.Add(this.butphauthuat);
            this.panMenu.Controls.Add(this.but_thuocdan);
            this.panMenu.Controls.Add(this.but_thuocbhyt);
            this.panMenu.Controls.Add(this.butIncv);
            this.panMenu.Location = new System.Drawing.Point(2, 178);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(146, 463);
            this.panMenu.TabIndex = 89;
            // 
            // butTiemchung
            // 
            this.butTiemchung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butTiemchung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butTiemchung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butTiemchung.Image = ((System.Drawing.Image)(resources.GetObject("butTiemchung.Image")));
            this.butTiemchung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiemchung.Location = new System.Drawing.Point(1, 95);
            this.butTiemchung.Name = "butTiemchung";
            this.butTiemchung.Size = new System.Drawing.Size(143, 23);
            this.butTiemchung.TabIndex = 320;
            this.butTiemchung.Text = "      Chỉ định Vacxin";
            this.butTiemchung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiemchung.UseVisualStyleBackColor = false;
            this.butTiemchung.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butTiemchung.Click += new System.EventHandler(this.butTiemchung_Click);
            this.butTiemchung.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butbenhmantinh
            // 
            this.butbenhmantinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butbenhmantinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butbenhmantinh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butbenhmantinh.Image = ((System.Drawing.Image)(resources.GetObject("butbenhmantinh.Image")));
            this.butbenhmantinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butbenhmantinh.Location = new System.Drawing.Point(1, 279);
            this.butbenhmantinh.Name = "butbenhmantinh";
            this.butbenhmantinh.Size = new System.Drawing.Size(143, 23);
            this.butbenhmantinh.TabIndex = 319;
            this.butbenhmantinh.Text = "      Bệnh mãn tính";
            this.butbenhmantinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butbenhmantinh.UseVisualStyleBackColor = false;
            this.butbenhmantinh.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butbenhmantinh.Click += new System.EventHandler(this.butbenhmantinh_Click);
            this.butbenhmantinh.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butdausinhton
            // 
            this.butdausinhton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butdausinhton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butdausinhton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butdausinhton.Image = ((System.Drawing.Image)(resources.GetObject("butdausinhton.Image")));
            this.butdausinhton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdausinhton.Location = new System.Drawing.Point(1, 164);
            this.butdausinhton.Name = "butdausinhton";
            this.butdausinhton.Size = new System.Drawing.Size(143, 23);
            this.butdausinhton.TabIndex = 318;
            this.butdausinhton.Tag = "0";
            this.butdausinhton.Text = "      Dấu sinh tồn";
            this.butdausinhton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdausinhton.UseVisualStyleBackColor = false;
            this.butdausinhton.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butdausinhton.Click += new System.EventHandler(this.butdausinhton_Click);
            this.butdausinhton.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butPhanungcohai
            // 
            this.butPhanungcohai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butPhanungcohai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butPhanungcohai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butPhanungcohai.Image = ((System.Drawing.Image)(resources.GetObject("butPhanungcohai.Image")));
            this.butPhanungcohai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanungcohai.Location = new System.Drawing.Point(1, 233);
            this.butPhanungcohai.Name = "butPhanungcohai";
            this.butPhanungcohai.Size = new System.Drawing.Size(143, 23);
            this.butPhanungcohai.TabIndex = 317;
            this.butPhanungcohai.Text = "      Phản ứng thuốc có hại";
            this.butPhanungcohai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanungcohai.UseVisualStyleBackColor = false;
            this.butPhanungcohai.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butPhanungcohai.Click += new System.EventHandler(this.butPhanungcohai_Click);
            this.butPhanungcohai.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butKhuyettat
            // 
            this.butKhuyettat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butKhuyettat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKhuyettat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butKhuyettat.Image = ((System.Drawing.Image)(resources.GetObject("butKhuyettat.Image")));
            this.butKhuyettat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhuyettat.Location = new System.Drawing.Point(1, 187);
            this.butKhuyettat.Name = "butKhuyettat";
            this.butKhuyettat.Size = new System.Drawing.Size(143, 23);
            this.butKhuyettat.TabIndex = 316;
            this.butKhuyettat.Text = "      Khuyết tật";
            this.butKhuyettat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhuyettat.UseVisualStyleBackColor = false;
            this.butKhuyettat.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butKhuyettat.Click += new System.EventHandler(this.butKhuyettat_Click);
            this.butKhuyettat.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // buttmh
            // 
            this.buttmh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttmh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttmh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttmh.Image = ((System.Drawing.Image)(resources.GetObject("buttmh.Image")));
            this.buttmh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttmh.Location = new System.Drawing.Point(1, 371);
            this.buttmh.Name = "buttmh";
            this.buttmh.Size = new System.Drawing.Size(143, 23);
            this.buttmh.TabIndex = 314;
            this.buttmh.Text = "      TMH Đầu mặt cổ";
            this.buttmh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttmh.UseVisualStyleBackColor = false;
            this.buttmh.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.buttmh.Click += new System.EventHandler(this.buttmh_Click);
            this.buttmh.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // buttiensu
            // 
            this.buttiensu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttiensu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttiensu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttiensu.Image = ((System.Drawing.Image)(resources.GetObject("buttiensu.Image")));
            this.buttiensu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttiensu.Location = new System.Drawing.Point(1, 256);
            this.buttiensu.Name = "buttiensu";
            this.buttiensu.Size = new System.Drawing.Size(143, 23);
            this.buttiensu.TabIndex = 314;
            this.buttiensu.Text = "      Tiền sử bệnh";
            this.buttiensu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttiensu.UseVisualStyleBackColor = false;
            this.buttiensu.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.buttiensu.Click += new System.EventHandler(this.buttiensu_Click);
            this.buttiensu.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butlichhen
            // 
            this.butlichhen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butlichhen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butlichhen.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butlichhen.Image = ((System.Drawing.Image)(resources.GetObject("butlichhen.Image")));
            this.butlichhen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butlichhen.Location = new System.Drawing.Point(1, 325);
            this.butlichhen.Name = "butlichhen";
            this.butlichhen.Size = new System.Drawing.Size(143, 23);
            this.butlichhen.TabIndex = 314;
            this.butlichhen.Text = "      Lịch hẹn";
            this.butlichhen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butlichhen.UseVisualStyleBackColor = false;
            this.butlichhen.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butlichhen.Click += new System.EventHandler(this.butlichhen_Click);
            this.butlichhen.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butdiungthuoc
            // 
            this.butdiungthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butdiungthuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butdiungthuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butdiungthuoc.Image = ((System.Drawing.Image)(resources.GetObject("butdiungthuoc.Image")));
            this.butdiungthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdiungthuoc.Location = new System.Drawing.Point(1, 210);
            this.butdiungthuoc.Name = "butdiungthuoc";
            this.butdiungthuoc.Size = new System.Drawing.Size(143, 23);
            this.butdiungthuoc.TabIndex = 314;
            this.butdiungthuoc.Text = "      Dị ứng thuốc";
            this.butdiungthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdiungthuoc.UseVisualStyleBackColor = false;
            this.butdiungthuoc.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butdiungthuoc.Click += new System.EventHandler(this.butdiungthuoc_Click);
            this.butdiungthuoc.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butkemtheo
            // 
            this.butkemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butkemtheo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butkemtheo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butkemtheo.Image = ((System.Drawing.Image)(resources.GetObject("butkemtheo.Image")));
            this.butkemtheo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butkemtheo.Location = new System.Drawing.Point(1, 302);
            this.butkemtheo.Name = "butkemtheo";
            this.butkemtheo.Size = new System.Drawing.Size(143, 23);
            this.butkemtheo.TabIndex = 314;
            this.butkemtheo.Text = "      Bệnh kèm theo";
            this.butkemtheo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butkemtheo.UseVisualStyleBackColor = false;
            this.butkemtheo.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butkemtheo.Click += new System.EventHandler(this.butkemtheo_Click);
            this.butkemtheo.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // buttutruc
            // 
            this.buttutruc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttutruc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttutruc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttutruc.Image = ((System.Drawing.Image)(resources.GetObject("buttutruc.Image")));
            this.buttutruc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttutruc.Location = new System.Drawing.Point(1, 72);
            this.buttutruc.Name = "buttutruc";
            this.buttutruc.Size = new System.Drawing.Size(143, 23);
            this.buttutruc.TabIndex = 314;
            this.buttutruc.Text = "      Đơn thuốc tủ trực";
            this.buttutruc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttutruc.UseVisualStyleBackColor = false;
            this.buttutruc.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.buttutruc.Click += new System.EventHandler(this.buttutruc_Click);
            this.buttutruc.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // buttainantt
            // 
            this.buttainantt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttainantt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttainantt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttainantt.Image = ((System.Drawing.Image)(resources.GetObject("buttainantt.Image")));
            this.buttainantt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttainantt.Location = new System.Drawing.Point(1, 141);
            this.buttainantt.Name = "buttainantt";
            this.buttainantt.Size = new System.Drawing.Size(143, 23);
            this.buttainantt.TabIndex = 314;
            this.buttainantt.Text = "      Tai nạn, thương tích";
            this.buttainantt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttainantt.UseVisualStyleBackColor = false;
            this.buttainantt.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.buttainantt.Click += new System.EventHandler(this.buttainantt_Click);
            this.buttainantt.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butchidinh
            // 
            this.butchidinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butchidinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butchidinh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butchidinh.Image = ((System.Drawing.Image)(resources.GetObject("butchidinh.Image")));
            this.butchidinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchidinh.Location = new System.Drawing.Point(1, 3);
            this.butchidinh.Name = "butchidinh";
            this.butchidinh.Size = new System.Drawing.Size(143, 23);
            this.butchidinh.TabIndex = 314;
            this.butchidinh.Text = "      Chỉ định cận lâm sàng";
            this.butchidinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchidinh.UseVisualStyleBackColor = false;
            this.butchidinh.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butchidinh.Click += new System.EventHandler(this.butchidinh_Click);
            this.butchidinh.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butphauthuat
            // 
            this.butphauthuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butphauthuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butphauthuat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butphauthuat.Image = ((System.Drawing.Image)(resources.GetObject("butphauthuat.Image")));
            this.butphauthuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butphauthuat.Location = new System.Drawing.Point(1, 118);
            this.butphauthuat.Name = "butphauthuat";
            this.butphauthuat.Size = new System.Drawing.Size(143, 23);
            this.butphauthuat.TabIndex = 313;
            this.butphauthuat.Text = "      Phẫu / thủ thuật";
            this.butphauthuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butphauthuat.UseVisualStyleBackColor = false;
            this.butphauthuat.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butphauthuat.Click += new System.EventHandler(this.butphauthuat_Click);
            this.butphauthuat.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // but_thuocdan
            // 
            this.but_thuocdan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.but_thuocdan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_thuocdan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_thuocdan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.but_thuocdan.Image = ((System.Drawing.Image)(resources.GetObject("but_thuocdan.Image")));
            this.but_thuocdan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_thuocdan.Location = new System.Drawing.Point(1, 49);
            this.but_thuocdan.Name = "but_thuocdan";
            this.but_thuocdan.Size = new System.Drawing.Size(143, 23);
            this.but_thuocdan.TabIndex = 312;
            this.but_thuocdan.Text = "      Đơn thuốc dịch vụ";
            this.but_thuocdan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_thuocdan.UseVisualStyleBackColor = false;
            this.but_thuocdan.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.but_thuocdan.Click += new System.EventHandler(this.but_thuocdan_Click);
            this.but_thuocdan.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // but_thuocbhyt
            // 
            this.but_thuocbhyt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.but_thuocbhyt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_thuocbhyt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.but_thuocbhyt.Image = ((System.Drawing.Image)(resources.GetObject("but_thuocbhyt.Image")));
            this.but_thuocbhyt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_thuocbhyt.Location = new System.Drawing.Point(1, 26);
            this.but_thuocbhyt.Name = "but_thuocbhyt";
            this.but_thuocbhyt.Size = new System.Drawing.Size(143, 23);
            this.but_thuocbhyt.TabIndex = 311;
            this.but_thuocbhyt.Text = "      Đơn thuốc BHYT";
            this.but_thuocbhyt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_thuocbhyt.UseVisualStyleBackColor = false;
            this.but_thuocbhyt.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.but_thuocbhyt.Click += new System.EventHandler(this.but_thuocbhyt_Click);
            this.but_thuocbhyt.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // butIncv
            // 
            this.butIncv.BackColor = System.Drawing.SystemColors.Control;
            this.butIncv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIncv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIncv.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butIncv.Image = ((System.Drawing.Image)(resources.GetObject("butIncv.Image")));
            this.butIncv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIncv.Location = new System.Drawing.Point(1, 348);
            this.butIncv.Name = "butIncv";
            this.butIncv.Size = new System.Drawing.Size(143, 23);
            this.butIncv.TabIndex = 84;
            this.butIncv.Text = "      Chuyển viện";
            this.butIncv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIncv.UseVisualStyleBackColor = false;
            this.butIncv.MouseLeave += new System.EventHandler(this.butTiemchung_Leave);
            this.butIncv.Click += new System.EventHandler(this.butIncv_Click);
            this.butIncv.MouseEnter += new System.EventHandler(this.butTiemchung_Enter);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(160, 499);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 285;
            this.label11.Text = "4. Chẩn đoán - Sơ bộ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sobo
            // 
            this.sobo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sobo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sobo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobo.Location = new System.Drawing.Point(303, 498);
            this.sobo.Name = "sobo";
            this.sobo.Size = new System.Drawing.Size(569, 21);
            this.sobo.TabIndex = 62;
            this.sobo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // phanbiet
            // 
            this.phanbiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phanbiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanbiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanbiet.Location = new System.Drawing.Point(356, 542);
            this.phanbiet.Name = "phanbiet";
            this.phanbiet.Size = new System.Drawing.Size(516, 21);
            this.phanbiet.TabIndex = 66;
            this.phanbiet.TextChanged += new System.EventHandler(this.phanbiet_TextChanged);
            this.phanbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(212, 543);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(93, 17);
            this.label40.TabIndex = 287;
            this.label40.Text = "- Bệnh kèm theo :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lchiphi
            // 
            this.lchiphi.AutoSize = true;
            this.lchiphi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lchiphi.ForeColor = System.Drawing.Color.Red;
            this.lchiphi.Location = new System.Drawing.Point(450, 1);
            this.lchiphi.Name = "lchiphi";
            this.lchiphi.Size = new System.Drawing.Size(40, 13);
            this.lchiphi.TabIndex = 288;
            this.lchiphi.Text = "conlai";
            this.lchiphi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panHanhchanh
            // 
            this.panHanhchanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panHanhchanh.BackColor = System.Drawing.SystemColors.Control;
            this.panHanhchanh.Controls.Add(this.namsinh);
            this.panHanhchanh.Controls.Add(this.cbotuyen);
            this.panHanhchanh.Controls.Add(this.madoituong);
            this.panHanhchanh.Controls.Add(this.nhantu);
            this.panHanhchanh.Controls.Add(this.label68);
            this.panHanhchanh.Controls.Add(this.icd_noichuyenden);
            this.panHanhchanh.Controls.Add(this.madstt);
            this.panHanhchanh.Controls.Add(this.cholam);
            this.panHanhchanh.Controls.Add(this.matt);
            this.panHanhchanh.Controls.Add(this.mabn2);
            this.panHanhchanh.Controls.Add(this.label3);
            this.panHanhchanh.Controls.Add(this.pic);
            this.panHanhchanh.Controls.Add(this.label49);
            this.panHanhchanh.Controls.Add(this.tennoidk);
            this.panHanhchanh.Controls.Add(this.noidk);
            this.panHanhchanh.Controls.Add(this.label38);
            this.panHanhchanh.Controls.Add(this.denngay);
            this.panHanhchanh.Controls.Add(this.tungay);
            this.panHanhchanh.Controls.Add(this.label8);
            this.panHanhchanh.Controls.Add(this.sothe);
            this.panHanhchanh.Controls.Add(this.label24);
            this.panHanhchanh.Controls.Add(this.tendoituong);
            this.panHanhchanh.Controls.Add(this.label23);
            this.panHanhchanh.Controls.Add(this.tenkp);
            this.panHanhchanh.Controls.Add(this.makp);
            this.panHanhchanh.Controls.Add(this.label1);
            this.panHanhchanh.Controls.Add(this.tendstt);
            this.panHanhchanh.Controls.Add(this.label9);
            this.panHanhchanh.Controls.Add(this.tendentu);
            this.panHanhchanh.Controls.Add(this.dentu);
            this.panHanhchanh.Controls.Add(this.tennhantu);
            this.panHanhchanh.Controls.Add(this.tenbs);
            this.panHanhchanh.Controls.Add(this.label20);
            this.panHanhchanh.Controls.Add(this.ngayvv);
            this.panHanhchanh.Controls.Add(this.label19);
            this.panHanhchanh.Controls.Add(this.cd_noichuyenden);
            this.panHanhchanh.Controls.Add(this.lcholam);
            this.panHanhchanh.Controls.Add(this.sovaovien);
            this.panHanhchanh.Controls.Add(this.tenpxa);
            this.panHanhchanh.Controls.Add(this.maqu1);
            this.panHanhchanh.Controls.Add(this.mapxa2);
            this.panHanhchanh.Controls.Add(this.mapxa1);
            this.panHanhchanh.Controls.Add(this.lmaphuongxa);
            this.panHanhchanh.Controls.Add(this.tenquan);
            this.panHanhchanh.Controls.Add(this.loaituoi);
            this.panHanhchanh.Controls.Add(this.maqu2);
            this.panHanhchanh.Controls.Add(this.lmaqu);
            this.panHanhchanh.Controls.Add(this.tentinh);
            this.panHanhchanh.Controls.Add(this.mabs);
            this.panHanhchanh.Controls.Add(this.lmatt);
            this.panHanhchanh.Controls.Add(this.label52);
            this.panHanhchanh.Controls.Add(this.label25);
            this.panHanhchanh.Controls.Add(this.label4);
            this.panHanhchanh.Controls.Add(this.ngaysinh);
            this.panHanhchanh.Controls.Add(this.label5);
            this.panHanhchanh.Controls.Add(this.phai);
            this.panHanhchanh.Controls.Add(this.lphai);
            this.panHanhchanh.Controls.Add(this.label6);
            this.panHanhchanh.Controls.Add(this.label7);
            this.panHanhchanh.Controls.Add(this.mabn3);
            this.panHanhchanh.Controls.Add(this.tuoi);
            this.panHanhchanh.Controls.Add(this.hoten);
            this.panHanhchanh.Controls.Add(this.label31);
            this.panHanhchanh.Controls.Add(this.label30);
            this.panHanhchanh.Controls.Add(this.label21);
            this.panHanhchanh.Location = new System.Drawing.Point(152, 27);
            this.panHanhchanh.Name = "panHanhchanh";
            this.panHanhchanh.Size = new System.Drawing.Size(864, 164);
            this.panHanhchanh.TabIndex = 309;
            // 
            // cbotuyen
            // 
            this.cbotuyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbotuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotuyen.Enabled = false;
            this.cbotuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotuyen.Items.AddRange(new object[] {
            "Trái tuyến",
            "Đúng tuyến"});
            this.cbotuyen.Location = new System.Drawing.Point(511, 118);
            this.cbotuyen.Name = "cbotuyen";
            this.cbotuyen.Size = new System.Drawing.Size(127, 21);
            this.cbotuyen.TabIndex = 309;
            // 
            // label68
            // 
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(454, 119);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(60, 20);
            this.label68.TabIndex = 310;
            this.label68.Text = "Tuyến :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblnguoilogin
            // 
            this.lblnguoilogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnguoilogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnguoilogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnguoilogin.Location = new System.Drawing.Point(872, 147);
            this.lblnguoilogin.Name = "lblnguoilogin";
            this.lblnguoilogin.Size = new System.Drawing.Size(10, 11);
            this.lblnguoilogin.TabIndex = 308;
            this.lblnguoilogin.Visible = false;
            // 
            // p
            // 
            this.p.Controls.Add(this.pgoi);
            this.p.Controls.Add(this.toolStrip1);
            this.p.Dock = System.Windows.Forms.DockStyle.Top;
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(1016, 23);
            this.p.TabIndex = 310;
            // 
            // pgoi
            // 
            this.pgoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pgoi.Controls.Add(this.butgoilai);
            this.pgoi.Controls.Add(this.butgoibenh);
            this.pgoi.Controls.Add(this.label71);
            this.pgoi.Controls.Add(this.sonhay);
            this.pgoi.Controls.Add(this.den);
            this.pgoi.Controls.Add(this.tu);
            this.pgoi.Location = new System.Drawing.Point(786, 1);
            this.pgoi.Name = "pgoi";
            this.pgoi.Size = new System.Drawing.Size(227, 22);
            this.pgoi.TabIndex = 309;
            this.pgoi.Visible = false;
            // 
            // butgoilai
            // 
            this.butgoilai.BackColor = System.Drawing.SystemColors.Control;
            this.butgoilai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butgoilai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butgoilai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butgoilai.Location = new System.Drawing.Point(180, 0);
            this.butgoilai.Name = "butgoilai";
            this.butgoilai.Size = new System.Drawing.Size(44, 21);
            this.butgoilai.TabIndex = 341;
            this.butgoilai.Text = "Gọi lại";
            this.butgoilai.UseVisualStyleBackColor = false;
            this.butgoilai.Click += new System.EventHandler(this.butgoilai_Click);
            // 
            // butgoibenh
            // 
            this.butgoibenh.BackColor = System.Drawing.SystemColors.Control;
            this.butgoibenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butgoibenh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butgoibenh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butgoibenh.Location = new System.Drawing.Point(146, 0);
            this.butgoibenh.Name = "butgoibenh";
            this.butgoibenh.Size = new System.Drawing.Size(31, 21);
            this.butgoibenh.TabIndex = 340;
            this.butgoibenh.Text = "Gọi";
            this.butgoibenh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butgoibenh.UseVisualStyleBackColor = false;
            this.butgoibenh.Click += new System.EventHandler(this.butgoibenh_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(3, 4);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(26, 13);
            this.label71.TabIndex = 307;
            this.label71.Text = "Số :";
            // 
            // sonhay
            // 
            this.sonhay.Location = new System.Drawing.Point(108, 0);
            this.sonhay.Name = "sonhay";
            this.sonhay.Size = new System.Drawing.Size(36, 20);
            this.sonhay.TabIndex = 308;
            // 
            // den
            // 
            this.den.Location = new System.Drawing.Point(70, 0);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(36, 20);
            this.den.TabIndex = 305;
            // 
            // tu
            // 
            this.tu.Location = new System.Drawing.Point(32, 0);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(36, 20);
            this.tu.TabIndex = 306;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barDonthuocngoai,
            this.toolStripSeparator1,
            this.barDonthuocduoc,
            this.toolStripSeparator2,
            this.barChidinh,
            this.toolStripSeparator3,
            this.barTainantt,
            this.toolStripSeparator4,
            this.barTutruc,
            this.toolStripSeparator6,
            this.barBenhkemtheo,
            this.toolStripSeparator7,
            this.barXemcls,
            this.toolStripSeparator8,
            this.barLichhen,
            this.toolStripSeparator9,
            this.barPhanUng,
            this.toolStripSeparator10,
            this.barSudungthuoc,
            this.toolStripSeparator13,
            this.barPttt,
            this.toolStripSeparator14,
            this.barTiensubenh,
            this.toolStripSeparator15,
            this.barTmh,
            this.toolStripSeparator16,
            this.barDausinhton,
            this.toolStripSeparator17,
            this.barbenhmantinh,
            this.toolStripSeparator5,
            this.tbutvantay,
            this.toolStripSeparator19,
            this.barKetthuc,
            this.toolStripSeparator11,
            this.toolStripSplitButton1,
            this.toolStripSeparator12,
            this.mnuTienich});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 23);
            this.toolStrip1.TabIndex = 302;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // barDonthuocngoai
            // 
            this.barDonthuocngoai.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDonthuocngoai.Image = ((System.Drawing.Image)(resources.GetObject("barDonthuocngoai.Image")));
            this.barDonthuocngoai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDonthuocngoai.Name = "barDonthuocngoai";
            this.barDonthuocngoai.Size = new System.Drawing.Size(23, 20);
            this.barDonthuocngoai.Text = "toolStripButton1";
            this.barDonthuocngoai.ToolTipText = "Đơn thuốc mua ngoài";
            this.barDonthuocngoai.Click += new System.EventHandler(this.but_thuocdan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // barDonthuocduoc
            // 
            this.barDonthuocduoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDonthuocduoc.Image = ((System.Drawing.Image)(resources.GetObject("barDonthuocduoc.Image")));
            this.barDonthuocduoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDonthuocduoc.Name = "barDonthuocduoc";
            this.barDonthuocduoc.Size = new System.Drawing.Size(23, 20);
            this.barDonthuocduoc.Text = "toolStripButton1";
            this.barDonthuocduoc.ToolTipText = "Đơn thuốc dược phát";
            this.barDonthuocduoc.Click += new System.EventHandler(this.but_thuocbhyt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // barChidinh
            // 
            this.barChidinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChidinh.Image = ((System.Drawing.Image)(resources.GetObject("barChidinh.Image")));
            this.barChidinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChidinh.Name = "barChidinh";
            this.barChidinh.Size = new System.Drawing.Size(23, 20);
            this.barChidinh.Text = "toolStripButton1";
            this.barChidinh.ToolTipText = "Chỉ định cận lâm sàng";
            this.barChidinh.Click += new System.EventHandler(this.butchidinh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // barTainantt
            // 
            this.barTainantt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barTainantt.Image = ((System.Drawing.Image)(resources.GetObject("barTainantt.Image")));
            this.barTainantt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barTainantt.Name = "barTainantt";
            this.barTainantt.Size = new System.Drawing.Size(23, 20);
            this.barTainantt.Text = "toolStripButton1";
            this.barTainantt.ToolTipText = "Tai nạn thương tích";
            this.barTainantt.Click += new System.EventHandler(this.buttainantt_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // barTutruc
            // 
            this.barTutruc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barTutruc.Image = ((System.Drawing.Image)(resources.GetObject("barTutruc.Image")));
            this.barTutruc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barTutruc.Name = "barTutruc";
            this.barTutruc.Size = new System.Drawing.Size(23, 20);
            this.barTutruc.Text = "toolStripButton3";
            this.barTutruc.ToolTipText = "Tủ trực";
            this.barTutruc.Click += new System.EventHandler(this.buttutruc_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // barBenhkemtheo
            // 
            this.barBenhkemtheo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barBenhkemtheo.Image = ((System.Drawing.Image)(resources.GetObject("barBenhkemtheo.Image")));
            this.barBenhkemtheo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barBenhkemtheo.Name = "barBenhkemtheo";
            this.barBenhkemtheo.Size = new System.Drawing.Size(23, 20);
            this.barBenhkemtheo.Text = "toolStripButton4";
            this.barBenhkemtheo.ToolTipText = "Bệnh kèm theo";
            this.barBenhkemtheo.Click += new System.EventHandler(this.butkemtheo_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // barXemcls
            // 
            this.barXemcls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barXemcls.Image = ((System.Drawing.Image)(resources.GetObject("barXemcls.Image")));
            this.barXemcls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barXemcls.Name = "barXemcls";
            this.barXemcls.Size = new System.Drawing.Size(23, 20);
            this.barXemcls.Text = "toolStripButton5";
            this.barXemcls.ToolTipText = "Xem cận lâm sàn";
            this.barXemcls.Click += new System.EventHandler(this.butcls_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // barLichhen
            // 
            this.barLichhen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barLichhen.Image = ((System.Drawing.Image)(resources.GetObject("barLichhen.Image")));
            this.barLichhen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barLichhen.Name = "barLichhen";
            this.barLichhen.Size = new System.Drawing.Size(23, 20);
            this.barLichhen.Text = "toolStripButton6";
            this.barLichhen.ToolTipText = "Lịch hẹn";
            this.barLichhen.Click += new System.EventHandler(this.butlichhen_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // barPhanUng
            // 
            this.barPhanUng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPhanUng.Image = ((System.Drawing.Image)(resources.GetObject("barPhanUng.Image")));
            this.barPhanUng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPhanUng.Name = "barPhanUng";
            this.barPhanUng.Size = new System.Drawing.Size(23, 20);
            this.barPhanUng.Text = "toolStripButton7";
            this.barPhanUng.ToolTipText = "Phản ứng";
            this.barPhanUng.Click += new System.EventHandler(this.butdiungthuoc_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // barSudungthuoc
            // 
            this.barSudungthuoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barSudungthuoc.Image = ((System.Drawing.Image)(resources.GetObject("barSudungthuoc.Image")));
            this.barSudungthuoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barSudungthuoc.Name = "barSudungthuoc";
            this.barSudungthuoc.Size = new System.Drawing.Size(23, 20);
            this.barSudungthuoc.Text = "toolStripButton1";
            this.barSudungthuoc.ToolTipText = "Sử dụng thuốc";
            this.barSudungthuoc.Click += new System.EventHandler(this.butsudungthuoc_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 23);
            // 
            // barPttt
            // 
            this.barPttt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPttt.Image = ((System.Drawing.Image)(resources.GetObject("barPttt.Image")));
            this.barPttt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPttt.Name = "barPttt";
            this.barPttt.Size = new System.Drawing.Size(23, 20);
            this.barPttt.Text = "toolStripButton1";
            this.barPttt.ToolTipText = "Phẫu thuật thủ thuật";
            this.barPttt.Click += new System.EventHandler(this.butphauthuat_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 23);
            // 
            // barTiensubenh
            // 
            this.barTiensubenh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barTiensubenh.Image = ((System.Drawing.Image)(resources.GetObject("barTiensubenh.Image")));
            this.barTiensubenh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barTiensubenh.Name = "barTiensubenh";
            this.barTiensubenh.Size = new System.Drawing.Size(23, 20);
            this.barTiensubenh.Text = "toolStripButton1";
            this.barTiensubenh.ToolTipText = "Tiền sử bệnh";
            this.barTiensubenh.Click += new System.EventHandler(this.buttiensu_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 23);
            // 
            // barTmh
            // 
            this.barTmh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barTmh.Image = ((System.Drawing.Image)(resources.GetObject("barTmh.Image")));
            this.barTmh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barTmh.Name = "barTmh";
            this.barTmh.Size = new System.Drawing.Size(23, 20);
            this.barTmh.Text = "toolStripButton1";
            this.barTmh.ToolTipText = "TMH Đầu mặt cổ";
            this.barTmh.Click += new System.EventHandler(this.buttmh_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 23);
            // 
            // barDausinhton
            // 
            this.barDausinhton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDausinhton.Image = ((System.Drawing.Image)(resources.GetObject("barDausinhton.Image")));
            this.barDausinhton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDausinhton.Name = "barDausinhton";
            this.barDausinhton.Size = new System.Drawing.Size(23, 20);
            this.barDausinhton.Text = "Dấu sinh tồn";
            this.barDausinhton.Click += new System.EventHandler(this.butdausinhton_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 23);
            // 
            // barbenhmantinh
            // 
            this.barbenhmantinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barbenhmantinh.Image = ((System.Drawing.Image)(resources.GetObject("barbenhmantinh.Image")));
            this.barbenhmantinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barbenhmantinh.Name = "barbenhmantinh";
            this.barbenhmantinh.Size = new System.Drawing.Size(23, 20);
            this.barbenhmantinh.Text = "Bệnh mãn tính";
            this.barbenhmantinh.Click += new System.EventHandler(this.barbenhmantinh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutvantay
            // 
            this.tbutvantay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbutvantay.Image = ((System.Drawing.Image)(resources.GetObject("tbutvantay.Image")));
            this.tbutvantay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbutvantay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutvantay.Name = "tbutvantay";
            this.tbutvantay.Size = new System.Drawing.Size(23, 20);
            this.tbutvantay.Text = "F5";
            this.tbutvantay.ToolTipText = "Vân tay";
            this.tbutvantay.Click += new System.EventHandler(this.tbutvantay_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 23);
            // 
            // barKetthuc
            // 
            this.barKetthuc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("barKetthuc.Image")));
            this.barKetthuc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barKetthuc.Name = "barKetthuc";
            this.barKetthuc.Size = new System.Drawing.Size(23, 20);
            this.barKetthuc.Text = "toolStripButton2";
            this.barKetthuc.ToolTipText = "Kết thúc";
            this.barKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkLCD,
            this.tsLCD,
            this.chkXem,
            this.chkTudongchonthongso,
            this.chkXml});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(89, 20);
            this.toolStripSplitButton1.Text = "Tuỳ chọn";
            // 
            // chkLCD
            // 
            this.chkLCD.CheckOnClick = true;
            this.chkLCD.Name = "chkLCD";
            this.chkLCD.Size = new System.Drawing.Size(264, 22);
            this.chkLCD.Text = "Xuất danh sách khám bệnh ra LCD";
            // 
            // tsLCD
            // 
            this.tsLCD.Name = "tsLCD";
            this.tsLCD.Size = new System.Drawing.Size(264, 22);
            this.tsLCD.Text = "Thông số LCD";
            this.tsLCD.Click += new System.EventHandler(this.tsLCD_Click);
            // 
            // chkXem
            // 
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(264, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkTudongchonthongso
            // 
            this.chkTudongchonthongso.CheckOnClick = true;
            this.chkTudongchonthongso.Name = "chkTudongchonthongso";
            this.chkTudongchonthongso.Size = new System.Drawing.Size(264, 22);
            this.chkTudongchonthongso.Text = "Tự động chọn thông số khi chỉ định";
            // 
            // chkXml
            // 
            this.chkXml.CheckOnClick = true;
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(264, 22);
            this.chkXml.Text = "Xml";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // mnuTienich
            // 
            this.mnuTienich.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butBienbantuvong,
            this.butChamdoc,
            this.butTruyendich,
            this.butPhieuchuyenkhamchuyenkhoa,
            this.mnuBaolucgiadinh,
            this.toolStripMenuItem1,
            this.butXemtonkho,
            this.butXemhosobenhan,
            this.butXemthuocdadung});
            this.mnuTienich.Image = ((System.Drawing.Image)(resources.GetObject("mnuTienich.Image")));
            this.mnuTienich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTienich.Name = "mnuTienich";
            this.mnuTienich.Size = new System.Drawing.Size(78, 20);
            this.mnuTienich.Text = "Tiện ích";
            // 
            // butBienbantuvong
            // 
            this.butBienbantuvong.Name = "butBienbantuvong";
            this.butBienbantuvong.Size = new System.Drawing.Size(258, 22);
            this.butBienbantuvong.Text = "Biên bản hội chẩn tử vong";
            this.butBienbantuvong.Click += new System.EventHandler(this.l_tuvong_Click);
            // 
            // butChamdoc
            // 
            this.butChamdoc.Name = "butChamdoc";
            this.butChamdoc.Size = new System.Drawing.Size(258, 22);
            this.butChamdoc.Text = "Phiếu chăm sóc";
            this.butChamdoc.Click += new System.EventHandler(this.butChamsoc_Click);
            // 
            // butTruyendich
            // 
            this.butTruyendich.Name = "butTruyendich";
            this.butTruyendich.Size = new System.Drawing.Size(258, 22);
            this.butTruyendich.Text = "Phiếu truyền dịch";
            this.butTruyendich.Click += new System.EventHandler(this.butTruyendich_Click);
            // 
            // butPhieuchuyenkhamchuyenkhoa
            // 
            this.butPhieuchuyenkhamchuyenkhoa.Name = "butPhieuchuyenkhamchuyenkhoa";
            this.butPhieuchuyenkhamchuyenkhoa.Size = new System.Drawing.Size(258, 22);
            this.butPhieuchuyenkhamchuyenkhoa.Text = "Phiếu chuyển khám chuyên khoa";
            this.butPhieuchuyenkhamchuyenkhoa.Click += new System.EventHandler(this.butPhieuchuyenkhamchuyenkhoa_Click);
            // 
            // mnuBaolucgiadinh
            // 
            this.mnuBaolucgiadinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butPhieusangloc,
            this.butPhieughichep,
            this.butGiayxacnhan});
            this.mnuBaolucgiadinh.Name = "mnuBaolucgiadinh";
            this.mnuBaolucgiadinh.Size = new System.Drawing.Size(258, 22);
            this.mnuBaolucgiadinh.Text = "Bạo lực gia đình";
            // 
            // butPhieusangloc
            // 
            this.butPhieusangloc.Name = "butPhieusangloc";
            this.butPhieusangloc.Size = new System.Drawing.Size(346, 22);
            this.butPhieusangloc.Text = "Phiếu sàng lọc nạn nhân bạo lực gia đình";
            this.butPhieusangloc.Click += new System.EventHandler(this.butPhieusangloc_Click);
            // 
            // butPhieughichep
            // 
            this.butPhieughichep.Name = "butPhieughichep";
            this.butPhieughichep.Size = new System.Drawing.Size(346, 22);
            this.butPhieughichep.Text = "Phiếu ghi chép thông tin nạn nhân bạo lực gia đình";
            this.butPhieughichep.Click += new System.EventHandler(this.butPhieughichep_Click);
            // 
            // butGiayxacnhan
            // 
            this.butGiayxacnhan.Name = "butGiayxacnhan";
            this.butGiayxacnhan.Size = new System.Drawing.Size(346, 22);
            this.butGiayxacnhan.Text = "Giấy xác nhận";
            this.butGiayxacnhan.Click += new System.EventHandler(this.butGiayxacnhan_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.toolStripMenuItem1.Text = "Phiếu thanh toán ra viện";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.butChiphi_Click);
            // 
            // butXemtonkho
            // 
            this.butXemtonkho.Name = "butXemtonkho";
            this.butXemtonkho.Size = new System.Drawing.Size(258, 22);
            this.butXemtonkho.Text = "Xem tồn kho";
            this.butXemtonkho.Click += new System.EventHandler(this.buttonkho_Click);
            // 
            // butXemhosobenhan
            // 
            this.butXemhosobenhan.Name = "butXemhosobenhan";
            this.butXemhosobenhan.Size = new System.Drawing.Size(258, 22);
            this.butXemhosobenhan.Text = "Xem hồ sơ bệnh án của bệnh nhân";
            this.butXemhosobenhan.Click += new System.EventHandler(this.butcls_Click);
            // 
            // butXemthuocdadung
            // 
            this.butXemthuocdadung.Name = "butXemthuocdadung";
            this.butXemthuocdadung.Size = new System.Drawing.Size(258, 22);
            this.butXemthuocdadung.Text = "Xem thuốc đã sử dụng";
            this.butXemthuocdadung.Click += new System.EventHandler(this.butsudungthuoc_Click);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(303, 542);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(51, 21);
            this.icd_kemtheo.TabIndex = 65;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            this.icd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_kemtheo_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lmann);
            this.panel4.Controls.Add(this.mann);
            this.panel4.Controls.Add(this.tennn);
            this.panel4.Controls.Add(this.lmadantoc);
            this.panel4.Controls.Add(this.madantoc);
            this.panel4.Controls.Add(this.tendantoc);
            this.panel4.Controls.Add(this.qh_dienthoai);
            this.panel4.Controls.Add(this.lmanuoc);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.tennuoc);
            this.panel4.Controls.Add(this.qh_diachi);
            this.panel4.Controls.Add(this.lsonha);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Controls.Add(this.manuoc);
            this.panel4.Controls.Add(this.qh_hoten);
            this.panel4.Controls.Add(this.sonha);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.lthon);
            this.panel4.Controls.Add(this.quanhe);
            this.panel4.Controls.Add(this.thon);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.tentqx);
            this.panel4.Controls.Add(this.bnmoi);
            this.panel4.Controls.Add(this.ltqx);
            this.panel4.Controls.Add(this.tqx);
            this.panel4.Controls.Add(this.l_bnmoi);
            this.panel4.Controls.Add(this.khamthai);
            this.panel4.Location = new System.Drawing.Point(156, 674);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(82, 58);
            this.panel4.TabIndex = 340;
            this.panel4.Visible = false;
            // 
            // label72
            // 
            this.label72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label72.BackColor = System.Drawing.Color.Teal;
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(872, 484);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(144, 19);
            this.label72.TabIndex = 341;
            this.label72.Text = "* Hướng xử lý";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenbv
            // 
            this.txtTenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenbv.Enabled = false;
            this.txtTenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenbv.Location = new System.Drawing.Point(570, 586);
            this.txtTenbv.Name = "txtTenbv";
            this.txtTenbv.Size = new System.Drawing.Size(302, 21);
            this.txtTenbv.TabIndex = 74;
            this.txtTenbv.TextChanged += new System.EventHandler(this.txtTenbv_TextChanged);
            this.txtTenbv.Validated += new System.EventHandler(this.txtTenbv_Validated);
            this.txtTenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenbv_KeyDown);
            this.txtTenbv.EnabledChanged += new System.EventHandler(this.txtTenbv_EnabledChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.multiColumnListBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 153);
            this.groupBox1.TabIndex = 344;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH ĐĂNG KÝ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(0, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Tìm kiếm";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBenhvien
            // 
            this.listBenhvien.BackColor = System.Drawing.SystemColors.Info;
            this.listBenhvien.ColumnCount = 0;
            this.listBenhvien.Location = new System.Drawing.Point(516, 663);
            this.listBenhvien.MatchBufferTimeOut = 1000;
            this.listBenhvien.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBenhvien.Name = "listBenhvien";
            this.listBenhvien.Size = new System.Drawing.Size(75, 17);
            this.listBenhvien.TabIndex = 343;
            this.listBenhvien.TextIndex = -1;
            this.listBenhvien.TextMember = null;
            this.listBenhvien.ValueIndex = -1;
            this.listBenhvien.Visible = false;
            this.listBenhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBenhvien_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(784, 712);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 225;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(704, 712);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 216;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // list1
            // 
            this.list1.BackColor = System.Drawing.SystemColors.Info;
            this.list1.ColumnCount = 0;
            this.list1.Location = new System.Drawing.Point(856, 712);
            this.list1.MatchBufferTimeOut = 1000;
            this.list1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(75, 17);
            this.list1.TabIndex = 258;
            this.list1.TextIndex = -1;
            this.list1.TextMember = null;
            this.list1.ValueIndex = -1;
            this.list1.Visible = false;
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(688, 720);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 215;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // c_kb_hong
            // 
            this.c_kb_hong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_hong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_hong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_hong.Location = new System.Drawing.Point(303, 441);
            this.c_kb_hong.Multiline = true;
            this.c_kb_hong.Name = "c_kb_hong";
            this.c_kb_hong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_hong.Size = new System.Drawing.Size(569, 28);
            this.c_kb_hong.TabIndex = 348;
            this.c_kb_hong.TextChanged += new System.EventHandler(this.c_kb_hong_TextChanged);
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label73.Location = new System.Drawing.Point(224, 447);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(46, 16);
            this.label73.TabIndex = 351;
            this.label73.Text = "Họng :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_kb_mui
            // 
            this.c_kb_mui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_mui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_mui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_mui.Location = new System.Drawing.Point(303, 408);
            this.c_kb_mui.Multiline = true;
            this.c_kb_mui.Name = "c_kb_mui";
            this.c_kb_mui.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_mui.Size = new System.Drawing.Size(569, 32);
            this.c_kb_mui.TabIndex = 347;
            this.c_kb_mui.TextChanged += new System.EventHandler(this.c_kb_mui_TextChanged);
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label74.Location = new System.Drawing.Point(224, 416);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(40, 16);
            this.label74.TabIndex = 350;
            this.label74.Text = "Mũi :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_kb_tai
            // 
            this.c_kb_tai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_kb_tai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c_kb_tai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_kb_tai.Location = new System.Drawing.Point(303, 375);
            this.c_kb_tai.Multiline = true;
            this.c_kb_tai.Name = "c_kb_tai";
            this.c_kb_tai.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_kb_tai.Size = new System.Drawing.Size(569, 32);
            this.c_kb_tai.TabIndex = 346;
            this.c_kb_tai.TextChanged += new System.EventHandler(this.c_kb_tai_TextChanged);
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(224, 379);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(37, 16);
            this.label75.TabIndex = 349;
            this.label75.Text = "Tai :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.SystemColors.Control;
            this.label77.Image = ((System.Drawing.Image)(resources.GetObject("label77.Image")));
            this.label77.Location = new System.Drawing.Point(285, 381);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(16, 16);
            this.label77.TabIndex = 352;
            this.label77.Tag = "";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.SystemColors.Control;
            this.label79.Image = ((System.Drawing.Image)(resources.GetObject("label79.Image")));
            this.label79.Location = new System.Drawing.Point(285, 413);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(16, 16);
            this.label79.TabIndex = 354;
            this.label79.Tag = "";
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.SystemColors.Control;
            this.label81.Image = ((System.Drawing.Image)(resources.GetObject("label81.Image")));
            this.label81.Location = new System.Drawing.Point(285, 444);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(16, 16);
            this.label81.TabIndex = 356;
            this.label81.Tag = "";
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(802, 632);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(69, 25);
            this.butKetthuc.TabIndex = 85;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.BackColor = System.Drawing.SystemColors.Control;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(733, 632);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(69, 25);
            this.butIn.TabIndex = 83;
            this.butIn.Text = "     &In";
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(664, 632);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(69, 25);
            this.butBoqua.TabIndex = 81;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(595, 632);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(69, 25);
            this.butLuu.TabIndex = 80;
            this.butLuu.Tag = "0";
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butTiep.BackColor = System.Drawing.SystemColors.Control;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(526, 632);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(69, 25);
            this.butTiep.TabIndex = 82;
            this.butTiep.Text = "      &Tiếp";
            this.butTiep.UseVisualStyleBackColor = true;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.SystemColors.Control;
            this.label69.Image = ((System.Drawing.Image)(resources.GetObject("label69.Image")));
            this.label69.Location = new System.Drawing.Point(285, 353);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(18, 16);
            this.label69.TabIndex = 339;
            this.label69.Tag = "";
            this.label69.Click += new System.EventHandler(this.label69_Click);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Image = ((System.Drawing.Image)(resources.GetObject("label42.Image")));
            this.label42.Location = new System.Drawing.Point(284, 328);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(18, 16);
            this.label42.TabIndex = 337;
            this.label42.Tag = "";
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.Image = ((System.Drawing.Image)(resources.GetObject("label46.Image")));
            this.label46.Location = new System.Drawing.Point(278, 328);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(22, 16);
            this.label46.TabIndex = 336;
            this.label46.Tag = "";
            this.label46.Visible = false;
            this.label46.Click += new System.EventHandler(this.label46_Click);
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.SystemColors.Control;
            this.label70.Image = ((System.Drawing.Image)(resources.GetObject("label70.Image")));
            this.label70.Location = new System.Drawing.Point(279, 353);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(22, 16);
            this.label70.TabIndex = 338;
            this.label70.Tag = "";
            this.label70.Visible = false;
            this.label70.Click += new System.EventHandler(this.label70_Click);
            // 
            // ptb
            // 
            this.ptb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptb.BackColor = System.Drawing.SystemColors.Control;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptb.InitialImage")));
            this.ptb.Location = new System.Drawing.Point(5, 573);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(48, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 345;
            this.ptb.TabStop = false;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.Control;
            this.label76.Image = ((System.Drawing.Image)(resources.GetObject("label76.Image")));
            this.label76.Location = new System.Drawing.Point(279, 381);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(22, 16);
            this.label76.TabIndex = 353;
            this.label76.Tag = "";
            this.label76.Visible = false;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.SystemColors.Control;
            this.label78.Image = ((System.Drawing.Image)(resources.GetObject("label78.Image")));
            this.label78.Location = new System.Drawing.Point(279, 413);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(22, 16);
            this.label78.TabIndex = 355;
            this.label78.Tag = "";
            this.label78.Visible = false;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.SystemColors.Control;
            this.label80.Image = ((System.Drawing.Image)(resources.GetObject("label80.Image")));
            this.label80.Location = new System.Drawing.Point(279, 444);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(22, 16);
            this.label80.TabIndex = 357;
            this.label80.Tag = "";
            this.label80.Visible = false;
            // 
            // frmKhambenh_tmh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 686);
            this.Controls.Add(this.c_kb_hong);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.c_kb_mui);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.c_kb_tai);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label81);
            this.Controls.Add(this.listBenhvien);
            this.Controls.Add(this.panMenu);
            this.Controls.Add(this.hen);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.lblnguoilogin);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.p);
            this.Controls.Add(this.danhsach);
            this.Controls.Add(this.lchiphi);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.lblhd);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.phanbiet);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.sobo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tenbs_pass);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.lblKhoaphong);
            this.Controls.Add(this.c_kb_xuli);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.c_kb_tomtat);
            this.Controls.Add(this.c_kb_bophan);
            this.Controls.Add(this.c_kb_toanthan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.c_hb_giadinh);
            this.Controls.Add(this.c_hb_banthan);
            this.Controls.Add(this.c_hb_benhly);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.c_lydo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.pmat);
            this.Controls.Add(this.maxutri);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.listdstt);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.c_kb_chuy);
            this.Controls.Add(this.txtTenbv);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panHanhchanh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.label80);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKhambenh_tmh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu khám bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKhambenh_tmh_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhambenh_tmh_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhambenh_tmh_KeyDown);
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.danhsach.ResumeLayout(false);
            this.danhsach.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.hen.ResumeLayout(false);
            this.hen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panMenu.ResumeLayout(false);
            this.panHanhchanh.ResumeLayout(false);
            this.panHanhchanh.PerformLayout();
            this.p.ResumeLayout(false);
            this.p.PerformLayout();
            this.pgoi.ResumeLayout(false);
            this.pgoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ena_yta(bool ena)
		{
			c_lydo.Enabled=ena;c_hb_banthan.Enabled=ena;c_hb_benhly.Enabled=ena;c_hb_giadinh.Enabled=ena;
			c_kb_bophan.Enabled=ena;c_kb_chuy.Enabled=ena;c_kb_toanthan.Enabled=ena;c_kb_tomtat.Enabled=ena;
			c_kb_xuli.Enabled=ena;c_lydo.Enabled=ena;cd_chinh.Enabled=ena;icd_chinh.Enabled=ena;
            c_kb_tai.Enabled = ena; c_kb_mui.Enabled = ena; c_kb_hong.Enabled = ena;
			mabs.Enabled=ena;tenbs.Enabled=ena;tenbs_pass.Enabled=ena;xutri.Enabled=ena;maxutri.Enabled=ena;
			bienchung.Enabled=ena;giaiphau.Enabled=ena;taibien.Enabled=ena;cmbTaibien.Enabled=ena;
			butkemtheo.Enabled=ena;butphauthuat.Enabled=ena;butchidinh.Enabled=ena;but_thuocbhyt.Enabled=ena;but_thuocdan.Enabled=ena;
			buttutruc.Enabled=ena;
		}

		private void ena_bacsi(bool ena)
		{
			hoten.Enabled=ena;ngaysinh.Enabled=ena;namsinh.Enabled=ena;tuoi.Enabled=ena;loaituoi.Enabled=ena;mann.Enabled=ena;tennn.Enabled=ena;
			phai.Enabled=ena;madantoc.Enabled=ena;tendantoc.Enabled=ena;sonha.Enabled=ena;thon.Enabled=ena;tqx.Enabled=ena;tentqx.Enabled=ena;
			matt.Enabled=ena;tentinh.Enabled=ena;maqu2.Enabled=ena;tenquan.Enabled=ena;mapxa2.Enabled=ena;tenpxa.Enabled=ena;
			cholam.Enabled=ena;ngayvv.Enabled=ena;dentu.Enabled=ena;tendentu.Enabled=ena;nhantu.Enabled=ena;tennhantu.Enabled=ena;
			noidk.Enabled=ena;tennoidk.Enabled=ena;sovaovien.Enabled=ena;madoituong.Enabled=ena;tendoituong.Enabled=ena;
			tungay.Enabled=ena;denngay.Enabled=ena;madstt.Enabled=ena;tendstt.Enabled=ena;bnmoi.Enabled=ena;loai.Enabled=ena;
			quanhe.Enabled=ena;qh_diachi.Enabled=ena;qh_hoten.Enabled=ena;qh_dienthoai.Enabled=ena;
			cd_noichuyenden.Enabled=ena;icd_noichuyenden.Enabled=ena;makp.Enabled=ena;tenkp.Enabled=ena;
		}

		private void load_diungthuoc()
		{
			lbl.Text="";
            foreach (DataRow r in m.get_data("select distinct b.ten from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b where a.mahc=b.ma and a.mabn='" + mabn2.Text + mabn3.Text + "'").Tables[0].Rows) lbl.Text += r["ten"].ToString().Trim() + ";";
            butdiungthuoc.ForeColor = lbl.Text == "" ? Color.Black : Color.Red;
            //diungthuoc.Checked=lbl.Text!="";
            //if (diungthuoc.Checked) 
            lbl.Text="DỊ ỨNG THUỐC :"+lbl.Text;
            //butdiungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):System.Drawing.SystemColors.Desktop;
		}

		private void load_phauthuat()
		{
			if (l_maql==0) return;
            bool b_pttt = m.get_data("select * from " + user + mmyy + ".pttt where maql=" + l_maql).Tables[0].Rows.Count != 0;
            butphauthuat.ForeColor = (b_pttt) ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
		}

		private void load_tainantt()
		{
			if (l_maql==0) return;
            bool b_tntt = m.get_data("select * from " + xxx + ".tainantt where maql=" + l_maql).Tables[0].Rows.Count != 0;
            buttainantt.ForeColor = b_tntt ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
		}

		private void load_thuocdan()
		{
			if (l_maql==0 || !m.bMmyy(mmyy)) return;
			if (bDanhmuc_nhathuoc) sql="select * from "+user+mmyy+".d_thuocbhytll where madoituong<>1 and nhom="+m.nhom_nhathuoc+" and maql="+l_maql;
            else sql = "select * from " + user + mmyy + ".d_toathuocll where maql=" + l_maql;
			bool b_thuoc=m.get_data(sql).Tables[0].Rows.Count!=0;
            but_thuocdan.ForeColor = b_thuoc ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
		}

		private void load_chidinh()
		{
			if (l_maql==0 || !m.bMmyy(mmyy)) return;
			sql="select * from "+m.user+mmyy+".v_chidinh ";
			sql+=" where mabn='"+s_mabn+"'";
			if (iChidinh==2) sql+=" and maql="+l_maql;
			else if (ngayvv.Text.Trim()!="" && makp.Text!="") sql+=" and to_char(ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"' and makp='"+makp.Text+"'";
			bool b_chidinh=m.get_data(sql).Tables[0].Rows.Count!=0;
            butchidinh.ForeColor = (b_chidinh) ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
			if (bTamung) 
			{
				sodu=m.get_chiphikb(ngayvv.Text,l_mavaovien);
				lchiphi.Text="Số dư : "+sodu.ToString("###,###,###,###");
			}
		}

		private void load_baohiem()
		{
			if (l_maql==0 || !m.bMmyy(mmyy)) return;
			bool b_thuoc=m.get_data("select * from "+user+mmyy+".d_thuocbhytll where nhom="+m.nhom_duoc+" and maql="+l_maql).Tables[0].Rows.Count!=0;
            but_thuocbhyt.ForeColor = (b_thuoc) ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
		}

		private void load_dm()
		{
			list1.DisplayMember="MABV";
			list1.ValueMember="TENBV";
            list1.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + m.user + ".dmnoicapbhyt order by mabv").Tables[0];

			listdstt.DisplayMember="MABV";
			listdstt.ValueMember="TENBV";
            listdstt.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + m.user + ".dstt where mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];

            try { dticd = m.get_data("select cicd10,vviet,benhmantinh,tiensubenh from " + m.user + ".icd10 order by cicd10").Tables[0]; }
            catch
            {
                m.execute_data("alter table " + user + ".icd10 add benhmantinh numeric(1) default 0");
                m.execute_data("alter table " + user + ".icd10 add tiensubenh numeric(1) default 0");
                dticd = m.get_data("select cicd10,vviet,benhmantinh,tiensubenh from " + m.user + ".icd10 order by cicd10").Tables[0];
            }
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			tenkhoa.DisplayMember="TENKP";
			tenkhoa.ValueMember="MAKP";
            sql = "select * from " + m.user + ".btdkp_bv where makp<>'01' ";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
            if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
            sql += "order by makp";
            dtkpfull = m.get_data(sql).Tables[0];
            tenkhoa.DataSource = dtkpfull;

            sql = "select * from " + m.user + ".btdkp_bv where makp<>'01' and loai=1";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
                if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                sql += " and makp in ('" + s + "')";
			}
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
            if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
			if (makp_khamnoi!="") sql+=" and makp<>'"+makp_khamnoi+"'";
			sql+=" order by makp";
			dtkp=m.get_data(sql).Tables[0];
            tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=dtkp;
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;
            //if (dtkp.Rows.Count==1)
            //    if (dtkp.Rows[0]["makpbo"].ToString()=="24") buttmh.Text="RHM";
			
			makp_capid=(s_makp.Length==3)?s_makp.Substring(0,2):"";
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);
			
			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + m.user + ".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
            tentinh.DataSource = m.get_data("select * from " + m.user + ".btdtt order by tentt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
            tennuoc.DataSource = m.get_data("select * from " + m.user + ".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

			tendentu.DisplayMember="TEN";
			tendentu.ValueMember="MA";
            tendentu.DataSource = m.get_data("select * from " + m.user + ".dentu order by ma").Tables[0];
			tendentu.SelectedIndex=-1;

			tennhantu.DisplayMember="TEN";
			tennhantu.ValueMember="MA";
            tennhantu.DataSource = m.get_data("select * from " + m.user + ".nhantu order by ma").Tables[0];
			tennhantu.SelectedIndex=-1;

            sql = "select * from " + m.user + ".doituong";
            if (s_madoituong.Length >= 2) s_madoituong = s_madoituong.Substring(0, s_madoituong.Length - 1);
            if (s_madoituong != "") sql += " where madoituong in (" + s_madoituong + ")";
			sql+=" order by madoituong";
            dtdt = m.get_data(sql).Tables[0];
			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			tendoituong.DataSource=dtdt;
			if (tendoituong.SelectedIndex!=-1) madoituong.Text=tendoituong.SelectedValue.ToString();

            dtxutri = m.get_data("select ma,to_char(ma,'00')||'   '||ten ten from " + m.user + ".xutrikb  where hide=0 order by ma").Tables[0];
            xutri.DataSource = dtxutri;
            xutri.DisplayMember="TEN";
			xutri.ValueMember="MA";

			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";

			tenloaibv.DisplayMember="TEN";
			tenloaibv.ValueMember="MA";
            tenloaibv.DataSource = m.get_data("select * from " + m.user + ".loaibv order by ma").Tables[0];
			tenloaibv.SelectedIndex=-1;

			tenbv.DisplayMember="TENBV";
			tenbv.ValueMember="MABV";	

			gphaubenh.DisplayMember="TEN";
			gphaubenh.ValueMember="MA";
            gphaubenh.DataSource = m.get_data("select * from " + m.user + ".gphaubenh").Tables[0];

			cmbTaibien.DisplayMember="TEN";
			cmbTaibien.ValueMember="MA";
            cmbTaibien.DataSource = m.get_data("select * from " + m.user + ".taibien").Tables[0];

			danhsach.Visible=bHiends;
            if (bHiends)
            {
                list.DisplayMember = "HOTEN";
                list.ValueMember = "STT";
                list.ColumnWidths[0] = 30;
                list.ColumnWidths[1] = 70;
                list.ColumnWidths[2] = 140;
                list.ColumnWidths[3] = 150;
                list.ColumnWidths[4] = 50;
                list.ColumnWidths[5] = list.Width - 440;
                load_ref();

                list.SetSensive(3, "Chờ KQ CLS", Color.Red);
                list.SetSensive1(3, "Đã có KQ CLS", Color.Blue);
                
                if (list.Items.Count == 0) danhsach.Visible = true;
                else
                {
                    list.Focus();
                    this.danhsach.Location = new Point(label2.Location.X, label2.Location.Y);
                    this.danhsach.Size = new Size(c_hb_benhly.Right + treeView1.Right, butTiep.Top);//1008//419
                }
            }
		}

		private void load_mabv(string maloai)
		{
			if (maloai=="3")
				tenbv.DataSource=m.get_data("select * from "+user+".tenvien where substr(maloai,1,1)='2' and mabv like '"+mabv.Text+"%'"+" and mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];
			else
				tenbv.DataSource=m.get_data("select * from "+user+".tenvien where mabv like '"+mabv.Text+"%'"+" and mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];
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
            tenquan.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
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
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				if (makp.Text!="" && l_maql==0)
				{
					if (!load_phongkham() && !bSuadoituong) 
					{
						madoituong.Enabled=false;
						tendoituong.Enabled=false;
						sothe.Enabled=false;
						denngay.Enabled=false;
						tungay.Enabled=false;
						noidk.Enabled=false;
						tennoidk.Enabled=false;
					}
				}
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
				int ituoi=DateTime.Now.Year-int.Parse(namsinh.Text);
				if (ituoi>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{F4}");
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
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
				s_mabn=mabn2.Text+mabn3.Text;
				DataTable dt=m.get_Timmabn(hoten.Text,ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2,i_maxlenght_mabn-2);
						s_mabn=mabn2.Text+mabn3.Text;
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
				tenkp.SelectedValue=makp.Text;
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
			mabn2.Text=mabn2.Text.PadLeft(2,'0');		
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			lblhd.Text="";
			//if (bHiends) danhsach.Visible=false;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			load_btdnn(0);
			bNew=true;nam = "";
			bCapso=false;
			if (mabn3.Text=="" && makp_capid!="")
			{
				if (mabn2.Text=="")
				{
					mabn2.Focus();
					return;
				}
				if (m.get_capso(makp_capid)) 
				{
					bCapso=true;
					mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),2,int.Parse(makp_capid),true).ToString().PadLeft(i_maxlenght_mabn-2,'0');
				}
				else return;
			} else if (mabn3.Text=="") return;
            //linh
            if (mabn3.Text.Trim() != "" && mabn3.MaxLength==8 && mabn3.Text.Trim().Length>2)
            {
                string _mabntmp1 = mabn3.Text.Substring(0, 2);
                string _mabntmp2 = mabn3.Text.Substring(2).PadLeft(6, '0');
                mabn3.Text = _mabntmp1 + _mabntmp2;
            }
            //end linh
			mabn3.Text=mabn3.Text.PadLeft(i_maxlenght_mabn-2,'0');
			s_mabn=mabn2.Text+mabn3.Text;
            //linha -> doi xuong
			//buttiensu.ForeColor=(m.get_data("select * from "+user+".theodoitsu where mabn='"+s_mabn+"'").Tables[0].Rows.Count>0)?Color.Red:System.Drawing.SystemColors.Desktop;
            //end linh
			emp_text(true);
			if (load_mabn())
			{
				if (bPhongkham_chidinh && tenkp.Items.Count == 1 && makp.Text != "" && ngayvv.Text!="")
				{
					if (m.bMmyy(m.mmyy(ngayvv.Text)))
					{
						sql="select * from "+user+mmyy+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
						sql+=" and noitiepdon in (0,1,5,16) and makp='"+makp.Text+"'";
						if (m.get_data(sql).Tables[0].Rows.Count==0)
						{
							MessageBox.Show(lan.Change_language_MessageText("Người bệnh "+hoten.Text.Trim()+" chưa được chỉ định vào ")+tenkp.Text,LibMedi.AccessData.Msg);
							butBoqua_Click(sender,e);
                            //linh
                            this.danhsach.Location = new Point(0, panHanhchanh.Top);
                            this.danhsach.Size = new Size(148, panMenu.Top);
                            //end linh
							return;
						}
					}
				}
				if (load_vv_mabn())
				{
					if (!m.bAdmin_hethong(i_userid) && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);//if (!bAdmin && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);
				}
				else load_tiepdon(m.Ngayhienhanh,false);
                //linh
                DataSet ds_ld = m.get_data("select id_lydokham from " + xxx + ".lydokham where maql=" + l_maql + "");
                string s_lydokham = "", s_tenlydo = "";
                if (ds_ld.Tables[0].Rows.Count > 0) s_lydokham = ds_ld.Tables[0].Rows[0][0].ToString();
                foreach (string st in s_lydokham.Split('+'))
                {
                    foreach (DataRow r in ds_lydo.Tables[0].Rows)
                    {
                        if (st.Trim() == r["id"].ToString().Trim())
                        {
                            s_tenlydo = r["ten"].ToString();
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân") + " " + s_tenlydo);
                            break;
                        }
                    }
                }
                //linh
                //Lấy dấu sinh tồn
                //if (m.bDausinhton_khambenh)
                //{
                decimal l_maql_pk = 0;
                if (butLuu.Tag != null)
                {
                    l_maql_pk = decimal.Parse(butLuu.Tag.ToString());
                }
                if (l_maql_pk == 0)
                {
                    l_maql_pk = l_maql;
                }
                if (l_maql_pk != 0)
                {
                    if (m.get_data("select mabn from " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".d_dausinhton where maql=" + l_maql_pk.ToString() + " and makp='" + s_makp + "'").Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đề nghị lấy dấu sinh tồn của bệnh nhân") + "!", LibMedi.AccessData.Msg);
                        butdausinhton_Click(null, null);
                    }
                    load_dausinhton();
                }
                //}
                //if (!bSuadoituong) 
                //{
					madoituong.Enabled=false;
					tendoituong.Enabled=false;
					sothe.Enabled=false;
					denngay.Enabled=false;
					tungay.Enabled=false;
					noidk.Enabled=false;
					tennoidk.Enabled=false;
				//}
                buttiensu.ForeColor = c_hb_banthan.Text.Trim() != "" ? Color.Red : Color.Black;
                //end linh
                s_icd_noichuyenden = icd_noichuyenden.Text;
				s_icd_chinh=icd_chinh.Text;
				ngayvv.Focus();
				SendKeys.Send("{Home}");
			} 
			else treeView1.Visible=true;
            //linh
            this.danhsach.Location = new Point(0, panHanhchanh.Top);
            this.danhsach.Size = new Size(148, panMenu.Top);
            //end lunh
		}
       
		private bool load_mabn()
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
            {
                nam = r["nam"].ToString().Trim();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                if (r["ngaysinh"].ToString() != "")
                {
                    ngaysinh.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaysinh"].ToString()));
                    string tuoivao = m.Tuoivao("", ngaysinh.Text);
                    tuoi.Text = tuoivao.Substring(2).PadLeft(3, '0');
                    loaituoi.SelectedIndex = int.Parse(tuoivao.Substring(0, 1));
                }
                else
                {
                    tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                    loaituoi.SelectedIndex = 0;
                }
                phai.SelectedIndex = int.Parse(r["phai"].ToString());
                tennn.SelectedValue = r["mann"].ToString();
                tendantoc.SelectedValue = r["madantoc"].ToString();
                sonha.Text = r["sonha"].ToString();
                thon.Text = r["thon"].ToString();
                cholam.Text = r["cholam"].ToString();
                tentinh.SelectedValue = r["matt"].ToString();
                load_quan();
                tenquan.SelectedValue = r["maqu"].ToString();
                load_pxa();
                tenpxa.SelectedValue = r["maphuongxa"].ToString();
                if (bHinh)
                {
                    //linh
                    bool error = true;
                    try
                    {
                        if (pathImage != "")
                        {
                            pathImage = pathImage.Replace("\\", "//");
                            pathImage = pathImage.Trim('/');
                            string pathpic = pathImage + "//" + s_mabn + "." + FileType;
                            if (System.IO.File.Exists(pathpic))
                            {
                                error = false;
                                pic.Tag = pathpic;
                            }
                            else
                            {
                                error = true;
                            }
                        }
                        else
                        {
                            error = true;
                            //image = new byte[0];
                            //image = (byte[])(r["image"]);
                            //memo = new MemoryStream(image);
                            //map = new Bitmap(Image.FromStream(memo));
                            //pic.Image = (Bitmap)map;
                            //pic.Tag = image;
                        }
                    }
                    catch
                    {
                        error = true;
                        pic.Tag = "0000.bmp";
                    }
                    if (error)
                    {
                        //linh
                        //fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = pic.InitialImage;// (Bitmap)map;
                        //end linh
                    }
                    else
                    {
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = (Bitmap)map;
                    }
                    //end linh
                }
                ret = true;
                break;
            }
			if (ret)
			{
                sql = "select c.loaiba,b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".hiendien a," + user + ".btdkp_bv b," + user + ".benhandt c where a.maql=c.maql and a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and c.loaiba in (1,2)";
				sql+=" and a.mabn='"+s_mabn+"'";
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    lblhd.Text = lan.Change_language_MessageText("ĐANG ĐIỀU TRỊ") + " " + ((r["loaiba"].ToString() == "1") ? 
                        lan.Change_language_MessageText("NỘI TRÚ") : lan.Change_language_MessageText("NGOẠI TRÚ")) + " " + 
                        lan.Change_language_MessageText("TẠI") + " " + r["tenkp"].ToString().Trim().ToUpper() + " " + 
                        lan.Change_language_MessageText("NGÀY") + " " + r["ngay"].ToString();
			}
            if (ret && manuoc.Enabled) tennuoc.SelectedValue = m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows[0][0].ToString();
			if (bSoluutru && nam!="") soluutru.Text=m.get_soluutru(nam,s_mabn);
            //linh
            load_tiensu();
            //end linh
			load_diungthuoc();
			load_treeView();
			return ret;
		}

		private void load_tiepdon(string m_ngay,bool skip)
		{
            l_matd = 0; l_mavaovien = 0; s_ngaydk = "";
			mmyy=m.mmyy(m_ngay);
			if (!m.bMmyy(mmyy)) return;
			xxx=user+mmyy;
			sql="select * from "+xxx+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
			sql+=" and noitiepdon in (0,1,5,16)";
            sql += " and (done is null or done in ('?','d') ";
            if (!m.bThuphi_kham)
                sql += "or done='c' ";
            sql += ") ";
			if (s_makp!="" && bPhongkham_chidinh )
			{
				string s=s_makp.Replace(",","','");
                if(s.Length>3)s=s.Substring(0,s.Length-3);
				sql+=" and makp in ('"+s+"')";
			}
			sql+=" order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                s_ngaydk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
				if (skip)
				{
					ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					s_ngayvv=ngayvv.Text;
				}
				i_madoituong=int.Parse(r["madoituong"].ToString());
				madoituong.Text=r["madoituong"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
				l_maql=decimal.Parse(r["maql"].ToString());
				l_mavaovien=decimal.Parse(r["mavaovien"].ToString());
				l_matd=l_mavaovien;
				if (bTamung)
				{
					sodu=m.get_chiphikb(ngayvv.Text,l_mavaovien);
					lchiphi.Text="Số dư : "+sodu.ToString("###,###,###,###");
				}
				if (!bSuadoituong) 
				{
					madoituong.Enabled=false;
					tendoituong.Enabled=false;
					sothe.Enabled=false;
					denngay.Enabled=false;
					tungay.Enabled=false;
					noidk.Enabled=false;
					tennoidk.Enabled=false;
				}
				break;
			}
			if (l_maql!=0)
			{
				emp_bhyt();
				foreach(DataRow r in m.get_data("select * from "+xxx+".noigioithieu where maql="+l_maql).Tables[0].Rows)
				{
					madstt.Text=r["mabv"].ToString();
					tendstt.Text=m.get_data("select tenbv from "+user+".dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
					dentu.Text="1";
					tendentu.SelectedIndex=0;
					break;
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
				{
					quanhe.Text=r["quanhe"].ToString();
					qh_hoten.Text=r["hoten"].ToString();
					qh_diachi.Text=r["diachi"].ToString();
					qh_dienthoai.Text=r["dienthoai"].ToString();
				}
				if (quanhe.Text=="")
				{
					foreach(DataRow r in m.get_data("select * from "+user+".dienthoai where mabn="+mabn2.Text+mabn3.Text).Tables[0].Rows)
					{
						qh_diachi.Text=r["coquan"].ToString().Trim()+((r["coquan"].ToString().Trim()!="")?"-":"")+((r["didong"].ToString().Trim()!="")?"Mobile : ":"")+r["didong"].ToString().Trim();
						qh_dienthoai.Text=r["nha"].ToString();
						break;
					}
				}
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".bhyt where maql="+l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						if (r["tungay"].ToString()!="")
							tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
						if (so.Substring(3,1)=="1")
						{
							noidk.Text=r["mabv"].ToString();
							try
							{
								tennoidk.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+noidk.Text+"'").Tables[0].Rows[0][0].ToString();
							}
							catch{}
						}
						traituyen=int.Parse(r["traituyen"].ToString());
                        i_traituyen = traituyen;
                        cbotuyen.SelectedIndex = i_traituyen;
					}
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
					if (bBacsy)
					{
						mabs.Text=r["mabs"].ToString();
						DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r1!=null) tenbs.Text=r1["hoten"].ToString();
						else tenbs.Text="";
					}
					bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
					loai.SelectedIndex=int.Parse(r["loai"].ToString());
                    s_soluutru = r["soluutru"].ToString();//TU:28/06/2011
				}
                //linh
                //foreach(DataRow r in m.get_data("select * from "+xxx+".dausinhton where maql="+l_maql).Tables[0].Rows)
                //{
                //    mach.Text=r["mach"].ToString();
                //    nhietdo.Text=r["nhietdo"].ToString();
                //    huyetap.Text=r["huyetap"].ToString();
                //    break;
                //}
                //foreach (DataRow r in m.get_data("select * from " + xxx + ".d_dausinhton where mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
                //{
                //    mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                //    nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                //    huyetap.Text = r["huyetap"].ToString();
                //    nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                //    cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                //    chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                //    tinh_bmi();
                //    break;
                //}
                //edn
				if (khamthai.Visible)
				{
					int bFound=0;
					foreach(DataRow r in m.get_data("select * from "+xxx+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
					{
						para1.Text=r["para"].ToString().Substring(0,2);
						para2.Text=r["para"].ToString().Substring(2,2);
						para3.Text=r["para"].ToString().Substring(4,2);
						para4.Text=r["para"].ToString().Substring(6,2);
						if (r["kinhcc"].ToString()!="") kinhcc.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["kinhcc"].ToString()));
						if (r["ngaysanh"].ToString()!="") ngaysanh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysanh"].ToString()));
						bFound=(r["para"].ToString()=="00000000")?0:1;
						break;
					}
					if (bFound==0)
					{
						sql="select * from xxx.ttkhamthai where mabn='"+s_mabn+"'";
						if (bFound==1) sql+=" and maql<>"+l_maql;
						sql+=" order by maql desc";
						foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
						{
							para1.Text=r["para"].ToString().Substring(0,2);
							para2.Text=r["para"].ToString().Substring(2,2);
							para3.Text=r["para"].ToString().Substring(4,2);
							para4.Text=r["para"].ToString().Substring(6,2);
							if (r["kinhcc"].ToString()!="") kinhcc.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["kinhcc"].ToString()));
							if (r["ngaysanh"].ToString()!="") ngaysanh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysanh"].ToString()));
							break;
						}
					}
				}
			}
			else if (khamthai.Visible)
			{
				sql="select * from xxx.ttkhamthai where mabn='"+s_mabn+"'";
				sql+=" order by maql desc";
				foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
				{
					para1.Text=r["para"].ToString().Substring(0,2);
					para2.Text=r["para"].ToString().Substring(2,2);
					para3.Text=r["para"].ToString().Substring(4,2);
					para4.Text=r["para"].ToString().Substring(6,2);
					if (r["kinhcc"].ToString()!="") kinhcc.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["kinhcc"].ToString()));
					if (r["ngaysanh"].ToString()!="") ngaysanh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysanh"].ToString()));
					break;
				}
			}
			if (!bSuadoituong && l_matd==0)
			{
				madoituong.Enabled=true;
				tendoituong.Enabled=true;
			}
			treeView1.Visible=true;
		}

		private void load_vv_maql(bool skip)
		{
			if (ngayvv.Text == "") return;
			mmyy=m.mmyy(ngayvv.Text);
			//foreach(DataRow r in m.get_data("select * from "+user+mmyy+".benhandt where mangtr=0 and loaiba=3 and maql="+l_maql).Tables[0].Rows)
            foreach (DataRow r in m.get_data("select * from " + user + mmyy + ".benhanpk where mangtr=0 and maql=" + l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					s_ngayvv=ngayvv.Text;
				}
				l_mavaovien=decimal.Parse(r["mavaovien"].ToString());
                tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				if (!m.bAdmin_hethong(i_userid) && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);//if (!bAdmin && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
			l_maql=0;l_mavaovien=0;
			emp_vv();
			emp_rv();
			if (nam == "") return false;
			sql="select * from "+user+nam.Substring(nam.Length-5,4)+".benhanpk where mangtr=0 ";
			sql+=" and mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m.ngayhienhanh_server.Substring(0,10)+"'";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
                if (s.Length > 3) s = s.Substring(0, s.Length - 3);
				sql+=" and makp in ('"+s+"')";
			}
			sql+=" and chandoan is null order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
				l_mavaovien=decimal.Parse(r["mavaovien"].ToString());
				ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				s_ngayvv=ngayvv.Text;
				tenkp.SelectedValue=r["makp"].ToString();
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
                
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			c_lydo.Text="";c_hb_banthan.Text="";c_hb_benhly.Text="";
			c_hb_giadinh.Text="";c_kb_bophan.Text="";c_kb_chuy.Text="";sobo.Text="";phanbiet.Text="";
			c_kb_toanthan.Text="";c_kb_tomtat.Text="";c_kb_xuli.Text="";
            c_kb_tai.Text = ""; c_kb_mui.Text = ""; c_kb_hong.Text = "";
            mach.Text = ""; nhietdo.Text = ""; nhiptho.Text = ""; huyetap.Text = ""; cannang.Text = ""; chieucao.Text = "";
			emp_bhyt();
			xxx=user+m.mmyy(ngayvv.Text);
			foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
				break;
			}
			foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
			{
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) 
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tenbs.Text="";tenbs_pass.Text="";
				}
				break;
			}
			string stuoi=m.get_tuoivao(ngayvv.Text,l_maql).Trim();
			if (stuoi.Length==4)
			{
				tuoi.Text=stuoi.Substring(0,3);
				loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
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
						if (r["tungay"].ToString()!="")
							tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
						if (so.Substring(3,1)=="1")
						{
							noidk.Text=r["mabv"].ToString();
							try
							{
								tennoidk.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+noidk.Text+"'").Tables[0].Rows[0][0].ToString();
							}
							catch{}
						}
						traituyen=int.Parse(r["traituyen"].ToString());
                        i_traituyen = traituyen;
                        cbotuyen.SelectedIndex = traituyen;
					}
				}
			}
            if (tendoituong.SelectedValue.ToString() != "1") cbotuyen.SelectedIndex = -1;
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
						break;
					}
				}
			}
			if (dentu.Text=="1")
			{
				try
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".noigioithieu where maql="+l_maql).Tables[0].Rows)
					{
						cd_noichuyenden.Text=r["chandoan"].ToString();
						icd_noichuyenden.Text=r["maicd"].ToString();
						madstt.Text=r["mabv"].ToString();
						tendstt.Text=m.get_data("select tenbv from "+user+".dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
					}
				}
				catch{}
			}
			
			foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_chung where maql="+l_maql).Tables[0].Rows)
			{
                //linh
                string s_tiensu = "";
                s_tiensu = load_tiensu();
                //try { s_tiensu = m.get_data("select noidung from " + user + ".theodoitsu where mabn='" + s_mabn + "'").Tables[0].Rows[0]["noidung"].ToString(); }
                //catch { }
                //end linh
				c_lydo.Text=r["lydo"].ToString();
				c_hb_benhly.Text=r["hb_benhly"].ToString();
                c_hb_banthan.Text = r["hb_banthan"].ToString().Trim() == "" ? s_tiensu : r["hb_banthan"].ToString() + ";" + s_tiensu;
				c_hb_giadinh.Text=r["hb_giadinh"].ToString();
				c_kb_toanthan.Text=r["kb_toanthan"].ToString();
				c_kb_bophan.Text=r["kb_bophan"].ToString();
				c_kb_tomtat.Text=r["kb_tomtat"].ToString();
				c_kb_xuli.Text=r["kb_xuli"].ToString();
				c_kb_chuy.Text=r["kb_chuy"].ToString();
				sobo.Text=r["sobo"].ToString();
                phanbiet.Text = r["phanbiet"].ToString();
                if (r["phanbiet"].ToString() != "")
                {
                    string kemtheo = m.get_data("select cicd10 from " + user + ".icd10 where vviet='" + r["phanbiet"].ToString().Trim() + "'").Tables[0].Rows[0][0].ToString();
                    icd_kemtheo.Text = kemtheo;
                }
				break;
			}
			foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_dausinhton where maql="+l_maql).Tables[0].Rows)
			{
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
                chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                tinh_bmi();
				break;
			}
            foreach (DataRow r in m.get_data("select * from " + xxx + ".d_dausinhton where mabn='" + s_mabn+"' order by ngay desc").Tables[0].Rows)
            {
                mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                huyetap.Text = r["huyetap"].ToString();
                nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                tinh_bmi();
                break;
            }
            foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_tmh where maql=" + l_maql).Tables[0].Rows)
            {
                c_kb_tai.Text = r["tai"].ToString();
                if (c_kb_tai.Text.Trim() != m.get_nor(-3).Trim())
                { label69.Visible = true; label56.Visible = false; }
                c_kb_mui.Text = r["mui"].ToString();
                if (c_kb_mui.Text.Trim() != m.get_nor(-4).Trim())
                { label73.Visible = true; label70.Visible = false; }
                c_kb_hong.Text = r["hong"].ToString();
                if (c_kb_hong.Text.Trim() != m.get_nor(-5).Trim())
                { label75.Visible = true; label74.Visible = false; }
                break;
            }
			treeView1.Visible=true;
			load_phauthuat();
			load_tainantt();
			load_chidinh();
			load_thuocdan();
			load_baohiem();
			load_kemtheo();
			load_rk();
		}

		private void load_rk()
		{
			DataRow r1;
			string s_xutri="";
			xxx=user+m.mmyy(ngayvv.Text);
			//foreach(DataRow r in m.get_data("select * from "+user+".xuatvien where maql="+l_maql).Tables[0].Rows)
            foreach (DataRow r in m.get_data("select * from " + xxx + ".benhanpk where maql=" + l_maql).Tables[0].Rows)
			{
				cd_chinh.Text=r["chandoan"].ToString();
				icd_chinh.Text=r["maicd"].ToString();
				mabs.Text=r["mabs"].ToString();
				r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) 
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tenbs.Text="";tenbs_pass.Text="";
				}
				s_xutri=m.get_xutri(ngayvv.Text,l_maql,0).ToString().Trim().PadLeft(2,'0');
				if (s_xutri=="") s_xutri=r["ttlucrv"].ToString().Trim().PadLeft(2,'0')+",";
				else 
				{
					if (s_xutri.IndexOf("03,")!=-1 && bTaikham_hen) 
					{
						hen.Visible=true;
						foreach(DataRow r2 in m.get_data("select * from "+xxx+".hen where maql="+l_maql).Tables[0].Rows)
						{
							hen_ngay.Value=decimal.Parse(r2["songay"].ToString());
							hen_ghichu.Text=r2["ghichu"].ToString();
							hen_loai.SelectedIndex=int.Parse(r2["loai"].ToString());
							chkTiepdon.Checked=r2["tiepdon"].ToString()=="1";
							break;
						}
					}
					if (s_xutri.IndexOf("05,")!=-1 || s_xutri.IndexOf("02,")!=-1 || s_xutri.IndexOf("08,")!=-1)
				    {
                        sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                        if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                        if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
						if (s_xutri.IndexOf("08,")!=-1) sql+=" and loai=1";
						else if (s_xutri.IndexOf("05,")!=-1) sql+=" and loai=0";
						else if (s_chonxutri.IndexOf("02,")!=-1) sql+=" and (maba like '%20%' or maba like '%21%' or maba like '%22%' or maba like '%23%')";
						sql+=" order by makp";
						tenkhoa.DataSource=m.get_data(sql).Tables[0];
						khoa.Text=m.get_xutri(ngayvv.Text,l_maql,1).ToString();
						tenkhoa.SelectedValue=khoa.Text;
						khoa.Enabled=true;
						tenkhoa.Enabled=true;
						this.lblKhoaphong.Text = (s_xutri.IndexOf("08,")!=-1)?"6. Chuyển vào phòng khám :":"6. Cho vào điều trị tại khoa :";
				    }
				}
				maxutri.Text=s_xutri;
				//soluutru.Text=r["soluutru"].ToString();
				bienchung.Checked=int.Parse(r["bienchung"].ToString())==1;
				taibien.Checked=int.Parse(r["taibien"].ToString())!=0;
				if (taibien.Checked) cmbTaibien.SelectedValue=int.Parse(r["taibien"].ToString());
				giaiphau.Checked=int.Parse(r["giaiphau"].ToString())!=0;
				if (giaiphau.Checked) gphaubenh.SelectedValue=int.Parse(r["giaiphau"].ToString());
				break;
			}
			
			if (s_xutri!="")
			{
				for(int i=0;i<=xutri.Items.Count;i++)
					if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2,'0')+",")!=-1) xutri.SetItemCheckState(i-1,CheckState.Checked);
			}
            mabv.Text = "";
            txtTenbv.Text = "";
            if (loaibv.Enabled && s_xutri == "06,")
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
				{
                    //linh
					tenloaibv.SelectedValue=r["loaibv"].ToString();
                    mabv.Text = (r["mabv"].ToString() == "") ? "" : r["mabv"].ToString();
                    DataRow rbv = m.getrowbyid(dtdmbenhvien, "mabv='" + mabv.Text + "'");
                    if (rbv != null)
                    {
                        txtTenbv.Text = rbv["tenbv"].ToString();
                    }
					//load_mabv(loaibv.Text);
					//tenbv.SelectedValue=mabv.Text;
					s_mabv=mabv.Text;
                    //end linh
				}
			}
			s_icd_noichuyenden=icd_noichuyenden.Text;
			s_icd_chinh=icd_chinh.Text;
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
			}
			catch{}
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
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
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
			cholam.Text=m.Caps(cholam.Text);		
		}

		private void caller()
		{
			try
			{
				int stt=0;
				DataRow r1=m.getrowbyid(dtlist,"stt="+decimal.Parse(list.SelectedValue.ToString()));
				if (r1!=null) stt=int.Parse(r1["sovaovien"].ToString());
				if (stt!=0)
				{
					s_mabn=r1["mabn"].ToString();
					string ngaysrv=m.ngayhienhanh_server,zzz=user+m.mmyy(ngaysrv);
					sql="update "+zzz+".tiepdon set kham=1 where noitiepdon in (0,1,5,16) and mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+ngaysrv.Substring(0,10)+"'";
					string s="";
					if (s_makp!="" )
					{
						s=s_makp.Replace(",","','");
                        if (s.Length > 3) s = s.Substring(0, s.Length - 3);
						sql+=" and makp in ('"+s+"')";
					}
					m.execute_data(sql);
					sql="update btdkp_bv set remark=1";
                    if (s != "")
                    {
                        if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                        sql += " where makp in ('" + s + "')";
                    }
					m.execute_data(sql);
					call=new LibCaller.Caller();
					call.voice(stt.ToString(),_d1,_d2,_d3,_d4,(s_makp.Length==3)?s_makp.Substring(0,2):makp.Text,bChuctramngan,m.bKhambenh_bangdien);
				}
			}
			catch{}
		}

		private void frmKhambenh_tmh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
		{
			switch (e.KeyCode)
			{
				case Keys.F1:
                    if (bCaller && list.Items.Count>0) caller();
                    else if (bGoi || bPhongkham_bangdien_kontum) butgoibenh_Click(sender, e);
					break;
				case Keys.F3:
					but_thuocbhyt_Click(sender,e);
					break;
				case Keys.F5:
					but_thuocdan_Click(sender,e);
					break;
				case Keys.F6:
					butphauthuat_Click(sender,e);
					break;
				case Keys.F7:
					butchidinh_Click(sender,e);
					break;
				case Keys.F8:
					l_tonkho_Click(sender,e);
					break;
				case Keys.F9:
					buttainantt_Click(sender,e);
					break;
				case Keys.F10:
					buttutruc_Click(sender,e);
					break;
				case Keys.F11:
					butkemtheo_Click(sender,e);
					break;
				case Keys.F12:
					butcls_Click(sender,e);
					break;
			}
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.D:
						butdiungthuoc_Click(sender,e);
						break;
					case Keys.L:
						l_lichhen_Click(sender,e);
						break;
					case Keys.T:
						label32_Click(sender,e);
						break;
					case Keys.S:
						buttiensu_Click(sender,e);
						break;		
					case Keys.H:
						buttmh_Click(sender,e);
						break;		
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();d.close();//v.close();
			System.GC.Collect();
			this.Close();
		}

		private void dentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tendentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tendentu.SelectedIndex==-1) tendentu.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
                c_lydo.Focus();
			}
		}

		private void tendentu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				dentu.Text=tendentu.SelectedValue.ToString();
				if (m.bChandoan) cd_noichuyenden.Enabled=dentu.Text=="1";
				icd_noichuyenden.Enabled=dentu.Text=="1";
				madstt.Enabled=icd_noichuyenden.Enabled;
				tendstt.Enabled=madstt.Enabled;
			}
			catch{dentu.Text="";}
		}

		private void dentu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendentu.SelectedValue=dentu.Text;
			}
			catch{}
		}

		private void nhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void nhantu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennhantu.SelectedValue=nhantu.Text;
			}
			catch{}
		
		}

		private void tennhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennhantu.SelectedIndex==-1) tennhantu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennhantu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				nhantu.Text=tennhantu.SelectedValue.ToString();
			}
			catch{nhantu.Text="";}
		}

		private void madoituong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (madoituong.Text!="")
				{
					if (i_madoituong!=0 && int.Parse(madoituong.Text)!=i_madoituong)
						if (MessageBox.Show(lan.Change_language_MessageText("Khác đối tượng đăng ký \nBạn có muốn thay đổi đối tượng ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) madoituong.Text=i_madoituong.ToString();
					tendoituong.SelectedValue=madoituong.Text;
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
				if (i_madoituong!=0 && int.Parse(tendoituong.SelectedValue.ToString())!=i_madoituong)
					if (MessageBox.Show(lan.Change_language_MessageText("Khác đối tượng đăng ký \nBạn có muốn thay đổi đối tượng ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) tendoituong.SelectedValue=i_madoituong.ToString();
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (sothe.Text=="" && int.Parse(so.Substring(0,2))>0) load_bhyt();
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
				if (bTungay && denngay.Enabled) tungay.Enabled=denngay.Enabled;
				else tungay.Enabled=false;
				noidk.Enabled=so.Substring(3,1)=="1";
				tennoidk.Enabled=noidk.Enabled;
				SendKeys.Send("{Tab}");
			}
		}

		private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendoituong)
			{
				try
				{
					if (i_madoituong!=0 && int.Parse(tendoituong.SelectedValue.ToString())!=i_madoituong)
						if (MessageBox.Show(lan.Change_language_MessageText("Khác đối tượng đăng ký \nBạn có muốn thay đổi đối tượng ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) tendoituong.SelectedValue=i_madoituong.ToString();
					madoituong.Text=tendoituong.SelectedValue.ToString();
					string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
					if (sothe.Text=="" && int.Parse(so.Substring(0,2))>0) load_bhyt();
					sothe.Enabled=int.Parse(so.Substring(0,2))>0;
					denngay.Enabled=so.Substring(2,1)=="1";
					if (bTungay && denngay.Enabled) tungay.Enabled=denngay.Enabled;
					else tungay.Enabled=false;
					noidk.Enabled=so.Substring(3,1)=="1";
					tennoidk.Enabled=noidk.Enabled;
				}
				catch{tendoituong.SelectedIndex=0;}
			}
		}

		private void load_bhyt()
		{
			if (nam == "") return;
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0 && ngayvv.Text!="")
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
					sql="select * from xxx.bhyt where mabn='"+s_mabn+"'"+" and to_date(denngay,'dd/mm/yy')>=to_date('"+ngayvv.Text.Substring(0,10)+"','dd/mm/yy')"+" order by maql desc";
				else
					sql="select * from xxx.bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (r["tungay"].ToString()!="")
						tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
					if (so.Substring(3,1)=="1")
					{
						noidk.Text=r["mabv"].ToString();
						try
						{
							tennoidk.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+noidk.Text+"'").Tables[0].Rows[0][0].ToString();
						}
						catch{}
					}
					traituyen=int.Parse(r["traituyen"].ToString());
                    i_traituyen = traituyen;
					break;
				}
			}
			else
			{
				traituyen=0;
				sothe.Text="";
				denngay.Text="";
				tungay.Text="";
				noidk.Text="";
				tennoidk.Text="";
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

		private void loaibv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenloaibv.SelectedValue=loaibv.Text;
			}
			catch{}
		}

		private void loaibv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenloaibv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenloaibv.SelectedIndex==-1) tenloaibv.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void tenloaibv_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			try
			{
				loaibv.Text=tenloaibv.SelectedValue.ToString();
			}
			catch
			{
				loaibv.Text="";
				tenbv.SelectedIndex=-1;
			}
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (mabv.Text!="")
				{//linh
                    if (dtdmbenhvien == null)
                    {
                        dtdmbenhvien = m.get_data("select mabv,tenbv,mahang,ngoaidm,maloai from " + user + ".tenvien where mabv<>'" + s_mabv + "'").Tables[0];
                        listBenhvien.DisplayMember = "MABV";
                        listBenhvien.ValueMember = "TENBV";
                        listBenhvien.DataSource = dtdmbenhvien;
                    }
                    DataRow rbv = m.getrowbyid(dtdmbenhvien, "mabv='" + mabv.Text + "'");
                    if (rbv != null)
                    {
                        string s_maloaibv = rbv["maloai"].ToString().Substring(0, 1);
                        if (s_maloaibv == "2")
                        {
                            tenloaibv.SelectedIndex = 2;
                            loaibv.Text = tenloaibv.SelectedValue.ToString();
                        }
                        else
                        {
                            int i_hangbv = m.HangBenhVien(mabv.Text);
                            int i_hangbv_chuyen = int.Parse(rbv["mahang"].ToString());
                            if (i_hangbv < i_hangbv_chuyen)
                            {
                                tenloaibv.SelectedIndex = 0;
                            }
                            else
                            {
                                tenloaibv.SelectedIndex = 1;
                            }
                        }
                        txtTenbv.Text = rbv["tenbv"].ToString();
                        string s_ngoaidm = rbv["ngoaidm"].ToString();
                        if (sender != null)
                        {
                            butLuu_Click(sender, null);
                            mabv.Enabled = false;
                            txtTenbv.Enabled = false;
                        }
                        //if (bExit)
                        //{
                            
                            if (s_ngoaidm == "1")
                            {
                                if (MessageBox.Show(lan.Change_language_MessageText("Bệnh viện cần chuyển đến nằm ngoài danh mục được phép chuyển viện.") + "\n" +
                                     lan.Change_language_MessageText("Bạn có thật sự muốn chuyển sang Bệnh viện") + ": " + txtTenbv.Text + " " + lan.Change_language_MessageText("không") + "?\n" +
                                     lan.Change_language_MessageText("Nếu có bạn chọn 'Yes', tuy nhiên bạn không có quyền in giấy chuyển viện. Phải chờ ban giám đốc duyệt."), "Medisoft",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    frmGiaycv fcv = new frmGiaycv(m, s_makp, i_userid, s_mabn, 3, int.Parse(s_ngoaidm));
                                    fcv.ShowDialog();
                                }
                                else
                                {
                                    txtTenbv.Text = "";
                                    mabv.Text = "";
                                    mabv.Focus();
                                }
                            }
                            else
                            {
                                frmGiaycv fcv = new frmGiaycv(m, s_makp, i_userid, s_mabn, 3, 0);
                                fcv.ShowDialog();
                            }
                       // }
                    }
                    else
                    {
                        mabv.Text = "";
                    }
                    //frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
                    //f.ShowDialog();
                    //if (f.m_mabv!="")
                    //{
                    //    mabv.Text=f.m_mabv;
                    //    load_mabv(loaibv.Text);
                    //    tenbv.SelectedValue=mabv.Text;
                    //}
				}
                //else if (mabv.Text!=s_mabv)
                //{
                //    if (mabv.Text==m.Mabv)
                //    {
                //        MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"),s_msg);
                //        mabv.Text="";
                //        return;
                //    }
                //    load_mabv(loaibv.Text);
                //    tenbv.SelectedValue=mabv.Text;
                //    if (tenbv.Items.Count==0)
                //    {
                //        frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
                //        f.ShowDialog();
                //        if (f.m_mabv!="")
                //        {
                //            mabv.Text=f.m_mabv;
                //            load_mabv(loaibv.Text);
                //            tenbv.SelectedValue=mabv.Text;
                //        }
                //    }
                //    s_mabv=mabv.Text;
                //    SendKeys.Send("{F4}");
                //}
                //end linh
            }
			catch{}
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					if (tenbv.SelectedIndex==-1) tenbv.SelectedIndex=0;
					if (loaibv.Text!="3" && m.get_data("select maloai from "+user+".tenvien where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString().Substring(0,1)=="2")
						tenloaibv.SelectedValue="3";
				}
				catch{}
				SendKeys.Send("{Tab}");	
			}
		}

		private void tenbv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mabv.Text=tenbv.SelectedValue.ToString();
			}
			catch{mabv.Text="";}
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
					if (icd_noichuyenden.Enabled) icd_noichuyenden.Focus();
					else if (c_lydo.Enabled) c_lydo.Focus();
					else mach.Focus();
					SendKeys.Send("{Home}");
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
				if (qh_diachi.Text=="") qh_diachi.Text="Cùng địa chỉ";
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
			qh_diachi.Text=m.Caps(qh_diachi.Text);
		}

		private void cd_noichuyenden_Validated(object sender, System.EventArgs e)
		{
			if (icd_noichuyenden.Text=="") icd_noichuyenden.Text=m.get_cicd10(cd_noichuyenden.Text);
			if (!m.bMaicd(icd_noichuyenden.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_noichuyenden.Text="";
				icd_noichuyenden.Focus();
			}
		}

		private void icd_noichuyenden_Validated(object sender, System.EventArgs e)
		{
			if (icd_noichuyenden.Text!=s_icd_noichuyenden)
			{				
				if (icd_noichuyenden.Text=="") cd_noichuyenden.Text="";
				else cd_noichuyenden.Text=m.get_vviet(icd_noichuyenden.Text);
				if (cd_noichuyenden.Text=="" && icd_noichuyenden.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_noichuyenden.Text, cd_noichuyenden.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_noichuyenden.Text=f.mTen;
						icd_noichuyenden.Text=f.mICD;
					}
				}
				s_icd_noichuyenden=icd_noichuyenden.Text;
			}
		}

		private void cd_chinh_Validated(object sender, System.EventArgs e)
		{
			if (icd_chinh.Text=="") icd_chinh.Text=m.get_cicd10(cd_chinh.Text);
			if (!m.bMaicd(icd_chinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_chinh.Text="";
				icd_chinh.Focus();
			}
		}

		private void icd_chinh_Validated(object sender, System.EventArgs e)
		{
			if (icd_chinh.Text=="" && !cd_chinh.Enabled)
			{
				cd_chinh.Text="";
				butLuu.Focus();
				return;
			}
            else if (icd_chinh.Text != "")//s_icd_chinh
			{
				cd_chinh.Text=m.get_vviet(icd_chinh.Text);
				if (cd_chinh.Text=="" && icd_chinh.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_chinh.Text=f.mTen;
						icd_chinh.Text=f.mICD;
					}
				}
				//s_icd_chinh=icd_chinh.Text;
			}
		}

		private void denngay_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (sothe.Text!="")
				{
					denngay.Text=denngay.Text.Trim();
					if (denngay.Text.Length==6) denngay.Text=denngay.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(denngay.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
						denngay.Focus();
						return;
					}
					denngay.Text=m.Ktngaygio(denngay.Text,10);
					if (!m.bNgay(denngay.Text,ngayvv.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày khám bệnh!"),s_msg);
						denngay.Focus();
						return;
					}
					if (tungay.Text!="")
					{
						if (!m.bNgay(denngay.Text,tungay.Text))
						{
							MessageBox.Show(lan.Change_language_MessageText("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!"),s_msg);
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
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (sothe.Text=="" || so.Substring(0,2)=="00") tendoituong.Focus();
			else if (m.sothe(int.Parse(tendoituong.SelectedValue.ToString()), sothe.Text)) return;
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
				sothe.Focus();
			}
		}

		private void emp_text(bool skip)
		{
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			sodu=0;
			lchiphi.Text="";
			loaituoi.SelectedIndex=0;
			hoten.Text="";
			ngaysinh.Text="";
			namsinh.Text="";
			tuoi.Text="";
			sonha.Text="";
			thon.Text="";
			cholam.Text="";
			tentqx.SelectedIndex=-1;
			tenkhoa.SelectedIndex=-1;
			tqx.Text="";
			bnmoi.SelectedIndex=0;
			l_maql=0;l_matd=0;l_mavaovien=0;
            butLuu.Tag = "0";
			b_Edit=false;
			if (!bSuadoituong) 
			{
				madoituong.Enabled=false;
				tendoituong.Enabled=false;
				sothe.Enabled=false;
				denngay.Enabled=false;
				tungay.Enabled=false;
				noidk.Enabled=false;
				tennoidk.Enabled=false;
			}
			i_madoituong=0;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			//diungthuoc.Checked=false;
			butdiungthuoc.ForeColor=System.Drawing.SystemColors.Desktop;
			ref_check();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			emp_rv();
            empty_dausinton();
			if (bHinh)
			{
				pic.Tag = "0000.bmp";
				fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
				map = new Bitmap(Image.FromStream(fstr));
				pic.Image = (Bitmap)map;
				image = new byte[fstr.Length];
				fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				pic.Tag = image;
			}
		}

		private void ref_check()
		{
            //linh
            //phauthuat.Checked=false;
			butphauthuat.ForeColor=System.Drawing.SystemColors.Desktop;
			//tainantt.Checked=false;
			buttainantt.ForeColor=System.Drawing.SystemColors.Desktop;
			//thuocbhyt.Checked=false;
			but_thuocbhyt.ForeColor=System.Drawing.SystemColors.Desktop;
			//thuocdan.Checked=false;
			but_thuocdan.ForeColor=System.Drawing.SystemColors.Desktop;
			//chidinh.Checked=false;
			butchidinh.ForeColor=System.Drawing.SystemColors.Desktop;
			//kemtheo.Checked=false;
			butkemtheo.ForeColor=System.Drawing.SystemColors.Desktop;
			//cls.Checked=false;
			//butcls_Click.ForeColor=System.Drawing.SystemColors.Desktop;
            //end lih
		}

		private void emp_bhyt()
		{
			traituyen=0;
			sothe.Text="";
			denngay.Text="";
			tungay.Text="";
			noidk.Text="";
			tennoidk.Text="";
		}

		private void emp_vv()
		{
			ngayvv.Text=m.ngayhienhanh_server;
			s_ngayvv="";//ngayvv.Text;
			tendentu.SelectedIndex=1;
			tennhantu.SelectedIndex=1;
			try
			{
				madoituong.Text="2";
				tendoituong.SelectedValue=madoituong.Text;
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
				if (bTungay && denngay.Enabled) tungay.Enabled=denngay.Enabled;
				else tungay.Enabled=false;
				noidk.Enabled=so.Substring(3,1)=="1";
				tennoidk.Enabled=noidk.Enabled;
			}
			catch{}
			quanhe.Text="";
			qh_hoten.Text="";
			qh_diachi.Text="";
			qh_dienthoai.Text="";
			sovaovien.Text="";
			if (!bSoluutru) soluutru.Text="";
			cd_noichuyenden.Text="";
			icd_noichuyenden.Text="";
			s_icd_noichuyenden="";
			madstt.Text="";
			tendstt.Text="";
			para1.Text="";para2.Text="";
			para3.Text="";para4.Text="";
			kinhcc.Text="";
			ngaysanh.Text="";
			hen.Visible=false;
			hen_ngay.Value=1;
			hen_loai.SelectedIndex=0;
			hen_ghichu.Text="";chkTiepdon.Checked=false;
			if (b701424)
			{
				mabs.Text="";tenbs.Text="";
				mp.Text="";mt.Text="";
				nhanapp.Text="";nhanapt.Text="";
			}
			if (s_mabs!="" && (i_loai==0 || i_loai==1))
			{
				mabs.Text=s_mabs;
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null)
				{
					tenbs.Text=r["hoten"].ToString();
					tenbs_pass.Text=r["password_"].ToString();
				}
				else tenbs.Text="";
			}
			c_lydo.Text="";c_hb_banthan.Text="";c_hb_benhly.Text="";
			c_hb_giadinh.Text="";c_kb_bophan.Text="";c_kb_chuy.Text="";sobo.Text="";phanbiet.Text="";
			c_kb_toanthan.Text="";c_kb_tomtat.Text="";c_kb_xuli.Text="";
            c_kb_tai.Text = ""; c_kb_mui.Text = c_kb_hong.Text = "";
		}

		private void emp_rv()
		{
			cd_chinh.Text="";
			icd_chinh.Text="";
			s_icd_chinh="";
			bienchung.Checked=false;
			taibien.Checked=false;
			giaiphau.Checked=false;
			tenloaibv.SelectedIndex=-1;
			tenbv.SelectedIndex=-1;
			tenkhoa.SelectedIndex=-1;
			khoa.Text="";
			s_mabv="";s_noicap="";
			for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
			maxutri.Text="";
			if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
			else if (!bSoluutru) soluutru.Text="";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			buttiensu.ForeColor=System.Drawing.SystemColors.Desktop;
			emp_text(false);
			if (bHiends)
			{
				load_ref();
				//danhsach.Visible=(list.Items.Count>0);
                if (list.Items.Count <= 0) mabn2.Focus();
				else list.Focus();
			}
			else mabn2.Focus();

            if (list.Items.Count > 0 && mabn3.Text == "")
            {
                this.danhsach.Location = new Point(label2.Location.X, label2.Location.Y);
                this.danhsach.Size = new Size(c_hb_benhly.Right + treeView1.Right, butTiep.Top);//1008//419
            }
		}

		private bool kiemtra()
		{
            if (c_lydo.Text.Trim()=="")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập lý do vào viện !"), s_msg);
                c_lydo.Focus();
                return false;
            }
            if (c_hb_benhly.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập quá trình bệnh lý !"), s_msg);
                c_hb_benhly.Focus();
                return false;
            }
            if (c_kb_toanthan.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập khám bệnh toàn thân !"), s_msg);
                c_kb_toanthan.Focus();
                return false;
            }
            if (c_kb_bophan.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập khám bệnh bộ phận !"), s_msg);
                c_kb_bophan.Focus();
                return false;
            }
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
			}

			if (mann.Text=="" || tennn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
				mann.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
				return false;
			}

			if ((b_khambenh) || (icd_chinh.Text!="" && cd_chinh.Text!="") || maxutri.Text.Trim()!="08,")
			{
				if (dentu.Text=="1")
				{
					if (icd_noichuyenden.Text=="" || cd_noichuyenden.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"),s_msg);
						icd_noichuyenden.Focus();
						return false;
					}
					else if (icd_noichuyenden.Text=="" && cd_noichuyenden.Text!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"),s_msg);
						icd_noichuyenden.Focus();
						return false;
					}
					else if (cd_noichuyenden.Text=="" && icd_noichuyenden.Text!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán nơi chuyển đến !"),s_msg);
						if (cd_noichuyenden.Enabled) cd_noichuyenden.Focus();
						else icd_noichuyenden.Focus();
						return false;
					}
					if (!m.Kiemtra_maicd(dticd,icd_noichuyenden.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
						icd_noichuyenden.Focus();
						return false;
					}
					if (bChandoan)
					{
						if (!m.Kiemtra_tenbenh(dticd,cd_noichuyenden.Text))
						{
							MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
							cd_noichuyenden.Focus();
							return false;
						}
					}
				}
			}

			if (dentu.Text=="1")
			{
				if (madstt.Text=="" || tendstt.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên cơ quan y tế !"),s_msg);
					madstt.Focus();
					return false;
				}
			}

			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngaysinh.Focus();
				return false;
			}

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

            if (ngayvv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào khám bệnh !"),s_msg);
				ngayvv.Focus();
				return false;
			}

			if (tennhantu.SelectedIndex==-1 || nhantu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập trực tiếp vào !"),s_msg);
				nhantu.Focus();
				return false;
			}

			if (tendentu.SelectedIndex==-1 || dentu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nơi giới thiệu !"),s_msg);
				dentu.Focus();
				return false;
			}

			if (madoituong.Text=="" || tendoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập đối tượng !"),s_msg);
				tendoituong.Focus();
				return false;
			}
			else
			{
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
					if (sothe.Text=="")
					{
						sothe.Focus();
						return false;
					}
					if (so.Substring(2,1)=="1" && denngay.Text=="")
					{
						denngay.Focus();
						return false;
					}
				}
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

			if (makp.Text=="" || tenkp.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"),s_msg);
				tenkp.Focus();
				return false;
			}
            string s_mabenh = icd_chinh.Text;
            if (icd_kemtheo.Text != "") s_mabenh += "," + icd_kemtheo.Text;
            if (icd_noichuyenden.Text != "") s_mabenh += "," + icd_noichuyenden.Text;
            if (m.ManTinh(s_mabenh))
            {
                if (maxutri.Text == "" || maxutri.Text.IndexOf("06,") == -1 || maxutri.Text.IndexOf("02,") == -1 || maxutri.Text.IndexOf("05,") == -1 || maxutri.Text.IndexOf("07,") == -1)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có bệnh mãn tính. Bạn có mở hồ sơ bệnh án ngoại trú cho bệnh nhân này không?") + ".", "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        maxutri.Text = maxutri.Text.Trim(',') + "," + "02,";
                        maxutri_Validated(null, null);
                        tenkhoa.SelectedValue = s_makp;
                        khoa.Text = tenkhoa.SelectedValue.ToString();
                    }
                }
            }
			s_chonxutri=chon_xutri();
			//
			if (bPhongkham_chidinh)
			{
				l_maql=m.get_maql_mmyy(3,s_mabn,makp.Text,ngayvv.Text,false);
				if (l_maql==0)
				{
					sql="select * from "+user+mmyy+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
                    sql += "  and makp='" + makp.Text + "'";//and done is null
					if (m.get_data(sql).Tables[0].Rows.Count==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh "+hoten.Text.Trim()+" chưa được chỉ định vào ")+tenkp.Text,LibMedi.AccessData.Msg);
						butBoqua.Focus();
						return false;
					}
				}
			}
			//
			if (s_chonxutri!="")
			{
				if ((s_chonxutri.IndexOf("06,")!=-1 && (s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("08,")!=-1)) || (s_chonxutri.IndexOf("07,")!=-1 && s_chonxutri.Length>3))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí không hợp lệ !"),LibMedi.AccessData.Msg);
					xutri.Focus();
					return false;
				}
			}
			if (maxutri.Text.Trim()!="08,")
			{
				if ((b_khambenh) || (icd_chinh.Text!="" && cd_chinh.Text!="") || (s_chonxutri!=""))
				{
					if (s_chonxutri=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"),s_msg);
						xutri.Focus();
						return false;
					}

					if (icd_chinh.Text=="" && cd_chinh.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
						icd_chinh.Focus();
						return false;
					}
					else if (icd_chinh.Text=="" && cd_chinh.Text!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
						icd_chinh.Focus();
						return false;
					}
					else if (cd_chinh.Text=="" && icd_chinh.Text!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"),s_msg);
						if (cd_chinh.Enabled) cd_chinh.Focus();
						else icd_chinh.Focus();
						return false;
					}
					if (!m.Kiemtra_maicd(dticd,icd_chinh.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
						icd_chinh.Focus();
						return false;
					}
					if (bChandoan)
					{
						if (!m.Kiemtra_tenbenh(dticd,cd_chinh.Text))
						{
							MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
							cd_chinh.Focus();
							return false;
						}
					}
					if (mabs.Text=="" || tenbs.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
						mabs.Focus();
						return false;
					}

					if (s_chonxutri.IndexOf("06,")!=-1)
					{
						if (tenloaibv.SelectedIndex==-1 || loaibv.Text=="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển viện !"),s_msg);
							loaibv.Focus();
							return false;
						}

                        if (mabv.Text == "" || txtTenbv.Text == "")// tenbv.SelectedIndex==-1)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển đến !"), s_msg);
                            mabv.Focus();
                            return false;
                        }
					}

					if (s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("08,")!=-1)
					{
						if (tenkhoa.SelectedIndex==-1 || khoa.Text=="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Nhập vào khoa/phòng !"),s_msg);
							khoa.Focus();
							return false;
						}
					}
				}
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
					if (m.kiemtra_khamnhi(makp.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Độ tuổi và phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
						makp.Focus();
						return false;
					}
				}
			}
            //if (soluutru.Text=="" && b_soluutru && soluutru.Enabled)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Nhập số lưu trữ !"),s_msg);
            //    soluutru.Focus();
            //    return false;
            //}
			s_mabn=mabn2.Text+mabn3.Text;
			if (m.get_maql_mmyy(3,s_mabn,"??",ngayvv.Text,false)==0)
			{
				if (m.bTuvong(mabn2.Text+mabn3.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"),LibMedi.AccessData.Msg);
					butBoqua_Click(null,null);
				}
			}
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) m.tao_user_mmyy(mmyy,i_userid);
			
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="")// && m.get_maql_mmyy(3,s_mabn,makp.Text,ngayvv.Text,false)==0)
			{
				if (s_chonxutri.IndexOf("02,")!=-1 && bXutri_ngoaitru) //dieu tri ngoai tru
				{
					string s_tenkp=m.bHiendien(s_mabn,2);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
						xutri.Focus();
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,l_maql,2);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
							xutri.Focus();
							return false;
						}
					}
				}
				if (s_chonxutri.IndexOf("05,")!=-1 && bXutri_noitru) //noi tru
				{
					string s_tenkp=m.bHiendien(s_mabn,1);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+ "\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
						xutri.Focus();
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,m.get_maql(s_mabn,ngayvv.Text,1),1);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
							xutri.Focus();
							return false;
						}
					}
				}
			}
			if (khamthai.Visible)
			{
				if (phai.SelectedIndex==0 && (para1.Text+para2.Text+para3.Text+para4.Text!="" || kinhcc.Text!="" || ngaysanh.Text!=""))
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
			else if (!bTudong) loai.SelectedIndex=0;
			if (l_maql!=0 && tenkp.Items.Count==1)
			{
				//DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
				if (tmp.Rows.Count>0)
				{
					if (tmp.Rows[0]["makp"].ToString()!=makp.Text)
					{
						MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ")+tmp.Rows[0]["tenkp"].ToString()+lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"),LibMedi.AccessData.Msg);
						butBoqua.Focus();
						return false;
					}
				}
			}
			l_maql=m.get_maql_ngay_gio(3,s_mabn,makp.Text,ngayvv.Text);
			if (l_maql!=0)
			{
				if (bNgay1kham)
				{
					if (m.get_maql_ngay(3,s_mabn,makp.Text,ngayvv.Text.Substring(0,10))!=0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày "+ngayvv.Text.Substring(0,10)+" người bệnh đã khám ")+tenkp.Text.Trim(),LibMedi.AccessData.Msg);
						butBoqua.Focus();
						return false;
					}
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {")+tenkp.Text.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Bạn có muốn lưu thêm 1 đợt nữa không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
				{
					butTiep.Focus();
					return false;
				}
			}
			
			if (bSothe_mabn)
			{
				if (sothe.Enabled && sothe.Text!="")
				{
					string s=m.mabn_bhyt_ngayhethan(nam,mabn2.Text+mabn3.Text,sothe.Text,denngay.Text);
					if (s!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Số thẻ ")+sothe.Text+"\n"+
                            lan.Change_language_MessageText("Đã có mã người bệnh")+": "+s+"\n"+
                            lan.Change_language_MessageText("Sử dụng")+"!",LibMedi.AccessData.Msg);
						sothe.Focus();
						return false;
					}
				}
			}
			if (b711512)
			{
				if (mabs.Text=="" || tenbs.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
					mabs.Focus();
					return false;
				}
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
                //if (!bAdministrator && tenbs_pass.Enabled)
                //{
                //    if (tenbs_pass.Text!=r["password_"].ToString())
                //    {
                //        MessageBox.Show("Mật khẩu bác sĩ điều trị chưa hợp lệ !",LibMedi.AccessData.Msg);
                //        tenbs_pass.Focus();
                //        return false;
                //    }
                //}
			}
			if (bKhamsuckhoe)
			{
				if (makp.Text==m.ksk_phong)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh "+hoten.Text+" khám sức khỏe !"),LibMedi.AccessData.Msg);
					butBoqua.Focus();
					return false;
				}
			}
            //if (m.bDausinhton_khambenh)//Tu:21/06/2011
            //{
            //    if (l_maql == 0)
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập dấu sinh tồn !"), LibMedi.AccessData.Msg);
            //        barDausinhton_Click(null, null);
            //        return false;
            //    }
            //    else
            //    {
            //        sql = "select idkhoa from " + xxx + ".d_dausinhton where idkhoa=" + l_maql + "";
            //        if (m.get_data(sql).Tables[0].Rows.Count <= 0)
            //        {
            //            MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập dấu sinh tồn !"), LibMedi.AccessData.Msg);
            //            barDausinhton_Click(null, null);
            //            return false;
            //        }
            //    }
            //}//end Tu

            //Khuong:05/07/2011
            string s_vp = "";
            if (s_chonxutri.IndexOf("07,") != -1)
            {
                s_vp = m.sKtKetquaCLS(s_mabn, decimal.Parse(l_mavaovien.ToString()), ngayvv.Text, ngayvv.Text);
                if (s_vp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân tử vong phải có kết quả của " + s_vp), s_msg);
                    return false;
                }
            }
            //
			return true;
		}

		private string chon_xutri()
		{
			string s="";
            for (int i = 0; i < xutri.Items.Count; i++)
            {
                if (xutri.GetItemChecked(i))
                {
                    s += dtxutri.Rows[i]["ma"].ToString().Trim().PadLeft(2, '0') + ",";
                }
            }
			maxutri.Text=s;
			return s;
		}

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            //linh
            ////Khuong:05/07/2011
            //string s_vp = "";
            //if (s_chonxutri.IndexOf("07,") != -1)
            //{
            //    s_vp = m.sKtKetquaCLS(s_mabn, decimal.Parse(l_mavaovien.ToString()), ngayvv.Text, ngayvv.Text);
            //    if (s_vp != "")
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân tử vong phải có kết quả của " + s_vp), s_msg);
            //        return;
            //    }
            //}
            ////
            bExit = kiemtra();
            if (!bExit) return;
            decimal maql1 = 0;
            int p = 0; string s_ttlucrv = "1"; string sokham = "";
            if (s_chonxutri != "")
            {
                p = s_chonxutri.IndexOf(",");
                s_ttlucrv = s_chonxutri.Substring(0, p);
            }
            s_mabn = mabn2.Text + mabn3.Text;
            xxx = user + m.mmyy(ngayvv.Text);
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, true);
            //linh
            butLuu.Tag = l_maql.ToString();
            if (!m.upd_lienhe(ngayvv.Text, l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            //Tu:28/06/2011 soluutru tang tu dong neu check option D28
            if (m.bSoluutruPK_PL_NGT_tudong && s_soluutru != "")
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu

            //m.execute_data("update " + xxx + ".lienhe set mabs='" + mabs.Text + "' where maql=" + l_maql);
            //if (bSoluutru && soluutru.Text!="") m.execute_data("update "+xxx+".lienhe set soluutru='"+soluutru.Text+"' where maql="+l_maql);
            if (khamthai.Visible && ((para1.Text.Trim().Length + para2.Text.Trim().Length + para3.Text.Trim().Length + para4.Text.Trim().Length) > 0 || kinhcc.Text.Trim() != "")) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), kinhcc.Text, ngaysanh.Text, "");

            int itable = m.tableid("", "benhanpk");
            if (m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + "1" + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text.Trim() + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + sovaovien.Text + "^" + "3" + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            m.upd_lydokham(ngayvv.Text, l_maql, sobo.Text, c_lydo.Text);
            if (!m.upd_benhandt_mmyy(s_mabn, l_maql, makp.Text, ngayvv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, mabs.Text, sovaovien.Text, 3, i_userid, true, 0, l_mavaovien))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            m.upd_bavv_chung(ngayvv.Text, s_mabn, l_maql, c_lydo.Text, c_hb_benhly.Text, c_hb_banthan.Text, c_hb_giadinh.Text, c_kb_toanthan.Text, c_kb_bophan.Text, c_kb_tomtat.Text, c_kb_xuli.Text, c_kb_chuy.Text, sobo.Text, phanbiet.Text, i_userid);
            //TU:08/04/2011
            if (c_kb_tai.Text == "") c_kb_tai.Text = m.get_nor(-3);
            if (c_kb_mui.Text == "") c_kb_mui.Text = m.get_nor(-4);
            if (c_kb_mui.Text == "") c_kb_mui.Text = m.get_nor(-5);
            m.upd_bavv_tmh(ngayvv.Text, l_maql, c_kb_tai.Text, c_kb_mui.Text, c_kb_hong.Text, "");//tmh
            m.upd_bavv_dausinhton(ngayvv.Text, s_mabn, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "" && nhietdo.Text.Trim() != ".") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0);
            //linh
            d.upd_dausinhton(m.mmyy(ngayvv.Text), l_maql, l_maql, 0, ngayvv.Text, mabs.Text, "", (mach.Text != "") ? decimal.Parse(mach.Text) : 0, 
                (nhietdo.Text != "" && nhietdo.Text.Trim() != ".") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, 
                (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? int.Parse(cannang.Text) : 0, "", "", "", s_mabn,
                (decimal) l_maql,(decimal) l_mavaovien, s_makp,i_userid);
            //end
            decimal chieucao_ = (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0;
            m.execute_data("update " + xxx + ".bavv_dausinhton set chieucao=" + chieucao_ + " where maql=" + l_maql + " ");
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (int.Parse(so.Substring(0, 2)) > 0)
            {
                if (!m.upd_bhyt(ngayvv.Text, s_mabn, l_maql, sothe.Text, denngay.Text, noidk.Text, 0, tungay.Text, traituyen))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                    return;
                }
            }

            if (cd_noichuyenden.Text != "" || madstt.Text != "")
            {
                if (!m.upd_noigioithieu(ngayvv.Text, l_maql, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                    return;
                }
            }
            l_matd = m.get_tiepdon(s_mabn, ngayvv.Text);
            if (bTiepdon)
            {
                if (l_matd == 0)
                {
                    l_matd = m.getidyymmddhhmiss_stt_computer;//get_capid(1);
                    m.upd_tiepdon_mmyy(s_mabn, l_matd, makp.Text, ngayvv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Khambenh, 0, l_matd);
                }
            }
            //Tu:21/05/2011 insert vao bang theodoitsu
            try
            {
                DataRow dr = m.getrowbyid(dticd, "cicd10='" + icd_chinh.Text.Trim() + "' and tiensubenh=1");
                if (dr != null)
                {
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + s_mabn + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(s_mabn, cd_chinh.Text, ngayvv.Text.Substring(0, 10), icd_chinh.Text, i_stt);

                    decimal i_stt_tsu = 0;
                    try { i_stt_tsu = decimal.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(icd_chinh.Text, i_stt_tsu, cd_chinh.Text);
                }

                DataRow dr0 = m.getrowbyid(dticd, "cicd10='" + icd_kemtheo.Text.Trim() + "' and tiensubenh=1");
                if (dr0 != null)
                {
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + s_mabn + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(s_mabn, phanbiet.Text, ngayvv.Text.Substring(0, 10), icd_kemtheo.Text, i_stt);

                    decimal i_stt_tsu = 0;
                    try { i_stt_tsu = decimal.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(icd_kemtheo.Text, i_stt_tsu, phanbiet.Text);
                }

                DataRow dr1 = m.getrowbyid(dticd, "cicd10='" + icd_chinh.Text.Trim() + "' and benhmantinh=1");
                if (dr1 != null)
                    m.upd_benhmantinh(s_mabn, cd_chinh.Text, icd_chinh.Text, "", i_userid, ngayvv.Text.Substring(0, 10));
                DataRow dr2 = m.getrowbyid(dticd, "cicd10='" + icd_kemtheo.Text.Trim() + "' and benhmantinh=1");
                if (dr2 != null)
                    m.upd_benhmantinh(s_mabn, phanbiet.Text, icd_kemtheo.Text, "", i_userid, ngayvv.Text.Substring(0, 10));
            }
            catch { }
            //end Tu
            m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Khambenh, l_maql);
            if (manuoc.Enabled && manuoc.Text != "") m.upd_nuocngoai(s_mabn, manuoc.Text);
            else m.execute_data("delete from " + user + ".nuocngoai where mabn='" + s_mabn + "'");
            if (quanhe.Text != "") m.upd_quanhe(ngayvv.Text, l_maql, quanhe.Text, qh_hoten.Text, qh_diachi.Text, qh_dienthoai.Text);
            if (mabs.Text != "" && s_chonxutri != "") m.execute_data("update " + m.user + m.mmyy(ngayvv.Text) + ".lienhe set mabs='" + mabs.Text + "' where maql=" + l_maql);
            if (s_chonxutri != "" && icd_chinh.Text != "" && cd_chinh.Text != "")
            {
                if (pmat.Visible) m.upd_ttmat(ngayvv.Text, l_maql, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
                if (s_chonxutri.IndexOf("07,") != -1)
                {
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count == 0)
                    {
                        l_tuvong_Click(null, null);
                        //return;
                    }
                }
                m.upd_xutrikbct(ngayvv.Text, l_maql, s_chonxutri, khoa.Text);
                if (loaibv.Enabled && loaibv.Text != "") m.upd_chuyenvien(l_maql, mabv.Text, int.Parse(loaibv.Text));
                else m.execute_data("delete from " + user + ".chuyenvien where maql=" + l_maql);
                sql = "update " + xxx + ".tiepdon set done='x' where noitiepdon in (0,1,5,16) and mabn='" + s_mabn + "'" + " and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'";
                m.execute_data(sql);
                if (bDangky_homqua && s_ngaydk != "")
                    if (s_ngaydk.Substring(0, 10) != ngayvv.Text.Substring(0, 10) && m.bMmyy(m.mmyy(s_ngaydk))) m.execute_data("update " + user + m.mmyy(s_ngaydk) + ".tiepdon set done='x' where noitiepdon in (0,1,5,16) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + s_ngaydk.Substring(0, 10) + "' and makp='" + makp.Text + "'");
                decimal maluu = l_maql;

                #region hen
                //linha
                upd_xutri_hen();
                //end linh
                #endregion
                if (s_chonxutri.IndexOf("08,") != -1)
                {
                    if (i_sokham != 3 && khoa.Text != "" && bNew)
                    {
                        sokham = m.get_sokham(ngayvv.Text.Substring(0, 10), khoa.Text, i_sokham).ToString();
                        frmSott f = new frmSott("Số khám " + tenkhoa.Text.ToUpper().Trim() + ": " + sokham);
                        f.ShowDialog(this);
                    }
                    maql1 = m.get_maql_mmyy(s_mabn, khoa.Text, ngayvv.Text);
                    m.upd_tiepdon_mmyy(s_mabn, maql1, khoa.Text, ngayvv.Text, int.Parse(madoituong.Text), (sokham != "") ? sokham : sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Khambenh, 0, l_mavaovien);
                    m.upd_lienhe(ngayvv.Text, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    //Tu:28/06/2011
                    if (m.bSoluutruPK_PL_NGT_tudong)
                        m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                    //end Tu
                    //update tiep don done='c' chua dong tien
                    if ((bChuyenkham_tinhcongkham && !m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString()))) || (bChuyenkham_thuphi && m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString()))))
                        upd_data(maql1, khoa.Text, ngayvv.Text);
                    so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (int.Parse(so.Substring(0, 2)) > 0)
                    {
                        if (!m.upd_bhyt(ngayvv.Text, s_mabn, maql1, sothe.Text, denngay.Text, noidk.Text, 0, tungay.Text, traituyen))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                            return;
                        }
                    }
                    if (cd_noichuyenden.Text != "" || madstt.Text != "")
                    {
                        if (!m.upd_noigioithieu(ngayvv.Text, maql1, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                            return;
                        }
                    }
                }
                else
                {
                    if (s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) //dieu tri ngoai tru
                        upd_ngoaitru(so);
                    if (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru) //noi tru
                        upd_noitru(so);
                    if (s_chonxutri.IndexOf("04,") != -1) upd_phongluu(so);
                }
                l_maql = maluu;
            }
            else if (s_chonxutri.IndexOf("08,") != -1)
            {
                if (i_sokham != 3 && khoa.Text != "" && bNew)
                {
                    sokham = m.get_sokham(ngayvv.Text.Substring(0, 10), khoa.Text, i_sokham).ToString();
                    frmSott f = new frmSott("Số khám " + tenkhoa.Text.ToUpper().Trim() + ": " + sokham);
                    f.ShowDialog(this);
                }
                sql = "update " + xxx + ".tiepdon set done='x' where noitiepdon in (0,1,5,16) and mabn='" + s_mabn + "'" + " and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'";
                m.execute_data(sql);
                maql1 = m.get_maql_mmyy(s_mabn, khoa.Text, ngayvv.Text);
                m.upd_tiepdon_mmyy(s_mabn, maql1, khoa.Text, ngayvv.Text, int.Parse(madoituong.Text), (sokham != "") ? sokham : sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Khambenh, 0, l_mavaovien);
                m.upd_lienhe(ngayvv.Text, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                //Tu:28/06/2011
                if (m.bSoluutruPK_PL_NGT_tudong)
                    m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                //end Tu
                //update tiep don done='c' chua dong tien
                if ((bChuyenkham_tinhcongkham && !m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString()))) || (bChuyenkham_thuphi && m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString()))))
                    upd_data(maql1, khoa.Text, ngayvv.Text);
                //
                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (int.Parse(so.Substring(0, 2)) > 0)
                {
                    if (!m.upd_bhyt(ngayvv.Text, s_mabn, maql1, sothe.Text, denngay.Text, noidk.Text, 0, tungay.Text, traituyen))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                        return;
                    }
                }
                if (cd_noichuyenden.Text != "" || madstt.Text != "")
                {
                    if (!m.upd_noigioithieu(ngayvv.Text, maql1, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                        return;
                    }
                }
            }
            else
            {
                m.execute_data("update " + xxx + ".tiepdon set done='?' where noitiepdon in (0,1,5,16) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'");
                if (bDangky_homqua && s_ngaydk != "")
                    if (s_ngaydk.Substring(0, 10) != ngayvv.Text.Substring(0, 10) && m.bMmyy(m.mmyy(s_ngaydk)))
                        m.execute_data("update " + user + m.mmyy(s_ngaydk) + ".tiepdon set done='?' where done is null and noitiepdon in (0,1,5,16) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + s_ngaydk.Substring(0, 10) + "' and makp='" + makp.Text + "'");
            }
            //linh
            if (m.get_lydokham(ngayvv.Text, l_mavaovien, "id_lydokham").IndexOf("3+") > -1)
            {
                if (m.get_data("select mabn from " + user + ".phanungthuoc_adr where maql=" + l_maql.ToString()).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân vào khám do bị dị ứng thuốc. Bạn phải nhập thêm thông tin ADR"));
                    butPhanungcohai_Click(sender, e);
                }
            }
            string s_mabenh = icd_chinh.Text;
            if (icd_kemtheo.Text != "") s_mabenh += "," + icd_kemtheo.Text;
            if (icd_noichuyenden.Text != "") s_mabenh += "," + icd_noichuyenden.Text;
            if (sender != null)
            {
                ena_but(false);
                khoa.Enabled = false;
                tenkhoa.Enabled = false;
                butTiep.Focus();
            }
            //end linh
            if (bStt) m.execute_data("update " + xxx + ".sttkham set dakham=dakham+1 where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and makp='" + makp.Text + "'");
            if (bHienthi_tivi) m.upd_remark(makp.Text, 1);
        }
        private void upd_data(decimal maql, string makhoa, string ngay)
        {
            DataRow r = m.getrowbyid(dtkpfull, "makp='" + makhoa + "'");
            if (r != null)
            {
                int _mavp = int.Parse(r["mavp"].ToString());
                if (m.bChuyenkham_pkthu2_giataikham && r["mavptk"].ToString() != "" && r["mavptk"].ToString() != "0") _mavp = int.Parse(r["mavptk"].ToString());
                decimal d_dongia = 0, d_vattu = 0;
                string mmyy = m.mmyy(ngay);
                int i_madt = int.Parse(madoituong.Text);
                if (bChuyenkham_tinh_congkham_dtthuphi && i_madt == 1) i_madt = 2;
                r = m.getrowbyid(dtgia, "id=" + _mavp);
                if (r != null)
                {
                    decimal l_id = m.get_id_chidinh(ngay, maql, _mavp, v.iNgoaitru);
                    if (l_id == 0) l_id = v.get_id_chidinh;
                    if (m.bNuocngoai(mabn2.Text + mabn3.Text))
                    {
                        d_dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                        d_vattu = decimal.Parse(r["vattu_nn"].ToString()) * m.dTygia;
                    }
                    else
                    {
                        string gia = m.field_gia(i_madt.ToString());//m.field_gia(tendoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        d_dongia = decimal.Parse(r[gia].ToString());
                        d_vattu = decimal.Parse(r[giavt].ToString());
                    }
                    //if(G79(bBH_chitra_1congkham) duoc chong thi d_dongia set ve =0): PK thu hai tro di khong lay tien cong kham bhyt
                    if (m.bBH_chitra_1congkham && i_madt == 1) d_dongia = 0;
                    v.upd_chidinh(l_id, mabn2.Text + mabn3.Text, l_matd, maql, 0, ngay, v.iNgoaitru, makhoa, i_madt, _mavp, 1, d_dongia, d_vattu, i_userid, 0, 0, l_id, icd_chinh.Text, cd_chinh.Text, mabs.Text, 3, "");
                    v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + traituyen + " where id=" + l_id);//((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString())
                    //if (bThuphi_kham)
                    //{
                    DataRow r1 = m.getrowbyid(dtdt, "mien=0 and donvi=0 and trasau=0 and madoituong=" + i_madt);//int.Parse(tendoituong.SelectedValue.ToString()));
                    if (r1 != null)
                    {
                        m.execute_data("update " + user + m.mmyy(ngay) + ".tiepdon set done='c' where maql=" + maql);
                        if (bDangky_homqua && s_ngaydk != "")
                            if (s_ngaydk.Substring(0, 10) != ngay && m.bMmyy(m.mmyy(s_ngaydk)))
                                m.execute_data("update " + user + m.mmyy(s_ngaydk) + ".tiepdon set done='c' where maql=" + maql);
                    }
                    //}
                    //Tinh chenh lech cong kham
                    if (i_madt == 1)
                    {
                        int tmp_madt = i_madt;
                        if (bChenhlech_laygiaphuthu) i_madt = m.iTunguyen_Tronggio_ngoaigio(s_mabn, l_mavaovien.ToString());
                        else i_madt = m.iTunguyen;

                        string gia = m.field_gia(i_madt.ToString());//m.field_gia(tendoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        if (bChenhlech_laygiaphuthu)
                        {
                            gia = gia.Replace("gia", "phuthu");
                            d_dongia = decimal.Parse(r[gia].ToString());
                        }
                        else//tinh chenh lech
                            d_dongia = decimal.Parse(r[gia].ToString()) - decimal.Parse(r["gia_th"].ToString()); ;

                        l_id = -1 * l_id;
                        //if (m.bBH_chitra_1congkham && i_madt == 1) d_dongia = 0;
                        v.upd_chidinh(l_id, mabn2.Text + mabn3.Text, l_matd, maql, 0, ngay, v.iNgoaitru, makhoa, i_madt, _mavp, 1, d_dongia, d_vattu, i_userid, 0, 0, l_id, icd_chinh.Text, cd_chinh.Text, mabs.Text, 3, "");
                        v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + traituyen + " where id=" + l_id);//((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString())                    
                        i_madt = tmp_madt;
                    }
                    //end 
                }
            }
        }

		private void upd_hen()
		{
			decimal maql1;
			s_mabn=mabn2.Text+mabn3.Text;
			string ngay,so,s_sovaovien=sovaovien.Text;
			DateTime dt=m.StringToDate(ngayvv.Text.Substring(0,10));
			for(int i=1;i<=Convert.ToInt16(hen_ngay.Value);i++)
			{
				ngay=m.DateToString("dd/MM/yyyy",dt.AddDays(i));
				if (m.mmyy(ngayvv.Text)==m.mmyy(ngay))
				{
					maql1=m.get_maql_tiepdon_mmyy(s_mabn,ngay+" 07:00");
					s_sovaovien="";
					foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngay)+".tiepdon where maql="+maql1).Tables[0].Rows)
						s_sovaovien=r["sovaovien"].ToString();
					if (s_sovaovien=="")
					{
						s_sovaovien=(bStt)?m.getSttkham(ngay,makp.Text).ToString():m.get_sokham(ngay,makp.Text,i_sokham).ToString();
						string s_hen=hen_ghichu.Text.Trim()+", Thứ tự tái khám "+s_sovaovien;
						m.upd_hen(ngayvv.Text,l_maql,hen_ngay.Value,s_hen,hen_loai.SelectedIndex,(chkTiepdon.Checked)?1:0);
						hen_ghichu.Text=s_hen;
					}
					m.upd_tiepdon_mmyy(s_mabn,maql1,makp.Text,ngay+" 07:00",int.Parse(tendoituong.SelectedValue.ToString()),s_sovaovien,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),bnmoi.SelectedIndex,i_userid,LibMedi.AccessData.Taikham,loai.SelectedIndex,l_matd);
					if (bHen_dangkylai) m.execute_data("update "+user+m.mmyy(ngay)+".tiepdon set done='x' where maql="+maql1);
					m.upd_lienhe(ngay,maql1,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex);
                    //Tu:28/06/2011
                    if (m.bSoluutruPK_PL_NGT_tudong)
                        m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                    //end Tu
					so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
					if (int.Parse(so.Substring(0,2))>0)
					{
						if (!m.upd_bhyt(ngay,s_mabn,maql1,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
						{
							MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
							return;
						}
					}
				}
				else
				{
					maql1=m.get_maql_tiepdon_hen(s_mabn,ngay+" 07:00");
					s_sovaovien="";
					foreach(DataRow r in m.get_data("select * from "+xxx+".tiepdon where maql="+maql1).Tables[0].Rows)
						s_sovaovien=r["sovaovien"].ToString();
					if (s_sovaovien=="")
					{
						s_sovaovien=(bStt)?m.getSttkham_hen(ngay,makp.Text).ToString():m.get_sokham_hen(ngay,makp.Text,i_sokham).ToString();
						string s_hen=hen_ghichu.Text.Trim()+", Thứ tự tái khám "+s_sovaovien;
						m.upd_hen(ngayvv.Text,l_maql,hen_ngay.Value,s_hen,hen_loai.SelectedIndex,(chkTiepdon.Checked)?1:0);
						hen_ghichu.Text=s_hen;
					}
					m.upd_tiepdon(s_mabn,l_matd,maql1,makp.Text,ngay+" 07:00",int.Parse(tendoituong.SelectedValue.ToString()),s_sovaovien,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),bnmoi.SelectedIndex,i_userid,LibMedi.AccessData.Taikham,loai.SelectedIndex);
					if (bHen_dangkylai) m.execute_data("update "+user+".tiepdon set done='x' where maql="+maql1);
					m.upd_lienhe(maql1,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex);
                    //Tu:28/06/2011
                    if (m.bSoluutruPK_PL_NGT_tudong)
                        m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                    //end Tu
					so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
					if (int.Parse(so.Substring(0,2))>0)
					{
						if (!m.upd_bhyt(s_mabn,maql1,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
						{
							MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
							return;
						}
					}
				}
			}
		}
		private void upd_phongluu(string so)
		{
			string makp_pl="99";
			s_mabn=mabn2.Text+mabn3.Text;
			//l_maql=m.get_maql(4,s_mabn,makp_pl,ngayvv.Text,true);
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text, true);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            //Tu:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu

            //int itable = m.tableid("", "benhancc");
            //if (m.get_maql(4,s_mabn,makp_pl,ngayvv.Text,false)!= 0)
            //{
            //    m.upd_eve_tables(itable, i_userid, "upd");
            //    m.upd_eve_upd_del(itable, i_userid, "upd",s_mabn+"^"+l_maql.ToString()+"^"+makp_pl+"^"+ngayvv.Text+"^"+dentu.Text+"^"+nhantu.Text+"^"+"1"+"^"+tendoituong.SelectedValue.ToString()+"^"+cd_chinh.Text.Trim()+"^"+icd_chinh.Text+"^"+mabs.Text+"^"+sovaovien.Text+"^"+"4"+"^"+i_userid.ToString());
            //}
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhancc");
            if (m.get_maql_benhancc(s_mabn, ngayvv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_maql.ToString() + "^" + l_maql.ToString() + "^" + makp_pl + "^" + ngayvv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
			else m.upd_eve_tables(itable, i_userid, "ins");

			int userpl=i_userid;
			if (bPhongluu_userid)
			{
				DataRow r=m.getrowbyid(dtkp,"makp='"+makp.Text+"'");
				if (r!=null) userpl=int.Parse(r["userpl"].ToString());
			}
			//if (!m.upd_benhandt(s_mabn,l_maql,makp_pl,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),1,int.Parse(tendoituong.SelectedValue.ToString()),cd_chinh.Text,icd_chinh.Text,mabs.Text,sovaovien.Text,4,userpl,true,0))
            if (!m.upd_benhancc(s_mabn, l_maql, l_maql, makp_pl, ngayvv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), mabs.Text, cd_chinh.Text, icd_chinh.Text, sovaovien.Text, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
            //Tu:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0,10)) + ".benhancc set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu

			m.upd_bavv_chung(ngayvv.Text,s_mabn,l_maql,c_lydo.Text,c_hb_benhly.Text,c_hb_banthan.Text,c_hb_giadinh.Text,c_kb_toanthan.Text,c_kb_bophan.Text,c_kb_tomtat.Text,c_kb_xuli.Text,c_kb_chuy.Text,sobo.Text,phanbiet.Text,i_userid);
            m.upd_bavv_tmh(ngayvv.Text, l_maql, c_kb_tai.Text, c_kb_mui.Text, c_kb_hong.Text, "");
            m.upd_bavv_dausinhton(ngayvv.Text, s_mabn, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "" && nhietdo.Text.Trim() != ".") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0);
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Phongluu,l_maql);
			decimal l_id=m.get_id(l_maql,makp_pl,ngayvv.Text);
			if (i_maba==0) i_maba=24;
            //if (!m.upd_nhapkhoa(l_id,s_mabn,l_maql,makp_pl,i_maba,ngayvv.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),"","01",cd_chinh.Text,icd_chinh.Text,mabs.Text,1,i_userid))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
            //    return;
            //}
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}
			
			if (cd_noichuyenden.Text!="" || madstt.Text!="")
			{
				if (!m.upd_noigioithieu(l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (pmat.Visible) m.upd_ttmat(l_maql,mp.Text,mt.Text,nhanapp.Text,nhanapt.Text);
		}

		private void upd_noitru(string so)
		{
			l_maql=m.get_maql(1,s_mabn,khoa.Text,ngayvv.Text,true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            //Tu:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu
			if (!m.upd_benhandt(s_mabn,l_maql,khoa.Text,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),1,int.Parse(tendoituong.SelectedValue.ToString()),cd_chinh.Text,icd_chinh.Text,mabs.Text,(b_sovaovien)?"":sovaovien.Text,1,i_userid,true,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			m.upd_bavv_chung(ngayvv.Text,s_mabn,l_maql,c_lydo.Text,c_hb_benhly.Text,c_hb_banthan.Text,c_hb_giadinh.Text,c_kb_toanthan.Text,c_kb_bophan.Text,c_kb_tomtat.Text,c_kb_xuli.Text,c_kb_chuy.Text,sobo.Text,phanbiet.Text,i_userid);
			m.upd_bavv_dausinhton(ngayvv.Text,s_mabn,l_maql,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!=""&&nhietdo.Text.Trim()!=".")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?decimal.Parse(cannang.Text):0);
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}
			if (cd_noichuyenden.Text!="")
			{
				if (!m.upd_noigioithieu(l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			else m.execute_data("delete from "+xxx+".cdkemtheo where stt=1 and loai=1 and maql="+l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Nhanbenh,l_maql);
			m.execute_data("delete from "+user+".hienhien where nhapkhoa=0 and xuatkhoa=0 and mabn='" + s_mabn + "' and makp<>'" + khoa.Text + "'");
			decimal tmpid=m.get_id_hiendien_do_cdvv(s_mabn,l_maql,"01");
			decimal l_idhiendien=(tmpid==0)?m.get_id(l_maql,khoa.Text,ngayvv.Text):tmpid;//tinh them gio
			m.upd_hiendien(l_idhiendien,s_mabn,l_maql,khoa.Text,ngayvv.Text,"01",0,0);
		}

		private void upd_ngoaitru(string so)
		{
			//l_maql=m.get_maql(2,s_mabn,khoa.Text,ngayvv.Text,true);
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvv.Text, true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            //Tu:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu

			//if (!m.upd_benhanngtr(s_mabn,l_mavaovien,l_maql,makp.Text,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),1,int.Parse(tendoituong.SelectedValue.ToString()),cd_chinh.Text,icd_chinh.Text,mabs.Text,sovaovien.Text,2,i_userid,true,l_maql))
            if (!m.upd_benhanngtr(s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, sovaovien.Text, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
            //Tu:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".benhanngtr set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end Tu

			m.upd_bavv_chung(ngayvv.Text,s_mabn,l_maql,c_lydo.Text,c_hb_benhly.Text,c_hb_banthan.Text,c_hb_giadinh.Text,c_kb_toanthan.Text,c_kb_bophan.Text,c_kb_tomtat.Text,c_kb_xuli.Text,c_kb_chuy.Text,sobo.Text,phanbiet.Text,i_userid);
			m.upd_bavv_dausinhton(ngayvv.Text,s_mabn,l_maql,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!=""&&nhietdo.Text.Trim()!=".")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?decimal.Parse(cannang.Text):0);
			decimal l_id=m.get_id(l_maql,khoa.Text,ngayvv.Text);
            //if (!m.upd_nhapkhoa(l_id,s_mabn,l_maql,khoa.Text,i_bangoaitru,ngayvv.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),"","01",cd_chinh.Text,icd_chinh.Text,mabs.Text,1,i_userid))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
            //    return;
            //}
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}
			
			if (cd_noichuyenden.Text!="")
			{
				if (!m.upd_noigioithieu(l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Ngoaitru,l_maql);
		}

		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butIn.Enabled=!ena;
			butIncv.Enabled=!ena;
			//butChiphi.Enabled=!ena;
			ngayvv.Enabled=ena;
			c_lydo.Enabled=ena;
			c_hb_benhly.Enabled=ena;
            //linh
			//c_hb_banthan.Enabled=ena;
            c_hb_banthan.ReadOnly = !ena;
            c_kb_tai.Enabled = ena;
            c_kb_mui.Enabled = ena;
            c_kb_hong.Enabled = ena;
            //end linh
			c_hb_giadinh.Enabled=ena;
			c_kb_toanthan.Enabled=ena;
			c_kb_bophan.Enabled=ena;
			c_kb_tomtat.Enabled=ena;
			c_kb_xuli.Enabled=ena;
			c_kb_chuy.Enabled=ena;
			sobo.Enabled=ena;
			phanbiet.Enabled=ena;
            //linh
            //mach.Enabled=ena;
            //nhietdo.Enabled=ena;
            //huyetap.Enabled=ena;
            //nhiptho.Enabled=ena;
            //cannang.Enabled=ena;
            //chieucao.Enabled = ena;
            //end
			dentu.Enabled=ena;
			nhantu.Enabled=ena;
			icd_chinh.Enabled=ena;
			cd_chinh.Enabled=ena;
			xutri.Enabled=ena;
            label42.Enabled = label46.Enabled = label69.Enabled = label70.Enabled = ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			//butTiep_Click(null,null);
			ena_but(false);
			butTiep.Focus();
		}

		private void nhantu_TextChanged(object sender, System.EventArgs e)
		{
			nhantu.Text=nhantu.Text;
		}

		private void ngayvv_Validated(object sender, System.EventArgs e)
		{
			if (ngayvv.Text=="")
			{
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=ngayvv.Text.Trim();
			if (ngayvv.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ khám bệnh !"),s_msg);
				ngayvv.Focus();
				return;
			}
			if (!m.bNgay(ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=m.Ktngaygio(ngayvv.Text,16);
            if (ngayvv.Text!=s_ngayvv)
			{
				if (bTudong)
				{
					DataRow r=m.getrowbyid(dtletet,"ngay='"+ngayvv.Text.Substring(0,5)+"'");
					bool bLetet=r!=null;
					hh1=int.Parse(ngayvv.Text.Substring(11,2));
					mm1=int.Parse(ngayvv.Text.Substring(14,2));
					DateTime dtime=m.StringToDate(ngayvv.Text.Substring(0,10));
					string ddd=dtime.DayOfWeek.ToString().Substring(0,3);
					if (bLetet || ddd=="Sat" || ddd=="Sun" || hh1>hh2 || (hh1==hh2 && mm1>mm2) || hh1<hh3 || (hh1==hh3 && mm1<mm3)) loai.SelectedValue="1";
					else loai.SelectedValue="0";
				}
				ref_check();
				if (tuoi.Text!="")
				{
					if (namsinh.Text!=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString())
					{
						tuoi.Text=Convert.ToString(int.Parse(ngayvv.Text.Substring(6,4))-int.Parse(namsinh.Text)).PadLeft(3,'0');
						loaituoi.SelectedIndex=0;
					}
				}
				string s=ngayvv.Text;
				s_mabn=mabn2.Text+mabn3.Text;
				if (!bTiepdon)
				{
					if (m.get_tiepdon(s_mabn,ngayvv.Text)==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"),s_msg);
						butBoqua_Click(sender,e);
						return; 
					}
				}
				l_maql=m.get_maql_mmyy(3,s_mabn,"??",ngayvv.Text,false);
				bNew=l_maql==0;
				if (l_maql!=0)
				{
					load_vv_maql(true);
					ngayvv.Text=s;
				}
				else
				{
					if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0,10)),DateTime.Now,songay))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày khám bệnh không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
						ngayvv.Focus();
						s_ngayvv="";
						return;
					}
					if (ngayvv.Text.Substring(0,10)==m.Ngayhienhanh)
					{
						string m_ngay=m.get_ngaytiepdon(s_mabn,ngayvv.Text);
						if (m_ngay!="")
						{
							if (!m.bNgaygio(ngayvv.Text,m_ngay))
							{
								MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(")+m_ngay+")",s_msg);
								ngayvv.Focus();
								return;
							}
						}
					}
					if (!makp.Enabled && makp.Text!="")
					{
						if (!load_phongkham()) return;
					}
					emp_vv();
					emp_bhyt();
					emp_rv();
					ngayvv.Text=s;
					if (ngayvv.Text!="") load_tiepdon(ngayvv.Text.Substring(0,10),false);
					if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
					else if (soluutru.Text=="" && b_sovaovien) soluutru.Text=sovaovien.Text;
					l_maql=0;
					if (!bSuadoituong) 
					{
						madoituong.Enabled=false;
						tendoituong.Enabled=false;
					}
				}
				s_ngayvv=ngayvv.Text;
			}
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
			TreeNode node;
			if (nam == "") return;
			foreach(DataRow r in m.get_data_nam(nam,"select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,chandoan,to_char(ngay,'yyyymmddhh24mi') as yymmdd from xxx.benhanpk where mangtr=0 and mabn='"+s_mabn+"'").Tables[0].Select("true","yymmdd desc"))
			{
				node=treeView1.Nodes.Add(r["ngay"].ToString());
				node.Nodes.Add(r["chandoan"].ToString());
			}
			//treeView1.ExpandAll();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse || e.Action==TreeViewAction.ByKeyboard)
			{
				try
				{
					emp_vv();emp_rv();
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					string ngay=s.Substring(iPos-2,16);
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql_mmyy(3,s_mabn,"??",ngay,false);
					
					bNew=l_maql==0;
					if (l_maql!=0)
					{
                        butLuu.Tag = l_maql.ToString();
						ngayvv.Text=ngay;
						load_vv_maql(true);
					}
				}
				catch{}
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
				if (b_bacsi)
				{
					dtbs=m.get_data("select * from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") and mapk='"+makp.Text+"'"+" order by ma").Tables[0];
					if (dtbs.Rows.Count==0)
                        dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				}
                else dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				listBS.DataSource=dtbs;
			}
			catch{makp.Text="";}
		}

		private void giaiphau_CheckStateChanged(object sender, System.EventArgs e)
		{
			gphaubenh.Visible=giaiphau.Checked;
		}

		private void taibien_CheckStateChanged(object sender, System.EventArgs e)
		{
			cmbTaibien.Visible=taibien.Checked;
		}

		private void Filt_dstt(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[listdstt.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
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
			treeView1.Visible=false;
			Filt_dstt(tendstt.Text);
			listdstt.BrowseToText(tendstt,madstt,makp,madstt.Location.X,madstt.Location.Y+madstt.Height,madstt.Width+tendstt.Width+2,madstt.Height);
		}

		private void listdstt_Validated(object sender, System.EventArgs e)
		{
			treeView1.Visible=true;
		}

		private void tendstt_Validated(object sender, System.EventArgs e)
		{
			if(!listdstt.Focused)
			{
				listdstt.Hide();
				treeView1.Visible=true;
			}
		}

		private void load_btdnn(int i)
		{
            if (i == 0) tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
                        tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
                        tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void cd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_noichuyenden)
			{
				if (bChandoan || icd_noichuyenden.Text=="")
				{
					Filt_ICD(cd_noichuyenden.Text);
					listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,(khamthai.Visible)?para1:c_lydo,icd_chinh.Location.X,icd_noichuyenden.Location.Y+icd_noichuyenden.Height,icd_noichuyenden.Width+cd_noichuyenden.Width+2,icd_noichuyenden.Height);
				}
			}
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
				if (bChandoan || icd_chinh.Text=="")
				{
					Filt_ICD(cd_chinh.Text);
					listICD.BrowseToICD10(cd_chinh,icd_chinh,c_kb_xuli,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
				}
			}
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void cd_kkb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Escape)
			{
				mabn2.Focus();
                this.danhsach.Location = new Point(0, panHanhchanh.Top);
                this.danhsach.Size = new Size(148, panMenu.Top);
			}
			else if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) gan_mabn();
		}

		private void gan_mabn()
		{
            try
            {
                s_mabn = "";
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                if (r1 != null) s_mabn = r1["mabn"].ToString();
                if (s_mabn != "")
                {
                    mabn2.Text = s_mabn.Substring(0, 2);
                    mabn3.Text = s_mabn.Substring(2);
                    //linh
                    mabn3_Validated(null, null);
                    //string ngaysrv = m.ngayhienhanh_server, zzz = user + m.mmyy(ngaysrv), s = "";
                    //sql = "select maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,mavaovien from " + xxx + ".benhanpk where mabn='" + s_mabn + "' and (chandoan is null or chandoan='') and to_char(ngay,'dd/mm/yyyy')='" + ngaysrv.Substring(0, 10) + "'";
                    //if (s_makp != "")
                    //{
                    //    s = s_makp.Replace(",", "','");
                    //    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    //    sql += " and makp in ('" + s + "')";
                    //}
                    //s = "";
                    //foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    //{
                    //    l_maql = decimal.Parse(r["maql"].ToString());
                    //    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    //    ngayvv.Text = r["ngay"].ToString();
                    //    s_ngayvv = ngayvv.Text;
                    //    s = s_ngayvv;
                    //    break;
                    //}
                    //cảnh baó lý do khám  là tái khám sớm hoặc không đáp ứng điều trị
                    //DataSet ds_ld = m.get_data("select id_lydokham from " + xxx + ".lydokham where maql=" + l_maql + "");
                    //string s_lydokham = "", s_tenlydo = "";
                    //if (ds_ld.Tables[0].Rows.Count > 0) s_lydokham = ds_ld.Tables[0].Rows[0][0].ToString();
                    //foreach (string st in s_lydokham.Split('+'))
                    //{
                    //    foreach (DataRow r in ds_lydo.Tables[0].Rows)
                    //    {
                    //        if (st.Trim() == r["id"].ToString().Trim())
                    //        {
                    //            s_tenlydo = r["ten"].ToString();
                    //            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân") + " " + s_tenlydo);
                    //            break;
                    //        }
                    //    }
                    //}
                    //end

                    //if (s != "")
                    //{
                    //    load_vv_maql(true);
                    //    ngayvv.Text = s;
                    //}
                    //else ngayvv_Validated(null, null);
                    //if (!ngayvv.Enabled) c_lydo.Focus();
                    //end linh
                }
                else
                {
                    //danhsach.Visible=false;
                    mabn2.Focus();
                }
            }
            catch { }//danhsach.Visible=false;}
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			load_ref();
			list.Focus();
		}

		private void load_ref()
		{
			mmyy=m.mmyy(m.Ngayhienhanh);
			list.DataSource=null;
			if (!m.bMmyy(mmyy)) return;
            sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten, ";//a.done
            sql += " (case when a.done='?' then 'Chờ KQ CLS' else(case when a.done='d' then 'Đã có KQ CLS' else(case when a.done='x' then 'Đã khám' else 'Chờ khám' end ) end) end) as done ";
            sql += ",a.maql as stt, ";//,rownum as stt
            sql += "case when a.noitiepdon=16 then 'Tái khám' else '' end as taikham ";
            sql += " from " + user + mmyy + ".tiepdon a," + m.user + ".btdbn b ";
			sql+=" where a.mabn=b.mabn and (a.done is null or a.done='?' ";
            if (!m.bThuphi_kham)
                sql += "or a.done='c' ";
            sql += ") ";
            sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+m.Ngayhienhanh.Substring(0,10)+"'";
			sql+=" and a.noitiepdon in (0,1,5,16)";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
                if(s.Length>3)s=s.Substring(0,s.Length-3);
				sql+=" and a.makp in ('"+s+"')";
			}
			//if (bStt) sql+=" order by to_number(a.sovaovien,'0000000000'),a.ngay,a.makp";
            if (bStt) sql += " order by a.sovaovien,a.ngay,a.makp";
			else sql+=" order by a.ngay,a.makp";
			dtlist=m.get_data(sql).Tables[0];
			list.DataSource=dtlist;
			danhsach.Text="DANH SÁCH ĐĂNG KÝ ("+list.Items.Count.ToString()+")";

            //xuất ra màn hình LCD
            if (chkLCD.Checked)
            {
                sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,a.done,a.maql as stt,";
                sql += " case when a.noitiepdon=16 then 'x' else 'y' end as tk, ";
                sql += " b.hoten as ten,to_char(sysdate,'yyyy')-b.namsinh as tuoi ";//,a.kham
                sql += " from " +user + mmyy + ".tiepdon a," + user + ".btdbn b ";
                //sql += " where a.mabn=b.mabn and a.done is null ";
                sql += " where a.mabn=b.mabn and (a.done is null or a.done='?' ";
                if (!m.bThuphi_kham)
                    sql += "or a.done='c' ";
                sql += ") ";
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + m.Ngayhienhanh.Substring(0, 10) + "' ";
                sql += " and a.noitiepdon in (0,1,5,16)";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    sql += " and a.makp in ('" + s + "')";
                }
                if (bStt)
                {
                    sql += " and a.sovaovien is not null";
                    sql += " order by to_number(a.sovaovien,'0000000000'),a.ngay,a.makp";
                }
                else sql += " order by a.ngay,a.makp";
                //if (flcd == null)
                //{
                    flcd = new frmOutput2(m, s_makp,s_mabn);
                    flcd.setSQL = sql;
                    flcd.Show();
                //}
                //else
                //{
                //    flcd.setSQL = sql;
                //    flcd.Show();
                //}
            }
            //end LCD
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			gan_mabn();
            //xuất ra màn hình LCD
            if (chkLCD.Checked)
            {
                sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,a.done,a.maql as stt,";
                sql += " case when a.noitiepdon=16 then 'x' else 'y' end as tk, ";
                sql += " b.hoten as ten,to_char(sysdate,'yyyy')-b.namsinh as tuoi ";//,a.kham
                sql += " from " + user + mmyy + ".tiepdon a," + user + ".btdbn b ";
                //sql += " where a.mabn=b.mabn and a.done is null ";
                sql += " where a.mabn=b.mabn and (a.done is null or a.done='?' ";
                if (!m.bThuphi_kham)
                {
                    sql += "or a.done='c' ";
                }
                sql += ") ";
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + m.Ngayhienhanh.Substring(0, 10) + "' ";
                sql += " and a.noitiepdon in (0,1,5,16)";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    sql += " and a.makp in ('" + s + "')";
                }
                if (bStt)
                {
                    sql += " and a.sovaovien is not null";
                    sql += " order by to_number(a.sovaovien,'0000000000'),a.ngay,a.makp";
                }
                else sql += " order by a.ngay,a.makp";
                //if (flcd == null)
                //{
                    flcd = new frmOutput2(m, s_makp,s_mabn);
                    flcd.setSQL = sql;
                    flcd.Show();
                //}
                //else
                //{
                //    flcd.setSQL = sql;
                //    flcd.Show();
                //}
            }
            //end LCD
            //
            this.danhsach.Location = new Point(0, panHanhchanh.Top);
            this.danhsach.Size = new Size(148, panMenu.Top);//148
		}

		private bool kiemtra(int loai)
		{
			string s="";
			foreach(DataRow r in m.get_data("select madoituong from "+user+".d_dmphieu where id="+loai).Tables[0].Rows) 
				s=r["madoituong"].ToString().Trim();
			if (s!="")
			{
                if (m.get_data("select * from " + user + ".d_dmphieu where id=" + loai + " and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Đối tượng \n"+tendoituong.Text+"\nKhông được cấp thuốc !"),LibMedi.AccessData.Msg);
					return false;
				}
			}
			return true;
		}

		private void soluutru_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (mabn3.Text=="" && soluutru.Text!="" && nam!="")
				{
					//DataTable dt=m.get_data_nam_dec(nam,"select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay from xxx.benhandt a,xxx.xuatvien b where a.maql=b.maql and b.soluutru='"+soluutru.Text+"'"+" order by a.maql").Tables[0];
                    DataTable dt = m.get_data_nam_dec(nam, "select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay from xxx.benhanpk a,"+user+".xuatvien b where a.maql=b.maql and b.soluutru='" + soluutru.Text + "'" + " order by a.maql").Tables[0];
					if (dt.Rows.Count>0)
					{
						s_mabn=dt.Rows[0]["mabn"].ToString();
						ngayvv.Text=dt.Rows[0]["ngay"].ToString();
						mabn2.Text=s_mabn.Substring(0,2);
						mabn3.Text=s_mabn.Substring(2);
						load_mabn();
						ngayvv_Validated(sender,e);
					}
				}
			}
			catch{}
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
                listBS.BrowseToICD10(tenbs, mabs, makp, mabs.Location.X +mabs.Width, mabs.Location.Y + mabs.Height*2, mabs.Width + tenkp.Width + 2, mabs.Height);//+mabs.Height
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

		private void khoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void tenkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkhoa.Items.Count>0 && tenkhoa.SelectedIndex==-1) tenkhoa.SelectedIndex=0;
				khoa.Text=tenkhoa.SelectedValue.ToString();
				SendKeys.Send("{Tab}");
			}
		}

		private void tenkhoa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkhoa)
			{
				khoa.Text=tenkhoa.SelectedValue.ToString();
			}
		}

		private void l_tuvong_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			if (l_maql!=0 && tenkp.Items.Count==1)
			{
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a,"+user+".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
				if (tmp.Rows.Count>0)
				{
					if (tmp.Rows[0]["makp"].ToString()!=makp.Text)
					{
						MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ")+tmp.Rows[0]["tenkp"].ToString()+lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"),LibMedi.AccessData.Msg);
						butBoqua.Focus();
						return;
					}
				}
			}
			l_maql=m.get_maql_mmyy(3,s_mabn,makp.Text,ngayvv.Text,false);
			if (l_maql==0)
			{
				butLuu_Click(sender,e);
				if (!bExit) return;
				ena_but(false);
			}
            //tu
            frmBienbantuvong f = new frmBienbantuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayvv.Text, sonha.Text + ", " + thon.Text + ", " + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, l_maql, i_userid, i_chinhanh, s_makp, phai.SelectedIndex);
			f.ShowDialog();
            //end tu
		}

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				xutri_SelectedIndexChanged(sender,e);
				SendKeys.Send("{Tab}");
			}
		}

        private void xutri_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            s_chonxutri = chon_xutri();
            hen.Visible = (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen);
            loaibv.Enabled = (s_chonxutri.IndexOf("06,") != -1);
            tenloaibv.Enabled = loaibv.Enabled;
            mabv.Enabled = loaibv.Enabled;
            //linh
            //tenbv.Enabled = loaibv.Enabled;
            txtTenbv.Enabled = loaibv.Enabled;
            //if (tenbv.Enabled) load_mabv(loaibv.Text);
            //else 
            if (!txtTenbv.Enabled) loaibv.Text = tenloaibv.Text = mabv.Text = tenbv.Text = txtTenbv.Text = "";
            khoa.Enabled = (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("08,") != -1);
            //end linh
            if (khoa.Enabled)
            {
                sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                else if (s_chonxutri.IndexOf("02,") != -1) sql += " and (maba like '%20%' or maba like '%21%' or maba like '%22%' or maba like '%23%')";
                sql += " order by makp";
                tenkhoa.DataSource = m.get_data(sql).Tables[0];
                if (tenkhoa.SelectedIndex != -1) khoa.Text = tenkhoa.SelectedValue.ToString();
            }
            tenkhoa.Enabled = khoa.Enabled;
            //linh
            if (s_chonxutri.IndexOf("08,") != -1)// chuyển viện
            {
                lblKhoaphong.Text = "6. Chuyển vào phòng khám :";
            }
            else
            {
                lblKhoaphong.Text = "6. Cho vào điều trị tại khoa :";
            }
            string s_vp = "";
            if (s_chonxutri.IndexOf("07,") != -1)
            {
                s_vp = m.sKtKetquaCLS(s_mabn, decimal.Parse(l_mavaovien.ToString()), ngayvv.Text, ngayvv.Text);
                if (s_vp != "")
                {
                    s_chonxutri = s_chonxutri.Replace("07,", "");
                    maxutri.Text = s_chonxutri;
                    maxutri_Validated(null, null);
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân tử vong phải có kết quả của " + s_vp), s_msg);
                    return;
                }
                else
                {
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count == 0)
                    {
                        s_chonxutri = "07,";
                        maxutri.Text = s_chonxutri;
                        maxutri_Validated(null, null);
                        l_tuvong_Click(null, null);
                        return;
                    }
                }
            }
            //linh
            if (s_chonxutri.IndexOf("06,") != -1)// chuyển viện
            {
                if (dtdmbenhvien == null)
                {
                    dtdmbenhvien = m.get_data("select mabv,tenbv,mahang,ngoaidm,maloai from " + user + ".tenvien where mabv<>'" + s_mabv + "'").Tables[0];
                    listBenhvien.DisplayMember = "MABV";
                    listBenhvien.ValueMember = "TENBV";
                    listBenhvien.DataSource = dtdmbenhvien;
                }
                if (mabv.Text == "" && txtTenbv.Text == "")
                {
                    mabv.Focus();
                    return;
                }
            }
            if (s_chonxutri.IndexOf("01,") != -1 && xutri.SelectedValue.ToString() == "1")// cấp toa
            {
                if (tendoituong.SelectedValue.ToString() == "1")
                {
                    but_thuocbhyt_Click(null, null);
                }
                else
                {
                    but_thuocdan_Click(null, null);
                }
                if (!bExit)
                {
                    s_chonxutri = s_chonxutri.Replace("01,", "");
                    maxutri.Text = s_chonxutri;
                    maxutri_Validated(null, null);
                }
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            s_mabn = mabn2.Text + mabn3.Text;
            mmyy = v.mmyy(ngayvv.Text);
            if (s_mabn == "" || ngayvv.Text == "" || !m.bMmyy(mmyy)) return;
            string c01 = "", c02 = "", c03 = "", c04 = "", c05 = "", tenfile = "r42bv_tmh";
            //sql="select b.ten from v_chidinh a,"+user+".v_giavp b where a.mavp=b.id and a.mabn='"+s_mabn+"' and to_char(a.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"' and a.maql="+l_maql;
            //TU:28/03/2011
            sql = "select b.ten from " + user + mmyy + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and a.maql=" + l_maql;
            int j = 1;
            foreach (DataRow r in v.get_data(sql).Tables[0].Rows)
            {
                c01 = c01 + j.ToString().Trim() + ". " + r["ten"].ToString().Trim() + "\n";
                j++;
            }
            j = 1;
            //sql="select 0 as loai,b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,b.slyeucau as soluong,b.cachdung from d_thuocbhytll a,d_thuocbhytct b,"+user+".d_dmbd c";
            //TU:28/03/2011
            sql = "select 0 as loai,b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,b.slyeucau as soluong,b.cachdung from " + user + mmyy + ".d_thuocbhytll a," + user + mmyy + ".d_thuocbhytct b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and a.maql=" + l_maql;
            foreach (DataRow r in v.get_data(sql).Tables[0].Select("true", "loai,stt"))
            {
                c02 = c02 + j.ToString().Trim() + ". " + r["ten"].ToString().Trim() + "\n";
                c03 += r["soluong"].ToString().Trim() + "\n";
                c04 += r["dang"].ToString().Trim() + "\n";
                c05 += r["cachdung"].ToString().Trim() + "\n";
                j++;
            }
            DataRow r1;
            DataSet ds = m.get_data("select a.*,b.mach,b.nhietdo,b.huyetap,b.nhiptho,b.cannang,b.chieucao,'' as c01,'' as c02,'' as c03,'' as c04,'' as c05 from " + xxx + ".bavv_chung a," + xxx + ".bavv_dausinhton b where a.maql=b.maql and a.maql=" + l_maql);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataColumn dc = new DataColumn("Image", typeof(byte[]));
                ds.Tables[0].Columns.Add(dc);
                r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                bool bFile = r1 != null;
                if (bFile)
                {
                    try
                    {
                        image = new byte[0];
                        image = (byte[])(r1["image"]);
                    }
                    catch { }
                }
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["c01"] = c01; r["c02"] = c02;
                    r["c03"] = c03; r["c04"] = c04; r["c05"] = c05;
                    if (bFile) r["image"] = image;
                }
                ds.WriteXml("khambenh_tmh.xml", XmlWriteMode.WriteSchema);
                string s_chinhanh = "";
                if (i_chinhanh != 0) s_chinhanh = m.get_data("select viettat from " + user + ".dmchinhanh where id=" + i_chinhanh + "").Tables[0].Rows[0]["viettat"].ToString();
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds, tenfile, "", tenkp.Text, tenbs.Text.Trim().ToUpper(), "", m.Mabv + "/" + mabn2.Text + "/" + mabn3.Text, hoten.Text, ngaysinh.Text, (loaituoi.SelectedIndex == 0) ? tuoi.Text.Substring(1) : "000", phai.SelectedIndex.ToString(),
                    tennn.Text, mann.Text, tendantoc.Text, madantoc.Text, (tennuoc.Enabled) ? tennuoc.Text : "", (tennuoc.Enabled) ? tennuoc.SelectedValue.ToString() : "", sonha.Text, thon.Text, tenpxa.Text, tenquan.Text, maqu2.Text, tentinh.Text, matt.Text, cholam.Text, madoituong.Text,
                    denngay.Text, sothe.Text, qh_hoten.Text + "      +Địa chỉ: " + qh_diachi.Text, qh_dienthoai.Text, "", ngayvv.Text, tennhantu.Text, tendentu.Text, "1", tenkhoa.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                    cd_noichuyenden.Text, m.Maicd_rpt(icd_noichuyenden.Text), cd_chinh.Text, m.Maicd_rpt(icd_chinh.Text), "", "", "0", "0", cd_chinh.Text, m.Maicd_rpt(icd_chinh.Text), phanbiet.Text, icd_kemtheo.Text, (taibien.Checked) ? "1" : "0",
                    (bienchung.Checked) ? "1" : "0", "", (giaiphau.Checked) ? gphaubenh.SelectedValue.ToString() : "0", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "0", "", "", "", "", "", "", "", "", "", "", s_chinhanh, mabn2.Text + mabn3.Text, c_kb_bophan.Text, c_kb_tai.Text, c_kb_mui.Text, c_kb_hong.Text);
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
		}

		private void luu()
		{
			bExit=kiemtra();
			if (!bExit) return;
			xxx=user+m.mmyy(ngayvv.Text);
			if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			l_maql=m.get_maql_mmyy(3,s_mabn,makp.Text,ngayvv.Text,true);
			if (!m.upd_lienhe(ngayvv.Text,l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (!m.upd_benhandt_mmyy(s_mabn,l_maql,makp.Text,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),1,int.Parse(tendoituong.SelectedValue.ToString()),cd_chinh.Text,icd_chinh.Text,mabs.Text,sovaovien.Text,3,i_userid,true,0,l_mavaovien))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			m.upd_bavv_chung(ngayvv.Text,s_mabn,l_maql,c_lydo.Text,c_hb_benhly.Text,c_hb_banthan.Text,c_hb_giadinh.Text,c_kb_toanthan.Text,c_kb_bophan.Text,c_kb_tomtat.Text,c_kb_xuli.Text,c_kb_chuy.Text,sobo.Text,phanbiet.Text,i_userid);
			m.upd_bavv_dausinhton(ngayvv.Text,s_mabn,l_maql,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!=""&&nhietdo.Text.Trim()!=".")?decimal.Parse(nhietdo.Text):0,huyetap.Text,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?decimal.Parse(cannang.Text):0);
			l_matd=m.get_tiepdon(s_mabn,ngayvv.Text);
			if (bTiepdon)
			{
				if (l_matd==0)
				{
					l_matd=m.getidyymmddhhmiss_stt_computer;//get_capid(1);
					m.upd_tiepdon_mmyy(s_mabn,l_matd,makp.Text,ngayvv.Text,int.Parse(madoituong.Text),sovaovien.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,i_userid,LibMedi.AccessData.Khambenh,0,l_matd);
				}
			}
			m.upd_sukien(ngayvv.Text,s_mabn,l_matd,LibMedi.AccessData.Khambenh,l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
		}

		private void load_kemtheo()
		{
			if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
			bool b_kemtheo=m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".cdkemtheo where stt>1 and loai=4 and id="+l_maql).Tables[0].Rows.Count!=0;
            butkemtheo.ForeColor = (b_kemtheo) ? Color.FromArgb(255, 0, 0) : System.Drawing.SystemColors.Desktop;
		}

		private void maxutri_Validated(object sender, System.EventArgs e)
		{
			s_chonxutri=maxutri.Text.Trim();
            if (s_chonxutri != "")
            {
                if (s_chonxutri.Substring(s_chonxutri.Length) != ",") s_chonxutri += ",";
                for (int i = 0; i < xutri.Items.Count; i++) xutri.SetItemCheckState(i, CheckState.Unchecked);
                for (int i = 0; i <= xutri.Items.Count; i++)
                    if (s_chonxutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                hen.Visible = (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen);
                loaibv.Enabled = (s_chonxutri.IndexOf("06,") != -1);
                tenloaibv.Enabled = loaibv.Enabled;
                mabv.Enabled = loaibv.Enabled;
                tenbv.Enabled = loaibv.Enabled;
                khoa.Enabled = (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("08,") != -1);
                if (khoa.Enabled)
                {
                    sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                    if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                    if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                    else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                    else if (s_chonxutri.IndexOf("02,") != -1) sql += " and (maba like '%20%' or maba like '%21%' or maba like '%22%' or maba like '%23%')";
                    sql += " order by makp";
                    tenkhoa.DataSource = m.get_data(sql).Tables[0];
                    this.lblKhoaphong.Text = (s_chonxutri.IndexOf("08,") != -1) ? lan.Change_language_MessageText("6. Chuyển vào phòng khám") + ": " : lan.Change_language_MessageText("6. Cho vào điều trị tại khoa") + ": ";
                }
                tenkhoa.Enabled = khoa.Enabled;
                SendKeys.Send("{Tab}");
            }
            else
            {
                for (int j = 0; j < xutri.Items.Count; j++)
                {
                    xutri.SetItemChecked(j, false);
                }
                xutri.Refresh();
            }
		}

        private void para1_Validated(object sender, System.EventArgs e)
		{
			para1.Text=para1.Text.PadLeft(2,'0');
			if (para1.Text=="99")
			{
				para2.Text=para1.Text;
				para3.Text=para1.Text;
				para4.Text=para1.Text;
				madoituong.Focus();
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
		private void phai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (bKhamthai) khamthai.Visible=phai.SelectedIndex==1;		
		}

		private void kinhcc_Validated(object sender, System.EventArgs e)
		{
			if (kinhcc.Text=="")
			{
				madoituong.Focus();
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
				MessageBox.Show(lan.Change_language_MessageText("Ngày sang dự đoán không hợp lệ !"));
				ngaysanh.Focus();
				return;
			}
			ngaysanh.Text=m.Ktngaygio(ngaysanh.Text,10);
		}

		private void l_lichhen_Click(object sender, System.EventArgs e)
		{
			
		}

		private bool load_phongkham()
		{
			l_maql=m.get_maql_ngay(3,s_mabn,makp.Text,ngayvv.Text);
			bNew=l_maql==0;
			if (l_maql!=0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {")+tenkp.Text.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Bạn có muốn xem lại !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
					load_vv_maql(false);
					s_ngayvv=ngayvv.Text;
					return false;
				}
			}
			if (!b701306 && l_matd!=0) sovaovien.Focus();
			return true;
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1 && loai.Items.Count>0) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void bnmoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (bnmoi.SelectedIndex==-1) bnmoi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

		private void sovaovien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIncv_Click(object sender, System.EventArgs e)
		{
            //linh
            mabv_Validated(null, e);
            //if (m.bChuyenvien_ngoaids_duyet)
            //{
            //    //Kiểm tra bệnh viện chuyển đi có nằm trong danh mục hepa ko?
            //    int i_cungtuyen = 0;
            //    DataSet ds_tenvien = m.get_data("select cungtuyen from " + user + ".tenvien where mabv='" + mabv.Text.Trim() + "'");
            //    if (ds_tenvien != null && ds_tenvien.Tables[0].Rows.Count > 0)
            //        i_cungtuyen = int.Parse(ds_tenvien.Tables[0].Rows[0][0].ToString());
            //    //end
            //    if (i_cungtuyen == 0)//không cùng tuyến của hepa
            //    {
            //        frmGiaycv fcv = new frmGiaycv(m, s_makp, i_userid, s_mabn, 3, 0);
            //        fcv.ShowDialog();
            //    }
            //}
            //else
            //{
            //    if (tenbv.SelectedIndex != -1 && ngayvv.Text != "")
            //    {
            //        string noidkkcb = "";
            //        foreach (DataRow r in m.get_data("select b.tenbv from " + user + m.mmyy(ngayvv.Text) + ".bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.maql=" + l_maql).Tables[0].Rows)
            //        {
            //            noidkkcb = r["tenbv"].ToString();
            //            break;
            //        }
            //        DataSet dsxml = new DataSet();
            //        dsxml.ReadXml("..\\..\\..\\xml\\m_giaycv.xml");
            //        DataRow r1 = dsxml.Tables[0].NewRow();
            //        r1["tenbv"] = tenbv.Text;
            //        r1["mabn"] = mabn2.Text + mabn3.Text;
            //        r1["hoten"] = hoten.Text;
            //        r1["namsinh"] = namsinh.Text;
            //        r1["phai"] = phai.Text;
            //        r1["dantoc"] = tendantoc.Text;
            //        r1["tennn"] = tennn.Text;
            //        r1["doituong"] = tendoituong.Text;
            //        r1["denngay"] = denngay.Text;
            //        r1["sothe"] = sothe.Text;
            //        r1["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim();
            //        r1["noilamviec"] = cholam.Text;
            //        r1["chandoan"] = cd_chinh.Text;
            //        r1["maicd"] = icd_chinh.Text;
            //        r1["tenkp"] = tenkp.Text;
            //        r1["tenbs"] = tenbs.Text;
            //        r1["ngayvao"] = ngayvv.Text;
            //        r1["ngayra"] = ngayvv.Text;
            //        r1["noidkkcb"] = noidkkcb;
            //        r1["noigioithieu"] = tendstt.Text;
            //        dsxml.Tables[0].Rows.Add(r1);
            //        dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, tenbv.Text, "rptGiaycv.rpt");
            //        f.ShowDialog();
            //    }
            //}
            //end
		}

		private void l_tonkho_Click(object sender, System.EventArgs e)
		{
			
		}

		private void icd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

		private void icd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

		private void icd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

		private void hen_ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void hen_butin_Click(object sender, System.EventArgs e)
		{
			if (ngayvv.Text!="")
			{
				dsdt=new DataSet();
				dsdt.ReadXml("..\\..\\..\\xml\\m_phieudieutri.xml");
				dsdt.Clear();
				decimal maql1;
				DataRow r;
				string ngay,noidkkcb="",so,s_sovaovien="";
				if (s_noicap!="")
					foreach(DataRow r1 in m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+s_noicap+"'").Tables[0].Rows)
						noidkkcb=r1["tenbv"].ToString();
				DateTime dt=m.StringToDate(ngayvv.Text.Substring(0,10));
				if (hen_loai.SelectedIndex==0)
				{
					for(int i=1;i<=Convert.ToInt16(hen_ngay.Value);i++)
					{
						ngay=m.DateToString("dd/MM/yyyy",dt.AddDays(i));
						r=dsdt.Tables[0].NewRow();
						r["syt"]=m.Syte;
						r["bv"]=m.Tenbv;
						r["diachibv"]=tenbs.Text;
						r["ngayin"]=ngayvv.Text;
						r["nguoiin"]=s_userid;
						r["ghichu"]=hen_ghichu.Text;
						r["lien"]="SỐ : "+sovaovien.Text;
						r["mabn"]=mabn2.Text+mabn3.Text;
						r["hoten"]=hoten.Text;
						r["namsinh"]=namsinh.Text;
						r["tuoi"]=tuoi.Text+" "+loaituoi.Text;
						r["gioitinh"]=phai.SelectedIndex.ToString();
						r["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+", "+tenquan.Text.Trim()+", "+tentinh.Text.Trim();
						r["ngaykham"]=ngay;
						r["lydokham"]=hen_ghichu.Text;
						r["nghenghiep"]=tennn.Text;
						r["doituong"]=tendoituong.Text;
						r["sothe"]=sothe.Text;
						r["tungay"]=(chkTiepdon.Checked)?"Qua tiếp đón":"";
						r["denngay"]=denngay.Text;
						r["noidkkcb"]=noidkkcb;
						r["chandoan"]=cd_chinh.Text;
						r["dantoc"]=tendantoc.Text;
						s_mabn=mabn2.Text+mabn3.Text;
						if (!chkTiepdon.Checked)
						{
                            //Tu:28/03/2011 chua lam cho nay
							//if (!m.bMmyy(m.mmyy(ngay))) d.tao_user_mmyy(m.mmyy(ngay),i_userid);
							maql1=m.get_maql_tiepdon_mmyy(s_mabn,ngay+" 08:00");
							s_sovaovien=sovaovien.Text;
							if (bStt)
							{
								s_sovaovien="";
								foreach(DataRow r1 in m.get_data("select * from "+user+m.mmyy(ngay)+".tiepdon where maql="+maql1).Tables[0].Rows)
									s_sovaovien=r1["sovaovien"].ToString();
								if (s_sovaovien=="")
								{
									s_sovaovien=m.getSttkham(ngay,makp.Text).ToString();
									string s_hen=hen_ghichu.Text.Trim()+", Thứ tự tái khám "+s_sovaovien;
									hen_ghichu.Text=s_hen;
								}
							}
							m.upd_tiepdon_mmyy(s_mabn,maql1,makp.Text,ngay+" 08:00",int.Parse(tendoituong.SelectedValue.ToString()),s_sovaovien,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),bnmoi.SelectedIndex,i_userid,LibMedi.AccessData.Khambenh,loai.SelectedIndex,l_matd);
							m.upd_lienhe(ngay,maql1,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex);
							so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
							if (int.Parse(so.Substring(0,2))>0)
							{
								if (!m.upd_bhyt(ngay,s_mabn,maql1,sothe.Text,denngay.Text,noidk.Text,0,tungay.Text,traituyen))
								{
									MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
									return;
								}
							}
						}
						dsdt.Tables[0].Rows.Add(r);
					}
				}
				else
				{
					switch (hen_loai.SelectedIndex)
					{
						case 1: ngay=m.DateToString("dd/MM/yyyy",dt.AddDays(Convert.ToInt16(hen_ngay.Value)));
							break;
						case 2: ngay=m.DateToString("dd/MM/yyyy",dt.AddDays(7*Convert.ToInt16(hen_ngay.Value)));
							break;
						case 3: ngay=m.DateToString("dd/MM/yyyy",dt.AddMonths(Convert.ToInt16(hen_ngay.Value)));
							break;
						default: ngay=m.DateToString("dd/MM/yyyy",dt.AddYears(Convert.ToInt16(hen_ngay.Value)));
							break;
					}
					r=dsdt.Tables[0].NewRow();
					r["syt"]=m.Syte;
					r["bv"]=m.Tenbv;
					r["diachibv"]=tenbs.Text;
					r["ngayin"]=ngayvv.Text;
					r["nguoiin"]=s_userid;
					r["ghichu"]=hen_ghichu.Text;
					r["lien"]="SỐ : "+sovaovien.Text;
					r["mabn"]=mabn2.Text+mabn3.Text;
					r["hoten"]=hoten.Text;
					r["namsinh"]=namsinh.Text;
					r["tuoi"]=tuoi.Text+" "+loaituoi.Text;
					r["gioitinh"]=phai.SelectedIndex.ToString();
					r["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+", "+tenquan.Text.Trim()+", "+tentinh.Text.Trim();
					r["ngaykham"]=ngay;
					r["lydokham"]=hen_ghichu.Text;
					r["nghenghiep"]=tennn.Text;
					r["doituong"]=tendoituong.Text;
					r["sothe"]=sothe.Text;
					r["tungay"]=(chkTiepdon.Checked)?"Qua tiếp đón":"";
					r["denngay"]=denngay.Text;
					r["noidkkcb"]=noidkkcb;
					r["chandoan"]=cd_chinh.Text;
					r["dantoc"]=tendantoc.Text;
					s_mabn=mabn2.Text+mabn3.Text;
					dsdt.Tables[0].Rows.Add(r);
				}
				if (m.bPreview)
				{
                    dllReportM.frmReport f = new dllReportM.frmReport(dsdt, "", "", "m_phieuhen.rpt");
					f.ShowDialog(this);
				}
				else print.Printer(dsdt,"m_phieuhen.rpt","","",0);
			}
			butLuu.Focus();
		}

		private void hen_loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (hen_loai.SelectedIndex==-1) hen_loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void label32_Click(object sender, System.EventArgs e)
		{
			
		}

		private void tungay_Validated(object sender, System.EventArgs e)
		{
			if (sothe.Text!="")
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
				if (!m.bNgay(ngayvv.Text,tungay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu phải nhỏ hơn ngày khám bệnh!"),s_msg);
					tungay.Focus();
					return;
				}
			}
		}

		private void noidk_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennoidk.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+noidk.Text+"'").Tables[0].Rows[0][0].ToString();
			}
			catch{}
		}

		private void tennoidk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list1.Visible)
				{
					list1.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tennoidk_TextChanged(object sender, System.EventArgs e)
		{
			treeView1.Visible=false;
			Filt_noicap(tennoidk.Text);
			list1.BrowseToText(tennoidk,noidk,sovaovien,noidk.Location.X,noidk.Location.Y+noidk.Height,noidk.Width+tennoidk.Width+2,noidk.Height);
		}

		private void Filt_noicap(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[list1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}

		private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Escape)
			{
				//danhsach.Visible=false;
				mabn2.Focus();

                this.danhsach.Location = new Point(0, panHanhchanh.Top);
                this.danhsach.Size = new Size(148, panMenu.Top);
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c_lydo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_lydo) setFcous(c_lydo);
		}

		private void setFcous(TextBox txt)
		{
			if (txt.Text == "\r\n") SendKeys.Send("{Tab}");
		}

		private void c_hb_benhly_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_hb_benhly) setFcous(c_hb_benhly);
		}

		private void c_hb_banthan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_hb_banthan) setFcous(c_hb_banthan);
		}

		private void c_hb_giadinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_hb_giadinh) setFcous(c_hb_giadinh);
		}

		private void c_kb_toanthan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_kb_toanthan) setFcous(c_kb_toanthan);
		}

		private void c_kb_bophan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_kb_bophan) setFcous(c_kb_tai);
		}

		private void c_kb_tomtat_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c_kb_tomtat) setFcous(c_kb_tomtat);
		}

		private void pic_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				frmXemhinh f=new frmXemhinh(hoten.Text,(byte[])(pic.Tag));
				f.ShowDialog();
			}
			catch{}
		}

		private void butChiphi_Click(object sender, System.EventArgs e)
		{
			l_maql=m.get_maql_mmyy(3,s_mabn,makp.Text,ngayvv.Text,false);
			if (l_maql==0)
			{
				butLuu_Click(sender,e);
				ena_but(false);
			}
			s_chonxutri=chon_xutri();
			string maso=l_maql.ToString().Trim()+",";
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="")
			{				
				if (s_chonxutri.IndexOf("05,")!=-1 && bXutri_noitru && m.bCapve_noitru)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chuyển vào nội trú !"),LibMedi.AccessData.Msg);
					return;
				}
				if (s_chonxutri.IndexOf("08,")!=-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa kết thúc !"),LibMedi.AccessData.Msg);
					return;
				}				
				maso=m.get_maso_khambenh(l_maql,ngayvv.Text);
				if (m.get_thvp_done(s_mabn,maso,ngayvv.Text,ngayvv.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Viện phí đã cập nhật !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			else
			{
				if (s_chonxutri=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"),s_msg);
					xutri.Focus();
					return;
				}
				if (icd_chinh.Text=="" && cd_chinh.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
					icd_chinh.Focus();
					return;
				}
				else if (icd_chinh.Text=="" && cd_chinh.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
					icd_chinh.Focus();
					return;
				}
				else if (cd_chinh.Text=="" && icd_chinh.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"),s_msg);
					if (cd_chinh.Enabled) cd_chinh.Focus();
					else icd_chinh.Focus();
					return;
				}
				if (mabs.Text=="" || tenbs.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
					mabs.Focus();
					return;
				}
			}

			string s_chandoan=cd_chinh.Text.Trim()+";";
			foreach(DataRow r3 in d.get_data("select chandoan from "+user+d.mmyy(ngayvv.Text)+".cdkemtheo where maql="+l_maql+" order by stt").Tables[0].Rows)
				s_chandoan+=r3["chandoan"].ToString()+";";
			int iTuoi=(tuoi.Text!="")?int.Parse(tuoi.Text):(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,e.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,";
			sql+="a.giamua dongia,round(a.giamua*a.soluong,3) sotien,";
			sql+="a.cachdung,a.makho,a.manguon,a.nhomcc ";
			sql+=", 0 as giachenhlech ";
			sql+=" from xxx.bhytthuoc a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_nhomcc d,"+user+".d_dmkho e,xxx.bhytkb f ";
			sql+=" where f.id=a.id and a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=e.id ";
			sql+=" and f.mabn='"+s_mabn+"'";
			//sql+=" and f.maql="+l_maql;
			if (maso!="") sql+=" and f.maql in ("+maso.Substring(0,maso.Length-1)+")";
			sql+=" and to_char(f.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
			sql+=" and f.loaiba=3";
			//if (chkBhyt.Checked) sql+=" and f.maphu=1";
			sql+=" and f.maphu="+int.Parse(madoituong.Text);
			sql+=" order by f.id,a.stt"; 
			//DataSet dstmp=d.get_thuoc_r(ngayvv.Text,ngayvv.Text,sql);
            DataSet dstmp = m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, false);
			//tu truc
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,e.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,";
			sql+="a.giamua dongia,round(a.giamua*a.soluong,3) sotien,";
			sql+="'x' as cachdung,a.makho,a.manguon,a.nhomcc ";
			sql+=", 0 as giachenhlech ";
			sql+=" from xxx.d_xuatsdct a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_nhomcc d,"+user+".d_dmkho e,xxx.d_xuatsdll f";
			sql+=" where f.id=a.id and a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=e.id ";
			sql+=" and f.mabn='"+s_mabn+"' and to_char(f.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
			//sql+=" and a.maql="+l_maql;
			if (maso!="") sql+=" and f.maql in ("+maso.Substring(0,maso.Length-1)+")";
			//if (chkBhyt.Checked) sql+=" and a.madoituong=1";
			sql+=" and a.madoituong="+int.Parse(madoituong.Text);
			sql+=" and f.loai=2 order by f.id,a.stt"; 
			//dstmp.Merge(d.get_thuoc_r(ngayvv.Text,ngayvv.Text,sql));
            dstmp.Merge(m.get_data_mmyy(sql,ngayvv.Text, ngayvv.Text,false));
			//
			sql="select a.stt,0 sttt,a.mavp mabd,b.ma,b.ten,' ' tenhc,b.dvt dang,' ' tenkho,' ' tennguon,' ' tennhomcc,' ' handung,' ' losx,a.soluong,a.dongia,a.soluong*a.dongia sotien,' ' cachdung,0 makho,0 manguon,0 nhomcc ";
			sql+=",0 as giachenhlech ";
			sql+=" from xxx.bhytcls a,"+user+".v_giavp b,xxx.bhytkb c where c.id=a.id and a.mavp=b.id ";
			sql+=" and c.mabn='"+s_mabn+"' and to_char(c.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
			//sql+=" and c.maql="+l_maql;
			if (maso!="") sql+=" and c.maql in ("+maso.Substring(0,maso.Length-1)+")";
			//if (chkBhyt.Checked) sql+=" and c.maphu=1";
			sql+=" and c.loaiba=3";
			sql+=" and c.maphu="+int.Parse(madoituong.Text);
			sql+=" order by c.id,a.stt"; 
			//dstmp.Merge(d.get_thuoc_r(ngayvv.Text,ngayvv.Text,sql));
            dstmp.Merge(m.get_data_mmyy(sql,ngayvv.Text, ngayvv.Text, false));
			if (m.bChidinh_vienphi)
			{
				sql="select cast(0 as numeric) as stt,0 sttt,a.mavp mabd,b.ma,b.ten,' ' tenhc,b.dvt dang,' ' tenkho,' ' tennguon,' ' tennhomcc,' ' handung,' ' losx,a.soluong,a.dongia,a.soluong*a.dongia sotien,' ' cachdung,0 makho,0 manguon,0 nhomcc ";
				sql+=",0 as giachenhlech ";
				sql+=" from xxx.v_chidinh a,"+user+".v_giavp b where a.mavp=b.id and a.loai=2 and a.paid=0";
				sql+=" and a.mabn='"+s_mabn+"' and to_char(a.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
				if (maso!="") sql+=" and a.maql in ("+maso.Substring(0,maso.Length-1)+")";
				//sql+=" and a.maql="+l_maql;
				//if (chkBhyt.Checked) sql+=" and a.madoituong=1";
				sql+=" and a.madoituong="+int.Parse(madoituong.Text);
				sql+=" order by a.id";
				dstmp.Merge(v.get_vienphi(ngayvv.Text,ngayvv.Text,sql));
			}
			dsxmlin.Clear();
			DataRow r2;
			string stamung=m.get_tamung(s_mabn,maso,ngayvv.Text,ngayvv.Text);
			decimal tamung=decimal.Parse(stamung.Substring(0,stamung.IndexOf("^")));
			stamung=stamung.Substring(stamung.IndexOf("^")+1);
			string ns=namsinh.Text,_sothe=sothe.Text,_denngay=tungay.Text+" ^ "+denngay.Text,diachi=sonha.Text.Trim()+" "+thon.Text.Trim()+","+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim();
			decimal st=0;
			foreach(DataRow r in dstmp.Tables[0].Rows)
			{
				if (r["sttt"].ToString()=="0")
					r2=m.getrowbyid(dtvpin,"id="+int.Parse(r["mabd"].ToString()));
				else
					r2=m.getrowbyid(dtbd,"id="+int.Parse(r["mabd"].ToString()));
				if (r2!=null)
				{
					st+=decimal.Parse(r["sotien"].ToString());
					m.updrec_ravien(dsxmlin,0,s_mabn,s_mabn,l_maql,0,hoten.Text,ns,phai.Text,diachi,int.Parse(madoituong.Text),
						madoituong.Text,_sothe,0,tungay.Text,_denngay,tendstt.Text,tennoidk.Text,"",r["cachdung"].ToString(),(tenkp.Text!="")?tenkp.Text:"Khoa khám bệnh",
						ngayvv.Text,ngayvv.Text,s_chandoan,icd_chinh.Text,int.Parse(r2["sttnhom"].ToString()),
						r2["nhom"].ToString(),int.Parse(r2["sttloai"].ToString()),r2["loai"].ToString(),
						int.Parse(r["mabd"].ToString()),r["ten"].ToString(),r["dang"].ToString(),
						decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["sotien"].ToString()),
						0,tamung,(d.bcongkham_bhyt(m.nhom_duoc))?d.Congkham(m.nhom_duoc):0,qh_hoten.Text,1,(makp.Text!="")?m.phuongphapdieutri(makp.Text):0,0,"",decimal.Parse(r["dongia"].ToString()),"","",3,0,mabs.Text,tenbs.Text,s_userid,"","","","","",ngayvv.Text,-1,"",0,(r["giachenhlech"].ToString()==""?0:decimal.Parse(r["giachenhlech"].ToString())));
				}
			}
			string chu=doiso.doithapphan(st.ToString());
			decimal sotien=0,bhyt=0;
			foreach(DataRow r in dsxmlin.Tables[0].Rows)
			{
				r["sbltamung"]=stamung;
				r["tcsotien"]=st;
				r["dichsotra"]=chu;
				r["dichso"]=chu;
				if (madoituong.Text=="1")
				{
					r["bhyttra"]=st;
					bhyt=st;
					sotien=0;
				}
				else
				{
					r["bntra"]=st;
					sotien=st;
					bhyt=0;
				}
			}
			string s_mmyy=m.mmyy(ngayvv.Text),ngayserver=m.ngayhienhanh_server,s_idvienphi=v.get_id_thvp(0,s_mabn,l_maql,0,ngayvv.Text,ngayserver);
			decimal idvienphi=0;
			if (s_idvienphi!="")
			{
				s_mmyy=s_idvienphi.Substring(0,4);
				idvienphi=decimal.Parse(s_idvienphi.Substring(4));
				m.execute_data("delete from "+m.user+mmyy+".v_thvpct where id="+idvienphi);
			}
			else idvienphi=v.get_id_thvp();
            if (sotien + bhyt + tamung != 0) v.upd_thvpll(idvienphi, s_mabn, l_mavaovien, l_maql, 0, ngayvv.Text, ngayvv.Text, "", makp.Text, cd_chinh.Text, icd_chinh.Text, sotien, tamung, bhyt, 0, s_mmyy);
            if (sothe.Text != "" && madoituong.Text == "1") v.upd_thvpbhyt(idvienphi, sothe.Text, 0, madstt.Text, noidk.Text, s_mmyy, traituyen);
			foreach(DataRow r in dsxmlin.Tables[0].Rows)
                v.upd_thvpct(idvienphi, ngayvv.Text, makp.Text, int.Parse(madoituong.Text), decimal.Parse(r["ma"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["sotien"].ToString()), 0, s_mmyy, sothe.Text,"",0,0);
            dllReportM.frmReport f = new dllReportM.frmReport(m, dsxmlin, (tenkp.Text != "") ? tenkp.Text : "Khoa khám bệnh", "rpt_ttravien_kb.rpt");
			f.ShowDialog();		
		}

        private void butChon_Click(object sender, EventArgs e)
        {

        }
        //???
        public void init()
        {
            v=new LibVienphi.AccessData();
            d = new LibDuoc.AccessData();
            lan = new Language();
            m = new LibMedi.AccessData();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //MSComm1 = null;
        }
        public void load_data()
        {
            i_maxlenght_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlenght_mabn-2;
            if (s_mabs != "")
            {
                mabs.Enabled = false;
                tenbs.Enabled = false;
                tenbs_pass.Enabled = false;

                //mabs.Text = s_mabs;
                //DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                //if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                //else tenbs.Text = "";
            }
            pathImage = m.pathImage; FileType = m.FileType;
            bChenhlech_laygiaphuthu = m.bChenhlech_laygiaphuthu;
            bPhongluu_userid = m.bPhongluu_userid; bHen_dangkylai = m.bHen_dangkylai;
            bChuctramngan = m.bChuctramngan; madoituong_hen = m.madoituong_hen; xutri_hen = m.xutri_hen;
            _d1 = m.delay1;
            _d2 = m.delay2;
            _d3 = m.delay3;
            _d4 = m.delay4;

            bChuyenkham_thuphi = m.bChuyenkham_thuphi;
            bChuyenkham_tinh_congkham_dtthuphi = m.bChuyenkham_tinh_congkham_dtthuphi;
            bChuyenkham_tinhcongkham = m.bChuyenkham_tinhcongkham;
            bKhamsuckhoe = m.bKhamsuckhoe;
            bTaikham_hen = m.bTaikham_hen;
            hen_butin.Enabled = m.bTaikham_in;
            bHinh = m.bHinh || m.bChonhinh;//m.bChonhinh_mabn;
            //pic.Visible = bHinh;
            bHienthi_tivi = m.bHienthi_tivi; bStt = m.bStt_tudong;
            chkXem.Checked = m.bPreview;
            bYta_khambenh = m.bYta_khambenh; bBacsi_hanhchinh = m.bBacsi_hanhchinh;
            bNgay1kham = m.bNgay1kham; bCaller = m.bKhambenh_bangdien;
            bGhichu = m.bGhichu_toamuangoai;
            user = m.user; bSuadoituong = m.bSuadoituong_khambenh;
            hen_loai.SelectedIndex = 0; makp_khamnoi = m.Makp_khamnoi;
            lblhd.Text = ""; bPhongkham_chidinh = m.bPhongkham_chidinh; bSothe_mabn = m.bsothe_mabn;
            bTungay = m.bBHYT_tungay;
            tungay.Enabled = bTungay;
            i_sokham = m.iSokham;
            b711512 = m.Mabv_so == 711512;
            b701306 = m.Mabv_so == 701306;
            b701424 = m.Mabv_so == 701424;
            bChandoan = m.bChandoan_icd10;
            bDenngay_sothe = m.bDenngay_sothe;
            b_trongngoai = m.bKham_trong_ngoai_gio;
            if (b_trongngoai && m.gio_ngoai != "00:00")
            {
                dtletet = m.get_data("select * from " + user + ".letet").Tables[0];
                hh3 = int.Parse(m.sGiobaocao.Substring(0, 2));
                mm3 = int.Parse(m.sGiobaocao.Substring(3, 2));
                hh2 = int.Parse(m.gio_ngoai.Substring(0, 2));
                mm2 = int.Parse(m.gio_ngoai.Substring(3, 2));
                bTudong = true;
                loai.Enabled = false;
            }
            else loai.Enabled = b_trongngoai;
            sql = "select a.id,a.ma,a.ten,a.dvt,b.stt sttloai,b.ten loai,c.stt sttnhom,c.ten nhom";
            sql += " from " + m.user + ".v_giavp a," + m.user + ".v_loaivp b," + m.user + ".v_nhomvp c";
            sql += " where a.id_loai=b.id and b.id_nhom=c.ma";
            dtvpin = m.get_data(sql).Tables[0];

            sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' ten,";
            sql += "a.dang dvt,c.stt sttloai,c.ten loai,d.stt sttnhom,d.ten nhom";
            sql += " from " + m.user + ".d_dmbd a," + m.user + ".d_dmhang b," + m.user + ".d_dmnhom c," + m.user + ".v_nhomvp d";
            sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
            dtbd = m.get_data(sql).Tables[0];

            dsxmlin.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            dsxmlin.Tables[0].Columns.Add("traituyen", typeof(decimal)).DefaultValue = 0;
            dsxmlin.Tables[0].Columns.Add("giachenhlech", typeof(decimal)).DefaultValue = 0;

            bTamung = m.bTamung_khambenh;
            mmyy = v.mmyy(m.ngayhienhanh_server);
            dsloai.ReadXml("..\\..\\..\\xml\\m_loai.xml");
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
            loai.DataSource = dsloai.Tables[0];
            dsbnmoi.ReadXml("..\\..\\..\\xml\\m_bnmoi.xml");
            bnmoi.DisplayMember = "TEN";
            bnmoi.ValueMember = "ID";
            bnmoi.DataSource = dsbnmoi.Tables[0];
            bnmoi.Enabled = m.bMoi_cu;
            bSoluutru = m.bSoluutru_nhapvien;
            bBacsy = m.bBacsy_tiepdon;
            bTiepdon = m.bTiepdon(LibMedi.AccessData.Khambenh);
            bDanhmuc_nhathuoc = m.bDanhmuc_nhathuoc;
            bKhamthai = m.bKhamthai;
            khamthai.Visible = bKhamthai;
            bChuyenkhoasan = m.bChuyenkhoasan;
            if (bChuyenkhoasan) phai.SelectedIndex = 1;
            lbl.Text = "";
            lchiphi.Text = "";
            bXutri_noitru = m.bXutri_noitru_kb;
            bXutri_ngoaitru = m.bXutri_ngoaitru_kb;
            iChidinh = m.iChidinh;
            bHiends = m.bHiendanhsach;
            bAdmin = m.bAdmin(i_userid);
            b_bacsi = m.bsKhambenh;
            bLuutru_Mabn = m.bSoluutru_Mabn;
            b_Hoten = m.bHoten_gioitinh;
            b_sovaovien = m.bSovaovien;
            load_dm();
            iKhamnhi = m.iTuoi_khamnhi;
            phai.SelectedIndex = 0;
            ngayvv.Text = m.ngayhienhanh_server;
            s_ngayvv = ngayvv.Text;
            songay = m.Ngaylv_Ngayht;
            s_msg = LibMedi.AccessData.Msg;
            cd_noichuyenden.Enabled = m.bChandoan;
            cd_chinh.Enabled = cd_noichuyenden.Enabled;
            b_khambenh = m.bKhambenh;
            iTreem6 = m.iTreem6;
            iTreem15 = m.iTreem15;
            soluutru.Enabled = !bLuutru_Mabn;
            DataTable tmp = m.get_data("select maba from " + m.user + ".dmbenhan where loaiba=2 order by maba").Tables[0];
            if (tmp.Rows.Count > 0) i_bangoaitru = int.Parse(tmp.Rows[0]["maba"].ToString());
            else i_bangoaitru = 20;
            if (i_loai == 2 && !bYta_khambenh) ena_yta(false);
            else if (i_loai == 1 && !bBacsi_hanhchinh) ena_bacsi(false);
            dtgia = m.get_data("select * from " + user + ".v_giavp").Tables[0];

            //goi kham benh
            ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            bPhongkham_bangdien_hanoi = m.bPhongkham_bangdien_hanoi;
            bPhongkham_bangdien_kontum = m.bPhongkham_bangdien_kontum;
            bGoi = m.bGoi_khambenh && dtkp.Rows.Count == 1;
            if (pgoi.Visible = bGoi || bPhongkham_bangdien_kontum)
            {
                sonhay.Value = decimal.Parse(m.sonhay.ToString());
                decimal so = m.goikham(ngaysrv, dtkp.Rows[0]["makp"].ToString());
                if (so != 0)
                {
                    tu.Value = Math.Max(0, so - sonhay.Value + 1);
                    den.Value = so;
                }
                else
                {
                    tu.Value = 0; den.Value = 0;
                }
            }

            ds_lydo = m.get_data("select id,ten from " + user + ".dmlydokham where danhmuc in(2,3,4)");
            //khuong
            chkTudongchonthongso.Checked = m.Thongso(chkTudongchonthongso.Name) == "1";
            //end khuog
            dtdmbenhvien = m.get_data("select mabv,tenbv,mahang,ngoaidm,maloai from " + user + ".tenvien where mabv<>'" + s_mabv + "'").Tables[0];
            listBenhvien.DisplayMember = "MABV";
            listBenhvien.ValueMember = "TENBV";
            listBenhvien.DataSource = dtdmbenhvien;
            DataRow rkp = m.getrowbyid(dtkp, "makp='" + s_makp + "'");
            butTiemchung.Enabled = rkp["tiemchung"].ToString() == "1";
        }
        public LibMedi.AccessData access
        {
            get { return m; }
            set { m = value; }
        }
        public bool Quantrihethong
        {
            get { return bAdministrator; }
            set { bAdministrator = value; }
        }
        public bool bSoLuuTru
        {
            get { return bSoLuuTru; }
            set { bSoLuuTru = value; }
        }
        public string strMakp
        {
            get { return s_makp; }
            set { s_makp = value; }
        }
        public string strMadoituong
        {
            get { return s_madoituong; }
            set { s_madoituong = value; }
        }
        public string strMabs
        {
            get { return s_mabs; }
            set { s_mabs = value; }
        }
        public string strHotennguoinhap
        {
            get { return s_userid; }
            set { s_userid = value; }
        }
        public string strNhomkho
        {
            get { return s_nhomkho; }
            set { s_nhomkho = value; }
        }
        public int i_Userid
        {
            get { return i_userid; }
            set { i_userid = value; }
        }
        public int i_Mabv
        {
            get { return i_mabv; }
            set { i_mabv = value; }
        }
        public int i_Loai
        {
            get { return i_loai; }
            set { i_loai = value; }
        }
        public void load_giatribt()
        {
            foreach (DataRow r in m.get_data("select * from " + user + ".dmgiatribt").Tables[0].Rows)
            {
                mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                huyetap.Text = r["huyetap"].ToString();
                nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                tinh_bmi();
                break;
            }
        }
        //???
        private void frmKhambenh_tmh_Load(object sender, EventArgs e)
        {
            butLuu.Tag = "0";
            buttmh.Visible = false;
            barTmh.Visible = false;
            load_data();
            //linh
            //load_giatribt();
            i_maxlenght_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlenght_mabn - 2;
            //edn
            //string hoten_login = m.get_data("select hoten from "+user+".dlogin where id="+i_userid+"").Tables[0].Rows[0][0].ToString();
            //lblnguoilogin.Text = "[Người đang làm việc: "+hoten_login+"]";
        }

        private void but_thuocbhyt_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (icd_chinh.Text == "" && cd_chinh.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                icd_chinh.Focus();
                return;
            }
            else if (icd_chinh.Text == "" && cd_chinh.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                icd_chinh.Focus();
                return;
            }
            else if (cd_chinh.Text == "" && icd_chinh.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"), s_msg);
                if (cd_chinh.Enabled) cd_chinh.Focus();
                else icd_chinh.Focus();
                return;
            }
            if (!m.Kiemtra_maicd(dticd, icd_chinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                icd_chinh.Focus();
                return;
            }
            if (bChandoan)
            {
                if (!m.Kiemtra_tenbenh(dticd, cd_chinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                    cd_chinh.Focus();
                    return;
                }
            }
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            //if (l_maql==0)
            //{
            //if (!kiemtra()) return;
            butLuu_Click(sender, e);
            if (!bExit) return;
            ena_but(false);
            //}
            string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
            sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
            DataTable dt = m.get_data(sql).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                s_mmyy = r["mmyy"].ToString();
                //if (d.get_data(s_mmyy,"select a.* from d_tonkhoth a,"+d.user+".d_dmkho b where a.makho=b.id and b.nhom="+m.nhom_duoc).Tables[0].Rows.Count>0) break;
                if (d.get_data("select a.* from " + d.user + s_mmyy + ".d_tonkhoth a," + d.user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
            }
            if (madoituong.Text != "1") if (!kiemtra(6)) return;
            //cho nay chua lam Tu: 28/03/2011
            frmBaohiem f = new frmBaohiem(false, s_mabn, (madoituong.Text == "1") ? 5 : 6, s_mmyy, ngayvv.Text, m.nhom_duoc, i_userid, "Đơn thuốc dược phát", l_mavaovien, l_maql, hoten.Text, namsinh.Text, sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, int.Parse(madoituong.Text), makp.Text, mabs.Text, tendoituong.Text, (cholam.Text.Trim() != "") ? cholam.Text : sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 3, noidk.Text, false, s_madoituong, ngayvv.Text, c_lydo.Text, traituyen, "", "", "", phai.Text, false,i_khudt);
            //linh
            int i_songayhen = 1;
            if (maxutri.Text.IndexOf("03,") > -1)
            {
                DateTime dt_ngayhen = m.StringToDate(ngayvv.Text.Substring(0, 10));
                switch (hen_loai.SelectedIndex)
                {
                    case 1: i_songayhen = (int)hen_ngay.Value;
                        break;
                    case 2: i_songayhen = 7 * (int)hen_ngay.Value;
                        break;
                    case 3: i_songayhen = DateTime.DaysInMonth(dt_ngayhen.Year, dt_ngayhen.Month) * (int)hen_ngay.Value;
                        break;
                    default: i_songayhen = dt_ngayhen.DayOfYear * (int)hen_ngay.Value;
                        break;
                }
                f.SoNgayHen = i_songayhen;
            }
            f.ShowDialog(this);
            if (maxutri.Text.IndexOf("03,") > -1)
            {
                if (i_songayhen != f.SoNgayHen)
                {
                    hen_ngay.Value = (decimal)f.SoNgayHen;
                    hen_ghichu.Text = lan.Change_language_MessageText("Hẹn lại theo ngày trong toa thuốc");
                    upd_xutri_hen();
                }
            }
            else
            {
                if (f.SoNgayHen > 0)
                {
                    hen_ngay.Value = (decimal)f.SoNgayHen;
                    hen_loai.SelectedIndex = 1;
                    hen_ghichu.Text = lan.Change_language_MessageText("Hẹn trong toa thuốc");
                    maxutri.Text = maxutri.Text.Trim(',') + ",03,";
                    maxutri_Validated(null, null);
                    butLuu_Click(null, null);
                }
            }
            //end linh
            load_baohiem();
        }

        private void but_thuocdan_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (icd_chinh.Text == "" && cd_chinh.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                icd_chinh.Focus();
                return;
            }
            else if (icd_chinh.Text == "" && cd_chinh.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                icd_chinh.Focus();
                return;
            }
            else if (cd_chinh.Text == "" && icd_chinh.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"), s_msg);
                if (cd_chinh.Enabled) cd_chinh.Focus();
                else icd_chinh.Focus();
                return;
            }
            if (!m.Kiemtra_maicd(dticd, icd_chinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                icd_chinh.Focus();
                return;
            }
            if (bChandoan)
            {
                if (!m.Kiemtra_tenbenh(dticd, cd_chinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                    cd_chinh.Focus();
                    return;
                }
            }
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            //if (l_maql==0)
            //{
            //if (!kiemtra()) return;
            butLuu_Click(sender, e);
            if (!bExit) return;
            ena_but(false);
            //}
            if (bDanhmuc_nhathuoc)
            {
                string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
                sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                DataTable dt = m.get_data(sql).Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    s_mmyy = r["mmyy"].ToString();
                    //if (d.get_data(s_mmyy,"select a.* from d_tonkhoth a,"+d.user+".d_dmkho b where a.makho=b.id and b.nhom="+m.nhom_nhathuoc).Tables[0].Rows.Count>0) break;
                    if (d.get_data("select a.* from " + d.user + s_mmyy + ".d_tonkhoth a," + d.user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc).Tables[0].Rows.Count > 0) break;
                }
                //
                string s_makho = d.get_dmkho(7).Trim(), s_ngay = ngayvv.Text, s_ngayht = m.ngayhienhanh_server;
                DataTable dtletet = m.get_data("select * from " + user + ".letet").Tables[0];
                DataRow r1 = m.getrowbyid(dtletet, "ngay='" + s_ngay.Substring(0, 5) + "'");
                bool bLetet = r1 != null;
                int hh1, hh2, hh3, mm1, mm2, mm3;
                string kho = "";
                hh1 = int.Parse(s_ngayht.Substring(11, 2));
                mm1 = int.Parse(s_ngayht.Substring(14, 2));
                hh3 = int.Parse(m.sGiobaocao.Substring(0, 2));
                mm3 = int.Parse(m.sGiobaocao.Substring(3, 2));
                string ddd = m.StringToDate(s_ngay.Substring(0, 10)).DayOfWeek.ToString().Substring(0, 3);
                if (bDanhmuc_nhathuoc && s_makho != "" && m.gio_nhathuoc != "00:00") //nha thuoc
                {
                    hh2 = int.Parse(m.gio_nhathuoc.Substring(0, 2));
                    mm2 = int.Parse(m.gio_nhathuoc.Substring(3, 2));
                    kho = m.kho_nhathuoc;
                    if (kho != "") kho += ",";
                    if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3)) s_makho = kho;
                    else if (kho != "") s_makho = s_makho.Remove(s_makho.IndexOf(kho), kho.Length);
                }
                if (s_makho != "")
                {
                    sql = "select * from " + user + ".d_dmkho where hide=0 and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
                    sql += " and nhom=" + m.nhom_nhathuoc;
                    DataTable tmp = m.get_data(sql).Tables[0];
                    if (tmp.Rows.Count > 1)
                    {
                        frmChonkho f1 = new frmChonkho(tmp);
                        f1.ShowDialog();
                        s_makho = f1.s_makho;
                        if (s_makho == "") return;
                    }
                }
                //chua lam cho nay Tu:28/03/2011
                //frmBaohiem f = new frmBaohiem(m, false, s_mabn, 7, s_mmyy, ngayvv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc mua ngoài", l_maql, hoten.Text, namsinh.Text, sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, 2, makp.Text, mabs.Text, tendoituong.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, 3, s_makho, s_madoituong, noidk.Text, phai.Text, l_mavaovien, false);
                frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayvv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc dịch vụ", l_mavaovien, l_maql, hoten.Text, namsinh.Text, sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, 2, makp.Text, mabs.Text, tendoituong.Text, (cholam.Text.Trim() != "") ? cholam.Text : sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 3, noidk.Text, false, s_madoituong, ngayvv.Text, c_lydo.Text, traituyen, "", "", "", phai.Text, false, i_khudt);//(madoituong.Text == "1") ? 5 : 6
                //linh
                int i_songayhen = 1;
                if (maxutri.Text.IndexOf("03,") > -1)
                {
                    DateTime dt_ngayhen = m.StringToDate(ngayvv.Text.Substring(0, 10));
                    switch (hen_loai.SelectedIndex)
                    {
                        case 1: i_songayhen = (int)hen_ngay.Value;
                            break;
                        case 2: i_songayhen = 7 * (int)hen_ngay.Value;
                            break;
                        case 3: i_songayhen = DateTime.DaysInMonth(dt_ngayhen.Year, dt_ngayhen.Month) * (int)hen_ngay.Value;
                            break;
                        default: i_songayhen = dt_ngayhen.DayOfYear * (int)hen_ngay.Value;
                            break;
                    }
                    f.SoNgayHen = i_songayhen;
                }
                f.ShowDialog(this);
                if (maxutri.Text.IndexOf("03,") > -1)
                {
                    if (i_songayhen != f.SoNgayHen)
                    {
                        hen_ngay.Value = (decimal)f.SoNgayHen;
                        hen_ghichu.Text = lan.Change_language_MessageText("Hẹn lại theo ngày trong toa thuốc");
                        upd_xutri_hen();
                    }
                }
                else
                {
                    if (f.SoNgayHen > 0)
                    {
                        hen_ngay.Value = (decimal)f.SoNgayHen;
                        hen_loai.SelectedIndex = 1;
                        hen_ghichu.Text = lan.Change_language_MessageText("Hẹn trong toa thuốc");
                        maxutri.Text = maxutri.Text.Trim(',') + ",03,";
                        maxutri_Validated(null, null);
                        butLuu_Click(null, null);
                    }
                }
                //end linh
                load_thuocdan();
            }
            else
            {
                frmToathuoc f2 = new frmToathuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text, makp.Text, tenkp.Text, mabs.Text, tenbs.Text, (c_lydo.Text != "" && bGhichu) ? c_lydo.Text : cd_chinh.Text, (c_lydo.Text != "" && bGhichu) ? "" : icd_chinh.Text, l_maql, i_userid, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), phai.Text, 3,i_chinhanh,true);
                f2.ShowDialog(this);
                load_thuocdan();
            }
        }

        private void butphauthuat_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            //chua lam cho nay:Tu 28/03/2011
            //frmPttt f=new frmPttt(m,makp.Text,s_mabn,hoten.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),phai.Text,sonha.Text.Trim()+" "+thon.Text,sothe.Text,"",ngayvv.Text,cd_chinh.Text,icd_chinh.Text,"P",i_userid,"","","","","","",0,0,0,0,0,"",0,3,"",0);
            frmPttt f = new frmPttt(m, makp.Text, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, "", ngayvv.Text, cd_chinh.Text, icd_chinh.Text, "P", i_userid, "", makp.Text, madoituong.Text, l_maql, l_mavaovien, 0, 3, m.bThuthuat_chidinh);
            f.ShowDialog();
            load_phauthuat();
        }

        private void butchidinh_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            //linh
            if (tenbs.Text == "" || mabs.Text == "")//m.bCD_BS_Chidinh end linh
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            string s_chandoan = "";
            if (sobo.Text != "") s_chandoan = sobo.Text + ";";
            if (cd_chinh.Text != "") s_chandoan += cd_chinh.Text + ";";
            if (phanbiet.Text != "") s_chandoan += phanbiet.Text;
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text, makp.Text, tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_mavaovien, l_maql, 0, i_userid, user + m.mmyy(ngayvv.Text) + ".benhanpk", sothe.Text, "", 3, mabs.Text, (cd_chinh.Text != "") ? cd_chinh.Text : (sobo.Text != "") ? sobo.Text : phanbiet.Text, icd_chinh.Text, i_traituyen, true, i_chinhanh);//bAdmin, l_mavaovien, 3, 0, denngay.Text);
            //linh
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
            f.TheBHYT_NoiDKKCB = noidk.Text;
            f.TuoiVao = tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString();
            f.ShowDialog();
            if (f.ChuyenNgoaiTru)
            {
                maxutri.Text = "02,";
                maxutri_Validated(null, null);
                icd_chinh.Text = "Z01.8";
                icd_chinh_Validated(null, null);
                c_kb_chuy.Text = lan.Change_language_MessageText("Tự động chuyển sang điều trị ngoại trú do dùng kỹ thuật xâm lấn") + ".";
                bool btudongchuyenvaongoaitru = bXutri_ngoaitru;
                khoa.Text = s_makp;
                khoa_Validated(null, null);
                bXutri_ngoaitru = true;
                butLuu_Click(sender, e);
                bXutri_ngoaitru = btudongchuyenvaongoaitru;
                if (bExit)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được chuyển sang hồ sơ bệnh án ngoại trú") + ".", "Medisoft");
                }
            }
            else if (f.ChuyenVien)
            {
                maxutri.Text = "06,";
                maxutri_Validated(null, null);
                icd_chinh.Text = "Z01.8";
                cd_chinh.Text = sobo.Text;
                mabv.Text = f.MaBenhVienCanChuyen;
                mabv_Validated(null, null);
                c_kb_chuy.Text = lan.Change_language_MessageText("Tự động xuất viện sang chi nhánh") + ": " + txtTenbv.Text + ".";
                bool _bchandoan = bChandoan;
                bChandoan = false;
                butLuu_Click(sender, e);
                bChandoan = _bchandoan;
                if (bExit)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được chuyển sang") + ": " + txtTenbv.Text + ".", "Medisoft");
                }
            }
            else if (f.XuatVienHenTraKetQua)
            {
                maxutri.Text = "03,";
                maxutri_Validated(null, null);
                icd_chinh.Text = "Z01.7";
                cd_chinh.Text = "Xét nghiệm cận lâm sàng";
                int i_songayhen = f.SoNgayHenTraKetQua;
                hen_ngay.Value = i_songayhen;
                hen_loai.SelectedIndex = 1;
                c_kb_chuy.Text = lan.Change_language_MessageText("Tự động xuất viện hẹn trả kết quả cận lâm sàng");
                butLuu_Click(null, null);
                if (bExit)
                {
                    DateTime ngayhen = DateTime.Now.Date.AddDays(i_songayhen);
                    hen_ghichu.Text = lan.Change_language_MessageText("Hẹn") + " " + m.DateToString("dd/MM/yyyy", ngayhen) + " " + lan.Change_language_MessageText("ngày") + " " + lan.Change_language_MessageText("để lấy kết quả");
                    hen_butin_Click(null, null);
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được hẹn") + ": " + i_songayhen.ToString()+" " + hen_loai.Text + ".", "Medisoft");
                }
            }
            load_chidinh();
            //end linh
        }

        private void buttonkho_Click(object sender, EventArgs e)
        {
            if (ngayvv.Text == "") return;
            string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
            sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
            DataTable dt = m.get_data(sql).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                s_mmyy = r["mmyy"].ToString();
                //if (d.get_data(s_mmyy,"select a.* from d_tonkhoth a,"+d.user+".d_dmkho b where a.makho=b.id and b.nhom="+m.nhom_duoc).Tables[0].Rows.Count>0) break;
                //TU:28/03/2011
                if (d.get_data("select a.* from " + d.user + s_mmyy + ".d_tonkhoth a," + d.user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
            }
            frmXemtonth f = new frmXemtonth(s_mmyy, (madoituong.Text == "1") ? 5 : 6, m.nhom_duoc, (madoituong.Text == "") ? 0 : int.Parse(madoituong.Text), ngayvv.Text,"",true);
            f.ShowDialog();
        }

        private void buttainantt_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            frmTainantt f = new frmTainantt(m, l_maql, s_mabn, ngayvv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid,true,(cd_chinh.Text!="")?cd_chinh.Text:sobo.Text,c_lydo.Text,nam);
            f.ShowDialog();
            load_tainantt();
        }

        private void buttutruc_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, makp.Text + ",", false, s_nhomkho, this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, s_mabn, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, s_mabs, madoituong.Text);
                f1.ShowDialog(this);
            }	
        }

        private void butkemtheo_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                luu();
                if (!bExit) return;
            }
            frmCdkemtheo f = new frmCdkemtheo(m, l_maql, l_maql, 4, ngayvv.Text,true);
            f.ShowDialog();
            load_kemtheo();
        }

        private void butcls_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text + mabn3.Text, hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim(),true);
            f.ShowDialog(this);
        }

        private void butdiungthuoc_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            frmDiungthuoc f = new frmDiungthuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(),true);
            f.ShowDialog(this);
            load_diungthuoc();
        }

        private void butlichhen_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            //try
            //{
            //    Lichhen.LICHHEN f = new Lichhen.LICHHEN(s_mabn, l_maql, makp.Text, mabs.Text, 0, 3);
            //    f.ShowDialog(this);
            //}
            //catch { }
        }

        private void butsudungthuoc_Click(object sender, EventArgs e)
        {
            if (mabn2.Text.Length + mabn3.Text.Length != i_maxlenght_mabn || hoten.Text == "") return;
            frmXemthuocpk f = new frmXemthuocpk(m, mabn2.Text + mabn3.Text, nam, hoten.Text,true);
            f.ShowDialog();
        }

        private void buttiensu_Click(object sender, EventArgs e)
        {
            if (mabn2.Text.Length + mabn3.Text.Length != i_maxlenght_mabn || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text,true,ngayvv.Text.Substring(0,10));
            f.ShowDialog();
            //linh
            c_hb_banthan.Text = load_tiensu();
            buttiensu.ForeColor = c_hb_banthan.Text.Trim() != "" ? Color.Red : Color.Black;//(m.get_data("select * from " + user + ".theodoitsu where mabn='" + s_mabn + "'").Tables[0].Rows.Count > 0) ? Color.Red : System.Drawing.SystemColors.Desktop;
            //try
            //{
            //    c_hb_banthan.Text = m.get_data("select noidung from " + user + ".theodoitsu where mabn='" + s_mabn + "'").Tables[0].Rows[0][0].ToString();
            //}
            //catch { }
            //end linh
        }

        private void buttmh_Click(object sender, EventArgs e)
        {
            if (makp.Text == "") return;
            DataRow r = m.getrowbyid(dtkp, "makp='" + makp.Text + "' and makpbo in ('23','24','25')");
            if (r == null) return;
            s_mabn = mabn2.Text + mabn3.Text;
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            if (r["makpbo"].ToString() == "23")
            {
                frmBATMH f = new frmBATMH(m, l_maql, ngayvv.Text, true);
                f.ShowDialog();
            }
            else if (r["makpbo"].ToString() == "24")
            {
                frmBARHM f = new frmBARHM(m, l_maql, ngayvv.Text, true);
                f.ShowDialog();
            }
            else
            {
                frmBAMAT f = new frmBAMAT(m, l_maql, ngayvv.Text, true);
                f.ShowDialog();
            }
        }

        private void chieucao_Validated(object sender, EventArgs e)
        {
            tinh_bmi();
        }

        private void cannang_Validated(object sender, EventArgs e)
        {
            tinh_bmi();
        }
        private void tinh_bmi()
        {
            decimal cn = (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0;
            decimal cc = (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0;
            decimal _bmi = 0;
            if (cn != 0 && cc != 0) _bmi = cn / (cc / 100 * cc / 100);
            else _bmi = 0;
            bmi.Text = _bmi.ToString("####0.00");
        }

        private void icd_kemtheo_Validated(object sender, EventArgs e)
        {
            if (icd_kemtheo.Text == "" && !phanbiet.Enabled)
            {
                phanbiet.Text = "";
                butLuu.Focus();
                return;
            }
            else if (icd_kemtheo.Text != s_icd_chinh)
            {
                phanbiet.Text = m.get_vviet(icd_kemtheo.Text);
                if (phanbiet.Text == "" && icd_kemtheo.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kemtheo.Text, phanbiet.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        phanbiet.Text = f.mTen;
                        icd_kemtheo.Text = f.mICD;
                    }
                }
                s_icd_chinh = icd_kemtheo.Text;
            }
        }

        private void phanbiet_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == phanbiet)
            {
                if (bChandoan || icd_kemtheo.Text == "")
                {
                    Filt_ICD(phanbiet.Text);
                    listICD.BrowseToICD10(phanbiet, icd_kemtheo, c_kb_xuli, icd_kemtheo.Location.X, icd_kemtheo.Location.Y + icd_kemtheo.Height, icd_kemtheo.Width + phanbiet.Width + 2, icd_kemtheo.Height);
                }
            }
        }

        private void icd_chinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                icd_kemtheo.Focus();
        }

        private void icd_kemtheo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                phanbiet.Focus();
        }

        private void butKhuyettat_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                //DataTable tmp=m.get_data("select a.makp,b.tenkp from "+m.user+m.mmyy(ngayvv.Text)+".benhandt a,btdkp_bv b where a.makp=b.makp and a.maql="+l_maql).Tables[0];
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            frmKhuyettat f = new frmKhuyettat(m, l_maql, s_mabn, ngayvv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid,tenbs.Text,(cd_chinh.Text!="")?cd_chinh.Text:(sobo.Text!="")?sobo.Text:phanbiet.Text,false);
            f.ShowDialog();
        }

        private void butPhanungcohai_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                //if (!kiemtra()) return;
                butLuu_Click(sender, e);
                if (!bExit) return;
                ena_but(false);
            }
            frmPhanungthuoccohai f = new frmPhanungthuoccohai(m,s_makp,phanbiet.Text,s_mabn,i_userid,cd_chinh.Text+", "+sobo.Text,s_userid,l_mavaovien,l_maql,s_ngayvv,i_loai,i_maba,i_mabv,3);
            f.ShowDialog();
        }

        private void list_MouseEnter(object sender, EventArgs e)
        {
            if (list.Items.Count > 0 && mabn3.Text == "")
            {
                this.danhsach.Location = new Point(label2.Location.X, label2.Location.Y);
                this.danhsach.Size = new Size(c_hb_benhly.Right + treeView1.Right, butTiep.Top);//1008//419
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {
            c_kb_toanthan.Text = m.get_nor(-1);
            label42.Visible = false;
            label46.Visible = true;
        }

        private void label46_Click(object sender, EventArgs e)
        {
            c_kb_toanthan.Text = "";
            c_kb_toanthan.Focus();
            label42.Visible = true;
            label46.Visible = false;
        }

        private void label69_Click(object sender, EventArgs e)
        {
            c_kb_bophan.Text = m.get_nor(-6);
            label69.Visible = false;
            label70.Visible = true;
        }

        private void label70_Click(object sender, EventArgs e)
        {
            c_kb_bophan.Text = "";
            c_kb_bophan.Focus();
            label69.Visible = true;
            label70.Visible = false;
        }

        private void butgoibenh_Click(object sender, EventArgs e)
        {
            int stt = 0;
            string sott = "";
            if (list.Items.Count > 0)
            {
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = (r1["sovaovien"].ToString() == "") ? 0 : int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    sott = stt.ToString(); //stt.ToString().PadLeft(4, '0');
                }
            }
            if (sott == "") return;
            tu.Value = stt;// den.Value + 1;
            den.Value = stt;// den.Value + sonhay.Value;
            tu.Update(); den.Update();
            if (bGoi) m.goi_kham(ngaysrv, makp.Text, sott, sott, true);
            //if (this.chkLCD.Checked)
            //{
            //    this.ds.ReadXml(@"..\..\..\xml\mauLCDpk.xml");
            //    this.sizestt = int.Parse(this.ds.Tables[0].Rows[0]["s2"].ToString());
            //    string str = "";
            //    if (this.fgoi == null)
            //    {
            //        this.fgoi = new frmGoibenhKham();
            //        this.fgoi.sets = this.sizestt;
            //        this.fgoi.s_sohienthi = sott;
            //        this.fgoi.Show();
            //    }
            //    else
            //    {
            //        try
            //        {
            //            this.fgoi.sets = this.sizestt;
            //            this.fgoi.s_sohienthi = sott;
            //            this.fgoi.Show();
            //        }
            //        catch { }
            //    }
            //}
            //else 
            string input = "";
            string s_khoitao = "T00_0";
            if (bPhongkham_bangdien_kontum)
            {
                s_khoitao = "[L0F";
            }
            input = Microsoft.VisualBasic.Strings.Chr(2) + s_khoitao + sott.PadLeft(3, '0') + Microsoft.VisualBasic.Strings.Chr(3);
            if (!MSComm1.IsOpen) { OpenPort(); }
            MSComm1.Write(input);
        }
        private void f_call_bangdien_kontum(string so)
        {
            string s = "";

            string input = so.PadLeft(3, '0');
            int i_leng = input.Length;
            input = so.PadLeft(3, '0').PadRight(8 - i_leng + ((i_leng - 3) * 2), ' ');
            s = "[L0F";
            char[] values = input.ToCharArray();
            foreach (char kytu in values)
            {
                // Get the integral value of the character.
                char value = kytu; //input[i];// Microsoft.VisualBasic.Strings.Chr(input[i]);
                int m_value = value - 32;
                s = s + Microsoft.VisualBasic.Strings.Chr(m_value);//.ToString();
            }
            s = s + Microsoft.VisualBasic.Strings.Chr(255); //0xff ;
            //MSComm1.Output = s;//linh
        }

        private void tsLCD_Click(object sender, EventArgs e)
        {
            frmThongsoLCDpk_ba f = new frmThongsoLCDpk_ba(m);
            f.ShowDialog();
        }

        //private void barDausinhton_Click(object sender, EventArgs e)
        //{
        //    //l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
        //    //if (l_maql == 0)
        //    //{
        //    //    //if (!kiemtra()) return;
        //    //    butLuu_Click(null, null);
        //    //    if (!bExit) return;
        //    //    //ena_but(false);
        //    //}
        //    frmDausinhton_pk f = new frmDausinhton_pk(m,s_makp,l_maql,user+m.mmyy(ngayvv.Text)+".benhanpk",3,s_mabn);
        //    f.ShowDialog();
        //    foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".d_dausinhton where mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
        //    {
        //        mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
        //        nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
        //        huyetap.Text = r["huyetap"].ToString();
        //        nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
        //        cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
        //        chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
        //        tinh_bmi();
        //        break;
        //    }
        //}

        private void butgoilai_Click(object sender, EventArgs e)
        {
            if (bPhongkham_bangdien_hanoi && list.Items.Count > 0)
            {
                int stt = 0;
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    string sott = stt.ToString().PadLeft(4, '0');
                    fled.Send(ref sott);
                }
            }
            else if (bPhongkham_bangdien_kontum && list.Items.Count > 0)
            {
                int stt = 0;
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    f_call_bangdien_kontum(stt.ToString());
                }

            }
            else m.goi_kham(ngaysrv, makp.Text, tu.Value.ToString(), den.Value.ToString(), false);
        }

        private void barbenhmantinh_Click(object sender, EventArgs e)
        {
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }
        //linh
        private void butdausinhton_Click(object sender, EventArgs e)
        {
            decimal l_maql_pk = 0;
            if (butLuu.Tag != null)
            {
                l_maql_pk = decimal.Parse(butLuu.Tag.ToString());
            }
            if (l_maql_pk == 0)
            {
                l_maql_pk = l_matd;
            }
            frmDausinhton_pk f = new frmDausinhton_pk(m, s_makp, l_maql_pk, user + m.mmyy(ngayvv.Text) + ".benhanpk", 3, s_mabn, l_mavaovien, ngayvv.Text, mabs.Text);
            f.ShowDialog();
            foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".d_dausinhton where maql=" + l_maql_pk.ToString()+" and makp='"+s_makp+"' order by ngay desc").Tables[0].Rows)
            {
                mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString().Trim('0').Trim('.') : "";
                huyetap.Text = r["huyetap"].ToString();
                nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                tinh_bmi();
                break;
            }
        }
        //end linh
        private void butbenhmantinh_Click(object sender, EventArgs e)
        {
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        //private void barchamsoc_Click(object sender, EventArgs e)
        //{
        //    frmChamsoc f = new frmChamsoc(m, s_mabn, l_maql, l_maql, sovaovien.Text, s_makp, hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), ngayvv.Text, sothe.Text, "", "", ngayvv.Text, s_mabs, i_userid, s_nhomkho, s_userid, cd_chinh.Text, tenkp.Text, bAdmin);
        //    f.ShowDialog(this);
        //}

        //private void bartruyendich_Click(object sender, EventArgs e)
        //{
        //    frmTruyendich f = new frmTruyendich(m, s_mabn, l_maql, l_maql, sovaovien.Text, s_makp, hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), ngayvv.Text, sothe.Text, "", "", ngayvv.Text, s_mabs, i_userid, s_nhomkho, s_userid, cd_chinh.Text, tenkp.Text, bAdmin);
        //    f.ShowDialog(this);
        //}
        //linh
        void Filt_benhvien(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBenhvien.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "tenbv like '%" + ten.Trim() + "%'";
                listBenhvien.Visible = dv.Table.Rows.Count > 0;
            }
            catch { }
        }
        private void txtTenbv_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txtTenbv)
            {
                Filt_benhvien(txtTenbv.Text);
                listBenhvien.BrowseToICD10(txtTenbv, mabv, c_kb_chuy, mabv.Location.X + mabv.Width, mabv.Location.Y + mabv.Height , mabv.Width + txtTenbv.Width + 2, mabv.Height);//+mabs.Height
            }
        }

        private void txtTenbv_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBenhvien.Visible)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter) listBenhvien.Focus();
                else if (e.KeyCode == Keys.Escape)
                {
                    listBenhvien.Hide();
                }
            }
        }

        private void txtTenbv_EnabledChanged(object sender, EventArgs e)
        {
            if (dtdmbenhvien == null)
            {
                dtdmbenhvien = m.get_data("select mabv,tenbv,mahang,ngoaidm,maloai from " + user + ".tenvien where mabv<>'" + s_mabv + "'").Tables[0];
                listBenhvien.DisplayMember = "MABV";
                listBenhvien.ValueMember = "TENBV";
                listBenhvien.DataSource = dtdmbenhvien;
            }
        }

        private void txtTenbv_Validated(object sender, EventArgs e)
        {
            if (!listBenhvien.Focus())
            {
                listBenhvien.Hide();
            }
            
        }

        private void listBenhvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mabv.Text != "")
                {
                    mabv_Validated(sender, null);
                }
            }
        }

        private void khoa_Validated(object sender, EventArgs e)
        {
            tenkhoa.SelectedValue = khoa.Text;
        }
        //khuong
        private void frmKhambenh_tmh_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.writeXml("thongso", chkTudongchonthongso.Name, chkTudongchonthongso.Checked ? "1" : "0");
        }

        private void butTiemchung_Click(object sender, EventArgs e)
        {
            DataTable dtPhieu = new DataTable();
            s_mabn = mabn2.Text + mabn3.Text;
            if (l_maql != 0 && tenkp.Items.Count == 1)
            {
                sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return;
                    }
                }
            }

            if (m.bCD_BS_Chidinh && tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            string s_chandoan = "";
            if (sobo.Text != "") s_chandoan = sobo.Text + ";";
            if (cd_chinh.Text != "") s_chandoan += cd_chinh.Text + ";";
            if (phanbiet.Text != "") s_chandoan += phanbiet.Text;
            if (chkTudongchonthongso.Checked)
            {
                decimal l_duyet1 = 0;
                string s_manguon = d.get_data("select nguon from " + m.user + ".d_dmphieu where id=2").Tables[0].Rows[0][0].ToString();
                sql = "select id,ten from " + m.user + ".d_loaiphieu where loai=2 and id not in(select phieu from " + m.user + m.mmyy(ngayvv.Text) + ".d_duyet where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and loai=2 and done<>0)order by ten";
                dtPhieu = m.get_data(sql).Tables[0];
                DataRow drttKho = m.get_data("select a.makp,b.ten,b.somay,b.id,b.matutruc,b.makho from " + m.user + ".btdkp_bv a, " + m.user + ".d_duockp b where a.makp=b.makp and a.makp='" + s_makp + "'").Tables[0].Rows[0];
                try
                {
                    l_duyet1 = decimal.Parse(d.get_data("select id from " + m.user + mmyy + ".d_duyet where phieu=" + dtPhieu.Rows[0]["id"].ToString() + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngayvv.Substring(0, 10) + "' and makp=" + drttKho["id"].ToString() + " and loai=2").Tables[0].Rows[0][0].ToString());
                }
                catch { l_duyet1 = 0; }
                dllvpkhoa_chidinh.frmGoiDichvu f = new dllvpkhoa_chidinh.frmGoiDichvu(1, int.Parse(drttKho["id"].ToString()), ngayvv.Text.Substring(0, 10), 2, int.Parse(dtPhieu.Rows[0]["id"].ToString()), m.mmyy(ngayvv.Text), drttKho["makho"].ToString(), s_manguon, l_duyet1, s_mabn,
                       l_mavaovien, l_maql, 0, i_userid, 0, int.Parse(drttKho["matutruc"].ToString()), ngayvv.Text, "", "", true, 0, i_madoituong, s_makp, 0, sothe.Text, s_icd_chinh, s_chandoan, s_mabs,
                       i_maba, false, false, 0);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }
            else
            {
                frmChonthongso f1 = new frmChonthongso(m, 1, 2, 0, s_makp, false, s_nhomkho, this.i_userid);//linh 16102012
                f1.ShowInTaskbar = false;
                f1.ShowDialog(this);
                if (f1.s_makp != "")
                {
                    dllvpkhoa_chidinh.frmGoiDichvu f = new dllvpkhoa_chidinh.frmGoiDichvu(f1.i_nhom, f1.i_makp, f1.s_ngay, 2, f1.i_phieu, f1.s_mmyy, f1.s_makho, f1.s_manguon, f1.l_duyet, s_mabn,
                        l_mavaovien, l_maql, 0, i_userid, 0, f1.i_makp, ngayvv.Text, "", "", true, 0, i_madoituong, s_makp, 0, sothe.Text, s_icd_chinh, s_chandoan, s_mabs,
                        i_maba, false, false, 0);
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }
            }
        }

        private void butChamsoc_Click(object sender, EventArgs e)
        {
            if (tenbs.Text == "" || mabs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            frmChamsoc f = new frmChamsoc(m, mabn2.Text + mabn3.Text, l_maql, 0, "", s_makp, hoten.Text, namsinh.Text, phai.Text, sonha.Text + ", " + thon.Text + ", " + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, ngayvv.Text, sothe.Text, "", "", ngayvv.Text, mabs.Text, i_userid, "", s_userid, cd_chinh.Text, tenkp.Text, false);
            f.FormParent = this;
            f.ShowDialog(this);
        }

        private void butTruyendich_Click(object sender, EventArgs e)
        {
            if (tenbs.Text == "" || mabs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            frmTruyendich f = new frmTruyendich(m, mabn2.Text + mabn3.Text, l_maql, 0, "", s_makp, hoten.Text, namsinh.Text, phai.Text, sonha.Text + ", " + thon.Text + ", " + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, ngayvv.Text, sothe.Text, "", "", ngayvv.Text, mabs.Text, i_userid, "", s_userid, cd_chinh.Text, tenkp.Text, false);
            f.ShowDialog(this);
        }

        private void butPhieughichep_Click(object sender, EventArgs e)
        {
            if (tenbs.Text == "" || mabs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            frmThongtinBLGD f = new frmThongtinBLGD(m, mabn2.Text + mabn3.Text, (decimal)l_mavaovien, (decimal)l_maql, m.mmyy(ngayvv.Text), i_userid, ngayvv.Text);
            f.ShowInTaskbar = false;
            f.ShowDialog();
        }

        private void butPhieusangloc_Click(object sender, EventArgs e)
        {
            if (tenbs.Text == "" || mabs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                sobo.Focus();
                return;
            }
            l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
            if (l_maql == 0)
            {
                butLuu_Click(null, null);
                if (!bExit) return;
            }
            frmPhieusanglocBLGD f = new frmPhieusanglocBLGD(m, mabn2.Text + mabn3.Text, hoten.Text, (decimal)l_mavaovien, (decimal)l_maql, int.Parse(tuoi.Text), c_lydo.Text, phai.Text, ngayvv.Text, tenkp.SelectedValue.ToString(), i_userid, thon.Text, matt.Text, mapxa1.Text + mapxa2.Text, maqu1.Text + maqu2.Text);
            f.ShowInTaskbar = false;
            f.ShowDialog();
        }
        //end khuong
        string load_tiensu()
        {
            string s_tiensu = "";
            DataSet dstmp = m.get_data("select distinct noidung from " + user + ".theodoitsu where mabn='" + s_mabn + "'");
            if (dstmp != null)
            {
                foreach (DataRow rts in dstmp.Tables[0].Rows)
                {
                    s_tiensu += rts["noidung"].ToString() + ";";
                }
                c_hb_banthan.Text = s_tiensu.Trim(';');
            }
            return s_tiensu;
        }

        private void butTiemchung_Enter(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            Color col = but.ForeColor;
            but.Tag = col;
            but.ForeColor=Color.Teal;
        }

        private void butTiemchung_Leave(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Tag != null)
            {
                but.ForeColor = (Color)but.Tag;
            }
            else
            {
                but.ForeColor = Color.Black;
            }
        }
        void upd_xutri_hen()
        {
            string ngay = "";
            if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
            {
                if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                {
                    m.upd_hen(ngayvv.Text, l_maql, hen_ngay.Value, hen_ghichu.Text, hen_loai.SelectedIndex, (chkTiepdon.Checked) ? 1 : 0);
                    if (hen_loai.SelectedIndex != 0)
                    {
                        DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                        switch (hen_loai.SelectedIndex)
                        {
                            case 1: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(Convert.ToInt16(hen_ngay.Value)));
                                break;
                            case 2: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * Convert.ToInt16(hen_ngay.Value)));
                                break;
                            case 3: ngay = m.DateToString("dd/MM/yyyy", dt.AddMonths(Convert.ToInt16(hen_ngay.Value)));
                                break;
                            default: ngay = m.DateToString("dd/MM/yyyy", dt.AddYears(Convert.ToInt16(hen_ngay.Value)));
                                break;
                        }
                        if (m.mmyy(ngayvv.Text) == m.mmyy(ngay))
                        {
                            decimal maql1 = m.get_maql_tiepdon_mmyy(s_mabn, ngay + " 07:00");
                            string s_sovaovien = "";
                            foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngay) + ".tiepdon where maql=" + maql1).Tables[0].Rows)
                                s_sovaovien = r["sovaovien"].ToString();
                            if (s_sovaovien == "")
                            {
                                s_sovaovien = (bStt) ? m.getSttkham(ngay, makp.Text).ToString() : m.get_sokham(ngay, makp.Text, i_sokham).ToString();
                                string s_hen = hen_ghichu.Text.Trim() + ", Thứ tự tái khám " + s_sovaovien;
                                m.upd_hen(ngayvv.Text, l_maql, hen_ngay.Value, s_hen, hen_loai.SelectedIndex, (chkTiepdon.Checked) ? 1 : 0);
                                hen_ghichu.Text = s_hen;
                            }
                            m.upd_tiepdon_mmyy(s_mabn, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), s_sovaovien, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), bnmoi.SelectedIndex, i_userid, LibMedi.AccessData.Taikham, loai.SelectedIndex, l_matd);
                            if (bHen_dangkylai) m.execute_data("update " + user + m.mmyy(ngay) + ".tiepdon set done='x' where maql=" + maql1);
                            m.upd_lienhe(ngay, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                            //Tu:28/06/2011
                            if (m.bSoluutruPK_PL_NGT_tudong)
                                m.execute_data("update " + user + m.mmyy(ngay) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                            //end Tu
                            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                            if (int.Parse(so.Substring(0, 2)) > 0)
                            {
                                if (!m.upd_bhyt(ngay, s_mabn, maql1, sothe.Text, denngay.Text, noidk.Text, 0, tungay.Text, traituyen))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            decimal maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                            string s_sovaovien = "";
                            foreach (DataRow r in m.get_data("select * from " + xxx + ".tiepdon where maql=" + maql1).Tables[0].Rows)
                                s_sovaovien = r["sovaovien"].ToString();
                            if (s_sovaovien == "")
                            {
                                s_sovaovien = (bStt) ? m.getSttkham_hen(ngay, makp.Text).ToString() : m.get_sokham_hen(ngay, makp.Text, i_sokham).ToString();
                                string s_hen = hen_ghichu.Text.Trim() + ", Thứ tự tái khám " + s_sovaovien;
                                m.upd_hen(ngayvv.Text, l_maql, hen_ngay.Value, s_hen, hen_loai.SelectedIndex, (chkTiepdon.Checked) ? 1 : 0);
                                hen_ghichu.Text = s_hen;
                            }
                            m.upd_tiepdon(s_mabn, l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), s_sovaovien, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), bnmoi.SelectedIndex, i_userid, LibMedi.AccessData.Taikham, loai.SelectedIndex);
                            if (bHen_dangkylai) m.execute_data("update " + user + ".tiepdon set done='x' where maql=" + maql1);
                            m.upd_lienhe(maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                            //Tu:28/06/2011
                            if (m.bSoluutruPK_PL_NGT_tudong)
                                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                            //end Tu
                            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                            if (int.Parse(so.Substring(0, 2)) > 0)
                            {
                                if (!m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, noidk.Text, 0, tungay.Text, traituyen))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                    return;
                                }
                            }
                        }
                    }
                    else if (hen_loai.SelectedIndex == 0 && !chkTiepdon.Checked) upd_hen();//hen_butin_Click(sender,e);
                }
            }
            else
            {
                if (hen_loai.SelectedIndex != 0)
                {
                    DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                    switch (hen_loai.SelectedIndex)
                    {
                        case 1: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 2: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 3: ngay = m.DateToString("dd/MM/yyyy", dt.AddMonths(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        default: ngay = m.DateToString("dd/MM/yyyy", dt.AddYears(Convert.ToInt16(hen_ngay.Value)));
                            break;
                    }
                    m.execute_data("delete from " + user + m.mmyy(ngay) + ".tiepdon where mavaovien=" + l_matd + " and noitiepdon=" + LibMedi.AccessData.Taikham + " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "'");
                }
                else if (hen_loai.SelectedIndex == 0 && !chkTiepdon.Checked)
                {
                    DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                    for (int i = 1; i <= Convert.ToInt16(hen_ngay.Value); i++)
                    {
                        ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(i));
                        m.execute_data("delete from " + user + m.mmyy(ngay) + ".tiepdon where mavaovien=" + l_matd + " and noitiepdon=" + LibMedi.AccessData.Taikham + " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "'");
                    }
                }
            }
        }

        private void tbutvantay_Click(object sender, EventArgs e)
        {
            lay_mabn_vantay();
        }
        string f_get_mabn()
        {
            string _mabn = "";
            if (mabn3.Text.Trim() == "") return "";
            _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlenght_mabn - 2);
            if (i_maxlenght_mabn > 8) _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlenght_mabn - 4);
            return _mabn;
        }
        void lay_mabn_vantay()
        {
            string tmp_mabn = (mabn3.Text.Trim() != "") ? f_get_mabn() : "";
            string ma_vantay = "";
            FingerApp.FrmNhanDang fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == i_maxlenght_mabn)
            {
                mabn2.Text = ma_vantay.Substring(0, 2);
                mabn3.Text = ma_vantay.Substring(2);
                s_mabn = f_get_mabn();
                mabn3_Validated(null, null);
                ngayvv.Focus();
                SendKeys.Send("{Home}");
            }
        }
        void empty_dausinton()
        {
            mach.Text = ""; nhietdo.Text = ""; nhiptho.Text = ""; huyetap.Text = ""; cannang.Text = ""; icd_kemtheo.Text = "";
            chieucao.Text = "";
        }
        void load_dausinhton()
        {
            decimal l_maql_pk = 0;
            if (butLuu.Tag != null)
            {
                l_maql_pk = decimal.Parse(butLuu.Tag.ToString());
            }
            if (l_maql_pk == 0)
            {
                l_maql_pk = l_maql;
            }
            foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".d_dausinhton where maql=" + l_maql_pk.ToString() + " and makp='" + s_makp + "' order by ngay desc").Tables[0].Rows)
            {
                mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString().Trim('0').Trim('.') : "";
                huyetap.Text = r["huyetap"].ToString();
                nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                tinh_bmi();
                break;
            }
        }

        private void butGiayxacnhan_Click(object sender, EventArgs e)
        {
            Inxacnhan_baolucgiadinh();
        }
        void Inxacnhan_baolucgiadinh()
        {
            DataSet dsGiayxn = new DataSet();
            string tiensu = "";
            //string user = m.user;
            string _mmyy = m.mmyy(ngayvv.Text);
            if (m.bMmyy(_mmyy))
            {
                sql = "select noidung from " + user + ".theodoitsu where mabn='" + s_mabn + "'";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    tiensu += r["noidung"].ToString() + "; ";
                }
                sql = "select a.mabn,a.hoten,case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end ngaysinh,case when a.phai=0 then '" + lan.Change_language_MessageText("Nam") + "' else '" + lan.Change_language_MessageText("Nữ") + "' end phai, a.cmnd,a.sonha,a.thon, b.tenpxa, ";
                sql += " c.tenquan, d.tentt,e.tennn || (case when trim(a.cholam)='' then '' else ' - '||a.cholam end) nghenghiep ,to_char(f.ngay,'dd/mm/yyyy hh24:mi') ngayvaopk, ";
                sql += " to_char(f.ngay,'dd/mm/yyyy hh24:mi') ngayrapk, to_char(fff.ngay,'dd/mm/yyyy hh24:mi') ngayvaocc,case when fff.ngayrv is null then to_char(Now(),'dd/mm/yyyy hh24:mi') else to_char(fff.ngayrv,'dd/mm/yyyy hh24:mi') end ngayracc, ";
                sql += " to_char(ff.ngay,'dd/mm/yyyy hh24:mi') ngayvaonoitru,to_char(ffa.ngay,'dd/mm/yyyy hh24:mi') ngayranoitru, ";
                sql += " 0 noitru,'" + tiensu + "' tiensu,f.chandoan chandoanpk, ";
                sql += " ffa.chandoan chandoannoitru,fff.chandoan chandoancc,g.kedon,g.tinhtrangsk,i.tenbv chuyenvien ";
                sql += " from " + user + ".btdbn a left join " + user + ".btdpxa b on a.maphuongxa=b.maphuongxa left join " + user + ".btdquan c on a.maqu=c.maqu left join " + user + ".btdtt d on a.matt=d.matt  ";
                sql += " left join " + user + ".btdnn e on a.mann=e.mann  ";
                sql += " left join " + user + _mmyy + ".benhanpk f on a.mabn=f.mabn and f.maql=" + l_maql;
                sql += " left join " + user + ".benhandt ff on a.mabn=ff.mabn and ff.mavaovien=" + l_mavaovien;
                sql += " left join " + user + ".xuatvien ffa on ff.maql=ffa.maql ";
                sql += " left join " + user + _mmyy + ".benhancc fff on a.mabn=fff.mabn and fff.maql=" + l_maql;
                sql += " left join " + user + ".blgd_ra g on a.mabn=g.mabn and g.mavaovien=" + l_mavaovien;
                sql += " left join " + user + ".chuyenvien h on h.maql=" + l_maql;
                sql += " left join " + user + ".tenvien i on h.mabv=i.mabv  ";
                sql += " where a.mabn='" + s_mabn + "' ";
                dsGiayxn = m.get_data(sql);
                if (dsGiayxn.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), s_msg);
                    return;
                }
                //dsGiayxn.Tables[0].Rows[0]["tiensu"] = tiensu;
                if (chkXml.Checked)
                {
                    try
                    {
                        dsGiayxn.WriteXml("..//..//dataxml//rptGiayxacnhanBLGD.xml", XmlWriteMode.WriteSchema);
                    }
                    catch { }
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsGiayxn.Tables[0], "rptGiayxacnhanBLGD.rpt", "", "", "", "", "", "", "", "", "", "");
                f.ShowDialog();
            }
        }

        private void butPhieuchuyenkhamchuyenkhoa_Click(object sender, EventArgs e)
        {
            if (maxutri.Text.IndexOf("06,") != -1)
            {
                //s_chonxutri = chon_xutri();
                DataTable dtPhieu = new DataTable();
                s_mabn = mabn2.Text + mabn3.Text;
                if (l_maql != 0 && tenkp.Items.Count == 1)
                {
                    sql = "select a.makp,b.tenkp from " + m.user + m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql;
                    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ") ";
                    if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
                    DataTable tmp = m.get_data(sql).Tables[0];
                    if (tmp.Rows.Count > 0)
                    {
                        if (tmp.Rows[0]["makp"].ToString() != makp.Text)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Thông tin đã cập nhật vào ") + tmp.Rows[0]["tenkp"].ToString() + lan.Change_language_MessageText("\n Bạn không có quyền chỉnh sửa !"), LibMedi.AccessData.Msg);
                            butBoqua.Focus();
                            return;
                        }
                    }
                }
                if (m.bCD_BS_Chidinh && tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                    mabs.Focus();
                    return;
                }
                if (sobo.Text == "" && icd_chinh.Text == "" && icd_kemtheo.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán trong khám bệnh !"), LibMedi.AccessData.Msg);
                    sobo.Focus();
                    return;
                }
                l_maql = m.get_maql_mmyy(3, s_mabn, makp.Text, ngayvv.Text, false);
                if (l_maql == 0)
                {
                    butLuu_Click(null, null);
                    if (!bExit) return;
                }

                frmPhieukhamck f = new frmPhieukhamck(m, decimal.Parse(l_maql.ToString()), hoten.Text, txtTenbv.Text, namsinh.Text, tuoi.Text, phai.Text, sonha.Text + ", " + thon.Text + ", " + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, tenbs.Text, ngayvv.Text, i_userid);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí chuyển viện !"), s_msg);
                xutri.Focus();
                return;
            }
        }

        private void c_kb_tai_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c_kb_tai) setFcous(c_kb_mui);
        }

        private void c_kb_mui_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c_kb_mui) setFcous(c_kb_hong);
        }

        private void c_kb_hong_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c_kb_hong) setFcous(c_kb_tomtat);
        }
        void OpenPort()
        {
            ///Baudrate, parity, databit,topbit
            string setting = "9600,n,8,1";
            string ports = "COM1", _Parity = "";
            try
            {
                DataSet dsCom = new DataSet();
                dsCom.ReadXml(@"..\..\..\xml\m_cauhinh.xml", XmlReadMode.ReadSchema);
                ports = dsCom.Tables[0].Rows[0]["port"].ToString().ToUpper();
                setting = dsCom.Tables[0].Rows[0]["config"].ToString();
            }
            catch
            {
                //bBangDienPhongKham = false;
                MessageBox.Show(lan.Change_language_MessageText("Không thể xuất số thứ tự ra bảng điện."));
                return;
            }
            bool error = false;
            string[] set = setting.Split(',');
            switch (set[1].ToString())
            {
                case "n":
                    _Parity = "None";
                    break;
                case "e":
                    _Parity = "Even";
                    break;
                case "o":
                    _Parity = "Odd";
                    break;
            }
            if (MSComm1.IsOpen) MSComm1.Close();
            MSComm1.BaudRate = int.Parse(set[0].ToString());
            MSComm1.DataBits = int.Parse(set[2].ToString());
            MSComm1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), set[3].ToString());
            MSComm1.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
            MSComm1.PortName = ports;

            try
            {
                // Open the port
                MSComm1.Open();
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }
            if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        //end linh
    }
}
