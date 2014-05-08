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

namespace libxTutruc
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmKhambenh : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private int sizestt = 120;
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
        //private frmGoibenhKham fgoi = null;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
        private string xxx, user, nam, s_userid, s_makp, s_mabn, s_msg, s_ngayvv, sql, s_madoituong, s_mabs, s_nhomkho, ngaysrv, FileType, u00 = "U00", s_ngaydk = "", maso = "", sNhapvien_kocongkham_madoituong;
        private int i_userid, i_mabv, i_maba, i_bangoaitru, iChidinh, iHaophi;
		private long l_maql=0,l_matd=0,d_id=0,lTraituyen=0;
        private decimal Congkham = 0, bhyttra, bntra;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtxutri=new DataTable();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
        private DataSet dsxmlin = new DataSet();
        private DataTable dtbd = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtkpfull = new DataTable();
        private DataTable dtdt1 = new DataTable();
		private System.Windows.Forms.ComboBox tenba;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox mabn1;
		private MaskedTextBox.MaskedTextBox mabn2;
		private MaskedTextBox.MaskedTextBox mabn3;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox loaituoi;
		private System.Windows.Forms.TextBox maba;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private MaskedTextBox.MaskedTextBox icd_kemtheo;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.ComboBox tenloaibv;
		private System.Windows.Forms.TextBox loaibv;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private MaskedTextBox.MaskedTextBox mabv;
		private System.Windows.Forms.ComboBox tenbv;
		private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.Label label49;
		private System.Windows.Forms.CheckBox taibien;
		private System.Windows.Forms.CheckBox bienchung;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private int songay = 30, iTreem6, iTreem15, iKhamnhi, i_sokham, hh1, hh2, hh3, mm1, mm2, mm3, imavp_congkham,iTraituyen;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bHiends, b_soluutru, bLuutru_Mabn, b_sovaovien, bXutri_noitru, bXutri_ngoaitru, bChuyenkhoasan, bKhamthai, bTiepdon, bDanhmuc_nhathuoc, bBacsy, bSoluutru, bTudong = false, bChuky = false, bGoi, bRight, bDangky_homqua, bDuyet_khambenh, bSothe_ngay_huong, bChuyenkham_chandoan, bXutri_hen_koin, bTraituyen, bPhongkham_bangdien_hanoi;
        private bool bPhongkham_khongduocxutri_chuyenvien = false;
		private System.Windows.Forms.CheckBox giaiphau;
		private System.ComponentModel.IContainer components;
        private bool b_khambenh, b_bacsi, b_trongngoai, bDenngay_sothe, bChandoan, b701424, bNew, bSuadoituong, bPhongkham_chidinh, bSothe_mabn, bInchitiet, bDichvu_vpkb, bIn = false, bCongkham, bClear, bChuyenkham_dscho, bXutri_phongluu, bChuyenkham_thuphi, bTaikham_v_chidinh, bTaikham_chiphi_inrieng, bPhongkham_chandoan, bChuyenkham_tinhcongkham = false, bChuyenkham_tinh_congkham_dtthuphi = false, bXemlai_toa = false, bChandoan_kemtheo_icd10=true;
		private System.Windows.Forms.Panel phanhchinh;
		private System.Windows.Forms.ComboBox tennuoc;
		private System.Windows.Forms.ComboBox tendantoc;
		private System.Windows.Forms.ComboBox tentqx;
		private System.Windows.Forms.TextBox cholam;
		private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.TextBox manuoc;
		private System.Windows.Forms.TextBox madantoc;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.ComboBox tennn;
		private System.Windows.Forms.ComboBox tenquan;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.ComboBox tenpxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lcholam;
		private MaskedTextBox.MaskedTextBox sonha;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label lphai;
		private System.Windows.Forms.Label lmann;
		private System.Windows.Forms.Label lsonha;
		private System.Windows.Forms.Label lmanuoc;
		private System.Windows.Forms.Label lmadantoc;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.Label lmaphuongxa;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.TextBox madoituong;
		private System.Windows.Forms.ComboBox tendentu;
		private System.Windows.Forms.ComboBox tendoituong;
		private MaskedTextBox.MaskedTextBox icd_noichuyenden;
		private System.Windows.Forms.Label label31;
		private MaskedTextBox.MaskedTextBox qh_dienthoai;
		private System.Windows.Forms.TextBox qh_diachi;
		private System.Windows.Forms.TextBox qh_hoten;
		private System.Windows.Forms.TextBox quanhe;
		private MaskedTextBox.MaskedTextBox sothe;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox dentu;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Panel pvaovien;
		private System.Windows.Forms.ComboBox tennhantu;
		private System.Windows.Forms.TextBox nhantu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox gphaubenh;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngaysinh;
		private System.Windows.Forms.ComboBox cmbTaibien;
		private System.Windows.Forms.Label label9;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private LibList.List listdstt;
		private System.Windows.Forms.TreeView treeView1;
        private string s_icd_noichuyenden, s_icd_chinh, s_icd_kemtheo, s_mabv, s_noicap, s_chonxutri = "", s_tungay, d_mmyy, khoa_save = "", xutri_save = "", pathImage, s_ngaymakp="",ngay1,ngay2,ngay3;
		private System.Windows.Forms.TextBox cd_chinh;
		private LibList.List listICD;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private System.Windows.Forms.TextBox cd_noichuyenden;
        private System.Windows.Forms.GroupBox danhsach;
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.Label label10;
        private MaskedTextBox.MaskedTextBox soluutru;
		private LibList.List listBS;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox khoa;
		private System.Windows.Forms.ComboBox tenkhoa;
        private System.Windows.Forms.CheckedListBox xutri;
        private MaskedTextBox.MaskedTextBox maxutri;
		private System.Windows.Forms.Panel khamthai;
		private MaskedTextBox.MaskedTextBox para4;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label llydo;
		private MaskedBox.MaskedBox ngaysanh;
		private MaskedBox.MaskedBox kinhcc;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox lydo;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox bnmoi;
		private System.Windows.Forms.Label l_bnmoi;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.Panel pmat;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label33;
		private MaskedTextBox.MaskedTextBox mp;
		private MaskedTextBox.MaskedTextBox mt;
		private MaskedTextBox.MaskedTextBox nhanapp;
		private MaskedTextBox.MaskedTextBox nhanapt;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button butIncv;
        private dllReportM.Print print = new dllReportM.Print();
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton11;
        private ToolStripLabel tlbl;
        private ToolStripLabel tlblhd;
		private DataTable dticd=new DataTable();
        private MaskedBox.MaskedBox giovv;
        private Label label16;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private AsYetUnnamed.MultiColumnListBox list;
        private Button butInchitiet;
        private CheckBox chkXem;
        private CheckBox chkToathuoc;
        private DataTable dtletet = new DataTable();
        private dichso.numbertotext doiso = new dichso.numbertotext();
        private FileStream fstr;
        private System.IO.MemoryStream memo;
        private TextBox tim;
        private ToolTip toolTip1;
        private Label lblso;
        private Button button1;
        private Button button2;
        private PictureBox pic;
        private byte[] image;        
        private Panel hen;
        private Label label17;
        private NumericUpDown hen_ngay;
        private TextBox hen_ghichu;
        private ComboBox hen_loai;
        private Label label32;
        private CheckBox chkTiepdon;
        private Bitmap map;
        private DataTable dtkp=new DataTable();
        private Panel dausinhton;
        private MaskedBox.MaskedBox nhietdo;
        private Label label38;
        private Label label39;
        private MaskedTextBox.MaskedTextBox mach;
        private Label label41;
        private Label label43;
        private Label label44;
        private Label label45;
        private Panel pgoi;
        private Button butGoilai;
        private Button butGoi;
        private NumericUpDown sonhay;
        private NumericUpDown den;
        private NumericUpDown tu;
        private Label label50;
        private Label lblTrieuchung;
        private TextBox trieuchung;
        private DataTable dtgia = new DataTable();
        private bool bNgtru_dt_makp, bTaikham_hen, bNhapvien_kocongkham;
        private int dt_ngtru = 0, Taikham_songay;
        private ToolStripButton toolStripButton12;
        private Button butXthuoc;
        private Label label12;
        private TextBox phanbiet;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton13;
        private ToolStripSeparator toolStripSeparator11;
        private string makp_kho_dt, madoituong_hen;
        private Label label58;
        private Label label55;
        private MaskedTextBox.MaskedTextBox cao;
        private Label label54;
        private Label label59;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton toolStripButton14;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton toolStripButton15;
        private MaskedTextBox.MaskedTextBox nang;
        private bool bHaophi, bHaophi_doituongvao;
        private CheckBox chkXml;
        private MaskedTextBox.MaskedTextBox huyetap;
        private ComboBox traituyen;
        //private Project1.Form1 fled;
        private int i_com = 1;
        private DataTable dtlist = new DataTable();
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem chkLCD;
        private ToolStripMenuItem lblLCD;
        private Button hen_in;
        ////linh
        //int[] a_fon = new int[21];
        //int L1, L2, L3, L4, Ds, Checksum;
        //string st = "";
        //private AxMSCommLib.AxMSComm MSComm1;
        //bool bBangDienPhongKham = false;
        ////end
        private string s_nhomhaophi;

		public frmKhambenh(LibMedi.AccessData acc,string makp,string hoten,int userid,int mabv,bool sovaovien,bool soluutru,string _madoituong,string _mabs,string _nhomkho,bool _right)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;v=new LibVienphi.AccessData();
            if (m.bBogo) tv.GanBogo(this, textBox111);
			s_makp=makp;s_madoituong=_madoituong;s_mabs=_mabs;
			s_userid=hoten;i_userid=userid;i_mabv=mabv;
			b_soluutru=soluutru;s_nhomkho=_nhomkho;
            bnmoi.Items.Clear(); bRight = _right;
            bnmoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Mới"),
                                                 lan.Change_language_MessageText("Cũ")});

            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("năm tuổi"),
                                                 lan.Change_language_MessageText("tháng tuổi"),
                                                 lan.Change_language_MessageText("ngày tuổi"),
                                                 lan.Change_language_MessageText("giờ tuổi")});
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhambenh));
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
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tenloaibv = new System.Windows.Forms.ComboBox();
            this.loaibv = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.tenbv = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.taibien = new System.Windows.Forms.CheckBox();
            this.bienchung = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.giaiphau = new System.Windows.Forms.CheckBox();
            this.phanhchinh = new System.Windows.Forms.Panel();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.tqx = new System.Windows.Forms.TextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.lmaqu = new System.Windows.Forms.Label();
            this.lcholam = new System.Windows.Forms.Label();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.lmatt = new System.Windows.Forms.Label();
            this.ltqx = new System.Windows.Forms.Label();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.lthon = new System.Windows.Forms.Label();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.trieuchung = new System.Windows.Forms.TextBox();
            this.lblTrieuchung = new System.Windows.Forms.Label();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.dausinhton = new System.Windows.Forms.Panel();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.nang = new MaskedTextBox.MaskedTextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.khamthai = new System.Windows.Forms.Panel();
            this.ngaysanh = new MaskedBox.MaskedBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.kinhcc = new MaskedBox.MaskedBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pmat = new System.Windows.Forms.Panel();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.denngay = new MaskedBox.MaskedBox();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.icd_noichuyenden = new MaskedTextBox.MaskedTextBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.loai = new System.Windows.Forms.ComboBox();
            this.listdstt = new LibList.List();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
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
            this.label34 = new System.Windows.Forms.Label();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.danhsach = new System.Windows.Forms.GroupBox();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.lblso = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.butRef = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.gphaubenh = new System.Windows.Forms.ComboBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.cmbTaibien = new System.Windows.Forms.ComboBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.khoa = new System.Windows.Forms.TextBox();
            this.tenkhoa = new System.Windows.Forms.ComboBox();
            this.xutri = new System.Windows.Forms.CheckedListBox();
            this.maxutri = new MaskedTextBox.MaskedTextBox();
            this.llydo = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.tlblhd = new System.Windows.Forms.ToolStripLabel();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkToathuoc = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.hen = new System.Windows.Forms.Panel();
            this.chkTiepdon = new System.Windows.Forms.CheckBox();
            this.hen_ghichu = new System.Windows.Forms.TextBox();
            this.hen_loai = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.hen_ngay = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.pgoi = new System.Windows.Forms.Panel();
            this.butGoilai = new System.Windows.Forms.Button();
            this.butGoi = new System.Windows.Forms.Button();
            this.sonhay = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.phanbiet = new System.Windows.Forms.TextBox();
            this.butXthuoc = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.butInchitiet = new System.Windows.Forms.Button();
            this.butIncv = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.hen_in = new System.Windows.Forms.Button();
            this.phanhchinh.SuspendLayout();
            this.pvaovien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pmat.SuspendLayout();
            this.danhsach.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.hen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Enabled = false;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(736, 19);
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
            this.label2.Location = new System.Drawing.Point(686, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(135, 41);
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
            this.label5.Location = new System.Drawing.Point(10, 62);
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
            this.mabn1.Location = new System.Drawing.Point(200, 13);
            this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn1.MaxLength = 8;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(45, 21);
            this.mabn1.TabIndex = 1;
            this.mabn1.Visible = false;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(71, 42);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 2;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(94, 42);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(44, 21);
            this.mabn3.TabIndex = 3;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(133, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(196, 64);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 6;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(222, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "y.o.",
            "m.o.",
            "d.o.",
            "h.o."});
            this.loaituoi.Location = new System.Drawing.Point(292, 64);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(89, 21);
            this.loaituoi.TabIndex = 8;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(168, 13);
            this.maba.MaxLength = 3;
            this.maba.Name = "maba";
            this.maba.Size = new System.Drawing.Size(30, 21);
            this.maba.TabIndex = 0;
            this.maba.Visible = false;
            this.maba.Validated += new System.EventHandler(this.maba_Validated);
            this.maba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maba_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(263, 64);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
            this.tuoi.TabIndex = 7;
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(196, 42);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(185, 21);
            this.hoten.TabIndex = 4;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(394, 169);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(102, 23);
            this.label40.TabIndex = 96;
            this.label40.Text = "Xử trí :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(394, 41);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(102, 23);
            this.label42.TabIndex = 200;
            this.label42.Text = "&Bệnh chính :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(492, 42);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 21);
            this.icd_chinh.TabIndex = 20;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(492, 64);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
            this.icd_kemtheo.TabIndex = 22;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_kemtheo_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label46.Location = new System.Drawing.Point(395, 63);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(101, 23);
            this.label46.TabIndex = 105;
            this.label46.Text = "Bệnh kèm theo :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenloaibv
            // 
            this.tenloaibv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenloaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenloaibv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenloaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloaibv.Location = new System.Drawing.Point(512, 256);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(270, 21);
            this.tenloaibv.TabIndex = 33;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(492, 256);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(18, 21);
            this.loaibv.TabIndex = 32;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label47.Location = new System.Drawing.Point(396, 255);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(98, 23);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label48.Location = new System.Drawing.Point(396, 278);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(98, 23);
            this.label48.TabIndex = 112;
            this.label48.Text = "Chuyển đến :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(492, 279);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(58, 21);
            this.mabv.TabIndex = 34;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(552, 279);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(230, 21);
            this.tenbv.TabIndex = 35;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(492, 146);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 26;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label49.Location = new System.Drawing.Point(394, 147);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(101, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Bác sĩ điều trị :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.Control;
            this.taibien.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.ForeColor = System.Drawing.SystemColors.Desktop;
            this.taibien.Location = new System.Drawing.Point(397, 384);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(109, 23);
            this.taibien.TabIndex = 126;
            this.taibien.Text = "Tai biến nội khoa";
            this.taibien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.UseVisualStyleBackColor = false;
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.BackColor = System.Drawing.SystemColors.Control;
            this.bienchung.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bienchung.Location = new System.Drawing.Point(397, 368);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(109, 18);
            this.bienchung.TabIndex = 127;
            this.bienchung.Text = "Biến chứng";
            this.bienchung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.UseVisualStyleBackColor = false;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(4, 25);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(382, 17);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giaiphau
            // 
            this.giaiphau.BackColor = System.Drawing.SystemColors.Control;
            this.giaiphau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.ForeColor = System.Drawing.SystemColors.Desktop;
            this.giaiphau.Location = new System.Drawing.Point(397, 407);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(109, 24);
            this.giaiphau.TabIndex = 128;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.UseVisualStyleBackColor = false;
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // phanhchinh
            // 
            this.phanhchinh.BackColor = System.Drawing.SystemColors.Control;
            this.phanhchinh.Controls.Add(this.tenpxa);
            this.phanhchinh.Controls.Add(this.thon);
            this.phanhchinh.Controls.Add(this.tennuoc);
            this.phanhchinh.Controls.Add(this.sonha);
            this.phanhchinh.Controls.Add(this.manuoc);
            this.phanhchinh.Controls.Add(this.tendantoc);
            this.phanhchinh.Controls.Add(this.tentqx);
            this.phanhchinh.Controls.Add(this.lmanuoc);
            this.phanhchinh.Controls.Add(this.mapxa2);
            this.phanhchinh.Controls.Add(this.maqu2);
            this.phanhchinh.Controls.Add(this.matt);
            this.phanhchinh.Controls.Add(this.tqx);
            this.phanhchinh.Controls.Add(this.madantoc);
            this.phanhchinh.Controls.Add(this.tenquan);
            this.phanhchinh.Controls.Add(this.mann);
            this.phanhchinh.Controls.Add(this.tentinh);
            this.phanhchinh.Controls.Add(this.maqu1);
            this.phanhchinh.Controls.Add(this.tennn);
            this.phanhchinh.Controls.Add(this.cholam);
            this.phanhchinh.Controls.Add(this.lmaqu);
            this.phanhchinh.Controls.Add(this.lcholam);
            this.phanhchinh.Controls.Add(this.mapxa1);
            this.phanhchinh.Controls.Add(this.lmatt);
            this.phanhchinh.Controls.Add(this.ltqx);
            this.phanhchinh.Controls.Add(this.lmaphuongxa);
            this.phanhchinh.Controls.Add(this.lthon);
            this.phanhchinh.Controls.Add(this.lsonha);
            this.phanhchinh.Controls.Add(this.lmadantoc);
            this.phanhchinh.Controls.Add(this.phai);
            this.phanhchinh.Controls.Add(this.lphai);
            this.phanhchinh.Controls.Add(this.lmann);
            this.phanhchinh.Location = new System.Drawing.Point(6, 85);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(377, 138);
            this.phanhchinh.TabIndex = 9;
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(90, 113);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(97, 21);
            this.tenpxa.TabIndex = 17;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(174, 47);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(201, 21);
            this.thon.TabIndex = 7;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(256, 25);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(119, 21);
            this.tennuoc.TabIndex = 5;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(65, 47);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(47, 21);
            this.sonha.TabIndex = 6;
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(233, 25);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(22, 21);
            this.manuoc.TabIndex = 4;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(90, 25);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(65, 21);
            this.tendantoc.TabIndex = 3;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(114, 69);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(261, 21);
            this.tentqx.TabIndex = 9;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmanuoc.Location = new System.Drawing.Point(168, 24);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(65, 113);
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
            this.maqu2.Location = new System.Drawing.Point(212, 91);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(22, 21);
            this.maqu2.TabIndex = 13;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(65, 91);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(27, 21);
            this.matt.TabIndex = 10;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(65, 69);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 8;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(65, 25);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 2;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(235, 91);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(140, 21);
            this.tenquan.TabIndex = 14;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(233, 3);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 0;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tentinh.Location = new System.Drawing.Point(93, 91);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(71, 21);
            this.tentinh.TabIndex = 11;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(212, 91);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 12;
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(256, 3);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(119, 21);
            this.tennn.TabIndex = 1;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(235, 113);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(140, 21);
            this.cholam.TabIndex = 10;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // lmaqu
            // 
            this.lmaqu.BackColor = System.Drawing.SystemColors.Control;
            this.lmaqu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaqu.Location = new System.Drawing.Point(135, 89);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.BackColor = System.Drawing.SystemColors.Control;
            this.lcholam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcholam.Location = new System.Drawing.Point(170, 115);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(67, 15);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Chỗ làm :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(65, 113);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 15;
            // 
            // lmatt
            // 
            this.lmatt.BackColor = System.Drawing.SystemColors.Control;
            this.lmatt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmatt.Location = new System.Drawing.Point(12, 89);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.BackColor = System.Drawing.SystemColors.Control;
            this.ltqx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ltqx.Location = new System.Drawing.Point(-1, 68);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(68, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.BackColor = System.Drawing.SystemColors.Control;
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaphuongxa.Location = new System.Drawing.Point(-4, 110);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
            this.lmaphuongxa.TabIndex = 77;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.BackColor = System.Drawing.SystemColors.Control;
            this.lthon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lthon.Location = new System.Drawing.Point(114, 51);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(57, 14);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.BackColor = System.Drawing.SystemColors.Control;
            this.lsonha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsonha.Location = new System.Drawing.Point(6, 45);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(61, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmadantoc.Location = new System.Drawing.Point(12, 24);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Unknown"});
            this.phai.Location = new System.Drawing.Point(65, 3);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(67, 21);
            this.phai.TabIndex = 12;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.BackColor = System.Drawing.SystemColors.Control;
            this.lphai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lphai.Location = new System.Drawing.Point(12, 2);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.BackColor = System.Drawing.SystemColors.Control;
            this.lmann.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmann.Location = new System.Drawing.Point(152, 2);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 0;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pvaovien.BackColor = System.Drawing.SystemColors.Control;
            this.pvaovien.Controls.Add(this.traituyen);
            this.pvaovien.Controls.Add(this.trieuchung);
            this.pvaovien.Controls.Add(this.lblTrieuchung);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.dausinhton);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label16);
            this.pvaovien.Controls.Add(this.pmat);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.bnmoi);
            this.pvaovien.Controls.Add(this.loai);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.label29);
            this.pvaovien.Controls.Add(this.label28);
            this.pvaovien.Controls.Add(this.label27);
            this.pvaovien.Controls.Add(this.label26);
            this.pvaovien.Controls.Add(this.label25);
            this.pvaovien.Controls.Add(this.label24);
            this.pvaovien.Controls.Add(this.label23);
            this.pvaovien.Controls.Add(this.dentu);
            this.pvaovien.Controls.Add(this.label21);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.label9);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.l_bnmoi);
            this.pvaovien.Location = new System.Drawing.Point(3, 224);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(381, 278);
            this.pvaovien.TabIndex = 13;
            // 
            // traituyen
            // 
            this.traituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traituyen.Enabled = false;
            this.traituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen.Location = new System.Drawing.Point(326, 89);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(52, 21);
            this.traituyen.TabIndex = 265;
            // 
            // trieuchung
            // 
            this.trieuchung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trieuchung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trieuchung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trieuchung.Location = new System.Drawing.Point(66, 221);
            this.trieuchung.Multiline = true;
            this.trieuchung.Name = "trieuchung";
            this.trieuchung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trieuchung.Size = new System.Drawing.Size(311, 53);
            this.trieuchung.TabIndex = 24;
            this.trieuchung.TextChanged += new System.EventHandler(this.trieuchung_TextChanged);
            this.trieuchung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trieuchung_KeyDown);
            // 
            // lblTrieuchung
            // 
            this.lblTrieuchung.BackColor = System.Drawing.SystemColors.Control;
            this.lblTrieuchung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTrieuchung.Location = new System.Drawing.Point(0, 220);
            this.lblTrieuchung.Name = "lblTrieuchung";
            this.lblTrieuchung.Size = new System.Drawing.Size(66, 39);
            this.lblTrieuchung.TabIndex = 253;
            this.lblTrieuchung.Text = "Triệu chứng lâm sàng ban đầu ";
            this.lblTrieuchung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(183, 45);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(36, 21);
            this.madstt.TabIndex = 6;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // dausinhton
            // 
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
            this.dausinhton.Controls.Add(this.huyetap);
            this.dausinhton.Controls.Add(this.cao);
            this.dausinhton.Controls.Add(this.label59);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.nang);
            this.dausinhton.Controls.Add(this.label55);
            this.dausinhton.Controls.Add(this.label38);
            this.dausinhton.Controls.Add(this.label39);
            this.dausinhton.Controls.Add(this.mach);
            this.dausinhton.Controls.Add(this.label54);
            this.dausinhton.Controls.Add(this.label41);
            this.dausinhton.Controls.Add(this.label43);
            this.dausinhton.Controls.Add(this.label44);
            this.dausinhton.Controls.Add(this.label45);
            this.dausinhton.Controls.Add(this.label58);
            this.dausinhton.Location = new System.Drawing.Point(10, 110);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(367, 22);
            this.dausinhton.TabIndex = 14;
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(182, 1);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(40, 21);
            this.huyetap.TabIndex = 2;
            // 
            // cao
            // 
            this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(248, 1);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(30, 21);
            this.cao.TabIndex = 3;
            // 
            // label59
            // 
            this.label59.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label59.Location = new System.Drawing.Point(352, 1);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(22, 21);
            this.label59.TabIndex = 269;
            this.label59.Text = "kg";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(125, 1);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(30, 21);
            this.nhietdo.TabIndex = 1;
            this.nhietdo.Text = "  .  ";
            // 
            // nang
            // 
            this.nang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nang.Location = new System.Drawing.Point(313, 1);
            this.nang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.nang.MaxLength = 5;
            this.nang.Name = "nang";
            this.nang.Size = new System.Drawing.Size(38, 21);
            this.nang.TabIndex = 4;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.SystemColors.Control;
            this.label55.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label55.Location = new System.Drawing.Point(275, 1);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(40, 20);
            this.label55.TabIndex = 267;
            this.label55.Text = "Nặng :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label38.Location = new System.Drawing.Point(103, -2);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 23);
            this.label38.TabIndex = 23;
            this.label38.Text = "T° :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(154, -1);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(30, 23);
            this.label39.TabIndex = 24;
            this.label39.Text = "HA :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(56, 1);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(24, 21);
            this.mach.TabIndex = 0;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label54.Location = new System.Drawing.Point(215, 1);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(36, 20);
            this.label54.TabIndex = 266;
            this.label54.Text = "Cao :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label41.Location = new System.Drawing.Point(11, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 23);
            this.label41.TabIndex = 1;
            this.label41.Text = "Mạch :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label43.Location = new System.Drawing.Point(81, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(28, 23);
            this.label43.TabIndex = 17;
            this.label43.Text = "l/p";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label44.Location = new System.Drawing.Point(131, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 23);
            this.label44.TabIndex = 19;
            this.label44.Text = "°C";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(185, -1);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(38, 23);
            this.label45.TabIndex = 21;
            this.label45.Text = "mmHg";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label58.Location = new System.Drawing.Point(248, 1);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(22, 21);
            this.label58.TabIndex = 268;
            this.label58.Text = "cm";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // khamthai
            // 
            this.khamthai.BackColor = System.Drawing.SystemColors.Control;
            this.khamthai.Controls.Add(this.ngaysanh);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label15);
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.kinhcc);
            this.khamthai.Controls.Add(this.label13);
            this.khamthai.Controls.Add(this.label14);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.khamthai.Location = new System.Drawing.Point(3, 110);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(377, 22);
            this.khamthai.TabIndex = 14;
            // 
            // ngaysanh
            // 
            this.ngaysanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysanh.Location = new System.Drawing.Point(307, 0);
            this.ngaysanh.Mask = "##/##/####";
            this.ngaysanh.Name = "ngaysanh";
            this.ngaysanh.Size = new System.Drawing.Size(67, 21);
            this.ngaysanh.TabIndex = 27;
            this.ngaysanh.Text = "  /  /    ";
            this.ngaysanh.Validated += new System.EventHandler(this.ngaysanh_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(63, 0);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(17, 21);
            this.para1.TabIndex = 1;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(30, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(114, 0);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(17, 21);
            this.para4.TabIndex = 4;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // kinhcc
            // 
            this.kinhcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhcc.Location = new System.Drawing.Point(182, 0);
            this.kinhcc.Mask = "##/##/####";
            this.kinhcc.Name = "kinhcc";
            this.kinhcc.Size = new System.Drawing.Size(62, 21);
            this.kinhcc.TabIndex = 26;
            this.kinhcc.Text = "  /  /    ";
            this.kinhcc.Validated += new System.EventHandler(this.kinhcc_Validated);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(235, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ngày sanh :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(127, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Kinh cuối ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(97, 0);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(17, 21);
            this.para3.TabIndex = 3;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(80, 0);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(17, 21);
            this.para2.TabIndex = 2;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(66, 177);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(140, 21);
            this.qh_diachi.TabIndex = 20;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(0, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(377, 20);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO KHÁM BỆNH :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(183, 23);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(35, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(154, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 23);
            this.label16.TabIndex = 244;
            this.label16.Text = "giờ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.label33);
            this.pmat.Controls.Add(this.label22);
            this.pmat.Controls.Add(this.label18);
            this.pmat.Controls.Add(this.label35);
            this.pmat.Controls.Add(this.label36);
            this.pmat.Controls.Add(this.label37);
            this.pmat.Location = new System.Drawing.Point(32, 111);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(356, 21);
            this.pmat.TabIndex = 14;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(226, 0);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(33, 21);
            this.nhanapp.TabIndex = 25;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(317, 0);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(27, 21);
            this.nhanapt.TabIndex = 26;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(117, 0);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(26, 21);
            this.mt.TabIndex = 24;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(34, 0);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(28, 21);
            this.mp.TabIndex = 23;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label33.Location = new System.Drawing.Point(142, 3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 5;
            this.label33.Text = "/10";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(254, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "Nhãn áp T :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(162, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Nhãn áp P :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label18.UseCompatibleTextRendering = true;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label35.Location = new System.Drawing.Point(79, 2);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 16);
            this.label35.TabIndex = 1;
            this.label35.Text = "Mắt T :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label36.Location = new System.Drawing.Point(59, 3);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 4;
            this.label36.Text = "/10";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label37.Location = new System.Drawing.Point(-72, 3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(110, 16);
            this.label37.TabIndex = 0;
            this.label37.Text = "Mắt P :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(258, 89);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(67, 21);
            this.denngay.TabIndex = 13;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(66, 89);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(139, 21);
            this.sothe.TabIndex = 12;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(126, 199);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(251, 21);
            this.cd_noichuyenden.TabIndex = 23;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(66, 199);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(59, 21);
            this.icd_noichuyenden.TabIndex = 22;
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(66, 23);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(66, 133);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(34, 21);
            this.sovaovien.TabIndex = 15;
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
            this.bnmoi.Location = new System.Drawing.Point(280, 133);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(97, 21);
            this.bnmoi.TabIndex = 17;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(143, 133);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(75, 21);
            this.loai.TabIndex = 16;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(219, 3);
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
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(220, 45);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(157, 21);
            this.tendstt.TabIndex = 7;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // tendentu
            // 
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(85, 45);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(70, 21);
            this.tendentu.TabIndex = 5;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // tennhantu
            // 
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(288, 23);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(89, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(269, 23);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(18, 21);
            this.nhantu.TabIndex = 2;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(193, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 210;
            this.label20.Text = "Nhận từ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(91, 67);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(114, 21);
            this.tenkp.TabIndex = 9;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(258, 67);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(21, 21);
            this.madoituong.TabIndex = 10;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(280, 67);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(97, 21);
            this.tendoituong.TabIndex = 11;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label31.Location = new System.Drawing.Point(4, 197);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(66, 23);
            this.label31.TabIndex = 2;
            this.label31.Text = "CĐ chuyển :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(280, 177);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(97, 21);
            this.qh_dienthoai.TabIndex = 21;
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(183, 155);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(194, 21);
            this.qh_hoten.TabIndex = 19;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(66, 155);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(77, 21);
            this.quanhe.TabIndex = 18;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(4, 131);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label29.Location = new System.Drawing.Point(205, 177);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label28.Location = new System.Drawing.Point(6, 175);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(137, 153);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(1, 152);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người thân :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(198, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 196;
            this.label25.Text = "Đến ngày :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(6, 88);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label23.Location = new System.Drawing.Point(198, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(66, 45);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(-17, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 23);
            this.label21.TabIndex = 10;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(-42, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày khám :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(66, 67);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 8;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(-10, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "P. khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(153, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 213;
            this.label9.Text = "Tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label34.Location = new System.Drawing.Point(95, 132);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 23);
            this.label34.TabIndex = 252;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.BackColor = System.Drawing.SystemColors.Control;
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_bnmoi.Location = new System.Drawing.Point(212, 132);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(72, 23);
            this.l_bnmoi.TabIndex = 251;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // danhsach
            // 
            this.danhsach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.danhsach.Controls.Add(this.list);
            this.danhsach.Controls.Add(this.lblso);
            this.danhsach.Controls.Add(this.tim);
            this.danhsach.Controls.Add(this.butRef);
            this.danhsach.Location = new System.Drawing.Point(6, 245);
            this.danhsach.Name = "danhsach";
            this.danhsach.Size = new System.Drawing.Size(377, 260);
            this.danhsach.TabIndex = 0;
            this.danhsach.TabStop = false;
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(5, 29);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(373, 225);
            this.list.TabIndex = 0;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // lblso
            // 
            this.lblso.AutoSize = true;
            this.lblso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblso.Location = new System.Drawing.Point(313, 10);
            this.lblso.Name = "lblso";
            this.lblso.Size = new System.Drawing.Size(28, 13);
            this.lblso.TabIndex = 3;
            this.lblso.Text = "Tìm";
            this.lblso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(4, 7);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(308, 21);
            this.tim.TabIndex = 2;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butRef
            // 
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.Image = ((System.Drawing.Image)(resources.GetObject("butRef.Image")));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(347, 6);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(31, 23);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách khám bệnh");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(414, 430);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(296, 72);
            this.treeView1.TabIndex = 207;
            this.toolTip1.SetToolTip(this.treeView1, "Ctrl + T : Đơn thuốc");
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(392, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(395, 16);
            this.label8.TabIndex = 208;
            this.label8.Text = "III. THÔNG TIN RA VIỆN :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gphaubenh
            // 
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(510, 407);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(122, 21);
            this.gphaubenh.TabIndex = 129;
            this.gphaubenh.Visible = false;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(71, 64);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(67, 21);
            this.ngaysinh.TabIndex = 5;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(510, 384);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(122, 21);
            this.cmbTaibien.TabIndex = 212;
            this.cmbTaibien.Visible = false;
            // 
            // cd_chinh
            // 
            this.cd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(553, 42);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(230, 21);
            this.cd_chinh.TabIndex = 21;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(4, 510);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(68, 17);
            this.listICD.TabIndex = 216;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // cd_kemtheo
            // 
            this.cd_kemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(553, 64);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(230, 21);
            this.cd_kemtheo.TabIndex = 23;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(659, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 217;
            this.label10.Text = "Số lưu trữ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(719, 146);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(64, 21);
            this.soluutru.TabIndex = 29;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(401, 214);
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
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(525, 146);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(142, 21);
            this.tenbs.TabIndex = 27;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(398, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 23);
            this.label11.TabIndex = 226;
            this.label11.Text = "Khoa : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoa
            // 
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(492, 301);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(24, 21);
            this.khoa.TabIndex = 36;
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(519, 301);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(263, 21);
            this.tenkhoa.TabIndex = 37;
            this.tenkhoa.SelectedIndexChanged += new System.EventHandler(this.tenkhoa_SelectedIndexChanged);
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xutri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(492, 191);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(291, 64);
            this.xutri.TabIndex = 31;
            this.xutri.SelectedIndexChanged += new System.EventHandler(this.xutri_SelectedIndexChanged);
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // maxutri
            // 
            this.maxutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maxutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maxutri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maxutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxutri.Location = new System.Drawing.Point(492, 169);
            this.maxutri.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maxutri.Name = "maxutri";
            this.maxutri.Size = new System.Drawing.Size(291, 21);
            this.maxutri.TabIndex = 30;
            this.maxutri.Validated += new System.EventHandler(this.maxutri_Validated);
            // 
            // llydo
            // 
            this.llydo.BackColor = System.Drawing.SystemColors.Control;
            this.llydo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.llydo.Location = new System.Drawing.Point(395, 107);
            this.llydo.Name = "llydo";
            this.llydo.Size = new System.Drawing.Size(101, 23);
            this.llydo.TabIndex = 237;
            this.llydo.Text = "Ghi chú :";
            this.llydo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.Location = new System.Drawing.Point(492, 109);
            this.lydo.Multiline = true;
            this.lydo.Name = "lydo";
            this.lydo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lydo.Size = new System.Drawing.Size(291, 36);
            this.lydo.TabIndex = 25;
            this.lydo.TextChanged += new System.EventHandler(this.lydo_TextChanged);
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
            this.toolStripButton11,
            this.toolStripSeparator5,
            this.toolStripButton5,
            this.toolStripSeparator6,
            this.toolStripButton6,
            this.toolStripSeparator7,
            this.toolStripButton7,
            this.toolStripSeparator8,
            this.toolStripButton8,
            this.toolStripSeparator9,
            this.toolStripButton9,
            this.toolStripSeparator10,
            this.toolStripButton13,
            this.toolStripSeparator11,
            this.toolStripButton10,
            this.toolStripDropDownButton1,
            this.toolStripSeparator12,
            this.toolStripButton14,
            this.toolStripSeparator13,
            this.toolStripButton15,
            this.toolStripButton12,
            this.tlbl,
            this.tlblhd});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 26);
            this.toolStrip1.TabIndex = 243;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton1.Text = "F3";
            this.toolStripButton1.ToolTipText = "Toa bảo hiểm";
            this.toolStripButton1.Click += new System.EventHandler(this.l_thuocbhyt_Click);
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
            this.toolStripButton2.Text = "F5";
            this.toolStripButton2.ToolTipText = "Toa mua ngoài";
            this.toolStripButton2.Click += new System.EventHandler(this.l_thuocdan_Click);
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
            this.toolStripButton3.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton3.Text = "F6";
            this.toolStripButton3.ToolTipText = "Phẩu thuật-Thủ thuật";
            this.toolStripButton3.Click += new System.EventHandler(this.l_phauthuat_Click);
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
            this.toolStripButton4.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton4.Text = "F7";
            this.toolStripButton4.ToolTipText = "Yêu cầu cận lâm sàng";
            this.toolStripButton4.Click += new System.EventHandler(this.l_chidinh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton11.Text = "F8";
            this.toolStripButton11.ToolTipText = "Xem tồn kho";
            this.toolStripButton11.Click += new System.EventHandler(this.l_tonkho_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton5.Text = "F9";
            this.toolStripButton5.ToolTipText = "Tai nạn thương tích";
            this.toolStripButton5.Click += new System.EventHandler(this.l_tainantt_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton6.Text = "F10";
            this.toolStripButton6.ToolTipText = "Thuốc tủ trực";
            this.toolStripButton6.Click += new System.EventHandler(this.l_tutruc_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton7.Text = "F11";
            this.toolStripButton7.ToolTipText = "Bệnh kèm theo";
            this.toolStripButton7.Click += new System.EventHandler(this.l_kemtheo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton8.Text = "F12";
            this.toolStripButton8.ToolTipText = "Xem hồ sơ bệnh án";
            this.toolStripButton8.Click += new System.EventHandler(this.l_cls_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(42, 20);
            this.toolStripButton9.Text = "^D";
            this.toolStripButton9.ToolTipText = "Di ứng thuốc";
            this.toolStripButton9.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton13.Text = "toolStripButton13";
            this.toolStripButton13.ToolTipText = "Tự sát";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(24, 23);
            this.toolStripButton10.ToolTipText = "Sổ khám thai";
            this.toolStripButton10.Click += new System.EventHandler(this.l_lichhen_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkLCD,
            this.lblLCD});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            // 
            // chkLCD
            // 
            this.chkLCD.CheckOnClick = true;
            this.chkLCD.Name = "chkLCD";
            this.chkLCD.Size = new System.Drawing.Size(190, 22);
            this.chkLCD.Text = "Xuất số thứ tự ra LCD";
            this.chkLCD.Click += new System.EventHandler(this.chkLCD_Click);
            // 
            // lblLCD
            // 
            this.lblLCD.Name = "lblLCD";
            this.lblLCD.Size = new System.Drawing.Size(190, 22);
            this.lblLCD.Text = "Thông số LCD";
            this.lblLCD.Click += new System.EventHandler(this.lblLCD_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton14.ToolTipText = "Bệnh mãn tính";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton15.ToolTipText = "Tiền sử bệnh";
            this.toolStripButton15.Click += new System.EventHandler(this.toolStripButton15_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 4);
            this.toolStripButton12.Text = "^T";
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            // 
            // tlblhd
            // 
            this.tlblhd.ForeColor = System.Drawing.Color.Red;
            this.tlblhd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlblhd.Name = "tlblhd";
            this.tlblhd.Size = new System.Drawing.Size(0, 0);
            this.tlblhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.SystemColors.Control;
            this.chkXem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXem.Location = new System.Drawing.Point(638, 409);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 245;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = false;
            // 
            // chkToathuoc
            // 
            this.chkToathuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkToathuoc.AutoSize = true;
            this.chkToathuoc.BackColor = System.Drawing.SystemColors.Control;
            this.chkToathuoc.Checked = true;
            this.chkToathuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToathuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkToathuoc.Location = new System.Drawing.Point(638, 388);
            this.chkToathuoc.Name = "chkToathuoc";
            this.chkToathuoc.Size = new System.Drawing.Size(106, 17);
            this.chkToathuoc.TabIndex = 246;
            this.chkToathuoc.Text = "In kèm toa thuốc";
            this.chkToathuoc.UseVisualStyleBackColor = false;
            this.chkToathuoc.CheckedChanged += new System.EventHandler(this.chkToathuoc_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(2, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(386, 483);
            this.button1.TabIndex = 247;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(390, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(399, 483);
            this.button2.TabIndex = 248;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // hen
            // 
            this.hen.Controls.Add(this.hen_in);
            this.hen.Controls.Add(this.chkTiepdon);
            this.hen.Controls.Add(this.hen_ghichu);
            this.hen.Controls.Add(this.hen_loai);
            this.hen.Controls.Add(this.label32);
            this.hen.Controls.Add(this.hen_ngay);
            this.hen.Controls.Add(this.label17);
            this.hen.Location = new System.Drawing.Point(420, 323);
            this.hen.Name = "hen";
            this.hen.Size = new System.Drawing.Size(362, 49);
            this.hen.TabIndex = 39;
            this.hen.Visible = false;
            // 
            // chkTiepdon
            // 
            this.chkTiepdon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTiepdon.AutoSize = true;
            this.chkTiepdon.BackColor = System.Drawing.SystemColors.Control;
            this.chkTiepdon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkTiepdon.Location = new System.Drawing.Point(225, 3);
            this.chkTiepdon.Name = "chkTiepdon";
            this.chkTiepdon.Size = new System.Drawing.Size(144, 17);
            this.chkTiepdon.TabIndex = 2;
            this.chkTiepdon.Text = "Qua đăng ký khám bệnh";
            this.chkTiepdon.UseVisualStyleBackColor = false;
            this.chkTiepdon.CheckedChanged += new System.EventHandler(this.chkTiepdon_CheckedChanged);
            this.chkTiepdon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // hen_ghichu
            // 
            this.hen_ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hen_ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ghichu.Location = new System.Drawing.Point(72, 23);
            this.hen_ghichu.Name = "hen_ghichu";
            this.hen_ghichu.Size = new System.Drawing.Size(250, 21);
            this.hen_ghichu.TabIndex = 3;
            this.hen_ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // hen_loai
            // 
            this.hen_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hen_loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_loai.FormattingEnabled = true;
            this.hen_loai.Items.AddRange(new object[] {
            "Ngày liên tục",
            "Ngày",
            "Tuần",
            "Tháng"});
            this.hen_loai.Location = new System.Drawing.Point(114, 1);
            this.hen_loai.Name = "hen_loai";
            this.hen_loai.Size = new System.Drawing.Size(110, 21);
            this.hen_loai.TabIndex = 1;
            this.hen_loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label32.Location = new System.Drawing.Point(-25, 19);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(98, 23);
            this.label32.TabIndex = 230;
            this.label32.Text = "Ghi chú :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen_ngay
            // 
            this.hen_ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ngay.Location = new System.Drawing.Point(72, 1);
            this.hen_ngay.Name = "hen_ngay";
            this.hen_ngay.Size = new System.Drawing.Size(40, 21);
            this.hen_ngay.TabIndex = 0;
            this.hen_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(-4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 23);
            this.label17.TabIndex = 227;
            this.label17.Text = "Thời gian :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.pgoi.Location = new System.Drawing.Point(553, -2);
            this.pgoi.Name = "pgoi";
            this.pgoi.Size = new System.Drawing.Size(252, 26);
            this.pgoi.TabIndex = 261;
            // 
            // butGoilai
            // 
            this.butGoilai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoilai.Location = new System.Drawing.Point(192, 3);
            this.butGoilai.Name = "butGoilai";
            this.butGoilai.Size = new System.Drawing.Size(45, 22);
            this.butGoilai.TabIndex = 6;
            this.butGoilai.Text = "Gọi lại";
            this.butGoilai.UseVisualStyleBackColor = true;
            this.butGoilai.Click += new System.EventHandler(this.butGoilai_Click);
            // 
            // butGoi
            // 
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(141, 3);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(50, 22);
            this.butGoi.TabIndex = 5;
            this.butGoi.Text = "&Gọi";
            this.butGoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butGoi.UseVisualStyleBackColor = true;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // sonhay
            // 
            this.sonhay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonhay.Location = new System.Drawing.Point(110, 3);
            this.sonhay.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.sonhay.Name = "sonhay";
            this.sonhay.Size = new System.Drawing.Size(30, 21);
            this.sonhay.TabIndex = 4;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(73, 3);
            this.den.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(37, 21);
            this.den.TabIndex = 2;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(30, 3);
            this.tu.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(41, 21);
            this.tu.TabIndex = 1;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(4, 6);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(26, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Số :";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(394, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 23);
            this.label12.TabIndex = 263;
            this.label12.Text = "Phân biệt :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phanbiet
            // 
            this.phanbiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phanbiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanbiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanbiet.Location = new System.Drawing.Point(492, 87);
            this.phanbiet.Name = "phanbiet";
            this.phanbiet.Size = new System.Drawing.Size(291, 21);
            this.phanbiet.TabIndex = 24;
            this.phanbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sovaovien_KeyDown);
            // 
            // butXthuoc
            // 
            this.butXthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXthuoc.BackColor = System.Drawing.Color.Transparent;
            this.butXthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXthuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butXthuoc.Image = ((System.Drawing.Image)(resources.GetObject("butXthuoc.Image")));
            this.butXthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXthuoc.Location = new System.Drawing.Point(522, 507);
            this.butXthuoc.Name = "butXthuoc";
            this.butXthuoc.Size = new System.Drawing.Size(119, 25);
            this.butXthuoc.TabIndex = 262;
            this.butXthuoc.Text = "Thuốc đã sử dụng";
            this.butXthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butXthuoc.UseVisualStyleBackColor = false;
            this.butXthuoc.Click += new System.EventHandler(this.butXthuoc_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(642, 507);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 44;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(80, 507);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(60, 25);
            this.butTiep.TabIndex = 42;
            this.butTiep.Text = "   &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butInchitiet
            // 
            this.butInchitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInchitiet.BackColor = System.Drawing.Color.Transparent;
            this.butInchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchitiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butInchitiet.Image = ((System.Drawing.Image)(resources.GetObject("butInchitiet.Image")));
            this.butInchitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchitiet.Location = new System.Drawing.Point(447, 507);
            this.butInchitiet.Name = "butInchitiet";
            this.butInchitiet.Size = new System.Drawing.Size(74, 25);
            this.butInchitiet.TabIndex = 244;
            this.butInchitiet.Text = "&In chi phí";
            this.butInchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInchitiet.UseVisualStyleBackColor = false;
            this.butInchitiet.Click += new System.EventHandler(this.butInchitiet_Click);
            // 
            // butIncv
            // 
            this.butIncv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIncv.BackColor = System.Drawing.Color.Transparent;
            this.butIncv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIncv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIncv.Image = ((System.Drawing.Image)(resources.GetObject("butIncv.Image")));
            this.butIncv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIncv.Location = new System.Drawing.Point(356, 507);
            this.butIncv.Name = "butIncv";
            this.butIncv.Size = new System.Drawing.Size(90, 25);
            this.butIncv.TabIndex = 238;
            this.butIncv.Text = "Chuyển viện";
            this.butIncv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIncv.UseVisualStyleBackColor = false;
            this.butIncv.Click += new System.EventHandler(this.butIncv_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(141, 507);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(64, 25);
            this.butLuu.TabIndex = 40;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(267, 507);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(88, 25);
            this.butIn.TabIndex = 43;
            this.butIn.Text = "    &Phiếu khám";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
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
            this.butBoqua.Location = new System.Drawing.Point(206, 507);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 41;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(710, 429);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 254;
            this.pic.TabStop = false;
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXml.AutoSize = true;
            this.chkXml.BackColor = System.Drawing.SystemColors.Control;
            this.chkXml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXml.Location = new System.Drawing.Point(715, 512);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 264;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = false;
            // 
            // hen_in
            // 
            this.hen_in.Location = new System.Drawing.Point(325, 21);
            this.hen_in.Name = "hen_in";
            this.hen_in.Size = new System.Drawing.Size(38, 23);
            this.hen_in.TabIndex = 231;
            this.hen_in.Text = "In";
            this.hen_in.UseVisualStyleBackColor = true;
            this.hen_in.Click += new System.EventHandler(this.hen_in_Click);
            // 
            // frmKhambenh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 534);
            this.Controls.Add(this.pgoi);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.phanbiet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.butXthuoc);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butInchitiet);
            this.Controls.Add(this.butIncv);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.danhsach);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.hen);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.maxutri);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.chkToathuoc);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.llydo);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cd_kemtheo);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tenba);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKhambenh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft 2007 -  Khám bệnh ";
            this.Load += new System.EventHandler(this.frmKhambenh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhambenh_KeyDown);
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.danhsach.ResumeLayout(false);
            this.danhsach.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.hen.ResumeLayout(false);
            this.hen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).EndInit();
            this.pgoi.ResumeLayout(false);
            this.pgoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKhambenh_Load(object sender, System.EventArgs e)
		{
            f_load_option();
            lblTrieuchung.Text = m.sTrieuchung; bNhapvien_kocongkham = m.bNhapvien_kocongkham;
            sNhapvien_kocongkham_madoituong = m.sNhapvien_kocongkham_madoituong;
            pathImage = m.pathImage;FileType = m.FileType; bXutri_hen_koin = m.bXutri_hen_koin;
            bDangky_homqua = m.bDangky_homqua; bTaikham_v_chidinh = m.bTaikham_v_chidinh;
            ngaysrv = m.ngayhienhanh_server.Substring(0, 10); bPhongkham_chandoan = m.bPhongkham_chandoan;
            traituyen.SelectedIndex = 0; bTraituyen = m.bTraituyen;lTraituyen = (bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0; bPhongkham_bangdien_hanoi = m.bPhongkham_bangdien_hanoi;
            //if (bPhongkham_bangdien_hanoi)
            //{
            //    fled = new Project1.Form1();
            //    fled.start_com(i_com);
            //}
            //if (bPhongkham_chandoan)
            //{
            //    this.icd_kemtheo.TabIndex = 52;
            //    this.cd_kemtheo.TabIndex = 53;
            //    this.phanbiet.TabIndex = 54;
            //}
            bSothe_ngay_huong = m.bSothe_ngay_huong; bChuyenkham_chandoan = m.bChuyenkham_chandoan;
            bChuyenkham_thuphi = m.bChuyenkham_thuphi; bTaikham_chiphi_inrieng = m.bTaikham_chiphi_inrieng;
			if (s_mabs!="")
			{
				mabs.Enabled=false;
				tenbs.Enabled=false;
			}            
            hoten.Enabled = ngaysinh.Enabled = namsinh.Enabled = phai.Enabled = tuoi.Enabled = loaituoi.Enabled = mann.Enabled = tennn.Enabled = tendantoc.Enabled = madantoc.Enabled = sonha.Enabled = thon.Enabled = cholam.Enabled = matt.Enabled = tentinh.Enabled = maqu2.Enabled = tenquan.Enabled = mapxa2.Enabled = tenpxa.Enabled = m.bPhongkham_hanhchanh;
            bHaophi = m.bHaophi_thanhtoan; bHaophi_doituongvao = m.bHaophi_thanhtoan_doituongvao;
            s_nhomhaophi = m.sHaophi_thanhtoan;
            Taikham_songay = m.Taikham_songay;
            
            
            bTaikham_hen = m.bTaikham_hen;
            madoituong_hen = m.madoituong_hen;
            if (m.iSokham != 3)sovaovien.Enabled = false;            
            bDuyet_khambenh = m.bDuyet_khambenh;
            bNgtru_dt_makp = m.bNgtru_dt_makp;
            dt_ngtru = m.dt_ngtru; iHaophi = d.iHaophi;
            makp_kho_dt = m.makp_kho_dt;
            giovv.Enabled = m.bGiokham;
            trieuchung.Enabled = m.bTrieuchung;
            pic.Visible = m.bHinh || m.bChonhinh; bChuyenkham_dscho = m.bChuyenkham_dscho;
            bChuyenkham_tinhcongkham = m.bChuyenkham_tinhcongkham;
            bChuyenkham_tinh_congkham_dtthuphi = m.bChuyenkham_tinh_congkham_dtthuphi;
            dausinhton.Visible = m.bDausinhton_khambenh;
            bPhongkham_khongduocxutri_chuyenvien = m.bPhongkham_khongduocxutri_chuyenvien;
            butIncv.Enabled = bPhongkham_khongduocxutri_chuyenvien==false;
            user = m.user; bSuadoituong = m.bSuadoituong_khambenh;
            dtgia = m.get_data("select * from " + user + ".v_giavp").Tables[0];
            imavp_congkham = m.iMavp_congkham(m.nhom_duoc);
            hen_loai.SelectedIndex = 0;
            bDichvu_vpkb = m.bDichvu_vpkb;
            bCongkham = m.bInchiphi_congkham;
            Congkham = d.Congkham(m.nhom_duoc);
            bInchitiet = m.bKham_inchiphi;
            butInchitiet.Enabled = bInchitiet;
            chkXem.Visible = bInchitiet;
            chkToathuoc.Visible = bInchitiet;
            dtdt1 = m.get_data("select * from " + user + ".doituong").Tables[0];
            if (bInchitiet)
            {
                bChuky = m.bChuky;
                chkXem.Checked = m.bPreview;
                sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom";
                sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
                sql += " where a.id_loai=b.id and b.id_nhom=c.ma";
                dtvpin = m.get_data(sql).Tables[0];

                sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
                sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom,e.id as nhomin";
                sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d," + user + ".d_nhomin e";
                sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma and c.nhomin=e.id";
                dtbd = m.get_data(sql).Tables[0];

                dsxmlin.ReadXml("..//..//..//xml//m_inravien.xml");
                dsxmlin.Tables[0].Columns.Add("Image", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add("mabs");
                dsxmlin.Tables[0].Columns.Add("tenbs");
                dsxmlin.Tables[0].Columns.Add("makprv");
                dsxmlin.Tables[0].Columns.Add("tenuser");
                dsxmlin.Tables[0].Columns.Add("cholam");
                dsxmlin.Tables[0].Columns.Add("madt", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("haophi", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("gianovat", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("idttrv", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("sotientra", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("traituyen", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("khoanhapvien");
                dsxmlin.Tables[0].Columns.Add("kythuat",typeof(decimal)).DefaultValue=-1;
                dsxmlin.Tables[0].Columns.Add("loaikythuat");
                dsxmlin.Tables[0].Columns.Add("ghichukb");
                dsxmlin.Tables[0].Columns.Add("trieuchung");
                dsxmlin.Tables[0].Columns.Add("phanbiet");
                //dsxmlin.Tables[0].Columns.Add("ngay");
            }            
            tlblhd.Text = ""; bPhongkham_chidinh = m.bPhongkham_chidinh; bSothe_mabn = m.bsothe_mabn;
            i_sokham = m.iSokham; bClear = m.bClear_bskham;
			b701424=m.Mabv_so==701424;
			pmat.Visible=b701424;
			lydo.Visible=!b701424;
            llydo.Visible = lydo.Visible;
			bChandoan=m.bChandoan_icd10;
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
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dsloai.Tables[0];
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];
			bnmoi.Enabled=m.bMoi_cu;
			bSoluutru=m.bSoluutru_nhapvien;
			bBacsy=m.bBacsy_tiepdon;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Khambenh);
			bDanhmuc_nhathuoc=m.bDanhmuc_nhathuoc;
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			bChuyenkhoasan=m.bChuyenkhoasan;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			tlbl.Text="";
			bXutri_noitru=m.bXutri_noitru_kb;
			bXutri_ngoaitru=m.bXutri_ngoaitru_kb;
            bXutri_phongluu = m.bXutri_khambenh_pl;
			iChidinh=m.iChidinh;
			bHiends=m.bHiendanhsach;
			bAdmin=m.bAdmin(i_userid);
			b_bacsi=m.bsKhambenh;
			bLuutru_Mabn=m.bSoluutru_Mabn;
			b_Hoten=m.bHoten_gioitinh;
			b_sovaovien=m.bSovaovien;
			load_dm();
			iKhamnhi=m.iTuoi_khamnhi;
			phai.SelectedIndex=0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			cd_noichuyenden.Enabled=m.bChandoan;
			cd_chinh.Enabled=cd_noichuyenden.Enabled;
			cd_kemtheo.Enabled=cd_noichuyenden.Enabled;
			b_khambenh=m.bKhambenh;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			soluutru.Enabled=!bLuutru_Mabn && b_soluutru;
			DataTable tmp=m.get_data("select maba from "+user+".dmbenhan where loaiba=2 order by maba").Tables[0];
			if (tmp.Rows.Count>0) i_bangoaitru=int.Parse(tmp.Rows[0]["maba"].ToString());
			else i_bangoaitru=20;
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),lan.Change_language_MessageText("Nữ")});
            bGoi = m.bGoi_khambenh && dtkp.Rows.Count==1;
            if (pgoi.Visible = bGoi)
            {
                sonhay.Value = decimal.Parse(m.sonhay.ToString());
                decimal so = m.goikham(ngaysrv,dtkp.Rows[0]["makp"].ToString());
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
            /*
            bBangDienPhongKham = m.bBangdienPhongkham;
            if (bBangDienPhongKham)
            {
                //linh
                a_fon[0] = 175;
                a_fon[1] = 3;
                a_fon[2] = 157;
                a_fon[3] = 151;
                a_fon[4] = 51;
                a_fon[5] = 182;
                a_fon[6] = 190;
                a_fon[7] = 131;
                a_fon[8] = 191;
                a_fon[9] = 183;
                a_fon[20] = 0;
                string settings = "";
                short iPort = 1;
                try
                {
                    DataSet dsCom = new DataSet();
                    dsCom.ReadXml(@"..\..\..\xml\m_cauhinh.xml", XmlReadMode.ReadSchema);
                    string port = dsCom.Tables[0].Rows[0]["port"].ToString().ToUpper().Replace("COM", "");
                    iPort = short.Parse(port);
                    settings = dsCom.Tables[0].Rows[0]["config"].ToString();
                }
                catch
                {
                    bBangDienPhongKham = false;
                    MessageBox.Show("Không thể xuất số thứ tự ra bảng điện.");
                    return;
                }
                if (!Mocong(iPort, settings))
                {
                    bBangDienPhongKham = false;
                    MessageBox.Show("Không thể xuất số thứ tự ra bảng điện.");
                }
                else
                {
                    den.Enabled = false;
                    sonhay.Enabled = false;
                }
            }
            //end
            */
            chkToathuoc.Checked=m.Thongso("pktoathuoc")=="1";
            this.chkLCD.Checked = this.m.Thongso("pklcd") == "1";
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
            foreach (DataRow r in m.get_data("select distinct b.ten from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b where a.mahc=b.ma and a.mabn='" + mabn2.Text + mabn3.Text + "'").Tables[0].Rows) tlbl.Text += r["ten"].ToString().Trim() + ";";
            if (tlbl.Text!="") tlbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
		}

		private void load_phauthuat()
		{
            //phauthuat.Checked=m.get_data("select * from pttt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_phauthuat.ForeColor=(phauthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tainantt()
		{
            //tainantt.Checked=m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tainantt.ForeColor=(tainantt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_thuocdan()
		{
            //if (bDanhmuc_nhathuoc) sql="select * from d_thuocbhytll where madoituong<>1 and nhom="+m.nhom_nhathuoc+" and maql="+l_maql;
            //else sql="select * from d_toathuocll where maql="+l_maql;
            //thuocdan.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_thuocdan.ForeColor=(thuocdan.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_chidinh()
		{
            //if (iChidinh==4) return;
            //sql="select * from v_chidinh ";
            //if (iChidinh==1) sql+=" where mabn='"+s_mabn+"'";
            //else sql+="where maql="+l_maql;
            //chidinh.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_chidinh.ForeColor=(chidinh.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_baohiem()
		{
            //thuocbhyt.Checked=m.get_data("select * from d_thuocbhytll where nhom="+m.nhom_duoc+" and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuocbhyt.ForeColor=(thuocbhyt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
			listdstt.DisplayMember="MABV";
			listdstt.ValueMember="TENBV";
            listdstt.DataSource = m.get_data("select mabv,tenbv,diachi from " + user + ".dstt where mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			tenkhoa.DisplayMember="TENKP";
			tenkhoa.ValueMember="MAKP";
            tenkhoa.DataSource = m.get_data("select * from " + user + ".btdkp_bv where makp<>'01' and loai=0 order by makp").Tables[0];

            dtkpfull = m.get_data("select * from "+user+".btdkp_bv").Tables[0];
            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=1";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by makp";
            dtkp = m.get_data(sql).Tables[0];
            tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=dtkp;
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;

            dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=3 order by maba").Tables[0];
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			tenba.SelectedIndex=0;
			if (m.Mabv.Length>3) mabn1.Text=m.Mabv_so.ToString();
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);
			
			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by tentt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
            tennuoc.DataSource = m.get_data("select * from " + user + ".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

			tendentu.DisplayMember="TEN";
			tendentu.ValueMember="MA";
            tendentu.DataSource = m.get_data("select * from " + user + ".dentu order by ma").Tables[0];
			tendentu.SelectedIndex=-1;

			tennhantu.DisplayMember="TEN";
			tennhantu.ValueMember="MA";
            tennhantu.DataSource = m.get_data("select * from " + user + ".nhantu order by ma").Tables[0];
			tennhantu.SelectedIndex=-1;

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
            dtdt = m.get_data(sql).Tables[0];
			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			tendoituong.DataSource=dtdt;
			if (tendoituong.SelectedIndex!=-1) madoituong.Text=tendoituong.SelectedValue.ToString();

            dtxutri = m.get_data("select ma,to_char(ma,'00')||'   '||ten as ten from " + user + ".xutrikb order by ma").Tables[0];
			xutri.DataSource=dtxutri;
            xutri.DisplayMember = "TEN";
            xutri.ValueMember = "MA";

			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";

			tenloaibv.DisplayMember="TEN";
			tenloaibv.ValueMember="MA";
			tenloaibv.DataSource=m.get_data("select * from "+user+".loaibv order by ma").Tables[0];
			tenloaibv.SelectedIndex=-1;

			tenbv.DisplayMember="TENBV";
			tenbv.ValueMember="MABV";	

			gphaubenh.DisplayMember="TEN";
			gphaubenh.ValueMember="MA";
            gphaubenh.DataSource = m.get_data("select * from " + user + ".gphaubenh").Tables[0];

			cmbTaibien.DisplayMember="TEN";
			cmbTaibien.ValueMember="MA";
            cmbTaibien.DataSource = m.get_data("select * from " + user + ".taibien").Tables[0];

			danhsach.Visible=bHiends;
			if (bHiends)
			{
				list.DisplayMember="HOTEN";
				list.ValueMember="STT";
                list.ColumnWidths[0]=40;
				list.ColumnWidths[1]=60;
				list.ColumnWidths[2]=list.Width-160;
                list.ColumnWidths[3] = 0;
                list.ColumnWidths[4] = 0;
                list.ColumnWidths[5] = 0;
                list.ColumnWidths[6] = 60;
                list.ColumnWidths[7] = 0;
                //list.SetSensive2(5, '3', Color.DarkRed);                
                list.SetSensive1(4, '?', Color.Blue);
                list.SetSensive(5, '1', Color.Red);
                //list.SetSensive(5);
                load_ref();
				if (list.Items.Count==0) danhsach.Visible=false;
				else list.Focus();
			}
		}

        private void load_ref()
        {
            string _ngay = m.f_ngay;
            string ngays = m.ngayhienhanh_server.Substring(0, 10), tu = m.DateToString("dd/MM/yyyy", m.StringToDate(ngays).AddDays(-1));
            sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,";
            sql += " case when a.noitiepdon=16 then 'x' else 'y' end as noitiepdon,";
            sql += " a.done,case when a.done='?' then '2' else case when a.done='d' then '3' else case when a.noitiepdon=16 then '1' else '4' end end end as tt,";
            sql += " case when a.done='?' then 'Đi làm CLS' else case when a.done='d' then 'Có kết quả' else case when a.noitiepdon=16 then 'Tái khám' else 'Chờ khám' end end end as tk,";
            sql += " a.makp,to_char(a.ngay,'yymmddhh24:mi') as yymmdd,a.oid as stt";
            sql += " from xxx.tiepdon a," + user + ".btdbn b ";
            sql += " where a.mabn=b.mabn and (a.done is null or a.done in ('?','d')) ";
            if (bDangky_homqua) sql += " and " + m.for_ngay("a.ngay", "'" + _ngay + "'") + " between to_date('" + tu.Substring(0, 10) + "','" + _ngay + "') and to_date('" + ngays.Substring(0, 10) + "','" + _ngay + "')";
            else sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + ngays.Substring(0, 10) + "'";
            sql += " and a.noitiepdon in (0,1,5,16,9,10,11,12,15) ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by tt,makp,yymmdd,mabn";
            dtlist = m.get_data_mmyy(sql, tu, ngays, false).Tables[0];
            list.DataSource = dtlist;
            lblso.Text = list.Items.Count.ToString();
        }

		private void load_mabv(string maloai)
		{
			if (maloai=="3")
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where substr(maloai,1,1)='2' and mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
			else
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
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
            tenquan.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
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
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				if (makp.Text!="" && l_maql==0) load_phongkham();
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
				this.Text=tenba.Text.Trim()+"< "+lan.Change_language_MessageText("User  :")+s_userid.Trim()+" >";
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
                DataTable dt = m.get_Timmabn(hoten.Text, ngaysinh.Text, namsinh.Text, s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
                    //frmTimMabn f=new frmTimMabn(dt);
                    //f.ShowDialog();
                    //if (f.m_mabn!="")
                    //{
                    //    mabn2.Text=f.m_mabn.Substring(0,2);
                    //    mabn3.Text=f.m_mabn.Substring(2,6);
                    //    s_mabn=mabn2.Text+mabn3.Text;
                    //    load_mabn();
                    //    if (bPhongkham_chandoan) icd_chinh.Focus();
                    //    else ngayvv.Focus();
                    //    SendKeys.Send("{Home}");
                    //    return true;
                    //}
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
			mabn2.Text=mabn2.Text.PadLeft(2,'0');		
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
            nam = "";
			tlblhd.Text="";
			if (bHiends) danhsach.Visible=false;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			load_btdnn(0);
			if (mabn3.Text=="") return;
			bNew=true;
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
            if (load_mabn())
            {
                if (tenkp.Items.Count == 1 && makp.Text != "" && bPhongkham_chidinh && ngayvv.Text!="")
                {
                    if (!kiemtra_dk(ngayvv.Text))
                    {
                        bool bExit=true;
                        if (bDangky_homqua)
                            bExit = !kiemtra_dk(m.DateToString("dd/MM/yyyy", m.StringToDate(ngayvv.Text).AddDays(-1)));
                        if (bExit)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa được chỉ định khám ") + " " + tenkp.Text, LibMedi.AccessData.Msg);
                            butBoqua_Click(sender, e);
                            return;
                        }
                    }
                }
                if (load_vv_mabn())
                {
                    if (!bAdmin && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);
                }
                else load_tiepdon(m.Ngayhienhanh,false);// true);
                ////linh
                //try
                //{
                //    den.Value = int.Parse(sovaovien.Text);
                //    sonhay.Value = 1;
                //    tu.Value = den.Value + 1;
                //}
                //catch { }
                //if (bBangDienPhongKham)
                //{
                //    string _makp = makp.Text.TrimStart('0').PadLeft(2, '0');
                //    Send(_makp + sovaovien.Text.PadLeft(2, '0'));
                //    m.goi_kham(ngaysrv, _makp, _makp + sovaovien.Text.PadLeft(2, '0'), _makp + sovaovien.Text.PadLeft(2, '0'), true);
                //}
                ////end linh
                s_icd_noichuyenden = icd_noichuyenden.Text;
                s_icd_chinh = icd_chinh.Text;
                s_icd_kemtheo = icd_kemtheo.Text;
                if (!bSuadoituong)
                {
                    madoituong.Enabled = false;
                    tendoituong.Enabled = false;
                    sothe.Enabled = false;
                    denngay.Enabled = false;
                }
                if (bPhongkham_chandoan) icd_chinh.Focus();
                else ngayvv.Focus();
                SendKeys.Send("{Home}");
            }
		}

        private bool kiemtra_dk(string ngay)
        {
            if (m.bMmyy(ngay))
            {
                sql = "select * from " + user + m.mmyy(ngay) + ".tiepdon ";
                sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngay + "'";
                sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) and makp='" + makp.Text + "'";
                sql += " and mabn='" + mabn2.Text + mabn3.Text + "'";
                return m.get_data(sql).Tables[0].Rows.Count > 0;
            }
            else return false;
        }

		private bool load_mabn()
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				if (r["ngaysinh"].ToString()!="")
				{
					ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysinh"].ToString()));
					string tuoivao=m.Tuoivao("",ngaysinh.Text);
					tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
					loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				}
				else
				{
					tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
					loaituoi.SelectedIndex=0;
				}
                nam = r["nam"].ToString().Trim();
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
                if (pic.Visible)
                {
                    bool error = false;
                    try
                    {
                        if (pathImage != "")
                        {
                            error = true;
                            pic.Tag = (System.IO.File.Exists(pathImage + "//" + s_mabn + "." + FileType)) ? pathImage + "//" + s_mabn + "." + FileType : "0000.bmp";
                        }
                        else
                        {
                            image = new byte[0];
                            image = (byte[])(r["image"]);
                            memo = new MemoryStream(image);
                            map = new Bitmap(Image.FromStream(memo));
                            pic.Image = (Bitmap)map;
                            pic.Tag = image;
                        }
                    }
                    catch
                    {
                        error = true;
                        pic.Tag = "0000.bmp";
                    }
                    if (error)
                    {
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = (Bitmap)map;
                    }
                }
				break;
			}
			if (ret)
			{
                sql = "select b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".hiendien a," + user + ".btdkp_bv b," + user + ".benhandt c where a.maql=c.maql and a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and c.loaiba=1";
				sql+=" and a.mabn='"+s_mabn+"'";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
					tlblhd.Text=lan.Change_language_MessageText("ĐANG ĐIỀU TRỊ TẠI")+" "+r["tenkp"].ToString().Trim().ToUpper();
			}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
			if (bSoluutru) soluutru.Text=m.get_soluutru(nam,s_mabn);
			load_diungthuoc();
			load_treeView();
			return ret;
		}

		private void load_tiepdon(string m_ngay,bool skip)
		{
            l_matd = 0; s_ngaydk = "";
            string xxx = user + m.mmyy(m_ngay);
            string _ngay = m.f_ngay;
            string ngays = m_ngay, tu = m.DateToString("dd/MM/yyyy", m.StringToDate(ngays).AddDays(-1));
			sql="select * from xxx.tiepdon where mabn='"+s_mabn+"'";
            if (bDangky_homqua) sql += " and " + m.for_ngay("ngay", "'" + _ngay + "'") + " between to_date('" + tu.Substring(0, 10) + "','" + _ngay + "') and to_date('" + ngays.Substring(0, 10) + "','" + _ngay + "')";
            else sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngays.Substring(0, 10) + "'";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
            sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) and (done is null or done in ('?','d')) order by ngay desc";
			foreach(DataRow r in m.get_data_mmyy(sql,tu,m_ngay,false).Tables[0].Rows)
			{
                s_ngaydk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
				if (skip)
				{
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = m.ngayhienhanh_server.Substring(11);
				}
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
				l_maql=long.Parse(r["maql"].ToString());
                l_matd = long.Parse(r["mavaovien"].ToString());
                if (!bSuadoituong)
                {
                    madoituong.Enabled = false;
                    tendoituong.Enabled = false;
                    sothe.Enabled = false;
                    denngay.Enabled = false;
                }
				break;
			}
			if (l_maql!=0)
			{
				emp_bhyt();
                if (dausinhton.Visible)
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
                    {
                        mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                        nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                        huyetap.Text = r["huyetap"].ToString();
                        nang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                        cao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                        break;
                    }                
                }
				foreach(DataRow r in m.get_data("select * from "+xxx+".noigioithieu where maql="+l_maql).Tables[0].Rows)
				{
					madstt.Text=r["mabv"].ToString();
                    tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
					dentu.Text="1";
					tendentu.SelectedIndex=0;
					break;
				}
                foreach (DataRow r in m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0].Rows)
				{
					quanhe.Text=r["quanhe"].ToString();
					qh_hoten.Text=r["hoten"].ToString();
					qh_diachi.Text=r["diachi"].ToString();
					qh_dienthoai.Text=r["dienthoai"].ToString();
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
							s_tungay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
						s_noicap=r["mabv"].ToString();
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					}
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
					if (bBacsy && r["mabs"].ToString()!="")
					{
						mabs.Text=r["mabs"].ToString();
						DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r1!=null) tenbs.Text=r1["hoten"].ToString();
						else tenbs.Text="";
					}
					bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
					loai.SelectedIndex=int.Parse(r["loai"].ToString());
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
			}
            if (!bPhongkham_chidinh)
            {
                if (!bSuadoituong && l_matd == 0)
                {
                    madoituong.Enabled = true;
                    tendoituong.Enabled = true;
                }
            }
            //treeView1.Visible=true;
            //label55.Visible = true;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            emp_rv();
            if (ngayvv.Text == "") return;
			ena_but(true);
            DataRow r1;
            string s_xutri = "", xxx = user + m.mmyy(ngayvv.Text);
            sql = "select a.*,b.soluutru,c.chandoan as k_chandoan,c.maicd as k_maicd from " + xxx + ".benhanpk a inner join " + xxx + ".lienhe b on a.maql=b.maql left join " + xxx + ".cdkemtheo c on a.maql=c.maql where a.maql=" + l_maql;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (!skip)
				{
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);					
				}
                l_matd = long.Parse(r["mavaovien"].ToString());
                tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();

                cd_chinh.Text = r["chandoan"].ToString();
                icd_chinh.Text = r["maicd"].ToString();
                cd_kemtheo.Text = r["k_chandoan"].ToString();
                icd_kemtheo.Text = r["k_maicd"].ToString();

                mabs.Text = r["mabs"].ToString();
                r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                else tenbs.Text = "";
                s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                if (s_xutri == "" && r["ttlucrv"].ToString().PadLeft(2,'0')!="00") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                else
                {
                    if (s_xutri.IndexOf("03,") != -1 && bTaikham_hen)
                    {
                        if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                        {
                            hen.Visible = true;
                            foreach (DataRow r2 in m.get_data("select * from " + xxx + ".hen where maql=" + l_maql).Tables[0].Rows)
                            {
                                hen_ngay.Value = decimal.Parse(r2["songay"].ToString());
                                hen_ghichu.Text = r2["ghichu"].ToString();
                                hen_loai.SelectedIndex = int.Parse(r2["loai"].ToString());
                                chkTiepdon.Checked = r2["tiepdon"].ToString() == "1";
                                break;
                            }
                        }
                    }
                    if (s_xutri.IndexOf("05,") != -1 || s_xutri.IndexOf("02,") != -1 || s_xutri.IndexOf("08,") != -1)
                    {
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa_save = khoa.Text;
                        xutri_save = s_xutri;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                        sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                        if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                        else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                        else if (s_chonxutri.IndexOf("02,") != -1)
                        {
                            //sql += " and makp<>'" + makp.Text + "'";
                            sql += "  and (maba like '%20%'";
                            sql += " or maba like '%21%'";
                            sql += " or maba like '%22%'";
                            sql += " or maba like '%23%')";
                        }
                        //else if (s_chonxutri.IndexOf("02,") == -1) sql += " and makp<>'" + makp.Text + "'";
                        sql += " order by makp";
                        tenkhoa.DataSource = m.get_data(sql).Tables[0];
                        tenkhoa.SelectedValue = khoa.Text;
                    }
                    else loaibv.Enabled = s_xutri.IndexOf("06,") != -1;
                }
                if (s_xutri!="00") maxutri.Text = s_xutri;
                if (maxutri.Text == "" && s_mabs!="")
                {
                    mabs.Text = s_mabs;
                    r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                }
                soluutru.Text = r["soluutru"].ToString();
                bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                if (s_xutri != "")
                {
                    for (int i = 0; i <= xutri.Items.Count; i++)
                        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                }
                if (loaibv.Enabled)
                {
                    foreach (DataRow r2 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                    {
                        tenloaibv.SelectedValue = r2["loaibv"].ToString();
                        mabv.Text = r2["mabv"].ToString();
                        load_mabv(loaibv.Text);
                        tenbv.SelectedValue = mabv.Text;
                        s_mabv = mabv.Text;
                    }
                }
                s_icd_noichuyenden = icd_noichuyenden.Text;
                s_icd_chinh = icd_chinh.Text;
                s_icd_kemtheo = icd_kemtheo.Text;
				if (!bAdmin && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);
                break;
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
            l_maql = 0;
			emp_vv();
			emp_rv();
            if (nam == "") return false;
            DataRow r1;
            string s_xutri,xxx = user + nam.Substring(nam.Length - 5, 4),ngaysrv=m.ngayhienhanh_server.Substring(0,10);
            sql = "select a.*,b.soluutru,c.chandoan as k_chandoan,c.maicd as k_maicd from " + xxx + ".benhanpk a inner join "+xxx+".lienhe b on a.maql=b.maql left join "+xxx+".cdkemtheo c on a.maql=c.maql ";
            sql+=" where a.mabn='" + s_mabn + "' and a.chandoan='' and a.ttlucrv=0 and to_char(a.ngay,'dd/mm/yyyy')='"+ngaysrv+"'";
            if (tenkp.Items.Count == 1)
            {
                if (tenkp.SelectedIndex == -1)
                {
                    tenkp.SelectedIndex = 0;
                    makp.Text = tenkp.SelectedValue.ToString();
                }
                sql += " and a.makp='" + makp.Text + "'";
            }
            sql+=" order by a.ngay desc";
            DataSet lds = m.get_data(sql);
            if (lds != null && lds.Tables.Count > 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    l_matd = long.Parse(r["mavaovien"].ToString());
                    l_maql = long.Parse(r["maql"].ToString());
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                    tenkp.SelectedValue = r["makp"].ToString();
                    tendentu.SelectedValue = r["dentu"].ToString();
                    tennhantu.SelectedValue = r["nhantu"].ToString();
                    tendoituong.SelectedValue = r["madoituong"].ToString();
                    madoituong.Text = r["madoituong"].ToString();
                    sovaovien.Text = r["sovaovien"].ToString();
                    cd_chinh.Text = r["chandoan"].ToString();
                    icd_chinh.Text = r["maicd"].ToString();
                    cd_kemtheo.Text = r["k_chandoan"].ToString();
                    icd_kemtheo.Text = r["k_maicd"].ToString();

                    mabs.Text = r["mabs"].ToString();
                    r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                    s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                    if (s_xutri == "" && r["ttlucrv"].ToString().Trim().PadLeft(2, '0') != "00") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                    else
                    {
                        if (s_xutri.IndexOf("03,") != -1 && bTaikham_hen)
                        {
                            if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                            {
                                hen.Visible = true;
                                foreach (DataRow r2 in m.get_data("select * from " + xxx + ".hen where maql=" + l_maql).Tables[0].Rows)
                                {
                                    hen_ngay.Value = decimal.Parse(r2["songay"].ToString());
                                    hen_ghichu.Text = r2["ghichu"].ToString();
                                    hen_loai.SelectedIndex = int.Parse(r2["loai"].ToString());
                                    chkTiepdon.Checked = r2["tiepdon"].ToString() == "1";
                                    break;
                                }
                            }
                        }
                        if (s_xutri.IndexOf("05,") != -1 || s_xutri.IndexOf("02,") != -1 || s_xutri.IndexOf("08,") != -1)
                        {
                            khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                            tenkhoa.SelectedValue = khoa.Text;
                            khoa_save = khoa.Text;
                            xutri_save = s_xutri;
                            sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                            if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                            else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                            else if (s_chonxutri.IndexOf("02,") != -1)
                            {
                                //sql += " and makp<>'" + makp.Text + "'";
                                sql += "  and (maba like '%20%'";
                                sql += " or maba like '%21%'";
                                sql += " or maba like '%22%'";
                                sql += " or maba like '%23%')";
                            }
                            //else if (s_chonxutri.IndexOf("02,") == -1) sql += " and makp<>'" + makp.Text + "'";
                            sql += " order by makp";
                            tenkhoa.DataSource = m.get_data(sql).Tables[0];
                            tenkhoa.SelectedValue = khoa.Text;
                            khoa.Enabled = true;
                            tenkhoa.Enabled = true;
                        }
                    }
                    if (s_xutri != "00") maxutri.Text = s_xutri;
                    soluutru.Text = r["soluutru"].ToString();
                    bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                    taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                    if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                    giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                    if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                    if (s_xutri != "")
                    {
                        for (int i = 0; i <= xutri.Items.Count; i++)
                            if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                    }
                    if (loaibv.Enabled)
                    {
                        foreach (DataRow r2 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                        {
                            tenloaibv.SelectedValue = r2["loaibv"].ToString();
                            mabv.Text = r2["mabv"].ToString();
                            load_mabv(loaibv.Text);
                            tenbv.SelectedValue = mabv.Text;
                            s_mabv = mabv.Text;
                        }
                    }
                    s_icd_noichuyenden = icd_noichuyenden.Text;
                    s_icd_chinh = icd_chinh.Text;
                    s_icd_kemtheo = icd_kemtheo.Text;
                    break;
                }
            }
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
            string xxx = user + m.mmyy(ngayvv.Text);
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
							s_tungay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
						s_noicap=r["mabv"].ToString();
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					}
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
			if (pmat.Visible)
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".ttmat where maql="+l_maql).Tables[0].Rows)
				{
					mp.Text=r["mp"].ToString();
					mt.Text=r["mt"].ToString();
					nhanapp.Text=r["nhanapp"].ToString();
					nhanapt.Text=r["nhanapt"].ToString();
					break;
				}
			}
            if (dausinhton.Visible)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
                {
                    mach.Text = r["mach"].ToString();
                    nhietdo.Text = r["nhietdo"].ToString();
                    huyetap.Text = r["huyetap"].ToString();
                    nang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    cao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    break;
                }
            }
            if (lydo.Enabled)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".lydokham where maql=" + l_maql).Tables[0].Rows)
                {
                    lydo.Text = r["lydo"].ToString();
                    phanbiet.Text = r["phanbiet"].ToString();
                    break;
                }
            }
            else phanbiet.Text = m.get_phanbiet(ngayvv.Text, l_maql).Trim().Trim();
            if (trieuchung.Enabled) trieuchung.Text = m.get_trieuchung(ngayvv.Text, l_maql).ToString().Trim();
            //treeView1.Visible=true;
            //label55.Visible = true;
			load_phauthuat();
			load_tainantt();
			load_chidinh();
			load_thuocdan();
			load_baohiem();
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

		private void frmKhambenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F1:
                    //if (bGoi || bPhongkham_bangdien_hanoi) butGoilai_Click(sender, e);
                    if (bGoi) butGoi_Click(sender, e);
                    break;
				case Keys.F3:
					l_thuocbhyt_Click(sender,e);
					break;
				case Keys.F5:
					l_thuocdan_Click(sender,e);
					break;
				case Keys.F6:
					l_phauthuat_Click(sender,e);
					break;
				case Keys.F7:
					l_chidinh_Click(sender,e);
					break;
				case Keys.F8:
					l_tonkho_Click(sender,e);
					break;
				case Keys.F9:
					l_tainantt_Click(sender,e);
					break;
				case Keys.F10:
					l_tutruc_Click(sender,e);
					break;
				case Keys.F11:
					l_kemtheo_Click(sender,e);
					break;
				case Keys.F12:
					l_cls_Click(sender,e);
					break;
			}
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.D:
						l_diungthuoc_Click(sender,e);
						break;
                        /*
					case Keys.L:
						l_lichhen_Click(sender,e);
						break;*/
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
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
				tendoituong.SelectedValue=madoituong.Text;
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
				if (sothe.Text=="" && int.Parse(so.Substring(0,2))>0) load_bhyt();
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
				//mabv.Enabled=so.Substring(3,1)=="1";
				//tenbv.Enabled=mabv.Enabled;
				SendKeys.Send("{Tab}");
			}
		}

		private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendoituong)
			{
				try
				{
					madoituong.Text=tendoituong.SelectedValue.ToString();
					string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
					if (sothe.Text=="" && int.Parse(so.Substring(0,2))>0) load_bhyt();
					sothe.Enabled=int.Parse(so.Substring(0,2))>0;
					denngay.Enabled=so.Substring(2,1)=="1";
					mabv.Enabled=so.Substring(3,1)=="1";
					tenbv.Enabled=mabv.Enabled;
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
					sql="select * from xxx.bhyt where mabn='"+s_mabn+"'"+" and denngay>=to_timestamp('"+ngayvv.Text.Substring(0,10)+"','"+m.f_ngay+"')"+" order by maql desc";
				else
					sql="select * from xxx.bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (r["tungay"].ToString()!="")
						s_tungay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
                    if (bSothe_ngay_huong)
                    {
                        if (r["ngay1"].ToString() != "")
                            ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                        if (r["ngay2"].ToString() != "")
                            ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                        if (r["ngay3"].ToString() != "")
                            ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                    }
					if (so.Substring(3,1)=="1") s_noicap=r["mabv"].ToString();
					s_noicap=r["mabv"].ToString();
                    traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					break;
				}
			}
			else
			{
				ngay1=ngay2=ngay3=sothe.Text=denngay.Text=s_tungay="";
				s_noicap=m.Mabv;
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
				if (mabv.Text=="")
				{
                    //frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
                    //f.ShowDialog();
                    //if (f.m_mabv!="")
                    //{
                    //    mabv.Text=f.m_mabv;
                    //    load_mabv(loaibv.Text);
                    //    tenbv.SelectedValue=mabv.Text;
                    //}
				}
				else if (mabv.Text!=s_mabv)
				{
					if (mabv.Text==m.Mabv)
					{
						MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"),s_msg);
						mabv.Text="";
						return;
					}
					load_mabv(loaibv.Text);
					tenbv.SelectedValue=mabv.Text;
					if (tenbv.Items.Count==0)
					{
                        //frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
                        //f.ShowDialog();
                        //if (f.m_mabv!="")
                        //{
                        //    mabv.Text=f.m_mabv;
                        //    load_mabv(loaibv.Text);
                        //    tenbv.SelectedValue=mabv.Text;
                        //}
					}
					s_mabv=mabv.Text;
					SendKeys.Send("{F4}");
				}
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
                    else if (trieuchung.Enabled) trieuchung.Focus();
                    else icd_chinh.Focus();
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
				if (qh_diachi.Text=="") qh_diachi.Text=lan.Change_language_MessageText("Cùng địa chỉ");
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
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_noichuyenden.Text, cd_noichuyenden.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_noichuyenden.Text=f.mTen;
                    //    icd_noichuyenden.Text=f.mICD;
                    //}
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
			else if (icd_chinh.Text!=s_icd_chinh)
			{
				cd_chinh.Text=m.get_vviet(icd_chinh.Text);
				if (cd_chinh.Text=="" && icd_chinh.Text!="")
                {
                //    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
                //    f.ShowDialog();
                //    if (f.mICD!="")
                //    {
                //        cd_chinh.Text=f.mTen;
                //        icd_chinh.Text=f.mICD;
                //    }
				}
				s_icd_chinh=icd_chinh.Text;
			}
		}

		private void cd_kemtheo_Validated(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="") icd_kemtheo.Text=m.get_cicd10(cd_kemtheo.Text);
			if (!m.bMaicd(icd_kemtheo.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_kemtheo.Text="";
				icd_kemtheo.Focus();
			}
		}

		private void icd_kemtheo_Validated(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text!=s_icd_kemtheo)
			{
				if (icd_kemtheo.Text=="") cd_kemtheo.Text="";
				else cd_kemtheo.Text=m.get_vviet(icd_kemtheo.Text);
				if (cd_kemtheo.Text=="" && icd_kemtheo.Text!="")
				{
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kemtheo.Text, cd_kemtheo.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_kemtheo.Text=f.mTen;
                    //    icd_kemtheo.Text=f.mICD;
                    //}
				}
				s_icd_kemtheo=icd_kemtheo.Text;
			}
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
                    if (!m.bNgay(denngay.Text, ngayvv.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày khám bệnh!"), s_msg);
                        denngay.Focus();
                        return;
                    }
                }
			}
			catch{}
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (sothe.Text=="" || so.Substring(0,2)=="00") tendoituong.Focus();
           	else if (m.sothe(int.Parse(tendoituong.SelectedValue.ToString()),sothe.Text)) return;
			else
			{
                MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
				sothe.Focus();
			}
		}

		private void emp_text(bool skip)
		{
            bIn = false;
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
            s_ngaymakp = "";
            this.toolTip1.SetToolTip(this.treeView1, "Ctrl + T : Đơn thuốc");
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
			l_maql=0;
			l_matd=0;
			b_Edit=false;
            if (!bSuadoituong)
            {
                madoituong.Enabled = false;
                tendoituong.Enabled = false;
                sothe.Enabled = false;
                denngay.Enabled = false;
            }
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
            //diungthuoc.Checked=false;
            //l_diungthuoc.ForeColor=Color.FromArgb(0,0,255);
            //ref_check();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			emp_rv();

            if (pic.Visible)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new Bitmap(Image.FromStream(fstr));
                pic.Image = (Bitmap)map;
            }
		}

		private void emp_bhyt()
		{
			sothe.Text=	denngay.Text=s_tungay=ngay1=ngay2=ngay3="";
            s_noicap = m.Mabv; traituyen.SelectedIndex = 0;
		}

		private void emp_vv()
		{
            s_ngayvv = m.ngayhienhanh_server;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);					
			s_ngayvv="";//ngayvv.Text;
			tendentu.SelectedIndex=1;
			tennhantu.SelectedIndex=1;
			try
			{
				madoituong.Text="2";
				tendoituong.SelectedValue=madoituong.Text;
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				//if (sothe.Text=="" && int.Parse(so.Substring(0,2))>0) load_bhyt();
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
			}
			catch{}
            hen.Visible = false;
            hen_ngay.Value = 1;
            hen_loai.SelectedIndex = 0;
            hen_ghichu.Text = "";
            chkTiepdon.Checked = false;
            cao.Text=nang.Text=mach.Text = nhietdo.Text = huyetap.Text = "";
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
            lydo.Text = ""; trieuchung.Text = ""; phanbiet.Text = "";
			mp.Text="";mt.Text="";
			nhanapp.Text="";nhanapt.Text="";
			if (s_mabs!="")
			{
				mabs.Text=s_mabs;
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
			}
            else if (bClear)
            {
                mabs.Text = ""; tenbs.Text = "";
            }
		}

		private void emp_rv()
		{
			cd_chinh.Text="";
			icd_chinh.Text="";
			s_icd_chinh="";
			cd_kemtheo.Text="";
			icd_kemtheo.Text="";
			s_icd_kemtheo="";
			bienchung.Checked=false;
			taibien.Checked=false;
			giaiphau.Checked=false;
			tenloaibv.SelectedIndex=-1;
			tenbv.SelectedIndex=-1;
			tenkhoa.SelectedIndex=-1;
            khoa.Text = ""; khoa_save = ""; xutri_save = "";
			s_mabv="";s_noicap="";
			for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
			maxutri.Text="";
			if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
			else if (!bSoluutru) soluutru.Text="";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
			if (bHiends)
			{
				load_ref();
				danhsach.Visible=(list.Items.Count>0);
				if (!danhsach.Visible) mabn2.Focus();
				else list.Focus();
			}
			else mabn2.Focus();
		}

		private bool kiemtra()
		{
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

            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if ((b_khambenh) || (icd_chinh.Text != "" && cd_chinh.Text != "") || maxutri.Text.Trim() != "08,")
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
					if (bChandoan_kemtheo_icd10 && !m.Kiemtra_maicd(dticd,icd_noichuyenden.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
						icd_noichuyenden.Focus();
						return false;
					}
					if (bChandoan)
					{
						if (bChandoan_kemtheo_icd10 && !m.Kiemtra_tenbenh(dticd,cd_noichuyenden.Text))
						{
							MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
							cd_noichuyenden.Focus();
							return false;
						}
					}
                    //

                    //
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
            //kiem tra gio dang ky voi gio kham
            if (giovv.Enabled)
            {
                string m_ngay = m.get_ngaytiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (m_ngay != "")
                {
                    if (!m.bNgaygio(ngayvv.Text + " " + giovv.Text, m_ngay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                        ngayvv.Focus();
                        return false;
                    }
                }
            }
            //
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
                        MessageBox.Show(lan.Change_language_MessageText("Nhập số thẻ !"), s_msg);
						sothe.Focus();
						return false;
					}
                    else if (!m.sothe(int.Parse(tendoituong.SelectedValue.ToString()), sothe.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
					if (so.Substring(2,1)=="1" && denngay.Text=="")
					{
                        MessageBox.Show(lan.Change_language_MessageText("Nhập ngày hết hạn !"), s_msg);
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

			s_chonxutri=chon_xutri();
			if (s_chonxutri!="")
			{
				if ((s_chonxutri.IndexOf("06,")!=-1 && (s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("08,")!=-1)) || (s_chonxutri.IndexOf("07,")!=-1 && s_chonxutri.Length>3))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí không hợp lệ !"),LibMedi.AccessData.Msg);
					xutri.Focus();
					return false;
				}
			}
            if (bPhongkham_khongduocxutri_chuyenvien)
            {
                if(s_chonxutri.IndexOf("06,")>=0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Phòng khám chưa được phân quyền chức năng chuyển viện !"), LibMedi.AccessData.Msg);
					xutri.Focus();
					return false;
                }
            }
            if (maxutri.Text.Trim() != "08,")
            {
                if ((b_khambenh) || (icd_chinh.Text != "" && cd_chinh.Text != "") || (s_chonxutri != ""))
                {
                    if (s_chonxutri == "" && mabs.Enabled)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"), s_msg);
                        xutri.Focus();
                        return false;
                    }

                    if (icd_chinh.Text == "" && cd_chinh.Text == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                        icd_chinh.Focus();
                        return false;
                    }
                    else if (icd_chinh.Text == "" && cd_chinh.Text != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                        icd_chinh.Focus();
                        return false;
                    }
                    else if (cd_chinh.Text == "" && icd_chinh.Text != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"), s_msg);
                        if (cd_chinh.Enabled) cd_chinh.Focus();
                        else icd_chinh.Focus();
                        return false;
                    }
                    if (bChandoan && !m.Kiemtra_maicd(dticd, icd_chinh.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                        icd_chinh.Focus();
                        return false;
                    }
                    if (bChandoan)
                    {
                        if (!m.Kiemtra_tenbenh(dticd, cd_chinh.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                            cd_chinh.Focus();
                            return false;
                        }
                    }
                    if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh kèm theo !"), s_msg);
                        icd_kemtheo.Focus();
                        return false;
                    }
                    else if (cd_kemtheo.Text == "" && icd_kemtheo.Text != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh kèm theo !"), s_msg);
                        if (cd_kemtheo.Enabled) cd_kemtheo.Focus();
                        else icd_kemtheo.Focus();
                        return false;
                    }
                    if (bChandoan_kemtheo_icd10 && !m.Kiemtra_maicd(dticd, icd_kemtheo.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                        icd_kemtheo.Focus();
                        return false;
                    }
                    if (bChandoan_kemtheo_icd10)
                    {
                        if (!m.Kiemtra_tenbenh(dticd, cd_kemtheo.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                            cd_kemtheo.Focus();
                            return false;
                        }
                    }
                    if (mabs.Text == "" || tenbs.Text == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                        mabs.Focus();
                        return false;
                    }

                    if (s_chonxutri.IndexOf("06,") != -1)
                    {
                        if (tenloaibv.SelectedIndex == -1 || loaibv.Text == "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển viện !"), s_msg);
                            loaibv.Focus();
                            return false;
                        }

                        if (mabv.Text == "" || tenbv.SelectedIndex == -1)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển đến !"), s_msg);
                            mabv.Focus();
                            return false;
                        }
                    }

                    if (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("08,") != -1)
                    {
                        if (tenkhoa.SelectedIndex == -1 || khoa.Text == "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Nhập vào khoa/phòng !"), s_msg);
                            khoa.Focus();
                            return false;
                        }
                    }

                }
            }
            else if (bChuyenkham_chandoan)
            {
                if (icd_chinh.Text == "" && cd_chinh.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                    icd_chinh.Focus();
                    return false;
                }
                else if (icd_chinh.Text == "" && cd_chinh.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"), s_msg);
                    icd_chinh.Focus();
                    return false;
                }
                else if (cd_chinh.Text == "" && icd_chinh.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"), s_msg);
                    if (cd_chinh.Enabled) cd_chinh.Focus();
                    else icd_chinh.Focus();
                    return false;
                }
                if (!m.Kiemtra_maicd(dticd, icd_chinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                    icd_chinh.Focus();
                    return false;
                }
                if (bChandoan)
                {
                    if (!m.Kiemtra_tenbenh(dticd, cd_chinh.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                        cd_chinh.Focus();
                        return false;
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
			if (soluutru.Text=="" && b_soluutru && soluutru.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lưu trữ !"),s_msg);
				soluutru.Focus();
				return false;
			}
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
			s_mabn=mabn2.Text+mabn3.Text;
            long maql1 = m.get_maql_benhanpk(s_mabn, ngayvv.Text+" "+giovv.Text,makp.Text,false);
            if (maql1 == 0)
            {
                if (m.bTuvong(s_mabn))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                }
                if (bPhongkham_chidinh)
                {
                    if (!kiemtra_dk_pk(ngayvv.Text))
                    {
                        bool bExit = true;
                        if (bDangky_homqua)
                            bExit = !kiemtra_dk_pk(m.DateToString("dd/MM/yyyy", m.StringToDate(ngayvv.Text).AddDays(-1)));
                        if (bExit)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa được chỉ định khám ") + " " + tenkp.Text, LibMedi.AccessData.Msg);
                            butBoqua.Focus();
                            return false;
                        }
                    }
                }
   
                sql = "select * from " + user + m.mmyy(ngayvv.Text) + ".benhanpk where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
                sql += " and makp='" + makp.Text + "' and maql<>" + maql1;
                if (m.get_data(sql).Tables[0].Rows.Count > 0)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {") + tenkp.Text.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Bạn có muốn lưu thêm 1 đợt nữa không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        butTiep.Focus();
                        return false;
                    }
                }
            }
            if (bInchitiet)
            {
                string _tenkp = m.inchiphipk(ngayvv.Text, l_matd);
                if (_tenkp != "" && !bIn)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại")+" " + _tenkp +"\n"+ lan.Change_language_MessageText("Không cho phép thay đổi thông tin !"), s_msg);
                    return false;
                }
            }
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = m.mabn_bhyt(nam, mabn2.Text + mabn3.Text, sothe.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ")+" " + sothe.Text +"\n"+ lan.Change_language_MessageText("Đã có mã người bệnh :") + s +"\n"+ lan.Change_language_MessageText("Sử dụng !)"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="")// && maql1==0)
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
						s_tenkp=m.bNhapvien(s_mabn,2);
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
						s_tenkp=m.bNhapvien(s_mabn,1);
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
			else loai.SelectedIndex=0;
            if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen && Taikham_songay != 0)
            {
                if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                {
                    string ngay = "";
                    DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                    switch (hen_loai.SelectedIndex)
                    {
                        case 2: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 3: ngay = m.DateToString("dd/MM/yyyy", dt.AddMonths(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 4: ngay = m.DateToString("dd/MM/yyyy", dt.AddYears(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        default: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(Convert.ToInt16(hen_ngay.Value)));
                            break;
                    }
                    long songay = m.songay(m.StringToDate(ngay), m.StringToDate(ngayvv.Text.Substring(0, 10)), 0);
                    if (songay > Taikham_songay)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Hẹn tái khám")+" " + songay.ToString() + " ngày\nvượt quá số ngày qui định " + Taikham_songay.ToString(), LibMedi.AccessData.Msg);
                        hen_ngay.Focus();
                        return false;
                    }
                }
            }
			return true;
		}

        private bool kiemtra_dk_pk(string ngay)
        {
            if (m.bMmyy(m.mmyy(ngay)))
            {
                sql = "select * from " + user + m.mmyy(ngay) + ".tiepdon ";
                sql += " where (done is null or done in ('?','d')) and to_char(ngay,'dd/mm/yyyy')='" + ngay + "'";
                sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) and makp='" + makp.Text + "'";
                sql += " and madoituong=" + int.Parse(tendoituong.SelectedValue.ToString());
                sql += " and mabn='" + s_mabn + "'";
                return m.get_data(sql).Tables[0].Rows.Count > 0;
            }
            else return false;
        }
		private string chon_xutri()
		{
			string s="";
			for(int i=0;i<xutri.Items.Count;i++)
				if (xutri.GetItemChecked(i)) s+=dtxutri.Rows[i]["ma"].ToString().Trim().PadLeft(2,'0')+",";
			maxutri.Text=s;
			return s;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			int p=0;string s_ttlucrv="0",zzz=user+m.mmyy(ngayvv.Text);
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (s_chonxutri!="")
			{
				p=s_chonxutri.IndexOf(",");
				s_ttlucrv=s_chonxutri.Substring(0,p);
			}
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			s_mabn=mabn2.Text+mabn3.Text;
            xxx = user + m.mmyy(ngayvv.Text);
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhanpk");
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, true);
            if (m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", m.fields(zzz + ".benhanpk", "maql=" + l_maql));
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql,l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(),i_userid, 0,LibMedi.AccessData.Khambenh, 0);
                        if (int.Parse(so.Substring(0, 2)) > 0)
                              m.upd_bhyt(ngayvv.Text, s_mabn, l_matd, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Khambenh, l_maql);
            }
			if (!m.upd_lienhe(ngayvv.Text,l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (bSoluutru && soluutru.Text!="") m.execute_data("update "+xxx+".lienhe set soluutru='"+soluutru.Text+"' where maql="+l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),kinhcc.Text,ngaysanh.Text,"");
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nang.Text != "") ? decimal.Parse(nang.Text) : 0, (cao.Text != "") ? decimal.Parse(cao.Text) : 0);
            if (!m.upd_benhanpk(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, (s_ttlucrv != "") ? int.Parse(s_ttlucrv) : 0, mabs.Text, sovaovien.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? 1 : 0, (giaiphau.Checked) ? 1 : 0, 0, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}		
	        //
            if(mabs.Text.Trim()!="" )upd_mabs_toathuoc(l_maql, mabs.Text);
            //
			if (int.Parse(so.Substring(0,2))>0)
				m.upd_bhyt(ngayvv.Text,s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap,0,s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
			if (cd_noichuyenden.Text!="" || madstt.Text!="")
			{
				if (!m.upd_noigioithieu(ngayvv.Text,l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (quanhe.Text!="") m.upd_quanhe(ngayvv.Text,l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
            if (trieuchung.Text != "") m.upd_trieuchung(ngayvv.Text, l_maql, trieuchung.Text);
            m.upd_lydokham(ngayvv.Text, l_maql, lydo.Text,phanbiet.Text);
            if (s_chonxutri != "")
            {
                if (pmat.Visible) m.upd_ttmat(ngayvv.Text, l_maql, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
                if (s_chonxutri.IndexOf("07,") != -1)
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count == 0)
                        l_tuvong_Click(null, null);
                m.upd_xutrikbct(ngayvv.Text, l_maql, s_chonxutri, khoa.Text);
                if (cd_kemtheo.Text != "") m.upd_cdkemtheo(ngayvv.Text, l_maql, l_maql, 4, cd_kemtheo.Text, icd_kemtheo.Text, 1);
                else m.execute_data("delete from " + xxx + ".cdkemtheo where stt=1 and loai=4 and maql=" + l_maql);
                if (loaibv.Enabled && loaibv.Text != "") m.upd_chuyenvien(l_maql, mabv.Text, int.Parse(loaibv.Text));
                else m.execute_data("delete from " + user + ".chuyenvien where maql=" + l_maql);
                m.execute_data("update " + xxx + ".tiepdon set done='x' where noitiepdon in (0,1,5,16,9,10,11,12,15) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'");
                if (bDangky_homqua && s_ngaydk != "")
                    if (s_ngaydk.Substring(0, 10) != ngayvv.Text.Substring(0, 10) && m.bMmyy(m.mmyy(s_ngaydk))) m.execute_data("update " + user+m.mmyy(s_ngaydk) + ".tiepdon set done='x' where noitiepdon in (0,1,5,16,9,10,11,12,15) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + s_ngaydk.Substring(0, 10) + "' and makp='" + makp.Text + "'");
                long maluu = l_maql;
                long maql1 = 0;
   				if (s_chonxutri.IndexOf("03,")!=-1  && bTaikham_hen)
				{
                    if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                    {
                        m.upd_hen(ngayvv.Text, l_maql, hen_ngay.Value, hen_ghichu.Text, hen_loai.SelectedIndex, (chkTiepdon.Checked) ? 1 : 0);
                        if (hen_loai.SelectedIndex != 0 && !chkTiepdon.Checked)
                        {
                            DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                            string ngay;
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
                            //if (!m.bMmyy(m.mmyy(ngay))) m.tao_schema(m.mmyy(ngay), i_userid);
                            if (m.mmyy(ngayvv.Text) == m.mmyy(ngay))
                            {
                                maql1 = m.get_maql_tiepdon(s_mabn, ngay + " 07:00");
                                string sokham = (i_sokham == 2) ? m.get_sokham(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                                if (sokham != "")
                                {
                                    string s = hen_ghichu.Text.Trim();
                                    hen_ghichu.Text = s + " Số thứ tự khám :" + sokham;
                                }
                                m.upd_tiepdon(s_mabn, (l_matd == 0) ? l_maql : l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex);
                                m.upd_lienhe(ngay,maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                    m.upd_bhyt(ngay,s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                            }
                            else
                            {
                                maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                                string sokham = (i_sokham == 2) ? m.get_sokham_hen(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                                if (sokham != "")
                                {
                                    string s = hen_ghichu.Text.Trim();
                                    hen_ghichu.Text = s + " Số thứ tự khám :" + sokham;
                                }
                                m.upd_tiepdon_hen(s_mabn, (l_matd == 0) ? l_maql : l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex, ngayvv.Text + " " + giovv.Text);
                                m.upd_lienhe(maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                    m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                            }
                            if (bTaikham_v_chidinh) upd_data(maql1, makp.Text, ngay);
                        }
                        else if (hen_loai.SelectedIndex == 0 && !chkTiepdon.Checked) upd_hen();//hen_butin_Click(sender,e);
                    }
                }
                if (s_chonxutri.IndexOf("08,") != -1)
                {
                    string sokham = "";
                    maql1 = m.get_maql(s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text);
                    if (i_sokham != 3 && khoa.Text != "" && bNew)
                    {
                        sokham = m.get_sokham(ngayvv.Text.Substring(0, 10), khoa.Text, i_sokham).ToString();
                        MessageBox.Show(lan.Change_language_MessageText("Số khám ") + " " + tenkhoa.Text.ToUpper().Trim() + ":\n" + sokham, LibMedi.AccessData.Msg);
                    }
                    m.upd_tiepdon(s_mabn, l_matd, maql1, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), (sokham != "") ? sokham : sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Khambenh, 0);
                    m.upd_lienhe(ngayvv.Text, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    if (int.Parse(so.Substring(0, 2)) > 0)
                        m.upd_bhyt(ngayvv.Text, s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                    if (!bChuyenkham_dscho || bChuyenkham_tinhcongkham && !m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString()))|| (bChuyenkham_thuphi && m.bThuphi(int.Parse(tendoituong.SelectedValue.ToString())))) upd_data(maql1,khoa.Text,ngayvv.Text);
                }
                else
                {
                    if (xutri_save.IndexOf("08,") != -1)
                    {
                        maql1 = m.get_maql(s_mabn, khoa_save, ngayvv.Text + " " + giovv.Text);
                        m.execute_data("delete from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where maql=" + maql1);
                        m.execute_data("delete from " + user + m.mmyy(ngayvv.Text) + ".lienhe where maql=" + maql1);
                        if (int.Parse(so.Substring(0, 2)) > 0) m.execute_data("delete from " + user + m.mmyy(ngayvv.Text) + ".bhyt where maql=" + maql1);
                    }
                    if (s_chonxutri.IndexOf("02,") != -1) //dieu tri ngoai tru
                    {
                        if (bXutri_ngoaitru) upd_ngoaitru(so);
                        else
                        {
                            m.execute_data("delete from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' and done is null and noitiepdon=-1 and makp='"+khoa_save+"'");
                            maql1 = m.get_maql(s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text);
                            m.upd_tiepdon(s_mabn, l_matd, maql1, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, -1, 0);
                            m.upd_lienhe(ngayvv.Text, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                            if (int.Parse(so.Substring(0, 2)) > 0)
                                m.upd_bhyt(ngayvv.Text, s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                        }
                    }
                    if (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru) //noi tru
                        upd_noitru(so);
                    if (s_chonxutri.IndexOf("04,") != -1 && bXutri_phongluu) 
                        upd_phongluu(so);
                }
                l_maql = maluu;
            }
            else
            {
                m.execute_data("update " + xxx + ".tiepdon set done='?' where done is null and noitiepdon in (0,1,5,16,9,10,11,12,15) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'");
                if (bDangky_homqua && s_ngaydk!="")
                    if (s_ngaydk.Substring(0,10)!=ngayvv.Text.Substring(0,10) && m.bMmyy(m.mmyy(s_ngaydk)))
                        m.execute_data("update " + user+m.mmyy(s_ngaydk) + ".tiepdon set done='?' where done is null and noitiepdon in (0,1,5,16,9,10,11,12,15) and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + s_ngaydk.Substring(0, 10) + "' and makp='" + makp.Text + "'");
            }
			if (sender!=null)
			{
				ena_but(false);
				butTiep.Focus();
			}
		}

        private void upd_phongluu(string so)
        {
            string makp_pl = "99";
            s_mabn = mabn2.Text + mabn3.Text;
            long l_mapl = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, true);
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhancc");
            if (m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_maql.ToString() + "^" + l_mapl.ToString() + "^" + makp_pl + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_mapl, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_mapl, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, 0, 0);
            if (!m.upd_lienhe(ngayvv.Text, l_mapl, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            if (!m.upd_benhancc(s_mabn, l_maql, l_mapl, makp_pl, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()),mabs.Text,cd_chinh.Text, icd_chinh.Text, sovaovien.Text, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            if (int.Parse(so.Substring(0, 2)) > 0)
                m.upd_bhyt(ngayvv.Text, s_mabn, l_mapl, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);

            if (cd_noichuyenden.Text != "" || madstt.Text != "")
            {
                if (!m.upd_noigioithieu(ngayvv.Text, l_mapl, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                    return;
                }
            }
            if (manuoc.Enabled && manuoc.Text != "") m.upd_nuocngoai(s_mabn, manuoc.Text);
            else m.execute_data("delete from " + user + ".nuocngoai where mabn='" + s_mabn + "'");
            if (quanhe.Text != "") m.upd_quanhe(ngayvv.Text, l_mapl, quanhe.Text, qh_hoten.Text, qh_diachi.Text, qh_dienthoai.Text);
            if (pmat.Visible) m.upd_ttmat(ngayvv.Text, l_mapl, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
            else m.upd_lydokham(ngayvv.Text, l_mapl, lydo.Text);
            if (trieuchung.Text != "") m.upd_trieuchung(ngayvv.Text, l_mapl, trieuchung.Text);
        }

        private void upd_data(long maql,string makhoa,string ngay)
        {
            DataRow r = m.getrowbyid(dtkpfull, "makp='" + makhoa + "'");
            if (r != null)
            {
                int _mavp = int.Parse(r["mavp"].ToString());
                decimal d_dongia = 0, d_vattu = 0;
                string mmyy = m.mmyy(ngay);
                int i_madt = int.Parse(madoituong.Text);
                r = m.getrowbyid(dtgia, "id=" + _mavp);
                if (r != null)
                {
                    long l_id = m.get_id_chidinh(ngay, maql, _mavp, v.iNgoaitru);
                    if (l_id == 0) l_id = v.get_id_chidinh;
                    if (m.bNuocngoai(mabn2.Text + mabn3.Text))
                    {
                        d_dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                        d_vattu = decimal.Parse(r["vattu_nn"].ToString()) * m.dTygia;
                    }
                    else
                    {
                        string gia = m.field_gia(tendoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        d_dongia = decimal.Parse(r[gia].ToString());
                        d_vattu = decimal.Parse(r[giavt].ToString());
                    }
                    if (bChuyenkham_tinh_congkham_dtthuphi && i_madt==1) i_madt = 2;
                    v.upd_chidinh(l_id, mabn2.Text + mabn3.Text,l_matd, maql, 0, ngay, v.iNgoaitru, makhoa, i_madt, _mavp, 1, d_dongia, d_vattu, i_userid, 0, 0,l_id,icd_chinh.Text,cd_chinh.Text,mabs.Text,3,"");
                    v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + l_id);
                    //if (bThuphi_kham)
                    //{
                        r = m.getrowbyid(dtdt, "mien=0 and madoituong=" + int.Parse(tendoituong.SelectedValue.ToString()));
                        if (r != null)
                        {
                            m.execute_data("update " + user + m.mmyy(ngay) + ".tiepdon set done='x' where maql=" + maql);
                            if (bDangky_homqua && s_ngaydk!="")
                                if (s_ngaydk.Substring(0,10)!=ngay && m.bMmyy(m.mmyy(s_ngaydk)))
                                    m.execute_data("update " + user + m.mmyy(s_ngaydk) + ".tiepdon set done='x' where maql=" + maql);
                        }
                    //}
                }
            }
        }

        private void upd_hen()
        {
            long maql1;
            s_mabn = mabn2.Text + mabn3.Text;
            string ngay, so,sokham;
            /*
            if (s_noicap != "")
                foreach (DataRow r1 in m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='" + s_noicap + "'").Tables[0].Rows)
                    noidkkcb = r1["tenbv"].ToString();
             */
            DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
            for (int i = 1; i <= Convert.ToInt16(hen_ngay.Value); i++)
            {
                ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(i));
                //if (!m.bMmyy(m.mmyy(ngay))) m.tao_schema(m.mmyy(ngay), i_userid);
                if (m.mmyy(ngayvv.Text) == m.mmyy(ngay))
                {
                    maql1 = m.get_maql_tiepdon(s_mabn, ngay + " 07:00");
                    sokham = (i_sokham == 2) ? m.get_sokham(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                    m.upd_tiepdon(s_mabn,(l_matd==0)? l_maql:l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex);
                    m.upd_lienhe(ngay,maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (int.Parse(so.Substring(0, 2)) > 0)
                        m.upd_bhyt(ngay,s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                }
                else
                {
                    maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                    sokham = (i_sokham == 2) ? m.get_sokham_hen(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                    m.upd_tiepdon_hen(s_mabn, (l_matd == 0) ? l_maql : l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex, ngayvv.Text + " " + giovv.Text);
                    m.upd_lienhe(maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (int.Parse(so.Substring(0, 2)) > 0)
                        m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
                    if (bTaikham_v_chidinh) upd_data(maql1, makp.Text,ngay);
                }
            }
        }
		private void upd_noitru(string so)
		{
            
            int itable = m.tableid("","benhandt");
            if (m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + khoa.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + "1" + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + sovaovien.Text + "^" + "1" + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            l_maql = m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, true);
            //
            if (m.get_data("select * from " + m.user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
            {
                return;
            }
            //
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, mabs.Text,"", 1, i_userid, true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (int.Parse(so.Substring(0,2))>0) m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
			if (cd_noichuyenden.Text!="")
			{
				if (!m.upd_noigioithieu(l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=1 and maql="+l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Nhanbenh,l_maql);
            m.execute_data("delete from " + user + ".hiendien where nhapkhoa=0 and xuatkhoa=0 and mabn='" + s_mabn + "' and makp<>'" + khoa.Text + "'");
			long tmpid=m.get_id_hiendien_do_cdvv(s_mabn,l_maql,"01");
            long l_idhiendien = (tmpid == 0) ? m.get_id(l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text) : tmpid;//tinh them gio
            m.upd_hiendien(l_idhiendien, s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, ngayvv.Text + " " + giovv.Text, "", mabs.Text,icd_chinh.Text, "01", 0, 0);
            if (bNhapvien_kocongkham && (sNhapvien_kocongkham_madoituong=="" || sNhapvien_kocongkham_madoituong.IndexOf(madoituong.Text.PadLeft(2,'0'))!=-1))
            {
                DataRow r1 = m.getrowbyid(dtkpfull, "makp='" + makp.Text + "'");
                int imavp = (r1 != null) ? int.Parse(r1["mavp"].ToString()) : imavp_congkham;
                if (imavp != 0)
                {
                    long _maql = m.get_maql_benhanpk(s_mabn,ngayvv.Text+" "+giovv.Text,makp.Text, false);
                    foreach (DataRow r in m.get_data("select a.mavaovien,b.mavp, b.mavptk from " + user + m.mmyy(ngayvv.Text) + ".benhanpk a,"+user+".btdkp_bv b where a.makp=b.makp and a.maql=" + _maql + " and a.makp='" + makp.Text + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'").Tables[0].Rows)
                    {
                        string sql1 = "delete from xxx.v_chidinh where mavaovien=" + long.Parse(r["mavaovien"].ToString()) + " and (mavp=" + long.Parse(r["mavp"].ToString());
                        if (r["mavptk"].ToString() != "") sql1 += " or  mavp=" + long.Parse(r["mavptk"].ToString()) + ")";
                        else sql1 += ")";
                        m.execute_data_mmyy(sql1, ngayvv.Text.Substring(0, 10), ngayvv.Text.Substring(0, 10),true);
                        break;
                    }
                }
            }
		}

		private void upd_ngoaitru(string so)
		{
            int itable = m.tableid("","benhanngtr");
            if (m.get_maql_benhanngtr(s_mabn, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvv.Text + " " + giovv.Text, true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhanngtr(s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, sovaovien.Text, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (int.Parse(so.Substring(0,2))>0) m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, s_noicap, 0, s_tungay,ngay1,ngay2,ngay3,traituyen.SelectedIndex);
			
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
            icd_chinh.Enabled = ena;
            cd_chinh.Enabled = ena;
            xutri.Enabled = ena;
            maxutri.Enabled = ena;
            icd_kemtheo.Enabled = ena;
            cd_kemtheo.Enabled = ena;
            butIn.Enabled = !ena;
            if (bInchitiet) butInchitiet.Enabled = !ena;
            butTiep.Enabled=butKetthuc.Enabled=butIncv.Enabled = !ena;
            lydo.Enabled = ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            ena_but(false);
			//butTiep_Click(null,null);
		}

		private void nhantu_TextChanged(object sender, System.EventArgs e)
		{
			nhantu.Text=nhantu.Text;
		}
        
        private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "") return;
            try
            {
                s_mabn = mabn2.Text + mabn3.Text;
                TreeNode node;
                foreach (DataRow r in m.get_data_nam(nam, "select a.ngay,a.makp,b.tenkp,a.chandoan,to_char(a.ngay,'yyyymmdd') as yyyymmdd from xxx.benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + s_mabn + "' and mangtr=0").Tables[0].Select("true", "yyyymmdd desc"))
                {
                    node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + " " + r["tenkp"].ToString().Trim() + "(" + r["makp"].ToString() + ")");
                    node.Nodes.Add(r["chandoan"].ToString());
                }
                //treeView1.ExpandAll();
            }
            catch { }
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse || e.Action==TreeViewAction.ByKeyboard)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
                    s_ngaymakp = s;
					int iPos=s.IndexOf("/");
                    string ngay = s.Substring(iPos - 2, 16), kp = s.Substring(s.IndexOf("(")+1, 2);
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql_benhanpk(s_mabn,kp,ngay);
					if (l_maql!=0)
					{
                        ngayvv.Text = ngay.Substring(0,10);
                        giovv.Text = ngay.Substring(11);
						load_vv_maql(true);
					}
				}
				catch{}
			}
		}

		private void l_phauthuat_Click(object sender, System.EventArgs e)
		{
            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmPttt f = new frmPttt(m, makp.Text, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, "", ngayvv.Text + " " + giovv.Text, cd_chinh.Text, icd_chinh.Text, "P", i_userid, "", "", "",l_maql,l_matd,0,3,false);
            //f.ShowDialog();
            //load_phauthuat();
		}


		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
				if (b_bacsi)
				{
					dtbs=m.get_data("select ma, hoten, makp, mapk, viettat from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") and mapk='"+makp.Text+"'"+" order by ma").Tables[0];
					if (dtbs.Rows.Count==0)
                        dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				}
                else dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				listBS.DataSource=dtbs;
                if (s_mabs != "")
                {
                    mabs.Text = s_mabs;
                    DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r != null) tenbs.Text = r["hoten"].ToString();
                    else tenbs.Text = "";
                }
			}
			catch{makp.Text="";}
		}

		private void giaiphau_CheckStateChanged(object sender, System.EventArgs e)
		{
			gphaubenh.Visible=giaiphau.Checked;
		}

		private void l_tainantt_Click(object sender, System.EventArgs e)
		{            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmTainantt f = new frmTainantt(m, l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid);
            //f.ShowDialog();
			//load_tainantt();
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
            //treeView1.Visible=false;
            //label55.Visible = false;
			Filt_dstt(tendstt.Text);
			listdstt.BrowseToText(tendstt,madstt,makp,madstt.Location.X-117,madstt.Location.Y+madstt.Height-2,madstt.Width+tendstt.Width+2+116,madstt.Height);
		}

		private void listdstt_Validated(object sender, System.EventArgs e)
		{
            //treeView1.Visible=true;
            //label55.Visible = true;
		}

		private void tendstt_Validated(object sender, System.EventArgs e)
		{
			if(!listdstt.Focused)
			{
				listdstt.Hide();
                //treeView1.Visible=true;
                //label55.Visible = true;
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
						tennn.DataSource=m.get_data("select * from "+user+".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void cd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_noichuyenden)
			{
				if (bChandoan || icd_noichuyenden.Text=="" || icd_noichuyenden.Text.Trim()==u00)
				{
					Filt_ICD(cd_noichuyenden.Text);
                    if (trieuchung.Enabled)
                        listICD.BrowseToICD10(cd_noichuyenden, icd_noichuyenden, trieuchung, icd_chinh.Location.X-422, pvaovien.Location.Y-118 + pvaovien.Height - icd_noichuyenden.Height + 18, icd_noichuyenden.Width + cd_noichuyenden.Width + 2, icd_noichuyenden.Height);
                    else
                        listICD.BrowseToICD10(cd_noichuyenden, icd_noichuyenden, icd_chinh, icd_chinh.Location.X - 422, pvaovien.Location.Y - 118 + pvaovien.Height - icd_noichuyenden.Height + 18, icd_noichuyenden.Width + cd_noichuyenden.Width + 2, icd_noichuyenden.Height);
				}
			}
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
				if (bChandoan || icd_chinh.Text=="" || icd_chinh.Text.Trim()==u00)
				{
					Filt_ICD(cd_chinh.Text);
                    if (bPhongkham_chandoan)
                    {
                        if (lydo.Enabled) listICD.BrowseToICD10(cd_chinh,icd_chinh,lydo,icd_chinh.Location.X-421,icd_chinh.Location.Y+icd_chinh.Height-2,icd_chinh.Width+cd_chinh.Width+2+421,icd_chinh.Height);
                        else listICD.BrowseToICD10(cd_chinh,icd_chinh,mabs,icd_chinh.Location.X-421,icd_chinh.Location.Y+icd_chinh.Height-2,icd_chinh.Width+cd_chinh.Width+2+421,icd_chinh.Height);
                    }
					else listICD.BrowseToICD10(cd_chinh,icd_chinh,icd_kemtheo,icd_chinh.Location.X-421,icd_chinh.Location.Y+icd_chinh.Height-2,icd_chinh.Width+cd_chinh.Width+2+421,icd_chinh.Height);
				}
			}
		}

		private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kemtheo)
			{
				if (bChandoan || icd_kemtheo.Text=="" || icd_kemtheo.Text.Trim()==u00)
				{
					Filt_ICD(cd_kemtheo.Text);
					listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,phanbiet,icd_kemtheo.Location.X-421,icd_kemtheo.Location.Y+icd_kemtheo.Height-2,icd_kemtheo.Width+cd_kemtheo.Width+2+421,icd_kemtheo.Height);
				}
			}		
		}

		private void Filt_ICD(string ten)
		{
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listICD.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "vviet like '%" + ten.Trim() + "%'";
            }
            catch { }
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
				danhsach.Visible=false;
				mabn2.Focus();
			}
			else if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) gan_mabn();
		}

		private void gan_mabn()
		{
			try
			{
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + long.Parse(list.SelectedValue.ToString()));
                s_mabn = (r1 != null) ? r1["mabn"].ToString() : "";
				if (s_mabn!="")
				{
					mabn2.Text=s_mabn.Substring(0,2);
					mabn3.Text=s_mabn.Substring(2);
					mabn3_Validated(null,null);
                    string ngaysrv = m.ngayhienhanh_server,zzz = user + m.mmyy(ngaysrv), s = "";
                    sql = "select mavaovien,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + zzz + ".benhanpk where mabn='" + s_mabn + "' and (chandoan='' or ttlucrv=0) and to_char(ngay,'dd/mm/yyyy')='"+ngaysrv.Substring(0,10)+"'";
                    if (tenkp.Items.Count == 1)
                    {
                        if (tenkp.SelectedIndex == -1)
                        {
                            tenkp.SelectedIndex = 0;
                            makp.Text = tenkp.SelectedValue.ToString();
                        }
                        sql += " and makp='" + makp.Text + "'";
                    }
                    else
                    {
                        if (s_makp != "")
                        {
                            string s1 = s_makp.Replace(",", "','");
                            sql += " and makp in ('" + s1.Substring(0, s1.Length - 3) + "')";
                        }
                    }
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        l_matd = long.Parse(r["mavaovien"].ToString());
                        l_maql = long.Parse(r["maql"].ToString());
                        s_ngayvv = ngayvv.Text;
                        ngayvv.Text = r["ngay"].ToString().Substring(0,10);
                        giovv.Text = (r["ngay"].ToString().Length <= 10) ? giovv.Text : r["ngay"].ToString().Substring(11);
                        s = s_ngayvv;
                        break;
                    }
                    if (s != "")
                    {
                        load_vv_maql(true);
                        ngayvv.Text = s;
                    }
                    else
                    {
                        load_tiepdon(m.Ngayhienhanh, false);
                        if (l_matd==0) giovv_Validated(null, null);
                    }
				}
				else
				{
					danhsach.Visible=false;
					mabn2.Focus();
				}
			}
			catch(Exception ex)
            {
                danhsach.Visible=false;
            }
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			load_ref();
			list.Focus();
		}
	
		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			gan_mabn();		
		}

		private void l_thuocbhyt_Click(object sender, System.EventArgs e)
		{            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
            }
            //else
            s_chonxutri = chon_xutri();
                if (s_chonxutri == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"), s_msg);
                    xutri.Focus();
                    return;
                }
                if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
                if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
                if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
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
                if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh kèm theo !"), s_msg);
                    icd_kemtheo.Focus();
                    return;
                }
                else if (cd_kemtheo.Text == "" && icd_kemtheo.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh kèm theo !"), s_msg);
                    if (cd_kemtheo.Enabled) cd_kemtheo.Focus();
                    else icd_kemtheo.Focus();
                    return;
                }
                if (!m.Kiemtra_maicd(dticd, icd_kemtheo.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                    icd_kemtheo.Focus();
                    return;
                }
                if (bChandoan)
                {
                    if (!m.Kiemtra_tenbenh(dticd, cd_kemtheo.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                        cd_kemtheo.Focus();
                        return;
                    }
                }
                if (mabs.Text == "" || tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                    mabs.Focus();
                    return;
                }

                //if (butLuu.Enabled && l_maql == 0) 
                    butLuu_Click(null, null);
                //else ena_but(true);
			string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
			sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			DataTable dt=m.get_data(sql).Tables[0];
			foreach(DataRow r in dt.Rows)
			{
				s_mmyy=r["mmyy"].ToString();
                if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
			}
            //
            string tmp_ngay = ngayvv.Text;
            int _userid = -1;
            if (d.bSophieu_mau38_tangtheonam(m.nhom_duoc))
            {
                tmp_ngay = "31/12/20" + s_mmyy.Substring(2, 2);
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(m.nhom_duoc)) tmp_ngay = "01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 0);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 1);
            }
            //
            if (madoituong.Text == "1" || (bNgtru_dt_makp && int.Parse(madoituong.Text) == dt_ngtru && makp_kho_dt.IndexOf(makp.Text)!=-1)) s_mmyy = s_mmyy;
            else if (madoituong.Text != "1")
            {
                if (m.get_data("select * from " + user + ".d_dmphieu where id=6 and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng") + "\n" + tendoituong.Text + "\n" + lan.Change_language_MessageText("Không được cấp thuốc !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            //
            bXemlai_toa=false;
            if (m.bNgayhienhanh_thuoc_chidinh && ngayvv.Text != m.ngayhienhanh_server)
            {
                if (m.get_data("select * from " + user + s_mmyy + ".d_thuocbhytll where maql=" + l_maql + " and nhom=" + m.nhom_duoc).Tables[0].Rows.Count != 0)
                {
                    DialogResult dlg = MessageBox.Show("Bạn có muốn xem lại toa đã phát không?\nKích NO: Cho phép cấp toa mới.\nKích YES: chỉ xem lại toa cũ.", "Cấp toa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    bXemlai_toa = dlg == DialogResult.Yes; 
                }
            }
            //
            //frmBaohiem f = new frmBaohiem(false, s_mabn, (madoituong.Text == "1") ? 5 : 6, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_duoc, i_userid, "Đơn thuốc", l_matd, l_maql, hoten.Text, namsinh.Text, sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, int.Parse(madoituong.Text), makp.Text, mabs.Text, tendoituong.Text, cholam.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 3, s_noicap, false, s_madoituong, ngayvv.Text + " " + giovv.Text, trieuchung.Text.Replace("\r\n", " "),traituyen.SelectedIndex,ngay1,ngay2,ngay3,bXemlai_toa);
            //f.ShowDialog(this);
            //load_baohiem();
		}

		private void l_thuocdan_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			//if (l_maql==0)
			//{
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
            }
            //else
                s_chonxutri = chon_xutri();
                if (s_chonxutri == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"), s_msg);
                    xutri.Focus();
                    return;
                }
                if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
                if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
                if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
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
                if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh kèm theo !"), s_msg);
                    icd_kemtheo.Focus();
                    return;
                }
                else if (cd_kemtheo.Text == "" && icd_kemtheo.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh kèm theo !"), s_msg);
                    if (cd_kemtheo.Enabled) cd_kemtheo.Focus();
                    else icd_kemtheo.Focus();
                    return;
                }
                if (!m.Kiemtra_maicd(dticd, icd_kemtheo.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                    icd_kemtheo.Focus();
                    return;
                }
                if (bChandoan)
                {
                    if (!m.Kiemtra_tenbenh(dticd, cd_kemtheo.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                        cd_kemtheo.Focus();
                        return;
                    }
                }
                if (mabs.Text == "" || tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                    mabs.Focus();
                    return;
                }
			//}
                if (butLuu.Enabled && l_maql == 0) butLuu_Click(null, null);
                else ena_but(true);
			if (bDanhmuc_nhathuoc)
			{
				string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
				sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
				DataTable dt=m.get_data(sql).Tables[0];
				foreach(DataRow r in dt.Rows)
				{
					s_mmyy=r["mmyy"].ToString();
                    if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc).Tables[0].Rows.Count > 0) break;
				}
                //
                bXemlai_toa = false;
                if (m.bNgayhienhanh_thuoc_chidinh && ngayvv.Text != m.ngayhienhanh_server)
                {
                    if (m.get_data("select * from " + user + s_mmyy + ".d_thuocbhytll where maql=" + l_maql + " and nhom=" + m.nhom_duoc).Tables[0].Rows.Count != 0)
                    {
                        DialogResult dlg = MessageBox.Show("Bạn có muốn xem lại toa đã phát không?\nKích NO: Cho phép cấp toa mới.\nKích YES: chỉ xem lại toa cũ.", "Cấp toa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        bXemlai_toa = dlg == DialogResult.Yes;
                    }
                }
                //
                //frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc mua ngoài", l_matd, l_maql, hoten.Text, namsinh.Text, sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, 5, makp.Text, mabs.Text, tendoituong.Text, cholam.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 3, s_noicap, false, s_madoituong, ngayvv.Text + " " + giovv.Text, trieuchung.Text.Replace("\r\n", " "), traituyen.SelectedIndex, ngay1, ngay2, ngay3, bXemlai_toa);
                //f.ShowDialog(this);
                //load_thuocdan();
			}
			else
			{
                //frmToathuoc f2 = new frmToathuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text + " " + giovv.Text, makp.Text, tenkp.Text, mabs.Text, tenbs.Text, cd_chinh.Text, icd_chinh.Text, l_maql, i_userid, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), nam);
                //f2.ShowDialog(this);
                //load_thuocdan();
			}
		}

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
			if (l_maql==0)
			{         
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            if (m.bCD_BS_Chidinh && tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (m.bCD_BS_Chidinh && cd_chinh.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán !"), LibMedi.AccessData.Msg);
                icd_chinh.Focus();
                return;
            }
            //
            bXemlai_toa = false;
            if (m.bNgayhienhanh_thuoc_chidinh && ngayvv.Text != m.ngayhienhanh_server)
            {
                if (m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".v_chidinh where maql=" + l_maql).Tables[0].Rows.Count != 0) 
                {
                    DialogResult dlg = MessageBox.Show("Bạn có muốn xem lại chỉ định Cận lâm sàng?\nKích NO: Cho phép nhập thêm mới.\nKích YES: chỉ xem lại chỉ định cũ.", "chỉ định CLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    bXemlai_toa = dlg == DialogResult.Yes;
                }
            }
            //
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text + " " + giovv.Text, makp.Text, tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_matd, l_maql, 0, i_userid, "xxx.benhanpk", sothe.Text, nam, 3, mabs.Text, (cd_chinh.Text != "") ? cd_chinh.Text : (trieuchung.Text != "") ? trieuchung.Text : lydo.Text, icd_chinh.Text, (traituyen.SelectedIndex < 0) ? 0 : traituyen.SelectedIndex, bXemlai_toa);
			f.ShowDialog(this);
			load_chidinh();
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim());
            //f.ShowDialog(this);
            //load_diungthuoc();
		}

		private void soluutru_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (mabn3.Text=="" && soluutru.Text!="")
				{
                    if (nam == "") return;
					DataTable dt=m.get_data_nam(nam,"select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.benhanpk a,xxx.lienhe b where a.maql=b.maql and b.soluutru='"+soluutru.Text+"'"+" order by a.maql").Tables[0];
					if (dt.Rows.Count>0)
					{
						s_mabn=dt.Rows[0]["mabn"].ToString();
                        ngayvv.Text = dt.Rows[0]["ngay"].ToString().Substring(0, 10);
                        giovv.Text = dt.Rows[0]["ngay"].ToString().Substring(11);
						mabn2.Text=s_mabn.Substring(0,2);
						mabn3.Text=s_mabn.Substring(2);
						load_mabn();
						giovv_Validated(sender,e);
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
				if (soluutru.Enabled)
					listBS.BrowseToICD10(tenbs,mabs,soluutru,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+117,mabs.Height);
				else
					listBS.BrowseToICD10(tenbs,mabs,maxutri,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+117,mabs.Height);
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
				tenkhoa.SelectedValue=khoa.Text;
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
			if (this.ActiveControl==tenkhoa && tenkhoa.SelectedIndex!=-1)
			{
				khoa.Text=tenkhoa.SelectedValue.ToString();
			}
		}

		private void l_tuvong_Click(object sender, System.EventArgs e)
		{
            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayvv.Text + " " + giovv.Text, "1", l_maql, i_userid);
            //f.ShowDialog();
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
			s_chonxutri=chon_xutri();
            //hen.Visible = s_chonxutri.IndexOf("03,") != -1;
            if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
            {
                hen.Visible = madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1;
                chkTiepdon.Checked = m.Thongso("hen_quadangky") == "1";
            }
            else hen.Visible = false;
			loaibv.Enabled=(s_chonxutri.IndexOf("06,")!=-1);
			tenloaibv.Enabled=loaibv.Enabled;
			mabv.Enabled=loaibv.Enabled;
			tenbv.Enabled=loaibv.Enabled;
			khoa.Enabled=(s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("08,")!=-1);
            if (khoa.Enabled)
            {
                sql = "select * from "+user+".btdkp_bv where makp<>'01'";
                if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0 and kehoach>0";
                else if (s_chonxutri.IndexOf("02,") != -1)
                {
                    //sql += " and makp<>'" + makp.Text + "'";
                    sql += "  and (maba like '%20%'";
			        sql += " or maba like '%21%'";
			        sql += " or maba like '%22%'";
			        sql += " or maba like '%23%')";
                }
                sql += " order by makp";
                tenkhoa.DataSource = m.get_data(sql).Tables[0];
                if (tenkhoa.SelectedIndex != -1) khoa.Text = tenkhoa.SelectedValue.ToString();
            }
			tenkhoa.Enabled=khoa.Enabled;		
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			if (s_mabn=="" || ngayvv.Text=="") return;
			string c01="",c02="",c03="",c04="",c05="",ketqua="",tenfile="Phieukham";
			sql="select b.ten from "+user+m.mmyy(ngayvv.Text)+".v_chidinh a,"+user+".v_giavp b where a.mavp=b.id and a.mabn='"+s_mabn+"' and to_char(a.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
			int j=1;
			foreach(DataRow r in v.get_data(sql).Tables[0].Rows) 
			{
				c01=c01+j.ToString().Trim()+". "+r["ten"].ToString().Trim()+"\n";
				j++;
			}
            string s_tiensu = f_get_tiensu(s_mabn);
			sql ="select 0 as loai,b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,b.slyeucau as soluong,b.cachdung from "+user+m.mmyy(ngayvv.Text)+".d_thuocbhytll a,"+user+m.mmyy(ngayvv.Text)+".d_thuocbhytct b,"+user+".d_dmbd c";
			sql +=" where a.id=b.id and b.mabd=c.id and a.mabn='"+s_mabn+"' and to_char(a.ngay,'dd/mm/yyyy')='"+ngayvv.Text.Substring(0,10)+"'";
            sql += " union all ";
            sql += "select 0 as loai,b.stt,c.ten,c.dang,b.soluong,b.cachdung from " + user + m.mmyy(ngayvv.Text) + ".d_toathuocll a," + user + m.mmyy(ngayvv.Text) + ".d_toathuocct b," + user + ".d_dmthuoc c";
            sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
			j=1;
			foreach(DataRow r in m.get_data(sql).Tables[0].Select("true","loai,stt"))
			{
				c02=c02+j.ToString().Trim()+". "+r["ten"].ToString().Trim()+"\n\n";
				c03+=r["soluong"].ToString().Trim()+"\n\n";
				c04+=r["dang"].ToString().Trim()+"\n\n";
				c05+=r["cachdung"].ToString().Trim()+"\n\n";
				j++;
			}
            string xxx = user + m.mmyy(ngayvv.Text);
            string sql1="select b.*,'' as c01,'' as c02,'' as c03,'' as c04,'' as c05, c.ten as trieuchung, d.lydo, d.phanbiet from " + xxx + ".benhanpk b left join "+xxx+".trieuchung c on b.maql=c.maql left join "+xxx+".lydokham d on b.maql=d.maql ";
            sql1 += " where b.maql=" + l_maql;
            ds=m.get_data(sql1);
			for(int i=0;i<xutri.Items.Count;i++) if (xutri.GetItemChecked(i)) ketqua+=dtxutri.Rows[i]["ten"].ToString().Trim().Substring(3)+";";
            string chandoan = cd_chinh.Text.Replace("'", "''");            
			if (ds.Tables[0].Rows.Count!=0)
			{
				foreach(DataRow r in ds.Tables[0].Rows)
				{
					r["c01"]=c01;r["c02"]=c02;
					r["c03"]=c03;r["c04"]=c04;r["c05"]=c05;
				}
                if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds.WriteXml("..\\..\\dataxml\\phieukham.xml", XmlWriteMode.WriteSchema);
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,tenfile,"",tenkp.Text,tenbs.Text.Trim().ToUpper(),"",m.Mabv+"/"+mabn2.Text+"/"+mabn3.Text,hoten.Text,ngaysinh.Text,(loaituoi.SelectedIndex==0)?tuoi.Text.Substring(1):"000",phai.SelectedIndex.ToString(),
					tennn.Text,mann.Text,tendantoc.Text,madantoc.Text,(tennuoc.Enabled)?tennuoc.Text:"",(tennuoc.Enabled)?tennuoc.SelectedValue.ToString():"",sonha.Text,thon.Text,tenpxa.Text,tenquan.Text,maqu2.Text,tentinh.Text,matt.Text,cholam.Text,madoituong.Text,
                    denngay.Text, sothe.Text, qh_hoten.Text, qh_dienthoai.Text, "", ngayvv.Text + " " + giovv.Text, tennhantu.Text, tendentu.Text, "1", tenkhoa.Text,mach.Text,nhietdo.Text,huyetap.Text,cao.Text, nang.Text, "", "", "", "", "", "", "", "", "", "", "",
					cd_noichuyenden.Text,m.Maicd_rpt(icd_noichuyenden.Text),chandoan,m.Maicd_rpt(icd_chinh.Text),"","","0","0",chandoan,m.Maicd_rpt(icd_chinh.Text),cd_kemtheo.Text,m.Maicd_rpt(icd_kemtheo.Text),(taibien.Checked)?"1":"0",
					(bienchung.Checked)?"1":"0",ketqua,(giaiphau.Checked)?gphaubenh.SelectedValue.ToString():"0","","","","","","","","","","","","","","","","","","","","","","","","","","",
					"","","","","","","","","","0","","","","","","","","","","","","","","" ,"",s_tiensu);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),s_msg);
		}

		private void l_kemtheo_Click(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="" || cd_kemtheo.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0) luu();
            //frmCdkemtheo f = new frmCdkemtheo(m, l_maql, l_maql, 4, ngayvv.Text + " " + giovv.Text);
            //f.ShowDialog();
			load_kemtheo();
		}

		private void luu()
		{
            int p = 0; string s_ttlucrv = "1",zzz=user+m.mmyy(ngayvv.Text);
            if (s_chonxutri != "")
            {
                p = s_chonxutri.IndexOf(",");
                s_ttlucrv = s_chonxutri.Substring(0, p);
            }
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            s_mabn = mabn2.Text + mabn3.Text;
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhanpk");
            if (m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", m.fields(zzz+".benhanpk","maql="+l_maql));
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, true);
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql,l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Khambenh, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Khambenh, l_maql);
            }
            if (!m.upd_lienhe(ngayvv.Text, l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            if (bSoluutru && soluutru.Text != "") m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".lienhe set soluutru='" + soluutru.Text + "' where maql=" + l_maql);
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), kinhcc.Text, ngaysanh.Text, "");
            if (!m.upd_benhanpk(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, (s_ttlucrv != "") ? int.Parse(s_ttlucrv) : 0, mabs.Text, sovaovien.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? 1 : 0, (giaiphau.Checked) ? 1 : 0, 0, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(ngayvv.Text,l_maql,l_maql,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
		}

		private void load_kemtheo()
		{
            //kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=4 and id="+l_maql).Tables[0].Rows.Count!=0;
            //l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void maxutri_Validated(object sender, System.EventArgs e)
		{
            s_chonxutri = maxutri.Text.Trim().Replace("00", "");
			if (s_chonxutri!="")
			{
				if (s_chonxutri.Substring(s_chonxutri.Length)!=",") s_chonxutri+=",";
				for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
				for(int i=0;i<=xutri.Items.Count;i++)
					if (s_chonxutri.IndexOf(i.ToString().Trim().PadLeft(2,'0')+",")!=-1) xutri.SetItemCheckState(i-1,CheckState.Checked);

                if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
                {
                    hen.Visible = madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1;
                }
                else hen.Visible = false;
                loaibv.Enabled = (s_chonxutri.IndexOf("06,") != -1) && (bPhongkham_khongduocxutri_chuyenvien==false);
				tenloaibv.Enabled=loaibv.Enabled;
				mabv.Enabled=loaibv.Enabled;
				tenbv.Enabled=loaibv.Enabled;
		        khoa.Enabled=(s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("08,")!=-1);
                if (khoa.Enabled)
                {
                    sql = "select * from "+user+".btdkp_bv where makp<>'01'";
                    if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                    else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0 and kehoach>0";
                    else if (s_chonxutri.IndexOf("02,") != -1)
                    {
                        //sql += " and makp<>'" + makp.Text + "'";
                        sql += "  and (maba like '%20%'";
                        sql += " or maba like '%21%'";
                        sql += " or maba like '%22%'";
                        sql += " or maba like '%23%')";
                    }
                    sql += " order by makp";
                        tenkhoa.DataSource = m.get_data(sql).Tables[0];
                }
				tenkhoa.Enabled=khoa.Enabled;		
				SendKeys.Send("{Tab}");
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
            if (kinhcc.Text.Length == 6) kinhcc.Text = kinhcc.Text + DateTime.Now.Year.ToString();
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
            if (ngaysanh.Text.Length == 6) ngaysanh.Text = ngaysanh.Text + DateTime.Now.Year.ToString();
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
            if (phai.SelectedIndex != 1) return;
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmSokhamthai f = new frmSokhamthai(m, l_matd, l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text,tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid);
            //f.ShowDialog();
            //if (f.bOk && f._songayhen != 0)
            //{
            //    hen_ngay.Value = Convert.ToDecimal(f._songayhen);
            //    hen_loai.SelectedIndex = f._loai;
            //    hen_ghichu.Text = f._ghichu;
            //    chkTiepdon.Checked = f._tiepdon == 1;
            //    if (maxutri.Text.IndexOf("03,") == -1)
            //    {
            //        maxutri.Text = maxutri.Text + "03,";
            //        string s_xutri = maxutri.Text;
            //        if (s_xutri != "")
            //        {
            //            for (int i = 0; i <= xutri.Items.Count; i++)
            //                if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
            //        }
            //        hen.Visible = true;
            //    }
            //}
		}

		private void l_cls_Click(object sender, System.EventArgs e)
		{
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            //frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text + mabn3.Text, hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim());
            //f.ShowDialog(this);
		}

		private bool load_phongkham()
		{
            l_maql = m.get_maql_ngay(s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text);
			bNew=l_maql==0;
            if (l_maql != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {") + tenkp.Text.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    load_vv_maql(false);
                    s_ngayvv = ngayvv.Text + " " + giovv.Text;
                    return false;
                }
                else if (!kiemtra_chidinh()) return false;
            }
            else if (!kiemtra_chidinh()) return false;
            if (dausinhton.Visible) mach.Focus();
            else if (sovaovien.Enabled) sovaovien.Focus();
            else if (loai.Enabled) loai.Focus();
            else if (bnmoi.Enabled) bnmoi.Focus();
            else quanhe.Focus();
			return true;
		}

        private bool kiemtra_chidinh()
        {
            if (bPhongkham_chidinh)
            {
                if (!kiemtra_pk_cd(ngayvv.Text))
                {
                    bool bExit=true;
                    if (bDangky_homqua)
                        bExit=!kiemtra_pk_cd(m.DateToString("dd/MM/yyyy",m.StringToDate(ngayvv.Text).AddDays(-1)));
                    if (bExit)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa được chỉ định khám ") + " " + tenkp.Text, LibMedi.AccessData.Msg);
                        butBoqua_Click(null, null);
                        return false;
                    }
                    else return true;
                }
                else return true;
            }
            else return true;
        }

        private bool kiemtra_pk_cd(string ngay)
        {
            if (m.bMmyy(m.mmyy(ngay)))
            {
                sql = "select * from " + user + m.mmyy(ngay) + ".tiepdon ";
                sql += " where (done is null or done in ('?','d')) and to_char(ngay,'dd/mm/yyyy')='" + ngay + "'";
                sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) and makp='" + makp.Text + "'";
                sql += " and mabn='" + mabn2.Text + mabn3.Text + "'";
                return m.get_data(sql).Tables[0].Rows.Count > 0;
            }
            else return false;
        }
		private void lydo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				lydo.Text=m.Viettat(lydo.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
			if (tenbv.SelectedIndex!=-1 && ngayvv.Text!="")
			{
                /*
				DataSet dsxml=new DataSet();
				dsxml.ReadXml("..//..//..//xml//m_giaycv.xml");
				DataRow r1=dsxml.Tables[0].NewRow();
				r1["tenbv"]=tenbv.Text;
				r1["mabn"]=mabn2.Text+mabn3.Text;
				r1["hoten"]=hoten.Text;
				r1["namsinh"]=namsinh.Text;
				r1["phai"]=phai.Text;
				r1["dantoc"]=tendantoc.Text;
				r1["tennn"]=tennn.Text;
				r1["doituong"]=tendoituong.Text;
				r1["sothe"]=sothe.Text;
				r1["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+","+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim();
				r1["noilamviec"]=cholam.Text;
				r1["chandoan"]=cd_chinh.Text;
				r1["maicd"]=icd_chinh.Text;
				r1["tenkp"]=tenkp.Text;
				r1["tenbs"]=tenbs.Text;
                r1["ngayvao"] = ngayvv.Text + " " + giovv.Text;
                r1["ngayra"] = ngayvv.Text + " " + giovv.Text;
				dsxml.Tables[0].Rows.Add(r1);
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,tenbv.Text,"rptGiaycv.rpt");
				f.ShowDialog();
                 */
                //frmGiaycv f = new frmGiaycv(m, "", i_userid, mabn2.Text + mabn3.Text, 3);
                //f.ShowDialog();
			}
		}

		private void l_tonkho_Click(object sender, System.EventArgs e)
		{
			if (ngayvv.Text=="") return;
			string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2),s_makho="";
			sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			DataTable dt=m.get_data(sql).Tables[0];
			foreach(DataRow r in dt.Rows)
			{
				s_mmyy=r["mmyy"].ToString();
                if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
			}
            //frmChonkho f1 = new frmChonkho(d.get_data("select * from " + user + ".d_dmkho order by nhom,stt").Tables[0]);
            //f1.ShowDialog();
            //if (f1.s_makho != "")
            //{
            //    s_makho = f1.s_makho;
            //    //frmXemtonth f = new frmXemtonth(s_mmyy, (madoituong.Text == "1") ? 5 : 6, m.nhom_duoc, (madoituong.Text == "") ? 0 : int.Parse(madoituong.Text), ngayvv.Text + " " + giovv.Text, s_makho);
            //    frmXemtonth f = new frmXemtonth(s_mmyy, (madoituong.Text == "1") ? 5 : 6,f1.nhom, (madoituong.Text == "") ? 0 : int.Parse(madoituong.Text), ngayvv.Text + " " + giovv.Text, s_makho);
            //    f.ShowDialog();
            //}
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

		private void l_tutruc_Click(object sender, System.EventArgs e)
		{            
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmChonthongso f=new frmChonthongso(m,1,2,0,makp.Text+",",false,s_nhomkho);
			f.ShowDialog(this);
			if (f.s_makp!="")
			{
				frmXtutruc f1=new frmXtutruc(f.s_ngay,f.s_makho,f.s_makp,f.i_nhom,2,f.i_phieu,f.i_macstt,f.i_makp,i_userid,f.s_mmyy,f.l_duyet,"Phiếu xuất tủ trực "+f.s_tennhom.Trim()+" theo người bệnh ("+f.s_ngay.Trim()+", "+f.s_tenkp.Trim()+", "+f.s_phieu.Trim()+", "+s_userid.Trim()+")",LibMedi.AccessData.Msg,m.bDausinhton,m.iSudungthuoc,f.s_manguon,s_mabn,f.i_buoi,f.s_tenkp,f.s_phieu,f.i_somay,mabs.Text,s_madoituong);
				f1.ShowDialog(this);
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
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
             s_mabn = mabn2.Text + mabn3.Text;
            if (!bTiepdon)
            {
                if (m.get_tiepdon(s_mabn, ngayvv.Text) == 0)
                {
                    if (bDangky_homqua)
                    {
                        if (m.get_tiepdon(s_mabn, m.DateToString("dd/MM/yyyy", m.StringToDate(ngayvv.Text).AddDays(-1))) == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                            butBoqua_Click(sender, e);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                        butBoqua_Click(sender, e);
                        return;
                    }
                }
            }
            if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày khám bệnh không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                ngayvv.Focus();
                s_ngayvv = "";
                return;
            }
            if (!makp.Enabled && makp.Text != "")
            {
                if (!load_phongkham()) return;
            }
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
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            s_mabn = mabn2.Text + mabn3.Text;
            string s = ngayvv.Text + " " + giovv.Text;
            if (s != s_ngayvv)
            {
                if (bTudong)
                {
                    DataRow r = m.getrowbyid(dtletet, "ngay='" + ngayvv.Text.Substring(0, 5) + "'");
                    bool bLetet = r != null;
                    hh1 = int.Parse(s.Substring(11, 2));//hh1 = int.Parse(ngayvv.Text.Substring(11, 2));
                    mm1 = int.Parse(s.Substring(14, 2));//mm1 = int.Parse(ngayvv.Text.Substring(14, 2));
                    DateTime dtime = m.StringToDate(ngayvv.Text.Substring(0, 10));
                    string ddd = dtime.DayOfWeek.ToString().Substring(0, 3);
                    if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3)) loai.SelectedValue = "1";
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
                l_maql = (tenkp.Items.Count==1 && tenkp.SelectedIndex!=-1)?m.get_maql_benhanpk(s_mabn,tenkp.SelectedValue.ToString(),s):m.get_maql_benhanpk(s_mabn,s);
                bNew = l_maql == 0;
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                }
                else
                {
                    if (ngayvv.Text.Substring(0, 10) == m.Ngayhienhanh)
                    {
                        string m_ngay = m.get_ngaytiepdon(s_mabn,s);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(s, m_ngay) && !bDangky_homqua)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                                ngayvv.Focus();
                                return;
                            }
                        }
                    }
                    emp_vv();
                    emp_bhyt();
                    emp_rv();
                    ngayvv.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                    if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text;
                    else if (soluutru.Text == "" && b_sovaovien) soluutru.Text = sovaovien.Text;
                    l_maql = 0;
                    if (!bSuadoituong)
                    {
                        madoituong.Enabled = false;
                        tendoituong.Enabled = false;
                    }
                }
                s_ngayvv = s;
            }
        }

        private void butInchitiet_Click(object sender, EventArgs e)
        {
            bIn = true;
            string ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            if (!bRight && ngayvv.Text != ngaysrv)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không quyền in lại!")+"\n"+lan.Change_language_MessageText("Ngày khám bệnh khác ngày hiện hành")+" " + ngaysrv, LibMedi.AccessData.Msg);
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            if (s_mabn == "" || ngayvv.Text == "") return;
            s_chonxutri = chon_xutri();
            if (s_chonxutri == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí khám bệnh !"), LibMedi.AccessData.Msg);
                maxutri.Focus();
                return;
            }
            if (s_chonxutri.IndexOf("08,") != -1 || (bXutri_hen_koin && s_chonxutri.IndexOf("03,")!=-1))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa phải phòng khám cuối !"), LibMedi.AccessData.Msg);
                butTiep.Focus();
                return;
            }
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin phòng khám chưa cập nhật !"), LibMedi.AccessData.Msg);
                butLuu.Focus();
                return;
            }
            else if (butLuu.Enabled) butLuu_Click(sender, e);
            string _tenkp = m.inchiphipk(ngayvv.Text, l_matd);
            if (_tenkp != "")
            {
                if (_tenkp != tenkp.Text.Trim())
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chi phí đã in tại phòng khám ") + _tenkp, LibMedi.AccessData.Msg);
                    butTiep.Focus();
                    return;
                }
                else if (MessageBox.Show(lan.Change_language_MessageText("Chi phí đã in") + "\n" + lan.Change_language_MessageText("Bạn có muốn in lại ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    butTiep.Focus();
                    return;
                }
            }
            maso = "";
            inchiphi();
            d_id = 0; d_mmyy = "";
            if (bDichvu_vpkb) upd_vienphi();
            else if (bDuyet_khambenh && sothe.Text!="")
            {
                sql = "update xxx.v_chidinh set paid=1 where where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                d.execute_data_mmyy(sql,ngayvv.Text,ngayvv.Text,30);
            }
            m.upd_inchiphipk(mabn2.Text + mabn3.Text, l_matd, ngayvv.Text + " " + giovv.Text, makp.Text);
            butTiep.Focus();
        }

        private void upd_vienphi()
        {
            DateTime dt1 = m.StringToDate(ngayvv.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = m.StringToDate(ngayvv.Text).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            DataTable tmp;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m.bMmyy(mmyy))
                    {
                        sql = "select id from " + user + mmyy + ".bhytkb where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                        if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                        tmp=m.get_data(sql).Tables[0];
                        if (tmp.Rows.Count > 0)
                        {
                            d_id = long.Parse(tmp.Rows[0]["id"].ToString());
                            d_mmyy = mmyy;
                            break;
                        }
                    }
                }
            }
            string yyy = user + m.mmyy(ngayvv.Text);
            int stt = 1, itable;
            if (d_id != 0 && d_mmyy != "" && bDuyet_khambenh && sothe.Text!="")
            {
                itable = d.tableid(d_mmyy, "bhytcls");
                d.execute_data("delete from " + user + d_mmyy + ".bhytcls where id=" + d_id);
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in d.get_data_mmyy(sql,ngayvv.Text,ngayvv.Text,30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), long.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + long.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                    sql += " and madoituong=" + int.Parse(madoituong.Text);
                    d.execute_data_mmyy(sql,ngayvv.Text,ngayvv.Text,30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
                sql = "update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra;//+" where id=" + d_id;
                sql += " where mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                m.execute_data(sql);
            }
            else if (bDuyet_khambenh && sothe.Text!="")
            {
                int i_nhom = m.nhom_duoc;
                d_id = d.get_id_bhyt;
                d_mmyy = m.mmyy(ngayvv.Text);
                if (!d.upd_bhytds(d_mmyy, s_mabn,hoten.Text,namsinh.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+" "+tenquan.Text.Trim()+" "+tentinh.Text.Trim()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytkb");
                d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                if (!d.upd_bhytkb(d_mmyy, d_id, i_nhom,ngayvv.Text, s_mabn, l_matd, l_maql,makp.Text,cd_chinh.Text,icd_chinh.Text,mabs.Text,sothe.Text,int.Parse(madoituong.Text),s_noicap,i_userid,3,traituyen.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                sql = "update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra;
                sql += " where mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                //+" where id=" + d_id;
                m.execute_data(sql);
                itable = d.tableid(d_mmyy, "bhytcls");
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in d.get_data_mmyy(sql,ngayvv.Text,ngayvv.Text,30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), long.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + long.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                    sql += " and madoituong=" + int.Parse(madoituong.Text);
                    d.execute_data_mmyy(sql,ngayvv.Text,ngayvv.Text,30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
        }

        private void inchiphi()
        {
            string s_trieuchung = "", s_ghichu_kb = "", s_phanbiet = "";
            dsxmlin.Clear();
            d_mmyy = m.mmyy(ngayvv.Text);
            DateTime dt1 = m.StringToDate(ngayvv.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = m.StringToDate(ngayvv.Text).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            DataTable tmp;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m.bMmyy(mmyy))
                    {
                        sql = "select id from " + user + mmyy + ".bhytkb where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                        if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                        tmp = m.get_data(sql).Tables[0];
                        if (tmp.Rows.Count > 0)
                        {
                            d_id = long.Parse(tmp.Rows[0]["id"].ToString());
                            d_mmyy = mmyy;
                            break;
                        }
                    }
                }
            }
            int _userid = -1;
            string tmp_ngay = ngayvv.Text;
            //
            //string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
            //sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
            //DataTable dt11 = m.get_data(sql).Tables[0];
            //foreach (DataRow r in dt11.Rows)
            //{
            //    s_mmyy = r["mmyy"].ToString();
            //    if (d.get_data("select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
            //}
            //
            if (d.bSophieu_mau38_tangtheonam(m.nhom_duoc))
            {
                tmp_ngay = "31/12/20" + d_mmyy.Substring(2, 2);
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(m.nhom_duoc)) tmp_ngay = "01/" + d_mmyy.Substring(0, 2) + "/20" + d_mmyy.Substring(2, 2);
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 0);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 1);
            }
            //
            int isophieu = d.get_sophieu_bhyt_userid(d_mmyy, s_mabn, l_matd, ngayvv.Text, int.Parse(madoituong.Text), _userid);
            int lanin = d.get_laninkb(d_mmyy, s_mabn, l_matd, ngayvv.Text, int.Parse(madoituong.Text));
            bhyttra = bntra = 0;
            string s_noicap = "", s_chandoan = "", s_maicd = "", s_tenkp = "", s_tenbs = "", yyy = user + m.mmyy(ngayvv.Text), ngaybd = ngayvv.Text, nam = m.get_mabn_nam(s_mabn);
            int sokham = 0;
            bool bTaikham = false;
            if (!bTaikham_chiphi_inrieng)
                 bTaikham = m.get_data("select * from " + yyy + ".tiepdon where mavaovien=" + l_matd + " and noitiepdon=16").Tables[0].Rows.Count > 0;
            sql = "select * from " + yyy + ".tiepdon where mavaovien=" + l_matd;
            if (bTaikham_chiphi_inrieng) sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows) maso += r["maql"].ToString() + ",";
            if (bTaikham)
            {
                sql = "select mavaovien,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.benhanpk where mabn='" + s_mabn + "' and maql=" + l_matd;
                tmp = m.get_data_nam_dec(nam, sql).Tables[0];
                foreach (DataRow r in tmp.Rows)
                {
                    ngaybd = r["ngay"].ToString().Substring(0,10); maso += r["maql"].ToString() + ",";
                }
            }
            sql = "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs ";
            sql+=" from xxx.benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql+=" left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd;
            if (bTaikham_chiphi_inrieng) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            sql+=" order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql,ngaybd.Substring(0,10),ngayvv.Text.Substring(0,10),true).Tables[0].Rows)
            {
                maso += r["maql"].ToString() + ",";
                //if (!bChuyenkham_dscho) sokham += 1; else sokham = 1;
                s_maicd += r["maicd"].ToString().Trim() + ";";
                s_chandoan += r["chandoan"].ToString().Trim() + ";";
                s_tenkp += r["tenkp"].ToString().Trim() + ";";
                s_tenbs += r["tenbs"].ToString() + ";";
                foreach (DataRow r1 in m.get_data("select distinct chandoan,maicd from " + yyy + ".cdkemtheo where maql=" + long.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
                //ghi chu + phan biet
                foreach (DataRow r1 in m.get_data("select distinct lydo, phanbiet from " + yyy + ".lydokham where maql=" + long.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    if (s_ghichu_kb.IndexOf( r1["lydo"].ToString().Trim()+";")<0 && r1["lydo"].ToString().Trim().Trim() != "") s_ghichu_kb += r1["lydo"].ToString().Trim() + ";";
                    if (s_phanbiet.IndexOf(r1["phanbiet"].ToString().Trim() + ";") < 0 && r1["phanbiet"].ToString().Trim().Trim() != "") s_phanbiet += r1["phanbiet"].ToString().Trim() + ";";
                }
                //trieu chung
                foreach (DataRow r1 in m.get_data("select distinct ten from " + yyy + ".trieuchung where maql=" + long.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    if (s_trieuchung.IndexOf(r1["ten"].ToString().Trim() + ";") < 0 && r1["ten"].ToString().Trim().Trim() != "") s_trieuchung += r1["ten"].ToString().Trim() + ";";
                }
            }
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            sql = "select 1 as id,a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "a.cachdung,0 as makho,0 as manguon,0 as nhomcc,f.makp,h.tenkp,f.maphu as madoituong,x.doituong,h.makp,t.gianovat ";
            sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h,"+user+".d_doituong x";
            sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and f.makp=h.makp and f.maphu=x.madoituong ";
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;//"and to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            if (maso != "") sql += " and f.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            ds1 = m.get_data_mmyy(sql,ngaybd, ngayvv.Text, true);
            //
            sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,g.makp,g.ten as tenkp,a.madoituong,x.doituong,g.makp,t.gianovat ";
            sql += " from xxx.d_thucxuat a," + user + ".d_dmbd b,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g,"+user+".d_doituong x";
            sql += " where f.id=a.id and a.sttt=t.id and a.mabd=b.id and f.makp=g.id and a.madoituong=x.madoituong";
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;
            sql += " and f.loai=2 ";
            if (maso != "") sql += " and f.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            ds1.Merge(d.get_thuoc(ngaybd, ngayvv.Text, sql));
            //
            sql = "select 2 as id,0 as stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,";
            sql += "a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
            sql += "h.makp,h.tenkp,a.madoituong,g.doituong,h.makp,a.dongia as gianovat ";
            sql += " from xxx.v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h," + user + ".doituong g";
            sql += " where a.mavp=b.id and a.madoituong=g.madoituong ";//and a.id="+l_id+" order by a.stt";
            sql += " and a.makp=h.makp and a.mabn='" + s_mabn + "'";            
            if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            else sql += " and a.mavaovien=" + l_matd;            
            if (sothe.Text == "") sql += " and a.done=0";
            sql += " and (a.madoituong=" + madoituong.Text + " or (a.done=0 and idttrv=0))";
            //ds1.Merge(m.get_data(sql));
            m.merge(ds1, d.get_data_mmyy(sql,ngaybd,ngayvv.Text,30));

            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.makp,h.tenkp,a.madoituong,x.doituong,h.makp,a.dongia as gianovat ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b,"+user+".btdkp_bv h,"+user+".d_doituong x where a.mavp=b.id and a.makp=h.makp and a.madoituong=x.madoituong ";
            sql += " and a.mabn='" + s_mabn + "'";            
            if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            else sql += " and a.mavaovien=" + l_matd;
            if (sothe.Text == "") sql += " and a.paid=0";
            sql += " and (a.madoituong="+madoituong.Text+" or (a.paid=0 and idttrv=0))";
            ds1.Merge(d.get_data_mmyy(sql,ngaybd,ngayvv.Text,30));
            DataSet dstmp = ds1.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "id,stt"));
            dsxmlin.Clear();
            DataRow r2;
            if (sothe.Text != "")
            {
                foreach (DataRow r in m.get_data("select b.tenbv from " + yyy + ".bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.sothe='" + sothe.Text + "'").Tables[0].Rows)
                {
                    s_noicap = r["tenbv"].ToString();
                    break;
                }
            }
            string dichso = "",s_ghichu="";
            decimal mien = 0, tcsotien=0;
            bool bMien=false;

            sql = "select a.ghichu from xxx.d_thuocbhytll a,xxx.bhytkb b";
            sql += " where a.id=b.id and a.ghichu<>''";
            sql += " and b.mabn='" + s_mabn + "' and b.mavaovien=" + l_matd;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                s_ghichu += r["ghichu"].ToString().Trim() + ";";

            r2 = m.getrowbyid(dtdt, "mien=1 and madoituong=" + int.Parse(madoituong.Text));
            bMien = r2 != null;
            foreach (DataRow r in dstmp.Tables[0].Select("madoituong="+madoituong.Text)) tcsotien += decimal.Parse(r["sotien"].ToString());
            //foreach (DataRow r in dstmp.Tables[0].Rows) tcsotien += decimal.Parse(r["sotien"].ToString());
            if (madoituong.Text == "1") bhyttra = tcsotien;
            else if (bMien) mien = tcsotien;
            else bntra = tcsotien;
            tcsotien += ((bCongkham) ? Congkham*sokham : 0);
            dichso = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
            if (dstmp.Tables[0].Rows.Count == 0)
            {
                m.updrec_ravien(dsxmlin, s_mabn, s_mabn, l_maql,2, hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(madoituong.Text),
                tendoituong.Text, sothe.Text, 0, s_tungay+"^"+denngay.Text, tendstt.Text, s_noicap, tenbs.Text, makp.Text, s_tenkp, ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                0, "", 0, "", 0, "", "", 0, 0, bhyttra, 0, (bCongkham) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, 0, false, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(madoituong.Text),0,0,0,traituyen.SelectedIndex,int.Parse("-1"));
            }
            else
            {
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    if (r["id"].ToString() == "2")
                        r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["mabd"].ToString()));
                    else
                        r2 = m.getrowbyid(dtbd, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        m.updrec_ravien(dsxmlin,r["sttt"].ToString(), s_mabn, l_maql, long.Parse(r["sttt"].ToString()) + long.Parse(r["id"].ToString()), hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(r["madoituong"].ToString()),
                            r["doituong"].ToString(), sothe.Text, 0, s_tungay+"^"+denngay.Text, tendstt.Text, s_noicap, tenbs.Text, r["makp"].ToString(), r["tenkp"].ToString(), ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                            int.Parse(r2["sttnhom"].ToString()), r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r["cachdung"].ToString(),
                            int.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(),
                            decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sotien"].ToString()),
                            bhyttra, 0, (bCongkham && int.Parse(r["madoituong"].ToString()) == int.Parse(madoituong.Text.ToString())) ? Congkham : 0, qh_hoten.Text, 1, int.Parse(r["id"].ToString()), sokham, s_tenbs, decimal.Parse(r["dongia"].ToString()), true, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(r["madoituong"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, decimal.Parse(r["sotien"].ToString()), traituyen.SelectedIndex, int.Parse("-1"));
                    }
                }
            }
            DateTime dt = d.StringToDate(ngayvv.Text.Substring(0, 10));
            string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
            decimal Bhyt_7cn = (m.getLetet(ngayvv.Text) || ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0,haophi=0;
            int maphu = (madoituong.Text == "1" && sothe.Text != "") ? d.get_maphu_ngtru(sothe.Text, tcsotien, m.nhom_duoc) : 0,chitra;
            int _madt = 0;
            foreach (DataRow r in dsxmlin.Tables[0].Select("true", "mabn,sothe,madoituong,sttnhom,ten"))
            {
                r["madt"] = r["madoituong"].ToString();
                r["haophi"] = 0;
                if (bHaophi_doituongvao && bHaophi && int.Parse(r["madoituong"].ToString()) == iHaophi)
                {
                    r["sttnhom"] = 1000 + decimal.Parse(r["sttnhom"].ToString());
                    r["nhom"] = r["nhom"].ToString().Trim() + s_nhomhaophi;
                    r["madoituong"] = madoituong.Text;
                    r["doituong"] = tendoituong.Text;
                }
            }
            decimal zsum = 0;
            foreach (DataRow r in dsxmlin.Tables[0].Select("madt=" + iHaophi)) haophi += decimal.Parse(r["sotien"].ToString());
            foreach (DataRow r in dsxmlin.Tables[0].Select("","madoituong,madt,sttnhom,ten"))
            {
                if (_madt != int.Parse(r["madt"].ToString()))
                {
                    tcsotien = ((bCongkham && int.Parse(r["madt"].ToString())==int.Parse(madoituong.Text)) ? Congkham * sokham : 0);
                    zsum = tcsotien;
                    _madt = int.Parse(r["madt"].ToString());
                }
                zsum += decimal.Parse(r["sotien"].ToString());
                if (int.Parse(r["madt"].ToString()) != iHaophi) tcsotien += decimal.Parse(r["sotien"].ToString());
                if (int.Parse(r["madt"].ToString()) == 1)
                {
                    if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0)
                    {
                        chitra = iTraituyen;
                        r["bhyttra"] = tcsotien * chitra / 100;
                        r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                        bhyttra = decimal.Parse(r["bhyttra"].ToString());
                        bntra = decimal.Parse(r["bntra"].ToString());
                    }
                    else if (Bhyt_7cn != 0 && tcsotien > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn;
                        r["bntra"] = tcsotien - Bhyt_7cn;
                        bhyttra = decimal.Parse(r["bhyttra"].ToString());
                        bntra = decimal.Parse(r["bntra"].ToString());
                    }
                    else
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            r["bhyttra"] = tcsotien * chitra / 100;
                            r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                            bhyttra = decimal.Parse(r["bhyttra"].ToString());
                            bntra = decimal.Parse(r["bntra"].ToString());
                        }
                        else
                        {
                            r["bhyttra"] = tcsotien;
                            r["bntra"] = 0;
                            bhyttra = decimal.Parse(r["bhyttra"].ToString());
                            bntra = decimal.Parse(r["bntra"].ToString());
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen;
                            r["bntra"] = tcsotien - lTraituyen;
                            bhyttra = decimal.Parse(r["bhyttra"].ToString());
                            bntra = decimal.Parse(r["bntra"].ToString());
                        }
                    }
                }
                else if (m.mien_doituong(int.Parse(r["madt"].ToString()), dtdt1)) //mien
                {
                    r["mien"] = tcsotien; r["bntra"] = r["bhyttra"] = 0;
                }
                else
                {
                    r["bhyttra"] = 0;
                    r["bntra"] = tcsotien;
                    bhyttra = 0;
                    bntra = 0;
                }
                r["dichso"] = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
                r["haophi"] = haophi;
                r["tcsotien"] = zsum;
                r["khoanhapvien"] = (tenkhoa.SelectedIndex != -1) ? tenkhoa.Text : "";
                r["idkhoa"] = isophieu;
                r["maql"] = lanin;
            }

            if (bChuky)
            {
                if (File.Exists("..//..//..//chuky//" + mabs.Text + ".bmp"))
                {
                    fstr = new FileStream("..//..//..//chuky//" + mabs.Text + ".bmp", FileMode.Open, FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    foreach (DataRow r in dsxmlin.Tables[0].Rows) r["Image"] = image;
                }
            }

            //if (m.bDelFileTemp) m.delFileTemp();
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxmlin.WriteXml("..\\xml\\inchiphipk", XmlWriteMode.WriteSchema);
            }
            if (dsxmlin.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsxmlin.Tables[0].Rows)
                {
                    r["tenuser"] = s_userid;
                    r["cholam"] = cholam.Text;
                    r["phanbiet"] = s_phanbiet;
                    r["ghichukb"] = s_ghichu_kb;
                    r["trieuchung"] = s_trieuchung;
                }
                if (chkXem.Checked)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxmlin, s_tenkp, "rpt_chiphi_kp.rpt");
                    f.ShowDialog();
                    f.Close();
                    f.Dispose();
                }
                else print.Printer(m, dsxmlin, "rpt_chiphi_kp.rpt", s_tenkp, 1);
            }
            if (chkToathuoc.Checked)
            {
                m.delrec(dsxmlin.Tables[0], "idkhoa=2");
                DataSet ds_toa = dsxmlin.Clone();
                foreach (DataRow dr1 in dsxmlin.Tables[0].Select("matt=0 and phuongphap=1"))
                {
                    ds_toa.Tables[0].Rows.Add(dr1.ItemArray);
                }
                if (dsxmlin.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds_toa.Tables[0].Rows)
                    {
                        r2 = m.getrowbyid(dtbd, "nhomin in (1,2,3) and id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null) r["nguoinha"] = doiso.doithapphan(r["soluong"].ToString());
                    }
                    if (chkXem.Checked)
                    {
                        dllReportM.frmReport f1 = new dllReportM.frmReport(m, ds_toa, s_tenkp, "rpt_toathuoc_kp.rpt");
                        f1.ShowDialog();
                        f1.Close();
                        f1.Dispose();
                    }
                    else print.Printer(m, dsxmlin, "rpt_toathuoc_kp.rpt", s_tenkp, 1);
                }
            }
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (tim.Text != "")
                        dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                    else
                        dv.RowFilter = "";
                }
                catch { }
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) list.Focus();
        }

        private void hen_ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void lydo_TextChanged(object sender, EventArgs e)
        {
            if (lydo.Text == "\r\n") SendKeys.Send("{Tab}");
        }
        private void butGoi_Click(object sender, EventArgs e)
        {
            //bbbbb
            //tu.Value = den.Value + 1;
            //den.Value = den.Value + sonhay.Value;
            //tu.Update(); den.Update();
            //bbbb
            //if (bBangDienPhongKham)
            //{
            //    string _makp = makp.Text.TrimStart('0').PadLeft(2, '0');
            //    Send(_makp + tu.Value.ToString().PadLeft(2, '0'));
            //    den.Value = tu.Value;
            //}
            int stt = 0;
            string sott = "";
            if (list.Items.Count > 0)
            {
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + long.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    sott = stt.ToString(); //stt.ToString().PadLeft(4, '0');

                }
               
            }
            if (sott == "") return;
            tu.Value = stt;// den.Value + 1;
            den.Value = stt;// den.Value + sonhay.Value;
            tu.Update(); den.Update();
            //m.goi_kham(ngaysrv,makp.Text, tu.Value.ToString(), den.Value.ToString(), true);
            m.goi_kham(ngaysrv, makp.Text, sott, sott, true);
            if (this.chkLCD.Checked)
            {
                this.ds.ReadXml(@"..\..\..\xml\mauLCDpk.xml");
                this.sizestt = int.Parse(this.ds.Tables[0].Rows[0]["s2"].ToString());
                string str = "";
                //if (tu.Value == den.Value)
                //    str = this.tu.Value.ToString();// + "-" + this.den.Value.ToString();
                //else
                //    str = this.tu.Value.ToString() + "-" + this.den.Value.ToString();
                //if (this.fgoi == null)
                //{
                //    this.fgoi = new frmGoibenhKham();
                //    this.fgoi.sets = this.sizestt;
                //    this.fgoi.s_sohienthi = sott;
                //    this.fgoi.Show();
                //}
                //else
                //{
                //    this.fgoi.sets = this.sizestt;
                //    this.fgoi.s_sohienthi = sott;
                //    this.fgoi.Show();
                //}
            }
            
        }

        private void butGoilai_Click(object sender, EventArgs e)
        {
            //if (bBangDienPhongKham)
            //{
            //    string _makp = makp.Text.TrimStart('0').PadLeft(2, '0');
            //    Send(_makp + tu.Value.ToString().PadLeft(2, '0'));
            //    den.Value = tu.Value;
            //}
            if (bPhongkham_bangdien_hanoi && list.Items.Count > 0)
            {
                int stt=0;
                DataRow r1=m.getrowbyid(dtlist,"stt="+long.Parse(list.SelectedValue.ToString()));
				if (r1!=null) stt=int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    string sott = stt.ToString().PadLeft(4, '0');
                    //fled.Send(ref sott);
                }
            }
            else  m.goi_kham(ngaysrv,makp.Text, tu.Value.ToString(), den.Value.ToString(), false);
        }

        private void trieuchung_TextChanged(object sender, EventArgs e)
        {
            if (trieuchung.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void trieuchung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                trieuchung.Text = m.Viettat(trieuchung.Text) + " ";
                SendKeys.Send("{END}");
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.T)
                {
                    try
                    {
                        string s = s_ngaymakp;
                        int iPos = s.IndexOf("/");
                        string s_ngay = s.Substring(iPos - 2, 16), kp = s.Substring(s.IndexOf("(") + 1, 2);
                        s_mabn = mabn2.Text + mabn3.Text;
                        l_maql = m.get_maql_benhanpk(s_mabn, kp, s_ngay);
                        if (l_maql != 0)
                        {
                            string xxx = user + m.mmyy(s_ngay);
                            string sql = "select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,b.slyeucau as soluong,b.cachdung from " + xxx + ".d_thuocbhytll a," + xxx + ".d_thuocbhytct b," + user + ".d_dmbd c";
                            sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0,10) + "'";
                            sql += " and a.maql=" + l_maql;
                            sql += " union all ";
                            sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,b.soluong,b.cachdung from " + xxx + ".d_toathuocll a," + xxx + ".d_toathuocct b," + user + ".d_dmbd c";
                            sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0,10) + "'";
                            sql += " and a.maql=" + l_maql;
                            s = "";
                            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                            {
                                s += r["ten"].ToString().Trim() + " " + r["soluong"].ToString().Trim() + " " + r["dang"].ToString().Trim() + "\n";
                            }
                            this.toolTip1.SetToolTip(this.treeView1,s);
                        }
                    }
                    catch { }
                }
            }
        }

        private void butXthuoc_Click(object sender, EventArgs e)
        {
            if (mabn2.Text.Length + mabn3.Text.Length != 8 || hoten.Text == "") return;
            //frmXemthuocpk f = new frmXemthuocpk(m, mabn2.Text + mabn3.Text,hoten.Text);
            //f.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            //frmTusat f = new frmTusat(l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid);
            //f.ShowDialog();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            //frmBenhmantinh f = new frmBenhmantinh(m,s_mabn,i_userid);
            //f.ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            //frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text);
            //f.ShowDialog();
        }

        private void chkToathuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkToathuoc) m.writeXml("thongso", "pktoathuoc", (chkToathuoc.Checked) ? "1" : "0");
        }

        private void chkLCD_Click(object sender, EventArgs e)
        {
            this.m.writeXml("thongso", "pklcd", this.chkLCD.Checked ? "1" : "0");
        }

        private void lblLCD_Click(object sender, EventArgs e)
        {
            //new frmThongsoLCDpk(this.m).ShowDialog();
        }
        ////linh
        //bool Send(string s)
        //{
        //    char c;
        //    int nlen = 0;
        //    nlen = s.Trim().Length;
        //    if ((nlen > 4) || (nlen == 0)) return false;
        //    for (int i = 0; i < nlen; i++)
        //    {
        //        c = s[i];
        //        if ((c < '0') || (c > '9'))
        //        {
        //            return false;
        //        }
        //    }
        //    switch (nlen)
        //    {
        //        case 1:
        //            L1 = a_fon[20];
        //            L2 = a_fon[20];
        //            L3 = a_fon[20];
        //            L4 = a_fon[int.Parse(s.Substring(0, 1))];
        //            break;
        //        case 2:
        //            L1 = a_fon[20];
        //            L2 = a_fon[20];
        //            L3 = a_fon[int.Parse(s.Substring(0, 1))];
        //            L4 = a_fon[int.Parse(s.Substring(1, 1))];
        //            break;
        //        case 3:
        //            L1 = a_fon[20];
        //            L2 = a_fon[int.Parse(s.Substring(0, 1))];
        //            L3 = a_fon[int.Parse(s.Substring(1, 1))];
        //            L4 = a_fon[int.Parse(s.Substring(2, 1))];
        //            break;
        //        default:
        //            L1 = a_fon[int.Parse(s.Substring(0, 1))];
        //            L2 = a_fon[int.Parse(s.Substring(1, 1))];
        //            L3 = a_fon[int.Parse(s.Substring(2, 1))];
        //            L4 = a_fon[int.Parse(s.Substring(3, 1))];
        //            break;
        //    }
        //    Ds = 128;
        //    Checksum = (L1 + L2 + L3 + L4 + Ds);
        //    Checksum = Checksum % 256;
        //    st = Microsoft.VisualBasic.Strings.Chr(L4).ToString() + Microsoft.VisualBasic.Strings.Chr(L3).ToString() +
        //        Microsoft.VisualBasic.Strings.Chr(L2).ToString() + Microsoft.VisualBasic.Strings.Chr(L1).ToString() +
        //        Microsoft.VisualBasic.Strings.Chr(Ds).ToString() + Microsoft.VisualBasic.Strings.Chr(Checksum).ToString();
        //    try
        //    {
        //        MSComm1.Output = st;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //bool Mocong(short cong, string settings)
        //{
        //    bool gttv = false;
        //    try
        //    {
        //        if (MSComm1.PortOpen)
        //        {
        //            MSComm1.PortOpen = false;
        //        }
        //        MSComm1.CommPort = cong;
        //        MSComm1.Settings = settings;
        //        MSComm1.RThreshold = 1;
        //        MSComm1.PortOpen = true;
        //        MSComm1.Handshaking = MSCommLib.HandshakeConstants.comNone;
        //        gttv = true;
        //    }
        //    catch
        //    {
        //        gttv = false;
        //    }
        //    return gttv;
        //}
        ////end linh

        private string f_get_tiensu(string s_mabn)
        {
            string s_tiensu = "";
            sql = "select * from " + m.user + ".theodoitsu where mabn='" + s_mabn + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                s_tiensu += (s_tiensu.IndexOf(r["noidung"].ToString() + ",") < 0) ? r["noidung"].ToString() + ", " : "";
            }
            return s_tiensu;
        }

        private void upd_mabs_toathuoc(long l_maql, string m_mabs)
        {
            string xxx = m.user + m.mmyy(ngayvv.Text);
            string asql = "select mabs, done from xxx.d_thuocbhytll where maql=" + l_maql + " and mabs<>'" + m_mabs + "'";
            DataSet lds = m.get_data_mmyy(asql, ngayvv.Text, ngayvv.Text, true);
            if (lds.Tables[0].Rows.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("Bạn có muốn cập nhật lại Bác sĩ đã cấp toa thuốc không?", "Toa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.Yes)
                {
                    if (lds.Tables[0].Rows[0]["done"].ToString() == "0")
                    {
                        asql = "update xxx.d_thuocbhytll set mabs='" + m_mabs + "' where maql=" + l_maql;
                        m.execute_data_mmyy(asql, ngayvv.Text, ngayvv.Text, true);
                    }
                    else
                    {
                        MessageBox.Show("Toa thuốc này đã duyệt, không cậo nhật lại Bác sĩ được");
                    }
                }

            }
        }

        private void hen_in_Click(object sender, EventArgs e)
        {
            if (ngayvv.Text != "")
            {
                DataSet dsdt = new DataSet();
                dsdt.ReadXml("..\\..\\..\\xml\\m_phieudieutri.xml");
                dsdt.Tables[0].Columns.Add("mabv");
                dsdt.Clear();
                long maql1;
                DataRow r;
                bool bStt = false;
                string ngay, noidkkcb = "", so, s_sovaovien = "";
                if (s_noicap != "") mabv.Text = s_noicap;
                if (tenbv.Text != "" || s_noicap.Trim() != "") 
                    foreach (DataRow r1 in m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows)
                        noidkkcb = r1["tenbv"].ToString();
                if (noidkkcb.Trim() == "") noidkkcb = tenbv.Text;

                DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
                if (hen_loai.SelectedIndex == 0)
                {
                    for (int i = 1; i <= Convert.ToInt16(hen_ngay.Value); i++)
                    {
                        ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(i));
                        r = dsdt.Tables[0].NewRow();
                        r["syt"] = m.Syte;
                        r["bv"] = m.Tenbv;
                        r["diachibv"] = tenbs.Text;
                        r["ngayin"] = ngayvv.Text;
                        r["nguoiin"] = s_userid;
                        r["ghichu"] = hen_ghichu.Text;
                        r["lien"] = "SỐ : " + sovaovien.Text;
                        r["mabn"] = mabn2.Text + mabn3.Text;
                        r["hoten"] = hoten.Text;
                        r["namsinh"] = namsinh.Text;
                        r["tuoi"] = tuoi.Text + " " + loaituoi.Text;
                        r["gioitinh"] = phai.SelectedIndex.ToString();
                        r["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
                        r["ngaykham"] = ngay;
                        r["lydokham"] = hen_ghichu.Text;
                        r["nghenghiep"] = tennn.Text;
                        r["doituong"] = tendoituong.Text;
                        r["sothe"] = sothe.Text;
                        r["tungay"] = (chkTiepdon.Checked) ? "Qua tiếp đón" : "";
                        r["denngay"] = denngay.Text+"^"+s_tungay;
                        r["noidkkcb"] = noidkkcb.Trim() + "^" + cholam.Text.Trim();
                        r["mabv"] = mabv.Text;
                        r["chandoan"] = cd_chinh.Text;
                        r["dantoc"] = tendantoc.Text;
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (!chkTiepdon.Checked)
                        {
                            //if (!m.bMmyy(m.mmyy(ngay))) d.tao_user_mmyy(m.mmyy(ngay),i_userid);
                            if (m.mmyy(ngay) == m.mmyy(ngayvv.Text))
                            {
                                maql1 = m.get_maql_tiepdon (s_mabn, ngay + " 07:00");
                                s_sovaovien = sovaovien.Text;
                                if (bStt)
                                {
                                    s_sovaovien = "";
                                    foreach (DataRow r1 in m.get_data("select * from " + user + m.mmyy(ngay) + ".tiepdon where maql=" + maql1).Tables[0].Rows)
                                        s_sovaovien = r1["sovaovien"].ToString();
                                    if (s_sovaovien == "")
                                    {
                                        s_sovaovien = "0";// m.getSttkham(ngay, makp.Text).ToString();
                                        string s_hen = hen_ghichu.Text.Trim() + ", Thứ tự tái khám " + s_sovaovien;
                                        hen_ghichu.Text = s_hen;
                                    }
                                }
                                m.upd_tiepdon_hen(s_mabn, l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), s_sovaovien, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Khambenh, loai.SelectedIndex, ngayvv.Text + " " + giovv.Text);
                                m.upd_lienhe(ngay, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                {
                                    if (!m.upd_bhyt(ngay, s_mabn, maql1, sothe.Text, denngay.Text, mabv.Text, 0, "", "", "", "", traituyen.SelectedIndex)) 
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                        return;
                                    }                                    
                                }
                            }
                            else
                            {
                                maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                                s_sovaovien = sovaovien.Text;
                                if (bStt)
                                {
                                    s_sovaovien = "";
                                    foreach (DataRow r1 in m.get_data("select * from " + user + m.mmyy(ngay) + ".tiepdon where maql=" + maql1).Tables[0].Rows)
                                        s_sovaovien = r1["sovaovien"].ToString();
                                    if (s_sovaovien == "")
                                    {
                                        s_sovaovien = "0";//m.getSttkham_hen(ngay, makp.Text).ToString();
                                        string s_hen = hen_ghichu.Text.Trim() + ", Thứ tự tái khám " + s_sovaovien;
                                        hen_ghichu.Text = s_hen;
                                    }
                                }
                                m.upd_tiepdon(s_mabn, l_matd, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), s_sovaovien, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), bnmoi.SelectedIndex, i_userid, LibMedi.AccessData.Khambenh, loai.SelectedIndex);
                                m.upd_lienhe(maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                {
                                    if (!m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, mabv.Text, 0, "", "", "", "", traituyen.SelectedIndex)) 
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                        return;
                                    }                                   
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
                        case 1: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 2: ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * Convert.ToInt16(hen_ngay.Value)));
                            break;
                        case 3: ngay = m.DateToString("dd/MM/yyyy", dt.AddMonths(Convert.ToInt16(hen_ngay.Value)));
                            break;
                        default: ngay = m.DateToString("dd/MM/yyyy", dt.AddYears(Convert.ToInt16(hen_ngay.Value)));
                            break;
                    }
                    r = dsdt.Tables[0].NewRow();
                    r["syt"] = m.Syte;
                    r["bv"] = m.Tenbv;
                    r["diachibv"] = tenbs.Text;
                    r["ngayin"] = ngayvv.Text;
                    r["nguoiin"] = s_userid;
                    r["ghichu"] = hen_ghichu.Text;
                    r["lien"] = "SỐ : " + sovaovien.Text;
                    r["mabn"] = mabn2.Text + mabn3.Text;
                    r["hoten"] = hoten.Text;
                    r["namsinh"] = namsinh.Text;
                    r["tuoi"] = tuoi.Text + " " + loaituoi.Text;
                    r["gioitinh"] = phai.SelectedIndex.ToString();
                    r["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
                    r["ngaykham"] = ngay;
                    r["lydokham"] = hen_ghichu.Text;
                    r["nghenghiep"] = tennn.Text;
                    r["doituong"] = tendoituong.Text;
                    r["sothe"] = sothe.Text;
                    r["tungay"] = (chkTiepdon.Checked) ? "Qua tiếp đón" : "";
                    r["denngay"] = denngay.Text+"^"+s_tungay ;
                    r["noidkkcb"] = noidkkcb + "^" + cholam.Text;
                    r["mabv"] = mabv.Text;
                    r["chandoan"] = cd_chinh.Text;
                    r["dantoc"] = tendantoc.Text;
                    s_mabn = mabn2.Text + mabn3.Text;
                    dsdt.Tables[0].Rows.Add(r);
                }
                if (m.bPreview)
                {
                    if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                    dsdt.WriteXml("..\\..\\dataxml\\m_phieuhen.xml", XmlWriteMode.WriteSchema);
                    dllReportM.frmReport f = new dllReportM.frmReport(dsdt, "", "", "m_phieuhen.rpt");
                    f.ShowDialog(this);
                }
                else print.Printer(dsdt, "m_phieuhen.rpt", "", "", 0);
            }
            butLuu.Focus();
        }

        private void chkTiepdon_CheckedChanged(object sender, EventArgs e)
        {
            m.writeXml("thongso", "hen_quadangky", chkTiepdon.Checked ? "1" : "0");
        }

        private void f_load_option()
        {
            bChandoan_kemtheo_icd10 = m.bChandoan_kemtheo_icd10;
        }
	}
}
