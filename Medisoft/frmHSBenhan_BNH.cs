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
    /// Summary description for frmHSBenhan_BNH.
    /// </summary>
    public class frmHSBenhan_BNH : System.Windows.Forms.Form
    {
        Language lan = new Language();

        private LibMedi.AccessData m;
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
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
        private string sql, s_makp, s_mabs, user, xxx, s_tenkp, s_sovaovien, s_nhomkho, s_userid, filebmp = "benhan.bmp";
        private int i_phong, i_userid, i_madoituong, itable, i_loai, i_maba, traituyen=0;
        private DataTable dtnv = new DataTable();
        private DataTable dtg = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataSet ds = new DataSet();
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
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
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
        private System.Windows.Forms.TextBox hb_benhly;
        private System.Windows.Forms.TextBox hb_giadinh;
        private System.Windows.Forms.TextBox hb_banthan;
        private System.Windows.Forms.TextBox kb_toanthan;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private LibList.List listICD;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
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
        private System.Windows.Forms.TextBox kb_hohap;
        private System.Windows.Forms.TextBox kb_tieuhoa;
        private System.Windows.Forms.TextBox kb_than;
        private System.Windows.Forms.TextBox kb_thankinh;
        private System.Windows.Forms.TextBox kb_co;
        private System.Windows.Forms.TextBox kb_noitiet;
        private System.Windows.Forms.TextBox cd_kemtheo;
        private MaskedTextBox.MaskedTextBox icd_kemtheo;
        private System.Windows.Forms.TextBox phanbiet;
        private System.Windows.Forms.TextBox tienluong;
        private System.Windows.Forms.TextBox dieutri;
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
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.TextBox tk_tinhtrang;
        private LibList.List listNv;
        private MemoryStream memo;
        private FileStream fstr;
        private Bitmap map;
        private byte[] image, imagedt, image1, image2;
        private DataSet dscd = new DataSet();
        private DataTable dtba = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dthinh = new DataTable();
        private System.Windows.Forms.TextBox cd_kkb;
        private MaskedTextBox.MaskedTextBox icd_kkb;
        private DataTable dticd = new DataTable();
        private decimal l_maql, l_id, l_idkhoa, l_idthuchien;
        private bool b_sovaovien, b_soluutru, bPhonggiuong, bAdmin, bHinh = false;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.CheckedListBox chonin;
        private LibList.List list1;
        private System.Windows.Forms.Button butKemtheo;
        private System.Windows.Forms.TabPage tab4;
        private string nor_toanthan, nor_tuanhoan, nor_hohap, nor_tieuhoa, nor_than, nor_thankinh, nor_co, nor_tmh, nor_rhm, nor_mat, nor_noitiet, thumucpic;
        private string f1 = "", f2 = "";
        private System.Windows.Forms.TextBox tenbs_pass;
        private AsYetUnnamedColor.MultiColumnListBoxColor list;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Button butPhong;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.CheckBox chkHinh;
        private System.Windows.Forms.ComboBox stt1;
        private System.Windows.Forms.ComboBox stt2;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label93;
        private LibList.List listNv1;
        private System.Windows.Forms.TextBox tk_tomtat;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.TextBox benhnhan;
        private System.Windows.Forms.TextBox lydovv;
        private System.Windows.Forms.TextBox thucthe;
        private System.Windows.Forms.TextBox conang;
        private System.Windows.Forms.TextBox clsdaco;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown conthu;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox tinhtrang;
        private System.Windows.Forms.Label label22;
        private MaskedTextBox.MaskedTextBox cannang_s;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox ditat;
        private System.Windows.Forms.ComboBox tenditat;
        private System.Windows.Forms.TextBox maditat;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tinhthan;
        private System.Windows.Forms.TextBox vandong;
        private System.Windows.Forms.TextBox benhlykhac;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox nuoiduong;
        private System.Windows.Forms.Label label32;
        private MaskedTextBox.MaskedTextBox caisua;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox vuontre;
        private System.Windows.Forms.CheckBox tainha;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox lao;
        private System.Windows.Forms.CheckBox bailiet;
        private System.Windows.Forms.CheckBox soi;
        private System.Windows.Forms.CheckBox hoga;
        private System.Windows.Forms.CheckBox uonvan;
        private System.Windows.Forms.CheckBox bachhau;
        private System.Windows.Forms.CheckBox tckhac;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.TextBox cuthe;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label109;
        private MaskedTextBox.MaskedTextBox chieucao;
        private MaskedTextBox.MaskedTextBox vongnguc;
        private MaskedTextBox.MaskedTextBox vongdau;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label111;
        private MaskedTextBox.MaskedTextBox para1;
        private MaskedTextBox.MaskedTextBox para2;
        private MaskedTextBox.MaskedTextBox para3;
        private MaskedTextBox.MaskedTextBox para4;
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
        private Label label58;
        private Label label59;
        private System.Windows.Forms.TextBox tenbsnb_pass;

        public frmHSBenhan_BNH(LibMedi.AccessData acc, string _makp, string _tenkp, int _phong, string _mabs, int userid, string _nhomkho, string suserid, bool _soluutru, bool _sovaovien, bool _admin, int _loai, int _maba)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //Language lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; s_makp = _makp; s_tenkp = _tenkp; i_phong = _phong; s_mabs = _mabs; i_userid = userid; s_nhomkho = _nhomkho;
            s_userid = suserid; b_sovaovien = _sovaovien; b_soluutru = _soluutru; bAdmin = _admin; i_loai = _loai; i_maba = _maba;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHSBenhan_BNH));
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
            this.butKemtheo = new System.Windows.Forms.Button();
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.tenbsnb_pass = new System.Windows.Forms.TextBox();
            this.list = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.butPhong = new System.Windows.Forms.Button();
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
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.vongdau = new MaskedTextBox.MaskedTextBox();
            this.vongnguc = new MaskedTextBox.MaskedTextBox();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cuthe = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.tckhac = new System.Windows.Forms.CheckBox();
            this.bachhau = new System.Windows.Forms.CheckBox();
            this.uonvan = new System.Windows.Forms.CheckBox();
            this.hoga = new System.Windows.Forms.CheckBox();
            this.soi = new System.Windows.Forms.CheckBox();
            this.bailiet = new System.Windows.Forms.CheckBox();
            this.lao = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.tainha = new System.Windows.Forms.CheckBox();
            this.vuontre = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.nuoiduong = new System.Windows.Forms.ComboBox();
            this.caisua = new MaskedTextBox.MaskedTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.benhlykhac = new System.Windows.Forms.TextBox();
            this.vandong = new System.Windows.Forms.TextBox();
            this.tinhthan = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tenditat = new System.Windows.Forms.ComboBox();
            this.maditat = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ditat = new System.Windows.Forms.CheckBox();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.cannang_s = new MaskedTextBox.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.conthu = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.kb_toanthan = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.kb_tuanhoan = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.stt2 = new System.Windows.Forms.ComboBox();
            this.stt1 = new System.Windows.Forms.ComboBox();
            this.chkHinh = new System.Windows.Forms.CheckBox();
            this.p2 = new System.Windows.Forms.Panel();
            this.p1 = new System.Windows.Forms.Panel();
            this.hb_giadinh = new System.Windows.Forms.TextBox();
            this.hb_banthan = new System.Windows.Forms.TextBox();
            this.hb_benhly = new System.Windows.Forms.TextBox();
            this.lydo = new System.Windows.Forms.TextBox();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
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
            this.label52 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.clsdaco = new System.Windows.Forms.TextBox();
            this.conang = new System.Windows.Forms.TextBox();
            this.thucthe = new System.Windows.Forms.TextBox();
            this.lydovv = new System.Windows.Forms.TextBox();
            this.benhnhan = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.listNv1 = new LibList.List();
            this.mabsnb = new MaskedTextBox.MaskedTextBox();
            this.giovk = new MaskedBox.MaskedBox();
            this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
            this.listICD = new LibList.List();
            this.label100 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.kb_noitiet = new System.Windows.Forms.TextBox();
            this.kb_co = new System.Windows.Forms.TextBox();
            this.kb_thankinh = new System.Windows.Forms.TextBox();
            this.kb_than = new System.Windows.Forms.TextBox();
            this.kb_tomtat = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label67 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.phanbiet = new System.Windows.Forms.TextBox();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tenbsnb = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.kb_hohap = new System.Windows.Forms.TextBox();
            this.kb_tieuhoa = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tab4 = new System.Windows.Forms.TabPage();
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
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.p.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).BeginInit();
            this.panel2.SuspendLayout();
            this.p2.SuspendLayout();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            this.tab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tab4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).BeginInit();
            this.panel9.SuspendLayout();
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
            this.p.Size = new System.Drawing.Size(1016, 27);
            this.p.TabIndex = 7;
            // 
            // butChon
            // 
            this.butChon.Enabled = false;
            this.butChon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChon.Location = new System.Drawing.Point(924, 1);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(54, 22);
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
            "Thuốc đã sử dụng",
            "Công khai thuốc",
            "Công nợ",
            "Xuất khoa",
            "Thanh toán ra viện",
            "Giấy ra viện",
            "Giấy chuyển viện"});
            this.xem.Location = new System.Drawing.Point(570, 1);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(352, 22);
            this.xem.TabIndex = 13;
            this.xem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
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
            this.toolStripSeparator11,
            this.barKetthuc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1012, 22);
            this.toolStrip1.TabIndex = 303;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 22);
            // 
            // barChuyengiuong
            // 
            this.barChuyengiuong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChuyengiuong.Image = ((System.Drawing.Image)(resources.GetObject("barChuyengiuong.Image")));
            this.barChuyengiuong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChuyengiuong.Name = "barChuyengiuong";
            this.barChuyengiuong.Size = new System.Drawing.Size(23, 19);
            this.barChuyengiuong.Text = "toolStripButton1";
            this.barChuyengiuong.ToolTipText = "Chuyển giường điều trị";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 22);
            // 
            // barChidinh
            // 
            this.barChidinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChidinh.Image = ((System.Drawing.Image)(resources.GetObject("barChidinh.Image")));
            this.barChidinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChidinh.Name = "barChidinh";
            this.barChidinh.Size = new System.Drawing.Size(23, 19);
            this.barChidinh.Text = "toolStripButton1";
            this.barChidinh.ToolTipText = "Chỉ định cận lâm sàng";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 22);
            // 
            // barDieutri
            // 
            this.barDieutri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDieutri.Image = ((System.Drawing.Image)(resources.GetObject("barDieutri.Image")));
            this.barDieutri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDieutri.Name = "barDieutri";
            this.barDieutri.Size = new System.Drawing.Size(23, 19);
            this.barDieutri.Text = "toolStripButton1";
            this.barDieutri.ToolTipText = "Tờ điều trị";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 22);
            // 
            // barChedoan
            // 
            this.barChedoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChedoan.Image = ((System.Drawing.Image)(resources.GetObject("barChedoan.Image")));
            this.barChedoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChedoan.Name = "barChedoan";
            this.barChedoan.Size = new System.Drawing.Size(23, 19);
            this.barChedoan.Text = "toolStripButton2";
            this.barChedoan.ToolTipText = "Chế độ ăn";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 22);
            // 
            // barChamsoc
            // 
            this.barChamsoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChamsoc.Image = ((System.Drawing.Image)(resources.GetObject("barChamsoc.Image")));
            this.barChamsoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChamsoc.Name = "barChamsoc";
            this.barChamsoc.Size = new System.Drawing.Size(23, 19);
            this.barChamsoc.Text = "toolStripButton3";
            this.barChamsoc.ToolTipText = "Chăm sóc";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 22);
            // 
            // barMau
            // 
            this.barMau.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barMau.Image = ((System.Drawing.Image)(resources.GetObject("barMau.Image")));
            this.barMau.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barMau.Name = "barMau";
            this.barMau.Size = new System.Drawing.Size(23, 19);
            this.barMau.Text = "toolStripButton4";
            this.barMau.ToolTipText = "Truyền máu";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 22);
            // 
            // barDich
            // 
            this.barDich.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDich.Image = ((System.Drawing.Image)(resources.GetObject("barDich.Image")));
            this.barDich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDich.Name = "barDich";
            this.barDich.Size = new System.Drawing.Size(23, 19);
            this.barDich.Text = "toolStripButton5";
            this.barDich.ToolTipText = "Truyền Dịch";
            // 
            // barChonkhoa
            // 
            this.barChonkhoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barChonkhoa.Image = ((System.Drawing.Image)(resources.GetObject("barChonkhoa.Image")));
            this.barChonkhoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barChonkhoa.Name = "barChonkhoa";
            this.barChonkhoa.Size = new System.Drawing.Size(23, 19);
            this.barChonkhoa.ToolTipText = "Chọn khoa làm việc";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 22);
            // 
            // barDausinhton
            // 
            this.barDausinhton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barDausinhton.Image = ((System.Drawing.Image)(resources.GetObject("barDausinhton.Image")));
            this.barDausinhton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barDausinhton.Name = "barDausinhton";
            this.barDausinhton.Size = new System.Drawing.Size(23, 19);
            this.barDausinhton.Text = "toolStripButton6";
            this.barDausinhton.ToolTipText = "Dấu sinh tồn";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 22);
            // 
            // barPhanUng
            // 
            this.barPhanUng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPhanUng.Image = ((System.Drawing.Image)(resources.GetObject("barPhanUng.Image")));
            this.barPhanUng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPhanUng.Name = "barPhanUng";
            this.barPhanUng.Size = new System.Drawing.Size(23, 19);
            this.barPhanUng.Text = "toolStripButton7";
            this.barPhanUng.ToolTipText = "Phản ứng";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 22);
            // 
            // barPttt
            // 
            this.barPttt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barPttt.Image = ((System.Drawing.Image)(resources.GetObject("barPttt.Image")));
            this.barPttt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barPttt.Name = "barPttt";
            this.barPttt.Size = new System.Drawing.Size(23, 19);
            this.barPttt.Text = "toolStripButton1";
            this.barPttt.ToolTipText = "Phẫu thuật thủ thuật";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 22);
            // 
            // barKetthuc
            // 
            this.barKetthuc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.barKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("barKetthuc.Image")));
            this.barKetthuc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barKetthuc.Name = "barKetthuc";
            this.barKetthuc.Size = new System.Drawing.Size(23, 19);
            this.barKetthuc.Text = "toolStripButton2";
            this.barKetthuc.ToolTipText = "Kết thúc";
            // 
            // butKethuc
            // 
            this.butKethuc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butKethuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKethuc.Location = new System.Drawing.Point(3, 395);
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
            this.butPhanung.Location = new System.Drawing.Point(3, 371);
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
            this.butAn.Location = new System.Drawing.Point(3, 227);
            this.butAn.Name = "butAn";
            this.butAn.Size = new System.Drawing.Size(178, 25);
            this.butAn.TabIndex = 4;
            this.butAn.Text = "     Chế độ ăn";
            this.butAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butChamsoc
            // 
            this.butChamsoc.Enabled = false;
            this.butChamsoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butChamsoc.Image = ((System.Drawing.Image)(resources.GetObject("butChamsoc.Image")));
            this.butChamsoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChamsoc.Location = new System.Drawing.Point(3, 251);
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
            this.butDieutri.Location = new System.Drawing.Point(3, 203);
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
            this.butChidinh.Location = new System.Drawing.Point(3, 179);
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
            this.butChuyenphong.Location = new System.Drawing.Point(3, 155);
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
            this.butKhoa.Location = new System.Drawing.Point(3, 131);
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
            this.butDich.Location = new System.Drawing.Point(3, 299);
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
            this.butDausinhton.Location = new System.Drawing.Point(3, 323);
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
            this.butPttt.Location = new System.Drawing.Point(3, 347);
            this.butPttt.Name = "butPttt";
            this.butPttt.Size = new System.Drawing.Size(178, 25);
            this.butPttt.TabIndex = 11;
            this.butPttt.Text = "     Phẩu thủ thuật";
            this.butPttt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butMau
            // 
            this.butMau.Enabled = false;
            this.butMau.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butMau.Image = ((System.Drawing.Image)(resources.GetObject("butMau.Image")));
            this.butMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMau.Location = new System.Drawing.Point(3, 275);
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
            this.butRef.Location = new System.Drawing.Point(160, 73);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(25, 21);
            this.butRef.TabIndex = 6;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách người bệnh");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // butKemtheo
            // 
            this.butKemtheo.Enabled = false;
            this.butKemtheo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butKemtheo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKemtheo.Location = new System.Drawing.Point(760, 448);
            this.butKemtheo.Name = "butKemtheo";
            this.butKemtheo.Size = new System.Drawing.Size(22, 21);
            this.butKemtheo.TabIndex = 298;
            this.butKemtheo.Text = "...";
            this.toolTip1.SetToolTip(this.butKemtheo, "Chẩn đoán kèm theo");
            this.butKemtheo.Click += new System.EventHandler(this.butKemtheo_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(720, 510);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbs_pass.TabIndex = 13;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_pass_KeyDown);
            // 
            // tenbsnb_pass
            // 
            this.tenbsnb_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb_pass.Enabled = false;
            this.tenbsnb_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb_pass.Location = new System.Drawing.Point(720, 540);
            this.tenbsnb_pass.Name = "tenbsnb_pass";
            this.tenbsnb_pass.PasswordChar = '*';
            this.tenbsnb_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbsnb_pass.TabIndex = 24;
            this.toolTip1.SetToolTip(this.tenbsnb_pass, "Mật khẩu bác sĩ làm bệnh án");
            this.tenbsnb_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_pass_KeyDown);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(6, 3);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(175, 121);
            this.list.TabIndex = 12;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F3 chọn");
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(0, 0);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(152, 112);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.toolTip1.SetToolTip(this.pic1, "Chỉnh sửa hình Double Click");
            this.pic1.DoubleClick += new System.EventHandler(this.pic1_DoubleClick);
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(0, 0);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(152, 112);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.toolTip1.SetToolTip(this.pic2, "Chỉnh sửa hình Double Click");
            this.pic2.DoubleClick += new System.EventHandler(this.pic2_DoubleClick);
            // 
            // butPhong
            // 
            this.butPhong.Enabled = false;
            this.butPhong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butPhong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPhong.Location = new System.Drawing.Point(839, 56);
            this.butPhong.Name = "butPhong";
            this.butPhong.Size = new System.Drawing.Size(22, 21);
            this.butPhong.TabIndex = 299;
            this.butPhong.Text = "...";
            this.toolTip1.SetToolTip(this.butPhong, "Chọn phòng giường");
            this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(283, 34);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(93, 21);
            this.tenba.TabIndex = 1;
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.CadetBlue;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(230, 34);
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
            this.panel1.Controls.Add(this.butMau);
            this.panel1.Controls.Add(this.butKhoa);
            this.panel1.Controls.Add(this.butDieutri);
            this.panel1.Controls.Add(this.butChuyenphong);
            this.panel1.Controls.Add(this.butChidinh);
            this.panel1.Location = new System.Drawing.Point(11, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 508);
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
            this.chonin.Location = new System.Drawing.Point(9, 430);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(162, 68);
            this.chonin.TabIndex = 11;
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(19, 72);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(136, 21);
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
            this.groupBox1.Location = new System.Drawing.Point(16, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 32);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rb2
            // 
            this.rb2.BackColor = System.Drawing.Color.CadetBlue;
            this.rb2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rb2.Location = new System.Drawing.Point(97, 11);
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
            this.rb1.Location = new System.Drawing.Point(11, 9);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(87, 20);
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
            this.ngay.Location = new System.Drawing.Point(283, 56);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(92, 21);
            this.ngay.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.CadetBlue;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(202, 61);
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
            this.sothe.Location = new System.Drawing.Point(420, 56);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(144, 21);
            this.sothe.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.CadetBlue;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(376, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(852, 34);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(150, 21);
            this.diachi.TabIndex = 37;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(780, 34);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 36;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(697, 34);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 35;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(517, 34);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(151, 21);
            this.hoten.TabIndex = 34;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(420, 34);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(50, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.CadetBlue;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(813, 34);
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
            this.label4.Location = new System.Drawing.Point(731, 34);
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
            this.label3.Location = new System.Drawing.Point(658, 34);
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
            this.label1.Location = new System.Drawing.Point(476, 34);
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
            this.label10.Location = new System.Drawing.Point(372, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.CadetBlue;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(560, 61);
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
            this.label12.Location = new System.Drawing.Point(733, 61);
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
            this.label13.Location = new System.Drawing.Point(214, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 22);
            this.label13.TabIndex = 48;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(604, 56);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(64, 21);
            this.phong.TabIndex = 49;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(780, 56);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(58, 21);
            this.giuong.TabIndex = 50;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(283, 78);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(719, 23);
            this.chandoan.TabIndex = 51;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Location = new System.Drawing.Point(200, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 605);
            this.tabControl1.TabIndex = 3;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.para4);
            this.tab2.Controls.Add(this.para3);
            this.tab2.Controls.Add(this.para2);
            this.tab2.Controls.Add(this.para1);
            this.tab2.Controls.Add(this.label111);
            this.tab2.Controls.Add(this.label110);
            this.tab2.Controls.Add(this.vongdau);
            this.tab2.Controls.Add(this.vongnguc);
            this.tab2.Controls.Add(this.chieucao);
            this.tab2.Controls.Add(this.label109);
            this.tab2.Controls.Add(this.label108);
            this.tab2.Controls.Add(this.label107);
            this.tab2.Controls.Add(this.label106);
            this.tab2.Controls.Add(this.label92);
            this.tab2.Controls.Add(this.label38);
            this.tab2.Controls.Add(this.cuthe);
            this.tab2.Controls.Add(this.label105);
            this.tab2.Controls.Add(this.tckhac);
            this.tab2.Controls.Add(this.bachhau);
            this.tab2.Controls.Add(this.uonvan);
            this.tab2.Controls.Add(this.hoga);
            this.tab2.Controls.Add(this.soi);
            this.tab2.Controls.Add(this.bailiet);
            this.tab2.Controls.Add(this.lao);
            this.tab2.Controls.Add(this.label51);
            this.tab2.Controls.Add(this.tainha);
            this.tab2.Controls.Add(this.vuontre);
            this.tab2.Controls.Add(this.label33);
            this.tab2.Controls.Add(this.nuoiduong);
            this.tab2.Controls.Add(this.caisua);
            this.tab2.Controls.Add(this.label32);
            this.tab2.Controls.Add(this.label30);
            this.tab2.Controls.Add(this.benhlykhac);
            this.tab2.Controls.Add(this.vandong);
            this.tab2.Controls.Add(this.tinhthan);
            this.tab2.Controls.Add(this.label27);
            this.tab2.Controls.Add(this.label26);
            this.tab2.Controls.Add(this.label25);
            this.tab2.Controls.Add(this.tenditat);
            this.tab2.Controls.Add(this.maditat);
            this.tab2.Controls.Add(this.label24);
            this.tab2.Controls.Add(this.ditat);
            this.tab2.Controls.Add(this.tinhtrang);
            this.tab2.Controls.Add(this.cannang_s);
            this.tab2.Controls.Add(this.label22);
            this.tab2.Controls.Add(this.label21);
            this.tab2.Controls.Add(this.label20);
            this.tab2.Controls.Add(this.conthu);
            this.tab2.Controls.Add(this.label19);
            this.tab2.Controls.Add(this.label18);
            this.tab2.Controls.Add(this.kb_toanthan);
            this.tab2.Controls.Add(this.panel2);
            this.tab2.Controls.Add(this.kb_tuanhoan);
            this.tab2.Controls.Add(this.label95);
            this.tab2.Controls.Add(this.label94);
            this.tab2.Controls.Add(this.label93);
            this.tab2.Controls.Add(this.label91);
            this.tab2.Controls.Add(this.stt2);
            this.tab2.Controls.Add(this.stt1);
            this.tab2.Controls.Add(this.chkHinh);
            this.tab2.Controls.Add(this.p2);
            this.tab2.Controls.Add(this.p1);
            this.tab2.Controls.Add(this.hb_giadinh);
            this.tab2.Controls.Add(this.hb_banthan);
            this.tab2.Controls.Add(this.hb_benhly);
            this.tab2.Controls.Add(this.lydo);
            this.tab2.Controls.Add(this.lanthu);
            this.tab2.Controls.Add(this.label50);
            this.tab2.Controls.Add(this.label49);
            this.tab2.Controls.Add(this.label37);
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
            this.tab2.Controls.Add(this.label52);
            this.tab2.Controls.Add(this.label23);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(801, 579);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Trang 2";
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Enabled = false;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(258, 254);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 5;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(28, 21);
            this.para4.TabIndex = 9;
            this.para4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Enabled = false;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(229, 254);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 5;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(28, 21);
            this.para3.TabIndex = 8;
            this.para3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Enabled = false;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(200, 254);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 5;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(28, 21);
            this.para2.TabIndex = 7;
            this.para2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Enabled = false;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(171, 254);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 5;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(28, 21);
            this.para1.TabIndex = 6;
            this.para1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label111
            // 
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.Location = new System.Drawing.Point(384, 474);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(32, 16);
            this.label111.TabIndex = 320;
            this.label111.Text = "cm";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label110
            // 
            this.label110.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.Location = new System.Drawing.Point(594, 474);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(32, 16);
            this.label110.TabIndex = 319;
            this.label110.Text = "cm";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vongdau
            // 
            this.vongdau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vongdau.Enabled = false;
            this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongdau.Location = new System.Drawing.Point(560, 471);
            this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vongdau.MaxLength = 5;
            this.vongdau.Name = "vongdau";
            this.vongdau.Size = new System.Drawing.Size(32, 21);
            this.vongdau.TabIndex = 32;
            this.vongdau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vongnguc
            // 
            this.vongnguc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vongnguc.Enabled = false;
            this.vongnguc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongnguc.Location = new System.Drawing.Point(344, 471);
            this.vongnguc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vongnguc.MaxLength = 5;
            this.vongnguc.Name = "vongnguc";
            this.vongnguc.Size = new System.Drawing.Size(32, 21);
            this.vongnguc.TabIndex = 31;
            this.vongnguc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Enabled = false;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(80, 471);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(32, 21);
            this.chieucao.TabIndex = 30;
            this.chieucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label109
            // 
            this.label109.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label109.Location = new System.Drawing.Point(496, 472);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(64, 18);
            this.label109.TabIndex = 315;
            this.label109.Text = "Vòng đầu :";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label108
            // 
            this.label108.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label108.Location = new System.Drawing.Point(280, 472);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(64, 18);
            this.label108.TabIndex = 314;
            this.label108.Text = "Vòng ngực :";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label107
            // 
            this.label107.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.Location = new System.Drawing.Point(120, 474);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(32, 16);
            this.label107.TabIndex = 313;
            this.label107.Text = "cm";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label106
            // 
            this.label106.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label106.Location = new System.Drawing.Point(16, 472);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(64, 18);
            this.label106.TabIndex = 312;
            this.label106.Text = "Chiều cao :";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.SystemColors.Control;
            this.label92.Image = ((System.Drawing.Image)(resources.GetObject("label92.Image")));
            this.label92.Location = new System.Drawing.Point(552, 453);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(16, 16);
            this.label92.TabIndex = 265;
            this.label92.Click += new System.EventHandler(this.label92_Click);
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(93, 454);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(483, 16);
            this.label38.TabIndex = 98;
            this.label38.Text = "(Ý thức, da niêm mạc, hệ thống hạch, tuyến giáp, vị trí, kích thước, số lượng, dị" +
                " động v.v...)";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cuthe
            // 
            this.cuthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cuthe.Enabled = false;
            this.cuthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuthe.Location = new System.Drawing.Point(232, 410);
            this.cuthe.Name = "cuthe";
            this.cuthe.Size = new System.Drawing.Size(552, 21);
            this.cuthe.TabIndex = 29;
            this.cuthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label105
            // 
            this.label105.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label105.Location = new System.Drawing.Point(16, 412);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(248, 18);
            this.label105.TabIndex = 310;
            this.label105.Text = "Cụ thể những bệnh khác được tiêm chủng :";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tckhac
            // 
            this.tckhac.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tckhac.Enabled = false;
            this.tckhac.Location = new System.Drawing.Point(661, 392);
            this.tckhac.Name = "tckhac";
            this.tckhac.Size = new System.Drawing.Size(124, 16);
            this.tckhac.TabIndex = 28;
            this.tckhac.Text = "7. Tiêm chủng khác";
            this.tckhac.CheckedChanged += new System.EventHandler(this.tckhac_CheckedChanged);
            this.tckhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // bachhau
            // 
            this.bachhau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bachhau.Enabled = false;
            this.bachhau.Location = new System.Drawing.Point(544, 392);
            this.bachhau.Name = "bachhau";
            this.bachhau.Size = new System.Drawing.Size(88, 16);
            this.bachhau.TabIndex = 27;
            this.bachhau.Text = "6. Bạch hầu";
            this.bachhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // uonvan
            // 
            this.uonvan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uonvan.Enabled = false;
            this.uonvan.Location = new System.Drawing.Point(448, 392);
            this.uonvan.Name = "uonvan";
            this.uonvan.Size = new System.Drawing.Size(80, 16);
            this.uonvan.TabIndex = 26;
            this.uonvan.Text = "5. Uốn ván";
            this.uonvan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // hoga
            // 
            this.hoga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hoga.Enabled = false;
            this.hoga.Location = new System.Drawing.Point(368, 392);
            this.hoga.Name = "hoga";
            this.hoga.Size = new System.Drawing.Size(66, 16);
            this.hoga.TabIndex = 25;
            this.hoga.Text = "4. Ho gà";
            this.hoga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // soi
            // 
            this.soi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.soi.Enabled = false;
            this.soi.Location = new System.Drawing.Point(293, 392);
            this.soi.Name = "soi";
            this.soi.Size = new System.Drawing.Size(56, 16);
            this.soi.TabIndex = 24;
            this.soi.Text = "3. Sởi";
            this.soi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // bailiet
            // 
            this.bailiet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bailiet.Enabled = false;
            this.bailiet.Location = new System.Drawing.Point(208, 392);
            this.bailiet.Name = "bailiet";
            this.bailiet.Size = new System.Drawing.Size(72, 16);
            this.bailiet.TabIndex = 23;
            this.bailiet.Text = "2. Bại liệt";
            this.bailiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // lao
            // 
            this.lao.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lao.Enabled = false;
            this.lao.Location = new System.Drawing.Point(136, 392);
            this.lao.Name = "lao";
            this.lao.Size = new System.Drawing.Size(56, 16);
            this.lao.TabIndex = 22;
            this.lao.Text = "1. Lao";
            this.lao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label51
            // 
            this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label51.Location = new System.Drawing.Point(16, 392);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(112, 18);
            this.label51.TabIndex = 302;
            this.label51.Text = "Đã tiêm chủng :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tainha
            // 
            this.tainha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tainha.Enabled = false;
            this.tainha.Location = new System.Drawing.Point(704, 371);
            this.tainha.Name = "tainha";
            this.tainha.Size = new System.Drawing.Size(80, 16);
            this.tainha.TabIndex = 21;
            this.tainha.Text = "2. Tại nhà";
            this.tainha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // vuontre
            // 
            this.vuontre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vuontre.Enabled = false;
            this.vuontre.Location = new System.Drawing.Point(608, 371);
            this.vuontre.Name = "vuontre";
            this.vuontre.Size = new System.Drawing.Size(80, 16);
            this.vuontre.TabIndex = 20;
            this.vuontre.Text = "1. Vườn trẻ";
            this.vuontre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(538, 371);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 16);
            this.label33.TabIndex = 299;
            this.label33.Text = "Chăm sóc :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuoiduong
            // 
            this.nuoiduong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nuoiduong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nuoiduong.Enabled = false;
            this.nuoiduong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuoiduong.Items.AddRange(new object[] {
            "1. Sữa mẹ",
            "2. Nuôi nhân tạo",
            "3. Hỗn hợp"});
            this.nuoiduong.Location = new System.Drawing.Point(136, 368);
            this.nuoiduong.Name = "nuoiduong";
            this.nuoiduong.Size = new System.Drawing.Size(96, 21);
            this.nuoiduong.TabIndex = 18;
            this.nuoiduong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // caisua
            // 
            this.caisua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.caisua.Enabled = false;
            this.caisua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caisua.Location = new System.Drawing.Point(336, 368);
            this.caisua.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.caisua.MaxLength = 5;
            this.caisua.Name = "caisua";
            this.caisua.Size = new System.Drawing.Size(32, 21);
            this.caisua.TabIndex = 19;
            this.caisua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(224, 371);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(112, 16);
            this.label32.TabIndex = 297;
            this.label32.Text = "Cai sữa tháng thứ :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(16, 369);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 18);
            this.label30.TabIndex = 295;
            this.label30.Text = "Nuôi dưỡng :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // benhlykhac
            // 
            this.benhlykhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhlykhac.Enabled = false;
            this.benhlykhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhlykhac.Location = new System.Drawing.Point(136, 345);
            this.benhlykhac.Name = "benhlykhac";
            this.benhlykhac.Size = new System.Drawing.Size(657, 21);
            this.benhlykhac.TabIndex = 17;
            this.benhlykhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // vandong
            // 
            this.vandong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vandong.Enabled = false;
            this.vandong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vandong.Location = new System.Drawing.Point(136, 323);
            this.vandong.Name = "vandong";
            this.vandong.Size = new System.Drawing.Size(657, 21);
            this.vandong.TabIndex = 16;
            this.vandong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tinhthan
            // 
            this.tinhthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhthan.Enabled = false;
            this.tinhthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhthan.Location = new System.Drawing.Point(136, 300);
            this.tinhthan.Name = "tinhthan";
            this.tinhthan.Size = new System.Drawing.Size(657, 21);
            this.tinhthan.TabIndex = 15;
            this.tinhthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(16, 347);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 18);
            this.label27.TabIndex = 291;
            this.label27.Text = "Các bệnh lý khác :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(16, 323);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(144, 18);
            this.label26.TabIndex = 290;
            this.label26.Text = "Phát triển về vận động :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(16, 302);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(136, 18);
            this.label25.TabIndex = 289;
            this.label25.Text = "Phát triển về tinh thần :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenditat
            // 
            this.tenditat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenditat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenditat.Enabled = false;
            this.tenditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenditat.Location = new System.Drawing.Point(171, 277);
            this.tenditat.Name = "tenditat";
            this.tenditat.Size = new System.Drawing.Size(622, 21);
            this.tenditat.TabIndex = 14;
            this.tenditat.SelectedIndexChanged += new System.EventHandler(this.tenditat_SelectedIndexChanged);
            this.tenditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenditat_KeyDown);
            // 
            // maditat
            // 
            this.maditat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maditat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maditat.Enabled = false;
            this.maditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maditat.Location = new System.Drawing.Point(117, 277);
            this.maditat.Name = "maditat";
            this.maditat.Size = new System.Drawing.Size(53, 21);
            this.maditat.TabIndex = 13;
            this.maditat.Validated += new System.EventHandler(this.maditat_Validated);
            this.maditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(16, 279);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 18);
            this.label24.TabIndex = 288;
            this.label24.Text = "Cụ thể tật bẩm sinh :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ditat
            // 
            this.ditat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ditat.Enabled = false;
            this.ditat.Location = new System.Drawing.Point(680, 256);
            this.ditat.Name = "ditat";
            this.ditat.Size = new System.Drawing.Size(98, 16);
            this.ditat.TabIndex = 12;
            this.ditat.Text = "Dị tật bẩm sinh";
            this.ditat.CheckedChanged += new System.EventHandler(this.ditat_CheckedChanged);
            this.ditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Items.AddRange(new object[] {
            "1. Đẻ thường",
            "2. Forceps",
            "3. Giác hút",
            "4. Đẻ phẫu thuật",
            "5. Đẻ chỉ huy",
            "6. Khác"});
            this.tinhtrang.Location = new System.Drawing.Point(392, 254);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(112, 21);
            this.tinhtrang.TabIndex = 10;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // cannang_s
            // 
            this.cannang_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang_s.Enabled = false;
            this.cannang_s.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang_s.Location = new System.Drawing.Point(600, 254);
            this.cannang_s.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang_s.MaxLength = 5;
            this.cannang_s.Name = "cannang_s";
            this.cannang_s.Size = new System.Drawing.Size(40, 21);
            this.cannang_s.TabIndex = 11;
            this.cannang_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(498, 256);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 16);
            this.label22.TabIndex = 283;
            this.label22.Text = "Cân nặng lúc sinh :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(278, 256);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 16);
            this.label21.TabIndex = 281;
            this.label21.Text = "Tình trạng khi sinh :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(128, 256);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 16);
            this.label20.TabIndex = 276;
            this.label20.Text = "Para :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // conthu
            // 
            this.conthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.conthu.Enabled = false;
            this.conthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conthu.Location = new System.Drawing.Point(88, 254);
            this.conthu.Name = "conthu";
            this.conthu.Size = new System.Drawing.Size(40, 21);
            this.conthu.TabIndex = 5;
            this.conthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(16, 256);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 16);
            this.label19.TabIndex = 274;
            this.label19.Text = "Con thứ mấy :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 235);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 16);
            this.label18.TabIndex = 273;
            this.label18.Text = "3. Quá trình sinh trưởng :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_toanthan
            // 
            this.kb_toanthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_toanthan.Enabled = false;
            this.kb_toanthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_toanthan.Location = new System.Drawing.Point(21, 493);
            this.kb_toanthan.Multiline = true;
            this.kb_toanthan.Name = "kb_toanthan";
            this.kb_toanthan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_toanthan.Size = new System.Drawing.Size(602, 29);
            this.kb_toanthan.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel2.Location = new System.Drawing.Point(634, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 120);
            this.panel2.TabIndex = 33;
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
            this.cannang.Location = new System.Drawing.Point(64, 93);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 4;
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
            // kb_tuanhoan
            // 
            this.kb_tuanhoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tuanhoan.Enabled = false;
            this.kb_tuanhoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tuanhoan.Location = new System.Drawing.Point(104, 553);
            this.kb_tuanhoan.Name = "kb_tuanhoan";
            this.kb_tuanhoan.Size = new System.Drawing.Size(520, 21);
            this.kb_tuanhoan.TabIndex = 35;
            this.kb_tuanhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.SystemColors.Control;
            this.label95.Image = ((System.Drawing.Image)(resources.GetObject("label95.Image")));
            this.label95.Location = new System.Drawing.Point(16, 554);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(16, 16);
            this.label95.TabIndex = 265;
            this.label95.Click += new System.EventHandler(this.label95_Click);
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.SystemColors.Control;
            this.label94.Image = ((System.Drawing.Image)(resources.GetObject("label94.Image")));
            this.label94.Location = new System.Drawing.Point(97, 535);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(16, 16);
            this.label94.TabIndex = 264;
            this.label94.Click += new System.EventHandler(this.label94_Click);
            // 
            // label93
            // 
            this.label93.Location = new System.Drawing.Point(384, 535);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(24, 16);
            this.label93.TabIndex = 272;
            this.label93.Text = "2 :";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label93.Visible = false;
            // 
            // label91
            // 
            this.label91.Location = new System.Drawing.Point(288, 535);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(24, 16);
            this.label91.TabIndex = 271;
            this.label91.Text = "1 :";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label91.Visible = false;
            // 
            // stt2
            // 
            this.stt2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stt2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt2.Location = new System.Drawing.Point(408, 527);
            this.stt2.Name = "stt2";
            this.stt2.Size = new System.Drawing.Size(64, 21);
            this.stt2.TabIndex = 270;
            this.stt2.Visible = false;
            this.stt2.SelectedIndexChanged += new System.EventHandler(this.stt2_SelectedIndexChanged);
            // 
            // stt1
            // 
            this.stt1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stt1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt1.Location = new System.Drawing.Point(312, 527);
            this.stt1.Name = "stt1";
            this.stt1.Size = new System.Drawing.Size(64, 21);
            this.stt1.TabIndex = 269;
            this.stt1.Visible = false;
            this.stt1.SelectedIndexChanged += new System.EventHandler(this.stt1_SelectedIndexChanged);
            // 
            // chkHinh
            // 
            this.chkHinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkHinh.Location = new System.Drawing.Point(240, 533);
            this.chkHinh.Name = "chkHinh";
            this.chkHinh.Size = new System.Drawing.Size(48, 16);
            this.chkHinh.TabIndex = 268;
            this.chkHinh.Text = "Hình";
            this.chkHinh.Visible = false;
            this.chkHinh.CheckedChanged += new System.EventHandler(this.chkHinh_CheckedChanged);
            // 
            // p2
            // 
            this.p2.AutoScroll = true;
            this.p2.Controls.Add(this.pic2);
            this.p2.Location = new System.Drawing.Point(632, 464);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(152, 112);
            this.p2.TabIndex = 267;
            this.p2.Visible = false;
            // 
            // p1
            // 
            this.p1.AutoScroll = true;
            this.p1.Controls.Add(this.pic1);
            this.p1.Location = new System.Drawing.Point(478, 536);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(152, 40);
            this.p1.TabIndex = 266;
            this.p1.Visible = false;
            // 
            // hb_giadinh
            // 
            this.hb_giadinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_giadinh.Enabled = false;
            this.hb_giadinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_giadinh.Location = new System.Drawing.Point(32, 210);
            this.hb_giadinh.Name = "hb_giadinh";
            this.hb_giadinh.Size = new System.Drawing.Size(759, 21);
            this.hb_giadinh.TabIndex = 4;
            this.hb_giadinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // hb_banthan
            // 
            this.hb_banthan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_banthan.Enabled = false;
            this.hb_banthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_banthan.Location = new System.Drawing.Point(32, 166);
            this.hb_banthan.Name = "hb_banthan";
            this.hb_banthan.Size = new System.Drawing.Size(761, 21);
            this.hb_banthan.TabIndex = 3;
            this.hb_banthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // hb_benhly
            // 
            this.hb_benhly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hb_benhly.Enabled = false;
            this.hb_benhly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hb_benhly.Location = new System.Drawing.Point(32, 77);
            this.hb_benhly.Multiline = true;
            this.hb_benhly.Name = "hb_benhly";
            this.hb_benhly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hb_benhly.Size = new System.Drawing.Size(764, 51);
            this.hb_benhly.TabIndex = 2;
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
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(8, 534);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 16);
            this.label37.TabIndex = 97;
            this.label37.Text = "2. Các cơ quan :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(8, 454);
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
            this.label35.Location = new System.Drawing.Point(8, 439);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(107, 17);
            this.label35.TabIndex = 95;
            this.label35.Text = "III. Khám bệnh :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(16, 193);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(648, 16);
            this.label34.TabIndex = 94;
            this.label34.Text = "+ Gia đình : (Những người trong gia đình : bệnh đã mắc, đời sống, tinh thần, vật " +
                "chất v.v ...)";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(128, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(360, 16);
            this.label17.TabIndex = 67;
            this.label17.Text = "(khởi phát, diễn biến, chẩn đoán,điều trị của tuyến dưới v.v...)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(648, 16);
            this.label16.TabIndex = 66;
            this.label16.Text = "+ Bản thân : (phát triển thể lực từ nhỏ đến lớn, những bệnh đã mắc, phương pháp Đ" +
                "Tr, tiêm phòng, ăn uống,sinh hoạt v.v...)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(8, 131);
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
            this.label29.Size = new System.Drawing.Size(136, 16);
            this.label29.TabIndex = 64;
            this.label29.Text = "1. Quá trình bệnh lý :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(8, 44);
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
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(24, 554);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(80, 16);
            this.label52.TabIndex = 99;
            this.label52.Text = "+ Tuần hoàn :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(648, 256);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 16);
            this.label23.TabIndex = 24;
            this.label23.Text = "Kg";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.clsdaco);
            this.tab3.Controls.Add(this.conang);
            this.tab3.Controls.Add(this.thucthe);
            this.tab3.Controls.Add(this.lydovv);
            this.tab3.Controls.Add(this.benhnhan);
            this.tab3.Controls.Add(this.label120);
            this.tab3.Controls.Add(this.label119);
            this.tab3.Controls.Add(this.label118);
            this.tab3.Controls.Add(this.label117);
            this.tab3.Controls.Add(this.label116);
            this.tab3.Controls.Add(this.listNv1);
            this.tab3.Controls.Add(this.mabsnb);
            this.tab3.Controls.Add(this.giovk);
            this.tab3.Controls.Add(this.icd_kemtheo);
            this.tab3.Controls.Add(this.listICD);
            this.tab3.Controls.Add(this.label100);
            this.tab3.Controls.Add(this.label99);
            this.tab3.Controls.Add(this.label98);
            this.tab3.Controls.Add(this.kb_noitiet);
            this.tab3.Controls.Add(this.kb_co);
            this.tab3.Controls.Add(this.kb_thankinh);
            this.tab3.Controls.Add(this.kb_than);
            this.tab3.Controls.Add(this.kb_tomtat);
            this.tab3.Controls.Add(this.label63);
            this.tab3.Controls.Add(this.label62);
            this.tab3.Controls.Add(this.label61);
            this.tab3.Controls.Add(this.label57);
            this.tab3.Controls.Add(this.label56);
            this.tab3.Controls.Add(this.label55);
            this.tab3.Controls.Add(this.dataGrid2);
            this.tab3.Controls.Add(this.label67);
            this.tab3.Controls.Add(this.label65);
            this.tab3.Controls.Add(this.label69);
            this.tab3.Controls.Add(this.label68);
            this.tab3.Controls.Add(this.label66);
            this.tab3.Controls.Add(this.label64);
            this.tab3.Controls.Add(this.tienluong);
            this.tab3.Controls.Add(this.cd_kkb);
            this.tab3.Controls.Add(this.dieutri);
            this.tab3.Controls.Add(this.phanbiet);
            this.tab3.Controls.Add(this.cd_kemtheo);
            this.tab3.Controls.Add(this.icd_kkb);
            this.tab3.Controls.Add(this.butKemtheo);
            this.tab3.Controls.Add(this.ngayvk);
            this.tab3.Controls.Add(this.label89);
            this.tab3.Controls.Add(this.label70);
            this.tab3.Controls.Add(this.tenbsnb);
            this.tab3.Controls.Add(this.label71);
            this.tab3.Controls.Add(this.tenbsnb_pass);
            this.tab3.Controls.Add(this.label96);
            this.tab3.Controls.Add(this.label53);
            this.tab3.Controls.Add(this.kb_hohap);
            this.tab3.Controls.Add(this.kb_tieuhoa);
            this.tab3.Controls.Add(this.label97);
            this.tab3.Controls.Add(this.label54);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(801, 579);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Trang 3";
            // 
            // clsdaco
            // 
            this.clsdaco.BackColor = System.Drawing.SystemColors.HighlightText;
            this.clsdaco.Enabled = false;
            this.clsdaco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsdaco.Location = new System.Drawing.Point(109, 335);
            this.clsdaco.Multiline = true;
            this.clsdaco.Name = "clsdaco";
            this.clsdaco.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.clsdaco.Size = new System.Drawing.Size(675, 32);
            this.clsdaco.TabIndex = 11;
            // 
            // conang
            // 
            this.conang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.conang.Enabled = false;
            this.conang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conang.Location = new System.Drawing.Point(109, 289);
            this.conang.Name = "conang";
            this.conang.Size = new System.Drawing.Size(675, 21);
            this.conang.TabIndex = 9;
            this.conang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // thucthe
            // 
            this.thucthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thucthe.Enabled = false;
            this.thucthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucthe.Location = new System.Drawing.Point(109, 312);
            this.thucthe.Name = "thucthe";
            this.thucthe.Size = new System.Drawing.Size(675, 21);
            this.thucthe.TabIndex = 10;
            this.thucthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // lydovv
            // 
            this.lydovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydovv.Enabled = false;
            this.lydovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydovv.Location = new System.Drawing.Point(109, 266);
            this.lydovv.Name = "lydovv";
            this.lydovv.Size = new System.Drawing.Size(675, 21);
            this.lydovv.TabIndex = 8;
            this.lydovv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // benhnhan
            // 
            this.benhnhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhnhan.Enabled = false;
            this.benhnhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhnhan.Location = new System.Drawing.Point(216, 243);
            this.benhnhan.Name = "benhnhan";
            this.benhnhan.Size = new System.Drawing.Size(568, 21);
            this.benhnhan.TabIndex = 7;
            this.benhnhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label120
            // 
            this.label120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.Location = new System.Drawing.Point(16, 336);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(104, 18);
            this.label120.TabIndex = 304;
            this.label120.Text = "+ CLS đã có  :";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label119
            // 
            this.label119.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(18, 312);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(104, 18);
            this.label119.TabIndex = 303;
            this.label119.Text = "+ Thực thể :";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label118
            // 
            this.label118.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(18, 291);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(104, 18);
            this.label118.TabIndex = 302;
            this.label118.Text = "+ Cơ năng :";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label117
            // 
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(18, 268);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(104, 18);
            this.label117.TabIndex = 301;
            this.label117.Text = "+ Lý do vào viện :";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label116
            // 
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(136, 247);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(80, 18);
            this.label116.TabIndex = 300;
            this.label116.Text = "+ Bệnh nhân :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(576, 402);
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
            // mabsnb
            // 
            this.mabsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsnb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabsnb.Enabled = false;
            this.mabsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsnb.Location = new System.Drawing.Point(411, 540);
            this.mabsnb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabsnb.MaxLength = 9;
            this.mabsnb.Name = "mabsnb";
            this.mabsnb.Size = new System.Drawing.Size(36, 21);
            this.mabsnb.TabIndex = 22;
            this.mabsnb.Validated += new System.EventHandler(this.mabsnb_Validated);
            this.mabsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Enabled = false;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(249, 540);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(40, 21);
            this.giovk.TabIndex = 21;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Enabled = false;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(144, 448);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
            this.icd_kemtheo.TabIndex = 15;
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(656, 402);
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
            // label100
            // 
            this.label100.BackColor = System.Drawing.SystemColors.Control;
            this.label100.Image = ((System.Drawing.Image)(resources.GetObject("label100.Image")));
            this.label100.Location = new System.Drawing.Point(5, 97);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(16, 16);
            this.label100.TabIndex = 270;
            this.label100.Click += new System.EventHandler(this.label100_Click);
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.SystemColors.Control;
            this.label99.Image = ((System.Drawing.Image)(resources.GetObject("label99.Image")));
            this.label99.Location = new System.Drawing.Point(5, 76);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(16, 16);
            this.label99.TabIndex = 269;
            this.label99.Click += new System.EventHandler(this.label99_Click);
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Image = ((System.Drawing.Image)(resources.GetObject("label98.Image")));
            this.label98.Location = new System.Drawing.Point(5, 53);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(16, 16);
            this.label98.TabIndex = 268;
            this.label98.Click += new System.EventHandler(this.label98_Click);
            // 
            // kb_noitiet
            // 
            this.kb_noitiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_noitiet.Enabled = false;
            this.kb_noitiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_noitiet.Location = new System.Drawing.Point(152, 136);
            this.kb_noitiet.Multiline = true;
            this.kb_noitiet.Name = "kb_noitiet";
            this.kb_noitiet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_noitiet.Size = new System.Drawing.Size(632, 32);
            this.kb_noitiet.TabIndex = 5;
            // 
            // kb_co
            // 
            this.kb_co.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_co.Enabled = false;
            this.kb_co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_co.Location = new System.Drawing.Point(152, 93);
            this.kb_co.Name = "kb_co";
            this.kb_co.Size = new System.Drawing.Size(632, 21);
            this.kb_co.TabIndex = 4;
            this.kb_co.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_thankinh
            // 
            this.kb_thankinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_thankinh.Enabled = false;
            this.kb_thankinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_thankinh.Location = new System.Drawing.Point(152, 71);
            this.kb_thankinh.Name = "kb_thankinh";
            this.kb_thankinh.Size = new System.Drawing.Size(632, 21);
            this.kb_thankinh.TabIndex = 3;
            this.kb_thankinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_than
            // 
            this.kb_than.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_than.Enabled = false;
            this.kb_than.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_than.Location = new System.Drawing.Point(152, 49);
            this.kb_than.Name = "kb_than";
            this.kb_than.Size = new System.Drawing.Size(632, 21);
            this.kb_than.TabIndex = 2;
            this.kb_than.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_tomtat
            // 
            this.kb_tomtat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tomtat.Enabled = false;
            this.kb_tomtat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tomtat.Location = new System.Drawing.Point(109, 368);
            this.kb_tomtat.Multiline = true;
            this.kb_tomtat.Name = "kb_tomtat";
            this.kb_tomtat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kb_tomtat.Size = new System.Drawing.Size(675, 32);
            this.kb_tomtat.TabIndex = 12;
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(8, 247);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(136, 16);
            this.label63.TabIndex = 110;
            this.label63.Text = "4. Tóm tắt bệnh án :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(8, 171);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(272, 16);
            this.label62.TabIndex = 109;
            this.label62.Text = "3. Các xét nghiệm cận lâm sàng cần làm :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(10, 119);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(390, 18);
            this.label61.TabIndex = 108;
            this.label61.Text = "+ Tai - Mũi - Họng, Răng - Hàm - Mặt, Dinh dưỡng và các bệnh lý khác :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(10, 97);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(176, 16);
            this.label57.TabIndex = 104;
            this.label57.Text = "+ Cơ - Xương - Khớp :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(10, 76);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(88, 16);
            this.label56.TabIndex = 103;
            this.label56.Text = "+ Thần kinh :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(10, 53);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(168, 16);
            this.label55.TabIndex = 102;
            this.label55.Text = "+ Thận - Tiết niệu - Sinh dục :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid2.Location = new System.Drawing.Point(22, 168);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(760, 67);
            this.dataGrid2.TabIndex = 260;
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(9, 474);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(80, 16);
            this.label67.TabIndex = 107;
            this.label67.Text = "+ Phân biệt :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(9, 426);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(80, 16);
            this.label65.TabIndex = 100;
            this.label65.Text = "+ Bệnh chính :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label69.Location = new System.Drawing.Point(9, 523);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(128, 17);
            this.label69.TabIndex = 110;
            this.label69.Text = "VI. Hướng điều trị :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label68.Location = new System.Drawing.Point(9, 498);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(88, 17);
            this.label68.TabIndex = 109;
            this.label68.Text = "V. Tiên lượng :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(9, 449);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(152, 16);
            this.label66.TabIndex = 104;
            this.label66.Text = "+ Bệnh kèm theo (nếu có) :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(9, 406);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(232, 17);
            this.label64.TabIndex = 96;
            this.label64.Text = "IV. Chẩn đoán khi vào khoa điều trị :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(144, 494);
            this.tienluong.Name = "tienluong";
            this.tienluong.Size = new System.Drawing.Size(640, 21);
            this.tienluong.TabIndex = 18;
            this.tienluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // cd_kkb
            // 
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Enabled = false;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(205, 425);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(579, 21);
            this.cd_kkb.TabIndex = 14;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // dieutri
            // 
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Enabled = false;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(144, 517);
            this.dieutri.Name = "dieutri";
            this.dieutri.Size = new System.Drawing.Size(640, 21);
            this.dieutri.TabIndex = 19;
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // phanbiet
            // 
            this.phanbiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanbiet.Enabled = false;
            this.phanbiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanbiet.Location = new System.Drawing.Point(144, 471);
            this.phanbiet.Name = "phanbiet";
            this.phanbiet.Size = new System.Drawing.Size(640, 21);
            this.phanbiet.TabIndex = 17;
            this.phanbiet.TextChanged += new System.EventHandler(this.phanbiet_TextChanged);
            this.phanbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phanbiet_KeyDown);
            // 
            // cd_kemtheo
            // 
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Enabled = false;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(205, 448);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(552, 21);
            this.cd_kemtheo.TabIndex = 16;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // icd_kkb
            // 
            this.icd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Enabled = false;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(144, 425);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(59, 21);
            this.icd_kkb.TabIndex = 13;
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Enabled = false;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(144, 540);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(72, 21);
            this.ngayvk.TabIndex = 20;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(219, 541);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(32, 16);
            this.label89.TabIndex = 290;
            this.label89.Text = "Giờ :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(110, 541);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 16);
            this.label70.TabIndex = 113;
            this.label70.Text = "Ngày :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbsnb
            // 
            this.tenbsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb.Enabled = false;
            this.tenbsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb.Location = new System.Drawing.Point(449, 540);
            this.tenbsnb.Name = "tenbsnb";
            this.tenbsnb.Size = new System.Drawing.Size(270, 21);
            this.tenbsnb.TabIndex = 23;
            this.tenbsnb.TextChanged += new System.EventHandler(this.tenbsnb_TextChanged);
            this.tenbsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_KeyDown);
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(294, 541);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(120, 16);
            this.label71.TabIndex = 114;
            this.label71.Text = "Bác sĩ làm bệnh án :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Image = ((System.Drawing.Image)(resources.GetObject("label96.Image")));
            this.label96.Location = new System.Drawing.Point(5, 7);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(16, 16);
            this.label96.TabIndex = 266;
            this.label96.Click += new System.EventHandler(this.label96_Click);
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(13, 7);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(80, 16);
            this.label53.TabIndex = 100;
            this.label53.Text = "+ Hô hấp :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kb_hohap
            // 
            this.kb_hohap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_hohap.Enabled = false;
            this.kb_hohap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_hohap.Location = new System.Drawing.Point(152, 4);
            this.kb_hohap.Name = "kb_hohap";
            this.kb_hohap.Size = new System.Drawing.Size(632, 21);
            this.kb_hohap.TabIndex = 0;
            this.kb_hohap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // kb_tieuhoa
            // 
            this.kb_tieuhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kb_tieuhoa.Enabled = false;
            this.kb_tieuhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_tieuhoa.Location = new System.Drawing.Point(152, 27);
            this.kb_tieuhoa.Name = "kb_tieuhoa";
            this.kb_tieuhoa.Size = new System.Drawing.Size(632, 21);
            this.kb_tieuhoa.TabIndex = 1;
            this.kb_tieuhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.SystemColors.Control;
            this.label97.Image = ((System.Drawing.Image)(resources.GetObject("label97.Image")));
            this.label97.Location = new System.Drawing.Point(5, 28);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(16, 16);
            this.label97.TabIndex = 267;
            this.label97.Click += new System.EventHandler(this.label97_Click);
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(11, 28);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 16);
            this.label54.TabIndex = 101;
            this.label54.Text = "+ Tiêu hóa :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tab4
            // 
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
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(801, 579);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Trang 4";
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
            this.tk_tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_tinhtrang.Enabled = false;
            this.tk_tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_tinhtrang.Location = new System.Drawing.Point(24, 304);
            this.tk_tinhtrang.Multiline = true;
            this.tk_tinhtrang.Name = "tk_tinhtrang";
            this.tk_tinhtrang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_tinhtrang.Size = new System.Drawing.Size(760, 48);
            this.tk_tinhtrang.TabIndex = 3;
            // 
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Enabled = false;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(456, 486);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(40, 21);
            this.giorv.TabIndex = 10;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // ngayrv
            // 
            this.ngayrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrv.Enabled = false;
            this.ngayrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrv.Location = new System.Drawing.Point(349, 486);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(72, 21);
            this.ngayrv.TabIndex = 9;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(426, 488);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 295;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nguoinhan
            // 
            this.nguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoinhan.Enabled = false;
            this.nguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoinhan.Location = new System.Drawing.Point(387, 463);
            this.nguoinhan.Name = "nguoinhan";
            this.nguoinhan.Size = new System.Drawing.Size(397, 21);
            this.nguoinhan.TabIndex = 8;
            this.nguoinhan.TextChanged += new System.EventHandler(this.nguoinhan_TextChanged);
            this.nguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoinhan
            // 
            this.manguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoinhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoinhan.Enabled = false;
            this.manguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoinhan.Location = new System.Drawing.Point(349, 463);
            this.manguoinhan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoinhan.MaxLength = 9;
            this.manguoinhan.Name = "manguoinhan";
            this.manguoinhan.Size = new System.Drawing.Size(36, 21);
            this.manguoinhan.TabIndex = 7;
            this.manguoinhan.Validated += new System.EventHandler(this.manguoinhan_Validated);
            this.manguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // nguoigiao
            // 
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(387, 440);
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(397, 21);
            this.nguoigiao.TabIndex = 6;
            this.nguoigiao.TextChanged += new System.EventHandler(this.nguoigiao_TextChanged);
            this.nguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // manguoigiao
            // 
            this.manguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguoigiao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manguoigiao.Enabled = false;
            this.manguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguoigiao.Location = new System.Drawing.Point(349, 440);
            this.manguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manguoigiao.MaxLength = 9;
            this.manguoigiao.Name = "manguoigiao";
            this.manguoigiao.Size = new System.Drawing.Size(36, 21);
            this.manguoigiao.TabIndex = 5;
            this.manguoigiao.Validated += new System.EventHandler(this.manguoigiao_Validated);
            this.manguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(386, 510);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(333, 21);
            this.tenbs.TabIndex = 12;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoigiao_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(349, 510);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(36, 21);
            this.mabs.TabIndex = 11;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
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
            this.tk_dieutri.Location = new System.Drawing.Point(24, 378);
            this.tk_dieutri.Multiline = true;
            this.tk_dieutri.Name = "tk_dieutri";
            this.tk_dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_dieutri.Size = new System.Drawing.Size(760, 58);
            this.tk_dieutri.TabIndex = 4;
            // 
            // tk_phuongphap
            // 
            this.tk_phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_phuongphap.Enabled = false;
            this.tk_phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_phuongphap.Location = new System.Drawing.Point(24, 240);
            this.tk_phuongphap.Multiline = true;
            this.tk_phuongphap.Name = "tk_phuongphap";
            this.tk_phuongphap.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_phuongphap.Size = new System.Drawing.Size(760, 40);
            this.tk_phuongphap.TabIndex = 2;
            // 
            // tk_tomtat
            // 
            this.tk_tomtat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tk_tomtat.Enabled = false;
            this.tk_tomtat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_tomtat.Location = new System.Drawing.Point(24, 134);
            this.tk_tomtat.Multiline = true;
            this.tk_tomtat.Name = "tk_tomtat";
            this.tk_tomtat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tk_tomtat.Size = new System.Drawing.Size(760, 80);
            this.tk_tomtat.TabIndex = 1;
            // 
            // tk_benhly
            // 
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
            this.label77.Location = new System.Drawing.Point(8, 359);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(264, 16);
            this.label77.TabIndex = 122;
            this.label77.Text = "5. Hướng điều trị và các chế độ tiếp theo :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(8, 283);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(208, 16);
            this.label76.TabIndex = 121;
            this.label76.Text = "4. Tình trạng người bệnh ra viện :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(8, 218);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(160, 16);
            this.label75.TabIndex = 120;
            this.label75.Text = "3. Phương pháp điều trị :";
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
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(295, 487);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(54, 16);
            this.label90.TabIndex = 294;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(239, 510);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(110, 16);
            this.label87.TabIndex = 282;
            this.label87.Text = "Bác sĩ điều trị :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(239, 467);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(110, 16);
            this.label86.TabIndex = 280;
            this.label86.Text = "Người nhận hồ sơ :";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(239, 442);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(110, 16);
            this.label85.TabIndex = 279;
            this.label85.Text = "Người giao hồ sơ :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(0, 655);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(69, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(136, 655);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(69, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(68, 655);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(69, 25);
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
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.CadetBlue;
            this.label58.Location = new System.Drawing.Point(11, 29);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(182, 77);
            this.label58.TabIndex = 360;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.CadetBlue;
            this.label59.Location = new System.Drawing.Point(200, 29);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(808, 77);
            this.label59.TabIndex = 361;
            // 
            // frmHSBenhan_BNH
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 732);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butPhong);
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
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label59);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHSBenhan_BNH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ bệnh án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHSBenhan_BNH_KeyDown);
            this.Load += new System.EventHandler(this.frmHSBenhan_BNH_Load);
            this.p.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.p2.ResumeLayout(false);
            this.p1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.st5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.st2)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmHSBenhan_BNH_Load(object sender, System.EventArgs e)
        {
            user = m.user;
            thumucpic = "..\\..\\..\\picture_ba";
            if (!Directory.Exists("..\\pict_ba")) Directory.CreateDirectory("..\\pict_ba");
            if (!Directory.Exists(thumucpic)) Directory.CreateDirectory(thumucpic);
            else
            {
                try
                {
                    string[] files = Directory.GetFiles(thumucpic);
                    for (int i = 0; i < files.GetLength(0); i++) File.Delete(files[i].ToString());
                }
                catch { }
            }
            bPhonggiuong = m.bPhonggiuong;
            butPhong.Visible = bPhonggiuong;
            if (bPhonggiuong) dtg = m.get_data("select * from " + user + ".dmgiuong").Tables[0];
            dtdt = m.get_data("select * from " + user + ".doituong").Tables[0];
            nor_toanthan = m.nor_toanthan; nor_tuanhoan = m.nor_tuanhoan; nor_hohap = m.nor_hohap; nor_tieuhoa = m.nor_tieuhoa;
            nor_than = m.nor_than; nor_thankinh = m.nor_thankinh; nor_co = m.nor_co; nor_tmh = m.nor_tmh;
            nor_rhm = m.nor_rhm; nor_mat = m.nor_mat; nor_noitiet = m.nor_noitiet;
            dt = m.get_data("select ten,id,loai,stt from " + user + ".ba_danhmuc order by ten").Tables[0];
            list1.DisplayMember = "TEN";
            list1.ValueMember = "TEN";
            list1.DataSource = dt;

            stt1.DisplayMember = "STT";
            stt1.ValueMember = "STT";

            stt2.DisplayMember = "STT";
            stt2.ValueMember = "STT";

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;
            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
            listNv.DisplayMember = "MA";
            listNv.ValueMember = "HOTEN";
            listNv.DataSource = dtnv;

            listNv1.DisplayMember = "MA";
            listNv1.ValueMember = "HOTEN";
            listNv1.DataSource = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];

            tenditat.DisplayMember = "TEN";
            tenditat.ValueMember = "MA";
            tenditat.DataSource = m.get_data("select * from " + user + ".dmditat order by stt").Tables[0];

            sql = "select * from " + user + ".dmbenhan_bv where maba=" + i_maba;
            dtba = m.get_data(sql).Tables[0];
            tenba.DisplayMember = "TENVT";
            tenba.ValueMember = "MAVT";
            tenba.DataSource = dtba;
            tenba.SelectedIndex = 0;
            xem.SelectedIndex = 0;
            list.DisplayMember = "HOTEN";
            list.ValueMember = "MABN";
            load_list();
            list.ColumnWidths[0] = 60;
            list.ColumnWidths[1] = 150;
            list.ColumnWidths[2] = 0;
            list.SetSensive(2, 0, Color.Red);
            dscd.ReadXml("..\\..\\..\\xml\\m_bachidinh.xml");
            dataGrid2.DataSource = dscd.Tables[0];
            AddGridTableStyle1();
            //-lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
            //lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString() + "_" + dataGrid2.Name.ToString());
            for (int i = 0; i < chonin.Items.Count; i++) chonin.SetItemCheckState(i, CheckState.Checked);
            tinhtrang.SelectedIndex = 0; nuoiduong.SelectedIndex = 0;
        }

        private void load_list()
        {
            Cursor = Cursors.WaitCursor;
            if (rb1.Checked)
            {
                xem.Enabled = false;
                butChon.Enabled = false;
                sql = "select a.mabn,trim(b.hoten)||' ('||to_number(to_char(now,'yyyy'))-to_number(b.namsinh)||')' as ten,a.nhapkhoa,b.hoten,";
                sql += "b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                sql += "k.ma as phong,h.giuong,a.id,a.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                sql += "d.sovaovien,to_char(now,'dd/mm/yyyy hh24:mi') as ngayrv,h.mabs,h.tuoivao,h.chandoan, g.traituyen ";
                sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql += " inner join " + user + ".benhandt d on a.maql=d.maql left join " + user + ".bhyt g on a.maql=g.maql";
                sql += " inner join " + user + ".nhapkhoa h on a.id=h.id left join " + user + ".dmgiuong i on a.idgiuong=i.id";
                sql += " inner join " + user + ".btdtt j on b.matt=j.matt inner join " + user + ".btdquan m on b.maqu=m.maqu";
                sql += " inner join " + user + ".btdpxa n on b.maphuongxa=n.maphuongxa left join " + user + ".dmphong k on i.idphong=k.id";
                sql += " where d.loaiba=1 and a.xuatkhoa=0 and a.makp='" + s_makp + "'";
                if (i_phong != 0) sql += " and i.idphong=" + i_phong;
                sql += " order by a.ngay desc";
            }
            else
            {
                xem.Enabled = true;
                butChon.Enabled = true;
                butKhoa.Enabled = true;
                butIn.Enabled = true;
                sql = "select h.mabn,trim(b.hoten)||' ('||to_number(to_char(now,'yyyy'))-to_number(b.namsinh)||')' as ten,1 as nhapkhoa,b.hoten,";
                sql += "b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                sql += "k.ma as phong,h.giuong,a.id,h.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                sql += "d.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,a.mabs,h.tuoivao,h.chandoan, g.traituyen ";
                sql += " from " + user + ".xuatkhoa a inner join " + user + ".nhapkhoa h on a.id=h.id";
                sql += " inner join " + user + ".benhandt d on h.maql=d.maql inner join " + user + ".btdbn b on d.mabn=b.mabn";
                sql += " left join " + user + ".bhyt g on h.maql=g.maql left join " + user + ".dmgiuong i on h.giuong=i.ma";
                sql += " inner join " + user + ".btdtt j on b.matt=j.matt inner join " + user + ".btdquan m on b.maqu=m.maqu";
                sql += " inner join " + user + ".btdpxa n on b.maphuongxa=n.maphuongxa left join " + user + ".dmphong k on i.idphong=k.id";
                sql += " where h.makp='" + s_makp + "'";
                if (i_phong != 0) sql += " and i.idphong=" + i_phong;
                sql += " order by a.ngay desc";
            }
            ds = m.get_data(sql);
            list.DataSource = ds.Tables[0];
            Cursor = Cursors.Default;
        }

        private void bKethuc_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tenba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void manguoigiao_Validated(object sender, System.EventArgs e)
        {
            if (manguoigiao.Text == "") return;
            DataRow r = m.getrowbyid(dtnv, "ma='" + manguoigiao.Text + "'");
            if (r != null) nguoigiao.Text = r["hoten"].ToString();
            else nguoigiao.Text = "";
        }

        private void nguoigiao_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == nguoigiao)
            {
                Filt_dmbs(nguoigiao.Text);
                listNv.BrowseToDanhmuc(nguoigiao, manguoigiao, manguoinhan, 35);
            }
        }

        private void nguoigiao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listNv.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listNv.Visible) listNv.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void nguoinhan_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == nguoinhan)
            {
                Filt_dmbs(nguoinhan.Text);
                listNv.BrowseToDanhmuc(nguoinhan, manguoinhan, ngayrv, 35);
            }
        }

        private void manguoinhan_Validated(object sender, System.EventArgs e)
        {
            if (manguoinhan.Text == "") return;
            DataRow r = m.getrowbyid(dtnv, "ma='" + manguoinhan.Text + "'");
            if (r != null) nguoinhan.Text = r["hoten"].ToString();
            else nguoinhan.Text = "";
        }

        private void Filt_dmbs1(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listNv1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void Filt_dmbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listNv.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }
        private void mabs_Validated(object sender, System.EventArgs e)
        {
            if (mabs.Text == "") return;
            DataRow r = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
            if (r != null) tenbs.Text = r["hoten"].ToString();
            else tenbs.Text = "";
        }

        private void tenbs_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_dmbs(tenbs.Text);
                listNv.BrowseToDanhmuc(tenbs, mabs, tenbs_pass, 35);
            }
        }

        private void icd_kkb_Validated(object sender, System.EventArgs e)
        {
            if (icd_kkb.Text != "")
            {
                cd_kkb.Text = m.get_vviet(icd_kkb.Text);
                if (cd_kkb.Text == "" && icd_kkb.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kkb.Text, cd_kkb.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_kkb.Text = f.mTen;
                        icd_kkb.Text = f.mICD;
                    }
                }
            }
        }

        private void icd_kemtheo_Validated(object sender, System.EventArgs e)
        {
            if (icd_kemtheo.Text != "")
            {
                cd_kemtheo.Text = m.get_vviet(icd_kemtheo.Text);
                if (cd_kemtheo.Text == "" && icd_kemtheo.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kemtheo.Text, cd_kemtheo.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_kemtheo.Text = f.mTen;
                        icd_kemtheo.Text = f.mICD;
                    }
                }
            }
        }

        private void cd_kkb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void cd_kkb_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_kkb)
            {
                Filt_ICD(cd_kkb.Text);
                listICD.BrowseToICD10(cd_kkb, icd_kkb, icd_kemtheo, icd_kkb.Location.X, icd_kkb.Location.Y + icd_kkb.Height, icd_kkb.Width + cd_kkb.Width + 2, icd_kkb.Height);
            }
        }

        private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_kemtheo)
            {
                Filt_ICD(cd_kemtheo.Text);
                listICD.BrowseToICD10(cd_kemtheo, icd_kemtheo, phanbiet, icd_kemtheo.Location.X, icd_kemtheo.Location.Y + icd_kemtheo.Height, icd_kemtheo.Width + cd_kemtheo.Width + 2, icd_kemtheo.Height);
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

        private void tim_Enter(object sender, System.EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
            }
        }

        private void emp_text()
        {
            s_sovaovien = ""; i_madoituong = 0; l_id = 0; l_idkhoa = 0; l_maql = 0; l_idthuchien = 0; dscd.Clear();
            mabn.Text = ""; hoten.Text = ""; namsinh.Text = ""; diachi.Text = ""; ngay.Text = ""; phong.Text = ""; giuong.Text = ""; sothe.Text = ""; chandoan.Text = "";
            lydo.Text = ""; lanthu.Value = 1; hb_benhly.Text = ""; hb_giadinh.Text = ""; hb_banthan.Text = ""; kb_toanthan.Text = "";
            kb_tuanhoan.Text = ""; kb_hohap.Text = ""; kb_tieuhoa.Text = ""; kb_than.Text = ""; kb_thankinh.Text = ""; kb_co.Text = "";
            kb_noitiet.Text = ""; kb_tomtat.Text = "";
            mach.Text = ""; nhietdo.Text = ""; huyetap.Text = ""; nhiptho.Text = ""; cannang.Text = ""; chieucao.Text = "";
            icd_kkb.Text = ""; cd_kkb.Text = ""; icd_kemtheo.Text = ""; cd_kemtheo.Text = ""; phanbiet.Text = ""; tienluong.Text = "";
            dieutri.Text = ""; ngayvk.Text = ""; giovk.Text = ""; mabsnb.Text = ""; tenbsnb.Text = "";
            tk_benhly.Text = ""; tk_tomtat.Text = ""; tk_phuongphap.Text = ""; tk_tinhtrang.Text = ""; tk_dieutri.Text = "";
            manguoigiao.Text = ""; nguoigiao.Text = ""; manguoinhan.Text = ""; nguoinhan.Text = ""; mabs.Text = ""; tenbs.Text = "";
            st1.Value = 0; st2.Value = 0; st3.Value = 0; st4.Value = 0; st5.Value = 0; st6.Value = 0; khac.Text = "";
            tenbs_pass.Text = ""; tenbsnb_pass.Text = "";
            benhnhan.Text = ""; lydovv.Text = ""; conang.Text = ""; thucthe.Text = ""; clsdaco.Text = "";
            conthu.Value = 1; para1.Text = ""; para2.Text = ""; para3.Text = ""; para4.Text = "";
            tinhtrang.SelectedIndex = 0; cannang_s.Text = ""; ditat.Checked = false; maditat.Text = ""; tenditat.SelectedIndex = -1;
            tinhthan.Text = ""; vandong.Text = ""; benhlykhac.Text = ""; nuoiduong.SelectedIndex = 0; caisua.Text = "";
            vuontre.Checked = false; tainha.Checked = false; lao.Checked = false; bailiet.Checked = false; soi.Checked = false;
            hoga.Checked = false; uonvan.Checked = false; bachhau.Checked = false; tckhac.Checked = false;
            cuthe.Text = ""; chieucao.Text = ""; vongnguc.Text = ""; vongdau.Text = "";
            get_file(0); bHinh = false; chkHinh.Enabled = false;
            emp_hinh();
            chkHinh.Enabled = m.get_data("select * from " + user + ".ba_hinh where id=" + int.Parse(dtba.Rows[tenba.SelectedIndex]["maba"].ToString()) + " order by stt").Tables[0].Rows.Count > 0;
            stt1.Enabled = chkHinh.Checked; stt2.Enabled = chkHinh.Checked;
            ena_object(true);
        }

        private void emp_hinh()
        {
            pic1.Tag = filebmp;
            fstr = new System.IO.FileStream(pic1.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
            map = new Bitmap(Image.FromStream(fstr));
            pic1.Image = (Bitmap)map;
            image1 = new byte[fstr.Length];
            fstr.Read(image1, 0, System.Convert.ToInt32(fstr.Length));
            fstr.Close();
            pic1.Tag = image1;
            System.IO.File.Copy(filebmp, f1, true);
            //
            pic2.Tag = filebmp;
            fstr = new System.IO.FileStream(pic2.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
            map = new Bitmap(Image.FromStream(fstr));
            pic2.Image = (Bitmap)map;
            image2 = new byte[fstr.Length];
            fstr.Read(image2, 0, System.Convert.ToInt32(fstr.Length));
            fstr.Close();
            pic2.Tag = image2;
            System.IO.File.Copy(filebmp, f2, true);
        }

        private void picture(PictureBox pic, string tenfile)
        {
            pic.Image = (Bitmap)map;
            pic.Tag = image;
            map.Save(tenfile);
        }

        private void get_mabn(string _mabn)
        {
            emp_text();
            DataRow r = m.getrowbyid(ds.Tables[0], "mabn='" + _mabn + "'");
            if (r != null)
            {
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                phai.Text = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                diachi.Text = r["diachi"].ToString();
                phong.Text = r["phong"].ToString();
                giuong.Text = r["giuong"].ToString();
                sothe.Text = r["sothe"].ToString();
                ngay.Text = r["ngayvv"].ToString();
                chandoan.Text = r["chandoanvv"].ToString();
                ngayvk.Text = r["ngayvk"].ToString().Substring(0, 10);
                giovk.Text = r["ngayvk"].ToString().Substring(11);
                mabsnb.Text = r["mabs"].ToString();
                traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());                
                DataRow r1 = m.getrowbyid(dtnv, "ma='" + mabsnb.Text + "'");
                if (r1 != null)
                {
                    tenbsnb.Text = r1["hoten"].ToString();
                    tenbsnb_pass.Text = r1["password_"].ToString();
                }
                else tenbsnb.Text = "";
                l_idkhoa = decimal.Parse(r["id"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                i_madoituong = int.Parse(r["madoituong"].ToString());
                s_sovaovien = r["sovaovien"].ToString();
                icd_kkb.Text = r["maicd"].ToString();
                cd_kkb.Text = r["chandoanvk"].ToString();
                if (rb2.Checked)
                {
                    ngayrv.Text = r["ngayrv"].ToString().Substring(0, 10);
                    giorv.Text = r["ngayrv"].ToString().Substring(11);
                }
                mabs.Text = r["mabs"].ToString();
                r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                if (r1 != null)
                {
                    tenbs.Text = r1["hoten"].ToString();
                    tenbs_pass.Text = r1["password_"].ToString();
                }
                if (bPhonggiuong) butPhong.Enabled = r["nhapkhoa"].ToString() == "0";
                load_data();
                ena_object(false);
                if (r["nhapkhoa"].ToString() == "0")
                {
                    butChuyenphong.Enabled = false; butChamsoc.Enabled = false; butKhoa.Enabled = false; xem.Enabled = false;
                    butDausinhton.Enabled = false; butChidinh.Enabled = false; butDieutri.Enabled = false;
                    butAn.Enabled = false; butMau.Enabled = false; butDich.Enabled = false; butDausinhton.Enabled = false; butPhanung.Enabled = false;
                    butChon.Enabled = false; butPttt.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(
lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
        }

        private void load_data()
        {
            Cursor = Cursors.WaitCursor;
            bool bFound = false; xxx = user + m.mmyy(ngay.Text);
            l_idthuchien = m.get_idthuchien(ngay.Text, l_idkhoa);
            DataRow r1;
            if (l_idthuchien != 0)
            {
                l_id = m.get_idchung(ngay.Text, l_idthuchien);
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_chung where id=" + l_id).Tables[0].Rows)
                {
                    lydo.Text = r["lydo"].ToString();
                    lanthu.Value = decimal.Parse(r["lanthu"].ToString());
                    hb_benhly.Text = r["hb_benhly"].ToString();
                    hb_banthan.Text = r["hb_banthan"].ToString();
                    hb_giadinh.Text = r["hb_giadinh"].ToString();
                    kb_toanthan.Text = r["kb_toanthan"].ToString();
                    kb_tuanhoan.Text = r["kb_tuanhoan"].ToString();
                    kb_hohap.Text = r["kb_hohap"].ToString();
                    kb_tieuhoa.Text = r["kb_tieuhoa"].ToString();
                    kb_than.Text = r["kb_than"].ToString();
                    kb_thankinh.Text = r["kb_thankinh"].ToString();
                    kb_co.Text = r["kb_co"].ToString();
                    kb_noitiet.Text = r["kb_noitiet"].ToString();
                    kb_tomtat.Text = r["kb_tomtat"].ToString();
                    phanbiet.Text = r["phanbiet"].ToString();
                    tienluong.Text = r["tienluong"].ToString();
                    dieutri.Text = r["dieutri"].ToString();
                    tk_benhly.Text = r["tk_benhly"].ToString();
                    tk_tomtat.Text = r["tk_tomtat"].ToString();
                    tk_phuongphap.Text = r["tk_phuongphap"].ToString();
                    tk_tinhtrang.Text = r["tk_tinhtrang"].ToString();
                    tk_dieutri.Text = r["tk_dieutri"].ToString();
                    manguoigiao.Text = r["nguoigiao"].ToString();
                    manguoinhan.Text = r["nguoinhan"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + manguoigiao.Text + "'");
                    if (r1 != null) nguoigiao.Text = r1["hoten"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + manguoinhan.Text + "'");
                    if (r1 != null) nguoinhan.Text = r1["hoten"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_hinh where id=" + l_id + " order by stt").Tables[0].Rows)
                {
                    image = new byte[0];
                    image = (byte[])(r["image"]);
                    memo = new MemoryStream(image);
                    map = new Bitmap(Image.FromStream(memo));
                    picture((int.Parse(r["stt"].ToString()) == 1) ? pic1 : pic2, (int.Parse(r["stt"].ToString()) == 1) ? f1 : f2);
                    bHinh = true; chkHinh.Enabled = true; chkHinh.Checked = true;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_kbdausinhton where id=" + l_id).Tables[0].Rows)
                {
                    mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                    nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                    huyetap.Text = r["huyetap"].ToString();
                    nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                    cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_tkhoso where id=" + l_id).Tables[0].Rows)
                {
                    switch (int.Parse(r["ma"].ToString()))
                    {
                        case 1: st1.Value = decimal.Parse(r["so"].ToString()); break;
                        case 2: st2.Value = decimal.Parse(r["so"].ToString()); break;
                        case 3: st3.Value = decimal.Parse(r["so"].ToString()); break;
                        case 4: st4.Value = decimal.Parse(r["so"].ToString()); break;
                        case 5: st5.Value = decimal.Parse(r["so"].ToString()); khac.Text = r["khac"].ToString(); break;
                        case 6: st6.Value = decimal.Parse(r["so"].ToString()); break;
                    }
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_tomtat where id=" + l_id).Tables[0].Rows)
                {
                    benhnhan.Text = r["benhnhan"].ToString();
                    lydovv.Text = r["lydo"].ToString();
                    conang.Text = r["conang"].ToString();
                    thucthe.Text = r["thucthe"].ToString();
                    clsdaco.Text = r["clsdaco"].ToString();
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_nhi where id=" + l_id).Tables[0].Rows)
                {
                    conthu.Value = decimal.Parse(r["conthu"].ToString());
                    para1.Text = r["para"].ToString().Substring(0, 2);
                    para2.Text = r["para"].ToString().Substring(2, 2);
                    para3.Text = r["para"].ToString().Substring(4, 2);
                    para4.Text = r["para"].ToString().Substring(6, 2);
                    tinhtrang.SelectedIndex = int.Parse(r["tinhtrang"].ToString());
                    cannang_s.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    ditat.Checked = r["ditat"].ToString() == "1";
                    maditat.Text = r["tenditat"].ToString();
                    tenditat.SelectedValue = maditat.Text;
                    maditat.Enabled = ditat.Checked;
                    tenditat.Enabled = maditat.Enabled;
                    tinhthan.Text = r["tinhthan"].ToString();
                    vandong.Text = r["vandong"].ToString();
                    benhlykhac.Text = r["benhlykhac"].ToString();
                    nuoiduong.SelectedIndex = int.Parse(r["nuoiduong"].ToString());
                    caisua.Text = (r["caisua"].ToString() != "0") ? r["caisua"].ToString() : "";
                    vuontre.Checked = r["vuontre"].ToString() == "1";
                    tainha.Checked = r["tainha"].ToString() == "1";
                    lao.Checked = r["lao"].ToString() == "1";
                    bailiet.Checked = r["bailiet"].ToString() == "1";
                    soi.Checked = r["soi"].ToString() == "1";
                    hoga.Checked = r["hoga"].ToString() == "1";
                    uonvan.Checked = r["uonvan"].ToString() == "1";
                    bachhau.Checked = r["bachhau"].ToString() == "1";
                    tckhac.Checked = r["tckhac"].ToString() == "1";
                    cuthe.Text = r["cuthe"].ToString();
                    cuthe.Enabled = tckhac.Checked;
                    chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    vongdau.Text = (r["vongdau"].ToString() != "0") ? r["vongdau"].ToString() : "";
                    vongnguc.Text = (r["vongnguc"].ToString() != "0") ? r["vongnguc"].ToString() : "";
                    break;
                }
            }
            else
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_chung where maql=" + l_maql).Tables[0].Rows)
                {
                    lydo.Text = r["lydo"].ToString();
                    hb_benhly.Text = r["hb_benhly"].ToString();
                    hb_banthan.Text = r["hb_banthan"].ToString();
                    hb_giadinh.Text = r["hb_giadinh"].ToString();
                    kb_toanthan.Text = r["kb_toanthan"].ToString();
                    bFound = true;
                    break;
                }
                if (bFound)
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_dausinhton where maql=" + l_maql).Tables[0].Rows)
                    {
                        mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                        nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                        huyetap.Text = r["huyetap"].ToString();
                        nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                        cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                        break;
                    }
                }
            }
            if (mabs.Text == "" && s_mabs != "")
            {
                mabs.Text = s_mabs;
                r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                if (r1 != null)
                {
                    tenbs.Text = r1["hoten"].ToString();
                    tenbs_pass.Text = r1["password_"].ToString();
                }
                else tenbs.Text = "";
            }
            foreach (DataRow r in m.get_data("select * from " + user + ".cdkemtheo where loai=2 and id=" + l_idkhoa + " order by stt").Tables[0].Rows)
            {
                cd_kemtheo.Text = r["chandoan"].ToString();
                icd_kemtheo.Text = r["maicd"].ToString();
                break;
            }
            load_chidinh();
            Cursor = Cursors.Default;
        }

        private void load_chidinh()
        {
            string tu = ngay.Text.Substring(0, 10), den = (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10);
            sql = "select coalesce(e.stt,0) as stt,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,d.hoten as tenbs,b.ten,' ' as ketqua ";
            sql += " from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id left join " + user + ".btdkp_bv c on a.makp=c.makp left join " + user + ".dmbs d on a.mabs=d.mabs left join " + user + ".dmchidinh e on b.id_loai=e.idloaivp";
            sql += " where a.mabn='" + mabn.Text + "' and to_date(a.ngay,'dd/mm/yy') between to_date('" + tu + "','dd/mm/yy') and to_date('" + den + "','dd/mm/yy')";
            sql += " order by a.ngay,b.stt";
            dscd = m.get_data_mmyy(sql, tu, den, false);
            dataGrid2.DataSource = dscd.Tables[0];
            st1.Value = dscd.Tables[0].Select("stt=2").Length;
            st2.Value = dscd.Tables[0].Select("stt=3").Length;
            st3.Value = dscd.Tables[0].Select("stt=5").Length;
            st4.Value = dscd.Tables[0].Select("stt>=10 and stt<=20").Length;
            st6.Value = dscd.Tables[0].Rows.Count;
            DataTable tmp = m.get_data("select b.stt from " + user + m.mmyy(ngay.Text) + ".ba_scan a," + user + ".ba_loaiphieu b where a.loai=b.id and a.id=" + l_id).Tables[0];
            st1.Value += tmp.Select("stt=2").Length;
            st2.Value += tmp.Select("stt=3").Length;
            st3.Value += tmp.Select("stt=5").Length;
            st4.Value += tmp.Select("stt>=10 and stt<=20").Length;
            st6.Value += tmp.Rows.Count;
            st5.Value = st6.Value - st1.Value - st2.Value - st3.Value - st4.Value;
        }

        private bool kiemtra()
        {
            if (icd_kkb.Text == "" || cd_kkb.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Chẩn đoán vào khoa chưa hợp lệ !"), LibMedi.AccessData.Msg);
                icd_kkb.Focus();
                return false;
            }
            if (mabsnb.Text == "" || tenbsnb.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ làm bệnh án chưa hợp lệ !"), LibMedi.AccessData.Msg);
                mabsnb.Focus();
                return false;
            }
            DataRow r = m.getrowbyid(dtnv, "ma='" + mabsnb.Text + "'");
            if (r == null)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ làm bệnh án chưa hợp lệ !"), LibMedi.AccessData.Msg);
                mabsnb.Focus();
                return false;
            }
            if (!bAdmin)
            {
                if (tenbsnb_pass.Text != r["password_"].ToString())
                {
                    MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu bác sĩ làm bệnh án chưa hợp lệ !"), LibMedi.AccessData.Msg);
                    tenbsnb_pass.Focus();
                    return false;
                }
            }
            if (mabs.Text != "" && tenbs.Text != "")
            {
                r = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                if (r == null)
                {
                    MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ điều trị chưa hợp lệ !"), LibMedi.AccessData.Msg);
                    mabs.Focus();
                    return false;
                }
                if (!bAdmin)
                {
                    if (tenbs_pass.Text != r["password_"].ToString())
                    {
                        MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu bác sĩ điều trị chưa hợp lệ !"), LibMedi.AccessData.Msg);
                        tenbs_pass.Focus();
                        return false;
                    }
                }
            }
            if (bPhonggiuong && giuong.Text == "" && butPhong.Enabled)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu chọn phòng/giường !"), LibMedi.AccessData.Msg);
                butPhong.Focus();
                return false;
            }
            return true;
        }

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            if (!kiemtra()) return;
            xxx = user + m.mmyy(ngay.Text);
            bool bNhapkhoa = m.getrowbyid(ds.Tables[0], "nhapkhoa=0 and mabn='" + mabn.Text + "'") != null;
            if (bNhapkhoa) upd_nhapkhoa();
            m.execute_data("update benhandt set mabs='" + mabsnb.Text + "' where maql=" + l_maql);
            l_idthuchien = m.get_idthuchien(ngay.Text, l_idkhoa);
            if (l_idthuchien == 0)
            {
                l_idthuchien = m.get_capid(-300);
                m.upd_ba_thuchien(ngay.Text, l_idthuchien, mabn.Text, l_maql, l_idkhoa, s_makp, phong.Text, giuong.Text, chandoan.Text);
            }
            l_id = m.get_idchung(ngay.Text, l_idthuchien);
            if (l_id == 0) l_id = m.get_capid(-301);
            if (!m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, lanthu.Value, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
                kb_hohap.Text, kb_tieuhoa.Text, kb_than.Text, kb_thankinh.Text, kb_co.Text, "", "", "", kb_noitiet.Text, "", kb_tomtat.Text, phanbiet.Text,
                tienluong.Text, dieutri.Text, mabsnb.Text, tk_benhly.Text, tk_tomtat.Text, tk_phuongphap.Text, tk_tinhtrang.Text, tk_dieutri.Text, manguoigiao.Text, manguoinhan.Text, mabs.Text, i_userid))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }
            m.upd_ba_kbdausinhton(ngay.Text, mabn.Text, l_id, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0);
            m.upd_ba_nhi(ngay.Text, l_id, conthu.Value, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), tinhtrang.SelectedIndex, (cannang_s.Text != "") ? decimal.Parse(cannang_s.Text) : 0, (ditat.Checked) ? 1 : 0, maditat.Text, tinhthan.Text, vandong.Text, benhlykhac.Text, nuoiduong.SelectedIndex, (caisua.Text != "") ? decimal.Parse(caisua.Text) : 0, (vuontre.Checked) ? 1 : 0, (tainha.Checked) ? 1 : 0, (lao.Checked) ? 1 : 0,
                (bailiet.Checked) ? 1 : 0, (soi.Checked) ? 1 : 0, (hoga.Checked) ? 1 : 0, (uonvan.Checked) ? 1 : 0, (bachhau.Checked) ? 1 : 0, (tckhac.Checked) ? 1 : 0, cuthe.Text, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0, (vongnguc.Text != "") ? decimal.Parse(vongnguc.Text) : 0, (vongdau.Text != "") ? decimal.Parse(vongdau.Text) : 0);
            if (cd_kemtheo.Text != "") m.upd_cdkemtheo(l_idkhoa, l_maql, 2, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            m.upd_ba_tomtat(ngay.Text, l_id, benhnhan.Text, lydovv.Text, conang.Text, thucthe.Text, clsdaco.Text);
            m.execute_data("delete from " + xxx + ".ba_hbdacdiem where id=" + l_id);
            m.execute_data("delete from " + xxx + ".ba_tkhoso where id=" + l_id);
            if (st1.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 1, "", st1.Value);
            if (st2.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 2, "", st2.Value);
            if (st3.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 3, "", st3.Value);
            if (st4.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 4, "", st4.Value);
            if (st5.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 5, khac.Text, st5.Value);
            if (st6.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 6, "", st6.Value);
            if (phanbiet.Text != "") upd_danhmuc(200, phanbiet.Text);
            if (tk_phuongphap.Text != "") upd_danhmuc(201, tk_phuongphap.Text);
            if (tk_tinhtrang.Text != "") upd_danhmuc(202, tk_tinhtrang.Text);
            //hinh
            if (bHinh)
            {
                upd_hinh(f1, 1);
                upd_hinh(f2, 2);
            }
            //
            ena_object(true);
            maditat.Enabled = false; tenditat.Enabled = false; cuthe.Enabled = false;
            if (bNhapkhoa) load_list();
        }

        private void upd_hinh(string tenfile, int stt)
        {
            if (File.Exists(tenfile))
            {
                fstr = new System.IO.FileStream(tenfile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                m.upd_ba_hinh(ngay.Text, l_id, stt, image);
            }
        }

        private void upd_nhapkhoa()
        {
            bool bNew = true;
            decimal idgiuong = 0;
            if (bPhonggiuong)
            {
                bNew = m.get_data("select id from " + user + ".nhapkhoa where maql=" + l_maql + " and makp='" + s_makp + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngayvk.Text + " " + giovk.Text + "'").Tables[0].Rows.Count == 0;
                if (bNew)
                {
                    l_idkhoa = m.get_id(l_maql, s_makp, ngayvk.Text + " " + giovk.Text);
                    DataRow r2, r1 = m.getrowbyid(dtg, "ma='" + giuong.Text + "'");
                    string fie = "gia_th";
                    decimal id = v.get_id_vpkhoa;
                    if (r1 != null)
                    {
                        r2 = m.getrowbyid(dtdt, "madoituong=" + i_madoituong);
                        if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                        decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        idgiuong = decimal.Parse(r1["id"].ToString());
                        m.upd_theodoigiuong(id, s_makp, mabn.Text, l_maql, l_idkhoa, i_madoituong, int.Parse(r1["id"].ToString()), ngayvk.Text + " " + giovk.Text, decimal.Parse(r1[fie].ToString()) * tygia, i_userid);
                        m.execute_data("update dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + int.Parse(r1["id"].ToString()));
                        itable = m.tableid("", "theodoigiuong");
                        m.upd_eve_tables(itable, i_userid, "ins");
                        m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + id));
                    }
                    bNew = false;
                }
            }
            if (bNew) l_idkhoa = m.get_id(l_maql, s_makp, ngayvk.Text + " " + giovk.Text);
            int i_maba = 11;
            DataRow r3 = m.getrowbyid(dtba, "mavt='" + tenba.SelectedValue.ToString() + "'");
            if (r3 != null) i_maba = int.Parse(r3["maba"].ToString());
            itable = m.tableid("", "nhapkhoa");
            if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".nhapkhoa", "id=" + l_idkhoa));
            }
            string stuoi = m.get_tuoivao(l_maql), khoachuyen = "01", ngaychuyen = ngayvk.Text + " " + giovk.Text;
            foreach (DataRow r in m.get_data("select makp,ngaychuyen from " + user + ".chuyenkhoa where khoaden='" + s_makp + "'" + " and maql=" + l_maql + " order by ngaychuyen desc").Tables[0].Rows)
            {
                ngaychuyen = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngaychuyen"].ToString()));
                khoachuyen = r["makp"].ToString();
                break;
            }
            if (!m.upd_nhapkhoa(l_idkhoa, mabn.Text, l_maql, l_maql, s_makp, i_maba, ngaychuyen, ngaychuyen, stuoi, giuong.Text, khoachuyen, cd_kkb.Text, icd_kkb.Text, mabsnb.Text, 1, i_userid))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin vào khoa !"), LibMedi.AccessData.Msg);
                return;
            }
            if (idgiuong != 0) m.execute_data("update hiendien set idgiuong=" + idgiuong + " where id=" + l_idkhoa);
        }

        private void upd_danhmuc(int loai, string ten)
        {
            if (ten != "")
            {
                DataRow r = m.getrowbyid(dt, "ten='" + ten + "'");
                if (r == null)
                {
                    decimal _id = m.get_capid(-50);
                    m.upd_ba_danhmuc(_id, loai, 0, ten);
                    DataRow r1 = dt.NewRow();
                    r1["id"] = _id;
                    r1["loai"] = loai;
                    r1["stt"] = 0;
                    r1["ten"] = ten;
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
                lydo.Enabled = !ena; lanthu.Enabled = !ena; hb_benhly.Enabled = !ena; hb_giadinh.Enabled = !ena; hb_banthan.Enabled = !ena; kb_toanthan.Enabled = !ena;
                kb_tuanhoan.Enabled = !ena; kb_hohap.Enabled = !ena; kb_tieuhoa.Enabled = !ena; kb_than.Enabled = !ena; kb_thankinh.Enabled = !ena; kb_co.Enabled = !ena;
                kb_noitiet.Enabled = !ena; kb_tomtat.Enabled = !ena;
                mach.Enabled = !ena; nhietdo.Enabled = !ena; huyetap.Enabled = !ena; nhiptho.Enabled = !ena; cannang.Enabled = !ena; chieucao.Enabled = !ena;
                icd_kemtheo.Enabled = !ena; cd_kemtheo.Enabled = !ena; phanbiet.Enabled = !ena; tienluong.Enabled = !ena;
                dieutri.Enabled = !ena; tk_benhly.Enabled = !ena; tk_tomtat.Enabled = !ena; tk_phuongphap.Enabled = !ena; tk_tinhtrang.Enabled = !ena; tk_dieutri.Enabled = !ena;
                ngayrv.Enabled = !ena; giorv.Enabled = !ena; manguoigiao.Enabled = !ena; nguoigiao.Enabled = !ena; manguoinhan.Enabled = !ena; nguoinhan.Enabled = !ena; mabs.Enabled = !ena; tenbs.Enabled = !ena;
                tenbs_pass.Enabled = !ena; tenbsnb_pass.Enabled = !ena; ngayvk.Enabled = !ena; giovk.Enabled = !ena; icd_kkb.Enabled = !ena; cd_kkb.Enabled = !ena; mabsnb.Enabled = !ena; tenbsnb.Enabled = !ena;
                mabn.Enabled = ena; list.Enabled = ena; butChuyenphong.Enabled = !ena;
                benhnhan.Enabled = !ena; lydovv.Enabled = !ena; conang.Enabled = !ena; thucthe.Enabled = !ena; clsdaco.Enabled = !ena;
                if (i_loai == 0 || i_loai == 2) butChamsoc.Enabled = !ena;
                butKhoa.Enabled = ena; xem.Enabled = !ena; butDausinhton.Enabled = !ena; butChidinh.Enabled = !ena;
                if (i_loai == 0 || i_loai == 1) butDieutri.Enabled = !ena;
                butAn.Enabled = !ena; butMau.Enabled = !ena; butDich.Enabled = !ena; butDausinhton.Enabled = !ena; butPhanung.Enabled = !ena;
                butKemtheo.Enabled = !ena; butChon.Enabled = !ena; butPttt.Enabled = !ena; butKethuc.Enabled = ena;
                butLuu.Enabled = !ena; butBoqua.Enabled = !ena; butIn.Enabled = ena; tim.Enabled = ena;
                conthu.Enabled = !ena; para1.Enabled = !ena; para2.Enabled = !ena; para3.Enabled = !ena; para4.Enabled = !ena;
                tinhtrang.Enabled = !ena; cannang_s.Enabled = !ena; ditat.Enabled = !ena;
                //maditat.Enabled=!ena;tenditat.Enabled=!ena;
                tinhthan.Enabled = !ena; vandong.Enabled = !ena; benhlykhac.Enabled = !ena; nuoiduong.Enabled = !ena; caisua.Enabled = !ena;
                vuontre.Enabled = !ena; tainha.Enabled = !ena; lao.Enabled = !ena; bailiet.Enabled = !ena; soi.Enabled = !ena;
                hoga.Enabled = !ena; uonvan.Enabled = !ena; bachhau.Enabled = !ena; tckhac.Enabled = !ena;
                //cuthe.Enabled=!ena;
                chieucao.Enabled = !ena; vongnguc.Enabled = !ena; vongdau.Enabled = !ena;
            }
        }

        private void butBoqua_Click(object sender, System.EventArgs e)
        {
            ena_object(true);
            maditat.Enabled = false; tenditat.Enabled = false; cuthe.Enabled = false;
        }

        private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) get_mabn(list.SelectedValue.ToString());
        }

        private void list_DoubleClick(object sender, System.EventArgs e)
        {
            get_mabn(list.SelectedValue.ToString());
        }

        private void mabn_Validated(object sender, System.EventArgs e)
        {
            if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
            if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            get_mabn(mabn.Text);
        }

        private void butKhoa_Click(object sender, System.EventArgs e)
        {
            frmChonkp f = new frmChonkp(m, s_makp, s_mabs);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                s_makp = f.s_makp; s_tenkp = f.s_tenkp; s_mabs = f.s_mabs; i_phong = f.i_phong;
                string s_maba = m.get_data("select maba from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0].Rows[0][0].ToString();
                sql = "select * from " + user + ".dmbenhan_bv where loaiba=1 and maba in (" + s_maba + ")" + " order by maba";
                dtba = m.get_data(sql).Tables[0];
                load_list();
            }
        }

        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dscd.Tables[0].TableName;
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
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa/phòng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenbs";
            TextCol.HeaderText = "Bác sĩ";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Chỉ định";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ketqua";
            TextCol.HeaderText = "Kết quả";
            TextCol.Width = 175;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        #region Normal
        private void st1_Validated(object sender, System.EventArgs e)
        {
            st6.Value = st1.Value + st2.Value + st3.Value + st4.Value + st5.Value;
        }

        private void label92_Click(object sender, System.EventArgs e)
        {
            kb_toanthan.Text = nor_toanthan;
        }

        private void label94_Click(object sender, System.EventArgs e)
        {
            kb_tuanhoan.Text = nor_tuanhoan;
            kb_hohap.Text = nor_hohap;
            kb_tieuhoa.Text = nor_tieuhoa;
            kb_than.Text = nor_than;
            kb_thankinh.Text = nor_thankinh;
            kb_co.Text = nor_co;
        }

        private void label95_Click(object sender, System.EventArgs e)
        {
            kb_tuanhoan.Text = nor_tuanhoan;
        }

        private void label96_Click(object sender, System.EventArgs e)
        {
            kb_hohap.Text = nor_hohap;
        }

        private void label97_Click(object sender, System.EventArgs e)
        {
            kb_tieuhoa.Text = nor_tieuhoa;
        }

        private void label98_Click(object sender, System.EventArgs e)
        {
            kb_than.Text = nor_than;
        }

        private void label99_Click(object sender, System.EventArgs e)
        {
            kb_thankinh.Text = nor_thankinh;
        }

        private void label100_Click(object sender, System.EventArgs e)
        {
            kb_co.Text = nor_co;
        }

        private void label104_Click(object sender, System.EventArgs e)
        {
            kb_noitiet.Text = nor_noitiet;
        }
        #endregion

        private void butChidinh_Click(object sender, System.EventArgs e)
        {
            string stuoi = m.get_tuoivao(l_maql).Trim();
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, mabn.Text, hoten.Text, stuoi, ngayvk.Text + " " + giovk.Text, s_makp, s_tenkp, i_madoituong, 1, l_maql, l_maql, l_idkhoa, i_userid, "nhapkhoa", sothe.Text, "", "", (s_mabs != "") ? s_mabs : mabsnb.Text, cd_kkb.Text, bAdmin, traituyen);
            f.ShowDialog(this);
            load_chidinh();
        }

        private void ngayrv_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (ngayrv.Text != "")
                {
                    ngayrv.Text = ngayrv.Text.Trim();
                    if (ngayrv.Text.Length == 6) ngayrv.Text = ngayrv.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngayrv.Text))
                    {
                        MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngayrv.Focus();
                        return;
                    }
                }
            }
            catch { }
        }

        private void giorv_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (giorv.Text != "")
                {
                    string sgio = (giorv.Text.Trim() == "") ? "00:00" : giorv.Text.Trim();
                    giorv.Text = sgio.Substring(0, 2).PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
                    if (!m.bGio(giorv.Text))
                    {
                        MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"));
                        giorv.Focus();
                        return;
                    }
                }
            }
            catch { }
        }

        private void phanbiet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list1.Focus(); 
            //			else 
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //				if (list1.Visible) list1.Focus();
                //				else 
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void phanbiet_TextChanged(object sender, System.EventArgs e)
        {
            //			if (this.ActiveControl==phanbiet)
            //			{
            //				Filter(phanbiet.Text,200);
            //				list1.BrowseToThon(phanbiet,phanbiet,tienluong);
            //			}		
        }

        private void Filter(string ten, int loai)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%' and loai=" + loai;
            }
            catch { }
        }

        private void butKemtheo_Click(object sender, System.EventArgs e)
        {
            if (icd_kemtheo.Text == "" || cd_kemtheo.Text == "")
            {
                icd_kemtheo.Focus();
                return;
            }
            if (cd_kemtheo.Text != "") m.upd_cdkemtheo(l_idkhoa, l_maql, 2, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            frmCdkemtheo f = new frmCdkemtheo(m, l_idkhoa, l_maql, 2, "");
            f.ShowDialog();
        }

        private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) list.Focus();
        }

        private void butIn_Click(object sender, System.EventArgs e)
        {
            if (mabn.Text == "") return;
            if (chonin.CheckedItems.Count == 0)
                for (int i = 0; i < chonin.Items.Count; i++) chonin.SetItemCheckState(i, CheckState.Checked);
            for (int i = 0; i < chonin.Items.Count; i++)
                if (chonin.GetItemChecked(i)) page(i);
        }
        #region Page
        private void page(int loai)
        {
            DataSet dsxml = new DataSet();
            if (chkXML.Checked)
                if (!Directory.Exists("..\\xml")) Directory.CreateDirectory("..\\xml");
            if (chonin.GetItemChecked(1) || chonin.GetItemChecked(2) || chonin.GetItemChecked(3))
            {
                dsxml = get_data();
                if (chkXML.Checked) dsxml.WriteXml("..\\xml\\page234.xml", XmlWriteMode.WriteSchema);
            }
            switch (loai)
            {
                case 0: page_1(); break;
                case 1: page_2(dsxml); break;
                case 2: page_3(dsxml); break;
                case 3: page_4(dsxml); break;
            }
        }
        private void page_1()
        {
            string tenfile = "BenhAnNgoaiKhoa", m_manuoc = "", m_tennuoc = "", stuoi = m.get_tuoivao(l_maql).Trim(), m_songaydt = "", m_cd_noichuyenden = "", m_icd_noichuyenden = "", m_tdvh = "", m_ngaybong = "";
            string m_songaydieutrivaokhoa = "", m_chuyenkhoa1 = "", m_ngaychuyenkhoa1 = "", m_songaydieutrichuyenkhoa1 = "", m_chuyenkhoa2 = "", m_ngaychuyenkhoa2 = "", m_songaydieutrichuyenkhoa2 = "";
            string m_chuyenkhoa3 = "", m_ngaychuyenkhoa3 = "", m_songaydieutrichuyenkhoa3 = "", m_ngaytuvong = "", m_tinhtrangtuvong = "", m_thoidiemtuvong = "", m_nguyennhantuvong = "", m_icdnguyennhantuvong = "";
            string m_cokhamnghiemtuthi = "", m_chandoantuthi = "", m_icdchandoantuthi = "", m_nguyennhantaibienbienchung = "", m_tongsongaydieutrisauphauthuat = "", m_tongsolanphauthuat = "", m_chandoantruocphauthuat = "";
            string m_icdchandoantruocphauthuat = "", m_chandoansauphauthuat = "", m_icdchandoansauphauthuat = "", m_tinhtrangphauthuat = "", m_ngoithai = "", m_phuongphapphauthuat = "", m_loaithai = "", m_gioitinhtre = "", m_treconsong = "", m_trecoditat = "", m_trecannang = "";
            string nhi_hoten_bo = "", nhi_vanhoa_bo = "", nhi_tennn_bo = "", nhi_hoten_me = "", nhi_vanhoa_me = "", nhi_tennn_me = "";
            string mame = "", ss_hoten_me = "", ss_ns_me = "", ss_tennn_me = "", ss_delan = "", ss_hoten_bo = "", ss_ns_bo = "", ss_tennn_bo = "", ss_nhommau = "", para = "", ss_para1 = "", ss_para2 = "", ss_para3 = "", ss_para4 = "";
            string m_ngayde = "", m_cachthucde = "", m_kiemsoat = "", t_v = "", n_v = "", m_v = "", giaidoan_v = "", t_r = "", n_r = "", m_r = "", giaidoan_r = "", ss_mann_bo = "", ss_mann_me = "", nhi_mann_bo = "", nhi_mann_me = "";
            sql = "select a.makp,b.soluutru,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql += "to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh,c.phai,c.sonha,c.thon,c.matt,c.maqu,c.maphuongxa,c.mann,d.tennn,c.madantoc,e.dantoc as tendantoc,";
            sql += "f.tentt,g.tenquan,h.tenpxa,c.cholam,a.madoituong,i.sothe,to_char(i.denngay,'dd/mm/yyyy') as denngay,";
            sql += "j.hoten as qh_hoten,j.dienthoai as qh_dienthoai,a.lanthu,a.nhantu,a.dentu,";
            sql += "coalesce(m.loaibv,0) as loaibv,n.tenbv,coalesce(b.ttlucrv,0) as ttlucrv,a.chandoan as chandoanvv,a.maicd as maicdvv,";
            sql += "b.chandoan as chandoanrv,b.maicd as maicdrv,b.taibien,b.bienchung,b.giaiphau,coalesce(b.ketqua,0) as ketqua,";
            sql += "coalesce(s.ten,b.giaiphau) as giaiphau,t.chandoan as chandoannn,t.maicd as maicdnn, i.traituyen ";
            sql += " from " + user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql";
            sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn inner join " + user + ".btdnn_bv d on c.mann=d.mann";
            sql += " inner join " + user + ".btddt e on c.madantoc=e.madantoc inner join " + user + ".btdtt f on c.matt=f.matt";
            sql += " inner join " + user + ".btdquan g on c.maqu=g.maqu inner join " + user + ".btdpxa h on c.maphuongxa=h.maphuongxa";
            sql += " left join " + user + ".bhyt i on a.maql=i.maql left join " + user + ".quanhe j on a.maql=j.maql";
            sql += " left join " + user + ".chuyenvien m on a.maql=m.maql left join " + user + ".tenvien n on m.mabv=n.mabv";
            sql += " left join " + user + ".gphaubenh s b.giaiphau=s.ma left join " + user + ".cdnguyennhan t on b.maql=t.maql";
            sql += " where a.loaiba=1 and a.maql=" + l_maql;
            DataSet ds1 = m.get_data(sql);
            DataRow r2 = m.getrowbyid(dtba, "MAVT='" + tenba.SelectedValue.ToString() + "'");
            if (r2 != null) tenfile = r2["tenfile"].ToString();
            if (ds1.Tables[0].Rows.Count == 0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                if (chkXML.Checked) ds1.WriteXml("..\\xml\\page1.xml", XmlWriteMode.WriteSchema);
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    if (r["ngayrv"].ToString() != "") m_songaydt = m.songay(m.StringToDate(r["ngayrv"].ToString()), m.StringToDate(r["ngayvv"].ToString()), 1).ToString();
                    if (m.get_data("select * from " + user + ".chuyenkhoa where maql=" + l_maql).Tables[0].Rows.Count != 0)
                    {
                        DataTable dtck = new DataTable();
                        dtck = m.get_data("select khoaden,to_char(ngaychuyen,'dd/mm/yyyy hh24:mi') as ngaychuyen from " + user + ".chuyenkhoa where maql=" + l_maql + " order by ngaychuyen").Tables[0];
                        m_chuyenkhoa1 = dtck.Rows[0]["khoaden"].ToString();
                        m_ngaychuyenkhoa1 = dtck.Rows[0]["ngaychuyen"].ToString();
                        m_songaydieutrivaokhoa = m.songay(m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();
                        if (dtck.Rows.Count > 1)
                        {
                            m_chuyenkhoa2 = dtck.Rows[1]["khoaden"].ToString();
                            m_ngaychuyenkhoa2 = dtck.Rows[1]["ngaychuyen"].ToString();
                            m_songaydieutrichuyenkhoa1 = m.songay(m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), 0).ToString();
                        }
                        else if (m_ngaychuyenkhoa1 != "" && r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa1 = m.songay(m.StringToDate(r["ngayrv"].ToString()), m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), 0).ToString();
                        if (dtck.Rows.Count > 2)
                        {
                            m_chuyenkhoa3 = dtck.Rows[2]["khoaden"].ToString();
                            m_ngaychuyenkhoa3 = dtck.Rows[2]["ngaychuyen"].ToString();
                            m_songaydieutrichuyenkhoa2 = m.songay(m.StringToDate(m_ngaychuyenkhoa3.Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), 0).ToString();
                            if (r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa3 = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa3.Substring(0, 10)), 0).ToString();
                        }
                        else if (m_ngaychuyenkhoa2 != "" && r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa2 = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), 0).ToString();
                    }
                    else if (r["ngayrv"].ToString() != "") m_songaydieutrivaokhoa = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();

                    if (tenba.SelectedValue.ToString() == "BSA")
                    {
                        if (m.get_data("select * from " + user + ".tresosinh where maql=" + l_maql).Tables[0].Rows.Count != 0)
                        {
                            DataTable dtss = new DataTable();
                            dtss = m.get_data("select ngoithai,phai,decode(tinhtrang,0,1,0) as tinhtrang,ditat,cannang from " + user + ".tresosinh where maql=" + l_maql + " order by ngay").Tables[0];
                            m_loaithai = dtss.Rows.Count.ToString();
                            m_ngoithai = dtss.Rows[0]["ngoithai"].ToString();
                            m_gioitinhtre = dtss.Rows[0]["phai"].ToString();
                            m_treconsong = dtss.Rows[0]["tinhtrang"].ToString();
                            m_trecoditat = dtss.Rows[0]["ditat"].ToString();
                            m_trecannang = dtss.Rows[0]["cannang"].ToString();
                        }
                    }
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count != 0)
                    {
                        m_ngaytuvong = r["ngayrv"].ToString();
                        DataTable dttv = new DataTable();
                        dttv = m.get_data("select chandoan,maicd,nguyennhan,benhly,khamtuthi from " + user + ".tuvong where maql=" + l_maql).Tables[0];
                        m_tinhtrangtuvong = dttv.Rows[0]["nguyennhan"].ToString();
                        m_cokhamnghiemtuthi = dttv.Rows[0]["khamtuthi"].ToString();
                        if (m_cokhamnghiemtuthi == "1")
                        {
                            m_chandoantuthi = dttv.Rows[0]["chandoan"].ToString();
                            m_icdchandoantuthi = m.Maicd_rpt(dttv.Rows[0]["maicd"].ToString());
                        }
                        m_nguyennhantuvong = r["chandoanrv"].ToString();
                        m_icdnguyennhantuvong = m.Maicd_rpt(r["maicdrv"].ToString());
                    }
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
                    {
                        m_cd_noichuyenden = r1["chandoan"].ToString();
                        m_icd_noichuyenden = r1["maicd"].ToString();
                    }

                    if (r["madantoc"].ToString() == "55")
                    {
                        foreach (DataRow r1 in m.get_data("select a.ma,a.ten from " + user + ".dmquocgia a," + user + ".nuocngoai b where a.ma=b.id_nuoc and b.mabn='" + mabn.Text + "'").Tables[0].Rows)
                        {
                            m_manuoc = r1["ma"].ToString();
                            m_tennuoc = r1["ten"].ToString();
                            break;
                        }
                    }
                    if (tenba.SelectedValue.ToString() == "BBO")
                    {
                        foreach (DataRow r1 in m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".ttbong where maql=" + l_maql).Tables[0].Rows)
                        {
                            m_ngaybong = r1["ngay"].ToString();
                            break;
                        }
                    }
                    else if (tenba.SelectedValue.ToString() == "BTH")
                    {
                        foreach (DataRow r1 in m.get_data("select vanhoa from " + user + ".tttamthan where maql=" + l_maql).Tables[0].Rows)
                        {
                            m_tdvh = r1["vanhoa"].ToString();
                            break;
                        }
                    }
                    else if ((tenba.SelectedValue.ToString() == "BNH" || tenba.SelectedValue.ToString() == "BMT"))
                    {
                        foreach (DataRow r1 in m.get_data("select a.*,b.tennn as bo,c.tennn as me from " + user + ".hcnhi a left join " + user + ".btdnn_bv b on a.mann_bo=b.mann left join " + user + ".btdnn_bv c on a.mann_me=c.mann where a.mabn='" + mabn.Text + "'").Tables[0].Rows) 
                        {
                            nhi_hoten_bo = r1["hoten_bo"].ToString();
                            nhi_vanhoa_bo = r1["vanhoa_bo"].ToString();
                            nhi_tennn_bo = r1["bo"].ToString();
                            nhi_hoten_me = r1["hoten_me"].ToString();
                            nhi_vanhoa_me = r1["vanhoa_me"].ToString();
                            nhi_tennn_me = r1["me"].ToString();
                            nhi_mann_bo = r1["mann_bo"].ToString();
                            nhi_mann_me = r1["mann_me"].ToString();
                        }
                    }
                    else if (tenba.SelectedValue.ToString() == "BSO")
                    {
                        foreach (DataRow r1 in m.get_data("select a.*,b.tennn as bo,c.tennn as me,d.ten as mau from " + user + ".hcsosinh a left join " + user + ".btdnn_bv b on a.mann_bo=b.mann left join " + user + ".btdnn_bv c on a.mann_me=c.mann inner join " + user + ".dmnhommau d on a.nhommau=d.ma where a.mabn='" + mabn.Text + "'").Tables[0].Rows)
                        {
                            mame = r1["mame"].ToString();
                            ss_mann_bo = r1["mann_bo"].ToString();
                            ss_mann_me = r1["mann_me"].ToString();
                            ss_hoten_me = r1["hoten_me"].ToString();
                            ss_ns_me = r1["ns_me"].ToString();
                            ss_tennn_me = r1["me"].ToString();
                            ss_delan = r1["delan"].ToString();
                            ss_hoten_bo = r1["hoten_bo"].ToString();
                            ss_ns_bo = r1["ns_bo"].ToString();
                            ss_tennn_bo = r1["bo"].ToString();
                            ss_nhommau = r1["mau"].ToString();
                            para = r1["para"].ToString();
                            if (para.Length == 8)
                            {
                                ss_para1 = para.Substring(0, 2);
                                ss_para2 = para.Substring(2, 2);
                                ss_para3 = para.Substring(4, 2);
                                ss_para4 = para.Substring(6, 2);
                            }
                        }
                    }
                    else if (tenba.SelectedValue.ToString() == "BSA")
                    {
                        foreach (DataRow r1 in m.get_data("select a.*,b.ten from " + user + ".cdsankhoa a," + user + ".dmkieusanh b where a.cachthucde=b.ma and a.maql=" + l_maql).Tables[0].Rows)
                        {
                            m_ngayde = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                            m_cachthucde = r1["ten"].ToString();
                            m_kiemsoat = r1["kiemsoat"].ToString();
                        }
                    }
                    else if (tenba.SelectedValue.ToString() == "BUN")
                    {
                        foreach (DataRow r1 in m.get_data("select * from " + user + ".cdungbuou where maql=" + l_maql).Tables[0].Rows)
                        {
                            t_v = r1["t_v"].ToString();
                            n_v = r1["n_v"].ToString();
                            m_v = r1["m_v"].ToString();
                            giaidoan_v = r1["giaidoan_v"].ToString();
                            t_r = r1["t_r"].ToString();
                            n_r = r1["n_r"].ToString();
                            m_r = r1["m_r"].ToString();
                            giaidoan_r = r1["giaidoan_r"].ToString();
                            break;
                        }
                    }
                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, tenfile, tenba.SelectedValue.ToString(), s_tenkp, giuong.Text, r["soluutru"].ToString(), m.Mabv + "/" + mabn.Text.Substring(0, 2) + "/" + mabn.Text.Substring(2), hoten.Text, r["ngaysinh"].ToString(), (stuoi.Substring(3) == "0") ? stuoi.Substring(1, 3) : "000", r["phai"].ToString(),
                    r["tennn"].ToString(), r["mann"].ToString(), r["tendantoc"].ToString(), r["madantoc"].ToString(), m_tennuoc, m_manuoc, r["sonha"].ToString(), r["thon"].ToString(),
                    r["tenpxa"].ToString(), r["tenquan"].ToString(), r["maqu"].ToString(), r["tentt"].ToString(), r["matt"].ToString(), r["cholam"].ToString(), r["madoituong"].ToString(),
                    r["denngay"].ToString(), r["sothe"].ToString(), r["qh_hoten"].ToString(), r["qh_dienthoai"].ToString(), m_ngaybong, r["ngayvv"].ToString(),
                    r["nhantu"].ToString(), r["dentu"].ToString(), r["lanthu"].ToString(), r["makp"].ToString(), ngayvk.Text + " " + giovk.Text,
                    m_songaydieutrivaokhoa, m_chuyenkhoa1, m_ngaychuyenkhoa1, m_songaydieutrichuyenkhoa1, m_chuyenkhoa2, m_ngaychuyenkhoa2, m_songaydieutrichuyenkhoa2, m_chuyenkhoa3, m_ngaychuyenkhoa3, m_songaydieutrichuyenkhoa3,
                    r["loaibv"].ToString(), r["tenbv"].ToString(), r["ngayrv"].ToString(), r["ttlucrv"].ToString(), m_songaydt,
                    m_cd_noichuyenden, m.Maicd_rpt(m_icd_noichuyenden), r["chandoanvv"].ToString(), m.Maicd_rpt(r["maicdvv"].ToString()),
                    cd_kkb.Text, m.Maicd_rpt(icd_kkb.Text), "0", "0", r["chandoanrv"].ToString(),
                    m.Maicd_rpt(r["maicdrv"].ToString()), cd_kemtheo.Text, m.Maicd_rpt(icd_kemtheo.Text),
                    r["taibien"].ToString(), r["bienchung"].ToString(), r["ketqua"].ToString(), r["giaiphau"].ToString(), m_ngaytuvong, m_tinhtrangtuvong, m_thoidiemtuvong,
                    m_nguyennhantuvong, m_icdnguyennhantuvong, m_cokhamnghiemtuthi, m_chandoantuthi, m_icdchandoantuthi, m_nguyennhantaibienbienchung, m_tongsongaydieutrisauphauthuat,
                    m_tongsolanphauthuat, r["chandoannn"].ToString(), m.Maicd_rpt(r["maicdnn"].ToString()), m_chandoantruocphauthuat, m_icdchandoantruocphauthuat, m_chandoansauphauthuat,
                    m_icdchandoansauphauthuat, m_tinhtrangphauthuat, m_tdvh, (tenba.SelectedValue.ToString() == "BSO") ? ss_hoten_bo : nhi_hoten_bo,
                    (tenba.SelectedValue.ToString() == "BSO") ? ss_mann_bo : nhi_mann_bo, nhi_vanhoa_bo, (tenba.SelectedValue.ToString() == "BSO") ? ss_hoten_me : nhi_hoten_me,
                    (tenba.SelectedValue.ToString() == "BSO") ? ss_mann_me : nhi_mann_me, nhi_vanhoa_me, ss_ns_me,
                    ss_mann_me, ss_delan, ss_ns_bo, ss_mann_bo, ss_nhommau, ss_para1 + ss_para2 + ss_para3 + ss_para4,
                    m_ngayde, m_ngoithai, m_cachthucde, m_kiemsoat, "", m_phuongphapphauthuat, m_loaithai, m_gioitinhtre, m_treconsong,
                    m_trecoditat, "", m_trecannang, t_v, n_v, m_v, giaidoan_v, t_r, n_r, m_r, giaidoan_r);
                    f.ShowDialog();
                }
            }
        }

        private void page_2(DataSet ds1)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, "", "rPage22.rpt");
                f.ShowDialog();
            }
        }
        private void page_3(DataSet ds1)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, "", "rPage23.rpt");
                f.ShowDialog();
            }
        }
        private void page_4(DataSet ds1)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, "", "rPage24.rpt");
                f.ShowDialog();
            }
        }

        private DataSet get_data()
        {
            string c01 = "", c02 = "", c03 = "", c04 = "", xn01 = "", xn02 = "", xn03 = "", xn04 = "", xn05 = "";
            foreach (DataRow r in dscd.Tables[0].Rows)
            {
                xn01 += r["ngay"].ToString().Trim() + "\n";
                xn02 += r["tenkp"].ToString().Trim() + "\n";
                xn03 += r["tenbs"].ToString().Trim() + "\n";
                xn04 += r["ten"].ToString().Trim() + "\n";
                xn05 += r["ketqua"].ToString().Trim() + "\n";
            }
            sql = "select a.*,b.mach,b.nhietdo,b.huyetap,b.nhiptho,c.cannang,'' as c01,'' as c02,'' as c03,'' as c04,";
            sql += "'' as xn01,'' as xn02,'' as xn03,'' as xn04,'' as xn05,";
            sql += "'' as chandoan,'' as chandoankem,'' as bacsiba,0 as pt,0 as tt,'' as tennguoigiao,'' as tennguoinhan,'' as bacsi,";
            sql += "'' as ngayba,'' as ngaydt,0 as xq,0 as ct,0 as sa,0 as xn,0 as stkhac,'' as loaikhac,0 as tong,";
            sql += "0 as k01,0 as k02,0 as k03,0 as k04,0 as k05,0 as k06,'' as t01,'' as t02,'' as t03,'' as t04,'' as t05,'' as t06,";
            sql += "c.conthu,c.para,c.tinhtrang,c.ditat,c.tenditat,c.tinhthan,c.vandong,c.benhlykhac,c.nuoiduong,c.caisua,c.vuontre,";
            sql += "c.tainha,c.lao,c.bailiet,c.soi,c.hoga,c.uonvan,c.bachhau,c.tckhac,c.cuthe,c.chieucao,c.vongnguc,c.vongdau ";
            sql += " from " + xxx + ".ba_chung a," + xxx + ".ba_kbdausinhton b," + xxx + ".ba_nhi c where a.id=b.id and a.id=c.id and a.id=" + l_id;
            DataSet ds1 = m.get_data(sql);
            bool bFile = false, bFiledt = false, bF1 = false, bF2 = false;
            if (ds1.Tables[0].Rows.Count != 0)
            {
                DataColumn dc = new DataColumn("Image", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                dc = new DataColumn("Imagedt", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                dc = new DataColumn("pic1", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                dc = new DataColumn("pic2", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                DataRow r1 = m.getrowbyid(dtnv, "ma='" + mabsnb.Text + "'");
                bFile = r1 != null;
                if (bFile)
                {
                    image = new byte[0];
                    try
                    {
                        image = (byte[])(r1["image"]);
                    }
                    catch { }
                }
                if (mabs.Text != "")
                {
                    r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    bFiledt = r1 != null;
                    if (bFiledt)
                    {
                        imagedt = new byte[0];
                        try
                        {
                            imagedt = (byte[])(r1["image"]);
                        }
                        catch { }
                    }
                }

                foreach (DataRow r2 in m.get_data("select * from " + xxx + ".ba_hinh where id=" + l_id + " order by stt").Tables[0].Rows)
                {
                    if (int.Parse(r2["stt"].ToString()) == 1)
                    {
                        bF1 = true;
                        image1 = new byte[0];
                        image1 = (byte[])(r2["image"]);
                    }
                    else
                    {
                        bF2 = true;
                        image2 = new byte[0];
                        image2 = (byte[])(r2["image"]);
                    }
                }
                string s = "";
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    r["hb_banthan"] = hb_banthan.Text;
                    s = "";
                    if (benhnhan.Text != "") s += benhnhan.Text.Trim() + "\n";
                    if (lydovv.Text != "") s += lydovv.Text.Trim() + "\n";
                    if (conang.Text != "") s += conang.Text.Trim() + "\n";
                    if (thucthe.Text != "") s += thucthe.Text.Trim() + "\n";
                    if (clsdaco.Text != "") s += clsdaco.Text.Trim() + "\n";
                    if (kb_tomtat.Text != "") s += kb_tomtat.Text.Trim();
                    r["kb_tomtat"] = s;
                    r["chandoan"] = cd_kkb.Text;
                    r["chandoankem"] = cd_kemtheo.Text;
                    r["xn01"] = xn01; r["xn02"] = xn02;
                    r["xn03"] = xn03; r["xn04"] = xn04; r["xn05"] = xn05;
                    r["c01"] = c01; r["c02"] = c02;
                    r["c03"] = c03; r["c04"] = c04;
                    r["bacsiba"] = tenbsnb.Text;
                    r["bacsi"] = tenbs.Text;
                    r["ngayba"] = ngayvk.Text + " " + giovk.Text;
                    r["ngaydt"] = ngayrv.Text + " " + giorv.Text;
                    r["tennguoigiao"] = nguoigiao.Text;
                    r["tennguoinhan"] = nguoinhan.Text;
                    r["xq"] = st1.Value; r["ct"] = st2.Value;
                    r["sa"] = st3.Value; r["xn"] = st4.Value;
                    r["loaikhac"] = khac.Text; r["stkhac"] = st5.Value;
                    r["tong"] = st6.Value;
                    if (bFile) r["image"] = image;
                    if (bFiledt) r["imagedt"] = imagedt;
                    if (bF1) r["pic1"] = image1;
                    if (bF2) r["pic2"] = image2;
                    r["tenditat"] = tenditat.Text;
                }
            }
            return ds1;
        }
        #endregion

        private void butChuyenphong_Click(object sender, System.EventArgs e)
        {
            frmChuyenphong f1 = new frmChuyenphong(m, ngayvk.Text, s_makp, s_tenkp, i_userid, mabn.Text, l_idkhoa);
            f1.ShowDialog(this);
            int idgiuong = f1.idgiuong;
            if (idgiuong != 0)
            {
                foreach (DataRow r in m.get_data("select a.ma as phong,b.ma as giuong from " + user + ".dmphong a," + user + ".dmgiuong b where a.id=b.idphong and b.id=" + idgiuong).Tables[0].Rows)
                {
                    phong.Text = r["phong"].ToString();
                    giuong.Text = r["giuong"].ToString();
                    break;
                }
                DataRow r1 = m.getrowbyid(ds.Tables[0], "mabn='" + mabn.Text + "'");
                if (r1 != null)
                {
                    r1["phong"] = phong.Text;
                    r1["giuong"] = giuong.Text;
                }
            }
        }

        private void butDieutri_Click(object sender, System.EventArgs e)
        {
            frmTodieutri f = new frmTodieutri(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin, false, 0, null, i_madoituong);
            f.ShowDialog(this);
        }

        private void butChamsoc_Click(object sender, System.EventArgs e)
        {
            frmChamsoc f = new frmChamsoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butPhanung_Click(object sender, System.EventArgs e)
        {
            frmPuthuoc f = new frmPuthuoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butDich_Click(object sender, System.EventArgs e)
        {
            frmTruyendich f = new frmTruyendich(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butMau_Click(object sender, System.EventArgs e)
        {
            frmTruyenmau f = new frmTruyenmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butDausinhton_Click(object sender, System.EventArgs e)
        {
            frmDausinhton f = new frmDausinhton(m, s_makp, mabn.Text);
            f.ShowDialog(this);
        }

        private void frmHSBenhan_BNH_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (butLuu.Enabled) butLuu_Click(sender, e);
                    break;
                case Keys.F8:
                    if (butBoqua.Enabled) butBoqua_Click(sender, e);
                    break;
                case Keys.F9:
                    if (butIn.Enabled) butIn_Click(sender, e);
                    break;
                case Keys.F3:
                    if (list.Enabled) get_mabn(list.SelectedValue.ToString());
                    break;
                case Keys.F6:
                    if (butChon.Enabled) butChon_Click(sender, e);
                    break;
                case Keys.F10:
                    if (butKethuc.Enabled) butKethuc_Click(sender, e);
                    break;
            }
        }

        private void butChon_Click(object sender, System.EventArgs e)
        {
            if ((xem.SelectedIndex == 10 || xem.SelectedIndex == 0) && (l_id == 0))
            {
                if (!kiemtra()) return;
                xxx = user + m.mmyy(ngay.Text);
                bool bNhapkhoa = m.getrowbyid(ds.Tables[0], "nhapkhoa=0 and mabn='" + mabn.Text + "'") != null;
                if (bNhapkhoa) upd_nhapkhoa();
                m.execute_data("update benhandt set mabs='" + mabsnb.Text + "' where maql=" + l_maql);
                l_idthuchien = m.get_idthuchien(ngay.Text, l_idkhoa);
                if (l_idthuchien == 0)
                {
                    l_idthuchien = m.get_capid(-300);
                    m.upd_ba_thuchien(ngay.Text, l_idthuchien, mabn.Text, l_maql, l_idkhoa, s_makp, phong.Text, giuong.Text, chandoan.Text);
                }
                l_id = m.get_idchung(ngay.Text, l_idthuchien);
                if (l_id == 0) l_id = m.get_capid(-301);
                m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, lanthu.Value, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", kb_tuanhoan.Text,
                    kb_hohap.Text, kb_tieuhoa.Text, kb_than.Text, kb_thankinh.Text, kb_co.Text, "", "", "", kb_noitiet.Text, "", kb_tomtat.Text, phanbiet.Text,
                    tienluong.Text, dieutri.Text, mabsnb.Text, tk_benhly.Text, tk_tomtat.Text, tk_phuongphap.Text, tk_tinhtrang.Text, tk_dieutri.Text, manguoigiao.Text, manguoinhan.Text, mabs.Text, i_userid);
            }
            if (xem.SelectedIndex == 8 && i_loai == 1) return;
            switch (xem.SelectedIndex)
            {
                case 0: frmHoichancc f0 = new frmHoichancc(m, ds, 0, l_idthuchien, mabn.Text, s_makp, s_tenkp, i_userid, bAdmin, ngay.Text);
                    f0.ShowDialog(this);
                    break;
                case 1: frmKiemsoatcc f1 = new frmKiemsoatcc(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f1.ShowDialog(this);
                    break;
                case 2: frmHoichan f2 = new frmHoichan(m, ds, 0, l_idthuchien, mabn.Text, s_makp, s_tenkp, i_userid, bAdmin, ngay.Text);
                    f2.ShowDialog(this);
                    break;
                case 3: frmKiemsoat f3 = new frmKiemsoat(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f3.ShowDialog(this);
                    break;
                case 4: frmHcthuoc f4 = new frmHcthuoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f4.ShowDialog(this);
                    break;
                case 5: frmDanhgia f5 = new frmDanhgia(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f5.ShowDialog(this);
                    break;
                case 6: frmCamdoan f6 = new frmCamdoan(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f6.ShowDialog(this);
                    break;
                case 7: frmLinhmau f7 = new frmLinhmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f7.ShowDialog(this);
                    break;
                case 8: frmGiaonhan f8 = new frmGiaonhan(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, l_id, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f8.ShowDialog(this);
                    break;
                case 9: frmSoket f9 = new frmSoket(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f9.ShowDialog(this);
                    break;
                case 10: frmBascan f10 = new frmBascan(m, 0, mabn.Text, l_maql, l_idkhoa, l_id, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, phong.Text, giuong.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f10.ShowDialog(this);
                    break;
                case 11: frmXemthuoc f11 = new frmXemthuoc(m, l_maql, hoten.Text, ngay.Text, ngayrv.Text);
                    f11.ShowDialog(this);
                    break;
                case 12: frmCongkhaiMabn f12 = new frmCongkhaiMabn(mabn.Text);
                    f12.ShowDialog(this);
                    break;
                case 13: frmCongnoMabn f13 = new frmCongnoMabn(m, mabn.Text, l_maql, ngay.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10));
                    f13.ShowDialog(this);
                    break;
                case 14: if (rb1.Checked)
                    {
                        frmXuatkhoa f14 = new frmXuatkhoa(m, s_makp, s_userid, i_userid, 0, b_sovaovien, b_soluutru, "", mabn.Text, tenba.SelectedValue.ToString());
                        f14.ShowDialog(this);
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
            if (this.ActiveControl == rb1) load_list();
        }

        private void rb2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == rb2) load_list();
        }

        private void mabsnb_Validated(object sender, System.EventArgs e)
        {
            if (mabsnb.Text == "") return;
            DataRow r = m.getrowbyid(dtnv, "ma='" + mabsnb.Text + "'");
            if (r != null) tenbsnb.Text = r["hoten"].ToString();
            else tenbsnb.Text = "";
        }

        private void tenbsnb_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenbsnb)
            {
                Filt_dmbs1(tenbsnb.Text);
                listNv1.BrowseToDanhmuc(tenbsnb, mabsnb, tenbsnb_pass, 35);
            }
        }

        private void pic1_DoubleClick(object sender, System.EventArgs e)
        {
            if (butLuu.Enabled && bHinh) edit_pic(pic1, 1);
        }

        private void edit_pic(PictureBox pic, int i)
        {
            bHinh = true;
            string sDir = System.Environment.CurrentDirectory.ToString(), tenfile = "..\\pict_ba\\" + pic.Name.ToString() + ".bmp";
            if (File.Exists((i == 1) ? f1 : f2))
            {
                frmPaint f = new frmPaint((i == 1) ? f1 : f2);
                f.ShowDialog(this);
                f.Save_image(tenfile);
                fstr = new System.IO.FileStream(tenfile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                pic.Tag = image;
                map = new Bitmap(Image.FromStream(fstr));
                pic.Image = (Bitmap)map;
                pic.Update();
                fstr.Close();
                get_file(i);
                File.Copy(tenfile, (i == 1) ? f1 : f2, true);
            }
            System.Environment.CurrentDirectory = sDir;
        }

        private void pic2_DoubleClick(object sender, System.EventArgs e)
        {
            if (butLuu.Enabled && bHinh) edit_pic(pic2, 2);
        }

        private void get_file(int i)
        {
            if (i == 0)
            {
                f1 = thumucpic + "\\1" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + ".bmp";
                f2 = thumucpic + "\\2" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + ".bmp";
            }
            else if (i == 1) f1 = thumucpic + "\\1" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + ".bmp";
            else f2 = thumucpic + "\\2" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + ".bmp";
        }

        private void butPhong_Click(object sender, System.EventArgs e)
        {
            if (m.get_data("select * from " + user + ".theodoigiuong where mabn='" + mabn.Text + "' and makp='" + s_makp + "' and den is null").Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Đã chọn phòng/giường")+"\n"+
lan.Change_language_MessageText("Nếu muốn chuyển phòng/giường thì chọn phần chuyển phòng giường !"), LibMedi.AccessData.Msg);
                return;
            }
            frmDsgiuong f = new frmDsgiuong(m, s_makp, i_madoituong, false);
            f.ShowDialog();
            if (f.ma != "") giuong.Text = f.ma;
            butLuu.Focus();
        }

        private void ngayvk_Validated(object sender, System.EventArgs e)
        {
            ngayvk.Text = ngayvk.Text.Trim();
            if (ngayvk.Text.Length == 6) ngayvk.Text = ngayvk.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(ngayvk.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayvk.Focus();
                return;
            }
        }

        private void giovk_Validated(object sender, System.EventArgs e)
        {
            string sgio = (giovk.Text.Trim() == "") ? "00:00" : giovk.Text.Trim();
            giovk.Text = sgio.Substring(0, 2).PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovk.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giovk.Focus();
                return;
            }
        }

        private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) butLuu.Focus();
        }

        private void chkHinh_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == chkHinh)
            {
                bHinh = chkHinh.Checked;
                if (bHinh)
                {
                    sql = "select * from " + user + ".ba_hinh where id=" + int.Parse(dtba.Rows[tenba.SelectedIndex]["maba"].ToString()) + " order by stt";
                    dthinh = m.get_data(sql).Tables[0];
                    stt1.DataSource = m.get_data(sql).Tables[0];
                    stt2.DataSource = m.get_data(sql).Tables[0];
                    stt1.Enabled = bHinh;
                    stt2.Enabled = bHinh;
                    foreach (DataRow r in dthinh.Rows)
                    {
                        image = new byte[0];
                        image = (byte[])(r["image"]);
                        memo = new MemoryStream(image);
                        map = new Bitmap(Image.FromStream(memo));
                        picture((int.Parse(r["stt"].ToString()) == 1) ? pic1 : pic2, (int.Parse(r["stt"].ToString()) == 1) ? f1 : f2);
                    }
                }
                else emp_hinh();
            }
        }

        private void stt1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == stt1 && stt1.SelectedIndex != -1)
            {
                image = new byte[0];
                image = (byte[])(dthinh.Rows[stt1.SelectedIndex]["image"]);
                memo = new MemoryStream(image);
                map = new Bitmap(Image.FromStream(memo));
                picture(pic1, f1);
            }
        }

        private void stt2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == stt2 && stt2.SelectedIndex != -1)
            {
                image = new byte[0];
                image = (byte[])(dthinh.Rows[stt2.SelectedIndex]["image"]);
                memo = new MemoryStream(image);
                map = new Bitmap(Image.FromStream(memo));
                picture(pic2, f2);
            }
        }

        private void tenbsnb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listNv1.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listNv1.Visible) listNv1.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void tenbsnb_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) butLuu.Focus();
        }

        private void maditat_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenditat.SelectedValue = maditat.Text;
            }
            catch { }
        }

        private void tenditat_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenditat) maditat.Text = tenditat.SelectedValue.ToString();
        }

        private void tenditat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tenditat.SelectedIndex == -1 && tenditat.Items.Count > 0) tenditat.SelectedIndex = 0;
                maditat.Text = tenditat.SelectedValue.ToString();
                SendKeys.Send("{Tab}");
            }
        }

        private void ditat_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == ditat)
            {
                maditat.Enabled = ditat.Checked;
                tenditat.Enabled = ditat.Checked;
            }
        }

        private void tckhac_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tckhac) cuthe.Enabled = tckhac.Checked;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
