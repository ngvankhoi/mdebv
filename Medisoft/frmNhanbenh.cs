using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
//using Medisoft.CyberRef;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmNhanbenh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
		private AccessData m;
		private DataSet ds=new DataSet();
        private string user, nam, s_userid, s_mabn, s_msg, s_ngayvv, m_phainu, m_sosinh, r_makp, makp_save, s_ngaybong, para, s_soluutru, ma_vantay, u00 = "U00",ngay1,ngay2,ngay3,s_ngaysrv;
        private int i_userid, i_mabv, i_maba, iCapso = 0, i_khudt=0, i_chinhanh=0;
		private decimal l_matd=0,l_maql=0;
        private bool bNew = false, bTuChoiNhapVienNeuChuaThanhToan=false;
        private FingerApp.FrmNhanDang fnhandang;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
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
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30,iTreem6,iTreem15;
        private bool b_Edit = false, b_Hoten = false, bSankhoa, bBong, bNhi, bSosinh, bTamthan, b_bacsi, bAdmin, bMabame, bKhamthai, bTiepdon, bChuyenkhoasan, bVantay, bVantay_mabntudong, bMabn_tudong_tu_ServerInterNet_D24 = false, bMabn_tudong = false, bMabn_tudong_theomay=false ;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.ComponentModel.IContainer components;
        private bool b_sovaovien, b_soluutru, bNhapsoluutru, bDenngay_sothe, bChandoan, bChandoan_kemtheo, bSothe_mabn, bTungay, bSothe_dkkcb, bSothe_ngay_huong, bTraituyen, bChuathanhtoan_khongcho_nhanbenh = false, bThongtinNguoithan = false, bnKhamBHYTmotlantrongngay = false;
		private System.Windows.Forms.Panel pnhi;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label45;
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
		private System.Windows.Forms.Panel psosinh;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label lphai;
		private System.Windows.Forms.Label lmann;
		private System.Windows.Forms.Panel ppara;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label lsonha;
		private System.Windows.Forms.Label lmanuoc;
		private System.Windows.Forms.Label lmadantoc;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.Label lmaphuongxa;
		private System.Windows.Forms.Label lmaqu;
		private MaskedTextBox.MaskedTextBox tdvh;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.Label ltdvh;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.TextBox madoituong;
		private System.Windows.Forms.ComboBox tendentu;
		private System.Windows.Forms.ComboBox tendoituong;
		private MaskedTextBox.MaskedTextBox icd_kkb;
		private System.Windows.Forms.Label label34;
		private MaskedTextBox.MaskedTextBox icd_noichuyenden;
		private System.Windows.Forms.Label label31;
		private MaskedTextBox.MaskedTextBox qh_dienthoai;
		private System.Windows.Forms.TextBox qh_diachi;
		private System.Windows.Forms.TextBox qh_hoten;
		private System.Windows.Forms.TextBox quanhe;
		private MaskedTextBox.MaskedTextBox lanthu;
		private MaskedTextBox.MaskedTextBox sothe;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox tennhantu;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox nhantu;
		private System.Windows.Forms.TextBox dentu;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Panel pvaovien;
		private System.Windows.Forms.Label lbong;
		private System.Windows.Forms.TextBox nhi_mann_me;
		private System.Windows.Forms.ComboBox nhi_tennn_me;
		private System.Windows.Forms.TextBox nhi_vanhoa_me;
		private System.Windows.Forms.TextBox nhi_mann_bo;
		private System.Windows.Forms.ComboBox nhi_tennn_bo;
		private System.Windows.Forms.TextBox nhi_vanhoa_bo;
		private System.Windows.Forms.TextBox nhi_hoten_me;
		private System.Windows.Forms.TextBox nhi_hoten_bo;
		private MaskedTextBox.MaskedTextBox ss_ns_bo;
		private System.Windows.Forms.TextBox ss_mann_bo;
		private System.Windows.Forms.ComboBox ss_tennn_bo;
		private System.Windows.Forms.TextBox ss_hoten_bo;
		private MaskedTextBox.MaskedTextBox ss_delan;
		private MaskedTextBox.MaskedTextBox ss_ns_me;
		private System.Windows.Forms.TextBox ss_mann_me;
		private System.Windows.Forms.ComboBox ss_tennn_me;
		private System.Windows.Forms.TextBox ss_hoten_me;
		private System.Windows.Forms.ComboBox ss_nhommau;
		private MaskedTextBox.MaskedTextBox ss_para4;
		private MaskedTextBox.MaskedTextBox ss_para3;
		private MaskedTextBox.MaskedTextBox ss_para2;
        private MaskedTextBox.MaskedTextBox ss_para1;
		private MaskedTextBox.MaskedTextBox icd_kemtheo;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.Label label49;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngaybong;
		private LibList.List listdstt;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private string s_icd_noichuyenden,s_icd_kkb,s_icd_kemtheo,sql,pathImage;
		private LibList.List listICD;
		private System.Windows.Forms.TextBox cd_noichuyenden;
		private System.Windows.Forms.TextBox cd_kkb;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private LibList.List list;
		private MaskedTextBox.MaskedTextBox mabv;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.Label label11;
		private MaskedTextBox.MaskedTextBox soluutru;
		private System.Windows.Forms.Label label12;
        private MaskedTextBox.MaskedTextBox mame;
		private System.Windows.Forms.Panel khamthai;
		private MaskedTextBox.MaskedTextBox para4;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel ddsosinh;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label47;
		private MaskedTextBox.MaskedTextBox apgar1;
		private MaskedTextBox.MaskedTextBox apgar5;
		private MaskedTextBox.MaskedTextBox apgar10;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox cao;
        private MaskedTextBox.MaskedTextBox vongdau;
		private System.Windows.Forms.TextBox tenbs;
		private LibList.List listBS;
		private System.Windows.Forms.Panel pmat;
		private MaskedTextBox.MaskedTextBox nhanapp;
		private MaskedTextBox.MaskedTextBox mt;
		private MaskedTextBox.MaskedTextBox mp;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label67;
		private MaskedTextBox.MaskedTextBox nhanapt;
		private System.Windows.Forms.Label label66;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripLabel tlblme;
        private ToolStripLabel tlbl;
        private MaskedBox.MaskedBox giovv;
        private Label label48;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Button button1;
        private Button button2;
        private TreeView treeView1;
        private PictureBox pic;
		private DataTable dticd=new DataTable();
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private PictureBox ptb;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tbutvantay;
        private Label lblvt;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButton5;
        private MaskedBox.MaskedBox tungay;
        private Label label25;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton7;
        private System.Drawing.Bitmap map;
        private int _dai = 18, _vitri = 14;
        private ComboBox traituyen;
        private Button butget_msbn_from_internet;
        private string _sothe = "08001";
        private bool bQuanly_Theo_Chinhanh = false;
        private DataTable dtdt;

		public frmNhanbenh(AccessData acc,string makp,string hoten,int userid,int mabv,bool sovaovien,bool soluutru,int _khudt, int _chinhanh)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			r_makp=makp;
			s_userid=hoten;
			i_userid=userid;
			i_mabv=mabv;
			b_sovaovien=sovaovien;
			b_soluutru=soluutru;
            i_khudt = _khudt;
            i_chinhanh = _chinhanh;
            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
            if (Screen.PrimaryScreen.WorkingArea.Width >= 1000)//
            {

                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanbenh));
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
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.tdvh = new MaskedTextBox.MaskedTextBox();
            this.lanthu = new MaskedTextBox.MaskedTextBox();
            this.ss_para4 = new MaskedTextBox.MaskedTextBox();
            this.ss_para3 = new MaskedTextBox.MaskedTextBox();
            this.ss_para2 = new MaskedTextBox.MaskedTextBox();
            this.ss_para1 = new MaskedTextBox.MaskedTextBox();
            this.pnhi = new System.Windows.Forms.Panel();
            this.nhi_mann_me = new System.Windows.Forms.TextBox();
            this.nhi_mann_bo = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.nhi_hoten_me = new System.Windows.Forms.TextBox();
            this.nhi_tennn_bo = new System.Windows.Forms.ComboBox();
            this.nhi_hoten_bo = new System.Windows.Forms.TextBox();
            this.nhi_tennn_me = new System.Windows.Forms.ComboBox();
            this.nhi_vanhoa_me = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.nhi_vanhoa_bo = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.phanhchinh = new System.Windows.Forms.Panel();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.tqx = new System.Windows.Forms.TextBox();
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
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.lmann = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.psosinh = new System.Windows.Forms.Panel();
            this.ss_hoten_me = new System.Windows.Forms.TextBox();
            this.ss_tennn_bo = new System.Windows.Forms.ComboBox();
            this.ss_mann_bo = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.ss_ns_me = new MaskedTextBox.MaskedTextBox();
            this.mame = new MaskedTextBox.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ss_ns_bo = new MaskedTextBox.MaskedTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.ss_hoten_bo = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.ss_delan = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.ss_mann_me = new System.Windows.Forms.TextBox();
            this.ss_tennn_me = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.ppara = new System.Windows.Forms.Panel();
            this.ss_nhommau = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label25 = new System.Windows.Forms.Label();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.icd_noichuyenden = new MaskedTextBox.MaskedTextBox();
            this.pmat = new System.Windows.Forms.Panel();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.ddsosinh = new System.Windows.Forms.Panel();
            this.vongdau = new MaskedTextBox.MaskedTextBox();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.apgar10 = new MaskedTextBox.MaskedTextBox();
            this.apgar5 = new MaskedTextBox.MaskedTextBox();
            this.apgar1 = new MaskedTextBox.MaskedTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.giovv = new MaskedBox.MaskedBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.khamthai = new System.Windows.Forms.Panel();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.quanhe = new System.Windows.Forms.TextBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.listdstt = new LibList.List();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.list = new LibList.List();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.ngaybong = new MaskedBox.MaskedBox();
            this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.listBS = new LibList.List();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.lbong = new System.Windows.Forms.Label();
            this.ltdvh = new System.Windows.Forms.Label();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.dentu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listICD = new LibList.List();
            this.label55 = new System.Windows.Forms.Label();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tlblme = new System.Windows.Forms.ToolStripLabel();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutvantay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblvt = new System.Windows.Forms.Label();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.butget_msbn_from_internet = new System.Windows.Forms.Button();
            this.pnhi.SuspendLayout();
            this.phanhchinh.SuspendLayout();
            this.psosinh.SuspendLayout();
            this.ppara.SuspendLayout();
            this.pvaovien.SuspendLayout();
            this.pmat.SuspendLayout();
            this.ddsosinh.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(72, 62);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(128, 21);
            this.tenba.TabIndex = 2;
            this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(201, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(10, 105);
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
            this.mabn1.Location = new System.Drawing.Point(160, 34);
            this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn1.MaxLength = 8;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(45, 21);
            this.mabn1.TabIndex = 4;
            this.mabn1.Visible = false;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(247, 62);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 5;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(270, 62);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(105, 21);
            this.mabn3.TabIndex = 6;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(130, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(191, 106);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 9;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(236, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
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
            "m.o",
            "d.o.",
            "h.o."});
            this.loaituoi.Location = new System.Drawing.Point(317, 106);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(58, 21);
            this.loaituoi.TabIndex = 11;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(128, 34);
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
            this.tuoi.Location = new System.Drawing.Point(287, 106);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
            this.tuoi.TabIndex = 10;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(72, 84);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(303, 21);
            this.hoten.TabIndex = 7;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(5, 29);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(384, 23);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(251, 518);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 44;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
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
            this.butLuu.Location = new System.Drawing.Point(321, 518);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 42;
            this.butLuu.Text = "    &Lưu";
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
            this.butBoqua.Location = new System.Drawing.Point(391, 518);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 43;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(461, 518);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 46;
            this.butKetthuc.Text = "   Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tdvh
            // 
            this.tdvh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tdvh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdvh.Location = new System.Drawing.Point(98, 130);
            this.tdvh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tdvh.MaxLength = 30;
            this.tdvh.Name = "tdvh";
            this.tdvh.Size = new System.Drawing.Size(97, 21);
            this.tdvh.TabIndex = 11;
            this.toolTip2.SetToolTip(this.tdvh, "Trình độ văn hóa");
            this.tdvh.Visible = false;
            // 
            // lanthu
            // 
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(98, 108);
            this.lanthu.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.lanthu.MaxLength = 3;
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(24, 21);
            this.lanthu.TabIndex = 8;
            this.toolTip2.SetToolTip(this.lanthu, "Vào viện do bệnh này lần thứ");
            this.lanthu.Validated += new System.EventHandler(this.lanthu_Validated);
            // 
            // ss_para4
            // 
            this.ss_para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_para4.Location = new System.Drawing.Point(348, 0);
            this.ss_para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_para4.MaxLength = 2;
            this.ss_para4.Name = "ss_para4";
            this.ss_para4.Size = new System.Drawing.Size(20, 21);
            this.ss_para4.TabIndex = 4;
            this.toolTip2.SetToolTip(this.ss_para4, "Sống");
            this.ss_para4.Validated += new System.EventHandler(this.ss_para4_Validated);
            // 
            // ss_para3
            // 
            this.ss_para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_para3.Location = new System.Drawing.Point(327, 0);
            this.ss_para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_para3.MaxLength = 2;
            this.ss_para3.Name = "ss_para3";
            this.ss_para3.Size = new System.Drawing.Size(20, 21);
            this.ss_para3.TabIndex = 3;
            this.toolTip2.SetToolTip(this.ss_para3, "Sẩy (nạo,hút)");
            this.ss_para3.Validated += new System.EventHandler(this.ss_para3_Validated);
            // 
            // ss_para2
            // 
            this.ss_para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_para2.Location = new System.Drawing.Point(306, 0);
            this.ss_para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_para2.MaxLength = 2;
            this.ss_para2.Name = "ss_para2";
            this.ss_para2.Size = new System.Drawing.Size(20, 21);
            this.ss_para2.TabIndex = 2;
            this.toolTip2.SetToolTip(this.ss_para2, "Sớm (thiếu tháng)");
            this.ss_para2.Validated += new System.EventHandler(this.ss_para2_Validated);
            // 
            // ss_para1
            // 
            this.ss_para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_para1.Location = new System.Drawing.Point(285, 0);
            this.ss_para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_para1.MaxLength = 2;
            this.ss_para1.Name = "ss_para1";
            this.ss_para1.Size = new System.Drawing.Size(20, 21);
            this.ss_para1.TabIndex = 1;
            this.toolTip2.SetToolTip(this.ss_para1, "Sinh (đủ tháng)");
            this.ss_para1.Validated += new System.EventHandler(this.ss_para1_Validated);
            // 
            // pnhi
            // 
            this.pnhi.BackColor = System.Drawing.Color.Transparent;
            this.pnhi.Controls.Add(this.nhi_mann_me);
            this.pnhi.Controls.Add(this.nhi_mann_bo);
            this.pnhi.Controls.Add(this.label41);
            this.pnhi.Controls.Add(this.label43);
            this.pnhi.Controls.Add(this.nhi_hoten_me);
            this.pnhi.Controls.Add(this.nhi_tennn_bo);
            this.pnhi.Controls.Add(this.nhi_hoten_bo);
            this.pnhi.Controls.Add(this.nhi_tennn_me);
            this.pnhi.Controls.Add(this.nhi_vanhoa_me);
            this.pnhi.Controls.Add(this.label45);
            this.pnhi.Controls.Add(this.nhi_vanhoa_bo);
            this.pnhi.Controls.Add(this.label35);
            this.pnhi.Controls.Add(this.label33);
            this.pnhi.Controls.Add(this.label14);
            this.pnhi.Location = new System.Drawing.Point(8, 270);
            this.pnhi.Name = "pnhi";
            this.pnhi.Size = new System.Drawing.Size(379, 101);
            this.pnhi.TabIndex = 15;
            this.pnhi.Visible = false;
            // 
            // nhi_mann_me
            // 
            this.nhi_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_mann_me.Location = new System.Drawing.Point(64, 66);
            this.nhi_mann_me.MaxLength = 2;
            this.nhi_mann_me.Name = "nhi_mann_me";
            this.nhi_mann_me.Size = new System.Drawing.Size(24, 21);
            this.nhi_mann_me.TabIndex = 6;
            this.nhi_mann_me.Validated += new System.EventHandler(this.nhi_mann_me_Validated);
            this.nhi_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_me_KeyDown);
            // 
            // nhi_mann_bo
            // 
            this.nhi_mann_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_mann_bo.Location = new System.Drawing.Point(64, 22);
            this.nhi_mann_bo.MaxLength = 2;
            this.nhi_mann_bo.Name = "nhi_mann_bo";
            this.nhi_mann_bo.Size = new System.Drawing.Size(24, 21);
            this.nhi_mann_bo.TabIndex = 2;
            this.nhi_mann_bo.Validated += new System.EventHandler(this.nhi_mann_bo_Validated);
            this.nhi_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_bo_KeyDown);
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label41.Location = new System.Drawing.Point(2, 21);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(64, 23);
            this.label41.TabIndex = 24;
            this.label41.Text = "Nghề bố :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label43.Location = new System.Drawing.Point(1, 63);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(66, 23);
            this.label43.TabIndex = 29;
            this.label43.Text = "Nghề mẹ :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_hoten_me
            // 
            this.nhi_hoten_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_hoten_me.Location = new System.Drawing.Point(64, 44);
            this.nhi_hoten_me.Name = "nhi_hoten_me";
            this.nhi_hoten_me.Size = new System.Drawing.Size(120, 21);
            this.nhi_hoten_me.TabIndex = 4;
            this.nhi_hoten_me.Validated += new System.EventHandler(this.nhi_hoten_me_Validated);
            this.nhi_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_me_KeyDown);
            // 
            // nhi_tennn_bo
            // 
            this.nhi_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhi_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_tennn_bo.Location = new System.Drawing.Point(89, 22);
            this.nhi_tennn_bo.Name = "nhi_tennn_bo";
            this.nhi_tennn_bo.Size = new System.Drawing.Size(278, 21);
            this.nhi_tennn_bo.TabIndex = 3;
            this.nhi_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_bo_SelectedIndexChanged);
            this.nhi_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_bo_KeyDown);
            // 
            // nhi_hoten_bo
            // 
            this.nhi_hoten_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_hoten_bo.Location = new System.Drawing.Point(64, 0);
            this.nhi_hoten_bo.Name = "nhi_hoten_bo";
            this.nhi_hoten_bo.Size = new System.Drawing.Size(126, 21);
            this.nhi_hoten_bo.TabIndex = 0;
            this.nhi_hoten_bo.Validated += new System.EventHandler(this.nhi_hoten_bo_Validated);
            this.nhi_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_bo_KeyDown);
            // 
            // nhi_tennn_me
            // 
            this.nhi_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhi_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_tennn_me.Location = new System.Drawing.Point(89, 66);
            this.nhi_tennn_me.Name = "nhi_tennn_me";
            this.nhi_tennn_me.Size = new System.Drawing.Size(278, 21);
            this.nhi_tennn_me.TabIndex = 7;
            this.nhi_tennn_me.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_me_SelectedIndexChanged);
            this.nhi_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_me_KeyDown);
            // 
            // nhi_vanhoa_me
            // 
            this.nhi_vanhoa_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_vanhoa_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_vanhoa_me.Location = new System.Drawing.Point(247, 44);
            this.nhi_vanhoa_me.Name = "nhi_vanhoa_me";
            this.nhi_vanhoa_me.Size = new System.Drawing.Size(120, 21);
            this.nhi_vanhoa_me.TabIndex = 5;
            this.nhi_vanhoa_me.Validated += new System.EventHandler(this.nhi_vanhoa_me_Validated);
            this.nhi_vanhoa_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_me_KeyDown);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(183, 42);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(63, 23);
            this.label45.TabIndex = 25;
            this.label45.Text = "VH mẹ :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_vanhoa_bo
            // 
            this.nhi_vanhoa_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_vanhoa_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_vanhoa_bo.Location = new System.Drawing.Point(247, 0);
            this.nhi_vanhoa_bo.Name = "nhi_vanhoa_bo";
            this.nhi_vanhoa_bo.Size = new System.Drawing.Size(120, 21);
            this.nhi_vanhoa_bo.TabIndex = 1;
            this.nhi_vanhoa_bo.Validated += new System.EventHandler(this.nhi_vanhoa_bo_Validated);
            this.nhi_vanhoa_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_bo_KeyDown);
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label35.Location = new System.Drawing.Point(121, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(128, 23);
            this.label35.TabIndex = 15;
            this.label35.Text = "VH bố :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label33.Location = new System.Drawing.Point(3, 42);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 23);
            this.label33.TabIndex = 13;
            this.label33.Text = "Họ tên mẹ :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 11;
            this.label14.Text = "Họ tên bố :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phanhchinh
            // 
            this.phanhchinh.BackColor = System.Drawing.Color.Transparent;
            this.phanhchinh.Controls.Add(this.madantoc);
            this.phanhchinh.Controls.Add(this.tennuoc);
            this.phanhchinh.Controls.Add(this.manuoc);
            this.phanhchinh.Controls.Add(this.lmanuoc);
            this.phanhchinh.Controls.Add(this.tendantoc);
            this.phanhchinh.Controls.Add(this.lmadantoc);
            this.phanhchinh.Controls.Add(this.sonha);
            this.phanhchinh.Controls.Add(this.tentqx);
            this.phanhchinh.Controls.Add(this.cholam);
            this.phanhchinh.Controls.Add(this.thon);
            this.phanhchinh.Controls.Add(this.mapxa2);
            this.phanhchinh.Controls.Add(this.maqu2);
            this.phanhchinh.Controls.Add(this.matt);
            this.phanhchinh.Controls.Add(this.tqx);
            this.phanhchinh.Controls.Add(this.tenquan);
            this.phanhchinh.Controls.Add(this.tentinh);
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
            this.phanhchinh.Controls.Add(this.mann);
            this.phanhchinh.Controls.Add(this.tennn);
            this.phanhchinh.Controls.Add(this.lmann);
            this.phanhchinh.Location = new System.Drawing.Point(7, 222);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(378, 182);
            this.phanhchinh.TabIndex = 14;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(65, 24);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 2;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(249, 24);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(119, 21);
            this.tennuoc.TabIndex = 5;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(224, 24);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 4;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.BackColor = System.Drawing.Color.Transparent;
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmanuoc.Location = new System.Drawing.Point(161, 22);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(90, 24);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(69, 21);
            this.tendantoc.TabIndex = 3;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // lmadantoc
            // 
            this.lmadantoc.BackColor = System.Drawing.Color.Transparent;
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmadantoc.Location = new System.Drawing.Point(12, 22);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(65, 46);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(93, 21);
            this.sonha.TabIndex = 6;
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(114, 68);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(254, 21);
            this.tentqx.TabIndex = 9;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(65, 156);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(303, 21);
            this.cholam.TabIndex = 18;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(224, 46);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(144, 21);
            this.thon.TabIndex = 7;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(107, 134);
            this.mapxa2.MaxLength = 2;
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
            this.maqu2.Location = new System.Drawing.Point(93, 112);
            this.maqu2.MaxLength = 2;
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
            this.matt.Location = new System.Drawing.Point(65, 90);
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
            this.tqx.Location = new System.Drawing.Point(65, 68);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 8;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(117, 112);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(251, 21);
            this.tenquan.TabIndex = 14;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(93, 90);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(275, 21);
            this.tentinh.TabIndex = 11;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(131, 134);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(237, 21);
            this.tenpxa.TabIndex = 17;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(65, 134);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 15;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaphuongxa.Location = new System.Drawing.Point(-4, 135);
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
            this.maqu1.Location = new System.Drawing.Point(65, 112);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 12;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaqu.Location = new System.Drawing.Point(-12, 112);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmatt.Location = new System.Drawing.Point(12, 90);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.BackColor = System.Drawing.Color.Transparent;
            this.ltqx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ltqx.Location = new System.Drawing.Point(-4, 69);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.BackColor = System.Drawing.Color.Transparent;
            this.lcholam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcholam.Location = new System.Drawing.Point(-3, 158);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(71, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.BackColor = System.Drawing.Color.Transparent;
            this.lthon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lthon.Location = new System.Drawing.Point(151, 44);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(68, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.BackColor = System.Drawing.Color.Transparent;
            this.lsonha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsonha.Location = new System.Drawing.Point(20, 46);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(48, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(224, 2);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(24, 21);
            this.mann.TabIndex = 0;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(249, 2);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(119, 21);
            this.tennn.TabIndex = 1;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmann.Location = new System.Drawing.Point(97, 2);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(128, 16);
            this.lmann.TabIndex = 58;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.phai.Location = new System.Drawing.Point(72, 128);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(86, 21);
            this.phai.TabIndex = 12;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.BackColor = System.Drawing.Color.Transparent;
            this.lphai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lphai.Location = new System.Drawing.Point(18, 127);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // psosinh
            // 
            this.psosinh.BackColor = System.Drawing.Color.Transparent;
            this.psosinh.Controls.Add(this.ss_hoten_me);
            this.psosinh.Controls.Add(this.ss_tennn_bo);
            this.psosinh.Controls.Add(this.ss_mann_bo);
            this.psosinh.Controls.Add(this.label61);
            this.psosinh.Controls.Add(this.ss_ns_me);
            this.psosinh.Controls.Add(this.mame);
            this.psosinh.Controls.Add(this.label12);
            this.psosinh.Controls.Add(this.ss_ns_bo);
            this.psosinh.Controls.Add(this.label60);
            this.psosinh.Controls.Add(this.ss_hoten_bo);
            this.psosinh.Controls.Add(this.label62);
            this.psosinh.Controls.Add(this.ss_delan);
            this.psosinh.Controls.Add(this.label59);
            this.psosinh.Controls.Add(this.label58);
            this.psosinh.Controls.Add(this.ss_mann_me);
            this.psosinh.Controls.Add(this.ss_tennn_me);
            this.psosinh.Controls.Add(this.label56);
            this.psosinh.Controls.Add(this.label57);
            this.psosinh.Location = new System.Drawing.Point(6, 124);
            this.psosinh.Name = "psosinh";
            this.psosinh.Size = new System.Drawing.Size(377, 113);
            this.psosinh.TabIndex = 13;
            this.psosinh.Visible = false;
            // 
            // ss_hoten_me
            // 
            this.ss_hoten_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_hoten_me.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ss_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_hoten_me.Location = new System.Drawing.Point(66, 26);
            this.ss_hoten_me.Name = "ss_hoten_me";
            this.ss_hoten_me.Size = new System.Drawing.Size(186, 21);
            this.ss_hoten_me.TabIndex = 1;
            this.ss_hoten_me.Validated += new System.EventHandler(this.ss_hoten_me_Validated);
            this.ss_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_me_KeyDown);
            // 
            // ss_tennn_bo
            // 
            this.ss_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_tennn_bo.Location = new System.Drawing.Point(91, 92);
            this.ss_tennn_bo.Name = "ss_tennn_bo";
            this.ss_tennn_bo.Size = new System.Drawing.Size(278, 21);
            this.ss_tennn_bo.TabIndex = 9;
            this.ss_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_bo_SelectedIndexChanged);
            this.ss_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_bo_KeyDown);
            // 
            // ss_mann_bo
            // 
            this.ss_mann_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_mann_bo.Location = new System.Drawing.Point(66, 92);
            this.ss_mann_bo.Name = "ss_mann_bo";
            this.ss_mann_bo.Size = new System.Drawing.Size(24, 21);
            this.ss_mann_bo.TabIndex = 8;
            this.ss_mann_bo.Validated += new System.EventHandler(this.ss_mann_bo_Validated);
            this.ss_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_bo_KeyDown);
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label61.Location = new System.Drawing.Point(3, 91);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(64, 23);
            this.label61.TabIndex = 64;
            this.label61.Text = "Nghề bố :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_ns_me
            // 
            this.ss_ns_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_ns_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_ns_me.Location = new System.Drawing.Point(322, 26);
            this.ss_ns_me.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_ns_me.MaxLength = 4;
            this.ss_ns_me.Name = "ss_ns_me";
            this.ss_ns_me.Size = new System.Drawing.Size(47, 21);
            this.ss_ns_me.TabIndex = 2;
            this.ss_ns_me.Validated += new System.EventHandler(this.ss_ns_me_Validated);
            // 
            // mame
            // 
            this.mame.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mame.Location = new System.Drawing.Point(223, 4);
            this.mame.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mame.MaxLength = 8;
            this.mame.Name = "mame";
            this.mame.Size = new System.Drawing.Size(146, 21);
            this.mame.TabIndex = 0;
            this.mame.Validated += new System.EventHandler(this.mame_Validated);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(119, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 23);
            this.label12.TabIndex = 67;
            this.label12.Text = "Mã mẹ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_ns_bo
            // 
            this.ss_ns_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_ns_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_ns_bo.Location = new System.Drawing.Point(322, 70);
            this.ss_ns_bo.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_ns_bo.MaxLength = 4;
            this.ss_ns_bo.Name = "ss_ns_bo";
            this.ss_ns_bo.Size = new System.Drawing.Size(47, 21);
            this.ss_ns_bo.TabIndex = 7;
            this.ss_ns_bo.Validated += new System.EventHandler(this.ss_ns_bo_Validated);
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label60.Location = new System.Drawing.Point(246, 70);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(80, 23);
            this.label60.TabIndex = 66;
            this.label60.Text = "Năm sinh/tuổi :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_hoten_bo
            // 
            this.ss_hoten_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_hoten_bo.Location = new System.Drawing.Point(66, 70);
            this.ss_hoten_bo.Name = "ss_hoten_bo";
            this.ss_hoten_bo.Size = new System.Drawing.Size(179, 21);
            this.ss_hoten_bo.TabIndex = 6;
            this.ss_hoten_bo.Validated += new System.EventHandler(this.ss_hoten_bo_Validated);
            this.ss_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_bo_KeyDown);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label62.Location = new System.Drawing.Point(-29, 68);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(96, 23);
            this.label62.TabIndex = 60;
            this.label62.Text = "Họ tên bố :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_delan
            // 
            this.ss_delan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_delan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_delan.Location = new System.Drawing.Point(322, 48);
            this.ss_delan.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_delan.MaxLength = 6;
            this.ss_delan.Name = "ss_delan";
            this.ss_delan.Size = new System.Drawing.Size(47, 21);
            this.ss_delan.TabIndex = 5;
            this.ss_delan.Validated += new System.EventHandler(this.ss_delan_Validated);
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label59.Location = new System.Drawing.Point(259, 45);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(67, 23);
            this.label59.TabIndex = 58;
            this.label59.Text = "Đẻ lần mấy :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label58.Location = new System.Drawing.Point(262, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(64, 23);
            this.label58.TabIndex = 36;
            this.label58.Text = "Năm sinh :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_mann_me
            // 
            this.ss_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_mann_me.Location = new System.Drawing.Point(66, 48);
            this.ss_mann_me.Name = "ss_mann_me";
            this.ss_mann_me.Size = new System.Drawing.Size(24, 21);
            this.ss_mann_me.TabIndex = 3;
            this.ss_mann_me.Validated += new System.EventHandler(this.ss_mann_me_Validated);
            this.ss_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_me_KeyDown);
            // 
            // ss_tennn_me
            // 
            this.ss_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_tennn_me.Location = new System.Drawing.Point(91, 48);
            this.ss_tennn_me.Name = "ss_tennn_me";
            this.ss_tennn_me.Size = new System.Drawing.Size(161, 21);
            this.ss_tennn_me.TabIndex = 4;
            this.ss_tennn_me.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_me_SelectedIndexChanged);
            this.ss_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_me_KeyDown);
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label56.Location = new System.Drawing.Point(-13, 46);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 23);
            this.label56.TabIndex = 34;
            this.label56.Text = "Nghề mẹ :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label57.Location = new System.Drawing.Point(5, 26);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(62, 23);
            this.label57.TabIndex = 30;
            this.label57.Text = "Họ tên mẹ :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ppara
            // 
            this.ppara.BackColor = System.Drawing.Color.Transparent;
            this.ppara.Controls.Add(this.ss_nhommau);
            this.ppara.Controls.Add(this.ss_para4);
            this.ppara.Controls.Add(this.ss_para3);
            this.ppara.Controls.Add(this.ss_para2);
            this.ppara.Controls.Add(this.ss_para1);
            this.ppara.Controls.Add(this.label63);
            this.ppara.Controls.Add(this.label8);
            this.ppara.Location = new System.Drawing.Point(6, 370);
            this.ppara.Name = "ppara";
            this.ppara.Size = new System.Drawing.Size(379, 21);
            this.ppara.TabIndex = 16;
            // 
            // ss_nhommau
            // 
            this.ss_nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_nhommau.Location = new System.Drawing.Point(79, 0);
            this.ss_nhommau.Name = "ss_nhommau";
            this.ss_nhommau.Size = new System.Drawing.Size(51, 21);
            this.ss_nhommau.TabIndex = 0;
            this.ss_nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_nhommau_KeyDown);
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label63.Location = new System.Drawing.Point(199, -3);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(88, 23);
            this.label63.TabIndex = 78;
            this.label63.Text = "Tiền thai (Para) :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(-6, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 76;
            this.label8.Text = "Nhóm máu mẹ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pvaovien.BackColor = System.Drawing.Color.Transparent;
            this.pvaovien.Controls.Add(this.traituyen);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.tungay);
            this.pvaovien.Controls.Add(this.label25);
            this.pvaovien.Controls.Add(this.lanthu);
            this.pvaovien.Controls.Add(this.icd_kkb);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.pmat);
            this.pvaovien.Controls.Add(this.ddsosinh);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label48);
            this.pvaovien.Controls.Add(this.tenbs);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Controls.Add(this.soluutru);
            this.pvaovien.Controls.Add(this.label11);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.tenbv);
            this.pvaovien.Controls.Add(this.label10);
            this.pvaovien.Controls.Add(this.cd_kemtheo);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.cd_kkb);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.label9);
            this.pvaovien.Controls.Add(this.list);
            this.pvaovien.Controls.Add(this.mabv);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.tdvh);
            this.pvaovien.Controls.Add(this.ngaybong);
            this.pvaovien.Controls.Add(this.icd_kemtheo);
            this.pvaovien.Controls.Add(this.label46);
            this.pvaovien.Controls.Add(this.mabs);
            this.pvaovien.Controls.Add(this.label49);
            this.pvaovien.Controls.Add(this.listBS);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.lbong);
            this.pvaovien.Controls.Add(this.ltdvh);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.label29);
            this.pvaovien.Controls.Add(this.label28);
            this.pvaovien.Controls.Add(this.label27);
            this.pvaovien.Controls.Add(this.label26);
            this.pvaovien.Controls.Add(this.label24);
            this.pvaovien.Controls.Add(this.label23);
            this.pvaovien.Controls.Add(this.label22);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.dentu);
            this.pvaovien.Controls.Add(this.label21);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.button2);
            this.pvaovien.Location = new System.Drawing.Point(393, 21);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(397, 491);
            this.pvaovien.TabIndex = 17;
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
            this.traituyen.Location = new System.Drawing.Point(324, 196);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(63, 21);
            this.traituyen.TabIndex = 20;
            this.traituyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.traituyen_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(249, 152);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(24, 21);
            this.madoituong.TabIndex = 14;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(98, 174);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(140, 21);
            this.sothe.TabIndex = 16;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // tungay
            // 
            this.tungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(263, 174);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(60, 21);
            this.tungay.TabIndex = 17;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(229, 176);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 17);
            this.label25.TabIndex = 254;
            this.label25.Text = "Từ :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_kkb
            // 
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(98, 284);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(50, 21);
            this.icd_kkb.TabIndex = 26;
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            this.icd_kkb.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(98, 262);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(50, 21);
            this.icd_noichuyenden.TabIndex = 24;
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            // 
            // pmat
            // 
            this.pmat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pmat.BackColor = System.Drawing.Color.Transparent;
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.label50);
            this.pmat.Controls.Add(this.label51);
            this.pmat.Controls.Add(this.label54);
            this.pmat.Controls.Add(this.label65);
            this.pmat.Controls.Add(this.label66);
            this.pmat.Controls.Add(this.label67);
            this.pmat.Location = new System.Drawing.Point(4, 410);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(386, 22);
            this.pmat.TabIndex = 34;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(342, 0);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(24, 21);
            this.nhanapt.TabIndex = 26;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(292, 0);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(23, 21);
            this.nhanapp.TabIndex = 25;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(160, 1);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(25, 21);
            this.mt.TabIndex = 24;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(94, 0);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(21, 21);
            this.mp.TabIndex = 23;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label50.Location = new System.Drawing.Point(184, 2);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(24, 16);
            this.label50.TabIndex = 5;
            this.label50.Text = "/10";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label51.Location = new System.Drawing.Point(305, 2);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(40, 16);
            this.label51.TabIndex = 3;
            this.label51.Text = "T :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label54.Location = new System.Drawing.Point(189, 3);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(100, 16);
            this.label54.TabIndex = 2;
            this.label54.Text = "Nhãn áp P :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label65.Location = new System.Drawing.Point(133, 2);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(30, 16);
            this.label65.TabIndex = 1;
            this.label65.Text = "T :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label66.Location = new System.Drawing.Point(112, 3);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(24, 16);
            this.label66.TabIndex = 4;
            this.label66.Text = "/10";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label67.Location = new System.Drawing.Point(21, 2);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(74, 16);
            this.label67.TabIndex = 0;
            this.label67.Text = "Thị lực P :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddsosinh
            // 
            this.ddsosinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddsosinh.BackColor = System.Drawing.Color.Transparent;
            this.ddsosinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ddsosinh.Controls.Add(this.vongdau);
            this.ddsosinh.Controls.Add(this.cao);
            this.ddsosinh.Controls.Add(this.cannang);
            this.ddsosinh.Controls.Add(this.apgar10);
            this.ddsosinh.Controls.Add(this.apgar5);
            this.ddsosinh.Controls.Add(this.apgar1);
            this.ddsosinh.Controls.Add(this.label47);
            this.ddsosinh.Controls.Add(this.label44);
            this.ddsosinh.Controls.Add(this.label42);
            this.ddsosinh.Controls.Add(this.label40);
            this.ddsosinh.Controls.Add(this.label39);
            this.ddsosinh.Controls.Add(this.label38);
            this.ddsosinh.Controls.Add(this.label36);
            this.ddsosinh.Controls.Add(this.label37);
            this.ddsosinh.Controls.Add(this.label18);
            this.ddsosinh.Controls.Add(this.label32);
            this.ddsosinh.Controls.Add(this.label17);
            this.ddsosinh.Controls.Add(this.label16);
            this.ddsosinh.Controls.Add(this.label13);
            this.ddsosinh.Location = new System.Drawing.Point(7, 352);
            this.ddsosinh.Name = "ddsosinh";
            this.ddsosinh.Size = new System.Drawing.Size(381, 48);
            this.ddsosinh.TabIndex = 33;
            this.ddsosinh.Visible = false;
            // 
            // vongdau
            // 
            this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongdau.Location = new System.Drawing.Point(284, 24);
            this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.vongdau.MaxLength = 5;
            this.vongdau.Name = "vongdau";
            this.vongdau.Size = new System.Drawing.Size(24, 21);
            this.vongdau.TabIndex = 220;
            // 
            // cao
            // 
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(187, 24);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(24, 21);
            this.cao.TabIndex = 219;
            // 
            // cannang
            // 
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(90, 24);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(24, 21);
            this.cannang.TabIndex = 218;
            // 
            // apgar10
            // 
            this.apgar10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar10.Location = new System.Drawing.Point(284, 2);
            this.apgar10.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.apgar10.MaxLength = 3;
            this.apgar10.Name = "apgar10";
            this.apgar10.Size = new System.Drawing.Size(24, 21);
            this.apgar10.TabIndex = 217;
            // 
            // apgar5
            // 
            this.apgar5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar5.Location = new System.Drawing.Point(187, 2);
            this.apgar5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.apgar5.MaxLength = 3;
            this.apgar5.Name = "apgar5";
            this.apgar5.Size = new System.Drawing.Size(24, 21);
            this.apgar5.TabIndex = 216;
            // 
            // apgar1
            // 
            this.apgar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar1.Location = new System.Drawing.Point(90, 2);
            this.apgar1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.apgar1.MaxLength = 3;
            this.apgar1.Name = "apgar1";
            this.apgar1.Size = new System.Drawing.Size(24, 21);
            this.apgar1.TabIndex = 215;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label47.Location = new System.Drawing.Point(307, 20);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(32, 23);
            this.label47.TabIndex = 214;
            this.label47.Text = "cm";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(209, 20);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(21, 23);
            this.label44.TabIndex = 213;
            this.label44.Text = "cm";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(114, 20);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 23);
            this.label42.TabIndex = 212;
            this.label42.Text = "gram";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(220, 21);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 23);
            this.label40.TabIndex = 211;
            this.label40.Text = "Vòng đầu";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(146, 21);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(41, 23);
            this.label39.TabIndex = 210;
            this.label39.Text = "Cao";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label38.Location = new System.Drawing.Point(36, 20);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(55, 23);
            this.label38.TabIndex = 209;
            this.label38.Text = "Cân nặng";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label36.Location = new System.Drawing.Point(306, 1);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(32, 23);
            this.label36.TabIndex = 208;
            this.label36.Text = "điểm";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label37.Location = new System.Drawing.Point(241, 1);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(48, 23);
            this.label37.TabIndex = 206;
            this.label37.Text = "10 phút";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(209, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 23);
            this.label18.TabIndex = 205;
            this.label18.Text = "điểm";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label32.Location = new System.Drawing.Point(153, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 23);
            this.label32.TabIndex = 203;
            this.label32.Text = "5 phút";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(114, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 23);
            this.label17.TabIndex = 202;
            this.label17.Text = "điểm";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(54, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 23);
            this.label16.TabIndex = 200;
            this.label16.Text = "1 phút";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 23);
            this.label13.TabIndex = 199;
            this.label13.Text = "Apgar ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(98, 42);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // tendentu
            // 
            this.tendentu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(115, 64);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(272, 21);
            this.tendentu.TabIndex = 5;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(202, 42);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label48.Location = new System.Drawing.Point(172, 41);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(34, 23);
            this.label48.TabIndex = 252;
            this.label48.Text = "giờ :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(130, 328);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(139, 21);
            this.tenbs.TabIndex = 31;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(98, 152);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 13;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(91, 21);
            this.sovaovien.TabIndex = 19;
            this.sovaovien.Validated += new System.EventHandler(this.sovaovien_Validated);
            // 
            // khamthai
            // 
            this.khamthai.BackColor = System.Drawing.Color.Transparent;
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label15);
            this.khamthai.Location = new System.Drawing.Point(204, 129);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(132, 24);
            this.khamthai.TabIndex = 12;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(107, 1);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(20, 21);
            this.para4.TabIndex = 3;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(86, 1);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(20, 21);
            this.para3.TabIndex = 2;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(65, 1);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(20, 21);
            this.para2.TabIndex = 1;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(45, 1);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(19, 21);
            this.para1.TabIndex = 0;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(-3, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(322, 328);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(65, 21);
            this.soluutru.TabIndex = 32;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(253, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 226;
            this.label11.Text = "Số lưu trữ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(98, 218);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(83, 21);
            this.quanhe.TabIndex = 20;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // denngay
            // 
            this.denngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(325, 174);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(63, 21);
            this.denngay.TabIndex = 18;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(98, 196);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(225, 21);
            this.tenbv.TabIndex = 19;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(5, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 225;
            this.label10.Text = "ĐKKCB :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_kemtheo
            // 
            this.cd_kemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(149, 306);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(238, 21);
            this.cd_kemtheo.TabIndex = 29;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(149, 262);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(238, 21);
            this.cd_noichuyenden.TabIndex = 25;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_kkb
            // 
            this.cd_kkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(149, 284);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(238, 21);
            this.cd_kkb.TabIndex = 27;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(616, 0);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 222;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(98, 86);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 10;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(62, 21);
            this.madstt.TabIndex = 6;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(162, 86);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(226, 21);
            this.tendstt.TabIndex = 7;
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(5, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 23);
            this.label9.TabIndex = 221;
            this.label9.Text = "Tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(13, 450);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(24, 17);
            this.list.TabIndex = 219;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(105, 450);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(57, 21);
            this.mabv.TabIndex = 223;
            this.mabv.Visible = false;
            // 
            // tennhantu
            // 
            this.tennhantu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(303, 42);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(85, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // ngaybong
            // 
            this.ngaybong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaybong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaybong.Location = new System.Drawing.Point(98, 130);
            this.ngaybong.Mask = "##/##/#### ##:##";
            this.ngaybong.Name = "ngaybong";
            this.ngaybong.Size = new System.Drawing.Size(94, 21);
            this.ngaybong.TabIndex = 11;
            this.ngaybong.Text = "  /  /       :  ";
            this.ngaybong.Validated += new System.EventHandler(this.ngaybong_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(98, 306);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(50, 21);
            this.icd_kemtheo.TabIndex = 28;
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label46.Location = new System.Drawing.Point(4, 304);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(97, 22);
            this.label46.TabIndex = 218;
            this.label46.Text = "Bệnh kèm theo :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(98, 328);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(31, 21);
            this.mabs.TabIndex = 30;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label49.Location = new System.Drawing.Point(5, 327);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(96, 23);
            this.label49.TabIndex = 217;
            this.label49.Text = "BS nhận bệnh :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(166, 450);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 242;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(191, 108);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(196, 21);
            this.tenkp.TabIndex = 10;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // lbong
            // 
            this.lbong.BackColor = System.Drawing.Color.Transparent;
            this.lbong.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbong.Location = new System.Drawing.Point(4, 131);
            this.lbong.Name = "lbong";
            this.lbong.Size = new System.Drawing.Size(97, 23);
            this.lbong.TabIndex = 212;
            this.lbong.Text = "TG bỏng :";
            this.lbong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbong.Visible = false;
            // 
            // ltdvh
            // 
            this.ltdvh.BackColor = System.Drawing.Color.Transparent;
            this.ltdvh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ltdvh.Location = new System.Drawing.Point(5, 132);
            this.ltdvh.Name = "ltdvh";
            this.ltdvh.Size = new System.Drawing.Size(96, 23);
            this.ltdvh.TabIndex = 9;
            this.ltdvh.Text = "TĐVH :";
            this.ltdvh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ltdvh.Visible = false;
            // 
            // tendoituong
            // 
            this.tendoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(274, 152);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(114, 21);
            this.tendoituong.TabIndex = 15;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label34.Location = new System.Drawing.Point(4, 282);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(98, 23);
            this.label34.TabIndex = 203;
            this.label34.Text = "CĐ KKB, Cấp cứu :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label31.Location = new System.Drawing.Point(5, 261);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 23);
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
            this.qh_dienthoai.Location = new System.Drawing.Point(317, 240);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(70, 21);
            this.qh_dienthoai.TabIndex = 23;
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(98, 240);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(158, 21);
            this.qh_diachi.TabIndex = 22;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // qh_hoten
            // 
            this.qh_hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(229, 218);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(158, 21);
            this.qh_hoten.TabIndex = 21;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(27, 152);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số vào viện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label29.Location = new System.Drawing.Point(241, 239);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label28.Location = new System.Drawing.Point(5, 239);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(139, 218);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(5, 217);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(96, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người thân :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(44, 173);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label23.Location = new System.Drawing.Point(153, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(96, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(5, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 23);
            this.label22.TabIndex = 193;
            this.label22.Text = "Lần thứ :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(286, 42);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(16, 21);
            this.nhantu.TabIndex = 2;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(98, 64);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(16, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(4, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 23);
            this.label21.TabIndex = 191;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(228, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 23);
            this.label20.TabIndex = 186;
            this.label20.Text = "Nhận từ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(5, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày giờ vào :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(169, 108);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(21, 21);
            this.makp.TabIndex = 9;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(129, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(2, 8);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(389, 23);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO VIỆN :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(394, 486);
            this.button2.TabIndex = 2454;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(-10, 448);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 218;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(70, 403);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(201, 23);
            this.label55.TabIndex = 207;
            this.label55.Text = "CÁC LẦN VÀO VIỆN :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(72, 106);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 8;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
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
            this.tlblme,
            this.tlbl,
            this.toolStripSeparator4,
            this.tbutvantay,
            this.toolStripSeparator5,
            this.toolStripButton5,
            this.toolStripSeparator6,
            this.toolStripButton6,
            this.toolStripSeparator7,
            this.toolStripButton7});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 23);
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
            this.toolStripButton1.ToolTipText = "Tìm bệnh nhân";
            this.toolStripButton1.Click += new System.EventHandler(this.label48_Click);
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
            this.toolStripButton2.ToolTipText = "Tai nạn,thương tích";
            this.toolStripButton2.Click += new System.EventHandler(this.l_tainantt_Click);
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
            this.toolStripButton3.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton3.Text = "F11";
            this.toolStripButton3.ToolTipText = "Bệnh kèm theo";
            this.toolStripButton3.Click += new System.EventHandler(this.l_kemtheo_Click);
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
            this.toolStripButton4.Size = new System.Drawing.Size(42, 20);
            this.toolStripButton4.Text = "^D";
            this.toolStripButton4.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton4.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // tlblme
            // 
            this.tlblme.ForeColor = System.Drawing.Color.Red;
            this.tlblme.Name = "tlblme";
            this.tlblme.Size = new System.Drawing.Size(0, 0);
            this.tlblme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutvantay
            // 
            this.tbutvantay.Image = ((System.Drawing.Image)(resources.GetObject("tbutvantay.Image")));
            this.tbutvantay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutvantay.Name = "tbutvantay";
            this.tbutvantay.Size = new System.Drawing.Size(39, 20);
            this.tbutvantay.Text = "F5";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Tự sát";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(3, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(388, 486);
            this.button1.TabIndex = 244;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(71, 424);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(228, 80);
            this.treeView1.TabIndex = 245;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // lblvt
            // 
            this.lblvt.AutoSize = true;
            this.lblvt.BackColor = System.Drawing.Color.Transparent;
            this.lblvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblvt.Location = new System.Drawing.Point(6, 491);
            this.lblvt.Name = "lblvt";
            this.lblvt.Size = new System.Drawing.Size(67, 13);
            this.lblvt.TabIndex = 260;
            this.lblvt.Text = "Fingerprint";
            this.lblvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptb
            // 
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.Location = new System.Drawing.Point(0, 0);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(55, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 258;
            this.ptb.TabStop = false;
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(305, 426);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 256;
            this.pic.TabStop = false;
            // 
            // butget_msbn_from_internet
            // 
            this.butget_msbn_from_internet.Location = new System.Drawing.Point(247, 40);
            this.butget_msbn_from_internet.Name = "butget_msbn_from_internet";
            this.butget_msbn_from_internet.Size = new System.Drawing.Size(128, 22);
            this.butget_msbn_from_internet.TabIndex = 271;
            this.butget_msbn_from_internet.Text = "Lấy Mã BN";
            this.butget_msbn_from_internet.UseVisualStyleBackColor = true;
            this.butget_msbn_from_internet.Visible = false;
            this.butget_msbn_from_internet.Click += new System.EventHandler(this.butget_msbn_from_internet_Click);
            // 
            // frmNhanbenh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 549);
            this.Controls.Add(this.butget_msbn_from_internet);
            this.Controls.Add(this.lblvt);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.pnhi);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.ppara);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.psosinh);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNhanbenh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhanbenh_KeyDown);
            this.Load += new System.EventHandler(this.frmNhanbenh_Load);
            this.pnhi.ResumeLayout(false);
            this.pnhi.PerformLayout();
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.psosinh.ResumeLayout(false);
            this.psosinh.PerformLayout();
            this.ppara.ResumeLayout(false);
            this.ppara.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.ddsosinh.ResumeLayout(false);
            this.ddsosinh.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhanbenh_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            mabn3.MaxLength = i_maxlength_mabn - ((bQuanly_Theo_Chinhanh) ? 2 : 4); 
            s_ngaysrv = m.ngayhienhanh_server;
            mame.MaxLength = i_maxlength_mabn - ((bQuanly_Theo_Chinhanh) ? 0 : 2); 
            bTraituyen = m.bTraituyen;
            bSothe_ngay_huong = m.bSothe_ngay_huong;
            traituyen.Enabled  = bTraituyen;
            traituyen.SelectedIndex = 0;
            bSothe_dkkcb = m.bSothe_dkkcb;
            pathImage = m.pathImage;
            bTungay = m.bBHYT_tungay;
            bThongtinNguoithan = m.bThongtinNguoithan;
            tungay.Enabled = bTungay;
            user = m.user; bSothe_mabn = m.bsothe_mabn;
            pic.Visible = m.bHinh;
			pmat.Visible=m.Mabv_so==701424;
			bDenngay_sothe=m.bDenngay_sothe;
			bChandoan=m.bChandoan_icd10;
            bChandoan_kemtheo = m.bChandoan_kemtheo_icd10;
            bChuathanhtoan_khongcho_nhanbenh = m.bChuathanhtoan_khongcho_nhanbenh;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Nhanbenh);
            b_Hoten = m.bHoten_gioitinh;
            phai.SelectedIndex = 0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            songay = m.Ngaylv_Ngayht;
            s_msg = LibMedi.AccessData.Msg;
            m_phainu = LibMedi.AccessData.phainu;
            m_sosinh = LibMedi.AccessData.sosinh;
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			bChuyenkhoasan=m.bChuyenkhoasan;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			tlbl.Text="";tlblme.Text="";
			bMabame=m.bMabame;
			bNhapsoluutru=m.bSoluutru_nhapvien;
			bAdmin=m.bAdmin(i_userid);
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			b_bacsi=m.bsNhanbenh;
            f_load_option();//
            // Thang
            bVantay = m.bVantay;
            if (bVantay) bVantay_mabntudong = m.bVantay_mabntudong;
            else bVantay_mabntudong = false;
            ptb.Visible = bVantay;
            tbutvantay.Visible = bVantay;
            lblvt.Visible = bVantay;
            //
			ppara.Top=371;
			pnhi.Top=282;
			load_dm();
			sovaovien.Enabled=!b_sovaovien;
			cd_kkb.Enabled=m.bChandoan;
			cd_noichuyenden.Enabled=cd_kkb.Enabled;
			cd_kemtheo.Enabled=cd_kkb.Enabled;
			soluutru.Enabled=bNhapsoluutru;
            bTuChoiNhapVienNeuChuaThanhToan = m.bTuChoiNhapVienNeuChuaThanhToan;
            butTiep_Click(null, null);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
			foreach(DataRow r in m.get_data("select distinct b.ten from "+user+".diungthuoc a,"+user+".d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) tlbl.Text+=r["ten"].ToString().Trim()+";";
			//diungthuoc.Checked=lbl.Text!="";
			//if (diungthuoc.Checked) 
            if (tlbl.Text!="")    tlbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
			//l_diungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tainantt()
		{
            //tainantt.Checked=m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tainantt.ForeColor=(tainantt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
            dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
            list.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + user + ".dmnoicapbhyt where hide=0 order by mabv").Tables[0];

			listdstt.DisplayMember="MABV";
			listdstt.ValueMember="TENBV";
            listdstt.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + user + ".dstt where mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

            sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
            if (r_makp != "")
            {
                 string s = r_makp.Replace(",", "','");
                 sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
            if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
			sql+=" order by makp";
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data(sql).Tables[0];
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;
            
            if (r_makp.Length == 3)
            {
                string s_maba = m.get_data("select maba from " + user + ".btdkp_bv where makp='" + r_makp.Substring(0,2) + "'").Tables[0].Rows[0][0].ToString();
                dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=1 and maba in (" + s_maba + ")" + " order by maba").Tables[0];
            }
            else dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=1 order by maba").Tables[0];
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
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];
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

			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			
			ss_tennn_bo.DisplayMember="TENNN";
			ss_tennn_bo.ValueMember="MANN";
            ss_tennn_bo.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			ss_tennn_me.DisplayMember="TENNN";
			ss_tennn_me.ValueMember="MANN";
            ss_tennn_me.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			nhi_tennn_bo.DisplayMember="TENNN";
			nhi_tennn_bo.ValueMember="MANN";
            nhi_tennn_bo.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			nhi_tennn_me.DisplayMember="TENNN";
			nhi_tennn_me.ValueMember="MANN";
            nhi_tennn_me.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			ss_nhommau.DisplayMember="TEN";
			ss_nhommau.ValueMember="MA";
            ss_nhommau.DataSource = m.get_data("select * from " + user + ".dmnhommau").Tables[0];
		}

		private void load_mann(bool btreem)
		{
			if (btreem)
                tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
			else
                tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
            //if (tenba.SelectedValue.ToString()=="BSO")
            //    tendoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where madoituong<>1 order by madoituong").Tables[0];
            //else
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            tendoituong.DataSource = dtdt;//= m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            tendoituong.DisplayMember = "DOITUONG";
            tendoituong.ValueMember = "MADOITUONG";
			if (tendoituong.SelectedIndex!=-1)
			{
				madoituong.Text=tendoituong.SelectedValue.ToString();
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
                if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                else tungay.Enabled = false;
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
                if (bTraituyen) traituyen.Enabled = tenbv.Enabled;
			}
            if (bKhamthai) khamthai.Visible = tenba.SelectedValue.ToString() != "BSO";
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
			tenpxa.DataSource=m.get_data("select * from "+user+".btdpxa where maqu='"+tenquan.SelectedValue.ToString()+"'"+" order by maphuongxa").Tables[0];
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
				if (tenkp.SelectedIndex==-1 && tenkp.Items.Count>0) tenkp.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
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
                maba.Text = tenba.SelectedValue.ToString();
                this.Text = lan.Change_language_MessageText("Nhập viện") + ">" + tenba.Text.Trim() + "< " + lan.Change_language_MessageText("Người cập nhật : ") + s_userid.Trim() + " >";
                DataRow r = m.getrowbyid(dtba, "mavt='" + tenba.SelectedValue.ToString() + "'");
                if (r != null) i_maba = int.Parse(r[0].ToString());
                else i_maba = 0;
                if (i_maba != 0)
                {
                    sql = "select * from " + user + ".btdkp_bv where makp<>'01' and maba like '%" + i_maba.ToString().PadLeft(2, '0') + "%'";
                    if (r_makp != "")
                    {
                        string s = r_makp.Replace(",", "','");
                        sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                    }
                    if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
                    sql += " order by makp";
                    tenkp.DataSource = m.get_data(sql).Tables[0];
                    if (tenkp.Items.Count > 0) tenkp.SelectedIndex = 0;
                }
                phai.Enabled = m_phainu.IndexOf(tenba.SelectedValue.ToString()) == -1;
                load_mann(m_sosinh.IndexOf(tenba.SelectedValue.ToString()) != -1);
                tennn.SelectedIndex = -1;
                if (!phai.Enabled) phai.SelectedIndex = 1;
                load_text();
            }
            catch { }
		}

		private void load_text()
		{
			bSosinh=tenba.SelectedValue.ToString()=="BSO";
			load_sosinh(bSosinh);
			bNhi=(tenba.SelectedValue.ToString()=="BNH" || tenba.SelectedValue.ToString()=="BMT");
			pnhi.Visible=bNhi;
			lcholam.Visible=!pnhi.Visible;
			if (bSosinh) lcholam.Visible=false;
			cholam.Visible=lcholam.Visible;
			bSankhoa=tenba.SelectedValue.ToString()=="BSA";
			bBong=tenba.SelectedValue.ToString()=="BBO";
			bTamthan=tenba.SelectedValue.ToString()=="BTH";
			ltdvh.Visible=bTamthan;
			tdvh.Visible=ltdvh.Visible;
			lbong.Visible=bBong;
			ngaybong.Visible=bBong;
			if (bSosinh)
			{
				tendoituong.SelectedValue="3"; 
				madoituong.Text=tendoituong.SelectedValue.ToString();
			}
		}

		private void load_sosinh(bool ena)
		{
            if (ena) psosinh.Top = 124;
            lmann.Visible=!ena;
            mann.Visible=!ena;
            tennn.Visible=!ena;
            psosinh.Visible=ena;
            phanhchinh.Top=(ena)?215:126;
            ppara.Visible=ena;
            ddsosinh.Visible=ena;
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
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2);
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
					if (bNhi) nhi_hoten_bo.Focus();
					else if (bSosinh)
					{
						ss_nhommau.Focus();
						SendKeys.Send("{F4}");
					}
					else cholam.Focus();
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
				if (ppara.Visible) SendKeys.Send("{Tab}{F4}");
				else SendKeys.Send("{Tab}");
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
							if (bNhi) nhi_hoten_bo.Focus();
							else if (bSosinh)
							{
								ss_nhommau.Focus();
								SendKeys.Send("{F4}");
							}
							else cholam.Focus();
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
			load_btdnn(0);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
            if (mabn3.Text == "") //return;
            {
                if (mabn2.Text == "")
                {
                    mabn2.Focus();
                    return;
                }
                decimal stt = 0;
                if ((bMabn_tudong || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "")
                {
                    for (; ; )
                    {
                        stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                        if (i_chinhanh > 0)
                        {
                            mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                        }
                        else mabn3.Text = stt.ToString().PadLeft(6, '0');
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (m.get_data("select mabn from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                    }
                }
                else if ((bMabn_tudong_theomay  || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "")
                {                   
                    for (; ; )
                    {
                        iCapso = 0;
                        stt = m.get_mabns(int.Parse(mabn2.Text), 0, 0);
                        if (stt != 0)
                        {
                            if (i_chinhanh > 0)
                            {
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');
                            }
                            else mabn3.Text = stt.ToString().PadLeft(6, '0'); 
                            iCapso = 2;
                        }
                        else
                        {
                            if (i_chinhanh > 0)
                            {
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 4, '0');
                            }
                            else mabn3.Text =  m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(6, '0');
                            m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                            iCapso = 1;
                        }
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                        else if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                    }
                }
                else return;
            } 
            if (i_chinhanh > 0)
            {
                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlength_mabn - 4, '0');
            }
            else mabn3.Text = mabn3.Text.PadLeft(6, '0');
			s_mabn=mabn2.Text+mabn3.Text;
            if (bVantay) loadHinhVanTay(s_mabn);
			emp_text(true);
			s_soluutru=get_soluutru(s_mabn);
			soluutru.Text=s_soluutru;
			if (load_mabn())
			{
                string s_chuathanhtoan = m.f_ngaychuathanhtoan(s_mabn);
                if (s_chuathanhtoan != "")
                {
                    if (bChuathanhtoan_khongcho_nhanbenh)
                    {
                        MessageBox.Show(s_chuathanhtoan);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(s_chuathanhtoan);
                    }
                }
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn() && !bAdmin) ena_but(false);
					s_icd_noichuyenden=icd_noichuyenden.Text;
					s_icd_kkb=icd_kkb.Text;
					s_icd_kemtheo=icd_kemtheo.Text;
				}
				if (bAdmin)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Bạn có sửa thông tin hành chính không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
					{
						b_Edit=true;
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
			else treeView1.Visible=true;
		}

		private bool load_mabn()
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
			{
                nam = r["nam"].ToString().Trim();
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
                            pic.Tag = (System.IO.File.Exists(pathImage + "//" + s_mabn + ".bmp")) ? pathImage + "//" + s_mabn + ".bmp" : "0000.bmp";
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
                    }
                    if (error)
                    {
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                        pic.Image = (System.Drawing.Bitmap)map;
                    }
                }
				break;
			}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
			if (ret)
			{
				if (bNhi)
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".hcnhi where mabn='" + s_mabn + "'").Tables[0].Rows)
					{
						nhi_hoten_bo.Text=r["hoten_bo"].ToString();
						nhi_vanhoa_bo.Text=r["vanhoa_bo"].ToString();
						nhi_tennn_bo.SelectedValue=r["mann_bo"].ToString();
						nhi_hoten_me.Text=r["hoten_me"].ToString();
						nhi_vanhoa_me.Text=r["vanhoa_me"].ToString();
						nhi_tennn_me.SelectedValue=r["mann_me"].ToString();
					}
				}
				else if (bSosinh)
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".hcsosinh where mabn='" + s_mabn + "'").Tables[0].Rows)
					{
						mame.Text=r["mame"].ToString();
						ss_hoten_me.Text=r["hoten_me"].ToString();
						ss_ns_me.Text=r["ns_me"].ToString();
						ss_tennn_me.SelectedValue=r["mann_me"].ToString();
						ss_delan.Text=r["delan"].ToString();
						ss_hoten_bo.Text=r["hoten_bo"].ToString();
						ss_ns_bo.Text=r["ns_bo"].ToString();
						ss_tennn_bo.SelectedValue=r["mann_bo"].ToString();
						ss_nhommau.SelectedValue=r["nhommau"].ToString();
						para=r["para"].ToString();
						if (para.Length==8)
						{
							ss_para1.Text=para.Substring(0,2);
							ss_para2.Text=para.Substring(2,2);
							ss_para3.Text=para.Substring(4,2);
							ss_para4.Text=para.Substring(6,2);
						}
						load_me();
					}
				}
			}
			load_treeView();
			load_diungthuoc();
			return ret;
		}

		private void load_vv_maql(bool skip)
		{
			ena_but(true);
			emp_vv();
            foreach (DataRow r in m.get_data("select * from " + user + ".benhandt where loaiba=1 and maql=" + l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
                l_matd = decimal.Parse(r["mavaovien"].ToString());
                tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				makp_save=r["makp"].ToString();
				if (!bAdmin) ena_but(false);
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
			l_maql=0;
			emp_vv();
            foreach (DataRow r in m.get_data("select * from " + user + ".benhandt where loaiba=1 and mabn='" + s_mabn + "'" + " order by ngay desc").Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
                l_matd = decimal.Parse(r["mavaovien"].ToString());
				s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				makp_save=r["makp"].ToString();
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
            foreach (DataRow r in m.get_data("select * from " + user + ".quanhe where maql=" + l_maql).Tables[0].Rows)
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
			}
            if (quanhe.Text == "" && m.bMmyy(m.mmyy(ngayvv.Text)))
            {
                s_mabn = mabn2.Text + mabn3.Text;
                string xxx = user + m.mmyy(ngayvv.Text);
                sql = "select b.* from " + xxx + ".tiepdon a," + xxx + ".quanhe b where a.maql=b.maql and a.mabn='" + s_mabn + "' order by a.maql desc";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    quanhe.Text = r["quanhe"].ToString();
                    qh_hoten.Text = r["hoten"].ToString();
                    qh_diachi.Text = r["diachi"].ToString();
                    qh_dienthoai.Text = r["dienthoai"].ToString();
                }
            }
			string stuoi=m.get_tuoivao(l_maql).Trim();
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
                    foreach (DataRow r in m.get_data("select * from " + user + ".bhyt where maql=" + l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						mabv.Text=r["mabv"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						try
						{
                            if (mabv.Text != "") tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
						}
						catch{}
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        if (bTraituyen) traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					}
				}
			}
			if (bSosinh)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".ddsosinh where maql=" + l_maql).Tables[0].Rows)
				{
					apgar1.Text=(r["apgar1"].ToString()=="0")?"":r["apgar1"].ToString();
					apgar5.Text=(r["apgar5"].ToString()=="0")?"":r["apgar5"].ToString();
					apgar10.Text=(r["apgar10"].ToString()=="0")?"":r["apgar10"].ToString();
					cannang.Text=(r["cannang"].ToString()=="0")?"":r["cannang"].ToString();
					cao.Text=(r["cao"].ToString()=="0")?"":r["cao"].ToString();
					vongdau.Text=(r["vongdau"].ToString()=="0")?"":r["vongdau"].ToString();
				}
			}
			if (khamthai.Visible)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".ttkhamthai where maql=" + l_maql).Tables[0].Rows)
				{
					para1.Text=r["para"].ToString().Substring(0,2);
					para2.Text=r["para"].ToString().Substring(2,2);
					para3.Text=r["para"].ToString().Substring(4,2);
					para4.Text=r["para"].ToString().Substring(6,2);
				}
			}
			if (dentu.Text=="1")
			{
				try
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
					{
						cd_noichuyenden.Text=r["chandoan"].ToString();
						icd_noichuyenden.Text=r["maicd"].ToString();
						madstt.Text=r["mabv"].ToString();
                        tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
					}
				}
				catch{}
			}
			if (pmat.Visible)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".ttmat where maql=" + l_maql).Tables[0].Rows)
				{
					mp.Text=r["mp"].ToString();
					mt.Text=r["mt"].ToString();
					nhanapp.Text=r["nhanapp"].ToString();
					nhanapt.Text=r["nhanapt"].ToString();
					break;
				}
			}
			treeView1.Visible=true;
			try
			{
                if (bTamthan) tdvh.Text = m.get_data("select vanhoa from " + user + ".tttamthan where maql=" + l_maql).Tables[0].Rows[0][0].ToString();
                else if (bBong) ngaybong.Text = m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') from " + user + ".ttbong where maql=" + l_maql).Tables[0].Rows[0][0].ToString();
			}
			catch{}
			s_ngaybong=ngaybong.Text;
            foreach (DataRow r in m.get_data("select * from " + user + ".cdkemtheo where loai=1 and maql=" + l_maql + " order by stt").Tables[0].Rows)
			{
				cd_kemtheo.Text=r["chandoan"].ToString();
				icd_kemtheo.Text=r["maicd"].ToString();
				break;
			}
			if (bNhapsoluutru) soluutru.Text=m.get_soluutru(l_maql).ToString();
			s_icd_noichuyenden=icd_noichuyenden.Text;
			s_icd_kkb=icd_kkb.Text;
			s_icd_kemtheo=icd_kemtheo.Text;
			//binh
			soluutru.Text=s_soluutru;
			//
			load_tainantt();
			load_kemtheo();
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
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
            cholam.Text = cholam.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+');
			cholam.Text=m.Caps(cholam.Text);		
		}

		private void frmNhanbenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F3:
                    label48_Click(null, null);
                    break;
                case Keys.F5:
                    if (bVantay) lay_mabn_vantay();
                    break;
				case Keys.F9:
					l_tainantt_Click(sender,e);
					break;
				case Keys.F11:
					l_kemtheo_Click(sender,e);
					break;
				case Keys.F10:
					butKetthuc_Click(sender,e);
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
						break;
						//tien: them tim BN					
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
                if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                else tungay.Enabled = false;
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
                if (bTraituyen) traituyen.Enabled = tenbv.Enabled;
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
                    if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                    else tungay.Enabled = false;
					mabv.Enabled=so.Substring(3,1)=="1";
					tenbv.Enabled=mabv.Enabled;
                    if (bTraituyen) traituyen.Enabled = tenbv.Enabled;
				}
				catch{tendoituong.SelectedIndex=0;}
			}
		}

		private void load_bhyt()
		{
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0 && ngayvv.Text!="")
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (so.Substring(2,1)=="1"  && bDenngay_sothe)
                    sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','"+m.f_ngay+"')" + " order by maql desc";
				else
                    sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
                    if (bTungay && r["tungay"].ToString() != "")
                        tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (so.Substring(3,1)=="1") mabv.Text=r["mabv"].ToString();
                    if (bSothe_ngay_huong)
                    {
                        if (r["ngay1"].ToString() != "")
                            ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                        if (r["ngay2"].ToString() != "")
                            ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                        if (r["ngay3"].ToString() != "")
                            ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                    }
                    if (bTraituyen) traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					break;
				}
                if (sothe.Text == "" && nam != "")
                {
                    if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                        sql = "select * from xxx.bhyt where mabn='" + s_mabn + "' and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                    else
                        sql = "select * from xxx.bhyt where mabn='" + s_mabn + "' order by maql desc";
                    DataSet dstmp=m.get_data_nam_dec(nam, sql);
                    if (dstmp != null)
                    {
                        foreach (DataRow r in dstmp.Tables[0].Rows)
                        {
                            sothe.Text = r["sothe"].ToString();
                            if (bTungay && r["tungay"].ToString() != "")
                                tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                            if (r["denngay"].ToString() != "")
                                denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                            if (so.Substring(3, 1) == "1") mabv.Text = r["mabv"].ToString();
                            if (bSothe_ngay_huong)
                            {
                                if (r["ngay1"].ToString() != "")
                                    ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                                if (r["ngay2"].ToString() != "")
                                    ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                                if (r["ngay3"].ToString() != "")
                                    ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                            }
                            if (bTraituyen) traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                            break;
                        }
                    }
                }
				try
				{
					if (mabv.Text=="" && so.Substring(3,1)=="1") mabv.Text=m.Mabv;
					tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
				}
				catch{}
			}
			else
			{
				tungay.Text=sothe.Text=denngay.Text=mabv.Text=tenbv.Text="";
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
					else icd_kkb.Focus();
					SendKeys.Send("{Home}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void quanhe_Validated(object sender, System.EventArgs e)
		{
			quanhe.Text=m.Caps(quanhe.Text);
			if (ss_hoten_me.Visible || nhi_hoten_bo.Visible)
			{
				if ((quanhe.Text==lan.Change_language_MessageText("Mẹ")) && (ss_hoten_me.Text!="" || nhi_hoten_me.Text!=""))
					qh_hoten.Text=(ss_hoten_me.Visible)?ss_hoten_me.Text:nhi_hoten_me.Text;
				else if ((quanhe.Text==lan.Change_language_MessageText("Bố")) && (ss_hoten_bo.Text!="" || nhi_hoten_bo.Text!=""))
					qh_hoten.Text=(ss_hoten_bo.Visible)?ss_hoten_bo.Text:nhi_hoten_bo.Text;
			}
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

		private void cd_kkb_Validated(object sender, System.EventArgs e)
		{
			if (icd_kkb.Text=="") icd_kkb.Text=m.get_cicd10(cd_kkb.Text);
			if (!m.bMaicd(icd_kkb.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_kkb.Text="";
				icd_kkb.Focus();
			}
		}

		private void icd_kkb_Validated(object sender, System.EventArgs e)
		{
			if (icd_kkb.Text!=s_icd_kkb)
			{
				if (icd_kkb.Text=="") cd_kkb.Text="";
				else cd_kkb.Text=m.get_vviet(icd_kkb.Text);
				if (cd_kkb.Text=="" && icd_kkb.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kkb.Text, cd_kkb.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_kkb.Text=f.mTen;
						icd_kkb.Text=f.mICD;
					}
				}
				s_icd_kkb=icd_kkb.Text;
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
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kemtheo.Text, cd_kemtheo.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_kemtheo.Text=f.mTen;
						icd_kemtheo.Text=f.mICD;
					}
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
            catch { }
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (sothe.Text != "")
            {
                if (bSothe_dkkcb)
                {
                    if (sothe.Text.Trim().Length == _dai && _vitri != 0 && _sothe != "")
                    {
                        mabv.Text = sothe.Text.Substring(_vitri - 1, _sothe.Length);
                        try
                        {
                            tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                        }
                        catch { }
                    }

                    if (sothe.Text.Trim().Length >= 18 && (tenbv.Text == "" || sothe.Text.Trim().Substring(sothe.Text.Trim().Length - 5) != mabv.Text))
                    {
                        mabv.Text = sothe.Text.Trim().Substring(sothe.Text.Trim().Length - 5);
                        try
                        {
                            tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                        }
                        catch { }
                    }
                }
            }
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
			loaituoi.SelectedIndex=0;
			makp_save="";
			hoten.Text="";
			ngaysinh.Text="";
			namsinh.Text="";
			tuoi.Text="";
			sonha.Text="";
			thon.Text="";
			cholam.Text="";
			tentqx.SelectedIndex=-1;
			tqx.Text="";
			l_maql=0;
            l_matd = 0;
			tlblme.Text="";
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Visible=true;
			treeView1.Nodes.Clear();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			if (bSosinh)
			{
				ss_hoten_bo.Text="";
				ss_ns_bo.Text="";
				ss_tennn_bo.SelectedIndex=-1;
				ss_delan.Text="";
				ss_para1.Text="";
				ss_para2.Text="";
				ss_para3.Text="";
				ss_para4.Text="";
				mame.Text="";
				ss_hoten_me.Text="";
				ss_ns_me.Text="";
				ss_tennn_me.SelectedIndex=-1;
				tendoituong.SelectedValue="3";
				madoituong.Text=tendoituong.SelectedValue.ToString();
				apgar1.Text="";apgar5.Text="";apgar10.Text="";
				cannang.Text="";cao.Text="";vongdau.Text="";

			}
			else if (bNhi)
			{
				nhi_hoten_bo.Text="";
				nhi_hoten_me.Text="";
				nhi_vanhoa_bo.Text="";
				nhi_vanhoa_me.Text="";
				nhi_tennn_bo.SelectedIndex=-1;
				nhi_tennn_me.SelectedIndex=-1;
			}
			tdvh.Text="";
			ngaybong.Text="";
			s_ngaybong="";
            if (pic.Visible)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                pic.Image = (System.Drawing.Bitmap)map;
            }
		}

		private void emp_bhyt()
		{
            ngay1=ngay2=ngay3=sothe.Text = denngay.Text = mabv.Text = tenbv.Text = "";
            traituyen.SelectedIndex = 0;
		}

		private void emp_vv()
		{
            string s = m.Ngaygio;
            ngayvv.Text = s.Substring(0, 10);
            giovv.Text = s.Substring(11);
			s_ngayvv="";
			tendentu.SelectedIndex=-1;
			tennhantu.SelectedIndex=-1;
			tendoituong.SelectedIndex=-1;
			madoituong.Text="";
			lanthu.Text="1";
			quanhe.Text="";
			qh_hoten.Text="";
			qh_diachi.Text="";
			qh_dienthoai.Text="";
			sovaovien.Text="";
			soluutru.Text=s_soluutru;
			cd_noichuyenden.Text="";
			icd_noichuyenden.Text="";
			madstt.Text="";
			tendstt.Text="";
			cd_kkb.Text="";
			icd_kkb.Text="";
			cd_kemtheo.Text="";
			icd_kemtheo.Text="";
			mabs.Text="";
			tenbs.Text="";
			s_icd_noichuyenden="";
			s_icd_kkb="";
			s_icd_kemtheo="";
			para1.Text="";para2.Text="";para3.Text="";para4.Text="";
			if (pmat.Visible)
			{
				mabs.Text="";tenbs.Text="";
				mp.Text="";mt.Text="";
				nhanapp.Text="";nhanapt.Text="";
			}
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			s_soluutru="";
            ptb.Image = null;
            ptb.Refresh();
            fnhandang = null;
			emp_text(false);
			mabn2.Focus();
		}
        private void loadHinhVanTay(string mabn)
        {
            System.IO.FileStream fstr;
            byte[] image;
            System.Drawing.Bitmap map;
            ptb.Image = null;
            if (fnhandang == null) fnhandang = new FingerApp.FrmNhanDang(ptb);
            ptb.Image = fnhandang.getImageFromMabn(mabn);
            if (ptb.Image == null)
            {
                ptb.Tag = "x.bmp";
                fstr = new System.IO.FileStream(ptb.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                ptb.Image = (System.Drawing.Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                ptb.Tag = image;
            }
            ptb.Refresh();
        }
        private void luu_vantay()
        {
            try
            {
                string ma = mabn2.Text + mabn3.Text;
                fnhandang.save_orac(ma);
            }
            catch { }
        }
		private bool kiemtra()
		{
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
			}

			if (bSosinh) tennn.SelectedIndex=0;
			else
			{
				if (tennn.SelectedIndex==-1 || mann.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
					mann.Focus();
					return false;
				}
			}
			if (!phai.Enabled) phai.SelectedIndex=1;

			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
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

			if (tendantoc.SelectedIndex==-1 || madantoc.Text=="")
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

			if (tenkp.SelectedIndex==-1 || makp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"),s_msg);
				tenkp.Focus();
				return false;
			}
            //
            string s_chuathanhtoan = m.f_ngaychuathanhtoan(s_mabn);
            if (s_chuathanhtoan != "")
            {
                if (bChuathanhtoan_khongcho_nhanbenh)
                {
                    MessageBox.Show(s_chuathanhtoan);
                    return false;
                }
                else
                {
                    MessageBox.Show(s_chuathanhtoan);
                }
            }
            //
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;

			if (dentu.Text=="1")
			{
				if (madstt.Text=="" || tendstt.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên cơ quan y tế !"),s_msg);
					madstt.Focus();
					return false;
				}
				if (icd_noichuyenden.Text=="" && cd_noichuyenden.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"),s_msg);
					icd_noichuyenden.Focus();
					return false;
				}
				else if (cd_noichuyenden.Text=="" && icd_noichuyenden.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán nơi chuyển đến !"),s_msg);
					if(cd_noichuyenden.Enabled) cd_noichuyenden.Focus();
					else icd_noichuyenden.Focus();
					return false;
				}
                if (bChandoan_kemtheo)
                {
                    if (!m.Kiemtra_maicd(dticd, icd_noichuyenden.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                        icd_noichuyenden.Focus();
                        return false;
                    }
                    if (!m.Kiemtra_tenbenh(dticd, cd_noichuyenden.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                        cd_noichuyenden.Focus();
                        return false;
                    }
                }
			}

			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngaysinh.Focus();
				return false;
			}
            try
            {
                if (bThongtinNguoithan && (quanhe.Text.Trim() == "" || qh_hoten.Text.Trim() == "") && int.Parse(s_ngaysrv.Substring(6, 4)) - int.Parse(namsinh.Text.Trim()) <= 6)
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

            if (loaituoi.SelectedIndex == 0 && tuoi.Text != "")
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
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào viện !"),s_msg);
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

			if (tendoituong.SelectedIndex==-1 || madoituong.Text=="")
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
                    else if (!m.sothe(int.Parse(tendoituong.SelectedValue.ToString()), sothe.Text)) 
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
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
				}
			}

			if (lanthu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập vào viện do bệnh này lần thứ !"),s_msg);
				lanthu.Focus();
				return false;
			}

			if (!b_sovaovien && sovaovien.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số vào viện !"),s_msg);
				sovaovien.Focus();
				return false;
			}

			if (icd_kkb.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD vào khoa khám bệnh !"),s_msg);
				icd_kkb.Focus();
				return false;
			}

			if (cd_kkb.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán vào khoa khám bệnh !"),s_msg);
				if (cd_kkb.Enabled) cd_kkb.Focus();
				else icd_kkb.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,icd_kkb.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				icd_kkb.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_kkb.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				cd_kkb.Focus();
				return false;
			}
			if (icd_kemtheo.Text=="" && cd_kemtheo.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh kèm theo !"),s_msg);
				icd_kemtheo.Focus();
				return false;
			}
			else if (cd_kemtheo.Text=="" && icd_kemtheo.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh kèm theo !"),s_msg);
				if (cd_kemtheo.Enabled) cd_kemtheo.Focus();
				else icd_kemtheo.Focus();
				return false;
			}
            if (bChandoan_kemtheo)
            {
                if (!m.Kiemtra_maicd(dticd, icd_kemtheo.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                    icd_kemtheo.Focus();
                    return false;
                }
                if (!m.Kiemtra_tenbenh(dticd, cd_kemtheo.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                    cd_kemtheo.Focus();
                    return false;
                }
            }
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
				mabs.Focus();
				return false;
			}
			if (bSosinh)
			{
				if (bMabame)
				{
					if (mame.Text=="" || ss_hoten_me.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập mã mẹ !"),s_msg);
						mame.Focus();
						return false;
					}
				}
				else
				{
					if (ss_hoten_me.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập tên mẹ !"),s_msg);
						ss_hoten_me.Focus();
						return false;
					}
				}
				para=ss_para1.Text+ss_para2.Text+ss_para3.Text+ss_para4.Text;
				if (ss_delan.Text=="" || ss_delan.Text=="0")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập đẻ lần mấy !"),s_msg);
					ss_delan.Focus();
					return false; 
				}
				if (para=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tiền thai (Para) !"),s_msg);
					ss_para1.Focus();
					return false;
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
			if (khamthai.Visible)
			{
				if (phai.SelectedIndex==0 && (para1.Text+para2.Text+para3.Text+para4.Text!=""))
				{
					MessageBox.Show(lan.Change_language_MessageText("Giới tính không hợp lệ !"),s_msg);
					phai.Focus();
					return false;
				}
			}
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text),i_userid);
			if (ngayvv.Text+" "+giovv.Text!=s_ngayvv)
			{
				l_maql=m.get_maql(1,s_mabn,"??",ngayvv.Text+" "+giovv.Text,false);
				if (l_maql==0)
				{
                    if (m.bTuvong(mabn2.Text + mabn3.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                        butBoqua_Click(null, null);
                    }
                    l_maql = m.get_maql_ngay(1, s_mabn, "??", ngayvv.Text + " " + giovv.Text);
					if (l_maql!=0)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã được nhận bệnh,")+"\n"+lan.Change_language_MessageText("Bạn có muốn xem lại !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo)==DialogResult.Yes) 
						{
							load_vv_maql(false);
							if (!bAdmin) ena_but(false);
							return false;
						}
					}
					string s_tenkp=m.bHiendien(s_mabn,1);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được,phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,1);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
							return false;
						}
					}
					if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0,10)),DateTime.Now,songay))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
						s_ngayvv="";
						ngayvv.Focus();
						return false;
					}
				}
			}
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = m.mabn_bhyt_ngayhethan(mabn2.Text + mabn3.Text, sothe.Text,denngay.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ") + " " + sothe.Text + "\n" + lan.Change_language_MessageText("Đã có mã người bệnh nội trú:") + " " + s + "\n" + lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }

                    s = m.mabn_bhyt("", mabn2.Text + mabn3.Text, sothe.Text, ngayvv.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ") + " " + sothe.Text + "\n" + lan.Change_language_MessageText("Đã có mã người bệnh :") + " " + s + "\n" + lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
            if (soluutru.Enabled && soluutru.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập số lưu trữ !"), s_msg);
                soluutru.Focus();
                return false;
            }
            if (bTuChoiNhapVienNeuChuaThanhToan)
            {               
              DataSet dtnam = m.get_data("select nam from " + user + ".btdbn where mabn='" + mabn2.Text + mabn3.Text + "'");//.Tables[0];

                string s_mmyy = "";
                if (dtnam != null && dtnam.Tables.Count > 0 && dtnam.Tables[0].Rows.Count > 0)
                {
                    s_mmyy = dtnam.Tables[0].Rows[0]["nam"].ToString();                    
                }
                if (s_mmyy != "")
                {
                    string s_sql = " select paid as temp from xxx.v_chidinh where mabn='" + mabn2.Text + mabn3.Text + "' and paid = 0";
                    s_sql += " union all select done as temp from xxx.d_tienthuoc where mabn='" + mabn2.Text + mabn3.Text + "' and done = 0 ";
                    DataSet ds_nam = new DataSet();
                    ds_nam = m.get_data_nam(s_mmyy, s_sql);
                    if (ds_nam.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText(" Trong các lần nhận bệnh trước do chưa thanh toán viện phí nên lần này không được phép nhận bệnh nữa !"), s_msg);
                        butTiep_Click(null, null);
                        mabn3.Focus();
                        return false;
                    }
                }
            }
            if (bnKhamBHYTmotlantrongngay && madoituong.Text == "1")
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
			return true;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_mabn"></param>
        /// <param name="m_ngay"></param>
        /// <returns>1 Vua kham xong trong ngay, 2 vua ra cung ngay dieu tri noi tru, ngoai tru ,</returns>
        private int f_kiemtrabndakhamtrongngay(string m_mabn, string m_ngay)
        {
            string s_sql = "";
            s_sql = " select  mabn from xxx.bhytkb where mabn='" + m_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngay + "'";
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
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (bVantay && ma_vantay == "") luu_vantay();
            if (!kiemtra()) return;
			s_mabn=mabn2.Text+mabn3.Text;
            int itable = m.tableid("","benhandt");
            if (m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + lanthu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_kkb.Text + "^" + icd_kkb.Text + "^" + mabs.Text + "^" + sovaovien.Text + "^" + "1" + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, true);
			if (makp.Text!=makp_save && makp_save!="")
			{
				if (m.get_nhapkhoa(l_maql))
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã nhập khoa không thể sửa phần vào khoa !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            //kiểm tra hiện diện phòng lưu thì không cho nhập viện
            string sql = "select c.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
            sql += " b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp";
            sql += " from xxx.benhancc a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp";
            sql += " where a.mabn='" + s_mabn + "' and a.ngayrv is null";
            sql += " order by a.makp,a.ngay desc";
            string s_nam = DateTime.Now.Year.ToString();
            string s_namtruoc = Convert.ToString(DateTime.Now.Year - 1);
            DataSet dstemp = m.get_data_yy(s_namtruoc, sql);

            if (dstemp != null && dstemp.Tables.Count > 0 && dstemp.Tables[0].Rows.Count > 0)
            {
                dstemp.Merge(m.get_data_yy(s_nam, sql));

            }
            else
            {
                dstemp=(m.get_data_yy(s_nam, sql));
            }

            if (dstemp != null && dstemp.Tables.Count > 0 && dstemp.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đang hiện diện phòng lưu không cho phép nhập viện!\n Đề nghị cho BN ra phòng lưu trước khi nhập viện."), LibMedi.AccessData.Msg);
                return;
            }
            //kiểm tra hiện diện ngoại trú
            sql = "select c.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
            sql += " b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,";
            sql += "date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1) as ngaydt ";
            sql += ", bh.sothe, case when bh.traituyen is null then 0 else bh.traituyen end as traituyen ";
            sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp";
            sql += " left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null)";
            sql += " where a.ttlucrv=0 and a.ngayrv is null";
            sql += " and a.mabn='" + s_mabn + "'";
            dstemp = m.get_data(sql);
            if (dstemp != null && dstemp.Tables.Count > 0 && dstemp.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đang hiện diện trong bệnh án ngoại trú")+ "\n" + lan.Change_language_MessageText("Bạn có muốn cho BN nhập viện không?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon_ngaygio(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Nhanbenh, 0);
                    }
                }
                if (l_matd == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được phân quyền để nhập bệnh nhân mới, đề nghị liện hệ phòng máy tính."));
                    return;
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Nhanbenh, l_maql);
            }
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (bNhapsoluutru) m.upd_soluutru(l_maql,soluutru.Text);
			if (!m.upd_benhandt(s_mabn,l_matd,l_maql,makp.Text,ngayvv.Text+" "+giovv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),int.Parse(lanthu.Text),int.Parse(tendoituong.SelectedValue.ToString()),cd_kkb.Text,icd_kkb.Text,mabs.Text,sovaovien.Text,1,i_userid,true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
            if (m.get_data("select * from " + m.user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã ra viện."));
                butBoqua_Click(null, null);
                return;
            }
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,mabv.Text,0,tungay.Text,ngay1,ngay2,ngay3,traituyen.SelectedIndex))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}

            if (cd_noichuyenden.Text != "" || madstt.Text.Trim()!="")
			{
				if (!m.upd_noigioithieu(l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}

			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
            else m.execute_data("delete from " + user + ".nuocngoai where mabn='" + s_mabn + "'");

			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
            else m.execute_data("delete from " + user + ".cdkemtheo where stt=1 and loai=1 and maql=" + l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
            if (pmat.Visible) m.upd_ttmat(l_maql, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
			upd_khac();
			//Binh: cap nhat hiendien:07/07/2005
            //
            
            //
			if (makp.Text!=makp_save)//Khi sua:
			{
				decimal tmpid=m.get_id_hiendien_do_cdvv(s_mabn,l_maql,"01");
                decimal l_idhiendien = (tmpid == 0) ? m.get_id(l_maql, makp.Text, ngayvv.Text + " " + giovv.Text) : tmpid;//tinh them gio
                m.upd_hiendien(l_idhiendien, s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, ngayvv.Text + " " + giovv.Text, "", mabs.Text,icd_kkb.Text, "01", 0, 0);
			}
			//
			try
			{
                if (sovaovien.Text == "") sovaovien.Text = m.get_data("select sovaovien from " + user + ".benhandt where loaiba=1 and maql=" + l_maql).Tables[0].Rows[0][0].ToString();
			}
			catch{}
            //quan ly doi tuong bo doi
            try
            {
                DataRow r = m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue.ToString());
                if (r["bodoi"].ToString() == "1")
                {
                    frmDoiTuongBoDoi f = new frmDoiTuongBoDoi(m, s_mabn, hoten.Text, tuoi.Text, ((sonha.Text == "") ? "" : sonha.Text + ", ") + ((thon.Text == "") ? "" : thon.Text + ", ") + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, l_matd, false);
                    f.ShowDialog();
                }
            }
            catch { }
			if (sender!=null)
			{
				ena_but(false);
				butTiep.Focus();
			}
		}

		private void upd_khac()
		{
			if (bSosinh)
			{
				m.upd_hcsosinh(s_mabn,ss_hoten_me.Text,ss_ns_me.Text,ss_mann_me.Text,int.Parse(ss_delan.Text),ss_hoten_bo.Text,ss_ns_bo.Text,ss_mann_bo.Text,int.Parse(ss_nhommau.SelectedValue.ToString()),para,mame.Text);
				m.upd_ddsosinh(s_mabn,l_maql,(apgar1.Text!="")?int.Parse(apgar1.Text):0,(apgar5.Text!="")?int.Parse(apgar5.Text):0,(apgar10.Text!="")?int.Parse(apgar10.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,(cao.Text!="")?int.Parse(cao.Text):0,(vongdau.Text!="")?int.Parse(vongdau.Text):0,"","",1,"",1,0,0,"","",0);
			}
			else if (bBong && ngaybong.Text!="") m.upd_ttbong(l_maql,ngaybong.Text);
			else if (bTamthan && tdvh.Text!="") m.upd_tttamthan(l_maql,tdvh.Text);
			else if (bNhi) m.upd_hcnhi(s_mabn,nhi_hoten_bo.Text,nhi_vanhoa_bo.Text,nhi_mann_bo.Text,nhi_hoten_me.Text,nhi_vanhoa_me.Text,nhi_mann_me.Text);
		}
		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			butTiep_Click(null,null);
		}

		private void nhantu_TextChanged(object sender, System.EventArgs e)
		{
			nhantu.Text=nhantu.Text;
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
			TreeNode node;
            foreach (DataRow r in m.get_data("select ngay,chandoan from " + user + ".benhandt where loaiba=1 and tuchoi=0 and mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
				node.Nodes.Add(r["chandoan"].ToString());
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					string ngay=s.Substring(iPos-2,16);
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql(1,s_mabn,"??",ngay,false);
					if (l_maql!=0)
					{
						load_vv_maql(true);
                        ngayvv.Text = ngay.Substring(0, 10);
                        giovv.Text = ngay.Substring(11);
					}
				}
				catch{}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
		}

		private void sovaovien_Validated(object sender, System.EventArgs e)
		{
			if (sovaovien.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số vào viện !"),s_msg);
				sovaovien.Focus();
				return;
			}
			if (m.blSovaovien(1,sovaovien.Text,l_maql))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số vào viện này đã có !"),s_msg);
				sovaovien.Focus();
				return;
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
				if (b_bacsi)
				{
                    dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") and mapk='" + makp.Text + "'" + " order by ma").Tables[0];
					if (dtbs.Rows.Count==0)
                        dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				}
                else dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
				listBS.DataSource=dtbs;
			}
			catch{makp.Text="";}
		}

		private void ngaybong_Validated(object sender, System.EventArgs e)
		{
			if (ngaybong.Text=="") return;
			ngaybong.Text=ngaybong.Text.Trim();
			if (ngaybong.Text!=s_ngaybong)
			{
				if (ngaybong.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập thời gian bị bỏng !"),s_msg);
					ngaybong.Focus();
					return;
				}
				if (!m.bNgay(ngaybong.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngaybong.Focus();
					return;
				}
				ngaybong.Text=m.Ktngaygio(ngaybong.Text,16);
                if (!m.bNgaygio(ngayvv.Text + " " + giovv.Text, ngaybong.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Thời gian bị bỏng không được lớn hơn ngày vào khoa !"),s_msg);
					ngaybong.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngaybong.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Thời gian bị bỏng không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngaybong.Focus();
					return;
				}
			}
		}

		private void ss_nhommau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (ss_nhommau.SelectedIndex==-1) ss_nhommau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ss_para1_Validated(object sender, System.EventArgs e)
		{
			ss_para1.Text=ss_para1.Text.PadLeft(2,'0');
		}

		private void ss_para2_Validated(object sender, System.EventArgs e)
		{
			ss_para2.Text=ss_para2.Text.PadLeft(2,'0');
		}

		private void ss_para3_Validated(object sender, System.EventArgs e)
		{
			ss_para3.Text=ss_para3.Text.PadLeft(2,'0');
		}

		private void ss_para4_Validated(object sender, System.EventArgs e)
		{
			ss_para4.Text=ss_para4.Text.PadLeft(2,'0');
            //if (ss_para1.Text+ss_para2.Text+ss_para3.Text+ss_para4.Text=="00000000")
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Tiền thai (Para) không hợp lệ !"),s_msg);
            //    ss_para1.Focus();
            //}
		}

		private void ss_hoten_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				ss_hoten_me.Text=m.Viettat(ss_hoten_me.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ss_hoten_me_Validated(object sender, System.EventArgs e)
		{
//			if (ss_hoten_me.Text=="")
//			{
//				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên mẹ !"),s_msg);
//				ss_hoten_me.Focus();
//				return;
//			}
//			ss_hoten_me.Text=m.Caps(ss_hoten_me.Text);
		}

		private void ss_ns_me_Validated(object sender, System.EventArgs e)
		{
			if (ss_ns_me.Text=="") return;
			if (ss_ns_me.Text.Length<4) ss_ns_me.Text=Convert.ToString(DateTime.Now.Year-int.Parse(ss_ns_me.Text));
			if (namsinh.Text!="")
			{
				if (int.Parse(ss_ns_me.Text)>int.Parse(namsinh.Text)-12)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ss_ns_me.Focus();
					return;
				}
			}
		}

		private void ss_mann_me_Validated(object sender, System.EventArgs e)
		{
			try
			{
				ss_tennn_me.SelectedValue=ss_mann_me.Text;
			}
			catch{}
		}

		private void ss_mann_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ss_tennn_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (ss_tennn_me.SelectedIndex==-1) ss_tennn_me.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ss_tennn_me_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ss_mann_me.Text=ss_tennn_me.SelectedValue.ToString();
			}
			catch{ss_mann_me.Text="";}
		}

		private void ss_hoten_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				ss_hoten_bo.Text=m.Viettat(ss_hoten_bo.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ss_hoten_bo_Validated(object sender, System.EventArgs e)
		{
			if (ss_hoten_bo.Text=="")
			{
				ss_tennn_bo.SelectedIndex=-1;
				ss_ns_bo.Text="";
				madantoc.Focus();
			}
			else ss_hoten_bo.Text=m.Caps(ss_hoten_bo.Text);
		}

		private void ss_ns_bo_Validated(object sender, System.EventArgs e)
		{
			if (ss_ns_bo.Text=="") return;
			if (ss_ns_bo.Text.Length<4) ss_ns_bo.Text=Convert.ToString(DateTime.Now.Year-int.Parse(ss_ns_bo.Text));
			if (namsinh.Text!="")
			{
				if (int.Parse(ss_ns_bo.Text)>int.Parse(namsinh.Text)-12)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ss_ns_bo.Focus();
					return;
				}
			}
		}

		private void ss_mann_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ss_mann_bo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				ss_tennn_bo.SelectedValue=ss_mann_bo.Text;
			}
			catch{}
		}

		private void ss_tennn_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (ss_tennn_bo.SelectedIndex==-1) ss_tennn_bo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ss_tennn_bo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ss_mann_bo.Text=ss_tennn_bo.SelectedValue.ToString();
			}
			catch{ss_mann_bo.Text="";}
		}

		private void nhi_hoten_bo_Validated(object sender, System.EventArgs e)
		{
			if (nhi_hoten_bo.Text=="")
			{
				nhi_vanhoa_bo.Text="";
				nhi_tennn_bo.SelectedIndex=-1;
				nhi_hoten_me.Focus();
			}
			else nhi_hoten_bo.Text=m.Caps(nhi_hoten_bo.Text);		
		}

		private void nhi_hoten_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				nhi_hoten_bo.Text=m.Viettat(nhi_hoten_bo.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhi_vanhoa_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhi_vanhoa_bo_Validated(object sender, System.EventArgs e)
		{
			nhi_vanhoa_bo.Text=m.Caps(nhi_vanhoa_bo.Text);
		}

		private void nhi_mann_bo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				nhi_tennn_bo.SelectedValue=nhi_mann_bo.Text;
			}
			catch{}
		}

		private void nhi_mann_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void nhi_tennn_bo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{	
			if (e.KeyCode==Keys.Enter)
			{
				if (nhi_tennn_bo.SelectedIndex==-1) nhi_tennn_bo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}	

		private void nhi_tennn_bo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				nhi_mann_bo.Text=nhi_tennn_bo.SelectedValue.ToString();
			}
			catch{nhi_mann_bo.Text="";}
		}

		private void nhi_hoten_me_Validated(object sender, System.EventArgs e)
		{
			if (nhi_hoten_me.Text=="")
			{
				nhi_vanhoa_me.Text="";
				nhi_tennn_me.SelectedIndex=-1;
				ngayvv.Focus();
				SendKeys.Send("{Home}");
			}
			else nhi_hoten_me.Text=m.Caps(nhi_hoten_me.Text);
		}

		private void nhi_hoten_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				nhi_hoten_me.Text=m.Viettat(nhi_hoten_me.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhi_vanhoa_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhi_vanhoa_me_Validated(object sender, System.EventArgs e)
		{
			nhi_vanhoa_me.Text=m.Caps(nhi_vanhoa_me.Text);
		}

		private void nhi_mann_me_Validated(object sender, System.EventArgs e)
		{
			try
			{
				nhi_tennn_me.SelectedValue=nhi_mann_me.Text;
			}
			catch{}
		}

		private void nhi_mann_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void nhi_tennn_me_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (nhi_tennn_me.SelectedIndex==-1) nhi_tennn_me.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void nhi_tennn_me_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				nhi_mann_me.Text=nhi_tennn_me.SelectedValue.ToString();
			}
			catch{nhi_mann_me.Text="";}
		}

		private void lanthu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (lanthu.Text=="" || lanthu.Text=="0") lanthu.Text="1";
			}
			catch{lanthu.Text="1";}
		}

		private void ss_delan_Validated(object sender, System.EventArgs e)
		{
			if (ss_delan.Text=="" || ss_delan.Text=="0") ss_delan.Text="1";
		}

        //private void load_tiepdon(string m_ngay,bool skip)
        //{
        //    if (!m.bMmyy(m.mmyy(m_ngay))) return;
        //    string xxx = user + m.mmyy(m_ngay);
        //    sql="select * from "+xxx+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
        //    sql+=" order by ngay desc";
        //    foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
        //    {
        //        if (skip)
        //        {
        //            s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
        //            ngayvv.Text = s_ngayvv.Substring(0, 10);
        //            giovv.Text = s_ngayvv.Substring(11);
        //        }
        //        l_matd = decimal.Parse(r["maql"].ToString());
        //        tendoituong.SelectedValue=r["madoituong"].ToString();
        //        madoituong.Text=r["madoituong"].ToString();
        //        //sovaovien.Text=r["sovaovien"].ToString();
        //        string stuoi=r["tuoivao"].ToString();
        //        if (stuoi.Length==4)
        //        {
        //            tuoi.Text=stuoi.Substring(0,3);
        //            loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
        //        }
        //        l_maql=decimal.Parse(r["maql"].ToString());
        //        break;
        //    }
        //    if (l_maql!=0)
        //    {
        //        emp_bhyt();
        //        foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
        //        {
        //            quanhe.Text=r["quanhe"].ToString();
        //            qh_hoten.Text=r["hoten"].ToString();
        //            qh_diachi.Text=r["diachi"].ToString();
        //            qh_dienthoai.Text=r["dienthoai"].ToString();
        //        }
        //        string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
        //        if (int.Parse(so.Substring(0,2))>0)
        //        {
        //            foreach(DataRow r in m.get_data("select * from "+xxx+".bhyt where maql="+l_maql).Tables[0].Rows)
        //            {
        //                sothe.Text=r["sothe"].ToString();
        //                if (bTungay && r["tungay"].ToString() != "")
        //                    tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
        //                if (r["denngay"].ToString()!="")
        //                    denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
        //                mabv.Text = r["mabv"].ToString();
        //                if (mabv.Text!="") tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
        //                if (bSothe_ngay_huong)
        //                {
        //                    if (r["ngay1"].ToString() != "")
        //                        ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
        //                    if (r["ngay2"].ToString() != "")
        //                        ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
        //                    if (r["ngay3"].ToString() != "")
        //                        ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
        //                }
        //                if (bTraituyen) traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
        //            }
        //        }
        //        if (khamthai.Visible)
        //        {
        //            foreach(DataRow r in m.get_data("select * from "+xxx+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
        //            {
        //                para1.Text=r["para"].ToString().Substring(0,2);
        //                para2.Text=r["para"].ToString().Substring(2,2);
        //                para3.Text=r["para"].ToString().Substring(4,2);
        //                para4.Text=r["para"].ToString().Substring(6,2);
        //            }
        //        }
        //    }
        //}
        private void load_tiepdon(string m_ngay, bool skip)
        {
            if (!m.bMmyy(m.mmyy(m_ngay))) return;
            string xxx = user + m.mmyy(m_ngay);
            sql = "select a.mabn, a.maql, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, a.ngay, a.madoituong, a.tuoivao ";
            sql += ", case when c.maql is null then to_number('0') else to_number('1') end as daxuatvien ";
            sql += " from " + xxx + ".tiepdon a left join medibv.benhandt b on a.mabn=b.mabn and a.mavaovien=b.mavaovien ";
            sql += " left join medibv.xuatvien c on b.maql=c.maql ";
            sql += " where a.mabn='" + s_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + m_ngay + "'";
            sql += " order by a.ngay desc";
            DataSet ads = m.get_data(sql);
            bool bLayMavaovienMoi = false;
            if (ads.Tables[0].Select("daxuatvien=0").Length > 0)
            {
                DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã vào trong ngày hôm nay rồi.") + "\n" + lan.Change_language_MessageText("Bạn có muốn lần vào này sẽ gom chung chi phí với lần trước không?"), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                bLayMavaovienMoi = dlg == DialogResult.No;
            }
            if (bLayMavaovienMoi) return;//Xem nhu mot dot dieu tri moi
            foreach (DataRow r in ads.Tables[0].Select("daxuatvien=0"))
            {
                if (skip)
                {
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                }
                l_matd = decimal.Parse(r["maql"].ToString());
                tendoituong.SelectedValue = r["madoituong"].ToString();
                madoituong.Text = r["madoituong"].ToString();
                //sovaovien.Text=r["sovaovien"].ToString();
                string stuoi = r["tuoivao"].ToString();
                if (stuoi.Length == 4)
                {
                    tuoi.Text = stuoi.Substring(0, 3);
                    loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
                }
                l_maql = decimal.Parse(r["maql"].ToString());
                break;
            }
            if (l_maql != 0)
            {
                emp_bhyt();
                foreach (DataRow r in m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0].Rows)
                {
                    quanhe.Text = r["quanhe"].ToString();
                    qh_hoten.Text = r["hoten"].ToString();
                    qh_diachi.Text = r["diachi"].ToString();
                    qh_dienthoai.Text = r["dienthoai"].ToString();
                }
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (int.Parse(so.Substring(0, 2)) > 0)
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".bhyt where maql=" + l_maql).Tables[0].Rows)
                    {
                        sothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        mabv.Text = r["mabv"].ToString();
                        if (mabv.Text != "") tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        if (bTraituyen) traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                    }
                }
                if (khamthai.Visible)
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".ttkhamthai where maql=" + l_maql).Tables[0].Rows)
                    {
                        para1.Text = r["para"].ToString().Substring(0, 2);
                        para2.Text = r["para"].ToString().Substring(2, 2);
                        para3.Text = r["para"].ToString().Substring(4, 2);
                        para4.Text = r["para"].ToString().Substring(6, 2);
                    }
                }
            }
        }

		private void l_tainantt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            frmTainantt f = new frmTainantt(m, l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid,makp.Text,nam);
			f.ShowDialog();
			load_tainantt();
		}

		private void Filt_dstt(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[listdstt.DataSource];
			DataView dv=(DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
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
                tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
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
			listdstt.BrowseToText(tendstt,madstt,lanthu,madstt.Location.X,madstt.Location.Y+madstt.Height-2,madstt.Width+tendstt.Width+1,madstt.Height);

		}

		private void listdstt_Validated(object sender, System.EventArgs e)
		{
//			try
//			{
//				if (madstt.Text!="") tendstt.Text=m.get_data("select tenbv from dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
//			}
//			catch{}
			treeView1.Visible=true;
		}

		private void tendstt_Validated(object sender, System.EventArgs e)
		{
//			madstt.Text=m.get_madstt(tendstt.Text);
			if(!listdstt.Focused)
			{
				listdstt.Hide();
				treeView1.Visible=true;
			}
		}

		private void load_btdnn(int i)
		{
            if (i == 0) tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
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

		private void cd_kkb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void cd_kkb_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kkb)
			{
				if (bChandoan_kemtheo || icd_kkb.Text==""  || icd_kkb.Text.Trim() == u00)
				{
					Filt_ICD(cd_kkb.Text);
					listICD.BrowseToICD10(cd_kkb,icd_kkb,icd_kemtheo,icd_kkb.Location.X-27,pvaovien.Location.Y+11*icd_kkb.Height+72,icd_kkb.Width+cd_kkb.Width+421,icd_kkb.Height);
				}
			}
		}

		private void cd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_noichuyenden)
			{
                if (bChandoan_kemtheo || icd_noichuyenden.Text == "" || icd_noichuyenden.Text.Trim() == u00)
				{
					Filt_ICD(cd_noichuyenden.Text);
					listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,icd_kkb,icd_kkb.Location.X-26,pvaovien.Location.Y+10*icd_noichuyenden.Height+71,icd_noichuyenden.Width+cd_noichuyenden.Width+420,icd_noichuyenden.Height);
				}
			}
		}

		private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kemtheo)
			{
                if (bChandoan_kemtheo || icd_kemtheo.Text == "" || icd_kemtheo.Text.Trim() == u00)
				{
					Filt_ICD(cd_kemtheo.Text);
					//listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,mabs,icd_kemtheo.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+34,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
                    listICD.BrowseToICD10(cd_kemtheo, icd_kemtheo, mabs, icd_kemtheo.Location.X-27 ,
                               pvaovien.Location.Y +12 * icd_kemtheo.Height+73 , 
                               icd_kemtheo.Width + cd_kemtheo.Width + 421, icd_kemtheo.Height);

				}
			}		
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
                dv.RowFilter = "vviet like '%" + ten.Trim().Replace("'", "''") + "%'";
			}
			catch{}
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
			if (traituyen.Enabled) list.BrowseToText(tenbv,mabv,traituyen,tenbv.Location.X,tenbv.Location.Y+tenbv.Height-2,tenbv.Width+128,tenbv.Height);
			else list.BrowseToText(tenbv,mabv,quanhe,tenbv.Location.X,tenbv.Location.Y+tenbv.Height-2,tenbv.Width+128,tenbv.Height);
		}

		private void l_kemtheo_Click(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="" || cd_kemtheo.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0) luu();
            else m.upd_cdkemtheo(l_maql, l_maql, 1, cd_kemtheo.Text, icd_kemtheo.Text, 1);
			frmCdkemtheo f=new frmCdkemtheo(m,l_maql,l_maql,1,"");
			f.ShowDialog();
			load_kemtheo();
		}

		private void load_kemtheo()
		{
            //kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=1 and id="+l_maql).Tables[0].Rows.Count!=0;
            //l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void luu()
		{
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, true);
			if (makp.Text!=makp_save && makp_save!="")
			{
				if (m.get_nhapkhoa(l_maql))
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã nhập khoa không thể sửa phần vào khoa !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql, l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Nhanbenh, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Nhanbenh, l_maql);
            }
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(lanthu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_kkb.Text, icd_kkb.Text, mabs.Text, sovaovien.Text, 1, i_userid, true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0) luu();
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
		}

		private void mame_Validated(object sender, System.EventArgs e)
		{
			tlblme.Text="";
			if (bMabame)
			{
				if (mame.Text=="") 
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã mẹ !"),s_msg);
					mame.Focus();
					return;
				}
			}
			else if (mame.Text=="") return;
			if (mame.Text==mabn2.Text+mabn3.Text) 
			{
				mame.Text="";
				return;
			}
            if (mame.Text == "" || mame.Text.Trim().Length < 3) return;
            //
            if (mame.Text.Trim().Length != 8)
            {
                if (i_chinhanh > 0)
                {
                    mame.Text = mame.Text.Substring(0, 2) + i_chinhanh.ToString().PadLeft(2, '0') + mame.Text.Substring(2).PadLeft(6, '0');
                }
                else mame.Text = mame.Text.Substring(0, 2) + mame.Text.Substring(2).PadLeft(6, '0');
            }
            //
             
			ss_hoten_me.Text="";ss_ns_me.Text="";ss_tennn_me.SelectedIndex=-1;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + mame.Text + "'").Tables[0].Rows)
			{
				ss_hoten_me.Text=r["hoten"].ToString();
				ss_ns_me.Text=r["namsinh"].ToString();
				ss_tennn_me.SelectedValue=r["mann"].ToString();
				tendantoc.SelectedValue=r["madantoc"].ToString();
				sonha.Text=r["sonha"].ToString();
				thon.Text=r["thon"].ToString();
				cholam.Text=r["cholam"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				if (manuoc.Enabled)
                    foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + mame.Text + "'").Tables[0].Rows) tennuoc.SelectedValue=r1["id_nuoc"].ToString();
				break;
			}
			foreach(DataRow r in m.get_data("select * from "+user+".ddsosinh where mabn='"+mame.Text+"' order by maql desc").Tables[0].Rows)
			{
				apgar1.Text=(r["apgar1"].ToString()=="0")?"":r["apgar1"].ToString();
				apgar5.Text=(r["apgar5"].ToString()=="0")?"":r["apgar5"].ToString();
				apgar10.Text=(r["apgar10"].ToString()=="0")?"":r["apgar10"].ToString();
				cannang.Text=(r["cannang"].ToString()=="0")?"":r["cannang"].ToString();
				cao.Text=(r["cao"].ToString()=="0")?"":r["cao"].ToString();
				vongdau.Text=(r["vongdau"].ToString()=="0")?"":r["vongdau"].ToString();
				break;
			}
            foreach (DataRow r in m.get_data("select * from " + user + ".ttkhamthai where mabn='" + mame.Text + "' order by maql desc").Tables[0].Rows)
			{
				para=r["para"].ToString();
				if (para.Length==8)
				{
					ss_para1.Text=para.Substring(0,2);
					ss_para2.Text=para.Substring(2,2);
					ss_para3.Text=para.Substring(4,2);
					ss_para4.Text=para.Substring(6,2);
				}
				break;
			}
			load_me();
			if (ss_hoten_me.Text!="") ss_delan.Focus();
		}

		private void load_me()
		{
			tlblme.Text="";
            sql = "select nullif(d.ten,'') as ten,c.tenkp from " + user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id";
            sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp left join " + user + ".ttxk d on b.ttlucrk=d.ma ";
			sql+=" where a.mabn='"+mame.Text+"' order by a.ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				tlblme.Text=
lan.Change_language_MessageText("MẸ :")+" "+((r["ten"].ToString()=="")?
lan.Change_language_MessageText("ĐANG ĐIỀU TRỊ TẠI"):r["ten"].ToString().Trim().ToUpper())+" "+r["tenkp"].ToString().Trim().ToUpper();
				break;
			}
		}
		private void para1_Validated(object sender, System.EventArgs e)
		{
			if (phai.SelectedIndex==1)
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
		}

		private void para2_Validated(object sender, System.EventArgs e)
		{
			if (phai.SelectedIndex==1) para2.Text=para2.Text.PadLeft(2,'0');
		}

		private void para3_Validated(object sender, System.EventArgs e)
		{
			if (phai.SelectedIndex==1) para3.Text=para3.Text.PadLeft(2,'0');
		}

		private void para4_Validated(object sender, System.EventArgs e)
		{
			if (phai.SelectedIndex==1) para4.Text=para4.Text.PadLeft(2,'0');
		}
		private void phai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (bKhamthai && !bSosinh) khamthai.Visible=phai.SelectedIndex==1;		
		}

		private void apgar1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
					listBS.BrowseToICD10(tenbs,mabs,soluutru,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+119,mabs.Height);
				else if (pmat.Visible)
					listBS.BrowseToICD10(tenbs,mabs,mp,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+119,mabs.Height);
				else if (ddsosinh.Visible)
					listBS.BrowseToICD10(tenbs,mabs,ddsosinh,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+119,mabs.Height);
				else listBS.BrowseToICD10(tenbs,mabs,butLuu,mabs.Location.X,mabs.Location.Y+mabs.Height-2,mabs.Width+tenbs.Width+119,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim().Replace("'", "''") + "%'";
			}
			catch{}
		}

