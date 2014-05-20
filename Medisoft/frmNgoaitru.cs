using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	public class frmNgoaitru : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();
        private int i_maxlength_mabn = 8;
        private bool bSothe_dkkcb, bMabn_tudong = false, bMabn_tudong_tu_ServerInterNet_D24 = false, bMabn_tudong_theomay = false;
        private bool bQuanly_Theo_Chinhanh = false;
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private DataSet ds=new DataSet();
        private DataTable dtbs = new DataTable ();
		private string user,nam,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,s_ngayvk,s_ngayrk,s_noicap,sql,s_nhomkho,s_mabs,u00 = "U00",s_madoituong,ngay1="",ngay2="",ngay3="";
        private int i_userid, i_mabv, i_maba, i_chidinh, iMavp_ngoaitru,iTraituyen,i_chinhanh=0;
		private decimal l_maql=0,l_matd=0,lTraituyen=0;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
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
        private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ComboBox tenketqua;
		private System.Windows.Forms.TextBox ketqua;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ComboBox tenttlucrv;
		private System.Windows.Forms.TextBox ttlucrv;
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
		private MaskedTextBox.MaskedTextBox soluutru;
		private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
		private System.Windows.Forms.CheckBox taibien;
		private System.Windows.Forms.CheckBox bienchung;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
		private int songay=30,iTreem6,iTreem15,songaydtngoaitru;
		private bool b_Edit=false,b_Hoten=false,bLuutru_Mabn,b_sovaovien,bAdmin,bXutri_noitru,bTiepdon,bKhamthai,bChuyenkhoasan,bDanhmuc_nhathuoc,bSothe_ngay_huong;
		private System.Windows.Forms.TextBox songaydt;
		private System.Windows.Forms.CheckBox giaiphau;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.ComponentModel.IContainer components;
        private bool b_soluutru, b_bacsi, bDenngay_sothe, bChandoan,bChandoan_kemtheo, bSothe_mabn, bSovaovien, bNgoaitru_congkham,bHiends,bTungay,bTraituyen,bSoluutru_ngtru_nam;
        private bool bSovaovien_tudong_nt = false, bSovaovien_tudong_ngt=false,bThongtinNguoithan=false,bXemlai_toa=false;
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
		private MaskedTextBox.MaskedTextBox sothe;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
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
		private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox gphaubenh;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox ngayvk;
		private MaskedBox.MaskedBox ngayrv;
		private System.Windows.Forms.ComboBox cmbTaibien;
		private LibList.List listdstt;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TreeView treeView1;
		private string s_icd_noichuyenden,s_icd_kkb,s_icd_chinh,s_icd_kemtheo,s_mabv;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private System.Windows.Forms.TextBox cd_chinh;
		private System.Windows.Forms.TextBox cd_noichuyenden;
		private System.Windows.Forms.TextBox cd_kkb;
		private LibList.List listICD;
		private System.Windows.Forms.ComboBox tenkhoa;
		private System.Windows.Forms.TextBox khoa;
		private System.Windows.Forms.Label label11;
        private DataTable dticd = new DataTable();
		private System.Windows.Forms.Panel khamthai;
		private MaskedTextBox.MaskedTextBox para4;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel pmat;
		private MaskedTextBox.MaskedTextBox nhanapt;
		private MaskedTextBox.MaskedTextBox nhanapp;
		private MaskedTextBox.MaskedTextBox mt;
		private MaskedTextBox.MaskedTextBox mp;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label8;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
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
        private ToolStripButton toolStripButton12;
        private ToolStripLabel tlbl;
        private MaskedBox.MaskedBox giovk;
        private Label label12;
        private MaskedBox.MaskedBox giovv;
        private Label label10;
        private TextBox lydo;
        private Label lblLydo;
        private MaskedBox.MaskedBox giorv;
        private Label label13;
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
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton toolStripButton13;
        private Label label14;
        private Label label16;
		private DataTable dtttlucrv=new DataTable();
        private DataTable dtvp = new DataTable();
        private bool bNgtru_dt_makp;
        private int dt_ngtru = 0;
        private GroupBox danhsach;
        private AsYetUnnamed.MultiColumnListBox list;
        private Label lblso;
        private TextBox tim;
        private Button butRef;
        private MaskedBox.MaskedBox tungay;
        private Label label17;
        private MaskedTextBox.MaskedTextBox manoidk;
        private TextBox noidk;
        private Label label38;
        private LibList.List listbv;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton toolStripButton14;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripButton toolStripButton15;
        private string makp_kho_dt;
        private Panel dausinhton;
        private MaskedTextBox.MaskedTextBox cao;
        private Label label59;
        private MaskedBox.MaskedBox nhietdo;
        private MaskedTextBox.MaskedTextBox nang;
        private Label label25;
        private Label label41;
        private MaskedTextBox.MaskedTextBox huyetap;
        private Label label43;
        private MaskedTextBox.MaskedTextBox mach;
        private Label label44;
        private Label label45;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label60;
        private Button butInchitiet;
        private CheckBox chkXml;
        private CheckBox chkToathuoc;
        private CheckBox chkXem;
        private bool bNgoaitru_bacsy;
        private bool bDonngoaitru_auto, bIn, bDichvu_vpkb;
        private bool bInchitiet, bCongkham, bChuky;
        private decimal Congkham = 0, bhyttra, bntra;
        private decimal d_id;
        private int iHaophi;
        private string maso, d_mmyy;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private DataSet dsxmlin = new DataSet();
        private DataTable dtbd = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtdt = new DataTable();
        private dichso.numbertotext doiso = new dichso.numbertotext();
        private FileStream fstr;
        private System.IO.MemoryStream memo;
        private byte[] image;
        private bool bHaophi, bHaophi_doituongvao;
        private string s_nhomhaophi="", s_soluutru = "";
        private ComboBox traituyen;
        private LibList.List listBS;
        private TextBox tenbs;
        private Label label61;
        private dllReportM.Print print = new dllReportM.Print();
        private Button butDateBHYT;
        //TU:31/03/2011
        public bool bUpdate = false;
        private string _sothe = "08001";
        private int _dai = 18, _vitri = 14;
        private string s_tungay1 = "", s_tungay2 = "", s_tungay3 = "";//gam 07/09/2011
        #endregion

        public frmNgoaitru(LibMedi.AccessData acc,string makp,string hoten,int userid,int mabv,bool sovaovien,bool soluutru,string _nhomkho,string _mabs,string _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; s_userid = hoten; if (m.bBogo) tv.GanBogo(this, textBox111);
            i_userid = userid; i_mabv = mabv; b_soluutru = soluutru; s_nhomkho = _nhomkho;
            loaituoi.Items.Clear(); s_mabs = _mabs; s_madoituong = _madoituong;
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
			
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        //Tu:27/06/2011 truyền vào mã bn
        public frmNgoaitru(LibMedi.AccessData acc, string makp, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _nhomkho, string _mabs, string _madoituong,string _s_mabn)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = makp; s_userid = hoten; if (m.bBogo) tv.GanBogo(this, textBox111);
            i_userid = userid; i_mabv = mabv; b_soluutru = soluutru; s_nhomkho = _nhomkho;
            loaituoi.Items.Clear(); s_mabs = _mabs; s_madoituong = _madoituong;
            mabn2.Text = _s_mabn.Substring(0,2);
            mabn3.Text = _s_mabn.Substring(2);
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});

        }
        //end Tu

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNgoaitru));
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
            this.label37 = new System.Windows.Forms.Label();
            this.tenketqua = new System.Windows.Forms.ComboBox();
            this.ketqua = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tenttlucrv = new System.Windows.Forms.ComboBox();
            this.ttlucrv = new System.Windows.Forms.TextBox();
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
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.songaydt = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.taibien = new System.Windows.Forms.CheckBox();
            this.bienchung = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.giaiphau = new System.Windows.Forms.CheckBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.phanhchinh = new System.Windows.Forms.Panel();
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
            this.pvaovien = new System.Windows.Forms.Panel();
            this.lydo = new System.Windows.Forms.TextBox();
            this.lblLydo = new System.Windows.Forms.Label();
            this.butDateBHYT = new System.Windows.Forms.Button();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.dausinhton = new System.Windows.Forms.Panel();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.nang = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.listbv = new LibList.List();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.noidk = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tungay = new MaskedBox.MaskedBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.giovk = new MaskedBox.MaskedBox();
            this.label12 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.label8 = new System.Windows.Forms.Label();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
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
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dentu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.khamthai = new System.Windows.Forms.Panel();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.manoidk = new MaskedTextBox.MaskedTextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.listdstt = new LibList.List();
            this.label55 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gphaubenh = new System.Windows.Forms.ComboBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.ngayrv = new MaskedBox.MaskedBox();
            this.cmbTaibien = new System.Windows.Forms.ComboBox();
            this.listICD = new LibList.List();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.tenkhoa = new System.Windows.Forms.ComboBox();
            this.khoa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.giorv = new MaskedBox.MaskedBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.danhsach = new System.Windows.Forms.GroupBox();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.lblso = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.butRef = new System.Windows.Forms.Button();
            this.butInchitiet = new System.Windows.Forms.Button();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkToathuoc = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.phanhchinh.SuspendLayout();
            this.pvaovien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.pmat.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.danhsach.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(91, 50);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(145, 21);
            this.tenba.TabIndex = 2;
            this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(237, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(30, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(30, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn1.Enabled = false;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(160, 15);
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
            this.mabn2.Location = new System.Drawing.Point(279, 50);
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
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(302, 50);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 8;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(58, 21);
            this.mabn3.TabIndex = 6;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(151, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(213, 94);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 9;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(224, 94);
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
            "y.o",
            "m.o.",
            "d.o",
            "h.o."});
            this.loaituoi.Location = new System.Drawing.Point(306, 94);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(54, 21);
            this.loaituoi.TabIndex = 11;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(128, 15);
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
            this.tuoi.Location = new System.Drawing.Point(277, 94);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
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
            this.hoten.Location = new System.Drawing.Point(91, 72);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(269, 21);
            this.hoten.TabIndex = 7;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label37.Location = new System.Drawing.Point(388, 311);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(112, 23);
            this.label37.TabIndex = 15;
            this.label37.Text = "Ngày kết thúc ĐT :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenketqua
            // 
            this.tenketqua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenketqua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenketqua.Location = new System.Drawing.Point(516, 333);
            this.tenketqua.Name = "tenketqua";
            this.tenketqua.Size = new System.Drawing.Size(269, 21);
            this.tenketqua.TabIndex = 20;
            this.tenketqua.SelectedIndexChanged += new System.EventHandler(this.tenketqua_SelectedIndexChanged);
            this.tenketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenketqua_KeyDown);
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(497, 333);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(18, 21);
            this.ketqua.TabIndex = 19;
            this.ketqua.Validated += new System.EventHandler(this.ketqua_Validated);
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(388, 333);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(112, 23);
            this.label39.TabIndex = 93;
            this.label39.Text = "Kết quả :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenttlucrv
            // 
            this.tenttlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenttlucrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenttlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenttlucrv.Location = new System.Drawing.Point(516, 421);
            this.tenttlucrv.Name = "tenttlucrv";
            this.tenttlucrv.Size = new System.Drawing.Size(138, 21);
            this.tenttlucrv.TabIndex = 28;
            this.tenttlucrv.SelectedIndexChanged += new System.EventHandler(this.tenttlucrv_SelectedIndexChanged);
            this.tenttlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenttlucrv_KeyDown);
            // 
            // ttlucrv
            // 
            this.ttlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ttlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlucrv.Location = new System.Drawing.Point(497, 421);
            this.ttlucrv.Name = "ttlucrv";
            this.ttlucrv.Size = new System.Drawing.Size(18, 21);
            this.ttlucrv.TabIndex = 27;
            this.ttlucrv.Validated += new System.EventHandler(this.ttlucrv_Validated);
            this.ttlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ttlucrv_KeyDown);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(388, 420);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(112, 23);
            this.label40.TabIndex = 96;
            this.label40.Text = "Tình trạng :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(388, 354);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(112, 23);
            this.label42.TabIndex = 97;
            this.label42.Text = "Bệnh chính :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(497, 355);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(50, 21);
            this.icd_chinh.TabIndex = 21;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(497, 377);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(50, 21);
            this.icd_kemtheo.TabIndex = 23;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // label46
            // 
            this.label46.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label46.Location = new System.Drawing.Point(388, 377);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(112, 23);
            this.label46.TabIndex = 105;
            this.label46.Text = "Bệnh kèm theo :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenloaibv
            // 
            this.tenloaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenloaibv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenloaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloaibv.Location = new System.Drawing.Point(516, 443);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(84, 21);
            this.tenloaibv.TabIndex = 31;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(497, 443);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(18, 21);
            this.loaibv.TabIndex = 30;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label47.Location = new System.Drawing.Point(388, 443);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(112, 23);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển tuyến :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label48.Location = new System.Drawing.Point(591, 443);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(41, 23);
            this.label48.TabIndex = 112;
            this.label48.Text = "Đến :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(630, 443);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(24, 21);
            this.mabv.TabIndex = 32;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(655, 443);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(130, 21);
            this.tenbv.TabIndex = 33;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(497, 399);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(34, 21);
            this.mabs.TabIndex = 25;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label49.Location = new System.Drawing.Point(388, 398);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(112, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Bác sĩ điều trị :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(711, 421);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(74, 21);
            this.soluutru.TabIndex = 29;
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label50.Location = new System.Drawing.Point(630, 423);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(81, 17);
            this.label50.TabIndex = 119;
            this.label50.Text = "Số lưu trữ :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songaydt
            // 
            this.songaydt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.songaydt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songaydt.Enabled = false;
            this.songaydt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaydt.Location = new System.Drawing.Point(746, 311);
            this.songaydt.Name = "songaydt";
            this.songaydt.Size = new System.Drawing.Size(39, 21);
            this.songaydt.TabIndex = 18;
            // 
            // label51
            // 
            this.label51.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label51.Location = new System.Drawing.Point(621, 311);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(126, 21);
            this.label51.TabIndex = 121;
            this.label51.Text = "Tổng số ngày điều trị :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taibien.ForeColor = System.Drawing.SystemColors.Desktop;
            this.taibien.Location = new System.Drawing.Point(15, 403);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(147, 24);
            this.taibien.TabIndex = 126;
            this.taibien.Text = "Tai biến điều trị nội khoa";
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bienchung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bienchung.Location = new System.Drawing.Point(15, 444);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(96, 24);
            this.bienchung.TabIndex = 127;
            this.bienchung.Text = "Biến chứng";
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(9, 27);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(137, 23);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label54.Location = new System.Drawing.Point(388, 292);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(224, 23);
            this.label54.TabIndex = 143;
            this.label54.Text = "III. THÔNG TIN RA VIỆN :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(176, 496);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 38;
            this.butTiep.Text = "     &Tiếp";
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
            this.butLuu.Location = new System.Drawing.Point(246, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 36;
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
            this.butBoqua.Location = new System.Drawing.Point(316, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 37;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(460, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(90, 25);
            this.butIn.TabIndex = 37;
            this.butIn.Text = "    Chuyển viện";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(550, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 39;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // giaiphau
            // 
            this.giaiphau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaiphau.ForeColor = System.Drawing.SystemColors.Desktop;
            this.giaiphau.Location = new System.Drawing.Point(15, 422);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(104, 24);
            this.giaiphau.TabIndex = 128;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // phanhchinh
            // 
            this.phanhchinh.Controls.Add(this.tennuoc);
            this.phanhchinh.Controls.Add(this.manuoc);
            this.phanhchinh.Controls.Add(this.lmanuoc);
            this.phanhchinh.Controls.Add(this.sonha);
            this.phanhchinh.Controls.Add(this.tendantoc);
            this.phanhchinh.Controls.Add(this.tentqx);
            this.phanhchinh.Controls.Add(this.cholam);
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
            this.phanhchinh.Location = new System.Drawing.Point(6, 116);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(355, 176);
            this.phanhchinh.TabIndex = 13;
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(268, 22);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(86, 21);
            this.tennuoc.TabIndex = 5;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(243, 22);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 4;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmanuoc.Location = new System.Drawing.Point(179, 22);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(85, 44);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(74, 21);
            this.sonha.TabIndex = 6;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(111, 22);
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
            this.tentqx.Location = new System.Drawing.Point(134, 66);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(220, 21);
            this.tentqx.TabIndex = 9;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(85, 154);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(269, 21);
            this.cholam.TabIndex = 18;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(243, 44);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(111, 21);
            this.thon.TabIndex = 7;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(125, 132);
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
            this.maqu2.Location = new System.Drawing.Point(113, 110);
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
            this.matt.Location = new System.Drawing.Point(85, 88);
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
            this.tqx.Location = new System.Drawing.Point(85, 66);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 8;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(85, 22);
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
            this.mann.Location = new System.Drawing.Point(243, 0);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 0;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(267, 0);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(87, 21);
            this.tennn.TabIndex = 1;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(137, 110);
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
            this.tentinh.Location = new System.Drawing.Point(113, 88);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(241, 21);
            this.tentinh.TabIndex = 11;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(149, 132);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(205, 21);
            this.tenpxa.TabIndex = 17;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(85, 132);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(39, 21);
            this.mapxa1.TabIndex = 15;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaphuongxa.Location = new System.Drawing.Point(16, 132);
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
            this.maqu1.Location = new System.Drawing.Point(85, 110);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 12;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaqu.Location = new System.Drawing.Point(8, 110);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmatt.Location = new System.Drawing.Point(32, 88);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ltqx.Location = new System.Drawing.Point(16, 65);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcholam.Location = new System.Drawing.Point(16, 154);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lthon.Location = new System.Drawing.Point(171, 44);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsonha.Location = new System.Drawing.Point(4, 44);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(83, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmadantoc.Location = new System.Drawing.Point(32, 20);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmann.Location = new System.Drawing.Point(166, 2);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
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
            this.phai.Location = new System.Drawing.Point(91, 116);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(86, 21);
            this.phai.TabIndex = 12;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lphai.Location = new System.Drawing.Point(38, 116);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pvaovien.Controls.Add(this.lydo);
            this.pvaovien.Controls.Add(this.lblLydo);
            this.pvaovien.Controls.Add(this.butDateBHYT);
            this.pvaovien.Controls.Add(this.traituyen);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.dausinhton);
            this.pvaovien.Controls.Add(this.listbv);
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.noidk);
            this.pvaovien.Controls.Add(this.label38);
            this.pvaovien.Controls.Add(this.tungay);
            this.pvaovien.Controls.Add(this.label17);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.ngayvk);
            this.pvaovien.Controls.Add(this.giovk);
            this.pvaovien.Controls.Add(this.label12);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label10);
            this.pvaovien.Controls.Add(this.pmat);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.cd_kkb);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.label9);
            this.pvaovien.Controls.Add(this.label32);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.icd_kkb);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.label29);
            this.pvaovien.Controls.Add(this.label28);
            this.pvaovien.Controls.Add(this.label27);
            this.pvaovien.Controls.Add(this.label26);
            this.pvaovien.Controls.Add(this.label24);
            this.pvaovien.Controls.Add(this.label23);
            this.pvaovien.Controls.Add(this.dentu);
            this.pvaovien.Controls.Add(this.label21);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Controls.Add(this.manoidk);
            this.pvaovien.Location = new System.Drawing.Point(388, 28);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(398, 265);
            this.pvaovien.TabIndex = 14;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.Location = new System.Drawing.Point(109, 242);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(288, 20);
            this.lydo.TabIndex = 27;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
            // 
            // lblLydo
            // 
            this.lblLydo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblLydo.Location = new System.Drawing.Point(-1, 242);
            this.lblLydo.Name = "lblLydo";
            this.lblLydo.Size = new System.Drawing.Size(109, 23);
            this.lblLydo.TabIndex = 248;
            this.lblLydo.Text = "Lý do :";
            this.lblLydo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butDateBHYT
            // 
            this.butDateBHYT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDateBHYT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDateBHYT.Location = new System.Drawing.Point(371, 87);
            this.butDateBHYT.Name = "butDateBHYT";
            this.butDateBHYT.Size = new System.Drawing.Size(24, 23);
            this.butDateBHYT.TabIndex = 268;
            this.butDateBHYT.TabStop = false;
            this.butDateBHYT.Text = "...";
            this.butDateBHYT.Click += new System.EventHandler(this.butDateBHYT_Click);
            // 
            // traituyen
            // 
            this.traituyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.traituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traituyen.Enabled = false;
            this.traituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen.Location = new System.Drawing.Point(345, 110);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(52, 21);
            this.traituyen.TabIndex = 17;
            this.traituyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.traituyen_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(128, 88);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(96, 21);
            this.tendoituong.TabIndex = 12;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // dausinhton
            // 
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
            this.dausinhton.Controls.Add(this.cao);
            this.dausinhton.Controls.Add(this.label59);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.nang);
            this.dausinhton.Controls.Add(this.label25);
            this.dausinhton.Controls.Add(this.label41);
            this.dausinhton.Controls.Add(this.huyetap);
            this.dausinhton.Controls.Add(this.label43);
            this.dausinhton.Controls.Add(this.mach);
            this.dausinhton.Controls.Add(this.label44);
            this.dausinhton.Controls.Add(this.label45);
            this.dausinhton.Controls.Add(this.label56);
            this.dausinhton.Controls.Add(this.label57);
            this.dausinhton.Controls.Add(this.label58);
            this.dausinhton.Controls.Add(this.label60);
            this.dausinhton.Location = new System.Drawing.Point(27, 131);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(367, 22);
            this.dausinhton.TabIndex = 17;
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
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(275, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 20);
            this.label25.TabIndex = 267;
            this.label25.Text = "Nặng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label41.Location = new System.Drawing.Point(103, -2);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(24, 23);
            this.label41.TabIndex = 23;
            this.label41.Text = "T° :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(181, 1);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(40, 21);
            this.huyetap.TabIndex = 2;
            // 
            // label43
            // 
            this.label43.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label43.Location = new System.Drawing.Point(154, -1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(30, 23);
            this.label43.TabIndex = 24;
            this.label43.Text = "HA :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label44
            // 
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label44.Location = new System.Drawing.Point(215, 1);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(36, 20);
            this.label44.TabIndex = 266;
            this.label44.Text = "Cao :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(11, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 23);
            this.label45.TabIndex = 1;
            this.label45.Text = "Mạch :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.SystemColors.Control;
            this.label56.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label56.Location = new System.Drawing.Point(81, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(28, 23);
            this.label56.TabIndex = 17;
            this.label56.Text = "l/p";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label57.Location = new System.Drawing.Point(131, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(24, 23);
            this.label57.TabIndex = 19;
            this.label57.Text = "°C";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label58.Location = new System.Drawing.Point(185, -1);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(38, 23);
            this.label58.TabIndex = 21;
            this.label58.Text = "mmHg";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label60.Location = new System.Drawing.Point(248, 1);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(22, 21);
            this.label60.TabIndex = 268;
            this.label60.Text = "cm";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listbv
            // 
            this.listbv.BackColor = System.Drawing.SystemColors.Info;
            this.listbv.ColumnCount = 0;
            this.listbv.Location = new System.Drawing.Point(292, 2);
            this.listbv.MatchBufferTimeOut = 1000;
            this.listbv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbv.Name = "listbv";
            this.listbv.Size = new System.Drawing.Size(75, 17);
            this.listbv.TabIndex = 267;
            this.listbv.TextIndex = -1;
            this.listbv.TextMember = null;
            this.listbv.ValueIndex = -1;
            this.listbv.Visible = false;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(261, 88);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(110, 21);
            this.sothe.TabIndex = 13;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(172, 110);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(62, 21);
            this.denngay.TabIndex = 15;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // noidk
            // 
            this.noidk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidk.Location = new System.Drawing.Point(261, 110);
            this.noidk.Name = "noidk";
            this.noidk.Size = new System.Drawing.Size(83, 21);
            this.noidk.TabIndex = 16;
            this.noidk.TextChanged += new System.EventHandler(this.noidk_TextChanged);
            this.noidk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noidk_KeyDown);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label38.Location = new System.Drawing.Point(215, 108);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 23);
            this.label38.TabIndex = 255;
            this.label38.Text = "KCB :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(109, 110);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(62, 21);
            this.tungay.TabIndex = 14;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(50, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 23);
            this.label17.TabIndex = 252;
            this.label17.Text = "Từ ngày :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tendstt
            // 
            this.tendstt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(232, 44);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(165, 21);
            this.tendstt.TabIndex = 6;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(109, 22);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(62, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(109, 66);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(62, 21);
            this.ngayvk.TabIndex = 7;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(193, 66);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(36, 21);
            this.giovk.TabIndex = 8;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(154, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 19);
            this.label12.TabIndex = 250;
            this.label12.Text = "giờ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(194, 22);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(151, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 23);
            this.label10.TabIndex = 248;
            this.label10.Text = "giờ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.pmat.Controls.Add(this.label8);
            this.pmat.Location = new System.Drawing.Point(-8, 241);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(413, 22);
            this.pmat.TabIndex = 27;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(381, 0);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(16, 21);
            this.nhanapt.TabIndex = 26;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(323, 1);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(18, 21);
            this.nhanapp.TabIndex = 25;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(178, 1);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(18, 21);
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
            this.mp.Size = new System.Drawing.Size(17, 21);
            this.mp.TabIndex = 23;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(195, 5);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 5;
            this.label33.Text = "/10";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(344, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "T :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(238, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Nhãn áp P :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(160, 3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(21, 16);
            this.label35.TabIndex = 1;
            this.label35.Text = "T :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(129, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 4;
            this.label36.Text = "/10";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(32, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Thị lực P :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(160, 198);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(237, 21);
            this.cd_noichuyenden.TabIndex = 24;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_kkb
            // 
            this.cd_kkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(160, 220);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(237, 21);
            this.cd_kkb.TabIndex = 26;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // tendentu
            // 
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(128, 44);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(74, 21);
            this.tendentu.TabIndex = 5;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(232, 44);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(32, 21);
            this.madstt.TabIndex = 6;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(184, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 218;
            this.label9.Text = "Tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label32.Location = new System.Drawing.Point(3, 65);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(109, 23);
            this.label32.TabIndex = 212;
            this.label32.Text = "Ngày bắt đầu ĐT :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennhantu
            // 
            this.tennhantu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(300, 22);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(101, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(280, 22);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(18, 21);
            this.nhantu.TabIndex = 2;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(201, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 210;
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
            this.tenkp.Location = new System.Drawing.Point(287, 66);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(111, 21);
            this.tenkp.TabIndex = 10;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(109, 88);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // icd_kkb
            // 
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(109, 220);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(50, 21);
            this.icd_kkb.TabIndex = 25;
            this.icd_kkb.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label34.Location = new System.Drawing.Point(3, 220);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(109, 23);
            this.label34.TabIndex = 203;
            this.label34.Text = "Chẩn đoán vào :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(109, 198);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(50, 21);
            this.icd_noichuyenden.TabIndex = 23;
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label31.Location = new System.Drawing.Point(3, 199);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(109, 23);
            this.label31.TabIndex = 2;
            this.label31.Text = "CĐ Nơi chuyển đến :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(333, 176);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(64, 21);
            this.qh_dienthoai.TabIndex = 22;
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(109, 176);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(149, 21);
            this.qh_diachi.TabIndex = 21;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // qh_hoten
            // 
            this.qh_hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(233, 154);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(164, 21);
            this.qh_hoten.TabIndex = 20;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(109, 154);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(62, 21);
            this.quanhe.TabIndex = 19;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(24, 130);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số ngoại trú :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label29.Location = new System.Drawing.Point(255, 176);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label28.Location = new System.Drawing.Point(3, 176);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(109, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(142, 154);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(3, 153);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người thân :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(201, 87);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label23.Location = new System.Drawing.Point(3, 86);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(109, 44);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(3, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 23);
            this.label21.TabIndex = 191;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(3, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Đến khám bệnh lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(261, 66);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 9;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(215, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(6, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(281, 21);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO VIỆN :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // khamthai
            // 
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label15);
            this.khamthai.Location = new System.Drawing.Point(200, 131);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(128, 24);
            this.khamthai.TabIndex = 18;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(104, 1);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(22, 21);
            this.para4.TabIndex = 3;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(80, 1);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(22, 21);
            this.para3.TabIndex = 2;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(56, 1);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(22, 21);
            this.para2.TabIndex = 1;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(32, 1);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(22, 21);
            this.para1.TabIndex = 0;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(-3, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manoidk
            // 
            this.manoidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manoidk.Enabled = false;
            this.manoidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manoidk.Location = new System.Drawing.Point(206, -2);
            this.manoidk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manoidk.MaxLength = 8;
            this.manoidk.Name = "manoidk";
            this.manoidk.Size = new System.Drawing.Size(60, 21);
            this.manoidk.TabIndex = 253;
            // 
            // sovaovien
            // 
            this.sovaovien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(693, 290);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(93, 21);
            this.sovaovien.TabIndex = 15;
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(119, 505);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 219;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(7, 308);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(134, 23);
            this.label55.TabIndex = 207;
            this.label55.Text = "CÁC LẦN VÀO VIỆN :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(14, 333);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(346, 65);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // gphaubenh
            // 
            this.gphaubenh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(155, 425);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(204, 21);
            this.gphaubenh.TabIndex = 129;
            this.gphaubenh.Visible = false;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(91, 94);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 8;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // ngayrv
            // 
            this.ngayrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrv.Location = new System.Drawing.Point(497, 311);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(70, 21);
            this.ngayrv.TabIndex = 16;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(155, 403);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(204, 21);
            this.cmbTaibien.TabIndex = 214;
            this.cmbTaibien.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(143, 494);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 217;
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
            this.cd_kemtheo.Location = new System.Drawing.Point(548, 377);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(237, 21);
            this.cd_kemtheo.TabIndex = 24;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_chinh
            // 
            this.cd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(548, 355);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(237, 21);
            this.cd_chinh.TabIndex = 22;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(518, 465);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(267, 21);
            this.tenkhoa.TabIndex = 35;
            this.tenkhoa.SelectedIndexChanged += new System.EventHandler(this.tenkhoa_SelectedIndexChanged);
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // khoa
            // 
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(497, 465);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(20, 21);
            this.khoa.TabIndex = 34;
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(388, 465);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 23);
            this.label11.TabIndex = 229;
            this.label11.Text = "Chuyển khoa : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.toolStripButton5,
            this.toolStripSeparator5,
            this.toolStripButton6,
            this.toolStripSeparator6,
            this.toolStripButton7,
            this.toolStripSeparator7,
            this.toolStripButton8,
            this.toolStripSeparator8,
            this.toolStripButton9,
            this.toolStripSeparator9,
            this.toolStripButton10,
            this.toolStripSeparator10,
            this.toolStripButton11,
            this.toolStripSeparator11,
            this.toolStripButton12,
            this.tlbl,
            this.toolStripSeparator12,
            this.toolStripButton13,
            this.toolStripSeparator13,
            this.toolStripButton14,
            this.toolStripSeparator14,
            this.toolStripButton15});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 23);
            this.toolStrip1.TabIndex = 247;
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
            this.toolStripButton3.Text = "F1";
            this.toolStripButton3.ToolTipText = "Phẩu thuật - Thủ thuật";
            this.toolStripButton3.Click += new System.EventHandler(this.l_thuthuat_Click);
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
            this.toolStripButton4.Text = "F6";
            this.toolStripButton4.ToolTipText = "Yêu cầu cận lâm sàng";
            this.toolStripButton4.Click += new System.EventHandler(this.l_chidinh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton5.Text = "F7";
            this.toolStripButton5.ToolTipText = "Viện phí";
            this.toolStripButton5.Click += new System.EventHandler(this.l_vienphi_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton6.Text = "F8";
            this.toolStripButton6.ToolTipText = "Tử vong";
            this.toolStripButton6.Click += new System.EventHandler(this.l_tuvong_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton7.Text = "F9";
            this.toolStripButton7.ToolTipText = "Tai nạn thương tích";
            this.toolStripButton7.Click += new System.EventHandler(this.l_tainantt_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton8.Text = "F10";
            this.toolStripButton8.ToolTipText = "Tái khám";
            this.toolStripButton8.Click += new System.EventHandler(this.l_dieutri_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton9.Text = "F11";
            this.toolStripButton9.ToolTipText = "Bệnh kèm theo";
            this.toolStripButton9.Click += new System.EventHandler(this.l_kemtheo_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton10.Text = "F12";
            this.toolStripButton10.ToolTipText = "Xem hồ sơ bệnh án";
            this.toolStripButton10.Click += new System.EventHandler(this.l_cls_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(42, 20);
            this.toolStripButton11.Text = "^D";
            this.toolStripButton11.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton11.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(40, 20);
            this.toolStripButton12.Text = "^L";
            this.toolStripButton12.ToolTipText = "Lịch hẹn";
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            this.tlbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(41, 20);
            this.toolStripButton13.Text = "^T";
            this.toolStripButton13.ToolTipText = "Tủ trực";
            this.toolStripButton13.Click += new System.EventHandler(this.l_tutruc_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 23);
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
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 23);
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
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(596, 311);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(36, 21);
            this.giorv.TabIndex = 17;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(560, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 23);
            this.label13.TabIndex = 252;
            this.label13.Text = "giờ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(4, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(376, 466);
            this.label14.TabIndex = 253;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(384, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(404, 466);
            this.label16.TabIndex = 254;
            // 
            // danhsach
            // 
            this.danhsach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.danhsach.Controls.Add(this.list);
            this.danhsach.Controls.Add(this.lblso);
            this.danhsach.Controls.Add(this.tim);
            this.danhsach.Controls.Add(this.butRef);
            this.danhsach.Location = new System.Drawing.Point(3, 248);
            this.danhsach.Name = "danhsach";
            this.danhsach.Size = new System.Drawing.Size(377, 244);
            this.danhsach.TabIndex = 255;
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
            this.list.Size = new System.Drawing.Size(373, 212);
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
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // butInchitiet
            // 
            this.butInchitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInchitiet.BackColor = System.Drawing.Color.Transparent;
            this.butInchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchitiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butInchitiet.Image = ((System.Drawing.Image)(resources.GetObject("butInchitiet.Image")));
            this.butInchitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchitiet.Location = new System.Drawing.Point(386, 496);
            this.butInchitiet.Name = "butInchitiet";
            this.butInchitiet.Size = new System.Drawing.Size(74, 25);
            this.butInchitiet.TabIndex = 256;
            this.butInchitiet.Text = "&In chi phí";
            this.butInchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInchitiet.UseVisualStyleBackColor = false;
            this.butInchitiet.Click += new System.EventHandler(this.butInchitiet_Click);
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXml.AutoSize = true;
            this.chkXml.BackColor = System.Drawing.SystemColors.Control;
            this.chkXml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXml.Location = new System.Drawing.Point(4, 498);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 267;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = false;
            // 
            // chkToathuoc
            // 
            this.chkToathuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkToathuoc.AutoSize = true;
            this.chkToathuoc.BackColor = System.Drawing.SystemColors.Control;
            this.chkToathuoc.Checked = true;
            this.chkToathuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToathuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkToathuoc.Location = new System.Drawing.Point(683, 494);
            this.chkToathuoc.Name = "chkToathuoc";
            this.chkToathuoc.Size = new System.Drawing.Size(106, 17);
            this.chkToathuoc.TabIndex = 266;
            this.chkToathuoc.Text = "In kèm toa thuốc";
            this.chkToathuoc.UseVisualStyleBackColor = false;
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.SystemColors.Control;
            this.chkXem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXem.Location = new System.Drawing.Point(683, 510);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 265;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = false;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(536, 296);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 268;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(532, 399);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(253, 21);
            this.tenbs.TabIndex = 26;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label61
            // 
            this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label61.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label61.Location = new System.Drawing.Point(621, 291);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(76, 21);
            this.label61.TabIndex = 270;
            this.label61.Text = "Số ngoại trú";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNgoaitru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 530);
            this.Controls.Add(this.giorv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.chkToathuoc);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.butInchitiet);
            this.Controls.Add(this.danhsach);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.listdstt);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.ttlucrv);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.ngayrv);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cd_kemtheo);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.songaydt);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.tenttlucrv);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.tenketqua);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label16);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNgoaitru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNgoaitru_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNgoaitru_KeyDown);
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.danhsach.ResumeLayout(false);
            this.danhsach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNgoaitru_Load(object sender, System.EventArgs e)
		{
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlength_mabn - 2;
            user = m.user; bSothe_mabn = m.bsothe_mabn; bSovaovien = m.bSovaovien;
            //TU:28/06/2011 lay chi nhanh
            try { i_chinhanh = int.Parse(m.get_data("select chinhanh from " + user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0][0].ToString()); }
            catch { i_chinhanh = 0; }
            //end TU
            bMabn_tudong_tu_ServerInterNet_D24 = m.bMabn_tudong_tu_ServerInterNet_D24;
            bMabn_tudong = m.bMabn_tudong_tiepdon;
            bNgoaitru_congkham = m.bNgoaitru_congkham; bSoluutru_ngtru_nam = m.bSoluutru_ngtru_nam;
            bNgoaitru_bacsy = m.bNgoaitru_bacsy;
            bTraituyen = m.bTraituyen; bSothe_ngay_huong = m.bSothe_ngay_huong;
            traituyen.SelectedIndex=0;
            traituyen.Enabled = bTraituyen; lTraituyen = (bTraituyen) ? m.lTraituyen_noitru : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            bDonngoaitru_auto = m.bDonngoaitru_auto;
            bThongtinNguoithan = m.bThongtinNguoithan;
            iHaophi = d.iHaophi;
            bHaophi = m.bHaophi_thanhtoan; bHaophi_doituongvao = m.bHaophi_thanhtoan_doituongvao;
            s_nhomhaophi = m.sHaophi_thanhtoan;
            bTungay = m.bBHYT_tungay;
            tungay.Enabled = bTungay;
            bNgtru_dt_makp = m.bNgtru_dt_makp;
            dt_ngtru = m.dt_ngtru;
            makp_kho_dt = m.makp_kho_dt;
            iMavp_ngoaitru = m.iMavp_ngoaitru;
			pmat.Visible=m.Mabv_so==701424;
            lblLydo.Visible = !pmat.Visible;
            lydo.Visible = lblLydo.Visible;
            lblLydo.Text = m.sTrieuchung;
			bChandoan=m.bChandoan_icd10;
            bChandoan_kemtheo = m.bChandoan_kemtheo_icd10;
            //dausinhton.Visible = m.bDausinhton_khambenh;
            dausinhton.Enabled = m.bDausinhton_khambenh;
            //sovaovien.Enabled = !dausinhton.Visible;
            bSovaovien_tudong_ngt = m.bSovaovien_ngoaitru_tang_rieng;
            bSovaovien_tudong_nt = m.bSovaovien_ngoaitru_tang_chungNoitru;
            sovaovien.Enabled = !(bSovaovien_tudong_ngt || bSovaovien_tudong_nt);
			bDenngay_sothe=m.bDenngay_sothe;
			songaydtngoaitru=m.songaydtngoaitru; 
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Ngoaitru);
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			bChuyenkhoasan=m.bChuyenkhoasan;
			bDanhmuc_nhathuoc=m.bDanhmuc_nhathuoc;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
            bDichvu_vpkb = m.bDichvu_vpkb;
            bCongkham = m.bInchiphi_congkham;
            Congkham = d.Congkham(m.nhom_duoc);
            bInchitiet = bDonngoaitru_auto;
            butInchitiet.Enabled = bInchitiet;
            chkXem.Visible = bInchitiet;
            chkToathuoc.Visible = bInchitiet;
            bSothe_dkkcb = m.bSothe_dkkcb;
            if (bInchitiet)
            {
                bChuky = m.bChuky;
                chkXem.Checked = m.bPreview;
                sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom";
                sql += ", a.kcct, a.bhyt, a.kythuat";
                sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
                sql += " where a.id_loai=b.id and b.id_nhom=c.ma";
                dtvpin = m.get_data(sql).Tables[0];

                sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
                sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom,e.id as nhomin";
                sql += ", a.kcct, a.bhyt, a.kythuat";
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
                dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal));
                dsxmlin.Tables[0].Columns.Add("loaikythuat", typeof(string));
                dsxmlin.Tables[0].Columns.Add("khoanhapvien");
            }      
			tlbl.Text="";
			bXutri_noitru=m.bXutri_noitru_ngtr;
			bAdmin=m.bAdmin(i_userid);
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			b_bacsi=m.bsNgoaitru;
			i_chidinh=m.iChidinh;
            bHiends = m.bHiendanhsach;
			load_dm();
			b_Hoten=m.bHoten_gioitinh;
			bLuutru_Mabn=m.bSoluutru_Mabn;
			b_sovaovien=m.bSovaovien;
			phai.SelectedIndex=0;
            string s = m.Ngaygio;
            ngayvv.Text = s.Substring(0, 10); giovv.Text = s.Substring(11);
            ngayvk.Text = s.Substring(0, 10); giovk.Text = s.Substring(11);
			s_ngayvv="";
			s_ngayvk="";
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
//			sovaovien.Enabled=!b_sovaovien;
			cd_kkb.Enabled=m.bChandoan;
			cd_noichuyenden.Enabled=cd_kkb.Enabled;
			cd_chinh.Enabled=cd_kkb.Enabled;
			cd_kemtheo.Enabled=cd_kkb.Enabled;
            if (bSoluutru_ngtru_nam) soluutru.Enabled = false;
			else soluutru.Enabled=!bLuutru_Mabn;
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
		}

		private void load_dieutri()
		{
            //dieutri.Checked=m.get_data("select * from "+user+".benhandt where mangtr<>0 and mangtr="+l_maql).Tables[0].Rows.Count!=0;
            //l_dieutri.ForeColor=(dieutri.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tuvong()
		{
            //tuvong.Checked=m.get_data("select * from tuvong where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tuvong.ForeColor=(tuvong.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_thuthuat()
		{
            //thuthuat.Checked=m.get_data("select * from pttt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuthuat.ForeColor=(thuthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
			foreach(DataRow r in m.get_data("select distinct b.ten from "+user+".diungthuoc a,"+user+".d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) tlbl.Text+=r["ten"].ToString().Trim()+";";
            if (tlbl.Text!="")    tlbl.Text=
lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
		}

		private void load_chidinh()
		{
            //sql="select * from v_chidinh";
            //if (i_chidinh==1) sql+=" where mabn='"+s_mabn+"'";
            //else if (i_chidinh==2) sql+=" where maql="+l_maql;
            //else if (i_chidinh==3) sql+=" where idkhoa="+l_id;
            //chidinh.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_chidinh.ForeColor=(chidinh.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_vienphi()
		{
            //sql="select * from v_vpkhoa";
            //if (i_chidinh==1) sql+=" where mabn='"+s_mabn+"'";
            //else if (i_chidinh==2) sql+=" where maql="+l_maql;
            //else if (i_chidinh==3) sql+=" where idkhoa="+l_id;
            //vienphi.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_vienphi.ForeColor=(vienphi.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tainantt()
		{
            //tainantt.Checked=m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tainantt.ForeColor=(tainantt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
            listbv.DisplayMember = "MABV";
            listbv.ValueMember = "TENBV";
            listbv.DataSource = m.get_data("select mabv,tenbv,diachi from " + user + ".dmnoicapbhyt order by mabv").Tables[0];

			listdstt.DisplayMember="MABV";
			listdstt.ValueMember="TENBV";
			listdstt.DataSource=m.get_data("select MABV,TENBV,DIACHI from "+user+".dstt where mabv<>'"+m.Mabv+"' order by mabv").Tables[0];

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			tenkhoa.DisplayMember="TENKP";
			tenkhoa.ValueMember="MAKP";
            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0 ";
            if (i_chinhanh > 0) sql += " and chinhanh in(0,"+i_chinhanh +")";
            sql += " order by makp";
            tenkhoa.DataSource = m.get_data(sql).Tables[0];
            sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_chinhanh > 0) sql += " and chinhanh in(0," + i_chinhanh + ")";
            sql += " order by makp";
            DataTable dtkp = m.get_data(sql).Tables[0];
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
            tenkp.DataSource = dtkp;
            //if (tenkp.Items.Count > 0)
            //{
            //    tenkp.SelectedIndex = 0;
            //    makp.Text = tenkp.SelectedValue.ToString();
            //}

            //Tu:31/05/2011
            string maba = "";
            foreach (DataRow r in dtkp.Rows)
            {
                if (r["maba"].ToString() != "")
                    maba += r["maba"].ToString() + ",";
            }
            if (maba != "")
            {
                maba = maba.Trim(',');
                dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=2 and maba in(" + maba + ")order by maba").Tables[0];
            }
            else dtba = m.get_data("select * from " + user + ".dmbenhan_bv order by maba").Tables[0];
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			tenba.SelectedIndex=0;
            //end Tu
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

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a ";
            if (s_madoituong != "" && s_madoituong.Length>=2) sql += " where a.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
            sql += " order by a.madoituong";
            dtdt = m.get_data(sql).Tables[0];

			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
            tendoituong.DataSource = dtdt;
			tendoituong.SelectedIndex=-1;

			tenketqua.DisplayMember="TEN";
			tenketqua.ValueMember="MA";
            tenketqua.DataSource = m.get_data("select * from " + user + ".ketqua order by ma").Tables[0];
			tenketqua.SelectedIndex=-1;

            dtttlucrv = m.get_data("select * from " + user + ".ttxk where rakhoa=0 order by ma").Tables[0];
			DataRow dr=dtttlucrv.NewRow();
			dr["ma"]=0;
			dr["ten"]="Nhập viện";
			dtttlucrv.Rows.Add(dr);
			tenttlucrv.DisplayMember="TEN";
			tenttlucrv.ValueMember="MA";
			tenttlucrv.DataSource=dtttlucrv;
			tenttlucrv.SelectedIndex=-1;


            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";

			tenloaibv.DisplayMember="TEN";
			tenloaibv.ValueMember="MA";
            tenloaibv.DataSource = m.get_data("select * from " + user + ".loaibv order by ma").Tables[0];
			tenloaibv.SelectedIndex=-1;

			tenbv.DisplayMember="TENBV";
			tenbv.ValueMember="MABV";	

			gphaubenh.DisplayMember="TEN";
			gphaubenh.ValueMember="MA";
            gphaubenh.DataSource = m.get_data("select * from " + user + ".gphaubenh").Tables[0];

			cmbTaibien.DisplayMember="TEN";
			cmbTaibien.ValueMember="MA";
            cmbTaibien.DataSource = m.get_data("select * from " + user + ".taibien").Tables[0];
            load_makp();

            danhsach.Visible = bHiends;
            if (bHiends)
            {
                list.DisplayMember = "HOTEN";
                list.ValueMember = "MABN";
                list.ColumnWidths[0] = 40;
                list.ColumnWidths[1] = 60;
                list.ColumnWidths[2] = list.Width - 160;
                list.ColumnWidths[3] = 0;
                list.ColumnWidths[4] = 0;
                list.ColumnWidths[5] = 0;
                list.ColumnWidths[6] = 60;
                list.SetSensive(3, 'x', Color.DarkRed);
                list.SetSensive1(4, '?', Color.Red);
                list.SetSensive2(5, 'd', Color.Blue);
                load_ref();
                if (list.Items.Count == 0) danhsach.Visible = false;
                else list.Focus();
            }
		}

		private void load_mabv(string maloai)
		{
			if (maloai=="3")
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where substr(maloai,1,1)='2' and mabv like '" + mabv.Text + "%' and mabv<>'" + m.Mabv + "' order by mabv").Tables[0];
			else
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where mabv like '" + mabv.Text + "%' and mabv<>'" + m.Mabv + "' order by mabv").Tables[0];
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
			try
			{
				if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
				{
					if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
					SendKeys.Send("{Tab}{Home}");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
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
				this.Text=tenba.Text.Trim()+"<"+lan.Change_language_MessageText("Người cập nhật  :")+" "+s_userid.Trim()+" >";
				DataRow r=m.getrowbyid(dtba,"mavt='"+tenba.SelectedValue.ToString()+"'");
				if (r!=null) i_maba=int.Parse(r[0].ToString());
				else i_maba=0;
				if (i_maba!=0)
				{
                    sql = "select * from " + user + ".btdkp_bv where makp<>'01' and maba like '%" + i_maba.ToString().PadLeft(2, '0') + "%'";
                    if (s_makp != "")
                    {
                        string s = s_makp.Replace(",", "','");
                        sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                    }
                    if (i_chinhanh > 0) sql += " and chinhanh in(0," + i_chinhanh + ")";
					sql+=" order by makp";
					tenkp.DataSource=m.get_data(sql).Tables[0];
					tenkp.SelectedIndex=0;
                    makp.Text = tenkp.SelectedValue.ToString();
				}
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
				s_ngayvk="";
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
            nam = ""; if (bHiends) danhsach.Visible = false;
            int iCapso = 0;
			load_btdnn(0);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
            //if (mabn3.Text=="") return;
            //if (bQuanly_Theo_Chinhanh)
            //{
            //    mabn3.Text = mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');//.PadLeft(6,'0');
            //}
            //else
            //{
            //    mabn3.Text = mabn3.Text.PadLeft(6,'0');//.PadLeft(i_maxlength_mabn - 2, '0');
            //}
            //16/10/2013
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
                else if ((bMabn_tudong_theomay || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "")
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
                            else mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(6, '0');
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
                mabn3.Text = mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
            }
            else mabn3.Text = mabn3.Text.PadLeft(6, '0');
            //
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
			if (load_mabn())
			{
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn())
					{
                        if (!bAdmin && cd_chinh.Text != "" && mabs.Text != "") ena_but(false);
					}
					s_icd_noichuyenden=icd_noichuyenden.Text;
					s_icd_kkb=icd_kkb.Text;
					s_icd_chinh=icd_chinh.Text;
					s_icd_kemtheo=icd_kemtheo.Text;
				}
				if (bAdmin && sender!=null)
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
			foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
                nam = r["nam"].ToString();
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
				break;
			}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
            if (m.get_data("select * from " + user + ".benhanngtr where mabn='" + s_mabn + "' and ngayrv is null").Tables[0].Rows.Count == 1) load_vv_mabn();
			load_treeView();
			load_diungthuoc();
			return ret;
		}

		private void load_vv_maql(bool skip)
		{
            if (ngayvv.Text == "") return;
			ena_but(true);
			//emp_vv();
			emp_rv();
            if (!skip)
            {
                s_ngayvv= m.get_ngaykb(ngayvv.Text, l_maql);
                if (s_ngayvv != "")
                {
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                }
            }
			foreach(DataRow r in m.get_data("select * from "+user+".benhanngtr where maql="+l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvk=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    if (s_ngayvv == "") s_ngayvv = s_ngayvk;
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                    ngayvk.Text = s_ngayvk.Substring(0, 10);
                    giovk.Text = s_ngayvk.Substring(11);
				}
                l_matd = decimal.Parse(r["mavaovien"].ToString());
                tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
                makp.Text = r["makp"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                mabs.Text  = r["mabs"].ToString();
                mabs_Validated(null, null);

                if (r["ngayrv"].ToString() != "")
                {
                    s_ngayrk=m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                    ngayrv.Text = s_ngayrk.Substring(0, 10);
                    giorv.Text = s_ngayrk.Substring(11);
                    try
                    {
                        songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();
                    }
                    catch { }
                    tenketqua.SelectedValue = r["ketqua"].ToString();
                    cd_chinh.Text = r["chandoanrv"].ToString();
                    icd_chinh.Text = r["maicdrv"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    mabs_Validated(null, null);
                    tenttlucrv.SelectedValue = r["ttlucrv"].ToString();
                    if (tenttlucrv.SelectedValue.ToString() == "0")
                    {
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                    soluutru.Text = r["soluutru"].ToString();
                    bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                    taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                    if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                    giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                    if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".cdkemtheo where loai=4 and maql=" + l_maql + " order by stt").Tables[0].Rows)
                    {
                        cd_kemtheo.Text = r1["chandoan"].ToString();
                        icd_kemtheo.Text = r1["maicd"].ToString();
                        break;
                    }

                    if (loaibv.Enabled)
                    {
                        foreach (DataRow r1 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                        {
                            tenloaibv.SelectedValue = r1["loaibv"].ToString();
                            mabv.Text = r1["mabv"].ToString();
                            load_mabv(loaibv.Text);
                            tenbv.SelectedValue = mabv.Text;
                            s_mabv = mabv.Text;
                        }
                    }
                }
                if (!bAdmin && cd_chinh.Text != "" && mabs.Text != "") ena_but(false);
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
            l_maql = 0; l_matd = 0;
			emp_vv();
			emp_rv();
			foreach(DataRow r in m.get_data("select * from "+user+".benhanngtr where mabn='"+s_mabn+"' order by ngay desc").Tables[0].Rows)
			{
                l_matd = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				s_ngayvk=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvk.Text = s_ngayvk.Substring(0, 10);
                giovk.Text = s_ngayvk.Substring(11);
                makp.Text = r["makp"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                mabs_Validated(null,null);
                if (r["ngayrv"].ToString() != "")
                {
                    s_ngayrk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                    ngayrv.Text = s_ngayrk.Substring(0, 10);
                    giorv.Text = s_ngayrk.Substring(11);
                    try
                    {
                        songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();
                    }
                    catch { }
                    tenketqua.SelectedValue = r["ketqua"].ToString();
                    cd_chinh.Text = r["chandoanrv"].ToString();
                    icd_chinh.Text = r["maicdrv"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    mabs_Validated(null, null);
                    tenttlucrv.SelectedValue = r["ttlucrv"].ToString();
                    if (tenttlucrv.SelectedValue.ToString() == "0")
                    {
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                    soluutru.Text = r["soluutru"].ToString();
                    bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                    taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                    if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                    giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                    if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".cdkemtheo where loai=4 and maql=" + l_maql + " order by stt").Tables[0].Rows)
                    {
                        cd_kemtheo.Text = r1["chandoan"].ToString();
                        icd_kemtheo.Text = r1["maicd"].ToString();
                        break;
                    }
                    if (loaibv.Enabled)
                    {
                        foreach (DataRow r1 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                        {
                            tenloaibv.SelectedValue = r1["loaibv"].ToString();
                            mabv.Text = r1["mabv"].ToString();
                            load_mabv(loaibv.Text);
                            tenbv.SelectedValue = mabv.Text;
                            s_mabv = mabv.Text;
                        }
                    }
                }
				break;
			}
            s_ngayvv = m.get_ngaykb(ngayvv.Text, l_maql);
            if (s_ngayvv == "") s_ngayvv = ngayvk.Text + " " + giovk.Text;
            ngayvv.Text = s_ngayvv.Substring(0,10);
            giovv.Text = s_ngayvv.Substring(11);
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
            if (dausinhton.Visible)
            {
                foreach (DataRow r in m.get_data("select * from " + user + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
                {
                    mach.Text = r["mach"].ToString();
                    nhietdo.Text = r["nhietdo"].ToString();
                    huyetap.Text = r["huyetap"].ToString();
                    nang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    cao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    break;
                }
            }
			foreach(DataRow r in m.get_data("select * from "+user+".quanhe where maql="+l_maql).Tables[0].Rows)
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
			}
			if (quanhe.Text=="" && m.bMmyy(ngayvv.Text))
			{
				decimal maql=m.l_maql(ngayvv.Text,mabn2.Text+mabn3.Text);
				if (maql!=0)
				{
					foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".quanhe where maql="+maql).Tables[0].Rows)
					{
						quanhe.Text=r["quanhe"].ToString();
						qh_hoten.Text=r["hoten"].ToString();
						qh_diachi.Text=r["diachi"].ToString();
						qh_dienthoai.Text=r["dienthoai"].ToString();
					}
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
					foreach(DataRow r in m.get_data("select a.*,b.tenbv from "+user+".bhyt a left join "+user+".dmnoicapbhyt b on a.mabv=b.mabv where a.maql="+l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						s_noicap=r["mabv"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
                        manoidk.Text = r["mabv"].ToString();
                        noidk.Text = r["tenbv"].ToString();
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
					}
				}
			}
			if (dentu.Text=="1")
			{
				try
				{
					foreach(DataRow r in m.get_data("select * from "+user+".noigioithieu where maql="+l_maql).Tables[0].Rows)
					{
						cd_noichuyenden.Text=r["chandoan"].ToString();
						icd_noichuyenden.Text=r["maicd"].ToString();
						madstt.Text=r["mabv"].ToString();
						tendstt.Text=m.get_data("select tenbv from "+user+".dstt where mabv='"+madstt.Text+"'").Tables[0].Rows[0][0].ToString();
					}
				}
				catch{}
			}
			if (khamthai.Visible && m.bMmyy(ngayvv.Text))
			{
				bool bFound=false;
				foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
				{
					para1.Text=r["para"].ToString().Substring(0,2);
					para2.Text=r["para"].ToString().Substring(2,2);
					para3.Text=r["para"].ToString().Substring(4,2);
					para4.Text=r["para"].ToString().Substring(6,2);
					bFound=true;
				}
				if (!bFound)
				{
					foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".ttkhamthai where mabn='"+s_mabn+"' order by maql desc").Tables[0].Rows)
					{
						para1.Text=r["para"].ToString().Substring(0,2);
						para2.Text=r["para"].ToString().Substring(2,2);
						para3.Text=r["para"].ToString().Substring(4,2);
						para4.Text=r["para"].ToString().Substring(6,2);
					}
				}
			}
			if (pmat.Visible && m.bMmyy(ngayvv.Text))
			{
				foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".ttmat where maql="+l_maql).Tables[0].Rows)
				{
					mp.Text=r["mp"].ToString();
					mt.Text=r["mt"].ToString();
					nhanapp.Text=r["nhanapp"].ToString();
					nhanapt.Text=r["nhanapt"].ToString();
					break;
				}
			}
            if (lydo.Visible) lydo.Text = m.get_lydokham(l_maql).ToString().Trim();
			treeView1.Visible=true;
			load_tuvong();
			load_dieutri();
			load_thuthuat();
			load_tainantt();
			load_thuocdan();
			load_baohiem();
			if (i_chidinh<4)
			{
				load_chidinh();
				load_vienphi();
			}
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

		private void frmNgoaitru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					l_thuocbhyt_Click(sender,e);
					break;
				case Keys.F5:
					l_thuocdan_Click(sender,e);
					break;
				case Keys.F1:
					l_thuthuat_Click(sender,e);
					break;
				case Keys.F6:
					l_chidinh_Click(sender,e);
					break;
				case Keys.F7:
					l_vienphi_Click(sender,e);
					break;
				case Keys.F8:
					l_tuvong_Click(sender,e);
					break;
				case Keys.F9:
					l_tainantt_Click(sender,e);
					break;
				case Keys.F10:
					l_dieutri_Click(sender,e);
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
                    case Keys.T:
                        l_tutruc_Click(sender, e);
                        break;
					case Keys.L:
						break;
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
                noidk.Enabled = so.Substring(3, 1) == "1";
                if (bTraituyen) traituyen.Enabled = noidk.Enabled;
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
                    butDateBHYT.Enabled = (int.Parse(so.Substring(0, 2)) > 0 && bSothe_ngay_huong);//gam 07/09/2011
					denngay.Enabled=so.Substring(2,1)=="1";
                    if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                    else tungay.Enabled = false;
                    noidk.Enabled = so.Substring(3, 1) == "1";
                    if (bTraituyen) traituyen.Enabled = noidk.Enabled;
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
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
					sql="select * from "+user+".bhyt where mabn='"+s_mabn+"' and denngay>=to_timestamp('"+ngayvv.Text.Substring(0,10)+"','"+m.f_ngay+"')"+" order by maql desc";
				else
					sql="select * from "+user+".bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
                    if (bTungay && r["tungay"].ToString() != "")
                        tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (so.Substring(3,1)=="1") manoidk.Text=r["mabv"].ToString();
					s_noicap=r["mabv"].ToString();
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
                    foreach (DataRow r in m.get_data_nam_dec(nam, sql).Tables[0].Rows)
                    {
                        sothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (so.Substring(3, 1) == "1") manoidk.Text = r["mabv"].ToString();
                        s_noicap = r["mabv"].ToString();
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
                try
                {
                    if (so.Substring(3, 1) == "1")
                    {
                        if (manoidk.Text == "") manoidk.Text = m.Mabv;
                        noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                }
                catch { }
                //gam 22/09/2011 nếu bênh nhân tiếp đón trong ngày có nhập nơi giới thiệu thì load lên thông tin cơ quan y tế chuyển đến

                try
                {
                    foreach (DataRow r in m.get_data("select a.* from " + (user + m.mmyy(ngayvv.Text.Substring(0, 10))) + ".noigioithieu a inner join " + (user + m.mmyy(ngayvv.Text.Substring(0, 10))) + ".tiepdon b on a.maql=b.maql where b.mabn='" + s_mabn + "' and to_char(b.ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "' order by b.ngay desc ").Tables[0].Rows)
                    {
                        cd_noichuyenden.Text = r["chandoan"].ToString();
                        icd_noichuyenden.Text = r["maicd"].ToString();
                        madstt.Text = r["mabv"].ToString();
                        tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
                        dentu.Text = "1";
                        tendentu.SelectedValue = 1;
                        break;
                    }
                }
                catch { }
                //end gam
			}
			else
			{
				manoidk.Text=noidk.Text=sothe.Text=denngay.Text="";
				s_noicap=m.Mabv;
			}
		}

		private void ketqua_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenketqua.SelectedValue=ketqua.Text;
			}
			catch{}
		}

		private void ketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenketqua.SelectedIndex==-1) tenketqua.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void tenketqua_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ketqua.Text=tenketqua.SelectedValue.ToString();
				if (ketqua.Text=="5") tenttlucrv.SelectedValue="7";
			}
			catch{ketqua.Text="";}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (mabs.Text != "")
                {
                    DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r != null) tenbs.Text = r["hoten"].ToString();
                    else tenbs.Text = "";
                }
			}
			catch{}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

	

		private void ttlucrv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenttlucrv.SelectedValue=ttlucrv.Text;
			}
			catch{}
		}

		private void ttlucrv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenttlucrv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenttlucrv.SelectedIndex==-1) tenttlucrv.SelectedIndex=0;
				if (tenttlucrv.SelectedValue.ToString()=="7") l_tuvong_Click(null,null);
				SendKeys.Send("{Tab}");
			}
		}

		private void tenttlucrv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ttlucrv.Text=tenttlucrv.SelectedValue.ToString();
				if (ttlucrv.Text=="7") tenketqua.SelectedValue="5";
				else if (ketqua.Text=="5") tenketqua.SelectedIndex=0;
				loaibv.Enabled=ttlucrv.Text=="6";
				tenloaibv.Enabled=loaibv.Enabled;
				mabv.Enabled=loaibv.Enabled;
				tenbv.Enabled=loaibv.Enabled;
				khoa.Enabled=ttlucrv.Text=="0";
				tenkhoa.Enabled=khoa.Enabled;
			}
			catch{ttlucrv.Text="";}
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
					frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
					f.ShowDialog();
					if (f.m_mabv!="")
					{
						mabv.Text=f.m_mabv;
						load_mabv(loaibv.Text);
						tenbv.SelectedValue=mabv.Text;
					}
				}
				else if (mabv.Text!=s_mabv)
				{
					if (mabv.Text==m.Mabv)
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ vì trùng mã bệnh viện !"),s_msg);
						mabv.Text="";
						mabv.Focus();
						return;
					}
					load_mabv(loaibv.Text);
					tenbv.SelectedValue=mabv.Text;
					if (tenbv.Items.Count==0)
					{
						frmDmbv f=new frmDmbv(m,mabv.Text,loaibv.Text,true);
						f.ShowDialog();
						if (f.m_mabv!="")
						{
							mabv.Text=f.m_mabv;
							load_mabv(loaibv.Text);
							tenbv.SelectedValue=mabv.Text;
						}
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
					else icd_kkb.Focus();
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
			if (icd_chinh.Text!=s_icd_chinh)
			{
				if (icd_chinh.Text=="") cd_chinh.Text="";
				else cd_chinh.Text=m.get_vviet(icd_chinh.Text);
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
            if (bSothe_dkkcb)
            {
                if (sothe.Text.Trim().Length == _dai && _vitri != 0 && _sothe != "")
                {
                    manoidk.Text = sothe.Text.Substring(_vitri - 1, _sothe.Length);
                    try
                    {
                        noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                    catch { }
                }

                if (sothe.Text.Trim().Length >= 18 && (noidk.Text == "" || sothe.Text.Trim().Substring(sothe.Text.Trim().Length - 5) != manoidk.Text))
                {
                    manoidk.Text = sothe.Text.Trim().Substring(sothe.Text.Trim().Length - 5);
                    try
                    {
                        noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                    catch { }
                }
            } 
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
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
			hoten.Text="";
			ngaysinh.Text="";
			namsinh.Text="";
			tuoi.Text="";
			sonha.Text="";
			thon.Text="";
			cholam.Text="";
			tentqx.SelectedIndex=-1;
			tqx.Text="";
            l_maql = 0; l_matd = 0;
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			emp_rv();
			tenkhoa.SelectedIndex=-1;
            s_tungay1 = s_tungay2 = s_tungay3 = "";//gam 07/09/2011
		}

		private void emp_bhyt()
		{
			ngay1=ngay2=ngay3=tungay.Text=denngay.Text=noidk.Text=sothe.Text="";
            s_noicap = m.Mabv; traituyen.SelectedIndex = 0;
		}

		private void emp_vv()
		{
            string s = m.Ngaygio;
            ngayvv.Text = s.Substring(0, 10);
            giovv.Text = s.Substring(11);
            ngayvk.Text = s.Substring(0, 10);
            giovk.Text = s.Substring(11);
			s_ngayvv="";//ngayvv.Text;
			s_ngayvk="";//ngayvk.Text;
			//tendentu.SelectedIndex=-1;
			//tennhantu.SelectedIndex=-1;
            if (tendentu.Items.Count>1) tendentu.SelectedIndex = 1;
            if (tennhantu.Items.Count>1) tennhantu.SelectedIndex = 1;
			tendoituong.SelectedIndex=-1;
            lydo.Text = "";
			madoituong.Text="";
			quanhe.Text="";
			qh_hoten.Text="";
			qh_diachi.Text="";
			qh_dienthoai.Text="";
			sovaovien.Text="";
			cd_noichuyenden.Text="";
			icd_noichuyenden.Text="";
			madstt.Text="";
			tendstt.Text="";
            cao.Text = nang.Text = mach.Text = nhietdo.Text = huyetap.Text = "";
			cd_kkb.Text="";
			icd_kkb.Text="";
			s_icd_noichuyenden="";
			s_icd_kkb="";
			para1.Text="";para2.Text="";
			para3.Text="";para4.Text="";
            if (pmat.Visible)
			{
				mp.Text="";mt.Text="";
				nhanapp.Text="";nhanapt.Text="";
			}
		}

		private void emp_rv()
		{
			ngayrv.Text="";
            giorv.Text = "";
			s_ngayrk="";
			songaydt.Text="";
			cd_chinh.Text="";
			icd_chinh.Text="";
			cd_kemtheo.Text="";
			icd_kemtheo.Text="";
			bienchung.Checked=false;
			taibien.Checked=false;
			giaiphau.Checked=false;
			if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
			else soluutru.Text="";
			//tenbs.SelectedIndex=-1;mabs.Text = "";
			tenketqua.SelectedIndex=-1;
			tenttlucrv.SelectedIndex=-1;
			tenloaibv.SelectedIndex=-1;
			tenbv.SelectedIndex=-1;
			s_mabv="";
			s_icd_chinh="";
			s_icd_kemtheo="";
			khoa.Text="";
			tenkhoa.SelectedIndex=-1;
            if (s_mabs != "")
            {                
                mabs.Text = s_mabs;
                mabs_Validated(null, null);
            }
            else if (tenbs.Text != "")
            {
                DataRow dr1 = m.getrowbyid(dtbs, "hoten='" + tenbs + "'");
                if (dr1 != null)
                {
                    mabs.Text = dr1["ma"].ToString();
                    mabs_Validated(null, null);
                }
            }
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
            if (bHiends)
            {
                load_ref();
                danhsach.Visible = (list.Items.Count > 0);
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
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;

			if (dentu.Text=="1")
			{
				//if (icd_noichuyenden.Text=="" && cd_noichuyenden.Text!="") 
                if (icd_noichuyenden.Text == "")//gam 22/09/2011
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"),s_msg);
					icd_noichuyenden.Focus();
					return false;
				}
				//else if (cd_noichuyenden.Text=="" && icd_noichuyenden.Text=="")
                else if (icd_noichuyenden.Text == "")//gam 22/09/2011
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
                    if (bChandoan_kemtheo)
                    {
                        if (!m.Kiemtra_tenbenh(dticd, cd_noichuyenden.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
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

            if (bThongtinNguoithan && (quanhe.Text.Trim() == "" || qh_hoten.Text.Trim() == "") && int.Parse(tuoi.Text.Trim()) <= 6)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập thông tin người thân !"), s_msg);
                if (quanhe.Text.Trim() == "")
                    quanhe.Focus();
                else
                    qh_hoten.Focus();
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
                    if (sothe.Text == "")
                    {
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
					if (so.Substring(3,1)=="1" && (manoidk.Text=="" || noidk.Text==""))
					{
						noidk.Focus();
						return false;
					}
					if (so.Substring(3,1)=="1")
					{
						if (m.get_data("select * from "+user+".dmnoicapbhyt where mabv='"+manoidk.Text+"'").Tables[0].Rows.Count==0)
						{
							manoidk.Text="";
							noidk.Focus();
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
			if (bChandoan)
			{
				if (!m.Kiemtra_tenbenh(dticd,cd_kkb.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_kkb.Focus();
					return false;
				}
			}
			if (ngayrv.Text!="")
			{
				if (tenketqua.SelectedIndex==-1 || ketqua.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập kết quả điều trị !"),s_msg);
					ketqua.Focus();
					return false;
				}

				if (tenttlucrv.SelectedIndex==-1 || ttlucrv.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tình trạng ra viện !"),s_msg);
					ttlucrv.Focus();
					return false;
				}

				if (icd_chinh.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
					icd_chinh.Focus();
					return false;
				}

				if (cd_chinh.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"),s_msg);
					if(cd_chinh.Enabled) cd_chinh.Focus();
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
				if (soluutru.Text=="" && b_soluutru && soluutru.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập số lưu trữ !"),s_msg);
					soluutru.Focus();
					return false;
				}

				if (mabs.Text=="" || tenbs.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
					mabs.Focus();
					return false;
				}

				if (ttlucrv.Text=="6")
				{
					if (tenloaibv.SelectedIndex==-1 || loaibv.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển viện !"),s_msg);
						loaibv.Focus();
						return false;
					}

					if (tenbv.SelectedIndex==-1 || mabv.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển đến !"),s_msg);
						mabv.Focus();
						return false;
					}
				}
				if (ttlucrv.Text=="0")
				{
					if (khoa.Text=="" || tenkhoa.SelectedIndex==-1)
					{
						MessageBox.Show(lan.Change_language_MessageText("Khoa nhập viện !"),s_msg);
						khoa.Focus();
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
			if (ngayrv.Text!="")
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (ttlucrv.Text=="0" && bXutri_noitru && m.get_maql_benhanngtr(s_mabn,ngayvk.Text+" "+giovk.Text,false)==0)
				{
					string s_tenkp=m.bHiendien(s_mabn,1);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
						ttlucrv.Focus();
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,1);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
							ttlucrv.Focus();
							return false;
						}
					}
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
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = m.mabn_bhyt(mabn2.Text + mabn3.Text, sothe.Text);
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
            if (m.get_maql_benhanngtr(mabn2.Text+mabn3.Text, ngayvk.Text + " " + giovk.Text, false) == 0)
            {
                if (!bTiepdon)
                {
                    if (m.get_tiepdon(s_mabn, ngayvv.Text) == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                        butBoqua_Click(null,null);
                        return false;
                    }
                }
                sql = "select c.tenkp from " + user + ".benhanngtr a inner join " + user + ".btdkp_bv c on a.makp=c.makp";
                sql += " where a.mabn='"+mabn2.Text+mabn3.Text+"' and a.ttlucrv=0 and a.ngayrv is null";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + tmp.Rows[0]["tenkp"].ToString().Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                    butBoqua_Click(null, null);
                    return false;
                }
                if (m.bTuvong(mabn2.Text + mabn3.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                    return false;
                }
            }
            else if (bNgoaitru_bacsy && mabs.Text!="")
            {
                l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text,false);
                if (l_maql != 0)
                {
                    string stime = "'dd/mm/yyyy hh24:mi'",ngay=m.ngayhienhanh_server,mabsc="'"+mabs.Text+"','";
                    sql = "select * from " + user + ".bsnghi where " + m.for_ngay("tu", stime) + "<=to_date('" + ngay + "'," + stime + ")";
                    sql += " and " + m.for_ngay("den", stime) + ">=to_date('" + ngay + "'," + stime + ")";
                    sql += " and mabsc='"+mabs.Text+"'";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                        mabsc += r["mabs"].ToString()+"','";
                    sql = "select a.*,b.hoten as tenbs from " + user + ".benhanngtr a,"+user+".dmbs b ";
                    sql +=" where a.mabs=b.ma and a.maql=" + l_maql + " and mabs in (" + mabsc.Substring(0,mabsc.Length-2) + ")";
                    if (m.get_data(sql).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bạn có quyền điều chỉnh !"), LibMedi.AccessData.Msg);
                        butBoqua.Focus();
                        return false;
                    }
                }
            }
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            bUpdate = true;
			s_mabn=mabn2.Text+mabn3.Text;
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, true);
            if (l_matd == 0)
            {
                //l_matd = m.get_tiepdon(s_mabn, ngayvv.Text+" "+giovv.Text);
                l_matd=m.get_mavaovien_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);//Thuy 08.08.2012 lấy mã vào viện chứ không lấy maql như đã làm trước đây//
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_matd,l_maql, makp.Text, ngayvv.Text+" "+giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Ngoaitru, 0);
                        if (int.Parse(so.Substring(0, 2)) > 0)
                        {
                            if (!m.upd_bhyt(ngayvv.Text,s_mabn, l_matd, sothe.Text, denngay.Text,manoidk.Text,0,tungay.Text,s_tungay1,s_tungay2,s_tungay3,traituyen.SelectedIndex))//gam 07/09/2011
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                return;
                            }
                        }			
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Ngoaitru, l_maql);
            }
            int itable = m.tableid("","benhanngtr");
            if (m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false) != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvk.Text + " " + giovk.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_kkb.Text + "^" + icd_kkb.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
            else
            {
                m.upd_eve_tables(itable, i_userid, "ins");
                if (bNgoaitru_congkham)
                {
                    decimal _id=v.get_id_chidinh;
                    decimal _dongia=m.tienkham(madantoc.Text=="55",iMavp_ngoaitru,int.Parse(madoituong.Text),m.field_gia(madoituong.Text));
                    v.upd_chidinh(_id, s_mabn, l_matd, l_maql, 0, ngayvk.Text + " " + giovk.Text, v.iNgoaitru, makp.Text, int.Parse(madoituong.Text), iMavp_ngoaitru, 1, _dongia, 0, i_userid, 0, 0, _id, (icd_chinh.Text != "") ? icd_chinh.Text : icd_kkb.Text,(cd_chinh.Text != "") ? cd_chinh.Text : cd_kkb.Text, mabs.Text,2,"");
                }
            }
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
           //  D19 - Số lưu trữ ngoại trú tăng tự động theo năm ";
            // //Cap so luu tru phong kham: dung chung ngoai tru
            if (m.bSoluutru_ngtru_nam && soluutru.Text == "")
            {
                soluutru.Text = m.get_capid((int)LibMedi.ma_table_capid.Soluutru_ngtru_nam, ngayrv.Text.Substring(8, 2)).ToString().PadLeft(10, '0');
                soluutru.Update();
            }
            //Tu:28/06/2011 soluutru tang tu dong neu check option D28
            else if (m.bSoluutruPK_PL_NGT_tudong && soluutru.Text == "")
            {
                string s_mmyy = "";
                s_mmyy = DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0');
                decimal l_idluutru = m.get_capid((int)LibMedi.ma_table_capid.SoluutruPK_PL_NGT_tudong, s_mmyy);//m.get_capid(200, s_mmyy);
                s_soluutru = i_chinhanh.ToString().PadLeft(2, '0') + s_mmyy + l_idluutru.ToString().PadLeft(6, '0');
                soluutru.Text = s_soluutru;
            }


            if (!m.upd_benhanngtr(s_mabn, l_matd, l_maql, makp.Text, ngayvk.Text + " " + giovk.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_kkb.Text, icd_kkb.Text, sovaovien.Text, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
            if (soluutru.Text.Trim() != "")
            {
                m.execute_data("update " + user + ".benhanngtr set soluutru='" + soluutru.Text + "' where maql=" + l_maql + "");
            }
            m.execute_data("update " + user + ".benhanngtr set mabs='" + mabs.Text + "' where maql=" + l_maql);
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,manoidk.Text,0,tungay.Text,ngay1,ngay2,ngay3,traituyen.SelectedIndex))
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
            if (dausinhton.Visible) m.upd_dausinhton(l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nang.Text != "") ? decimal.Parse(nang.Text) : 0, (cao.Text != "") ? decimal.Parse(cao.Text) : 0,0);
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
            if (pmat.Visible) m.upd_ttmat(l_maql, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
            if (lydo.Text != "") m.upd_lydokham(l_maql, lydo.Text);
            if (bHiends) m.execute_data("update " + user+m.mmyy(ngayvv.Text) + ".tiepdon set done='x' where noitiepdon<0 and mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.ToString().Substring(0, 10) + "' and makp='" + makp.Text + "'");
			if (ngayrv.Text!="")
			{
				if (tenttlucrv.SelectedValue.ToString()=="7") 
				{
					if (m.get_data("select * from "+user+".tuvong where maql="+l_maql).Tables[0].Rows.Count==0)
						l_tuvong_Click(null,null);
				}
				DataTable dt1=m.get_data_nam_dec(nam,"select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.pttt where maql="+l_maql+" order by ngay desc,id desc").Tables[0];
				if (dt1.Rows.Count!=0)
				{
					string s_ngaypt=dt1.Rows[0][0].ToString();
					if (!m.bNgaygio(ngayrv.Text+" "+giorv.Text,s_ngaypt))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không được nhỏ hơn ngày phẫu thuật - thủ thuật !")+"\n"+s_ngaypt,LibMedi.AccessData.Msg);
						ngayrv.Focus();
						return;
					}
				}
             

				if (!m.upd_benhanngtr(l_maql,ngayrv.Text+" "+giorv.Text,int.Parse(ketqua.Text),int.Parse(ttlucrv.Text),cd_chinh.Text,icd_chinh.Text,mabs.Text,(bienchung.Checked)?1:0,(taibien.Checked)?int.Parse(cmbTaibien.SelectedValue.ToString()):0,(giaiphau.Checked)?int.Parse(gphaubenh.SelectedValue.ToString()):0,soluutru.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra viện !"),s_msg);
					return;
				}
				if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
				else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=4 and maql="+l_maql);
				if (loaibv.Enabled && loaibv.Text!="") m.upd_chuyenvien(l_maql,mabv.Text,int.Parse(loaibv.Text));
				else m.execute_data("delete from "+user+".chuyenvien where maql="+l_maql);
				if (ttlucrv.Text=="0" && bXutri_noitru)	upd_noitru(so);
			}
			if (ngayvv.Text+" "+giovv.Text!=ngayvk.Text+" "+giovk.Text) m.upd_ngaykb(l_maql,s_mabn,ngayvv.Text+" "+giovv.Text);
			if (sender!=null)
			{
				ena_but(false);
				butTiep.Focus();
			}
		}

		private void upd_noitru(string so)
		{
			decimal l_mangtru=l_maql;
            bool bNew = m.get_maql(1, s_mabn, khoa.Text, ngayrv.Text + " " + giorv.Text, false) == 0;
            if (bNew)
            {
                string s_tenkp = m.bHiendien(s_mabn, 1);
                if (s_tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được,phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                    return;
                }
            }
            l_maql = m.get_maql(1, s_mabn, khoa.Text, ngayrv.Text + " " + giorv.Text, true);
            int itable = m.tableid("", "benhandt");
            if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".benhandt", "maql=" + l_maql));
            }
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if(m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, mabs.Text, (bSovaovien) ? "" : sovaovien.Text, 1, i_userid,true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap,0,tungay.Text,ngay1,ngay2,ngay3,traituyen.SelectedIndex))
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
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=1 and maql="+l_maql);
			m.upd_sukien(ngayvv.Text,s_mabn,l_matd,LibMedi.AccessData.Nhanbenh,l_maql);
            m.upd_xutrikbct(ngayvv.Text, l_mangtru, "", khoa.Text);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
            if (bNew)
            {
                decimal tmpid = m.get_id_hiendien_do_cdvv(s_mabn, l_maql, "01");
                decimal l_idhiendien = (tmpid == 0) ? m.get_id(l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text) : tmpid;//tinh them gio
                m.upd_hiendien(l_idhiendien, s_mabn, l_matd, l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text, ngayrv.Text + " " + giorv.Text, "", mabs.Text, icd_chinh.Text, "01", 0, 0);
            }
		}

		private void ena_but(bool ena)
		{
            if (bInchitiet) butInchitiet.Enabled = !ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            ena_but(false);
            butTiep.Focus();
		}

		private void nhantu_TextChanged(object sender, System.EventArgs e)
		{
			nhantu.Text=nhantu.Text;
		}

		private void load_tiepdon(string m_ngay,bool skip,bool noitiepdon)
		{
            if (!m.bMmyy(m.mmyy(m_ngay))) return;
            string xxx = user + m.mmyy(m_ngay);
			sql="select * from "+xxx+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (noitiepdon) sql += " and noitiepdon<0";
            sql += " order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
                if (noitiepdon)
                {
                    try
                    {                        
                        tenkp.SelectedValue = r["makp"].ToString();
                        makp.Text = r["makp"].ToString();
                    }
                    catch { }
                }
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
                l_maql = decimal.Parse(r["maql"].ToString());
                //l_matd = l_maql;
                l_matd = decimal.Parse(r["mavaovien"].ToString());//Thuy 08.08.2012 lấy mavaovien thay vì lấy maql như trước
				break;
			}
			if (l_maql!=0)
			{
				emp_bhyt();
				foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
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
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						manoidk.Text=s_noicap=r["mabv"].ToString();
                        if (manoidk.Text == "") manoidk.Text = m.Mabv;
                        noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
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
					foreach(DataRow r in m.get_data("select * from "+xxx+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
					{
						para1.Text=r["para"].ToString().Substring(0,2);
						para2.Text=r["para"].ToString().Substring(2,2);
						para3.Text=r["para"].ToString().Substring(4,2);
						para4.Text=r["para"].ToString().Substring(6,2);
					}
				}
			}
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
			TreeNode node;
			foreach(DataRow r in m.get_data("select ngay,chandoan from "+user+".benhanngtr where mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
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
					l_maql=m.get_maql_benhanngtr(s_mabn,ngay,false);
					if (l_maql!=0)
					{
						ngayvk.Text=ngay.Substring(0,10);
                        giovk.Text = ngay.Substring(11);
                        s_ngayvv = m.get_ngaykb(ngayvv.Text+" "+giovv.Text, l_maql);
                        if (s_ngayvv == "") s_ngayvv = ngayvk.Text + " " + giovk.Text;
                        ngayvv.Text = s_ngayvv.Substring(0, 10);
                        giovv.Text = s_ngayvv.Substring(11);
                        load_vv_maql(true);
					}
				}
				catch{}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (tenbv.SelectedIndex!=-1 && ngayrv.Text!="")
			{
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
				r1["ngayvao"]=ngayvv.Text+" "+giovv.Text;
				r1["ngayra"]=ngayrv.Text+" "+giorv.Text;
				dsxml.Tables[0].Rows.Add(r1);
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,tenbv.Text,"rptGiaycv.rpt");
				f.ShowDialog();
			}
		}

		private void l_tuvong_Click(object sender, System.EventArgs e)
		{
			if (ttlucrv.Text!="7") return;
			s_mabn=mabn2.Text+mabn3.Text;
			if (ngayrv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày ra viện !"),s_msg);
				ngayrv.Focus();
				return;
			}
			tenketqua.SelectedValue="5";
			tenttlucrv.SelectedValue="7";
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayrv.Text + " " + giorv.Text, songaydt.Text, l_maql, i_userid);
			f.ShowDialog();
			load_tuvong();
		}

		private void l_thuthuat_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }*/
            frmPttt f = new frmPttt(m, makp.Text, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, "", ngayvk.Text + " " + giovk.Text, cd_kkb.Text, icd_kkb.Text, "T", i_userid, ngayrv.Text + " " + giorv.Text, "", "",l_maql,l_matd,0,1,true);
			f.ShowDialog(this);
			load_thuthuat();		
		}

        private void load_makp()
        {
            try
            {
                makp.Text = tenkp.SelectedValue.ToString();
                if (b_bacsi)
                {
                    dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") and makp='" + makp.Text + "'" + " order by ma").Tables[0];
                    if (dtbs.Rows.Count == 0)
                        dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
                }
                else dtbs  = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
                if (s_mabs != "")
                {                    
                    mabs.Text = s_mabs;
                    mabs_Validated(null, null);//
                }
                listBS.DataSource = dtbs;
            }
            catch { makp.Text = ""; }
        }

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == tenkp) load_makp();
		}

		private void giaiphau_CheckStateChanged(object sender, System.EventArgs e)
		{
			gphaubenh.Visible=giaiphau.Checked;
		}

		private void l_tainantt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }*/
			frmTainantt f=new frmTainantt(m,l_maql,s_mabn,ngayvv.Text+" "+giovv.Text,hoten.Text,namsinh.Text,tennn.Text,sonha.Text.Trim()+" "+thon.Text,i_userid,s_makp,nam);
			f.ShowDialog();
			load_tainantt();
		}

		private void taibien_CheckStateChanged(object sender, System.EventArgs e)
		{
			cmbTaibien.Visible=taibien.Checked;		
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
			listdstt.BrowseToText(tendstt,madstt,ngayvk,madstt.Location.X+265,madstt.Location.Y+madstt.Height+26,madstt.Width+tendstt.Width+91,madstt.Height);
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
                if (bChandoan || icd_kkb.Text == "" || icd_kkb.Text.Trim() == u00)
				{
					Filt_ICD(cd_kkb.Text);
					listICD.BrowseToICD10(cd_kkb,icd_kkb,ngayrv,icd_chinh.Location.X-406,pvaovien.Location.Y+pvaovien.Height-icd_kkb.Height-3,icd_kkb.Width+cd_kkb.Width+407,icd_kkb.Height);
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
					listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,icd_kkb,icd_chinh.Location.X-406,pvaovien.Location.Y-9+pvaovien.Height-icd_noichuyenden.Height-16,icd_noichuyenden.Width+cd_noichuyenden.Width+407,icd_noichuyenden.Height);
				}
			}
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
                if (bChandoan || icd_chinh.Text == "" || icd_chinh.Text.Trim() == u00)
				{
					Filt_ICD(cd_chinh.Text);
					listICD.BrowseToICD10(cd_chinh,icd_chinh,icd_kemtheo,icd_chinh.Location.X-406,icd_chinh.Location.Y-1+icd_chinh.Height-1,icd_chinh.Width+cd_chinh.Width+2+405,icd_chinh.Height);
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
					listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,mabs,icd_kemtheo.Location.X-406,icd_kemtheo.Location.Y+icd_kemtheo.Height-2,icd_kemtheo.Width+cd_kemtheo.Width+407,icd_kemtheo.Height);
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
			if (this.ActiveControl==tenkhoa)
			{
				khoa.Text=tenkhoa.SelectedValue.ToString();
			}
		}

		private void l_vienphi_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }
             * */
            dllvpkhoa_chidinh.frmChonthongsovp f1 = new dllvpkhoa_chidinh.frmChonthongsovp(m, makp.Text + ",");
			f1.ShowDialog(this);
			if (f1.s_makp!="")
			{
                dllvpkhoa_chidinh.frmChonvpk f = new dllvpkhoa_chidinh.frmChonvpk(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, f1.s_ngay, f1.s_makp, f1.s_tenkp, int.Parse(madoituong.Text), l_matd, l_maql, 0, i_userid, user + ".benhanngtr", f1.i_buoi, sothe.Text);
				f.ShowDialog(this);
				load_vienphi();
			}
		}

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }*/
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
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvk.Text + " " + giovk.Text, makp.Text, tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_matd, l_maql, 0, i_userid, user + ".benhanngtr", sothe.Text, nam, 2, mabs.Text, (cd_chinh.Text != "") ? cd_chinh.Text : cd_kkb.Text, (icd_chinh.Text != "") ? icd_chinh.Text : icd_kkb.Text, (traituyen.SelectedIndex < 0) ? 0 : traituyen.SelectedIndex);
            f.NgayVaoVien = ngayvv.Text;
			f.ShowDialog(this);
			load_chidinh();
		}

		private void load_thuocdan()
		{
            //if (bDanhmuc_nhathuoc) sql="select * from d_thuocbhytll where nhom="+m.nhom_nhathuoc+" and maql="+l_maql;
            //else sql="select * from d_toathuocll where maql="+l_maql;
            //thuocdan.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_thuocdan.ForeColor=(thuocdan.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_baohiem()
		{
            //thuocbhyt.Checked=m.get_data("select * from d_thuocbhytll where nhom="+m.nhom_duoc+" and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuocbhyt.ForeColor=(thuocbhyt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_kemtheo()
		{
            //kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=4 and id="+l_id).Tables[0].Rows.Count!=0;
            //l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void l_thuocbhyt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }
             * */
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            if (icd_kkb.Text == "" && cd_kkb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (icd_kkb.Text == "" && cd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (cd_kkb.Text == "" && icd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh vào !"), s_msg);
                if (cd_kkb.Enabled) cd_kkb.Focus();
                else icd_kkb.Focus();
                return;
            }
            if (!m.Kiemtra_maicd(dticd, icd_kkb.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                icd_kkb.Focus();
                return;
            }
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }				
			LibDuoc.AccessData d=new LibDuoc.AccessData();
			string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
			sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			DataTable dt=m.get_data(sql).Tables[0];
			foreach(DataRow r in dt.Rows)
			{
				s_mmyy=r["mmyy"].ToString();
                if (d.get_data("select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
			}
            bool bDieutringtr = m.get_data("select * from "+user+".d_dmphieu where id=8").Tables[0].Rows.Count > 0;
            if (bDieutringtr)
            {
                if (!kiemtra(8)) return;
            }
            else
            {
                if (madoituong.Text != "1") if (!kiemtra(6)) return;
            }
            //
            bXemlai_toa = false;
            if (m.bNgayhienhanh_thuoc_chidinh && ngayvv.Text != m.ngayhienhanh_server)
            {
                if (m.get_data_mmyy("select mabn,id from xxx.d_thuocbhytll where maql=" + l_maql + " and nhom=" + m.nhom_duoc,ngayvv.Text,m.ngayhienhanh_server.Substring(0,10),true).Tables[0].Rows.Count != 0)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn xem lại toa đã phát không") + "\n" + "Kích NO: Cho phép cấp toa mới.\nKích YES: chỉ xem lại toa cũ.", "Cấp toa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    bXemlai_toa = dlg == DialogResult.Yes;
                }
            }
            frmBaohiem f = new frmBaohiem(bDieutringtr, s_mabn, (bDieutringtr) ? 8 : (madoituong.Text == "1") ? 5 : 6, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_duoc, i_userid, "Đơn thuốc dược phát", l_matd, l_maql, hoten.Text, namsinh.Text + "^" + ngaysinh.Text, sothe.Text, tenkp.Text, tenbs.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, int.Parse(madoituong.Text), makp.Text, mabs.Text, tendoituong.Text, cholam.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "-" + tenquan.Text.Trim() + "-" + tentinh.Text.Trim(), nam, user + ".bhyt", (bDieutringtr) ? 2 : 3, s_noicap, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen.SelectedIndex, ngay1, ngay2, ngay3, phai.Text,bXemlai_toa,0);
			f.ShowDialog(this);
			load_baohiem();
		}

        private bool kiemtra(int loai)
        {
            string s = "";
            foreach (DataRow r in m.get_data("select madoituong from "+user+".d_dmphieu where id=" + loai).Tables[0].Rows)
                s = r["madoituong"].ToString().Trim();
            if (s != "")
            {
                if (m.get_data("select * from "+user+".d_dmphieu where id=" + loai + " and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng")+"\n" + tendoituong.Text + "\n"+lan.Change_language_MessageText("Không được cấp thuốc !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            return true;
        }

		private void l_thuocdan_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            /*
            if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ttlucrv=0 and ngayrv is null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã kết thúc điều trị !", LibMedi.AccessData.Msg);
                return;
            }*/
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            if (icd_kkb.Text == "" && cd_kkb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (icd_kkb.Text == "" && cd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (cd_kkb.Text == "" && icd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh vào !"), s_msg);
                if (cd_kkb.Enabled) cd_kkb.Focus();
                else icd_kkb.Focus();
                return;
            }
            if (!m.Kiemtra_maicd(dticd, icd_kkb.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                icd_kkb.Focus();
                return;
            }
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            string adiachi = sonha.Text.Trim() + " " + thon.Text.Trim() + ", " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
			if (bDanhmuc_nhathuoc)
			{
				LibDuoc.AccessData d=new LibDuoc.AccessData();
				string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
				sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
				DataTable dt=m.get_data(sql).Tables[0];
				foreach(DataRow r in dt.Rows)
				{
					s_mmyy=r["mmyy"].ToString();
                    if (d.get_data("select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc).Tables[0].Rows.Count > 0) break;
				}
                frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc mua ngoài", l_matd, l_maql, hoten.Text, namsinh.Text + "^" + ngaysinh.Text, sothe.Text, tenkp.Text, tenbs.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, 2, makp.Text, mabs.Text, tendoituong.Text, cholam.Text, adiachi.Trim().Trim(','), nam, user + ".bhyt", 5, s_noicap, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen.SelectedIndex, ngay1, ngay2, ngay3, phai.Text );//Khuong 16/11/2011
				f.ShowDialog(this);
				load_thuocdan();
			}
			else
			{
				frmToathuoc f=new frmToathuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,ngayvv.Text+" "+giovv.Text,makp.Text,tenkp.Text,mabs.Text,tenbs.Text,(cd_chinh.Text=="")?cd_kkb.Text:cd_chinh.Text,(icd_chinh.Text=="")?icd_kkb.Text:icd_chinh.Text,l_maql,i_userid,adiachi.Trim().Trim(','),nam);
				f.ShowDialog(this);
				load_thuocdan();
			}
		}

		private void l_kemtheo_Click(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="" || cd_kemtheo.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0) luu();
			else m.upd_cdkemtheo(l_maql,l_maql,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
			frmCdkemtheo f=new frmCdkemtheo(m,l_maql,l_maql,4,ngayvv.Text+" "+giovv.Text);
			f.ShowDialog();
			load_kemtheo();
		}

		private void luu()
		{
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            int itable = m.tableid("","benhanngtr");
            if (m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false) != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvk.Text + " " + giovk.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_kkb.Text + "^" + icd_kkb.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, true);
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text+" "+giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql, l_matd, makp.Text, ngayvv.Text+" "+giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Ngoaitru, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Ngoaitru, l_maql);
            }
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhanngtr(s_mabn, l_matd, l_maql, makp.Text, ngayvk.Text + " " + giovk.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_kkb.Text, icd_kkb.Text, sovaovien.Text, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_maql,l_maql,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
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

		private void l_dieutri_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            string adiachi = thon.Text + ", " + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text;
            adiachi = adiachi.Replace("Không xác định", "");
            frmKhambenh_nt f2 = new frmKhambenh_nt(m, makp.Text, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, mabn2.Text + mabn3.Text, hoten.Text, phai.SelectedIndex, namsinh.Text, mann.Text, ngayrv.Text + " " + giorv.Text, sonha.Text, adiachi, cholam.Text, matt.Text, maqu1.Text, maqu2.Text, mapxa1.Text, mapxa2.Text, tuoi.Text, loaituoi.SelectedIndex, l_maql, l_maql, makp.Text, ngayvk.Text + " " + giovk.Text, s_makp, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(madoituong.Text), sothe.Text, denngay.Text, madstt.Text, tendstt.Text, icd_noichuyenden.Text, cd_noichuyenden.Text, s_noicap, nam, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, mabs.Text, tenbs.Text, soluutru.Text, s_nhomkho, madantoc.Text, s_madoituong, tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text, tungay.Text, traituyen.SelectedIndex, ngay1, ngay2, ngay3,l_matd);
            f2.s_tuoi = tuoi.Text + "^" + loaituoi.Text;
            f2.s_dantoc = tendantoc.Text;
            f2.s_tungay = tungay.Text;
            f2.s_cholam = cholam.Text.Trim();
			f2.ShowDialog(this);
			if (f2.bravien) load_rk();
			load_dieutri();
		}

        private void l_tutruc_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvv.Text + " " + giovv.Text,false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, makp.Text + ",", false, s_nhomkho, this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, s_mabn, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, mabs.Text,s_madoituong);
                f1.ShowDialog(this);
            }
        }

		private void l_cls_Click(object sender, System.EventArgs e)
		{
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text + mabn3.Text, hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim());
            f.ShowDialog(this);
		}

		private bool get_ravien(string ngay)
		{
			if (m.songay(m.StringToDate(m.Ngayhienhanh.Substring(0,10)),m.StringToDate(ngay.Substring(0,10)),1)>songaydtngoaitru)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này kết thúc điều trị ngoại trú ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					string sMabs="0001";
					if (tenbs.Text =="" && dtbs.Rows.Count>0)
					{
                        mabs.Text = dtbs.Rows[0]["ma"].ToString();
                        sMabs = mabs.Text;
                        mabs_Validated(null, null);						
					}
                    l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, true);
					m.upd_benhanngtr(l_maql,ngay,1,3,cd_kkb.Text,icd_kkb.Text,sMabs,(bienchung.Checked)?1:0,(taibien.Checked)?int.Parse(cmbTaibien.SelectedValue.ToString()):0,(giaiphau.Checked)?int.Parse(gphaubenh.SelectedValue.ToString()):0,soluutru.Text);
					ngayvk.Text=ngay.Substring(0,10);
                    giovk.Text = ngay.Substring(11);
					cd_kkb.Text="";
					icd_kkb.Text="";
					return true;
				}
				else return false;
			}
			return false;
		}

		private void icd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

        private void load_rk()
        {
            foreach (DataRow r in m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql).Tables[0].Rows)
            {
                if (r["ngayrv"].ToString() != "")
                {
                    s_ngayrk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                    ngayrv.Text = s_ngayrk.Substring(0, 10);
                    giorv.Text = s_ngayrk.Substring(11);
                    try
                    {
                        songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();
                    }
                    catch { }
                    tenketqua.SelectedValue = r["ketqua"].ToString();
                    cd_chinh.Text = r["chandoanrv"].ToString();
                    icd_chinh.Text = r["maicdrv"].ToString();
                    mabs.Text  = r["mabs"].ToString();
                    mabs_Validated(null, null);
                    tenttlucrv.SelectedValue = r["ttlucrv"].ToString();
                    if (tenttlucrv.SelectedValue.ToString() == "0")
                    {
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                    soluutru.Text = r["soluutru"].ToString();
                    bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                    taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                    if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                    giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                    if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".cdkemtheo where loai=4 and maql=" + l_maql + " order by stt").Tables[0].Rows)
                    {
                        cd_kemtheo.Text = r1["chandoan"].ToString();
                        icd_kemtheo.Text = r1["maicd"].ToString();
                        break;
                    }

                    if (loaibv.Enabled)
                    {
                        foreach (DataRow r1 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                        {
                            tenloaibv.SelectedValue = r1["loaibv"].ToString();
                            mabv.Text = r1["mabv"].ToString();
                            load_mabv(loaibv.Text);
                            tenbv.SelectedValue = mabv.Text;
                            s_mabv = mabv.Text;
                        }
                    }
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ khám bệnh !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            if (tuoi.Text != "")
            {
                if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                {
                    tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                    loaituoi.SelectedIndex = 0;
                }
            }
            if (s_ngayvv != "")
            {
                if (ngayvv.Text != s_ngayvv.Substring(0, 10))
                {
                    if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu điều trị không hợp lệ so với khai báo hệ thống (" + songay.ToString() + ")!"), s_msg);
                        ngayvv.Focus();
                        s_ngayvv = "";
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
            string s = ngayvv.Text + " " + giovv.Text, s1 = ngayvk.Text + " " + giovk.Text;
            s_mabn = mabn2.Text + mabn3.Text;
            if (s != s_ngayvv)
            {
                l_maql = m.get_maql_benhanngtr(s_mabn,s, false);
                if (l_maql != 0)
                {
                    load_vv_maql(false);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    //ngayvk.Text = s1.Substring(0,10);
                    //giovk.Text = s1.Substring(11);
                    if (!bAdmin && cd_chinh.Text != "" && mabs.Text != "") ena_but(false);
                }
                else
                {
                    l_maql = m.get_maql(s_mabn,s);
                    if (l_maql != 0)
                    {
                        load_vv_maql(false);
                        ngayvv.Text = s.Substring(0, 10);
                        giovv.Text = s.Substring(11);
                    }
                    else
                    {
                        string s_tenkp = m.bHiendien_benhanngtr(s_mabn);
                        if (s_tenkp != "")
                        {
                            if (get_ravien(s)) return;
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                            butBoqua_Click(null, null);
                            return;
                        }
                        ena_but(true);
                        emp_vv();
                        emp_bhyt();
                        emp_rv();
                        ngayvv.Text = s.Substring(0,10);
                        giovv.Text = s.Substring(11);
                        ngayvk.Text = s.Substring(0,10);
                        giovk.Text = s.Substring(11);
                        if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false,false);
                    }
                }
                s_ngayvv = ngayvv.Text+" "+giovv.Text;
                s_ngayvk = ngayvk.Text+" "+giovk.Text;
            }
        }

        private void ngayvk_Validated(object sender, System.EventArgs e)
        {
            if (ngayvk.Text == "")
            {
                ngayvk.Focus();
                return;
            }
            ngayvk.Text = ngayvk.Text.Trim();
            if (ngayvk.Text.Length == 6) ngayvk.Text = ngayvk.Text + DateTime.Now.Year.ToString();
            if (ngayvk.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào viện !"), s_msg);
                ngayvk.Focus();
                return;
            }
            if (!m.bNgay(ngayvk.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayvk.Focus();
                return;
            }
            if (s_ngayvk != "")
            {
                if (ngayvk.Text != s_ngayvk.Substring(0, 10))
                {
                    if (!m.ngay(m.StringToDate(ngayvk.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu điều trị không hợp lệ so với khai báo hệ thống (" + songay.ToString() + ")!"), s_msg);
                        ngayvk.Focus();
                        s_ngayvk = "";
                        return;
                    }
                }
            }
        }

        private void giovk_Validated(object sender, EventArgs e)
        {
            string sgio = (giovk.Text.Trim() == "") ? "00:00" : giovk.Text.Trim();
            giovk.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovk.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giovk.Focus();
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            string s = ngayvk.Text+" "+giovk.Text, s1 = ngayvv.Text+" "+giovv.Text;
            if (!m.bNgaygio(s,s1))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày bắt đầu điều trị không được nhỏ hơn ngày khám bệnh !"), s_msg);
                ngayvk.Focus();
                return;
            }
            if (s != s_ngayvk)
            {
                l_maql = m.get_maql_benhanngtr(s_mabn,s, false);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvk.Text = s.Substring(0,10);
                    giovk.Text = s.Substring(11);
                    ngayvv.Text = s1.Substring(0,10);
                    giovv.Text = s1.Substring(11);
                }
                else
                {
                    /*
                    string s_tenkp = m.bHiendien(s_mabn, 2);
                    if (s_tenkp != "")
                    {
                        if (get_ravien(s)) return;
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        butBoqua_Click(null, null);
                        return;
                    }
                    else
                    {
                        s_tenkp = m.bNhapvien(s_mabn, 2);
                        if (s_tenkp != "")
                        {
                            if (get_ravien(s)) return;
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                            butBoqua_Click(null, null);
                            return;
                        }
                    }
                    */
                    emp_rv();
                }
                s_ngayvk = ngayvk.Text+" "+giovk.Text;
            }
        }

        private void ngayrv_Validated(object sender, System.EventArgs e)
        {
            if (ngayrv.Text == "")
            {
                butLuu.Focus();
                return;
            }
            ngayrv.Text = ngayrv.Text.Trim();
            if (ngayrv.Text.Length == 6) ngayrv.Text = ngayrv.Text + DateTime.Now.Year.ToString();
            if (ngayrv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ ra viện !"), s_msg);
                ngayrv.Focus();
                return;
            }
            if (!m.bNgay(ngayrv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayrv.Focus();
                return;
            }

            if (!m.ngay(m.StringToDate(ngayrv.Text.Substring(0, 10)), DateTime.Now, songay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                ngayrv.Focus();
                return;
            }
            try
            {
                songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvv.Text.Substring(0, 10)), 1).ToString();
                if (songaydt.Text == "0") songaydt.Text = "1";
            }
            catch { songaydt.Text = ""; }
            if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text;
            else if (soluutru.Text == "" && (b_sovaovien && !bSoluutru_ngtru_nam)) soluutru.Text = sovaovien.Text;
        }

        private void giorv_Validated(object sender, EventArgs e)
        {
            string sgio = (giorv.Text.Trim() == "") ? "00:00" : giorv.Text.Trim();
            giorv.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giorv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giorv.Focus();
                return;
            }
            if (!m.bNgaygio(ngayrv.Text+" "+giorv.Text, ngayvk.Text+" "+giovk.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không được nhỏ hơn ngày vào viện !"), s_msg);
                ngayrv.Focus();
                return;
            }
        }

        private void lydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                danhsach.Visible = false;
                mabn2.Focus();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) gan_mabn();
        }

        private void gan_mabn()
        {
            try
            {
                s_mabn = list.SelectedValue.ToString();
                if (s_mabn != "")
                {
                    mabn2.Text = s_mabn.Substring(0, 2);
                    mabn3.Text = s_mabn.Substring(2);
                    mabn3_Validated(null, null);
                    load_tiepdon(m.ngayhienhanh_server.Substring(0, 10), true, true);
                }
                else
                {
                    danhsach.Visible = false;
                    mabn2.Focus();
                }
            }
            catch 
            {
                danhsach.Visible = false;
            }
        }

        private void butRef_Click(object sender, System.EventArgs e)
        {
            load_ref();
            list.Focus();
        }

        private void load_ref()
        {
            string ngays = m.ngayhienhanh_server.Substring(0, 10);
            sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,";
            sql += "case when a.noitiepdon=16 then 'x' else 'y' end as noitiepdon,a.done,a.done as tt,";
            sql += " case when a.noitiepdon=16 then 'Tái khám' else '' end as tk from "+user+m.mmyy(ngays)+".tiepdon a," + user + ".btdbn b ";
            sql += " where a.mabn=b.mabn and (a.done is null or a.done in ('?','d')) ";
            sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + ngays.Substring(0, 10) + "'";
            sql += " and a.noitiepdon<0 ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by a.makp,a.ngay,a.mabn";
            list.DataSource = m.get_data(sql).Tables[0];
            lblso.Text = list.Items.Count.ToString();
        }

        private void list_DoubleClick(object sender, System.EventArgs e)
        {
            gan_mabn();
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

        private void noidk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbv.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listbv.Visible)
                {
                    listbv.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void noidk_TextChanged(object sender, System.EventArgs e)
        {
            Filt_noicap(noidk.Text);
            if (traituyen.Enabled) listbv.BrowseToText(noidk, manoidk, traituyen, noidk.Location.X, noidk.Location.Y + noidk.Height - 2, noidk.Width, noidk.Height);
            else if (dausinhton.Visible) listbv.BrowseToText(noidk, manoidk, mach, noidk.Location.X, noidk.Location.Y + noidk.Height - 2, noidk.Width, noidk.Height);
            else listbv.BrowseToText(noidk, manoidk, sovaovien, noidk.Location.X, noidk.Location.Y + noidk.Height - 2, noidk.Width, noidk.Height);
        }

        private void Filt_noicap(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listbv.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
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

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text);
            f.ShowDialog();
        }

        private void butInchitiet_Click(object sender, EventArgs e)
        {
            bIn = true;
            string ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            if (!bAdmin && ngayvv.Text != ngaysrv)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không quyền in lại!") + "\n" + lan.Change_language_MessageText("Ngày khám bệnh khác ngày hiện hành") + " " + ngaysrv, LibMedi.AccessData.Msg);
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            if (s_mabn == "" || ngayvv.Text == "") return;
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayvk.Text + " " + giovk.Text, false);
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin ngoại trú chưa cập nhật !"), LibMedi.AccessData.Msg);
                butLuu.Focus();
                return;
            }
            else if (butLuu.Enabled) butLuu_Click(sender, e);
            string _tenkp = m.inchiphipk(ngayvv.Text, l_maql);
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
            else if (bDonngoaitru_auto && sothe.Text != "")
            {
                sql = "update xxx.v_chidinh set paid=1 where where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                d.execute_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30);
            }
            m.upd_inchiphipk(mabn2.Text + mabn3.Text, l_maql, ngayvv.Text + " " + giovv.Text, makp.Text);
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
                        tmp = m.get_data(sql).Tables[0];
                        if (tmp.Rows.Count > 0)
                        {
                            d_id = decimal.Parse(tmp.Rows[0]["id"].ToString());
                            d_mmyy = mmyy;
                            break;
                        }
                    }
                }
            }
            string yyy = user + m.mmyy(ngayvv.Text);
            int stt = 1, itable;
            if (d_id != 0 && d_mmyy != "" && bDonngoaitru_auto && sothe.Text != "")
            {
                itable = d.tableid(d_mmyy, "bhytcls");
                d.execute_data("delete from " + user + d_mmyy + ".bhytcls where id=" + d_id);
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in d.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                    sql += " and madoituong=" + int.Parse(madoituong.Text);
                    d.execute_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
                m.execute_data("update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra + " where id=" + d_id);
            }
            else if (bDonngoaitru_auto && sothe.Text != "")
            {
                int i_nhom = m.nhom_duoc;
                d_id = d.get_id_bhyt;
                d_mmyy = m.mmyy(ngayvv.Text);
                if (!d.upd_bhytds(d_mmyy, s_mabn, hoten.Text, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytkb");
                d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                if (!d.upd_bhytkb(d_mmyy, d_id, i_nhom, ngayvv.Text, s_mabn, l_matd, l_maql, makp.Text, cd_chinh.Text, icd_chinh.Text, mabs.Text, sothe.Text, int.Parse(madoituong.Text), s_noicap, i_userid, 2,traituyen.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                m.execute_data("update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra + " where id=" + d_id);
                itable = d.tableid(d_mmyy, "bhytcls");
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in d.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                    sql += " and madoituong=" + int.Parse(madoituong.Text);
                    d.execute_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
        }

        private void inchiphi()
        {
            dsxmlin.Clear();
            bhyttra = bntra = 0;
            string s_noicap = "", s_chandoan = "", s_maicd = "", s_tenkp = "", s_tenbs = "", yyy = user + m.mmyy(ngayvv.Text), ngaybd = ngayvv.Text, nam = m.get_mabn_nam(s_mabn);
            int sokham = 0;
            sql = "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs ";
            sql += " from "+user+".benhanngtr a inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql += " left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd;
            sql += " and a.maql=" + l_maql;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                maso += r["maql"].ToString() + ",";
                s_maicd += r["maicd"].ToString().Trim() + ";";
                s_chandoan += r["chandoan"].ToString().Trim() + ";";
                s_tenkp += r["tenkp"].ToString().Trim() + ";";
                s_tenbs += r["tenbs"].ToString() + ";";
                foreach (DataRow r1 in m.get_data("select distinct chandoan,maicd from "+user+".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
            }
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            sql = "select 1 as id,a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong||' ['||b.tenhc||']' as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "a.cachdung,0 as makho,0 as manguon,0 as nhomcc,f.makp,h.tenkp,f.maphu as madoituong,x.doituong,h.makp,t.gianovat ";
            sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h," + user + ".d_doituong x";
            sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and f.makp=h.makp and f.maphu=x.madoituong ";
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;//"and to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            if (maso != "") sql += " and f.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            ds1 = m.get_data_mmyy(sql, ngaybd, ngayvv.Text, true);
            //
            sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong||' ['||b.tenhc||']' as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,g.makp,g.ten as tenkp,a.madoituong,x.doituong,g.makp,t.gianovat ";
            sql += " from xxx.d_thucxuat a," + user + ".d_dmbd b,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".d_doituong x";
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
            //ds1.Merge(m.get_data(sql));
            m.merge(ds1, d.get_data_mmyy(sql, ngaybd, ngayvv.Text, 30));

            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.makp,h.tenkp,a.madoituong,x.doituong,h.makp,a.dongia as gianovat ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".btdkp_bv h," + user + ".d_doituong x where a.mavp=b.id and a.makp=h.makp and a.madoituong=x.madoituong ";
            sql += " and a.mabn='" + s_mabn + "'";
            if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            else sql += " and a.mavaovien=" + l_matd;
            if (sothe.Text == "") sql += " and a.paid=0";
            ds1.Merge(d.get_data_mmyy(sql, ngaybd, ngayvv.Text, 30));
            DataSet dstmp = ds1.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "id,stt"));
            dsxmlin.Clear();
            DataRow r2;
            if (sothe.Text != "")
            {
                foreach (DataRow r in m.get_data("select b.tenbv, a.mabv from " + user + ".bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.sothe='" + sothe.Text + "'").Tables[0].Rows)
                {
                    s_noicap = r["tenbv"].ToString() + "^" + r["mabv"].ToString();
                    break;
                }
            }
            string dichso = "", s_ghichu = "";
            decimal mien = 0, tcsotien = 0;
            bool bMien = false;

            sql = "select a.ghichu from xxx.d_thuocbhytll a,xxx.bhytkb b";
            sql += " where a.id=b.id and a.ghichu<>''";
            sql += " and b.mabn='" + s_mabn + "' and b.mavaovien=" + l_matd;
            sql += " and b.maql=" + l_maql;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                s_ghichu += r["ghichu"].ToString().Trim() + ";";

            r2 = m.getrowbyid(dtdt, "mien=1 and madoituong=" + int.Parse(madoituong.Text));
            bMien = r2 != null;
            foreach (DataRow r in dstmp.Tables[0].Rows) tcsotien += decimal.Parse(r["sotien"].ToString());
            if (madoituong.Text == "1") bhyttra = tcsotien;
            else if (bMien) mien = tcsotien;
            else bntra = tcsotien;
            tcsotien += ((bCongkham) ? Congkham * sokham : 0);
            dichso = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
            if (dstmp.Tables[0].Rows.Count == 0)
            {
                m.updrec_ravien(dsxmlin, s_mabn, s_mabn, l_maql, 2, hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(madoituong.Text),
                tendoituong.Text, sothe.Text, 0, tungay.Text + "^" + denngay.Text, tendstt.Text, s_noicap, tenbs.Text, makp.Text, s_tenkp, ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                0, "", 0, "", 0, "", "", 0, 0, bhyttra, 0, (bCongkham) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, 0, false, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(madoituong.Text), 0, 0,0,traituyen.SelectedIndex,int.Parse("-1"),"");
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
                        m.updrec_ravien(dsxmlin, r["sttt"].ToString(), s_mabn, l_maql, decimal.Parse(r["sttt"].ToString()) + decimal.Parse(r["id"].ToString()), hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(r["madoituong"].ToString()),
                            r["doituong"].ToString(), sothe.Text, 0, tungay.Text + "^" + denngay.Text, tendstt.Text, s_noicap, tenbs.Text, r["makp"].ToString(), r["tenkp"].ToString(), ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                            int.Parse(r2["sttnhom"].ToString()), r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r["cachdung"].ToString(),
                            int.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(),
                            decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sotien"].ToString()),
                            bhyttra, 0, (bCongkham && int.Parse(r["madoituong"].ToString()) == int.Parse(madoituong.Text.ToString())) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, decimal.Parse(r["dongia"].ToString()), true, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(r["madoituong"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, decimal.Parse(r["sotien"].ToString()),traituyen.SelectedIndex, int.Parse(r2["kythuat"].ToString()),"");
                    }
                }
            }
            DateTime dt = d.StringToDate(ngayvv.Text.Substring(0, 10));
            string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
            decimal Bhyt_7cn = (m.getLetet(ngayvv.Text) || ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0, haophi = 0;
            int maphu = (madoituong.Text == "1" && sothe.Text != "") ? d.get_maphu_ngtru(sothe.Text, tcsotien, m.nhom_duoc) : 0, chitra;
            int _madt = 0;
            //Tu:29/06/2011 them cot tlchitra
            try
            {
                dsxmlin.Tables[0].Columns.Add("tlchitra", typeof(decimal));
            }
            catch { }//end
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
            foreach (DataRow r in dsxmlin.Tables[0].Select("", "madoituong,madt,sttnhom,ten"))
            {
                if (_madt != int.Parse(r["madt"].ToString()))
                {
                    tcsotien = ((bCongkham && int.Parse(r["madt"].ToString()) == int.Parse(madoituong.Text)) ? Congkham * sokham : 0);
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
                        r["tlchitra"] = chitra;//Tu:29/06/2011
                        r["bhyttra"] = tcsotien * chitra / 100;
                        r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                    }
                    else if (Bhyt_7cn != 0 && tcsotien > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn;
                        r["bntra"] = tcsotien - Bhyt_7cn;
                    }
                    else
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            r["tlchitra"] = chitra;//Tu:29/06/2011
                            r["bhyttra"] = tcsotien * chitra / 100;
                            r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                        }
                        else
                        {
                            r["bhyttra"] = tcsotien;
                            r["bntra"] = 0;
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen;
                            r["bntra"] = tcsotien - lTraituyen;
                        }
                    }
                }
                else
                {
                    r["bhyttra"] = 0;
                    r["bntra"] = tcsotien;
                }
                r["dichso"] = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
                r["haophi"] = haophi;
                r["tcsotien"] = zsum;
                bhyttra = decimal.Parse(r["bhyttra"].ToString());
                bntra = decimal.Parse(r["bntra"].ToString());
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
                if (dsxmlin.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsxmlin.Tables[0].Rows)
                    {
                        r2 = m.getrowbyid(dtbd, "nhomin in (1,2,3) and id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null) r["nguoinha"] = doiso.doithapphan(r["soluong"].ToString());
                    }
                    if (chkXem.Checked)
                    {
                        dllReportM.frmReport f1 = new dllReportM.frmReport(m, dsxmlin, s_tenkp, "rpt_toathuoc_kp.rpt");
                        f1.ShowDialog();
                        f1.Close();
                        f1.Dispose();
                    }
                    else print.Printer(m, dsxmlin, "rpt_toathuoc_kp.rpt", s_tenkp, 1);
                }
            }
        }

        private void traituyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }
        private void tenbs_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text);
                listBS.BrowseToICD10(tenbs, mabs, ttlucrv , mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
            }
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim().Replace("'", "''") + "%'";
            }
            catch { }
        }

        private void butDateBHYT_Click(object sender, EventArgs e)
        {
            frmNgayBHYT frm = new frmNgayBHYT(s_mabn, hoten.Text, ngayvv.Text, nam, tungay.Text, denngay.Text, sothe.Text);
            frm.ShowDialog();
            if (frm.v_Tungay != "")
                tungay.Text = frm.v_Tungay;
            if (frm.v_Denngay != "")
                denngay.Text = frm.v_Denngay;
            s_tungay1 = frm.v_Tungay1;
            s_tungay2 = frm.v_Tungay2;
            s_tungay3 = frm.v_Tungay3;
            tungay.Focus();
        }
	}
}
