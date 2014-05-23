using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibVienphi;
//using Medisoft.CyberRef;

namespace Medisoft
{
    public class frmPhongluu : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibMedi.AccessData m;
        private LibVienphi.AccessData v;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private DataSet ds = new DataSet(); 
        private bool bBHYT_QRCode_Dangky = false;//B24
        private bool bSothe_dmbhyt = false;
        private string s_QRcode_sothe = "", s_QRcode_Hoten = "", s_QRcode_ngaysinh = "", s_QRcode_gioitinh = "", s_QRcode_diachi = "", s_QRcode_mabv = "", s_QRcode_tungay = "", s_QRcode_denngay = "", s_QRcode_ngaycap = "", s_QRcode_MaQLBHXH = "", s_QRcode_KiemTraBHXH = "";
        private FingerApp.FrmNhanDang fnhandang;//thang
        private string user, nam, s_userid, s_mabn, s_msg, s_ngayvv, sql, s_ngayrk, s_makp, s_icd_kkb, s_nhomkho, d_mmyy = "", pathImage, FileType, u00 = "U00", s_madoituong, ngay1, ngay2, ngay3, ngay_reset_phieu38 = "";
        private string ma_vantay, s_nhomhaophi;//thang
        private string s_matinh_bhyt = "", s_vitri_matinh_bhyt = "";
        private int i_userid, i_mabv, i_maba, i_bangoaitru, iChidinh, i_sokham, itable, iHaophi, iTraituyen, iCapso = 0, i_khudt = 0;
        private decimal l_maql = 0, l_matd = 0, d_id, lTraituyen,l_idcdnguyennhan=0;
        private DataTable dtba = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtxutri = new DataTable();
        private DataSet dsxmlin = new DataSet();
        private DataTable dtbd = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtg = new DataTable();
        private DataTable dtkp = new DataTable();
        private DataTable dtgia = new DataTable();
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
        private int songay = 30, iTreem6, iTreem15, iKhamnhi, madoituong_giuongdichvu;
        private bool b_Edit = false, b_Hoten = false, bAdmin, b_soluutru, bLuutru_Mabn, b_sovaovien, bXutri_noitru, bXutri_ngoaitru, bKhamthai, bTiepdon, bChuyenkhoasan, bDanhmuc_nhathuoc, bDenngay_sothe, bChandoan, bChandoan_kemtheo, bCapso, bSothe_mabn, bSovaovien, bInravien_ravien, bNew, bInthanhtoanchitiet, bCapcuu_noitru, bInchitiet, bChuky, bDichvu_vpkb, bCongkham, bPhonggiuong, bNgayra_ngayvao_1, bDuyet_khambenh, bTungay, bSothe_ngay_huong, bTraituyen, bchidinh_chonngay;
        private bool bVantay, bVantay_mabntudong, bThuphi_kham, bDanhsach, bPhongluu_chuyenkham_kcong, bPhongluu_bhyt_khambenh, bChuathanhtoan_khongcho_nhanbenh = false, bMabn_tudong_tu_ServerInterNet_D24 = false, bMabn_tudong = false, bThongtinNguoithan = false, bBNPhongluu_nhapnguoithan = false, bThongBaoSoVaoVien = false, bnKhamBHYTmotlantrongngay = false;
        private decimal Congkham;
        private System.Windows.Forms.CheckBox giaiphau;
        private System.ComponentModel.IContainer components;
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
        private MaskedTextBox.MaskedTextBox sovaovien;
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
        private string s_icd_noichuyenden, s_icd_chinh, s_icd_kemtheo, s_mabv, s_chonxutri = "", s_icd_nguyennhan = "";
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
        private MaskedBox.MaskedBox ngayrv;
        private System.Windows.Forms.TextBox songaydt;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ComboBox tenketqua;
        private MaskedTextBox.MaskedTextBox giuong;
        private System.Windows.Forms.TextBox ketqua;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lgiuong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cd_kkb;
        private MaskedTextBox.MaskedTextBox icd_kkb;
        private System.Windows.Forms.Label label34;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butIncv;
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
        private ToolStripLabel tlbl;
        private TextBox lydo;
        private Label llydo;
        private MaskedBox.MaskedBox giovv;
        private Label label13;
        private MaskedBox.MaskedBox giorv;
        private Label label14;
        private ToolStripSeparator stripvt;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private Label label16;
        private TextBox noidk;
        private MaskedTextBox.MaskedTextBox manoidk;
        private LibList.List list;
        private Button butInchitiet;
        private DataTable dticd = new DataTable();
        private dllReportM.Print print = new dllReportM.Print();
        private dichso.numbertotext doiso = new dichso.numbertotext();
        private FileStream fstr;
        private Button butPhong;
        private Button button1;
        private Button button3;
        private Button button2;
        private Label label17;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private Panel dausinhton;
        private Label label41;
        private MaskedBox.MaskedBox nhietdo;
        private Label label32;
        private MaskedTextBox.MaskedTextBox huyetap;
        private Label label37;
        private MaskedTextBox.MaskedTextBox mach;
        private Label label38;
        private Label label43;
        private Label label44;
        private Label lblvt;
        private PictureBox ptb;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton tbutvantay;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton12;
        private MaskedBox.MaskedBox tungay;
        private CheckBox chkXML;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton toolStripButton13;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton toolStripButton14;
        private TextBox trieuchung;
        private Label label45;
        private MaskedTextBox.MaskedTextBox maxutri;
        private TextBox tenbsnb;
        private TextBox mabsnb;
        private System.Drawing.Bitmap map;
        private int _dai = 18, _vitri = 14, i_maxlength_mabn = 8, i_chinhanh = 0;
        private string _sothe = "08001", s_soluutru = "";
        private bool bSothe_dkkcb;
        private bool bHaophi, bHaophi_doituongvao;
        private Button butget_msbn_from_internet;
        private ComboBox traituyen;
        private ToolStripButton tButBaolucgiadinh;
        private Button butDateBHYT;
        private string s_tungay1 = "", s_tungay2 = "", s_tungay3 = "";//gam 07/09/2011
        private Label label50;
        private ToolStripDropDownButton chkToathuoc111111111;
        private ToolStripMenuItem chkToathuoc;
        private ToolStripMenuItem chkXem;
        private ToolStripMenuItem chkIn;
        private TextBox cd_nguyennhan;
        private MaskedTextBox.MaskedTextBox icd_nguyennhan;
        private Label label54;
        //TU:31/03/2011
        public bool bUpdate = false, bQuanly_Theo_Chinhanh = false;
        #endregion
        public TextBox mathe;
        public CheckBox chkBhyt;
        private Button button4;
        private ToolStripButton tbutchuphinh;

