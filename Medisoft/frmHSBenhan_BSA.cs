using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Paint;
using LibVienphi;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmHSBenhan_BSA.
	/// </summary>
	public class frmHSBenhan_BSA : System.Windows.Forms.Form
	{
		Language lan = new Language();

        private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private System.Windows.Forms.Panel p;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox tenba;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.ComponentModel.IContainer components;
		private string sql,s_makp,s_mabs,user,xxx,s_tenkp,s_sovaovien,s_nhomkho,s_userid,filebmp="benhan.bmp";
		private int i_phong,i_userid,i_madoituong,itable,i_loai,i_maba, traituyen=0;
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
		private System.Windows.Forms.ComboBox xem;
		private System.Windows.Forms.Button butChon;
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
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Panel panel2;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
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
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.NumericUpDown lanthu;
		private System.Windows.Forms.TextBox lydo;
		private System.Windows.Forms.TextBox hb_giadinh;
		private System.Windows.Forms.TextBox hb_banthan;
		private System.Windows.Forms.TextBox kb_toanthan;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private LibList.List listICD;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.DataGrid dataGrid1;
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
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.TextBox kb_tuanhoan;
		private System.Windows.Forms.TextBox kb_hohap;
		private System.Windows.Forms.TextBox kb_tieuhoa;
		private System.Windows.Forms.TextBox kb_than;
		private System.Windows.Forms.TextBox phanbiet;
		private System.Windows.Forms.TextBox tienluong;
		private System.Windows.Forms.TextBox dieutri;
		private System.Windows.Forms.TextBox tenbsnb;
		private MaskedTextBox.MaskedTextBox mabsnb;
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
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button butBoqua;
		private LibList.List listNv;
		private MemoryStream memo;
		private FileStream fstr;
		private Bitmap map;
		private byte[] image,imagedt,image1,image2;
		private DataSet dscd=new DataSet();
		private DataSet dspt=new DataSet();
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dthinh=new DataTable();
		private DataSet dstress=new DataSet();
		private DataSet dsts=new DataSet();
		private System.Windows.Forms.TextBox cd_kkb;
		private MaskedTextBox.MaskedTextBox icd_kkb;
		private DataTable dticd=new DataTable();
		private decimal l_maql,l_id,l_idkhoa,l_idthuchien;
		private bool b_sovaovien,b_soluutru,bPhonggiuong,bAdmin,bHinh=false;
		private System.Windows.Forms.TabPage tab2;
		private System.Windows.Forms.TabPage tab3;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckedListBox chonin;
		private System.Windows.Forms.TabPage tab4;
		private string nor_toanthan,nor_tuanhoan,nor_hohap,nor_tieuhoa,nor_than,nor_thankinh,nor_co,nor_tmh,nor_rhm,nor_mat,nor_noitiet,thumucpic;
		private string f1="",f2="";
		private System.Windows.Forms.TextBox tenbs_pass;
		private AsYetUnnamedColor.MultiColumnListBoxColor list;
		private System.Windows.Forms.Button butPhong;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.Label label105;
		private MaskedBox.MaskedBox tungay;
		private MaskedBox.MaskedBox denngay;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.Label label107;
		private MaskedTextBox.MaskedTextBox tuoithai;
		private System.Windows.Forms.Label label108;
		private System.Windows.Forms.TextBox khamthai;
		private System.Windows.Forms.CheckBox uonvan;
		private System.Windows.Forms.Label label109;
		private MaskedTextBox.MaskedTextBox tiem;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.Label label18;
		private MaskedBox.MaskedBox giochuyenda;
		private MaskedBox.MaskedBox ngaychuyenda;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox dauhieu;
		private System.Windows.Forms.TextBox bienchuyen;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private MaskedTextBox.MaskedTextBox kinhnam;
		private MaskedTextBox.MaskedTextBox kinhtuoi;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tinhchat;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private MaskedTextBox.MaskedTextBox chuky;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox luongkinh;
		private MaskedTextBox.MaskedTextBox chongtuoi;
		private System.Windows.Forms.Label label32;
		private MaskedTextBox.MaskedTextBox chongnam;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label111;
		private System.Windows.Forms.TextBox dadieutri;
		private System.Windows.Forms.Panel p2;
		private System.Windows.Forms.PictureBox pic2;
		private System.Windows.Forms.Panel p1;
		private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.ComboBox stt2;
		private System.Windows.Forms.ComboBox stt1;
		private System.Windows.Forms.CheckBox chkHinh;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.TextBox kb_khac;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.CheckBox ptcu;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.TextBox dangtc;
		private System.Windows.Forms.TextBox tuthe;
		private System.Windows.Forms.Label label58;
		private MaskedTextBox.MaskedTextBox caotc;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private MaskedTextBox.MaskedTextBox vongbung;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.TextBox cotc;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.Label label100;
		private MaskedTextBox.MaskedTextBox timthai;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.TextBox vu;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label103;
		private MaskedTextBox.MaskedTextBox bishop;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.Label label115;
		private System.Windows.Forms.TextBox amho;
		private System.Windows.Forms.TextBox amdao;
		private System.Windows.Forms.TextBox sinhmon;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.Label label117;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.TextBox tucung;
		private System.Windows.Forms.TextBox phanphu;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.Label label124;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.TextBox mausac;
		private System.Windows.Forms.TextBox nuocoi;
		private System.Windows.Forms.TextBox ngoi;
		private System.Windows.Forms.TextBox the;
		private System.Windows.Forms.TextBox kieu;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.ComboBox dolot;
		private System.Windows.Forms.ComboBox oivo;
		private System.Windows.Forms.ComboBox tinhtrangoi;
		private System.Windows.Forms.TextBox have;
		private System.Windows.Forms.Label label129;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label130;
		private MaskedBox.MaskedBox giode;
		private MaskedBox.MaskedBox ngayde;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.Label label133;
		private System.Windows.Forms.Label label134;
		private LibList.List listNv1;
		private System.Windows.Forms.TextBox tentheodoi;
		private MaskedTextBox.MaskedTextBox theodoi;
		private System.Windows.Forms.TextBox chucdanh;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.ComboBox rau;
		private MaskedBox.MaskedBox ngayrau;
		private MaskedBox.MaskedBox giorau;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label135;
		private System.Windows.Forms.Label label136;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.Label label138;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.Label label140;
		private MaskedTextBox.MaskedTextBox raucannang;
		private System.Windows.Forms.TextBox cachso;
		private System.Windows.Forms.TextBox mang;
		private System.Windows.Forms.TextBox mui;
		private System.Windows.Forms.TextBox banhrau;
		private System.Windows.Forms.Label label141;
		private MaskedTextBox.MaskedTextBox raudai;
		private System.Windows.Forms.Label label142;
		private System.Windows.Forms.CheckBox chaymau;
		private System.Windows.Forms.Label label143;
		private MaskedTextBox.MaskedTextBox maumat;
		private System.Windows.Forms.Label label144;
		private System.Windows.Forms.Label label145;
		private System.Windows.Forms.TextBox xuly;
		private System.Windows.Forms.CheckBox kiemsoattc;
		private System.Windows.Forms.Label label146;
		private System.Windows.Forms.Label label147;
		private System.Windows.Forms.TextBox da;
		private System.Windows.Forms.Label label148;
		private System.Windows.Forms.ComboBox ppde;
		private System.Windows.Forms.Panel panel3;
		private MaskedBox.MaskedBox sd_nhietdo;
		private MaskedBox.MaskedBox sd_huyetap;
		private MaskedTextBox.MaskedTextBox sd_nhiptho;
		private MaskedTextBox.MaskedTextBox sd_mach;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.Label label153;
		private System.Windows.Forms.TextBox canthiep;
		private System.Windows.Forms.Label label154;
		private System.Windows.Forms.ComboBox tangsinhmon;
		private System.Windows.Forms.Label label159;
		private System.Windows.Forms.Label label160;
		private MaskedTextBox.MaskedTextBox somui;
		private System.Windows.Forms.TextBox loaichi;
		private System.Windows.Forms.Label label161;
		private System.Windows.Forms.ComboBox cotucung;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Label label162;
		private System.Windows.Forms.Label label163;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.TextBox chandoan_t;
		private System.Windows.Forms.TextBox chandoan_s;
		private System.Windows.Forms.Label label164;
		private System.Windows.Forms.ComboBox taibien;
		private System.Windows.Forms.CheckBox bienchung;
		private System.Windows.Forms.Button butTresosinh;
		private System.Windows.Forms.Button butTiensu;
		private MaskedBox.MaskedBox giovo;
		private MaskedBox.MaskedBox ngayvo;
		private System.Windows.Forms.CheckBox phu;
		private System.Windows.Forms.CheckBox raucuon;
		private System.Windows.Forms.Label label165;
		private MaskedTextBox.MaskedTextBox cao;
		private System.Windows.Forms.Label label166;
		private System.Windows.Forms.Label label167;
		private MaskedBox.MaskedBox ngaysaude;
		private MaskedBox.MaskedBox giosaude;
		private System.Windows.Forms.Label label168;
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
        private Label label169;
        private Label label170;
        private ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.TextBox tenbsnb_pass;

		public frmHSBenhan_BSA(LibMedi.AccessData acc,string _makp,string _tenkp,int _phong,string _mabs,int userid,string _nhomkho,string suserid,bool _soluutru,bool _sovaovien,bool _admin,int _loai,int _maba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //Language lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m=acc;s_makp=_makp;s_tenkp=_tenkp;i_phong=_phong;s_mabs=_mabs;i_userid=userid;s_nhomkho=_nhomkho;
			s_userid=suserid;b_sovaovien=_sovaovien;b_soluutru=_soluutru;bAdmin=_admin;i_loai=_loai;i_maba=_maba;
            user = m.user;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHSBenhan_BSA));
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
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.barChonkhoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.barDausinhton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.barPhanUng = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.barPttt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.barKetthuc = new System.Windows.Forms.ToolStripButton();
            this.butKethuc = new System.Windows.Forms.Button();
            this.butPhanung = new System.Windows.Forms.Button();
            this.butAn = new System.Windows.Forms.Button();
            this.butChamsoc = new System.Windows.Forms.Button();
            this.butDieutri = new System.Windows.Forms.Button();
            this.butChidinh = new System.Windows.Forms.Button();
            this.butChuyenphong = new System.Windows.Forms.Button();
            this.butKhoa = new System.Windows.Forms.Button();
            this.butDich = new System.Windows.Forms.Button();
            this.butDausinhton = new System.Windows.Forms.Button();
            this.butPttt = new System.Windows.Forms.Button();
            this.butMau = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butRef = new System.Windows.Forms.Button();
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.tenbsnb_pass = new System.Windows.Forms.TextBox();
            this.list = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.butPhong = new System.Windows.Forms.Button();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.tenba = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.phong = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.label165 = new System.Windows.Forms.Label();
            this.phu = new System.Windows.Forms.CheckBox();
            this.butTiensu = new System.Windows.Forms.Button();
            this.label112 = new System.Windows.Forms.Label();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.label92 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.kb_toanthan = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.chongtuoi = new MaskedTextBox.MaskedTextBox();
            this.kinhtuoi = new MaskedTextBox.MaskedTextBox();
            this.dadieutri = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.chongnam = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.luongkinh = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tinhchat = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.kinhnam = new MaskedTextBox.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.bienchuyen = new System.Windows.Forms.TextBox();
            this.dauhieu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.giochuyenda = new MaskedBox.MaskedBox();
            this.ngaychuyenda = new MaskedBox.MaskedBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.tiem = new MaskedTextBox.MaskedTextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.uonvan = new System.Windows.Forms.CheckBox();
            this.khamthai = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.tuoithai = new MaskedTextBox.MaskedTextBox();
            this.label107 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.denngay = new MaskedBox.MaskedBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label105 = new System.Windows.Forms.Label();
            this.hb_giadinh = new System.Windows.Forms.TextBox();
            this.hb_banthan = new System.Windows.Forms.TextBox();
            this.lydo = new System.Windows.Forms.TextBox();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cao = new MaskedTextBox.MaskedTextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
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
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.chuky = new MaskedTextBox.MaskedTextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.kb_tuanhoan = new System.Windows.Forms.TextBox();
            this.kb_hohap = new System.Windows.Forms.TextBox();
            this.kb_tieuhoa = new System.Windows.Forms.TextBox();
            this.kb_than = new System.Windows.Forms.TextBox();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.giovk = new MaskedBox.MaskedBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.have = new System.Windows.Forms.TextBox();
            this.tinhtrangoi = new System.Windows.Forms.ComboBox();
            this.oivo = new System.Windows.Forms.ComboBox();
            this.dolot = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.kieu = new System.Windows.Forms.TextBox();
            this.the = new System.Windows.Forms.TextBox();
            this.ngoi = new System.Windows.Forms.TextBox();
            this.nuocoi = new System.Windows.Forms.TextBox();
            this.mausac = new System.Windows.Forms.TextBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.giovo = new MaskedBox.MaskedBox();
            this.ngayvo = new MaskedBox.MaskedBox();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.phanphu = new System.Windows.Forms.TextBox();
            this.tucung = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.sinhmon = new System.Windows.Forms.TextBox();
            this.amdao = new System.Windows.Forms.TextBox();
            this.amho = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.bishop = new MaskedTextBox.MaskedTextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.vu = new System.Windows.Forms.TextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.timthai = new MaskedTextBox.MaskedTextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.cotc = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.vongbung = new MaskedTextBox.MaskedTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.caotc = new MaskedTextBox.MaskedTextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.tuthe = new System.Windows.Forms.TextBox();
            this.dangtc = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.ptcu = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.stt2 = new System.Windows.Forms.ComboBox();
            this.stt1 = new System.Windows.Forms.ComboBox();
            this.chkHinh = new System.Windows.Forms.CheckBox();
            this.p2 = new System.Windows.Forms.Panel();
            this.p1 = new System.Windows.Forms.Panel();
            this.kb_khac = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.listICD = new LibList.List();
            this.listNv = new LibList.List();
            this.label65 = new System.Windows.Forms.Label();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.phanbiet = new System.Windows.Forms.TextBox();
            this.mabsnb = new MaskedTextBox.MaskedTextBox();
            this.tenbsnb = new System.Windows.Forms.TextBox();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.label168 = new System.Windows.Forms.Label();
            this.ngaysaude = new MaskedBox.MaskedBox();
            this.giosaude = new MaskedBox.MaskedBox();
            this.butTresosinh = new System.Windows.Forms.Button();
            this.bienchung = new System.Windows.Forms.CheckBox();
            this.taibien = new System.Windows.Forms.ComboBox();
            this.label164 = new System.Windows.Forms.Label();
            this.chandoan_s = new System.Windows.Forms.TextBox();
            this.chandoan_t = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.cotucung = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.loaichi = new System.Windows.Forms.TextBox();
            this.somui = new MaskedTextBox.MaskedTextBox();
            this.tangsinhmon = new System.Windows.Forms.ComboBox();
            this.label160 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.ppde = new System.Windows.Forms.ComboBox();
            this.canthiep = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sd_nhietdo = new MaskedBox.MaskedBox();
            this.sd_huyetap = new MaskedBox.MaskedBox();
            this.sd_nhiptho = new MaskedTextBox.MaskedTextBox();
            this.sd_mach = new MaskedTextBox.MaskedTextBox();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.da = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.xuly = new System.Windows.Forms.TextBox();
            this.label145 = new System.Windows.Forms.Label();
            this.kiemsoattc = new System.Windows.Forms.CheckBox();
            this.label144 = new System.Windows.Forms.Label();
            this.maumat = new MaskedTextBox.MaskedTextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.chaymau = new System.Windows.Forms.CheckBox();
            this.label142 = new System.Windows.Forms.Label();
            this.raudai = new MaskedTextBox.MaskedTextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.banhrau = new System.Windows.Forms.TextBox();
            this.mui = new System.Windows.Forms.TextBox();
            this.mang = new System.Windows.Forms.TextBox();
            this.cachso = new System.Windows.Forms.TextBox();
            this.raucannang = new MaskedTextBox.MaskedTextBox();
            this.raucuon = new System.Windows.Forms.CheckBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.ngayrau = new MaskedBox.MaskedBox();
            this.giorau = new MaskedBox.MaskedBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.rau = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.chucdanh = new System.Windows.Forms.TextBox();
            this.ngayde = new MaskedBox.MaskedBox();
            this.tentheodoi = new System.Windows.Forms.TextBox();
            this.theodoi = new MaskedTextBox.MaskedTextBox();
            this.listNv1 = new LibList.List();
            this.label134 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.giode = new MaskedBox.MaskedBox();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.giorv = new MaskedBox.MaskedBox();
            this.ngayrv = new MaskedBox.MaskedBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.nguoinhan = new System.Windows.Forms.TextBox();
            this.manguoinhan = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new System.Windows.Forms.TextBox();
            this.manguoigiao = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
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
            this.label77 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label169 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.p.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            this.panel2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.p2.SuspendLayout();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tab4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.SuspendLayout();
            // 
            // p
            // 
            this.p.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p.Controls.Add(this.butChon);
            this.p.Controls.Add(this.xem);
            this.p.Controls.Add(this.toolStrip1);
            this.p.Dock = System.Windows.Forms.DockStyle.Top;
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(1016, 32);
            this.p.TabIndex = 7;
            this.p.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Paint);
            // 
            // butChon
            // 
            this.butChon.Enabled = false;
            this.butChon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChon.Location = new System.Drawing.Point(939, 2);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(60, 23);
            this.butChon.TabIndex = 14;
            this.butChon.Text = "Chọn";
            this.toolTip1.SetToolTip(this.butChon, "F6 Chọn");
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // xem
            // 
            this.xem.BackColor = System.Drawing.SystemColors.Info;
            this.xem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xem.Enabled = false;
            this.xem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xem.Items.AddRange(new object[] {
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
            "Diễn biến chuyển dạ",
            "Diễn biến hậu sản gần",
            "Diễn biến hậu sản",
            "Thuốc đã sử dụng",
            "Công khai thuốc",
            "Công nợ",
            "Xuất khoa",
            "Thanh toán ra viện",
            "Giấy ra viện",
            "Giấy chuyển viện"});
            this.xem.Location = new System.Drawing.Point(585, 2);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(352, 22);
            this.xem.TabIndex = 13;
            this.xem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
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
            this.toolStripSeparator12,
            this.barChonkhoa,
            this.toolStripSeparator8,
            this.barDausinhton,
            this.toolStripSeparator9,
            this.barPhanUng,
            this.toolStripSeparator10,
            this.barPttt,
            this.toolStripSeparator11,
            this.barKetthuc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1012, 25);
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
            this.barChuyengiuong.ToolTipText = "Chuyển giường điều trị";
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
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // barChonkhoa
            // 
            this.barChonkhoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChonkhoa.Image = ((System.Drawing.Image)(resources.GetObject("barChonkhoa.Image")));
            this.barChonkhoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChonkhoa.Name = "barChonkhoa";
            this.barChonkhoa.Size = new System.Drawing.Size(23, 22);
            this.barChonkhoa.ToolTipText = "Chọn khoa làm việc";
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
            // 
            // butKethuc
            // 
            this.butKethuc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butKethuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKethuc.Location = new System.Drawing.Point(3, 442);
            this.butKethuc.Name = "butKethuc";
            this.butKethuc.Size = new System.Drawing.Size(178, 25);
            this.butKethuc.TabIndex = 15;
            this.butKethuc.Text = "     Kết thúc";
            this.butKethuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butKethuc, "F10 Kết thúc");
            this.butKethuc.Click += new System.EventHandler(this.butKethuc_Click);
            // 
            // butPhanung
            // 
            this.butPhanung.Enabled = false;
            this.butPhanung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butPhanung.Image = ((System.Drawing.Image)(resources.GetObject("butPhanung.Image")));
            this.butPhanung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanung.Location = new System.Drawing.Point(3, 418);
            this.butPhanung.Name = "butPhanung";
            this.butPhanung.Size = new System.Drawing.Size(178, 25);
            this.butPhanung.TabIndex = 12;
            this.butPhanung.Text = "     Phản ứng thuốc";
            this.butPhanung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanung.Click += new System.EventHandler(this.butPhanung_Click);
            // 
            // butAn
            // 
            this.butAn.Enabled = false;
            this.butAn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butAn.Image = ((System.Drawing.Image)(resources.GetObject("butAn.Image")));
            this.butAn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAn.Location = new System.Drawing.Point(3, 274);
            this.butAn.Name = "butAn";
            this.butAn.Size = new System.Drawing.Size(178, 25);
            this.butAn.TabIndex = 4;
            this.butAn.Text = "     Chế độ ăn";
            this.butAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAn.Click += new System.EventHandler(this.butAn_Click);
            // 
            // butChamsoc
            // 
            this.butChamsoc.Enabled = false;
            this.butChamsoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChamsoc.Image = ((System.Drawing.Image)(resources.GetObject("butChamsoc.Image")));
            this.butChamsoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChamsoc.Location = new System.Drawing.Point(3, 298);
            this.butChamsoc.Name = "butChamsoc";
            this.butChamsoc.Size = new System.Drawing.Size(178, 25);
            this.butChamsoc.TabIndex = 5;
            this.butChamsoc.Text = "     Chăm sóc";
            this.butChamsoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChamsoc.Click += new System.EventHandler(this.butChamsoc_Click);
            // 
            // butDieutri
            // 
            this.butDieutri.Enabled = false;
            this.butDieutri.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butDieutri.Image = ((System.Drawing.Image)(resources.GetObject("butDieutri.Image")));
            this.butDieutri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDieutri.Location = new System.Drawing.Point(3, 250);
            this.butDieutri.Name = "butDieutri";
            this.butDieutri.Size = new System.Drawing.Size(178, 25);
            this.butDieutri.TabIndex = 3;
            this.butDieutri.Text = "     Tờ điều trị";
            this.butDieutri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDieutri.Click += new System.EventHandler(this.butDieutri_Click);
            // 
            // butChidinh
            // 
            this.butChidinh.Enabled = false;
            this.butChidinh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChidinh.Image = ((System.Drawing.Image)(resources.GetObject("butChidinh.Image")));
            this.butChidinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChidinh.Location = new System.Drawing.Point(3, 226);
            this.butChidinh.Name = "butChidinh";
            this.butChidinh.Size = new System.Drawing.Size(178, 25);
            this.butChidinh.TabIndex = 2;
            this.butChidinh.Text = "     Phiếu chỉ định";
            this.butChidinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChidinh.Click += new System.EventHandler(this.butChidinh_Click);
            // 
            // butChuyenphong
            // 
            this.butChuyenphong.Enabled = false;
            this.butChuyenphong.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChuyenphong.Image = ((System.Drawing.Image)(resources.GetObject("butChuyenphong.Image")));
            this.butChuyenphong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyenphong.Location = new System.Drawing.Point(3, 202);
            this.butChuyenphong.Name = "butChuyenphong";
            this.butChuyenphong.Size = new System.Drawing.Size(178, 25);
            this.butChuyenphong.TabIndex = 1;
            this.butChuyenphong.Text = "     Chuyển giường";
            this.butChuyenphong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyenphong.Click += new System.EventHandler(this.butChuyenphong_Click);
            // 
            // butKhoa
            // 
            this.butKhoa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butKhoa.Image = ((System.Drawing.Image)(resources.GetObject("butKhoa.Image")));
            this.butKhoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhoa.Location = new System.Drawing.Point(3, 178);
            this.butKhoa.Name = "butKhoa";
            this.butKhoa.Size = new System.Drawing.Size(178, 25);
            this.butKhoa.TabIndex = 0;
            this.butKhoa.Text = "     Chọn khoa";
            this.butKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhoa.Click += new System.EventHandler(this.butKhoa_Click);
            // 
            // butDich
            // 
            this.butDich.Enabled = false;
            this.butDich.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butDich.Image = ((System.Drawing.Image)(resources.GetObject("butDich.Image")));
            this.butDich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDich.Location = new System.Drawing.Point(3, 346);
            this.butDich.Name = "butDich";
            this.butDich.Size = new System.Drawing.Size(178, 25);
            this.butDich.TabIndex = 7;
            this.butDich.Text = "     Truyền dịch";
            this.butDich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDich.Click += new System.EventHandler(this.butDich_Click);
            // 
            // butDausinhton
            // 
            this.butDausinhton.Enabled = false;
            this.butDausinhton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butDausinhton.Image = ((System.Drawing.Image)(resources.GetObject("butDausinhton.Image")));
            this.butDausinhton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDausinhton.Location = new System.Drawing.Point(3, 370);
            this.butDausinhton.Name = "butDausinhton";
            this.butDausinhton.Size = new System.Drawing.Size(178, 25);
            this.butDausinhton.TabIndex = 10;
            this.butDausinhton.Text = "     Chức năng sống";
            this.butDausinhton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDausinhton.Click += new System.EventHandler(this.butDausinhton_Click);
            // 
            // butPttt
            // 
            this.butPttt.Enabled = false;
            this.butPttt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butPttt.Image = ((System.Drawing.Image)(resources.GetObject("butPttt.Image")));
            this.butPttt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPttt.Location = new System.Drawing.Point(3, 394);
            this.butPttt.Name = "butPttt";
            this.butPttt.Size = new System.Drawing.Size(178, 25);
            this.butPttt.TabIndex = 11;
            this.butPttt.Text = "     Phẩu thủ thuật";
            this.butPttt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPttt.Click += new System.EventHandler(this.butPttt_Click);
            // 
            // butMau
            // 
            this.butMau.Enabled = false;
            this.butMau.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butMau.Image = ((System.Drawing.Image)(resources.GetObject("butMau.Image")));
            this.butMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMau.Location = new System.Drawing.Point(3, 322);
            this.butMau.Name = "butMau";
            this.butMau.Size = new System.Drawing.Size(178, 25);
            this.butMau.TabIndex = 6;
            this.butMau.Text = "     Truyền máu";
            this.butMau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMau.Click += new System.EventHandler(this.butMau_Click);
            // 
            // butRef
            // 
            this.butRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(160, 76);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(22, 21);
            this.butRef.TabIndex = 6;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách người bệnh");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(722, 521);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(62, 21);
            this.tenbs_pass.TabIndex = 42;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_pass_KeyDown);
            // 
            // tenbsnb_pass
            // 
            this.tenbsnb_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb_pass.Enabled = false;
            this.tenbsnb_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb_pass.Location = new System.Drawing.Point(704, 531);
            this.tenbsnb_pass.Name = "tenbsnb_pass";
            this.tenbsnb_pass.PasswordChar = '*';
            this.tenbsnb_pass.Size = new System.Drawing.Size(80, 21);
            this.tenbsnb_pass.TabIndex = 35;
            this.toolTip1.SetToolTip(this.tenbsnb_pass, "Mật khẩu bác sĩ làm bệnh án");
            this.tenbsnb_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_pass_KeyDown);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(6, 4);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(176, 173);
            this.list.TabIndex = 12;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F3 chọn");
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // butPhong
            // 
            this.butPhong.Enabled = false;
            this.butPhong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butPhong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPhong.Location = new System.Drawing.Point(765, 63);
            this.butPhong.Name = "butPhong";
            this.butPhong.Size = new System.Drawing.Size(22, 21);
            this.butPhong.TabIndex = 299;
            this.butPhong.Text = "...";
            this.toolTip1.SetToolTip(this.butPhong, "Chọn phòng giường");
            this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(0, 0);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(152, 86);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.toolTip1.SetToolTip(this.pic2, "Chỉnh sửa hình Double Click");
            this.pic2.DoubleClick += new System.EventHandler(this.pic2_DoubleClick);
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(0, 0);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(152, 86);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.toolTip1.SetToolTip(this.pic1, "Chỉnh sửa hình Double Click");
            this.pic1.DoubleClick += new System.EventHandler(this.pic1_DoubleClick);
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(273, 41);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(96, 21);
            this.tenba.TabIndex = 1;
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.CadetBlue;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(220, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.butKethuc);
            this.panel1.Controls.Add(this.list);
            this.panel1.Controls.Add(this.butPhanung);
            this.panel1.Controls.Add(this.chonin);
            this.panel1.Controls.Add(this.butPttt);
            this.panel1.Controls.Add(this.butDausinhton);
            this.panel1.Controls.Add(this.butDich);
            this.panel1.Controls.Add(this.butChamsoc);
            this.panel1.Controls.Add(this.butAn);
            this.panel1.Controls.Add(this.butKhoa);
            this.panel1.Controls.Add(this.butMau);
            this.panel1.Controls.Add(this.butChuyenphong);
            this.panel1.Controls.Add(this.butDieutri);
            this.panel1.Controls.Add(this.butChidinh);
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 609);
            this.panel1.TabIndex = 0;
            // 
            // chonin
            // 
            this.chonin.CheckOnClick = true;
            this.chonin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonin.Items.AddRange(new object[] {
            "Trang 1",
            "Trang 2",
            "Trang 3",
            "Trang 4"});
            this.chonin.Location = new System.Drawing.Point(0, 473);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(182, 68);
            this.chonin.TabIndex = 11;
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(7, 75);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(151, 21);
            this.tim.TabIndex = 10;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(7, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 32);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rb2
            // 
            this.rb2.BackColor = System.Drawing.Color.CadetBlue;
            this.rb2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rb2.Location = new System.Drawing.Point(93, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(68, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Hồ sơ củ";
            this.rb2.UseVisualStyleBackColor = false;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb1
            // 
            this.rb1.BackColor = System.Drawing.Color.CadetBlue;
            this.rb1.Checked = true;
            this.rb1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rb1.Location = new System.Drawing.Point(5, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(136, 18);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Đang điều trị";
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(273, 63);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(94, 21);
            this.ngay.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.CadetBlue;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(192, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Ngày vào viện :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(416, 63);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(144, 21);
            this.sothe.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.CadetBlue;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(368, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(848, 42);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(151, 21);
            this.diachi.TabIndex = 37;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(776, 41);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 36;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(693, 41);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 35;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(518, 41);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(146, 21);
            this.hoten.TabIndex = 34;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(416, 41);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.CadetBlue;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(804, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.CadetBlue;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(724, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CadetBlue;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(650, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(474, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.CadetBlue;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(361, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.CadetBlue;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(555, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 46;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.CadetBlue;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(660, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 47;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.CadetBlue;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(197, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(600, 63);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(64, 21);
            this.phong.TabIndex = 49;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(705, 63);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(58, 21);
            this.giuong.TabIndex = 50;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(273, 85);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(725, 21);
            this.chandoan.TabIndex = 51;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Location = new System.Drawing.Point(190, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 605);
            this.tabControl1.TabIndex = 3;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.label165);
            this.tab2.Controls.Add(this.phu);
            this.tab2.Controls.Add(this.butTiensu);
            this.tab2.Controls.Add(this.label112);
            this.tab2.Controls.Add(this.dataGrid3);
            this.tab2.Controls.Add(this.label92);
            this.tab2.Controls.Add(this.label97);
            this.tab2.Controls.Add(this.label96);
            this.tab2.Controls.Add(this.label95);
            this.tab2.Controls.Add(this.label55);
            this.tab2.Controls.Add(this.label54);
            this.tab2.Controls.Add(this.label53);
            this.tab2.Controls.Add(this.label52);
            this.tab2.Controls.Add(this.kb_toanthan);
            this.tab2.Controls.Add(this.label37);
            this.tab2.Controls.Add(this.chongtuoi);
            this.tab2.Controls.Add(this.kinhtuoi);
            this.tab2.Controls.Add(this.dadieutri);
            this.tab2.Controls.Add(this.label111);
            this.tab2.Controls.Add(this.label32);
            this.tab2.Controls.Add(this.chongnam);
            this.tab2.Controls.Add(this.label33);
            this.tab2.Controls.Add(this.luongkinh);
            this.tab2.Controls.Add(this.label30);
            this.tab2.Controls.Add(this.label27);
            this.tab2.Controls.Add(this.label26);
            this.tab2.Controls.Add(this.tinhchat);
            this.tab2.Controls.Add(this.label25);
            this.tab2.Controls.Add(this.label24);
            this.tab2.Controls.Add(this.kinhnam);
            this.tab2.Controls.Add(this.label23);
            this.tab2.Controls.Add(this.label22);
            this.tab2.Controls.Add(this.bienchuyen);
            this.tab2.Controls.Add(this.dauhieu);
            this.tab2.Controls.Add(this.label21);
            this.tab2.Controls.Add(this.label20);
            this.tab2.Controls.Add(this.giochuyenda);
            this.tab2.Controls.Add(this.ngaychuyenda);
            this.tab2.Controls.Add(this.label19);
            this.tab2.Controls.Add(this.label18);
            this.tab2.Controls.Add(this.label110);
            this.tab2.Controls.Add(this.tiem);
            this.tab2.Controls.Add(this.label109);
            this.tab2.Controls.Add(this.uonvan);
            this.tab2.Controls.Add(this.khamthai);
            this.tab2.Controls.Add(this.label108);
            this.tab2.Controls.Add(this.tuoithai);
            this.tab2.Controls.Add(this.label107);
            this.tab2.Controls.Add(this.label106);
            this.tab2.Controls.Add(this.denngay);
            this.tab2.Controls.Add(this.tungay);
            this.tab2.Controls.Add(this.label105);
            this.tab2.Controls.Add(this.hb_giadinh);
            this.tab2.Controls.Add(this.hb_banthan);
            this.tab2.Controls.Add(this.lydo);
            this.tab2.Controls.Add(this.lanthu);
            this.tab2.Controls.Add(this.label50);
            this.tab2.Controls.Add(this.label49);
            this.tab2.Controls.Add(this.panel2);
            this.tab2.Controls.Add(this.label36);
            this.tab2.Controls.Add(this.label35);
            this.tab2.Controls.Add(this.label34);
            this.tab2.Controls.Add(this.label17);
            this.tab2.Controls.Add(this.label16);
            this.tab2.Controls.Add(this.label28);
            this.tab2.Controls.Add(this.label29);
            this.tab2.Controls.Add(this.label15);
            this.tab2.Controls.Add(this.label14);
            this.tab2.Controls.Add(this.label31);
            this.tab2.Controls.Add(this.chuky);
            this.tab2.Controls.Add(this.label98);
            this.tab2.Controls.Add(this.kb_tuanhoan);
            this.tab2.Controls.Add(this.kb_hohap);
            this.tab2.Controls.Add(this.kb_tieuhoa);
            this.tab2.Controls.Add(this.kb_than);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(811, 579);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Trang 2";
            // 
            // label165
            // 
            this.label165.BackColor = System.Drawing.SystemColors.Control;
            this.label165.Image = ((System.Drawing.Image)(resources.GetObject("label165.Image")));
            this.label165.Location = new System.Drawing.Point(87, 440);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(16, 16);
            this.label165.TabIndex = 394;
            this.label165.Click += new System.EventHandler(this.label165_Click);
            // 
            // phu
            // 
            this.phu.Enabled = false;
            this.phu.Location = new System.Drawing.Point(584, 463);
            this.phu.Name = "phu";
            this.phu.Size = new System.Drawing.Size(48, 16);
            this.phu.TabIndex = 24;
            this.phu.Text = "Phù";
            this.phu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // butTiensu
            // 
            this.butTiensu.Enabled = false;
            this.butTiensu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butTiensu.Location = new System.Drawing.Point(656, 340);
            this.butTiensu.Name = "butTiensu";
            this.butTiensu.Size = new System.Drawing.Size(128, 19);
            this.butTiensu.TabIndex = 393;
            this.butTiensu.Text = "Nhập tiền sử sản khoa";
            this.butTiensu.Click += new System.EventHandler(this.butTiensu_Click);
            // 
            // label112
            // 
            this.label112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.Location = new System.Drawing.Point(8, 341);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(128, 16);
            this.label112.TabIndex = 315;
            this.label112.Text = "4. Tiền sử sản khoa :";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(16, 340);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 10;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(768, 84);
            this.dataGrid3.TabIndex = 321;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.SystemColors.Control;
            this.label92.Image = ((System.Drawing.Image)(resources.GetObject("label92.Image")));
            this.label92.Location = new System.Drawing.Point(87, 461);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(16, 16);
            this.label92.TabIndex = 265;
            this.label92.Click += new System.EventHandler(this.label92_Click);
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.SystemColors.Control;
            this.label97.Image = ((System.Drawing.Image)(resources.GetObject("label97.Image")));
            this.label97.Location = new System.Drawing.Point(87, 533);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(16, 16);
            this.label97.TabIndex = 267;
            this.label97.Click += new System.EventHandler(this.label97_Click);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Image = ((System.Drawing.Image)(resources.GetObject("label96.Image")));
            this.label96.Location = new System.Drawing.Point(87, 509);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(16, 16);
            this.label96.TabIndex = 266;
            this.label96.Click += new System.EventHandler(this.label96_Click);
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.SystemColors.Control;
            this.label95.Image = ((System.Drawing.Image)(resources.GetObject("label95.Image")));
            this.label95.Location = new System.Drawing.Point(87, 485);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(16, 16);
            this.label95.TabIndex = 265;
            this.label95.Click += new System.EventHandler(this.label95_Click);
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(16, 557);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(64, 16);
            this.label55.TabIndex = 320;
            this.label55.Text = "- Tiết niệu :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(16, 532);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 16);
            this.label54.TabIndex = 319;
            this.label54.Text = "- Tiêu hóa :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(16, 508);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(80, 16);
            this.label53.TabIndex = 318;
            this.label53.Text = "- Hô hấp :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(16, 485);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(80, 16);
            this.label52.TabIndex = 317;
            this.label52.Text = "- Tuần hoàn :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_toanthan
            // 
            this.kb_toanthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_toanthan.Enabled = false;
            this.kb_toanthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_toanthan.Location = new System.Drawing.Point(104, 459);
            this.kb_toanthan.Name = "kb_toanthan";
            this.kb_toanthan.Size = new System.Drawing.Size(472, 21);
            this.kb_toanthan.TabIndex = 23;
            this.kb_toanthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(16, 462);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 16);
            this.label37.TabIndex = 316;
            this.label37.Text = "- Toàn trạng :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chongtuoi
            // 
            this.chongtuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chongtuoi.Enabled = false;
            this.chongtuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chongtuoi.Location = new System.Drawing.Point(224, 316);
            this.chongtuoi.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chongtuoi.MaxLength = 5;
            this.chongtuoi.Name = "chongtuoi";
            this.chongtuoi.Size = new System.Drawing.Size(32, 21);
            this.chongtuoi.TabIndex = 21;
            this.chongtuoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chongtuoi.Validated += new System.EventHandler(this.chongtuoi_Validated);
            // 
            // kinhtuoi
            // 
            this.kinhtuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhtuoi.Enabled = false;
            this.kinhtuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhtuoi.Location = new System.Drawing.Point(224, 269);
            this.kinhtuoi.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.kinhtuoi.MaxLength = 5;
            this.kinhtuoi.Name = "kinhtuoi";
            this.kinhtuoi.Size = new System.Drawing.Size(32, 21);
            this.kinhtuoi.TabIndex = 16;
            this.kinhtuoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kinhtuoi.Validated += new System.EventHandler(this.kinhtuoi_Validated);
            // 
            // dadieutri
            // 
            this.dadieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dadieutri.Enabled = false;
            this.dadieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dadieutri.Location = new System.Drawing.Point(432, 316);
            this.dadieutri.Name = "dadieutri";
            this.dadieutri.Size = new System.Drawing.Size(352, 21);
            this.dadieutri.TabIndex = 22;
            this.dadieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label111
            // 
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.Location = new System.Drawing.Point(247, 317);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(184, 16);
            this.label111.TabIndex = 313;
            this.label111.Text = "Những bệnh phụ khoa đã điều trị :";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(184, 317);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(40, 16);
            this.label32.TabIndex = 312;
            this.label32.Text = "Tuổi :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chongnam
            // 
            this.chongnam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chongnam.Enabled = false;
            this.chongnam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chongnam.Location = new System.Drawing.Point(144, 316);
            this.chongnam.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chongnam.MaxLength = 5;
            this.chongnam.Name = "chongnam";
            this.chongnam.Size = new System.Drawing.Size(40, 21);
            this.chongnam.TabIndex = 20;
            this.chongnam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chongnam.Validated += new System.EventHandler(this.chongnam_Validated);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(16, 317);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 16);
            this.label33.TabIndex = 309;
            this.label33.Text = "- Lấy chồng năm :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luongkinh
            // 
            this.luongkinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.luongkinh.Enabled = false;
            this.luongkinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luongkinh.Location = new System.Drawing.Point(432, 293);
            this.luongkinh.Name = "luongkinh";
            this.luongkinh.Size = new System.Drawing.Size(352, 21);
            this.luongkinh.TabIndex = 19;
            this.luongkinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(351, 293);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 16);
            this.label30.TabIndex = 307;
            this.label30.Text = "Lượng kinh :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(191, 295);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(32, 16);
            this.label27.TabIndex = 306;
            this.label27.Text = "ngày ";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(16, 293);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 16);
            this.label26.TabIndex = 305;
            this.label26.Text = "- Chu kỳ :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tinhchat
            // 
            this.tinhchat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhchat.Enabled = false;
            this.tinhchat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhchat.Location = new System.Drawing.Point(432, 269);
            this.tinhchat.Name = "tinhchat";
            this.tinhchat.Size = new System.Drawing.Size(352, 21);
            this.tinhchat.TabIndex = 17;
            this.tinhchat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(303, 274);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 16);
            this.label25.TabIndex = 303;
            this.label25.Text = "Tính chất kinh nguyệt :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(184, 274);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 302;
            this.label24.Text = "Tuổi :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kinhnam
            // 
            this.kinhnam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kinhnam.Enabled = false;
            this.kinhnam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhnam.Location = new System.Drawing.Point(144, 269);
            this.kinhnam.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.kinhnam.MaxLength = 5;
            this.kinhnam.Name = "kinhnam";
            this.kinhnam.Size = new System.Drawing.Size(40, 21);
            this.kinhnam.TabIndex = 15;
            this.kinhnam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kinhnam.Validated += new System.EventHandler(this.kinhnam_Validated);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(16, 274);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 16);
            this.label23.TabIndex = 299;
            this.label23.Text = "- Bắt đầu thấy kinh năm :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 255);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 16);
            this.label22.TabIndex = 298;
            this.label22.Text = "3. Tiền sử phụ khoa :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bienchuyen
            // 
            this.bienchuyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bienchuyen.Enabled = false;
            this.bienchuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bienchuyen.Location = new System.Drawing.Point(616, 106);
            this.bienchuyen.Name = "bienchuyen";
            this.bienchuyen.Size = new System.Drawing.Size(168, 21);
            this.bienchuyen.TabIndex = 12;
            this.bienchuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // dauhieu
            // 
            this.dauhieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dauhieu.Enabled = false;
            this.dauhieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dauhieu.Location = new System.Drawing.Point(392, 106);
            this.dauhieu.Name = "dauhieu";
            this.dauhieu.Size = new System.Drawing.Size(152, 21);
            this.dauhieu.TabIndex = 11;
            this.dauhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(536, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 16);
            this.label21.TabIndex = 295;
            this.label21.Text = "Biến chuyển :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(296, 109);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 16);
            this.label20.TabIndex = 294;
            this.label20.Text = "Dấu hiệu lúc đầu :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giochuyenda
            // 
            this.giochuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giochuyenda.Enabled = false;
            this.giochuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giochuyenda.Location = new System.Drawing.Point(144, 106);
            this.giochuyenda.Mask = "##:##";
            this.giochuyenda.Name = "giochuyenda";
            this.giochuyenda.Size = new System.Drawing.Size(40, 21);
            this.giochuyenda.TabIndex = 9;
            this.giochuyenda.Text = "  :  ";
            this.giochuyenda.Validated += new System.EventHandler(this.giochuyenda_Validated);
            // 
            // ngaychuyenda
            // 
            this.ngaychuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaychuyenda.Enabled = false;
            this.ngaychuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaychuyenda.Location = new System.Drawing.Point(224, 106);
            this.ngaychuyenda.Mask = "##/##/####";
            this.ngaychuyenda.Name = "ngaychuyenda";
            this.ngaychuyenda.Size = new System.Drawing.Size(72, 21);
            this.ngaychuyenda.TabIndex = 10;
            this.ngaychuyenda.Text = "  /  /    ";
            this.ngaychuyenda.Validated += new System.EventHandler(this.ngaychuyenda_Validated);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(192, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 16);
            this.label19.TabIndex = 293;
            this.label19.Text = "ngày ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 16);
            this.label18.TabIndex = 285;
            this.label18.Text = "- Bắt đầu chuyển dạ từ :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label110
            // 
            this.label110.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.Location = new System.Drawing.Point(624, 85);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(32, 16);
            this.label110.TabIndex = 284;
            this.label110.Text = "lần";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tiem
            // 
            this.tiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tiem.Enabled = false;
            this.tiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiem.Location = new System.Drawing.Point(576, 82);
            this.tiem.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.tiem.MaxLength = 5;
            this.tiem.Name = "tiem";
            this.tiem.Size = new System.Drawing.Size(40, 21);
            this.tiem.TabIndex = 8;
            this.tiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label109
            // 
            this.label109.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.Location = new System.Drawing.Point(512, 85);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(64, 16);
            this.label109.TabIndex = 8;
            this.label109.Text = "Được tiêm :";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uonvan
            // 
            this.uonvan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uonvan.Enabled = false;
            this.uonvan.Location = new System.Drawing.Point(373, 85);
            this.uonvan.Name = "uonvan";
            this.uonvan.Size = new System.Drawing.Size(136, 16);
            this.uonvan.TabIndex = 7;
            this.uonvan.Text = "- Tiêm phòng uốn ván";
            this.uonvan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // khamthai
            // 
            this.khamthai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khamthai.Enabled = false;
            this.khamthai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khamthai.Location = new System.Drawing.Point(112, 82);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(252, 21);
            this.khamthai.TabIndex = 6;
            this.khamthai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label108
            // 
            this.label108.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label108.Location = new System.Drawing.Point(16, 85);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(88, 16);
            this.label108.TabIndex = 279;
            this.label108.Text = "- Khám thai tại :";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tuoithai
            // 
            this.tuoithai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoithai.Enabled = false;
            this.tuoithai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoithai.Location = new System.Drawing.Point(576, 58);
            this.tuoithai.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.tuoithai.MaxLength = 5;
            this.tuoithai.Name = "tuoithai";
            this.tuoithai.Size = new System.Drawing.Size(40, 21);
            this.tuoithai.TabIndex = 5;
            this.tuoithai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label107
            // 
            this.label107.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.Location = new System.Drawing.Point(624, 61);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(32, 16);
            this.label107.TabIndex = 277;
            this.label107.Text = "tuần";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label106
            // 
            this.label106.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(512, 61);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(64, 16);
            this.label106.TabIndex = 276;
            this.label106.Text = "Tuổi thai :";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Enabled = false;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(436, 58);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(72, 21);
            this.denngay.TabIndex = 4;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Enabled = false;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(292, 58);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(72, 21);
            this.tungay.TabIndex = 3;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label105
            // 
            this.label105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(372, 61);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(64, 16);
            this.label105.TabIndex = 273;
            this.label105.Text = "đến ngày :";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hb_giadinh
            // 
            this.hb_giadinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_giadinh.Enabled = false;
            this.hb_giadinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_giadinh.Location = new System.Drawing.Point(32, 218);
            this.hb_giadinh.Multiline = true;
            this.hb_giadinh.Name = "hb_giadinh";
            this.hb_giadinh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_giadinh.Size = new System.Drawing.Size(752, 32);
            this.hb_giadinh.TabIndex = 14;
            // 
            // hb_banthan
            // 
            this.hb_banthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_banthan.Enabled = false;
            this.hb_banthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_banthan.Location = new System.Drawing.Point(32, 165);
            this.hb_banthan.Multiline = true;
            this.hb_banthan.Name = "hb_banthan";
            this.hb_banthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_banthan.Size = new System.Drawing.Size(752, 32);
            this.hb_banthan.TabIndex = 13;
            // 
            // lydo
            // 
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(112, 21);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(504, 21);
            this.lydo.TabIndex = 0;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Enabled = false;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(701, 24);
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(40, 21);
            this.lanthu.TabIndex = 1;
            this.lanthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(741, 26);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(56, 16);
            this.label50.TabIndex = 101;
            this.label50.Text = "của bệnh ";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(621, 26);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(80, 16);
            this.label49.TabIndex = 100;
            this.label49.Text = "Vào ngày thứ :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cao);
            this.panel2.Controls.Add(this.label166);
            this.panel2.Controls.Add(this.label167);
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
            this.panel2.Location = new System.Drawing.Point(634, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 144);
            this.panel2.TabIndex = 29;
            // 
            // cao
            // 
            this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cao.Enabled = false;
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(64, 93);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(40, 21);
            this.cao.TabIndex = 4;
            this.cao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label166
            // 
            this.label166.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.Location = new System.Drawing.Point(113, 96);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(32, 16);
            this.label166.TabIndex = 22;
            this.label166.Text = "cm";
            this.label166.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label167
            // 
            this.label167.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.Location = new System.Drawing.Point(0, 96);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(64, 16);
            this.label167.TabIndex = 21;
            this.label167.Text = "Chiều cao :";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 2;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(64, 70);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
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
            this.cannang.Location = new System.Drawing.Point(64, 116);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 5;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(64, 2);
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
            this.label43.Location = new System.Drawing.Point(107, 118);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 16);
            this.label43.TabIndex = 19;
            this.label43.Text = "Kg";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(0, 119);
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
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(8, 443);
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
            this.label35.Location = new System.Drawing.Point(8, 426);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(107, 17);
            this.label35.TabIndex = 95;
            this.label35.Text = "III. Khám bệnh :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(16, 200);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(648, 16);
            this.label34.TabIndex = 94;
            this.label34.Text = "+ Gia đình :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(154, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "Kinh cuối cùng từ ngày :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(648, 16);
            this.label16.TabIndex = 66;
            this.label16.Text = "+ Bản thân : (những bệnh đã mắc, dị ứng, thói quen ăn uống, sinh hoạt, khác, ...)" +
                "";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(8, 130);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 16);
            this.label28.TabIndex = 65;
            this.label28.Text = "2. Tiền sử bệnh :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(8, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(152, 16);
            this.label29.TabIndex = 64;
            this.label29.Text = "1. Quá trình kỳ thai này :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(8, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 62;
            this.label15.Text = "II. Hỏi bệnh :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(8, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 61;
            this.label14.Text = "I. Lý do vào viện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(8, 5);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 17);
            this.label31.TabIndex = 60;
            this.label31.Text = "A. BỆNH ÁN :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chuky
            // 
            this.chuky.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chuky.Enabled = false;
            this.chuky.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuky.Location = new System.Drawing.Point(144, 293);
            this.chuky.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chuky.MaxLength = 5;
            this.chuky.Name = "chuky";
            this.chuky.Size = new System.Drawing.Size(40, 21);
            this.chuky.TabIndex = 18;
            this.chuky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Image = ((System.Drawing.Image)(resources.GetObject("label98.Image")));
            this.label98.Location = new System.Drawing.Point(87, 557);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(16, 16);
            this.label98.TabIndex = 268;
            this.label98.Click += new System.EventHandler(this.label98_Click);
            // 
            // kb_tuanhoan
            // 
            this.kb_tuanhoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tuanhoan.Enabled = false;
            this.kb_tuanhoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tuanhoan.Location = new System.Drawing.Point(104, 481);
            this.kb_tuanhoan.Name = "kb_tuanhoan";
            this.kb_tuanhoan.Size = new System.Drawing.Size(520, 21);
            this.kb_tuanhoan.TabIndex = 25;
            this.kb_tuanhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_hohap
            // 
            this.kb_hohap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_hohap.Enabled = false;
            this.kb_hohap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_hohap.Location = new System.Drawing.Point(104, 505);
            this.kb_hohap.Name = "kb_hohap";
            this.kb_hohap.Size = new System.Drawing.Size(520, 21);
            this.kb_hohap.TabIndex = 26;
            this.kb_hohap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_tieuhoa
            // 
            this.kb_tieuhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tieuhoa.Enabled = false;
            this.kb_tieuhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tieuhoa.Location = new System.Drawing.Point(104, 529);
            this.kb_tieuhoa.Name = "kb_tieuhoa";
            this.kb_tieuhoa.Size = new System.Drawing.Size(520, 21);
            this.kb_tieuhoa.TabIndex = 27;
            this.kb_tieuhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_than
            // 
            this.kb_than.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_than.Enabled = false;
            this.kb_than.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_than.Location = new System.Drawing.Point(104, 553);
            this.kb_than.Name = "kb_than";
            this.kb_than.Size = new System.Drawing.Size(520, 21);
            this.kb_than.TabIndex = 28;
            this.kb_than.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.ngayvk);
            this.tab3.Controls.Add(this.dieutri);
            this.tab3.Controls.Add(this.label130);
            this.tab3.Controls.Add(this.giovk);
            this.tab3.Controls.Add(this.label89);
            this.tab3.Controls.Add(this.label71);
            this.tab3.Controls.Add(this.label70);
            this.tab3.Controls.Add(this.tienluong);
            this.tab3.Controls.Add(this.label67);
            this.tab3.Controls.Add(this.label66);
            this.tab3.Controls.Add(this.label129);
            this.tab3.Controls.Add(this.have);
            this.tab3.Controls.Add(this.tinhtrangoi);
            this.tab3.Controls.Add(this.oivo);
            this.tab3.Controls.Add(this.dolot);
            this.tab3.Controls.Add(this.label128);
            this.tab3.Controls.Add(this.kieu);
            this.tab3.Controls.Add(this.the);
            this.tab3.Controls.Add(this.ngoi);
            this.tab3.Controls.Add(this.nuocoi);
            this.tab3.Controls.Add(this.mausac);
            this.tab3.Controls.Add(this.label127);
            this.tab3.Controls.Add(this.label126);
            this.tab3.Controls.Add(this.label125);
            this.tab3.Controls.Add(this.label124);
            this.tab3.Controls.Add(this.label123);
            this.tab3.Controls.Add(this.label122);
            this.tab3.Controls.Add(this.label121);
            this.tab3.Controls.Add(this.giovo);
            this.tab3.Controls.Add(this.ngayvo);
            this.tab3.Controls.Add(this.label119);
            this.tab3.Controls.Add(this.label120);
            this.tab3.Controls.Add(this.phanphu);
            this.tab3.Controls.Add(this.tucung);
            this.tab3.Controls.Add(this.label118);
            this.tab3.Controls.Add(this.label117);
            this.tab3.Controls.Add(this.label116);
            this.tab3.Controls.Add(this.sinhmon);
            this.tab3.Controls.Add(this.amdao);
            this.tab3.Controls.Add(this.amho);
            this.tab3.Controls.Add(this.label115);
            this.tab3.Controls.Add(this.label114);
            this.tab3.Controls.Add(this.label113);
            this.tab3.Controls.Add(this.label104);
            this.tab3.Controls.Add(this.bishop);
            this.tab3.Controls.Add(this.label103);
            this.tab3.Controls.Add(this.label102);
            this.tab3.Controls.Add(this.vu);
            this.tab3.Controls.Add(this.label101);
            this.tab3.Controls.Add(this.label100);
            this.tab3.Controls.Add(this.timthai);
            this.tab3.Controls.Add(this.label99);
            this.tab3.Controls.Add(this.cotc);
            this.tab3.Controls.Add(this.label94);
            this.tab3.Controls.Add(this.label61);
            this.tab3.Controls.Add(this.vongbung);
            this.tab3.Controls.Add(this.label60);
            this.tab3.Controls.Add(this.label59);
            this.tab3.Controls.Add(this.caotc);
            this.tab3.Controls.Add(this.label58);
            this.tab3.Controls.Add(this.tuthe);
            this.tab3.Controls.Add(this.dangtc);
            this.tab3.Controls.Add(this.label57);
            this.tab3.Controls.Add(this.ptcu);
            this.tab3.Controls.Add(this.label38);
            this.tab3.Controls.Add(this.label93);
            this.tab3.Controls.Add(this.label91);
            this.tab3.Controls.Add(this.stt2);
            this.tab3.Controls.Add(this.stt1);
            this.tab3.Controls.Add(this.chkHinh);
            this.tab3.Controls.Add(this.p2);
            this.tab3.Controls.Add(this.p1);
            this.tab3.Controls.Add(this.kb_khac);
            this.tab3.Controls.Add(this.label63);
            this.tab3.Controls.Add(this.label62);
            this.tab3.Controls.Add(this.label56);
            this.tab3.Controls.Add(this.label51);
            this.tab3.Controls.Add(this.dataGrid2);
            this.tab3.Controls.Add(this.listICD);
            this.tab3.Controls.Add(this.listNv);
            this.tab3.Controls.Add(this.label65);
            this.tab3.Controls.Add(this.icd_kkb);
            this.tab3.Controls.Add(this.cd_kkb);
            this.tab3.Controls.Add(this.phanbiet);
            this.tab3.Controls.Add(this.mabsnb);
            this.tab3.Controls.Add(this.tenbsnb);
            this.tab3.Controls.Add(this.tenbsnb_pass);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(811, 579);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Trang 3";
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Enabled = false;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(128, 531);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(72, 21);
            this.ngayvk.TabIndex = 31;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // dieutri
            // 
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Enabled = false;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(128, 494);
            this.dieutri.Multiline = true;
            this.dieutri.Name = "dieutri";
            this.dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dieutri.Size = new System.Drawing.Size(656, 35);
            this.dieutri.TabIndex = 30;
            // 
            // label130
            // 
            this.label130.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(16, 500);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(120, 16);
            this.label130.TabIndex = 347;
            this.label130.Text = "- Phương pháp chính :";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Enabled = false;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(230, 531);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(40, 21);
            this.giovk.TabIndex = 32;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(202, 533);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(32, 16);
            this.label89.TabIndex = 346;
            this.label89.Text = "Giờ :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(278, 533);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(120, 16);
            this.label71.TabIndex = 345;
            this.label71.Text = "Bác sĩ làm bệnh án :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(90, 533);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 16);
            this.label70.TabIndex = 344;
            this.label70.Text = "Ngày :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(128, 445);
            this.tienluong.Multiline = true;
            this.tienluong.Name = "tienluong";
            this.tienluong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tienluong.Size = new System.Drawing.Size(656, 35);
            this.tienluong.TabIndex = 29;
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(8, 480);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(136, 16);
            this.label67.TabIndex = 343;
            this.label67.Text = "7. Hướng điều trị :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(8, 450);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(136, 16);
            this.label66.TabIndex = 342;
            this.label66.Text = "6. Tiên lượng :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label129
            // 
            this.label129.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(8, 410);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(80, 16);
            this.label129.TabIndex = 341;
            this.label129.Text = "- Phân biệt :";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // have
            // 
            this.have.BackColor = System.Drawing.SystemColors.HighlightText;
            this.have.Enabled = false;
            this.have.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.have.Location = new System.Drawing.Point(512, 231);
            this.have.Name = "have";
            this.have.Size = new System.Drawing.Size(272, 21);
            this.have.TabIndex = 25;
            this.have.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tinhtrangoi
            // 
            this.tinhtrangoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrangoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrangoi.Enabled = false;
            this.tinhtrangoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrangoi.Items.AddRange(new object[] {
            "1. Ối phồng",
            "2. Ối dẹt",
            "3. Ối quả lê"});
            this.tinhtrangoi.Location = new System.Drawing.Point(512, 162);
            this.tinhtrangoi.Name = "tinhtrangoi";
            this.tinhtrangoi.Size = new System.Drawing.Size(112, 21);
            this.tinhtrangoi.TabIndex = 15;
            this.tinhtrangoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // oivo
            // 
            this.oivo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.oivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oivo.Enabled = false;
            this.oivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oivo.Items.AddRange(new object[] {
            "1. Tự nhiên",
            "2. Bấm ối"});
            this.oivo.Location = new System.Drawing.Point(328, 184);
            this.oivo.Name = "oivo";
            this.oivo.Size = new System.Drawing.Size(92, 21);
            this.oivo.TabIndex = 18;
            this.oivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // dolot
            // 
            this.dolot.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dolot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dolot.Enabled = false;
            this.dolot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dolot.Items.AddRange(new object[] {
            "1. Cao",
            "2. Chúc",
            "3. Chặt",
            "4. Lọt"});
            this.dolot.Location = new System.Drawing.Point(328, 232);
            this.dolot.Name = "dolot";
            this.dolot.Size = new System.Drawing.Size(64, 21);
            this.dolot.TabIndex = 24;
            this.dolot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label128
            // 
            this.label128.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(388, 232);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(124, 16);
            this.label128.TabIndex = 336;
            this.label128.Text = "Đường kính nhô hạ vệ :";
            this.label128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kieu
            // 
            this.kieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kieu.Enabled = false;
            this.kieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kieu.Location = new System.Drawing.Point(88, 231);
            this.kieu.Name = "kieu";
            this.kieu.Size = new System.Drawing.Size(198, 21);
            this.kieu.TabIndex = 23;
            this.kieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // the
            // 
            this.the.BackColor = System.Drawing.SystemColors.HighlightText;
            this.the.Enabled = false;
            this.the.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.the.Location = new System.Drawing.Point(512, 208);
            this.the.Name = "the";
            this.the.Size = new System.Drawing.Size(112, 21);
            this.the.TabIndex = 22;
            this.the.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // ngoi
            // 
            this.ngoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoi.Enabled = false;
            this.ngoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoi.Location = new System.Drawing.Point(328, 208);
            this.ngoi.Name = "ngoi";
            this.ngoi.Size = new System.Drawing.Size(152, 21);
            this.ngoi.TabIndex = 21;
            this.ngoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // nuocoi
            // 
            this.nuocoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nuocoi.Enabled = false;
            this.nuocoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuocoi.Location = new System.Drawing.Point(120, 208);
            this.nuocoi.Name = "nuocoi";
            this.nuocoi.Size = new System.Drawing.Size(166, 21);
            this.nuocoi.TabIndex = 20;
            this.nuocoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // mausac
            // 
            this.mausac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mausac.Enabled = false;
            this.mausac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mausac.Location = new System.Drawing.Point(512, 184);
            this.mausac.Name = "mausac";
            this.mausac.Size = new System.Drawing.Size(112, 21);
            this.mausac.TabIndex = 19;
            this.mausac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label127
            // 
            this.label127.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(280, 232);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(48, 16);
            this.label127.TabIndex = 330;
            this.label127.Text = "Độ lọt :";
            this.label127.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label126
            // 
            this.label126.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.Location = new System.Drawing.Point(8, 232);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(64, 16);
            this.label126.TabIndex = 329;
            this.label126.Text = "- Kiểu thế :";
            this.label126.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label125
            // 
            this.label125.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.Location = new System.Drawing.Point(472, 211);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(40, 16);
            this.label125.TabIndex = 328;
            this.label125.Text = "Thế :";
            this.label125.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label124
            // 
            this.label124.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.Location = new System.Drawing.Point(288, 211);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(40, 16);
            this.label124.TabIndex = 327;
            this.label124.Text = "Ngôi :";
            this.label124.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label123
            // 
            this.label123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.Location = new System.Drawing.Point(8, 211);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(120, 16);
            this.label123.TabIndex = 326;
            this.label123.Text = "- Nước ối nhiều hay ít :";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label122
            // 
            this.label122.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.Location = new System.Drawing.Point(416, 184);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(96, 16);
            this.label122.TabIndex = 325;
            this.label122.Text = "Mầu sắc nước ối :";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label121
            // 
            this.label121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(288, 186);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(40, 16);
            this.label121.TabIndex = 322;
            this.label121.Text = "Ối vỡ :";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovo
            // 
            this.giovo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovo.Enabled = false;
            this.giovo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovo.Location = new System.Drawing.Point(88, 185);
            this.giovo.Mask = "##:##";
            this.giovo.Name = "giovo";
            this.giovo.Size = new System.Drawing.Size(40, 21);
            this.giovo.TabIndex = 16;
            this.giovo.Text = "  :  ";
            this.giovo.Validated += new System.EventHandler(this.giovo_Validated);
            // 
            // ngayvo
            // 
            this.ngayvo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvo.Enabled = false;
            this.ngayvo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvo.Location = new System.Drawing.Point(213, 184);
            this.ngayvo.Mask = "##/##/####";
            this.ngayvo.Name = "ngayvo";
            this.ngayvo.Size = new System.Drawing.Size(72, 21);
            this.ngayvo.TabIndex = 17;
            this.ngayvo.Text = "  /  /    ";
            this.ngayvo.Validated += new System.EventHandler(this.ngayvo_Validated);
            // 
            // label119
            // 
            this.label119.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(176, 188);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(38, 16);
            this.label119.TabIndex = 321;
            this.label119.Text = "ngày :";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label120
            // 
            this.label120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.Location = new System.Drawing.Point(8, 188);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(72, 16);
            this.label120.TabIndex = 318;
            this.label120.Text = "- Ối vỡ lúc :";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phanphu
            // 
            this.phanphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanphu.Enabled = false;
            this.phanphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanphu.Location = new System.Drawing.Point(213, 162);
            this.phanphu.Name = "phanphu";
            this.phanphu.Size = new System.Drawing.Size(219, 21);
            this.phanphu.TabIndex = 14;
            this.phanphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tucung
            // 
            this.tucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tucung.Enabled = false;
            this.tucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tucung.Location = new System.Drawing.Point(88, 162);
            this.tucung.Name = "tucung";
            this.tucung.Size = new System.Drawing.Size(64, 21);
            this.tucung.TabIndex = 13;
            this.tucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label118
            // 
            this.label118.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(424, 166);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(88, 16);
            this.label118.TabIndex = 312;
            this.label118.Text = "Tình trạng ối :";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label117
            // 
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(150, 166);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(64, 16);
            this.label117.TabIndex = 311;
            this.label117.Text = "Phần phụ :";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label116
            // 
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(8, 166);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(112, 16);
            this.label116.TabIndex = 310;
            this.label116.Text = "- Cổ tử cung :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sinhmon
            // 
            this.sinhmon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sinhmon.Enabled = false;
            this.sinhmon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinhmon.Location = new System.Drawing.Point(512, 139);
            this.sinhmon.Name = "sinhmon";
            this.sinhmon.Size = new System.Drawing.Size(112, 21);
            this.sinhmon.TabIndex = 12;
            this.sinhmon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // amdao
            // 
            this.amdao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.amdao.Enabled = false;
            this.amdao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amdao.Location = new System.Drawing.Point(351, 139);
            this.amdao.Name = "amdao";
            this.amdao.Size = new System.Drawing.Size(80, 21);
            this.amdao.TabIndex = 11;
            this.amdao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // amho
            // 
            this.amho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.amho.Enabled = false;
            this.amho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amho.Location = new System.Drawing.Point(213, 139);
            this.amho.Name = "amho";
            this.amho.Size = new System.Drawing.Size(91, 21);
            this.amho.TabIndex = 10;
            this.amho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label115
            // 
            this.label115.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(424, 144);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(88, 16);
            this.label115.TabIndex = 306;
            this.label115.Text = "Tầng sinh môn :";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label114
            // 
            this.label114.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(296, 144);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(56, 16);
            this.label114.TabIndex = 305;
            this.label114.Text = "Âm đạo :";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label113
            // 
            this.label113.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.Location = new System.Drawing.Point(158, 144);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(56, 16);
            this.label113.TabIndex = 304;
            this.label113.Text = "Âm hộ :";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label104
            // 
            this.label104.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.Location = new System.Drawing.Point(128, 142);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(48, 16);
            this.label104.TabIndex = 303;
            this.label104.Text = "điểm";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bishop
            // 
            this.bishop.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bishop.Enabled = false;
            this.bishop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bishop.Location = new System.Drawing.Point(88, 139);
            this.bishop.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.bishop.MaxLength = 5;
            this.bishop.Name = "bishop";
            this.bishop.Size = new System.Drawing.Size(38, 21);
            this.bishop.TabIndex = 9;
            this.bishop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label103
            // 
            this.label103.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label103.Location = new System.Drawing.Point(8, 144);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(96, 16);
            this.label103.TabIndex = 301;
            this.label103.Text = "- Chỉ số Bishop :";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label102
            // 
            this.label102.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.Location = new System.Drawing.Point(8, 120);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(104, 16);
            this.label102.TabIndex = 300;
            this.label102.Text = "3. Khám trong :";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vu
            // 
            this.vu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vu.Enabled = false;
            this.vu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vu.Location = new System.Drawing.Point(264, 95);
            this.vu.Name = "vu";
            this.vu.Size = new System.Drawing.Size(360, 21);
            this.vu.TabIndex = 8;
            this.vu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label101
            // 
            this.label101.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.Location = new System.Drawing.Point(175, 96);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(90, 16);
            this.label101.TabIndex = 298;
            this.label101.Text = "- Vú :";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label100
            // 
            this.label100.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(131, 96);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(48, 16);
            this.label100.TabIndex = 297;
            this.label100.Text = "lần/phút";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timthai
            // 
            this.timthai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timthai.Enabled = false;
            this.timthai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timthai.Location = new System.Drawing.Point(88, 95);
            this.timthai.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.timthai.MaxLength = 5;
            this.timthai.Name = "timthai";
            this.timthai.Size = new System.Drawing.Size(40, 21);
            this.timthai.TabIndex = 7;
            this.timthai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label99
            // 
            this.label99.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.Location = new System.Drawing.Point(8, 96);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(64, 16);
            this.label99.TabIndex = 295;
            this.label99.Text = "- Tim thai :";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cotc
            // 
            this.cotc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cotc.Enabled = false;
            this.cotc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotc.Location = new System.Drawing.Point(471, 72);
            this.cotc.Name = "cotc";
            this.cotc.Size = new System.Drawing.Size(153, 21);
            this.cotc.TabIndex = 6;
            this.cotc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label94
            // 
            this.label94.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(360, 74);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(112, 16);
            this.label94.TabIndex = 293;
            this.label94.Text = "- Cơn co TC :";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(304, 74);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(32, 16);
            this.label61.TabIndex = 292;
            this.label61.Text = "cm";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vongbung
            // 
            this.vongbung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vongbung.Enabled = false;
            this.vongbung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongbung.Location = new System.Drawing.Point(264, 72);
            this.vongbung.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vongbung.MaxLength = 5;
            this.vongbung.Name = "vongbung";
            this.vongbung.Size = new System.Drawing.Size(40, 21);
            this.vongbung.TabIndex = 5;
            this.vongbung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(175, 74);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(90, 16);
            this.label60.TabIndex = 290;
            this.label60.Text = ", vòng bụng :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(131, 74);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(32, 16);
            this.label59.TabIndex = 289;
            this.label59.Text = "cm";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // caotc
            // 
            this.caotc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.caotc.Enabled = false;
            this.caotc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caotc.Location = new System.Drawing.Point(88, 72);
            this.caotc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.caotc.MaxLength = 5;
            this.caotc.Name = "caotc";
            this.caotc.Size = new System.Drawing.Size(40, 21);
            this.caotc.TabIndex = 4;
            this.caotc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(8, 74);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(88, 16);
            this.label58.TabIndex = 287;
            this.label58.Text = "- Chiều cao TC :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tuthe
            // 
            this.tuthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuthe.Enabled = false;
            this.tuthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuthe.Location = new System.Drawing.Point(471, 50);
            this.tuthe.Name = "tuthe";
            this.tuthe.Size = new System.Drawing.Size(153, 21);
            this.tuthe.TabIndex = 3;
            this.tuthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // dangtc
            // 
            this.dangtc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dangtc.Enabled = false;
            this.dangtc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangtc.Location = new System.Drawing.Point(264, 50);
            this.dangtc.Name = "dangtc";
            this.dangtc.Size = new System.Drawing.Size(160, 21);
            this.dangtc.TabIndex = 2;
            this.dangtc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(392, 52);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(80, 16);
            this.label57.TabIndex = 284;
            this.label57.Text = "Tư thế :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptcu
            // 
            this.ptcu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ptcu.Enabled = false;
            this.ptcu.Location = new System.Drawing.Point(8, 53);
            this.ptcu.Name = "ptcu";
            this.ptcu.Size = new System.Drawing.Size(168, 16);
            this.ptcu.TabIndex = 1;
            this.ptcu.Text = "- Bụng có sẹo phẫu thuật cũ";
            this.ptcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(175, 52);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(90, 16);
            this.label38.TabIndex = 282;
            this.label38.Text = "- Hình dạng TC :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label93
            // 
            this.label93.Location = new System.Drawing.Point(536, 120);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(24, 16);
            this.label93.TabIndex = 281;
            this.label93.Text = "2 :";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label91
            // 
            this.label91.Location = new System.Drawing.Point(535, 30);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(24, 16);
            this.label91.TabIndex = 280;
            this.label91.Text = "1 :";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt2
            // 
            this.stt2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stt2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt2.Location = new System.Drawing.Point(560, 117);
            this.stt2.Name = "stt2";
            this.stt2.Size = new System.Drawing.Size(64, 21);
            this.stt2.TabIndex = 279;
            this.stt2.SelectedIndexChanged += new System.EventHandler(this.stt2_SelectedIndexChanged);
            // 
            // stt1
            // 
            this.stt1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stt1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt1.Location = new System.Drawing.Point(560, 28);
            this.stt1.Name = "stt1";
            this.stt1.Size = new System.Drawing.Size(64, 21);
            this.stt1.TabIndex = 278;
            this.stt1.SelectedIndexChanged += new System.EventHandler(this.stt1_SelectedIndexChanged);
            // 
            // chkHinh
            // 
            this.chkHinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkHinh.Location = new System.Drawing.Point(472, 32);
            this.chkHinh.Name = "chkHinh";
            this.chkHinh.Size = new System.Drawing.Size(48, 16);
            this.chkHinh.TabIndex = 277;
            this.chkHinh.Text = "Hình";
            this.chkHinh.CheckedChanged += new System.EventHandler(this.chkHinh_CheckedChanged);
            // 
            // p2
            // 
            this.p2.AutoScroll = true;
            this.p2.Controls.Add(this.pic2);
            this.p2.Location = new System.Drawing.Point(632, 144);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(152, 86);
            this.p2.TabIndex = 276;
            // 
            // p1
            // 
            this.p1.AutoScroll = true;
            this.p1.Controls.Add(this.pic1);
            this.p1.Location = new System.Drawing.Point(632, 32);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(152, 86);
            this.p1.TabIndex = 275;
            // 
            // kb_khac
            // 
            this.kb_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_khac.Enabled = false;
            this.kb_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_khac.Location = new System.Drawing.Point(118, 5);
            this.kb_khac.Name = "kb_khac";
            this.kb_khac.Size = new System.Drawing.Size(666, 21);
            this.kb_khac.TabIndex = 0;
            this.kb_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(8, 370);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(136, 16);
            this.label63.TabIndex = 110;
            this.label63.Text = "5. Chẩn đoán :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(8, 256);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(272, 16);
            this.label62.TabIndex = 109;
            this.label62.Text = "4. Các xét nghiệm cận lâm sàng cần làm :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(8, 8);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(112, 16);
            this.label56.TabIndex = 103;
            this.label56.Text = "- Các bộ phận khác :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(8, 33);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(136, 16);
            this.label51.TabIndex = 98;
            this.label51.Text = "2. Khám ngoài :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid2.Location = new System.Drawing.Point(22, 254);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(760, 109);
            this.dataGrid2.TabIndex = 260;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(168, 32);
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
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(256, 32);
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
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(8, 390);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(80, 16);
            this.label65.TabIndex = 100;
            this.label65.Text = "- Khi vào khoa :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // icd_kkb
            // 
            this.icd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Enabled = false;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(128, 386);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(59, 21);
            this.icd_kkb.TabIndex = 26;
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // cd_kkb
            // 
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Enabled = false;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(188, 386);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(596, 21);
            this.cd_kkb.TabIndex = 27;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // phanbiet
            // 
            this.phanbiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanbiet.Enabled = false;
            this.phanbiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanbiet.Location = new System.Drawing.Point(128, 408);
            this.phanbiet.Multiline = true;
            this.phanbiet.Name = "phanbiet";
            this.phanbiet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.phanbiet.Size = new System.Drawing.Size(656, 35);
            this.phanbiet.TabIndex = 28;
            // 
            // mabsnb
            // 
            this.mabsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsnb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabsnb.Enabled = false;
            this.mabsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsnb.Location = new System.Drawing.Point(398, 531);
            this.mabsnb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabsnb.MaxLength = 9;
            this.mabsnb.Name = "mabsnb";
            this.mabsnb.Size = new System.Drawing.Size(36, 21);
            this.mabsnb.TabIndex = 33;
            this.mabsnb.Validated += new System.EventHandler(this.mabsnb_Validated);
            this.mabsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tenbsnb
            // 
            this.tenbsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb.Enabled = false;
            this.tenbsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb.Location = new System.Drawing.Point(436, 531);
            this.tenbsnb.Name = "tenbsnb";
            this.tenbsnb.Size = new System.Drawing.Size(266, 21);
            this.tenbsnb.TabIndex = 34;
            this.tenbsnb.TextChanged += new System.EventHandler(this.tenbsnb_TextChanged);
            this.tenbsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // tab4
            // 
            this.tab4.Controls.Add(this.label168);
            this.tab4.Controls.Add(this.ngaysaude);
            this.tab4.Controls.Add(this.giosaude);
            this.tab4.Controls.Add(this.butTresosinh);
            this.tab4.Controls.Add(this.bienchung);
            this.tab4.Controls.Add(this.taibien);
            this.tab4.Controls.Add(this.label164);
            this.tab4.Controls.Add(this.chandoan_s);
            this.tab4.Controls.Add(this.chandoan_t);
            this.tab4.Controls.Add(this.label76);
            this.tab4.Controls.Add(this.label75);
            this.tab4.Controls.Add(this.label163);
            this.tab4.Controls.Add(this.label162);
            this.tab4.Controls.Add(this.label73);
            this.tab4.Controls.Add(this.cotucung);
            this.tab4.Controls.Add(this.label161);
            this.tab4.Controls.Add(this.loaichi);
            this.tab4.Controls.Add(this.somui);
            this.tab4.Controls.Add(this.tangsinhmon);
            this.tab4.Controls.Add(this.label160);
            this.tab4.Controls.Add(this.label159);
            this.tab4.Controls.Add(this.label154);
            this.tab4.Controls.Add(this.ppde);
            this.tab4.Controls.Add(this.canthiep);
            this.tab4.Controls.Add(this.label153);
            this.tab4.Controls.Add(this.panel3);
            this.tab4.Controls.Add(this.label148);
            this.tab4.Controls.Add(this.da);
            this.tab4.Controls.Add(this.label147);
            this.tab4.Controls.Add(this.label146);
            this.tab4.Controls.Add(this.xuly);
            this.tab4.Controls.Add(this.label145);
            this.tab4.Controls.Add(this.kiemsoattc);
            this.tab4.Controls.Add(this.label144);
            this.tab4.Controls.Add(this.maumat);
            this.tab4.Controls.Add(this.label143);
            this.tab4.Controls.Add(this.chaymau);
            this.tab4.Controls.Add(this.label142);
            this.tab4.Controls.Add(this.raudai);
            this.tab4.Controls.Add(this.label141);
            this.tab4.Controls.Add(this.banhrau);
            this.tab4.Controls.Add(this.mui);
            this.tab4.Controls.Add(this.mang);
            this.tab4.Controls.Add(this.cachso);
            this.tab4.Controls.Add(this.raucannang);
            this.tab4.Controls.Add(this.raucuon);
            this.tab4.Controls.Add(this.label140);
            this.tab4.Controls.Add(this.label139);
            this.tab4.Controls.Add(this.label138);
            this.tab4.Controls.Add(this.label137);
            this.tab4.Controls.Add(this.label74);
            this.tab4.Controls.Add(this.label136);
            this.tab4.Controls.Add(this.ngayrau);
            this.tab4.Controls.Add(this.giorau);
            this.tab4.Controls.Add(this.label72);
            this.tab4.Controls.Add(this.label135);
            this.tab4.Controls.Add(this.rau);
            this.tab4.Controls.Add(this.label69);
            this.tab4.Controls.Add(this.label68);
            this.tab4.Controls.Add(this.chucdanh);
            this.tab4.Controls.Add(this.ngayde);
            this.tab4.Controls.Add(this.tentheodoi);
            this.tab4.Controls.Add(this.theodoi);
            this.tab4.Controls.Add(this.listNv1);
            this.tab4.Controls.Add(this.label134);
            this.tab4.Controls.Add(this.label133);
            this.tab4.Controls.Add(this.giode);
            this.tab4.Controls.Add(this.label131);
            this.tab4.Controls.Add(this.label132);
            this.tab4.Controls.Add(this.tenbs_pass);
            this.tab4.Controls.Add(this.giorv);
            this.tab4.Controls.Add(this.ngayrv);
            this.tab4.Controls.Add(this.label88);
            this.tab4.Controls.Add(this.label90);
            this.tab4.Controls.Add(this.nguoinhan);
            this.tab4.Controls.Add(this.manguoinhan);
            this.tab4.Controls.Add(this.nguoigiao);
            this.tab4.Controls.Add(this.manguoigiao);
            this.tab4.Controls.Add(this.tenbs);
            this.tab4.Controls.Add(this.mabs);
            this.tab4.Controls.Add(this.label87);
            this.tab4.Controls.Add(this.label86);
            this.tab4.Controls.Add(this.label85);
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
            this.tab4.Controls.Add(this.label77);
            this.tab4.Controls.Add(this.label64);
            this.tab4.Controls.Add(this.dataGrid1);
            this.tab4.Controls.Add(this.panel9);
            this.tab4.Controls.Add(this.dataGrid4);
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(811, 579);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Trang 4";
            // 
            // label168
            // 
            this.label168.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.Location = new System.Drawing.Point(176, 237);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(38, 16);
            this.label168.TabIndex = 395;
            this.label168.Text = "ngày :";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysaude
            // 
            this.ngaysaude.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysaude.Enabled = false;
            this.ngaysaude.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysaude.Location = new System.Drawing.Point(216, 234);
            this.ngaysaude.Mask = "##/##/####";
            this.ngaysaude.Name = "ngaysaude";
            this.ngaysaude.Size = new System.Drawing.Size(72, 21);
            this.ngaysaude.TabIndex = 19;
            this.ngaysaude.Text = "  /  /    ";
            this.ngaysaude.Validated += new System.EventHandler(this.ngaysaude_Validated);
            // 
            // giosaude
            // 
            this.giosaude.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giosaude.Enabled = false;
            this.giosaude.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giosaude.Location = new System.Drawing.Point(289, 234);
            this.giosaude.Mask = "##:##";
            this.giosaude.Name = "giosaude";
            this.giosaude.Size = new System.Drawing.Size(40, 21);
            this.giosaude.TabIndex = 20;
            this.giosaude.Text = "  :  ";
            this.giosaude.Validated += new System.EventHandler(this.giosaude_Validated);
            // 
            // butTresosinh
            // 
            this.butTresosinh.Enabled = false;
            this.butTresosinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butTresosinh.Location = new System.Drawing.Point(688, 45);
            this.butTresosinh.Name = "butTresosinh";
            this.butTresosinh.Size = new System.Drawing.Size(96, 19);
            this.butTresosinh.TabIndex = 392;
            this.butTresosinh.Text = "Nhập trẻ sơ sinh";
            this.butTresosinh.Click += new System.EventHandler(this.butTresosinh_Click);
            // 
            // bienchung
            // 
            this.bienchung.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bienchung.Enabled = false;
            this.bienchung.Location = new System.Drawing.Point(232, 419);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(96, 16);
            this.bienchung.TabIndex = 32;
            this.bienchung.Text = "2. Biến chứng";
            this.bienchung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taibien.Enabled = false;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Items.AddRange(new object[] {
            "1. Không rách",
            "2. Rách"});
            this.taibien.Location = new System.Drawing.Point(96, 416);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(94, 21);
            this.taibien.TabIndex = 31;
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label164
            // 
            this.label164.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label164.Location = new System.Drawing.Point(16, 419);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(88, 15);
            this.label164.TabIndex = 389;
            this.label164.Text = "1. Tai biến PT :";
            this.label164.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chandoan_s
            // 
            this.chandoan_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan_s.Enabled = false;
            this.chandoan_s.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan_s.Location = new System.Drawing.Point(552, 343);
            this.chandoan_s.Name = "chandoan_s";
            this.chandoan_s.Size = new System.Drawing.Size(232, 21);
            this.chandoan_s.TabIndex = 30;
            this.chandoan_s.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // chandoan_t
            // 
            this.chandoan_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan_t.Enabled = false;
            this.chandoan_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan_t.Location = new System.Drawing.Point(168, 343);
            this.chandoan_t.Name = "chandoan_t";
            this.chandoan_t.Size = new System.Drawing.Size(232, 21);
            this.chandoan_t.TabIndex = 29;
            this.chandoan_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(408, 348);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(168, 15);
            this.label76.TabIndex = 386;
            this.label76.Text = "- Chẩn đoán sau phẫu thuật :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(16, 348);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(168, 15);
            this.label75.TabIndex = 385;
            this.label75.Text = "- Chẩn đoán trước phẫu thuật :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label163
            // 
            this.label163.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label163.Location = new System.Drawing.Point(144, 327);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(88, 16);
            this.label163.TabIndex = 384;
            this.label163.Text = "(nếu có) :";
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label162
            // 
            this.label162.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label162.Location = new System.Drawing.Point(8, 327);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(176, 16);
            this.label162.TabIndex = 383;
            this.label162.Text = "4. Tình hình phẫu thuật";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(8, 48);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(144, 16);
            this.label73.TabIndex = 118;
            this.label73.Text = "1. Đặc điểm trẻ sơ sinh :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cotucung
            // 
            this.cotucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cotucung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cotucung.Enabled = false;
            this.cotucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotucung.Items.AddRange(new object[] {
            "1. Không rách",
            "2. Rách"});
            this.cotucung.Location = new System.Drawing.Point(296, 302);
            this.cotucung.Name = "cotucung";
            this.cotucung.Size = new System.Drawing.Size(328, 21);
            this.cotucung.TabIndex = 27;
            this.cotucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label161
            // 
            this.label161.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.Location = new System.Drawing.Point(202, 303);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(96, 16);
            this.label161.TabIndex = 380;
            this.label161.Text = "Cổ tử cung :";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaichi
            // 
            this.loaichi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaichi.Enabled = false;
            this.loaichi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaichi.Location = new System.Drawing.Point(408, 279);
            this.loaichi.Name = "loaichi";
            this.loaichi.Size = new System.Drawing.Size(216, 21);
            this.loaichi.TabIndex = 25;
            this.loaichi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // somui
            // 
            this.somui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.somui.Enabled = false;
            this.somui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.somui.Location = new System.Drawing.Point(120, 302);
            this.somui.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.somui.MaxLength = 5;
            this.somui.Name = "somui";
            this.somui.Size = new System.Drawing.Size(40, 21);
            this.somui.TabIndex = 26;
            this.somui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tangsinhmon
            // 
            this.tangsinhmon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tangsinhmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tangsinhmon.Enabled = false;
            this.tangsinhmon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tangsinhmon.Items.AddRange(new object[] {
            "1. Không rách",
            "2. Rách",
            "3. Cắt"});
            this.tangsinhmon.Location = new System.Drawing.Point(120, 279);
            this.tangsinhmon.Name = "tangsinhmon";
            this.tangsinhmon.Size = new System.Drawing.Size(94, 21);
            this.tangsinhmon.TabIndex = 24;
            this.tangsinhmon.SelectedIndexChanged += new System.EventHandler(this.tangsinhmon_SelectedIndexChanged);
            this.tangsinhmon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label160
            // 
            this.label160.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.Location = new System.Drawing.Point(16, 303);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(88, 16);
            this.label160.TabIndex = 377;
            this.label160.Text = "- Số mũi khâu :";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label159
            // 
            this.label159.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label159.Location = new System.Drawing.Point(191, 282);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(216, 16);
            this.label159.TabIndex = 376;
            this.label159.Text = "Nếu có, phương pháp khâu và loại chỉ :";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label154
            // 
            this.label154.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.Location = new System.Drawing.Point(16, 282);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(96, 16);
            this.label154.TabIndex = 374;
            this.label154.Text = "- Tầng sinh môn :";
            this.label154.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ppde
            // 
            this.ppde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ppde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ppde.Enabled = false;
            this.ppde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppde.Location = new System.Drawing.Point(120, 256);
            this.ppde.Name = "ppde";
            this.ppde.Size = new System.Drawing.Size(94, 21);
            this.ppde.TabIndex = 22;
            this.ppde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // canthiep
            // 
            this.canthiep.BackColor = System.Drawing.SystemColors.HighlightText;
            this.canthiep.Enabled = false;
            this.canthiep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canthiep.Location = new System.Drawing.Point(296, 256);
            this.canthiep.Name = "canthiep";
            this.canthiep.Size = new System.Drawing.Size(328, 21);
            this.canthiep.TabIndex = 23;
            this.canthiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label153
            // 
            this.label153.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label153.Location = new System.Drawing.Point(202, 258);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(96, 16);
            this.label153.TabIndex = 372;
            this.label153.Text = "Lý do can thiệp :";
            this.label153.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.sd_nhietdo);
            this.panel3.Controls.Add(this.sd_huyetap);
            this.panel3.Controls.Add(this.sd_nhiptho);
            this.panel3.Controls.Add(this.sd_mach);
            this.panel3.Controls.Add(this.label149);
            this.panel3.Controls.Add(this.label150);
            this.panel3.Controls.Add(this.label151);
            this.panel3.Controls.Add(this.label152);
            this.panel3.Controls.Add(this.label155);
            this.panel3.Controls.Add(this.label156);
            this.panel3.Controls.Add(this.label157);
            this.panel3.Controls.Add(this.label158);
            this.panel3.Location = new System.Drawing.Point(632, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(152, 95);
            this.panel3.TabIndex = 28;
            // 
            // sd_nhietdo
            // 
            this.sd_nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_nhietdo.Enabled = false;
            this.sd_nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_nhietdo.Location = new System.Drawing.Point(64, 25);
            this.sd_nhietdo.Mask = "##.##";
            this.sd_nhietdo.Name = "sd_nhietdo";
            this.sd_nhietdo.Size = new System.Drawing.Size(32, 21);
            this.sd_nhietdo.TabIndex = 1;
            this.sd_nhietdo.Text = "  .  ";
            // 
            // sd_huyetap
            // 
            this.sd_huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_huyetap.Enabled = false;
            this.sd_huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_huyetap.Location = new System.Drawing.Point(64, 48);
            this.sd_huyetap.Mask = "###/###";
            this.sd_huyetap.Name = "sd_huyetap";
            this.sd_huyetap.Size = new System.Drawing.Size(45, 21);
            this.sd_huyetap.TabIndex = 2;
            this.sd_huyetap.Text = "   /   ";
            // 
            // sd_nhiptho
            // 
            this.sd_nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_nhiptho.Enabled = false;
            this.sd_nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_nhiptho.Location = new System.Drawing.Point(64, 70);
            this.sd_nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sd_nhiptho.MaxLength = 5;
            this.sd_nhiptho.Name = "sd_nhiptho";
            this.sd_nhiptho.Size = new System.Drawing.Size(32, 21);
            this.sd_nhiptho.TabIndex = 3;
            this.sd_nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sd_mach
            // 
            this.sd_mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sd_mach.Enabled = false;
            this.sd_mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_mach.Location = new System.Drawing.Point(64, 2);
            this.sd_mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sd_mach.MaxLength = 5;
            this.sd_mach.Name = "sd_mach";
            this.sd_mach.Size = new System.Drawing.Size(32, 21);
            this.sd_mach.TabIndex = 0;
            this.sd_mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label149
            // 
            this.label149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(99, 4);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(48, 19);
            this.label149.TabIndex = 11;
            this.label149.Text = "lần/phút";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.Location = new System.Drawing.Point(96, 29);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 13;
            this.label150.Text = "°C";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(112, 48);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(38, 16);
            this.label151.TabIndex = 16;
            this.label151.Text = "mmHg";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.Location = new System.Drawing.Point(99, 73);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(48, 16);
            this.label152.TabIndex = 18;
            this.label152.Text = "lần/phút";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label155
            // 
            this.label155.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(8, 74);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(56, 16);
            this.label155.TabIndex = 6;
            this.label155.Text = "Nhịp thở :";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label156
            // 
            this.label156.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(0, 53);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(64, 16);
            this.label156.TabIndex = 5;
            this.label156.Text = "Huyết áp :";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label157
            // 
            this.label157.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(8, 29);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(56, 16);
            this.label157.TabIndex = 4;
            this.label157.Text = "Nhiệt độ :";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(24, 5);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(40, 16);
            this.label158.TabIndex = 3;
            this.label158.Text = "Mạch :";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label148
            // 
            this.label148.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(16, 259);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(112, 15);
            this.label148.TabIndex = 369;
            this.label148.Text = "- Phương pháp đẻ :";
            this.label148.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // da
            // 
            this.da.BackColor = System.Drawing.SystemColors.HighlightText;
            this.da.Enabled = false;
            this.da.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.da.Location = new System.Drawing.Point(408, 234);
            this.da.Name = "da";
            this.da.Size = new System.Drawing.Size(216, 21);
            this.da.TabIndex = 21;
            this.da.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label147
            // 
            this.label147.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.Location = new System.Drawing.Point(312, 237);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(96, 16);
            this.label147.TabIndex = 367;
            this.label147.Text = "Da, niêm mạc :";
            this.label147.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label146
            // 
            this.label146.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.Location = new System.Drawing.Point(8, 237);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(176, 16);
            this.label146.TabIndex = 366;
            this.label146.Text = "3. Tình trạng sản phụ sau đẻ :";
            this.label146.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xuly
            // 
            this.xuly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xuly.Enabled = false;
            this.xuly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuly.Location = new System.Drawing.Point(120, 211);
            this.xuly.Name = "xuly";
            this.xuly.Size = new System.Drawing.Size(664, 21);
            this.xuly.TabIndex = 18;
            this.xuly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label145
            // 
            this.label145.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.Location = new System.Drawing.Point(16, 215);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(112, 15);
            this.label145.TabIndex = 364;
            this.label145.Text = "- Xử lý và kết quả :";
            this.label145.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kiemsoattc
            // 
            this.kiemsoattc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kiemsoattc.Enabled = false;
            this.kiemsoattc.Location = new System.Drawing.Point(444, 191);
            this.kiemsoattc.Name = "kiemsoattc";
            this.kiemsoattc.Size = new System.Drawing.Size(114, 16);
            this.kiemsoattc.TabIndex = 17;
            this.kiemsoattc.Text = "Kiểm soát tử cung ";
            this.kiemsoattc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label144
            // 
            this.label144.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.Location = new System.Drawing.Point(388, 190);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(38, 16);
            this.label144.TabIndex = 362;
            this.label144.Text = "ml";
            this.label144.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maumat
            // 
            this.maumat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maumat.Enabled = false;
            this.maumat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maumat.Location = new System.Drawing.Point(344, 188);
            this.maumat.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.maumat.MaxLength = 5;
            this.maumat.Name = "maumat";
            this.maumat.Size = new System.Drawing.Size(40, 21);
            this.maumat.TabIndex = 16;
            this.maumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label143
            // 
            this.label143.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.Location = new System.Drawing.Point(216, 191);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(128, 16);
            this.label143.TabIndex = 360;
            this.label143.Text = "Nếu có lượng máu mất :";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chaymau
            // 
            this.chaymau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chaymau.Enabled = false;
            this.chaymau.Location = new System.Drawing.Point(16, 191);
            this.chaymau.Name = "chaymau";
            this.chaymau.Size = new System.Drawing.Size(133, 16);
            this.chaymau.TabIndex = 15;
            this.chaymau.Text = "- Có chảy máu sau sổ";
            this.chaymau.CheckedChanged += new System.EventHandler(this.chaymau_CheckedChanged);
            this.chaymau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label142
            // 
            this.label142.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(728, 167);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(38, 16);
            this.label142.TabIndex = 358;
            this.label142.Text = "cm";
            this.label142.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // raudai
            // 
            this.raudai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.raudai.Enabled = false;
            this.raudai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raudai.Location = new System.Drawing.Point(688, 165);
            this.raudai.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.raudai.MaxLength = 5;
            this.raudai.Name = "raudai";
            this.raudai.Size = new System.Drawing.Size(40, 21);
            this.raudai.TabIndex = 14;
            this.raudai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label141
            // 
            this.label141.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(600, 167);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(88, 16);
            this.label141.TabIndex = 356;
            this.label141.Text = "Cuống rau dài :";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // banhrau
            // 
            this.banhrau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.banhrau.Enabled = false;
            this.banhrau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banhrau.Location = new System.Drawing.Point(120, 165);
            this.banhrau.Name = "banhrau";
            this.banhrau.Size = new System.Drawing.Size(152, 21);
            this.banhrau.TabIndex = 11;
            this.banhrau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // mui
            // 
            this.mui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mui.Enabled = false;
            this.mui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mui.Location = new System.Drawing.Point(688, 143);
            this.mui.Name = "mui";
            this.mui.Size = new System.Drawing.Size(96, 21);
            this.mui.TabIndex = 10;
            this.mui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // mang
            // 
            this.mang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mang.Enabled = false;
            this.mang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mang.Location = new System.Drawing.Point(544, 143);
            this.mang.Name = "mang";
            this.mang.Size = new System.Drawing.Size(96, 21);
            this.mang.TabIndex = 9;
            this.mang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // cachso
            // 
            this.cachso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachso.Enabled = false;
            this.cachso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachso.Location = new System.Drawing.Point(344, 143);
            this.cachso.Name = "cachso";
            this.cachso.Size = new System.Drawing.Size(144, 21);
            this.cachso.TabIndex = 8;
            this.cachso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // raucannang
            // 
            this.raucannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.raucannang.Enabled = false;
            this.raucannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raucannang.Location = new System.Drawing.Point(344, 165);
            this.raucannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.raucannang.MaxLength = 5;
            this.raucannang.Name = "raucannang";
            this.raucannang.Size = new System.Drawing.Size(40, 21);
            this.raucannang.TabIndex = 12;
            this.raucannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // raucuon
            // 
            this.raucuon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.raucuon.Enabled = false;
            this.raucuon.Location = new System.Drawing.Point(468, 167);
            this.raucuon.Name = "raucuon";
            this.raucuon.Size = new System.Drawing.Size(90, 16);
            this.raucuon.TabIndex = 13;
            this.raucuon.Text = "Rau cuốn cổ";
            this.raucuon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label140
            // 
            this.label140.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(384, 167);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(38, 16);
            this.label140.TabIndex = 349;
            this.label140.Text = "gram";
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label139
            // 
            this.label139.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(272, 167);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(72, 16);
            this.label139.TabIndex = 348;
            this.label139.Text = "Cân nặng :";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label138
            // 
            this.label138.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(16, 167);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(72, 16);
            this.label138.TabIndex = 347;
            this.label138.Text = "- Bánh rau :";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label137
            // 
            this.label137.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.Location = new System.Drawing.Point(616, 145);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(72, 16);
            this.label137.TabIndex = 346;
            this.label137.Text = "Mặt mũi :";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(472, 145);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(72, 16);
            this.label74.TabIndex = 345;
            this.label74.Text = "Mặt màng :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label136
            // 
            this.label136.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.Location = new System.Drawing.Point(272, 145);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(72, 16);
            this.label136.TabIndex = 344;
            this.label136.Text = "Cách sổ rau :";
            this.label136.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayrau
            // 
            this.ngayrau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrau.Enabled = false;
            this.ngayrau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrau.Location = new System.Drawing.Point(200, 142);
            this.ngayrau.Mask = "##/##/####";
            this.ngayrau.Name = "ngayrau";
            this.ngayrau.Size = new System.Drawing.Size(72, 21);
            this.ngayrau.TabIndex = 7;
            this.ngayrau.Text = "  /  /    ";
            this.ngayrau.Validated += new System.EventHandler(this.ngayrau_Validated);
            // 
            // giorau
            // 
            this.giorau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorau.Enabled = false;
            this.giorau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorau.Location = new System.Drawing.Point(120, 142);
            this.giorau.Mask = "##:##";
            this.giorau.Name = "giorau";
            this.giorau.Size = new System.Drawing.Size(40, 21);
            this.giorau.TabIndex = 6;
            this.giorau.Text = "  :  ";
            this.giorau.Validated += new System.EventHandler(this.giorau_Validated);
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(160, 145);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(38, 16);
            this.label72.TabIndex = 343;
            this.label72.Text = "ngày :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label135
            // 
            this.label135.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label135.Location = new System.Drawing.Point(16, 145);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(112, 16);
            this.label135.TabIndex = 340;
            this.label135.Text = "- Rau sổ lúc :";
            this.label135.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rau
            // 
            this.rau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rau.Enabled = false;
            this.rau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rau.Items.AddRange(new object[] {
            "1. Bóc",
            "2. Sổ"});
            this.rau.Location = new System.Drawing.Point(200, 118);
            this.rau.Name = "rau";
            this.rau.Size = new System.Drawing.Size(72, 21);
            this.rau.TabIndex = 5;
            this.rau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(168, 119);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(40, 16);
            this.label69.TabIndex = 333;
            this.label69.Text = "Rau :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(8, 119);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(144, 16);
            this.label68.TabIndex = 332;
            this.label68.Text = "2. Đặc điểm sổ rau :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chucdanh
            // 
            this.chucdanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chucdanh.Enabled = false;
            this.chucdanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chucdanh.Location = new System.Drawing.Point(640, 24);
            this.chucdanh.Name = "chucdanh";
            this.chucdanh.Size = new System.Drawing.Size(144, 21);
            this.chucdanh.TabIndex = 4;
            this.chucdanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // ngayde
            // 
            this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayde.Enabled = false;
            this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayde.Location = new System.Drawing.Point(200, 23);
            this.ngayde.Mask = "##/##/####";
            this.ngayde.Name = "ngayde";
            this.ngayde.Size = new System.Drawing.Size(72, 21);
            this.ngayde.TabIndex = 1;
            this.ngayde.Text = "  /  /    ";
            this.ngayde.Validated += new System.EventHandler(this.ngayde_Validated);
            // 
            // tentheodoi
            // 
            this.tentheodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentheodoi.Enabled = false;
            this.tentheodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentheodoi.Location = new System.Drawing.Point(413, 24);
            this.tentheodoi.Name = "tentheodoi";
            this.tentheodoi.Size = new System.Drawing.Size(162, 21);
            this.tentheodoi.TabIndex = 3;
            this.tentheodoi.TextChanged += new System.EventHandler(this.tentheodoi_TextChanged);
            this.tentheodoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // theodoi
            // 
            this.theodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.theodoi.Enabled = false;
            this.theodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi.Location = new System.Drawing.Point(376, 24);
            this.theodoi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.theodoi.MaxLength = 9;
            this.theodoi.Name = "theodoi";
            this.theodoi.Size = new System.Drawing.Size(36, 21);
            this.theodoi.TabIndex = 2;
            this.theodoi.Validated += new System.EventHandler(this.theodoi_Validated);
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(168, 0);
            this.listNv1.MatchBufferTimeOut = 1000;
            this.listNv1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv1.Name = "listNv1";
            this.listNv1.Size = new System.Drawing.Size(75, 17);
            this.listNv1.TabIndex = 328;
            this.listNv1.TextIndex = -1;
            this.listNv1.TextMember = null;
            this.listNv1.ValueIndex = -1;
            this.listNv1.Visible = false;
            // 
            // label134
            // 
            this.label134.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.Location = new System.Drawing.Point(571, 26);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(69, 16);
            this.label134.TabIndex = 327;
            this.label134.Text = "Chức danh :";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label133
            // 
            this.label133.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(264, 26);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(112, 16);
            this.label133.TabIndex = 326;
            this.label133.Text = "Tên người theo dõi :";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giode
            // 
            this.giode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giode.Enabled = false;
            this.giode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giode.Location = new System.Drawing.Point(120, 23);
            this.giode.Mask = "##:##";
            this.giode.Name = "giode";
            this.giode.Size = new System.Drawing.Size(40, 21);
            this.giode.TabIndex = 0;
            this.giode.Text = "  :  ";
            this.giode.Validated += new System.EventHandler(this.giode_Validated);
            // 
            // label131
            // 
            this.label131.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(160, 26);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(38, 16);
            this.label131.TabIndex = 325;
            this.label131.Text = "ngày :";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label132
            // 
            this.label132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.Location = new System.Drawing.Point(16, 26);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(112, 16);
            this.label132.TabIndex = 322;
            this.label132.Text = "- Vào buồng đẻ lúc :";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Enabled = false;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(392, 521);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(40, 21);
            this.giorv.TabIndex = 39;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // ngayrv
            // 
            this.ngayrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrv.Enabled = false;
            this.ngayrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrv.Location = new System.Drawing.Point(293, 521);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(72, 21);
            this.ngayrv.TabIndex = 38;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(368, 525);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 295;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(256, 525);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(40, 16);
            this.label90.TabIndex = 294;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nguoinhan
            // 
            this.nguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoinhan.Enabled = false;
            this.nguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoinhan.Location = new System.Drawing.Point(644, 499);
            this.nguoinhan.Name = "nguoinhan";
            this.nguoinhan.Size = new System.Drawing.Size(140, 21);
            this.nguoinhan.TabIndex = 37;
            this.nguoinhan.TextChanged += new System.EventHandler(this.nguoinhan_TextChanged);
            this.nguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoinhan
            // 
            this.manguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoinhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoinhan.Enabled = false;
            this.manguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoinhan.Location = new System.Drawing.Point(606, 499);
            this.manguoinhan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoinhan.MaxLength = 9;
            this.manguoinhan.Name = "manguoinhan";
            this.manguoinhan.Size = new System.Drawing.Size(36, 21);
            this.manguoinhan.TabIndex = 36;
            this.manguoinhan.Validated += new System.EventHandler(this.manguoinhan_Validated);
            this.manguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // nguoigiao
            // 
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(373, 499);
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(140, 21);
            this.nguoigiao.TabIndex = 35;
            this.nguoigiao.TextChanged += new System.EventHandler(this.nguoigiao_TextChanged);
            this.nguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoigiao
            // 
            this.manguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoigiao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoigiao.Enabled = false;
            this.manguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoigiao.Location = new System.Drawing.Point(336, 499);
            this.manguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoigiao.MaxLength = 9;
            this.manguoigiao.Name = "manguoigiao";
            this.manguoigiao.Size = new System.Drawing.Size(36, 21);
            this.manguoigiao.TabIndex = 34;
            this.manguoigiao.Validated += new System.EventHandler(this.manguoigiao_Validated);
            this.manguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(560, 521);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(162, 21);
            this.tenbs.TabIndex = 41;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(520, 521);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(36, 21);
            this.mabs.TabIndex = 40;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(432, 525);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(96, 16);
            this.label87.TabIndex = 282;
            this.label87.Text = "Bác sĩ điều trị :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(514, 501);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(112, 16);
            this.label86.TabIndex = 280;
            this.label86.Text = "Người nhận hồ sơ :";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(248, 501);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(112, 16);
            this.label85.TabIndex = 279;
            this.label85.Text = "Người giao hồ sơ :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Location = new System.Drawing.Point(200, 457);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1, 120);
            this.panel12.TabIndex = 277;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(7, 475);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(238, 1);
            this.panel10.TabIndex = 276;
            // 
            // khac
            // 
            this.khac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(52, 542);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(139, 14);
            this.khac.TabIndex = 28;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label81
            // 
            this.label81.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(15, 558);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(80, 16);
            this.label81.TabIndex = 274;
            this.label81.Text = "Toàn bộ hồ sơ";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(15, 542);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(56, 16);
            this.label80.TabIndex = 273;
            this.label80.Text = "Khác ";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(15, 526);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(64, 16);
            this.label79.TabIndex = 272;
            this.label79.Text = "Xét nghiệm";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(15, 510);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(56, 16);
            this.label78.TabIndex = 271;
            this.label78.Text = "Siêu âm";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 494);
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
            this.st5.Location = new System.Drawing.Point(203, 542);
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
            this.st4.Location = new System.Drawing.Point(203, 526);
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
            this.st3.Location = new System.Drawing.Point(203, 510);
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
            this.st6.Location = new System.Drawing.Point(203, 558);
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
            this.st1.Location = new System.Drawing.Point(203, 478);
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
            this.st2.Location = new System.Drawing.Point(203, 494);
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
            this.label8.Location = new System.Drawing.Point(15, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 262;
            this.label8.Text = "X-quang";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tk_dieutri
            // 
            this.tk_dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_dieutri.Enabled = false;
            this.tk_dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_dieutri.Location = new System.Drawing.Point(248, 457);
            this.tk_dieutri.Multiline = true;
            this.tk_dieutri.Name = "tk_dieutri";
            this.tk_dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_dieutri.Size = new System.Drawing.Size(536, 40);
            this.tk_dieutri.TabIndex = 33;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(248, 441);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(264, 16);
            this.label77.TabIndex = 122;
            this.label77.Text = "5. Hướng điều trị và các chế độ tiếp theo :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(8, 4);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(232, 17);
            this.label64.TabIndex = 96;
            this.label64.Text = "IV. Theo dõi tại buồng đẻ :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid1.Location = new System.Drawing.Point(24, 349);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(760, 61);
            this.dataGrid1.TabIndex = 259;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label82);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.label83);
            this.panel9.Controls.Add(this.label84);
            this.panel9.Location = new System.Drawing.Point(6, 440);
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
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(24, 45);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.ReadOnly = true;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(760, 68);
            this.dataGrid4.TabIndex = 382;
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(-2, 655);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(66, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(126, 655);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(66, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(62, 655);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(66, 25);
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
            // label169
            // 
            this.label169.BackColor = System.Drawing.Color.CadetBlue;
            this.label169.Location = new System.Drawing.Point(3, 36);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(181, 77);
            this.label169.TabIndex = 360;
            // 
            // label170
            // 
            this.label170.BackColor = System.Drawing.Color.CadetBlue;
            this.label170.Location = new System.Drawing.Point(191, 35);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(813, 77);
            this.label170.TabIndex = 361;
            // 
            // frmHSBenhan_BSA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 732);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butPhong);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p);
            this.Controls.Add(this.label169);
            this.Controls.Add(this.label170);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHSBenhan_BSA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ bệnh án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHSBenhan_BSA_KeyDown);
            this.Load += new System.EventHandler(this.frmHSBenhan_BSA_Load);
            this.p.ResumeLayout(false);
            this.p.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            this.p2.ResumeLayout(false);
            this.p1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHSBenhan_BSA_Load(object sender, System.EventArgs e)
		{
			thumucpic="..\\..\\..\\picture_ba";
			if (!Directory.Exists("..\\pict_ba")) Directory.CreateDirectory("..\\pict_ba");
   			if (!Directory.Exists(thumucpic)) Directory.CreateDirectory(thumucpic);
			else
			{
				try
				{
					string [] files=Directory.GetFiles(thumucpic);
					for(int i=0;i<files.GetLength(0);i++) File.Delete(files[i].ToString());
				}
				catch{}
			}
			bPhonggiuong=m.bPhonggiuong;
			butPhong.Visible=bPhonggiuong;
            if (bPhonggiuong) dtg = m.get_data("select * from " + user + ".dmgiuong").Tables[0];
			dtdt=m.get_data("select * from doituong").Tables[0];
			nor_toanthan=m.nor_toanthan;nor_tuanhoan=m.nor_tuanhoan;nor_hohap=m.nor_hohap;nor_tieuhoa=m.nor_tieuhoa;
			nor_than=m.nor_than;nor_thankinh=m.nor_thankinh;nor_co=m.nor_co;nor_tmh=m.nor_tmh;
			nor_rhm=m.nor_rhm;nor_mat=m.nor_mat;nor_noitiet=m.nor_noitiet;

			taibien.DisplayMember="TEN";
			taibien.ValueMember="MA";
            taibien.DataSource = m.get_data("select * from " + user + ".taibienpt order by ma").Tables[0];

			ppde.DisplayMember="TEN";
			ppde.ValueMember="ID";
            ppde.DataSource = m.get_data("select * from " + user + ".dmkieusanh order by stt").Tables[0];

			tinhtrangoi.SelectedIndex=0;
			oivo.SelectedIndex=0;
			dolot.SelectedIndex=0;
			rau.SelectedIndex=0;
			tangsinhmon.SelectedIndex=0;
			cotucung.SelectedIndex=0;

			stt1.DisplayMember="STT";
			stt1.ValueMember="STT";

			stt2.DisplayMember="STT";
			stt2.ValueMember="STT";

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
            listNv1.DataSource = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];

            //			string s_maba=m.get_data("select maba from " + user + ".btdkp_bv where makp='"+s_makp+"'").Tables[0].Rows[0][0].ToString();
            //			sql="select * from " + user + ".dmbenhan_bv where loaiba=1 and maba in ("+s_maba+")"+" order by maba";
            sql = "select * from " + user + ".dmbenhan_bv where maba=" + i_maba;
			dtba=m.get_data(sql).Tables[0];
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			tenba.SelectedIndex=0;
			xem.SelectedIndex=0;
			list.DisplayMember="HOTEN";
			list.ValueMember="MABN";
			load_list();
			list.ColumnWidths[0]=60;
			list.ColumnWidths[1]=150;
			list.ColumnWidths[2]=0;
			list.SetSensive(2,0,Color.Red);
			dsts.ReadXml("..\\..\\..\\xml\\m_tiensusk.xml");
			dscd.ReadXml("..\\..\\..\\xml\\m_bachidinh.xml");
			dspt.ReadXml("..\\..\\..\\xml\\m_bapttt.xml");
			dstress.ReadXml("..\\..\\..\\xml\\m_tresosinh.xml");
			dataGrid2.DataSource=dscd.Tables[0];
			AddGridTableStyle2();
            //-lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
            //lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
			dataGrid1.DataSource=dspt.Tables[0];
			AddGridTableStyle();
            //-lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            //lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            dataGrid4.DataSource=dstress.Tables[0];
			AddGridTableStyle4();
            //-lan.Read_dtgrid_to_Xml(dataGrid4, this.Name.ToString() + "_" + dataGrid4.Name.ToString());
            //lan.Change_dtgrid_HeaderText_to_English(dataGrid4, this.Name.ToString() + "_" + dataGrid4.Name.ToString());
			dataGrid3.DataSource=dsts.Tables[0];
			AddGridTableStyle3();
            //-lan.Read_dtgrid_to_Xml(dataGrid3, this.Name.ToString() + "_" + dataGrid3.Name.ToString());
            //lan.Change_dtgrid_HeaderText_to_English(dataGrid3, this.Name.ToString() + "_" + dataGrid3.Name.ToString());
            for(int i=0;i<chonin.Items.Count;i++) chonin.SetItemCheckState(i,CheckState.Checked);
		}	

		private void load_list()
		{
			Cursor=Cursors.WaitCursor;
			if (rb1.Checked)
			{
				xem.Enabled=false;
				butChon.Enabled=false;
				sql="select a.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,a.nhapkhoa,b.hoten,";
				sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
				sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
				sql+="k.ma as phong,h.giuong,a.id,a.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
				sql+="d.sovaovien,to_char(sysdate,'dd/mm/yyyy hh24:mi') as ngayrv,h.mabs,h.tuoivao,h.chandoan,";
				sql+="b.matt,b.maqu,b.maphuongxa, g.traituyen ";
				sql+=" from hiendien a,btdbn b,benhandt d,bhyt g,nhapkhoa h ,dmgiuong i,btdtt j,btdquan m,btdpxa n,dmphong k";
				sql+=" where a.id=h.id(+) and a.mabn=b.mabn and a.maql=g.maql(+) ";
				sql+=" and a.maql=d.maql and d.loaiba=1 and a.xuatkhoa=0 and a.idgiuong=i.id(+) and i.idphong=k.id(+)";
				sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
				sql+=" and a.makp='"+s_makp+"' and b.phai=1";
				if (i_phong!=0) sql+=" and i.idphong="+i_phong;
				sql+=" order by a.ngay desc";
			}
			else
			{
				xem.Enabled=true;
				butChon.Enabled=true;
				butKhoa.Enabled=true;
				butIn.Enabled=true;
				sql="select h.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,1 as nhapkhoa,b.hoten,";
				sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
				sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
				sql+="k.ma as phong,h.giuong,a.id,h.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
				sql+="d.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,a.mabs,h.tuoivao,h.chandoan,";
				sql+="b.matt,b.maqu,b.maphuongxa, g.traituyen ";
                sql += " from " + user + ".xuatkhoa a," + user + ".btdbn b," + user + ".benhandt d," + user + ".bhyt g," + user + ".nhapkhoa h ," + user + ".dmgiuong i," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n," + user + ".dmphong k";
				sql+=" where a.id=h.id and h.mabn=b.mabn and h.maql=g.maql(+) ";
				sql+=" and h.maql=d.maql and d.loaiba=1 and h.giuong=i.ma(+) and i.idphong=k.id(+)";
				sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
				sql+=" and h.makp='"+s_makp+"' and b.phai=1";
				if (i_phong!=0) sql+=" and i.idphong="+i_phong;
				sql+=" order by a.ngay desc";
			}
			ds=m.get_data(sql);
			list.DataSource=ds.Tables[0];
			Cursor=Cursors.Default;
		}

		private void bKethuc_Click(object sender, System.EventArgs e)
		{
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
				listNv1.BrowseToDanhmuc(nguoigiao,manguoigiao,manguoinhan,35);
			}
		}

		private void nguoigiao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv1.Visible) listNv1.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void nguoinhan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nguoinhan)
			{
				Filt_dmbs(nguoinhan.Text);
				listNv1.BrowseToDanhmuc(nguoinhan,manguoinhan,ngayrv,35);
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
				listNv1.BrowseToDanhmuc(tenbs,mabs,tenbs_pass,35);
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
				listICD.BrowseToICD10(cd_kkb,icd_kkb,phanbiet,icd_kkb.Location.X,icd_kkb.Location.Y+icd_kkb.Height,icd_kkb.Width+cd_kkb.Width+2,icd_kkb.Height);
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
			string _ngay=m.ngayhienhanh_server;
			tinhtrangoi.SelectedIndex=0;oivo.SelectedIndex=0;dolot.SelectedIndex=0;rau.SelectedIndex=0;tangsinhmon.SelectedIndex=0;cotucung.SelectedIndex=0;
			tungay.Text="";denngay.Text="";tuoithai.Text="";khamthai.Text="";uonvan.Checked=false;timthai.Text="";tiem.Text="";
			ngaychuyenda.Text=_ngay.Substring(0,10);giochuyenda.Text=_ngay.Substring(11);dauhieu.Text="";bienchuyen.Text="";
			kinhnam.Text="";kinhtuoi.Text="";chongnam.Text="";chongtuoi.Text="";tinhchat.Text="";chuky.Text="";luongkinh.Text="";
			dieutri.Text="";phu.Checked=false;tucung.Text="";dadieutri.Text="";cao.Text="";
			ptcu.Checked=false;dangtc.Text="";tuthe.Text="";caotc.Text="";vongbung.Text="";cotc.Text="";timthai.Text="";
			vu.Text="";bishop.Text="";amho.Text="";amdao.Text="";sinhmon.Text="";phanphu.Text="";ngayvo.Text="";giovo.Text="";
			mausac.Text="";nuocoi.Text="";ngoi.Text="";the.Text="";kieu.Text="";have.Text="";ngaysaude.Text="";giosaude.Text="";
			ngayde.Text=_ngay.Substring(0,10);giode.Text=_ngay.Substring(11);theodoi.Text="";tentheodoi.Text="";chucdanh.Text="";ngayrau.Text="";giorau.Text="";
			cachso.Text="";mang.Text="";mui.Text="";banhrau.Text="";raucannang.Text="";raucuon.Checked=false;raudai.Text="";
			chaymau.Checked=false;maumat.Text="";kiemsoattc.Checked=false;xuly.Text="";da.Text="";
			sd_mach.Text="";sd_nhietdo.Text="";sd_huyetap.Text="";sd_nhiptho.Text="";canthiep.Text="";loaichi.Text="";somui.Text="";bienchung.Checked=false;
			s_sovaovien="";i_madoituong=0;l_id=0;l_idkhoa=0;l_maql=0;l_idthuchien=0;dscd.Clear();dspt.Clear();
			mabn.Text="";hoten.Text="";namsinh.Text="";diachi.Text="";ngay.Text="";phong.Text="";giuong.Text="";sothe.Text="";chandoan.Text="";
			lydo.Text="";lanthu.Value=1;hb_giadinh.Text="";hb_banthan.Text="";kb_toanthan.Text="";
			kb_tuanhoan.Text="";kb_hohap.Text="";kb_tieuhoa.Text="";kb_than.Text="";kb_khac.Text="";
			mach.Text="";nhietdo.Text="";huyetap.Text="";nhiptho.Text="";cannang.Text="";
			icd_kkb.Text="";cd_kkb.Text="";phanbiet.Text="";tienluong.Text="";
			dieutri.Text="";ngayvk.Text="";giovk.Text="";mabsnb.Text="";tenbsnb.Text="";
			tk_dieutri.Text="";manguoigiao.Text="";nguoigiao.Text="";manguoinhan.Text="";nguoinhan.Text="";mabs.Text="";tenbs.Text="";
			st1.Value=0;st2.Value=0;st3.Value=0;st4.Value=0;st5.Value=0;st6.Value=0;khac.Text="";
			tenbs_pass.Text="";tenbsnb_pass.Text="";
			get_file(0);bHinh=false;chkHinh.Enabled=false;
			emp_hinh();
            chkHinh.Enabled = m.get_data("select * from " + user + ".ba_hinh where id=" + int.Parse(dtba.Rows[tenba.SelectedIndex]["maba"].ToString()) + " order by stt").Tables[0].Rows.Count > 0;
			stt1.Enabled=chkHinh.Checked;stt2.Enabled=chkHinh.Checked;
			ena_object(true);
		}

		private void emp_hinh()
		{
			pic1.Tag=filebmp;
			fstr=new System.IO.FileStream(pic1.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic1.Image=(Bitmap)map;
			image1=new byte[fstr.Length];
			fstr.Read(image1,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic1.Tag=image1;
			System.IO.File.Copy(filebmp,f1,true);
			//
			pic2.Tag=filebmp;
			fstr=new System.IO.FileStream(pic2.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic2.Image=(Bitmap)map;
			image2=new byte[fstr.Length];
			fstr.Read(image2,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic2.Tag=image2;
			System.IO.File.Copy(filebmp,f2,true);
		}

		private void picture(PictureBox pic,string tenfile)
		{
			pic.Image=(Bitmap)map;
			pic.Tag=image;
			map.Save(tenfile);
		}

		private void get_mabn(string _mabn)
		{
			emp_text();
			DataRow r=m.getrowbyid(ds.Tables[0],"mabn='"+_mabn+"'");
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi.Text=r["diachi"].ToString();
				phong.Text=r["phong"].ToString();
				giuong.Text=r["giuong"].ToString();
				sothe.Text=r["sothe"].ToString();
				ngay.Text=r["ngayvv"].ToString();
				chandoan.Text=r["chandoanvv"].ToString();
				ngayvk.Text=r["ngayvk"].ToString().Substring(0,10);
				giovk.Text=r["ngayvk"].ToString().Substring(11);
				mabsnb.Text=r["mabs"].ToString();
                traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());                
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
				if (r1!=null) 
				{
					tenbsnb.Text=r1["hoten"].ToString();
					tenbsnb_pass.Text=r1["password_"].ToString();
				}
				else tenbsnb.Text="";
				l_idkhoa=decimal.Parse(r["id"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				i_madoituong=int.Parse(r["madoituong"].ToString());
				s_sovaovien=r["sovaovien"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				cd_kkb.Text=r["chandoanvk"].ToString();
				if (rb2.Checked)
				{
					ngayrv.Text=r["ngayrv"].ToString().Substring(0,10);
					giorv.Text=r["ngayrv"].ToString().Substring(11);
				}
				mabs.Text=r["mabs"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null)
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				if (bPhonggiuong) butPhong.Enabled=r["nhapkhoa"].ToString()=="0";
				load_data();
				ena_object(false);
				if (r["nhapkhoa"].ToString()=="0")
				{
					butChuyenphong.Enabled=false;butChamsoc.Enabled=false;butKhoa.Enabled=false;xem.Enabled=false;
					butDausinhton.Enabled=false;butChidinh.Enabled=false;butDieutri.Enabled=false;
					butAn.Enabled=false;butMau.Enabled=false;butDich.Enabled=false;butDausinhton.Enabled=false;butPhanung.Enabled=false;
					butChon.Enabled=false;butPttt.Enabled=false;
				}
			}
			else
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
		}

		private void load_data()
		{
			Cursor=Cursors.WaitCursor;
			bool bFound=false;xxx=user+m.mmyy(ngay.Text);
			l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
			string _ngay="";
			DataRow r1;
			if (l_idthuchien!=0)
			{
				l_id=m.get_idchung(ngay.Text,l_idthuchien);
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_chung where id="+l_id).Tables[0].Rows)
				{
					lydo.Text=r["lydo"].ToString();
					lanthu.Value=decimal.Parse(r["lanthu"].ToString());
					hb_banthan.Text=r["hb_banthan"].ToString();
					hb_giadinh.Text=r["hb_giadinh"].ToString();
					kb_toanthan.Text=r["kb_toanthan"].ToString();
					kb_tuanhoan.Text=r["kb_tuanhoan"].ToString();
					kb_hohap.Text=r["kb_hohap"].ToString();
					kb_tieuhoa.Text=r["kb_tieuhoa"].ToString();
					kb_than.Text=r["kb_than"].ToString();
					kb_khac.Text=r["kb_khac"].ToString();
					phanbiet.Text=r["phanbiet"].ToString();
					tienluong.Text=r["tienluong"].ToString();
					dieutri.Text=r["dieutri"].ToString();
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
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_sankhoa where id="+l_id).Tables[0].Rows)
				{
					if (r["tungay"].ToString()!="") tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
					if (r["denngay"].ToString()!="") denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					tuoithai.Text=(r["tuoithai"].ToString()!="0")?r["tuoithai"].ToString():"";
					khamthai.Text=r["khamthai"].ToString();
					uonvan.Checked=r["uonvan"].ToString()=="1";
					tiem.Text=(r["tiem"].ToString()!="0")?r["tiem"].ToString():"";
					if (r["chuyenda"].ToString()!="")
					{
						_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["chuyenda"].ToString()));
						ngaychuyenda.Text=_ngay.Substring(0,10);
						giochuyenda.Text=_ngay.Substring(11);
					}
					dauhieu.Text=r["dauhieu"].ToString();
					bienchuyen.Text=r["bienchuyen"].ToString();
					kinhnam.Text=r["kinhnam"].ToString();
					if (kinhnam.Text!="") kinhtuoi.Text=Convert.ToString(int.Parse(kinhnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
					tinhchat.Text=r["tinhchat"].ToString();
					chuky.Text=(r["chuky"].ToString()!="0")?r["chuky"].ToString():"";
					luongkinh.Text=r["luongkinh"].ToString();
					chongnam.Text=r["chongnam"].ToString();
					if (chongnam.Text!="") chongtuoi.Text=Convert.ToString(int.Parse(chongnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
					dadieutri.Text=r["dieutri"].ToString();
					phu.Checked=r["phu"].ToString()=="1";
					ptcu.Checked=r["ptcu"].ToString()=="1";
					dangtc.Text=r["dangtc"].ToString();
					tuthe.Text=r["tuthe"].ToString();
					caotc.Text=(r["caotc"].ToString()!="0")?r["caotc"].ToString():"";
					vongbung.Text=(r["vongbung"].ToString()!="0")?r["vongbung"].ToString():"";
					cotc.Text=r["cotc"].ToString();
					timthai.Text=(r["timthai"].ToString()!="0")?r["timthai"].ToString():"";
					vu.Text=r["vu"].ToString();
					bishop.Text=(r["bishop"].ToString()!="0")?r["bishop"].ToString():"";
					amho.Text=r["amho"].ToString();
					amdao.Text=r["amdao"].ToString();
					sinhmon.Text=r["sinhmon"].ToString();
					tucung.Text=r["tucung"].ToString();
					phanphu.Text=r["phanphu"].ToString();
					tinhtrangoi.SelectedIndex=int.Parse(r["tinhtrangoi"].ToString());
					if (r["voluc"].ToString()!="")
					{
						_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["voluc"].ToString()));
						ngayvo.Text=_ngay.Substring(0,10);
						giovo.Text=_ngay.Substring(11);
					}
					oivo.SelectedIndex=int.Parse(r["oivo"].ToString());
					mausac.Text=r["mausac"].ToString();
					nuocoi.Text=r["nuocoi"].ToString();
					ngoi.Text=r["ngoi"].ToString();
					the.Text=r["the"].ToString();
					kieu.Text=r["kieu"].ToString();
					dolot.SelectedIndex=int.Parse(r["dolot"].ToString());
					have.Text=r["have"].ToString();
					if (r["deluc"].ToString()!="")
					{
						_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["deluc"].ToString()));
						ngayde.Text=_ngay.Substring(0,10);
						giode.Text=_ngay.Substring(11);
					}
					theodoi.Text=r["theodoi"].ToString();
					r1=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
					if (r1!=null) tentheodoi.Text=r1["hoten"].ToString();
					chucdanh.Text=r["chucdanh"].ToString();
					rau.SelectedIndex=int.Parse(r["rau"].ToString());
					if (r["rauluc"].ToString()!="")
					{
						_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["rauluc"].ToString()));
						ngayrau.Text=_ngay.Substring(0,10);
						giorau.Text=_ngay.Substring(11);
					}
					cachso.Text=r["cachso"].ToString();
					mang.Text=r["mang"].ToString();
					mui.Text=r["mui"].ToString();
					banhrau.Text=r["banhrau"].ToString();
					raucannang.Text=(r["raucannang"].ToString()!="0")?r["raucannang"].ToString():"";
					raucuon.Checked=r["raucuon"].ToString()=="1";
					raudai.Text=(r["raudai"].ToString()!="0")?r["raudai"].ToString():"";
					chaymau.Checked=r["chaymau"].ToString()=="1";
					maumat.Text=(r["maumat"].ToString()!="0")?r["maumat"].ToString():"";
					maumat.Enabled=chaymau.Checked;
					kiemsoattc.Checked=r["kiemsoattc"].ToString()=="1";
					xuly.Text=r["xuly"].ToString();
					if (r["ngaysaude"].ToString()!="")
					{
						_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaysaude"].ToString()));
						ngaysaude.Text=_ngay.Substring(0,10);
						giosaude.Text=_ngay.Substring(11);
					}
					da.Text=r["da"].ToString();
					ppde.SelectedValue=r["ppde"].ToString();
					sd_mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					sd_nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					sd_huyetap.Text=r["huyetap"].ToString();
					sd_nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cao.Text=(r["cao"].ToString()!="0")?r["cao"].ToString():"";
					canthiep.Text=r["canthiep"].ToString();
					tangsinhmon.SelectedIndex=int.Parse(r["tangsinhmon"].ToString());
					loaichi.Text=r["loaichi"].ToString();
					somui.Text=(r["somui"].ToString()!="0")?r["somui"].ToString():"";
					loaichi.Enabled=tangsinhmon.SelectedIndex==2;
					somui.Enabled=loaichi.Enabled;
					cotucung.SelectedIndex=int.Parse(r["cotucung"].ToString());
					break;
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_hinh where id="+l_id+" order by stt").Tables[0].Rows)
				{
					image =new byte[0];
					image =(byte[])(r["image"]);
					memo=new MemoryStream(image);
					map=new Bitmap(Image.FromStream(memo));
					picture((int.Parse(r["stt"].ToString())==1)?pic1:pic2,(int.Parse(r["stt"].ToString())==1)?f1:f2);
					bHinh=true;chkHinh.Enabled=true;chkHinh.Checked=true;
				}
				foreach(DataRow r in m.get_data("select * from "+xxx+".ba_kbdausinhton where id="+l_id).Tables[0].Rows)
				{
					mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
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
				foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_sankhoa where maql="+l_maql).Tables[0].Rows)
				{
					lydo.Text=r["lydokham"].ToString();
					hb_giadinh.Text=r["giadinh"].ToString();
					kinhnam.Text=r["kinhnam"].ToString();
					if (kinhnam.Text!="") kinhtuoi.Text=Convert.ToString(int.Parse(kinhnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
					chuky.Text=(r["chuky"].ToString()!="0")?r["chuky"].ToString():"";
					chongnam.Text=r["chongnam"].ToString();
					if (chongnam.Text!="") chongtuoi.Text=Convert.ToString(int.Parse(chongnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
					dadieutri.Text=r["phukhoa"].ToString();
					caotc.Text=r["caotc"].ToString();
					dangtc.Text=r["dangtc"].ToString();
					ptcu.Checked=r["vmc"].ToString()!="";
					kieu.Text=r["kieuthe"].ToString();
					phu.Checked=r["phu"].ToString()=="1";
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
						cao.Text=(r["chieucao"].ToString()!="0")?r["chieucao"].ToString():"";
						break;
					}
                    //					foreach(DataRow r in m.get_data("select * from " + user + ".benhandt where maql="+l_maql).Tables[0].Rows)
//					{
//						icd_kkb.Text=r["maicd"].ToString();
//						cd_kkb.Text=r["chandoan"].ToString();
//						break;
//					}
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
			load_chidinh();
			load_pttt();
			load_tresosinh();
			load_tiensusk();
			Cursor=Cursors.Default;
		}

		private void load_tiensusk()
		{
			sql="select a.stt,a.nam,decode(a.duthieu,1,'x',' ') as du,decode(a.duthieu,2,'x',' ') as thieu,";
			sql+="decode(a.sayhutnao,0,'x',' ') as say,decode(a.sayhutnao,1,'x',' ') as hut,decode(a.sayhutnao,2,'x',' ') as nao,";
			sql+="decode(a.covac,1,'x',' ') as covac,decode(a.ngoaitrung,0,'x',' ') as ngoai,decode(a.ngoaitrung,1,'x',' ') as trung,";
			sql+="decode(a.chetsong,0,'x',' ') as chet,decode(a.chetsong,1,'x',' ') as song,a.cannang,a.ppde,b.ten,decode(a.taibien,1,'x',' ') as taibien";
			sql+=" from "+user+m.mmyy(ngay.Text)+".ba_tiensusk a,"+user+".dmkieusanh b where a.ppde=b.id and a.id="+l_id+" order by a.stt";
			dsts=m.get_data(sql);
			dataGrid3.DataSource=dsts.Tables[0];
		}

		private void load_tresosinh()
		{
			sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten as tenngoithai,b.ma,";
			sql+="decode(a.phai,0,'Nam','Nu') as t_phai,decode(a.tinhtrang,0,'Song','Chet') as t_tinhtrang,";
			sql+="decode(a.ditat,0,'Không','Có') as t_ditat,a.cannang,a.phai,a.tinhtrang,a.ditat,a.id_ss,d.ten as tencachthucde,";
			sql+="c.apgar1,c.apgar5,c.apgar10,c.conthu,c.mass,c.hoten,c.duthang,c.thang,c.tuan,c.manv1,c.manv2,c.cachthucde,c.xuly,";
			sql+="c.cao,c.vongdau,c.ditatbs,e.ten as tenditat,a.ngoithai ";
            sql += " from " + user + ".tresosinh a," + user + ".dmngoithai b," + user + ".ddsosinh c," + user + ".dmkieusanh d," + user + ".dmditat e ";
			sql+=" where a.ngoithai=b.ma and a.id_ss=c.maql and c.cachthucde=d.id and c.ditatbs=e.ma(+) and a.maql="+l_maql+" order by a.id_ss";
			dstress=m.get_data(sql);
			dataGrid4.DataSource=dstress.Tables[0];
		}

		private void load_chidinh()
		{
			string tu=ngay.Text.Substring(0,10),den=(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10);
			sql="select nvl(e.stt,0) as stt,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,d.hoten as tenbs,b.ten,' ' as ketqua ";
			sql+=" from xxx.v_chidinh a,"+user+".v_giavp b,"+user+".btdkp_bv c,"+user+".dmbs d,"+user+".dmchidinh e ";
			sql+=" where a.mavp=b.id and a.makp=c.makp(+) and a.mabs=d.ma(+) and b.id_loai=e.idloaivp(+) and a.mabn='"+mabn.Text+"'";
			sql+=" and to_date(a.ngay,'dd/mm/yyyy') between to_date('"+tu+"','dd/mm/yyyy') and to_date('"+den+"','dd/mm/yyyy')";
			sql+=" order by a.ngay,b.stt";
			dscd=m.get_data_mmyy(sql,tu,den,false);
			dataGrid2.DataSource=dscd.Tables[0];
			st1.Value=dscd.Tables[0].Select("stt=2").Length;
			st2.Value=dscd.Tables[0].Select("stt=3").Length;
			st3.Value=dscd.Tables[0].Select("stt=5").Length;
			st4.Value=dscd.Tables[0].Select("stt>=10 and stt<=20").Length;
			st6.Value=dscd.Tables[0].Rows.Count;
			//st5.Value=st6.Value-st1.Value-st2.Value-st3.Value-st4.Value;
			DataTable tmp=m.get_data("select b.stt from "+user+m.mmyy(ngay.Text)+".ba_scan a,ba_loaiphieu b where a.loai=b.id and a.id="+l_id).Tables[0];
			st1.Value+=tmp.Select("stt=2").Length;
			st2.Value+=tmp.Select("stt=3").Length;
			st3.Value+=tmp.Select("stt=5").Length;
			st4.Value+=tmp.Select("stt>=10 and stt<=20").Length;
			st6.Value+=tmp.Rows.Count;
			st5.Value=st6.Value-st1.Value-st2.Value-st3.Value-st4.Value;
		}

		private void load_pttt()
		{
			string tu=ngay.Text.Substring(0,10),den=(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10);
			sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,substr(a.mapt,1,1) as ma,trim(a.tenpt)||' / '||trim(b.ten) as ten,";
			sql+="c.hoten as tenbs,d.hoten as gayme,a.chandoant,a.chandoans,a.taibien,a.bienchung from pttt a,dmmete b,dmbs c,dmbs d ";
			sql+=" where a.phuongphap=b.ma and a.ptv=c.ma(+) and a.bsgayme=d.ma(+)";
			sql+=" and a.mabn='"+mabn.Text+"' and to_date(a.ngay,'dd/mm/yyyy') between to_date('"+tu+"','dd/mm/yyyy') and to_date('"+den+"','dd/mm/yyyy')";
			dspt=m.get_data(sql);
			dataGrid1.DataSource=dspt.Tables[0];
			if (dspt.Tables[0].Rows.Count>0)
			{
				chandoan_t.Text=dspt.Tables[0].Rows[0]["chandoant"].ToString();
				chandoan_s.Text=dspt.Tables[0].Rows[0]["chandoans"].ToString();
				taibien.SelectedValue=dspt.Tables[0].Rows[0]["taibien"].ToString();
				bienchung.Checked=dspt.Tables[0].Rows[0]["bienchung"].ToString()=="1";
			}
		}

		private bool kiemtra()
		{
			if (icd_kkb.Text=="" || cd_kkb.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Chẩn đoán vào khoa chưa hợp lệ !"),LibMedi.AccessData.Msg);
				icd_kkb.Focus();
				return false;
			}
			if (mabsnb.Text=="" || tenbsnb.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ làm bệnh án chưa hợp lệ !"),LibMedi.AccessData.Msg);
				mabsnb.Focus();
				return false;
			}
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ làm bệnh án chưa hợp lệ !"),LibMedi.AccessData.Msg);
				mabsnb.Focus();
				return false;
			}
			if (!bAdmin)
			{
				if (tenbsnb_pass.Text!=r["password_"].ToString())
				{
					MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu bác sĩ làm bệnh án chưa hợp lệ !"),LibMedi.AccessData.Msg);
					tenbsnb_pass.Focus();
					return false;
				}
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
				if (!bAdmin)
				{
					if (tenbs_pass.Text!=r["password_"].ToString())
					{
						MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
						tenbs_pass.Focus();
						return false;
					}
				}
			}
			if (bPhonggiuong && giuong.Text=="" && butPhong.Enabled)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu chọn phòng/giường !"),LibMedi.AccessData.Msg);
				butPhong.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			xxx=user+m.mmyy(ngay.Text);
			bool bNhapkhoa=m.getrowbyid(ds.Tables[0],"nhapkhoa=0 and mabn='"+mabn.Text+"'")!=null;
			if (bNhapkhoa) upd_nhapkhoa();
			m.execute_data("update benhandt set mabs='"+mabsnb.Text+"' where maql="+l_maql);
			l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			l_id=m.get_idchung(ngay.Text,l_idthuchien);
			if (l_id==0) l_id=m.get_capid(-301);
            if (!m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, lanthu.Value, "", hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
				kb_hohap.Text,kb_tieuhoa.Text,kb_than.Text,"","","","","","",kb_khac.Text,"",phanbiet.Text,
				tienluong.Text,dieutri.Text,mabsnb.Text,"","","","",tk_dieutri.Text,manguoigiao.Text,manguoinhan.Text,mabs.Text,i_userid))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin !"),LibMedi.AccessData.Msg);
				return;
			}
			m.upd_ba_sankhoa(ngay.Text,l_id,tungay.Text,denngay.Text,(tuoithai.Text!="")?decimal.Parse(tuoithai.Text):0,khamthai.Text,(uonvan.Checked)?1:0,(tiem.Text!="")?decimal.Parse(tiem.Text):0,
				ngaychuyenda.Text+" "+giochuyenda.Text,dauhieu.Text,bienchuyen.Text,kinhnam.Text,tinhchat.Text,(chuky.Text!="")?int.Parse(chuky.Text):0,luongkinh.Text,
				chongnam.Text,dadieutri.Text,(phu.Checked)?1:0,(ptcu.Checked)?1:0,dangtc.Text,tuthe.Text,(caotc.Text!="")?decimal.Parse(caotc.Text):0,(vongbung.Text!="")?decimal.Parse(vongbung.Text):0,
				cotc.Text,(timthai.Text!="")?decimal.Parse(timthai.Text):0,vu.Text,(bishop.Text!="")?decimal.Parse(bishop.Text):0,amho.Text,amdao.Text,sinhmon.Text,tucung.Text,
				phanphu.Text,tinhtrangoi.SelectedIndex,ngayvo.Text+" "+giovo.Text,oivo.SelectedIndex,mausac.Text,nuocoi.Text,ngoi.Text,the.Text,kieu.Text,dolot.SelectedIndex,have.Text,
				ngayde.Text+" "+giode.Text,theodoi.Text,chucdanh.Text,rau.SelectedIndex,ngayrau.Text+" "+giorau.Text,cachso.Text,mang.Text,mui.Text,banhrau.Text,(raucannang.Text!="")?decimal.Parse(raucannang.Text):0,
				(raucuon.Checked)?1:0,(raudai.Text!="")?decimal.Parse(raudai.Text):0,(chaymau.Checked)?1:0,(maumat.Text!="")?decimal.Parse(maumat.Text):0,(kiemsoattc.Checked)?1:0,xuly.Text,ngaysaude.Text+" "+giosaude.Text,da.Text,int.Parse(ppde.SelectedValue.ToString()),
				(sd_mach.Text!="")?decimal.Parse(sd_mach.Text):0,(sd_nhietdo.Text!="")?decimal.Parse(sd_nhietdo.Text):0,sd_huyetap.Text,(sd_nhiptho.Text!="")?decimal.Parse(sd_nhiptho.Text):0,canthiep.Text,tangsinhmon.SelectedIndex,loaichi.Text,(somui.Text!="")?decimal.Parse(somui.Text):0,cotucung.SelectedIndex,(cao.Text!="")?decimal.Parse(cao.Text):0);
            m.upd_ba_kbdausinhton(ngay.Text, mabn.Text, l_id, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, 0);
			m.execute_data("delete from "+xxx+".ba_hbdacdiem where id="+l_id);
			m.execute_data("delete from "+xxx+".ba_tkhoso where id="+l_id);
            if (st1.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 1, "", st1.Value);
            if (st2.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 2, "", st2.Value);
            if (st3.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 3, "", st3.Value);
            if (st4.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 4, "", st4.Value);
            if (st5.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 5, khac.Text, st5.Value);
            if (st6.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 6, "", st6.Value);
			//hinh
			if (bHinh)
			{
				upd_hinh(f1,1);
				upd_hinh(f2,2);
			}
			//
			ena_object(true);
			if (bNhapkhoa) load_list();
		}

		private void upd_hinh(string tenfile,int stt)
		{
			if (File.Exists(tenfile))
			{
				fstr=new System.IO.FileStream(tenfile,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image=new byte[fstr.Length];
				fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				m.upd_ba_hinh(ngay.Text,l_id,stt,image);
			}
		}

		private void upd_nhapkhoa()
		{
			bool bNew=true;
			decimal idgiuong=0;
			if (bPhonggiuong)
			{				
				bNew=m.get_data("select id from nhapkhoa where maql="+l_maql+" and makp='"+s_makp+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+" "+giovk.Text+"'").Tables[0].Rows.Count==0;
				if (bNew)
				{
					l_idkhoa=m.get_id(l_maql,s_makp,ngayvk.Text+" "+giovk.Text);
					DataRow r2,r1=m.getrowbyid(dtg,"ma='"+giuong.Text+"'");
					string fie="gia_th";
					decimal id=v.get_id_vpkhoa;
					if (r1!=null)
					{
						r2=m.getrowbyid(dtdt,"madoituong="+i_madoituong);
						if (r2!=null) fie=r2["field_gia"].ToString().Trim();
						decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
						idgiuong=decimal.Parse(r1["id"].ToString());
						m.upd_theodoigiuong(id,s_makp,mabn.Text,l_maql, l_idkhoa,i_madoituong,int.Parse(r1["id"].ToString()),ngayvk.Text+" "+giovk.Text,decimal.Parse(r1[fie].ToString())*tygia,i_userid);
						m.execute_data("update dmgiuong set tinhtrang=2,soluong=soluong+1 where id="+int.Parse(r1["id"].ToString()));
						itable=m.tableid("","theodoigiuong");
						m.upd_eve_tables(itable,i_userid,"ins");
						m.upd_eve_upd_del(itable,i_userid,"ins",m.fields(user+".theodoigiuong","id="+id));
					}
					bNew=false;
				}
			}
			if (bNew) l_idkhoa=m.get_id(l_maql,s_makp,ngayvk.Text+" "+giovk.Text);
			int i_maba=11;
			DataRow r3=m.getrowbyid(dtba,"mavt='"+tenba.SelectedValue.ToString()+"'");
			if (r3!=null) i_maba=int.Parse(r3["maba"].ToString());
			itable = m.tableid("","nhapkhoa");
			if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
			else
			{
				m.upd_eve_tables(itable, i_userid, "upd");
				m.upd_eve_upd_del(itable, i_userid, "upd",m.fields(user+".nhapkhoa","id="+l_idkhoa));
			}
			string stuoi=m.get_tuoivao(l_maql),khoachuyen="01",ngaychuyen=ngayvk.Text+" "+giovk.Text;
			foreach(DataRow r in m.get_data("select makp,ngaychuyen from chuyenkhoa where khoaden='"+s_makp+"'"+" and maql="+l_maql+" order by ngaychuyen desc").Tables[0].Rows)
			{
				ngaychuyen=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaychuyen"].ToString()));
				khoachuyen=r["makp"].ToString();
				break;
			}
            if (!m.upd_nhapkhoa(l_idkhoa, mabn.Text, l_maql, l_maql, s_makp, i_maba, ngaychuyen, ngaychuyen, stuoi, giuong.Text, khoachuyen, cd_kkb.Text, icd_kkb.Text, mabsnb.Text, 1, i_userid))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin vào khoa !"),LibMedi.AccessData.Msg);
				return;
			}
			if (idgiuong!=0) m.execute_data("update hiendien set idgiuong="+idgiuong+" where id="+l_idkhoa);			
		}

		private void upd_danhmuc(int loai,string ten)
		{
			if (ten!="")
			{
				DataRow r=m.getrowbyid(dt,"ten='"+ten+"'");
				if (r==null)
				{
					decimal _id=m.get_capid(-50);
					m.upd_ba_danhmuc(_id,loai,0,ten);
					DataRow r1=dt.NewRow();
					r1["id"]=_id;
					r1["loai"]=loai;
					r1["stt"]=0;
					r1["ten"]=ten;
					dt.Rows.Add(r1);
				}
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
				tinhtrangoi.Enabled=!ena;oivo.Enabled=!ena;dolot.Enabled=!ena;rau.Enabled=!ena;tangsinhmon.Enabled=!ena;cotucung.Enabled=!ena;ppde.Enabled=!ena;
				tungay.Enabled=!ena;denngay.Enabled=!ena;tuoithai.Enabled=!ena;khamthai.Enabled=!ena;uonvan.Enabled=!ena;timthai.Enabled=!ena;tiem.Enabled=!ena;
				ngaychuyenda.Enabled=!ena;giochuyenda.Enabled=!ena;dauhieu.Enabled=!ena;bienchuyen.Enabled=!ena;
				kinhnam.Enabled=!ena;kinhtuoi.Enabled=!ena;chongnam.Enabled=!ena;chongtuoi.Enabled=!ena;tucung.Enabled=!ena;
				tinhchat.Enabled=!ena;chuky.Enabled=!ena;luongkinh.Enabled=!ena;dieutri.Enabled=!ena;phu.Enabled=!ena;
				ptcu.Enabled=!ena;dangtc.Enabled=!ena;tuthe.Enabled=!ena;caotc.Enabled=!ena;vongbung.Enabled=!ena;cotc.Enabled=!ena;timthai.Enabled=!ena;
				vu.Enabled=!ena;bishop.Enabled=!ena;amho.Enabled=!ena;amdao.Enabled=!ena;sinhmon.Enabled=!ena;phanphu.Enabled=!ena;ngayvo.Enabled=!ena;giovo.Enabled=!ena;
				mausac.Enabled=!ena;nuocoi.Enabled=!ena;ngoi.Enabled=!ena;the.Enabled=!ena;kieu.Enabled=!ena;have.Enabled=!ena;ngayde.Enabled=!ena;
				ngaysaude.Enabled=!ena;giosaude.Enabled=!ena;
				giode.Enabled=!ena;theodoi.Enabled=!ena;tentheodoi.Enabled=!ena;chucdanh.Enabled=!ena;ngayrau.Enabled=!ena;giorau.Enabled=!ena;
				cachso.Enabled=!ena;mang.Enabled=!ena;mui.Enabled=!ena;banhrau.Enabled=!ena;raucannang.Enabled=!ena;raucuon.Enabled=!ena;raudai.Enabled=!ena;
				chaymau.Enabled=!ena;dadieutri.Enabled=!ena;cao.Enabled=!ena;
				if (ena)
				{
					maumat.Enabled=!ena;loaichi.Enabled=!ena;somui.Enabled=!ena;
				}
				kiemsoattc.Enabled=!ena;xuly.Enabled=!ena;da.Enabled=!ena;
				sd_mach.Enabled=!ena;sd_nhietdo.Enabled=!ena;sd_huyetap.Enabled=!ena;sd_nhiptho.Enabled=!ena;canthiep.Enabled=!ena;				
				lydo.Enabled=!ena;lanthu.Enabled=!ena;hb_giadinh.Enabled=!ena;hb_banthan.Enabled=!ena;kb_toanthan.Enabled=!ena;
				kb_tuanhoan.Enabled=!ena;kb_hohap.Enabled=!ena;kb_tieuhoa.Enabled=!ena;kb_than.Enabled=!ena;
				kb_khac.Enabled=!ena;mach.Enabled=!ena;nhietdo.Enabled=!ena;huyetap.Enabled=!ena;nhiptho.Enabled=!ena;cannang.Enabled=!ena;
				phanbiet.Enabled=!ena;tienluong.Enabled=!ena;dieutri.Enabled=!ena;tk_dieutri.Enabled=!ena;
				ngayrv.Enabled=!ena;giorv.Enabled=!ena;manguoigiao.Enabled=!ena;nguoigiao.Enabled=!ena;manguoinhan.Enabled=!ena;nguoinhan.Enabled=!ena;mabs.Enabled=!ena;tenbs.Enabled=!ena;
				tenbs_pass.Enabled=!ena;tenbsnb_pass.Enabled=!ena;ngayvk.Enabled=!ena;giovk.Enabled=!ena;icd_kkb.Enabled=!ena;cd_kkb.Enabled=!ena;mabsnb.Enabled=!ena;tenbsnb.Enabled=!ena;
				mabn.Enabled=ena;list.Enabled=ena;butChuyenphong.Enabled=!ena;
				if (i_loai==0 || i_loai==2) butChamsoc.Enabled=!ena;
				butKhoa.Enabled=ena;xem.Enabled=!ena;butDausinhton.Enabled=!ena;butChidinh.Enabled=!ena;
				if (i_loai==0 || i_loai==1) butDieutri.Enabled=!ena;
				butAn.Enabled=!ena;butMau.Enabled=!ena;butDich.Enabled=!ena;butDausinhton.Enabled=!ena;butPhanung.Enabled=!ena;
				butChon.Enabled=!ena;butPttt.Enabled=!ena;butKethuc.Enabled=ena;
				butLuu.Enabled=!ena;butBoqua.Enabled=!ena;butIn.Enabled=ena;tim.Enabled=ena;
				butTresosinh.Enabled=!ena;butTiensu.Enabled=!ena;
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) get_mabn(list.SelectedValue.ToString());
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			get_mabn(list.SelectedValue.ToString());
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			get_mabn(mabn.Text);
		}

		private void butKhoa_Click(object sender, System.EventArgs e)
		{
			frmChonkp f=new frmChonkp(m,s_makp,s_mabs);
			f.ShowDialog();
			if (f.s_makp!="")
			{
				s_makp=f.s_makp;s_tenkp=f.s_tenkp;s_mabs=f.s_mabs;i_phong=f.i_phong;
				string s_maba=m.get_data("select maba from btdkp_bv where makp='"+s_makp+"'").Tables[0].Rows[0][0].ToString();
				sql="select * from dmbenhan_bv where loaiba=1 and maba in ("+s_maba+")"+" order by maba";
				dtba=m.get_data(sql).Tables[0];
				load_list();
			}
		}

		private void AddGridTableStyle4()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dstress.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id_ss";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày sinh";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenngoithai";
			TextCol.HeaderText = "Ngôi thai";
			TextCol.Width = 85;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_phai";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tencachthucde";
			TextCol.HeaderText = "Cách thức đẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cao";
			TextCol.HeaderText = "Cao";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vongdau";
			TextCol.HeaderText = "Vòng đầu";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_tinhtrang";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_ditat";
			TextCol.HeaderText = "Dị tật";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenditat";
			TextCol.HeaderText = "Tật bẩm sinh";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);
		}

		private void AddGridTableStyle3()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsts.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Số lần";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nam";
			TextCol.HeaderText = "Năm";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "du";
			TextCol.HeaderText = "Đủ tháng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thieu";
			TextCol.HeaderText = "Thiếu tháng";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "say";
			TextCol.HeaderText = "Sẩy";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hut";
			TextCol.HeaderText = "Hút";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nao";
			TextCol.HeaderText = "Nạo";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "Covac";
			TextCol.HeaderText = "Covac";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngoai";
			TextCol.HeaderText = "Chửa ngoài";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "trung";
			TextCol.HeaderText = "Chửa trứng";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chet";
			TextCol.HeaderText = "Thai chết lưu";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "song";
			TextCol.HeaderText = "Con hiện sống";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Phương pháp đẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "taibien";
			TextCol.HeaderText = "Tai biến";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);
		}

		private void AddGridTableStyle2()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dscd.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa/phòng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sĩ";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Chỉ định";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ketqua";
			TextCol.HeaderText = "Kết quả";
			TextCol.Width = 175;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dspt.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;				

			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();						
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Phương pháp phẫu thuật / vô cảm";
			TextCol.Width = 330;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sĩ phẫu thuật";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gayme";
			TextCol.HeaderText = "Bác sĩ gây mê";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
		#region Normal
		private void st1_Validated(object sender, System.EventArgs e)
		{
			st6.Value=st1.Value+st2.Value+st3.Value+st4.Value+st5.Value;
		}

		private void label165_Click(object sender, System.EventArgs e)
		{
			kb_toanthan.Text=nor_toanthan;
			kb_tuanhoan.Text=nor_tuanhoan;
			kb_hohap.Text=nor_hohap;
			kb_tieuhoa.Text=nor_tieuhoa;
			kb_than.Text=nor_than;
		}

		private void label92_Click(object sender, System.EventArgs e)
		{
			kb_toanthan.Text=nor_toanthan;
		}

		private void label94_Click(object sender, System.EventArgs e)
		{
			kb_tuanhoan.Text=nor_tuanhoan;
			kb_hohap.Text=nor_hohap;
			kb_tieuhoa.Text=nor_tieuhoa;
			kb_than.Text=nor_than;
		}

		private void label95_Click(object sender, System.EventArgs e)
		{
			kb_tuanhoan.Text=nor_tuanhoan;
		}

		private void label96_Click(object sender, System.EventArgs e)
		{
			kb_hohap.Text=nor_hohap;
		}

		private void label97_Click(object sender, System.EventArgs e)
		{
			kb_tieuhoa.Text=nor_tieuhoa;
		}

		private void label98_Click(object sender, System.EventArgs e)
		{
			kb_than.Text=nor_than;
		}

		#endregion

		private void butPttt_Click(object sender, System.EventArgs e)
		{
			string stuoi=m.get_tuoivao(l_maql).Trim();
			frmPttt_ba f=new frmPttt_ba(m,s_makp,mabn.Text,hoten.Text,stuoi,phai.Text,diachi.Text,sothe.Text,giuong.Text,ngay.Text,cd_kkb.Text,icd_kkb.Text,"P",i_userid,"","","","","","",0,0,0,0,0,"",0,traituyen);
			f.ShowDialog(this);
			load_pttt();
		}

		private void butChidinh_Click(object sender, System.EventArgs e)
		{
			string stuoi=m.get_tuoivao(l_maql).Trim();
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, mabn.Text, hoten.Text, stuoi, ngayvk.Text + " " + giovk.Text, s_makp, s_tenkp, i_madoituong, 1, l_maql, l_maql, l_idkhoa, i_userid, "nhapkhoa", sothe.Text, "", "", (s_mabs != "") ? s_mabs : mabsnb.Text, cd_kkb.Text, bAdmin, traituyen);
			f.ShowDialog(this);
			load_chidinh();
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
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
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
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giorv.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) list.Focus();
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
				if (chkXML.Checked) dsxml.WriteXml("..\\xml\\page234.xml",XmlWriteMode.WriteSchema);
			}
			switch (loai)
			{
				case 0: page_1();break;
				case 1: page_2(dsxml);break;
				case 2: page_3(dsxml);break;
				case 3: page_4(dsxml);break;
			}
		}
		private void page_1()
		{
			string tenfile="BenhAnNgoaiKhoa",m_manuoc="",m_tennuoc="",stuoi=m.get_tuoivao(l_maql).Trim(),m_songaydt="",m_cd_noichuyenden="",m_icd_noichuyenden="",m_tdvh="",m_ngaybong="";
			string m_songaydieutrivaokhoa="",m_chuyenkhoa1="",m_ngaychuyenkhoa1="",m_songaydieutrichuyenkhoa1="",m_chuyenkhoa2="",m_ngaychuyenkhoa2="",m_songaydieutrichuyenkhoa2="";
			string m_chuyenkhoa3="",m_ngaychuyenkhoa3="",m_songaydieutrichuyenkhoa3="",m_ngaytuvong="",m_tinhtrangtuvong="",m_thoidiemtuvong="",m_nguyennhantuvong="",m_icdnguyennhantuvong="";
			string m_cokhamnghiemtuthi="",m_chandoantuthi="",m_icdchandoantuthi="",m_nguyennhantaibienbienchung="",m_tongsongaydieutrisauphauthuat="",m_tongsolanphauthuat="",m_chandoantruocphauthuat="";
			string m_icdchandoantruocphauthuat="",m_chandoansauphauthuat="",m_icdchandoansauphauthuat="",m_tinhtrangphauthuat="",m_ngoithai="",m_phuongphapphauthuat="",m_loaithai="",m_gioitinhtre="",m_treconsong="",m_trecoditat="",m_trecannang="";
			string nhi_hoten_bo="",nhi_vanhoa_bo="",nhi_tennn_bo="",nhi_hoten_me="",nhi_vanhoa_me="",nhi_tennn_me="";
			string mame="",ss_hoten_me="",ss_ns_me="",ss_tennn_me="",ss_delan="",ss_hoten_bo="",ss_ns_bo="",ss_tennn_bo="",ss_nhommau="",para="",ss_para1="",ss_para2="",ss_para3="",ss_para4="";
			string m_ngayde="",m_cachthucde="",m_kiemsoat="",t_v="",n_v="",m_v="",giaidoan_v="",t_r="",n_r="",m_r="",giaidoan_r="",ss_mann_bo="",ss_mann_me="",nhi_mann_bo="",nhi_mann_me="";
			sql="select a.makp,b.soluutru,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,";
			sql+="to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh,c.phai,c.sonha,c.thon,c.matt,c.maqu,c.maphuongxa,c.mann,d.tennn,c.madantoc,e.dantoc as tendantoc,";
			sql+="f.tentt,g.tenquan,h.tenpxa,c.cholam,a.madoituong,i.sothe,to_char(i.denngay,'dd/mm/yyyy') as denngay,";
			sql+="j.hoten as qh_hoten,j.dienthoai as qh_dienthoai,a.lanthu,a.nhantu,a.dentu,";
			sql+="nvl(m.loaibv,0) as loaibv,n.tenbv,nvl(b.ttlucrv,0) as ttlucrv,a.chandoan as chandoanvv,a.maicd as maicdvv,";
			sql+="b.chandoan as chandoanrv,b.maicd as maicdrv,b.taibien,b.bienchung,b.giaiphau,nvl(b.ketqua,0) as ketqua,";
			sql+="nvl(s.ten,b.giaiphau) as giaiphau,t.chandoan as chandoannn,t.maicd as maicdnn, i.traituyen ";
			sql+=" from benhandt a,xuatvien b,btdbn c,btdnn_bv d,btddt e,btdtt f,btdquan g,btdpxa h,bhyt i,";
			sql+=" quanhe j,chuyenvien m,tenvien n,gphaubenh s,cdnguyennhan t";
			sql+=" where a.maql=b.maql(+) and a.mabn=c.mabn and c.mann=d.mann and c.madantoc=e.madantoc ";
			sql+=" and c.matt=f.matt and c.maqu=g.maqu and c.maphuongxa=h.maphuongxa ";
			sql+=" and a.maql=i.maql(+) and a.maql=j.maql(+) and a.maql=m.maql(+) and m.mabv=n.mabv(+) ";
			sql+=" and b.giaiphau=s.ma(+) and b.maql=t.maql(+)";
			sql+=" and a.loaiba=1 and a.maql="+l_maql;
			DataSet ds1=m.get_data(sql);
			DataRow r2=m.getrowbyid(dtba,"MAVT='"+tenba.SelectedValue.ToString()+"'");
			if (r2!=null) tenfile=r2["tenfile"].ToString();
			if (ds1.Tables[0].Rows.Count==0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (chkXML.Checked) ds1.WriteXml("..\\xml\\page1.xml",XmlWriteMode.WriteSchema);
				foreach(DataRow r in ds1.Tables[0].Rows)
				{
					if (r["ngayrv"].ToString()!="") m_songaydt=m.songay(m.StringToDate(r["ngayrv"].ToString()),m.StringToDate(r["ngayvv"].ToString()),1).ToString();
					if (m.get_data("select * from chuyenkhoa where maql="+l_maql).Tables[0].Rows.Count!=0)
					{
						DataTable dtck=new DataTable();
						dtck=m.get_data("select khoaden,to_char(ngaychuyen,'dd/mm/yyyy hh24:mi') as ngaychuyen from chuyenkhoa where maql="+l_maql+" order by ngaychuyen").Tables[0];
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
					if (dspt.Tables[0].Rows.Count>0)
					{
						DataTable dtpt=new DataTable();
						dtpt=m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,chandoant,maicdt,chandoans,maicds,tenpt,tinhhinh,taibien,tuvong from pttt where maql="+l_maql+" order by ngay").Tables[0];
						m_nguyennhantaibienbienchung=dtpt.Rows[0]["taibien"].ToString();
						m_tinhtrangphauthuat=dtpt.Rows[0]["tinhhinh"].ToString();
						m_thoidiemtuvong=dtpt.Rows[0]["tuvong"].ToString();
						m_tongsolanphauthuat=dtpt.Rows.Count.ToString();
						m_chandoantruocphauthuat=dtpt.Rows[0]["chandoant"].ToString();
						m_icdchandoantruocphauthuat=m.Maicd_rpt(dtpt.Rows[0]["maicdt"].ToString());
						m_chandoansauphauthuat=dtpt.Rows[0]["chandoans"].ToString();
						m_icdchandoansauphauthuat=m.Maicd_rpt(dtpt.Rows[0]["maicds"].ToString());
						m_phuongphapphauthuat=dtpt.Rows[0]["tenpt"].ToString();
						if (r["ngayrv"].ToString()!="") m_tongsongaydieutrisauphauthuat=m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0,10)),m.StringToDate(dtpt.Rows[0]["ngay"].ToString().Substring(0,10)),1).ToString();
					}

					if (tenba.SelectedValue.ToString()=="BSA")
					{
						if (m.get_data("select * from tresosinh where maql="+l_maql).Tables[0].Rows.Count!=0)
						{
							DataTable dtss=new DataTable();
							dtss=m.get_data("select ngoithai,phai,decode(tinhtrang,0,1,0) as tinhtrang,ditat,cannang from tresosinh where maql="+l_maql+" order by ngay").Tables[0];
							m_loaithai=dtss.Rows.Count.ToString();
							m_ngoithai=dtss.Rows[0]["ngoithai"].ToString();
							m_gioitinhtre=dtss.Rows[0]["phai"].ToString();
							m_treconsong=dtss.Rows[0]["tinhtrang"].ToString();
							m_trecoditat=dtss.Rows[0]["ditat"].ToString();
							m_trecannang=dtss.Rows[0]["cannang"].ToString();
						}
					}
					if (m.get_data("select * from tuvong where maql="+l_maql).Tables[0].Rows.Count!=0)
					{
						m_ngaytuvong=r["ngayrv"].ToString();
						DataTable dttv=new DataTable();
						dttv=m.get_data("select chandoan,maicd,nguyennhan,benhly,khamtuthi from tuvong where maql="+l_maql).Tables[0];
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
					foreach(DataRow r1 in m.get_data("select * from noigioithieu where maql="+l_maql).Tables[0].Rows)
					{
						m_cd_noichuyenden=r1["chandoan"].ToString();
						m_icd_noichuyenden=r1["maicd"].ToString();
					}

					if (r["madantoc"].ToString()=="55")
					{
						foreach(DataRow r1 in m.get_data("select a.ma,a.ten from dmquocgia a,nuocngoai b where a.ma=b.id_nuoc and b.mabn='"+mabn.Text+"'").Tables[0].Rows)
						{
							m_manuoc=r1["ma"].ToString();
							m_tennuoc=r1["ten"].ToString();
							break;
						}
					}
					if (tenba.SelectedValue.ToString()=="BBO")
					{
						foreach(DataRow r1 in m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from ttbong where maql="+l_maql).Tables[0].Rows)
						{
							m_ngaybong=r1["ngay"].ToString();
							break;
						}
					}
					else if (tenba.SelectedValue.ToString()=="BTH")
					{
						foreach(DataRow r1 in m.get_data("select vanhoa from tttamthan where maql="+l_maql).Tables[0].Rows)
						{
							m_tdvh=r1["vanhoa"].ToString();
							break;
						}
					}
					else if ((tenba.SelectedValue.ToString()=="BNH" || tenba.SelectedValue.ToString()=="BMT"))
					{
						foreach(DataRow r1 in m.get_data("select a.*,b.tennn as bo,c.tennn as me from hcnhi a,btdnn_bv b,btdnn_bv c where a.mann_bo=b.mann(+) and a.mann_me=c.mann(+) and a.mabn='"+mabn.Text+"'").Tables[0].Rows)
						{
							nhi_hoten_bo=r1["hoten_bo"].ToString();
							nhi_vanhoa_bo=r1["vanhoa_bo"].ToString();
							nhi_tennn_bo=r1["bo"].ToString();
							nhi_hoten_me=r1["hoten_me"].ToString();
							nhi_vanhoa_me=r1["vanhoa_me"].ToString();
							nhi_tennn_me=r1["me"].ToString();
							nhi_mann_bo=r1["mann_bo"].ToString();
							nhi_mann_me=r1["mann_me"].ToString();
						}
					}
					else if (tenba.SelectedValue.ToString()=="BSO")
					{
						foreach(DataRow r1 in m.get_data("select a.*,b.tennn as bo,c.tennn as me,d.ten as mau from hcsosinh a,btdnn_bv b,btdnn_bv c,dmnhommau d where a.mann_bo=b.mann(+) and a.mann_me=c.mann(+) and a.nhommau=d.ma and a.mabn='"+mabn.Text+"'").Tables[0].Rows)
						{
							mame=r1["mame"].ToString();
							ss_mann_bo=r1["mann_bo"].ToString();
							ss_mann_me=r1["mann_me"].ToString();
							ss_hoten_me=r1["hoten_me"].ToString();
							ss_ns_me=r1["ns_me"].ToString();
							ss_tennn_me=r1["me"].ToString();
							ss_delan=r1["delan"].ToString();
							ss_hoten_bo=r1["hoten_bo"].ToString();
							ss_ns_bo=r1["ns_bo"].ToString();
							ss_tennn_bo=r1["bo"].ToString();
							ss_nhommau=r1["mau"].ToString();
							para=r1["para"].ToString();
							if (para.Length==8)
							{
								ss_para1=para.Substring(0,2);
								ss_para2=para.Substring(2,2);
								ss_para3=para.Substring(4,2);
								ss_para4=para.Substring(6,2);
							}
						}
					}
					else if (tenba.SelectedValue.ToString()=="BSA")
					{
						m_ngayde=ngayde.Text+" "+giode.Text;
						m_cachthucde=ppde.Text;
						m_kiemsoat=(kiemsoattc.Checked)?"1":"0";
//						foreach(DataRow r1 in m.get_data("select a.*,b.ten from cdsankhoa a,dmkieusanh b where a.cachthucde=b.ma and a.maql="+l_maql).Tables[0].Rows)
//						{
//							m_ngayde=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r1["ngay"].ToString()));
//							m_cachthucde=r1["ten"].ToString();
//							m_kiemsoat=r1["kiemsoat"].ToString();
//						}
					}
					else if (tenba.SelectedValue.ToString()=="BUN")
					{
						foreach(DataRow r1 in m.get_data("select * from cdungbuou where maql="+l_maql).Tables[0].Rows)
						{
							t_v=r1["t_v"].ToString();
							n_v=r1["n_v"].ToString();
							m_v=r1["m_v"].ToString();
							giaidoan_v=r1["giaidoan_v"].ToString();
							t_r=r1["t_r"].ToString();
							n_r=r1["n_r"].ToString();
							m_r=r1["m_r"].ToString();
							giaidoan_r=r1["giaidoan_r"].ToString();
							break;
						}
					}
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds1,tenfile,tenba.SelectedValue.ToString(),s_tenkp,giuong.Text,r["soluutru"].ToString(),m.Mabv+"/"+mabn.Text.Substring(0,2)+"/"+mabn.Text.Substring(2),hoten.Text,r["ngaysinh"].ToString(),(stuoi.Substring(3)=="0")?stuoi.Substring(1,3):"000",r["phai"].ToString(),
					r["tennn"].ToString(),r["mann"].ToString(),r["tendantoc"].ToString(),r["madantoc"].ToString(),m_tennuoc,m_manuoc,r["sonha"].ToString(),r["thon"].ToString(),
					r["tenpxa"].ToString(),r["tenquan"].ToString(),r["maqu"].ToString(),r["tentt"].ToString(),r["matt"].ToString(),r["cholam"].ToString(),r["madoituong"].ToString(),
					r["denngay"].ToString(),r["sothe"].ToString(),r["qh_hoten"].ToString(),r["qh_dienthoai"].ToString(),m_ngaybong,r["ngayvv"].ToString(),
					r["nhantu"].ToString(),r["dentu"].ToString(),r["lanthu"].ToString(),r["makp"].ToString(),ngayvk.Text+" "+giovk.Text,
					m_songaydieutrivaokhoa,m_chuyenkhoa1,m_ngaychuyenkhoa1,m_songaydieutrichuyenkhoa1,m_chuyenkhoa2,m_ngaychuyenkhoa2,m_songaydieutrichuyenkhoa2,m_chuyenkhoa3,m_ngaychuyenkhoa3,m_songaydieutrichuyenkhoa3,
					r["loaibv"].ToString(),r["tenbv"].ToString(),r["ngayrv"].ToString(),r["ttlucrv"].ToString(),m_songaydt,
					m_cd_noichuyenden,m.Maicd_rpt(m_icd_noichuyenden),r["chandoanvv"].ToString(),m.Maicd_rpt(r["maicdvv"].ToString()),
					cd_kkb.Text,m.Maicd_rpt(icd_kkb.Text),"0","0",r["chandoanrv"].ToString(),
					m.Maicd_rpt(r["maicdrv"].ToString()),"","",
					r["taibien"].ToString(),r["bienchung"].ToString(),r["ketqua"].ToString(),r["giaiphau"].ToString(),m_ngaytuvong,m_tinhtrangtuvong,m_thoidiemtuvong,
					m_nguyennhantuvong,m_icdnguyennhantuvong,m_cokhamnghiemtuthi,m_chandoantuthi,m_icdchandoantuthi,m_nguyennhantaibienbienchung,m_tongsongaydieutrisauphauthuat,
					m_tongsolanphauthuat,r["chandoannn"].ToString(),m.Maicd_rpt(r["maicdnn"].ToString()),m_chandoantruocphauthuat,m_icdchandoantruocphauthuat,m_chandoansauphauthuat,
					m_icdchandoansauphauthuat,m_tinhtrangphauthuat,m_tdvh,(tenba.SelectedValue.ToString()=="BSO")?ss_hoten_bo:nhi_hoten_bo,
					(tenba.SelectedValue.ToString()=="BSO")?ss_mann_bo:nhi_mann_bo,nhi_vanhoa_bo,(tenba.SelectedValue.ToString()=="BSO")?ss_hoten_me:nhi_hoten_me,
					(tenba.SelectedValue.ToString()=="BSO")?ss_mann_me:nhi_mann_me,nhi_vanhoa_me,ss_ns_me,
					ss_mann_me,ss_delan,ss_ns_bo,ss_mann_bo,ss_nhommau,ss_para1+ss_para2+ss_para3+ss_para4,
					m_ngayde,m_ngoithai,m_cachthucde,m_kiemsoat,"",m_phuongphapphauthuat,m_loaithai,m_gioitinhtre,m_treconsong,
					m_trecoditat,"",m_trecannang,t_v,n_v,m_v,giaidoan_v,t_r,n_r,m_r,giaidoan_r);
					f.ShowDialog();
				}
			}
		}

		private void page_2(DataSet ds1)
		{
			if (ds1.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds1,"","rPage34.rpt");
				f.ShowDialog();
			}
		}
		private void page_3(DataSet ds1)
		{
			if (ds1.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds1,"","rPage35.rpt");
				f.ShowDialog();
			}
		}
		private void page_4(DataSet ds1)
		{
			if (ds1.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds1,"","rPage36.rpt");
				f.ShowDialog();
			}
		}

		private DataSet get_data()
		{
			string c01="",c02="",c03="",c04="",xn01="",xn02="",xn03="",xn04="",xn05="";
			string ts01="",ts02="",ts03="",ts04="",ts05="",ts06="",ts07="",ts08="",ts09="",ts10="",ts11="",ts12="",ts13="",ts14="",ts15="";
			foreach(DataRow r in dscd.Tables[0].Rows)
			{
				xn01+=r["ngay"].ToString().Trim()+"\n";
				xn02+=r["tenkp"].ToString().Trim()+"\n";
				xn03+=r["tenbs"].ToString().Trim()+"\n";
				xn04+=r["ten"].ToString().Trim()+"\n";
				xn05+=r["ketqua"].ToString().Trim()+"\n";
			}
			foreach(DataRow r in dspt.Tables[0].Rows)
			{
				c01+=r["ngay"].ToString().Trim()+"\n";
				c02+=r["ten"].ToString().Trim()+"\n";
				c03+=r["tenbs"].ToString().Trim()+"\n";
				c04+=r["gayme"].ToString().Trim()+"\n";
			}
			foreach(DataRow r in dsts.Tables[0].Rows)
			{
				ts01+=r["stt"].ToString();
				ts02+=r["nam"].ToString();
				ts03+=r["du"].ToString();
				ts04+=r["thieu"].ToString();
				ts05+=r["say"].ToString();
				ts06+=r["hut"].ToString();
				ts07+=r["nao"].ToString();
				ts08+=r["covac"].ToString();
				ts09+=r["ngoai"].ToString();
				ts10+=r["trung"].ToString();
				ts11+=r["chet"].ToString();
				ts12+=r["song"].ToString();
				ts13+=r["cannang"].ToString();
				ts14+=r["ten"].ToString();
				ts15+=r["taibien"].ToString();
			}

			string ss01="",ss02="",ss03="",ss04="",ss05="",ss06="",ss07="",ss08="",ss09="",ss10="",ss11="",ss12="",ss13="",ss14="",ss15="",ss16="";
			int sothai=dstress.Tables[0].Rows.Count;
			if (sothai>0)
			{
				foreach(DataRow r in dstress.Tables[0].Rows)
				{
					ss01=r["ngay"].ToString();
					ss02=r["apgar1"].ToString();
					ss03=r["apgar5"].ToString();
					ss04=r["apgar10"].ToString();
					ss05=r["cannang"].ToString();
					ss06=r["cao"].ToString();
					ss07=r["vongdau"].ToString();
					if (sothai>1)
					{
						ss10=dstress.Tables[0].Select("phai=0").Length.ToString();
						ss11=dstress.Tables[0].Select("phai=1").Length.ToString();
					}
					else
					{
						ss08=dstress.Tables[0].Select("phai=0").Length.ToString();
						ss09=dstress.Tables[0].Select("phai=1").Length.ToString();
					}
					ss12=r["ditat"].ToString();
					ss14=r["tenditat"].ToString();
					ss15=(r["tinhtrang"].ToString()=="0")?"Sống":"Chết";
					ss16=r["xuly"].ToString();
					break;
				}
			}
			sql="select a.*,b.mach,b.nhietdo,b.huyetap,b.nhiptho,b.cannang,'' as c01,'' as c02,'' as c03,'' as c04,";
			sql+="'' as xn01,'' as xn02,'' as xn03,'' as xn04,'' as xn05,";
			sql+="'' as chandoan,'' as chandoankem,'' as bacsiba,0 as pt,0 as tt,'' as tennguoigiao,'' as tennguoinhan,'' as bacsi,";
			sql+="'' as ngayba,'' as ngaydt,0 as xq,0 as ct,0 as sa,0 as xn,0 as stkhac,'' as loaikhac,0 as tong,";
			sql+="0 as k01,0 as k02,0 as k03,0 as k04,0 as k05,0 as k06,'' as t01,'' as t02,'' as t03,'' as t04,'' as t05,'' as t06,";
			sql+="to_char(c.tungay,'dd/mm/yyyy') as tungay,to_char(c.denngay,'dd/mm/yyyy') as denngay,c.tuoithai,c.khamthai,c.uonvan,";
			sql+="c.tiem,to_char(c.chuyenda,'dd/mm/yyyy hh24:mi') as chuyenda,c.dauhieu,c.bienchuyen,c.kinhnam,c.tinhchat,c.chuky,c.luongkinh,";
			sql+="c.chongnam,c.dieutri as dadieutri,c.phu,c.ptcu,c.dangtc,c.tuthe,c.caotc,c.vongbung,c.cotc,c.timthai,c.vu,c.bishop,";
			sql+="c.amho,c.amdao,c.sinhmon,c.tucung,c.phanphu,c.tinhtrangoi,to_char(c.voluc,'dd/mm/yyyy hh24:mi') as voluc,c.oivo,c.mausac,";
			sql+="c.nuocoi,c.ngoi,c.the,c.kieu,c.dolot,c.have,to_char(c.deluc,'dd/mm/yyyy hh24:mi') as deluc,c.theodoi,c.chucdanh,c.rau,";
			sql+="to_char(c.rauluc,'dd/mm/yyyy hh24:mi') as rauluc,c.cachso,c.mang,c.mui,c.banhrau,c.raucannang,c.raucuon,c.raudai,c.chaymau,";
			sql+="c.maumat,c.kiemsoattc,c.xuly,c.da,' ' as ppde,c.mach as sd_mach,c.nhietdo as sd_nhietdo,c.huyetap as sd_huyetap,c.nhiptho as sd_nhiptho,";
			sql+="c.canthiep,c.tangsinhmon,c.loaichi,c.somui,c.cotucung,c.cao,";
			sql+="' ' as ts01,' ' as ts02,' ' as ts03,' ' as ts04,' ' as ts05,' ' as ts06,' ' as ts07,' ' as ts08,' ' as ts09,' ' as ts10,' ' as ts11,' ' as ts12,' ' as ts13,' ' as ts14,' ' as ts15,";
			sql+="' ' as ss01,' ' as ss02,' ' as ss03,' ' as ss04,' ' as ss05,' ' as ss06,' ' as ss07,' ' as ss08,' ' as ss09,' ' as ss10,' ' as ss11,' ' as ss12,' ' as ss13,' ' as ss14,' ' as ss15,' ' as ss16,";
			sql+="' ' as taibien,0 as bienchung,' ' as chandoant,' ' as chandoans ";
			sql+=" from "+xxx+".ba_chung a,"+xxx+".ba_kbdausinhton b,"+xxx+".ba_sankhoa c where a.id=b.id and a.id=c.id and a.id="+l_id;
			DataSet ds1=m.get_data(sql);				
			bool bFile=false,bFiledt=false,bF1=false,bF2=false;
			if (ds1.Tables[0].Rows.Count!=0)
			{
				DataColumn dc = new DataColumn("Image", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
				dc = new DataColumn("Imagedt", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
				dc = new DataColumn("pic1", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
				dc = new DataColumn("pic2", typeof(byte[]));
				ds1.Tables[0].Columns.Add(dc);
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabsnb.Text+"'");
				bFile=r1!=null;
				if (bFile)
				{
					image =new byte[0];
					image =(byte[])(r1["image"]);
				}
				if (mabs.Text!="")
				{
					r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
					bFiledt=r1!=null;
					if (bFiledt)
					{
						imagedt =new byte[0];
						imagedt =(byte[])(r1["image"]);
					}
				}				

				foreach(DataRow r2 in m.get_data("select * from "+xxx+".ba_hinh where id="+l_id+" order by stt").Tables[0].Rows)
				{
					if (int.Parse(r2["stt"].ToString())==1)
					{
						bF1=true;
						image1 =new byte[0];
						image1 =(byte[])(r2["image"]);
					}
					else
					{
						bF2=true;
						image2 =new byte[0];
						image2 =(byte[])(r2["image"]);
					}
				}
				foreach(DataRow r in ds1.Tables[0].Rows)
				{
					r["chandoan"]=cd_kkb.Text;
					r["chandoankem"]="";
					r["xn01"]=xn01;r["xn02"]=xn02;
					r["xn03"]=xn03;r["xn04"]=xn04;r["xn05"]=xn05;
					r["c01"]=c01;r["c02"]=c02;
					r["c03"]=c03;r["c04"]=c04;
					r["chandoant"]=chandoan_t.Text;
					r["chandoans"]=chandoan_s.Text;
					r["taibien"]=taibien.Text;
					r["bienchung"]=(bienchung.Checked)?1:0;
					r["bacsiba"]=tenbsnb.Text;
					r["bacsi"]=tenbs.Text;
					r["ngayba"]=ngayvk.Text+" "+giovk.Text;
					r["ngaydt"]=ngayrv.Text+" "+giorv.Text;
					r["tennguoigiao"]=nguoigiao.Text;
					r["tennguoinhan"]=nguoinhan.Text;
					r["xq"]=st1.Value;	r["ct"]=st2.Value;
					r["sa"]=st3.Value;	r["xn"]=st4.Value;
					r["loaikhac"]=khac.Text;r["stkhac"]=st5.Value;
					r["ppde"]=ppde.Text;
					r["theodoi"]=tentheodoi.Text;
					r["tong"]=st6.Value;
					r["ts01"]=ts01;r["ts02"]=ts02;r["ts03"]=ts03;r["ts04"]=ts04;r["ts05"]=ts05;r["ts06"]=ts06;r["ts07"]=ts07;
					r["ts08"]=ts08;r["ts09"]=ts09;r["ts10"]=ts10;r["ts11"]=ts11;r["ts12"]=ts12;r["ts13"]=ts13;r["ts14"]=ts14;r["ts15"]=ts15;
					r["ss01"]=ss01;r["ss02"]=ss02;r["ss03"]=ss03;r["ss04"]=ss04;r["ss05"]=ss05;r["ss06"]=ss06;r["ss07"]=ss07;r["ss08"]=ss08;
					r["ss09"]=ss09;r["ss10"]=ss10;r["ss11"]=ss11;r["ss12"]=ss12;r["ss13"]=ss13;r["ss14"]=ss14;r["ss15"]=ss15;r["ss16"]=ss16;
					if (bFile) r["image"]=image;
					if (bFiledt) r["imagedt"]=imagedt;
					if (bF1) r["pic1"]=image1;
					if (bF2) r["pic2"]=image2;
				}
			}
			return ds1;
		}
		#endregion

		private void butChuyenphong_Click(object sender, System.EventArgs e)
		{
			frmChuyenphong f1=new frmChuyenphong(m,ngayvk.Text,s_makp,s_tenkp,i_userid,mabn.Text,l_idkhoa);
			f1.ShowDialog(this);
			int idgiuong=f1.idgiuong;
			if (idgiuong!=0)
			{
				foreach(DataRow r in m.get_data("select a.ma as phong,b.ma as giuong from dmphong a,dmgiuong b where a.id=b.idphong and b.id="+idgiuong).Tables[0].Rows)
				{
					phong.Text=r["phong"].ToString();
					giuong.Text=r["giuong"].ToString();
					break;
				}
				DataRow r1=m.getrowbyid(ds.Tables[0],"mabn='"+mabn.Text+"'");
				if (r1!=null)
				{
					r1["phong"]=phong.Text;
					r1["giuong"]=giuong.Text;
				}
			}
		}

		private void butDieutri_Click(object sender, System.EventArgs e)
		{
			frmTodieutri f=new frmTodieutri(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin,true,l_id,ds,i_madoituong);
			f.ShowDialog(this);
			if (f.bUpdate) load_sankhoa();
		}

		private void load_sankhoa()
		{
			string _ngay="";
			DataRow r1;
			foreach(DataRow r in m.get_data("select * from "+xxx+".ba_sankhoa where id="+l_id).Tables[0].Rows)
			{
				bishop.Text=(r["bishop"].ToString()!="0")?r["bishop"].ToString():"";
				amho.Text=r["amho"].ToString();
				amdao.Text=r["amdao"].ToString();
				sinhmon.Text=r["sinhmon"].ToString();
				tucung.Text=r["tucung"].ToString();
				phanphu.Text=r["phanphu"].ToString();
				tinhtrangoi.SelectedIndex=int.Parse(r["tinhtrangoi"].ToString());
				if (r["voluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["voluc"].ToString()));
					ngayvo.Text=_ngay.Substring(0,10);
					giovo.Text=_ngay.Substring(11);
				}
				oivo.SelectedIndex=int.Parse(r["oivo"].ToString());
				mausac.Text=r["mausac"].ToString();
				nuocoi.Text=r["nuocoi"].ToString();
				ngoi.Text=r["ngoi"].ToString();
				the.Text=r["the"].ToString();
				kieu.Text=r["kieu"].ToString();
				dolot.SelectedIndex=int.Parse(r["dolot"].ToString());
				have.Text=r["have"].ToString();
				if (r["deluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["deluc"].ToString()));
					ngayde.Text=_ngay.Substring(0,10);
					giode.Text=_ngay.Substring(11);
				}
				theodoi.Text=r["theodoi"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r1!=null) tentheodoi.Text=r1["hoten"].ToString();
				chucdanh.Text=r["chucdanh"].ToString();
				rau.SelectedIndex=int.Parse(r["rau"].ToString());
				if (r["rauluc"].ToString()!="")
				{
					_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["rauluc"].ToString()));
					ngayrau.Text=_ngay.Substring(0,10);
					giorau.Text=_ngay.Substring(11);
				}
				cachso.Text=r["cachso"].ToString();
				mang.Text=r["mang"].ToString();
				mui.Text=r["mui"].ToString();
				banhrau.Text=r["banhrau"].ToString();
				raucannang.Text=(r["raucannang"].ToString()!="0")?r["raucannang"].ToString():"";
				raucuon.Checked=r["raucuon"].ToString()=="1";
				raudai.Text=(r["raudai"].ToString()!="0")?r["raudai"].ToString():"";
				chaymau.Checked=r["chaymau"].ToString()=="1";
				maumat.Text=(r["maumat"].ToString()!="0")?r["maumat"].ToString():"";
				maumat.Enabled=chaymau.Checked;
				kiemsoattc.Checked=r["kiemsoattc"].ToString()=="1";
				xuly.Text=r["xuly"].ToString();
				da.Text=r["da"].ToString();
				ppde.SelectedValue=r["ppde"].ToString();
				sd_mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				sd_nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				sd_huyetap.Text=r["huyetap"].ToString();
				sd_nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				canthiep.Text=r["canthiep"].ToString();
				tangsinhmon.SelectedIndex=int.Parse(r["tangsinhmon"].ToString());
				loaichi.Text=r["loaichi"].ToString();
				somui.Text=(r["somui"].ToString()!="0")?r["somui"].ToString():"";
				loaichi.Enabled=tangsinhmon.SelectedIndex==2;
				somui.Enabled=loaichi.Enabled;
				cotucung.SelectedIndex=int.Parse(r["cotucung"].ToString());
				break;
			}
			load_tresosinh();
		}

		private void butChamsoc_Click(object sender, System.EventArgs e)
		{
			frmChamsoc f=new frmChamsoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butPhanung_Click(object sender, System.EventArgs e)
		{
			frmPuthuoc f=new frmPuthuoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butDich_Click(object sender, System.EventArgs e)
		{
			frmTruyendich f=new frmTruyendich(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butMau_Click(object sender, System.EventArgs e)
		{
			frmTruyenmau f=new frmTruyenmau(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
			f.ShowDialog(this);
		}

		private void butDausinhton_Click(object sender, System.EventArgs e)
		{
			frmDausinhton f=new frmDausinhton(m,s_makp,mabn.Text);
			f.ShowDialog(this);
		}

		private void frmHSBenhan_BSA_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
					if (list.Enabled) get_mabn(list.SelectedValue.ToString());
					break;
				case Keys.F6:
					if (butChon.Enabled) butChon_Click(sender,e);
					break;
				case Keys.F10:
					if (butKethuc.Enabled) butKethuc_Click(sender,e);
					break;
			}		
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			if ((xem.SelectedIndex==10 || xem.SelectedIndex==0) && (l_id==0))
			{
				if (!kiemtra()) return;
				xxx=user+m.mmyy(ngay.Text);
				bool bNhapkhoa=m.getrowbyid(ds.Tables[0],"nhapkhoa=0 and mabn='"+mabn.Text+"'")!=null;
				if (bNhapkhoa) upd_nhapkhoa();
				m.execute_data("update benhandt set mabs='"+mabsnb.Text+"' where maql="+l_maql);
				l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
				if (l_idthuchien==0) 
				{
					l_idthuchien=m.get_capid(-300);
					m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
				}
				l_id=m.get_idchung(ngay.Text,l_idthuchien);
				if (l_id==0) l_id=m.get_capid(-301);
                m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, lanthu.Value, "", hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
					kb_hohap.Text,kb_tieuhoa.Text,kb_than.Text,"","","","","","",kb_khac.Text,"",phanbiet.Text,
					tienluong.Text,dieutri.Text,mabsnb.Text,"","","","",tk_dieutri.Text,manguoigiao.Text,manguoinhan.Text,mabs.Text,i_userid);
			}
			if (xem.SelectedIndex==8 && i_loai==1) return;
			switch (xem.SelectedIndex)
			{
				case 0:frmHoichancc f0=new frmHoichancc(m,ds,0,l_idthuchien,mabn.Text,s_makp,s_tenkp,i_userid,bAdmin,ngay.Text);
					f0.ShowDialog(this);
					break;
				case 1:frmKiemsoatcc f1=new frmKiemsoatcc(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
					f1.ShowDialog(this);
					break;
				case 2:frmHoichan f2=new frmHoichan(m,ds,0,l_idthuchien,mabn.Text,s_makp,s_tenkp,i_userid,bAdmin,ngay.Text);
					f2.ShowDialog(this);
					break;
				case 3:frmKiemsoat f3=new frmKiemsoat(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
					f3.ShowDialog(this);
					break;
				case 4:frmHcthuoc f4=new frmHcthuoc(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f4.ShowDialog(this);
					break;
				case 5:frmDanhgia f5=new frmDanhgia(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f5.ShowDialog(this);
					break;
				case 6:frmCamdoan f6=new frmCamdoan(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f6.ShowDialog(this);
					break;
				case 7:frmLinhmau f7=new frmLinhmau(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f7.ShowDialog(this);
					break;
				case 8:frmGiaonhan f8=new frmGiaonhan(m,mabn.Text,l_maql,l_idkhoa,l_idthuchien,l_id,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
						f8.ShowDialog(this);
						break;
				case 9:frmSoket f9=new frmSoket(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f9.ShowDialog(this);
					break;
				case 10:frmBascan f10=new frmBascan(m,0,mabn.Text,l_maql,l_idkhoa,l_id,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
						f10.ShowDialog(this);
					break;
				case 11:frmBasosinh f11=new frmBasosinh(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_userid,chandoan.Text,s_tenkp,bAdmin);
						f11.ShowDialog(this);
					break;
				case 12:frmBahausangan f12=new frmBahausangan(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_userid,chandoan.Text,s_tenkp,bAdmin);
						f12.ShowDialog(this);
					break;
				case 13:frmBahausan f13=new frmBahausan(m,mabn.Text,l_maql,l_idkhoa,s_sovaovien,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngay.Text,sothe.Text,phong.Text,giuong.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10),s_mabs,i_userid,s_userid,chandoan.Text,s_tenkp,bAdmin);
					f13.ShowDialog(this);
					break;
                case 14: frmXemthuoc f14 = new frmXemthuoc(m, l_maql, hoten.Text, ngay.Text, ngayrv.Text);
						f14.ShowDialog(this);
						break;
				case 15:frmCongkhaiMabn f15=new frmCongkhaiMabn(mabn.Text);
						f15.ShowDialog(this);
						break;
				case 16:frmCongnoMabn f16=new frmCongnoMabn(m,mabn.Text,l_maql,ngay.Text,(ngayrv.Text.Trim().Length==10)?ngayrv.Text:m.ngayhienhanh_server.Substring(0,10));
						f16.ShowDialog(this);
						break;
				case 17:if (rb1.Checked)
						{
							frmXuatkhoa f17=new frmXuatkhoa(m,s_makp,s_userid,i_userid,0,b_sovaovien,b_soluutru,"",mabn.Text,tenba.SelectedValue.ToString());
							f17.ShowDialog(this);
						}
						break;
			}
		}

		private void butKethuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void rb1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==rb1) load_list();
		}

		private void rb2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==rb2) load_list();
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
				Filt_dmbs(tenbsnb.Text);
				listNv.BrowseToDanhmuc(tenbsnb,mabsnb,tenbsnb_pass,35);
			}		
		}

		private void pic1_DoubleClick(object sender, System.EventArgs e)
		{
			if (butLuu.Enabled && bHinh) edit_pic(pic1,1);
		}

		private void edit_pic(PictureBox pic,int i)
		{
			bHinh=true;
			string sDir=System.Environment.CurrentDirectory.ToString(),tenfile="..\\pict_ba\\"+pic.Name.ToString()+".bmp";
			if (File.Exists((i==1)?f1:f2))
			{
				frmPaint f=new frmPaint((i==1)?f1:f2);
				f.ShowDialog(this);
				f.Save_image(tenfile);
				fstr=new System.IO.FileStream(tenfile,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image=new byte[fstr.Length];
				fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
				pic.Tag=image;
				map=new Bitmap(Image.FromStream(fstr));
				pic.Image=(Bitmap)map;
				pic.Update();
				fstr.Close();
				get_file(i);
				File.Copy(tenfile,(i==1)?f1:f2,true);
			}
			System.Environment.CurrentDirectory=sDir;
		}

		private void pic2_DoubleClick(object sender, System.EventArgs e)
		{
			if (butLuu.Enabled && bHinh) edit_pic(pic2,2);
		}

		private void get_file(int i)
		{
			if (i==0)
			{
				f1=thumucpic+"\\1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
				f2=thumucpic+"\\2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			}
			else if (i==1) f1=thumucpic+"\\1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			else f2=thumucpic+"\\2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
		}

		private void butPhong_Click(object sender, System.EventArgs e)
		{
			if (m.get_data("select * from theodoigiuong where mabn='"+mabn.Text+"' and makp='"+s_makp+"' and den is null").Tables[0].Rows.Count>0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Đã chọn phòng/giường")+"\n"+
lan.Change_language_MessageText("Nếu muốn chuyển phòng/giường thì chọn phần chuyển phòng giường !"),LibMedi.AccessData.Msg);
				return;
			}
			frmDsgiuong f=new frmDsgiuong(m,s_makp,i_madoituong,false);
			f.ShowDialog();
			if (f.ma!="") giuong.Text=f.ma;
			butLuu.Focus();
		}

		private void ngayvk_Validated(object sender, System.EventArgs e)
		{
			ngayvk.Text=ngayvk.Text.Trim();
			if (ngayvk.Text.Length==6) ngayvk.Text=ngayvk.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayvk.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
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
				MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				giovk.Focus();
				return;
			}
		}

		private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}

		private void chkHinh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkHinh)
			{
				bHinh=chkHinh.Checked;
				if (bHinh)
				{
					sql="select * from ba_hinh where id="+int.Parse(dtba.Rows[tenba.SelectedIndex]["maba"].ToString())+" order by stt";
					dthinh=m.get_data(sql).Tables[0];
					stt1.DataSource=m.get_data(sql).Tables[0];
					stt2.DataSource=m.get_data(sql).Tables[0];
					stt1.Enabled=bHinh;
					stt2.Enabled=bHinh;
					foreach(DataRow r in dthinh.Rows)
					{
						image =new byte[0];
						image =(byte[])(r["image"]);
						memo=new MemoryStream(image);
						map=new Bitmap(Image.FromStream(memo));
						picture((int.Parse(r["stt"].ToString())==1)?pic1:pic2,(int.Parse(r["stt"].ToString())==1)?f1:f2);
					}
				}
				else emp_hinh();
			}
		}

		private void stt1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==stt1 && stt1.SelectedIndex!=-1)
			{
				image =new byte[0];
				image =(byte[])(dthinh.Rows[stt1.SelectedIndex]["image"]);
				memo=new MemoryStream(image);
				map=new Bitmap(Image.FromStream(memo));
				picture(pic1,f1);
			}
		}

		private void stt2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==stt2 && stt2.SelectedIndex!=-1)
			{
				image =new byte[0];
				image =(byte[])(dthinh.Rows[stt2.SelectedIndex]["image"]);
				memo=new MemoryStream(image);
				map=new Bitmap(Image.FromStream(memo));
				picture(pic2,f2);
			}
		}

		private void tenbsnb_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();		
		}

		private void theodoi_Validated(object sender, System.EventArgs e)
		{
			if (theodoi.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
			if (r!=null) tentheodoi.Text=r["hoten"].ToString();
			else tentheodoi.Text="";				
		}

		private void tentheodoi_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentheodoi)
			{
				Filt_dmbs1(tentheodoi.Text);
				listNv1.BrowseToDanhmuc(tentheodoi,theodoi,chucdanh,35);
			}	
		}

		private void tungay_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (tungay.Text!="")
				{
					tungay.Text=tungay.Text.Trim();
					if (tungay.Text.Length==6) tungay.Text=tungay.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(tungay.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						tungay.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void denngay_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (denngay.Text!="")
				{
					denngay.Text=denngay.Text.Trim();
					if (denngay.Text.Length==6) denngay.Text=denngay.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(denngay.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						denngay.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void ngayrau_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayrau.Text!="")
				{
					ngayrau.Text=ngayrau.Text.Trim();
					if (ngayrau.Text.Length==6) ngayrau.Text=ngayrau.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayrau.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayrau.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void ngayde_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayde.Text!="")
				{
					ngayde.Text=ngayde.Text.Trim();
					if (ngayde.Text.Length==6) ngayde.Text=ngayde.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayde.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayde.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void ngayvo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayvo.Text!="")
				{
					ngayvo.Text=ngayvo.Text.Trim();
					if (ngayvo.Text.Length==6) ngayvo.Text=ngayvo.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngayvo.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngayvo.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void ngaychuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngaychuyenda.Text!="")
				{
					ngaychuyenda.Text=ngaychuyenda.Text.Trim();
					if (ngaychuyenda.Text.Length==6) ngaychuyenda.Text=ngaychuyenda.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngaychuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngaychuyenda.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void giochuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giochuyenda.Text!="")
				{
					string sgio=(giochuyenda.Text.Trim()=="")?"00:00":giochuyenda.Text.Trim();
					giochuyenda.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giochuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giochuyenda.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giode_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giode.Text!="")
				{
					string sgio=(giode.Text.Trim()=="")?"00:00":giode.Text.Trim();
					giode.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giode.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giode.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giorau_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giorau.Text!="")
				{
					string sgio=(giorau.Text.Trim()=="")?"00:00":giorau.Text.Trim();
					giorau.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giorau.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giorau.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void giovo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giovo.Text!="")
				{
					string sgio=(giovo.Text.Trim()=="")?"00:00":giovo.Text.Trim();
					giovo.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giovo.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giovo.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void kinhnam_Validated(object sender, System.EventArgs e)
		{
			if(kinhnam.Text!="")
			{
				if (int.Parse(kinhnam.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Năm không hợp lệ !"),LibMedi.AccessData.Msg);
					kinhnam.Focus();
					return;
				}
				if (kinhnam.Text.Length<4) kinhnam.Text=Convert.ToString(DateTime.Now.Year-int.Parse(kinhnam.Text));
				kinhtuoi.Text=Convert.ToString(int.Parse(kinhnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
			}
		}

		private void kinhtuoi_Validated(object sender, System.EventArgs e)
		{
			if (kinhtuoi.Text!="")
			{
				int _tuoi=int.Parse(namsinh.Text)+int.Parse(kinhtuoi.Text);
				kinhnam.Text=_tuoi.ToString();
			}
		}

		private void chongnam_Validated(object sender, System.EventArgs e)
		{
			if(chongnam.Text!="")
			{
				if (int.Parse(chongnam.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Năm không hợp lệ !"),LibMedi.AccessData.Msg);
					chongnam.Focus();
					return;
				}
				if (chongnam.Text.Length<4) chongnam.Text=Convert.ToString(DateTime.Now.Year-int.Parse(chongnam.Text));
				chongtuoi.Text=Convert.ToString(int.Parse(chongnam.Text)-int.Parse(namsinh.Text)).PadLeft(3,'0');
			}
		}

		private void chongtuoi_Validated(object sender, System.EventArgs e)
		{
			if (chongtuoi.Text!="")
			{
				int _tuoi=int.Parse(namsinh.Text)+int.Parse(chongtuoi.Text);
				chongnam.Text=_tuoi.ToString();
			}
		}

		private void chaymau_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chaymau) maumat.Enabled=chaymau.Checked;
		}

		private void tangsinhmon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tangsinhmon)
			{
				loaichi.Enabled=tangsinhmon.SelectedIndex==2;
				somui.Enabled=loaichi.Enabled;
			}
		}

		private void butTresosinh_Click(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				frmTresosinh f=new frmTresosinh(m,mabn.Text,hoten.Text,m.get_tuoivao(l_maql),l_maql,ngayvk.Text+" "+giovk.Text,i_userid,r["matt"].ToString(),r["maqu"].ToString(),r["maphuongxa"].ToString());
				f.ShowDialog();
				load_tresosinh();
			}
		}

		private void butTiensu_Click(object sender, System.EventArgs e)
		{
			if (l_id==0)
			{
				if (!kiemtra()) return;
				xxx=user+m.mmyy(ngay.Text);
				bool bNhapkhoa=m.getrowbyid(ds.Tables[0],"nhapkhoa=0 and mabn='"+mabn.Text+"'")!=null;
				if (bNhapkhoa) upd_nhapkhoa();
				m.execute_data("update benhandt set mabs='"+mabsnb.Text+"' where maql="+l_maql);
				l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
				if (l_idthuchien==0) 
				{
					l_idthuchien=m.get_capid(-300);
					m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
				}
				l_id=m.get_idchung(ngay.Text,l_idthuchien);
				if (l_id==0) l_id=m.get_capid(-301);
                m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, lanthu.Value, "", hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
					kb_hohap.Text,kb_tieuhoa.Text,kb_than.Text,"","","","","","",kb_khac.Text,"",phanbiet.Text,
					tienluong.Text,dieutri.Text,mabsnb.Text,"","","","",tk_dieutri.Text,manguoigiao.Text,manguoinhan.Text,mabs.Text,i_userid);
			}
			frmTiensusk f=new frmTiensusk(m,l_id,ngay.Text);
			f.ShowDialog();
			load_tiensusk();
		}

		private void butAn_Click(object sender, System.EventArgs e)
		{
		
		}

		private void giosaude_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giosaude.Text!="")
				{
					string sgio=(giosaude.Text.Trim()=="")?"00:00":giosaude.Text.Trim();
					giosaude.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giosaude.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giosaude.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void ngaysaude_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngaysaude.Text!="")
				{
					ngaysaude.Text=ngaysaude.Text.Trim();
					if (ngaysaude.Text.Length==6) ngaysaude.Text=ngaysaude.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngaysaude.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngaysaude.Focus();
						return;
					}
				}
			}
			catch{}		
		}

        private void p_Paint(object sender, PaintEventArgs e)
        {

        }

	}
}