#region Binh
		private string get_soluutru(string s_mabn)
		{
			string s_soluutru="";
			sql=" select a.mabn, b.maql, c.soluutru "+
                " from " + user + ".btdbn a, " + user + ".benhandt b, " + user + ".lienhe c where a.mabn=b.mabn and b.maql=c.maql and c.soluutru is not null" +
				" and a.mabn='"+s_mabn+"' order by b.maql desc ";
			DataSet ds=m.get_data(sql);
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				s_soluutru=r["soluutru"].ToString();
				break;
			}
			ds.Dispose();
			return s_soluutru;
		}
	#endregion

		private void label48_Click(object sender, System.EventArgs e)
		{
			Dsach_bn frmdsbenhnhan = new Dsach_bn(hoten.Text,namsinh.Text);
			frmdsbenhnhan.ShowDialog();
			try
			{
				hoten.Text=frmdsbenhnhan.Hotenbn.ToString();
				mabn2.Text=frmdsbenhnhan.Mabn.Substring(0,2).ToString();
				mabn3.Text=frmdsbenhnhan.Mabn.Substring(2,6).ToString();		
			}
			catch{}
		}

		private void icd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào viện !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            if (s_ngayvv != "")
            {
                if (ngayvv.Text != s_ngayvv.Substring(0,10))
                {
                    if (tuoi.Text != "")
                    {
                        if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                        {
                            tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    s_mabn = mabn2.Text + mabn3.Text;
                    if (!bTiepdon)
                    {
                        if (m.bMmyy(m.mmyy(ngayvv.Text)))
                        {
                            if (m.get_tiepdon(s_mabn, ngayvv.Text) == 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                                butBoqua_Click(sender, e);
                                return;
                            }
                        }
                    }
                    if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        s_ngayvv = "";
                        ngayvv.Focus();
                        return;
                    }
                }
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
            string s = ngayvv.Text+" "+giovv.Text;
            s_mabn = mabn2.Text + mabn3.Text;
            if (s != s_ngayvv)
            {
                l_maql = m.get_maql(1, s_mabn, "??", s, false);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                    if (!bAdmin) ena_but(false);
                }
                else
                {
                    l_maql = m.get_maql_ngay(1, s_mabn, "??", s);
                    if (l_maql != 0)
                    {
                        if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã được nhận bệnh ngày '"+ngayvv.Text+"',") + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            load_vv_maql(false);
                            if (!bAdmin) ena_but(false);
                            return;
                        }
                        else
                        {
                            bNew = true;
                            l_matd = 0;
                            l_maql = 0;
                        }
                    }
                    string s_tenkp = m.bHiendien(s_mabn, 1);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được,phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        butBoqua_Click(null, null);
                        return;
                    }
                    else
                    {
                        s_tenkp = m.bNhapvien(s_mabn, 1);
                        if (s_tenkp != "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                            butBoqua_Click(null, null);
                            return;
                        }
                    }
                    ena_but(true);
                    emp_vv();
                    emp_bhyt();
                    if (ngayvv.Text != "" && bNew==false) load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    s_ngayvv = s;
                }
            }
        }

        private void soluutru_Validated(object sender, EventArgs e)
        {
            if (m.blSoluutru(soluutru.Text, l_maql, user+".lienhe"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số lưu trữ này đã có !"), s_msg);
                soluutru.Focus();
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void lay_mabn_vantay()
        {
            string tmp_mabn = (mabn3.Text.Trim() != "") ? (mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(3, '0')) : "";
            ma_vantay = "";
            if (fnhandang == null) fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == 8)
            {
                mabn2.Text = ma_vantay.Substring(0, 2);
                mabn3.Text = ma_vantay.Substring(2);
                s_mabn = mabn2.Text + mabn3.Text;
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
                        string ma = DateTime.Now.Year.ToString().Substring(2) + maso.ToString().PadLeft(6, '0');
                        mabn2.Text = ma.Substring(0, 2);
                        mabn3.Text = ma.Substring(2);
                        hoten.Text = "";
                        hoten.Focus();
                    }
                }
                else if (tmp_mabn.Trim() != "")
                    return;
                else if (tmp_mabn.Trim() == "")
                {
                    mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
                    mabn3.Text = "";
                    mabn2.Focus();
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            frmTusat f = new frmTusat(l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid);
            f.ShowDialog();
        }

        private void tungay_Validated(object sender, EventArgs e)
        {
            tungay.Text = tungay.Text.Trim();
            if (tungay.Text.Length == 6) tungay.Text = tungay.Text + DateTime.Now.Year.ToString();
            if (tungay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"), s_msg);
                tungay.Focus();
                return;
            }
            if (!m.bNgay(tungay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                tungay.Focus();
                return;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text);
            f.ShowDialog();
        }

        private void traituyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        

        private void f_load_option()
        {
            bMabn_tudong_tu_ServerInterNet_D24 = m.bMabn_tudong_tu_ServerInterNet_D24;
            butget_msbn_from_internet.Visible = bMabn_tudong_tu_ServerInterNet_D24;
            bMabn_tudong = m.bMabn_tudong_tiepdon;
            bnKhamBHYTmotlantrongngay = m.bnKhamBHYTmotlantrongngay;// E34
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
                s_mabn = mabn2.Text + mabn3.Text;
                if (m.get_data("select mabn from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
            }
            try
            {
                if (s_nam != "" && mabn3.Text != "")
                {
                    m.upd_capmabn(int.Parse(s_nam), 0, 0, int.Parse(mabn3.Text));
                }
                mabn3.Focus();
            }
            catch { Cursor = Cursors.Default; }
            Cursor = Cursors.Default;
        }
	}
}
