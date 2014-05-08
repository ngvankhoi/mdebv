using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	public class frmKhambenh_nt : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
        private LibVienphi.AccessData v =new LibVienphi.AccessData();
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private string nam,user,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,sql,_makp,s_sothe,s_denngay,s_madstt,s_tendstt,s_icd_noichuyen,s_cd_noichuyen,s_madantoc,s_madoituong,sdiachi,stungay,ngay1,ngay2,ngay3;
        private int i_userid, i_mabv, i_bangoaitru, iChidinh, iTaikham, iMavp_taikham, traituyen, iTraituyen, i_khudt=0;
		private decimal l_id=0,l_maql=0,l_matd=0,l_mangtr,l_idngtr,d_id,lTraituyen=0;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtxutri=new DataTable();
        private DataSet dsxmlin = new DataSet();
        private DataTable dtbd = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtdt = new DataTable();
        private dichso.numbertotext doiso = new dichso.numbertotext();
        private FileStream fstr;
        //private System.IO.MemoryStream memo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox mabn2;
		private MaskedTextBox.MaskedTextBox mabn3;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox namsinh;
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
		private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butKetthuc;
        private int songay = 30, iTreem6, iTreem15, iKhamnhi, iloaituoi, i_dentu, i_nhantu, i_madoituong, iHaophi;
        private bool b_Hoten = false, bAdmin, bHiends, b_soluutru, bLuutru_Mabn, b_sovaovien, bXutri_noitru, bXutri_ngoaitru, bKhamthai, bTiepdon, bDanhmuc_nhathuoc, bDenngay_sothe, bChandoan, bChandoan_kemtheo, bSothe_mabn, bTaikham_chidinh;
		private System.Windows.Forms.CheckBox giaiphau;
		private System.ComponentModel.IContainer components=null;
        private decimal Congkham = 0, bhyttra, bntra;
        private bool b_khambenh, b_bacsi, b_trongngoai, b701424, bNgoaitru_bacsy, bDonngoaitru_auto, bIn, bDichvu_vpkb;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.ComboBox tennn;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label lphai;
		private System.Windows.Forms.Label lmann;
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
		private System.Windows.Forms.ComboBox cmbTaibien;
		private System.Windows.Forms.Label label9;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private LibList.List listdstt;
		private System.Windows.Forms.TreeView treeView1;
        private string s_icd_noichuyenden, s_icd_chinh, s_icd_kemtheo, s_mabv, s_noicap, s_chonxutri = "", s_ngayra, s_makpngtr, s_ngayvao, s_nhomkho, maso,d_mmyy;
		private System.Windows.Forms.TextBox cd_chinh;
		private LibList.List listICD;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private System.Windows.Forms.TextBox cd_noichuyenden;
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
		private System.Windows.Forms.Label label12;
		private MaskedBox.MaskedBox ngaysanh;
		private MaskedBox.MaskedBox kinhcc;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label55;
		private DataTable dticd=new DataTable();
        private string ssonha, sthon, scholam, smatt, smaqu1, smaqu2, smapxa1, smapxa2, stuoi, madoituong_hen;
		private System.Windows.Forms.ComboBox bnmoi;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label l_bnmoi;
		private System.Windows.Forms.TextBox sovaovien;
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
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox lydo;
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
        private ToolStripLabel tlbl;
        private MaskedBox.MaskedBox giovv;
        private Label label2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton10;
        private ToolStripSeparator toolStripSeparator9;
        private Panel hen;
        private CheckBox chkTiepdon;
        private TextBox hen_ghichu;
        private ComboBox hen_loai;
        private Label label32;
        private NumericUpDown hen_ngay;
        private Label label17;
		public bool bravien=false;
        private bool bTaikham_hen;
        private int Taikham_songay,i_sokham;
        private Panel dausinhton;
        private MaskedTextBox.MaskedTextBox cao;
        private Label label59;
        private MaskedBox.MaskedBox nhietdo;
        private MaskedTextBox.MaskedTextBox nang;
        private Label label5;
        private Label label41;
        private MaskedTextBox.MaskedTextBox huyetap;
        private Label label43;
        private MaskedTextBox.MaskedTextBox mach;
        private Label label44;
        private Label label45;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label7;
        private Button butInchitiet;
        private CheckBox chkToathuoc;
        private Label label60;
        private bool bCongkham, bInchitiet, bChuky;
        private bool bHaophi, bHaophi_doituongvao;
        private CheckBox chkXml;
        private CheckBox chkXem;
        private byte[] image;        
        private string s_nhomhaophi;
        private dllReportM.Print print = new dllReportM.Print();
        //TU:31/03/2011
        private string s_soluutru = "";
        private string s_mabs = "";
        private string s_tenbs = "";
        private string s_cd_chinh = "";
        private string s_icd_ch = "";
        private string s_sonha = "";
        private string m_maba = "";
        private decimal l_mavaovien = 0;
        private string s_manoiskkcb = "";
        private Button hen_in;
        private string s_tennoidkkcb = "";
        private int i_maxlength_mabn = 8;
        //
        //TU

        //GAM
        public string s_diachi = "";
        public string s_tuoi = "";
        public string s_dantoc = "";
        public string s_tungay = "";
        public string s_cholam = "";
        //GAM
        #endregion

        public frmKhambenh_nt(LibMedi.AccessData acc, string kp, string shoten, int userid, int mabv, bool sovaovien, bool soluutru, string mabn, string hten, int iphai, string nsinh, string smann, string ngayra, string sonha, string thon, string cholam, string matt, string maqu1, string maqu2, string mapxa1, string mapxa2, string tuoi, int loaituoi, decimal mangtr, decimal idngtr, string makpngtr, string ngayvao, string makp, int _dentu, int _nhantu, int _madoituong, string _sothe, string _denngay, string _madstt, string _tendstt, string _icd_noichuyen, string _cd_noichuyen, string _noicap, string _cd_chinh, string _icd_chinh, string _mabs, string _tenbs, string _soluutru, string _sonha, int _traituyen, int _khudt, decimal _mavaovien)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; traituyen = _traituyen;
            l_mangtr = mangtr; l_idngtr = idngtr;
            s_makp = makp; s_userid = shoten; i_userid = userid; s_soluutru = _soluutru;
            i_mabv = mabv; b_soluutru = soluutru; s_mabs = _mabs; s_tenbs = _tenbs;
            mabn2.Text = mabn.Substring(0, 2); s_noicap = _noicap; s_cd_chinh = _cd_chinh; s_icd_ch = _icd_chinh;
            mabn3.Text = mabn.Substring(2); _makp = kp; s_sothe = _sothe; s_denngay = _denngay; i_madoituong = _madoituong;
            hoten.Text = hten; namsinh.Text = nsinh; mann.Text = smann; s_makpngtr = makpngtr; s_sonha = _sonha;
            phai.SelectedIndex = iphai; s_ngayra = ngayra; s_ngayvao = ngayvao; s_madstt = _madstt; s_tendstt = _tendstt; s_icd_noichuyen = _icd_noichuyen; s_cd_noichuyen = _cd_noichuyen;
            ssonha = sonha; sthon = thon; scholam = cholam; smatt = matt; smaqu1 = maqu1; smaqu2 = maqu2;
            smapxa1 = mapxa1; smapxa2 = mapxa2; stuoi = tuoi; iloaituoi = loaituoi; i_dentu = _dentu; i_nhantu = _nhantu;
            i_khudt = _khudt;
            l_mavaovien = _mavaovien;
            l_matd = _mavaovien;
        }

		public frmKhambenh_nt(LibMedi.AccessData acc,string kp,string shoten,int userid,int mabv,bool sovaovien,bool bsoluutru,string mabn,string hten,int iphai,string nsinh,string smann,string ngayra,string sonha,string thon,string cholam,string matt,string maqu1,string maqu2,string mapxa1,string mapxa2,string tuoi,int loaituoi,decimal mangtr,decimal idngtr,string makpngtr,string ngayvao,string makp,int _dentu,int _nhantu,int _madoituong,string _sothe,string _denngay,string _madstt,string _tendstt,string _icd_noichuyen,string _cd_noichuyen,string _noicap,string _nam,string _cd_chinh,string _icd_chinh,string _mabs,string _tenbs,string _soluutru,string _nhomkho,string madantoc,string _smadoituong,string _diachi,string _tungay,int _traituyen,string _ngay1,string _ngay2,string _ngay3, decimal _mavaovien)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			l_mangtr=mangtr;l_idngtr=idngtr;
            v = new LibVienphi.AccessData(); ngay1 = _ngay1; ngay2 = _ngay2; ngay3 = _ngay3;
            s_makp = makp; s_userid = shoten; i_userid = userid; traituyen = _traituyen;
            i_mabv = mabv; b_soluutru = bsoluutru; stungay = _tungay; sdiachi = _diachi;
            mabn2.Text = mabn.Substring(0, 2); s_noicap = _noicap; s_madoituong = _smadoituong;
			mabn3.Text=mabn.Substring(2);_makp=kp;s_sothe=_sothe;s_denngay=_denngay;i_madoituong=_madoituong;
            hoten.Text = hten; namsinh.Text = nsinh; mann.Text = smann; s_makpngtr = makpngtr; s_madantoc = madantoc;
			phai.SelectedIndex=iphai;s_ngayra=ngayra;s_ngayvao=ngayvao;s_madstt=_madstt;s_tendstt=_tendstt;s_icd_noichuyen=_icd_noichuyen;s_cd_noichuyen=_cd_noichuyen;
            ssonha = sonha; sthon = thon; scholam = cholam; smatt = matt; smaqu1 = maqu1; smaqu2 = maqu2; nam = _nam;
			smapxa1=mapxa1;smapxa2=mapxa2;stuoi=tuoi;iloaituoi=loaituoi;i_dentu=_dentu;i_nhantu=_nhantu;
            cd_chinh.Text = _cd_chinh; icd_chinh.Text = _icd_chinh; mabs.Text = _mabs; tenbs.Text = _tenbs; soluutru.Text = _soluutru; s_nhomkho = _nhomkho;
            l_mavaovien = _mavaovien;
            l_matd = _mavaovien;
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
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhambenh_nt));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
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
            this.giaiphau = new System.Windows.Forms.CheckBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.lmann = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.dausinhton = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.nang = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.ngayvv = new MaskedBox.MaskedBox();
            this.giovv = new MaskedBox.MaskedBox();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.listdstt = new LibList.List();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.denngay = new MaskedBox.MaskedBox();
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
            this.sothe = new MaskedTextBox.MaskedTextBox();
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
            this.label53 = new System.Windows.Forms.Label();
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.gphaubenh = new System.Windows.Forms.ComboBox();
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
            this.label12 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.pmat = new System.Windows.Forms.Panel();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.hen = new System.Windows.Forms.Panel();
            this.hen_in = new System.Windows.Forms.Button();
            this.chkTiepdon = new System.Windows.Forms.CheckBox();
            this.hen_ghichu = new System.Windows.Forms.TextBox();
            this.hen_loai = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.hen_ngay = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.chkToathuoc = new System.Windows.Forms.CheckBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.butInchitiet = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.pvaovien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pmat.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.hen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(133, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Enabled = false;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(55, 28);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(20, 21);
            this.mabn2.TabIndex = 5;
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Enabled = false;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(76, 28);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(58, 21);
            this.mabn3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(332, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(392, 28);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 9;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(189, 28);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 7;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(424, 284);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(40, 23);
            this.label40.TabIndex = 96;
            this.label40.Text = "Xử trí :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(-10, 214);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(120, 23);
            this.label42.TabIndex = 20;
            this.label42.Text = "&Bệnh chính :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(109, 215);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 21);
            this.icd_chinh.TabIndex = 21;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(109, 238);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
            this.icd_kemtheo.TabIndex = 23;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_kemtheo_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // label46
            // 
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(-7, 238);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(120, 23);
            this.label46.TabIndex = 105;
            this.label46.Text = "Bệnh kèm theo :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenloaibv
            // 
            this.tenloaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenloaibv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenloaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloaibv.Location = new System.Drawing.Point(128, 307);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(298, 21);
            this.tenloaibv.TabIndex = 33;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(109, 307);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(18, 21);
            this.loaibv.TabIndex = 32;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(25, 307);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(88, 23);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(40, 328);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(72, 23);
            this.label48.TabIndex = 112;
            this.label48.Text = "Chuyển đến :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(109, 330);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(55, 21);
            this.mabv.TabIndex = 34;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(166, 330);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(260, 21);
            this.tenbv.TabIndex = 35;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(109, 284);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 26;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(6, 284);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(104, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Bác sĩ điều trị :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.ForeColor = System.Drawing.Color.Black;
            this.taibien.Location = new System.Drawing.Point(2, 374);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(146, 24);
            this.taibien.TabIndex = 126;
            this.taibien.Text = "Tai biến điều trị nội khoa";
            this.taibien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bienchung.Location = new System.Drawing.Point(368, 352);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(80, 24);
            this.bienchung.TabIndex = 127;
            this.bienchung.Text = "Biến chứng";
            this.bienchung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giaiphau
            // 
            this.giaiphau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.giaiphau.Location = new System.Drawing.Point(254, 376);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(104, 24);
            this.giaiphau.TabIndex = 128;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(600, 28);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 0;
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Enabled = false;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(624, 28);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(159, 21);
            this.tennn.TabIndex = 1;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.Color.Black;
            this.lmann.Location = new System.Drawing.Point(520, 29);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 0;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.phai.Location = new System.Drawing.Point(480, 28);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(48, 21);
            this.phai.TabIndex = 12;
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.Color.Black;
            this.lphai.Location = new System.Drawing.Point(424, 29);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Controls.Add(this.dausinhton);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.label2);
            this.pvaovien.Controls.Add(this.bnmoi);
            this.pvaovien.Controls.Add(this.loai);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.l_bnmoi);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.sothe);
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
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.label9);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.ForeColor = System.Drawing.Color.Black;
            this.pvaovien.Location = new System.Drawing.Point(-8, 51);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(800, 137);
            this.pvaovien.TabIndex = 13;
            // 
            // dausinhton
            // 
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
            this.dausinhton.Controls.Add(this.label7);
            this.dausinhton.Controls.Add(this.cao);
            this.dausinhton.Controls.Add(this.label59);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.nang);
            this.dausinhton.Controls.Add(this.label5);
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
            this.dausinhton.Location = new System.Drawing.Point(334, 44);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(474, 22);
            this.dausinhton.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(281, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 270;
            this.label7.Text = "cm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label59.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label59.Location = new System.Drawing.Point(398, 1);
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
            this.nang.Location = new System.Drawing.Point(358, 1);
            this.nang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.nang.MaxLength = 5;
            this.nang.Name = "nang";
            this.nang.Size = new System.Drawing.Size(38, 21);
            this.nang.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(315, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 267;
            this.label5.Text = "Nặng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.ForeColor = System.Drawing.Color.Black;
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
            this.label43.ForeColor = System.Drawing.Color.Black;
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
            this.label44.ForeColor = System.Drawing.Color.Black;
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
            this.label45.ForeColor = System.Drawing.Color.Black;
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
            this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(117, 22);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(211, 22);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // sovaovien
            // 
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(544, 68);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(40, 21);
            this.sovaovien.TabIndex = 15;
            this.sovaovien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sovaovien_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(181, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 250;
            this.label2.Text = "giờ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.bnmoi.Location = new System.Drawing.Point(746, 68);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(48, 21);
            this.bnmoi.TabIndex = 17;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(618, 68);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(64, 21);
            this.loai.TabIndex = 16;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(583, 68);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(40, 23);
            this.label34.TabIndex = 256;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.ForeColor = System.Drawing.Color.Black;
            this.l_bnmoi.Location = new System.Drawing.Point(674, 68);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(72, 23);
            this.l_bnmoi.TabIndex = 255;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(178, 114);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(486, 21);
            this.cd_noichuyenden.TabIndex = 23;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(712, 0);
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
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(592, 22);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(55, 21);
            this.madstt.TabIndex = 6;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(649, 22);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(143, 21);
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
            this.tendentu.Location = new System.Drawing.Point(475, 22);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(85, 21);
            this.tendentu.TabIndex = 5;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(425, 68);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(64, 21);
            this.denngay.TabIndex = 14;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // tennhantu
            // 
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(313, 22);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(73, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(293, 22);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(18, 21);
            this.nhantu.TabIndex = 2;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(216, 22);
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
            this.tenkp.Location = new System.Drawing.Point(143, 45);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(169, 21);
            this.tenkp.TabIndex = 9;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(117, 68);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(136, 68);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(80, 21);
            this.tendoituong.TabIndex = 12;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(117, 114);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(59, 21);
            this.icd_noichuyenden.TabIndex = 22;
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(9, 114);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(112, 23);
            this.label31.TabIndex = 2;
            this.label31.Text = "CĐ Nơi chuyển đến :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(600, 91);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(64, 21);
            this.qh_dienthoai.TabIndex = 21;
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(400, 91);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(144, 21);
            this.qh_diachi.TabIndex = 20;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(216, 91);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(136, 21);
            this.qh_hoten.TabIndex = 19;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(117, 91);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(59, 21);
            this.quanhe.TabIndex = 18;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(257, 68);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(111, 21);
            this.sothe.TabIndex = 13;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(472, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(517, 91);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(86, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(336, 91);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(159, 91);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(-16, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người nhà, quan hệ :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(361, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 196;
            this.label25.Text = "Đến ngày :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(193, 68);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(53, 68);
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
            this.dentu.Location = new System.Drawing.Point(455, 22);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(373, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 23);
            this.label21.TabIndex = 10;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(8, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Đến khám bệnh lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(117, 45);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 8;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Phòng khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(16, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(200, 23);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(560, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 213;
            this.label9.Text = "Tên :";
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
            this.khamthai.Location = new System.Drawing.Point(272, 44);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(520, 24);
            this.khamthai.TabIndex = 10;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(152, 1);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(22, 21);
            this.para4.TabIndex = 4;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // ngaysanh
            // 
            this.ngaysanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysanh.Location = new System.Drawing.Point(448, 2);
            this.ngaysanh.Mask = "##/##/####";
            this.ngaysanh.Name = "ngaysanh";
            this.ngaysanh.Size = new System.Drawing.Size(72, 21);
            this.ngaysanh.TabIndex = 27;
            this.ngaysanh.Text = "  /  /    ";
            this.ngaysanh.Validated += new System.EventHandler(this.ngaysanh_Validated);
            // 
            // kinhcc
            // 
            this.kinhcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhcc.Location = new System.Drawing.Point(264, 2);
            this.kinhcc.Mask = "##/##/####";
            this.kinhcc.Name = "kinhcc";
            this.kinhcc.Size = new System.Drawing.Size(72, 21);
            this.kinhcc.TabIndex = 26;
            this.kinhcc.Text = "  /  /    ";
            this.kinhcc.Validated += new System.EventHandler(this.kinhcc_Validated);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(328, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ngày sanh dự đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(176, 4);
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
            this.para3.Location = new System.Drawing.Point(128, 1);
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
            this.para2.Location = new System.Drawing.Point(104, 1);
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
            this.para1.Location = new System.Drawing.Point(80, 1);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(22, 21);
            this.para1.TabIndex = 1;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(40, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "&Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(658, 162);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(128, 239);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(8, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 23);
            this.label8.TabIndex = 208;
            this.label8.Text = "III. THÔNG TIN RA VIỆN :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gphaubenh
            // 
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(360, 376);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(96, 21);
            this.gphaubenh.TabIndex = 129;
            this.gphaubenh.Visible = false;
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(150, 376);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(106, 21);
            this.cmbTaibien.TabIndex = 212;
            this.cmbTaibien.Visible = false;
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(169, 215);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(486, 21);
            this.cd_chinh.TabIndex = 22;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(8, 410);
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
            // cd_kemtheo
            // 
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(169, 238);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(486, 21);
            this.cd_kemtheo.TabIndex = 24;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(296, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 217;
            this.label10.Text = "Số lưu trữ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(360, 284);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(66, 21);
            this.soluutru.TabIndex = 29;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(96, 410);
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
            this.tenbs.Location = new System.Drawing.Point(148, 284);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(156, 21);
            this.tenbs.TabIndex = 27;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(50, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 23);
            this.label11.TabIndex = 226;
            this.label11.Text = "Khoa : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoa
            // 
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(109, 353);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(24, 21);
            this.khoa.TabIndex = 36;
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(134, 353);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(234, 21);
            this.tenkhoa.TabIndex = 37;
            this.tenkhoa.SelectedIndexChanged += new System.EventHandler(this.tenkhoa_SelectedIndexChanged);
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(464, 307);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(192, 94);
            this.xutri.TabIndex = 31;
            this.xutri.SelectedIndexChanged += new System.EventHandler(this.xutri_SelectedIndexChanged);
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // maxutri
            // 
            this.maxutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maxutri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maxutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxutri.Location = new System.Drawing.Point(464, 284);
            this.maxutri.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maxutri.Name = "maxutri";
            this.maxutri.Size = new System.Drawing.Size(192, 21);
            this.maxutri.TabIndex = 30;
            this.maxutri.Validated += new System.EventHandler(this.maxutri_Validated);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(-4, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 23);
            this.label12.TabIndex = 237;
            this.label12.Text = "Ghi chú :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(658, 143);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 23);
            this.label55.TabIndex = 206;
            this.label55.Text = "&CÁC LẦN TÁI KHÁM";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.label33);
            this.pmat.Controls.Add(this.label22);
            this.pmat.Controls.Add(this.label18);
            this.pmat.Controls.Add(this.label35);
            this.pmat.Controls.Add(this.label36);
            this.pmat.Controls.Add(this.label37);
            this.pmat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pmat.Location = new System.Drawing.Point(-7, 261);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(664, 22);
            this.pmat.TabIndex = 25;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(116, 0);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(60, 21);
            this.mp.TabIndex = 23;
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
            this.label18.Location = new System.Drawing.Point(384, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 16);
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
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(32, 4);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(88, 16);
            this.label37.TabIndex = 0;
            this.label37.Text = "Thị lực phải :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(109, 261);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(547, 21);
            this.lydo.TabIndex = 25;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
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
            this.toolStripButton10,
            this.toolStripSeparator9,
            this.toolStripButton6,
            this.toolStripSeparator6,
            this.toolStripButton7,
            this.toolStripSeparator7,
            this.toolStripButton8,
            this.toolStripSeparator8,
            this.toolStripButton9,
            this.tlbl});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 23);
            this.toolStrip1.TabIndex = 239;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            this.tlbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.hen.Location = new System.Drawing.Point(4, 352);
            this.hen.Name = "hen";
            this.hen.Size = new System.Drawing.Size(460, 49);
            this.hen.TabIndex = 36;
            this.hen.Visible = false;
            // 
            // hen_in
            // 
            this.hen_in.Location = new System.Drawing.Point(411, 21);
            this.hen_in.Name = "hen_in";
            this.hen_in.Size = new System.Drawing.Size(38, 23);
            this.hen_in.TabIndex = 267;
            this.hen_in.Text = "In";
            this.hen_in.UseVisualStyleBackColor = true;
            this.hen_in.Visible = false;
            this.hen_in.Click += new System.EventHandler(this.hen_in_Click);
            // 
            // chkTiepdon
            // 
            this.chkTiepdon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTiepdon.AutoSize = true;
            this.chkTiepdon.BackColor = System.Drawing.SystemColors.Control;
            this.chkTiepdon.ForeColor = System.Drawing.Color.Black;
            this.chkTiepdon.Location = new System.Drawing.Point(258, 3);
            this.chkTiepdon.Name = "chkTiepdon";
            this.chkTiepdon.Size = new System.Drawing.Size(144, 17);
            this.chkTiepdon.TabIndex = 2;
            this.chkTiepdon.Text = "Qua đăng ký khám bệnh";
            this.chkTiepdon.UseVisualStyleBackColor = false;
            this.chkTiepdon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // hen_ghichu
            // 
            this.hen_ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ghichu.Location = new System.Drawing.Point(105, 23);
            this.hen_ghichu.Name = "hen_ghichu";
            this.hen_ghichu.Size = new System.Drawing.Size(297, 21);
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
            this.hen_loai.Location = new System.Drawing.Point(147, 1);
            this.hen_loai.Name = "hen_loai";
            this.hen_loai.Size = new System.Drawing.Size(110, 21);
            this.hen_loai.TabIndex = 1;
            this.hen_loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(8, 19);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(98, 23);
            this.label32.TabIndex = 230;
            this.label32.Text = "Ghi chú :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen_ngay
            // 
            this.hen_ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ngay.Location = new System.Drawing.Point(105, 1);
            this.hen_ngay.Name = "hen_ngay";
            this.hen_ngay.Size = new System.Drawing.Size(40, 21);
            this.hen_ngay.TabIndex = 0;
            this.hen_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(29, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 23);
            this.label17.TabIndex = 227;
            this.label17.Text = "Thời gian :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkToathuoc
            // 
            this.chkToathuoc.AutoSize = true;
            this.chkToathuoc.BackColor = System.Drawing.SystemColors.Control;
            this.chkToathuoc.Checked = true;
            this.chkToathuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToathuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkToathuoc.Location = new System.Drawing.Point(658, 405);
            this.chkToathuoc.Name = "chkToathuoc";
            this.chkToathuoc.Size = new System.Drawing.Size(106, 17);
            this.chkToathuoc.TabIndex = 247;
            this.chkToathuoc.Text = "In kèm toa thuốc";
            this.chkToathuoc.UseVisualStyleBackColor = false;
            this.chkToathuoc.CheckedChanged += new System.EventHandler(this.chkToathuoc_CheckedChanged);
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.BackColor = System.Drawing.SystemColors.Control;
            this.chkXml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXml.Location = new System.Drawing.Point(11, 413);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 266;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = false;
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.SystemColors.Control;
            this.chkXem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkXem.Location = new System.Drawing.Point(658, 422);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 265;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = false;
            // 
            // butInchitiet
            // 
            this.butInchitiet.BackColor = System.Drawing.Color.Transparent;
            this.butInchitiet.Enabled = false;
            this.butInchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchitiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butInchitiet.Image = ((System.Drawing.Image)(resources.GetObject("butInchitiet.Image")));
            this.butInchitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchitiet.Location = new System.Drawing.Point(361, 408);
            this.butInchitiet.Name = "butInchitiet";
            this.butInchitiet.Size = new System.Drawing.Size(70, 25);
            this.butInchitiet.TabIndex = 39;
            this.butInchitiet.Text = "&In chi phí";
            this.butInchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInchitiet.UseVisualStyleBackColor = false;
            this.butInchitiet.Click += new System.EventHandler(this.butInchitiet_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton1.Text = "F3";
            this.toolStripButton1.ToolTipText = "Đơn thuốc dược phát(Đơn thuốc BHYT)";
            this.toolStripButton1.Click += new System.EventHandler(this.l_thuocbhyt_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton2.Text = "F5";
            this.toolStripButton2.ToolTipText = "Đơn thuốc mua ngoài(Đơn thuốc dịch vụ)";
            this.toolStripButton2.Click += new System.EventHandler(this.l_thuocdan_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton3.Text = "F6";
            this.toolStripButton3.ToolTipText = "Phẫu thủ thuật";
            this.toolStripButton3.Click += new System.EventHandler(this.l_phauthuat_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton4.Text = "F7";
            this.toolStripButton4.ToolTipText = "Chỉ định dịch vụ(Chỉ định cân lâm sàng)";
            this.toolStripButton4.Click += new System.EventHandler(this.l_chidinh_Click);
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
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton10.Text = "F10";
            this.toolStripButton10.ToolTipText = "Xuất tủ trực";
            this.toolStripButton10.Click += new System.EventHandler(this.l_tutruc_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton6.Text = "F11";
            this.toolStripButton6.ToolTipText = "Chẩn đoán kèm theo";
            this.toolStripButton6.Click += new System.EventHandler(this.l_kemtheo_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton7.Text = "F12";
            this.toolStripButton7.ToolTipText = "Xem hồ sơ bệnh án";
            this.toolStripButton7.Click += new System.EventHandler(this.l_cls_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(43, 20);
            this.toolStripButton8.Text = "^D";
            this.toolStripButton8.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton8.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(72, 20);
            this.toolStripButton9.Text = "Lịch hẹn";
            this.toolStripButton9.Click += new System.EventHandler(this.l_lichhen_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(433, 408);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 42;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(290, 408);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 38;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // frmKhambenh_nt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 440);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.chkToathuoc);
            this.Controls.Add(this.butInchitiet);
            this.Controls.Add(this.hen);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.maxutri);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cd_kemtheo);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lmann);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.tennn);
            this.Controls.Add(this.pmat);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKhambenh_nt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.Load += new System.EventHandler(this.frmKhambenh_nt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhambenh_nt_KeyDown);
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.hen.ResumeLayout(false);
            this.hen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKhambenh_nt_Load(object sender, System.EventArgs e)
		{
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlength_mabn-2;
            
            user = m.user; bSothe_mabn = m.bsothe_mabn;
            if (nam == null || nam == "") nam = m.get_data("select nam from " + user + ".btdbn where mabn='" + mabn2.Text.Trim() + mabn3.Text.Trim() + "'").Tables[0].Rows[0][0].ToString();

            b701424 = m.Mabv_so == 701424; bNgoaitru_bacsy = m.bNgoaitru_bacsy;
            pmat.Visible = b701424; bDonngoaitru_auto = m.bDonngoaitru_auto;
            lydo.Visible = !b701424; bDichvu_vpkb = m.bDichvu_vpkb;
            dausinhton.Visible = m.bDausinhton_khambenh;
            label12.Text = m.sTrieuchung; lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            bHaophi = m.bHaophi_thanhtoan; bHaophi_doituongvao = m.bHaophi_thanhtoan_doituongvao;
            s_nhomhaophi = m.sHaophi_thanhtoan;
            i_sokham = m.iSokham;
            iTaikham = m.iTaikham;            
            Taikham_songay = m.Taikham_songay;
            bTaikham_hen = m.bTaikham_hen;
            madoituong_hen = m.madoituong_hen;
			bChandoan=m.bChandoan_icd10;
            bChandoan_kemtheo = m.bChandoan_kemtheo_icd10;
			bDenngay_sothe=m.bDenngay_sothe;
			b_trongngoai=m.bKham_trong_ngoai_gio;
			loai.Enabled=b_trongngoai;
			dsloai.ReadXml("..//..//..//xml//m_loai.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dsloai.Tables[0];
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];
			bnmoi.Enabled=m.bMoi_cu;
			bnmoi.SelectedIndex=0;
            bTiepdon = m.bTiepdon(LibMedi.AccessData.Taikham);
			bDanhmuc_nhathuoc=m.bDanhmuc_nhathuoc;
			bKhamthai=(dausinhton.Visible)?false:m.bKhamthai;
			khamthai.Visible=bKhamthai;
            bTaikham_chidinh = m.bTaikham_chidinh;
            iMavp_taikham = m.iMavp_taikham;
			tlbl.Text="";
			bXutri_noitru=m.bXutri_noitru_kb;
			bXutri_ngoaitru=m.bXutri_ngoaitru_kb;            
			iChidinh=m.iChidinh;
			bHiends=m.bHiendanhsach;
			bAdmin=m.bAdmin(i_userid);
			b_bacsi=m.bsKhambenh;
			bLuutru_Mabn=m.bSoluutru_Mabn;
			b_Hoten=m.bHoten_gioitinh;
			b_sovaovien=m.bSovaovien;
			load_dm();
			iKhamnhi=m.iTuoi_khamnhi;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			madstt.Text=s_madstt;
			tendstt.Text=s_tendstt;
			icd_noichuyenden.Text=s_icd_noichuyen;
			cd_noichuyenden.Text=s_cd_noichuyen;
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			cd_noichuyenden.Enabled=m.bChandoan;
			cd_chinh.Enabled=cd_noichuyenden.Enabled;
			cd_kemtheo.Enabled=cd_noichuyenden.Enabled;
			s_icd_noichuyenden=s_icd_noichuyen;
            hen_loai.SelectedIndex = 0;
			b_khambenh=m.bKhambenh;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			soluutru.Enabled=!bLuutru_Mabn;
			DataTable tmp=m.get_data("select maba from "+user+".dmbenhan where loaiba=2 order by maba").Tables[0];
			if (tmp.Rows.Count>0) i_bangoaitru=int.Parse(tmp.Rows[0]["maba"].ToString());
			else i_bangoaitru=20;            
            bDichvu_vpkb = m.bDichvu_vpkb;
            bCongkham = m.bInchiphi_congkham;
            Congkham = d.Congkham(m.nhom_duoc);
            bInchitiet = bDonngoaitru_auto;
            butInchitiet.Enabled = bInchitiet;
            chkToathuoc.Visible = bInchitiet;
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
			load_diungthuoc();
			load_treeView();
			ngayvv.Focus();
            chkToathuoc.Checked = m.Thongso("pktoathuoc") == "1";
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
            foreach (DataRow r in m.get_data("select distinct b.ten from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b where a.mahc=b.ma and a.mabn='" + mabn2.Text + mabn3.Text + "'").Tables[0].Rows) tlbl.Text += r["ten"].ToString().Trim() + ";";
            if (tlbl.Text!="")    tlbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
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
            //if (bDanhmuc_nhathuoc) sql="select * from d_thuocbhytll where nhom="+m.nhom_nhathuoc+" and maql="+l_maql;
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
            cao.Text = nang.Text = mach.Text = nhietdo.Text = huyetap.Text = "";
			listdstt.DisplayMember="MABV";
			listdstt.ValueMember="TENBV";
			listdstt.DataSource=m.get_data("select MABV,TENBV,DIACHI from "+user+".dstt where mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0  order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			tenkhoa.DisplayMember="TENKP";
			tenkhoa.ValueMember="MAKP";
            int i_idcn = m.i_Chinhanh_hientai;
            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0 ";
            if (i_idcn > 0) sql += " and chinhanh in(0," + i_idcn + ")";
            sql+=" order by makp";
            tenkhoa.DataSource = m.get_data(sql).Tables[0];

            sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
            if (_makp != "") sql += " and makp='" + _makp + "'";
            else if (s_makp != "")
            {
                if (s_makp.Length >= 2) s_makp = s_makp.Substring(0, s_makp.Length - 1);
                sql += " and makp in (" + s_makp + ")";
            }
            if (i_idcn > 0) sql += " and chinhanh in(0," + i_idcn + ")";
			sql+=" order by makp";
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data(sql).Tables[0];
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;
			if (_makp!="")
			{
				tenkp.SelectedValue=_makp;
				makp.Text=_makp;
				makp.Enabled=false;
				tenkp.Enabled=false;
			}

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);
			tennn.SelectedValue=mann.Text;
			
			tendentu.DisplayMember="TEN";
			tendentu.ValueMember="MA";
            tendentu.DataSource = m.get_data("select * from " + user + ".dentu order by ma").Tables[0];
			dentu.Text=i_dentu.ToString();
			tendentu.SelectedValue=dentu.Text.ToString();

			tennhantu.DisplayMember="TEN";
			tennhantu.ValueMember="MA";
            tennhantu.DataSource = m.get_data("select * from " + user + ".nhantu order by ma").Tables[0];
			nhantu.Text=i_nhantu.ToString();
			tennhantu.SelectedValue=nhantu.Text.ToString();

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a";
            if (s_madoituong!=null && s_madoituong.Length >= 2) s_madoituong = s_madoituong.Substring(0, s_madoituong.Length - 1);
            if (s_madoituong != "" && s_madoituong != null) sql += " where madoituong in (" + s_madoituong + ")";
            sql += " order by madoituong";
            dtdt = m.get_data(sql).Tables[0];           

			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
            tendoituong.DataSource = dtdt;
			madoituong.Text=i_madoituong.ToString();
			tendoituong.SelectedValue=madoituong.Text.ToString();
			sothe.Text=s_sothe;
			denngay.Text=s_denngay;

            dtxutri = m.get_data("select ma,to_char(ma,'00')||'   '||ten as ten from "+user+".xutrikb where ma=0 and hide=0 order by ma").Tables[0];
            DataRow dr = dtxutri.NewRow();
            dr["ma"] = 0;
            dr["ten"] = lan.Change_language_MessageText(" 00   Kết thúc điều trị");
            dtxutri.Rows.Add(dr);
            foreach (DataRow r in m.get_data("select ma,to_char(ma,'00')||'   '||ten as ten from " + user + ".xutrikb  where hide=0  order by ma").Tables[0].Rows)
            {
                dr = dtxutri.NewRow();
                dr["ma"] = r["ma"].ToString();
                dr["ten"] = r["ten"].ToString();
                dtxutri.Rows.Add(dr);
            }
            xutri.DataSource = dtxutri;
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
		}

		private void load_mabv(string maloai)
		{
			if (maloai=="3")
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where substr(maloai,1,1)='2' and mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
			else
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
		}

		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				if (makp.Text!="" && l_maql==0) load_phongkham();
				SendKeys.Send("{Tab}{Home}");
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

		private void load_tiepdon(string m_ngay,bool skip)
		{
            //l_matd=0;
            if (!m.bMmyy(m.mmyy(m_ngay))) return;
            string xxx = user + m.mmyy(m_ngay);
			sql="select * from "+xxx+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
			if (_makp!="") sql+=" and makp='"+_makp+"'";
			sql+=" order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
                //l_matd=l_maql;
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
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						s_noicap=r["mabv"].ToString();
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
			}
			//treeView1.Visible=true;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
			emp_rv();
            if (ngayvv.Text == "") return;
            DataRow r1;
            string s_xutri = "", xxx = user + m.mmyy(ngayvv.Text);
            sql = "select a.*,b.soluutru,c.chandoan as k_chandoan,c.maicd as k_maicd from " + xxx + ".benhanpk a inner join " + xxx + ".lienhe b on a.maql=b.maql left join " + xxx + ".cdkemtheo c on a.maql=c.maql where a.maql=" + l_maql;            
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
                //l_matd = decimal.Parse(r["mavaovien"].ToString());
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
                if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
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
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                }
                maxutri.Text = s_xutri;
                soluutru.Text = r["soluutru"].ToString();
                bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                if (s_xutri != "")
                {
                    for (int i = 0; i <= xutri.Items.Count; i++)
                        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i, CheckState.Checked);
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
			load_vv();
		}

		private bool load_vv_mabn()
		{
            l_maql = 0; 
            emp_vv();
            emp_rv();
            if (nam == "") return false;
            DataRow r1;
            string s_xutri, xxx = user + nam.Substring(nam.Length - 5, 4);
            sql = "select a.*,b.soluutru,c.chandoan as k_chandoan,c.maicd as k_maicd from " + xxx + ".benhanpk a inner join " + xxx + ".lienhe b on a.maql=b.maql left join " + xxx + ".cdkemtheo c on a.maql=c.maql where a.mabn='" + s_mabn + "' order by a.ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
				s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
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
                if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
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
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                }
                maxutri.Text = s_xutri;
                soluutru.Text = r["soluutru"].ToString();
                bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                if (s_xutri != "")
                {
                    for (int i = 0; i <= xutri.Items.Count; i++)
                        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i, CheckState.Checked);
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
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
            string xxx = user + m.mmyy(ngayvv.Text);
            cao.Text = nang.Text = mach.Text = nhietdo.Text = huyetap.Text = "";
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
			foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
				break;
			}
            foreach (DataRow r in m.get_data("select * from " + xxx + ".lienhe where maql=" + l_maql).Tables[0].Rows)
			{
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
				break;
			}
			if (tendoituong.SelectedIndex!=-1)
			{
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".bhyt where maql=" + l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
						s_noicap=r["mabv"].ToString();
					}
				}
			}
			if (khamthai.Visible)
			{
				bool bFound=false;
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ttkhamthai where maql=" + l_maql).Tables[0].Rows)
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
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".ttkhamthai where mabn='" + s_mabn + "' order by maql desc").Tables[0].Rows)
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
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
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
			lydo.Text=m.get_lydokham(ngayvv.Text,l_maql).ToString().Trim();
            butInchitiet.Enabled = bDonngoaitru_auto;
			//treeView1.Visible=true;
			load_phauthuat();
			load_tainantt();
			load_chidinh();
			load_thuocdan();
			load_baohiem();
		}

		private void frmKhambenh_nt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
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
                if (tendoituong.SelectedIndex == -1) tendoituong.SelectedIndex = 0;
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                denngay.Enabled = so.Substring(2, 1) == "1";
                mabv.Enabled = so.Substring(3, 1) == "1";
                tenbv.Enabled = mabv.Enabled;
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
                if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                    sql = "select sothe,denngay,mabv,tungay from xxx.bhyt where mabn='" + s_mabn + "'" + " and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                else
                    sql = "select sothe,denngay,mabv,tungay from xxx.bhyt where mabn='" + s_mabn + "' order by maql desc";
                foreach (DataRow r in m.get_data_nam_dec(nam, sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (so.Substring(3,1)=="1") mabv.Text=r["mabv"].ToString();
					s_noicap=r["mabv"].ToString();
					break;
				}
			}
			else
			{
				sothe.Text="";
				denngay.Text="";
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
						MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"),s_msg);
						mabv.Text="";
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
				if (qh_diachi.Text=="") qh_diachi.Text=
lan.Change_language_MessageText("Cùng địa chỉ");
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
			else if (icd_chinh.Text!=s_icd_chinh)
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
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			if (_makp!="")
			{
				tenkp.SelectedValue=_makp;
				makp.Text=_makp;
			}			
			tenkhoa.SelectedIndex=-1;
			l_maql=0;
            //l_matd=0;
			l_id=0;
			treeView1.Nodes.Clear();
            //diungthuoc.Checked=false;
            //l_diungthuoc.ForeColor=Color.FromArgb(0,0,255);
			//ref_check();
			emp_vv();
			emp_bhyt();
			emp_rv();
		}

		private void emp_bhyt()
		{
			sothe.Text=s_sothe;
			denngay.Text=s_denngay;
		}

		private void emp_vv()
		{
            hen.Visible = false;
            hen_ngay.Value = 1;
            hen_loai.SelectedIndex = 0;
            hen_ghichu.Text = "";
            chkTiepdon.Checked = false;
			s_ngayvv=m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			s_ngayvv="";
			tendentu.SelectedValue=i_dentu.ToString();
			tennhantu.SelectedValue=i_nhantu.ToString();
			tendoituong.SelectedValue=i_madoituong.ToString();
			madoituong.Text=i_madoituong.ToString();
			sothe.Text=s_sothe;
			denngay.Text=s_denngay;
			quanhe.Text="";
			qh_hoten.Text="";
			qh_diachi.Text="";
			qh_dienthoai.Text="";
			sovaovien.Text="";
			soluutru.Text="";
            cao.Text = nang.Text = mach.Text = nhietdo.Text = huyetap.Text = "";
			s_icd_noichuyenden=s_icd_noichuyen;
			madstt.Text=s_madstt;
			tendstt.Text=s_tendstt;
			icd_noichuyenden.Text=s_icd_noichuyen;
			cd_noichuyenden.Text=s_cd_noichuyen;
			para1.Text="";para2.Text="";
			para3.Text="";para4.Text="";
			kinhcc.Text="";
			ngaysanh.Text="";
			lydo.Text="";
            if (khamthai.Visible)
            {
                if (m.bMmyy(ngayvv.Text))
                {

                    foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".ttkhamthai where mabn='" + mabn2.Text + mabn3.Text + "' order by maql desc").Tables[0].Rows)
                    {
                        para1.Text = r["para"].ToString().Substring(0, 2);
                        para2.Text = r["para"].ToString().Substring(2, 2);
                        para3.Text = r["para"].ToString().Substring(4, 2);
                        para4.Text = r["para"].ToString().Substring(6, 2);
                        if (r["kinhcc"].ToString() != "") kinhcc.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["kinhcc"].ToString()));
                        if (r["ngaysanh"].ToString() != "") ngaysanh.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaysanh"].ToString()));
                        break;
                    }
                }
            }
            if (pmat.Visible)
            {
                mabs.Text = ""; tenbs.Text = "";
                mp.Text = ""; mt.Text = "";
                nhanapp.Text = ""; nhanapt.Text = "";
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
			khoa.Text="";
			s_mabv="";s_noicap="";
			for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
			maxutri.Text="";
			if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
			else soluutru.Text="";
		}

		private bool kiemtra()
		{

			if ((b_khambenh) || (icd_chinh.Text!="" && cd_chinh.Text!=""))
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
                /*
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
				}*/
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (int.Parse(so.Substring(0, 2)) > 0)
                {
                    if (sothe.Text == "")
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
                    if (so.Substring(2, 1) == "1" && denngay.Text == "")
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

			if (makp.Text=="" || tenkp.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"),s_msg);
				tenkp.Focus();
				return false;
			}

			s_chonxutri=chon_xutri();
			if (s_chonxutri!="")
			{
				if ((s_chonxutri.IndexOf("06,")!=-1 && (s_chonxutri.IndexOf("02,")!=-1 || s_chonxutri.IndexOf("05,")!=-1)) || (s_chonxutri.IndexOf("07,")!=-1 && s_chonxutri.Length>3))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí không hợp lệ !"),LibMedi.AccessData.Msg);
					xutri.Focus();
					return false;
				}
			}
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
				if (!m.Kiemtra_tenbenh(dticd,cd_chinh.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_chinh.Focus();
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

				if (s_chonxutri.IndexOf("06,")!=-1)
				{
					if (tenloaibv.SelectedIndex==-1 || loaibv.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển viện !"),s_msg);
						loaibv.Focus();
						return false;
					}

					if (mabv.Text=="" || tenbv.SelectedIndex==-1)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập chuyển đến !"),s_msg);
						mabv.Focus();
						return false;
					}
				}

				if (s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1)
				{
					if (tenkhoa.SelectedIndex==-1 || khoa.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập vào khoa !"),s_msg);
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
			s_mabn=mabn2.Text+mabn3.Text;
            if (!m.bMmyy(ngayvv.Text)) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
            decimal maql1 = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="" && maql1==0)
			{
				if (s_chonxutri.IndexOf("02,")!=-1 && bXutri_ngoaitru) //dieu tri ngoai tru
				{
					string s_tenkp=m.bHiendien(s_mabn,2);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {"+s_tenkp.Trim().ToUpper()+"}\nKhông thể thêm được phải xuất bệnh nhân này ra\nTrước khi nhập viện !"),s_msg);
						xutri.Focus();
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,2);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {"+s_tenkp.Trim().ToUpper()+"}\nKhông thể thêm được phải xuất bệnh nhân này ra\nTrước khi nhập viện !"),s_msg);
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
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {"+s_tenkp.Trim().ToUpper()+"}\nKhông thể thêm được phải xuất bệnh nhân này ra\nTrước khi nhập viện !"),s_msg);
						xutri.Focus();
						return false;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,1);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {"+s_tenkp.Trim().ToUpper()+"}\nKhông thể thêm được phải xuất bệnh nhân này ra\nTrước khi nhập viện !"),s_msg);
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
			if (b_trongngoai)
			{
				if (loai.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Khám !"),LibMedi.AccessData.Msg);
					return false;
				}
			}
			else loai.SelectedIndex=0;
            l_maql = m.get_maql_ngay_makp(s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text);            
            if (l_maql != 0)
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tái khám bệnh tại phòng khám {") + tenkp.Text.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Bạn có muốn lưu thêm 1 đợt nữa không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    butKetthuc.Focus();
                    return false;
                }
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = m.mabn_bhyt(nam, mabn2.Text + mabn3.Text, sothe.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ")+" " + sothe.Text + "\n"+lan.Change_language_MessageText("Đã có mã người bệnh :")+" " + s + "\n"+lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
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
                    decimal songay = m.songay(m.StringToDate(ngay), m.StringToDate(ngayvv.Text.Substring(0, 10)), 0);
                    if (songay > Taikham_songay)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Hẹn tái khám")+" " + songay.ToString() + " "+lan.Change_language_MessageText("ngày")+"\n"+lan.Change_language_MessageText("vượt quá số ngày qui định")+" " + Taikham_songay.ToString(), LibMedi.AccessData.Msg);
                        hen_ngay.Focus();
                        return false;
                    }
                }
            }
            //if (!m.bNgaygio(ngayvv.Text+" "+giovv.Text, s_ngayvao))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ hơn ngày bắt đầu diều trị !(") + s_ngayvao + ")", s_msg);
            //    ngayvv.Focus();
            //    return false;
            //}
            //if (s_ngayra != "")
            //{
            //    if (!m.bNgaygio(s_ngayra,ngayvv.Text+" "+giovv.Text))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được lớn hơn ngày giờ ra viện !(") + s_ngayra + ")", s_msg);
            //        ngayvv.Focus();
            //        return false;
            //    }
            //}
            if (kiemtrataikham() != "") return false;
            if (bNgoaitru_bacsy && mabs.Text!="")
            {
                l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text,makp.Text,false);
                if (l_maql != 0)
                {
                    string stime = "'dd/mm/yyyy hh24:mi'", ngay = ngayvv.Text+" "+giovv.Text, mabsc = "'" + mabs.Text + "','";
                    sql = "select * from " + user + ".bsnghi where " + m.for_ngay("tu", stime) + "<=to_date('" + ngay + "'," + stime + ")";
                    sql += " and " + m.for_ngay("den", stime) + ">=to_date('" + ngay + "'," + stime + ")";
                    sql += " and mabs='" + mabs.Text + "'";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                        mabsc += r["mabsc"].ToString() + "','";
                    sql = "select a.*,b.hoten as tenbs from " + user+m.mmyy(ngayvv.Text) + ".benhanpk a," + user + ".dmbs b ";
                    sql += " where a.mabs=b.ma and a.maql=" + l_maql + " and mabs in (" + mabsc.Substring(0, mabsc.Length - 2) + ")";
                    if (m.get_data(sql).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bạn có quyền điều chỉnh !"), LibMedi.AccessData.Msg);
                        butKetthuc.Focus();
                        return false;
                    }
                }
            }
			return true;
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
			int p=0;string s_ttlucrv="1";
			if (s_chonxutri!="")
			{
				p=s_chonxutri.IndexOf(",");
				s_ttlucrv=s_chonxutri.Substring(0,p);
			}
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			s_mabn=mabn2.Text+mabn3.Text;
            m.execute_data("update " + user + ".btdbn set nam='" + nam + "' where mabn='" + s_mabn + "'");
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text+" "+giovv.Text,makp.Text,true);            
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql,l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), 0, i_userid, LibMedi.AccessData.Ngoaitru, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Ngoaitru, l_maql);
            }
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhanpk");
            if (m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + s_ttlucrv + "^" + mabs.Text + "^" + sovaovien.Text + "^" + ((bienchung.Checked) ? "1" : "0") + "^" + ((taibien.Checked) ? "1" : "0") + "^" + ((giaiphau.Checked) ? "1" : "0") + "^" + l_mangtr.ToString() + "^" + i_userid.ToString());
            }
            else
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
                if (bTaikham_chidinh)
                {
                    decimal _id = v.get_id_chidinh;
                    decimal _dongia = m.tienkham(s_madantoc == "55", iMavp_taikham, int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                    v.upd_chidinh(_id, s_mabn, l_matd, l_maql, 0, ngayvv.Text + " " + giovv.Text, v.iNgoaitru, makp.Text, int.Parse(madoituong.Text), iMavp_taikham, 1, _dongia, 0, i_userid, 0, 0, _id, icd_chinh.Text, cd_chinh.Text, mabs.Text, 2,"");
                }
            }
			if (!m.upd_lienhe(ngayvv.Text,l_maql,ssonha,sthon,scholam,smatt,smaqu1+smaqu2,smapxa1+smapxa2,stuoi.PadLeft(3,'0')+iloaituoi.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),(kinhcc.Text.Trim().Length<10)?"":kinhcc.Text,(ngaysanh.Text.Trim().Length<10)?"":ngaysanh.Text,"");
            if (!m.upd_benhanpk(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, (s_ttlucrv == "") ? 0 : int.Parse(s_ttlucrv), mabs.Text, sovaovien.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? 1 : 0, (giaiphau.Checked) ? 1 : 0, l_mangtr, i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(ngayvv.Text,s_mabn,l_maql,sothe.Text,denngay.Text,(s_noicap=="")?m.Mabv:s_noicap,0,stungay,ngay1,ngay2,ngay3,traituyen))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}
			
			if (cd_noichuyenden.Text!="" || madstt.Text!="")
			{
				if (!m.upd_noigioithieu(ngayvv.Text,l_maql,madstt.Text,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_maql, (mach.Text.Trim() != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text.Trim() != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nang.Text.Trim() != "") ? decimal.Parse(nang.Text) : 0, (cao.Text.Trim() != "") ? decimal.Parse(cao.Text) : 0,0);
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="")
			{
				if (lydo.Text!="") m.upd_lydokham(ngayvv.Text,l_maql,lydo.Text);
				if (pmat.Visible) m.upd_ttmat(ngayvv.Text,l_maql,mp.Text,mt.Text,nhanapp.Text,nhanapt.Text);
				if (s_chonxutri.IndexOf("07,")!=-1)
				{
					if (m.get_data("select * from "+user+".tuvong where maql="+l_maql).Tables[0].Rows.Count==0)
						l_tuvong_Click(null,null);
				}
				m.upd_xutrikbct(ngayvv.Text,l_maql,s_chonxutri,khoa.Text);
				if (cd_kemtheo.Text!="") m.upd_cdkemtheo(ngayvv.Text,l_id,l_maql,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
				else m.execute_data("delete from "+user+m.mmyy(ngayvv.Text)+".cdkemtheo where stt=1 and loai=4 and maql="+l_maql);
				if (loaibv.Enabled && loaibv.Text!="") m.upd_chuyenvien(l_maql,mabv.Text,int.Parse(loaibv.Text));
				else m.execute_data("delete from "+user+".chuyenvien where maql="+l_maql);
				decimal maluu=l_maql;
				if (s_chonxutri.IndexOf("05,")!=-1 && bXutri_noitru) upd_noitru(so);
				l_maql=maluu;
                if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
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
                                decimal maql1 = m.get_maql_tiepdon(s_mabn, ngay + " 07:00");
                                string sokham = (i_sokham == 2) ? m.get_sokham(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                                if (sokham != "")
                                {
                                    string s = hen_ghichu.Text.Trim();
                                    hen_ghichu.Text = s + " Số thứ tự khám :" + sokham;
                                }
                                m.upd_tiepdon(s_mabn, l_maql, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex);
                                m.upd_lienhe(ngayvv.Text, maql1, ssonha, sthon, scholam, smatt, smaqu1 + smaqu2, smapxa1 + smapxa2, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                {
                                    if (!m.upd_bhyt(ngay, s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0,stungay,ngay1,ngay2,ngay3,traituyen))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                decimal maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                                string sokham = (i_sokham == 2) ? m.get_sokham_hen(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                                if (sokham != "")
                                {
                                    string s = hen_ghichu.Text.Trim();
                                    hen_ghichu.Text = s + " Số thứ tự khám :" + sokham;
                                }
                                m.upd_tiepdon_hen(s_mabn, l_maql, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex,ngayvv.Text+" "+giovv.Text);
                                m.upd_lienhe(maql1, ssonha, sthon, scholam, smatt, smaqu1 + smaqu2, smapxa1 + smapxa2, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                                if (int.Parse(so.Substring(0, 2)) > 0)
                                {
                                    if (!m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0,stungay,ngay1,ngay2,ngay3,traituyen))
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
				if (s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("06,")!=-1 || s_chonxutri.IndexOf("07,")!=-1) upd_ngoaitru(so);
                if (s_chonxutri.IndexOf("00,") != -1) upd_ravien();
			}
            if (bDonngoaitru_auto)
            {
                butInchitiet.Enabled = true;
                butInchitiet.Focus();
            }
			else butKetthuc.Focus();
		}

        private void upd_hen()
        {
            decimal maql1;
            s_mabn = mabn2.Text + mabn3.Text;
            string ngay, so, sokham;
            /*
            if (s_noicap != "")
                foreach (DataRow r1 in m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + s_noicap + "'").Tables[0].Rows)
                    noidkkcb = r1["tenbv"].ToString();
             * */
            DateTime dt = m.StringToDate(ngayvv.Text.Substring(0, 10));
            for (int i = 1; i <= Convert.ToInt16(hen_ngay.Value); i++)
            {
                ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(i));
                //if (!m.bMmyy(m.mmyy(ngay))) m.tao_schema(m.mmyy(ngay), i_userid);
                if (m.mmyy(ngayvv.Text) == m.mmyy(ngay))
                {
                    maql1 = m.get_maql_tiepdon(s_mabn, ngay + " 07:00");
                    sokham = (i_sokham == 2) ? m.get_sokham(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                    m.upd_tiepdon(s_mabn, l_maql, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex);
                    m.upd_lienhe(ngayvv.Text, maql1, ssonha, sthon, scholam, smatt, smaqu1 + smaqu2, smapxa1 + smapxa2, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (int.Parse(so.Substring(0, 2)) > 0)
                    {
                        if (!m.upd_bhyt(ngay, s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0,stungay,ngay1,ngay2,ngay3,traituyen))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                            return;
                        }
                    }
                }
                else
                {
                    maql1 = m.get_maql_tiepdon_hen(s_mabn, ngay + " 07:00");
                    sokham = (i_sokham == 2) ? m.get_sokham_hen(ngay + " 07:00", makp.Text, i_sokham).ToString() : "";
                    m.upd_tiepdon_hen(s_mabn, l_maql, maql1, makp.Text, ngay + " 07:00", int.Parse(tendoituong.SelectedValue.ToString()), sokham, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), i_userid, bnmoi.SelectedIndex, LibMedi.AccessData.Taikham, loai.SelectedIndex,ngayvv.Text+" "+giovv.Text);
                    m.upd_lienhe(maql1, ssonha, sthon, scholam, smatt, smaqu1 + smaqu2, smapxa1 + smapxa2, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex);
                    so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (int.Parse(so.Substring(0, 2)) > 0)
                    {
                        if (!m.upd_bhyt(s_mabn, maql1, sothe.Text, denngay.Text, s_noicap, 0,stungay,ngay1,ngay2,ngay3,traituyen))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                            return;
                        }
                    }
                }
            }
        }
        private void upd_ravien()
        {
            if (!m.upd_benhanngtr(l_mangtr, ngayvv.Text + " " + giovv.Text, 1, 1, cd_chinh.Text, icd_chinh.Text, mabs.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? int.Parse(cmbTaibien.SelectedValue.ToString()) : 0, (giaiphau.Checked) ? int.Parse(gphaubenh.SelectedValue.ToString()) : 0, soluutru.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra viện !"), s_msg);
                return;
            }
            bravien = true;
        }

		private void upd_ngoaitru(string so)
		{
			int ketqua=1,ttlucrv=1;
			if (s_chonxutri.IndexOf("07,")!=-1)
			{
				ketqua=5;ttlucrv=7;
			}
			else if (s_chonxutri.IndexOf("05,")!=-1)
			{
				ketqua=3;ttlucrv=0;
			}
			DataTable dt1=m.get_data_nam_dec(nam,"select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.pttt where maql="+l_mangtr+" order by ngay desc,id desc").Tables[0];
			if (dt1.Rows.Count!=0)
			{
				string s_ngaypt=dt1.Rows[0][0].ToString();
                if (!m.bNgaygio(ngayvv.Text + " " + giovv.Text, s_ngaypt))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không được nhỏ hơn ngày phẫu thuật - thủ thuật !")+"\n"+s_ngaypt,LibMedi.AccessData.Msg);
					ngayvv.Focus();
					return;
				}
			}
            if (!m.upd_benhanngtr(l_mangtr, ngayvv.Text + " " + giovv.Text,ketqua, ttlucrv, cd_chinh.Text, icd_chinh.Text, mabs.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? int.Parse(cmbTaibien.SelectedValue.ToString()) : 0, (giaiphau.Checked) ? int.Parse(gphaubenh.SelectedValue.ToString()) : 0, soluutru.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra viện !"), s_msg);
                return;
            }
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_idngtr,l_mangtr,4,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=4 and maql="+l_mangtr);
			if (loaibv.Enabled && loaibv.Text!="") m.upd_chuyenvien(l_mangtr,mabv.Text,int.Parse(loaibv.Text));
			else m.execute_data("delete from "+user+".chuyenvien where maql="+l_mangtr);
			if (ttlucrv==0 && bXutri_noitru)	upd_noitru(so,l_matd);
			bravien=true;
		}

		private void upd_noitru(string so)
		{
            int itable = m.tableid("","benhandt");
            if (m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + khoa.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + "1" + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + sovaovien.Text + "^" + "1" + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            l_maql = m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, true);
			if (!m.upd_lienhe(l_maql,ssonha,sthon,scholam,smatt,smaqu1+smaqu2,smapxa1+smapxa2,stuoi.PadLeft(3,'0')+iloaituoi.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, mabs.Text, sovaovien.Text, 1, i_userid, true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap,0,stungay,ngay1,ngay2,ngay3,traituyen))
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
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_id,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=1 and maql="+l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Nhanbenh,l_maql);
			decimal tmpid=m.get_id_hiendien_do_cdvv(s_mabn,l_maql,"01");
            decimal l_idhiendien = (tmpid == 0) ? m.get_id(l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text) : tmpid;//tinh them gio
            m.upd_hiendien(l_idhiendien, s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, ngayvv.Text + " " + giovv.Text, "", mabs.Text,icd_chinh.Text, "01", 0, 0);
		}

		private void upd_noitru(string so,decimal l_matd)
		{
            int itable = m.tableid("","benhandt");
            if (m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + khoa.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + "1" + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + sovaovien.Text + "^" + "1" + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            l_maql = m.get_maql(1, s_mabn, khoa.Text, ngayvv.Text + " " + giovv.Text, true);
			if (!m.upd_lienhe(l_maql,ssonha,sthon,scholam,smatt,smaqu1+smaqu2,smapxa1+smapxa2,stuoi.PadLeft(3,'0')+iloaituoi.ToString(),loai.SelectedIndex,bnmoi.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, khoa.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, mabs.Text, sovaovien.Text, 1, i_userid, true))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap,0,stungay,ngay1,ngay2,ngay3,traituyen))
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
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_idngtr,l_maql,1,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from "+user+".cdkemtheo where stt=1 and loai=1 and maql="+l_maql);
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Nhanbenh,l_maql);
			m.upd_xutrikbct(ngayvv.Text,l_maql,"",khoa.Text);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
    	}

		private void nhantu_TextChanged(object sender, System.EventArgs e)
		{
			nhantu.Text=nhantu.Text;
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            TreeNode node;            
            foreach (DataRow r in m.get_data_mmyy("select ngay,chandoan,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.benhanpk where mangtr="+l_mangtr+" and mabn='" + s_mabn + "'",s_ngayvao.Substring(0,10),(s_ngayra.Trim()=="")?m.ngayhienhanh_server.Substring(0,10):s_ngayra.Substring(0,10),false).Tables[0].Select("true","yyyymmdd desc"))
            {
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                node.Nodes.Add(r["chandoan"].ToString());
            }
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
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql_benhanpk(s_mabn,ngay);
					if (l_maql!=0)
					{
                        ngayvv.Text = ngay.Substring(0, 10);
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
            else if (kiemtrataikham() != "") return;
            frmPttt f = new frmPttt(m, makp.Text, s_mabn, hoten.Text, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), phai.Text, ssonha.Trim() + " " + sthon, sothe.Text, "", ngayvv.Text + " " + giovv.Text, cd_chinh.Text, icd_chinh.Text, "P", i_userid, "", "", "",l_maql,l_matd,0,3,false);
			f.ShowDialog();
			load_phauthuat();
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
            frmTainantt f = new frmTainantt(m, l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, ssonha.Trim() + " " + sthon, i_userid,makp.Text,nam);
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
			//treeView1.Visible=false;
			Filt_dstt(tendstt.Text);
			listdstt.BrowseToText(tendstt,madstt,makp,madstt.Location.X,madstt.Location.Y+madstt.Height,madstt.Width+tendstt.Width+2,madstt.Height);
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

		private void cd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_noichuyenden)
			{
				if (bChandoan_kemtheo || icd_noichuyenden.Text=="")
				{
					Filt_ICD(cd_noichuyenden.Text);
					listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,icd_chinh,icd_chinh.Location.X,pvaovien.Location.Y+pvaovien.Height-icd_noichuyenden.Height+18,icd_noichuyenden.Width+cd_noichuyenden.Width+2,icd_noichuyenden.Height);
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
					listICD.BrowseToICD10(cd_chinh,icd_chinh,icd_kemtheo,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
				}
			}
		}

		private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kemtheo)
			{
				if (bChandoan_kemtheo || icd_kemtheo.Text=="")
				{
					Filt_ICD(cd_kemtheo.Text);
					listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,mabs,icd_kemtheo.Location.X,icd_kemtheo.Location.Y+icd_kemtheo.Height,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
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

		private void cd_kkb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void l_thuocbhyt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
	        s_chonxutri=chon_xutri();
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
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            else if (kiemtrataikham() != "") return;
			LibDuoc.AccessData d=new LibDuoc.AccessData();
			string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
            sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			DataTable dt=m.get_data(sql).Tables[0];
			foreach(DataRow r in dt.Rows)
			{
				s_mmyy=r["mmyy"].ToString();
                if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
			}
            bool bDieutringtr = m.get_data("select * from " + user + ".d_dmphieu where id=8").Tables[0].Rows.Count > 0;
            if (bDieutringtr)
            {
                if (!kiemtra(8)) return;
            }
            else
            {
                if (madoituong.Text != "1") if (!kiemtra(6)) return;
            }
            string adiachi = ssonha.Trim() + " " + sthon.Trim();
            //
            string s_ngayhienhanh = m.ngayhienhanh_server;
            if (s_ngayhienhanh.Substring(3, 2) != ngayvv.Text.Substring(3, 2)) m.f_chuyenbhyt_to_next_mmyy(s_mabn, l_maql, ngayvv.Text, s_ngayhienhanh);
            //
            frmBaohiem f = new frmBaohiem(bDieutringtr, s_mabn, (bDieutringtr) ? 8 : (madoituong.Text == "1") ? 5 : 6, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_duoc, i_userid, "Đơn thuốc dược phát", l_matd, l_maql, hoten.Text, namsinh.Text+"^", sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, int.Parse(madoituong.Text), makp.Text, mabs.Text, tendoituong.Text,scholam,adiachi.Trim().Trim(','), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", (bDieutringtr) ? 2 : 3, (s_noicap == "") ? m.Mabv : s_noicap,false,"",ngayvv.Text+" "+giovv.Text,"",traituyen,ngay1,ngay2,ngay3,phai.Text,i_khudt,3);
			f.ShowDialog(this);
			load_baohiem();
		}

        private bool kiemtra(int loai)
        {
            string s = "";
            foreach (DataRow r in m.get_data("select madoituong from " + user + ".d_dmphieu where id=" + loai).Tables[0].Rows)
                s = r["madoituong"].ToString().Trim();
            if (s != "")
            {
                if (m.get_data("select * from " + user + ".d_dmphieu where id=" + loai + " and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng")+ "\n" + tendoituong.Text + "\n"+lan.Change_language_MessageText("Không được cấp thuốc !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            return true;
        }

		private void l_thuocdan_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            else if (kiemtrataikham() != "") return;
            string adiachi = ssonha.Trim() + " " + sthon.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
			if (bDanhmuc_nhathuoc)
			{
				LibDuoc.AccessData d=new LibDuoc.AccessData();
				string s_mmyy=ngayvv.Text.Substring(3,2)+ngayvv.Text.Substring(8,2);
                sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
				DataTable dt=m.get_data(sql).Tables[0];
				foreach(DataRow r in dt.Rows)
				{
					s_mmyy=r["mmyy"].ToString();
                    if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc).Tables[0].Rows.Count > 0) break;
                }
                //Thuy 27.05.2013
                string ss_madoituong = "";
                DataSet dsdt = new DataSet();
                dsdt = m.get_data("select * from " + user + ".d_dmphieu");
                foreach (DataRow r_dt in dsdt.Tables[0].Select("id=7"))
                {
                    ss_madoituong = r_dt["madoituong"].ToString();
                }
                string[] s_dt = ss_madoituong.Split(',');
                int i_dt = 2;
                if (s_dt.Length >= 1)
                {
                    i_dt = int.Parse(s_dt[0]);
                }
                frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc mua ngoài", l_matd, l_maql, hoten.Text, namsinh.Text+"^", sothe.Text, tenkp.Text, tenbs.Text, icd_chinh.Text, cd_chinh.Text, i_dt, makp.Text, mabs.Text, tendoituong.Text,scholam, adiachi.Trim().Trim(','), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 3, (s_noicap == "") ? m.Mabv : s_noicap,false,ss_madoituong,ngayvv.Text+" "+giovv.Text,"",traituyen,ngay1,ngay2,ngay3,phai.Text,i_khudt,3);
				f.ShowDialog(this);
				load_thuocdan();
			}
			else
			{
                frmToathuoc f2 = new frmToathuoc(m, s_mabn, hoten.Text, stuoi, ngayvv.Text + " " + giovv.Text, makp.Text, tenkp.Text, mabs.Text, tenbs.Text, cd_chinh.Text, icd_chinh.Text, l_maql, i_userid, adiachi.Trim().Trim(','), nam);
				f2.ShowDialog(this);
				load_thuocdan();
			}
		}

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            //if (s_chonxutri == "")
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"), s_msg);
            //    xutri.Focus();
            //    return;
            //}

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
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            else if (kiemtrataikham() != "") return;
            if (m.bCD_BS_Chidinh && tenbs.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu chọn bác sĩ !"), LibMedi.AccessData.Msg);
                mabs.Focus();
                return;
            }
            if (m.bCD_BS_Chidinh && cd_chinh.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán !"), LibMedi.AccessData.Msg);
                icd_chinh.Focus();
                return;
            }
            //
            string s_ngayhienhanh = m.ngayhienhanh_server;
            if (s_ngayhienhanh.Substring(3, 2) != ngayvv.Text.Substring(3, 2)) m.f_chuyenbhyt_to_next_mmyy(s_mabn, l_maql, ngayvv.Text, s_ngayhienhanh);
            //
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, stuoi, ngayvv.Text + " " + giovv.Text, makp.Text, tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_matd, l_maql, 0, i_userid, "xxx.benhanpk", sothe.Text, nam, 2, mabs.Text, cd_chinh.Text, icd_chinh.Text, traituyen);
            f.NgayVaoVien = ngayvv.Text;
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
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,stuoi,ssonha.Trim()+" "+sthon.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
		}

		private void soluutru_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (mabn3.Text=="" && soluutru.Text!="")
				{
                    if (nam == "") return;
					DataTable dt=m.get_data_nam_dec(nam,"select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.benhanpk a,xxx.lienhe b where a.maql=b.maql and b.soluutru='"+soluutru.Text+"' order by a.maql").Tables[0];
					if (dt.Rows.Count>0)
					{
						s_mabn=dt.Rows[0]["mabn"].ToString();
                        ngayvv.Text = dt.Rows[0]["ngay"].ToString().Substring(0, 10);
                        giovv.Text = dt.Rows[0]["ngay"].ToString().Substring(11);
						mabn2.Text=s_mabn.Substring(0,2);
						mabn3.Text=s_mabn.Substring(2);
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
					listBS.BrowseToICD10(tenbs,mabs,soluutru,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
				else
					listBS.BrowseToICD10(tenbs,mabs,maxutri,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
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

		private void l_tuvong_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql_benhanpk(s_mabn,ngayvv.Text+" "+giovv.Text,makp.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), ngayvv.Text + " " + giovv.Text, "1", l_maql, i_userid);
			f.ShowDialog();
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
            if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
            {
                hen.Visible = madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1;
            }
            else hen.Visible = false;
			loaibv.Enabled=(s_chonxutri.IndexOf("06,")!=-1);
			tenloaibv.Enabled=loaibv.Enabled;
			mabv.Enabled=loaibv.Enabled;
			tenbv.Enabled=loaibv.Enabled;
			khoa.Enabled=(s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1);
			tenkhoa.Enabled=khoa.Enabled;		
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
            frmCdkemtheo f = new frmCdkemtheo(m, l_maql, l_maql, 4, ngayvv.Text + " " + giovv.Text);
			f.ShowDialog();
			load_kemtheo();
		}

		private void luu()
		{
            if (kiemtrataikham() != "") return;
            int p = 0; string s_ttlucrv = "1";
            if (s_chonxutri != "")
            {
                p = s_chonxutri.IndexOf(",");
                s_ttlucrv = s_chonxutri.Substring(0, p);
            }
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            s_mabn = mabn2.Text + mabn3.Text;
            m.execute_data("update " + user + ".btdbn set nam='" + nam + "' where mabn='" + s_mabn + "'");
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, true);
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql, l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), 0, i_userid, LibMedi.AccessData.Ngoaitru, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Ngoaitru, l_maql);
            }
            if (!m.upd_lienhe(ngayvv.Text, l_maql, ssonha, sthon, scholam, smatt, smaqu1 + smaqu2, smapxa1 + smapxa2, stuoi.PadLeft(3, '0') + iloaituoi.ToString(), loai.SelectedIndex, bnmoi.SelectedIndex))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            if (soluutru.Text != "") m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".lienhe set soluutru='" + soluutru.Text + "' where maql=" + l_maql);
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), kinhcc.Text, ngaysanh.Text, "");
            if (!m.upd_benhanpk(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, (s_ttlucrv != "") ? int.Parse(s_ttlucrv) : 0, mabs.Text, sovaovien.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? 1 : 0, (giaiphau.Checked) ? 1 : 0, l_mangtr, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            if (cd_kemtheo.Text != "") m.upd_cdkemtheo(ngayvv.Text, l_maql, l_maql, 4, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
		}

		private void load_kemtheo()
		{
            //kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=4 and id="+l_id).Tables[0].Rows.Count!=0;
            //l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void maxutri_Validated(object sender, System.EventArgs e)
		{
			s_chonxutri=maxutri.Text.Trim();
			if (s_chonxutri!="")
			{
				if (s_chonxutri.Substring(s_chonxutri.Length)!=",") s_chonxutri+=",";
				for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
				for(int i=0;i<=xutri.Items.Count;i++)
					if (s_chonxutri.IndexOf(i.ToString().Trim().PadLeft(2,'0')+",")!=-1) xutri.SetItemCheckState(i,CheckState.Checked);
                if (s_chonxutri.IndexOf("03,") != -1 && bTaikham_hen)
                {
                    hen_in.Visible = hen.Visible = madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1;
                    
                }
                else hen.Visible = false;
				loaibv.Enabled=(s_chonxutri.IndexOf("06,")!=-1);
				tenloaibv.Enabled=loaibv.Enabled;
				mabv.Enabled=loaibv.Enabled;
				tenbv.Enabled=loaibv.Enabled;
				khoa.Enabled=(s_chonxutri.IndexOf("05,")!=-1 || s_chonxutri.IndexOf("02,")!=-1);
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
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
		}

        private void l_tutruc_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text,makp.Text,false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            else if (kiemtrataikham() != "") return;
            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, makp.Text + ",", false, s_nhomkho, i_khudt, i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, s_mabn, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, mabs.Text,s_madoituong);
                f1.ShowDialog(this);
            }
        }

		private void l_cls_Click(object sender, System.EventArgs e)
		{
		}

		private bool load_phongkham()
		{
            l_maql = m.get_maql_ngay(s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text);
			if (l_maql!=0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám")+"\n"+" "+tenkp.Text.Trim().ToUpper()+"\n"+lan.Change_language_MessageText("Bạn có muốn xem lại !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
                    s_ngayvv = ngayvv.Text+" "+giovv.Text;
					load_vv_maql(false);					
					return false;
				}
			}
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

		private void lydo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				lydo.Text=m.Viettat(lydo.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            s_mabn = mabn2.Text + mabn3.Text;
            if (!bTiepdon)
            {
                if (m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text) == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                    ngayvv.Focus();
                    return;
                }
            }
            if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày khám bệnh không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                ngayvv.Focus();
                s_ngayvv = "";
                return;
            }
            if (khamthai.Visible)
            {
                if (m.bMmyy(m.mmyy(ngayvv.Text)))
                {
                    foreach (DataRow r in m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".ttkhamthai where mabn='" + mabn2.Text + mabn3.Text + "' order by maql desc").Tables[0].Rows)
                    {
                        para1.Text = r["para"].ToString().Substring(0, 2);
                        para2.Text = r["para"].ToString().Substring(2, 2);
                        para3.Text = r["para"].ToString().Substring(4, 2);
                        para4.Text = r["para"].ToString().Substring(6, 2);
                        if (r["kinhcc"].ToString() != "") kinhcc.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["kinhcc"].ToString()));
                        if (r["ngaysanh"].ToString() != "") ngaysanh.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaysanh"].ToString()));
                        break;
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
            s_mabn = mabn2.Text + mabn3.Text;
            string s = ngayvv.Text+" "+giovv.Text;
            if (s != s_ngayvv)
            {
                l_maql = m.get_maql_benhanpk(s_mabn,s);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                }
                else
                {
                    if (ngayvv.Text.Substring(0, 10) == m.Ngayhienhanh)
                    {
                        string m_ngay = m.get_ngaytiepdon(s_mabn,s);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(s, m_ngay))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                                ngayvv.Focus();
                                return;
                            }
                        }
                    }
                    if (!m.bNgaygio(s, s_ngayvao))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ hơn ngày bắt đầu diều trị !(") + s_ngayvao + ")", s_msg);
                        ngayvv.Focus();
                        return;
                    }
                    if (s_ngayra != "")
                    {
                        if (!m.bNgaygio(s_ngayra, s))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được lớn hơn ngày giờ ra viện !(") + s_ngayra + ")", s_msg);
                            ngayvv.Focus();
                            return;
                        }
                    }
                    if (!makp.Enabled && makp.Text != "")
                    {
                        if (!load_phongkham()) return;
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
                }
                s_ngayvv = ngayvv.Text+" "+giovv.Text;
            }
        }
        private string kiemtrataikham()
        {
            string s = "";
            if (iTaikham != 0)
            {
                DataSet tmp = m.getTaikham(mabn2.Text + mabn3.Text, l_mangtr,m.get_maql_benhanpk(mabn2.Text+mabn3.Text, ngayvv.Text+" "+giovv.Text,makp.Text,false), s_ngayvao.Substring(0, 10), m.ngayhienhanh_server.Substring(0, 10));
                if (tmp.Tables[0].Rows.Count >= iTaikham)
                {
                    foreach (DataRow r in tmp.Tables[0].Rows) s += r["ngay"].ToString().Trim() + "\n";
                    s = "Người bệnh đã tái khám các ngày sau \n" + s.Trim() + "\nvượt quá số lần tái khám cho phép : " + iTaikham.ToString();
                    MessageBox.Show(s, LibMedi.AccessData.Msg);
                }
            }
            return s;
        }

        private void hen_ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
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
            l_maql = m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false);
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin phòng khám chưa cập nhật !"), LibMedi.AccessData.Msg);
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
                    butKetthuc.Focus();
                    return;
                }
                else if (MessageBox.Show(lan.Change_language_MessageText("Chi phí đã in") + "\n" + lan.Change_language_MessageText("Bạn có muốn in lại ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    butKetthuc.Focus();
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
            butKetthuc.Focus();
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
                if (!d.upd_bhytds(d_mmyy, s_mabn, hoten.Text, namsinh.Text, ssonha.Trim() + " " + sthon.Trim()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytkb");
                d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                if (!d.upd_bhytkb(d_mmyy, d_id, i_nhom, ngayvv.Text, s_mabn, l_matd, l_maql, makp.Text, cd_chinh.Text, icd_chinh.Text, mabs.Text, sothe.Text, int.Parse(madoituong.Text), s_noicap, i_userid, 2,traituyen))
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
            sql += " from xxx.benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql += " left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd;
            sql += " and a.maql="+l_maql;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql, ngaybd.Substring(0, 10), ngayvv.Text.Substring(0, 10), true).Tables[0].Rows)
            {
                maso += r["maql"].ToString() + ",";
                s_maicd += r["maicd"].ToString().Trim() + ";";
                s_chandoan += r["chandoan"].ToString().Trim() + ";";
                s_tenkp += r["tenkp"].ToString().Trim() + ";";
                s_tenbs += r["tenbs"].ToString() + ";";
                foreach (DataRow r1 in m.get_data("select distinct chandoan,maicd from " + yyy + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
            }
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            sql = "select 1 as id,a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "a.cachdung,0 as makho,0 as manguon,0 as nhomcc,f.makp,h.tenkp,f.maphu as madoituong,x.doituong,h.makp,t.gianovat ";
            sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h," + user + ".d_doituong x";
            sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and f.makp=h.makp and f.maphu=x.madoituong ";
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;//"and to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            if (maso != "") sql += " and f.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            ds1 = m.get_data_mmyy(sql, ngaybd, ngayvv.Text, true);
            //
            sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
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
                foreach (DataRow r in m.get_data("select b.tenbv from " + yyy + ".bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.sothe='" + sothe.Text + "'").Tables[0].Rows)
                {
                    s_noicap = r["tenbv"].ToString();
                    break;
                }
            }
            string dichso = "", s_ghichu = "";
            decimal mien = 0, tcsotien = 0;
            bool bMien = false;

            sql = "select a.ghichu from xxx.d_thuocbhytll a,xxx.bhytkb b";
            sql += " where a.id=b.id and a.ghichu<>''";
            sql += " and b.mabn='" + s_mabn + "' and b.mavaovien=" + l_matd+" and b.maql="+l_maql;
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
                m.updrec_ravien(dsxmlin, s_mabn, s_mabn, l_maql, 2, hoten.Text, namsinh.Text, phai.Text, ssonha.Trim() + " " + sthon.Trim() + " " + sdiachi, int.Parse(madoituong.Text),
                tendoituong.Text, sothe.Text, 0, stungay + "^" + denngay.Text, tendstt.Text, s_noicap, tenbs.Text, makp.Text, s_tenkp, ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                0, "", 0, "", 0, "", "", 0, 0, bhyttra, 0, (bCongkham) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, 0, false, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(madoituong.Text), 0, 0,0,traituyen,int.Parse("-1"),"");
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
                        m.updrec_ravien(dsxmlin, r["sttt"].ToString(), s_mabn, l_maql, decimal.Parse(r["sttt"].ToString()) + decimal.Parse(r["id"].ToString()), hoten.Text, namsinh.Text, phai.Text, ssonha.Trim() + " " + sthon.Trim() + " " + sdiachi, int.Parse(r["madoituong"].ToString()),
                            r["doituong"].ToString(), sothe.Text, 0, stungay + "^" + denngay.Text, tendstt.Text, s_noicap, tenbs.Text, r["makp"].ToString(), r["tenkp"].ToString(), ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                            int.Parse(r2["sttnhom"].ToString()), r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r["cachdung"].ToString(),
                            int.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(),
                            decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sotien"].ToString()),
                            bhyttra, 0, (bCongkham && int.Parse(r["madoituong"].ToString()) == int.Parse(madoituong.Text.ToString())) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, decimal.Parse(r["dongia"].ToString()), true, 0, mabs.Text, tenbs.Text, makp.Text, "", int.Parse(r["madoituong"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, decimal.Parse(r["sotien"].ToString()), traituyen, int.Parse(r2["kythuat"].ToString()),"");
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
                        r["tlchitra"] = chitra;//TU:29/06/2011
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
                            r["tlchitra"] = chitra;//TU:29/06/2011
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
                dsxmlin.WriteXml("..\\xml\\inchiphipk.xml", XmlWriteMode.WriteSchema);
            }
            if (dsxmlin.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsxmlin.Tables[0].Rows)
                {
                    r["tenuser"] = s_userid;
                    r["cholam"] = scholam;
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

        private void chkToathuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkToathuoc) m.writeXml("thongso", "pktoathuoc", (chkToathuoc.Checked) ? "1" : "0");
        }

        private void hen_in_Click(object sender, EventArgs e)
        {
            phai.Enabled = true;
            tenkp.Enabled = true;
            if (ngayvv.Text != "")
            {
                DataSet dsdt = new DataSet();
                dsdt.ReadXml("..\\..\\..\\xml\\m_phieudieutri.xml");
                dsdt.Tables[0].Columns.Add("mabv");
                dsdt.Clear();
                decimal maql1;
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
                        r["tuoi"] = s_tuoi;
                        r["gioitinh"] = phai.SelectedItem.ToString();
                        r["diachi"] = sdiachi;
                        r["ngaykham"] = ngay;
                        r["lydokham"] = hen_ghichu.Text;
                        r["nghenghiep"] = tennn.Text;
                        r["doituong"] = tendoituong.Text;
                        r["sothe"] = sothe.Text;
                        r["tungay"] = (chkTiepdon.Checked) ? "Qua tiếp đón" : "";
                        r["denngay"] = denngay.Text +"^" + s_tungay;
                        r["noidkkcb"] = noidkkcb.Trim() +"^" + s_cholam;
                        r["mabv"] = mabv.Text;
                        r["chandoan"] = cd_chinh.Text + "^" + tenkp.Text; 
                        r["dantoc"] = s_dantoc;
                        r["benhvien"] = noidkkcb;
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (!chkTiepdon.Checked)
                        {
                            if (m.mmyy(ngay) == m.mmyy(ngayvv.Text))
                            {
                                maql1 = m.get_maql_tiepdon(s_mabn, ngay + " 07:00");
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
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
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
                                so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
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
                    r["tuoi"] = s_tuoi;
                    r["gioitinh"] = phai.SelectedItem.ToString();
                    r["diachi"] = sdiachi;
                    r["ngaykham"] = ngay;
                    r["lydokham"] = hen_ghichu.Text;
                    r["nghenghiep"] = tennn.Text;
                    r["doituong"] = tendoituong.Text;
                    r["sothe"] = sothe.Text;
                    r["tungay"] = (chkTiepdon.Checked) ? "Qua tiếp đón" : "";
                    r["denngay"] = denngay.Text +"^" + s_tungay;
                    r["noidkkcb"] = noidkkcb +"^" + s_cholam;
                    r["mabv"] = mabv.Text;
                    r["chandoan"] = cd_chinh.Text + "^" + tenkp.Text;
                    r["dantoc"] = s_dantoc;
                    r["benhvien"] = noidkkcb;
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
            tenkp.Enabled = false;
            phai.Enabled = false;
            butLuu.Focus();
        }
	}
}