        public frmPhongluu(LibMedi.AccessData acc, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _nhomkho, string _madoituong, int _khudt, int _chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111); s_madoituong = _madoituong;
            s_userid = hoten; i_userid = userid; i_mabv = mabv; s_nhomkho = _nhomkho; b_soluutru = soluutru;
            i_khudt = _khudt; i_chinhanh = _chinhanh;

            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});

        }
        public frmPhongluu(LibMedi.AccessData acc, string _s_mabn, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _nhomkho, string _madoituong, int _khudt, int _chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111); s_madoituong = _madoituong;
            s_userid = hoten; i_userid = userid; i_mabv = mabv; s_nhomkho = _nhomkho; b_soluutru = soluutru;
            i_khudt = _khudt; s_mabn = _s_mabn; i_chinhanh = _chinhanh;

            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});
            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});

        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongluu));
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
            this.tqx = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
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
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.lphai = new System.Windows.Forms.Label();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.butDateBHYT = new System.Windows.Forms.Button();
            this.manoidk = new MaskedTextBox.MaskedTextBox();
            this.noidk = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.tenbsnb = new System.Windows.Forms.TextBox();
            this.mabsnb = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.trieuchung = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.lblvt = new System.Windows.Forms.Label();
            this.tungay = new MaskedBox.MaskedBox();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.dausinhton = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.label32 = new System.Windows.Forms.Label();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.khamthai = new System.Windows.Forms.Panel();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.icd_noichuyenden = new MaskedTextBox.MaskedTextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.pmat = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dentu = new System.Windows.Forms.TextBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.label16 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.llydo = new System.Windows.Forms.Label();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
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
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.list = new LibList.List();
            this.listdstt = new LibList.List();
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
            this.ngayrv = new MaskedBox.MaskedBox();
            this.songaydt = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.tenketqua = new System.Windows.Forms.ComboBox();
            this.giuong = new MaskedTextBox.MaskedTextBox();
            this.ketqua = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.lgiuong = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutvantay = new System.Windows.Forms.ToolStripButton();
            this.stripvt = new System.Windows.Forms.ToolStripSeparator();
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
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.tButBaolucgiadinh = new System.Windows.Forms.ToolStripButton();
            this.chkToathuoc111111111 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkToathuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tbutchuphinh = new System.Windows.Forms.ToolStripButton();
            this.giorv = new MaskedBox.MaskedBox();
            this.label14 = new System.Windows.Forms.Label();
            this.butPhong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.maxutri = new MaskedTextBox.MaskedTextBox();
            this.butget_msbn_from_internet = new System.Windows.Forms.Button();
            this.butInchitiet = new System.Windows.Forms.Button();
            this.butIncv = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.cd_nguyennhan = new System.Windows.Forms.TextBox();
            this.icd_nguyennhan = new MaskedTextBox.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.mathe = new System.Windows.Forms.TextBox();
            this.chkBhyt = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.phanhchinh.SuspendLayout();
            this.pvaovien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.dausinhton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.khamthai.SuspendLayout();
            this.pmat.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Enabled = false;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(59, 43);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(85, 21);
            this.tenba.TabIndex = 0;
            this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(140, 42);
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
            this.label4.Location = new System.Drawing.Point(262, 42);
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
            this.label5.Location = new System.Drawing.Point(466, 41);
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
            this.mabn1.Location = new System.Drawing.Point(160, 4);
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
            this.mabn2.Location = new System.Drawing.Point(186, 43);
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
            this.mabn3.Location = new System.Drawing.Point(209, 43);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 8;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(59, 21);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(581, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(642, 42);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(33, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(666, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "y.o",
            "m.o",
            "d.o.",
            "h.o."});
            this.loaituoi.Location = new System.Drawing.Point(728, 42);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(270, 21);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(128, 4);
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
            this.tuoi.Location = new System.Drawing.Point(704, 42);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(23, 21);
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
            this.hoten.Location = new System.Drawing.Point(323, 43);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(148, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(540, 283);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 23);
            this.label40.TabIndex = 23;
            this.label40.Text = "Xử trí :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(436, 194);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(71, 23);
            this.label42.TabIndex = 97;
            this.label42.Text = "Bệnh chính :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(504, 196);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(47, 21);
            this.icd_chinh.TabIndex = 16;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(504, 218);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(47, 21);
            this.icd_kemtheo.TabIndex = 18;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label46.Location = new System.Drawing.Point(445, 216);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(62, 23);
            this.label46.TabIndex = 105;
            this.label46.Text = "Bệnh kèm :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenloaibv
            // 
            this.tenloaibv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenloaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenloaibv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenloaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloaibv.Location = new System.Drawing.Point(561, 395);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(436, 21);
            this.tenloaibv.TabIndex = 26;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(504, 395);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(55, 21);
            this.loaibv.TabIndex = 25;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label47.Location = new System.Drawing.Point(435, 397);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(72, 21);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label48.Location = new System.Drawing.Point(436, 418);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 23);
            this.label48.TabIndex = 112;
            this.label48.Text = "Chuyển đến :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv
            // 
            this.mabv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(504, 417);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(55, 21);
            this.mabv.TabIndex = 27;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(561, 417);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(436, 21);
            this.tenbv.TabIndex = 28;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(504, 262);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(47, 21);
            this.mabs.TabIndex = 22;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label49.Location = new System.Drawing.Point(442, 262);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(65, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "BS điều trị :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taibien.BackColor = System.Drawing.SystemColors.Control;
            this.taibien.ForeColor = System.Drawing.SystemColors.Desktop;
            this.taibien.Location = new System.Drawing.Point(643, 476);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(146, 20);
            this.taibien.TabIndex = 126;
            this.taibien.Text = "Tai biến nội khoa";
            this.taibien.UseVisualStyleBackColor = false;
            this.taibien.Visible = false;
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bienchung.BackColor = System.Drawing.SystemColors.Control;
            this.bienchung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bienchung.Location = new System.Drawing.Point(694, 482);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(91, 18);
            this.bienchung.TabIndex = 127;
            this.bienchung.Text = "Biến chứng";
            this.bienchung.UseVisualStyleBackColor = false;
            this.bienchung.Visible = false;
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(5, 24);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(994, 17);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giaiphau
            // 
            this.giaiphau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaiphau.BackColor = System.Drawing.SystemColors.Control;
            this.giaiphau.ForeColor = System.Drawing.SystemColors.Desktop;
            this.giaiphau.Location = new System.Drawing.Point(681, 480);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(104, 20);
            this.giaiphau.TabIndex = 128;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.UseVisualStyleBackColor = false;
            this.giaiphau.Visible = false;
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // phanhchinh
            // 
            this.phanhchinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phanhchinh.BackColor = System.Drawing.SystemColors.Control;
            this.phanhchinh.Controls.Add(this.tqx);
            this.phanhchinh.Controls.Add(this.phai);
            this.phanhchinh.Controls.Add(this.tendantoc);
            this.phanhchinh.Controls.Add(this.tentqx);
            this.phanhchinh.Controls.Add(this.cholam);
            this.phanhchinh.Controls.Add(this.thon);
            this.phanhchinh.Controls.Add(this.mapxa2);
            this.phanhchinh.Controls.Add(this.maqu2);
            this.phanhchinh.Controls.Add(this.matt);
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
            this.phanhchinh.Controls.Add(this.tennuoc);
            this.phanhchinh.Controls.Add(this.manuoc);
            this.phanhchinh.Controls.Add(this.lmanuoc);
            this.phanhchinh.Controls.Add(this.sonha);
            this.phanhchinh.Controls.Add(this.madantoc);
            this.phanhchinh.Controls.Add(this.mann);
            this.phanhchinh.Controls.Add(this.tennn);
            this.phanhchinh.Controls.Add(this.lsonha);
            this.phanhchinh.Controls.Add(this.lmadantoc);
            this.phanhchinh.Controls.Add(this.lmann);
            this.phanhchinh.Controls.Add(this.lphai);
            this.phanhchinh.Location = new System.Drawing.Point(5, 62);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(994, 70);
            this.phanhchinh.TabIndex = 8;
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(376, 25);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 9;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.phai.Location = new System.Drawing.Point(54, 3);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(55, 21);
            this.phai.TabIndex = 0;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(401, 3);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(181, 21);
            this.tendantoc.TabIndex = 4;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(425, 25);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(157, 21);
            this.tentqx.TabIndex = 10;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(638, 47);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(356, 21);
            this.cholam.TabIndex = 19;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(181, 25);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(138, 21);
            this.thon.TabIndex = 8;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(356, 47);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(19, 21);
            this.mapxa2.TabIndex = 17;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(82, 47);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(26, 21);
            this.maqu2.TabIndex = 14;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(638, 25);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(21, 21);
            this.matt.TabIndex = 11;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(109, 47);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(141, 21);
            this.tenquan.TabIndex = 15;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(660, 25);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(334, 21);
            this.tentinh.TabIndex = 12;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(377, 47);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(205, 21);
            this.tenpxa.TabIndex = 18;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(316, 47);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(39, 21);
            this.mapxa1.TabIndex = 16;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.BackColor = System.Drawing.SystemColors.Control;
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaphuongxa.Location = new System.Drawing.Point(248, 48);
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
            this.maqu1.Location = new System.Drawing.Point(54, 47);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 13;
            // 
            // lmaqu
            // 
            this.lmaqu.BackColor = System.Drawing.SystemColors.Control;
            this.lmaqu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmaqu.Location = new System.Drawing.Point(2, 48);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(55, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.BackColor = System.Drawing.SystemColors.Control;
            this.lmatt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmatt.Location = new System.Drawing.Point(586, 25);
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
            this.ltqx.Location = new System.Drawing.Point(307, 25);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 9;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.BackColor = System.Drawing.SystemColors.Control;
            this.lcholam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcholam.Location = new System.Drawing.Point(574, 45);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Chổ làm :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.BackColor = System.Drawing.SystemColors.Control;
            this.lthon.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lthon.Location = new System.Drawing.Point(112, 25);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(660, 3);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(334, 21);
            this.tennuoc.TabIndex = 6;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(638, 3);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(21, 21);
            this.manuoc.TabIndex = 5;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmanuoc.Location = new System.Drawing.Point(578, 1);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(54, 25);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(55, 21);
            this.sonha.TabIndex = 7;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(376, 3);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 3;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(181, 3);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 1;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(204, 3);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(116, 21);
            this.tennn.TabIndex = 2;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // lsonha
            // 
            this.lsonha.BackColor = System.Drawing.SystemColors.Control;
            this.lsonha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsonha.Location = new System.Drawing.Point(2, 26);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(56, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.BackColor = System.Drawing.SystemColors.Control;
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lmadantoc.Location = new System.Drawing.Point(322, 2);
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
            this.lmann.Location = new System.Drawing.Point(105, 3);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 58;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lphai
            // 
            this.lphai.BackColor = System.Drawing.SystemColors.Control;
            this.lphai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lphai.Location = new System.Drawing.Point(5, 2);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(53, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pvaovien.Controls.Add(this.butDateBHYT);
            this.pvaovien.Controls.Add(this.manoidk);
            this.pvaovien.Controls.Add(this.noidk);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.traituyen);
            this.pvaovien.Controls.Add(this.tenbsnb);
            this.pvaovien.Controls.Add(this.mabsnb);
            this.pvaovien.Controls.Add(this.label50);
            this.pvaovien.Controls.Add(this.trieuchung);
            this.pvaovien.Controls.Add(this.label45);
            this.pvaovien.Controls.Add(this.lblvt);
            this.pvaovien.Controls.Add(this.tungay);
            this.pvaovien.Controls.Add(this.ptb);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.dausinhton);
            this.pvaovien.Controls.Add(this.pic);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Controls.Add(this.icd_kkb);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.pmat);
            this.pvaovien.Controls.Add(this.dentu);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendstt);
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.label16);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label13);
            this.pvaovien.Controls.Add(this.lydo);
            this.pvaovien.Controls.Add(this.llydo);
            this.pvaovien.Controls.Add(this.cd_kkb);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.madstt);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
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
            this.pvaovien.Controls.Add(this.label21);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.label9);
            this.pvaovien.Controls.Add(this.button3);
            this.pvaovien.Controls.Add(this.list);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Location = new System.Drawing.Point(2, 131);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(422, 372);
            this.pvaovien.TabIndex = 9;
            // 
            // butDateBHYT
            // 
            this.butDateBHYT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDateBHYT.Location = new System.Drawing.Point(376, 65);
            this.butDateBHYT.Name = "butDateBHYT";
            this.butDateBHYT.Size = new System.Drawing.Size(26, 23);
            this.butDateBHYT.TabIndex = 111;
            this.butDateBHYT.Text = "...";
            this.butDateBHYT.Click += new System.EventHandler(this.butDateBHYT_Click);
            // 
            // manoidk
            // 
            this.manoidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manoidk.Enabled = false;
            this.manoidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manoidk.Location = new System.Drawing.Point(238, 88);
            this.manoidk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manoidk.MaxLength = 8;
            this.manoidk.Name = "manoidk";
            this.manoidk.Size = new System.Drawing.Size(57, 21);
            this.manoidk.TabIndex = 14;
            this.manoidk.Validated += new System.EventHandler(this.manoidk_Validated);
            // 
            // noidk
            // 
            this.noidk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidk.Location = new System.Drawing.Point(297, 88);
            this.noidk.Name = "noidk";
            this.noidk.Size = new System.Drawing.Size(78, 21);
            this.noidk.TabIndex = 15;
            this.noidk.TextChanged += new System.EventHandler(this.noidk_TextChanged);
            this.noidk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noidk_KeyDown);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(3, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(418, 17);
            this.label53.TabIndex = 1;
            this.label53.Text = "II. THÔNG TIN VÀO PHÒNG LƯU :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.traituyen.Location = new System.Drawing.Point(376, 87);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(45, 21);
            this.traituyen.TabIndex = 16;
            this.traituyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.traituyen_KeyDown);
            // 
            // tenbsnb
            // 
            this.tenbsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsnb.Location = new System.Drawing.Point(133, 284);
            this.tenbsnb.Name = "tenbsnb";
            this.tenbsnb.Size = new System.Drawing.Size(289, 21);
            this.tenbsnb.TabIndex = 28;
            this.tenbsnb.TextChanged += new System.EventHandler(this.tenbsnb_TextChanged);
            this.tenbsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsnb_KeyDown);
            // 
            // mabsnb
            // 
            this.mabsnb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsnb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabsnb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsnb.Location = new System.Drawing.Point(84, 284);
            this.mabsnb.Name = "mabsnb";
            this.mabsnb.Size = new System.Drawing.Size(47, 21);
            this.mabsnb.TabIndex = 27;
            this.mabsnb.Validated += new System.EventHandler(this.mabsnb_Validated);
            this.mabsnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label50.Location = new System.Drawing.Point(3, 285);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(81, 23);
            this.label50.TabIndex = 268;
            this.label50.Text = "BS nhận bệnh :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trieuchung
            // 
            this.trieuchung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trieuchung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trieuchung.Location = new System.Drawing.Point(84, 199);
            this.trieuchung.Multiline = true;
            this.trieuchung.Name = "trieuchung";
            this.trieuchung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trieuchung.Size = new System.Drawing.Size(338, 39);
            this.trieuchung.TabIndex = 24;
            this.trieuchung.TextChanged += new System.EventHandler(this.trieuchung_TextChanged);
            this.trieuchung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trieuchung_KeyDown);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(17, 199);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(66, 39);
            this.label45.TabIndex = 267;
            this.label45.Text = "Triệu chứng lâm sàng ban đầu ";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblvt
            // 
            this.lblvt.AutoSize = true;
            this.lblvt.BackColor = System.Drawing.SystemColors.Control;
            this.lblvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblvt.Location = new System.Drawing.Point(10, 336);
            this.lblvt.Name = "lblvt";
            this.lblvt.Size = new System.Drawing.Size(67, 13);
            this.lblvt.TabIndex = 265;
            this.lblvt.Text = "Fingerprint";
            this.lblvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(84, 88);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(62, 21);
            this.tungay.TabIndex = 12;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // ptb
            // 
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.Location = new System.Drawing.Point(15, 308);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(53, 38);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 264;
            this.ptb.TabStop = false;
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(190, 133);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(232, 21);
            this.qh_hoten.TabIndex = 19;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(84, 111);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 17;
            // 
            // dausinhton
            // 
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
            this.dausinhton.Controls.Add(this.label41);
            this.dausinhton.Controls.Add(this.nhietdo);
            this.dausinhton.Controls.Add(this.label32);
            this.dausinhton.Controls.Add(this.huyetap);
            this.dausinhton.Controls.Add(this.label37);
            this.dausinhton.Controls.Add(this.mach);
            this.dausinhton.Controls.Add(this.label43);
            this.dausinhton.Controls.Add(this.label44);
            this.dausinhton.Controls.Add(this.label38);
            this.dausinhton.Location = new System.Drawing.Point(147, 109);
            this.dausinhton.Name = "dausinhton";
            this.dausinhton.Size = new System.Drawing.Size(277, 24);
            this.dausinhton.TabIndex = 18;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label41.Location = new System.Drawing.Point(84, -1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(21, 23);
            this.label41.TabIndex = 1;
            this.label41.Text = "l/p";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(139, 1);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 1;
            this.nhietdo.Text = "  .  ";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label32.Location = new System.Drawing.Point(108, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(24, 23);
            this.label32.TabIndex = 3;
            this.label32.Text = "T° :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(229, 1);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label37.Location = new System.Drawing.Point(199, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(28, 23);
            this.label37.TabIndex = 3;
            this.label37.Text = "HA :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(43, 1);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(35, 21);
            this.mach.TabIndex = 0;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label43.Location = new System.Drawing.Point(169, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(24, 23);
            this.label43.TabIndex = 19;
            this.label43.Text = "°C";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label44.Location = new System.Drawing.Point(290, -1);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(38, 23);
            this.label44.TabIndex = 21;
            this.label44.Text = "mmHg";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label38.Location = new System.Drawing.Point(-6, -1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 23);
            this.label38.TabIndex = 0;
            this.label38.Text = "Mạch :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(352, 307);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 40);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 261;
            this.pic.TabStop = false;
            // 
            // khamthai
            // 
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label15);
            this.khamthai.Location = new System.Drawing.Point(156, 107);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(128, 25);
            this.khamthai.TabIndex = 15;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(105, 3);
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
            this.para3.Location = new System.Drawing.Point(81, 3);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(22, 21);
            this.para3.TabIndex = 0;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(57, 3);
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
            this.para1.Location = new System.Drawing.Point(33, 3);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(22, 21);
            this.para1.TabIndex = 0;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(3, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Para :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_kkb
            // 
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(84, 239);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(47, 21);
            this.icd_kkb.TabIndex = 25;
            this.icd_kkb.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(84, 177);
            this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_noichuyenden.MaxLength = 9;
            this.icd_noichuyenden.Name = "icd_noichuyenden";
            this.icd_noichuyenden.Size = new System.Drawing.Size(47, 21);
            this.icd_noichuyenden.TabIndex = 22;
            this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(84, 155);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(177, 21);
            this.qh_diachi.TabIndex = 20;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.label17);
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.label33);
            this.pmat.Controls.Add(this.label22);
            this.pmat.Controls.Add(this.label18);
            this.pmat.Controls.Add(this.label35);
            this.pmat.Controls.Add(this.label36);
            this.pmat.Controls.Add(this.label1);
            this.pmat.Location = new System.Drawing.Point(3, 260);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(419, 22);
            this.pmat.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(54, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "P :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(372, 1);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(44, 21);
            this.nhanapt.TabIndex = 3;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(299, 1);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(52, 21);
            this.nhanapp.TabIndex = 2;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(164, 0);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(33, 21);
            this.mt.TabIndex = 1;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(81, 1);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(38, 21);
            this.mp.TabIndex = 0;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label33.Location = new System.Drawing.Point(197, 2);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 2;
            this.label33.Text = "/10";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(332, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 4;
            this.label22.Text = "T :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(213, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 16);
            this.label18.TabIndex = 5;
            this.label18.Text = "Nhãn áp    P : ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label35.Location = new System.Drawing.Point(141, 3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(21, 16);
            this.label35.TabIndex = 1;
            this.label35.Text = "T :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label36.Location = new System.Drawing.Point(118, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 1;
            this.label36.Text = "/10";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thị lực :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(84, 44);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(84, 66);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 9;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(238, 44);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(184, 21);
            this.tendstt.TabIndex = 8;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(84, 22);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 0;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(148, 88);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(62, 21);
            this.denngay.TabIndex = 13;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(162, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 19);
            this.label16.TabIndex = 13;
            this.label16.Text = "KCB :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(200, 22);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 1;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(170, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 250;
            this.label13.Text = "giờ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(84, 261);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(337, 21);
            this.lydo.TabIndex = 25;
            this.lydo.TextChanged += new System.EventHandler(this.lydo_TextChanged);
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // llydo
            // 
            this.llydo.BackColor = System.Drawing.SystemColors.Control;
            this.llydo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.llydo.Location = new System.Drawing.Point(13, 260);
            this.llydo.Name = "llydo";
            this.llydo.Size = new System.Drawing.Size(73, 23);
            this.llydo.TabIndex = 219;
            this.llydo.Text = "Ghi chú :";
            this.llydo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_kkb
            // 
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(132, 239);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(288, 21);
            this.cd_kkb.TabIndex = 26;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label34.Location = new System.Drawing.Point(6, 236);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 23);
            this.label34.TabIndex = 218;
            this.label34.Text = "Chẩn đoán :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(132, 177);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(290, 21);
            this.cd_noichuyenden.TabIndex = 23;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(200, 44);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(37, 21);
            this.madstt.TabIndex = 7;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendentu
            // 
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(103, 44);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(66, 21);
            this.tendentu.TabIndex = 6;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // tennhantu
            // 
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(310, 22);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(111, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(290, 22);
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
            this.label20.Location = new System.Drawing.Point(211, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 210;
            this.label20.Text = "Nhận từ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(103, 66);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(97, 21);
            this.tendoituong.TabIndex = 10;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label31.Location = new System.Drawing.Point(3, 175);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 23);
            this.label31.TabIndex = 2;
            this.label31.Text = "CĐ nơi chuyển :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(318, 155);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(104, 21);
            this.qh_dienthoai.TabIndex = 21;
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(84, 133);
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
            this.sothe.Location = new System.Drawing.Point(238, 66);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(137, 21);
            this.sothe.TabIndex = 11;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(15, 109);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label29.Location = new System.Drawing.Point(256, 154);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label28.Location = new System.Drawing.Point(22, 153);
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
            this.label27.Location = new System.Drawing.Point(126, 131);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(6, 131);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người thân :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(23, 86);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 196;
            this.label25.Text = "Từ ngày :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(198, 65);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label23.Location = new System.Drawing.Point(23, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(8, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 23);
            this.label21.TabIndex = 191;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(10, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày vào :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(118, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(425, 372);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(209, 0);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 255;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(306, 0);
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
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(86, 437);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(267, 63);
            this.treeView1.TabIndex = 8;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(430, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(571, 18);
            this.label8.TabIndex = 208;
            this.label8.Text = "III. THÔNG TIN RA PHÒNG LƯU :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gphaubenh
            // 
            this.gphaubenh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(755, 476);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(32, 21);
            this.gphaubenh.TabIndex = 33;
            this.gphaubenh.Visible = false;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(526, 43);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(60, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(753, 477);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(32, 21);
            this.cmbTaibien.TabIndex = 32;
            this.cmbTaibien.Visible = false;
            // 
            // cd_chinh
            // 
            this.cd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(553, 196);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(446, 21);
            this.cd_chinh.TabIndex = 17;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(197, 517);
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
            this.cd_kemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(553, 218);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(446, 21);
            this.cd_kemtheo.TabIndex = 19;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(442, 283);
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
            this.soluutru.Location = new System.Drawing.Point(504, 284);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(76, 21);
            this.soluutru.TabIndex = 24;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(285, 517);
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
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(553, 262);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(446, 21);
            this.tenbs.TabIndex = 23;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(430, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 226;
            this.label11.Text = "Khoa : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoa
            // 
            this.khoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(504, 439);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(55, 21);
            this.khoa.TabIndex = 29;
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(561, 439);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(435, 21);
            this.tenkhoa.TabIndex = 30;
            this.tenkhoa.SelectedIndexChanged += new System.EventHandler(this.tenkhoa_SelectedIndexChanged);
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xutri.BackColor = System.Drawing.SystemColors.Info;
            this.xutri.CheckOnClick = true;
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(504, 306);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(494, 84);
            this.xutri.TabIndex = 25;
            this.xutri.SelectedIndexChanged += new System.EventHandler(this.xutri_SelectedIndexChanged);
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // ngayrv
            // 
            this.ngayrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrv.Location = new System.Drawing.Point(504, 152);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(70, 21);
            this.ngayrv.TabIndex = 10;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // songaydt
            // 
            this.songaydt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.songaydt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songaydt.Enabled = false;
            this.songaydt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaydt.Location = new System.Drawing.Point(726, 152);
            this.songaydt.Name = "songaydt";
            this.songaydt.Size = new System.Drawing.Size(272, 21);
            this.songaydt.TabIndex = 12;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.SystemColors.Control;
            this.label51.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label51.Location = new System.Drawing.Point(624, 152);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(104, 20);
            this.label51.TabIndex = 13;
            this.label51.Text = "Thời gian điều trị :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenketqua
            // 
            this.tenketqua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenketqua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenketqua.Location = new System.Drawing.Point(696, 174);
            this.tenketqua.Name = "tenketqua";
            this.tenketqua.Size = new System.Drawing.Size(302, 21);
            this.tenketqua.TabIndex = 15;
            this.tenketqua.SelectedIndexChanged += new System.EventHandler(this.tenketqua_SelectedIndexChanged);
            this.tenketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenketqua_KeyDown);
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(504, 174);
            this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giuong.MaxLength = 10;
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(93, 21);
            this.giuong.TabIndex = 13;
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(676, 174);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(18, 21);
            this.ketqua.TabIndex = 14;
            this.ketqua.Validated += new System.EventHandler(this.ketqua_Validated);
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(621, 172);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 237;
            this.label39.Text = "Kết quả :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lgiuong
            // 
            this.lgiuong.BackColor = System.Drawing.SystemColors.Control;
            this.lgiuong.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lgiuong.Location = new System.Drawing.Point(445, 171);
            this.lgiuong.Name = "lgiuong";
            this.lgiuong.Size = new System.Drawing.Size(59, 23);
            this.lgiuong.TabIndex = 236;
            this.lgiuong.Text = "Giường :";
            this.lgiuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(445, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 23);
            this.label12.TabIndex = 216;
            this.label12.Text = "Ngày ra :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator11,
            this.tbutvantay,
            this.stripvt,
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
            this.tlbl,
            this.toolStripSeparator1,
            this.toolStripButton12,
            this.toolStripSeparator12,
            this.toolStripButton13,
            this.toolStripSeparator13,
            this.toolStripButton14,
            this.tButBaolucgiadinh,
            this.chkToathuoc111111111,
            this.tbutchuphinh});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 23);
            this.toolStrip1.TabIndex = 247;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton1.Text = "F3";
            this.toolStripButton1.ToolTipText = "Toa bảo hiểm(Đơn thuốc BHYT)";
            this.toolStripButton1.Click += new System.EventHandler(this.l_thuocbhyt_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // tbutvantay
            // 
            this.tbutvantay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbutvantay.Image = ((System.Drawing.Image)(resources.GetObject("tbutvantay.Image")));
            this.tbutvantay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutvantay.Name = "tbutvantay";
            this.tbutvantay.Size = new System.Drawing.Size(39, 20);
            this.tbutvantay.Text = "F2";
            this.tbutvantay.ToolTipText = "Lấy vân tay";
            this.tbutvantay.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // stripvt
            // 
            this.stripvt.Name = "stripvt";
            this.stripvt.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton2.Text = "F5";
            this.toolStripButton2.ToolTipText = "Toa mua ngoài(Đơn thuốc dịch vụ)";
            this.toolStripButton2.Click += new System.EventHandler(this.l_thuocdan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton3.Text = "F6";
            this.toolStripButton3.ToolTipText = "Phẩu thuật - thủ thuật";
            this.toolStripButton3.Click += new System.EventHandler(this.l_phauthuat_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton4.Text = "F7";
            this.toolStripButton4.ToolTipText = "Yêu cầu cận lâm sàng(Chỉ định cận lâm sàng)";
            this.toolStripButton4.Click += new System.EventHandler(this.l_chidinh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton5.Text = "F8";
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
            this.toolStripButton6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton6.Text = "F9";
            this.toolStripButton6.ToolTipText = "Tai nạn thương tích";
            this.toolStripButton6.Click += new System.EventHandler(this.l_tainantt_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton7.Text = "F10";
            this.toolStripButton7.ToolTipText = "Thuốc tủ trực";
            this.toolStripButton7.Click += new System.EventHandler(this.l_tutruc_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton8.Text = "F11";
            this.toolStripButton8.ToolTipText = "Bệnh kèm theo";
            this.toolStripButton8.Click += new System.EventHandler(this.l_kemtheo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton9.Text = "F12";
            this.toolStripButton9.ToolTipText = "Xem hồ sơ bệnh án";
            this.toolStripButton9.Click += new System.EventHandler(this.l_cls_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(43, 20);
            this.toolStripButton10.Text = "^D";
            this.toolStripButton10.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton10.Click += new System.EventHandler(this.l_diungthuoc_Click);
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
            this.toolStripButton11.Size = new System.Drawing.Size(41, 20);
            this.toolStripButton11.Text = "^L";
            this.toolStripButton11.ToolTipText = "Lịch hẹn";
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            this.tlbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton12.Text = "toolStripButton12";
            this.toolStripButton12.ToolTipText = "Tự sát";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click_1);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton13.ToolTipText = "Bệnh mãn tính";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
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
            this.toolStripButton14.ToolTipText = "Tiền sử bệnh";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // tButBaolucgiadinh
            // 
            this.tButBaolucgiadinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tButBaolucgiadinh.Image = ((System.Drawing.Image)(resources.GetObject("tButBaolucgiadinh.Image")));
            this.tButBaolucgiadinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tButBaolucgiadinh.Name = "tButBaolucgiadinh";
            this.tButBaolucgiadinh.Size = new System.Drawing.Size(23, 20);
            this.tButBaolucgiadinh.Text = "toolStripButton15";
            this.tButBaolucgiadinh.ToolTipText = "Phiếu sàng lọc nạn nhân bạo lực gia đình";
            this.tButBaolucgiadinh.Click += new System.EventHandler(this.tButBaolucgiadinh_Click);
            // 
            // chkToathuoc111111111
            // 
            this.chkToathuoc111111111.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chkToathuoc111111111.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkToathuoc,
            this.chkXem,
            this.chkIn});
            this.chkToathuoc111111111.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkToathuoc111111111.Name = "chkToathuoc111111111";
            this.chkToathuoc111111111.Size = new System.Drawing.Size(13, 4);
            this.chkToathuoc111111111.Text = "Tùy chọn";
            // 
            // chkToathuoc
            // 
            this.chkToathuoc.Checked = true;
            this.chkToathuoc.CheckOnClick = true;
            this.chkToathuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToathuoc.Name = "chkToathuoc";
            this.chkToathuoc.Size = new System.Drawing.Size(183, 22);
            this.chkToathuoc.Text = "In kèm toa thuốc";
            // 
            // chkXem
            // 
            this.chkXem.CheckOnClick = true;
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(183, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkIn
            // 
            this.chkIn.CheckOnClick = true;
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(183, 22);
            this.chkIn.Text = "In thanh toan ra viện";
            // 
            // tbutchuphinh
            // 
            this.tbutchuphinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbutchuphinh.Image = ((System.Drawing.Image)(resources.GetObject("tbutchuphinh.Image")));
            this.tbutchuphinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbutchuphinh.Name = "tbutchuphinh";
            this.tbutchuphinh.Size = new System.Drawing.Size(23, 20);
            this.tbutchuphinh.Text = "toolStripButton15";
            this.tbutchuphinh.Click += new System.EventHandler(this.tbutchuphinh_Click);
            // 
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(603, 152);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(36, 21);
            this.giorv.TabIndex = 11;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(570, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 20);
            this.label14.TabIndex = 254;
            this.label14.Text = "giờ :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butPhong
            // 
            this.butPhong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPhong.Location = new System.Drawing.Point(600, 173);
            this.butPhong.Name = "butPhong";
            this.butPhong.Size = new System.Drawing.Size(26, 23);
            this.butPhong.TabIndex = 14;
            this.butPhong.Text = "...";
            this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(2, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1001, 106);
            this.button1.TabIndex = 259;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(433, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(570, 373);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.BackColor = System.Drawing.SystemColors.Control;
            this.chkXML.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXML.Location = new System.Drawing.Point(872, 509);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(124, 17);
            this.chkXML.TabIndex = 261;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = false;
            // 
            // maxutri
            // 
            this.maxutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maxutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maxutri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maxutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxutri.Location = new System.Drawing.Point(617, 284);
            this.maxutri.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maxutri.Name = "maxutri";
            this.maxutri.Size = new System.Drawing.Size(382, 21);
            this.maxutri.TabIndex = 25;
            this.maxutri.Validated += new System.EventHandler(this.maxutri_Validated);
            // 
            // butget_msbn_from_internet
            // 
            this.butget_msbn_from_internet.Location = new System.Drawing.Point(402, 21);
            this.butget_msbn_from_internet.Name = "butget_msbn_from_internet";
            this.butget_msbn_from_internet.Size = new System.Drawing.Size(70, 22);
            this.butget_msbn_from_internet.TabIndex = 270;
            this.butget_msbn_from_internet.Text = "Lấy Mã BN";
            this.butget_msbn_from_internet.UseVisualStyleBackColor = true;
            this.butget_msbn_from_internet.Visible = false;
            this.butget_msbn_from_internet.Click += new System.EventHandler(this.butget_msbn_from_internet_Click);
            // 
            // butInchitiet
            // 
            this.butInchitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInchitiet.BackColor = System.Drawing.Color.Transparent;
            this.butInchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchitiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butInchitiet.Image = ((System.Drawing.Image)(resources.GetObject("butInchitiet.Image")));
            this.butInchitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchitiet.Location = new System.Drawing.Point(333, 506);
            this.butInchitiet.Name = "butInchitiet";
            this.butInchitiet.Size = new System.Drawing.Size(70, 25);
            this.butInchitiet.TabIndex = 258;
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
            this.butIncv.Location = new System.Drawing.Point(489, 506);
            this.butIncv.Name = "butIncv";
            this.butIncv.Size = new System.Drawing.Size(91, 25);
            this.butIncv.TabIndex = 246;
            this.butIncv.Text = "     Chuyển viện";
            this.butIncv.UseVisualStyleBackColor = false;
            this.butIncv.Click += new System.EventHandler(this.butIncv_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(580, 506);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 34;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(403, 506);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(86, 25);
            this.butIn.TabIndex = 91;
            this.butIn.Text = "Phiếu khám";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.butBoqua.Location = new System.Drawing.Point(263, 506);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 33;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
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
            this.butLuu.Location = new System.Drawing.Point(193, 506);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 31;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(123, 506);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 32;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // cd_nguyennhan
            // 
            this.cd_nguyennhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_nguyennhan.Location = new System.Drawing.Point(553, 240);
            this.cd_nguyennhan.Name = "cd_nguyennhan";
            this.cd_nguyennhan.Size = new System.Drawing.Size(446, 21);
            this.cd_nguyennhan.TabIndex = 21;
            this.cd_nguyennhan.Validated += new System.EventHandler(this.cd_nguyennhan_Validated);
            this.cd_nguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_nguyennhan_KeyDown);
            // 
            // icd_nguyennhan
            // 
            this.icd_nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_nguyennhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_nguyennhan.Location = new System.Drawing.Point(504, 240);
            this.icd_nguyennhan.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_nguyennhan.MaxLength = 9;
            this.icd_nguyennhan.Name = "icd_nguyennhan";
            this.icd_nguyennhan.Size = new System.Drawing.Size(47, 21);
            this.icd_nguyennhan.TabIndex = 20;
            this.icd_nguyennhan.TextChanged += new System.EventHandler(this.icd_nguyennhan_TextChanged);
            this.icd_nguyennhan.Validated += new System.EventHandler(this.icd_nguyennhan_Validated);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label54.Location = new System.Drawing.Point(435, 238);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(72, 23);
            this.label54.TabIndex = 273;
            this.label54.Text = "Nguyên nhân";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mathe
            // 
            this.mathe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mathe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mathe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mathe.Location = new System.Drawing.Point(186, 24);
            this.mathe.MaxLength = 20;
            this.mathe.Name = "mathe";
            this.mathe.Size = new System.Drawing.Size(138, 21);
            this.mathe.TabIndex = 0;
            this.mathe.TextChanged += new System.EventHandler(this.mathe_TextChanged);
            this.mathe.Validated += new System.EventHandler(this.mathe_Validated);
            this.mathe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mathe_KeyDown);
            // 
            // chkBhyt
            // 
            this.chkBhyt.BackColor = System.Drawing.SystemColors.Control;
            this.chkBhyt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkBhyt.Location = new System.Drawing.Point(127, 25);
            this.chkBhyt.Name = "chkBhyt";
            this.chkBhyt.Size = new System.Drawing.Size(73, 17);
            this.chkBhyt.TabIndex = 275;
            this.chkBhyt.Text = "Số thẻ :";
            this.chkBhyt.UseVisualStyleBackColor = false;
            this.chkBhyt.CheckedChanged += new System.EventHandler(this.chkBhyt_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(791, 506);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 25);
            this.button4.TabIndex = 276;
            this.button4.Text = "In Mã BN";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmPhongluu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1006, 536);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.mathe);
            this.Controls.Add(this.chkBhyt);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.icd_nguyennhan);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.cd_nguyennhan);
            this.Controls.Add(this.butget_msbn_from_internet);
            this.Controls.Add(this.ngayrv);
            this.Controls.Add(this.maxutri);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.butPhong);
            this.Controls.Add(this.butInchitiet);
            this.Controls.Add(this.giorv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.butIncv);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.songaydt);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.tenketqua);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.lgiuong);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cd_kemtheo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPhongluu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhongluu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhongluu_KeyDown);
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmPhongluu_Load(object sender, System.EventArgs e)
        {
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_load_option();
            //
            
            if (s_mabn != null && s_mabn.Trim() != "")
                if (s_mabn.Length > 2) mabn3.Text = s_mabn.Substring(2);

            bThongtinNguoithan = m.bThongtinNguoithan;
            bBNPhongluu_nhapnguoithan = m.bBNPhongluu_nhapnguoithan;
            bTraituyen = m.bTraituyen;
            bSothe_ngay_huong = m.bSothe_ngay_huong;
            traituyen.Enabled = bTraituyen;
            traituyen.SelectedIndex = 0; lTraituyen = (bTraituyen) ? m.lTraituyen_noitru : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            bHaophi = m.bHaophi_thanhtoan; bHaophi_doituongvao = m.bHaophi_thanhtoan_doituongvao;
            s_nhomhaophi = m.sHaophi_thanhtoan; iHaophi = d.iHaophi;
            pathImage = m.pathImage; bPhongluu_bhyt_khambenh = m.bPhongluu_bhyt_khambenh;
            FileType = m.FileType; bPhongluu_chuyenkham_kcong = m.bPhongluu_chuyenkham_kcong;
            bSothe_dkkcb = m.bSothe_dkkcb;
            bDuyet_khambenh = m.bDuyet_khambenh;
            user = m.user; bPhonggiuong = m.bPhonggiuong;
            madoituong_giuongdichvu = (m.bMadoituong_giuongdichvu) ? m.madoituong_giuongdichvu : 0;
            bNgayra_ngayvao_1 = m.bNgayra_ngayvao_1;
            dausinhton.Visible = m.bDausinhton_khambenh;
            bchidinh_chonngay = m.bPhongluu_chidinh_chonngay;
            if (bPhonggiuong) dtg = m.get_data("select a.*,b.dichvu from " + user + ".dmgiuong a," + user + ".dmphong b where a.idphong=b.id").Tables[0];
            giuong.Enabled = !bPhonggiuong;
            butPhong.Visible = bPhonggiuong;
            bDichvu_vpkb = m.bDichvu_vpkb;
            bSothe_mabn = m.bsothe_mabn; bSovaovien = m.bSovaovien;
            bCongkham = m.bInchiphi_congkham;
            Congkham = d.Congkham(m.nhom_duoc);
            sql = "select * from " + user + ".btdkp_bv where 1=1 ";
            if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
            if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
            dtkp = m.get_data(sql).Tables[0];
            dtgia = m.get_data("select * from " + user + ".v_giavp").Tables[0];
            trieuchung.Enabled = m.bTrieuchung;
            pic.Visible = m.bHinh || m.bChonhinh;
            bThuphi_kham = m.bThuphi_kham;
            bDanhsach = m.bDanhsach_cho;
            bTungay = m.bBHYT_tungay;
            tungay.Enabled = bTungay;

            bInravien_ravien = m.bInravien_ravien;
            bInthanhtoanchitiet = m.bInthanhtoanchitiet;
            bInchitiet = m.bKham_inchiphi;
            bCapcuu_noitru = m.bCapcuu_noitru;
            butInchitiet.Enabled = bInchitiet;
            chkToathuoc111111111.Visible = butInchitiet.Enabled;
            //chkIn.Enabled = bInravien_ravien && !bInchitiet;//!bCapcuu_noitru && 
            if (chkIn.Enabled) chkIn.Checked = bInravien_ravien;
            chkXem.Checked = m.bPreview;
            // Thang
            bVantay = m.bVantay;
            if (bVantay) bVantay_mabntudong = m.bVantay_mabntudong;
            else bVantay_mabntudong = false;
            ptb.Visible = bVantay;
            tbutvantay.Visible = bVantay;
            lblvt.Visible = bVantay;
            stripvt.Visible = bVantay;
            //
            if (bInchitiet)
            {
                bChuky = m.bChuky;
                sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom, a.kythuat ";
                sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
                sql += " where a.id_loai=b.id and b.id_nhom=c.ma";
                dtvpin = m.get_data(sql).Tables[0];

                sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
                sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom,e.id as nhomin, a.kythuat ";
                sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d," + user + ".d_nhomin e";
                sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma and c.nhomin=e.id";
                dtbd = m.get_data(sql).Tables[0];

                dsxmlin.ReadXml("..//..//..//xml//m_inravien.xml");
                DataColumn dc = new DataColumn("Image", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add(dc);
                dc = new DataColumn("Imagetk", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add(dc);
                dc = new DataColumn("Imageuser", typeof(byte[]));
                dsxmlin.Tables[0].Columns.Add(dc);
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
                dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal)).DefaultValue = -1;
                dsxmlin.Tables[0].Columns.Add("loaikythuat");
                dsxmlin.Tables[0].Columns.Add("ghichukb");
                dsxmlin.Tables[0].Columns.Add("trieuchung");
                dsxmlin.Tables[0].Columns.Add("phanbiet");
            }

            pmat.Visible = m.Mabv_so == 701424;
            llydo.Visible = !pmat.Visible;
            lydo.Visible = llydo.Visible;
            bChandoan = m.bChandoan_icd10;
            bChandoan_kemtheo = m.bChandoan_kemtheo_icd10;
            bDenngay_sothe = m.bDenngay_sothe;
            bTiepdon = m.bTiepdon(LibMedi.AccessData.Phongluu);
            bKhamthai = m.bKhamthai;
            khamthai.Visible = bKhamthai;
            bChuyenkhoasan = m.bChuyenkhoasan;
            bDanhmuc_nhathuoc = m.bDanhmuc_nhathuoc;
            if (bChuyenkhoasan) phai.SelectedIndex = 1;
            i_sokham = m.iSokham;
            tlbl.Text = "";
            bXutri_noitru = m.bXutri_noitru_pl;
            bXutri_ngoaitru = m.bXutri_ngoaitru_pl;
            s_makp = LibMedi.AccessData.phongluu;
            iChidinh = m.iChidinh;
            bAdmin = m.bAdmin(i_userid);
            bLuutru_Mabn = m.bSoluutru_Mabn;
            b_Hoten = m.bHoten_gioitinh;
            b_sovaovien = m.bSovaovien;
            load_dm();
            iKhamnhi = m.iTuoi_khamnhi;
            phai.SelectedIndex = 0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = (s_ngayvv.Trim() == "") ? m.ngayhienhanh_server : s_ngayvv.Substring(0, 10);
            giovv.Text = (s_ngayvv.Trim() == "") ? m.ngayhienhanh_server.Substring(11) : s_ngayvv.Substring(11);
            songay = m.Ngaylv_Ngayht;
            s_msg = LibMedi.AccessData.Msg;
            cd_noichuyenden.Enabled = m.bChandoan;
            cd_chinh.Enabled = cd_noichuyenden.Enabled;
            cd_kemtheo.Enabled = cd_noichuyenden.Enabled;
            iTreem6 = m.iTreem6;
            iTreem15 = m.iTreem15;
            soluutru.Enabled = !bLuutru_Mabn;
            DataTable tmp = m.get_data("select maba from " + user + ".dmbenhan where loaiba=2 order by maba").Tables[0];
            if (tmp.Rows.Count > 0) i_bangoaitru = int.Parse(tmp.Rows[0]["maba"].ToString());
            else i_bangoaitru = 20;
            //QRCODE
            bBHYT_QRCode_Dangky = m.bBHYT_QRCode_Dangky;
            mathe.MaxLength = (bBHYT_QRCode_Dangky) ? 20000 : 20;
            bSothe_dmbhyt = m.bSothe_dmbhyt; 
            if (bSothe_dmbhyt) chkBhyt.Checked = m.Thongso("c345") == "1";
            else if (bBHYT_QRCode_Dangky) chkBhyt.Checked = true;
            else chkBhyt.Checked = false;

            mathe.Enabled = (bSothe_dmbhyt && chkBhyt.Checked) || bBHYT_QRCode_Dangky;
            
            //            
            //
            butTiep_Click(null, null);
        }

        private void load_diungthuoc()
        {
            tlbl.Text = "";
            foreach (DataRow r in m.get_data("select distinct b.ten from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b where a.mahc=b.ma and a.mabn='" + mabn2.Text + mabn3.Text + "'").Tables[0].Rows) tlbl.Text += r["ten"].ToString().Trim() + ";";
            if (tlbl.Text != "") tlbl.Text = lan.Change_language_MessageText("DỊ ỨNG THUỐC :") + tlbl.Text;
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

        private void load_vienphi()
        {
            //sql="select * from v_vpkhoa";
            //if (iChidinh==1) sql+=" where mabn='"+s_mabn+"'";
            //else if (iChidinh==2) sql+=" where maql="+l_maql;
            //else if (iChidinh==3) sql+=" where idkhoa="+l_id;
            //vienphi.Checked=m.get_data(sql).Tables[0].Rows.Count!=0;
            //l_vienphi.ForeColor=(vienphi.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
        }

        private void load_baohiem()
        {
            //thuocbhyt.Checked=m.get_data("select * from d_thuocbhytll where nhom="+m.nhom_duoc+" and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuocbhyt.ForeColor=(thuocbhyt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
        }

        private void load_dm()
        {
            list.DisplayMember = "MABV";
            list.ValueMember = "TENBV";
            list.DataSource = m.get_data("select mabv,tenbv,diachi from " + user + ".dmnoicapbhyt where hide=0  order by mabv").Tables[0];

            listdstt.DisplayMember = "MABV";
            listdstt.ValueMember = "TENBV";
            listdstt.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + user + ".dstt where mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;

            if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0].Rows.Count == 0)
                m.upd_btdkp_bv("btdkp_bv", s_makp, "Phòng lưu", 0, 0, "02", "", 4, 0, "", "", "PL", "", "", "");
            tenkhoa.DisplayMember = "TENKP";
            tenkhoa.ValueMember = "MAKP";
            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0 and kehoach>0 ";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
            if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
            sql += " order by makp";
            tenkhoa.DataSource = m.get_data(sql).Tables[0];

            dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=3 order by maba").Tables[0];
            tenba.DisplayMember = "TENVT";
            tenba.ValueMember = "MAVT";
            tenba.DataSource = dtba;
            tenba.SelectedIndex = 0;
            if (m.Mabv.Length > 3) mabn1.Text = m.Mabv_so.ToString();
            mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);

            tennn.DisplayMember = "TENNN";
            tennn.ValueMember = "MANN";
            load_btdnn(0);

            tenketqua.DisplayMember = "TEN";
            tenketqua.ValueMember = "MA";
            tenketqua.DataSource = m.get_data("select * from " + user + ".ketqua order by ma").Tables[0];
            tenketqua.SelectedIndex = -1;

            tendantoc.DisplayMember = "DANTOC";
            tendantoc.ValueMember = "MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];
            tendantoc.SelectedValue = "25";

            tentinh.DisplayMember = "TENTT";
            tentinh.ValueMember = "MATT";
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];
            tentinh.SelectedValue = m.Mabv.Substring(0, 3);

            tenquan.DisplayMember = "TENQUAN";
            tenquan.ValueMember = "MAQU";
            load_quan();

            tenpxa.DisplayMember = "TENPXA";
            tenpxa.ValueMember = "MAPHUONGXA";
            load_pxa();

            tennuoc.DisplayMember = "TEN";
            tennuoc.ValueMember = "MA";
            tennuoc.DataSource = m.get_data("select * from " + user + ".dmquocgia order by ma").Tables[0];
            tennuoc.SelectedIndex = -1;

            tentqx.DisplayMember = "TEN";
            tentqx.ValueMember = "MAPHUONGXA";

            tendentu.DisplayMember = "TEN";
            tendentu.ValueMember = "MA";
            tendentu.DataSource = m.get_data("select * from " + user + ".dentu order by ma").Tables[0];
            tendentu.SelectedIndex = -1;

            tennhantu.DisplayMember = "TEN";
            tennhantu.ValueMember = "MA";
            tennhantu.DataSource = m.get_data("select * from " + user + ".nhantu order by ma").Tables[0];
            tennhantu.SelectedIndex = -1;

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a ";
            if (s_madoituong != "") sql += " where a.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
            sql += " order by a.madoituong";
            dtdt = m.get_data(sql).Tables[0];
            tendoituong.DisplayMember = "DOITUONG";
            tendoituong.ValueMember = "MADOITUONG";
            tendoituong.DataSource = dtdt;
            tendoituong.SelectedIndex = -1;

            dtxutri = m.get_data("select ma,to_char(ma,'00')||'   '||ten as ten from " + user + ".xutrikb where hide=0 order by ma").Tables[0];
            xutri.DataSource = dtxutri;
            xutri.DisplayMember = "TEN";
            xutri.ValueMember = "MA";

            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DataSource = dtbs;

            tenloaibv.DisplayMember = "TEN";
            tenloaibv.ValueMember = "MA";
            tenloaibv.DataSource = m.get_data("select * from " + user + ".loaibv order by ma").Tables[0];
            tenloaibv.SelectedIndex = -1;

            tenbv.DisplayMember = "TENBV";
            tenbv.ValueMember = "MABV";

            gphaubenh.DisplayMember = "TEN";
            gphaubenh.ValueMember = "MA";
            gphaubenh.DataSource = m.get_data("select * from " + user + ".gphaubenh").Tables[0];

            cmbTaibien.DisplayMember = "TEN";
            cmbTaibien.ValueMember = "MA";
            cmbTaibien.DataSource = m.get_data("select * from " + user + ".taibien").Tables[0];
        }

        private void load_mabv(string maloai)
        {
            if (maloai == "3")
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where substr(maloai,1,1)='2' and mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
            else
                tenbv.DataSource = m.get_data("select * from " + user + ".tenvien where mabv like '" + mabv.Text + "%'" + " and mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];
        }

        private void load_tqx()
        {
            tentqx.DataSource = m.Tqx(tqx.Text).Tables[0];
        }

        private void ena_tuoi(bool ena)
        {
            tuoi.Enabled = ena;
            loaituoi.Enabled = ena;
        }

        private void ena_namsinh(bool ena)
        {
            namsinh.Enabled = ena;
        }

        private void load_quan()
        {
            try
            {
                tenquan.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
            }
            catch { }
        }

        private void load_pxa()
        {
            try
            {
                tenpxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
            }
            catch { }
        }

        private void hoten_Validated(object sender, System.EventArgs e)
        {
            if (hoten.Text == "") mabn2.Focus();
            else
            {
                if (m.bvodanh(hoten.Text))
                {
                    hoten.Text = m.vodanh;
                    tuoi.Text = m.vodanh_tuoi.ToString();
                    loaituoi.SelectedIndex = 0;
                    namsinh.Text = m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString();
                    phai.SelectedIndex = m.vodanh_gioitinh;
                    tendantoc.SelectedValue = m.vodanh_dantoc;
                    madantoc.Text = tendantoc.SelectedValue.ToString();
                    try
                    {
                        tennn.SelectedValue = m.vodanh_nghenghiep;
                    }
                    catch { tennn.SelectedIndex = 0; }
                    mann.Text = tennn.SelectedValue.ToString();
                    tentinh.SelectedValue = m.vodanh_tinh;
                    load_quan();
                    tenquan.SelectedValue = tentinh.SelectedValue.ToString() + "00";
                    maqu1.Text = tentinh.SelectedValue.ToString();
                    maqu2.Text = "00";
                    load_pxa();
                    tenpxa.SelectedValue = tenquan.SelectedValue.ToString() + "00";
                    ngayvv.Focus();
                }
            }
        }

        private void tenba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenba.SelectedIndex == -1) tenba.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tenba_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                maba.Text = tenba.SelectedValue.ToString();
                this.Text = lan.Change_language_MessageText("Phòng lưu") + "<" +
                lan.Change_language_MessageText("Người cập nhật :") + "  " + s_userid.Trim() + " >";
                DataRow r = m.getrowbyid(dtba, "mavt='" + tenba.SelectedValue.ToString() + "'");
                if (r != null) i_maba = int.Parse(r[0].ToString());
                else i_maba = 0;
            }
            catch { }
        }

        private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (loaituoi.SelectedIndex == -1) loaituoi.SelectedIndex = 0;
                namsinh.Text = m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString();
                if (!load_tim_mabn())
                {
                    if (phai.Enabled)
                    {
                        //SendKeys.Send("{Tab}{F4}"); 
                        phai.Focus();
                    }//gam 07/092011
                    else
                    {
                        //SendKeys.Send("{Tab}"); 
                        phai.Focus();
                    }
                }
            }
        }

        private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (phai.SelectedIndex == -1) phai.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private bool load_tim_mabn()
        {
            string s_mann = mann.Text;
            load_btdnn(1);
            tennn.SelectedValue = s_mann;
            if (!b_Edit)
            {
                s_ngayvv = "";
                s_mabn = mabn2.Text + mabn3.Text;
                DataTable dt = m.get_Timmabn(hoten.Text, ngaysinh.Text, namsinh.Text, s_mabn).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    frmTimMabn f = new frmTimMabn(dt);
                    f.ShowDialog();
                    if (f.m_mabn != "")
                    {
                        mabn2.Text = f.m_mabn.Substring(0, 2);
                        mabn3.Text = f.m_mabn.Substring(2,f.m_mabn.Length-2);
                        s_mabn = mabn2.Text + mabn3.Text;
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
            if (e.KeyCode == Keys.Enter)
            {
                if (tennn.SelectedIndex == -1) tennn.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void ena_nuoc(bool ena)
        {
            manuoc.Enabled = ena;
            tennuoc.Enabled = ena;
        }

        private void tennn_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                mann.Text = tennn.SelectedValue.ToString();
            }
            catch { mann.Text = ""; }
        }

        private void tendantoc_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                madantoc.Text = tendantoc.SelectedValue.ToString();
                if (madantoc.Text == "55") ena_nuoc(true);
                else
                {
                    ena_nuoc(false);
                    tennuoc.SelectedValue = "VN";
                }
            }
            catch { madantoc.Text = ""; }
        }

        private void tendantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tendantoc.SelectedIndex == -1) tendantoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tennuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tennuoc.SelectedIndex == -1) tennuoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tennuoc_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                manuoc.Text = tennuoc.SelectedValue.ToString();
            }
            catch { manuoc.Text = ""; }
        }

        private void tentqx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                tentinh.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 3);
                tenquan.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 5);
                tenpxa.SelectedValue = tentqx.SelectedValue.ToString();
            }
            catch { tqx.Text = ""; }
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
        private void tentqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tentqx.SelectedIndex == -1) tentqx.SelectedIndex = 0;
                    tentinh.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 3);
                    tenquan.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 5);
                    tenpxa.SelectedValue = tentqx.SelectedValue.ToString();
                    cholam.Focus();
                    return;
                }
                catch { }
                SendKeys.Send("{Tab}");
            }
        }

        private void tentinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tentinh.SelectedIndex == -1) tentinh.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tentinh_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                matt.Text = tentinh.SelectedValue.ToString();
                load_quan();
            }
            catch { matt.Text = ""; }
        }

        private void tenquan_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                maqu1.Text = tenquan.SelectedValue.ToString().Substring(0, 3);
                maqu2.Text = tenquan.SelectedValue.ToString().Substring(3, 2);
                load_pxa();
            }
            catch
            {
                maqu1.Text = "";
                maqu2.Text = "";
            }
        }

        private void tenquan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenquan.SelectedIndex == -1) tenquan.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tenpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenpxa.SelectedIndex == -1) tenpxa.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tenpxa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                mapxa1.Text = tenpxa.SelectedValue.ToString().Substring(0, 5);
                mapxa2.Text = tenpxa.SelectedValue.ToString().Substring(5, 2);
            }
            catch
            {
                mapxa1.Text = "";
                mapxa2.Text = "";
            }
        }

        private void maba_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenba.SelectedValue = maba.Text;
            }
            catch { }
        }

        private void maba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void manuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void matt_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tentinh.SelectedValue = matt.Text;
            }
            catch { }
        }

        private void mann_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tennn.SelectedValue = mann.Text;
            }
            catch { }
        }

        private void madantoc_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tendantoc.SelectedValue = madantoc.Text;
            }
            catch { }
        }

        private void manuoc_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tennuoc.SelectedValue = manuoc.Text;
            }
            catch { }
        }

        private void maqu2_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenquan.SelectedValue = maqu1.Text + maqu2.Text;
            }
            catch { }
        }

        private void maqu2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mapxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mapxa2_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenpxa.SelectedValue = mapxa1.Text + mapxa2.Text;
            }
            catch { }
        }

        private void tqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tqx.Text == "") matt.Focus();
                else
                {
                    load_tqx();
                    if (tentqx.Items.Count == 1)
                    {
                        try
                        {
                            string s = tentqx.SelectedValue.ToString();
                            tentinh.SelectedValue = s.Substring(0, 3);
                            tenquan.SelectedValue = s.Substring(0, 5);
                            tenpxa.SelectedValue = s;
                            cholam.Focus();
                        }
                        catch { }
                    }
                    else SendKeys.Send("{Tab}{F4}");
                }
            }
        }

        private void mabn2_Validated(object sender, System.EventArgs e)
        {
            mabn2.Text = mabn2.Text.PadLeft(2, '0');
        }

        private void mabn3_Validated(object sender, System.EventArgs e)
        {
            nam = "";
            load_btdnn(0);
            if (bBHYT_QRCode_Dangky == false || (bBHYT_QRCode_Dangky && mathe.Text == ""))
            {
                s_QRcode_sothe = s_QRcode_Hoten = s_QRcode_ngaysinh = s_QRcode_gioitinh = s_QRcode_diachi = s_QRcode_mabv = s_QRcode_tungay = s_QRcode_denngay = s_QRcode_ngaycap = s_QRcode_MaQLBHXH = s_QRcode_KiemTraBHXH = "";
            }
            bNew = true;
            bCapso = false;
            if (bChuyenkhoasan) phai.SelectedIndex = 1;
            if (mabn3.Text == "")
            {
                if (mabn2.Text == "")
                {
                    mabn2.Focus();
                    return;
                }
                if (m.get_capso(s_makp))
                {
                    //bCapso = true;
                    //mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 2, int.Parse(s_makp), true).ToString().PadLeft(6, '0');

                    decimal stt = 0;
                    for (; ; )
                    {
                        stt = m.get_mabn(int.Parse(mabn2.Text), 2, int.Parse(s_makp), true);
                        //stt = m.get_mabns(int.Parse(mabn2.Text), 2, int.Parse(s_makp));
                        if (stt != 0)
                        {
                            //mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');
                            if (i_maxlength_mabn > 8 && bQuanly_Theo_Chinhanh)
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                            else mabn3.Text = stt.ToString().PadLeft(6, '0'); ;
                            iCapso = 2;
                        }
                        else
                        {
                            mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 2, int.Parse(s_makp), true).ToString().PadLeft(i_maxlength_mabn - 2, '0');
                            if (i_maxlength_mabn > 8 && bQuanly_Theo_Chinhanh)
                            {
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + m.get_mabn(int.Parse(mabn2.Text), 2, int.Parse(s_makp), true).ToString().PadLeft(i_maxlength_mabn - 4, '0');
                                //m.upd_mabns(int.Parse(mabn2.Text), 2, int.Parse(s_makp), decimal.Parse(mabn3.Text.Substring(2)));
                            }
                            else
                            {
                                mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 2, int.Parse(s_makp), true).ToString().PadLeft(6, '0');
                                //m.upd_mabns(int.Parse(mabn2.Text), 2, int.Parse(s_makp), decimal.Parse(mabn3.Text));
                            }
                            iCapso = 1;
                        }
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                        //else if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                    }
                    bCapso = true;
                }
                else if ((bMabn_tudong || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text == "")
                {
                    if (mabn2.Text == "")
                    {
                        mabn2.Focus();
                        return;
                    }
                    decimal stt = 0;
                    for (; ; )
                    {
                        iCapso = 0;
                        stt = m.get_mabns(int.Parse(mabn2.Text), 0, 0);
                        if (stt != 0)
                        {
                            if (i_maxlength_mabn > 8 && bQuanly_Theo_Chinhanh)
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                            else
                                mabn3.Text = stt.ToString().PadLeft(6, '0');
                            iCapso = 2;
                        }
                        else
                        {
                            if (i_maxlength_mabn > 8 && bQuanly_Theo_Chinhanh)
                            {
                                mabn3.Text = i_chinhanh.ToString().PadLeft(2, '0') + m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 4, '0');
                                m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text.Substring(2)));
                            }
                            else
                            {
                                mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(6, '0');
                                m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                            }
                            iCapso = 1;
                        }
                        s_mabn = mabn2.Text + mabn3.Text;
                        if (m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                        else if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(stt.ToString()));
                    }
                    if (mabn3.Text == "" || bBHYT_QRCode_Dangky == false || (bBHYT_QRCode_Dangky && mathe.Text == ""))
                    {
                        emp_text(true);
                    }
                }
                else return;
            }
            if (bQuanly_Theo_Chinhanh)
            {
                mabn3.Text = mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
            }
            else
            {
                mabn3.Text = mabn3.Text.PadLeft(6, '0');
            }
            s_mabn = mabn2.Text + mabn3.Text;
            if (bVantay) loadHinhVanTay(s_mabn);//thang
            if (load_mabn())
            {
                if (ngayvv.Text == "")
                {
                    if (load_vv_mabn())
                    {
                        if (!bAdmin && cd_chinh.Text != "" && mabs.Text != "") ena_but(false);
                    }
                    else load_tiepdon(m.Ngayhienhanh, true);
                    s_icd_noichuyenden = icd_noichuyenden.Text;
                    s_icd_chinh = icd_chinh.Text;
                    s_icd_nguyennhan = icd_nguyennhan.Text;
                    s_icd_kemtheo = icd_kemtheo.Text;
                    s_icd_kkb = icd_kkb.Text;
                }
                if (bAdmin)
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
            //else treeView1.Visible=true;
        }

        private bool load_mabn()
        {
            bool ret = false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
            {
                nam = r["nam"].ToString();
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
                ret = true;
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
            try
            {
                if (ret && manuoc.Enabled)
                    foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
                if (nam != "")
                    if (m.get_data_nam_dec(nam, "select * from xxx.benhancc where mabn='" + s_mabn + "' and ngayrv is null").Tables[0].Rows.Count == 1) load_vv_mabn();
            }
            catch { }
            load_diungthuoc();
            load_treeView();
            return ret;
        }

        private void load_tiepdon(string m_ngay, bool skip)
        {
            if (!m.bMmyy(m.mmyy(m_ngay))) return;
            string xxx = user + m.mmyy(m_ngay);
            l_matd = 0;
            sql = "select * from " + xxx + ".tiepdon where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngay + "'";
            sql += " and (done is null or done='?') and noitiepdon in (0,1,5) ";
            sql += " order by ngay desc";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                if (skip)
                {
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                }
                tendoituong.SelectedValue = r["madoituong"].ToString();
                madoituong.Text = r["madoituong"].ToString();
                sovaovien.Text = r["sovaovien"].ToString();
                string stuoi = r["tuoivao"].ToString();
                if (stuoi.Length == 4)
                {
                    tuoi.Text = stuoi.Substring(0, 3);
                    loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
                }
                l_maql = decimal.Parse(r["maql"].ToString());
                l_matd = l_maql;
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
                        if (so.Substring(3, 1) == "1")
                        {
                            manoidk.Text = r["mabv"].ToString();
                            if (manoidk.Text != "") noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
                        }
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                    }
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
            //treeView1.Visible=true;
        }

        private void load_vv_maql(bool skip)
        {
            if (ngayvv.Text == "") return;
            //emp_vv();
            emp_rv();
            ena_but(true);
            DataRow r2;
            string s_xutri = "", xxx = user + m.mmyy(ngayvv.Text);
            foreach (DataRow r in m.get_data("select * from " + xxx + ".benhancc where maql=" + l_maql).Tables[0].Rows)
            {
                if (!skip)
                {
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                }
                l_matd = decimal.Parse(r["mavaovien"].ToString());
                tendentu.SelectedValue = r["dentu"].ToString();
                tennhantu.SelectedValue = r["nhantu"].ToString();
                tendoituong.SelectedValue = r["madoituong"].ToString();
                madoituong.Text = r["madoituong"].ToString();
                sovaovien.Text = r["sovaovien"].ToString();
                icd_kkb.Text = r["maicd"].ToString();
                cd_kkb.Text = r["chandoan"].ToString();
                giuong.Text = r["giuong"].ToString();
                try
                {
                    mabsnb.Text = r["mabsnb"].ToString();
                    r2 = m.getrowbyid(dtbs, "ma='" + mabsnb.Text + "'");
                    if (r2 != null) tenbsnb.Text = r2["hoten"].ToString();
                    else tenbsnb.Text = "";
                }
                catch { MessageBox.Show(lan.Change_language_MessageText("Chạy tạo lại số liệu tháng " + m.mmyy(ngayrv.Text).Substring(0, 2) + " năm " + m.mmyy(ngayvv.Text).Substring(2)), LibMedi.AccessData.Msg); }
                if (r["ngayrv"].ToString() != "")
                {
                    s_ngayrk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                    ngayrv.Text = s_ngayrk.Substring(0, 10);
                    giorv.Text = s_ngayrk.Substring(11);
                    try
                    {
                        songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvv.Text.Substring(0, 10)), 1).ToString();
                    }
                    catch { }
                    tenketqua.SelectedValue = r["ketqua"].ToString();
                    cd_chinh.Text = r["chandoanrv"].ToString();
                    icd_chinh.Text = r["maicdrv"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    r2 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r2 != null) tenbs.Text = r2["hoten"].ToString();
                    else tenbs.Text = "";
                    s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                    if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                    if (s_xutri.IndexOf("05,") != -1 || s_xutri.IndexOf("02,") != -1 || s_xutri.IndexOf("08,") != -1)
                    {
                        sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                        if (s_xutri.IndexOf("08,") != -1) sql += " and loai=1";
                        else if (s_xutri.IndexOf("05,") != -1) sql += " and loai=0 and kehoach>0";
                        if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411

                        sql += " order by makp";
                        tenkhoa.DataSource = m.get_data(sql).Tables[0];
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                    else
                    {
                        tenloaibv.Enabled = mabv.Enabled = tenbv.Enabled = loaibv.Enabled = s_xutri.IndexOf("06,") != -1;
                    }
                    soluutru.Text = r["soluutru"].ToString();
                    giuong.Text = r["giuong"].ToString();
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
                    maxutri.Text = s_xutri;
                    foreach (DataRow r1 in m.get_data("select * from " + xxx + ".cdkemtheo where loai=4 and maql=" + l_maql + " order by stt").Tables[0].Rows)
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
                    foreach (DataRow r3 in m.get_data("select * from " + user + ".cdnguyennhan where maql=" + l_maql).Tables[0].Rows)//gam 17/03/2012
                    {
                        cd_nguyennhan.Text = r3["chandoan"].ToString();
                        icd_nguyennhan.Text = r3["maicd"].ToString();
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
            DataRow r1;
            if (nam == "") return false;
            string s_xutri = "", xxx = user + nam.Substring(nam.Length - 5, 4);
            foreach (DataRow r in m.get_data("select * from " + xxx + ".benhancc where mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
            {
                l_matd = decimal.Parse(r["mavaovien"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
                tendentu.SelectedValue = r["dentu"].ToString();
                tennhantu.SelectedValue = r["nhantu"].ToString();
                tendoituong.SelectedValue = r["madoituong"].ToString();
                madoituong.Text = r["madoituong"].ToString();
                sovaovien.Text = r["sovaovien"].ToString();
                icd_kkb.Text = r["maicd"].ToString();
                cd_kkb.Text = r["chandoan"].ToString();
                try
                {
                    mabsnb.Text = r["mabsnb"].ToString();
                    r1 = m.getrowbyid(dtbs, "ma='" + mabsnb.Text + "'");
                    if (r1 != null) tenbsnb.Text = r1["hoten"].ToString();
                    else tenbsnb.Text = "";
                }
                catch { MessageBox.Show(lan.Change_language_MessageText("Chạy tạo lại số liệu tháng ") + m.mmyy(ngayrv.Text).Substring(0, 2) + lan.Change_language_MessageText(" năm ") + m.mmyy(ngayvv.Text).Substring(2), LibMedi.AccessData.Msg); }

                if (r["ngayrv"].ToString() != "")
                {
                    s_ngayrk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                    ngayrv.Text = s_ngayrk.Substring(0, 10);
                    giorv.Text = s_ngayrk.Substring(11);
                    try
                    {
                        songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvv.Text.Substring(0, 10)), 1).ToString();
                    }
                    catch { }
                    tenketqua.SelectedValue = r["ketqua"].ToString();
                    cd_chinh.Text = r["chandoanrv"].ToString();
                    icd_chinh.Text = r["maicdrv"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                    s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                    if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                    if (s_xutri.IndexOf("05,") != -1 || s_xutri.IndexOf("02,") != -1 || s_xutri.IndexOf("08,") != -1)
                    {
                        sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                        if (s_xutri.IndexOf("08,") != -1) sql += " and loai=1";
                        else if (s_xutri.IndexOf("05,") != -1) sql += " and loai=0";
                        if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
                        sql += " order by makp";
                        tenkhoa.DataSource = m.get_data(sql).Tables[0];
                        khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        tenkhoa.SelectedValue = khoa.Text;
                        khoa.Enabled = true;
                        tenkhoa.Enabled = true;
                    }
                    soluutru.Text = r["soluutru"].ToString();
                    giuong.Text = r["giuong"].ToString();
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
                    maxutri.Text = s_xutri;
                    foreach (DataRow r2 in m.get_data("select * from " + xxx + ".cdkemtheo where loai=4 and maql=" + l_maql + " order by stt").Tables[0].Rows)
                    {
                        cd_kemtheo.Text = r2["chandoan"].ToString();
                        icd_kemtheo.Text = r2["maicd"].ToString();
                        break;
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
                    break;
                }
                else s_ngayrk = ngayrv.Text;
            }
            load_vv();
            return l_maql != 0;
        }

        private void load_vv()
        {
            emp_bhyt();
            string xxx = user + m.mmyy(ngayvv.Text);
            foreach (DataRow r in m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0].Rows)
            {
                quanhe.Text = r["quanhe"].ToString();
                qh_hoten.Text = r["hoten"].ToString();
                qh_diachi.Text = r["diachi"].ToString();
                qh_dienthoai.Text = r["dienthoai"].ToString();
            }
            string stuoi = m.get_tuoivao(l_maql).Trim();
            if (stuoi.Length == 4)
            {
                tuoi.Text = stuoi.Substring(0, 3);
                loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
            }
            if (tendoituong.SelectedIndex != -1)
            {
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
                        if (so.Substring(3, 1) == "1")
                        {
                            manoidk.Text = r["mabv"].ToString();
                            if (manoidk.Text != "") noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
                        }
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                    }
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
            if (dentu.Text == "1")
            {
                try
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
                    {
                        cd_noichuyenden.Text = r["chandoan"].ToString();
                        icd_noichuyenden.Text = r["maicd"].ToString();
                        madstt.Text = r["mabv"].ToString();
                        tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                }
                catch { }
            }
            if (pmat.Visible)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ttmat where maql=" + l_maql).Tables[0].Rows)
                {
                    mp.Text = r["mp"].ToString();
                    mt.Text = r["mt"].ToString();
                    nhanapp.Text = r["nhanapp"].ToString();
                    nhanapt.Text = r["nhanapt"].ToString();
                    break;
                }
            }
            else lydo.Text = m.get_lydokham(ngayvv.Text, l_maql).ToString().Trim();
            if (dausinhton.Visible)
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
                {
                    mach.Text = r["mach"].ToString();
                    nhietdo.Text = r["nhietdo"].ToString();
                    huyetap.Text = r["huyetap"].ToString();
                    break;
                }
            }
            if (trieuchung.Enabled) trieuchung.Text = m.get_trieuchung(ngayvv.Text, l_maql).ToString().Trim();
            //treeView1.Visible=true;
            load_phauthuat();
            load_tainantt();
            if (iChidinh < 4)
            {
                load_chidinh();
                load_vienphi();
            }
            load_thuocdan();
            load_baohiem();
        }

        private void ngaysinh_Validated(object sender, System.EventArgs e)
        {
            if (ngaysinh.Text == "") return;
            ngaysinh.Text = ngaysinh.Text.Trim();
            if (!m.bNgay(ngaysinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
                ngaysinh.Focus();
                return;
            }
            ngaysinh.Text = m.Ktngaygio(ngaysinh.Text, 10);
            if (!m.bNgay("", ngaysinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
                ngaysinh.Focus();
                return;
            }
            try
            {
                string tuoivao = m.Tuoivao("", ngaysinh.Text);
                tuoi.Text = tuoivao.Substring(2).PadLeft(3, '0');
                loaituoi.SelectedIndex = int.Parse(tuoivao.Substring(0, 1));
                namsinh.Text = m.Namsinh(ngaysinh.Text).ToString();
                if (int.Parse(tuoi.Text) > m.iTuoi_nguoibenh && loaituoi.SelectedIndex == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"), LibMedi.AccessData.Msg);
                    ngaysinh.Focus();
                    return;
                }
                if (tuoi.Text == "000")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"), s_msg);
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
            catch { }
        }

        private void namsinh_Validated(object sender, System.EventArgs e)
        {
            if (namsinh.Text != "")
            {
                if (int.Parse(namsinh.Text) > DateTime.Now.Year)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"), LibMedi.AccessData.Msg);
                    namsinh.Focus();
                    return;
                }
                if (namsinh.Text.Length < 4) namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
                tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                loaituoi.SelectedIndex = 0;
                if (int.Parse(tuoi.Text) > m.iTuoi_nguoibenh)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"), LibMedi.AccessData.Msg);
                    namsinh.Focus();
                    return;
                }
                if (tuoi.Text == "000")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"), s_msg);
                    tuoi.Focus();
                    return;
                }
                if (!load_tim_mabn())
                {
                    if (phai.Enabled) { phai.Focus(); }
                    else mann.Focus();
                }
            }
        }

        private void tuoi_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (int.Parse(tuoi.Text) == 0) ngaysinh.Focus();
            }
            catch { ngaysinh.Focus(); }
        }

        private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                hoten.Text = m.Viettat(hoten.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{Home}");
        }

        private void thon_Validated(object sender, System.EventArgs e)
        {
            thon.Text = m.Caps(thon.Text);
        }

        private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                thon.Text = m.Viettat(thon.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cholam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cholam.Text = m.Viettat(cholam.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{Home}");
        }

        private void cholam_Validated(object sender, System.EventArgs e)
        {
            cholam.Text = m.Caps(cholam.Text);
        }

        private void frmPhongluu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2://thang
                    if (bVantay) lay_mabn_vantay();
                    break;
                case Keys.F3:
                    l_thuocbhyt_Click(sender, e);
                    break;
                case Keys.F5:
                    l_thuocdan_Click(sender, e);
                    break;
                case Keys.F6:
                    l_phauthuat_Click(sender, e);
                    break;
                case Keys.F7:
                    l_chidinh_Click(sender, e);
                    break;
                case Keys.F8:
                    l_vienphi_Click(sender, e);
                    break;
                case Keys.F9:
                    l_tainantt_Click(sender, e);
                    break;
                case Keys.F10:
                    l_tutruc_Click(sender, e);
                    break;
                case Keys.F11:
                    l_kemtheo_Click(sender, e);
                    break;
                case Keys.F12:
                    l_cls_Click(sender, e);
                    break;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        l_diungthuoc_Click(sender, e);
                        break;
                    case Keys.L:
                        break;
                }

            }

        }

        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            m.close(); this.Close();
        }

        private void dentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tendentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tendentu.SelectedIndex == -1) tendentu.SelectedIndex = 0;
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void tendentu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                dentu.Text = tendentu.SelectedValue.ToString();
                if (m.bChandoan) cd_noichuyenden.Enabled = dentu.Text == "1";
                icd_noichuyenden.Enabled = dentu.Text == "1";
                madstt.Enabled = icd_noichuyenden.Enabled;
                tendstt.Enabled = madstt.Enabled;
            }
            catch { dentu.Text = ""; }
        }

        private void dentu_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tendentu.SelectedValue = dentu.Text;
            }
            catch { }
        }

        private void nhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void nhantu_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tennhantu.SelectedValue = nhantu.Text;
            }
            catch { }

        }

        private void tennhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tennhantu.SelectedIndex == -1) tennhantu.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tennhantu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                nhantu.Text = tennhantu.SelectedValue.ToString();
            }
            catch { nhantu.Text = ""; }
        }

        private void madoituong_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tendoituong.SelectedValue = madoituong.Text;
            }
            catch { }
        }

        private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tendoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tendoituong.SelectedIndex == -1) tendoituong.SelectedIndex = 0;
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                denngay.Enabled = so.Substring(2, 1) == "1";
                if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                else tungay.Enabled = false;
                noidk.Enabled = so.Substring(3, 1) == "1";
                traituyen.Enabled = noidk.Enabled;
                //tenbv.Enabled=mabv.Enabled;
                if (int.Parse(so.Substring(0, 2)) > 0)
                    SendKeys.Send("{Tab}");
                else
                    sovaovien.Focus();

            }
        }

        private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tendoituong)
            {
                try
                {
                    madoituong.Text = tendoituong.SelectedValue.ToString();
                    string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                    if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0)
                    {
                        load_bhyt();
                    }
                    sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                    butDateBHYT.Enabled = (int.Parse(so.Substring(0, 2)) > 0 && bSothe_ngay_huong);//gam 07/09/2011
                    denngay.Enabled = so.Substring(2, 1) == "1";
                    if (bTungay && denngay.Enabled) tungay.Enabled = denngay.Enabled;
                    else tungay.Enabled = false;
                    manoidk.Enabled = noidk.Enabled = so.Substring(3, 1) == "1";
                    //tenbv.Enabled=mabv.Enabled;
                }
                catch { tendoituong.SelectedIndex = 0; }
            }
        }

        private void load_bhyt()
        {
            if (nam == "") return;
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (int.Parse(so.Substring(0, 2)) > 0 && ngayvv.Text != "")
            {
                s_mabn = mabn2.Text + mabn3.Text;
                if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                    sql = "select * from xxx.bhyt where mabn='" + s_mabn + "'" + " and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                else
                    sql = "select * from xxx.bhyt where mabn='" + s_mabn + "' order by maql desc";
                DataSet dstemp = m.get_data_nam_dec(nam, sql);
                if (dstemp != null)
                {
                    foreach (DataRow r in dstemp.Tables[0].Rows)
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
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
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
                        if (so.Substring(3, 1) == "1") manoidk.Text = r["mabv"].ToString();
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        traituyen.SelectedIndex = int.Parse(r["traituyen"].ToString());
                        break;
                    }
                }
                try
                {
                    if (so.Substring(3, 1) == "1")
                    {
                        if (manoidk.Text == "") manoidk.Text = m.Mabvbhyt;
                        noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                }
                catch { }
            }
            else
            {
                ngay1 = ngay2 = ngay3 = tungay.Text = sothe.Text = denngay.Text = manoidk.Text = noidk.Text = "";
                traituyen.SelectedIndex = 0;
            }
        }

        private void mabs_Validated(object sender, System.EventArgs e)
        {
            if (mabs.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r != null) tenbs.Text = r["hoten"].ToString();
                else tenbs.Text = "";
            }
        }

        private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void loaibv_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenloaibv.SelectedValue = loaibv.Text;
            }
            catch { }
        }

        private void loaibv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tenloaibv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenloaibv.SelectedIndex == -1) tenloaibv.SelectedIndex = 0;
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void tenloaibv_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                loaibv.Text = tenloaibv.SelectedValue.ToString();
            }
            catch
            {
                loaibv.Text = "";
                tenbv.SelectedIndex = -1;
            }
        }

        private void mabv_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (mabv.Text == "")
                {
                    frmDmbv f = new frmDmbv(m, mabv.Text, loaibv.Text, true);
                    f.ShowDialog();
                    if (f.m_mabv != "")
                    {
                        mabv.Text = f.m_mabv;
                        load_mabv(loaibv.Text);
                        tenbv.SelectedValue = mabv.Text;
                    }
                }
                else if (mabv.Text != s_mabv)
                {
                    if (mabv.Text == m.Mabv)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"), s_msg);
                        mabv.Text = "";
                        return;
                    }
                    load_mabv(loaibv.Text);
                    tenbv.SelectedValue = mabv.Text;
                    if (tenbv.Items.Count == 0)
                    {
                        frmDmbv f = new frmDmbv(m, mabv.Text, loaibv.Text, true);
                        f.ShowDialog();
                        if (f.m_mabv != "")
                        {
                            mabv.Text = f.m_mabv;
                            load_mabv(loaibv.Text);
                            tenbv.SelectedValue = mabv.Text;
                        }
                    }
                    s_mabv = mabv.Text;
                    SendKeys.Send("{F4}");
                }
            }
            catch { }
        }

        private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tenbv.SelectedIndex == -1) tenbv.SelectedIndex = 0;
                    if (loaibv.Text != "3" && m.get_data("select maloai from " + user + ".tenvien where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString().Substring(0, 1) == "2")
                        tenloaibv.SelectedValue = "3";
                }
                catch { }
                SendKeys.Send("{Tab}");
            }
        }

        private void tenbv_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                mabv.Text = tenbv.SelectedValue.ToString();
            }
            catch { mabv.Text = ""; }
        }

        private void quanhe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                quanhe.Text = m.Viettat(quanhe.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (quanhe.Text == "")
                {
                    if (icd_noichuyenden.Enabled) icd_noichuyenden.Focus();
                    else if (trieuchung.Enabled) trieuchung.Focus();
                    else icd_kkb.Focus();
                    SendKeys.Send("{Home}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void quanhe_Validated(object sender, System.EventArgs e)
        {
            quanhe.Text = m.Caps(quanhe.Text);
        }

        private void qh_hoten_Validated(object sender, System.EventArgs e)
        {
            qh_hoten.Text = m.Caps(qh_hoten.Text);
        }

        private void qh_hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                qh_hoten.Text = m.Viettat(qh_hoten.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (qh_diachi.Text == "") qh_diachi.Text = lan.Change_language_MessageText("Cùng địa chỉ");
                SendKeys.Send("{Tab}");
            }
        }

        private void qh_diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                qh_diachi.Text = m.Viettat(qh_diachi.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void qh_diachi_Validated(object sender, System.EventArgs e)
        {
            qh_diachi.Text = m.Caps(qh_diachi.Text);
        }

        private void cd_noichuyenden_Validated(object sender, System.EventArgs e)
        {
            if (icd_noichuyenden.Text == "") icd_noichuyenden.Text = m.get_cicd10(cd_noichuyenden.Text);
            if (!m.bMaicd(icd_noichuyenden.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"), s_msg);
                icd_noichuyenden.Text = "";
                icd_noichuyenden.Focus();
            }
        }

        private void icd_noichuyenden_Validated(object sender, System.EventArgs e)
        {
            if (icd_noichuyenden.Text != s_icd_noichuyenden)
            {
                if (icd_noichuyenden.Text == "") cd_noichuyenden.Text = "";
                else cd_noichuyenden.Text = m.get_vviet(icd_noichuyenden.Text);
                if (cd_noichuyenden.Text == "" && icd_noichuyenden.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_noichuyenden.Text, cd_noichuyenden.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_noichuyenden.Text = f.mTen;
                        icd_noichuyenden.Text = f.mICD;
                    }
                }
                s_icd_noichuyenden = icd_noichuyenden.Text;
            }
        }

        private void cd_chinh_Validated(object sender, System.EventArgs e)
        {
            if (icd_chinh.Text == "") icd_chinh.Text = m.get_cicd10(cd_chinh.Text);
            if (!m.bMaicd(icd_chinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"), s_msg);
                icd_chinh.Text = "";
                icd_chinh.Focus();
            }
        }

        private void icd_chinh_Validated(object sender, System.EventArgs e)
        {
            if (icd_chinh.Text == "" && !cd_chinh.Enabled)
            {
                cd_chinh.Text = "";
                butLuu.Focus();
                return;
            }
            else if (icd_chinh.Text != s_icd_chinh)
            {
                cd_chinh.Text = m.get_vviet(icd_chinh.Text);
                if (cd_chinh.Text == "" && icd_chinh.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_chinh.Text = f.mTen;
                        icd_chinh.Text = f.mICD;
                    }
                }
                s_icd_chinh = icd_chinh.Text;
            }
        }

        private void cd_kemtheo_Validated(object sender, System.EventArgs e)
        {
            if (icd_kemtheo.Text == "") icd_kemtheo.Text = m.get_cicd10(cd_kemtheo.Text);
            if (!m.bMaicd(icd_kemtheo.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"), s_msg);
                icd_kemtheo.Text = "";
                icd_kemtheo.Focus();
            }
        }

        private void icd_kemtheo_Validated(object sender, System.EventArgs e)
        {
            if (icd_kemtheo.Text != s_icd_kemtheo)
            {
                if (icd_kemtheo.Text == "") cd_kemtheo.Text = "";
                else cd_kemtheo.Text = m.get_vviet(icd_kemtheo.Text);
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
                s_icd_kemtheo = icd_kemtheo.Text;
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
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (sothe.Text != "")
            {
                //Tu:22/08/2011 kiểm tra số thẻ hợp lệ theo qui định của BHYT dựa vào option E28(true)
                if (!m.bKiemtrasothehople(sothe.Text))
                {
                    MessageBox.Show("Số thẻ không hợp lệ. Đề nghị kiểm tra kĩ lại !");
                    sothe.Focus();
                    return;
                }
                //
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
            }
            if (sothe.Text == "" || so.Substring(0, 2) == "00") tendoituong.Focus();
            else if (m.sothe(int.Parse(tendoituong.SelectedValue.ToString()), sothe.Text))
            {
                tungay.Focus();//gam 28/09/2011
                return;
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
                sothe.Focus();
            }

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
        }

        private void emp_text(bool skip)
        {
            ena_but(true);
            if (!skip)
            {
                mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
                mabn3.Text = "";
            }
            tendoituong.Enabled = madoituong.Enabled = true;
            loaituoi.SelectedIndex = 0;
            hoten.Text = "";
            ngaysinh.Text = "";
            namsinh.Text = "";
            tuoi.Text = "";
            sonha.Text = "";
            thon.Text = "";
            cholam.Text = "";
            tentqx.SelectedIndex = -1;
            tenkhoa.SelectedIndex = -1;
            tqx.Text = "";
            l_maql = 0;
            l_matd = 0;
            b_Edit = false;
            tentinh.SelectedValue = m.Mabv.Substring(0, 3);
            tendantoc.SelectedValue = "25";
            tennuoc.SelectedValue = "VN";
            treeView1.Nodes.Clear();
            //ref_check();
            load_quan();
            load_pxa();
            emp_vv();
            if (mabn3.Text == "" || bBHYT_QRCode_Dangky == false || (bBHYT_QRCode_Dangky && mathe.Text == ""))
            {                
                emp_bhyt();
            }
            emp_rv();
            //            
            //
            if (pic.Visible)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(fstr));
                pic.Image = (System.Drawing.Bitmap)map;
            }
            //gam 07/09/2011 
            s_tungay1 = s_tungay2 = s_tungay3 = "";
            //end gam
        }


        private void emp_bhyt()
        {
            ngay1 = ngay2 = ngay3 = tungay.Text = sothe.Text = denngay.Text = manoidk.Text = noidk.Text = "";
            traituyen.SelectedIndex = 0;
        }

        private void emp_vv()
        {
            string s = m.Ngaygio;
            ngayvv.Text = s.Substring(0, 10);
            giovv.Text = s.Substring(11);
            s_ngayvv = "";
            tendentu.SelectedIndex = 1;
            tennhantu.SelectedIndex = 1;
            if (bBHYT_QRCode_Dangky == false || (bBHYT_QRCode_Dangky && mathe.Text == ""))
            {
                tendoituong.SelectedIndex = -1;
                madoituong.Text = "";
                manoidk.Text = ""; noidk.Text = "";
            }
            quanhe.Text = "";
            qh_hoten.Text = "";
            qh_diachi.Text = "";
            trieuchung.Text = qh_dienthoai.Text = "";
            sovaovien.Text = "";
            mach.Text = ""; nhietdo.Text = ""; huyetap.Text = "";
            soluutru.Text = "";
            cd_noichuyenden.Text = "";
            icd_noichuyenden.Text = "";
            cd_kkb.Text = "";
            icd_kkb.Text = "";
            mabsnb.Text = tenbsnb.Text = "";
            s_icd_noichuyenden = "";
            s_icd_kkb = "";
            madstt.Text = "";
            tendstt.Text = "";
            para1.Text = ""; para2.Text = "";
            para3.Text = ""; para4.Text = "";
            if (pmat.Visible)
            {
                mp.Text = ""; mt.Text = "";
                nhanapp.Text = ""; nhanapt.Text = "";
            }
            else lydo.Text = "";
        }

        private void emp_rv()
        {
            mabs.Text = ""; tenbs.Text = "";
            string s = m.ngayhienhanh_server;
            ngayrv.Text = s.Substring(0, 10);
            giorv.Text = s.Substring(11);
            s_ngayrk = "";
            giuong.Text = "";
            cd_chinh.Text = "";
            icd_chinh.Text = "";
            s_icd_chinh = "";
            s_icd_nguyennhan = "";
            cd_nguyennhan.Text = "";
            icd_nguyennhan.Text = "";
            cd_kemtheo.Text = "";
            icd_kemtheo.Text = "";
            s_icd_kemtheo = "";
            bienchung.Checked = false;
            taibien.Checked = false;
            giaiphau.Checked = false;
            tenloaibv.SelectedIndex = -1;
            tenbv.SelectedIndex = -1;
            tenkhoa.SelectedIndex = -1;
            tenketqua.SelectedIndex = -1;
            ketqua.Text = "";
            khoa.Text = "";
            maxutri.Text = s_mabv = "";
            for (int i = 0; i < xutri.Items.Count; i++) xutri.SetItemCheckState(i, CheckState.Unchecked);
            if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text;
            else soluutru.Text = "";
        }

        private void butTiep_Click(object sender, System.EventArgs e)
        {
            mathe.Enabled = bBHYT_QRCode_Dangky || (bSothe_dmbhyt && chkBhyt.Checked);
            ptb.Image = null;
            ptb.Refresh();
            fnhandang = null;
            mathe.Text = "";
            mathe.Enabled = bBHYT_QRCode_Dangky;
            s_QRcode_sothe = s_QRcode_Hoten = s_QRcode_ngaysinh = s_QRcode_gioitinh = s_QRcode_diachi = s_QRcode_mabv = s_QRcode_tungay = s_QRcode_denngay = s_QRcode_ngaycap = s_QRcode_MaQLBHXH = s_QRcode_KiemTraBHXH = "";
            emp_text(false);
            if ((bSothe_dmbhyt && chkBhyt.Checked) || bBHYT_QRCode_Dangky) mathe.Focus();
            else mabn2.Focus();

        }

        private bool kiemtra(bool chiphi)
        {
            if (mabn2.Text == "" || mabn3.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"), s_msg);
                mabn2.Focus();
                return false;
            }

            if (mann.Text == "" || tennn.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"), s_msg);
                mann.Focus();
                return false;
            }
            if (hoten.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"), s_msg);
                hoten.Focus();
                return false;
            }

            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;

            if (dentu.Text == "1")
            {
                if (madstt.Text == "" || tendstt.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập tên cơ quan y tế !"), s_msg);
                    madstt.Focus();
                    return false;
                }
                if (icd_noichuyenden.Text == "" || cd_noichuyenden.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"), s_msg);
                    icd_noichuyenden.Focus();
                    return false;
                }
                else if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nơi chuyển đến !"), s_msg);
                    icd_noichuyenden.Focus();
                    return false;
                }
                else if (cd_noichuyenden.Text == "" && icd_noichuyenden.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán nơi chuyển đến !"), s_msg);
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

            if (namsinh.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"), s_msg);
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
            if (bBNPhongluu_nhapnguoithan && (quanhe.Text.Trim() == "" || qh_hoten.Text.Trim() == ""))
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
                if (tennuoc.SelectedValue.ToString() == "VN" && tendantoc.SelectedValue.ToString() == "55")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Quốc tịch không hợp lệ !"), LibMedi.AccessData.Msg);
                    tennuoc.Focus();
                    return false;
                }
            }

            if (b_Hoten)
            {
                if ((hoten.Text.Trim().IndexOf(" VĂN ") != -1 && phai.SelectedIndex == 1) || (hoten.Text.Trim().IndexOf(" THỊ ") != -1 && phai.SelectedIndex == 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Họ tên và giới tính không hợp lệ !"), LibMedi.AccessData.Msg);
                    if (phai.Enabled) phai.Focus();
                    else hoten.Focus();
                    return false;
                }
            }

            if (tuoi.Text == "" || loaituoi.SelectedIndex == -1)
            {
                if (namsinh.Text.Length < 4) namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
                tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                loaituoi.SelectedIndex = 0;
            }
            else
            {
                if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Tuổi và năm sinh không hợp lệ") + "\n" + lan.Change_language_MessageText("Bạn có muốn chương trình tính lại không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ngaysinh.Text = "";
                        namsinh.Text = m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString();
                    }
                    else
                    {
                        if (ngaysinh.Text != "") ngaysinh.Focus();
                        else namsinh.Focus();
                        return false;
                    }
                }
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
            if (ngayvv.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào !"), s_msg);
                ngayvv.Focus();
                return false;
            }

            if (tennhantu.SelectedIndex == -1 || nhantu.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập trực tiếp vào !"), s_msg);
                nhantu.Focus();
                return false;
            }

            if (tendentu.SelectedIndex == -1 || dentu.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập nơi giới thiệu !"), s_msg);
                dentu.Focus();
                return false;
            }

            if (madoituong.Text == "" || tendoituong.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập đối tượng !"), s_msg);
                tendoituong.Focus();
                return false;
            }
            else
            {
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                if (int.Parse(so.Substring(0, 2)) > 0)
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
                    if (so.Substring(3, 1) == "1" && (manoidk.Text == "" || noidk.Text == ""))
                    {
                        noidk.Focus();
                        return false;
                    }
                    if (so.Substring(3, 1) == "1")
                    {
                        if (m.get_data("select * from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows.Count == 0)
                        {
                            manoidk.Text = "";
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

            if (tentinh.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"), s_msg);
                tentinh.Focus();
                return false;
            }

            if (tenquan.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"), s_msg);
                tenquan.Focus();
                return false;
            }

            if (tenpxa.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"), s_msg);
                tenpxa.Focus();
                return false;
            }

            if (madantoc.Text == "" || tendantoc.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn dân tộc !"), s_msg);
                tendantoc.Focus();
                return false;
            }

            if (tennuoc.SelectedIndex == -1 && tennuoc.Enabled)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn quốc tịch !"), s_msg);
                tennuoc.Focus();
                return false;
            }

            if (icd_kkb.Text == "" && cd_kkb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return false;
            }
            else if (icd_kkb.Text == "" && cd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh vào !"), s_msg);
                icd_kkb.Focus();
                return false;
            }
            else if (cd_kkb.Text == "" && icd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh vào !"), s_msg);
                if (cd_kkb.Enabled) cd_kkb.Focus();
                else icd_kkb.Focus();
                return false;
            }
            if (!m.Kiemtra_maicd(dticd, icd_kkb.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                icd_kkb.Focus();
                return false;
            }
            if (!m.Kiemtra_tenbenh(dticd, cd_kkb.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                cd_kkb.Focus();
                return false;
            }
            if (mabsnb.Text == "" || tenbsnb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ nhận bệnh !"), s_msg);
                mabsnb.Focus();
                return false;
            }
            s_chonxutri = chon_xutri();
            if (s_chonxutri != "")
            {
                if ((s_chonxutri.IndexOf("06,") != -1 && (s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("08,") != -1)) || (s_chonxutri.IndexOf("07,") != -1 && s_chonxutri.Length > 3))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chọn xử trí không hợp lệ !"), LibMedi.AccessData.Msg);
                    xutri.Focus();
                    return false;
                }
                else if (f_kiemtra_xutri_hople(s_chonxutri))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xử trí không hợp lệ !"), s_msg);
                    xutri.Focus();
                    return false;
                }
            }
            if ((ngayrv.Text != "" && icd_chinh.Text != "" && cd_chinh.Text != "") || (s_chonxutri != ""))
            {
                if (s_chonxutri == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí !"), s_msg);
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
                if (!m.Kiemtra_maicd(dticd, icd_chinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"), LibMedi.AccessData.Msg);
                    icd_chinh.Focus();
                    return false;
                }
                if (!m.Kiemtra_tenbenh(dticd, cd_chinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"), LibMedi.AccessData.Msg);
                    cd_chinh.Focus();
                    return false;
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
                if (icd_nguyennhan.Text == "" && cd_nguyennhan.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập mã ICD bệnh nguyên nhân !"), s_msg);
                    icd_nguyennhan.Focus();
                    return false;
                }
                else if (icd_nguyennhan.Text != "" && cd_nguyennhan.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập chẩn đoán bệnh nguyên nhân !"), s_msg);
                    cd_nguyennhan.Focus();
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
                if (mabs.Text == "" || tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                    mabs.Focus();
                    return false;
                }

                if (ketqua.Text == "" || tenketqua.SelectedIndex == -1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chọn kết quả điều trị !"), s_msg);
                    ketqua.Focus();
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

                if (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1)
                {
                    if (tenkhoa.SelectedIndex == -1 || khoa.Text == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập vào khoa !"), s_msg);
                        khoa.Focus();
                        return false;
                    }
                }

                //
                if (s_chonxutri.IndexOf("05,") != -1)
                {
                    string s_chuathanhtoan = m.f_ngaychuathanhtoan(s_mabn);
                    if (s_chuathanhtoan != "")
                    {
                        if (bChuathanhtoan_khongcho_nhanbenh)
                        {
                            MessageBox.Show(s_chuathanhtoan + "\nĐề nghị Bệnh nhân làm thủ tục thanh toán ra viện đợt trước, trước khi nhập viện.");
                            return false;
                        }
                        else
                        {
                            MessageBox.Show(s_chuathanhtoan);
                        }
                    }
                }
                //
            }
            if (namsinh.Text != "" && mann.Text != "")
            {
                if (!m.Kiemtra_mann(mann.Text, DateTime.Now.Year - int.Parse(namsinh.Text), iTreem6, iTreem15))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nghề nghiệp và độ tuổi không hợp lệ !"), LibMedi.AccessData.Msg);
                    mann.Focus();
                    return false;
                }
            }
            if (soluutru.Text == "" && b_soluutru && soluutru.Enabled)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập số lưu trữ !"), s_msg);
                soluutru.Focus();
                return false;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            if (m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false) == 0)
            {
                if (m.bTuvong(mabn2.Text + mabn3.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                }
                string msg = "";
                sql = "select c.loaiba,b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".hiendien a," + user + ".btdkp_bv b," + user + ".benhandt c where a.maql=c.maql and a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and c.loaiba in (1)";//2
                sql += " and a.mabn='" + s_mabn + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)


                    msg = lan.Change_language_MessageText("ĐANG ĐIỀU TRỊ") + " " + ((r["loaiba"].ToString() == "1") ? lan.Change_language_MessageText("NỘI TRÚ") + " " : lan.Change_language_MessageText("NGOẠI TRÚ")) + lan.Change_language_MessageText("TẠI") + " " + r["tenkp"].ToString().Trim().ToUpper() + " " + lan.Change_language_MessageText("NGÀY") + " " + r["ngay"].ToString();
                if (msg != "")
                {
                    MessageBox.Show(msg, s_msg);
                    ngayvv.Focus();
                    return false;
                }
            }
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
            if (ngayrv.Text != "" && s_chonxutri != "" && icd_chinh.Text != "" && cd_chinh.Text != "" && m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false) == 0)
            {
                if (s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru)
                {
                    string s_tenkp = m.bHiendien_benhanngtr(s_mabn);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        xutri.Focus();
                        return false;
                    }
                }
                if (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru) //noi tru
                {
                    string s_tenkp = m.bHiendien(s_mabn, 1);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        xutri.Focus();
                        return false;
                    }
                    else
                    {
                        s_tenkp = m.bNhapvien(s_mabn, 1);
                        if (s_tenkp != "")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                            xutri.Focus();
                            return false;
                        }
                    }
                }
                else if (f_kiemtra_xutri_hople(s_chonxutri))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xử trí không hợp lệ !"), s_msg);
                    xutri.Focus();
                    return false;
                }
            }
            if (khamthai.Visible)
            {
                if (phai.SelectedIndex == 0 && (para1.Text + para2.Text + para3.Text + para4.Text != ""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Giới tính không hợp lệ !"), s_msg);
                    phai.Focus();
                    return false;
                }
            }
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe.Text != "")
                {
                    string s = "";
                    s = m.mabn_bhyt_ngayhethan(mabn2.Text + mabn3.Text, sothe.Text,denngay.Text);//tim trong medibv goc
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
            if (bPhonggiuong && giuong.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn phòng/giường !"), LibMedi.AccessData.Msg);
                butPhong.Focus();
                return false;
            }
            if (m.get_maql_benhancc(mabn2.Text + mabn3.Text, ngayvv.Text + " " + giovv.Text, false) == 0)
            {
                string s_tenkp = m.bHiendien_benhancc(ngayvv.Text + " " + giovv.Text, mabn2.Text + mabn3.Text);
                if (s_tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                    butBoqua_Click(null, null);
                    return false;
                }
            }
            else if (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru && !chiphi)
            {
                DataTable tmp = m.get_data("select b.tenkp from " + user + ".hiendien a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + mabn2.Text + mabn3.Text + "' and a.nhapkhoa=1 and a.xuatkhoa=0").Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh ") + hoten.Text + lan.Change_language_MessageText(" đã nhập vào ") + tmp.Rows[0]["tenkp"].ToString(), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                    return false;
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
        }

        private string chon_xutri()
        {
            string s = "";
            for (int i = 0; i < xutri.Items.Count; i++)
                if (xutri.GetItemChecked(i)) s += dtxutri.Rows[i]["ma"].ToString().Trim().PadLeft(2, '0') + ",";
            maxutri.Text = s;
            return s;
        }

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            bUpdate = true;
            if (bVantay && ma_vantay == "") luu_vantay();//thang
            if (!kiemtra((sender == null) ? true : false)) return;
            int p = 0; string s_ttlucrv = "1";
            if (s_chonxutri != "")
            {
                p = s_chonxutri.IndexOf(",");
                s_ttlucrv = s_chonxutri.Substring(0, p);
            }
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');/////////////////////////////////////////
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            l_idcdnguyennhan = m.get_id(l_maql, s_makp, ngayvv.Text + " " + giovv.Text);
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            //if (bCapso)  m.upd_capmabn(int.Parse(mabn2.Text),2,int.Parse(s_makp),int.Parse(mabn3.Text));
            itable = m.tableid(m.mmyy(ngayvv.Text), "benhancc");
            if (m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + s_makp + "^" + ngayvv.Text + " " + giovv.Text + "^" + dentu.Text + "^" + nhantu.Text + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_kkb.Text + "^" + icd_kkb.Text + "^" + sovaovien.Text + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            bool bNew = false;
            decimal idgiuong = 0;
            if (bPhonggiuong)
            {
                bNew = m.get_data("select maql from " + user + m.mmyy(ngayvv.Text) + ".benhancc where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngayvv.Text + " " + giovv.Text + "'").Tables[0].Rows.Count == 0;
                if (bNew)
                {
                    l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, true);
                    if (l_matd == 0)
                    {
                        if (m.bTiepdon_nkp_inchungchiphi) l_matd = m.get_tiepdon_phongluu(s_mabn, ngayvv.Text);
                        else l_matd = m.get_tiepdon_phongluu(s_mabn, ngayvv.Text + " " + giovv.Text);
                        if (l_matd == 0)
                        {
                            l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                            m.upd_tiepdon(s_mabn, l_matd, l_matd, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Phongluu, 0);//bi061009
                        }
                        m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Phongluu, l_maql);
                    }
                    DataRow r2, r1 = m.getrowbyid(dtg, "ma='" + giuong.Text + "'");
                    string fie = "gia_th";
                    decimal id = v.get_id_vpkhoa;
                    int _madoituong = int.Parse(madoituong.Text);
                    if (r1 != null)
                    {
                        if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r1["dichvu"].ToString() == "1") ? madoituong_giuongdichvu : int.Parse(madoituong.Text);
                        r2 = m.getrowbyid(dtdt, "madoituong=" + _madoituong);
                        if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                        decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        idgiuong = decimal.Parse(r1["id"].ToString());
                        m.upd_theodoigiuong(id, s_makp, s_mabn, l_matd, l_maql, l_maql, _madoituong, int.Parse(r1["id"].ToString()), ngayvv.Text + " " + giovv.Text, decimal.Parse(r1[fie].ToString()) * tygia, i_userid);
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + int.Parse(r1["id"].ToString()));
                        itable = m.tableid("", "theodoigiuong");
                        m.upd_eve_tables(itable, i_userid, "ins");
                        m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + id));
                    }
                }
                else if ((s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) || (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru)) m.upd_sukien(ngayvv.Text, s_mabn, l_maql, LibMedi.AccessData.Phongluu, l_maql);
            }
            else
            {
                l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, true);
                if (l_matd == 0)
                {
                    l_matd = m.get_tiepdon_phongluu(s_mabn, ngayvv.Text + " " + giovv.Text);
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn, l_matd, l_matd, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Phongluu, 0);//bi061009
                        if (int.Parse(so.Substring(0, 2)) > 0)
                        {
                            if (!m.upd_bhyt(ngayvv.Text, s_mabn, l_matd, sothe.Text, denngay.Text, manoidk.Text, 0, tungay.Text, s_tungay1, s_tungay2, s_tungay3, traituyen.SelectedIndex))//gam 07/09/2011
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                                return;
                            }
                        }
                    }
                    m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Phongluu, l_maql);
                }
                else if ((s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) || (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru)) m.upd_sukien(ngayvv.Text, s_mabn, l_maql, LibMedi.AccessData.Phongluu, l_maql);
            }
            string s_vp = "";
            if (s_chonxutri.IndexOf("07,") != -1)
            {
                s_vp = m.sKtKetquaCLS(s_mabn, decimal.Parse(l_matd.ToString()), ngayvv.Text, ngayrv.Text);
                if (s_vp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân tử vong phải có kết quả của " + s_vp), s_msg);
                    return;
                }

            }
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, 0, 0,0);
            if (!m.upd_lienhe(ngayvv.Text, l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            
            if (!m.upd_benhancc(s_mabn, l_matd, l_maql, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), mabsnb.Text, cd_kkb.Text, icd_kkb.Text, sovaovien.Text, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }

            //quan ly doi tuong bo doi
            try
            {
                if (l_matd > 0)
                {
                    DataSet ads1 = m.get_data("select mabn from medibv.qn_benhnhan where mavaovien=" + l_matd + " and mabn='" + s_mabn + "'");
                    if (ads1 == null || ads1.Tables.Count <= 0 || ads1.Tables[0].Rows.Count <= 0)
                    {
                        DataRow r = m.getrowbyid(dtdt, "madoituong=" + tendoituong.SelectedValue.ToString());
                        if (r["bodoi"].ToString() == "1")
                        {
                            frmDoiTuongBoDoi f = new frmDoiTuongBoDoi(m, s_mabn, hoten.Text, tuoi.Text, ((sonha.Text == "") ? "" : sonha.Text + ", ") + ((thon.Text == "") ? "" : thon.Text + ", ") + tenpxa.Text + ", " + tenquan.Text + ", " + tentinh.Text, l_matd, false);
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch { }
            if (m.bSoluutruPK_PL_NGT_tudong)
            {
                string s_mmyy = "";
                s_mmyy = DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0');
                decimal l_idluutru = m.get_capid(200, s_mmyy);
                s_soluutru = i_chinhanh.ToString().PadLeft(2, '0') + s_mmyy + l_idluutru.ToString().PadLeft(6, '0');
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
                m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".benhancc set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            }
            //if (m.bSoluutruPK_PL_NGT_tudong) gam 02042012 -->code dư, đã update o tren rồi
            //{
            //    m.execute_data("update " + user + m.mmyy(ngayvv.Text.Substring(0, 10)) + ".benhancc set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //}

            if (bNew) m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".benhancc set giuong='" + giuong.Text + "' where maql=" + l_maql);
            if (int.Parse(so.Substring(0, 2)) > 0)
            {
                if (!m.upd_bhyt(ngayvv.Text, s_mabn, l_maql, sothe.Text, denngay.Text, manoidk.Text, 0, tungay.Text, s_tungay1, s_tungay2, s_tungay3, traituyen.SelectedIndex))//gam 07/09/2011
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
            if (manuoc.Enabled && manuoc.Text != "") m.upd_nuocngoai(s_mabn, manuoc.Text);
            else m.execute_data("delete from " + user + ".nuocngoai where mabn='" + s_mabn + "'");
            if (quanhe.Text != "") m.upd_quanhe(ngayvv.Text, l_maql, quanhe.Text, qh_hoten.Text, qh_diachi.Text, qh_dienthoai.Text);
            if (pmat.Visible) m.upd_ttmat(ngayvv.Text, l_maql, mp.Text, mt.Text, nhanapp.Text, nhanapt.Text);
            else m.upd_lydokham(ngayvv.Text, l_maql, lydo.Text);
            if (trieuchung.Text != "") m.upd_trieuchung(ngayvv.Text, l_maql, trieuchung.Text);
            if (ngayrv.Text != "" && s_chonxutri != "" && icd_chinh.Text != "" && cd_chinh.Text != "")
            {
                if (bPhonggiuong)
                {
                    itable = m.tableid("", "theodoigiuong");
                    decimal songay = 0;
                    int _madoituong = int.Parse(madoituong.Text);
                    foreach (DataRow r1 in m.get_data("select a.id,a.mavaovien,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,a.dongia,a.idgiuong,a.madoituong,c.dichvu from " + user + ".theodoigiuong a," + user + ".dmgiuong b," + user + ".dmphong c where a.idgiuong=b.id and b.idphong=c.id and a.maql=" + l_maql + " and a.soluong=0").Tables[0].Rows)
                    {
                        if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r1["dichvu"].ToString() == "1") ? madoituong_giuongdichvu : int.Parse(madoituong.Text);
                        //songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(1, m.songay(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 0));
                        songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(1, m.songay(m.StringToDateTime(ngayrv.Text), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), 0));
                        m.upd_theodoigiuong(decimal.Parse(r1["id"].ToString()), ngayrv.Text + " " + giorv.Text, _madoituong, songay);
                        v.upd_vpkhoa(decimal.Parse(r1["id"].ToString()), s_mabn, decimal.Parse(r1["mavaovien"].ToString()), l_maql, l_maql, ngayrv.Text + " " + giorv.Text, s_makp, _madoituong, int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), decimal.Parse(r1["dongia"].ToString()), 0, i_userid, 0);
                        //tinh chenh lech tien giuong
                        if (m.bChenhlech && _madoituong == 1)
                        {
                            DataRow rg = m.getrowbyid(dtgia, "id=" + r1["idgiuong"].ToString());
                            if (rg != null)
                            {
                                _madoituong = m.iTunguyen;
                                string fie = m.field_gia(_madoituong.ToString());
                                decimal d_dongia = decimal.Parse(rg[fie].ToString());
                                if (fie != "gia_bh" && rg["chenhlech"].ToString() == "1" && d_dongia - decimal.Parse(rg["gia_bh"].ToString()) > 1)
                                {
                                    d_dongia = d_dongia - decimal.Parse(rg["gia_bh"].ToString());
                                    v.upd_vpkhoa(decimal.Parse(r1["id"].ToString()) * -1, s_mabn, decimal.Parse(r1["mavaovien"].ToString()), l_maql, l_maql, ngayrv.Text + " " + giorv.Text, s_makp, _madoituong, int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), d_dongia, 0, i_userid, 0);
                                    v.execute_data("update " + user + m.mmyy(ngayrv.Text.Substring(0, 10)) + ".v_vpkhoa set dachenhlech=1 where id in(" + decimal.Parse(r1["id"].ToString()) * -1 + "," + decimal.Parse(r1["id"].ToString()) + ")");
                                }
                            }
                        }
                        //Khuong 02/11/2011
                        try
                        {
                            m.execute_data("update " + user + ".dmgiuong set soluong=soluong-1,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString()));
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(exx.Message);
                            m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString()));
                        }
                        m.upd_eve_tables(itable, i_userid, "upd");
                        m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".theodoigiuong", "id=" + decimal.Parse(r1["id"].ToString())));
                    }
                }
                if (s_chonxutri.IndexOf("07,") != -1)
                {
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count == 0)
                        l_tuvong_Click(null, null);
                }
                if (!m.upd_benhancc(ngayvv.Text + " " + giovv.Text, l_maql, ngayrv.Text + " " + giorv.Text, int.Parse(ketqua.Text), int.Parse(s_ttlucrv), cd_chinh.Text, icd_chinh.Text, mabs.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? int.Parse(cmbTaibien.SelectedValue.ToString()) : 0, (giaiphau.Checked) ? int.Parse(gphaubenh.SelectedValue.ToString()) : 0, soluutru.Text, giuong.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra viện !"), s_msg);
                    return;
                }
                //QRCODE
                if (bBHYT_QRCode_Dangky && s_QRcode_sothe.Trim() != "")
                {
                    m.upd_bhyt_qrcode(s_QRcode_sothe, s_QRcode_Hoten, s_QRcode_ngaysinh, int.Parse(s_QRcode_gioitinh), s_QRcode_diachi, s_QRcode_mabv, s_QRcode_tungay, s_QRcode_denngay, s_QRcode_ngaycap, s_QRcode_MaQLBHXH, s_QRcode_KiemTraBHXH, i_userid, s_mabn);
                }
               
                m.upd_xutrikbct(ngayvv.Text, l_maql, s_chonxutri, khoa.Text);
                if (cd_kemtheo.Text != "") m.upd_cdkemtheo(ngayvv.Text, l_maql, l_maql, 4, cd_kemtheo.Text, icd_kemtheo.Text, 1);
                else m.execute_data("delete from " + user + m.mmyy(ngayvv.Text) + ".cdkemtheo where stt=1 and loai=4 and maql=" + l_maql);
                if (loaibv.Enabled && loaibv.Text != "") m.upd_chuyenvien(l_maql, mabv.Text, int.Parse(loaibv.Text));
                else m.execute_data("delete from " + user + ".chuyenvien where maql=" + l_maql);
                decimal maluu = l_maql;
                m.execute_data_mmyy("update xxx.tiepdon set done='x' where mabn='" + s_mabn + "' and makp='" + s_makp + "' and to_char(ngay,'dd/Mm/yyyy')='" + ngayvv.Text + "'", ngayvv.Text, ngayvv.Text, false);//gam 22/10/2011 update lại done='x' khi đã kết thúc khám TH: bệnh nhân vào trực tiếp phòng lưu mà không qua tiếp đón 
                if (cd_nguyennhan.Text != "") m.upd_cdnguyennhan(l_idcdnguyennhan, l_maql, cd_nguyennhan.Text, icd_nguyennhan.Text);//gam 17/03/2012
                if (s_chonxutri.IndexOf("08,") != -1)
                {
                    string sokham = "";
                    decimal maql1 = m.get_maql(s_mabn, khoa.Text, ngayrv.Text + " " + giorv.Text);
                    if (i_sokham != 3 && khoa.Text != "" && bNew)
                    {
                        sokham = m.get_sokham(ngayrv.Text.Substring(0, 10), khoa.Text, i_sokham).ToString();
                        MessageBox.Show(lan.Change_language_MessageText("Số khám :") + " " + tenkhoa.Text.ToUpper().Trim() + " " + "\n" + sokham, LibMedi.AccessData.Msg);
                    }
                    m.upd_tiepdon(s_mabn, l_matd, maql1, khoa.Text, ngayrv.Text + " " + giorv.Text, int.Parse(madoituong.Text), (sokham != "") ? sokham : sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Khambenh, 0);//bi061009
                    m.upd_lienhe(ngayrv.Text, maql1, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0);
                    //TU:28/06/2011
                    if (m.bSoluutruPK_PL_NGT_tudong)
                        m.execute_data("update " + user + m.mmyy(ngayrv.Text.Substring(0, 10)) + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + maql1 + "");
                    //end TU
                    if (int.Parse(so.Substring(0, 2)) > 0)
                    {
                        if (!m.upd_bhyt(ngayrv.Text, s_mabn, maql1, sothe.Text, denngay.Text, manoidk.Text, 0, tungay.Text, s_tungay1, s_tungay2, s_tungay3, traituyen.SelectedIndex))//gam 07/09/2011
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                            return;
                        }
                    }
                    if (bDanhsach) upd_detail(ngayrv.Text, maql1, khoa.Text, int.Parse(madoituong.Text));
                    if (bThuphi_kham && !bPhongluu_chuyenkham_kcong)
                    {
                        DataRow r2 = m.getrowbyid(dtdt, "mien=0 and madoituong=" + int.Parse(madoituong.Text));
                        if (r2 != null) m.execute_data("update " + user + m.mmyy(ngayrv.Text) + ".tiepdon set done='x' where maql=" + maql1);
                    }
                }
                if (s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) //dieu tri ngoai tru
                    upd_ngoaitru(so);
                if (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru) //noi tru
                    upd_noitru(so);
                l_maql = maluu;
                if ((!bCapcuu_noitru || s_chonxutri.IndexOf("05,") == -1) && bInravien_ravien)
                {
                    if (m.get_thvpll(ngayrv.Text + " " + giorv.Text, l_maql, ngayvv.Text + " " + giovv.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã chuyển chi phí thanh toán !"), LibMedi.AccessData.Msg);
                        //butTiep_Click(sender, e);
                        return;
                    }
                    if (m.get_thvpll(ngayrv.Text + " " + giorv.Text, l_maql, ngayvv.Text + " " + giovv.Text) == false)
                    {
                        DataSet dsxml = m.get_thanhtoan(l_maql, 0, ngayvv.Text + " " + giovv.Text, ngayrv.Text + " " + giorv.Text, 4, m.bThanhtoan_khoa, s_userid, i_userid);
                        string s_rpt = "rptTtravien.rpt", title = lan.Change_language_MessageText("PHIẾU THANH TOÁN RA VIỆN");
                        if (bInthanhtoanchitiet)
                        {
                            s_rpt = "rpt_ttravien_kp.rpt";
                            title = m.get_tenkp(s_makp);
                        }
                        if (dsxml.Tables[0].Rows.Count > 0)
                        {
                            if (chkIn.Checked)
                            {
                                if (chkXem.Checked)
                                {
                                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, title, s_rpt, true);
                                    f.ShowDialog();
                                }
                                else print.Printer(m, dsxml, s_rpt, title, 1);
                            }
                            else MessageBox.Show(lan.Change_language_MessageText("Đã chuyển số liệu xuống phòng thanh toán."), LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
                    }
                }
            }
            if (sender != null)
            {
                ena_but(false);
                butTiep.Focus();
            }
        }

        private void upd_detail(string ngay, decimal maql, string _makp, int _madoituong)
        {
            DataRow r = m.getrowbyid(dtkp, "makp='" + _makp + "'");
            if (r != null)
            {
                int _mavp = int.Parse(r["mavp"].ToString());
                decimal l_id = m.get_id_chidinh(ngay, maql, 0, v.iNgoaitru);
                if (l_id == 0) l_id = v.get_id_chidinh;
                string gia = m.field_gia(_madoituong.ToString());
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                r = m.getrowbyid(dtgia, "id=" + _mavp);
                if (r != null)
                {
                    decimal d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    if (d_dongia != 0)
                    {
                        v.upd_chidinh(l_id, mabn2.Text + mabn3.Text.PadLeft(6, '0'), l_matd, maql, 0, ngay, v.iNgoaitru, _makp, _madoituong, _mavp, 1, d_dongia, 0, i_userid, 0, 0, l_id, "", "", "", 3, "");//bi061009
                        v.execute_data("update " + user + v.mmyy(ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + ((traituyen.SelectedIndex < 0) ? "0" : traituyen.SelectedIndex.ToString()) + " where id=" + l_id);
                    }
                }
            }
        }

        private void upd_noitru(string so)
        {
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
            //
            if (m.get_data("select * from " + m.user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
            {
                return;
            }
            //
            itable = m.tableid("", "benhandt");
            if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".benhandt", "maql=" + l_maql));
            }
            if (!m.upd_lienhe(l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            //TU:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end TU

            if (!m.upd_benhandt(s_mabn, l_matd, l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), 1, int.Parse(tendoituong.SelectedValue.ToString()), (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, mabs.Text, "", 1, i_userid, true))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            //ThanhCuong 21/03/2012
            if (bThongBaoSoVaoVien)
            {
                try
                {
                    string s_sovaoviennt = "";
                    s_sovaoviennt = m.get_data("select sovaovien from " + user + ".benhandt where mabn='" + s_mabn + "' and maql=" + l_maql).Tables[0].Rows[0]["sovaovien"].ToString();
                    string mes = "Số vào viện BN: " + hoten.Text + " là : " + s_sovaoviennt;
                    frmMessageSVV f = new frmMessageSVV(m, i_userid, mes);
                    f.ShowDialog();
                }
                catch { }
            }
            //End ThanhCuong
            if (int.Parse(so.Substring(0, 2)) > 0)
            {
                if (!m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, manoidk.Text, 0, tungay.Text, ngay1, ngay2, ngay3, traituyen.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                    return;
                }
            }
            if (cd_noichuyenden.Text != "")
            {
                if (!m.upd_noigioithieu(l_maql, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                    return;
                }
            }
            if (quanhe.Text != "") m.upd_quanhe(l_maql, quanhe.Text, qh_hoten.Text, qh_diachi.Text, qh_dienthoai.Text);
            if (cd_kemtheo.Text != "") m.upd_cdkemtheo(l_maql, l_maql, 1, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            else m.execute_data("delete from " + user + ".cdkemtheo where stt=1 and loai=1 and maql=" + l_maql);
            if (khamthai.Visible) m.upd_ttkhamthai(s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
            m.upd_sukien(s_mabn, l_matd, LibMedi.AccessData.Nhanbenh, l_maql);
            if (!bNew) m.execute_data("delete from " + user + ".hiendien where nhapkhoa=0 and xuatkhoa=0 and mabn='" + s_mabn + "' and makp<>'" + khoa.Text + "'");
            //m.execute_data("delete from " + user + ".hiendien where nhapkhoa=0 and xuatkhoa=0 and mabn='" + s_mabn + "' and makp<>'" + khoa.Text + "'");
            decimal tmpid = m.get_id_hiendien_do_cdvv(s_mabn, l_maql, "01");
            decimal l_idhiendien = (tmpid == 0) ? m.get_id(l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text) : tmpid;//tinh them gio
            m.upd_hiendien(l_idhiendien, s_mabn, l_matd, l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text, ngayrv.Text + " " + giorv.Text, giuong.Text, mabs.Text, icd_chinh.Text, "01", 0, 0);
        }

        private void upd_ngoaitru(string so)
        {
            bool bNew = m.get_maql_benhanngtr(s_mabn, ngayrv.Text + " " + giorv.Text, false) == 0;
            if (bNew)
            {
                string s_tenkp = m.bHiendien(s_mabn, 2);
                if (s_tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được,phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                    return;
                }
            }
            l_maql = m.get_maql_benhanngtr(s_mabn, ngayrv.Text + " " + giorv.Text, true);
            itable = m.tableid("", "benhanngtr");
            if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".benhanngtr", "maql=" + l_maql));
            }
            if (!m.upd_lienhe(l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            //TU:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".lienhe set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end TU

            if (!m.upd_benhanngtr(s_mabn, l_matd, l_maql, khoa.Text, ngayrv.Text + " " + giorv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), cd_kkb.Text, icd_kkb.Text, sovaovien.Text, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            //TU:28/06/2011
            if (m.bSoluutruPK_PL_NGT_tudong)
                m.execute_data("update " + user + ".benhanngtr set soluutru='" + s_soluutru + "' where maql=" + l_maql + "");
            //end TU

            if (int.Parse(so.Substring(0, 2)) > 0)
            {
                if (!m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, manoidk.Text, 0, tungay.Text, ngay1, ngay2, ngay3, traituyen.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), s_msg);
                    return;
                }
            }

            if (cd_noichuyenden.Text != "")
            {
                if (!m.upd_noigioithieu(l_maql, madstt.Text, cd_noichuyenden.Text, icd_noichuyenden.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"), s_msg);
                    return;
                }
            }
            if (quanhe.Text != "") m.upd_quanhe(l_maql, quanhe.Text, qh_hoten.Text, qh_diachi.Text, qh_dienthoai.Text);
            if (khamthai.Visible) m.upd_ttkhamthai(s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
            m.upd_sukien(s_mabn, l_matd, LibMedi.AccessData.Ngoaitru, l_maql);
        }

        private void ena_but(bool ena)
        {
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
        }

        private void butBoqua_Click(object sender, System.EventArgs e)
        {
            butTiep_Click(null, null);
        }

        private void nhantu_TextChanged(object sender, System.EventArgs e)
        {
            nhantu.Text = nhantu.Text;
        }

        private void load_treeView()
        {
            treeView1.Nodes.Clear();
            if (nam == "") return;
            try
            {
                if (bQuanly_Theo_Chinhanh)
                {
                    s_mabn = mabn2.Text + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
                }
                else
                {
                    s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                }
                TreeNode node;
                foreach (DataRow r in m.get_data_nam(nam, "select ngay,chandoan,to_char(ngay,'yyyymmddhh24mi') as yymmdd from xxx.benhancc where mabn='" + s_mabn + "'").Tables[0].Select("true", "yymmdd desc"))
                {
                    node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                    node.Nodes.Add(r["chandoan"].ToString());
                }
            }
            catch { }
        }

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                try
                {
                    string s = e.Node.FullPath.Trim();
                    int iPos = s.IndexOf("/");
                    string ngay = s.Substring(iPos - 2, 16);
                    if (bQuanly_Theo_Chinhanh)
                    {
                        s_mabn = mabn2.Text + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
                    }
                    else
                    {
                        s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                    }
                    l_maql = m.get_maql_benhancc(s_mabn, ngay, false);
                    bNew = l_maql == 0;
                    if (l_maql != 0)
                    {
                        ngayvv.Text = ngay.Substring(0, 10);
                        giovv.Text = ngay.Substring(11);
                        load_vv_maql(true);
                    }
                }
                catch { }
            }
        }

        private void l_phauthuat_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            frmPttt f = new frmPttt(m, s_makp, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, "", ngayvv.Text + " " + giovv.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, "P", i_userid, "", "", "", l_maql, l_matd, 0, 2, false);
            f.ShowDialog();
            load_phauthuat();
        }

        private void giaiphau_CheckStateChanged(object sender, System.EventArgs e)
        {
            gphaubenh.Visible = giaiphau.Checked;
        }

        private void l_tainantt_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            frmTainantt f = new frmTainantt(m, l_maql, s_mabn, ngayvv.Text + " " + giovv.Text, hoten.Text, namsinh.Text, tennn.Text, sonha.Text.Trim() + " " + thon.Text, i_userid, s_makp,nam);
            f.ShowInTaskbar = false;
            f.ShowDialog();
            load_tainantt();
        }

        private void taibien_CheckStateChanged(object sender, System.EventArgs e)
        {
            cmbTaibien.Visible = taibien.Checked;
        }

        private void Filt_dstt(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listdstt.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
        }

        private void madstt_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (madstt.Text == m.Mabv)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"), s_msg);
                    madstt.Text = "";
                    return;
                }
                tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void tendstt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listdstt.Focus();
            else if (e.KeyCode == Keys.Enter)
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
            listdstt.BrowseToText(tendstt, madstt, madoituong, dentu.Location.X, dentu.Location.Y + madstt.Height, madstt.Width + tendentu.Width + dentu.Width * 3 + tendstt.Width + 2, madstt.Height);
            //listdstt.BrowseToText(tendstt, madstt, madoituong, madstt.Location.X, madstt.Location.Y + madstt.Height, madstt.Width + tendstt.Width + 2, madstt.Height);
        }

        private void listdstt_Validated(object sender, System.EventArgs e)
        {
            //treeView1.Visible=true;
        }

        private void tendstt_Validated(object sender, System.EventArgs e)
        {
            if (!listdstt.Focused)
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
                if (namsinh.Text != "")
                {
                    if (DateTime.Now.Year - int.Parse(namsinh.Text) < iTreem6)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
                    else if (DateTime.Now.Year - int.Parse(namsinh.Text) < iTreem15)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
                }
            }
        }

        private void cd_noichuyenden_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_noichuyenden)
            {
                if (bChandoan_kemtheo || icd_noichuyenden.Text == "" || icd_noichuyenden.Text.Trim() == u00)
                {
                    Filt_ICD(cd_noichuyenden.Text);
                    if (trieuchung.Enabled)
                        listICD.BrowseToICD10(cd_noichuyenden, icd_noichuyenden, trieuchung, icd_chinh.Location.X - 393, pvaovien.Location.Y + pvaovien.Height - icd_noichuyenden.Height - 97, icd_noichuyenden.Width + cd_noichuyenden.Width + 392, icd_noichuyenden.Height);
                    else
                        listICD.BrowseToICD10(cd_noichuyenden, icd_noichuyenden, icd_kkb, icd_chinh.Location.X - 393, pvaovien.Location.Y + pvaovien.Height - icd_noichuyenden.Height - 97, icd_noichuyenden.Width + cd_noichuyenden.Width + 392, icd_noichuyenden.Height);
                }
            }
        }

        private void cd_chinh_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_chinh)
            {
                if (bChandoan || icd_chinh.Text == "" || icd_chinh.Text.Trim() == u00)
                {
                    Filt_ICD(cd_chinh.Text);
                    listICD.BrowseToICD10(cd_chinh, icd_chinh, icd_kemtheo, icd_chinh.Location.X - 393, icd_chinh.Location.Y + icd_chinh.Height - 2, icd_chinh.Width + cd_chinh.Width + 394, icd_chinh.Height);
                }
            }
        }

        private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_kemtheo)
            {
                if (bChandoan_kemtheo || icd_kemtheo.Text == "" || icd_kemtheo.Text.Trim() == u00)
                {
                    Filt_ICD(cd_kemtheo.Text);
                    listICD.BrowseToICD10(cd_kemtheo, icd_kemtheo, mabs, icd_kemtheo.Location.X - 393, icd_kemtheo.Location.Y + icd_kemtheo.Height - 2, icd_kemtheo.Width + cd_kemtheo.Width + 394, icd_kemtheo.Height);
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
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void l_thuocbhyt_Click(object sender, System.EventArgs e)
        {
            if (bQuanly_Theo_Chinhanh)
            {
                s_mabn = mabn2.Text + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
            }
            else
            {
                s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            }
            if (mabs.Text == "" || tenbs.Text == "" || mabsnb.Text == "" || tenbsnb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            if (icd_kkb.Text == "" && cd_kkb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (icd_kkb.Text == "" && cd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (cd_kkb.Text == "" && icd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh !"), s_msg);
                if (cd_kkb.Enabled) cd_kkb.Focus();
                else icd_kkb.Focus();
                return;
            }
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            //
            if (m.bPhongluu_ra_captoave)//BN chưa ra phong luu chua duoc phep cap toa
            {
                if (cd_chinh.Text == "" || icd_chinh.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh !"), s_msg);
                    if (cd_chinh.Enabled) cd_chinh.Focus();
                    else icd_chinh.Focus();
                    return;
                }
                if (maxutri.Text.Trim() == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập xử trí trước khi cấp toa !"), s_msg);
                    xutri.Focus();
                    return;
                }
            }
            //
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
            sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
            DataTable dt = m.get_data(sql).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                s_mmyy = r["mmyy"].ToString();
                sql = "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc;
                if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";//binh 210411
                if (d.get_data(sql).Tables[0].Rows.Count > 0) break;
            }
            //
            string tmp_ngay = ngayvv.Text;
            int _userid = -1;
            if (s_mmyy == "") s_mmyy = m.mmyy(ngayvv.Text.Substring(0, 10));
            if (d.bSophieu_mau38_tangtheonam(m.nhom_duoc))
            {
                tmp_ngay = "31/12/20" + s_mmyy.Substring(2, 2);
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else if (d.bSophieu_mau38_tangtheonam_tinhtuthang12(m.nhom_duoc))
            {
                tmp_ngay = d.get_ngaytao_solieu_thangmoi("01" + s_mmyy.Substring(2, 2), m.nhom_duoc); //d.iNgaytinh_Sophieu_mau38_tangtheonam(m.nhom_duoc).ToString().PadLeft(2, '0') + "/12/20" + (int.Parse(s_mmyy.Substring(2, 2)) - 1).ToString().PadLeft(2, '0');
                //
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(m.nhom_duoc)) tmp_ngay = "01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                else if (d.bSophieu_mau38_tangtheothang_tinhtuthangtruoc(m.nhom_duoc))
                {
                    tmp_ngay = d.get_ngaytao_solieu_thangmoi(s_mmyy, m.nhom_duoc);// d.iNgaytinh_Sophieu_mau38_tangthang(m.nhom_duoc).ToString().PadLeft(2, '0') + "/" + tmp_mm.ToString().PadLeft(2, '0') + "/20" + tmp_yy.ToString().PadLeft(2, '0');
                }
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(d_mmyy, -99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 0);
                d.upd_capsotoa(d_mmyy, 2, tmp_ngay, 1);
            }
            ngay_reset_phieu38 = tmp_ngay;
            if (madoituong.Text != "1")
            {
                if (m.get_data("select * from " + user + ".d_dmphieu where id=6 and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng") + " " + "\n" + tendoituong.Text + "\n" + lan.Change_language_MessageText("Không được cấp thuốc !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            string adiachi = sonha.Text.Trim() + " " + thon.Text.Trim() + ", " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
            //
            string s_ngayhienhanh = m.ngayhienhanh_server;
            if (s_ngayhienhanh.Substring(3, 2) != ngayvv.Text.Substring(3, 2)) m.f_chuyenbhyt_to_next_mmyy(s_mabn, l_maql, ngayvv.Text, s_ngayhienhanh);
            //
            frmBaohiem f = new frmBaohiem(false, s_mabn, (madoituong.Text == "1") ? 5 : 6, s_mmyy, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text + " " + giorv.Text : m.ngayhienhanh_server, m.nhom_duoc, i_userid, "Đơn thuốc dược phát", l_matd, l_maql, hoten.Text, namsinh.Text, sothe.Text, "Phòng lưu", (tenbs.Text != "") ? tenbs.Text : tenbsnb.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, int.Parse(madoituong.Text), s_makp, (mabs.Text != "") ? mabs.Text : mabsnb.Text, tendoituong.Text, cholam.Text, adiachi.Trim().Trim(','), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 4, manoidk.Text, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen.SelectedIndex, ngay1, ngay2, ngay3, phai.Text, i_khudt, 4);
            f.ShowDialog(this);
            load_baohiem();
        }

        private void l_thuocdan_Click(object sender, System.EventArgs e)
        {
            if (bQuanly_Theo_Chinhanh)
            {
                s_mabn = mabn2.Text + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');
            }
            else
            {
                s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            } 
            if (mabs.Text == "" || tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                mabs.Focus();
                return;
            }
            if (icd_kkb.Text == "" && cd_kkb.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (icd_kkb.Text == "" && cd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh !"), s_msg);
                icd_kkb.Focus();
                return;
            }
            else if (cd_kkb.Text == "" && icd_kkb.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh !"), s_msg);
                if (cd_kkb.Enabled) cd_kkb.Focus();
                else icd_kkb.Focus();
                return;
            }
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;
            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            if (icd_nguyennhan.Text == "" && cd_nguyennhan.Text != "") icd_nguyennhan.Text = u00;
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            string adiachi = sonha.Text.Trim() + " " + thon.Text.Trim() + ", " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
            if (bDanhmuc_nhathuoc)
            {
                LibDuoc.AccessData d = new LibDuoc.AccessData();
                string s_mmyy = ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(8, 2);
                sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                DataTable dt = m.get_data(sql).Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    s_mmyy = r["mmyy"].ToString();
                    sql = "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc;
                    if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";//binh 210411
                    if (d.get_data(sql).Tables[0].Rows.Count > 0) break;
                }
                frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayvv.Text + " " + giovv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc mua ngoài", l_matd, l_maql, hoten.Text, namsinh.Text, sothe.Text, "Phòng lưu", tenbs.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, 2, s_makp, (mabs.Text != "") ? mabs.Text : mabsnb.Text, tendoituong.Text, cholam.Text, adiachi.Trim().Trim(','), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 4, manoidk.Text, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen.SelectedIndex, ngay1, ngay2, ngay3, phai.Text, i_khudt, 4); //Khuong 16/11/2011
                f.ShowDialog(this);
                load_thuocdan();
            }
            else
            {
                frmToathuoc f = new frmToathuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text + " " + giorv.Text : m.ngayhienhanh_server, s_makp, "Phòng lưu", mabs.Text, tenbs.Text, (cd_chinh.Text == "") ? cd_kkb.Text : cd_chinh.Text, (icd_chinh.Text == "") ? icd_kkb.Text : icd_chinh.Text, l_maql, i_userid, adiachi.Trim().Trim(','), nam);
                f.ShowDialog(this);
                load_thuocdan();
            }
        }

        private void l_chidinh_Click(object sender, System.EventArgs e)
        {
            string s_ngaygiovv = ngayvv.Text + " " + giovv.Text;
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (mabs.Text == "" || tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"), s_msg);
                    mabs.Focus();
                    return;
                }
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
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
            if (m.bRaphongluu_khongchochidinh && bRaphongluu(l_maql))
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã ra phòng lưu, không được chỉ định thêm !"), LibMedi.AccessData.Msg);
                try
                {
                    butBoqua.Focus();
                }
                catch { }
                return;
            }
            //
            string s_ngaycd = ngayvv.Text;
            if (bchidinh_chonngay)
            {
                dllvpkhoa_chidinh.frmChonthongsovp f1 = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp + ",", i_khudt);
                f1.ShowDialog(this);
                if (f1.s_ngay == null) return;
                s_ngaycd = f1.s_ngay.Substring(0, 10) + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            }
            if (m.StringToDateTime(s_ngaygiovv) > m.StringToDateTime(s_ngaycd))
            {
                s_ngaycd = s_ngaygiovv;
            }
            //
            if (s_ngaycd.Substring(3, 2) != ngayvv.Text.Substring(3, 2)) m.f_chuyenbhyt_to_next_mmyy(s_mabn, l_maql, ngayvv.Text, s_ngaycd);
            //
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, s_ngaycd, s_makp, "Phòng lưu", int.Parse(madoituong.Text), v.iNgoaitru, l_matd, l_maql, 0, i_userid, "xxx.benhancc", sothe.Text, nam, 4, (mabs.Text != "") ? mabs.Text : mabsnb.Text, (cd_chinh.Text != "") ? cd_chinh.Text : cd_kkb.Text, (icd_chinh.Text != "") ? icd_chinh.Text : icd_kkb.Text, (traituyen.SelectedIndex < 0) ? 0 : traituyen.SelectedIndex);
            f.NgayVaoVien = ngayvv.Text;
            f.ShowDialog(this);
            load_chidinh();
        }

        private void l_vienphi_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            dllvpkhoa_chidinh.frmChonthongsovp f1 = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp + ",", i_khudt);
            f1.ShowDialog(this);
            if (f1.s_makp != "")
            {
                dllvpkhoa_chidinh.frmChonvpk f = new dllvpkhoa_chidinh.frmChonvpk(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, f1.s_ngay, f1.s_makp, f1.s_tenkp, int.Parse(madoituong.Text), l_matd, l_maql, 0, i_userid, "xxx.benhancc", f1.i_buoi, sothe.Text);
                f.ShowDialog(this);
                load_vienphi();
            }
        }

        private void soluutru_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (mabn3.Text == "" && soluutru.Text != "" && nam != "")
                {
                    DataTable dt = m.get_data_nam_dec(nam, "select mabn,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from benhancc where soluutru='" + soluutru.Text + "'" + " order by maql").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        s_mabn = dt.Rows[0]["mabn"].ToString();
                        ngayvv.Text = dt.Rows[0]["ngay"].ToString().Substring(0, 10);
                        giovv.Text = dt.Rows[0]["ngay"].ToString().Substring(11);
                        mabn2.Text = s_mabn.Substring(0, 2);
                        mabn3.Text = s_mabn.Substring(2);
                        load_mabn();
                        ngayvv_Validated(sender, e);
                    }
                }
            }
            catch { }
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

        private void tenbs_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text);
                if (soluutru.Enabled)
                    listBS.BrowseToICD10(tenbs, mabs, soluutru, mabs.Location.X, mabs.Location.Y + mabs.Height - 2, mabs.Width + tenbs.Width + 2, mabs.Height);
                else
                    listBS.BrowseToICD10(tenbs, mabs, xutri, mabs.Location.X, mabs.Location.Y + mabs.Height - 2, mabs.Width + tenbs.Width + 2, mabs.Height);
            }
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void khoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tenkhoa.SelectedValue = khoa.Text;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void tenkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenkhoa.Items.Count > 0 && tenkhoa.SelectedIndex == -1) tenkhoa.SelectedIndex = 0;
                khoa.Text = tenkhoa.SelectedValue.ToString();
                SendKeys.Send("{Tab}");
            }
        }

        private void tenkhoa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenkhoa)
            {
                khoa.Text = tenkhoa.SelectedValue.ToString();
            }
        }

        private void l_tuvong_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayvv.Text + " " + giovv.Text, "1", l_maql, i_userid);
            f.ShowDialog();
        }

        private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                xutri_SelectedIndexChanged(sender, e);
                SendKeys.Send("{Tab}");
            }
        }

        private void xutri_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            s_chonxutri = chon_xutri();
            loaibv.Enabled = (s_chonxutri.IndexOf("06,") != -1);
            tenloaibv.Enabled = loaibv.Enabled;
            mabv.Enabled = loaibv.Enabled;
            tenbv.Enabled = loaibv.Enabled;
            khoa.Enabled = (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("08,") != -1);
            if (khoa.Enabled)
            {
                sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
                if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
                sql += " order by makp";
                tenkhoa.DataSource = m.get_data(sql).Tables[0];
                if (tenkhoa.SelectedIndex != -1) khoa.Text = tenkhoa.SelectedValue.ToString();
            }
            tenkhoa.Enabled = khoa.Enabled;
        }

        private void butIn_Click(object sender, System.EventArgs e)
        {
            if (khoa.Text != "" && tenkhoa.SelectedIndex != -1)
            {
                ds = m.get_data("select * from " + m.user + m.mmyy(ngayvv.Text) + ".benhancc where maql=" + l_maql);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "PhieuKhamBenh", "",
lan.Change_language_MessageText("Phòng lưu"), tenbs.Text, "", m.Mabv + "/" + mabn2.Text + "/" + mabn3.Text, hoten.Text, ngaysinh.Text, (loaituoi.SelectedIndex == 0) ? tuoi.Text.Substring(1) : "000", phai.SelectedIndex.ToString(),
                        tennn.Text, mann.Text, tendantoc.Text, madantoc.Text, (tennuoc.Enabled) ? tennuoc.Text : "", (tennuoc.Enabled) ? tennuoc.SelectedValue.ToString() : "", sonha.Text, thon.Text, tenpxa.Text, tenquan.Text, maqu2.Text, tentinh.Text, matt.Text, cholam.Text, madoituong.Text,
                        denngay.Text, sothe.Text, qh_hoten.Text, qh_dienthoai.Text, "", ngayvv.Text + " " + giovv.Text, nhantu.Text, dentu.Text, "1", tenkhoa.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                        cd_noichuyenden.Text, m.Maicd_rpt(icd_noichuyenden.Text), cd_kkb.Text, m.Maicd_rpt(icd_kkb.Text), "", "", "0", "0", cd_chinh.Text, m.Maicd_rpt(icd_chinh.Text), cd_kemtheo.Text, m.Maicd_rpt(icd_kemtheo.Text), (taibien.Checked) ? "1" : "0",
                        (bienchung.Checked) ? "1" : "0", "", (giaiphau.Checked) ? gphaubenh.SelectedValue.ToString() : "0", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                        "", "", "", "", "", "", "", "", "", "0", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    f.ShowDialog();
                }
                else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), s_msg);
            }
        }

        private void l_kemtheo_Click(object sender, System.EventArgs e)
        {
            if (icd_kemtheo.Text == "" || cd_kemtheo.Text == "")
            {
                icd_kemtheo.Focus();
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0) luu();
            else m.upd_cdkemtheo(ngayvv.Text, l_maql, l_maql, 4, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            frmCdkemtheo f = new frmCdkemtheo(m, l_maql, l_maql, 4, ngayvv.Text + " " + giovv.Text);
            f.ShowDialog();
            load_kemtheo();
        }

        private void luu()
        {
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            bool bNew = false;
            decimal idgiuong = 0;
            if (bPhonggiuong)
            {
                bNew = m.get_data("select maql from " + user + m.mmyy(ngayvv.Text) + ".benhancc where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngayvv.Text + " " + giovv.Text + "'").Tables[0].Rows.Count == 0;
                if (bNew)
                {
                    l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, true);
                    if (l_matd == 0)
                    {
                        l_matd = m.get_tiepdon_phongluu(s_mabn, ngayvv.Text + " " + giovv.Text);
                        if (l_matd == 0)
                        {
                            l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                            m.upd_tiepdon(s_mabn, l_matd, l_matd, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Phongluu, 0);//bi061009
                        }
                        m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Phongluu, l_maql);
                    }
                    DataRow r2, r1 = m.getrowbyid(dtg, "ma='" + giuong.Text + "'");
                    string fie = "gia_th";
                    decimal id = v.get_id_vpkhoa;
                    if (r1 != null)
                    {
                        r2 = m.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.Text));
                        if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                        idgiuong = decimal.Parse(r1["id"].ToString());
                        m.upd_theodoigiuong(id, s_makp, s_mabn, l_matd, l_maql, l_maql, int.Parse(madoituong.Text), int.Parse(r1["id"].ToString()), ngayvv.Text + " " + giovv.Text, decimal.Parse(r1[fie].ToString()), i_userid);
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + int.Parse(r1["id"].ToString()));
                        itable = m.tableid("", "theodoigiuong");
                        m.upd_eve_tables(itable, i_userid, "ins");
                        m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + id));
                    }
                    m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".benhancc set giuong='" + giuong.Text + "' where maql=" + l_maql);
                }
                else if ((s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) || (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru)) m.upd_sukien(ngayvv.Text, s_mabn, l_maql, LibMedi.AccessData.Phongluu, l_maql);
            }
            else
            {
                l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, true);
                if (l_matd == 0)
                {
                    l_matd = m.get_tiepdon_phongluu(s_mabn, ngayvv.Text + " " + giovv.Text);
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn, l_matd, l_matd, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, 0, LibMedi.AccessData.Phongluu, 0);//bi061009
                    }
                    m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Phongluu, l_maql);
                }
                else if ((s_chonxutri.IndexOf("02,") != -1 && bXutri_ngoaitru) || (s_chonxutri.IndexOf("05,") != -1 && bXutri_noitru)) m.upd_sukien(ngayvv.Text, s_mabn, l_maql, LibMedi.AccessData.Phongluu, l_maql);
            }
            if (!m.upd_lienhe(ngayvv.Text, l_maql, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }
            if (!m.upd_benhancc(s_mabn, l_matd, l_maql, s_makp, ngayvv.Text + " " + giovv.Text, int.Parse(dentu.Text), int.Parse(nhantu.Text), int.Parse(tendoituong.SelectedValue.ToString()), mabsnb.Text, cd_kkb.Text, icd_kkb.Text, sovaovien.Text, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
            if (bNew) m.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".benhancc set giuong='" + giuong.Text + "' where maql=" + l_maql);
            if (cd_kemtheo.Text != "") m.upd_cdkemtheo(ngayvv.Text, l_maql, l_maql, 4, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text, s_mabn, l_maql, para1.Text.PadLeft(2, '0') + para2.Text.PadLeft(2, '0') + para3.Text.PadLeft(2, '0') + para4.Text.PadLeft(2, '0'), "", "", "");
        }

        private void load_kemtheo()
        {
            //kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=4 and id="+l_id).Tables[0].Rows.Count!=0;
            //l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
        }

        private void ketqua_Validated(object sender, System.EventArgs e)
        {
            try
            {
                tenketqua.SelectedValue = ketqua.Text;
            }
            catch { }
        }

        private void ketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tenketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenketqua.SelectedIndex == -1) tenketqua.SelectedIndex = 0;
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void icd_kkb_Validated(object sender, System.EventArgs e)
        {
            if (icd_kkb.Text != s_icd_kkb)
            {
                if (icd_kkb.Text == "") cd_kkb.Text = "";
                else cd_kkb.Text = m.get_vviet(icd_kkb.Text);
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
                s_icd_kkb = icd_kkb.Text;
            }
        }

        private void cd_kkb_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == cd_kkb)
            {
                if (bChandoan_kemtheo || icd_kkb.Text == "" || icd_kkb.Text.Trim() == u00)
                {
                    Filt_ICD(cd_kkb.Text);
                    //listICD.BrowseToICD10(cd_kkb, icd_kkb, ngayrv, icd_chinh.Location.X - 393, pvaovien.Location.Y + pvaovien.Height - icd_noichuyenden.Height - 74, icd_noichuyenden.Width + cd_noichuyenden.Width + 394, icd_noichuyenden.Height);
                    listICD.BrowseToICD10(cd_kkb, icd_kkb, mabsnb, icd_kkb.Location.X, pvaovien.Location.Y + icd_kkb.Location.Y + icd_kkb.Height + 2, icd_noichuyenden.Width + cd_noichuyenden.Width + 394, icd_noichuyenden.Height);
                }
            }
        }

        private void tenketqua_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ketqua.Text = tenketqua.SelectedValue.ToString();
            }
            catch { ketqua.Text = ""; }
        }

        private void l_diungthuoc_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            frmDiungthuoc f = new frmDiungthuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim());
            f.ShowDialog(this);
            load_diungthuoc();
        }
        private void para1_Validated(object sender, System.EventArgs e)
        {
            para1.Text = para1.Text.PadLeft(2, '0');
            if (para1.Text == "99")
            {
                para2.Text = para1.Text;
                para3.Text = para1.Text;
                para4.Text = para1.Text;
                madoituong.Focus();
            }
        }

        private void para2_Validated(object sender, System.EventArgs e)
        {
            para2.Text = para2.Text.PadLeft(2, '0');
        }

        private void para3_Validated(object sender, System.EventArgs e)
        {
            para3.Text = para3.Text.PadLeft(2, '0');
        }

        private void para4_Validated(object sender, System.EventArgs e)
        {
            para4.Text = para4.Text.PadLeft(2, '0');
        }
        private void phai_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (bKhamthai) khamthai.Visible = phai.SelectedIndex == 1;
        }

        private void l_cls_Click(object sender, System.EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            if (bQuanly_Theo_Chinhanh)
            {
                frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text + mabn3.Text.PadLeft(6, '0'), hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim());
                f.ShowDialog(this);
            }
            else
            {
                frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text + mabn3.Text.PadLeft(6, '0'), hoten.Text, tuoi.Text + " " + loaituoi.Text, sonha.Text.Trim() + " " + thon.Text.Trim());
                f.ShowDialog(this);
            }
        }

        private void l_tutruc_Click(object sender, System.EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }

            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, s_makp + ",", false, s_nhomkho, i_khudt,i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, s_mabn, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, mabs.Text, s_madoituong);
                f1.ShowDialog(this);
            }
        }

        private void butIncv_Click(object sender, System.EventArgs e)
        {
            bool bPhongluu_nhapchuyenvien_truockhiin = m.bPhongluu_nhapchuyenvien_truockhiin;
            if (bPhongluu_nhapchuyenvien_truockhiin)
            {
                frmGiaycv f = new frmGiaycv(m, "", i_userid, mabn2.Text + mabn3.Text.PadLeft(6, '0'), 2);
                f.ShowDialog();
            }
            else
            {
                if (tenbv.SelectedIndex != -1 && ngayrv.Text != "")
                {
                    DataSet dsxml = new DataSet();
                    dsxml.ReadXml("..//..//..//xml//m_giaycv.xml");
                    DataRow r1 = dsxml.Tables[0].NewRow();
                    r1["tenbv"] = tenbv.Text;
                    r1["mabn"] = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                    r1["hoten"] = hoten.Text;
                    r1["namsinh"] = namsinh.Text;
                    r1["phai"] = phai.Text;
                    r1["dantoc"] = tendantoc.Text;
                    r1["tennn"] = tennn.Text;
                    r1["doituong"] = tendoituong.Text;
                    r1["sothe"] = sothe.Text;
                    r1["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + "," + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim();
                    r1["noilamviec"] = cholam.Text;
                    r1["chandoan"] = cd_chinh.Text;
                    r1["maicd"] = icd_chinh.Text;
                    r1["tenkp"] = "Phòng lưu";
                    r1["tenbs"] = tenbs.Text;
                    r1["ngayvao"] = ngayvv.Text + " " + giovv.Text;
                    r1["ngayra"] = ngayrv.Text + " " + giorv.Text;
                    dsxml.Tables[0].Rows.Add(r1);
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, tenbv.Text, "rptGiaycv.rpt");
                    f.ShowDialog();
                }
            }
        }

        private void icd_noichuyenden_TextChanged(object sender, System.EventArgs e)
        {
            listICD.Hide();
        }

        private void lydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ngayrv.Focus();
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào !"), s_msg);
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
            if (s_ngayvv != "")
            {
                if (ngayvv.Text != s_ngayvv.Substring(0, 10))
                {
                    if (tuoi.Text != "")
                    {
                        if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                        {
                            tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                    if (!bTiepdon)
                    {
                        if (m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text) == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                            butBoqua_Click(sender, e);
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
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            string s = ngayvv.Text + " " + giovv.Text;
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            if (s != s_ngayvv)
            {
                l_maql = m.get_maql_benhancc(s_mabn, s, false);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                }
                else
                {
                    string s_tenkp = m.bHiendien_benhancc(s, s_mabn);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị {") + s_tenkp.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"), s_msg);
                        butBoqua_Click(null, null);
                        return;
                    }
                    if (ngayvv.Text.Substring(0, 10) == m.Ngayhienhanh)
                    {
                        string m_ngay = m.get_ngaytiepdon(s_mabn, s);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(s, m_ngay))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ vào không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                                ngayvv.Focus();
                                return;
                            }
                        }
                    }
                    emp_vv();
                    if (bBHYT_QRCode_Dangky == false || (bBHYT_QRCode_Dangky && mathe.Text == ""))
                    {                        
                        emp_bhyt();
                    }
                    emp_rv();
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                    else if (soluutru.Text == "" && b_sovaovien) soluutru.Text = sovaovien.Text;
                }
                s_ngayvv = ngayvv.Text + " " + giovv.Text;
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào !"), s_msg);
                ngayrv.Focus();
                return;
            }
            if (!m.bNgay(ngayrv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayrv.Focus();
                return;
            }
            if (s_ngayrk != "")
            {
               
                if (ngayrv.Text != s_ngayrk.Substring(0, 10))
                {
                    if (!m.ngay(m.StringToDate(ngayrv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày ra không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        ngayrv.Focus();
                        return;
                    }
                }
                try
                {
                    songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvv.Text.Substring(0, 10)), 1).ToString();
                    if (songaydt.Text == "0") songaydt.Text = "1";
                }
                catch { songaydt.Text = ""; }
                if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text;
                else if (soluutru.Text == "" && b_sovaovien) soluutru.Text = sovaovien.Text;
            }
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
            if (ngayrv.Text != s_ngayrk)
            {
                if (!m.bNgaygio(ngayrv.Text + " " + giorv.Text, ngayvv.Text + " " + giovv.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày ra không được nhỏ hơn ngày vào !"), s_msg);
                    ngayrv.Focus();
                    return;
                }
            }
        }

        private void noidk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) list.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (list.Visible)
                {
                    list.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void noidk_TextChanged(object sender, EventArgs e)
        {
            Filt_noicap(noidk.Text);
            if (traituyen.Enabled) list.BrowseToText(noidk, manoidk, traituyen, tungay.Location.X, tungay.Location.Y + noidk.Height - 2, noidk.Width + tungay.Width + denngay.Width + sovaovien.Width * 2 - 7, noidk.Height);
            else if (sovaovien.Enabled) list.BrowseToText(noidk, manoidk, sovaovien, tungay.Location.X, tungay.Location.Y + noidk.Height - 2, noidk.Width + tungay.Width + denngay.Width + sovaovien.Width * 2 - 7, noidk.Height);
            else list.BrowseToText(noidk, manoidk, quanhe, tungay.Location.X, tungay.Location.Y + noidk.Height - 2, noidk.Width + denngay.Width + denngay.Width + sovaovien.Width * 2 - 7, noidk.Height);
        }

        private void Filt_noicap(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
        }

        private void butInchitiet_Click(object sender, EventArgs e)
        {
            string ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            if (!bAdmin && ngayrv.Text != ngaysrv)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không quyền in lại!\nNgày khám bệnh khác ngày hiện hành") + " " + ngaysrv, LibMedi.AccessData.Msg);
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            if (s_mabn == "" || ngayvv.Text == "") return;
            if (!m.bMmyy(m.mmyy(ngayvv.Text)))
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đang điều trị !"), LibMedi.AccessData.Msg);
                if (ngayrv.Text == "") ngayrv.Focus();
                else butLuu.Focus();
                return;
            }
            if (m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".benhancc where to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngayvv.Text + " " + giovv.Text + "' and mabn='" + s_mabn + "' and ngayrv is not null").Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đang điều trị !"), LibMedi.AccessData.Msg);
                if (ngayrv.Text == "") ngayrv.Focus();
                else butLuu.Focus();
                return;
            }
            else if (butLuu.Enabled) butLuu_Click(null, null);
            string _tenkp = m.inchiphipk(ngayvv.Text, l_matd);
            if (_tenkp != "")
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Chi phí đã in") + "\n" + lan.Change_language_MessageText("Bạn có muốn in lại ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    butTiep.Focus();
                    return;
                }
            }
            //gam 20/10/2011 kiểm tra nếu bệnh nhân đăng kí nhiều phòng khám hay đăng ký nhiều lần trong ngày và vẫn còn trong danh sách chờ khám tại phòng khac thì không cho phép in
            if (bDichvu_vpkb && m.get_data_mmyy("select maql,mavaovien,mabn,done from xxx.tiepdon where mabn='" + s_mabn + "' and ( done is null or done='?' or done ='d') and to_char(ngay,'dd/mm/yyyy')='" + ngaysrv + "' ", ngayvv.Text, ngayvv.Text, 1).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có chờ khám tại phòng khám khác.\nKhông cho phép in"));
                return;

            }
            //gam 25/10/2011 kiểm tra nếu xử trí nhập khoa + gom chi phí phòng khám vào nội trú hoặc xử trí chuyển phòng khám và chi phí điều trị in trong ngày thì không cho phép in
            if (bDichvu_vpkb && ((maxutri.Text.IndexOf("05,") >= 0 && m.bChiphikp_noingoai) || (maxutri.Text.IndexOf("08,") >= 0 && m.bTiepdon_nkp_inchungchiphi)))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cho phép in."), LibMedi.AccessData.Msg);
                return;
            }
            try
            {
                inchiphi();
                d_id = 0; d_mmyy = "";
                if (bDichvu_vpkb) upd_vienphi();
                else if (bDuyet_khambenh && sothe.Text != "") d.execute_data("update " + user + m.mmyy(ngayvv.Text) + ".v_chidinh set paid=1 where where mabn='" + s_mabn + "' and mavaovien=" + l_matd + " and maql=" + l_maql);
                m.upd_inchiphipk(mabn2.Text + mabn3.Text.PadLeft(6, '0'), l_matd, ngayvv.Text + " " + giovv.Text, s_makp);
            }
            catch { }
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
                        sql += " and maql=" + l_maql;
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
            int stt = 1;
            if (d_id != 0 && d_mmyy != "" && bDuyet_khambenh && sothe.Text != "")
            {
                itable = d.tableid(d_mmyy, "bhytcls");
                d.execute_data("delete from " + user + d_mmyy + ".bhytcls where id=" + d_id);
                sql = "select * from " + yyy + ".v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                sql += " and maql=" + l_maql;
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    d.execute_data("update " + yyy + ".v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString()));
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
                //vpkhoa
                sql = "select * from " + yyy + ".v_vpkhoa where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                sql += " and maql=" + l_maql;
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    d.execute_data("update " + yyy + ".v_vpkhoa set done=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString()));
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
            else if (bDuyet_khambenh && sothe.Text != "")
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
                if (!d.upd_bhytkb(d_mmyy, d_id, i_nhom, ngayvv.Text, s_mabn, l_matd, l_maql, s_makp, cd_chinh.Text, icd_chinh.Text, mabs.Text, sothe.Text, int.Parse(madoituong.Text), manoidk.Text, i_userid, 4, traituyen.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytcls");
                sql = "select * from " + yyy + ".v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
                sql += " and maql=" + l_maql;
                sql += " and madoituong=" + int.Parse(madoituong.Text);
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));

                    d.execute_data("update " + yyy + ".v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString()));
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
        }

        private void inchiphi()
        {
            string s_trieuchung = "", s_ghichu_kb = "", s_phanbiet = "";
            dsxmlin.Clear();
            string s_noicap = "", s_chandoan = cd_chinh.Text.Trim() + ";", s_maicd = icd_chinh.Text.Trim() + ";", s_tenkp = "Phòng lưu", s_tenbs = "", yyy = user + m.mmyy(ngayvv.Text);
            int sokham = 1;
            if (cd_kemtheo.Text != "") s_chandoan += cd_kemtheo.Text.Trim() + ";";
            if (icd_kemtheo.Text != "") s_maicd += icd_kemtheo.Text.Trim() + ";";
            bool bTiepdon_nkp_inchungchiphi = m.bTiepdon_nkp_inchungchiphi;
            string atenbs = "", atenkp = "";
            if (bTiepdon_nkp_inchungchiphi)//gam 14/10/2011 gom chi phi nhieu phong kham
            {
                sql = "select maql,chandoan,maicd,tenkp,tenbs from (";
                sql += "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs from " + yyy + ".benhancc a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd;
                sql += " union all ";
                sql += "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs from " + yyy + ".benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd;
                sql += ") as a order by maql";
            }
            else
            {
                sql = "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs from " + yyy + ".benhancc a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_matd + " order by a.maql";
            }
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                sokham += 1;
                //s_maicd = r["maicd"].ToString().Trim() + ";";
                //s_chandoan = r["chandoan"].ToString().Trim() + ";";
                if (s_maicd.IndexOf(r["maicd"].ToString().Trim() + ";") < 0) s_maicd += r["chandoan"].ToString().Trim() + "; ";
                if (s_chandoan.IndexOf(r["chandoan"].ToString().Trim() + ";") < 0) s_chandoan += r["chandoan"].ToString().Trim() + "; ";
                s_tenkp = r["tenkp"].ToString().Trim() + ";";
                s_tenbs = r["tenbs"].ToString() + ";";
                atenkp += r["tenkp"].ToString().Trim() + ";";
                atenbs += r["tenbs"].ToString() + ";";
                foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + yyy + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows)
                {
                    s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
                //ghi chu + phan biet
                foreach (DataRow r1 in m.get_data("select distinct lydo, phanbiet from " + yyy + ".lydokham where maql=" + decimal.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    if (s_ghichu_kb.IndexOf(r1["lydo"].ToString().Trim() + ";") < 0 && r1["lydo"].ToString().Trim().Trim() != "") s_ghichu_kb += r1["lydo"].ToString().Trim() + ";";
                    if (s_phanbiet.IndexOf(r1["phanbiet"].ToString().Trim() + ";") < 0 && r1["phanbiet"].ToString().Trim().Trim() != "") s_phanbiet += r1["phanbiet"].ToString().Trim() + ";";
                }
                //trieu chung
                foreach (DataRow r1 in m.get_data("select distinct ten from " + yyy + ".trieuchung where maql=" + decimal.Parse(r["maql"].ToString())).Tables[0].Rows)
                {
                    if (s_trieuchung.IndexOf(r1["ten"].ToString().Trim() + ";") < 0 && r1["ten"].ToString().Trim().Trim() != "") s_trieuchung += r1["ten"].ToString().Trim() + ";";
                }
            }
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            sql = "select 1 as id,a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong||' ['||b.tenhc||']' as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "a.giaban as dongia,a.giaban*a.soluong as sotien,"; //gam 10/10/2011 sua t.giamua=a.giaban
            sql += "a.cachdung,0 as makho,0 as manguon,0 as nhomcc,f.makp,h.tenkp,f.maphu as madoituong,x.doituong,t.gianovat ";
            sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h," + user + ".doituong x";
            sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and f.makp=h.makp and f.maphu=x.madoituong";
            sql += " and f.mabn='" + s_mabn + "' ";
            if (bTiepdon_nkp_inchungchiphi) sql += "and (f.mavaovien=" + l_matd + "or to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "')";//gam 14/10/2011 nếu chọn option in chung chi phí trong ngày thì lấy theo mã vào viện hoặc theo ngày
            else sql += " and (f.maql=" + l_maql + " or f.makp='" + s_makp + "') and f.mavaovien=" + l_matd;
            if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
            ds1 = m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true);
            //
            sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong||' ['||b.tenhc||']' as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
            sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,g.makp,g.ten as tenkp,a.madoituong,x.doituong,g.makp,t.gianovat ";
            sql += " from xxx.d_thucxuat a," + user + ".d_dmbd b,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".d_doituong x";
            sql += " where f.id=a.id and a.sttt=t.id and a.mabd=b.id and f.makp=g.id and a.madoituong=x.madoituong";
            //sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;
            ////sql += " and f.loai=2 ";
            //sql += " and (f.maql=" + l_maql + " or g.makp='" + s_makp + "')";
            sql += " and f.mabn='" + s_mabn + "' ";
            if (bTiepdon_nkp_inchungchiphi) sql += "and (f.mavaovien=" + l_matd + "or to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "')";//gam 14/10/2011 nếu chọn option in chung chi phí trong ngày thì lấy theo mã vào viện hoặc theo ngày
            else sql += " and (f.maql=" + l_maql + " or f.makp='" + s_makp + "') and f.mavaovien=" + l_matd;
            if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
            ds1.Merge(d.get_thuoc(ngayvv.Text, ngayvv.Text, sql));
            //
            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.makp,h.tenkp,a.madoituong,x.doituong,a.dongia as gianovat ";
            sql += " from " + yyy + ".v_chidinh a," + user + ".v_giavp b," + user + ".btdkp_bv h," + user + ".doituong x where a.mavp=b.id and a.makp=h.makp and a.madoituong=x.madoituong ";
            //sql += " and a.mabn='" + s_mabn + "' and a.mavaovien=" + l_matd;//"and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            //sql += " and (a.maql=" + l_maql + " or a.makp='" + s_makp + "')";//
            sql += " and a.mabn='" + s_mabn + "' ";
            if (bTiepdon_nkp_inchungchiphi) sql += "and (a.mavaovien=" + l_matd + "or to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "')";//gam 14/10/2011 nếu chọn option in chung chi phí trong ngày thì lấy theo mã vào viện hoặc theo ngày
            else sql += " and (a.maql=" + l_maql + " or a.makp='" + s_makp + "') and a.mavaovien=" + l_matd;
            if (sothe.Text == "") sql += " and (a.paid=0 or a.idttrv=0) ";
            if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
            ds1.Merge(m.get_data(sql));

            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.makp,h.tenkp,a.madoituong,x.doituong,a.dongia as gianovat ";
            sql += " from " + yyy + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h," + user + ".doituong x where a.mavp=b.id and a.makp=h.makp and a.madoituong=x.madoituong ";
            //sql += " and a.mabn='" + s_mabn + "' and a.mavaovien=" + l_matd;//"and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            //sql += " and (a.maql=" + l_maql + " or a.makp='" + s_makp + "')";
            sql += " and a.mabn='" + s_mabn + "' ";
            if (bTiepdon_nkp_inchungchiphi) sql += "and (a.mavaovien=" + l_matd + "or to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "')";//gam 14/10/2011 nếu chọn option in chung chi phí trong ngày thì lấy theo mã vào viện hoặc theo ngày
            else sql += " and (a.maql=" + l_maql + " or a.makp='" + s_makp + "') and a.mavaovien=" + l_matd;
            if (sothe.Text == "") sql += " and (a.done=0 or a.idttrv=0)";
            if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
            ds1.Merge(m.get_data(sql));

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
            //
            int _userid = -1;
            ngay_reset_phieu38 = ngayvv.Text;
            if (d_mmyy.Trim() == "") d_mmyy = m.mmyy(ngayvv.Text);
            if (d.bSophieu_mau38_tangtheonam(m.nhom_duoc))
            {
                ngay_reset_phieu38 = "31/12/20" + d_mmyy.Substring(2, 2);
                d.upd_capsotoa(-99, ngay_reset_phieu38, 0, _userid);
                d.upd_capsotoa(-99, ngay_reset_phieu38, 1, _userid);
                d.upd_capsotoa(2, ngay_reset_phieu38, 0);
                d.upd_capsotoa(2, ngay_reset_phieu38, 1);
            }
            else if (d.bSophieu_mau38_tangtheonam_tinhtuthang12(m.nhom_duoc))
            {
                ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi("01" + d_mmyy.Substring(2, 2), m.nhom_duoc); //d.iNgaytinh_Sophieu_mau38_tangtheonam(m.nhom_duoc).ToString().PadLeft(2, '0') + "/12/20" + (int.Parse(d_mmyy.Substring(2, 2)) - 1).ToString().PadLeft(2, '0');
                //
                d.upd_capsotoa(-99, ngay_reset_phieu38, 0, _userid);
                d.upd_capsotoa(-99, ngay_reset_phieu38, 1, _userid);
                d.upd_capsotoa(2, ngay_reset_phieu38, 0);
                d.upd_capsotoa(2, ngay_reset_phieu38, 1);
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(m.nhom_duoc)) ngay_reset_phieu38 = "01/" + d_mmyy.Substring(0, 2) + "/20" + d_mmyy.Substring(2, 2);
                else if (d.bSophieu_mau38_tangtheothang_tinhtuthangtruoc(m.nhom_duoc))
                {
                    ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi(d_mmyy, m.nhom_duoc); //d.iNgaytinh_Sophieu_mau38_tangthang(m.nhom_duoc).ToString().PadLeft(2, '0') + "/" + tmp_mm.ToString().PadLeft(2, '0') + "/20" + tmp_yy.ToString().PadLeft(2, '0');
                }
                d.upd_capsotoa(d_mmyy, -99, ngay_reset_phieu38, 0, _userid);
                d.upd_capsotoa(d_mmyy, -99, ngay_reset_phieu38, 1, _userid);
                d.upd_capsotoa(d_mmyy, 2, ngay_reset_phieu38, 0);
                d.upd_capsotoa(d_mmyy, 2, ngay_reset_phieu38, 1);
            }
            //
            int isophieu = d.get_sophieu_bhyt_userid(d_mmyy, s_mabn, l_matd, ngayvv.Text, int.Parse(madoituong.Text), _userid, ngay_reset_phieu38);
            int lanin = d.get_laninkb(d_mmyy, s_mabn, l_matd, ngayvv.Text, int.Parse(madoituong.Text));
            //
            string dichso = "", s_ghichu = "";
            decimal bntra = 0, bhyttra = 0, mien = 0, tcsotien = 0;
            bool bMien = false;
            decimal i_tylechinhsach = 0;//gam 12/10/2011

            sql = "select a.ghichu from xxx.d_thuocbhytll a,xxx.bhytkb b";
            sql += " where a.id=b.id and a.ghichu<>''";
            sql += " and b.mabn='" + s_mabn + "' and b.mavaovien=" + l_matd;
            sql += " and b.maql=" + l_maql;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                s_ghichu += r["ghichu"].ToString().Trim() + ";";

            r2 = m.getrowbyid(dtdt, "mien=1 and madoituong=" + int.Parse(madoituong.Text));
            bMien = r2 != null;
            //foreach (DataRow r in dstmp.Tables[0].Rows)tcsotien += decimal.Parse(r["sotien"].ToString());
            foreach (DataRow r in dstmp.Tables[0].Select("madoituong=" + madoituong.Text)) tcsotien += decimal.Parse(r["sotien"].ToString());//gam 17/11/2011

            if (madoituong.Text == "1") bhyttra = tcsotien;
            else if (bMien) mien = tcsotien;
            else bntra = tcsotien;
            tcsotien += ((bCongkham) ? Congkham * sokham : 0);
            dichso = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
            decimal d_tamung = m.get_tamung(s_mabn, l_maql, ngayvv.Text, ngayrv.Text == "" ? ngayvv.Text : ngayrv.Text, s_makp, int.Parse(madoituong.Text));
            if (dstmp.Tables[0].Rows.Count == 0)
            {
                m.updrec_ravien(dsxmlin, s_mabn, s_mabn, l_maql, 2, hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(madoituong.Text),
                tendoituong.Text, sothe.Text, 0, tungay.Text + "^" + denngay.Text, s_noicap + "^" + manoidk.Text + "^" + tendstt.Text, s_noicap, tenbs.Text, s_makp, s_tenkp, ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                0, "", 0, "", 0, "", "", 0, 0, bhyttra, 0, (bCongkham) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs, 0, false, 0, mabs.Text, tenbs.Text, s_makp, "", int.Parse(madoituong.Text), 0, 0, 0, traituyen.SelectedIndex, int.Parse("-1"), "");
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
                        try
                        {
                            m.updrec_ravien(dsxmlin, r["sttt"].ToString(), s_mabn, l_maql, decimal.Parse(r["sttt"].ToString()) + decimal.Parse(r["id"].ToString()), hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim(), int.Parse(r["madoituong"].ToString()),
                                r["doituong"].ToString(), sothe.Text, 0, tungay.Text + "^" + denngay.Text, s_noicap + "^" + manoidk.Text + "^" + tendstt.Text, s_noicap, tenbs.Text, r["makp"].ToString(), r["tenkp"].ToString(), ngayvv.Text + " " + giovv.Text, s_ghichu, s_chandoan, s_maicd,
                                int.Parse(r2["sttnhom"].ToString()), r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r["cachdung"].ToString(),
                                int.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(),
                                decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sotien"].ToString()),
                                bhyttra, d_tamung, (bCongkham) ? Congkham : 0, qh_hoten.Text, 1, 0, sokham, s_tenbs + "^" + s_userid, decimal.Parse(r["dongia"].ToString()), true, 0, mabs.Text, tenbs.Text, s_makp, "", int.Parse(r["madoituong"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, decimal.Parse(r["sotien"].ToString()), traituyen.SelectedIndex, int.Parse(r2["kythuat"].ToString()), "");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            int maphu = 0, _madt = 0;
            decimal chitra = 0;
            if (madoituong.Text == "1" && sothe.Text != "")
            {
                maphu = (bPhongluu_bhyt_khambenh) ? d.get_maphu_ngtru(sothe.Text, tcsotien, m.nhom_duoc) : d.get_maphu(sothe.Text);
            }
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
            decimal haophi = 0, Bhyt_7cn = 0;//(ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0;
            //Tu:29/06/2011 them cot tlchitra
            try
            {
                dsxmlin.Tables[0].Columns.Add("tyletra", typeof(decimal)).DefaultValue = 0;
            }
            catch { }//end
            try
            {
                dsxmlin.Tables[0].Columns.Add("tlchitra", typeof(decimal)).DefaultValue = 0;
            }
            catch { }//end
            try
            {
                dsxmlin.Tables[0].Columns.Add("toathuocve", typeof(decimal)).DefaultValue = 0;
            }
            catch { }//end
            try
            {
                dsxmlin.Tables[0].Columns.Add("tlchinhsach", typeof(decimal)).DefaultValue = 0;
                dsxmlin.Tables[0].Columns.Add("thangtuoi", typeof(decimal)).DefaultValue = 0;
            }
            catch { }//gam 12/10/2011
            i_tylechinhsach = m.get_tyle_bhyt_chinhsach(sothe.Text);
            foreach (DataRow r in dsxmlin.Tables[0].Select("madt=" + iHaophi)) haophi += decimal.Parse(r["sotien"].ToString());
            foreach (DataRow r in dsxmlin.Tables[0].Select("", "madoituong,madt,sttnhom,ten"))
            {
                chitra = 0;
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
                    r["tlchinhsach"] = i_tylechinhsach;//gam 12/10/2011
                    if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0)
                    {
                        chitra = iTraituyen;
                        r["tyletra"] = chitra;//Tu:29/06/2011
                        r["bhyttra"] = tcsotien * chitra / 100;
                        r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                    }
                    else if (Bhyt_7cn != 0 && tcsotien > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn;
                        r["bntra"] = tcsotien - Bhyt_7cn;
                        chitra = Math.Round(Bhyt_7cn / tcsotien, 2);
                    }
                    else
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            r["tyletra"] = chitra;//Tu:29/06/2011
                            r["bhyttra"] = tcsotien * chitra / 100;
                            r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                        }
                        else
                        {
                            r["bhyttra"] = tcsotien;
                            r["bntra"] = 0;
                            chitra = 100;
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen;
                            r["bntra"] = tcsotien - lTraituyen;
                            chitra = Math.Round(lTraituyen / tcsotien, 2);
                        }
                    }
                }
                else
                {
                    r["bhyttra"] = 0;
                    r["bntra"] = tcsotien;
                    chitra = 0;
                }
                r["dichso"] = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
                r["haophi"] = haophi;
                r["tcsotien"] = zsum;
                if (chkToathuoc.Checked)
                {
                    r["toathuocve"] = r["idkhoa"].ToString();
                }
                r["idkhoa"] = isophieu;
                r["maql"] = lanin;
                r["tyletra"] = chitra;//Tu:29/06/2011
                r["tlchitra"] = chitra;//Tu:29/06/2011
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
            if (dsxmlin.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsxmlin.Tables[0].Rows)
                {
                    r["tenuser"] = s_userid;
                    //
                    r["phanbiet"] = s_phanbiet;
                    r["ghichukb"] = s_ghichu_kb;
                    r["trieuchung"] = s_trieuchung;
                }
                if (chkXML.Checked)
                {
                    if (System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dsxmlin.WriteXml("..//xml//chiphipk.xml", XmlWriteMode.WriteSchema);
                    
                }
                if (chkXem.Checked)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxmlin, "rpt_chiphi_kp.rpt", atenkp, atenbs, s_chandoan, s_maicd, "", "");
                    f.ShowDialog();
                }
                else print.Printer(m, dsxmlin, "rpt_chiphi_kp.rpt", atenkp, atenbs, s_chandoan, s_maicd, "", "", "", "", "", "", 1);
            }
            if (chkToathuoc.Checked)
            {
                m.delrec(dsxmlin.Tables[0], "toathuocve=2");
                if (dsxmlin.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsxmlin.Tables[0].Rows)
                    {
                        r2 = m.getrowbyid(dtbd, "nhomin in (1,2,3) and id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null) r["nguoinha"] = doiso.doithapphan(r["soluong"].ToString());
                    }
                    if (chkXem.Checked)
                    {
                        dllReportM.frmReport f = new dllReportM.frmReport(m, dsxmlin, s_tenkp, "rpt_toathuoc_kp.rpt");
                        f.ShowDialog();
                    }
                    else print.Printer(m, dsxmlin, "rpt_toathuoc_kp.rpt", s_tenkp, 1);
                }
            }
        }

        private void butPhong_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "") return;
            if (m.get_data("select * from " + user + ".theodoigiuong where mabn='" + mabn2.Text + mabn3.Text.PadLeft(6, '0') + "' and makp='" + s_makp + "' and den is null").Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đã chọn phòng/giường") + "\n" + lan.Change_language_MessageText("Nếu muốn chuyển phòng/giường thì chọn phần chuyển phòng giường !"), LibMedi.AccessData.Msg);
                return;
            }
            frmDsgiuong f = new frmDsgiuong(m, s_makp, int.Parse(madoituong.Text));
            f.ShowDialog();
            if (f.ma != "") giuong.Text = f.ma;
            if (ketqua.Text == "") ketqua.Focus();
            else butLuu.Focus();
        }

        private void lydo_TextChanged(object sender, EventArgs e)
        {
            if (lydo.Text == "\r\n") ngayrv.Focus();
        }

        #region vantay_thang
        void lay_mabn_vantay()
        {
            string tmp_mabn = (mabn3.Text.Trim() != "") ? f_get_mabn() : "";
            string ma_vantay = "";
            FingerApp.FrmNhanDang fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == i_maxlength_mabn)
            {
                mabn2.Text = ma_vantay.Substring(0, 2);
                mabn3.Text = ma_vantay.Substring(2);
                s_mabn = f_get_mabn();
                mabn3_Validated(null, null);
                ngayvv.Focus();
                SendKeys.Send("{Home}");
            }
        }

        string f_get_mabn()
        {
            string _mabn = "";
            if (mabn3.Text.Trim() == "") return "";
            _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(6,'0');
            if (i_maxlength_mabn > 8) _mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(6,'0');
            return _mabn;
        }
        private void luu_vantay()
        {
            try
            {
                string ma = mabn2.Text + mabn3.Text.PadLeft(6, '0');
                fnhandang.save_orac(ma);
            }
            catch { }
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
        #endregion

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (bVantay) lay_mabn_vantay();
        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
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

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text);
            f.ShowDialog();
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

        private void maxutri_Validated(object sender, EventArgs e)
        {
            s_chonxutri = maxutri.Text.Trim().Replace("00", "");
            if (s_chonxutri != "")
            {
                if (s_chonxutri.Substring(s_chonxutri.Length) != ",") s_chonxutri += ",";
                for (int i = 0; i < xutri.Items.Count; i++) xutri.SetItemCheckState(i, CheckState.Unchecked);
                for (int i = 0; i <= xutri.Items.Count; i++)
                    if (s_chonxutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                loaibv.Enabled = (s_chonxutri.IndexOf("06,") != -1);
                tenloaibv.Enabled = loaibv.Enabled;
                mabv.Enabled = loaibv.Enabled;
                tenbv.Enabled = loaibv.Enabled;
                khoa.Enabled = (s_chonxutri.IndexOf("05,") != -1 || s_chonxutri.IndexOf("02,") != -1 || s_chonxutri.IndexOf("08,") != -1);
                if (khoa.Enabled)
                {
                    sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                    if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                    else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
                    if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
                    sql += " order by makp";
                    tenkhoa.DataSource = m.get_data(sql).Tables[0];
                    if (tenkhoa.SelectedIndex != -1) khoa.Text = tenkhoa.SelectedValue.ToString();
                }
                tenkhoa.Enabled = khoa.Enabled;
                SendKeys.Send("{Tab}");
            }
        }

        private void mabsnb_Validated(object sender, EventArgs e)
        {
            if (mabsnb.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + mabsnb.Text + "'");
                if (r != null) tenbsnb.Text = r["hoten"].ToString();
                else tenbsnb.Text = "";
                if (mabs.Text == "")
                {
                    mabs.Text = mabsnb.Text;
                    tenbs.Text = tenbsnb.Text;
                }
            }
        }

        private void tenbsnb_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenbsnb)
            {
                Filt_tenbs(tenbsnb.Text);
                listBS.BrowseToICD10(tenbsnb, mabsnb, ngayrv, mabsnb.Location.X, mabsnb.Location.Y + mabsnb.Height - 2, mabsnb.Width + tenbsnb.Width + 2, mabsnb.Height);
            }
        }

        private void traituyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tenbsnb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else ngayrv.Focus();
            }
        }

        private bool bRaphongluu(decimal maql)
        {
            string asql = "select case when ngayrv is null then '' else to_char(ngayrv,'dd/mm/yyyy') end as ngayrv from " + user + m.mmyy(ngayvv.Text) + ".benhancc where maql=" + maql;
            DataSet lds = m.get_data(asql);
            return lds.Tables[0].Rows[0]["ngayrv"].ToString() != "";
        }

        //
        private void f_load_option()
        {
            s_matinh_bhyt = m.s_matinh_bhyt;
            s_vitri_matinh_bhyt = m.s_vitri_matinh_bhyt;
            bChuathanhtoan_khongcho_nhanbenh = m.bChuathanhtoan_khongcho_nhanbenh;
            bMabn_tudong_tu_ServerInterNet_D24 = m.bMabn_tudong_tu_ServerInterNet_D24;
            butget_msbn_from_internet.Visible = bMabn_tudong_tu_ServerInterNet_D24;
            bMabn_tudong = m.bMabn_tudong_tiepdon;
            //ThanhCuong 21/03/2012
            bThongBaoSoVaoVien = m.bthongbaosovaovien;
            //End ThanhCuong
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;            
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            mabn3.MaxLength = i_maxlength_mabn - ((bQuanly_Theo_Chinhanh) ? 2 : 4);
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
                    // ma = cms.get_cap_mabn(s_nam);
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
                if (mabn3.Text.Trim() != "")
                {
                    m.upd_capmabn(int.Parse(s_nam), 0, 0, int.Parse(mabn3.Text));
                }
                mabn3.Focus();
            }
            catch { Cursor = Cursors.Default; }
            Cursor = Cursors.Default;
        }

        private void tButBaolucgiadinh_Click(object sender, EventArgs e)
        {
            s_mabn = mabn2.Text + mabn3.Text.PadLeft(6, '0');
            l_maql = m.get_maql_benhancc(s_mabn, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(sender, e);
            }
            frmPhieusanglocBLGD f = new frmPhieusanglocBLGD(m, s_mabn, hoten.Text, l_matd, l_maql, int.Parse(tuoi.Text.Trim()), trieuchung.Text.Trim(), phai.Text, ngayvv.Text + " " + giovv.Text, s_makp, i_userid, thon.Text.Trim(), matt.Text, mapxa1.Text.Trim() + mapxa2.Text.Trim(), maqu1.Text.Trim() + maqu2.Text.Trim());
            f.ShowDialog();
        }
        private bool f_kiemtra_xutri_hople(string m_xutri)
        {
            bool berr_xutri = false;
            m_xutri = m_xutri.Trim().Trim(',') + ",";
            if (m_xutri.IndexOf("07,") >= 0 && m_xutri.Length > 3)//tu vong, thi khong cho chon xu tri gi them
            {
                berr_xutri = true;

            }
            else if (m_xutri.IndexOf("06,") >= 0 && (m_xutri.IndexOf("02,") >= 0 || m_xutri.IndexOf("03,") >= 0 || m_xutri.IndexOf("04,") >= 0 || m_xutri.IndexOf("05,") >= 0 || m_xutri.IndexOf("08,") >= 0))//chuyen vien thi khong: dt ngoai tru, chuyen phong luu, chuyen phong kham, nhap vien
            {
                berr_xutri = true;
            }
            else if (m_xutri.IndexOf("05,") >= 0 && (m_xutri.IndexOf("02,") >= 0 || m_xutri.IndexOf("03,") >= 0 || m_xutri.IndexOf("04,") >= 0 || m_xutri.IndexOf("08,") >= 0))
            {
                berr_xutri = true;
            }
            else if (m_xutri.IndexOf("04,") >= 0 && (m_xutri.IndexOf("02,") >= 0 || m_xutri.IndexOf("03,") >= 0 || m_xutri.IndexOf("08,") >= 0))
            {
                berr_xutri = true;
            }
            else if (m_xutri.IndexOf("03,") >= 0 && (m_xutri.IndexOf("02,") >= 0))
            {
                berr_xutri = true;
            }
            else if (m_xutri.IndexOf("02,") >= 0 && (m_xutri.IndexOf("08,") >= 0))
            {
                berr_xutri = true;
            }
            return berr_xutri;
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

        private void sothe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void icd_nguyennhan_TextChanged(object sender, EventArgs e)
        {
            listICD.Hide();
        }

        private void icd_nguyennhan_Validated(object sender, EventArgs e)
        {
            if (icd_nguyennhan.Text != s_icd_nguyennhan)
            {
                if (icd_nguyennhan.Text == "") cd_nguyennhan.Text = "";
                else cd_nguyennhan.Text = m.get_vviet(icd_nguyennhan.Text);
                if (cd_nguyennhan.Text == "" && icd_nguyennhan.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_nguyennhan.Text, cd_nguyennhan.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_nguyennhan.Text = f.mTen;
                        icd_nguyennhan.Text = f.mICD;
                    }
                }
                s_icd_nguyennhan = icd_nguyennhan.Text;
            }
            //
        }

        private void cd_nguyennhan_Validated(object sender, EventArgs e)
        {
            if (icd_nguyennhan.Text == "") icd_nguyennhan.Text = m.get_cicd10(cd_nguyennhan.Text);
            if (!m.bMaicd(icd_nguyennhan.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"), s_msg);
                icd_nguyennhan.Text = "";
                icd_nguyennhan.Focus();
            }
        }

       

        private void cd_nguyennhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }		
        }

        private void tbutchuphinh_Click(object sender, EventArgs e)
        {
            s_mabn = f_get_mabn();// mabn2.Text + mabn3.Text;

            if (l_maql == 0)
            {
                if (!kiemtra(false)) return;
                butLuu_Click(null, null);
                frmChuphinhchungtu f = new frmChuphinhchungtu(s_mabn, decimal.Parse(l_matd.ToString()), i_userid);
                f.ShowDialog();
            }
            else
            {
                if (treeView1.SelectedNode == null)
                {
                    frmChuphinhchungtu f = new frmChuphinhchungtu(s_mabn, decimal.Parse(l_matd.ToString()), i_userid);
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

        private void manoidk_Validated(object sender, EventArgs e)
        {
            try
            {
                noidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where hide=0 and mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }
        
        private void chkBhyt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkBhyt)
            {
                m.writeXml("thongso", "c345", (chkBhyt.Checked) ? "1" : "0");
               //MessageBox.Show(chkBhyt.Checked.ToString());
                mathe.Enabled = bBHYT_QRCode_Dangky || (bSothe_dmbhyt && chkBhyt.Checked);
            }

        }

        private void mathe_Validated(object sender, EventArgs e)
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
                    tendoituong.SelectedValue = "1"; madoituong.Text = "1";
                }
            }
            else if (bBHYT_QRCode_Dangky)
            {                
                if (mathe.Text.Trim() == "") return;
                emp_text(true);
                f_split_QRCode_BHYT(mathe.Text);
                tendoituong.Enabled = madoituong.Enabled = s_QRcode_sothe == "";
                mathe.Enabled = false;
                try
                {
                    if (sothe.Text.Length > 2 && sothe.Text.Substring(0, 2) == "HS")
                    {
                        mann.Text = "02";
                    }
                    else
                    {
                        mann.Text = "99";
                    }
                    tennn.SelectedValue = mann.Text;
                    if (namsinh.Text == "")
                    {
                        namsinh.Focus();
                    }
                    else 
                    {
                        mann.Focus();
                    }
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
            if (a_length > 0) s_QRcode_sothe = arr_QRCode[0] + arr_QRCode[5].Trim().Replace("-", "").Replace(" ", "");
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
                if (s_QRcode_ngaysinh.Length >= 4)
                {
                    namsinh.Text = s_QRcode_ngaysinh.Substring(s_QRcode_ngaysinh.Length - 4);
                    if (a_qrcode_mabn == "") namsinh_Validated(null, null);
                }
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
            manoidk.Text = s_QRcode_mabv;
            manoidk_Validated(null, null);
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

        private void mathe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}");
        }

        private void mathe_TextChanged(object sender, EventArgs e)
        {
            //if (mathe.Text != "" && bBHYT_QRCode_Dangky == false)
            //{
            //    string _mabn = "";
            //    DataTable tmp = m.getdmthe("", mathe.Text, (ngayvv.Text != "") ? ngayvv.Text : m.Ngayhienhanh).Tables[0];
            //    foreach (DataRow r in tmp.Rows)
            //    {
            //        _mabn = r["mabn"].ToString();
            //        mathe.Text = r["sothe"].ToString();
            //        if (_mabn == "")
            //        {
            //            hoten.Text = r["hoten"].ToString();
            //            hoten.Tag = r["hoten"].ToString();
            //            namsinh.Text = r["namsinh"].ToString();
            //            namsinh.Tag = namsinh.Text;
            //            tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
            //            loaituoi.SelectedIndex = 0;
            //            phai.SelectedIndex = int.Parse(r["gioitinh"].ToString());
            //            thon.Text = r["diachi"].ToString();
            //            cholam.Text = r["cholam"].ToString();
            //            tentinh.SelectedValue = r["matt"].ToString();
            //            load_quan();
            //            tenquan.SelectedValue = r["maqu"].ToString();
            //            load_pxa();
            //            tenpxa.SelectedValue = r["maphuongxa"].ToString();
            //            madoituong.Text = "1"; tendoituong.SelectedValue = "1";
            //            sothe.Text = mathe.Text;
            //            mabv.Text = r["mabv"].ToString();
            //            tenbv.Text = r["tenbv"].ToString();
            //            tungay.Text = r["tungay"].ToString();
            //            denngay.Text = r["denngay"].ToString();
            //        }
            //        break;
            //    }
            //    if (_mabn != "")
            //    {
            //        s_mabn = _mabn;
            //        if (s_mabn.Length > 8)
            //        {
            //            mabn1.Text = _mabn.Substring(0, 2);
            //            mabn2.Text = _mabn.Substring(2, 2);
            //            mabn3.Text = _mabn.Substring(4);
            //        }
            //        else
            //        {

            //            mabn2.Text = _mabn.Substring(0, 2);
            //            mabn3.Text = _mabn.Substring(2);
            //        }
            //        load_mabn();
            //        giovv.Focus();// ngayvv.Focus();
            //    }
            //    else
            //    {
            //        sothe.Text = mathe.Text;
            //        tendoituong.SelectedValue = "1"; madoituong.Text = "1";
            //    }
            //}
            //else if (bBHYT_QRCode_Dangky)
            //{
            //    //xu ly the QR code cua BHYT
            //    if (mathe.Text.Trim() == "") return;
            //    f_split_QRCode_BHYT(mathe.Text);
            //    tendoituong.Enabled = madoituong.Enabled = s_QRcode_sothe == "";
            //    mathe.Enabled = false;
            //    try
            //    {
            //        if (sothe.Text.Length > 2 && sothe.Text.Substring(0, 2) == "HS")
            //        {
            //            mann.Text = "02";
            //        }
            //        else
            //        {
            //            mann.Text = "99";
            //        }
            //        tennn.SelectedValue = mann.Text;
            //        if (namsinh.Text == "")
            //        {
            //            namsinh.Focus();
            //        }
            //        else
            //        {
            //            mann.Focus();
            //        }
            //    }
            //    catch { }
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mabn3.Text.Length > 1)
            {
                DataSet dsbarcode = new DataSet();
                dsbarcode.ReadXml("..//..//..//xml//m_bnmoi.xml");
                dsbarcode.Tables[0].Clear();
                dsbarcode.Tables[0].Columns.Add("mabn");
                dsbarcode.Tables[0].Columns.Add("hoten");
                dsbarcode.Tables[0].Columns.Add("namsinh");
                dsbarcode.Tables[0].Columns.Add("phai");
                dsbarcode.Tables[0].Columns.Add("diachi");
                dsbarcode.Tables[0].Columns.Add("barcode");
                dsbarcode.Tables[0].Columns.Add("image", typeof(byte[]));
                DataRow dr = dsbarcode.Tables[0].NewRow();
                dr["mabn"] = f_get_mabn();
                dr["hoten"] = hoten.Text;
                dr["namsinh"] = namsinh.Text;
                dr["phai"] = phai.Text;
                dr["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
                dr["image"] = null;
                dsbarcode.Tables[0].Rows.Add(dr);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsbarcode, "rptbarcode.rpt", f_get_mabn(), hoten.Text, namsinh.Text, phai.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + "," + tenquan.Text.Trim() + "," + tentinh.Text.Trim(), "");
                f.ShowDialog(this);
            }
        }

    }
}