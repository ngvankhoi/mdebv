using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.IO.Ports;
using Paint;
using LibVienphi;
using LibMedi;

namespace Medisoft
{
	public class frmHSBenhan_NTTMH : System.Windows.Forms.Form
    {
        #region Khai bao
        private Language lan = new Language();
        private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private System.Windows.Forms.Panel p;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.ComponentModel.IContainer components;
		private string sql,s_makp,s_mabs,user,xxx,s_tenkp,s_sovaovien,s_nhomkho,s_userid;
        private string pathImage = "", FileType = "";
        private int i_userid, i_madoituong, itable, i_loai, i_maba, i_mabv, i_chinhanh = 0, i_traituyen=0;//??tu
		private DataTable dtnv=new DataTable();
		private DataTable dtg=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Button butPttt;
		private System.Windows.Forms.Button butPhanung;
		private System.Windows.Forms.Button butAn;
		private System.Windows.Forms.Button butDausinhton;
		private System.Windows.Forms.Button butDich;
		private System.Windows.Forms.Button butChamsoc;
		private System.Windows.Forms.Button butMau;
		private System.Windows.Forms.Button butDieutri;
		private System.Windows.Forms.Button butChidinh;
        private System.Windows.Forms.Button butChuyenphong;
		private System.Windows.Forms.Button butKhoa;
		private System.Windows.Forms.TextBox ngay;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sothe;
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
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Panel panel2;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedBox.MaskedBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox lydo;
		private System.Windows.Forms.TextBox hb_benhly;
		private System.Windows.Forms.TextBox hb_giadinh;
		private System.Windows.Forms.TextBox hb_banthan;
		private System.Windows.Forms.TextBox kb_toanthan;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private LibList.List listICD;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Button butKethuc;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.TextBox kb_tomtat;
		private System.Windows.Forms.TextBox kb_tuanhoan;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private MaskedTextBox.MaskedTextBox icd_kemtheo;
		private System.Windows.Forms.TextBox phanbiet;
		private System.Windows.Forms.TextBox tenbsnb;
		private MaskedTextBox.MaskedTextBox mabsnb;
		private System.Windows.Forms.TextBox tk_benhly;
		private System.Windows.Forms.TextBox tk_phuongphap;
		private System.Windows.Forms.TextBox tk_dieutri;
		private System.Windows.Forms.NumericUpDown st2;
		private System.Windows.Forms.NumericUpDown st1;
		private System.Windows.Forms.NumericUpDown st6;
		private System.Windows.Forms.NumericUpDown st3;
		private System.Windows.Forms.NumericUpDown st4;
		private System.Windows.Forms.NumericUpDown st5;
		private System.Windows.Forms.TextBox khac;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.TextBox nguoigiao;
		private MaskedTextBox.MaskedTextBox manguoigiao;
		private System.Windows.Forms.TextBox nguoinhan;
		private MaskedTextBox.MaskedTextBox manguoinhan;
		private MaskedBox.MaskedBox giovk;
		private MaskedBox.MaskedBox ngayvk;
		private MaskedBox.MaskedBox giorv;
		private MaskedBox.MaskedBox ngayrv;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.TextBox tk_tinhtrang;
		private LibList.List listNv;
		private DataSet dscd=new DataSet();
		private DataSet dsct=new DataSet();
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dthinh=new DataTable();
		private System.Windows.Forms.TextBox cd_kkb;
		private MaskedTextBox.MaskedTextBox icd_kkb;
		private DataTable dticd=new DataTable();
		private long l_maql,l_mavaovien,l_id,l_idkhoa,l_idthuchien;
		private bool b_sovaovien,b_soluutru,bAdmin;
		private System.Windows.Forms.TabPage tab2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckedListBox chonin;
		private LibList.List list1;
		private System.Windows.Forms.Button butKemtheo;
		private System.Windows.Forms.TabPage tab4;
		private System.Windows.Forms.TextBox tenbs_pass;
		private AsYetUnnamed.MultiColumnListBox list;
		private System.Windows.Forms.CheckBox chkXML;
		private LibList.List listNv1;
		private System.Windows.Forms.TextBox tk_tomtat;
		private System.Windows.Forms.Label label51;
		private MaskedTextBox.MaskedTextBox chieucao;
		private System.Windows.Forms.Label label105;
		private System.Windows.Forms.Label label106;
		private MaskedTextBox.MaskedTextBox bmi;
		private System.Windows.Forms.Button butVao;
		private System.Windows.Forms.Button butRa;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox chandoanrv;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox icdrv;
		private System.Windows.Forms.TextBox tungay;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox denngay;
		private System.Windows.Forms.TextBox kb_khac;
		private System.Windows.Forms.TextBox dieutri;
		private System.Windows.Forms.TextBox maicd;
		private System.Windows.Forms.Button butLoc;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.TextBox tenbsnb_pass;
        private byte[] image, image1;
		private Bitmap map;
        private System.IO.MemoryStream memo;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton barChuyengiuong;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton barChidinh;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton barDieutri;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton barChedoan;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton barChamsoc;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton barMau;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton barDich;
        private ToolStripButton barChonkhoa;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton barDausinhton;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton barPhanUng;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton barPttt;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton barKetthuc;
        private ComboBox xem;
        private Button butChon;
        private GroupBox groupBox2;
        private Button butHinh;
        private Button butphanungthuocohai;
		private System.IO.FileStream fstr;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton butVantay;
        public PictureBox ptb;
        private System.IO.Ports.SerialPort MSComm1;
        private Panel pgoi;
        protected Button butgoilai;
        protected Button butgoibenh;
        private Label label2;
        private NumericUpDown sonhay;
        private NumericUpDown den;
        private NumericUpDown tu;
        private int i_maxlength_mabn = 8;
        #endregion

        public frmHSBenhan_NTTMH(LibMedi.AccessData acc,string _makp,string _tenkp,string _mabs,int userid,string _nhomkho,string suserid,bool _soluutru,bool _sovaovien,bool _admin,int _loai,int _maba,int _mabv)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;s_makp=_makp;s_tenkp=_tenkp;s_mabs=_mabs;i_userid=userid;s_nhomkho=_nhomkho;i_mabv=_mabv;
			s_userid=suserid;b_sovaovien=_sovaovien;b_soluutru=_soluutru;bAdmin=_admin;i_loai=_loai;i_maba=_maba;
		}
        public frmHSBenhan_NTTMH(LibMedi.AccessData acc, string _makp, string _tenkp, string _mabs, int userid, string _nhomkho, string suserid, bool _soluutru, bool _sovaovien, bool _admin, int _loai, int _maba, int _mabv,int _i_chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = _makp; s_tenkp = _tenkp; s_mabs = _mabs; i_userid = userid; s_nhomkho = _nhomkho; i_mabv = _mabv;
            s_userid = suserid; b_sovaovien = _sovaovien; b_soluutru = _soluutru; bAdmin = _admin; i_loai = _loai; i_maba = _maba;
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
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHSBenhan_NTTMH));
            this.p = new System.Windows.Forms.Panel();
            this.butChon = new System.Windows.Forms.Button();
            this.xem = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.barChuyengiuong = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.barChidinh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.barDieutri = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.barChedoan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.barChamsoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.barMau = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.barDich = new System.Windows.Forms.ToolStripButton();
            this.barChonkhoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.barDausinhton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.barPhanUng = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.barPttt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.barKetthuc = new System.Windows.Forms.ToolStripButton();
            this.butLoc = new System.Windows.Forms.Button();
            this.butKethuc = new System.Windows.Forms.Button();
            this.butPhanung = new System.Windows.Forms.Button();
            this.butAn = new System.Windows.Forms.Button();
            this.butChamsoc = new System.Windows.Forms.Button();
            this.butDieutri = new System.Windows.Forms.Button();
            this.butChidinh = new System.Windows.Forms.Button();
            this.butKhoa = new System.Windows.Forms.Button();
            this.butDich = new System.Windows.Forms.Button();
            this.butDausinhton = new System.Windows.Forms.Button();
            this.butPttt = new System.Windows.Forms.Button();
            this.butMau = new System.Windows.Forms.Button();
            this.butChuyenphong = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butRef = new System.Windows.Forms.Button();
            this.butKemtheo = new System.Windows.Forms.Button();
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.tenbsnb_pass = new System.Windows.Forms.TextBox();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butphanungthuocohai = new System.Windows.Forms.Button();
            this.butHinh = new System.Windows.Forms.Button();
            this.butRa = new System.Windows.Forms.Button();
            this.butVao = new System.Windows.Forms.Button();
            this.chonin = new System.Windows.Forms.CheckedListBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.ngay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
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
            this.label13 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.giovk = new MaskedBox.MaskedBox();
            this.mabsnb = new MaskedTextBox.MaskedTextBox();
            this.denngay = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tungay = new System.Windows.Forms.TextBox();
            this.icdrv = new System.Windows.Forms.TextBox();
            this.chandoanrv = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.kb_khac = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.kb_toanthan = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bmi = new MaskedTextBox.MaskedTextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedBox.MaskedBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.kb_tuanhoan = new System.Windows.Forms.TextBox();
            this.hb_giadinh = new System.Windows.Forms.TextBox();
            this.hb_banthan = new System.Windows.Forms.TextBox();
            this.hb_benhly = new System.Windows.Forms.TextBox();
            this.lydo = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.kb_tomtat = new System.Windows.Forms.TextBox();
            this.listNv1 = new LibList.List();
            this.label70 = new System.Windows.Forms.Label();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.tenbsnb = new System.Windows.Forms.TextBox();
            this.maicd = new System.Windows.Forms.TextBox();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
            this.list1 = new LibList.List();
            this.listNv = new LibList.List();
            this.tk_tinhtrang = new System.Windows.Forms.TextBox();
            this.giorv = new MaskedBox.MaskedBox();
            this.ngayrv = new MaskedBox.MaskedBox();
            this.label88 = new System.Windows.Forms.Label();
            this.nguoinhan = new System.Windows.Forms.TextBox();
            this.manguoinhan = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new System.Windows.Forms.TextBox();
            this.manguoigiao = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.khac = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.st5 = new System.Windows.Forms.NumericUpDown();
            this.st4 = new System.Windows.Forms.NumericUpDown();
            this.st3 = new System.Windows.Forms.NumericUpDown();
            this.st6 = new System.Windows.Forms.NumericUpDown();
            this.st1 = new System.Windows.Forms.NumericUpDown();
            this.st2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tk_dieutri = new System.Windows.Forms.TextBox();
            this.tk_phuongphap = new System.Windows.Forms.TextBox();
            this.tk_tomtat = new System.Windows.Forms.TextBox();
            this.tk_benhly = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.listICD = new LibList.List();
            this.label65 = new System.Windows.Forms.Label();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.phanbiet = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.butVantay = new System.Windows.Forms.ToolStripButton();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.MSComm1 = new System.IO.Ports.SerialPort(this.components);
            this.pgoi = new System.Windows.Forms.Panel();
            this.butgoilai = new System.Windows.Forms.Button();
            this.butgoibenh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sonhay = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.p.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tab4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).BeginInit();
            this.panel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.SuspendLayout();
            // 
            // p
            // 
            this.p.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p.Controls.Add(this.pgoi);
            this.p.Controls.Add(this.butChon);
            this.p.Controls.Add(this.xem);
            this.p.Controls.Add(this.toolStrip1);
            this.p.Dock = System.Windows.Forms.DockStyle.Top;
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(1014, 29);
            this.p.TabIndex = 7;
            // 
            // butChon
            // 
            this.butChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChon.Location = new System.Drawing.Point(699, 2);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(52, 23);
            this.butChon.TabIndex = 304;
            this.butChon.Text = "Chọn";
            this.butChon.UseVisualStyleBackColor = true;
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // xem
            // 
            this.xem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xem.BackColor = System.Drawing.SystemColors.Info;
            this.xem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xem.Items.AddRange(new object[] {
            "Phiếu vận chuyển bệnh nhân",
            "Phiếu chuyển bệnh",
            "Hội chẩn mổ cấp cứu",
            "Bảng kiểm soát BN mổ khẩn trước khi đưa lên phòng mổ",
            "Hội chẩn duyệt mổ",
            "Bảng kiểm soát BN trước khi đưa lên phòng mổ",
            "Hội chẩn về sử dụng thuốc theo qui định",
            "Phiếu đánh giá bệnh nhân trước phẫu thuật",
            "Giấy cam đoan chấp nhận PTTT và GMHS",
            "Phiếu lĩnh và phát máu",
            "Giao nhận",
            "Phiếu sơ kết 15 ngày điều trị",
            "Phiếu cận lâm sàng bằng tập tin",
            "Thuốc đã sử dụng",
            "Công khai thuốc",
            "Công nợ",
            "Thanh toán ra viện",
            "Giấy ra viện",
            "Giấy chuyển viện",
            "Xem hồ sơ bệnh án"});
            this.xem.Location = new System.Drawing.Point(419, 3);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(275, 22);
            this.xem.TabIndex = 303;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.barChuyengiuong,
            this.toolStripSeparator2,
            this.barChidinh,
            this.toolStripSeparator3,
            this.barDieutri,
            this.toolStripSeparator4,
            this.barChedoan,
            this.toolStripSeparator5,
            this.barChamsoc,
            this.toolStripSeparator6,
            this.barMau,
            this.toolStripSeparator7,
            this.barDich,
            this.barChonkhoa,
            this.toolStripSeparator8,
            this.barDausinhton,
            this.toolStripSeparator9,
            this.barPhanUng,
            this.toolStripSeparator10,
            this.barPttt,
            this.toolStripSeparator12,
            this.butVantay,
            this.toolStripSeparator11,
            this.barKetthuc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1010, 25);
            this.toolStrip1.TabIndex = 302;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // barChuyengiuong
            // 
            this.barChuyengiuong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChuyengiuong.Image = ((System.Drawing.Image)(resources.GetObject("barChuyengiuong.Image")));
            this.barChuyengiuong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChuyengiuong.Name = "barChuyengiuong";
            this.barChuyengiuong.Size = new System.Drawing.Size(23, 22);
            this.barChuyengiuong.Text = "toolStripButton1";
            this.barChuyengiuong.ToolTipText = "Tái khám";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // barChidinh
            // 
            this.barChidinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChidinh.Image = ((System.Drawing.Image)(resources.GetObject("barChidinh.Image")));
            this.barChidinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChidinh.Name = "barChidinh";
            this.barChidinh.Size = new System.Drawing.Size(23, 22);
            this.barChidinh.Text = "toolStripButton1";
            this.barChidinh.ToolTipText = "Chỉ định cận lâm sàng";
            this.barChidinh.Click += new System.EventHandler(this.butChidinh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // barDieutri
            // 
            this.barDieutri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDieutri.Image = ((System.Drawing.Image)(resources.GetObject("barDieutri.Image")));
            this.barDieutri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDieutri.Name = "barDieutri";
            this.barDieutri.Size = new System.Drawing.Size(23, 22);
            this.barDieutri.Text = "toolStripButton1";
            this.barDieutri.ToolTipText = "Tờ điều trị";
            this.barDieutri.Click += new System.EventHandler(this.butDieutri_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // barChedoan
            // 
            this.barChedoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChedoan.Image = ((System.Drawing.Image)(resources.GetObject("barChedoan.Image")));
            this.barChedoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChedoan.Name = "barChedoan";
            this.barChedoan.Size = new System.Drawing.Size(23, 22);
            this.barChedoan.Text = "toolStripButton2";
            this.barChedoan.ToolTipText = "Chế độ ăn";
            this.barChedoan.Click += new System.EventHandler(this.butAn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // barChamsoc
            // 
            this.barChamsoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChamsoc.Image = ((System.Drawing.Image)(resources.GetObject("barChamsoc.Image")));
            this.barChamsoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChamsoc.Name = "barChamsoc";
            this.barChamsoc.Size = new System.Drawing.Size(23, 22);
            this.barChamsoc.Text = "toolStripButton3";
            this.barChamsoc.ToolTipText = "Chăm sóc";
            this.barChamsoc.Click += new System.EventHandler(this.butChamsoc_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // barMau
            // 
            this.barMau.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barMau.Image = ((System.Drawing.Image)(resources.GetObject("barMau.Image")));
            this.barMau.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barMau.Name = "barMau";
            this.barMau.Size = new System.Drawing.Size(23, 22);
            this.barMau.Text = "toolStripButton4";
            this.barMau.ToolTipText = "Truyền máu";
            this.barMau.Click += new System.EventHandler(this.butMau_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // barDich
            // 
            this.barDich.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDich.Image = ((System.Drawing.Image)(resources.GetObject("barDich.Image")));
            this.barDich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDich.Name = "barDich";
            this.barDich.Size = new System.Drawing.Size(23, 22);
            this.barDich.Text = "toolStripButton5";
            this.barDich.ToolTipText = "Truyền Dịch";
            this.barDich.Click += new System.EventHandler(this.butDich_Click);
            // 
            // barChonkhoa
            // 
            this.barChonkhoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChonkhoa.Image = ((System.Drawing.Image)(resources.GetObject("barChonkhoa.Image")));
            this.barChonkhoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChonkhoa.Name = "barChonkhoa";
            this.barChonkhoa.Size = new System.Drawing.Size(23, 22);
            this.barChonkhoa.ToolTipText = "Chọn khoa làm việc";
            this.barChonkhoa.Click += new System.EventHandler(this.butChon_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // barDausinhton
            // 
            this.barDausinhton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDausinhton.Image = ((System.Drawing.Image)(resources.GetObject("barDausinhton.Image")));
            this.barDausinhton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDausinhton.Name = "barDausinhton";
            this.barDausinhton.Size = new System.Drawing.Size(23, 22);
            this.barDausinhton.Text = "toolStripButton6";
            this.barDausinhton.ToolTipText = "Dấu sinh tồn";
            this.barDausinhton.Click += new System.EventHandler(this.butDausinhton_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // barPhanUng
            // 
            this.barPhanUng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPhanUng.Image = ((System.Drawing.Image)(resources.GetObject("barPhanUng.Image")));
            this.barPhanUng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPhanUng.Name = "barPhanUng";
            this.barPhanUng.Size = new System.Drawing.Size(23, 22);
            this.barPhanUng.Text = "toolStripButton7";
            this.barPhanUng.ToolTipText = "Phản ứng";
            this.barPhanUng.Click += new System.EventHandler(this.butPhanung_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // barPttt
            // 
            this.barPttt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPttt.Image = ((System.Drawing.Image)(resources.GetObject("barPttt.Image")));
            this.barPttt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPttt.Name = "barPttt";
            this.barPttt.Size = new System.Drawing.Size(23, 22);
            this.barPttt.Text = "toolStripButton1";
            this.barPttt.ToolTipText = "Phẫu thuật thủ thuật";
            this.barPttt.Click += new System.EventHandler(this.butPttt_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // barKetthuc
            // 
            this.barKetthuc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("barKetthuc.Image")));
            this.barKetthuc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barKetthuc.Name = "barKetthuc";
            this.barKetthuc.Size = new System.Drawing.Size(23, 22);
            this.barKetthuc.Text = "toolStripButton2";
            this.barKetthuc.ToolTipText = "Kết thúc";
            this.barKetthuc.Click += new System.EventHandler(this.butKethuc_Click);
            // 
            // butLoc
            // 
            this.butLoc.Enabled = false;
            this.butLoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butLoc.Image = ((System.Drawing.Image)(resources.GetObject("butLoc.Image")));
            this.butLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLoc.Location = new System.Drawing.Point(3, 109);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(202, 22);
            this.butLoc.TabIndex = 16;
            this.butLoc.Text = "        Phiếu lọc máu";
            this.butLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLoc.UseVisualStyleBackColor = false;
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // butKethuc
            // 
            this.butKethuc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butKethuc.Image = ((System.Drawing.Image)(resources.GetObject("butKethuc.Image")));
            this.butKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKethuc.Location = new System.Drawing.Point(3, 257);
            this.butKethuc.Name = "butKethuc";
            this.butKethuc.Size = new System.Drawing.Size(202, 22);
            this.butKethuc.TabIndex = 15;
            this.butKethuc.Text = "        Kết thúc";
            this.butKethuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butKethuc, "F10 Kết thúc");
            this.butKethuc.UseVisualStyleBackColor = false;
            this.butKethuc.Click += new System.EventHandler(this.butKethuc_Click);
            // 
            // butPhanung
            // 
            this.butPhanung.Enabled = false;
            this.butPhanung.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butPhanung.Image = ((System.Drawing.Image)(resources.GetObject("butPhanung.Image")));
            this.butPhanung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanung.Location = new System.Drawing.Point(2, 193);
            this.butPhanung.Name = "butPhanung";
            this.butPhanung.Size = new System.Drawing.Size(203, 22);
            this.butPhanung.TabIndex = 12;
            this.butPhanung.Text = "        Phản ứng thuốc";
            this.butPhanung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanung.UseVisualStyleBackColor = false;
            this.butPhanung.Click += new System.EventHandler(this.butPhanung_Click);
            // 
            // butAn
            // 
            this.butAn.Enabled = false;
            this.butAn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butAn.Image = ((System.Drawing.Image)(resources.GetObject("butAn.Image")));
            this.butAn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAn.Location = new System.Drawing.Point(2, 278);
            this.butAn.Name = "butAn";
            this.butAn.Size = new System.Drawing.Size(202, 22);
            this.butAn.TabIndex = 4;
            this.butAn.Text = "        Chế độ ăn";
            this.butAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAn.UseVisualStyleBackColor = false;
            this.butAn.Visible = false;
            this.butAn.Click += new System.EventHandler(this.butAn_Click);
            // 
            // butChamsoc
            // 
            this.butChamsoc.Enabled = false;
            this.butChamsoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butChamsoc.Image = ((System.Drawing.Image)(resources.GetObject("butChamsoc.Image")));
            this.butChamsoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChamsoc.Location = new System.Drawing.Point(3, 67);
            this.butChamsoc.Name = "butChamsoc";
            this.butChamsoc.Size = new System.Drawing.Size(202, 22);
            this.butChamsoc.TabIndex = 5;
            this.butChamsoc.Text = "        Chăm sóc";
            this.butChamsoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChamsoc.UseVisualStyleBackColor = false;
            this.butChamsoc.Click += new System.EventHandler(this.butChamsoc_Click);
            // 
            // butDieutri
            // 
            this.butDieutri.Enabled = false;
            this.butDieutri.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butDieutri.Image = ((System.Drawing.Image)(resources.GetObject("butDieutri.Image")));
            this.butDieutri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDieutri.Location = new System.Drawing.Point(3, 46);
            this.butDieutri.Name = "butDieutri";
            this.butDieutri.Size = new System.Drawing.Size(202, 22);
            this.butDieutri.TabIndex = 3;
            this.butDieutri.Text = "        Tờ điều trị";
            this.butDieutri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDieutri.UseVisualStyleBackColor = false;
            this.butDieutri.Click += new System.EventHandler(this.butDieutri_Click);
            // 
            // butChidinh
            // 
            this.butChidinh.Enabled = false;
            this.butChidinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butChidinh.Image = ((System.Drawing.Image)(resources.GetObject("butChidinh.Image")));
            this.butChidinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChidinh.Location = new System.Drawing.Point(3, 24);
            this.butChidinh.Name = "butChidinh";
            this.butChidinh.Size = new System.Drawing.Size(202, 23);
            this.butChidinh.TabIndex = 2;
            this.butChidinh.Text = "        Phiếu chỉ định";
            this.butChidinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChidinh.UseVisualStyleBackColor = false;
            this.butChidinh.Click += new System.EventHandler(this.butChidinh_Click);
            // 
            // butKhoa
            // 
            this.butKhoa.Enabled = false;
            this.butKhoa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butKhoa.Image = ((System.Drawing.Image)(resources.GetObject("butKhoa.Image")));
            this.butKhoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhoa.Location = new System.Drawing.Point(3, 3);
            this.butKhoa.Name = "butKhoa";
            this.butKhoa.Size = new System.Drawing.Size(202, 22);
            this.butKhoa.TabIndex = 0;
            this.butKhoa.Text = "        Tái khám";
            this.butKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhoa.UseVisualStyleBackColor = false;
            this.butKhoa.Click += new System.EventHandler(this.butKhoa_Click);
            // 
            // butDich
            // 
            this.butDich.Enabled = false;
            this.butDich.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butDich.Image = ((System.Drawing.Image)(resources.GetObject("butDich.Image")));
            this.butDich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDich.Location = new System.Drawing.Point(3, 130);
            this.butDich.Name = "butDich";
            this.butDich.Size = new System.Drawing.Size(202, 22);
            this.butDich.TabIndex = 7;
            this.butDich.Text = "        Truyền dịch";
            this.butDich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDich.UseVisualStyleBackColor = false;
            this.butDich.Click += new System.EventHandler(this.butDich_Click);
            // 
            // butDausinhton
            // 
            this.butDausinhton.Enabled = false;
            this.butDausinhton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butDausinhton.Image = ((System.Drawing.Image)(resources.GetObject("butDausinhton.Image")));
            this.butDausinhton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDausinhton.Location = new System.Drawing.Point(3, 151);
            this.butDausinhton.Name = "butDausinhton";
            this.butDausinhton.Size = new System.Drawing.Size(202, 22);
            this.butDausinhton.TabIndex = 10;
            this.butDausinhton.Text = "        Chức năng sống";
            this.butDausinhton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDausinhton.UseVisualStyleBackColor = false;
            this.butDausinhton.Click += new System.EventHandler(this.butDausinhton_Click);
            // 
            // butPttt
            // 
            this.butPttt.Enabled = false;
            this.butPttt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butPttt.Image = ((System.Drawing.Image)(resources.GetObject("butPttt.Image")));
            this.butPttt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPttt.Location = new System.Drawing.Point(2, 172);
            this.butPttt.Name = "butPttt";
            this.butPttt.Size = new System.Drawing.Size(203, 22);
            this.butPttt.TabIndex = 11;
            this.butPttt.Text = "        Phẩu thủ thuật";
            this.butPttt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPttt.UseVisualStyleBackColor = false;
            this.butPttt.Click += new System.EventHandler(this.butPttt_Click);
            // 
            // butMau
            // 
            this.butMau.Enabled = false;
            this.butMau.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butMau.Image = ((System.Drawing.Image)(resources.GetObject("butMau.Image")));
            this.butMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMau.Location = new System.Drawing.Point(3, 88);
            this.butMau.Name = "butMau";
            this.butMau.Size = new System.Drawing.Size(202, 22);
            this.butMau.TabIndex = 6;
            this.butMau.Text = "        Truyền máu";
            this.butMau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMau.UseVisualStyleBackColor = false;
            this.butMau.Click += new System.EventHandler(this.butMau_Click);
            // 
            // butChuyenphong
            // 
            this.butChuyenphong.Enabled = false;
            this.butChuyenphong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butChuyenphong.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butChuyenphong.Location = new System.Drawing.Point(136, 696);
            this.butChuyenphong.Name = "butChuyenphong";
            this.butChuyenphong.Size = new System.Drawing.Size(52, 35);
            this.butChuyenphong.TabIndex = 1;
            this.butChuyenphong.Text = "Vật lý trị liệu";
            this.butChuyenphong.Visible = false;
            this.butChuyenphong.Click += new System.EventHandler(this.butChuyenphong_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(184, 34);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(22, 21);
            this.butRef.TabIndex = 6;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách người bệnh");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // butKemtheo
            // 
            this.butKemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKemtheo.Enabled = false;
            this.butKemtheo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butKemtheo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKemtheo.Location = new System.Drawing.Point(761, 229);
            this.butKemtheo.Name = "butKemtheo";
            this.butKemtheo.Size = new System.Drawing.Size(22, 21);
            this.butKemtheo.TabIndex = 298;
            this.butKemtheo.Text = "...";
            this.toolTip1.SetToolTip(this.butKemtheo, "Chẩn đoán kèm theo");
            this.butKemtheo.Click += new System.EventHandler(this.butKemtheo_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(720, 502);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbs_pass.TabIndex = 18;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_pass_KeyDown);
            // 
            // tenbsnb_pass
            // 
            this.tenbsnb_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbsnb_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb_pass.Enabled = false;
            this.tenbsnb_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb_pass.Location = new System.Drawing.Point(688, 548);
            this.tenbsnb_pass.Name = "tenbsnb_pass";
            this.tenbsnb_pass.PasswordChar = '*';
            this.tenbsnb_pass.Size = new System.Drawing.Size(96, 21);
            this.tenbsnb_pass.TabIndex = 19;
            this.toolTip1.SetToolTip(this.tenbsnb_pass, "Mật khẩu bác sĩ làm bệnh án");
            this.tenbsnb_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_pass_KeyDown);
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 56);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(206, 199);
            this.list.TabIndex = 12;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F3 chọn");
            this.list.ValueIndex = -1;
            this.list.MouseEnter += new System.EventHandler(this.list_MouseEnter);
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(711, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(90, 72);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 308;
            this.pic.TabStop = false;
            this.toolTip1.SetToolTip(this.pic, "DoubleClick phóng to hình");
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.butphanungthuocohai);
            this.panel1.Controls.Add(this.butHinh);
            this.panel1.Controls.Add(this.butKethuc);
            this.panel1.Controls.Add(this.butLoc);
            this.panel1.Controls.Add(this.butPhanung);
            this.panel1.Controls.Add(this.butRa);
            this.panel1.Controls.Add(this.butPttt);
            this.panel1.Controls.Add(this.butDausinhton);
            this.panel1.Controls.Add(this.butDich);
            this.panel1.Controls.Add(this.butVao);
            this.panel1.Controls.Add(this.butChamsoc);
            this.panel1.Controls.Add(this.butAn);
            this.panel1.Controls.Add(this.chonin);
            this.panel1.Controls.Add(this.butMau);
            this.panel1.Controls.Add(this.butDieutri);
            this.panel1.Controls.Add(this.butKhoa);
            this.panel1.Controls.Add(this.butChidinh);
            this.panel1.Location = new System.Drawing.Point(2, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 363);
            this.panel1.TabIndex = 0;
            // 
            // butphanungthuocohai
            // 
            this.butphanungthuocohai.Enabled = false;
            this.butphanungthuocohai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butphanungthuocohai.Image = ((System.Drawing.Image)(resources.GetObject("butphanungthuocohai.Image")));
            this.butphanungthuocohai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butphanungthuocohai.Location = new System.Drawing.Point(2, 214);
            this.butphanungthuocohai.Name = "butphanungthuocohai";
            this.butphanungthuocohai.Size = new System.Drawing.Size(203, 23);
            this.butphanungthuocohai.TabIndex = 303;
            this.butphanungthuocohai.Text = "        Phản ứng thuốc có hại";
            this.butphanungthuocohai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butphanungthuocohai.UseVisualStyleBackColor = false;
            this.butphanungthuocohai.Click += new System.EventHandler(this.butphanungthuocohai_Click);
            // 
            // butHinh
            // 
            this.butHinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butHinh.Image = ((System.Drawing.Image)(resources.GetObject("butHinh.Image")));
            this.butHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHinh.Location = new System.Drawing.Point(2, 236);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(203, 22);
            this.butHinh.TabIndex = 17;
            this.butHinh.Text = "        Chọn hình";
            this.butHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHinh.UseVisualStyleBackColor = false;
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // butRa
            // 
            this.butRa.Enabled = false;
            this.butRa.Image = ((System.Drawing.Image)(resources.GetObject("butRa.Image")));
            this.butRa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRa.Location = new System.Drawing.Point(109, 301);
            this.butRa.Name = "butRa";
            this.butRa.Size = new System.Drawing.Size(96, 24);
            this.butRa.TabIndex = 14;
            this.butRa.Text = "     Thông tin &ra";
            this.butRa.Click += new System.EventHandler(this.butRa_Click);
            // 
            // butVao
            // 
            this.butVao.Image = ((System.Drawing.Image)(resources.GetObject("butVao.Image")));
            this.butVao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVao.Location = new System.Drawing.Point(2, 301);
            this.butVao.Name = "butVao";
            this.butVao.Size = new System.Drawing.Size(104, 24);
            this.butVao.TabIndex = 13;
            this.butVao.Text = "     Thông tin &vào";
            this.butVao.Click += new System.EventHandler(this.butVao_Click);
            // 
            // chonin
            // 
            this.chonin.CheckOnClick = true;
            this.chonin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonin.Items.AddRange(new object[] {
            "Trang 1",
            "Trang 2"});
            this.chonin.Location = new System.Drawing.Point(0, 325);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(208, 36);
            this.chonin.TabIndex = 11;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 34);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(206, 21);
            this.tim.TabIndex = 10;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.butRef);
            this.groupBox1.Controls.Add(this.tim);
            this.groupBox1.Controls.Add(this.list);
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 256);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(130, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(68, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Hồ sơ củ";
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(8, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(136, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Hồ sơ đang điều trị";
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(83, 37);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(92, 21);
            this.ngay.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-2, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Ngày vào viện :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(214, 37);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 21);
            this.sothe.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(166, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(595, 14);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(206, 21);
            this.diachi.TabIndex = 37;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(515, 14);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 36;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(403, 14);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 35;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(214, 14);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 34;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(83, 14);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(73, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(547, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(331, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(403, 37);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(398, 21);
            this.chandoan.TabIndex = 51;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Location = new System.Drawing.Point(216, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 605);
            this.tabControl1.TabIndex = 3;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.giovk);
            this.tab2.Controls.Add(this.mabsnb);
            this.tab2.Controls.Add(this.denngay);
            this.tab2.Controls.Add(this.label23);
            this.tab2.Controls.Add(this.tungay);
            this.tab2.Controls.Add(this.icdrv);
            this.tab2.Controls.Add(this.chandoanrv);
            this.tab2.Controls.Add(this.label22);
            this.tab2.Controls.Add(this.label21);
            this.tab2.Controls.Add(this.kb_khac);
            this.tab2.Controls.Add(this.label52);
            this.tab2.Controls.Add(this.label20);
            this.tab2.Controls.Add(this.label19);
            this.tab2.Controls.Add(this.label17);
            this.tab2.Controls.Add(this.kb_toanthan);
            this.tab2.Controls.Add(this.panel2);
            this.tab2.Controls.Add(this.dieutri);
            this.tab2.Controls.Add(this.kb_tuanhoan);
            this.tab2.Controls.Add(this.hb_giadinh);
            this.tab2.Controls.Add(this.hb_banthan);
            this.tab2.Controls.Add(this.hb_benhly);
            this.tab2.Controls.Add(this.lydo);
            this.tab2.Controls.Add(this.label37);
            this.tab2.Controls.Add(this.label36);
            this.tab2.Controls.Add(this.label35);
            this.tab2.Controls.Add(this.label34);
            this.tab2.Controls.Add(this.label16);
            this.tab2.Controls.Add(this.label28);
            this.tab2.Controls.Add(this.label29);
            this.tab2.Controls.Add(this.label15);
            this.tab2.Controls.Add(this.label14);
            this.tab2.Controls.Add(this.kb_tomtat);
            this.tab2.Controls.Add(this.listNv1);
            this.tab2.Controls.Add(this.label70);
            this.tab2.Controls.Add(this.ngayvk);
            this.tab2.Controls.Add(this.label89);
            this.tab2.Controls.Add(this.label71);
            this.tab2.Controls.Add(this.tenbsnb);
            this.tab2.Controls.Add(this.tenbsnb_pass);
            this.tab2.Controls.Add(this.maicd);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(792, 579);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Trang 1";
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Enabled = false;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(235, 548);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(40, 21);
            this.giovk.TabIndex = 16;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // mabsnb
            // 
            this.mabsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsnb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabsnb.Enabled = false;
            this.mabsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsnb.Location = new System.Drawing.Point(320, 548);
            this.mabsnb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabsnb.MaxLength = 9;
            this.mabsnb.Name = "mabsnb";
            this.mabsnb.Size = new System.Drawing.Size(48, 21);
            this.mabsnb.TabIndex = 17;
            this.mabsnb.Validated += new System.EventHandler(this.mabsnb_Validated);
            this.mabsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Enabled = false;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(320, 525);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(112, 21);
            this.denngay.TabIndex = 14;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(256, 528);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 282;
            this.label23.Text = "đến ngày :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Enabled = false;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(136, 525);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(112, 21);
            this.tungay.TabIndex = 13;
            // 
            // icdrv
            // 
            this.icdrv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icdrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icdrv.Enabled = false;
            this.icdrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icdrv.Location = new System.Drawing.Point(728, 502);
            this.icdrv.Name = "icdrv";
            this.icdrv.Size = new System.Drawing.Size(56, 21);
            this.icdrv.TabIndex = 12;
            // 
            // chandoanrv
            // 
            this.chandoanrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoanrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoanrv.Enabled = false;
            this.chandoanrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoanrv.Location = new System.Drawing.Point(136, 502);
            this.chandoanrv.Name = "chandoanrv";
            this.chandoanrv.Size = new System.Drawing.Size(590, 21);
            this.chandoanrv.TabIndex = 11;
            this.chandoanrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 528);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(152, 16);
            this.label22.TabIndex = 279;
            this.label22.Text = "7. Điều trị từ ngày :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 505);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(152, 16);
            this.label21.TabIndex = 278;
            this.label21.Text = "6. Chẩn đoán ra viện :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_khac
            // 
            this.kb_khac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kb_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_khac.Enabled = false;
            this.kb_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_khac.Location = new System.Drawing.Point(136, 418);
            this.kb_khac.Name = "kb_khac";
            this.kb_khac.Size = new System.Drawing.Size(648, 21);
            this.kb_khac.TabIndex = 9;
            this.kb_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(72, 443);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(120, 16);
            this.label52.TabIndex = 99;
            this.label52.Text = "( thuốc, chăm sóc ) :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(8, 443);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 16);
            this.label20.TabIndex = 277;
            this.label20.Text = "5. Đã xử lý ";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 421);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(208, 16);
            this.label19.TabIndex = 276;
            this.label19.Text = "4. Chẩn đoán ban đầu :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 327);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(208, 16);
            this.label17.TabIndex = 275;
            this.label17.Text = "3. Tóm tắt bệnh án :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_toanthan
            // 
            this.kb_toanthan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kb_toanthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_toanthan.Enabled = false;
            this.kb_toanthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_toanthan.Location = new System.Drawing.Point(136, 208);
            this.kb_toanthan.Multiline = true;
            this.kb_toanthan.Name = "kb_toanthan";
            this.kb_toanthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_toanthan.Size = new System.Drawing.Size(488, 48);
            this.kb_toanthan.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bmi);
            this.panel2.Controls.Add(this.label106);
            this.panel2.Controls.Add(this.label105);
            this.panel2.Controls.Add(this.chieucao);
            this.panel2.Controls.Add(this.label51);
            this.panel2.Controls.Add(this.nhietdo);
            this.panel2.Controls.Add(this.huyetap);
            this.panel2.Controls.Add(this.nhiptho);
            this.panel2.Controls.Add(this.cannang);
            this.panel2.Controls.Add(this.mach);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.label41);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.label46);
            this.panel2.Controls.Add(this.label47);
            this.panel2.Controls.Add(this.label48);
            this.panel2.Location = new System.Drawing.Point(634, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 160);
            this.panel2.TabIndex = 7;
            // 
            // bmi
            // 
            this.bmi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bmi.Enabled = false;
            this.bmi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmi.Location = new System.Drawing.Point(64, 137);
            this.bmi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bmi.MaxLength = 5;
            this.bmi.Name = "bmi";
            this.bmi.Size = new System.Drawing.Size(48, 21);
            this.bmi.TabIndex = 6;
            this.bmi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label106
            // 
            this.label106.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(16, 142);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(48, 16);
            this.label106.TabIndex = 23;
            this.label106.Text = "BMI :";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label105
            // 
            this.label105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(112, 120);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(32, 16);
            this.label105.TabIndex = 22;
            this.label105.Text = "cm";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Enabled = false;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(64, 115);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(40, 21);
            this.chieucao.TabIndex = 5;
            this.chieucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chieucao.Validated += new System.EventHandler(this.chieucao_Validated);
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(0, 120);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(64, 16);
            this.label51.TabIndex = 20;
            this.label51.Text = "Chiều cao :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(64, 25);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 1;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(64, 48);
            this.huyetap.Mask = "###/###";
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 2;
            this.huyetap.Text = "   /   ";
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(64, 70);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 3;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(64, 93);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 4;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(64, 2);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 0;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(99, 4);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 19);
            this.label39.TabIndex = 11;
            this.label39.Text = "lần/phút";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(96, 29);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 16);
            this.label40.TabIndex = 13;
            this.label40.Text = "°C";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(112, 48);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 16);
            this.label41.TabIndex = 16;
            this.label41.Text = "mmHg";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(99, 73);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 16);
            this.label42.TabIndex = 18;
            this.label42.Text = "lần/phút";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(107, 95);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 16);
            this.label43.TabIndex = 19;
            this.label43.Text = "Kg";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(0, 96);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(64, 16);
            this.label44.TabIndex = 7;
            this.label44.Text = "Cân nặng :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(8, 74);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 6;
            this.label45.Text = "Nhịp thở :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(0, 53);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(64, 16);
            this.label46.TabIndex = 5;
            this.label46.Text = "Huyết áp :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(8, 29);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 16);
            this.label47.TabIndex = 4;
            this.label47.Text = "Nhiệt độ :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(24, 5);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(40, 16);
            this.label48.TabIndex = 3;
            this.label48.Text = "Mạch :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dieutri
            // 
            this.dieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Enabled = false;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(136, 459);
            this.dieutri.Multiline = true;
            this.dieutri.Name = "dieutri";
            this.dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dieutri.Size = new System.Drawing.Size(648, 40);
            this.dieutri.TabIndex = 10;
            // 
            // kb_tuanhoan
            // 
            this.kb_tuanhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kb_tuanhoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tuanhoan.Enabled = false;
            this.kb_tuanhoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tuanhoan.Location = new System.Drawing.Point(136, 260);
            this.kb_tuanhoan.Multiline = true;
            this.kb_tuanhoan.Name = "kb_tuanhoan";
            this.kb_tuanhoan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_tuanhoan.Size = new System.Drawing.Size(488, 67);
            this.kb_tuanhoan.TabIndex = 6;
            // 
            // hb_giadinh
            // 
            this.hb_giadinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hb_giadinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_giadinh.Enabled = false;
            this.hb_giadinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_giadinh.Location = new System.Drawing.Point(136, 142);
            this.hb_giadinh.Multiline = true;
            this.hb_giadinh.Name = "hb_giadinh";
            this.hb_giadinh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_giadinh.Size = new System.Drawing.Size(648, 38);
            this.hb_giadinh.TabIndex = 4;
            // 
            // hb_banthan
            // 
            this.hb_banthan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hb_banthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_banthan.Enabled = false;
            this.hb_banthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_banthan.Location = new System.Drawing.Point(136, 100);
            this.hb_banthan.Multiline = true;
            this.hb_banthan.Name = "hb_banthan";
            this.hb_banthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_banthan.Size = new System.Drawing.Size(648, 40);
            this.hb_banthan.TabIndex = 3;
            // 
            // hb_benhly
            // 
            this.hb_benhly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hb_benhly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_benhly.Enabled = false;
            this.hb_benhly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_benhly.Location = new System.Drawing.Point(136, 56);
            this.hb_benhly.Multiline = true;
            this.hb_benhly.Name = "hb_benhly";
            this.hb_benhly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_benhly.Size = new System.Drawing.Size(648, 32);
            this.hb_benhly.TabIndex = 2;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(136, 8);
            this.lydo.Multiline = true;
            this.lydo.Name = "lydo";
            this.lydo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lydo.Size = new System.Drawing.Size(648, 35);
            this.lydo.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(8, 260);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 16);
            this.label37.TabIndex = 97;
            this.label37.Text = "2. Bệnh chuyên khoa :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(8, 210);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(136, 16);
            this.label36.TabIndex = 96;
            this.label36.Text = "1. Toàn thân :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(8, 188);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(107, 17);
            this.label35.TabIndex = 95;
            this.label35.Text = "IV. Khám bệnh :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(16, 151);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 16);
            this.label34.TabIndex = 94;
            this.label34.Text = "+ Gia đình :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 16);
            this.label16.TabIndex = 66;
            this.label16.Text = "+ Bản thân : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(8, 87);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 16);
            this.label28.TabIndex = 65;
            this.label28.Text = "2. Tiền sử bệnh :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(8, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(136, 16);
            this.label29.TabIndex = 64;
            this.label29.Text = "1. Quá trình bệnh lý :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(8, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 62;
            this.label15.Text = "III. Hỏi bệnh :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 17);
            this.label14.TabIndex = 61;
            this.label14.Text = "II. Lý do vào viện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_tomtat
            // 
            this.kb_tomtat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kb_tomtat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tomtat.Enabled = false;
            this.kb_tomtat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tomtat.Location = new System.Drawing.Point(136, 344);
            this.kb_tomtat.Multiline = true;
            this.kb_tomtat.Name = "kb_tomtat";
            this.kb_tomtat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_tomtat.Size = new System.Drawing.Size(648, 72);
            this.kb_tomtat.TabIndex = 8;
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(32, 384);
            this.listNv1.MatchBufferTimeOut = 1000;
            this.listNv1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv1.Name = "listNv1";
            this.listNv1.Size = new System.Drawing.Size(75, 17);
            this.listNv1.TabIndex = 299;
            this.listNv1.TextIndex = -1;
            this.listNv1.TextMember = null;
            this.listNv1.ValueIndex = -1;
            this.listNv1.Visible = false;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(88, 553);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 16);
            this.label70.TabIndex = 113;
            this.label70.Text = "Ngày :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Enabled = false;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(136, 548);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(72, 21);
            this.ngayvk.TabIndex = 15;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(208, 553);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(32, 16);
            this.label89.TabIndex = 290;
            this.label89.Text = "Giờ :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(277, 553);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(48, 16);
            this.label71.TabIndex = 114;
            this.label71.Text = "Bác sĩ  :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbsnb
            // 
            this.tenbsnb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb.Enabled = false;
            this.tenbsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb.Location = new System.Drawing.Point(370, 548);
            this.tenbsnb.Name = "tenbsnb";
            this.tenbsnb.Size = new System.Drawing.Size(316, 21);
            this.tenbsnb.TabIndex = 18;
            this.tenbsnb.TextChanged += new System.EventHandler(this.tenbsnb_TextChanged);
            this.tenbsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(370, 464);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(56, 21);
            this.maicd.TabIndex = 301;
            // 
            // tab4
            // 
            this.tab4.Controls.Add(this.icd_kemtheo);
            this.tab4.Controls.Add(this.tenbs_pass);
            this.tab4.Controls.Add(this.list1);
            this.tab4.Controls.Add(this.listNv);
            this.tab4.Controls.Add(this.tk_tinhtrang);
            this.tab4.Controls.Add(this.giorv);
            this.tab4.Controls.Add(this.ngayrv);
            this.tab4.Controls.Add(this.label88);
            this.tab4.Controls.Add(this.nguoinhan);
            this.tab4.Controls.Add(this.manguoinhan);
            this.tab4.Controls.Add(this.nguoigiao);
            this.tab4.Controls.Add(this.manguoigiao);
            this.tab4.Controls.Add(this.tenbs);
            this.tab4.Controls.Add(this.mabs);
            this.tab4.Controls.Add(this.panel12);
            this.tab4.Controls.Add(this.panel10);
            this.tab4.Controls.Add(this.khac);
            this.tab4.Controls.Add(this.label81);
            this.tab4.Controls.Add(this.label80);
            this.tab4.Controls.Add(this.label79);
            this.tab4.Controls.Add(this.label78);
            this.tab4.Controls.Add(this.label9);
            this.tab4.Controls.Add(this.st5);
            this.tab4.Controls.Add(this.st4);
            this.tab4.Controls.Add(this.st3);
            this.tab4.Controls.Add(this.st6);
            this.tab4.Controls.Add(this.st1);
            this.tab4.Controls.Add(this.st2);
            this.tab4.Controls.Add(this.label8);
            this.tab4.Controls.Add(this.tk_dieutri);
            this.tab4.Controls.Add(this.tk_phuongphap);
            this.tab4.Controls.Add(this.tk_tomtat);
            this.tab4.Controls.Add(this.tk_benhly);
            this.tab4.Controls.Add(this.label77);
            this.tab4.Controls.Add(this.label76);
            this.tab4.Controls.Add(this.label75);
            this.tab4.Controls.Add(this.label74);
            this.tab4.Controls.Add(this.label73);
            this.tab4.Controls.Add(this.label72);
            this.tab4.Controls.Add(this.panel9);
            this.tab4.Controls.Add(this.label90);
            this.tab4.Controls.Add(this.label87);
            this.tab4.Controls.Add(this.label86);
            this.tab4.Controls.Add(this.label85);
            this.tab4.Controls.Add(this.label64);
            this.tab4.Controls.Add(this.listICD);
            this.tab4.Controls.Add(this.label65);
            this.tab4.Controls.Add(this.icd_kkb);
            this.tab4.Controls.Add(this.cd_kkb);
            this.tab4.Controls.Add(this.label66);
            this.tab4.Controls.Add(this.cd_kemtheo);
            this.tab4.Controls.Add(this.butKemtheo);
            this.tab4.Controls.Add(this.label67);
            this.tab4.Controls.Add(this.phanbiet);
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(792, 579);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Trang 2";
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Enabled = false;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(163, 229);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
            this.icd_kemtheo.TabIndex = 4;
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // list1
            // 
            this.list1.BackColor = System.Drawing.SystemColors.Info;
            this.list1.ColumnCount = 0;
            this.list1.Location = new System.Drawing.Point(472, 0);
            this.list1.MatchBufferTimeOut = 1000;
            this.list1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(75, 17);
            this.list1.TabIndex = 297;
            this.list1.TextIndex = -1;
            this.list1.TextMember = null;
            this.list1.ValueIndex = -1;
            this.list1.Visible = false;
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(352, 0);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 296;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // tk_tinhtrang
            // 
            this.tk_tinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tk_tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_tinhtrang.Enabled = false;
            this.tk_tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_tinhtrang.Location = new System.Drawing.Point(24, 339);
            this.tk_tinhtrang.Multiline = true;
            this.tk_tinhtrang.Name = "tk_tinhtrang";
            this.tk_tinhtrang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_tinhtrang.Size = new System.Drawing.Size(760, 32);
            this.tk_tinhtrang.TabIndex = 8;
            // 
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Enabled = false;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(456, 478);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(40, 21);
            this.giorv.TabIndex = 15;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // ngayrv
            // 
            this.ngayrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrv.Enabled = false;
            this.ngayrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrv.Location = new System.Drawing.Point(349, 478);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(72, 21);
            this.ngayrv.TabIndex = 14;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(426, 480);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 295;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nguoinhan
            // 
            this.nguoinhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoinhan.Enabled = false;
            this.nguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoinhan.Location = new System.Drawing.Point(387, 455);
            this.nguoinhan.Name = "nguoinhan";
            this.nguoinhan.Size = new System.Drawing.Size(397, 21);
            this.nguoinhan.TabIndex = 13;
            this.nguoinhan.TextChanged += new System.EventHandler(this.nguoinhan_TextChanged);
            this.nguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoinhan
            // 
            this.manguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoinhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoinhan.Enabled = false;
            this.manguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoinhan.Location = new System.Drawing.Point(349, 455);
            this.manguoinhan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoinhan.MaxLength = 9;
            this.manguoinhan.Name = "manguoinhan";
            this.manguoinhan.Size = new System.Drawing.Size(36, 21);
            this.manguoinhan.TabIndex = 12;
            this.manguoinhan.Validated += new System.EventHandler(this.manguoinhan_Validated);
            this.manguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // nguoigiao
            // 
            this.nguoigiao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(387, 432);
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(397, 21);
            this.nguoigiao.TabIndex = 11;
            this.nguoigiao.TextChanged += new System.EventHandler(this.nguoigiao_TextChanged);
            this.nguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoigiao
            // 
            this.manguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoigiao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoigiao.Enabled = false;
            this.manguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoigiao.Location = new System.Drawing.Point(349, 432);
            this.manguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoigiao.MaxLength = 9;
            this.manguoigiao.Name = "manguoigiao";
            this.manguoigiao.Size = new System.Drawing.Size(36, 21);
            this.manguoigiao.TabIndex = 10;
            this.manguoigiao.Validated += new System.EventHandler(this.manguoigiao_Validated);
            this.manguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(386, 502);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(333, 21);
            this.tenbs.TabIndex = 17;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(349, 502);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(36, 21);
            this.mabs.TabIndex = 16;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Location = new System.Drawing.Point(200, 446);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1, 120);
            this.panel12.TabIndex = 277;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(7, 464);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(238, 1);
            this.panel10.TabIndex = 276;
            // 
            // khac
            // 
            this.khac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(52, 531);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(139, 14);
            this.khac.TabIndex = 28;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label81
            // 
            this.label81.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(15, 547);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(80, 16);
            this.label81.TabIndex = 274;
            this.label81.Text = "Toàn bộ hồ sơ";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(15, 531);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(56, 16);
            this.label80.TabIndex = 273;
            this.label80.Text = "Khác ";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(15, 515);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(64, 16);
            this.label79.TabIndex = 272;
            this.label79.Text = "Xét nghiệm";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(15, 499);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(56, 16);
            this.label78.TabIndex = 271;
            this.label78.Text = "Siêu âm";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 483);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 270;
            this.label9.Text = "CT Scanner";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st5
            // 
            this.st5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st5.Enabled = false;
            this.st5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st5.Location = new System.Drawing.Point(203, 531);
            this.st5.Name = "st5";
            this.st5.Size = new System.Drawing.Size(40, 17);
            this.st5.TabIndex = 29;
            this.st5.ValueChanged += new System.EventHandler(this.st1_Validated);
            this.st5.Validated += new System.EventHandler(this.st1_Validated);
            this.st5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // st4
            // 
            this.st4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st4.Enabled = false;
            this.st4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st4.Location = new System.Drawing.Point(203, 515);
            this.st4.Name = "st4";
            this.st4.Size = new System.Drawing.Size(40, 17);
            this.st4.TabIndex = 27;
            this.st4.ValueChanged += new System.EventHandler(this.st1_Validated);
            this.st4.Validated += new System.EventHandler(this.st1_Validated);
            this.st4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // st3
            // 
            this.st3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st3.Enabled = false;
            this.st3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st3.Location = new System.Drawing.Point(203, 499);
            this.st3.Name = "st3";
            this.st3.Size = new System.Drawing.Size(40, 17);
            this.st3.TabIndex = 26;
            this.st3.ValueChanged += new System.EventHandler(this.st1_Validated);
            this.st3.Validated += new System.EventHandler(this.st1_Validated);
            this.st3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // st6
            // 
            this.st6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st6.Enabled = false;
            this.st6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st6.Location = new System.Drawing.Point(203, 547);
            this.st6.Name = "st6";
            this.st6.Size = new System.Drawing.Size(40, 17);
            this.st6.TabIndex = 30;
            this.st6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // st1
            // 
            this.st1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st1.Enabled = false;
            this.st1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st1.Location = new System.Drawing.Point(203, 467);
            this.st1.Name = "st1";
            this.st1.Size = new System.Drawing.Size(40, 17);
            this.st1.TabIndex = 24;
            this.st1.ValueChanged += new System.EventHandler(this.st1_Validated);
            this.st1.Validated += new System.EventHandler(this.st1_Validated);
            this.st1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // st2
            // 
            this.st2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.st2.Enabled = false;
            this.st2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st2.Location = new System.Drawing.Point(203, 483);
            this.st2.Name = "st2";
            this.st2.Size = new System.Drawing.Size(40, 17);
            this.st2.TabIndex = 25;
            this.st2.ValueChanged += new System.EventHandler(this.st1_Validated);
            this.st2.Validated += new System.EventHandler(this.st1_Validated);
            this.st2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 262;
            this.label8.Text = "X-quang";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tk_dieutri
            // 
            this.tk_dieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tk_dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_dieutri.Enabled = false;
            this.tk_dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_dieutri.Location = new System.Drawing.Point(24, 387);
            this.tk_dieutri.Multiline = true;
            this.tk_dieutri.Name = "tk_dieutri";
            this.tk_dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_dieutri.Size = new System.Drawing.Size(760, 38);
            this.tk_dieutri.TabIndex = 9;
            // 
            // tk_phuongphap
            // 
            this.tk_phuongphap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tk_phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_phuongphap.Enabled = false;
            this.tk_phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_phuongphap.Location = new System.Drawing.Point(24, 289);
            this.tk_phuongphap.Multiline = true;
            this.tk_phuongphap.Name = "tk_phuongphap";
            this.tk_phuongphap.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_phuongphap.Size = new System.Drawing.Size(760, 32);
            this.tk_phuongphap.TabIndex = 7;
            // 
            // tk_tomtat
            // 
            this.tk_tomtat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tk_tomtat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_tomtat.Enabled = false;
            this.tk_tomtat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_tomtat.Location = new System.Drawing.Point(24, 134);
            this.tk_tomtat.Multiline = true;
            this.tk_tomtat.Name = "tk_tomtat";
            this.tk_tomtat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_tomtat.Size = new System.Drawing.Size(760, 58);
            this.tk_tomtat.TabIndex = 1;
            // 
            // tk_benhly
            // 
            this.tk_benhly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tk_benhly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_benhly.Enabled = false;
            this.tk_benhly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_benhly.Location = new System.Drawing.Point(24, 43);
            this.tk_benhly.Multiline = true;
            this.tk_benhly.Name = "tk_benhly";
            this.tk_benhly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_benhly.Size = new System.Drawing.Size(760, 69);
            this.tk_benhly.TabIndex = 0;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(8, 371);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(264, 16);
            this.label77.TabIndex = 122;
            this.label77.Text = "6. Hướng điều trị và các chế độ tiếp theo :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(8, 321);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(208, 16);
            this.label76.TabIndex = 121;
            this.label76.Text = "5. Tình trạng người bệnh ra viện :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(8, 270);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(160, 16);
            this.label75.TabIndex = 120;
            this.label75.Text = "4. Phương pháp điều trị :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(8, 115);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(384, 16);
            this.label74.TabIndex = 119;
            this.label74.Text = "2. Tóm tắt kết quả xét nghiệm cận lâm sàng có giá trị chẩn đoán :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(8, 24);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(256, 16);
            this.label73.TabIndex = 118;
            this.label73.Text = "1. Quá trình bệnh lý và diễn biến lâm sàng :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label72.Location = new System.Drawing.Point(8, 6);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(168, 17);
            this.label72.TabIndex = 115;
            this.label72.Text = "B. TỔNG KẾT BỆNH ÁN :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label82);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.label83);
            this.panel9.Controls.Add(this.label84);
            this.panel9.Location = new System.Drawing.Point(6, 429);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(240, 136);
            this.panel9.TabIndex = 275;
            // 
            // label82
            // 
            this.label82.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(52, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(120, 16);
            this.label82.TabIndex = 277;
            this.label82.Text = "Hồ sơ, phim, ảnh";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Location = new System.Drawing.Point(1, 16);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(328, 1);
            this.panel11.TabIndex = 280;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(64, 19);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(56, 16);
            this.label83.TabIndex = 278;
            this.label83.Text = "Loại";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.Location = new System.Drawing.Point(184, 17);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(56, 16);
            this.label84.TabIndex = 279;
            this.label84.Text = "Số tờ";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(295, 479);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(54, 16);
            this.label90.TabIndex = 294;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(239, 502);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(110, 16);
            this.label87.TabIndex = 282;
            this.label87.Text = "Bác sĩ điều trị :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(239, 459);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(110, 16);
            this.label86.TabIndex = 280;
            this.label86.Text = "Người nhận hồ sơ :";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(239, 434);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(110, 16);
            this.label85.TabIndex = 279;
            this.label85.Text = "Người giao hồ sơ :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label64.Location = new System.Drawing.Point(8, 191);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(128, 17);
            this.label64.TabIndex = 96;
            this.label64.Text = "3. Chẩn đoán ra viện :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(664, 24);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 103;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(24, 208);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(80, 16);
            this.label65.TabIndex = 100;
            this.label65.Text = "+ Bệnh chính :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // icd_kkb
            // 
            this.icd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Enabled = false;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(163, 205);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(59, 21);
            this.icd_kkb.TabIndex = 2;
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // cd_kkb
            // 
            this.cd_kkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Enabled = false;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(224, 205);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(560, 21);
            this.cd_kkb.TabIndex = 3;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(24, 228);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(152, 16);
            this.label66.TabIndex = 104;
            this.label66.Text = "+ Bệnh kèm theo (nếu có) :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cd_kemtheo
            // 
            this.cd_kemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Enabled = false;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(224, 229);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(536, 21);
            this.cd_kemtheo.TabIndex = 5;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(24, 251);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(80, 16);
            this.label67.TabIndex = 107;
            this.label67.Text = "+ Phân biệt :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phanbiet
            // 
            this.phanbiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phanbiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanbiet.Enabled = false;
            this.phanbiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanbiet.Location = new System.Drawing.Point(163, 251);
            this.phanbiet.Name = "phanbiet";
            this.phanbiet.Size = new System.Drawing.Size(621, 21);
            this.phanbiet.TabIndex = 6;
            this.phanbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phanbiet_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(0, 656);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(140, 656);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(70, 656);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(6, 688);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 300;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pic);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.mabn);
            this.groupBox2.Controls.Add(this.chandoan);
            this.groupBox2.Controls.Add(this.hoten);
            this.groupBox2.Controls.Add(this.sothe);
            this.groupBox2.Controls.Add(this.namsinh);
            this.groupBox2.Controls.Add(this.phai);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.diachi);
            this.groupBox2.Controls.Add(this.ngay);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(213, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 61);
            this.groupBox2.TabIndex = 302;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "I-Hành chính";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // butVantay
            // 
            this.butVantay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butVantay.Image = ((System.Drawing.Image)(resources.GetObject("butVantay.Image")));
            this.butVantay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butVantay.Name = "butVantay";
            this.butVantay.Size = new System.Drawing.Size(23, 22);
            this.butVantay.Text = "Vân tay";
            this.butVantay.ToolTipText = "Lấy dấu vân tay";
            this.butVantay.Click += new System.EventHandler(this.butVantay_Click);
            // 
            // ptb
            // 
            this.ptb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptb.BackColor = System.Drawing.SystemColors.Control;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptb.InitialImage")));
            this.ptb.Location = new System.Drawing.Point(224, 627);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(48, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 348;
            this.ptb.TabStop = false;
            // 
            // pgoi
            // 
            this.pgoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pgoi.Controls.Add(this.butgoilai);
            this.pgoi.Controls.Add(this.butgoibenh);
            this.pgoi.Controls.Add(this.label2);
            this.pgoi.Controls.Add(this.sonhay);
            this.pgoi.Controls.Add(this.den);
            this.pgoi.Controls.Add(this.tu);
            this.pgoi.Location = new System.Drawing.Point(780, 2);
            this.pgoi.Name = "pgoi";
            this.pgoi.Size = new System.Drawing.Size(227, 22);
            this.pgoi.TabIndex = 312;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 307;
            this.label2.Text = "Số :";
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
            // frmHSBenhan_NTTMH
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1014, 716);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p);
            this.Controls.Add(this.butChuyenphong);
            this.Controls.Add(this.ptb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHSBenhan_NTTMH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ bệnh án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHSBenhan_NTTMH_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHSBenhan_NTTMH_KeyDown);
            this.p.ResumeLayout(false);
            this.p.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).EndInit();
            this.panel9.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.pgoi.ResumeLayout(false);
            this.pgoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmHSBenhan_NTTMH_Load(object sender, System.EventArgs e)
		{
            i_maxlength_mabn = m.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            user = m.user;
			this.st1.Maximum=999999;this.st2.Maximum=999999;this.st3.Maximum=999999;
			this.st4.Maximum=999999;this.st5.Maximum=999999;this.st6.Maximum=999999;
            pathImage = m.pathImage; FileType = m.FileType;
			pic.Visible=m.bHinh || m.bChonhinh;
			//if (!bHinh)	this.list.Size = new System.Drawing.Size(208,498);
			dtdt=m.get_data("select * from "+user+".doituong").Tables[0];
            dt = m.get_data("select ten,id,loai,stt from " + user + ".ba_danhmuc order by ten").Tables[0];
			list1.DisplayMember="TEN";
			list1.ValueMember="TEN";
			list1.DataSource=dt;

			user=m.user;
            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;
            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;
			
			listNv1.DisplayMember="MA";
			listNv1.ValueMember="HOTEN";
            listNv1.DataSource = m.get_data("select  ma, hoten, nhom, viettat, makp, mapk, password_  from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];

            sql = "select * from " + user + ".dmbenhan_bv where maba=" + i_maba;
			dtba=m.get_data(sql).Tables[0];

			xem.SelectedIndex=0;
			list.DisplayMember="HOTEN";
			list.ValueMember="MAQL";
			load_list();
			list.ColumnWidths[0]=70;
			list.ColumnWidths[1]=150;
			list.ColumnWidths[2]=0;
			list.SetSensive(2,0,Color.Red);
			dscd.ReadXml("..\\..\\..\\xml\\m_bachidinh.xml");
			for(int i=0;i<chonin.Items.Count;i++) chonin.SetItemCheckState(i,CheckState.Checked);
		}	

		private void load_list()
		{
			Cursor=Cursors.WaitCursor;
			if (rb1.Checked)
			{
				xem.Enabled=false;
				butChon.Enabled=false;
                #region Bo
                //sql="select a.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,a.nhapkhoa,b.hoten,";
                //sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                //sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                //sql+="h.giuong,a.id,a.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                //sql+="d.sovaovien,to_char(sysdate,'dd/mm/yyyy hh24:mi') as ngayrv,h.tuoivao,h.chandoan";
                //sql+=",'' as chandoanrv,'' as maicdrv";
                //sql += " from " + user + ".btdbn b," + user + ".hiendien a," + user + ".benhandt d," + user + ".bhyt g," + user + ".nhapkhoa h ," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n";
                //sql+=" where a.id=h.id(+) and a.mabn=b.mabn and a.maql=g.maql(+) ";
                //sql+=" and a.maql=d.maql and d.loaiba=2 and a.xuatkhoa=0 ";
                //sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
                //sql+=" and a.makp='"+s_makp+"'";
                //sql+=" and (g.sudung is null or g.sudung=1)";
                //sql+=" order by a.ngay desc";
                #endregion
                sql ="select d.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.namsinh,b.phai,";
                sql += "trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,d.maql,d.mavaovien,g.sothe,";
                sql += "d.chandoan as chandoanvv,d.maicd,d.chandoan as chandoanvk,d.mabs,d.madoituong,d.sovaovien,to_char(d.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                sql += "d.chandoan,d.chandoanrv as chandoanrv,d.maicdrv as maicdrv,g.traituyen, lh.tuoivao ";//to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao ";
                sql += ",'' as giuong ";
                sql += "from " + user + ".btdbn b," + user + ".benhanngtr d," + user + ".bhyt g," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n ";
                sql += ", "+user+".lienhe lh ";
                sql += "where b.mabn=d.mabn and d.maql=g.maql(+) and d.ngayrv is null  ";
                sql += "and b.matt=j.matt and b.maqu=m.maqu(+) and b.maphuongxa=n.maphuongxa(+)  and d.makp='"+s_makp+"' and (g.sudung is null or g.sudung=1) ";
                sql += " and d.maql=lh.maql ";
                sql += "order by d.ngay desc ";
			}
			else
			{
                sql = "select d.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.namsinh,b.phai,";
                sql += "trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,d.maql,d.mavaovien,g.sothe,";
                sql += "d.chandoan as chandoanvv,d.maicd,d.chandoan as chandoanvk,d.mabs,d.madoituong,d.sovaovien,to_char(d.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                sql += "d.chandoan,d.chandoanrv as chandoanrv,d.maicdrv as maicdrv,g.traituyen,lh.tuoivao ";//to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao ";
                sql += ",'' as giuong ";
                sql += "from " + user + ".btdbn b," + user + ".benhanngtr d," + user + ".bhyt g," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n ";
                sql += ", " + user + ".lienhe lh ";
                sql += "where b.mabn=d.mabn and d.maql=g.maql(+) and d.ngayrv is not null  ";
                sql += "and b.matt=j.matt and b.maqu=m.maqu(+) and b.maphuongxa=n.maphuongxa(+)  and d.makp='" + s_makp + "' and (g.sudung is null or g.sudung=1) ";
                sql += " and d.maql=lh.maql ";
                sql += "order by d.ngay desc ";
                #region Bo
                //xem.Enabled=butChon.Enabled=butKhoa.Enabled=butIn.Enabled=true;
                //butChidinh.Enabled=butChamsoc.Enabled=butDieutri.Enabled=true;
                //sql="select h.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,1 as nhapkhoa,b.hoten,";
                //sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                //sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                //sql+="h.giuong,a.id,h.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                //sql+="d.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,h.tuoivao,h.chandoan";
                //sql+=",a.chandoan as chandoanrv,a.maicd as maicdrv";
                //sql += " from " + user + ".xuatkhoa a," + user + ".btdbn b," + user + ".benhandt d," + user + ".bhyt g," + user + ".nhapkhoa h ," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n";
                //sql+=" where a.id=h.id and h.mabn=b.mabn and h.maql=g.maql(+) ";
                //sql+=" and h.maql=d.maql and d.loaiba=2 ";
                //sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
                //sql+=" and h.makp='"+s_makp+"'";
                //sql+=" and (g.sudung is null or g.sudung=1)";
                //sql+=" order by a.ngay desc";
                #endregion
            }
			ds=m.get_data(sql);
			list.DataSource=ds.Tables[0];
			Cursor=Cursors.Default;
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);//236
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);//419
            }
		}

		private void bKethuc_Click(object sender, System.EventArgs e)
		{
			m.close();//v.close();
			System.GC.Collect();
			this.Close();
		}

		private void tenba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void manguoigiao_Validated(object sender, System.EventArgs e)
		{
			if (manguoigiao.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+manguoigiao.Text+"'");
			if (r!=null) nguoigiao.Text=r["hoten"].ToString();
			else nguoigiao.Text="";
		}

		private void nguoigiao_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nguoigiao)
			{
				Filt_dmbs(nguoigiao.Text);
				listNv.BrowseToDanhmuc(nguoigiao,manguoigiao,manguoinhan,35);
			}
		}

		private void nguoigiao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void nguoinhan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nguoinhan)
			{
				Filt_dmbs(nguoinhan.Text);
				listNv.BrowseToDanhmuc(nguoinhan,manguoinhan,ngayrv,35);
			}
		}

		private void manguoinhan_Validated(object sender, System.EventArgs e)
		{
			if (manguoinhan.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+manguoinhan.Text+"'");
			if (r!=null) nguoinhan.Text=r["hoten"].ToString();
			else nguoinhan.Text="";
		}

		private void Filt_dmbs1(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
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
				listNv.BrowseToDanhmuc(tenbs,mabs,tenbs_pass,tenbs.Location.X,tenbs.Location.Y-98,35);
			}		
		}

		private void icd_kkb_Validated(object sender, System.EventArgs e)
		{
			if (icd_kkb.Text!="")
			{
				cd_kkb.Text=m.get_vviet(icd_kkb.Text);
				if (cd_kkb.Text=="" && icd_kkb.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kkb.Text, cd_kkb.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_kkb.Text=f.mTen;
						icd_kkb.Text=f.mICD;
						chandoanrv.Text=cd_kkb.Text;
						icdrv.Text=icd_kkb.Text;
					}
				}
			}
		}

		private void icd_kemtheo_Validated(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text!="")
			{
				cd_kemtheo.Text=m.get_vviet(icd_kemtheo.Text);
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
				Filt_ICD(cd_kkb.Text);
				listICD.BrowseToICD10(cd_kkb,icd_kkb,icd_kemtheo,icd_kkb.Location.X,icd_kkb.Location.Y+icd_kkb.Height,icd_kkb.Width+cd_kkb.Width+2,icd_kkb.Height);
			}
		}

		private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kemtheo)
			{
				Filt_ICD(cd_kemtheo.Text);
				listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,phanbiet,icd_kemtheo.Location.X,icd_kemtheo.Location.Y+icd_kemtheo.Height,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
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

		private void emp_text()
		{
            s_sovaovien = ""; i_madoituong = 0; l_id = 0; l_idkhoa = 0; l_maql = 0;l_mavaovien=0 ; l_idthuchien = 0; dscd.Clear();
			mabn.Text="";hoten.Text="";namsinh.Text="";diachi.Text="";ngay.Text="";sothe.Text="";chandoan.Text="";maicd.Text="";
			lydo.Text="";hb_benhly.Text="";hb_giadinh.Text="";hb_banthan.Text="";kb_toanthan.Text="";
			kb_tuanhoan.Text="";kb_khac.Text="";kb_tomtat.Text="";
			mach.Text="";nhietdo.Text="";huyetap.Text="";nhiptho.Text="";cannang.Text="";chieucao.Text="";bmi.Text="";
			icd_kkb.Text="";cd_kkb.Text="";icd_kemtheo.Text="";cd_kemtheo.Text="";phanbiet.Text="";
			dieutri.Text="";ngayvk.Text="";giovk.Text="";mabsnb.Text="";tenbsnb.Text="";
			tk_benhly.Text="";tk_tomtat.Text="";tk_phuongphap.Text="";tk_tinhtrang.Text="";tk_dieutri.Text="";
			manguoigiao.Text="";nguoigiao.Text="";manguoinhan.Text="";nguoinhan.Text="";mabs.Text="";tenbs.Text="";
			st1.Value=0;st2.Value=0;st3.Value=0;st4.Value=0;st5.Value=0;st6.Value=0;khac.Text="";
			tenbs_pass.Text="";tenbsnb_pass.Text="";tungay.Text="";denngay.Text="";
			ena_object(true);
		}

		private void get_mabn(string _mabn,long id)
		{
			emp_text();			
			sql="mabn='"+_mabn+"'";
			if (id!=0) sql+=" and maql="+id;
			DataRow r=m.getrowbyid(ds.Tables[0],sql);
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi.Text=r["diachi"].ToString();
				sothe.Text=r["sothe"].ToString();
                i_traituyen = (r["traituyen"].ToString() != "") ? int.Parse(r["traituyen"].ToString()) : 0;
				ngay.Text=r["ngayvv"].ToString();
				chandoan.Text=r["chandoanvv"].ToString();
				maicd.Text=r["maicd"].ToString();
				ngayvk.Text=r["ngayvk"].ToString().Substring(0,10);
				giovk.Text=r["ngayvk"].ToString().Substring(11);
				tungay.Text=ngayvk.Text+" "+giovk.Text;
				mabsnb.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
				if (r1!=null) 
				{
					tenbsnb.Text=r1["hoten"].ToString();
					tenbsnb_pass.Text=r1["password_"].ToString();
				}
				else tenbsnb.Text="";
				l_idkhoa=long.Parse(r["maql"].ToString());
				l_maql=long.Parse(r["maql"].ToString());
                l_mavaovien = long.Parse(r["mavaovien"].ToString());
				i_madoituong=int.Parse(r["madoituong"].ToString());
				s_sovaovien=r["sovaovien"].ToString();
				if (rb2.Checked)
				{
					ngayrv.Text=r["ngayrv"].ToString().Substring(0,10);
					giorv.Text=r["ngayrv"].ToString().Substring(11);
					icd_kkb.Text=r["maicdrv"].ToString();
					cd_kkb.Text=r["chandoanrv"].ToString();
					chandoanrv.Text=r["chandoanrv"].ToString();
					icdrv.Text=r["maicdrv"].ToString();
					denngay.Text=ngayrv.Text+" "+giorv.Text;
				}
				mabs.Text=r["mabs"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null)
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				load_data();
				ena_object(false);
				if (pic.Visible)
				{
					foreach(DataRow r2 in m.get_data("select * from "+user+".btdbn where mabn='"+_mabn+"'").Tables[0].Rows)
					{
                        //try
                        //{
                        //    image = new byte[0];
                        //    image = (byte[])(r2["image"]);
                        //    memo = new MemoryStream(image);
                        //    map = new Bitmap(Image.FromStream(memo));
                        //    pic.Image = (Bitmap)map;
                        //    pic.Tag = image;
                        //}
                        //catch
                        //{
                        //    pic.Tag = "0000.bmp";
                        //    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //    map = new Bitmap(Image.FromStream(fstr));
                        //    pic.Image = (Bitmap)map;
                        //    image = new byte[fstr.Length];
                        //    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        //    fstr.Close();
                        //    pic.Tag = image;
                        //}

                        if (pic.Visible)
                        {
                            bool error = false;
                            try
                            {
                                if (pathImage != "")
                                {
                                    error = true;
                                    //string paa = pathImage.Trim('\\').Replace("\\", "//") + "//" + s_mabn;
                                    pic.Tag = (System.IO.File.Exists(pathImage.Trim('\\').Replace("\\", "//") + "//" + mabn.Text + "." + FileType)) ? pathImage + "//" + mabn.Text + "." + FileType : "0000.bmp";
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
					}
				}
			}
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
		}

		private void load_data()
		{
			Cursor=Cursors.WaitCursor;
			bool bFound=false;xxx=user+m.mmyy(ngay.Text);
			l_idthuchien=m.get_idthuchien(ngay.Text,l_maql,s_makp,l_maql);
			DataRow r1;
			if (l_idthuchien!=0)
			{
				l_id=m.get_idchung(ngay.Text,l_idthuchien);
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_chung where id="+l_id).Tables[0].Rows)
				{
					lydo.Text=r["lydo"].ToString();
					hb_benhly.Text=r["hb_benhly"].ToString();
					hb_banthan.Text=r["hb_banthan"].ToString();
					hb_giadinh.Text=r["hb_giadinh"].ToString();
					kb_toanthan.Text=r["kb_toanthan"].ToString();
					kb_tuanhoan.Text=r["kb_tuanhoan"].ToString();
					kb_khac.Text=r["kb_khac"].ToString();
					kb_tomtat.Text=r["kb_tomtat"].ToString();
					phanbiet.Text=r["phanbiet"].ToString();
					dieutri.Text=r["dieutri"].ToString();
					tk_benhly.Text=r["tk_benhly"].ToString();
					tk_tomtat.Text=r["tk_tomtat"].ToString();
					tk_phuongphap.Text=r["tk_phuongphap"].ToString();
					tk_tinhtrang.Text=r["tk_tinhtrang"].ToString();
					tk_dieutri.Text=r["tk_dieutri"].ToString();
					manguoigiao.Text=r["nguoigiao"].ToString();
					manguoinhan.Text=r["nguoinhan"].ToString();
					mabs.Text=r["mabs"].ToString();
					r1=m.getrowbyid(dtnv,"ma='"+manguoigiao.Text+"'");
					if (r1!=null) nguoigiao.Text=r1["hoten"].ToString();
					r1=m.getrowbyid(dtnv,"ma='"+manguoinhan.Text+"'");
					if (r1!=null) nguoinhan.Text=r1["hoten"].ToString();
					r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					break;
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_kbdausinhton where id="+l_id).Tables[0].Rows)
				{
					mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
					chieucao.Text=(r["chieucao"].ToString()!="0")?r["chieucao"].ToString():"";
					tinh_bmi();
					break;
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_tkhoso where id="+l_id).Tables[0].Rows)
				{
					switch (int.Parse(r["ma"].ToString()))
					{
						case 1:st1.Value=decimal.Parse(r["so"].ToString());break;
						case 2:st2.Value=decimal.Parse(r["so"].ToString());break;
						case 3:st3.Value=decimal.Parse(r["so"].ToString());break;
						case 4:st4.Value=decimal.Parse(r["so"].ToString());break;
						case 5:st5.Value=decimal.Parse(r["so"].ToString());khac.Text=r["khac"].ToString();break;
						case 6:st6.Value=decimal.Parse(r["so"].ToString());break;
					}
				}
			}
			else
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_chung where maql="+l_maql).Tables[0].Rows)
				{
					lydo.Text=r["lydo"].ToString();
					hb_benhly.Text=r["hb_benhly"].ToString();
					hb_banthan.Text=r["hb_banthan"].ToString();
					hb_giadinh.Text=r["hb_giadinh"].ToString();
					kb_toanthan.Text=r["kb_toanthan"].ToString();
                    kb_tuanhoan.Text = r["kb_bophan"].ToString();
                    kb_tomtat.Text = r["kb_tomtat"].ToString();
                    kb_khac.Text = r["sobo"].ToString();
                    dieutri.Text = r["kb_xuli"].ToString();
					bFound=true;
					break;
				}
				if (bFound)
				{
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
				}
			}
			if (mabs.Text=="" && s_mabs!="")
			{
				mabs.Text=s_mabs;
				r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null)
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else tenbs.Text="";
			}
			foreach(DataRow r in m.get_data("select * from "+user+".cdkemtheo where loai=2 and id="+l_idkhoa+" order by stt").Tables[0].Rows)
			{
				cd_kemtheo.Text=r["chandoan"].ToString();
				icd_kemtheo.Text=r["maicd"].ToString();
				break;
			}
			load_chidinh();
			Cursor=Cursors.Default;
		}

		private void load_chidinh()
		{
			string tu=ngay.Text.Substring(0,10),den=(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10);
			sql="select nvl(e.stt,0) as stt,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,d.hoten as tenbs,b.ten,' ' as ketqua ";
            sql += ",id_loai ";
            sql+=" from xxx.v_chidinh a,"+user+".v_giavp b,"+user+".btdkp_bv c,"+user+".dmbs d,"+user+".dmchidinh e ";
			sql+=" where a.mavp=b.id and a.makp=c.makp(+) and a.mabs=d.ma(+) and b.id_loai=e.idloaivp(+) and a.mabn='"+mabn.Text+"'";
			sql+=" and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+tu+"','dd/mm/yyyy') and to_date('"+den+"','dd/mm/yyyy')";
            if (i_chinhanh != 0) sql += " and (khu=0 or khu="+i_chinhanh+") ";
            sql+=" order by a.ngay,b.stt";
			dscd=m.get_data_mmyy(sql,tu,den,false);
            //st1.Value=dscd.Tables[0].Select("stt=2").Length;
            //st2.Value=dscd.Tables[0].Select("stt=3").Length;
            //st3.Value=dscd.Tables[0].Select("stt=5").Length;
            //st4.Value=dscd.Tables[0].Select("stt>=10 and stt<=20").Length;
            //st6.Value=dscd.Tables[0].Rows.Count;

            //Tu:26/05/2011
            st1.Value = dscd.Tables[0].Select("id_loai=75 or id_loai=76").Length;
            st2.Value = dscd.Tables[0].Select("id_loai=8").Length;
            st3.Value = dscd.Tables[0].Select("id_loai=65").Length;
            st4.Value = dscd.Tables[0].Select("id_loai=77 or id_loai=78 or id_loai=79 or id_loai=80 or id_loai=81 or id_loai=82").Length;
            st6.Value = dscd.Tables[0].Rows.Count;
            //end
			//st5.Value=st6.Value-st1.Value-st2.Value-st3.Value-st4.Value;
			DataTable tmp=m.get_data("select b.stt from "+user+m.mmyy(ngay.Text)+".ba_scan a,"+user+".ba_loaiphieu b where a.loai=b.id and a.id="+l_id).Tables[0];
			st1.Value+=tmp.Select("stt=2").Length;
			st2.Value+=tmp.Select("stt=3").Length;
			st3.Value+=tmp.Select("stt=5").Length;
			st4.Value+=tmp.Select("stt>=10 and stt<=20").Length;
			st6.Value+=tmp.Rows.Count;
			st5.Value=st6.Value-st1.Value-st2.Value-st3.Value-st4.Value;
		}

		private bool kiemtra()
		{
			/*
			if (icd_kkb.Text=="" || cd_kkb.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán ra viện chưa hợp lệ !",LibMedi.AccessData.Msg);
				icd_kkb.Focus();
				return false;
			}
			*/
			if (mabsnb.Text=="" || tenbsnb.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ khám bệnh chưa hợp lệ !"),LibMedi.AccessData.Msg);
				mabsnb.Focus();
				return false;
			}
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ khám bệnh chưa hợp lệ !"),LibMedi.AccessData.Msg);
				mabsnb.Focus();
				return false;
			}
            //if (!bAdmin)
            //{
            //    if (tenbsnb_pass.Text!=r["password_"].ToString())
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Mật khẩu bác sĩ khám bệnh chưa hợp lệ !",LibMedi.AccessData.Msg);
            //        tenbsnb_pass.Focus();
            //        return false;
            //    }
            //}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
                //if (!bAdmin)
                //{
                //    if (tenbs_pass.Text!=r["password_"].ToString())
                //    {
                //        MessageBox.Show(lan.Change_language_MessageText("Mật khẩu bác sĩ điều trị chưa hợp lệ !",LibMedi.AccessData.Msg);
                //        tenbs_pass.Focus();
                //        return false;
                //    }
                //}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			xxx=user+m.mmyy(ngay.Text);
			bool bNhapkhoa=m.getrowbyid(ds.Tables[0],"nhapkhoa=0 and mabn='"+mabn.Text+"'")!=null;
			if (bNhapkhoa)
			{
				string s_tenkp=m.bHiendien(l_maql);
				if (s_tenkp!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {")+s_tenkp.Trim().ToUpper()+lan.Change_language_MessageText("}"+"\nKhông thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"),LibMedi.AccessData.Msg);
					butBoqua_Click(null,null);
					return;
				}
				upd_nhapkhoa();
			}
			m.execute_data("update "+user+".benhandt set mabs='"+mabsnb.Text+"' where maql="+l_maql);
			DataRow r1=m.getrowbyid(ds.Tables[0],"maql="+l_maql);
			if (r1!=null) r1["mabs"]=mabsnb.Text;
			l_idthuchien=m.get_idthuchien_maql(ngay.Text,l_maql);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.getidyymmddhhmiss_stt_computer;//get_capid(-300);
				m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,"","",chandoan.Text);
			}
			l_id=m.get_idchung(ngay.Text,l_idthuchien);
			if (l_id==0) l_id=m.getidyymmddhhmiss_stt_computer;//get_capid(-301);
            if (!m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, 1, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
				"","","","","","","","","",kb_khac.Text,kb_tomtat.Text,phanbiet.Text,
				"",dieutri.Text,mabsnb.Text,tk_benhly.Text,tk_tomtat.Text,tk_phuongphap.Text,tk_tinhtrang.Text,tk_dieutri.Text,manguoigiao.Text,manguoinhan.Text,mabs.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),LibMedi.AccessData.Msg);
				return;
			}
            m.upd_ba_kbdausinhton(ngay.Text, mabn.Text, l_id, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "" && nhietdo.Text.Trim() != ".") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0);
            //Tu:21/05/2011 insert vao bang theodoitsu
            try
            {
                DataRow dr = m.getrowbyid(dticd, "cicd10='" + icd_kkb.Text.Trim() + "' and tiensubenh=1");
                if (dr != null)
                {
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + mabn.Text.Trim() + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(mabn.Text, cd_kkb.Text, ngay.Text.Substring(0, 10), icd_kkb.Text, i_stt);

                    long i_stt_tsu = 0;
                    try { i_stt_tsu = long.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(icd_kkb.Text, i_stt_tsu, cd_kkb.Text);
                }

                DataRow dr0 = m.getrowbyid(dticd, "cicd10='" + icd_kemtheo.Text.Trim() + "' and tiensubenh=1");
                if (dr0 != null)
                {
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + mabn.Text.Trim() + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(mabn.Text, cd_kemtheo.Text, ngay.Text.Substring(0, 10), icd_kemtheo.Text, i_stt);

                    long i_stt_tsu = 0;
                    try { i_stt_tsu = long.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(icd_kemtheo.Text, i_stt_tsu, cd_kemtheo.Text);
                }

                DataRow dr1 = m.getrowbyid(dticd, "cicd10='" + icd_kkb.Text.Trim() + "' and benhmantinh=1");
                if (dr1 != null)
                    m.upd_benhmantinh(mabn.Text, cd_kkb.Text, icd_kkb.Text, "", i_userid, ngay.Text.Substring(0, 10));
                DataRow dr2 = m.getrowbyid(dticd, "cicd10='" + icd_kemtheo.Text.Trim() + "' and benhmantinh=1");
                if (dr2 != null)
                    m.upd_benhmantinh(mabn.Text, cd_kemtheo.Text, icd_kemtheo.Text, "", i_userid, ngay.Text.Substring(0, 10));
            }
            catch { }
            //end Tu
            if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_idkhoa,l_maql,2,cd_kemtheo.Text,icd_kemtheo.Text,1);
			m.execute_data("delete from "+xxx+".ba_tkhoso where id="+l_id);
            if (st1.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 1, "", st1.Value);
            if (st2.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 2, "", st2.Value);
            if (st3.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 3, "", st3.Value);
            if (st4.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 4, "", st4.Value);
            if (st5.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 5, khac.Text, st5.Value);
            if (st6.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 6, "", st6.Value);
			ena_object(true);
			if (bNhapkhoa) load_list();
		}

		private void upd_nhapkhoa()
		{
			bool bNew=true;
			if (bNew) l_idkhoa=m.get_id(l_maql,s_makp,ngayvk.Text+" "+giovk.Text);
			int i_maba=11;
			itable = m.tableid("","nhapkhoa");
			if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
			else
			{
				m.upd_eve_tables(itable, i_userid, "upd");
				m.upd_eve_upd_del(itable, i_userid, "upd",m.fields(user+".nhapkhoa","id="+l_idkhoa));
			}
			string stuoi=m.get_tuoivao(l_maql),khoachuyen="01",ngaychuyen=ngayvk.Text+" "+giovk.Text;
			foreach(DataRow r in m.get_data("select makp,ngaychuyen from "+user+".chuyenkhoa where khoaden='"+s_makp+"'"+" and maql="+l_maql+" order by ngaychuyen desc").Tables[0].Rows)
			{
				ngaychuyen=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaychuyen"].ToString()));
				khoachuyen=r["makp"].ToString();
				break;
			}
			if (!m.upd_nhapkhoa(l_idkhoa,mabn.Text,l_maql,s_makp,i_maba,ngaychuyen,stuoi,"",khoachuyen,chandoan.Text,maicd.Text,mabsnb.Text,1,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào khoa !"),LibMedi.AccessData.Msg);
				return;
			}
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			load_list();
		}

		private void ena_object(bool ena)
		{
			if (rb1.Checked || bAdmin)
			{
				lydo.Enabled=!ena;hb_benhly.Enabled=!ena;hb_giadinh.Enabled=!ena;hb_banthan.Enabled=!ena;kb_toanthan.Enabled=!ena;
				kb_tuanhoan.Enabled=!ena;kb_khac.Enabled=!ena;kb_tomtat.Enabled=!ena;
				mach.Enabled=!ena;nhietdo.Enabled=!ena;huyetap.Enabled=!ena;nhiptho.Enabled=!ena;cannang.Enabled=!ena;chieucao.Enabled=!ena;
				icd_kemtheo.Enabled=!ena;cd_kemtheo.Enabled=!ena;phanbiet.Enabled=!ena;
				dieutri.Enabled=!ena;tk_benhly.Enabled=!ena;tk_tomtat.Enabled=!ena;tk_phuongphap.Enabled=!ena;tk_tinhtrang.Enabled=!ena;tk_dieutri.Enabled=!ena;
				//ngayrv.Enabled=!ena;giorv.Enabled=!ena;
				manguoigiao.Enabled=!ena;nguoigiao.Enabled=!ena;manguoinhan.Enabled=!ena;nguoinhan.Enabled=!ena;
				//mabs.Enabled=!ena;tenbs.Enabled=!ena;tenbs_pass.Enabled=!ena;
				tenbsnb_pass.Enabled=!ena;ngayvk.Enabled=!ena;giovk.Enabled=!ena;
				//icd_kkb.Enabled=!ena;cd_kkb.Enabled=!ena;
				mabsnb.Enabled=!ena;tenbsnb.Enabled=!ena;
				mabn.Enabled=ena;list.Enabled=ena;butChuyenphong.Enabled=!ena;
				if (i_loai==0 || i_loai==2) butChamsoc.Enabled=!ena;
				butKhoa.Enabled=!ena;xem.Enabled=!ena;butDausinhton.Enabled=!ena;butChidinh.Enabled=!ena;
				if (i_loai==0 || i_loai==1) butDieutri.Enabled=!ena;
				butAn.Enabled=!ena;butMau.Enabled=!ena;butLoc.Enabled=!ena;butDich.Enabled=!ena;butDausinhton.Enabled=!ena;butPhanung.Enabled=!ena;
				butKemtheo.Enabled=!ena;butChon.Enabled=!ena;butPttt.Enabled=!ena;butKethuc.Enabled=ena;
				butLuu.Enabled=!ena;butBoqua.Enabled=!ena;butIn.Enabled=ena;tim.Enabled=ena;
                butVao.Enabled = ena; butRa.Enabled = !ena; butphanungthuocohai.Enabled = !ena;
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);

            if (list.Items.Count > 0)
            {
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);//236
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);//419
            }
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				DataRow r=m.getrowbyid(ds.Tables[0],"id="+long.Parse(list.SelectedValue.ToString()));
				if (r!=null) get_mabn(r["mabn"].ToString(),long.Parse(r["id"].ToString()));
			}
            if (e.KeyCode == Keys.Escape)
            {
                this.groupBox1.Location = new Point(0, 30);
                this.groupBox1.Size = new Size(206, 256);
            }
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"maql="+long.Parse(list.SelectedValue.ToString()));
			if (r!=null) get_mabn(r["mabn"].ToString(),long.Parse(r["maql"].ToString()));
            //Lấy dấu sinh tồn
            if (m.bDausinhton_khambenh)
            {
                if (m.get_data("select mabn from " + user + m.mmyy(ngay.Text.Substring(0, 10)) + ".d_dausinhton where mabn='" + mabn.Text.Trim() + "'").Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("Đề nghị lấy dấu sinh tồn của bệnh nhân! ", LibMedi.AccessData.Msg);
                    butDausinhton_Click(sender, e);
                }
            }
            //end
            this.groupBox1.Location = new Point(0, 30);
            this.groupBox1.Size = new Size(206, 256);
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=i_maxlength_mabn) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(i_maxlength_mabn-2,'0');
			get_mabn(mabn.Text,0);
		}		

		private void butKhoa_Click(object sender, System.EventArgs e)
		{
			sql="select a.mabn,a.hoten,a.phai,a.namsinh,a.cholam,a.sonha,a.thon,a.mann,a.matt,a.maqu,a.maphuongxa,";
			sql+="b.dentu,b.nhantu,b.madoituong,f.tuoivao as tuoi,c.sothe,to_char(c.denngay,'dd/mm/yyyy') as denngay,";
			sql+="g.mabv as madstt,g.tenbv as tendstt,d.maicd as icdnoichuyen,d.chandoan as cdnoichuyen,";
			sql+="c.mabv as noicap,b.chandoan,b.maicd,b.mabs,i.hoten as tenbs,b.soluutru,b.maql as mangtr ";
			//sql+=" from btdbn a,benhandt b,bhyt c,noigioithieu d,xuatvien e,lienhe f,dstt g,dmnoicapbhyt h,dmbs i ";
            sql += " from " + user + ".btdbn a," + user + ".benhanngtr b," + xxx + ".bhyt c," + user + ".noigioithieu d," + user + ".lienhe f," + user + ".dstt g," + user + ".dmnoicapbhyt h," + user + ".dmbs i ";//,xuatvien e
			sql+=" where a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql(+) and b.maql=f.maql ";
            sql += " and d.mabv=g.mabv(+) and c.mabv=h.mabv(+) and b.mabs=i.ma(+) ";//and b.maql=e.maql(+) 
			sql+=" and a.mabn='"+mabn.Text+"' and b.maql="+l_maql;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				frmKhambenh_nt f2=new frmKhambenh_nt(m,s_makp,s_userid,i_userid,i_mabv,b_sovaovien,b_soluutru,mabn.Text,hoten.Text,int.Parse(r["phai"].ToString()),r["namsinh"].ToString(),r["mann"].ToString(),ngay.Text,r["sonha"].ToString(),r["thon"].ToString(),r["cholam"].ToString(),r["matt"].ToString(),r["maqu"].ToString().Substring(0,3),r["maqu"].ToString().Substring(3),r["maphuongxa"].ToString().Substring(0,5),r["maphuongxa"].ToString().Substring(5),r["tuoi"].ToString().Substring(0,3),int.Parse(r["tuoi"].ToString().Substring(3)),
					long.Parse(r["mangtr"].ToString()),l_id,s_makp,ngay.Text,s_makp+",",int.Parse(r["dentu"].ToString()),
					int.Parse(r["nhantu"].ToString()),int.Parse(r["madoituong"].ToString()),r["sothe"].ToString(),
					r["denngay"].ToString(),r["madstt"].ToString(),r["tendstt"].ToString(),r["icdnoichuyen"].ToString(),
					r["cdnoichuyen"].ToString(),r["noicap"].ToString(),r["chandoan"].ToString(),r["maicd"].ToString(),
					r["mabs"].ToString(),r["tenbs"].ToString(),r["soluutru"].ToString(),r["sonha"].ToString().Trim()+" "+r["thon"].ToString(),0,i_chinhanh);
				f2.ShowDialog(this);
				if (f2.bravien)	butRa_Click(sender,e);
				break;
			}
		}

		private void butChidinh_Click(object sender, System.EventArgs e)
		{
            if (kb_khac.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán !"), LibMedi.AccessData.Msg);
                return;
            }
			string stuoi=m.get_tuoivao(l_maql).Trim();
            dllvpkhoa_chidinh.frmChonthongsovp ff = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp, i_userid);
			ff.ShowDialog(this);
			if (ff.s_makp!="")
			{
                dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, mabn.Text, hoten.Text, stuoi, ngayvk.Text + " " + giovk.Text, s_makp, s_tenkp, i_madoituong, 1, l_mavaovien, l_maql, 0, i_userid, "medibv.benhanngtr", sothe.Text, "",2 ,(s_mabs != "") ? s_mabs : mabsnb.Text, cd_kkb.Text, "",i_traituyen,true,i_chinhanh);//bAdmin, l_maql, 3, 0, ff.s_ngay,false);
				f.ShowDialog(this);
				load_chidinh();
			}
		}

		private void ngayrv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayrv.Text!="")
				{
					ngayrv.Text=ngayrv.Text.Trim();
					if (ngayrv.Text.Length==6) ngayrv.Text=ngayrv.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayrv.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
						ngayrv.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giorv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giorv.Text!="")
				{
					string sgio=(giorv.Text.Trim()=="")?"00:00":giorv.Text.Trim();
					giorv.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giorv.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
						giorv.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void phanbiet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)	SendKeys.Send("{Tab}{Home}");
		}

		private void Filter(string ten,int loai)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%' and loai="+loai;
			}
			catch{}
		}

		private void butKemtheo_Click(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="" || cd_kemtheo.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_idkhoa,l_maql,2,cd_kemtheo.Text,icd_kemtheo.Text,1);
			frmCdkemtheo f=new frmCdkemtheo(m,l_idkhoa,l_maql,2,"");
			f.ShowDialog();
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) list.Focus();
            if (e.KeyCode == Keys.Escape)
            {
                this.groupBox1.Location = new Point(0, 30);
                this.groupBox1.Size = new Size(206, 256);
            }
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (mabn.Text=="") return;
			if (chonin.CheckedItems.Count==0) 
				for(int i=0;i<chonin.Items.Count;i++) chonin.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<chonin.Items.Count;i++)
				if (chonin.GetItemChecked(i)) page(i);
		}
		#region Page
		private void page(int loai)
		{
			DataSet dsxml=new DataSet();
			if (chkXML.Checked)
				if (!Directory.Exists("..\\xml")) Directory.CreateDirectory("..\\xml");
			if (chonin.GetItemChecked(1) || chonin.GetItemChecked(2) || chonin.GetItemChecked(3)) 
			{
				dsxml=get_data();
				if (chkXML.Checked) dsxml.WriteXml("..\\xml\\page2.xml",XmlWriteMode.WriteSchema);
			}
			switch (loai)
			{
				case 0: page_1();break;
				case 1: page_2(dsxml);break;
			}
		}
		private void page_1()
		{
			string tenfile="BenhAnNgoaiKhoa",m_manuoc="",m_tennuoc="",stuoi=m.get_tuoivao(l_maql).Trim(),m_songaydt="",m_cd_noichuyenden="",m_icd_noichuyenden="",m_tdvh="",m_ngaybong="";
			string m_songaydieutrivaokhoa="",m_chuyenkhoa1="",m_ngaychuyenkhoa1="",m_songaydieutrichuyenkhoa1="",m_chuyenkhoa2="",m_ngaychuyenkhoa2="",m_songaydieutrichuyenkhoa2="";
			string m_chuyenkhoa3="",m_ngaychuyenkhoa3="",m_songaydieutrichuyenkhoa3="",m_ngaytuvong="",m_tinhtrangtuvong="",m_thoidiemtuvong="",m_nguyennhantuvong="",m_icdnguyennhantuvong="";
			string m_cokhamnghiemtuthi="",m_chandoantuthi="",m_icdchandoantuthi="",m_nguyennhantaibienbienchung="",m_tongsongaydieutrisauphauthuat="",m_tongsolanphauthuat="",m_chandoantruocphauthuat="";
			string m_icdchandoantruocphauthuat="",m_chandoansauphauthuat="",m_icdchandoansauphauthuat="",m_tinhtrangphauthuat="";
			sql="select a.mabn,a.makp,a.soluutru,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
			sql+="to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh,c.phai,c.sonha,c.thon,c.matt,c.maqu,c.maphuongxa,c.mann,d.tennn,c.madantoc,e.dantoc as tendantoc,";
			sql+="f.tentt,g.tenquan,h.tenpxa,c.cholam,a.madoituong,i.sothe,to_char(i.denngay,'dd/mm/yyyy') as denngay,";
            sql += "j.hoten as qh_hoten,j.dienthoai as qh_dienthoai,a.nhantu,a.dentu,";//,a.lanthu
			sql+="nvl(m.loaibv,0) as loaibv,n.tenbv,nvl(a.ttlucrv,0) as ttlucrv,a.chandoan as chandoanvv,a.maicd as maicdvv,";
			sql+="a.chandoanrv as chandoanrv,a.maicdrv as maicdrv,a.taibien,a.bienchung,a.giaiphau,nvl(a.ketqua,0) as ketqua,";
			sql+="nvl(s.ten,a.giaiphau) as giaiphau,t.chandoan as chandoannn,t.maicd as maicdnn";
            sql += " from " + user + ".benhanngtr a," + user + ".btdbn c," + user + ".btdnn_bv d," + user + ".btddt e," + user + ".btdtt f," + user + ".btdquan g," + user + ".btdpxa h," + user + ".bhyt i,";
            sql += " " + user + ".quanhe j," + user + ".chuyenvien m," + user + ".tenvien n," + user + ".gphaubenh s," + user + ".cdnguyennhan t";
            sql += " where a.mabn=c.mabn and c.mann=d.mann and c.madantoc=e.madantoc ";//a.maql=b.maql(+) and 
			sql+=" and c.matt=f.matt and c.maqu=g.maqu and c.maphuongxa=h.maphuongxa ";
			sql+=" and a.maql=i.maql(+) and a.maql=j.maql(+) and a.maql=m.maql(+) and m.mabv=n.mabv(+) ";
			sql+=" and a.giaiphau=s.ma(+) and a.maql=t.maql(+)";
            sql += " and a.maql=" + l_maql;//and a.loaiba=2
			DataSet ds1=m.get_data(sql);
			tenfile="rPage98";
			bool bFile=false;
			if (ds1.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (chkXML.Checked) ds1.WriteXml("..\\xml\\page1.xml",XmlWriteMode.WriteSchema);
				DataColumn dc = new DataColumn("Image", typeof(byte[]));
                DataColumn dc1 = new DataColumn("Image1", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
                ds1.Tables[0].Columns.Add(dc1);
				foreach(DataRow r in ds1.Tables[0].Rows)
				{
					//DataRow r2=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
                    DataTable dthinh = m.get_data("select * from " + xxx + ".bavv_tmh where maql=" + l_maql + " ").Tables[0];
                    DataRow r2 = m.getrowbyid(dthinh, "maql=" + l_maql + "");
                    System.IO.FileStream file;
					bFile=r2!=null;
					if (bFile)
					{
						image =new byte[0];
                        image1 = new byte[0];
						try
						{
							image =(byte[])(r2["image1"]);
                            if (image.Length == 0)
                            {
                                file = new FileStream("bangtmh_01.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                image = new byte[file.Length];
                                file.Read(image, 0, System.Convert.ToInt32(file.Length));
                            }
                            image1 = (byte[])(r2["image2"]);
                            if (image1.Length == 0)
                            {
                                file = new FileStream("bangtmh_02.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                image1 = new byte[file.Length];
                                file.Read(image1, 0, System.Convert.ToInt32(file.Length));
                            }
						}
                        catch (Exception ex) { string s = ex.Message; }
					}
					if (bFile) r["image"]=image;
                    if (bFile) r["image1"] = image1;
					if (r["ngayrv"].ToString()!="") m_songaydt=m.songay(m.StringToDate(r["ngayrv"].ToString()),m.StringToDate(r["ngayvv"].ToString()),1).ToString();
					if (m.get_data("select * from "+user+".chuyenkhoa where maql="+l_maql).Tables[0].Rows.Count!=0)
					{
						DataTable dtck=new DataTable();
						dtck=m.get_data("select khoaden,to_char(ngaychuyen,'dd/mm/yyyy hh24:mi') as ngaychuyen from "+user+".chuyenkhoa where maql="+l_maql+" order by ngaychuyen").Tables[0];
						m_chuyenkhoa1=dtck.Rows[0]["khoaden"].ToString();
						m_ngaychuyenkhoa1=dtck.Rows[0]["ngaychuyen"].ToString();
						m_songaydieutrivaokhoa=m.songay(m.StringToDate(m_ngaychuyenkhoa1.Substring(0,10)),m.StringToDate(ngayvk.Text.Substring(0,10)),1).ToString();
						if (dtck.Rows.Count>1)
						{
							m_chuyenkhoa2=dtck.Rows[1]["khoaden"].ToString();
							m_ngaychuyenkhoa2=dtck.Rows[1]["ngaychuyen"].ToString();
							m_songaydieutrichuyenkhoa1=m.songay(m.StringToDate(m_ngaychuyenkhoa2.Substring(0,10)),m.StringToDate(m_ngaychuyenkhoa1.Substring(0,10)),0).ToString();
						}
						else if (m_ngaychuyenkhoa1!="" && r["ngayrv"].ToString()!="") m_songaydieutrichuyenkhoa1=m.songay(m.StringToDate(r["ngayrv"].ToString()),m.StringToDate(m_ngaychuyenkhoa1.Substring(0,10)),0).ToString();
						if (dtck.Rows.Count>2)
						{
							m_chuyenkhoa3=dtck.Rows[2]["khoaden"].ToString();
							m_ngaychuyenkhoa3=dtck.Rows[2]["ngaychuyen"].ToString();
							m_songaydieutrichuyenkhoa2=m.songay(m.StringToDate(m_ngaychuyenkhoa3.Substring(0,10)),m.StringToDate(m_ngaychuyenkhoa2.Substring(0,10)),0).ToString();
							if (r["ngayrv"].ToString()!="") m_songaydieutrichuyenkhoa3=m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0,10)),m.StringToDate(m_ngaychuyenkhoa3.Substring(0,10)),0).ToString();
						}
						else if (m_ngaychuyenkhoa2!="" && r["ngayrv"].ToString()!="") m_songaydieutrichuyenkhoa2=m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0,10)),m.StringToDate(m_ngaychuyenkhoa2.Substring(0,10)),0).ToString(); 
					}
					else if (r["ngayrv"].ToString()!="") m_songaydieutrivaokhoa=m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0,10)),m.StringToDate(ngayvk.Text.Substring(0,10)),1).ToString();
			
					if (m.get_data("select * from "+user+".tuvong where maql="+l_maql).Tables[0].Rows.Count!=0)
					{
						m_ngaytuvong=r["ngayrv"].ToString();
						DataTable dttv=new DataTable();
						dttv=m.get_data("select chandoan,maicd,nguyennhan,benhly,khamtuthi from "+user+".tuvong where maql="+l_maql).Tables[0];
						m_tinhtrangtuvong=dttv.Rows[0]["nguyennhan"].ToString();
						m_cokhamnghiemtuthi=dttv.Rows[0]["khamtuthi"].ToString();
						if (m_cokhamnghiemtuthi=="1")
						{
							m_chandoantuthi=dttv.Rows[0]["chandoan"].ToString();
							m_icdchandoantuthi=m.Maicd_rpt(dttv.Rows[0]["maicd"].ToString());
						}
						m_nguyennhantuvong=r["chandoanrv"].ToString();
						m_icdnguyennhantuvong=m.Maicd_rpt(r["maicdrv"].ToString());
					}
					foreach(DataRow r1 in m.get_data("select * from "+user+".noigioithieu where maql="+l_maql).Tables[0].Rows)
					{
						m_cd_noichuyenden=r1["chandoan"].ToString();
						m_icd_noichuyenden=r1["maicd"].ToString();
					}

					if (r["madantoc"].ToString()=="55")
					{
						foreach(DataRow r1 in m.get_data("select a.ma,a.ten from "+user+".dmquocgia a,"+user+".nuocngoai b where a.ma=b.id_nuoc and b.mabn='"+mabn.Text+"'").Tables[0].Rows)
						{
							m_manuoc=r1["ma"].ToString();
							m_tennuoc=r1["ten"].ToString();
							break;
						}
					}

                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, tenfile, "NNT", s_tenkp, "", r["soluutru"].ToString(), m.Mabv + "/" + mabn.Text.Substring(0, 2) + "/" + mabn.Text.Substring(2), hoten.Text, r["ngaysinh"].ToString(), (stuoi.Substring(3) == "0") ? stuoi.Substring(1, 3) : "000", r["phai"].ToString(),
					r["tennn"].ToString(),r["mann"].ToString(),r["tendantoc"].ToString(),r["madantoc"].ToString(),m_tennuoc,m_manuoc,r["sonha"].ToString(),r["thon"].ToString(),
					r["tenpxa"].ToString(),r["tenquan"].ToString(),r["maqu"].ToString(),r["tentt"].ToString(),r["matt"].ToString(),r["cholam"].ToString(),r["madoituong"].ToString(),
					r["denngay"].ToString(),r["sothe"].ToString(),r["qh_hoten"].ToString(),r["qh_dienthoai"].ToString(),m_ngaybong,r["ngayvv"].ToString(),
					r["nhantu"].ToString(),r["dentu"].ToString(),"",r["makp"].ToString(),ngayvk.Text+" "+giovk.Text,
					m_songaydieutrivaokhoa,m_chuyenkhoa1,m_ngaychuyenkhoa1,m_songaydieutrichuyenkhoa1,m_chuyenkhoa2,m_ngaychuyenkhoa2,m_songaydieutrichuyenkhoa2,m_chuyenkhoa3,m_ngaychuyenkhoa3,m_songaydieutrichuyenkhoa3,
					r["loaibv"].ToString(),r["tenbv"].ToString(),r["ngayrv"].ToString(),r["ttlucrv"].ToString(),m_songaydt,
					m_cd_noichuyenden,m.Maicd_rpt(m_icd_noichuyenden),r["chandoanvv"].ToString(),m.Maicd_rpt(r["maicdvv"].ToString()),
					cd_kkb.Text,m.Maicd_rpt(icd_kkb.Text),"0","0",r["chandoanrv"].ToString(),
					m.Maicd_rpt(r["maicdrv"].ToString()),cd_kemtheo.Text,m.Maicd_rpt(icd_kemtheo.Text),
					r["taibien"].ToString(),r["bienchung"].ToString(),r["ketqua"].ToString(),r["giaiphau"].ToString(),m_ngaytuvong,m_tinhtrangtuvong,m_thoidiemtuvong,
					m_nguyennhantuvong,m_icdnguyennhantuvong,m_cokhamnghiemtuthi,m_chandoantuthi,m_icdchandoantuthi,m_nguyennhantaibienbienchung,m_tongsongaydieutrisauphauthuat,
					m_tongsolanphauthuat,r["chandoannn"].ToString(),m.Maicd_rpt(r["maicdnn"].ToString()),m_chandoantruocphauthuat,m_icdchandoantruocphauthuat,m_chandoansauphauthuat,
					m_icdchandoansauphauthuat,m_tinhtrangphauthuat,m_tdvh,"",
					lydo.Text,hb_benhly.Text,hb_giadinh.Text,hb_banthan.Text,kb_toanthan.Text,kb_tuanhoan.Text,mach.Text,nhietdo.Text,huyetap.Text,nhiptho.Text,cannang.Text,chieucao.Text,bmi.Text,
						kb_tomtat.Text,kb_khac.Text,dieutri.Text,chandoanrv.Text,m.Maicd_rpt(icdrv.Text),tungay.Text,denngay.Text,ngayvk.Text,giovk.Text,tenbsnb.Text,"","","","","","","","",i_maba.ToString());
                    f.ShowDialog();//r["lanthu"].ToString()
				}
			}
		}

		private void page_2(DataSet ds1)
		{
			if (ds1.Tables[0].Rows.Count>0)
			{
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, "", "rPage99.rpt");
				f.ShowDialog();
			}
		}

		private DataSet get_data()
		{
			string c01="",c02="",c03="",c04="",xn01="",xn02="",xn03="",xn04="",xn05="";
			foreach(DataRow r in dscd.Tables[0].Rows)
			{
				xn01+=r["ngay"].ToString().Trim()+"\n";
				xn02+=r["tenkp"].ToString().Trim()+"\n";
				xn03+=r["tenbs"].ToString().Trim()+"\n";
				xn04+=r["ten"].ToString().Trim()+"\n";
				xn05+=r["ketqua"].ToString().Trim()+"\n";
			}
			sql="select a.*,b.mach,b.nhietdo,b.huyetap,b.nhiptho,b.cannang,'' as c01,'' as c02,'' as c03,'' as c04,";
			sql+="'' as xn01,'' as xn02,'' as xn03,'' as xn04,'' as xn05,";
			sql+="'' as chandoan,'' as chandoankem,'' as phanbiet,'' as bacsiba,0 as pt,0 as tt,'' as tennguoigiao,'' as tennguoinhan,'' as bacsi,";
			sql+="'' as ngayba,'' as ngaydt,0 as xq,0 as ct,0 as sa,0 as xn,0 as stkhac,'' as loaikhac,0 as tong,";
			sql+="0 as k01,0 as k02,0 as k03,0 as k04,0 as k05,0 as k06,'' as t01,'' as t02,'' as t03,'' as t04,'' as t05,'' as t06";
			sql+=" from "+xxx+".ba_chung a,"+xxx+".ba_kbdausinhton b where a.id=b.id and a.id="+l_id;
			DataSet ds1=m.get_data(sql);				
			bool bFile=false;
			if (ds1.Tables[0].Rows.Count!=0)
			{
				DataColumn dc = new DataColumn("Image", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				bFile=r1!=null;
				if (bFile)
				{
					image =new byte[0];
					try
					{
						image =(byte[])(r1["image"]);
					}
					catch{}
				}
				string s="";
				foreach(DataRow r in ds1.Tables[0].Rows)
				{
					if (hb_banthan.Text!="") s+=hb_banthan.Text.Trim()+"\n";					
					r["hb_banthan"]=s;
					s="";
					if (kb_tomtat.Text!="") s+=kb_tomtat.Text.Trim();
					r["kb_tomtat"]=s;
					r["chandoan"]=cd_kkb.Text;
					r["chandoankem"]=cd_kemtheo.Text;
					r["phanbiet"]=phanbiet.Text;
					r["xn01"]=xn01;r["xn02"]=xn02;
					r["xn03"]=xn03;r["xn04"]=xn04;r["xn05"]=xn05;
					r["c01"]=c01;r["c02"]=c02;
					r["c03"]=c03;r["c04"]=c04;
					r["bacsiba"]=tenbsnb.Text;
					r["bacsi"]=tenbs.Text;
					r["ngayba"]=ngayvk.Text+" "+giovk.Text;
					r["ngaydt"]=ngayrv.Text+" "+giorv.Text;
					r["tennguoigiao"]=nguoigiao.Text;
					r["tennguoinhan"]=nguoinhan.Text;
					r["xq"]=st1.Value;	r["ct"]=st2.Value;
					r["sa"]=st3.Value;	r["xn"]=st4.Value;
					r["loaikhac"]=khac.Text;r["stkhac"]=st5.Value;
					r["tong"]=st6.Value;
					if (bFile) r["image"]=image;
				}
			}
			return ds1;
		}
		#endregion

		private void butDieutri_Click(object sender, System.EventArgs e)
		{
            frmTodieutri f = new frmTodieutri(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin, false, 0, null, i_madoituong);//,(rb2.Checked)?true:false
			f.ShowDialog(this);
		}

		private void butChamsoc_Click(object sender, System.EventArgs e)
		{
			frmChamsoc f=new frmChamsoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butPhanung_Click(object sender, System.EventArgs e)
		{
			frmPuthuoc f=new frmPuthuoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butDich_Click(object sender, System.EventArgs e)
		{
			frmTruyendich f=new frmTruyendich(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butMau_Click(object sender, System.EventArgs e)
		{
			frmTruyenmau f=new frmTruyenmau(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butDausinhton_Click(object sender, System.EventArgs e)
		{
            frmDausinhton_pk f = new frmDausinhton_pk(m, s_makp, l_maql, m.user + ".benhanngtr", 2, mabn.Text, (decimal)l_mavaovien, ngayvk.Text);//
			f.ShowDialog(this);
		}

		private void frmHSBenhan_NTTMH_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					if (butLuu.Enabled) butLuu_Click(sender,e);
					break;
				case Keys.F8:
					if (butBoqua.Enabled) butBoqua_Click(sender,e);
					break;
				case Keys.F9:
					if (butIn.Enabled) butIn_Click(sender,e);
					break;
				case Keys.F3:
					if (list.Enabled) 
					{
						DataRow r=m.getrowbyid(ds.Tables[0],"id="+long.Parse(list.SelectedValue.ToString()));
						if (r!=null) get_mabn(r["mabn"].ToString(),long.Parse(r["id"].ToString()));			
					}
					break;
				case Keys.F6:
					if (butChon.Enabled) butChon_Click(sender,e);
					break;
				case Keys.F10:
					if (butKethuc.Enabled) butKethuc_Click(sender,e);
					break;
				case Keys.F11:
					if (butVao.Enabled) butVao_Click(sender,e);
					break;
				case Keys.F12:
					if (butRa.Enabled) butRa_Click(sender,e);
					break;
			}		
			if (e.KeyCode==Keys.X && e.Control&&e.Shift)
			{
				if (mabn.Text=="" || hoten.Text=="") return;
				int ituoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
				frmCanlamsan.frmXemCanLamSan_medi f=new frmCanlamsan.frmXemCanLamSan_medi(mabn.Text,hoten.Text,(ituoi!=0)?ituoi.ToString():"",diachi.Text);
				f.ShowDialog(this);
			}
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			if ((xem.SelectedIndex==12 || xem.SelectedIndex==0) && (l_id==0))
			{
				if (!kiemtra()) return;
				xxx=user+m.mmyy(ngay.Text);
				bool bNhapkhoa=m.getrowbyid(ds.Tables[0],"nhapkhoa=0 and mabn='"+mabn.Text+"'")!=null;
				if (bNhapkhoa)
				{
					string s_tenkp=m.bHiendien(l_maql);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {")+s_tenkp.Trim().ToUpper()+lan.Change_language_MessageText("}"+"\nKhông thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"),LibMedi.AccessData.Msg);
						butBoqua_Click(null,null);
						return;
					}
					upd_nhapkhoa();
				}
                m.execute_data("update " + user + ".benhandt set mabs='" + mabsnb.Text + "' where maql=" + l_maql);
				l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
				if (l_idthuchien==0) 
				{
					l_idthuchien=m.getidyymmddhhmiss_stt_computer;//get_capid(-300);
					m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,"","",chandoan.Text);
				}
				l_id=m.get_idchung(ngay.Text,l_idthuchien);
				if (l_id==0) l_id=m.getidyymmddhhmiss_stt_computer;//get_capid(-301);
                m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, 1, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
					"","","","","","","","","",kb_khac.Text,kb_tomtat.Text,phanbiet.Text,
					"",dieutri.Text,mabsnb.Text,tk_benhly.Text,tk_tomtat.Text,tk_phuongphap.Text,tk_tinhtrang.Text,tk_dieutri.Text,manguoigiao.Text,manguoinhan.Text,mabs.Text,i_userid);
			}
			if (xem.SelectedIndex==10 && i_loai==1) return;
			switch (xem.SelectedIndex)
			{
				case 0:frmVanchuyen f0=new frmVanchuyen(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
					f0.ShowDialog(this);
					break;
				case 2:frmHoichancc f2=new frmHoichancc(m,ds,0,l_idthuchien,mabn.Text,s_makp,s_tenkp,i_userid,bAdmin,ngay.Text);
					f2.ShowDialog(this);
					break;
				case 3:frmKiemsoatcc f3=new frmKiemsoatcc(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
					f3.ShowDialog(this);
					break;
				case 4:frmHoichan f4=new frmHoichan(m,ds,0,l_idthuchien,mabn.Text,s_makp,s_tenkp,i_userid,bAdmin,ngay.Text);
					f4.ShowDialog(this);
					break;
				case 5:frmKiemsoat f5=new frmKiemsoat(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
					f5.ShowDialog(this);
					break;
				case 6:frmHcthuoc f6=new frmHcthuoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f6.ShowDialog(this);
					break;
				case 7:frmDanhgia f7=new frmDanhgia(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f7.ShowDialog(this);
					break;
				case 8:frmCamdoan f8=new frmCamdoan(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f8.ShowDialog(this);
					break;
				case 9:frmLinhmau f9=new frmLinhmau(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f9.ShowDialog(this);
					break;
				case 10:frmGiaonhan f10=new frmGiaonhan(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,l_id,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
						f10.ShowDialog(this);
						break;
				case 11:frmSoket f11=new frmSoket(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f11.ShowDialog(this);
					break;
				case 12:frmBascan f12=new frmBascan(m,0,mabn.Text,l_maql,l_idkhoa,l_id,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
						f12.ShowDialog(this);
					break;
				case 13:frmXemthuoc f13=new frmXemthuoc(m,l_maql,hoten.Text,"","");
						f13.ShowDialog(this);
						break;
				case 14:frmCongkhaiMabn f14=new frmCongkhaiMabn(mabn.Text);
						f14.ShowDialog(this);
						break;
                    case 15: frmCongnoMabn f15 = new frmCongnoMabn(m, mabn.Text, l_maql, DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"));
						f15.ShowDialog(this);
						break;
				case 19:					
					if (mabn.Text=="" || hoten.Text=="") return;
					int ituoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
					frmCanlamsan.frmXemCanLamSan_medi f=new frmCanlamsan.frmXemCanLamSan_medi(mabn.Text,hoten.Text,(ituoi!=0)?ituoi.ToString():"",diachi.Text);
					f.ShowDialog(this);
					break;
			}
		}

		private void butKethuc_Click(object sender, System.EventArgs e)
		{
			m.close();//v.close();
			System.GC.Collect();
			this.Close();
		}

		private void rb1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==rb1) load_list();
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                this.groupBox1.Location = new Point(5, 91);//236
                this.groupBox1.Size = new Size(1008, 550);//419
            }
		}

		private void rb2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==rb2) load_list();
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                this.groupBox1.Location = new Point(5, 91);//236
                this.groupBox1.Size = new Size(1008, 550);//419
            }
		}

		private void mabsnb_Validated(object sender, System.EventArgs e)
		{
			if (mabsnb.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
			if (r!=null) tenbsnb.Text=r["hoten"].ToString();
			else tenbsnb.Text="";		
		}

		private void tenbsnb_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsnb)
			{
				Filt_dmbs1(tenbsnb.Text);
				listNv1.BrowseToDanhmuc(tenbsnb,mabsnb,tenbsnb_pass,tenbsnb.Location.X,tenbsnb.Location.Y-98,35);
			}		
		}

		private void ngayvk_Validated(object sender, System.EventArgs e)
		{
			ngayvk.Text=ngayvk.Text.Trim();
			if (ngayvk.Text.Length==6) ngayvk.Text=ngayvk.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayvk.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngayvk.Focus();
				return;
			}
		}

		private void giovk_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giovk.Text.Trim()=="")?"00:00":giovk.Text.Trim();
			giovk.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giovk.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giovk.Focus();
				return;
			}
		}

		private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}
	
		private void tenbsnb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv1.Visible) listNv1.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbsnb_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}

		private void cannang_Validated(object sender, System.EventArgs e)
		{
			tinh_bmi();
		}

		private void chieucao_Validated(object sender, System.EventArgs e)
		{
			tinh_bmi();
		}

		private void tinh_bmi()
		{
			decimal cn=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
			decimal cc=(chieucao.Text!="")?decimal.Parse(chieucao.Text):0;
			decimal _bmi=0;
			if (cn!=0 && cc!=0) _bmi=cn/(cc/100*cc/100);
			else _bmi=0;
			bmi.Text=_bmi.ToString("####0.00");
		}

		private void butVao_Click(object sender, System.EventArgs e)
		{
			frmNgoaitru f0=new frmNgoaitru(m,s_makp+",",s_userid,i_userid,i_mabv,b_sovaovien,b_soluutru,s_nhomkho,s_mabs,i_madoituong.ToString());
			f0.ShowDialog(this);
			if (f0.bUpdate) load_list();
		}

		private void butRa_Click(object sender, System.EventArgs e)
		{
			frmNgoaitru f0=new frmNgoaitru(m,s_makp+",",s_userid,i_userid,i_mabv,b_sovaovien,b_soluutru,s_nhomkho,s_mabs,i_madoituong.ToString(),mabn.Text);
			f0.ShowDialog(this);
			if (f0.bUpdate)
			{
				load_list();
				DataRow r1;
				//foreach(DataRow r in m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,chandoan,maicd,mabs from xuatvien where maql="+l_maql).Tables[0].Rows)
                foreach (DataRow r in m.get_data("select to_char(ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,chandoanrv,maicdrv,mabs from " + user + ".benhanngtr where maql=" + l_maql).Tables[0].Rows)
				{
					mabs.Text=r["mabs"].ToString();
					r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
					if (r1!=null)
					{
						tenbs.Text=r1["hoten"].ToString();
						tenbs_pass.Text=r1["password_"].ToString();
					}
					cd_kkb.Text=r["chandoanrv"].ToString();
					icd_kkb.Text=r["maicdrv"].ToString();
					ngayrv.Text=r["ngayrv"].ToString().Substring(0,10);
					giorv.Text=r["ngayrv"].ToString().Substring(11);
					denngay.Text=r["ngayrv"].ToString();
					chandoanrv.Text=r["chandoanrv"].ToString();
					icdrv.Text=r["maicdrv"].ToString();
					break;
				}
			}
		}

		private void st1_Validated(object sender, System.EventArgs e)
		{
			st6.Value=st1.Value+st2.Value+st3.Value+st4.Value+st5.Value;
		}

		private void butPttt_Click(object sender, System.EventArgs e)
		{
			string stuoi=m.get_tuoivao(l_maql).Trim();
            frmPttt_ba f = new frmPttt_ba(m, s_makp, mabn.Text, hoten.Text, stuoi, phai.Text, diachi.Text, 
                sothe.Text, "", ngay.Text, cd_kkb.Text, icd_kkb.Text, "P", i_userid, 
                (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), "", 
                "", "", "", "", 0, 0, 0, 0, 0, DateTime.Now.Date.ToString("dd/MM/yyyy"), 0,0,2);
			f.ShowDialog(this);
		}

		private void butChuyenphong_Click(object sender, System.EventArgs e)
		{
		
		}

		private void butLoc_Click(object sender, System.EventArgs e)
		{
			frmLocmau f=new frmLocmau(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,"","",(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);		
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

        private void butAn_Click(object sender, EventArgs e)
        {

        }

        private void butHinh_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            if (l_maql == 0)
            {
                butLuu_Click(sender, e);
                ena_object(false);
            }
            frmBATMH f = new frmBATMH(m, l_maql, ngay.Text);
            f.ShowDialog();
        }

        private void butphanungthuocohai_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            //l_maql = m.get_maql_mmyy(2, s_mabn, makp.Text, ngayvv.Text, false);
            //if (l_maql == 0)
            //{
            //    butLuu_Click(sender, e);
            //    if (!bExit) return;
            //    ena_but(false);
            //}
            frmPhanungthuoccohai f = new frmPhanungthuoccohai(m, s_makp, phanbiet.Text, mabn.Text, i_userid, kb_khac.Text, s_userid, l_mavaovien, l_maql, ngay.Text, i_loai, i_maba, i_mabv,2);
            f.ShowDialog();
        }

        private void list_MouseEnter(object sender, EventArgs e)
        {
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);//236
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);//419
            }
        }

        private void butVantay_Click(object sender, EventArgs e)
        {

            lay_mabn_vantay();
        }
        void lay_mabn_vantay()
        {
            string tmp_mabn = mabn.Text.Trim();
            string ma_vantay = "";
            FingerApp.FrmNhanDang fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == i_maxlength_mabn)
            {
                mabn.Text = ma_vantay;
                mabn_Validated(null, null);
                ngayvk.Focus();
                SendKeys.Send("{Home}");
            }
        }

        private void butgoibenh_Click(object sender, EventArgs e)
        {
            int stt = 0;
            string sott = "";
            if (list.Items.Count > 0)
            {
                DataRow r1 = m.getrowbyid(ds.Tables[0], "stt=" + long.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = (r1["sovaovien"].ToString() == "") ? 0 : int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    sott = stt.ToString(); 
                }
            }
            if (sott == "") return;
            tu.Value = stt;
            den.Value = stt;
            tu.Update(); den.Update();
            if (bBangDienPhongKham) m.goi_kham(ngayvk.Text, s_makp, sott, sott, true);
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
                bBangDienPhongKham = false;
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
    }
}
